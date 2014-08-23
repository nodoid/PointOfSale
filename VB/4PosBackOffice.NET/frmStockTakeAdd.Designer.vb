<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTakeAdd
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
	Public WithEvents txtSARef As System.Windows.Forms.TextBox
	Public WithEvents cmdPrintSlip As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents grdDataGrid1 As myDataGridView
	Public WithEvents grdDataGrid As System.Windows.Forms.Panel
	Public WithEvents lbl As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTakeAdd))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtSARef = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdPrintSlip = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.lblHeading = New System.Windows.Forms.Label
		Me.grdDataGrid = New System.Windows.Forms.Panel
		Me.grdDataGrid1 = New myDataGridView
		Me.lbl = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.grdDataGrid.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.grdDataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Stock Take Add(This option only add stock to your quantities and is not a stock take)"
		Me.ClientSize = New System.Drawing.Size(564, 555)
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
		Me.Name = "frmStockTakeAdd"
		Me.txtSARef.AutoSize = False
		Me.txtSARef.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtSARef.Size = New System.Drawing.Size(486, 22)
		Me.txtSARef.Location = New System.Drawing.Point(72, 528)
		Me.txtSARef.TabIndex = 6
		Me.txtSARef.AcceptsReturn = True
		Me.txtSARef.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSARef.CausesValidation = True
		Me.txtSARef.Enabled = True
		Me.txtSARef.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSARef.HideSelection = True
		Me.txtSARef.ReadOnly = False
		Me.txtSARef.Maxlength = 0
		Me.txtSARef.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSARef.MultiLine = False
		Me.txtSARef.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSARef.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSARef.TabStop = True
		Me.txtSARef.Visible = True
		Me.txtSARef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSARef.Name = "txtSARef"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(564, 35)
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
		Me.cmdPrintSlip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintSlip.Text = "&Print Slip"
		Me.cmdPrintSlip.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrintSlip.Location = New System.Drawing.Point(336, 0)
		Me.cmdPrintSlip.TabIndex = 8
		Me.cmdPrintSlip.TabStop = False
		Me.cmdPrintSlip.Visible = False
		Me.cmdPrintSlip.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintSlip.CausesValidation = True
		Me.cmdPrintSlip.Enabled = True
		Me.cmdPrintSlip.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintSlip.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintSlip.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintSlip.Name = "cmdPrintSlip"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(488, 2)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(411, 3)
		Me.cmdPrint.TabIndex = 2
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.lblHeading.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblHeading.Size = New System.Drawing.Size(403, 22)
		Me.lblHeading.Location = New System.Drawing.Point(3, 6)
		Me.lblHeading.TabIndex = 4
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
		Me.grdDataGrid.Dock = System.Windows.Forms.DockStyle.Top
		Me.grdDataGrid.Size = New System.Drawing.Size(564, 486)
		Me.grdDataGrid.Location = New System.Drawing.Point(0, 35)
		Me.grdDataGrid.TabIndex = 0
		Me.grdDataGrid.BackColor = System.Drawing.SystemColors.Control
		Me.grdDataGrid.CausesValidation = True
		Me.grdDataGrid.Enabled = True
		Me.grdDataGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.grdDataGrid.Cursor = System.Windows.Forms.Cursors.Default
		Me.grdDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.grdDataGrid.TabStop = True
		Me.grdDataGrid.Visible = True
		Me.grdDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.grdDataGrid.Name = "grdDataGrid"
        'grdDataGrid1.OcxState = CType(resources.GetObject("grdDataGrid1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.grdDataGrid1.Size = New System.Drawing.Size(557, 247)
		Me.grdDataGrid1.Location = New System.Drawing.Point(0, 0)
		Me.grdDataGrid1.TabIndex = 5
		Me.grdDataGrid1.Name = "grdDataGrid1"
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lbl.Text = "&Reference :"
		Me.lbl.Size = New System.Drawing.Size(64, 22)
		Me.lbl.Location = New System.Drawing.Point(0, 530)
		Me.lbl.TabIndex = 7
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
		Me.Controls.Add(txtSARef)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(grdDataGrid)
		Me.Controls.Add(lbl)
		Me.picButtons.Controls.Add(cmdPrintSlip)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(lblHeading)
		Me.grdDataGrid.Controls.Add(grdDataGrid1)
		CType(Me.grdDataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.grdDataGrid.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class