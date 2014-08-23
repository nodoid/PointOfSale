Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStockTakeLIQ
	Inherits System.Windows.Forms.Form
	Dim rs As ADODB.Recordset
	Dim Te_Name As String
	Dim MyFTypes As String
	Dim sql1 As String
	
	Dim fso As New Scripting.FileSystemObject ' picture loading
	Dim lMWNo As Integer ' to select W/H for stock take
	Dim rsLIQ As New ADODB.Recordset
	
	Private arData() As Byte
	Private arPWord() As Byte
	Private m_intCipher As Short
	'serialization
	
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
	
	Private Sub cmdReg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReg.Click
		If frmStockTakeLIQCode.setupCode = True Then
			Picture1.Visible = False
		End If
	End Sub
	
	Private Function getSerialNumber() As String
		Dim fso As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		Dim fsoDrive As Scripting.Drive
		getSerialNumber = ""
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
		Dim l As Integer
		Dim x As Short
		'UPGRADE_NOTE: Char was upgraded to Char_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Char_Renamed As String
		l = Len(password)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim intMonth As Object
		Dim intYear As Object
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		Dim strSerial As String
		Dim strTmp As Object
		Dim intDate As Short
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
				If rs.Fields.Count <= 55 Then checkSecurity = True : Exit Function
				
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rs.Fields("Company_ResMS").Value) Then checkSecurity = False : Exit Function
				
				
				cCrypto = New clsCryptoAPI 'clsCryptoAPI
				System.Windows.Forms.Application.DoEvents()
				'strTmp = cCrypto.ConvertStringFromHex(Left(rs("Company_ResMS"), 6))
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ConvertStringFromHex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object strTmp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strTmp = cCrypto.ConvertStringFromHex(VB.Left(rs.Fields("Company_ResMS").Value, Len(rs.Fields("Company_ResMS").Value) - 5))
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				arData = cCrypto.StringToByteArray(strTmp)
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				arPWord = cCrypto.StringToByteArray(Val(VB.Right(rs.Fields("Company_ResMS").Value, 5)))
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.password. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
                cCrypto.PassWord = arPWord
				System.Windows.Forms.Application.DoEvents()
				'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.InputData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
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
				
				If VB.Left(strSerial, 3) = "liq" Then
					
					'Create date password
					If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then
						
						checkSecurity = True
						GoTo jumpOut
						
						strSerial = Mid(strSerial, 4, Len(strSerial))
						'UPGRADE_WARNING: Couldn't resolve default property of object intYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						intYear = Mid(strSerial, 5, 2)
						'UPGRADE_WARNING: Couldn't resolve default property of object intMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						intMonth = Mid(strSerial, 3, 2)
						intDate = CShort(VB.Left(strSerial, 2))
						
						If (intDate / 2) = System.Math.Round(intDate / 2) Then
							intDate = intDate / 2
						Else
							GoTo jumpOut
						End If
						
						'UPGRADE_WARNING: Couldn't resolve default property of object intMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If (intMonth / 3) = System.Math.Round(intMonth / 3) Then
							'UPGRADE_WARNING: Couldn't resolve default property of object intMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							intMonth = intMonth / 3
						Else
							GoTo jumpOut
						End If
						
						'UPGRADE_WARNING: Couldn't resolve default property of object intYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If (intYear / 4) = System.Math.Round(intYear / 4) Then
							'UPGRADE_WARNING: Couldn't resolve default property of object intYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							intYear = intYear / 4
						Else
							GoTo jumpOut
						End If
						
						stPass = "20"
						'UPGRADE_WARNING: Couldn't resolve default property of object intYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Len(CStr(intYear)) = 1 Then
							stPass = stPass & "0" & intYear & "/"
						Else
							'UPGRADE_WARNING: Couldn't resolve default property of object intYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							stPass = stPass & intYear & "/"
						End If
						'UPGRADE_WARNING: Couldn't resolve default property of object intMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Len(CStr(intMonth)) = 1 Then
							stPass = stPass & "0" & intMonth & "/"
						Else
							'UPGRADE_WARNING: Couldn't resolve default property of object intMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							stPass = stPass & intMonth & "/"
						End If
						If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
						
						If IsDate(stPass) Then
							If CDate(stPass) >= (System.Date.FromOADate(Today.ToOADate - 31)) Then
								checkSecurity = True
							End If
						End If
						
					Else
						'MsgBox "Not a Valid 4MEAT Key!", vbCritical
					End If
				Else
					'MsgBox "Not a Valid 4MEAT Key!", vbCritical
				End If
