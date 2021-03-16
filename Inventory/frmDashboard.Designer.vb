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
        Me.dgvDashboard.Location = New System.Drawing.Point(98, 64)
        Me.dgvDashboard.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvDashboard.Name = "dgvDashboard"
        Me.dgvDashboard.RowHeadersWidth = 51
        Me.dgvDashboard.RowTemplate.Height = 29
        Me.dgvDashboard.Size = New System.Drawing.Size(592, 265)
        Me.dgvDashboard.TabIndex = 0
        Me.dgvDashboard.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(98, 42)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(185, 23)
        Me.txtSearch.TabIndex = 1
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(8, 131)
        Me.btnNavCategories.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(82, 22)
        Me.btnNavCategories.TabIndex = 7
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(8, 165)
        Me.btnNavLocations.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(82, 22)
        Me.btnNavLocations.TabIndex = 8
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(8, 199)
        Me.btnNavExport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(82, 22)
        Me.btnNavExport.TabIndex = 9
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(8, 98)
        Me.btnNavItems.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(82, 22)
        Me.btnNavItems.TabIndex = 6
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(8, 64)
        Me.btnNavDashboard.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(82, 22)
        Me.btnNavDashboard.TabIndex = 5
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'lblDashboard
        '
        Me.lblDashboard.AutoSize = True
        Me.lblDashboard.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDashboard.Location = New System.Drawing.Point(3, 2)
        Me.lblDashboard.Name = "lblDashboard"
        Me.lblDashboard.Size = New System.Drawing.Size(147, 37)
        Me.lblDashboard.TabIndex = 0
        Me.lblDashboard.Text = "Dashboard"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(287, 41)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(82, 22)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(583, 41)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Update Counts"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnResetCounts
        '
        Me.btnResetCounts.Location = New System.Drawing.Point(482, 41)
        Me.btnResetCounts.Margin = New System.Windows.Forms.Padding(2)
        Me.btnResetCounts.Name = "btnResetCounts"
        Me.btnResetCounts.Size = New System.Drawing.Size(96, 22)
        Me.btnResetCounts.TabIndex = 3
        Me.btnResetCounts.Text = "Reset Counts"
        Me.btnResetCounts.UseVisualStyleBackColor = True
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 338)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
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
