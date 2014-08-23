Option Strict Off
Option Explicit On
Module basCryptoProcs
	
	Public g_blnCaseSensitiveUserID As Boolean
	Public g_blnCaseSensitivePWord As Boolean
	Public g_blnEnhancedProvider As Boolean
	Public g_intHashType As Short
	
	Public Const PGM_NAME As String = "4LIQ Serials"
	Public Const MAX_PATH As Integer = 260
	Public Const APP_NAME As String = "PWDTest"
	Public Const APP_SECTION As String = "Settings"
	Public Const MYNAME As String = "4LIQ"
	
	Public strCDKey As String
	
	
	Public Function ConvertToArray(ByRef strInput As String) As Byte()
		
		'UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cCrypto As clsCryptoAPI
		cCrypto = New clsCryptoAPI
		
		'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ConvertToArray = cCrypto.StringToByteArray(strInput)
		'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cCrypto = Nothing
		
	End Function
	
	Public Function Correct_Password_Length(ByRef arPWord() As Byte) As Boolean
		
		Dim intLength As Short
		Dim strPWord As String
		'UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cCrypto As clsCryptoAPI
		
		cCrypto = New clsCryptoAPI
		'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strPWord = cCrypto.ByteArrayToString(arPWord)
		intLength = Len(strPWord)
		'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cCrypto = Nothing
		
		If intLength = 0 Then
			MsgBox("A Password / Passphrase must be entered.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Password / Passphrase missing")
			Correct_Password_Length = False
			'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = Nothing
			Exit Function
		End If
		
		If intLength < 8 Then
			' If not a valid length
			MsgBox("Password / Passphrase must be a minimum length of eight(8) characters.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Password / Passphrase length")
			Correct_Password_Length = False
			'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = Nothing
			Exit Function
		End If
		
		
		Correct_Password_Length = True
		'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cCrypto = Nothing
		
	End Function
	
	Public Function CurrentSettings_Get(ByRef strKey As String) As Object
		
		
		CurrentSettings_Get = GetSetting(APP_NAME, APP_SECTION, strKey)
		
	End Function
	
	Public Function CurrentSettings_Save(ByRef strKey As String, ByRef varValue As Object) As String
		
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		SaveSetting(APP_NAME, APP_SECTION, strKey, varValue)
		
	End Function
	
	Public Sub Initial_settings()
		
		Dim varValue As Object
		
		' ---------------------------------------------------------------------------
		' Case sensitive User ID setting (Default = True)
		' ---------------------------------------------------------------------------
		'UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		varValue = CurrentSettings_Get("UserID")
		
		' if nothing of file, write default to the registry
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(Trim(varValue)) = 0 Then
			g_blnCaseSensitiveUserID = True
			CurrentSettings_Save("UserID", g_blnCaseSensitiveUserID)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			g_blnCaseSensitiveUserID = CBool(varValue)
		End If
		
		' ---------------------------------------------------------------------------
		' Case sensitive Password / Passphrase setting (Default = True)
		' ---------------------------------------------------------------------------
		'UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		varValue = CurrentSettings_Get("Password")
		
		' if nothing of file, write default to the registry
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(Trim(varValue)) = 0 Then
			g_blnCaseSensitivePWord = True
			CurrentSettings_Save("Password", g_blnCaseSensitivePWord)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			g_blnCaseSensitivePWord = CBool(varValue)
		End If
		
		' ---------------------------------------------------------------------------
		' Whether or not to use the Enhanced Provider
		' ---------------------------------------------------------------------------
		'UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		varValue = CurrentSettings_Get("EnhancedProvider")
		
		' if nothing of file, write default to the registry
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(Trim(varValue)) = 0 Then
			g_blnEnhancedProvider = False
			CurrentSettings_Save("EnhancedProvider", g_blnEnhancedProvider)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			g_blnEnhancedProvider = CBool(varValue)
		End If
		
		' ---------------------------------------------------------------------------
		' Hash method (Default = MD5)
		' ---------------------------------------------------------------------------
		'UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		varValue = CurrentSettings_Get("HashMethod")
		
		' if nothing of file, write default to the registry
		'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(Trim(varValue)) = 0 Then
			g_intHashType = 2
			CurrentSettings_Save("HashMethod", g_intHashType)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			g_intHashType = CShort(varValue)
		End If
		
	End Sub
	
	Public Function Same_As_Previous(ByRef arByte1() As Byte, ByRef arByte2() As Byte) As Boolean
		
		Dim strTmp1 As String
		Dim strTmp2 As String
		'UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cCrypto As clsCryptoAPI
		cCrypto = New clsCryptoAPI
		
		' ---------------------------------------------------------------------------
		' Convert byte arrays to string data
		' ---------------------------------------------------------------------------
		'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strTmp1 = cCrypto.ByteArrayToString(arByte1)
		'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strTmp2 = cCrypto.ByteArrayToString(arByte2)
		
		' ---------------------------------------------------------------------------
		' Make the comparisons to see if these two arrays are the same
		' ---------------------------------------------------------------------------
		If StrComp(strTmp1, strTmp2, CompareMethod.Binary) = 0 Then
			Same_As_Previous = True
		Else
			Same_As_Previous = False
		End If
		
		' ---------------------------------------------------------------------------
		' Empty data strings
		' ---------------------------------------------------------------------------
		strTmp1 = New String(Chr(0), 250)
		strTmp2 = New String(Chr(0), 250)
		'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cCrypto = Nothing
		
	End Function
End Module