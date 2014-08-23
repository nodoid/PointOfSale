Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmLogin
	Inherits System.Windows.Forms.Form
	Private Declare Function BringWindowToTop Lib "user32" (ByVal hwnd As Integer) As Integer
	
	Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As Object, ByVal lpWindowName As Object) As Integer
	
	Public LoginSucceeded As Boolean
	
	Private Sub loadLanguage()
		
		'frmLogin = No Code     [4POS Application Suite]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmLogin.Caption = rsLang("LanguageLayoutLnk_Description"): frmLogin.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: BACKGROUND IMAGE CONTAINS TEXT- CONVERT TO LABELS!
		
		'lbl_UserId = No Label/NO CODE  --> CREATE COMPONENT!
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl_userId.Caption = rsLang("LanguageLayoutLnk_Description"): lbl_userId.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl_password = No Label   --> CREATE COMPONENT!
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490
		'If rsLang.RecordCount Then lbl_password.Caption = rsLang("LanguageLayoutLnk_Description"): lbl_password.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1389 'OK|Checked
		If rsLang.RecordCount Then cmdOK.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdOK.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code       [NOTE:]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code       [If this is a new Installation.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmLogin.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'set the global var to false
		'to denote a failed login
		LoginSucceeded = False
        'End
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim createDayend As Boolean
		Dim x As Decimal
		Dim revName As String
		
		On Error Resume Next
		rs = getRS("SELECT * FROM Person WHERE (Person_UserID = '" & Replace(Me.txtUserName.Text, "'", "''") & "') AND (Person_Password = '" & Replace(Me.txtPassword.Text, "'", "''") & "')")
        Dim rsRpt As New ADODB.Recordset
		If rs.BOF Or rs.EOF Then
			MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login")
			txtPassword.Focus()
			'        SendKeys "{Home}+{End}"
        Else
            frmMenu.Show()
            'MsgBox "Login 1"
            If CInt(rs.Fields("Person_SecurityBit").Value & "0") Then
                Me.Close()
                frmMenu.lblUser.Text = rs.Fields("Person_FirstName").Value & " " & rs.Fields("Person_LastName").Value
                frmMenu.lblUser.Tag = rs.Fields("PersonID").Value
                frmMenu.gBit = rs.Fields("Person_SecurityBit").Value

                If Len(rs.Fields("Person_QuickAccess").Value) > 0 Then
                    For x = Len(rs.Fields("Person_QuickAccess").Value) To 1 Step -1
                        revName = revName & Mid(rs.Fields("Person_QuickAccess").Value, x, 1)
                    Next
                    If LCase(VB.Left(rs.Fields("Person_Position").Value, 8)) = "4posboss" And LCase(VB.Right(rs.Fields("Person_Position").Value, Len(rs.Fields("Person_QuickAccess").Value))) = revName Then
                        frmMenu.lblUser.ForeColor = System.Drawing.Color.Yellow
                        frmMenu.gSuper = True
                    End If
                End If

                rsRpt = getRS("SELECT Company_LoadTRpt From Company")
                If IsDBNull(rsRpt.Fields("Company_LoadTRpt").Value) Then
                ElseIf rsRpt.Fields("Company_LoadTRpt").Value = 0 Then
                Else
                    If fso.FileExists(serverPath & "templateReport1.mdb") Then
                        If fso.FileExists(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb") Then fso.DeleteFile(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb", True)
                        If fso.FileExists(serverPath & "templateReport.mdb") Then fso.DeleteFile(serverPath & "templateReport.mdb", True)

                        fso.CopyFile(serverPath & "templateReport1.mdb", serverPath & "templateReport.mdb", True)
                    End If
                End If
                'MsgBox "Login 2"
                frmMenu.loadMenu("stock")
                'MsgBox "Login 3"

                'frmUpdateReportData.loadReportData

                If fso.FileExists(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb") Then
                Else
                    fso.CopyFile(serverPath & "templateReport.mdb", serverPath & "report" & frmMenu.lblUser.Tag & ".mdb")
                    createDayend = True
                End If
                'MsgBox "Login 4"
                If openConnectionReport() Then
                Else
                    MsgBox("Unable to locate the Report Database!" & vbCrLf & vbCrLf & "The Update Controller wil terminate.", MsgBoxStyle.Critical, "SERVER ERROR")
                    End
                End If
                'MsgBox "Login 5"
                If createDayend Then
                    '                cnnDBreport.Execute "DELETE * FROM Report"
                    '                cnnDBreport.Execute "INSERT INTO Report ( ReportID, Report_DayEndStartID, Report_DayEndEndID, Report_Heading ) SELECT 1 AS reportKey, Max(aDayEnd.DayEndID) AS MaxOfDayEndID, Max(aDayEnd.DayEndID) AS MaxOfDayEndID1, 'From ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' to ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' covering a dayend range of 1 days' AS theHeading FROM aDayEnd;"
                    '                frmUpdateDayEnd.show 1
                    frmMenu.cmdToday_Click(Nothing, New System.EventArgs())
                    frmMenu.cmdLoad_Click(Nothing, New System.EventArgs())
                End If
                'MsgBox "Login 6"
                rs = getRSreport("SELECT DayEnd.DayEnd_Date AS fromDate, DayEnd_1.DayEnd_Date AS toDate FROM (Report INNER JOIN DayEnd ON Report.Report_DayEndStartID = DayEnd.DayEndID) INNER JOIN DayEnd AS DayEnd_1 ON Report.Report_DayEndEndID = DayEnd_1.DayEndID;")
                If rs.RecordCount Then
                    frmMenu._DTPicker1_0.Format = DateTimePickerFormat.Custom
                    frmMenu._DTPicker1_0.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("fromDate").Value, "yyyy"), _
                    Format(rs.Fields("fromDate").Value, "m"), _
                    Format(rs.Fields("fromDate").Value, "d"))
                    frmMenu._DTPicker1_1.Format = DateTimePickerFormat.Custom
                    frmMenu._DTPicker1_1.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("toDate").Value, "yyyy"), _
                    Format(rs.Fields("toDate").Value, "m"), _
                    Format(rs.Fields("toDate").Value, "d"))
                End If
                'MsgBox "Login 7"
                frmMenu.setDayEndRange()
                frmMenu.lblDayEndCurrent.Text = frmMenu.lblDayEnd.Text
            Else
                MsgBox("You do not have the correct permissions to access the 4POS Office Application, try again!", MsgBoxStyle.Exclamation, "Login")
                Me.txtUserName.Focus()
                System.Windows.Forms.SendKeys.Send("{Home}+{End}")
            End If
            'MsgBox "Login 8"
            'frmMenu.Show()
		End If
	End Sub
	Private Sub frmLogin_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdCancel_Click(cmdCancel, New System.EventArgs())
		End If
		If KeyAscii = 13 Then
			KeyAscii = 0
			If Me.txtUserName.Text = "" Then
				txtUserName.Focus()
			ElseIf Me.txtPassword.Text = "" Then 
				txtPassword.Focus()
			Else
				cmdOK.Focus()
				System.Windows.Forms.Application.DoEvents()
				cmdOK_Click(cmdOK, New System.EventArgs())
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmLogin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
        Me.Show()
        'frmRegister.checkSecurity()
        'Me.Show()
	End Sub
	
	Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
		txtPassword.SelectionStart = 0
		txtPassword.SelectionLength = 999
	End Sub
	
	Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserName.Enter
		txtUserName.SelectionStart = 0
		txtUserName.SelectionLength = 999
	End Sub
End Class