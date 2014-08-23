Option Strict Off
Option Explicit On
Module modRecordSet
	Public cnnDB As ADODB.Connection
	Public cnnDB1 As ADODB.Connection
	Public cnnIns As ADODB.Connection '2 Open Instances......
	Public gDisp As Boolean
	Public picP As Boolean
	Public gDisplay As Boolean
	Public gDQuote As Short
	Public gMain As Short
	Public gInt As Short
	Public StrLocRep As String
	Public RptHead As String
	Public gPersonID As Short
	Public serverPath As String
	Public dltDayEndID As Short
	Public intCur As Short
	Public intArrayProd(100) As String
	Public intArrayCode(100) As Short
	Public intArrayQty(100) As Short
	'loading languages files
	Public rsLang As ADODB.Recordset
	Public iLangRTL As Short
	'loading help file
	Public rsHelp As ADODB.Recordset
	
	Public Sub setServerPath()
		Exit Sub
		Dim FSO As New Scripting.FileSystemObject
        Dim hkey As Integer
		Dim lRetVal As Integer
		Dim vValue As String
		Dim lPath As String
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "server", vValue)
		RegCloseKey(hkey)
		If vValue = "" Then
			lPath = serverPath & ""
		Else
			lPath = vValue
		End If
		
		If Right(lPath, 1) <> "\" Then lPath = lPath & "\"
		If FSO.FolderExists(lPath) Then
			serverPath = lPath
		Else
			serverPath = ""
		End If
	End Sub
	
	Public Sub setNewServerPath()
		Dim FSO As New Scripting.FileSystemObject
        Dim hkey As Integer
		Dim lRetVal As Integer
		Dim vValue As String
		Dim lPath As String
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "server", vValue)
		RegCloseKey(hkey)
		If vValue = "" Then
			lPath = serverPath & ""
		Else
			lPath = vValue
		End If
		
		If Right(lPath, 1) <> "\" Then lPath = lPath & "\"
		If FSO.FolderExists(lPath) Then
			serverPath = lPath
		Else
			serverPath = ""
		End If
	End Sub
	
    Public Function getRS(ByRef sql As String) As ADODB.Recordset
        getRS = New ADODB.Recordset
        getRS.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        getRS.Open(sql, cnnDB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, -1)
        'Debug.Print(sql)
    End Function
	Public Function openConnection() As Boolean
        Dim Path As String
        Dim cnnDBname As String
		'this
        On Error GoTo openConnection_Error
        'If Win7Ver() = True Then
        'Path = "c:\4posserver\"
        'Else
        'Path = String.Empty
        'End If
        cnnDBname = "4pos"
        cnnDB = New ADODB.Connection
        'cnnDB.Provider = "Microsoft.ACE.OLEDB.12.0"
        cnnDB.Open(cnnDBname)

        'win 7
        Dim FSO As New Scripting.FileSystemObject
        Dim textstream As Scripting.TextStream
        Dim lString As String
        If Win7Ver() = True Then
            If FSO.FileExists("C:\4POS\4POSWinPath.txt") Then
                textstream = FSO.OpenTextFile("C:\4POS\4POSWinPath.txt", Scripting.IOMode.ForReading, True)
                lString = textstream.ReadAll
                serverPath = lString '& "pricing.mdb"
            Else
                serverPath = "C:\4POSServer\" '"pricing.mdb"
            End If
            openConnection = True
            Exit Function
        End If
        'win 7

        serverPath = Split(Split(cnnDB.ConnectionString, ";DBQ=")(1), ";")(0)
        serverPath = Split(LCase(serverPath), "pricing.mdb")(0) '
        openConnection = True
        Exit Function
        If serverPath = "" Then setServerPath()
        Dim strDBPath As String
        If serverPath = "" Then
            openConnection = False
        Else
            openConnection = True
            cnnDB = New ADODB.Connection
            strDBPath = serverPath & "Pricing.mdb"
            With cnnDB
                .Provider = "Microsoft.ACE.OLEDB.12.0"
                .Properties("Jet OLEDB:System Database").Value = serverPath & "secured.mdw"
                .Open(strDBPath, "liquid", "lqd")
            End With
        End If
        Exit Function

