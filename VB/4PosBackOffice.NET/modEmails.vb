Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module modEmails
	' Registry API functions
	Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal fRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
	
	Const ODBC_ADD_DSN As Short = 1 ' Add data source
	Const ODBC_REMOVE_DSN As Short = 3 ' Delete data source
	
	
	Private Structure STARTUPINFO
		Dim cb As Integer
		Dim lpReserved As String
		Dim lpDesktop As String
		Dim lpTitle As String
		Dim dwX As Integer
		Dim dwY As Integer
		Dim dwXSize As Integer
		Dim dwYSize As Integer
		Dim dwXCountChars As Integer
		Dim dwYCountChars As Integer
		Dim dwFillAttribute As Integer
		Dim dwFlags As Integer
		Dim wShowWindow As Short
		Dim cbReserved2 As Short
		Dim lpReserved2 As Integer
		Dim hStdInput As Integer
		Dim hStdOutput As Integer
		Dim hStdError As Integer
	End Structure
	
	Private Structure PROCESS_INFORMATION
		Dim hProcess As Integer
		Dim hThread As Integer
		Dim dwProcessID As Integer
		Dim dwThreadID As Integer
	End Structure
	
	Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'UPGRADE_WARNING: Structure PROCESS_INFORMATION may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure STARTUPINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function CreateProcessA Lib "kernel32" (ByVal lpApplicationName As String, ByVal lpCommandLine As String, ByVal lpProcessAttributes As Integer, ByVal lpThreadAttributes As Integer, ByVal bInheritHandles As Integer, ByVal dwCreationFlags As Integer, ByVal lpEnvironment As Integer, ByVal lpCurrentDirectory As String, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As Integer
	
	Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
	
	Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer
	
	Private Const NORMAL_PRIORITY_CLASS As Integer = &H20
	Private Const INFINITE As Short = -1
	
	
	Public Function ExecCmd(ByRef cmdline As String) As Object
		Dim ret As Integer
		Dim proc As PROCESS_INFORMATION
		Dim start As STARTUPINFO
		
		'Initialize the STARTUPINFO structure:
		start.cb = Len(start)
		
		'Start the shelled application:
		ret = CreateProcessA(vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, vbNullString, start, proc)
		
		'Wait for the shelled application to finish:
		ret = WaitForSingleObject(proc.hProcess, INFINITE)
		Call GetExitCodeProcess(proc.hProcess, ret)
		Call CloseHandle(proc.hThread)
		Call CloseHandle(proc.hProcess)
		'UPGRADE_WARNING: Couldn't resolve default property of object ExecCmd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ExecCmd = ret
	End Function
	Sub SendSaleMail(ByRef stEmail_d As String, ByRef stAttchFile As String, ByRef compID As String)
        Dim id As Short
		Dim stFileName As String
		stFileName = serverPath & "HQSales\HQSales" & id & ".zip"
		
		stFileName = "HQSales" & compID & ".zip"

        ' MSAPISession calls now need to be using System.Net.Mail

        'frmDayEnd.MAPISession1.SignOn()
        'frmDayEnd.MAPIMessages1.SessionID = frmDayEnd.MAPISession1.SessionID
        'frmDayEnd.MAPIMessages1.Compose()
        'frmDayEnd.MAPIMessages1.RecipIndex = 0
        'frmDayEnd.MAPIMessages1.RecipDisplayName = stEmail_d
        'frmDayEnd.MAPIMessages1.ResolveName()
        'frmDayEnd.MAPIMessages1.AddressResolveUI = True
        'frmDayEnd.MAPIMessages1.ResolveName()
        'frmDayEnd.MAPIMessages1.RecipAddress = "smtp:" & Trim(stEmail_d)
        'frmDayEnd.MAPIMessages1.MsgSubject = "4POS Sales"
        'frmDayEnd.MAPIMessages1.MsgNoteText = "Store Sales as at " & Format(Now, "ddd, dd-mmm-yyyy hh:nn")
        'frmDayEnd.MAPIMessages1.AttachmentType = MSMAPI.AttachTypeConstants.mapData
        'frmDayEnd.MAPIMessages1.AttachmentName = stFileName '"HQSales.zip"
        ''frmDayEnd.MAPIMessages1.AttachmentPathName = serverPath & "HQSales\HQSales.zip"
        'frmDayEnd.MAPIMessages1.AttachmentPathName = stAttchFile 'Identifying company ID
        'frmDayEnd.MAPIMessages1.Send(False)
        'frmDayEnd.MAPISession1.SignOff()
		
	End Sub
	
	Public Sub CollectSalesHQ()
        Dim dateSeril As String
		Dim ldir1 As String
		Dim f_File As String
		Dim sFiles As Boolean
		Dim strFile As String
		Dim rs As ADODB.Recordset
		Dim FSO As New Scripting.FileSystemObject
		
		On Error GoTo ErrHQ
		
		rs = getRS("SELECT * FROM CompanyEmails")
		If rs.RecordCount Then strFile = serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip "
		
		Dim stEmail As String
		Dim k As Short
		Dim v_Email As Boolean
		If copyFilesFromPoints = True Then
			'ExecCmd  serverPath & "wzzip.exe " & serverPath & "HQSales\HQSales.zip " & serverPath & "HQSales\*.*"
			
			'now it will look  "c:\4POSServer\"  ExecCmd serverPath & "wzzip.exe " & strFile & serverPath & "HQSales\*.*"
			ExecCmd("c:\4POSServer\" & "wzzip.exe " & strFile & serverPath & "HQSales\*.*")
			'On Local Error Resume Next
			
			
			'UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dateSeril = Trim(Replace(CStr(Now), ":", ""))
			'UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dateSeril = Trim(Replace(dateSeril, "/", ""))
			'UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dateSeril = Trim(Replace(dateSeril, " ", ""))
			
			rs = getRS("SELECT * FROM CompanyEmails")
			If rs.RecordCount Then
				For k = 1 To 7
					stEmail = rs.Fields("Comp_Email" & k).Value
					If InStr(stEmail, "@") > 0 Then v_Email = True
					If InStr(stEmail, ":\") > 0 Then v_Email = True
					If InStr(stEmail, "\\") > 0 Then v_Email = True
				Next 
				If v_Email = False Then Exit Sub 'No valid email
				For k = 1 To 7
					stEmail = rs.Fields("Comp_Email" & k).Value
					If InStr(stEmail, "@") > 0 Then 'Validate email string...
						'SendSaleMail stEmail, rs("Comp_ID")
						SendSaleMail(stEmail, serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip", rs.Fields("Comp_ID").Value)
						
					ElseIf InStr(stEmail, "\\") > 0 Then  'Validate Netword Path string...
						System.Windows.Forms.Application.DoEvents()
						If Right(stEmail, 1) = "\" Then 
						Else 
							stEmail = stEmail & "\"
						End If
						If FSO.FolderExists(stEmail) Then
							System.Windows.Forms.Application.DoEvents()
							If FSO.FileExists(stEmail & "HQSales" & rs.Fields("Comp_ID").Value & ".zip") Then
								'UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								FSO.CopyFile(serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip", stEmail & "HQSales" & rs.Fields("Comp_ID").Value & "_" & dateSeril & ".zip", True)
							Else
								FSO.CopyFile(serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip", stEmail & "HQSales" & rs.Fields("Comp_ID").Value & ".zip", True)
							End If
						Else
						End If
						
					ElseIf InStr(stEmail, ":\") > 0 Then  'Validate Local Path string...
						
						If Right(stEmail, 1) = "\" Then 
						Else 
							stEmail = stEmail & "\"
						End If
						If FSO.FolderExists(stEmail) Then 
						Else 
							FSO.CreateFolder(stEmail)
						End If
						System.Windows.Forms.Application.DoEvents()
						If FSO.FileExists(stEmail & "HQSales" & rs.Fields("Comp_ID").Value & ".zip") Then
							'UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							FSO.CopyFile(serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip", stEmail & "HQSales" & rs.Fields("Comp_ID").Value & "_" & dateSeril & ".zip", True)
						Else
							FSO.CopyFile(serverPath & "HQSales\HQSales" & rs.Fields("Comp_ID").Value & ".zip", stEmail & "HQSales" & rs.Fields("Comp_ID").Value & ".zip", True)
						End If
						
					End If
				Next 
			End If
		End If
		
		Exit Sub
ErrHQ: 
		MsgBox(Err.Number & " : " & Err.Description & " : Path = " & stEmail)
		Resume Next
	End Sub
	Private Function copyFilesFromPoints() As Boolean
		Dim sFiles As Boolean
		Dim f_File As String
		Dim ldir1 As String
		Dim rj As ADODB.Recordset
		Dim FSO As New Scripting.FileSystemObject
		
		
		sFiles = False
		
		f_File = Trim(Str(Year(Today))) & "\" & Trim(Str(Month(Today))) & "\" & Trim(Str(VB.Day(Today)))
		
		rj = getRS("SELECT POS_Name FROM POS WHERE POS_Disabled = False AND POS_KitchenMonitor = False;")
		
		If rj.RecordCount Then
			If FSO.FolderExists(serverPath & "HQSales") Then 
			Else 
				FSO.CreateFolder(serverPath & "HQSales")
			End If
			
			'Make sure the HQSales file is empty...
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			ldir1 = Dir(serverPath & "HQSales\*.*")
			Do Until ldir1 = ""
				FSO.DeleteFile(serverPath & "HQSales\" & ldir1, True)
				'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				ldir1 = Dir()
			Loop 
			
			Do While rj.EOF = False
				If LCase(rj.Fields("POS_Name").Value) = "localhost" Then
					If FSO.FolderExists(serverPath & "data\Server\" & f_File) Then
						'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						ldir1 = Dir(serverPath & "data\Server\" & f_File & "\*.*")
						Do Until ldir1 = ""
							FSO.CopyFile(serverPath & "data\Server\" & f_File & "\" & ldir1, serverPath & "HQSales\" & ldir1, True)
							'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
							ldir1 = Dir()
							sFiles = True
						Loop 
					End If
				Else
					If FSO.FolderExists(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File) Then
						'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						ldir1 = Dir(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File & "\*.*")
						Do Until ldir1 = ""
							FSO.CopyFile(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File & "\" & ldir1, serverPath & "HQSales\" & ldir1, True)
							'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
							ldir1 = Dir()
							sFiles = True
						Loop 
						
					End If
				End If
				rj.moveNext()
			Loop 
		End If
		
		If sFiles = True Then
			copyFilesFromPoints = True
		Else
			copyFilesFromPoints = False
		End If
		
	End Function
End Module