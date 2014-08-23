Option Strict Off
Option Explicit On
Friend Class frmPersonFPRegOT
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: Capture was upgraded to Capture_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Dim WithEvents Capture_Renamed As DPFPDevXLib.DPFPCapture
	Dim CreateFtrs As DPFPEngXLib.DPFPFeatureExtraction
	Dim CreateTempl As DPFPEngXLib.DPFPEnrollment
	Dim ConvertSample As DPFPDevXLib.DPFPSampleConversion
	
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
	
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
			Label4.Text = "You already have Finger Prints saved."
		Else
			
		End If
		
		loading = False
		
		'loadLanguage
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
	
	Private Sub DrawPicture(ByVal Pict As System.Drawing.Image)
		' Must use hidden PictureBox to easily resize picture.
		HiddenPict.Image = Pict
		'UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'Picture1.PaintPicture(HiddenPict.Image, 0, 0, pixelToTwips(Picture1.ClientRectangle.Width, True), pixelToTwips(Picture1.ClientRectangle.Height, False), 0, 0, pixelToTwips(HiddenPict.ClientRectangle.Width, True), pixelToTwips(HiddenPict.ClientRectangle.Height, False), vbSrcCopy)
		Picture1.Image = Picture1.Image
	End Sub
	'UPGRADE_NOTE: Str was upgraded to Str_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub ReportStatus(ByVal Str_Renamed As String)
        ' Add string to list box.
        Dim i As Integer
        i = Status.Items.Add((Str_Renamed))
		' Move list box selection down.
		Status.SelectedIndex = i
	End Sub
	
	Private Sub Close_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Close_Renamed.Click
		' Stop capture operation. This code is optional.
		Capture_Renamed.StopCapture()
		' Unload form.
		Me.Close()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		' Stop capture operation. This code is optional.
		Capture_Renamed.StopCapture()
		' Unload form.
		Me.Close()
	End Sub
	
	Private Sub frmPersonFPRegOT_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' Create capture operation.
		Capture_Renamed = New DPFPDevXLib.DPFPCapture
		' Start capture operation.
		Capture_Renamed.StartCapture()
		' Create DPFPFeatureExtraction object.
		CreateFtrs = New DPFPEngXLib.DPFPFeatureExtraction
		' Create DPFPEnrollment object.
		CreateTempl = New DPFPEngXLib.DPFPEnrollment
		' Show number of samples needed.
		Samples.Text = CStr(CreateTempl.FeaturesNeeded)
		' Create DPFPSampleConversion object.
		ConvertSample = New DPFPDevXLib.DPFPSampleConversion
	End Sub
	
	Private Sub Capture_Renamed_OnReaderConnect(ByVal ReaderSerNum As String) Handles Capture_Renamed.OnReaderConnect
		ReportStatus(("The fingerprint reader was connected."))
	End Sub
	
	Private Sub Capture_Renamed_OnReaderDisconnect(ByVal ReaderSerNum As String) Handles Capture_Renamed.OnReaderDisconnect
		ReportStatus(("The fingerprint reader was disconnected."))
	End Sub
	
	Private Sub Capture_Renamed_OnFingerTouch(ByVal ReaderSerNum As String) Handles Capture_Renamed.OnFingerTouch
		ReportStatus(("The fingerprint reader was touched."))
	End Sub
	Private Sub Capture_Renamed_OnFingerGone(ByVal ReaderSerNum As String) Handles Capture_Renamed.OnFingerGone
		ReportStatus(("The finger was removed from the fingerprint reader."))
	End Sub
	Private Sub Capture_Renamed_OnSampleQuality(ByVal ReaderSerNum As String, ByVal Feedback As DPFPDevXLib.DPFPCaptureFeedbackEnum) Handles Capture_Renamed.OnSampleQuality
		If Feedback = DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood Then
			ReportStatus(("The quality of the fingerprint sample is good."))
		Else
			ReportStatus(("The quality of the fingerprint sample is poor."))
		End If
	End Sub
	
	Private Sub Capture_Renamed_OnComplete(ByVal ReaderSerNum As String, ByVal Sample As Object) Handles Capture_Renamed.OnComplete
		Dim rs As Object
		Dim Feedback As DPFPDevXLib.DPFPCaptureFeedbackEnum
		
		ReportStatus(("The fingerprint sample was captured."))
		' Draw fingerprint image.
		'UPGRADE_WARNING: Couldn't resolve default property of object ConvertSample.ConvertToPicture(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DrawPicture(ConvertSample.ConvertToPicture(Sample))
		' Process sample and create feature set for purpose of enrollment.
		Feedback = CreateFtrs.CreateFeatureSet(Sample, DPFPEngXLib.DPFPDataPurposeEnum.DataPurposeEnrollment)
		' Quality of sample is not good enough to produce feature set.
		Dim Templ As DPFPShrXLib.DPFPTemplate
		Dim blob() As Byte
		'UPGRADE_ISSUE: clsRC4 object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cBFCryp As New clsRC4
		If Feedback = DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood Then
			ReportStatus(("The fingerprint feature set was created."))
			Prompt.Text = "Touch the fingerprint reader again with the same finger."
			' Add feature set to template.
			CreateTempl.AddFeatures(CreateFtrs.FeatureSet)
			' Show number of samples needed to complete template.
			Samples.Text = CStr(CreateTempl.FeaturesNeeded)
			' Check if template has been created.
			If CreateTempl.TemplateStatus = DPFPEngXLib.DPFPTemplateStatusEnum.TemplateStatusTemplateReady Then
				
				'MainFrame.SetTemplete CreateTempl.Template
				' Template has been created, so stop capturing samples.
				Templ = CreateTempl.Template
				'UPGRADE_WARNING: Couldn't resolve default property of object Templ.Serialize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				blob = Templ.Serialize
				rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & gID)
				'UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If rs.RecordCount > 0 Then
					'cnnDB.Execute "UPDATE PersonFPLnk SET PersonFPLnk.Person_FP = " & blob_write & " WHERE (((PersonFPLnk.PersonID)=" & gID & "));"
					'rs.AddNew
					'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs("PersonID") = gID
					'UPGRADE_WARNING: Couldn't resolve default property of object cBFCryp.EncodeArray64. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs("Person_FPs") = cBFCryp.EncodeArray64(blob)
					'UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs.update()
				Else
					'cnnDB.Execute "INSERT INTO PersonFPLnk (PersonID, Person_FP) VALUES (" & gID & ", " & blob_write & ")"
					'UPGRADE_WARNING: Couldn't resolve default property of object rs.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs.AddNew()
					'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs("PersonID") = gID
					'UPGRADE_WARNING: Couldn't resolve default property of object cBFCryp.EncodeArray64. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs("Person_FPs") = cBFCryp.EncodeArray64(blob)
					'UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs.update()
				End If
				
				Capture_Renamed.StopCapture()
				Prompt.Text = "Click Exit, and then click Fingerprint Verification."
				MsgBox("The fingerprint template was created.")
				
				'frmPersonFPVerifyOT.loadItem (gID)
				'frmPersonFPVerify.loadItem (gID)
			End If
		End If
	End Sub
End Class