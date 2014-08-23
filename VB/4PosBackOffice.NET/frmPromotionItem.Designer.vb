<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPromotionItem
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
	Public WithEvents txtPrice As System.Windows.Forms.TextBox
	Public WithEvents cmbQuantity As System.Windows.Forms.ComboBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _LBL_3 As System.Windows.Forms.Label
	Public WithEvents _LBL_2 As System.Windows.Forms.Label
	Public WithEvents _LBL_1 As System.Windows.Forms.Label
	Public WithEvents _LBL_0 As System.Windows.Forms.Label
	Public WithEvents lblPromotion As System.Windows.Forms.Label
	Public WithEvents lblStockItem As System.Windows.Forms.Label
    'Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPromotionItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtPrice = New System.Windows.Forms.TextBox
		Me.cmbQuantity = New System.Windows.Forms.ComboBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me._LBL_3 = New System.Windows.Forms.Label
		Me._LBL_2 = New System.Windows.Forms.Label
		Me._LBL_1 = New System.Windows.Forms.Label
		Me._LBL_0 = New System.Windows.Forms.Label
		Me.lblPromotion = New System.Windows.Forms.Label
		Me.lblStockItem = New System.Windows.Forms.Label
        'Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Promotion Item"
		Me.ClientSize = New System.Drawing.Size(388, 115)
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
		Me.Name = "frmPromotionItem"
		Me.txtPrice.AutoSize = False
		Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrice.Size = New System.Drawing.Size(91, 19)
		Me.txtPrice.Location = New System.Drawing.Point(285, 81)
		Me.txtPrice.TabIndex = 5
		Me.txtPrice.Text = "0.00"
		Me.txtPrice.AcceptsReturn = True
		Me.txtPrice.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrice.CausesValidation = True
		Me.txtPrice.Enabled = True
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
		Me.cmbQuantity.Location = New System.Drawing.Point(90, 81)
		Me.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbQuantity.TabIndex = 4
		Me.cmbQuantity.BackColor = System.Drawing.SystemColors.Window
		Me.cmbQuantity.CausesValidation = True
		Me.cmbQuantity.Enabled = True
		Me.cmbQuantity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbQuantity.IntegralHeight = True
		Me.cmbQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbQuantity.Sorted = False
		Me.cmbQuantity.TabStop = True
		Me.cmbQuantity.Visible = True
		Me.cmbQuantity.Name = "cmbQuantity"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(388, 39)
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
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(303, 3)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_3.Text = "Price:"
		Me._LBL_3.Size = New System.Drawing.Size(27, 13)
		Me._LBL_3.Location = New System.Drawing.Point(254, 84)
		Me._LBL_3.TabIndex = 9
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
		Me._LBL_2.Text = "Shrink Size:"
		Me._LBL_2.Size = New System.Drawing.Size(56, 13)
		Me._LBL_2.Location = New System.Drawing.Point(31, 84)
		Me._LBL_2.TabIndex = 8
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
		Me._LBL_1.Location = New System.Drawing.Point(2, 63)
		Me._LBL_1.TabIndex = 7
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
		Me._LBL_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_0.Text = "Promotion Name:"
		Me._LBL_0.Size = New System.Drawing.Size(81, 13)
		Me._LBL_0.Location = New System.Drawing.Point(7, 45)
		Me._LBL_0.TabIndex = 6
		Me._LBL_0.BackColor = System.Drawing.Color.Transparent
		Me._LBL_0.Enabled = True
		Me._LBL_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._LBL_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._LBL_0.UseMnemonic = True
		Me._LBL_0.Visible = True
		Me._LBL_0.AutoSize = True
		Me._LBL_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._LBL_0.Name = "_LBL_0"
		Me.lblPromotion.Text = "lblPromotion"
		Me.lblPromotion.Size = New System.Drawing.Size(286, 17)
		Me.lblPromotion.Location = New System.Drawing.Point(90, 45)
		Me.lblPromotion.TabIndex = 3
		Me.lblPromotion.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPromotion.BackColor = System.Drawing.SystemColors.Control
		Me.lblPromotion.Enabled = True
		Me.lblPromotion.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPromotion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPromotion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPromotion.UseMnemonic = True
		Me.lblPromotion.Visible = True
		Me.lblPromotion.AutoSize = False
		Me.lblPromotion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPromotion.Name = "lblPromotion"
		Me.lblStockItem.Text = "Label1"
		Me.lblStockItem.Size = New System.Drawing.Size(286, 17)
		Me.lblStockItem.Location = New System.Drawing.Point(90, 63)
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
		Me.Controls.Add(txtPrice)
		Me.Controls.Add(cmbQuantity)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_LBL_3)
		Me.Controls.Add(_LBL_2)
		Me.Controls.Add(_LBL_1)
		Me.Controls.Add(_LBL_0)
		Me.Controls.Add(lblPromotion)
		Me.Controls.Add(lblStockItem)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.LBL.SetIndex(_LBL_3, CType(3, Short))
        'Me.LBL.SetIndex(_LBL_2, CType(2, Short))
        'Me.LBL.SetIndex(_LBL_1, CType(1, Short))
        'Me.LBL.SetIndex(_LBL_0, CType(0, Short))
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class