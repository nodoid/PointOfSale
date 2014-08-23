<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPriceList
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
	Public WithEvents chkChannel As System.Windows.Forms.CheckBox
	Public WithEvents cmbDelivery As System.Windows.Forms.ComboBox
	Public WithEvents cmbCOD As System.Windows.Forms.ComboBox
	Public WithEvents _chkFields_12 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdAllocate As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
    'Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.chkChannel = New System.Windows.Forms.CheckBox()
        Me.cmbDelivery = New System.Windows.Forms.ComboBox()
        Me.cmbCOD = New System.Windows.Forms.ComboBox()
        Me._chkFields_12 = New System.Windows.Forms.CheckBox()
        Me._txtFields_0 = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdAllocate = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
        Me._lblLabels_38 = New System.Windows.Forms.Label()
        Me._lbl_5 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._Shape1_2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(406, 158)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_2
        '
        Me._Shape1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me._Shape1_2.Location = New System.Drawing.Point(15, 60)
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Shape1_2.Size = New System.Drawing.Size(379, 88)
        '
        'chkChannel
        '
        Me.chkChannel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkChannel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkChannel.Location = New System.Drawing.Point(210, 87)
        Me.chkChannel.Name = "chkChannel"
        Me.chkChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkChannel.Size = New System.Drawing.Size(136, 13)
        Me.chkChannel.TabIndex = 5
        Me.chkChannel.Text = "Delivery Channel Name:"
        Me.chkChannel.UseVisualStyleBackColor = False
        '
        'cmbDelivery
        '
        Me.cmbDelivery.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDelivery.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDelivery.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDelivery.Location = New System.Drawing.Point(210, 102)
        Me.cmbDelivery.Name = "cmbDelivery"
        Me.cmbDelivery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDelivery.Size = New System.Drawing.Size(178, 21)
        Me.cmbDelivery.TabIndex = 6
        '
        'cmbCOD
        '
        Me.cmbCOD.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOD.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCOD.Location = New System.Drawing.Point(21, 102)
        Me.cmbCOD.Name = "cmbCOD"
        Me.cmbCOD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCOD.Size = New System.Drawing.Size(178, 21)
        Me.cmbCOD.TabIndex = 4
        '
        '_chkFields_12
        '
        Me._chkFields_12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_12.Location = New System.Drawing.Point(324, 126)
        Me._chkFields_12.Name = "_chkFields_12"
        Me._chkFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_12.Size = New System.Drawing.Size(64, 19)
        Me._chkFields_12.TabIndex = 7
        Me._chkFields_12.Text = "Disabled:"
        Me._chkFields_12.UseVisualStyleBackColor = False
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_0.Location = New System.Drawing.Point(102, 66)
        Me._txtFields_0.MaxLength = 0
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(285, 19)
        Me._txtFields_0.TabIndex = 2
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdPrint)
        Me.picButtons.Controls.Add(Me.cmdAllocate)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(406, 39)
        Me.picButtons.TabIndex = 10
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(243, 3)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(76, 28)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdAllocate
        '
        Me.cmdAllocate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllocate.Location = New System.Drawing.Point(150, 3)
        Me.cmdAllocate.Name = "cmdAllocate"
        Me.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllocate.Size = New System.Drawing.Size(79, 28)
        Me.cmdAllocate.TabIndex = 11
        Me.cmdAllocate.Text = "&Allocate"
        Me.cmdAllocate.UseVisualStyleBackColor = False
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
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(324, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_0.Location = New System.Drawing.Point(20, 87)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(106, 13)
        Me._lblLabels_0.TabIndex = 3
        Me._lblLabels_0.Text = "COD Channel Name:"
        Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_38
        '
        Me._lblLabels_38.AutoSize = True
        Me._lblLabels_38.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_38.Location = New System.Drawing.Point(20, 69)
        Me._lblLabels_38.Name = "_lblLabels_38"
        Me._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_38.Size = New System.Drawing.Size(84, 13)
        Me._lblLabels_38.TabIndex = 1
        Me._lblLabels_38.Text = "Price List Name:"
        Me._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(15, 45)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(56, 13)
        Me._lbl_5.TabIndex = 0
        Me._lbl_5.Text = "&1. General"
        '
        'frmPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(406, 158)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkChannel)
        Me.Controls.Add(Me.cmbDelivery)
        Me.Controls.Add(Me.cmbCOD)
        Me.Controls.Add(Me._chkFields_12)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lblLabels_38)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriceList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Price List"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class