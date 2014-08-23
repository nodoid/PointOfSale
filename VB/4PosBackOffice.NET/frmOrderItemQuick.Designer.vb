<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOrderItemQuick
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
	Public WithEvents txtMin As System.Windows.Forms.TextBox
	Public WithEvents cmdProceed As System.Windows.Forms.Button
	Public WithEvents txtMax As System.Windows.Forms.TextBox
	Public WithEvents txtCost As System.Windows.Forms.TextBox
	Public WithEvents lblPath As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblName As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderItemQuick))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtMin = New System.Windows.Forms.TextBox
		Me.cmdProceed = New System.Windows.Forms.Button
		Me.txtMax = New System.Windows.Forms.TextBox
		Me.txtCost = New System.Windows.Forms.TextBox
		Me.lblPath = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblName = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ControlBox = False
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(313, 176)
		Me.Location = New System.Drawing.Point(3, 3)
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
		Me.Name = "frmOrderItemQuick"
		Me.txtMin.AutoSize = False
		Me.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtMin.Size = New System.Drawing.Size(217, 19)
		Me.txtMin.Location = New System.Drawing.Point(84, 86)
		Me.txtMin.TabIndex = 0
		Me.txtMin.Text = "Text1"
		Me.txtMin.AcceptsReturn = True
		Me.txtMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtMin.CausesValidation = True
		Me.txtMin.Enabled = True
		Me.txtMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMin.HideSelection = True
		Me.txtMin.ReadOnly = False
		Me.txtMin.Maxlength = 0
		Me.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMin.MultiLine = False
		Me.txtMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMin.TabStop = True
		Me.txtMin.Visible = True
		Me.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMin.Name = "txtMin"
		Me.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProceed.Text = "&Proceed"
		Me.cmdProceed.Size = New System.Drawing.Size(85, 31)
		Me.cmdProceed.Location = New System.Drawing.Point(216, 136)
		Me.cmdProceed.TabIndex = 2
		Me.cmdProceed.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProceed.CausesValidation = True
		Me.cmdProceed.Enabled = True
		Me.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProceed.TabStop = True
		Me.cmdProceed.Name = "cmdProceed"
		Me.txtMax.AutoSize = False
		Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtMax.Size = New System.Drawing.Size(217, 19)
		Me.txtMax.Location = New System.Drawing.Point(84, 110)
		Me.txtMax.TabIndex = 1
		Me.txtMax.Text = "Text1"
		Me.txtMax.AcceptsReturn = True
		Me.txtMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtMax.CausesValidation = True
		Me.txtMax.Enabled = True
		Me.txtMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMax.HideSelection = True
		Me.txtMax.ReadOnly = False
		Me.txtMax.Maxlength = 0
		Me.txtMax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMax.MultiLine = False
		Me.txtMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMax.TabStop = True
		Me.txtMax.Visible = True
		Me.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMax.Name = "txtMax"
		Me.txtCost.AutoSize = False
		Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtCost.Enabled = False
		Me.txtCost.Size = New System.Drawing.Size(217, 19)
		Me.txtCost.Location = New System.Drawing.Point(84, 62)
		Me.txtCost.TabIndex = 5
		Me.txtCost.TabStop = False
		Me.txtCost.Text = "Text1"
		Me.txtCost.AcceptsReturn = True
		Me.txtCost.BackColor = System.Drawing.SystemColors.Window
		Me.txtCost.CausesValidation = True
		Me.txtCost.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCost.HideSelection = True
		Me.txtCost.ReadOnly = False
		Me.txtCost.Maxlength = 0
		Me.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCost.MultiLine = False
		Me.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCost.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCost.Visible = True
		Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCost.Name = "txtCost"
		Me.lblPath.BackColor = System.Drawing.Color.Blue
		Me.lblPath.Text = "Stock Re-order Quick Edit"
		Me.lblPath.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPath.ForeColor = System.Drawing.Color.White
		Me.lblPath.Size = New System.Drawing.Size(568, 25)
		Me.lblPath.Location = New System.Drawing.Point(0, 0)
		Me.lblPath.TabIndex = 8
		Me.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPath.Enabled = True
		Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPath.UseMnemonic = True
		Me.lblPath.Visible = True
		Me.lblPath.AutoSize = False
		Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPath.Name = "lblPath"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "Minimum"
		Me._lbl_2.Size = New System.Drawing.Size(41, 13)
		Me._lbl_2.Location = New System.Drawing.Point(40, 86)
		Me._lbl_2.TabIndex = 6
		Me._lbl_2.BackColor = System.Drawing.SystemColors.Control
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Maximum"
		Me.Label1.Size = New System.Drawing.Size(44, 13)
		Me.Label1.Location = New System.Drawing.Point(34, 113)
		Me.Label1.TabIndex = 7
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "Cost"
		Me._lbl_0.Size = New System.Drawing.Size(21, 13)
		Me._lbl_0.Location = New System.Drawing.Point(59, 65)
		Me._lbl_0.TabIndex = 4
		Me._lbl_0.BackColor = System.Drawing.SystemColors.Control
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblName.Text = "Label1"
		Me.lblName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblName.Size = New System.Drawing.Size(289, 16)
		Me.lblName.Location = New System.Drawing.Point(12, 33)
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
		Me.Controls.Add(txtMin)
		Me.Controls.Add(cmdProceed)
		Me.Controls.Add(txtMax)
		Me.Controls.Add(txtCost)
		Me.Controls.Add(lblPath)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblName)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class