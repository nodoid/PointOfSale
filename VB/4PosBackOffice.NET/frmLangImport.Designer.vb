<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLangImport
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
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents prgUpdate As System.Windows.Forms.ProgressBar
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents txtFile As System.Windows.Forms.TextBox
	Public cmdDlgOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.prgUpdate = New System.Windows.Forms.ProgressBar()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.cmdDlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line2, Me.Line1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(512, 234)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line2.BorderWidth = 2
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 8
        Me.Line2.X2 = 508
        Me.Line2.Y1 = 156
        Me.Line2.Y2 = 156
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line1.BorderWidth = 2
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 4
        Me.Line1.X2 = 504
        Me.Line1.Y1 = 76
        Me.Line1.Y2 = 76
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(88, 160)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(371, 17)
        Me.Text1.TabIndex = 8
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(476, 164)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(35, 15)
        Me.Command1.TabIndex = 7
        Me.Command1.Text = "..."
        Me.Command1.UseVisualStyleBackColor = False
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(512, 38)
        Me.picButtons.TabIndex = 4
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(432, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'prgUpdate
        '
        Me.prgUpdate.Location = New System.Drawing.Point(84, 192)
        Me.prgUpdate.Maximum = 1
        Me.prgUpdate.Name = "prgUpdate"
        Me.prgUpdate.Size = New System.Drawing.Size(373, 33)
        Me.prgUpdate.TabIndex = 3
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(472, 84)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(35, 15)
        Me.Command3.TabIndex = 2
        Me.Command3.Text = "..."
        Me.Command3.UseVisualStyleBackColor = False
        '
        'txtFile
        '
        Me.txtFile.AcceptsReturn = True
        Me.txtFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFile.Location = New System.Drawing.Point(84, 80)
        Me.txtFile.MaxLength = 0
        Me.txtFile.Name = "txtFile"
        Me.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFile.Size = New System.Drawing.Size(371, 17)
        Me.txtFile.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(495, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Menu Translation  -  CSV file layout: ( MenuNo | Description )"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "File path"
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblHeading.Location = New System.Drawing.Point(8, 48)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeading.Size = New System.Drawing.Size(495, 21)
        Me.lblHeading.TabIndex = 6
        Me.lblHeading.Text = "Main Translation  -  CSV file layout: ( LanguageNo | Description )"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "File path"
        '
        'frmLangImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(512, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.prgUpdate)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLangImport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Language Translation"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class