<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLabel
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
	Public WithEvents lstLayout As System.Windows.Forms.ListBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLabel))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstLayout = New System.Windows.Forms.ListBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select Label Format"
		Me.ClientSize = New System.Drawing.Size(364, 263)
		Me.Location = New System.Drawing.Point(3, 22)
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
		Me.Name = "frmLabel"
		Me.lstLayout.Size = New System.Drawing.Size(349, 189)
		Me.lstLayout.Location = New System.Drawing.Point(6, 6)
		Me.lstLayout.TabIndex = 2
		Me.lstLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstLayout.BackColor = System.Drawing.SystemColors.Window
		Me.lstLayout.CausesValidation = True
		Me.lstLayout.Enabled = True
		Me.lstLayout.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstLayout.IntegralHeight = True
		Me.lstLayout.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstLayout.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstLayout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstLayout.Sorted = False
		Me.lstLayout.TabStop = True
		Me.lstLayout.Visible = True
		Me.lstLayout.MultiColumn = False
		Me.lstLayout.Name = "lstLayout"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(21, 201)
		Me.cmdExit.TabIndex = 1
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Size = New System.Drawing.Size(97, 52)
		Me.cmdNext.Location = New System.Drawing.Point(243, 201)
		Me.cmdNext.TabIndex = 0
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.Controls.Add(lstLayout)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdNext)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class