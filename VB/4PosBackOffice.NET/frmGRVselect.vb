Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGRVselect
	Inherits System.Windows.Forms.Form
	Dim gMode As Short
	Dim rs As ADODB.Recordset
	Dim HoldGrvID As String
	Dim HoldGrvNo As String
	
	Dim gBrandItem As Integer
	Dim gStockItem As Integer
	Dim newATItem As Boolean

	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1621 'Select GRV Type|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1622 'Imported GRV Data|Checked
        If rsLang.RecordCount Then _Frame1_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1624 'Delete GRV|Checked
		If rsLang.RecordCount Then Frame2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1630 'Load Selecter GRV|Checked
		If rsLang.RecordCount Then cmdEdit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdEdit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1631 'Create a New GRV|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1632 'Import a GRV|Checked
		If rsLang.RecordCount Then cmdImport.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdImport.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdAirTime = No Code   [Air Time GRV]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdAirTime.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAirTime.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1634 'Import GRV Field.......|
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Frame2 = No Code       [Importing Airtime File]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame2.Caption = rsLang("LanguageLayoutLnk_Description"): Frame2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVselect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem()
		doSearch()
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub loadGRV()
		Dim rs As ADODB.Recordset
		Dim listItem As System.Windows.Forms.ListViewItem
		lvImport.Items.Clear()
		rs = getRS("SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID;")
		Do Until rs.EOF
			listItem = Me.lvImport.Items.Add("k" & rs.Fields("stockitemID").Value, rs.Fields("GRVimport_Barcode").Value, "")
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = rs.Fields("StockItem_Name").Value
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_Name").Value))
			End If
            If listItem.SubItems.Count > 2 Then
                listItem.SubItems(2).Text = rs.Fields("Catalogue_Quantity").Value
            Else
                listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("Catalogue_Quantity").Value))
            End If
            If listItem.SubItems.Count > 3 Then
                listItem.SubItems(3).Text = rs.Fields("GRVimport_Quantity").Value
            Else
                listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Quantity").Value))
            End If
            If listItem.SubItems.Count > 4 Then
                listItem.SubItems(4).Text = FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)
            Else
                listItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)))
            End If
            If listItem.SubItems.Count > 5 Then
                listItem.SubItems(5).Text = FormatNumber(rs.Fields("GRVimport_Price").Value, 2)
            Else
                listItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Price").Value, 2)))
            End If
            If listItem.SubItems.Count > 6 Then
                listItem.SubItems(6).Text = rs.Fields("GRVimport_Key").Value
            Else
                listItem.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Key").Value))
            End If
            rs.MoveNext()
        Loop
	End Sub
	
	Private Function getSerialNumber() As String
		Dim FSO As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		Dim fsoDrive As Scripting.Drive
		getSerialNumber = ""
		If FSO.FolderExists(serverPath) Then
			fsoFolder = FSO.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(password)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	Private Function bolSecurityCode() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		
		Dim stPass As String
		Dim givPass As String
		
		On Error GoTo Hell_Error
		
		bolSecurityCode = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					gSecKey = rs.Fields("Company_PosString").Value
					If Len(rs.Fields("Company_PosString").Value) = 13 Then
						bolSecurityCode = True
						Exit Function
					End If
				End If
				
				If IsDbNull(rs.Fields("Company_PosString").Value) Or rs.Fields("Company_PosString").Value = "0" Then
					bolSecurityCode = True
					Exit Function
				End If
				
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					intYear = CShort(VB.Left(rs.Fields("Company_PosString").Value, 2))
					intMonth = CShort(Mid(rs.Fields("Company_PosString").Value, 3, 2))
					intDate = CShort(Mid(rs.Fields("Company_PosString").Value, 5, 2))
					
					If (intDate / 2) = System.Math.Round(intDate / 2) Then
						intDate = intDate / 2
					Else
						Exit Function
					End If
					
					
					If (intMonth / 2) = System.Math.Round(intMonth / 2) Then
						intMonth = intMonth / 2
					Else
						Exit Function
					End If
					
					
					If (intYear / 2) = System.Math.Round(intYear / 2) Then
						intYear = intYear / 2
					Else
						Exit Function
					End If
					
					stPass = "20"
					If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
					If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
					If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
					
					If IsDate(stPass) Then
						If CDate(stPass) >= Today Then
							bolSecurityCode = True
							Exit Function
						End If
					End If
					
					'If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
					'    bolSecurityCode = True
					'    Exit Function
					'Else
					'    Exit Function
					'End If
					
				Else
					Exit Function
				End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
		
		Exit Function
