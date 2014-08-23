<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPriceSet
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
	Public WithEvents txtholdvalue As System.Windows.Forms.TextBox
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdEmulate As System.Windows.Forms.Button
	Public WithEvents _chkFields_0 As System.Windows.Forms.CheckBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdPrintAll As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents lblStockItem As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
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
        Me.txtholdvalue = New System.Windows.Forms.TextBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdEmulate = New System.Windows.Forms.Button()
        Me._chkFields_0 = New System.Windows.Forms.CheckBox()
        Me._txtFields_0 = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdPrintAll = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me._lblLabels_1 = New System.Windows.Forms.Label()
        Me.lblStockItem = New System.Windows.Forms.Label()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
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
        Me.ShapeContainer1.Size = New System.Drawing.Size(408, 204)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        '_Shape1_2
        '
        Me._Shape1_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
        Me._Shape1_2.FillColor = System.Drawing.Color.Black
        Me._Shape1_2.Location = New System.Drawing.Point(9, 60)
        Me._Shape1_2.Name = "_Shape1_2"
        Me._Shape1_2.Size = New System.Drawing.Size(322, 112)
        '
        'txtholdvalue
        '
        Me.txtholdvalue.AcceptsReturn = True
        Me.txtholdvalue.BackColor = System.Drawing.SystemColors.Window
        Me.txtholdvalue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtholdvalue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtholdvalue.Location = New System.Drawing.Point(90, 236)
        Me.txtholdvalue.MaxLength = 0
        Me.txtholdvalue.Name = "txtholdvalue"
        Me.txtholdvalue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtholdvalue.Size = New System.Drawing.Size(71, 19)
        Me.txtholdvalue.TabIndex = 12
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEdit.Location = New System.Drawing.Point(282, 147)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEdit.Size = New System.Drawing.Size(37, 17)
        Me.cmdEdit.TabIndex = 11
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdEmulate
        '
        Me.cmdEmulate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEmulate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEmulate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEmulate.Location = New System.Drawing.Point(282, 128)
        Me.cmdEmulate.Name = "cmdEmulate"
        Me.cmdEmulate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEmulate.Size = New System.Drawing.Size(37, 17)
        Me.cmdEmulate.TabIndex = 10
        Me.cmdEmulate.Text = "..."
        Me.cmdEmulate.UseVisualStyleBackColor = False
        '
        '_chkFields_0
        '
        Me._chkFields_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkFields_0.Location = New System.Drawing.Point(222, 90)
        Me._chkFields_0.Name = "_chkFields_0"
        Me._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkFields_0.Size = New System.Drawing.Size(97, 19)
        Me._chkFields_0.TabIndex = 6
        Me._chkFields_0.Text = "Disable this Set:"
        Me._chkFields_0.UseVisualStyleBackColor = False
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtFields_0.Location = New System.Drawing.Point(96, 66)
        Me._txtFields_0.MaxLength = 0
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(226, 19)
        Me._txtFields_0.TabIndex = 5
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdPrintAll)
        Me.picButtons.Controls.Add(Me.cmdPrint)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(408, 39)
        Me.picButtons.TabIndex = 2
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrintAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrintAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrintAll.Location = New System.Drawing.Point(96, 3)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrintAll.Size = New System.Drawing.Size(73, 29)
        Me.cmdPrintAll.TabIndex = 13
        Me.cmdPrintAll.Text = "&Print All"
        Me.cmdPrintAll.UseVisualStyleBackColor = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(183, 3)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
        Me.cmdPrint.TabIndex = 7
        Me.cmdPrint.TabStop = False
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
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
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(261, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_1.Location = New System.Drawing.Point(16, 114)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(98, 13)
        Me._lblLabels_1.TabIndex = 9
        Me._lblLabels_1.Text = "Primary Stock Item:"
        Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblStockItem
        '
        Me.lblStockItem.BackColor = System.Drawing.SystemColors.Control
        Me.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStockItem.Location = New System.Drawing.Point(15, 129)
        Me.lblStockItem.Name = "lblStockItem"
        Me.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStockItem.Size = New System.Drawing.Size(262, 16)
        Me.lblStockItem.TabIndex = 8
        Me.lblStockItem.Text = "No Stock Item Selected"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_0.Location = New System.Drawing.Point(14, 69)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(84, 13)
        Me._lblLabels_0.TabIndex = 4
        Me._lblLabels_0.Text = "Price Set Name:"
        Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_5
        '
        Me._lbl_5.AutoSize = True
        Me._lbl_5.BackColor = System.Drawing.Color.Transparent
        Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_5.Location = New System.Drawing.Point(9, 45)
        Me._lbl_5.Name = "_lbl_5"
        Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_5.Size = New System.Drawing.Size(56, 13)
        Me._lbl_5.TabIndex = 3
        Me._lbl_5.Text = "&1. General"
        '
        'frmPriceSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(408, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtholdvalue)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdEmulate)
        Me.Controls.Add(Me._chkFields_0)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me.lblStockItem)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lbl_5)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(73, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriceSet"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Pricing Set Details"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class