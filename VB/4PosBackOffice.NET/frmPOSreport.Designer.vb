<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPOSreport
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
	Public WithEvents chkNoCon As System.Windows.Forms.CheckBox
	Public WithEvents chkOutCon As System.Windows.Forms.CheckBox
	Public WithEvents chkSum As System.Windows.Forms.CheckBox
	Public WithEvents chkFC As System.Windows.Forms.CheckBox
	Public WithEvents lstSaleref As System.Windows.Forms.CheckedListBox
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents chkReversal As System.Windows.Forms.CheckBox
	Public WithEvents chkRevoke As System.Windows.Forms.CheckBox
	Public WithEvents lstPOS As System.Windows.Forms.CheckedListBox
	Public WithEvents lstChannel As System.Windows.Forms.CheckedListBox
	Public WithEvents lstPerson As System.Windows.Forms.CheckedListBox
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPOSreport))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chkNoCon = New System.Windows.Forms.CheckBox
		Me.chkOutCon = New System.Windows.Forms.CheckBox
		Me.chkSum = New System.Windows.Forms.CheckBox
		Me.chkFC = New System.Windows.Forms.CheckBox
		Me.lstSaleref = New System.Windows.Forms.CheckedListBox
		Me.cmdLoad = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.chkReversal = New System.Windows.Forms.CheckBox
		Me.chkRevoke = New System.Windows.Forms.CheckBox
		Me.lstPOS = New System.Windows.Forms.CheckedListBox
		Me.lstChannel = New System.Windows.Forms.CheckedListBox
		Me.lstPerson = New System.Windows.Forms.CheckedListBox
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
        'Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Sale Tranaction List ..."
		Me.ClientSize = New System.Drawing.Size(672, 308)
		Me.Location = New System.Drawing.Point(4, 30)
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
		Me.Name = "frmPOSreport"
		Me.chkNoCon.Text = "Do not show Consignments"
		Me.chkNoCon.Size = New System.Drawing.Size(233, 19)
		Me.chkNoCon.Location = New System.Drawing.Point(18, 234)
		Me.chkNoCon.TabIndex = 15
		Me.chkNoCon.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkNoCon.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkNoCon.BackColor = System.Drawing.SystemColors.Control
		Me.chkNoCon.CausesValidation = True
		Me.chkNoCon.Enabled = True
		Me.chkNoCon.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkNoCon.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkNoCon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkNoCon.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkNoCon.TabStop = True
		Me.chkNoCon.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkNoCon.Visible = True
		Me.chkNoCon.Name = "chkNoCon"
		Me.chkOutCon.Text = "Only show Outstanding Consignments"
		Me.chkOutCon.Size = New System.Drawing.Size(233, 19)
		Me.chkOutCon.Location = New System.Drawing.Point(424, 208)
		Me.chkOutCon.TabIndex = 14
		Me.chkOutCon.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOutCon.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOutCon.BackColor = System.Drawing.SystemColors.Control
		Me.chkOutCon.CausesValidation = True
		Me.chkOutCon.Enabled = True
		Me.chkOutCon.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOutCon.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOutCon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOutCon.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOutCon.TabStop = True
		Me.chkOutCon.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOutCon.Visible = True
		Me.chkOutCon.Name = "chkOutCon"
		Me.chkSum.Text = "Only show Summary"
		Me.chkSum.Size = New System.Drawing.Size(129, 19)
		Me.chkSum.Location = New System.Drawing.Point(288, 208)
		Me.chkSum.TabIndex = 13
		Me.chkSum.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSum.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSum.BackColor = System.Drawing.SystemColors.Control
		Me.chkSum.CausesValidation = True
		Me.chkSum.Enabled = True
		Me.chkSum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkSum.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSum.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSum.TabStop = True
		Me.chkSum.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSum.Visible = True
		Me.chkSum.Name = "chkSum"
		Me.chkFC.Text = "Only show transaction with Foreign Currencies"
		Me.chkFC.Size = New System.Drawing.Size(249, 19)
		Me.chkFC.Location = New System.Drawing.Point(288, 186)
		Me.chkFC.TabIndex = 12
		Me.chkFC.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFC.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFC.BackColor = System.Drawing.SystemColors.Control
		Me.chkFC.CausesValidation = True
		Me.chkFC.Enabled = True
		Me.chkFC.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFC.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFC.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFC.TabStop = True
		Me.chkFC.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFC.Visible = True
		Me.chkFC.Name = "chkFC"
		Me.lstSaleref.Size = New System.Drawing.Size(145, 154)
		Me.lstSaleref.Location = New System.Drawing.Point(510, 24)
		Me.lstSaleref.Items.AddRange(New Object(){"Card Number", "Order Number", "Serial Number"})
		Me.lstSaleref.TabIndex = 10
		Me.lstSaleref.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstSaleref.BackColor = System.Drawing.SystemColors.Window
		Me.lstSaleref.CausesValidation = True
		Me.lstSaleref.Enabled = True
		Me.lstSaleref.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstSaleref.IntegralHeight = True
		Me.lstSaleref.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstSaleref.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstSaleref.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstSaleref.Sorted = False
		Me.lstSaleref.TabStop = True
		Me.lstSaleref.Visible = True
		Me.lstSaleref.MultiColumn = False
		Me.lstSaleref.Name = "lstSaleref"
		Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoad.Text = "Show/&Print Report"
		Me.cmdLoad.Size = New System.Drawing.Size(79, 43)
		Me.cmdLoad.Location = New System.Drawing.Point(576, 260)
		Me.cmdLoad.TabIndex = 9
		Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoad.CausesValidation = True
		Me.cmdLoad.Enabled = True
		Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoad.TabStop = True
		Me.cmdLoad.Name = "cmdLoad"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(79, 43)
		Me.cmdExit.Location = New System.Drawing.Point(18, 260)
		Me.cmdExit.TabIndex = 8
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.chkReversal.Text = "Only show transaction with one or more Reversals"
		Me.chkReversal.Size = New System.Drawing.Size(258, 19)
		Me.chkReversal.Location = New System.Drawing.Point(18, 210)
		Me.chkReversal.TabIndex = 4
		Me.chkReversal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkReversal.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkReversal.BackColor = System.Drawing.SystemColors.Control
		Me.chkReversal.CausesValidation = True
		Me.chkReversal.Enabled = True
		Me.chkReversal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkReversal.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkReversal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkReversal.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkReversal.TabStop = True
		Me.chkReversal.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkReversal.Visible = True
		Me.chkReversal.Name = "chkReversal"
		Me.chkRevoke.Text = "Only show transaction with revoked Lines"
		Me.chkRevoke.Size = New System.Drawing.Size(234, 19)
		Me.chkRevoke.Location = New System.Drawing.Point(18, 186)
		Me.chkRevoke.TabIndex = 3
		Me.chkRevoke.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkRevoke.BackColor = System.Drawing.SystemColors.Control
		Me.chkRevoke.CausesValidation = True
		Me.chkRevoke.Enabled = True
		Me.chkRevoke.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkRevoke.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkRevoke.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkRevoke.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkRevoke.TabStop = True
		Me.chkRevoke.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkRevoke.Visible = True
		Me.chkRevoke.Name = "chkRevoke"
		Me.lstPOS.Size = New System.Drawing.Size(145, 154)
		Me.lstPOS.Location = New System.Drawing.Point(360, 24)
		Me.lstPOS.TabIndex = 2
		Me.lstPOS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPOS.BackColor = System.Drawing.SystemColors.Window
		Me.lstPOS.CausesValidation = True
		Me.lstPOS.Enabled = True
		Me.lstPOS.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPOS.IntegralHeight = True
		Me.lstPOS.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPOS.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPOS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPOS.Sorted = False
		Me.lstPOS.TabStop = True
		Me.lstPOS.Visible = True
		Me.lstPOS.MultiColumn = False
		Me.lstPOS.Name = "lstPOS"
		Me.lstChannel.Size = New System.Drawing.Size(145, 154)
		Me.lstChannel.Location = New System.Drawing.Point(210, 24)
		Me.lstChannel.TabIndex = 1
		Me.lstChannel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstChannel.BackColor = System.Drawing.SystemColors.Window
		Me.lstChannel.CausesValidation = True
		Me.lstChannel.Enabled = True
		Me.lstChannel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstChannel.IntegralHeight = True
		Me.lstChannel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstChannel.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstChannel.Sorted = False
		Me.lstChannel.TabStop = True
		Me.lstChannel.Visible = True
		Me.lstChannel.MultiColumn = False
		Me.lstChannel.Name = "lstChannel"
		Me.lstPerson.Size = New System.Drawing.Size(187, 154)
		Me.lstPerson.Location = New System.Drawing.Point(18, 24)
		Me.lstPerson.TabIndex = 0
		Me.lstPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPerson.BackColor = System.Drawing.SystemColors.Window
		Me.lstPerson.CausesValidation = True
		Me.lstPerson.Enabled = True
		Me.lstPerson.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPerson.IntegralHeight = True
		Me.lstPerson.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPerson.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPerson.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPerson.Sorted = False
		Me.lstPerson.TabStop = True
		Me.lstPerson.Visible = True
		Me.lstPerson.MultiColumn = False
		Me.lstPerson.Name = "lstPerson"
		Me._Label1_3.Text = "Transaction Reference"
		Me._Label1_3.Size = New System.Drawing.Size(109, 13)
		Me._Label1_3.Location = New System.Drawing.Point(512, 10)
		Me._Label1_3.TabIndex = 11
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_3.BackColor = System.Drawing.Color.Transparent
		Me._Label1_3.Enabled = True
		Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = True
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label1_2.Text = "POS Devices"
		Me._Label1_2.Size = New System.Drawing.Size(64, 13)
		Me._Label1_2.Location = New System.Drawing.Point(360, 10)
		Me._Label1_2.TabIndex = 7
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = True
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_1.Text = "Sale Channels"
		Me._Label1_1.Size = New System.Drawing.Size(68, 13)
		Me._Label1_1.Location = New System.Drawing.Point(210, 10)
		Me._Label1_1.TabIndex = 6
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = True
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.Text = "Persons"
		Me._Label1_0.Size = New System.Drawing.Size(38, 13)
		Me._Label1_0.Location = New System.Drawing.Point(21, 10)
		Me._Label1_0.TabIndex = 5
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = True
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(chkNoCon)
		Me.Controls.Add(chkOutCon)
		Me.Controls.Add(chkSum)
		Me.Controls.Add(chkFC)
		Me.Controls.Add(lstSaleref)
		Me.Controls.Add(cmdLoad)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(chkReversal)
		Me.Controls.Add(chkRevoke)
		Me.Controls.Add(lstPOS)
		Me.Controls.Add(lstChannel)
		Me.Controls.Add(lstPerson)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label1_2)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
        'Me.Label1.SetIndex(_Label1_3, CType(3, Short))
        'Me.Label1.SetIndex(_Label1_2, CType(2, Short))
        'Me.Label1.SetIndex(_Label1_1, CType(1, Short))
        'Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        'CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class