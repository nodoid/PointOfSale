<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSupplierDeposits
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lvDeposit_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvDeposit_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvDeposit_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvDeposit As System.Windows.Forms.ListView
	Public WithEvents lblSupplier As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSupplierDeposits))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lvDeposit = New System.Windows.Forms.ListView
		Me._lvDeposit_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvDeposit_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvDeposit_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.lblSupplier = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.lvDeposit.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Supplier Deposits"
		Me.ClientSize = New System.Drawing.Size(450, 477)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSupplierDeposits"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(450, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 1
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
		Me.cmdClose.Location = New System.Drawing.Point(369, 3)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
		Me.cmdCancel.TabIndex = 2
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.lvDeposit.Size = New System.Drawing.Size(442, 394)
		Me.lvDeposit.Location = New System.Drawing.Point(3, 72)
		Me.lvDeposit.TabIndex = 0
		Me.lvDeposit.View = System.Windows.Forms.View.Details
		Me.lvDeposit.LabelEdit = False
		Me.lvDeposit.LabelWrap = True
		Me.lvDeposit.HideSelection = True
		Me.lvDeposit.AllowColumnReorder = -1
		Me.lvDeposit.Checkboxes = True
		Me.lvDeposit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvDeposit.BackColor = System.Drawing.SystemColors.Window
		Me.lvDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvDeposit.Name = "lvDeposit"
		Me._lvDeposit_ColumnHeader_1.Text = "Deposit Name"
		Me._lvDeposit_ColumnHeader_1.Width = 236
		Me._lvDeposit_ColumnHeader_2.Text = "Type"
		Me._lvDeposit_ColumnHeader_2.Width = 106
		Me._lvDeposit_ColumnHeader_3.Text = "Suppliers Description"
		Me._lvDeposit_ColumnHeader_3.Width = 377
		Me.lblSupplier.Text = "Label1"
		Me.lblSupplier.Size = New System.Drawing.Size(39, 13)
		Me.lblSupplier.Location = New System.Drawing.Point(9, 45)
		Me.lblSupplier.TabIndex = 4
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
		Me.Controls.Add(picButtons)
		Me.Controls.Add(lvDeposit)
		Me.Controls.Add(lblSupplier)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_1)
		Me.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_2)
		Me.lvDeposit.Columns.Add(_lvDeposit_ColumnHeader_3)
		Me.picButtons.ResumeLayout(False)
		Me.lvDeposit.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class