Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockSalesShrink
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmStockSalesShrink = No Code  [Stock Item Sales Shrink Analysis]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockSalesShrink.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockSalesShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
        If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockSalesShrink.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
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
		
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblGroup.Text = rs.Fields("Link_Name").Value
	End Sub
	
	
	Private Sub loadStockSales()
		Dim rs As ADODB.Recordset
		Dim rsStock As ADODB.Recordset
		Dim rsGroup As ADODB.Recordset
		Dim sql As String
        Dim rsData As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySalesByShrink.rpt")
        ReportNone.Load("cryNoRecords.rpt")
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		If rs.Fields("Link_Name").Value = "" Then
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
		Else
            Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		End If
		
		sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, thejoin.shrink, thejoin.quantity, thejoin.price, thejoin.list, thejoin.actual FROM aStockItem INNER JOIN (SELECT SaleItem.SaleItem_StockItemID AS StockItem, SaleItem.SaleItem_ShrinkQuantity AS shrink, Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])) AS quantity, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS price, Sum((([SaleItem_ListCost]+[SaleItem_DepositCost])*IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS list, Sum((([SaleItem_ActualCost]+[SaleItem_DepositCost])*IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS actual From SaleItem Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = 0)) GROUP BY SaleItem.SaleItem_StockItemID, SaleItem.SaleItem_ShrinkQuantity ) AS thejoin ON aStockItem.StockItemID = thejoin.StockItem "
		sql = sql & rs.Fields("Link_SQL").Value & " ORDER BY aStockItem.StockItem_Name, thejoin.shrink;"
		
		
		rs = getRSreport(sql)
		
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
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		loadStockSales()
		Exit Sub
		
	End Sub
	
    Private Sub frmStockSalesShrink_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockSalesShrink_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
		
		setup()
	End Sub
End Class