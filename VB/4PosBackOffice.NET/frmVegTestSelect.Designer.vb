<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVegTestSelect
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
	Public WithEvents cmdRepair As System.Windows.Forms.Button
	Public WithEvents cmdRevST As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmddelete As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents _lvImport_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvImport As System.Windows.Forms.ListView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmdNew As System.Windows.Forms.Button
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVegTestSelect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdRepair = New System.Windows.Forms.Button
		Me.cmdRevST = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.cmddelete = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.lvImport = New System.Windows.Forms.ListView
		Me._lvImport_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.cmdNew = New System.Windows.Forms.Button
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me._Frame1_0.SuspendLayout()
		Me.lvImport.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "4VEG Production List"
		Me.ClientSize = New System.Drawing.Size(574, 449)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmVegTestSelect"
		Me.cmdRepair.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRepair.Text = "Repair Product"
		Me.cmdRepair.Size = New System.Drawing.Size(73, 49)
		Me.cmdRepair.Location = New System.Drawing.Point(424, 390)
		Me.cmdRepair.TabIndex = 9
		Me.cmdRepair.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRepair.CausesValidation = True
		Me.cmdRepair.Enabled = True
		Me.cmdRepair.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRepair.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRepair.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRepair.TabStop = True
		Me.cmdRepair.Name = "cmdRepair"
		Me.cmdRevST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRevST.Text = "Stock Receiving"
		Me.cmdRevST.Size = New System.Drawing.Size(73, 49)
		Me.cmdRevST.Location = New System.Drawing.Point(344, 390)
		Me.cmdRevST.TabIndex = 7
		Me.cmdRevST.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRevST.CausesValidation = True
		Me.cmdRevST.Enabled = True
		Me.cmdRevST.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRevST.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRevST.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRevST.TabStop = True
		Me.cmdRevST.Name = "cmdRevST"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Load Selected Production Test"
		Me.cmdEdit.Size = New System.Drawing.Size(161, 49)
		Me.cmdEdit.Location = New System.Drawing.Point(8, 390)
		Me.cmdEdit.TabIndex = 6
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.TabStop = True
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(65, 49)
		Me.cmdExit.Location = New System.Drawing.Point(504, 390)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(559, 370)
		Me._Frame1_0.Location = New System.Drawing.Point(8, 8)
		Me._Frame1_0.TabIndex = 1
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.cmddelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmddelete.Text = "&Delete Production Test"
		Me.cmddelete.Size = New System.Drawing.Size(151, 27)
		Me.cmddelete.Location = New System.Drawing.Point(400, 16)
		Me.cmddelete.TabIndex = 8
		Me.cmddelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmddelete.CausesValidation = True
		Me.cmddelete.Enabled = True
		Me.cmddelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmddelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmddelete.TabStop = True
		Me.cmddelete.Name = "cmddelete"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(283, 19)
		Me.txtSearch.Location = New System.Drawing.Point(52, 18)
		Me.txtSearch.TabIndex = 3
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
		Me.lvImport.Size = New System.Drawing.Size(541, 308)
		Me.lvImport.Location = New System.Drawing.Point(9, 48)
		Me.lvImport.TabIndex = 2
		Me.lvImport.View = System.Windows.Forms.View.Details
		Me.lvImport.LabelEdit = False
		Me.lvImport.LabelWrap = True
		Me.lvImport.HideSelection = False
		Me.lvImport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvImport.BackColor = System.Drawing.SystemColors.Window
		Me.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvImport.Name = "lvImport"
		Me._lvImport_ColumnHeader_1.Text = "Production Test Name"
		Me._lvImport_ColumnHeader_1.Width = 219
		Me._lvImport_ColumnHeader_2.Text = "Production Date"
		Me._lvImport_ColumnHeader_2.Width = 171
		Me._lvImport_ColumnHeader_3.Text = "Person Cutting"
		Me._lvImport_ColumnHeader_3.Width = 212
		Me._lvImport_ColumnHeader_4.Text = "Main Stock Item"
		Me._lvImport_ColumnHeader_4.Width = 311
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "&Search :"
		Me._lbl_0.Size = New System.Drawing.Size(40, 13)
		Me._lbl_0.Location = New System.Drawing.Point(9, 21)
		Me._lbl_0.TabIndex = 4
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
		Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNew.Text = "Create a N&ew Production Test"
		Me.cmdNew.Size = New System.Drawing.Size(161, 49)
		Me.cmdNew.Location = New System.Drawing.Point(176, 390)
		Me.cmdNew.TabIndex = 5
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.TabStop = True
		Me.cmdNew.Name = "cmdNew"
		Me.Controls.Add(cmdRepair)
		Me.Controls.Add(cmdRevST)
		Me.Controls.Add(cmdEdit)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(cmdNew)
		Me._Frame1_0.Controls.Add(cmddelete)
		Me._Frame1_0.Controls.Add(txtSearch)
		Me._Frame1_0.Controls.Add(lvImport)
		Me._Frame1_0.Controls.Add(_lbl_0)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_1)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_2)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_3)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_4)
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._Frame1_0.ResumeLayout(False)
		Me.lvImport.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class