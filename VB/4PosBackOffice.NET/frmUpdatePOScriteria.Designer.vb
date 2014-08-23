<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUpdatePOScriteria
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
	Public WithEvents tmrDeposit As System.Windows.Forms.Timer
	Public WithEvents tmrMEndUpdatePOS As System.Windows.Forms.Timer
	Public WithEvents cmdBuildChanges As System.Windows.Forms.Button
	Public WithEvents _Label3_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _frmType_0 As System.Windows.Forms.GroupBox
	Public WithEvents tmrDuplicate As System.Windows.Forms.Timer
	Public WithEvents _cmdType_2 As System.Windows.Forms.Button
	Public WithEvents _cmdType_1 As System.Windows.Forms.Button
	Public WithEvents _cmdType_0 As System.Windows.Forms.Button
	Public WithEvents cmdBuildFilter As System.Windows.Forms.Button
	Public WithEvents cmdNamespace As System.Windows.Forms.Button
	Public WithEvents lblHeading As System.Windows.Forms.Label
	Public WithEvents _frmType_1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents cmdBuildAll As System.Windows.Forms.Button
	Public WithEvents _Label3_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _frmType_2 As System.Windows.Forms.GroupBox
	Public WithEvents Label2 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents Label3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents cmdType As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents frmType As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdatePOScriteria))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmrDeposit = New System.Windows.Forms.Timer(components)
		Me.tmrMEndUpdatePOS = New System.Windows.Forms.Timer(components)
		Me._frmType_0 = New System.Windows.Forms.GroupBox
		Me.cmdBuildChanges = New System.Windows.Forms.Button
		Me._Label3_0 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.tmrDuplicate = New System.Windows.Forms.Timer(components)
		Me._cmdType_2 = New System.Windows.Forms.Button
		Me._cmdType_1 = New System.Windows.Forms.Button
		Me._cmdType_0 = New System.Windows.Forms.Button
		Me._frmType_1 = New System.Windows.Forms.GroupBox
		Me.cmdBuildFilter = New System.Windows.Forms.Button
		Me.cmdNamespace = New System.Windows.Forms.Button
		Me.lblHeading = New System.Windows.Forms.Label
		Me.cmdExit = New System.Windows.Forms.Button
		Me._frmType_2 = New System.Windows.Forms.GroupBox
		Me.cmdBuildAll = New System.Windows.Forms.Button
		Me._Label3_1 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.Label3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.cmdType = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.frmType = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
		Me._frmType_0.SuspendLayout()
		Me._frmType_1.SuspendLayout()
		Me._frmType_2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cmdType, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.frmType, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Selection Criteria for Point Of Sale Update"
		Me.ClientSize = New System.Drawing.Size(508, 335)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmUpdatePOScriteria"
		Me.tmrDeposit.Enabled = False
		Me.tmrDeposit.Interval = 10
		Me.tmrMEndUpdatePOS.Enabled = False
		Me.tmrMEndUpdatePOS.Interval = 10
		Me._frmType_0.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me._frmType_0.Text = "Option One (Update POS Changes)"
		Me._frmType_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmType_0.Size = New System.Drawing.Size(382, 196)
		Me._frmType_0.Location = New System.Drawing.Point(8, 50)
		Me._frmType_0.TabIndex = 4
		Me._frmType_0.Enabled = True
		Me._frmType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmType_0.Visible = True
		Me._frmType_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmType_0.Name = "_frmType_0"
		Me.cmdBuildChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuildChanges.Text = "&View and Update changes >>"
		Me.cmdBuildChanges.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBuildChanges.Size = New System.Drawing.Size(178, 52)
		Me.cmdBuildChanges.Location = New System.Drawing.Point(180, 132)
		Me.cmdBuildChanges.TabIndex = 6
		Me.cmdBuildChanges.TabStop = False
		Me.cmdBuildChanges.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuildChanges.CausesValidation = True
		Me.cmdBuildChanges.Enabled = True
		Me.cmdBuildChanges.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuildChanges.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuildChanges.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuildChanges.Name = "cmdBuildChanges"
		Me._Label3_0.Text = "Click on the ""View and Update changes >>"" button to continue."
		Me._Label3_0.Size = New System.Drawing.Size(157, 46)
		Me._Label3_0.Location = New System.Drawing.Point(12, 144)
		Me._Label3_0.TabIndex = 15
		Me._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_0.BackColor = System.Drawing.Color.Transparent
		Me._Label3_0.Enabled = True
		Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_0.UseMnemonic = True
		Me._Label3_0.Visible = True
		Me._Label3_0.AutoSize = False
		Me._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_0.Name = "_Label3_0"
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Text = "As you make changes to your catalogue by the use of the Stock Item, Pricing, Deposit and Pricing Group maintenance screens, the system records these changes and allows you to quickly update just the known changes to the ""Point Of Sale"" devices."
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Label1_0.Size = New System.Drawing.Size(316, 70)
		Me._Label1_0.Location = New System.Drawing.Point(30, 36)
		Me._Label1_0.TabIndex = 5
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.tmrDuplicate.Enabled = False
		Me.tmrDuplicate.Interval = 10
		Me._cmdType_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdType_2.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._cmdType_2.Text = "&3. Update All"
		Me._cmdType_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._cmdType_2.Size = New System.Drawing.Size(121, 31)
		Me._cmdType_2.Location = New System.Drawing.Point(267, 264)
		Me._cmdType_2.TabIndex = 10
		Me._cmdType_2.CausesValidation = True
		Me._cmdType_2.Enabled = True
		Me._cmdType_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdType_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdType_2.TabStop = True
		Me._cmdType_2.Name = "_cmdType_2"
		Me._cmdType_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdType_1.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._cmdType_1.Text = "&2. Update by Filter"
		Me._cmdType_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._cmdType_1.Size = New System.Drawing.Size(124, 31)
		Me._cmdType_1.Location = New System.Drawing.Point(134, 262)
		Me._cmdType_1.TabIndex = 9
		Me._cmdType_1.CausesValidation = True
		Me._cmdType_1.Enabled = True
		Me._cmdType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdType_1.TabStop = True
		Me._cmdType_1.Name = "_cmdType_1"
		Me._cmdType_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdType_0.BackColor = System.Drawing.Color.FromARGB(192, 255, 192)
		Me._cmdType_0.Text = "&1. Changes Only"
		Me._cmdType_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._cmdType_0.Size = New System.Drawing.Size(121, 31)
		Me._cmdType_0.Location = New System.Drawing.Point(6, 264)
		Me._cmdType_0.TabIndex = 8
		Me._cmdType_0.CausesValidation = True
		Me._cmdType_0.Enabled = True
		Me._cmdType_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdType_0.TabStop = True
		Me._cmdType_0.Name = "_cmdType_0"
		Me._frmType_1.BackColor = System.Drawing.Color.FromARGB(255, 255, 192)
		Me._frmType_1.Text = "Update POS by a filter"
		Me._frmType_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmType_1.Size = New System.Drawing.Size(382, 196)
		Me._frmType_1.Location = New System.Drawing.Point(99, 72)
		Me._frmType_1.TabIndex = 1
		Me._frmType_1.Enabled = True
		Me._frmType_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmType_1.Visible = True
		Me._frmType_1.Padding = New System.Windows.Forms.Padding(0)
		Me._frmType_1.Name = "_frmType_1"
		Me.cmdBuildFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuildFilter.Text = "&View and Update changes >>"
		Me.cmdBuildFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBuildFilter.Size = New System.Drawing.Size(178, 52)
		Me.cmdBuildFilter.Location = New System.Drawing.Point(180, 132)
		Me.cmdBuildFilter.TabIndex = 7
		Me.cmdBuildFilter.TabStop = False
		Me.cmdBuildFilter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuildFilter.CausesValidation = True
		Me.cmdBuildFilter.Enabled = True
		Me.cmdBuildFilter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuildFilter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuildFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuildFilter.Name = "cmdBuildFilter"
		Me.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNamespace.Text = "&Filter"
		Me.cmdNamespace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdNamespace.Size = New System.Drawing.Size(97, 52)
		Me.cmdNamespace.Location = New System.Drawing.Point(9, 132)
		Me.cmdNamespace.TabIndex = 2
		Me.cmdNamespace.TabStop = False
		Me.cmdNamespace.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNamespace.CausesValidation = True
		Me.cmdNamespace.Enabled = True
		Me.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNamespace.Name = "cmdNamespace"
		Me.lblHeading.Text = "Using the ""Stock Item Selector"" ....."
		Me.lblHeading.Size = New System.Drawing.Size(349, 106)
		Me.lblHeading.Location = New System.Drawing.Point(9, 18)
		Me.lblHeading.TabIndex = 3
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
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(97, 52)
		Me.cmdExit.Location = New System.Drawing.Point(406, 8)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		Me._frmType_2.BackColor = System.Drawing.Color.FromARGB(255, 192, 192)
		Me._frmType_2.Text = "Option Three (Check Data Integrity)"
		Me._frmType_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._frmType_2.Size = New System.Drawing.Size(382, 196)
		Me._frmType_2.Location = New System.Drawing.Point(63, 129)
		Me._frmType_2.TabIndex = 11
		Me._frmType_2.Enabled = True
		Me._frmType_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmType_2.Visible = True
		Me._frmType_2.Padding = New System.Windows.Forms.Padding(0)
		Me._frmType_2.Name = "_frmType_2"
		Me.cmdBuildAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBuildAll.Text = "&View and Update changes >>"
		Me.cmdBuildAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.cmdBuildAll.Size = New System.Drawing.Size(178, 52)
		Me.cmdBuildAll.Location = New System.Drawing.Point(180, 132)
		Me.cmdBuildAll.TabIndex = 12
		Me.cmdBuildAll.TabStop = False
		Me.cmdBuildAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBuildAll.CausesValidation = True
		Me.cmdBuildAll.Enabled = True
		Me.cmdBuildAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBuildAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBuildAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBuildAll.Name = "cmdBuildAll"
		Me._Label3_1.Text = "Click on the ""View and Update changes >>"" button to continue."
		Me._Label3_1.Size = New System.Drawing.Size(157, 46)
		Me._Label3_1.Location = New System.Drawing.Point(12, 144)
		Me._Label3_1.TabIndex = 16
		Me._Label3_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label3_1.BackColor = System.Drawing.Color.Transparent
		Me._Label3_1.Enabled = True
		Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label3_1.UseMnemonic = True
		Me._Label3_1.Visible = True
		Me._Label3_1.AutoSize = False
		Me._Label3_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label3_1.Name = "_Label3_1"
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Text = "This option will check all your data for changes. The reason for using this option would be to thoroughly check all your data to make sure that your data integrity is correct."
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._Label1_1.Size = New System.Drawing.Size(316, 70)
		Me._Label1_1.Location = New System.Drawing.Point(30, 36)
		Me._Label1_1.TabIndex = 13
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.Enabled = True
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me.Label2.Text = "You may set the Point Of Sale update instruction with one of three methods. Each offering a different update type. By click on the buttons below you will be able to switch between each of these options."
		Me.Label2.Size = New System.Drawing.Size(370, 49)
		Me.Label2.Location = New System.Drawing.Point(18, 6)
		Me.Label2.TabIndex = 14
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
		Me.Controls.Add(_frmType_0)
		Me.Controls.Add(_cmdType_2)
		Me.Controls.Add(_cmdType_1)
		Me.Controls.Add(_cmdType_0)
		Me.Controls.Add(_frmType_1)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_frmType_2)
		Me.Controls.Add(Label2)
		Me._frmType_0.Controls.Add(cmdBuildChanges)
		Me._frmType_0.Controls.Add(_Label3_0)
		Me._frmType_0.Controls.Add(_Label1_0)
		Me._frmType_1.Controls.Add(cmdBuildFilter)
		Me._frmType_1.Controls.Add(cmdNamespace)
		Me._frmType_1.Controls.Add(lblHeading)
		Me._frmType_2.Controls.Add(cmdBuildAll)
		Me._frmType_2.Controls.Add(_Label3_1)
		Me._frmType_2.Controls.Add(_Label1_1)
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label3.SetIndex(_Label3_0, CType(0, Short))
        'Me.Label3.SetIndex(_Label3_1, CType(1, Short))
        'Me.cmdType.SetIndex(_cmdType_2, CType(2, Short))
        'Me.cmdType.SetIndex(_cmdType_1, CType(1, Short))
        'Me.cmdType.SetIndex(_cmdType_0, CType(0, Short))
        'Me.frmType.SetIndex(_frmType_0, CType(0, Short))
        'Me.frmType.SetIndex(_frmType_1, CType(1, Short))
        'Me.frmType.SetIndex(_frmType_2, CType(2, Short))
        'CType(Me.frmType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdType, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmType_0.ResumeLayout(False)
		Me._frmType_1.ResumeLayout(False)
		Me._frmType_2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class