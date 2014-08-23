<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmQuoteDelete
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
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents lvData As System.Windows.Forms.ListView
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Shape1_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Shape1 As RectangleShapeArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmQuoteDelete))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.lvData = New System.Windows.Forms.ListView
		Me.Label1 = New System.Windows.Forms.Label
		Me._Shape1_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Shape1 = New RectangleShapeArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Delete unwanted quotes"
		Me.ClientSize = New System.Drawing.Size(695, 473)
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
		Me.Name = "frmQuoteDelete"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Delete"
		Me.cmdDelete.Size = New System.Drawing.Size(79, 34)
		Me.cmdDelete.Location = New System.Drawing.Point(3, 3)
		Me.cmdDelete.TabIndex = 3
		Me.cmdDelete.TabStop = False
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 34)
		Me.cmdExit.Location = New System.Drawing.Point(609, 3)
		Me.cmdExit.TabIndex = 2
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.lvData.Size = New System.Drawing.Size(664, 337)
		Me.lvData.Location = New System.Drawing.Point(15, 114)
		Me.lvData.TabIndex = 1
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
		Me.Label1.Text = "&1. Affected Stock Items"
		Me.Label1.Size = New System.Drawing.Size(135, 13)
		Me.Label1.Location = New System.Drawing.Point(18, 90)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(cmdDelete)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(lvData)
		Me.Controls.Add(Label1)
		Me.ShapeContainer1.Shapes.Add(_Shape1_0)
		Me.Controls.Add(ShapeContainer1)
		Me.Shape1.SetIndex(_Shape1_0, CType(0, Short))
		CType(Me.Shape1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class