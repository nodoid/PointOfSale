<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTopSelectNon
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
	Public WithEvents cmdGroup As System.Windows.Forms.Button
	Public WithEvents lblGroup As System.Windows.Forms.Label
	Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
	Public WithEvents cmbSort As System.Windows.Forms.ComboBox
	Public WithEvents cmbSortField As System.Windows.Forms.ComboBox
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents chkPageBreak As System.Windows.Forms.CheckBox
	Public WithEvents cmbGroup As System.Windows.Forms.ComboBox
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_2 As System.Windows.Forms.RadioButton
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdLoad As System.Windows.Forms.Button
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTopSelectNon))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._Frame1_2 = New System.Windows.Forms.GroupBox
		Me.cmdGroup = New System.Windows.Forms.Button
		Me.lblGroup = New System.Windows.Forms.Label
		Me._Frame1_1 = New System.Windows.Forms.GroupBox
		Me.cmbSort = New System.Windows.Forms.ComboBox
		Me.cmbSortField = New System.Windows.Forms.ComboBox
		Me._lbl_0 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.chkPageBreak = New System.Windows.Forms.CheckBox
		Me.cmbGroup = New System.Windows.Forms.ComboBox
		Me._optType_0 = New System.Windows.Forms.RadioButton
		Me._optType_1 = New System.Windows.Forms.RadioButton
		Me._optType_2 = New System.Windows.Forms.RadioButton
		Me._lbl_3 = New System.Windows.Forms.Label
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdLoad = New System.Windows.Forms.Button
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me._Frame1_2.SuspendLayout()
		Me._Frame1_1.SuspendLayout()
		Me._Frame1_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Product Non-Performance"
		Me.ClientSize = New System.Drawing.Size(252, 465)
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
		Me.Name = "frmTopSelectNon"
		Me._Frame1_2.Text = "&3. Report Filter"
		Me._Frame1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_2.Size = New System.Drawing.Size(232, 145)
		Me._Frame1_2.Location = New System.Drawing.Point(12, 249)
		Me._Frame1_2.TabIndex = 12
		Me._Frame1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_2.Enabled = True
		Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_2.Visible = True
		Me._Frame1_2.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_2.Name = "_Frame1_2"
		Me.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGroup.Text = "&Filter"
		Me.cmdGroup.Size = New System.Drawing.Size(97, 31)
		Me.cmdGroup.Location = New System.Drawing.Point(129, 105)
		Me.cmdGroup.TabIndex = 14
		Me.cmdGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGroup.CausesValidation = True
		Me.cmdGroup.Enabled = True
		Me.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGroup.TabStop = True
		Me.cmdGroup.Name = "cmdGroup"
		Me.lblGroup.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.lblGroup.Text = "lblGroup"
		Me.lblGroup.Size = New System.Drawing.Size(220, 76)
		Me.lblGroup.Location = New System.Drawing.Point(6, 21)
		Me.lblGroup.TabIndex = 13
		Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGroup.Enabled = True
		Me.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGroup.UseMnemonic = True
		Me.lblGroup.Visible = True
		Me.lblGroup.AutoSize = False
		Me.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblGroup.Name = "lblGroup"
		Me._Frame1_1.Text = "&2. Report Sort Order"
		Me._Frame1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_1.Size = New System.Drawing.Size(232, 85)
		Me._Frame1_1.Location = New System.Drawing.Point(12, 156)
		Me._Frame1_1.TabIndex = 7
		Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_1.Enabled = True
		Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_1.Visible = True
		Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_1.Name = "_Frame1_1"
		Me.cmbSort.Size = New System.Drawing.Size(115, 21)
		Me.cmbSort.Location = New System.Drawing.Point(63, 48)
		Me.cmbSort.Items.AddRange(New Object(){"Ascending", "Descending"})
		Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSort.TabIndex = 11
		Me.cmbSort.BackColor = System.Drawing.SystemColors.Window
		Me.cmbSort.CausesValidation = True
		Me.cmbSort.Enabled = True
		Me.cmbSort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbSort.IntegralHeight = True
		Me.cmbSort.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbSort.Sorted = False
		Me.cmbSort.TabStop = True
		Me.cmbSort.Visible = True
		Me.cmbSort.Name = "cmbSort"
		Me.cmbSortField.Size = New System.Drawing.Size(115, 21)
		Me.cmbSortField.Location = New System.Drawing.Point(63, 24)
		Me.cmbSortField.Items.AddRange(New Object(){"Item Name", "Cost", "Selling", "Gross Profit", "Gross Profit %", "Quantity Sold"})
		Me.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSortField.TabIndex = 9
		Me.cmbSortField.BackColor = System.Drawing.SystemColors.Window
		Me.cmbSortField.CausesValidation = True
		Me.cmbSortField.Enabled = True
		Me.cmbSortField.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbSortField.IntegralHeight = True
		Me.cmbSortField.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbSortField.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbSortField.Sorted = False
		Me.cmbSortField.TabStop = True
		Me.cmbSortField.Visible = True
		Me.cmbSortField.Name = "cmbSortField"
		Me._lbl_0.Text = "Sort Field:"
		Me._lbl_0.Size = New System.Drawing.Size(47, 13)
		Me._lbl_0.Location = New System.Drawing.Point(12, 30)
		Me._lbl_0.TabIndex = 8
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
		Me._lbl_2.Text = "Sort Order:"
		Me._lbl_2.Size = New System.Drawing.Size(51, 13)
		Me._lbl_2.Location = New System.Drawing.Point(9, 54)
		Me._lbl_2.TabIndex = 10
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
		Me._Frame1_0.Text = "&1. Report Options"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(232, 139)
		Me._Frame1_0.Location = New System.Drawing.Point(12, 9)
		Me._Frame1_0.TabIndex = 0
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.chkPageBreak.Text = "Page Break after each Group."
		Me.chkPageBreak.Enabled = False
		Me.chkPageBreak.Size = New System.Drawing.Size(163, 13)
		Me.chkPageBreak.Location = New System.Drawing.Point(54, 114)
		Me.chkPageBreak.TabIndex = 6
		Me.chkPageBreak.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPageBreak.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPageBreak.BackColor = System.Drawing.SystemColors.Control
		Me.chkPageBreak.CausesValidation = True
		Me.chkPageBreak.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkPageBreak.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPageBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPageBreak.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPageBreak.TabStop = True
		Me.chkPageBreak.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPageBreak.Visible = True
		Me.chkPageBreak.Name = "chkPageBreak"
		Me.cmbGroup.Enabled = False
		Me.cmbGroup.Size = New System.Drawing.Size(106, 21)
		Me.cmbGroup.Location = New System.Drawing.Point(108, 93)
		Me.cmbGroup.Items.AddRange(New Object(){"Pricing Group", "Stock Group", "Supplier", "Report Group"})
		Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbGroup.TabIndex = 5
		Me.cmbGroup.BackColor = System.Drawing.SystemColors.Window
		Me.cmbGroup.CausesValidation = True
		Me.cmbGroup.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbGroup.IntegralHeight = True
		Me.cmbGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbGroup.Sorted = False
		Me.cmbGroup.TabStop = True
		Me.cmbGroup.Visible = True
		Me.cmbGroup.Name = "cmbGroup"
		Me._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.Text = "Normal Item Listing"
		Me._optType_0.Size = New System.Drawing.Size(115, 13)
		Me._optType_0.Location = New System.Drawing.Point(12, 21)
		Me._optType_0.TabIndex = 1
		Me._optType_0.Checked = True
		Me._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.BackColor = System.Drawing.SystemColors.Control
		Me._optType_0.CausesValidation = True
		Me._optType_0.Enabled = True
		Me._optType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_0.TabStop = True
		Me._optType_0.Visible = True
		Me._optType_0.Name = "_optType_0"
		Me._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.Text = "Items Per Group"
		Me._optType_1.Size = New System.Drawing.Size(115, 13)
		Me._optType_1.Location = New System.Drawing.Point(12, 39)
		Me._optType_1.TabIndex = 2
		Me._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.BackColor = System.Drawing.SystemColors.Control
		Me._optType_1.CausesValidation = True
		Me._optType_1.Enabled = True
		Me._optType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_1.TabStop = True
		Me._optType_1.Checked = False
		Me._optType_1.Visible = True
		Me._optType_1.Name = "_optType_1"
		Me._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.Text = "Group Totals"
		Me._optType_2.Size = New System.Drawing.Size(115, 13)
		Me._optType_2.Location = New System.Drawing.Point(12, 57)
		Me._optType_2.TabIndex = 3
		Me._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.BackColor = System.Drawing.SystemColors.Control
		Me._optType_2.CausesValidation = True
		Me._optType_2.Enabled = True
		Me._optType_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_2.TabStop = True
		Me._optType_2.Checked = False
		Me._optType_2.Visible = True
		Me._optType_2.Name = "_optType_2"
		Me._lbl_3.Text = "Group on:"
		Me._lbl_3.Size = New System.Drawing.Size(47, 13)
		Me._lbl_3.Location = New System.Drawing.Point(54, 96)
		Me._lbl_3.TabIndex = 4
		Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_3.BackColor = System.Drawing.Color.Transparent
		Me._lbl_3.Enabled = True
		Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_3.UseMnemonic = True
		Me._lbl_3.Visible = True
		Me._lbl_3.AutoSize = True
		Me._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_3.Name = "_lbl_3"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 43)
		Me.cmdExit.Location = New System.Drawing.Point(12, 408)
		Me.cmdExit.TabIndex = 16
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "Show/&Print Report"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 43)
		Me.cmdLoad.Location = New System.Drawing.Point(164, 408)
		Me.cmdLoad.TabIndex = 15
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.Controls.Add(_Frame1_2)
		Me.Controls.Add(_Frame1_1)
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdLoad)
		Me._Frame1_2.Controls.Add(cmdGroup)
		Me._Frame1_2.Controls.Add(lblGroup)
		Me._Frame1_1.Controls.Add(cmbSort)
		Me._Frame1_1.Controls.Add(cmbSortField)
		Me._Frame1_1.Controls.Add(_lbl_0)
		Me._Frame1_1.Controls.Add(_lbl_2)
		Me._Frame1_0.Controls.Add(chkPageBreak)
		Me._Frame1_0.Controls.Add(cmbGroup)
		Me._Frame1_0.Controls.Add(_optType_0)
		Me._Frame1_0.Controls.Add(_optType_1)
		Me._Frame1_0.Controls.Add(_optType_2)
		Me._Frame1_0.Controls.Add(_lbl_3)
        'Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
        'Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.optType.SetIndex(_optType_0, CType(0, Short))
        'Me.optType.SetIndex(_optType_1, CType(1, Short))
        'Me.optType.SetIndex(_optType_2, CType(2, Short))
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._Frame1_2.ResumeLayout(False)
		Me._Frame1_1.ResumeLayout(False)
		Me._Frame1_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class