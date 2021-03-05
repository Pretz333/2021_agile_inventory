<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Me.dgvDashboard = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.lblDashboard = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.frmCreate = New System.Windows.Forms.Button()
        CType(Me.dgvDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDashboard
        '
        Me.dgvDashboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDashboard.Location = New System.Drawing.Point(182, 136)
        Me.dgvDashboard.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.dgvDashboard.Name = "dgvDashboard"
        Me.dgvDashboard.RowHeadersWidth = 51
        Me.dgvDashboard.RowTemplate.Height = 41
        Me.dgvDashboard.Size = New System.Drawing.Size(1098, 565)
        Me.dgvDashboard.TabIndex = 0
        Me.dgvDashboard.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(182, 90)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(340, 39)
        Me.txtSearch.TabIndex = 2
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(15, 280)
        Me.btnNavCategories.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(153, 46)
        Me.btnNavCategories.TabIndex = 5
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(15, 352)
        Me.btnNavLocations.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(153, 46)
        Me.btnNavLocations.TabIndex = 6
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(15, 424)
        Me.btnNavExport.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(153, 46)
        Me.btnNavExport.TabIndex = 7
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(15, 208)
        Me.btnNavItems.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(153, 46)
        Me.btnNavItems.TabIndex = 4
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(15, 136)
        Me.btnNavDashboard.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(153, 46)
        Me.btnNavDashboard.TabIndex = 3
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'lblDashboard
        '
        Me.lblDashboard.AutoSize = True
        Me.lblDashboard.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDashboard.Location = New System.Drawing.Point(20, 14)
        Me.lblDashboard.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDashboard.Name = "lblDashboard"
        Me.lblDashboard.Size = New System.Drawing.Size(291, 72)
        Me.lblDashboard.TabIndex = 0
        Me.lblDashboard.Text = "Dashboard"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(533, 88)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(153, 46)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'frmCreate
        '
        Me.frmCreate.Location = New System.Drawing.Point(787, 51)
        Me.frmCreate.Name = "frmCreate"
        Me.frmCreate.Size = New System.Drawing.Size(227, 83)
        Me.frmCreate.TabIndex = 8
        Me.frmCreate.Text = "Create Item, Location, Category"
        Me.frmCreate.UseVisualStyleBackColor = True
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 720)
        Me.Controls.Add(Me.frmCreate)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblDashboard)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgvDashboard)
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
    Friend WithEvents frmCreate As Button
End Class
