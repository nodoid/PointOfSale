<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUpdateDayEnd
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
	Public WithEvents tmrStart As System.Windows.Forms.Timer
	Public WithEvents picInner As System.Windows.Forms.PictureBox
	Public WithEvents picOuter As System.Windows.Forms.Panel
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdateDayEnd))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmrStart = New System.Windows.Forms.Timer(components)
		Me.picOuter = New System.Windows.Forms.Panel
		Me.picInner = New System.Windows.Forms.PictureBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.picOuter.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.ControlBox = False
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(312, 55)
		Me.Location = New System.Drawing.Point(3, 3)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmUpdateDayEnd"
		Me.tmrStart.Interval = 100
		Me.tmrStart.Enabled = True
		Me.picOuter.BackColor = System.Drawing.Color.White
		Me.picOuter.Size = New System.Drawing.Size(298, 25)
		Me.picOuter.Location = New System.Drawing.Point(6, 21)
		Me.picOuter.TabIndex = 0
		Me.picOuter.Dock = System.Windows.Forms.DockStyle.None
		Me.picOuter.CausesValidation = True
		Me.picOuter.Enabled = True
		Me.picOuter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picOuter.Cursor = System.Windows.Forms.Cursors.Default
		Me.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picOuter.TabStop = True
		Me.picOuter.Visible = True
		Me.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picOuter.Name = "picOuter"
		Me.picInner.BackColor = System.Drawing.Color.FromARGB(0, 0, 192)
		Me.picInner.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picInner.Size = New System.Drawing.Size(58, 34)
		Me.picInner.Location = New System.Drawing.Point(0, 0)
		Me.picInner.TabIndex = 1
		Me.picInner.Dock = System.Windows.Forms.DockStyle.None
		Me.picInner.CausesValidation = True
		Me.picInner.Enabled = True
		Me.picInner.Cursor = System.Windows.Forms.Cursors.Default
		Me.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picInner.TabStop = True
		Me.picInner.Visible = True
		Me.picInner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picInner.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picInner.Name = "picInner"
		Me.Label1.Text = "Updating Report Data ..."
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label1.Size = New System.Drawing.Size(168, 16)
		Me.Label1.Location = New System.Drawing.Point(6, 3)
		Me.Label1.TabIndex = 2
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
		Me.Controls.Add(picOuter)
		Me.Controls.Add(Label1)
		Me.picOuter.Controls.Add(picInner)
		Me.picOuter.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class