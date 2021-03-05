<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLocations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblLocations = New System.Windows.Forms.Label()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.dvgLocations = New System.Windows.Forms.DataGridView()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dvgLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLocations
        '
        Me.lblLocations.AutoSize = True
        Me.lblLocations.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblLocations.Location = New System.Drawing.Point(12, 9)
        Me.lblLocations.Name = "lblLocations"
        Me.lblLocations.Size = New System.Drawing.Size(162, 46)
        Me.lblLocations.TabIndex = 0
        Me.lblLocations.Text = "Locations"
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(9, 85)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(94, 29)
        Me.btnNavDashboard.TabIndex = 6
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(9, 175)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(94, 29)
        Me.btnNavCategories.TabIndex = 8
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(9, 265)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(94, 29)
        Me.btnNavExport.TabIndex = 10
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'dvgLocations
        '
        Me.dvgLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgLocations.Location = New System.Drawing.Point(112, 85)
        Me.dvgLocations.Name = "dvgLocations"
        Me.dvgLocations.RowHeadersWidth = 51
        Me.dvgLocations.RowTemplate.Height = 29
        Me.dvgLocations.Size = New System.Drawing.Size(676, 353)
        Me.dvgLocations.TabIndex = 0
        Me.dvgLocations.TabStop = False
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(9, 130)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(94, 29)
        Me.btnNavItems.TabIndex = 7
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(9, 220)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(94, 29)
        Me.btnNavLocations.TabIndex = 9
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(112, 56)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(277, 27)
        Me.txtSearch.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(394, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 29)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(666, 55)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 29)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.dvgLocations)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.lblLocations)
        Me.Name = "frmLocations"
        Me.Text = "Locations"
        CType(Me.dvgLocations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLocations As Label
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents btnNavCategories As Button
    Friend WithEvents btnNavExport As Button
    Friend WithEvents dvgLocations As DataGridView
    Friend WithEvents btnNavItems As Button
    Friend WithEvents btnNavLocations As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
End Class
