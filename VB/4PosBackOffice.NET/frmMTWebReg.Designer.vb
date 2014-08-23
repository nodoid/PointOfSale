<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMTWebReg
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents lblVerification As System.Windows.Forms.Label
	Public WithEvents lblOperation As System.Windows.Forms.Label
	Public WithEvents lblAccumulator As System.Windows.Forms.Label
	Public WithEvents lblGlobalCounter As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents label4 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMTWebReg))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.lblVerification = New System.Windows.Forms.Label
		Me.lblOperation = New System.Windows.Forms.Label
		Me.lblAccumulator = New System.Windows.Forms.Label
		Me.lblGlobalCounter = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.label4 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(186, 209)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMTWebReg"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Launch New Form"
		Me.Command1.Size = New System.Drawing.Size(133, 25)
		Me.Command1.Location = New System.Drawing.Point(24, 180)
		Me.Command1.TabIndex = 8
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Timer1.Enabled = False
		Me.Timer1.Interval = 1
		Me.lblVerification.Size = New System.Drawing.Size(109, 13)
		Me.lblVerification.Location = New System.Drawing.Point(36, 156)
		Me.lblVerification.TabIndex = 7
		Me.lblVerification.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblVerification.BackColor = System.Drawing.SystemColors.Control
		Me.lblVerification.Enabled = True
		Me.lblVerification.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVerification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVerification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVerification.UseMnemonic = True
		Me.lblVerification.Visible = True
		Me.lblVerification.AutoSize = False
		Me.lblVerification.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVerification.Name = "lblVerification"
		Me.lblOperation.Size = New System.Drawing.Size(145, 13)
		Me.lblOperation.Location = New System.Drawing.Point(36, 114)
		Me.lblOperation.TabIndex = 6
		Me.lblOperation.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblOperation.BackColor = System.Drawing.SystemColors.Control
		Me.lblOperation.Enabled = True
		Me.lblOperation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblOperation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblOperation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblOperation.UseMnemonic = True
		Me.lblOperation.Visible = True
		Me.lblOperation.AutoSize = False
		Me.lblOperation.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblOperation.Name = "lblOperation"
		Me.lblAccumulator.Size = New System.Drawing.Size(97, 13)
		Me.lblAccumulator.Location = New System.Drawing.Point(36, 72)
		Me.lblAccumulator.TabIndex = 5
		Me.lblAccumulator.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAccumulator.BackColor = System.Drawing.SystemColors.Control
		Me.lblAccumulator.Enabled = True
		Me.lblAccumulator.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAccumulator.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAccumulator.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAccumulator.UseMnemonic = True
		Me.lblAccumulator.Visible = True
		Me.lblAccumulator.AutoSize = False
		Me.lblAccumulator.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAccumulator.Name = "lblAccumulator"
		Me.lblGlobalCounter.Size = New System.Drawing.Size(79, 13)
		Me.lblGlobalCounter.Location = New System.Drawing.Point(36, 30)
		Me.lblGlobalCounter.TabIndex = 4
		Me.lblGlobalCounter.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGlobalCounter.BackColor = System.Drawing.SystemColors.Control
		Me.lblGlobalCounter.Enabled = True
		Me.lblGlobalCounter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGlobalCounter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGlobalCounter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGlobalCounter.UseMnemonic = True
		Me.lblGlobalCounter.Visible = True
		Me.lblGlobalCounter.AutoSize = False
		Me.lblGlobalCounter.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGlobalCounter.Name = "lblGlobalCounter"
		Me.Label3.Text = "TotalIncrements:"
		Me.Label3.Size = New System.Drawing.Size(115, 13)
		Me.Label3.Location = New System.Drawing.Point(12, 132)
		Me.Label3.TabIndex = 3
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
		Me.Label2.Text = "Operation:"
		Me.Label2.Size = New System.Drawing.Size(127, 13)
		Me.Label2.Location = New System.Drawing.Point(12, 96)
		Me.Label2.TabIndex = 2
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
		Me.Label1.Text = "Accumulator:"
		Me.Label1.Size = New System.Drawing.Size(121, 13)
		Me.Label1.Location = New System.Drawing.Point(12, 54)
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
		Me.label4.Text = "GenericGlobalCounter:"
		Me.label4.Size = New System.Drawing.Size(133, 13)
		Me.label4.Location = New System.Drawing.Point(12, 12)
		Me.label4.TabIndex = 0
		Me.label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label4.BackColor = System.Drawing.SystemColors.Control
		Me.label4.Enabled = True
		Me.label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label4.UseMnemonic = True
		Me.label4.Visible = True
		Me.label4.AutoSize = False
		Me.label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label4.Name = "label4"
		Me.Controls.Add(Command1)
		Me.Controls.Add(lblVerification)
		Me.Controls.Add(lblOperation)
		Me.Controls.Add(lblAccumulator)
		Me.Controls.Add(lblGlobalCounter)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(label4)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class