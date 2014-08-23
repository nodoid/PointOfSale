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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockTransfer : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord -= adoPrimaryRS_WillChangeRecord;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord += adoPrimaryRS_WillChangeRecord;
				}
			}
		}
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;
		int p_Prom;
		bool p_Prom1;
		public string loadDBStr;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1787;
			//Stock Transfer Details|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1789;
			//Transfer|Checked
			if (modRecordSet.rsLang.RecordCount){cmdTransfer.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdTransfer.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1790;
			//Transfer From|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1801;
			//Transfer To|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			//If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			//If rsLang.RecordCount Then lblSComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblSComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAdd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAdd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdSelComp = No Code   [Select Company to Transfer]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdSelComp.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSelComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTransfer.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//rs = getRS(sql)
			//dataControl.DataSource = rs
			//dataControl.DataSource = adoPrimaryRS
			// dataControl.DataField = DataField
			// dataControl.boundColumn = boundColumn
			// dataControl.listField = listField
		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = new System.Windows.Forms.TextBox();
			DateTimePicker oDate = new DateTimePicker();
			System.Windows.Forms.CheckBox oCheck = new System.Windows.Forms.CheckBox();

			loadLanguage();
			ShowDialog();
		}
		private void setup()
		{
		}

		private void chkFields_Click(ref short Index)
		{

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				 // ERROR: Not supported in C#: OnErrorStatement

				//cnnDB.Execute "INSERT INTO PromotionItem ( PromotionItem_PromotionID, PromotionItem_StockItemID, PromotionItem_Quantity, PromotionItem_Price ) SELECT " & adoPrimaryRS("PromotionID") & " AS [Set], CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, 1,CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & lID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
				My.MyProject.Forms.frmStockTransferItem.loadItem(lID);
				//adoPrimaryRS("PromotionID"), lID
				loadItems(lID);
			}
		}
		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			if (lvStockT.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to remove  '" + lvStockT.FocusedItem.Text + "'  from this Transfer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") == MsgBoxResult.Yes) {
					lID = Convert.ToInt32(Strings.Split(lvStockT.FocusedItem.Name, "_")[0]);
					modRecordSet.cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE StockTransferGRV.StockTransfer_StockItemID=" + lID + " AND StockTransferGRV.StockTransfer_Quantity=" + Strings.Split(lvStockT.FocusedItem.Name, "_")[1] + ";");
					loadItems();
				}
			}

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//update
			//report_Promotion
		}


		private void cmdSelComp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//frmSelComp.show 1
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rj = default(ADODB.Recordset);

			loadDBStr = My.MyProject.Forms.frmSelComp.loadDB();

			if (string.IsNullOrEmpty(loadDBStr)) {
			} else {
				cn = modRecordSet.openSComp(ref loadDBStr);
				if (cn == null) {
				} else {

					rj = modRecordSet.getRSwaitron(ref "SELECT Company_Name FROM Company;", ref cn);
					lblSComp.Text = rj.Fields("Company_Name").Value;

					cmdAdd.Enabled = true;
					cmdDelete.Enabled = true;
				}

			}
		}

		private void cmdTransfer_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int grvNo = 0;
			string sql = null;
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			string errPosition = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			errPosition = "Start";

			if (lvStockT.Items.Count > 0) {
				errPosition = "1";
				sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
				sql = sql + "SELECT 2, Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Blind)', '' FROM Company;";
				modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

				errPosition = "2";
				rsID = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
				grvNo = "Trsnfr#-" + rsID.Fields("id").Value;
				sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), 'Trsnfr#-" + rsID.Fields("id").Value + "', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
				modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
				if (rsID.State)
					rsID.Close();
				rsID = modRecordSet.getRS(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;");

				x = 1;
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
				while (!(rs.EOF)) {
					errPosition = "3";
					rsChk = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
					if (rsChk.RecordCount) {

						errPosition = "4";
						//changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
						sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
						sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
						Debug.Print(sql);
						modRecordSet.cnnDB.Execute(sql);

						//update selling price
						sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + " AND GRVItem.GRVItem_Line =" + x + ");";
						modRecordSet.cnnDB.Execute(sql);
					} else {

						errPosition = "5";
						if (rs.Fields("StockTransfer_Pack").Value == 1) {
							//changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
							sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
						} else {
							//changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
							sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
						}
						Debug.Print(sql);
						modRecordSet.cnnDB.Execute(sql);

						//update selling price
						sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + " AND GRVItem.GRVItem_Line =" + x + ");";
						modRecordSet.cnnDB.Execute(sql);
					}

					x = x + 1;
					rs.moveNext();
				}


				if (string.IsNullOrEmpty(loadDBStr)) {
				} else {
					cn = modRecordSet.openSComp(ref loadDBStr);
					errPosition = "6";
					if (cn == null) {
					} else {

						errPosition = "7";
						sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
						sql = sql + "SELECT 2, Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Blind)', '' FROM Company;";
						cn.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

						errPosition = "8";
						rsID = modRecordSet.getRSwaitron(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;", ref cn);
						sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), 'Trsnfr#-" + rsID.Fields("id").Value + "', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
						cn.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

						if (rsID.State)
							rsID.Close();
						rsID = modRecordSet.getRSwaitron(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;", ref cn);

						x = 1;
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
						while (!(rs.EOF)) {

							errPosition = "9";
							//Set rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs("StockTransfer_StockItemID") & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
							rsChk = modRecordSet.getRSwaitron(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));", ref cn);
							if (rsChk.RecordCount) {

								errPosition = "10";
								//list cost will also change 04-oct      sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
								sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								cn.Execute(sql);

								//update selling price
								sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + " AND GRVItem.GRVItem_Line =" + x + ");";
								cn.Execute(sql);
							} else {

								errPosition = "11";
								if (rs.Fields("StockTransfer_Pack").Value == 1) {
									//changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
									//changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								} else {
									//changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
									//changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								}
								Debug.Print(sql);
								cn.Execute(sql);

								//update selling price
								sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + " AND GRVItem.GRVItem_Line =" + x + ");";
								cn.Execute(sql);
								//sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								//sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs("StockTransfer_StockItemID") & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
								//cn.Execute sql
							}
							Debug.Print(sql);
							x = x + 1;
							rs.moveNext();
						}

					}

				}

				Interaction.MsgBox("GRV on both Locations has been created with InvoiceNumber " + grvNo + ". Please process ASAP.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2, "Completed");
				this.Close();
			} else {
			}

			return;
			ErrTransfer:
			Interaction.MsgBox("Error at position no. " + errPosition + " Err Number " + Err().Number + " " + Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void frmStockTransfer_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lvStockT.Columns.Clear();
			lvStockT.Columns.Add("", "Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(4050, true)));
			lvStockT.Columns.Add("QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(800, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvStockT.Columns.Add("Price", Convert.ToInt32(sizeConvertors.twipsToPixels(1440, true)), System.Windows.Forms.HorizontalAlignment.Right);

			ADODB.Recordset rj = default(ADODB.Recordset);
			rj = modRecordSet.getRS(ref "SELECT Company_Name FROM Company;");
			lblPComp.Text = rj.Fields("Company_Name").Value;

			lblSComp.Text = "Select Company to Transfer";
			cmdAdd.Enabled = false;
			cmdDelete.Enabled = false;
			//cmdTransfer.Enabled = False
			loadLanguage();

			modRecordSet.cnnDB.Execute("DELETE * from StockTransferGRV;");
		}

		private void loadItems(ref int lID = 0, ref short quantity = 0)
		{
			System.Windows.Forms.ListViewItem listItem = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			lvStockT.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
			while (!(rs.EOF)) {

				listItem = lvStockT.Items.Add(rs.Fields("StockTransfer_StockItemID").Value + "_" + rs.Fields("StockTransfer_Quantity").Value, rs.Fields("Stockitem_Name").Value, "");
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = rs.Fields("StockTransfer_Quantity").Value;
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockTransfer_Quantity").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = Strings.FormatNumber(rs.Fields("StockTransfer_Price").Value, 2);
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("StockTransfer_Price").Value, 2)));
				}
				if (rs.Fields("StockTransfer_StockItemID").Value == lID & rs.Fields("StockTransfer_Quantity").Value == quantity)
					listItem.Selected = true;
				rs.moveNext();
			}
		}

