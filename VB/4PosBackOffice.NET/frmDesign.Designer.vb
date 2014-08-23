<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDesign
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
	Public WithEvents cmdnew As System.Windows.Forms.Button
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents cmdexit As System.Windows.Forms.Button
	Public WithEvents cmdnext As System.Windows.Forms.Button
    Public WithEvents DataList1 As myDataGridView
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDesign))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdnew = New System.Windows.Forms.Button
		Me._Option1_1 = New System.Windows.Forms.RadioButton
		Me._Option1_2 = New System.Windows.Forms.RadioButton
		Me.cmdexit = New System.Windows.Forms.Button
		Me.cmdnext = New System.Windows.Forms.Button
        Me.DataList1 = New myDataGridView
		Me.Label1 = New System.Windows.Forms.Label
        'Me.Option1 = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Option1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Barcode Design"
		Me.ClientSize = New System.Drawing.Size(425, 383)
		Me.Location = New System.Drawing.Point(3, 29)
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
		Me.Name = "frmDesign"
		Me.cmdnew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdnew.Text = "N&ew"
		Me.cmdnew.Size = New System.Drawing.Size(81, 33)
		Me.cmdnew.Location = New System.Drawing.Point(168, 344)
		Me.cmdnew.TabIndex = 6
		Me.cmdnew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdnew.CausesValidation = True
		Me.cmdnew.Enabled = True
		Me.cmdnew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdnew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdnew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdnew.TabStop = True
		Me.cmdnew.Name = "cmdnew"
		Me._Option1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._Option1_1.Text = "&Shelf Talker"
		Me._Option1_1.Size = New System.Drawing.Size(113, 33)
		Me._Option1_1.Location = New System.Drawing.Point(144, 32)
		Me._Option1_1.Appearance = System.Windows.Forms.Appearance.Button
		Me._Option1_1.TabIndex = 5
		Me._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_1.CausesValidation = True
		Me._Option1_1.Enabled = True
		Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_1.TabStop = True
		Me._Option1_1.Checked = False
		Me._Option1_1.Visible = True
		Me._Option1_1.Name = "_Option1_1"
		Me._Option1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._Option1_2.Text = "Stock &Barcode"
		Me._Option1_2.Size = New System.Drawing.Size(129, 33)
		Me._Option1_2.Location = New System.Drawing.Point(8, 32)
		Me._Option1_2.Appearance = System.Windows.Forms.Appearance.Button
		Me._Option1_2.TabIndex = 4
		Me._Option1_2.Checked = True
		Me._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
		Me._Option1_2.CausesValidation = True
		Me._Option1_2.Enabled = True
		Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Option1_2.TabStop = True
		Me._Option1_2.Visible = True
		Me._Option1_2.Name = "_Option1_2"
		Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdexit.Text = "E&xit"
		Me.cmdexit.Size = New System.Drawing.Size(81, 33)
		Me.cmdexit.Location = New System.Drawing.Point(8, 344)
		Me.cmdexit.TabIndex = 2
		Me.cmdexit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdexit.CausesValidation = True
		Me.cmdexit.Enabled = True
		Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdexit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdexit.TabStop = True
		Me.cmdexit.Name = "cmdexit"
		Me.cmdnext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdnext.Text = "&Next"
		Me.cmdnext.Size = New System.Drawing.Size(81, 33)
		Me.cmdnext.Location = New System.Drawing.Point(336, 344)
		Me.cmdnext.TabIndex = 1
		Me.cmdnext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdnext.CausesValidation = True
		Me.cmdnext.Enabled = True
		Me.cmdnext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdnext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdnext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdnext.TabStop = True
		Me.cmdnext.Name = "cmdnext"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(409, 264)
		Me.DataList1.Location = New System.Drawing.Point(8, 72)
		Me.DataList1.TabIndex = 0
		Me.DataList1.Name = "DataList1"
		Me.Label1.Text = "Please select the Stock Barcode you wish to modify"
		Me.Label1.Size = New System.Drawing.Size(353, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 8)
		Me.Label1.TabIndex = 3
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
		Me.Controls.Add(cmdnew)
		Me.Controls.Add(_Option1_1)
		Me.Controls.Add(_Option1_2)
		Me.Controls.Add(cmdexit)
		Me.Controls.Add(cmdnext)
		Me.Controls.Add(DataList1)
		Me.Controls.Add(Label1)
        'Me.Option1.SetIndex(_Option1_1, CType(1, Short))
        'Me.Option1.SetIndex(_Option1_2, CType(2, Short))
        'CType(Me.Option1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class