Hell_Error: 
		MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Exclamation)
		Exit Function
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_Code").Value) Then
					gSecKey = rs.Fields("Company_Code").Value
					If Len(rs.Fields("Company_Code").Value) = 13 Then
						
						checkSecurity = True
						Exit Function
					End If
				End If
				lPassword = "pospospospos"
				lCode = getSerialNumber
				If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
					checkSecurity = True
				Else
					leCode = Encrypt(lCode, lPassword)
					For x = 1 To Len(leCode)
						If Asc(Mid(leCode, x, 1)) < 33 Then
							leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
						End If
					Next x
					
					If rs.Fields("Company_Code").Value = leCode Then
						'If IsNull(rs("Company_TerminateDate")) Then
						checkSecurity = True
						'Else
						'    If Date > rs("Company_TerminateDate") Then
						'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						'        checkSecurity = False
						Exit Function
						'   End If
						'End If
					Else
						'txtCompany.Text = rs("Company_Name")
						'txtCompany.SelStart = 0
						'txtCompany.SelLength = 999
						'show 1
					End If
					
				End If
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
	
	Private Sub loadAirtimeCSV(ByRef csvBarcode As String, ByRef csvPRG As String, ByRef csvDESC As String, ByRef csvSell As Decimal, ByRef csvCost As Decimal, ByRef csvSTG_RPG As String, ByRef csvVAT As String)
        Dim sql As String
		
		
		System.Windows.Forms.Application.DoEvents()
		gStockItem = 0
		gBrandItem = 0
		
		Dim rsSupp As ADODB.Recordset
		Dim rsDep As ADODB.Recordset
		Dim rsPriceG As ADODB.Recordset
		Dim rsStockG As ADODB.Recordset
		Dim rsReportG As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim aCost As Decimal
		
		'Set rs = getRS("SELECT StockItemID FROM StockItem WHERE StockItem_Name = '" & Replace(ManuName(ManufactureId) & " - " & Description, "'", "''") & "'")
		'If rs.RecordCount > 0 Then
		'Else
		rsDep = getRS("SELECT DepositID AS DepositIDs FROM Deposit WHERE Deposit_Name = 'Non' OR Deposit_Name = 'No Deposit' OR Deposit_Name = 'NON'")
		If rsDep.RecordCount > 0 Then
		Else
			'rsDep.Close
			'Set rsDep = Nothing
			rsDep = getRS("SELECT MIN(DepositID) AS DepositIDs  FROM Deposit;")
			If rsDep.RecordCount > 0 Then
				
			End If
			'MsgBox "Setup Deposit with 'Non' Title"
			'Exit Sub
			'cnnDB.Execute "INSERT INTO PricingGroup ( PricingGroup_Name, PricingGroup_Code, PricingGroup_RemoveCents, PricingGroup_RoundAfter, PricingGroup_RoundDown, PricingGroup_Unit1, PricingGroup_Case1, PricingGroup_Unit2, PricingGroup_Case2, PricingGroup_Unit3, PricingGroup_Case3, PricingGroup_Unit4, PricingGroup_Case4, PricingGroup_Unit5, PricingGroup_Case5, PricingGroup_Unit6, PricingGroup_Case6, PricingGroup_Unit7, PricingGroup_Case7, PricingGroup_Unit8, PricingGroup_Case8 ) VALUES ('AirTime_CES', '0', 1, 39, 19.99, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20)"
			'Set rsDep = getRS("SELECT MAX(DepositID) FROM Deposit")
		End If
		
		rsPriceG = getRS("SELECT PricingGroupID FROM PricingGroup WHERE PricingGroup_Name = '" & csvPRG & "'")
		If rsPriceG.RecordCount > 0 Then
		Else
			rsPriceG.Close()
			rsPriceG = Nothing
			
			cnnDB.Execute("INSERT INTO PricingGroup ( PricingGroup_Name, PricingGroup_Code, PricingGroup_RemoveCents, PricingGroup_RoundAfter, PricingGroup_RoundDown, PricingGroup_Unit1, PricingGroup_Case1, PricingGroup_Unit2, PricingGroup_Case2, PricingGroup_Unit3, PricingGroup_Case3, PricingGroup_Unit4, PricingGroup_Case4, PricingGroup_Unit5, PricingGroup_Case5, PricingGroup_Unit6, PricingGroup_Case6, PricingGroup_Unit7, PricingGroup_Case7, PricingGroup_Unit8, PricingGroup_Case8 ) VALUES ('" & csvPRG & "', '0', 1, 39, 19.99, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20)")
			rsPriceG = getRS("SELECT MAX(PricingGroupID) FROM PricingGroup")
		End If
		
		rsStockG = getRS("SELECT StockGroupID FROM StockGroup WHERE StockGroup_Name = '" & csvSTG_RPG & "'")
		If rsStockG.RecordCount > 0 Then
		Else
			rsStockG.Close()
			rsStockG = Nothing
			
			cnnDB.Execute("INSERT INTO StockGroup ( StockGroup_Name, StockGroup_Disabled ) VALUES ('" & csvSTG_RPG & "',0)")
			rsStockG = getRS("SELECT MAX(StockGroupID) FROM StockGroup")
		End If
		
		rsReportG = getRS("SELECT ReportID FROM ReportGroup WHERE ReportGroup_Name = '" & csvSTG_RPG & "'")
		If rsReportG.RecordCount > 0 Then
		Else
			rsReportG.Close()
			rsReportG = Nothing
			
			cnnDB.Execute("INSERT INTO ReportGroup ( ReportGroup_Name ) VALUES ('" & csvSTG_RPG & "')")
			rsReportG = getRS("SELECT MAX(ReportID) FROM ReportGroup")
		End If
		
		'aCost = (RetailPrice / 1.04)
		'aCost = (aCost / 1.14)
		aCost = csvCost
		sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey, StockItem_NegSale, StockItem_PrintLocationID, StockItem_SerialTracker, StockItem_ReportID, StockItem_ATItem, StockItem_ATStockTypeID) VALUES ("
		sql = sql & gBrandItem & ", " & 2 & ", " & 1 & ", " & 1 & ", " & rsPriceG.Fields(0).Value & ", " & rsStockG.Fields(0).Value & ", 2, " & rsDep.Fields(0).Value & ", '" & csvDESC & "', '" & csvDESC & "', " & Replace(CStr(1), ",", "") & ", " & Replace(CStr(aCost), ",", "") & ", " & Replace(CStr(aCost), ",", "") & ", 0, 0, " & CDec(1) & ", 1, 0, 0, 0, '" & csvBarcode & "', True, 1, True, " & rsReportG.Fields(0).Value & ", True, 0)"
		Debug.Print(sql)
		cnnDB.Execute(sql)
		
		sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;"
		rs = getRS(sql)
		gStockItem = rs.Fields("id").Value
		cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		'Multi Warehouse change     cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & ", " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & " FROM Company;"
		cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & csvCost & ", " & csvCost & ", Warehouse.WarehouseID FROM Company, Warehouse;")
		cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " & gStockItem & ", 0 FROM Warehouse;")
		
		cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" & gStockItem & ")")
		
		cnnDB.Execute("INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & buildItemBarcode(gStockItem, 1) & "')")
		
		'buildBarcodes gStockItem
		'If gBrandItem Then
		'   cnnDB.Execute "UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" & gStockItem & "));"
		'End If
		
		'cnnDB.Execute "UPDATE Catalogue Set Catalogue_Barcode = '" & sBarCode & "' WHERE Catalogue_Quantity = " & 1 & " AND Catalogue_StockItemID =" & rs.Fields(0) & ";"
		'Set rt = getRS("SELECT * FROM PriceChannelLnk WHERE PriceChannelLnk_StockItemID = " & rs.Fields(0) & " AND PriceChannelLnk_Quantity = " & 1 & ";")
		'If rt.RecordCount Then
		'Else
		cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) VALUES (" & gStockItem & "," & 1 & ",1," & csvSell & ")")
		cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & csvSell & " WHERE PriceChannelLnk_StockItemID = " & gStockItem & ";")
		'End If
		newATItem = True
		'gStockItem = 0
		'gBrandItem = 0
		'loadProducts
        'End If
        Dim form As frmUpdateCatalogue
        form.Show()
	End Sub
	
	Private Sub CreateAirtimeBC(ByRef csvATFile As String)
		Dim strSvrName As String
		Dim ATrs As New ADODB.Recordset
		Dim csvSplit() As String
		Dim csvLine As String
		Dim csvRows As Integer
		Dim rsCat As ADODB.Recordset
		
		Dim vValue As String
        Dim hkey As Integer
		Dim lRetVal As Integer
		If checkSecurity = True Then
			'for Security Code
			If bolSecurityCode = True Then
				'loadCustom
				FileOpen(8, csvATFile, OpenMode.Input)
				csvRows = 0
				While Not (EOF(8))
					csvLine = LineInput(8)
					If Len(csvLine) > 0 Then
						If VB.Left(csvLine, 3) = "PLU" Then
						Else
							csvSplit = Split(csvLine, ",")
							rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(csvSplit(0), 5) & "'")
							If rsCat.RecordCount = 0 Then
								'FROM QUICK KEY
								rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(csvSplit(0), 5) & "');")
								If rsCat.RecordCount = 0 Then
									loadAirtimeCSV(csvSplit(0), csvSplit(1), csvSplit(2), CDec(csvSplit(3)), CDec(csvSplit(4)), csvSplit(6), csvSplit(7))
									If gStockItem <> 0 Then
										cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & CDec(csvSplit(3)) & " WHERE PriceChannelLnk_StockItemID = " & gStockItem & ";")
										'MsgBox gStockItem & " " & CCur(csvSplit(3))
									End If
								End If
							End If
						End If
					End If
					csvRows = csvRows + 1
				End While
				FileClose(8)
				
			Else
				MsgBox("New Stock Items cannot be added due to Security Restrictions." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired")
				Exit Sub
			End If
			'for Security Code
		Else
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				'check advance date expiry system
				On Error Resume Next
				vValue = ""
				lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_QUERY_VALUE, hkey)
				lRetVal = QueryValueEx(hkey, "ShellClass", vValue)
				RegCloseKey(hkey)
				If vValue = "" Then
					vValue = "0"
				Else
					If vValue <> "0" Then vValue = CStr(CDate("&H" & vValue))
				End If
				
				'If IsNull(rs("Company_TerminateDate")) Then
				'    cnnDB.Execute "UPDATE Company SET Company_TerminateDate = #" & Date & "#;"
				'    Set rs = getRS("SELECT * From Company")
				'End If
				If IsDbNull(rs.Fields("Company_TerminateDate").Value) And vValue = "0" Then
					cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
					lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
					lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
					SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
					RegCloseKey(hkey)
					rs = getRS("SELECT * From Company")
				Else
					If IsDbNull(rs.Fields("Company_TerminateDate").Value) And vValue <> "0" Then
						'db date tempered
						If posDemo = True Then
							cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
							lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
							lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
							SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
							RegCloseKey(hkey)
						Else
							cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.Date.FromOADate(Today.ToOADate - 20)) & "#;")
							MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
							End
						End If
					End If
					
					If IsDbNull(rs.Fields("Company_TerminateDate").Value) Then
					Else
						If rs.Fields("Company_TerminateDate").Value > Today Then
							'db date tempered
							cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.Date.FromOADate(Today.ToOADate - 20)) & "#;")
							MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
							End
						End If
					End If
					
					'If (Date + 2) > rs("Company_TerminateDate") Then
					'    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
					'    checkSecurity = False
					'   Exit Function
					'End If
				End If
				
				If Today >= CDate(rs.Fields("Company_TerminateDate").Value + 30) Then
					MsgBox("New Stock Items may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired")
					Exit Sub
				Else
					'loadCustom
					FileOpen(8, csvATFile, OpenMode.Input)
					csvRows = 0
					While Not (EOF(8))
						csvLine = LineInput(8)
						If Len(csvLine) > 0 Then
							If VB.Left(csvLine, 3) = "PLU" Then
							Else
								csvSplit = Split(csvLine, ",")
								rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(csvSplit(0), 5) & "'")
								If rsCat.RecordCount = 0 Then
									'FROM QUICK KEY
									rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(csvSplit(0), 5) & "');")
									If rsCat.RecordCount = 0 Then
										loadAirtimeCSV(csvSplit(0), csvSplit(1), csvSplit(2), CDec(csvSplit(3)), CDec(csvSplit(4)), csvSplit(6), csvSplit(7))
										If gStockItem <> 0 Then
											cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & CDec(csvSplit(3)) & " WHERE PriceChannelLnk_StockItemID = " & gStockItem & ";")
											'MsgBox gStockItem & " " & CCur(csvSplit(3))
										End If
									End If
								End If
							End If
						End If
						csvRows = csvRows + 1
					End While
					FileClose(8)
				End If
				'End If
			End If
		End If
		'frmUpdateCatalogue.show 1, Me
		MsgBox("All Airtime Items activated/updated. Now system will do GRV.")
	End Sub
	
	Private Sub cmdAirTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAirTime.Click
        Dim sql As String
        Dim strIn As String
        Dim Pin As String
        Dim Serial As String
		Dim lString As String
        Dim lData As String()
        Dim lFields As String()
		Dim FSO As New Scripting.FileSystemObject
		Dim lTextstream As Scripting.TextStream
		Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		Dim rsCat As ADODB.Recordset
		'Dim lListitem As listItem
		On Error GoTo loadGRV_Error
		
		Dim sSplit() As String
		Dim sLine As String
		Dim lRows As Integer
		Dim lRowsIN As Integer
		Dim iPOId As Integer
		Dim iSuppId As Integer
		Dim rsID As ADODB.Recordset
		Dim rsChk As ADODB.Recordset
		Dim errPosition As String
		
		CDOpen.ShowDialog()
		lString = CDOpen.FileName
		'lvImport.ListItems.Clear
		If lString = "" Then
			'Unload Me
			Exit Sub
		Else
			cnnDB.Execute("DELETE * from StockTransferGRV;")
			If FSO.FileExists(lString) Then
				
				Frame2.Visible = True
				cmdAirTime.Enabled = False
				
				'Validating serials file
				FileOpen(7, lString, OpenMode.Input)
				lRows = 0
				lRowsIN = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						If VB.Left(sLine, 2) = "D|" Then
							
							sSplit = Split(sLine, "|")
							RSitem = getRS("Select * from Serialtracking where serial_serialnumber = '" & sSplit(7) & "'")
							If RSitem.RecordCount Then
								'a = 1
								Debug.Print(Serial)
								Debug.Print(Pin)
							Else
