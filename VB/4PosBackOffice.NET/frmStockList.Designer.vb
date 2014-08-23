<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockList
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
	Public WithEvents cmdBOM As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNamespace As System.Windows.Forms.Button
	Public WithEvents DataList1 As myDataGridView
	Public WithEvents txtBCode As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents lblRecords As System.Windows.Forms.Label
	Public WithEvents lbl As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockList))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdBOM = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNamespace = New System.Windows.Forms.Button
		Me.DataList1 = New myDataGridView
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtBCode = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblRecords = New System.Windows.Forms.Label
		Me.lbl = New System.Windows.Forms.Label
		Me.lblHeading = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select a Stock Item"
		Me.ClientSize = New System.Drawing.Size(352, 449)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockList"
		Me.cmdBOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBOM.Text = "&Show Items with Bill of Materials"
		Me.cmdBOM.Size = New System.Drawing.Size(97, 52)
		Me.cmdBOM.Location = New System.Drawing.Point(250, 96)
		Me.cmdBOM.TabIndex = 10
		Me.cmdBOM.TabStop = False
		Me.cmdBOM.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBOM.CausesValidation = True
		Me.cmdBOM.Enabled = True
		Me.cmdBOM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBOM.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBOM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBOM.Name = "cmdBOM"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(294, 19)
		Me.txtSearch.Location = New System.Drawing.Point(53, 8)
		Me.txtSearch.TabIndex = 0
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
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(252, 318)
		Me.cmdExit.TabIndex = 6
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNamespace.Text = "&Filter"
		Me.cmdNamespace.Size = New System.Drawing.Size(97, 52)
		Me.cmdNamespace.Location = New System.Drawing.Point(250, 32)
		Me.cmdNamespace.TabIndex = 5
		Me.cmdNamespace.TabStop = False
		Me.cmdNamespace.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNamespace.CausesValidation = True
		Me.cmdNamespace.Enabled = True
		Me.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNamespace.Name = "cmdNamespace"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(244, 342)
		Me.DataList1.Location = New System.Drawing.Point(2, 32)
		Me.DataList1.TabIndex = 4
		Me.DataList1.Name = "DataList1"
		Me.Frame1.Text = "Search . . ."
		Me.Frame1.Size = New System.Drawing.Size(345, 73)
		Me.Frame1.Location = New System.Drawing.Point(2, 32)
		Me.Frame1.TabIndex = 1
		Me.Frame1.Visible = False
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.txtBCode.AutoSize = False
		Me.txtBCode.Size = New System.Drawing.Size(182, 19)
		Me.txtBCode.Location = New System.Drawing.Point(59, 16)
		Me.txtBCode.TabIndex = 2
		Me.txtBCode.AcceptsReturn = True
		Me.txtBCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtBCode.CausesValidation = True
		Me.txtBCode.Enabled = True
		Me.txtBCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBCode.HideSelection = True
		Me.txtBCode.ReadOnly = False
		Me.txtBCode.Maxlength = 0
		Me.txtBCode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBCode.MultiLine = False
		Me.txtBCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBCode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBCode.TabStop = True
		Me.txtBCode.Visible = True
		Me.txtBCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBCode.Name = "txtBCode"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "&Barcode :"
		Me.Label1.Size = New System.Drawing.Size(46, 13)
		Me.Label1.Location = New System.Drawing.Point(10, 21)
		Me.Label1.TabIndex = 3
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
		Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblRecords.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecords.Size = New System.Drawing.Size(337, 15)
		Me.lblRecords.Location = New System.Drawing.Point(8, 426)
		Me.lblRecords.TabIndex = 9
		Me.lblRecords.BackColor = System.Drawing.SystemColors.Control
		Me.lblRecords.Enabled = True
		Me.lblRecords.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRecords.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRecords.UseMnemonic = True
		Me.lblRecords.Visible = True
		Me.lblRecords.AutoSize = False
		Me.lblRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRecords.Name = "lblRecords"
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lbl.Text = "&Search :"
		Me.lbl.Size = New System.Drawing.Size(40, 13)
		Me.lbl.Location = New System.Drawing.Point(8, 8)
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
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Size = New System.Drawing.Size(349, 70)
		Me.lblHeading.Location = New System.Drawing.Point(0, 376)
		Me.lblHeading.TabIndex = 7
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
		Me.Controls.Add(cmdBOM)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdNamespace)
		Me.Controls.Add(DataList1)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(lblRecords)
		Me.Controls.Add(lbl)
		Me.Controls.Add(lblHeading)
		Me.Frame1.Controls.Add(txtBCode)
		Me.Frame1.Controls.Add(Label1)
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class