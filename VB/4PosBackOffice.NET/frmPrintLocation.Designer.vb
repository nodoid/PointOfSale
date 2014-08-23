<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPrintLocation
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
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents lstPrinter As System.Windows.Forms.CheckedListBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrintLocation))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtName = New System.Windows.Forms.TextBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.lstPrinter = New System.Windows.Forms.CheckedListBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select a Printers for the Print Location"
		Me.ClientSize = New System.Drawing.Size(316, 376)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
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
		Me.Name = "frmPrintLocation"
		Me.txtName.AutoSize = False
		Me.txtName.Size = New System.Drawing.Size(190, 19)
		Me.txtName.Location = New System.Drawing.Point(114, 6)
		Me.txtName.TabIndex = 3
		Me.txtName.Text = "[New Print Location]"
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
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(9, 204)
		Me.cmdExit.TabIndex = 2
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Save"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(97, 52)
		Me.cmdNext.Location = New System.Drawing.Point(207, 204)
		Me.cmdNext.TabIndex = 1
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.lstPrinter.Size = New System.Drawing.Size(295, 154)
		Me.lstPrinter.Location = New System.Drawing.Point(9, 33)
		Me.lstPrinter.TabIndex = 0
		Me.lstPrinter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPrinter.BackColor = System.Drawing.SystemColors.Window
		Me.lstPrinter.CausesValidation = True
		Me.lstPrinter.Enabled = True
		Me.lstPrinter.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPrinter.IntegralHeight = True
		Me.lstPrinter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPrinter.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPrinter.Sorted = False
		Me.lstPrinter.TabStop = True
		Me.lstPrinter.Visible = True
		Me.lstPrinter.MultiColumn = False
		Me.lstPrinter.Name = "lstPrinter"
		Me.Label3.Text = "For Example:"
		Me.Label3.Size = New System.Drawing.Size(100, 13)
		Me.Label3.Location = New System.Drawing.Point(8, 304)
		Me.Label3.TabIndex = 10
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label7.Text = "Incorrect :"
		Me.Label7.ForeColor = System.Drawing.Color.Red
		Me.Label7.Size = New System.Drawing.Size(60, 13)
		Me.Label7.Location = New System.Drawing.Point(80, 352)
		Me.Label7.TabIndex = 9
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label6.Text = "Correct :"
		Me.Label6.Size = New System.Drawing.Size(60, 13)
		Me.Label6.Location = New System.Drawing.Point(80, 328)
		Me.Label6.TabIndex = 8
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "My Favorite Printer"
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Size = New System.Drawing.Size(233, 29)
		Me.Label5.Location = New System.Drawing.Point(144, 352)
		Me.Label5.TabIndex = 7
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "MyFavoritePrinter"
		Me.Label4.Size = New System.Drawing.Size(233, 29)
		Me.Label4.Location = New System.Drawing.Point(144, 328)
		Me.Label4.TabIndex = 6
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.Label2.Text = "Please note : This list will not show a printer, if the name of that printer has SPACE in it."
		Me.Label2.ForeColor = System.Drawing.Color.Red
		Me.Label2.Size = New System.Drawing.Size(296, 37)
		Me.Label2.Location = New System.Drawing.Point(8, 272)
		Me.Label2.TabIndex = 5
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Print Location Name:"
		Me.Label1.Size = New System.Drawing.Size(99, 13)
		Me.Label1.Location = New System.Drawing.Point(6, 9)
		Me.Label1.TabIndex = 4
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(txtName)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(lstPrinter)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class