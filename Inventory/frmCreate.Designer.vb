<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreate
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
        Me.lblCreate = New System.Windows.Forms.Label()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.btnNavItems = New System.Windows.Forms.Button()
        Me.btnNavExport = New System.Windows.Forms.Button()
        Me.btnNavLocations = New System.Windows.Forms.Button()
        Me.btnNavCategories = New System.Windows.Forms.Button()
        Me.cmbList = New System.Windows.Forms.ComboBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCreate
        '
        Me.lblCreate.AutoSize = True
        Me.lblCreate.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblCreate.Location = New System.Drawing.Point(23, 17)
        Me.lblCreate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCreate.Name = "lblCreate"
        Me.lblCreate.Size = New System.Drawing.Size(831, 72)
        Me.lblCreate.TabIndex = 9
        Me.lblCreate.Text = "Create Item, Location or Category"
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Location = New System.Drawing.Point(18, 139)
        Me.btnNavDashboard.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(153, 46)
        Me.btnNavDashboard.TabIndex = 13
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = True
        '
        'btnNavItems
        '
        Me.btnNavItems.Location = New System.Drawing.Point(18, 211)
        Me.btnNavItems.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNavItems.Name = "btnNavItems"
        Me.btnNavItems.Size = New System.Drawing.Size(153, 46)
        Me.btnNavItems.TabIndex = 14
        Me.btnNavItems.Text = "Items"
        Me.btnNavItems.UseVisualStyleBackColor = True
        '
        'btnNavExport
        '
        Me.btnNavExport.Location = New System.Drawing.Point(18, 427)
        Me.btnNavExport.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNavExport.Name = "btnNavExport"
        Me.btnNavExport.Size = New System.Drawing.Size(153, 46)
        Me.btnNavExport.TabIndex = 17
        Me.btnNavExport.Text = "Export"
        Me.btnNavExport.UseVisualStyleBackColor = True
        '
        'btnNavLocations
        '
        Me.btnNavLocations.Location = New System.Drawing.Point(18, 355)
        Me.btnNavLocations.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNavLocations.Name = "btnNavLocations"
        Me.btnNavLocations.Size = New System.Drawing.Size(153, 46)
        Me.btnNavLocations.TabIndex = 16
        Me.btnNavLocations.Text = "Locations"
        Me.btnNavLocations.UseVisualStyleBackColor = True
        '
        'btnNavCategories
        '
        Me.btnNavCategories.Location = New System.Drawing.Point(18, 283)
        Me.btnNavCategories.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNavCategories.Name = "btnNavCategories"
        Me.btnNavCategories.Size = New System.Drawing.Size(153, 46)
        Me.btnNavCategories.TabIndex = 15
        Me.btnNavCategories.Text = "Categories"
        Me.btnNavCategories.UseVisualStyleBackColor = True
        '
        'cmbList
        '
        Me.cmbList.FormattingEnabled = True
        Me.cmbList.Items.AddRange(New Object() {"Category", "Item", "Location"})
        Me.cmbList.Location = New System.Drawing.Point(545, 145)
        Me.cmbList.Name = "cmbList"
        Me.cmbList.Size = New System.Drawing.Size(242, 40)
        Me.cmbList.TabIndex = 18
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(804, 296)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(150, 46)
        Me.btnCreate.TabIndex = 19
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        Me.btnCreate.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(545, 303)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(200, 39)
        Me.TextBox1.TabIndex = 20
        Me.TextBox1.Visible = False
        '
        'lbltype
        '
        Me.lbltype.AutoSize = True
        Me.lbltype.Location = New System.Drawing.Point(571, 254)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(135, 32)
        Me.lbltype.TabIndex = 21
        Me.lbltype.Text = "Description"
        '
        'frmCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 720)
        Me.Controls.Add(Me.lbltype)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.cmbList)
        Me.Controls.Add(Me.lblCreate)
        Me.Controls.Add(Me.btnNavDashboard)
        Me.Controls.Add(Me.btnNavItems)
        Me.Controls.Add(Me.btnNavExport)
        Me.Controls.Add(Me.btnNavLocations)
        Me.Controls.Add(Me.btnNavCategories)
        Me.Name = "frmCreate"
        Me.Text = "frmCreate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCreate As Label
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents btnNavItems As Button
    Friend WithEvents btnNavExport As Button
    Friend WithEvents btnNavLocations As Button
    Friend WithEvents btnNavCategories As Button
    Friend WithEvents cmbList As ComboBox
    Friend WithEvents btnCreate As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbltype As Label
End Class
