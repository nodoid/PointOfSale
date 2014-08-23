<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVprint
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
	Public WithEvents lstSupplier As System.Windows.Forms.ListBox
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents lblPath As System.Windows.Forms.Label
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents lvItems As System.Windows.Forms.ListView
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVprint))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.lstSupplier = New System.Windows.Forms.ListBox
		Me.Picture1 = New System.Windows.Forms.Panel
		Me.cmdBack = New System.Windows.Forms.Button
		Me.lblPath = New System.Windows.Forms.Label
		Me.lvItems = New System.Windows.Forms.ListView
		Me._lbl_0 = New System.Windows.Forms.Label
		Me._lbl_1 = New System.Windows.Forms.Label
		Me._Shape1_1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Shape1 = New RectangleShapeArray(components)
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ControlBox = False
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(618, 459)
		Me.Location = New System.Drawing.Point(3, 3)
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
		Me.Name = "frmGRVprint"
		Me.lstSupplier.Size = New System.Drawing.Size(151, 384)
		Me.lstSupplier.Location = New System.Drawing.Point(12, 64)
		Me.lstSupplier.TabIndex = 1
		Me.lstSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstSupplier.BackColor = System.Drawing.SystemColors.Window
		Me.lstSupplier.CausesValidation = True
		Me.lstSupplier.Enabled = True
		Me.lstSupplier.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstSupplier.IntegralHeight = True
		Me.lstSupplier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstSupplier.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstSupplier.Sorted = False
		Me.lstSupplier.TabStop = True
		Me.lstSupplier.Visible = True
		Me.lstSupplier.MultiColumn = False
		Me.lstSupplier.Name = "lstSupplier"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.Blue
		Me.Picture1.Size = New System.Drawing.Size(618, 35)
		Me.Picture1.Location = New System.Drawing.Point(0, 0)
		Me.Picture1.TabIndex = 4
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Picture1.Name = "Picture1"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "E&xit"
		Me.cmdBack.Size = New System.Drawing.Size(97, 25)
		Me.cmdBack.Location = New System.Drawing.Point(512, 3)
		Me.cmdBack.TabIndex = 6
		Me.cmdBack.TabStop = False
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.Name = "cmdBack"
		Me.lblPath.BackColor = System.Drawing.Color.Transparent
		Me.lblPath.Text = "Invoice Print"
		Me.lblPath.ForeColor = System.Drawing.Color.White
		Me.lblPath.Size = New System.Drawing.Size(100, 20)
		Me.lblPath.Location = New System.Drawing.Point(0, 0)
		Me.lblPath.TabIndex = 5
		Me.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPath.Enabled = True
		Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPath.UseMnemonic = True
		Me.lblPath.Visible = True
		Me.lblPath.AutoSize = True
		Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPath.Name = "lblPath"
		Me.lvItems.Size = New System.Drawing.Size(424, 382)
		Me.lvItems.Location = New System.Drawing.Point(183, 64)
		Me.lvItems.TabIndex = 3
		Me.lvItems.View = System.Windows.Forms.View.Details
		Me.lvItems.LabelEdit = False
		Me.lvItems.LabelWrap = True
		Me.lvItems.HideSelection = True
		Me.lvItems.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvItems.BackColor = System.Drawing.SystemColors.Window
		Me.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvItems.Name = "lvItems"
		Me._lbl_0.BackColor = System.Drawing.Color.Transparent
		Me._lbl_0.Text = "&1. Select a Supplier"
		Me._lbl_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lbl_0.Size = New System.Drawing.Size(113, 13)
		Me._lbl_0.Location = New System.Drawing.Point(9, 43)
		Me._lbl_0.TabIndex = 0
		Me._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_0.Enabled = True
		Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_0.UseMnemonic = True
		Me._lbl_0.Visible = True
		Me._lbl_0.AutoSize = True
		Me._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_0.Name = "_lbl_0"
		Me._lbl_1.BackColor = System.Drawing.Color.Transparent
		Me._lbl_1.Text = "&2. Select an Invoice"
		Me._lbl_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lbl_1.Size = New System.Drawing.Size(116, 13)
		Me._lbl_1.Location = New System.Drawing.Point(180, 43)
		Me._lbl_1.TabIndex = 2
		Me._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_1.Enabled = True
		Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_1.UseMnemonic = True
		Me._lbl_1.Visible = True
		Me._lbl_1.AutoSize = True
		Me._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_1.Name = "_lbl_1"
		Me._Shape1_1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_1.Size = New System.Drawing.Size(436, 394)
		Me._Shape1_1.Location = New System.Drawing.Point(177, 58)
		Me._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_1.BorderWidth = 1
		Me._Shape1_1.FillColor = System.Drawing.Color.Black
		Me._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_1.Visible = True
		Me._Shape1_1.Name = "_Shape1_1"
		Me._Shape1_0.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me._Shape1_0.Size = New System.Drawing.Size(163, 394)
		Me._Shape1_0.Location = New System.Drawing.Point(6, 58)
		Me._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText
		Me._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._Shape1_0.BorderWidth = 1
		Me._Shape1_0.FillColor = System.Drawing.Color.Black
		Me._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me._Shape1_0.Visible = True
		Me._Shape1_0.Name = "_Shape1_0"
		Me.Controls.Add(lstSupplier)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(lvItems)
		Me.Controls.Add(_lbl_0)
		Me.Controls.Add(_lbl_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.Controls.Add(ShapeContainer1)
		Me.Picture1.Controls.Add(cmdBack)
		Me.Picture1.Controls.Add(lblPath)
        'Me.lbl.SetIndex(_lbl_0, CType(0, Short))
        'Me.lbl.SetIndex(_lbl_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
		Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class