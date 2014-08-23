<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockSalesShrink
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
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdGroup As System.Windows.Forms.Button
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents lblGroup As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockSalesShrink))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdGroup = New System.Windows.Forms.Button
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lblGroup = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Stock Item Sales Shrink Analysis"
		Me.ClientSize = New System.Drawing.Size(264, 192)
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
		Me.Name = "frmStockSalesShrink"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load Report"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 31)
		Me.cmdLoad.Location = New System.Drawing.Point(177, 147)
		Me.cmdLoad.TabIndex = 4
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 31)
		Me.cmdExit.Location = New System.Drawing.Point(9, 147)
		Me.cmdExit.TabIndex = 3
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGroup.Text = "&Filter"
		Me.cmdGroup.Size = New System.Drawing.Size(97, 31)
		Me.cmdGroup.Location = New System.Drawing.Point(153, 93)
		Me.cmdGroup.TabIndex = 2
		Me.cmdGroup.TabStop = False
		Me.cmdGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGroup.CausesValidation = True
		Me.cmdGroup.Enabled = True
		Me.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGroup.Name = "cmdGroup"
		Me._lbl_1.Text = "Filter"
		Me._lbl_1.Size = New System.Drawing.Size(29, 13)
		Me._lbl_1.Location = New System.Drawing.Point(9, 6)
		Me._lbl_1.TabIndex = 0
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
		Me.lblGroup.Size = New System.Drawing.Size(232, 58)
		Me.lblGroup.Location = New System.Drawing.Point(15, 27)
		Me.lblGroup.TabIndex = 1
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
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(247, 112)
		Me._Shape1_1.Location = New System.Drawing.Point(9, 21)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdGroup)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(lblGroup)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.Controls.Add(ShapeContainer1)
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class