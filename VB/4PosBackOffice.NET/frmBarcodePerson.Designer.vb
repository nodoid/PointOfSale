<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBarcodePerson
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
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents lstPerson As System.Windows.Forms.CheckedListBox
	Public WithEvents cndExit As System.Windows.Forms.Button
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents lblPrinterType As System.Windows.Forms.Label
	Public WithEvents lblPrinter As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBarcodePerson))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.lstPerson = New System.Windows.Forms.CheckedListBox
		Me.cndExit = New System.Windows.Forms.Button
		Me._Label2_1 = New System.Windows.Forms.Label
		Me.lblPrinterType = New System.Windows.Forms.Label
		Me.lblPrinter = New System.Windows.Forms.Label
		Me._Label2_0 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
        'Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Security Barcode Printing"
		Me.ClientSize = New System.Drawing.Size(394, 449)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("frmBarcodePerson.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmBarcodePerson"
		Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrint.Text = "&Print"
		Me.cmdPrint.Size = New System.Drawing.Size(106, 49)
		Me.cmdPrint.Location = New System.Drawing.Point(21, 381)
		Me.cmdPrint.TabIndex = 7
		Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrint.CausesValidation = True
		Me.cmdPrint.Enabled = True
		Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrint.TabStop = True
		Me.cmdPrint.Name = "cmdPrint"
		Me.lstPerson.Size = New System.Drawing.Size(361, 244)
		Me.lstPerson.Location = New System.Drawing.Point(15, 93)
		Me.lstPerson.TabIndex = 6
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
		Me.cndExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cndExit.Text = "E&xit"
		Me.cndExit.Size = New System.Drawing.Size(106, 49)
		Me.cndExit.Location = New System.Drawing.Point(267, 381)
		Me.cndExit.TabIndex = 5
		Me.cndExit.BackColor = System.Drawing.SystemColors.Control
		Me.cndExit.CausesValidation = True
		Me.cndExit.Enabled = True
		Me.cndExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cndExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cndExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cndExit.TabStop = True
		Me.cndExit.Name = "cndExit"
		Me._Label2_1.Text = "Printer Type:"
		Me._Label2_1.Size = New System.Drawing.Size(90, 16)
		Me._Label2_1.Location = New System.Drawing.Point(6, 24)
		Me._Label2_1.TabIndex = 4
		Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_1.BackColor = System.Drawing.Color.Transparent
		Me._Label2_1.Enabled = True
		Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_1.UseMnemonic = True
		Me._Label2_1.Visible = True
		Me._Label2_1.AutoSize = True
		Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_1.Name = "_Label2_1"
		Me.lblPrinterType.Text = "Label1"
		Me.lblPrinterType.Size = New System.Drawing.Size(41, 16)
		Me.lblPrinterType.Location = New System.Drawing.Point(102, 24)
		Me.lblPrinterType.TabIndex = 3
		Me.lblPrinterType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrinterType.BackColor = System.Drawing.Color.Transparent
		Me.lblPrinterType.Enabled = True
		Me.lblPrinterType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPrinterType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrinterType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrinterType.UseMnemonic = True
		Me.lblPrinterType.Visible = True
		Me.lblPrinterType.AutoSize = True
		Me.lblPrinterType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPrinterType.Name = "lblPrinterType"
		Me.lblPrinter.Text = "Label1"
		Me.lblPrinter.Size = New System.Drawing.Size(41, 16)
		Me.lblPrinter.Location = New System.Drawing.Point(102, 6)
		Me.lblPrinter.TabIndex = 2
		Me.lblPrinter.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrinter.BackColor = System.Drawing.Color.Transparent
		Me.lblPrinter.Enabled = True
		Me.lblPrinter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPrinter.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrinter.UseMnemonic = True
		Me.lblPrinter.Visible = True
		Me.lblPrinter.AutoSize = True
		Me.lblPrinter.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPrinter.Name = "lblPrinter"
		Me._Label2_0.Text = "Printer:"
		Me._Label2_0.Size = New System.Drawing.Size(50, 16)
		Me._Label2_0.Location = New System.Drawing.Point(45, 6)
		Me._Label2_0.TabIndex = 1
		Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label2_0.BackColor = System.Drawing.Color.Transparent
		Me._Label2_0.Enabled = True
		Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label2_0.UseMnemonic = True
		Me._Label2_0.Visible = True
		Me._Label2_0.AutoSize = True
		Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label2_0.Name = "_Label2_0"
		Me.Label1.Text = "Tick the check boxes for the Persons you require access barcodes for from the list below."
		Me.Label1.Size = New System.Drawing.Size(357, 37)
		Me.Label1.Location = New System.Drawing.Point(12, 45)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(cmdPrint)
		Me.Controls.Add(lstPerson)
		Me.Controls.Add(cndExit)
		Me.Controls.Add(_Label2_1)
		Me.Controls.Add(lblPrinterType)
		Me.Controls.Add(lblPrinter)
		Me.Controls.Add(_Label2_0)
		Me.Controls.Add(Label1)
        'Me.Label2.SetIndex(_Label2_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_0, CType(0, Short))
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class