validateAgain: 
								rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(sSplit(1), 5) & "'")
								If rsCat.RecordCount = 0 Then
									'MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
									'FROM QUICK KEY
									rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(sSplit(1), 5) & "');")
									'SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
									If rsCat.RecordCount = 0 Then
										MsgBox("Barcode or Quick key not found for '" & VB.Left(sSplit(1), 5) & "'. Process will now Create/Update airtime item(s).")
										'Fire external utility
										If FSO.FileExists("c:\4POSServer\4AIRItems.csv") Then
											newATItem = False
											CreateAirtimeBC("c:\4POSServer\4AIRItems.csv")
											If newATItem = True Then
												GoTo validateAgain
											Else
												MsgBox("Could not Create Airtime item. Process will stop now. Please make sure you have latest Airtime CSV file in place.")
												Exit Sub
											End If
										Else
											MsgBox("Could not find file '" & serverPath & "4AIRItems.csv'. Process will stop now. Please make sure you have latest Airtime CSV file in place.")
											Exit Sub
										End If
									Else
										'cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
										'Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";")
										'If rs.RecordCount > 0 Then
										'    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";"
										'Else
										'    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
										''            "(" & rsCat("StockItemID") & ", 1, 1, 1)"
										'End If
										'DoEvents
										'cnnDB.Execute strIn
										'Debug.Print strIn
										'DoEvents
										'lRows = lRows + 1
									End If
								Else
									
									'FROM BARCODE
									'cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("catalogue_StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
									'Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";")
									'If rs.RecordCount > 0 Then
									'    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";"
									'Else
									'    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
									''            "(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
									'End If
									'DoEvents
									'cnnDB.Execute strIn
									'Debug.Print strIn
									'DoEvents
									'lRows = lRows + 1
								End If
							End If
							lRowsIN = lRowsIN + 1
						End If
					End If
				End While
				FileClose(7)
				
				
				prgBar.Maximum = lRowsIN
				prgBar.Value = 0
				
				'Importing serials file
				FileOpen(7, lString, OpenMode.Input)
				lRows = 0
				lRowsIN = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						If VB.Left(sLine, 2) = "D|" Then
							
							If prgBar.Value = prgBar.Maximum Then
								System.Windows.Forms.Application.DoEvents()
								prgBar.Value = 0
							Else
								prgBar.Value = prgBar.Value + 1
								System.Windows.Forms.Application.DoEvents()
							End If
							
							sSplit = Split(sLine, "|")
							RSitem = getRS("Select * from Serialtracking where serial_serialnumber = '" & sSplit(7) & "'")
							If RSitem.RecordCount Then
								'a = 1
								Debug.Print(sSplit(7))
								Debug.Print(sSplit(8))
							Else
								rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(sSplit(1), 5) & "'")
								If rsCat.RecordCount = 0 Then
									'MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
									'FROM QUICK KEY
									rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(sSplit(1), 5) & "');")
									'SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
									If rsCat.RecordCount = 0 Then
										MsgBox("Barcode or Quick key not found for '" & VB.Left(sSplit(1), 5) & "'")
									Else
										
										cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" & rsCat.Fields("StockItemID").Value & "));")
										cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat.Fields("StockItemID").Value & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')")
										If sSplit(2) = "" Then
											sSplit(2) = CStr(1)
										Else
											sSplit(2) = CStr(CDbl(sSplit(2)) / 1.14)
										End If
										rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat.Fields("StockItemID").Value & ";")
										If rs.RecordCount > 0 Then
											strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs.Fields("StockTransfer_Quantity").Value + 1 & " WHERE StockTransfer_StockItemID = " & rsCat.Fields("StockItemID").Value & ";"
										Else
											strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & "(" & rsCat.Fields("StockItemID").Value & ", 1, " & IIf(sSplit(2) = "", 1, sSplit(2)) & ", 1)"
											' "(" & rsCat("StockItemID") & ", 1, 1, 1)"
										End If
										System.Windows.Forms.Application.DoEvents()
										cnnDB.Execute(strIn)
										Debug.Print(strIn)
										System.Windows.Forms.Application.DoEvents()
										lRows = lRows + 1
									End If
								Else
									
									'FROM BARCODE
									cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" & rsCat.Fields("catalogue_StockItemID").Value & "));")
									cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat.Fields("catalogue_StockItemID").Value & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')")
									If sSplit(2) = "" Then
										sSplit(2) = CStr(1)
									Else
										sSplit(2) = CStr(CDbl(sSplit(2)) / 1.14)
									End If
									rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat.Fields("catalogue_StockItemID").Value & ";")
									If rs.RecordCount > 0 Then
										strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs.Fields("StockTransfer_Quantity").Value + 1 & " WHERE StockTransfer_StockItemID = " & rsCat.Fields("catalogue_StockItemID").Value & ";"
									Else
										strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & "(" & rsCat.Fields("catalogue_StockItemID").Value & ", 1, " & IIf(sSplit(2) = "", 1, sSplit(2)) & ", 1)"
										'"(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
									End If
									System.Windows.Forms.Application.DoEvents()
									cnnDB.Execute(strIn)
									Debug.Print(strIn)
									System.Windows.Forms.Application.DoEvents()
									lRows = lRows + 1
								End If
							End If
							lRowsIN = lRowsIN + 1
						End If
					End If
				End While
				FileClose(7)
				
				errPosition = "Start"
				'Create GRV
				rs = getRS("SELECT * FROM StockTransferGRV;")
				If rs.RecordCount > 0 Then
					If lRowsIN <> lRows Then
						MsgBox("Total serials imported " & lRows & " out of " & lRowsIN & " in file")
					End If
					
					iSuppId = 2
					rsID = getRS("SELECT SupplierID FROM Supplier WHERE Supplier_Name = '4AIR';")
					If rsID.RecordCount Then
						iSuppId = rsID.Fields("SupplierID").Value
					End If
					
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
					sql = sql & "SELECT " & iSuppId & ", Company.Company_DayEndID, " & frmMenu.lblUser.Tag & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Blind)', '' FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					errPosition = "2"
					rsID = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
					iPOId = rsID.Fields("id").Value
					sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					If rsID.State Then rsID.Close()
					rsID = getRS("SELECT Max(GRV.GRVID) AS id FROM GRV;")
					
					x = 1
					rs = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					Do Until rs.EOF
						errPosition = "3"
						rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						If rsChk.RecordCount Then
							
							errPosition = "4"
							'sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							'sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity,     StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							Debug.Print(sql)
							cnnDB.Execute(sql)
						Else
							
							errPosition = "5"
							If rs.Fields("StockTransfer_Pack").Value = 1 Then
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							Else
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							End If
							Debug.Print(sql)
							cnnDB.Execute(sql)
						End If
						
						sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & "));"
						cnnDB.Execute(sql)
						
						x = x + 1
						rs.moveNext()
					Loop 
					
					doSearch()
					
					Frame2.Visible = False
					
					bolAirTimeGRV = True
					strAirTimeFile = lString
					frmGRV.Create(iPOId)
					Me.Close()
				Else
					MsgBox("No Airtime serials have been imported, please verify that the file wasn't imported already!")
				End If
			End If
		End If
		Exit Sub
		
		cmdAirTime.Enabled = True
