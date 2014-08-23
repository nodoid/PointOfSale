<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVSummaryFnV
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
	Public WithEvents cmdNextFnV As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
    Public WithEvents FGRecipe As myDataGridView
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblRecipeCost As System.Windows.Forms.Label
	Public WithEvents _Frame1_6 As System.Windows.Forms.GroupBox
	Public WithEvents tmrAutoGRV As System.Windows.Forms.Timer
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents txtNotes As System.Windows.Forms.TextBox
	Public WithEvents _optClose_0 As System.Windows.Forms.RadioButton
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents frmProcess As System.Windows.Forms.GroupBox
	Public WithEvents lblDepositReturnIn As System.Windows.Forms.Label
	Public WithEvents _lbl_35 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnVatIn As System.Windows.Forms.Label
	Public WithEvents _lbl_34 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnInclusiveIn As System.Windows.Forms.Label
	Public WithEvents _lbl_33 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnVatRateIn As System.Windows.Forms.Label
	Public WithEvents _Frame1_5 As System.Windows.Forms.GroupBox
	Public WithEvents lblContentOut As System.Windows.Forms.Label
	Public WithEvents lblDiscountLineOut As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents lblExclusiveOut As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents lblVATout As System.Windows.Forms.Label
	Public WithEvents _lbl_12 As System.Windows.Forms.Label
	Public WithEvents lblInclusiveOut As System.Windows.Forms.Label
	Public WithEvents lblVatRateOut As System.Windows.Forms.Label
	Public WithEvents _lbl_37 As System.Windows.Forms.Label
	Public WithEvents lblLinesOut As System.Windows.Forms.Label
	Public WithEvents _Frame1_3 As System.Windows.Forms.GroupBox
	Public WithEvents lblDepositVatRateOut As System.Windows.Forms.Label
	Public WithEvents lblDepositOut As System.Windows.Forms.Label
	Public WithEvents _lbl_9 As System.Windows.Forms.Label
	Public WithEvents lblDepositVatOut As System.Windows.Forms.Label
	Public WithEvents _lbl_23 As System.Windows.Forms.Label
	Public WithEvents lblDepositInclusiveOut As System.Windows.Forms.Label
	Public WithEvents _lbl_24 As System.Windows.Forms.Label
	Public WithEvents _Frame1_4 As System.Windows.Forms.GroupBox
	Public WithEvents lblDepositReturnVatRateOut As System.Windows.Forms.Label
	Public WithEvents _lbl_15 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnInclusiveOut As System.Windows.Forms.Label
	Public WithEvents _lbl_16 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnVatOut As System.Windows.Forms.Label
	Public WithEvents _lbl_17 As System.Windows.Forms.Label
	Public WithEvents lblDepositReturnOut As System.Windows.Forms.Label
	Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
	Public WithEvents cmbPayment As System.Windows.Forms.ComboBox
	Public WithEvents txtUllage As System.Windows.Forms.TextBox
	Public WithEvents txtDiscount As System.Windows.Forms.TextBox
	Public WithEvents txtMinus As System.Windows.Forms.TextBox
	Public WithEvents txtPlus As System.Windows.Forms.TextBox
	Public WithEvents lblContentIn As System.Windows.Forms.Label
	Public WithEvents lblDiscountLineIn As System.Windows.Forms.Label
	Public WithEvents _lbl_20 As System.Windows.Forms.Label
	Public WithEvents _lbl_21 As System.Windows.Forms.Label
	Public WithEvents lblExclusiveIn As System.Windows.Forms.Label
	Public WithEvents _lbl_22 As System.Windows.Forms.Label
	Public WithEvents _lbl_29 As System.Windows.Forms.Label
	Public WithEvents lblVATin As System.Windows.Forms.Label
	Public WithEvents _lbl_30 As System.Windows.Forms.Label
	Public WithEvents lblInclusiveIn As System.Windows.Forms.Label
	Public WithEvents lblVatRateIn As System.Windows.Forms.Label
	Public WithEvents _lbl_19 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents lblDiscount As System.Windows.Forms.Label
	Public WithEvents lblUllage As System.Windows.Forms.Label
	Public WithEvents lblDiscountName As System.Windows.Forms.Label
	Public WithEvents _lbl_31 As System.Windows.Forms.Label
	Public WithEvents lblContentExclusiveIn As System.Windows.Forms.Label
	Public WithEvents _lbl_11 As System.Windows.Forms.Label
	Public WithEvents _lbl_10 As System.Windows.Forms.Label
	Public WithEvents _lbl_32 As System.Windows.Forms.Label
	Public WithEvents lblLinesIn As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents lblDepositVatRateIn As System.Windows.Forms.Label
	Public WithEvents lblDepositIn As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents lblDepositVatIn As System.Windows.Forms.Label
	Public WithEvents _lbl_13 As System.Windows.Forms.Label
	Public WithEvents lblDepositInclusiveIn As System.Windows.Forms.Label
	Public WithEvents _lbl_14 As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _lbl_28 As System.Windows.Forms.Label
	Public WithEvents lblInBoundVat As System.Windows.Forms.Label
	Public WithEvents _lbl_27 As System.Windows.Forms.Label
	Public WithEvents lblInBound As System.Windows.Forms.Label
	Public WithEvents _lbl_26 As System.Windows.Forms.Label
	Public WithEvents lblCreditVat As System.Windows.Forms.Label
	Public WithEvents _lbl_25 As System.Windows.Forms.Label
	Public WithEvents lblCredit As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents lblOutBoundVat As System.Windows.Forms.Label
	Public WithEvents lblOutBound As System.Windows.Forms.Label
	Public WithEvents _lbl_6 As System.Windows.Forms.Label
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblTotalOriginal As System.Windows.Forms.Label
	Public WithEvents lblDifference As System.Windows.Forms.Label
	Public WithEvents _lbl_18 As System.Windows.Forms.Label
	Public WithEvents frmMain As System.Windows.Forms.GroupBox
	Public WithEvents lblSupplier As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optClose As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVSummaryFnV))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdNextFnV = New System.Windows.Forms.Button
		Me._Frame1_6 = New System.Windows.Forms.GroupBox
		Me.cmdNext = New System.Windows.Forms.Button
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.FGRecipe = New myDataGridView
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.lblRecipeCost = New System.Windows.Forms.Label
		Me.tmrAutoGRV = New System.Windows.Forms.Timer(components)
		Me.Picture2 = New System.Windows.Forms.Panel
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.frmProcess = New System.Windows.Forms.GroupBox
		Me.txtNotes = New System.Windows.Forms.TextBox
		Me._optClose_0 = New System.Windows.Forms.RadioButton
		Me.Label3 = New System.Windows.Forms.Label
		Me.frmMain = New System.Windows.Forms.GroupBox
		Me._Frame1_5 = New System.Windows.Forms.GroupBox
		Me.lblDepositReturnIn = New System.Windows.Forms.Label
		Me._lbl_35 = New System.Windows.Forms.Label
		Me.lblDepositReturnVatIn = New System.Windows.Forms.Label
		Me._lbl_34 = New System.Windows.Forms.Label
		Me.lblDepositReturnInclusiveIn = New System.Windows.Forms.Label
		Me._lbl_33 = New System.Windows.Forms.Label
		Me.lblDepositReturnVatRateIn = New System.Windows.Forms.Label
		Me._Frame1_3 = New System.Windows.Forms.GroupBox
		Me.lblContentOut = New System.Windows.Forms.Label
		Me.lblDiscountLineOut = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_3 = New System.Windows.Forms.Label
		Me.lblExclusiveOut = New System.Windows.Forms.Label
		Me._lbl_4 = New System.Windows.Forms.Label
		Me._lbl_5 = New System.Windows.Forms.Label
		Me.lblVATout = New System.Windows.Forms.Label
		Me._lbl_12 = New System.Windows.Forms.Label
		Me.lblInclusiveOut = New System.Windows.Forms.Label
		Me.lblVatRateOut = New System.Windows.Forms.Label
		Me._lbl_37 = New System.Windows.Forms.Label
		Me.lblLinesOut = New System.Windows.Forms.Label
		Me._Frame1_4 = New System.Windows.Forms.GroupBox
		Me.lblDepositVatRateOut = New System.Windows.Forms.Label
		Me.lblDepositOut = New System.Windows.Forms.Label
		Me._lbl_9 = New System.Windows.Forms.Label
		Me.lblDepositVatOut = New System.Windows.Forms.Label
		Me._lbl_23 = New System.Windows.Forms.Label
		Me.lblDepositInclusiveOut = New System.Windows.Forms.Label
		Me._lbl_24 = New System.Windows.Forms.Label
		Me._Frame1_2 = New System.Windows.Forms.GroupBox
		Me.lblDepositReturnVatRateOut = New System.Windows.Forms.Label
		Me._lbl_15 = New System.Windows.Forms.Label
		Me.lblDepositReturnInclusiveOut = New System.Windows.Forms.Label
		Me._lbl_16 = New System.Windows.Forms.Label
		Me.lblDepositReturnVatOut = New System.Windows.Forms.Label
		Me._lbl_17 = New System.Windows.Forms.Label
		Me.lblDepositReturnOut = New System.Windows.Forms.Label
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.cmbPayment = New System.Windows.Forms.ComboBox
		Me.txtUllage = New System.Windows.Forms.TextBox
		Me.txtDiscount = New System.Windows.Forms.TextBox
		Me.txtMinus = New System.Windows.Forms.TextBox
		Me.txtPlus = New System.Windows.Forms.TextBox
		Me.lblContentIn = New System.Windows.Forms.Label
		Me.lblDiscountLineIn = New System.Windows.Forms.Label
		Me._lbl_20 = New System.Windows.Forms.Label
		Me._lbl_21 = New System.Windows.Forms.Label
		Me.lblExclusiveIn = New System.Windows.Forms.Label
		Me._lbl_22 = New System.Windows.Forms.Label
		Me._lbl_29 = New System.Windows.Forms.Label
		Me.lblVATin = New System.Windows.Forms.Label
		Me._lbl_30 = New System.Windows.Forms.Label
		Me.lblInclusiveIn = New System.Windows.Forms.Label
		Me.lblVatRateIn = New System.Windows.Forms.Label
		Me._lbl_19 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.lblDiscount = New System.Windows.Forms.Label
		Me.lblUllage = New System.Windows.Forms.Label
		Me.lblDiscountName = New System.Windows.Forms.Label
		Me._lbl_31 = New System.Windows.Forms.Label
		Me.lblContentExclusiveIn = New System.Windows.Forms.Label
		Me._lbl_11 = New System.Windows.Forms.Label
		Me._lbl_10 = New System.Windows.Forms.Label
		Me._lbl_32 = New System.Windows.Forms.Label
		Me.lblLinesIn = New System.Windows.Forms.Label
		Me._Frame1_1 = New System.Windows.Forms.GroupBox
		Me.lblDepositVatRateIn = New System.Windows.Forms.Label
		Me.lblDepositIn = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me.lblDepositVatIn = New System.Windows.Forms.Label
		Me._lbl_13 = New System.Windows.Forms.Label
		Me.lblDepositInclusiveIn = New System.Windows.Forms.Label
		Me._lbl_14 = New System.Windows.Forms.Label
		Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._lbl_28 = New System.Windows.Forms.Label
		Me.lblInBoundVat = New System.Windows.Forms.Label
		Me._lbl_27 = New System.Windows.Forms.Label
		Me.lblInBound = New System.Windows.Forms.Label
		Me._lbl_26 = New System.Windows.Forms.Label
		Me.lblCreditVat = New System.Windows.Forms.Label
		Me._lbl_25 = New System.Windows.Forms.Label
		Me.lblCredit = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me.lblOutBoundVat = New System.Windows.Forms.Label
		Me.lblOutBound = New System.Windows.Forms.Label
		Me._lbl_6 = New System.Windows.Forms.Label
		Me.lblTotal = New System.Windows.Forms.Label
		Me._lbl_7 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblTotalOriginal = New System.Windows.Forms.Label
		Me.lblDifference = New System.Windows.Forms.Label
		Me._lbl_18 = New System.Windows.Forms.Label
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.lblSupplier = New System.Windows.Forms.Label
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optClose = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me._Frame1_6.SuspendLayout()
		Me.Picture2.SuspendLayout()
		Me.frmProcess.SuspendLayout()
		Me.frmMain.SuspendLayout()
		Me._Frame1_5.SuspendLayout()
		Me._Frame1_3.SuspendLayout()
		Me._Frame1_4.SuspendLayout()
		Me._Frame1_2.SuspendLayout()
		Me._Frame1_0.SuspendLayout()
		Me._Frame1_1.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.FGRecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optClose, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "GRV Summary and Process - Fruit and Veg"
		Me.ClientSize = New System.Drawing.Size(760, 684)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmGRVSummaryFnV"
		Me.cmdNextFnV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNextFnV.Text = "P&rocess"
		Me.cmdNextFnV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNextFnV.Size = New System.Drawing.Size(139, 55)
		Me.cmdNextFnV.Location = New System.Drawing.Point(840, 560)
		Me.cmdNextFnV.TabIndex = 108
		Me.cmdNextFnV.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNextFnV.CausesValidation = True
		Me.cmdNextFnV.Enabled = True
		Me.cmdNextFnV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNextFnV.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNextFnV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNextFnV.TabStop = True
		Me.cmdNextFnV.Name = "cmdNextFnV"
		Me._Frame1_6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_6.Size = New System.Drawing.Size(988, 547)
		Me._Frame1_6.Location = New System.Drawing.Point(8, 88)
		Me._Frame1_6.TabIndex = 104
		Me._Frame1_6.Visible = False
		Me._Frame1_6.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_6.Enabled = True
		Me._Frame1_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_6.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_6.Name = "_Frame1_6"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "Finish"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(139, 55)
		Me.cmdNext.Location = New System.Drawing.Point(520, 24)
		Me.cmdNext.TabIndex = 112
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.Text1.AutoSize = False
		Me.Text1.Size = New System.Drawing.Size(41, 25)
		Me.Text1.Location = New System.Drawing.Point(256, 392)
		Me.Text1.TabIndex = 111
		Me.Text1.Text = "0"
		Me.Text1.Visible = False
		Me.Text1.AcceptsReturn = True
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.CausesValidation = True
		Me.Text1.Enabled = True
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.HideSelection = True
		Me.Text1.ReadOnly = False
		Me.Text1.Maxlength = 0
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.MultiLine = False
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text1.TabStop = True
		Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text1.Name = "Text1"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Next >>"
		Me.Command2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Command2.Size = New System.Drawing.Size(73, 40)
		Me.Command2.Location = New System.Drawing.Point(584, 384)
		Me.Command2.TabIndex = 110
		Me.Command2.TabStop = False
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "<< &Back"
		Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Command1.Size = New System.Drawing.Size(73, 40)
		Me.Command1.Location = New System.Drawing.Point(16, 384)
		Me.Command1.TabIndex = 109
		Me.Command1.TabStop = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.Name = "Command1"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtQuantity.Size = New System.Drawing.Size(64, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(168, 368)
		Me.txtQuantity.TabIndex = 105
		Me.txtQuantity.Text = "Text1"
		Me.txtQuantity.Visible = False
		Me.txtQuantity.AcceptsReturn = True
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
		Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtQuantity.Name = "txtQuantity"
        'FGRecipe.OcxState = CType(resources.GetObject("FGRecipe.OcxState"), System.Windows.Forms.AxHost.State)
		Me.FGRecipe.Size = New System.Drawing.Size(646, 273)
		Me.FGRecipe.Location = New System.Drawing.Point(14, 90)
		Me.FGRecipe.TabIndex = 106
		Me.FGRecipe.Name = "FGRecipe"
		Me.Label5.Text = "-"
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Size = New System.Drawing.Size(505, 25)
		Me.Label5.Location = New System.Drawing.Point(16, 56)
		Me.Label5.TabIndex = 114
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "BILL OF MATERIAL for :"
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Size = New System.Drawing.Size(265, 25)
		Me.Label4.Location = New System.Drawing.Point(16, 24)
		Me.Label4.TabIndex = 113
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.lblRecipeCost.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblRecipeCost.Text = "0.00"
		Me.lblRecipeCost.Size = New System.Drawing.Size(88, 19)
		Me.lblRecipeCost.Location = New System.Drawing.Point(416, 365)
		Me.lblRecipeCost.TabIndex = 107
		Me.lblRecipeCost.Visible = False
		Me.lblRecipeCost.BackColor = System.Drawing.SystemColors.Control
		Me.lblRecipeCost.Enabled = True
		Me.lblRecipeCost.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRecipeCost.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRecipeCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRecipeCost.UseMnemonic = True
		Me.lblRecipeCost.AutoSize = False
		Me.lblRecipeCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRecipeCost.Name = "lblRecipeCost"
		Me.tmrAutoGRV.Enabled = False
		Me.tmrAutoGRV.Interval = 10
		Me.Picture2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture2.BackColor = System.Drawing.Color.Blue
		Me.Picture2.Size = New System.Drawing.Size(760, 49)
		Me.Picture2.Location = New System.Drawing.Point(0, 0)
		Me.Picture2.TabIndex = 101
		Me.Picture2.TabStop = False
		Me.Picture2.CausesValidation = True
		Me.Picture2.Enabled = True
		Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture2.Visible = True
		Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture2.Name = "Picture2"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(73, 40)
		Me.cmdExit.Location = New System.Drawing.Point(627, 3)
		Me.cmdExit.TabIndex = 103
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "<< &Back"
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(73, 40)
		Me.cmdBack.Location = New System.Drawing.Point(426, 3)
		Me.cmdBack.TabIndex = 102
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me.frmProcess.Text = "Process this 'Goods Receiving Voucher'"
		Me.frmProcess.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmProcess.Size = New System.Drawing.Size(343, 271)
		Me.frmProcess.Location = New System.Drawing.Point(657, 363)
		Me.frmProcess.TabIndex = 3
		Me.frmProcess.BackColor = System.Drawing.SystemColors.Control
		Me.frmProcess.Enabled = True
		Me.frmProcess.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmProcess.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmProcess.Visible = True
		Me.frmProcess.Padding = New System.Windows.Forms.Padding(0)
		Me.frmProcess.Name = "frmProcess"
		Me.txtNotes.AutoSize = False
		Me.txtNotes.Size = New System.Drawing.Size(301, 85)
		Me.txtNotes.Location = New System.Drawing.Point(21, 102)
		Me.txtNotes.Maxlength = 255
		Me.txtNotes.MultiLine = True
		Me.txtNotes.TabIndex = 6
		Me.txtNotes.Text = "txtNotes"
		Me.txtNotes.AcceptsReturn = True
		Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNotes.BackColor = System.Drawing.SystemColors.Window
		Me.txtNotes.CausesValidation = True
		Me.txtNotes.Enabled = True
		Me.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNotes.HideSelection = True
		Me.txtNotes.ReadOnly = False
		Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNotes.TabStop = True
		Me.txtNotes.Visible = True
		Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNotes.Name = "txtNotes"
		Me._optClose_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optClose_0.Text = "This Purchase Order has been delivered in full."
		Me._optClose_0.Size = New System.Drawing.Size(310, 19)
		Me._optClose_0.Location = New System.Drawing.Point(18, 18)
		Me._optClose_0.TabIndex = 4
		Me._optClose_0.Checked = True
		Me._optClose_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optClose_0.BackColor = System.Drawing.SystemColors.Control
		Me._optClose_0.CausesValidation = True
		Me._optClose_0.Enabled = True
		Me._optClose_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optClose_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optClose_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optClose_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optClose_0.TabStop = True
		Me._optClose_0.Visible = True
		Me._optClose_0.Name = "_optClose_0"
		Me.Label3.Text = "Notes:"
		Me.Label3.Size = New System.Drawing.Size(31, 13)
		Me.Label3.Location = New System.Drawing.Point(21, 84)
		Me.Label3.TabIndex = 5
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = True
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.frmMain.Text = "fmHeading"
		Me.frmMain.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmMain.Size = New System.Drawing.Size(631, 550)
		Me.frmMain.Location = New System.Drawing.Point(3, 84)
		Me.frmMain.TabIndex = 10
		Me.frmMain.BackColor = System.Drawing.SystemColors.Control
		Me.frmMain.Enabled = True
		Me.frmMain.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmMain.Visible = True
		Me.frmMain.Padding = New System.Windows.Forms.Padding(0)
		Me.frmMain.Name = "frmMain"
		Me._Frame1_5.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Frame1_5.Text = "Purchased Deposits"
		Me._Frame1_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_5.Size = New System.Drawing.Size(301, 79)
		Me._Frame1_5.Location = New System.Drawing.Point(9, 375)
		Me._Frame1_5.TabIndex = 93
		Me._Frame1_5.Enabled = True
		Me._Frame1_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_5.Visible = True
		Me._Frame1_5.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_5.Name = "_Frame1_5"
		Me.lblDepositReturnIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnIn.Text = "0.00"
		Me.lblDepositReturnIn.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnIn.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositReturnIn.Location = New System.Drawing.Point(150, 18)
		Me.lblDepositReturnIn.TabIndex = 100
		Me.lblDepositReturnIn.Enabled = True
		Me.lblDepositReturnIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnIn.UseMnemonic = True
		Me.lblDepositReturnIn.Visible = True
		Me.lblDepositReturnIn.AutoSize = False
		Me.lblDepositReturnIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnIn.Name = "lblDepositReturnIn"
		Me._lbl_35.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_35.Text = "Deposit Value:"
		Me._lbl_35.ForeColor = System.Drawing.Color.Black
		Me._lbl_35.Size = New System.Drawing.Size(133, 13)
		Me._lbl_35.Location = New System.Drawing.Point(16, 21)
		Me._lbl_35.TabIndex = 99
		Me._lbl_35.BackColor = System.Drawing.Color.Transparent
		Me._lbl_35.Enabled = True
		Me._lbl_35.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_35.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_35.UseMnemonic = True
		Me._lbl_35.Visible = True
		Me._lbl_35.AutoSize = False
		Me._lbl_35.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_35.Name = "_lbl_35"
		Me.lblDepositReturnVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnVatIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnVatIn.Text = "0.00"
		Me.lblDepositReturnVatIn.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnVatIn.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositReturnVatIn.Location = New System.Drawing.Point(150, 36)
		Me.lblDepositReturnVatIn.TabIndex = 98
		Me.lblDepositReturnVatIn.Enabled = True
		Me.lblDepositReturnVatIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnVatIn.UseMnemonic = True
		Me.lblDepositReturnVatIn.Visible = True
		Me.lblDepositReturnVatIn.AutoSize = False
		Me.lblDepositReturnVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnVatIn.Name = "lblDepositReturnVatIn"
		Me._lbl_34.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_34.Text = "VAT:"
		Me._lbl_34.ForeColor = System.Drawing.Color.Black
		Me._lbl_34.Size = New System.Drawing.Size(133, 13)
		Me._lbl_34.Location = New System.Drawing.Point(16, 39)
		Me._lbl_34.TabIndex = 97
		Me._lbl_34.BackColor = System.Drawing.Color.Transparent
		Me._lbl_34.Enabled = True
		Me._lbl_34.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_34.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_34.UseMnemonic = True
		Me._lbl_34.Visible = True
		Me._lbl_34.AutoSize = False
		Me._lbl_34.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_34.Name = "_lbl_34"
		Me.lblDepositReturnInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnInclusiveIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnInclusiveIn.Text = "0.00"
		Me.lblDepositReturnInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositReturnInclusiveIn.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnInclusiveIn.Size = New System.Drawing.Size(91, 19)
		Me.lblDepositReturnInclusiveIn.Location = New System.Drawing.Point(150, 54)
		Me.lblDepositReturnInclusiveIn.TabIndex = 96
		Me.lblDepositReturnInclusiveIn.Enabled = True
		Me.lblDepositReturnInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnInclusiveIn.UseMnemonic = True
		Me.lblDepositReturnInclusiveIn.Visible = True
		Me.lblDepositReturnInclusiveIn.AutoSize = False
		Me.lblDepositReturnInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnInclusiveIn.Name = "lblDepositReturnInclusiveIn"
		Me._lbl_33.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_33.Text = "Inclusive:"
		Me._lbl_33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_33.ForeColor = System.Drawing.Color.Black
		Me._lbl_33.Size = New System.Drawing.Size(133, 13)
		Me._lbl_33.Location = New System.Drawing.Point(16, 57)
		Me._lbl_33.TabIndex = 95
		Me._lbl_33.BackColor = System.Drawing.Color.Transparent
		Me._lbl_33.Enabled = True
		Me._lbl_33.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_33.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_33.UseMnemonic = True
		Me._lbl_33.Visible = True
		Me._lbl_33.AutoSize = False
		Me._lbl_33.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_33.Name = "_lbl_33"
		Me.lblDepositReturnVatRateIn.Text = "0.00"
		Me.lblDepositReturnVatRateIn.Size = New System.Drawing.Size(55, 16)
		Me.lblDepositReturnVatRateIn.Location = New System.Drawing.Point(243, 39)
		Me.lblDepositReturnVatRateIn.TabIndex = 94
		Me.lblDepositReturnVatRateIn.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDepositReturnVatRateIn.BackColor = System.Drawing.Color.Transparent
		Me.lblDepositReturnVatRateIn.Enabled = True
		Me.lblDepositReturnVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositReturnVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnVatRateIn.UseMnemonic = True
		Me.lblDepositReturnVatRateIn.Visible = True
		Me.lblDepositReturnVatRateIn.AutoSize = False
		Me.lblDepositReturnVatRateIn.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDepositReturnVatRateIn.Name = "lblDepositReturnVatRateIn"
		Me._Frame1_3.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Frame1_3.Text = "Credited Content / Liquid"
		Me._Frame1_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_3.Size = New System.Drawing.Size(301, 145)
		Me._Frame1_3.Location = New System.Drawing.Point(318, 18)
		Me._Frame1_3.TabIndex = 68
		Me._Frame1_3.Enabled = True
		Me._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_3.Visible = True
		Me._Frame1_3.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_3.Name = "_Frame1_3"
		Me.lblContentOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblContentOut.Text = "0.00"
		Me.lblContentOut.Size = New System.Drawing.Size(91, 19)
		Me.lblContentOut.Location = New System.Drawing.Point(153, 33)
		Me.lblContentOut.TabIndex = 81
		Me.lblContentOut.Enabled = True
		Me.lblContentOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentOut.UseMnemonic = True
		Me.lblContentOut.Visible = True
		Me.lblContentOut.AutoSize = False
		Me.lblContentOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentOut.Name = "lblContentOut"
		Me.lblDiscountLineOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDiscountLineOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDiscountLineOut.Text = "0.00"
		Me.lblDiscountLineOut.Size = New System.Drawing.Size(91, 19)
		Me.lblDiscountLineOut.Location = New System.Drawing.Point(153, 54)
		Me.lblDiscountLineOut.TabIndex = 80
		Me.lblDiscountLineOut.Enabled = True
		Me.lblDiscountLineOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDiscountLineOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDiscountLineOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDiscountLineOut.UseMnemonic = True
		Me.lblDiscountLineOut.Visible = True
		Me.lblDiscountLineOut.AutoSize = False
		Me.lblDiscountLineOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDiscountLineOut.Name = "lblDiscountLineOut"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "Contents Value :"
		Me._lbl_1.Size = New System.Drawing.Size(133, 13)
		Me._lbl_1.Location = New System.Drawing.Point(18, 36)
		Me._lbl_1.TabIndex = 79
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
		Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_3.Text = "Line Item Discount :"
		Me._lbl_3.Size = New System.Drawing.Size(133, 13)
		Me._lbl_3.Location = New System.Drawing.Point(18, 57)
		Me._lbl_3.TabIndex = 78
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
		Me.lblExclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblExclusiveOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblExclusiveOut.Text = "0.00"
		Me.lblExclusiveOut.Size = New System.Drawing.Size(91, 19)
		Me.lblExclusiveOut.Location = New System.Drawing.Point(153, 75)
		Me.lblExclusiveOut.TabIndex = 77
		Me.lblExclusiveOut.Enabled = True
		Me.lblExclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblExclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblExclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblExclusiveOut.UseMnemonic = True
		Me.lblExclusiveOut.Visible = True
		Me.lblExclusiveOut.AutoSize = False
		Me.lblExclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblExclusiveOut.Name = "lblExclusiveOut"
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_4.Text = "Exclusive:"
		Me._lbl_4.Size = New System.Drawing.Size(133, 13)
		Me._lbl_4.Location = New System.Drawing.Point(18, 78)
		Me._lbl_4.TabIndex = 76
		Me._lbl_4.BackColor = System.Drawing.Color.Transparent
		Me._lbl_4.Enabled = True
		Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_4.UseMnemonic = True
		Me._lbl_4.Visible = True
		Me._lbl_4.AutoSize = False
		Me._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_4.Name = "_lbl_4"
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_5.Text = "VAT :"
		Me._lbl_5.Size = New System.Drawing.Size(133, 13)
		Me._lbl_5.Location = New System.Drawing.Point(18, 99)
		Me._lbl_5.TabIndex = 75
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
		Me.lblVATout.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblVATout.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblVATout.Text = "0.00"
		Me.lblVATout.Size = New System.Drawing.Size(91, 19)
		Me.lblVATout.Location = New System.Drawing.Point(153, 96)
		Me.lblVATout.TabIndex = 74
		Me.lblVATout.Enabled = True
		Me.lblVATout.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVATout.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVATout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVATout.UseMnemonic = True
		Me.lblVATout.Visible = True
		Me.lblVATout.AutoSize = False
		Me.lblVATout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblVATout.Name = "lblVATout"
		Me._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_12.Text = "Inclusive:"
		Me._lbl_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_12.Size = New System.Drawing.Size(133, 13)
		Me._lbl_12.Location = New System.Drawing.Point(18, 120)
		Me._lbl_12.TabIndex = 73
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
		Me.lblInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInclusiveOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblInclusiveOut.Text = "0.00"
		Me.lblInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInclusiveOut.Size = New System.Drawing.Size(91, 19)
		Me.lblInclusiveOut.Location = New System.Drawing.Point(153, 117)
		Me.lblInclusiveOut.TabIndex = 72
		Me.lblInclusiveOut.Enabled = True
		Me.lblInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInclusiveOut.UseMnemonic = True
		Me.lblInclusiveOut.Visible = True
		Me.lblInclusiveOut.AutoSize = False
		Me.lblInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblInclusiveOut.Name = "lblInclusiveOut"
		Me.lblVatRateOut.Text = "lblVatRateOut"
		Me.lblVatRateOut.Size = New System.Drawing.Size(55, 16)
		Me.lblVatRateOut.Location = New System.Drawing.Point(246, 99)
		Me.lblVatRateOut.TabIndex = 71
		Me.lblVatRateOut.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblVatRateOut.BackColor = System.Drawing.Color.Transparent
		Me.lblVatRateOut.Enabled = True
		Me.lblVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVatRateOut.UseMnemonic = True
		Me.lblVatRateOut.Visible = True
		Me.lblVatRateOut.AutoSize = False
		Me.lblVatRateOut.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVatRateOut.Name = "lblVatRateOut"
		Me._lbl_37.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_37.Text = "No Of Lines :"
		Me._lbl_37.Size = New System.Drawing.Size(133, 13)
		Me._lbl_37.Location = New System.Drawing.Point(18, 15)
		Me._lbl_37.TabIndex = 70
		Me._lbl_37.BackColor = System.Drawing.Color.Transparent
		Me._lbl_37.Enabled = True
		Me._lbl_37.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_37.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_37.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_37.UseMnemonic = True
		Me._lbl_37.Visible = True
		Me._lbl_37.AutoSize = False
		Me._lbl_37.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_37.Name = "_lbl_37"
		Me.lblLinesOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLinesOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblLinesOut.Text = "0.00"
		Me.lblLinesOut.Size = New System.Drawing.Size(91, 19)
		Me.lblLinesOut.Location = New System.Drawing.Point(153, 12)
		Me.lblLinesOut.TabIndex = 69
		Me.lblLinesOut.Enabled = True
		Me.lblLinesOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLinesOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLinesOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLinesOut.UseMnemonic = True
		Me.lblLinesOut.Visible = True
		Me.lblLinesOut.AutoSize = False
		Me.lblLinesOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLinesOut.Name = "lblLinesOut"
		Me._Frame1_4.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Frame1_4.Text = "Deposits with Credits"
		Me._Frame1_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_4.Size = New System.Drawing.Size(301, 82)
		Me._Frame1_4.Location = New System.Drawing.Point(318, 162)
		Me._Frame1_4.TabIndex = 60
		Me._Frame1_4.Enabled = True
		Me._Frame1_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_4.Visible = True
		Me._Frame1_4.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_4.Name = "_Frame1_4"
		Me.lblDepositVatRateOut.Text = "0.00"
		Me.lblDepositVatRateOut.Size = New System.Drawing.Size(55, 16)
		Me.lblDepositVatRateOut.Location = New System.Drawing.Point(243, 39)
		Me.lblDepositVatRateOut.TabIndex = 67
		Me.lblDepositVatRateOut.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDepositVatRateOut.BackColor = System.Drawing.Color.Transparent
		Me.lblDepositVatRateOut.Enabled = True
		Me.lblDepositVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositVatRateOut.UseMnemonic = True
		Me.lblDepositVatRateOut.Visible = True
		Me.lblDepositVatRateOut.AutoSize = False
		Me.lblDepositVatRateOut.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDepositVatRateOut.Name = "lblDepositVatRateOut"
		Me.lblDepositOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositOut.Text = "0.00"
		Me.lblDepositOut.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositOut.Location = New System.Drawing.Point(150, 18)
		Me.lblDepositOut.TabIndex = 66
		Me.lblDepositOut.Enabled = True
		Me.lblDepositOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositOut.UseMnemonic = True
		Me.lblDepositOut.Visible = True
		Me.lblDepositOut.AutoSize = False
		Me.lblDepositOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositOut.Name = "lblDepositOut"
		Me._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_9.Text = "Deposit Value:"
		Me._lbl_9.Size = New System.Drawing.Size(133, 13)
		Me._lbl_9.Location = New System.Drawing.Point(16, 21)
		Me._lbl_9.TabIndex = 65
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
		Me.lblDepositVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositVatOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositVatOut.Text = "0.00"
		Me.lblDepositVatOut.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositVatOut.Location = New System.Drawing.Point(150, 36)
		Me.lblDepositVatOut.TabIndex = 64
		Me.lblDepositVatOut.Enabled = True
		Me.lblDepositVatOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositVatOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositVatOut.UseMnemonic = True
		Me.lblDepositVatOut.Visible = True
		Me.lblDepositVatOut.AutoSize = False
		Me.lblDepositVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositVatOut.Name = "lblDepositVatOut"
		Me._lbl_23.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_23.Text = "VAT:"
		Me._lbl_23.Size = New System.Drawing.Size(133, 13)
		Me._lbl_23.Location = New System.Drawing.Point(16, 39)
		Me._lbl_23.TabIndex = 63
		Me._lbl_23.BackColor = System.Drawing.Color.Transparent
		Me._lbl_23.Enabled = True
		Me._lbl_23.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_23.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_23.UseMnemonic = True
		Me._lbl_23.Visible = True
		Me._lbl_23.AutoSize = False
		Me._lbl_23.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_23.Name = "_lbl_23"
		Me.lblDepositInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositInclusiveOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositInclusiveOut.Text = "0.00"
		Me.lblDepositInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositInclusiveOut.Size = New System.Drawing.Size(91, 19)
		Me.lblDepositInclusiveOut.Location = New System.Drawing.Point(150, 54)
		Me.lblDepositInclusiveOut.TabIndex = 62
		Me.lblDepositInclusiveOut.Enabled = True
		Me.lblDepositInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositInclusiveOut.UseMnemonic = True
		Me.lblDepositInclusiveOut.Visible = True
		Me.lblDepositInclusiveOut.AutoSize = False
		Me.lblDepositInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositInclusiveOut.Name = "lblDepositInclusiveOut"
		Me._lbl_24.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_24.Text = "Inclusive:"
		Me._lbl_24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_24.Size = New System.Drawing.Size(133, 13)
		Me._lbl_24.Location = New System.Drawing.Point(16, 57)
		Me._lbl_24.TabIndex = 61
		Me._lbl_24.BackColor = System.Drawing.Color.Transparent
		Me._lbl_24.Enabled = True
		Me._lbl_24.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_24.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_24.UseMnemonic = True
		Me._lbl_24.Visible = True
		Me._lbl_24.AutoSize = False
		Me._lbl_24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_24.Name = "_lbl_24"
		Me._Frame1_2.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Frame1_2.Text = "Returned Deposits"
		Me._Frame1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_2.Size = New System.Drawing.Size(301, 79)
		Me._Frame1_2.Location = New System.Drawing.Point(321, 375)
		Me._Frame1_2.TabIndex = 21
		Me._Frame1_2.Enabled = True
		Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_2.Visible = True
		Me._Frame1_2.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_2.Name = "_Frame1_2"
		Me.lblDepositReturnVatRateOut.Text = "0.00"
		Me.lblDepositReturnVatRateOut.Size = New System.Drawing.Size(55, 16)
		Me.lblDepositReturnVatRateOut.Location = New System.Drawing.Point(243, 39)
		Me.lblDepositReturnVatRateOut.TabIndex = 82
		Me.lblDepositReturnVatRateOut.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDepositReturnVatRateOut.BackColor = System.Drawing.Color.Transparent
		Me.lblDepositReturnVatRateOut.Enabled = True
		Me.lblDepositReturnVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositReturnVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnVatRateOut.UseMnemonic = True
		Me.lblDepositReturnVatRateOut.Visible = True
		Me.lblDepositReturnVatRateOut.AutoSize = False
		Me.lblDepositReturnVatRateOut.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDepositReturnVatRateOut.Name = "lblDepositReturnVatRateOut"
		Me._lbl_15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_15.Text = "Inclusive:"
		Me._lbl_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_15.ForeColor = System.Drawing.Color.Black
		Me._lbl_15.Size = New System.Drawing.Size(133, 13)
		Me._lbl_15.Location = New System.Drawing.Point(16, 57)
		Me._lbl_15.TabIndex = 26
		Me._lbl_15.BackColor = System.Drawing.Color.Transparent
		Me._lbl_15.Enabled = True
		Me._lbl_15.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_15.UseMnemonic = True
		Me._lbl_15.Visible = True
		Me._lbl_15.AutoSize = False
		Me._lbl_15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_15.Name = "_lbl_15"
		Me.lblDepositReturnInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnInclusiveOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnInclusiveOut.Text = "0.00"
		Me.lblDepositReturnInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositReturnInclusiveOut.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnInclusiveOut.Size = New System.Drawing.Size(91, 19)
		Me.lblDepositReturnInclusiveOut.Location = New System.Drawing.Point(150, 54)
		Me.lblDepositReturnInclusiveOut.TabIndex = 27
		Me.lblDepositReturnInclusiveOut.Enabled = True
		Me.lblDepositReturnInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnInclusiveOut.UseMnemonic = True
		Me.lblDepositReturnInclusiveOut.Visible = True
		Me.lblDepositReturnInclusiveOut.AutoSize = False
		Me.lblDepositReturnInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnInclusiveOut.Name = "lblDepositReturnInclusiveOut"
		Me._lbl_16.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_16.Text = "VAT:"
		Me._lbl_16.ForeColor = System.Drawing.Color.Black
		Me._lbl_16.Size = New System.Drawing.Size(133, 13)
		Me._lbl_16.Location = New System.Drawing.Point(16, 39)
		Me._lbl_16.TabIndex = 24
		Me._lbl_16.BackColor = System.Drawing.Color.Transparent
		Me._lbl_16.Enabled = True
		Me._lbl_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_16.UseMnemonic = True
		Me._lbl_16.Visible = True
		Me._lbl_16.AutoSize = False
		Me._lbl_16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_16.Name = "_lbl_16"
		Me.lblDepositReturnVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnVatOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnVatOut.Text = "0.00"
		Me.lblDepositReturnVatOut.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnVatOut.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositReturnVatOut.Location = New System.Drawing.Point(150, 36)
		Me.lblDepositReturnVatOut.TabIndex = 25
		Me.lblDepositReturnVatOut.Enabled = True
		Me.lblDepositReturnVatOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnVatOut.UseMnemonic = True
		Me.lblDepositReturnVatOut.Visible = True
		Me.lblDepositReturnVatOut.AutoSize = False
		Me.lblDepositReturnVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnVatOut.Name = "lblDepositReturnVatOut"
		Me._lbl_17.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_17.Text = "Deposit Value:"
		Me._lbl_17.ForeColor = System.Drawing.Color.Black
		Me._lbl_17.Size = New System.Drawing.Size(133, 13)
		Me._lbl_17.Location = New System.Drawing.Point(16, 21)
		Me._lbl_17.TabIndex = 22
		Me._lbl_17.BackColor = System.Drawing.Color.Transparent
		Me._lbl_17.Enabled = True
		Me._lbl_17.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_17.UseMnemonic = True
		Me._lbl_17.Visible = True
		Me._lbl_17.AutoSize = False
		Me._lbl_17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_17.Name = "_lbl_17"
		Me.lblDepositReturnOut.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositReturnOut.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositReturnOut.Text = "0.00"
		Me.lblDepositReturnOut.ForeColor = System.Drawing.Color.Black
		Me.lblDepositReturnOut.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositReturnOut.Location = New System.Drawing.Point(150, 18)
		Me.lblDepositReturnOut.TabIndex = 23
		Me.lblDepositReturnOut.Enabled = True
		Me.lblDepositReturnOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositReturnOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositReturnOut.UseMnemonic = True
		Me.lblDepositReturnOut.Visible = True
		Me.lblDepositReturnOut.AutoSize = False
		Me.lblDepositReturnOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositReturnOut.Name = "lblDepositReturnOut"
		Me._Frame1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Frame1_0.Text = "Purchased Content / Liquid"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(301, 268)
		Me._Frame1_0.Location = New System.Drawing.Point(9, 18)
		Me._Frame1_0.TabIndex = 11
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.cmbPayment.Size = New System.Drawing.Size(91, 21)
		Me.cmbPayment.Location = New System.Drawing.Point(153, 96)
		Me.cmbPayment.Items.AddRange(New Object(){"C.O.D.", "15 Days", "30 Days", "60 Days", "90 Days", "120 Days", "Smart Card"})
		Me.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPayment.TabIndex = 0
		Me.cmbPayment.BackColor = System.Drawing.SystemColors.Window
		Me.cmbPayment.CausesValidation = True
		Me.cmbPayment.Enabled = True
		Me.cmbPayment.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbPayment.IntegralHeight = True
		Me.cmbPayment.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbPayment.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbPayment.Sorted = False
		Me.cmbPayment.TabStop = True
		Me.cmbPayment.Visible = True
		Me.cmbPayment.Name = "cmbPayment"
		Me.txtUllage.AutoSize = False
		Me.txtUllage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtUllage.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.txtUllage.Enabled = False
		Me.txtUllage.ForeColor = System.Drawing.Color.Red
		Me.txtUllage.Size = New System.Drawing.Size(40, 19)
		Me.txtUllage.Location = New System.Drawing.Point(99, 135)
		Me.txtUllage.TabIndex = 7
		Me.txtUllage.Text = "0.20"
		Me.txtUllage.AcceptsReturn = True
		Me.txtUllage.CausesValidation = True
		Me.txtUllage.HideSelection = True
		Me.txtUllage.ReadOnly = False
		Me.txtUllage.Maxlength = 0
		Me.txtUllage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUllage.MultiLine = False
		Me.txtUllage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUllage.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUllage.TabStop = True
		Me.txtUllage.Visible = True
		Me.txtUllage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtUllage.Name = "txtUllage"
		Me.txtDiscount.AutoSize = False
		Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtDiscount.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.txtDiscount.Enabled = False
		Me.txtDiscount.ForeColor = System.Drawing.Color.Red
		Me.txtDiscount.Size = New System.Drawing.Size(40, 19)
		Me.txtDiscount.Location = New System.Drawing.Point(99, 117)
		Me.txtDiscount.TabIndex = 34
		Me.txtDiscount.TabStop = False
		Me.txtDiscount.Text = "2.00"
		Me.txtDiscount.AcceptsReturn = True
		Me.txtDiscount.CausesValidation = True
		Me.txtDiscount.HideSelection = True
		Me.txtDiscount.ReadOnly = False
		Me.txtDiscount.Maxlength = 0
		Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDiscount.MultiLine = False
		Me.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDiscount.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDiscount.Visible = True
		Me.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDiscount.Name = "txtDiscount"
		Me.txtMinus.AutoSize = False
		Me.txtMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtMinus.ForeColor = System.Drawing.Color.Red
		Me.txtMinus.Size = New System.Drawing.Size(91, 19)
		Me.txtMinus.Location = New System.Drawing.Point(153, 180)
		Me.txtMinus.TabIndex = 2
		Me.txtMinus.Text = "0.00"
		Me.txtMinus.AcceptsReturn = True
		Me.txtMinus.BackColor = System.Drawing.SystemColors.Window
		Me.txtMinus.CausesValidation = True
		Me.txtMinus.Enabled = True
		Me.txtMinus.HideSelection = True
		Me.txtMinus.ReadOnly = False
		Me.txtMinus.Maxlength = 0
		Me.txtMinus.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMinus.MultiLine = False
		Me.txtMinus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMinus.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMinus.TabStop = True
		Me.txtMinus.Visible = True
		Me.txtMinus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMinus.Name = "txtMinus"
		Me.txtPlus.AutoSize = False
		Me.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPlus.Size = New System.Drawing.Size(91, 19)
		Me.txtPlus.Location = New System.Drawing.Point(153, 159)
		Me.txtPlus.TabIndex = 1
		Me.txtPlus.Text = "0.00"
		Me.txtPlus.AcceptsReturn = True
		Me.txtPlus.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlus.CausesValidation = True
		Me.txtPlus.Enabled = True
		Me.txtPlus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlus.HideSelection = True
		Me.txtPlus.ReadOnly = False
		Me.txtPlus.Maxlength = 0
		Me.txtPlus.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlus.MultiLine = False
		Me.txtPlus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlus.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlus.TabStop = True
		Me.txtPlus.Visible = True
		Me.txtPlus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlus.Name = "txtPlus"
		Me.lblContentIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblContentIn.Text = "0.00"
		Me.lblContentIn.Size = New System.Drawing.Size(91, 19)
		Me.lblContentIn.Location = New System.Drawing.Point(153, 33)
		Me.lblContentIn.TabIndex = 58
		Me.lblContentIn.Enabled = True
		Me.lblContentIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentIn.UseMnemonic = True
		Me.lblContentIn.Visible = True
		Me.lblContentIn.AutoSize = False
		Me.lblContentIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentIn.Name = "lblContentIn"
		Me.lblDiscountLineIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDiscountLineIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDiscountLineIn.Text = "0.00"
		Me.lblDiscountLineIn.Size = New System.Drawing.Size(91, 19)
		Me.lblDiscountLineIn.Location = New System.Drawing.Point(153, 54)
		Me.lblDiscountLineIn.TabIndex = 57
		Me.lblDiscountLineIn.Enabled = True
		Me.lblDiscountLineIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDiscountLineIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDiscountLineIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDiscountLineIn.UseMnemonic = True
		Me.lblDiscountLineIn.Visible = True
		Me.lblDiscountLineIn.AutoSize = False
		Me.lblDiscountLineIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDiscountLineIn.Name = "lblDiscountLineIn"
		Me._lbl_20.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_20.Text = "Contents Value :"
		Me._lbl_20.Size = New System.Drawing.Size(133, 13)
		Me._lbl_20.Location = New System.Drawing.Point(18, 36)
		Me._lbl_20.TabIndex = 56
		Me._lbl_20.BackColor = System.Drawing.Color.Transparent
		Me._lbl_20.Enabled = True
		Me._lbl_20.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_20.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_20.UseMnemonic = True
		Me._lbl_20.Visible = True
		Me._lbl_20.AutoSize = False
		Me._lbl_20.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_20.Name = "_lbl_20"
		Me._lbl_21.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_21.Text = "Line Item Discount :"
		Me._lbl_21.Size = New System.Drawing.Size(133, 13)
		Me._lbl_21.Location = New System.Drawing.Point(18, 57)
		Me._lbl_21.TabIndex = 55
		Me._lbl_21.BackColor = System.Drawing.Color.Transparent
		Me._lbl_21.Enabled = True
		Me._lbl_21.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_21.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_21.UseMnemonic = True
		Me._lbl_21.Visible = True
		Me._lbl_21.AutoSize = False
		Me._lbl_21.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_21.Name = "_lbl_21"
		Me.lblExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblExclusiveIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblExclusiveIn.Text = "0.00"
		Me.lblExclusiveIn.Size = New System.Drawing.Size(91, 19)
		Me.lblExclusiveIn.Location = New System.Drawing.Point(153, 201)
		Me.lblExclusiveIn.TabIndex = 54
		Me.lblExclusiveIn.Enabled = True
		Me.lblExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblExclusiveIn.UseMnemonic = True
		Me.lblExclusiveIn.Visible = True
		Me.lblExclusiveIn.AutoSize = False
		Me.lblExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblExclusiveIn.Name = "lblExclusiveIn"
		Me._lbl_22.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_22.Text = "Exclusive:"
		Me._lbl_22.Size = New System.Drawing.Size(133, 13)
		Me._lbl_22.Location = New System.Drawing.Point(18, 204)
		Me._lbl_22.TabIndex = 53
		Me._lbl_22.BackColor = System.Drawing.Color.Transparent
		Me._lbl_22.Enabled = True
		Me._lbl_22.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_22.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_22.UseMnemonic = True
		Me._lbl_22.Visible = True
		Me._lbl_22.AutoSize = False
		Me._lbl_22.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_22.Name = "_lbl_22"
		Me._lbl_29.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_29.Text = "VAT :"
		Me._lbl_29.Size = New System.Drawing.Size(133, 13)
		Me._lbl_29.Location = New System.Drawing.Point(18, 225)
		Me._lbl_29.TabIndex = 52
		Me._lbl_29.BackColor = System.Drawing.Color.Transparent
		Me._lbl_29.Enabled = True
		Me._lbl_29.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_29.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_29.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_29.UseMnemonic = True
		Me._lbl_29.Visible = True
		Me._lbl_29.AutoSize = False
		Me._lbl_29.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_29.Name = "_lbl_29"
		Me.lblVATin.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblVATin.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblVATin.Text = "0.00"
		Me.lblVATin.Size = New System.Drawing.Size(91, 19)
		Me.lblVATin.Location = New System.Drawing.Point(153, 222)
		Me.lblVATin.TabIndex = 51
		Me.lblVATin.Enabled = True
		Me.lblVATin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVATin.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVATin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVATin.UseMnemonic = True
		Me.lblVATin.Visible = True
		Me.lblVATin.AutoSize = False
		Me.lblVATin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblVATin.Name = "lblVATin"
		Me._lbl_30.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_30.Text = "Inclusive:"
		Me._lbl_30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_30.Size = New System.Drawing.Size(133, 13)
		Me._lbl_30.Location = New System.Drawing.Point(18, 246)
		Me._lbl_30.TabIndex = 50
		Me._lbl_30.BackColor = System.Drawing.Color.Transparent
		Me._lbl_30.Enabled = True
		Me._lbl_30.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_30.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_30.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_30.UseMnemonic = True
		Me._lbl_30.Visible = True
		Me._lbl_30.AutoSize = False
		Me._lbl_30.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_30.Name = "_lbl_30"
		Me.lblInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInclusiveIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblInclusiveIn.Text = "0.00"
		Me.lblInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInclusiveIn.Size = New System.Drawing.Size(91, 19)
		Me.lblInclusiveIn.Location = New System.Drawing.Point(153, 243)
		Me.lblInclusiveIn.TabIndex = 49
		Me.lblInclusiveIn.Enabled = True
		Me.lblInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInclusiveIn.UseMnemonic = True
		Me.lblInclusiveIn.Visible = True
		Me.lblInclusiveIn.AutoSize = False
		Me.lblInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblInclusiveIn.Name = "lblInclusiveIn"
		Me.lblVatRateIn.Text = "0.00"
		Me.lblVatRateIn.Size = New System.Drawing.Size(55, 16)
		Me.lblVatRateIn.Location = New System.Drawing.Point(246, 225)
		Me.lblVatRateIn.TabIndex = 48
		Me.lblVatRateIn.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblVatRateIn.BackColor = System.Drawing.Color.Transparent
		Me.lblVatRateIn.Enabled = True
		Me.lblVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVatRateIn.UseMnemonic = True
		Me.lblVatRateIn.Visible = True
		Me.lblVatRateIn.AutoSize = False
		Me.lblVatRateIn.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVatRateIn.Name = "lblVatRateIn"
		Me._lbl_19.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_19.Text = "Payment Terms"
		Me._lbl_19.Size = New System.Drawing.Size(133, 13)
		Me._lbl_19.Location = New System.Drawing.Point(18, 99)
		Me._lbl_19.TabIndex = 47
		Me._lbl_19.BackColor = System.Drawing.Color.Transparent
		Me._lbl_19.Enabled = True
		Me._lbl_19.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_19.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_19.UseMnemonic = True
		Me._lbl_19.Visible = True
		Me._lbl_19.AutoSize = False
		Me._lbl_19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_19.Name = "_lbl_19"
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_1.Text = "%:"
		Me._Label1_1.ForeColor = System.Drawing.Color.Red
		Me._Label1_1.Size = New System.Drawing.Size(13, 13)
		Me._Label1_1.Location = New System.Drawing.Point(138, 138)
		Me._Label1_1.TabIndex = 46
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = True
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = "Ullage @"
		Me.Label2.ForeColor = System.Drawing.Color.Red
		Me.Label2.Size = New System.Drawing.Size(133, 13)
		Me.Label2.Location = New System.Drawing.Point(-36, 138)
		Me.Label2.TabIndex = 45
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_0.Text = "%:"
		Me._Label1_0.ForeColor = System.Drawing.Color.Red
		Me._Label1_0.Size = New System.Drawing.Size(13, 13)
		Me._Label1_0.Location = New System.Drawing.Point(138, 120)
		Me._Label1_0.TabIndex = 44
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = True
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDiscount.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDiscount.Text = "0.00"
		Me.lblDiscount.ForeColor = System.Drawing.Color.Red
		Me.lblDiscount.Size = New System.Drawing.Size(91, 19)
		Me.lblDiscount.Location = New System.Drawing.Point(153, 117)
		Me.lblDiscount.TabIndex = 43
		Me.lblDiscount.Enabled = True
		Me.lblDiscount.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDiscount.UseMnemonic = True
		Me.lblDiscount.Visible = True
		Me.lblDiscount.AutoSize = False
		Me.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDiscount.Name = "lblDiscount"
		Me.lblUllage.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblUllage.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblUllage.Text = "0.00"
		Me.lblUllage.ForeColor = System.Drawing.Color.Red
		Me.lblUllage.Size = New System.Drawing.Size(91, 19)
		Me.lblUllage.Location = New System.Drawing.Point(153, 138)
		Me.lblUllage.TabIndex = 42
		Me.lblUllage.Enabled = True
		Me.lblUllage.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUllage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUllage.UseMnemonic = True
		Me.lblUllage.Visible = True
		Me.lblUllage.AutoSize = False
		Me.lblUllage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblUllage.Name = "lblUllage"
		Me.lblDiscountName.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDiscountName.Text = "Account Discount"
		Me.lblDiscountName.ForeColor = System.Drawing.Color.Red
		Me.lblDiscountName.Size = New System.Drawing.Size(133, 13)
		Me.lblDiscountName.Location = New System.Drawing.Point(-42, 120)
		Me.lblDiscountName.TabIndex = 41
		Me.lblDiscountName.BackColor = System.Drawing.Color.Transparent
		Me.lblDiscountName.Enabled = True
		Me.lblDiscountName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDiscountName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDiscountName.UseMnemonic = True
		Me.lblDiscountName.Visible = True
		Me.lblDiscountName.AutoSize = False
		Me.lblDiscountName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDiscountName.Name = "lblDiscountName"
		Me._lbl_31.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_31.Text = "Content Sub Total :"
		Me._lbl_31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_31.Size = New System.Drawing.Size(133, 13)
		Me._lbl_31.Location = New System.Drawing.Point(18, 78)
		Me._lbl_31.TabIndex = 40
		Me._lbl_31.BackColor = System.Drawing.Color.Transparent
		Me._lbl_31.Enabled = True
		Me._lbl_31.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_31.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_31.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_31.UseMnemonic = True
		Me._lbl_31.Visible = True
		Me._lbl_31.AutoSize = False
		Me._lbl_31.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_31.Name = "_lbl_31"
		Me.lblContentExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentExclusiveIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblContentExclusiveIn.Text = "0.00"
		Me.lblContentExclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblContentExclusiveIn.Size = New System.Drawing.Size(91, 19)
		Me.lblContentExclusiveIn.Location = New System.Drawing.Point(153, 75)
		Me.lblContentExclusiveIn.TabIndex = 39
		Me.lblContentExclusiveIn.Enabled = True
		Me.lblContentExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentExclusiveIn.UseMnemonic = True
		Me.lblContentExclusiveIn.Visible = True
		Me.lblContentExclusiveIn.AutoSize = False
		Me.lblContentExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentExclusiveIn.Name = "lblContentExclusiveIn"
		Me._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_11.Text = "Sundry Minuses:"
		Me._lbl_11.ForeColor = System.Drawing.Color.Red
		Me._lbl_11.Size = New System.Drawing.Size(133, 13)
		Me._lbl_11.Location = New System.Drawing.Point(18, 183)
		Me._lbl_11.TabIndex = 38
		Me._lbl_11.BackColor = System.Drawing.Color.Transparent
		Me._lbl_11.Enabled = True
		Me._lbl_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_11.UseMnemonic = True
		Me._lbl_11.Visible = True
		Me._lbl_11.AutoSize = False
		Me._lbl_11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_11.Name = "_lbl_11"
		Me._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_10.Text = "Sundry Pluses:"
		Me._lbl_10.Size = New System.Drawing.Size(133, 13)
		Me._lbl_10.Location = New System.Drawing.Point(18, 162)
		Me._lbl_10.TabIndex = 37
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
		Me._lbl_32.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_32.Text = "No Of Lines :"
		Me._lbl_32.Size = New System.Drawing.Size(133, 13)
		Me._lbl_32.Location = New System.Drawing.Point(18, 15)
		Me._lbl_32.TabIndex = 36
		Me._lbl_32.BackColor = System.Drawing.Color.Transparent
		Me._lbl_32.Enabled = True
		Me._lbl_32.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_32.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_32.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_32.UseMnemonic = True
		Me._lbl_32.Visible = True
		Me._lbl_32.AutoSize = False
		Me._lbl_32.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_32.Name = "_lbl_32"
		Me.lblLinesIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblLinesIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblLinesIn.Text = "0"
		Me.lblLinesIn.Size = New System.Drawing.Size(91, 19)
		Me.lblLinesIn.Location = New System.Drawing.Point(153, 12)
		Me.lblLinesIn.TabIndex = 35
		Me.lblLinesIn.Enabled = True
		Me.lblLinesIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLinesIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLinesIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLinesIn.UseMnemonic = True
		Me.lblLinesIn.Visible = True
		Me.lblLinesIn.AutoSize = False
		Me.lblLinesIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLinesIn.Name = "lblLinesIn"
		Me._Frame1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Frame1_1.Text = "Deposits with Purchases"
		Me._Frame1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_1.Size = New System.Drawing.Size(301, 82)
		Me._Frame1_1.Location = New System.Drawing.Point(9, 285)
		Me._Frame1_1.TabIndex = 12
		Me._Frame1_1.Enabled = True
		Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_1.Visible = True
		Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_1.Name = "_Frame1_1"
		Me.lblDepositVatRateIn.Text = "0.00"
		Me.lblDepositVatRateIn.Size = New System.Drawing.Size(55, 16)
		Me.lblDepositVatRateIn.Location = New System.Drawing.Point(243, 39)
		Me.lblDepositVatRateIn.TabIndex = 59
		Me.lblDepositVatRateIn.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDepositVatRateIn.BackColor = System.Drawing.Color.Transparent
		Me.lblDepositVatRateIn.Enabled = True
		Me.lblDepositVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositVatRateIn.UseMnemonic = True
		Me.lblDepositVatRateIn.Visible = True
		Me.lblDepositVatRateIn.AutoSize = False
		Me.lblDepositVatRateIn.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDepositVatRateIn.Name = "lblDepositVatRateIn"
		Me.lblDepositIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositIn.Text = "0.00"
		Me.lblDepositIn.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositIn.Location = New System.Drawing.Point(150, 18)
		Me.lblDepositIn.TabIndex = 14
		Me.lblDepositIn.Enabled = True
		Me.lblDepositIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositIn.UseMnemonic = True
		Me.lblDepositIn.Visible = True
		Me.lblDepositIn.AutoSize = False
		Me.lblDepositIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositIn.Name = "lblDepositIn"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "Deposit Value:"
		Me._lbl_2.Size = New System.Drawing.Size(133, 13)
		Me._lbl_2.Location = New System.Drawing.Point(16, 21)
		Me._lbl_2.TabIndex = 13
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
		Me.lblDepositVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositVatIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositVatIn.Text = "0.00"
		Me.lblDepositVatIn.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositVatIn.Location = New System.Drawing.Point(150, 36)
		Me.lblDepositVatIn.TabIndex = 16
		Me.lblDepositVatIn.Enabled = True
		Me.lblDepositVatIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositVatIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositVatIn.UseMnemonic = True
		Me.lblDepositVatIn.Visible = True
		Me.lblDepositVatIn.AutoSize = False
		Me.lblDepositVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositVatIn.Name = "lblDepositVatIn"
		Me._lbl_13.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_13.Text = "VAT:"
		Me._lbl_13.Size = New System.Drawing.Size(133, 13)
		Me._lbl_13.Location = New System.Drawing.Point(16, 39)
		Me._lbl_13.TabIndex = 15
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
		Me.lblDepositInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositInclusiveIn.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDepositInclusiveIn.Text = "0.00"
		Me.lblDepositInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositInclusiveIn.Size = New System.Drawing.Size(91, 19)
		Me.lblDepositInclusiveIn.Location = New System.Drawing.Point(150, 54)
		Me.lblDepositInclusiveIn.TabIndex = 18
		Me.lblDepositInclusiveIn.Enabled = True
		Me.lblDepositInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositInclusiveIn.UseMnemonic = True
		Me.lblDepositInclusiveIn.Visible = True
		Me.lblDepositInclusiveIn.AutoSize = False
		Me.lblDepositInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositInclusiveIn.Name = "lblDepositInclusiveIn"
		Me._lbl_14.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_14.Text = "Inclusive:"
		Me._lbl_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_14.Size = New System.Drawing.Size(133, 13)
		Me._lbl_14.Location = New System.Drawing.Point(16, 57)
		Me._lbl_14.TabIndex = 17
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
		Me.Line2.X1 = 620
		Me.Line2.X2 = 24
		Me.Line2.Y1 = 485
		Me.Line2.Y2 = 485
		Me.Line2.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Line2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line2.BorderWidth = 1
		Me.Line2.Visible = True
		Me.Line2.Name = "Line2"
		Me.Line1.X1 = 620
		Me.Line1.X2 = 24
		Me.Line1.Y1 = 482
		Me.Line1.Y2 = 482
		Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line1.BorderWidth = 1
		Me.Line1.Visible = True
		Me.Line1.Name = "Line1"
		Me._lbl_28.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_28.Text = "In Bound VAT:"
		Me._lbl_28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_28.Size = New System.Drawing.Size(133, 13)
		Me._lbl_28.Location = New System.Drawing.Point(336, 456)
		Me._lbl_28.TabIndex = 92
		Me._lbl_28.BackColor = System.Drawing.Color.Transparent
		Me._lbl_28.Enabled = True
		Me._lbl_28.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_28.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_28.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_28.UseMnemonic = True
		Me._lbl_28.Visible = True
		Me._lbl_28.AutoSize = False
		Me._lbl_28.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_28.Name = "_lbl_28"
		Me.lblInBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInBoundVat.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblInBoundVat.Text = "0.00"
		Me.lblInBoundVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInBoundVat.Size = New System.Drawing.Size(91, 19)
		Me.lblInBoundVat.Location = New System.Drawing.Point(470, 453)
		Me.lblInBoundVat.TabIndex = 91
		Me.lblInBoundVat.Enabled = True
		Me.lblInBoundVat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInBoundVat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInBoundVat.UseMnemonic = True
		Me.lblInBoundVat.Visible = True
		Me.lblInBoundVat.AutoSize = False
		Me.lblInBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblInBoundVat.Name = "lblInBoundVat"
		Me._lbl_27.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_27.Text = "Credit Inclusive:"
		Me._lbl_27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_27.Size = New System.Drawing.Size(133, 13)
		Me._lbl_27.Location = New System.Drawing.Point(337, 477)
		Me._lbl_27.TabIndex = 90
		Me._lbl_27.BackColor = System.Drawing.Color.Transparent
		Me._lbl_27.Enabled = True
		Me._lbl_27.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_27.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_27.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_27.UseMnemonic = True
		Me._lbl_27.Visible = True
		Me._lbl_27.AutoSize = False
		Me._lbl_27.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_27.Name = "_lbl_27"
		Me.lblInBound.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInBound.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblInBound.Text = "0.00"
		Me.lblInBound.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInBound.Size = New System.Drawing.Size(91, 19)
		Me.lblInBound.Location = New System.Drawing.Point(471, 474)
		Me.lblInBound.TabIndex = 89
		Me.lblInBound.Enabled = True
		Me.lblInBound.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInBound.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInBound.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInBound.UseMnemonic = True
		Me.lblInBound.Visible = True
		Me.lblInBound.AutoSize = False
		Me.lblInBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblInBound.Name = "lblInBound"
		Me._lbl_26.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_26.Text = "Credits VAT:"
		Me._lbl_26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_26.Size = New System.Drawing.Size(133, 13)
		Me._lbl_26.Location = New System.Drawing.Point(336, 246)
		Me._lbl_26.TabIndex = 88
		Me._lbl_26.BackColor = System.Drawing.Color.Transparent
		Me._lbl_26.Enabled = True
		Me._lbl_26.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_26.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_26.UseMnemonic = True
		Me._lbl_26.Visible = True
		Me._lbl_26.AutoSize = False
		Me._lbl_26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_26.Name = "_lbl_26"
		Me.lblCreditVat.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblCreditVat.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblCreditVat.Text = "0.00"
		Me.lblCreditVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblCreditVat.Size = New System.Drawing.Size(91, 19)
		Me.lblCreditVat.Location = New System.Drawing.Point(470, 243)
		Me.lblCreditVat.TabIndex = 87
		Me.lblCreditVat.Enabled = True
		Me.lblCreditVat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCreditVat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCreditVat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCreditVat.UseMnemonic = True
		Me.lblCreditVat.Visible = True
		Me.lblCreditVat.AutoSize = False
		Me.lblCreditVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCreditVat.Name = "lblCreditVat"
		Me._lbl_25.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_25.Text = "Credits Inclusive:"
		Me._lbl_25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_25.Size = New System.Drawing.Size(133, 13)
		Me._lbl_25.Location = New System.Drawing.Point(337, 267)
		Me._lbl_25.TabIndex = 86
		Me._lbl_25.BackColor = System.Drawing.Color.Transparent
		Me._lbl_25.Enabled = True
		Me._lbl_25.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_25.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_25.UseMnemonic = True
		Me._lbl_25.Visible = True
		Me._lbl_25.AutoSize = False
		Me._lbl_25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_25.Name = "_lbl_25"
		Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblCredit.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblCredit.Text = "0.00"
		Me.lblCredit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblCredit.Size = New System.Drawing.Size(91, 19)
		Me.lblCredit.Location = New System.Drawing.Point(471, 264)
		Me.lblCredit.TabIndex = 85
		Me.lblCredit.Enabled = True
		Me.lblCredit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCredit.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCredit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCredit.UseMnemonic = True
		Me.lblCredit.Visible = True
		Me.lblCredit.AutoSize = False
		Me.lblCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCredit.Name = "lblCredit"
		Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_8.Text = "Out Bound VAT:"
		Me._lbl_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_8.Size = New System.Drawing.Size(133, 13)
		Me._lbl_8.Location = New System.Drawing.Point(24, 456)
		Me._lbl_8.TabIndex = 84
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
		Me.lblOutBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblOutBoundVat.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblOutBoundVat.Text = "0.00"
		Me.lblOutBoundVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblOutBoundVat.Size = New System.Drawing.Size(91, 19)
		Me.lblOutBoundVat.Location = New System.Drawing.Point(158, 453)
		Me.lblOutBoundVat.TabIndex = 83
		Me.lblOutBoundVat.Enabled = True
		Me.lblOutBoundVat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblOutBoundVat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblOutBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblOutBoundVat.UseMnemonic = True
		Me.lblOutBoundVat.Visible = True
		Me.lblOutBoundVat.AutoSize = False
		Me.lblOutBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblOutBoundVat.Name = "lblOutBoundVat"
		Me.lblOutBound.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblOutBound.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblOutBound.Text = "0.00"
		Me.lblOutBound.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblOutBound.Size = New System.Drawing.Size(91, 19)
		Me.lblOutBound.Location = New System.Drawing.Point(159, 474)
		Me.lblOutBound.TabIndex = 20
		Me.lblOutBound.Enabled = True
		Me.lblOutBound.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblOutBound.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblOutBound.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblOutBound.UseMnemonic = True
		Me.lblOutBound.Visible = True
		Me.lblOutBound.AutoSize = False
		Me.lblOutBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblOutBound.Name = "lblOutBound"
		Me._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_6.Text = "Purchases Inclusive:"
		Me._lbl_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_6.Size = New System.Drawing.Size(133, 13)
		Me._lbl_6.Location = New System.Drawing.Point(25, 477)
		Me._lbl_6.TabIndex = 19
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
		Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotal.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblTotal.Text = "0.00"
		Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblTotal.Size = New System.Drawing.Size(91, 19)
		Me.lblTotal.Location = New System.Drawing.Point(531, 522)
		Me.lblTotal.TabIndex = 9
		Me.lblTotal.Enabled = True
		Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotal.UseMnemonic = True
		Me.lblTotal.Visible = True
		Me.lblTotal.AutoSize = False
		Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotal.Name = "lblTotal"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "Nett Invoice Value:"
		Me._lbl_7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_7.Size = New System.Drawing.Size(133, 13)
		Me._lbl_7.Location = New System.Drawing.Point(396, 525)
		Me._lbl_7.TabIndex = 8
		Me._lbl_7.BackColor = System.Drawing.Color.Transparent
		Me._lbl_7.Enabled = True
		Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_7.UseMnemonic = True
		Me._lbl_7.Visible = True
		Me._lbl_7.AutoSize = False
		Me._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_7.Name = "_lbl_7"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "Desired Invoice Value:"
		Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_0.Size = New System.Drawing.Size(133, 13)
		Me._lbl_0.Location = New System.Drawing.Point(24, 504)
		Me._lbl_0.TabIndex = 28
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
		Me.lblTotalOriginal.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalOriginal.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblTotalOriginal.Text = "0.00"
		Me.lblTotalOriginal.Size = New System.Drawing.Size(91, 19)
		Me.lblTotalOriginal.Location = New System.Drawing.Point(159, 501)
		Me.lblTotalOriginal.TabIndex = 29
		Me.lblTotalOriginal.Enabled = True
		Me.lblTotalOriginal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalOriginal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalOriginal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalOriginal.UseMnemonic = True
		Me.lblTotalOriginal.Visible = True
		Me.lblTotalOriginal.AutoSize = False
		Me.lblTotalOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalOriginal.Name = "lblTotalOriginal"
		Me.lblDifference.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDifference.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblDifference.Text = "0.00"
		Me.lblDifference.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDifference.Size = New System.Drawing.Size(91, 19)
		Me.lblDifference.Location = New System.Drawing.Point(159, 522)
		Me.lblDifference.TabIndex = 31
		Me.lblDifference.Enabled = True
		Me.lblDifference.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDifference.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDifference.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDifference.UseMnemonic = True
		Me.lblDifference.Visible = True
		Me.lblDifference.AutoSize = False
		Me.lblDifference.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDifference.Name = "lblDifference"
		Me._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_18.Text = "Difference:"
		Me._lbl_18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_18.Size = New System.Drawing.Size(133, 13)
		Me._lbl_18.Location = New System.Drawing.Point(24, 525)
		Me._lbl_18.TabIndex = 30
		Me._lbl_18.BackColor = System.Drawing.Color.Transparent
		Me._lbl_18.Enabled = True
		Me._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_18.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_18.UseMnemonic = True
		Me._lbl_18.Visible = True
		Me._lbl_18.AutoSize = False
		Me._lbl_18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_18.Name = "_lbl_18"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.Red
		Me.Picture1.Size = New System.Drawing.Size(760, 25)
		Me.Picture1.Location = New System.Drawing.Point(0, 49)
		Me.Picture1.TabIndex = 32
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.lblSupplier.Text = "lblSupplier"
		Me.lblSupplier.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblSupplier.ForeColor = System.Drawing.Color.White
		Me.lblSupplier.Size = New System.Drawing.Size(85, 20)
		Me.lblSupplier.Location = New System.Drawing.Point(0, 0)
		Me.lblSupplier.TabIndex = 33
		Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
		Me.lblSupplier.Enabled = True
		Me.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSupplier.UseMnemonic = True
		Me.lblSupplier.Visible = True
		Me.lblSupplier.AutoSize = True
		Me.lblSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSupplier.Name = "lblSupplier"
		Me.Controls.Add(cmdNextFnV)
		Me.Controls.Add(_Frame1_6)
		Me.Controls.Add(Picture2)
		Me.Controls.Add(frmProcess)
		Me.Controls.Add(frmMain)
		Me.Controls.Add(Picture1)
		Me._Frame1_6.Controls.Add(cmdNext)
		Me._Frame1_6.Controls.Add(Text1)
		Me._Frame1_6.Controls.Add(Command2)
		Me._Frame1_6.Controls.Add(Command1)
		Me._Frame1_6.Controls.Add(txtQuantity)
		Me._Frame1_6.Controls.Add(FGRecipe)
		Me._Frame1_6.Controls.Add(Label5)
		Me._Frame1_6.Controls.Add(Label4)
		Me._Frame1_6.Controls.Add(lblRecipeCost)
		Me.Picture2.Controls.Add(cmdExit)
		Me.Picture2.Controls.Add(cmdBack)
		Me.frmProcess.Controls.Add(txtNotes)
		Me.frmProcess.Controls.Add(_optClose_0)
		Me.frmProcess.Controls.Add(Label3)
		Me.frmMain.Controls.Add(_Frame1_5)
		Me.frmMain.Controls.Add(_Frame1_3)
		Me.frmMain.Controls.Add(_Frame1_4)
		Me.frmMain.Controls.Add(_Frame1_2)
		Me.frmMain.Controls.Add(_Frame1_0)
		Me.frmMain.Controls.Add(_Frame1_1)
		Me.ShapeContainer1.Shapes.Add(Line2)
		Me.ShapeContainer1.Shapes.Add(Line1)
		Me.frmMain.Controls.Add(_lbl_28)
		Me.frmMain.Controls.Add(lblInBoundVat)
		Me.frmMain.Controls.Add(_lbl_27)
		Me.frmMain.Controls.Add(lblInBound)
		Me.frmMain.Controls.Add(_lbl_26)
		Me.frmMain.Controls.Add(lblCreditVat)
		Me.frmMain.Controls.Add(_lbl_25)
		Me.frmMain.Controls.Add(lblCredit)
		Me.frmMain.Controls.Add(_lbl_8)
		Me.frmMain.Controls.Add(lblOutBoundVat)
		Me.frmMain.Controls.Add(lblOutBound)
		Me.frmMain.Controls.Add(_lbl_6)
		Me.frmMain.Controls.Add(lblTotal)
		Me.frmMain.Controls.Add(_lbl_7)
		Me.frmMain.Controls.Add(_lbl_0)
		Me.frmMain.Controls.Add(lblTotalOriginal)
		Me.frmMain.Controls.Add(lblDifference)
		Me.frmMain.Controls.Add(_lbl_18)
		Me.frmMain.Controls.Add(ShapeContainer1)
		Me._Frame1_5.Controls.Add(lblDepositReturnIn)
		Me._Frame1_5.Controls.Add(_lbl_35)
		Me._Frame1_5.Controls.Add(lblDepositReturnVatIn)
		Me._Frame1_5.Controls.Add(_lbl_34)
		Me._Frame1_5.Controls.Add(lblDepositReturnInclusiveIn)
		Me._Frame1_5.Controls.Add(_lbl_33)
		Me._Frame1_5.Controls.Add(lblDepositReturnVatRateIn)
		Me._Frame1_3.Controls.Add(lblContentOut)
		Me._Frame1_3.Controls.Add(lblDiscountLineOut)
		Me._Frame1_3.Controls.Add(_lbl_1)
		Me._Frame1_3.Controls.Add(_lbl_3)
		Me._Frame1_3.Controls.Add(lblExclusiveOut)
		Me._Frame1_3.Controls.Add(_lbl_4)
		Me._Frame1_3.Controls.Add(_lbl_5)
		Me._Frame1_3.Controls.Add(lblVATout)
		Me._Frame1_3.Controls.Add(_lbl_12)
		Me._Frame1_3.Controls.Add(lblInclusiveOut)
		Me._Frame1_3.Controls.Add(lblVatRateOut)
		Me._Frame1_3.Controls.Add(_lbl_37)
		Me._Frame1_3.Controls.Add(lblLinesOut)
		Me._Frame1_4.Controls.Add(lblDepositVatRateOut)
		Me._Frame1_4.Controls.Add(lblDepositOut)
		Me._Frame1_4.Controls.Add(_lbl_9)
		Me._Frame1_4.Controls.Add(lblDepositVatOut)
		Me._Frame1_4.Controls.Add(_lbl_23)
		Me._Frame1_4.Controls.Add(lblDepositInclusiveOut)
		Me._Frame1_4.Controls.Add(_lbl_24)
		Me._Frame1_2.Controls.Add(lblDepositReturnVatRateOut)
		Me._Frame1_2.Controls.Add(_lbl_15)
		Me._Frame1_2.Controls.Add(lblDepositReturnInclusiveOut)
		Me._Frame1_2.Controls.Add(_lbl_16)
		Me._Frame1_2.Controls.Add(lblDepositReturnVatOut)
		Me._Frame1_2.Controls.Add(_lbl_17)
		Me._Frame1_2.Controls.Add(lblDepositReturnOut)
		Me._Frame1_0.Controls.Add(cmbPayment)
		Me._Frame1_0.Controls.Add(txtUllage)
		Me._Frame1_0.Controls.Add(txtDiscount)
		Me._Frame1_0.Controls.Add(txtMinus)
		Me._Frame1_0.Controls.Add(txtPlus)
		Me._Frame1_0.Controls.Add(lblContentIn)
		Me._Frame1_0.Controls.Add(lblDiscountLineIn)
		Me._Frame1_0.Controls.Add(_lbl_20)
		Me._Frame1_0.Controls.Add(_lbl_21)
		Me._Frame1_0.Controls.Add(lblExclusiveIn)
		Me._Frame1_0.Controls.Add(_lbl_22)
		Me._Frame1_0.Controls.Add(_lbl_29)
		Me._Frame1_0.Controls.Add(lblVATin)
		Me._Frame1_0.Controls.Add(_lbl_30)
		Me._Frame1_0.Controls.Add(lblInclusiveIn)
		Me._Frame1_0.Controls.Add(lblVatRateIn)
		Me._Frame1_0.Controls.Add(_lbl_19)
		Me._Frame1_0.Controls.Add(_Label1_1)
		Me._Frame1_0.Controls.Add(Label2)
		Me._Frame1_0.Controls.Add(_Label1_0)
		Me._Frame1_0.Controls.Add(lblDiscount)
		Me._Frame1_0.Controls.Add(lblUllage)
		Me._Frame1_0.Controls.Add(lblDiscountName)
		Me._Frame1_0.Controls.Add(_lbl_31)
		Me._Frame1_0.Controls.Add(lblContentExclusiveIn)
		Me._Frame1_0.Controls.Add(_lbl_11)
		Me._Frame1_0.Controls.Add(_lbl_10)
		Me._Frame1_0.Controls.Add(_lbl_32)
		Me._Frame1_0.Controls.Add(lblLinesIn)
		Me._Frame1_1.Controls.Add(lblDepositVatRateIn)
		Me._Frame1_1.Controls.Add(lblDepositIn)
		Me._Frame1_1.Controls.Add(_lbl_2)
		Me._Frame1_1.Controls.Add(lblDepositVatIn)
		Me._Frame1_1.Controls.Add(_lbl_13)
		Me._Frame1_1.Controls.Add(lblDepositInclusiveIn)
		Me._Frame1_1.Controls.Add(_lbl_14)
		Me.Picture1.Controls.Add(lblSupplier)
        'Me.Frame1.SetIndex(_Frame1_6, CType(6, Short))
        'Me.Frame1.SetIndex(_Frame1_5, CType(5, Short))
        'Me.Frame1.SetIndex(_Frame1_3, CType(3, Short))
        'Me.Frame1.SetIndex(_Frame1_4, CType(4, Short))
        'Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_35, CType(35, Short))
        'Me.lbl.SetIndex(_lbl_34, CType(34, Short))
        'Me.lbl.SetIndex(_lbl_33, CType(33, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_12, CType(12, Short))
        'Me.lbl.SetIndex(_lbl_37, CType(37, Short))
        'Me.lbl.SetIndex(_lbl_9, CType(9, Short))
        'Me.lbl.SetIndex(_lbl_23, CType(23, Short))
        'Me.lbl.SetIndex(_lbl_24, CType(24, Short))
        'Me.lbl.SetIndex(_lbl_15, CType(15, Short))
        'Me.lbl.SetIndex(_lbl_16, CType(16, Short))
        'Me.lbl.SetIndex(_lbl_17, CType(17, Short))
        'Me.lbl.SetIndex(_lbl_20, CType(20, Short))
        'Me.lbl.SetIndex(_lbl_21, CType(21, Short))
        'Me.lbl.SetIndex(_lbl_22, CType(22, Short))
        'Me.lbl.SetIndex(_lbl_29, CType(29, Short))
        'Me.lbl.SetIndex(_lbl_30, CType(30, Short))
        'Me.lbl.SetIndex(_lbl_19, CType(19, Short))
        'Me.lbl.SetIndex(_lbl_31, CType(31, Short))
        'Me.lbl.SetIndex(_lbl_11, CType(11, Short))
        'Me.lbl.SetIndex(_lbl_10, CType(10, Short))
        'Me.lbl.SetIndex(_lbl_32, CType(32, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_13, CType(13, Short))
        'Me.lbl.SetIndex(_lbl_14, CType(14, Short))
        'Me.lbl.SetIndex(_lbl_28, CType(28, Short))
        'Me.lbl.SetIndex(_lbl_27, CType(27, Short))
        'Me.lbl.SetIndex(_lbl_26, CType(26, Short))
        'Me.lbl.SetIndex(_lbl_25, CType(25, Short))
        'Me.lbl.SetIndex(_lbl_8, CType(8, Short))
        'Me.lbl.SetIndex(_lbl_6, CType(6, Short))
        'Me.lbl.SetIndex(_lbl_7, CType(7, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_18, CType(18, Short))
        'Me.optClose.SetIndex(_optClose_0, CType(0, Short))
        'CType(Me.optClose, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FGRecipe, System.ComponentModel.ISupportInitialize).EndInit()
		Me._Frame1_6.ResumeLayout(False)
		Me.Picture2.ResumeLayout(False)
		Me.frmProcess.ResumeLayout(False)
		Me.frmMain.ResumeLayout(False)
		Me._Frame1_5.ResumeLayout(False)
		Me._Frame1_3.ResumeLayout(False)
		Me._Frame1_4.ResumeLayout(False)
		Me._Frame1_2.ResumeLayout(False)
		Me._Frame1_0.ResumeLayout(False)
		Me._Frame1_1.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class