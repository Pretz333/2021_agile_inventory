Imports System.Data.SqlClient

Public Class frmDashboard

    'load table from database, in this case item table
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTable("")
    End Sub

    'set up connection function
    Private Function connectToDb() As SqlConnection
        'This gives the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length

        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 25)

        Dim strconnection As String = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + strPath + "Inventory.mdf"
        Dim dbConnection As New SqlConnection(strconnection)

        Return dbConnection
    End Function

    Public Sub LoadTable(ByVal tableR As String)
        Dim dbConnection As SqlConnection = connectToDb()
        dbConnection.Open()

        'select query to find the item that was looked for
        Dim adapter As New SqlDataAdapter("select t1.description as Item, t2.description as Cat from item as t1 left join category as t2 on t1.CategoryId = t2.CategoryiD   where t1.description like '%" & srchItem1.Text & "%'", dbConnection)

        'Fill the colum with the data from the database
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table

        dbConnection.Close()
    End Sub

    'basic search option
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles srchItem1.TextChanged
        LoadTable(srchItem1.Text)
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        'Already on this page
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        Me.Hide()
        frmItems.Show()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        Me.Hide()
        frmCategories.Show()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        Me.Hide()
        frmLocations.Show()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        Me.Hide()
        frmExport.Show()
    End Sub
End Class
