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
            selectStatement += " WHERE Item.Description LIKE '%" + searchTerm + "%' OR Location.Description LIKE '%" + searchTerm + "%'"
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
        Dim dbConnection As SqlConnection = ConnectToDb()

        Dim cmd As New SqlCommand("", dbConnection)
        Dim LocationID As String
        Dim ItemID As String
        Try
            dbConnection.Open()
            For i As Integer = 0 To dgvDashboard.Rows.Count - 2 'The last row is blank
                cmd.CommandText = "SELECT LocationID FROM Location WHERE Description = '" + dgvDashboard.Rows.Item(i).Cells(0).Value.ToString() + "'"
                LocationID = cmd.ExecuteScalar().ToString()
                cmd.CommandText = "SELECT ItemID FROM Item WHERE Description = '" + dgvDashboard.Rows.Item(i).Cells(1).Value.ToString() + "'"
                ItemID = cmd.ExecuteScalar().ToString()
                cmd.CommandText = "UPDATE InventoryMain SET ExpectedCount = " + dgvDashboard.Rows.Item(i).Cells(2).Value.ToString() + ", ActualCount = " + dgvDashboard.Rows.Item(i).Cells(3).Value.ToString() + " WHERE LocationID = " + LocationID + " AND ItemID = " + ItemID
                If cmd.ExecuteNonQuery() = 0 Then
                    Throw New ArgumentException("Update Failed.")
                End If
            Next
            MsgBox("Success!") 'If it fails, it'll be caught by the try-catch
        Catch ex As Exception
            MsgBox("Something went wrong, please try again")
        End Try
        dbConnection.Close()
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        'Already on this page
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        frmItems.Show()
        Me.Hide()
        Me.CenterToScreen()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        frmCategories.Show()
        Me.Hide()
        Me.CenterToScreen()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        frmLocations.Show()
        Me.Hide()
        Me.CenterToScreen()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        Me.Hide()
        frmExport.Show()
        Me.CenterToScreen()
    End Sub

    Private Sub btnResetCounts_Click(sender As Object, e As EventArgs) Handles btnResetCounts.Click

        Dim dbConnection As SqlConnection = ConnectToDb()
        Dim selectStatement As String = "Update InventoryMain set ExpectedCount = @val, ActualCount = @val "

        ds.Tables.Clear()
        dbConnection.Open()
        Dim saveCommand As New SqlCommand(selectStatement, dbConnection)

        saveCommand.Parameters.AddWithValue("@val", 0)


        Try
            If saveCommand.ExecuteNonQuery > 0 Then
                MessageBox.Show("Actual Count reset to zero for all items.")
            Else
                MessageBox.Show("Items not reset.")
            End If
        Catch ex As Exception
            MessageBox.Show("Oops, there was a problem connecting to the database. " + ex.Message)
        End Try


        dbConnection.Close()
        Dim frmDashboard As New frmDashboard
        frmDashboard.Show()
        Me.Dispose(False)
    End Sub

    Private Sub dgvDashboard_Click(sender As Object, e As EventArgs) Handles dgvDashboard.Click
        dgvDashboard.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub
End Class
