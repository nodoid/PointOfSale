<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBOSecurity
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents chkSelectAll As System.Windows.Forms.CheckBox
	Public WithEvents lstSecurity As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents lbl As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.lstSecurity = New System.Windows.Forms.CheckedListBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Shape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(359, 415)
        Me.ShapeContainer1.TabIndex = 6
        Me.ShapeContainer1.TabStop = False
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape1.FillColor = System.Drawing.Color.Black
        Me.Shape1.Location = New System.Drawing.Point(4, 62)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.Size(340, 328)
        '
        'chkSelectAll
        '
        Me.chkSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.chkSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSelectAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSelectAll.Location = New System.Drawing.Point(8, 396)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSelectAll.Size = New System.Drawing.Size(211, 17)
        Me.chkSelectAll.TabIndex = 5
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = False
        '
        'lstSecurity
        '
        Me.lstSecurity.BackColor = System.Drawing.SystemColors.Window
        Me.lstSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSecurity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSecurity.Location = New System.Drawing.Point(16, 72)
        Me.lstSecurity.Name = "lstSecurity"
        Me.lstSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSecurity.Size = New System.Drawing.Size(316, 302)
        Me.lstSecurity.TabIndex = 3
        Me.lstSecurity.Tag = "0"
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdExit)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(359, 39)
        Me.picButtons.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(276, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(73, 29)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl.Location = New System.Drawing.Point(12, 48)
        Me.lbl.Name = "lbl"
        Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl.Size = New System.Drawing.Size(62, 14)
        Me.lbl.TabIndex = 4
        Me.lbl.Text = "&1. General"
        '
        'frmBOSecurity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(359, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.lstSecurity)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBOSecurity"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Back Office Permissions"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class