<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockPricing
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
	Public WithEvents txttemphold As System.Windows.Forms.TextBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdbarcode As System.Windows.Forms.Button
	Public WithEvents cmdHistory As System.Windows.Forms.Button
	Public WithEvents cmdDetails As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdUndo As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents cmbChannel As System.Windows.Forms.ComboBox
	Public WithEvents _picLine_0 As System.Windows.Forms.PictureBox
	Public WithEvents _txtCost_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtProp_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtPrice_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtVariableCost_0 As System.Windows.Forms.TextBox
	Public WithEvents _lblGPActual_0 As System.Windows.Forms.Label
	Public WithEvents _lblGP_0 As System.Windows.Forms.Label
	Public WithEvents _lblSection_0 As System.Windows.Forms.Label
	Public WithEvents _lnProfit_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _lblProfitPrecent_0 As System.Windows.Forms.Label
	Public WithEvents _lblProfitAmount_0 As System.Windows.Forms.Label
	Public WithEvents _lblMatrix_0 As System.Windows.Forms.Label
	Public WithEvents _lblDepositUnit_0 As System.Windows.Forms.Label
	Public WithEvents _lblDepositPack_0 As System.Windows.Forms.Label
	Public WithEvents _lblVat_0 As System.Windows.Forms.Label
	Public WithEvents _lblMarkup_0 As System.Windows.Forms.Label
	Public WithEvents _lblPrice_0 As System.Windows.Forms.Label
	Public WithEvents _lblPercent_0 As System.Windows.Forms.Label
	Public WithEvents _frmItem_0 As System.Windows.Forms.GroupBox
	Public WithEvents ilGeneral As System.Windows.Forms.ImageList
	Public WithEvents _lbl_17 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblPriceSet As System.Windows.Forms.Label
	Public WithEvents _lbl_16 As System.Windows.Forms.Label
	Public WithEvents _lbl_15 As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents lblStockItemName As System.Windows.Forms.Label
	Public WithEvents lblPricingGroupRule As System.Windows.Forms.Label
	Public WithEvents lblPricingGroup As System.Windows.Forms.Label
	Public WithEvents _lbl_18 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _lbl_6 As System.Windows.Forms.Label
	Public WithEvents lblVatName As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents _lbl_9 As System.Windows.Forms.Label
	Public WithEvents _lbl_10 As System.Windows.Forms.Label
	Public WithEvents _lbl_11 As System.Windows.Forms.Label
	Public WithEvents _lbl_12 As System.Windows.Forms.Label
	Public WithEvents _lbl_13 As System.Windows.Forms.Label
	Public WithEvents _lbl_14 As System.Windows.Forms.Label
	Public WithEvents _Line1_3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line1 As LineShapeArray
    'Public WithEvents frmItem As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblDepositPack As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblDepositUnit As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'P''ublic WithEvents lblGP As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'P'ublic WithEvents lblGPActual As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'P'ublic WithEvents lblMarkup As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'P'ublic WithEvents lblMatrix As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'P'''ublic WithEvents lblPercent As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblPrice As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblProfitAmount As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblProfitPrecent As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblSection As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblVat As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lnProfit As LineShapeArray
    'Public WithEvents picLine As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents txtCost As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtPrice As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'P''ublic WithEvents txtProp As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtVariableCost As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockPricing))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.txttemphold = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdbarcode = New System.Windows.Forms.Button
		Me.cmdHistory = New System.Windows.Forms.Button
		Me.cmdDetails = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdUndo = New System.Windows.Forms.Button
		Me.cmbChannel = New System.Windows.Forms.ComboBox
		Me._frmItem_0 = New System.Windows.Forms.GroupBox
		Me._picLine_0 = New System.Windows.Forms.PictureBox
		Me._txtCost_0 = New System.Windows.Forms.TextBox
		Me._txtProp_0 = New System.Windows.Forms.TextBox
		Me._txtPrice_0 = New System.Windows.Forms.TextBox
		Me._txtVariableCost_0 = New System.Windows.Forms.TextBox
		Me._lblGPActual_0 = New System.Windows.Forms.Label
		Me._lblGP_0 = New System.Windows.Forms.Label
		Me._lblSection_0 = New System.Windows.Forms.Label
		Me._lnProfit_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._lblProfitPrecent_0 = New System.Windows.Forms.Label
		Me._lblProfitAmount_0 = New System.Windows.Forms.Label
		Me._lblMatrix_0 = New System.Windows.Forms.Label
		Me._lblDepositUnit_0 = New System.Windows.Forms.Label
		Me._lblDepositPack_0 = New System.Windows.Forms.Label
		Me._lblVat_0 = New System.Windows.Forms.Label
		Me._lblMarkup_0 = New System.Windows.Forms.Label
		Me._lblPrice_0 = New System.Windows.Forms.Label
		Me._lblPercent_0 = New System.Windows.Forms.Label
		Me.ilGeneral = New System.Windows.Forms.ImageList
		Me._lbl_17 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblPriceSet = New System.Windows.Forms.Label
		Me._lbl_16 = New System.Windows.Forms.Label
		Me._lbl_15 = New System.Windows.Forms.Label
		Me._lbl_4 = New System.Windows.Forms.Label
		Me._lbl_7 = New System.Windows.Forms.Label
		Me.lblStockItemName = New System.Windows.Forms.Label
		Me.lblPricingGroupRule = New System.Windows.Forms.Label
		Me.lblPricingGroup = New System.Windows.Forms.Label
		Me._lbl_18 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_3 = New System.Windows.Forms.Label
		Me._lbl_5 = New System.Windows.Forms.Label
		Me._lbl_6 = New System.Windows.Forms.Label
		Me.lblVatName = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me._lbl_9 = New System.Windows.Forms.Label
		Me._lbl_10 = New System.Windows.Forms.Label
		Me._lbl_11 = New System.Windows.Forms.Label
		Me._lbl_12 = New System.Windows.Forms.Label
		Me._lbl_13 = New System.Windows.Forms.Label
		Me._lbl_14 = New System.Windows.Forms.Label
		Me._Line1_3 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line1 = New LineShapeArray(components)
        'Me.frmItem = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblDepositPack = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblDepositUnit = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblGP = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblGPActual = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblMarkup = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblMatrix = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblPercent = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblPrice = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblProfitAmount = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblProfitPrecent = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblSection = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblVat = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lnProfit = New LineShapeArray(components)
        'Me.picLine = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
        'Me.txtCost = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        ''Me.txtPrice = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'M() 'e.txtProp = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'M() 'e.txtVariableCost = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.picButtons.SuspendLayout()
		Me._frmItem_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmItem, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblDepositPack, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblDepositUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblGP, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblGPActual, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblMarkup, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblProfitAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblProfitPrecent, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblSection, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblVat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lnProfit, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtCost, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtProp, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtVariableCost, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Stock Item Pricing"
		Me.ClientSize = New System.Drawing.Size(711, 565)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("frmStockPricing.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockPricing"
		Me.txttemphold.AutoSize = False
		Me.txttemphold.Size = New System.Drawing.Size(73, 21)
		Me.txttemphold.Location = New System.Drawing.Point(392, 574)
		Me.txttemphold.TabIndex = 48
		Me.txttemphold.AcceptsReturn = True
		Me.txttemphold.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txttemphold.BackColor = System.Drawing.SystemColors.Window
		Me.txttemphold.CausesValidation = True
		Me.txttemphold.Enabled = True
		Me.txttemphold.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txttemphold.HideSelection = True
		Me.txttemphold.ReadOnly = False
		Me.txttemphold.Maxlength = 0
		Me.txttemphold.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txttemphold.MultiLine = False
		Me.txttemphold.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txttemphold.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txttemphold.TabStop = True
		Me.txttemphold.Visible = True
		Me.txttemphold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txttemphold.Name = "txttemphold"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(711, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 38
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
		Me.cmdNext.Text = "&Next Item >"
		Me.cmdNext.Size = New System.Drawing.Size(67, 29)
		Me.cmdNext.Location = New System.Drawing.Point(320, 4)
		Me.cmdNext.TabIndex = 50
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.cmdbarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdbarcode.Text = "&Barcode"
		Me.cmdbarcode.Size = New System.Drawing.Size(77, 31)
		Me.cmdbarcode.Location = New System.Drawing.Point(86, 2)
		Me.cmdbarcode.TabIndex = 47
		Me.cmdbarcode.TabStop = False
		Me.cmdbarcode.BackColor = System.Drawing.SystemColors.Control
		Me.cmdbarcode.CausesValidation = True
		Me.cmdbarcode.Enabled = True
		Me.cmdbarcode.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdbarcode.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdbarcode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdbarcode.Name = "cmdbarcode"
		Me.cmdHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdHistory.Text = "&History"
		Me.cmdHistory.Size = New System.Drawing.Size(67, 29)
		Me.cmdHistory.Location = New System.Drawing.Point(248, 4)
		Me.cmdHistory.TabIndex = 45
		Me.cmdHistory.TabStop = False
		Me.cmdHistory.BackColor = System.Drawing.SystemColors.Control
		Me.cmdHistory.CausesValidation = True
		Me.cmdHistory.Enabled = True
		Me.cmdHistory.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdHistory.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdHistory.Name = "cmdHistory"
		Me.cmdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDetails.Text = "&Details"
		Me.cmdDetails.Size = New System.Drawing.Size(73, 29)
		Me.cmdDetails.Location = New System.Drawing.Point(168, 4)
		Me.cmdDetails.TabIndex = 41
		Me.cmdDetails.TabStop = False
		Me.cmdDetails.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDetails.CausesValidation = True
		Me.cmdDetails.Enabled = True
		Me.cmdDetails.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDetails.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDetails.Name = "cmdDetails"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(73, 29)
		Me.cmdExit.Location = New System.Drawing.Point(512, 2)
		Me.cmdExit.TabIndex = 40
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUndo.Text = "&Undo"
		Me.cmdUndo.Size = New System.Drawing.Size(73, 29)
		Me.cmdUndo.Location = New System.Drawing.Point(5, 3)
		Me.cmdUndo.TabIndex = 39
		Me.cmdUndo.TabStop = False
		Me.cmdUndo.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUndo.CausesValidation = True
		Me.cmdUndo.Enabled = True
		Me.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUndo.Name = "cmdUndo"
		Me.cmbChannel.Size = New System.Drawing.Size(160, 21)
		Me.cmbChannel.Location = New System.Drawing.Point(87, 66)
		Me.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbChannel.TabIndex = 0
		Me.cmbChannel.BackColor = System.Drawing.SystemColors.Window
		Me.cmbChannel.CausesValidation = True
		Me.cmbChannel.Enabled = True
		Me.cmbChannel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbChannel.IntegralHeight = True
		Me.cmbChannel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbChannel.Sorted = False
		Me.cmbChannel.TabStop = True
		Me.cmbChannel.Visible = True
		Me.cmbChannel.Name = "cmbChannel"
		Me._frmItem_0.Text = "Frame1"
		Me._frmItem_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmItem_0.Size = New System.Drawing.Size(100, 355)
		Me._frmItem_0.Location = New System.Drawing.Point(87, 159)
		Me._frmItem_0.TabIndex = 5
		Me._frmItem_0.BackColor = System.Drawing.SystemColors.Control
		Me._frmItem_0.Enabled = True
		Me._frmItem_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmItem_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmItem_0.Visible = True
		Me._frmItem_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmItem_0.Name = "_frmItem_0"
		Me._picLine_0.BackColor = System.Drawing.Color.FromARGB(0, 0, 192)
		Me._picLine_0.Size = New System.Drawing.Size(94, 7)
		Me._picLine_0.Location = New System.Drawing.Point(3, 189)
		Me._picLine_0.TabIndex = 37
		Me._picLine_0.TabStop = False
		Me._picLine_0.Dock = System.Windows.Forms.DockStyle.None
		Me._picLine_0.CausesValidation = True
		Me._picLine_0.Enabled = True
		Me._picLine_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._picLine_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._picLine_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._picLine_0.Visible = True
		Me._picLine_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me._picLine_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._picLine_0.Name = "_picLine_0"
		Me._txtCost_0.AutoSize = False
		Me._txtCost_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtCost_0.Size = New System.Drawing.Size(88, 19)
		Me._txtCost_0.Location = New System.Drawing.Point(6, 18)
		Me._txtCost_0.TabIndex = 1
		Me._txtCost_0.Text = "9,999.99"
		Me._txtCost_0.AcceptsReturn = True
		Me._txtCost_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtCost_0.CausesValidation = True
		Me._txtCost_0.Enabled = True
		Me._txtCost_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtCost_0.HideSelection = True
		Me._txtCost_0.ReadOnly = False
		Me._txtCost_0.Maxlength = 0
		Me._txtCost_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtCost_0.MultiLine = False
		Me._txtCost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtCost_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtCost_0.TabStop = True
		Me._txtCost_0.Visible = True
		Me._txtCost_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtCost_0.Name = "_txtCost_0"
		Me._txtProp_0.AutoSize = False
		Me._txtProp_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtProp_0.Size = New System.Drawing.Size(88, 19)
		Me._txtProp_0.Location = New System.Drawing.Point(6, 54)
		Me._txtProp_0.TabIndex = 2
		Me._txtProp_0.AcceptsReturn = True
		Me._txtProp_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtProp_0.CausesValidation = True
		Me._txtProp_0.Enabled = True
		Me._txtProp_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtProp_0.HideSelection = True
		Me._txtProp_0.ReadOnly = False
		Me._txtProp_0.Maxlength = 0
		Me._txtProp_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtProp_0.MultiLine = False
		Me._txtProp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtProp_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtProp_0.TabStop = True
		Me._txtProp_0.Visible = True
		Me._txtProp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtProp_0.Name = "_txtProp_0"
		Me._txtPrice_0.AutoSize = False
		Me._txtPrice_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtPrice_0.Size = New System.Drawing.Size(88, 19)
		Me._txtPrice_0.Location = New System.Drawing.Point(6, 150)
		Me._txtPrice_0.TabIndex = 3
		Me._txtPrice_0.AcceptsReturn = True
		Me._txtPrice_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtPrice_0.CausesValidation = True
		Me._txtPrice_0.Enabled = True
		Me._txtPrice_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtPrice_0.HideSelection = True
		Me._txtPrice_0.ReadOnly = False
		Me._txtPrice_0.Maxlength = 0
		Me._txtPrice_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtPrice_0.MultiLine = False
		Me._txtPrice_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtPrice_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtPrice_0.TabStop = True
		Me._txtPrice_0.Visible = True
		Me._txtPrice_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtPrice_0.Name = "_txtPrice_0"
		Me._txtVariableCost_0.AutoSize = False
		Me._txtVariableCost_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtVariableCost_0.Enabled = False
		Me._txtVariableCost_0.Size = New System.Drawing.Size(88, 19)
		Me._txtVariableCost_0.Location = New System.Drawing.Point(6, 243)
		Me._txtVariableCost_0.TabIndex = 4
		Me._txtVariableCost_0.TabStop = False
		Me._txtVariableCost_0.Text = "42.00"
		Me._txtVariableCost_0.AcceptsReturn = True
		Me._txtVariableCost_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtVariableCost_0.CausesValidation = True
		Me._txtVariableCost_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtVariableCost_0.HideSelection = True
		Me._txtVariableCost_0.ReadOnly = False
		Me._txtVariableCost_0.Maxlength = 0
		Me._txtVariableCost_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtVariableCost_0.MultiLine = False
		Me._txtVariableCost_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtVariableCost_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtVariableCost_0.Visible = True
		Me._txtVariableCost_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtVariableCost_0.Name = "_txtVariableCost_0"
		Me._lblGPActual_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblGPActual_0.BackColor = System.Drawing.Color.FromARGB(255, 224, 192)
		Me._lblGPActual_0.Text = "lblGPActual"
		Me._lblGPActual_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblGPActual_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblGPActual_0.Size = New System.Drawing.Size(88, 16)
		Me._lblGPActual_0.Location = New System.Drawing.Point(6, 300)
		Me._lblGPActual_0.TabIndex = 46
		Me._lblGPActual_0.Enabled = True
		Me._lblGPActual_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblGPActual_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblGPActual_0.UseMnemonic = True
		Me._lblGPActual_0.Visible = True
		Me._lblGPActual_0.AutoSize = False
		Me._lblGPActual_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblGPActual_0.Name = "_lblGPActual_0"
		Me._lblGP_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblGP_0.BackColor = System.Drawing.Color.FromARGB(255, 224, 192)
		Me._lblGP_0.Text = "lblGP"
		Me._lblGP_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblGP_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblGP_0.Size = New System.Drawing.Size(88, 16)
		Me._lblGP_0.Location = New System.Drawing.Point(6, 216)
		Me._lblGP_0.TabIndex = 43
		Me._lblGP_0.Enabled = True
		Me._lblGP_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblGP_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblGP_0.UseMnemonic = True
		Me._lblGP_0.Visible = True
		Me._lblGP_0.AutoSize = False
		Me._lblGP_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblGP_0.Name = "_lblGP_0"
		Me._lblSection_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblSection_0.BackColor = System.Drawing.Color.Red
		Me._lblSection_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblSection_0.Size = New System.Drawing.Size(88, 34)
		Me._lblSection_0.Location = New System.Drawing.Point(6, 318)
		Me._lblSection_0.TabIndex = 36
		Me._lblSection_0.Enabled = True
		Me._lblSection_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblSection_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblSection_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblSection_0.UseMnemonic = True
		Me._lblSection_0.Visible = True
		Me._lblSection_0.AutoSize = False
		Me._lblSection_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lblSection_0.Name = "_lblSection_0"
		Me._lnProfit_0.X1 = 93
		Me._lnProfit_0.X2 = 0
		Me._lnProfit_0.Y1 = 224
		Me._lnProfit_0.Y2 = 224
		Me._lnProfit_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._lnProfit_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._lnProfit_0.BorderWidth = 1
		Me._lnProfit_0.Visible = True
		Me._lnProfit_0.Name = "_lnProfit_0"
		Me._lblProfitPrecent_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblProfitPrecent_0.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._lblProfitPrecent_0.Text = "lblProfitPrecent"
		Me._lblProfitPrecent_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblProfitPrecent_0.ForeColor = System.Drawing.Color.Black
		Me._lblProfitPrecent_0.Size = New System.Drawing.Size(88, 16)
		Me._lblProfitPrecent_0.Location = New System.Drawing.Point(6, 282)
		Me._lblProfitPrecent_0.TabIndex = 28
		Me._lblProfitPrecent_0.Enabled = True
		Me._lblProfitPrecent_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblProfitPrecent_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblProfitPrecent_0.UseMnemonic = True
		Me._lblProfitPrecent_0.Visible = True
		Me._lblProfitPrecent_0.AutoSize = False
		Me._lblProfitPrecent_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblProfitPrecent_0.Name = "_lblProfitPrecent_0"
		Me._lblProfitAmount_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblProfitAmount_0.BackColor = System.Drawing.Color.FromARGB(255, 192, 128)
		Me._lblProfitAmount_0.Text = "lblProfitAmount"
		Me._lblProfitAmount_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblProfitAmount_0.ForeColor = System.Drawing.Color.Black
		Me._lblProfitAmount_0.Size = New System.Drawing.Size(88, 16)
		Me._lblProfitAmount_0.Location = New System.Drawing.Point(6, 264)
		Me._lblProfitAmount_0.TabIndex = 27
		Me._lblProfitAmount_0.Enabled = True
		Me._lblProfitAmount_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblProfitAmount_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblProfitAmount_0.UseMnemonic = True
		Me._lblProfitAmount_0.Visible = True
		Me._lblProfitAmount_0.AutoSize = False
		Me._lblProfitAmount_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblProfitAmount_0.Name = "_lblProfitAmount_0"
		Me._lblMatrix_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblMatrix_0.Text = "30.00"
		Me._lblMatrix_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblMatrix_0.Size = New System.Drawing.Size(88, 13)
		Me._lblMatrix_0.Location = New System.Drawing.Point(6, 39)
		Me._lblMatrix_0.TabIndex = 26
		Me._lblMatrix_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblMatrix_0.Enabled = True
		Me._lblMatrix_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblMatrix_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblMatrix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblMatrix_0.UseMnemonic = True
		Me._lblMatrix_0.Visible = True
		Me._lblMatrix_0.AutoSize = False
		Me._lblMatrix_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblMatrix_0.Name = "_lblMatrix_0"
		Me._lblDepositUnit_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblDepositUnit_0.Text = "10.00"
		Me._lblDepositUnit_0.Size = New System.Drawing.Size(88, 13)
		Me._lblDepositUnit_0.Location = New System.Drawing.Point(6, 78)
		Me._lblDepositUnit_0.TabIndex = 25
		Me._lblDepositUnit_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblDepositUnit_0.Enabled = True
		Me._lblDepositUnit_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDepositUnit_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDepositUnit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDepositUnit_0.UseMnemonic = True
		Me._lblDepositUnit_0.Visible = True
		Me._lblDepositUnit_0.AutoSize = False
		Me._lblDepositUnit_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDepositUnit_0.Name = "_lblDepositUnit_0"
		Me._lblDepositPack_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblDepositPack_0.Text = "15.00"
		Me._lblDepositPack_0.Size = New System.Drawing.Size(88, 13)
		Me._lblDepositPack_0.Location = New System.Drawing.Point(6, 96)
		Me._lblDepositPack_0.TabIndex = 24
		Me._lblDepositPack_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblDepositPack_0.Enabled = True
		Me._lblDepositPack_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblDepositPack_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblDepositPack_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblDepositPack_0.UseMnemonic = True
		Me._lblDepositPack_0.Visible = True
		Me._lblDepositPack_0.AutoSize = False
		Me._lblDepositPack_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblDepositPack_0.Name = "_lblDepositPack_0"
		Me._lblVat_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblVat_0.Text = "lblVat"
		Me._lblVat_0.Size = New System.Drawing.Size(88, 13)
		Me._lblVat_0.Location = New System.Drawing.Point(6, 114)
		Me._lblVat_0.TabIndex = 23
		Me._lblVat_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblVat_0.Enabled = True
		Me._lblVat_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblVat_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblVat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblVat_0.UseMnemonic = True
		Me._lblVat_0.Visible = True
		Me._lblVat_0.AutoSize = False
		Me._lblVat_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblVat_0.Name = "_lblVat_0"
		Me._lblMarkup_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblMarkup_0.BackColor = System.Drawing.Color.FromARGB(255, 224, 192)
		Me._lblMarkup_0.Text = "lblMarkup"
		Me._lblMarkup_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblMarkup_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblMarkup_0.Size = New System.Drawing.Size(88, 16)
		Me._lblMarkup_0.Location = New System.Drawing.Point(6, 132)
		Me._lblMarkup_0.TabIndex = 22
		Me._lblMarkup_0.Enabled = True
		Me._lblMarkup_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblMarkup_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblMarkup_0.UseMnemonic = True
		Me._lblMarkup_0.Visible = True
		Me._lblMarkup_0.AutoSize = False
		Me._lblMarkup_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblMarkup_0.Name = "_lblMarkup_0"
		Me._lblPrice_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblPrice_0.BackColor = System.Drawing.Color.Red
		Me._lblPrice_0.Text = "lblPrice"
		Me._lblPrice_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblPrice_0.ForeColor = System.Drawing.Color.White
		Me._lblPrice_0.Size = New System.Drawing.Size(88, 16)
		Me._lblPrice_0.Location = New System.Drawing.Point(6, 171)
		Me._lblPrice_0.TabIndex = 21
		Me._lblPrice_0.Enabled = True
		Me._lblPrice_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblPrice_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblPrice_0.UseMnemonic = True
		Me._lblPrice_0.Visible = True
		Me._lblPrice_0.AutoSize = False
		Me._lblPrice_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblPrice_0.Name = "_lblPrice_0"
		Me._lblPercent_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblPercent_0.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._lblPercent_0.Text = "lblPercent"
		Me._lblPercent_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblPercent_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblPercent_0.Size = New System.Drawing.Size(88, 16)
		Me._lblPercent_0.Location = New System.Drawing.Point(6, 198)
		Me._lblPercent_0.TabIndex = 20
		Me._lblPercent_0.Enabled = True
		Me._lblPercent_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblPercent_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblPercent_0.UseMnemonic = True
		Me._lblPercent_0.Visible = True
		Me._lblPercent_0.AutoSize = False
		Me._lblPercent_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblPercent_0.Name = "_lblPercent_0"
		Me.ilGeneral.ImageSize = New System.Drawing.Size(20, 20)
		Me.ilGeneral.TransparentColor = System.Drawing.Color.FromARGB(255, 0, 255)
		Me.ilGeneral.ImageStream = CType(resources.GetObject("ilGeneral.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ilGeneral.Images.SetKeyName(0, "")
		Me.ilGeneral.Images.SetKeyName(1, "")
		Me.ilGeneral.Images.SetKeyName(2, "")
		Me.ilGeneral.Images.SetKeyName(3, "")
		Me.ilGeneral.Images.SetKeyName(4, "")
		Me.ilGeneral.Images.SetKeyName(5, "")
		Me.ilGeneral.Images.SetKeyName(6, "")
		Me._lbl_17.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_17.Text = "Margin % "
		Me._lbl_17.Size = New System.Drawing.Size(88, 13)
		Me._lbl_17.Location = New System.Drawing.Point(-3, 460)
		Me._lbl_17.TabIndex = 49
		Me._lbl_17.BackColor = System.Drawing.Color.Transparent
		Me._lbl_17.Enabled = True
		Me._lbl_17.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_17.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_17.UseMnemonic = True
		Me._lbl_17.Visible = True
		Me._lbl_17.AutoSize = False
		Me._lbl_17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_17.Name = "_lbl_17"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "GP %:"
		Me._lbl_0.Size = New System.Drawing.Size(88, 13)
		Me._lbl_0.Location = New System.Drawing.Point(-3, 378)
		Me._lbl_0.TabIndex = 44
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = False
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblPriceSet.Text = "No Action"
		Me.lblPriceSet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPriceSet.Size = New System.Drawing.Size(421, 17)
		Me.lblPriceSet.Location = New System.Drawing.Point(87, 525)
		Me.lblPriceSet.TabIndex = 42
		Me.lblPriceSet.Visible = False
		Me.lblPriceSet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPriceSet.BackColor = System.Drawing.SystemColors.Control
		Me.lblPriceSet.Enabled = True
		Me.lblPriceSet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPriceSet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPriceSet.UseMnemonic = True
		Me.lblPriceSet.AutoSize = False
		Me.lblPriceSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPriceSet.Name = "lblPriceSet"
		Me._lbl_16.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_16.Text = "Pricing Rule:"
		Me._lbl_16.Size = New System.Drawing.Size(60, 13)
		Me._lbl_16.Location = New System.Drawing.Point(22, 111)
		Me._lbl_16.TabIndex = 35
		Me._lbl_16.BackColor = System.Drawing.Color.Transparent
		Me._lbl_16.Enabled = True
		Me._lbl_16.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_16.UseMnemonic = True
		Me._lbl_16.Visible = True
		Me._lbl_16.AutoSize = True
		Me._lbl_16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_16.Name = "_lbl_16"
		Me._lbl_15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_15.Text = "Pricing Group:"
		Me._lbl_15.Size = New System.Drawing.Size(67, 13)
		Me._lbl_15.Location = New System.Drawing.Point(14, 90)
		Me._lbl_15.TabIndex = 34
		Me._lbl_15.BackColor = System.Drawing.Color.Transparent
		Me._lbl_15.Enabled = True
		Me._lbl_15.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_15.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_15.UseMnemonic = True
		Me._lbl_15.Visible = True
		Me._lbl_15.AutoSize = True
		Me._lbl_15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_15.Name = "_lbl_15"
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_4.Text = "Sales Channel:"
		Me._lbl_4.Size = New System.Drawing.Size(71, 13)
		Me._lbl_4.Location = New System.Drawing.Point(12, 69)
		Me._lbl_4.TabIndex = 33
		Me._lbl_4.BackColor = System.Drawing.Color.Transparent
		Me._lbl_4.Enabled = True
		Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_4.UseMnemonic = True
		Me._lbl_4.Visible = True
		Me._lbl_4.AutoSize = True
		Me._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_4.Name = "_lbl_4"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "Stock Item:"
		Me._lbl_7.Size = New System.Drawing.Size(54, 13)
		Me._lbl_7.Location = New System.Drawing.Point(29, 51)
		Me._lbl_7.TabIndex = 32
		Me._lbl_7.BackColor = System.Drawing.Color.Transparent
		Me._lbl_7.Enabled = True
		Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_7.UseMnemonic = True
		Me._lbl_7.Visible = True
		Me._lbl_7.AutoSize = True
		Me._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_7.Name = "_lbl_7"
		Me.lblStockItemName.Text = "Label1"
		Me.lblStockItemName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblStockItemName.Size = New System.Drawing.Size(39, 13)
		Me.lblStockItemName.Location = New System.Drawing.Point(87, 51)
		Me.lblStockItemName.TabIndex = 31
		Me.lblStockItemName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStockItemName.BackColor = System.Drawing.Color.Transparent
		Me.lblStockItemName.Enabled = True
		Me.lblStockItemName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblStockItemName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStockItemName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStockItemName.UseMnemonic = True
		Me.lblStockItemName.Visible = True
		Me.lblStockItemName.AutoSize = True
		Me.lblStockItemName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStockItemName.Name = "lblStockItemName"
		Me.lblPricingGroupRule.Text = "Label1"
		Me.lblPricingGroupRule.Size = New System.Drawing.Size(421, 43)
		Me.lblPricingGroupRule.Location = New System.Drawing.Point(87, 108)
		Me.lblPricingGroupRule.TabIndex = 30
		Me.lblPricingGroupRule.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPricingGroupRule.BackColor = System.Drawing.SystemColors.Control
		Me.lblPricingGroupRule.Enabled = True
		Me.lblPricingGroupRule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPricingGroupRule.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPricingGroupRule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPricingGroupRule.UseMnemonic = True
		Me.lblPricingGroupRule.Visible = True
		Me.lblPricingGroupRule.AutoSize = False
		Me.lblPricingGroupRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPricingGroupRule.Name = "lblPricingGroupRule"
		Me.lblPricingGroup.Text = "Label1"
		Me.lblPricingGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPricingGroup.Size = New System.Drawing.Size(39, 13)
		Me.lblPricingGroup.Location = New System.Drawing.Point(87, 90)
		Me.lblPricingGroup.TabIndex = 29
		Me.lblPricingGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPricingGroup.BackColor = System.Drawing.Color.Transparent
		Me.lblPricingGroup.Enabled = True
		Me.lblPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPricingGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPricingGroup.UseMnemonic = True
		Me.lblPricingGroup.Visible = True
		Me.lblPricingGroup.AutoSize = True
		Me.lblPricingGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPricingGroup.Name = "lblPricingGroup"
		Me._lbl_18.Text = "Actual"
		Me._lbl_18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_18.Size = New System.Drawing.Size(37, 13)
		Me._lbl_18.Location = New System.Drawing.Point(3, 390)
		Me._lbl_18.TabIndex = 6
		Me._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_18.BackColor = System.Drawing.Color.Transparent
		Me._lbl_18.Enabled = True
		Me._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_18.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_18.UseMnemonic = True
		Me._lbl_18.Visible = True
		Me._lbl_18.AutoSize = True
		Me._lbl_18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_18.Name = "_lbl_18"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "List Cost:"
		Me._lbl_1.Size = New System.Drawing.Size(88, 13)
		Me._lbl_1.Location = New System.Drawing.Point(-3, 180)
		Me._lbl_1.TabIndex = 19
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = False
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "Unit Deposit:"
		Me._lbl_2.Size = New System.Drawing.Size(88, 13)
		Me._lbl_2.Location = New System.Drawing.Point(-3, 237)
		Me._lbl_2.TabIndex = 18
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = False
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_3.Text = "Case Deposit:"
		Me._lbl_3.Size = New System.Drawing.Size(88, 13)
		Me._lbl_3.Location = New System.Drawing.Point(-3, 255)
		Me._lbl_3.TabIndex = 17
		Me._lbl_3.BackColor = System.Drawing.Color.Transparent
		Me._lbl_3.Enabled = True
		Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_3.UseMnemonic = True
		Me._lbl_3.Visible = True
		Me._lbl_3.AutoSize = False
		Me._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_3.Name = "_lbl_3"
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_5.Text = "Matrix %"
		Me._lbl_5.Size = New System.Drawing.Size(88, 13)
		Me._lbl_5.Location = New System.Drawing.Point(-3, 198)
		Me._lbl_5.TabIndex = 16
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Enabled = True
		Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_5.UseMnemonic = True
		Me._lbl_5.Visible = True
		Me._lbl_5.AutoSize = False
		Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_5.Name = "_lbl_5"
		Me._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_6.Text = "Prop %"
		Me._lbl_6.Size = New System.Drawing.Size(88, 13)
		Me._lbl_6.Location = New System.Drawing.Point(-3, 219)
		Me._lbl_6.TabIndex = 15
		Me._lbl_6.BackColor = System.Drawing.Color.Transparent
		Me._lbl_6.Enabled = True
		Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_6.UseMnemonic = True
		Me._lbl_6.Visible = True
		Me._lbl_6.AutoSize = False
		Me._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_6.Name = "_lbl_6"
		Me.lblVatName.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblVatName.Text = "VAT at 14%"
		Me.lblVatName.Size = New System.Drawing.Size(88, 13)
		Me.lblVatName.Location = New System.Drawing.Point(-3, 273)
		Me.lblVatName.TabIndex = 14
		Me.lblVatName.BackColor = System.Drawing.Color.Transparent
		Me.lblVatName.Enabled = True
		Me.lblVatName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVatName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVatName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVatName.UseMnemonic = True
		Me.lblVatName.Visible = True
		Me.lblVatName.AutoSize = False
		Me.lblVatName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVatName.Name = "lblVatName"
		Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_8.Text = "Markup Price:"
		Me._lbl_8.Size = New System.Drawing.Size(88, 13)
		Me._lbl_8.Location = New System.Drawing.Point(-3, 294)
		Me._lbl_8.TabIndex = 13
		Me._lbl_8.BackColor = System.Drawing.Color.Transparent
		Me._lbl_8.Enabled = True
		Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_8.UseMnemonic = True
		Me._lbl_8.Visible = True
		Me._lbl_8.AutoSize = False
		Me._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_8.Name = "_lbl_8"
		Me._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_9.Text = "Override Price:"
		Me._lbl_9.Size = New System.Drawing.Size(88, 13)
		Me._lbl_9.Location = New System.Drawing.Point(-3, 312)
		Me._lbl_9.TabIndex = 12
		Me._lbl_9.BackColor = System.Drawing.Color.Transparent
		Me._lbl_9.Enabled = True
		Me._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_9.UseMnemonic = True
		Me._lbl_9.Visible = True
		Me._lbl_9.AutoSize = False
		Me._lbl_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_9.Name = "_lbl_9"
		Me._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_10.Text = "Price:"
		Me._lbl_10.Size = New System.Drawing.Size(88, 13)
		Me._lbl_10.Location = New System.Drawing.Point(-3, 333)
		Me._lbl_10.TabIndex = 11
		Me._lbl_10.BackColor = System.Drawing.Color.Transparent
		Me._lbl_10.Enabled = True
		Me._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_10.UseMnemonic = True
		Me._lbl_10.Visible = True
		Me._lbl_10.AutoSize = False
		Me._lbl_10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_10.Name = "_lbl_10"
		Me._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_11.Text = "Markup %:"
		Me._lbl_11.Size = New System.Drawing.Size(88, 13)
		Me._lbl_11.Location = New System.Drawing.Point(-3, 360)
		Me._lbl_11.TabIndex = 10
		Me._lbl_11.BackColor = System.Drawing.Color.Transparent
		Me._lbl_11.Enabled = True
		Me._lbl_11.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_11.UseMnemonic = True
		Me._lbl_11.Visible = True
		Me._lbl_11.AutoSize = False
		Me._lbl_11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_11.Name = "_lbl_11"
		Me._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_12.Text = "Actual Cost:"
		Me._lbl_12.Size = New System.Drawing.Size(88, 13)
		Me._lbl_12.Location = New System.Drawing.Point(-3, 405)
		Me._lbl_12.TabIndex = 9
		Me._lbl_12.BackColor = System.Drawing.Color.Transparent
		Me._lbl_12.Enabled = True
		Me._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_12.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_12.UseMnemonic = True
		Me._lbl_12.Visible = True
		Me._lbl_12.AutoSize = False
		Me._lbl_12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_12.Name = "_lbl_12"
		Me._lbl_13.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_13.Text = "Profit Amount:"
		Me._lbl_13.Size = New System.Drawing.Size(88, 13)
		Me._lbl_13.Location = New System.Drawing.Point(-3, 423)
		Me._lbl_13.TabIndex = 8
		Me._lbl_13.BackColor = System.Drawing.Color.Transparent
		Me._lbl_13.Enabled = True
		Me._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_13.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_13.UseMnemonic = True
		Me._lbl_13.Visible = True
		Me._lbl_13.AutoSize = False
		Me._lbl_13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_13.Name = "_lbl_13"
		Me._lbl_14.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_14.Text = "Markup % "
		Me._lbl_14.Size = New System.Drawing.Size(88, 13)
		Me._lbl_14.Location = New System.Drawing.Point(-3, 441)
		Me._lbl_14.TabIndex = 7
		Me._lbl_14.BackColor = System.Drawing.Color.Transparent
		Me._lbl_14.Enabled = True
		Me._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_14.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_14.UseMnemonic = True
		Me._lbl_14.Visible = True
		Me._lbl_14.AutoSize = False
		Me._lbl_14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_14.Name = "_lbl_14"
		Me._Line1_3.X1 = 81
		Me._Line1_3.X2 = 45
		Me._Line1_3.Y1 = 396
		Me._Line1_3.Y2 = 396
		Me._Line1_3.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Line1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Line1_3.BorderWidth = 1
		Me._Line1_3.Visible = True
		Me._Line1_3.Name = "_Line1_3"
		Me.Controls.Add(txttemphold)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(cmbChannel)
		Me.Controls.Add(_frmItem_0)
		Me.Controls.Add(_lbl_17)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblPriceSet)
		Me.Controls.Add(_lbl_16)
		Me.Controls.Add(_lbl_15)
		Me.Controls.Add(_lbl_4)
		Me.Controls.Add(_lbl_7)
		Me.Controls.Add(lblStockItemName)
		Me.Controls.Add(lblPricingGroupRule)
		Me.Controls.Add(lblPricingGroup)
		Me.Controls.Add(_lbl_18)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_3)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(_lbl_6)
		Me.Controls.Add(lblVatName)
		Me.Controls.Add(_lbl_8)
		Me.Controls.Add(_lbl_9)
		Me.Controls.Add(_lbl_10)
		Me.Controls.Add(_lbl_11)
		Me.Controls.Add(_lbl_12)
		Me.Controls.Add(_lbl_13)
		Me.Controls.Add(_lbl_14)
		Me.ShapeContainer1.Shapes.Add(_Line1_3)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdbarcode)
		Me.picButtons.Controls.Add(cmdHistory)
		Me.picButtons.Controls.Add(cmdDetails)
		Me.picButtons.Controls.Add(cmdExit)
		Me.picButtons.Controls.Add(cmdUndo)
		Me._frmItem_0.Controls.Add(_picLine_0)
		Me._frmItem_0.Controls.Add(_txtCost_0)
		Me._frmItem_0.Controls.Add(_txtProp_0)
		Me._frmItem_0.Controls.Add(_txtPrice_0)
		Me._frmItem_0.Controls.Add(_txtVariableCost_0)
		Me._frmItem_0.Controls.Add(_lblGPActual_0)
		Me._frmItem_0.Controls.Add(_lblGP_0)
		Me._frmItem_0.Controls.Add(_lblSection_0)
		Me.ShapeContainer2.Shapes.Add(_lnProfit_0)
		Me._frmItem_0.Controls.Add(_lblProfitPrecent_0)
		Me._frmItem_0.Controls.Add(_lblProfitAmount_0)
		Me._frmItem_0.Controls.Add(_lblMatrix_0)
		Me._frmItem_0.Controls.Add(_lblDepositUnit_0)
		Me._frmItem_0.Controls.Add(_lblDepositPack_0)
		Me._frmItem_0.Controls.Add(_lblVat_0)
		Me._frmItem_0.Controls.Add(_lblMarkup_0)
		Me._frmItem_0.Controls.Add(_lblPrice_0)
		Me._frmItem_0.Controls.Add(_lblPercent_0)
		Me._frmItem_0.Controls.Add(ShapeContainer2)
        'Me.Line1.SetIndex(_Line1_3, CType(3, Short))
        'Me.frmItem.SetIndex(_frmItem_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_17, CType(17, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_16, CType(16, Short))
        'Me.lbl.SetIndex(_lbl_15, CType(15, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_7, CType(7, Short))
        'Me.lbl.SetIndex(_lbl_18, CType(18, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_6, CType(6, Short))
        'Me.lbl.SetIndex(_lbl_8, CType(8, Short))
        'Me.lbl.SetIndex(_lbl_9, CType(9, Short))
        'Me.lbl.SetIndex(_lbl_10, CType(10, Short))
        'Me.lbl.SetIndex(_lbl_11, CType(11, Short))
        'Me.lbl.SetIndex(_lbl_12, CType(12, Short))
        'Me.lbl.SetIndex(_lbl_13, CType(13, Short))
        'Me.lbl.SetIndex(_lbl_14, CType(14, Short))
        'Me.lblDepositPack.SetIndex(_lblDepositPack_0, CType(0, Short))
        'Me.lblDepositUnit.SetIndex(_lblDepositUnit_0, CType(0, Short))
        'Me.lblGP.SetIndex(_lblGP_0, CType(0, Short))
        'Me.lblGPActual.SetIndex(_lblGPActual_0, CType(0, Short))
        'Me.lblMarkup.SetIndex(_lblMarkup_0, CType(0, Short))
        'Me.lblMatrix.SetIndex(_lblMatrix_0, CType(0, Short))
        'Me.lblPercent.SetIndex(_lblPercent_0, CType(0, Short))
        'Me.lblPrice.SetIndex(_lblPrice_0, CType(0, Short))
        'Me.lblProfitAmount.SetIndex(_lblProfitAmount_0, CType(0, Short))
        'Me.lblProfitPrecent.SetIndex(_lblProfitPrecent_0, CType(0, Short))
        'Me.lblSection.SetIndex(_lblSection_0, CType(0, Short))
        'Me.lblVat.SetIndex(_lblVat_0, CType(0, Short))
        Me.lnProfit.SetIndex(_lnProfit_0, CType(0, Short))
        'Me.picLine.SetIndex(_picLine_0, CType(0, Short))
        'Me.txtCost.SetIndex(_txtCost_0, CType(0, Short))
        'Me.txtPrice.SetIndex(_txtPrice_0, CType(0, Short))
        'Me.txtProp.SetIndex(_txtProp_0, CType(0, Short))
        'Me.txtVariableCost.SetIndex(_txtVariableCost_0, CType(0, Short))
        'CType(Me.txtVariableCost, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtProp, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtPrice, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtCost, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lnProfit, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblVat, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblSection, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblProfitPrecent, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblProfitAmount, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblPrice, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblPercent, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblMarkup, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblGPActual, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblGP, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblDepositUnit, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblDepositPack, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmItem, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me._frmItem_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class