Imports System.Data.SqlClient

Public Class frmCategories
    Dim ds As New DataSet
    Dim dataAdapter As SqlDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)
        dgvCategories.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvCategories.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    'Set up connection to database
    Private Function ConnectToDb() As SqlConnection
        'This gives the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length

        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 25)

        Dim strconnection As String = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + strPath + "Inventory.mdf"
        Dim dbConnection As New SqlConnection(strconnection)

        Return dbConnection
    End Function

    Public Sub LoadTableData(ByVal searchTerm As String)

        ds.Tables.Clear()
        Dim selectStatement As String = "SELECT * FROM Category"


        If searchTerm IsNot String.Empty Then
            Dim srh As String = "' hello'"
            Dim dbConnection As SqlConnection = ConnectToDb()
            Dim srchSelectStatement As String = "Select * from category where description = @val "

            dbConnection.Open()

            Dim saveCommand As New SqlCommand(srchSelectStatement, dbConnection)

            saveCommand.Parameters.AddWithValue("@val", srh)


            Try
                If saveCommand.ExecuteNonQuery > 0 Then
                    dataAdapter = New SqlDataAdapter(srchSelectStatement, dbConnection)
                    dataAdapter.Fill(ds)
                    dgvCategories.DataSource = ds.Tables(0)
                    dbConnection.Close()
                Else
                    MessageBox.Show("items not Found" + saveCommand.CommandText)

                End If
            Catch ex As Exception
                MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
            End Try



        Else
            Dim dbConnection As SqlConnection = ConnectToDb()
            dbConnection.Open()
            dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)
            dataAdapter.Fill(ds)
            dgvCategories.DataSource = ds.Tables(0)
            dbConnection.Close()


        End If


    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim cmd As SqlCommandBuilder = New SqlCommandBuilder(dataAdapter)
            Dim changes As DataSet = ds.GetChanges()
            If changes IsNot Nothing Then
                dataAdapter.Update(changes)
                MsgBox("Changes Saved")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvCategories_Click(sender As Object, e As EventArgs) Handles dgvCategories.Click
        dgvCategories.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        frmDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        frmItems.Show()
        Me.Close()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        'Already on this page
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        frmLocations.Show()
        Me.Close()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        frmExport.Show()
        Me.Close()
    End Sub
End Class