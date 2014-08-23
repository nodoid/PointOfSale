<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmcalendar
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
    Public WithEvents Calendar1 As MonthCalendar
	Public WithEvents cmdcancel As System.Windows.Forms.Button
	Public WithEvents cmdok As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcalendar))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Calendar1 = New System.Windows.Forms.MonthCalendar()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Calendar1
        '
        Me.Calendar1.Location = New System.Drawing.Point(0, 0)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.TabIndex = 2
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdcancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdcancel.Location = New System.Drawing.Point(154, 165)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdcancel.Size = New System.Drawing.Size(73, 33)
        Me.cmdcancel.TabIndex = 1
        Me.cmdcancel.Text = "&Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Control
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdok.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdok.Location = New System.Drawing.Point(78, 165)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdok.Size = New System.Drawing.Size(73, 33)
        Me.cmdok.TabIndex = 0
        Me.cmdok.Text = "&OK"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'frmcalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(230, 207)
        Me.Controls.Add(Me.Calendar1)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdok)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcalendar"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calendar"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class