jumpOut: 
				'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				cCrypto = Nothing ' Free the Crypto class from memory
				'UPGRADE_WARNING: Couldn't resolve default property of object strTmp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strTmp = New String(Chr(0), 250) ' overwrite data in temp variable
				Exit Function
				
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				'End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			'End
		End If
	End Function
	
	
	Private Sub loadLanguage()
		
		'NOTE: Caption has a spelling mistake, DB Entry 1213 is correct!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1213 'Stock Take
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2506 'Show Differendce|Checked
		If rsLang.RecordCount Then cmdDiff.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDiff.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 2507 requires "&" for accelerator key
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2507 'Save and Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1674 'Description|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1676 'Qty|Checked
		If rsLang.RecordCount Then Label3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then cmdsearch.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdsearch.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2512 'Show Pictures|Checked
		If rsLang.RecordCount Then chkPic.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPic.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTakeLIQ.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'UPGRADE_WARNING: Event chkPic.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkPic_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPic.CheckStateChanged
		If chkPic.CheckState Then
            Me.Width = twipsToPixels(12675, True)
			picBC.Visible = True
			imgBC.Visible = True
            Me.Left = twipsToPixels(400, True)
		Else
            Me.Width = twipsToPixels(8640, True)
			picBC.Visible = False
			imgBC.Visible = False
		End If
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim MStockNew As Integer
		On Error GoTo MyErH
		Dim rsB As ADODB.Recordset
		Dim rsk As ADODB.Recordset
		
		rsB = New ADODB.Recordset
		rsk = New ADODB.Recordset
		
		rsk = getRS("SELECT * FROM " & Te_Name & "")
		
		If rsk.RecordCount > 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object MStockNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MStockNew = 2
			rsB = getRS("INSERT INTO StockGroup(StockGroup_Name,StockGroup_Disabled)VALUES('" & Te_Name & "',0)")
			UpdateCatalogID((Te_Name))
		End If
MyErH: 
		If rsLIQ.State Then rsLIQ.Close()
		Me.Close()
		
	End Sub
	
	Private Sub report_WHTransfer(ByRef tblName As String)
		Dim rs As ADODB.Recordset
		Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryWHRecVerify.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT Company.Company_Name FROM Company;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
		sql = "SELECT Handheld777_0.HandHeldID, StockItem.StockItem_Name, Handheld777_0.Quantity"
		sql = sql & " FROM Handheld777_0 INNER JOIN StockItem ON Handheld777_0.HandHeldID = StockItem.StockItemID;"
		rs = getRS(sql)
		
		ReportNone.Load("cryNoRecords.rpt")
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		Report.Database.Tables(1).SetDataSource(rs)
		
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub cmdDiff_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDiff.Click
        Dim strIn As String
        Dim strFldName As String
		'Te_Name
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		On Error Resume Next
		'Set rs = getRS("SELECT * FROM Te_Name")
		
		cnnDB.Execute("DELETE * FROM Handheld777_0;")
		cnnDB.Execute("DROP TABLE Handheld777_0;")
		strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
		cnnDB.Execute("CREATE TABLE " & "Handheld777_0" & " (" & strFldName & ")")
		System.Windows.Forms.Application.DoEvents()
		
		rj = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)>0))")
		Do While rj.EOF = False
			
			rs = getRS("SELECT * FROM " & Te_Name & " WHERE HandHeldID=" & rj.Fields("WarehouseStockItemLnk_StockItemID").Value & ";")
			If rs.RecordCount > 0 Then
			Else
				strIn = "INSERT INTO Handheld777_0 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rj.Fields("WarehouseStockItemLnk_StockItemID").Value & ", '" & rj.Fields("WarehouseStockItemLnk_Quantity").Value & "', " & rj.Fields("WarehouseStockItemLnk_Quantity").Value & ")"
				cnnDB.Execute(strIn)
			End If
			
			rj.moveNext()
		Loop 
		
		report_WHTransfer("Handheld777_0")
		
		cnnDB.Execute("DELETE * FROM Handheld777_0;")
		cnnDB.Execute("DROP TABLE Handheld777_0;")
		Exit Sub
