<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmIncrementQuantity
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
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents txtPrice As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
	Public WithEvents _LBL_3 As System.Windows.Forms.Label
	Public WithEvents _LBL_1 As System.Windows.Forms.Label
	Public WithEvents lblStockItem As System.Windows.Forms.Label
    'Public WithEvents LBL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIncrementQuantity))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me.txtPrice = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me._lblLabels_9 = New System.Windows.Forms.Label
		Me._LBL_3 = New System.Windows.Forms.Label
		Me._LBL_1 = New System.Windows.Forms.Label
		Me.lblStockItem = New System.Windows.Forms.Label
        'Me.LBL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Increment Quantity"
		Me.ClientSize = New System.Drawing.Size(388, 94)
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
		Me.Name = "frmIncrementQuantity"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(43, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(88, 66)
		Me.txtQuantity.TabIndex = 6
		Me.txtQuantity.Text = "999"
		Me.txtQuantity.AcceptsReturn = True
		Me.txtQuantity.BackColor = System.Drawing.SystemColors.Window
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
		Me.txtQuantity.Visible = True
		Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtQuantity.Name = "txtQuantity"
		Me.txtPrice.AutoSize = False
		Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrice.Size = New System.Drawing.Size(91, 19)
		Me.txtPrice.Location = New System.Drawing.Point(285, 66)
		Me.txtPrice.TabIndex = 3
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
		Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtPrice.Name = "txtPrice"
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
		Me._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_9.Text = "Shrink Size:"
		Me._lblLabels_9.Size = New System.Drawing.Size(56, 13)
		Me._lblLabels_9.Location = New System.Drawing.Point(27, 69)
		Me._lblLabels_9.TabIndex = 7
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
		Me._LBL_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_3.Text = "Price:"
		Me._LBL_3.Size = New System.Drawing.Size(27, 13)
		Me._LBL_3.Location = New System.Drawing.Point(254, 69)
		Me._LBL_3.TabIndex = 5
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
		Me._LBL_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._LBL_1.Text = "Increment Name:"
		Me._LBL_1.Size = New System.Drawing.Size(81, 13)
		Me._LBL_1.Location = New System.Drawing.Point(6, 45)
		Me._LBL_1.TabIndex = 4
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
		Me.lblStockItem.Location = New System.Drawing.Point(90, 45)
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
		Me.Controls.Add(txtQuantity)
		Me.Controls.Add(txtPrice)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_lblLabels_9)
		Me.Controls.Add(_LBL_3)
		Me.Controls.Add(_LBL_1)
		Me.Controls.Add(lblStockItem)
		Me.picButtons.Controls.Add(cmdClose)
        ''Me.LBL.SetIndex(_LBL_3, CType(3, Short))
        'Me.LBL.SetIndex(_LBL_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.LBL, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class