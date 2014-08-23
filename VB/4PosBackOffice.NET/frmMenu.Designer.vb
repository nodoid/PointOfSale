<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMenu
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
	Public WithEvents mnuWelcome As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDashboard As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuReports As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents chkDash As System.Windows.Forms.CheckBox
	Public WithEvents cmdToday As System.Windows.Forms.Button
	Public WithEvents cmdYesterday As System.Windows.Forms.Button
	Public WithEvents cmdLoad As System.Windows.Forms.Button
    Public WithEvents tmrReports As System.Windows.Forms.Timer
	Public WithEvents tmrReportCancel As System.Windows.Forms.Timer
	Public WithEvents tmrForm As System.Windows.Forms.Timer
	Public WithEvents Text1 As System.Windows.Forms.TextBox
    'Public WithEvents CRViewer1 As CrystalDecisions.Web.CrystalReportViewer
    Public WithEvents picReport As System.Windows.Forms.Panel
    Public WithEvents tmrMenuShow As System.Windows.Forms.Timer
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblPath As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblDayEndCurrent As System.Windows.Forms.Label
    Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
    Public WithEvents lblCompany As System.Windows.Forms.Label
	Public WithEvents _imgArrow_0 As System.Windows.Forms.PictureBox
    Public WithEvents lblUser As System.Windows.Forms.Label
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Image2 As System.Windows.Forms.PictureBox
    'Public WithEvents DTPicker1 As AxDTPickerArray
    'Public WithEvents imgArrow As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents imgMenu As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblColor As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    ''Public WithEvents lblMenu As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblMenuMain As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents picMenuList As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWelcome = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDashboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkDash = New System.Windows.Forms.CheckBox()
        Me.cmdToday = New System.Windows.Forms.Button()
        Me.cmdYesterday = New System.Windows.Forms.Button()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.tmrReports = New System.Windows.Forms.Timer(Me.components)
        Me.tmrReportCancel = New System.Windows.Forms.Timer(Me.components)
        Me.tmrForm = New System.Windows.Forms.Timer(Me.components)
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.picReport = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tmrMenuShow = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDayEndCurrent = New System.Windows.Forms.Label()
        Me._lbl_0 = New System.Windows.Forms.Label()
        Me._lbl_1 = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me._imgArrow_0 = New System.Windows.Forms.PictureBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me._DTPicker1_0 = New System.Windows.Forms.DateTimePicker()
        Me._DTPicker1_1 = New System.Windows.Forms.DateTimePicker()
        Me.lblDayEnd = New System.Windows.Forms.Label()
        Me.MainMenu1.SuspendLayout()
        Me.picReport.SuspendLayout()
        CType(Me._imgArrow_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReports})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1013, 24)
        Me.MainMenu1.TabIndex = 31
        '
        'mnuReports
        '
        Me.mnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWelcome, Me.mnuDashboard})
        Me.mnuReports.Name = "mnuReports"
        Me.mnuReports.Size = New System.Drawing.Size(84, 20)
        Me.mnuReports.Text = "mnuReports"
        Me.mnuReports.Visible = False
        '
        'mnuWelcome
        '
        Me.mnuWelcome.Name = "mnuWelcome"
        Me.mnuWelcome.Size = New System.Drawing.Size(160, 22)
        Me.mnuWelcome.Text = "Welcome Note"
        '
        'mnuDashboard
        '
        Me.mnuDashboard.Name = "mnuDashboard"
        Me.mnuDashboard.Size = New System.Drawing.Size(160, 22)
        Me.mnuDashboard.Text = "Sales &Dashboard"
        '
        'chkDash
        '
        Me.chkDash.BackColor = System.Drawing.SystemColors.Control
        Me.chkDash.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDash.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDash.Location = New System.Drawing.Point(320, 672)
        Me.chkDash.Name = "chkDash"
        Me.chkDash.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDash.Size = New System.Drawing.Size(14, 14)
        Me.chkDash.TabIndex = 22
        Me.chkDash.Text = " Show  Sales  Dashboard"
        Me.chkDash.UseVisualStyleBackColor = False
        '
        'cmdToday
        '
        Me.cmdToday.BackColor = System.Drawing.SystemColors.Control
        Me.cmdToday.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdToday.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdToday.Location = New System.Drawing.Point(761, 128)
        Me.cmdToday.Name = "cmdToday"
        Me.cmdToday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdToday.Size = New System.Drawing.Size(126, 19)
        Me.cmdToday.TabIndex = 17
        Me.cmdToday.TabStop = False
        Me.cmdToday.Text = "&1. Goto Today"
        Me.cmdToday.UseVisualStyleBackColor = False
        '
        'cmdYesterday
        '
        Me.cmdYesterday.BackColor = System.Drawing.SystemColors.Control
        Me.cmdYesterday.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdYesterday.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdYesterday.Location = New System.Drawing.Point(761, 148)
        Me.cmdYesterday.Name = "cmdYesterday"
        Me.cmdYesterday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdYesterday.Size = New System.Drawing.Size(126, 19)
        Me.cmdYesterday.TabIndex = 16
        Me.cmdYesterday.TabStop = False
        Me.cmdYesterday.Text = "&2. Goto Yesterday"
        Me.cmdYesterday.UseVisualStyleBackColor = False
        '
        'cmdLoad
        '
        Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.Location = New System.Drawing.Point(892, 126)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoad.Size = New System.Drawing.Size(100, 39)
        Me.cmdLoad.TabIndex = 15
        Me.cmdLoad.TabStop = False
        Me.cmdLoad.Text = "&Load Reports"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'tmrReports
        '
        Me.tmrReports.Interval = 1
        '
        'tmrReportCancel
        '
        Me.tmrReportCancel.Interval = 30000
        '
        'tmrForm
        '
        Me.tmrForm.Interval = 10
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(-66, 75)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(55, 20)
        Me.Text1.TabIndex = 9
        Me.Text1.TabStop = False
        Me.Text1.Text = "Text1"
        '
        'picReport
        '
        Me.picReport.BackColor = System.Drawing.SystemColors.Window
        Me.picReport.Controls.Add(Me.CrystalReportViewer1)
        Me.picReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.picReport.Enabled = False
        Me.picReport.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picReport.Location = New System.Drawing.Point(312, 216)
        Me.picReport.Name = "picReport"
        Me.picReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picReport.Size = New System.Drawing.Size(683, 449)
        Me.picReport.TabIndex = 6
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(683, 449)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'tmrMenuShow
        '
        Me.tmrMenuShow.Interval = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(336, 672)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(137, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Show Sales Dashboard"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.BackColor = System.Drawing.Color.Transparent
        Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPath.ForeColor = System.Drawing.Color.White
        Me.lblPath.Location = New System.Drawing.Point(525, 99)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPath.Size = New System.Drawing.Size(0, 13)
        Me.lblPath.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(312, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(270, 61)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Before viewing any reports, the date range needs to be selected. Your ""Day End"" r" & _
    "uns determine the date range and the details of your selection is given in the """ & _
    "Calculated Criteria"" box."
        '
        'lblDayEndCurrent
        '
        Me.lblDayEndCurrent.BackColor = System.Drawing.SystemColors.Window
        Me.lblDayEndCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDayEndCurrent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDayEndCurrent.Location = New System.Drawing.Point(596, 674)
        Me.lblDayEndCurrent.Name = "lblDayEndCurrent"
        Me.lblDayEndCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDayEndCurrent.Size = New System.Drawing.Size(400, 16)
        Me.lblDayEndCurrent.TabIndex = 19
        Me.lblDayEndCurrent.Text = "Label1"
        '
        '_lbl_0
        '
        Me._lbl_0.AutoSize = True
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_0.ForeColor = System.Drawing.Color.White
        Me._lbl_0.Location = New System.Drawing.Point(582, 133)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(63, 14)
        Me._lbl_0.TabIndex = 14
        Me._lbl_0.Text = "&From Date"
        '
        '_lbl_1
        '
        Me._lbl_1.AutoSize = True
        Me._lbl_1.BackColor = System.Drawing.Color.Transparent
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._lbl_1.ForeColor = System.Drawing.Color.White
        Me._lbl_1.Location = New System.Drawing.Point(582, 152)
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.Size = New System.Drawing.Size(47, 14)
        Me._lbl_1.TabIndex = 13
        Me._lbl_1.Text = "&To Date"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCompany.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCompany.ForeColor = System.Drawing.Color.White
        Me.lblCompany.Location = New System.Drawing.Point(524, 37)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCompany.Size = New System.Drawing.Size(255, 37)
        Me.lblCompany.TabIndex = 8
        Me.lblCompany.Text = "Company Name"
        '
        '_imgArrow_0
        '
        Me._imgArrow_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._imgArrow_0.Image = CType(resources.GetObject("_imgArrow_0.Image"), System.Drawing.Image)
        Me._imgArrow_0.Location = New System.Drawing.Point(392, 280)
        Me._imgArrow_0.Name = "_imgArrow_0"
        Me._imgArrow_0.Size = New System.Drawing.Size(11, 9)
        Me._imgArrow_0.TabIndex = 24
        Me._imgArrow_0.TabStop = False
        Me._imgArrow_0.Visible = False
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(14, 156)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser.Size = New System.Drawing.Size(267, 43)
        Me.lblUser.TabIndex = 3
        Me.lblUser.Text = "lblUserName"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(18, 674)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(1240, 24)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(1025, 720)
        Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image1.TabIndex = 29
        Me.Image1.TabStop = False
        '
        'Image2
        '
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(1056, 168)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(17, 714)
        Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image2.TabIndex = 30
        Me.Image2.TabStop = False
        '
        '_DTPicker1_0
        '
        Me._DTPicker1_0.Location = New System.Drawing.Point(652, 130)
        Me._DTPicker1_0.Name = "_DTPicker1_0"
        Me._DTPicker1_0.Size = New System.Drawing.Size(103, 20)
        Me._DTPicker1_0.TabIndex = 32
        '
        '_DTPicker1_1
        '
        Me._DTPicker1_1.Location = New System.Drawing.Point(652, 152)
        Me._DTPicker1_1.Name = "_DTPicker1_1"
        Me._DTPicker1_1.Size = New System.Drawing.Size(103, 20)
        Me._DTPicker1_1.TabIndex = 33
        '
        'lblDayEnd
        '
        Me.lblDayEnd.AutoSize = True
        Me.lblDayEnd.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDayEnd.Location = New System.Drawing.Point(762, 170)
        Me.lblDayEnd.Name = "lblDayEnd"
        Me.lblDayEnd.Size = New System.Drawing.Size(39, 13)
        Me.lblDayEnd.TabIndex = 34
        Me.lblDayEnd.Text = "Label3"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1013, 710)
        Me.Controls.Add(Me.lblDayEnd)
        Me.Controls.Add(Me._DTPicker1_1)
        Me.Controls.Add(Me._DTPicker1_0)
        Me.Controls.Add(Me.chkDash)
        Me.Controls.Add(Me.cmdToday)
        Me.Controls.Add(Me.cmdYesterday)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.picReport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDayEndCurrent)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me._lbl_1)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me._imgArrow_0)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.Image2)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 37)
        Me.Name = "frmMenu"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "4POS Back Office"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.picReport.ResumeLayout(False)
        CType(Me._imgArrow_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents _DTPicker1_0 As System.Windows.Forms.DateTimePicker
    Friend WithEvents _DTPicker1_1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDayEnd As System.Windows.Forms.Label
#End Region
End Class