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
namespace _4PosBackOffice.NET
{
	internal partial class frmStockItemHistory : System.Windows.Forms.Form
	{
		ADODB.Recordset adoPrimaryRS;
		int gID;
		List<Label> lblField = new List<Label>();
		private void loadLanguage()
		{

			//frmStockItemHistory = No Code  [Stock Item Sales History]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockItemHistory.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItemHistory.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblField_0 = No Code/Dynamic!

			//Label1(15) = No Code           [Current Units in Stock]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(15).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(15).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(16) = No Code           [Cases in Stock]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(16).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(17) = No Code           [Units per Case]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(17).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code            [Daily]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code            [Weekly]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code            [Monthly]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockItemHistory.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.Label oLabel = null;
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lQty = 0;
			rs = modRecordSet.getRS(ref "SELECT StockitemHistory.StockitemHistory_StockItemID From StockitemHistory WHERE (((StockitemHistory.StockitemHistory_StockItemID)=" + id + "));");
			if (rs.RecordCount == 0) {
				sql = "INSERT INTO StockitemHistory (StockitemHistory_StockItemID,  StockitemHistory_Value, StockitemHistory_Day1, StockitemHistory_Day2, StockitemHistory_Day3, StockitemHistory_Day4, StockitemHistory_Day5, StockitemHistory_Day6, StockitemHistory_Day7, StockitemHistory_Day8, StockitemHistory_Day9, StockitemHistory_Day10, StockitemHistory_Day11, StockitemHistory_Day12, StockitemHistory_Week1, StockitemHistory_Week2, StockitemHistory_Week3, StockitemHistory_Week4, StockitemHistory_Week5, StockitemHistory_Week6, StockitemHistory_Week7, StockitemHistory_Week8, StockitemHistory_Week9, StockitemHistory_Week10, StockitemHistory_Week11, StockitemHistory_Week12, StockitemHistory_Month1, StockitemHistory_Month2, StockitemHistory_Month3, StockitemHistory_Month4, StockitemHistory_Month5, StockitemHistory_Month6, StockitemHistory_Month7, StockitemHistory_Month8, StockitemHistory_Month9, StockitemHistory_Month10, StockitemHistory_Month11, StockitemHistory_Month12 )";
				sql = sql + " SELECT " + id + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;";
				modRecordSet.cnnDB.Execute(sql);
			}
			//    Set rs = getRS("SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY SaleItem.SaleItem_StockItemID HAVING (((SaleItem.SaleItem_StockItemID)=" & id & "));")
			sql = "SELECT Sum(sales.qty) AS SumOfqty FROM (SELECT SaleItem.SaleItem_StockItemID, (IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_StockItemID) = " + id + ") And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) Union SELECT SaleItemReciept.SaleItemReciept_StockitemID AS SaleItem_StockItemID, IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity]) AS qty ";
			sql = sql + "FROM (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN SaleItemReciept ON SaleItem.SaleItemID = SaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItemReciept.SaleItemReciept_StockitemID)=" + id + ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((SaleItem.SaleItem_Recipe)<>0))) AS sales;";
			//wrong calculation cuz DayEndID = MonthEndID
			//sql = "SELECT Sum(sales.qty) AS SumOfqty FROM (SELECT SaleItem.SaleItem_StockItemID, (IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_StockItemID) = " & id & ") And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) Union SELECT SaleItemReciept.SaleItemReciept_StockitemID AS SaleItem_StockItemID, IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity]) AS qty "
			//sql = sql & "FROM (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN SaleItemReciept ON SaleItem.SaleItemID = SaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItemReciept.SaleItemReciept_StockitemID)=" & id & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((SaleItem.SaleItem_Recipe)<>0))) AS sales;"

			rs = modRecordSet.getRS(ref sql);
			if (rs.RecordCount) {
				lQty = Convert.ToInt32(0 + rs.Fields("SumOfqty").Value);
			} else {
				lQty = 0;
			}



			sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, CCur([WarehouseStockItemLnk_Quantity]/[StockItem_Quantity]) AS cases, StockitemHistory.*, [StockitemHistory_Week1]+" + lQty + " AS thisWeek, [StockitemHistory_Month1]+" + lQty + " AS thisMonth, " + lQty + " AS thisDay FROM (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID=2 AND StockItem.StockItemID=" + id + ";";
			//sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, CCur([WarehouseStockItemLnk_Quantity]/[StockItem_Quantity]) AS cases, StockitemHistory.*, [StockitemHistory_Week1]+" & lQty & " AS thisWeek, [StockitemHistory_Month1]+" & lQty & " AS thisMonth, " & lQty & " AS thisDay FROM (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE StockItem.StockItemID=" & id & ";"


			adoPrimaryRS = modRecordSet.getRS(ref sql);
			if (adoPrimaryRS.RecordCount == 0) {
				return;
			}
			foreach (Label oLabel_loopVariable in this.lblField) {
				oLabel = oLabel_loopVariable;
				oLabel.DataBindings.Add(adoPrimaryRS);
			}

			this._lblFieldCurr_0.Text = Strings.FormatNumber(adoPrimaryRS.Fields("cases").Value, 2);

			loadLanguage();
			ShowDialog();
		}

		private void frmStockItemHistory_Load(object sender, System.EventArgs e)
		{
			lblField.AddRange(new Label[] {
				_lblField_0,
				_lblField_1,
				_lblField_2,
				_lblField_3,
				_lblField_4,
				_lblField_5,
				_lblField_6,
				_lblField_7,
				_lblField_8,
				_lblField_9,
				_lblField_10,
				_lblField_11,
				_lblField_12,
				_lblField_13,
				_lblField_14,
				_lblField_15,
				_lblField_16,
				_lblField_16,
				_lblField_17,
				_lblField_18,
				_lblField_19,
				_lblField_20,
				_lblField_21,
				_lblField_22,
				_lblField_23,
				_lblField_24,
				_lblField_25,
				_lblField_26,
				_lblField_27,
				_lblField_28,
				_lblField_29,
				_lblField_30,
				_lblField_31,
				_lblField_32,
				_lblField_33,
				_lblField_34,
				_lblField_35,
				_lblField_36,
				_lblField_37,
				_lblField_38
			});
		}


//UPGRADE_WARNING: Event frmStockItemHistory.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockItemHistory_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdnext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdnext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdnext.Left + 340;
		}
		private void frmStockItemHistory_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					adoPrimaryRS.Move(0);
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockItemHistory_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}


		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
	}
}
