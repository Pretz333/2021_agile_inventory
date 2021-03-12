Imports System.Data.SqlClient

Public Class frmItems
    Dim ds As New DataSet
    Dim dataAdapter As SqlDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)
        dgvItems.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).HeaderText = "Category"
        dgvItems.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvItems.Columns.Item(2).HeaderText = "Description"
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
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        ds.Tables.Clear()
        Dim selectStatement As String = "SELECT Item.ItemID, Category.Description, Item.Description FROM [Item] INNER JOIN [Category] ON Item.[CategoryID] = Category.[CategoryID]"
        If searchTerm IsNot String.Empty Then
            selectStatement += " WHERE Item.Description LIKE '%" + searchTerm + "%'"
        End If
        dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)
        dataAdapter.Fill(ds)
        dgvItems.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    Private Function GetCategoryComboBoxColumn() As DataGridViewComboBoxColumn
        Dim dataTable As New DataTable
        Dim cboColumnCategory As New DataGridViewComboBoxColumn
        Dim dbConnection As SqlConnection = ConnectToDb()
        Using dbConnection
            Dim categorySelectStatement As String = "SELECT Description FROM Category"
            dataAdapter = New SqlDataAdapter(categorySelectStatement, dbConnection)
            dataAdapter.Fill(dataTable)

            For Each dataRow As DataRow In dataTable.Rows
                cboColumnCategory.Items.Add(dataRow("Description"))
            Next

            cboColumnCategory.HeaderText = "Category"
            cboColumnCategory.Name = "Category"

            Return cboColumnCategory
        End Using
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dbConnection As SqlConnection = ConnectToDb()

        Dim cmd As New SqlCommand("", dbConnection)
        Dim CategoryID As String
        Try
            dbConnection.Open()
            For i As Integer = 0 To dgvItems.Rows.Count - 2 'The last row is blank
                cmd.CommandText = "SELECT CategoryID FROM Category WHERE Description LIKE '%" + dgvItems.Rows.Item(i).Cells(1).Value.ToString() + "%'"
                CategoryID = cmd.ExecuteScalar().ToString()
                If CategoryID Is Nothing Then
                    MsgBox("The Category on Row #" + i.ToString() + " was unrecognized.")
                Else
                    cmd.CommandText = "UPDATE Item SET CategoryID = " + CategoryID + ", Description = '" + dgvItems.Rows.Item(i).Cells(2).Value.ToString() + "' WHERE ItemID = " + dgvItems.Rows(i).Cells(0).Value.ToString()
                    If cmd.ExecuteNonQuery() > 0 Then
                        MsgBox("Success!")
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("Something went wrong, please try again", "Error")
        End Try
        dbConnection.Close()
    End Sub

    Private Sub dgvItems_Click(sender As Object, e As EventArgs) Handles dgvItems.Click
        dgvItems.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        frmDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        'Already on this page
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        frmCategories.Show()
        Me.Close()
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