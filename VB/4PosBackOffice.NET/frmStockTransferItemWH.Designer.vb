<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTransferItemWH
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
	Public WithEvents txtQty As System.Windows.Forms.TextBox
	Public WithEvents txtPSize As System.Windows.Forms.TextBox
	Public WithEvents txtPack As System.Windows.Forms.TextBox
	Public WithEvents txtPriceS As System.Windows.Forms.TextBox
	Public WithEvents txtQtyT As System.Windows.Forms.TextBox
	Public WithEvents txtPrice As System.Windows.Forms.TextBox
	Public WithEvents cmbQuantity As System.Windows.Forms.ComboBox
	Public WithEvents cmdPack As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _LBL_6 As System.Windows.Forms.Label
	Public WithEvents _LBL_4 As System.Windows.Forms.Label
	Public WithEvents _LBL_2 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblPComp As System.Windows.Forms.Label
	Public WithEvents lblSComp As System.Windows.Forms.Label
	Public WithEvents lblStockItemS As System.Windows.Forms.Label
	Public WithEvents _LBL_5 As System.Windows.Forms.Label
	Public WithEvents _LBL_0 As System.Windows.Forms.Label
	Public WithEvents _LBL_3 As System.Windows.Forms.Label
	Public WithEvents _LBL_1 As System.Windows.Forms.Label
	Public WithEvents lblStockItem As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTransferItemWH))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.txtQty = New System.Windows.Forms.TextBox
		Me.txtPSize = New System.Windows.Forms.TextBox
		Me.txtPack = New System.Windows.Forms.TextBox
		Me.txtPriceS = New System.Windows.Forms.TextBox
		Me.txtQtyT = New System.Windows.Forms.TextBox
		Me.txtPrice = New System.Windows.Forms.TextBox
		Me.cmbQuantity = New System.Windows.Forms.ComboBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdPack = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._LBL_6 = New System.Windows.Forms.Label
		Me._LBL_4 = New System.Windows.Forms.Label
		Me._LBL_2 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblPComp = New System.Windows.Forms.Label
		Me.lblSComp = New System.Windows.Forms.Label
		Me.lblStockItemS = New System.Windows.Forms.Label
		Me._LBL_5 = New System.Windows.Forms.Label
		Me._LBL_0 = New System.Windows.Forms.Label
		Me._LBL_3 = New System.Windows.Forms.Label
		Me._LBL_1 = New System.Windows.Forms.Label
		Me.lblStockItem = New System.Windows.Forms.Label
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Stock Transfer Item"
		Me.ClientSize = New System.Drawing.Size(400, 136)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
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
		Me.Name = "frmStockTransferItemWH"
		Me.txtQty.AutoSize = False
		Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQty.Size = New System.Drawing.Size(67, 19)
		Me.txtQty.Location = New System.Drawing.Point(316, 97)
		Me.txtQty.ReadOnly = True
		Me.txtQty.TabIndex = 20
		Me.txtQty.Text = "0"
		Me.txtQty.AcceptsReturn = True
		Me.txtQty.BackColor = System.Drawing.SystemColors.Window
		Me.txtQty.CausesValidation = True
		Me.txtQty.Enabled = True
		Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQty.HideSelection = True
		Me.txtQty.Maxlength = 0
		Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQty.MultiLine = False
		Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQty.TabStop = True
		Me.txtQty.Visible = True
		Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQty.Name = "txtQty"
		Me.txtPSize.AutoSize = False
		Me.txtPSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtPSize.Enabled = False
		Me.txtPSize.Size = New System.Drawing.Size(27, 19)
		Me.txtPSize.Location = New System.Drawing.Point(184, 97)
		Me.txtPSize.TabIndex = 19
		Me.txtPSize.Text = "1"
		Me.txtPSize.AcceptsReturn = True
		Me.txtPSize.BackColor = System.Drawing.SystemColors.Window
		Me.txtPSize.CausesValidation = True
		Me.txtPSize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPSize.HideSelection = True
		Me.txtPSize.ReadOnly = False
		Me.txtPSize.Maxlength = 0
		Me.txtPSize.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPSize.MultiLine = False
		Me.txtPSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPSize.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPSize.TabStop = True
		Me.txtPSize.Visible = True
		Me.txtPSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPSize.Name = "txtPSize"
		Me.txtPack.AutoSize = False
		Me.txtPack.Size = New System.Drawing.Size(41, 19)
		Me.txtPack.Location = New System.Drawing.Point(352, 272)
		Me.txtPack.TabIndex = 16
		Me.txtPack.Text = "0"
		Me.txtPack.Visible = False
		Me.txtPack.AcceptsReturn = True
		Me.txtPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPack.BackColor = System.Drawing.SystemColors.Window
		Me.txtPack.CausesValidation = True
		Me.txtPack.Enabled = True
		Me.txtPack.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPack.HideSelection = True
		Me.txtPack.ReadOnly = False
		Me.txtPack.Maxlength = 0
		Me.txtPack.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPack.MultiLine = False
		Me.txtPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPack.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPack.TabStop = True
		Me.txtPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPack.Name = "txtPack"
		Me.txtPriceS.AutoSize = False
		Me.txtPriceS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPriceS.Enabled = False
		Me.txtPriceS.Size = New System.Drawing.Size(91, 19)
		Me.txtPriceS.Location = New System.Drawing.Point(291, 346)
		Me.txtPriceS.TabIndex = 8
		Me.txtPriceS.Text = "0.00"
		Me.txtPriceS.Visible = False
		Me.txtPriceS.AcceptsReturn = True
		Me.txtPriceS.BackColor = System.Drawing.SystemColors.Window
		Me.txtPriceS.CausesValidation = True
		Me.txtPriceS.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPriceS.HideSelection = True
		Me.txtPriceS.ReadOnly = False
		Me.txtPriceS.Maxlength = 0
		Me.txtPriceS.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPriceS.MultiLine = False
		Me.txtPriceS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPriceS.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPriceS.TabStop = True
		Me.txtPriceS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPriceS.Name = "txtPriceS"
		Me.txtQtyT.AutoSize = False
		Me.txtQtyT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQtyT.Size = New System.Drawing.Size(67, 19)
		Me.txtQtyT.Location = New System.Drawing.Point(96, 97)
		Me.txtQtyT.TabIndex = 7
		Me.txtQtyT.Text = "0"
		Me.txtQtyT.AcceptsReturn = True
		Me.txtQtyT.BackColor = System.Drawing.SystemColors.Window
		Me.txtQtyT.CausesValidation = True
		Me.txtQtyT.Enabled = True
		Me.txtQtyT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQtyT.HideSelection = True
		Me.txtQtyT.ReadOnly = False
		Me.txtQtyT.Maxlength = 0
		Me.txtQtyT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQtyT.MultiLine = False
		Me.txtQtyT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQtyT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQtyT.TabStop = True
		Me.txtQtyT.Visible = True
		Me.txtQtyT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQtyT.Name = "txtQtyT"
		Me.txtPrice.AutoSize = False
		Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrice.Enabled = False
		Me.txtPrice.Size = New System.Drawing.Size(91, 19)
		Me.txtPrice.Location = New System.Drawing.Point(301, 249)
		Me.txtPrice.TabIndex = 4
		Me.txtPrice.Text = "0.00"
		Me.txtPrice.Visible = False
		Me.txtPrice.AcceptsReturn = True
		Me.txtPrice.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrice.CausesValidation = True
		Me.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrice.HideSelection = True
		Me.txtPrice.ReadOnly = False
		Me.txtPrice.Maxlength = 0
		Me.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrice.MultiLine = False
		Me.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrice.TabStop = True
		Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrice.Name = "txtPrice"
		Me.cmbQuantity.Size = New System.Drawing.Size(79, 21)
		Me.cmbQuantity.Location = New System.Drawing.Point(192, 248)
		Me.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbQuantity.TabIndex = 3
		Me.cmbQuantity.Visible = False
		Me.cmbQuantity.BackColor = System.Drawing.SystemColors.Window
		Me.cmbQuantity.CausesValidation = True
		Me.cmbQuantity.Enabled = True
		Me.cmbQuantity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbQuantity.IntegralHeight = True
		Me.cmbQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbQuantity.Sorted = False
		Me.cmbQuantity.TabStop = True
		Me.cmbQuantity.Name = "cmbQuantity"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(400, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPack.Text = "Break / Build P&ack"
		Me.cmdPack.Size = New System.Drawing.Size(105, 29)
		Me.cmdPack.Location = New System.Drawing.Point(88, 3)
		Me.cmdPack.TabIndex = 22
		Me.cmdPack.TabStop = False
		Me.cmdPack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPack.CausesValidation = True
		Me.cmdPack.Enabled = True
		Me.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPack.Name = "cmdPack"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(8, 3)
		Me.cmdCancel.TabIndex = 15
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
		Me.cmdClose.Location = New System.Drawing.Point(312, 3)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._LBL_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_6.Text = "Total Qty:"
		Me._LBL_6.Size = New System.Drawing.Size(46, 13)
		Me._LBL_6.Location = New System.Drawing.Point(268, 99)
		Me._LBL_6.TabIndex = 21
		Me._LBL_6.BackColor = System.Drawing.Color.Transparent
		Me._LBL_6.Enabled = True
		Me._LBL_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_6.UseMnemonic = True
		Me._LBL_6.Visible = True
		Me._LBL_6.AutoSize = True
		Me._LBL_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_6.Name = "_LBL_6"
		Me._LBL_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_4.Text = "x"
		Me._LBL_4.Size = New System.Drawing.Size(8, 16)
		Me._LBL_4.Location = New System.Drawing.Point(170, 98)
		Me._LBL_4.TabIndex = 18
		Me._LBL_4.BackColor = System.Drawing.Color.Transparent
		Me._LBL_4.Enabled = True
		Me._LBL_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_4.UseMnemonic = True
		Me._LBL_4.Visible = True
		Me._LBL_4.AutoSize = True
		Me._LBL_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_4.Name = "_LBL_4"
		Me._LBL_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_2.Text = "Item Qty:"
		Me._LBL_2.Size = New System.Drawing.Size(42, 13)
		Me._LBL_2.Location = New System.Drawing.Point(52, 99)
		Me._LBL_2.TabIndex = 17
		Me._LBL_2.BackColor = System.Drawing.Color.Transparent
		Me._LBL_2.Enabled = True
		Me._LBL_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_2.UseMnemonic = True
		Me._LBL_2.Visible = True
		Me._LBL_2.AutoSize = True
		Me._LBL_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_2.Name = "_LBL_2"
		Me.Label2.Text = "Please verify products from both locations"
		Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromARGB(192, 0, 0)
		Me.Label2.Size = New System.Drawing.Size(296, 23)
		Me.Label2.Location = New System.Drawing.Point(56, 272)
		Me.Label2.TabIndex = 14
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblPComp.Text = "Promotion Name:"
		Me.lblPComp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPComp.Size = New System.Drawing.Size(352, 24)
		Me.lblPComp.Location = New System.Drawing.Point(16, 52)
		Me.lblPComp.TabIndex = 13
		Me.lblPComp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPComp.BackColor = System.Drawing.Color.Transparent
		Me.lblPComp.Enabled = True
		Me.lblPComp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPComp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPComp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPComp.UseMnemonic = True
		Me.lblPComp.Visible = True
		Me.lblPComp.AutoSize = False
		Me.lblPComp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPComp.Name = "lblPComp"
		Me.lblSComp.Text = "Promotion Name:"
		Me.lblSComp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblSComp.Size = New System.Drawing.Size(360, 24)
		Me.lblSComp.Location = New System.Drawing.Point(16, 304)
		Me.lblSComp.TabIndex = 12
		Me.lblSComp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSComp.BackColor = System.Drawing.Color.Transparent
		Me.lblSComp.Enabled = True
		Me.lblSComp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSComp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSComp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSComp.UseMnemonic = True
		Me.lblSComp.Visible = True
		Me.lblSComp.AutoSize = False
		Me.lblSComp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSComp.Name = "lblSComp"
		Me.lblStockItemS.Text = "Label1"
		Me.lblStockItemS.Size = New System.Drawing.Size(286, 17)
		Me.lblStockItemS.Location = New System.Drawing.Point(98, 328)
		Me.lblStockItemS.TabIndex = 11
		Me.lblStockItemS.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStockItemS.BackColor = System.Drawing.SystemColors.Control
		Me.lblStockItemS.Enabled = True
		Me.lblStockItemS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblStockItemS.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStockItemS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStockItemS.UseMnemonic = True
		Me.lblStockItemS.Visible = True
		Me.lblStockItemS.AutoSize = False
		Me.lblStockItemS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblStockItemS.Name = "lblStockItemS"
		Me._LBL_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_5.Text = "Stock Item Name:"
		Me._LBL_5.Size = New System.Drawing.Size(85, 13)
		Me._LBL_5.Location = New System.Drawing.Point(10, 328)
		Me._LBL_5.TabIndex = 10
		Me._LBL_5.BackColor = System.Drawing.Color.Transparent
		Me._LBL_5.Enabled = True
		Me._LBL_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_5.UseMnemonic = True
		Me._LBL_5.Visible = True
		Me._LBL_5.AutoSize = True
		Me._LBL_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_5.Name = "_LBL_5"
		Me._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_0.Text = "Price:"
		Me._LBL_0.Size = New System.Drawing.Size(27, 13)
		Me._LBL_0.Location = New System.Drawing.Point(260, 349)
		Me._LBL_0.TabIndex = 9
		Me._LBL_0.Visible = False
		Me._LBL_0.BackColor = System.Drawing.Color.Transparent
		Me._LBL_0.Enabled = True
		Me._LBL_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_0.UseMnemonic = True
		Me._LBL_0.AutoSize = True
		Me._LBL_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_0.Name = "_LBL_0"
		Me._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_3.Text = "Price:"
		Me._LBL_3.Size = New System.Drawing.Size(27, 13)
		Me._LBL_3.Location = New System.Drawing.Point(270, 252)
		Me._LBL_3.TabIndex = 6
		Me._LBL_3.Visible = False
		Me._LBL_3.BackColor = System.Drawing.Color.Transparent
		Me._LBL_3.Enabled = True
		Me._LBL_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_3.UseMnemonic = True
		Me._LBL_3.AutoSize = True
		Me._LBL_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_3.Name = "_LBL_3"
		Me._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_1.Text = "Stock Item Name:"
		Me._LBL_1.Size = New System.Drawing.Size(85, 13)
		Me._LBL_1.Location = New System.Drawing.Point(10, 79)
		Me._LBL_1.TabIndex = 5
		Me._LBL_1.BackColor = System.Drawing.Color.Transparent
		Me._LBL_1.Enabled = True
		Me._LBL_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_1.UseMnemonic = True
		Me._LBL_1.Visible = True
		Me._LBL_1.AutoSize = True
		Me._LBL_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_1.Name = "_LBL_1"
		Me.lblStockItem.Text = "Label1"
		Me.lblStockItem.Size = New System.Drawing.Size(286, 17)
		Me.lblStockItem.Location = New System.Drawing.Point(98, 79)
		Me.lblStockItem.TabIndex = 2
		Me.lblStockItem.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStockItem.BackColor = System.Drawing.SystemColors.Control
		Me.lblStockItem.Enabled = True
		Me.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStockItem.UseMnemonic = True
		Me.lblStockItem.Visible = True
		Me.lblStockItem.AutoSize = False
		Me.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblStockItem.Name = "lblStockItem"
		Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_0.Size = New System.Drawing.Size(383, 56)
		Me._Shape1_0.Location = New System.Drawing.Point(7, 296)
		Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_0.BorderWidth = 1
		Me._Shape1_0.FillColor = System.Drawing.Color.Black
		Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_0.Visible = True
		Me._Shape1_0.Name = "_Shape1_0"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(383, 80)
		Me._Shape1_2.Location = New System.Drawing.Point(7, 48)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me.Controls.Add(txtQty)
		Me.Controls.Add(txtPSize)
		Me.Controls.Add(txtPack)
		Me.Controls.Add(txtPriceS)
		Me.Controls.Add(txtQtyT)
		Me.Controls.Add(txtPrice)
		Me.Controls.Add(cmbQuantity)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_LBL_6)
		Me.Controls.Add(_LBL_4)
		Me.Controls.Add(_LBL_2)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblPComp)
		Me.Controls.Add(lblSComp)
		Me.Controls.Add(lblStockItemS)
		Me.Controls.Add(_LBL_5)
		Me.Controls.Add(_LBL_0)
		Me.Controls.Add(_LBL_3)
		Me.Controls.Add(_LBL_1)
		Me.Controls.Add(lblStockItem)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdPack)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.LBL.SetIndex(_LBL_6, CType(6, Short))
        'Me.LBL.SetIndex(_LBL_4, CType(4, Short))
        'Me.LBL.SetIndex(_LBL_2, CType(2, Short))
        'Me.LBL.SetIndex(_LBL_5, CType(5, Short))
        'Me.LBL.SetIndex(_LBL_0, CType(0, Short))
        'Me.LBL.SetIndex(_LBL_3, CType(3, Short))
        'Me.LBL.SetIndex(_LBL_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class