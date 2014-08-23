Option Strict Off
Option Explicit On
Module modReport
	Public cnnDBreport As ADODB.Connection
	Public cnnDBConsReport As ADODB.Connection
    Public Function getRSreport(ByRef sql As String) As ADODB.Recordset
        Dim Path As String
        Dim strDBPath As String
        On Error GoTo getRSreport_Error

        getRSreport = New ADODB.Recordset
        getRSreport.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Debug.Print(sql)
        getRSreport.Open(sql, cnnDBreport, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Exit Function
getRSreport_Error:
        If cnnDBreport Is Nothing Then
            MsgBox(Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & " cnnDBreport object has not been made.")
        ElseIf Err.Description = "Not a valid password." Then
            MsgBox("Error while getRSreport and Error is :" & Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & cnnDBreport.ConnectionString & vbCrLf & vbCrLf & " --- " & cnnDBreport.State)

            cnnDB.Close()
            'UPGRADE_NOTE: Object cnnDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            cnnDB = Nothing
            cnnDB = New ADODB.Connection
            'UPGRADE_WARNING: Couldn't resolve default property of object strDBPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            strDBPath = serverPath & "pricing.mdb"
            'UPGRADE_WARNING: Couldn't resolve default property of object strDBPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
            'cnnDB.CursorLocation = adUseClient
            'UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Mode=Share Deny Read|Share Deny Write;Persist Security Info=False;Data Source= " & Path)
            cnnDB.Execute("ALTER DATABASE PASSWORD Null " & " " & "lqd")
            cnnDB.Close()
            'UPGRADE_NOTE: Object cnnDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            cnnDB = Nothing
            openConnection()

        Else
            MsgBox("Error while getRSreport and Error is :" & Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & cnnDBreport.ConnectionString & vbCrLf & vbCrLf & " --- " & cnnDBreport.State)
        End If
        Resume Next
    End Function
	Public Function getRSreport1(ByRef sql As Object) As ADODB.Recordset
		On Error GoTo getRSreport1_Error
		
		getRSreport1 = New ADODB.Recordset
		getRSreport1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		getRSreport1.Open(sql, cnnDBConsReport, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		
		Exit Function
getRSreport1_Error: 
		If cnnDBConsReport Is Nothing Then
			MsgBox(Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & " cnnDBConsReport object has not been made.")
		Else
			MsgBox("Error while getRSreport1 and Error is :" & Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & " --- " & cnnDBConsReport.ConnectionString & vbCrLf & vbCrLf & " --- " & cnnDBConsReport.State)
		End If
		Resume Next
	End Function
	
	Public Function openConnectionReport() As Boolean
        Dim Path As String
		On Error GoTo openConnection_Error
		Dim createDayend As Boolean
		Dim strDBPath As String
		Dim fso As New Scripting.FileSystemObject
		createDayend = False
		openConnectionReport = True
		cnnDBreport = New ADODB.Connection
		strDBPath = serverPath & "report" & frmMenu.lblUser.Tag & ".mdb"
		With cnnDBreport
			.Provider = "Microsoft.ACE.OLEDB.12.0"
			.Properties("Jet OLEDB:System Database").Value = serverPath & "Secured.mdw"
			.Open(strDBPath, "liquid", "lqd")
		End With
		Exit Function
		
withPass: 
		'If serverPath = "" Then setNewServerPath
		'If serverPath <> "" Then
		cnnDBreport = New ADODB.Connection
		strDBPath = serverPath & "report" & frmMenu.lblUser.Tag & ".mdb"
		'UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
		cnnDBreport.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		'UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cnnDBreport.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " & Path)
		openConnectionReport = True
		'End If
		Exit Function
		
openConnection_Error: 
		If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
			GoTo withPass
		ElseIf Err.Description = "Not a valid password." Then 
			GoTo withPass
		End If
		
		openConnectionReport = False
		MsgBox(Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & " openConnectionReport object has not been made.")
	End Function
	Public Function openConsReport(ByRef strL As String) As Boolean
		Dim strTable As String
		Dim createDayend As Boolean
		Dim strDBPath As String
		
		On Error GoTo openConnection_Error
		createDayend = False
		
		cnnDBConsReport = New ADODB.Connection
		
		strDBPath = StrLocRep & "report" & frmMenu.lblUser.Tag & ".mdb"
		
		cnnDBConsReport.Open("Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source= " & strDBPath & ";")
		
openConnection_Error: 
		openConsReport = False
		MsgBox(Err.Number & " " & Err.Description & " " & Err.Source & vbCrLf & vbCrLf & " openConsReport object has not been made.")
	End Function
	Public Sub closeConnectionReport()
		cnnDBreport.Close()
		'UPGRADE_NOTE: Object cnnDBreport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cnnDBreport = Nothing
	End Sub
End Module