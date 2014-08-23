<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVPromotion
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
    Public WithEvents _DTFields_3 As System.Windows.Forms.DateTimePicker
    Public WithEvents _DTFields_2 As System.Windows.Forms.DateTimePicker
	Public WithEvents _chkFields_2 As System.Windows.Forms.CheckBox
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents lvPromotion As System.Windows.Forms.ListView
	Public WithEvents _chkFields_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkFields_0 As System.Windows.Forms.CheckBox
    Public WithEvents _DTFields_0 As System.Windows.Forms.DateTimePicker
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents _DTFields_1 As System.Windows.Forms.DateTimePicker
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents DTFields As AxDTPickerArray
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVPromotion))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me._DTFields_3 = New System.Windows.Forms.DateTimePicker
        Me._DTFields_2 = New System.Windows.Forms.DateTimePicker
		Me._chkFields_2 = New System.Windows.Forms.CheckBox
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.lvPromotion = New System.Windows.Forms.ListView
		Me._chkFields_1 = New System.Windows.Forms.CheckBox
		Me._chkFields_0 = New System.Windows.Forms.CheckBox
        Me._DTFields_0 = New System.Windows.Forms.DateTimePicker
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
        Me._DTFields_1 = New System.Windows.Forms.DateTimePicker
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_38 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._lbl_5 = New System.Windows.Forms.Label
        'Me.DTFields = New AxDTPickerArray(components)
        'Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me._DTFields_3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._DTFields_2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._DTFields_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._DTFields_1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.DTFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Edit GRV Deal Details"
		Me.ClientSize = New System.Drawing.Size(455, 460)
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
		Me.Name = "frmGRVPromotion"
        '_DTFields_3.OcxState = CType(resources.GetObject("_DTFields_3.OcxState"), System.Windows.Forms.AxHost.State)
		Me._DTFields_3.Size = New System.Drawing.Size(130, 21)
		Me._DTFields_3.Location = New System.Drawing.Point(291, 112)
		Me._DTFields_3.TabIndex = 20
		Me._DTFields_3.Visible = False
		Me._DTFields_3.Name = "_DTFields_3"
        '_DTFields_2.OcxState = CType(resources.GetObject("_DTFields_2.OcxState"), System.Windows.Forms.AxHost.State)
		Me._DTFields_2.Size = New System.Drawing.Size(130, 21)
		Me._DTFields_2.Location = New System.Drawing.Point(104, 112)
		Me._DTFields_2.TabIndex = 19
		Me._DTFields_2.Visible = False
		Me._DTFields_2.Name = "_DTFields_2"
		Me._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_2.Text = "Only for Specific Time"
		Me._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_2.Size = New System.Drawing.Size(151, 17)
		Me._chkFields_2.Location = New System.Drawing.Point(270, 152)
		Me._chkFields_2.TabIndex = 16
		Me._chkFields_2.Visible = False
		Me._chkFields_2.CausesValidation = True
		Me._chkFields_2.Enabled = True
		Me._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_2.TabStop = True
		Me._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_2.Name = "_chkFields_2"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Delete"
		Me.cmdDelete.Size = New System.Drawing.Size(94, 25)
		Me.cmdDelete.Location = New System.Drawing.Point(352, 176)
		Me.cmdDelete.TabIndex = 14
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "&Add"
		Me.cmdAdd.Size = New System.Drawing.Size(94, 25)
		Me.cmdAdd.Location = New System.Drawing.Point(2, 176)
		Me.cmdAdd.TabIndex = 13
		Me.cmdAdd.TabStop = False
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.Name = "cmdAdd"
		Me.lvPromotion.Size = New System.Drawing.Size(445, 250)
		Me.lvPromotion.Location = New System.Drawing.Point(2, 206)
		Me.lvPromotion.TabIndex = 11
		Me.lvPromotion.View = System.Windows.Forms.View.Details
		Me.lvPromotion.LabelWrap = True
		Me.lvPromotion.HideSelection = False
		Me.lvPromotion.FullRowSelect = True
		Me.lvPromotion.GridLines = True
		Me.lvPromotion.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvPromotion.BackColor = System.Drawing.SystemColors.Window
		Me.lvPromotion.LabelEdit = True
		Me.lvPromotion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvPromotion.Name = "lvPromotion"
		Me._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_1.Text = "Disabled:"
		Me._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_1.Size = New System.Drawing.Size(64, 13)
		Me._chkFields_1.Location = New System.Drawing.Point(54, 138)
		Me._chkFields_1.TabIndex = 7
		Me._chkFields_1.CausesValidation = True
		Me._chkFields_1.Enabled = True
		Me._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_1.TabStop = True
		Me._chkFields_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_1.Visible = True
		Me._chkFields_1.Name = "_chkFields_1"
		Me._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me._chkFields_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._chkFields_0.Text = "Apply Only to POS Channel"
		Me._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._chkFields_0.Size = New System.Drawing.Size(151, 13)
		Me._chkFields_0.Location = New System.Drawing.Point(270, 138)
		Me._chkFields_0.TabIndex = 8
		Me._chkFields_0.Visible = False
		Me._chkFields_0.CausesValidation = True
		Me._chkFields_0.Enabled = True
		Me._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkFields_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkFields_0.TabStop = True
		Me._chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkFields_0.Name = "_chkFields_0"
        '_DTFields_0.OcxState = CType(resources.GetObject("_DTFields_0.OcxState"), System.Windows.Forms.AxHost.State)
		Me._DTFields_0.Size = New System.Drawing.Size(130, 22)
		Me._DTFields_0.Location = New System.Drawing.Point(105, 87)
		Me._DTFields_0.TabIndex = 4
		Me._DTFields_0.Name = "_DTFields_0"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Size = New System.Drawing.Size(315, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(105, 66)
		Me._txtFields_0.TabIndex = 2
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Maxlength = 0
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.Visible = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_0.Name = "_txtFields_0"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(455, 39)
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
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(192, 3)
		Me.cmdPrint.TabIndex = 15
		Me.cmdPrint.TabStop = False
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
		Me.cmdClose.Location = New System.Drawing.Point(369, 3)
		Me.cmdClose.TabIndex = 12
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
		Me.cmdCancel.TabIndex = 9
		Me.cmdCancel.TabStop = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Name = "cmdCancel"
        '_DTFields_1.OcxState = CType(resources.GetObject("_DTFields_1.OcxState"), System.Windows.Forms.AxHost.State)
		Me._DTFields_1.Size = New System.Drawing.Size(130, 22)
		Me._DTFields_1.Location = New System.Drawing.Point(291, 87)
		Me._DTFields_1.TabIndex = 6
		Me._DTFields_1.Name = "_DTFields_1"
		Me.Label2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.Label2.Text = "To Time:"
		Me.Label2.Size = New System.Drawing.Size(51, 15)
		Me.Label2.Location = New System.Drawing.Point(238, 116)
		Me.Label2.TabIndex = 18
		Me.Label2.Visible = False
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.Label1.Text = "From Time:"
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(48, 116)
		Me.Label1.TabIndex = 17
		Me.Label1.Visible = False
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_1.Text = "End Date:"
		Me._lblLabels_1.Size = New System.Drawing.Size(48, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(240, 90)
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
		Me._lblLabels_0.Text = "Start Date:"
		Me._lblLabels_0.Size = New System.Drawing.Size(51, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(52, 90)
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
		Me._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblLabels_38.Text = "Deal Name:"
		Me._lblLabels_38.Size = New System.Drawing.Size(56, 13)
		Me._lblLabels_38.Location = New System.Drawing.Point(44, 69)
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
		Me._Shape1_2.Size = New System.Drawing.Size(415, 112)
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
		Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
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
		Me.Controls.Add(_DTFields_3)
		Me.Controls.Add(_DTFields_2)
		Me.Controls.Add(_chkFields_2)
		Me.Controls.Add(cmdDelete)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(lvPromotion)
		Me.Controls.Add(_chkFields_1)
		Me.Controls.Add(_chkFields_0)
		Me.Controls.Add(_DTFields_0)
		Me.Controls.Add(_txtFields_0)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(_DTFields_1)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_1)
		Me.Controls.Add(_lblLabels_0)
		Me.Controls.Add(_lblLabels_38)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(_lbl_5)
		Me.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdCancel)
        'Me.DTFields.SetIndex(_DTFields_3, CType(3, Short))
        'Me.DTFields.SetIndex(_DTFields_2, CType(2, Short))
        'Me.DTFields.SetIndex(_DTFields_0, CType(0, Short))
        'Me.DTFields.SetIndex(_DTFields_1, CType(1, Short))
        'Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
        'Me.chkFields.SetIndex(_chkFields_1, CType(1, Short))
        'Me.chkFields.SetIndex(_chkFields_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
        'Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
        'Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
        'Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.DTFields, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._DTFields_1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._DTFields_0, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._DTFields_2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._DTFields_3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class