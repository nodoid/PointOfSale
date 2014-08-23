<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockfromFile
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
	Public WithEvents txtFile As System.Windows.Forms.TextBox
	Public WithEvents prgStockItem As System.Windows.Forms.ProgressBar
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog1Font As System.Windows.Forms.FontDialog
	Public CommonDialog1Color As System.Windows.Forms.ColorDialog
	Public CommonDialog1Print As System.Windows.Forms.PrintDialog
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents txtName As System.Windows.Forms.TextBox
	Public WithEvents txtReceipt As System.Windows.Forms.TextBox
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents txtCost As System.Windows.Forms.TextBox
    Public WithEvents cmbShrink As myDataGridView
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_10 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmbPricingGroup As myDataGridView
    Public WithEvents cmbStockGroup As myDataGridView
    Public WithEvents cmbDeposit As myDataGridView
    Public WithEvents cmbSupplier As myDataGridView
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
    'Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockfromFile))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.txtFile = New System.Windows.Forms.TextBox
		Me.prgStockItem = New System.Windows.Forms.ProgressBar
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
		Me.CommonDialog1Font = New System.Windows.Forms.FontDialog
		Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog
		Me.CommonDialog1Print = New System.Windows.Forms.PrintDialog
		Me._frmMode_1 = New System.Windows.Forms.GroupBox
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.txtName = New System.Windows.Forms.TextBox
		Me.txtReceipt = New System.Windows.Forms.TextBox
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me.txtCost = New System.Windows.Forms.TextBox
        Me.cmbShrink = New myDataGridView
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_10 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.cmbPricingGroup = New myDataGridView
        Me.cmbStockGroup = New myDataGridView
        Me.cmbDeposit = New myDataGridView
        Me.cmbSupplier = New myDataGridView
		Me._lblLabels_6 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_3 = New System.Windows.Forms.Label
		Me._lblLabels_4 = New System.Windows.Forms.Label
		Me._lblLabels_7 = New System.Windows.Forms.Label
		Me._lblLabels_8 = New System.Windows.Forms.Label
        'Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Frame2.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me._frmMode_1.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Adding Stock Items"
		Me.ClientSize = New System.Drawing.Size(528, 170)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockfromFile"
		Me.Frame2.Size = New System.Drawing.Size(515, 99)
		Me.Frame2.Location = New System.Drawing.Point(6, 62)
		Me.Frame2.TabIndex = 24
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.txtFile.AutoSize = False
		Me.txtFile.Enabled = False
		Me.txtFile.Size = New System.Drawing.Size(403, 19)
		Me.txtFile.Location = New System.Drawing.Point(104, 12)
		Me.txtFile.TabIndex = 26
		Me.txtFile.AcceptsReturn = True
		Me.txtFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFile.BackColor = System.Drawing.SystemColors.Window
		Me.txtFile.CausesValidation = True
		Me.txtFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFile.HideSelection = True
		Me.txtFile.ReadOnly = False
		Me.txtFile.Maxlength = 0
		Me.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFile.MultiLine = False
		Me.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFile.TabStop = True
		Me.txtFile.Visible = True
		Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtFile.Name = "txtFile"
		Me.prgStockItem.Size = New System.Drawing.Size(495, 21)
		Me.prgStockItem.Location = New System.Drawing.Point(14, 34)
		Me.prgStockItem.TabIndex = 25
		Me.prgStockItem.Maximum = 10000
		Me.prgStockItem.Name = "prgStockItem"
		Me.Label1.Text = "File Name: "
		Me.Label1.Size = New System.Drawing.Size(81, 17)
		Me.Label1.Location = New System.Drawing.Point(20, 12)
		Me.Label1.TabIndex = 28
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = ":"
		Me.Label2.Size = New System.Drawing.Size(295, 23)
		Me.Label2.Location = New System.Drawing.Point(212, 60)
		Me.Label2.TabIndex = 27
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(528, 53)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 21
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Do Update>>"
		Me.cmdNext.Size = New System.Drawing.Size(96, 33)
		Me.cmdNext.Location = New System.Drawing.Point(420, 6)
		Me.cmdNext.TabIndex = 23
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
		Me.cmdBack.Size = New System.Drawing.Size(97, 33)
		Me.cmdBack.Location = New System.Drawing.Point(8, 6)
		Me.cmdBack.TabIndex = 22
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me._frmMode_1.Text = "New ""Stock Item"" Details."
		Me._frmMode_1.Enabled = False
		Me._frmMode_1.Size = New System.Drawing.Size(331, 263)
		Me._frmMode_1.Location = New System.Drawing.Point(-2, 506)
		Me._frmMode_1.TabIndex = 0
		Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_1.Visible = True
		Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_1.Name = "_frmMode_1"
		Me.Picture1.Size = New System.Drawing.Size(295, 4)
		Me.Picture1.Location = New System.Drawing.Point(28, 162)
		Me.Picture1.TabIndex = 10
		Me.Picture1.TabStop = False
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.BackColor = System.Drawing.SystemColors.Control
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.txtName.AutoSize = False
		Me.txtName.Size = New System.Drawing.Size(241, 19)
		Me.txtName.Location = New System.Drawing.Point(82, 18)
		Me.txtName.TabIndex = 9
		Me.txtName.Text = "[New Product]"
		Me.txtName.AcceptsReturn = True
		Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtName.BackColor = System.Drawing.SystemColors.Window
		Me.txtName.CausesValidation = True
		Me.txtName.Enabled = True
		Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtName.HideSelection = True
		Me.txtName.ReadOnly = False
		Me.txtName.Maxlength = 0
		Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtName.MultiLine = False
		Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtName.TabStop = True
		Me.txtName.Visible = True
		Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtName.Name = "txtName"
		Me.txtReceipt.AutoSize = False
		Me.txtReceipt.Size = New System.Drawing.Size(241, 19)
		Me.txtReceipt.Location = New System.Drawing.Point(82, 39)
		Me.txtReceipt.Maxlength = 20
		Me.txtReceipt.TabIndex = 8
		Me.txtReceipt.AcceptsReturn = True
		Me.txtReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtReceipt.BackColor = System.Drawing.SystemColors.Window
		Me.txtReceipt.CausesValidation = True
		Me.txtReceipt.Enabled = True
		Me.txtReceipt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtReceipt.HideSelection = True
		Me.txtReceipt.ReadOnly = False
		Me.txtReceipt.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtReceipt.MultiLine = False
		Me.txtReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtReceipt.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtReceipt.TabStop = True
		Me.txtReceipt.Visible = True
		Me.txtReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtReceipt.Name = "txtReceipt"
		Me.Frame1.Size = New System.Drawing.Size(317, 57)
		Me.Frame1.Location = New System.Drawing.Point(8, 168)
		Me.Frame1.TabIndex = 1
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(28, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(56, 12)
		Me.txtQuantity.TabIndex = 3
		Me.txtQuantity.Text = "12"
		Me.txtQuantity.AcceptsReturn = True
		Me.txtQuantity.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantity.CausesValidation = True
		Me.txtQuantity.Enabled = True
		Me.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantity.HideSelection = True
		Me.txtQuantity.ReadOnly = False
		Me.txtQuantity.Maxlength = 0
		Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantity.MultiLine = False
		Me.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantity.TabStop = True
		Me.txtQuantity.Visible = True
		Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtQuantity.Name = "txtQuantity"
		Me.txtCost.AutoSize = False
		Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtCost.Size = New System.Drawing.Size(56, 19)
		Me.txtCost.Location = New System.Drawing.Point(256, 14)
		Me.txtCost.TabIndex = 2
		Me.txtCost.Text = "0.00"
		Me.txtCost.AcceptsReturn = True
		Me.txtCost.BackColor = System.Drawing.SystemColors.Window
		Me.txtCost.CausesValidation = True
		Me.txtCost.Enabled = True
		Me.txtCost.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCost.HideSelection = True
		Me.txtCost.ReadOnly = False
		Me.txtCost.Maxlength = 0
		Me.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCost.MultiLine = False
		Me.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCost.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCost.TabStop = True
		Me.txtCost.Visible = True
		Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtCost.Name = "txtCost"
        'cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbShrink.Size = New System.Drawing.Size(91, 21)
		Me.cmbShrink.Location = New System.Drawing.Point(134, 30)
		Me.cmbShrink.TabIndex = 4
		Me.cmbShrink.Name = "cmbShrink"
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.Text = "There are "
		Me._lblLabels_2.Size = New System.Drawing.Size(49, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(6, 16)
		Me._lblLabels_2.TabIndex = 7
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
		Me._lblLabels_10.Text = "Units in a case/carton, which costs"
		Me._lblLabels_10.Size = New System.Drawing.Size(167, 13)
		Me._lblLabels_10.Location = New System.Drawing.Point(86, 16)
		Me._lblLabels_10.TabIndex = 6
		Me._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_10.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_10.Enabled = True
		Me._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_10.UseMnemonic = True
		Me._lblLabels_10.Visible = True
		Me._lblLabels_10.AutoSize = True
		Me._lblLabels_10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_10.Name = "_lblLabels_10"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.Text = "and you sell in shrinks of"
		Me._lblLabels_1.Size = New System.Drawing.Size(115, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(8, 38)
		Me._lblLabels_1.TabIndex = 5
		Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_1.Enabled = True
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_1.UseMnemonic = True
		Me._lblLabels_1.Visible = True
		Me._lblLabels_1.AutoSize = True
		Me._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_1.Name = "_lblLabels_1"
        'cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPricingGroup.Size = New System.Drawing.Size(241, 21)
		Me.cmbPricingGroup.Location = New System.Drawing.Point(82, 108)
		Me.cmbPricingGroup.TabIndex = 11
		Me.cmbPricingGroup.Name = "cmbPricingGroup"
        'cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbStockGroup.Size = New System.Drawing.Size(241, 21)
		Me.cmbStockGroup.Location = New System.Drawing.Point(82, 132)
		Me.cmbStockGroup.TabIndex = 12
		Me.cmbStockGroup.Name = "cmbStockGroup"
        'cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbDeposit.Size = New System.Drawing.Size(241, 21)
		Me.cmbDeposit.Location = New System.Drawing.Point(82, 84)
		Me.cmbDeposit.TabIndex = 13
		Me.cmbDeposit.Name = "cmbDeposit"
        'cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbSupplier.Size = New System.Drawing.Size(241, 21)
		Me.cmbSupplier.Location = New System.Drawing.Point(82, 60)
		Me.cmbSupplier.TabIndex = 14
		Me.cmbSupplier.Name = "cmbSupplier"
		Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_6.Text = "Deposit:"
		Me._lblLabels_6.Size = New System.Drawing.Size(39, 13)
		Me._lblLabels_6.Location = New System.Drawing.Point(38, 90)
		Me._lblLabels_6.TabIndex = 20
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
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.Text = "Supplier:"
		Me._lblLabels_0.Size = New System.Drawing.Size(41, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(36, 66)
		Me._lblLabels_0.TabIndex = 19
		Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.Visible = True
		Me._lblLabels_0.AutoSize = True
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_3.Text = "Pricing Group:"
		Me._lblLabels_3.Size = New System.Drawing.Size(67, 13)
		Me._lblLabels_3.Location = New System.Drawing.Point(10, 114)
		Me._lblLabels_3.TabIndex = 18
		Me._lblLabels_3.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_3.Enabled = True
		Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_3.UseMnemonic = True
		Me._lblLabels_3.Visible = True
		Me._lblLabels_3.AutoSize = True
		Me._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_3.Name = "_lblLabels_3"
		Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_4.Text = "Stock Group:"
		Me._lblLabels_4.Size = New System.Drawing.Size(63, 13)
		Me._lblLabels_4.Location = New System.Drawing.Point(14, 138)
		Me._lblLabels_4.TabIndex = 17
		Me._lblLabels_4.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_4.Enabled = True
		Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_4.UseMnemonic = True
		Me._lblLabels_4.Visible = True
		Me._lblLabels_4.AutoSize = True
		Me._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_4.Name = "_lblLabels_4"
		Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_7.Text = "Display Name:"
		Me._lblLabels_7.Size = New System.Drawing.Size(68, 13)
		Me._lblLabels_7.Location = New System.Drawing.Point(10, 20)
		Me._lblLabels_7.TabIndex = 16
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
		Me._lblLabels_8.Text = "Receipt Name:"
		Me._lblLabels_8.Size = New System.Drawing.Size(71, 13)
		Me._lblLabels_8.Location = New System.Drawing.Point(6, 45)
		Me._lblLabels_8.TabIndex = 15
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
		Me.Controls.Add(Frame2)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_frmMode_1)
		Me.Frame2.Controls.Add(txtFile)
		Me.Frame2.Controls.Add(prgStockItem)
		Me.Frame2.Controls.Add(Label1)
		Me.Frame2.Controls.Add(Label2)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdBack)
		Me._frmMode_1.Controls.Add(Picture1)
		Me._frmMode_1.Controls.Add(txtName)
		Me._frmMode_1.Controls.Add(txtReceipt)
		Me._frmMode_1.Controls.Add(Frame1)
		Me._frmMode_1.Controls.Add(cmbPricingGroup)
		Me._frmMode_1.Controls.Add(cmbStockGroup)
		Me._frmMode_1.Controls.Add(cmbDeposit)
		Me._frmMode_1.Controls.Add(cmbSupplier)
		Me._frmMode_1.Controls.Add(_lblLabels_6)
		Me._frmMode_1.Controls.Add(_lblLabels_0)
		Me._frmMode_1.Controls.Add(_lblLabels_3)
		Me._frmMode_1.Controls.Add(_lblLabels_4)
		Me._frmMode_1.Controls.Add(_lblLabels_7)
		Me._frmMode_1.Controls.Add(_lblLabels_8)
		Me.Frame1.Controls.Add(txtQuantity)
		Me.Frame1.Controls.Add(txtCost)
		Me.Frame1.Controls.Add(cmbShrink)
		Me.Frame1.Controls.Add(_lblLabels_2)
		Me.Frame1.Controls.Add(_lblLabels_10)
		Me.Frame1.Controls.Add(_lblLabels_1)
        'Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
        'Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
        'Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
        'Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame2.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me._frmMode_1.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class