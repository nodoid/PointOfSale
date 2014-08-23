<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVNC
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
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents ilPOS As System.Windows.Forms.ImageList
	Public WithEvents _lvPOS_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPOS_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPOS_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPOS_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvPOS As System.Windows.Forms.ListView
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVNC))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdExit = New System.Windows.Forms.Button
		Me._optType_0 = New System.Windows.Forms.RadioButton
		Me._optType_1 = New System.Windows.Forms.RadioButton
		Me.ilPOS = New System.Windows.Forms.ImageList
		Me.lvPOS = New System.Windows.Forms.ListView
		Me._lvPOS_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvPOS_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvPOS_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvPOS_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.lvPOS.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "View another computer"
		Me.ClientSize = New System.Drawing.Size(513, 339)
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
		Me.Name = "frmVNC"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(115, 34)
		Me.cmdExit.Location = New System.Drawing.Point(387, 291)
		Me.cmdExit.TabIndex = 3
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._optType_0.Text = "&View mode"
		Me._optType_0.Size = New System.Drawing.Size(115, 16)
		Me._optType_0.Location = New System.Drawing.Point(27, 108)
		Me._optType_0.TabIndex = 2
		Me._optType_0.TabStop = False
		Me._optType_0.Checked = True
		Me._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.CausesValidation = True
		Me._optType_0.Enabled = True
		Me._optType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_0.Visible = True
		Me._optType_0.Name = "_optType_0"
		Me._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me._optType_1.Text = "&Edit mode"
		Me._optType_1.Size = New System.Drawing.Size(115, 16)
		Me._optType_1.Location = New System.Drawing.Point(27, 180)
		Me._optType_1.TabIndex = 1
		Me._optType_1.TabStop = False
		Me._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.CausesValidation = True
		Me._optType_1.Enabled = True
		Me._optType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_1.Checked = False
		Me._optType_1.Visible = True
		Me._optType_1.Name = "_optType_1"
		Me.ilPOS.ImageSize = New System.Drawing.Size(32, 32)
		Me.ilPOS.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.ilPOS.ImageStream = CType(resources.GetObject("ilPOS.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ilPOS.Images.SetKeyName(0, "")
		Me.lvPOS.Size = New System.Drawing.Size(346, 274)
		Me.lvPOS.Location = New System.Drawing.Point(156, 6)
		Me.lvPOS.TabIndex = 0
		Me.lvPOS.Alignment = System.Windows.Forms.ListViewAlignment.Top
		Me.lvPOS.LabelEdit = False
		Me.lvPOS.LabelWrap = True
		Me.lvPOS.HideSelection = True
		Me.lvPOS.LargeImageList = ilPOS
		Me.lvPOS.SmallImageList = ilPOS
		Me.lvPOS.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvPOS.BackColor = System.Drawing.SystemColors.Window
		Me.lvPOS.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lvPOS.Name = "lvPOS"
		Me._lvPOS_ColumnHeader_1.Text = "POS"
		Me._lvPOS_ColumnHeader_1.Width = 170
		Me._lvPOS_ColumnHeader_2.Text = "Name"
		Me._lvPOS_ColumnHeader_2.Width = 170
		Me._lvPOS_ColumnHeader_3.Text = "IP Address"
		Me._lvPOS_ColumnHeader_3.Width = 170
		Me._lvPOS_ColumnHeader_4.Text = "Enabled"
		Me._lvPOS_ColumnHeader_4.Width = 170
		Me._Label1_3.Text = "You can control the mouse and keyboard activity from your own computer. "
		Me._Label1_3.Size = New System.Drawing.Size(121, 55)
		Me._Label1_3.Location = New System.Drawing.Point(27, 195)
		Me._Label1_3.TabIndex = 7
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_3.BackColor = System.Drawing.Color.Transparent
		Me._Label1_3.Enabled = True
		Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = False
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label1_2.Text = "You can only view the activity on the computer. No intervention is permitted."
		Me._Label1_2.Size = New System.Drawing.Size(121, 55)
		Me._Label1_2.Location = New System.Drawing.Point(27, 123)
		Me._Label1_2.TabIndex = 6
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_1.Text = "There are two modes that can be activated a description of each follows:"
		Me._Label1_1.Size = New System.Drawing.Size(142, 55)
		Me._Label1_1.Location = New System.Drawing.Point(6, 60)
		Me._Label1_1.TabIndex = 5
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.Text = "Use the Arrow keys to move to the desired computer you wish to view and then press the Enter key."
		Me._Label1_0.Size = New System.Drawing.Size(142, 70)
		Me._Label1_0.Location = New System.Drawing.Point(6, 6)
		Me._Label1_0.TabIndex = 4
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_optType_0)
		Me.Controls.Add(_optType_1)
		Me.Controls.Add(lvPOS)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label1_2)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
		Me.lvPOS.Columns.Add(_lvPOS_ColumnHeader_1)
		Me.lvPOS.Columns.Add(_lvPOS_ColumnHeader_2)
		Me.lvPOS.Columns.Add(_lvPOS_ColumnHeader_3)
		Me.lvPOS.Columns.Add(_lvPOS_ColumnHeader_4)
        'Me.Label1.SetIndex(_Label1_3, CType(3, Short))
        'Me.Label1.SetIndex(_Label1_2, CType(2, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.optType.SetIndex(_optType_0, CType(0, Short))
        'Me.optType.SetIndex(_optType_1, CType(1, Short))
        'CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.lvPOS.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class