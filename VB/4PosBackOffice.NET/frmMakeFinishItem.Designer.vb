<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMakeFinishItem
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
	Public WithEvents chkSaleQTY As System.Windows.Forms.CheckBox
	Public WithEvents txtQty As System.Windows.Forms.TextBox
	Public WithEvents txtPrice As System.Windows.Forms.TextBox
	Public WithEvents cmbQuantity As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents lblSaleQty As System.Windows.Forms.Label
	Public WithEvents lblPComp As System.Windows.Forms.Label
	Public WithEvents _LBL_3 As System.Windows.Forms.Label
	Public WithEvents _LBL_2 As System.Windows.Forms.Label
	Public WithEvents _LBL_1 As System.Windows.Forms.Label
	Public WithEvents lblStockItem As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMakeFinishItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.chkSaleQTY = New System.Windows.Forms.CheckBox
		Me.txtQty = New System.Windows.Forms.TextBox
		Me.txtPrice = New System.Windows.Forms.TextBox
		Me.cmbQuantity = New System.Windows.Forms.ComboBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.lblSaleQty = New System.Windows.Forms.Label
		Me.lblPComp = New System.Windows.Forms.Label
		Me._LBL_3 = New System.Windows.Forms.Label
		Me._LBL_2 = New System.Windows.Forms.Label
		Me._LBL_1 = New System.Windows.Forms.Label
		Me.lblStockItem = New System.Windows.Forms.Label
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
		Me.Text = "Make Finished Product"
		Me.ClientSize = New System.Drawing.Size(400, 152)
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
		Me.Name = "frmMakeFinishItem"
		Me.chkSaleQTY.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkSaleQTY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkSaleQTY.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.chkSaleQTY.Text = "Apply Sales Qty:"
		Me.chkSaleQTY.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkSaleQTY.Size = New System.Drawing.Size(102, 19)
		Me.chkSaleQTY.Location = New System.Drawing.Point(16, 120)
		Me.chkSaleQTY.TabIndex = 11
		Me.chkSaleQTY.CausesValidation = True
		Me.chkSaleQTY.Enabled = True
		Me.chkSaleQTY.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSaleQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSaleQTY.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSaleQTY.TabStop = True
		Me.chkSaleQTY.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSaleQTY.Visible = True
		Me.chkSaleQTY.Name = "chkSaleQTY"
		Me.txtQty.AutoSize = False
		Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQty.Size = New System.Drawing.Size(67, 19)
		Me.txtQty.Location = New System.Drawing.Point(104, 97)
		Me.txtQty.TabIndex = 8
		Me.txtQty.Text = "0"
		Me.txtQty.AcceptsReturn = True
		Me.txtQty.BackColor = System.Drawing.SystemColors.Window
		Me.txtQty.CausesValidation = True
		Me.txtQty.Enabled = True
		Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQty.HideSelection = True
		Me.txtQty.ReadOnly = False
		Me.txtQty.Maxlength = 0
		Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQty.MultiLine = False
		Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQty.TabStop = True
		Me.txtQty.Visible = True
		Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQty.Name = "txtQty"
		Me.txtPrice.AutoSize = False
		Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrice.Enabled = False
		Me.txtPrice.Size = New System.Drawing.Size(91, 19)
		Me.txtPrice.Location = New System.Drawing.Point(293, 97)
		Me.txtPrice.TabIndex = 4
		Me.txtPrice.Text = "0.00"
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
		Me.txtPrice.Visible = True
		Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrice.Name = "txtPrice"
		Me.cmbQuantity.Size = New System.Drawing.Size(79, 21)
		Me.cmbQuantity.Location = New System.Drawing.Point(184, 96)
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
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(8, 3)
		Me.cmdCancel.TabIndex = 10
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
		Me.lblSaleQty.Text = "[ 0 ]"
		Me.lblSaleQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblSaleQty.Size = New System.Drawing.Size(256, 20)
		Me.lblSaleQty.Location = New System.Drawing.Point(128, 122)
		Me.lblSaleQty.TabIndex = 12
		Me.lblSaleQty.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSaleQty.BackColor = System.Drawing.Color.Transparent
		Me.lblSaleQty.Enabled = True
		Me.lblSaleQty.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSaleQty.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSaleQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSaleQty.UseMnemonic = True
		Me.lblSaleQty.Visible = True
		Me.lblSaleQty.AutoSize = False
		Me.lblSaleQty.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSaleQty.Name = "lblSaleQty"
		Me.lblPComp.Text = "Please enter the Qty you wish to make:"
		Me.lblPComp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPComp.Size = New System.Drawing.Size(352, 20)
		Me.lblPComp.Location = New System.Drawing.Point(10, 56)
		Me.lblPComp.TabIndex = 9
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
		Me._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_3.Text = "Price:"
		Me._LBL_3.Size = New System.Drawing.Size(27, 13)
		Me._LBL_3.Location = New System.Drawing.Point(262, 100)
		Me._LBL_3.TabIndex = 7
		Me._LBL_3.BackColor = System.Drawing.Color.Transparent
		Me._LBL_3.Enabled = True
		Me._LBL_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_3.UseMnemonic = True
		Me._LBL_3.Visible = True
		Me._LBL_3.AutoSize = True
		Me._LBL_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_3.Name = "_LBL_3"
		Me._LBL_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_2.Text = "Item Qty:"
		Me._LBL_2.Size = New System.Drawing.Size(42, 13)
		Me._LBL_2.Location = New System.Drawing.Point(53, 100)
		Me._LBL_2.TabIndex = 6
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
		Me.lblStockItem.Size = New System.Drawing.Size(278, 17)
		Me.lblStockItem.Location = New System.Drawing.Point(105, 79)
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
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(383, 96)
		Me._Shape1_2.Location = New System.Drawing.Point(7, 48)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me.Controls.Add(chkSaleQTY)
		Me.Controls.Add(txtQty)
		Me.Controls.Add(txtPrice)
		Me.Controls.Add(cmbQuantity)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(lblSaleQty)
		Me.Controls.Add(lblPComp)
		Me.Controls.Add(_LBL_3)
		Me.Controls.Add(_LBL_2)
		Me.Controls.Add(_LBL_1)
		Me.Controls.Add(lblStockItem)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.LBL.SetIndex(_LBL_3, CType(3, Short))
        'Me.LBL.SetIndex(_LBL_2, CType(2, Short))
        'Me.LBL.SetIndex(_LBL_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class