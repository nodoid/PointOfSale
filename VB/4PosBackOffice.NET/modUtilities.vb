Option Strict Off
Option Explicit On
Imports Microsoft.Win32
Module modUtilities
	Public Const REG_SZ As Integer = 1
	Public Const REG_DWORD As Integer = 4
	
	Public Const HKEY_CLASSES_ROOT As Integer = &H80000000
	Public Const HKEY_CURRENT_USER As Integer = &H80000001
	Public Const HKEY_LOCAL_MACHINE As Integer = &H80000002
	Public Const HKEY_USERS As Integer = &H80000003
	
	Public Const ERROR_NONE As Short = 0
	Public Const ERROR_BADDB As Short = 1
	Public Const ERROR_BADKEY As Short = 2
	Public Const ERROR_CANTOPEN As Short = 3
	Public Const ERROR_CANTREAD As Short = 4
	Public Const ERROR_CANTWRITE As Short = 5
	Public Const ERROR_OUTOFMEMORY As Short = 6
	Public Const ERROR_ARENA_TRASHED As Short = 7
	Public Const ERROR_ACCESS_DENIED As Short = 8
	Public Const ERROR_INVALID_PARAMETERS As Short = 87
	Public Const ERROR_NO_MORE_ITEMS As Short = 259
	
	Public Const KEY_QUERY_VALUE As Integer = &H1
	Public Const KEY_SET_VALUE As Integer = &H2
	Public Const KEY_ALL_ACCESS As Integer = &H3F
	
	Public Const REG_OPTION_NON_VOLATILE As Short = 0
	
	Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hkey As Integer) As Integer
	Declare Function RegCreateKeyEx Lib "advapi32.dll"  Alias "RegCreateKeyExA"(ByVal hkey As Integer, ByVal lpSubKey As String, ByVal Reserved As Integer, ByVal lpClass As String, ByVal dwOptions As Integer, ByVal samDesired As Integer, ByVal lpSecurityAttributes As Integer, ByRef phkResult As Integer, ByRef lpdwDisposition As Integer) As Integer
	Declare Function RegOpenKeyEx Lib "advapi32.dll"  Alias "RegOpenKeyExA"(ByVal hkey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
	Declare Function RegQueryValueExString Lib "advapi32.dll"  Alias "RegQueryValueExA"(ByVal hkey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As String, ByRef lpcbData As Integer) As Integer
	Declare Function RegQueryValueExLong Lib "advapi32.dll"  Alias "RegQueryValueExA"(ByVal hkey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByRef lpData As Integer, ByRef lpcbData As Integer) As Integer
	Declare Function RegQueryValueExNULL Lib "advapi32.dll"  Alias "RegQueryValueExA"(ByVal hkey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As Integer, ByRef lpcbData As Integer) As Integer
	Declare Function RegSetValueExString Lib "advapi32.dll"  Alias "RegSetValueExA"(ByVal hkey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByVal lpValue As String, ByVal cbData As Integer) As Integer
	Declare Function RegSetValueExLong Lib "advapi32.dll"  Alias "RegSetValueExA"(ByVal hkey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef lpValue As Integer, ByVal cbData As Integer) As Integer
	
	Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Integer) As Integer
	
	
	Private Declare Function BringWindowToTop Lib "user32" (ByVal hwnd As Integer) As Integer
	
	Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As Object, ByVal lpWindowName As Object) As Integer
	
	Private Const LOCALE_SSHORTDATE As Integer = &H1F
	Private Const WM_SETTINGCHANGE As Integer = &H1A
	Private Const HWND_BROADCAST As Integer = &HFFFF
	
	Private Declare Function SetLocaleInfo Lib "kernel32"  Alias "SetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Boolean
	Private Declare Function PostMessage Lib "user32"  Alias "PostMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
	Private Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer
	
	Public Sub setShortDateFormat()
		Dim dwLCID As Integer
		dwLCID = GetSystemDefaultLCID()
		If SetLocaleInfo(dwLCID, LOCALE_SSHORTDATE, "yyyy/MM/dd") = False Then
			MsgBox("Failed")
			Exit Sub
		End If
		PostMessage(HWND_BROADCAST, WM_SETTINGCHANGE, 0, 0)
	End Sub
	
	Public Sub setApplicationFocus(ByRef title As String)
		Dim iret As Integer
		Dim lHandle As Integer
		
		lHandle = FindWindow(VariantType.Empty, title)
		If lHandle = 0 Then
		Else
			iret = BringWindowToTop(lHandle)
		End If
		
	End Sub
	
    Public Function SetValueEx(ByVal hkey As Integer, ByRef sValueName As String, ByRef ltype As Integer, ByRef vValue As Integer) As Integer
        Dim lValue As Integer
        Dim sValue As String
        Select Case ltype
            Case REG_SZ
                sValue = vValue & Chr(0)
                SetValueEx = RegSetValueExString(hkey, sValueName, 0, ltype, sValue, Len(sValue))
            Case REG_DWORD
                lValue = vValue
                SetValueEx = RegSetValueExLong(hkey, sValueName, 0, ltype, lValue, 4)
        End Select
    End Function
	
    Function QueryValueEx(ByVal lhKey As Integer, ByVal szValueName As String, ByRef vValue As Object) As Integer
        Dim cch As Integer
        Dim lrc As Integer
        Dim ltype As Integer
        Dim lValue As Integer
        Dim sValue As String
        Dim rkey As RegistryKey
        On Error GoTo QueryValueExError

        ' Determine the size and type of data to be read
        rkey = Registry.LocalMachine.OpenSubKey(szValueName, True)

        lrc = RegQueryValueExNULL(lhKey, szValueName, 0, ltype, 0, cch)
        If lrc <> ERROR_NONE Then Error (5)

        Select Case ltype
            ' For strings
            Case REG_SZ
                sValue = New String(Chr(0), cch)

                lrc = RegQueryValueExString(lhKey, szValueName, 0, ltype, sValue, cch)
                If lrc = ERROR_NONE Then
                    vValue = Left(sValue, cch - 1)
                Else
                    vValue = Nothing
                End If
                ' For DWORDS
            Case REG_DWORD
                lrc = RegQueryValueExLong(lhKey, szValueName, 0, ltype, lValue, cch)
                If lrc = ERROR_NONE Then vValue = lValue
            Case Else
                'all other data types not supported
                lrc = -1
        End Select

