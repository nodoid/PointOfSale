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
	internal partial class frmOrderSummary : System.Windows.Forms.Form
	{
		ADODB.Recordset adoPrimaryRS;
		List<Label> lblLabels = new List<Label>();
		List<Label> lbl = new List<Label>();
		List<TextBox> txtFields = new List<TextBox>();
		List<Label> lblData = new List<Label>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1594;
			//Complete Order|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1458;
			//Ordering Details|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1455;
			//Representative Name|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[38].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[38].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1456;
			//Representative Number|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[37].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[37].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1457;
			//Account Number|Checked
			if (modRecordSet.rsLang.RecordCount){lblLabels[36].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblLabels[36].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmOrder = No Code     [Order Totals]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1605;
			//Content Total|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1606;
			//Deposit Total|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1607;
			//Order Exclusive Total|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1608;
			//Process this Order|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[8].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[8].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1609;
			//Order Reference|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1610;
			//Order Attention Line|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1332;
			//Process|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrderSummary.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void doTotals()
		{
			decimal lContent = default(decimal);
			decimal lQuantity = default(decimal);
			decimal lDeposit = default(decimal);
			lContent = Convert.ToDecimal(My.MyProject.Forms.frmOrderItem.lblContent.Text);
			lDeposit = Convert.ToDecimal(My.MyProject.Forms.frmOrderItem.lblDeposit.Text);
			this.lblContentTotal.Text = Strings.FormatNumber(lContent, 2);
			lblDepositTotal.Text = Strings.FormatNumber(lDeposit, 2);
			lblTotal.Text = Strings.FormatNumber(lContent + lDeposit, 2);
		}



		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Application.DoEvents();
			this.Close();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Application.DoEvents();
			this.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmOrderItem.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmOrder.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int gID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsComp = default(ADODB.Recordset);

			string sql = null;
			if (Interaction.MsgBox("You are about to commit this order." + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Commit Order") == MsgBoxResult.Yes) {
				update_Renamed();
				modRecordSet.cnnDB.Execute("INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_DateCreated, PurchaseOrder_DatePosted, PurchaseOrder_Reference, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_AttentionLine ) SELECT TempOrder.TempOrder_SupplierID, Company.Company_DayEndID, TempOrder.TempOrder_DateCreated, Now() AS [date], TempOrder.TempOrder_Reference, 1 AS Status, TempOrder.TempOrder_AttentionLine From TempOrder, Company WHERE (((TempOrder.TempOrder_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));");
				rs = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");

				gID = rs.Fields("id").Value;

				//sql = "INSERT INTO PurchaseOrderItem ( PurchaseOrderItem_PurchaseOrderID, PurchaseOrderItem_StockItemID, PurchaseOrderItem_PackSize, PurchaseOrderItem_QuantityRequired, PurchaseOrderItem_Quantity, PurchaseOrderItem_QuantityDelivered, PurchaseOrderItem_DepositUnitCost, PurchaseOrderItem_DepositPackCost, PurchaseOrderItem_DepositCost, PurchaseOrderItem_ContentCost ) SELECT " & gID & " AS purchaseOrder, TempOrderItem.TempOrderItem_StockItemID, TempOrderItem.TempOrderItem_PackSize, TempOrderItem.TempOrderItem_QuantityRequired, TempOrderItem.TempOrderItem_Quantity, 0 AS delivered, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, (Abs([TempOrderItem_PackSize]=[StockItem_Quantity])*[Deposit_CaseCost])+([TempOrderItem_PackSize]*[Deposit_UnitCost]) AS deposit, [StockItem_ListCost] AS content "
				sql = "INSERT INTO PurchaseOrderItem ( PurchaseOrderItem_PurchaseOrderID, PurchaseOrderItem_StockItemID, PurchaseOrderItem_PackSize, PurchaseOrderItem_QuantityRequired, PurchaseOrderItem_Quantity, PurchaseOrderItem_QuantityDelivered, PurchaseOrderItem_DepositUnitCost, PurchaseOrderItem_DepositPackCost, PurchaseOrderItem_DepositCost, PurchaseOrderItem_ContentCost ) SELECT " + gID + " AS purchaseOrder, TempOrderItem.TempOrderItem_StockItemID, TempOrderItem.TempOrderItem_PackSize, TempOrderItem.TempOrderItem_QuantityRequired, TempOrderItem.TempOrderItem_Quantity, 0 AS delivered, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, (Abs([TempOrderItem_PackSize]=[StockItem_Quantity])*[Deposit_CaseCost])+([TempOrderItem_PackSize]*[Deposit_UnitCost]) AS deposit, TempOrderItem.TempOrderItem_ContentCost AS content ";
				sql = sql + "FROM (StockItem INNER JOIN TempOrderItem ON StockItem.StockItemID = TempOrderItem.TempOrderItem_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + adoPrimaryRS.Fields("SupplierID").Value + "));";
				modRecordSet.cnnDB.Execute(sql);

				rsComp = modRecordSet.getRS(ref "SELECT Company_POPrintBC FROM Company;");
				if (rsComp.RecordCount) {
					if ((Information.IsDBNull(rsComp.Fields("Company_POPrintBC").Value) ? false : rsComp.Fields("Company_POPrintBC").Value)) {
						//cnnDB.Execute "UPDATE PurchaseOrderItem INNER JOIN Catalogue ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = Catalogue.Catalogue_StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Code = [Catalogue]![Catalogue_Barcode] WHERE (((Catalogue.Catalogue_Quantity)=1) AND ((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & gID & "));"
						modRecordSet.cnnDB.Execute("UPDATE (PurchaseOrderItem INNER JOIN Catalogue ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = [Catalogue]![Catalogue_Barcode] WHERE (((Catalogue.Catalogue_Quantity)=1) AND ((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" + gID + "));");
					} else {
						modRecordSet.cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = '' WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" + gID + "));");
						modRecordSet.cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN BrandItemSupplier ON StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) INNER JOIN PurchaseOrder ON (PurchaseOrder.PurchaseOrderID = PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID) AND (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) SET PurchaseOrderItem.PurchaseOrderItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((PurchaseOrder.PurchaseOrderID)=" + gID + "));");
					}
				} else {
					modRecordSet.cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = '' WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" + gID + "));");
					modRecordSet.cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN BrandItemSupplier ON StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) INNER JOIN PurchaseOrder ON (PurchaseOrder.PurchaseOrderID = PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID) AND (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) SET PurchaseOrderItem.PurchaseOrderItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((PurchaseOrder.PurchaseOrderID)=" + gID + "));");
				}

				modRecordSet.cnnDB.Execute("DELETE FROM TempOrderItem WHERE (TempOrderItem_SupplierID = " + adoPrimaryRS.Fields("SupplierID").Value + ")");
				modRecordSet.cnnDB.Execute("DELETE FROM TempOrder WHERE (TempOrder_SupplierID = " + adoPrimaryRS.Fields("SupplierID").Value + ")");

				modApplication.report_PurchaseOrder(ref gID);
				cmdExit_Click(cmdExit, new System.EventArgs());

			}
		}

		private void frmOrderSummary_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblLabels.AddRange(new Label[] {
				_lblLabels_36,
				_lblLabels_37,
				_lblLabels_38,
				_lblLabels_6,
				_lblLabels_7,
				_lblLabels_8,
				_lblLabels_8,
				_lblLabels_9
			});
			lbl.AddRange(new Label[] {
				_lbl_0,
				_lbl_1,
				_lbl_2,
				_lbl_3,
				_lbl_4,
				_lbl_5,
				_lbl_6,
				_lbl_7,
				_lbl_8
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
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			System.Windows.Forms.Label oLabel = null;
			System.Windows.Forms.TextBox oText = null;
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT Supplier.*, TempOrder.* FROM Supplier INNER JOIN TempOrder ON Supplier.SupplierID = TempOrder.TempOrder_SupplierID WHERE (((Supplier.SupplierID)=" + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + "));");
			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			foreach (Label oLabel_loopVariable in this.lblData) {
				oLabel = oLabel_loopVariable;
				oLabel.DataBindings.Add(adoPrimaryRS);
			}

			loadLanguage();
			doTotals();
		}

		private void frmOrderSummary_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			update_Renamed();
		}

		private void update_Renamed()
		{
			//  On Error GoTo UpdateErr
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			return;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}
	}
}
