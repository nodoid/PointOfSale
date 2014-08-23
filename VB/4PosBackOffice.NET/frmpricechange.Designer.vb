<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmpricechange
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
	Public WithEvents cmdcancel As System.Windows.Forms.Button
	Public WithEvents cmdshow As System.Windows.Forms.Button
	Public WithEvents cmdenddate As System.Windows.Forms.Button
	Public WithEvents txtenddate As System.Windows.Forms.TextBox
	Public WithEvents txtstartdate As System.Windows.Forms.TextBox
	Public WithEvents cmdstart As System.Windows.Forms.Button
	Public WithEvents lblInstruction As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmpricechange))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdcancel = New System.Windows.Forms.Button
		Me.cmdshow = New System.Windows.Forms.Button
		Me.cmdenddate = New System.Windows.Forms.Button
		Me.txtenddate = New System.Windows.Forms.TextBox
		Me.txtstartdate = New System.Windows.Forms.TextBox
		Me.cmdstart = New System.Windows.Forms.Button
		Me.lblInstruction = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Price Changes"
		Me.ClientSize = New System.Drawing.Size(442, 155)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmpricechange.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmpricechange"
		Me.cmdcancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcancel.Text = "&Cancel"
		Me.cmdcancel.Size = New System.Drawing.Size(81, 33)
		Me.cmdcancel.Location = New System.Drawing.Point(352, 112)
		Me.cmdcancel.TabIndex = 7
		Me.cmdcancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcancel.CausesValidation = True
		Me.cmdcancel.Enabled = True
		Me.cmdcancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcancel.TabStop = True
		Me.cmdcancel.Name = "cmdcancel"
		Me.cmdshow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdshow.Text = "&Show"
		Me.cmdshow.Size = New System.Drawing.Size(81, 33)
		Me.cmdshow.Location = New System.Drawing.Point(248, 112)
		Me.cmdshow.TabIndex = 6
		Me.cmdshow.BackColor = System.Drawing.SystemColors.Control
		Me.cmdshow.CausesValidation = True
		Me.cmdshow.Enabled = True
		Me.cmdshow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdshow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdshow.TabStop = True
		Me.cmdshow.Name = "cmdshow"
		Me.cmdenddate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdenddate.Text = "..."
		Me.cmdenddate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdenddate.Size = New System.Drawing.Size(33, 33)
		Me.cmdenddate.Location = New System.Drawing.Point(400, 64)
		Me.cmdenddate.TabIndex = 5
		Me.cmdenddate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdenddate.CausesValidation = True
		Me.cmdenddate.Enabled = True
		Me.cmdenddate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdenddate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdenddate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdenddate.TabStop = True
		Me.cmdenddate.Name = "cmdenddate"
		Me.txtenddate.AutoSize = False
		Me.txtenddate.Size = New System.Drawing.Size(81, 33)
		Me.txtenddate.Location = New System.Drawing.Point(320, 64)
		Me.txtenddate.TabIndex = 4
		Me.txtenddate.AcceptsReturn = True
		Me.txtenddate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtenddate.BackColor = System.Drawing.SystemColors.Window
		Me.txtenddate.CausesValidation = True
		Me.txtenddate.Enabled = True
		Me.txtenddate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtenddate.HideSelection = True
		Me.txtenddate.ReadOnly = False
		Me.txtenddate.Maxlength = 0
		Me.txtenddate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtenddate.MultiLine = False
		Me.txtenddate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtenddate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtenddate.TabStop = True
		Me.txtenddate.Visible = True
		Me.txtenddate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtenddate.Name = "txtenddate"
		Me.txtstartdate.AutoSize = False
		Me.txtstartdate.Size = New System.Drawing.Size(81, 33)
		Me.txtstartdate.Location = New System.Drawing.Point(112, 64)
		Me.txtstartdate.TabIndex = 2
		Me.txtstartdate.AcceptsReturn = True
		Me.txtstartdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtstartdate.BackColor = System.Drawing.SystemColors.Window
		Me.txtstartdate.CausesValidation = True
		Me.txtstartdate.Enabled = True
		Me.txtstartdate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtstartdate.HideSelection = True
		Me.txtstartdate.ReadOnly = False
		Me.txtstartdate.Maxlength = 0
		Me.txtstartdate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtstartdate.MultiLine = False
		Me.txtstartdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtstartdate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtstartdate.TabStop = True
		Me.txtstartdate.Visible = True
		Me.txtstartdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtstartdate.Name = "txtstartdate"
		Me.cmdstart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdstart.Text = "..."
		Me.cmdstart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdstart.Size = New System.Drawing.Size(33, 33)
		Me.cmdstart.Location = New System.Drawing.Point(192, 64)
		Me.cmdstart.TabIndex = 1
		Me.cmdstart.BackColor = System.Drawing.SystemColors.Control
		Me.cmdstart.CausesValidation = True
		Me.cmdstart.Enabled = True
		Me.cmdstart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdstart.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdstart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdstart.TabStop = True
		Me.cmdstart.Name = "cmdstart"
		Me.lblInstruction.Text = "This Process will print you the Price Changes of the Date range you selected.Please Select the 'Start Date' and the 'End Date'  and Click the Show button.Please Note the Start Date must be earlier than the 'End Date'"
		Me.lblInstruction.Size = New System.Drawing.Size(424, 45)
		Me.lblInstruction.Location = New System.Drawing.Point(8, 8)
		Me.lblInstruction.TabIndex = 8
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
		Me.Label2.Text = "End Date:"
		Me.Label2.Size = New System.Drawing.Size(81, 33)
		Me.Label2.Location = New System.Drawing.Point(232, 72)
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
		Me.Label1.Text = " Start Date:"
		Me.Label1.Size = New System.Drawing.Size(97, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 72)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(cmdcancel)
		Me.Controls.Add(cmdshow)
		Me.Controls.Add(cmdenddate)
		Me.Controls.Add(txtenddate)
		Me.Controls.Add(txtstartdate)
		Me.Controls.Add(cmdstart)
		Me.Controls.Add(lblInstruction)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class