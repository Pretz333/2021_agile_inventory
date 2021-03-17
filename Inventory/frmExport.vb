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
        import_FolderBrowserDialog.ShowDialog()
        mImportPath = import_FolderBrowserDialog.SelectedPath

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
            MessageBox.Show("Importing of the Inventory is not implemented at this time.", "Sorry!")
            ' Show the user a warning
            'MessageBox.Show("Just a heads up, the entire inventory will be replaced with the new inventory you're about to import!", "Heads up")
            importInventory()
        End If
    End Sub

    ' Invalid path message box
    Private Sub invalidPathDialog(ByVal mPath As String)
        MessageBox.Show("The location " + mPath + "isn't valid. Try picking another location", "Oops.")
    End Sub

    Private Sub exportInventory()
        Dim dbConnection As SQLiteConnection = ConnectToDb()
        Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT Location.Description, Category.Description, Item.Description, ExpectedCount, ActualCount FROM InventoryMain INNER JOIN Location ON InventoryMain.LocationID = Location.LocationID INNER JOIN Item ON InventoryMain.ItemID = Item.ItemID INNER JOIN Category ON Item.CategoryID = Category.CategoryID ORDER BY Location.Description, Category.Description, Item.Description", dbConnection)
        dbConnection.Open()
        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

        ' Use a different writing method for CSV or PDF
        If cbExport_exportType.SelectedIndex = 0 Then 'CSV
            mExportPath += "\Inventory.csv"
            While reader.Read()

            End While
        ElseIf cbExport_exportType.SelectedIndex = 1 Then 'PDF
            mExportPath += "\Inventory.pdf"
            Dim pdf As PdfDocument = New PdfDocument(New PdfWriter(New FileStream(mExportPath, FileMode.Create, FileAccess.Write)))
            Dim doc As Document = New Document(pdf)
            Dim tbl As Table = New Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth()
            tbl.AddHeaderCell("Location")
            tbl.AddHeaderCell("Category")
            tbl.AddHeaderCell("Item")
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
        ' Verify the import CSV is setup as Location, Item, Category, Expected, Actual

        ' Delete and recreate all tables

        ' For each row in the CSV:
        ' Read the Location field, add it to Location if it doesn't exist
        ' Read the Category field, add it to Category if it doesn't exist
        ' Add the Item and Category to the Item table
        ' Add the Location-Category pair to CategoryLocation if it doesn't exist
        ' Add the Location-Item pair and the two counts to InventoryMain
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