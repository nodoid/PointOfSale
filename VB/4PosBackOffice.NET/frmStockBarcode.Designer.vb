<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockBarcode
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
	Public WithEvents cmdBuildSPLU As System.Windows.Forms.Button
	Public WithEvents cmdBuildBarcodes As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents _chkBarcode_0 As System.Windows.Forms.CheckBox
	Public WithEvents _txtBarcode_0 As System.Windows.Forms.TextBox
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lblBarcode_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_12 As System.Windows.Forms.Label
	Public WithEvents _lbl_13 As System.Windows.Forms.Label
	Public WithEvents _lbl_14 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents chkBarcode As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents lblBarcode As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents txtBarcode As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.cmdBuildSPLU = New System.Windows.Forms.Button()
        Me.cmdBuildBarcodes = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me._chkBarcode_0 = New System.Windows.Forms.CheckBox()
        Me._txtBarcode_0 = New System.Windows.Forms.TextBox()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me._lbl_2 = New System.Windows.Forms.Label()
        Me._lblBarcode_0 = New System.Windows.Forms.Label()
        Me._lbl_12 = New System.Windows.Forms.Label()
        Me._lbl_13 = New System.Windows.Forms.Label()
        Me._lbl_14 = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Shape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(361, 184)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Shape1.FillColor = System.Drawing.Color.Black
        Me.Shape1.Location = New System.Drawing.Point(9, 75)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.Size(349, 64)
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.cmdBuildSPLU)
        Me.picButtons.Controls.Add(Me.cmdBuildBarcodes)
        Me.picButtons.Controls.Add(Me.cmdClose)
        Me.picButtons.Controls.Add(Me.cmdCancel)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(361, 38)
        Me.picButtons.TabIndex = 6
        '
        'cmdBuildSPLU
        '
        Me.cmdBuildSPLU.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuildSPLU.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuildSPLU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuildSPLU.Location = New System.Drawing.Point(184, 3)
        Me.cmdBuildSPLU.Name = "cmdBuildSPLU"
        Me.cmdBuildSPLU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuildSPLU.Size = New System.Drawing.Size(88, 29)
        Me.cmdBuildSPLU.TabIndex = 12
        Me.cmdBuildSPLU.TabStop = False
        Me.cmdBuildSPLU.Text = "&Build Scale PLU"
        Me.cmdBuildSPLU.UseVisualStyleBackColor = False
        '
        'cmdBuildBarcodes
        '
        Me.cmdBuildBarcodes.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuildBarcodes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuildBarcodes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuildBarcodes.Location = New System.Drawing.Point(87, 3)
        Me.cmdBuildBarcodes.Name = "cmdBuildBarcodes"
        Me.cmdBuildBarcodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuildBarcodes.Size = New System.Drawing.Size(88, 29)
        Me.cmdBuildBarcodes.TabIndex = 11
        Me.cmdBuildBarcodes.TabStop = False
        Me.cmdBuildBarcodes.Text = "&Build Barcode"
        Me.cmdBuildBarcodes.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(280, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 29)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = False
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
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "&Undo"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        '_chkBarcode_0
        '
        Me._chkBarcode_0.BackColor = System.Drawing.SystemColors.Window
        Me._chkBarcode_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkBarcode_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkBarcode_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._chkBarcode_0.Location = New System.Drawing.Point(243, 102)
        Me._chkBarcode_0.Name = "_chkBarcode_0"
        Me._chkBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkBarcode_0.Size = New System.Drawing.Size(13, 13)
        Me._chkBarcode_0.TabIndex = 1
        Me._chkBarcode_0.UseVisualStyleBackColor = False
        '
        '_txtBarcode_0
        '
        Me._txtBarcode_0.AcceptsReturn = True
        Me._txtBarcode_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtBarcode_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtBarcode_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBarcode_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtBarcode_0.Location = New System.Drawing.Point(66, 99)
        Me._txtBarcode_0.MaxLength = 0
        Me._txtBarcode_0.Name = "_txtBarcode_0"
        Me._txtBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtBarcode_0.Size = New System.Drawing.Size(154, 19)
        Me._txtBarcode_0.TabIndex = 0
        Me._txtBarcode_0.Text = "99999999999999"
        '
        'lblHeading
        '
        Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
        Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeading.Location = New System.Drawing.Point(0, 39)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeading.Size = New System.Drawing.Size(359, 19)
        Me.lblHeading.TabIndex = 10
        Me.lblHeading.Text = "Label1"
        '
        '_lbl_2
        '
        Me._lbl_2.AutoSize = True
        Me._lbl_2.BackColor = System.Drawing.Color.Transparent
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(9, 60)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(64, 13)
        Me._lbl_2.TabIndex = 9
        Me._lbl_2.Text = "&1. Barcodes"
        '
        '_lblBarcode_0
        '
        Me._lblBarcode_0.BackColor = System.Drawing.Color.Transparent
        Me._lblBarcode_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblBarcode_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblBarcode_0.Location = New System.Drawing.Point(21, 102)
        Me._lblBarcode_0.Name = "_lblBarcode_0"
        Me._lblBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblBarcode_0.Size = New System.Drawing.Size(40, 13)
        Me._lblBarcode_0.TabIndex = 5
        Me._lblBarcode_0.Text = "Bonne"
        Me._lblBarcode_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lbl_12
        '
        Me._lbl_12.AutoSize = True
        Me._lbl_12.BackColor = System.Drawing.Color.Transparent
        Me._lbl_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_12.Location = New System.Drawing.Point(102, 84)
        Me._lbl_12.Name = "_lbl_12"
        Me._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_12.Size = New System.Drawing.Size(51, 13)
        Me._lbl_12.TabIndex = 4
        Me._lbl_12.Text = "Bar Code"
        Me._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lbl_13
        '
        Me._lbl_13.AutoSize = True
        Me._lbl_13.BackColor = System.Drawing.Color.Transparent
        Me._lbl_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_13.Location = New System.Drawing.Point(21, 84)
        Me._lbl_13.Name = "_lbl_13"
        Me._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_13.Size = New System.Drawing.Size(37, 13)
        Me._lbl_13.TabIndex = 3
        Me._lbl_13.Text = "Shrink"
        '
        '_lbl_14
        '
        Me._lbl_14.AutoSize = True
        Me._lbl_14.BackColor = System.Drawing.Color.Transparent
        Me._lbl_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_14.Location = New System.Drawing.Point(228, 84)
        Me._lbl_14.Name = "_lbl_14"
        Me._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_14.Size = New System.Drawing.Size(42, 13)
        Me._lbl_14.TabIndex = 2
        Me._lbl_14.Text = "Disable"
        '
        'frmStockBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(361, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me._chkBarcode_0)
        Me.Controls.Add(Me._txtBarcode_0)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me._lbl_2)
        Me.Controls.Add(Me._lblBarcode_0)
        Me.Controls.Add(Me._lbl_12)
        Me.Controls.Add(Me._lbl_13)
        Me.Controls.Add(Me._lbl_14)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockBarcode"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Stock Item Barcodes"
        Me.picButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class