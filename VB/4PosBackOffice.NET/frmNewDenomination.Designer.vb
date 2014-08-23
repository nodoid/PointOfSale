<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNewDenomination
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
	Public WithEvents txtUnit As System.Windows.Forms.TextBox
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents _optCoin_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optCoin_0 As System.Windows.Forms.RadioButton
	Public WithEvents txtPack As System.Windows.Forms.TextBox
	Public WithEvents txtName As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents optCoin As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNewDenomination))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtUnit = New System.Windows.Forms.TextBox
		Me.Check1 = New System.Windows.Forms.CheckBox
		Me._optCoin_1 = New System.Windows.Forms.RadioButton
		Me._optCoin_0 = New System.Windows.Forms.RadioButton
		Me.txtPack = New System.Windows.Forms.TextBox
		Me.txtName = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
        'Me.optCoin = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.optCoin, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "New Denomination"
		Me.ClientSize = New System.Drawing.Size(234, 157)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmNewDenomination"
		Me.txtUnit.AutoSize = False
		Me.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtUnit.Size = New System.Drawing.Size(81, 19)
		Me.txtUnit.Location = New System.Drawing.Point(146, 66)
		Me.txtUnit.TabIndex = 1
		Me.txtUnit.Text = "0"
		Me.txtUnit.AcceptsReturn = True
		Me.txtUnit.BackColor = System.Drawing.SystemColors.Window
		Me.txtUnit.CausesValidation = True
		Me.txtUnit.Enabled = True
		Me.txtUnit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtUnit.HideSelection = True
		Me.txtUnit.ReadOnly = False
		Me.txtUnit.Maxlength = 0
		Me.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUnit.MultiLine = False
		Me.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUnit.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUnit.TabStop = True
		Me.txtUnit.Visible = True
		Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtUnit.Name = "txtUnit"
		Me.Check1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Check1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Check1.BackColor = System.Drawing.SystemColors.ScrollBar
		Me.Check1.Text = "Disable Denominations"
		Me.Check1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Check1.Size = New System.Drawing.Size(223, 17)
		Me.Check1.Location = New System.Drawing.Point(2, 134)
		Me.Check1.TabIndex = 10
		Me.Check1.CausesValidation = True
		Me.Check1.Enabled = True
		Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Check1.Appearance = System.Windows.Forms.Appearance.Normal
		Me.Check1.TabStop = True
		Me.Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.Check1.Visible = True
		Me.Check1.Name = "Check1"
		Me._optCoin_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCoin_1.BackColor = System.Drawing.SystemColors.ScrollBar
		Me._optCoin_1.Text = "Note"
		Me._optCoin_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._optCoin_1.Size = New System.Drawing.Size(59, 15)
		Me._optCoin_1.Location = New System.Drawing.Point(166, 114)
		Me._optCoin_1.TabIndex = 9
		Me._optCoin_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCoin_1.CausesValidation = True
		Me._optCoin_1.Enabled = True
		Me._optCoin_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCoin_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCoin_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCoin_1.TabStop = True
		Me._optCoin_1.Checked = False
		Me._optCoin_1.Visible = True
		Me._optCoin_1.Name = "_optCoin_1"
		Me._optCoin_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCoin_0.BackColor = System.Drawing.SystemColors.ScrollBar
		Me._optCoin_0.Text = "Coin"
		Me._optCoin_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._optCoin_0.Size = New System.Drawing.Size(51, 15)
		Me._optCoin_0.Location = New System.Drawing.Point(94, 114)
		Me._optCoin_0.TabIndex = 8
		Me._optCoin_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCoin_0.CausesValidation = True
		Me._optCoin_0.Enabled = True
		Me._optCoin_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCoin_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCoin_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCoin_0.TabStop = True
		Me._optCoin_0.Checked = False
		Me._optCoin_0.Visible = True
		Me._optCoin_0.Name = "_optCoin_0"
		Me.txtPack.AutoSize = False
		Me.txtPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPack.Size = New System.Drawing.Size(81, 17)
		Me.txtPack.Location = New System.Drawing.Point(146, 92)
		Me.txtPack.TabIndex = 2
		Me.txtPack.Text = "0"
		Me.txtPack.AcceptsReturn = True
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
		Me.txtPack.Visible = True
		Me.txtPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtPack.Name = "txtPack"
		Me.txtName.AutoSize = False
		Me.txtName.Size = New System.Drawing.Size(137, 17)
		Me.txtName.Location = New System.Drawing.Point(92, 44)
		Me.txtName.TabIndex = 0
		Me.txtName.AcceptsReturn = True
		Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtName.BackColor = System.Drawing.SystemColors.Window
		Me.txtName.CausesValidation = True
		Me.txtName.Enabled = True
		Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtName.HideSelection = True
		Me.txtName.ReadOnly = False
		Me.txtName.Maxlength = 0
		Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtName.MultiLine = False
		Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtName.TabStop = True
		Me.txtName.Visible = True
		Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtName.Name = "txtName"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(234, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 3
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "&Undo"
		Me.Command2.Size = New System.Drawing.Size(85, 25)
		Me.Command2.Location = New System.Drawing.Point(4, 4)
		Me.Command2.TabIndex = 12
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "E&xit"
		Me.Command1.Size = New System.Drawing.Size(87, 25)
		Me.Command1.Location = New System.Drawing.Point(140, 4)
		Me.Command1.TabIndex = 4
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Label4.Text = "Unit/Amount:"
		Me.Label4.Size = New System.Drawing.Size(77, 15)
		Me.Label4.Location = New System.Drawing.Point(4, 68)
		Me.Label4.TabIndex = 11
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Type :"
		Me.Label3.Size = New System.Drawing.Size(83, 15)
		Me.Label3.Location = New System.Drawing.Point(4, 114)
		Me.Label3.TabIndex = 7
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Pack :"
		Me.Label2.Size = New System.Drawing.Size(83, 15)
		Me.Label2.Location = New System.Drawing.Point(4, 94)
		Me.Label2.TabIndex = 6
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Name :"
		Me.Label1.Size = New System.Drawing.Size(83, 15)
		Me.Label1.Location = New System.Drawing.Point(4, 46)
		Me.Label1.TabIndex = 5
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(txtUnit)
		Me.Controls.Add(Check1)
		Me.Controls.Add(_optCoin_1)
		Me.Controls.Add(_optCoin_0)
		Me.Controls.Add(txtPack)
		Me.Controls.Add(txtName)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.picButtons.Controls.Add(Command2)
		Me.picButtons.Controls.Add(Command1)
        'Me.optCoin.SetIndex(_optCoin_1, CType(1, Short))
        'Me.optCoin.SetIndex(_optCoin_0, CType(0, Short))
        'CType(Me.optCoin, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class