<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTransfer
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
	Public WithEvents cmdSelComp As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents lvStockT As System.Windows.Forms.ListView
	Public WithEvents cmdTransfer As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents lblSComp As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblPComp As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTransfer))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdSelComp = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.lvStockT = New System.Windows.Forms.ListView
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdTransfer = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lblSComp = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblPComp = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Stock Transfer Details"
		Me.ClientSize = New System.Drawing.Size(453, 406)
		Me.Location = New System.Drawing.Point(73, 22)
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
		Me.Name = "frmStockTransfer"
		Me.cmdSelComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelComp.Text = "&Select Company to Transfer"
		Me.cmdSelComp.Size = New System.Drawing.Size(161, 25)
		Me.cmdSelComp.Location = New System.Drawing.Point(280, 120)
		Me.cmdSelComp.TabIndex = 9
		Me.cmdSelComp.TabStop = False
		Me.cmdSelComp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelComp.CausesValidation = True
		Me.cmdSelComp.Enabled = True
		Me.cmdSelComp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelComp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelComp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelComp.Name = "cmdSelComp"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Delete"
		Me.cmdDelete.Enabled = False
		Me.cmdDelete.Size = New System.Drawing.Size(94, 25)
		Me.cmdDelete.Location = New System.Drawing.Point(112, 120)
		Me.cmdDelete.TabIndex = 7
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "&Add"
		Me.cmdAdd.Enabled = False
		Me.cmdAdd.Size = New System.Drawing.Size(94, 25)
		Me.cmdAdd.Location = New System.Drawing.Point(8, 120)
		Me.cmdAdd.TabIndex = 6
		Me.cmdAdd.TabStop = False
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.Name = "cmdAdd"
		Me.lvStockT.Size = New System.Drawing.Size(445, 250)
		Me.lvStockT.Location = New System.Drawing.Point(2, 150)
		Me.lvStockT.TabIndex = 4
		Me.lvStockT.View = System.Windows.Forms.View.Details
		Me.lvStockT.LabelEdit = False
		Me.lvStockT.LabelWrap = True
		Me.lvStockT.HideSelection = False
		Me.lvStockT.FullRowSelect = True
		Me.lvStockT.GridLines = True
		Me.lvStockT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvStockT.BackColor = System.Drawing.SystemColors.Window
		Me.lvStockT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvStockT.Name = "lvStockT"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(453, 39)
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
		Me.cmdTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTransfer.Text = "&Transfer"
		Me.cmdTransfer.Size = New System.Drawing.Size(73, 29)
		Me.cmdTransfer.Location = New System.Drawing.Point(368, 3)
		Me.cmdTransfer.TabIndex = 12
		Me.cmdTransfer.TabStop = False
		Me.cmdTransfer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTransfer.CausesValidation = True
		Me.cmdTransfer.Enabled = True
		Me.cmdTransfer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTransfer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTransfer.Name = "cmdTransfer"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(80, 3)
		Me.cmdPrint.TabIndex = 8
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.Visible = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(161, 3)
		Me.cmdClose.TabIndex = 5
		Me.cmdClose.TabStop = False
		Me.cmdClose.Visible = False
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
		Me.lblSComp.Text = "Promotion Name:"
		Me.lblSComp.Size = New System.Drawing.Size(192, 48)
		Me.lblSComp.Location = New System.Drawing.Point(248, 64)
		Me.lblSComp.TabIndex = 11
		Me.lblSComp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSComp.BackColor = System.Drawing.Color.Transparent
		Me.lblSComp.Enabled = True
		Me.lblSComp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSComp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSComp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSComp.UseMnemonic = True
		Me.lblSComp.Visible = True
		Me.lblSComp.AutoSize = False
		Me.lblSComp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSComp.Name = "lblSComp"
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Text = "&Transfer To"
		Me._lbl_0.Size = New System.Drawing.Size(67, 13)
		Me._lbl_0.Location = New System.Drawing.Point(248, 45)
		Me._lbl_0.TabIndex = 10
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblPComp.Text = "Promotion Name:"
		Me.lblPComp.Size = New System.Drawing.Size(216, 48)
		Me.lblPComp.Location = New System.Drawing.Point(16, 64)
		Me.lblPComp.TabIndex = 1
		Me.lblPComp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPComp.BackColor = System.Drawing.Color.Transparent
		Me.lblPComp.Enabled = True
		Me.lblPComp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPComp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPComp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPComp.UseMnemonic = True
		Me.lblPComp.Visible = True
		Me.lblPComp.AutoSize = False
		Me.lblPComp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPComp.Name = "lblPComp"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(439, 56)
		Me._Shape1_2.Location = New System.Drawing.Point(8, 60)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Text = "&Transfer From"
		Me._lbl_5.Size = New System.Drawing.Size(79, 13)
		Me._lbl_5.Location = New System.Drawing.Point(8, 45)
		Me._lbl_5.TabIndex = 0
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_5.Enabled = True
		Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_5.UseMnemonic = True
		Me._lbl_5.Visible = True
		Me._lbl_5.AutoSize = True
		Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_5.Name = "_lbl_5"
		Me.Controls.Add(cmdSelComp)
		Me.Controls.Add(cmdDelete)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(lvStockT)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(lblSComp)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblPComp)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdTransfer)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdCancel)
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class