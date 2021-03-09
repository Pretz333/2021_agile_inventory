Imports System.Data.SqlClient

Public Class frmItems
    Dim ds As New DataSet
    Dim dataAdapter As SqlDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToParent()
        LoadTableData(String.Empty)
        'ItemID Column
        dgvItems.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns("ItemID").DisplayIndex = 0
        'Category Description Column
        Dim categoryColumn As DataGridViewComboBoxColumn = GetCategoryComboBoxColumn()
        dgvItems.Columns.Add(categoryColumn)
        dgvItems.Columns("Category").DisplayIndex = 1
        'Item Description Column
        dgvItems.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvItems.Columns("Description").DisplayIndex = 2
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
        Dim selectStatement As String = "SELECT Item.ItemID, Item.Description FROM [Item] INNER JOIN [Category] ON Item.[CategoryID] = Category.[CategoryID]"
        If searchTerm IsNot String.Empty Then
            Command.Append(" WHERE Item.Description LIKE '%" + searchTerm + "%'")
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
            cboColumnCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            cboColumnCategory.Name = "Category"

            Return cboColumnCategory
        End Using
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
End Class