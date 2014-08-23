<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOrder
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
	Public WithEvents _cmdInformation_1 As System.Windows.Forms.Button
	Public WithEvents _cmdInformation_0 As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdBlank As System.Windows.Forms.Button
	Public WithEvents cmdAuto As System.Windows.Forms.Button
	Public WithEvents _lblData_7 As System.Windows.Forms.Label
	Public WithEvents _lblData_6 As System.Windows.Forms.Label
	Public WithEvents _lblData_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_36 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_37 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _lblData_0 As System.Windows.Forms.Label
	Public WithEvents _lblData_1 As System.Windows.Forms.Label
	Public WithEvents _lblData_2 As System.Windows.Forms.Label
	Public WithEvents _lblData_3 As System.Windows.Forms.Label
	Public WithEvents _lblData_4 As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents DataList1 As myDataGridView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _frmMode_0 As System.Windows.Forms.GroupBox
    'Public WithEvents cmdInformation As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblData As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As OvalShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrder))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._cmdInformation_1 = New System.Windows.Forms.Button
		Me._cmdInformation_0 = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me._frmMode_1 = New System.Windows.Forms.GroupBox
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdBlank = New System.Windows.Forms.Button
		Me.cmdAuto = New System.Windows.Forms.Button
		Me._lblData_7 = New System.Windows.Forms.Label
		Me._lblData_6 = New System.Windows.Forms.Label
		Me._lblData_5 = New System.Windows.Forms.Label
		Me._lblLabels_36 = New System.Windows.Forms.Label
		Me._lblLabels_37 = New System.Windows.Forms.Label
		Me._lblLabels_38 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_6 = New System.Windows.Forms.Label
		Me._lblLabels_7 = New System.Windows.Forms.Label
		Me._lblLabels_8 = New System.Windows.Forms.Label
		Me._lblLabels_9 = New System.Windows.Forms.Label
		Me._lblData_0 = New System.Windows.Forms.Label
		Me._lblData_1 = New System.Windows.Forms.Label
		Me._lblData_2 = New System.Windows.Forms.Label
		Me._lblData_3 = New System.Windows.Forms.Label
		Me._lblData_4 = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._frmMode_0 = New System.Windows.Forms.GroupBox
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.DataList1 = New myDataGridView
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.cmdInformation = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblData = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New OvalShapeArray(components)
		Me._frmMode_1.SuspendLayout()
		Me._frmMode_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cmdInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblData, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Create / Amend an Order"
		Me.ClientSize = New System.Drawing.Size(362, 472)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmOrder"
		Me._cmdInformation_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdInformation_1.Text = "Order Information Report(*)"
		Me._cmdInformation_1.Size = New System.Drawing.Size(166, 31)
		Me._cmdInformation_1.Location = New System.Drawing.Point(186, 6)
		Me._cmdInformation_1.TabIndex = 28
		Me._cmdInformation_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdInformation_1.CausesValidation = True
		Me._cmdInformation_1.Enabled = True
		Me._cmdInformation_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdInformation_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdInformation_1.TabStop = True
		Me._cmdInformation_1.Name = "_cmdInformation_1"
		Me._cmdInformation_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdInformation_0.Text = "Order Information Report"
		Me._cmdInformation_0.Size = New System.Drawing.Size(166, 31)
		Me._cmdInformation_0.Location = New System.Drawing.Point(6, 6)
		Me._cmdInformation_0.TabIndex = 27
		Me._cmdInformation_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdInformation_0.CausesValidation = True
		Me._cmdInformation_0.Enabled = True
		Me._cmdInformation_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdInformation_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdInformation_0.TabStop = True
		Me._cmdInformation_0.Name = "_cmdInformation_0"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Size = New System.Drawing.Size(97, 34)
		Me.cmdNext.Location = New System.Drawing.Point(246, 435)
		Me.cmdNext.TabIndex = 1
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "E&xit"
		Me.cmdBack.Size = New System.Drawing.Size(97, 34)
		Me.cmdBack.Location = New System.Drawing.Point(15, 435)
		Me.cmdBack.TabIndex = 0
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me._frmMode_1.Text = "Select a supplier to transact with."
		Me._frmMode_1.Size = New System.Drawing.Size(346, 379)
		Me._frmMode_1.Location = New System.Drawing.Point(6, 45)
		Me._frmMode_1.TabIndex = 6
		Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_1.Enabled = True
		Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_1.Visible = True
		Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_1.Name = "_frmMode_1"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Edit Current Order"
		Me.cmdEdit.Size = New System.Drawing.Size(97, 52)
		Me.cmdEdit.Location = New System.Drawing.Point(9, 318)
		Me.cmdEdit.TabIndex = 29
		Me.cmdEdit.TabStop = False
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdBlank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBlank.Text = "&Create a Blank Order"
		Me.cmdBlank.Size = New System.Drawing.Size(97, 52)
		Me.cmdBlank.Location = New System.Drawing.Point(126, 318)
		Me.cmdBlank.TabIndex = 26
		Me.cmdBlank.TabStop = False
		Me.cmdBlank.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBlank.CausesValidation = True
		Me.cmdBlank.Enabled = True
		Me.cmdBlank.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBlank.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBlank.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBlank.Name = "cmdBlank"
		Me.cmdAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAuto.Text = "Create &Recommended Order"
		Me.cmdAuto.Size = New System.Drawing.Size(97, 52)
		Me.cmdAuto.Location = New System.Drawing.Point(240, 318)
		Me.cmdAuto.TabIndex = 25
		Me.cmdAuto.TabStop = False
		Me.cmdAuto.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAuto.CausesValidation = True
		Me.cmdAuto.Enabled = True
		Me.cmdAuto.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAuto.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAuto.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAuto.Name = "cmdAuto"
		Me._lblData_7.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_7.Text = "Supplier_ShippingCode"
		Me._lblData_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_7.Size = New System.Drawing.Size(190, 16)
		Me._lblData_7.Location = New System.Drawing.Point(141, 267)
		Me._lblData_7.TabIndex = 24
		Me._lblData_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_7.Enabled = True
		Me._lblData_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_7.UseMnemonic = True
		Me._lblData_7.Visible = True
		Me._lblData_7.AutoSize = False
		Me._lblData_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_7.Name = "_lblData_7"
		Me._lblData_6.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_6.Text = "Supplier_RepresentativeNumber"
		Me._lblData_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_6.Size = New System.Drawing.Size(190, 16)
		Me._lblData_6.Location = New System.Drawing.Point(141, 249)
		Me._lblData_6.TabIndex = 23
		Me._lblData_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_6.Enabled = True
		Me._lblData_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_6.UseMnemonic = True
		Me._lblData_6.Visible = True
		Me._lblData_6.AutoSize = False
		Me._lblData_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_6.Name = "_lblData_6"
		Me._lblData_5.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_5.Text = "Supplier_RepresentativeName"
		Me._lblData_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_5.Size = New System.Drawing.Size(190, 16)
		Me._lblData_5.Location = New System.Drawing.Point(141, 231)
		Me._lblData_5.TabIndex = 22
		Me._lblData_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_5.Enabled = True
		Me._lblData_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_5.UseMnemonic = True
		Me._lblData_5.Visible = True
		Me._lblData_5.AutoSize = False
		Me._lblData_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_5.Name = "_lblData_5"
		Me._lblLabels_36.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_36.Text = "Account Number:"
		Me._lblLabels_36.Size = New System.Drawing.Size(83, 13)
		Me._lblLabels_36.Location = New System.Drawing.Point(50, 267)
		Me._lblLabels_36.TabIndex = 21
		Me._lblLabels_36.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_36.Enabled = True
		Me._lblLabels_36.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_36.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_36.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_36.UseMnemonic = True
		Me._lblLabels_36.Visible = True
		Me._lblLabels_36.AutoSize = True
		Me._lblLabels_36.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_36.Name = "_lblLabels_36"
		Me._lblLabels_37.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_37.Text = "Representative Number:"
		Me._lblLabels_37.Size = New System.Drawing.Size(115, 13)
		Me._lblLabels_37.Location = New System.Drawing.Point(18, 248)
		Me._lblLabels_37.TabIndex = 20
		Me._lblLabels_37.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_37.Enabled = True
		Me._lblLabels_37.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_37.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_37.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_37.UseMnemonic = True
		Me._lblLabels_37.Visible = True
		Me._lblLabels_37.AutoSize = True
		Me._lblLabels_37.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_37.Name = "_lblLabels_37"
		Me._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_38.Text = "Representative Name:"
		Me._lblLabels_38.Size = New System.Drawing.Size(106, 13)
		Me._lblLabels_38.Location = New System.Drawing.Point(27, 230)
		Me._lblLabels_38.TabIndex = 19
		Me._lblLabels_38.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_38.Enabled = True
		Me._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_38.UseMnemonic = True
		Me._lblLabels_38.Visible = True
		Me._lblLabels_38.AutoSize = True
		Me._lblLabels_38.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_38.Name = "_lblLabels_38"
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Text = "&2. Ordering Details"
		Me._lbl_2.Size = New System.Drawing.Size(107, 13)
		Me._lbl_2.Location = New System.Drawing.Point(9, 207)
		Me._lbl_2.TabIndex = 18
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Text = "&1. General"
		Me._lbl_1.Size = New System.Drawing.Size(61, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 18)
		Me._lbl_1.TabIndex = 17
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.Text = "Supplier Name:"
		Me._lblLabels_2.Size = New System.Drawing.Size(87, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(13, 39)
		Me._lblLabels_2.TabIndex = 16
		Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_2.Enabled = True
		Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_2.UseMnemonic = True
		Me._lblLabels_2.Visible = True
		Me._lblLabels_2.AutoSize = True
		Me._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_2.Name = "_lblLabels_2"
		Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_6.Text = "Physical Address:"
		Me._lblLabels_6.Size = New System.Drawing.Size(94, 13)
		Me._lblLabels_6.Location = New System.Drawing.Point(6, 78)
		Me._lblLabels_6.TabIndex = 15
		Me._lblLabels_6.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_6.Enabled = True
		Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_6.UseMnemonic = True
		Me._lblLabels_6.Visible = True
		Me._lblLabels_6.AutoSize = True
		Me._lblLabels_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_6.Name = "_lblLabels_6"
		Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_7.Text = "Postal Address:"
		Me._lblLabels_7.Size = New System.Drawing.Size(76, 13)
		Me._lblLabels_7.Location = New System.Drawing.Point(24, 138)
		Me._lblLabels_7.TabIndex = 14
		Me._lblLabels_7.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_7.Enabled = True
		Me._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_7.UseMnemonic = True
		Me._lblLabels_7.Visible = True
		Me._lblLabels_7.AutoSize = True
		Me._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_7.Name = "_lblLabels_7"
		Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_8.Text = "Telephone:"
		Me._lblLabels_8.Size = New System.Drawing.Size(55, 13)
		Me._lblLabels_8.Location = New System.Drawing.Point(42, 57)
		Me._lblLabels_8.TabIndex = 13
		Me._lblLabels_8.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_8.Enabled = True
		Me._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_8.UseMnemonic = True
		Me._lblLabels_8.Visible = True
		Me._lblLabels_8.AutoSize = True
		Me._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_8.Name = "_lblLabels_8"
		Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_9.Text = "Fax:"
		Me._lblLabels_9.Size = New System.Drawing.Size(22, 13)
		Me._lblLabels_9.Location = New System.Drawing.Point(210, 57)
		Me._lblLabels_9.TabIndex = 12
		Me._lblLabels_9.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_9.Enabled = True
		Me._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_9.UseMnemonic = True
		Me._lblLabels_9.Visible = True
		Me._lblLabels_9.AutoSize = True
		Me._lblLabels_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_9.Name = "_lblLabels_9"
		Me._lblData_0.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_0.Text = "Supplier_Name"
		Me._lblData_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_0.Size = New System.Drawing.Size(226, 16)
		Me._lblData_0.Location = New System.Drawing.Point(105, 39)
		Me._lblData_0.TabIndex = 11
		Me._lblData_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_0.Enabled = True
		Me._lblData_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_0.UseMnemonic = True
		Me._lblData_0.Visible = True
		Me._lblData_0.AutoSize = False
		Me._lblData_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_0.Name = "_lblData_0"
		Me._lblData_1.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_1.Text = "Supplier_Telephone"
		Me._lblData_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_1.Size = New System.Drawing.Size(94, 16)
		Me._lblData_1.Location = New System.Drawing.Point(105, 57)
		Me._lblData_1.TabIndex = 10
		Me._lblData_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_1.Enabled = True
		Me._lblData_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_1.UseMnemonic = True
		Me._lblData_1.Visible = True
		Me._lblData_1.AutoSize = False
		Me._lblData_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_1.Name = "_lblData_1"
		Me._lblData_2.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_2.Text = "Supplier_Facimile"
		Me._lblData_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_2.Size = New System.Drawing.Size(94, 16)
		Me._lblData_2.Location = New System.Drawing.Point(237, 57)
		Me._lblData_2.TabIndex = 9
		Me._lblData_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_2.Enabled = True
		Me._lblData_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_2.UseMnemonic = True
		Me._lblData_2.Visible = True
		Me._lblData_2.AutoSize = False
		Me._lblData_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_2.Name = "_lblData_2"
		Me._lblData_3.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_3.Text = "Supplier_PhysicalAddress"
		Me._lblData_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_3.Size = New System.Drawing.Size(226, 58)
		Me._lblData_3.Location = New System.Drawing.Point(105, 78)
		Me._lblData_3.TabIndex = 8
		Me._lblData_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_3.Enabled = True
		Me._lblData_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_3.UseMnemonic = True
		Me._lblData_3.Visible = True
		Me._lblData_3.AutoSize = False
		Me._lblData_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_3.Name = "_lblData_3"
		Me._lblData_4.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_4.Text = "Supplier_PostalAddress"
		Me._lblData_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_4.Size = New System.Drawing.Size(226, 58)
		Me._lblData_4.Location = New System.Drawing.Point(105, 141)
		Me._lblData_4.TabIndex = 7
		Me._lblData_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_4.Enabled = True
		Me._lblData_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_4.UseMnemonic = True
		Me._lblData_4.Visible = True
		Me._lblData_4.AutoSize = False
		Me._lblData_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_4.Name = "_lblData_4"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(328, 172)
		Me._Shape1_1.Location = New System.Drawing.Point(9, 20)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(328, 70)
		Me._Shape1_2.Location = New System.Drawing.Point(9, 209)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me._frmMode_0.Text = "Select a supplier to transact with."
		Me._frmMode_0.Size = New System.Drawing.Size(346, 379)
		Me._frmMode_0.Location = New System.Drawing.Point(6, 48)
		Me._frmMode_0.TabIndex = 2
		Me._frmMode_0.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_0.Enabled = True
		Me._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_0.Visible = True
		Me._frmMode_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_0.Name = "_frmMode_0"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(283, 19)
		Me.txtSearch.Location = New System.Drawing.Point(54, 18)
		Me.txtSearch.TabIndex = 3
		Me.txtSearch.AcceptsReturn = True
		Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch.CausesValidation = True
		Me.txtSearch.Enabled = True
		Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch.HideSelection = True
		Me.txtSearch.ReadOnly = False
		Me.txtSearch.Maxlength = 0
		Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch.MultiLine = False
		Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch.TabStop = True
		Me.txtSearch.Visible = True
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch.Name = "txtSearch"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(328, 329)
		Me.DataList1.Location = New System.Drawing.Point(9, 42)
		Me.DataList1.TabIndex = 4
		Me.DataList1.Name = "DataList1"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "&Search :"
		Me._lbl_0.Size = New System.Drawing.Size(40, 13)
		Me._lbl_0.Location = New System.Drawing.Point(11, 21)
		Me._lbl_0.TabIndex = 5
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.Controls.Add(_cmdInformation_1)
		Me.Controls.Add(_cmdInformation_0)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdBack)
		Me.Controls.Add(_frmMode_1)
		Me.Controls.Add(_frmMode_0)
		Me._frmMode_1.Controls.Add(cmdEdit)
		Me._frmMode_1.Controls.Add(cmdBlank)
		Me._frmMode_1.Controls.Add(cmdAuto)
		Me._frmMode_1.Controls.Add(_lblData_7)
		Me._frmMode_1.Controls.Add(_lblData_6)
		Me._frmMode_1.Controls.Add(_lblData_5)
		Me._frmMode_1.Controls.Add(_lblLabels_36)
		Me._frmMode_1.Controls.Add(_lblLabels_37)
		Me._frmMode_1.Controls.Add(_lblLabels_38)
		Me._frmMode_1.Controls.Add(_lbl_2)
		Me._frmMode_1.Controls.Add(_lbl_1)
		Me._frmMode_1.Controls.Add(_lblLabels_2)
		Me._frmMode_1.Controls.Add(_lblLabels_6)
		Me._frmMode_1.Controls.Add(_lblLabels_7)
		Me._frmMode_1.Controls.Add(_lblLabels_8)
		Me._frmMode_1.Controls.Add(_lblLabels_9)
		Me._frmMode_1.Controls.Add(_lblData_0)
		Me._frmMode_1.Controls.Add(_lblData_1)
		Me._frmMode_1.Controls.Add(_lblData_2)
		Me._frmMode_1.Controls.Add(_lblData_3)
		Me._frmMode_1.Controls.Add(_lblData_4)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me._frmMode_1.Controls.Add(ShapeContainer1)
		Me._frmMode_0.Controls.Add(txtSearch)
		Me._frmMode_0.Controls.Add(DataList1)
		Me._frmMode_0.Controls.Add(_lbl_0)
        'Me.cmdInformation.SetIndex(_cmdInformation_1, CType(1, Short))
        'Me.cmdInformation.SetIndex(_cmdInformation_0, CType(0, Short))
        'Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
        'Me.frmMode.SetIndex(_frmMode_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lblData.SetIndex(_lblData_7, CType(7, Short))
        'Me.lblData.SetIndex(_lblData_6, CType(6, Short))
        'Me.lblData.SetIndex(_lblData_5, CType(5, Short))
        'Me.lblData.SetIndex(_lblData_0, CType(0, Short))
        'Me.lblData.SetIndex(_lblData_1, CType(1, Short))
        'M() ''e.lblData.SetIndex(_lblData_2, CType(2, Short))
        'M() 'e.lblData.SetIndex(_lblData_3, CType(3, Short))
        'Me.lblData.SetIndex(_lblData_4, CType(4, Short))
        'Me.lblLabels.SetIndex(_lblLabels_36, CType(36, Short))
        'Me.lblLabels.SetIndex(_lblLabels_37, CType(37, Short))
        'Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
        'Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
        'Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
        'Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
        'Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
        'Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblData, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdInformation, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmMode_1.ResumeLayout(False)
		Me._frmMode_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class