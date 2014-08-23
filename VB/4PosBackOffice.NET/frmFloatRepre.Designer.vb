<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFloatRepre
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
	Public WithEvents cbmChangeType As System.Windows.Forms.ComboBox
	Public WithEvents _txtFloat_3 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents chkDisable As System.Windows.Forms.CheckBox
	Public WithEvents _txtFloat_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtFloat_1 As System.Windows.Forms.TextBox
	Public WithEvents chkKey As System.Windows.Forms.CheckBox
	Public WithEvents _txtKey_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtKey_1 As System.Windows.Forms.TextBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Shape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
    'Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'Public WithEvents txtKey As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Shape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.cbmChangeType = New System.Windows.Forms.ComboBox()
        Me._txtFloat_3 = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.chkDisable = New System.Windows.Forms.CheckBox()
        Me._txtFloat_2 = New System.Windows.Forms.TextBox()
        Me._txtFloat_0 = New System.Windows.Forms.TextBox()
        Me._txtFloat_1 = New System.Windows.Forms.TextBox()
        Me.chkKey = New System.Windows.Forms.CheckBox()
        Me._txtKey_0 = New System.Windows.Forms.TextBox()
        Me._txtKey_1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Shape2, Me.Shape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(343, 231)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.SystemColors.Window
        Me.Shape2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape2.FillColor = System.Drawing.Color.Black
        Me.Shape2.Location = New System.Drawing.Point(4, 160)
        Me.Shape2.Name = "Shape2"
        Me.Shape2.Size = New System.Drawing.Size(337, 67)
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.SystemColors.Window
        Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape1.FillColor = System.Drawing.Color.Black
        Me.Shape1.Location = New System.Drawing.Point(4, 66)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.Size(337, 75)
        '
        'cbmChangeType
        '
        Me.cbmChangeType.BackColor = System.Drawing.SystemColors.Window
        Me.cbmChangeType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbmChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmChangeType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbmChangeType.Items.AddRange(New Object() {"Coin", "Note"})
        Me.cbmChangeType.Location = New System.Drawing.Point(256, 92)
        Me.cbmChangeType.Name = "cbmChangeType"
        Me.cbmChangeType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbmChangeType.Size = New System.Drawing.Size(79, 21)
        Me.cbmChangeType.TabIndex = 18
        '
        '_txtFloat_3
        '
        Me._txtFloat_3.AcceptsReturn = True
        Me._txtFloat_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_3.Location = New System.Drawing.Point(70, 116)
        Me._txtFloat_3.MaxLength = 0
        Me._txtFloat_3.Name = "_txtFloat_3"
        Me._txtFloat_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_3.Size = New System.Drawing.Size(75, 20)
        Me._txtFloat_3.TabIndex = 16
        Me._txtFloat_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.Command1)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(343, 38)
        Me.picButtons.TabIndex = 14
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(244, 4)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(93, 25)
        Me.Command1.TabIndex = 15
        Me.Command1.Text = "E&xit"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'chkDisable
        '
        Me.chkDisable.BackColor = System.Drawing.SystemColors.Control
        Me.chkDisable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDisable.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDisable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkDisable.Location = New System.Drawing.Point(218, 120)
        Me.chkDisable.Name = "chkDisable"
        Me.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDisable.Size = New System.Drawing.Size(117, 16)
        Me.chkDisable.TabIndex = 6
        Me.chkDisable.Text = "Float Disabled"
        Me.chkDisable.UseVisualStyleBackColor = False
        '
        '_txtFloat_2
        '
        Me._txtFloat_2.AcceptsReturn = True
        Me._txtFloat_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_2.Enabled = False
        Me._txtFloat_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_2.Location = New System.Drawing.Point(70, 94)
        Me._txtFloat_2.MaxLength = 0
        Me._txtFloat_2.Name = "_txtFloat_2"
        Me._txtFloat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_2.Size = New System.Drawing.Size(49, 20)
        Me._txtFloat_2.TabIndex = 5
        '
        '_txtFloat_0
        '
        Me._txtFloat_0.AcceptsReturn = True
        Me._txtFloat_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_0.Location = New System.Drawing.Point(70, 72)
        Me._txtFloat_0.MaxLength = 0
        Me._txtFloat_0.Name = "_txtFloat_0"
        Me._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_0.Size = New System.Drawing.Size(75, 20)
        Me._txtFloat_0.TabIndex = 0
        '
        '_txtFloat_1
        '
        Me._txtFloat_1.AcceptsReturn = True
        Me._txtFloat_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFloat_1.Location = New System.Drawing.Point(288, 70)
        Me._txtFloat_1.MaxLength = 0
        Me._txtFloat_1.Name = "_txtFloat_1"
        Me._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFloat_1.Size = New System.Drawing.Size(47, 20)
        Me._txtFloat_1.TabIndex = 1
        Me._txtFloat_1.Text = "0"
        Me._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkKey
        '
        Me.chkKey.BackColor = System.Drawing.SystemColors.Control
        Me.chkKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkKey.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKey.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkKey.Location = New System.Drawing.Point(8, 165)
        Me.chkKey.Name = "chkKey"
        Me.chkKey.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkKey.Size = New System.Drawing.Size(329, 19)
        Me.chkKey.TabIndex = 4
        Me.chkKey.Text = "Float set as a Fast Preset Tender on POS"
        Me.chkKey.UseVisualStyleBackColor = False
        '
        '_txtKey_0
        '
        Me._txtKey_0.AcceptsReturn = True
        Me._txtKey_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtKey_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtKey_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtKey_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtKey_0.Location = New System.Drawing.Point(252, 184)
        Me._txtKey_0.MaxLength = 0
        Me._txtKey_0.Name = "_txtKey_0"
        Me._txtKey_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtKey_0.Size = New System.Drawing.Size(85, 20)
        Me._txtKey_0.TabIndex = 3
        Me._txtKey_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtKey_1
        '
        Me._txtKey_1.AcceptsReturn = True
        Me._txtKey_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtKey_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtKey_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtKey_1.Enabled = False
        Me._txtKey_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtKey_1.Location = New System.Drawing.Point(252, 204)
        Me._txtKey_1.MaxLength = 0
        Me._txtKey_1.Name = "_txtKey_1"
        Me._txtKey_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtKey_1.Size = New System.Drawing.Size(85, 20)
        Me._txtKey_1.TabIndex = 2
        Me._txtKey_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(160, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(91, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Change Float Type"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Float Value"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "1. Float Details"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(4, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "2. Preset Details"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Float Name"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(160, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Float Pack"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Float Type"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(160, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Keyboard Name:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(160, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(89, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Keyboard Key(s)"
        '
        'frmFloatRepre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(343, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbmChangeType)
        Me.Controls.Add(Me._txtFloat_3)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.chkDisable)
        Me.Controls.Add(Me._txtFloat_2)
        Me.Controls.Add(Me._txtFloat_0)
        Me.Controls.Add(Me._txtFloat_1)
        Me.Controls.Add(Me.chkKey)
        Me.Controls.Add(Me._txtKey_0)
        Me.Controls.Add(Me._txtKey_1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmFloatRepre"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Denomination Details"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class