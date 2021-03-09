Imports System.Data.SqlClient

Public Class frmDashboard
    Dim ds As New DataSet
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        'LoadTableData(String.Empty)
    End Sub

    'set up connection function
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
        Dim command As String = "SELECT * FROM InventoryMain" 'add joins to not display IDs
        dbConnection.Open()

        If searchTerm IsNot "" Then
            'select query to find the item that was looked for
            command += " WHERE Description LIKE '%" + searchTerm + "%'"
            ds.Tables.Clear()
            'Dim adapter As New SqlDataAdapter("select t1.description as Item, t2.description as Cat from item as t1 left join category as t2 on t1.CategoryId = t2.CategoryiD   where t1.description like '%" & searchTerm & "%'", dbConnection)
        End If

        Dim adapter As New SqlDataAdapter(command, dbConnection)

        'Fill the colum with the data from the database
        Dim table As New DataTable()
        adapter.Fill(table)
        dgvDashboard.DataSource = table

        dbConnection.Close()
    End Sub

    'Basic search
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        'Already on this page
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        frmItems.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        frmCategories.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        frmLocations.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        Me.Hide()
        frmExport.Show()
    End Sub
End Class
