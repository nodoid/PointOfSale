Option Strict Off
Option Explicit On
Friend Class frmPersonFPReg
	Inherits System.Windows.Forms.Form
	Dim WithEvents op As DPSDKOPSLib.FPRegisterTemplate
	Dim cursample As Short
	Dim register As DpSdkEngLib.FPTemplate
	
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
    Dim WithEvents Label6 As New List(Of Label)
    Dim WithEvents picSample As New List(Of PictureBox)
	Private Sub loadLanguage()
		
		'frmPersonFPReg = No Code   [Registration Form]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPersonFPReg.Caption = rsLang("LanguageLayoutLnk_Description"): frmPersonFPReg.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label3 = No Code           [Press Start Button to Start]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'eName = No Code/Dynamic!
		
		'Label1 = No Code           [Quality]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2496 'Start|
		If rsLang.RecordCount Then start_cmd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : start_cmd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Command1 = No Code         [Verify]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code           [Events]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPersonFPReg.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
		On Error GoTo FPA_Error
		
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
		
		loading = True
		gID = id
		'Set rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
		rs = getRS("SELECT * FROM Person WHERE PersonID = " & id)
		
		eName.Text = "Finger Print Registration for -> " & UCase(rs.Fields("Person_LastName").value) '& ""
		eName.Refresh()
		
		rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & id)
		If rs.RecordCount > 0 Then
			Label3.Text = "You already have Finger Prints saved."
		Else
			
		End If
		
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub Save_and_Load_Verify_Form()
        Dim rs As ADODB.Recordset
		Dim blob_write As Object
		On Error GoTo FPA_Error
		
		Dim bvariant As Object
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		'UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		blob_write = System.DBNull.Value
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		'UPGRADE_WARNING: Couldn't resolve default property of object bvariant. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		bvariant = System.DBNull.Value
		
		If register Is Nothing Then
			lblEvents.Text = ""
			MsgBox("Nothing Registered !!")
			Exit Sub
		End If
		
		register.Export(bvariant)
		'UPGRADE_WARNING: Couldn't resolve default property of object bvariant. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		blob_write = bvariant
		
		rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & gID)
		'UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If rs.RecordCount > 0 Then
			'cnnDB.Execute "UPDATE PersonFPLnk SET PersonFPLnk.Person_FP = " & blob_write & " WHERE (((PersonFPLnk.PersonID)=" & gID & "));"
			'rs.AddNew
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rs("PersonID").Value = gID
			'UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rs("Person_FP").Value = blob_write
			'UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs.update()
		Else
			'cnnDB.Execute "INSERT INTO PersonFPLnk (PersonID, Person_FP) VALUES (" & gID & ", " & blob_write & ")"
			'UPGRADE_WARNING: Couldn't resolve default property of object rs.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs.AddNew()
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rs("PersonID").Value = gID
			'UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rs("Person_FP").Value = blob_write
			'UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs.update()
		End If
		
		'reslt = MsgBox("Wana do more registerations !! ? ", vbYesNo, "More Registrations ?")
		'If reslt = 6 Then
		' eName.Text = ""
		' eName.Refresh
		' Label3.Caption = "Before Putting finger on the senser - Enter New Name -> "
		' Label3.Refresh
		' Call start_cmd_Click
		'Else
		frmPersonFPVerify.loadItem((gID))
		'End If
		
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
		
		frmPersonFPVerify.loadItem((gID))
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub frmPersonFPReg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Label6.AddRange(New Label() {_Label6_0, _Label6_1, _Label6_2, _Label6_3})
        picSample.AddRange(New PictureBox() {_picSample_0, _picSample_1, _picSample_2, _picSample_3})

        Dim i As Integer
		On Error GoTo FPA_Error
		
		'If cnx Is Nothing And rs Is Nothing Then
		'Set cnx = New Connection
		'Set rs = New Recordset
		'End If
		'cnx.Open "sdb", "", ""
		'rs.Open "select * from empl", cnx, adOpenKeyset, adLockOptimistic
		
		cursample = 0
		
		op = New DPSDKOPSLib.FPRegisterTemplate
		For i = 0 To 3
			'UPGRADE_NOTE: Object picSample().Picture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			picSample(i).Image = Nothing
			Label6(i).Visible = False
		Next i
		
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
		On Error GoTo FPA_Error
		
		lblEvents.Text = ""
		'UPGRADE_NOTE: Object register may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		register = Nothing
		register = pTemplate
		MsgBox("Registration Process is Done. Please wait while system verify and save information...")
		Call Save_and_Load_Verify_Form()
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub op_SampleQuality(ByVal Quality As DpSdkEngLib.AISampleQuality) Handles op.SampleQuality
		On Error GoTo FPA_Error
		
		Select Case Quality
			Case DpSdkEngLib.AISampleQuality.Sq_Good
				lblQuality.Text = "OK"
				cursample = cursample + 1
				Label6(cursample - 1).Visible = False
				If cursample <> 4 Then
					Label6(cursample).Visible = True
				End If
			Case DpSdkEngLib.AISampleQuality.Sq_LowContrast
				lblQuality.Text = "Bad Quality"
			Case DpSdkEngLib.AISampleQuality.Sq_NoCentralRegion
				lblQuality.Text = "Bad Quality"
			Case DpSdkEngLib.AISampleQuality.Sq_None
				lblQuality.Text = "Bad Quality"
			Case DpSdkEngLib.AISampleQuality.Sq_NotEnoughFtr
				lblQuality.Text = "Bad Quality" '
			Case DpSdkEngLib.AISampleQuality.Sq_TooDark
				lblQuality.Text = "Too Dark"
			Case DpSdkEngLib.AISampleQuality.Sq_TooLight
				lblQuality.Text = "Too Light"
			Case DpSdkEngLib.AISampleQuality.Sq_TooNoisy
				lblQuality.Text = "Too Noisy"
		End Select
		lblEvents.Text = ""
		
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
		
		If cursample < 3 Then
			Label3.Text = "Yes, put your finger again on the sensor for sample #" & Str(cursample + 1)
			Label3.Refresh()
		Else
			Label3.Text = "Wait for the Verify form"
			Label3.Refresh()
			Me.Cursor = System.Windows.Forms.Cursors.Cross
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureOrientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		pSample.PictureOrientation = DpSdkEngLib.AIOrientation.Or_Portrait
		'UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pSample.PictureWidth = pixelToTwips(picSample(cursample).Width, True) / twipsPerPixel(True)
		'UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pSample.PictureHeight = pixelToTwips(picSample(cursample).Height, False) / twipsPerPixel(False)
		'UPGRADE_WARNING: Couldn't resolve default property of object pSample.Picture. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		picSample(cursample).Image = pSample.Picture
		lblEvents.Text = "Sample ready"
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
    Private Sub picSample_Click(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs)
        Dim Index As Integer
        Dim pbox As New PictureBox
        pbox = DirectCast(eventSender, PictureBox)
        Index = GetIndexer(pbox, picSample)
        On Error GoTo FPA_Error

        Dim i As Short
        cursample = 0
        For i = 0 To 3
            'UPGRADE_NOTE: Object picSample().Picture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            picSample(i).Image = Nothing
            Label6(i).Visible = False
        Next i
        Label6(cursample).Visible = True
        'UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        op = Nothing
        op = New DPSDKOPSLib.FPRegisterTemplate
        op.Run()
        lblQuality.Text = ""
        lblEvents.Text = ""

        Exit Sub
FPA_Error:
        If Err.Number = 429 Then
            MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
        Else
            MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
            Resume Next
        End If
    End Sub
	
	Private Sub start_cmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_cmd.Click
		On Error GoTo FPA_Error
		
		'eName.Text = ""
		'eName.Refresh
		Label3.Text = "Put your finger on the senser 4 times -> "
		Label3.Refresh()
		picSample_Click(picSample.Item(0), New System.EventArgs())
		
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