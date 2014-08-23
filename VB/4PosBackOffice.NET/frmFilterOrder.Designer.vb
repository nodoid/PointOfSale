<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFilterOrder
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
	Public WithEvents _cmdList_0 As System.Windows.Forms.Button
	Public WithEvents _lblList_0 As System.Windows.Forms.Label
	Public WithEvents _frmList_0 As System.Windows.Forms.GroupBox
    'Public WithEvents cmdList As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'Public WithEvents frmList As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    'Public WithEvents lblList As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFilterOrder))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._frmList_0 = New System.Windows.Forms.GroupBox
		Me._cmdList_0 = New System.Windows.Forms.Button
		Me._lblList_0 = New System.Windows.Forms.Label
        'Me.cmdList = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
        'Me.frmList = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
        'Me.lblList = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me._frmList_0.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
        'CType(Me.cmdList, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.frmList, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Text = "Broken Pack Exclusion List Criteria"
		Me.ClientSize = New System.Drawing.Size(520, 498)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
		Me.Name = "frmFilterOrder"
		Me._frmList_0.Text = "Frame1"
		Me._frmList_0.Size = New System.Drawing.Size(493, 55)
		Me._frmList_0.Location = New System.Drawing.Point(9, 18)
		Me._frmList_0.TabIndex = 0
		Me._frmList_0.Visible = False
		Me._frmList_0.BackColor = System.Drawing.SystemColors.Control
		Me._frmList_0.Enabled = True
		Me._frmList_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._frmList_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._frmList_0.Padding = New System.Windows.Forms.Padding(0)
		Me._frmList_0.Name = "_frmList_0"
		Me._cmdList_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdList_0.Text = "Build"
		Me._cmdList_0.Size = New System.Drawing.Size(52, 37)
		Me._cmdList_0.Location = New System.Drawing.Point(435, 12)
		Me._cmdList_0.TabIndex = 2
		Me._cmdList_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdList_0.CausesValidation = True
		Me._cmdList_0.Enabled = True
		Me._cmdList_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdList_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdList_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdList_0.TabStop = True
		Me._cmdList_0.Name = "_cmdList_0"
		Me._lblList_0.BackColor = System.Drawing.Color.White
		Me._lblList_0.Text = "Label1"
		Me._lblList_0.Size = New System.Drawing.Size(421, 31)
		Me._lblList_0.Location = New System.Drawing.Point(9, 15)
		Me._lblList_0.TabIndex = 1
		Me._lblList_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblList_0.Enabled = True
		Me._lblList_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblList_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblList_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblList_0.UseMnemonic = True
		Me._lblList_0.Visible = True
		Me._lblList_0.AutoSize = False
		Me._lblList_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lblList_0.Name = "_lblList_0"
		Me.Controls.Add(_frmList_0)
		Me._frmList_0.Controls.Add(_cmdList_0)
		Me._frmList_0.Controls.Add(_lblList_0)
        'Me.cmdList.SetIndex(_cmdList_0, CType(0, Short))
        'Me.frmList.SetIndex(_frmList_0, CType(0, Short))
        'Me.lblList.SetIndex(_lblList_0, CType(0, Short))
        'CType(Me.lblList, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.frmList, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cmdList, System.ComponentModel.ISupportInitialize).EndInit()
		Me._frmList_0.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class