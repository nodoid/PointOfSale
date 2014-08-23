using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmGRV : System.Windows.Forms.Form
	{
		public ADODB.Recordset adoPrimaryRS;
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		bool bIsVoucher;
		List<Label> lblLabels = new List<Label>();
		List<Label> lblData = new List<Label>();
		private void loadLanguage()
		{

			//NOTE: Form Caption has a Spelling Mistake!
			//frmGRV = No Code       [Process a 'Goods Receiving Voucher']
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmGRV.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRV.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1559;
			//Select a Supplier to Transact with|Checked
			if (modRecordSet.rsLang.RecordCount){_frmMode_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_frmMode_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1432;
			//Supplier Details|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1442;
			//Supplier Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1457;
			//Account Number|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[36].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[36].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1609;
			//Order Reference|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1459;
			//GRV Template|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1650;
			//Invoice Details|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdNewGT = No Code     [Create New GRV Template]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNewGT.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNewGT.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1651;
			//Number| Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1652;
			//Total| Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1426;
			//Date|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1654;
			//Load GRV|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void Create(ref int purchaseOrder, ref bool import = false, ref bool isVoucher = false)
		{
			string sql = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			gID = purchaseOrder;
			bIsVoucher = isVoucher;

			System.Windows.Forms.Label oLabel = null;
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT GRV.GRV_PurchaseOrderID, GRV.GRV_GRVStatusID From GRV WHERE (((GRV.GRV_PurchaseOrderID)=" + gID + ") AND ((GRV.GRV_GRVStatusID)=1));");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				modRecordSet.cnnDB.Execute("INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + gID + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;");
				modRecordSet.cnnDB.Execute("INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date ) SELECT GRV.GRVID, PurchaseOrderItem.PurchaseOrderItem_StockItemID, 0 AS return, PurchaseOrderItem.PurchaseOrderItem_PackSize, PurchaseOrderItem.PurchaseOrderItem_Quantity, PurchaseOrderItem.PurchaseOrderItem_Quantity, PurchaseOrderItem.PurchaseOrderItem_ContentCost, 0, 0, 0, Now() FROM PurchaseOrderItem INNER JOIN (GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) ON PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((PurchaseOrder.PurchaseOrderID)=" + gID + ") AND ((GRV.GRV_GRVStatusID)=1));");

				modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_Name = [StockItem]![StockItem_Name], GRVItem.GRVItem_Code = '' WHERE ((([GRV].[GRV_PurchaseOrderID])=" + gID + ") AND (([GRV].[GRV_GRVStatusID])=1));");
				modRecordSet.cnnDB.Execute("UPDATE (CatalogueChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount], GRVItem.GRVItem_Price = [CatalogueChannelLnk_PriceSystem] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" + gID + "));");
				//cnnDB.Execute "UPDATE (CatalogueChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = Vat.Vat_Amount, GRVItem.GRVItem_Price = CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));"

				//Set rs1 = getRS("SELECT Vat.Vat_Amount FROM GRV INNER JOIN (GRVItem INNER JOIN (StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON GRV.GRVID = GRVItem.GRVItem_GRVID WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & "));")
				//If rs1.RecordCount > 0 Then
				//    cnnDB.Execute "UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_VatRate = " & rs1("Vat_Amount") & " WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & "));"
				//End If
				//rs1.Close
				//changed above with below
				modRecordSet.cnnDB.Execute("UPDATE ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRV.GRV_PurchaseOrderID)=" + gID + "));");

				//cnnDB.Execute "UPDATE (PriceChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount], GRVItem.GRVItem_Price = [CatalogueChannelLnk_PriceSystem] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));"

				//update selling price
				sql = "UPDATE (GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN PriceChannelLnk ON GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE (((PriceChannelLnk.PriceChannelLnk_Quantity)=1) AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" + gID + "));";
				//sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & gID & ");"
				modRecordSet.cnnDB.Execute(sql);

			} else {
				rs.Close();
			}

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT Supplier.*, PurchaseOrder.*, GRV.* FROM GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((PurchaseOrder.PurchaseOrderID)=" + gID + ") AND ((GRV.GRV_GRVStatusID)=1));");
			if (import) {
				sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount ) ";
				sql = sql + "SELECT " + adoPrimaryRS.Fields("GRVID").Value + ", StockItem.StockItemID, 0, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, StockItem.StockItem_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost], 0 FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY " + adoPrimaryRS.Fields("GRVID").Value + ", StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, StockItem.StockItem_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];";

				sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount, GRVItem_Line ) ";
				sql = sql + "SELECT " + adoPrimaryRS.Fields("GRVID").Value + ", StockItem.StockItemID, 0 AS Expr2, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0 AS Expr3, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost] AS Expr4, 0 AS Expr5, First(GRVimport.GRVimport_Key) AS FirstOfGRVimport_Key FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY " + adoPrimaryRS.Fields("GRVID").Value + ", StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];";

				//sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount, GRVItem_Line, GRVItem_Price ) "
				//sql = sql & "SELECT " & adoPrimaryRS("GRVID") & ", StockItem.StockItemID, 0 AS Expr2, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0 AS Expr3, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost] AS Expr4, 0 AS Expr5, Last(GRVimport.GRVimport_Key) AS LastOfGRVimport_Key, StockItem_ActualCost FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];"

				x = 1;

				rs = modRecordSet.getRS(ref "SELECT * FROM GRVitem ORDER BY GRVitem_Line");

				modRecordSet.cnnDB.Execute(sql);

				while (!(rs.EOF)) {
					rs.Fields("GRVitem_Line").Value = x;
					rs.update();
					x = x + 1;
					rs.moveNext();
				}
			}
			BindingSource bind = new BindingSource();
			bind.DataSource = adoPrimaryRS;
			foreach (Label oLabel_loopVariable in lblData) {
				oLabel = oLabel_loopVariable;
				oLabel.DataBindings.Add(bind.DataSource);
			}
			txtInvoiceNo.DataBindings.Add(bind.DataSource);
			txtInvoiceTotal.DataBindings.Add(bind.DataSource);
			txtInvoiceTotal.Text = Convert.ToString(Convert.ToDouble(txtInvoiceTotal.Text) * 100);
			txtInvoiceTotal_Leave(txtInvoiceTotal, new System.EventArgs());

			buildDataControls();
			MonthView1.DataBindings.Add(adoPrimaryRS);

			cmdBack.Text = "&Back";
			cmdNext.Text = "E&xit";
			if (this.Visible)
				txtInvoiceNo.Focus();
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = true;
			}

			if (import) {
				sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" + adoPrimaryRS.Fields("GRVID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));";
				modRecordSet.cnnDB.Execute(sql);

				sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" + adoPrimaryRS.Fields("GRVID").Value + "));";
				modRecordSet.cnnDB.Execute(sql);

				//update selling price
				sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + adoPrimaryRS.Fields("GRVID").Value + ");";
				modRecordSet.cnnDB.Execute(sql);
			}

			if (!string.IsNullOrEmpty(Module1.sGRVSales)) {
				Module1.sGRVSales = "DONE";
			} else {
				loadLanguage();
				ShowDialog();
			}

			return;
			Error_Create:
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
			doDataControl(ref (this.cmbTemplate), ref "SELECT GRVTemplateID, GRVTemplate_Name FROM GRVTemplate ORDER BY GRVTemplate_Name", ref "Supplier_GRVtype", ref "GRVTemplate_Name", ref "GRVTemplate_Name");
			//doDataControl Me.cmbKeyboard, "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", "POS_Keyboard", "KeyboardLayoutID", "KeyboardLayout_Name"
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			BindingSource bind = new BindingSource();
			bind.DataSource = rs;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataSource = rs
			dataControl.DataBindings.Add(bind.DataSource);
			dataControl.DataBindings.Add(adoPrimaryRS);
			dataControl.DataField = DataField;
			dataControl.boundColumn = boundColumn;
			dataControl.Columns.Add(listField, "");
		}

		private void cmdExit_Click()
		{
			modApplication.bolFNVegGRV = false;
			this.Close();
		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.bolFNVegGRV = false;
			this.Close();
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_GRVStatusID FROM (GRV INNER JOIN GRV AS GRV_1 ON GRV.GRV_InvoiceNumber = GRV_1.GRV_InvoiceNumber) INNER JOIN (PurchaseOrder INNER JOIN PurchaseOrder AS PurchaseOrder_1 ON PurchaseOrder.PurchaseOrder_SupplierID = PurchaseOrder_1.PurchaseOrder_SupplierID) ON (GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) AND (GRV_1.GRV_PurchaseOrderID = PurchaseOrder_1.PurchaseOrderID) WHERE (((GRV.GRV_InvoiceNumber)='" + this.txtInvoiceNo.Text + "') AND ((GRV.GRVID)<>[GRV_1]![GRVID]) AND ((GRV_1.GRVID)=" + adoPrimaryRS.Fields("GRVID").Value + "));");
			if (rs.RecordCount) {
				if (Interaction.MsgBox("An Invoice Number of '" + rs.Fields("GRV_InvoiceNumber").Value + "' already exist for this supplier!" + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo + MsgBoxStyle.Question, "DUPLICATE INVOICE NUMBER") == MsgBoxResult.No) {
					return;
				}
			}
			update_Renamed();
			if (modApplication.bolAirTimeGRV == true) {
				modRecordSet.cnnDB.Execute("UPDATE GRV SET GRV_InvoiceNumber = '" + Strings.Left(this.txtInvoiceNo.Text, 20) + "' WHERE GRVID=" + adoPrimaryRS.Fields("GRVID").Value + ";");
			}
			if (modApplication.bolFNVegGRV == true) {
				My.MyProject.Forms.frmGRVitemFnV.loadItem(ref 0);
			} else {
				My.MyProject.Forms.frmGRVitem.loadItem(ref 0);
			}
			//    frmGRVitem.Show 1, Me
		}

		private void cmdNewGT_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmGRVTemplate form = new frmGRVTemplate();
			form.Show();
			buildDataControls();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
			this.Close();
		}


		private void frmGRV_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			frmGRVTemplate form = new frmGRVTemplate();
			if (Shift == 7 & KeyCode == 67) {
				form.Show();
				KeyCode = 0;
			}
		}

		private void frmGRV_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdBack_Click(cmdBack, new System.EventArgs());
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmGRV_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//    gRS.Close
		}

		private void MonthView1_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			MonthView1.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624);
		}

		private void MonthView1_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			MonthView1.BackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 255, 255));

		}

		private void tmrAutoGRV_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = false;
				txtInvoiceNo.Text = Strings.Replace(Convert.ToString(DateAndTime.Now), " ", "");
				txtInvoiceNo.Text = Strings.Replace(txtInvoiceNo.Text, "/", "");
				txtInvoiceNo.Text = Strings.Replace(txtInvoiceNo.Text, ":", "");

				if (bIsVoucher) {
					txtInvoiceNo.Text = "4Voucher" + Strings.Replace(txtInvoiceNo.Text, ":", "");
				} else {
					txtInvoiceNo.Text = "4AIR" + Strings.Replace(txtInvoiceNo.Text, ":", "");
				}

				cmdLoad.Focus();
				cmdLoad_Click(cmdLoad, new System.EventArgs());
			}
		}

		private void txtInvoiceNo_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtInvoiceNo.SelectionStart = 0;
			txtInvoiceNo.SelectionLength = 999;
		}

		private void txtInvoiceTotal_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtInvoiceTotal);
		}

		private void txtInvoiceTotal_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtInvoiceTotal_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtInvoiceTotal, ref 2);
		}

		private void txtSearch_MyGotFocus()
		{
			//Dim txtSearch As New TextBox
			//txtSearch.Start = 0
			//txtSearch.Length = 999
		}

		private void update_Renamed()
		{
			//  On Error GoTo UpdateErr
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			return;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
		}

		private void frmGRV_Load(object sender, System.EventArgs e)
		{
			lblLabels.AddRange(new Label[] {
				_lblLabels_0,
				_lblLabels_2,
				_lblLabels_36,
				_lblLabels_8,
				_lblLabels_9
			});
			lblData.AddRange(new Label[] {
				_lblData_0,
				_lblData_1,
				_lblData_2,
				_lblData_3,
				_lblData_7
			});
		}
	}
}
