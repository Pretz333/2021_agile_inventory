Imports System.Data.SQLite
Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iText.Layout.Properties

Public Class frmExport
    Dim mExportPath As String
    Dim mImportPath As String

    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()

        ' Set the export type combo box to the first element
        cbExport_exportType.SelectedIndex = 0

        ' Disable the import and export buttons
        btnExport_export.Enabled = False
        btnImport_import.Enabled = False
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

    ' Opens a dialog to select an IMPORT location and verifies if its all good.
    Private Sub btnImport_selectLocation_Click(sender As Object, e As EventArgs) Handles btnImport_selectLocation.Click
        ' Open a file browser dialog and set the path to a variable
        fdImport.ShowDialog()
        mImportPath = fdImport.FileName

        ' Check if the user gave an actual path
        If mImportPath.Length > 0 Then
            lblImport_showLocation.Text = mImportPath
            btnImport_import.Enabled = True
        Else
            invalidPathDialog(mImportPath)
        End If
    End Sub

    ' Opens a dialog to select an EXPORT location and verifies if its all good.
    Private Sub btnExport_selectLocation_Click(sender As Object, e As EventArgs) Handles btnExport_selectLocation.Click
        ' Open a file browser dialog and set the path to a variable
        export_FolderBrowserDialog.ShowDialog()
        mExportPath = export_FolderBrowserDialog.SelectedPath

        ' Check if the user gave an actual path
        If mExportPath.Length > 0 Then
            lblExport_showLocation.Text = mExportPath
            btnExport_export.Enabled = True
        Else
            invalidPathDialog(mExportPath)
        End If
    End Sub

    ' Check if the folder path and export type are valid.
    Private Sub btnExport_export_Click(sender As Object, e As EventArgs) Handles btnExport_export.Click
        ' Check if a path was given and if an export type was selected
        If (mExportPath.Length >= 1 And cbExport_exportType.SelectedIndex >= 0) Then
            exportInventory()
        End If
    End Sub

    ' Check if the folder path is valid.
    Private Sub btnImport_import_Click(sender As Object, e As EventArgs) Handles btnImport_import.Click
        ' Check if the import path is valid (janky, but it works)
        If mImportPath.Length >= 1 Then
            ' Show the user a warning
            MessageBox.Show("Just a heads up, the entire inventory will be replaced with the new inventory you're about to import!", "Heads up")
            importInventory()
        End If
    End Sub

    ' Invalid path message box
    Private Sub invalidPathDialog(ByVal mPath As String)
        MessageBox.Show("The location " + mPath + "isn't valid. Try picking another location", "Oops.")
    End Sub

    Private Sub exportInventory()
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT Location.Description, Item.Description, Category.Description, ExpectedCount, ActualCount FROM InventoryMain INNER JOIN Location ON InventoryMain.LocationID = Location.LocationID INNER JOIN Item ON InventoryMain.ItemID = Item.ItemID INNER JOIN Category ON Item.CategoryID = Category.CategoryID ORDER BY Location.Description, Category.Description, Item.Description", dbConnection)
        dbConnection.Open()
        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

        ' Use a different writing method for CSV or PDF
        If cbExport_exportType.SelectedIndex = 0 Then 'CSV
            mExportPath += "\Inventory.csv"


            ' Stream writer for CSV file.
            Dim csvFile As StreamWriter = Nothing


            Try


                ' Stream writer for CSV file.
                csvFile = New StreamWriter(mExportPath)

                ' Add the headers to the CSV file.
                csvFile.WriteLine(String.Format("""{0}"",""{1}""," _
                                       & """{2}"",""{3}""",
                                       reader.GetName(0),
                                       reader.GetName(1),
                                       reader.GetName(2),
                                       reader.GetName(3)))

                ' Construct CSV file data rows.
                While reader.Read()

                    ' Add line from reader object to new CSV file.
                    csvFile.WriteLine(String.Format("""{0}"",""{1}""," _
                                       & """{2}"",""{3}""",
                                       reader(0),
                                       reader(1),
                                       reader(2),
                                       reader(3)))

                End While


            Catch ex As Exception

                ' Message stating export unsuccessful.
                MsgBox("Data export unsuccessful." + ex.Message)
                End

            Finally

                ' Close the  CSV file.
                csvFile.Close()

            End Try

        ElseIf cbExport_exportType.SelectedIndex = 1 Then 'PDF
            mExportPath += "\Inventory.pdf"
            Dim pdf As PdfDocument = New PdfDocument(New PdfWriter(New FileStream(mExportPath, FileMode.Create, FileAccess.Write)))
            Dim doc As Document = New Document(pdf)
            Dim tbl As Table = New Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth()
            tbl.AddHeaderCell("Location")
            tbl.AddHeaderCell("Item")
            tbl.AddHeaderCell("Category")
            tbl.AddHeaderCell("Expected Count")
            tbl.AddHeaderCell("Actual Count")
            While reader.Read()
                tbl.AddCell(reader.Item(0).ToString())
                tbl.AddCell(reader.Item(1).ToString())
                tbl.AddCell(reader.Item(2).ToString())
                tbl.AddCell(reader.Item(3).ToString())
                tbl.AddCell(reader.Item(4).ToString())
            End While
            doc.Add(tbl)
            doc.Close()
        End If

        reader.Close()
        dbConnection.Close()
        MessageBox.Show("Successfully exported to " + mExportPath, "Success!")
    End Sub

    Private Sub importInventory()
        Try
            'Verify the path is a csv file
            If mImportPath.EndsWith(".csv") Then
                ' Get all info from the file
                Dim dt As DataTable = New DataTable()
                Dim csvReader As FileIO.TextFieldParser = New FileIO.TextFieldParser(mImportPath)
                csvReader.SetDelimiters(New String() {","})
                Dim colFields As String() = csvReader.ReadFields()
                For Each column As String In colFields
                    Dim col As DataColumn = New DataColumn(column)
                    dt.Columns.Add(col)
                Next
                While Not csvReader.EndOfData
                    Dim fieldData As String() = csvReader.ReadFields()
                    dt.Rows.Add(fieldData)
                End While
                csvReader.Close()

                ' Verify the import CSV is setup as Location, Category, Item, Expected, Actual
                If dt.Columns(0).ToString().ToLower() = "location" And dt.Columns(2).ToString().ToLower() = "item" And dt.Columns(1).ToString().ToLower() = "category" And dt.Columns(3).ToString().ToLower() = "expected count" And dt.Columns(4).ToString().ToLower() = "actual count" Then
                    'Further error checking
                    If dt.Rows.Count > 1 And Not dt.Rows.ToString = String.Empty Then
                        ' Delete all data in tables
                        Dim dbConnection As SQLiteConnection = ConnectToDb()
                        dbConnection.Open()
                        Dim cmd As SQLiteCommand = New SQLiteCommand("DELETE FROM InventoryMain", dbConnection)
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM CategoryLocation"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM Item"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM Category"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM Location"
                        cmd.ExecuteNonQuery()

                        ' Setup
                        Dim locInsert As SQLiteCommand = New SQLiteCommand("INSERT INTO Location (Description) VALUES (@val)", dbConnection)
                        locInsert.Parameters.Add("@val", DbType.String)
                        Dim catInsert As SQLiteCommand = New SQLiteCommand("INSERT INTO Category (Description) VALUES (@val)", dbConnection)
                        catInsert.Parameters.Add("@val", DbType.String)
                        Dim itemInsert As SQLiteCommand = New SQLiteCommand("INSERT INTO Item (Description, CategoryID) VALUES (@val, @catid)", dbConnection)
                        itemInsert.Parameters.Add("@val", DbType.String)
                        itemInsert.Parameters.Add("@catid", DbType.Int32)
                        Dim loccatInsert As SQLiteCommand = New SQLiteCommand("INSERT INTO CategoryLocation (CategoryID, LocationID) VALUES (@cat, @loc)", dbConnection)
                        loccatInsert.Parameters.Add("@cat", DbType.Int32)
                        loccatInsert.Parameters.Add("@loc", DbType.Int32)
                        Dim invInsert As SQLiteCommand = New SQLiteCommand("INSERT INTO InventoryMain (LocationID, ItemID, ExpectedCount, ActualCount) VALUES (@loc, @item, 0, 0)", dbConnection)
                        invInsert.Parameters.Add("@loc", DbType.Int32)
                        invInsert.Parameters.Add("@item", DbType.Int32)
                        Dim findItem As SQLiteCommand = New SQLiteCommand("SELECT ItemID FROM Item WHERE Item.Description = @val", dbConnection)
                        findItem.Parameters.Add("@val", DbType.String)
                        Dim findCat As SQLiteCommand = New SQLiteCommand("SELECT CategoryID FROM Category WHERE Category.Description = @val", dbConnection)
                        findCat.Parameters.Add("@val", DbType.String)
                        Dim findLoc As SQLiteCommand = New SQLiteCommand("SELECT LocationID FROM Location WHERE Location.Description = @val", dbConnection)
                        findLoc.Parameters.Add("@val", DbType.String)
                        Dim locList As List(Of String) = New List(Of String)
                        Dim catList As List(Of String) = New List(Of String)
                        Dim loccatList As List(Of Integer()) = New List(Of Integer())
                        Dim loccat(2) As Integer
                        Dim loc As String
                        Dim cat As String
                        Dim item As String
                        Dim catID As String

                        ' For each row in the CSV:
                        For i As Integer = 0 To dt.Rows.Count - 1
                            ' Read the Location field, add it to Location if it doesn't exist
                            loc = dt.Rows(i).Item(0).ToString()
                            If locList.IndexOf(loc) = -1 Then
                                locList.Add(loc)
                                locInsert.Parameters(0).Value = loc
                                locInsert.ExecuteNonQuery()
                            End If

                            ' Read the Category field, add it to Category if it doesn't exist
                            cat = dt.Rows(i).Item(1).ToString()
                            If catList.IndexOf(cat) = -1 Then
                                catList.Add(cat)
                                catInsert.Parameters(0).Value = cat
                                catInsert.ExecuteNonQuery()
                            End If

                            ' Add the Item and Category to the Item table
                            findCat.Parameters(0).Value = cat
                            item = dt.Rows(i).Item(2).ToString()
                            itemInsert.Parameters(0).Value = item
                            catID = findCat.ExecuteScalar()
                            itemInsert.Parameters(1).Value = catID
                            itemInsert.ExecuteNonQuery()

                            ' Add the Location-Category pair to CategoryLocation if it doesn't exist
                            findLoc.Parameters(0).Value = loc
                            loccat(1) = findLoc.ExecuteScalar()
                            loccat(0) = catID
                            If loccatList.IndexOf(loccat) = -1 Then
                                loccatList.Add(loccat)
                                loccatInsert.Parameters(0).Value = loccat(0)
                                loccatInsert.Parameters(1).Value = loccat(1)
                                loccatInsert.ExecuteNonQuery()
                            End If

                            ' Add the Location-Item pair and the two counts to InventoryMain
                            invInsert.Parameters(0).Value = loccat(1)
                            findItem.Parameters(0).Value = item
                            invInsert.Parameters(1).Value = findItem.ExecuteScalar().ToString()
                            invInsert.ExecuteNonQuery()
                        Next
                        dbConnection.Close()
                        MessageBox.Show("Improt successful!", "Import Success!")
                    Else
                        MessageBox.Show("There is no data in this file", "Import Error")
                    End If
                Else
                    MessageBox.Show("The columns should be in this order with these titles: Location, Item, Category, Expected, Actual", "Import Error")
                End If
            Else
                MessageBox.Show("The file you selected is not a CSV file, please select a CSV file.", "Import Error")
            End If
        Catch ex As Exception
            MessageBox.Show("The import failed, here's the details on why: " + ex.ToString(), "Import Error")
        End Try
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
        frmLocations.Show()
        Me.Close()
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        'Already on this page
    End Sub
End Class