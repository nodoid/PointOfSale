<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmZeroiseED
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents mdbFile As System.Windows.Forms.TextBox
	Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents prgBar As System.Windows.Forms.ProgressBar
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public cmdDlgOpen As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog1Font As System.Windows.Forms.FontDialog
	Public CommonDialog1Color As System.Windows.Forms.ColorDialog
	Public CommonDialog1Print As System.Windows.Forms.PrintDialog
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmZeroiseED))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtPassword = New System.Windows.Forms.TextBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.mdbFile = New System.Windows.Forms.TextBox
		Me.cmdStart = New System.Windows.Forms.Button
		Me.prgBar = New System.Windows.Forms.ProgressBar
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdDlgOpen = New System.Windows.Forms.OpenFileDialog
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
		Me.CommonDialog1Font = New System.Windows.Forms.FontDialog
		Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog
		Me.CommonDialog1Print = New System.Windows.Forms.PrintDialog
		Me.Frame1.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "Export Customer Details"
		Me.ClientSize = New System.Drawing.Size(539, 153)
		Me.Location = New System.Drawing.Point(3, 14)
		Me.Icon = CType(resources.GetObject("frmZeroiseED.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmZeroiseED"
		Me.Frame1.Size = New System.Drawing.Size(531, 107)
		Me.Frame1.Location = New System.Drawing.Point(4, 40)
		Me.Frame1.TabIndex = 2
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Size = New System.Drawing.Size(179, 20)
		Me.txtPassword.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtPassword.Location = New System.Drawing.Point(238, 48)
		Me.txtPassword.PasswordChar = ChrW(42)
		Me.txtPassword.TabIndex = 8
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
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "----"
		Me.Command1.Size = New System.Drawing.Size(77, 21)
		Me.Command1.Location = New System.Drawing.Point(424, 16)
		Me.Command1.TabIndex = 5
		Me.Command1.Visible = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.mdbFile.AutoSize = False
		Me.mdbFile.Size = New System.Drawing.Size(285, 21)
		Me.mdbFile.Location = New System.Drawing.Point(8, 72)
		Me.mdbFile.TabIndex = 4
		Me.mdbFile.Visible = False
		Me.mdbFile.AcceptsReturn = True
		Me.mdbFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.mdbFile.BackColor = System.Drawing.SystemColors.Window
		Me.mdbFile.CausesValidation = True
		Me.mdbFile.Enabled = True
		Me.mdbFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.mdbFile.HideSelection = True
		Me.mdbFile.ReadOnly = False
		Me.mdbFile.Maxlength = 0
		Me.mdbFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.mdbFile.MultiLine = False
		Me.mdbFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.mdbFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.mdbFile.TabStop = True
		Me.mdbFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.mdbFile.Name = "mdbFile"
		Me.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStart.Text = "Start ..."
		Me.cmdStart.Size = New System.Drawing.Size(77, 21)
		Me.cmdStart.Location = New System.Drawing.Point(424, 48)
		Me.cmdStart.TabIndex = 3
		Me.ToolTip1.SetToolTip(Me.cmdStart, "export database to csv")
		Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStart.CausesValidation = True
		Me.cmdStart.Enabled = True
		Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStart.TabStop = True
		Me.cmdStart.Name = "cmdStart"
		Me.prgBar.Size = New System.Drawing.Size(481, 21)
		Me.prgBar.Location = New System.Drawing.Point(18, 80)
		Me.prgBar.TabIndex = 7
		Me.prgBar.Name = "prgBar"
		Me.Label2.Text = "Password:"
		Me.Label2.Size = New System.Drawing.Size(101, 21)
		Me.Label2.Location = New System.Drawing.Point(136, 48)
		Me.Label2.TabIndex = 9
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
		Me.Label1.Text = "Please click Start to Export Customer details"
		Me.Label1.Size = New System.Drawing.Size(499, 56)
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.TabIndex = 6
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
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(533, 37)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.None
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.TabStop = True
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "Exit"
		Me.cmdExit.Size = New System.Drawing.Size(77, 21)
		Me.cmdExit.Location = New System.Drawing.Point(424, 8)
		Me.cmdExit.TabIndex = 1
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(picButtons)
		Me.Frame1.Controls.Add(txtPassword)
		Me.Frame1.Controls.Add(Command1)
		Me.Frame1.Controls.Add(mdbFile)
		Me.Frame1.Controls.Add(cmdStart)
		Me.Frame1.Controls.Add(prgBar)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		Me.picButtons.Controls.Add(cmdExit)
		Me.Frame1.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class