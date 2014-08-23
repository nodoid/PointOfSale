<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockItemNew
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
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdPackSize As System.Windows.Forms.Button
	Public WithEvents cmdStockGroup As System.Windows.Forms.Button
	Public WithEvents cmdPricingGroup As System.Windows.Forms.Button
	Public WithEvents cmdDeposit As System.Windows.Forms.Button
	Public WithEvents cmdSupplier As System.Windows.Forms.Button
	Public WithEvents cmdShrink As System.Windows.Forms.Button
	Public WithEvents txtCost As System.Windows.Forms.TextBox
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
    Public WithEvents cmbShrink As myDataGridView
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_10 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents txtReceipt As System.Windows.Forms.TextBox
	Public WithEvents txtName As System.Windows.Forms.TextBox
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents cmbPricingGroup As myDataGridView
    Public WithEvents cmbStockGroup As myDataGridView
    Public WithEvents cmbDeposit As myDataGridView
    Public WithEvents cmbSupplier As myDataGridView
    Public WithEvents cmbPackSize As myDataGridView
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents cmdCustom As System.Windows.Forms.Button
    Public WithEvents DataList1 As myDataGridView
	Public WithEvents lblRecords As System.Windows.Forms.Label
	Public WithEvents _lbl_35 As System.Windows.Forms.Label
	Public WithEvents _frmMode_0 As System.Windows.Forms.GroupBox
    'Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockItemNew))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdBack = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me._frmMode_1 = New System.Windows.Forms.GroupBox
		Me.cmdPackSize = New System.Windows.Forms.Button
		Me.cmdStockGroup = New System.Windows.Forms.Button
		Me.cmdPricingGroup = New System.Windows.Forms.Button
		Me.cmdDeposit = New System.Windows.Forms.Button
		Me.cmdSupplier = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.cmdShrink = New System.Windows.Forms.Button
		Me.txtCost = New System.Windows.Forms.TextBox
		Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.cmbShrink = New myDataGridView
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_10 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me.txtReceipt = New System.Windows.Forms.TextBox
		Me.txtName = New System.Windows.Forms.TextBox
		Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.cmbPricingGroup = New myDataGridView
        Me.cmbStockGroup = New myDataGridView
        Me.cmbDeposit = New myDataGridView
        Me.cmbSupplier = New myDataGridView
        Me.cmbPackSize = New myDataGridView
		Me._lblLabels_5 = New System.Windows.Forms.Label
		Me._lblLabels_8 = New System.Windows.Forms.Label
		Me._lblLabels_7 = New System.Windows.Forms.Label
		Me._lblLabels_4 = New System.Windows.Forms.Label
		Me._lblLabels_3 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_6 = New System.Windows.Forms.Label
		Me._frmMode_0 = New System.Windows.Forms.GroupBox
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.cmdCustom = New System.Windows.Forms.Button
        Me.DataList1 = New myDataGridView
		Me.lblRecords = New System.Windows.Forms.Label
		Me._lbl_35 = New System.Windows.Forms.Label
        'Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me._frmMode_1.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me._frmMode_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPackSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "New Stock Item"
		Me.ClientSize = New System.Drawing.Size(366, 413)
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
		Me.Name = "frmStockItemNew"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "E&xit"
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(97, 43)
		Me.cmdBack.Location = New System.Drawing.Point(4, 364)
		Me.cmdBack.TabIndex = 20
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next >>"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(96, 43)
		Me.cmdNext.Location = New System.Drawing.Point(266, 364)
		Me.cmdNext.TabIndex = 19
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me._frmMode_1.Text = "New ""Stock Item"" Details."
		Me._frmMode_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmMode_1.Size = New System.Drawing.Size(357, 353)
		Me._frmMode_1.Location = New System.Drawing.Point(96, 6)
		Me._frmMode_1.TabIndex = 0
		Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_1.Enabled = True
		Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_1.Visible = True
		Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_1.Name = "_frmMode_1"
		Me.cmdPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPackSize.Text = "..."
		Me.cmdPackSize.Size = New System.Drawing.Size(25, 19)
		Me.cmdPackSize.Location = New System.Drawing.Point(326, 158)
		Me.cmdPackSize.TabIndex = 36
		Me.cmdPackSize.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPackSize.CausesValidation = True
		Me.cmdPackSize.Enabled = True
		Me.cmdPackSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPackSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPackSize.TabStop = True
		Me.cmdPackSize.Name = "cmdPackSize"
		Me.cmdStockGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStockGroup.Text = "..."
		Me.cmdStockGroup.Size = New System.Drawing.Size(25, 19)
		Me.cmdStockGroup.Location = New System.Drawing.Point(326, 134)
		Me.cmdStockGroup.TabIndex = 31
		Me.cmdStockGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStockGroup.CausesValidation = True
		Me.cmdStockGroup.Enabled = True
		Me.cmdStockGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStockGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStockGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStockGroup.TabStop = True
		Me.cmdStockGroup.Name = "cmdStockGroup"
		Me.cmdPricingGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPricingGroup.Text = "..."
		Me.cmdPricingGroup.Size = New System.Drawing.Size(25, 19)
		Me.cmdPricingGroup.Location = New System.Drawing.Point(326, 110)
		Me.cmdPricingGroup.TabIndex = 30
		Me.cmdPricingGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPricingGroup.CausesValidation = True
		Me.cmdPricingGroup.Enabled = True
		Me.cmdPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPricingGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPricingGroup.TabStop = True
		Me.cmdPricingGroup.Name = "cmdPricingGroup"
		Me.cmdDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeposit.Text = "..."
		Me.cmdDeposit.Size = New System.Drawing.Size(25, 19)
		Me.cmdDeposit.Location = New System.Drawing.Point(326, 86)
		Me.cmdDeposit.TabIndex = 29
		Me.cmdDeposit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDeposit.CausesValidation = True
		Me.cmdDeposit.Enabled = True
		Me.cmdDeposit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDeposit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDeposit.TabStop = True
		Me.cmdDeposit.Name = "cmdDeposit"
		Me.cmdSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupplier.Text = "..."
		Me.cmdSupplier.Size = New System.Drawing.Size(25, 19)
		Me.cmdSupplier.Location = New System.Drawing.Point(326, 62)
		Me.cmdSupplier.TabIndex = 28
		Me.cmdSupplier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupplier.CausesValidation = True
		Me.cmdSupplier.Enabled = True
		Me.cmdSupplier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupplier.TabStop = True
		Me.cmdSupplier.Name = "cmdSupplier"
		Me.Frame1.Size = New System.Drawing.Size(343, 75)
		Me.Frame1.Location = New System.Drawing.Point(8, 200)
		Me.Frame1.TabIndex = 21
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.cmdShrink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdShrink.Text = "..."
		Me.cmdShrink.Size = New System.Drawing.Size(25, 19)
		Me.cmdShrink.Location = New System.Drawing.Point(230, 40)
		Me.cmdShrink.TabIndex = 32
		Me.cmdShrink.BackColor = System.Drawing.SystemColors.Control
		Me.cmdShrink.CausesValidation = True
		Me.cmdShrink.Enabled = True
		Me.cmdShrink.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdShrink.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdShrink.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdShrink.TabStop = True
		Me.cmdShrink.Name = "cmdShrink"
		Me.txtCost.AutoSize = False
		Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtCost.Size = New System.Drawing.Size(56, 19)
		Me.txtCost.Location = New System.Drawing.Point(282, 14)
		Me.txtCost.TabIndex = 25
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
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(34, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(68, 14)
		Me.txtQuantity.TabIndex = 23
		Me.txtQuantity.Text = "1"
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
        'cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbShrink.Size = New System.Drawing.Size(91, 21)
		Me.cmbShrink.Location = New System.Drawing.Point(132, 38)
		Me.cmbShrink.TabIndex = 27
		Me.cmbShrink.Name = "cmbShrink"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.Text = "and you sell in shrinks of"
		Me._lblLabels_1.Size = New System.Drawing.Size(115, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(14, 42)
		Me._lblLabels_1.TabIndex = 26
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
		Me._lblLabels_10.Text = "Units in a case/carton, which costs"
		Me._lblLabels_10.Size = New System.Drawing.Size(167, 13)
		Me._lblLabels_10.Location = New System.Drawing.Point(106, 16)
		Me._lblLabels_10.TabIndex = 24
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
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.Text = "There are "
		Me._lblLabels_2.Size = New System.Drawing.Size(49, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(14, 16)
		Me._lblLabels_2.TabIndex = 22
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
		Me.txtReceipt.AutoSize = False
		Me.txtReceipt.Size = New System.Drawing.Size(241, 19)
		Me.txtReceipt.Location = New System.Drawing.Point(82, 40)
		Me.txtReceipt.Maxlength = 40
		Me.txtReceipt.TabIndex = 4
		Me.txtReceipt.Text = "[New Product]"
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
		Me.txtName.AutoSize = False
		Me.txtName.Size = New System.Drawing.Size(241, 19)
		Me.txtName.Location = New System.Drawing.Point(82, 18)
		Me.txtName.Maxlength = 128
		Me.txtName.TabIndex = 2
		Me.txtName.Text = "[New Product]"
		Me.txtName.AcceptsReturn = True
		Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtName.BackColor = System.Drawing.SystemColors.Window
		Me.txtName.CausesValidation = True
		Me.txtName.Enabled = True
		Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtName.HideSelection = True
		Me.txtName.ReadOnly = False
		Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtName.MultiLine = False
		Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtName.TabStop = True
		Me.txtName.Visible = True
		Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtName.Name = "txtName"
		Me.Picture1.Size = New System.Drawing.Size(295, 4)
		Me.Picture1.Location = New System.Drawing.Point(28, 192)
		Me.Picture1.TabIndex = 13
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
        'cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPricingGroup.Size = New System.Drawing.Size(241, 21)
		Me.cmbPricingGroup.Location = New System.Drawing.Point(82, 108)
		Me.cmbPricingGroup.TabIndex = 10
		Me.cmbPricingGroup.Name = "cmbPricingGroup"
        'cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbStockGroup.Size = New System.Drawing.Size(241, 21)
		Me.cmbStockGroup.Location = New System.Drawing.Point(82, 132)
		Me.cmbStockGroup.TabIndex = 12
		Me.cmbStockGroup.Name = "cmbStockGroup"
        'cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbDeposit.Size = New System.Drawing.Size(241, 21)
		Me.cmbDeposit.Location = New System.Drawing.Point(82, 84)
		Me.cmbDeposit.TabIndex = 8
		Me.cmbDeposit.Name = "cmbDeposit"
        'cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbSupplier.Size = New System.Drawing.Size(241, 21)
		Me.cmbSupplier.Location = New System.Drawing.Point(82, 60)
		Me.cmbSupplier.TabIndex = 6
		Me.cmbSupplier.Name = "cmbSupplier"
        'cmbPackSize.OcxState = CType(resources.GetObject("cmbPackSize.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPackSize.Size = New System.Drawing.Size(241, 21)
		Me.cmbPackSize.Location = New System.Drawing.Point(82, 156)
		Me.cmbPackSize.TabIndex = 35
		Me.cmbPackSize.Name = "cmbPackSize"
		Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_5.Text = "Pack Size:"
		Me._lblLabels_5.Size = New System.Drawing.Size(51, 13)
		Me._lblLabels_5.Location = New System.Drawing.Point(28, 160)
		Me._lblLabels_5.TabIndex = 34
		Me._lblLabels_5.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_5.Enabled = True
		Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_5.UseMnemonic = True
		Me._lblLabels_5.Visible = True
		Me._lblLabels_5.AutoSize = True
		Me._lblLabels_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_5.Name = "_lblLabels_5"
		Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_8.Text = "Receipt Name:"
		Me._lblLabels_8.Size = New System.Drawing.Size(71, 13)
		Me._lblLabels_8.Location = New System.Drawing.Point(6, 45)
		Me._lblLabels_8.TabIndex = 3
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
		Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_7.Text = "Display Name:"
		Me._lblLabels_7.Size = New System.Drawing.Size(68, 13)
		Me._lblLabels_7.Location = New System.Drawing.Point(10, 20)
		Me._lblLabels_7.TabIndex = 1
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
		Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_4.Text = "Stock Group:"
		Me._lblLabels_4.Size = New System.Drawing.Size(63, 13)
		Me._lblLabels_4.Location = New System.Drawing.Point(14, 138)
		Me._lblLabels_4.TabIndex = 11
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
		Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_3.Text = "Pricing Group:"
		Me._lblLabels_3.Size = New System.Drawing.Size(67, 13)
		Me._lblLabels_3.Location = New System.Drawing.Point(10, 114)
		Me._lblLabels_3.TabIndex = 9
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
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.Text = "Supplier:"
		Me._lblLabels_0.Size = New System.Drawing.Size(41, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(36, 66)
		Me._lblLabels_0.TabIndex = 5
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
		Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_6.Text = "Deposit:"
		Me._lblLabels_6.Size = New System.Drawing.Size(39, 13)
		Me._lblLabels_6.Location = New System.Drawing.Point(38, 90)
		Me._lblLabels_6.TabIndex = 7
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
		Me._frmMode_0.Text = "Select the Product for the New ""Stock Item""."
		Me._frmMode_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmMode_0.Size = New System.Drawing.Size(357, 355)
		Me._frmMode_0.Location = New System.Drawing.Point(4, 4)
		Me._frmMode_0.TabIndex = 15
		Me._frmMode_0.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_0.Enabled = True
		Me._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_0.Visible = True
		Me._frmMode_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_0.Name = "_frmMode_0"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(291, 19)
		Me.txtSearch.Location = New System.Drawing.Point(57, 18)
		Me.txtSearch.TabIndex = 16
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
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSearch.Name = "txtSearch"
		Me.cmdCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCustom.Text = "The product I want is not in this list."
		Me.cmdCustom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdCustom.Size = New System.Drawing.Size(336, 37)
		Me.cmdCustom.Location = New System.Drawing.Point(12, 306)
		Me.cmdCustom.TabIndex = 18
		Me.cmdCustom.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCustom.CausesValidation = True
		Me.cmdCustom.Enabled = True
		Me.cmdCustom.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCustom.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCustom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCustom.TabStop = True
		Me.cmdCustom.Name = "cmdCustom"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(336, 225)
		Me.DataList1.Location = New System.Drawing.Point(12, 44)
		Me.DataList1.TabIndex = 17
		Me.DataList1.Name = "DataList1"
		Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblRecords.Text = "Displayed Records 0 of 0"
		Me.lblRecords.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecords.Size = New System.Drawing.Size(336, 17)
		Me.lblRecords.Location = New System.Drawing.Point(12, 272)
		Me.lblRecords.TabIndex = 33
		Me.lblRecords.BackColor = System.Drawing.SystemColors.Control
		Me.lblRecords.Enabled = True
		Me.lblRecords.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRecords.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRecords.UseMnemonic = True
		Me.lblRecords.Visible = True
		Me.lblRecords.AutoSize = False
		Me.lblRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRecords.Name = "lblRecords"
		Me._lbl_35.Text = "Search"
		Me._lbl_35.Size = New System.Drawing.Size(43, 16)
		Me._lbl_35.Location = New System.Drawing.Point(15, 21)
		Me._lbl_35.TabIndex = 14
		Me._lbl_35.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_35.BackColor = System.Drawing.SystemColors.Control
		Me._lbl_35.Enabled = True
		Me._lbl_35.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_35.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_35.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_35.UseMnemonic = True
		Me._lbl_35.Visible = True
		Me._lbl_35.AutoSize = False
		Me._lbl_35.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_35.Name = "_lbl_35"
		Me.Controls.Add(cmdBack)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(_frmMode_1)
		Me.Controls.Add(_frmMode_0)
		Me._frmMode_1.Controls.Add(cmdPackSize)
		Me._frmMode_1.Controls.Add(cmdStockGroup)
		Me._frmMode_1.Controls.Add(cmdPricingGroup)
		Me._frmMode_1.Controls.Add(cmdDeposit)
		Me._frmMode_1.Controls.Add(cmdSupplier)
		Me._frmMode_1.Controls.Add(Frame1)
		Me._frmMode_1.Controls.Add(txtReceipt)
		Me._frmMode_1.Controls.Add(txtName)
		Me._frmMode_1.Controls.Add(Picture1)
		Me._frmMode_1.Controls.Add(cmbPricingGroup)
		Me._frmMode_1.Controls.Add(cmbStockGroup)
		Me._frmMode_1.Controls.Add(cmbDeposit)
		Me._frmMode_1.Controls.Add(cmbSupplier)
		Me._frmMode_1.Controls.Add(cmbPackSize)
		Me._frmMode_1.Controls.Add(_lblLabels_5)
		Me._frmMode_1.Controls.Add(_lblLabels_8)
		Me._frmMode_1.Controls.Add(_lblLabels_7)
		Me._frmMode_1.Controls.Add(_lblLabels_4)
		Me._frmMode_1.Controls.Add(_lblLabels_3)
		Me._frmMode_1.Controls.Add(_lblLabels_0)
		Me._frmMode_1.Controls.Add(_lblLabels_6)
		Me.Frame1.Controls.Add(cmdShrink)
		Me.Frame1.Controls.Add(txtCost)
		Me.Frame1.Controls.Add(txtQuantity)
		Me.Frame1.Controls.Add(cmbShrink)
		Me.Frame1.Controls.Add(_lblLabels_1)
		Me.Frame1.Controls.Add(_lblLabels_10)
		Me.Frame1.Controls.Add(_lblLabels_2)
		Me._frmMode_0.Controls.Add(txtSearch)
		Me._frmMode_0.Controls.Add(cmdCustom)
		Me._frmMode_0.Controls.Add(DataList1)
		Me._frmMode_0.Controls.Add(lblRecords)
		Me._frmMode_0.Controls.Add(_lbl_35)
        'Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
        'Me.frmMode.SetIndex(_frmMode_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_35, CType(35, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
        'Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
        'Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
        'Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPackSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmMode_1.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me._frmMode_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class