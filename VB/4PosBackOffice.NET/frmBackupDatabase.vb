Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmBackupDatabase
	Inherits System.Windows.Forms.Form
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
	
	Private cnnDBclient As ADODB.Connection
	Private Const udChannel As Short = 1
	Private Const udPerson As Short = 2
	Private Const udPrice As Short = 4
	Private Const udStockGroup As Short = 8
	Private Const udSockItemSupplier As Short = 16
	Private Const udStockItemActualCost As Short = 32
	Private Const udSupplierStatic As Short = 64
	Private Const udSupplierOrder As Short = 128
	Private Const udSupplierDiscount As Short = 256
	Private Const udPromotion As Short = 512
	Private Const udRecipe As Short = 1024
	Private Const udCashTransaction As Short = 2048
	Private Const udIncrement As Short = 4096
    Public Function ExecCmd(ByRef cmdline As String) As Integer
        Dim ret As Integer
        Dim proc As PROCESS_INFORMATION
        Dim start As STARTUPINFO

        ' Initialize the STARTUPINFO structure:
        start.cb = Len(start)

        ' Start the shelled application:
        ret = CreateProcessA(vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, vbNullString, start, proc)

        ' Wait for the shelled application to finish:
        ret = WaitForSingleObject(proc.hProcess, INFINITE)
        Call GetExitCodeProcess(proc.hProcess, ret)
        Call CloseHandle(proc.hThread)
        Call CloseHandle(proc.hProcess)
        'UPGRADE_WARNING: Couldn't resolve default property of object ExecCmd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ExecCmd = ret
    End Function
	
	Private Sub loadLanguage()
		
		'NO COMPONENTS AVAILABLE FOR TRANSLATION!!!
		'Reccomend Removing text items from picture/image and adding them as
		'standalone, updatable label components.
		
		'No Component! [4POS Application Suite]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'No Component! [Database compression and backup in progress...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBackupDatabase.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub frmBackupDatabase_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
		tmrBackup.Enabled = True
	End Sub
	
	Private Sub tmrBackup_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrBackup.Tick
		Dim fso As New Scripting.FileSystemObject
		Dim lDir As String
		Dim rs As ADODB.Recordset
		On Error GoTo tmrBackup_Timer_Error
		lDir = Dir("C:\*.tmp")
		Do Until lDir = ""
			fso.DeleteFile("C:\" & lDir)
			lDir = Dir()
		Loop 
		lDir = Dir(serverPath & "report*.mdb")
		Do Until lDir = ""
			fso.DeleteFile(serverPath & "" & lDir)
			lDir = Dir()
		Loop 
		tmrBackup.Enabled = False
		If openConnection() Then
			rs = getRS("SELECT Count(Sale.SaleID) AS CountOfSaleID FROM Sale;")
			If rs.Fields("CountOfSaleID").Value Then
				rs.Close()
				modRecordSet.closeConnection()
				backupDatabase("Pricing")
				backupDatabase("Waitron")
				backupDatabase("templateReport")
				
			End If
		End If
		lDir = Dir(serverPath & "update\*.zip")
		Do Until lDir = ""
			Select Case LCase(lDir)
				Case "lqcontroller2.zip", "template.zip", "templatereport.zip"
					ExecCmd("c:\4posServer\wzunzip.exe " & serverPath & "update\" & lDir & " " & serverPath & "")
					fso.DeleteFile(serverPath & "update\" & lDir)
				Case "lqpos2.zip", "lqreport2.zip", "lqbackoffice2.zip", "lqbarcode2.zip", "lqautodayend.zip"
					
					ExecCmd("c:\4posServer\wzunzip.exe " & serverPath & "update\" & lDir & " c:\4POS\")
					fso.DeleteFile(serverPath & "update\" & lDir)
				Case "data"
			End Select
			lDir = Dir()
		Loop 
		Me.Close()
		Exit Sub
tmrBackup_Timer_Error: 
		MsgBox(Err.Description)
		Me.Close()
		
	End Sub
	
	Private Function backupDatabase(ByRef lDatabase As String) As Boolean
        Dim jetEngine As JRO.JetEngine
		Dim strSourceConnect As String
		Dim strDestConnect As String
		Dim fso As New Scripting.FileSystemObject
		
		fso.CopyFile(serverPath & "" & lDatabase & ".mdb", serverPath & "" & lDatabase & ".bk0", True)
		On Error GoTo backupDatabase_Error
		If fso.FileExists(serverPath & "" & lDatabase & ".bak") Then
			fso.DeleteFile(serverPath & "" & lDatabase & ".bak", True)
		End If
		
		strSourceConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & serverPath & "" & lDatabase & ".mdb;User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
		strDestConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & serverPath & "" & lDatabase & ".bak;User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
		jetEngine = New JRO.JetEngine
		
		' Compact and encrypt the database specified by strSourceDB
		' to the name and path specified by strDestDB.
		jetEngine.CompactDatabase(strSourceConnect, strDestConnect)
		'UPGRADE_NOTE: Object jetEngine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		jetEngine = Nothing
		fso.DeleteFile(serverPath & "" & lDatabase & ".mdb")
		fso.CopyFile(serverPath & "" & lDatabase & ".bak", serverPath & "" & lDatabase & ".mdb", True)
		openConnection()
		saveDatabase(lDatabase)
		backupDatabase = True
		Exit Function
		
backupDatabase_Error: 
		fso.CopyFile(serverPath & "" & lDatabase & ".bk0", serverPath & "" & lDatabase & ".mdb", True)
		openConnection()
		backupDatabase = False
	End Function
	
	Public Sub saveDatabase(ByRef lDatabase As String)
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lPath As String
		On Error GoTo saveDatabase_Error
		
		rs = getRS("SELECT Company.Company_BackupPath, Right([Company_DayEndID],1) AS file FROM Company;")
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rs.Fields("Company_BackupPath").Value) Then
			GoTo saveDatabase_Error
		Else
			If rs.Fields("Company_BackupPath").Value = "" Then
				lPath = My.Application.Info.DirectoryPath
			Else
				lPath = rs.Fields("Company_BackupPath").Value
			End If
			If VB.Right(lPath, 1) <> "\" Then lPath = lPath & "\"
			lPath = lPath & rs.Fields("file").Value & ".bak"
			
			If fso.FileExists(lPath) Then fso.DeleteFile(lPath, True)
			fso.CopyFile(serverPath & "" & lDatabase & ".mdb", lPath, True)
		End If
		
		Exit Sub
saveDatabase_Error: 
	End Sub
End Class