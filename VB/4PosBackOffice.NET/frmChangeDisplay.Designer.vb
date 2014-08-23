<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChangeDisplay
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
	Public WithEvents cmdSubmit As System.Windows.Forms.Button
	Public WithEvents txtNumber As System.Windows.Forms.TextBox
	Public WithEvents lblName As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangeDisplay))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdSubmit = New System.Windows.Forms.Button
		Me.txtNumber = New System.Windows.Forms.TextBox
		Me.lblName = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(248, 82)
		Me.Location = New System.Drawing.Point(0, 0)
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
		Me.Name = "frmChangeDisplay"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Decline"
		Me.Command1.Size = New System.Drawing.Size(73, 22)
		Me.Command1.Location = New System.Drawing.Point(172, 52)
		Me.Command1.TabIndex = 4
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.cmdSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSubmit.Text = "Accept"
		Me.cmdSubmit.Size = New System.Drawing.Size(73, 22)
		Me.cmdSubmit.Location = New System.Drawing.Point(92, 52)
		Me.cmdSubmit.TabIndex = 1
		Me.cmdSubmit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSubmit.CausesValidation = True
		Me.cmdSubmit.Enabled = True
		Me.cmdSubmit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSubmit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSubmit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSubmit.TabStop = True
		Me.cmdSubmit.Name = "cmdSubmit"
		Me.txtNumber.AutoSize = False
		Me.txtNumber.Size = New System.Drawing.Size(81, 23)
		Me.txtNumber.Location = New System.Drawing.Point(2, 50)
		Me.txtNumber.TabIndex = 0
		Me.txtNumber.AcceptsReturn = True
		Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumber.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumber.CausesValidation = True
		Me.txtNumber.Enabled = True
		Me.txtNumber.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumber.HideSelection = True
		Me.txtNumber.ReadOnly = False
		Me.txtNumber.Maxlength = 0
		Me.txtNumber.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumber.MultiLine = False
		Me.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumber.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumber.TabStop = True
		Me.txtNumber.Visible = True
		Me.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumber.Name = "txtNumber"
		Me.lblName.Text = "Enter the desired display number"
		Me.lblName.Size = New System.Drawing.Size(119, 19)
		Me.lblName.Location = New System.Drawing.Point(0, 26)
		Me.lblName.TabIndex = 3
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblName.BackColor = System.Drawing.SystemColors.Control
		Me.lblName.Enabled = True
		Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblName.UseMnemonic = True
		Me.lblName.Visible = True
		Me.lblName.AutoSize = False
		Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblName.Name = "lblName"
		Me.Label1.Text = "Enter the desired display number"
		Me.Label1.Size = New System.Drawing.Size(241, 19)
		Me.Label1.Location = New System.Drawing.Point(2, 4)
		Me.Label1.TabIndex = 2
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
		Me.Controls.Add(Command1)
		Me.Controls.Add(cmdSubmit)
		Me.Controls.Add(txtNumber)
		Me.Controls.Add(lblName)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class