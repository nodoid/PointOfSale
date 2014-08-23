<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChannel
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
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmbChannelPrice As System.Windows.Forms.ComboBox
	Public WithEvents _chkFields_5 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_4 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_3 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChannel))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me._optType_1 = New System.Windows.Forms.RadioButton
		Me._optType_0 = New System.Windows.Forms.RadioButton
		Me.cmbChannelPrice = New System.Windows.Forms.ComboBox
		Me._chkFields_5 = New System.Windows.Forms.CheckBox
		Me._chkFields_4 = New System.Windows.Forms.CheckBox
		Me._chkFields_3 = New System.Windows.Forms.CheckBox
		Me._txtFields_2 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
        'Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit Sale Channel Details"
		Me.ClientSize = New System.Drawing.Size(432, 298)
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
		Me.Name = "frmChannel"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Size = New System.Drawing.Size(67, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(264, 234)
		Me._txtFields_0.Maxlength = 5
		Me._txtFields_0.TabIndex = 16
		Me._txtFields_0.Visible = False
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_0.Name = "_txtFields_0"
		Me._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._optType_1.Text = "Price of default sales channel plus pricing group percentage"
		Me._optType_1.Size = New System.Drawing.Size(346, 16)
		Me._optType_1.Location = New System.Drawing.Point(54, 252)
		Me._optType_1.TabIndex = 15
		Me._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.CausesValidation = True
		Me._optType_1.Enabled = True
		Me._optType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_1.TabStop = True
		Me._optType_1.Checked = False
		Me._optType_1.Visible = True
		Me._optType_1.Name = "_optType_1"
		Me._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._optType_0.Text = "Cost plus pricing group percentage"
		Me._optType_0.Size = New System.Drawing.Size(346, 16)
		Me._optType_0.Location = New System.Drawing.Point(54, 234)
		Me._optType_0.TabIndex = 13
		Me._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.CausesValidation = True
		Me._optType_0.Enabled = True
		Me._optType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_0.TabStop = True
		Me._optType_0.Checked = False
		Me._optType_0.Visible = True
		Me._optType_0.Name = "_optType_0"
		Me.cmbChannelPrice.Size = New System.Drawing.Size(196, 21)
		Me.cmbChannelPrice.Location = New System.Drawing.Point(78, 174)
		Me.cmbChannelPrice.Items.AddRange(New Object(){"No relationship", "Always the same or cheaper", "Always the same or more expensive"})
		Me.cmbChannelPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbChannelPrice.TabIndex = 11
		Me.cmbChannelPrice.BackColor = System.Drawing.SystemColors.Window
		Me.cmbChannelPrice.CausesValidation = True
		Me.cmbChannelPrice.Enabled = True
		Me.cmbChannelPrice.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbChannelPrice.IntegralHeight = True
		Me.cmbChannelPrice.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbChannelPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbChannelPrice.Sorted = False
		Me.cmbChannelPrice.TabStop = True
		Me.cmbChannelPrice.Visible = True
		Me.cmbChannelPrice.Name = "cmbChannelPrice"
		Me._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_5.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_5.Text = "Treat a case/carton price as the unit price when doing the pricing update:"
		Me._chkFields_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_5.Size = New System.Drawing.Size(373, 19)
		Me._chkFields_5.Location = New System.Drawing.Point(33, 135)
		Me._chkFields_5.TabIndex = 10
		Me._chkFields_5.CausesValidation = True
		Me._chkFields_5.Enabled = True
		Me._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_5.TabStop = True
		Me._chkFields_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_5.Visible = True
		Me._chkFields_5.Name = "_chkFields_5"
		Me._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_4.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_4.Text = "Do not use Pricing Strategy when doing pricing update:"
		Me._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_4.Size = New System.Drawing.Size(283, 19)
		Me._chkFields_4.Location = New System.Drawing.Point(123, 114)
		Me._chkFields_4.TabIndex = 9
		Me._chkFields_4.CausesValidation = True
		Me._chkFields_4.Enabled = True
		Me._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_4.TabStop = True
		Me._chkFields_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_4.Visible = True
		Me._chkFields_4.Name = "_chkFields_4"
		Me._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_3.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_3.Text = "Disable this sale channel on the POS:"
		Me._chkFields_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_3.Size = New System.Drawing.Size(202, 19)
		Me._chkFields_3.Location = New System.Drawing.Point(204, 93)
		Me._chkFields_3.TabIndex = 8
		Me._chkFields_3.CausesValidation = True
		Me._chkFields_3.Enabled = True
		Me._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_3.TabStop = True
		Me._chkFields_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_3.Visible = True
		Me._chkFields_3.Name = "_chkFields_3"
		Me._txtFields_2.AutoSize = False
		Me._txtFields_2.Size = New System.Drawing.Size(49, 19)
		Me._txtFields_2.Location = New System.Drawing.Point(357, 69)
		Me._txtFields_2.Maxlength = 5
		Me._txtFields_2.TabIndex = 7
		Me._txtFields_2.AcceptsReturn = True
		Me._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_2.CausesValidation = True
		Me._txtFields_2.Enabled = True
		Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_2.HideSelection = True
		Me._txtFields_2.ReadOnly = False
		Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_2.MultiLine = False
		Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_2.TabStop = True
		Me._txtFields_2.Visible = True
		Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_2.Name = "_txtFields_2"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.Size = New System.Drawing.Size(217, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(66, 69)
		Me._txtFields_1.TabIndex = 5
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
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
		Me.picButtons.Size = New System.Drawing.Size(432, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 2
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
		Me.cmdCancel.TabIndex = 1
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
		Me.cmdClose.Location = New System.Drawing.Point(351, 3)
		Me.cmdClose.TabIndex = 0
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me._Label1_1.Text = "When calculating exit price percentages, prices are calculated as,"
		Me._Label1_1.Size = New System.Drawing.Size(388, 16)
		Me._Label1_1.Location = New System.Drawing.Point(21, 216)
		Me._Label1_1.TabIndex = 14
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.Text = "When doing the pricing calculation this Sale Channel relationship to the First Sale Channel is,"
		Me._Label1_0.Size = New System.Drawing.Size(388, 43)
		Me._Label1_0.Location = New System.Drawing.Point(21, 159)
		Me._Label1_0.TabIndex = 12
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_2.BackColor = System.Drawing.Color.Transparent
		Me._lblLabels_2.Text = "Short Name:"
		Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_2.Size = New System.Drawing.Size(61, 13)
		Me._lblLabels_2.Location = New System.Drawing.Point(291, 72)
		Me._lblLabels_2.TabIndex = 6
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
		Me._lblLabels_1.Text = "Name:"
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lblLabels_1.Size = New System.Drawing.Size(31, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(27, 72)
		Me._lblLabels_1.TabIndex = 4
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
		Me._Shape1_2.Size = New System.Drawing.Size(403, 220)
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
		Me._lbl_5.TabIndex = 3
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
		Me.Controls.Add(_txtFields_0)
		Me.Controls.Add(_optType_1)
		Me.Controls.Add(_optType_0)
		Me.Controls.Add(cmbChannelPrice)
		Me.Controls.Add(_chkFields_5)
		Me.Controls.Add(_chkFields_4)
		Me.Controls.Add(_chkFields_3)
		Me.Controls.Add(_txtFields_2)
		Me.Controls.Add(_txtFields_1)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
		Me.Controls.Add(_lblLabels_2)
		Me.Controls.Add(_lblLabels_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.chkFields.SetIndex(_chkFields_5, CType(5, Short))
        'Me.chkFields.SetIndex(_chkFields_4, CType(4, Short))
        'Me.chkFields.SetIndex(_chkFields_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.optType.SetIndex(_optType_1, CType(1, Short))
        'Me.optType.SetIndex(_optType_0, CType(0, Short))
        'Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
        'Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
        'Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
        'Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class