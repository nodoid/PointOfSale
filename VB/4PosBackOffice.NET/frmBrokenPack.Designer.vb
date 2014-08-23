<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBrokenPack
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
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmbSize As System.Windows.Forms.ComboBox
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents cmdBuild As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents _Line1_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _Line1_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
    'Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Line1 As LineShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBrokenPack))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmbSize = New System.Windows.Forms.ComboBox
		Me.cmdFilter = New System.Windows.Forms.Button
		Me.cmdBuild = New System.Windows.Forms.Button
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me._Line1_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._Line1_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._Label2_1 = New System.Windows.Forms.Label
		Me.lblHeading = New System.Windows.Forms.Label
		Me._Label2_0 = New System.Windows.Forms.Label
        'Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Line1 = New LineShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = " "
		Me.ClientSize = New System.Drawing.Size(515, 332)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmBrokenPack"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(106, 46)
		Me.cmdPrint.Location = New System.Drawing.Point(276, 273)
		Me.cmdPrint.TabIndex = 5
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmbSize.Size = New System.Drawing.Size(229, 21)
		Me.cmbSize.Location = New System.Drawing.Point(21, 225)
		Me.cmbSize.Items.AddRange(New Object(){"Rebuild all broken packs", "1 case", "3/4 of a case", "2/3 of a case", "1/2 a case", "1/3 of a case", "1/4 of a case"})
		Me.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSize.TabIndex = 4
		Me.cmbSize.BackColor = System.Drawing.SystemColors.Window
		Me.cmbSize.CausesValidation = True
		Me.cmbSize.Enabled = True
		Me.cmbSize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbSize.IntegralHeight = True
		Me.cmbSize.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbSize.Sorted = False
		Me.cmbSize.TabStop = True
		Me.cmbSize.Visible = True
		Me.cmbSize.Name = "cmbSize"
		Me.cmdFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFilter.Text = "&Filter"
		Me.cmdFilter.Size = New System.Drawing.Size(79, 49)
		Me.cmdFilter.Location = New System.Drawing.Point(423, 123)
		Me.cmdFilter.TabIndex = 2
		Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFilter.CausesValidation = True
		Me.cmdFilter.Enabled = True
		Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFilter.TabStop = True
		Me.cmdFilter.Name = "cmdFilter"
		Me.cmdBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuild.Text = "&Execute"
		Me.cmdBuild.Size = New System.Drawing.Size(106, 46)
		Me.cmdBuild.Location = New System.Drawing.Point(396, 273)
		Me.cmdBuild.TabIndex = 6
		Me.cmdBuild.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuild.CausesValidation = True
		Me.cmdBuild.Enabled = True
		Me.cmdBuild.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuild.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuild.TabStop = True
		Me.cmdBuild.Name = "cmdBuild"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.SystemColors.Window
		Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture1.Size = New System.Drawing.Size(515, 76)
		Me.Picture1.Location = New System.Drawing.Point(0, 0)
		Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
		Me.Picture1.TabIndex = 7
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Picture1.Name = "Picture1"
		Me._Line1_1.X1 = 21
		Me._Line1_1.X2 = 505
		Me._Line1_1.Y1 = 255
		Me._Line1_1.Y2 = 255
		Me._Line1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Line1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Line1_1.BorderWidth = 1
		Me._Line1_1.Visible = True
		Me._Line1_1.Name = "_Line1_1"
		Me._Line1_0.X1 = 21
		Me._Line1_0.X2 = 505
		Me._Line1_0.Y1 = 186
		Me._Line1_0.Y2 = 186
		Me._Line1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Line1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Line1_0.BorderWidth = 1
		Me._Line1_0.Visible = True
		Me._Line1_0.Name = "_Line1_0"
		Me._Label2_1.Text = "If you have not sold what proportion of a case in the last ten days then break the case so as to order as single unit ..."
		Me._Label2_1.Size = New System.Drawing.Size(478, 40)
		Me._Label2_1.Location = New System.Drawing.Point(21, 195)
		Me._Label2_1.TabIndex = 3
		Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_1.BackColor = System.Drawing.Color.Transparent
		Me._Label2_1.Enabled = True
		Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_1.UseMnemonic = True
		Me._Label2_1.Visible = True
		Me._Label2_1.AutoSize = False
		Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_1.Name = "_Label2_1"
		Me.lblHeading.BackColor = System.Drawing.Color.White
		Me.lblHeading.Size = New System.Drawing.Size(391, 49)
		Me.lblHeading.Location = New System.Drawing.Point(21, 123)
		Me.lblHeading.TabIndex = 1
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
		Me._Label2_0.Text = "Some suppliers do not allow you to order ""broken packs"". For example you may not order a single unit of ""Coca-cola 340ml can"". To allow liquid to assist in determining which stock items you require as a single order quantity, click on the ""Filter"" button to create an exclusion list."
		Me._Label2_0.Size = New System.Drawing.Size(478, 40)
		Me._Label2_0.Location = New System.Drawing.Point(21, 81)
		Me._Label2_0.TabIndex = 0
		Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_0.BackColor = System.Drawing.Color.Transparent
		Me._Label2_0.Enabled = True
		Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_0.UseMnemonic = True
		Me._Label2_0.Visible = True
		Me._Label2_0.AutoSize = False
		Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_0.Name = "_Label2_0"
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(cmbSize)
		Me.Controls.Add(cmdFilter)
		Me.Controls.Add(cmdBuild)
		Me.Controls.Add(Picture1)
		Me.ShapeContainer1.Shapes.Add(_Line1_1)
		Me.ShapeContainer1.Shapes.Add(_Line1_0)
		Me.Controls.Add(_Label2_1)
		Me.Controls.Add(lblHeading)
		Me.Controls.Add(_Label2_0)
		Me.Controls.Add(ShapeContainer1)
        'Me.Label2.SetIndex(_Label2_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_0, CType(0, Short))
		Me.Line1.SetIndex(_Line1_1, CType(1, Short))
		Me.Line1.SetIndex(_Line1_0, CType(0, Short))
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class