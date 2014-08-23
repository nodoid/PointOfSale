<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMaintainWeight
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
	Public WithEvents cmdNew As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
    Public WithEvents grdDataGrid As myDataGridView
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _txtFields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    'Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMaintainWeight))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdNew = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.grdDataGrid = New myDataGridView
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me._txtFields_4 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me._txtFields_3 = New System.Windows.Forms.TextBox
		Me._txtFields_2 = New System.Windows.Forms.TextBox
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        'Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.picButtons.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Maintain Scale Weight Codes"
		Me.ClientSize = New System.Drawing.Size(398, 289)
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
		Me.Name = "frmMaintainWeight"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(398, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 5
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNew.Text = "&New"
		Me.cmdNew.Size = New System.Drawing.Size(79, 25)
		Me.cmdNew.Location = New System.Drawing.Point(4, 4)
		Me.cmdNew.TabIndex = 8
		Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNew.CausesValidation = True
		Me.cmdNew.Enabled = True
		Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNew.TabStop = True
		Me.cmdNew.Name = "cmdNew"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(79, 25)
		Me.cmdClose.Location = New System.Drawing.Point(312, 4)
		Me.cmdClose.TabIndex = 7
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(79, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(120, 4)
		Me.cmdCancel.TabIndex = 6
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.Frame1.Size = New System.Drawing.Size(391, 237)
		Me.Frame1.Location = New System.Drawing.Point(2, 46)
		Me.Frame1.TabIndex = 15
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
        'grdDataGrid.OcxState = CType(resources.GetObject("grdDataGrid.OcxState"), System.Windows.Forms.AxHost.State)
		Me.grdDataGrid.Size = New System.Drawing.Size(373, 217)
		Me.grdDataGrid.Location = New System.Drawing.Point(8, 14)
		Me.grdDataGrid.TabIndex = 16
		Me.grdDataGrid.Name = "grdDataGrid"
		Me.Frame2.Text = "New Weight Code"
		Me.Frame2.Size = New System.Drawing.Size(391, 237)
		Me.Frame2.Location = New System.Drawing.Point(2, 46)
		Me.Frame2.TabIndex = 9
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me._txtFields_4.AutoSize = False
		Me._txtFields_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_4.Size = New System.Drawing.Size(37, 19)
		Me._txtFields_4.Location = New System.Drawing.Point(340, 72)
		Me._txtFields_4.TabIndex = 4
		Me._txtFields_4.AcceptsReturn = True
		Me._txtFields_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_4.CausesValidation = True
		Me._txtFields_4.Enabled = True
		Me._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_4.HideSelection = True
		Me._txtFields_4.ReadOnly = False
		Me._txtFields_4.Maxlength = 0
		Me._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_4.MultiLine = False
		Me._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_4.TabStop = True
		Me._txtFields_4.Visible = True
		Me._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_4.Name = "_txtFields_4"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_1.Size = New System.Drawing.Size(37, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(340, 28)
		Me._txtFields_1.TabIndex = 2
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Maxlength = 0
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.Visible = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_1.Name = "_txtFields_1"
		Me._txtFields_3.AutoSize = False
		Me._txtFields_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_3.Size = New System.Drawing.Size(37, 19)
		Me._txtFields_3.Location = New System.Drawing.Point(340, 50)
		Me._txtFields_3.TabIndex = 3
		Me._txtFields_3.AcceptsReturn = True
		Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_3.CausesValidation = True
		Me._txtFields_3.Enabled = True
		Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_3.HideSelection = True
		Me._txtFields_3.ReadOnly = False
		Me._txtFields_3.Maxlength = 0
		Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_3.MultiLine = False
		Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_3.TabStop = True
		Me._txtFields_3.Visible = True
		Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_3.Name = "_txtFields_3"
		Me._txtFields_2.AutoSize = False
		Me._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_2.Size = New System.Drawing.Size(37, 19)
		Me._txtFields_2.Location = New System.Drawing.Point(160, 50)
		Me._txtFields_2.TabIndex = 1
		Me._txtFields_2.AcceptsReturn = True
		Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_2.CausesValidation = True
		Me._txtFields_2.Enabled = True
		Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_2.HideSelection = True
		Me._txtFields_2.ReadOnly = False
		Me._txtFields_2.Maxlength = 0
		Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_2.MultiLine = False
		Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_2.TabStop = True
		Me._txtFields_2.Visible = True
		Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_2.Name = "_txtFields_2"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_0.Size = New System.Drawing.Size(37, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(160, 28)
		Me._txtFields_0.TabIndex = 0
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Maxlength = 0
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.Visible = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._txtFields_0.Name = "_txtFields_0"
		Me.Label5.Text = "Number of Decimals"
		Me.Label5.Size = New System.Drawing.Size(131, 17)
		Me.Label5.Location = New System.Drawing.Point(204, 52)
		Me.Label5.TabIndex = 14
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Price Length"
		Me.Label4.Size = New System.Drawing.Size(135, 17)
		Me.Label4.Location = New System.Drawing.Point(16, 52)
		Me.Label4.TabIndex = 13
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Check Digit"
		Me.Label3.Size = New System.Drawing.Size(107, 17)
		Me.Label3.Location = New System.Drawing.Point(204, 74)
		Me.Label3.TabIndex = 12
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Barcode"
		Me.Label2.Size = New System.Drawing.Size(105, 17)
		Me.Label2.Location = New System.Drawing.Point(204, 32)
		Me.Label2.TabIndex = 11
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Scale Prefix"
		Me.Label1.Size = New System.Drawing.Size(111, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 10
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.Shape1.BackColor = System.Drawing.Color.FromARGB(192, 192, 255)
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me.Shape1.Size = New System.Drawing.Size(375, 209)
		Me.Shape1.Location = New System.Drawing.Point(8, 7)
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.BorderWidth = 1
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Controls.Add(picButtons)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(Frame2)
		Me.picButtons.Controls.Add(cmdNew)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.Frame1.Controls.Add(grdDataGrid)
		Me.Frame2.Controls.Add(_txtFields_4)
		Me.Frame2.Controls.Add(_txtFields_1)
		Me.Frame2.Controls.Add(_txtFields_3)
		Me.Frame2.Controls.Add(_txtFields_2)
		Me.Frame2.Controls.Add(_txtFields_0)
		Me.Frame2.Controls.Add(Label5)
		Me.Frame2.Controls.Add(Label4)
		Me.Frame2.Controls.Add(Label3)
		Me.Frame2.Controls.Add(Label2)
		Me.Frame2.Controls.Add(Label1)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Frame2.Controls.Add(ShapeContainer1)
        'Me.txtFields.SetIndex(_txtFields_4, CType(4, Short))
        'Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
        'Me.txtFields.SetIndex(_txtFields_3, CType(3, Short))
        'Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
        'Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
        'CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class