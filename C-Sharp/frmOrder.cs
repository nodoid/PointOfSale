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
	internal partial class frmOrder : System.Windows.Forms.Form
	{
		public ADODB.Recordset adoPrimaryRS;
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		short gMode;
		List<Button> cmdInformation = new List<Button>();
		List<GroupBox> frmMode = new List<GroupBox>();
		List<Label> lblLabels = new List<Label>();
		List<Label> lblData = new List<Label>();
		const short mdSupplier = 0;
		const short mdProcess = 1;


		private void loadLanguage()
		{
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1556;
			//Create / Amend an Order|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1557;
			//Order Information Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdInformation[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdInformation[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdInformation(1) = No Code    [Order Information Report (*)]
			//Note" Closest Match DB Entry 1557, but missing the "(*)" chars
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdInformation(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdInformation(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1559;
			//Select a Supplier to transact with|Checked
			if (modRecordSet.rsLang.RecordCount){frmMode[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmMode[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1454;
			//Ordering Details|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//WARNING: DB Entry 1455 has a spelling mistake!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1455;
			//Representative Name|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[38].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[38].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1456;
			//Representative Number|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[37].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[37].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1457;
			//Account Number|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[36].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[36].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1576;
			//Edit Current Order|Checked
			if (modRecordSet.rsLang.RecordCount){cmdEdit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdEdit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1577;
			//Create a Blank Order|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBlank.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBlank.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1578;
			//Create Recommended Order|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAuto.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAuto.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrder.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdEdit_Enabled()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM TempOrder WHERE TempOrder_SupplierID = " + adoPrimaryRS.Fields("SupplierID").Value);
			if (rs.BOF | rs.EOF) {
				cmdEdit.Enabled = false;
			} else {
				cmdEdit.Enabled = true;
			}
		}
		private void doMode(ref short mode)
		{
			System.Windows.Forms.Label oLabel = null;
			short x = 0;
			gMode = mode;
			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}
			frmMode[gMode].Left = frmMode[0].Left;
			frmMode[gMode].Top = frmMode[0].Top;
			frmMode[gMode].Visible = true;
			System.Windows.Forms.Application.DoEvents();

			switch (gMode) {
				case mdSupplier:
					doSearch();
					if (this.Visible)
						txtSearch.Focus();
					cmdBack.Text = "E&xit";
					cmdNext.Text = "&Next";
					break;
				case mdProcess:
					adoPrimaryRS = modRecordSet.getRS(ref "select SupplierID,Supplier_Name,Supplier_PostalAddress,Supplier_PhysicalAddress,Supplier_Telephone,Supplier_Facimile,Supplier_RepresentativeName,Supplier_RepresentativeNumber,Supplier_ShippingCode,Supplier_OrderAttentionLine,Supplier_Ullage,Supplier_discountCOD,Supplier_discount15days,Supplier_discount30days,Supplier_discount60days,Supplier_discount90days,Supplier_discount120days,Supplier_discountSmartCard,Supplier_discountDefault,Supplier_Current,Supplier_30Days,Supplier_60Days,Supplier_90Days,Supplier_120Days from Supplier WHERE SupplierID = " + DataList1.BoundText);
					foreach (Label oLabel_loopVariable in this.lblData) {
						oLabel = oLabel_loopVariable;
						oLabel.DataBindings.Add(adoPrimaryRS);
					}

					cmdEdit_Enabled();

					cmdBack.Text = "&Back";
					cmdNext.Text = "E&xit";
					break;
			}
		}


		private void cmdExit_Click()
		{
			this.Close();
		}


		private void cmdAuto_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("DELETE tempOrderGenerate.* From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");
			modRecordSet.cnnDB.Execute("INSERT INTO tempOrderGenerate ( tempGenerate_StockItemID, tempGenerate_SupplierID, tempGenerate_Quantity, tempGenerate_OnOrder, tempGenerate_Total ) SELECT StockItem.StockItemID, StockItem.StockItem_SupplierID, 0, 0, 0 From StockItem WHERE (((StockItem.StockItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((StockItem.StockItem_Discontinued)=0));");
			modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN tempOrderGenerate ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = tempOrderGenerate.tempGenerate_StockItemID SET tempOrderGenerate.tempGenerate_Quantity = [tempOrderGenerate]![tempGenerate_Quantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN tempOrderGenerate ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = tempOrderGenerate.tempGenerate_StockItemID) INNER JOIN PurchaseOrder ON (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) AND (tempOrderGenerate.tempGenerate_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID SET tempOrderGenerate.tempGenerate_OnOrder = [tempGenerate_OnOrder]+([PurchaseOrderItem_Quantity]-[PurchaseOrderItem_QuantityDelivered])*[PurchaseOrderItem]![PurchaseOrderItem_PackSize] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((PurchaseOrderStatus.PurchaseOrderStatus_Complete)=0));");
			modRecordSet.cnnDB.Execute("UPDATE Company, tempOrderGenerate SET tempOrderGenerate.tempGenerate_OnOrder = 0 WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");

			modRecordSet.cnnDB.Execute("UPDATE tempOrderGenerate INNER JOIN StockItem ON (StockItem.StockItem_SupplierID = tempOrderGenerate.tempGenerate_SupplierID) AND (tempOrderGenerate.tempGenerate_StockItemID = StockItem.StockItemID) SET tempOrderGenerate.tempGenerate_Total = [StockItem_MinimumStock]-[tempGenerate_Quantity]-[tempGenerate_OnOrder] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");

			modRecordSet.cnnDB.Execute("DELETE tempOrderGenerate.* From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((tempOrderGenerate.tempGenerate_Total)<1));");

			modRecordSet.cnnDB.Execute("DELETE FROM TempOrderItem WHERE TempOrderItem_SupplierID = " + adoPrimaryRS.Fields("SupplierID").Value);
			modRecordSet.cnnDB.Execute("DELETE FROM TempOrder WHERE  TempOrder_SupplierID = " + adoPrimaryRS.Fields("SupplierID").Value);

			modRecordSet.cnnDB.Execute("INSERT INTO TempOrder ( TempOrder_SupplierID, TempOrder_DayEndID, TempOrder_DateCreated, TempOrder_Reference, TempOrder_AttentionLine ) SELECT Supplier.SupplierID, Company.Company_DayEndID, Now(), '" + Strings.Format(DateAndTime.Now, "dd mmm\", \"yyyy") + "', Supplier.Supplier_OrderAttentionLine From Supplier, Company WHERE (((Supplier.SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");

			//cnnDB.Execute "INSERT INTO TempOrderItem ( TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity ) SELECT tempOrderGenerate.tempGenerate_SupplierID, tempOrderGenerate.tempGenerate_StockItemID, 1 AS Expr1, tempOrderGenerate.tempGenerate_Total, 0 AS Expr2 From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS("SupplierID") & "));"
			modRecordSet.cnnDB.Execute("INSERT INTO TempOrderItem ( TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity, TempOrderItem_ContentCost ) SELECT tempOrderGenerate.tempGenerate_SupplierID, tempOrderGenerate.tempGenerate_StockItemID, 1 AS Expr1, tempOrderGenerate.tempGenerate_Total, 0 AS Expr2, StockItem.StockItem_ListCost FROM tempOrderGenerate INNER JOIN StockItem ON tempOrderGenerate.tempGenerate_StockItemID = StockItem.StockItemID WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");
			modRecordSet.cnnDB.Execute("DELETE TempOrderItem.* FROM TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((StockItem.StockItem_OrderQuantity)=0)) OR (((TempOrderItem.TempOrderItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + ") AND ((StockItem.StockItem_OrderRounding)=0));");

			modRecordSet.cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_QuantityRequired = CInt([TempOrderItem_QuantityRequired]/([StockItem_OrderQuantity]*[StockItem_OrderRounding])+0.49)*[StockItem_OrderQuantity]*[StockItem_OrderRounding] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");
			modRecordSet.cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_Quantity = CInt(([TempOrderItem_QuantityRequired]+([StockItem_OrderQuantity]-1)/2)/[StockItem_OrderQuantity]), TempOrderItem.TempOrderItem_PackSize = [StockItem]![StockItem_OrderQuantity] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");
			frmOrderItem form = new frmOrderItem();
			form.Show();
			if (this.Visible) {
				cmdEdit_Enabled();
			} else {
				this.Close();
			}

		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case mdSupplier:
					this.Close();
					break;
				case mdProcess:
					doMode(ref mdSupplier);
					break;
			}
		}

		private void cmdBlank_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("DELETE FROM TempOrderItem WHERE TempOrderItem_SupplierID = " + DataList1.BoundText);
			modRecordSet.cnnDB.Execute("DELETE FROM TempOrder WHERE  TempOrder_SupplierID = " + DataList1.BoundText);

			modRecordSet.cnnDB.Execute("INSERT INTO TempOrder ( TempOrder_SupplierID, TempOrder_DayEndID, TempOrder_DateCreated, TempOrder_Reference, TempOrder_AttentionLine ) SELECT Supplier.SupplierID, Company.Company_DayEndID, Now(), '" + Strings.Format(DateAndTime.Now, "dd mmm\", \"yyyy") + "', Supplier.Supplier_OrderAttentionLine From Supplier, Company WHERE (((Supplier.SupplierID)=" + DataList1.BoundText + "));");
			frmOrderItem form2 = new frmOrderItem();
			form2.Show();
			if (this.Visible) {
				cmdEdit_Enabled();
			} else {
				this.Close();
			}

		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmOrderItem form = new frmOrderItem();
			form.Show();
			if (this.Visible) {
				cmdEdit_Enabled();
			} else {
				this.Close();
			}
		}

		private void InformationReport(ref bool ltype)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short lDays = 0;
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			//Dim Report As New crySupplierOrderInformation
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crySupplierOrderInformation.rpt");
			if (string.IsNullOrEmpty(this.DataList1.BoundText))
				return;
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			lDays = 10;
			modRecordSet.cnnDB.Execute("UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Value = 0;");
			modRecordSet.cnnDB.Execute("UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Value = [StockitemHistory]![StockitemHistory_Day11]+[StockitemHistory]![StockitemHistory_Day2]+[StockitemHistory]![StockitemHistory_Day3]+[StockitemHistory]![StockitemHistory_Day4]+[StockitemHistory]![StockitemHistory_Day5]+[StockitemHistory]![StockitemHistory_Day6]+[StockitemHistory]![StockitemHistory_Day7]+[StockitemHistory]![StockitemHistory_Day8]+[StockitemHistory]![StockitemHistory_Day9]+[StockitemHistory]![StockitemHistory_Day10];");

			modRecordSet.cnnDB.Execute("UPDATE Company, StockBreakTransaction INNER JOIN StockitemHistory ON StockBreakTransaction.StockBreakTransaction_ParentID = StockitemHistory.StockitemHistory_StockItemID SET StockitemHistory.StockitemHistory_Value = [StockitemHistory_Value]+[StockBreakTransaction_MoveQuantity] WHERE ((([Company_DayEndID]-[StockBreakTransaction_DayEndID]+1)<=" + lDays + "));");
			modRecordSet.cnnDB.Execute("UPDATE Company, StockBreakTransaction INNER JOIN StockitemHistory ON StockBreakTransaction.StockBreakTransaction_ChildID = StockitemHistory.StockitemHistory_StockItemID SET StockitemHistory.StockitemHistory_Value = [StockitemHistory_Value]-([StockBreakTransaction_MoveQuantity]*[StockBreakTransaction_Quantity]) WHERE ((([Company_DayEndID]-[StockBreakTransaction_DayEndID]+1)<=" + lDays + "));");
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			if (ltype) {
				sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockItem.StockItem_SupplierID, StockitemHistory.StockitemHistory_Value, StockItem.StockItem_Name, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity FROM WarehouseStockItemLnk INNER JOIN (StockitemHistory INNER JOIN StockItem ON StockitemHistory.StockitemHistory_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2 And StockItem.StockItem_SupplierID = " + this.DataList1.BoundText + " AND StockItem.StockItem_Discontinued=0  And (WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity <= [StockitemHistory]![StockitemHistory_Value]) ORDER BY StockItem.StockItem_Name;";
			} else {
				sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockItem.StockItem_SupplierID, StockitemHistory.StockitemHistory_Value, StockItem.StockItem_Name, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity FROM WarehouseStockItemLnk INNER JOIN (StockitemHistory INNER JOIN StockItem ON StockitemHistory.StockitemHistory_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2 And StockItem.StockItem_SupplierID = " + this.DataList1.BoundText + " AND StockItem.StockItem_Discontinued=0 ORDER BY StockItem.StockItem_Name;";
			}
			RSitem = modRecordSet.getRS(ref sql);
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (RSitem.BOF | RSitem.EOF) {
				ReportNone.SetParameterValue("txtCompanyName.", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			rs = modRecordSet.getRS(ref "SELECT * From Supplier WHERE SupplierID=" + this.DataList1.BoundText);
			Report.Database.Tables(1).SetDataSource(RSitem);
			Report.Database.Tables(2).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}


		private void cmdInformation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = cmdInformation.GetIndex(eventSender)
			int Index = 0;
			Button n = new Button();
			n = (Button)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref cmdInformation);
			InformationReport(ref Convert.ToBoolean(Index));
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case mdSupplier:
					if (!string.IsNullOrEmpty(DataList1.BoundText)) {
						doMode(ref mdProcess);
					}
					break;
				case mdProcess:
					this.Close();
					break;
			}
		}

		private void DataList1_DblClick(System.Object eventSender, KeyEventArgs eventArgs)
		{
			cmdNext_Click(cmdNext, new System.EventArgs());
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
				case Strings.ChrW(27):
					eventArgs.KeyChar = Strings.ChrW(0);
					cmdExit_Click();
					break;
			}

		}

		private void frmOrder_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmOrder_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdInformation.AddRange(new Button[] {
				_cmdInformation_0,
				_cmdInformation_1
			});
			frmMode.AddRange(new GroupBox[] {
				_frmMode_0,
				_frmMode_1
			});
			lblLabels.AddRange(new Label[] {
				_lblLabels_2,
				_lblLabels_36,
				_lblLabels_37,
				_lblLabels_38,
				_lblLabels_6,
				_lblLabels_7,
				_lblLabels_8,
				_lblLabels_9
			});
			lblData.AddRange(new Label[] {
				_lblData_0,
				_lblData_1,
				_lblData_2,
				_lblData_3,
				_lblData_4,
				_lblData_5,
				_lblData_6,
				_lblData_7
			});
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdInformation) {
				bt = bt_loopVariable;
				bt.Click += cmdInformation_Click;
			}
			loadLanguage();
			doMode(ref mdSupplier);
		}

		private void frmOrder_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					this.DataList1.Focus();
					break;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void doSearch()
		{
			string sql = null;
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (Supplier_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND Supplier_Name LIKE '%") + "%')";
			}
			if (string.IsNullOrEmpty(lString)) {
				lString = " WHERE Supplier_Disabled = 0 ";
			} else {
				lString = lString + " AND Supplier_Disabled = 0 ";
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier " + lString + " ORDER BY Supplier_Name");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.Columns[0].DataPropertyName = "Supplier_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.Columns[0].DataPropertyName = "SupplierID";

		}
	}
}
