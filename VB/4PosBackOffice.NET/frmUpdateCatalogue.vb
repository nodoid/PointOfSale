Option Strict Off
Option Explicit On
Friend Class frmUpdateCatalogue
	Inherits System.Windows.Forms.Form
	Dim gCNT As Short
	
	Private Sub loadLanguage()
		
		'Label1 = No Code   [Update Stock Items...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmUpdateCatalogue.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub moveItem()
		gCNT = gCNT + 1
        picInner.Width = twipsToPixels(CShort(pixelToTwips(picOuter.Width, True) / 31 * gCNT) + 100, True)
		System.Windows.Forms.Application.DoEvents()
	End Sub
	Private Sub beginUpdate()
		picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		Dim sql As String
		Dim x As Short
		Dim rs As ADODB.Recordset
		
		On Error GoTo Err_beginUpdate
		
		rs = getRS("SELECT theJoin.StockItemID, PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, * FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin RIGHT JOIN PriceChannelLnk ON (theJoin.ShrinkItem_Quantity = PriceChannelLnk.PriceChannelLnk_Quantity) AND (theJoin.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID) WHERE (((theJoin.StockItemID) Is Null));")
		Do Until rs.EOF
			cnnDB.Execute("DELETE PriceChannelLnk.* From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" & rs.Fields("PriceChannelLnk_StockItemID").Value & ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" & rs.Fields("PriceChannelLnk_Quantity").Value & "));")
			rs.moveNext()
		Loop 
		
		rs = getRS("SELECT theJoin.StockItemID, PropChannelLnk.PropChannelLnk_StockItemID, PropChannelLnk.PropChannelLnk_Quantity, * FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin RIGHT JOIN PropChannelLnk ON (theJoin.ShrinkItem_Quantity = PropChannelLnk.PropChannelLnk_Quantity) AND (theJoin.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID) WHERE (((theJoin.StockItemID) Is Null));")
		Do Until rs.EOF
			cnnDB.Execute("DELETE PropChannelLnk.* From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" & rs.Fields("PropChannelLnk_StockItemID").Value & ") AND ((PropChannelLnk.PropChannelLnk_Quantity)=" & rs.Fields("PropChannelLnk_Quantity").Value & "));")
			rs.moveNext()
		Loop 
		
		rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin RIGHT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID) WHERE (((theJoin.StockItemID) Is Null));")
		Do Until rs.EOF
			cnnDB.Execute("DELETE Catalogue.* From Catalogue WHERE (((Catalogue.Catalogue_StockItemID)=" & rs.Fields("Catalogue_StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=" & rs.Fields("Catalogue_Quantity").Value & "));")
			rs.moveNext()
		Loop 
		
		cnnDB.Execute("DELETE CatalogueChannelLnk.* FROM Catalogue RIGHT JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) WHERE (((Catalogue.Catalogue_StockItemID) Is Null));")
		cnnDB.Execute("DELETE systemStockItemPricing.* FROM systemStockItemPricing INNER JOIN StockItem ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID WHERE (((StockItem.StockItem_Disabled)<>0));")
		'cnnDB.Execute "DELETE systemStockItemPricing.* FROM systemStockItemPricing;"
		
		cnnDB.Execute("UPDATE (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN StockItem AS StockItem_1 ON PriceSet.PriceSet_StockItemID = StockItem_1.StockItemID SET StockItem.StockItem_ShrinkID = [StockItem_1]![StockItem_ShrinkID], StockItem.StockItem_PricingGroupID = [StockItem_1]![StockItem_PricingGroupID], StockItem.StockItem_VatID = [StockItem_1]![StockItem_VatID], StockItem.StockItem_DepositID = [StockItem_1]![StockItem_DepositID], StockItem.StockItem_Quantity = [StockItem_1]![StockItem_Quantity], StockItem.StockItem_ListCost = [StockItem_1]![StockItem_ListCost] WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[StockItem_1]![StockItemID]));")
		cnnDB.Execute("DELETE PropChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]));")
		cnnDB.Execute("DELETE PriceChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]));")
		cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT StockItem.StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON PriceSet.PriceSet_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]));")
		cnnDB.Execute("INSERT INTO PropChannelLnk ( PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup ) SELECT StockItem.StockItemID, PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON PriceSet.PriceSet_StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]));")
		
		cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_Quantity = 1 WHERE (((StockItem.StockItem_Quantity)=0));")
		cnnDB.Execute("DELETE Catalogue.*, StockItem.StockItemID FROM StockItem RIGHT JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID WHERE (((StockItem.StockItemID) Is Null));")
		moveItem()
		
		cnnDB.Execute("INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM systemStockItemPricing INNER JOIN ([SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = theJoin.StockItemID WHERE (((Catalogue.Catalogue_StockItemID) Is Null));")
		moveItem()
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Content = [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost];")
		moveItem()
		
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Quantity]*[Deposit_UnitCost];")
		moveItem()
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Deposit]+[Deposit_CaseCost] WHERE (((Deposit.Deposit_CaseCost)<>0));")
		moveItem()
		
		sql = "INSERT INTO CatalogueChannelLnk ( CatalogueChannelLnk_StockItemID, CatalogueChannelLnk_Quantity, CatalogueChannelLnk_ChannelID, CatalogueChannelLnk_Markup, CatalogueChannelLnk_Price, CatalogueChannelLnk_PriceOriginal, CatalogueChannelLnk_PriceSystem, CatalogueChannelLnk_Location ) "
		sql = sql & "SELECT catalogue.Catalogue_StockItemID, catalogue.Catalogue_Quantity, catalogue.ChannelID, 0 AS markup, 0 AS price, 0 AS original, 0 AS system, 0 AS location FROM ([SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Channel.ChannelID FROM Catalogue ,Channel]. AS catalogue LEFT JOIN CatalogueChannelLnk ON (catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (catalogue.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)) INNER JOIN systemStockItemPricing ON catalogue.Catalogue_StockItemID = systemStockItemPricing.systemStockItemPricing WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) Is Null));"
		cnnDB.Execute(sql)
		moveItem()
		
		For x = 1 To 8
			cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Unit" & x & "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" & x & "));")
			cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Case" & x & "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" & x & "));")
			moveItem()
		Next 
		moveItem()
		
		'old
		'cnnDB.Execute "UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroupChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (StockItem.StockItem_PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroupChannelLnk]![PricingGroupChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 2;"
		
		'new
		cnnDB.Execute("UPDATE PricingGroupChannelLnk INNER JOIN (systemStockItemPricing INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID) ON (StockItem.StockItem_PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) AND (StockItem.StockItem_PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID) AND (PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = PricingGroupChannelLnk.PricingGroupChannelLnk_Markup, CatalogueChannelLnk.CatalogueChannelLnk_Location = 1;")
		'MsgBox "helo"
		
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PropChannelLnk INNER JOIN CatalogueChannelLnk ON (PropChannelLnk.PropChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (PropChannelLnk.PropChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (PropChannelLnk.PropChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PropChannelLnk]![PropChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 3;")
		moveItem()
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Catalogue INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [Catalogue_Content]*(1+[CatalogueChannelLnk_Markup]/100)+[Catalogue_Deposit];")
		moveItem()
		
		'Add VAT
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100);")
		moveItem()
		
		'round cents Up
		cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = Round([CatalogueChannelLnk_PriceOriginal]+0.0049,1);")
		cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1);")
		moveItem()
		
		'Do rouding
		cnnDB.Execute("UPDATE (systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID) INNER JOIN Channel ON CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = Channel.ChannelID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)>[PricingGroup]![PricingGroup_RoundDown]) AND ((Channel.Channel_NoPricing)=False));")
		moveItem()
		cnnDB.Execute("UPDATE (systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID) INNER JOIN Channel ON CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = Channel.ChannelID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]-0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)<=[PricingGroup]![PricingGroup_RoundDown]) AND ((Channel.Channel_NoPricing)=False));")
		moveItem()
		
		'update system price
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN CatalogueChannelLnk ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];")
		moveItem()
		
		'Do No Pricing
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((Channel.Channel_NoPricing)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9));")
		moveItem()
		
		'do Price Override
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PriceChannelLnk INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = PriceChannelLnk.PriceChannelLnk_ChannelID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (PriceChannelLnk.PriceChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [PriceChannelLnk]![PriceChannelLnk_Price], CatalogueChannelLnk.CatalogueChannelLnk_Location = 4;")
		moveItem()
		
		'Do Price less
		cnnDB.Execute("UPDATE ((CatalogueChannelLnk AS CatalogueChannelLnk_1 INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) INNER JOIN Channel ON CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = Channel.ChannelID) INNER JOIN systemStockItemPricing ON CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]+([CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]*([CatalogueChannelLnk]![CatalogueChannelLnk_Markup]/100)) WHERE (((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Location)=1) AND ((Channel.Channel_MarkupType)=1));")
		
		'Do Channel 9 Actual Cost
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_Quantity]/[StockItem_Quantity]*[StockItem_ActualCost] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
		moveItem()
		
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal]+[Catalogue]![Catalogue_Deposit] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
		moveItem()
		
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
		moveItem()
		
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
		moveItem()
		
		cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
		moveItem()
		
		cnnDB.Execute("UPDATE (CatalogueChannelLnk INNER JOIN Channel ON CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = Channel.ChannelID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk_1]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>1) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((Channel.Channel_PriceToChannel1)=-1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]));")
		cnnDB.Execute("UPDATE (CatalogueChannelLnk INNER JOIN Channel ON CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = Channel.ChannelID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk_1]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>1) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((Channel.Channel_PriceToChannel1)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Price)<[CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]));")
		
		'Shrink Increment
		sql = "UPDATE (StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN (Catalogue AS Catalogue_1 INNER JOIN (Catalogue INNER JOIN (systemStockItemPricing INNER JOIN (CatalogueChannelLnk AS CatalogueChannelLnk_1 INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON (CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (Catalogue_1.Catalogue_Quantity = CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity) AND (Catalogue_1.Catalogue_StockItemID = "
		sql = sql & "CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID)) ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = ([CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]-[Catalogue_1.Catalogue_Deposit]*(1+[Vat_Amount]/100))*[CatalogueChannelLnk]![CatalogueChannelLnk_Quantity]+([Catalogue]![Catalogue_Deposit]*(1+[Vat_Amount]/100)) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity)=1) AND ((Channel.Channel_ShrinkIncrement)<>0));"
		cnnDB.Execute(sql)
		moveItem()
		cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal], CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((Channel.Channel_ShrinkIncrement)<>0));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount1 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount2 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount3 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=3));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount4 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=4));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount5 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=5));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount6 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=6));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount7 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=7));")
		cnnDB.Execute("UPDATE [Set] INNER JOIN CatalogueChannelLnk ON (Set.Set_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Set.Set_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) SET [Set].Set_Amount8 = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=8));")
		cnnDB.Execute("UPDATE Scale, systemStockItemPricing INNER JOIN StockItem ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Scale.Scale_Update = True WHERE (((StockItem.StockItem_VariablePrice)=True));")
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		
		Exit Sub
Err_beginUpdate: 
		If Err.Number = -2147217833 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver]Numeric value out of range (null)" Then
			MsgBox("Updating POS has found one or more Stock Item(s) have invalid Cost or Selling Price. Please Disable or change the price for the items in order to complete Upload POS.")
		Else
			If Win7Ver Then
				Resume Next
			Else
				MsgBox("Error while Updating POS and Error is :" & Err.Number & " " & Err.Description & " " & Err.Source)
			End If
			'MsgBox "Error while Updating POS and Error is :" & Err.Number & " " & Err.Description & " " & Err.source
		End If
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		'Resume Next
	End Sub
	Private Sub frmUpdateCatalogue_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		picInner.Width = 0
	End Sub
	Private Sub tmrStart_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrStart.Tick
		tmrStart.Enabled = False
		beginUpdate()
	End Sub
End Class