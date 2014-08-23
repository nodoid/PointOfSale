<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBarcode
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
	Public WithEvents cmdnext As System.Windows.Forms.Button
	Public WithEvents cndExit As System.Windows.Forms.Button
	Public WithEvents _optBarcode_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optBarcode_1 As System.Windows.Forms.RadioButton
	Public WithEvents lstBarcode As System.Windows.Forms.ListBox
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents lblPrinterType As System.Windows.Forms.Label
	Public WithEvents lblPrinter As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents optBarcode As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBarcode))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdnext = New System.Windows.Forms.Button
		Me.cndExit = New System.Windows.Forms.Button
		Me._optBarcode_2 = New System.Windows.Forms.RadioButton
		Me._optBarcode_1 = New System.Windows.Forms.RadioButton
		Me.lstBarcode = New System.Windows.Forms.ListBox
		Me._Label2_1 = New System.Windows.Forms.Label
		Me.lblPrinterType = New System.Windows.Forms.Label
		Me.lblPrinter = New System.Windows.Forms.Label
		Me._Label2_0 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
        'Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        'Me.optBarcode = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.optBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Barcode Printing"
		Me.ClientSize = New System.Drawing.Size(391, 435)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("frmBarcode.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmBarcode"
		Me.cmdnext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdnext.Text = "&Next"
		Me.cmdnext.Size = New System.Drawing.Size(106, 49)
		Me.cmdnext.Location = New System.Drawing.Point(272, 376)
		Me.cmdnext.TabIndex = 9
		Me.cmdnext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdnext.CausesValidation = True
		Me.cmdnext.Enabled = True
		Me.cmdnext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdnext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdnext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdnext.TabStop = True
		Me.cmdnext.Name = "cmdnext"
		Me.cndExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cndExit.Text = "E&xit"
		Me.cndExit.Size = New System.Drawing.Size(106, 49)
		Me.cndExit.Location = New System.Drawing.Point(8, 376)
		Me.cndExit.TabIndex = 7
		Me.cndExit.BackColor = System.Drawing.SystemColors.Control
		Me.cndExit.CausesValidation = True
		Me.cndExit.Enabled = True
		Me.cndExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cndExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cndExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cndExit.TabStop = True
		Me.cndExit.Name = "cndExit"
		Me._optBarcode_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optBarcode_2.Text = "Stock Barcode"
		Me._optBarcode_2.Size = New System.Drawing.Size(133, 40)
		Me._optBarcode_2.Location = New System.Drawing.Point(9, 69)
		Me._optBarcode_2.Appearance = System.Windows.Forms.Appearance.Button
		Me._optBarcode_2.TabIndex = 2
		Me._optBarcode_2.Checked = True
		Me._optBarcode_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optBarcode_2.BackColor = System.Drawing.SystemColors.Control
		Me._optBarcode_2.CausesValidation = True
		Me._optBarcode_2.Enabled = True
		Me._optBarcode_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optBarcode_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optBarcode_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optBarcode_2.TabStop = True
		Me._optBarcode_2.Visible = True
		Me._optBarcode_2.Name = "_optBarcode_2"
		Me._optBarcode_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optBarcode_1.Text = "Shelf Talker"
		Me._optBarcode_1.Size = New System.Drawing.Size(133, 40)
		Me._optBarcode_1.Location = New System.Drawing.Point(144, 69)
		Me._optBarcode_1.Appearance = System.Windows.Forms.Appearance.Button
		Me._optBarcode_1.TabIndex = 1
		Me._optBarcode_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optBarcode_1.BackColor = System.Drawing.SystemColors.Control
		Me._optBarcode_1.CausesValidation = True
		Me._optBarcode_1.Enabled = True
		Me._optBarcode_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optBarcode_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optBarcode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optBarcode_1.TabStop = True
		Me._optBarcode_1.Checked = False
		Me._optBarcode_1.Visible = True
		Me._optBarcode_1.Name = "_optBarcode_1"
		Me.lstBarcode.Size = New System.Drawing.Size(367, 254)
		Me.lstBarcode.Location = New System.Drawing.Point(9, 117)
		Me.lstBarcode.TabIndex = 8
		Me.lstBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstBarcode.BackColor = System.Drawing.SystemColors.Window
		Me.lstBarcode.CausesValidation = True
		Me.lstBarcode.Enabled = True
		Me.lstBarcode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstBarcode.IntegralHeight = True
		Me.lstBarcode.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstBarcode.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstBarcode.Sorted = False
		Me.lstBarcode.TabStop = True
		Me.lstBarcode.Visible = True
		Me.lstBarcode.MultiColumn = True
		Me.lstBarcode.ColumnWidth = 367
		Me.lstBarcode.Name = "lstBarcode"
		Me._Label2_1.Text = "Printer Type:"
		Me._Label2_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Label2_1.Size = New System.Drawing.Size(90, 16)
		Me._Label2_1.Location = New System.Drawing.Point(6, 24)
		Me._Label2_1.TabIndex = 6
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
		Me.lblPrinterType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPrinterType.Size = New System.Drawing.Size(41, 16)
		Me.lblPrinterType.Location = New System.Drawing.Point(102, 24)
		Me.lblPrinterType.TabIndex = 5
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
		Me.lblPrinter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.lblPrinter.Size = New System.Drawing.Size(41, 16)
		Me.lblPrinter.Location = New System.Drawing.Point(102, 6)
		Me.lblPrinter.TabIndex = 4
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
		Me._Label2_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me._Label2_0.Size = New System.Drawing.Size(50, 16)
		Me._Label2_0.Location = New System.Drawing.Point(45, 6)
		Me._Label2_0.TabIndex = 3
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
		Me.Label1.Text = "Select the barcode printing type you require"
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
		Me.Label1.Size = New System.Drawing.Size(258, 16)
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
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdnext)
		Me.Controls.Add(cndExit)
		Me.Controls.Add(_optBarcode_2)
		Me.Controls.Add(_optBarcode_1)
		Me.Controls.Add(lstBarcode)
		Me.Controls.Add(_Label2_1)
		Me.Controls.Add(lblPrinterType)
		Me.Controls.Add(lblPrinter)
		Me.Controls.Add(_Label2_0)
		Me.Controls.Add(Label1)
        'Me.Label2.SetIndex(_Label2_1, CType(1, Short))
        'Me.Label2.SetIndex(_Label2_0, CType(0, Short))
        'Me.optBarcode.SetIndex(_optBarcode_2, CType(2, Short))
        'Me.optBarcode.SetIndex(_optBarcode_1, CType(1, Short))
        'CType(Me.optBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class