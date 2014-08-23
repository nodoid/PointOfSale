<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPersonFPRegOT
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
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents eName As System.Windows.Forms.TextBox
	Public WithEvents HiddenPict As System.Windows.Forms.PictureBox
	Public WithEvents Status As System.Windows.Forms.ListBox
	Public WithEvents Close_Renamed As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents Samples As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Prompt As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPersonFPRegOT))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdExit = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.eName = New System.Windows.Forms.TextBox
		Me.HiddenPict = New System.Windows.Forms.PictureBox
		Me.Status = New System.Windows.Forms.ListBox
		Me.Close_Renamed = New System.Windows.Forms.Button
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.Samples = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Prompt = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Registration Form"
		Me.ClientSize = New System.Drawing.Size(521, 311)
		Me.Location = New System.Drawing.Point(3, 29)
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
		Me.Name = "frmPersonFPRegOT"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(521, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 10
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
		Me.cmdExit.Location = New System.Drawing.Point(432, 3)
		Me.cmdExit.TabIndex = 11
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.Label4.Text = "Registration Form"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(313, 25)
		Me.Label4.Location = New System.Drawing.Point(8, 8)
		Me.Label4.TabIndex = 12
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.eName.AutoSize = False
		Me.eName.BackColor = System.Drawing.Color.Blue
		Me.eName.ForeColor = System.Drawing.Color.White
		Me.eName.Size = New System.Drawing.Size(489, 17)
		Me.eName.Location = New System.Drawing.Point(16, 48)
		Me.eName.ReadOnly = True
		Me.eName.TabIndex = 9
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
		Me.HiddenPict.Size = New System.Drawing.Size(41, 33)
		Me.HiddenPict.Location = New System.Drawing.Point(224, 328)
		Me.HiddenPict.TabIndex = 8
		Me.HiddenPict.Visible = False
		Me.HiddenPict.Dock = System.Windows.Forms.DockStyle.None
		Me.HiddenPict.BackColor = System.Drawing.SystemColors.Control
		Me.HiddenPict.CausesValidation = True
		Me.HiddenPict.Enabled = True
		Me.HiddenPict.ForeColor = System.Drawing.SystemColors.ControlText
		Me.HiddenPict.Cursor = System.Windows.Forms.Cursors.Default
		Me.HiddenPict.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HiddenPict.TabStop = True
		Me.HiddenPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.HiddenPict.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.HiddenPict.Name = "HiddenPict"
		Me.Status.Size = New System.Drawing.Size(289, 176)
		Me.Status.Location = New System.Drawing.Point(216, 128)
		Me.Status.TabIndex = 6
		Me.Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Status.BackColor = System.Drawing.SystemColors.Window
		Me.Status.CausesValidation = True
		Me.Status.Enabled = True
		Me.Status.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Status.IntegralHeight = True
		Me.Status.Cursor = System.Windows.Forms.Cursors.Default
		Me.Status.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.Status.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Status.Sorted = False
		Me.Status.TabStop = True
		Me.Status.Visible = True
		Me.Status.MultiColumn = False
		Me.Status.Name = "Status"
		Me.Close_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Close_Renamed.Text = "Close"
		Me.Close_Renamed.Size = New System.Drawing.Size(81, 25)
		Me.Close_Renamed.Location = New System.Drawing.Point(416, 320)
		Me.Close_Renamed.TabIndex = 4
		Me.Close_Renamed.Visible = False
		Me.Close_Renamed.BackColor = System.Drawing.SystemColors.Control
		Me.Close_Renamed.CausesValidation = True
		Me.Close_Renamed.Enabled = True
		Me.Close_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Close_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.Close_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Close_Renamed.TabStop = True
		Me.Close_Renamed.Name = "Close_Renamed"
		Me.Picture1.Size = New System.Drawing.Size(185, 185)
		Me.Picture1.Location = New System.Drawing.Point(16, 72)
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
		Me.Samples.Size = New System.Drawing.Size(41, 25)
		Me.Samples.Location = New System.Drawing.Point(160, 272)
		Me.Samples.TabIndex = 7
		Me.Samples.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Samples.BackColor = System.Drawing.SystemColors.Control
		Me.Samples.Enabled = True
		Me.Samples.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Samples.Cursor = System.Windows.Forms.Cursors.Default
		Me.Samples.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Samples.UseMnemonic = True
		Me.Samples.Visible = True
		Me.Samples.AutoSize = False
		Me.Samples.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Samples.Name = "Samples"
		Me.Label3.Text = "Fingerprint samples needed:"
		Me.Label3.Size = New System.Drawing.Size(145, 25)
		Me.Label3.Location = New System.Drawing.Point(16, 272)
		Me.Label3.TabIndex = 5
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Status:"
		Me.Label2.Size = New System.Drawing.Size(177, 17)
		Me.Label2.Location = New System.Drawing.Point(216, 112)
		Me.Label2.TabIndex = 3
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Prompt.Text = "Touch the fingerprint reader."
		Me.Prompt.Size = New System.Drawing.Size(289, 17)
		Me.Prompt.Location = New System.Drawing.Point(216, 88)
		Me.Prompt.TabIndex = 2
		Me.Prompt.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Prompt.BackColor = System.Drawing.SystemColors.Control
		Me.Prompt.Enabled = True
		Me.Prompt.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Prompt.Cursor = System.Windows.Forms.Cursors.Default
		Me.Prompt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Prompt.UseMnemonic = True
		Me.Prompt.Visible = True
		Me.Prompt.AutoSize = False
		Me.Prompt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Prompt.Name = "Prompt"
		Me.Label1.Text = "Prompt:"
		Me.Label1.Size = New System.Drawing.Size(177, 17)
		Me.Label1.Location = New System.Drawing.Point(216, 72)
		Me.Label1.TabIndex = 1
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(eName)
		Me.Controls.Add(HiddenPict)
		Me.Controls.Add(Status)
		Me.Controls.Add(Close_Renamed)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(Samples)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Prompt)
		Me.Controls.Add(Label1)
		Me.picButtons.Controls.Add(cmdExit)
		Me.picButtons.Controls.Add(Label4)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class