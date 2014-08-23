<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVDeposit
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
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents lblDepositExclusive As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents lblQuantity As System.Windows.Forms.Label
	Public WithEvents _lbl_9 As System.Windows.Forms.Label
	Public WithEvents lblDepositInclusive As System.Windows.Forms.Label
	Public WithEvents frmTotals As System.Windows.Forms.GroupBox
	Public WithEvents lblSupplier As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents txtEdit As System.Windows.Forms.TextBox
	Public WithEvents gridItem As myDataGridView
	Public WithEvents lblReturns As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVDeposit))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdBack = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.frmTotals = New System.Windows.Forms.GroupBox
		Me.lblDepositExclusive = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me.lblQuantity = New System.Windows.Forms.Label
		Me._lbl_9 = New System.Windows.Forms.Label
		Me.lblDepositInclusive = New System.Windows.Forms.Label
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.lblSupplier = New System.Windows.Forms.Label
		Me.txtEdit = New System.Windows.Forms.TextBox
		Me.gridItem = New myDataGridView
		Me.lblReturns = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.picButtons.SuspendLayout()
		Me.frmTotals.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "Deposit Returns Form"
		Me.ClientSize = New System.Drawing.Size(806, 547)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmGRVDeposit"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(806, 49)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 10
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "<< &Back"
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(73, 40)
		Me.cmdBack.Location = New System.Drawing.Point(426, 3)
		Me.cmdBack.TabIndex = 14
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next >>"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(73, 40)
		Me.cmdNext.Location = New System.Drawing.Point(528, 3)
		Me.cmdNext.TabIndex = 13
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "D&elete"
		Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdDelete.Size = New System.Drawing.Size(73, 40)
		Me.cmdDelete.Location = New System.Drawing.Point(3, 3)
		Me.cmdDelete.TabIndex = 12
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(73, 40)
		Me.cmdExit.Location = New System.Drawing.Point(630, 3)
		Me.cmdExit.TabIndex = 11
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.frmTotals.Text = "Sub Totals"
		Me.frmTotals.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmTotals.Size = New System.Drawing.Size(370, 52)
		Me.frmTotals.Location = New System.Drawing.Point(219, 444)
		Me.frmTotals.TabIndex = 4
		Me.frmTotals.BackColor = System.Drawing.SystemColors.Control
		Me.frmTotals.Enabled = True
		Me.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmTotals.Visible = True
		Me.frmTotals.Padding = New System.Windows.Forms.Padding(0)
		Me.frmTotals.Name = "frmTotals"
		Me.lblDepositExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositExclusive.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblDepositExclusive.Text = "0.00"
		Me.lblDepositExclusive.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositExclusive.Location = New System.Drawing.Point(134, 27)
		Me.lblDepositExclusive.TabIndex = 16
		Me.lblDepositExclusive.Enabled = True
		Me.lblDepositExclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositExclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositExclusive.UseMnemonic = True
		Me.lblDepositExclusive.Visible = True
		Me.lblDepositExclusive.AutoSize = False
		Me.lblDepositExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositExclusive.Name = "lblDepositExclusive"
		Me._lbl_0.Text = "Exclusive Amount"
		Me._lbl_0.Size = New System.Drawing.Size(103, 13)
		Me._lbl_0.Location = New System.Drawing.Point(135, 15)
		Me._lbl_0.TabIndex = 15
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = False
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me._lbl_8.Text = "No Of Cases"
		Me._lbl_8.Size = New System.Drawing.Size(60, 13)
		Me._lbl_8.Location = New System.Drawing.Point(9, 15)
		Me._lbl_8.TabIndex = 7
		Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_8.BackColor = System.Drawing.Color.Transparent
		Me._lbl_8.Enabled = True
		Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_8.UseMnemonic = True
		Me._lbl_8.Visible = True
		Me._lbl_8.AutoSize = True
		Me._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_8.Name = "_lbl_8"
		Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblQuantity.Text = "lblQuantity"
		Me.lblQuantity.Size = New System.Drawing.Size(64, 17)
		Me.lblQuantity.Location = New System.Drawing.Point(9, 27)
		Me.lblQuantity.TabIndex = 6
		Me.lblQuantity.BackColor = System.Drawing.SystemColors.Control
		Me.lblQuantity.Enabled = True
		Me.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblQuantity.UseMnemonic = True
		Me.lblQuantity.Visible = True
		Me.lblQuantity.AutoSize = False
		Me.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblQuantity.Name = "lblQuantity"
		Me._lbl_9.Text = "Inclusive Amount"
		Me._lbl_9.Size = New System.Drawing.Size(103, 13)
		Me._lbl_9.Location = New System.Drawing.Point(256, 15)
		Me._lbl_9.TabIndex = 8
		Me._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_9.BackColor = System.Drawing.Color.Transparent
		Me._lbl_9.Enabled = True
		Me._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_9.UseMnemonic = True
		Me._lbl_9.Visible = True
		Me._lbl_9.AutoSize = False
		Me._lbl_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_9.Name = "_lbl_9"
		Me.lblDepositInclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositInclusive.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.lblDepositInclusive.Text = "0.00"
		Me.lblDepositInclusive.Size = New System.Drawing.Size(91, 17)
		Me.lblDepositInclusive.Location = New System.Drawing.Point(255, 27)
		Me.lblDepositInclusive.TabIndex = 5
		Me.lblDepositInclusive.Enabled = True
		Me.lblDepositInclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositInclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositInclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositInclusive.UseMnemonic = True
		Me.lblDepositInclusive.Visible = True
		Me.lblDepositInclusive.AutoSize = False
		Me.lblDepositInclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositInclusive.Name = "lblDepositInclusive"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.Picture1.Size = New System.Drawing.Size(806, 25)
		Me.Picture1.Location = New System.Drawing.Point(0, 49)
		Me.Picture1.TabIndex = 2
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.lblSupplier.Text = "lblSupplier"
		Me.lblSupplier.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblSupplier.Size = New System.Drawing.Size(85, 20)
		Me.lblSupplier.Location = New System.Drawing.Point(0, 0)
		Me.lblSupplier.TabIndex = 3
		Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
		Me.lblSupplier.Enabled = True
		Me.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSupplier.UseMnemonic = True
		Me.lblSupplier.Visible = True
		Me.lblSupplier.AutoSize = True
		Me.lblSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSupplier.Name = "lblSupplier"
		Me.txtEdit.AutoSize = False
		Me.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtEdit.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me.txtEdit.Size = New System.Drawing.Size(55, 16)
		Me.txtEdit.Location = New System.Drawing.Point(279, 138)
		Me.txtEdit.TabIndex = 0
		Me.txtEdit.Tag = "0"
		Me.txtEdit.Text = "0"
		Me.txtEdit.Visible = False
		Me.txtEdit.AcceptsReturn = True
		Me.txtEdit.CausesValidation = True
		Me.txtEdit.Enabled = True
		Me.txtEdit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEdit.HideSelection = True
		Me.txtEdit.ReadOnly = False
		Me.txtEdit.Maxlength = 0
		Me.txtEdit.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEdit.MultiLine = False
		Me.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEdit.TabStop = True
		Me.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtEdit.Name = "txtEdit"
        'gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridItem.Size = New System.Drawing.Size(685, 277)
		Me.gridItem.Location = New System.Drawing.Point(3, 81)
		Me.gridItem.TabIndex = 1
		Me.gridItem.Name = "gridItem"
		Me.lblReturns.BackColor = System.Drawing.Color.Red
		Me.lblReturns.Text = "PURCHASES"
		Me.lblReturns.Font = New System.Drawing.Font("Arial", 24!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblReturns.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblReturns.Size = New System.Drawing.Size(208, 34)
		Me.lblReturns.Location = New System.Drawing.Point(9, 453)
		Me.lblReturns.TabIndex = 9
		Me.lblReturns.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblReturns.Enabled = True
		Me.lblReturns.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblReturns.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblReturns.UseMnemonic = True
		Me.lblReturns.Visible = True
		Me.lblReturns.AutoSize = False
		Me.lblReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReturns.Name = "lblReturns"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(frmTotals)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(txtEdit)
		Me.Controls.Add(gridItem)
		Me.Controls.Add(lblReturns)
		Me.picButtons.Controls.Add(cmdBack)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdDelete)
		Me.picButtons.Controls.Add(cmdExit)
		Me.frmTotals.Controls.Add(lblDepositExclusive)
		Me.frmTotals.Controls.Add(_lbl_0)
		Me.frmTotals.Controls.Add(_lbl_8)
		Me.frmTotals.Controls.Add(lblQuantity)
		Me.frmTotals.Controls.Add(_lbl_9)
		Me.frmTotals.Controls.Add(lblDepositInclusive)
		Me.Picture1.Controls.Add(lblSupplier)
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_8, CType(8, Short))
        'Me.lbl.SetIndex(_lbl_9, CType(9, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.frmTotals.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class