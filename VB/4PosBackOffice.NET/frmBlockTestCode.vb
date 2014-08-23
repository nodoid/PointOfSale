Option Strict Off
Option Explicit On
Option Compare Text
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmBlockTestCode
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
	
	Dim fox(8) As Object
	Dim usb_drv As String
	Dim yourdrive As String
	Dim CDKey As Boolean
	
	Private arData() As Byte
	Private arPWord() As Byte
	Private m_intCipher As Short
	Dim LsSection As String
	
	Private Sub loadLanguage()
		
		'frmBlockTestCode = No Code [4MEAT Registration]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBlockTestCode.Caption = rsLang("LanguageLayoutLnk_Description"): frmBlockTestCode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_5 = No Code           [Please type in your 4MEAT CD-Key]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_1 = No Code     [CD Key]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBlockTestCode.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub Reset_frmEncStrings()
		
		Erase arData
		Erase arPWord
		
	End Sub
	
	Private Sub Form_Initialize_Renamed()

        Initial_settings()
        Reset_frmEncStrings()

    End Sub
	
	
	Public Function setupCode() As Boolean
		
		CDKey = False
		System.Windows.Forms.Application.DoEvents()
		
		'For i = 68 To 75
		'    c = c + 1
		'    fox(c) = Chr(i) & ":"
		'Next
		
		loadLanguage()
		Me.ShowDialog()
		
		setupCode = CDKey
		'Exit Function
	End Function
	
	Private Sub frmBlockTestCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		CDKey = False
		Dim strSerial As String
        Dim strTmp As String
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		Dim dtDate As String
		Dim dtMonth As String
		Dim dtYear As String
		Dim stPass As String ' clsCryptoAPI
		'UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cCrypto As clsCryptoAPI
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				
				'if old database don't chk secuirty
				If rs.Fields.Count <= 55 Then
					CDKey = False
					MsgBox("You need to download latest 4POS upgrades in order to Register.", MsgBoxStyle.Critical, "4POS")
					Exit Sub
				End If
				
				txtFields.Text = Trim(Replace(txtFields.Text, "-", ""))
				
				
				cCrypto = New clsCryptoAPI 'clsCryptoAPI
				System.Windows.Forms.Application.DoEvents()
				txtFields.Text = LTrim(txtFields.Text)
				txtFields.Text = RTrim(txtFields.Text)
				txtFields.Text = Trim(txtFields.Text)
				'strTmp = cCrypto.ConvertStringFromHex(Left(rs("Company_ResMS"), 6))
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ConvertStringFromHex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strTmp = cCrypto.ConvertStringFromHex(VB.Left(txtFields.Text, Len(txtFields.Text) - 5))
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				arData = cCrypto.StringToByteArray(strTmp)
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				arPWord = cCrypto.StringToByteArray(Val(VB.Right(txtFields.Text, 5)))
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.password. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cCrypto.PassWord = arPWord
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.InputData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData)
				System.Windows.Forms.Application.DoEvents()
				
				' Decrypt the data input from the encrypted text box
				'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.Decrypt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If cCrypto.Decrypt(2, 1) Then
					System.Windows.Forms.Application.DoEvents()
					'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.OutputData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    arData = cCrypto.OutputData.Clone()
					'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSerial = cCrypto.ByteArrayToString(arData)
				End If
				
				If VB.Left(strSerial, 3) = "met" Then
					
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
							If CDate(stPass) >= (System.Date.FromOADate(Today.ToOADate - 31)) Then
								cnnDB.Execute("UPDATE Company SET Company_ResMS = '" & txtFields.Text & "';")
								CDKey = True
							End If
						End If
						
					Else
						MsgBox("Not a Valid 4MEAT Key!", MsgBoxStyle.Critical)
					End If
				Else
					MsgBox("Not a Valid 4MEAT Key!", MsgBoxStyle.Critical)
				End If
jumpOut: 
				cCrypto = Nothing ' Free the Crypto class from memory
				strTmp = New String(Chr(0), 250) ' overwrite data in temp variable
				'Exit Sub
				
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				'End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			'End
		End If
		
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		
	End Sub
End Class