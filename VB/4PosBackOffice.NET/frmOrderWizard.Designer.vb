<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOrderWizard
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
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents lvData As System.Windows.Forms.ListView
	Public WithEvents cmdBuild As System.Windows.Forms.Button
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblFilter As System.Windows.Forms.Label
	Public WithEvents lblDayEnd As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderWizard))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdExit = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.lvData = New System.Windows.Forms.ListView
		Me.cmdBuild = New System.Windows.Forms.Button
		Me.cmdFilter = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._lbl_0 = New System.Windows.Forms.Label
		Me.lblFilter = New System.Windows.Forms.Label
		Me.lblDayEnd = New System.Windows.Forms.Label
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Stock Re-order Wizard"
		Me.ClientSize = New System.Drawing.Size(695, 468)
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
		Me.Name = "frmOrderWizard"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(79, 34)
		Me.cmdExit.Location = New System.Drawing.Point(609, 3)
		Me.cmdExit.TabIndex = 9
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "&Update"
		Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdUpdate.Size = New System.Drawing.Size(79, 34)
		Me.cmdUpdate.Location = New System.Drawing.Point(609, 45)
		Me.cmdUpdate.TabIndex = 5
		Me.cmdUpdate.TabStop = False
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.lvData.Size = New System.Drawing.Size(664, 337)
		Me.lvData.Location = New System.Drawing.Point(15, 114)
		Me.lvData.TabIndex = 7
		Me.lvData.View = System.Windows.Forms.View.Details
		Me.lvData.LabelEdit = False
		Me.lvData.LabelWrap = True
		Me.lvData.HideSelection = True
		Me.lvData.Checkboxes = True
		Me.lvData.FullRowSelect = True
		Me.lvData.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvData.BackColor = System.Drawing.SystemColors.Window
		Me.lvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvData.Name = "lvData"
		Me.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuild.Text = "&Build"
		Me.cmdBuild.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBuild.Size = New System.Drawing.Size(79, 34)
		Me.cmdBuild.Location = New System.Drawing.Point(522, 3)
		Me.cmdBuild.TabIndex = 4
		Me.cmdBuild.TabStop = False
		Me.cmdBuild.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuild.CausesValidation = True
		Me.cmdBuild.Enabled = True
		Me.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuild.Name = "cmdBuild"
		Me.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFilter.Text = "&Filter"
		Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdFilter.Size = New System.Drawing.Size(79, 34)
		Me.cmdFilter.Location = New System.Drawing.Point(522, 45)
		Me.cmdFilter.TabIndex = 8
		Me.cmdFilter.TabStop = False
		Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFilter.CausesValidation = True
		Me.cmdFilter.Enabled = True
		Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFilter.Name = "cmdFilter"
		Me.Label1.Text = "&1. Affected Stock Items"
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label1.Size = New System.Drawing.Size(135, 13)
		Me.Label1.Location = New System.Drawing.Point(18, 90)
		Me.Label1.TabIndex = 6
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_1.Text = "Applied Filter "
		Me._lbl_1.Size = New System.Drawing.Size(45, 31)
		Me._lbl_1.Location = New System.Drawing.Point(6, 54)
		Me._lbl_1.TabIndex = 2
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Enabled = True
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = False
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lbl_0.Text = "Day End Selection Criteria "
		Me._lbl_0.Size = New System.Drawing.Size(51, 40)
		Me._lbl_0.Location = New System.Drawing.Point(0, 0)
		Me._lbl_0.TabIndex = 0
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Enabled = True
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = False
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me.lblFilter.BackColor = System.Drawing.Color.White
		Me.lblFilter.Text = "Label1"
		Me.lblFilter.Size = New System.Drawing.Size(460, 37)
		Me.lblFilter.Location = New System.Drawing.Point(54, 42)
		Me.lblFilter.TabIndex = 3
		Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFilter.Enabled = True
		Me.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFilter.UseMnemonic = True
		Me.lblFilter.Visible = True
		Me.lblFilter.AutoSize = False
		Me.lblFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFilter.Name = "lblFilter"
		Me.lblDayEnd.BackColor = System.Drawing.Color.White
		Me.lblDayEnd.Text = "Label1"
		Me.lblDayEnd.Size = New System.Drawing.Size(460, 37)
		Me.lblDayEnd.Location = New System.Drawing.Point(54, 0)
		Me.lblDayEnd.TabIndex = 1
		Me.lblDayEnd.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDayEnd.Enabled = True
		Me.lblDayEnd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDayEnd.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDayEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDayEnd.UseMnemonic = True
		Me.lblDayEnd.Visible = True
		Me.lblDayEnd.AutoSize = False
		Me.lblDayEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDayEnd.Name = "lblDayEnd"
		Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_0.Size = New System.Drawing.Size(682, 355)
		Me._Shape1_0.Location = New System.Drawing.Point(6, 105)
		Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_0.BorderWidth = 1
		Me._Shape1_0.FillColor = System.Drawing.Color.Black
		Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_0.Visible = True
		Me._Shape1_0.Name = "_Shape1_0"
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(lvData)
		Me.Controls.Add(cmdBuild)
		Me.Controls.Add(cmdFilter)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lbl_1)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(lblFilter)
		Me.Controls.Add(lblDayEnd)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.Controls.Add(ShapeContainer1)
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
		Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class