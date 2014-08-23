<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmItemGroup
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
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents _optDataType_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optDataType_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmdGroup As System.Windows.Forms.Button
	Public WithEvents cmdStockItem As System.Windows.Forms.Button
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents lblGroup As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblItem As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optDataType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmItemGroup))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdLoad = New System.Windows.Forms.Button
		Me._optDataType_1 = New System.Windows.Forms.RadioButton
		Me._optDataType_0 = New System.Windows.Forms.RadioButton
		Me.cmdGroup = New System.Windows.Forms.Button
		Me.cmdStockItem = New System.Windows.Forms.Button
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lblGroup = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblItem = New System.Windows.Forms.Label
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optDataType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optDataType, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Stock Item / Stock Group Compare"
		Me.ClientSize = New System.Drawing.Size(558, 196)
		Me.Location = New System.Drawing.Point(3, 22)
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
		Me.Name = "frmItemGroup"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 31)
		Me.cmdExit.Location = New System.Drawing.Point(9, 144)
		Me.cmdExit.TabIndex = 9
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load report >>"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 31)
		Me.cmdLoad.Location = New System.Drawing.Point(465, 144)
		Me.cmdLoad.TabIndex = 8
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me._optDataType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optDataType_1.Text = "Sales Value"
		Me._optDataType_1.Size = New System.Drawing.Size(145, 13)
		Me._optDataType_1.Location = New System.Drawing.Point(315, 162)
		Me._optDataType_1.TabIndex = 7
		Me._optDataType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optDataType_1.BackColor = System.Drawing.SystemColors.Control
		Me._optDataType_1.CausesValidation = True
		Me._optDataType_1.Enabled = True
		Me._optDataType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optDataType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optDataType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optDataType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optDataType_1.TabStop = True
		Me._optDataType_1.Checked = False
		Me._optDataType_1.Visible = True
		Me._optDataType_1.Name = "_optDataType_1"
		Me._optDataType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optDataType_0.Text = "Sales Quantity"
		Me._optDataType_0.Size = New System.Drawing.Size(145, 13)
		Me._optDataType_0.Location = New System.Drawing.Point(315, 144)
		Me._optDataType_0.TabIndex = 6
		Me._optDataType_0.Checked = True
		Me._optDataType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optDataType_0.BackColor = System.Drawing.SystemColors.Control
		Me._optDataType_0.CausesValidation = True
		Me._optDataType_0.Enabled = True
		Me._optDataType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optDataType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optDataType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optDataType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optDataType_0.TabStop = True
		Me._optDataType_0.Visible = True
		Me._optDataType_0.Name = "_optDataType_0"
		Me.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGroup.Text = "Get a Group >>"
		Me.cmdGroup.Size = New System.Drawing.Size(97, 31)
		Me.cmdGroup.Location = New System.Drawing.Point(441, 90)
		Me.cmdGroup.TabIndex = 3
		Me.cmdGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGroup.CausesValidation = True
		Me.cmdGroup.Enabled = True
		Me.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGroup.TabStop = True
		Me.cmdGroup.Name = "cmdGroup"
		Me.cmdStockItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdStockItem.Text = "Get Stock Item >>"
		Me.cmdStockItem.Size = New System.Drawing.Size(97, 22)
		Me.cmdStockItem.Location = New System.Drawing.Point(441, 30)
		Me.cmdStockItem.TabIndex = 1
		Me.cmdStockItem.BackColor = System.Drawing.SystemColors.Control
		Me.cmdStockItem.CausesValidation = True
		Me.cmdStockItem.Enabled = True
		Me.cmdStockItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdStockItem.TabStop = True
		Me.cmdStockItem.Name = "cmdStockItem"
		Me._lbl_1.Text = "&2. Select a Group"
		Me._lbl_1.Size = New System.Drawing.Size(101, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 66)
		Me._lbl_1.TabIndex = 5
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me.lblGroup.Text = "lblGroup"
		Me.lblGroup.Size = New System.Drawing.Size(421, 37)
		Me.lblGroup.Location = New System.Drawing.Point(15, 87)
		Me.lblGroup.TabIndex = 4
		Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGroup.BackColor = System.Drawing.SystemColors.Control
		Me.lblGroup.Enabled = True
		Me.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGroup.UseMnemonic = True
		Me.lblGroup.Visible = True
		Me.lblGroup.AutoSize = False
		Me.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblGroup.Name = "lblGroup"
		Me._lbl_0.Text = "&1. Select a Stock Item"
		Me._lbl_0.Size = New System.Drawing.Size(128, 13)
		Me._lbl_0.Location = New System.Drawing.Point(9, 9)
		Me._lbl_0.TabIndex = 2
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblItem.Size = New System.Drawing.Size(421, 19)
		Me.lblItem.Location = New System.Drawing.Point(15, 30)
		Me.lblItem.TabIndex = 0
		Me.lblItem.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblItem.BackColor = System.Drawing.SystemColors.Control
		Me.lblItem.Enabled = True
		Me.lblItem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblItem.UseMnemonic = True
		Me.lblItem.Visible = True
		Me.lblItem.AutoSize = False
		Me.lblItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblItem.Name = "lblItem"
		Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_0.Size = New System.Drawing.Size(535, 34)
		Me._Shape1_0.Location = New System.Drawing.Point(9, 24)
		Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_0.BorderWidth = 1
		Me._Shape1_0.FillColor = System.Drawing.Color.Black
		Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_0.Visible = True
		Me._Shape1_0.Name = "_Shape1_0"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(535, 52)
		Me._Shape1_1.Location = New System.Drawing.Point(9, 81)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(_optDataType_1)
		Me.Controls.Add(_optDataType_0)
		Me.Controls.Add(cmdGroup)
		Me.Controls.Add(cmdStockItem)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(lblGroup)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblItem)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.Controls.Add(ShapeContainer1)
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.optDataType.SetIndex(_optDataType_1, CType(1, Short))
        'Me.optDataType.SetIndex(_optDataType_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.optDataType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class