<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRegister
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
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents txtCompany As System.Windows.Forms.TextBox
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _picMode_0 As System.Windows.Forms.Panel
	Public WithEvents txtKey As System.Windows.Forms.TextBox
	Public WithEvents lblCompany As System.Windows.Forms.Label
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents lblCode As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _picMode_1 As System.Windows.Forms.Panel
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents picMode As Microsoft.VisualBasic.Compatibility.VB6.PanelArray
	Public WithEvents Shape1 As OvalShapeArray
	Public WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRegister))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdExit = New System.Windows.Forms.Button
		Me._picMode_0 = New System.Windows.Forms.Panel
		Me.txtCompany = New System.Windows.Forms.TextBox
		Me._lbl_0 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me._lbl_3 = New System.Windows.Forms.Label
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._picMode_1 = New System.Windows.Forms.Panel
		Me.txtKey = New System.Windows.Forms.TextBox
		Me.lblCompany = New System.Windows.Forms.Label
		Me._Label2_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label2_0 = New System.Windows.Forms.Label
		Me.lblCode = New System.Windows.Forms.Label
		Me._Label2_1 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.cmdNext = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.picMode = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(components)
		Me.Shape1 = New OvalShapeArray(components)
		Me._picMode_0.SuspendLayout()
		Me._picMode_1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.picMode, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Registration Wizard"
		Me.ClientSize = New System.Drawing.Size(296, 282)
		Me.Location = New System.Drawing.Point(3, 22)
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
		Me.Name = "frmRegister"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 28)
		Me.cmdExit.Location = New System.Drawing.Point(8, 249)
		Me.cmdExit.TabIndex = 8
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me._picMode_0.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._picMode_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._picMode_0.Size = New System.Drawing.Size(283, 232)
		Me._picMode_0.Location = New System.Drawing.Point(6, 9)
		Me._picMode_0.TabIndex = 13
		Me._picMode_0.TabStop = False
		Me._picMode_0.Dock = System.Windows.Forms.DockStyle.None
		Me._picMode_0.CausesValidation = True
		Me._picMode_0.Enabled = True
		Me._picMode_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._picMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._picMode_0.Visible = True
		Me._picMode_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._picMode_0.Name = "_picMode_0"
		Me.txtCompany.AutoSize = False
		Me.txtCompany.Size = New System.Drawing.Size(271, 19)
		Me.txtCompany.Location = New System.Drawing.Point(6, 201)
		Me.txtCompany.Maxlength = 50
		Me.txtCompany.TabIndex = 6
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
		Me.txtCompany.TabStop = True
		Me.txtCompany.Visible = True
		Me.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCompany.Name = "txtCompany"
		Me._lbl_0.Text = "Store Name:"
		Me._lbl_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_0.Size = New System.Drawing.Size(178, 16)
		Me._lbl_0.Location = New System.Drawing.Point(6, 186)
		Me._lbl_0.TabIndex = 5
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lbl_1.Text = "Welcome to the 4POS Application Suite of products designed for the Retailer."
		Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_1.Size = New System.Drawing.Size(280, 43)
		Me._lbl_1.Location = New System.Drawing.Point(0, 0)
		Me._lbl_1.TabIndex = 2
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = False
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lbl_2.Text = "In the text box below, please capture your store's name. It is imperative that you capture you stores name correctly as this makes up part of your licensing agreement with 4POS."
		Me._lbl_2.Size = New System.Drawing.Size(274, 64)
		Me._lbl_2.Location = New System.Drawing.Point(6, 36)
		Me._lbl_2.TabIndex = 3
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = False
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me._lbl_3.Text = "To bypass this registration process, press the ""Exit"" button. This will activate the demo version of this software, which is fully functional except that you may only complete ten ""Day End"" runs."
		Me._lbl_3.Size = New System.Drawing.Size(274, 64)
		Me._lbl_3.Location = New System.Drawing.Point(6, 99)
		Me._lbl_3.TabIndex = 4
		Me._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_3.BackColor = System.Drawing.Color.Transparent
		Me._lbl_3.Enabled = True
		Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_3.UseMnemonic = True
		Me._lbl_3.Visible = True
		Me._lbl_3.AutoSize = False
		Me._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_3.Name = "_lbl_3"
		Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_0.Size = New System.Drawing.Size(283, 133)
		Me._Shape1_0.Location = New System.Drawing.Point(0, 30)
		Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_0.BorderWidth = 1
		Me._Shape1_0.FillColor = System.Drawing.Color.Black
		Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_0.Visible = True
		Me._Shape1_0.Name = "_Shape1_0"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(283, 46)
		Me._Shape1_1.Location = New System.Drawing.Point(0, 183)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me._picMode_1.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._picMode_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._picMode_1.Size = New System.Drawing.Size(283, 232)
		Me._picMode_1.Location = New System.Drawing.Point(333, 57)
		Me._picMode_1.TabIndex = 9
		Me._picMode_1.TabStop = False
		Me._picMode_1.Visible = False
		Me._picMode_1.Dock = System.Windows.Forms.DockStyle.None
		Me._picMode_1.CausesValidation = True
		Me._picMode_1.Enabled = True
		Me._picMode_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._picMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._picMode_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._picMode_1.Name = "_picMode_1"
		Me.txtKey.AutoSize = False
		Me.txtKey.Size = New System.Drawing.Size(175, 19)
		Me.txtKey.Location = New System.Drawing.Point(99, 186)
		Me.txtKey.TabIndex = 1
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
		Me.txtKey.TabStop = True
		Me.txtKey.Visible = True
		Me.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKey.Name = "txtKey"
		Me.lblCompany.BackColor = System.Drawing.Color.Transparent
		Me.lblCompany.Text = "123456789012345"
		Me.lblCompany.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblCompany.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCompany.Size = New System.Drawing.Size(276, 18)
		Me.lblCompany.Location = New System.Drawing.Point(3, 87)
		Me.lblCompany.TabIndex = 15
		Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCompany.Enabled = True
		Me.lblCompany.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCompany.UseMnemonic = True
		Me.lblCompany.Visible = True
		Me.lblCompany.AutoSize = False
		Me.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCompany.Name = "lblCompany"
		Me._Label2_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label2_2.Text = "Company Name:"
		Me._Label2_2.Size = New System.Drawing.Size(93, 13)
		Me._Label2_2.Location = New System.Drawing.Point(-12, 75)
		Me._Label2_2.TabIndex = 14
		Me._Label2_2.BackColor = System.Drawing.Color.Transparent
		Me._Label2_2.Enabled = True
		Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_2.UseMnemonic = True
		Me._Label2_2.Visible = True
		Me._Label2_2.AutoSize = False
		Me._Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_2.Name = "_Label2_2"
		Me._Label1_1.Text = "Please contact a ""4POS"" representative and quote the company name and registration code below to get your new activation key for the product."
		Me._Label1_1.Size = New System.Drawing.Size(280, 58)
		Me._Label1_1.Location = New System.Drawing.Point(3, 0)
		Me._Label1_1.TabIndex = 12
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
		Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label2_0.Text = "Registration code:"
		Me._Label2_0.Size = New System.Drawing.Size(93, 13)
		Me._Label2_0.Location = New System.Drawing.Point(-3, 102)
		Me._Label2_0.TabIndex = 11
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
		Me.lblCode.BackColor = System.Drawing.Color.Transparent
		Me.lblCode.Text = "123456789012345"
		Me.lblCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCode.Size = New System.Drawing.Size(123, 18)
		Me.lblCode.Location = New System.Drawing.Point(3, 114)
		Me.lblCode.TabIndex = 10
		Me.lblCode.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCode.Enabled = True
		Me.lblCode.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCode.UseMnemonic = True
		Me.lblCode.Visible = True
		Me.lblCode.AutoSize = False
		Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCode.Name = "lblCode"
		Me._Label2_1.Text = "Activation key:"
		Me._Label2_1.Size = New System.Drawing.Size(70, 13)
		Me._Label2_1.Location = New System.Drawing.Point(21, 189)
		Me._Label2_1.TabIndex = 0
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
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(283, 67)
		Me._Shape1_2.Location = New System.Drawing.Point(0, 72)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me._Shape1_3.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_3.Size = New System.Drawing.Size(283, 31)
		Me._Shape1_3.Location = New System.Drawing.Point(0, 180)
		Me._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_3.BorderWidth = 1
		Me._Shape1_3.FillColor = System.Drawing.Color.Black
		Me._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_3.Visible = True
		Me._Shape1_3.Name = "_Shape1_3"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Size = New System.Drawing.Size(97, 28)
		Me.cmdNext.Location = New System.Drawing.Point(186, 249)
		Me.cmdNext.TabIndex = 7
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.Label4.Text = "Label4"
		Me.Label4.Size = New System.Drawing.Size(273, 33)
		Me.Label4.Location = New System.Drawing.Point(16, 320)
		Me.Label4.TabIndex = 17
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Label3"
		Me.Label3.Size = New System.Drawing.Size(265, 25)
		Me.Label3.Location = New System.Drawing.Point(16, 288)
		Me.Label3.TabIndex = 16
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_picMode_0)
		Me.Controls.Add(_picMode_1)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me._picMode_0.Controls.Add(txtCompany)
		Me._picMode_0.Controls.Add(_lbl_0)
		Me._picMode_0.Controls.Add(_lbl_1)
		Me._picMode_0.Controls.Add(_lbl_2)
		Me._picMode_0.Controls.Add(_lbl_3)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me._picMode_0.Controls.Add(ShapeContainer1)
		Me._picMode_1.Controls.Add(txtKey)
		Me._picMode_1.Controls.Add(lblCompany)
		Me._picMode_1.Controls.Add(_Label2_2)
		Me._picMode_1.Controls.Add(_Label1_1)
		Me._picMode_1.Controls.Add(_Label2_0)
		Me._picMode_1.Controls.Add(lblCode)
		Me._picMode_1.Controls.Add(_Label2_1)
		Me.ShapeContainer2.Shapes.Add(_Shape1_2)
		Me.ShapeContainer2.Shapes.Add(_Shape1_3)
		Me._picMode_1.Controls.Add(ShapeContainer2)
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_2, CType(2, Short))
        'Me.Label2.SetIndex(_Label2_0, CType(0, Short))
        'Me.Label2.SetIndex(_Label2_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lbl.SetIndex(_lbl_3, CType(3, Short))
        'Me.picMode.SetIndex(_picMode_0, CType(0, Short))
        'Me.picMode.SetIndex(_picMode_1, CType(1, Short))
        'Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
        'Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
        'Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
        'Me.Shape1.SetIndex(_Shape1_3, CType(3, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.picMode, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._picMode_0.ResumeLayout(False)
		Me._picMode_1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class