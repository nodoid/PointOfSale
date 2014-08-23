Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmItemItem
	Inherits System.Windows.Forms.Form
    Dim cmdClear As New List(Of Button)
    Dim cmdStockItem As New List(Of Button)
    Dim lblItem As New List(Of Label)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2390 'Compare Stock Item to Stock Item|Checked
		If rsLang.RecordCount Then frmItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2391 'Select Stock Items|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdClear(1) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(2) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(2).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(3) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(3).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(4) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(4).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(5) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(5).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(6) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(6).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(6).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(7) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(7).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(7).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(8) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(8).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(9) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(9).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClear(10) = No Code  [Clear]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClear(10).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2382 'Sales Quantity|Checked
        If rsLang.RecordCount Then _optDataType_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optDataType_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2382 'Sales Value|Checked
        If rsLang.RecordCount Then _optDataType_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optDataType_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmItemItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmdClear.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdClear)
        cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '', Link.Link_SQL = '' WHERE (((Link.LinkID)=" & Index & ") AND ((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" & gPersonID & "));")
        cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=" & Index & ") AND ((LinkDataItem.LinkDataItem_SectionID)=3) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
        cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=" & Index & ") AND ((LinkData.LinkData_SectionID)=3) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
        lblItem(Index).Text = ""

    End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
    Private Sub cmdStockItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmdStockItem.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdStockItem)
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
            rs = getRSreport("SELECT Link.Link_SQL, Link.Link_SectionID From Link WHERE (((Link.Link_SQL)='StockItemID=" & lID & "') AND ((Link.Link_SectionID)=3));")
            If rs.RecordCount Then
            Else
                rs.Close()

                rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & lID)
                cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = ' " & Replace(rs.Fields("StockItem_Name").Value, "'", "''") & "', Link.Link_SQL = 'StockItemID=" & lID & "' WHERE (((Link.LinkID)=" & Index & ") AND ((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" & gPersonID & "));")
                cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=" & Index & ") AND ((LinkDataItem.LinkDataItem_SectionID)=3) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
                cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=" & Index & ") AND ((LinkData.LinkData_SectionID)=3) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
                cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT " & Index & ", 3, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
                cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT " & Index & ", 3, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
                lblItem(Index).Text = rs.Fields("StockItem_Name").Value
            End If
        End If
    End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		Dim x As Short
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
		rs = getRSreport("SELECT Link.LinkID, Link.Link_Name From Link WHERE (((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		Do Until rs.EOF
            lblItem(rs.Fields("LinkID").Value).Text = rs.Fields("Link_Name").Value
			rs.moveNext()
		Loop 
	End Sub
	
	Private Sub loadQTY()
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
		'Dim Report As New cryItemItemCompareQty
        'ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryItemItemCompareQty.rpt")
        ReportNone.Load("cryNoRecords.rpt")
		cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;")
		rs = getRSreport("SELECT * FROM Link Where Link_SectionID=3")
		Do Until rs.EOF
			If rs.Fields("Link_SQL").Value <> "" Then
				cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT " & rs.Fields("LinkID").Value & ", DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID WHERE " & rs.Fields("Link_SQL").Value & ";")
			End If
			rs.moveNext()
		Loop 
		
		cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT theJoin.LinkID, theJoin.DayEndID, 0 FROM LinkItem RIGHT JOIN [SELECT Link.LinkID, DayEnd.DayEndID From Link, DayEnd WHERE (((Link.Link_SQL)<>'') AND ((Link.Link_SectionID)=3))]. AS theJoin ON (LinkItem.LinkItem_DayEndID = theJoin.DayEndID) AND (LinkItem.LinkItem_LinkID = theJoin.LinkID) WHERE (((LinkItem.LinkItem_LinkID) Is Null));")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT [Link].[LinkID], [Link].[Link_Name], Sum([LinkItem].[LinkItem_Value]) AS SumOfLinkItem_Value FROM Link INNER JOIN LinkItem ON [Link].[LinkID]=[LinkItem].[LinkItem_LinkID] WHERE ((([Link].[Link_SQL])<>'') And (([Link].[Link_SectionID])=3)) GROUP BY [Link].[LinkID], [Link].[Link_Name] ORDER BY [Link].[LinkID];")
		
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
		rsData = getRSreport("SELECT LinkItem.*, Format([DayEnd_Date],'yyyy mm dd ddd') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID ORDER BY DayEnd.DayEnd_Date;")
		If rsData.BOF Or rsData.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsData)
		System.Windows.Forms.Application.DoEvents()
		'Report.VerifyOnEveryPrint = True
		System.Windows.Forms.Application.DoEvents()
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	Private Sub loadValue()
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
		'Dim Report As New cryItemItemCompareValue
        'ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryItemItemCompareValue.rpt")
        ReportNone.Load("cryNoRecords.rpt")
		cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;")
		rs = getRSreport("SELECT * FROM Link Where Link_SectionID=3")
		Do Until rs.EOF
			If rs.Fields("Link_SQL").Value <> "" Then
				cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT " & rs.Fields("LinkID").Value & ", Sale.Sale_DayEndID, Sum([SaleItem_Quantity]*[SaleItem_Price]) FROM (SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID) INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where " & rs.Fields("Link_SQL").Value & " GROUP BY Sale.Sale_DayEndID;")
			End If
			rs.moveNext()
		Loop 
		
		cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT theJoin.LinkID, theJoin.DayEndID, 0 FROM LinkItem RIGHT JOIN [SELECT Link.LinkID, DayEnd.DayEndID From Link, DayEnd WHERE (((Link.Link_SQL)<>'') AND ((Link.Link_SectionID)=3))]. AS theJoin ON (LinkItem.LinkItem_DayEndID = theJoin.DayEndID) AND (LinkItem.LinkItem_LinkID = theJoin.LinkID) WHERE (((LinkItem.LinkItem_LinkID) Is Null));")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT [Link].[LinkID], [Link].[Link_Name], Sum([LinkItem].[LinkItem_Value]) AS SumOfLinkItem_Value FROM Link INNER JOIN LinkItem ON [Link].[LinkID]=[LinkItem].[LinkItem_LinkID] WHERE ((([Link].[Link_SQL])<>'') And (([Link].[Link_SectionID])=3)) GROUP BY [Link].[LinkID], [Link].[Link_Name] ORDER BY [Link].[LinkID];")
		
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
		rsData = getRSreport("SELECT LinkItem.*, Format([DayEnd_Date],'yyyy mm dd ddd') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID ORDER BY DayEnd.DayEnd_Date;")
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
		System.Windows.Forms.Application.DoEvents()
		'Report.VerifyOnEveryPrint = True
		System.Windows.Forms.Application.DoEvents()
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		
        If _optDataType_0.Checked Then
            loadQTY()
        Else
            loadValue()
        End If
	End Sub
	
	Private Sub frmItemItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmItemItem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmdClear.AddRange(New Button() {_cmdClear_1, _cmdClear_2, _cmdClear_3, _cmdClear_4, _cmdClear_5, _
                                       _cmdClear_6, _cmdClear_7, _cmdClear_8, _cmdClear_9, _cmdClear_10})
        cmdStockItem.AddRange(New Button() {_cmdStockItem_1, _cmdStockItem_2, _cmdStockItem_3, _
                                           _cmdStockItem_4, _cmdStockItem_5, _cmdStockItem_6, _
                                           _cmdStockItem_7, _cmdStockItem_8, _cmdStockItem_9, _
                                           _cmdStockItem_10})
        lblItem.AddRange(New Label() {_lblItem_1, _lblItem_2, _lblItem_3, _lblItem_4, _lblItem_5, _
                                      _lblItem_6, _lblItem_7, _lblItem_8, _lblItem_9, _lblItem_10})
        Dim bt As New Button
        For Each bt In cmdClear
            AddHandler bt.Click, AddressOf cmdClear_Click
        Next
        For Each bt In cmdStockItem
            AddHandler bt.Click, AddressOf cmdStockItem_Click
        Next
        openConnection()
		openConnectionReport()
		
		loadLanguage()
		setup()
	End Sub
End Class