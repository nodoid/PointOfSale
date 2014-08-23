<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBarcodeLoad
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
	Public WithEvents _Option1_11 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_10 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_9 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_8 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_7 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_6 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_5 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_4 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_3 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents _chkFields_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chkFields_1 As System.Windows.Forms.CheckBox
    Public WithEvents _chkFields_2 As System.Windows.Forms.CheckBox
    Public WithEvents _chkFields_3 As System.Windows.Forms.CheckBox
    Public WithEvents _chkFields_4 As System.Windows.Forms.CheckBox
    Public WithEvents _chkFields_5 As System.Windows.Forms.CheckBox
	Public WithEvents txtpos As System.Windows.Forms.TextBox
	Public WithEvents cmbfont As System.Windows.Forms.ComboBox
	Public WithEvents _Option2_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option2_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option2_0 As System.Windows.Forms.RadioButton
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents frmDeposits As System.Windows.Forms.GroupBox
	Public WithEvents HSLeft As System.Windows.Forms.HScrollBar
	Public WithEvents HSTop As System.Windows.Forms.HScrollBar
	Public WithEvents cmdundo As System.Windows.Forms.Button
	Public WithEvents cmdnormal As System.Windows.Forms.Button
	Public WithEvents cmbpos As System.Windows.Forms.ComboBox
	Public WithEvents cmdadd As System.Windows.Forms.Button
	Public cmdDlgOpen As System.Windows.Forms.OpenFileDialog
	Public cmdDlgSave As System.Windows.Forms.SaveFileDialog
	Public cmdDlgFont As System.Windows.Forms.FontDialog
	Public cmdDlgColor As System.Windows.Forms.ColorDialog
	Public cmdDlgPrint As System.Windows.Forms.PrintDialog
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents HSHeight As System.Windows.Forms.HScrollBar
	Public WithEvents HSselect As System.Windows.Forms.HScrollBar
	Public WithEvents _picSelect_0 As System.Windows.Forms.PictureBox
	Public WithEvents picInner As System.Windows.Forms.Panel
	Public WithEvents picOuter As System.Windows.Forms.Panel
	Public WithEvents HSWidth As System.Windows.Forms.HScrollBar
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents lblLeft As System.Windows.Forms.Label
	Public WithEvents _lbl_6 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents lblTop As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents lblLineNo As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblWidth As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents lblHeight As System.Windows.Forms.Label
	Public WithEvents lbldesign As System.Windows.Forms.Label
    'Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'Public WithEvents Option2 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents picSelect As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcodeLoad))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me._Option1_11 = New System.Windows.Forms.RadioButton()
        Me._Option1_10 = New System.Windows.Forms.RadioButton()
        Me._Option1_9 = New System.Windows.Forms.RadioButton()
        Me._Option1_8 = New System.Windows.Forms.RadioButton()
        Me._Option1_7 = New System.Windows.Forms.RadioButton()
        Me._Option1_6 = New System.Windows.Forms.RadioButton()
        Me._Option1_5 = New System.Windows.Forms.RadioButton()
        Me._Option1_4 = New System.Windows.Forms.RadioButton()
        Me._Option1_3 = New System.Windows.Forms.RadioButton()
        Me._Option1_2 = New System.Windows.Forms.RadioButton()
        Me._Option1_1 = New System.Windows.Forms.RadioButton()
        Me._Option1_0 = New System.Windows.Forms.RadioButton()
        Me.frmDeposits = New System.Windows.Forms.GroupBox()
        Me._chkFields_4 = New System.Windows.Forms.CheckBox()
        Me._chkFields_0 = New System.Windows.Forms.CheckBox()
        Me.txtpos = New System.Windows.Forms.TextBox()
        Me.cmbfont = New System.Windows.Forms.ComboBox()
        Me._Option2_2 = New System.Windows.Forms.RadioButton()
        Me._Option2_1 = New System.Windows.Forms.RadioButton()
        Me._Option2_0 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._chkFields_1 = New System.Windows.Forms.CheckBox()
        Me._chkFields_2 = New System.Windows.Forms.CheckBox()
        Me._chkFields_3 = New System.Windows.Forms.CheckBox()
        Me._chkFields_5 = New System.Windows.Forms.CheckBox()
        Me.HSLeft = New System.Windows.Forms.HScrollBar()
        Me.HSTop = New System.Windows.Forms.HScrollBar()
        Me.cmdundo = New System.Windows.Forms.Button()
        Me.cmdnormal = New System.Windows.Forms.Button()
        Me.cmbpos = New System.Windows.Forms.ComboBox()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdDlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cmdDlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.cmdDlgFont = New System.Windows.Forms.FontDialog()
        Me.cmdDlgColor = New System.Windows.Forms.ColorDialog()
        Me.cmdDlgPrint = New System.Windows.Forms.PrintDialog()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.HSHeight = New System.Windows.Forms.HScrollBar()
        Me.HSselect = New System.Windows.Forms.HScrollBar()
        Me.picOuter = New System.Windows.Forms.Panel()
        Me.picInner = New System.Windows.Forms.Panel()
        Me._picSelect_0 = New System.Windows.Forms.PictureBox()
        Me.HSWidth = New System.Windows.Forms.HScrollBar()
        Me._lbl_7 = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me._lbl_6 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me._lbl_4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblLineNo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._lbl_1 = New System.Windows.Forms.Label()
        Me._lbl_2 = New System.Windows.Forms.Label()
        Me._lbl_3 = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lbldesign = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.frmDeposits.SuspendLayout()
        Me.picOuter.SuspendLayout()
        Me.picInner.SuspendLayout()
        CType(Me._picSelect_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Frame1.Controls.Add(Me._Option1_11)
        Me.Frame1.Controls.Add(Me._Option1_10)
        Me.Frame1.Controls.Add(Me._Option1_9)
        Me.Frame1.Controls.Add(Me._Option1_8)
        Me.Frame1.Controls.Add(Me._Option1_7)
        Me.Frame1.Controls.Add(Me._Option1_6)
        Me.Frame1.Controls.Add(Me._Option1_5)
        Me.Frame1.Controls.Add(Me._Option1_4)
        Me.Frame1.Controls.Add(Me._Option1_3)
        Me.Frame1.Controls.Add(Me._Option1_2)
        Me.Frame1.Controls.Add(Me._Option1_1)
        Me.Frame1.Controls.Add(Me._Option1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(568, 24)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(142, 300)
        Me.Frame1.TabIndex = 41
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Field to Format"
        '
        '_Option1_11
        '
        Me._Option1_11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_11.Location = New System.Drawing.Point(8, 280)
        Me._Option1_11.Name = "_Option1_11"
        Me._Option1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_11.Size = New System.Drawing.Size(129, 17)
        Me._Option1_11.TabIndex = 53
        Me._Option1_11.TabStop = True
        Me._Option1_11.Text = "&Price for   24:"
        Me._Option1_11.UseVisualStyleBackColor = False
        '
        '_Option1_10
        '
        Me._Option1_10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_10.Location = New System.Drawing.Point(8, 256)
        Me._Option1_10.Name = "_Option1_10"
        Me._Option1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_10.Size = New System.Drawing.Size(129, 17)
        Me._Option1_10.TabIndex = 52
        Me._Option1_10.TabStop = True
        Me._Option1_10.Text = "&Price for   12:"
        Me._Option1_10.UseVisualStyleBackColor = False
        '
        '_Option1_9
        '
        Me._Option1_9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_9.Location = New System.Drawing.Point(8, 232)
        Me._Option1_9.Name = "_Option1_9"
        Me._Option1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_9.Size = New System.Drawing.Size(129, 17)
        Me._Option1_9.TabIndex = 51
        Me._Option1_9.TabStop = True
        Me._Option1_9.Text = "&Price for    6:"
        Me._Option1_9.UseVisualStyleBackColor = False
        '
        '_Option1_8
        '
        Me._Option1_8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_8.Location = New System.Drawing.Point(8, 184)
        Me._Option1_8.Name = "_Option1_8"
        Me._Option1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_8.Size = New System.Drawing.Size(129, 17)
        Me._Option1_8.TabIndex = 50
        Me._Option1_8.TabStop = True
        Me._Option1_8.Text = "Blan&k"
        Me._Option1_8.UseVisualStyleBackColor = False
        '
        '_Option1_7
        '
        Me._Option1_7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_7.Location = New System.Drawing.Point(8, 160)
        Me._Option1_7.Name = "_Option1_7"
        Me._Option1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_7.Size = New System.Drawing.Size(129, 17)
        Me._Option1_7.TabIndex = 49
        Me._Option1_7.TabStop = True
        Me._Option1_7.Text = "Bar&code:"
        Me._Option1_7.UseVisualStyleBackColor = False
        '
        '_Option1_6
        '
        Me._Option1_6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_6.Location = New System.Drawing.Point(8, 136)
        Me._Option1_6.Name = "_Option1_6"
        Me._Option1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_6.Size = New System.Drawing.Size(129, 17)
        Me._Option1_6.TabIndex = 48
        Me._Option1_6.TabStop = True
        Me._Option1_6.Text = "&Line:"
        Me._Option1_6.UseVisualStyleBackColor = False
        '
        '_Option1_5
        '
        Me._Option1_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_5.Location = New System.Drawing.Point(8, 112)
        Me._Option1_5.Name = "_Option1_5"
        Me._Option1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_5.Size = New System.Drawing.Size(129, 17)
        Me._Option1_5.TabIndex = 47
        Me._Option1_5.TabStop = True
        Me._Option1_5.Text = "&Group:"
        Me._Option1_5.UseVisualStyleBackColor = False
        '
        '_Option1_4
        '
        Me._Option1_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_4.Location = New System.Drawing.Point(8, 208)
        Me._Option1_4.Name = "_Option1_4"
        Me._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_4.Size = New System.Drawing.Size(129, 17)
        Me._Option1_4.TabIndex = 46
        Me._Option1_4.TabStop = True
        Me._Option1_4.Text = "&Price for   1:"
        Me._Option1_4.UseVisualStyleBackColor = False
        '
        '_Option1_3
        '
        Me._Option1_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_3.Location = New System.Drawing.Point(8, 88)
        Me._Option1_3.Name = "_Option1_3"
        Me._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_3.Size = New System.Drawing.Size(129, 17)
        Me._Option1_3.TabIndex = 45
        Me._Option1_3.TabStop = True
        Me._Option1_3.Text = "&Telephone:"
        Me._Option1_3.UseVisualStyleBackColor = False
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_2.Location = New System.Drawing.Point(8, 64)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(129, 17)
        Me._Option1_2.TabIndex = 44
        Me._Option1_2.TabStop = True
        Me._Option1_2.Text = "Barcode &No:"
        Me._Option1_2.UseVisualStyleBackColor = False
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_1.Location = New System.Drawing.Point(8, 40)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(129, 17)
        Me._Option1_1.TabIndex = 43
        Me._Option1_1.TabStop = True
        Me._Option1_1.Text = "Stock &Item Name:"
        Me._Option1_1.UseVisualStyleBackColor = False
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_0.Location = New System.Drawing.Point(8, 16)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(129, 17)
        Me._Option1_0.TabIndex = 42
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "Company Na&me:"
        Me._Option1_0.UseVisualStyleBackColor = False
        '
        'frmDeposits
        '
        Me.frmDeposits.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.frmDeposits.Controls.Add(Me._chkFields_4)
        Me.frmDeposits.Controls.Add(Me._chkFields_0)
        Me.frmDeposits.Controls.Add(Me.txtpos)
        Me.frmDeposits.Controls.Add(Me.cmbfont)
        Me.frmDeposits.Controls.Add(Me._Option2_2)
        Me.frmDeposits.Controls.Add(Me._Option2_1)
        Me.frmDeposits.Controls.Add(Me._Option2_0)
        Me.frmDeposits.Controls.Add(Me.Label6)
        Me.frmDeposits.Controls.Add(Me.Label5)
        Me.frmDeposits.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmDeposits.Location = New System.Drawing.Point(568, 328)
        Me.frmDeposits.Name = "frmDeposits"
        Me.frmDeposits.Padding = New System.Windows.Forms.Padding(0)
        Me.frmDeposits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmDeposits.Size = New System.Drawing.Size(142, 185)
        Me.frmDeposits.TabIndex = 31
        Me.frmDeposits.TabStop = False
        Me.frmDeposits.Text = "Font"
        '
        '_chkFields_4
        '
        Me._chkFields_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_4.Location = New System.Drawing.Point(8, 160)
        Me._chkFields_4.Name = "_chkFields_4"
        Me._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_4.Size = New System.Drawing.Size(129, 19)
        Me._chkFields_4.TabIndex = 40
        Me._chkFields_4.Text = "Add/Remo&ve:"
        Me._chkFields_4.UseVisualStyleBackColor = False
        '
        '_chkFields_0
        '
        Me._chkFields_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_0.Location = New System.Drawing.Point(8, 64)
        Me._chkFields_0.Name = "_chkFields_0"
        Me._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_0.Size = New System.Drawing.Size(129, 19)
        Me._chkFields_0.TabIndex = 39
        Me._chkFields_0.Tag = "Company_Name"
        Me._chkFields_0.Text = "B&old:"
        Me._chkFields_0.UseVisualStyleBackColor = False
        '
        'txtpos
        '
        Me.txtpos.AcceptsReturn = True
        Me.txtpos.BackColor = System.Drawing.SystemColors.Window
        Me.txtpos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtpos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtpos.Location = New System.Drawing.Point(72, 48)
        Me.txtpos.MaxLength = 0
        Me.txtpos.Name = "txtpos"
        Me.txtpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtpos.Size = New System.Drawing.Size(65, 19)
        Me.txtpos.TabIndex = 37
        Me.txtpos.Text = "1"
        '
        'cmbfont
        '
        Me.cmbfont.BackColor = System.Drawing.SystemColors.Window
        Me.cmbfont.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbfont.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbfont.Items.AddRange(New Object() {"8", "10", "12"})
        Me.cmbfont.Location = New System.Drawing.Point(72, 24)
        Me.cmbfont.Name = "cmbfont"
        Me.cmbfont.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbfont.Size = New System.Drawing.Size(65, 21)
        Me.cmbfont.TabIndex = 35
        Me.cmbfont.Text = "8"
        '
        '_Option2_2
        '
        Me._Option2_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option2_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option2_2.Location = New System.Drawing.Point(8, 136)
        Me._Option2_2.Name = "_Option2_2"
        Me._Option2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_2.Size = New System.Drawing.Size(129, 17)
        Me._Option2_2.TabIndex = 34
        Me._Option2_2.TabStop = True
        Me._Option2_2.Text = "Align &Right:"
        Me._Option2_2.UseVisualStyleBackColor = False
        '
        '_Option2_1
        '
        Me._Option2_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option2_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option2_1.Location = New System.Drawing.Point(8, 112)
        Me._Option2_1.Name = "_Option2_1"
        Me._Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_1.Size = New System.Drawing.Size(129, 17)
        Me._Option2_1.TabIndex = 33
        Me._Option2_1.TabStop = True
        Me._Option2_1.Text = "Align &Center:"
        Me._Option2_1.UseVisualStyleBackColor = False
        '
        '_Option2_0
        '
        Me._Option2_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Option2_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Option2_0.Location = New System.Drawing.Point(8, 88)
        Me._Option2_0.Name = "_Option2_0"
        Me._Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_0.Size = New System.Drawing.Size(129, 17)
        Me._Option2_0.TabIndex = 32
        Me._Option2_0.TabStop = True
        Me._Option2_0.Text = "Align Le&ft:"
        Me._Option2_0.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Ro&w Position:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Font Si&ze:"
        '
        '_chkFields_1
        '
        Me._chkFields_1.Location = New System.Drawing.Point(0, 0)
        Me._chkFields_1.Name = "_chkFields_1"
        Me._chkFields_1.Size = New System.Drawing.Size(104, 24)
        Me._chkFields_1.TabIndex = 0
        '
        '_chkFields_2
        '
        Me._chkFields_2.Location = New System.Drawing.Point(0, 0)
        Me._chkFields_2.Name = "_chkFields_2"
        Me._chkFields_2.Size = New System.Drawing.Size(104, 24)
        Me._chkFields_2.TabIndex = 0
        '
        '_chkFields_3
        '
        Me._chkFields_3.Location = New System.Drawing.Point(0, 0)
        Me._chkFields_3.Name = "_chkFields_3"
        Me._chkFields_3.Size = New System.Drawing.Size(104, 24)
        Me._chkFields_3.TabIndex = 0
        '
        '_chkFields_5
        '
        Me._chkFields_5.Location = New System.Drawing.Point(0, 0)
        Me._chkFields_5.Name = "_chkFields_5"
        Me._chkFields_5.Size = New System.Drawing.Size(104, 24)
        Me._chkFields_5.TabIndex = 0
        '
        'HSLeft
        '
        Me.HSLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.HSLeft.LargeChange = 5
        Me.HSLeft.Location = New System.Drawing.Point(416, 48)
        Me.HSLeft.Maximum = 104
        Me.HSLeft.Name = "HSLeft"
        Me.HSLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HSLeft.Size = New System.Drawing.Size(112, 19)
        Me.HSLeft.TabIndex = 27
        Me.HSLeft.TabStop = True
        '
        'HSTop
        '
        Me.HSTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.HSTop.LargeChange = 5
        Me.HSTop.Location = New System.Drawing.Point(280, 48)
        Me.HSTop.Maximum = 26
        Me.HSTop.Name = "HSTop"
        Me.HSTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HSTop.Size = New System.Drawing.Size(112, 19)
        Me.HSTop.TabIndex = 26
        Me.HSTop.TabStop = True
        '
        'cmdundo
        '
        Me.cmdundo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdundo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdundo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdundo.Location = New System.Drawing.Point(136, 464)
        Me.cmdundo.Name = "cmdundo"
        Me.cmdundo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdundo.Size = New System.Drawing.Size(88, 49)
        Me.cmdundo.TabIndex = 5
        Me.cmdundo.Text = "&Undo"
        Me.cmdundo.UseVisualStyleBackColor = False
        '
        'cmdnormal
        '
        Me.cmdnormal.BackColor = System.Drawing.SystemColors.Control
        Me.cmdnormal.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdnormal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdnormal.Location = New System.Drawing.Point(384, 560)
        Me.cmdnormal.Name = "cmdnormal"
        Me.cmdnormal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdnormal.Size = New System.Drawing.Size(88, 41)
        Me.cmdnormal.TabIndex = 20
        Me.cmdnormal.Text = "Back To &Default"
        Me.cmdnormal.UseVisualStyleBackColor = False
        '
        'cmbpos
        '
        Me.cmbpos.BackColor = System.Drawing.SystemColors.Window
        Me.cmbpos.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbpos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbpos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbpos.Items.AddRange(New Object() {"Second Row", "Third Row", "Fourth Row", "Fifth Row", "Sixth Row", "Seventh Row", "Eight Row"})
        Me.cmbpos.Location = New System.Drawing.Point(248, 560)
        Me.cmbpos.Name = "cmbpos"
        Me.cmbpos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbpos.Size = New System.Drawing.Size(65, 21)
        Me.cmbpos.TabIndex = 18
        Me.cmbpos.Text = "First Row"
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdadd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdadd.Location = New System.Drawing.Point(368, 464)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdadd.Size = New System.Drawing.Size(88, 49)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&Save Design"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(472, 464)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(88, 49)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "&Apply Changes"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(32, 464)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(88, 49)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "&Back"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'HSHeight
        '
        Me.HSHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.HSHeight.LargeChange = 5
        Me.HSHeight.Location = New System.Drawing.Point(144, 48)
        Me.HSHeight.Maximum = 82
        Me.HSHeight.Minimum = 10
        Me.HSHeight.Name = "HSHeight"
        Me.HSHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HSHeight.Size = New System.Drawing.Size(112, 19)
        Me.HSHeight.TabIndex = 4
        Me.HSHeight.TabStop = True
        Me.HSHeight.Value = 30
        '
        'HSselect
        '
        Me.HSselect.Cursor = System.Windows.Forms.Cursors.Default
        Me.HSselect.LargeChange = 500
        Me.HSselect.Location = New System.Drawing.Point(32, 384)
        Me.HSselect.Maximum = 33266
        Me.HSselect.Name = "HSselect"
        Me.HSselect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HSselect.Size = New System.Drawing.Size(531, 22)
        Me.HSselect.SmallChange = 100
        Me.HSselect.TabIndex = 16
        Me.HSselect.TabStop = True
        '
        'picOuter
        '
        Me.picOuter.BackColor = System.Drawing.SystemColors.Control
        Me.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picOuter.Controls.Add(Me.picInner)
        Me.picOuter.Cursor = System.Windows.Forms.Cursors.Default
        Me.picOuter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picOuter.Location = New System.Drawing.Point(32, 88)
        Me.picOuter.Name = "picOuter"
        Me.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picOuter.Size = New System.Drawing.Size(531, 297)
        Me.picOuter.TabIndex = 14
        Me.picOuter.TabStop = True
        '
        'picInner
        '
        Me.picInner.BackColor = System.Drawing.SystemColors.Control
        Me.picInner.Controls.Add(Me._picSelect_0)
        Me.picInner.Cursor = System.Windows.Forms.Cursors.Default
        Me.picInner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picInner.Location = New System.Drawing.Point(0, 0)
        Me.picInner.Name = "picInner"
        Me.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picInner.Size = New System.Drawing.Size(533, 204)
        Me.picInner.TabIndex = 6
        Me.picInner.TabStop = True
        '
        '_picSelect_0
        '
        Me._picSelect_0.BackColor = System.Drawing.SystemColors.Window
        Me._picSelect_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._picSelect_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._picSelect_0.Location = New System.Drawing.Point(0, 0)
        Me._picSelect_0.Name = "_picSelect_0"
        Me._picSelect_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picSelect_0.Size = New System.Drawing.Size(118, 142)
        Me._picSelect_0.TabIndex = 15
        '
        'HSWidth
        '
        Me.HSWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.HSWidth.LargeChange = 5
        Me.HSWidth.Location = New System.Drawing.Point(16, 48)
        Me.HSWidth.Maximum = 204
        Me.HSWidth.Minimum = 10
        Me.HSWidth.Name = "HSWidth"
        Me.HSWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HSWidth.Size = New System.Drawing.Size(104, 19)
        Me.HSWidth.TabIndex = 3
        Me.HSWidth.TabStop = True
        Me.HSWidth.Value = 40
        '
        '_lbl_7
        '
        Me._lbl_7.AutoSize = True
        Me._lbl_7.BackColor = System.Drawing.Color.Transparent
        Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_7.Location = New System.Drawing.Point(512, 32)
        Me._lbl_7.Name = "_lbl_7"
        Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_7.Size = New System.Drawing.Size(23, 13)
        Me._lbl_7.TabIndex = 30
        Me._lbl_7.Text = "mm"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = True
        Me.lblLeft.BackColor = System.Drawing.Color.Transparent
        Me.lblLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLeft.Location = New System.Drawing.Point(480, 32)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLeft.Size = New System.Drawing.Size(13, 13)
        Me.lblLeft.TabIndex = 29
        Me.lblLeft.Text = "0"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_6
        '
        Me._lbl_6.AutoSize = True
        Me._lbl_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_6.Location = New System.Drawing.Point(416, 32)
        Me._lbl_6.Name = "_lbl_6"
        Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_6.Size = New System.Drawing.Size(60, 13)
        Me._lbl_6.TabIndex = 28
        Me._lbl_6.Text = "Left Margin"
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(376, 32)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(23, 13)
        Me._lbl_5.TabIndex = 25
        Me._lbl_5.Text = "mm"
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.BackColor = System.Drawing.Color.Transparent
        Me.lblTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTop.Location = New System.Drawing.Point(344, 32)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTop.Size = New System.Drawing.Size(13, 13)
        Me.lblTop.TabIndex = 24
        Me.lblTop.Text = "0"
        Me.lblTop.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_4
        '
        Me._lbl_4.AutoSize = True
        Me._lbl_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_4.Location = New System.Drawing.Point(280, 32)
        Me._lbl_4.Name = "_lbl_4"
        Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_4.Size = New System.Drawing.Size(61, 13)
        Me._lbl_4.TabIndex = 23
        Me._lbl_4.Text = "Top Margin"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(425, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "The Numbers from (1 to 23) on the left side is the row position where your field " & _
    "will appear."
        '
        'lblLineNo
        '
        Me.lblLineNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblLineNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLineNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLineNo.Location = New System.Drawing.Point(16, 88)
        Me.lblLineNo.Name = "lblLineNo"
        Me.lblLineNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLineNo.Size = New System.Drawing.Size(17, 297)
        Me.lblLineNo.TabIndex = 21
        Me.lblLineNo.Text = "1- 2- 3- 4-  5- 6- 7- 8- 9- 10- 11- 12- 13- 14- 15- 16- 17- 18- 19- 20- 21- 22- 2" & _
    "3-"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(544, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(169, 17)
        Me.Label7.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Design Name:"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWidth.Location = New System.Drawing.Point(80, 32)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWidth.Size = New System.Drawing.Size(19, 13)
        Me.lblWidth.TabIndex = 13
        Me.lblWidth.Text = "50"
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_0
        '
        Me._lbl_0.AutoSize = True
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(104, 32)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(23, 13)
        Me._lbl_0.TabIndex = 12
        Me._lbl_0.Text = "mm"
        '
        '_lbl_1
        '
        Me._lbl_1.AutoSize = True
        Me._lbl_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_1.Location = New System.Drawing.Point(16, 32)
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.Size = New System.Drawing.Size(64, 13)
        Me._lbl_1.TabIndex = 11
        Me._lbl_1.Text = "Label Width"
        '
        '_lbl_2
        '
        Me._lbl_2.AutoSize = True
        Me._lbl_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(144, 32)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(67, 13)
        Me._lbl_2.TabIndex = 10
        Me._lbl_2.Text = "Label Height"
        '
        '_lbl_3
        '
        Me._lbl_3.AutoSize = True
        Me._lbl_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Location = New System.Drawing.Point(240, 32)
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.Size = New System.Drawing.Size(23, 13)
        Me._lbl_3.TabIndex = 9
        Me._lbl_3.Text = "mm"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeight.Location = New System.Drawing.Point(216, 32)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeight.Size = New System.Drawing.Size(13, 13)
        Me.lblHeight.TabIndex = 8
        Me.lblHeight.Text = "0"
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbldesign
        '
        Me.lbldesign.AutoSize = True
        Me.lbldesign.BackColor = System.Drawing.Color.Transparent
        Me.lbldesign.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbldesign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbldesign.Location = New System.Drawing.Point(144, 3)
        Me.lbldesign.Name = "lbldesign"
        Me.lbldesign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbldesign.Size = New System.Drawing.Size(39, 13)
        Me.lbldesign.TabIndex = 7
        Me.lbldesign.Text = "Label1"
        '
        'frmBarcodeLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(726, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.frmDeposits)
        Me.Controls.Add(Me.HSLeft)
        Me.Controls.Add(Me.HSTop)
        Me.Controls.Add(Me.cmdundo)
        Me.Controls.Add(Me.cmdnormal)
        Me.Controls.Add(Me.cmbpos)
        Me.Controls.Add(Me.cmdadd)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.HSHeight)
        Me.Controls.Add(Me.HSselect)
        Me.Controls.Add(Me.picOuter)
        Me.Controls.Add(Me.HSWidth)
        Me.Controls.Add(Me._lbl_7)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me._lbl_6)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me._lbl_4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblLineNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me._lbl_1)
        Me.Controls.Add(Me._lbl_2)
        Me.Controls.Add(Me._lbl_3)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lbldesign)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBarcodeLoad"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barcode Designing"
        Me.Frame1.ResumeLayout(False)
        Me.frmDeposits.ResumeLayout(False)
        Me.picOuter.ResumeLayout(False)
        Me.picInner.ResumeLayout(False)
        CType(Me._picSelect_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class