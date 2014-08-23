<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockValSelect
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
	Public WithEvents lstFilter As System.Windows.Forms.CheckedListBox
	Public WithEvents ckbGrp As System.Windows.Forms.CheckBox
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents cmdShow As System.Windows.Forms.Button
	Public WithEvents optSum As System.Windows.Forms.RadioButton
	Public WithEvents optDel As System.Windows.Forms.RadioButton
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents DataList1 As myDataGridView
	Public WithEvents lbl As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockValSelect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstFilter = New System.Windows.Forms.CheckedListBox
		Me.ckbGrp = New System.Windows.Forms.CheckBox
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.cmdShow = New System.Windows.Forms.Button
		Me.optSum = New System.Windows.Forms.RadioButton
		Me.optDel = New System.Windows.Forms.RadioButton
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me.lblHeading = New System.Windows.Forms.Label
		Me.DataList1 = New myDataGridView
		Me.lbl = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Stock Value Report"
		Me.ClientSize = New System.Drawing.Size(354, 159)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockValSelect"
		Me.lstFilter.Size = New System.Drawing.Size(247, 79)
		Me.lstFilter.Location = New System.Drawing.Point(8, 72)
		Me.lstFilter.TabIndex = 10
		Me.lstFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstFilter.BackColor = System.Drawing.SystemColors.Window
		Me.lstFilter.CausesValidation = True
		Me.lstFilter.Enabled = True
		Me.lstFilter.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstFilter.IntegralHeight = True
		Me.lstFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstFilter.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstFilter.Sorted = False
		Me.lstFilter.TabStop = True
		Me.lstFilter.Visible = True
		Me.lstFilter.MultiColumn = False
		Me.lstFilter.Name = "lstFilter"
		Me.ckbGrp.Text = "Select Group ?"
		Me.ckbGrp.Size = New System.Drawing.Size(97, 17)
		Me.ckbGrp.Location = New System.Drawing.Point(160, 48)
		Me.ckbGrp.TabIndex = 9
		Me.ckbGrp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckbGrp.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckbGrp.BackColor = System.Drawing.SystemColors.Control
		Me.ckbGrp.CausesValidation = True
		Me.ckbGrp.Enabled = True
		Me.ckbGrp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckbGrp.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckbGrp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckbGrp.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckbGrp.TabStop = True
		Me.ckbGrp.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckbGrp.Visible = True
		Me.ckbGrp.Name = "ckbGrp"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(94, 19)
		Me.txtSearch.Location = New System.Drawing.Point(51, 46)
		Me.txtSearch.TabIndex = 7
		Me.txtSearch.AcceptsReturn = True
		Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch.CausesValidation = True
		Me.txtSearch.Enabled = True
		Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch.HideSelection = True
		Me.txtSearch.ReadOnly = False
		Me.txtSearch.Maxlength = 0
		Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch.MultiLine = False
		Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch.TabStop = True
		Me.txtSearch.Visible = True
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch.Name = "txtSearch"
		Me.cmdShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdShow.Text = "&Print"
		Me.cmdShow.Size = New System.Drawing.Size(73, 29)
		Me.cmdShow.Location = New System.Drawing.Point(272, 124)
		Me.cmdShow.TabIndex = 5
		Me.cmdShow.TabStop = False
		Me.cmdShow.BackColor = System.Drawing.SystemColors.Control
		Me.cmdShow.CausesValidation = True
		Me.cmdShow.Enabled = True
		Me.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdShow.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdShow.Name = "cmdShow"
		Me.optSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSum.Text = "Summary"
		Me.optSum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optSum.Size = New System.Drawing.Size(96, 23)
		Me.optSum.Location = New System.Drawing.Point(266, 86)
		Me.optSum.TabIndex = 4
		Me.optSum.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSum.BackColor = System.Drawing.SystemColors.Control
		Me.optSum.CausesValidation = True
		Me.optSum.Enabled = True
		Me.optSum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optSum.Cursor = System.Windows.Forms.Cursors.Default
		Me.optSum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optSum.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optSum.TabStop = True
		Me.optSum.Checked = False
		Me.optSum.Visible = True
		Me.optSum.Name = "optSum"
		Me.optDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optDel.Text = "Detail"
		Me.optDel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optDel.Size = New System.Drawing.Size(72, 23)
		Me.optDel.Location = New System.Drawing.Point(266, 46)
		Me.optDel.TabIndex = 3
		Me.optDel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optDel.BackColor = System.Drawing.SystemColors.Control
		Me.optDel.CausesValidation = True
		Me.optDel.Enabled = True
		Me.optDel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optDel.Cursor = System.Windows.Forms.Cursors.Default
		Me.optDel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optDel.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optDel.TabStop = True
		Me.optDel.Checked = False
		Me.optDel.Visible = True
		Me.optDel.Name = "optDel"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(354, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(272, 2)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.lblHeading.Text = "Select option for Detail / Summary"
		Me.lblHeading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblHeading.ForeColor = System.Drawing.Color.White
		Me.lblHeading.Size = New System.Drawing.Size(273, 21)
		Me.lblHeading.Location = New System.Drawing.Point(2, 8)
		Me.lblHeading.TabIndex = 2
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.BackColor = System.Drawing.Color.Transparent
		Me.lblHeading.Enabled = True
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblHeading.Name = "lblHeading"
		'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(244, 82)
		Me.DataList1.Location = New System.Drawing.Point(8, 168)
		Me.DataList1.TabIndex = 6
		Me.DataList1.Name = "DataList1"
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lbl.Text = "&Search :"
		Me.lbl.Size = New System.Drawing.Size(40, 13)
		Me.lbl.Location = New System.Drawing.Point(8, 49)
		Me.lbl.TabIndex = 8
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
		Me.Controls.Add(lstFilter)
		Me.Controls.Add(ckbGrp)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(cmdShow)
		Me.Controls.Add(optSum)
		Me.Controls.Add(optDel)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(DataList1)
		Me.Controls.Add(lbl)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(lblHeading)
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class