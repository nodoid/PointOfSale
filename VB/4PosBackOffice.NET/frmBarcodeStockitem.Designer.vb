<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBarcodeStockitem
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdClear As System.Windows.Forms.Button
	Public WithEvents cmdShow As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents txtEdit As System.Windows.Forms.TextBox
	Public WithEvents _txtSearch_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtSearch_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtSearch_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtSearch_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtSearch_0 As System.Windows.Forms.TextBox
    Public WithEvents gridEdit As myDataGridView
	Public cmdDlgOpen As System.Windows.Forms.OpenFileDialog
    'Public WithEvents txtSearch As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBarcodeStockitem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdClear = New System.Windows.Forms.Button
		Me.cmdShow = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.txtEdit = New System.Windows.Forms.TextBox
		Me._txtSearch_4 = New System.Windows.Forms.TextBox
		Me._txtSearch_3 = New System.Windows.Forms.TextBox
		Me._txtSearch_2 = New System.Windows.Forms.TextBox
		Me._txtSearch_1 = New System.Windows.Forms.TextBox
		Me._txtSearch_0 = New System.Windows.Forms.TextBox
        Me.gridEdit = New myDataGridView
		Me.cmdDlgOpen = New System.Windows.Forms.OpenFileDialog
        'Me.txtSearch = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select products for barcode printing ..."
		Me.ClientSize = New System.Drawing.Size(839, 573)
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
		Me.Name = "frmBarcodeStockitem"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "&Show Only with   Single Qty"
		Me.Command1.Size = New System.Drawing.Size(121, 64)
		Me.Command1.Location = New System.Drawing.Point(712, 288)
		Me.Command1.TabIndex = 12
		Me.Command1.TabStop = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.Name = "Command1"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load Qty from  CSV file"
		Me.cmdLoad.Size = New System.Drawing.Size(121, 64)
		Me.cmdLoad.Location = New System.Drawing.Point(712, 64)
		Me.cmdLoad.TabIndex = 11
		Me.cmdLoad.TabStop = False
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.Name = "cmdLoad"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "&Exit"
		Me.cmdExit.Size = New System.Drawing.Size(121, 64)
		Me.cmdExit.Location = New System.Drawing.Point(712, 471)
		Me.cmdExit.TabIndex = 10
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClear.Text = "&Clear All Selected Products"
		Me.cmdClear.Size = New System.Drawing.Size(121, 64)
		Me.cmdClear.Location = New System.Drawing.Point(712, 216)
		Me.cmdClear.TabIndex = 9
		Me.cmdClear.TabStop = False
		Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClear.CausesValidation = True
		Me.cmdClear.Enabled = True
		Me.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClear.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClear.Name = "cmdClear"
		Me.cmdShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdShow.Text = "&Show Changed     Price Items    Or      Selected Products"
		Me.cmdShow.Size = New System.Drawing.Size(121, 72)
		Me.cmdShow.Location = New System.Drawing.Point(712, 136)
		Me.cmdShow.TabIndex = 8
		Me.cmdShow.TabStop = False
		Me.cmdShow.BackColor = System.Drawing.SystemColors.Control
		Me.cmdShow.CausesValidation = True
		Me.cmdShow.Enabled = True
		Me.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdShow.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdShow.Name = "cmdShow"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(121, 64)
		Me.cmdPrint.Location = New System.Drawing.Point(712, 400)
		Me.cmdPrint.TabIndex = 7
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.txtEdit.AutoSize = False
		Me.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtEdit.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtEdit.Size = New System.Drawing.Size(55, 16)
		Me.txtEdit.Location = New System.Drawing.Point(0, 0)
		Me.txtEdit.Maxlength = 4
		Me.txtEdit.TabIndex = 6
		Me.txtEdit.Tag = "0"
		Me.txtEdit.Text = "0"
		Me.txtEdit.Visible = False
		Me.txtEdit.AcceptsReturn = True
		Me.txtEdit.CausesValidation = True
		Me.txtEdit.Enabled = True
		Me.txtEdit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEdit.HideSelection = True
		Me.txtEdit.ReadOnly = False
		Me.txtEdit.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEdit.MultiLine = False
		Me.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEdit.TabStop = True
		Me.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtEdit.Name = "txtEdit"
		Me._txtSearch_4.AutoSize = False
		Me._txtSearch_4.BackColor = System.Drawing.SystemColors.Control
		Me._txtSearch_4.Size = New System.Drawing.Size(76, 19)
		Me._txtSearch_4.Location = New System.Drawing.Point(369, 39)
		Me._txtSearch_4.TabIndex = 4
		Me._txtSearch_4.Tag = "PricingGroup_Name"
		Me._txtSearch_4.AcceptsReturn = True
		Me._txtSearch_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtSearch_4.CausesValidation = True
		Me._txtSearch_4.Enabled = True
		Me._txtSearch_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtSearch_4.HideSelection = True
		Me._txtSearch_4.ReadOnly = False
		Me._txtSearch_4.Maxlength = 0
		Me._txtSearch_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtSearch_4.MultiLine = False
		Me._txtSearch_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtSearch_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtSearch_4.TabStop = True
		Me._txtSearch_4.Visible = True
		Me._txtSearch_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtSearch_4.Name = "_txtSearch_4"
		Me._txtSearch_3.AutoSize = False
		Me._txtSearch_3.BackColor = System.Drawing.SystemColors.Control
		Me._txtSearch_3.Size = New System.Drawing.Size(76, 19)
		Me._txtSearch_3.Location = New System.Drawing.Point(282, 39)
		Me._txtSearch_3.TabIndex = 3
		Me._txtSearch_3.Tag = "Supplier_Name"
		Me._txtSearch_3.AcceptsReturn = True
		Me._txtSearch_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtSearch_3.CausesValidation = True
		Me._txtSearch_3.Enabled = True
		Me._txtSearch_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtSearch_3.HideSelection = True
		Me._txtSearch_3.ReadOnly = False
		Me._txtSearch_3.Maxlength = 0
		Me._txtSearch_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtSearch_3.MultiLine = False
		Me._txtSearch_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtSearch_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtSearch_3.TabStop = True
		Me._txtSearch_3.Visible = True
		Me._txtSearch_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtSearch_3.Name = "_txtSearch_3"
		Me._txtSearch_2.AutoSize = False
		Me._txtSearch_2.BackColor = System.Drawing.SystemColors.Control
		Me._txtSearch_2.Size = New System.Drawing.Size(76, 19)
		Me._txtSearch_2.Location = New System.Drawing.Point(189, 39)
		Me._txtSearch_2.TabIndex = 2
		Me._txtSearch_2.Tag = "StockItem_Name"
		Me._txtSearch_2.AcceptsReturn = True
		Me._txtSearch_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtSearch_2.CausesValidation = True
		Me._txtSearch_2.Enabled = True
		Me._txtSearch_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtSearch_2.HideSelection = True
		Me._txtSearch_2.ReadOnly = False
		Me._txtSearch_2.Maxlength = 0
		Me._txtSearch_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtSearch_2.MultiLine = False
		Me._txtSearch_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtSearch_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtSearch_2.TabStop = True
		Me._txtSearch_2.Visible = True
		Me._txtSearch_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtSearch_2.Name = "_txtSearch_2"
		Me._txtSearch_1.AutoSize = False
		Me._txtSearch_1.BackColor = System.Drawing.SystemColors.Control
		Me._txtSearch_1.Size = New System.Drawing.Size(76, 19)
		Me._txtSearch_1.Location = New System.Drawing.Point(93, 39)
		Me._txtSearch_1.TabIndex = 1
		Me._txtSearch_1.Tag = "StockItemID"
		Me._txtSearch_1.AcceptsReturn = True
		Me._txtSearch_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtSearch_1.CausesValidation = True
		Me._txtSearch_1.Enabled = True
		Me._txtSearch_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtSearch_1.HideSelection = True
		Me._txtSearch_1.ReadOnly = False
		Me._txtSearch_1.Maxlength = 0
		Me._txtSearch_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtSearch_1.MultiLine = False
		Me._txtSearch_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtSearch_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtSearch_1.TabStop = True
		Me._txtSearch_1.Visible = True
		Me._txtSearch_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtSearch_1.Name = "_txtSearch_1"
		Me._txtSearch_0.AutoSize = False
		Me._txtSearch_0.BackColor = System.Drawing.SystemColors.Control
		Me._txtSearch_0.Size = New System.Drawing.Size(76, 19)
		Me._txtSearch_0.Location = New System.Drawing.Point(9, 39)
		Me._txtSearch_0.TabIndex = 0
		Me._txtSearch_0.Tag = "Catalogue_Barcode"
		Me._txtSearch_0.AcceptsReturn = True
		Me._txtSearch_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtSearch_0.CausesValidation = True
		Me._txtSearch_0.Enabled = True
		Me._txtSearch_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtSearch_0.HideSelection = True
		Me._txtSearch_0.ReadOnly = False
		Me._txtSearch_0.Maxlength = 0
		Me._txtSearch_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtSearch_0.MultiLine = False
		Me._txtSearch_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtSearch_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtSearch_0.TabStop = True
		Me._txtSearch_0.Visible = True
		Me._txtSearch_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtSearch_0.Name = "_txtSearch_0"
        'gridEdit.OcxState = CType(resources.GetObject("gridEdit.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridEdit.Size = New System.Drawing.Size(695, 475)
		Me.gridEdit.Location = New System.Drawing.Point(9, 60)
		Me.gridEdit.TabIndex = 5
		Me.gridEdit.Name = "gridEdit"
		Me.Controls.Add(Command1)
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdClear)
		Me.Controls.Add(cmdShow)
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(txtEdit)
		Me.Controls.Add(_txtSearch_4)
		Me.Controls.Add(_txtSearch_3)
		Me.Controls.Add(_txtSearch_2)
		Me.Controls.Add(_txtSearch_1)
		Me.Controls.Add(_txtSearch_0)
		Me.Controls.Add(gridEdit)
        'Me.txtSearch.SetIndex(_txtSearch_4, CType(4, Short))
        'Me.txtSearch.SetIndex(_txtSearch_3, CType(3, Short))
        'Me.txtSearch.SetIndex(_txtSearch_2, CType(2, Short))
        'Me.txtSearch.SetIndex(_txtSearch_1, CType(1, Short))
        'Me.txtSearch.SetIndex(_txtSearch_0, CType(0, Short))
        'CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.gridEdit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class