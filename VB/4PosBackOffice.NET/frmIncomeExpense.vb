Option Strict Off
Option Explicit On
Friend Class frmIncomeExpense
	Inherits System.Windows.Forms.Form
	Dim gMonth As Integer
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1267 'Income and Expense Report|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl = No Code      [Select the Month-end Period for the Report]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl.Caption = rsLang("LanguageLayoutLnk_Description"): lbl.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmIncomeExpense.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Dim sql As String
		Dim lConn As ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim rsPurchase As ADODB.Recordset
		Dim rsSales As ADODB.Recordset
		Dim rsStock As ADODB.Recordset
		Dim rsCompany As ADODB.Recordset
        'Dim Report As New cryIncomeExpense
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryIncomeExpense.rpt")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		If cmbMonthEnd.SelectedIndex Then
			lConn = openConnectionInstance("month" & gMonth - cmbMonthEnd.SelectedIndex & ".mdb")
			If lConn Is Nothing Then Exit Sub
			rsStock = New ADODB.Recordset
			rsStock.CursorLocation = ADODB.CursorLocationEnum.adUseClient
			sql = "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;"
			
			rsStock.Open(sql, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			rsSales = New ADODB.Recordset
			rsSales.CursorLocation = ADODB.CursorLocationEnum.adUseClient
			'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "SELECT [M_DayEnd].[DayEndID], [M_DayEnd].[DayEnd_Date], Sum([Declaration].[Declaration_Total]) AS SumOfSale_Total FROM Declaration INNER JOIN M_DayEnd ON [Declaration].[Declaration_DayEndID]=[M_DayEnd].[DayEndID] GROUP BY [M_DayEnd].[DayEndID], [M_DayEnd].[DayEnd_Date];"
			
			rsSales.Open(sql, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		Else
			
			modUpdate = 3
			
			updateStockMovement()
			
			sql = "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(Declaration.Declaration_Total) AS SumOfSale_Total FROM Company, Declaration INNER JOIN DayEnd ON Declaration.Declaration_DayEndID = DayEnd.DayEndID Where (((DayEnd.DayEndID) <> [Company]![Company_DayEndID])) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date Union SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SumOfSale_Total FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((Sale INNER JOIN (Company INNER JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0)) GROUP BY Consignment.ConsignmentID, Consignment_1.ConsignmentID, DayEnd.DayEndID, DayEnd.DayEnd_Date  "
			sql = sql & "HAVING (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));"
			rsSales = getRS(sql)
			
			rsStock = getRS("SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
			
		End If
		
		rsPurchase = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(grvPosted.GRV_InvoiceInclusive) AS SumOfGRV_InvoiceInclusive, ([MonthEnd_BudgetSales]/[MonthEnd_Days]) AS saleBudget, ([MonthEnd_BudgetPurchases]/[MonthEnd_Days]) AS purchaseBudget FROM [SELECT GRV.* From GRV WHERE (((GRV.GRV_GRVStatusID)=3))]. AS grvPosted RIGHT JOIN (DayEnd INNER JOIN MonthEnd ON DayEnd.DayEnd_MonthEndID = MonthEnd.MonthEndID) ON grvPosted.GRV_DayEndID = DayEnd.DayEndID Where (((MonthEnd.MonthEndID) = " & gMonth - cmbMonthEnd.SelectedIndex & ")) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date, ([MonthEnd_BudgetSales]/[MonthEnd_Days]), ([MonthEnd_BudgetPurchases]/[MonthEnd_Days]);")
		
		
		
		rsCompany = getRS("SELECT MonthEnd.* From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth - cmbMonthEnd.SelectedIndex & "));")
		
		rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
		If rsPurchase.BOF Or rsPurchase.EOF Then
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
        'Report.Database.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rsPurchase)
        Report.Database.Tables(2).SetDataSource(rsSales)
        Report.Database.Tables(3).SetDataSource(rsStock)
        Report.Database.Tables(4).SetDataSource(rsCompany)
		'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
		If lConn Is Nothing Then 
		Else 
			lConn.Close()
		End If
	End Sub
	
	Private Sub frmIncomeExpense_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmIncomeExpense_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim rs As New ADODB.Recordset
		cmbMonthEnd.Items.Clear()
		rs = getRS("SELECT Min(DayEnd.DayEnd_Date) AS MinOfDayEnd_Date, Max(DayEnd_1.DayEnd_Date) AS MaxOfDayEnd_Date, Company.Company_MonthEndID, MonthEnd.MonthEndID FROM Company, (DayEnd AS DayEnd_1 INNER JOIN MonthEnd ON DayEnd_1.DayEnd_MonthEndID = MonthEnd.MonthEndID) INNER JOIN DayEnd ON MonthEnd.MonthEndID = DayEnd.DayEnd_MonthEndID GROUP BY Company.Company_MonthEndID, MonthEnd.MonthEndID ORDER BY MonthEnd.MonthEndID DESC")
		gMonth = rs.Fields("Company_MonthEndID").Value
		Do Until rs.EOF
			If rs.Fields("Company_MonthEndID").Value = rs.Fields("MonthEndID").Value Then
				cmbMonthEnd.Items.Add("Current Month")
			Else
				cmbMonthEnd.Items.Add((rs.Fields("Company_MonthEndID").Value - rs.Fields("MonthEndID").Value) & " Month/s ago starting on the " & Format(rs.Fields("MinOfDayEnd_Date").Value, "dd MM yyyy") & " and ending on the " & Format(rs.Fields("MaxOfDayEnd_Date").Value, "dd MM yyyy") & ".")
			End If
			rs.moveNext()
		Loop 
		cmbMonthEnd.SelectedIndex = 0
		
		loadLanguage()
	End Sub
End Class