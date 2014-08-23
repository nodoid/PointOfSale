<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVblind
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
	Public WithEvents cmdProceed As System.Windows.Forms.Button
	Public WithEvents lblData As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblRepNumber As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents lblRepName As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblName As System.Windows.Forms.Label
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents ilHeading As System.Windows.Forms.ImageList
	Public WithEvents lstSupplier As System.Windows.Forms.ListBox
	Public WithEvents _frmMode_0 As System.Windows.Forms.GroupBox
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVblind))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me._frmMode_1 = New System.Windows.Forms.GroupBox
		Me.cmdProceed = New System.Windows.Forms.Button
		Me.lblData = New System.Windows.Forms.Label
		Me._lbl_4 = New System.Windows.Forms.Label
		Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.lblRepNumber = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lblRepName = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblName = New System.Windows.Forms.Label
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.ilHeading = New System.Windows.Forms.ImageList
		Me._frmMode_0 = New System.Windows.Forms.GroupBox
		Me.lstSupplier = New System.Windows.Forms.ListBox
		Me.Label1 = New System.Windows.Forms.Label
        'Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me._frmMode_1.SuspendLayout()
		Me._frmMode_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ControlBox = False
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(377, 434)
		Me.Location = New System.Drawing.Point(3, 3)
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
		Me.Name = "frmGRVblind"
		Me._frmMode_1.Text = "Supplier Details"
		Me._frmMode_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmMode_1.Size = New System.Drawing.Size(352, 349)
		Me._frmMode_1.Location = New System.Drawing.Point(12, 39)
		Me._frmMode_1.TabIndex = 3
		Me._frmMode_1.Visible = False
		Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_1.Enabled = True
		Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_1.Name = "_frmMode_1"
		Me.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProceed.Text = "&Create Purchase Order"
		Me.cmdProceed.Size = New System.Drawing.Size(127, 28)
		Me.cmdProceed.Location = New System.Drawing.Point(216, 312)
		Me.cmdProceed.TabIndex = 12
		Me.cmdProceed.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProceed.CausesValidation = True
		Me.cmdProceed.Enabled = True
		Me.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProceed.TabStop = True
		Me.cmdProceed.Name = "cmdProceed"
		Me.lblData.Text = "By clicking the ""Create Purchase Order"" button, you will create a blank purchase order for the above supplier. You will then be prompted for the invoice details and proceed to the GRV product capture screen."
		Me.lblData.Size = New System.Drawing.Size(334, 151)
		Me.lblData.Location = New System.Drawing.Point(3, 120)
		Me.lblData.TabIndex = 11
		Me.lblData.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblData.BackColor = System.Drawing.SystemColors.Control
		Me.lblData.Enabled = True
		Me.lblData.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblData.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblData.UseMnemonic = True
		Me.lblData.Visible = True
		Me.lblData.AutoSize = False
		Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblData.Name = "lblData"
		Me._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._lbl_4.BackColor = System.Drawing.Color.Blue
		Me._lbl_4.Text = "Create New Purchase Order"
		Me._lbl_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_4.ForeColor = System.Drawing.Color.White
		Me._lbl_4.Size = New System.Drawing.Size(347, 17)
		Me._lbl_4.Location = New System.Drawing.Point(3, 93)
		Me._lbl_4.TabIndex = 10
		Me._lbl_4.Enabled = True
		Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_4.UseMnemonic = True
		Me._lbl_4.Visible = True
		Me._lbl_4.AutoSize = False
		Me._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lbl_4.Name = "_lbl_4"
		Me.Line1.X1 = 342
		Me.Line1.X2 = 12
		Me.Line1.Y1 = 74
		Me.Line1.Y2 = 74
		Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line1.BorderWidth = 1
		Me.Line1.Visible = True
		Me.Line1.Name = "Line1"
		Me.lblRepNumber.BackColor = System.Drawing.SystemColors.Window
		Me.lblRepNumber.Text = "lblRepNumber"
		Me.lblRepNumber.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblRepNumber.Size = New System.Drawing.Size(91, 16)
		Me.lblRepNumber.Location = New System.Drawing.Point(252, 63)
		Me.lblRepNumber.TabIndex = 9
		Me.lblRepNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRepNumber.Enabled = True
		Me.lblRepNumber.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRepNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRepNumber.UseMnemonic = True
		Me.lblRepNumber.Visible = True
		Me.lblRepNumber.AutoSize = False
		Me.lblRepNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRepNumber.Name = "lblRepNumber"
		Me._lbl_1.Text = "Representative Name"
		Me._lbl_1.Size = New System.Drawing.Size(103, 13)
		Me._lbl_1.Location = New System.Drawing.Point(12, 51)
		Me._lbl_1.TabIndex = 8
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
		Me.lblRepName.BackColor = System.Drawing.SystemColors.Window
		Me.lblRepName.Text = "lblRepName"
		Me.lblRepName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblRepName.Size = New System.Drawing.Size(238, 16)
		Me.lblRepName.Location = New System.Drawing.Point(12, 63)
		Me.lblRepName.TabIndex = 7
		Me.lblRepName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRepName.Enabled = True
		Me.lblRepName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRepName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRepName.UseMnemonic = True
		Me.lblRepName.Visible = True
		Me.lblRepName.AutoSize = False
		Me.lblRepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRepName.Name = "lblRepName"
		Me._lbl_0.Text = "Supplier Name"
		Me._lbl_0.Size = New System.Drawing.Size(69, 13)
		Me._lbl_0.Location = New System.Drawing.Point(12, 15)
		Me._lbl_0.TabIndex = 6
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
		Me.lblName.BackColor = System.Drawing.SystemColors.Window
		Me.lblName.Text = "lblName"
		Me.lblName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblName.Size = New System.Drawing.Size(268, 16)
		Me.lblName.Location = New System.Drawing.Point(12, 27)
		Me.lblName.TabIndex = 5
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblName.Enabled = True
		Me.lblName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblName.UseMnemonic = True
		Me.lblName.Visible = True
		Me.lblName.AutoSize = False
		Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblName.Name = "lblName"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next >>"
		Me.cmdNext.Enabled = False
		Me.cmdNext.Size = New System.Drawing.Size(84, 25)
		Me.cmdNext.Location = New System.Drawing.Point(270, 396)
		Me.cmdNext.TabIndex = 1
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "&New Supplier"
		Me.cmdBack.Size = New System.Drawing.Size(85, 25)
		Me.cmdBack.Location = New System.Drawing.Point(18, 396)
		Me.cmdBack.TabIndex = 2
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.TabStop = True
		Me.cmdBack.Name = "cmdBack"
		Me.ilHeading.ImageSize = New System.Drawing.Size(32, 32)
		Me.ilHeading.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.ilHeading.Images.SetKeyName(0, "")
		Me.ilHeading.Images.SetKeyName(1, "")
		Me.ilHeading.Images.SetKeyName(2, "")
		Me._frmMode_0.Text = "Select a supplier"
		Me._frmMode_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmMode_0.Size = New System.Drawing.Size(352, 349)
		Me._frmMode_0.Location = New System.Drawing.Point(12, 39)
		Me._frmMode_0.TabIndex = 4
		Me._frmMode_0.Visible = False
		Me._frmMode_0.BackColor = System.Drawing.SystemColors.Control
		Me._frmMode_0.Enabled = True
		Me._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmMode_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmMode_0.Name = "_frmMode_0"
		Me.lstSupplier.Size = New System.Drawing.Size(328, 319)
		Me.lstSupplier.Location = New System.Drawing.Point(12, 18)
		Me.lstSupplier.TabIndex = 0
		Me.lstSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstSupplier.BackColor = System.Drawing.SystemColors.Window
		Me.lstSupplier.CausesValidation = True
		Me.lstSupplier.Enabled = True
		Me.lstSupplier.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstSupplier.IntegralHeight = True
		Me.lstSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstSupplier.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstSupplier.Sorted = False
		Me.lstSupplier.TabStop = True
		Me.lstSupplier.Visible = True
		Me.lstSupplier.MultiColumn = False
		Me.lstSupplier.Name = "lstSupplier"
		Me.Label1.Text = "This utility will create a blank ""Purchase Order"" so you can process a ""Goods Receiving Voucher"" for a supplier without creating an order first."
		Me.Label1.Size = New System.Drawing.Size(352, 31)
		Me.Label1.Location = New System.Drawing.Point(12, 3)
		Me.Label1.TabIndex = 13
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(_frmMode_1)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdBack)
		Me.Controls.Add(_frmMode_0)
		Me.Controls.Add(Label1)
		Me._frmMode_1.Controls.Add(cmdProceed)
		Me._frmMode_1.Controls.Add(lblData)
		Me._frmMode_1.Controls.Add(_lbl_4)
		Me.ShapeContainer1.Shapes.Add(Line1)
		Me._frmMode_1.Controls.Add(lblRepNumber)
		Me._frmMode_1.Controls.Add(_lbl_1)
		Me._frmMode_1.Controls.Add(lblRepName)
		Me._frmMode_1.Controls.Add(_lbl_0)
		Me._frmMode_1.Controls.Add(lblName)
		Me._frmMode_1.Controls.Add(ShapeContainer1)
        Me._frmMode_0.Controls.Add(lstSupplier)
        Me._frmMode_0.TabIndex = 0
        Me._frmMode_1.TabIndex = 1
        Me._lbl_0.TabIndex = 0
        Me._lbl_1.TabIndex = 1
        Me._lbl_4.TabIndex = 4
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmMode_1.ResumeLayout(False)
		Me._frmMode_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class