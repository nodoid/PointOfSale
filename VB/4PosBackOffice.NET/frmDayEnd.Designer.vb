<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDayEnd
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
	Public WithEvents lblDemo As System.Windows.Forms.Label
	Public WithEvents lblText As System.Windows.Forms.Label
	Public WithEvents _frmMode_4 As System.Windows.Forms.GroupBox
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents lstPOS As System.Windows.Forms.ListBox
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents _frmMode_0 As System.Windows.Forms.GroupBox
	Public WithEvents calDayEnd As System.Windows.Forms.MonthCalendar
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _frmMode_2 As System.Windows.Forms.GroupBox
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _frmMode_1 As System.Windows.Forms.GroupBox
	Public WithEvents Picture2 As System.Windows.Forms.PictureBox
	Public WithEvents _frmMode_3 As System.Windows.Forms.GroupBox
    'Public WithEvents MAPISession1 As MSMAPI.MAPISession
    'Public WithEvents MAPIMessages1 As MSMAPI.MAPIMessages
    Public WithEvents Label3 As System.Windows.Forms.Label
    'Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDayEnd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frmMode_4 = New System.Windows.Forms.GroupBox()
        Me.lblDemo = New System.Windows.Forms.Label()
        Me.lblText = New System.Windows.Forms.Label()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me._frmMode_0 = New System.Windows.Forms.GroupBox()
        Me.lstPOS = New System.Windows.Forms.ListBox()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me._frmMode_2 = New System.Windows.Forms.GroupBox()
        Me.calDayEnd = New System.Windows.Forms.MonthCalendar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._frmMode_1 = New System.Windows.Forms.GroupBox()
        Me._Label1_4 = New System.Windows.Forms.Label()
        Me._Label1_5 = New System.Windows.Forms.Label()
        Me._frmMode_3 = New System.Windows.Forms.GroupBox()
        Me.Picture2 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._frmMode_4.SuspendLayout()
        Me._frmMode_0.SuspendLayout()
        Me._frmMode_2.SuspendLayout()
        Me._frmMode_1.SuspendLayout()
        Me._frmMode_3.SuspendLayout()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_frmMode_4
        '
        Me._frmMode_4.BackColor = System.Drawing.SystemColors.Control
        Me._frmMode_4.Controls.Add(Me.lblDemo)
        Me._frmMode_4.Controls.Add(Me.lblText)
        Me._frmMode_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._frmMode_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMode_4.Location = New System.Drawing.Point(412, 319)
        Me._frmMode_4.Name = "_frmMode_4"
        Me._frmMode_4.Padding = New System.Windows.Forms.Padding(0)
        Me._frmMode_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmMode_4.Size = New System.Drawing.Size(196, 313)
        Me._frmMode_4.TabIndex = 16
        Me._frmMode_4.TabStop = False
        Me._frmMode_4.Text = "Demo Version Notification"
        '
        'lblDemo
        '
        Me.lblDemo.BackColor = System.Drawing.SystemColors.Control
        Me.lblDemo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDemo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDemo.ForeColor = System.Drawing.Color.Black
        Me.lblDemo.Location = New System.Drawing.Point(12, 138)
        Me.lblDemo.Name = "lblDemo"
        Me.lblDemo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDemo.Size = New System.Drawing.Size(175, 124)
        Me.lblDemo.TabIndex = 18
        '
        'lblText
        '
        Me.lblText.BackColor = System.Drawing.SystemColors.Control
        Me.lblText.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblText.ForeColor = System.Drawing.Color.Black
        Me.lblText.Location = New System.Drawing.Point(12, 33)
        Me.lblText.Name = "lblText"
        Me.lblText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblText.Size = New System.Drawing.Size(175, 82)
        Me.lblText.TabIndex = 17
        Me.lblText.Text = "The 4POS Application you are currently using is a Demo Version. The Demo version " & _
    "is a fully functional version except that you may only run one ten Day End runs." & _
    ""
        '
        'cmdBack
        '
        Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBack.Location = New System.Drawing.Point(4, 350)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBack.Size = New System.Drawing.Size(85, 25)
        Me.cmdBack.TabIndex = 4
        Me.cmdBack.Text = "E&xit"
        Me.cmdBack.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNext.Location = New System.Drawing.Point(118, 350)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNext.Size = New System.Drawing.Size(84, 25)
        Me.cmdNext.TabIndex = 3
        Me.cmdNext.Text = "&Next >>"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        '_frmMode_0
        '
        Me._frmMode_0.BackColor = System.Drawing.SystemColors.Control
        Me._frmMode_0.Controls.Add(Me.lstPOS)
        Me._frmMode_0.Controls.Add(Me._Label1_3)
        Me._frmMode_0.Controls.Add(Me._Label1_0)
        Me._frmMode_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMode_0.Location = New System.Drawing.Point(6, 12)
        Me._frmMode_0.Name = "_frmMode_0"
        Me._frmMode_0.Padding = New System.Windows.Forms.Padding(0)
        Me._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmMode_0.Size = New System.Drawing.Size(196, 313)
        Me._frmMode_0.TabIndex = 0
        Me._frmMode_0.TabStop = False
        Me._frmMode_0.Text = "No Cashup Declarations"
        '
        'lstPOS
        '
        Me.lstPOS.BackColor = System.Drawing.SystemColors.Window
        Me.lstPOS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstPOS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lstPOS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstPOS.ItemHeight = 16
        Me.lstPOS.Location = New System.Drawing.Point(9, 18)
        Me.lstPOS.Name = "lstPOS"
        Me.lstPOS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPOS.Size = New System.Drawing.Size(178, 164)
        Me.lstPOS.TabIndex = 1
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_3.ForeColor = System.Drawing.Color.Red
        Me._Label1_3.Location = New System.Drawing.Point(12, 246)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(178, 43)
        Me._Label1_3.TabIndex = 10
        Me._Label1_3.Text = "All active Point Of Sales Devices have to be declared before your Day End Run."
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_0.ForeColor = System.Drawing.Color.Red
        Me._Label1_0.Location = New System.Drawing.Point(12, 201)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(178, 40)
        Me._Label1_0.TabIndex = 2
        Me._Label1_0.Text = "The following Point Of Sales Devices have not been declared."
        '
        '_frmMode_2
        '
        Me._frmMode_2.BackColor = System.Drawing.SystemColors.Control
        Me._frmMode_2.Controls.Add(Me.calDayEnd)
        Me._frmMode_2.Controls.Add(Me.Label2)
        Me._frmMode_2.Controls.Add(Me._Label1_2)
        Me._frmMode_2.Controls.Add(Me._Label1_1)
        Me._frmMode_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._frmMode_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMode_2.Location = New System.Drawing.Point(210, 0)
        Me._frmMode_2.Name = "_frmMode_2"
        Me._frmMode_2.Padding = New System.Windows.Forms.Padding(0)
        Me._frmMode_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmMode_2.Size = New System.Drawing.Size(196, 313)
        Me._frmMode_2.TabIndex = 5
        Me._frmMode_2.TabStop = False
        Me._frmMode_2.Text = "Confirm Day End Run"
        '
        'calDayEnd
        '
        Me.calDayEnd.Location = New System.Drawing.Point(9, 42)
        Me.calDayEnd.Name = "calDayEnd"
        Me.calDayEnd.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(6, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(181, 52)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Please insure that there are no other users using the system before pressing the " & _
    """Next"" button!"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(9, 207)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(178, 43)
        Me._Label1_2.TabIndex = 9
        Me._Label1_2.Text = "As part of the ""Day End"" run, the integrity of your database will be check and a " & _
    "backup made."
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(15, 13)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(178, 34)
        Me._Label1_1.TabIndex = 6
        Me._Label1_1.Text = "Use the date selector to select the correct date for your day end."
        '
        '_frmMode_1
        '
        Me._frmMode_1.BackColor = System.Drawing.SystemColors.Control
        Me._frmMode_1.Controls.Add(Me._Label1_4)
        Me._frmMode_1.Controls.Add(Me._Label1_5)
        Me._frmMode_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMode_1.Location = New System.Drawing.Point(210, 319)
        Me._frmMode_1.Name = "_frmMode_1"
        Me._frmMode_1.Padding = New System.Windows.Forms.Padding(0)
        Me._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmMode_1.Size = New System.Drawing.Size(196, 313)
        Me._frmMode_1.TabIndex = 11
        Me._frmMode_1.TabStop = False
        Me._frmMode_1.Text = "No POS Trasactions"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_4.ForeColor = System.Drawing.Color.Red
        Me._Label1_4.Location = New System.Drawing.Point(9, 129)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(178, 70)
        Me._Label1_4.TabIndex = 13
        Me._Label1_4.Text = "There is no need to run your Day End Run."
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label1_5.ForeColor = System.Drawing.Color.Red
        Me._Label1_5.Location = New System.Drawing.Point(12, 57)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(178, 70)
        Me._Label1_5.TabIndex = 12
        Me._Label1_5.Text = "There have been no Point Of Sale transactions since the last time this Day End Ru" & _
    "n procedure was run."
        '
        '_frmMode_3
        '
        Me._frmMode_3.BackColor = System.Drawing.SystemColors.Control
        Me._frmMode_3.Controls.Add(Me.Picture2)
        Me._frmMode_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._frmMode_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMode_3.Location = New System.Drawing.Point(412, 0)
        Me._frmMode_3.Name = "_frmMode_3"
        Me._frmMode_3.Padding = New System.Windows.Forms.Padding(0)
        Me._frmMode_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frmMode_3.Size = New System.Drawing.Size(196, 313)
        Me._frmMode_3.TabIndex = 7
        Me._frmMode_3.TabStop = False
        Me._frmMode_3.Text = "Day End Run Complete"
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.SystemColors.Control
        Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture2.Image = CType(resources.GetObject("Picture2.Image"), System.Drawing.Image)
        Me.Picture2.Location = New System.Drawing.Point(27, 54)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(140, 205)
        Me.Picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Picture2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 330)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(195, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Please Wait, Stock Update progress..."
        Me.Label3.Visible = False
        '
        'frmDayEnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(654, 483)
        Me.ControlBox = False
        Me.Controls.Add(Me._frmMode_4)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me._frmMode_0)
        Me.Controls.Add(Me._frmMode_2)
        Me.Controls.Add(Me._frmMode_1)
        Me.Controls.Add(Me._frmMode_3)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDayEnd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Day End Run"
        Me._frmMode_4.ResumeLayout(False)
        Me._frmMode_0.ResumeLayout(False)
        Me._frmMode_2.ResumeLayout(False)
        Me._frmMode_1.ResumeLayout(False)
        Me._frmMode_3.ResumeLayout(False)
        Me._frmMode_3.PerformLayout()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class