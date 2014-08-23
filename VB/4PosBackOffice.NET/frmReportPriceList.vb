Option Strict Off
Option Explicit On
Friend Class frmReportPriceList
	Inherits System.Windows.Forms.Form

	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1171 'Price List|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1172 'Report Options|Checked
        If rsLang.RecordCount Then _Frame1_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1173 'Group on|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1174 'Page Break after each Group|
		If rsLang.RecordCount Then chkPageBreak.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPageBreak.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'chkQty = No code       [Show Total Quantity]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkQty.Caption = rsLang("LanguageLayoutLnk_Description"): chkQty.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Frame1(1) = No Code    [Report Sort Order]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Frame1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2158 'Sort Field|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2159 'Sort Order|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1178 'Report Filter|Checked
        If rsLang.RecordCount Then _Frame1_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1179 'Channel Filter|Checked
		If rsLang.RecordCount Then Frame2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2176 'Channel|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1181 'Show/Print Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmReportPriceList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
		
		'Dim Report As New cryPricelistRealNoGroup 'cryPricelistReal
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Select Case Me.cmbGroup.SelectedIndex
			Case 0
                Report.Load("cryPricelistReal.rpt")
				chkPageBreak.Enabled = True
			Case 1
                Report.Load("cryPricelistReal.rpt")
				chkPageBreak.Enabled = True
			Case 2
                Report.Load("cryPricelistReal.rpt")
				chkPageBreak.Enabled = True
			Case 3
                Report.Load("cryPricelistRealNoGroup.rpt")
				chkPageBreak.Enabled = False
		End Select
		
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		Dim lOrder As String
		Dim lWhere As String
		Select Case Me.cmbSortField.SelectedIndex
			Case 0
				lOrder = "StockItem.StockItem_Name"
			Case 1
				lOrder = "[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)"
			Case 2
				lOrder = "POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price"
			Case 3
				lOrder = "([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))"
			Case 4
				lOrder = "IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100)"
		End Select
		If Me.cmbSort.SelectedIndex Then lOrder = lOrder & " DESC"
		lOrder = " ORDER BY " & lOrder & ", StockItem.StockItem_Name, Catalogue.Catalogue_Quantity"

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		
		'sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit "
		'sql = sql & "FROM Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON Vat.VatID = StockItem.StockItem_VatID "
		
		'with w/h =2 qty
		'sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity "
		'sql = sql & "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID "
		
		'with all W/H qty
		If chkQty.Enabled = False Then
			sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, 0 AS SumOfWarehouseStockItemLnk_Quantity "
			sql = sql & "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID "
		Else
			If chkQty.CheckState Then
				sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity "
				sql = sql & "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID "
			Else
				sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, 0 AS SumOfWarehouseStockItemLnk_Quantity "
				sql = sql & "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID "
			End If
		End If
		
		Select Case Me.cmbGroup.SelectedIndex
			Case 0
                Report.SetParameterValue("txtTitle", "Price List - by Pricing Group")
			Case 1
				sql = Replace(sql, "PricingGroup", "StockGroup")
                Report.SetParameterValue("txtTitle", "Price List - by Stock Group")
			Case 2
				sql = Replace(sql, "PricingGroup", "Supplier")
                Report.SetParameterValue("txtTitle", "Price List - by Supplier")
			Case 3
                Report.SetParameterValue("txtTitle", "Price List - by Stock Name")
		End Select
		
		If chkPageBreak.Enabled = True Then
			If Me.chkPageBreak.CheckState Then
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			Else
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			End If
		Else
			Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
		End If
		
		'new code
        Report.SetParameterValue("txtChannel", "For " & cmbChannel.CtlText)
		
		If rs.Fields("Link_SQL").Value = "" Then
			'sql = sql & "Where (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = 1) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) "
			sql = sql & "Where (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) "
			'chnaged for QTY 29 June 2010   sql = sql & "Where (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) "
		Else
			'sql = sql & rs("Link_SQL") & " AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = 1) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) "
			sql = sql & rs.Fields("Link_SQL").Value & " AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) "
			'chnaged for QTY 29 June 2010   sql = sql & rs("Link_SQL") & " AND (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) "
		End If
		
		
		sql = sql & "GROUP BY PricingGroup.PricingGroup_Name, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost], [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost], [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100), IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100), ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) "
		Select Case Me.cmbGroup.SelectedIndex
			Case 0
                Report.SetParameterValue("txtTitle", "Price List - by Pricing Group")
			Case 1
				sql = Replace(sql, "PricingGroup", "StockGroup")
                Report.SetParameterValue("txtTitle", "Price List - by Stock Group")
			Case 2
				sql = Replace(sql, "PricingGroup", "Supplier")
                Report.SetParameterValue("txtTitle", "Price List - by Supplier")
			Case 3
                Report.SetParameterValue("txtTitle", "Price List - by Stock Name")
		End Select
		
		sql = sql & lOrder
		Debug.Print(sql)
		rs = getRS(sql)
		
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
		
		'Report.VerifyOnEveryPrint = True
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.Database.SetDataSource(rs, 3)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
		
	End Sub
	
	
	
	Private Sub frmReportPriceList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmReportPriceList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim StockTakePrinter As Integer
        Dim StockTakeAdministrator As Integer
		StockTakeAdministrator = 2
		StockTakePrinter = 4
		
		setup()
		Me.cmbGroup.SelectedIndex = 0
		Me.cmbSort.SelectedIndex = 0
		Me.cmbSortField.SelectedIndex = 0
		
		If StockTakeAdministrator And frmMenu.gBit Then
			chkQty.Enabled = True
		Else
			chkQty.Enabled = False
		End If
		
		loadLanguage()
		
		buildDataControls()
	End Sub
	
	Private Sub optType_Click(ByRef Index As Short)
		If Index Then
			cmbGroup.Enabled = True
		Else
			cmbGroup.Enabled = False
		End If
		Me.chkPageBreak.Enabled = (Index = 1)
	End Sub
	
	'new code
	Private Sub buildDataControls()
		doDataControl((Me.cmbChannel), "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "ChannelID", "Channel_Name")
		cmbChannel.BoundText = CStr(1)
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        dataControl.DataSource = rs
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
End Class