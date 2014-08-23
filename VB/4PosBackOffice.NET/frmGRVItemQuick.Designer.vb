<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVItemQuick
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
	Public WithEvents cmdProceed As System.Windows.Forms.Button
	Public WithEvents txtDiscountMinus As System.Windows.Forms.TextBox
	Public WithEvents txtDiscountPlus As System.Windows.Forms.TextBox
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents chkBreakPack As System.Windows.Forms.CheckBox
	Public WithEvents lblPath As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblName As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVItemQuick))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtPrice = New System.Windows.Forms.TextBox
		Me.cmdProceed = New System.Windows.Forms.Button
		Me.txtDiscountMinus = New System.Windows.Forms.TextBox
		Me.txtDiscountPlus = New System.Windows.Forms.TextBox
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me.chkBreakPack = New System.Windows.Forms.CheckBox
		Me.lblPath = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblName = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ControlBox = False
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(313, 213)
		Me.Location = New System.Drawing.Point(3, 3)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmGRVItemQuick"
		Me.txtPrice.AutoSize = False
		Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrice.Size = New System.Drawing.Size(217, 19)
		Me.txtPrice.Location = New System.Drawing.Point(85, 99)
		Me.txtPrice.TabIndex = 5
		Me.txtPrice.Text = "Text1"
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
		Me.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProceed.Text = "&Proceed"
		Me.cmdProceed.Size = New System.Drawing.Size(85, 31)
		Me.cmdProceed.Location = New System.Drawing.Point(216, 174)
		Me.cmdProceed.TabIndex = 10
		Me.cmdProceed.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProceed.CausesValidation = True
		Me.cmdProceed.Enabled = True
		Me.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProceed.TabStop = True
		Me.cmdProceed.Name = "cmdProceed"
		Me.txtDiscountMinus.AutoSize = False
		Me.txtDiscountMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtDiscountMinus.Size = New System.Drawing.Size(217, 19)
		Me.txtDiscountMinus.Location = New System.Drawing.Point(84, 147)
		Me.txtDiscountMinus.TabIndex = 9
		Me.txtDiscountMinus.Text = "Text1"
		Me.txtDiscountMinus.AcceptsReturn = True
		Me.txtDiscountMinus.BackColor = System.Drawing.SystemColors.Window
		Me.txtDiscountMinus.CausesValidation = True
		Me.txtDiscountMinus.Enabled = True
		Me.txtDiscountMinus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDiscountMinus.HideSelection = True
		Me.txtDiscountMinus.ReadOnly = False
		Me.txtDiscountMinus.Maxlength = 0
		Me.txtDiscountMinus.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDiscountMinus.MultiLine = False
		Me.txtDiscountMinus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDiscountMinus.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDiscountMinus.TabStop = True
		Me.txtDiscountMinus.Visible = True
		Me.txtDiscountMinus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDiscountMinus.Name = "txtDiscountMinus"
		Me.txtDiscountPlus.AutoSize = False
		Me.txtDiscountPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtDiscountPlus.Size = New System.Drawing.Size(217, 19)
		Me.txtDiscountPlus.Location = New System.Drawing.Point(84, 126)
		Me.txtDiscountPlus.TabIndex = 7
		Me.txtDiscountPlus.Text = "Text1"
		Me.txtDiscountPlus.AcceptsReturn = True
		Me.txtDiscountPlus.BackColor = System.Drawing.SystemColors.Window
		Me.txtDiscountPlus.CausesValidation = True
		Me.txtDiscountPlus.Enabled = True
		Me.txtDiscountPlus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDiscountPlus.HideSelection = True
		Me.txtDiscountPlus.ReadOnly = False
		Me.txtDiscountPlus.Maxlength = 0
		Me.txtDiscountPlus.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDiscountPlus.MultiLine = False
		Me.txtDiscountPlus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDiscountPlus.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDiscountPlus.TabStop = True
		Me.txtDiscountPlus.Visible = True
		Me.txtDiscountPlus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDiscountPlus.Name = "txtDiscountPlus"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(217, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(84, 78)
		Me.txtQuantity.TabIndex = 3
		Me.txtQuantity.Text = "Text1"
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
		Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantity.Name = "txtQuantity"
		Me.chkBreakPack.Text = "Break Pack"
		Me.chkBreakPack.Size = New System.Drawing.Size(286, 16)
		Me.chkBreakPack.Location = New System.Drawing.Point(12, 54)
		Me.chkBreakPack.TabIndex = 1
		Me.chkBreakPack.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBreakPack.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkBreakPack.BackColor = System.Drawing.SystemColors.Control
		Me.chkBreakPack.CausesValidation = True
		Me.chkBreakPack.Enabled = True
		Me.chkBreakPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkBreakPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBreakPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBreakPack.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBreakPack.TabStop = True
		Me.chkBreakPack.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkBreakPack.Visible = True
		Me.chkBreakPack.Name = "chkBreakPack"
		Me.lblPath.BackColor = System.Drawing.Color.Blue
		Me.lblPath.Text = "GRV Quick Edit"
		Me.lblPath.ForeColor = System.Drawing.Color.White
		Me.lblPath.Size = New System.Drawing.Size(568, 25)
		Me.lblPath.Location = New System.Drawing.Point(0, 0)
		Me.lblPath.TabIndex = 11
		Me.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPath.Enabled = True
		Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPath.UseMnemonic = True
		Me.lblPath.Visible = True
		Me.lblPath.AutoSize = False
		Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPath.Name = "lblPath"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "Price"
		Me._lbl_2.Size = New System.Drawing.Size(24, 13)
		Me._lbl_2.Location = New System.Drawing.Point(57, 102)
		Me._lbl_2.TabIndex = 4
		Me._lbl_2.BackColor = System.Drawing.SystemColors.Control
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "Surcharges"
		Me._lbl_1.Size = New System.Drawing.Size(54, 13)
		Me._lbl_1.Location = New System.Drawing.Point(24, 150)
		Me._lbl_1.TabIndex = 8
		Me._lbl_1.BackColor = System.Drawing.SystemColors.Control
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
		Me.Label1.Text = "Discount"
		Me.Label1.Size = New System.Drawing.Size(42, 13)
		Me.Label1.Location = New System.Drawing.Point(36, 129)
		Me.Label1.TabIndex = 6
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "Quantity"
		Me._lbl_0.Size = New System.Drawing.Size(39, 13)
		Me._lbl_0.Location = New System.Drawing.Point(41, 81)
		Me._lbl_0.TabIndex = 2
		Me._lbl_0.BackColor = System.Drawing.SystemColors.Control
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblName.Text = "Label1"
		Me.lblName.Size = New System.Drawing.Size(289, 16)
		Me.lblName.Location = New System.Drawing.Point(12, 33)
		Me.lblName.TabIndex = 0
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblName.BackColor = System.Drawing.SystemColors.Control
		Me.lblName.Enabled = True
		Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblName.UseMnemonic = True
		Me.lblName.Visible = True
		Me.lblName.AutoSize = False
		Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblName.Name = "lblName"
		Me.Controls.Add(txtPrice)
		Me.Controls.Add(cmdProceed)
		Me.Controls.Add(txtDiscountMinus)
		Me.Controls.Add(txtDiscountPlus)
		Me.Controls.Add(txtQuantity)
		Me.Controls.Add(chkBreakPack)
		Me.Controls.Add(lblPath)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblName)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class