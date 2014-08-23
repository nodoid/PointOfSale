<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVTemplate
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
	Public WithEvents cmdDown As System.Windows.Forms.Button
	Public WithEvents cmdUp As System.Windows.Forms.Button
	Public WithEvents lstItem As System.Windows.Forms.ListBox
	Public WithEvents cmbTemplate As System.Windows.Forms.ComboBox
	Public WithEvents lstTemplate As System.Windows.Forms.ListBox
	Public WithEvents cmdNew As System.Windows.Forms.Button
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVTemplate))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdDown = New System.Windows.Forms.Button
		Me.cmdUp = New System.Windows.Forms.Button
		Me.lstItem = New System.Windows.Forms.ListBox
		Me.cmbTemplate = New System.Windows.Forms.ComboBox
		Me.lstTemplate = New System.Windows.Forms.ListBox
		Me.cmdNew = New System.Windows.Forms.Button
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "GRV Template Editor"
		Me.ClientSize = New System.Drawing.Size(419, 382)
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
		Me.Name = "frmGRVTemplate"
		Me.cmdDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDown.Text = "Down"
		Me.cmdDown.Size = New System.Drawing.Size(46, 70)
		Me.cmdDown.Location = New System.Drawing.Point(363, 294)
		Me.cmdDown.TabIndex = 5
		Me.cmdDown.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDown.CausesValidation = True
		Me.cmdDown.Enabled = True
		Me.cmdDown.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDown.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDown.TabStop = True
		Me.cmdDown.Name = "cmdDown"
		Me.cmdUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUp.Text = "Up"
		Me.cmdUp.Size = New System.Drawing.Size(46, 70)
		Me.cmdUp.Location = New System.Drawing.Point(363, 45)
		Me.cmdUp.TabIndex = 4
		Me.cmdUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUp.CausesValidation = True
		Me.cmdUp.Enabled = True
		Me.cmdUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUp.TabStop = True
		Me.cmdUp.Name = "cmdUp"
		Me.lstItem.Size = New System.Drawing.Size(172, 319)
		Me.lstItem.Location = New System.Drawing.Point(186, 45)
		Me.lstItem.TabIndex = 3
		Me.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstItem.BackColor = System.Drawing.SystemColors.Window
		Me.lstItem.CausesValidation = True
		Me.lstItem.Enabled = True
		Me.lstItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstItem.IntegralHeight = True
		Me.lstItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstItem.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstItem.Sorted = False
		Me.lstItem.TabStop = True
		Me.lstItem.Visible = True
		Me.lstItem.MultiColumn = False
		Me.lstItem.Name = "lstItem"
		Me.cmbTemplate.Size = New System.Drawing.Size(268, 21)
		Me.cmbTemplate.Location = New System.Drawing.Point(87, 3)
		Me.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTemplate.TabIndex = 2
		Me.cmbTemplate.BackColor = System.Drawing.SystemColors.Window
		Me.cmbTemplate.CausesValidation = True
		Me.cmbTemplate.Enabled = True
		Me.cmbTemplate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbTemplate.IntegralHeight = True
		Me.cmbTemplate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbTemplate.Sorted = False
		Me.cmbTemplate.TabStop = True
		Me.cmbTemplate.Visible = True
		Me.cmbTemplate.Name = "cmbTemplate"
		Me.lstTemplate.Size = New System.Drawing.Size(172, 319)
		Me.lstTemplate.Location = New System.Drawing.Point(6, 45)
		Me.lstTemplate.TabIndex = 1
		Me.lstTemplate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstTemplate.BackColor = System.Drawing.SystemColors.Window
		Me.lstTemplate.CausesValidation = True
		Me.lstTemplate.Enabled = True
		Me.lstTemplate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstTemplate.IntegralHeight = True
		Me.lstTemplate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstTemplate.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstTemplate.Sorted = False
		Me.lstTemplate.TabStop = True
		Me.lstTemplate.Visible = True
		Me.lstTemplate.MultiColumn = False
		Me.lstTemplate.Name = "lstTemplate"
		Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNew.Text = "New ..."
		Me.cmdNew.Size = New System.Drawing.Size(49, 22)
		Me.cmdNew.Location = New System.Drawing.Point(360, 3)
		Me.cmdNew.TabIndex = 0
		Me.cmdNew.Visible = False
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.TabStop = True
		Me.cmdNew.Name = "cmdNew"
		Me._lbl_2.Text = "GRV Columns :"
		Me._lbl_2.Size = New System.Drawing.Size(72, 13)
		Me._lbl_2.Location = New System.Drawing.Point(189, 30)
		Me._lbl_2.TabIndex = 8
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "Available Columns :"
		Me._lbl_1.Size = New System.Drawing.Size(92, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 30)
		Me._lbl_1.TabIndex = 7
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
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "GRV Tempate :"
		Me._lbl_0.Size = New System.Drawing.Size(74, 13)
		Me._lbl_0.Location = New System.Drawing.Point(8, 6)
		Me._lbl_0.TabIndex = 6
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
		Me.Controls.Add(cmdDown)
		Me.Controls.Add(cmdUp)
		Me.Controls.Add(lstItem)
		Me.Controls.Add(cmbTemplate)
		Me.Controls.Add(lstTemplate)
		Me.Controls.Add(cmdNew)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_0)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class