<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportProductPerfomace
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
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents _optType_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmbGroup As System.Windows.Forms.ComboBox
	Public WithEvents chkPageBreak As System.Windows.Forms.CheckBox
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmbSortField As System.Windows.Forms.ComboBox
	Public WithEvents cmbSort As System.Windows.Forms.ComboBox
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdGroup As System.Windows.Forms.Button
	Public WithEvents lblGroup As System.Windows.Forms.Label
	Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me._Frame1_0 = New System.Windows.Forms.GroupBox()
        Me._optType_2 = New System.Windows.Forms.RadioButton()
        Me._optType_1 = New System.Windows.Forms.RadioButton()
        Me._optType_0 = New System.Windows.Forms.RadioButton()
        Me.cmbGroup = New System.Windows.Forms.ComboBox()
        Me.chkPageBreak = New System.Windows.Forms.CheckBox()
        Me._lbl_3 = New System.Windows.Forms.Label()
        Me._Frame1_1 = New System.Windows.Forms.GroupBox()
        Me.cmbSortField = New System.Windows.Forms.ComboBox()
        Me.cmbSort = New System.Windows.Forms.ComboBox()
        Me._lbl_2 = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._Frame1_2 = New System.Windows.Forms.GroupBox()
        Me.cmdGroup = New System.Windows.Forms.Button()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me._Frame1_0.SuspendLayout()
        Me._Frame1_1.SuspendLayout()
        Me._Frame1_2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdLoad
        '
        Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.Location = New System.Drawing.Point(160, 356)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoad.Size = New System.Drawing.Size(79, 43)
        Me.cmdLoad.TabIndex = 16
        Me.cmdLoad.Text = "Export Now"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(6, 356)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(79, 43)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        '_Frame1_0
        '
        Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_0.Controls.Add(Me._optType_2)
        Me._Frame1_0.Controls.Add(Me._optType_1)
        Me._Frame1_0.Controls.Add(Me._optType_0)
        Me._Frame1_0.Controls.Add(Me.cmbGroup)
        Me._Frame1_0.Controls.Add(Me.chkPageBreak)
        Me._Frame1_0.Controls.Add(Me._lbl_3)
        Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_0.Location = New System.Drawing.Point(6, 4)
        Me._Frame1_0.Name = "_Frame1_0"
        Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_0.Size = New System.Drawing.Size(232, 105)
        Me._Frame1_0.TabIndex = 8
        Me._Frame1_0.TabStop = False
        Me._Frame1_0.Text = "&1. Export Options"
        '
        '_optType_2
        '
        Me._optType_2.BackColor = System.Drawing.SystemColors.Control
        Me._optType_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optType_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optType_2.Location = New System.Drawing.Point(12, 57)
        Me._optType_2.Name = "_optType_2"
        Me._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optType_2.Size = New System.Drawing.Size(115, 22)
        Me._optType_2.TabIndex = 13
        Me._optType_2.TabStop = True
        Me._optType_2.Text = "Group Totals"
        Me._optType_2.UseVisualStyleBackColor = False
        '
        '_optType_1
        '
        Me._optType_1.BackColor = System.Drawing.SystemColors.Control
        Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optType_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optType_1.Location = New System.Drawing.Point(12, 39)
        Me._optType_1.Name = "_optType_1"
        Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optType_1.Size = New System.Drawing.Size(115, 18)
        Me._optType_1.TabIndex = 12
        Me._optType_1.TabStop = True
        Me._optType_1.Text = "Items Per Group"
        Me._optType_1.UseVisualStyleBackColor = False
        '
        '_optType_0
        '
        Me._optType_0.BackColor = System.Drawing.SystemColors.Control
        Me._optType_0.Checked = True
        Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optType_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optType_0.Location = New System.Drawing.Point(12, 21)
        Me._optType_0.Name = "_optType_0"
        Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optType_0.Size = New System.Drawing.Size(115, 20)
        Me._optType_0.TabIndex = 11
        Me._optType_0.TabStop = True
        Me._optType_0.Text = "Normal Item Listing"
        Me._optType_0.UseVisualStyleBackColor = False
        '
        'cmbGroup
        '
        Me.cmbGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroup.Enabled = False
        Me.cmbGroup.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbGroup.Items.AddRange(New Object() {"Pricing Group", "Stock Group", "Supplier"})
        Me.cmbGroup.Location = New System.Drawing.Point(110, 78)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbGroup.Size = New System.Drawing.Size(106, 22)
        Me.cmbGroup.TabIndex = 10
        '
        'chkPageBreak
        '
        Me.chkPageBreak.BackColor = System.Drawing.SystemColors.Control
        Me.chkPageBreak.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPageBreak.Enabled = False
        Me.chkPageBreak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPageBreak.Location = New System.Drawing.Point(30, 130)
        Me.chkPageBreak.Name = "chkPageBreak"
        Me.chkPageBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPageBreak.Size = New System.Drawing.Size(163, 13)
        Me.chkPageBreak.TabIndex = 9
        Me.chkPageBreak.Text = "Page Break after each Group."
        Me.chkPageBreak.UseVisualStyleBackColor = False
        Me.chkPageBreak.Visible = False
        '
        '_lbl_3
        '
        Me._lbl_3.AutoSize = True
        Me._lbl_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Location = New System.Drawing.Point(54, 82)
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.Size = New System.Drawing.Size(61, 14)
        Me._lbl_3.TabIndex = 14
        Me._lbl_3.Text = "Group on:"
        '
        '_Frame1_1
        '
        Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_1.Controls.Add(Me.cmbSortField)
        Me._Frame1_1.Controls.Add(Me.cmbSort)
        Me._Frame1_1.Controls.Add(Me._lbl_2)
        Me._Frame1_1.Controls.Add(Me._lbl_0)
        Me._Frame1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_1.Location = New System.Drawing.Point(6, 114)
        Me._Frame1_1.Name = "_Frame1_1"
        Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_1.Size = New System.Drawing.Size(232, 85)
        Me._Frame1_1.TabIndex = 3
        Me._Frame1_1.TabStop = False
        Me._Frame1_1.Text = "&2. Export Sort Options"
        '
        'cmbSortField
        '
        Me.cmbSortField.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSortField.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSortField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSortField.Items.AddRange(New Object() {"Item Name", "Cost", "Selling", "Gross Profit", "Gross Profit %", "Quantity Sold"})
        Me.cmbSortField.Location = New System.Drawing.Point(80, 27)
        Me.cmbSortField.Name = "cmbSortField"
        Me.cmbSortField.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSortField.Size = New System.Drawing.Size(115, 22)
        Me.cmbSortField.TabIndex = 5
        '
        'cmbSort
        '
        Me.cmbSort.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSort.Items.AddRange(New Object() {"Ascending", "Descending"})
        Me.cmbSort.Location = New System.Drawing.Point(80, 51)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSort.Size = New System.Drawing.Size(115, 22)
        Me.cmbSort.TabIndex = 4
        '
        '_lbl_2
        '
        Me._lbl_2.AutoSize = True
        Me._lbl_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(9, 54)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(68, 14)
        Me._lbl_2.TabIndex = 7
        Me._lbl_2.Text = "Sort Order:"
        '
        '_lbl_0
        '
        Me._lbl_0.AutoSize = True
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(12, 30)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(62, 14)
        Me._lbl_0.TabIndex = 6
        Me._lbl_0.Text = "Sort Field:"
        '
        '_Frame1_2
        '
        Me._Frame1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_2.Controls.Add(Me.cmdGroup)
        Me._Frame1_2.Controls.Add(Me.lblGroup)
        Me._Frame1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_2.Location = New System.Drawing.Point(6, 204)
        Me._Frame1_2.Name = "_Frame1_2"
        Me._Frame1_2.Padding = New System.Windows.Forms.Padding(0)
        Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_2.Size = New System.Drawing.Size(232, 145)
        Me._Frame1_2.TabIndex = 0
        Me._Frame1_2.TabStop = False
        Me._Frame1_2.Text = "&3. Export Filter"
        '
        'cmdGroup
        '
        Me.cmdGroup.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroup.Location = New System.Drawing.Point(129, 105)
        Me.cmdGroup.Name = "cmdGroup"
        Me.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGroup.Size = New System.Drawing.Size(97, 31)
        Me.cmdGroup.TabIndex = 1
        Me.cmdGroup.Text = "&Filter"
        Me.cmdGroup.UseVisualStyleBackColor = False
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGroup.Location = New System.Drawing.Point(6, 21)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGroup.Size = New System.Drawing.Size(220, 76)
        Me.lblGroup.TabIndex = 2
        Me.lblGroup.Text = "lblGroup"
        '
        'frmExportProductPerfomace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(243, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me._Frame1_0)
        Me.Controls.Add(Me._Frame1_1)
        Me.Controls.Add(Me._Frame1_2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmExportProductPerfomace"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Product Perfomance"
        Me._Frame1_0.ResumeLayout(False)
        Me._Frame1_0.PerformLayout()
        Me._Frame1_1.ResumeLayout(False)
        Me._Frame1_1.PerformLayout()
        Me._Frame1_2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class