loadGRV_Error: 
		MsgBox(Err.Description)
		'Unload Me
		Resume Next
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        Dim grvdelete As MsgBoxResult
		'*
		On Error Resume Next
		Dim sqlstr As String
		Dim sql As String
		Dim sqlpur As String
		
		
		'* Delete the selected GRV.
		
		sqlstr = "DELETE * FROM GRV WHERE GRV.GRVID =" & HoldGrvID
		sql = "DELETE * FROM GRVItem WHERE GRVItem_GRVID =" & HoldGrvID
		sqlpur = "DELETE * FROM PurchaseOrder WHERE PurchaseOrderID =" & HoldGrvID
		
		
        grvdelete = MsgBox("Are you sure you wish to delete the selected GRV", MsgBoxStyle.YesNoCancel)
        If grvdelete = MsgBoxResult.Yes Then
            cnnDB.Execute(sql)
            cnnDB.Execute(sqlstr)
            cnnDB.Execute(sqlpur)

            'MsgBox ("GRV Deleted")
            cmdExit_Click(cmdExit, New System.EventArgs())
            doSearch()
            lvImport.Refresh()
            'frmGRVselect.Refresh
            HoldGrvID = ""

            loadLanguage()
            ShowDialog()

        ElseIf grvdelete = MsgBoxResult.No Then
        ElseIf grvdelete = MsgBoxResult.Cancel Then
        End If

            '*
    End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		If Me.lvImport.FocusedItem Is Nothing Then
		Else
			frmGRV.Create(CInt(Mid(Me.lvImport.FocusedItem.Name, 2)))
			Me.Close()
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImport.Click
		Me.Close()
		On Error Resume Next
		frmGRVimport.ShowDialog()
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Me.Close()
		frmGRVblind.ShowDialog()
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		Dim listItem As System.Windows.Forms.ListViewItem
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = " AND (Supplier_Name LIKE '%" & Replace(lString, " ", "%' AND Supplier_Name LIKE '%") & "%')"
		End If
		
		'    Set grs = getRS("SELECT PurchaseOrder.PurchaseOrderID, [Supplier_Name] & '(' & [PurchaseOrder_Reference] & ')' AS name FROM (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0  AND Supplier_Disabled = 0 " & lstring & " ORDER BY Supplier.Supplier_Name;")
		rs = getRS("SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " & lString & " ORDER BY Supplier.Supplier_Name;")
		On Error Resume Next
		lvImport.Items.Clear()
		Do Until rs.EOF
			listItem = Me.lvImport.Items.Add("k" & rs.Fields("PurchaseOrderID").Value, rs.Fields("Supplier_Name").Value, "")
			cmdDelete.Enabled = True
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = Format(rs.Fields("PurchaseOrder_DateCreated").Value, "yyyy mmm dd")
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs.Fields("PurchaseOrder_DateCreated").Value, "yyyy mmm dd")))
			End If
			If listItem.SubItems.Count > 2 Then
				listItem.SubItems(2).Text = rs.Fields("PurchaseOrder_Reference").Value
			Else
				listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("PurchaseOrder_Reference").Value))
			End If
			If IsDbNull(rs.Fields("GRV_InvoiceInclusive").Value) Then
			Else
				If listItem.SubItems.Count > 3 Then
					listItem.SubItems(3).Text = rs.Fields("GRV_InvoiceNumber").Value
				Else
					listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRV_InvoiceNumber").Value))
				End If
				If listItem.SubItems.Count > 4 Then
					listItem.SubItems(4).Text = FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)
				Else
					listItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)))
				End If
			End If
			rs.moveNext()
		Loop 
		
		
	End Sub
	
	
	Private Sub cmdNewFnV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewFnV.Click
		bolFNVegGRV = True
		Me.Close()
		frmGRVblind.ShowDialog()
	End Sub
	
	Private Sub cmdVoucher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVoucher.Click
        Dim sql As String
        Dim strIn As String
        Dim Pin As String
        Dim Serial As String
		Dim lString As String
        Dim lData As String()
        Dim lFields As String()
		Dim FSO As New Scripting.FileSystemObject
		Dim lTextstream As Scripting.TextStream
		Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		Dim rsCat As ADODB.Recordset
		'Dim lListitem As listItem
		On Error GoTo loadGRV_Error
		
		Dim sSplit() As String
		Dim sLine As String
		Dim lRows As Integer
		Dim lRowsIN As Integer
		Dim iPOId As Integer
		Dim iSuppId As Integer
		Dim rsID As ADODB.Recordset
		Dim rsChk As ADODB.Recordset
		Dim errPosition As String
		
		CDOpen.ShowDialog()
		lString = CDOpen.FileName
		'lvImport.ListItems.Clear
		If lString = "" Then
			'Unload Me
			Exit Sub
		Else
			cnnDB.Execute("DELETE * from StockTransferGRV;")
			If FSO.FileExists(lString) Then
				
				Frame2.Visible = True
				cmdAirTime.Enabled = False
				
				'Validating serials file
				FileOpen(7, lString, OpenMode.Input)
				lRows = 0
				lRowsIN = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						If VB.Left(sLine, 2) = "D|" Then
							
							sSplit = Split(sLine, "|")
							RSitem = getRS("Select * from Serialtracking where serial_serialnumber = '" & sSplit(7) & "'")
							If RSitem.RecordCount Then
								'a = 1
								Debug.Print(Serial)
								Debug.Print(Pin)
							Else
