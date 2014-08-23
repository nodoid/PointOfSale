<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGroupSales
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
	Public WithEvents cmbMinor As System.Windows.Forms.ComboBox
	Public WithEvents cmbMajor As System.Windows.Forms.ComboBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGroupSales))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbMinor = New System.Windows.Forms.ComboBox
		Me.cmbMajor = New System.Windows.Forms.ComboBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdLoad = New System.Windows.Forms.Button
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Group Sales Profitability Order Criteria"
		Me.ClientSize = New System.Drawing.Size(447, 152)
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
		Me.Name = "frmGroupSales"
		Me.cmbMinor.Size = New System.Drawing.Size(400, 21)
		Me.cmbMinor.Location = New System.Drawing.Point(36, 78)
		Me.cmbMinor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbMinor.TabIndex = 3
		Me.cmbMinor.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMinor.CausesValidation = True
		Me.cmbMinor.Enabled = True
		Me.cmbMinor.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMinor.IntegralHeight = True
		Me.cmbMinor.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMinor.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMinor.Sorted = False
		Me.cmbMinor.TabStop = True
		Me.cmbMinor.Visible = True
		Me.cmbMinor.Name = "cmbMinor"
		Me.cmbMajor.Size = New System.Drawing.Size(400, 21)
		Me.cmbMajor.Location = New System.Drawing.Point(36, 27)
		Me.cmbMajor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbMajor.TabIndex = 1
		Me.cmbMajor.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMajor.CausesValidation = True
		Me.cmbMajor.Enabled = True
		Me.cmbMajor.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMajor.IntegralHeight = True
		Me.cmbMajor.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMajor.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMajor.Sorted = False
		Me.cmbMajor.TabStop = True
		Me.cmbMajor.Visible = True
		Me.cmbMajor.Name = "cmbMajor"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 31)
		Me.cmdExit.Location = New System.Drawing.Point(12, 111)
		Me.cmdExit.TabIndex = 4
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load report >>"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 31)
		Me.cmdLoad.Location = New System.Drawing.Point(357, 111)
		Me.cmdLoad.TabIndex = 5
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me._lbl_1.Text = "&2. Select the Minor Break Group"
		Me._lbl_1.Size = New System.Drawing.Size(184, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 57)
		Me._lbl_1.TabIndex = 2
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lbl_0.Text = "&1. Select the Major Break Group"
		Me._lbl_0.Size = New System.Drawing.Size(184, 13)
		Me._lbl_0.Location = New System.Drawing.Point(9, 9)
		Me._lbl_0.TabIndex = 0
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.Controls.Add(cmbMinor)
		Me.Controls.Add(cmbMajor)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_0)
		Me.lbl.SetIndex(_lbl_1, CType(1, Short))
		Me.lbl.SetIndex(_lbl_0, CType(0, Short))
		CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class