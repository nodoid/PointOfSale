<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPrinter
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
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents lstPrinter As System.Windows.Forms.ListBox
	Public WithEvents Label3 As System.Windows.Forms.Label
    'Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrinter))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me._optType_0 = New System.Windows.Forms.RadioButton
		Me._optType_3 = New System.Windows.Forms.RadioButton
		Me._optType_2 = New System.Windows.Forms.RadioButton
		Me._optType_1 = New System.Windows.Forms.RadioButton
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.lstPrinter = New System.Windows.Forms.ListBox
		Me.Label3 = New System.Windows.Forms.Label
        'Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select a Printer"
		Me.ClientSize = New System.Drawing.Size(316, 316)
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
		Me.Name = "frmPrinter"
		Me.Frame1.Text = "NOTE: Please select your printer type before clicking 'Next'"
		Me.Frame1.ForeColor = System.Drawing.Color.Blue
		Me.Frame1.Size = New System.Drawing.Size(295, 49)
		Me.Frame1.Location = New System.Drawing.Point(8, 192)
		Me.Frame1.TabIndex = 4
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.Text = "no spec"
		Me._optType_0.Size = New System.Drawing.Size(97, 17)
		Me._optType_0.Location = New System.Drawing.Point(184, 48)
		Me._optType_0.TabIndex = 8
		Me._optType_0.Visible = False
		Me._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.BackColor = System.Drawing.SystemColors.Control
		Me._optType_0.CausesValidation = True
		Me._optType_0.Enabled = True
		Me._optType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_0.TabStop = True
		Me._optType_0.Checked = False
		Me._optType_0.Name = "_optType_0"
		Me._optType_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_3.Text = "Other barcode printer"
		Me._optType_3.Size = New System.Drawing.Size(121, 17)
		Me._optType_3.Location = New System.Drawing.Point(168, 24)
		Me._optType_3.TabIndex = 7
		Me._optType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_3.BackColor = System.Drawing.SystemColors.Control
		Me._optType_3.CausesValidation = True
		Me._optType_3.Enabled = True
		Me._optType_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_3.TabStop = True
		Me._optType_3.Checked = False
		Me._optType_3.Visible = True
		Me._optType_3.Name = "_optType_3"
		Me._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.Text = "Argox printer"
		Me._optType_2.Size = New System.Drawing.Size(121, 17)
		Me._optType_2.Location = New System.Drawing.Point(80, 24)
		Me._optType_2.TabIndex = 6
		Me._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.BackColor = System.Drawing.SystemColors.Control
		Me._optType_2.CausesValidation = True
		Me._optType_2.Enabled = True
		Me._optType_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_2.TabStop = True
		Me._optType_2.Checked = False
		Me._optType_2.Visible = True
		Me._optType_2.Name = "_optType_2"
		Me._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.Text = "A4 printer"
		Me._optType_1.Size = New System.Drawing.Size(97, 17)
		Me._optType_1.Location = New System.Drawing.Point(8, 24)
		Me._optType_1.TabIndex = 5
		Me._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.BackColor = System.Drawing.SystemColors.Control
		Me._optType_1.CausesValidation = True
		Me._optType_1.Enabled = True
		Me._optType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_1.TabStop = True
		Me._optType_1.Checked = False
		Me._optType_1.Visible = True
		Me._optType_1.Name = "_optType_1"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(9, 256)
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
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Size = New System.Drawing.Size(97, 52)
		Me.cmdNext.Location = New System.Drawing.Point(207, 256)
		Me.cmdNext.TabIndex = 1
		Me.cmdNext.TabStop = False
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.Name = "cmdNext"
		Me.lstPrinter.Size = New System.Drawing.Size(295, 176)
		Me.lstPrinter.Location = New System.Drawing.Point(9, 9)
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
		Me.Label3.Text = "Only printers with the word ""Label"" in the name would be regarded as true Barcode printers. All other printers would be regarded as an ""A4"" printer. If you are not sure, please rename the printer accordingly."
		Me.Label3.Size = New System.Drawing.Size(369, 49)
		Me.Label3.Location = New System.Drawing.Point(8, 328)
		Me.Label3.TabIndex = 3
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
		Me.Controls.Add(Frame1)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(lstPrinter)
		Me.Controls.Add(Label3)
		Me.Frame1.Controls.Add(_optType_0)
		Me.Frame1.Controls.Add(_optType_3)
		Me.Frame1.Controls.Add(_optType_2)
		Me.Frame1.Controls.Add(_optType_1)
        'Me.optType.SetIndex(_optType_0, CType(0, Short))
        'Me.optType.SetIndex(_optType_3, CType(3, Short))
        'Me.optType.SetIndex(_optType_2, CType(2, Short))
        'Me.optType.SetIndex(_optType_1, CType(1, Short))
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class