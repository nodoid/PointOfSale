<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDepositTake
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
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents grdDataGrid As myDataGridView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDepositTake))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.lblHeading = New System.Windows.Forms.Label
        Me.grdDataGrid = New myDataGridView
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Deposit Stock Take Adjustments"
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
		Me.Name = "frmDepositTake"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(565, 35)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
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
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(489, 3)
		Me.cmdClose.TabIndex = 2
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(411, 3)
		Me.cmdPrint.TabIndex = 1
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.lblHeading.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblHeading.Text = "Deposit Stock Take List"
		Me.lblHeading.Size = New System.Drawing.Size(403, 22)
		Me.lblHeading.Location = New System.Drawing.Point(3, 6)
		Me.lblHeading.TabIndex = 3
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
		Me.grdDataGrid.Size = New System.Drawing.Size(565, 233)
		Me.grdDataGrid.Location = New System.Drawing.Point(0, 35)
		Me.grdDataGrid.TabIndex = 4
		Me.grdDataGrid.Name = "grdDataGrid"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(grdDataGrid)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(lblHeading)
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class