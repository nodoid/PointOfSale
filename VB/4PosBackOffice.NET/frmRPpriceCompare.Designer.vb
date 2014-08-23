<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRPpriceCompare
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
	Public WithEvents txtAbove As System.Windows.Forms.TextBox
	Public WithEvents chkAbove As System.Windows.Forms.CheckBox
	Public WithEvents txtBelow As System.Windows.Forms.TextBox
	Public WithEvents chkBelow As System.Windows.Forms.CheckBox
	Public WithEvents chkQuantity As System.Windows.Forms.CheckBox
	Public WithEvents chkDifferent As System.Windows.Forms.CheckBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdNamespace As System.Windows.Forms.Button
    Public WithEvents cmbChannel As myDataGridView
    Public WithEvents cmbShrink As myDataGridView
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRPpriceCompare))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtAbove = New System.Windows.Forms.TextBox
		Me.chkAbove = New System.Windows.Forms.CheckBox
		Me.txtBelow = New System.Windows.Forms.TextBox
		Me.chkBelow = New System.Windows.Forms.CheckBox
		Me.chkQuantity = New System.Windows.Forms.CheckBox
		Me.chkDifferent = New System.Windows.Forms.CheckBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdNamespace = New System.Windows.Forms.Button
        Me.cmbChannel = New myDataGridView
        Me.cmbShrink = New myDataGridView
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lblHeading = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmbChannel, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "Setup Price Comparison Report"
		Me.ClientSize = New System.Drawing.Size(462, 215)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmRPpriceCompare"
		Me.txtAbove.AutoSize = False
		Me.txtAbove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtAbove.Size = New System.Drawing.Size(28, 19)
		Me.txtAbove.Location = New System.Drawing.Point(252, 168)
		Me.txtAbove.TabIndex = 13
		Me.txtAbove.Text = "0"
		Me.txtAbove.AcceptsReturn = True
		Me.txtAbove.BackColor = System.Drawing.SystemColors.Window
		Me.txtAbove.CausesValidation = True
		Me.txtAbove.Enabled = True
		Me.txtAbove.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAbove.HideSelection = True
		Me.txtAbove.ReadOnly = False
		Me.txtAbove.Maxlength = 0
		Me.txtAbove.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAbove.MultiLine = False
		Me.txtAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAbove.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAbove.TabStop = True
		Me.txtAbove.Visible = True
		Me.txtAbove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtAbove.Name = "txtAbove"
		Me.chkAbove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkAbove.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkAbove.Text = "Show stock Items where exit price above"
		Me.chkAbove.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkAbove.Size = New System.Drawing.Size(217, 13)
		Me.chkAbove.Location = New System.Drawing.Point(33, 171)
		Me.chkAbove.TabIndex = 12
		Me.chkAbove.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAbove.CausesValidation = True
		Me.chkAbove.Enabled = True
		Me.chkAbove.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAbove.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAbove.TabStop = True
		Me.chkAbove.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAbove.Visible = True
		Me.chkAbove.Name = "chkAbove"
		Me.txtBelow.AutoSize = False
		Me.txtBelow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBelow.Size = New System.Drawing.Size(28, 19)
		Me.txtBelow.Location = New System.Drawing.Point(252, 189)
		Me.txtBelow.TabIndex = 10
		Me.txtBelow.Text = "0"
		Me.txtBelow.AcceptsReturn = True
		Me.txtBelow.BackColor = System.Drawing.SystemColors.Window
		Me.txtBelow.CausesValidation = True
		Me.txtBelow.Enabled = True
		Me.txtBelow.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBelow.HideSelection = True
		Me.txtBelow.ReadOnly = False
		Me.txtBelow.Maxlength = 0
		Me.txtBelow.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBelow.MultiLine = False
		Me.txtBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBelow.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBelow.TabStop = True
		Me.txtBelow.Visible = True
		Me.txtBelow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtBelow.Name = "txtBelow"
		Me.chkBelow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkBelow.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkBelow.Text = "Show stock Items where exit price below "
		Me.chkBelow.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkBelow.Size = New System.Drawing.Size(217, 13)
		Me.chkBelow.Location = New System.Drawing.Point(33, 192)
		Me.chkBelow.TabIndex = 9
		Me.chkBelow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBelow.CausesValidation = True
		Me.chkBelow.Enabled = True
		Me.chkBelow.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBelow.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBelow.TabStop = True
		Me.chkBelow.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkBelow.Visible = True
		Me.chkBelow.Name = "chkBelow"
		Me.chkQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkQuantity.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkQuantity.Text = "Show stock Items where quantity is exactly "
		Me.chkQuantity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkQuantity.Size = New System.Drawing.Size(226, 13)
		Me.chkQuantity.Location = New System.Drawing.Point(33, 141)
		Me.chkQuantity.TabIndex = 5
		Me.chkQuantity.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkQuantity.CausesValidation = True
		Me.chkQuantity.Enabled = True
		Me.chkQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkQuantity.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkQuantity.TabStop = True
		Me.chkQuantity.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkQuantity.Visible = True
		Me.chkQuantity.Name = "chkQuantity"
		Me.chkDifferent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkDifferent.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.chkDifferent.Text = "Only show stock item where prices are different"
		Me.chkDifferent.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkDifferent.Size = New System.Drawing.Size(268, 13)
		Me.chkDifferent.Location = New System.Drawing.Point(33, 111)
		Me.chkDifferent.TabIndex = 4
		Me.chkDifferent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDifferent.CausesValidation = True
		Me.chkDifferent.Enabled = True
		Me.chkDifferent.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDifferent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDifferent.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDifferent.TabStop = True
		Me.chkDifferent.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDifferent.Visible = True
		Me.chkDifferent.Name = "chkDifferent"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(363, 156)
		Me.cmdExit.TabIndex = 8
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(97, 52)
		Me.cmdPrint.Location = New System.Drawing.Point(363, 96)
		Me.cmdPrint.TabIndex = 7
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNamespace.Text = "&Filter"
		Me.cmdNamespace.Size = New System.Drawing.Size(97, 52)
		Me.cmdNamespace.Location = New System.Drawing.Point(363, 3)
		Me.cmdNamespace.TabIndex = 1
		Me.cmdNamespace.TabStop = False
		Me.cmdNamespace.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNamespace.CausesValidation = True
		Me.cmdNamespace.Enabled = True
		Me.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNamespace.Name = "cmdNamespace"
        'cmbChannel.OcxState = CType(resources.GetObject("cmbChannel.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbChannel.Size = New System.Drawing.Size(124, 21)
		Me.cmbChannel.Location = New System.Drawing.Point(153, 60)
		Me.cmbChannel.TabIndex = 3
		Me.cmbChannel.Name = "cmbChannel"
        'cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbShrink.Size = New System.Drawing.Size(67, 21)
		Me.cmbShrink.Location = New System.Drawing.Point(261, 138)
		Me.cmbShrink.TabIndex = 6
		Me.cmbShrink.Name = "cmbShrink"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "%"
		Me._lbl_2.Size = New System.Drawing.Size(11, 13)
		Me._lbl_2.Location = New System.Drawing.Point(282, 171)
		Me._lbl_2.TabIndex = 14
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
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "%"
		Me._lbl_1.Size = New System.Drawing.Size(11, 13)
		Me._lbl_1.Location = New System.Drawing.Point(282, 192)
		Me._lbl_1.TabIndex = 11
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
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Size = New System.Drawing.Size(349, 52)
		Me.lblHeading.Location = New System.Drawing.Point(3, 3)
		Me.lblHeading.TabIndex = 0
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "For which Sale Channel"
		Me._lbl_0.Size = New System.Drawing.Size(112, 13)
		Me._lbl_0.Location = New System.Drawing.Point(34, 63)
		Me._lbl_0.TabIndex = 2
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
		Me.Controls.Add(txtAbove)
		Me.Controls.Add(chkAbove)
		Me.Controls.Add(txtBelow)
		Me.Controls.Add(chkBelow)
		Me.Controls.Add(chkQuantity)
		Me.Controls.Add(chkDifferent)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(cmdNamespace)
		Me.Controls.Add(cmbChannel)
		Me.Controls.Add(cmbShrink)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(lblHeading)
		Me.Controls.Add(_lbl_0)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbChannel, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class