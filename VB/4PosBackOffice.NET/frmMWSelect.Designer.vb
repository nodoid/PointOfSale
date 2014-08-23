<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMWSelect
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
	Public WithEvents cmbMWNo As System.Windows.Forms.ComboBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents txtWNO As System.Windows.Forms.TextBox
	Public WithEvents _lbl_5 As System.Windows.Forms.Label
	Public WithEvents _Shape1_2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMWSelect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmbMWNo = New System.Windows.Forms.ComboBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.txtWNO = New System.Windows.Forms.TextBox
		Me._lbl_5 = New System.Windows.Forms.Label
		Me._Shape1_2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Warehouse selection"
		Me.ClientSize = New System.Drawing.Size(418, 99)
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
		Me.Name = "frmMWSelect"
		Me.cmbMWNo.Size = New System.Drawing.Size(276, 21)
		Me.cmbMWNo.Location = New System.Drawing.Point(16, 32)
		Me.cmbMWNo.Items.AddRange(New Object(){"No relationship", "Always the same or cheaper", "Always the same or more expensive"})
		Me.cmbMWNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbMWNo.TabIndex = 2
		Me.cmbMWNo.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMWNo.CausesValidation = True
		Me.cmbMWNo.Enabled = True
		Me.cmbMWNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMWNo.IntegralHeight = True
		Me.cmbMWNo.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMWNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMWNo.Sorted = False
		Me.cmbMWNo.TabStop = True
		Me.cmbMWNo.Visible = True
		Me.cmbMWNo.Name = "cmbMWNo"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "Next"
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(304, 32)
		Me.cmdExit.TabIndex = 1
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.txtWNO.AutoSize = False
		Me.txtWNO.Size = New System.Drawing.Size(89, 25)
		Me.txtWNO.Location = New System.Drawing.Point(104, 56)
		Me.txtWNO.TabIndex = 0
		Me.txtWNO.Text = "2"
		Me.txtWNO.Visible = False
		Me.txtWNO.AcceptsReturn = True
		Me.txtWNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtWNO.BackColor = System.Drawing.SystemColors.Window
		Me.txtWNO.CausesValidation = True
		Me.txtWNO.Enabled = True
		Me.txtWNO.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtWNO.HideSelection = True
		Me.txtWNO.ReadOnly = False
		Me.txtWNO.Maxlength = 0
		Me.txtWNO.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtWNO.MultiLine = False
		Me.txtWNO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtWNO.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtWNO.TabStop = True
		Me.txtWNO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtWNO.Name = "txtWNO"
		Me._lbl_5.BackColor = System.Drawing.Color.Transparent
		Me._lbl_5.Text = "&Select Warehouse you wish to see/edit information for."
		Me._lbl_5.Size = New System.Drawing.Size(313, 13)
		Me._lbl_5.Location = New System.Drawing.Point(8, 8)
		Me._lbl_5.TabIndex = 3
		Me._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_5.Enabled = True
		Me._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_5.UseMnemonic = True
		Me._lbl_5.Visible = True
		Me._lbl_5.AutoSize = True
		Me._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_5.Name = "_lbl_5"
		Me._Shape1_2.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_2.Size = New System.Drawing.Size(403, 68)
		Me._Shape1_2.Location = New System.Drawing.Point(8, 23)
		Me._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_2.BorderWidth = 1
		Me._Shape1_2.FillColor = System.Drawing.Color.Black
		Me._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_2.Visible = True
		Me._Shape1_2.Name = "_Shape1_2"
		Me.Controls.Add(cmbMWNo)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(txtWNO)
		Me.Controls.Add(_lbl_5)
		Me.ShapeContainer1.Shapes.Add(_Shape1_2)
		Me.Controls.Add(ShapeContainer1)
        'Me.lbl.SetIndex(_lbl_5, CType(5, Short))
		Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class