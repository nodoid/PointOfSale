<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVitemFnV
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
	Public WithEvents txtPackSize As System.Windows.Forms.TextBox
	Public WithEvents cmdEditPackSize As System.Windows.Forms.Button
	Public WithEvents frmFNVeg As System.Windows.Forms.GroupBox
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents txtBCode As System.Windows.Forms.TextBox
	Public WithEvents _txtEdit_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtEdit_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdPriceBOM As System.Windows.Forms.Button
	Public WithEvents tmrAutoGRV As System.Windows.Forms.Timer
	Public WithEvents cmdVat As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdStockItem As System.Windows.Forms.Button
	Public WithEvents cmdDiscount As System.Windows.Forms.Button
	Public WithEvents cmdPrintOrder As System.Windows.Forms.Button
	Public WithEvents cmdPrintGRV As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdPack As System.Windows.Forms.Button
	Public WithEvents cmdPrice As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdNew As System.Windows.Forms.Button
	Public WithEvents cmdQuick As System.Windows.Forms.Button
	Public WithEvents cmdSort As System.Windows.Forms.Button
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents _lblTotal_5 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_4 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_3 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_2 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_1 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_0 As System.Windows.Forms.Label
	Public WithEvents lblTotalInclusive As System.Windows.Forms.Label
	Public WithEvents lblTotalExclusive As System.Windows.Forms.Label
	Public WithEvents lblDepositInclusive As System.Windows.Forms.Label
	Public WithEvents lblDepositExclusive As System.Windows.Forms.Label
	Public WithEvents lblContentInclusive As System.Windows.Forms.Label
	Public WithEvents lblContentExclusive As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents lblBrokenPack As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents lblQuantity As System.Windows.Forms.Label
	Public WithEvents frmTotals As System.Windows.Forms.GroupBox
	Public WithEvents lblSupplier As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents _txtEdit_0 As System.Windows.Forms.TextBox
    Public WithEvents gridItem As myDataGridView
	Public WithEvents txtSearch0 As System.Windows.Forms.TextBox
	Public WithEvents lstWorkspace As System.Windows.Forms.ListBox
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblReturns As System.Windows.Forms.Label
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblTotal As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtEdit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVitemFnV))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frmFNVeg = New System.Windows.Forms.GroupBox
		Me.txtPackSize = New System.Windows.Forms.TextBox
		Me.cmdEditPackSize = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.txtBCode = New System.Windows.Forms.TextBox
		Me._txtEdit_2 = New System.Windows.Forms.TextBox
		Me._txtEdit_1 = New System.Windows.Forms.TextBox
		Me.Picture2 = New System.Windows.Forms.Panel
		Me.cmdPriceBOM = New System.Windows.Forms.Button
		Me.tmrAutoGRV = New System.Windows.Forms.Timer(components)
		Me.cmdVat = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.cmdStockItem = New System.Windows.Forms.Button
		Me.cmdDiscount = New System.Windows.Forms.Button
		Me.cmdPrintOrder = New System.Windows.Forms.Button
		Me.cmdPrintGRV = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdPack = New System.Windows.Forms.Button
		Me.cmdPrice = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdNew = New System.Windows.Forms.Button
		Me.cmdQuick = New System.Windows.Forms.Button
		Me.cmdSort = New System.Windows.Forms.Button
		Me.frmTotals = New System.Windows.Forms.GroupBox
		Me._lblTotal_5 = New System.Windows.Forms.Label
		Me._lblTotal_4 = New System.Windows.Forms.Label
		Me._lblTotal_3 = New System.Windows.Forms.Label
		Me._lblTotal_2 = New System.Windows.Forms.Label
		Me._lblTotal_1 = New System.Windows.Forms.Label
		Me._lblTotal_0 = New System.Windows.Forms.Label
		Me.lblTotalInclusive = New System.Windows.Forms.Label
		Me.lblTotalExclusive = New System.Windows.Forms.Label
		Me.lblDepositInclusive = New System.Windows.Forms.Label
		Me.lblDepositExclusive = New System.Windows.Forms.Label
		Me.lblContentInclusive = New System.Windows.Forms.Label
		Me.lblContentExclusive = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me.lblBrokenPack = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me.lblQuantity = New System.Windows.Forms.Label
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.lblSupplier = New System.Windows.Forms.Label
		Me._txtEdit_0 = New System.Windows.Forms.TextBox
        Me.gridItem = New myDataGridView
		Me.txtSearch0 = New System.Windows.Forms.TextBox
		Me.lstWorkspace = New System.Windows.Forms.ListBox
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblReturns = New System.Windows.Forms.Label
		Me._lbl_7 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblTotal = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtEdit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.frmFNVeg.SuspendLayout()
		Me.Picture2.SuspendLayout()
		Me.frmTotals.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "GRV Processing Form - Fruit and Veg"
		Me.ClientSize = New System.Drawing.Size(836, 566)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmGRVitemFnV"
		Me.frmFNVeg.Text = "Pack Size Volume"
		Me.frmFNVeg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmFNVeg.Size = New System.Drawing.Size(192, 49)
		Me.frmFNVeg.Location = New System.Drawing.Point(48, 472)
		Me.frmFNVeg.TabIndex = 48
		Me.frmFNVeg.BackColor = System.Drawing.SystemColors.Control
		Me.frmFNVeg.Enabled = True
		Me.frmFNVeg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmFNVeg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmFNVeg.Visible = True
		Me.frmFNVeg.Padding = New System.Windows.Forms.Padding(0)
		Me.frmFNVeg.Name = "frmFNVeg"
		Me.txtPackSize.AutoSize = False
		Me.txtPackSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPackSize.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtPackSize.Enabled = False
		Me.txtPackSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtPackSize.Size = New System.Drawing.Size(100, 19)
		Me.txtPackSize.Location = New System.Drawing.Point(8, 24)
		Me.txtPackSize.TabIndex = 50
		Me.txtPackSize.Text = "0.00"
		Me.txtPackSize.AcceptsReturn = True
		Me.txtPackSize.CausesValidation = True
		Me.txtPackSize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPackSize.HideSelection = True
		Me.txtPackSize.ReadOnly = False
		Me.txtPackSize.Maxlength = 0
		Me.txtPackSize.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPackSize.MultiLine = False
		Me.txtPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPackSize.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPackSize.TabStop = True
		Me.txtPackSize.Visible = True
		Me.txtPackSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPackSize.Name = "txtPackSize"
		Me.cmdEditPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEditPackSize.Text = "&Edit Size"
		Me.cmdEditPackSize.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdEditPackSize.Size = New System.Drawing.Size(70, 32)
		Me.cmdEditPackSize.Location = New System.Drawing.Point(112, 14)
		Me.cmdEditPackSize.TabIndex = 49
		Me.cmdEditPackSize.TabStop = False
		Me.cmdEditPackSize.Tag = "0"
		Me.cmdEditPackSize.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEditPackSize.CausesValidation = True
		Me.cmdEditPackSize.Enabled = True
		Me.cmdEditPackSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEditPackSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEditPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEditPackSize.Name = "cmdEditPackSize"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(142, 19)
		Me.txtSearch.Location = New System.Drawing.Point(45, 104)
		Me.txtSearch.TabIndex = 0
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
		Me.txtBCode.AutoSize = False
		Me.txtBCode.Size = New System.Drawing.Size(142, 19)
		Me.txtBCode.Location = New System.Drawing.Point(45, 99)
		Me.txtBCode.TabIndex = 1
		Me.txtBCode.Visible = False
		Me.txtBCode.AcceptsReturn = True
		Me.txtBCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtBCode.CausesValidation = True
		Me.txtBCode.Enabled = True
		Me.txtBCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBCode.HideSelection = True
		Me.txtBCode.ReadOnly = False
		Me.txtBCode.Maxlength = 0
		Me.txtBCode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBCode.MultiLine = False
		Me.txtBCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBCode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBCode.TabStop = True
		Me.txtBCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBCode.Name = "txtBCode"
		Me._txtEdit_2.AutoSize = False
		Me._txtEdit_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_2.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_2.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_2.Location = New System.Drawing.Point(534, 87)
		Me._txtEdit_2.Maxlength = 10
		Me._txtEdit_2.TabIndex = 43
		Me._txtEdit_2.Tag = "0"
		Me._txtEdit_2.Text = "0"
		Me._txtEdit_2.Visible = False
		Me._txtEdit_2.AcceptsReturn = True
		Me._txtEdit_2.CausesValidation = True
		Me._txtEdit_2.Enabled = True
		Me._txtEdit_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_2.HideSelection = True
		Me._txtEdit_2.ReadOnly = False
		Me._txtEdit_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_2.MultiLine = False
		Me._txtEdit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_2.TabStop = True
		Me._txtEdit_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_2.Name = "_txtEdit_2"
		Me._txtEdit_1.AutoSize = False
		Me._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_1.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_1.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_1.Location = New System.Drawing.Point(462, 87)
		Me._txtEdit_1.Maxlength = 10
		Me._txtEdit_1.TabIndex = 42
		Me._txtEdit_1.Tag = "0"
		Me._txtEdit_1.Text = "0"
		Me._txtEdit_1.Visible = False
		Me._txtEdit_1.AcceptsReturn = True
		Me._txtEdit_1.CausesValidation = True
		Me._txtEdit_1.Enabled = True
		Me._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_1.HideSelection = True
		Me._txtEdit_1.ReadOnly = False
		Me._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_1.MultiLine = False
		Me._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_1.TabStop = True
		Me._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_1.Name = "_txtEdit_1"
		Me.Picture2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture2.BackColor = System.Drawing.Color.Blue
		Me.Picture2.Size = New System.Drawing.Size(836, 49)
		Me.Picture2.Location = New System.Drawing.Point(0, 0)
		Me.Picture2.TabIndex = 27
		Me.Picture2.TabStop = False
		Me.Picture2.CausesValidation = True
		Me.Picture2.Enabled = True
		Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture2.Visible = True
		Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture2.Name = "Picture2"
		Me.cmdPriceBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPriceBOM.Text = "Change &BOM Price"
		Me.cmdPriceBOM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPriceBOM.Size = New System.Drawing.Size(70, 40)
		Me.cmdPriceBOM.Location = New System.Drawing.Point(731, 3)
		Me.cmdPriceBOM.TabIndex = 51
		Me.cmdPriceBOM.TabStop = False
		Me.cmdPriceBOM.Tag = "0"
		Me.cmdPriceBOM.Visible = False
		Me.cmdPriceBOM.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPriceBOM.CausesValidation = True
		Me.cmdPriceBOM.Enabled = True
		Me.cmdPriceBOM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPriceBOM.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPriceBOM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPriceBOM.Name = "cmdPriceBOM"
		Me.tmrAutoGRV.Enabled = False
		Me.tmrAutoGRV.Interval = 10
		Me.cmdVat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVat.Text = "Change VAT"
		Me.cmdVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdVat.Size = New System.Drawing.Size(70, 40)
		Me.cmdVat.Location = New System.Drawing.Point(435, 3)
		Me.cmdVat.TabIndex = 44
		Me.cmdVat.TabStop = False
		Me.cmdVat.Tag = "0"
		Me.cmdVat.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVat.CausesValidation = True
		Me.cmdVat.Enabled = True
		Me.cmdVat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVat.Name = "cmdVat"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(67, 40)
		Me.cmdExit.Location = New System.Drawing.Point(885, 3)
		Me.cmdExit.TabIndex = 40
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next >>"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(67, 40)
		Me.cmdNext.Location = New System.Drawing.Point(813, 3)
		Me.cmdNext.TabIndex = 39
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "<< &Back"
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(67, 40)
		Me.cmdBack.Location = New System.Drawing.Point(744, 3)
		Me.cmdBack.TabIndex = 38
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me.cmdStockItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStockItem.Text = "All Stoc&k Items"
		Me.cmdStockItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdStockItem.Size = New System.Drawing.Size(70, 40)
		Me.cmdStockItem.Location = New System.Drawing.Point(3, 3)
		Me.cmdStockItem.TabIndex = 37
		Me.cmdStockItem.TabStop = False
		Me.cmdStockItem.Tag = "0"
		Me.cmdStockItem.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStockItem.CausesValidation = True
		Me.cmdStockItem.Enabled = True
		Me.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStockItem.Name = "cmdStockItem"
		Me.cmdDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDiscount.Text = "&Discount"
		Me.cmdDiscount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdDiscount.Size = New System.Drawing.Size(70, 40)
		Me.cmdDiscount.Location = New System.Drawing.Point(291, 3)
		Me.cmdDiscount.TabIndex = 36
		Me.cmdDiscount.TabStop = False
		Me.cmdDiscount.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDiscount.CausesValidation = True
		Me.cmdDiscount.Enabled = True
		Me.cmdDiscount.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDiscount.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDiscount.Name = "cmdDiscount"
		Me.cmdPrintOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintOrder.Text = "Print &Order"
		Me.cmdPrintOrder.Size = New System.Drawing.Size(79, 19)
		Me.cmdPrintOrder.Location = New System.Drawing.Point(507, 3)
		Me.cmdPrintOrder.TabIndex = 35
		Me.cmdPrintOrder.TabStop = False
		Me.cmdPrintOrder.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintOrder.CausesValidation = True
		Me.cmdPrintOrder.Enabled = True
		Me.cmdPrintOrder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintOrder.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintOrder.Name = "cmdPrintOrder"
		Me.cmdPrintGRV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintGRV.Text = "Print &GRV"
		Me.cmdPrintGRV.Size = New System.Drawing.Size(79, 19)
		Me.cmdPrintGRV.Location = New System.Drawing.Point(507, 24)
		Me.cmdPrintGRV.TabIndex = 34
		Me.cmdPrintGRV.TabStop = False
		Me.cmdPrintGRV.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintGRV.CausesValidation = True
		Me.cmdPrintGRV.Enabled = True
		Me.cmdPrintGRV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintGRV.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintGRV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintGRV.Name = "cmdPrintGRV"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "Dele&te"
		Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdDelete.Size = New System.Drawing.Size(70, 40)
		Me.cmdDelete.Location = New System.Drawing.Point(75, 3)
		Me.cmdDelete.TabIndex = 33
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.Tag = "0"
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPack.Text = "Break / Build P&ack"
		Me.cmdPack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPack.Size = New System.Drawing.Size(70, 40)
		Me.cmdPack.Location = New System.Drawing.Point(147, 3)
		Me.cmdPack.TabIndex = 32
		Me.cmdPack.TabStop = False
		Me.cmdPack.Tag = "0"
		Me.cmdPack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPack.CausesValidation = True
		Me.cmdPack.Enabled = True
		Me.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPack.Name = "cmdPack"
		Me.cmdPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrice.Text = "&Change Price"
		Me.cmdPrice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPrice.Size = New System.Drawing.Size(70, 40)
		Me.cmdPrice.Location = New System.Drawing.Point(219, 3)
		Me.cmdPrice.TabIndex = 31
		Me.cmdPrice.TabStop = False
		Me.cmdPrice.Tag = "0"
		Me.cmdPrice.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrice.CausesValidation = True
		Me.cmdPrice.Enabled = True
		Me.cmdPrice.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrice.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrice.Name = "cmdPrice"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Edit Stock Item"
		Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdEdit.Size = New System.Drawing.Size(70, 40)
		Me.cmdEdit.Location = New System.Drawing.Point(588, 3)
		Me.cmdEdit.TabIndex = 30
		Me.cmdEdit.TabStop = False
		Me.cmdEdit.Tag = "0"
		Me.cmdEdit.Visible = False
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNew.Text = "Ne&w Stock Item"
		Me.cmdNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNew.Size = New System.Drawing.Size(70, 40)
		Me.cmdNew.Location = New System.Drawing.Point(660, 3)
		Me.cmdNew.TabIndex = 29
		Me.cmdNew.TabStop = False
		Me.cmdNew.Tag = "0"
		Me.cmdNew.Visible = False
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.Name = "cmdNew"
		Me.cmdQuick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdQuick.Text = "&Quick Edit"
		Me.cmdQuick.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdQuick.Size = New System.Drawing.Size(70, 40)
		Me.cmdQuick.Location = New System.Drawing.Point(363, 3)
		Me.cmdQuick.TabIndex = 28
		Me.cmdQuick.TabStop = False
		Me.cmdQuick.BackColor = System.Drawing.SystemColors.Control
		Me.cmdQuick.CausesValidation = True
		Me.cmdQuick.Enabled = True
		Me.cmdQuick.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdQuick.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdQuick.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdQuick.Name = "cmdQuick"
		Me.cmdSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSort.Text = "&Sort"
		Me.cmdSort.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdSort.Size = New System.Drawing.Size(73, 40)
		Me.cmdSort.Location = New System.Drawing.Point(3, 3)
		Me.cmdSort.TabIndex = 41
		Me.cmdSort.TabStop = False
		Me.cmdSort.Tag = "0"
		Me.cmdSort.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSort.CausesValidation = True
		Me.cmdSort.Enabled = True
		Me.cmdSort.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSort.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSort.Name = "cmdSort"
		Me.frmTotals.Text = "Sub Totals"
		Me.frmTotals.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmTotals.Size = New System.Drawing.Size(457, 130)
		Me.frmTotals.Location = New System.Drawing.Point(102, 294)
		Me.frmTotals.TabIndex = 9
		Me.frmTotals.BackColor = System.Drawing.SystemColors.Control
		Me.frmTotals.Enabled = True
		Me.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmTotals.Visible = True
		Me.frmTotals.Padding = New System.Windows.Forms.Padding(0)
		Me.frmTotals.Name = "frmTotals"
		Me._lblTotal_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_5.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_5.Text = "Inclusive Total :"
		Me._lblTotal_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_5.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_5.Location = New System.Drawing.Point(234, 102)
		Me._lblTotal_5.TabIndex = 26
		Me._lblTotal_5.Enabled = True
		Me._lblTotal_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_5.UseMnemonic = True
		Me._lblTotal_5.Visible = True
		Me._lblTotal_5.AutoSize = False
		Me._lblTotal_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_5.Name = "_lblTotal_5"
		Me._lblTotal_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_4.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_4.Text = "Exclusive Total :"
		Me._lblTotal_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_4.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_4.Location = New System.Drawing.Point(234, 84)
		Me._lblTotal_4.TabIndex = 25
		Me._lblTotal_4.Enabled = True
		Me._lblTotal_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_4.UseMnemonic = True
		Me._lblTotal_4.Visible = True
		Me._lblTotal_4.AutoSize = False
		Me._lblTotal_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_4.Name = "_lblTotal_4"
		Me._lblTotal_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_3.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_3.Text = "Total Selling :"
		Me._lblTotal_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_3.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_3.Location = New System.Drawing.Point(234, 66)
		Me._lblTotal_3.TabIndex = 24
		Me._lblTotal_3.Enabled = True
		Me._lblTotal_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_3.UseMnemonic = True
		Me._lblTotal_3.Visible = True
		Me._lblTotal_3.AutoSize = False
		Me._lblTotal_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_3.Name = "_lblTotal_3"
		Me._lblTotal_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_2.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_2.Text = "Total GP% :"
		Me._lblTotal_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_2.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_2.Location = New System.Drawing.Point(234, 48)
		Me._lblTotal_2.TabIndex = 23
		Me._lblTotal_2.Enabled = True
		Me._lblTotal_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_2.UseMnemonic = True
		Me._lblTotal_2.Visible = True
		Me._lblTotal_2.AutoSize = False
		Me._lblTotal_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_2.Name = "_lblTotal_2"
		Me._lblTotal_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_1.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_1.Text = "Inclusive Content :"
		Me._lblTotal_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_1.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_1.Location = New System.Drawing.Point(234, 30)
		Me._lblTotal_1.TabIndex = 22
		Me._lblTotal_1.Enabled = True
		Me._lblTotal_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_1.UseMnemonic = True
		Me._lblTotal_1.Visible = True
		Me._lblTotal_1.AutoSize = False
		Me._lblTotal_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_1.Name = "_lblTotal_1"
		Me._lblTotal_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_0.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_0.Text = "Exclusive Content :"
		Me._lblTotal_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_0.Size = New System.Drawing.Size(115, 16)
		Me._lblTotal_0.Location = New System.Drawing.Point(234, 12)
		Me._lblTotal_0.TabIndex = 21
		Me._lblTotal_0.Enabled = True
		Me._lblTotal_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_0.UseMnemonic = True
		Me._lblTotal_0.Visible = True
		Me._lblTotal_0.AutoSize = False
		Me._lblTotal_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_0.Name = "_lblTotal_0"
		Me.lblTotalInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalInclusive.BackColor = System.Drawing.Color.FromARGB(128, 255, 128)
		Me.lblTotalInclusive.Text = "0.00"
		Me.lblTotalInclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblTotalInclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblTotalInclusive.Location = New System.Drawing.Point(351, 102)
		Me.lblTotalInclusive.TabIndex = 20
		Me.lblTotalInclusive.Enabled = True
		Me.lblTotalInclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalInclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalInclusive.UseMnemonic = True
		Me.lblTotalInclusive.Visible = True
		Me.lblTotalInclusive.AutoSize = False
		Me.lblTotalInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalInclusive.Name = "lblTotalInclusive"
		Me.lblTotalExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalExclusive.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalExclusive.Text = "0.00"
		Me.lblTotalExclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblTotalExclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblTotalExclusive.Location = New System.Drawing.Point(351, 84)
		Me.lblTotalExclusive.TabIndex = 19
		Me.lblTotalExclusive.Enabled = True
		Me.lblTotalExclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalExclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalExclusive.UseMnemonic = True
		Me.lblTotalExclusive.Visible = True
		Me.lblTotalExclusive.AutoSize = False
		Me.lblTotalExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalExclusive.Name = "lblTotalExclusive"
		Me.lblDepositInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositInclusive.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me.lblDepositInclusive.Text = "0.00"
		Me.lblDepositInclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositInclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblDepositInclusive.Location = New System.Drawing.Point(351, 66)
		Me.lblDepositInclusive.TabIndex = 18
		Me.lblDepositInclusive.Enabled = True
		Me.lblDepositInclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositInclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositInclusive.UseMnemonic = True
		Me.lblDepositInclusive.Visible = True
		Me.lblDepositInclusive.AutoSize = False
		Me.lblDepositInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositInclusive.Name = "lblDepositInclusive"
		Me.lblDepositExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositExclusive.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblDepositExclusive.Text = "0.00"
		Me.lblDepositExclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositExclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblDepositExclusive.Location = New System.Drawing.Point(351, 48)
		Me.lblDepositExclusive.TabIndex = 17
		Me.lblDepositExclusive.Enabled = True
		Me.lblDepositExclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositExclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositExclusive.UseMnemonic = True
		Me.lblDepositExclusive.Visible = True
		Me.lblDepositExclusive.AutoSize = False
		Me.lblDepositExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositExclusive.Name = "lblDepositExclusive"
		Me.lblContentInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentInclusive.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me.lblContentInclusive.Text = "0.00"
		Me.lblContentInclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblContentInclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblContentInclusive.Location = New System.Drawing.Point(351, 30)
		Me.lblContentInclusive.TabIndex = 16
		Me.lblContentInclusive.Enabled = True
		Me.lblContentInclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentInclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentInclusive.UseMnemonic = True
		Me.lblContentInclusive.Visible = True
		Me.lblContentInclusive.AutoSize = False
		Me.lblContentInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentInclusive.Name = "lblContentInclusive"
		Me.lblContentExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentExclusive.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblContentExclusive.Text = "0.00"
		Me.lblContentExclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblContentExclusive.Size = New System.Drawing.Size(100, 16)
		Me.lblContentExclusive.Location = New System.Drawing.Point(351, 12)
		Me.lblContentExclusive.TabIndex = 15
		Me.lblContentExclusive.Enabled = True
		Me.lblContentExclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentExclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentExclusive.UseMnemonic = True
		Me.lblContentExclusive.Visible = True
		Me.lblContentExclusive.AutoSize = False
		Me.lblContentExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentExclusive.Name = "lblContentExclusive"
		Me._lbl_2.Text = "Broken Packs"
		Me._lbl_2.Size = New System.Drawing.Size(67, 13)
		Me._lbl_2.Location = New System.Drawing.Point(78, 15)
		Me._lbl_2.TabIndex = 13
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me.lblBrokenPack.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblBrokenPack.Text = "lblQuantity"
		Me.lblBrokenPack.Size = New System.Drawing.Size(64, 17)
		Me.lblBrokenPack.Location = New System.Drawing.Point(81, 27)
		Me.lblBrokenPack.TabIndex = 12
		Me.lblBrokenPack.BackColor = System.Drawing.SystemColors.Control
		Me.lblBrokenPack.Enabled = True
		Me.lblBrokenPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblBrokenPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblBrokenPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblBrokenPack.UseMnemonic = True
		Me.lblBrokenPack.Visible = True
		Me.lblBrokenPack.AutoSize = False
		Me.lblBrokenPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblBrokenPack.Name = "lblBrokenPack"
		Me._lbl_8.Text = "No Of Cases"
		Me._lbl_8.Size = New System.Drawing.Size(60, 13)
		Me._lbl_8.Location = New System.Drawing.Point(9, 15)
		Me._lbl_8.TabIndex = 11
		Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_8.BackColor = System.Drawing.Color.Transparent
		Me._lbl_8.Enabled = True
		Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_8.UseMnemonic = True
		Me._lbl_8.Visible = True
		Me._lbl_8.AutoSize = True
		Me._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_8.Name = "_lbl_8"
		Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblQuantity.Text = "lblQuantity"
		Me.lblQuantity.Size = New System.Drawing.Size(64, 17)
		Me.lblQuantity.Location = New System.Drawing.Point(9, 27)
		Me.lblQuantity.TabIndex = 10
		Me.lblQuantity.BackColor = System.Drawing.SystemColors.Control
		Me.lblQuantity.Enabled = True
		Me.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblQuantity.UseMnemonic = True
		Me.lblQuantity.Visible = True
		Me.lblQuantity.AutoSize = False
		Me.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblQuantity.Name = "lblQuantity"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.Red
		Me.Picture1.Size = New System.Drawing.Size(836, 25)
		Me.Picture1.Location = New System.Drawing.Point(0, 49)
		Me.Picture1.TabIndex = 7
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
		Me.lblSupplier.TabIndex = 8
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
		Me._txtEdit_0.AutoSize = False
		Me._txtEdit_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_0.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_0.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_0.Location = New System.Drawing.Point(279, 138)
		Me._txtEdit_0.Maxlength = 8
		Me._txtEdit_0.TabIndex = 3
		Me._txtEdit_0.Tag = "0"
		Me._txtEdit_0.Text = "0"
		Me._txtEdit_0.Visible = False
		Me._txtEdit_0.AcceptsReturn = True
		Me._txtEdit_0.CausesValidation = True
		Me._txtEdit_0.Enabled = True
		Me._txtEdit_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_0.HideSelection = True
		Me._txtEdit_0.ReadOnly = False
		Me._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_0.MultiLine = False
		Me._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_0.TabStop = True
		Me._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_0.Name = "_txtEdit_0"
        'gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridItem.Size = New System.Drawing.Size(493, 319)
		Me.gridItem.Location = New System.Drawing.Point(195, 117)
		Me.gridItem.TabIndex = 4
		Me.gridItem.Name = "gridItem"
		Me.txtSearch0.AutoSize = False
		Me.txtSearch0.Size = New System.Drawing.Size(142, 19)
		Me.txtSearch0.Location = New System.Drawing.Point(45, 99)
		Me.txtSearch0.TabIndex = 47
		Me.txtSearch0.Visible = False
		Me.txtSearch0.AcceptsReturn = True
		Me.txtSearch0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch0.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch0.CausesValidation = True
		Me.txtSearch0.Enabled = True
		Me.txtSearch0.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch0.HideSelection = True
		Me.txtSearch0.ReadOnly = False
		Me.txtSearch0.Maxlength = 0
		Me.txtSearch0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch0.MultiLine = False
		Me.txtSearch0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch0.TabStop = True
		Me.txtSearch0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch0.Name = "txtSearch0"
		Me.lstWorkspace.Size = New System.Drawing.Size(187, 306)
		Me.lstWorkspace.Location = New System.Drawing.Point(0, 128)
		Me.lstWorkspace.TabIndex = 2
		Me.lstWorkspace.TabStop = False
		Me.lstWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstWorkspace.BackColor = System.Drawing.SystemColors.Window
		Me.lstWorkspace.CausesValidation = True
		Me.lstWorkspace.Enabled = True
		Me.lstWorkspace.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstWorkspace.IntegralHeight = True
		Me.lstWorkspace.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstWorkspace.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstWorkspace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstWorkspace.Sorted = False
		Me.lstWorkspace.Visible = True
		Me.lstWorkspace.MultiColumn = False
		Me.lstWorkspace.Name = "lstWorkspace"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "&Search"
		Me._lbl_1.Size = New System.Drawing.Size(34, 13)
		Me._lbl_1.Location = New System.Drawing.Point(8, 104)
		Me._lbl_1.TabIndex = 46
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "&Barcode"
		Me.Label1.Size = New System.Drawing.Size(40, 13)
		Me.Label1.Location = New System.Drawing.Point(0, 102)
		Me.Label1.TabIndex = 45
		Me.Label1.Visible = False
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lblReturns.BackColor = System.Drawing.Color.Red
		Me.lblReturns.Text = "RETURNS"
		Me.lblReturns.Font = New System.Drawing.Font("Arial", 24!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblReturns.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblReturns.Size = New System.Drawing.Size(166, 34)
		Me.lblReturns.Location = New System.Drawing.Point(195, 480)
		Me.lblReturns.TabIndex = 14
		Me.lblReturns.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblReturns.Enabled = True
		Me.lblReturns.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblReturns.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblReturns.UseMnemonic = True
		Me.lblReturns.Visible = True
		Me.lblReturns.AutoSize = False
		Me.lblReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReturns.Name = "lblReturns"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "Search"
		Me._lbl_7.Size = New System.Drawing.Size(34, 13)
		Me._lbl_7.Location = New System.Drawing.Point(48, 102)
		Me._lbl_7.TabIndex = 5
		Me._lbl_7.Visible = False
		Me._lbl_7.BackColor = System.Drawing.Color.Transparent
		Me._lbl_7.Enabled = True
		Me._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_7.UseMnemonic = True
		Me._lbl_7.AutoSize = True
		Me._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_7.Name = "_lbl_7"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lbl_0.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me._lbl_0.Text = "Stock Item Selector"
		Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_0.ForeColor = System.Drawing.Color.White
		Me._lbl_0.Size = New System.Drawing.Size(190, 16)
		Me._lbl_0.Location = New System.Drawing.Point(0, 81)
		Me._lbl_0.TabIndex = 6
		Me._lbl_0.Enabled = True
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = False
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lbl_0.Name = "_lbl_0"
		Me.Controls.Add(frmFNVeg)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(txtBCode)
		Me.Controls.Add(_txtEdit_2)
		Me.Controls.Add(_txtEdit_1)
		Me.Controls.Add(Picture2)
		Me.Controls.Add(frmTotals)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(_txtEdit_0)
		Me.Controls.Add(gridItem)
		Me.Controls.Add(txtSearch0)
		Me.Controls.Add(lstWorkspace)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblReturns)
		Me.Controls.Add(_lbl_7)
		Me.Controls.Add(_lbl_0)
		Me.frmFNVeg.Controls.Add(txtPackSize)
		Me.frmFNVeg.Controls.Add(cmdEditPackSize)
		Me.Picture2.Controls.Add(cmdPriceBOM)
		Me.Picture2.Controls.Add(cmdVat)
		Me.Picture2.Controls.Add(cmdExit)
		Me.Picture2.Controls.Add(cmdNext)
		Me.Picture2.Controls.Add(cmdBack)
		Me.Picture2.Controls.Add(cmdStockItem)
		Me.Picture2.Controls.Add(cmdDiscount)
		Me.Picture2.Controls.Add(cmdPrintOrder)
		Me.Picture2.Controls.Add(cmdPrintGRV)
		Me.Picture2.Controls.Add(cmdDelete)
		Me.Picture2.Controls.Add(cmdPack)
		Me.Picture2.Controls.Add(cmdPrice)
		Me.Picture2.Controls.Add(cmdEdit)
		Me.Picture2.Controls.Add(cmdNew)
		Me.Picture2.Controls.Add(cmdQuick)
		Me.Picture2.Controls.Add(cmdSort)
		Me.frmTotals.Controls.Add(_lblTotal_5)
		Me.frmTotals.Controls.Add(_lblTotal_4)
		Me.frmTotals.Controls.Add(_lblTotal_3)
		Me.frmTotals.Controls.Add(_lblTotal_2)
		Me.frmTotals.Controls.Add(_lblTotal_1)
		Me.frmTotals.Controls.Add(_lblTotal_0)
		Me.frmTotals.Controls.Add(lblTotalInclusive)
		Me.frmTotals.Controls.Add(lblTotalExclusive)
		Me.frmTotals.Controls.Add(lblDepositInclusive)
		Me.frmTotals.Controls.Add(lblDepositExclusive)
		Me.frmTotals.Controls.Add(lblContentInclusive)
		Me.frmTotals.Controls.Add(lblContentExclusive)
		Me.frmTotals.Controls.Add(_lbl_2)
		Me.frmTotals.Controls.Add(lblBrokenPack)
		Me.frmTotals.Controls.Add(_lbl_8)
		Me.frmTotals.Controls.Add(lblQuantity)
		Me.Picture1.Controls.Add(lblSupplier)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_8, CType(8, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_7, CType(7, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lblTotal.SetIndex(_lblTotal_5, CType(5, Short))
        'Me.lblTotal.SetIndex(_lblTotal_4, CType(4, Short))
        'Me.lblTotal.SetIndex(_lblTotal_3, CType(3, Short))
        'Me.lblTotal.SetIndex(_lblTotal_2, CType(2, Short))
        'Me.lblTotal.SetIndex(_lblTotal_1, CType(1, Short))
        'Me.lblTotal.SetIndex(_lblTotal_0, CType(0, Short))
        'Me.txtEdit.SetIndex(_txtEdit_2, CType(2, Short))
        'Me.txtEdit.SetIndex(_txtEdit_1, CType(1, Short))
        'Me.txtEdit.SetIndex(_txtEdit_0, CType(0, Short))
        'CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridItem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frmFNVeg.ResumeLayout(False)
		Me.Picture2.ResumeLayout(False)
		Me.frmTotals.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class