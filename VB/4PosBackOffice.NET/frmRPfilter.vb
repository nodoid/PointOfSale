Option Strict Off
Option Explicit On
Friend Class frmRPfilter
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gFilterSQL As String
	Dim gReport As String
	
	Private Sub loadLanguage()
		
		'frmRPfilter = No Code  [Select the filter for your Report]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmRPfilter.Caption = rsLang("LanguageLayoutLnk_Description"): frmRPfilter.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code   [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdNamespace.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNamespace.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmRPfilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef Report As String)
		getNamespace()
		Select Case LCase(Report)
			Case "recipe"
				gReport = Report
				Me.Text = "Bill Of Material Listing"
				gFilter = "stockitem"
				System.Windows.Forms.Application.DoEvents()
				getNamespace()
				
				loadLanguage()
				ShowDialog()
			Case "stockitemgrouping"
				gReport = Report
				Me.Text = "Stock Item Grouping Details"
				gFilter = "stockitem"
				System.Windows.Forms.Application.DoEvents()
				getNamespace()
				
				loadLanguage()
				ShowDialog()
			Case "stockitemorderlevels"
				gReport = Report
				Me.Text = "Stock Item Re-order Levels"
				gFilter = "stockitem"
				System.Windows.Forms.Application.DoEvents()
				getNamespace()
				
				loadLanguage()
				ShowDialog()
		End Select
	End Sub
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNamespace.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Select Case LCase(gReport)
			Case "recipe"
				report_BOM(gFilterSQL)
			Case "stockitemgrouping"
				stockitemGroup()
			Case "stockitemorderlevels"
				stockitemOrderLevels()
		End Select
	End Sub
	
	Private Sub frmRPfilter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		getNamespace()
	End Sub
	
	Private Sub frmRPfilter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				Me.Close()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub getNamespace()
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
	End Sub
	
	
	Private Sub stockitemGroup()
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim rs As ADODB.Recordset
		Dim sql As String
        Report.Load("cryStockItemGrouping.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtTitle", Me.Text)
        Report.SetParameterValue("txtFilter", Me.lblHeading.Text)
		rs.Close()
		sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_ReceiptName, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost , Deposit.Deposit_Name, StockGroup.StockGroup_Name, Shrink.Shrink_Name, Supplier.Supplier_Name, PricingGroup.PricingGroup_Name FROM (((Deposit INNER JOIN (StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID "
		sql = sql & gFilterSQL & " ORDER BY StockItem.StockItem_Name;"
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
		'Report.Database.SetDataSource(rs, 3)
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	
	Private Sub stockitemOrderLevels()
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim rs As ADODB.Recordset
		Dim sql As String
        Report.Load("cryStockItemORderLevels.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtTitle", Me.Text)
        Report.SetParameterValue("txtFilter", Me.lblHeading.Text)
		rs.Close()
		sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, [StockItem_MinimumStock]/[StockItem_Quantity] AS minimumCase, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, [StockItem_Quantity]=[StockItem_OrderQuantity] AS brokenPack FROM StockItem "
		sql = sql & gFilterSQL & " ORDER BY StockItem.StockItem_Name;"
		rs = getRS(sql)
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		'Report.Database.SetDataSource(rs, 3)
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
End Class