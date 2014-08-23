<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPOS
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
	Public WithEvents _txtInteger_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdLocate As System.Windows.Forms.Button
	Public WithEvents _txtFields_10 As System.Windows.Forms.TextBox
	Public WithEvents chkKitchenMonitors As System.Windows.Forms.CheckBox
	Public WithEvents _txtInteger_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_2 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents _lblLic_0 As System.Windows.Forms.Label
	Public WithEvents _lblLic_1 As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents cmbKeyboard As myDataGridView
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
    Public WithEvents cmbWH As myDataGridView
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Shape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLic As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Shape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._txtInteger_1 = New System.Windows.Forms.TextBox()
        Me.cmdLocate = New System.Windows.Forms.Button()
        Me._txtFields_10 = New System.Windows.Forms.TextBox()
        Me.chkKitchenMonitors = New System.Windows.Forms.CheckBox()
        Me._txtInteger_0 = New System.Windows.Forms.TextBox()
        Me._txtFloat_5 = New System.Windows.Forms.TextBox()
        Me._txtInteger_4 = New System.Windows.Forms.TextBox()
        Me._txtFields_3 = New System.Windows.Forms.TextBox()
        Me._chkFields_2 = New System.Windows.Forms.CheckBox()
        Me._txtFields_1 = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me._lblLic_0 = New System.Windows.Forms.Label()
        Me._lblLic_1 = New System.Windows.Forms.Label()
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog()
        Me._lblLabels_6 = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._lblLabels_2 = New System.Windows.Forms.Label()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
        Me._lblLabels_5 = New System.Windows.Forms.Label()
        Me._lblLabels_4 = New System.Windows.Forms.Label()
        Me._lblLabels_3 = New System.Windows.Forms.Label()
        Me._lblLabels_1 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Shape2, Me._Shape1_2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(452, 214)
        Me.ShapeContainer1.TabIndex = 25
        Me.ShapeContainer1.TabStop = False
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Shape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Shape2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape2.FillColor = System.Drawing.Color.Black
        Me.Shape2.Location = New System.Drawing.Point(4, 180)
        Me.Shape2.Name = "Shape2"
        Me.Shape2.Size = New System.Drawing.Size(441, 29)
        '
        '_Shape1_2
        '
        Me._Shape1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me._Shape1_2.Location = New System.Drawing.Point(4, 56)
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Shape1_2.Size = New System.Drawing.Size(442, 103)
        '
        '_txtInteger_1
        '
        Me._txtInteger_1.AcceptsReturn = True
        Me._txtInteger_1.BackColor = System.Drawing.Color.White
        Me._txtInteger_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtInteger_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtInteger_1.Enabled = False
        Me._txtInteger_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtInteger_1.Location = New System.Drawing.Point(110, 248)
        Me._txtInteger_1.MaxLength = 0
        Me._txtInteger_1.Name = "_txtInteger_1"
        Me._txtInteger_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtInteger_1.Size = New System.Drawing.Size(246, 19)
        Me._txtInteger_1.TabIndex = 22
        Me._txtInteger_1.Visible = False
        '
        'cmdLocate
        '
        Me.cmdLocate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLocate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLocate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLocate.Location = New System.Drawing.Point(360, 248)
        Me.cmdLocate.Name = "cmdLocate"
        Me.cmdLocate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLocate.Size = New System.Drawing.Size(76, 19)
        Me.cmdLocate.TabIndex = 20
        Me.cmdLocate.Text = "Locate ..."
        Me.cmdLocate.UseVisualStyleBackColor = False
        Me.cmdLocate.Visible = False
        '
        '_txtFields_10
        '
        Me._txtFields_10.AcceptsReturn = True
        Me._txtFields_10.BackColor = System.Drawing.Color.White
        Me._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_10.Location = New System.Drawing.Point(272, 280)
        Me._txtFields_10.MaxLength = 0
        Me._txtFields_10.Name = "_txtFields_10"
        Me._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_10.Size = New System.Drawing.Size(78, 19)
        Me._txtFields_10.TabIndex = 19
        '
        'chkKitchenMonitors
        '
        Me.chkKitchenMonitors.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkKitchenMonitors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkKitchenMonitors.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkKitchenMonitors.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKitchenMonitors.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkKitchenMonitors.Location = New System.Drawing.Point(122, 186)
        Me.chkKitchenMonitors.Name = "chkKitchenMonitors"
        Me.chkKitchenMonitors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkKitchenMonitors.Size = New System.Drawing.Size(317, 17)
        Me.chkKitchenMonitors.TabIndex = 18
        Me.chkKitchenMonitors.Text = "Setup this Terminal as a Kitchen Monitor  ( for Drive Thru only )"
        Me.chkKitchenMonitors.UseVisualStyleBackColor = False
        '
        '_txtInteger_0
        '
        Me._txtInteger_0.AcceptsReturn = True
        Me._txtInteger_0.BackColor = System.Drawing.Color.White
        Me._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtInteger_0.Location = New System.Drawing.Point(300, 60)
        Me._txtInteger_0.MaxLength = 0
        Me._txtInteger_0.Name = "_txtInteger_0"
        Me._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtInteger_0.Size = New System.Drawing.Size(27, 19)
        Me._txtInteger_0.TabIndex = 3
        Me._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_5
        '
        Me._txtFloat_5.AcceptsReturn = True
        Me._txtFloat_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_5.Location = New System.Drawing.Point(110, 104)
        Me._txtFloat_5.MaxLength = 0
        Me._txtFloat_5.Name = "_txtFloat_5"
        Me._txtFloat_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_5.Size = New System.Drawing.Size(78, 19)
        Me._txtFloat_5.TabIndex = 10
        Me._txtFloat_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtInteger_4
        '
        Me._txtInteger_4.AcceptsReturn = True
        Me._txtInteger_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._txtInteger_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtInteger_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtInteger_4.Enabled = False
        Me._txtInteger_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtInteger_4.Location = New System.Drawing.Point(362, 80)
        Me._txtInteger_4.MaxLength = 0
        Me._txtInteger_4.Name = "_txtInteger_4"
        Me._txtInteger_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtInteger_4.Size = New System.Drawing.Size(78, 19)
        Me._txtInteger_4.TabIndex = 7
        '
        '_txtFields_3
        '
        Me._txtFields_3.AcceptsReturn = True
        Me._txtFields_3.BackColor = System.Drawing.Color.White
        Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_3.Location = New System.Drawing.Point(110, 82)
        Me._txtFields_3.MaxLength = 0
        Me._txtFields_3.Name = "_txtFields_3"
        Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_3.Size = New System.Drawing.Size(78, 19)
        Me._txtFields_3.TabIndex = 5
        '
        '_chkFields_2
        '
        Me._chkFields_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_2.Location = New System.Drawing.Point(10, 106)
        Me._chkFields_2.Name = "_chkFields_2"
        Me._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_2.Size = New System.Drawing.Size(60, 17)
        Me._chkFields_2.TabIndex = 8
        Me._chkFields_2.Text = "Disable:"
        Me._chkFields_2.UseVisualStyleBackColor = False
        '
        '_txtFields_1
        '
        Me._txtFields_1.AcceptsReturn = True
        Me._txtFields_1.BackColor = System.Drawing.Color.White
        Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_1.Location = New System.Drawing.Point(110, 60)
        Me._txtFields_1.MaxLength = 0
        Me._txtFields_1.Name = "_txtFields_1"
        Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_1.Size = New System.Drawing.Size(78, 19)
        Me._txtFields_1.TabIndex = 1
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Controls.Add(Me._lblLic_0)
        Me.picButtons.Controls.Add(Me._lblLic_1)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(452, 39)
        Me.picButtons.TabIndex = 16
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
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(372, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        '_lblLic_0
        '
        Me._lblLic_0.BackColor = System.Drawing.Color.Red
        Me._lblLic_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLic_0.ForeColor = System.Drawing.Color.White
        Me._lblLic_0.Location = New System.Drawing.Point(176, 8)
        Me._lblLic_0.Name = "_lblLic_0"
        Me._lblLic_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLic_0.Size = New System.Drawing.Size(113, 19)
        Me._lblLic_0.TabIndex = 25
        Me._lblLic_0.Text = "Not Licensed"
        Me._lblLic_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblLic_0.Visible = False
        '
        '_lblLic_1
        '
        Me._lblLic_1.BackColor = System.Drawing.Color.Red
        Me._lblLic_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLic_1.ForeColor = System.Drawing.Color.White
        Me._lblLic_1.Location = New System.Drawing.Point(120, 3)
        Me._lblLic_1.Name = "_lblLic_1"
        Me._lblLic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLic_1.Size = New System.Drawing.Size(217, 27)
        Me._lblLic_1.TabIndex = 26
        Me._lblLic_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblLic_1.Visible = False
        '
        'CommonDialog1Open
        '
        Me.CommonDialog1Open.FileName = "waitron.mdb"
        Me.CommonDialog1Open.Title = "Path to Waitron dabatase"
        '
        '_lblLabels_6
        '
        Me._lblLabels_6.AutoSize = True
        Me._lblLabels_6.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_6.Location = New System.Drawing.Point(10, 131)
        Me._lblLabels_6.Name = "_lblLabels_6"
        Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_6.Size = New System.Drawing.Size(65, 13)
        Me._lblLabels_6.TabIndex = 24
        Me._lblLabels_6.Text = "Warehouse:"
        Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_0
        '
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(10, 250)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(94, 13)
        Me._lbl_0.TabIndex = 21
        Me._lbl_0.Text = "Server Path:"
        Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._lbl_0.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "&2. Kitchen Monitors"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.AutoSize = True
        Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_2.Location = New System.Drawing.Point(230, 63)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(72, 13)
        Me._lblLabels_2.TabIndex = 2
        Me._lblLabels_2.Text = "POS Number:"
        Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_0.Location = New System.Drawing.Point(204, 108)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(92, 13)
        Me._lblLabels_0.TabIndex = 11
        Me._lblLabels_0.Text = "Default Keyboard:"
        Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_5
        '
        Me._lblLabels_5.AutoSize = True
        Me._lblLabels_5.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_5.Location = New System.Drawing.Point(80, 108)
        Me._lblLabels_5.Name = "_lblLabels_5"
        Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_5.Size = New System.Drawing.Size(33, 13)
        Me._lblLabels_5.TabIndex = 9
        Me._lblLabels_5.Text = "Float:"
        Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.AutoSize = True
        Me._lblLabels_4.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_4.Location = New System.Drawing.Point(271, 84)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(87, 13)
        Me._lblLabels_4.TabIndex = 6
        Me._lblLabels_4.Text = "Last Declaration:"
        Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.AutoSize = True
        Me._lblLabels_3.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_3.Location = New System.Drawing.Point(26, 84)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(86, 13)
        Me._lblLabels_3.TabIndex = 4
        Me._lblLabels_3.Text = "POS IP Address:"
        Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblLabels_1.Location = New System.Drawing.Point(48, 63)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(63, 13)
        Me._lblLabels_1.TabIndex = 0
        Me._lblLabels_1.Text = "POS Name:"
        Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(6, 42)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(56, 13)
        Me._lbl_5.TabIndex = 13
        Me._lbl_5.Text = "&1. General"
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(452, 214)
        Me.ControlBox = False
        Me.Controls.Add(Me._txtInteger_1)
        Me.Controls.Add(Me.cmdLocate)
        Me.Controls.Add(Me._txtFields_10)
        Me.Controls.Add(Me.chkKitchenMonitors)
        Me.Controls.Add(Me._txtInteger_0)
        Me.Controls.Add(Me._txtFloat_5)
        Me.Controls.Add(Me._txtInteger_4)
        Me.Controls.Add(Me._txtFields_3)
        Me.Controls.Add(Me._chkFields_2)
        Me.Controls.Add(Me._txtFields_1)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._lblLabels_6)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lblLabels_5)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Point Of Sale Details"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class