Public Class frmExport

    ' Member variables for export and import sections
    Dim mExportPath As String
    Dim mExportType As Integer

    Dim mImportPath As String




    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()

        ' Set the export type combo box index to the first and only element
        cbExport_exportType.SelectedIndex = 0
        ' Disable the export combo box (for now.)
        cbExport_exportType.Enabled = False

        ' Disable the export button
        btnExport_export.Enabled = False
        ' Disable the import button
        btnImport_import.Enabled = False
    End Sub




    ' Opens a dialog to select an IMPORT location
    ' and verifies if its all good.
    Private Sub btnImport_selectLocation_Click(sender As Object, e As EventArgs) Handles btnImport_selectLocation.Click
        ' Open a file browser dialog
        import_FolderBrowserDialog.ShowDialog()

        ' Set the path variable to our local variable for simplicity
        mImportPath = import_FolderBrowserDialog.SelectedPath

        ' Check if the user gave an actual path
        If mImportPath.Length > 0 Then
            ' Set the label to the import path
            lblImport_showLocation.Text = mImportPath
            ' Enable the import button
            btnImport_import.Enabled = True
        Else
            invalidPathDialog(mImportPath)
        End If
    End Sub




    ' Opens a dialog to select an EXPORT location
    ' and verifies if its all good.
    Private Sub btnExport_selectLocation_Click(sender As Object, e As EventArgs) Handles btnExport_selectLocation.Click
        ' Open a file browser dialog
        export_FolderBrowserDialog.ShowDialog()

        ' Set the path variable to our local variable for simplicity
        mExportPath = export_FolderBrowserDialog.SelectedPath

        ' Check if the user gave an actual path
        If mExportPath.Length > 0 Then
            ' Set the label to the import path
            lblExport_showLocation.Text = mExportPath
            ' Enable the import button
            btnExport_export.Enabled = True
        Else
            invalidPathDialog(mExportPath)
        End If
    End Sub




    ' Export button. Check if the folder path and export type are valid, then
    ' show the user what they've selected as a heads up.
    Private Sub btnExport_export_Click(sender As Object, e As EventArgs) Handles btnExport_export.Click
        ' Check if a path was given and if an export type was selected
        If (mExportPath.Length >= 1 And cbExport_exportType.SelectedIndex >= 0) Then
            ' Show the user a heads up
            MessageBox.Show("Just a heads up, you will be exporting to " + mExportPath + " with the file type as " + cbExport_exportType.SelectedItem.ToString, "Heads up")
            exportInventory()
        End If
    End Sub




    ' Import button. Check if the folder path is valid.
    Private Sub btnImport_import_Click(sender As Object, e As EventArgs) Handles btnImport_import.Click
        ' Check if the import path is valid (janky, but it works)
        If mImportPath.Length >= 1 Then
            ' Show the user a heads up
            MessageBox.Show("Just a heads up, your entire inventory will be replaced with the new inventory you're about to import!", "Heads up")
            importInventory()
        End If
    End Sub


    ' Invalid path message box
    Private Sub invalidPathDialog(ByVal mPath As String)
        MessageBox.Show("The location " + mPath + "isn't valid. Try picking another location", "Oops.")
    End Sub

    ' Import subroutine
    Private Sub exportInventory()
        ' Do some crazy magic exporting crap
        ' ...
        ' ...
    End Sub

    ' Export subroutine
    Private Sub importInventory()
        ' Do some crazy magic importing crap
        ' ...
        ' ...
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