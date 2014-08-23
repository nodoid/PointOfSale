<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStock
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
	Public WithEvents picInner As System.Windows.Forms.PictureBox
	Public WithEvents picOuter As System.Windows.Forms.Panel
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStock))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdGroup = New System.Windows.Forms.Button
		Me.picOuter = New System.Windows.Forms.Panel
		Me.picInner = New System.Windows.Forms.PictureBox
		Me._lbl_1 = New System.Windows.Forms.Label
		Me.lblGroup = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.picOuter.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "All StockItems GRV, Sales & Shrink Analysis"
		Me.ClientSize = New System.Drawing.Size(276, 208)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmStock"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "&Load Report"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 31)
		Me.cmdLoad.Location = New System.Drawing.Point(184, 168)
		Me.cmdLoad.TabIndex = 3
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "&Exit"
		Me.cmdExit.Size = New System.Drawing.Size(85, 31)
		Me.cmdExit.Location = New System.Drawing.Point(8, 168)
		Me.cmdExit.TabIndex = 1
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.cmdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdGroup.Text = "Filter"
		Me.cmdGroup.Size = New System.Drawing.Size(65, 27)
		Me.cmdGroup.Location = New System.Drawing.Point(192, 112)
		Me.cmdGroup.TabIndex = 0
		Me.cmdGroup.BackColor = System.Drawing.SystemColors.Control
		Me.cmdGroup.CausesValidation = True
		Me.cmdGroup.Enabled = True
		Me.cmdGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdGroup.TabStop = True
		Me.cmdGroup.Name = "cmdGroup"
		Me.picOuter.BackColor = System.Drawing.Color.White
		Me.picOuter.Size = New System.Drawing.Size(257, 33)
		Me.picOuter.Location = New System.Drawing.Point(8, 168)
		Me.picOuter.TabIndex = 5
		Me.picOuter.Visible = False
		Me.picOuter.Dock = System.Windows.Forms.DockStyle.None
		Me.picOuter.CausesValidation = True
		Me.picOuter.Enabled = True
		Me.picOuter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picOuter.Cursor = System.Windows.Forms.Cursors.Default
		Me.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picOuter.TabStop = True
		Me.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picOuter.Name = "picOuter"
		Me.picInner.BackColor = System.Drawing.Color.FromARGB(0, 0, 192)
		Me.picInner.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picInner.Size = New System.Drawing.Size(58, 34)
		Me.picInner.Location = New System.Drawing.Point(0, 0)
		Me.picInner.TabIndex = 6
		Me.picInner.Dock = System.Windows.Forms.DockStyle.None
		Me.picInner.CausesValidation = True
		Me.picInner.Enabled = True
		Me.picInner.Cursor = System.Windows.Forms.Cursors.Default
		Me.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picInner.TabStop = True
		Me.picInner.Visible = True
		Me.picInner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picInner.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picInner.Name = "picInner"
		Me._lbl_1.Text = "Filter"
		Me._lbl_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._lbl_1.Size = New System.Drawing.Size(29, 13)
		Me._lbl_1.Location = New System.Drawing.Point(8, 16)
		Me._lbl_1.TabIndex = 4
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
		Me.lblGroup.Location = New System.Drawing.Point(32, 44)
		Me.lblGroup.TabIndex = 2
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
		Me._Shape1_1.Size = New System.Drawing.Size(259, 124)
		Me._Shape1_1.Location = New System.Drawing.Point(8, 32)
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
		Me.Controls.Add(picOuter)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(lblGroup)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.Controls.Add(ShapeContainer1)
		Me.picOuter.Controls.Add(picInner)
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picOuter.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class