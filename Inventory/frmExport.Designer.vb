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
        Me.btnNavDashboard.Location = New System.Drawing.Point(12, 85)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(94, 29)
        Me.btnNavDashboard.TabIndex = 1
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(12, 173)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(94, 29)
        Me.btnNavCategories.TabIndex = 2
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(12, 217)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(94, 29)
        Me.btnNavLocations.TabIndex = 3
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(12, 129)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(94, 29)
        Me.btnNavItems.TabIndex = 9
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(12, 261)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(94, 29)
        Me.btnNavExport.TabIndex = 10
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.lblExport)
        Me.Name = "frmExport"
        Me.Text = "Export"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblExport As Label
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents btnNavCategories As Button
    Friend WithEvents btnNavLocations As Button
    Friend WithEvents btnNavItems As Button
    Friend WithEvents btnNavExport As Button
End Class