QueryValueExExit:
        QueryValueEx = lrc
        Exit Function

QueryValueExError:
        Resume QueryValueExExit
    End Function
    Public Sub MyGotFocus(ByRef lControl As Object)
        Dim x As Short
        If lControl.Alignment = 1 Then
            For x = 1 To 10
                If Left(lControl.Text, 1) = "0" Then
                    lControl.Text = Mid(lControl.Text, 2)
                End If
                If lControl.Text = "" Then lControl.Text = "0"
            Next
        End If
        lControl.SelStart = 0
        lControl.SelLength = Len(lControl.Text)

    End Sub
	
    Public Sub MyGotFocusNumeric(ByRef lControl As Object)
        Dim x As Short
        lControl.Text = Replace(lControl.Text, ",", "")
        lControl.Text = Replace(lControl.Text, ".", "")
        If lControl.Alignment = 1 Then
            For x = 1 To 10
                If Left(lControl.Text, 1) = "0" Then
                    lControl.Text = Mid(lControl.Text, 2)
                End If
                If lControl.Text = "" Then lControl.Text = "0"
            Next
        End If
        lControl.SelStart = 0
        lControl.SelLength = Len(lControl.Text)

    End Sub
	
    Public Sub MyGotFocusNumericMEAT(ByRef lControl As Object)
        Dim x As Short
        lControl.Text = Replace(lControl.Text, ",", "")
        'lControl.Text = Replace(lControl.Text, ".", "")
        'If lControl.Alignment = 1 Then
        '    For x = 1 To 10
        '        If Left(lControl.Text, 1) = "0" Then
        '            lControl.Text = Mid(lControl.Text, 2)
        '        End If
        If lControl.Text = "" Then lControl.Text = "0"
        '    Next
        'End If
        lControl.SelStart = 0
        lControl.SelLength = Len(lControl.Text)

    End Sub
	
    Public Sub MyGotFocusNumericNew(ByRef lControl As Object)
        Dim x As Short
        lControl.Text = Replace(lControl.Text, ",", "")
        If lControl.Text = "" Then lControl.Text = "0"
        lControl.SelStart = 0
        lControl.SelLength = Len(lControl.Text)

    End Sub
	
    Public Sub MyKeyPress(ByRef KeyAscii As Short)
        Select Case KeyAscii
            Case Asc(vbCr)
                KeyAscii = 0
            Case 8, 46
            Case 48 To 57
            Case Else
                KeyAscii = 0
        End Select
    End Sub
	
    Public Sub MyKeyPressInt(ByRef KeyAscii As Short)
        Select Case KeyAscii
            Case Asc(vbCr)
                KeyAscii = 0
            Case 8
            Case 48 To 57
            Case Else
                KeyAscii = 0
        End Select
    End Sub
	
    Public Sub MyKeyPressNegative(ByRef lControl As Object, ByRef KeyAscii As Short)
        Dim lCurrentX As Object
        Select Case KeyAscii
            Case 45 '-
                If InStr(lControl.Text, "-") Then
                Else
                    lCurrentX = lControl.SelStart + 1
                    lControl.Text = "-" & lControl.Text
                    lControl.SelStart = lCurrentX

                End If
                KeyAscii = 0
            Case 43 '+
                If InStr(lControl.Text, "-") Then
                    lCurrentX = lControl.SelStart - 1
                    lControl.Text = Right(lControl.Text, Len(lControl.Text) - 1)
                    If lCurrentX < 0 Then lCurrentX = 0
                    lControl.SelStart = lCurrentX

                End If
                KeyAscii = 0

            Case Asc(vbCr)
                KeyAscii = 0
            Case 8, 46
            Case 48 To 57
            Case Else
                KeyAscii = 0
        End Select
    End Sub
	
    Public Sub MyLostFocus(ByRef lControl As TextBox, ByRef lDecimal As Decimal)
        If lControl.Text = "" Then lControl.Text = 0
        If lDecimal Then

            lControl.Text = lControl.Text / 100
        End If
        lControl.Text = FormatNumber(lControl.Text, lDecimal)
    End Sub
	
    Public Sub MyLostFocusNew(ByRef lControl As TextBox, ByRef lDecimal As Decimal)
        If lControl.Text = "" Then lControl.Text = 0
        lControl.Text = FormatNumber(lControl.Text, lDecimal)
    End Sub
	
	'Public Sub ageCustomer(id As Long)
	'    Dim rs As Recordset
	'    Dim lAmount As Currency, current As Currency, days30 As Currency, days60 As Currency, days90 As Currency, days120 As Currency, days150 As Currency
	'
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));"
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));"
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));"
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));"
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));"
	'    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));"
	'
	'    Set rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransaction_ReferenceID) = " & id & "));")
	'
	'    Do While rs.EOF = False
	'       amount = amount + rs("CustomerTransaction_Amount")
	'       rs.MoveNext
	'    Loop
	'
	'    If rs.RecordCount Then
	'
	'    'Do While rs.EOF = False
	'
	'        'amount = rs("CustomerTransaction_Amount")
	'        rs.MoveFirst
	'        current = rs("Customer_Current")
	'        days30 = rs("Customer_30Days")
	'        days60 = rs("Customer_60Days")
	'        days90 = rs("Customer_90Days")
	'        days120 = rs("Customer_120Days")
	'        days150 = rs("Customer_150Days")
	'        If amount < 0 Then
	'            days150 = days150 + amount
	'            If (days150 < 0) Then
	'                amount = days150
	'                days150 = 0
	'            Else
	'                amount = 0
	'            End If
	'            days120 = days120 + amount
	'            If (days120 < 0) Then
	'                amount = days120
	'                days120 = 0
	'            Else
	'                amount = 0
	'            End If
	'            days90 = days90 + amount
	'            If (days90 < 0) Then
	'                amount = days90
	'                days90 = 0
	'            Else
	'                amount = 0
	'            End If
	'            days60 = days60 + amount
	'            If (days60 < 0) Then
	'                amount = days60
	'                days60 = 0
	'            Else
	'                amount = 0
	'            End If
	'            days30 = days30 + amount
	'            If (days30 < 0) Then
	'                amount = days30
	'                days30 = 0
	'            Else
	'                amount = 0
	'            End If
	'        End If
	'        current = current + amount
	'        cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
	'        'rs.MoveNext
	'    'Loop
	'    End If
	'End Sub
End Module