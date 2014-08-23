<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRPfilter
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
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdNamespace As System.Windows.Forms.Button
	Public WithEvents lblHeading As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRPfilter))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdNamespace = New System.Windows.Forms.Button
		Me.lblHeading = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "Select the filter for your Report"
		Me.ClientSize = New System.Drawing.Size(462, 123)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmRPfilter"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(363, 66)
		Me.cmdExit.TabIndex = 3
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPrint.Size = New System.Drawing.Size(97, 52)
		Me.cmdPrint.Location = New System.Drawing.Point(159, 66)
		Me.cmdPrint.TabIndex = 2
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNamespace.Text = "&Filter"
		Me.cmdNamespace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNamespace.Size = New System.Drawing.Size(97, 52)
		Me.cmdNamespace.Location = New System.Drawing.Point(363, 3)
		Me.cmdNamespace.TabIndex = 1
		Me.cmdNamespace.TabStop = False
		Me.cmdNamespace.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNamespace.CausesValidation = True
		Me.cmdNamespace.Enabled = True
		Me.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNamespace.Name = "cmdNamespace"
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Size = New System.Drawing.Size(349, 52)
		Me.lblHeading.Location = New System.Drawing.Point(3, 3)
		Me.lblHeading.TabIndex = 0
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(cmdNamespace)
		Me.Controls.Add(lblHeading)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class