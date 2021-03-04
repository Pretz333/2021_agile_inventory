Imports System.Data.SqlClient

Public Class frmCategories
    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategoryTableData()
    End Sub

    'Set up connection to database
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

    Public Sub LoadCategoryTableData()
        Dim dbConnection As SqlConnection = connectToDb()
        dbConnection.Open()
        Dim selectStatement As String = "SELECT * FROM Category"
        Dim cmdCategory As New SqlCommand(selectStatement, dbConnection)
        cmdCategory.CommandType = CommandType.Text
        Dim dataAdapter As New SqlDataAdapter(cmdCategory)
        Dim dataTable As New DataTable()
        dataAdapter.Fill(dataTable)
        dgvCategories.DataSource = dataTable
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        Me.Hide()
        frmDashboard.Show()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        Me.Hide()
        frmItems.Show()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        'Already on this page
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