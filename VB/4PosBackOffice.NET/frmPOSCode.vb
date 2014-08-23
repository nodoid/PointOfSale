Option Strict Off
Option Explicit On
Option Compare Text
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPOSCode
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim k_posID As Integer
	Dim k_posNew As Boolean
	
	
	Dim flag As Boolean
	Dim y As Single
	Dim c As Short
	Dim YY As Short
	Dim x As Short
	Private Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
	
	Dim obj As System.Drawing.Image = New System.Drawing.Bitmap(1, 1)
	Private Declare Function GetDriveType Lib "kernel32"  Alias "GetDriveTypeA"(ByVal nDrive As String) As Integer
	
    Dim fox(8) As Char
	Dim usb_drv As String
	Dim yourdrive As String
	Dim CDKey As Boolean
	
	Private arData() As Byte
	Private arPWord() As Byte
	Private m_intCipher As Short
	
	Private Sub loadLanguage()
		On Error Resume Next
		'frmPOSCode = No Code   [4POS Registration]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPOSCode.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSCode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_0 = No Code       [Please type in your 4POS CD Key (without dashes)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_1 = No Code [CD Key]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPOSCode.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub Reset_frmEncStrings()
		Dim strMsg As String
		
		Erase arData
		Erase arPWord
	End Sub
	
	'UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Form_Initialize_Renamed()
		'ChDrive App.Path
		'ChDir App.Path
		Initial_settings()
		Reset_frmEncStrings()
	End Sub
	
	Public Function setupCode() As Boolean
		
		CDKey = False
		System.Windows.Forms.Application.DoEvents()
		'Dim c, i As Byte
		'For i = 68 To 75
		'    c = c + 1
		'    fox(c) = Chr(i) & ":"
		'Next
		
		loadLanguage()
		Me.ShowDialog()
		
		setupCode = CDKey
		'Exit Function
	End Function
	
	Private Sub frmPOSCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				'            adoPrimaryRS.Move 0
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		Me.Close()
	End Sub
	
	Private Function getCDKeyDate(ByRef posCDKey As String) As Date
		On Error GoTo jumpOut
		Dim cCrypto As clsCryptoAPI ' clsCryptoAPI
		
		Dim strSerial As String
        Dim strTmp As String
		
		cCrypto = New clsCryptoAPI 'clsCryptoAPI
		System.Windows.Forms.Application.DoEvents()
		'strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
		strTmp = cCrypto.ConvertStringFromHex(VB.Left(posCDKey, Len(posCDKey) - 5))
		System.Windows.Forms.Application.DoEvents()
		arData = cCrypto.StringToByteArray(strTmp)
		System.Windows.Forms.Application.DoEvents()
		arPWord = cCrypto.StringToByteArray(Val(VB.Right(posCDKey, 5)))
		System.Windows.Forms.Application.DoEvents()
        cCrypto.PassWord = arPWord
		System.Windows.Forms.Application.DoEvents()
		cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData)
		System.Windows.Forms.Application.DoEvents()
		
		' Decrypt the data input from the encrypted text box
		'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
		If cCrypto.Decrypt(2, 1) Then
			System.Windows.Forms.Application.DoEvents()
			arData = cCrypto.OutputData.Clone()
			strSerial = cCrypto.ByteArrayToString(arData)
		End If
		
		'If strSerial = "pos" Then
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		Dim dtDate As String
		Dim dtMonth As String
		Dim dtYear As String
		Dim stPass As String
		If VB.Left(strSerial, 3) = "pos" Or VB.Left(strSerial, 3) = "pre" Then
			
			'Create date password
			If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then
				strSerial = Mid(strSerial, 4, Len(strSerial))
				intYear = CShort(Mid(strSerial, 5, 2))
				intMonth = CShort(Mid(strSerial, 3, 2))
				intDate = CShort(VB.Left(strSerial, 2))
				
				If (intDate / 2) = System.Math.Round(intDate / 2) Then
					intDate = intDate / 2
				Else
					GoTo jumpOut
				End If
				
				If (intMonth / 3) = System.Math.Round(intMonth / 3) Then
					intMonth = intMonth / 3
				Else
					GoTo jumpOut
				End If
				
				If (intYear / 4) = System.Math.Round(intYear / 4) Then
					intYear = intYear / 4
				Else
					GoTo jumpOut
				End If
				
				stPass = "20"
				If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
				If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
				If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
				
				If IsDate(stPass) Then
					'    If CDate(stPass) >= (Date - 31) Then
					
				End If
			End If
		End If
		
