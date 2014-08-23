<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUpdateWarning
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
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdContinue As System.Windows.Forms.Button
	Public WithEvents tmrStart As System.Windows.Forms.Timer
	Public WithEvents lblDesc As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdateWarning))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdContinue = New System.Windows.Forms.Button
		Me.tmrStart = New System.Windows.Forms.Timer(components)
		Me.lblDesc = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Update Warning ..."
		Me.ClientSize = New System.Drawing.Size(468, 258)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmUpdateWarning"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Cancel the Update of Point Of Sale"
		Me.cmdClose.Size = New System.Drawing.Size(130, 37)
		Me.cmdClose.Location = New System.Drawing.Point(309, 204)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "Print List"
		Me.cmdPrint.Size = New System.Drawing.Size(130, 37)
		Me.cmdPrint.Location = New System.Drawing.Point(171, 204)
		Me.cmdPrint.TabIndex = 0
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdContinue.Text = "Continue with the Update of Point Of Sale"
		Me.cmdContinue.Size = New System.Drawing.Size(130, 37)
		Me.cmdContinue.Location = New System.Drawing.Point(33, 204)
		Me.cmdContinue.TabIndex = 2
		Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
		Me.cmdContinue.CausesValidation = True
		Me.cmdContinue.Enabled = True
		Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdContinue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdContinue.TabStop = True
		Me.cmdContinue.Name = "cmdContinue"
		Me.tmrStart.Interval = 10
		Me.tmrStart.Enabled = True
		Me.lblDesc.BackColor = System.Drawing.Color.White
		Me.lblDesc.Text = "There are 47 catalogue prices where your price is equal or less that the products cost price."
		Me.lblDesc.ForeColor = System.Drawing.Color.Red
		Me.lblDesc.Size = New System.Drawing.Size(409, 172)
		Me.lblDesc.Location = New System.Drawing.Point(30, 12)
		Me.lblDesc.TabIndex = 3
		Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDesc.Enabled = True
		Me.lblDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDesc.UseMnemonic = True
		Me.lblDesc.Visible = True
		Me.lblDesc.AutoSize = False
		Me.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDesc.Name = "lblDesc"
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(cmdContinue)
		Me.Controls.Add(lblDesc)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class