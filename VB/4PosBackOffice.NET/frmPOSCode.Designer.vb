<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPOSCode
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		Form_Initialize_renamed()
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
	Public WithEvents txtFields As System.Windows.Forms.TextBox
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    'Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents chkFields As System.Windows.Forms.CheckBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.txtFields = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.chkFields = New System.Windows.Forms.CheckBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me._lblLabels_1 = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._Shape1_2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(347, 120)
        Me.ShapeContainer1.TabIndex = 12
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_2
        '
        Me._Shape1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me._Shape1_2.Location = New System.Drawing.Point(4, 64)
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Shape1_2.Size = New System.Drawing.Size(338, 49)
        '
        'txtFields
        '
        Me.txtFields.AcceptsReturn = True
        Me.txtFields.BackColor = System.Drawing.Color.White
        Me.txtFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFields.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFields.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFields.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFields.Location = New System.Drawing.Point(64, 76)
        Me.txtFields.MaxLength = 0
        Me.txtFields.Name = "txtFields"
        Me.txtFields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFields.Size = New System.Drawing.Size(270, 28)
        Me.txtFields.TabIndex = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(184, 344)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(151, 19)
        Me.Command2.TabIndex = 8
        Me.Command2.Text = "Close CD Tray and Register"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(208, 384)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(59, 19)
        Me.Command1.TabIndex = 6
        Me.Command1.Text = "Open"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'chkFields
        '
        Me.chkFields.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkFields.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFields.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFields.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkFields.Location = New System.Drawing.Point(264, 319)
        Me.chkFields.Name = "chkFields"
        Me.chkFields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFields.Size = New System.Drawing.Size(68, 17)
        Me.chkFields.TabIndex = 0
        Me.chkFields.Text = "Manual :"
        Me.chkFields.UseVisualStyleBackColor = False
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(347, 39)
        Me.picButtons.TabIndex = 4
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
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(256, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(81, 29)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "N&ext"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_1.Location = New System.Drawing.Point(8, 79)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(61, 16)
        Me._lblLabels_1.TabIndex = 11
        Me._lblLabels_1.Text = "CD Key :"
        Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_0
        '
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(6, 48)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(333, 21)
        Me._lbl_0.TabIndex = 9
        Me._lbl_0.Text = "Please type in your 4POS CD Key. [ without dashes ]"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_0.Location = New System.Drawing.Point(8, 346)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(56, 13)
        Me._lblLabels_0.TabIndex = 7
        Me._lblLabels_0.Text = "CD Drive :"
        Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(6, 274)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(333, 29)
        Me._lbl_5.TabIndex = 1
        Me._lbl_5.Text = "It looks you don't have CD-ROM drive. Please type the CD Key Manually."
        '
        'frmPOSCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(347, 120)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFields)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.chkFields)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSCode"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "4POS Registration"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class