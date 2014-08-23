Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmUpdateDayEnd
	Inherits System.Windows.Forms.Form
	Dim gCNT As Short
	Dim gTotal As Short
	
	Private Sub loadLanguage()
		
		'Label1 = No Code   [Updating Report Data...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmUpdateDayEnd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Function buildPath1(ByRef lPath As String) As Boolean
		Dim cat As ADOX.Catalog
		Dim tbl As ADOX.Table
		Dim rs As ADODB.Recordset
        Dim cn As ADODB.Connection = New ADODB.Connection
		Dim lFile As String
		Dim holdfile As String
        Dim lArray As String()
		Dim x As Short
		Dim fso As New Scripting.FileSystemObject
		Dim lDir As String
		cat = New ADOX.Catalog
		tbl = New ADOX.Table
		On Error Resume Next
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		If cnnDBreport Is Nothing Then
		Else
			cat.let_ActiveConnection(cnnDBreport)
			For	Each tbl In cat.Tables
				If tbl.Type = "LINK" Then
					System.Windows.Forms.Application.DoEvents()
					tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & "pricing.mdb" 'Replace(LCase(tbl.Properties("Jet OLEDB:Link Datasource")), LCase("C:\4posServer\"), serverPath)
				End If
			Next tbl
			cat = Nothing
			cn.Close()
			cn = Nothing
			cat = New ADOX.Catalog
		End If
		
		System.Windows.Forms.Application.DoEvents()
		Cursor = System.Windows.Forms.Cursors.Default
		buildPath1 = True
		Exit Function
buildPath_Error: 
		Cursor = System.Windows.Forms.Cursors.Default
		MsgBox(Err.Description)
		buildPath1 = False
	End Function
	
	Private Sub linkTables(ByRef source As String)
		
		Dim cat As ADOX.Catalog
		Dim tbl As ADOX.Table
		Dim fso As New Scripting.FileSystemObject
		If fso.FileExists(serverPath & source & ".mdb") Then
		Else
			Exit Sub
		End If
		
		cat = New ADOX.Catalog
		Dim x As Short
		' Open the catalog.
		cat.let_ActiveConnection(cnnDBreport)
		
		For x = cat.Tables.Count - 1 To 0 Step -1
			Select Case LCase(cat.Tables(x).name)
				Case "acustomertransaction", "adayendstockitemlnk", "adeclaration", "asale", "asaleitem", "asuppliertransaction"
					cat.Tables.delete(cat.Tables(x).name)
			End Select
		Next 
		tbl = New ADOX.Table
		tbl.name = "aCustomerTransaction"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "CustomerTransaction"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.name = "aDayEndStockItemLnk"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.name = "aDeclaration"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Declaration"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		
		tbl = New ADOX.Table
		tbl.name = "aSale"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Sale"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.name = "aSaleItem"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SaleItem"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.name = "aSupplierTransaction"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SupplierTransaction"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		cat.Tables.Refresh()
		
		cat = Nothing
		
		
	End Sub
	
	Private Sub linkFirstTable(ByRef source As String)
		Dim cat As ADOX.Catalog
		Dim tbl As ADOX.Table
		Dim fso As New Scripting.FileSystemObject
		
		On Error GoTo openConnection_linkFirstTable
		
		If fso.FileExists(serverPath & source & ".mdb") Then
		Else
			Exit Sub
		End If
		
		cat = New ADOX.Catalog
		Dim x As Short
		' Open the catalog.
		cat.let_ActiveConnection(cnnDBreport)
		
		For x = cat.Tables.Count - 1 To 0 Step -1
			Select Case LCase(cat.Tables(x).name)
				Case "adayendstockitemlnk"
					cat.Tables.delete(cat.Tables(x).name)
			End Select
		Next 
		tbl = New ADOX.Table
		tbl.name = "aDayEndStockItemLnk"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = serverPath & source & ".mdb"
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		cat.Tables.Refresh()
		cat = Nothing
		Exit Sub
		
withPass: 
		'cat.ActiveConnection("Jet OLEDB:Database Password") = "lqd"
		'Resume Next
		'Exit Sub
		
