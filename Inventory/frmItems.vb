Imports System.Data.SQLite

Public Class frmItems
    Dim ds As New DataSet
    Dim dataAdapter As SQLiteDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)
        dgvItems.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvItems.Columns.Item(1).HeaderText = "Category"
        dgvItems.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvItems.Columns.Item(2).HeaderText = "Description"
        ' Disable the itemId column to prevent errors when saving
        dgvItems.Columns.Item(0).ReadOnly = True
    End Sub

    'Set up connection to database
    Private Function ConnectToDb() As SQLiteConnection
        'This gives the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length

        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 25)

        Dim strconnection As String = "Data Source= " + strPath + "Inventory.db"
        Dim dbConnection As New SQLiteConnection(strconnection)

        Return dbConnection
    End Function

    Public Sub LoadTableData(ByVal searchTerm As String)
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        ds.Tables.Clear()
        dbConnection.Open()
        Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT Item.ItemID, Category.Description, Item.Description FROM [Item] INNER JOIN [Category] ON Item.[CategoryID] = Category.[CategoryID]", dbConnection)
        If searchTerm IsNot String.Empty Then
            cmd.CommandText += " WHERE Item.Description LIKE @search OR Category.Description LIKE @search"
            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%")
        End If
        dataAdapter = New SQLiteDataAdapter(cmd)
        dataAdapter.Fill(ds)
        dgvItems.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    Private Function GetCategoryComboBoxColumn() As DataGridViewComboBoxColumn
        Dim dataTable As New DataTable
        Dim cboColumnCategory As New DataGridViewComboBoxColumn
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        Using dbConnection
            Dim categorySelectStatement As String = "SELECT Description FROM Category"
            dataAdapter = New SQLiteDataAdapter(categorySelectStatement, dbConnection)
            dataAdapter.Fill(dataTable)

            For Each dataRow As DataRow In dataTable.Rows
                cboColumnCategory.Items.Add(dataRow("Description"))
            Next

            cboColumnCategory.HeaderText = "Category"
            cboColumnCategory.Name = "Category"

            Return cboColumnCategory
        End Using
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dbConnection As SQLiteConnection = ConnectToDb()

        Dim CategoryID As String
        Try
            dbConnection.Open()
            For i As Integer = 0 To dgvItems.Rows.Count - 1
                Dim cmd As New SQLiteCommand("SELECT CategoryID FROM Category WHERE Description LIKE @search", dbConnection)
                cmd.Parameters.Add("@search", DbType.String)
                cmd.Parameters(0).Value = "%" + dgvItems.Rows.Item(i).Cells(1).Value.ToString() + "%"
                CategoryID = cmd.ExecuteScalar()
                If CategoryID Is Nothing Then
                    MessageBox.Show("The category you entered on row #" + (i + 1).ToString() + " can't be found", "Oops")
                Else
                    cmd.CommandText = "UPDATE Item SET CategoryID = " + CategoryID + ", Description = @search WHERE ItemID = " + dgvItems.Rows(i).Cells(0).Value.ToString()
                    cmd.Parameters(0).Value = dgvItems.Rows.Item(i).Cells(2).Value.ToString()
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        dbConnection.Close()
    End Sub

    Private Sub dgvItems_Click(sender As Object, e As EventArgs) Handles dgvItems.Click
        dgvItems.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        frmDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        'Already on this page
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        frmCategories.Show()
        Me.Close()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        frmLocations.Show()
        Me.Close()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        frmExport.Show()
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        Dim itemDescription As String = InputBox("Please type in the description of the item:", "Add new Item")
        Try
            dbConnection.Open()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT CategoryID FROM Category WHERE Description LIKE @search", dbConnection)
            cmd.Parameters.Add("@search", DbType.String)
            cmd.Parameters(0).Value = "%" + InputBox("Please search for a category to add the item to:", "Add new Item") + "%"
            Dim CategoryID As String = cmd.ExecuteScalar()
            If CategoryID Is Nothing Then
                MessageBox.Show("The category you entered can't be found.", "Oops")
            Else
                cmd.CommandText = "INSERT INTO Item (CategoryID, Description) VALUES (" + CategoryID + ", @search)"
                cmd.Parameters(0).Value = itemDescription
                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Successfully added!", "Changes Saved")

                    'Get the ItemID
                    cmd.CommandText = "SELECT ItemID FROM Item WHERE Description = @search"
                    Dim ItemID As String = cmd.ExecuteScalar()

                    'Query CategoryLocation for all locations that use the CategoryID of the item
                    cmd.CommandText = "SELECT LocationID FROM CategoryLocation WHERE CategoryID = " + CategoryID
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                    Dim locations As List(Of String) = New List(Of String)
                    While reader.Read()
                        locations.Add(reader.Item(0).ToString())
                    End While
                    reader.Close()

                    'Insert into InventoryMain LocationID, ItemID
                    For i As Integer = 0 To (locations.Count - 1)
                        cmd.CommandText = "INSERT INTO InventoryMain (LocationID, ItemID, ExpectedCount, ActualCount) VALUES (" + locations.Item(i) + ", " + ItemID + ", 0, 0)"
                        cmd.ExecuteNonQuery()
                    Next
                    frmDashboard.LoadTableData(String.Empty)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        dbConnection.Close()
        LoadTableData(String.Empty)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        Dim ItemID As String = InputBox("Please type in the ItemID of the item:", "Delete a Item")
        Try
            dbConnection.Open()
            Dim cmd As SQLiteCommand = New SQLiteCommand("DELETE FROM Item WHERE ItemID = @id", dbConnection)
            cmd.Parameters.Add("@id", DbType.String)
            cmd.Parameters(0).Value = ItemID
            If cmd.ExecuteNonQuery > 0 Then
                MessageBox.Show("Successfully deleted", "Changss Saved")
                cmd.CommandText = "DELETE FROM InventoryMain WHERE ItemID = @id"
                frmDashboard.LoadTableData(String.Empty)
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        dbConnection.Close()
        LoadTableData(String.Empty)
    End Sub
End Class