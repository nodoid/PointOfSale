<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmIncomeExpense
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
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents cmbMonthEnd As System.Windows.Forms.ComboBox
	Public WithEvents lbl As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIncomeExpense))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.cmbMonthEnd = New System.Windows.Forms.ComboBox
		Me.lbl = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Income and Expense Report"
		Me.ClientSize = New System.Drawing.Size(448, 94)
		Me.Location = New System.Drawing.Point(3, 29)
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
		Me.Name = "frmIncomeExpense"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(172, 31)
		Me.cmdExit.Location = New System.Drawing.Point(267, 54)
		Me.cmdExit.TabIndex = 3
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load Report"
		Me.cmdLoad.Size = New System.Drawing.Size(172, 31)
		Me.cmdLoad.Location = New System.Drawing.Point(12, 54)
		Me.cmdLoad.TabIndex = 1
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.cmbMonthEnd.Size = New System.Drawing.Size(427, 21)
		Me.cmbMonthEnd.Location = New System.Drawing.Point(12, 27)
		Me.cmbMonthEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbMonthEnd.TabIndex = 0
		Me.cmbMonthEnd.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMonthEnd.CausesValidation = True
		Me.cmbMonthEnd.Enabled = True
		Me.cmbMonthEnd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMonthEnd.IntegralHeight = True
		Me.cmbMonthEnd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMonthEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMonthEnd.Sorted = False
		Me.cmbMonthEnd.TabStop = True
		Me.cmbMonthEnd.Visible = True
		Me.cmbMonthEnd.Name = "cmbMonthEnd"
		Me.lbl.Text = "&1.Select the Month-end Period for the Report."
		Me.lbl.Size = New System.Drawing.Size(215, 13)
		Me.lbl.Location = New System.Drawing.Point(15, 6)
		Me.lbl.TabIndex = 2
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbl.BackColor = System.Drawing.Color.Transparent
		Me.lbl.Enabled = True
		Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl.UseMnemonic = True
		Me.lbl.Visible = True
		Me.lbl.AutoSize = True
		Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbl.Name = "lbl"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(cmbMonthEnd)
		Me.Controls.Add(lbl)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class