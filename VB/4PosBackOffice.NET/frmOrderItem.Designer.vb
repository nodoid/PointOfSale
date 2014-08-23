<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOrderItem
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
	Public WithEvents _txtEdit_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdPriceBOM As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdStockItem As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdPack As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents lblBrokenPack As System.Windows.Forms.Label
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_10 As System.Windows.Forms.Label
	Public WithEvents _lbl_9 As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents lblQuantity As System.Windows.Forms.Label
	Public WithEvents lblDeposit As System.Windows.Forms.Label
	Public WithEvents lblContent As System.Windows.Forms.Label
	Public WithEvents frmTotals As System.Windows.Forms.GroupBox
	Public WithEvents lblSupplier As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents _txtEdit_0 As System.Windows.Forms.TextBox
	Public WithEvents gridItem As myDataGridView
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents lstWorkspace As System.Windows.Forms.ListBox
	Public WithEvents _lbl_7 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtEdit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._txtEdit_1 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdPriceBOM = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.cmdStockItem = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdPack = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.frmTotals = New System.Windows.Forms.GroupBox
		Me._lbl_2 = New System.Windows.Forms.Label
		Me.lblBrokenPack = New System.Windows.Forms.Label
		Me.lblTotal = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_10 = New System.Windows.Forms.Label
		Me._lbl_9 = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me.lblQuantity = New System.Windows.Forms.Label
		Me.lblDeposit = New System.Windows.Forms.Label
		Me.lblContent = New System.Windows.Forms.Label
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.lblSupplier = New System.Windows.Forms.Label
		Me._txtEdit_0 = New System.Windows.Forms.TextBox
		Me.gridItem = New myDataGridView
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.lstWorkspace = New System.Windows.Forms.ListBox
		Me._lbl_7 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtEdit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.picButtons.SuspendLayout()
		Me.frmTotals.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "Order Form"
		Me.ClientSize = New System.Drawing.Size(592, 547)
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
		Me.Name = "frmOrderItem"
		Me._txtEdit_1.AutoSize = False
		Me._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_1.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_1.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_1.Location = New System.Drawing.Point(376, 136)
		Me._txtEdit_1.TabIndex = 27
		Me._txtEdit_1.Tag = "0"
		Me._txtEdit_1.Text = "0"
		Me._txtEdit_1.Visible = False
		Me._txtEdit_1.AcceptsReturn = True
		Me._txtEdit_1.CausesValidation = True
		Me._txtEdit_1.Enabled = True
		Me._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_1.HideSelection = True
		Me._txtEdit_1.ReadOnly = False
		Me._txtEdit_1.Maxlength = 0
		Me._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_1.MultiLine = False
		Me._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_1.TabStop = True
		Me._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_1.Name = "_txtEdit_1"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(592, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 19
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdPriceBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPriceBOM.Text = "Change &BOM Price"
		Me.cmdPriceBOM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPriceBOM.Size = New System.Drawing.Size(123, 28)
		Me.cmdPriceBOM.Location = New System.Drawing.Point(432, 3)
		Me.cmdPriceBOM.TabIndex = 28
		Me.cmdPriceBOM.TabStop = False
		Me.cmdPriceBOM.Tag = "0"
		Me.cmdPriceBOM.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPriceBOM.CausesValidation = True
		Me.cmdPriceBOM.Enabled = True
		Me.cmdPriceBOM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPriceBOM.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPriceBOM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPriceBOM.Name = "cmdPriceBOM"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(73, 28)
		Me.cmdExit.Location = New System.Drawing.Point(717, 3)
		Me.cmdExit.TabIndex = 26
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
		Me.cmdNext.Size = New System.Drawing.Size(73, 28)
		Me.cmdNext.Location = New System.Drawing.Point(669, 3)
		Me.cmdNext.TabIndex = 25
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
		Me.cmdBack.Size = New System.Drawing.Size(73, 28)
		Me.cmdBack.Location = New System.Drawing.Point(570, 3)
		Me.cmdBack.TabIndex = 24
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
		Me.cmdStockItem.Size = New System.Drawing.Size(97, 28)
		Me.cmdStockItem.Location = New System.Drawing.Point(0, 3)
		Me.cmdStockItem.TabIndex = 23
		Me.cmdStockItem.TabStop = False
		Me.cmdStockItem.Tag = "0"
		Me.cmdStockItem.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStockItem.CausesValidation = True
		Me.cmdStockItem.Enabled = True
		Me.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStockItem.Name = "cmdStockItem"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Edit Stock Item"
		Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdEdit.Size = New System.Drawing.Size(103, 28)
		Me.cmdEdit.Location = New System.Drawing.Point(324, 3)
		Me.cmdEdit.TabIndex = 22
		Me.cmdEdit.TabStop = False
		Me.cmdEdit.Tag = "0"
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPack.Text = "Break / Build P&ack"
		Me.cmdPack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPack.Size = New System.Drawing.Size(124, 28)
		Me.cmdPack.Location = New System.Drawing.Point(195, 3)
		Me.cmdPack.TabIndex = 21
		Me.cmdPack.TabStop = False
		Me.cmdPack.Tag = "0"
		Me.cmdPack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPack.CausesValidation = True
		Me.cmdPack.Enabled = True
		Me.cmdPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPack.Name = "cmdPack"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "Dele&te"
		Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdDelete.Size = New System.Drawing.Size(73, 28)
		Me.cmdDelete.Location = New System.Drawing.Point(117, 3)
		Me.cmdDelete.TabIndex = 20
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.Tag = "0"
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.frmTotals.Text = "Sub Totals"
		Me.frmTotals.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmTotals.Size = New System.Drawing.Size(457, 58)
		Me.frmTotals.Location = New System.Drawing.Point(219, 366)
		Me.frmTotals.TabIndex = 8
		Me.frmTotals.BackColor = System.Drawing.SystemColors.Control
		Me.frmTotals.Enabled = True
		Me.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmTotals.Visible = True
		Me.frmTotals.Padding = New System.Windows.Forms.Padding(0)
		Me.frmTotals.Name = "frmTotals"
		Me._lbl_2.Text = "Broken Packs"
		Me._lbl_2.Size = New System.Drawing.Size(67, 13)
		Me._lbl_2.Location = New System.Drawing.Point(78, 15)
		Me._lbl_2.TabIndex = 18
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
		Me.lblBrokenPack.TabIndex = 17
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
		Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotal.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblTotal.Text = "0.00"
		Me.lblTotal.Size = New System.Drawing.Size(91, 17)
		Me.lblTotal.Location = New System.Drawing.Point(357, 27)
		Me.lblTotal.TabIndex = 16
		Me.lblTotal.Enabled = True
		Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotal.UseMnemonic = True
		Me.lblTotal.Visible = True
		Me.lblTotal.AutoSize = False
		Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotal.Name = "lblTotal"
		Me._lbl_1.Text = "Total Value"
		Me._lbl_1.Size = New System.Drawing.Size(91, 13)
		Me._lbl_1.Location = New System.Drawing.Point(358, 15)
		Me._lbl_1.TabIndex = 15
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_10.Text = "Contents Value"
		Me._lbl_10.Size = New System.Drawing.Size(91, 13)
		Me._lbl_10.Location = New System.Drawing.Point(256, 15)
		Me._lbl_10.TabIndex = 14
		Me._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_9.Text = "Deposit Value"
		Me._lbl_9.Size = New System.Drawing.Size(91, 13)
		Me._lbl_9.Location = New System.Drawing.Point(163, 15)
		Me._lbl_9.TabIndex = 13
		Me._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_8.Text = "No Of Cases"
		Me._lbl_8.Size = New System.Drawing.Size(60, 13)
		Me._lbl_8.Location = New System.Drawing.Point(9, 15)
		Me._lbl_8.TabIndex = 12
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
		Me.lblQuantity.TabIndex = 11
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
		Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDeposit.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblDeposit.Text = "0.00"
		Me.lblDeposit.Size = New System.Drawing.Size(91, 17)
		Me.lblDeposit.Location = New System.Drawing.Point(162, 27)
		Me.lblDeposit.TabIndex = 10
		Me.lblDeposit.Enabled = True
		Me.lblDeposit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDeposit.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDeposit.UseMnemonic = True
		Me.lblDeposit.Visible = True
		Me.lblDeposit.AutoSize = False
		Me.lblDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDeposit.Name = "lblDeposit"
		Me.lblContent.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContent.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblContent.Text = "0.00"
		Me.lblContent.Size = New System.Drawing.Size(91, 17)
		Me.lblContent.Location = New System.Drawing.Point(255, 27)
		Me.lblContent.TabIndex = 9
		Me.lblContent.Enabled = True
		Me.lblContent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContent.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContent.UseMnemonic = True
		Me.lblContent.Visible = True
		Me.lblContent.AutoSize = False
		Me.lblContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContent.Name = "lblContent"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.Picture1.ForeColor = System.Drawing.Color.White
		Me.Picture1.Size = New System.Drawing.Size(592, 25)
		Me.Picture1.Location = New System.Drawing.Point(0, 38)
		Me.Picture1.TabIndex = 6
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.lblSupplier.Text = "lblSupplier"
		Me.lblSupplier.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblSupplier.ForeColor = System.Drawing.Color.Black
		Me.lblSupplier.Size = New System.Drawing.Size(85, 20)
		Me.lblSupplier.Location = New System.Drawing.Point(0, 0)
		Me.lblSupplier.TabIndex = 7
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
		Me._txtEdit_0.Location = New System.Drawing.Point(279, 120)
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
		Me._txtEdit_0.Maxlength = 0
		Me._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_0.MultiLine = False
		Me._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_0.TabStop = True
		Me._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_0.Name = "_txtEdit_0"
        'gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridItem.Size = New System.Drawing.Size(493, 355)
		Me.gridItem.Location = New System.Drawing.Point(195, 63)
		Me.gridItem.TabIndex = 5
		Me.gridItem.Name = "gridItem"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(142, 19)
		Me.txtSearch.Location = New System.Drawing.Point(45, 81)
		Me.txtSearch.TabIndex = 1
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
		Me.lstWorkspace.Size = New System.Drawing.Size(187, 358)
		Me.lstWorkspace.Location = New System.Drawing.Point(0, 102)
		Me.lstWorkspace.TabIndex = 2
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
		Me.lstWorkspace.TabStop = True
		Me.lstWorkspace.Visible = True
		Me.lstWorkspace.MultiColumn = False
		Me.lstWorkspace.Name = "lstWorkspace"
		Me._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_7.Text = "&Search"
		Me._lbl_7.Size = New System.Drawing.Size(34, 13)
		Me._lbl_7.Location = New System.Drawing.Point(6, 84)
		Me._lbl_7.TabIndex = 0
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
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lbl_0.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me._lbl_0.Text = "Stock Item Selector"
		Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_0.ForeColor = System.Drawing.Color.White
		Me._lbl_0.Size = New System.Drawing.Size(190, 16)
		Me._lbl_0.Location = New System.Drawing.Point(0, 63)
		Me._lbl_0.TabIndex = 4
		Me._lbl_0.Enabled = True
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = False
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._lbl_0.Name = "_lbl_0"
		Me.Controls.Add(_txtEdit_1)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(frmTotals)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(_txtEdit_0)
		Me.Controls.Add(gridItem)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(lstWorkspace)
		Me.Controls.Add(_lbl_7)
		Me.Controls.Add(_lbl_0)
		Me.picButtons.Controls.Add(cmdPriceBOM)
		Me.picButtons.Controls.Add(cmdExit)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdBack)
		Me.picButtons.Controls.Add(cmdStockItem)
		Me.picButtons.Controls.Add(cmdEdit)
		Me.picButtons.Controls.Add(cmdPack)
		Me.picButtons.Controls.Add(cmdDelete)
		Me.frmTotals.Controls.Add(_lbl_2)
		Me.frmTotals.Controls.Add(lblBrokenPack)
		Me.frmTotals.Controls.Add(lblTotal)
		Me.frmTotals.Controls.Add(_lbl_1)
		Me.frmTotals.Controls.Add(_lbl_10)
		Me.frmTotals.Controls.Add(_lbl_9)
		Me.frmTotals.Controls.Add(_lbl_8)
		Me.frmTotals.Controls.Add(lblQuantity)
		Me.frmTotals.Controls.Add(lblDeposit)
		Me.frmTotals.Controls.Add(lblContent)
		Me.Picture1.Controls.Add(lblSupplier)
		Me.lbl.SetIndex(_lbl_2, CType(2, Short))
		Me.lbl.SetIndex(_lbl_1, CType(1, Short))
		Me.lbl.SetIndex(_lbl_10, CType(10, Short))
		Me.lbl.SetIndex(_lbl_9, CType(9, Short))
		Me.lbl.SetIndex(_lbl_8, CType(8, Short))
		Me.lbl.SetIndex(_lbl_7, CType(7, Short))
		Me.lbl.SetIndex(_lbl_0, CType(0, Short))
		Me.txtEdit.SetIndex(_txtEdit_1, CType(1, Short))
		Me.txtEdit.SetIndex(_txtEdit_0, CType(0, Short))
		CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.frmTotals.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class