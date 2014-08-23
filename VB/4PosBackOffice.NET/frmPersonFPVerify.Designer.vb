<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPersonFPVerify
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
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents eName As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPersonFPVerify))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdExit = New System.Windows.Forms.Button
		Me.eName = New System.Windows.Forms.TextBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Verify Form"
		Me.ClientSize = New System.Drawing.Size(271, 251)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmPersonFPVerify"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(271, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 5
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
		Me.cmdExit.Location = New System.Drawing.Point(184, 3)
		Me.cmdExit.TabIndex = 6
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.eName.AutoSize = False
		Me.eName.BackColor = System.Drawing.Color.Blue
		Me.eName.ForeColor = System.Drawing.Color.White
		Me.eName.Size = New System.Drawing.Size(257, 17)
		Me.eName.Location = New System.Drawing.Point(8, 48)
		Me.eName.ReadOnly = True
		Me.eName.TabIndex = 4
		Me.eName.Text = "name"
		Me.eName.AcceptsReturn = True
		Me.eName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.eName.CausesValidation = True
		Me.eName.Enabled = True
		Me.eName.HideSelection = True
		Me.eName.Maxlength = 0
		Me.eName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.eName.MultiLine = False
		Me.eName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.eName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.eName.TabStop = True
		Me.eName.Visible = True
		Me.eName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.eName.Name = "eName"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Verify Again ?"
		Me.Command1.Size = New System.Drawing.Size(113, 41)
		Me.Command1.Location = New System.Drawing.Point(152, 200)
		Me.Command1.TabIndex = 1
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Picture1.Size = New System.Drawing.Size(129, 161)
		Me.Picture1.Location = New System.Drawing.Point(8, 80)
		Me.Picture1.TabIndex = 0
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.BackColor = System.Drawing.SystemColors.Control
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.label2.Text = "Name"
		Me.label2.Size = New System.Drawing.Size(41, 17)
		Me.label2.Location = New System.Drawing.Point(80, 160)
		Me.label2.TabIndex = 3
		Me.label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label2.BackColor = System.Drawing.SystemColors.Control
		Me.label2.Enabled = True
		Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label2.UseMnemonic = True
		Me.label2.Visible = True
		Me.label2.AutoSize = False
		Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label2.Name = "label2"
		Me.Label1.Text = "Please put your finger on the sensor ..."
		Me.Label1.ForeColor = System.Drawing.Color.Red
		Me.Label1.Size = New System.Drawing.Size(105, 105)
		Me.Label1.Location = New System.Drawing.Point(152, 80)
		Me.Label1.TabIndex = 2
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(eName)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(label2)
		Me.Controls.Add(Label1)
		Me.picButtons.Controls.Add(cmdExit)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class