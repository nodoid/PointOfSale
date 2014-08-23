<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSerialNumber
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
	Public WithEvents txtRtd As System.Windows.Forms.TextBox
	Public WithEvents txtItem As System.Windows.Forms.TextBox
	Public WithEvents txtCode As System.Windows.Forms.TextBox
	Public WithEvents txtQty As System.Windows.Forms.TextBox
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdRemove As System.Windows.Forms.Button
	Public WithEvents lstSerial As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents txtSerialNbr As System.Windows.Forms.TextBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSerialNumber))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtRtd = New System.Windows.Forms.TextBox
		Me.txtItem = New System.Windows.Forms.TextBox
		Me.txtCode = New System.Windows.Forms.TextBox
		Me.txtQty = New System.Windows.Forms.TextBox
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdRemove = New System.Windows.Forms.Button
		Me.lstSerial = New System.Windows.Forms.CheckedListBox
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.txtSerialNbr = New System.Windows.Forms.TextBox
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.Frame1.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Serial Number Entry"
		Me.ClientSize = New System.Drawing.Size(322, 457)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSerialNumber"
		Me.Frame1.Size = New System.Drawing.Size(313, 415)
		Me.Frame1.Location = New System.Drawing.Point(4, 40)
		Me.Frame1.TabIndex = 2
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.txtRtd.AutoSize = False
		Me.txtRtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtRtd.Enabled = False
		Me.txtRtd.Size = New System.Drawing.Size(39, 19)
		Me.txtRtd.Location = New System.Drawing.Point(262, 76)
		Me.txtRtd.TabIndex = 17
		Me.txtRtd.AcceptsReturn = True
		Me.txtRtd.BackColor = System.Drawing.SystemColors.Window
		Me.txtRtd.CausesValidation = True
		Me.txtRtd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRtd.HideSelection = True
		Me.txtRtd.ReadOnly = False
		Me.txtRtd.Maxlength = 0
		Me.txtRtd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRtd.MultiLine = False
		Me.txtRtd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRtd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRtd.TabStop = True
		Me.txtRtd.Visible = True
		Me.txtRtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtRtd.Name = "txtRtd"
		Me.txtItem.AutoSize = False
		Me.txtItem.Size = New System.Drawing.Size(195, 19)
		Me.txtItem.Location = New System.Drawing.Point(106, 16)
		Me.txtItem.TabIndex = 15
		Me.txtItem.AcceptsReturn = True
		Me.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtItem.BackColor = System.Drawing.SystemColors.Window
		Me.txtItem.CausesValidation = True
		Me.txtItem.Enabled = True
		Me.txtItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtItem.HideSelection = True
		Me.txtItem.ReadOnly = False
		Me.txtItem.Maxlength = 0
		Me.txtItem.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtItem.MultiLine = False
		Me.txtItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtItem.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtItem.TabStop = True
		Me.txtItem.Visible = True
		Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtItem.Name = "txtItem"
		Me.txtCode.AutoSize = False
		Me.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtCode.Enabled = False
		Me.txtCode.Size = New System.Drawing.Size(39, 19)
		Me.txtCode.Location = New System.Drawing.Point(106, 36)
		Me.txtCode.TabIndex = 13
		Me.txtCode.AcceptsReturn = True
		Me.txtCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtCode.CausesValidation = True
		Me.txtCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCode.HideSelection = True
		Me.txtCode.ReadOnly = False
		Me.txtCode.Maxlength = 0
		Me.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCode.MultiLine = False
		Me.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCode.TabStop = True
		Me.txtCode.Visible = True
		Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtCode.Name = "txtCode"
		Me.txtQty.AutoSize = False
		Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtQty.Enabled = False
		Me.txtQty.Size = New System.Drawing.Size(39, 19)
		Me.txtQty.Location = New System.Drawing.Point(106, 76)
		Me.txtQty.TabIndex = 10
		Me.txtQty.AcceptsReturn = True
		Me.txtQty.BackColor = System.Drawing.SystemColors.Window
		Me.txtQty.CausesValidation = True
		Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQty.HideSelection = True
		Me.txtQty.ReadOnly = False
		Me.txtQty.Maxlength = 0
		Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQty.MultiLine = False
		Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQty.TabStop = True
		Me.txtQty.Visible = True
		Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtQty.Name = "txtQty"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "Update"
		Me.cmdUpdate.Size = New System.Drawing.Size(83, 21)
		Me.cmdUpdate.Location = New System.Drawing.Point(226, 388)
		Me.cmdUpdate.TabIndex = 9
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.TabStop = True
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRemove.Text = "Remove"
		Me.cmdRemove.Size = New System.Drawing.Size(83, 25)
		Me.cmdRemove.Location = New System.Drawing.Point(226, 360)
		Me.cmdRemove.TabIndex = 8
		Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRemove.CausesValidation = True
		Me.cmdRemove.Enabled = True
		Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRemove.TabStop = True
		Me.cmdRemove.Name = "cmdRemove"
		Me.lstSerial.Size = New System.Drawing.Size(159, 238)
		Me.lstSerial.Location = New System.Drawing.Point(4, 170)
		Me.lstSerial.TabIndex = 6
		Me.lstSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstSerial.BackColor = System.Drawing.SystemColors.Window
		Me.lstSerial.CausesValidation = True
		Me.lstSerial.Enabled = True
		Me.lstSerial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstSerial.IntegralHeight = True
		Me.lstSerial.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstSerial.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstSerial.Sorted = False
		Me.lstSerial.TabStop = True
		Me.lstSerial.Visible = True
		Me.lstSerial.MultiColumn = False
		Me.lstSerial.Name = "lstSerial"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "Add"
		Me.cmdAdd.Size = New System.Drawing.Size(83, 23)
		Me.cmdAdd.Location = New System.Drawing.Point(220, 122)
		Me.cmdAdd.TabIndex = 5
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.txtSerialNbr.AutoSize = False
		Me.txtSerialNbr.Size = New System.Drawing.Size(195, 19)
		Me.txtSerialNbr.Location = New System.Drawing.Point(106, 98)
		Me.txtSerialNbr.TabIndex = 4
		Me.txtSerialNbr.AcceptsReturn = True
		Me.txtSerialNbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSerialNbr.BackColor = System.Drawing.SystemColors.Window
		Me.txtSerialNbr.CausesValidation = True
		Me.txtSerialNbr.Enabled = True
		Me.txtSerialNbr.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSerialNbr.HideSelection = True
		Me.txtSerialNbr.ReadOnly = False
		Me.txtSerialNbr.Maxlength = 0
		Me.txtSerialNbr.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSerialNbr.MultiLine = False
		Me.txtSerialNbr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSerialNbr.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSerialNbr.TabStop = True
		Me.txtSerialNbr.Visible = True
		Me.txtSerialNbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSerialNbr.Name = "txtSerialNbr"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label8.Text = "All Items that are being returned should be checked"
		Me.Label8.Size = New System.Drawing.Size(141, 31)
		Me.Label8.Location = New System.Drawing.Point(168, 170)
		Me.Label8.TabIndex = 20
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Returned"
		Me.Label7.Size = New System.Drawing.Size(59, 17)
		Me.Label7.Location = New System.Drawing.Point(202, 78)
		Me.Label7.TabIndex = 19
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Recieved"
		Me.Label6.Size = New System.Drawing.Size(59, 17)
		Me.Label6.Location = New System.Drawing.Point(44, 78)
		Me.Label6.TabIndex = 18
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Item Name"
		Me.Label5.Size = New System.Drawing.Size(83, 17)
		Me.Label5.Location = New System.Drawing.Point(4, 18)
		Me.Label5.TabIndex = 14
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Item Code"
		Me.Label4.Size = New System.Drawing.Size(93, 17)
		Me.Label4.Location = New System.Drawing.Point(4, 38)
		Me.Label4.TabIndex = 12
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Quantity"
		Me.Label3.Size = New System.Drawing.Size(71, 17)
		Me.Label3.Location = New System.Drawing.Point(4, 58)
		Me.Label3.TabIndex = 11
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Line1.BorderWidth = 2
		Me.Line1.X1 = 4
		Me.Line1.X2 = 306
		Me.Line1.Y1 = 137
		Me.Line1.Y2 = 137
		Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line1.Visible = True
		Me.Line1.Name = "Line1"
		Me.Label2.Text = "List Of Serial Number"
		Me.Label2.Size = New System.Drawing.Size(159, 17)
		Me.Label2.Location = New System.Drawing.Point(4, 154)
		Me.Label2.TabIndex = 7
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Serial Number"
		Me.Label1.Size = New System.Drawing.Size(91, 17)
		Me.Label1.Location = New System.Drawing.Point(4, 100)
		Me.Label1.TabIndex = 3
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(322, 38)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 0
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "IMPORT >> "
		Me.Command1.Size = New System.Drawing.Size(91, 27)
		Me.Command1.Location = New System.Drawing.Point(8, 4)
		Me.Command1.TabIndex = 21
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "<< BACK "
		Me.cmdBack.Size = New System.Drawing.Size(91, 27)
		Me.cmdBack.Location = New System.Drawing.Point(222, 4)
		Me.cmdBack.TabIndex = 16
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.TabStop = True
		Me.cmdBack.Name = "cmdBack"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "E&xit"
		Me.cmdClose.Size = New System.Drawing.Size(73, 29)
		Me.cmdClose.Location = New System.Drawing.Point(576, 3)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.TabStop = False
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(picButtons)
		Me.Frame1.Controls.Add(txtRtd)
		Me.Frame1.Controls.Add(txtItem)
		Me.Frame1.Controls.Add(txtCode)
		Me.Frame1.Controls.Add(txtQty)
		Me.Frame1.Controls.Add(cmdUpdate)
		Me.Frame1.Controls.Add(cmdRemove)
		Me.Frame1.Controls.Add(lstSerial)
		Me.Frame1.Controls.Add(cmdAdd)
		Me.Frame1.Controls.Add(txtSerialNbr)
		Me.Frame1.Controls.Add(Label8)
		Me.Frame1.Controls.Add(Label7)
		Me.Frame1.Controls.Add(Label6)
		Me.Frame1.Controls.Add(Label5)
		Me.Frame1.Controls.Add(Label4)
		Me.Frame1.Controls.Add(Label3)
		Me.ShapeContainer1.Shapes.Add(Line1)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		Me.Frame1.Controls.Add(ShapeContainer1)
		Me.picButtons.Controls.Add(Command1)
		Me.picButtons.Controls.Add(cmdBack)
		Me.picButtons.Controls.Add(cmdClose)
		Me.Frame1.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class