openConnection_linkFirstTable: 
		'If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
		'    GoTo withPass
		'ElseIf Err.Description = "Not a valid password." Then
		'    GoTo withPass
		'Else
		MsgBox(Err.Number & " - " & Err.Description)
		'End If
	End Sub
	
	Private Sub moveItem()
		gCNT = gCNT + 1
        picInner.Width = twipsToPixels(CShort(pixelToTwips(picOuter.Width, True) / gTotal * gCNT) + 100, True)
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Private Sub beginUpdate()
        Dim gModeReport As Boolean
		
		On Error GoTo Err_beginUpdate
		
		picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		Dim x As Short
		Dim sql As String
		Dim rs As ADODB.Recordset
        Dim rsChk As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lMode As Boolean
		gModeReport = False
		
		If VB.Left(serverPath, 3) = "c:\" Then
		Else
			buildPath1(serverPath)
		End If
		
		Label1.Text = "Loading Report ..."
		'Dim ccndbReport As Connection
        Dim lTable As String()
		Dim y As Short
		lTable = Split("aChannel,aCompany,aConsignment,aCustomer,aDayEnd,aDayEndDepositItemLnk,aDeposit,aftConstruct,aftData,aftDataItem,aftSet,aGRV,aGRVDeposit,aGRVitem,aPackSize,aPayout,aPerson,aPOS,aPricingGroup,aPurchaseOrder,aRecipe,aRecipeStockitemLnk,aSaleItemReciept,aShrink,aStockBreakTransaction,aStockGroup,aStockItem,aStockTakeDetail,Supplier,Vat", ",")
		System.Windows.Forms.Application.DoEvents()
		gTotal = 9 + 1 * 9
		'ccndbReport.Close
		'Set ccndbReport = openConnectionInstance("templatereport.mdb")
		For y = 0 To UBound(lTable)
			moveItem()
			System.Windows.Forms.Application.DoEvents()
			cnnDBreport.Execute("DELETE * FROM " & lTable(y) & ";")
			cnnDBreport.Execute("INSERT INTO " & lTable(y) & " SELECT * FROM " & lTable(y) & "1;")
		Next y
		
		Label1.Text = "Updating Report Data ..."
		picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		
		cnnDBreport.Execute("DELETE * FROM DayEnd")
		cnnDBreport.Execute("INSERT INTO dayend ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT aDayEnd.DayEndID, aDayEnd.DayEnd_MonthEndID, aDayEnd.DayEnd_Date From aDayEnd, Report WHERE (((aDayEnd.DayEndID)>=[Report]![Report_DayEndStartID] And (aDayEnd.DayEndID)<=[Report]![Report_DayEndEndID]));")
		cnnDBreport.Execute("DELETE DayEndStockItemLnkFirst.* FROM DayEndStockItemLnkFirst;")
		'Error in aCompany showing old wrong data if month end is done
		'Set rs = getRSreport("SELECT aDayEnd.*, aCompany.Company_DayEndID, aCompany.Company_MonthEndID From aDayEnd, Report, aCompany WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
		rs = getRSreport("SELECT aDayEnd.*, aCompany1.Company_DayEndID, aCompany1.Company_MonthEndID From aDayEnd, Report, aCompany1 WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
		If rs.RecordCount Then
			If rs.Fields("DayEnd_MonthEndID").Value = rs.Fields("Company_MonthEndID").Value Then
				linkFirstTable("pricing")
			Else
				linkFirstTable("month" & rs.Fields("DayEnd_MonthEndID").Value)
			End If
			cnnDBreport.Execute("INSERT INTO DayEndStockItemLnkFirst SELECT aDayEndStockItemLnk.* FROM Report, aDayEndStockItemLnk INNER JOIN aDayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aDayEnd.DayEndID WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
		End If
		rs.Close()
		
		'Error in aCompany showing old wrong data if month end is done
		'Set rs = getRSreport("SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany.Company_MonthEndID FROM DayEnd, aCompany;")
		rs = getRSreport("SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany1.Company_MonthEndID FROM DayEnd, aCompany1;")
		gTotal = 9 + rs.RecordCount * 9
		moveItem()
		cnnDBreport.Execute("DELETE Payout.* FROM Payout;")
		cnnDBreport.Execute("INSERT INTO Payout SELECT aPayout.* From Report, aPayout WHERE (((aPayout.Payout_DayEndID)>=[Report]![Report_DayEndStartID] And (aPayout.Payout_DayEndID)<=[Report]![Report_DayEndEndID]));")
		moveItem()
		cnnDBreport.Execute("DELETE aStockTakeDetail.* FROM aStockTakeDetail;")
		cnnDBreport.Execute("INSERT INTO aStockTakeDetail SELECT aStockTakeDetail1.* From Report, aStockTakeDetail1 WHERE (((aStockTakeDetail1.StockTake_DayEndID)>=[Report]![Report_DayEndStartID] And (aStockTakeDetail1.StockTake_DayEndID)<=[Report]![Report_DayEndEndID]));")
		moveItem()
		cnnDBreport.Execute("DELETE * FROM DayEndStockItemLnk")
		moveItem()
		cnnDBreport.Execute("DELETE * FROM DayEndDepositItemLnk")
		moveItem()
		cnnDBreport.Execute("DELETE SaleItem.* FROM SaleItem;")
		moveItem()
		
		'consignment setting in report
		cnnDBreport.Execute("DELETE aConsignment.* FROM aConsignment;")
		moveItem()
		
		cnnDBreport.Execute("DELETE Sale.* FROM Sale;")
		moveItem()
		cnnDBreport.Execute("DELETE CustomerTransaction.* FROM CustomerTransaction;")
		moveItem()
		cnnDBreport.Execute("DELETE Declaration.* FROM Declaration;")
		moveItem()
		cnnDBreport.Execute("DELETE SupplierTransaction.* FROM SupplierTransaction;")
		moveItem()
		
		Do Until rs.EOF
			If rs.Fields("DayEnd_MonthEndID").Value = rs.Fields("Company_MonthEndID").Value Then
				linkTables("pricing")
			Else
				linkTables("month" & rs.Fields("DayEnd_MonthEndID").Value)
			End If
			moveItem()
			cnnDBreport.Execute("INSERT INTO DayEndStockItemLnk SELECT aDayEndStockItemLnk.* FROM aDayEndStockItemLnk INNER JOIN DayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID;")
			moveItem()
			On Error Resume Next
			cnnDBreport.Execute("INSERT INTO DayEndDepositItemLnk SELECT aDayEndDepositItemLnk.* FROM aDayEndDepositItemLnk INNER JOIN DayEnd ON aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DayEnd.DayEndID;")
			moveItem()
			If frmMenu.gSuper = True Then
				cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));")
			Else
				If rsChk.State Then rsChk.Close()
				rsChk = getRSreport("SELECT TOP 1 * FROM aSale;")
				If rsChk.Fields.Count < 30 Then
					cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));")
				Else
					cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE ((((aSale.Sale_SaleChk)=False) And (aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));")
				End If
				rsChk.Close()
			End If
			moveItem()
			cnnDBreport.Execute("INSERT INTO SaleItem SELECT aSaleItem.* FROM (aSaleItem INNER JOIN Sale ON aSaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN SaleItem ON aSaleItem.SaleItemID = SaleItem.SaleItemID WHERE (((SaleItem.SaleItemID) Is Null));")
			moveItem()
			
			'consignment setting in report
			cnnDBreport.Execute("INSERT INTO aConsignment SELECT aConsignment1.* FROM aConsignment1;")
			moveItem()
			
			If rs.Fields("DayEnd_MonthEndID").Value = rs.Fields("Company_MonthEndID").Value Then
				cnnDBreport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_MonthEndID)=" & rs.Fields("DayEnd_MonthEndID").Value & ") AND ((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));")
			Else
				cnnDBreport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_MonthEndID)=" & rs.Fields("DayEnd_MonthEndID").Value & ") AND ((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));")
			End If
			moveItem()
			sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference )"
			sql = sql & "SELECT aSupplierTransaction.SupplierTransactionID, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;"
			
			sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) "
			sql = sql & "SELECT [SupplierTransaction_MonthEndID] & [SupplierTransactionID] AS Expr1, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;"
			
			cnnDBreport.Execute(sql)
			moveItem()
			cnnDBreport.Execute("INSERT INTO Declaration SELECT aDeclaration.* From Report, aDeclaration WHERE (((aDeclaration.Declaration_DayEndID)>=[Report]![Report_DayEndStartID] And (aDeclaration.Declaration_DayEndID)<=[Report]![Report_DayEndEndID]));")
			moveItem()
			cnnDBreport.Execute("UPDATE aCompany INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [aStockItem]![StockItem_ListCost]/[aStockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [aStockItem]![StockItem_ActualCost]/[aStockItem]![StockItem_Quantity];")
			moveItem()
			rs.moveNext()
		Loop 
		
		moveItem()
		cnnDBreport.Execute("UPDATE Report SET Report.Report_Type = " & lMode & ";")
		rs = getRSreport("SELECT DayEnd.DayEndID FROM aCompany INNER JOIN DayEnd ON aCompany.Company_DayEndID = DayEnd.DayEndID;")
		If rs.RecordCount Then
			cnnDBreport.Execute("UPDATE Report SET Report.Report_Heading = [Report_Heading] & '(*)';")
			
			cnnDBreport.Execute("UPDATE aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;")
			'Multi Warehouse change
			'cnnDBreport.Execute "UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
			sql = "UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) "
			sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
			cnnDBreport.Execute(sql)
			
			'sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
			'sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
			sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID AND DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
			sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
			cnnDBreport.Execute(sql)
			'Multi Warehouse change
			cnnDBreport.Execute("UPDATE aGRV INNER JOIN ((aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aGRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) AND (aGRV.GRVID = aGRVItem.GRVItem_GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([aGRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((aGRV.GRV_GRVStatusID)=3));")
			
		End If
		
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		
		Exit Sub
Err_beginUpdate: 
		
		MsgBox("Error while Loading Report and Error is :" & Err.Number & " " & Err.Description & " " & Err.Source)
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
	End Sub
	
	Private Sub frmUpdateDayEnd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		picInner.Width = 0
	End Sub
	
	Private Sub tmrStart_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrStart.Tick
		tmrStart.Enabled = False
		beginUpdate()
	End Sub
End Class