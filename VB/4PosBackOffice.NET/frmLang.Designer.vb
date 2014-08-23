<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLang
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
	Public WithEvents txtName As System.Windows.Forms.TextBox
	Public WithEvents Option3 As System.Windows.Forms.RadioButton
	Public WithEvents Option2 As System.Windows.Forms.RadioButton
	Public WithEvents Option1 As System.Windows.Forms.RadioButton
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents gridEdit As myDataGridView
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLang))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtName = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Option3 = New System.Windows.Forms.RadioButton
		Me.Option2 = New System.Windows.Forms.RadioButton
		Me.Option1 = New System.Windows.Forms.RadioButton
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.gridEdit = New myDataGridView
		Me.Label1 = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.gridEdit, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Language Translation Editor"
		Me.ClientSize = New System.Drawing.Size(963, 663)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmLang"
		Me.txtName.AutoSize = False
		Me.txtName.Size = New System.Drawing.Size(301, 24)
		Me.txtName.Location = New System.Drawing.Point(125, 48)
		Me.txtName.TabIndex = 4
		Me.txtName.Text = "Text1"
		Me.txtName.AcceptsReturn = True
		Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtName.BackColor = System.Drawing.SystemColors.Window
		Me.txtName.CausesValidation = True
		Me.txtName.Enabled = True
		Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtName.HideSelection = True
		Me.txtName.ReadOnly = False
		Me.txtName.Maxlength = 0
		Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtName.MultiLine = False
		Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtName.TabStop = True
		Me.txtName.Visible = True
		Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtName.Name = "txtName"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(963, 44)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 1
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picButtons.Name = "picButtons"
		Me.Option3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Option3.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Option3.Text = "Touch Screen"
		Me.Option3.Size = New System.Drawing.Size(129, 29)
		Me.Option3.Location = New System.Drawing.Point(448, 6)
		Me.Option3.Appearance = System.Windows.Forms.Appearance.Button
		Me.Option3.TabIndex = 9
		Me.Option3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option3.CausesValidation = True
		Me.Option3.Enabled = True
		Me.Option3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option3.TabStop = True
		Me.Option3.Checked = False
		Me.Option3.Visible = True
		Me.Option3.Name = "Option3"
		Me.Option2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Option2.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Option2.Text = "Point of Sale"
		Me.Option2.Size = New System.Drawing.Size(129, 29)
		Me.Option2.Location = New System.Drawing.Point(312, 6)
		Me.Option2.Appearance = System.Windows.Forms.Appearance.Button
		Me.Option2.TabIndex = 8
		Me.Option2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option2.CausesValidation = True
		Me.Option2.Enabled = True
		Me.Option2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option2.TabStop = True
		Me.Option2.Checked = False
		Me.Option2.Visible = True
		Me.Option2.Name = "Option2"
		Me.Option1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Option1.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Option1.Text = "Back Office"
		Me.Option1.Size = New System.Drawing.Size(129, 29)
		Me.Option1.Location = New System.Drawing.Point(176, 6)
		Me.Option1.Appearance = System.Windows.Forms.Appearance.Button
		Me.Option1.TabIndex = 7
		Me.Option1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option1.CausesValidation = True
		Me.Option1.Enabled = True
		Me.Option1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1.TabStop = True
		Me.Option1.Checked = False
		Me.Option1.Visible = True
		Me.Option1.Name = "Option1"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(880, 6)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(798, 6)
		Me.cmdPrint.TabIndex = 2
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.Visible = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.Label2.Text = "Show Translations for :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(158, 21)
		Me.Label2.Location = New System.Drawing.Point(16, 14)
		Me.Label2.TabIndex = 6
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
        'gridEdit.OcxState = CType(resources.GetObject("gridEdit.OcxState"), System.Windows.Forms.AxHost.State)
		Me.gridEdit.Size = New System.Drawing.Size(947, 582)
		Me.gridEdit.Location = New System.Drawing.Point(9, 75)
		Me.gridEdit.TabIndex = 0
		Me.gridEdit.Name = "gridEdit"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Lanuage Name:"
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Size = New System.Drawing.Size(110, 16)
		Me.Label1.Location = New System.Drawing.Point(13, 51)
		Me.Label1.TabIndex = 5
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(txtName)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(gridEdit)
		Me.Controls.Add(Label1)
		Me.picButtons.Controls.Add(Option3)
		Me.picButtons.Controls.Add(Option2)
		Me.picButtons.Controls.Add(Option1)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(Label2)
		CType(Me.gridEdit, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class