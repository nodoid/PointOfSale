Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmItemGroup
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2375 'Stock Item / Stock Group Compare|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2113 'Select Stock Item|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2378 'Get Stock Item|Checked
		If rsLang.RecordCount Then cmdStockItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStockItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2379 'Select a Group|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2380 'Get a Group|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2382 'Sales Quantity|Checked
        If rsLang.RecordCount Then _optDataType_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optDataType_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2383 'Sales Value|Checked
        If rsLang.RecordCount Then _optDataType_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optDataType_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmItemGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
		Dim rs As ADODB.Recordset
		Dim lID As Integer
		cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		frmFilter.Close()
		frmFilter.buildCriteria("StockItem")
		frmFilter.loadFilter("StockItem")
		frmFilter.buildCriteria("StockItem")
		
		cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" & Replace(frmFilter.gHeading, "'", "''") & "', Link.Link_SQL = '" & Replace(frmFilter.gCriteria, "'", "''") & "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		lblGroup.Text = frmFilter.gHeading
	End Sub
	
	Private Sub cmdStockItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStockItem.Click
		Dim rs As ADODB.Recordset
		Dim lID As Integer
		cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=1) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=1) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		
		frmFilter.buildCriteria("StockItem")
		frmFilter.Close()
		lID = frmStockList.getItem()
		If lID Then
			frmFilter.buildCriteria("StockItem")
			rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & lID)
			cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = ' " & Replace(rs.Fields("StockItem_Name").Value, "'", "''") & "', Link.Link_SQL = 'StockItemID=" & lID & "' WHERE (((Link.LinkID)=1) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
			cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=1) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
			cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=1) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
			cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 1, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
			cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 1, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
			lblItem.Text = rs.Fields("StockItem_Name").Value
		End If
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		rs = getRSreport("SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" & gPersonID & "));")
		If rs.BOF Or rs.EOF Then
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " & gPersonID & ", '', '';")
		End If
		
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=1) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblItem.Text = rs.Fields("Link_Name").Value
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblGroup.Text = rs.Fields("Link_Name").Value
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
		'Dim Report As New cryItemGroupCompare
        'ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryItemGroupCompare.rpt")
        ReportNone.Load("cryNoRecords")
		cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;")
		rs = getRSreport("SELECT * FROM Link Where LinkID=1 AND Link_SectionID=1")
		cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT 1, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID WHERE " & rs.Fields("Link_SQL").Value & ";")
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT 2, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID " & rs.Fields("Link_SQL").Value & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT Link.* From Link Where (((Link.Link_SectionID) = 1)) ORDER BY Link.Link_SectionID;")
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
		rsData = getRSreport("SELECT LinkItem.*, Format([DayEnd_Date],'ddd dd mmm"", ""yyyy') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID;")
		If rsData.BOF Or rsData.EOF Then
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
        Report.Database.Tables(2).SetDataSource(rsData)
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub frmItemGroup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmItemGroup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		openConnection()
		openConnectionReport()
		
		loadLanguage()
		setup()
	End Sub
End Class