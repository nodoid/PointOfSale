Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmMaster
	Inherits System.Windows.Forms.Form
	' Registry API functions
	Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hWndParent As Integer, ByVal fRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
	
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
	
	Dim cnnDBmaster As ADODB.Connection
	Dim cnnDBWaitron As ADODB.Connection
	Dim gMasterPath As String
	
	Dim gSecurityCode As String
	Dim gSecKey As String

    Dim Label1 As New List(Of Label)

	Private Sub loadLanguage()
		
		'frmMaster = No Code        [4POS Company Loader...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMaster.Caption = rsLang("LanguageLayoutLnk_Description"): frmMaster.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(2) = No Code        [Company]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblCompany = No Code/Dynamic/NA?
		
		'Label1(3) = No Code        [Database]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblPath = No Code/Dynamic/NA?
		
		'Label1(4) = No Code        [Directory]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblDir = No Code/Dynamic/NA?
		
		'Label1(0) = No Code        [User ID]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490 'Password|Checked
        If rsLang.RecordCount Then _Label1_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label1_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1389 'OK|Checked
		If rsLang.RecordCount Then cmdOK.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdOK.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdBuild = No Code         [Synchronize Via Email]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuild.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuild.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: Caption has a spelling mistake!!!
		'frmRegister = No Code      [Unregistered Version]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmRegister.Caption = rsLang("LanguageLayoutLnk_Description"): frmRegister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code           [Store Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdRegistration = No Code  [Registration]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdRegistration.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRegistration.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMaster.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Function ExecCmd(ByRef cmdline As String) As Integer
        Dim ret As Integer
        Dim proc As PROCESS_INFORMATION
        Dim start As STARTUPINFO

        ' Initialize the STARTUPINFO structure:
        start.cb = Len(start)

        ' Start the shelled application:
        ret = CreateProcessA(vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, vbNullString, start, proc)

        ' Wait for the shelled application to finish:
        ret = WaitForSingleObject(proc.hProcess, 1) ' INFINITE)
        Call GetExitCodeProcess(proc.hProcess, ret)
        Call CloseHandle(proc.hThread)
        Call CloseHandle(proc.hProcess)
        ExecCmd = ret
    End Function
	Private Function AddDSN(ByVal strDSN As String, ByVal strDescription As String, ByRef strDB As String, Optional ByRef delete As Boolean = False) As Boolean
		
		'------------------------------------
		'Usage:
		' AddDSN "MyDSN", "This is a test", "C:\test\myDB.mdb"
		'------------------------------------
		
		On Error GoTo Hell
		
		'win 7
		Dim fso As New Scripting.FileSystemObject
		Dim textstream As Scripting.TextStream
		Dim lString As String
		If Win7Ver = True Then
			If fso.FileExists("C:\4POS\4POSWinPath.txt") Then fso.DeleteFile("C:\4POS\4POSWinPath.txt", True)
			
			lString = Replace(strDB, "\pricing.mdb", "\")
			textstream = fso.OpenTextFile("C:\4POS\4POSWinPath.txt", Scripting.IOMode.ForWriting, True)
			textstream.Write(lString)
			textstream.Close()
			
		End If
		'win 7
		
		
		'Set the Driver Name
		Dim strDriver As String
		Dim strFolder As String
		strFolder = strDB
		Do Until VB.Right(strFolder, 1) = "\"
			strFolder = VB.Left(strFolder, Len(strFolder) - 1)
		Loop 
		strDriver = "Microsoft Access Driver (*.mdb)"
		
		'Build the attributes - Attributes must be Null separated
        Dim strAttributes As String = ""
		strAttributes = strAttributes & "DESCRIPTION=" & strDescription & Chr(0)
		strAttributes = strAttributes & "DSN=" & strDSN & Chr(0)
		'strAttributes = strAttributes & "DATABASE=" & strDB & Chr(0)
		strAttributes = strAttributes & "DBQ=" & strDB & Chr(0)
		strAttributes = strAttributes & "systemDB=" & strFolder & "Secured.mdw" & Chr(0)
		strAttributes = strAttributes & "UID=liquid" & Chr(0)
		strAttributes = strAttributes & "PWD=lqd" & Chr(0)
		
		'Create DSN
		AddDSN = SQLConfigDataSource(0, ODBC_REMOVE_DSN, strDriver, strAttributes)
		If delete Then 
		Else 
			AddDSN = SQLConfigDataSource(0, ODBC_ADD_DSN, strDriver, strAttributes)
		End If
        AddDSN = True
		Exit Function
		
Hell: 
		AddDSN = False
		MsgBox(Err.Description)
	End Function
	
    Public Function getRSMaster(ByRef sql As String) As ADODB.Recordset
        getRSMaster = New ADODB.Recordset
        getRSMaster.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        getRSMaster.Open(sql, cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
    End Function
	
    Private Function getMasterDB() As Boolean
        On Error GoTo openConnection_Error
        'getMasterDB = True
        cnnDBmaster = New ADODB.Connection
        Dim filename As String
        If Win7Ver() = True Then
            filename = "c:\4posmaster\4posmaster.mdb"
        Else
            filename = "4posmaster.mdb"
        End If
        If System.IO.File.Exists(filename) = True Then
            With cnnDBmaster
                '.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0"
                .Provider = "Microsoft.ACE.OLEDB.12.0"
                .Open(filename)
                '.Open()
                getMasterDB = True
            End With
        Else
            getMasterDB = False
        End If

        'cnnDBmaster.Open("4posMaster")
        'gMasterPath = Split(Split(cnnDBmaster.ConnectionString, ";DBQ=")(1), ";")(0)
        'gMasterPath = Split(LCase(gMasterPath), "4posmaster.mdb")(0) '

        'win 7
        Dim fso As New Scripting.FileSystemObject
        Dim textstream As Scripting.TextStream
        Dim lString As String
        If Win7Ver() = True Then
            'If fso.FileExists("C:\4POS\4POSWinPath.txt") Then
            '    Set textstream = fso.OpenTextFile("C:\4POS\4POSWinPath.txt", ForReading, True)
            '    lString = textstream.ReadAll
            '    serverPath = lString '& "pricing.mdb"
            'Else
            '    serverPath = "C:\4POSServer\" '"pricing.mdb"
            'End If
            gMasterPath = "c:\4posmaster\"
            'getMasterDB = True
            Exit Function
        End If
        'win 7

        gMasterPath = Split(Split(cnnDBmaster.ConnectionString, ";DBQ=")(1), ";")(0)
        gMasterPath = Split(LCase(gMasterPath), "4posmaster.mdb")(0) '

        Exit Function
openConnection_Error:
        getMasterDB = False
    End Function
    Public Function openConnectionWaitron() As Boolean
        On Error GoTo openConnection_Error
        Dim createDayend As Boolean
        Dim strDBPath As String
        createDayend = False
        openConnectionWaitron = True
        cnnDBWaitron = New ADODB.Connection
        strDBPath = serverPath & "Waitron.mdb"
        With cnnDBWaitron
            .Provider = "Microsoft.ACE.OLEDB.12.0"
            .Properties("Jet OLEDB:System Database").Value = serverPath & "Secured.mdw"
            .Open(strDBPath, "liquid", "lqd")
        End With
        Exit Function

openConnection_Error:
        openConnectionWaitron = False

    End Function
	Public Sub closeConnectionWaitron()
		cnnDBWaitron.Close()
		cnnDBWaitron = Nothing
	End Sub
	Public Function getRSwaitron(ByRef sql As Object) As ADODB.Recordset
		getRSwaitron = New ADODB.Recordset
		getRSwaitron.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		getRSwaitron.Open(sql, cnnDBWaitron, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
	End Function
	Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
        Dim x As Integer
        Dim TMPgMasterPath As String
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lDir As String
		On Error GoTo buildError
		If MsgBox("A data instruction will prepare a download for each store of the latest stock and pricing data." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Prepare Download") = MsgBoxResult.Yes Then
			
			TMPgMasterPath = gMasterPath
			gMasterPath = "c:\4POSServer\"
			
			If fso.FolderExists(gMasterPath & "Data\") Then 
			Else 
				fso.CreateFolder(gMasterPath & "Data\")
			End If
			lDir = Dir(gMasterPath & "data\*.*")
			Do Until lDir = ""
				fso.DeleteFile(gMasterPath & "data\" & lDir, True)
				lDir = Dir()
			Loop 
			Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			System.Windows.Forms.Application.DoEvents()
			rs = getRSMaster("SELECT 1 as MasterID, #" & Today & "# as Master_DateReplica")
			rs.save(gMasterPath & "Data\Master.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Catalogue")
			rs.save(gMasterPath & "Data\catalogue.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PriceSet")
			rs.save(gMasterPath & "Data\PriceSet.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Channel ORDER BY ChannelID")
			rs.save(gMasterPath & "Data\channel.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Deposit ORDER BY DepositID")
			rs.save(gMasterPath & "Data\Deposit.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PackSize ORDER BY PackSizeID")
			rs.save(gMasterPath & "Data\PackSize.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Person ORDER BY PersonID")
			rs.save(gMasterPath & "Data\Person.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PersonChannelLnk")
			rs.save(gMasterPath & "Data\PersonChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PriceChannelLnk")
			rs.save(gMasterPath & "Data\PriceChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PricingGroup ORDER BY PricingGroupID")
			rs.save(gMasterPath & "Data\PricingGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PricingGroupChannelLnk")
			rs.save(gMasterPath & "Data\PricingGroupChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PropChannelLnk")
			rs.save(gMasterPath & "Data\PropChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM [Set] ORDER BY SetID")
			rs.save(gMasterPath & "Data\Set.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM SetItem")
			rs.save(gMasterPath & "Data\SetItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Shrink ORDER BY ShrinkID")
			rs.save(gMasterPath & "Data\Shrink.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM ShrinkItem")
			rs.save(gMasterPath & "Data\ShrinkItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockGroup ORDER BY StockGroupID")
			rs.save(gMasterPath & "Data\StockGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockItem ORDER BY StockItemID")
			rs.save(gMasterPath & "Data\stockitem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Supplier ORDER BY SupplierID")
			rs.save(gMasterPath & "Data\Supplier.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM SupplierDepositLnk")
			rs.save(gMasterPath & "Data\SupplierDepositLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Promotion")
			rs.save(gMasterPath & "Data\Promotion.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PromotionItem")
			rs.save(gMasterPath & "Data\PromotionItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockBreak")
			rs.save(gMasterPath & "Data\StockBreak.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM RecipeStockItemLnk")
			rs.save(gMasterPath & "Data\RecipeStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM CashTransaction")
			rs.save(gMasterPath & "Data\CashTransaction.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Increment")
			rs.save(gMasterPath & "Data\Increment.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM IncrementStockItemLnk")
			rs.save(gMasterPath & "Data\IncrementStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM IncrementQuantity")
			rs.save(gMasterPath & "Data\IncrementQuantity.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Message")
			rs.save(gMasterPath & "Data\Message.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM MessageItem")
			rs.save(gMasterPath & "Data\MessageItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockItemMessageLnk")
			rs.save(gMasterPath & "Data\StockItemMessageLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			openConnectionWaitron()
			rs = getRSwaitron("SELECT * FROM POSMenu")
			rs.save(gMasterPath & "Data\POSMenu.rs", ADODB.PersistFormatEnum.adPersistADTG)
			
			ExecCmd(gMasterPath & "wzzip.exe " & gMasterPath & "Data\data.zip " & gMasterPath & "Data\*.*")
			
			If fso.FileExists(gMasterPath & "Data.zip") Then fso.DeleteFile(gMasterPath & "Data.zip", True)
			
			fso.CopyFile(gMasterPath & "Data\data.zip", gMasterPath & "Data.zip", True)
			
			rs = getRSMaster("SELECT locationCompany_1.locationCompanyID, locationCompany.locationCompany_Email FROM locationCompany INNER JOIN (locationCompany AS locationCompany_1 INNER JOIN location ON locationCompany_1.locationCompany_LocationID = location.locationID) ON locationCompany.locationCompany_LocationID = location.locationID WHERE (((locationCompany_1.locationCompanyID)=" & lblCompany.Tag & "));")
			
			On Error Resume Next
            'MAPISession1.SignOn()
            'MAPIMessages1.SessionID = MAPISession1.SessionID
            'MAPIMessages1.Compose()
			x = -1
			On Error Resume Next
			Do Until rs.EOF
				
				If rs.Fields("locationCompany_Email").Value <> "" Then
					x = x + 1
                    'MAPIMessages1.RecipIndex = x
                    'MAPIMessages1.RecipDisplayName = rs.Fields("locationCompany_Email").Value
                    'MAPIMessages1.ResolveName()
				End If
				
				rs.moveNext()
			Loop 
			rs = getRSMaster("SELECT locationAudit.locationAuditID, locationAudit.locationAudit_Email FROM locationCompany INNER JOIN locationAudit ON locationCompany.locationCompany_LocationID = locationAudit.locationAudit_LocationID WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
			Do Until rs.EOF
				x = x + 1
                'MAPIMessages1.RecipIndex = x
                'MAPIMessages1.RecipDisplayName = rs.Fields("locationAudit_Email").Value
                'MAPIMessages1.ResolveName()
				rs.moveNext()
			Loop 
            'MAPIMessages1.MsgSubject = "4POS Data"
            'MAPIMessages1.MsgNoteText = "4POS Pricing update as at " & Format(Now, "ddd, dd-mmm-yyyy hh:nn")
            'MAPIMessages1.AttachmentType = MSMAPI.AttachTypeConstants.mapData
            'MAPIMessages1.AttachmentName = "data.zip"
            'MAPIMessages1.AttachmentPathName = gMasterPath & "data.zip"
            'MAPIMessages1.Send()
            'MAPISession1.SignOff()
			
			gMasterPath = TMPgMasterPath
		End If
		Me.Cursor = System.Windows.Forms.Cursors.Default
		
		Exit Sub
buildError: 
		If Err.Number = 53 Then
			MsgBox("Please ensure if you have 'WinZip Command Line Support Add-On' installed on your system.")
		Else
			MsgBox(Err.Number & " " & Err.Description)
		End If
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdCompany_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCompany.Click
		cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Name = '" & Replace(txtCompany.Text, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
		loadCompanies()
		lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
        lblCompany.Text = lvLocation.FocusedItem.Text & " - " & lvLocation.FocusedItem.SubItems(0).Text
		
	End Sub
	
	Private Sub cmdDatabase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDatabase.Click
        Me.CDmasterOpen.Title = "Select the path to " & lvLocation.FocusedItem.SubItems(0).Text & " application database ..."
		CDmasterOpen.Filter = "Application Data Base|pricing.mdb"
		CDmasterOpen.FileName = ""
		Me.CDmasterOpen.ShowDialog()
		If CDmasterOpen.FileName = "" Then
		Else
			lblCompany.Tag = Mid(lvLocation.FocusedItem.Name, 2)
			cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" & Replace(CDmasterOpen.FileName, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & Mid(lvLocation.FocusedItem.Name, 2) & "));")
			loadCompanies()
			lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
			lvLocation_DoubleClick(lvLocation, New System.EventArgs())
			cmdCompany_Click(cmdCompany, New System.EventArgs())
		End If
		
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim createDayend As Boolean
		Dim x As Decimal
        Dim revName As String = ""
		'loading languages files
		'Dim rs As Recordset
		Dim tempLID As Short
		tempLID = 1
		rs = getRS("SELECT Company_LanguageID, Company_RightTL From Company")
		If rs.RecordCount Then
			If IsDbNull(rs.Fields("Company_LanguageID").Value) Then tempLID = 1
			If rs.Fields("Company_LanguageID").Value = 0 Then
				tempLID = 1
			Else
				tempLID = rs.Fields("Company_LanguageID").Value
			End If
			
			If IsDbNull(rs.Fields("Company_RightTL").Value) Then iLangRTL = 0
			If rs.Fields("Company_RightTL").Value = 0 Then
				iLangRTL = 0
			Else
				iLangRTL = rs.Fields("Company_RightTL").Value
			End If
		Else
			tempLID = 1
			iLangRTL = 0
		End If
		
		rsLang = getRS("SELECT * From LanguageLayoutLnk Where LanguageLayoutLnk_LanguageLayoutID = " & tempLID & ";")
		'loading languages files
		
		'loading help file
		Dim helpPath As String
		'helpPath = App.Path & "\4POS4Dummies.chm"
		'If Command = "1" Then helpPath = "C:\4POS\4POS4Dummies.chm"
		helpPath = "C:\4POS\4POS4Dummies.chm"
		If fso.FileExists(helpPath) Then
			rsHelp = getRS("SELECT * From Help;")
		Else
			rsHelp = getRS("SELECT 0 AS Help_Section, 'A' AS Help_Form From Help;")
		End If
		'loading help file
		
		On Error Resume Next
		rs = getRS("SELECT * FROM Person WHERE (Person_UserID = '" & Replace(Me.txtUserName.Text, "'", "''") & "') AND (Person_Password = '" & Replace(Me.txtPassword.Text, "'", "''") & "')")
		Dim rsRpt As ADODB.Recordset
		If rs.BOF Or rs.EOF Then
			MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login")
			txtPassword.Focus()
		Else
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
				If IsDbNull(rsRpt.Fields("Company_LoadTRpt").Value) Then
                ElseIf rsRpt.Fields("Company_LoadTRpt").Value = 0 Then
                Else
                    If fso.FileExists(serverPath & "templateReport1.mdb") Then
                        If fso.FileExists(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb") Then fso.DeleteFile(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb", True)
                        If fso.FileExists(serverPath & "templateReport.mdb") Then fso.DeleteFile(serverPath & "templateReport.mdb", True)

                        fso.CopyFile(serverPath & "templateReport1.mdb", serverPath & "templateReport.mdb", True)
                    End If
                End If
				
				frmMenu.loadMenu("stock")
				If fso.FileExists(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb") Then
				Else
					fso.CopyFile(serverPath & "templateReport.mdb", serverPath & "report" & frmMenu.lblUser.Tag & ".mdb")
					createDayend = True
				End If
				If openConnectionReport() Then
				Else
					MsgBox("Unable to locate the Report Database!" & vbCrLf & vbCrLf & "The Update Controller wil terminate.", MsgBoxStyle.Critical, "SERVER ERROR")
					End
				End If
				If createDayend Then
					'                cnnDBreport.Execute "DELETE * FROM Report"
					'                cnnDBreport.Execute "INSERT INTO Report ( ReportID, Report_DayEndStartID, Report_DayEndEndID, Report_Heading ) SELECT 1 AS reportKey, Max(aDayEnd.DayEndID) AS MaxOfDayEndID, Max(aDayEnd.DayEndID) AS MaxOfDayEndID1, 'From ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' to ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' covering a dayend range of 1 days' AS theHeading FROM aDayEnd;"
					'                frmUpdateDayEnd.show 1
					frmMenu.cmdToday_Click(Nothing, New System.EventArgs())
					frmMenu.cmdLoad_Click(Nothing, New System.EventArgs())
				End If
				
				rs = getRSreport("SELECT DayEnd.DayEnd_Date AS fromDate, DayEnd_1.DayEnd_Date AS toDate FROM (Report INNER JOIN DayEnd ON Report.Report_DayEndStartID = DayEnd.DayEndID) INNER JOIN DayEnd AS DayEnd_1 ON Report.Report_DayEndEndID = DayEnd_1.DayEndID;")
				If rs.RecordCount Then
                    frmMenu._DTPicker1_0.Value = Format(rs.Fields("fromDate").Value, "yyyy")
                    frmMenu._DTPicker1_0.Value = Format(rs.Fields("fromDate").Value, "mm")
                    frmMenu._DTPicker1_0.Value = Format(rs.Fields("fromDate").Value, "dd")
                    frmMenu._DTPicker1_1.Value = Format(rs.Fields("toDate").Value, "yyyy")
                    frmMenu._DTPicker1_1.Value = Format(rs.Fields("toDate").Value, "mm")
                    frmMenu._DTPicker1_1.Value = Format(rs.Fields("toDate").Value, "dd")
				End If
				frmMenu.setDayEndRange()
				frmMenu.lblDayEndCurrent.Text = frmMenu.lblDayEnd.Text
			Else
				MsgBox("You do not have the correct permissions to access the 4POS Office Application, try again!", MsgBoxStyle.Exclamation, "Login")
				Me.txtUserName.Focus()
				System.Windows.Forms.SendKeys.Send("{Home}+{End}")
			End If
		End If
		
		
		
	End Sub
	
	Private Sub BuildRegistrationKey()
		Dim x As Short
		Dim lCode, leCode As String
		gSecurityCode = UCase(txtCompany.Text) & "XDFHWPGMIJ"
		gSecurityCode = Replace(gSecurityCode, " ", "")
		gSecurityCode = Replace(gSecurityCode, "'", "")
		gSecurityCode = Replace(gSecurityCode, """", "")
		gSecurityCode = Replace(gSecurityCode, ",", "")
		For x = 1 To 10
			gSecurityCode = VB.Left(gSecurityCode, x) & Replace(Mid(gSecurityCode, x + 1), Mid(gSecurityCode, x, 1), "")
		Next x
		gSecurityCode = VB.Left(gSecurityCode, 10)
		lCode = getSerialNumber
		leCode = ""
		On Error Resume Next
		For x = 1 To Len(lCode)
			leCode = leCode & Mid(gSecurityCode, CDbl(Mid(lCode, x, 1)) + 1, 1)
		Next x
		On Error GoTo 0
		lblCode.Text = leCode
		
	End Sub
	
	Private Sub Command1_Click()
		If checkSecurity() Then
			Me.frmRegister.Visible = False
		Else
			Me.frmRegister.Visible = True
			BuildRegistrationKey()
		End If
	End Sub
	
	Private Sub cmdRegistration_Click_OLD()
        Dim lCode As String
        Dim lPassword As String
        Dim x As Integer
        Dim lNewString As String
		Dim fso As New Scripting.FileSystemObject
		Const securtyStringReply As String = "9487203516"
		
        'Exit Sub
		
		If MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") = MsgBoxResult.Yes Then
			
			If Len(gSecKey) = 12 Then
				lNewString = ""
				For x = 1 To Len(txtKey.Text)
					If IsNumeric(Mid(txtKey.Text, x, 1)) Then
                        lNewString = lNewString & InStr(securtyStringReply, Mid(txtKey.Text, x, 1)) - 1
                    End If
				Next x
				cmdCompany_Click(cmdCompany, New System.EventArgs())
				Exit Sub
			Else
				lNewString = ""
				For x = 1 To Len(txtKey.Text)
					If IsNumeric(Mid(txtKey.Text, x, 1)) Then
                        lNewString = lNewString & InStr(securtyStringReply, Mid(txtKey.Text, x, 1)) - 1
                    End If
				Next x
				If lNewString <> "" Then
					If System.Math.Abs(CDbl(lNewString)) = System.Math.Abs(CDbl(getSerialNumber())) Then
						lPassword = "pospospospos"
						lCode = getSerialNumber
						If lCode <> "" Then
                            lCode = Encrypt(lCode, lPassword)
                            cmdCompany_Click(cmdCompany, New System.EventArgs())
                            cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" & Replace(lCode, "'", "''") & "';")
                            frmRegister.Visible = False
                        End If
						
						Exit Sub
					End If
				End If
			End If
		End If
		MsgBox("The 'Activation key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
	End Sub
	
	Private Sub cmdBegin_Click_OLD()
        Dim rs As ADODB.Recordset
		If Trim(txtCompany.Text) <> "" Then
			'cnnDB.Execute "UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'"
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
                If IsDBNull(rs("Company_TerminateDate")) Then
                    cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                Else
                    'If (Date + 2) > rs("Company_TerminateDate") Then
                    '    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                    '    checkSecurity = False
                    '   Exit Function
                    'End If
                End If
            End If
		End If
	End Sub
	
	Private Sub cmdBegin_Click()
        Dim rs As ADODB.Recordset
		Dim vValue As String
        Dim hkey As String
		Dim lRetVal As Integer
		If Trim(txtCompany.Text) <> "" Then
			cnnDB.Execute("UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'")
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then

                'check advance date expiry system
                On Error Resume Next
                vValue = ""
                lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_QUERY_VALUE, hkey)
                lRetVal = QueryValueEx(hkey, "ShellClass", vValue)
                RegCloseKey(hkey)
                If vValue = "" Then
                    vValue = "0"
                Else
                    If vValue <> "0" Then vValue = CStr(CDate("&H" & vValue))
                End If

                If IsDBNull(rs("Company_TerminateDate")) And vValue = "0" Then
                    cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                    lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                    lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                    SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                    RegCloseKey(hkey)
                Else
                    If IsDBNull(rs("Company_TerminateDate")) And vValue <> "0" Then
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

                    If IsDBNull(rs("Company_TerminateDate")) Then
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
	
	Private Sub cmdRegistration_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRegistration.Click
		Dim x As Short
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		
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
								'Else
								'    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID=" & rs("POS_CID") & ";"
							End If
							rs.moveNext()
						Loop 
					End If
					'new serialization check
					frmRegister.Visible = False
				End If
				
			End If
			
		Else
			MsgBox("A Company name is required." & vbCrLf & vbCrLf & "If you do not want to register now, Press then 'Exit Button'.", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
			txtCompany.Focus()
		End If
	End Sub
	
	Private Sub frmMaster_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim rs As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject
        Dim lFile As String
        Label1.AddRange(New Label() {_Label1_0, _Label1_1, _Label1_2, _Label1_3, _Label1_4})
        'ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 0)

        ExecCmd("cmd /C DEL c:\*.tmp")

        If fso.FileExists("C:\4POS\pos\data.ug") Then
            If fso.FileExists("C:\4POS\pos\4POSupgrade.exe") Then
                Shell("C:\4POS\pos\4POSupgrade.exe", AppWinStyle.NormalFocus)
            Else
                MsgBox("An upgrade is required, but the upgrade unility can not be located!" & vbCrLf & vbCrLf & "Please contact a 4POS representative to assist you in resolving this problem.", MsgBoxStyle.Critical, "UPGRADE")
            End If
            End
        End If

        setShortDateFormat()

        Dim tempLID As Short
        Dim helpPath As String
        Dim DayEndtextstream As Scripting.TextStream
        Dim lString As String
        If getMasterDB() Then
            'loadLanguage
            loadCompanies()
        Else
            If openConnection() Then
            Else
                If fso.FileExists("c:\4posServer\pricing.mdb") Then
                    lFile = "c:\4posServer\pricing.mdb"
                Else
                    Me.CDmasterOpen.Title = "Select the path to the application database ..."
                    'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    CDmasterOpen.Filter = "Application Data Base|pricing.mdb"
                    CDmasterOpen.FileName = ""
                    Me.CDmasterOpen.ShowDialog()
                    lFile = CDmasterOpen.FileName
                End If
                If lFile = "" Then
                    End
                Else
                    If AddDSN("4POS", "4POS Pricing File", lFile) Then
                        Me.Close()
                        MsgBox("The new data source has just been configured into the application suite." & vbCrLf & vbCrLf & "Please restart this application", MsgBoxStyle.Information, "DATA SOURCE")
                        End
                    Else
                        End
                    End If
                End If
            End If
            'loading languages files
            'Dim rs As Recordset
            tempLID = 1
            rs = getRS("SELECT Company_LanguageID, Company_RightTL From Company")
            If rs.RecordCount Then
                If IsDBNull(rs.Fields("Company_LanguageID").Value) Then tempLID = 1
                If rs.Fields("Company_LanguageID").Value = 0 Then
                    tempLID = 1
                Else
                    tempLID = rs.Fields("Company_LanguageID").Value
                End If

                If IsDBNull(rs.Fields("Company_RightTL").Value) Then iLangRTL = 0
                If rs.Fields("Company_RightTL").Value = 0 Then
                    iLangRTL = 0
                Else
                    iLangRTL = rs.Fields("Company_RightTL").Value
                End If
            Else
                tempLID = 1
                iLangRTL = 0
            End If

            rsLang = getRS("SELECT * From LanguageLayoutLnk Where LanguageLayoutLnk_LanguageLayoutID = " & tempLID & ";")
            'loading languages files

            'loading help file
            'helpPath = App.Path & "\4POS4Dummies.chm"
            'If Command = "1" Then helpPath = "C:\4POS\4POS4Dummies.chm"
            helpPath = "C:\4POS\4POS4Dummies.chm"
            If fso.FileExists(helpPath) Then
                rsHelp = getRS("SELECT * From Help;")
            Else
                rsHelp = getRS("SELECT 0 AS Help_Section, 'A' AS Help_Form From Help;")
            End If
            'loading help file

            'Dim lTextstream As textstream
            lString = serverPath & "data\4POSInterface\4POSAUTODE.txt"
            If fso.FileExists(lString) Then
                DayEndtextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForReading, True)
                lString = DayEndtextstream.ReadAll
                DayEndtextstream.Close()
                DayEndtextstream = Nothing

                If IsDate(lString) Then
                    bolAutoDE = True
                    dateDayEnd = CDate(lString)
                    doMenuForms("frmdayend")
                    System.Windows.Forms.Application.DoEvents()
                Else
                    MsgBox("Auto DayEnd file was detected but file is invalid.")
                    End
                End If
            Else
                loadLanguage()
                Dim f As New frmLogin
                f.Show()
                'frmLogin.Show()
            End If

            'Me.Close()
            Me.Hide()
        End If


    End Sub
	
	'Private Sub Label3_Click()
	'    Dim rs As Recordset
	'        Set rs = getRS("SELECT * FROM aTransactionItem")
	'        If rs.RecordCount = 0 Then
	'        rs.save gMasterPath & "Data\aTransactionItem.rs", adPersistADTG
	'        End If
	'End Sub
	
	Private Sub lvLocation_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvLocation.DoubleClick
        Dim lArray As String()
		Dim x As Short

		If AddDSN("4POS", "4POS Pricing Data", Me.lvLocation.FocusedItem.SubItems(1).Text) Then
            System.Windows.Forms.Application.DoEvents()
            If openConnection() Then
                lblCompany.Text = lvLocation.FocusedItem.Text & " - " & lvLocation.FocusedItem.SubItems(0).Text
                lblCompany.Tag = Mid(lvLocation.FocusedItem.Name, 2)
                lblPath.Text = lvLocation.FocusedItem.SubItems(1).Text
                lArray = Split(lblPath.Text, "\")
                'lblDir.Text = lArray(0) & "\"
                For x = 1 To UBound(lArray) - 1
                    lblDir.Text = lblDir.Text & lArray(x) & "\"
                Next x
                For x = 0 To Label1.Count
                    Label1(x).Enabled = True
                Next x
                cmdCompany.Enabled = True
                cmdBuild.Enabled = True
                cmdDatabase.Enabled = True
                Me.txtUserName.Enabled = True
                txtPassword.Enabled = True
                Me.cmdOK.Enabled = True
                If checkSecurity() Then
                    Me.frmRegister.Visible = False
                Else
                    Me.frmRegister.Visible = True
                    BuildRegistrationKey()
                End If
                If txtUserName.Visible Then txtUserName.Focus()

                Exit Sub
            End If
        End If
		lblCompany.Text = "..."
		lblCompany.Tag = ""
		lblPath.Text = "..."
		lblDir.Text = "..."
        For x = 0 To Label1.Count
            Label1(x).Enabled = False
        Next x
		Me.txtUserName.Enabled = False
		txtPassword.Enabled = False
		Me.cmdOK.Enabled = False
		cmdCompany.Enabled = False
		cmdBuild.Enabled = False
		cmdDatabase.Enabled = False
		
		Me.CDmasterOpen.Title = "Select the path to " & lvLocation.FocusedItem.SubItems(0).Text & " application database ..."
		CDmasterOpen.Filter = "Application Data Base|pricing.mdb"
		CDmasterOpen.FileName = ""
		Me.CDmasterOpen.ShowDialog()
		If CDmasterOpen.FileName = "" Then
		Else
			lblCompany.Tag = Mid(lvLocation.FocusedItem.Name, 2)
			cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" & Replace(CDmasterOpen.FileName, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & Mid(lvLocation.FocusedItem.Name, 2) & "));")
			loadCompanies()
			lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
			lvLocation_DoubleClick(lvLocation, New System.EventArgs())
		End If
	End Sub
	
	Private Sub loadCompanies()
		Dim rs As New ADODB.Recordset
		Dim lListitem As System.Windows.Forms.ListViewItem
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'If openConnection Then
        'End If
		rs.Open("SELECT locationCompany.locationCompanyID, location.location_Name, locationCompany.locationCompany_Name, locationCompany.locationCompany_Path FROM location INNER JOIN locationCompany ON location.locationID = locationCompany.locationCompany_LocationID ORDER BY location.location_Name, locationCompany.locationCompany_Name;", cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        'If lvLocation.Items.Count <> 0 Then
        'Me.lvLocation.Items.Clear()
        'End If
        If rs.RecordCount Then
            Do Until rs.EOF
                lListitem = lvLocation.Items.Add("k" & rs.Fields("locationCompanyID").Value, rs.Fields("locationCompany_Name").Value, 2)
                If lListitem.SubItems.Count > 0 Then
                    lListitem.SubItems(0).Text = rs.Fields("location_Name").Value & ""
                Else
                    lListitem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("location_Name").Value & ""))
                End If
                If lListitem.SubItems.Count > 1 Then
                    lListitem.SubItems(1).Text = rs.Fields("locationCompany_Path").Value & ""
                Else
                    lListitem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("locationCompany_Path").Value & ""))
                End If
                If LCase(rs.Fields("locationCompany_Path").Value & "") = LCase(serverPath & "pricing.mdb") Then
                    lListitem.Selected = True
                    lvLocation_DoubleClick(lvLocation, New System.EventArgs())
                End If
                rs.MoveNext()
            Loop
        End If
    End Sub
	
	Private Sub txtCompany_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCompany.Enter
		txtCompany.SelectionStart = 0
		txtCompany.SelectionLength = 9999
	End Sub
	
	Private Sub txtCompany_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCompany.Leave
		If Trim(txtCompany.Text) <> "" Then
			cnnDB.Execute("UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'")
		End If
		BuildRegistrationKey()
	End Sub
	
	Private Sub txtKey_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKey.Enter
		txtKey.SelectionStart = 0
		txtKey.SelectionLength = 9999
	End Sub
	Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
		txtPassword.SelectionStart = 0
		txtPassword.SelectionLength = 9999
	End Sub
	Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			KeyAscii = 0
			cmdOK_Click(cmdOK, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserName.Enter
		txtUserName.SelectionStart = 0
		txtUserName.SelectionLength = 9999
	End Sub
	Private Sub txtUserName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			KeyAscii = 0
			txtPassword.Focus()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Function getSerialNumber() As String
		Dim fso As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		getSerialNumber = ""
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
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
		rs = getRS("SELECT * From Company")
		If rs.RecordCount Then
			gSecKey = rs.Fields("Company_Code").Value & ""
			If IsNumeric(rs.Fields("Company_Code").Value) Then
				If Len(rs.Fields("Company_Code").Value) = 13 Then
					
					checkSecurity = True
					Exit Function
				End If
			End If
			lPassword = "pospospospos"
			lCode = getSerialNumber
			If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
				checkSecurity = True
			Else
				leCode = Encrypt(lCode, lPassword)
				For x = 1 To Len(leCode)
					If Asc(Mid(leCode, x, 1)) < 33 Then
						leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
					End If
				Next x
				
				
				If rs.Fields("Company_Code").Value = leCode Then
					'If IsNull(rs("Company_TerminateDate")) Then
					checkSecurity = True
					'Else
					'    If Date > rs("Company_TerminateDate") Then
					'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
					'        checkSecurity = False
					Exit Function
					'   End If
					'End If
				Else
					txtCompany.Text = rs.Fields("Company_Name").Value
					txtCompany.SelectionStart = 0
					txtCompany.SelectionLength = 999
				End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
End Class