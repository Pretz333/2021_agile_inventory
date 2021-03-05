<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocations
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
        Me.lblLocations = New System.Windows.Forms.Label()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.dvgLocations = New System.Windows.Forms.DataGridView()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
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
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(9, 265)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(94, 29)
        Me.btnNavExport.TabIndex = 6
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
        Me.btnNavItems.TabIndex = 3
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
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
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(112, 58)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(56, 20)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(172, 55)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(211, 27)
        Me.txtSearch.TabIndex = 1
        '
        'frmLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
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
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
End Class
