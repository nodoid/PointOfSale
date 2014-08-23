<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTakeSnapshot
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
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdProceed As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents lbl As System.Windows.Forms.Label
	Public WithEvents lblInstruction As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTakeSnapshot))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdProceed = New System.Windows.Forms.Button
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.lbl = New System.Windows.Forms.Label
		Me.lblInstruction = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Stock Take Snapshot"
		Me.ClientSize = New System.Drawing.Size(391, 215)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockTakeSnapshot"
		Me.Timer1.Enabled = False
		Me.Timer1.Interval = 10
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 25)
		Me.cmdExit.Location = New System.Drawing.Point(6, 180)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProceed.Text = "&Proceed"
		Me.cmdProceed.Size = New System.Drawing.Size(97, 25)
		Me.cmdProceed.Location = New System.Drawing.Point(288, 180)
		Me.cmdProceed.TabIndex = 1
		Me.cmdProceed.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProceed.CausesValidation = True
		Me.cmdProceed.Enabled = True
		Me.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProceed.TabStop = True
		Me.cmdProceed.Name = "cmdProceed"
		Me.Picture1.Size = New System.Drawing.Size(111, 108)
		Me.Picture1.Location = New System.Drawing.Point(6, 6)
		Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
		Me.Picture1.TabIndex = 2
		Me.Picture1.TabStop = False
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.BackColor = System.Drawing.SystemColors.Control
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.lbl.Text = "Please note that should you run the 'Create Theoretical Stock Snapshot' process you will over write the previously created snapshot."
		Me.lbl.Size = New System.Drawing.Size(256, 52)
		Me.lbl.Location = New System.Drawing.Point(126, 120)
		Me.lbl.TabIndex = 4
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbl.BackColor = System.Drawing.SystemColors.Control
		Me.lbl.Enabled = True
		Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl.UseMnemonic = True
		Me.lbl.Visible = True
		Me.lbl.AutoSize = False
		Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lbl.Name = "lbl"
		Me.lblInstruction.Text = "The 'Create Theoretical Stock Snapshot' process will create a snapshot of your stock holding as it stands currently for the purpose of facilitating your stock taking process. The theoretical snapshot that you create will remain constant until the next time that this process is run. This will allow you to continue your day-to-day activities without affecting your stock take count."
		Me.lblInstruction.Size = New System.Drawing.Size(256, 109)
		Me.lblInstruction.Location = New System.Drawing.Point(126, 6)
		Me.lblInstruction.TabIndex = 3
		Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblInstruction.BackColor = System.Drawing.SystemColors.Control
		Me.lblInstruction.Enabled = True
		Me.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInstruction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInstruction.UseMnemonic = True
		Me.lblInstruction.Visible = True
		Me.lblInstruction.AutoSize = False
		Me.lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblInstruction.Name = "lblInstruction"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdProceed)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(lbl)
		Me.Controls.Add(lblInstruction)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class