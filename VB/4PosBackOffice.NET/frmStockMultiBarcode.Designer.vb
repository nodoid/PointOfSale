<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockMultiBarcode
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
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
    Public WithEvents cmbShrink As myDataGridView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents grdDataGrid As myDataGridView
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockMultiBarcode))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdFilter = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmbShrink = New myDataGridView
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblHeading = New System.Windows.Forms.Label
        Me.grdDataGrid = New myDataGridView
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Edit Stock Item Barcodes"
		Me.ClientSize = New System.Drawing.Size(565, 493)
		Me.Location = New System.Drawing.Point(73, 22)
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
		Me.Name = "frmStockMultiBarcode"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(565, 89)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 1
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picButtons.Name = "picButtons"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 62)
		Me.cmdClose.Location = New System.Drawing.Point(489, 3)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFilter.Text = "&Filter"
		Me.cmdFilter.Size = New System.Drawing.Size(73, 29)
		Me.cmdFilter.Location = New System.Drawing.Point(411, 3)
		Me.cmdFilter.TabIndex = 3
		Me.cmdFilter.TabStop = False
		Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFilter.CausesValidation = True
		Me.cmdFilter.Enabled = True
		Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFilter.Name = "cmdFilter"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(411, 36)
		Me.cmdPrint.TabIndex = 2
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
        'cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
		Me.cmbShrink.Size = New System.Drawing.Size(67, 21)
		Me.cmbShrink.Location = New System.Drawing.Point(276, 66)
		Me.cmbShrink.TabIndex = 7
		Me.cmbShrink.Name = "cmbShrink"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "For which Shrink Quantity do you wish to edit"
		Me._lbl_0.ForeColor = System.Drawing.Color.White
		Me._lbl_0.Size = New System.Drawing.Size(359, 13)
		Me._lbl_0.Location = New System.Drawing.Point(-92, 69)
		Me._lbl_0.TabIndex = 6
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblHeading.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Size = New System.Drawing.Size(403, 61)
		Me.lblHeading.Location = New System.Drawing.Point(3, 3)
		Me.lblHeading.TabIndex = 5
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
        'grdDataGrid.OcxState = CType(resources.GetObject("grdDataGrid.OcxState"), System.Windows.Forms.AxHost.State)
		Me.grdDataGrid.Dock = System.Windows.Forms.DockStyle.Top
		Me.grdDataGrid.Size = New System.Drawing.Size(565, 239)
		Me.grdDataGrid.Location = New System.Drawing.Point(0, 89)
		Me.grdDataGrid.TabIndex = 0
		Me.grdDataGrid.Name = "grdDataGrid"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(grdDataGrid)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdFilter)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(cmbShrink)
		Me.picButtons.Controls.Add(_lbl_0)
		Me.picButtons.Controls.Add(lblHeading)
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmbShrink, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class