withPass:
        If serverPath = "" Then setNewServerPath()
        If serverPath <> "" Then
            cnnDB = New ADODB.Connection
            strDBPath = serverPath & "pricing.mdb"
            Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
            cnnDB.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " & Path)
            openConnection = True
        End If
        Exit Function

openConnection_Error:
        If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
            GoTo withPass
        ElseIf Err.Description = "Not a valid password." Then
            GoTo withPass
        End If

        openConnection = False

	End Function
	Public Function openConnectionInstance(Optional ByRef lDatabase As String = "") As ADODB.Connection
        Dim Path As String
		Dim FSO As New Scripting.FileSystemObject
		
		If lDatabase = "" Then lDatabase = "Pricing.mdb"
		If serverPath = "" Then setServerPath()
		On Error GoTo openConnection_Error
		Dim cn As New ADODB.Connection
		'UPGRADE_NOTE: Object openConnectionInstance may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		openConnectionInstance = Nothing
		Dim strDBPath As String
		If serverPath = "" Then
		Else
			strDBPath = serverPath & lDatabase
			With cn
				.Provider = "Microsoft.ACE.OLEDB.12.0"
				.Properties("Jet OLEDB:System Database").Value = serverPath & "Secured.mdw"
				.Open(strDBPath, "liquid", "lqd")
			End With
			openConnectionInstance = cn
		End If
		Exit Function
		
withPass: 
		If serverPath = "" Then setNewServerPath()
		If serverPath <> "" Then
			openConnectionInstance = Nothing
			strDBPath = serverPath & lDatabase
			Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
			cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
			cn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " & Path)
			openConnectionInstance = cn
		End If
		Exit Function
		
openConnection_Error: 
		If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
			GoTo withPass
		ElseIf Err.Description = "Not a valid password." Then 
			GoTo withPass
		Else
			MsgBox(Err.Number & " - " & Err.Description)
		End If
		
	End Function
	Public Function openConnectionShapeInstance() As ADODB.Connection
        Dim Path As String
        Dim lDatabase As String
		On Error GoTo openConnectionShape_Error
		Dim cn As New ADODB.Connection
		openConnectionShapeInstance = Nothing
		If serverPath = "" Then setServerPath()
		Dim strDBPath As String
		If serverPath = "" Then
		Else
			strDBPath = serverPath & "Pricing.mdb"
			With cn
				.Provider = "MSDataShape"
				cn.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw")
			End With
			openConnectionShapeInstance = cn
		End If
		Exit Function
		
withPass: 
		If serverPath = "" Then setNewServerPath()
		If serverPath <> "" Then
			openConnectionShapeInstance = Nothing
			strDBPath = serverPath & lDatabase
			Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
			cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
			cn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " & Path)
			openConnectionShapeInstance = cn
		End If
		Exit Function
		
openConnectionShape_Error: 
		If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
			GoTo withPass
		ElseIf Err.Description = "Not a valid password." Then 
			GoTo withPass
		Else
			MsgBox(Err.Number & " - " & Err.Description)
		End If
	End Function
	Public Sub closeConnection()
		On Error Resume Next
		cnnDB.Close()
		cnnDB = Nothing
	End Sub
	
	
	Public Function getRSwaitron(ByRef sql As Object, ByRef cn As ADODB.Connection) As ADODB.Recordset
		getRSwaitron = New ADODB.Recordset
		getRSwaitron.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		getRSwaitron.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		
	End Function
	
	
	Public Function openSComp(Optional ByRef lDatabase As String = "") As ADODB.Connection
		Dim FSO As New Scripting.FileSystemObject
		
		'If lDatabase = "" Then lDatabase = "Pricing.mdb"
		'If serverPath = "" Then setServerPath
		If lDatabase = "" Then lDatabase = serverPath & "Pricing.mdb"
		On Error GoTo openConnection_Error
		Dim cn As New ADODB.Connection
		openSComp = Nothing
		Dim strDBPath As String
		If lDatabase = "" Then
		Else
			strDBPath = lDatabase
			With cn
				.Provider = "Microsoft.ACE.OLEDB.12.0"
				.Properties("Jet OLEDB:System Database").Value = serverPath & "Secured.mdw"
				.Open(strDBPath, "liquid", "lqd")
			End With
			openSComp = cn
		End If
		
		Exit Function
openConnection_Error: 
		
	End Function
End Module