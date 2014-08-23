<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDeposit
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
	Public WithEvents _chkFields_1 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFloat_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtHide_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtHide_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_28 As System.Windows.Forms.TextBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents cmbVat As myDataGridView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtHide As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
        Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._chkFields_1 = New System.Windows.Forms.CheckBox()
        Me._txtFloat_3 = New System.Windows.Forms.TextBox()
        Me._txtFloat_2 = New System.Windows.Forms.TextBox()
        Me._txtFloat_1 = New System.Windows.Forms.TextBox()
        Me._txtFloat_0 = New System.Windows.Forms.TextBox()
        Me._txtHide_1 = New System.Windows.Forms.TextBox()
        Me._txtHide_0 = New System.Windows.Forms.TextBox()
        Me._txtInteger_5 = New System.Windows.Forms.TextBox()
        Me._txtFields_4 = New System.Windows.Forms.TextBox()
        Me._txtFields_3 = New System.Windows.Forms.TextBox()
        Me._txtFields_28 = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbVat = New _4PosBackOffice.NET.myDataGridView()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._lblLabels_2 = New System.Windows.Forms.Label()
        Me._lblLabels_9 = New System.Windows.Forms.Label()
        Me._lblLabels_8 = New System.Windows.Forms.Label()
        Me._lblLabels_7 = New System.Windows.Forms.Label()
        Me._lblLabels_6 = New System.Windows.Forms.Label()
        Me._lblLabels_5 = New System.Windows.Forms.Label()
        Me._lblLabels_4 = New System.Windows.Forms.Label()
        Me._lblLabels_3 = New System.Windows.Forms.Label()
        Me._lblLabels_38 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.Shape1 = New _4PosBackOffice.NET.RectangleShapeArray(Me.components)
        Me.picButtons.SuspendLayout()
        CType(Me.cmbVat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._Shape1_2, Me._Shape1_0})
        Me.ShapeContainer1.Size = New System.Drawing.Size(549, 205)
        Me.ShapeContainer1.TabIndex = 26
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_2
        '
        Me._Shape1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me.Shape1.SetIndex(Me._Shape1_2, CType(2, Short))
        Me._Shape1_2.Location = New System.Drawing.Point(15, 60)
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Shape1_2.Size = New System.Drawing.Size(286, 136)
        '
        '_Shape1_0
        '
        Me._Shape1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_0.FillColor = System.Drawing.Color.Black
        Me.Shape1.SetIndex(Me._Shape1_0, CType(0, Short))
        Me._Shape1_0.Location = New System.Drawing.Point(309, 60)
        Me._Shape1_0.Name = "_Shape1_0"
        Me._Shape1_0.Size = New System.Drawing.Size(229, 76)
        '
        '_chkFields_1
        '
        Me._chkFields_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_1.Location = New System.Drawing.Point(171, 174)
        Me._chkFields_1.Name = "_chkFields_1"
        Me._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_1.Size = New System.Drawing.Size(118, 19)
        Me._chkFields_1.TabIndex = 11
        Me._chkFields_1.Text = "Disable this Deposit"
        Me._chkFields_1.UseVisualStyleBackColor = False
        '
        '_txtFloat_3
        '
        Me._txtFloat_3.AcceptsReturn = True
        Me._txtFloat_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_3.Location = New System.Drawing.Point(465, 99)
        Me._txtFloat_3.MaxLength = 0
        Me._txtFloat_3.Name = "_txtFloat_3"
        Me._txtFloat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_3.Size = New System.Drawing.Size(61, 19)
        Me._txtFloat_3.TabIndex = 20
        Me._txtFloat_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_2
        '
        Me._txtFloat_2.AcceptsReturn = True
        Me._txtFloat_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_2.Location = New System.Drawing.Point(402, 99)
        Me._txtFloat_2.MaxLength = 0
        Me._txtFloat_2.Name = "_txtFloat_2"
        Me._txtFloat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_2.Size = New System.Drawing.Size(61, 19)
        Me._txtFloat_2.TabIndex = 17
        Me._txtFloat_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_1
        '
        Me._txtFloat_1.AcceptsReturn = True
        Me._txtFloat_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_1.Location = New System.Drawing.Point(465, 78)
        Me._txtFloat_1.MaxLength = 0
        Me._txtFloat_1.Name = "_txtFloat_1"
        Me._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_1.Size = New System.Drawing.Size(61, 19)
        Me._txtFloat_1.TabIndex = 19
        Me._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_0
        '
        Me._txtFloat_0.AcceptsReturn = True
        Me._txtFloat_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_0.Location = New System.Drawing.Point(402, 78)
        Me._txtFloat_0.MaxLength = 0
        Me._txtFloat_0.Name = "_txtFloat_0"
        Me._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_0.Size = New System.Drawing.Size(61, 19)
        Me._txtFloat_0.TabIndex = 16
        Me._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtHide_1
        '
        Me._txtHide_1.AcceptsReturn = True
        Me._txtHide_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtHide_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtHide_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHide_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtHide_1.Location = New System.Drawing.Point(329, 167)
        Me._txtHide_1.MaxLength = 0
        Me._txtHide_1.Name = "_txtHide_1"
        Me._txtHide_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHide_1.Size = New System.Drawing.Size(99, 19)
        Me._txtHide_1.TabIndex = 25
        Me._txtHide_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtHide_1.Visible = False
        '
        '_txtHide_0
        '
        Me._txtHide_0.AcceptsReturn = True
        Me._txtHide_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtHide_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtHide_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtHide_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtHide_0.Location = New System.Drawing.Point(329, 142)
        Me._txtHide_0.MaxLength = 0
        Me._txtHide_0.Name = "_txtHide_0"
        Me._txtHide_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtHide_0.Size = New System.Drawing.Size(99, 19)
        Me._txtHide_0.TabIndex = 24
        Me._txtHide_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._txtHide_0.Visible = False
        '
        '_txtInteger_5
        '
        Me._txtInteger_5.AcceptsReturn = True
        Me._txtInteger_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtInteger_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtInteger_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtInteger_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtInteger_5.Location = New System.Drawing.Point(239, 152)
        Me._txtInteger_5.MaxLength = 0
        Me._txtInteger_5.Name = "_txtInteger_5"
        Me._txtInteger_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtInteger_5.Size = New System.Drawing.Size(51, 19)
        Me._txtInteger_5.TabIndex = 10
        Me._txtInteger_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFields_4
        '
        Me._txtFields_4.AcceptsReturn = True
        Me._txtFields_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_4.Location = New System.Drawing.Point(104, 108)
        Me._txtFields_4.MaxLength = 15
        Me._txtFields_4.Name = "_txtFields_4"
        Me._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_4.Size = New System.Drawing.Size(184, 19)
        Me._txtFields_4.TabIndex = 6
        '
        '_txtFields_3
        '
        Me._txtFields_3.AcceptsReturn = True
        Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_3.Location = New System.Drawing.Point(105, 87)
        Me._txtFields_3.MaxLength = 20
        Me._txtFields_3.Name = "_txtFields_3"
        Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_3.Size = New System.Drawing.Size(184, 19)
        Me._txtFields_3.TabIndex = 4
        '
        '_txtFields_28
        '
        Me._txtFields_28.AcceptsReturn = True
        Me._txtFields_28.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_28.Location = New System.Drawing.Point(104, 64)
        Me._txtFields_28.MaxLength = 128
        Me._txtFields_28.Name = "_txtFields_28"
        Me._txtFields_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_28.Size = New System.Drawing.Size(184, 19)
        Me._txtFields_28.TabIndex = 2
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdPrint)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(549, 39)
        Me.picButtons.TabIndex = 23
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(375, 3)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
        Me.cmdPrint.TabIndex = 26
        Me.cmdPrint.TabStop = False
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
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
        Me.cmdCancel.TabIndex = 22
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(460, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 21
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmbVat
        '
        Me.cmbVat.AllowAddNew = True
        Me.cmbVat.BoundText = ""
        Me.cmbVat.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbVat.Col = 0
        Me.cmbVat.CtlText = ""
        Me.cmbVat.DataField = Nothing
        Me.cmbVat.Location = New System.Drawing.Point(105, 129)
        Me.cmbVat.Name = "cmbVat"
        Me.cmbVat.row = 0
        Me.cmbVat.Size = New System.Drawing.Size(184, 21)
        Me.cmbVat.TabIndex = 8
        Me.cmbVat.TopRow = 0
        '
        '_lbl_0
        '
        Me._lbl_0.AutoSize = True
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(309, 45)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(57, 14)
        Me._lbl_0.TabIndex = 12
        Me._lbl_0.Text = "&2. Pricing"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.AutoSize = True
        Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_2.Location = New System.Drawing.Point(72, 132)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(31, 13)
        Me._lblLabels_2.TabIndex = 7
        Me._lblLabels_2.Text = "VAT:"
        Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_9
        '
        Me._lblLabels_9.AutoSize = True
        Me._lblLabels_9.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_9.Location = New System.Drawing.Point(498, 66)
        Me._lblLabels_9.Name = "_lblLabels_9"
        Me._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_9.Size = New System.Drawing.Size(31, 13)
        Me._lblLabels_9.TabIndex = 18
        Me._lblLabels_9.Text = "Case"
        Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_8
        '
        Me._lblLabels_8.AutoSize = True
        Me._lblLabels_8.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_8.Location = New System.Drawing.Point(432, 66)
        Me._lblLabels_8.Name = "_lblLabels_8"
        Me._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_8.Size = New System.Drawing.Size(34, 13)
        Me._lblLabels_8.TabIndex = 15
        Me._lblLabels_8.Text = "Bottle"
        Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_7
        '
        Me._lblLabels_7.AutoSize = True
        Me._lblLabels_7.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_7.Location = New System.Drawing.Point(318, 99)
        Me._lblLabels_7.Name = "_lblLabels_7"
        Me._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_7.Size = New System.Drawing.Size(84, 13)
        Me._lblLabels_7.TabIndex = 14
        Me._lblLabels_7.Text = "2. Special Price:"
        Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_6
        '
        Me._lblLabels_6.AutoSize = True
        Me._lblLabels_6.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_6.Location = New System.Drawing.Point(312, 81)
        Me._lblLabels_6.Name = "_lblLabels_6"
        Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_6.Size = New System.Drawing.Size(91, 13)
        Me._lblLabels_6.TabIndex = 13
        Me._lblLabels_6.Text = "1. Inclusive Price:"
        Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_5
        '
        Me._lblLabels_5.AutoSize = True
        Me._lblLabels_5.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_5.Location = New System.Drawing.Point(104, 155)
        Me._lblLabels_5.Name = "_lblLabels_5"
        Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_5.Size = New System.Drawing.Size(138, 13)
        Me._lblLabels_5.TabIndex = 9
        Me._lblLabels_5.Text = "Number of Bottles In a case"
        Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.AutoSize = True
        Me._lblLabels_4.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_4.Location = New System.Drawing.Point(21, 108)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(84, 13)
        Me._lblLabels_4.TabIndex = 5
        Me._lblLabels_4.Text = "POS Quick Key:"
        Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.AutoSize = True
        Me._lblLabels_3.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_3.Location = New System.Drawing.Point(27, 87)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(78, 13)
        Me._lblLabels_3.TabIndex = 3
        Me._lblLabels_3.Text = "Receipt Name:"
        Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_38
        '
        Me._lblLabels_38.AutoSize = True
        Me._lblLabels_38.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_38.Location = New System.Drawing.Point(30, 69)
        Me._lblLabels_38.Name = "_lblLabels_38"
        Me._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_38.Size = New System.Drawing.Size(75, 13)
        Me._lblLabels_38.TabIndex = 1
        Me._lblLabels_38.Text = "Display Name:"
        Me._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(15, 45)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(62, 14)
        Me._lbl_5.TabIndex = 0
        Me._lbl_5.Text = "&1. General"
        '
        'frmDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(549, 205)
        Me.ControlBox = False
        Me.Controls.Add(Me._chkFields_1)
        Me.Controls.Add(Me._txtFloat_3)
        Me.Controls.Add(Me._txtFloat_2)
        Me.Controls.Add(Me._txtFloat_1)
        Me.Controls.Add(Me._txtFloat_0)
        Me.Controls.Add(Me._txtHide_1)
        Me.Controls.Add(Me._txtHide_0)
        Me.Controls.Add(Me._txtInteger_5)
        Me.Controls.Add(Me._txtFields_4)
        Me.Controls.Add(Me._txtFields_3)
        Me.Controls.Add(Me._txtFields_28)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.cmbVat)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_9)
        Me.Controls.Add(Me._lblLabels_8)
        Me.Controls.Add(Me._lblLabels_7)
        Me.Controls.Add(Me._lblLabels_6)
        Me.Controls.Add(Me._lblLabels_5)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_38)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeposit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Deposit Details"
        Me.picButtons.ResumeLayout(False)
        CType(Me.cmbVat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class