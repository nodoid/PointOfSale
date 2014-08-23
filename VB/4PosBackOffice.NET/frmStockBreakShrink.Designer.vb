<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockBreakShrink
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
	Public WithEvents cmdMove As System.Windows.Forms.Button
	Public WithEvents txtQuantity As System.Windows.Forms.TextBox
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents picMove As System.Windows.Forms.Panel
	Public WithEvents lvStock As System.Windows.Forms.ListView
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents lblData As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockBreakShrink))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picMove = New System.Windows.Forms.Panel
		Me.cmdMove = New System.Windows.Forms.Button
		Me.txtQuantity = New System.Windows.Forms.TextBox
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lvStock = New System.Windows.Forms.ListView
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.lblData = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picMove.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Break a Stock Item"
		Me.ClientSize = New System.Drawing.Size(693, 433)
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
		Me.Name = "frmStockBreakShrink"
		Me.picMove.Size = New System.Drawing.Size(112, 70)
		Me.picMove.Location = New System.Drawing.Point(432, 357)
		Me.picMove.TabIndex = 5
		Me.picMove.TabStop = False
		Me.picMove.Dock = System.Windows.Forms.DockStyle.None
		Me.picMove.BackColor = System.Drawing.SystemColors.Control
		Me.picMove.CausesValidation = True
		Me.picMove.Enabled = True
		Me.picMove.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picMove.Cursor = System.Windows.Forms.Cursors.Default
		Me.picMove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picMove.Visible = True
		Me.picMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picMove.Name = "picMove"
		Me.cmdMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMove.Text = "&Move"
		Me.cmdMove.Size = New System.Drawing.Size(103, 25)
		Me.cmdMove.Location = New System.Drawing.Point(3, 39)
		Me.cmdMove.TabIndex = 8
		Me.cmdMove.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMove.CausesValidation = True
		Me.cmdMove.Enabled = True
		Me.cmdMove.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMove.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMove.TabStop = True
		Me.cmdMove.Name = "cmdMove"
		Me.txtQuantity.AutoSize = False
		Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQuantity.Size = New System.Drawing.Size(40, 19)
		Me.txtQuantity.Location = New System.Drawing.Point(54, 15)
		Me.txtQuantity.TabIndex = 6
		Me.txtQuantity.Text = "0"
		Me.txtQuantity.AcceptsReturn = True
		Me.txtQuantity.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantity.CausesValidation = True
		Me.txtQuantity.Enabled = True
		Me.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantity.HideSelection = True
		Me.txtQuantity.ReadOnly = False
		Me.txtQuantity.Maxlength = 0
		Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantity.MultiLine = False
		Me.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantity.TabStop = True
		Me.txtQuantity.Visible = True
		Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantity.Name = "txtQuantity"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "&Quantity to move :"
		Me._lbl_1.Size = New System.Drawing.Size(86, 13)
		Me._lbl_1.Location = New System.Drawing.Point(6, 0)
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
		Me.lvStock.Size = New System.Drawing.Size(673, 325)
		Me.lvStock.Location = New System.Drawing.Point(8, 24)
		Me.lvStock.TabIndex = 3
		Me.lvStock.View = System.Windows.Forms.View.Details
		Me.lvStock.LabelEdit = False
		Me.lvStock.LabelWrap = True
		Me.lvStock.HideSelection = False
		Me.lvStock.FullRowSelect = True
		Me.lvStock.GridLines = True
		Me.lvStock.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvStock.BackColor = System.Drawing.SystemColors.Window
		Me.lvStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvStock.Name = "lvStock"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(631, 19)
		Me.txtSearch.Location = New System.Drawing.Point(51, 3)
		Me.txtSearch.TabIndex = 1
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
		Me.cmdExit.Location = New System.Drawing.Point(585, 375)
		Me.cmdExit.TabIndex = 2
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.lblData.Size = New System.Drawing.Size(418, 70)
		Me.lblData.Location = New System.Drawing.Point(12, 357)
		Me.lblData.TabIndex = 4
		Me.lblData.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblData.BackColor = System.Drawing.SystemColors.Control
		Me.lblData.Enabled = True
		Me.lblData.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblData.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblData.UseMnemonic = True
		Me.lblData.Visible = True
		Me.lblData.AutoSize = False
		Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblData.Name = "lblData"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "&Search :"
		Me._lbl_0.Size = New System.Drawing.Size(40, 13)
		Me._lbl_0.Location = New System.Drawing.Point(8, 6)
		Me._lbl_0.TabIndex = 0
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
		Me.Controls.Add(picMove)
		Me.Controls.Add(lvStock)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(lblData)
		Me.Controls.Add(_lbl_0)
		Me.picMove.Controls.Add(cmdMove)
		Me.picMove.Controls.Add(txtQuantity)
		Me.picMove.Controls.Add(_lbl_1)
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picMove.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class