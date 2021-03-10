Imports System.Data.SqlClient

Public Class frmDashboard
    Dim dataAdapter As New SqlDataAdapter
    Dim ds As New DataSet

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)

        'Location Column
        dgvDashboard.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDashboard.Columns.Item(0).HeaderText = "Location"
        'Item Column
        dgvDashboard.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDashboard.Columns.Item(1).HeaderText = "Item"
        'Expected Count Column
        dgvDashboard.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDashboard.Columns.Item(2).HeaderText = "Expected Count"
        'Actual Count Column
        dgvDashboard.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvDashboard.Columns.Item(3).HeaderText = "Actual Count"
    End Sub

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
        Dim selectStatement As String = "SELECT Location.Description, Item.Description, ExpectedCount, ActualCount FROM InventoryMain INNER JOIN Item on InventoryMain.ItemID = Item.ItemID INNER JOIN Location on InventoryMain.LocationID = Location.LocationID"
        ds.Tables.Clear()
        dbConnection.Open()
        If searchTerm IsNot String.Empty Then
            selectStatement += " WHERE Description LIKE '%" + searchTerm + "%'"
        End If
        dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)
        dataAdapter.Fill(ds)
        dgvDashboard.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    'Basic search
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

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