diff_Error: 
		MsgBox(Err.Number & " " & Err.Description)
	End Sub
	
	Private Sub cmdsearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsearch.Click
		Dim eroor As Object
		On Error Resume Next
		'openConnection
		Dim rsP As ADODB.Recordset
		Dim rsk As ADODB.Recordset
		Dim rsTest As ADODB.Recordset
		Dim rsNew As ADODB.Recordset
		
		rs = New ADODB.Recordset
		rsP = New ADODB.Recordset
		rsk = New ADODB.Recordset
		rsk = New ADODB.Recordset
		rsTest = New ADODB.Recordset
		rsNew = New ADODB.Recordset
		If Me.txtcode.Text = "" Then Exit Sub
		'If Me.txtCode.Text <> "" Then
		'creating table name
		'Te_Name = "HandHeld" & Trim(Year(Date)) & Trim(Month(Date)) & Trim(Day(Date)) & Trim(Hour(Now)) & Trim(Minute(Now)) & Trim(Second(Now)) & "_" & frmMenu.lblUser.Tag
		rsTest = getRS("SELECT Barcodes,Description,Quantity FROM " & Te_Name & "")
		
		'If rsTest.RecordCount And MStockNew = 0 Then
		rs = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode='" & Me.txtcode.Text & "'")
		
		'check if the barcode exists
		If rs.RecordCount > 0 Then
			rsP = getRS("SELECT StockItem_Name FROM StockItem WHERE StockItemID=" & rs.Fields("Catalogue_StockItemID").Value & "")
			Me.txtdesc.Text = rsP.Fields("StockItem_Name").Value
			Me.txtqty.Focus()
			
			'show pic
			If Me.cmdsearch.Text <> "&Add" Then
				If chkPic.CheckState And picBC.Visible = True Then
					If fso.FileExists(serverPath & "\images\" & Me.txtcode.Text & ".jpg") Then
						picBC.Image = System.Drawing.Image.FromFile(serverPath & "\images\" & Me.txtcode.Text & ".jpg")
						imgBC.Image = picBC.Image
					Else
						MsgBox("No picture found for " & Me.txtcode.Text)
					End If
				End If
			End If
			'show pic
			
			Me.cmdsearch.Text = "&Add"
			
			'get Weight
			If Me.txtqty.Text = "" Then tmrGetWei.Enabled = True
			
			'if the barcode does not exist display a message
		ElseIf rs.RecordCount < 1 Then 
			MsgBox("The Item does not exist,Please add it in Stock Create/Edit, New Stock Item", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, "4POS")
			Me.txtcode.Text = ""
			Me.txtcode.Focus()
			Exit Sub
		End If
		
		'Checking if the barcode was found and if the quantity textbox has a value
		Dim NewQty As Double
		If Me.cmdsearch.Text = "&Add" And Me.txtqty.Text <> "" Then
			'creating fields with their data types
			MyFTypes = "HandHeldID Number,Barcodes Text(50),Description Text(50),Quantity Currency"
			
			rsk = getRS("SELECT * FROM " & Te_Name & "")
			'if the table has not been created yet create it
			Select Case eroor
				Case Is < 0
					Error(5)
				Case 1
					GoTo erh
			End Select
			
erh: cnnDB.Execute("CREATE TABLE " & Te_Name & " (" & MyFTypes & ")")
			
			'selecting from the new table created
			rsNew = getRS("SELECT * FROM " & Te_Name & " WHERE Barcodes='" & Me.txtcode.Text & "'")
			'if the item is already in the newly created table then add the previous quantity to the new one then update it
			If rsNew.RecordCount > 0 Then
				
				NewQty = CDbl(Me.txtqty.Text)
				
				NewQty = NewQty + rsNew.Fields("Quantity").Value
				'update the quantity
				rsk = getRS("UPDATE " & Te_Name & " SET Quantity=" & NewQty & " WHERE Barcodes='" & Me.txtcode.Text & "'")
			ElseIf rsNew.RecordCount < 1 Then 
				'inserting into the newly created table
				rsk = getRS("INSERT INTO " & Te_Name & "(HandHeldID,Barcodes,Description,Quantity)VALUES(" & rs.Fields("Catalogue_StockItemID").Value & ",'" & Me.txtcode.Text & "','" & Me.txtdesc.Text & "'," & Me.txtqty.Text & " )")
			End If
			
			'selecting from the newly created table
			rsk = getRS("SELECT Barcodes,Description,Quantity FROM " & Te_Name & "")
			'filling the datagrid with the record consisting of barcode,description,quantity if the barcode exist
			Me.DataGrid1.DataSource = rsk
			Me.txtcode.Text = ""
			Me.txtdesc.Text = ""
			Me.txtqty.Text = ""
			Me.cmdsearch.Text = "&Search"
			Me.txtcode.Focus()
			
		End If
		'ElseIf rsTest.RecordCount > 0 And MStockNew = 2 Then
		'MsgBox "A Table with the Same Name Already Exist", vbApplicationModal + vbOKOnly, "4POS"
		'Me.txtCode.Text = ""
		'Me.cmdClose.SetFocus
		'End If
	End Sub
	
    Private Sub frmStockTakeLIQ_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = 13 And Me.cmdsearch.Text = "&Search" And Me.txtcode.Text <> "" Then
            cmdsearch_Click(cmdsearch, New System.EventArgs())
        ElseIf KeyAscii = 13 And Me.cmdsearch.Text = "&Add" And Me.txtdesc.Text <> "" Then
            cmdsearch_Click(cmdsearch, New System.EventArgs())
        ElseIf KeyAscii = 27 Then
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Sub UpdateCatalogID(ByRef st_Name As String)
        Dim strFldName As Object
        Dim strIn As Object
        Dim rj As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim rID As ADODB.Recordset

        'Set rID = getRS("SELECT * FROM " & st_Name)
        'Do While rID.EOF = False
        '        If prgUpdate.value = prgUpdate.Max Then
        '           prgUpdate.value = 0
        '        Else
        '           prgUpdate.value = prgUpdate.value + 1
        '        End If
        '    'rID("Handheld_Barcode") = 0
        '        rID("HandHeldID") = 0
        '        rID.update '"HandHeldID", 0
        ' rID.moveNext
        'Loop

        'UPGRADE_WARNING: Couldn't resolve default property of object strIn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        strIn = "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Quantity > 0;"
        'UPGRADE_WARNING: Couldn't resolve default property of object strIn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cnnDB.Execute(strIn)

        rj = getRS("SELECT * FROM " & st_Name)
        Do While rj.EOF = False
            'If prgUpdate.value = prgUpdate.Max Then
            '   prgUpdate.value = 0
            'Else
            '   prgUpdate.value = prgUpdate.value + 1
            'End If

            'Set rs = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
            rs = getRS("SELECT StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, * FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" & rj.Fields("Barcodes").Value & "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));")
            If rs.RecordCount > 0 Then cnnDB.Execute("UPDATE " & st_Name & " SET HandHeldID = " & rs.Fields("Catalogue_StockItemID").Value & ", Quantity = " & (rj.Fields("Quantity").Value * rs.Fields("Catalogue_Quantity").Value) & " WHERE Barcodes = '" & rj.Fields("Barcodes").Value & "'")

            rj.moveNext()
        Loop

        'chkDuplicate:
        'UPGRADE_WARNING: Couldn't resolve default property of object strFldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        strFldName = "HandHeldID Number,Barcodes Text(50),Description Text(50),Quantity Currency"
        'UPGRADE_WARNING: Couldn't resolve default property of object strFldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cnnDB.Execute("CREATE TABLE " & "Handheld777" & " (" & strFldName & ")")
        System.Windows.Forms.Application.DoEvents()

        rj = getRS("SELECT * FROM " & st_Name)
        Do While rj.EOF = False

            rs = getRS("SELECT * FROM Handheld777 WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";")
            If rs.RecordCount > 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object strIn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strIn = "UPDATE Handheld777 SET Quantity = " & (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) & " WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object strIn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strIn = "INSERT INTO Handheld777 (HandHeldID,Barcodes,Quantity) VALUES (" & rj.Fields("HandHeldID").Value & ", '" & rj.Fields("Barcodes").Value & "', " & rj.Fields("Quantity").Value & ")"
            End If
            'UPGRADE_WARNING: Couldn't resolve default property of object strIn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cnnDB.Execute(strIn)

            rj.moveNext()
        Loop

        cnnDB.Execute("DELETE * FROM " & st_Name & ";")
        'strIn = "SELECT Handheld777.* INTO " & st_Name & " FROM Handheld777" '& ResolveTable(cmbTables.Text)
        cnnDB.Execute("INSERT INTO " & st_Name & " SELECT * FROM Handheld777;")
        cnnDB.Execute("DROP TABLE Handheld777;")
        'chkDuplicate:

        'DeleteBlankID
        'MsgBox "File was extracted and exported succesfully", vbApplicationModal + vbInformation + vbOKOnly, App.title
        'prgUpdate.value = 300

    End Sub

    Private Sub frmStockTakeLIQ_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cnnDB Is Nothing Then
            If openConnection = True Then

            End If
        End If
        'creating table name
        Te_Name = "HandHeld" & Trim(CStr(Year(Today))) & Trim(CStr(Month(Today))) & Trim(CStr(VB.Day(Today))) & Trim(CStr(Hour(Now))) & Trim(CStr(Minute(Now))) & Trim(CStr(Second(Now))) & "_" & frmMenu.lblUser.Tag

        loadLanguage()

        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            'Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            'Report.txtWH.SetText rsWH("Warehouse_Name")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub frmStockTakeLIQ_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If rsLIQ.State Then rsLIQ.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

        If fso.FileExists(serverPath & "4LIQ-DATA.pos") Then

            rsLIQ.Open(serverPath & "\4LIQ-DATA.pos", , ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            rsLIQ.filter = ADODB.FilterGroupEnum.adFilterNone
            '        Do Until rsLIQ.EOF
            '            'Text1 = rsLIQ("StockItemName")
            '            'Text2 = rsLIQ("StockItemBC")
            '            'MsgBox "next"
            '            If LCase(rsLIQ("StockItemName")) = LCase(frmMenu.lblCompany.Caption) Then Exit Sub
            '            rsLIQ.moveNext
            '        Loop

            'Serial chk
            If checkSecurity = True Then
                Exit Sub
            Else
                Label4.Text = "Please contact your 4POS representative or www.4pos.co.za."
                cmdReg.Visible = True
            End If
            '        If date > #11/11/2012# Then
            '        Else
            '            Exit Sub
            '        End If
        Else
            Label4.Text = "'4LIQ-DATA.pos' file is missing."
        End If

        With Picture1
            .Top = 0
            .Left = 0
            .Width = Me.Width
            .Height = Me.Height
        End With

    End Sub

    Private Sub tmrGetWei_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrGetWei.Tick
        Dim frmDSWeight As Object
        Dim cScaleWeight As Decimal
        Dim cStockTots As Decimal
        tmrGetWei.Enabled = False

tryScaleWeight:
        'UPGRADE_WARNING: Couldn't resolve default property of object frmDSWeight.getScaleWeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cScaleWeight = frmDSWeight.getScaleWeight
        'cScaleWeight = 0.874
        If cScaleWeight <= 0 Then
            If MsgBox("Do you wish to try again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                GoTo tryScaleWeight
            Else
                Me.txtcode.Text = ""
                Me.txtdesc.Text = ""
                Me.txtqty.Text = ""
                Me.cmdsearch.Text = "&Search"
                Me.txtcode.Focus()
            End If
        Else
            rsLIQ.filter = "StockItemBC='" & Me.txtcode.Text & "'"
            If rsLIQ.RecordCount Then
                cStockTots = (cScaleWeight - CDec(rsLIQ.Fields("Empty").Value)) / CDec(rsLIQ.Fields("PerTotWeight").Value)
                Me.txtqty.Text = CStr(cStockTots)
                frmStockTakeLIQ_KeyPress(Me, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
            Else
                MsgBox("The Item does not exist in 4LIQ file.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, "4POS")
                Me.txtcode.Text = ""
                Me.txtdesc.Text = ""
                Me.txtqty.Text = ""
                Me.cmdsearch.Text = "&Search"
                Me.txtcode.Focus()
            End If
        End If

    End Sub
End Class