Imports System.Data.SqlClient

Public Class frmItems
    Dim ds As New DataSet
    Dim ct As New DataTable
    Dim dataAdapter As SqlDataAdapter
    Dim catAdapter As SqlDataAdapter
    Dim varRowtext As String

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTableData(String.Empty)
        dgvItems.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
        Dim selectStatement As String = "SELECT ItemId, Category.Description, Item.Description FROM Item inner join Category on item.CategoryId = Category.categoryId"
        Dim selectCat As String = "Select * from Category"
        If searchTerm IsNot String.Empty Then
            Command.Append(" WHERE item.Description LIKE '%" + searchTerm + "%'")
        End If
        dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)
        catAdapter = New SqlDataAdapter(selectCat, dbConnection)

        'comboBox information
        Categories.DisplayMember = "Description"
        Categories.ValueMember = "Description"
        Categories.DataSource = catRetrieval()
        dataAdapter.Fill(ds)
        dgvItems.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    'retrieve the data fir the dropdownlist
    Private Function catRetrieval() As Object
        'This gives the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length

        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 25)

        Dim strconnection As String = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + strPath + "Inventory.mdf"
        Dim dbConnection As New SqlConnection(strconnection)
        catAdapter.Fill(ct)
        Return ct
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
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

    Private Sub dgvItems_Click(sender As Object, e As EventArgs) Handles dgvItems.Click
        dgvItems.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        Me.Hide()
        frmDashboard.Show()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        'Already on this page
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

    'Events for the change in dropdownlist
    Private Sub dgvItems_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvItems.EditingControlShowing
        Dim editingComboBox As ComboBox = e.Control
        AddHandler editingComboBox.SelectedIndexChanged, AddressOf editingComboBox_SelectedIndexChanged

    End Sub

    'Get the value from drop downlist
    Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        varRowtext = editingComboBox.Text
        MsgBox(varRowtext)
    End Sub

End Class