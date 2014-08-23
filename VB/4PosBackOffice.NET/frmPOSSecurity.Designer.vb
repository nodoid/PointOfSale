<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPOSSecurity
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
	Public WithEvents chkPosSecurity As System.Windows.Forms.CheckBox
	Public WithEvents lstChannel As System.Windows.Forms.CheckedListBox
	Public WithEvents lstSecurity As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.chkPosSecurity = New System.Windows.Forms.CheckBox()
        Me.lstChannel = New System.Windows.Forms.CheckedListBox()
        Me.lstSecurity = New System.Windows.Forms.CheckedListBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._Shape1_1, Me._Shape1_0})
        Me.ShapeContainer1.Size = New System.Drawing.Size(493, 486)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_1
        '
        Me._Shape1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_1.FillColor = System.Drawing.Color.Black
        Me._Shape1_1.Location = New System.Drawing.Point(252, 78)
        Me._Shape1_1.Name = "_Shape1_1"
        Me._Shape1_1.Size = New System.Drawing.Size(232, 373)
        '
        '_Shape1_0
        '
        Me._Shape1_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_0.FillColor = System.Drawing.Color.Black
        Me._Shape1_0.Location = New System.Drawing.Point(9, 78)
        Me._Shape1_0.Name = "_Shape1_0"
        Me._Shape1_0.Size = New System.Drawing.Size(232, 373)
        '
        'chkPosSecurity
        '
        Me.chkPosSecurity.BackColor = System.Drawing.SystemColors.Control
        Me.chkPosSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPosSecurity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPosSecurity.Location = New System.Drawing.Point(10, 456)
        Me.chkPosSecurity.Name = "chkPosSecurity"
        Me.chkPosSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPosSecurity.Size = New System.Drawing.Size(233, 19)
        Me.chkPosSecurity.TabIndex = 8
        Me.chkPosSecurity.Text = "Select All"
        Me.chkPosSecurity.UseVisualStyleBackColor = False
        '
        'lstChannel
        '
        Me.lstChannel.BackColor = System.Drawing.SystemColors.Window
        Me.lstChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstChannel.Location = New System.Drawing.Point(264, 90)
        Me.lstChannel.Name = "lstChannel"
        Me.lstChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstChannel.Size = New System.Drawing.Size(208, 347)
        Me.lstChannel.TabIndex = 5
        Me.lstChannel.Tag = "0"
        '
        'lstSecurity
        '
        Me.lstSecurity.BackColor = System.Drawing.SystemColors.Window
        Me.lstSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSecurity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSecurity.Location = New System.Drawing.Point(22, 90)
        Me.lstSecurity.Name = "lstSecurity"
        Me.lstSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSecurity.Size = New System.Drawing.Size(208, 347)
        Me.lstSecurity.TabIndex = 3
        Me.lstSecurity.Tag = "0"
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdExit)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(493, 39)
        Me.picButtons.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(411, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(73, 29)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(5, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 29)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        '_Label1_2
        '
        Me._Label1_2.AutoSize = True
        Me._Label1_2.BackColor = System.Drawing.Color.Transparent
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(12, 42)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(35, 13)
        Me._Label1_2.TabIndex = 7
        Me._Label1_2.Text = "Name"
        '
        '_Label1_1
        '
        Me._Label1_1.AutoSize = True
        Me._Label1_1.BackColor = System.Drawing.Color.Transparent
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(12, 63)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(74, 13)
        Me._Label1_1.TabIndex = 6
        Me._Label1_1.Text = "&1. Permissions"
        '
        '_Label1_0
        '
        Me._Label1_0.AutoSize = True
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(255, 63)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(120, 13)
        Me._Label1_0.TabIndex = 4
        Me._Label1_0.Text = "&2. Sale Channel Access"
        '
        'frmPOSSecurity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(493, 486)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkPosSecurity)
        Me.Controls.Add(Me.lstChannel)
        Me.Controls.Add(Me.lstSecurity)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSSecurity"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Point Of Sale Permissions"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class