<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMainHOParam
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
	Public WithEvents _chkBit_6 As System.Windows.Forms.CheckBox
	Public WithEvents _chkBit_5 As System.Windows.Forms.CheckBox
	Public WithEvents _chkBit_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkBit_2 As System.Windows.Forms.CheckBox
	Public WithEvents _chkBit_3 As System.Windows.Forms.CheckBox
	Public WithEvents _chkBit_4 As System.Windows.Forms.CheckBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClearLock As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _Shape1_3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents chkBit As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMainHOParam))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._chkBit_6 = New System.Windows.Forms.CheckBox
		Me._chkBit_5 = New System.Windows.Forms.CheckBox
		Me._chkBit_1 = New System.Windows.Forms.CheckBox
		Me._chkBit_2 = New System.Windows.Forms.CheckBox
		Me._chkBit_3 = New System.Windows.Forms.CheckBox
		Me._chkBit_4 = New System.Windows.Forms.CheckBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClearLock = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._Shape1_3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.chkBit = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.chkBit, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "4POS HeadOffice Sync - Parameters"
		Me.ClientSize = New System.Drawing.Size(271, 189)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMainHOParam"
		Me._chkBit_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_6.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_6.Text = "Ignore Bill of Material / Recipe"
		Me._chkBit_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_6.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_6.Location = New System.Drawing.Point(16, 160)
		Me._chkBit_6.TabIndex = 10
		Me._chkBit_6.CausesValidation = True
		Me._chkBit_6.Enabled = True
		Me._chkBit_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_6.TabStop = True
		Me._chkBit_6.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_6.Visible = True
		Me._chkBit_6.Name = "_chkBit_6"
		Me._chkBit_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_5.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_5.Text = "Overwrite Promotion"
		Me._chkBit_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_5.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_5.Location = New System.Drawing.Point(16, 142)
		Me._chkBit_5.TabIndex = 9
		Me._chkBit_5.CausesValidation = True
		Me._chkBit_5.Enabled = True
		Me._chkBit_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_5.TabStop = True
		Me._chkBit_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_5.Visible = True
		Me._chkBit_5.Name = "_chkBit_5"
		Me._chkBit_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_1.Text = "Update Re-order level"
		Me._chkBit_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_1.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_1.Location = New System.Drawing.Point(16, 59)
		Me._chkBit_1.TabIndex = 6
		Me._chkBit_1.CausesValidation = True
		Me._chkBit_1.Enabled = True
		Me._chkBit_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_1.TabStop = True
		Me._chkBit_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_1.Visible = True
		Me._chkBit_1.Name = "_chkBit_1"
		Me._chkBit_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_2.Text = "Overwrite Employee information"
		Me._chkBit_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_2.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_2.Location = New System.Drawing.Point(16, 79)
		Me._chkBit_2.TabIndex = 5
		Me._chkBit_2.CausesValidation = True
		Me._chkBit_2.Enabled = True
		Me._chkBit_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_2.TabStop = True
		Me._chkBit_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_2.Visible = True
		Me._chkBit_2.Name = "_chkBit_2"
		Me._chkBit_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_3.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_3.Text = "Update Item Counter for Waitron"
		Me._chkBit_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_3.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_3.Location = New System.Drawing.Point(16, 99)
		Me._chkBit_3.TabIndex = 4
		Me._chkBit_3.CausesValidation = True
		Me._chkBit_3.Enabled = True
		Me._chkBit_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_3.TabStop = True
		Me._chkBit_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_3.Visible = True
		Me._chkBit_3.Name = "_chkBit_3"
		Me._chkBit_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkBit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkBit_4.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkBit_4.Text = "Update Actual Cost"
		Me._chkBit_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkBit_4.Size = New System.Drawing.Size(242, 15)
		Me._chkBit_4.Location = New System.Drawing.Point(16, 120)
		Me._chkBit_4.TabIndex = 3
		Me._chkBit_4.CausesValidation = True
		Me._chkBit_4.Enabled = True
		Me._chkBit_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkBit_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkBit_4.TabStop = True
		Me._chkBit_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkBit_4.Visible = True
		Me._chkBit_4.Name = "_chkBit_4"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(271, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Undo"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
		Me.cmdCancel.Location = New System.Drawing.Point(8, 4)
		Me.cmdCancel.TabIndex = 8
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdClearLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClearLock.Text = "Clear Log"
		Me.cmdClearLock.Size = New System.Drawing.Size(73, 29)
		Me.cmdClearLock.Location = New System.Drawing.Point(552, 4)
		Me.cmdClearLock.TabIndex = 2
		Me.cmdClearLock.TabStop = False
		Me.cmdClearLock.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClearLock.CausesValidation = True
		Me.cmdClearLock.Enabled = True
		Me.cmdClearLock.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClearLock.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClearLock.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClearLock.Name = "cmdClearLock"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(184, 4)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Text = "1. 4POS HeadOffice Sync - Parameters"
		Me._lbl_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_2.Size = New System.Drawing.Size(206, 14)
		Me._lbl_2.Location = New System.Drawing.Point(8, 40)
		Me._lbl_2.TabIndex = 7
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._Shape1_3.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_3.Size = New System.Drawing.Size(254, 125)
		Me._Shape1_3.Location = New System.Drawing.Point(8, 55)
		Me._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_3.BorderWidth = 1
		Me._Shape1_3.FillColor = System.Drawing.Color.Black
		Me._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_3.Visible = True
		Me._Shape1_3.Name = "_Shape1_3"
		Me.Controls.Add(_chkBit_6)
		Me.Controls.Add(_chkBit_5)
		Me.Controls.Add(_chkBit_1)
		Me.Controls.Add(_chkBit_2)
		Me.Controls.Add(_chkBit_3)
		Me.Controls.Add(_chkBit_4)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_lbl_2)
		Me.ShapeContainer1.Shapes.Add(_Shape1_3)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClearLock)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.chkBit.SetIndex(_chkBit_6, CType(6, Short))
        'Me.chkBit.SetIndex(_chkBit_5, CType(5, Short))
        'Me.chkBit.SetIndex(_chkBit_1, CType(1, Short))
        'Me.chkBit.SetIndex(_chkBit_2, CType(2, Short))
        'Me.chkBit.SetIndex(_chkBit_3, CType(3, Short))
        'Me.chkBit.SetIndex(_chkBit_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
		Me.Shape1.SetIndex(_Shape1_3, CType(3, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chkBit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class