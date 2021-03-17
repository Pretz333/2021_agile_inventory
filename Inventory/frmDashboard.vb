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
        dgvDashboard.Columns.Item(0).ReadOnly = True
        'Item Column
        dgvDashboard.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvDashboard.Columns.Item(1).HeaderText = "Item"
        dgvDashboard.Columns.Item(1).ReadOnly = True
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
        Dim cmd As SqlCommand = New SqlCommand("SELECT Location.Description, Item.Description, ExpectedCount, ActualCount FROM InventoryMain INNER JOIN Item on InventoryMain.ItemID = Item.ItemID INNER JOIN Location on InventoryMain.LocationID = Location.LocationID", dbConnection)
        ds.Tables.Clear()
        dbConnection.Open()
        If searchTerm IsNot String.Empty Then
            cmd.CommandText += " WHERE Item.Description LIKE @search OR Location.Description LIKE @search"
            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%")
        End If
        dataAdapter = New SqlDataAdapter(cmd)
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
                LocationID = cmd.ExecuteScalar()
                cmd.CommandText = "SELECT ItemID FROM Item WHERE Description = '" + dgvDashboard.Rows.Item(i).Cells(1).Value.ToString() + "'"
                ItemID = cmd.ExecuteScalar()

                ' Get the expected count and actual count cells from the table
                Dim sExpectedCount As Integer = dgvDashboard.Rows.Item(i).Cells(2).Value
                Dim sActualCount As Integer = dgvDashboard.Rows.Item(i).Cells(3).Value

                ' Check to make sure the numbers are positive, not negative.
                If sExpectedCount < 0 Or sActualCount < 0 Then
                    ' Throw an exception preventing the rest of the code from executing
                    Throw New Exception("number_positive_exception")
                End If

                cmd.CommandText = "UPDATE InventoryMain SET ExpectedCount = " + sExpectedCount.ToString + ", ActualCount = " + sActualCount.ToString + " WHERE LocationID = " + LocationID + " AND ItemID = " + ItemID
                If cmd.ExecuteNonQuery() = 0 Then
                    Throw New Exception("update_failed")
                End If

            Next
            MessageBox.Show("Successfully updated counts!", "Changes Saved") 'If it fails, it'll be caught by the try-catch
        Catch ex As Exception


            ' See which exception happened to give the user a more in-depth answer
            If ex.Message.ToString.Equals("number_positive_exception") Then
                MessageBox.Show("Your item counts can only be positive numbers. E.g. 24", "Oops")
            ElseIf ex.Message.ToString.Equals("update_failed") Then
                MessageBox.Show("None of the rows were updated", "Oops")
            Else
                MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
            End If

        End Try
        dbConnection.Close()
    End Sub

    ' This event handles errors regarding the Expected Count and Actual Count cells.
    ' If data entered contains a character that isn't an Integer, this method will run.
    Private Sub dgvDashboard_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDashboard.DataError
        ' If the user entered a String instead of an Integer, show them this error
        If e.Exception.GetType.ToString.Equals("System.FormatException") Then
            MessageBox.Show("Oops, only numbers are allowed in your Expected Count and Actual Count cells.", "Oops...")
        Else
            MessageBox.Show("Something bad happened. Here's the details: " + e.Exception.ToString, "Error")
        End If
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
                MessageBox.Show("All item counts were successfuly set to zero.", "Task Complete")
            Else
                MessageBox.Show("Sorry, it looks like the counts couldn't be reset!", "Task Failed")
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
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