validateAgain: 
								rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(sSplit(1), 5) & "'")
								If rsCat.RecordCount = 0 Then
									'MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
									'FROM QUICK KEY
									rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(sSplit(1), 5) & "');")
									'SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
									If rsCat.RecordCount = 0 Then
										MsgBox("Barcode or Quick key not found for '" & VB.Left(sSplit(1), 5) & "'. Process will stop now. Please Configure 4POS Voucher item correctly.")
										'Fire external utility
										'If fso.FileExists("c:\4POSServer\4AIRItems.csv") Then
										'    newATItem = False
										'    CreateAirtimeBC "c:\4POSServer\4AIRItems.csv"
										'    If newATItem = True Then
										'        GoTo validateAgain
										'    Else
										'        MsgBox "Could not Create Airtime item. Process will stop now. Please make sure you have latest Airtime CSV file in place."
										'        Exit Sub
										'    End If
										'Else
										'    MsgBox "Could not find file '" & serverPath & "4AIRItems.csv'. Process will stop now. Please make sure you have latest Airtime CSV file in place."
										Exit Sub
										'End If
									Else
										'cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
										'Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";")
										'If rs.RecordCount > 0 Then
										'    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";"
										'Else
										'    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
										''            "(" & rsCat("StockItemID") & ", 1, 1, 1)"
										'End If
										'DoEvents
										'cnnDB.Execute strIn
										'Debug.Print strIn
										'DoEvents
										'lRows = lRows + 1
									End If
								Else
									
									'FROM BARCODE
									'cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("catalogue_StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
									'Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";")
									'If rs.RecordCount > 0 Then
									'    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";"
									'Else
									'    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
									''            "(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
									'End If
									'DoEvents
									'cnnDB.Execute strIn
									'Debug.Print strIn
									'DoEvents
									'lRows = lRows + 1
								End If
							End If
							lRowsIN = lRowsIN + 1
						End If
					End If
				End While
				FileClose(7)
				
				
				prgBar.Maximum = lRowsIN
				prgBar.Value = 0
				
				'Importing serials file
				FileOpen(7, lString, OpenMode.Input)
				lRows = 0
				lRowsIN = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						If VB.Left(sLine, 2) = "D|" Then
							
							If prgBar.Value = prgBar.Maximum Then
								System.Windows.Forms.Application.DoEvents()
								prgBar.Value = 0
							Else
								prgBar.Value = prgBar.Value + 1
								System.Windows.Forms.Application.DoEvents()
							End If
							
							sSplit = Split(sLine, "|")
							RSitem = getRS("Select * from Serialtracking where serial_serialnumber = '" & sSplit(7) & "'")
							If RSitem.RecordCount Then
								'a = 1
								Debug.Print(sSplit(7))
								Debug.Print(sSplit(8))
							Else
								rsCat = getRS("Select * from Catalogue where Catalogue_Barcode = '" & VB.Left(sSplit(1), 5) & "'")
								If rsCat.RecordCount = 0 Then
									'MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
									'FROM QUICK KEY
									rsCat = getRS("SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" & VB.Left(sSplit(1), 5) & "');")
									'SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
									If rsCat.RecordCount = 0 Then
										MsgBox("Barcode or Quick key not found for '" & VB.Left(sSplit(1), 5) & "'")
									Else
										
										cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" & rsCat.Fields("StockItemID").Value & "));")
										cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat.Fields("StockItemID").Value & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')")
										If sSplit(2) = "" Then
											sSplit(2) = CStr(1)
										Else
											sSplit(2) = CStr(CDbl(sSplit(2)) / 1.14)
										End If
										rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat.Fields("StockItemID").Value & ";")
										If rs.RecordCount > 0 Then
											strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs.Fields("StockTransfer_Quantity").Value + 1 & " WHERE StockTransfer_StockItemID = " & rsCat.Fields("StockItemID").Value & ";"
										Else
											strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & "(" & rsCat.Fields("StockItemID").Value & ", 1, " & IIf(sSplit(2) = "", 1, sSplit(2)) & ", 1)"
											' "(" & rsCat("StockItemID") & ", 1, 1, 1)"
										End If
										System.Windows.Forms.Application.DoEvents()
										cnnDB.Execute(strIn)
										Debug.Print(strIn)
										System.Windows.Forms.Application.DoEvents()
										lRows = lRows + 1
									End If
								Else
									
									'FROM BARCODE
									cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" & rsCat.Fields("catalogue_StockItemID").Value & "));")
									cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat.Fields("catalogue_StockItemID").Value & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')")
									If sSplit(2) = "" Then
										sSplit(2) = CStr(1)
									Else
										sSplit(2) = CStr(CDbl(sSplit(2)) / 1.14)
									End If
									rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat.Fields("catalogue_StockItemID").Value & ";")
									If rs.RecordCount > 0 Then
										strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs.Fields("StockTransfer_Quantity").Value + 1 & " WHERE StockTransfer_StockItemID = " & rsCat.Fields("catalogue_StockItemID").Value & ";"
									Else
										strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & "(" & rsCat.Fields("catalogue_StockItemID").Value & ", 1, " & IIf(sSplit(2) = "", 1, sSplit(2)) & ", 1)"
										'"(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
									End If
									System.Windows.Forms.Application.DoEvents()
									cnnDB.Execute(strIn)
									Debug.Print(strIn)
									System.Windows.Forms.Application.DoEvents()
									lRows = lRows + 1
								End If
							End If
							lRowsIN = lRowsIN + 1
						End If
					End If
				End While
				FileClose(7)
				
				errPosition = "Start"
				'Create GRV
				rs = getRS("SELECT * FROM StockTransferGRV;")
				If rs.RecordCount > 0 Then
					If lRowsIN <> lRows Then
						MsgBox("Total serials imported " & lRows & " out of " & lRowsIN & " in file")
					End If
					
					iSuppId = 2
					rsID = getRS("SELECT SupplierID FROM Supplier WHERE Supplier_Name = '4POS SOFTWARE';")
					If rsID.RecordCount Then
						iSuppId = rsID.Fields("SupplierID").Value
					End If
					
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
					sql = sql & "SELECT " & iSuppId & ", Company.Company_DayEndID, " & frmMenu.lblUser.Tag & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Blind)', '' FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					errPosition = "2"
					rsID = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
					iPOId = rsID.Fields("id").Value
					sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					If rsID.State Then rsID.Close()
					rsID = getRS("SELECT Max(GRV.GRVID) AS id FROM GRV;")
					
					x = 1
					rs = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					Do Until rs.EOF
						errPosition = "3"
						rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						If rsChk.RecordCount Then
							
							errPosition = "4"
							'sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							'sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity,     StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							Debug.Print(sql)
							cnnDB.Execute(sql)
						Else
							
							errPosition = "5"
							If rs.Fields("StockTransfer_Pack").Value = 1 Then
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							Else
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							End If
							Debug.Print(sql)
							cnnDB.Execute(sql)
						End If
						
						sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & "));"
						cnnDB.Execute(sql)
						
						x = x + 1
						rs.moveNext()
					Loop 
					
					doSearch()
					
					Frame2.Visible = False
					
					bolAirTimeGRV = True
					strAirTimeFile = lString
					frmGRV.Create(iPOId,  , True)
					Me.Close()
				Else
					MsgBox("No Vouchers have been imported, please verify that the file wasn't imported already!")
				End If
			End If
		End If
		Exit Sub
		
		cmdAirTime.Enabled = True
