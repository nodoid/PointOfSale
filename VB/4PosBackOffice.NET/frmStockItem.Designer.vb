<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockItem
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
	Public WithEvents _chkSerialTracking_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_6 As System.Windows.Forms.CheckBox
	Public WithEvents Frame6 As System.Windows.Forms.GroupBox
	Public WithEvents chkbarcode As System.Windows.Forms.CheckBox
	Public WithEvents chkshelf As System.Windows.Forms.CheckBox
	Public WithEvents Frame5 As System.Windows.Forms.GroupBox
	Public WithEvents _chkFields_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkSerialTracking_0 As System.Windows.Forms.CheckBox
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents cmdReportGroup As System.Windows.Forms.Button
	Public WithEvents cmdStockGroup As System.Windows.Forms.Button
	Public WithEvents cmdPricingGroup As System.Windows.Forms.Button
    Public WithEvents cmbPricingGroup As myDataGridView
    Public WithEvents cmbStockGroup As myDataGridView
    Public WithEvents cmbReportGroup As myDataGridView
	Public WithEvents _lblLabels_15 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _Frame2_1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdShrink As System.Windows.Forms.Button
	Public WithEvents _txtFloat_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_0 As System.Windows.Forms.TextBox
    Public WithEvents cmbShrink As myDataGridView
	Public WithEvents _lblLabels_11 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_10 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _Frame2_2 As System.Windows.Forms.GroupBox
	Public WithEvents cmbReorder As System.Windows.Forms.ComboBox
	Public WithEvents _txtInteger_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_1 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_0 As System.Windows.Forms.CheckBox
	Public WithEvents _txtInteger_2 As System.Windows.Forms.TextBox
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _Frame2_3 As System.Windows.Forms.GroupBox
	Public WithEvents cmdpriceselist As System.Windows.Forms.Button
	Public WithEvents chkPriceSet As System.Windows.Forms.CheckBox
    Public WithEvents cmbPriceSet As myDataGridView
	Public WithEvents lblPriceSet As System.Windows.Forms.Label
	Public WithEvents _Frame2_4 As System.Windows.Forms.GroupBox
	Public WithEvents _txtInteger_4 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_5 As System.Windows.Forms.CheckBox
	Public WithEvents chkSQ As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_3 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_2 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_4 As System.Windows.Forms.CheckBox
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _Frame2_5 As System.Windows.Forms.GroupBox
	Public WithEvents cmdPackSize As System.Windows.Forms.Button
	Public WithEvents cmdPrintGroup As System.Windows.Forms.Button
	Public WithEvents cmdVAT As System.Windows.Forms.Button
	Public WithEvents cmdPrintLocation As System.Windows.Forms.Button
	Public WithEvents cmdSupplier As System.Windows.Forms.Button
	Public WithEvents cmdDeposit As System.Windows.Forms.Button
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_14 As System.Windows.Forms.TextBox
	Public WithEvents _chkFields_13 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_12 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFields_8 As System.Windows.Forms.TextBox
    Public WithEvents cmbVat As myDataGridView
    Public WithEvents cmbDeposit As myDataGridView
    Public WithEvents cmbSupplier As myDataGridView
    Public WithEvents cmbPrintLocation As myDataGridView
    Public WithEvents cmbPrintGroup As myDataGridView
    Public WithEvents cmbPackSize As myDataGridView
	Public WithEvents _lblLabels_16 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_13 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_12 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_14 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _Frame2_0 As System.Windows.Forms.GroupBox
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents txtholdname As System.Windows.Forms.TextBox
	Public WithEvents txttemphold As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdHistory As System.Windows.Forms.Button
	Public WithEvents cmdDuplicate As System.Windows.Forms.Button
	Public WithEvents cmdDetails As System.Windows.Forms.Button
	Public WithEvents cmdbarcodeItem As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents ILtree As System.Windows.Forms.ImageList
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdRecipeAdd As System.Windows.Forms.Button
	Public WithEvents _optRecipeType_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optRecipeType_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optRecipeType_2 As System.Windows.Forms.RadioButton
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents _optRecipeType_3 As System.Windows.Forms.RadioButton
	Public WithEvents FGRecipe As myDataGridView
	Public WithEvents lblRecipeCost As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents _cmdNew_2 As System.Windows.Forms.Button
	Public WithEvents cmdDeallocate As System.Windows.Forms.Button
	Public WithEvents cmdAllocate As System.Windows.Forms.Button
	Public WithEvents _cmdMove_1 As System.Windows.Forms.Button
	Public WithEvents _cmdMove_0 As System.Windows.Forms.Button
	Public WithEvents _cmdNew_1 As System.Windows.Forms.Button
	Public WithEvents _cmdNew_0 As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents TVMessage As System.Windows.Forms.TreeView
	Public WithEvents TreeView1 As System.Windows.Forms.TreeView
	Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
    'Public WithEvents TabStrip1 As Axmscomctl.AxTabStrip
	Public WithEvents _lstvSerial_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstvSerial_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstvSerial_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstvSerial_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstvSerial_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstvSerial_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lstvSerial As System.Windows.Forms.ListView
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
	Public WithEvents _Frame1_3 As System.Windows.Forms.GroupBox
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents Frame2 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents chkSerialTracking As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents cmdMove As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents cmdNew As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optRecipeType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.Frame6 = New System.Windows.Forms.GroupBox
		Me._chkSerialTracking_1 = New System.Windows.Forms.CheckBox
		Me._chkFields_6 = New System.Windows.Forms.CheckBox
		Me.Frame5 = New System.Windows.Forms.GroupBox
		Me.chkbarcode = New System.Windows.Forms.CheckBox
		Me.chkshelf = New System.Windows.Forms.CheckBox
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me._chkFields_1 = New System.Windows.Forms.CheckBox
		Me._chkSerialTracking_0 = New System.Windows.Forms.CheckBox
		Me._Frame2_1 = New System.Windows.Forms.GroupBox
		Me.cmdReportGroup = New System.Windows.Forms.Button
		Me.cmdStockGroup = New System.Windows.Forms.Button
		Me.cmdPricingGroup = New System.Windows.Forms.Button
        Me.cmbPricingGroup = New myDataGridView
        Me.cmbStockGroup = New myDataGridView
        Me.cmbReportGroup = New myDataGridView
		Me._lblLabels_15 = New System.Windows.Forms.Label
		Me._lblLabels_4 = New System.Windows.Forms.Label
		Me._lblLabels_3 = New System.Windows.Forms.Label
		Me._Frame2_2 = New System.Windows.Forms.GroupBox
		Me.cmdShrink = New System.Windows.Forms.Button
		Me._txtFloat_1 = New System.Windows.Forms.TextBox
		Me._txtFloat_0 = New System.Windows.Forms.TextBox
		Me._txtInteger_0 = New System.Windows.Forms.TextBox
        Me.cmbShrink = New myDataGridView
		Me._lblLabels_11 = New System.Windows.Forms.Label
		Me._lblLabels_10 = New System.Windows.Forms.Label
		Me._lblLabels_9 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._Frame2_3 = New System.Windows.Forms.GroupBox
		Me.cmbReorder = New System.Windows.Forms.ComboBox
		Me._txtInteger_3 = New System.Windows.Forms.TextBox
		Me._txtInteger_1 = New System.Windows.Forms.TextBox
		Me._chkFields_0 = New System.Windows.Forms.CheckBox
		Me._txtInteger_2 = New System.Windows.Forms.TextBox
		Me._lbl_7 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me._lbl_5 = New System.Windows.Forms.Label
		Me._lbl_4 = New System.Windows.Forms.Label
		Me._Frame2_4 = New System.Windows.Forms.GroupBox
		Me.cmdpriceselist = New System.Windows.Forms.Button
		Me.chkPriceSet = New System.Windows.Forms.CheckBox
        Me.cmbPriceSet = New myDataGridView
		Me.lblPriceSet = New System.Windows.Forms.Label
		Me._Frame2_5 = New System.Windows.Forms.GroupBox
		Me._txtInteger_4 = New System.Windows.Forms.TextBox
		Me._chkFields_5 = New System.Windows.Forms.CheckBox
		Me.chkSQ = New System.Windows.Forms.CheckBox
		Me._chkFields_3 = New System.Windows.Forms.CheckBox
		Me._chkFields_2 = New System.Windows.Forms.CheckBox
		Me._chkFields_4 = New System.Windows.Forms.CheckBox
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._Frame2_0 = New System.Windows.Forms.GroupBox
		Me.cmdPackSize = New System.Windows.Forms.Button
		Me.cmdPrintGroup = New System.Windows.Forms.Button
		Me.cmdVAT = New System.Windows.Forms.Button
		Me.cmdPrintLocation = New System.Windows.Forms.Button
		Me.cmdSupplier = New System.Windows.Forms.Button
		Me.cmdDeposit = New System.Windows.Forms.Button
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me._txtFields_14 = New System.Windows.Forms.TextBox
		Me._chkFields_13 = New System.Windows.Forms.CheckBox
		Me._chkFields_12 = New System.Windows.Forms.CheckBox
		Me._txtFields_8 = New System.Windows.Forms.TextBox
        Me.cmbVat = New myDataGridView
        Me.cmbDeposit = New myDataGridView
        Me.cmbSupplier = New myDataGridView
        Me.cmbPrintLocation = New myDataGridView
        Me.cmbPrintGroup = New myDataGridView
        Me.cmbPackSize = New myDataGridView
		Me._lblLabels_16 = New System.Windows.Forms.Label
		Me._lblLabels_13 = New System.Windows.Forms.Label
		Me._lblLabels_12 = New System.Windows.Forms.Label
		Me._lblLabels_14 = New System.Windows.Forms.Label
		Me._lblLabels_8 = New System.Windows.Forms.Label
		Me._lblLabels_6 = New System.Windows.Forms.Label
		Me._lblLabels_5 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me.txtholdname = New System.Windows.Forms.TextBox
		Me.txttemphold = New System.Windows.Forms.TextBox
		Me._txtFields_7 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdHistory = New System.Windows.Forms.Button
		Me.cmdDuplicate = New System.Windows.Forms.Button
		Me.cmdDetails = New System.Windows.Forms.Button
		Me.cmdbarcodeItem = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.ILtree = New System.Windows.Forms.ImageList
		Me._Frame1_1 = New System.Windows.Forms.GroupBox
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdRecipeAdd = New System.Windows.Forms.Button
		Me._optRecipeType_0 = New System.Windows.Forms.RadioButton
		Me._optRecipeType_1 = New System.Windows.Forms.RadioButton
		Me._optRecipeType_2 = New System.Windows.Forms.RadioButton
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me._optRecipeType_3 = New System.Windows.Forms.RadioButton
		Me.FGRecipe = New myDataGridView
		Me.lblRecipeCost = New System.Windows.Forms.Label
		Me._Frame1_2 = New System.Windows.Forms.GroupBox
		Me._cmdNew_2 = New System.Windows.Forms.Button
		Me.cmdDeallocate = New System.Windows.Forms.Button
		Me.cmdAllocate = New System.Windows.Forms.Button
		Me._cmdMove_1 = New System.Windows.Forms.Button
		Me._cmdMove_0 = New System.Windows.Forms.Button
		Me._cmdNew_1 = New System.Windows.Forms.Button
		Me._cmdNew_0 = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.TVMessage = New System.Windows.Forms.TreeView
		Me.TreeView1 = New System.Windows.Forms.TreeView
        'Me.TabStrip1 = New Axmscomctl.AxTabStrip
		Me._Frame1_3 = New System.Windows.Forms.GroupBox
		Me.Frame4 = New System.Windows.Forms.GroupBox
		Me.lstvSerial = New System.Windows.Forms.ListView
		Me._lstvSerial_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lstvSerial_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lstvSerial_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstvSerial_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lstvSerial_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lstvSerial_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lblLabels_7 = New System.Windows.Forms.Label
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.Frame2 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
        'Me.chkSerialTracking = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
        'Me.cmdMove = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.cmdNew = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optRecipeType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
        'Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'Me.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me._Frame1_0.SuspendLayout()
		Me.Frame6.SuspendLayout()
		Me.Frame5.SuspendLayout()
		Me.Frame3.SuspendLayout()
		Me._Frame2_1.SuspendLayout()
		Me._Frame2_2.SuspendLayout()
		Me._Frame2_3.SuspendLayout()
		Me._Frame2_4.SuspendLayout()
		Me._Frame2_5.SuspendLayout()
		Me._Frame2_0.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me._Frame1_1.SuspendLayout()
		Me._Frame1_2.SuspendLayout()
		Me._Frame1_3.SuspendLayout()
		Me.Frame4.SuspendLayout()
		Me.lstvSerial.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbReportGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPriceSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbVat, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPrintLocation, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPrintGroup, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbPackSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FGRecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.TabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Frame2, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.chkSerialTracking, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cmdNew, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optRecipeType, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Stock Item Details"
		Me.ClientSize = New System.Drawing.Size(592, 541)
		Me.Location = New System.Drawing.Point(73, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockItem"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(556, 435)
		Me._Frame1_0.Location = New System.Drawing.Point(14, 96)
		Me._Frame1_0.TabIndex = 51
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.Frame6.Text = "&8. Air Time"
		Me.Frame6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Frame6.Size = New System.Drawing.Size(115, 43)
		Me.Frame6.Location = New System.Drawing.Point(432, 338)
		Me.Frame6.TabIndex = 113
		Me.Frame6.BackColor = System.Drawing.SystemColors.Control
		Me.Frame6.Enabled = True
		Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame6.Visible = True
		Me.Frame6.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame6.Name = "Frame6"
		Me._chkSerialTracking_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkSerialTracking_1.Text = "Yes"
		Me._chkSerialTracking_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkSerialTracking_1.Size = New System.Drawing.Size(61, 17)
		Me._chkSerialTracking_1.Location = New System.Drawing.Point(236, 10)
		Me._chkSerialTracking_1.TabIndex = 115
		Me._chkSerialTracking_1.Visible = False
		Me._chkSerialTracking_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkSerialTracking_1.BackColor = System.Drawing.SystemColors.Control
		Me._chkSerialTracking_1.CausesValidation = True
		Me._chkSerialTracking_1.Enabled = True
		Me._chkSerialTracking_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkSerialTracking_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkSerialTracking_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkSerialTracking_1.TabStop = True
		Me._chkSerialTracking_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkSerialTracking_1.Name = "_chkSerialTracking_1"
		Me._chkFields_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_6.Text = "Yes"
		Me._chkFields_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_6.Size = New System.Drawing.Size(79, 21)
		Me._chkFields_6.Location = New System.Drawing.Point(10, 16)
		Me._chkFields_6.TabIndex = 114
		Me._chkFields_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_6.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_6.CausesValidation = True
		Me._chkFields_6.Enabled = True
		Me._chkFields_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_6.TabStop = True
		Me._chkFields_6.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_6.Visible = True
		Me._chkFields_6.Name = "_chkFields_6"
		Me.Frame5.Text = "&9. Shelf && Barcode Printing"
		Me.Frame5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Frame5.Size = New System.Drawing.Size(235, 43)
		Me.Frame5.Location = New System.Drawing.Point(312, 384)
		Me.Frame5.TabIndex = 98
		Me.Frame5.BackColor = System.Drawing.SystemColors.Control
		Me.Frame5.Enabled = True
		Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame5.Visible = True
		Me.Frame5.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame5.Name = "Frame5"
		Me.chkbarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkbarcode.Text = "Barcode"
		Me.chkbarcode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkbarcode.Size = New System.Drawing.Size(83, 21)
		Me.chkbarcode.Location = New System.Drawing.Point(100, 16)
		Me.chkbarcode.TabIndex = 104
		Me.chkbarcode.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkbarcode.BackColor = System.Drawing.SystemColors.Control
		Me.chkbarcode.CausesValidation = True
		Me.chkbarcode.Enabled = True
		Me.chkbarcode.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkbarcode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkbarcode.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkbarcode.TabStop = True
		Me.chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkbarcode.Visible = True
		Me.chkbarcode.Name = "chkbarcode"
		Me.chkshelf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkshelf.Text = "Shelf"
		Me.chkshelf.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkshelf.Size = New System.Drawing.Size(61, 21)
		Me.chkshelf.Location = New System.Drawing.Point(10, 16)
		Me.chkshelf.TabIndex = 103
		Me.chkshelf.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkshelf.BackColor = System.Drawing.SystemColors.Control
		Me.chkshelf.CausesValidation = True
		Me.chkshelf.Enabled = True
		Me.chkshelf.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkshelf.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkshelf.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkshelf.TabStop = True
		Me.chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkshelf.Visible = True
		Me.chkshelf.Name = "chkshelf"
		Me.Frame3.Text = "&7. Serial Tracking"
		Me.Frame3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Frame3.Size = New System.Drawing.Size(115, 43)
		Me.Frame3.Location = New System.Drawing.Point(312, 338)
		Me.Frame3.TabIndex = 92
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_1.Text = "Yes"
		Me._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_1.Size = New System.Drawing.Size(79, 21)
		Me._chkFields_1.Location = New System.Drawing.Point(10, 16)
		Me._chkFields_1.TabIndex = 97
		Me._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_1.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_1.CausesValidation = True
		Me._chkFields_1.Enabled = True
		Me._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_1.TabStop = True
		Me._chkFields_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_1.Visible = True
		Me._chkFields_1.Name = "_chkFields_1"
		Me._chkSerialTracking_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkSerialTracking_0.Text = "Yes"
		Me._chkSerialTracking_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkSerialTracking_0.Size = New System.Drawing.Size(61, 17)
		Me._chkSerialTracking_0.Location = New System.Drawing.Point(236, 10)
		Me._chkSerialTracking_0.TabIndex = 93
		Me._chkSerialTracking_0.Visible = False
		Me._chkSerialTracking_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkSerialTracking_0.BackColor = System.Drawing.SystemColors.Control
		Me._chkSerialTracking_0.CausesValidation = True
		Me._chkSerialTracking_0.Enabled = True
		Me._chkSerialTracking_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkSerialTracking_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkSerialTracking_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkSerialTracking_0.TabStop = True
		Me._chkSerialTracking_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkSerialTracking_0.Name = "_chkSerialTracking_0"
		Me._Frame2_1.Text = "&2. Groupings"
		Me._Frame2_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_1.Size = New System.Drawing.Size(298, 92)
		Me._Frame2_1.Location = New System.Drawing.Point(8, 248)
		Me._Frame2_1.TabIndex = 13
		Me._Frame2_1.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_1.Enabled = True
		Me._Frame2_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_1.Visible = True
		Me._Frame2_1.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_1.Name = "_Frame2_1"
		Me.cmdReportGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReportGroup.Text = "..."
		Me.cmdReportGroup.Size = New System.Drawing.Size(25, 19)
		Me.cmdReportGroup.Location = New System.Drawing.Point(266, 66)
		Me.cmdReportGroup.TabIndex = 100
		Me.cmdReportGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReportGroup.CausesValidation = True
		Me.cmdReportGroup.Enabled = True
		Me.cmdReportGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReportGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReportGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReportGroup.TabStop = True
		Me.cmdReportGroup.Name = "cmdReportGroup"
		Me.cmdStockGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStockGroup.Text = "..."
		Me.cmdStockGroup.Size = New System.Drawing.Size(25, 19)
		Me.cmdStockGroup.Location = New System.Drawing.Point(267, 40)
		Me.cmdStockGroup.TabIndex = 75
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
		Me.cmdPricingGroup.Location = New System.Drawing.Point(267, 16)
		Me.cmdPricingGroup.TabIndex = 74
		Me.cmdPricingGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPricingGroup.CausesValidation = True
		Me.cmdPricingGroup.Enabled = True
		Me.cmdPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPricingGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPricingGroup.TabStop = True
		Me.cmdPricingGroup.Name = "cmdPricingGroup"
        'cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPricingGroup.Size = New System.Drawing.Size(184, 21)
		Me.cmbPricingGroup.Location = New System.Drawing.Point(81, 15)
		Me.cmbPricingGroup.TabIndex = 14
		Me.cmbPricingGroup.Name = "cmbPricingGroup"
        'cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbStockGroup.Size = New System.Drawing.Size(184, 21)
		Me.cmbStockGroup.Location = New System.Drawing.Point(81, 40)
		Me.cmbStockGroup.TabIndex = 15
		Me.cmbStockGroup.Name = "cmbStockGroup"
        'cmbReportGroup.OcxState = CType(resources.GetObject("cmbReportGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbReportGroup.Size = New System.Drawing.Size(184, 21)
		Me.cmbReportGroup.Location = New System.Drawing.Point(80, 64)
		Me.cmbReportGroup.TabIndex = 99
		Me.cmbReportGroup.Name = "cmbReportGroup"
		Me._lblLabels_15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_15.Text = "Report Group:"
		Me._lblLabels_15.Size = New System.Drawing.Size(67, 13)
		Me._lblLabels_15.Location = New System.Drawing.Point(8, 70)
		Me._lblLabels_15.TabIndex = 101
		Me._lblLabels_15.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_15.Enabled = True
		Me._lblLabels_15.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_15.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_15.UseMnemonic = True
		Me._lblLabels_15.Visible = True
		Me._lblLabels_15.AutoSize = True
		Me._lblLabels_15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_15.Name = "_lblLabels_15"
		Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_4.Text = "Stock Group:"
		Me._lblLabels_4.Size = New System.Drawing.Size(63, 13)
		Me._lblLabels_4.Location = New System.Drawing.Point(13, 45)
		Me._lblLabels_4.TabIndex = 63
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
		Me._lblLabels_3.Location = New System.Drawing.Point(9, 21)
		Me._lblLabels_3.TabIndex = 62
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
		Me._Frame2_2.Text = "&3. Pricing and Shrinks"
		Me._Frame2_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_2.Size = New System.Drawing.Size(298, 82)
		Me._Frame2_2.Location = New System.Drawing.Point(8, 344)
		Me._Frame2_2.TabIndex = 57
		Me._Frame2_2.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_2.Enabled = True
		Me._Frame2_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_2.Visible = True
		Me._Frame2_2.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_2.Name = "_Frame2_2"
		Me.cmdShrink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdShrink.Text = "..."
		Me.cmdShrink.Size = New System.Drawing.Size(25, 19)
		Me.cmdShrink.Location = New System.Drawing.Point(267, 15)
		Me.cmdShrink.TabIndex = 76
		Me.cmdShrink.BackColor = System.Drawing.SystemColors.Control
		Me.cmdShrink.CausesValidation = True
		Me.cmdShrink.Enabled = True
		Me.cmdShrink.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdShrink.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdShrink.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdShrink.TabStop = True
		Me.cmdShrink.Name = "cmdShrink"
		Me._txtFloat_1.AutoSize = False
		Me._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFloat_1.Size = New System.Drawing.Size(64, 19)
		Me._txtFloat_1.Location = New System.Drawing.Point(165, 51)
		Me._txtFloat_1.TabIndex = 19
		Me._txtFloat_1.Text = "0"
		Me._txtFloat_1.AcceptsReturn = True
		Me._txtFloat_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFloat_1.CausesValidation = True
		Me._txtFloat_1.Enabled = True
		Me._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFloat_1.HideSelection = True
		Me._txtFloat_1.ReadOnly = False
		Me._txtFloat_1.Maxlength = 0
		Me._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFloat_1.MultiLine = False
		Me._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFloat_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFloat_1.TabStop = True
		Me._txtFloat_1.Visible = True
		Me._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFloat_1.Name = "_txtFloat_1"
		Me._txtFloat_0.AutoSize = False
		Me._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFloat_0.Size = New System.Drawing.Size(64, 19)
		Me._txtFloat_0.Location = New System.Drawing.Point(99, 51)
		Me._txtFloat_0.TabIndex = 18
		Me._txtFloat_0.Text = "9,999.99"
		Me._txtFloat_0.AcceptsReturn = True
		Me._txtFloat_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFloat_0.CausesValidation = True
		Me._txtFloat_0.Enabled = True
		Me._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFloat_0.HideSelection = True
		Me._txtFloat_0.ReadOnly = False
		Me._txtFloat_0.Maxlength = 0
		Me._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFloat_0.MultiLine = False
		Me._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFloat_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFloat_0.TabStop = True
		Me._txtFloat_0.Visible = True
		Me._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFloat_0.Name = "_txtFloat_0"
		Me._txtInteger_0.AutoSize = False
		Me._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_0.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_0.Location = New System.Drawing.Point(54, 51)
		Me._txtInteger_0.TabIndex = 17
		Me._txtInteger_0.Text = "999"
		Me._txtInteger_0.AcceptsReturn = True
		Me._txtInteger_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_0.CausesValidation = True
		Me._txtInteger_0.Enabled = True
		Me._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_0.HideSelection = True
		Me._txtInteger_0.ReadOnly = False
		Me._txtInteger_0.Maxlength = 0
		Me._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_0.MultiLine = False
		Me._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_0.TabStop = True
		Me._txtInteger_0.Visible = True
		Me._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_0.Name = "_txtInteger_0"
        'cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbShrink.Size = New System.Drawing.Size(181, 21)
		Me.cmbShrink.Location = New System.Drawing.Point(84, 14)
		Me.cmbShrink.TabIndex = 16
		Me.cmbShrink.Name = "cmbShrink"
		Me._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_11.Text = "Actual Cost:"
		Me._lblLabels_11.Size = New System.Drawing.Size(57, 13)
		Me._lblLabels_11.Location = New System.Drawing.Point(169, 39)
		Me._lblLabels_11.TabIndex = 61
		Me._lblLabels_11.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_11.Enabled = True
		Me._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_11.UseMnemonic = True
		Me._lblLabels_11.Visible = True
		Me._lblLabels_11.AutoSize = True
		Me._lblLabels_11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_11.Name = "_lblLabels_11"
		Me._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_10.Text = "List Cost:"
		Me._lblLabels_10.Size = New System.Drawing.Size(40, 13)
		Me._lblLabels_10.Location = New System.Drawing.Point(120, 39)
		Me._lblLabels_10.TabIndex = 60
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
		Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_9.Text = "Suppliers Quantity:"
		Me._lblLabels_9.Size = New System.Drawing.Size(88, 13)
		Me._lblLabels_9.Location = New System.Drawing.Point(9, 39)
		Me._lblLabels_9.TabIndex = 59
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
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.Text = "Sale Shrinks:"
		Me._lblLabels_1.Size = New System.Drawing.Size(62, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(17, 18)
		Me._lblLabels_1.TabIndex = 58
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
		Me._Frame2_3.Text = "&4. Ordering Rules"
		Me._Frame2_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_3.Size = New System.Drawing.Size(235, 91)
		Me._Frame2_3.Location = New System.Drawing.Point(312, 12)
		Me._Frame2_3.TabIndex = 20
		Me._Frame2_3.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_3.Enabled = True
		Me._Frame2_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_3.Visible = True
		Me._Frame2_3.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_3.Name = "_Frame2_3"
		Me.cmbReorder.Size = New System.Drawing.Size(97, 21)
		Me.cmbReorder.Location = New System.Drawing.Point(63, 66)
		Me.cmbReorder.Items.AddRange(New Object(){"Single Unit", "Case/Carton"})
		Me.cmbReorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbReorder.TabIndex = 23
		Me.cmbReorder.BackColor = System.Drawing.SystemColors.Window
		Me.cmbReorder.CausesValidation = True
		Me.cmbReorder.Enabled = True
		Me.cmbReorder.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbReorder.IntegralHeight = True
		Me.cmbReorder.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbReorder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbReorder.Sorted = False
		Me.cmbReorder.TabStop = True
		Me.cmbReorder.Visible = True
		Me.cmbReorder.Name = "cmbReorder"
		Me._txtInteger_3.AutoSize = False
		Me._txtInteger_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_3.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_3.Location = New System.Drawing.Point(184, 66)
		Me._txtInteger_3.TabIndex = 24
		Me._txtInteger_3.Text = "999"
		Me._txtInteger_3.AcceptsReturn = True
		Me._txtInteger_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_3.CausesValidation = True
		Me._txtInteger_3.Enabled = True
		Me._txtInteger_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_3.HideSelection = True
		Me._txtInteger_3.ReadOnly = False
		Me._txtInteger_3.Maxlength = 0
		Me._txtInteger_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_3.MultiLine = False
		Me._txtInteger_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_3.TabStop = True
		Me._txtInteger_3.Visible = True
		Me._txtInteger_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_3.Name = "_txtInteger_3"
		Me._txtInteger_1.AutoSize = False
		Me._txtInteger_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_1.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_1.Location = New System.Drawing.Point(150, 45)
		Me._txtInteger_1.TabIndex = 22
		Me._txtInteger_1.Text = "999"
		Me._txtInteger_1.AcceptsReturn = True
		Me._txtInteger_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_1.CausesValidation = True
		Me._txtInteger_1.Enabled = True
		Me._txtInteger_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_1.HideSelection = True
		Me._txtInteger_1.ReadOnly = False
		Me._txtInteger_1.Maxlength = 0
		Me._txtInteger_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_1.MultiLine = False
		Me._txtInteger_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_1.TabStop = True
		Me._txtInteger_1.Visible = True
		Me._txtInteger_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_1.Name = "_txtInteger_1"
		Me._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_0.Text = "Check this box to exclude this Stock Item when using the Ordering wizard"
		Me._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_0.Size = New System.Drawing.Size(217, 25)
		Me._chkFields_0.Location = New System.Drawing.Point(9, 15)
		Me._chkFields_0.TabIndex = 21
		Me._chkFields_0.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_0.CausesValidation = True
		Me._chkFields_0.Enabled = True
		Me._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_0.TabStop = True
		Me._chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_0.Visible = True
		Me._chkFields_0.Name = "_chkFields_0"
		Me._txtInteger_2.AutoSize = False
		Me._txtInteger_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_2.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_2.Location = New System.Drawing.Point(160, 0)
		Me._txtInteger_2.TabIndex = 52
		Me._txtInteger_2.Text = "999"
		Me._txtInteger_2.Visible = False
		Me._txtInteger_2.AcceptsReturn = True
		Me._txtInteger_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_2.CausesValidation = True
		Me._txtInteger_2.Enabled = True
		Me._txtInteger_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_2.HideSelection = True
		Me._txtInteger_2.ReadOnly = False
		Me._txtInteger_2.Maxlength = 0
		Me._txtInteger_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_2.MultiLine = False
		Me._txtInteger_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_2.TabStop = True
		Me._txtInteger_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_2.Name = "_txtInteger_2"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "of"
		Me._lbl_7.Size = New System.Drawing.Size(9, 13)
		Me._lbl_7.Location = New System.Drawing.Point(164, 69)
		Me._lbl_7.TabIndex = 56
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
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "Re-order a "
		Me._lbl_0.Size = New System.Drawing.Size(53, 13)
		Me._lbl_0.Location = New System.Drawing.Point(11, 69)
		Me._lbl_0.TabIndex = 55
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
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_5.Text = "units,"
		Me._lbl_5.Size = New System.Drawing.Size(25, 13)
		Me._lbl_5.Location = New System.Drawing.Point(196, 48)
		Me._lbl_5.TabIndex = 54
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
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_4.Text = "When the stock goes below "
		Me._lbl_4.Size = New System.Drawing.Size(136, 13)
		Me._lbl_4.Location = New System.Drawing.Point(12, 48)
		Me._lbl_4.TabIndex = 53
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
		Me._Frame2_4.Text = "&5. Pricing Set"
		Me._Frame2_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_4.Size = New System.Drawing.Size(235, 76)
		Me._Frame2_4.Location = New System.Drawing.Point(312, 104)
		Me._Frame2_4.TabIndex = 25
		Me._Frame2_4.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_4.Enabled = True
		Me._Frame2_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_4.Visible = True
		Me._Frame2_4.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_4.Name = "_Frame2_4"
		Me.cmdpriceselist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdpriceselist.Text = "..."
		Me.cmdpriceselist.Size = New System.Drawing.Size(29, 21)
		Me.cmdpriceselist.Location = New System.Drawing.Point(200, 32)
		Me.cmdpriceselist.TabIndex = 102
		Me.cmdpriceselist.BackColor = System.Drawing.SystemColors.Control
		Me.cmdpriceselist.CausesValidation = True
		Me.cmdpriceselist.Enabled = True
		Me.cmdpriceselist.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdpriceselist.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdpriceselist.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdpriceselist.TabStop = True
		Me.cmdpriceselist.Name = "cmdpriceselist"
		Me.chkPriceSet.Text = "&5. This item is part of a Pricing Set"
		Me.chkPriceSet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.chkPriceSet.Size = New System.Drawing.Size(220, 13)
		Me.chkPriceSet.Location = New System.Drawing.Point(9, 15)
		Me.chkPriceSet.TabIndex = 26
		Me.chkPriceSet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPriceSet.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPriceSet.BackColor = System.Drawing.SystemColors.Control
		Me.chkPriceSet.CausesValidation = True
		Me.chkPriceSet.Enabled = True
		Me.chkPriceSet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkPriceSet.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPriceSet.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPriceSet.TabStop = True
		Me.chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPriceSet.Visible = True
		Me.chkPriceSet.Name = "chkPriceSet"
        'cmbPriceSet.OcxState = CType(resources.GetObject("cmbPriceSet.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPriceSet.Size = New System.Drawing.Size(179, 21)
		Me.cmbPriceSet.Location = New System.Drawing.Point(18, 32)
		Me.cmbPriceSet.TabIndex = 27
		Me.cmbPriceSet.Name = "cmbPriceSet"
		Me.lblPriceSet.Text = "No Action"
		Me.lblPriceSet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPriceSet.Size = New System.Drawing.Size(211, 17)
		Me.lblPriceSet.Location = New System.Drawing.Point(18, 51)
		Me.lblPriceSet.TabIndex = 28
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
		Me._Frame2_5.Text = "&6.Parameters"
		Me._Frame2_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_5.Size = New System.Drawing.Size(235, 152)
		Me._Frame2_5.Location = New System.Drawing.Point(312, 182)
		Me._Frame2_5.TabIndex = 29
		Me._Frame2_5.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_5.Enabled = True
		Me._Frame2_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_5.Visible = True
		Me._Frame2_5.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_5.Name = "_Frame2_5"
		Me._txtInteger_4.AutoSize = False
		Me._txtInteger_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_4.Size = New System.Drawing.Size(27, 19)
		Me._txtInteger_4.Location = New System.Drawing.Point(10, 36)
		Me._txtInteger_4.TabIndex = 116
		Me._txtInteger_4.Text = "0"
		Me._txtInteger_4.AcceptsReturn = True
		Me._txtInteger_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_4.CausesValidation = True
		Me._txtInteger_4.Enabled = True
		Me._txtInteger_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_4.HideSelection = True
		Me._txtInteger_4.ReadOnly = False
		Me._txtInteger_4.Maxlength = 0
		Me._txtInteger_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_4.MultiLine = False
		Me._txtInteger_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_4.TabStop = True
		Me._txtInteger_4.Visible = True
		Me._txtInteger_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_4.Name = "_txtInteger_4"
		Me._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_5.Text = "Do not Allow Negative Stock"
		Me._chkFields_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_5.Size = New System.Drawing.Size(177, 19)
		Me._chkFields_5.Location = New System.Drawing.Point(10, 102)
		Me._chkFields_5.TabIndex = 107
		Me._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_5.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_5.CausesValidation = True
		Me._chkFields_5.Enabled = True
		Me._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_5.TabStop = True
		Me._chkFields_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_5.Visible = True
		Me._chkFields_5.Name = "_chkFields_5"
		Me.chkSQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkSQ.Text = "POS Price Overide (SQ)"
		Me.chkSQ.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkSQ.Size = New System.Drawing.Size(151, 13)
		Me.chkSQ.Location = New System.Drawing.Point(10, 128)
		Me.chkSQ.TabIndex = 33
		Me.chkSQ.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSQ.BackColor = System.Drawing.SystemColors.Control
		Me.chkSQ.CausesValidation = True
		Me.chkSQ.Enabled = True
		Me.chkSQ.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSQ.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSQ.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSQ.TabStop = True
		Me.chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSQ.Visible = True
		Me.chkSQ.Name = "chkSQ"
		Me._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_3.Text = "Allow Fractions"
		Me._chkFields_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_3.Size = New System.Drawing.Size(95, 19)
		Me._chkFields_3.Location = New System.Drawing.Point(10, 80)
		Me._chkFields_3.TabIndex = 32
		Me._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_3.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_3.CausesValidation = True
		Me._chkFields_3.Enabled = True
		Me._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_3.TabStop = True
		Me._chkFields_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_3.Visible = True
		Me._chkFields_3.Name = "_chkFields_3"
		Me._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_2.Text = "This is a scale product"
		Me._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_2.Size = New System.Drawing.Size(170, 19)
		Me._chkFields_2.Location = New System.Drawing.Point(10, 15)
		Me._chkFields_2.TabIndex = 30
		Me._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_2.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_2.CausesValidation = True
		Me._chkFields_2.Enabled = True
		Me._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_2.TabStop = True
		Me._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_2.Visible = True
		Me._chkFields_2.Name = "_chkFields_2"
		Me._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_4.Text = "This is a scale item Non Weighed"
		Me._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_4.Size = New System.Drawing.Size(179, 19)
		Me._chkFields_4.Location = New System.Drawing.Point(10, 59)
		Me._chkFields_4.TabIndex = 31
		Me._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkFields_4.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_4.CausesValidation = True
		Me._chkFields_4.Enabled = True
		Me._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_4.TabStop = True
		Me._chkFields_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_4.Visible = True
		Me._chkFields_4.Name = "_chkFields_4"
		Me._lbl_1.Text = "Sell by days (for labelling only)"
		Me._lbl_1.Size = New System.Drawing.Size(140, 13)
		Me._lbl_1.Location = New System.Drawing.Point(42, 39)
		Me._lbl_1.TabIndex = 117
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._Frame2_0.Text = "&1. General"
		Me._Frame2_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame2_0.Size = New System.Drawing.Size(298, 232)
		Me._Frame2_0.Location = New System.Drawing.Point(9, 12)
		Me._Frame2_0.TabIndex = 3
		Me._Frame2_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame2_0.Enabled = True
		Me._Frame2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame2_0.Visible = True
		Me._Frame2_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame2_0.Name = "_Frame2_0"
		Me.cmdPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPackSize.Text = "..."
		Me.cmdPackSize.Size = New System.Drawing.Size(25, 19)
		Me.cmdPackSize.Location = New System.Drawing.Point(266, 206)
		Me.cmdPackSize.TabIndex = 109
		Me.cmdPackSize.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPackSize.CausesValidation = True
		Me.cmdPackSize.Enabled = True
		Me.cmdPackSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPackSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPackSize.TabStop = True
		Me.cmdPackSize.Name = "cmdPackSize"
		Me.cmdPrintGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintGroup.Text = "..."
		Me.cmdPrintGroup.Size = New System.Drawing.Size(25, 19)
		Me.cmdPrintGroup.Location = New System.Drawing.Point(266, 180)
		Me.cmdPrintGroup.TabIndex = 88
		Me.cmdPrintGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintGroup.CausesValidation = True
		Me.cmdPrintGroup.Enabled = True
		Me.cmdPrintGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintGroup.TabStop = True
		Me.cmdPrintGroup.Name = "cmdPrintGroup"
		Me.cmdVAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVAT.Text = "..."
		Me.cmdVAT.Size = New System.Drawing.Size(25, 19)
		Me.cmdVAT.Location = New System.Drawing.Point(267, 82)
		Me.cmdVAT.TabIndex = 77
		Me.cmdVAT.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVAT.CausesValidation = True
		Me.cmdVAT.Enabled = True
		Me.cmdVAT.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVAT.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVAT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVAT.TabStop = True
		Me.cmdVAT.Name = "cmdVAT"
		Me.cmdPrintLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintLocation.Text = "..."
		Me.cmdPrintLocation.Size = New System.Drawing.Size(25, 19)
		Me.cmdPrintLocation.Location = New System.Drawing.Point(267, 156)
		Me.cmdPrintLocation.TabIndex = 73
		Me.cmdPrintLocation.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintLocation.CausesValidation = True
		Me.cmdPrintLocation.Enabled = True
		Me.cmdPrintLocation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintLocation.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintLocation.TabStop = True
		Me.cmdPrintLocation.Name = "cmdPrintLocation"
		Me.cmdSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupplier.Text = "..."
		Me.cmdSupplier.Size = New System.Drawing.Size(25, 19)
		Me.cmdSupplier.Location = New System.Drawing.Point(267, 105)
		Me.cmdSupplier.TabIndex = 72
		Me.cmdSupplier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupplier.CausesValidation = True
		Me.cmdSupplier.Enabled = True
		Me.cmdSupplier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupplier.TabStop = True
		Me.cmdSupplier.Name = "cmdSupplier"
		Me.cmdDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeposit.Text = "..."
		Me.cmdDeposit.Size = New System.Drawing.Size(25, 19)
		Me.cmdDeposit.Location = New System.Drawing.Point(267, 58)
		Me.cmdDeposit.TabIndex = 71
		Me.cmdDeposit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDeposit.CausesValidation = True
		Me.cmdDeposit.Enabled = True
		Me.cmdDeposit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDeposit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDeposit.TabStop = True
		Me.cmdDeposit.Name = "cmdDeposit"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Size = New System.Drawing.Size(48, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(89, 132)
		Me._txtFields_0.TabIndex = 9
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Maxlength = 0
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.Visible = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_0.Name = "_txtFields_0"
		Me._txtFields_14.AutoSize = False
		Me._txtFields_14.Size = New System.Drawing.Size(202, 19)
		Me._txtFields_14.Location = New System.Drawing.Point(89, 36)
		Me._txtFields_14.TabIndex = 5
		Me._txtFields_14.AcceptsReturn = True
		Me._txtFields_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_14.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_14.CausesValidation = True
		Me._txtFields_14.Enabled = True
		Me._txtFields_14.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_14.HideSelection = True
		Me._txtFields_14.ReadOnly = False
		Me._txtFields_14.Maxlength = 0
		Me._txtFields_14.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_14.MultiLine = False
		Me._txtFields_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_14.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_14.TabStop = True
		Me._txtFields_14.Visible = True
		Me._txtFields_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_14.Name = "_txtFields_14"
		Me._chkFields_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_13.Text = "Discontinued:"
		Me._chkFields_13.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_13.Size = New System.Drawing.Size(86, 19)
		Me._chkFields_13.Location = New System.Drawing.Point(206, 132)
		Me._chkFields_13.TabIndex = 11
		Me._chkFields_13.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_13.CausesValidation = True
		Me._chkFields_13.Enabled = True
		Me._chkFields_13.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_13.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_13.TabStop = True
		Me._chkFields_13.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_13.Visible = True
		Me._chkFields_13.Name = "_chkFields_13"
		Me._chkFields_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_12.Text = "Disabled:"
		Me._chkFields_12.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_12.Size = New System.Drawing.Size(64, 19)
		Me._chkFields_12.Location = New System.Drawing.Point(140, 132)
		Me._chkFields_12.TabIndex = 10
		Me._chkFields_12.BackColor = System.Drawing.SystemColors.Control
		Me._chkFields_12.CausesValidation = True
		Me._chkFields_12.Enabled = True
		Me._chkFields_12.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_12.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_12.TabStop = True
		Me._chkFields_12.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_12.Visible = True
		Me._chkFields_12.Name = "_chkFields_12"
		Me._txtFields_8.AutoSize = False
		Me._txtFields_8.Size = New System.Drawing.Size(202, 19)
		Me._txtFields_8.Location = New System.Drawing.Point(89, 15)
		Me._txtFields_8.Maxlength = 40
		Me._txtFields_8.TabIndex = 4
		Me._txtFields_8.AcceptsReturn = True
		Me._txtFields_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_8.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_8.CausesValidation = True
		Me._txtFields_8.Enabled = True
		Me._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_8.HideSelection = True
		Me._txtFields_8.ReadOnly = False
		Me._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_8.MultiLine = False
		Me._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_8.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_8.TabStop = True
		Me._txtFields_8.Visible = True
		Me._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_8.Name = "_txtFields_8"
        'cmbVat.OcxState = CType(resources.GetObject("cmbVat.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbVat.Size = New System.Drawing.Size(178, 21)
		Me.cmbVat.Location = New System.Drawing.Point(89, 81)
		Me.cmbVat.TabIndex = 7
		Me.cmbVat.Name = "cmbVat"
        'cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbDeposit.Size = New System.Drawing.Size(178, 21)
		Me.cmbDeposit.Location = New System.Drawing.Point(89, 57)
		Me.cmbDeposit.TabIndex = 6
		Me.cmbDeposit.Name = "cmbDeposit"
        'cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbSupplier.Size = New System.Drawing.Size(178, 21)
		Me.cmbSupplier.Location = New System.Drawing.Point(89, 105)
		Me.cmbSupplier.TabIndex = 8
		Me.cmbSupplier.Name = "cmbSupplier"
        'cmbPrintLocation.OcxState = CType(resources.GetObject("cmbPrintLocation.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPrintLocation.Size = New System.Drawing.Size(175, 21)
		Me.cmbPrintLocation.Location = New System.Drawing.Point(89, 156)
		Me.cmbPrintLocation.TabIndex = 12
		Me.cmbPrintLocation.Name = "cmbPrintLocation"
        'cmbPrintGroup.OcxState = CType(resources.GetObject("cmbPrintGroup.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPrintGroup.Size = New System.Drawing.Size(174, 21)
		Me.cmbPrintGroup.Location = New System.Drawing.Point(89, 180)
		Me.cmbPrintGroup.TabIndex = 89
		Me.cmbPrintGroup.Name = "cmbPrintGroup"
        'cmbPackSize.OcxState = CType(resources.GetObject("cmbPackSize.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbPackSize.Size = New System.Drawing.Size(174, 21)
		Me.cmbPackSize.Location = New System.Drawing.Point(89, 206)
		Me.cmbPackSize.TabIndex = 110
		Me.cmbPackSize.Name = "cmbPackSize"
		Me._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_16.Text = "Pack Size:"
		Me._lblLabels_16.Size = New System.Drawing.Size(51, 13)
		Me._lblLabels_16.Location = New System.Drawing.Point(32, 208)
		Me._lblLabels_16.TabIndex = 111
		Me._lblLabels_16.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_16.Enabled = True
		Me._lblLabels_16.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_16.UseMnemonic = True
		Me._lblLabels_16.Visible = True
		Me._lblLabels_16.AutoSize = True
		Me._lblLabels_16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_16.Name = "_lblLabels_16"
		Me._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_13.Text = "Print Group:"
		Me._lblLabels_13.Size = New System.Drawing.Size(56, 13)
		Me._lblLabels_13.Location = New System.Drawing.Point(27, 186)
		Me._lblLabels_13.TabIndex = 90
		Me._lblLabels_13.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_13.Enabled = True
		Me._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_13.UseMnemonic = True
		Me._lblLabels_13.Visible = True
		Me._lblLabels_13.AutoSize = True
		Me._lblLabels_13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_13.Name = "_lblLabels_13"
		Me._lblLabels_12.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_12.Text = "Supplier Code:"
		Me._lblLabels_12.Size = New System.Drawing.Size(69, 13)
		Me._lblLabels_12.Location = New System.Drawing.Point(16, 135)
		Me._lblLabels_12.TabIndex = 70
		Me._lblLabels_12.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_12.Enabled = True
		Me._lblLabels_12.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_12.UseMnemonic = True
		Me._lblLabels_12.Visible = True
		Me._lblLabels_12.AutoSize = True
		Me._lblLabels_12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_12.Name = "_lblLabels_12"
		Me._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_14.Text = "POS Quick Key:"
		Me._lblLabels_14.Size = New System.Drawing.Size(77, 13)
		Me._lblLabels_14.Location = New System.Drawing.Point(7, 42)
		Me._lblLabels_14.TabIndex = 69
		Me._lblLabels_14.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_14.Enabled = True
		Me._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_14.UseMnemonic = True
		Me._lblLabels_14.Visible = True
		Me._lblLabels_14.AutoSize = True
		Me._lblLabels_14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_14.Name = "_lblLabels_14"
		Me._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_8.Text = "Receipt Name:"
		Me._lblLabels_8.Size = New System.Drawing.Size(71, 13)
		Me._lblLabels_8.Location = New System.Drawing.Point(13, 21)
		Me._lblLabels_8.TabIndex = 68
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
		Me._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_6.Text = "Deposit:"
		Me._lblLabels_6.Size = New System.Drawing.Size(39, 13)
		Me._lblLabels_6.Location = New System.Drawing.Point(45, 63)
		Me._lblLabels_6.TabIndex = 67
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
		Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_5.Text = "VAT:"
		Me._lblLabels_5.Size = New System.Drawing.Size(24, 13)
		Me._lblLabels_5.Location = New System.Drawing.Point(60, 87)
		Me._lblLabels_5.TabIndex = 66
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
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.Text = "Default Supplier:"
		Me._lblLabels_0.Size = New System.Drawing.Size(78, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(6, 111)
		Me._lblLabels_0.TabIndex = 65
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
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.Text = "Print Location:"
		Me._lblLabels_2.Size = New System.Drawing.Size(68, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(16, 162)
		Me._lblLabels_2.TabIndex = 64
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
		Me.txtholdname.AutoSize = False
		Me.txtholdname.Size = New System.Drawing.Size(63, 19)
		Me.txtholdname.Location = New System.Drawing.Point(220, 570)
		Me.txtholdname.TabIndex = 106
		Me.txtholdname.AcceptsReturn = True
		Me.txtholdname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtholdname.BackColor = System.Drawing.SystemColors.Window
		Me.txtholdname.CausesValidation = True
		Me.txtholdname.Enabled = True
		Me.txtholdname.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtholdname.HideSelection = True
		Me.txtholdname.ReadOnly = False
		Me.txtholdname.Maxlength = 0
		Me.txtholdname.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtholdname.MultiLine = False
		Me.txtholdname.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtholdname.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtholdname.TabStop = True
		Me.txtholdname.Visible = True
		Me.txtholdname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtholdname.Name = "txtholdname"
		Me.txttemphold.AutoSize = False
		Me.txttemphold.Size = New System.Drawing.Size(83, 19)
		Me.txttemphold.Location = New System.Drawing.Point(42, 572)
		Me.txttemphold.TabIndex = 105
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
		Me._txtFields_7.AutoSize = False
		Me._txtFields_7.Size = New System.Drawing.Size(202, 19)
		Me._txtFields_7.Location = New System.Drawing.Point(103, 45)
		Me._txtFields_7.Maxlength = 128
		Me._txtFields_7.TabIndex = 1
		Me._txtFields_7.AcceptsReturn = True
		Me._txtFields_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_7.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_7.CausesValidation = True
		Me._txtFields_7.Enabled = True
		Me._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_7.HideSelection = True
		Me._txtFields_7.ReadOnly = False
		Me._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_7.MultiLine = False
		Me._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_7.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_7.TabStop = True
		Me._txtFields_7.Visible = True
		Me._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_7.Name = "_txtFields_7"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.Size = New System.Drawing.Size(79, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(596, 382)
		Me._txtFields_1.TabIndex = 50
		Me._txtFields_1.Visible = False
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Maxlength = 0
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_1.Name = "_txtFields_1"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(592, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 41
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
		Me.cmdNext.Location = New System.Drawing.Point(427, 3)
		Me.cmdNext.TabIndex = 108
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.cmdHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdHistory.Text = "&History"
		Me.cmdHistory.Size = New System.Drawing.Size(67, 29)
		Me.cmdHistory.Location = New System.Drawing.Point(233, 3)
		Me.cmdHistory.TabIndex = 47
		Me.cmdHistory.TabStop = False
		Me.cmdHistory.BackColor = System.Drawing.SystemColors.Control
		Me.cmdHistory.CausesValidation = True
		Me.cmdHistory.Enabled = True
		Me.cmdHistory.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdHistory.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdHistory.Name = "cmdHistory"
		Me.cmdDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDuplicate.Text = "&Duplicate Codes Report"
		Me.cmdDuplicate.Size = New System.Drawing.Size(121, 29)
		Me.cmdDuplicate.Location = New System.Drawing.Point(303, 3)
		Me.cmdDuplicate.TabIndex = 46
		Me.cmdDuplicate.TabStop = False
		Me.cmdDuplicate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDuplicate.CausesValidation = True
		Me.cmdDuplicate.Enabled = True
		Me.cmdDuplicate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDuplicate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDuplicate.Name = "cmdDuplicate"
		Me.cmdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDetails.Text = "&Pricing"
		Me.cmdDetails.Size = New System.Drawing.Size(73, 29)
		Me.cmdDetails.Location = New System.Drawing.Point(157, 3)
		Me.cmdDetails.TabIndex = 45
		Me.cmdDetails.TabStop = False
		Me.cmdDetails.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDetails.CausesValidation = True
		Me.cmdDetails.Enabled = True
		Me.cmdDetails.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDetails.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDetails.Name = "cmdDetails"
		Me.cmdbarcodeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdbarcodeItem.Text = "&Barcodes"
		Me.cmdbarcodeItem.Size = New System.Drawing.Size(73, 29)
		Me.cmdbarcodeItem.Location = New System.Drawing.Point(82, 3)
		Me.cmdbarcodeItem.TabIndex = 44
		Me.cmdbarcodeItem.TabStop = False
		Me.cmdbarcodeItem.BackColor = System.Drawing.SystemColors.Control
		Me.cmdbarcodeItem.CausesValidation = True
		Me.cmdbarcodeItem.Enabled = True
		Me.cmdbarcodeItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdbarcodeItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdbarcodeItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdbarcodeItem.Name = "cmdbarcodeItem"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
		Me.cmdCancel.TabIndex = 43
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(510, 3)
		Me.cmdClose.TabIndex = 42
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.ILtree.ImageSize = New System.Drawing.Size(16, 16)
		Me.ILtree.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.ILtree.Images.SetKeyName(0, "")
		Me.ILtree.Images.SetKeyName(1, "")
		Me.ILtree.Images.SetKeyName(2, "")
		Me._Frame1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_1.Size = New System.Drawing.Size(556, 395)
		Me._Frame1_1.Location = New System.Drawing.Point(12, 104)
		Me._Frame1_1.TabIndex = 34
		Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_1.Enabled = True
		Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_1.Visible = True
		Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_1.Name = "_Frame1_1"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "Print Bill Of Material"
		Me.cmdPrint.Size = New System.Drawing.Size(106, 34)
		Me.cmdPrint.Location = New System.Drawing.Point(174, 15)
		Me.cmdPrint.TabIndex = 91
		Me.cmdPrint.Visible = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdRecipeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRecipeAdd.Text = "Add StockItem"
		Me.cmdRecipeAdd.Size = New System.Drawing.Size(100, 34)
		Me.cmdRecipeAdd.Location = New System.Drawing.Point(390, 15)
		Me.cmdRecipeAdd.TabIndex = 35
		Me.cmdRecipeAdd.TabStop = False
		Me.cmdRecipeAdd.Visible = False
		Me.cmdRecipeAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRecipeAdd.CausesValidation = True
		Me.cmdRecipeAdd.Enabled = True
		Me.cmdRecipeAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRecipeAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRecipeAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRecipeAdd.Name = "cmdRecipeAdd"
		Me._optRecipeType_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optRecipeType_0.Text = "Not a Bill Of Material"
		Me._optRecipeType_0.Size = New System.Drawing.Size(133, 58)
		Me._optRecipeType_0.Location = New System.Drawing.Point(27, 57)
		Me._optRecipeType_0.Appearance = System.Windows.Forms.Appearance.Button
		Me._optRecipeType_0.TabIndex = 36
		Me._optRecipeType_0.TabStop = False
		Me._optRecipeType_0.Checked = True
		Me._optRecipeType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optRecipeType_0.BackColor = System.Drawing.SystemColors.Control
		Me._optRecipeType_0.CausesValidation = True
		Me._optRecipeType_0.Enabled = True
		Me._optRecipeType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optRecipeType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optRecipeType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optRecipeType_0.Visible = True
		Me._optRecipeType_0.Name = "_optRecipeType_0"
		Me._optRecipeType_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optRecipeType_1.Text = "Production"
		Me._optRecipeType_1.Size = New System.Drawing.Size(133, 58)
		Me._optRecipeType_1.Location = New System.Drawing.Point(27, 129)
		Me._optRecipeType_1.Appearance = System.Windows.Forms.Appearance.Button
		Me._optRecipeType_1.TabIndex = 37
		Me._optRecipeType_1.TabStop = False
		Me._optRecipeType_1.Visible = False
		Me._optRecipeType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optRecipeType_1.BackColor = System.Drawing.SystemColors.Control
		Me._optRecipeType_1.CausesValidation = True
		Me._optRecipeType_1.Enabled = True
		Me._optRecipeType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optRecipeType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optRecipeType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optRecipeType_1.Checked = False
		Me._optRecipeType_1.Name = "_optRecipeType_1"
		Me._optRecipeType_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optRecipeType_2.Text = "At time of Sale"
		Me._optRecipeType_2.Size = New System.Drawing.Size(133, 58)
		Me._optRecipeType_2.Location = New System.Drawing.Point(27, 201)
		Me._optRecipeType_2.Appearance = System.Windows.Forms.Appearance.Button
		Me._optRecipeType_2.TabIndex = 38
		Me._optRecipeType_2.TabStop = False
		Me._optRecipeType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optRecipeType_2.BackColor = System.Drawing.SystemColors.Control
		Me._optRecipeType_2.CausesValidation = True
		Me._optRecipeType_2.Enabled = True
		Me._optRecipeType_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optRecipeType_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optRecipeType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optRecipeType_2.Checked = False
		Me._optRecipeType_2.Visible = True
		Me._optRecipeType_2.Name = "_optRecipeType_2"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtQuantity.Size = New System.Drawing.Size(64, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(168, 336)
		Me.txtQuantity.TabIndex = 48
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
		Me._optRecipeType_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optRecipeType_3.Text = "This Product makes other products"
		Me._optRecipeType_3.Size = New System.Drawing.Size(133, 58)
		Me._optRecipeType_3.Location = New System.Drawing.Point(27, 273)
		Me._optRecipeType_3.Appearance = System.Windows.Forms.Appearance.Button
		Me._optRecipeType_3.TabIndex = 39
		Me._optRecipeType_3.TabStop = False
		Me._optRecipeType_3.Visible = False
		Me._optRecipeType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optRecipeType_3.BackColor = System.Drawing.SystemColors.Control
		Me._optRecipeType_3.CausesValidation = True
		Me._optRecipeType_3.Enabled = True
		Me._optRecipeType_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optRecipeType_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._optRecipeType_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optRecipeType_3.Checked = False
		Me._optRecipeType_3.Name = "_optRecipeType_3"
        'FGRecipe.OcxState = CType(resources.GetObject("FGRecipe.OcxState"), System.Windows.Forms.AxHost.State)
		Me.FGRecipe.Size = New System.Drawing.Size(366, 274)
		Me.FGRecipe.Location = New System.Drawing.Point(174, 57)
		Me.FGRecipe.TabIndex = 40
		Me.FGRecipe.Name = "FGRecipe"
		Me.lblRecipeCost.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblRecipeCost.Text = "0.00"
		Me.lblRecipeCost.Size = New System.Drawing.Size(88, 19)
		Me.lblRecipeCost.Location = New System.Drawing.Point(396, 333)
		Me.lblRecipeCost.TabIndex = 49
		Me.lblRecipeCost.BackColor = System.Drawing.SystemColors.Control
		Me.lblRecipeCost.Enabled = True
		Me.lblRecipeCost.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRecipeCost.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRecipeCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRecipeCost.UseMnemonic = True
		Me.lblRecipeCost.Visible = True
		Me.lblRecipeCost.AutoSize = False
		Me.lblRecipeCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRecipeCost.Name = "lblRecipeCost"
		Me._Frame1_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_2.Size = New System.Drawing.Size(556, 385)
		Me._Frame1_2.Location = New System.Drawing.Point(12, 96)
		Me._Frame1_2.TabIndex = 78
		Me._Frame1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_2.Enabled = True
		Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_2.Visible = True
		Me._Frame1_2.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_2.Name = "_Frame1_2"
		Me._cmdNew_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdNew_2.Text = "New Child  from existed Stock"
		Me._cmdNew_2.Size = New System.Drawing.Size(79, 52)
		Me._cmdNew_2.Location = New System.Drawing.Point(468, 75)
		Me._cmdNew_2.TabIndex = 112
		Me._cmdNew_2.TabStop = False
		Me._cmdNew_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdNew_2.CausesValidation = True
		Me._cmdNew_2.Enabled = True
		Me._cmdNew_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdNew_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdNew_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdNew_2.Name = "_cmdNew_2"
		Me.cmdDeallocate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeallocate.Text = "De-allocate >>"
		Me.cmdDeallocate.Size = New System.Drawing.Size(82, 31)
		Me.cmdDeallocate.Location = New System.Drawing.Point(210, 252)
		Me.cmdDeallocate.TabIndex = 85
		Me.cmdDeallocate.TabStop = False
		Me.cmdDeallocate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDeallocate.CausesValidation = True
		Me.cmdDeallocate.Enabled = True
		Me.cmdDeallocate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDeallocate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDeallocate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDeallocate.Name = "cmdDeallocate"
		Me.cmdAllocate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAllocate.Text = "<< Allocate"
		Me.cmdAllocate.Size = New System.Drawing.Size(82, 31)
		Me.cmdAllocate.Location = New System.Drawing.Point(210, 84)
		Me.cmdAllocate.TabIndex = 84
		Me.cmdAllocate.TabStop = False
		Me.cmdAllocate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAllocate.CausesValidation = True
		Me.cmdAllocate.Enabled = True
		Me.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAllocate.Name = "cmdAllocate"
		Me._cmdMove_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_1.Text = "Move Down"
		Me._cmdMove_1.Size = New System.Drawing.Size(79, 28)
		Me._cmdMove_1.Location = New System.Drawing.Point(468, 197)
		Me._cmdMove_1.TabIndex = 83
		Me._cmdMove_1.TabStop = False
		Me._cmdMove_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_1.CausesValidation = True
		Me._cmdMove_1.Enabled = True
		Me._cmdMove_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_1.Name = "_cmdMove_1"
		Me._cmdMove_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdMove_0.Text = "Move Up"
		Me._cmdMove_0.Size = New System.Drawing.Size(79, 28)
		Me._cmdMove_0.Location = New System.Drawing.Point(468, 167)
		Me._cmdMove_0.TabIndex = 82
		Me._cmdMove_0.TabStop = False
		Me._cmdMove_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdMove_0.CausesValidation = True
		Me._cmdMove_0.Enabled = True
		Me._cmdMove_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdMove_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdMove_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdMove_0.Name = "_cmdMove_0"
		Me._cmdNew_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdNew_1.Text = "New Child"
		Me._cmdNew_1.Size = New System.Drawing.Size(79, 28)
		Me._cmdNew_1.Location = New System.Drawing.Point(468, 45)
		Me._cmdNew_1.TabIndex = 81
		Me._cmdNew_1.TabStop = False
		Me._cmdNew_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdNew_1.CausesValidation = True
		Me._cmdNew_1.Enabled = True
		Me._cmdNew_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdNew_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdNew_1.Name = "_cmdNew_1"
		Me._cmdNew_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdNew_0.Text = "New Message"
		Me._cmdNew_0.Size = New System.Drawing.Size(79, 28)
		Me._cmdNew_0.Location = New System.Drawing.Point(468, 15)
		Me._cmdNew_0.TabIndex = 80
		Me._cmdNew_0.TabStop = False
		Me._cmdNew_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdNew_0.CausesValidation = True
		Me._cmdNew_0.Enabled = True
		Me._cmdNew_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdNew_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdNew_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdNew_0.Name = "_cmdNew_0"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "Delete Item"
		Me.cmdDelete.Size = New System.Drawing.Size(79, 28)
		Me.cmdDelete.Location = New System.Drawing.Point(468, 321)
		Me.cmdDelete.TabIndex = 79
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.TVMessage.CausesValidation = True
		Me.TVMessage.Size = New System.Drawing.Size(157, 334)
		Me.TVMessage.Location = New System.Drawing.Point(303, 15)
		Me.TVMessage.TabIndex = 86
		Me.TVMessage.HideSelection = False
		Me.TVMessage.Indent = 36
		Me.TVMessage.LabelEdit = False
		Me.TVMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TVMessage.Name = "TVMessage"
		Me.TreeView1.CausesValidation = True
		Me.TreeView1.Size = New System.Drawing.Size(193, 334)
		Me.TreeView1.Location = New System.Drawing.Point(9, 15)
		Me.TreeView1.TabIndex = 87
		Me.TreeView1.HideSelection = False
		Me.TreeView1.Indent = 36
		Me.TreeView1.LabelEdit = False
		Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeView1.Name = "TreeView1"
        'TabStrip1.OcxState = CType(resources.GetObject("TabStrip1.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.TabStrip1.Size = New System.Drawing.Size(577, 469)
        'Me.TabStrip1.Location = New System.Drawing.Point(8, 68)
        'Me.TabStrip1.TabIndex = 2
        'Me.TabStrip1.Name = "TabStrip1"
		Me._Frame1_3.Size = New System.Drawing.Size(560, 387)
		Me._Frame1_3.Location = New System.Drawing.Point(10, 108)
		Me._Frame1_3.TabIndex = 94
		Me._Frame1_3.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_3.Enabled = True
		Me._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_3.Visible = True
		Me._Frame1_3.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_3.Name = "_Frame1_3"
		Me.Frame4.Text = "Details"
		Me.Frame4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Frame4.Size = New System.Drawing.Size(531, 379)
		Me.Frame4.Location = New System.Drawing.Point(6, 6)
		Me.Frame4.TabIndex = 95
		Me.Frame4.BackColor = System.Drawing.SystemColors.Control
		Me.Frame4.Enabled = True
		Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame4.Visible = True
		Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame4.Name = "Frame4"
		Me.lstvSerial.Size = New System.Drawing.Size(519, 339)
		Me.lstvSerial.Location = New System.Drawing.Point(10, 12)
		Me.lstvSerial.TabIndex = 96
		Me.lstvSerial.View = System.Windows.Forms.View.Details
		Me.lstvSerial.Alignment = System.Windows.Forms.ListViewAlignment.Left
		Me.lstvSerial.LabelWrap = True
		Me.lstvSerial.HideSelection = True
		Me.lstvSerial.FullRowSelect = True
		Me.lstvSerial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstvSerial.BackColor = System.Drawing.SystemColors.Window
		Me.lstvSerial.LabelEdit = True
		Me.lstvSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstvSerial.Name = "lstvSerial"
		Me._lstvSerial_ColumnHeader_1.Text = "Serial Number"
		Me._lstvSerial_ColumnHeader_1.Width = 170
		Me._lstvSerial_ColumnHeader_2.Text = "Supplier's Name"
		Me._lstvSerial_ColumnHeader_2.Width = 170
		Me._lstvSerial_ColumnHeader_3.Text = "Date Purchased"
		Me._lstvSerial_ColumnHeader_3.Width = 170
		Me._lstvSerial_ColumnHeader_4.Text = "In Stock"
		Me._lstvSerial_ColumnHeader_4.Width = 170
		Me._lstvSerial_ColumnHeader_5.Text = "Date Sold"
		Me._lstvSerial_ColumnHeader_5.Width = 170
		Me._lstvSerial_ColumnHeader_6.Text = "Invoice Number"
		Me._lstvSerial_ColumnHeader_6.Width = 170
		Me._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_7.Text = "Display Name:"
		Me._lblLabels_7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblLabels_7.Size = New System.Drawing.Size(89, 16)
		Me._lblLabels_7.Location = New System.Drawing.Point(10, 48)
		Me._lblLabels_7.TabIndex = 0
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
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(txtholdname)
		Me.Controls.Add(txttemphold)
		Me.Controls.Add(_txtFields_7)
		Me.Controls.Add(_txtFields_1)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_Frame1_1)
		Me.Controls.Add(_Frame1_2)
        'Me.Controls.Add(TabStrip1)
		Me.Controls.Add(_Frame1_3)
		Me.Controls.Add(_lblLabels_7)
		Me._Frame1_0.Controls.Add(Frame6)
		Me._Frame1_0.Controls.Add(Frame5)
		Me._Frame1_0.Controls.Add(Frame3)
		Me._Frame1_0.Controls.Add(_Frame2_1)
		Me._Frame1_0.Controls.Add(_Frame2_2)
		Me._Frame1_0.Controls.Add(_Frame2_3)
		Me._Frame1_0.Controls.Add(_Frame2_4)
		Me._Frame1_0.Controls.Add(_Frame2_5)
		Me._Frame1_0.Controls.Add(_Frame2_0)
		Me.Frame6.Controls.Add(_chkSerialTracking_1)
		Me.Frame6.Controls.Add(_chkFields_6)
		Me.Frame5.Controls.Add(chkbarcode)
		Me.Frame5.Controls.Add(chkshelf)
		Me.Frame3.Controls.Add(_chkFields_1)
		Me.Frame3.Controls.Add(_chkSerialTracking_0)
		Me._Frame2_1.Controls.Add(cmdReportGroup)
		Me._Frame2_1.Controls.Add(cmdStockGroup)
		Me._Frame2_1.Controls.Add(cmdPricingGroup)
		Me._Frame2_1.Controls.Add(cmbPricingGroup)
		Me._Frame2_1.Controls.Add(cmbStockGroup)
		Me._Frame2_1.Controls.Add(cmbReportGroup)
		Me._Frame2_1.Controls.Add(_lblLabels_15)
		Me._Frame2_1.Controls.Add(_lblLabels_4)
		Me._Frame2_1.Controls.Add(_lblLabels_3)
		Me._Frame2_2.Controls.Add(cmdShrink)
		Me._Frame2_2.Controls.Add(_txtFloat_1)
		Me._Frame2_2.Controls.Add(_txtFloat_0)
		Me._Frame2_2.Controls.Add(_txtInteger_0)
		Me._Frame2_2.Controls.Add(cmbShrink)
		Me._Frame2_2.Controls.Add(_lblLabels_11)
		Me._Frame2_2.Controls.Add(_lblLabels_10)
		Me._Frame2_2.Controls.Add(_lblLabels_9)
		Me._Frame2_2.Controls.Add(_lblLabels_1)
		Me._Frame2_3.Controls.Add(cmbReorder)
		Me._Frame2_3.Controls.Add(_txtInteger_3)
		Me._Frame2_3.Controls.Add(_txtInteger_1)
		Me._Frame2_3.Controls.Add(_chkFields_0)
		Me._Frame2_3.Controls.Add(_txtInteger_2)
		Me._Frame2_3.Controls.Add(_lbl_7)
		Me._Frame2_3.Controls.Add(_lbl_0)
		Me._Frame2_3.Controls.Add(_lbl_5)
		Me._Frame2_3.Controls.Add(_lbl_4)
		Me._Frame2_4.Controls.Add(cmdpriceselist)
		Me._Frame2_4.Controls.Add(chkPriceSet)
		Me._Frame2_4.Controls.Add(cmbPriceSet)
		Me._Frame2_4.Controls.Add(lblPriceSet)
		Me._Frame2_5.Controls.Add(_txtInteger_4)
		Me._Frame2_5.Controls.Add(_chkFields_5)
		Me._Frame2_5.Controls.Add(chkSQ)
		Me._Frame2_5.Controls.Add(_chkFields_3)
		Me._Frame2_5.Controls.Add(_chkFields_2)
		Me._Frame2_5.Controls.Add(_chkFields_4)
		Me._Frame2_5.Controls.Add(_lbl_1)
		Me._Frame2_0.Controls.Add(cmdPackSize)
		Me._Frame2_0.Controls.Add(cmdPrintGroup)
		Me._Frame2_0.Controls.Add(cmdVAT)
		Me._Frame2_0.Controls.Add(cmdPrintLocation)
		Me._Frame2_0.Controls.Add(cmdSupplier)
		Me._Frame2_0.Controls.Add(cmdDeposit)
		Me._Frame2_0.Controls.Add(_txtFields_0)
		Me._Frame2_0.Controls.Add(_txtFields_14)
		Me._Frame2_0.Controls.Add(_chkFields_13)
		Me._Frame2_0.Controls.Add(_chkFields_12)
		Me._Frame2_0.Controls.Add(_txtFields_8)
		Me._Frame2_0.Controls.Add(cmbVat)
		Me._Frame2_0.Controls.Add(cmbDeposit)
		Me._Frame2_0.Controls.Add(cmbSupplier)
		Me._Frame2_0.Controls.Add(cmbPrintLocation)
		Me._Frame2_0.Controls.Add(cmbPrintGroup)
		Me._Frame2_0.Controls.Add(cmbPackSize)
		Me._Frame2_0.Controls.Add(_lblLabels_16)
		Me._Frame2_0.Controls.Add(_lblLabels_13)
		Me._Frame2_0.Controls.Add(_lblLabels_12)
		Me._Frame2_0.Controls.Add(_lblLabels_14)
		Me._Frame2_0.Controls.Add(_lblLabels_8)
		Me._Frame2_0.Controls.Add(_lblLabels_6)
		Me._Frame2_0.Controls.Add(_lblLabels_5)
		Me._Frame2_0.Controls.Add(_lblLabels_0)
		Me._Frame2_0.Controls.Add(_lblLabels_2)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdHistory)
		Me.picButtons.Controls.Add(cmdDuplicate)
		Me.picButtons.Controls.Add(cmdDetails)
		Me.picButtons.Controls.Add(cmdbarcodeItem)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
		Me._Frame1_1.Controls.Add(cmdPrint)
		Me._Frame1_1.Controls.Add(cmdRecipeAdd)
		Me._Frame1_1.Controls.Add(_optRecipeType_0)
		Me._Frame1_1.Controls.Add(_optRecipeType_1)
		Me._Frame1_1.Controls.Add(_optRecipeType_2)
		Me._Frame1_1.Controls.Add(txtQuantity)
		Me._Frame1_1.Controls.Add(_optRecipeType_3)
		Me._Frame1_1.Controls.Add(FGRecipe)
		Me._Frame1_1.Controls.Add(lblRecipeCost)
		Me._Frame1_2.Controls.Add(_cmdNew_2)
		Me._Frame1_2.Controls.Add(cmdDeallocate)
		Me._Frame1_2.Controls.Add(cmdAllocate)
		Me._Frame1_2.Controls.Add(_cmdMove_1)
		Me._Frame1_2.Controls.Add(_cmdMove_0)
		Me._Frame1_2.Controls.Add(_cmdNew_1)
		Me._Frame1_2.Controls.Add(_cmdNew_0)
		Me._Frame1_2.Controls.Add(cmdDelete)
		Me._Frame1_2.Controls.Add(TVMessage)
		Me._Frame1_2.Controls.Add(TreeView1)
		Me._Frame1_3.Controls.Add(Frame4)
		Me.Frame4.Controls.Add(lstvSerial)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_1)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_2)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_3)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_4)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_5)
		Me.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_6)
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
        'Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
        'Me.Frame1.SetIndex(_Frame1_3, CType(3, Short))
        'Me.Frame2.SetIndex(_Frame2_1, CType(1, Short))
        'Me.Frame2.SetIndex(_Frame2_2, CType(2, Short))
        'Me.Frame2.SetIndex(_Frame2_3, CType(3, Short))
        'Me.Frame2.SetIndex(_Frame2_4, CType(4, Short))
        'Me.Frame2.SetIndex(_Frame2_5, CType(5, Short))
        'Me.Frame2.SetIndex(_Frame2_0, CType(0, Short))
        'Me.chkFields.SetIndex(_chkFields_6, CType(6, Short))
        'Me.chkFields.SetIndex(_chkFields_1, CType(1, Short))
        'Me.chkFields.SetIndex(_chkFields_0, CType(0, Short))
        'Me.chkFields.SetIndex(_chkFields_5, CType(5, Short))
        'Me.chkFields.SetIndex(_chkFields_3, CType(3, Short))
        'Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
        'Me.chkFields.SetIndex(_chkFields_4, CType(4, Short))
        'Me.chkFields.SetIndex(_chkFields_13, CType(13, Short))
        'Me.chkFields.SetIndex(_chkFields_12, CType(12, Short))
        'Me.chkSerialTracking.SetIndex(_chkSerialTracking_1, CType(1, Short))
        'Me.chkSerialTracking.SetIndex(_chkSerialTracking_0, CType(0, Short))
        'Me.cmdMove.SetIndex(_cmdMove_1, CType(1, Short))
        'Me.cmdMove.SetIndex(_cmdMove_0, CType(0, Short))
        'Me.cmdNew.SetIndex(_cmdNew_2, CType(2, Short))
        'Me.cmdNew.SetIndex(_cmdNew_1, CType(1, Short))
        'Me.cmdNew.SetIndex(_cmdNew_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_7, CType(7, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'M() ''e.lblLabels.SetIndex(_lblLabels_15, CType(15, Short))
        'M() 'e.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
        'Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
        'Me.lblLabels.SetIndex(_lblLabels_11, CType(11, Short))
        'Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
        'Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_16, CType(16, Short))
        'Me.lblLabels.SetIndex(_lblLabels_13, CType(13, Short))
        'Me.lblLabels.SetIndex(_lblLabels_12, CType(12, Short))
        'Me.lblLabels.SetIndex(_lblLabels_14, CType(14, Short))
        'Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
        'M() ''e.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
        'M() 'e.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
        'M() 'e.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
        'Me.optRecipeType.SetIndex(_optRecipeType_0, CType(0, Short))
        'Me.optRecipeType.SetIndex(_optRecipeType_1, CType(1, Short))
        'Me.optRecipeType.SetIndex(_optRecipeType_2, CType(2, Short))
        'Me.optRecipeType.SetIndex(_optRecipeType_3, CType(3, Short))
        'Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
        'Me.txtFields.SetIndex(_txtFields_14, CType(14, Short))
        'Me.txtFields.SetIndex(_txtFields_8, CType(8, Short))
        'Me.txtFields.SetIndex(_txtFields_7, CType(7, Short))
        'Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
        'Me.txtFloat.SetIndex(_txtFloat_1, CType(1, Short))
        'Me.txtFloat.SetIndex(_txtFloat_0, CType(0, Short))
        'Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
        'Me.txtInteger.SetIndex(_txtInteger_3, CType(3, Short))
        'Me.txtInteger.SetIndex(_txtInteger_1, CType(1, Short))
        'Me.txtInteger.SetIndex(_txtInteger_2, CType(2, Short))
        'Me.txtInteger.SetIndex(_txtInteger_4, CType(4, Short))
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.optRecipeType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdNew, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chkSerialTracking, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame2, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.TabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FGRecipe, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPackSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPrintGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPrintLocation, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbSupplier, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbDeposit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbVat, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPriceSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbReportGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbStockGroup, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbPricingGroup, System.ComponentModel.ISupportInitialize).EndInit()
		Me._Frame1_0.ResumeLayout(False)
		Me.Frame6.ResumeLayout(False)
		Me.Frame5.ResumeLayout(False)
		Me.Frame3.ResumeLayout(False)
		Me._Frame2_1.ResumeLayout(False)
		Me._Frame2_2.ResumeLayout(False)
		Me._Frame2_3.ResumeLayout(False)
		Me._Frame2_4.ResumeLayout(False)
		Me._Frame2_5.ResumeLayout(False)
		Me._Frame2_0.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me._Frame1_1.ResumeLayout(False)
		Me._Frame1_2.ResumeLayout(False)
		Me._Frame1_3.ResumeLayout(False)
		Me.Frame4.ResumeLayout(False)
		Me.lstvSerial.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class