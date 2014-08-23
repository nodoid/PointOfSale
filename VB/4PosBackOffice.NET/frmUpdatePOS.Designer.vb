<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUpdatePOS
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
	Public WithEvents tmrMEndUpdatePOS As System.Windows.Forms.Timer
	Public WithEvents cmdScale As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdPrintNew As System.Windows.Forms.Button
	Public WithEvents cmdPrintAmend As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _txtNew_8 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_8 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtNew_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtAmend_1 As System.Windows.Forms.TextBox
	Public WithEvents lblInstructionNew As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblInstruction As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lblCG_7 As System.Windows.Forms.Label
	Public WithEvents _lblCG_6 As System.Windows.Forms.Label
	Public WithEvents _lblCG_5 As System.Windows.Forms.Label
	Public WithEvents _lblCG_4 As System.Windows.Forms.Label
	Public WithEvents _lblCG_3 As System.Windows.Forms.Label
	Public WithEvents _lblCG_2 As System.Windows.Forms.Label
	Public WithEvents _lblCG_1 As System.Windows.Forms.Label
	Public WithEvents _lblCG_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_33 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_34 As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblCG As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtAmend As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtNew As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdatePOS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.tmrMEndUpdatePOS = New System.Windows.Forms.Timer(components)
		Me.cmdScale = New System.Windows.Forms.Button
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrintNew = New System.Windows.Forms.Button
		Me.cmdPrintAmend = New System.Windows.Forms.Button
		Me._txtNew_8 = New System.Windows.Forms.TextBox
		Me._txtAmend_8 = New System.Windows.Forms.TextBox
		Me._txtNew_7 = New System.Windows.Forms.TextBox
		Me._txtAmend_7 = New System.Windows.Forms.TextBox
		Me._txtNew_6 = New System.Windows.Forms.TextBox
		Me._txtAmend_6 = New System.Windows.Forms.TextBox
		Me._txtNew_5 = New System.Windows.Forms.TextBox
		Me._txtAmend_5 = New System.Windows.Forms.TextBox
		Me._txtNew_4 = New System.Windows.Forms.TextBox
		Me._txtAmend_4 = New System.Windows.Forms.TextBox
		Me._txtNew_3 = New System.Windows.Forms.TextBox
		Me._txtAmend_3 = New System.Windows.Forms.TextBox
		Me._txtNew_2 = New System.Windows.Forms.TextBox
		Me._txtAmend_2 = New System.Windows.Forms.TextBox
		Me._txtNew_1 = New System.Windows.Forms.TextBox
		Me._txtAmend_1 = New System.Windows.Forms.TextBox
		Me.lblInstructionNew = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblInstruction = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lblCG_7 = New System.Windows.Forms.Label
		Me._lblCG_6 = New System.Windows.Forms.Label
		Me._lblCG_5 = New System.Windows.Forms.Label
		Me._lblCG_4 = New System.Windows.Forms.Label
		Me._lblCG_3 = New System.Windows.Forms.Label
		Me._lblCG_2 = New System.Windows.Forms.Label
		Me._lblCG_1 = New System.Windows.Forms.Label
		Me._lblCG_0 = New System.Windows.Forms.Label
		Me._lblLabels_33 = New System.Windows.Forms.Label
		Me._lblLabels_34 = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblCG = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtAmend = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        'Me.txtNew = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblCG, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtAmend, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtNew, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Update Point Of Sale"
		Me.ClientSize = New System.Drawing.Size(490, 229)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmUpdatePOS"
		Me.tmrMEndUpdatePOS.Enabled = False
		Me.tmrMEndUpdatePOS.Interval = 10
		Me.cmdScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdScale.Text = "Force &Scale Update"
		Me.cmdScale.Size = New System.Drawing.Size(127, 34)
		Me.cmdScale.Location = New System.Drawing.Point(12, 186)
		Me.cmdScale.TabIndex = 36
		Me.cmdScale.BackColor = System.Drawing.SystemColors.Control
		Me.cmdScale.CausesValidation = True
		Me.cmdScale.Enabled = True
		Me.cmdScale.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdScale.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdScale.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdScale.TabStop = True
		Me.cmdScale.Name = "cmdScale"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(490, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 27
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Print &Barcodes"
		Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Command1.Size = New System.Drawing.Size(105, 29)
		Me.Command1.Location = New System.Drawing.Point(168, 3)
		Me.Command1.TabIndex = 37
		Me.Command1.TabStop = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.Name = "Command1"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "&Update POS"
		Me.cmdUpdate.Size = New System.Drawing.Size(73, 29)
		Me.cmdUpdate.Location = New System.Drawing.Point(328, 3)
		Me.cmdUpdate.TabIndex = 35
		Me.cmdUpdate.TabStop = False
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(408, 3)
		Me.cmdClose.TabIndex = 30
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cmdPrintNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintNew.Text = "Print &New"
		Me.cmdPrintNew.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrintNew.Location = New System.Drawing.Point(5, 3)
		Me.cmdPrintNew.TabIndex = 29
		Me.cmdPrintNew.TabStop = False
		Me.cmdPrintNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintNew.CausesValidation = True
		Me.cmdPrintNew.Enabled = True
		Me.cmdPrintNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintNew.Name = "cmdPrintNew"
		Me.cmdPrintAmend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrintAmend.Text = "Print &Amend"
		Me.cmdPrintAmend.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrintAmend.Location = New System.Drawing.Point(88, 3)
		Me.cmdPrintAmend.TabIndex = 28
		Me.cmdPrintAmend.TabStop = False
		Me.cmdPrintAmend.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrintAmend.CausesValidation = True
		Me.cmdPrintAmend.Enabled = True
		Me.cmdPrintAmend.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrintAmend.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrintAmend.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrintAmend.Name = "cmdPrintAmend"
		Me._txtNew_8.AutoSize = False
		Me._txtNew_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_8.Enabled = False
		Me._txtNew_8.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_8.Location = New System.Drawing.Point(423, 105)
		Me._txtNew_8.TabIndex = 15
		Me._txtNew_8.Text = "0"
		Me._txtNew_8.AcceptsReturn = True
		Me._txtNew_8.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_8.CausesValidation = True
		Me._txtNew_8.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_8.HideSelection = True
		Me._txtNew_8.ReadOnly = False
		Me._txtNew_8.Maxlength = 0
		Me._txtNew_8.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_8.MultiLine = False
		Me._txtNew_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_8.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_8.TabStop = True
		Me._txtNew_8.Visible = True
		Me._txtNew_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_8.Name = "_txtNew_8"
		Me._txtAmend_8.AutoSize = False
		Me._txtAmend_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_8.Enabled = False
		Me._txtAmend_8.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_8.Location = New System.Drawing.Point(423, 87)
		Me._txtAmend_8.TabIndex = 14
		Me._txtAmend_8.Text = "0"
		Me._txtAmend_8.AcceptsReturn = True
		Me._txtAmend_8.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_8.CausesValidation = True
		Me._txtAmend_8.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_8.HideSelection = True
		Me._txtAmend_8.ReadOnly = False
		Me._txtAmend_8.Maxlength = 0
		Me._txtAmend_8.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_8.MultiLine = False
		Me._txtAmend_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_8.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_8.TabStop = True
		Me._txtAmend_8.Visible = True
		Me._txtAmend_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_8.Name = "_txtAmend_8"
		Me._txtNew_7.AutoSize = False
		Me._txtNew_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_7.Enabled = False
		Me._txtNew_7.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_7.Location = New System.Drawing.Point(372, 105)
		Me._txtNew_7.TabIndex = 13
		Me._txtNew_7.Text = "0"
		Me._txtNew_7.AcceptsReturn = True
		Me._txtNew_7.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_7.CausesValidation = True
		Me._txtNew_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_7.HideSelection = True
		Me._txtNew_7.ReadOnly = False
		Me._txtNew_7.Maxlength = 0
		Me._txtNew_7.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_7.MultiLine = False
		Me._txtNew_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_7.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_7.TabStop = True
		Me._txtNew_7.Visible = True
		Me._txtNew_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_7.Name = "_txtNew_7"
		Me._txtAmend_7.AutoSize = False
		Me._txtAmend_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_7.Enabled = False
		Me._txtAmend_7.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_7.Location = New System.Drawing.Point(372, 87)
		Me._txtAmend_7.TabIndex = 12
		Me._txtAmend_7.Text = "0"
		Me._txtAmend_7.AcceptsReturn = True
		Me._txtAmend_7.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_7.CausesValidation = True
		Me._txtAmend_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_7.HideSelection = True
		Me._txtAmend_7.ReadOnly = False
		Me._txtAmend_7.Maxlength = 0
		Me._txtAmend_7.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_7.MultiLine = False
		Me._txtAmend_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_7.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_7.TabStop = True
		Me._txtAmend_7.Visible = True
		Me._txtAmend_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_7.Name = "_txtAmend_7"
		Me._txtNew_6.AutoSize = False
		Me._txtNew_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_6.Enabled = False
		Me._txtNew_6.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_6.Location = New System.Drawing.Point(321, 105)
		Me._txtNew_6.TabIndex = 11
		Me._txtNew_6.Text = "0"
		Me._txtNew_6.AcceptsReturn = True
		Me._txtNew_6.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_6.CausesValidation = True
		Me._txtNew_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_6.HideSelection = True
		Me._txtNew_6.ReadOnly = False
		Me._txtNew_6.Maxlength = 0
		Me._txtNew_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_6.MultiLine = False
		Me._txtNew_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_6.TabStop = True
		Me._txtNew_6.Visible = True
		Me._txtNew_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_6.Name = "_txtNew_6"
		Me._txtAmend_6.AutoSize = False
		Me._txtAmend_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_6.Enabled = False
		Me._txtAmend_6.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_6.Location = New System.Drawing.Point(321, 87)
		Me._txtAmend_6.TabIndex = 10
		Me._txtAmend_6.Text = "0"
		Me._txtAmend_6.AcceptsReturn = True
		Me._txtAmend_6.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_6.CausesValidation = True
		Me._txtAmend_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_6.HideSelection = True
		Me._txtAmend_6.ReadOnly = False
		Me._txtAmend_6.Maxlength = 0
		Me._txtAmend_6.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_6.MultiLine = False
		Me._txtAmend_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_6.TabStop = True
		Me._txtAmend_6.Visible = True
		Me._txtAmend_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_6.Name = "_txtAmend_6"
		Me._txtNew_5.AutoSize = False
		Me._txtNew_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_5.Enabled = False
		Me._txtNew_5.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_5.Location = New System.Drawing.Point(270, 105)
		Me._txtNew_5.TabIndex = 9
		Me._txtNew_5.Text = "0"
		Me._txtNew_5.AcceptsReturn = True
		Me._txtNew_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_5.CausesValidation = True
		Me._txtNew_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_5.HideSelection = True
		Me._txtNew_5.ReadOnly = False
		Me._txtNew_5.Maxlength = 0
		Me._txtNew_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_5.MultiLine = False
		Me._txtNew_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_5.TabStop = True
		Me._txtNew_5.Visible = True
		Me._txtNew_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_5.Name = "_txtNew_5"
		Me._txtAmend_5.AutoSize = False
		Me._txtAmend_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_5.Enabled = False
		Me._txtAmend_5.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_5.Location = New System.Drawing.Point(270, 87)
		Me._txtAmend_5.TabIndex = 8
		Me._txtAmend_5.Text = "0"
		Me._txtAmend_5.AcceptsReturn = True
		Me._txtAmend_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_5.CausesValidation = True
		Me._txtAmend_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_5.HideSelection = True
		Me._txtAmend_5.ReadOnly = False
		Me._txtAmend_5.Maxlength = 0
		Me._txtAmend_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_5.MultiLine = False
		Me._txtAmend_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_5.TabStop = True
		Me._txtAmend_5.Visible = True
		Me._txtAmend_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_5.Name = "_txtAmend_5"
		Me._txtNew_4.AutoSize = False
		Me._txtNew_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_4.Enabled = False
		Me._txtNew_4.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_4.Location = New System.Drawing.Point(219, 105)
		Me._txtNew_4.TabIndex = 7
		Me._txtNew_4.Text = "0"
		Me._txtNew_4.AcceptsReturn = True
		Me._txtNew_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_4.CausesValidation = True
		Me._txtNew_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_4.HideSelection = True
		Me._txtNew_4.ReadOnly = False
		Me._txtNew_4.Maxlength = 0
		Me._txtNew_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_4.MultiLine = False
		Me._txtNew_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_4.TabStop = True
		Me._txtNew_4.Visible = True
		Me._txtNew_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_4.Name = "_txtNew_4"
		Me._txtAmend_4.AutoSize = False
		Me._txtAmend_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_4.Enabled = False
		Me._txtAmend_4.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_4.Location = New System.Drawing.Point(219, 87)
		Me._txtAmend_4.TabIndex = 6
		Me._txtAmend_4.Text = "0"
		Me._txtAmend_4.AcceptsReturn = True
		Me._txtAmend_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_4.CausesValidation = True
		Me._txtAmend_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_4.HideSelection = True
		Me._txtAmend_4.ReadOnly = False
		Me._txtAmend_4.Maxlength = 0
		Me._txtAmend_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_4.MultiLine = False
		Me._txtAmend_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_4.TabStop = True
		Me._txtAmend_4.Visible = True
		Me._txtAmend_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_4.Name = "_txtAmend_4"
		Me._txtNew_3.AutoSize = False
		Me._txtNew_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_3.Enabled = False
		Me._txtNew_3.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_3.Location = New System.Drawing.Point(168, 105)
		Me._txtNew_3.TabIndex = 5
		Me._txtNew_3.Text = "0"
		Me._txtNew_3.AcceptsReturn = True
		Me._txtNew_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_3.CausesValidation = True
		Me._txtNew_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_3.HideSelection = True
		Me._txtNew_3.ReadOnly = False
		Me._txtNew_3.Maxlength = 0
		Me._txtNew_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_3.MultiLine = False
		Me._txtNew_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_3.TabStop = True
		Me._txtNew_3.Visible = True
		Me._txtNew_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_3.Name = "_txtNew_3"
		Me._txtAmend_3.AutoSize = False
		Me._txtAmend_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_3.Enabled = False
		Me._txtAmend_3.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_3.Location = New System.Drawing.Point(168, 87)
		Me._txtAmend_3.TabIndex = 4
		Me._txtAmend_3.Text = "0"
		Me._txtAmend_3.AcceptsReturn = True
		Me._txtAmend_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_3.CausesValidation = True
		Me._txtAmend_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_3.HideSelection = True
		Me._txtAmend_3.ReadOnly = False
		Me._txtAmend_3.Maxlength = 0
		Me._txtAmend_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_3.MultiLine = False
		Me._txtAmend_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_3.TabStop = True
		Me._txtAmend_3.Visible = True
		Me._txtAmend_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_3.Name = "_txtAmend_3"
		Me._txtNew_2.AutoSize = False
		Me._txtNew_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_2.Enabled = False
		Me._txtNew_2.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_2.Location = New System.Drawing.Point(117, 105)
		Me._txtNew_2.TabIndex = 3
		Me._txtNew_2.Text = "0"
		Me._txtNew_2.AcceptsReturn = True
		Me._txtNew_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_2.CausesValidation = True
		Me._txtNew_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_2.HideSelection = True
		Me._txtNew_2.ReadOnly = False
		Me._txtNew_2.Maxlength = 0
		Me._txtNew_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_2.MultiLine = False
		Me._txtNew_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_2.TabStop = True
		Me._txtNew_2.Visible = True
		Me._txtNew_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_2.Name = "_txtNew_2"
		Me._txtAmend_2.AutoSize = False
		Me._txtAmend_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_2.Enabled = False
		Me._txtAmend_2.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_2.Location = New System.Drawing.Point(117, 87)
		Me._txtAmend_2.TabIndex = 2
		Me._txtAmend_2.Text = "0"
		Me._txtAmend_2.AcceptsReturn = True
		Me._txtAmend_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_2.CausesValidation = True
		Me._txtAmend_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_2.HideSelection = True
		Me._txtAmend_2.ReadOnly = False
		Me._txtAmend_2.Maxlength = 0
		Me._txtAmend_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_2.MultiLine = False
		Me._txtAmend_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_2.TabStop = True
		Me._txtAmend_2.Visible = True
		Me._txtAmend_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_2.Name = "_txtAmend_2"
		Me._txtNew_1.AutoSize = False
		Me._txtNew_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtNew_1.Enabled = False
		Me._txtNew_1.Size = New System.Drawing.Size(49, 19)
		Me._txtNew_1.Location = New System.Drawing.Point(66, 105)
		Me._txtNew_1.TabIndex = 1
		Me._txtNew_1.Text = "0"
		Me._txtNew_1.AcceptsReturn = True
		Me._txtNew_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtNew_1.CausesValidation = True
		Me._txtNew_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtNew_1.HideSelection = True
		Me._txtNew_1.ReadOnly = False
		Me._txtNew_1.Maxlength = 0
		Me._txtNew_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtNew_1.MultiLine = False
		Me._txtNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtNew_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtNew_1.TabStop = True
		Me._txtNew_1.Visible = True
		Me._txtNew_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtNew_1.Name = "_txtNew_1"
		Me._txtAmend_1.AutoSize = False
		Me._txtAmend_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtAmend_1.Enabled = False
		Me._txtAmend_1.Size = New System.Drawing.Size(49, 19)
		Me._txtAmend_1.Location = New System.Drawing.Point(66, 87)
		Me._txtAmend_1.TabIndex = 0
		Me._txtAmend_1.Text = "0"
		Me._txtAmend_1.AcceptsReturn = True
		Me._txtAmend_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtAmend_1.CausesValidation = True
		Me._txtAmend_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtAmend_1.HideSelection = True
		Me._txtAmend_1.ReadOnly = False
		Me._txtAmend_1.Maxlength = 0
		Me._txtAmend_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtAmend_1.MultiLine = False
		Me._txtAmend_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtAmend_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtAmend_1.TabStop = True
		Me._txtAmend_1.Visible = True
		Me._txtAmend_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtAmend_1.Name = "_txtAmend_1"
		Me.lblInstructionNew.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInstructionNew.Text = "9999"
		Me.lblInstructionNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInstructionNew.Size = New System.Drawing.Size(31, 13)
		Me.lblInstructionNew.Location = New System.Drawing.Point(450, 165)
		Me.lblInstructionNew.TabIndex = 34
		Me.lblInstructionNew.BackColor = System.Drawing.Color.Transparent
		Me.lblInstructionNew.Enabled = True
		Me.lblInstructionNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInstructionNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInstructionNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInstructionNew.UseMnemonic = True
		Me.lblInstructionNew.Visible = True
		Me.lblInstructionNew.AutoSize = False
		Me.lblInstructionNew.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblInstructionNew.Name = "lblInstructionNew"
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_2.Text = "After this update the new POS instruction number will be"
		Me._lbl_2.Size = New System.Drawing.Size(265, 13)
		Me._lbl_2.Location = New System.Drawing.Point(183, 165)
		Me._lbl_2.TabIndex = 33
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = True
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "The current POS update instruction number is "
		Me._lbl_0.Size = New System.Drawing.Size(220, 13)
		Me._lbl_0.Location = New System.Drawing.Point(228, 147)
		Me._lbl_0.TabIndex = 32
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblInstruction.Text = "9999"
		Me.lblInstruction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblInstruction.Size = New System.Drawing.Size(31, 13)
		Me.lblInstruction.Location = New System.Drawing.Point(450, 147)
		Me.lblInstruction.TabIndex = 31
		Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
		Me.lblInstruction.Enabled = True
		Me.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblInstruction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblInstruction.UseMnemonic = True
		Me.lblInstruction.Visible = True
		Me.lblInstruction.AutoSize = False
		Me.lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblInstruction.Name = "lblInstruction"
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Text = "Number of Stock Items that will be effected by the update."
		Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_1.Size = New System.Drawing.Size(333, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 54)
		Me._lbl_1.TabIndex = 26
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lblCG_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_7.Text = "PricingGroup_Case6:"
		Me._lblCG_7.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_7.Location = New System.Drawing.Point(423, 75)
		Me._lblCG_7.TabIndex = 25
		Me._lblCG_7.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_7.Enabled = True
		Me._lblCG_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_7.UseMnemonic = True
		Me._lblCG_7.Visible = True
		Me._lblCG_7.AutoSize = False
		Me._lblCG_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_7.Name = "_lblCG_7"
		Me._lblCG_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_6.Text = "PricingGroup_Unit6:"
		Me._lblCG_6.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_6.Location = New System.Drawing.Point(372, 75)
		Me._lblCG_6.TabIndex = 24
		Me._lblCG_6.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_6.Enabled = True
		Me._lblCG_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_6.UseMnemonic = True
		Me._lblCG_6.Visible = True
		Me._lblCG_6.AutoSize = False
		Me._lblCG_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_6.Name = "_lblCG_6"
		Me._lblCG_5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_5.Text = "PricingGroup_Case5:"
		Me._lblCG_5.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_5.Location = New System.Drawing.Point(321, 75)
		Me._lblCG_5.TabIndex = 23
		Me._lblCG_5.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_5.Enabled = True
		Me._lblCG_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_5.UseMnemonic = True
		Me._lblCG_5.Visible = True
		Me._lblCG_5.AutoSize = False
		Me._lblCG_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_5.Name = "_lblCG_5"
		Me._lblCG_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_4.Text = "PricingGroup_Unit5:"
		Me._lblCG_4.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_4.Location = New System.Drawing.Point(270, 75)
		Me._lblCG_4.TabIndex = 22
		Me._lblCG_4.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_4.Enabled = True
		Me._lblCG_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_4.UseMnemonic = True
		Me._lblCG_4.Visible = True
		Me._lblCG_4.AutoSize = False
		Me._lblCG_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_4.Name = "_lblCG_4"
		Me._lblCG_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_3.Text = "PricingGroup_Case4:"
		Me._lblCG_3.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_3.Location = New System.Drawing.Point(219, 75)
		Me._lblCG_3.TabIndex = 21
		Me._lblCG_3.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_3.Enabled = True
		Me._lblCG_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_3.UseMnemonic = True
		Me._lblCG_3.Visible = True
		Me._lblCG_3.AutoSize = False
		Me._lblCG_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_3.Name = "_lblCG_3"
		Me._lblCG_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_2.Text = "PricingGroup_Unit4:"
		Me._lblCG_2.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_2.Location = New System.Drawing.Point(168, 75)
		Me._lblCG_2.TabIndex = 20
		Me._lblCG_2.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_2.Enabled = True
		Me._lblCG_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_2.UseMnemonic = True
		Me._lblCG_2.Visible = True
		Me._lblCG_2.AutoSize = False
		Me._lblCG_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_2.Name = "_lblCG_2"
		Me._lblCG_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_1.Text = "PricingGroup_Case3:"
		Me._lblCG_1.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_1.Location = New System.Drawing.Point(117, 75)
		Me._lblCG_1.TabIndex = 19
		Me._lblCG_1.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_1.Enabled = True
		Me._lblCG_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_1.UseMnemonic = True
		Me._lblCG_1.Visible = True
		Me._lblCG_1.AutoSize = False
		Me._lblCG_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_1.Name = "_lblCG_1"
		Me._lblCG_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lblCG_0.Text = "PricingGroup_Unit3:"
		Me._lblCG_0.Size = New System.Drawing.Size(49, 13)
		Me._lblCG_0.Location = New System.Drawing.Point(66, 75)
		Me._lblCG_0.TabIndex = 18
		Me._lblCG_0.BackColor = System.Drawing.Color.Transparent
		Me._lblCG_0.Enabled = True
		Me._lblCG_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblCG_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblCG_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblCG_0.UseMnemonic = True
		Me._lblCG_0.Visible = True
		Me._lblCG_0.AutoSize = False
		Me._lblCG_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblCG_0.Name = "_lblCG_0"
		Me._lblLabels_33.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_33.Text = "New :"
		Me._lblLabels_33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblLabels_33.Size = New System.Drawing.Size(34, 13)
		Me._lblLabels_33.Location = New System.Drawing.Point(27, 107)
		Me._lblLabels_33.TabIndex = 17
		Me._lblLabels_33.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_33.Enabled = True
		Me._lblLabels_33.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_33.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_33.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_33.UseMnemonic = True
		Me._lblLabels_33.Visible = True
		Me._lblLabels_33.AutoSize = True
		Me._lblLabels_33.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_33.Name = "_lblLabels_33"
		Me._lblLabels_34.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_34.Text = "Amend :"
		Me._lblLabels_34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblLabels_34.Size = New System.Drawing.Size(47, 13)
		Me._lblLabels_34.Location = New System.Drawing.Point(14, 88)
		Me._lblLabels_34.TabIndex = 16
		Me._lblLabels_34.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_34.Enabled = True
		Me._lblLabels_34.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_34.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_34.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_34.UseMnemonic = True
		Me._lblLabels_34.Visible = True
		Me._lblLabels_34.AutoSize = True
		Me._lblLabels_34.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_34.Name = "_lblLabels_34"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(472, 67)
		Me._Shape1_1.Location = New System.Drawing.Point(9, 69)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me.Controls.Add(cmdScale)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_txtNew_8)
		Me.Controls.Add(_txtAmend_8)
		Me.Controls.Add(_txtNew_7)
		Me.Controls.Add(_txtAmend_7)
		Me.Controls.Add(_txtNew_6)
		Me.Controls.Add(_txtAmend_6)
		Me.Controls.Add(_txtNew_5)
		Me.Controls.Add(_txtAmend_5)
		Me.Controls.Add(_txtNew_4)
		Me.Controls.Add(_txtAmend_4)
		Me.Controls.Add(_txtNew_3)
		Me.Controls.Add(_txtAmend_3)
		Me.Controls.Add(_txtNew_2)
		Me.Controls.Add(_txtAmend_2)
		Me.Controls.Add(_txtNew_1)
		Me.Controls.Add(_txtAmend_1)
		Me.Controls.Add(lblInstructionNew)
		Me.Controls.Add(_lbl_2)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblInstruction)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lblCG_7)
		Me.Controls.Add(_lblCG_6)
		Me.Controls.Add(_lblCG_5)
		Me.Controls.Add(_lblCG_4)
		Me.Controls.Add(_lblCG_3)
		Me.Controls.Add(_lblCG_2)
		Me.Controls.Add(_lblCG_1)
		Me.Controls.Add(_lblCG_0)
		Me.Controls.Add(_lblLabels_33)
		Me.Controls.Add(_lblLabels_34)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(Command1)
		Me.picButtons.Controls.Add(cmdUpdate)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdPrintNew)
		Me.picButtons.Controls.Add(cmdPrintAmend)
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lblCG.SetIndex(_lblCG_7, CType(7, Short))
        'Me.lblCG.SetIndex(_lblCG_6, CType(6, Short))
        'Me.lblCG.SetIndex(_lblCG_5, CType(5, Short))
        'Me.lblCG.SetIndex(_lblCG_4, CType(4, Short))
        'Me.lblCG.SetIndex(_lblCG_3, CType(3, Short))
        'Me.lblCG.SetIndex(_lblCG_2, CType(2, Short))
        'Me.lblCG.SetIndex(_lblCG_1, CType(1, Short))
        'Me.lblCG.SetIndex(_lblCG_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_33, CType(33, Short))
        'Me.lblLabels.SetIndex(_lblLabels_34, CType(34, Short))
        'Me.txtAmend.SetIndex(_txtAmend_8, CType(8, Short))
        'Me.txtAmend.SetIndex(_txtAmend_7, CType(7, Short))
        'Me.txtAmend.SetIndex(_txtAmend_6, CType(6, Short))
        'Me.txtAmend.SetIndex(_txtAmend_5, CType(5, Short))
        'Me.txtAmend.SetIndex(_txtAmend_4, CType(4, Short))
        'Me.txtAmend.SetIndex(_txtAmend_3, CType(3, Short))
        'Me.txtAmend.SetIndex(_txtAmend_2, CType(2, Short))
        'Me.txtAmend.SetIndex(_txtAmend_1, CType(1, Short))
        'Me.txtNew.SetIndex(_txtNew_8, CType(8, Short))
        'Me.txtNew.SetIndex(_txtNew_7, CType(7, Short))
        'Me.txtNew.SetIndex(_txtNew_6, CType(6, Short))
        'Me.txtNew.SetIndex(_txtNew_5, CType(5, Short))
        'Me.txtNew.SetIndex(_txtNew_4, CType(4, Short))
        'Me.txtNew.SetIndex(_txtNew_3, CType(3, Short))
        'Me.txtNew.SetIndex(_txtNew_2, CType(2, Short))
        'Me.txtNew.SetIndex(_txtNew_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtNew, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtAmend, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblCG, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class