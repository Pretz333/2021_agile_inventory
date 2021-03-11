<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblExport = New System.Windows.Forms.Label()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.lblExportInfo = New System.Windows.Forms.Label()
        Me.lblExport_selectLocation = New System.Windows.Forms.Label()
        Me.btnExport_selectLocation = New System.Windows.Forms.Button()
        Me.gbExport = New System.Windows.Forms.GroupBox()
        Me.btnExport_export = New System.Windows.Forms.Button()
        Me.lblExport_export = New System.Windows.Forms.Label()
        Me.cbExport_exportType = New System.Windows.Forms.ComboBox()
        Me.lblExport_exportType = New System.Windows.Forms.Label()
        Me.lblExport_showLocation = New System.Windows.Forms.Label()
        Me.export_FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbImport = New System.Windows.Forms.GroupBox()
        Me.lblImport_import = New System.Windows.Forms.Label()
        Me.btnImport_import = New System.Windows.Forms.Button()
        Me.lblImport_showLocation = New System.Windows.Forms.Label()
        Me.btnImport_selectLocation = New System.Windows.Forms.Button()
        Me.lblImport_selectedLocation = New System.Windows.Forms.Label()
        Me.lblImportInfo = New System.Windows.Forms.Label()
        Me.import_FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbExport.SuspendLayout()
        Me.gbImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblExport
        '
        Me.lblExport.AutoSize = True
        Me.lblExport.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblExport.Location = New System.Drawing.Point(12, 9)
        Me.lblExport.Name = "lblExport"
        Me.lblExport.Size = New System.Drawing.Size(117, 46)
        Me.lblExport.TabIndex = 0
        Me.lblExport.Text = "Export"
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(9, 85)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(94, 29)
        Me.btnNavDashboard.TabIndex = 2
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(9, 175)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(94, 29)
        Me.btnNavCategories.TabIndex = 4
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(9, 220)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(94, 29)
        Me.btnNavLocations.TabIndex = 5
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(9, 130)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(94, 29)
        Me.btnNavItems.TabIndex = 3
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(9, 265)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(94, 29)
        Me.btnNavExport.TabIndex = 6
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'lblExportInfo
        '
        Me.lblExportInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblExportInfo.Location = New System.Drawing.Point(6, 23)
        Me.lblExportInfo.Name = "lblExportInfo"
        Me.lblExportInfo.Size = New System.Drawing.Size(289, 102)
        Me.lblExportInfo.TabIndex = 7
        Me.lblExportInfo.Text = "Easily export your inventory into portable file formats. Note that Items, categor" &
    "ies, and locations will be stored in separate files."
        '
        'lblExport_selectLocation
        '
        Me.lblExport_selectLocation.AutoSize = True
        Me.lblExport_selectLocation.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblExport_selectLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblExport_selectLocation.Location = New System.Drawing.Point(6, 125)
        Me.lblExport_selectLocation.Name = "lblExport_selectLocation"
        Me.lblExport_selectLocation.Size = New System.Drawing.Size(265, 28)
        Me.lblExport_selectLocation.TabIndex = 8
        Me.lblExport_selectLocation.Text = "Select a location to export to"
        '
        'btnExport_selectLocation
        '
        Me.btnExport_selectLocation.Location = New System.Drawing.Point(12, 156)
        Me.btnExport_selectLocation.Name = "btnExport_selectLocation"
        Me.btnExport_selectLocation.Size = New System.Drawing.Size(94, 29)
        Me.btnExport_selectLocation.TabIndex = 9
        Me.btnExport_selectLocation.Text = "Choose"
        Me.btnExport_selectLocation.UseVisualStyleBackColor = True
        '
        'gbExport
        '
        Me.gbExport.Controls.Add(Me.btnExport_export)
        Me.gbExport.Controls.Add(Me.lblExport_export)
        Me.gbExport.Controls.Add(Me.cbExport_exportType)
        Me.gbExport.Controls.Add(Me.lblExport_exportType)
        Me.gbExport.Controls.Add(Me.lblExport_showLocation)
        Me.gbExport.Controls.Add(Me.lblExportInfo)
        Me.gbExport.Controls.Add(Me.lblExport_selectLocation)
        Me.gbExport.Controls.Add(Me.btnExport_selectLocation)
        Me.gbExport.Location = New System.Drawing.Point(135, 18)
        Me.gbExport.Name = "gbExport"
        Me.gbExport.Size = New System.Drawing.Size(301, 420)
        Me.gbExport.TabIndex = 10
        Me.gbExport.TabStop = False
        Me.gbExport.Text = "Export Inventory"
        '
        'btnExport_export
        '
        Me.btnExport_export.Location = New System.Drawing.Point(10, 304)
        Me.btnExport_export.Name = "btnExport_export"
        Me.btnExport_export.Size = New System.Drawing.Size(94, 29)
        Me.btnExport_export.TabIndex = 14
        Me.btnExport_export.Text = "Export"
        Me.btnExport_export.UseVisualStyleBackColor = True
        '
        'lblExport_export
        '
        Me.lblExport_export.AutoSize = True
        Me.lblExport_export.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblExport_export.Location = New System.Drawing.Point(6, 273)
        Me.lblExport_export.Name = "lblExport_export"
        Me.lblExport_export.Size = New System.Drawing.Size(69, 28)
        Me.lblExport_export.TabIndex = 13
        Me.lblExport_export.Text = "Export"
        '
        'cbExport_exportType
        '
        Me.cbExport_exportType.AllowDrop = True
        Me.cbExport_exportType.FormattingEnabled = True
        Me.cbExport_exportType.Items.AddRange(New Object() {"*.csv (Comma Separated Values)"})
        Me.cbExport_exportType.Location = New System.Drawing.Point(10, 234)
        Me.cbExport_exportType.Name = "cbExport_exportType"
        Me.cbExport_exportType.Size = New System.Drawing.Size(151, 28)
        Me.cbExport_exportType.TabIndex = 12
        '
        'lblExport_exportType
        '
        Me.lblExport_exportType.AutoSize = True
        Me.lblExport_exportType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblExport_exportType.Location = New System.Drawing.Point(6, 203)
        Me.lblExport_exportType.Name = "lblExport_exportType"
        Me.lblExport_exportType.Size = New System.Drawing.Size(228, 28)
        Me.lblExport_exportType.TabIndex = 11
        Me.lblExport_exportType.Text = "Choose your export type"
        '
        'lblExport_showLocation
        '
        Me.lblExport_showLocation.Location = New System.Drawing.Point(112, 159)
        Me.lblExport_showLocation.Name = "lblExport_showLocation"
        Me.lblExport_showLocation.Size = New System.Drawing.Size(181, 24)
        Me.lblExport_showLocation.TabIndex = 10
        Me.lblExport_showLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbImport
        '
        Me.gbImport.Controls.Add(Me.lblImport_import)
        Me.gbImport.Controls.Add(Me.btnImport_import)
        Me.gbImport.Controls.Add(Me.lblImport_showLocation)
        Me.gbImport.Controls.Add(Me.btnImport_selectLocation)
        Me.gbImport.Controls.Add(Me.lblImport_selectedLocation)
        Me.gbImport.Controls.Add(Me.lblImportInfo)
        Me.gbImport.Location = New System.Drawing.Point(474, 18)
        Me.gbImport.Name = "gbImport"
        Me.gbImport.Size = New System.Drawing.Size(314, 420)
        Me.gbImport.TabIndex = 11
        Me.gbImport.TabStop = False
        Me.gbImport.Text = "Import Inventory"
        '
        'lblImport_import
        '
        Me.lblImport_import.AutoSize = True
        Me.lblImport_import.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblImport_import.Location = New System.Drawing.Point(7, 202)
        Me.lblImport_import.Name = "lblImport_import"
        Me.lblImport_import.Size = New System.Drawing.Size(72, 28)
        Me.lblImport_import.TabIndex = 13
        Me.lblImport_import.Text = "Import"
        '
        'btnImport_import
        '
        Me.btnImport_import.Location = New System.Drawing.Point(7, 233)
        Me.btnImport_import.Name = "btnImport_import"
        Me.btnImport_import.Size = New System.Drawing.Size(94, 29)
        Me.btnImport_import.TabIndex = 12
        Me.btnImport_import.Text = "Import"
        Me.btnImport_import.UseVisualStyleBackColor = True
        '
        'lblImport_showLocation
        '
        Me.lblImport_showLocation.Location = New System.Drawing.Point(107, 158)
        Me.lblImport_showLocation.Name = "lblImport_showLocation"
        Me.lblImport_showLocation.Size = New System.Drawing.Size(201, 24)
        Me.lblImport_showLocation.TabIndex = 11
        Me.lblImport_showLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImport_selectLocation
        '
        Me.btnImport_selectLocation.Location = New System.Drawing.Point(7, 157)
        Me.btnImport_selectLocation.Name = "btnImport_selectLocation"
        Me.btnImport_selectLocation.Size = New System.Drawing.Size(94, 29)
        Me.btnImport_selectLocation.TabIndex = 2
        Me.btnImport_selectLocation.Text = "Choose"
        Me.btnImport_selectLocation.UseVisualStyleBackColor = True
        '
        'lblImport_selectedLocation
        '
        Me.lblImport_selectedLocation.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblImport_selectedLocation.Location = New System.Drawing.Point(6, 125)
        Me.lblImport_selectedLocation.Name = "lblImport_selectedLocation"
        Me.lblImport_selectedLocation.Size = New System.Drawing.Size(301, 29)
        Me.lblImport_selectedLocation.TabIndex = 1
        Me.lblImport_selectedLocation.Text = "Select a location to import from"
        '
        'lblImportInfo
        '
        Me.lblImportInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblImportInfo.Location = New System.Drawing.Point(7, 27)
        Me.lblImportInfo.Name = "lblImportInfo"
        Me.lblImportInfo.Size = New System.Drawing.Size(301, 69)
        Me.lblImportInfo.TabIndex = 0
        Me.lblImportInfo.Text = "Import an entire inventory from exported *.csv files. Note, this will rewrite you" &
    "r entire inventory."
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gbImport)
        Me.Controls.Add(Me.gbExport)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.lblExport)
        Me.Name = "frmExport"
        Me.Text = "Export"
        Me.gbExport.ResumeLayout(False)
        Me.gbExport.PerformLayout()
        Me.gbImport.ResumeLayout(False)
        Me.gbImport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblExport As Label
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents btnNavCategories As Button
    Friend WithEvents btnNavLocations As Button
    Friend WithEvents btnNavItems As Button
    Friend WithEvents btnNavExport As Button
    Friend WithEvents lblExportInfo As Label
    Friend WithEvents lblExport_selectLocation As Label
    Friend WithEvents btnExport_selectLocation As Button
    Friend WithEvents gbExport As GroupBox
    Friend WithEvents lblExport_showLocation As Label
    Friend WithEvents export_FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents lblExport_exportType As Label
    Friend WithEvents cbExport_exportType As ComboBox
    Friend WithEvents btnExport_export As Button
    Friend WithEvents lblExport_export As Label
    Friend WithEvents gbImport As GroupBox
    Friend WithEvents lblImport_import As Label
    Friend WithEvents btnImport_import As Button
    Friend WithEvents lblImport_showLocation As Label
    Friend WithEvents btnImport_selectLocation As Button
    Friend WithEvents lblImport_selectedLocation As Label
    Friend WithEvents lblImportInfo As Label
    Friend WithEvents import_FolderBrowserDialog As FolderBrowserDialog
End Class
