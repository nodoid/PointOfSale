<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustomerAllocPayment
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdAllocateFull As System.Windows.Forms.Button
	Public WithEvents cmdAllocate As System.Windows.Forms.Button
	Public WithEvents cmbMonth As System.Windows.Forms.ComboBox
	Public WithEvents txtCustomer As System.Windows.Forms.TextBox
	Public WithEvents cmdSearch As System.Windows.Forms.Button
	Public WithEvents cmbPOS As System.Windows.Forms.ComboBox
	Public WithEvents txtStock As System.Windows.Forms.TextBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdProfit As System.Windows.Forms.Button
	Public WithEvents txtSerial As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmbTerms As System.Windows.Forms.ComboBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_8 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_9 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_10 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_11 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFloat_12 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_13 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_14 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_15 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_16 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_17 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_18 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_19 As System.Windows.Forms.CheckBox
	Public WithEvents cmdInv As System.Windows.Forms.Button
	Public WithEvents cmdShowHistory As System.Windows.Forms.Button
	Public WithEvents cmdStatement As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents cmbChannel As myDataGridView
	Public WithEvents _lvPayment_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPayment_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvPayment As System.Windows.Forms.ListView
	Public WithEvents _lvTransaction_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransaction_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvTransaction As System.Windows.Forms.ListView
	Public WithEvents _lvTransAlloc_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransAlloc_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransAlloc_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransAlloc_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransAlloc_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvTransAlloc_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvTransAlloc As System.Windows.Forms.ListView
	Public WithEvents _lbl_9 As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents lblcount As System.Windows.Forms.Label
	Public WithEvents _lbl_6 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_11 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_12 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_13 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_15 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_17 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_10 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_14 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_16 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_18 As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.cmdAllocateFull = New System.Windows.Forms.Button()
        Me.cmdAllocate = New System.Windows.Forms.Button()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmbPOS = New System.Windows.Forms.ComboBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdProfit = New System.Windows.Forms.Button()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me._txtFields_0 = New System.Windows.Forms.TextBox()
        Me.cmbTerms = New System.Windows.Forms.ComboBox()
        Me._txtFields_2 = New System.Windows.Forms.TextBox()
        Me._txtFields_3 = New System.Windows.Forms.TextBox()
        Me._txtFields_4 = New System.Windows.Forms.TextBox()
        Me._txtFields_5 = New System.Windows.Forms.TextBox()
        Me._txtFields_6 = New System.Windows.Forms.TextBox()
        Me._txtFields_7 = New System.Windows.Forms.TextBox()
        Me._txtFields_8 = New System.Windows.Forms.TextBox()
        Me._txtFields_9 = New System.Windows.Forms.TextBox()
        Me._txtFields_10 = New System.Windows.Forms.TextBox()
        Me._chkFields_11 = New System.Windows.Forms.CheckBox()
        Me._txtFloat_12 = New System.Windows.Forms.TextBox()
        Me._txtFloat_13 = New System.Windows.Forms.TextBox()
        Me._txtFloat_14 = New System.Windows.Forms.TextBox()
        Me._txtFloat_15 = New System.Windows.Forms.TextBox()
        Me._txtFloat_16 = New System.Windows.Forms.TextBox()
        Me._txtFloat_17 = New System.Windows.Forms.TextBox()
        Me._txtFloat_18 = New System.Windows.Forms.TextBox()
        Me._chkFields_19 = New System.Windows.Forms.CheckBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdInv = New System.Windows.Forms.Button()
        Me.cmdShowHistory = New System.Windows.Forms.Button()
        Me.cmdStatement = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbChannel = New _4PosBackOffice.NET.myDataGridView()
        Me.lvPayment = New System.Windows.Forms.ListView()
        Me._lvPayment_ColumnHeader_1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvPayment_ColumnHeader_7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTransaction = New System.Windows.Forms.ListView()
        Me._lvTransaction_ColumnHeader_1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransaction_ColumnHeader_7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTransAlloc = New System.Windows.Forms.ListView()
        Me._lvTransAlloc_ColumnHeader_1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransAlloc_ColumnHeader_2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransAlloc_ColumnHeader_3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransAlloc_ColumnHeader_4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransAlloc_ColumnHeader_5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lvTransAlloc_ColumnHeader_6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._lbl_9 = New System.Windows.Forms.Label()
        Me._lbl_8 = New System.Windows.Forms.Label()
        Me._lbl_7 = New System.Windows.Forms.Label()
        Me.lblcount = New System.Windows.Forms.Label()
        Me._lbl_6 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me._lbl_2 = New System.Windows.Forms.Label()
        Me._lbl_3 = New System.Windows.Forms.Label()
        Me._lbl_4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._lblLabels_11 = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._lblLabels_12 = New System.Windows.Forms.Label()
        Me._lblLabels_13 = New System.Windows.Forms.Label()
        Me._lblLabels_15 = New System.Windows.Forms.Label()
        Me._lblLabels_17 = New System.Windows.Forms.Label()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
        Me._lbl_1 = New System.Windows.Forms.Label()
        Me._lblLabels_1 = New System.Windows.Forms.Label()
        Me._lblLabels_2 = New System.Windows.Forms.Label()
        Me._lblLabels_3 = New System.Windows.Forms.Label()
        Me._lblLabels_4 = New System.Windows.Forms.Label()
        Me._lblLabels_5 = New System.Windows.Forms.Label()
        Me._lblLabels_6 = New System.Windows.Forms.Label()
        Me._lblLabels_7 = New System.Windows.Forms.Label()
        Me._lblLabels_8 = New System.Windows.Forms.Label()
        Me._lblLabels_9 = New System.Windows.Forms.Label()
        Me._lblLabels_10 = New System.Windows.Forms.Label()
        Me._lblLabels_14 = New System.Windows.Forms.Label()
        Me._lblLabels_16 = New System.Windows.Forms.Label()
        Me._lblLabels_18 = New System.Windows.Forms.Label()
        Me.Shape1 = New _4PosBackOffice.NET.RectangleShapeArray(Me.components)
        Me.picButtons.SuspendLayout()
        CType(Me.cmbChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._Shape1_0, Me._Shape1_1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(659, 652)
        Me.ShapeContainer1.TabIndex = 72
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_0
        '
        Me._Shape1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_0.FillColor = System.Drawing.Color.Black
        Me.Shape1.SetIndex(Me._Shape1_0, CType(0, Short))
        Me._Shape1_0.Location = New System.Drawing.Point(342, 57)
        Me._Shape1_0.Name = "_Shape1_0"
        Me._Shape1_0.Size = New System.Drawing.Size(310, 111)
        '
        '_Shape1_1
        '
        Me._Shape1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_1.FillColor = System.Drawing.Color.Black
        Me.Shape1.SetIndex(Me._Shape1_1, CType(1, Short))
        Me._Shape1_1.Location = New System.Drawing.Point(6, 57)
        Me._Shape1_1.Name = "_Shape1_1"
        Me._Shape1_1.Size = New System.Drawing.Size(328, 112)
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(264, 480)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(129, 29)
        Me.Command1.TabIndex = 71
        Me.Command1.TabStop = False
        Me.Command1.Text = "&Un-Allocate Payment"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'cmdAllocateFull
        '
        Me.cmdAllocateFull.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllocateFull.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllocateFull.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllocateFull.Location = New System.Drawing.Point(400, 480)
        Me.cmdAllocateFull.Name = "cmdAllocateFull"
        Me.cmdAllocateFull.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllocateFull.Size = New System.Drawing.Size(129, 29)
        Me.cmdAllocateFull.TabIndex = 68
        Me.cmdAllocateFull.TabStop = False
        Me.cmdAllocateFull.Text = "&Allocate Full Payment"
        Me.cmdAllocateFull.UseVisualStyleBackColor = False
        '
        'cmdAllocate
        '
        Me.cmdAllocate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllocate.Location = New System.Drawing.Point(536, 480)
        Me.cmdAllocate.Name = "cmdAllocate"
        Me.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllocate.Size = New System.Drawing.Size(113, 29)
        Me.cmdAllocate.TabIndex = 64
        Me.cmdAllocate.TabStop = False
        Me.cmdAllocate.Text = "&Allocate Partial"
        Me.cmdAllocate.UseVisualStyleBackColor = False
        '
        'cmbMonth
        '
        Me.cmbMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMonth.Location = New System.Drawing.Point(729, 188)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonth.Size = New System.Drawing.Size(112, 21)
        Me.cmbMonth.TabIndex = 56
        '
        'txtCustomer
        '
        Me.txtCustomer.AcceptsReturn = True
        Me.txtCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustomer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustomer.Location = New System.Drawing.Point(729, 266)
        Me.txtCustomer.MaxLength = 0
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustomer.Size = New System.Drawing.Size(112, 19)
        Me.txtCustomer.TabIndex = 55
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Location = New System.Drawing.Point(748, 372)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(94, 28)
        Me.cmdSearch.TabIndex = 54
        Me.cmdSearch.Text = "&Search ..."
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'cmbPOS
        '
        Me.cmbPOS.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPOS.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPOS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPOS.Location = New System.Drawing.Point(729, 227)
        Me.cmbPOS.Name = "cmbPOS"
        Me.cmbPOS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPOS.Size = New System.Drawing.Size(112, 21)
        Me.cmbPOS.TabIndex = 53
        '
        'txtStock
        '
        Me.txtStock.AcceptsReturn = True
        Me.txtStock.BackColor = System.Drawing.SystemColors.Window
        Me.txtStock.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStock.Location = New System.Drawing.Point(729, 302)
        Me.txtStock.MaxLength = 0
        Me.txtStock.Name = "txtStock"
        Me.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStock.Size = New System.Drawing.Size(112, 19)
        Me.txtStock.TabIndex = 52
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(750, 480)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(94, 28)
        Me.cmdPrint.TabIndex = 50
        Me.cmdPrint.TabStop = False
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdProfit
        '
        Me.cmdProfit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProfit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdProfit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdProfit.Location = New System.Drawing.Point(752, 526)
        Me.cmdProfit.Name = "cmdProfit"
        Me.cmdProfit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdProfit.Size = New System.Drawing.Size(94, 28)
        Me.cmdProfit.TabIndex = 49
        Me.cmdProfit.TabStop = False
        Me.cmdProfit.Text = "&Detail Profit"
        Me.cmdProfit.UseVisualStyleBackColor = False
        '
        'txtSerial
        '
        Me.txtSerial.AcceptsReturn = True
        Me.txtSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSerial.Location = New System.Drawing.Point(730, 336)
        Me.txtSerial.MaxLength = 0
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial.Size = New System.Drawing.Size(112, 19)
        Me.txtSerial.TabIndex = 48
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.Enabled = False
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_0.Location = New System.Drawing.Point(924, 238)
        Me._txtFields_0.MaxLength = 0
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_0.TabIndex = 44
        '
        'cmbTerms
        '
        Me.cmbTerms.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTerms.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTerms.Enabled = False
        Me.cmbTerms.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTerms.Items.AddRange(New Object() {"C.O.D.", "Current", "30 Days", "60 Days", "90 Days"})
        Me.cmbTerms.Location = New System.Drawing.Point(567, 63)
        Me.cmbTerms.Name = "cmbTerms"
        Me.cmbTerms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTerms.Size = New System.Drawing.Size(79, 21)
        Me.cmbTerms.TabIndex = 23
        '
        '_txtFields_2
        '
        Me._txtFields_2.AcceptsReturn = True
        Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_2.Enabled = False
        Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_2.Location = New System.Drawing.Point(102, 63)
        Me._txtFields_2.MaxLength = 0
        Me._txtFields_2.Name = "_txtFields_2"
        Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_2.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_2.TabIndex = 2
        '
        '_txtFields_3
        '
        Me._txtFields_3.AcceptsReturn = True
        Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_3.Enabled = False
        Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_3.Location = New System.Drawing.Point(102, 84)
        Me._txtFields_3.MaxLength = 0
        Me._txtFields_3.Name = "_txtFields_3"
        Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_3.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_3.TabIndex = 4
        '
        '_txtFields_4
        '
        Me._txtFields_4.AcceptsReturn = True
        Me._txtFields_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_4.Enabled = False
        Me._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_4.Location = New System.Drawing.Point(15, 120)
        Me._txtFields_4.MaxLength = 0
        Me._txtFields_4.Name = "_txtFields_4"
        Me._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_4.Size = New System.Drawing.Size(157, 19)
        Me._txtFields_4.TabIndex = 6
        '
        '_txtFields_5
        '
        Me._txtFields_5.AcceptsReturn = True
        Me._txtFields_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_5.Enabled = False
        Me._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_5.Location = New System.Drawing.Point(174, 120)
        Me._txtFields_5.MaxLength = 0
        Me._txtFields_5.Name = "_txtFields_5"
        Me._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_5.Size = New System.Drawing.Size(154, 19)
        Me._txtFields_5.TabIndex = 8
        '
        '_txtFields_6
        '
        Me._txtFields_6.AcceptsReturn = True
        Me._txtFields_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_6.Location = New System.Drawing.Point(918, 115)
        Me._txtFields_6.MaxLength = 0
        Me._txtFields_6.Multiline = True
        Me._txtFields_6.Name = "_txtFields_6"
        Me._txtFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_6.Size = New System.Drawing.Size(226, 58)
        Me._txtFields_6.TabIndex = 16
        '
        '_txtFields_7
        '
        Me._txtFields_7.AcceptsReturn = True
        Me._txtFields_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_7.Location = New System.Drawing.Point(918, 175)
        Me._txtFields_7.MaxLength = 0
        Me._txtFields_7.Multiline = True
        Me._txtFields_7.Name = "_txtFields_7"
        Me._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_7.Size = New System.Drawing.Size(226, 58)
        Me._txtFields_7.TabIndex = 18
        '
        '_txtFields_8
        '
        Me._txtFields_8.AcceptsReturn = True
        Me._txtFields_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_8.Enabled = False
        Me._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_8.Location = New System.Drawing.Point(102, 144)
        Me._txtFields_8.MaxLength = 0
        Me._txtFields_8.Name = "_txtFields_8"
        Me._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_8.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_8.TabIndex = 10
        '
        '_txtFields_9
        '
        Me._txtFields_9.AcceptsReturn = True
        Me._txtFields_9.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_9.Enabled = False
        Me._txtFields_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_9.Location = New System.Drawing.Point(926, 261)
        Me._txtFields_9.MaxLength = 0
        Me._txtFields_9.Name = "_txtFields_9"
        Me._txtFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_9.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_9.TabIndex = 12
        '
        '_txtFields_10
        '
        Me._txtFields_10.AcceptsReturn = True
        Me._txtFields_10.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_10.Enabled = False
        Me._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_10.Location = New System.Drawing.Point(926, 282)
        Me._txtFields_10.MaxLength = 0
        Me._txtFields_10.Name = "_txtFields_10"
        Me._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_10.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_10.TabIndex = 14
        '
        '_chkFields_11
        '
        Me._chkFields_11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_11.Location = New System.Drawing.Point(829, 83)
        Me._chkFields_11.Name = "_chkFields_11"
        Me._chkFields_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_11.Size = New System.Drawing.Size(214, 19)
        Me._chkFields_11.TabIndex = 39
        Me._chkFields_11.Text = "Disable this customer from Point Of Sale:"
        Me._chkFields_11.UseVisualStyleBackColor = False
        '
        '_txtFloat_12
        '
        Me._txtFloat_12.AcceptsReturn = True
        Me._txtFloat_12.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_12.Enabled = False
        Me._txtFloat_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_12.Location = New System.Drawing.Point(423, 63)
        Me._txtFloat_12.MaxLength = 0
        Me._txtFloat_12.Name = "_txtFloat_12"
        Me._txtFloat_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_12.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_12.TabIndex = 21
        Me._txtFloat_12.Text = "9,999,999.00"
        Me._txtFloat_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_13
        '
        Me._txtFloat_13.AcceptsReturn = True
        Me._txtFloat_13.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_13.Enabled = False
        Me._txtFloat_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_13.Location = New System.Drawing.Point(423, 87)
        Me._txtFloat_13.MaxLength = 0
        Me._txtFloat_13.Name = "_txtFloat_13"
        Me._txtFloat_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_13.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_13.TabIndex = 25
        Me._txtFloat_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_14
        '
        Me._txtFloat_14.AcceptsReturn = True
        Me._txtFloat_14.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_14.Enabled = False
        Me._txtFloat_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_14.Location = New System.Drawing.Point(567, 87)
        Me._txtFloat_14.MaxLength = 0
        Me._txtFloat_14.Name = "_txtFloat_14"
        Me._txtFloat_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_14.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_14.TabIndex = 27
        Me._txtFloat_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_15
        '
        Me._txtFloat_15.AcceptsReturn = True
        Me._txtFloat_15.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_15.Enabled = False
        Me._txtFloat_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_15.Location = New System.Drawing.Point(423, 108)
        Me._txtFloat_15.MaxLength = 0
        Me._txtFloat_15.Name = "_txtFloat_15"
        Me._txtFloat_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_15.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_15.TabIndex = 29
        Me._txtFloat_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_16
        '
        Me._txtFloat_16.AcceptsReturn = True
        Me._txtFloat_16.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_16.Enabled = False
        Me._txtFloat_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_16.Location = New System.Drawing.Point(567, 108)
        Me._txtFloat_16.MaxLength = 0
        Me._txtFloat_16.Name = "_txtFloat_16"
        Me._txtFloat_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_16.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_16.TabIndex = 31
        Me._txtFloat_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_17
        '
        Me._txtFloat_17.AcceptsReturn = True
        Me._txtFloat_17.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_17.Enabled = False
        Me._txtFloat_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_17.Location = New System.Drawing.Point(423, 129)
        Me._txtFloat_17.MaxLength = 0
        Me._txtFloat_17.Name = "_txtFloat_17"
        Me._txtFloat_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_17.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_17.TabIndex = 33
        Me._txtFloat_17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtFloat_18
        '
        Me._txtFloat_18.AcceptsReturn = True
        Me._txtFloat_18.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_18.Enabled = False
        Me._txtFloat_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_18.Location = New System.Drawing.Point(567, 129)
        Me._txtFloat_18.MaxLength = 0
        Me._txtFloat_18.Name = "_txtFloat_18"
        Me._txtFloat_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_18.Size = New System.Drawing.Size(79, 19)
        Me._txtFloat_18.TabIndex = 35
        Me._txtFloat_18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_chkFields_19
        '
        Me._chkFields_19.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_19.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_19.Location = New System.Drawing.Point(811, 65)
        Me._chkFields_19.Name = "_chkFields_19"
        Me._chkFields_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_19.Size = New System.Drawing.Size(232, 19)
        Me._chkFields_19.TabIndex = 38
        Me._chkFields_19.Text = "Automatically print a statement at monthend:"
        Me._chkFields_19.UseVisualStyleBackColor = False
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdInv)
        Me.picButtons.Controls.Add(Me.cmdShowHistory)
        Me.picButtons.Controls.Add(Me.cmdStatement)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(659, 38)
        Me.picButtons.TabIndex = 42
        '
        'cmdInv
        '
        Me.cmdInv.BackColor = System.Drawing.SystemColors.Control
        Me.cmdInv.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdInv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdInv.Location = New System.Drawing.Point(211, 3)
        Me.cmdInv.Name = "cmdInv"
        Me.cmdInv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdInv.Size = New System.Drawing.Size(73, 29)
        Me.cmdInv.TabIndex = 47
        Me.cmdInv.TabStop = False
        Me.cmdInv.Text = "&Print"
        Me.cmdInv.UseVisualStyleBackColor = False
        Me.cmdInv.Visible = False
        '
        'cmdShowHistory
        '
        Me.cmdShowHistory.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowHistory.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowHistory.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowHistory.Location = New System.Drawing.Point(88, 3)
        Me.cmdShowHistory.Name = "cmdShowHistory"
        Me.cmdShowHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowHistory.Size = New System.Drawing.Size(113, 29)
        Me.cmdShowHistory.TabIndex = 46
        Me.cmdShowHistory.TabStop = False
        Me.cmdShowHistory.Text = "&allocate"
        Me.cmdShowHistory.UseVisualStyleBackColor = False
        Me.cmdShowHistory.Visible = False
        '
        'cmdStatement
        '
        Me.cmdStatement.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStatement.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStatement.Location = New System.Drawing.Point(344, 3)
        Me.cmdStatement.Name = "cmdStatement"
        Me.cmdStatement.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStatement.Size = New System.Drawing.Size(73, 29)
        Me.cmdStatement.TabIndex = 43
        Me.cmdStatement.TabStop = False
        Me.cmdStatement.Text = "&Statement"
        Me.cmdStatement.UseVisualStyleBackColor = False
        Me.cmdStatement.Visible = False
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
        Me.cmdCancel.TabIndex = 40
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(576, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 41
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmbChannel
        '
        Me.cmbChannel.AllowAddNew = True
        Me.cmbChannel.BoundText = ""
        Me.cmbChannel.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbChannel.Col = 0
        Me.cmbChannel.CtlText = ""
        Me.cmbChannel.DataField = Nothing
        Me.cmbChannel.Location = New System.Drawing.Point(823, 38)
        Me.cmbChannel.Name = "cmbChannel"
        Me.cmbChannel.row = 0
        Me.cmbChannel.Size = New System.Drawing.Size(223, 21)
        Me.cmbChannel.TabIndex = 37
        Me.cmbChannel.TopRow = 0
        '
        'lvPayment
        '
        Me.lvPayment.BackColor = System.Drawing.SystemColors.Window
        Me.lvPayment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._lvPayment_ColumnHeader_1, Me._lvPayment_ColumnHeader_2, Me._lvPayment_ColumnHeader_3, Me._lvPayment_ColumnHeader_4, Me._lvPayment_ColumnHeader_5, Me._lvPayment_ColumnHeader_6, Me._lvPayment_ColumnHeader_7})
        Me.lvPayment.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvPayment.FullRowSelect = True
        Me.lvPayment.GridLines = True
        Me.lvPayment.HideSelection = False
        Me.lvPayment.LabelWrap = False
        Me.lvPayment.Location = New System.Drawing.Point(7, 192)
        Me.lvPayment.Name = "lvPayment"
        Me.lvPayment.Size = New System.Drawing.Size(646, 121)
        Me.lvPayment.TabIndex = 51
        Me.lvPayment.UseCompatibleStateImageBehavior = False
        Me.lvPayment.View = System.Windows.Forms.View.Details
        '
        '_lvPayment_ColumnHeader_1
        '
        Me._lvPayment_ColumnHeader_1.Text = "Date"
        Me._lvPayment_ColumnHeader_1.Width = 200
        '
        '_lvPayment_ColumnHeader_2
        '
        Me._lvPayment_ColumnHeader_2.Text = "Reference"
        Me._lvPayment_ColumnHeader_2.Width = 294
        '
        '_lvPayment_ColumnHeader_3
        '
        Me._lvPayment_ColumnHeader_3.Text = "Type"
        Me._lvPayment_ColumnHeader_3.Width = 177
        '
        '_lvPayment_ColumnHeader_4
        '
        Me._lvPayment_ColumnHeader_4.Text = "Debit"
        Me._lvPayment_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvPayment_ColumnHeader_4.Width = 0
        '
        '_lvPayment_ColumnHeader_5
        '
        Me._lvPayment_ColumnHeader_5.Text = "Credit"
        Me._lvPayment_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvPayment_ColumnHeader_5.Width = 142
        '
        '_lvPayment_ColumnHeader_6
        '
        Me._lvPayment_ColumnHeader_6.Text = "Allocated"
        Me._lvPayment_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvPayment_ColumnHeader_6.Width = 170
        '
        '_lvPayment_ColumnHeader_7
        '
        Me._lvPayment_ColumnHeader_7.Text = "Available"
        Me._lvPayment_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvPayment_ColumnHeader_7.Width = 142
        '
        'lvTransaction
        '
        Me.lvTransaction.BackColor = System.Drawing.SystemColors.Window
        Me.lvTransaction.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._lvTransaction_ColumnHeader_1, Me._lvTransaction_ColumnHeader_2, Me._lvTransaction_ColumnHeader_3, Me._lvTransaction_ColumnHeader_4, Me._lvTransaction_ColumnHeader_5, Me._lvTransaction_ColumnHeader_6, Me._lvTransaction_ColumnHeader_7})
        Me.lvTransaction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvTransaction.FullRowSelect = True
        Me.lvTransaction.GridLines = True
        Me.lvTransaction.HideSelection = False
        Me.lvTransaction.LabelWrap = False
        Me.lvTransaction.Location = New System.Drawing.Point(8, 336)
        Me.lvTransaction.Name = "lvTransaction"
        Me.lvTransaction.Size = New System.Drawing.Size(646, 137)
        Me.lvTransaction.TabIndex = 65
        Me.lvTransaction.UseCompatibleStateImageBehavior = False
        Me.lvTransaction.View = System.Windows.Forms.View.Details
        '
        '_lvTransaction_ColumnHeader_1
        '
        Me._lvTransaction_ColumnHeader_1.Text = "Date"
        Me._lvTransaction_ColumnHeader_1.Width = 200
        '
        '_lvTransaction_ColumnHeader_2
        '
        Me._lvTransaction_ColumnHeader_2.Text = "Reference"
        Me._lvTransaction_ColumnHeader_2.Width = 294
        '
        '_lvTransaction_ColumnHeader_3
        '
        Me._lvTransaction_ColumnHeader_3.Text = "Type"
        Me._lvTransaction_ColumnHeader_3.Width = 177
        '
        '_lvTransaction_ColumnHeader_4
        '
        Me._lvTransaction_ColumnHeader_4.Text = "Debit"
        Me._lvTransaction_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransaction_ColumnHeader_4.Width = 142
        '
        '_lvTransaction_ColumnHeader_5
        '
        Me._lvTransaction_ColumnHeader_5.Text = "Credit"
        Me._lvTransaction_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransaction_ColumnHeader_5.Width = 0
        '
        '_lvTransaction_ColumnHeader_6
        '
        Me._lvTransaction_ColumnHeader_6.Text = "Allocated"
        Me._lvTransaction_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransaction_ColumnHeader_6.Width = 170
        '
        '_lvTransaction_ColumnHeader_7
        '
        Me._lvTransaction_ColumnHeader_7.Text = "Outstanding"
        Me._lvTransaction_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransaction_ColumnHeader_7.Width = 142
        '
        'lvTransAlloc
        '
        Me.lvTransAlloc.BackColor = System.Drawing.SystemColors.Window
        Me.lvTransAlloc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._lvTransAlloc_ColumnHeader_1, Me._lvTransAlloc_ColumnHeader_2, Me._lvTransAlloc_ColumnHeader_3, Me._lvTransAlloc_ColumnHeader_4, Me._lvTransAlloc_ColumnHeader_5, Me._lvTransAlloc_ColumnHeader_6})
        Me.lvTransAlloc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvTransAlloc.FullRowSelect = True
        Me.lvTransAlloc.GridLines = True
        Me.lvTransAlloc.HideSelection = False
        Me.lvTransAlloc.LabelWrap = False
        Me.lvTransAlloc.Location = New System.Drawing.Point(8, 512)
        Me.lvTransAlloc.Name = "lvTransAlloc"
        Me.lvTransAlloc.Size = New System.Drawing.Size(646, 129)
        Me.lvTransAlloc.TabIndex = 70
        Me.lvTransAlloc.UseCompatibleStateImageBehavior = False
        Me.lvTransAlloc.View = System.Windows.Forms.View.Details
        '
        '_lvTransAlloc_ColumnHeader_1
        '
        Me._lvTransAlloc_ColumnHeader_1.Text = "Date"
        Me._lvTransAlloc_ColumnHeader_1.Width = 200
        '
        '_lvTransAlloc_ColumnHeader_2
        '
        Me._lvTransAlloc_ColumnHeader_2.Text = "Reference"
        Me._lvTransAlloc_ColumnHeader_2.Width = 294
        '
        '_lvTransAlloc_ColumnHeader_3
        '
        Me._lvTransAlloc_ColumnHeader_3.Text = "Type"
        Me._lvTransAlloc_ColumnHeader_3.Width = 177
        '
        '_lvTransAlloc_ColumnHeader_4
        '
        Me._lvTransAlloc_ColumnHeader_4.Text = "Debit"
        Me._lvTransAlloc_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransAlloc_ColumnHeader_4.Width = 142
        '
        '_lvTransAlloc_ColumnHeader_5
        '
        Me._lvTransAlloc_ColumnHeader_5.Text = "Credit"
        Me._lvTransAlloc_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransAlloc_ColumnHeader_5.Width = 0
        '
        '_lvTransAlloc_ColumnHeader_6
        '
        Me._lvTransAlloc_ColumnHeader_6.Text = "Allocated"
        Me._lvTransAlloc_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lvTransAlloc_ColumnHeader_6.Width = 170
        '
        '_lbl_9
        '
        Me._lbl_9.AutoSize = True
        Me._lbl_9.BackColor = System.Drawing.Color.Transparent
        Me._lbl_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_9.Location = New System.Drawing.Point(8, 496)
        Me._lbl_9.Name = "_lbl_9"
        Me._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_9.Size = New System.Drawing.Size(126, 14)
        Me._lbl_9.TabIndex = 69
        Me._lbl_9.Text = "&5. Invoices - Allocated"
        '
        '_lbl_8
        '
        Me._lbl_8.AutoSize = True
        Me._lbl_8.BackColor = System.Drawing.Color.Transparent
        Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_8.Location = New System.Drawing.Point(8, 320)
        Me._lbl_8.Name = "_lbl_8"
        Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_8.Size = New System.Drawing.Size(138, 14)
        Me._lbl_8.TabIndex = 67
        Me._lbl_8.Text = "&4. Invoices - Unallocated"
        '
        '_lbl_7
        '
        Me._lbl_7.AutoSize = True
        Me._lbl_7.BackColor = System.Drawing.Color.Transparent
        Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_7.Location = New System.Drawing.Point(8, 176)
        Me._lbl_7.Name = "_lbl_7"
        Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_7.Size = New System.Drawing.Size(74, 14)
        Me._lbl_7.TabIndex = 66
        Me._lbl_7.Text = "&3. Payments"
        '
        'lblcount
        '
        Me.lblcount.AutoSize = True
        Me.lblcount.BackColor = System.Drawing.SystemColors.Control
        Me.lblcount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblcount.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblcount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcount.Location = New System.Drawing.Point(791, 442)
        Me.lblcount.Name = "lblcount"
        Me.lblcount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblcount.Size = New System.Drawing.Size(57, 21)
        Me.lblcount.TabIndex = 63
        Me.lblcount.Text = "0 of 0"
        Me.lblcount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_6
        '
        Me._lbl_6.AutoSize = True
        Me._lbl_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_6.Location = New System.Drawing.Point(729, 173)
        Me._lbl_6.Name = "_lbl_6"
        Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_6.Size = New System.Drawing.Size(49, 13)
        Me._lbl_6.TabIndex = 62
        Me._lbl_6.Text = "&1. Month"
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(729, 212)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(81, 13)
        Me._lbl_5.TabIndex = 61
        Me._lbl_5.Text = "&2. Point Of Sale"
        '
        '_lbl_2
        '
        Me._lbl_2.AutoSize = True
        Me._lbl_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(729, 251)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(92, 13)
        Me._lbl_2.TabIndex = 60
        Me._lbl_2.Text = "&3. Customer name"
        '
        '_lbl_3
        '
        Me._lbl_3.AutoSize = True
        Me._lbl_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Location = New System.Drawing.Point(729, 287)
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.Size = New System.Drawing.Size(101, 13)
        Me._lbl_3.TabIndex = 59
        Me._lbl_3.Text = "&4. Stock Item Name"
        '
        '_lbl_4
        '
        Me._lbl_4.AutoSize = True
        Me._lbl_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_4.Location = New System.Drawing.Point(736, 416)
        Me._lbl_4.Name = "_lbl_4"
        Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_4.Size = New System.Drawing.Size(101, 13)
        Me._lbl_4.TabIndex = 58
        Me._lbl_4.Text = "&4. Stock Item Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(729, 322)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "&5: Serial Number"
        '
        '_lblLabels_11
        '
        Me._lblLabels_11.AutoSize = True
        Me._lblLabels_11.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_11.Location = New System.Drawing.Point(855, 241)
        Me._lblLabels_11.Name = "_lblLabels_11"
        Me._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_11.Size = New System.Drawing.Size(71, 13)
        Me._lblLabels_11.TabIndex = 45
        Me._lblLabels_11.Text = "VAT Number:"
        Me._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_0
        '
        Me._lbl_0.AutoSize = True
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(342, 42)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(73, 14)
        Me._lbl_0.TabIndex = 19
        Me._lbl_0.Text = "&2. Financials"
        '
        '_lblLabels_12
        '
        Me._lblLabels_12.AutoSize = True
        Me._lblLabels_12.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_12.Location = New System.Drawing.Point(363, 66)
        Me._lblLabels_12.Name = "_lblLabels_12"
        Me._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_12.Size = New System.Drawing.Size(61, 13)
        Me._lblLabels_12.TabIndex = 20
        Me._lblLabels_12.Text = "Credit Limit:"
        Me._lblLabels_12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_13
        '
        Me._lblLabels_13.AutoSize = True
        Me._lblLabels_13.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_13.Location = New System.Drawing.Point(381, 90)
        Me._lblLabels_13.Name = "_lblLabels_13"
        Me._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_13.Size = New System.Drawing.Size(44, 13)
        Me._lblLabels_13.TabIndex = 24
        Me._lblLabels_13.Text = "Current:"
        Me._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_15
        '
        Me._lblLabels_15.AutoSize = True
        Me._lblLabels_15.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_15.Location = New System.Drawing.Point(375, 111)
        Me._lblLabels_15.Name = "_lblLabels_15"
        Me._lblLabels_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_15.Size = New System.Drawing.Size(49, 13)
        Me._lblLabels_15.TabIndex = 28
        Me._lblLabels_15.Text = "60 Days:"
        Me._lblLabels_15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_17
        '
        Me._lblLabels_17.AutoSize = True
        Me._lblLabels_17.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_17.Location = New System.Drawing.Point(369, 132)
        Me._lblLabels_17.Name = "_lblLabels_17"
        Me._lblLabels_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_17.Size = New System.Drawing.Size(55, 13)
        Me._lblLabels_17.TabIndex = 32
        Me._lblLabels_17.Text = "120 Days:"
        Me._lblLabels_17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_0.Location = New System.Drawing.Point(530, 66)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(39, 13)
        Me._lblLabels_0.TabIndex = 22
        Me._lblLabels_0.Text = "Terms:"
        Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_1
        '
        Me._lbl_1.AutoSize = True
        Me._lbl_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_1.Location = New System.Drawing.Point(6, 42)
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.Size = New System.Drawing.Size(62, 14)
        Me._lbl_1.TabIndex = 0
        Me._lbl_1.Text = "&1. General"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_1.Location = New System.Drawing.Point(755, 44)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(73, 13)
        Me._lblLabels_1.TabIndex = 36
        Me._lblLabels_1.Text = "Sale Channel:"
        Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.AutoSize = True
        Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_2.Location = New System.Drawing.Point(12, 63)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(83, 14)
        Me._lblLabels_2.TabIndex = 1
        Me._lblLabels_2.Text = "Invoice Name:"
        Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.AutoSize = True
        Me._lblLabels_3.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_3.Location = New System.Drawing.Point(36, 84)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(65, 13)
        Me._lblLabels_3.TabIndex = 3
        Me._lblLabels_3.Text = "Department:"
        Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.AutoSize = True
        Me._lblLabels_4.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_4.Location = New System.Drawing.Point(9, 108)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(156, 14)
        Me._lblLabels_4.TabIndex = 5
        Me._lblLabels_4.Text = "Responsible Person Name:"
        Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_5
        '
        Me._lblLabels_5.AutoSize = True
        Me._lblLabels_5.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_5.Location = New System.Drawing.Point(174, 108)
        Me._lblLabels_5.Name = "_lblLabels_5"
        Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_5.Size = New System.Drawing.Size(60, 14)
        Me._lblLabels_5.TabIndex = 7
        Me._lblLabels_5.Text = "Surname:"
        Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_6
        '
        Me._lblLabels_6.AutoSize = True
        Me._lblLabels_6.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_6.Location = New System.Drawing.Point(819, 112)
        Me._lblLabels_6.Name = "_lblLabels_6"
        Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_6.Size = New System.Drawing.Size(90, 13)
        Me._lblLabels_6.TabIndex = 15
        Me._lblLabels_6.Text = "Physical Address:"
        Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_7
        '
        Me._lblLabels_7.AutoSize = True
        Me._lblLabels_7.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_7.Location = New System.Drawing.Point(837, 172)
        Me._lblLabels_7.Name = "_lblLabels_7"
        Me._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_7.Size = New System.Drawing.Size(80, 13)
        Me._lblLabels_7.TabIndex = 17
        Me._lblLabels_7.Text = "Postal Address:"
        Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_8
        '
        Me._lblLabels_8.AutoSize = True
        Me._lblLabels_8.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_8.Location = New System.Drawing.Point(42, 144)
        Me._lblLabels_8.Name = "_lblLabels_8"
        Me._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_8.Size = New System.Drawing.Size(61, 13)
        Me._lblLabels_8.TabIndex = 9
        Me._lblLabels_8.Text = "Telephone:"
        Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_9
        '
        Me._lblLabels_9.AutoSize = True
        Me._lblLabels_9.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_9.Location = New System.Drawing.Point(899, 261)
        Me._lblLabels_9.Name = "_lblLabels_9"
        Me._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_9.Size = New System.Drawing.Size(27, 13)
        Me._lblLabels_9.TabIndex = 11
        Me._lblLabels_9.Text = "Fax:"
        Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_10
        '
        Me._lblLabels_10.AutoSize = True
        Me._lblLabels_10.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_10.Location = New System.Drawing.Point(893, 282)
        Me._lblLabels_10.Name = "_lblLabels_10"
        Me._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_10.Size = New System.Drawing.Size(35, 13)
        Me._lblLabels_10.TabIndex = 13
        Me._lblLabels_10.Text = "Email:"
        Me._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_14
        '
        Me._lblLabels_14.AutoSize = True
        Me._lblLabels_14.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_14.Location = New System.Drawing.Point(519, 87)
        Me._lblLabels_14.Name = "_lblLabels_14"
        Me._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_14.Size = New System.Drawing.Size(49, 13)
        Me._lblLabels_14.TabIndex = 26
        Me._lblLabels_14.Text = "30 Days:"
        Me._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_16
        '
        Me._lblLabels_16.AutoSize = True
        Me._lblLabels_16.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_16.Location = New System.Drawing.Point(519, 108)
        Me._lblLabels_16.Name = "_lblLabels_16"
        Me._lblLabels_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_16.Size = New System.Drawing.Size(49, 13)
        Me._lblLabels_16.TabIndex = 30
        Me._lblLabels_16.Text = "90 Days:"
        Me._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_18
        '
        Me._lblLabels_18.AutoSize = True
        Me._lblLabels_18.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_18.Location = New System.Drawing.Point(513, 129)
        Me._lblLabels_18.Name = "_lblLabels_18"
        Me._lblLabels_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_18.Size = New System.Drawing.Size(55, 13)
        Me._lblLabels_18.TabIndex = 34
        Me._lblLabels_18.Text = "150 Days:"
        Me._lblLabels_18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCustomerAllocPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(659, 652)
        Me.ControlBox = False
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmdAllocateFull)
        Me.Controls.Add(Me.cmdAllocate)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmbPOS)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdProfit)
        Me.Controls.Add(Me.txtSerial)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.cmbTerms)
        Me.Controls.Add(Me._txtFields_2)
        Me.Controls.Add(Me._txtFields_3)
        Me.Controls.Add(Me._txtFields_4)
        Me.Controls.Add(Me._txtFields_5)
        Me.Controls.Add(Me._txtFields_6)
        Me.Controls.Add(Me._txtFields_7)
        Me.Controls.Add(Me._txtFields_8)
        Me.Controls.Add(Me._txtFields_9)
        Me.Controls.Add(Me._txtFields_10)
        Me.Controls.Add(Me._chkFields_11)
        Me.Controls.Add(Me._txtFloat_12)
        Me.Controls.Add(Me._txtFloat_13)
        Me.Controls.Add(Me._txtFloat_14)
        Me.Controls.Add(Me._txtFloat_15)
        Me.Controls.Add(Me._txtFloat_16)
        Me.Controls.Add(Me._txtFloat_17)
        Me.Controls.Add(Me._txtFloat_18)
        Me.Controls.Add(Me._chkFields_19)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.cmbChannel)
        Me.Controls.Add(Me.lvPayment)
        Me.Controls.Add(Me.lvTransaction)
        Me.Controls.Add(Me.lvTransAlloc)
        Me.Controls.Add(Me._lbl_9)
        Me.Controls.Add(Me._lbl_8)
        Me.Controls.Add(Me._lbl_7)
        Me.Controls.Add(Me.lblcount)
        Me.Controls.Add(Me._lbl_6)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me._lbl_2)
        Me.Controls.Add(Me._lbl_3)
        Me.Controls.Add(Me._lbl_4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_11)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me._lblLabels_12)
        Me.Controls.Add(Me._lblLabels_13)
        Me.Controls.Add(Me._lblLabels_15)
        Me.Controls.Add(Me._lblLabels_17)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lbl_1)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_5)
        Me.Controls.Add(Me._lblLabels_6)
        Me.Controls.Add(Me._lblLabels_7)
        Me.Controls.Add(Me._lblLabels_8)
        Me.Controls.Add(Me._lblLabels_9)
        Me.Controls.Add(Me._lblLabels_10)
        Me.Controls.Add(Me._lblLabels_14)
        Me.Controls.Add(Me._lblLabels_16)
        Me.Controls.Add(Me._lblLabels_18)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomerAllocPayment"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Allocation"
        Me.picButtons.ResumeLayout(False)
        CType(Me.cmbChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class