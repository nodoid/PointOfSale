<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockBreak
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
	Public WithEvents cmdChild As System.Windows.Forms.Button
	Public WithEvents cmdParent As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents chkDisabled As System.Windows.Forms.CheckBox
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblChild As System.Windows.Forms.Label
	Public WithEvents lblParent As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockBreak))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdChild = New System.Windows.Forms.Button
		Me.cmdParent = New System.Windows.Forms.Button
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.chkDisabled = New System.Windows.Forms.CheckBox
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblChild = New System.Windows.Forms.Label
		Me.lblParent = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Maintain Stock Item Conversion"
		Me.ClientSize = New System.Drawing.Size(396, 129)
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
		Me.Name = "frmStockBreak"
		Me.cmdChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdChild.Text = "..."
		Me.cmdChild.Size = New System.Drawing.Size(40, 16)
		Me.cmdChild.Location = New System.Drawing.Point(348, 75)
		Me.cmdChild.TabIndex = 7
		Me.cmdChild.BackColor = System.Drawing.SystemColors.Control
		Me.cmdChild.CausesValidation = True
		Me.cmdChild.Enabled = True
		Me.cmdChild.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdChild.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdChild.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdChild.TabStop = True
		Me.cmdChild.Name = "cmdChild"
		Me.cmdParent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdParent.Text = "..."
		Me.cmdParent.Size = New System.Drawing.Size(40, 16)
		Me.cmdParent.Location = New System.Drawing.Point(348, 54)
		Me.cmdParent.TabIndex = 2
		Me.cmdParent.BackColor = System.Drawing.SystemColors.Control
		Me.cmdParent.CausesValidation = True
		Me.cmdParent.Enabled = True
		Me.cmdParent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdParent.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdParent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdParent.TabStop = True
		Me.cmdParent.Name = "cmdParent"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(396, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 9
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(73, 29)
		Me.cmdExit.Location = New System.Drawing.Point(315, 3)
		Me.cmdExit.TabIndex = 12
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
		Me.cmdCancel.TabIndex = 11
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(237, 3)
		Me.cmdPrint.TabIndex = 10
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.chkDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkDisabled.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkDisabled.Text = "Disable this Stock Item Conversion."
		Me.chkDisabled.Size = New System.Drawing.Size(187, 13)
		Me.chkDisabled.Location = New System.Drawing.Point(156, 99)
		Me.chkDisabled.TabIndex = 8
		Me.chkDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDisabled.CausesValidation = True
		Me.chkDisabled.Enabled = True
		Me.chkDisabled.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDisabled.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDisabled.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDisabled.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDisabled.TabStop = True
		Me.chkDisabled.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDisabled.Visible = True
		Me.chkDisabled.Name = "chkDisabled"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(34, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(24, 75)
		Me.txtQuantity.TabIndex = 4
		Me.txtQuantity.Text = "0"
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
		Me._lbl_2.Text = "units of "
		Me._lbl_2.Size = New System.Drawing.Size(37, 13)
		Me._lbl_2.Location = New System.Drawing.Point(63, 78)
		Me._lbl_2.TabIndex = 5
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
		Me._lbl_1.Text = "to"
		Me._lbl_1.Size = New System.Drawing.Size(9, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 78)
		Me._lbl_1.TabIndex = 3
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
		Me._lbl_0.Text = "Convert one unit of "
		Me._lbl_0.Size = New System.Drawing.Size(93, 13)
		Me._lbl_0.Location = New System.Drawing.Point(9, 57)
		Me._lbl_0.TabIndex = 0
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.lblChild.Text = "No Stock Item Selected ..."
		Me.lblChild.Size = New System.Drawing.Size(243, 17)
		Me.lblChild.Location = New System.Drawing.Point(102, 75)
		Me.lblChild.TabIndex = 6
		Me.lblChild.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblChild.BackColor = System.Drawing.SystemColors.Control
		Me.lblChild.Enabled = True
		Me.lblChild.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblChild.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblChild.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblChild.UseMnemonic = True
		Me.lblChild.Visible = True
		Me.lblChild.AutoSize = False
		Me.lblChild.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblChild.Name = "lblChild"
		Me.lblParent.Text = "No Stock Item Selected ..."
		Me.lblParent.Size = New System.Drawing.Size(243, 17)
		Me.lblParent.Location = New System.Drawing.Point(102, 54)
		Me.lblParent.TabIndex = 1
		Me.lblParent.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblParent.BackColor = System.Drawing.SystemColors.Control
		Me.lblParent.Enabled = True
		Me.lblParent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblParent.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblParent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblParent.UseMnemonic = True
		Me.lblParent.Visible = True
		Me.lblParent.AutoSize = False
		Me.lblParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblParent.Name = "lblParent"
		Me.Controls.Add(cmdChild)
		Me.Controls.Add(cmdParent)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(chkDisabled)
		Me.Controls.Add(txtQuantity)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblChild)
		Me.Controls.Add(lblParent)
		Me.picButtons.Controls.Add(cmdExit)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdPrint)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class