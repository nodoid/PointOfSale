<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVselect
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
	Public WithEvents cmdVoucher As System.Windows.Forms.Button
	Public WithEvents cmdNewFnV As System.Windows.Forms.Button
	Public WithEvents prgBar As System.Windows.Forms.ProgressBar
	Public WithEvents lblNum As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAirTime As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdImport As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmddelete As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents _lvImport_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvImport As System.Windows.Forms.ListView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmdNew As System.Windows.Forms.Button
	Public CDOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVselect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdVoucher = New System.Windows.Forms.Button
		Me.cmdNewFnV = New System.Windows.Forms.Button
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.prgBar = New System.Windows.Forms.ProgressBar
		Me.lblNum = New System.Windows.Forms.Label
		Me.cmdAirTime = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdImport = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.cmddelete = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.lvImport = New System.Windows.Forms.ListView
		Me._lvImport_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.cmdNew = New System.Windows.Forms.Button
		Me.CDOpen = New System.Windows.Forms.OpenFileDialog
		Me.Label1 = New System.Windows.Forms.Label
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Frame2.SuspendLayout()
		Me._Frame1_0.SuspendLayout()
		Me.lvImport.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select GRV Type ..."
		Me.ClientSize = New System.Drawing.Size(590, 465)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmGRVselect"
		Me.cmdVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVoucher.Text = "&4POS Voucher G.R.V"
		Me.cmdVoucher.Size = New System.Drawing.Size(73, 49)
		Me.cmdVoucher.Location = New System.Drawing.Point(496, 336)
		Me.cmdVoucher.TabIndex = 15
		Me.cmdVoucher.Visible = False
		Me.cmdVoucher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVoucher.CausesValidation = True
		Me.cmdVoucher.Enabled = True
		Me.cmdVoucher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVoucher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVoucher.TabStop = True
		Me.cmdVoucher.Name = "cmdVoucher"
		Me.cmdNewFnV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNewFnV.Text = "&Fruit n Veg G.R.V"
		Me.cmdNewFnV.Size = New System.Drawing.Size(73, 49)
		Me.cmdNewFnV.Location = New System.Drawing.Point(416, 390)
		Me.cmdNewFnV.TabIndex = 14
		Me.cmdNewFnV.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNewFnV.CausesValidation = True
		Me.cmdNewFnV.Enabled = True
		Me.cmdNewFnV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNewFnV.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNewFnV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNewFnV.TabStop = True
		Me.cmdNewFnV.Name = "cmdNewFnV"
		Me.Frame2.Text = "Importing Airtime file "
		Me.Frame2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Frame2.Size = New System.Drawing.Size(557, 65)
		Me.Frame2.Location = New System.Drawing.Point(16, 280)
		Me.Frame2.TabIndex = 11
		Me.Frame2.Visible = False
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.prgBar.Size = New System.Drawing.Size(549, 31)
		Me.prgBar.Location = New System.Drawing.Point(8, 24)
		Me.prgBar.TabIndex = 12
		Me.prgBar.Name = "prgBar"
		Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblNum.BackColor = System.Drawing.Color.Transparent
		Me.lblNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblNum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNum.Size = New System.Drawing.Size(283, 17)
		Me.lblNum.Location = New System.Drawing.Point(120, 40)
		Me.lblNum.TabIndex = 13
		Me.lblNum.Enabled = True
		Me.lblNum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNum.UseMnemonic = True
		Me.lblNum.Visible = True
		Me.lblNum.AutoSize = False
		Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNum.Name = "lblNum"
		Me.cmdAirTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAirTime.Text = "&Air Time G.R.V"
		Me.cmdAirTime.Size = New System.Drawing.Size(73, 49)
		Me.cmdAirTime.Location = New System.Drawing.Point(336, 390)
		Me.cmdAirTime.TabIndex = 10
		Me.cmdAirTime.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAirTime.CausesValidation = True
		Me.cmdAirTime.Enabled = True
		Me.cmdAirTime.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAirTime.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAirTime.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAirTime.TabStop = True
		Me.cmdAirTime.Name = "cmdAirTime"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Load Selected G.R.V."
		Me.cmdEdit.Size = New System.Drawing.Size(113, 49)
		Me.cmdEdit.Location = New System.Drawing.Point(15, 390)
		Me.cmdEdit.TabIndex = 7
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.TabStop = True
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImport.Text = "&Import a G.R.V."
		Me.cmdImport.Size = New System.Drawing.Size(73, 49)
		Me.cmdImport.Location = New System.Drawing.Point(256, 390)
		Me.cmdImport.TabIndex = 5
		Me.cmdImport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImport.CausesValidation = True
		Me.cmdImport.Enabled = True
		Me.cmdImport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImport.TabStop = True
		Me.cmdImport.Name = "cmdImport"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(73, 49)
		Me.cmdExit.Location = New System.Drawing.Point(496, 390)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me._Frame1_0.Text = "Imported GRV Data"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(559, 370)
		Me._Frame1_0.Location = New System.Drawing.Point(15, 12)
		Me._Frame1_0.TabIndex = 1
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.cmddelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmddelete.Text = "&Delete G.R.V"
		Me.cmddelete.Size = New System.Drawing.Size(111, 27)
		Me.cmddelete.Location = New System.Drawing.Point(440, 8)
		Me.cmddelete.TabIndex = 9
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
		Me.lvImport.Size = New System.Drawing.Size(541, 316)
		Me.lvImport.Location = New System.Drawing.Point(9, 40)
		Me.lvImport.TabIndex = 2
		Me.lvImport.View = System.Windows.Forms.View.Details
		Me.lvImport.LabelEdit = False
		Me.lvImport.LabelWrap = True
		Me.lvImport.HideSelection = False
		Me.lvImport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvImport.BackColor = System.Drawing.SystemColors.Window
		Me.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvImport.Name = "lvImport"
		Me._lvImport_ColumnHeader_1.Text = "Supplier"
		Me._lvImport_ColumnHeader_1.Width = 177
		Me._lvImport_ColumnHeader_2.Text = "Order Date"
		Me._lvImport_ColumnHeader_2.Width = 142
		Me._lvImport_ColumnHeader_3.Text = "Reference"
		Me._lvImport_ColumnHeader_3.Width = 165
		Me._lvImport_ColumnHeader_4.Text = "Invoice #"
		Me._lvImport_ColumnHeader_4.Width = 170
		Me._lvImport_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_5.Text = "Amount"
		Me._lvImport_ColumnHeader_5.Width = 95
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
		Me.cmdNew.Text = "Create a N&ew G.R.V."
		Me.cmdNew.Size = New System.Drawing.Size(113, 49)
		Me.cmdNew.Location = New System.Drawing.Point(136, 390)
		Me.cmdNew.TabIndex = 6
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.TabStop = True
		Me.cmdNew.Name = "cmdNew"
		Me.CDOpen.Title = "Select GRV import file ..."
		Me.Label1.Text = "Import GRV field sequence: Barcode, Quantity, Description, Cost, Selling"
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label1.Size = New System.Drawing.Size(426, 16)
		Me.Label1.Location = New System.Drawing.Point(105, 444)
		Me.Label1.TabIndex = 8
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdVoucher)
		Me.Controls.Add(cmdNewFnV)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(cmdAirTime)
		Me.Controls.Add(cmdEdit)
		Me.Controls.Add(cmdImport)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(cmdNew)
		Me.Controls.Add(Label1)
		Me.Frame2.Controls.Add(prgBar)
		Me.Frame2.Controls.Add(lblNum)
		Me._Frame1_0.Controls.Add(cmddelete)
		Me._Frame1_0.Controls.Add(txtSearch)
		Me._Frame1_0.Controls.Add(lvImport)
		Me._Frame1_0.Controls.Add(_lbl_0)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_1)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_2)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_3)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_4)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_5)
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame2.ResumeLayout(False)
		Me._Frame1_0.ResumeLayout(False)
		Me.lvImport.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class