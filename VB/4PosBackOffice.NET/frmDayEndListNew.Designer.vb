<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDayEndList
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
	Public WithEvents cmdPrev As System.Windows.Forms.Button
    Public WithEvents DataList1 As myDataGridView
	Public WithEvents cmdExit As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDayEndList))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdPrev = New System.Windows.Forms.Button
        Me.DataList1 = New myDataGridView
		Me.cmdExit = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Select a Day End"
		Me.ClientSize = New System.Drawing.Size(259, 416)
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
		Me.Name = "frmDayEndList"
		Me.cmdPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrev.Text = "Load Previous Month Ends"
		Me.cmdPrev.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdPrev.Size = New System.Drawing.Size(97, 52)
		Me.cmdPrev.Location = New System.Drawing.Point(8, 354)
		Me.cmdPrev.TabIndex = 2
		Me.cmdPrev.TabStop = False
		Me.cmdPrev.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrev.CausesValidation = True
		Me.cmdPrev.Enabled = True
		Me.cmdPrev.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrev.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrev.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrev.Name = "cmdPrev"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(244, 342)
		Me.DataList1.Location = New System.Drawing.Point(6, 6)
		Me.DataList1.TabIndex = 0
		Me.DataList1.Name = "DataList1"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(153, 354)
		Me.cmdExit.TabIndex = 1
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.Controls.Add(cmdPrev)
		Me.Controls.Add(DataList1)
		Me.Controls.Add(cmdExit)
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class