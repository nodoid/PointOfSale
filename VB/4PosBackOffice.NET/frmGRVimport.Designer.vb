<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGRVimport
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
	Public WithEvents tmrAutoGRV As System.Windows.Forms.Timer
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public CDOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents _lvImport_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvImport_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvImport As System.Windows.Forms.ListView
	Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
	Public WithEvents DataList1 As myDataGridView
	Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
    'Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGRVimport))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmrAutoGRV = New System.Windows.Forms.Timer(components)
		Me.cmdNext = New System.Windows.Forms.Button
		Me.CDOpen = New System.Windows.Forms.OpenFileDialog
		Me.cmdExit = New System.Windows.Forms.Button
		Me._Frame1_0 = New System.Windows.Forms.GroupBox
		Me.lvImport = New System.Windows.Forms.ListView
		Me._lvImport_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvImport_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._Frame1_1 = New System.Windows.Forms.GroupBox
		Me.DataList1 = New myDataGridView
        'Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
		Me._Frame1_0.SuspendLayout()
		Me.lvImport.SuspendLayout()
		Me._Frame1_1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Import a GRV ..."
		Me.ClientSize = New System.Drawing.Size(590, 462)
		Me.Location = New System.Drawing.Point(3, 29)
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
		Me.Name = "frmGRVimport"
		Me.tmrAutoGRV.Enabled = False
		Me.tmrAutoGRV.Interval = 10
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Size = New System.Drawing.Size(88, 49)
		Me.cmdNext.Location = New System.Drawing.Point(486, 402)
		Me.cmdNext.TabIndex = 1
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.CDOpen.Title = "Select GRV import file ..."
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(88, 49)
		Me.cmdExit.Location = New System.Drawing.Point(15, 402)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me._Frame1_0.Text = "Imported GRV Data"
		Me._Frame1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_0.Size = New System.Drawing.Size(559, 370)
		Me._Frame1_0.Location = New System.Drawing.Point(15, 24)
		Me._Frame1_0.TabIndex = 2
		Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_0.Enabled = True
		Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_0.Visible = True
		Me._Frame1_0.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_0.Name = "_Frame1_0"
		Me.lvImport.Size = New System.Drawing.Size(541, 346)
		Me.lvImport.Location = New System.Drawing.Point(9, 15)
		Me.lvImport.TabIndex = 3
		Me.lvImport.View = System.Windows.Forms.View.Details
		Me.lvImport.LabelEdit = False
		Me.lvImport.LabelWrap = True
		Me.lvImport.HideSelection = False
		Me.lvImport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvImport.BackColor = System.Drawing.SystemColors.Window
		Me.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvImport.Name = "lvImport"
		Me._lvImport_ColumnHeader_1.Text = "Barcode"
		Me._lvImport_ColumnHeader_1.Width = 118
		Me._lvImport_ColumnHeader_2.Text = "Name"
		Me._lvImport_ColumnHeader_2.Width = 236
		Me._lvImport_ColumnHeader_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_3.Text = "Pack Size"
		Me._lvImport_ColumnHeader_3.Width = 106
		Me._lvImport_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_4.Text = "Quantity"
		Me._lvImport_ColumnHeader_4.Width = 95
		Me._lvImport_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_5.Text = "Cost"
		Me._lvImport_ColumnHeader_5.Width = 118
		Me._lvImport_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_6.Text = "Price"
		Me._lvImport_ColumnHeader_6.Width = 118
		Me._lvImport_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvImport_ColumnHeader_7.Text = "Order"
		Me._lvImport_ColumnHeader_7.Width = 71
		Me._Frame1_1.Text = "Select a Supplier for this GRV ..."
		Me._Frame1_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Frame1_1.Size = New System.Drawing.Size(559, 370)
		Me._Frame1_1.Location = New System.Drawing.Point(15, 24)
		Me._Frame1_1.TabIndex = 4
		Me._Frame1_1.Visible = False
		Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Frame1_1.Enabled = True
		Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Frame1_1.Padding = New System.Windows.Forms.Padding(0)
		Me._Frame1_1.Name = "_Frame1_1"
        ''DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(328, 342)
		Me.DataList1.Location = New System.Drawing.Point(219, 15)
		Me.DataList1.TabIndex = 5
		Me.DataList1.Name = "DataList1"
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(_Frame1_0)
		Me.Controls.Add(_Frame1_1)
		Me._Frame1_0.Controls.Add(lvImport)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_1)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_2)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_3)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_4)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_5)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_6)
		Me.lvImport.Columns.Add(_lvImport_ColumnHeader_7)
		Me._Frame1_1.Controls.Add(DataList1)
        'Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
        'Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
        'CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me._Frame1_0.ResumeLayout(False)
		Me.lvImport.ResumeLayout(False)
		Me._Frame1_1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class