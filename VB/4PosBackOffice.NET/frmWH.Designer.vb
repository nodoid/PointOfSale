<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWH
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
	Public WithEvents _txtFields_10 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWH))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._txtFields_10 = New System.Windows.Forms.TextBox
		Me._txtInteger_0 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Warehouse Details"
		Me.ClientSize = New System.Drawing.Size(452, 109)
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
		Me.Name = "frmWH"
		Me._txtFields_10.AutoSize = False
		Me._txtFields_10.BackColor = System.Drawing.Color.White
		Me._txtFields_10.Size = New System.Drawing.Size(78, 19)
		Me._txtFields_10.Location = New System.Drawing.Point(352, 272)
		Me._txtFields_10.TabIndex = 8
		Me._txtFields_10.AcceptsReturn = True
		Me._txtFields_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_10.CausesValidation = True
		Me._txtFields_10.Enabled = True
		Me._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_10.HideSelection = True
		Me._txtFields_10.ReadOnly = False
		Me._txtFields_10.Maxlength = 0
		Me._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_10.MultiLine = False
		Me._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_10.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_10.TabStop = True
		Me._txtFields_10.Visible = True
		Me._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_10.Name = "_txtFields_10"
		Me._txtInteger_0.AutoSize = False
		Me._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_0.BackColor = System.Drawing.Color.White
		Me._txtInteger_0.Enabled = False
		Me._txtInteger_0.Size = New System.Drawing.Size(27, 19)
		Me._txtInteger_0.Location = New System.Drawing.Point(412, 68)
		Me._txtInteger_0.TabIndex = 3
		Me._txtInteger_0.AcceptsReturn = True
		Me._txtInteger_0.CausesValidation = True
		Me._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtInteger_0.HideSelection = True
		Me._txtInteger_0.ReadOnly = False
		Me._txtInteger_0.Maxlength = 0
		Me._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtInteger_0.MultiLine = False
		Me._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtInteger_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtInteger_0.TabStop = True
		Me._txtInteger_0.Visible = True
		Me._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtInteger_0.Name = "_txtInteger_0"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.BackColor = System.Drawing.Color.White
		Me._txtFields_1.Size = New System.Drawing.Size(190, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(110, 68)
		Me._txtFields_1.TabIndex = 1
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Maxlength = 0
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.Visible = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_1.Name = "_txtFields_1"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(452, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 7
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
		Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
		Me.cmdCancel.TabIndex = 6
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(372, 2)
		Me.cmdClose.TabIndex = 5
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_2.Text = "Warehouse Number:"
		Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_2.Size = New System.Drawing.Size(98, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(309, 71)
		Me._lblLabels_2.TabIndex = 2
		Me._lblLabels_2.Enabled = True
		Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_2.UseMnemonic = True
		Me._lblLabels_2.Visible = True
		Me._lblLabels_2.AutoSize = True
		Me._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_2.Name = "_lblLabels_2"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_1.Text = "Warehouse Name:"
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_1.Size = New System.Drawing.Size(89, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(15, 71)
		Me._lblLabels_1.TabIndex = 0
		Me._lblLabels_1.Enabled = True
		Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_1.UseMnemonic = True
		Me._lblLabels_1.Visible = True
		Me._lblLabels_1.AutoSize = True
		Me._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_1.Name = "_lblLabels_1"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(442, 47)
		Me._Shape1_2.Location = New System.Drawing.Point(4, 56)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Text = "&1. General"
		Me._lbl_5.Size = New System.Drawing.Size(60, 13)
		Me._lbl_5.Location = New System.Drawing.Point(6, 42)
		Me._lbl_5.TabIndex = 4
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
		Me.Controls.Add(_txtFields_10)
		Me.Controls.Add(_txtInteger_0)
		Me.Controls.Add(_txtFields_1)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_lblLabels_2)
		Me.Controls.Add(_lblLabels_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.txtFields.SetIndex(_txtFields_10, CType(10, Short))
        'Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
        'Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class