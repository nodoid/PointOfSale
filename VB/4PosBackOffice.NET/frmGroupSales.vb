Option Strict Off
Option Explicit On
Friend Class frmGroupSales
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2181 'Group Sales Profitability Order Criteria|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2182 'Select the Majour Break Group|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2183 'Select the Minor Break Group|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 1269 doesn't have ">>" Chars!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGroupSales.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub setup()
		Me.cmbMajor.Items.Clear()
		cmbMajor.Items.Add("Supplier")
		cmbMajor.Items.Add("Pricing Group")
		cmbMajor.Items.Add("Stock Group")
		cmbMajor.Items.Add("Deposit Type")
		cmbMajor.Items.Add("Shrink Type")
		cmbMajor.SelectedIndex = 2
		
		Me.cmbMinor.Items.Clear()
		cmbMinor.Items.Add("None")
		cmbMinor.Items.Add("Supplier")
		cmbMinor.Items.Add("Pricing Group")
		cmbMinor.Items.Add("Stock Group")
		cmbMinor.Items.Add("Deposit Type")
		cmbMinor.Items.Add("Shrink Type")
		cmbMinor.SelectedIndex = 0
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim rs As ADODB.Recordset
		Dim rsMajor As ADODB.Recordset
		Dim rsMinor As ADODB.Recordset
		Dim majorSQL As String
		Dim majorSQLgroup As String
		Dim minorSQL As String
		Dim minorSQLgroup As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim sql As String
        If LCase(CStr(cmbMajor.SelectedIndex)) = LCase(CStr(cmbMinor.SelectedIndex)) Then
            cmbMinor.SelectedIndex = 0
            System.Windows.Forms.Application.DoEvents()
        End If
        Select Case LCase(CStr(cmbMajor.SelectedIndex))
            Case "supplier"
                majorSQL = "SELECT Supplier.SupplierID AS sectionAkey, Supplier.Supplier_Name AS sectionAname FROM Supplier ORDER BY Supplier.Supplier_Name;"
                majorSQLgroup = "aStockItem.StockItem_SupplierID"
            Case "pricing group"
                majorSQL = "SELECT aPricingGroup.PricingGroupID AS sectionAkey, aPricingGroup.PricingGroup_Name AS sectionAname FROM aPricingGroup;"
                majorSQLgroup = "aStockItem.StockItem_PricingGroupID"
            Case "stock group"
                majorSQL = "SELECT aStockGroup.StockGroupID AS sectionAkey, aStockGroup.StockGroup_Name AS sectionAname FROM aStockGroup;"
                majorSQLgroup = "aStockItem.StockItem_StockGroupID"
            Case "deposit type"
                majorSQL = "SELECT aDeposit.DepositID AS sectionAkey, aDeposit.Deposit_Name AS sectionAname FROM aDeposit;"
                majorSQLgroup = "aStockItem.StockItem_DepositID"
            Case "shrink type"
                majorSQL = "SELECT aShrink.ShrinkID AS sectionAkey, aShrink.Shrink_Name AS sectionAname FROM aShrink;"
                majorSQLgroup = "aStockItem.StockItem_ShrinkID"
        End Select
        Select Case LCase(CStr(cmbMinor.SelectedIndex))
            Case "supplier"
                minorSQL = "SELECT Supplier.SupplierID AS sectionAkey, Supplier.Supplier_Name AS sectionAname FROM Supplier;"
                minorSQLgroup = "aStockItem.StockItem_SupplierID"
            Case "pricing group"
                minorSQL = "SELECT aPricingGroup.PricingGroupID AS sectionAkey, aPricingGroup.PricingGroup_Name AS sectionAname FROM aPricingGroup;"
                minorSQLgroup = "aStockItem.StockItem_PricingGroupID"
            Case "stock group"
                minorSQL = "SELECT aStockGroup.StockGroupID AS sectionAkey, aStockGroup.StockGroup_Name AS sectionAname FROM aStockGroup;"
                minorSQLgroup = "aStockItem.StockItem_StockGroupID"
            Case "deposit type"
                minorSQL = "SELECT aDeposit.DepositID AS sectionAkey, aDeposit.Deposit_Name AS sectionAname FROM aDeposit;"
                minorSQLgroup = "aStockItem.StockItem_DepositID"
            Case "shrink type"
                minorSQL = "SELECT aShrink.ShrinkID AS sectionAkey, aShrink.Shrink_Name AS sectionAname FROM aShrink;"
                minorSQLgroup = "aStockItem.StockItem_ShrinkID"
        End Select
		If minorSQL = "" Then
            Report.Load("cryGroupSalesMajor.rpt")
			sql = "SELECT " & majorSQLgroup & " AS sectionB, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost FROM StockList INNER JOIN "
			sql = sql & "aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY " & majorSQLgroup & ";"
			
		Else
            Report.Load("cryGroupSalesMinor.rpt")
			sql = "SELECT " & majorSQLgroup & " AS sectionA, " & minorSQLgroup & " AS sectionB, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost FROM StockList INNER JOIN "
			sql = sql & "aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY " & majorSQLgroup & ", " & minorSQLgroup & ";"
		End If
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport(sql)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
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
		If minorSQL = "" Then
			rsMajor = getRSreport(majorSQL)
            Report.Database.Tables(1).SetDataSource(rs)
            Report.Database.Tables(2).SetDataSource(rsMajor)
            Report.SetParameterValue("txtTitle", "Group Sales Profit Summary by " & CStr(cmbMajor.SelectedIndex))
		Else
			rsMajor = getRSreport(majorSQL)
            Report.Database.Tables(1).SetDataSource(rsMajor)
            Report.Database.Tables(2).SetDataSource(rs)
			
			rsMinor = getRSreport(minorSQL)
            Report.Database.Tables(3).SetDataSource(rsMinor)
            Report.SetParameterValue("txtTitle", "Group Sales Profit Summary by " & CStr(cmbMajor.SelectedIndex) & " by " & GetItemString(cmbMinor, cmbMinor.SelectedIndex))
		End If
		
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
	End Sub
	
	Private Sub frmGroupSales_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmGroupSales_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
		setup()
	End Sub
End Class