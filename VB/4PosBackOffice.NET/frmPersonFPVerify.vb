Option Strict Off
Option Explicit On
Friend Class frmPersonFPVerify
	Inherits System.Windows.Forms.Form
	Private WithEvents op As DPSDKOPSLib.FPGetTemplate
	Dim tp As DpSdkEngLib.FPTemplate
	Dim cnx1 As New ADODB.Connection
	Dim rs1 As New ADODB.Recordset
	Dim vp As DpSdkEngLib.FPVerify
	Dim nStartTimer As Single
	Dim nEndTimer As Single
	
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
	
	Private Sub loadLanguage()
		
		'frmPersonFPVerify = No Code    [Verify Form]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPersonFPVerify.Caption = rsLang("LanguageLayoutLnk_Description"): frmPersonFPVerify.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'eName = No Code / Dynamic!
		
		'Label1 = No Code               [Please put your finger on the sensor...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Command1 = No Code             [Verify Again?]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPersonFPVerify.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		On Error GoTo FPA_Error
		
		Me.Close()
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
		
		On Error GoTo FPA_Error
		loading = True
		gID = id
		'Set rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
		rs = getRS("SELECT * FROM Person WHERE PersonID = " & id)
		
		eName.Text = "Finger Print Verfication for -> " & UCase(rs.Fields("Person_LastName").value) '& ""
		eName.Refresh()
		
		'Set rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & id)
		'If rs.RecordCount > 0 Then
		'Label3 = "You already have Finger Prints saved."
		'Else
		'
		'End If
		
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
		
		Command1_Click(Command1, New System.EventArgs())
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		On Error GoTo FPA_Error
		'   If tName.Text = "" Then
		'     MsgBox "Enter user name "
		'     Exit Sub
		'   End If
		
		If op Is Nothing Then
			op = New DPSDKOPSLib.FPGetTemplate
		End If
		op.Run()
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub frmPersonFPVerify_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error GoTo FPA_Error
		
		'frmVerify.show 1
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub frmPersonFPVerify_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		On Error GoTo FPA_Error
		
		'rs.Close
		'cnx.Close
		'UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		op = Nothing
		'UPGRADE_NOTE: Object vp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		vp = Nothing
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub op_Done(ByVal pTemplate As Object) Handles op.Done
		Dim re As Object
		Dim thsh As Object
		Dim src As Object
		Dim er As Object
		Dim varnt As Object
		Dim blob_read As Object
		Dim rs As Object
		On Error GoTo FPA_Error
		
		tp = pTemplate
		Dim rp As DpSdkEngLib.FPTemplate
		
		op = New DPSDKOPSLib.FPGetTemplate
		vp = New DpSdkEngLib.FPVerify
		
		Dim result As Boolean
		Dim strHex As Object
		Dim strTemp As String
		Dim rno As Short
		
		rno = 1
		result = False
		
		rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & gID)
		'UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If rs.RecordCount > 0 Then
			
			'Label3 = "You already have Finger Prints saved."
			'rs.Find "employee_name = '" + tName.Text + "'"
			'If rs.EOF = False Then
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object blob_read. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			blob_read = rs("Person_FP")
			'UPGRADE_WARNING: Couldn't resolve default property of object blob_read. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object varnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			varnt = blob_read
			rp = New DpSdkEngLib.FPTemplate
			'UPGRADE_WARNING: Couldn't resolve default property of object er. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			er = rp.import(varnt)
			'UPGRADE_WARNING: Couldn't resolve default property of object re. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			re = vp.Compare(rp, pTemplate, result, src, thsh, False, DpSdkEngLib.AISecureModeMask.Sm_None)
			'UPGRADE_NOTE: Object rp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rp = Nothing
			'End If
			
		Else
			
		End If
		
		
		If result = True Then
			Label1.Text = "Passed !!! Finger prints matched "
			Label1.Refresh()
			MsgBox("Finger print matched.") '+ rs("employee_name")
		Else
			Label1.Text = "Failed !!! Finger prints NOT matched"
			Label1.Refresh()
			MsgBox("No finger print match found !")
		End If
		
		'UPGRADE_NOTE: Object rp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rp = Nothing
		'UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		op = Nothing
		'UPGRADE_NOTE: Object vp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		vp = Nothing
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub op_SampleReady(ByVal pSample As Object) Handles op.SampleReady
		On Error GoTo FPA_Error
		
		pSample.PictureOrientation = DpSdkEngLib.AIOrientation.Or_Portrait
		pSample.PictureWidth = pixelToTwips(Picture1.Width, True) / twipsPerPixel(True)
		 pSample.PictureHeight = pixelToTwips(Picture1.Height, False) / twipsPerPixel(False)
		Picture1.Image = pSample.Picture
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
End Class