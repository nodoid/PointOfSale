<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOrderWizardFilter
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
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents chkDynamic As System.Windows.Forms.CheckBox
	Public WithEvents txtDays As System.Windows.Forms.TextBox
	Public WithEvents txtMinimum As System.Windows.Forms.TextBox
    Public WithEvents _MonthView1_1 As System.Windows.Forms.MonthCalendar
    Public WithEvents _MonthView1_0 As System.Windows.Forms.MonthCalendar
    Public WithEvents _lbl_6 As System.Windows.Forms.Label
    Public WithEvents lblFilter As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblDayEnd As System.Windows.Forms.Label
    Public WithEvents _lbl_5 As System.Windows.Forms.Label
    Public WithEvents _lbl_3 As System.Windows.Forms.Label
    Public WithEvents _lbl_1 As System.Windows.Forms.Label
    Public WithEvents _lbl_4 As System.Windows.Forms.Label
    Public WithEvents _lbl_2 As System.Windows.Forms.Label
    Public WithEvents _lbl_0 As System.Windows.Forms.Label
    Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents MonthView1 As AxMonthViewArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Shape1 As RectangleShapeArray
    Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderWizardFilter))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.chkDynamic = New System.Windows.Forms.CheckBox
        Me.txtDays = New System.Windows.Forms.TextBox
        Me.txtMinimum = New System.Windows.Forms.TextBox
        Me._MonthView1_1 = New System.Windows.Forms.MonthCalendar
        Me._MonthView1_0 = New System.Windows.Forms.MonthCalendar
        Me._lbl_6 = New System.Windows.Forms.Label
        Me.lblFilter = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDayEnd = New System.Windows.Forms.Label
        Me._lbl_5 = New System.Windows.Forms.Label
        Me._lbl_3 = New System.Windows.Forms.Label
        Me._lbl_1 = New System.Windows.Forms.Label
        Me._lbl_4 = New System.Windows.Forms.Label
        Me._lbl_2 = New System.Windows.Forms.Label
        Me._lbl_0 = New System.Windows.Forms.Label
        Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.MonthView1 = New AxMonthViewArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.Shape1 = New RectangleShapeArray(components)
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        CType(Me._MonthView1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MonthView1_0, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ClientSize = New System.Drawing.Size(436, 590)
        Me.Location = New System.Drawing.Point(3, 3)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmOrderWizardFilter"
        Me.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdFilter.Text = "&Filter ..."
        Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdFilter.Size = New System.Drawing.Size(79, 37)
        Me.cmdFilter.Location = New System.Drawing.Point(336, 528)
        Me.cmdFilter.TabIndex = 16
        Me.cmdFilter.TabStop = False
        Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFilter.CausesValidation = True
        Me.cmdFilter.Enabled = True
        Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter.Name = "cmdFilter"
        Me.chkDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDynamic.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
        Me.chkDynamic.Text = "Automatically re-calculate start and end dates based on current ""Day End"" date."
        Me.chkDynamic.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkDynamic.Size = New System.Drawing.Size(400, 13)
        Me.chkDynamic.Location = New System.Drawing.Point(21, 393)
        Me.chkDynamic.TabIndex = 13
        Me.chkDynamic.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkDynamic.CausesValidation = True
        Me.chkDynamic.Enabled = True
        Me.chkDynamic.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDynamic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDynamic.Appearance = System.Windows.Forms.Appearance.Normal
        Me.chkDynamic.TabStop = True
        Me.chkDynamic.CheckState = System.Windows.Forms.CheckState.Unchecked
        Me.chkDynamic.Visible = True
        Me.chkDynamic.Name = "chkDynamic"
        Me.txtDays.AutoSize = False
        Me.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDays.Size = New System.Drawing.Size(40, 19)
        Me.txtDays.Location = New System.Drawing.Point(156, 348)
        Me.txtDays.TabIndex = 8
        Me.txtDays.Text = "9"
        Me.txtDays.AcceptsReturn = True
        Me.txtDays.BackColor = System.Drawing.SystemColors.Window
        Me.txtDays.CausesValidation = True
        Me.txtDays.Enabled = True
        Me.txtDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDays.HideSelection = True
        Me.txtDays.ReadOnly = False
        Me.txtDays.Maxlength = 0
        Me.txtDays.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDays.MultiLine = False
        Me.txtDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDays.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDays.TabStop = True
        Me.txtDays.Visible = True
        Me.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDays.Name = "txtDays"
        Me.txtMinimum.AutoSize = False
        Me.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMinimum.Size = New System.Drawing.Size(40, 19)
        Me.txtMinimum.Location = New System.Drawing.Point(105, 366)
        Me.txtMinimum.TabIndex = 11
        Me.txtMinimum.Text = "2"
        Me.txtMinimum.AcceptsReturn = True
        Me.txtMinimum.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinimum.CausesValidation = True
        Me.txtMinimum.Enabled = True
        Me.txtMinimum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinimum.HideSelection = True
        Me.txtMinimum.ReadOnly = False
        Me.txtMinimum.Maxlength = 0
        Me.txtMinimum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinimum.MultiLine = False
        Me.txtMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinimum.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtMinimum.TabStop = True
        Me.txtMinimum.Visible = True
        Me.txtMinimum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinimum.Name = "txtMinimum"
        '_MonthView1_1.OcxState = CType(resources.GetObject("_MonthView1_1.OcxState"), System.Windows.Forms.AxHost.State)
        Me._MonthView1_1.Size = New System.Drawing.Size(180, 158)
        Me._MonthView1_1.Location = New System.Drawing.Point(237, 96)
        Me._MonthView1_1.TabIndex = 4
        Me._MonthView1_1.Name = "_MonthView1_1"
        '_MonthView1_0.OcxState = CType(resources.GetObject("_MonthView1_0.OcxState"), System.Windows.Forms.AxHost.State)
        Me._MonthView1_0.Size = New System.Drawing.Size(180, 158)
        Me._MonthView1_0.Location = New System.Drawing.Point(21, 96)
        Me._MonthView1_0.TabIndex = 2
        Me._MonthView1_0.Name = "_MonthView1_0"
        Me._lbl_6.Text = "units."
        Me._lbl_6.Size = New System.Drawing.Size(25, 13)
        Me._lbl_6.Location = New System.Drawing.Point(150, 369)
        Me._lbl_6.TabIndex = 12
        Me._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lbl_6.BackColor = System.Drawing.Color.Transparent
        Me._lbl_6.Enabled = True
        Me._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_6.UseMnemonic = True
        Me._lbl_6.Visible = True
        Me._lbl_6.AutoSize = True
        Me._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_6.Name = "_lbl_6"
        Me.lblFilter.Text = "Label1"
        Me.lblFilter.Size = New System.Drawing.Size(391, 76)
        Me.lblFilter.Location = New System.Drawing.Point(24, 447)
        Me.lblFilter.TabIndex = 15
        Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblFilter.BackColor = System.Drawing.SystemColors.Control
        Me.lblFilter.Enabled = True
        Me.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFilter.UseMnemonic = True
        Me.lblFilter.Visible = True
        Me.lblFilter.AutoSize = False
        Me.lblFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFilter.Name = "lblFilter"
        Me._Label1_2.Text = "&3. Filter"
        Me._Label1_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_2.Size = New System.Drawing.Size(44, 13)
        Me._Label1_2.Location = New System.Drawing.Point(15, 423)
        Me._Label1_2.TabIndex = 14
        Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_2.BackColor = System.Drawing.Color.Transparent
        Me._Label1_2.Enabled = True
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.UseMnemonic = True
        Me._Label1_2.Visible = True
        Me._Label1_2.AutoSize = True
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_2.Name = "_Label1_2"
        Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.Size = New System.Drawing.Size(415, 136)
        Me._Shape1_2.Location = New System.Drawing.Point(12, 438)
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me._Shape1_2.BorderWidth = 1
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
        Me._Shape1_2.Visible = True
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Label1_1.Text = "&2. Wizard Rules"
        Me._Label1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_1.Size = New System.Drawing.Size(91, 13)
        Me._Label1_1.Location = New System.Drawing.Point(15, 327)
        Me._Label1_1.TabIndex = 6
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_1.BackColor = System.Drawing.Color.Transparent
        Me._Label1_1.Enabled = True
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.UseMnemonic = True
        Me._Label1_1.Visible = True
        Me._Label1_1.AutoSize = True
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_0.Text = "&1. Day End Criteria"
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_0.Size = New System.Drawing.Size(108, 13)
        Me._Label1_0.Location = New System.Drawing.Point(15, 63)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.Enabled = True
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.UseMnemonic = True
        Me._Label1_0.Visible = True
        Me._Label1_0.AutoSize = True
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_0.Name = "_Label1_0"
        Me.Label2.Text = "When calculating your ordering levels, you must select the mean number of ""day Ends"" to cover to get an average number of units sold. This average is then projected for a set number of days to give you your expected sales. This expectation is then your minimum order level for the ""Stock Item""."
        Me.Label2.Size = New System.Drawing.Size(397, 55)
        Me.Label2.Location = New System.Drawing.Point(15, 3)
        Me.Label2.TabIndex = 17
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Enabled = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.UseMnemonic = True
        Me.Label2.Visible = True
        Me.Label2.AutoSize = False
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label2.Name = "Label2"
        Me.lblDayEnd.Text = "Label1"
        Me.lblDayEnd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDayEnd.Size = New System.Drawing.Size(397, 34)
        Me.lblDayEnd.Location = New System.Drawing.Point(21, 276)
        Me.lblDayEnd.TabIndex = 5
        Me.lblDayEnd.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblDayEnd.BackColor = System.Drawing.SystemColors.Control
        Me.lblDayEnd.Enabled = True
        Me.lblDayEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDayEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDayEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDayEnd.UseMnemonic = True
        Me.lblDayEnd.Visible = True
        Me.lblDayEnd.AutoSize = False
        Me.lblDayEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDayEnd.Name = "lblDayEnd"
        Me._lbl_5.Text = "From Date"
        Me._lbl_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_5.Size = New System.Drawing.Size(59, 13)
        Me._lbl_5.Location = New System.Drawing.Point(24, 81)
        Me._lbl_5.TabIndex = 1
        Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Enabled = True
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.UseMnemonic = True
        Me._lbl_5.Visible = True
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_3.Text = "To Date"
        Me._lbl_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_3.Size = New System.Drawing.Size(47, 13)
        Me._lbl_3.Location = New System.Drawing.Point(240, 81)
        Me._lbl_3.TabIndex = 3
        Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lbl_3.BackColor = System.Drawing.Color.Transparent
        Me._lbl_3.Enabled = True
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.UseMnemonic = True
        Me._lbl_3.Visible = True
        Me._lbl_3.AutoSize = True
        Me._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_1.Text = "Calculated Day End Criteria"
        Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_1.Size = New System.Drawing.Size(157, 13)
        Me._lbl_1.Location = New System.Drawing.Point(21, 261)
        Me._lbl_1.TabIndex = 18
        Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lbl_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_1.Enabled = True
        Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.UseMnemonic = True
        Me._lbl_1.Visible = True
        Me._lbl_1.AutoSize = True
        Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_4.Text = "level will be below"
        Me._lbl_4.Size = New System.Drawing.Size(85, 13)
        Me._lbl_4.Location = New System.Drawing.Point(15, 369)
        Me._lbl_4.TabIndex = 10
        Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lbl_4.BackColor = System.Drawing.Color.Transparent
        Me._lbl_4.Enabled = True
        Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_4.UseMnemonic = True
        Me._lbl_4.Visible = True
        Me._lbl_4.AutoSize = True
        Me._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_4.Name = "_lbl_4"
        Me._lbl_2.Text = """Day Ends"" and then guarantee no re-order"
        Me._lbl_2.Size = New System.Drawing.Size(206, 13)
        Me._lbl_2.Location = New System.Drawing.Point(201, 351)
        Me._lbl_2.TabIndex = 9
        Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
        Me._lbl_0.Text = "Forecast my stock holding for "
        Me._lbl_0.Size = New System.Drawing.Size(141, 13)
        Me._lbl_0.Location = New System.Drawing.Point(15, 351)
        Me._lbl_0.TabIndex = 7
        Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
        Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
        Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_0.Size = New System.Drawing.Size(415, 241)
        Me._Shape1_0.Location = New System.Drawing.Point(12, 78)
        Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me._Shape1_0.BorderWidth = 1
        Me._Shape1_0.FillColor = System.Drawing.Color.Black
        Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
        Me._Shape1_0.Visible = True
        Me._Shape1_0.Name = "_Shape1_0"
        Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
        Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_1.Size = New System.Drawing.Size(415, 73)
        Me._Shape1_1.Location = New System.Drawing.Point(12, 342)
        Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me._Shape1_1.BorderWidth = 1
        Me._Shape1_1.FillColor = System.Drawing.Color.Black
        Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
        Me._Shape1_1.Visible = True
        Me._Shape1_1.Name = "_Shape1_1"
        Me.Controls.Add(cmdFilter)
        Me.Controls.Add(chkDynamic)
        Me.Controls.Add(txtDays)
        Me.Controls.Add(txtMinimum)
        Me.Controls.Add(_MonthView1_1)
        Me.Controls.Add(_MonthView1_0)
        Me.Controls.Add(_lbl_6)
        Me.Controls.Add(lblFilter)
        Me.Controls.Add(_Label1_2)
        Me.ShapeContainer1.Shapes.Add(_Shape1_2)
        Me.Controls.Add(_Label1_1)
        Me.Controls.Add(_Label1_0)
        Me.Controls.Add(Label2)
        Me.Controls.Add(lblDayEnd)
        Me.Controls.Add(_lbl_5)
        Me.Controls.Add(_lbl_3)
        Me.Controls.Add(_lbl_1)
        Me.Controls.Add(_lbl_4)
        Me.Controls.Add(_lbl_2)
        Me.Controls.Add(_lbl_0)
        Me.ShapeContainer1.Shapes.Add(_Shape1_0)
        Me.ShapeContainer1.Shapes.Add(_Shape1_1)
        Me.Controls.Add(ShapeContainer1)
        'Me.Label1.SetIndex(_Label1_2, CType(2, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.MonthView1.SetIndex(_MonthView1_1, CType(1, Short))
        'Me.MonthView1.SetIndex(_MonthView1_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_6, CType(6, Short))
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_4, CType(4, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
        Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
        Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
        CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.MonthView1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MonthView1_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MonthView1_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region 
End Class