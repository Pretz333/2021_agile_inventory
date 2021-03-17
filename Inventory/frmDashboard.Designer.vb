<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Me.dgvDashboard = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.lblDashboard = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnResetCounts = New System.Windows.Forms.Button()
        CType(Me.dgvDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDashboard
        '
        Me.dgvDashboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDashboard.Location = New System.Drawing.Point(112, 85)
        Me.dgvDashboard.Name = "dgvDashboard"
        Me.dgvDashboard.RowHeadersWidth = 51
        Me.dgvDashboard.RowTemplate.Height = 29
        Me.dgvDashboard.Size = New System.Drawing.Size(677, 353)
        Me.dgvDashboard.TabIndex = 0
        Me.dgvDashboard.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(112, 56)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(211, 27)
        Me.txtSearch.TabIndex = 1
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(9, 175)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(94, 29)
        Me.btnNavCategories.TabIndex = 7
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(9, 220)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(94, 29)
        Me.btnNavLocations.TabIndex = 8
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(9, 265)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(94, 29)
        Me.btnNavExport.TabIndex = 9
        Me.btnNavExport.Text = "Data"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(9, 131)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(94, 29)
        Me.btnNavItems.TabIndex = 6
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(9, 85)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(94, 29)
        Me.btnNavDashboard.TabIndex = 5
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'lblDashboard
        '
        Me.lblDashboard.AutoSize = True
        Me.lblDashboard.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDashboard.Location = New System.Drawing.Point(3, 3)
        Me.lblDashboard.Name = "lblDashboard"
        Me.lblDashboard.Size = New System.Drawing.Size(183, 46)
        Me.lblDashboard.TabIndex = 0
        Me.lblDashboard.Text = "Dashboard"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(328, 55)
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
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Update Counts"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnResetCounts
        '
        Me.btnResetCounts.Location = New System.Drawing.Point(551, 55)
        Me.btnResetCounts.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnResetCounts.Name = "btnResetCounts"
        Me.btnResetCounts.Size = New System.Drawing.Size(110, 29)
        Me.btnResetCounts.TabIndex = 3
        Me.btnResetCounts.Text = "Reset Counts"
        Me.btnResetCounts.UseVisualStyleBackColor = True
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 451)
        Me.Controls.Add(Me.btnResetCounts)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblDashboard)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvDashboard)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmDashboard"
        Me.Text = "Dashboard"
        CType(Me.dgvDashboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDashboard As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnNavCategories As Button
    Friend WithEvents btnNavLocations As Button
    Friend WithEvents btnNavExport As Button
    Friend WithEvents btnNavItems As Button
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents lblDashboard As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnResetCounts As Button
End Class
