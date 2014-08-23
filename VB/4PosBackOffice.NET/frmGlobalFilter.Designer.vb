<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGlobalFilter
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
	Public WithEvents cmdUndo As System.Windows.Forms.Button
	Public WithEvents chkUndoPosOveride As System.Windows.Forms.CheckBox
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents chkDiscontinued As System.Windows.Forms.CheckBox
	Public WithEvents chkDisable As System.Windows.Forms.CheckBox
	Public WithEvents _OprBarcode_1 As System.Windows.Forms.RadioButton
	Public WithEvents _OprBarcode_0 As System.Windows.Forms.RadioButton
	Public WithEvents _OprBarcode_2 As System.Windows.Forms.RadioButton
	Public WithEvents chkSerialTracking As System.Windows.Forms.CheckBox
	Public WithEvents chkPosOveride As System.Windows.Forms.CheckBox
	Public WithEvents chkAllowFractions As System.Windows.Forms.CheckBox
	Public WithEvents chkNonWeigted As System.Windows.Forms.CheckBox
	Public WithEvents chkScale As System.Windows.Forms.CheckBox
    Public WithEvents cmbUpPrinting As myDataGridView
    Public WithEvents cmpUpSupplier As myDataGridView
    Public WithEvents cmbUpPricing As myDataGridView
    Public WithEvents cmbReportGroups As myDataGridView
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents lblChanges As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'Public WithEvents OprBarcode As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.cmdUndo = New System.Windows.Forms.Button()
        Me.chkUndoPosOveride = New System.Windows.Forms.CheckBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.chkDisable = New System.Windows.Forms.CheckBox()
        Me._OprBarcode_1 = New System.Windows.Forms.RadioButton()
        Me._OprBarcode_0 = New System.Windows.Forms.RadioButton()
        Me._OprBarcode_2 = New System.Windows.Forms.RadioButton()
        Me.chkSerialTracking = New System.Windows.Forms.CheckBox()
        Me.chkPosOveride = New System.Windows.Forms.CheckBox()
        Me.chkAllowFractions = New System.Windows.Forms.CheckBox()
        Me.chkNonWeigted = New System.Windows.Forms.CheckBox()
        Me.chkScale = New System.Windows.Forms.CheckBox()
        Me.cmbUpPrinting = New _4PosBackOffice.NET.myDataGridView()
        Me.cmpUpSupplier = New _4PosBackOffice.NET.myDataGridView()
        Me.cmbUpPricing = New _4PosBackOffice.NET.myDataGridView()
        Me.cmbReportGroups = New _4PosBackOffice.NET.myDataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.lblChanges = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.Frame3.SuspendLayout()
        Me.picButtons.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.cmbUpPrinting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmpUpSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUpPricing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbReportGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 13)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line3, Me.Line2, Me.Line1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(441, 312)
        Me.ShapeContainer1.TabIndex = 28
        Me.ShapeContainer1.TabStop = False
        '
        'Line3
        '
        Me.Line3.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line3.BorderWidth = 2
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 6
        Me.Line3.X2 = 432
        Me.Line3.Y1 = 251
        Me.Line3.Y2 = 251
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line2.BorderWidth = 2
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 8
        Me.Line2.X2 = 434
        Me.Line2.Y1 = 96
        Me.Line2.Y2 = 96
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line1.BorderWidth = 2
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 6
        Me.Line1.X2 = 434
        Me.Line1.Y1 = 139
        Me.Line1.Y2 = 139
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.cmdUndo)
        Me.Frame3.Controls.Add(Me.chkUndoPosOveride)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(6, 496)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(441, 49)
        Me.Frame3.TabIndex = 28
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Undo Changes"
        '
        'cmdUndo
        '
        Me.cmdUndo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUndo.Location = New System.Drawing.Point(184, 16)
        Me.cmdUndo.Name = "cmdUndo"
        Me.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUndo.Size = New System.Drawing.Size(95, 27)
        Me.cmdUndo.TabIndex = 30
        Me.cmdUndo.Text = "Undo Update"
        Me.cmdUndo.UseVisualStyleBackColor = False
        '
        'chkUndoPosOveride
        '
        Me.chkUndoPosOveride.BackColor = System.Drawing.SystemColors.Control
        Me.chkUndoPosOveride.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUndoPosOveride.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUndoPosOveride.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkUndoPosOveride.Location = New System.Drawing.Point(8, 21)
        Me.chkUndoPosOveride.Name = "chkUndoPosOveride"
        Me.chkUndoPosOveride.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUndoPosOveride.Size = New System.Drawing.Size(171, 16)
        Me.chkUndoPosOveride.TabIndex = 29
        Me.chkUndoPosOveride.Text = "Undo POS Price Overide (SQ)"
        Me.chkUndoPosOveride.UseVisualStyleBackColor = False
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.Command2)
        Me.picButtons.Controls.Add(Me.Command1)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(452, 38)
        Me.picButtons.TabIndex = 20
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(360, 4)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(83, 27)
        Me.Command2.TabIndex = 22
        Me.Command2.Text = "&Exit"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(4, 4)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(83, 27)
        Me.Command1.TabIndex = 21
        Me.Command1.Text = "Global Cost"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmdUpdate)
        Me.Frame2.Controls.Add(Me.chkDiscontinued)
        Me.Frame2.Controls.Add(Me.chkDisable)
        Me.Frame2.Controls.Add(Me._OprBarcode_1)
        Me.Frame2.Controls.Add(Me._OprBarcode_0)
        Me.Frame2.Controls.Add(Me._OprBarcode_2)
        Me.Frame2.Controls.Add(Me.chkSerialTracking)
        Me.Frame2.Controls.Add(Me.chkPosOveride)
        Me.Frame2.Controls.Add(Me.chkAllowFractions)
        Me.Frame2.Controls.Add(Me.chkNonWeigted)
        Me.Frame2.Controls.Add(Me.chkScale)
        Me.Frame2.Controls.Add(Me.cmbUpPrinting)
        Me.Frame2.Controls.Add(Me.cmpUpSupplier)
        Me.Frame2.Controls.Add(Me.cmbUpPricing)
        Me.Frame2.Controls.Add(Me.cmbReportGroups)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.ShapeContainer1)
        Me.Frame2.Enabled = False
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(6, 166)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(441, 325)
        Me.Frame2.TabIndex = 12
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Field(s) To Update"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(184, 280)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(95, 27)
        Me.cmdUpdate.TabIndex = 19
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.BackColor = System.Drawing.SystemColors.Control
        Me.chkDiscontinued.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDiscontinued.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDiscontinued.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkDiscontinued.Location = New System.Drawing.Point(348, 272)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDiscontinued.Size = New System.Drawing.Size(83, 17)
        Me.chkDiscontinued.TabIndex = 11
        Me.chkDiscontinued.Text = "Discontinued"
        Me.chkDiscontinued.UseVisualStyleBackColor = False
        '
        'chkDisable
        '
        Me.chkDisable.BackColor = System.Drawing.SystemColors.Control
        Me.chkDisable.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDisable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkDisable.Location = New System.Drawing.Point(6, 272)
        Me.chkDisable.Name = "chkDisable"
        Me.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDisable.Size = New System.Drawing.Size(71, 17)
        Me.chkDisable.TabIndex = 10
        Me.chkDisable.Text = "Disabled"
        Me.chkDisable.UseVisualStyleBackColor = False
        '
        '_OprBarcode_1
        '
        Me._OprBarcode_1.BackColor = System.Drawing.SystemColors.Control
        Me._OprBarcode_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._OprBarcode_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._OprBarcode_1.Location = New System.Drawing.Point(128, 130)
        Me._OprBarcode_1.Name = "_OprBarcode_1"
        Me._OprBarcode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._OprBarcode_1.Size = New System.Drawing.Size(71, 19)
        Me._OprBarcode_1.TabIndex = 7
        Me._OprBarcode_1.TabStop = True
        Me._OprBarcode_1.Text = "Barcode"
        Me._OprBarcode_1.UseVisualStyleBackColor = False
        '
        '_OprBarcode_0
        '
        Me._OprBarcode_0.BackColor = System.Drawing.SystemColors.Control
        Me._OprBarcode_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._OprBarcode_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._OprBarcode_0.Location = New System.Drawing.Point(6, 130)
        Me._OprBarcode_0.Name = "_OprBarcode_0"
        Me._OprBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._OprBarcode_0.Size = New System.Drawing.Size(69, 19)
        Me._OprBarcode_0.TabIndex = 6
        Me._OprBarcode_0.TabStop = True
        Me._OprBarcode_0.Text = "Shelf"
        Me._OprBarcode_0.UseVisualStyleBackColor = False
        '
        '_OprBarcode_2
        '
        Me._OprBarcode_2.BackColor = System.Drawing.SystemColors.Control
        Me._OprBarcode_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._OprBarcode_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._OprBarcode_2.Location = New System.Drawing.Point(252, 130)
        Me._OprBarcode_2.Name = "_OprBarcode_2"
        Me._OprBarcode_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._OprBarcode_2.Size = New System.Drawing.Size(47, 19)
        Me._OprBarcode_2.TabIndex = 5
        Me._OprBarcode_2.TabStop = True
        Me._OprBarcode_2.Text = "None"
        Me._OprBarcode_2.UseVisualStyleBackColor = False
        '
        'chkSerialTracking
        '
        Me.chkSerialTracking.BackColor = System.Drawing.SystemColors.Control
        Me.chkSerialTracking.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSerialTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSerialTracking.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkSerialTracking.Location = New System.Drawing.Point(8, 86)
        Me.chkSerialTracking.Name = "chkSerialTracking"
        Me.chkSerialTracking.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSerialTracking.Size = New System.Drawing.Size(211, 21)
        Me.chkSerialTracking.TabIndex = 4
        Me.chkSerialTracking.Text = "Serial Tracking "
        Me.chkSerialTracking.UseVisualStyleBackColor = False
        '
        'chkPosOveride
        '
        Me.chkPosOveride.BackColor = System.Drawing.SystemColors.Control
        Me.chkPosOveride.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPosOveride.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPosOveride.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkPosOveride.Location = New System.Drawing.Point(8, 68)
        Me.chkPosOveride.Name = "chkPosOveride"
        Me.chkPosOveride.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPosOveride.Size = New System.Drawing.Size(211, 21)
        Me.chkPosOveride.TabIndex = 3
        Me.chkPosOveride.Text = "POS Price Overide (SQ)"
        Me.chkPosOveride.UseVisualStyleBackColor = False
        '
        'chkAllowFractions
        '
        Me.chkAllowFractions.BackColor = System.Drawing.SystemColors.Control
        Me.chkAllowFractions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAllowFractions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAllowFractions.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkAllowFractions.Location = New System.Drawing.Point(8, 52)
        Me.chkAllowFractions.Name = "chkAllowFractions"
        Me.chkAllowFractions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAllowFractions.Size = New System.Drawing.Size(211, 20)
        Me.chkAllowFractions.TabIndex = 2
        Me.chkAllowFractions.Text = "Allow Fractions"
        Me.chkAllowFractions.UseVisualStyleBackColor = False
        '
        'chkNonWeigted
        '
        Me.chkNonWeigted.BackColor = System.Drawing.SystemColors.Control
        Me.chkNonWeigted.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNonWeigted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNonWeigted.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkNonWeigted.Location = New System.Drawing.Point(8, 34)
        Me.chkNonWeigted.Name = "chkNonWeigted"
        Me.chkNonWeigted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNonWeigted.Size = New System.Drawing.Size(211, 17)
        Me.chkNonWeigted.TabIndex = 1
        Me.chkNonWeigted.Text = "This is a scale item Non-Weigted"
        Me.chkNonWeigted.UseVisualStyleBackColor = False
        '
        'chkScale
        '
        Me.chkScale.BackColor = System.Drawing.SystemColors.Control
        Me.chkScale.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkScale.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkScale.Location = New System.Drawing.Point(8, 16)
        Me.chkScale.Name = "chkScale"
        Me.chkScale.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkScale.Size = New System.Drawing.Size(211, 18)
        Me.chkScale.TabIndex = 0
        Me.chkScale.Text = "This Is a Scale Product "
        Me.chkScale.UseVisualStyleBackColor = False
        '
        'cmbUpPrinting
        '
        Me.cmbUpPrinting.AllowAddNew = True
        Me.cmbUpPrinting.BoundText = ""
        Me.cmbUpPrinting.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbUpPrinting.Col = 0
        Me.cmbUpPrinting.CtlText = ""
        Me.cmbUpPrinting.DataField = Nothing
        Me.cmbUpPrinting.Location = New System.Drawing.Point(156, 210)
        Me.cmbUpPrinting.Name = "cmbUpPrinting"
        Me.cmbUpPrinting.row = 0
        Me.cmbUpPrinting.Size = New System.Drawing.Size(275, 21)
        Me.cmbUpPrinting.TabIndex = 8
        Me.cmbUpPrinting.TopRow = 0
        '
        'cmpUpSupplier
        '
        Me.cmpUpSupplier.AllowAddNew = True
        Me.cmpUpSupplier.BoundText = ""
        Me.cmpUpSupplier.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmpUpSupplier.Col = 0
        Me.cmpUpSupplier.CtlText = ""
        Me.cmpUpSupplier.DataField = Nothing
        Me.cmpUpSupplier.Location = New System.Drawing.Point(156, 162)
        Me.cmpUpSupplier.Name = "cmpUpSupplier"
        Me.cmpUpSupplier.row = 0
        Me.cmpUpSupplier.Size = New System.Drawing.Size(275, 21)
        Me.cmpUpSupplier.TabIndex = 15
        Me.cmpUpSupplier.TopRow = 0
        '
        'cmbUpPricing
        '
        Me.cmbUpPricing.AllowAddNew = True
        Me.cmbUpPricing.BoundText = ""
        Me.cmbUpPricing.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbUpPricing.Col = 0
        Me.cmbUpPricing.CtlText = ""
        Me.cmbUpPricing.DataField = Nothing
        Me.cmbUpPricing.Location = New System.Drawing.Point(156, 186)
        Me.cmbUpPricing.Name = "cmbUpPricing"
        Me.cmbUpPricing.row = 0
        Me.cmbUpPricing.Size = New System.Drawing.Size(275, 21)
        Me.cmbUpPricing.TabIndex = 17
        Me.cmbUpPricing.TopRow = 0
        '
        'cmbReportGroups
        '
        Me.cmbReportGroups.AllowAddNew = True
        Me.cmbReportGroups.BoundText = ""
        Me.cmbReportGroups.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbReportGroups.Col = 0
        Me.cmbReportGroups.CtlText = ""
        Me.cmbReportGroups.DataField = Nothing
        Me.cmbReportGroups.Location = New System.Drawing.Point(156, 234)
        Me.cmbReportGroups.Name = "cmbReportGroups"
        Me.cmbReportGroups.row = 0
        Me.cmbReportGroups.Size = New System.Drawing.Size(275, 21)
        Me.cmbReportGroups.TabIndex = 26
        Me.cmbReportGroups.TopRow = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(38, 238)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Report Groups:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(38, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "New Supplier :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(38, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(113, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "New Pricing Group :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(147, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Shelf && Barcode Printing"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(38, 214)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "New Printing Location :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Command3)
        Me.Frame1.Controls.Add(Me.lblChanges)
        Me.Frame1.Controls.Add(Me.lblHeading)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(6, 44)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(441, 119)
        Me.Frame1.TabIndex = 9
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "1. Filter"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(356, 16)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(79, 37)
        Me.Command3.TabIndex = 23
        Me.Command3.Text = "Filter"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'lblChanges
        '
        Me.lblChanges.BackColor = System.Drawing.SystemColors.Window
        Me.lblChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChanges.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblChanges.ForeColor = System.Drawing.Color.Red
        Me.lblChanges.Location = New System.Drawing.Point(12, 94)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblChanges.Size = New System.Drawing.Size(339, 19)
        Me.lblChanges.TabIndex = 25
        Me.lblChanges.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
        Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeading.Location = New System.Drawing.Point(12, 16)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeading.Size = New System.Drawing.Size(339, 76)
        Me.lblHeading.TabIndex = 24
        Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
        '
        'frmGlobalFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(452, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmGlobalFilter"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Global Update"
        Me.Frame3.ResumeLayout(False)
        Me.picButtons.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        CType(Me.cmbUpPrinting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmpUpSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUpPricing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbReportGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class