//UPGRADE_WARNING: Event frmStockTransfer.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockTransfer_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmStockTransfer_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					adoPrimaryRS.Move(0);

					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockTransfer_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This is where you put validation code
			//This event gets called when the following actions occur
			bool bCancel = false;
			switch (adReason) {
				case ADODB.EventReasonEnum.adRsnAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnClose:
					break;
				case ADODB.EventReasonEnum.adRsnDelete:
					break;
				case ADODB.EventReasonEnum.adRsnFirstChange:
					break;
				case ADODB.EventReasonEnum.adRsnMove:
					break;
				case ADODB.EventReasonEnum.adRsnRequery:
					break;
				case ADODB.EventReasonEnum.adRsnResynch:
					break;
				case ADODB.EventReasonEnum.adRsnUndoAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnUndoDelete:
					break;
				case ADODB.EventReasonEnum.adRsnUndoUpdate:
					break;
				case ADODB.EventReasonEnum.adRsnUpdate:
					break;
			}

			if (bCancel)
				adStatus = ADODB.EventStatusEnum.adStatusCancel;
		}
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    On Error Resume Next
			//    If mbAddNewFlag Then
			this.Close();
			//    Else
			//        mbEditFlag = False
			//        mbAddNewFlag = False
			//        adoPrimaryRS.CancelUpdate
			//        If mvBookMark > 0 Then
			//            adoPrimaryRS.Bookmark = mvBookMark
			//        Else
			//            adoPrimaryRS.MoveFirst
			//        End If
			//        mbDataChanged = False
			//    End If
		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = false;
			return functionReturnValue;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			//DoEvents
			//If update() Then
			//   If _chkFields_1.value = 0 Then
			//      cnnDB.Execute "UPDATE Promotion SET Promotion_StartDate = #" & DTFields(0).value & "#, Promotion_EndDate = #" & DTFields(1).value & "#, Promotion_StartTime = #" & DTFields(2).value & "# ,Promotion_EndTime =#" & DTFields(3).value & "# WHERE PromotionID = " & p_Prom & ";"
			//   End If
			//   Unload Me
			//End If
		}

		private void Label1_Click()
		{

		}

		private void lvStockT_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			short lQty = 0;
			if (lvStockT.FocusedItem == null) {
			} else {
				lID = Convert.ToInt32(Strings.Split(lvStockT.FocusedItem.Name, "_")[0]);
				lQty = Convert.ToInt16(Strings.Split(lvStockT.FocusedItem.Name, "_")[1]);

				My.MyProject.Forms.frmStockTransferItem.loadItem(ref lID, ref Convert.ToInt16(lQty));
				loadItems(ref lID, ref lQty);
			}
		}

		private void lvStockT_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lvStockT_DoubleClick(lvStockT, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}


		private void txtInteger_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtInteger(Index)
		}

		private void txtInteger_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtInteger_MyLostFocus(ref short Index)
		{
			//    LostFocus txtInteger(Index), 0
		}

		private void txtFloat_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloat(Index)
		}

		private void txtFloat_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtFloat_MyLostFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloat(Index), 2
		}

		private void txtFloatNegative_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloatNegative(Index)
		}

		private void txtFloatNegative_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPressNegative txtFloatNegative(Index), KeyAscii
		}

		private void txtFloatNegative_MyLostFocus(ref short Index)
		{
			//    LostFocus txtFloatNegative(Index), 2
		}
	}
}
