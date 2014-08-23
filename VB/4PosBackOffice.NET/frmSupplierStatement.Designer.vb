<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSupplierStatement
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
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents cmbMonth As System.Windows.Forms.ComboBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents DataList1 As myDataGridView
	Public WithEvents lbl As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSupplierStatement))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmbMonth = New System.Windows.Forms.ComboBox
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.DataList1 = New myDataGridView
		Me.lbl = New System.Windows.Forms.Label
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Supplier Previous Statements"
		Me.ClientSize = New System.Drawing.Size(263, 425)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSupplierStatement"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(199, 19)
		Me.txtSearch.Location = New System.Drawing.Point(54, 48)
		Me.txtSearch.TabIndex = 1
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
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
		Me.picButtons.BackColor = System.Drawing.Color.Blue
		Me.picButtons.Size = New System.Drawing.Size(263, 39)
		Me.picButtons.Location = New System.Drawing.Point(0, 0)
		Me.picButtons.TabIndex = 4
		Me.picButtons.TabStop = False
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picButtons.Name = "picButtons"
		Me.cmbMonth.Size = New System.Drawing.Size(88, 21)
		Me.cmbMonth.Location = New System.Drawing.Point(84, 6)
		Me.cmbMonth.Items.AddRange(New Object(){"Last Month", "2 Months Ago", "3 Months Ago", "4 Months Ago", "5 Months Ago", "6 Months Ago"})
		Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbMonth.TabIndex = 3
		Me.cmbMonth.BackColor = System.Drawing.SystemColors.Window
		Me.cmbMonth.CausesValidation = True
		Me.cmbMonth.Enabled = True
		Me.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbMonth.IntegralHeight = True
		Me.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbMonth.Sorted = False
		Me.cmbMonth.TabStop = True
		Me.cmbMonth.Visible = True
		Me.cmbMonth.Name = "cmbMonth"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
		Me.cmdPrint.Location = New System.Drawing.Point(5, 3)
		Me.cmdPrint.TabIndex = 6
		Me.cmdPrint.TabStop = False
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "E&xit"
		Me.cmdExit.Size = New System.Drawing.Size(73, 29)
		Me.cmdExit.Location = New System.Drawing.Point(177, 3)
		Me.cmdExit.TabIndex = 5
		Me.cmdExit.TabStop = False
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.Name = "cmdExit"
		'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DataList1.Size = New System.Drawing.Size(244, 342)
		Me.DataList1.Location = New System.Drawing.Point(9, 72)
		Me.DataList1.TabIndex = 2
		Me.DataList1.Name = "DataList1"
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lbl.Text = "&Search :"
		Me.lbl.Size = New System.Drawing.Size(40, 13)
		Me.lbl.Location = New System.Drawing.Point(11, 51)
		Me.lbl.TabIndex = 0
		Me.lbl.BackColor = System.Drawing.Color.Transparent
		Me.lbl.Enabled = True
		Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl.UseMnemonic = True
		Me.lbl.Visible = True
		Me.lbl.AutoSize = True
		Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbl.Name = "lbl"
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(DataList1)
		Me.Controls.Add(lbl)
		Me.picButtons.Controls.Add(cmbMonth)
		Me.picButtons.Controls.Add(cmdPrint)
		Me.picButtons.Controls.Add(cmdExit)
		CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class