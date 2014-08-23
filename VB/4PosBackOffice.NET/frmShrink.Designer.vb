<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmShrink
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
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents _txtInteger_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdShrinkAdd As System.Windows.Forms.Button
	Public WithEvents _txtInteger_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_1 As System.Windows.Forms.TextBox
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShrink))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdExit = New System.Windows.Forms.Button
		Me._txtInteger_0 = New System.Windows.Forms.TextBox
		Me.cmdShrinkAdd = New System.Windows.Forms.Button
		Me._txtInteger_5 = New System.Windows.Forms.TextBox
		Me._txtInteger_4 = New System.Windows.Forms.TextBox
		Me._txtInteger_3 = New System.Windows.Forms.TextBox
		Me._txtInteger_2 = New System.Windows.Forms.TextBox
		Me._txtInteger_1 = New System.Windows.Forms.TextBox
		Me._lbl_5 = New System.Windows.Forms.Label
		Me._lbl_4 = New System.Windows.Forms.Label
		Me._lbl_3 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Add a Shrink ..."
		Me.ClientSize = New System.Drawing.Size(344, 143)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmShrink"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(240, 78)
		Me.cmdExit.TabIndex = 13
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me._txtInteger_0.AutoSize = False
		Me._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_0.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_0.Location = New System.Drawing.Point(24, 12)
		Me._txtInteger_0.TabIndex = 0
		Me._txtInteger_0.Text = "0"
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
		Me.cmdShrinkAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdShrinkAdd.Text = "Add Shrink"
		Me.cmdShrinkAdd.Size = New System.Drawing.Size(97, 19)
		Me.cmdShrinkAdd.Location = New System.Drawing.Point(240, 39)
		Me.cmdShrinkAdd.TabIndex = 11
		Me.cmdShrinkAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdShrinkAdd.CausesValidation = True
		Me.cmdShrinkAdd.Enabled = True
		Me.cmdShrinkAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdShrinkAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdShrinkAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdShrinkAdd.TabStop = True
		Me.cmdShrinkAdd.Name = "cmdShrinkAdd"
		Me._txtInteger_5.AutoSize = False
		Me._txtInteger_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_5.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_5.Location = New System.Drawing.Point(294, 12)
		Me._txtInteger_5.TabIndex = 5
		Me._txtInteger_5.Text = "0"
		Me._txtInteger_5.AcceptsReturn = True
		Me._txtInteger_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_5.CausesValidation = True
		Me._txtInteger_5.Enabled = True
		Me._txtInteger_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_5.HideSelection = True
		Me._txtInteger_5.ReadOnly = False
		Me._txtInteger_5.Maxlength = 0
		Me._txtInteger_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_5.MultiLine = False
		Me._txtInteger_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_5.TabStop = True
		Me._txtInteger_5.Visible = True
		Me._txtInteger_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_5.Name = "_txtInteger_5"
		Me._txtInteger_4.AutoSize = False
		Me._txtInteger_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_4.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_4.Location = New System.Drawing.Point(240, 12)
		Me._txtInteger_4.TabIndex = 4
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
		Me._txtInteger_3.AutoSize = False
		Me._txtInteger_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_3.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_3.Location = New System.Drawing.Point(186, 12)
		Me._txtInteger_3.TabIndex = 3
		Me._txtInteger_3.Text = "0"
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
		Me._txtInteger_2.AutoSize = False
		Me._txtInteger_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_2.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_2.Location = New System.Drawing.Point(132, 12)
		Me._txtInteger_2.TabIndex = 2
		Me._txtInteger_2.Text = "0"
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
		Me._txtInteger_2.Visible = True
		Me._txtInteger_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_2.Name = "_txtInteger_2"
		Me._txtInteger_1.AutoSize = False
		Me._txtInteger_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_1.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_1.Location = New System.Drawing.Point(78, 12)
		Me._txtInteger_1.TabIndex = 1
		Me._txtInteger_1.Text = "0"
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
		Me._lbl_5.Text = "1 X"
		Me._lbl_5.Size = New System.Drawing.Size(16, 13)
		Me._lbl_5.Location = New System.Drawing.Point(6, 15)
		Me._lbl_5.TabIndex = 12
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_4.Text = "X"
		Me._lbl_4.Size = New System.Drawing.Size(7, 13)
		Me._lbl_4.Location = New System.Drawing.Point(285, 15)
		Me._lbl_4.TabIndex = 10
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_3.Text = "X"
		Me._lbl_3.Size = New System.Drawing.Size(7, 13)
		Me._lbl_3.Location = New System.Drawing.Point(231, 15)
		Me._lbl_3.TabIndex = 9
		Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_3.BackColor = System.Drawing.Color.Transparent
		Me._lbl_3.Enabled = True
		Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_3.UseMnemonic = True
		Me._lbl_3.Visible = True
		Me._lbl_3.AutoSize = True
		Me._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_3.Name = "_lbl_3"
		Me._lbl_2.Text = "X"
		Me._lbl_2.Size = New System.Drawing.Size(7, 13)
		Me._lbl_2.Location = New System.Drawing.Point(177, 15)
		Me._lbl_2.TabIndex = 8
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
		Me._lbl_1.Text = "X"
		Me._lbl_1.Size = New System.Drawing.Size(7, 13)
		Me._lbl_1.Location = New System.Drawing.Point(123, 15)
		Me._lbl_1.TabIndex = 7
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
		Me._lbl_0.Text = "X"
		Me._lbl_0.Size = New System.Drawing.Size(7, 13)
		Me._lbl_0.Location = New System.Drawing.Point(69, 15)
		Me._lbl_0.TabIndex = 6
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
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_txtInteger_0)
		Me.Controls.Add(cmdShrinkAdd)
		Me.Controls.Add(_txtInteger_5)
		Me.Controls.Add(_txtInteger_4)
		Me.Controls.Add(_txtInteger_3)
		Me.Controls.Add(_txtInteger_2)
		Me.Controls.Add(_txtInteger_1)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(_lbl_4)
		Me.Controls.Add(_lbl_3)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_0)
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
        'Me.txtInteger.SetIndex(_txtInteger_5, CType(5, Short))
        'Me.txtInteger.SetIndex(_txtInteger_4, CType(4, Short))
        'Me.txtInteger.SetIndex(_txtInteger_3, CType(3, Short))
        'Me.txtInteger.SetIndex(_txtInteger_2, CType(2, Short))
        'Me.txtInteger.SetIndex(_txtInteger_1, CType(1, Short))
        'C() ''Type(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class