<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockTakeLIQ
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
	Public WithEvents tmrGetWei As System.Windows.Forms.Timer
	Public WithEvents cmdReg As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents picBC As System.Windows.Forms.PictureBox
	Public WithEvents chkPic As System.Windows.Forms.CheckBox
	Public WithEvents cmdDiff As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents cmdsearch As System.Windows.Forms.Button
	Public WithEvents txtqty As System.Windows.Forms.TextBox
	Public WithEvents txtdesc As System.Windows.Forms.TextBox
	Public WithEvents txtcode As System.Windows.Forms.TextBox
	Public WithEvents DataGrid1 As myDataGridView
	Public WithEvents imgBC As System.Windows.Forms.PictureBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockTakeLIQ))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmrGetWei = New System.Windows.Forms.Timer(components)
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.cmdReg = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.picBC = New System.Windows.Forms.PictureBox
		Me.chkPic = New System.Windows.Forms.CheckBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdDiff = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdsearch = New System.Windows.Forms.Button
		Me.txtqty = New System.Windows.Forms.TextBox
		Me.txtdesc = New System.Windows.Forms.TextBox
		Me.txtcode = New System.Windows.Forms.TextBox
		Me.DataGrid1 = New myDataGridView
		Me.imgBC = New System.Windows.Forms.PictureBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Picture1.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "StockTake"
		Me.ClientSize = New System.Drawing.Size(567, 391)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmStockTakeLIQ.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStockTakeLIQ"
		Me.tmrGetWei.Enabled = False
		Me.tmrGetWei.Interval = 100
		Me.Picture1.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture1.Size = New System.Drawing.Size(553, 153)
		Me.Picture1.Location = New System.Drawing.Point(8, 432)
		Me.Picture1.TabIndex = 13
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Picture1.Name = "Picture1"
		Me.cmdReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReg.Text = "&Register 4LIQUOR"
		Me.cmdReg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdReg.Size = New System.Drawing.Size(115, 40)
		Me.cmdReg.Location = New System.Drawing.Point(208, 88)
		Me.cmdReg.TabIndex = 15
		Me.cmdReg.TabStop = False
		Me.cmdReg.Visible = False
		Me.cmdReg.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReg.CausesValidation = True
		Me.cmdReg.Enabled = True
		Me.cmdReg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReg.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReg.Name = "cmdReg"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Size = New System.Drawing.Size(545, 73)
		Me.Label4.Location = New System.Drawing.Point(0, 8)
		Me.Label4.TabIndex = 14
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Timer1.Enabled = False
		Me.Timer1.Interval = 100
		Me.picBC.Size = New System.Drawing.Size(265, 300)
		Me.picBC.Location = New System.Drawing.Point(576, 472)
		Me.picBC.TabIndex = 11
		Me.picBC.Visible = False
		Me.picBC.Dock = System.Windows.Forms.DockStyle.None
		Me.picBC.BackColor = System.Drawing.SystemColors.Control
		Me.picBC.CausesValidation = True
		Me.picBC.Enabled = True
		Me.picBC.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picBC.Cursor = System.Windows.Forms.Cursors.Default
		Me.picBC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picBC.TabStop = True
		Me.picBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.picBC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picBC.Name = "picBC"
		Me.chkPic.Text = "Show Pictures"
		Me.chkPic.Size = New System.Drawing.Size(89, 17)
		Me.chkPic.Location = New System.Drawing.Point(472, 440)
		Me.chkPic.TabIndex = 10
		Me.chkPic.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPic.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPic.BackColor = System.Drawing.SystemColors.Control
		Me.chkPic.CausesValidation = True
		Me.chkPic.Enabled = True
		Me.chkPic.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkPic.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPic.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPic.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPic.TabStop = True
		Me.chkPic.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPic.Visible = True
		Me.chkPic.Name = "chkPic"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(567, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 7
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDiff.Text = "Show Difference"
		Me.cmdDiff.Size = New System.Drawing.Size(97, 29)
		Me.cmdDiff.Location = New System.Drawing.Point(360, 2)
		Me.cmdDiff.TabIndex = 12
		Me.cmdDiff.TabStop = False
		Me.cmdDiff.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDiff.CausesValidation = True
		Me.cmdDiff.Enabled = True
		Me.cmdDiff.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDiff.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDiff.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDiff.Name = "cmdDiff"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Save and E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(89, 29)
		Me.cmdClose.Location = New System.Drawing.Point(472, 2)
		Me.cmdClose.TabIndex = 8
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cmdsearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsearch.Text = "&Search"
		Me.AcceptButton = Me.cmdsearch
		Me.cmdsearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdsearch.Size = New System.Drawing.Size(89, 33)
		Me.cmdsearch.Location = New System.Drawing.Point(8, 352)
		Me.cmdsearch.TabIndex = 3
		Me.cmdsearch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsearch.CausesValidation = True
		Me.cmdsearch.Enabled = True
		Me.cmdsearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsearch.TabStop = True
		Me.cmdsearch.Name = "cmdsearch"
		Me.txtqty.AutoSize = False
		Me.txtqty.Size = New System.Drawing.Size(89, 25)
		Me.txtqty.Location = New System.Drawing.Point(472, 48)
		Me.txtqty.TabIndex = 2
		Me.txtqty.AcceptsReturn = True
		Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtqty.BackColor = System.Drawing.SystemColors.Window
		Me.txtqty.CausesValidation = True
		Me.txtqty.Enabled = True
		Me.txtqty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtqty.HideSelection = True
		Me.txtqty.ReadOnly = False
		Me.txtqty.Maxlength = 0
		Me.txtqty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtqty.MultiLine = False
		Me.txtqty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtqty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtqty.TabStop = True
		Me.txtqty.Visible = True
		Me.txtqty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtqty.Name = "txtqty"
		Me.txtdesc.AutoSize = False
		Me.txtdesc.Enabled = False
		Me.txtdesc.Size = New System.Drawing.Size(153, 25)
		Me.txtdesc.Location = New System.Drawing.Point(272, 48)
		Me.txtdesc.TabIndex = 1
		Me.txtdesc.AcceptsReturn = True
		Me.txtdesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtdesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtdesc.CausesValidation = True
		Me.txtdesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtdesc.HideSelection = True
		Me.txtdesc.ReadOnly = False
		Me.txtdesc.Maxlength = 0
		Me.txtdesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtdesc.MultiLine = False
		Me.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtdesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtdesc.TabStop = True
		Me.txtdesc.Visible = True
		Me.txtdesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtdesc.Name = "txtdesc"
		Me.txtcode.AutoSize = False
		Me.txtcode.Size = New System.Drawing.Size(89, 25)
		Me.txtcode.Location = New System.Drawing.Point(88, 48)
		Me.txtcode.TabIndex = 0
		Me.txtcode.AcceptsReturn = True
		Me.txtcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcode.BackColor = System.Drawing.SystemColors.Window
		Me.txtcode.CausesValidation = True
		Me.txtcode.Enabled = True
		Me.txtcode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcode.HideSelection = True
		Me.txtcode.ReadOnly = False
		Me.txtcode.Maxlength = 0
		Me.txtcode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcode.MultiLine = False
		Me.txtcode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcode.TabStop = True
		Me.txtcode.Visible = True
		Me.txtcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcode.Name = "txtcode"
        'DataGrid1.OcxState = CType(resources.GetObject("DataGrid1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataGrid1.Size = New System.Drawing.Size(553, 257)
		Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
		Me.DataGrid1.TabIndex = 9
		Me.DataGrid1.Name = "DataGrid1"
		Me.imgBC.Size = New System.Drawing.Size(265, 300)
		Me.imgBC.Location = New System.Drawing.Point(568, 48)
		Me.imgBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgBC.Visible = False
		Me.imgBC.Enabled = True
		Me.imgBC.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgBC.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgBC.Name = "imgBC"
		Me.Label3.Text = "Qty"
		Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label3.Size = New System.Drawing.Size(33, 17)
		Me.Label3.Location = New System.Drawing.Point(432, 56)
		Me.Label3.TabIndex = 6
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
		Me.Label2.Text = "Description"
		Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label2.Size = New System.Drawing.Size(81, 25)
		Me.Label2.Location = New System.Drawing.Point(184, 56)
		Me.Label2.TabIndex = 5
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Barcode"
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label1.Size = New System.Drawing.Size(81, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 56)
		Me.Label1.TabIndex = 4
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Picture1)
		Me.Controls.Add(picBC)
		Me.Controls.Add(chkPic)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(cmdsearch)
		Me.Controls.Add(txtqty)
		Me.Controls.Add(txtdesc)
		Me.Controls.Add(txtcode)
		Me.Controls.Add(DataGrid1)
		Me.Controls.Add(imgBC)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Picture1.Controls.Add(cmdReg)
		Me.Picture1.Controls.Add(Label4)
		Me.picButtons.Controls.Add(cmdDiff)
		Me.picButtons.Controls.Add(cmdClose)
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Picture1.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class