<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustomerStatement
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
	Public WithEvents chkFields As System.Windows.Forms.CheckBox
	Public WithEvents cmbMonthEnd As System.Windows.Forms.ComboBox
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.picButtons = New System.Windows.Forms.Panel()
        Me.chkFields = New System.Windows.Forms.CheckBox()
        Me.cmbMonthEnd = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.DataList1 = New _4PosBackOffice.NET.myDataGridView()
        Me.lbl = New System.Windows.Forms.Label()
        Me.picButtons.SuspendLayout()
        CType(Me.DataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSearch.Location = New System.Drawing.Point(54, 115)
        Me.txtSearch.MaxLength = 0
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.Size = New System.Drawing.Size(199, 19)
        Me.txtSearch.TabIndex = 1
        '
        'picButtons
        '
        Me.picButtons.BackColor = System.Drawing.Color.Blue
        Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picButtons.Controls.Add(Me.chkFields)
        Me.picButtons.Controls.Add(Me.cmbMonthEnd)
        Me.picButtons.Controls.Add(Me.cmbMonth)
        Me.picButtons.Controls.Add(Me.cmdPrint)
        Me.picButtons.Controls.Add(Me.cmdExit)
        Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.picButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.picButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picButtons.Location = New System.Drawing.Point(0, 0)
        Me.picButtons.Name = "picButtons"
        Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picButtons.Size = New System.Drawing.Size(263, 109)
        Me.picButtons.TabIndex = 4
        '
        'chkFields
        '
        Me.chkFields.BackColor = System.Drawing.Color.Blue
        Me.chkFields.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFields.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFields.ForeColor = System.Drawing.Color.White
        Me.chkFields.Location = New System.Drawing.Point(7, 82)
        Me.chkFields.Name = "chkFields"
        Me.chkFields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFields.Size = New System.Drawing.Size(241, 23)
        Me.chkFields.TabIndex = 8
        Me.chkFields.Text = "Do not print Payment Date on Statement :"
        Me.chkFields.UseVisualStyleBackColor = False
        '
        'cmbMonthEnd
        '
        Me.cmbMonthEnd.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMonthEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMonthEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMonthEnd.Location = New System.Drawing.Point(7, 31)
        Me.cmbMonthEnd.Name = "cmbMonthEnd"
        Me.cmbMonthEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonthEnd.Size = New System.Drawing.Size(243, 21)
        Me.cmbMonthEnd.TabIndex = 7
        '
        'cmbMonth
        '
        Me.cmbMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMonth.Items.AddRange(New Object() {"Last Month", "2 Months Ago", "3 Months Ago", "4 Months Ago", "5 Months Ago", "6 Months Ago", "7 Months Ago", "8 Months Ago", "9 Months Ago", "10 Months Ago", "11 Months Ago", "12 Months Ago", "13 Months Ago", "14 Months Ago", "15 Months Ago"})
        Me.cmbMonth.Location = New System.Drawing.Point(7, 8)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonth.Size = New System.Drawing.Size(242, 21)
        Me.cmbMonth.TabIndex = 3
        Me.cmbMonth.Visible = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(5, 53)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(73, 29)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.TabStop = False
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(177, 53)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(73, 29)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'DataList1
        '
        Me.DataList1.AllowAddNew = True
        Me.DataList1.BoundText = ""
        Me.DataList1.CellBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.DataList1.Col = 0
        Me.DataList1.CtlText = ""
        Me.DataList1.DataField = Nothing
        Me.DataList1.Location = New System.Drawing.Point(9, 141)
        Me.DataList1.Name = "DataList1"
        Me.DataList1.row = 0
        Me.DataList1.Size = New System.Drawing.Size(244, 321)
        Me.DataList1.TabIndex = 2
        Me.DataList1.TopRow = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl.Location = New System.Drawing.Point(6, 115)
        Me.lbl.Name = "lbl"
        Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl.Size = New System.Drawing.Size(47, 13)
        Me.lbl.TabIndex = 0
        Me.lbl.Text = "&Search :"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCustomerStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(263, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.picButtons)
        Me.Controls.Add(Me.DataList1)
        Me.Controls.Add(Me.lbl)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomerStatement"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Statement Run"
        Me.picButtons.ResumeLayout(False)
        CType(Me.DataList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class