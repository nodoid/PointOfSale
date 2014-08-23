<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSetItem
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
	Public WithEvents _cmdClick_1 As System.Windows.Forms.Button
	Public WithEvents _cmdClick_2 As System.Windows.Forms.Button
	Public WithEvents _cmdClick_3 As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents lstStockItem As System.Windows.Forms.CheckedListBox
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents _tbStockItem_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbStockItem_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbStockItem_Button3 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbStockItem As System.Windows.Forms.ToolStrip
	Public WithEvents ilSelect As System.Windows.Forms.ImageList
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
    'Public WithEvents cmdClick As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSetItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._cmdClick_1 = New System.Windows.Forms.Button
		Me._cmdClick_2 = New System.Windows.Forms.Button
		Me._cmdClick_3 = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.lstStockItem = New System.Windows.Forms.CheckedListBox
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.tbStockItem = New System.Windows.Forms.ToolStrip
		Me._tbStockItem_Button1 = New System.Windows.Forms.ToolStripButton
		Me._tbStockItem_Button2 = New System.Windows.Forms.ToolStripButton
		Me._tbStockItem_Button3 = New System.Windows.Forms.ToolStripButton
		Me.ilSelect = New System.Windows.Forms.ImageList
		Me.lblHeading = New System.Windows.Forms.Label
		Me._lbl_2 = New System.Windows.Forms.Label
        'Me.cmdClick = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.tbStockItem.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.cmdClick, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Allocate Stock Items to Set"
		Me.ClientSize = New System.Drawing.Size(232, 458)
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
		Me.Name = "frmSetItem"
		Me._cmdClick_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdClick_1.Text = "&A"
		Me._cmdClick_1.Size = New System.Drawing.Size(103, 34)
		Me._cmdClick_1.Location = New System.Drawing.Point(303, 162)
		Me._cmdClick_1.TabIndex = 8
		Me._cmdClick_1.TabStop = False
		Me._cmdClick_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdClick_1.CausesValidation = True
		Me._cmdClick_1.Enabled = True
		Me._cmdClick_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdClick_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdClick_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdClick_1.Name = "_cmdClick_1"
		Me._cmdClick_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdClick_2.Text = "&S"
		Me._cmdClick_2.Size = New System.Drawing.Size(103, 34)
		Me._cmdClick_2.Location = New System.Drawing.Point(306, 210)
		Me._cmdClick_2.TabIndex = 7
		Me._cmdClick_2.TabStop = False
		Me._cmdClick_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdClick_2.CausesValidation = True
		Me._cmdClick_2.Enabled = True
		Me._cmdClick_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdClick_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdClick_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdClick_2.Name = "_cmdClick_2"
		Me._cmdClick_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdClick_3.Text = "&U"
		Me._cmdClick_3.Size = New System.Drawing.Size(103, 34)
		Me._cmdClick_3.Location = New System.Drawing.Point(297, 261)
		Me._cmdClick_3.TabIndex = 6
		Me._cmdClick_3.TabStop = False
		Me._cmdClick_3.BackColor = System.Drawing.SystemColors.Control
		Me._cmdClick_3.CausesValidation = True
		Me._cmdClick_3.Enabled = True
		Me._cmdClick_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdClick_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdClick_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdClick_3.Name = "_cmdClick_3"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(126, 393)
		Me.cmdExit.TabIndex = 4
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me.lstStockItem.Size = New System.Drawing.Size(214, 304)
		Me.lstStockItem.Location = New System.Drawing.Point(9, 81)
		Me.lstStockItem.Sorted = True
		Me.lstStockItem.TabIndex = 1
		Me.lstStockItem.Tag = "0"
		Me.lstStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstStockItem.BackColor = System.Drawing.SystemColors.Window
		Me.lstStockItem.CausesValidation = True
		Me.lstStockItem.Enabled = True
		Me.lstStockItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstStockItem.IntegralHeight = True
		Me.lstStockItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstStockItem.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstStockItem.TabStop = True
		Me.lstStockItem.Visible = True
		Me.lstStockItem.MultiColumn = False
		Me.lstStockItem.Name = "lstStockItem"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(175, 19)
		Me.txtSearch.Location = New System.Drawing.Point(48, 57)
		Me.txtSearch.TabIndex = 0
		Me.txtSearch.AcceptsReturn = True
		Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch.CausesValidation = True
		Me.txtSearch.Enabled = True
		Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch.HideSelection = True
		Me.txtSearch.ReadOnly = False
		Me.txtSearch.Maxlength = 0
		Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch.MultiLine = False
		Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch.TabStop = True
		Me.txtSearch.Visible = True
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch.Name = "txtSearch"
		Me.tbStockItem.ShowItemToolTips = True
		Me.tbStockItem.Size = New System.Drawing.Size(224, 40)
		Me.tbStockItem.Location = New System.Drawing.Point(0, 18)
		Me.tbStockItem.TabIndex = 2
		Me.tbStockItem.ImageList = ilSelect
		Me.tbStockItem.Name = "tbStockItem"
		Me._tbStockItem_Button1.Size = New System.Drawing.Size(68, 41)
		Me._tbStockItem_Button1.AutoSize = False
		Me._tbStockItem_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbStockItem_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbStockItem_Button1.Text = "&All"
		Me._tbStockItem_Button1.Name = "All"
		Me._tbStockItem_Button1.ImageIndex = 0
		Me._tbStockItem_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbStockItem_Button2.Size = New System.Drawing.Size(68, 41)
		Me._tbStockItem_Button2.AutoSize = False
		Me._tbStockItem_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbStockItem_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbStockItem_Button2.Text = "&Selected"
		Me._tbStockItem_Button2.Name = "Selected"
		Me._tbStockItem_Button2.ImageIndex = 1
		Me._tbStockItem_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbStockItem_Button3.Size = New System.Drawing.Size(68, 41)
		Me._tbStockItem_Button3.AutoSize = False
		Me._tbStockItem_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbStockItem_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbStockItem_Button3.Text = "&Unselected"
		Me._tbStockItem_Button3.Name = "Unselected"
		Me._tbStockItem_Button3.ImageIndex = 2
		Me._tbStockItem_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.ilSelect.ImageSize = New System.Drawing.Size(20, 20)
		Me.ilSelect.TransparentColor = System.Drawing.Color.FromARGB(255, 0, 255)
		Me.ilSelect.ImageStream = CType(resources.GetObject("ilSelect.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ilSelect.Images.SetKeyName(0, "")
		Me.ilSelect.Images.SetKeyName(1, "")
		Me.ilSelect.Images.SetKeyName(2, "")
		Me.lblHeading.Text = "Label1"
		Me.lblHeading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblHeading.Size = New System.Drawing.Size(226, 19)
		Me.lblHeading.Location = New System.Drawing.Point(0, 0)
		Me.lblHeading.TabIndex = 5
		Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
		Me.lblHeading.Enabled = True
		Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeading.UseMnemonic = True
		Me.lblHeading.Visible = True
		Me.lblHeading.AutoSize = False
		Me.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeading.Name = "lblHeading"
		Me._lbl_2.Text = "Search:"
		Me._lbl_2.Size = New System.Drawing.Size(40, 13)
		Me._lbl_2.Location = New System.Drawing.Point(6, 60)
		Me._lbl_2.TabIndex = 3
		Me._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbl_2.BackColor = System.Drawing.Color.Transparent
		Me._lbl_2.Enabled = True
		Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbl_2.UseMnemonic = True
		Me._lbl_2.Visible = True
		Me._lbl_2.AutoSize = False
		Me._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbl_2.Name = "_lbl_2"
		Me.Controls.Add(_cmdClick_1)
		Me.Controls.Add(_cmdClick_2)
		Me.Controls.Add(_cmdClick_3)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(lstStockItem)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(tbStockItem)
		Me.Controls.Add(lblHeading)
		Me.Controls.Add(_lbl_2)
		Me.tbStockItem.Items.Add(_tbStockItem_Button1)
		Me.tbStockItem.Items.Add(_tbStockItem_Button2)
		Me.tbStockItem.Items.Add(_tbStockItem_Button3)
        'Me.cmdClick.SetIndex(_cmdClick_1, CType(1, Short))
        'Me.cmdClick.SetIndex(_cmdClick_2, CType(2, Short))
        'Me.cmdClick.SetIndex(_cmdClick_3, CType(3, Short))
        'Me.lbl.SetIndex(_lbl_2, CType(2, Short))
        'CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdClick, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tbStockItem.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class