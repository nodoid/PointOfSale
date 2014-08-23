<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCashTransaction
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
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdNew As System.Windows.Forms.Button
	Public WithEvents lvItem As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCashTransaction))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdNew = New System.Windows.Forms.Button
		Me.lvItem = New System.Windows.Forms.ListView
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Cash Transactions"
		Me.ClientSize = New System.Drawing.Size(461, 515)
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
		Me.Name = "frmCashTransaction"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(461, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 3
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
		Me.cmdClose.TabIndex = 5
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
		Me.cmdPrint.Location = New System.Drawing.Point(9, 3)
		Me.cmdPrint.TabIndex = 4
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Delete"
		Me.cmdDelete.Size = New System.Drawing.Size(97, 34)
		Me.cmdDelete.Location = New System.Drawing.Point(351, 465)
		Me.cmdDelete.TabIndex = 2
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNew.Text = "&Add"
		Me.cmdNew.Size = New System.Drawing.Size(97, 34)
		Me.cmdNew.Location = New System.Drawing.Point(9, 465)
		Me.cmdNew.TabIndex = 0
		Me.cmdNew.TabStop = False
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.Name = "cmdNew"
		Me.lvItem.Size = New System.Drawing.Size(445, 409)
		Me.lvItem.Location = New System.Drawing.Point(6, 45)
		Me.lvItem.TabIndex = 1
		Me.lvItem.View = System.Windows.Forms.View.Details
		Me.lvItem.LabelWrap = True
		Me.lvItem.HideSelection = False
		Me.lvItem.FullRowSelect = True
		Me.lvItem.GridLines = True
		Me.lvItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvItem.BackColor = System.Drawing.SystemColors.Window
		Me.lvItem.LabelEdit = True
		Me.lvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvItem.Name = "lvItem"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(cmdDelete)
		Me.Controls.Add(cmdNew)
		Me.Controls.Add(lvItem)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class