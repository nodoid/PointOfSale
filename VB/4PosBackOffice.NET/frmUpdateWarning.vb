Option Strict Off
Option Explicit On
Friend Class frmUpdateWarning
	Inherits System.Windows.Forms.Form
	Dim gRS As ADODB.Recordset
	Dim gRSsq As ADODB.Recordset
	Dim gUpdate As Boolean
	
	Private Sub loadLanguage()
		
		'frmUpdateWarning = No Code [Update Warning...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmUpdateSale.Caption = rsLang("LanguageLayoutLnk_Description"): frmUpdateWarning.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblDesc = No Code          [There are 47 catalogue.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblDesc.Caption = rsLang("LanguageLayoutLnk_Description"): lblDesc.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdContinue = No Code      [Continue with the Update of Point Of Sale]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdContinue.Caption = rsLang("LanguageLayoutLnk_Description"): cmdContinue.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdPrint = No Code         [Print List]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdPrint.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrint.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdClose = No Code         [Cancel the Update of Point Of Sale]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdClose.Caption = rsLang("LanguageLayoutLnk_Description"): cmdClose.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmUpdateWarning.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		gUpdate = False
		Me.Close()
	End Sub
	
	Private Sub cmdContinue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdContinue.Click
		gUpdate = True
		Me.Close()
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim rs As ADODB.Recordset
		Dim sql As String
        Dim rsData As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Report1 As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryNegativeProfit.rpt")
        Report1.Load("crysqZero.rpt")
		Dim lOrder As String
		Dim lWhere As String
		If gRS.RecordCount Then
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			rs = getRS("SELECT * FROM Company")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
			rs.Close()
			
			'Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(gRS)
			'Report.Database.SetDataSource(gRS, 3)
			frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = Report
			frmReportShow.mReport = Report : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
		End If
		If gRSsq.RecordCount Then
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			rs = getRS("SELECT * FROM Company")
            Report1.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
			rs.Close()
			
			'Report1.VerifyOnEveryPrint = True
            Report1.Database.Tables(1).SetDataSource(gRSsq)
			'Report1.Database.SetDataSource(gRSsq, 3)
            frmReportShow.Text = Report1.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = Report1
			frmReportShow.mReport = Report : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
		End If
	End Sub
	
	Public Function loadItem() As Boolean
		Dim sql As String
		gUpdate = True
        Dim lString As String = ""
		
		sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, Channel.Channel_Name, Channel.ChannelID "
		sql = sql & "FROM Channel INNER JOIN ((Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) LEFT JOIN StockitemOverwrite ON StockItem.StockItemID = StockitemOverwrite.StockitemOverwriteID) ON Channel.ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID "
		sql = sql & "WHERE (((([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)))<=0) AND ((StockitemOverwrite.StockitemOverwriteID) Is Null) AND ((StockItem.StockItem_Disabled)=False) AND ((Channel.Channel_Disabled)=False) AND ((Channel.ChannelID)<>9) AND ((Catalogue.Catalogue_Disabled)=False));"
		
		gRS = getRS(sql)
		If gRS.RecordCount Then
			lString = lString & "There are " & gRS.RecordCount & " catalogue prices where your price is equal or less that the products cost price." & vbCrLf & vbCrLf
		End If
		sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, CatalogueChannelLnk.CatalogueChannelLnk_Price, Channel.Channel_Name, Channel.ChannelID "
		sql = sql & "FROM Channel INNER JOIN ((Vat INNER JOIN (CatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN StockitemOverwrite ON StockItem.StockItemID = StockitemOverwrite.StockitemOverwriteID) ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID "
		sql = sql & "WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)=0) AND ((Channel.ChannelID)<>9) AND ((StockItem.StockItem_Disabled)=False) AND ((Channel.Channel_Disabled)=False) AND ((Catalogue.Catalogue_Disabled)=False));"
		gRSsq = getRS(sql)
		If gRSsq.RecordCount Then
			lString = lString & "There are " & gRS.RecordCount & " SQ catalogue prices set to ZERO." & vbCrLf & vbCrLf
		End If
		If lString <> "" Then
			lString = lString & "It is not advisable to post any changes to your Point Of Sale devices until you have resolved this prices."
			Me.lblDesc.Text = lString
			ShowDialog()
		End If
		loadItem = gUpdate
	End Function
End Class