Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStockTakeCSV
	Inherits System.Windows.Forms.Form
	Dim rs As ADODB.Recordset
	Dim Te_Name As String
	Dim MyFTypes As String
	Dim sql1 As String
	
	Dim fso As New Scripting.FileSystemObject ' picture loading
	Dim lMWNo As Integer ' to select W/H for stock take
	
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
		If rsLang.RecordCount Then cmdSearch.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdSearch.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2512 'Show Pictures|Checked
		If rsLang.RecordCount Then chkPic.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPic.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTakeCSV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
		Me.Close()
		
	End Sub
	
	Private Sub report_WHTransfer(ByRef tblName As String)
		Dim rs As ADODB.Recordset
        Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryWHRecVerify.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT Company.Company_Name FROM Company;")
		Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
		sql = "SELECT Handheld777_0.HandHeldID, StockItem.StockItem_Name, Handheld777_0.Quantity"
		sql = sql & " FROM Handheld777_0 INNER JOIN StockItem ON Handheld777_0.HandHeldID = StockItem.StockItemID;"
		rs = getRS(sql)
		
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
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
        Dim eroor As String
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
			Me.txtQty.Focus()
			
			'show pic
			If Me.cmdSearch.Text <> "&Add" Then
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
			
			Me.cmdSearch.Text = "&Add"
			'if the barcode does not exist display a message
		ElseIf rs.RecordCount < 1 Then 
			MsgBox("The Item does not exist,Please add it in Stock Create/Edit, New Stock Item", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, "4POS")
			Me.txtcode.Text = ""
			Me.txtcode.Focus()
			Exit Sub
		End If
		
		'Checking if the barcode was found and if the quantity textbox has a value
		Dim NewQty As Double
		If Me.cmdSearch.Text = "&Add" And Me.txtQty.Text <> "" Then
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
				
				NewQty = CDbl(Me.txtQty.Text)
				
				NewQty = NewQty + rsNew.Fields("Quantity").Value
				'update the quantity
				rsk = getRS("UPDATE " & Te_Name & " SET Quantity=" & NewQty & " WHERE Barcodes='" & Me.txtcode.Text & "'")
			ElseIf rsNew.RecordCount < 1 Then 
				'inserting into the newly created table
				rsk = getRS("INSERT INTO " & Te_Name & "(HandHeldID,Barcodes,Description,Quantity)VALUES(" & rs.Fields("Catalogue_StockItemID").Value & ",'" & Me.txtcode.Text & "','" & Me.txtdesc.Text & "'," & Me.txtQty.Text & " )")
			End If
			
			'selecting from the newly created table
			rsk = getRS("SELECT Barcodes,Description,Quantity FROM " & Te_Name & "")
			'filling the datagrid with the record consisting of barcode,description,quantity if the barcode exist
			Me.DataGrid1.DataSource = rsk
			Me.txtcode.Text = ""
			Me.txtdesc.Text = ""
			Me.txtQty.Text = ""
			Me.cmdSearch.Text = "&Search"
			Me.txtcode.Focus()
			
		End If
		'ElseIf rsTest.RecordCount > 0 And MStockNew = 2 Then
		'MsgBox "A Table with the Same Name Already Exist", vbApplicationModal + vbOKOnly, "4POS"
		'Me.txtCode.Text = ""
		'Me.cmdClose.SetFocus
		'End If
	End Sub
	
	Private Sub frmStockTakeCSV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 And Me.cmdSearch.Text = "&Search" And Me.txtcode.Text <> "" Then
			cmdsearch_Click(cmdsearch, New System.EventArgs())
		ElseIf KeyAscii = 13 And Me.cmdSearch.Text = "&Add" And Me.txtdesc.Text <> "" Then 
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
        Dim strFldName As String
        Dim strIn As String
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
		
		strIn = "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Quantity > 0;"
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
		strFldName = "HandHeldID Number,Barcodes Text(50),Description Text(50),Quantity Currency"
		cnnDB.Execute("CREATE TABLE " & "Handheld777" & " (" & strFldName & ")")
		System.Windows.Forms.Application.DoEvents()
		
		rj = getRS("SELECT * FROM " & st_Name)
		Do While rj.EOF = False
			
			rs = getRS("SELECT * FROM Handheld777 WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";")
			If rs.RecordCount > 0 Then
				strIn = "UPDATE Handheld777 SET Quantity = " & (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) & " WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";"
			Else
				strIn = "INSERT INTO Handheld777 (HandHeldID,Barcodes,Quantity) VALUES (" & rj.Fields("HandHeldID").Value & ", '" & rj.Fields("Barcodes").Value & "', " & rj.Fields("Quantity").Value & ")"
			End If
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
	
	Private Sub frmStockTakeCSV_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
	End Sub
End Class