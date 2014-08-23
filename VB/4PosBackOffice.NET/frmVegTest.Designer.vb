<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVegTest
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
	Public PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
	Public WithEvents AvailGRV As System.Windows.Forms.TextBox
	Public WithEvents lblTotalOP As System.Windows.Forms.Label
	Public WithEvents lblTotalLP As System.Windows.Forms.Label
	Public WithEvents lblTotalO As System.Windows.Forms.Label
	Public WithEvents _lblTotal_17 As System.Windows.Forms.Label
	Public WithEvents lblTotalL As System.Windows.Forms.Label
	Public WithEvents _lblTotal_16 As System.Windows.Forms.Label
	Public WithEvents lblTotalH As System.Windows.Forms.Label
	Public WithEvents _lblTotal_15 As System.Windows.Forms.Label
	Public WithEvents lblTotalG As System.Windows.Forms.Label
	Public WithEvents _lblTotal_14 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_13 As System.Windows.Forms.Label
	Public WithEvents lblTotalQ As System.Windows.Forms.Label
	Public WithEvents _lblTotal_12 As System.Windows.Forms.Label
	Public WithEvents lblTotalF As System.Windows.Forms.Label
	Public WithEvents lblP As System.Windows.Forms.Label
	Public WithEvents _lblTotal_11 As System.Windows.Forms.Label
	Public WithEvents picTotal As System.Windows.Forms.Panel
	Public WithEvents _txtEdit_0 As System.Windows.Forms.TextBox
	Public WithEvents TotalQTY As System.Windows.Forms.TextBox
	Public WithEvents TotalQTYd As System.Windows.Forms.TextBox
	Public WithEvents txtR As System.Windows.Forms.TextBox
	Public WithEvents txtZ As System.Windows.Forms.TextBox
	Public WithEvents cmdTotal As System.Windows.Forms.Button
	Public WithEvents txtReqGP As System.Windows.Forms.TextBox
	Public WithEvents txtVAT As System.Windows.Forms.TextBox
	Public WithEvents lblQuantity As System.Windows.Forms.Label
	Public WithEvents _lbl_8 As System.Windows.Forms.Label
	Public WithEvents lblBrokenPack As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents lblContentExclusive As System.Windows.Forms.Label
	Public WithEvents lblContentInclusives As System.Windows.Forms.Label
	Public WithEvents lblDepositExclusives As System.Windows.Forms.Label
	Public WithEvents lblA As System.Windows.Forms.Label
	Public WithEvents lblB As System.Windows.Forms.Label
	Public WithEvents lblC As System.Windows.Forms.Label
	Public WithEvents _lblTotal_0 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_1 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_2 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_3 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_4 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_5 As System.Windows.Forms.Label
	Public WithEvents lblX As System.Windows.Forms.Label
	Public WithEvents lblGP_Y As System.Windows.Forms.Label
	Public WithEvents lblB_Z As System.Windows.Forms.Label
	Public WithEvents _lblTotal_6 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_7 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_8 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_9 As System.Windows.Forms.Label
	Public WithEvents _lblTotal_10 As System.Windows.Forms.Label
	Public WithEvents frmTotals As System.Windows.Forms.GroupBox
	Public WithEvents _txtEdit_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtEdit_2 As System.Windows.Forms.TextBox
	Public WithEvents cmdReg As System.Windows.Forms.Button
	Public WithEvents cmdProc As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents gridItem As myDataGridView
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblTotal As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtEdit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVegTest))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me)
		Me.AvailGRV = New System.Windows.Forms.TextBox
		Me.picTotal = New System.Windows.Forms.Panel
		Me.lblTotalOP = New System.Windows.Forms.Label
		Me.lblTotalLP = New System.Windows.Forms.Label
		Me.lblTotalO = New System.Windows.Forms.Label
		Me._lblTotal_17 = New System.Windows.Forms.Label
		Me.lblTotalL = New System.Windows.Forms.Label
		Me._lblTotal_16 = New System.Windows.Forms.Label
		Me.lblTotalH = New System.Windows.Forms.Label
		Me._lblTotal_15 = New System.Windows.Forms.Label
		Me.lblTotalG = New System.Windows.Forms.Label
		Me._lblTotal_14 = New System.Windows.Forms.Label
		Me._lblTotal_13 = New System.Windows.Forms.Label
		Me.lblTotalQ = New System.Windows.Forms.Label
		Me._lblTotal_12 = New System.Windows.Forms.Label
		Me.lblTotalF = New System.Windows.Forms.Label
		Me.lblP = New System.Windows.Forms.Label
		Me._lblTotal_11 = New System.Windows.Forms.Label
		Me._txtEdit_0 = New System.Windows.Forms.TextBox
		Me.frmTotals = New System.Windows.Forms.GroupBox
		Me.TotalQTY = New System.Windows.Forms.TextBox
		Me.TotalQTYd = New System.Windows.Forms.TextBox
		Me.txtR = New System.Windows.Forms.TextBox
		Me.txtZ = New System.Windows.Forms.TextBox
		Me.cmdTotal = New System.Windows.Forms.Button
		Me.txtReqGP = New System.Windows.Forms.TextBox
		Me.txtVAT = New System.Windows.Forms.TextBox
		Me.lblQuantity = New System.Windows.Forms.Label
		Me._lbl_8 = New System.Windows.Forms.Label
		Me.lblBrokenPack = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
		Me.lblContentExclusive = New System.Windows.Forms.Label
		Me.lblContentInclusives = New System.Windows.Forms.Label
		Me.lblDepositExclusives = New System.Windows.Forms.Label
		Me.lblA = New System.Windows.Forms.Label
		Me.lblB = New System.Windows.Forms.Label
		Me.lblC = New System.Windows.Forms.Label
		Me._lblTotal_0 = New System.Windows.Forms.Label
		Me._lblTotal_1 = New System.Windows.Forms.Label
		Me._lblTotal_2 = New System.Windows.Forms.Label
		Me._lblTotal_3 = New System.Windows.Forms.Label
		Me._lblTotal_4 = New System.Windows.Forms.Label
		Me._lblTotal_5 = New System.Windows.Forms.Label
		Me.lblX = New System.Windows.Forms.Label
		Me.lblGP_Y = New System.Windows.Forms.Label
		Me.lblB_Z = New System.Windows.Forms.Label
		Me._lblTotal_6 = New System.Windows.Forms.Label
		Me._lblTotal_7 = New System.Windows.Forms.Label
		Me._lblTotal_8 = New System.Windows.Forms.Label
		Me._lblTotal_9 = New System.Windows.Forms.Label
		Me._lblTotal_10 = New System.Windows.Forms.Label
		Me._txtEdit_1 = New System.Windows.Forms.TextBox
		Me._txtEdit_2 = New System.Windows.Forms.TextBox
		Me.Picture2 = New System.Windows.Forms.Panel
		Me.cmdReg = New System.Windows.Forms.Button
		Me.cmdProc = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.gridItem = New myDataGridView
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.lblTotal = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.txtEdit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.picTotal.SuspendLayout()
		Me.frmTotals.SuspendLayout()
		Me.Picture2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "4VEG Production Tester"
		Me.ClientSize = New System.Drawing.Size(1016, 707)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "frmVegTest"
		Me.AvailGRV.AutoSize = False
		Me.AvailGRV.Size = New System.Drawing.Size(105, 19)
		Me.AvailGRV.Location = New System.Drawing.Point(168, 664)
		Me.AvailGRV.ReadOnly = True
		Me.AvailGRV.TabIndex = 56
		Me.AvailGRV.Text = "0"
		Me.AvailGRV.Visible = False
		Me.AvailGRV.AcceptsReturn = True
		Me.AvailGRV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.AvailGRV.BackColor = System.Drawing.SystemColors.Window
		Me.AvailGRV.CausesValidation = True
		Me.AvailGRV.Enabled = True
		Me.AvailGRV.ForeColor = System.Drawing.SystemColors.WindowText
		Me.AvailGRV.HideSelection = True
		Me.AvailGRV.Maxlength = 0
		Me.AvailGRV.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.AvailGRV.MultiLine = False
		Me.AvailGRV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.AvailGRV.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.AvailGRV.TabStop = True
		Me.AvailGRV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.AvailGRV.Name = "AvailGRV"
		Me.picTotal.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.picTotal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picTotal.Size = New System.Drawing.Size(997, 73)
		Me.picTotal.Location = New System.Drawing.Point(8, 576)
		Me.picTotal.TabIndex = 37
		Me.picTotal.Visible = False
		Me.picTotal.Dock = System.Windows.Forms.DockStyle.None
		Me.picTotal.CausesValidation = True
		Me.picTotal.Enabled = True
		Me.picTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.picTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picTotal.TabStop = True
		Me.picTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picTotal.Name = "picTotal"
		Me.lblTotalOP.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalOP.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalOP.Text = "0.00"
		Me.lblTotalOP.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalOP.Location = New System.Drawing.Point(928, 16)
		Me.lblTotalOP.TabIndex = 54
		Me.lblTotalOP.Visible = False
		Me.lblTotalOP.Enabled = True
		Me.lblTotalOP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalOP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalOP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalOP.UseMnemonic = True
		Me.lblTotalOP.AutoSize = False
		Me.lblTotalOP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalOP.Name = "lblTotalOP"
		Me.lblTotalLP.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalLP.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalLP.Text = "0.00"
		Me.lblTotalLP.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalLP.Location = New System.Drawing.Point(728, 16)
		Me.lblTotalLP.TabIndex = 53
		Me.lblTotalLP.Visible = False
		Me.lblTotalLP.Enabled = True
		Me.lblTotalLP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalLP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalLP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalLP.UseMnemonic = True
		Me.lblTotalLP.AutoSize = False
		Me.lblTotalLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalLP.Name = "lblTotalLP"
		Me.lblTotalO.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalO.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalO.Text = "0.00"
		Me.lblTotalO.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalO.Location = New System.Drawing.Point(928, 0)
		Me.lblTotalO.TabIndex = 51
		Me.lblTotalO.Visible = False
		Me.lblTotalO.Enabled = True
		Me.lblTotalO.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalO.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalO.UseMnemonic = True
		Me.lblTotalO.AutoSize = False
		Me.lblTotalO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalO.Name = "lblTotalO"
		Me._lblTotal_17.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_17.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_17.Text = "O :"
		Me._lblTotal_17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_17.Size = New System.Drawing.Size(35, 16)
		Me._lblTotal_17.Location = New System.Drawing.Point(944, 32)
		Me._lblTotal_17.TabIndex = 50
		Me._lblTotal_17.Visible = False
		Me._lblTotal_17.Enabled = True
		Me._lblTotal_17.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_17.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_17.UseMnemonic = True
		Me._lblTotal_17.AutoSize = False
		Me._lblTotal_17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_17.Name = "_lblTotal_17"
		Me.lblTotalL.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalL.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalL.Text = "0.00"
		Me.lblTotalL.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalL.Location = New System.Drawing.Point(728, 0)
		Me.lblTotalL.TabIndex = 49
		Me.lblTotalL.Visible = False
		Me.lblTotalL.Enabled = True
		Me.lblTotalL.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalL.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalL.UseMnemonic = True
		Me.lblTotalL.AutoSize = False
		Me.lblTotalL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalL.Name = "lblTotalL"
		Me._lblTotal_16.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_16.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_16.Text = "L :"
		Me._lblTotal_16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_16.Size = New System.Drawing.Size(35, 16)
		Me._lblTotal_16.Location = New System.Drawing.Point(736, 32)
		Me._lblTotal_16.TabIndex = 48
		Me._lblTotal_16.Visible = False
		Me._lblTotal_16.Enabled = True
		Me._lblTotal_16.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_16.UseMnemonic = True
		Me._lblTotal_16.AutoSize = False
		Me._lblTotal_16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_16.Name = "_lblTotal_16"
		Me.lblTotalH.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalH.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalH.Text = "0.00"
		Me.lblTotalH.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalH.Location = New System.Drawing.Point(462, 0)
		Me.lblTotalH.TabIndex = 47
		Me.lblTotalH.Visible = False
		Me.lblTotalH.Enabled = True
		Me.lblTotalH.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalH.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalH.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalH.UseMnemonic = True
		Me.lblTotalH.AutoSize = False
		Me.lblTotalH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalH.Name = "lblTotalH"
		Me._lblTotal_15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_15.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_15.Text = "H :"
		Me._lblTotal_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_15.Size = New System.Drawing.Size(27, 16)
		Me._lblTotal_15.Location = New System.Drawing.Point(480, 16)
		Me._lblTotal_15.TabIndex = 46
		Me._lblTotal_15.Visible = False
		Me._lblTotal_15.Enabled = True
		Me._lblTotal_15.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_15.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_15.UseMnemonic = True
		Me._lblTotal_15.AutoSize = False
		Me._lblTotal_15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_15.Name = "_lblTotal_15"
		Me.lblTotalG.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalG.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalG.Text = "0.00"
		Me.lblTotalG.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalG.Location = New System.Drawing.Point(392, 0)
		Me.lblTotalG.TabIndex = 45
		Me.lblTotalG.Visible = False
		Me.lblTotalG.Enabled = True
		Me.lblTotalG.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalG.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalG.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalG.UseMnemonic = True
		Me.lblTotalG.AutoSize = False
		Me.lblTotalG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalG.Name = "lblTotalG"
		Me._lblTotal_14.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_14.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_14.Text = "G :"
		Me._lblTotal_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_14.Size = New System.Drawing.Size(27, 16)
		Me._lblTotal_14.Location = New System.Drawing.Point(408, 16)
		Me._lblTotal_14.TabIndex = 44
		Me._lblTotal_14.Visible = False
		Me._lblTotal_14.Enabled = True
		Me._lblTotal_14.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_14.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_14.UseMnemonic = True
		Me._lblTotal_14.AutoSize = False
		Me._lblTotal_14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_14.Name = "_lblTotal_14"
		Me._lblTotal_13.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_13.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_13.Text = "Q :"
		Me._lblTotal_13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_13.Size = New System.Drawing.Size(35, 16)
		Me._lblTotal_13.Location = New System.Drawing.Point(536, 16)
		Me._lblTotal_13.TabIndex = 43
		Me._lblTotal_13.Visible = False
		Me._lblTotal_13.Enabled = True
		Me._lblTotal_13.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_13.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_13.UseMnemonic = True
		Me._lblTotal_13.AutoSize = False
		Me._lblTotal_13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_13.Name = "_lblTotal_13"
		Me.lblTotalQ.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalQ.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalQ.Text = "0.00"
		Me.lblTotalQ.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalQ.Location = New System.Drawing.Point(528, 0)
		Me.lblTotalQ.TabIndex = 42
		Me.lblTotalQ.Visible = False
		Me.lblTotalQ.Enabled = True
		Me.lblTotalQ.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalQ.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalQ.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalQ.UseMnemonic = True
		Me.lblTotalQ.AutoSize = False
		Me.lblTotalQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalQ.Name = "lblTotalQ"
		Me._lblTotal_12.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_12.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_12.Text = "F :"
		Me._lblTotal_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_12.Size = New System.Drawing.Size(27, 16)
		Me._lblTotal_12.Location = New System.Drawing.Point(344, 16)
		Me._lblTotal_12.TabIndex = 41
		Me._lblTotal_12.Visible = False
		Me._lblTotal_12.Enabled = True
		Me._lblTotal_12.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_12.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_12.UseMnemonic = True
		Me._lblTotal_12.AutoSize = False
		Me._lblTotal_12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_12.Name = "_lblTotal_12"
		Me.lblTotalF.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalF.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblTotalF.Text = "0.00"
		Me.lblTotalF.Size = New System.Drawing.Size(65, 16)
		Me.lblTotalF.Location = New System.Drawing.Point(323, 0)
		Me.lblTotalF.TabIndex = 40
		Me.lblTotalF.Visible = False
		Me.lblTotalF.Enabled = True
		Me.lblTotalF.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalF.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalF.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalF.UseMnemonic = True
		Me.lblTotalF.AutoSize = False
		Me.lblTotalF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalF.Name = "lblTotalF"
		Me.lblP.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblP.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblP.Text = "0.00"
		Me.lblP.Size = New System.Drawing.Size(65, 16)
		Me.lblP.Location = New System.Drawing.Point(192, 0)
		Me.lblP.TabIndex = 39
		Me.lblP.Enabled = True
		Me.lblP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblP.UseMnemonic = True
		Me.lblP.Visible = True
		Me.lblP.AutoSize = False
		Me.lblP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblP.Name = "lblP"
		Me._lblTotal_11.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_11.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_11.Text = "After Production Qty.Loss - P :"
		Me._lblTotal_11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_11.Size = New System.Drawing.Size(187, 16)
		Me._lblTotal_11.Location = New System.Drawing.Point(0, 0)
		Me._lblTotal_11.TabIndex = 38
		Me._lblTotal_11.Enabled = True
		Me._lblTotal_11.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_11.UseMnemonic = True
		Me._lblTotal_11.Visible = True
		Me._lblTotal_11.AutoSize = False
		Me._lblTotal_11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_11.Name = "_lblTotal_11"
		Me._txtEdit_0.AutoSize = False
		Me._txtEdit_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_0.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_0.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_0.Location = New System.Drawing.Point(391, 546)
		Me._txtEdit_0.Maxlength = 8
		Me._txtEdit_0.TabIndex = 36
		Me._txtEdit_0.Tag = "0"
		Me._txtEdit_0.Text = "0"
		Me._txtEdit_0.Visible = False
		Me._txtEdit_0.AcceptsReturn = True
		Me._txtEdit_0.CausesValidation = True
		Me._txtEdit_0.Enabled = True
		Me._txtEdit_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_0.HideSelection = True
		Me._txtEdit_0.ReadOnly = False
		Me._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_0.MultiLine = False
		Me._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_0.TabStop = True
		Me._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_0.Name = "_txtEdit_0"
		Me.frmTotals.Text = " Genral Information "
		Me.frmTotals.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.frmTotals.Size = New System.Drawing.Size(889, 137)
		Me.frmTotals.Location = New System.Drawing.Point(3, 56)
		Me.frmTotals.TabIndex = 10
		Me.frmTotals.BackColor = System.Drawing.SystemColors.Control
		Me.frmTotals.Enabled = True
		Me.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmTotals.Visible = True
		Me.frmTotals.Padding = New System.Windows.Forms.Padding(0)
		Me.frmTotals.Name = "frmTotals"
		Me.TotalQTY.AutoSize = False
		Me.TotalQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TotalQTY.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.TotalQTY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.TotalQTY.Size = New System.Drawing.Size(234, 21)
		Me.TotalQTY.Location = New System.Drawing.Point(216, 66)
		Me.TotalQTY.ReadOnly = True
		Me.TotalQTY.TabIndex = 58
		Me.TotalQTY.Text = "0.00"
		Me.TotalQTY.AcceptsReturn = True
		Me.TotalQTY.CausesValidation = True
		Me.TotalQTY.Enabled = True
		Me.TotalQTY.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TotalQTY.HideSelection = True
		Me.TotalQTY.Maxlength = 0
		Me.TotalQTY.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TotalQTY.MultiLine = False
		Me.TotalQTY.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TotalQTY.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TotalQTY.TabStop = True
		Me.TotalQTY.Visible = True
		Me.TotalQTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TotalQTY.Name = "TotalQTY"
		Me.TotalQTYd.AutoSize = False
		Me.TotalQTYd.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.TotalQTYd.Size = New System.Drawing.Size(89, 19)
		Me.TotalQTYd.Location = New System.Drawing.Point(472, 112)
		Me.TotalQTYd.ReadOnly = True
		Me.TotalQTYd.TabIndex = 57
		Me.TotalQTYd.Text = "0"
		Me.TotalQTYd.Visible = False
		Me.TotalQTYd.AcceptsReturn = True
		Me.TotalQTYd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TotalQTYd.CausesValidation = True
		Me.TotalQTYd.Enabled = True
		Me.TotalQTYd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TotalQTYd.HideSelection = True
		Me.TotalQTYd.Maxlength = 0
		Me.TotalQTYd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TotalQTYd.MultiLine = False
		Me.TotalQTYd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TotalQTYd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TotalQTYd.TabStop = True
		Me.TotalQTYd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TotalQTYd.Name = "TotalQTYd"
		Me.txtR.AutoSize = False
		Me.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtR.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtR.Enabled = False
		Me.txtR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtR.Size = New System.Drawing.Size(234, 19)
		Me.txtR.Location = New System.Drawing.Point(216, 104)
		Me.txtR.TabIndex = 0
		Me.txtR.Text = "0.00"
		Me.txtR.Visible = False
		Me.txtR.AcceptsReturn = True
		Me.txtR.CausesValidation = True
		Me.txtR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtR.HideSelection = True
		Me.txtR.ReadOnly = False
		Me.txtR.Maxlength = 0
		Me.txtR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtR.MultiLine = False
		Me.txtR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtR.TabStop = True
		Me.txtR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtR.Name = "txtR"
		Me.txtZ.AutoSize = False
		Me.txtZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtZ.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtZ.Enabled = False
		Me.txtZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtZ.Size = New System.Drawing.Size(234, 19)
		Me.txtZ.Location = New System.Drawing.Point(208, 96)
		Me.txtZ.TabIndex = 1
		Me.txtZ.Text = "0.00"
		Me.txtZ.Visible = False
		Me.txtZ.AcceptsReturn = True
		Me.txtZ.CausesValidation = True
		Me.txtZ.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtZ.HideSelection = True
		Me.txtZ.ReadOnly = False
		Me.txtZ.Maxlength = 0
		Me.txtZ.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtZ.MultiLine = False
		Me.txtZ.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtZ.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtZ.TabStop = True
		Me.txtZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtZ.Name = "txtZ"
		Me.cmdTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTotal.Text = "Calculate"
		Me.cmdTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdTotal.Size = New System.Drawing.Size(99, 40)
		Me.cmdTotal.Location = New System.Drawing.Point(776, 32)
		Me.cmdTotal.TabIndex = 11
		Me.cmdTotal.TabStop = False
		Me.cmdTotal.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTotal.CausesValidation = True
		Me.cmdTotal.Enabled = True
		Me.cmdTotal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTotal.Name = "cmdTotal"
		Me.txtReqGP.AutoSize = False
		Me.txtReqGP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtReqGP.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtReqGP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtReqGP.Size = New System.Drawing.Size(120, 21)
		Me.txtReqGP.Location = New System.Drawing.Point(616, 20)
		Me.txtReqGP.ReadOnly = True
		Me.txtReqGP.TabIndex = 2
		Me.txtReqGP.Text = "0.00"
		Me.txtReqGP.AcceptsReturn = True
		Me.txtReqGP.CausesValidation = True
		Me.txtReqGP.Enabled = True
		Me.txtReqGP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtReqGP.HideSelection = True
		Me.txtReqGP.Maxlength = 0
		Me.txtReqGP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtReqGP.MultiLine = False
		Me.txtReqGP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtReqGP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtReqGP.TabStop = True
		Me.txtReqGP.Visible = True
		Me.txtReqGP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtReqGP.Name = "txtReqGP"
		Me.txtVAT.AutoSize = False
		Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtVAT.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.txtVAT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.txtVAT.Size = New System.Drawing.Size(120, 19)
		Me.txtVAT.Location = New System.Drawing.Point(616, 92)
		Me.txtVAT.TabIndex = 3
		Me.txtVAT.Text = "0.00"
		Me.txtVAT.Visible = False
		Me.txtVAT.AcceptsReturn = True
		Me.txtVAT.CausesValidation = True
		Me.txtVAT.Enabled = True
		Me.txtVAT.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVAT.HideSelection = True
		Me.txtVAT.ReadOnly = False
		Me.txtVAT.Maxlength = 0
		Me.txtVAT.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVAT.MultiLine = False
		Me.txtVAT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVAT.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVAT.TabStop = True
		Me.txtVAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVAT.Name = "txtVAT"
		Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblQuantity.Text = "lblQuantity"
		Me.lblQuantity.Size = New System.Drawing.Size(64, 17)
		Me.lblQuantity.Location = New System.Drawing.Point(673, 195)
		Me.lblQuantity.TabIndex = 35
		Me.lblQuantity.BackColor = System.Drawing.SystemColors.Control
		Me.lblQuantity.Enabled = True
		Me.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblQuantity.UseMnemonic = True
		Me.lblQuantity.Visible = True
		Me.lblQuantity.AutoSize = False
		Me.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblQuantity.Name = "lblQuantity"
		Me._lbl_8.Text = "No Of Cases"
		Me._lbl_8.Size = New System.Drawing.Size(60, 13)
		Me._lbl_8.Location = New System.Drawing.Point(673, 183)
		Me._lbl_8.TabIndex = 34
		Me._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_8.BackColor = System.Drawing.Color.Transparent
		Me._lbl_8.Enabled = True
		Me._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_8.UseMnemonic = True
		Me._lbl_8.Visible = True
		Me._lbl_8.AutoSize = True
		Me._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_8.Name = "_lbl_8"
		Me.lblBrokenPack.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblBrokenPack.Text = "lblQuantity"
		Me.lblBrokenPack.Size = New System.Drawing.Size(64, 17)
		Me.lblBrokenPack.Location = New System.Drawing.Point(745, 195)
		Me.lblBrokenPack.TabIndex = 33
		Me.lblBrokenPack.BackColor = System.Drawing.SystemColors.Control
		Me.lblBrokenPack.Enabled = True
		Me.lblBrokenPack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblBrokenPack.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblBrokenPack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblBrokenPack.UseMnemonic = True
		Me.lblBrokenPack.Visible = True
		Me.lblBrokenPack.AutoSize = False
		Me.lblBrokenPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblBrokenPack.Name = "lblBrokenPack"
		Me._lbl_2.Text = "Broken Packs"
		Me._lbl_2.Size = New System.Drawing.Size(67, 13)
		Me._lbl_2.Location = New System.Drawing.Point(742, 183)
		Me._lbl_2.TabIndex = 32
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
		Me.lblContentExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentExclusive.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me.lblContentExclusive.Text = "person name"
		Me.lblContentExclusive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblContentExclusive.Size = New System.Drawing.Size(234, 21)
		Me.lblContentExclusive.Location = New System.Drawing.Point(215, 20)
		Me.lblContentExclusive.TabIndex = 31
		Me.lblContentExclusive.Enabled = True
		Me.lblContentExclusive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentExclusive.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentExclusive.UseMnemonic = True
		Me.lblContentExclusive.Visible = True
		Me.lblContentExclusive.AutoSize = False
		Me.lblContentExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentExclusive.Name = "lblContentExclusive"
		Me.lblContentInclusives.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblContentInclusives.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblContentInclusives.Text = "0.00"
		Me.lblContentInclusives.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblContentInclusives.Size = New System.Drawing.Size(233, 16)
		Me.lblContentInclusives.Location = New System.Drawing.Point(840, 32)
		Me.lblContentInclusives.TabIndex = 30
		Me.lblContentInclusives.Visible = False
		Me.lblContentInclusives.Enabled = True
		Me.lblContentInclusives.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContentInclusives.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContentInclusives.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContentInclusives.UseMnemonic = True
		Me.lblContentInclusives.AutoSize = False
		Me.lblContentInclusives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblContentInclusives.Name = "lblContentInclusives"
		Me.lblDepositExclusives.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDepositExclusives.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblDepositExclusives.Text = "0.00"
		Me.lblDepositExclusives.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblDepositExclusives.Size = New System.Drawing.Size(233, 16)
		Me.lblDepositExclusives.Location = New System.Drawing.Point(840, 16)
		Me.lblDepositExclusives.TabIndex = 29
		Me.lblDepositExclusives.Visible = False
		Me.lblDepositExclusives.Enabled = True
		Me.lblDepositExclusives.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDepositExclusives.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDepositExclusives.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDepositExclusives.UseMnemonic = True
		Me.lblDepositExclusives.AutoSize = False
		Me.lblDepositExclusives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDepositExclusives.Name = "lblDepositExclusives"
		Me.lblA.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblA.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblA.Text = "0.00"
		Me.lblA.Enabled = False
		Me.lblA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblA.Size = New System.Drawing.Size(234, 16)
		Me.lblA.Location = New System.Drawing.Point(215, 74)
		Me.lblA.TabIndex = 28
		Me.lblA.Visible = False
		Me.lblA.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblA.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblA.UseMnemonic = True
		Me.lblA.AutoSize = False
		Me.lblA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblA.Name = "lblA"
		Me.lblB.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblB.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblB.Text = "0.00"
		Me.lblB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblB.Size = New System.Drawing.Size(234, 21)
		Me.lblB.Location = New System.Drawing.Point(215, 43)
		Me.lblB.TabIndex = 27
		Me.lblB.Enabled = True
		Me.lblB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblB.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblB.UseMnemonic = True
		Me.lblB.Visible = True
		Me.lblB.AutoSize = False
		Me.lblB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblB.Name = "lblB"
		Me.lblC.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblC.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblC.Text = "0.00"
		Me.lblC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblC.Size = New System.Drawing.Size(233, 16)
		Me.lblC.Location = New System.Drawing.Point(215, 112)
		Me.lblC.TabIndex = 26
		Me.lblC.Visible = False
		Me.lblC.Enabled = True
		Me.lblC.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblC.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblC.UseMnemonic = True
		Me.lblC.AutoSize = False
		Me.lblC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblC.Name = "lblC"
		Me._lblTotal_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_0.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_0.Text = "Person Cutting :"
		Me._lblTotal_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_0.Size = New System.Drawing.Size(203, 21)
		Me._lblTotal_0.Location = New System.Drawing.Point(0, 20)
		Me._lblTotal_0.TabIndex = 25
		Me._lblTotal_0.Enabled = True
		Me._lblTotal_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_0.UseMnemonic = True
		Me._lblTotal_0.Visible = True
		Me._lblTotal_0.AutoSize = False
		Me._lblTotal_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_0.Name = "_lblTotal_0"
		Me._lblTotal_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_1.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_1.Text = "Price Per Kg :"
		Me._lblTotal_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_1.Size = New System.Drawing.Size(203, 16)
		Me._lblTotal_1.Location = New System.Drawing.Point(2, 38)
		Me._lblTotal_1.TabIndex = 24
		Me._lblTotal_1.Visible = False
		Me._lblTotal_1.Enabled = True
		Me._lblTotal_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_1.UseMnemonic = True
		Me._lblTotal_1.AutoSize = False
		Me._lblTotal_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_1.Name = "_lblTotal_1"
		Me._lblTotal_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_2.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_2.Text = "Total Weight Purchased :"
		Me._lblTotal_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_2.Size = New System.Drawing.Size(203, 16)
		Me._lblTotal_2.Location = New System.Drawing.Point(2, 56)
		Me._lblTotal_2.TabIndex = 23
		Me._lblTotal_2.Visible = False
		Me._lblTotal_2.Enabled = True
		Me._lblTotal_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_2.UseMnemonic = True
		Me._lblTotal_2.AutoSize = False
		Me._lblTotal_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_2.Name = "_lblTotal_2"
		Me._lblTotal_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_3.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_3.Text = "Total Weight Used :"
		Me._lblTotal_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_3.Size = New System.Drawing.Size(203, 16)
		Me._lblTotal_3.Location = New System.Drawing.Point(2, 74)
		Me._lblTotal_3.TabIndex = 22
		Me._lblTotal_3.Visible = False
		Me._lblTotal_3.Enabled = True
		Me._lblTotal_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_3.UseMnemonic = True
		Me._lblTotal_3.AutoSize = False
		Me._lblTotal_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_3.Name = "_lblTotal_3"
		Me._lblTotal_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_4.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_4.Text = "Total Bag Available :"
		Me._lblTotal_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_4.Size = New System.Drawing.Size(203, 21)
		Me._lblTotal_4.Location = New System.Drawing.Point(2, 43)
		Me._lblTotal_4.TabIndex = 21
		Me._lblTotal_4.Enabled = True
		Me._lblTotal_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_4.UseMnemonic = True
		Me._lblTotal_4.Visible = True
		Me._lblTotal_4.AutoSize = False
		Me._lblTotal_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_4.Name = "_lblTotal_4"
		Me._lblTotal_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_5.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_5.Text = "Total Used :"
		Me._lblTotal_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_5.Size = New System.Drawing.Size(203, 21)
		Me._lblTotal_5.Location = New System.Drawing.Point(2, 66)
		Me._lblTotal_5.TabIndex = 20
		Me._lblTotal_5.Enabled = True
		Me._lblTotal_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_5.UseMnemonic = True
		Me._lblTotal_5.Visible = True
		Me._lblTotal_5.AutoSize = False
		Me._lblTotal_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_5.Name = "_lblTotal_5"
		Me.lblX.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblX.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me.lblX.Text = "0.00"
		Me.lblX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblX.Size = New System.Drawing.Size(120, 16)
		Me.lblX.Location = New System.Drawing.Point(616, 110)
		Me.lblX.TabIndex = 19
		Me.lblX.Visible = False
		Me.lblX.Enabled = True
		Me.lblX.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblX.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblX.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblX.UseMnemonic = True
		Me.lblX.AutoSize = False
		Me.lblX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblX.Name = "lblX"
		Me.lblGP_Y.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblGP_Y.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblGP_Y.Text = "0.00"
		Me.lblGP_Y.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblGP_Y.Size = New System.Drawing.Size(120, 21)
		Me.lblGP_Y.Location = New System.Drawing.Point(616, 43)
		Me.lblGP_Y.TabIndex = 18
		Me.lblGP_Y.Enabled = True
		Me.lblGP_Y.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGP_Y.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGP_Y.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGP_Y.UseMnemonic = True
		Me.lblGP_Y.Visible = True
		Me.lblGP_Y.AutoSize = False
		Me.lblGP_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblGP_Y.Name = "lblGP_Y"
		Me.lblB_Z.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblB_Z.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.lblB_Z.Text = "0.00"
		Me.lblB_Z.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblB_Z.Size = New System.Drawing.Size(120, 21)
		Me.lblB_Z.Location = New System.Drawing.Point(616, 66)
		Me.lblB_Z.TabIndex = 17
		Me.lblB_Z.Enabled = True
		Me.lblB_Z.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblB_Z.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblB_Z.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblB_Z.UseMnemonic = True
		Me.lblB_Z.Visible = True
		Me.lblB_Z.AutoSize = False
		Me.lblB_Z.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblB_Z.Name = "lblB_Z"
		Me._lblTotal_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_6.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_6.Text = "X - VAT+1 :"
		Me._lblTotal_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_6.Size = New System.Drawing.Size(133, 16)
		Me._lblTotal_6.Location = New System.Drawing.Point(472, 110)
		Me._lblTotal_6.TabIndex = 16
		Me._lblTotal_6.Visible = False
		Me._lblTotal_6.Enabled = True
		Me._lblTotal_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_6.UseMnemonic = True
		Me._lblTotal_6.AutoSize = False
		Me._lblTotal_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_6.Name = "_lblTotal_6"
		Me._lblTotal_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_7.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_7.Text = "VAT :"
		Me._lblTotal_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_7.Size = New System.Drawing.Size(133, 16)
		Me._lblTotal_7.Location = New System.Drawing.Point(472, 92)
		Me._lblTotal_7.TabIndex = 15
		Me._lblTotal_7.Visible = False
		Me._lblTotal_7.Enabled = True
		Me._lblTotal_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_7.UseMnemonic = True
		Me._lblTotal_7.AutoSize = False
		Me._lblTotal_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_7.Name = "_lblTotal_7"
		Me._lblTotal_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_8.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_8.Text = "Total Selling Price :"
		Me._lblTotal_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_8.Size = New System.Drawing.Size(133, 21)
		Me._lblTotal_8.Location = New System.Drawing.Point(472, 43)
		Me._lblTotal_8.TabIndex = 14
		Me._lblTotal_8.Enabled = True
		Me._lblTotal_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_8.UseMnemonic = True
		Me._lblTotal_8.Visible = True
		Me._lblTotal_8.AutoSize = False
		Me._lblTotal_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_8.Name = "_lblTotal_8"
		Me._lblTotal_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_9.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_9.Text = "Total Cost :"
		Me._lblTotal_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_9.Size = New System.Drawing.Size(133, 21)
		Me._lblTotal_9.Location = New System.Drawing.Point(472, 20)
		Me._lblTotal_9.TabIndex = 13
		Me._lblTotal_9.Enabled = True
		Me._lblTotal_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_9.UseMnemonic = True
		Me._lblTotal_9.Visible = True
		Me._lblTotal_9.AutoSize = False
		Me._lblTotal_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_9.Name = "_lblTotal_9"
		Me._lblTotal_10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblTotal_10.BackColor = System.Drawing.Color.Transparent
		Me._lblTotal_10.Text = "Total GP :"
		Me._lblTotal_10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lblTotal_10.Size = New System.Drawing.Size(133, 21)
		Me._lblTotal_10.Location = New System.Drawing.Point(472, 66)
		Me._lblTotal_10.TabIndex = 12
		Me._lblTotal_10.Enabled = True
		Me._lblTotal_10.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblTotal_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblTotal_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblTotal_10.UseMnemonic = True
		Me._lblTotal_10.Visible = True
		Me._lblTotal_10.AutoSize = False
		Me._lblTotal_10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblTotal_10.Name = "_lblTotal_10"
		Me._txtEdit_1.AutoSize = False
		Me._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_1.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_1.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_1.Location = New System.Drawing.Point(350, 583)
		Me._txtEdit_1.Maxlength = 10
		Me._txtEdit_1.TabIndex = 9
		Me._txtEdit_1.Tag = "0"
		Me._txtEdit_1.Text = "0"
		Me._txtEdit_1.Visible = False
		Me._txtEdit_1.AcceptsReturn = True
		Me._txtEdit_1.CausesValidation = True
		Me._txtEdit_1.Enabled = True
		Me._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_1.HideSelection = True
		Me._txtEdit_1.ReadOnly = False
		Me._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_1.MultiLine = False
		Me._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_1.TabStop = True
		Me._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_1.Name = "_txtEdit_1"
		Me._txtEdit_2.AutoSize = False
		Me._txtEdit_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtEdit_2.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._txtEdit_2.Size = New System.Drawing.Size(55, 16)
		Me._txtEdit_2.Location = New System.Drawing.Point(422, 583)
		Me._txtEdit_2.Maxlength = 10
		Me._txtEdit_2.TabIndex = 8
		Me._txtEdit_2.Tag = "0"
		Me._txtEdit_2.Text = "0"
		Me._txtEdit_2.Visible = False
		Me._txtEdit_2.AcceptsReturn = True
		Me._txtEdit_2.CausesValidation = True
		Me._txtEdit_2.Enabled = True
		Me._txtEdit_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtEdit_2.HideSelection = True
		Me._txtEdit_2.ReadOnly = False
		Me._txtEdit_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtEdit_2.MultiLine = False
		Me._txtEdit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtEdit_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtEdit_2.TabStop = True
		Me._txtEdit_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._txtEdit_2.Name = "_txtEdit_2"
		Me.Picture2.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture2.BackColor = System.Drawing.Color.Blue
		Me.Picture2.Size = New System.Drawing.Size(1016, 49)
		Me.Picture2.Location = New System.Drawing.Point(0, 0)
		Me.Picture2.TabIndex = 5
		Me.Picture2.TabStop = False
		Me.Picture2.CausesValidation = True
		Me.Picture2.Enabled = True
		Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture2.Visible = True
		Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture2.Name = "Picture2"
		Me.cmdReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReg.Text = "&Register 4VEG"
		Me.cmdReg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdReg.Size = New System.Drawing.Size(115, 40)
		Me.cmdReg.Location = New System.Drawing.Point(448, 3)
		Me.cmdReg.TabIndex = 55
		Me.cmdReg.TabStop = False
		Me.cmdReg.Visible = False
		Me.cmdReg.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReg.CausesValidation = True
		Me.cmdReg.Enabled = True
		Me.cmdReg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReg.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReg.Name = "cmdReg"
		Me.cmdProc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProc.Text = "&Process"
		Me.cmdProc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdProc.Size = New System.Drawing.Size(67, 40)
		Me.cmdProc.Location = New System.Drawing.Point(168, 3)
		Me.cmdProc.TabIndex = 52
		Me.cmdProc.TabStop = False
		Me.cmdProc.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProc.CausesValidation = True
		Me.cmdProc.Enabled = True
		Me.cmdProc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProc.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProc.Name = "cmdProc"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "P&rint"
		Me.cmdPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPrint.Size = New System.Drawing.Size(67, 40)
		Me.cmdPrint.Location = New System.Drawing.Point(88, 3)
		Me.cmdPrint.TabIndex = 7
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(67, 40)
		Me.cmdExit.Location = New System.Drawing.Point(7, 3)
		Me.cmdExit.TabIndex = 6
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
        'gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridItem.Size = New System.Drawing.Size(901, 359)
		Me.gridItem.Location = New System.Drawing.Point(3, 200)
		Me.gridItem.TabIndex = 4
		Me.gridItem.Name = "gridItem"
		Me.Controls.Add(AvailGRV)
		Me.Controls.Add(picTotal)
		Me.Controls.Add(_txtEdit_0)
		Me.Controls.Add(frmTotals)
		Me.Controls.Add(_txtEdit_1)
		Me.Controls.Add(_txtEdit_2)
		Me.Controls.Add(Picture2)
		Me.Controls.Add(gridItem)
		Me.picTotal.Controls.Add(lblTotalOP)
		Me.picTotal.Controls.Add(lblTotalLP)
		Me.picTotal.Controls.Add(lblTotalO)
		Me.picTotal.Controls.Add(_lblTotal_17)
		Me.picTotal.Controls.Add(lblTotalL)
		Me.picTotal.Controls.Add(_lblTotal_16)
		Me.picTotal.Controls.Add(lblTotalH)
		Me.picTotal.Controls.Add(_lblTotal_15)
		Me.picTotal.Controls.Add(lblTotalG)
		Me.picTotal.Controls.Add(_lblTotal_14)
		Me.picTotal.Controls.Add(_lblTotal_13)
		Me.picTotal.Controls.Add(lblTotalQ)
		Me.picTotal.Controls.Add(_lblTotal_12)
		Me.picTotal.Controls.Add(lblTotalF)
		Me.picTotal.Controls.Add(lblP)
		Me.picTotal.Controls.Add(_lblTotal_11)
		Me.frmTotals.Controls.Add(TotalQTY)
		Me.frmTotals.Controls.Add(TotalQTYd)
		Me.frmTotals.Controls.Add(txtR)
		Me.frmTotals.Controls.Add(txtZ)
		Me.frmTotals.Controls.Add(cmdTotal)
		Me.frmTotals.Controls.Add(txtReqGP)
		Me.frmTotals.Controls.Add(txtVAT)
		Me.frmTotals.Controls.Add(lblQuantity)
		Me.frmTotals.Controls.Add(_lbl_8)
		Me.frmTotals.Controls.Add(lblBrokenPack)
		Me.frmTotals.Controls.Add(_lbl_2)
		Me.frmTotals.Controls.Add(lblContentExclusive)
		Me.frmTotals.Controls.Add(lblContentInclusives)
		Me.frmTotals.Controls.Add(lblDepositExclusives)
		Me.frmTotals.Controls.Add(lblA)
		Me.frmTotals.Controls.Add(lblB)
		Me.frmTotals.Controls.Add(lblC)
		Me.frmTotals.Controls.Add(_lblTotal_0)
		Me.frmTotals.Controls.Add(_lblTotal_1)
		Me.frmTotals.Controls.Add(_lblTotal_2)
		Me.frmTotals.Controls.Add(_lblTotal_3)
		Me.frmTotals.Controls.Add(_lblTotal_4)
		Me.frmTotals.Controls.Add(_lblTotal_5)
		Me.frmTotals.Controls.Add(lblX)
		Me.frmTotals.Controls.Add(lblGP_Y)
		Me.frmTotals.Controls.Add(lblB_Z)
		Me.frmTotals.Controls.Add(_lblTotal_6)
		Me.frmTotals.Controls.Add(_lblTotal_7)
		Me.frmTotals.Controls.Add(_lblTotal_8)
		Me.frmTotals.Controls.Add(_lblTotal_9)
		Me.frmTotals.Controls.Add(_lblTotal_10)
		Me.Picture2.Controls.Add(cmdReg)
		Me.Picture2.Controls.Add(cmdProc)
		Me.Picture2.Controls.Add(cmdPrint)
		Me.Picture2.Controls.Add(cmdExit)
        'Me.lbl.SetIndex(_lbl_8, CType(8, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'Me.lblTotal.SetIndex(_lblTotal_17, CType(17, Short))
        'Me.lblTotal.SetIndex(_lblTotal_16, CType(16, Short))
        'Me.lblTotal.SetIndex(_lblTotal_15, CType(15, Short))
        'Me.lblTotal.SetIndex(_lblTotal_14, CType(14, Short))
        'Me.lblTotal.SetIndex(_lblTotal_13, CType(13, Short))
        'Me.lblTotal.SetIndex(_lblTotal_12, CType(12, Short))
        'Me.lblTotal.SetIndex(_lblTotal_11, CType(11, Short))
        'Me.lblTotal.SetIndex(_lblTotal_0, CType(0, Short))
        'Me.lblTotal.SetIndex(_lblTotal_1, CType(1, Short))
        'Me.lblTotal.SetIndex(_lblTotal_2, CType(2, Short))
        'Me.lblTotal.SetIndex(_lblTotal_3, CType(3, Short))
        'Me.lblTotal.SetIndex(_lblTotal_4, CType(4, Short))
        'Me.lblTotal.SetIndex(_lblTotal_5, CType(5, Short))
        'Me.lblTotal.SetIndex(_lblTotal_6, CType(6, Short))
        'Me.lblTotal.SetIndex(_lblTotal_7, CType(7, Short))
        'Me.lblTotal.SetIndex(_lblTotal_8, CType(8, Short))
        'Me.lblTotal.SetIndex(_lblTotal_9, CType(9, Short))
        'Me.lblTotal.SetIndex(_lblTotal_10, CType(10, Short))
        'Me.txtEdit.SetIndex(_txtEdit_0, CType(0, Short))
        'Me.txtEdit.SetIndex(_txtEdit_1, CType(1, Short))
        'Me.txtEdit.SetIndex(_txtEdit_2, CType(2, Short))
        'CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.gridItem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picTotal.ResumeLayout(False)
		Me.frmTotals.ResumeLayout(False)
		Me.Picture2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class