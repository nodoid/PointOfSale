<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMonthendBudget
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
	Public WithEvents _txtFloat_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtInteger_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents lblMonth As System.Windows.Forms.Label
	Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMonthendBudget))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._txtFloat_1 = New System.Windows.Forms.TextBox
		Me._txtInteger_0 = New System.Windows.Forms.TextBox
		Me._txtFloat_0 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me.lblMonth = New System.Windows.Forms.Label
		Me._lblLabels_38 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Month Budget"
		Me.ClientSize = New System.Drawing.Size(382, 180)
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
		Me.Name = "frmMonthendBudget"
		Me._txtFloat_1.AutoSize = False
		Me._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFloat_1.Size = New System.Drawing.Size(88, 19)
		Me._txtFloat_1.Location = New System.Drawing.Point(267, 120)
		Me._txtFloat_1.TabIndex = 6
		Me._txtFloat_1.Text = "9,999.99"
		Me._txtFloat_1.AcceptsReturn = True
		Me._txtFloat_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFloat_1.CausesValidation = True
		Me._txtFloat_1.Enabled = True
		Me._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFloat_1.HideSelection = True
		Me._txtFloat_1.ReadOnly = False
		Me._txtFloat_1.Maxlength = 0
		Me._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFloat_1.MultiLine = False
		Me._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFloat_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFloat_1.TabStop = True
		Me._txtFloat_1.Visible = True
		Me._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFloat_1.Name = "_txtFloat_1"
		Me._txtInteger_0.AutoSize = False
		Me._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtInteger_0.Size = New System.Drawing.Size(43, 19)
		Me._txtInteger_0.Location = New System.Drawing.Point(267, 99)
		Me._txtInteger_0.TabIndex = 4
		Me._txtInteger_0.Text = "999"
		Me._txtInteger_0.AcceptsReturn = True
		Me._txtInteger_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtInteger_0.CausesValidation = True
		Me._txtInteger_0.Enabled = True
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
		Me._txtFloat_0.AutoSize = False
		Me._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFloat_0.Size = New System.Drawing.Size(88, 19)
		Me._txtFloat_0.Location = New System.Drawing.Point(267, 141)
		Me._txtFloat_0.TabIndex = 8
		Me._txtFloat_0.Text = "9,999.99"
		Me._txtFloat_0.AcceptsReturn = True
		Me._txtFloat_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFloat_0.CausesValidation = True
		Me._txtFloat_0.Enabled = True
		Me._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFloat_0.HideSelection = True
		Me._txtFloat_0.ReadOnly = False
		Me._txtFloat_0.Maxlength = 0
		Me._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFloat_0.MultiLine = False
		Me._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFloat_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFloat_0.TabStop = True
		Me._txtFloat_0.Visible = True
		Me._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFloat_0.Name = "_txtFloat_0"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(382, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 11
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
		Me.cmdCancel.TabIndex = 10
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
		Me.cmdClose.Location = New System.Drawing.Point(300, 3)
		Me.cmdClose.TabIndex = 9
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.Text = "Total Budget of Sales for the Month:"
		Me._lblLabels_2.Size = New System.Drawing.Size(171, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(93, 141)
		Me._lblLabels_2.TabIndex = 7
		Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_2.Enabled = True
		Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_2.UseMnemonic = True
		Me._lblLabels_2.Visible = True
		Me._lblLabels_2.AutoSize = True
		Me._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_2.Name = "_lblLabels_2"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.Text = "Total Budget of Purchases for the Month:"
		Me._lblLabels_1.Size = New System.Drawing.Size(195, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(70, 120)
		Me._lblLabels_1.TabIndex = 5
		Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_1.Enabled = True
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_1.UseMnemonic = True
		Me._lblLabels_1.Visible = True
		Me._lblLabels_1.AutoSize = True
		Me._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_1.Name = "_lblLabels_1"
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_0.Text = "Number of Expected Day Ends in the Month:"
		Me._lblLabels_0.Size = New System.Drawing.Size(211, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(54, 99)
		Me._lblLabels_0.TabIndex = 3
		Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.Visible = True
		Me._lblLabels_0.AutoSize = True
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me.lblMonth.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.lblMonth.Text = "..."
		Me.lblMonth.Size = New System.Drawing.Size(229, 19)
		Me.lblMonth.Location = New System.Drawing.Point(129, 66)
		Me.lblMonth.TabIndex = 2
		Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMonth.Enabled = True
		Me.lblMonth.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMonth.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMonth.UseMnemonic = True
		Me.lblMonth.Visible = True
		Me.lblMonth.AutoSize = False
		Me.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblMonth.Name = "lblMonth"
		Me._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_38.Text = "Month End :"
		Me._lblLabels_38.Size = New System.Drawing.Size(58, 13)
		Me._lblLabels_38.Location = New System.Drawing.Point(63, 69)
		Me._lblLabels_38.TabIndex = 1
		Me._lblLabels_38.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_38.Enabled = True
		Me._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_38.UseMnemonic = True
		Me._lblLabels_38.Visible = True
		Me._lblLabels_38.AutoSize = True
		Me._lblLabels_38.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_38.Name = "_lblLabels_38"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(355, 109)
		Me._Shape1_2.Location = New System.Drawing.Point(15, 60)
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
		Me._lbl_5.Location = New System.Drawing.Point(15, 45)
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
		Me.Controls.Add(_txtFloat_1)
		Me.Controls.Add(_txtInteger_0)
		Me.Controls.Add(_txtFloat_0)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_lblLabels_2)
		Me.Controls.Add(_lblLabels_1)
		Me.Controls.Add(_lblLabels_0)
		Me.Controls.Add(lblMonth)
		Me.Controls.Add(_lblLabels_38)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
        'Me.txtFloat.SetIndex(_txtFloat_1, CType(1, Short))
        'Me.txtFloat.SetIndex(_txtFloat_0, CType(0, Short))
        'Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class