<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRV
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
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdNewGT As System.Windows.Forms.Button
	Public WithEvents MonthView1 As System.Windows.Forms.MonthCalendar
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
	Public WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Public WithEvents cmbTemplate As myDataGridView
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblData_3 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _lbl_6 As System.Windows.Forms.Label
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents _lblData_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_36 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _lblData_0 As System.Windows.Forms.Label
	Public WithEvents _lblData_1 As System.Windows.Forms.Label
	Public WithEvents _lblData_2 As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRV))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.tmrAutoGRV = New System.Windows.Forms.Timer(components)
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me._frmMode_1 = New System.Windows.Forms.GroupBox
		Me.cmdNewGT = New System.Windows.Forms.Button
		Me.MonthView1 = New System.Windows.Forms.MonthCalendar
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
		Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.cmbTemplate = New myDataGridView
		Me._lbl_4 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblData_3 = New System.Windows.Forms.Label
		Me._lbl_5 = New System.Windows.Forms.Label
		Me._lbl_6 = New System.Windows.Forms.Label
		Me._lbl_7 = New System.Windows.Forms.Label
		Me._lblData_7 = New System.Windows.Forms.Label
		Me._lblLabels_36 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_8 = New System.Windows.Forms.Label
		Me._lblLabels_9 = New System.Windows.Forms.Label
		Me._lblData_0 = New System.Windows.Forms.Label
		Me._lblData_1 = New System.Windows.Forms.Label
		Me._lblData_2 = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblData = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New OvalShapeArray(components)
		Me._frmMode_1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblData, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Process a 'Good Receiving Voucher'"
		Me.ClientSize = New System.Drawing.Size(360, 449)
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
		Me.Name = "frmGRV"
		Me.tmrAutoGRV.Enabled = False
		Me.tmrAutoGRV.Interval = 10
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(97, 34)
		Me.cmdNext.Location = New System.Drawing.Point(246, 409)
		Me.cmdNext.TabIndex = 9
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
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(97, 34)
		Me.cmdBack.Location = New System.Drawing.Point(15, 409)
		Me.cmdBack.TabIndex = 8
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me._frmMode_1.Text = "Select a supplier to transact with."
		Me._frmMode_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmMode_1.Size = New System.Drawing.Size(346, 395)
		Me._frmMode_1.Location = New System.Drawing.Point(6, 6)
		Me._frmMode_1.TabIndex = 10
		Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_1.Enabled = True
		Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_1.Visible = True
		Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_1.Name = "_frmMode_1"
		Me.cmdNewGT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNewGT.Text = "Maintain GRV Templates"
		Me.AcceptButton = Me.cmdNewGT
		Me.cmdNewGT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNewGT.Size = New System.Drawing.Size(169, 23)
		Me.cmdNewGT.Location = New System.Drawing.Point(167, 144)
		Me.cmdNewGT.TabIndex = 24
		Me.cmdNewGT.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNewGT.CausesValidation = True
		Me.cmdNewGT.Enabled = True
		Me.cmdNewGT.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNewGT.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNewGT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNewGT.TabStop = True
		Me.cmdNewGT.Name = "cmdNewGT"
        'MonthView1.OcxState = CType(resources.GetObject("MonthView1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MonthView1.Size = New System.Drawing.Size(176, 154)
		Me.MonthView1.Location = New System.Drawing.Point(72, 223)
		Me.MonthView1.TabIndex = 6
		Me.MonthView1.Name = "MonthView1"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "Load GRV"
		Me.cmdLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdLoad.Size = New System.Drawing.Size(73, 52)
		Me.cmdLoad.Location = New System.Drawing.Point(255, 322)
		Me.cmdLoad.TabIndex = 7
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.txtInvoiceTotal.AutoSize = False
		Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtInvoiceTotal.Size = New System.Drawing.Size(103, 19)
		Me.txtInvoiceTotal.Location = New System.Drawing.Point(147, 199)
		Me.txtInvoiceTotal.TabIndex = 4
		Me.txtInvoiceTotal.AcceptsReturn = True
		Me.txtInvoiceTotal.BackColor = System.Drawing.SystemColors.Window
		Me.txtInvoiceTotal.CausesValidation = True
		Me.txtInvoiceTotal.Enabled = True
		Me.txtInvoiceTotal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtInvoiceTotal.HideSelection = True
		Me.txtInvoiceTotal.ReadOnly = False
		Me.txtInvoiceTotal.Maxlength = 0
		Me.txtInvoiceTotal.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtInvoiceTotal.MultiLine = False
		Me.txtInvoiceTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtInvoiceTotal.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtInvoiceTotal.TabStop = True
		Me.txtInvoiceTotal.Visible = True
		Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
		Me.txtInvoiceNo.AutoSize = False
		Me.txtInvoiceNo.Size = New System.Drawing.Size(178, 19)
		Me.txtInvoiceNo.Location = New System.Drawing.Point(72, 178)
		Me.txtInvoiceNo.TabIndex = 2
		Me.txtInvoiceNo.AcceptsReturn = True
		Me.txtInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtInvoiceNo.CausesValidation = True
		Me.txtInvoiceNo.Enabled = True
		Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtInvoiceNo.HideSelection = True
		Me.txtInvoiceNo.ReadOnly = False
		Me.txtInvoiceNo.Maxlength = 0
		Me.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtInvoiceNo.MultiLine = False
		Me.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtInvoiceNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtInvoiceNo.TabStop = True
		Me.txtInvoiceNo.Visible = True
		Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtInvoiceNo.Name = "txtInvoiceNo"
        'cmbTemplate.OcxState = CType(resources.GetObject("cmbTemplate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbTemplate.Size = New System.Drawing.Size(228, 21)
		Me.cmbTemplate.Location = New System.Drawing.Point(104, 117)
		Me.cmbTemplate.TabIndex = 22
		Me.cmbTemplate.Name = "cmbTemplate"
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_4.Text = "GRV Template :"
		Me._lbl_4.Size = New System.Drawing.Size(76, 13)
		Me._lbl_4.Location = New System.Drawing.Point(22, 120)
		Me._lbl_4.TabIndex = 23
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
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.Text = "Order Reference:"
		Me._lblLabels_0.Size = New System.Drawing.Size(82, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(16, 96)
		Me._lblLabels_0.TabIndex = 21
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
		Me._lblData_3.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_3.Text = "PurchaseOrder_Reference"
		Me._lblData_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_3.Size = New System.Drawing.Size(226, 16)
		Me._lblData_3.Location = New System.Drawing.Point(106, 96)
		Me._lblData_3.TabIndex = 20
		Me._lblData_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_3.Enabled = True
		Me._lblData_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_3.UseMnemonic = True
		Me._lblData_3.Visible = True
		Me._lblData_3.AutoSize = False
		Me._lblData_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_3.Name = "_lblData_3"
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_5.Text = "Number :"
		Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_5.Size = New System.Drawing.Size(52, 13)
		Me._lbl_5.Location = New System.Drawing.Point(14, 181)
		Me._lbl_5.TabIndex = 1
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Enabled = True
		Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_5.UseMnemonic = True
		Me._lbl_5.Visible = True
		Me._lbl_5.AutoSize = True
		Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_5.Name = "_lbl_5"
		Me._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_6.Text = "Total :"
		Me._lbl_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_6.Size = New System.Drawing.Size(38, 13)
		Me._lbl_6.Location = New System.Drawing.Point(103, 202)
		Me._lbl_6.TabIndex = 3
		Me._lbl_6.BackColor = System.Drawing.Color.Transparent
		Me._lbl_6.Enabled = True
		Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_6.UseMnemonic = True
		Me._lbl_6.Visible = True
		Me._lbl_6.AutoSize = True
		Me._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_6.Name = "_lbl_6"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "Date :"
		Me._lbl_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_7.Size = New System.Drawing.Size(36, 13)
		Me._lbl_7.Location = New System.Drawing.Point(30, 220)
		Me._lbl_7.TabIndex = 5
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
		Me._lblData_7.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._lblData_7.Text = "Supplier_ShippingCode"
		Me._lblData_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblData_7.Size = New System.Drawing.Size(226, 16)
		Me._lblData_7.Location = New System.Drawing.Point(105, 75)
		Me._lblData_7.TabIndex = 19
		Me._lblData_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_7.Enabled = True
		Me._lblData_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_7.UseMnemonic = True
		Me._lblData_7.Visible = True
		Me._lblData_7.AutoSize = False
		Me._lblData_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_7.Name = "_lblData_7"
		Me._lblLabels_36.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_36.Text = "Account Number:"
		Me._lblLabels_36.Size = New System.Drawing.Size(83, 13)
		Me._lblLabels_36.Location = New System.Drawing.Point(14, 75)
		Me._lblLabels_36.TabIndex = 18
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
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Text = "&2. Invoice Details"
		Me._lbl_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_2.Size = New System.Drawing.Size(101, 13)
		Me._lbl_2.Location = New System.Drawing.Point(9, 152)
		Me._lbl_2.TabIndex = 0
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
		Me._lbl_1.Text = "&1. Supplier Details"
		Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_1.Size = New System.Drawing.Size(105, 13)
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
		Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
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
		Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_8.Text = "Telephone:"
		Me._lblLabels_8.Size = New System.Drawing.Size(55, 13)
		Me._lblLabels_8.Location = New System.Drawing.Point(42, 57)
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
		Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_9.Text = "Fax:"
		Me._lblLabels_9.Size = New System.Drawing.Size(22, 13)
		Me._lblLabels_9.Location = New System.Drawing.Point(210, 57)
		Me._lblLabels_9.TabIndex = 14
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
		Me._lblData_0.TabIndex = 13
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
		Me._lblData_1.TabIndex = 12
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
		Me._lblData_2.TabIndex = 11
		Me._lblData_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblData_2.Enabled = True
		Me._lblData_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblData_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblData_2.UseMnemonic = True
		Me._lblData_2.Visible = True
		Me._lblData_2.AutoSize = False
		Me._lblData_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lblData_2.Name = "_lblData_2"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(328, 112)
		Me._Shape1_1.Location = New System.Drawing.Point(9, 20)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(328, 214)
		Me._Shape1_2.Location = New System.Drawing.Point(9, 156)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdBack)
		Me.Controls.Add(_frmMode_1)
		Me._frmMode_1.Controls.Add(cmdNewGT)
		Me._frmMode_1.Controls.Add(MonthView1)
		Me._frmMode_1.Controls.Add(cmdLoad)
		Me._frmMode_1.Controls.Add(txtInvoiceTotal)
		Me._frmMode_1.Controls.Add(txtInvoiceNo)
		Me._frmMode_1.Controls.Add(cmbTemplate)
		Me._frmMode_1.Controls.Add(_lbl_4)
		Me._frmMode_1.Controls.Add(_lblLabels_0)
		Me._frmMode_1.Controls.Add(_lblData_3)
		Me._frmMode_1.Controls.Add(_lbl_5)
		Me._frmMode_1.Controls.Add(_lbl_6)
		Me._frmMode_1.Controls.Add(_lbl_7)
		Me._frmMode_1.Controls.Add(_lblData_7)
		Me._frmMode_1.Controls.Add(_lblLabels_36)
		Me._frmMode_1.Controls.Add(_lbl_2)
		Me._frmMode_1.Controls.Add(_lbl_1)
		Me._frmMode_1.Controls.Add(_lblLabels_2)
		Me._frmMode_1.Controls.Add(_lblLabels_8)
		Me._frmMode_1.Controls.Add(_lblLabels_9)
		Me._frmMode_1.Controls.Add(_lblData_0)
		Me._frmMode_1.Controls.Add(_lblData_1)
		Me._frmMode_1.Controls.Add(_lblData_2)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me._frmMode_1.Controls.Add(ShapeContainer1)
        'Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_6, CType(6, Short))
        'Me.lbl.SetIndex(_lbl_7, CType(7, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lblData.SetIndex(_lblData_3, CType(3, Short))
        'Me.lblData.SetIndex(_lblData_7, CType(7, Short))
        'Me.lblData.SetIndex(_lblData_0, CType(0, Short))
        'Me.lblData.SetIndex(_lblData_1, CType(1, Short))
        'Me.lblData.SetIndex(_lblData_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_36, CType(36, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
        'Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
        'Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
        'Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblData, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbTemplate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmMode_1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class