<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGlobalCost
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
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents prgUpload As System.Windows.Forms.ProgressBar
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtFileName As System.Windows.Forms.TextBox
	Public cmdDlgOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGlobalCost))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtPassword = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Command3 = New System.Windows.Forms.Button
		Me.prgUpload = New System.Windows.Forms.ProgressBar
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.txtFileName = New System.Windows.Forms.TextBox
		Me.cmdDlgOpen = New System.Windows.Forms.OpenFileDialog
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "[Update Cost]"
		Me.ClientSize = New System.Drawing.Size(498, 141)
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
		Me.Name = "frmGlobalCost"
		Me.Frame1.Text = "Passwords"
		Me.Frame1.Size = New System.Drawing.Size(493, 131)
		Me.Frame1.Location = New System.Drawing.Point(2, 4)
		Me.Frame1.TabIndex = 7
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Size = New System.Drawing.Size(195, 23)
		Me.txtPassword.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtPassword.Location = New System.Drawing.Point(186, 54)
		Me.txtPassword.PasswordChar = ChrW(42)
		Me.txtPassword.TabIndex = 0
		Me.txtPassword.AcceptsReturn = True
		Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
		Me.txtPassword.CausesValidation = True
		Me.txtPassword.Enabled = True
		Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPassword.HideSelection = True
		Me.txtPassword.ReadOnly = False
		Me.txtPassword.Maxlength = 0
		Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPassword.MultiLine = False
		Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPassword.TabStop = True
		Me.txtPassword.Visible = True
		Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtPassword.Name = "txtPassword"
		Me.Label2.Text = "Passwords :"
		Me.Label2.Size = New System.Drawing.Size(73, 19)
		Me.Label2.Location = New System.Drawing.Point(98, 56)
		Me.Label2.TabIndex = 8
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
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "Exit"
		Me.Command3.Size = New System.Drawing.Size(105, 29)
		Me.Command3.Location = New System.Drawing.Point(6, 104)
		Me.Command3.TabIndex = 6
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.prgUpload.Size = New System.Drawing.Size(493, 23)
		Me.prgUpload.Location = New System.Drawing.Point(2, 48)
		Me.prgUpload.TabIndex = 5
		Me.prgUpload.Maximum = 300
		Me.prgUpload.Name = "prgUpload"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Do Update"
		Me.Command2.Size = New System.Drawing.Size(107, 29)
		Me.Command2.Location = New System.Drawing.Point(386, 104)
		Me.Command2.TabIndex = 4
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "..."
		Me.Command1.Size = New System.Drawing.Size(47, 19)
		Me.Command1.Location = New System.Drawing.Point(444, 18)
		Me.Command1.TabIndex = 3
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.txtFileName.AutoSize = False
		Me.txtFileName.Enabled = False
		Me.txtFileName.Size = New System.Drawing.Size(359, 19)
		Me.txtFileName.Location = New System.Drawing.Point(78, 18)
		Me.txtFileName.TabIndex = 2
		Me.txtFileName.AcceptsReturn = True
		Me.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFileName.BackColor = System.Drawing.SystemColors.Window
		Me.txtFileName.CausesValidation = True
		Me.txtFileName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFileName.HideSelection = True
		Me.txtFileName.ReadOnly = False
		Me.txtFileName.Maxlength = 0
		Me.txtFileName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFileName.MultiLine = False
		Me.txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFileName.TabStop = True
		Me.txtFileName.Visible = True
		Me.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtFileName.Name = "txtFileName"
		Me.Label1.Text = "File Name :"
		Me.Label1.Size = New System.Drawing.Size(71, 15)
		Me.Label1.Location = New System.Drawing.Point(2, 20)
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
		Me.Controls.Add(Frame1)
		Me.Controls.Add(Command3)
		Me.Controls.Add(prgUpload)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(txtFileName)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(txtPassword)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class