<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVSummary
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
	Public WithEvents tmrAutoGRV As System.Windows.Forms.Timer
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents txtNotes As System.Windows.Forms.TextBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.tmrAutoGRV = New System.Windows.Forms.Timer(Me.components)
        Me.Picture2 = New System.Windows.Forms.Panel()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.frmProcess = New System.Windows.Forms.GroupBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me._optClose_0 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.frmMain = New System.Windows.Forms.GroupBox()
        Me._Frame1_5 = New System.Windows.Forms.GroupBox()
        Me.lblDepositReturnIn = New System.Windows.Forms.Label()
        Me._lbl_35 = New System.Windows.Forms.Label()
        Me.lblDepositReturnVatIn = New System.Windows.Forms.Label()
        Me._lbl_34 = New System.Windows.Forms.Label()
        Me.lblDepositReturnInclusiveIn = New System.Windows.Forms.Label()
        Me._lbl_33 = New System.Windows.Forms.Label()
        Me.lblDepositReturnVatRateIn = New System.Windows.Forms.Label()
        Me._Frame1_3 = New System.Windows.Forms.GroupBox()
        Me.lblContentOut = New System.Windows.Forms.Label()
        Me.lblDiscountLineOut = New System.Windows.Forms.Label()
        Me._lbl_1 = New System.Windows.Forms.Label()
        Me._lbl_3 = New System.Windows.Forms.Label()
        Me.lblExclusiveOut = New System.Windows.Forms.Label()
        Me._lbl_4 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.lblVATout = New System.Windows.Forms.Label()
        Me._lbl_12 = New System.Windows.Forms.Label()
        Me.lblInclusiveOut = New System.Windows.Forms.Label()
        Me.lblVatRateOut = New System.Windows.Forms.Label()
        Me._lbl_37 = New System.Windows.Forms.Label()
        Me.lblLinesOut = New System.Windows.Forms.Label()
        Me._Frame1_4 = New System.Windows.Forms.GroupBox()
        Me.lblDepositVatRateOut = New System.Windows.Forms.Label()
        Me.lblDepositOut = New System.Windows.Forms.Label()
        Me._lbl_9 = New System.Windows.Forms.Label()
        Me.lblDepositVatOut = New System.Windows.Forms.Label()
        Me._lbl_23 = New System.Windows.Forms.Label()
        Me.lblDepositInclusiveOut = New System.Windows.Forms.Label()
        Me._lbl_24 = New System.Windows.Forms.Label()
        Me._Frame1_2 = New System.Windows.Forms.GroupBox()
        Me.lblDepositReturnVatRateOut = New System.Windows.Forms.Label()
        Me._lbl_15 = New System.Windows.Forms.Label()
        Me.lblDepositReturnInclusiveOut = New System.Windows.Forms.Label()
        Me._lbl_16 = New System.Windows.Forms.Label()
        Me.lblDepositReturnVatOut = New System.Windows.Forms.Label()
        Me._lbl_17 = New System.Windows.Forms.Label()
        Me.lblDepositReturnOut = New System.Windows.Forms.Label()
        Me._Frame1_0 = New System.Windows.Forms.GroupBox()
        Me.cmbPayment = New System.Windows.Forms.ComboBox()
        Me.txtUllage = New System.Windows.Forms.TextBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.txtMinus = New System.Windows.Forms.TextBox()
        Me.txtPlus = New System.Windows.Forms.TextBox()
        Me.lblContentIn = New System.Windows.Forms.Label()
        Me.lblDiscountLineIn = New System.Windows.Forms.Label()
        Me._lbl_20 = New System.Windows.Forms.Label()
        Me._lbl_21 = New System.Windows.Forms.Label()
        Me.lblExclusiveIn = New System.Windows.Forms.Label()
        Me._lbl_22 = New System.Windows.Forms.Label()
        Me._lbl_29 = New System.Windows.Forms.Label()
        Me.lblVATin = New System.Windows.Forms.Label()
        Me._lbl_30 = New System.Windows.Forms.Label()
        Me.lblInclusiveIn = New System.Windows.Forms.Label()
        Me.lblVatRateIn = New System.Windows.Forms.Label()
        Me._lbl_19 = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblUllage = New System.Windows.Forms.Label()
        Me.lblDiscountName = New System.Windows.Forms.Label()
        Me._lbl_31 = New System.Windows.Forms.Label()
        Me.lblContentExclusiveIn = New System.Windows.Forms.Label()
        Me._lbl_11 = New System.Windows.Forms.Label()
        Me._lbl_10 = New System.Windows.Forms.Label()
        Me._lbl_32 = New System.Windows.Forms.Label()
        Me.lblLinesIn = New System.Windows.Forms.Label()
        Me._Frame1_1 = New System.Windows.Forms.GroupBox()
        Me.lblDepositVatRateIn = New System.Windows.Forms.Label()
        Me.lblDepositIn = New System.Windows.Forms.Label()
        Me._lbl_2 = New System.Windows.Forms.Label()
        Me.lblDepositVatIn = New System.Windows.Forms.Label()
        Me._lbl_13 = New System.Windows.Forms.Label()
        Me.lblDepositInclusiveIn = New System.Windows.Forms.Label()
        Me._lbl_14 = New System.Windows.Forms.Label()
        Me._lbl_28 = New System.Windows.Forms.Label()
        Me.lblInBoundVat = New System.Windows.Forms.Label()
        Me._lbl_27 = New System.Windows.Forms.Label()
        Me.lblInBound = New System.Windows.Forms.Label()
        Me._lbl_26 = New System.Windows.Forms.Label()
        Me.lblCreditVat = New System.Windows.Forms.Label()
        Me._lbl_25 = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me._lbl_8 = New System.Windows.Forms.Label()
        Me.lblOutBoundVat = New System.Windows.Forms.Label()
        Me.lblOutBound = New System.Windows.Forms.Label()
        Me._lbl_6 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me._lbl_7 = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me.lblTotalOriginal = New System.Windows.Forms.Label()
        Me.lblDifference = New System.Windows.Forms.Label()
        Me._lbl_18 = New System.Windows.Forms.Label()
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.lblSupplier = New System.Windows.Forms.Label()
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
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 13)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line2, Me.Line1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(631, 537)
        Me.ShapeContainer1.TabIndex = 95
        Me.ShapeContainer1.TabStop = False
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 620
        Me.Line2.X2 = 24
        Me.Line2.Y1 = 485
        Me.Line2.Y2 = 485
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 620
        Me.Line1.X2 = 24
        Me.Line1.Y1 = 482
        Me.Line1.Y2 = 482
        '
        'tmrAutoGRV
        '
        Me.tmrAutoGRV.Interval = 10
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.Color.Blue
        Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture2.Controls.Add(Me.cmdExit)
        Me.Picture2.Controls.Add(Me.cmdBack)
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture2.Location = New System.Drawing.Point(0, 25)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(760, 49)
        Me.Picture2.TabIndex = 102
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(627, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(73, 40)
        Me.cmdExit.TabIndex = 104
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdBack
        '
        Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBack.Location = New System.Drawing.Point(426, 3)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBack.Size = New System.Drawing.Size(73, 40)
        Me.cmdBack.TabIndex = 103
        Me.cmdBack.TabStop = False
        Me.cmdBack.Text = "<< &Back"
        Me.cmdBack.UseVisualStyleBackColor = False
        '
        'frmProcess
        '
        Me.frmProcess.BackColor = System.Drawing.SystemColors.Control
        Me.frmProcess.Controls.Add(Me.txtNotes)
        Me.frmProcess.Controls.Add(Me.cmdNext)
        Me.frmProcess.Controls.Add(Me._optClose_0)
        Me.frmProcess.Controls.Add(Me.Label3)
        Me.frmProcess.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.frmProcess.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmProcess.Location = New System.Drawing.Point(657, 363)
        Me.frmProcess.Name = "frmProcess"
        Me.frmProcess.Padding = New System.Windows.Forms.Padding(0)
        Me.frmProcess.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmProcess.Size = New System.Drawing.Size(343, 271)
        Me.frmProcess.TabIndex = 3
        Me.frmProcess.TabStop = False
        Me.frmProcess.Text = "Process this 'Goods Receiving Voucher'"
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = True
        Me.txtNotes.BackColor = System.Drawing.SystemColors.Window
        Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNotes.Location = New System.Drawing.Point(21, 102)
        Me.txtNotes.MaxLength = 255
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNotes.Size = New System.Drawing.Size(301, 85)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = "txtNotes"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNext.Location = New System.Drawing.Point(183, 198)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNext.Size = New System.Drawing.Size(139, 55)
        Me.cmdNext.TabIndex = 7
        Me.cmdNext.Text = "P&rocess"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        '_optClose_0
        '
        Me._optClose_0.BackColor = System.Drawing.SystemColors.Control
        Me._optClose_0.Checked = True
        Me._optClose_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optClose_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optClose_0.Location = New System.Drawing.Point(18, 18)
        Me._optClose_0.Name = "_optClose_0"
        Me._optClose_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optClose_0.Size = New System.Drawing.Size(310, 19)
        Me._optClose_0.TabIndex = 4
        Me._optClose_0.TabStop = True
        Me._optClose_0.Text = "This Purchase Order has been delivered in full."
        Me._optClose_0.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(21, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Notes:"
        '
        'frmMain
        '
        Me.frmMain.BackColor = System.Drawing.SystemColors.Control
        Me.frmMain.Controls.Add(Me._Frame1_5)
        Me.frmMain.Controls.Add(Me._Frame1_3)
        Me.frmMain.Controls.Add(Me._Frame1_4)
        Me.frmMain.Controls.Add(Me._Frame1_2)
        Me.frmMain.Controls.Add(Me._Frame1_0)
        Me.frmMain.Controls.Add(Me._Frame1_1)
        Me.frmMain.Controls.Add(Me._lbl_28)
        Me.frmMain.Controls.Add(Me.lblInBoundVat)
        Me.frmMain.Controls.Add(Me._lbl_27)
        Me.frmMain.Controls.Add(Me.lblInBound)
        Me.frmMain.Controls.Add(Me._lbl_26)
        Me.frmMain.Controls.Add(Me.lblCreditVat)
        Me.frmMain.Controls.Add(Me._lbl_25)
        Me.frmMain.Controls.Add(Me.lblCredit)
        Me.frmMain.Controls.Add(Me._lbl_8)
        Me.frmMain.Controls.Add(Me.lblOutBoundVat)
        Me.frmMain.Controls.Add(Me.lblOutBound)
        Me.frmMain.Controls.Add(Me._lbl_6)
        Me.frmMain.Controls.Add(Me.lblTotal)
        Me.frmMain.Controls.Add(Me._lbl_7)
        Me.frmMain.Controls.Add(Me._lbl_0)
        Me.frmMain.Controls.Add(Me.lblTotalOriginal)
        Me.frmMain.Controls.Add(Me.lblDifference)
        Me.frmMain.Controls.Add(Me._lbl_18)
        Me.frmMain.Controls.Add(Me.ShapeContainer1)
        Me.frmMain.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.frmMain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmMain.Location = New System.Drawing.Point(3, 84)
        Me.frmMain.Name = "frmMain"
        Me.frmMain.Padding = New System.Windows.Forms.Padding(0)
        Me.frmMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmMain.Size = New System.Drawing.Size(631, 550)
        Me.frmMain.TabIndex = 11
        Me.frmMain.TabStop = False
        Me.frmMain.Text = "fmHeading"
        '
        '_Frame1_5
        '
        Me._Frame1_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Frame1_5.Controls.Add(Me.lblDepositReturnIn)
        Me._Frame1_5.Controls.Add(Me._lbl_35)
        Me._Frame1_5.Controls.Add(Me.lblDepositReturnVatIn)
        Me._Frame1_5.Controls.Add(Me._lbl_34)
        Me._Frame1_5.Controls.Add(Me.lblDepositReturnInclusiveIn)
        Me._Frame1_5.Controls.Add(Me._lbl_33)
        Me._Frame1_5.Controls.Add(Me.lblDepositReturnVatRateIn)
        Me._Frame1_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_5.Location = New System.Drawing.Point(9, 375)
        Me._Frame1_5.Name = "_Frame1_5"
        Me._Frame1_5.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_5.Size = New System.Drawing.Size(301, 79)
        Me._Frame1_5.TabIndex = 94
        Me._Frame1_5.TabStop = False
        Me._Frame1_5.Text = "Purchased Deposits"
        '
        'lblDepositReturnIn
        '
        Me.lblDepositReturnIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnIn.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnIn.Location = New System.Drawing.Point(150, 18)
        Me.lblDepositReturnIn.Name = "lblDepositReturnIn"
        Me.lblDepositReturnIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnIn.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositReturnIn.TabIndex = 101
        Me.lblDepositReturnIn.Text = "0.00"
        Me.lblDepositReturnIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_35
        '
        Me._lbl_35.BackColor = System.Drawing.Color.Transparent
        Me._lbl_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_35.ForeColor = System.Drawing.Color.Black
        Me._lbl_35.Location = New System.Drawing.Point(16, 21)
        Me._lbl_35.Name = "_lbl_35"
        Me._lbl_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_35.Size = New System.Drawing.Size(133, 13)
        Me._lbl_35.TabIndex = 100
        Me._lbl_35.Text = "Deposit Value:"
        Me._lbl_35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnVatIn
        '
        Me.lblDepositReturnVatIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnVatIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnVatIn.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnVatIn.Location = New System.Drawing.Point(150, 36)
        Me.lblDepositReturnVatIn.Name = "lblDepositReturnVatIn"
        Me.lblDepositReturnVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnVatIn.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositReturnVatIn.TabIndex = 99
        Me.lblDepositReturnVatIn.Text = "0.00"
        Me.lblDepositReturnVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_34
        '
        Me._lbl_34.BackColor = System.Drawing.Color.Transparent
        Me._lbl_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_34.ForeColor = System.Drawing.Color.Black
        Me._lbl_34.Location = New System.Drawing.Point(16, 39)
        Me._lbl_34.Name = "_lbl_34"
        Me._lbl_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_34.Size = New System.Drawing.Size(133, 13)
        Me._lbl_34.TabIndex = 98
        Me._lbl_34.Text = "VAT:"
        Me._lbl_34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnInclusiveIn
        '
        Me.lblDepositReturnInclusiveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDepositReturnInclusiveIn.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnInclusiveIn.Location = New System.Drawing.Point(150, 54)
        Me.lblDepositReturnInclusiveIn.Name = "lblDepositReturnInclusiveIn"
        Me.lblDepositReturnInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnInclusiveIn.Size = New System.Drawing.Size(91, 19)
        Me.lblDepositReturnInclusiveIn.TabIndex = 97
        Me.lblDepositReturnInclusiveIn.Text = "0.00"
        Me.lblDepositReturnInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_33
        '
        Me._lbl_33.BackColor = System.Drawing.Color.Transparent
        Me._lbl_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_33.ForeColor = System.Drawing.Color.Black
        Me._lbl_33.Location = New System.Drawing.Point(16, 57)
        Me._lbl_33.Name = "_lbl_33"
        Me._lbl_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_33.Size = New System.Drawing.Size(133, 13)
        Me._lbl_33.TabIndex = 96
        Me._lbl_33.Text = "Inclusive:"
        Me._lbl_33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnVatRateIn
        '
        Me.lblDepositReturnVatRateIn.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositReturnVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositReturnVatRateIn.Location = New System.Drawing.Point(243, 39)
        Me.lblDepositReturnVatRateIn.Name = "lblDepositReturnVatRateIn"
        Me.lblDepositReturnVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnVatRateIn.Size = New System.Drawing.Size(55, 16)
        Me.lblDepositReturnVatRateIn.TabIndex = 95
        Me.lblDepositReturnVatRateIn.Text = "0.00"
        '
        '_Frame1_3
        '
        Me._Frame1_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Frame1_3.Controls.Add(Me.lblContentOut)
        Me._Frame1_3.Controls.Add(Me.lblDiscountLineOut)
        Me._Frame1_3.Controls.Add(Me._lbl_1)
        Me._Frame1_3.Controls.Add(Me._lbl_3)
        Me._Frame1_3.Controls.Add(Me.lblExclusiveOut)
        Me._Frame1_3.Controls.Add(Me._lbl_4)
        Me._Frame1_3.Controls.Add(Me._lbl_5)
        Me._Frame1_3.Controls.Add(Me.lblVATout)
        Me._Frame1_3.Controls.Add(Me._lbl_12)
        Me._Frame1_3.Controls.Add(Me.lblInclusiveOut)
        Me._Frame1_3.Controls.Add(Me.lblVatRateOut)
        Me._Frame1_3.Controls.Add(Me._lbl_37)
        Me._Frame1_3.Controls.Add(Me.lblLinesOut)
        Me._Frame1_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_3.Location = New System.Drawing.Point(318, 18)
        Me._Frame1_3.Name = "_Frame1_3"
        Me._Frame1_3.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_3.Size = New System.Drawing.Size(301, 145)
        Me._Frame1_3.TabIndex = 69
        Me._Frame1_3.TabStop = False
        Me._Frame1_3.Text = "Credited Content / Liquid"
        '
        'lblContentOut
        '
        Me.lblContentOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblContentOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContentOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContentOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContentOut.Location = New System.Drawing.Point(153, 33)
        Me.lblContentOut.Name = "lblContentOut"
        Me.lblContentOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContentOut.Size = New System.Drawing.Size(91, 19)
        Me.lblContentOut.TabIndex = 82
        Me.lblContentOut.Text = "0.00"
        Me.lblContentOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiscountLineOut
        '
        Me.lblDiscountLineOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDiscountLineOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiscountLineOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDiscountLineOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDiscountLineOut.Location = New System.Drawing.Point(153, 54)
        Me.lblDiscountLineOut.Name = "lblDiscountLineOut"
        Me.lblDiscountLineOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDiscountLineOut.Size = New System.Drawing.Size(91, 19)
        Me.lblDiscountLineOut.TabIndex = 81
        Me.lblDiscountLineOut.Text = "0.00"
        Me.lblDiscountLineOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_1
        '
        Me._lbl_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_1.Location = New System.Drawing.Point(18, 36)
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.Size = New System.Drawing.Size(133, 13)
        Me._lbl_1.TabIndex = 80
        Me._lbl_1.Text = "Contents Value :"
        Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_3
        '
        Me._lbl_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Location = New System.Drawing.Point(18, 57)
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.Size = New System.Drawing.Size(133, 13)
        Me._lbl_3.TabIndex = 79
        Me._lbl_3.Text = "Line Item Discount :"
        Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblExclusiveOut
        '
        Me.lblExclusiveOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblExclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExclusiveOut.Location = New System.Drawing.Point(153, 75)
        Me.lblExclusiveOut.Name = "lblExclusiveOut"
        Me.lblExclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExclusiveOut.Size = New System.Drawing.Size(91, 19)
        Me.lblExclusiveOut.TabIndex = 78
        Me.lblExclusiveOut.Text = "0.00"
        Me.lblExclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_4
        '
        Me._lbl_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_4.Location = New System.Drawing.Point(18, 78)
        Me._lbl_4.Name = "_lbl_4"
        Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_4.Size = New System.Drawing.Size(133, 13)
        Me._lbl_4.TabIndex = 77
        Me._lbl_4.Text = "Exclusive:"
        Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(18, 99)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(133, 13)
        Me._lbl_5.TabIndex = 76
        Me._lbl_5.Text = "VAT :"
        Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVATout
        '
        Me.lblVATout.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVATout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVATout.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVATout.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVATout.Location = New System.Drawing.Point(153, 96)
        Me.lblVATout.Name = "lblVATout"
        Me.lblVATout.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVATout.Size = New System.Drawing.Size(91, 19)
        Me.lblVATout.TabIndex = 75
        Me.lblVATout.Text = "0.00"
        Me.lblVATout.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_12
        '
        Me._lbl_12.BackColor = System.Drawing.Color.Transparent
        Me._lbl_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_12.Location = New System.Drawing.Point(18, 120)
        Me._lbl_12.Name = "_lbl_12"
        Me._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_12.Size = New System.Drawing.Size(133, 13)
        Me._lbl_12.TabIndex = 74
        Me._lbl_12.Text = "Inclusive:"
        Me._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInclusiveOut
        '
        Me.lblInclusiveOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInclusiveOut.Location = New System.Drawing.Point(153, 117)
        Me.lblInclusiveOut.Name = "lblInclusiveOut"
        Me.lblInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInclusiveOut.Size = New System.Drawing.Size(91, 19)
        Me.lblInclusiveOut.TabIndex = 73
        Me.lblInclusiveOut.Text = "0.00"
        Me.lblInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVatRateOut
        '
        Me.lblVatRateOut.BackColor = System.Drawing.Color.Transparent
        Me.lblVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVatRateOut.Location = New System.Drawing.Point(246, 99)
        Me.lblVatRateOut.Name = "lblVatRateOut"
        Me.lblVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVatRateOut.Size = New System.Drawing.Size(55, 16)
        Me.lblVatRateOut.TabIndex = 72
        Me.lblVatRateOut.Text = "lblVatRateOut"
        '
        '_lbl_37
        '
        Me._lbl_37.BackColor = System.Drawing.Color.Transparent
        Me._lbl_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_37.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_37.Location = New System.Drawing.Point(18, 15)
        Me._lbl_37.Name = "_lbl_37"
        Me._lbl_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_37.Size = New System.Drawing.Size(133, 13)
        Me._lbl_37.TabIndex = 71
        Me._lbl_37.Text = "No Of Lines :"
        Me._lbl_37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLinesOut
        '
        Me.lblLinesOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLinesOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLinesOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLinesOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLinesOut.Location = New System.Drawing.Point(153, 12)
        Me.lblLinesOut.Name = "lblLinesOut"
        Me.lblLinesOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLinesOut.Size = New System.Drawing.Size(91, 19)
        Me.lblLinesOut.TabIndex = 70
        Me.lblLinesOut.Text = "0.00"
        Me.lblLinesOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Frame1_4
        '
        Me._Frame1_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Frame1_4.Controls.Add(Me.lblDepositVatRateOut)
        Me._Frame1_4.Controls.Add(Me.lblDepositOut)
        Me._Frame1_4.Controls.Add(Me._lbl_9)
        Me._Frame1_4.Controls.Add(Me.lblDepositVatOut)
        Me._Frame1_4.Controls.Add(Me._lbl_23)
        Me._Frame1_4.Controls.Add(Me.lblDepositInclusiveOut)
        Me._Frame1_4.Controls.Add(Me._lbl_24)
        Me._Frame1_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_4.Location = New System.Drawing.Point(318, 162)
        Me._Frame1_4.Name = "_Frame1_4"
        Me._Frame1_4.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_4.Size = New System.Drawing.Size(301, 82)
        Me._Frame1_4.TabIndex = 61
        Me._Frame1_4.TabStop = False
        Me._Frame1_4.Text = "Deposits with Credits"
        '
        'lblDepositVatRateOut
        '
        Me.lblDepositVatRateOut.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositVatRateOut.Location = New System.Drawing.Point(243, 39)
        Me.lblDepositVatRateOut.Name = "lblDepositVatRateOut"
        Me.lblDepositVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositVatRateOut.Size = New System.Drawing.Size(55, 16)
        Me.lblDepositVatRateOut.TabIndex = 68
        Me.lblDepositVatRateOut.Text = "0.00"
        '
        'lblDepositOut
        '
        Me.lblDepositOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositOut.Location = New System.Drawing.Point(150, 18)
        Me.lblDepositOut.Name = "lblDepositOut"
        Me.lblDepositOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositOut.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositOut.TabIndex = 67
        Me.lblDepositOut.Text = "0.00"
        Me.lblDepositOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_9
        '
        Me._lbl_9.BackColor = System.Drawing.Color.Transparent
        Me._lbl_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_9.Location = New System.Drawing.Point(16, 21)
        Me._lbl_9.Name = "_lbl_9"
        Me._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_9.Size = New System.Drawing.Size(133, 13)
        Me._lbl_9.TabIndex = 66
        Me._lbl_9.Text = "Deposit Value:"
        Me._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositVatOut
        '
        Me.lblDepositVatOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositVatOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositVatOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositVatOut.Location = New System.Drawing.Point(150, 36)
        Me.lblDepositVatOut.Name = "lblDepositVatOut"
        Me.lblDepositVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositVatOut.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositVatOut.TabIndex = 65
        Me.lblDepositVatOut.Text = "0.00"
        Me.lblDepositVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_23
        '
        Me._lbl_23.BackColor = System.Drawing.Color.Transparent
        Me._lbl_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_23.Location = New System.Drawing.Point(16, 39)
        Me._lbl_23.Name = "_lbl_23"
        Me._lbl_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_23.Size = New System.Drawing.Size(133, 13)
        Me._lbl_23.TabIndex = 64
        Me._lbl_23.Text = "VAT:"
        Me._lbl_23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositInclusiveOut
        '
        Me.lblDepositInclusiveOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDepositInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositInclusiveOut.Location = New System.Drawing.Point(150, 54)
        Me.lblDepositInclusiveOut.Name = "lblDepositInclusiveOut"
        Me.lblDepositInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositInclusiveOut.Size = New System.Drawing.Size(91, 19)
        Me.lblDepositInclusiveOut.TabIndex = 63
        Me.lblDepositInclusiveOut.Text = "0.00"
        Me.lblDepositInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_24
        '
        Me._lbl_24.BackColor = System.Drawing.Color.Transparent
        Me._lbl_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_24.Location = New System.Drawing.Point(16, 57)
        Me._lbl_24.Name = "_lbl_24"
        Me._lbl_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_24.Size = New System.Drawing.Size(133, 13)
        Me._lbl_24.TabIndex = 62
        Me._lbl_24.Text = "Inclusive:"
        Me._lbl_24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Frame1_2
        '
        Me._Frame1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Frame1_2.Controls.Add(Me.lblDepositReturnVatRateOut)
        Me._Frame1_2.Controls.Add(Me._lbl_15)
        Me._Frame1_2.Controls.Add(Me.lblDepositReturnInclusiveOut)
        Me._Frame1_2.Controls.Add(Me._lbl_16)
        Me._Frame1_2.Controls.Add(Me.lblDepositReturnVatOut)
        Me._Frame1_2.Controls.Add(Me._lbl_17)
        Me._Frame1_2.Controls.Add(Me.lblDepositReturnOut)
        Me._Frame1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_2.Location = New System.Drawing.Point(321, 375)
        Me._Frame1_2.Name = "_Frame1_2"
        Me._Frame1_2.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_2.Size = New System.Drawing.Size(301, 79)
        Me._Frame1_2.TabIndex = 22
        Me._Frame1_2.TabStop = False
        Me._Frame1_2.Text = "Returned Deposits"
        '
        'lblDepositReturnVatRateOut
        '
        Me.lblDepositReturnVatRateOut.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositReturnVatRateOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositReturnVatRateOut.Location = New System.Drawing.Point(243, 39)
        Me.lblDepositReturnVatRateOut.Name = "lblDepositReturnVatRateOut"
        Me.lblDepositReturnVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnVatRateOut.Size = New System.Drawing.Size(55, 16)
        Me.lblDepositReturnVatRateOut.TabIndex = 83
        Me.lblDepositReturnVatRateOut.Text = "0.00"
        '
        '_lbl_15
        '
        Me._lbl_15.BackColor = System.Drawing.Color.Transparent
        Me._lbl_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_15.ForeColor = System.Drawing.Color.Black
        Me._lbl_15.Location = New System.Drawing.Point(16, 57)
        Me._lbl_15.Name = "_lbl_15"
        Me._lbl_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_15.Size = New System.Drawing.Size(133, 13)
        Me._lbl_15.TabIndex = 27
        Me._lbl_15.Text = "Inclusive:"
        Me._lbl_15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnInclusiveOut
        '
        Me.lblDepositReturnInclusiveOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnInclusiveOut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDepositReturnInclusiveOut.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnInclusiveOut.Location = New System.Drawing.Point(150, 54)
        Me.lblDepositReturnInclusiveOut.Name = "lblDepositReturnInclusiveOut"
        Me.lblDepositReturnInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnInclusiveOut.Size = New System.Drawing.Size(91, 19)
        Me.lblDepositReturnInclusiveOut.TabIndex = 28
        Me.lblDepositReturnInclusiveOut.Text = "0.00"
        Me.lblDepositReturnInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_16
        '
        Me._lbl_16.BackColor = System.Drawing.Color.Transparent
        Me._lbl_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_16.ForeColor = System.Drawing.Color.Black
        Me._lbl_16.Location = New System.Drawing.Point(16, 39)
        Me._lbl_16.Name = "_lbl_16"
        Me._lbl_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_16.Size = New System.Drawing.Size(133, 13)
        Me._lbl_16.TabIndex = 25
        Me._lbl_16.Text = "VAT:"
        Me._lbl_16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnVatOut
        '
        Me.lblDepositReturnVatOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnVatOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnVatOut.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnVatOut.Location = New System.Drawing.Point(150, 36)
        Me.lblDepositReturnVatOut.Name = "lblDepositReturnVatOut"
        Me.lblDepositReturnVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnVatOut.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositReturnVatOut.TabIndex = 26
        Me.lblDepositReturnVatOut.Text = "0.00"
        Me.lblDepositReturnVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_17
        '
        Me._lbl_17.BackColor = System.Drawing.Color.Transparent
        Me._lbl_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_17.ForeColor = System.Drawing.Color.Black
        Me._lbl_17.Location = New System.Drawing.Point(16, 21)
        Me._lbl_17.Name = "_lbl_17"
        Me._lbl_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_17.Size = New System.Drawing.Size(133, 13)
        Me._lbl_17.TabIndex = 23
        Me._lbl_17.Text = "Deposit Value:"
        Me._lbl_17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositReturnOut
        '
        Me.lblDepositReturnOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositReturnOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositReturnOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositReturnOut.ForeColor = System.Drawing.Color.Black
        Me.lblDepositReturnOut.Location = New System.Drawing.Point(150, 18)
        Me.lblDepositReturnOut.Name = "lblDepositReturnOut"
        Me.lblDepositReturnOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositReturnOut.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositReturnOut.TabIndex = 24
        Me.lblDepositReturnOut.Text = "0.00"
        Me.lblDepositReturnOut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Frame1_0
        '
        Me._Frame1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Frame1_0.Controls.Add(Me.cmbPayment)
        Me._Frame1_0.Controls.Add(Me.txtUllage)
        Me._Frame1_0.Controls.Add(Me.txtDiscount)
        Me._Frame1_0.Controls.Add(Me.txtMinus)
        Me._Frame1_0.Controls.Add(Me.txtPlus)
        Me._Frame1_0.Controls.Add(Me.lblContentIn)
        Me._Frame1_0.Controls.Add(Me.lblDiscountLineIn)
        Me._Frame1_0.Controls.Add(Me._lbl_20)
        Me._Frame1_0.Controls.Add(Me._lbl_21)
        Me._Frame1_0.Controls.Add(Me.lblExclusiveIn)
        Me._Frame1_0.Controls.Add(Me._lbl_22)
        Me._Frame1_0.Controls.Add(Me._lbl_29)
        Me._Frame1_0.Controls.Add(Me.lblVATin)
        Me._Frame1_0.Controls.Add(Me._lbl_30)
        Me._Frame1_0.Controls.Add(Me.lblInclusiveIn)
        Me._Frame1_0.Controls.Add(Me.lblVatRateIn)
        Me._Frame1_0.Controls.Add(Me._lbl_19)
        Me._Frame1_0.Controls.Add(Me._Label1_1)
        Me._Frame1_0.Controls.Add(Me.Label2)
        Me._Frame1_0.Controls.Add(Me._Label1_0)
        Me._Frame1_0.Controls.Add(Me.lblDiscount)
        Me._Frame1_0.Controls.Add(Me.lblUllage)
        Me._Frame1_0.Controls.Add(Me.lblDiscountName)
        Me._Frame1_0.Controls.Add(Me._lbl_31)
        Me._Frame1_0.Controls.Add(Me.lblContentExclusiveIn)
        Me._Frame1_0.Controls.Add(Me._lbl_11)
        Me._Frame1_0.Controls.Add(Me._lbl_10)
        Me._Frame1_0.Controls.Add(Me._lbl_32)
        Me._Frame1_0.Controls.Add(Me.lblLinesIn)
        Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_0.Location = New System.Drawing.Point(9, 18)
        Me._Frame1_0.Name = "_Frame1_0"
        Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_0.Size = New System.Drawing.Size(301, 268)
        Me._Frame1_0.TabIndex = 12
        Me._Frame1_0.TabStop = False
        Me._Frame1_0.Text = "Purchased Content / Liquid"
        '
        'cmbPayment
        '
        Me.cmbPayment.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPayment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPayment.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPayment.Items.AddRange(New Object() {"C.O.D.", "15 Days", "30 Days", "60 Days", "90 Days", "120 Days", "Smart Card"})
        Me.cmbPayment.Location = New System.Drawing.Point(153, 96)
        Me.cmbPayment.Name = "cmbPayment"
        Me.cmbPayment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPayment.Size = New System.Drawing.Size(91, 22)
        Me.cmbPayment.TabIndex = 0
        '
        'txtUllage
        '
        Me.txtUllage.AcceptsReturn = True
        Me.txtUllage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUllage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUllage.Enabled = False
        Me.txtUllage.ForeColor = System.Drawing.Color.Red
        Me.txtUllage.Location = New System.Drawing.Point(99, 135)
        Me.txtUllage.MaxLength = 0
        Me.txtUllage.Name = "txtUllage"
        Me.txtUllage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUllage.Size = New System.Drawing.Size(40, 19)
        Me.txtUllage.TabIndex = 8
        Me.txtUllage.Text = "0.20"
        Me.txtUllage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscount
        '
        Me.txtDiscount.AcceptsReturn = True
        Me.txtDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.Enabled = False
        Me.txtDiscount.ForeColor = System.Drawing.Color.Red
        Me.txtDiscount.Location = New System.Drawing.Point(99, 117)
        Me.txtDiscount.MaxLength = 0
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDiscount.Size = New System.Drawing.Size(40, 19)
        Me.txtDiscount.TabIndex = 35
        Me.txtDiscount.TabStop = False
        Me.txtDiscount.Text = "2.00"
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinus
        '
        Me.txtMinus.AcceptsReturn = True
        Me.txtMinus.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinus.ForeColor = System.Drawing.Color.Red
        Me.txtMinus.Location = New System.Drawing.Point(153, 180)
        Me.txtMinus.MaxLength = 0
        Me.txtMinus.Name = "txtMinus"
        Me.txtMinus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinus.Size = New System.Drawing.Size(91, 19)
        Me.txtMinus.TabIndex = 2
        Me.txtMinus.Text = "0.00"
        Me.txtMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPlus
        '
        Me.txtPlus.AcceptsReturn = True
        Me.txtPlus.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPlus.Location = New System.Drawing.Point(153, 159)
        Me.txtPlus.MaxLength = 0
        Me.txtPlus.Name = "txtPlus"
        Me.txtPlus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlus.Size = New System.Drawing.Size(91, 19)
        Me.txtPlus.TabIndex = 1
        Me.txtPlus.Text = "0.00"
        Me.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblContentIn
        '
        Me.lblContentIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblContentIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContentIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContentIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContentIn.Location = New System.Drawing.Point(153, 33)
        Me.lblContentIn.Name = "lblContentIn"
        Me.lblContentIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContentIn.Size = New System.Drawing.Size(91, 19)
        Me.lblContentIn.TabIndex = 59
        Me.lblContentIn.Text = "0.00"
        Me.lblContentIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiscountLineIn
        '
        Me.lblDiscountLineIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDiscountLineIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiscountLineIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDiscountLineIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDiscountLineIn.Location = New System.Drawing.Point(153, 54)
        Me.lblDiscountLineIn.Name = "lblDiscountLineIn"
        Me.lblDiscountLineIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDiscountLineIn.Size = New System.Drawing.Size(91, 19)
        Me.lblDiscountLineIn.TabIndex = 58
        Me.lblDiscountLineIn.Text = "0.00"
        Me.lblDiscountLineIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_20
        '
        Me._lbl_20.BackColor = System.Drawing.Color.Transparent
        Me._lbl_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_20.Location = New System.Drawing.Point(18, 36)
        Me._lbl_20.Name = "_lbl_20"
        Me._lbl_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_20.Size = New System.Drawing.Size(133, 13)
        Me._lbl_20.TabIndex = 57
        Me._lbl_20.Text = "Contents Value :"
        Me._lbl_20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_21
        '
        Me._lbl_21.BackColor = System.Drawing.Color.Transparent
        Me._lbl_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_21.Location = New System.Drawing.Point(18, 57)
        Me._lbl_21.Name = "_lbl_21"
        Me._lbl_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_21.Size = New System.Drawing.Size(133, 13)
        Me._lbl_21.TabIndex = 56
        Me._lbl_21.Text = "Line Item Discount :"
        Me._lbl_21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblExclusiveIn
        '
        Me.lblExclusiveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExclusiveIn.Location = New System.Drawing.Point(153, 201)
        Me.lblExclusiveIn.Name = "lblExclusiveIn"
        Me.lblExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExclusiveIn.Size = New System.Drawing.Size(91, 19)
        Me.lblExclusiveIn.TabIndex = 55
        Me.lblExclusiveIn.Text = "0.00"
        Me.lblExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_22
        '
        Me._lbl_22.BackColor = System.Drawing.Color.Transparent
        Me._lbl_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_22.Location = New System.Drawing.Point(18, 204)
        Me._lbl_22.Name = "_lbl_22"
        Me._lbl_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_22.Size = New System.Drawing.Size(133, 13)
        Me._lbl_22.TabIndex = 54
        Me._lbl_22.Text = "Exclusive:"
        Me._lbl_22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_29
        '
        Me._lbl_29.BackColor = System.Drawing.Color.Transparent
        Me._lbl_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_29.Location = New System.Drawing.Point(18, 225)
        Me._lbl_29.Name = "_lbl_29"
        Me._lbl_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_29.Size = New System.Drawing.Size(133, 13)
        Me._lbl_29.TabIndex = 53
        Me._lbl_29.Text = "VAT :"
        Me._lbl_29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVATin
        '
        Me.lblVATin.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVATin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVATin.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVATin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVATin.Location = New System.Drawing.Point(153, 222)
        Me.lblVATin.Name = "lblVATin"
        Me.lblVATin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVATin.Size = New System.Drawing.Size(91, 19)
        Me.lblVATin.TabIndex = 52
        Me.lblVATin.Text = "0.00"
        Me.lblVATin.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_30
        '
        Me._lbl_30.BackColor = System.Drawing.Color.Transparent
        Me._lbl_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_30.Location = New System.Drawing.Point(18, 246)
        Me._lbl_30.Name = "_lbl_30"
        Me._lbl_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_30.Size = New System.Drawing.Size(133, 13)
        Me._lbl_30.TabIndex = 51
        Me._lbl_30.Text = "Inclusive:"
        Me._lbl_30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInclusiveIn
        '
        Me.lblInclusiveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInclusiveIn.Location = New System.Drawing.Point(153, 243)
        Me.lblInclusiveIn.Name = "lblInclusiveIn"
        Me.lblInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInclusiveIn.Size = New System.Drawing.Size(91, 19)
        Me.lblInclusiveIn.TabIndex = 50
        Me.lblInclusiveIn.Text = "0.00"
        Me.lblInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVatRateIn
        '
        Me.lblVatRateIn.BackColor = System.Drawing.Color.Transparent
        Me.lblVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVatRateIn.Location = New System.Drawing.Point(246, 225)
        Me.lblVatRateIn.Name = "lblVatRateIn"
        Me.lblVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVatRateIn.Size = New System.Drawing.Size(55, 16)
        Me.lblVatRateIn.TabIndex = 49
        Me.lblVatRateIn.Text = "0.00"
        '
        '_lbl_19
        '
        Me._lbl_19.BackColor = System.Drawing.Color.Transparent
        Me._lbl_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_19.Location = New System.Drawing.Point(18, 99)
        Me._lbl_19.Name = "_lbl_19"
        Me._lbl_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_19.Size = New System.Drawing.Size(133, 13)
        Me._lbl_19.TabIndex = 48
        Me._lbl_19.Text = "Payment Terms"
        Me._lbl_19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label1_1
        '
        Me._Label1_1.AutoSize = True
        Me._Label1_1.BackColor = System.Drawing.Color.Transparent
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.Color.Red
        Me._Label1_1.Location = New System.Drawing.Point(138, 138)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(19, 14)
        Me._Label1_1.TabIndex = 47
        Me._Label1_1.Text = "%:"
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(-36, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Ullage @"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label1_0
        '
        Me._Label1_0.AutoSize = True
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.Color.Red
        Me._Label1_0.Location = New System.Drawing.Point(138, 120)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(19, 14)
        Me._Label1_0.TabIndex = 45
        Me._Label1_0.Text = "%:"
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiscount
        '
        Me.lblDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiscount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDiscount.ForeColor = System.Drawing.Color.Red
        Me.lblDiscount.Location = New System.Drawing.Point(153, 117)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDiscount.Size = New System.Drawing.Size(91, 19)
        Me.lblDiscount.TabIndex = 44
        Me.lblDiscount.Text = "0.00"
        Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUllage
        '
        Me.lblUllage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUllage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUllage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUllage.ForeColor = System.Drawing.Color.Red
        Me.lblUllage.Location = New System.Drawing.Point(153, 138)
        Me.lblUllage.Name = "lblUllage"
        Me.lblUllage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUllage.Size = New System.Drawing.Size(91, 19)
        Me.lblUllage.TabIndex = 43
        Me.lblUllage.Text = "0.00"
        Me.lblUllage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiscountName
        '
        Me.lblDiscountName.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscountName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDiscountName.ForeColor = System.Drawing.Color.Red
        Me.lblDiscountName.Location = New System.Drawing.Point(-42, 120)
        Me.lblDiscountName.Name = "lblDiscountName"
        Me.lblDiscountName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDiscountName.Size = New System.Drawing.Size(133, 13)
        Me.lblDiscountName.TabIndex = 42
        Me.lblDiscountName.Text = "Account Discount"
        Me.lblDiscountName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_31
        '
        Me._lbl_31.BackColor = System.Drawing.Color.Transparent
        Me._lbl_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_31.Location = New System.Drawing.Point(18, 78)
        Me._lbl_31.Name = "_lbl_31"
        Me._lbl_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_31.Size = New System.Drawing.Size(133, 13)
        Me._lbl_31.TabIndex = 41
        Me._lbl_31.Text = "Content Sub Total :"
        Me._lbl_31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblContentExclusiveIn
        '
        Me.lblContentExclusiveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblContentExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContentExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContentExclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblContentExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContentExclusiveIn.Location = New System.Drawing.Point(153, 75)
        Me.lblContentExclusiveIn.Name = "lblContentExclusiveIn"
        Me.lblContentExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContentExclusiveIn.Size = New System.Drawing.Size(91, 19)
        Me.lblContentExclusiveIn.TabIndex = 40
        Me.lblContentExclusiveIn.Text = "0.00"
        Me.lblContentExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_11
        '
        Me._lbl_11.BackColor = System.Drawing.Color.Transparent
        Me._lbl_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_11.ForeColor = System.Drawing.Color.Red
        Me._lbl_11.Location = New System.Drawing.Point(18, 183)
        Me._lbl_11.Name = "_lbl_11"
        Me._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_11.Size = New System.Drawing.Size(133, 13)
        Me._lbl_11.TabIndex = 39
        Me._lbl_11.Text = "Sundry Minuses:"
        Me._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_10
        '
        Me._lbl_10.BackColor = System.Drawing.Color.Transparent
        Me._lbl_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_10.Location = New System.Drawing.Point(18, 162)
        Me._lbl_10.Name = "_lbl_10"
        Me._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_10.Size = New System.Drawing.Size(133, 13)
        Me._lbl_10.TabIndex = 38
        Me._lbl_10.Text = "Sundry Pluses:"
        Me._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_32
        '
        Me._lbl_32.BackColor = System.Drawing.Color.Transparent
        Me._lbl_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_32.Location = New System.Drawing.Point(18, 15)
        Me._lbl_32.Name = "_lbl_32"
        Me._lbl_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_32.Size = New System.Drawing.Size(133, 13)
        Me._lbl_32.TabIndex = 37
        Me._lbl_32.Text = "No Of Lines :"
        Me._lbl_32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLinesIn
        '
        Me.lblLinesIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLinesIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLinesIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLinesIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLinesIn.Location = New System.Drawing.Point(153, 12)
        Me.lblLinesIn.Name = "lblLinesIn"
        Me.lblLinesIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLinesIn.Size = New System.Drawing.Size(91, 19)
        Me.lblLinesIn.TabIndex = 36
        Me.lblLinesIn.Text = "0"
        Me.lblLinesIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Frame1_1
        '
        Me._Frame1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Frame1_1.Controls.Add(Me.lblDepositVatRateIn)
        Me._Frame1_1.Controls.Add(Me.lblDepositIn)
        Me._Frame1_1.Controls.Add(Me._lbl_2)
        Me._Frame1_1.Controls.Add(Me.lblDepositVatIn)
        Me._Frame1_1.Controls.Add(Me._lbl_13)
        Me._Frame1_1.Controls.Add(Me.lblDepositInclusiveIn)
        Me._Frame1_1.Controls.Add(Me._lbl_14)
        Me._Frame1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_1.Location = New System.Drawing.Point(9, 285)
        Me._Frame1_1.Name = "_Frame1_1"
        Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_1.Size = New System.Drawing.Size(301, 82)
        Me._Frame1_1.TabIndex = 13
        Me._Frame1_1.TabStop = False
        Me._Frame1_1.Text = "Deposits with Purchases"
        '
        'lblDepositVatRateIn
        '
        Me.lblDepositVatRateIn.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositVatRateIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositVatRateIn.Location = New System.Drawing.Point(243, 39)
        Me.lblDepositVatRateIn.Name = "lblDepositVatRateIn"
        Me.lblDepositVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositVatRateIn.Size = New System.Drawing.Size(55, 16)
        Me.lblDepositVatRateIn.TabIndex = 60
        Me.lblDepositVatRateIn.Text = "0.00"
        '
        'lblDepositIn
        '
        Me.lblDepositIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositIn.Location = New System.Drawing.Point(150, 18)
        Me.lblDepositIn.Name = "lblDepositIn"
        Me.lblDepositIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositIn.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositIn.TabIndex = 15
        Me.lblDepositIn.Text = "0.00"
        Me.lblDepositIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_2
        '
        Me._lbl_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(16, 21)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(133, 13)
        Me._lbl_2.TabIndex = 14
        Me._lbl_2.Text = "Deposit Value:"
        Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositVatIn
        '
        Me.lblDepositVatIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositVatIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositVatIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositVatIn.Location = New System.Drawing.Point(150, 36)
        Me.lblDepositVatIn.Name = "lblDepositVatIn"
        Me.lblDepositVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositVatIn.Size = New System.Drawing.Size(91, 17)
        Me.lblDepositVatIn.TabIndex = 17
        Me.lblDepositVatIn.Text = "0.00"
        Me.lblDepositVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_13
        '
        Me._lbl_13.BackColor = System.Drawing.Color.Transparent
        Me._lbl_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_13.Location = New System.Drawing.Point(16, 39)
        Me._lbl_13.Name = "_lbl_13"
        Me._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_13.Size = New System.Drawing.Size(133, 13)
        Me._lbl_13.TabIndex = 16
        Me._lbl_13.Text = "VAT:"
        Me._lbl_13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDepositInclusiveIn
        '
        Me.lblDepositInclusiveIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDepositInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepositInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDepositInclusiveIn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDepositInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositInclusiveIn.Location = New System.Drawing.Point(150, 54)
        Me.lblDepositInclusiveIn.Name = "lblDepositInclusiveIn"
        Me.lblDepositInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDepositInclusiveIn.Size = New System.Drawing.Size(91, 19)
        Me.lblDepositInclusiveIn.TabIndex = 19
        Me.lblDepositInclusiveIn.Text = "0.00"
        Me.lblDepositInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_14
        '
        Me._lbl_14.BackColor = System.Drawing.Color.Transparent
        Me._lbl_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_14.Location = New System.Drawing.Point(16, 57)
        Me._lbl_14.Name = "_lbl_14"
        Me._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_14.Size = New System.Drawing.Size(133, 13)
        Me._lbl_14.TabIndex = 18
        Me._lbl_14.Text = "Inclusive:"
        Me._lbl_14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_28
        '
        Me._lbl_28.BackColor = System.Drawing.Color.Transparent
        Me._lbl_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_28.Location = New System.Drawing.Point(336, 456)
        Me._lbl_28.Name = "_lbl_28"
        Me._lbl_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_28.Size = New System.Drawing.Size(133, 13)
        Me._lbl_28.TabIndex = 93
        Me._lbl_28.Text = "In Bound VAT:"
        Me._lbl_28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInBoundVat
        '
        Me.lblInBoundVat.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblInBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInBoundVat.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInBoundVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInBoundVat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInBoundVat.Location = New System.Drawing.Point(470, 453)
        Me.lblInBoundVat.Name = "lblInBoundVat"
        Me.lblInBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInBoundVat.Size = New System.Drawing.Size(91, 19)
        Me.lblInBoundVat.TabIndex = 92
        Me.lblInBoundVat.Text = "0.00"
        Me.lblInBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_27
        '
        Me._lbl_27.BackColor = System.Drawing.Color.Transparent
        Me._lbl_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_27.Location = New System.Drawing.Point(337, 477)
        Me._lbl_27.Name = "_lbl_27"
        Me._lbl_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_27.Size = New System.Drawing.Size(133, 13)
        Me._lbl_27.TabIndex = 91
        Me._lbl_27.Text = "Credit Inclusive:"
        Me._lbl_27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInBound
        '
        Me.lblInBound.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblInBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInBound.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInBound.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInBound.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInBound.Location = New System.Drawing.Point(471, 474)
        Me.lblInBound.Name = "lblInBound"
        Me.lblInBound.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInBound.Size = New System.Drawing.Size(91, 19)
        Me.lblInBound.TabIndex = 90
        Me.lblInBound.Text = "0.00"
        Me.lblInBound.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_26
        '
        Me._lbl_26.BackColor = System.Drawing.Color.Transparent
        Me._lbl_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_26.Location = New System.Drawing.Point(336, 246)
        Me._lbl_26.Name = "_lbl_26"
        Me._lbl_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_26.Size = New System.Drawing.Size(133, 13)
        Me._lbl_26.TabIndex = 89
        Me._lbl_26.Text = "Credits VAT:"
        Me._lbl_26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCreditVat
        '
        Me.lblCreditVat.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCreditVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreditVat.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCreditVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCreditVat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCreditVat.Location = New System.Drawing.Point(470, 243)
        Me.lblCreditVat.Name = "lblCreditVat"
        Me.lblCreditVat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCreditVat.Size = New System.Drawing.Size(91, 19)
        Me.lblCreditVat.TabIndex = 88
        Me.lblCreditVat.Text = "0.00"
        Me.lblCreditVat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_25
        '
        Me._lbl_25.BackColor = System.Drawing.Color.Transparent
        Me._lbl_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_25.Location = New System.Drawing.Point(337, 267)
        Me._lbl_25.Name = "_lbl_25"
        Me._lbl_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_25.Size = New System.Drawing.Size(133, 13)
        Me._lbl_25.TabIndex = 87
        Me._lbl_25.Text = "Credits Inclusive:"
        Me._lbl_25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCredit
        '
        Me.lblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCredit.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCredit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCredit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCredit.Location = New System.Drawing.Point(471, 264)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCredit.Size = New System.Drawing.Size(91, 19)
        Me.lblCredit.TabIndex = 86
        Me.lblCredit.Text = "0.00"
        Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_8
        '
        Me._lbl_8.BackColor = System.Drawing.Color.Transparent
        Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_8.Location = New System.Drawing.Point(24, 456)
        Me._lbl_8.Name = "_lbl_8"
        Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_8.Size = New System.Drawing.Size(133, 13)
        Me._lbl_8.TabIndex = 85
        Me._lbl_8.Text = "Out Bound VAT:"
        Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblOutBoundVat
        '
        Me.lblOutBoundVat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblOutBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOutBoundVat.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOutBoundVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOutBoundVat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutBoundVat.Location = New System.Drawing.Point(158, 453)
        Me.lblOutBoundVat.Name = "lblOutBoundVat"
        Me.lblOutBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOutBoundVat.Size = New System.Drawing.Size(91, 19)
        Me.lblOutBoundVat.TabIndex = 84
        Me.lblOutBoundVat.Text = "0.00"
        Me.lblOutBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblOutBound
        '
        Me.lblOutBound.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblOutBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOutBound.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOutBound.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOutBound.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutBound.Location = New System.Drawing.Point(159, 474)
        Me.lblOutBound.Name = "lblOutBound"
        Me.lblOutBound.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOutBound.Size = New System.Drawing.Size(91, 19)
        Me.lblOutBound.TabIndex = 21
        Me.lblOutBound.Text = "0.00"
        Me.lblOutBound.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_6
        '
        Me._lbl_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_6.Location = New System.Drawing.Point(25, 477)
        Me._lbl_6.Name = "_lbl_6"
        Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_6.Size = New System.Drawing.Size(133, 13)
        Me._lbl_6.TabIndex = 20
        Me._lbl_6.Text = "Purchases Inclusive:"
        Me._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(531, 522)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(91, 19)
        Me.lblTotal.TabIndex = 10
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_7
        '
        Me._lbl_7.BackColor = System.Drawing.Color.Transparent
        Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_7.Location = New System.Drawing.Point(396, 525)
        Me._lbl_7.Name = "_lbl_7"
        Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_7.Size = New System.Drawing.Size(133, 13)
        Me._lbl_7.TabIndex = 9
        Me._lbl_7.Text = "Nett Invoice Value:"
        Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_0
        '
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(24, 504)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(133, 13)
        Me._lbl_0.TabIndex = 29
        Me._lbl_0.Text = "Desired Invoice Value:"
        Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalOriginal
        '
        Me.lblTotalOriginal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotalOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalOriginal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalOriginal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalOriginal.Location = New System.Drawing.Point(159, 501)
        Me.lblTotalOriginal.Name = "lblTotalOriginal"
        Me.lblTotalOriginal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotalOriginal.Size = New System.Drawing.Size(91, 19)
        Me.lblTotalOriginal.TabIndex = 30
        Me.lblTotalOriginal.Text = "0.00"
        Me.lblTotalOriginal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDifference
        '
        Me.lblDifference.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDifference.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDifference.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDifference.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDifference.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDifference.Location = New System.Drawing.Point(159, 522)
        Me.lblDifference.Name = "lblDifference"
        Me.lblDifference.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDifference.Size = New System.Drawing.Size(91, 19)
        Me.lblDifference.TabIndex = 32
        Me.lblDifference.Text = "0.00"
        Me.lblDifference.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_18
        '
        Me._lbl_18.BackColor = System.Drawing.Color.Transparent
        Me._lbl_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_18.Location = New System.Drawing.Point(24, 525)
        Me._lbl_18.Name = "_lbl_18"
        Me._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_18.Size = New System.Drawing.Size(133, 13)
        Me._lbl_18.TabIndex = 31
        Me._lbl_18.Text = "Difference:"
        Me._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.Red
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me.lblSupplier)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(0, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(760, 25)
        Me.Picture1.TabIndex = 33
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
        Me.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSupplier.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSupplier.ForeColor = System.Drawing.Color.White
        Me.lblSupplier.Location = New System.Drawing.Point(0, 0)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSupplier.Size = New System.Drawing.Size(91, 19)
        Me.lblSupplier.TabIndex = 34
        Me.lblSupplier.Text = "lblSupplier"
        '
        'frmGRVSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(760, 684)
        Me.ControlBox = False
        Me.Controls.Add(Me.Picture2)
        Me.Controls.Add(Me.frmProcess)
        Me.Controls.Add(Me.frmMain)
        Me.Controls.Add(Me.Picture1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmGRVSummary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GRV Summary and Process"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Picture2.ResumeLayout(False)
        Me.frmProcess.ResumeLayout(False)
        Me.frmProcess.PerformLayout()
        Me.frmMain.ResumeLayout(False)
        Me._Frame1_5.ResumeLayout(False)
        Me._Frame1_3.ResumeLayout(False)
        Me._Frame1_4.ResumeLayout(False)
        Me._Frame1_2.ResumeLayout(False)
        Me._Frame1_0.ResumeLayout(False)
        Me._Frame1_0.PerformLayout()
        Me._Frame1_1.ResumeLayout(False)
        Me.Picture1.ResumeLayout(False)
        Me.Picture1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class