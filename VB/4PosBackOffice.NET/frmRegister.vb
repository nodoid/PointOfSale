Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmRegister
	Inherits System.Windows.Forms.Form
	Dim gMode As Short
	Const modeCompany As Short = 0
	Const modeCode As Short = 1
	Dim gSecurityCode As String
	Dim preSerial() As String 'new serialization check
    Dim picMode As New List(Of Panel)
	Private Sub loadLanguage()
		
		'frmRegister = No Code      [Registration Wizard]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmRegister.Caption = rsLang("LanguageLayoutLnk_Description"): frmRegister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code           [Welcome to the 4POS Application Suite of products designed for the retailer.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code           [In the text box below.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_3 = No Code           [To bypass this registration.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code           [Store Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmRegister.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub doMode(ByRef lMode As Object)
        Dim x As Integer
        gMode = lMode
        For x = 0 To picMode.Count
            picMode(x).Visible = False
        Next x
		picMode(gMode).Left = picMode(0).Left
		picMode(gMode).Top = picMode(0).Top

		picMode(gMode).Visible = True
	End Sub
	
	Private Sub cmdBegin_Click()
        Dim rs As ADODB.Recordset
		Dim vValue As String
        Dim hkey As Long
        Dim lRetVal As Long
		If Trim(txtCompany.Text) <> "" Then
			cnnDB.Execute("UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'")
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then

                'check advance date expiry system
                On Error Resume Next
                vValue = ""
                lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_QUERY_VALUE, hkey)
                lRetVal = QueryValueEx(hkey, "Software\Microsoft\Windows\CurrentVersion\ShellDls\ShellClass", vValue)
                
                RegCloseKey(hkey)
                If vValue = "" Then
                    vValue = "0"
                Else
                    If vValue <> "0" Then vValue = CStr(CDate("&H" & vValue))
                End If

                If IsDBNull(rs("Company_TerminateDate").Value) And vValue = "0" Then
                    'If vValue = "0" Then
                    cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                    lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                    lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                    SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                    RegCloseKey(hkey)
                Else
                    If IsDBNull(rs("Company_TerminateDate").Value) And vValue <> "0" Then
                        'db date tempered
                        If posDemo() = True Then
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                            lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                            lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                            SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                            RegCloseKey(hkey)
                        Else
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    If IsDBNull(rs("Company_TerminateDate").Value) Then
                    Else
                        If rs("Company_TerminateDate").Value > Today Then
                            'db date tempered
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    'If (Date + 2) > rs("Company_TerminateDate") Then
                    '    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                    '    checkSecurity = False
                    '   Exit Function
                    'End If
                End If
            End If
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Select Case gMode
			Case modeCompany
				cmdBegin_Click()
                Me.Hide()
			Case modeCode
				cmdBegin_Click()
				doMode(modeCompany)
				txtCompany.SelectionStart = 0
				txtCompany.SelectionLength = 999
				txtCompany.Focus()
				cmdExit.Text = "E&xit"
		End Select
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim x As Short
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		
		Select Case gMode
			Case modeCompany
				If Trim(txtCompany.Text) <> "" Then
					'new serialization check
					'If Len(gSecKey) = 12 Then
					'is he really using Original CD to register
					If frmPOSCode.setupCode = True Then
						If MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") = MsgBoxResult.Yes Then
							cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
							cmdBegin_Click()
							'new serialization check    cnnDB.Execute "UPDATE Company SET Company.Company_Code = [Company_Code] & '0';"
							'new serialization check    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & strCDKey & "';"
							lPassword = "pospospospos"
							lCode = getSerialNumber
							lCode = Encrypt(lCode, lPassword)
							cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" & Replace(lCode, "'", "''") & "';")
							
							lPassword = LTrim(Replace(txtCompany.Text, "'", ""))
							lPassword = RTrim(Replace(lPassword, " ", ""))
							lPassword = Trim(Replace(lPassword, ".", ""))
							lPassword = LCase(lPassword)
							leCode = ""
							lCode = ""
							For x = 1 To Len(lPassword)
								lCode = Mid(lPassword, x, 1)
								lCode = CStr(Asc(lCode))
								If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
									leCode = leCode & Mid(lPassword, x, 1)
								End If
							Next 
							lPassword = leCode
							rs = getRS("SELECT * FROM POS;") 'WHERE POS_IPAddress = 'localhost';")
							If rs.RecordCount Then
								Do While rs.EOF = False
									If rs.Fields("POS_IPAddress").Value = "localhost" And rs.Fields("POS_Name").Value = "Server" Then
										lCode = CStr(rs.Fields("POS_CID").Value * 135792468)
										leCode = Encrypt(lCode, lPassword)
										leCode = leCode & Chr(255) & strCDKey
										cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rs.Fields("POS_CID").Value & ";")
										cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" & rs.Fields("POS_CID").Value & ";")
										Exit Do
									ElseIf rs.Fields("POS_IPAddress").Value = "localhost" Then 
										lCode = CStr(rs.Fields("POS_CID").Value * 135792468)
										leCode = Encrypt(lCode, lPassword)
										leCode = leCode & Chr(255) & strCDKey
										cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rs.Fields("POS_CID").Value & ";")
										cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" & rs.Fields("POS_CID").Value & ";")
										Exit Do
									Else
										cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID=" & rs.Fields("POS_CID").Value & ";")
									End If
									rs.moveNext()
								Loop 
							End If
							'new serialization check
							Me.Close()
						End If
						'Else
						
					End If
					
					'Else
					'    cmdBegin_Click
					'    lblCompany.Caption = txtCompany.Text
					'    gSecurityCode = UCase(txtCompany.Text) & "XDFHWPGMIJ"
					'    gSecurityCode = Replace(gSecurityCode, " ", "")
					'    gSecurityCode = Replace(gSecurityCode, "'", "")
					'    gSecurityCode = Replace(gSecurityCode, """", "")
					'    gSecurityCode = Replace(gSecurityCode, ",", "")
					'    For x = 1 To 10
					'        gSecurityCode = Left(gSecurityCode, x) & Replace(Mid(gSecurityCode, x + 1), Mid(gSecurityCode, x, 1), "")
					'    Next x
					'    gSecurityCode = Left(gSecurityCode, 10)
					'    lCode = getSerialNumber
					'    leCode = ""
					'    On Local Error Resume Next
					'    For x = 1 To Len(lCode)
					'        leCode = leCode & Mid(gSecurityCode, Mid(lCode, x, 1) + 1, 1)
					'    Next x
					'    On Local Error GoTo 0
					'    lblCode.Caption = leCode
					'    doMode modeCode
					'    txtKey.Text = ""
					'    txtKey.SetFocus
					'    cmdExit.Caption = "&Back"
					'End If
				Else
					MsgBox("A Company name is required." & vbCrLf & vbCrLf & "If you do not want to register now, Press then 'Exit Button'.", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
					txtCompany.Focus()
				End If
				'Case modeCode
				'    register
		End Select
	End Sub
	
	Private Sub register()
		Dim x As Short
		Dim rs As ADODB.Recordset
		Dim lNewString As String
		Const securtyStringReply As String = "9487203516"
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		
		lNewString = ""
		For x = 1 To Len(txtKey.Text)
			If IsNumeric(Mid(txtKey.Text, x, 1)) Then
				lNewString = lNewString & InStr(securtyStringReply, Mid(txtKey.Text, x, 1)) - 1
			End If
		Next x
		
		If System.Math.Abs(CDbl(lNewString)) = System.Math.Abs(CDbl(getSerialNumber())) Then
			lPassword = "pospospospos"
			lCode = getSerialNumber
			If lCode <> "" Then
				lCode = Encrypt(lCode, lPassword)
				cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" & Replace(lCode, "'", "''") & "';")
				'new serialization check    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & Replace(lCode, "'", "''") & "';"
				lPassword = LTrim(Replace(txtCompany.Text, "'", ""))
				lPassword = RTrim(Replace(lPassword, " ", ""))
				lPassword = Trim(Replace(lPassword, ".", ""))
				lPassword = LCase(lPassword)
				leCode = ""
				lCode = ""
				For x = 1 To Len(lPassword)
					lCode = Mid(lPassword, x, 1)
					lCode = CStr(Asc(lCode))
					If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
						leCode = leCode & Mid(lPassword, x, 1)
					End If
				Next 
				lPassword = leCode
				rs = getRS("SELECT * FROM POS WHERE POS_IPAddress = 'localhost';")
				If rs.RecordCount Then
					lCode = CStr(rs.Fields("POS_CID").Value * 135792468)
					leCode = Encrypt(lCode, lPassword)
					cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rs.Fields("POS_CID").Value & ";")
				End If
				'new serialization check
			End If
			Me.Close()
		Else
			MsgBox("The 'Activation key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
		End If
	End Sub
	
	Private Function getSerialNumber() As String
		Dim FSO As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		getSerialNumber = ""
		Label4.Text = serverPath
		If FSO.FolderExists(serverPath) Then
			fsoFolder = FSO.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
			Label3.Text = CStr(fsoFolder.Drive.SerialNumber)
		End If
		
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(password)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	
	Public Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		
		getLoginDate() 'Piracy check
		
		checkSecurity = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				'check Ban list
				If getBanList(rs.Fields("Company_Name").Value) Then
					cnnDB.Execute("UPDATE Company SET Company_PosString = '121832753'") ' date 2006-09-16 753
					'MsgBox "Illegal function call." & vbCrLf & "application will now exit", vbCritical, "Run Time Error"
					'End
				End If
				
				'check ban cdkeys
				If getBanCDKey Then
					cnnDB.Execute("UPDATE Company SET Company_PosString = '121832753'") ' date 2006-09-16 753
				End If
				
				If IsNumeric(rs.Fields("Company_Code").Value) Then
					gSecKey = rs.Fields("Company_Code").Value
					If Len(rs.Fields("Company_Code").Value) = 13 Then
						'checkSecurity = True
						'Exit Function
					End If
				End If
				lPassword = "pospospospos"
				lCode = getSerialNumber
				
				'to handle WIN 98 problem of not picking HD Serial of server
                If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value.ToString <> "" Then
                    'If lCode = "0" And LCase(Left(serverPath, 3)) <> "c:\" Then
                    checkSecurity = True
                    Exit Function
                    'Else
                End If
				'to handle WIN 98 problem of not picking HD Serial of server
				
				leCode = Encrypt(lCode, lPassword)
				For x = 1 To Len(leCode)
					If Asc(Mid(leCode, x, 1)) < 33 Then
						leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
					End If
				Next x
				
                If rs.Fields("Company_Code").Value.ToString = leCode Then
                    'If IsNull(rs("Company_TerminateDate")) Then
                    checkSecurity = True
                    'Else
                    '    If Date > rs("Company_TerminateDate") Then
                    '        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                    '        checkSecurity = False
                    Exit Function
                    '    End If
                    'End If
                Else
                    If checkDayEnds() = True Then
                        checkSecurity = True
                        Exit Function
                    Else
                        txtCompany.Text = rs.Fields("Company_Name").Value
                        txtCompany.SelectionStart = 0
                        txtCompany.SelectionLength = 999

                        loadLanguage()
                        Me.ShowDialog(frmLogin)
                    End If
                End If
				
				'End If
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
	
	
	Public Function checkDayEnds() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rsComp As ADODB.Recordset
		Dim rsPOS As ADODB.Recordset
		Dim x As Short
		checkDayEnds = False
		If openConnection() Then
			rsComp = getRS("SELECT * From Company")
			If rsComp.RecordCount Then
				'If rsComp("Company_Code") <> "" Then
                If rsComp.Fields("Company_Code").Value.ToString <> "" And Len(rsComp.Fields("Company_Code").Value.ToString) >= 6 And Not IsNumeric(rsComp.Fields("Company_Code").Value.ToString) Then
                    'Set rs = getRS("SELECT Max(DayEnd.DayEndID) AS maxID FROM DayEnd;")
                    'If rs.BOF Or rs.EOF Then
                    '    checkDayEnds = False
                    '    Exit Function
                    'Else
                    '    If rs("maxID") >= 15 Then
                    blChkSecu = False
                    frmRegisterAgree.blChkSecure()
                    If blChkSecu = True Then
                        'new serialization check    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '" & Replace("3571592584560", "'", "''") & "';"

                        loadPreSerials()

                        lPassword = "pospospospos"
                        lCode = getSerialNumber()
                        'MsgBox "lCode  " & lCode
                        lCode = Encrypt(lCode, lPassword)
                        'MsgBox "lCode  " & lCode
                        cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" & Replace(lCode, "'", "''") & "';")

                        lPassword = LTrim(Replace(rsComp.Fields("Company_Name").Value, "'", ""))
                        lPassword = RTrim(Replace(lPassword, " ", ""))
                        lPassword = Trim(Replace(lPassword, ".", ""))
                        lPassword = LCase(lPassword)
                        leCode = ""
                        lCode = ""
                        For x = 1 To Len(lPassword)
                            lCode = Mid(lPassword, x, 1)
                            lCode = CStr(Asc(lCode))
                            If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
                                leCode = leCode & Mid(lPassword, x, 1)
                            End If
                        Next
                        lPassword = leCode
                        rsPOS = getRS("SELECT * FROM POS;") 'WHERE POS_IPAddress = 'localhost';")
                        If rsPOS.RecordCount Then
                            Do While rsPOS.EOF = False
                                If rsPOS.Fields("POS_IPAddress").Value = "localhost" Then
                                    lCode = CStr(rsPOS.Fields("POS_CID").Value * 135792468)
                                    leCode = Encrypt(lCode, lPassword)
                                    'leCode = leCode & Chr(255) & strCDKey
                                    leCode = leCode & Chr(255) & preSerial(rsPOS.Fields("POSID").Value)
                                    cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rsPOS.Fields("POS_CID").Value & ";")
                                End If
                                rsPOS.MoveNext()
                            Loop
                        End If

                        'new serialization check
                        checkDayEnds = True
                        Exit Function
                    Else
                        checkDayEnds = False
                        Exit Function
                    End If
                    '    Else
                    '        checkDayEnds = False
                    '        Exit Function
                    '    End If
                    'End If

                Else
                    checkDayEnds = False
                    Exit Function
                End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
	
	Private Sub loadPreSerials()
		ReDim preSerial(20)
		preSerial(0) = "B0ECB9F444347C66BB00001"
		preSerial(1) = "FB1863769BB68424B300002"
		preSerial(2) = "F1208835E63FE05D1300003"
		preSerial(3) = "EE8F5582E537C66B7400004"
		preSerial(4) = "1C15A97DF770A6E63300005"
		preSerial(5) = "4CFC05D13B2D03E7DD00006"
		preSerial(6) = "C83A20C3DC939C68D000007"
		preSerial(7) = "6698D3D57C753FDAC700008"
		preSerial(8) = "5DFE7F99EB090ED61F00009"
		preSerial(9) = "4C731DBD61F37B251300010"
		preSerial(10) = "64A72A7C0FF747EB4B00011"
		preSerial(11) = "8DD534E4DD07EAFA4B00012"
		preSerial(12) = "D37B45C581B4B2FF8400013"
		preSerial(13) = "2770B6008FF9CCA4FE00014"
		preSerial(14) = "E9764E9AF15982683000015"
		preSerial(15) = "B0AA5F109111C3099A00016"
		preSerial(16) = "620F3A446C700D8DE300017"
		preSerial(17) = "256B1211EC123E651700018"
		preSerial(18) = "559250B55D876EC98100019"
		preSerial(19) = "3999B6F959488AC1FD00020"
	End Sub
	
	Private Sub frmRegister_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

    Private Sub frmRegister_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        picMode.AddRange(New Panel() {_picMode_0, _picMode_1})
    End Sub
End Class