jumpOut: 
		cCrypto = Nothing ' Free the Crypto class from memory
		strTmp = New String(Chr(0), 250) ' overwrite data in temp variable
		
		getCDKeyDate = CDate(stPass)
		
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		On Error GoTo Err_Close
		Dim cCrypto As clsCryptoAPI ' clsCryptoAPI
		
		Dim strSerial As String
        Dim strTmp As String
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		'Piracy check
		Dim lastCDKeyDate As Date
		lastCDKeyDate = System.Date.FromOADate(Today.ToOADate - 356)
		'check if he is backdating while on the cd-key screen
		If Today <> loginDate Then
			If Today < (System.Date.FromOADate(loginDate.ToOADate - 30)) Then
				MsgBox("ErrorCode:31 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
				CDKey = False
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				Me.Close()
				Exit Sub
			End If
		End If
		'
        'check if he is changing the date before the install date
        strSerial = FormatDateTime(instalDate, DateFormat.ShortDate)
		instalDate = CDate(strSerial)
		strSerial = ""
		If CDate(instalDate) > Today Then
			MsgBox("ErrorCode:64 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
			CDKey = False
			cmdClose.Focus()
			System.Windows.Forms.Application.DoEvents()
			Me.Close()
			Exit Sub
		End If
		'
		'check if current key is not older then the last used key (if any)
		On Error GoTo Err_Close
		rs = getRS("SELECT TOP 1 * FROM POS ORDER BY POS_CID DESC;")
		If rs.RecordCount Then
			If InStr(1, rs.Fields("POS_Code").Value, Chr(255)) Then
				lastCDKeyDate = getCDKeyDate(CStr(Split(rs.Fields("POS_Code").Value, Chr(255))(1)))
			End If
		End If
		'Piracy check
		
		txtFields.Text = Trim(Replace(txtFields.Text, "-", ""))
		If Len(txtFields.Text) < 23 Then
			MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
			CDKey = False
			cmdClose.Focus()
			System.Windows.Forms.Application.DoEvents()
			Me.Close()
			Exit Sub
		End If
		
		cCrypto = New clsCryptoAPI 'clsCryptoAPI
		System.Windows.Forms.Application.DoEvents()
		txtFields.Text = LTrim(txtFields.Text)
		txtFields.Text = RTrim(txtFields.Text)
		txtFields.Text = Trim(txtFields.Text)
		txtFields.Text = Replace(txtFields.Text, " ", "")
		'strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
		strTmp = cCrypto.ConvertStringFromHex(VB.Left(txtFields.Text, Len(txtFields.Text) - 5))
		System.Windows.Forms.Application.DoEvents()
		arData = cCrypto.StringToByteArray(strTmp)
		System.Windows.Forms.Application.DoEvents()
		arPWord = cCrypto.StringToByteArray(Val(VB.Right(txtFields.Text, 5)))
		System.Windows.Forms.Application.DoEvents()
        cCrypto.PassWord = arPWord
		System.Windows.Forms.Application.DoEvents()
		cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData)
		System.Windows.Forms.Application.DoEvents()
		
		' Decrypt the data input from the encrypted text box
		'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
		If cCrypto.Decrypt(2, 1) Then
			System.Windows.Forms.Application.DoEvents()
			arData = cCrypto.OutputData.Clone()
			strSerial = cCrypto.ByteArrayToString(arData)
		End If
		
		'If strSerial = "pos" Then
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		Dim dtDate As String
		Dim dtMonth As String
		Dim dtYear As String
		Dim stPass As String
		If VB.Left(strSerial, 3) = "pos" Then
			
			'Create date password
			If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then
				strSerial = Mid(strSerial, 4, Len(strSerial))
				intYear = CShort(Mid(strSerial, 5, 2))
				intMonth = CShort(Mid(strSerial, 3, 2))
				intDate = CShort(VB.Left(strSerial, 2))
				
				If (intDate / 2) = System.Math.Round(intDate / 2) Then
					intDate = intDate / 2
				Else
					GoTo jumpOut
				End If
				
				If (intMonth / 3) = System.Math.Round(intMonth / 3) Then
					intMonth = intMonth / 3
				Else
					GoTo jumpOut
				End If
				
				If (intYear / 4) = System.Math.Round(intYear / 4) Then
					intYear = intYear / 4
				Else
					GoTo jumpOut
				End If
				
				stPass = "20"
				If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
				If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
				If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
				
				If IsDate(stPass) Then
					If CDate(stPass) < lastCDKeyDate Then
						MsgBox("ErrorCode:97 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
						CDKey = False
						cmdClose.Focus()
						System.Windows.Forms.Application.DoEvents()
						Me.Close()
						Exit Sub
					End If
					
					If CDate(stPass) < #1/1/2012# Then
						MsgBox("ErrorCode:82 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
						CDKey = False
						cmdClose.Focus()
						System.Windows.Forms.Application.DoEvents()
						Me.Close()
						Exit Sub
					End If
					
					rs = getRS("Select TOP 1 * FROM Sale ORDER BY SaleID DESC;")
					If rs.RecordCount Then
						If CDate(stPass) < System.Date.FromOADate(rs.Fields("Sale_Date").Value - 30) Then
							MsgBox("ErrorCode:28 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
							CDKey = False
							cmdClose.Focus()
							System.Windows.Forms.Application.DoEvents()
							Me.Close()
							Exit Sub
						End If
					End If
					
					If CDate(stPass) >= (System.Date.FromOADate(Today.ToOADate - 31)) Then
						'Dim rs As Recordset
						'Dim rj As Recordset
						'Set rs = getRS("Select * FROM POS WHERE POS_Code = '" & Trim(strCDKey) & "'")
						'    If rs.RecordCount > 0 Then
						'       MsgBox "This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", vbApplicationModal + vbInformation + vbOKOnly, App.title
						'       CDKey = False
						'    Else
						'        CDKey = True
						'    End If
						'
						'    cnnDB.Execute "UPDATE Company SET Company_ResMS = '" & txtFields.Text & "';"
						'    CDKey = True
						On Error GoTo Err_Close
						rs = getRS("Select * FROM POS;")
						Do While rs.EOF = False
							If InStr(1, rs.Fields("POS_Code").Value, Chr(255)) Then
								If Split(rs.Fields("POS_Code").Value, Chr(255))(1) = txtFields.Text Then
									MsgBox("This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
									CDKey = False
									GoTo jumpOut
								End If
							End If
							rs.moveNext()
						Loop 
						'all validation OK
						CDKey = True
						strCDKey = txtFields.Text
					Else
						MsgBox("This '4POS CD Key' is expired!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
						CDKey = False
						GoTo jumpOut
					End If
				End If
				
			Else
				MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
				CDKey = False
				GoTo jumpOut
			End If
			
		Else
			'MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
			MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
			CDKey = False
		End If
jumpOut: 
		cCrypto = Nothing ' Free the Crypto class from memory
		strTmp = New String(Chr(0), 250) ' overwrite data in temp variable
		
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		'CDKey = False
		Me.Close()
		
Err_Close: 
		'If Err.Number = 0 Then
		'Else
		'End If
		Resume Next
	End Sub
	
	'Private Sub OLD__Timer1_Timer()
	'Dim i
	'    For i = 1 To 8
	'        'DoEvents
	'        If GetDriveType(fox(i)) = 5 Then ' CD ROM DISK'
	'
	'            If setupCodeAuto(fox(i)) = True Then
	'                Timer1.Enabled = False
	'                Unload Me
	'                Exit Sub
	'            Else
	'                'Me.show 1
	'            End If''
	'
	'            If TEST_CDROM(fox(i)) = True Then'
	'
	'                '_lbl_5.Caption = "Please Insert next 4POS CD to Add New Terminal then click Close."
	'                _lbl_5.Caption = "Your 4POS CD is not installed 4POS CD must be Inserted to Register."
	'                'Timer2.Enabled = True
	'                Timer1.Enabled = False
	'                'Timer5.Enabled = 0
	'                'X = 324
	'                'Y = 95
	'                'chkFields_Click
	'                txtFields.Enabled = False
	'                'txtFields.SetFocus
	'                Exit Sub
	'            End If
	'
	'        Else
	'            'Timer1.Enabled = True
	'            'Y = 95'
	'
	'            'If Not Timer5.Enabled Then
	'            'label1.Cls
	'            'label1.CurrentX = 0
	'            'label1.CurrentY = 0
	'            'label1.Print "---<cd rom is off---->"'
	'
	'            'Timer5.Enabled = True
	'            'End If
	'            _lbl_5.Caption = "It looks you don't have CD-ROM drive. Please Type the CD Key Manually and press Exit."'
	'
	'            chkFields_Click
	'            txtFields.Enabled = True
	'            txtFields.SetFocus
	'        End If
	'    Next
	'    If i >= 8 Then Timer1.Enabled = False
	'End Sub''
	
	'
	'Function OLD__TEST_CDROM(ByVal CDR_SYMBOL) As Boolean '
	''
	'On Error GoTo ER
	'File1.Path = CDR_SYMBOL & "\"''
	'
	'Dim retval
	'yourdrive = CDR_SYMBOL
	'''
	'
	''this is the main call to open the CD tray using a drive list box
	'retval = openCD(Mid(CDR_SYMBOL, 1, 1))
	'If retval <> 0 Then
	'    'MsgBox "Not a CD drive!"
	'Else
	'    TEST_CDROM = True
	'    'Drive1.Drive = CDR_SYMBOL
	'
	'End If
	''label1.Cls
	''label1.CurrentX = 0
	''label1.CurrentY = 0
	''label1.Print "cd rom <" & CDR_SYMBOL & "> is inserted please wait ..."
	'Exit Function
	'ER:
	'If Err.Number = 68 Then
	'
	'    Else
	'        MsgBox Err.Number & Err.Description
	'        TEST_CDROM = False
	'End If'
	'
	'End Function'
	'
	'Public Function OLD__setupCodeAuto(ByVal CDR_SYMBOL) As Boolean
	'
	'    Dim fso As New FileSystemObject
	'    Dim fsoFolder As Folder
	'    Dim fsoDrive As Drive
	'
	'    On Error GoTo D_Err
	'    DoEvents
	'
	'    Drive1.Drive = CDR_SYMBOL
	'    Set fsoFolder = fso.GetFolder(Drive1.Drive & "\")
	'    txtFields.Text = fsoFolder.Drive.VolumeName
	'
	'Dim cCrypto As clsCryptoAPI ' clsCryptoAPI''
	'
	'Dim strSerial As String
	'Dim strTmp'
	'
	'        Set cCrypto = New clsCryptoAPI 'clsCryptoAPI
	'        DoEvents
	'        txtFields.Text = LTrim(txtFields.Text)
	'        txtFields.Text = RTrim(txtFields.Text)
	'        txtFields.Text = Trim(txtFields.Text)
	'        'strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
	'        strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, (Len(txtFields.Text) - 5)))
	'        DoEvents
	'        arData = cCrypto.StringToByteArray(strTmp)
	'        DoEvents
	'        arPWord = cCrypto.StringToByteArray(Val(Right(txtFields.Text, 5)))
	'        DoEvents
	'        cCrypto.PassWord = arPWord()
	'        DoEvents
	'        cCrypto.InputData = arData()
	'        DoEvents
	'
	'        ' Decrypt the data input from the encrypted text box
	'        'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
	'        If cCrypto.Decrypt(2, 1) Then
	'            DoEvents
	'            arData = cCrypto.OutputData
	'            strSerial = cCrypto.ByteArrayToString(arData)
	'        End If
	'
	'        If strSerial = "pos" Then
	'
	'            'Create date password
	'            Dim intDate   As Integer
	'            Dim intYear   As Integer
	'            Dim intMonth   As Integer
	'            Dim dtDate   As String
	'            Dim dtMonth  As String
	'            Dim dtYear  As String
	'            Dim stPass As String
	'            If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then
	'                strSerial = Mid(strSerial, 4, Len(strSerial))
	'                intYear = Mid(strSerial, 5, 2)
	'                intMonth = Mid(strSerial, 3, 2)
	'                intDate = Left(strSerial, 2)
	'
	'                If (intDate / 2) = Round(intDate / 2) Then
	'                    intDate = intDate / 2
	'                Else
	'                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                    setupCodeAuto = False
	'                    GoTo jumpOut
	'                End If
	'
	'                If (intMonth / 3) = Round(intMonth / 3) Then
	'                    intMonth = intMonth / 3
	'                Else
	'                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                    setupCodeAuto = False
	'                    GoTo jumpOut
	'                End If
	'
	'                If (intYear / 4) = Round(intYear / 4) Then
	'                    intYear = intYear / 4
	'                Else
	'                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                    setupCodeAuto = False
	'                    GoTo jumpOut
	'                End If
	'
	'                stPass = "20"
	'                If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
	'                If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
	'                If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
	'
	'                If IsDate(stPass) Then
	'                    If CDate(stPass) >= (Date - 31) Then
	'                        CDKey = True
	'                        setupCodeAuto = True
	'                    Else
	'                        MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                        setupCodeAuto = False
	'                        GoTo jumpOut
	'                    End If
	'                Else
	'                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                    setupCodeAuto = False
	'                    GoTo jumpOut
	'                End If
	'
	'            Else
	'                MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'                setupCodeAuto = False
	'            End If
	'
	'            strCDKey = txtFields.Text
	'
	'            Dim rs As Recordset
	'            Dim rj As Recordset''''
	'
	'            Set rs = getRS("Select * FROM POS WHERE POS_Code = '" & Trim(strCDKey) & "'")
	'            If rs.RecordCount > 0 Then
	'
	'               'MsgBox "This CD already used and registered, Chooose another 4POS CD.", vbApplicationModal + vbInformation + vbOKOnly, App.title
	'               MsgBox "This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", vbApplicationModal + vbInformation + vbOKOnly, App.title
	'              setupCodeAuto = False
	'               CDKey = False
	'            Else
	'                CDKey = True
	'                setupCodeAuto = True
	'            End If
	'
	'        Else
	'            MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
	'            setupCodeAuto = False
	'        End If
	'
	'jumpOut:
	'        Set cCrypto = Nothing    ' Free the Crypto class from memory
	'        strTmp = String$(250, 0)  ' overwrite data in temp variable
	'
	'
	'Exit Function
	'D_Err:
	''If Err.Number = 76 Then
	''    MsgBox "Drive is not ready, or still loading disc."
	''Else
	''    MsgBox Err.Number & " - " & Err.Description
	''End If
	'setupCodeAuto = False
	'    'Exit Function
	'End Function''
	'
	'Private Sub OLD__chkFields_Click()
	'txtFields.Enabled = chkFields
	'End Sub''
	
	'Private Sub OLD__Command1_Click()
	'Dim retval
	'Dim yourdrive As String
	'''
	''this is the main call to open the CD tray using a drive list box
	'retval = openCD(Mid(Drive1.Drive, 1, 1))
	'''
	''Or you could do this, without a drive box:
	'''
	''yourdrive = "D"
	''retval = openCD(YourDrive)
	'''
	''we need to make sure retval is 0, else an error happend
	'If retval <> 0 Then MsgBox "Not a CD drive!"
	'End Sub''
	'
	'Private Sub OLD__Command2_Click()
	'On Error GoTo D_Err
	'    Dim retval
	'    Dim fso As New FileSystemObject
	'    Dim fsoFolder As Folder
	'    Dim fsoDrive As Drive
	'
	'_lbl_5.Caption = "Loading Key Please wait..."''
	'
	''this is the main call to close the CD tray using a drive list box
	'retval = closeCD(Mid(yourdrive, 1, 1))
	''we need to make sure retval is 0, else an error happend
	'If retval <> 0 Then
	'    MsgBox "Not a CD drive OR No CD in Drive!"
	'    _lbl_5.Caption = "Not a CD drive OR No CD in Drive! Please put the CD Key Manually."
	'            chkFields_Click
	'            txtFields.Enabled = True
	'            txtFields.SetFocus
	'
	'Else
	'    'getSerialNumber = ""
	'    'If fso.FolderExists(serverPath) Then
	'    '    Set fsoFolder = fso.GetFolder(serverPath)
	'    '    getSerialNumber = fsoFolder.Drive.SerialNumber
	'    'End If
	'    Drive1.Drive = yourdrive
	'    Set fsoFolder = fso.GetFolder(Drive1.Drive & "\")
	'    'txtFields.Text = fsoFolder.Drive.SerialNumber
	'    txtFields.Text = fsoFolder.Drive.VolumeName
	'
	'    '_lbl_5.Caption = "Click Save && Exit to verify and save CD Key."
	'    cmdClose_Click
	'End If'
	'
	'Exit Sub
	'D_Err:
	'If Err.Number = 76 Then
	'    MsgBox "Drive is not ready, or still loading disc."
	'Else
	'    MsgBox Err.Number & " - " & Err.Description
	'End If
	'
	'
	'End Sub'
	'
	'Private Sub OLD__Form_Resize()
	'  On Error Resume Next
	'Unload Me
	'End Sub'
	'UPGRADE_WARNING: Event txtFields.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtFields_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.TextChanged
		
	End Sub
End Class