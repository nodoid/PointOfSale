<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportUt
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
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public cmdlgOpen As System.Windows.Forms.OpenFileDialog
	Public cmdlgSave As System.Windows.Forms.SaveFileDialog
	Public cmdlgFont As System.Windows.Forms.FontDialog
	Public cmdlgColor As System.Windows.Forms.ColorDialog
	Public cmdlgPrint As System.Windows.Forms.PrintDialog
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents cmdBrowse As System.Windows.Forms.Button
	Public WithEvents cmdExportNow As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cmdlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.cmdlgFont = New System.Windows.Forms.FontDialog()
        Me.cmdlgColor = New System.Windows.Forms.ColorDialog()
        Me.cmdlgPrint = New System.Windows.Forms.PrintDialog()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.cmdExportNow = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdBrowse
        '
        Me.cmdBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBrowse.Location = New System.Drawing.Point(390, 48)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBrowse.Size = New System.Drawing.Size(43, 17)
        Me.cmdBrowse.TabIndex = 1
        Me.cmdBrowse.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdBrowse, "Browse file ")
        Me.cmdBrowse.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(360, 4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(73, 27)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(437, 38)
        Me.picButtons.TabIndex = 4
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(576, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Enabled = False
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(66, 46)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.ReadOnly = True
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(317, 19)
        Me.Text1.TabIndex = 2
        '
        'cmdExportNow
        '
        Me.cmdExportNow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportNow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExportNow.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportNow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportNow.Location = New System.Drawing.Point(318, 72)
        Me.cmdExportNow.Name = "cmdExportNow"
        Me.cmdExportNow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExportNow.Size = New System.Drawing.Size(113, 27)
        Me.cmdExportNow.TabIndex = 0
        Me.cmdExportNow.Text = "Export &Now!"
        Me.cmdExportNow.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(4, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File Path:"
        '
        'frmExportUt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(437, 106)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdExportNow)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportUt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Export Utilities"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class