loadGRV_Error: 
		MsgBox(Err.Description)
		'Unload Me
		Resume Next
	End Sub
	
	Private Sub frmGRVselect_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cmdDelete.Enabled = False
		bolAirTimeGRV = False
		strAirTimeFile = ""
		
		'4POS Voucher
		Dim rsVoucher As ADODB.Recordset
		rsVoucher = getRS("SELECT Company_Name FROM Company")
		If rsVoucher.RecordCount Then
			If LCase(rsVoucher.Fields("Company_Name").Value) = "compupos" Then
				cmdVoucher.Visible = True
			End If
		End If
		'4POS Voucher
	End Sub
	
	Private Sub frmGRVselect_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		bolAirTimeGRV = False
		strAirTimeFile = ""
	End Sub
	
	Private Sub lvImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvImport.Click
		'*Get the following fields
		On Error Resume Next
		rs = getRS("SELECT GRV.GRVID,GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive,GRVItem.GRVItem_GRVID FROM ((GRV INNER JOIN GRVItem ON GRV.GRVID=GRVItem.GRVItem_GRVID))")
		
		'*Get the GRVID of the select GRV,Remove letter K from It and hold it.
		HoldGrvID = Split(lvImport.FocusedItem.Name, "_")(0)
		HoldGrvID = Mid(HoldGrvID, 2)
		
		'Set rs = getRS("SELECT GRV_InvoiceNumber FROM GRV WHERE GRVID=" & HoldGrvID)
		'HoldGrvNo = rs("GRV_InvoiceNumber")
		
		'HoldName = lvImport.SelectedItem
	End Sub
	
	Private Sub lvImport_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvImport.DoubleClick
		cmdEdit_Click(cmdEdit, New System.EventArgs())
	End Sub
	
	Private Sub lvImport_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvImport.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'* Cater for the delete button to delete a GRV in the listbox
		If KeyCode = 46 Then cmdDelete_Click(cmdDelete, New System.EventArgs())
	End Sub
	
	Private Sub lvImport_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvImport.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then cmdEdit_Click(cmdEdit, New System.EventArgs())
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class