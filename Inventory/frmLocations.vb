Imports System.Data.SQLite

Public Class frmLocations
    Dim ds As New DataSet
    Dim dataAdapter As SQLiteDataAdapter

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        LoadTableData(String.Empty)
        dvgLocations.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dvgLocations.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' Disable the locationID column to prevent errors when saving
        dvgLocations.Columns.Item(0).ReadOnly = True
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
        Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT * FROM Location", dbConnection)
        If searchTerm IsNot String.Empty Then
            cmd.CommandText += " WHERE Description LIKE @search"
            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%")
        End If
        dataAdapter = New SQLiteDataAdapter(cmd)
        dataAdapter.Fill(ds)
        dvgLocations.DataSource = ds.Tables(0)
        dbConnection.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
        txtSearch.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim cmd As SQLiteCommandBuilder = New SQLiteCommandBuilder(dataAdapter)
            Dim changes As DataSet = ds.GetChanges()
            If changes IsNot Nothing Then
                dataAdapter.Update(changes)
                MessageBox.Show("Your changes were saved", "Changes Saved")
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        LoadTableData(String.Empty)
        frmDashboard.LoadTableData(String.Empty)
    End Sub

    Private Sub dvgLocations_Click(sender As Object, e As EventArgs) Handles dvgLocations.Click
        dvgLocations.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        frmDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        frmItems.Show()
        Me.Close()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        frmCategories.Show()
        Me.Close()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        'Already on this page
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        frmExport.Show()
        Me.Close()
    End Sub

    Private Sub btnAssociate_Click(sender As Object, e As EventArgs) Handles btnAssociate.Click
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        dbConnection.Open()
        Try
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT CategoryID FROM Category WHERE Description LIKE @search", dbConnection)
            cmd.Parameters.Add("@search", DbType.String)
            cmd.Parameters(0).Value = "%" + InputBox("Search for a Category to add to a Location", "Add Category to a Location") + "%"
            Dim CategoryID As String = cmd.ExecuteScalar()
            cmd.CommandText = "SELECT LocationID FROM Location WHERE Description LIKE @search"
            cmd.Parameters(0).Value = "%" + InputBox("Search for a Location to add the Category to", "Add Category to a Location") + "%"
            Dim LocationID As String = cmd.ExecuteScalar()
            If CategoryID Is Nothing Then
                MessageBox.Show("The category you entered does not exist!", "Oops")
            ElseIf LocationID Is Nothing Then
                MessageBox.Show("The location you entered does not exist!", "Oops")
            Else
                cmd.CommandText = "INSERT INTO CategoryLocation (LocationID, CategoryID) VALUES (" + LocationID + ", " + CategoryID + ")"
                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Your changes were saved", "Changes Saved")
                    cmd.CommandText = "SELECT ItemID FROM Item WHERE CategoryID = " + CategoryID
                    Dim items As List(Of String) = New List(Of String)
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        items.Add(reader.Item(0).ToString())
                    End While
                    reader.Close()
                    For i As Integer = 0 To (items.Count - 1)
                        cmd.CommandText = "INSERT INTO InventoryMain (LocationID, ItemID, ExpectedCount, ActualCount) VALUES (" + LocationID + ", " + items.Item(i).ToString() + ", 0, 0)"
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        frmDashboard.LoadTableData(String.Empty)
        dbConnection.Close()
    End Sub

    Private Sub btnDisassociate_Click(sender As Object, e As EventArgs) Handles btnDisassociate.Click
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        dbConnection.Open()
        Try
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT CategoryID FROM Category WHERE Description LIKE @search", dbConnection)
            cmd.Parameters.Add("@search", DbType.String)
            cmd.Parameters(0).Value = "%" + InputBox("Search for a Category to remove from a Location", "Remove Category from a Location") + "%"
            Dim CategoryID As String = cmd.ExecuteScalar()
            cmd.CommandText = "SELECT LocationID FROM Location WHERE Description LIKE @search"
            cmd.Parameters(0).Value = "%" + InputBox("Search for a Location to remove the Category from", "Remove Category from a Location") + "%"
            Dim LocationID As String = cmd.ExecuteScalar()
            If CategoryID Is Nothing Then
                MessageBox.Show("The category you entered does not exist!", "Oops")
            ElseIf LocationID Is Nothing Then
                MessageBox.Show("The location you entered does not exist!", "Oops")
            Else
                cmd.CommandText = "DELETE FROM CategoryLocation WHERE LocationID = " + LocationID + " AND CategoryID = " + CategoryID
                If cmd.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Your changes were saved", "Changes Saved")
                    cmd.CommandText = "SELECT ItemID FROM Item WHERE CategoryID = " + CategoryID
                    Dim items As List(Of String) = New List(Of String)
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        items.Add(reader.Item(0).ToString())
                    End While
                    reader.Close()
                    For i As Integer = 0 To (items.Count - 1)
                        cmd.CommandText = "DELETE FROM InventoryMain WHERE LocationID = " + LocationID + " AND ItemID = " + items.Item(i)
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Something bad happened while working with the database. Here's the details: " + ex.Message, "Database Error")
        End Try
        frmDashboard.LoadTableData(String.Empty)
        dbConnection.Close()
    End Sub
End Class