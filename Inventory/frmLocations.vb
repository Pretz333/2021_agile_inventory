Imports System.Data.SqlClient

Public Class frmLocations
    Dim ds As New DataSet
    Dim dataAdapter As SqlDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)
        dvgLocations.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dvgLocations.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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
        Dim selectStatement As String = "SELECT * FROM Location"
        If searchTerm IsNot String.Empty Then
            selectStatement += " WHERE Description LIKE '%" + searchTerm + "%'"
        End If
        dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)
        dataAdapter.Fill(ds)
        dvgLocations.DataSource = ds.Tables(0)
        dbConnection.Close()
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

    Private Sub dvgLocations_Click(sender As Object, e As EventArgs) Handles dvgLocations.Click
        dvgLocations.DefaultCellStyle.SelectionBackColor = Color.Orange
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
        frmCategories.Show()
        Me.Close()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        'Already on this page
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        frmExport.Show()
        Me.Close()
    End Sub

    Private Sub btnAssociate_Click(sender As Object, e As EventArgs) Handles btnAssociate.Click
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Try
            Dim categoryDesc As String = InputBox("Category to add to a Location", "Add Category to a Location")
            Dim locationDesc As String = InputBox("Location to add the Category to", "Add Category to a Location")
            Dim catCmd As SqlCommand = New SqlCommand("SELECT CategoryID FROM Category WHERE Description LIKE '%" + categoryDesc + "%'", dbConnection)
            Dim locCmd As SqlCommand = New SqlCommand("SELECT LocationID FROM Location WHERE Description LIKE '%" + locationDesc + "%'", dbConnection)
            Dim CategoryId = catCmd.ExecuteScalar().ToString()
            Dim LocationId = locCmd.ExecuteScalar().ToString()
            If CategoryId Is Nothing Then
                MsgBox("That Category was not recognized, please try again.")
            ElseIf LocationId Is Nothing Then
                MsgBox("That Location was not recognized, please try again.")
            Else
                Dim insertCmd As SqlCommand = New SqlCommand("INSERT INTO CategoryLocation (LocationID, CategoryID) VALUES (" + LocationId + ", " + CategoryId + ")", dbConnection)
                MsgBox(insertCmd.ExecuteNonQuery().ToString() + " row affected") 'IF >0 UPDATE INVENTORYMAIN
            End If
        Catch
            MsgBox("Something went wrong, please try again.")
        End Try
        dbConnection.Close()
    End Sub

    Private Sub btnDisassociate_Click(sender As Object, e As EventArgs) Handles btnDisassociate.Click
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Try
            Dim categoryDesc As String = InputBox("Category to remove from a location", "Remove Category from a Location")
            Dim locationDesc As String = InputBox("Location to remove the Category from", "Remove Category from a Location")
            Dim catCmd As SqlCommand = New SqlCommand("SELECT CategoryID FROM Category WHERE Description LIKE '%" + categoryDesc + "%'", dbConnection)
            Dim locCmd As SqlCommand = New SqlCommand("SELECT LocationID FROM Location WHERE Description LIKE '%" + locationDesc + "%'", dbConnection)
            Dim CategoryId = catCmd.ExecuteScalar().ToString()
            Dim LocationId = locCmd.ExecuteScalar().ToString()
            If CategoryId Is Nothing Then
                MsgBox("That Category was not recognized, please try again.")
            ElseIf LocationId Is Nothing Then
                MsgBox("That Location was not recognized, please try again.")
            Else
                Dim removeCmd As SqlCommand = New SqlCommand("DELETE FROM CategoryLocation WHERE LocationID =" + LocationId + " AND CategoryID = " + CategoryId, dbConnection)
                MsgBox(removeCmd.ExecuteNonQuery().ToString() + " row affected") 'IF >0 UPDATE INVENTORYMAIN
            End If
        Catch
            MsgBox("Something went wrong, please try again.")
        End Try
        dbConnection.Close()
    End Sub
End Class