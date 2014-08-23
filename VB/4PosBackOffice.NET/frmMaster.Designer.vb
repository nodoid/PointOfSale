<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMaster
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
	Public WithEvents cmdDatabase As System.Windows.Forms.Button
	Public WithEvents cmdCompany As System.Windows.Forms.Button
	Public WithEvents txtKey As System.Windows.Forms.TextBox
	Public WithEvents cmdRegistration As System.Windows.Forms.Button
	Public WithEvents txtCompany As System.Windows.Forms.TextBox
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents lblCode As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents frmRegister As System.Windows.Forms.GroupBox
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents txtUserName As System.Windows.Forms.TextBox
    'Public WithEvents MAPISession1 As MSMAPI.MAPISession
    'Public WithEvents MAPIMessages1 As MSMAPI.MAPIMessages
    Public WithEvents tmrStart As System.Windows.Forms.Timer
    Public CDmasterOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents cmdBuild As System.Windows.Forms.Button
    Public WithEvents _lvLocation_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
    Public WithEvents _lvLocation_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
    Public WithEvents _lvLocation_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
    Public WithEvents lvLocation As System.Windows.Forms.ListView
    Public WithEvents ILtree As System.Windows.Forms.ImageList
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents lblDir As System.Windows.Forms.Label
    Public WithEvents lblPath As System.Windows.Forms.Label
    Public WithEvents lblCompany As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMaster))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.cmdDatabase = New System.Windows.Forms.Button
        Me.cmdCompany = New System.Windows.Forms.Button
        Me.frmRegister = New System.Windows.Forms.GroupBox
        Me.txtKey = New System.Windows.Forms.TextBox
        Me.cmdRegistration = New System.Windows.Forms.Button
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me._lbl_0 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtUserName = New System.Windows.Forms.TextBox
        'Me.MAPISession1 = New MSMAPI.MAPISession
        'Me.MAPIMessages1 = New MSMAPI.MAPIMessages
        Me.tmrStart = New System.Windows.Forms.Timer(components)
        Me.CDmasterOpen = New System.Windows.Forms.OpenFileDialog
        Me.cmdBuild = New System.Windows.Forms.Button
        Me.lvLocation = New System.Windows.Forms.ListView
        Me._lvLocation_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
        Me._lvLocation_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
        Me._lvLocation_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
        Me.ILtree = New System.Windows.Forms.ImageList
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me.lblDir = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblCompany = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.frmRegister.SuspendLayout()
        Me.lvLocation.SuspendLayout()
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        'CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.MAPIMessages1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Text = "4POS Company Loader ..."
        Me.ClientSize = New System.Drawing.Size(640, 576)
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Icon = CType(resources.GetObject("frmMaster.Icon"), System.Drawing.Icon)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmMaster"
        Me.cmdDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CancelButton = Me.cmdDatabase
        Me.cmdDatabase.Text = "..."
        Me.cmdDatabase.Enabled = False
        Me.cmdDatabase.Size = New System.Drawing.Size(25, 16)
        Me.cmdDatabase.Location = New System.Drawing.Point(15, 309)
        Me.cmdDatabase.TabIndex = 23
        Me.cmdDatabase.TabStop = False
        Me.cmdDatabase.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDatabase.CausesValidation = True
        Me.cmdDatabase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDatabase.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDatabase.Name = "cmdDatabase"
        Me.cmdCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdCompany.Text = "..."
        Me.cmdCompany.Enabled = False
        Me.cmdCompany.Size = New System.Drawing.Size(25, 16)
        Me.cmdCompany.Location = New System.Drawing.Point(15, 288)
        Me.cmdCompany.TabIndex = 22
        Me.cmdCompany.TabStop = False
        Me.cmdCompany.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCompany.CausesValidation = True
        Me.cmdCompany.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCompany.Name = "cmdCompany"
        Me.frmRegister.Text = "Unregisted Version"
        Me.frmRegister.Size = New System.Drawing.Size(292, 98)
        Me.frmRegister.Location = New System.Drawing.Point(288, 351)
        Me.frmRegister.TabIndex = 14
        Me.frmRegister.Visible = False
        Me.frmRegister.BackColor = System.Drawing.SystemColors.Control
        Me.frmRegister.Enabled = True
        Me.frmRegister.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmRegister.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmRegister.Padding = New System.Windows.Forms.Padding(0)
        Me.frmRegister.Name = "frmRegister"
        Me.txtKey.AutoSize = False
        Me.txtKey.Size = New System.Drawing.Size(157, 19)
        Me.txtKey.Location = New System.Drawing.Point(117, 198)
        Me.txtKey.TabIndex = 19
        Me.txtKey.TabStop = False
        Me.txtKey.AcceptsReturn = True
        Me.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKey.BackColor = System.Drawing.SystemColors.Window
        Me.txtKey.CausesValidation = True
        Me.txtKey.Enabled = True
        Me.txtKey.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKey.HideSelection = True
        Me.txtKey.ReadOnly = False
        Me.txtKey.Maxlength = 0
        Me.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKey.MultiLine = False
        Me.txtKey.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtKey.Visible = True
        Me.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtKey.Name = "txtKey"
        Me.cmdRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdRegistration.Text = "Register"
        Me.cmdRegistration.Size = New System.Drawing.Size(100, 30)
        Me.cmdRegistration.Location = New System.Drawing.Point(176, 48)
        Me.cmdRegistration.TabIndex = 17
        Me.cmdRegistration.TabStop = False
        Me.cmdRegistration.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRegistration.CausesValidation = True
        Me.cmdRegistration.Enabled = True
        Me.cmdRegistration.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRegistration.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRegistration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRegistration.Name = "cmdRegistration"
        Me.txtCompany.AutoSize = False
        Me.txtCompany.Size = New System.Drawing.Size(154, 19)
        Me.txtCompany.Location = New System.Drawing.Point(117, 21)
        Me.txtCompany.Maxlength = 50
        Me.txtCompany.TabIndex = 15
        Me.txtCompany.TabStop = False
        Me.txtCompany.AcceptsReturn = True
        Me.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCompany.BackColor = System.Drawing.SystemColors.Window
        Me.txtCompany.CausesValidation = True
        Me.txtCompany.Enabled = True
        Me.txtCompany.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCompany.HideSelection = True
        Me.txtCompany.ReadOnly = False
        Me.txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompany.MultiLine = False
        Me.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCompany.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCompany.Visible = True
        Me.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtCompany.Name = "txtCompany"
        Me._Label2_1.Text = "Activation key:"
        Me._Label2_1.Size = New System.Drawing.Size(70, 13)
        Me._Label2_1.Location = New System.Drawing.Point(39, 201)
        Me._Label2_1.TabIndex = 21
        Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label2_1.BackColor = System.Drawing.Color.Transparent
        Me._Label2_1.Enabled = True
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.UseMnemonic = True
        Me._Label2_1.Visible = True
        Me._Label2_1.AutoSize = True
        Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label2_0.Text = "Registration code:"
        Me._Label2_0.Size = New System.Drawing.Size(93, 13)
        Me._Label2_0.Location = New System.Drawing.Point(15, 171)
        Me._Label2_0.TabIndex = 20
        Me._Label2_0.BackColor = System.Drawing.Color.Transparent
        Me._Label2_0.Enabled = True
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.UseMnemonic = True
        Me._Label2_0.Visible = True
        Me._Label2_0.AutoSize = False
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label2_0.Name = "_Label2_0"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblCode.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
        Me.lblCode.Text = "Label2"
        Me.lblCode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCode.Size = New System.Drawing.Size(156, 22)
        Me.lblCode.Location = New System.Drawing.Point(117, 168)
        Me.lblCode.TabIndex = 18
        Me.lblCode.Enabled = True
        Me.lblCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCode.UseMnemonic = True
        Me.lblCode.Visible = True
        Me.lblCode.AutoSize = False
        Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCode.Name = "lblCode"
        Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._lbl_0.Text = "Store Name:"
        Me._lbl_0.Size = New System.Drawing.Size(82, 16)
        Me._lbl_0.Location = New System.Drawing.Point(24, 24)
        Me._lbl_0.TabIndex = 16
        Me._lbl_0.BackColor = System.Drawing.Color.Transparent
        Me._lbl_0.Enabled = True
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.UseMnemonic = True
        Me._lbl_0.Visible = True
        Me._lbl_0.AutoSize = False
        Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lbl_0.Name = "_lbl_0"
        Me.txtPassword.AutoSize = False
        Me.txtPassword.Enabled = False
        Me.txtPassword.Size = New System.Drawing.Size(149, 16)
        Me.txtPassword.IMEMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(98, 377)
        Me.txtPassword.PasswordChar = ChrW(42)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "password"
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.CausesValidation = True
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.HideSelection = True
        Me.txtPassword.ReadOnly = False
        Me.txtPassword.Maxlength = 0
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.MultiLine = False
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPassword.TabStop = True
        Me.txtPassword.Visible = True
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Name = "txtPassword"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdCancel.Text = "E&xit"
        Me.cmdCancel.Size = New System.Drawing.Size(76, 26)
        Me.cmdCancel.Location = New System.Drawing.Point(171, 407)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.CausesValidation = True
        Me.cmdCancel.Enabled = True
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.TabStop = True
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.Enabled = False
        Me.cmdOK.Size = New System.Drawing.Size(76, 26)
        Me.cmdOK.Location = New System.Drawing.Point(24, 407)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.CausesValidation = True
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.TabStop = True
        Me.cmdOK.Name = "cmdOK"
        Me.txtUserName.AutoSize = False
        Me.txtUserName.Enabled = False
        Me.txtUserName.Size = New System.Drawing.Size(149, 16)
        Me.txtUserName.Location = New System.Drawing.Point(98, 354)
        Me.txtUserName.TabIndex = 1
        Me.txtUserName.Text = "default"
        Me.txtUserName.AcceptsReturn = True
        Me.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUserName.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserName.CausesValidation = True
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUserName.HideSelection = True
        Me.txtUserName.ReadOnly = False
        Me.txtUserName.Maxlength = 0
        Me.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUserName.MultiLine = False
        Me.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtUserName.TabStop = True
        Me.txtUserName.Visible = True
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserName.Name = "txtUserName"
        'MAPISession1.OcxState = CType(resources.GetObject("MAPISession1.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.MAPISession1.Location = New System.Drawing.Point(606, 381)
        'Me.MAPISession1.Name = "MAPISession1"
        'MAPIMessages1.OcxState = CType(resources.GetObject("MAPIMessages1.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.MAPIMessages1.Location = New System.Drawing.Point(603, 447)
        'Me.MAPIMessages1.Name = "MAPIMessages1"
        Me.tmrStart.Interval = 1
        Me.tmrStart.Enabled = True
        Me.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdBuild.Text = "Synchronize Via Email"
        Me.cmdBuild.Enabled = False
        Me.cmdBuild.Size = New System.Drawing.Size(223, 46)
        Me.cmdBuild.Location = New System.Drawing.Point(24, 447)
        Me.cmdBuild.TabIndex = 7
        Me.cmdBuild.TabStop = False
        Me.cmdBuild.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuild.CausesValidation = True
        Me.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuild.Name = "cmdBuild"
        Me.lvLocation.Size = New System.Drawing.Size(592, 265)
        Me.lvLocation.Location = New System.Drawing.Point(9, 9)
        Me.lvLocation.TabIndex = 6
        Me.lvLocation.TabStop = 0
        Me.lvLocation.View = System.Windows.Forms.View.Details
        Me.lvLocation.LabelEdit = False
        Me.lvLocation.LabelWrap = True
        Me.lvLocation.HideSelection = True
        Me.lvLocation.SmallImageList = ILtree
        Me.lvLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvLocation.BackColor = System.Drawing.SystemColors.Window
        Me.lvLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lvLocation.Name = "lvLocation"
        Me._lvLocation_ColumnHeader_1.Text = "Company"
        Me._lvLocation_ColumnHeader_1.Width = 236
        Me._lvLocation_ColumnHeader_2.Text = "Location"
        Me._lvLocation_ColumnHeader_2.Width = 236
        Me._lvLocation_ColumnHeader_3.Text = "Path"
        Me._lvLocation_ColumnHeader_3.Width = 530
        Me.ILtree.ImageSize = New System.Drawing.Size(16, 16)
        Me.ILtree.TransparentColor = System.Drawing.Color.White
        Me.ILtree.ImageStream = CType(resources.GetObject("ILtree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ILtree.Images.SetKeyName(0, "cm")
        Me.ILtree.Images.SetKeyName(1, "")
        Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label1_4.Text = "Directory:"
        Me._Label1_4.Enabled = False
        Me._Label1_4.Size = New System.Drawing.Size(45, 13)
        Me._Label1_4.Location = New System.Drawing.Point(48, 330)
        Me._Label1_4.TabIndex = 13
        Me._Label1_4.BackColor = System.Drawing.Color.Transparent
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.UseMnemonic = True
        Me._Label1_4.Visible = True
        Me._Label1_4.AutoSize = True
        Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label1_3.Text = "Database:"
        Me._Label1_3.Enabled = False
        Me._Label1_3.Size = New System.Drawing.Size(49, 13)
        Me._Label1_3.Location = New System.Drawing.Point(44, 309)
        Me._Label1_3.TabIndex = 12
        Me._Label1_3.BackColor = System.Drawing.Color.Transparent
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.UseMnemonic = True
        Me._Label1_3.Visible = True
        Me._Label1_3.AutoSize = True
        Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label1_2.Text = "Company:"
        Me._Label1_2.Enabled = False
        Me._Label1_2.Size = New System.Drawing.Size(47, 13)
        Me._Label1_2.Location = New System.Drawing.Point(46, 288)
        Me._Label1_2.TabIndex = 11
        Me._Label1_2.BackColor = System.Drawing.Color.Transparent
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.UseMnemonic = True
        Me._Label1_2.Visible = True
        Me._Label1_2.AutoSize = True
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label1_0.Text = "User ID:"
        Me._Label1_0.Enabled = False
        Me._Label1_0.Size = New System.Drawing.Size(39, 13)
        Me._Label1_0.Location = New System.Drawing.Point(54, 357)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.UseMnemonic = True
        Me._Label1_0.Visible = True
        Me._Label1_0.AutoSize = True
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me._Label1_1.Text = "Password:"
        Me._Label1_1.Enabled = False
        Me._Label1_1.Size = New System.Drawing.Size(49, 13)
        Me._Label1_1.Location = New System.Drawing.Point(44, 381)
        Me._Label1_1.TabIndex = 2
        Me._Label1_1.BackColor = System.Drawing.Color.Transparent
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.UseMnemonic = True
        Me._Label1_1.Visible = True
        Me._Label1_1.AutoSize = True
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_1.Name = "_Label1_1"
        Me.lblDir.Text = "..."
        Me.lblDir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDir.Size = New System.Drawing.Size(9, 16)
        Me.lblDir.Location = New System.Drawing.Point(96, 327)
        Me.lblDir.TabIndex = 10
        Me.lblDir.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblDir.BackColor = System.Drawing.Color.Transparent
        Me.lblDir.Enabled = True
        Me.lblDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDir.UseMnemonic = True
        Me.lblDir.Visible = True
        Me.lblDir.AutoSize = True
        Me.lblDir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDir.Name = "lblDir"
        Me.lblPath.Text = "..."
        Me.lblPath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPath.Size = New System.Drawing.Size(9, 16)
        Me.lblPath.Location = New System.Drawing.Point(96, 306)
        Me.lblPath.TabIndex = 9
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblPath.BackColor = System.Drawing.Color.Transparent
        Me.lblPath.Enabled = True
        Me.lblPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPath.UseMnemonic = True
        Me.lblPath.Visible = True
        Me.lblPath.AutoSize = True
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblPath.Name = "lblPath"
        Me.lblCompany.Text = "..."
        Me.lblCompany.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCompany.Size = New System.Drawing.Size(9, 16)
        Me.lblCompany.Location = New System.Drawing.Point(96, 285)
        Me.lblCompany.TabIndex = 8
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblCompany.Enabled = True
        Me.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCompany.UseMnemonic = True
        Me.lblCompany.Visible = True
        Me.lblCompany.AutoSize = True
        Me.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblCompany.Name = "lblCompany"
        Me.Controls.Add(cmdDatabase)
        Me.Controls.Add(cmdCompany)
        Me.Controls.Add(frmRegister)
        Me.Controls.Add(txtPassword)
        Me.Controls.Add(cmdCancel)
        Me.Controls.Add(cmdOK)
        Me.Controls.Add(txtUserName)
        'Me.Controls.Add(MAPISession1)
        'Me.Controls.Add(MAPIMessages1)
        Me.Controls.Add(cmdBuild)
        Me.Controls.Add(lvLocation)
        Me.Controls.Add(_Label1_4)
        Me.Controls.Add(_Label1_3)
        Me.Controls.Add(_Label1_2)
        Me.Controls.Add(_Label1_0)
        Me.Controls.Add(_Label1_1)
        Me.Controls.Add(lblDir)
        Me.Controls.Add(lblPath)
        Me.Controls.Add(lblCompany)
        Me.frmRegister.Controls.Add(txtKey)
        Me.frmRegister.Controls.Add(cmdRegistration)
        Me.frmRegister.Controls.Add(txtCompany)
        Me.frmRegister.Controls.Add(_Label2_1)
        Me.frmRegister.Controls.Add(_Label2_0)
        Me.frmRegister.Controls.Add(lblCode)
        Me.frmRegister.Controls.Add(_lbl_0)
        Me.lvLocation.Columns.Add(_lvLocation_ColumnHeader_1)
        Me.lvLocation.Columns.Add(_lvLocation_ColumnHeader_2)
        Me.lvLocation.Columns.Add(_lvLocation_ColumnHeader_3)
        'Me.Label1.SetIndex(_Label1_4, CType(4, Short))
        'Me.Label1.SetIndex(_Label1_3, CType(3, Short))
        'Me.Label1.SetIndex(_Label1_2, CType(2, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.MAPIMessages1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.MAPISession1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmRegister.ResumeLayout(False)
        Me.lvLocation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region 
End Class