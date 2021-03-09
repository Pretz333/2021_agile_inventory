Imports System.Data.SqlClient

Public Class frmItems
    Dim ds As New DataSet
    Dim ct As New DataTable
    Dim dataAdapter As SqlDataAdapter
    Dim catAdapter As SqlDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTableData(String.Empty)
        PopulateDropdown()
        dgvItems.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

    Private Sub PopulateDropdown()
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Dim selectCat As String = "Select * from Category"
        catAdapter = New SqlDataAdapter(selectCat, dbConnection)
        catAdapter.Fill(ct)
        Categories.DisplayMember = "Description"
        Categories.ValueMember = "Description"
        Categories.DataSource = ct
        dbConnection.Close()
    End Sub

    Public Sub LoadTableData(ByVal searchTerm As String)
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Dim selectStatement As String = "SELECT ItemId, Item.Description, Category.Description FROM Item INNER JOIN Category on item.CategoryId = Category.CategoryId"
        If searchTerm IsNot String.Empty Then
            selectStatement.Append(" WHERE item.Description LIKE '%" + searchTerm + "%'")
        End If
        dataAdapter = New SqlDataAdapter(selectStatement, dbConnection)

        dataAdapter.Fill(ds)
        dgvItems.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    'Events for the change in dropdownlist
    Private Sub dgvItems_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvItems.EditingControlShowing
        ' Only do this for the dropdown, not the input fields
        If e.Control.GetType().ToString() = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
            Dim editingComboBox As ComboBox = e.Control
            AddHandler editingComboBox.SelectedIndexChanged, AddressOf editingComboBox_SelectedIndexChanged
        End If
    End Sub

    'Get the CategoryID of the selected item from dropdown list
    Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim editingComboBox As ComboBox = TryCast(sender, ComboBox)
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Dim selectStatement As String = "SELECT CategoryID from Category WHERE Description = '" + editingComboBox.Text + "'"
        Dim cmd As SqlCommand = New SqlCommand(selectStatement, dbConnection)
        Dim id As Integer = cmd.ExecuteScalar()
        MsgBox(id.ToString())
        dbConnection.Close()
    End Sub

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

End Class