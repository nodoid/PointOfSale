<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTakeLIQCode
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		Form_Initialize_renamed()
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
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    'Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents chkFields As System.Windows.Forms.CheckBox
	Public WithEvents txtFields As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTakeLIQCode))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
        'Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.chkFields = New System.Windows.Forms.CheckBox
		Me.txtFields = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "4LIQUOR Registration"
		Me.ClientSize = New System.Drawing.Size(345, 120)
		Me.Location = New System.Drawing.Point(73, 22)
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
		Me.Name = "frmStockTakeLIQCode"
		Me.Timer1.Interval = 1
		Me.Timer1.Enabled = True
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Close CD Tray and Register"
		Me.Command2.Size = New System.Drawing.Size(151, 19)
		Me.Command2.Location = New System.Drawing.Point(184, 256)
		Me.Command2.TabIndex = 10
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Open"
		Me.Command1.Size = New System.Drawing.Size(59, 19)
		Me.Command1.Location = New System.Drawing.Point(216, 280)
		Me.Command1.TabIndex = 8
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
        'Me.Drive1.Enabled = False
        'Me.Drive1.Size = New System.Drawing.Size(111, 21)
        'Me.Drive1.Location = New System.Drawing.Point(64, 256)
        'Me.Drive1.TabIndex = 7
        'Me.Drive1.BackColor = System.Drawing.SystemColors.Window
        'Me.Drive1.CausesValidation = True
        'Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
        'Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
        'Me.Drive1.TabStop = True
        'Me.Drive1.Visible = True
        'Me.Drive1.Name = "Drive1"
		Me.chkFields.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkFields.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.chkFields.Text = "Manual :"
		Me.chkFields.ForeColor = System.Drawing.SystemColors.WindowText
		Me.chkFields.Size = New System.Drawing.Size(68, 17)
		Me.chkFields.Location = New System.Drawing.Point(264, 231)
		Me.chkFields.TabIndex = 2
		Me.chkFields.CausesValidation = True
		Me.chkFields.Enabled = True
		Me.chkFields.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFields.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFields.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFields.TabStop = True
		Me.chkFields.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFields.Visible = True
		Me.chkFields.Name = "chkFields"
		Me.txtFields.AutoSize = False
		Me.txtFields.BackColor = System.Drawing.Color.White
		Me.txtFields.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtFields.Size = New System.Drawing.Size(270, 27)
		Me.txtFields.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtFields.Location = New System.Drawing.Point(64, 76)
		Me.txtFields.TabIndex = 1
		Me.txtFields.AcceptsReturn = True
		Me.txtFields.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFields.CausesValidation = True
		Me.txtFields.Enabled = True
		Me.txtFields.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFields.HideSelection = True
		Me.txtFields.ReadOnly = False
		Me.txtFields.Maxlength = 0
		Me.txtFields.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFields.MultiLine = False
		Me.txtFields.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFields.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFields.TabStop = True
		Me.txtFields.Visible = True
		Me.txtFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtFields.Name = "txtFields"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(345, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 6
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
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "N&ext"
		Me.cmdClose.Size = New System.Drawing.Size(81, 29)
		Me.cmdClose.Location = New System.Drawing.Point(256, 2)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_0.Text = "CD Drive :"
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_0.Size = New System.Drawing.Size(49, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(8, 258)
		Me._lblLabels_0.TabIndex = 9
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.Visible = True
		Me._lblLabels_0.AutoSize = True
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_1.Text = "CD Key :"
		Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_1.Size = New System.Drawing.Size(51, 16)
		Me._lblLabels_1.Location = New System.Drawing.Point(8, 79)
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
		Me._Shape1_2.Size = New System.Drawing.Size(338, 49)
		Me._Shape1_2.Location = New System.Drawing.Point(4, 64)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Text = "Please type in your 4LIQUOR CD Key. [ without dashes ]"
		Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_5.Size = New System.Drawing.Size(333, 21)
		Me._lbl_5.Location = New System.Drawing.Point(6, 48)
		Me._lbl_5.TabIndex = 3
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_5.Enabled = True
		Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_5.UseMnemonic = True
		Me._lbl_5.Visible = True
		Me._lbl_5.AutoSize = False
		Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_5.Name = "_lbl_5"
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
        'Me.Controls.Add(Drive1)
		Me.Controls.Add(chkFields)
		Me.Controls.Add(txtFields)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_lblLabels_0)
		Me.Controls.Add(_lblLabels_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class