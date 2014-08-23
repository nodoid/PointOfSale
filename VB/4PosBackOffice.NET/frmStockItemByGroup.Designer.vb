<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStockItemByGroup
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
	Public WithEvents lstStockItem As System.Windows.Forms.ListBox
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockItemByGroup))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstStockItem = New System.Windows.Forms.ListBox
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.ControlBox = False
		Me.ClientSize = New System.Drawing.Size(473, 498)
		Me.Location = New System.Drawing.Point(4, 4)
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
		Me.Name = "frmStockItemByGroup"
		Me.lstStockItem.Size = New System.Drawing.Size(461, 407)
		Me.lstStockItem.Location = New System.Drawing.Point(6, 50)
		Me.lstStockItem.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
		Me.lstStockItem.TabIndex = 0
		Me.lstStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstStockItem.BackColor = System.Drawing.SystemColors.Window
		Me.lstStockItem.CausesValidation = True
		Me.lstStockItem.Enabled = True
		Me.lstStockItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstStockItem.IntegralHeight = True
		Me.lstStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstStockItem.Sorted = False
		Me.lstStockItem.TabStop = True
		Me.lstStockItem.Visible = True
		Me.lstStockItem.MultiColumn = False
		Me.lstStockItem.Name = "lstStockItem"
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Picture1.BackColor = System.Drawing.Color.Blue
		Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture1.Size = New System.Drawing.Size(473, 41)
		Me.Picture1.Location = New System.Drawing.Point(0, 0)
		Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
		Me.Picture1.TabIndex = 1
		Me.Picture1.TabStop = False
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture1.Name = "Picture1"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Press (A) To Select All Products"
		Me.Label1.Size = New System.Drawing.Size(461, 33)
		Me.Label1.Location = New System.Drawing.Point(6, 462)
		Me.Label1.TabIndex = 2
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(lstStockItem)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class