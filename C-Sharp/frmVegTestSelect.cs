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
	internal partial class frmVegTestSelect : System.Windows.Forms.Form
	{
		string testType;
		int testID;
		bool gAll;

		public void loadTest(ref string tType, ref int tID)
		{
			doSearch();
			ShowDialog();

			tType = testType;
			tID = testID;
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);

			if (this.lvImport.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to delete the selected Production Test", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {

					rs = modRecordSet.getRS(ref "SELECT * FROM VegTest WHERE VegTest.VegTestID =" + Strings.Mid(this.lvImport.FocusedItem.Name, 2) + ";");
					if (rs.Fields("VegTest_VegTestStatusID").Value == 3) {
						Interaction.MsgBox("You may not delete Processed Production Test!");
					} else {
						modRecordSet.cnnDB.Execute("DELETE * FROM VegTest WHERE VegTest.VegTestID =" + Strings.Mid(this.lvImport.FocusedItem.Name, 2));
						modRecordSet.cnnDB.Execute("DELETE * FROM VegTestItem WHERE VegTestItem_VegTestID =" + Strings.Mid(this.lvImport.FocusedItem.Name, 2));
					}
					doSearch();
				}
			}

		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (this.lvImport.FocusedItem == null) {
			} else {
				testType = "load";
				testID = Convert.ToInt32(Strings.Mid(this.lvImport.FocusedItem.Name, 2));
				this.Close();
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			testType = "exit";
			testID = 0;
			this.Close();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			testType = "new";
			testID = 0;
			this.Close();
		}


		private void doSearch()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			string lString = null;
			System.Windows.Forms.ListViewItem listItem = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = " AND (VegTest.VegTest_Desc LIKE '%" + Strings.Replace(lString, " ", "%' AND VegTest.VegTest_Desc LIKE '%") + "%')";
			}

			if (gAll) {
				rs = modRecordSet.getRS(ref "SELECT VegTest.VegTestID, VegTest.VegTest_Date, VegTest.VegTest_MainItemID, VegTest.VegTest_PersonID, VegTest.VegTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, VegTest.VegTest_VegTestStatusID FROM (VegTest INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID) INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID WHERE ((VegTest.VegTest_VegTestStatusID)>0) " + lString + " ORDER BY VegTest.VegTestID DESC;");
			} else {
				rs = modRecordSet.getRS(ref "SELECT VegTest.VegTestID, VegTest.VegTest_Date, VegTest.VegTest_MainItemID, VegTest.VegTest_PersonID, VegTest.VegTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, VegTest.VegTest_VegTestStatusID FROM (VegTest INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID) INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID WHERE ((VegTest.VegTest_VegTestStatusID)<>3) " + lString + " ORDER BY VegTest.VegTestID DESC;");
			}
			//Set rs = getRS("SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " & lString & " ORDER BY Supplier.Supplier_Name;")
			 // ERROR: Not supported in C#: OnErrorStatement

			lvImport.Items.Clear();
			while (!(rs.EOF)) {
				listItem = this.lvImport.Items.Add("k" + rs("VegTestID").Value, rs("VegTest_Desc").Value, "");
				cmddelete.Enabled = true;
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = Strings.Format(rs("VegTest_Date"), "yyyy mmm dd");
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs("VegTest_Date"), "yyyy mmm dd")));
				}
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = rs("Person_FirstName").Value + " " + rs("Person_LastName").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs("Person_FirstName").Value + " " + rs("Person_LastName").Value));
				}
				//If IsNull(rs("GRV_InvoiceInclusive")) Then
				//Else
				if (listItem.SubItems.Count > 3) {
					listItem.SubItems[3].Text = rs("StockItem_Name");
				} else {
					listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs("StockItem_Name")));
				}
				//    listItem.SubItems(4) = FormatNumber(rs("GRV_InvoiceInclusive"), 2)
				//End If
				rs.moveNext();
			}

		}

		private void cmdRepair_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmMakeRepairItem.makeItem();
		}

		private void cmdRevST_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				rs = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity From WarehouseStockItemLnk Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + lID + "));");
				if (rs.RecordCount) {
					if (rs.Fields("Warehouse_StockItemQuantity").Value > 0) {
						My.MyProject.Forms.frmVegTestStockBack.loadItem(lID, rs.Fields("Warehouse_StockItemQuantity").Value);
					} else {
						Interaction.MsgBox("Insufficient Qty!");
						return;
					}
				} else {
					Interaction.MsgBox("Insufficient Qty!");
					return;
				}
				//
			}
		}

		private void frmVegTestSelect_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
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

		private void lvImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string HoldGrvID = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			//*Get the following fields
			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT GRV.GRVID,GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive,GRVItem.GRVItem_GRVID FROM ((GRV INNER JOIN GRVItem ON GRV.GRVID=GRVItem.GRVItem_GRVID))");

			//*Get the GRVID of the select GRV,Remove letter K from It and hold it.
			HoldGrvID = Strings.Split(lvImport.FocusedItem.Name, "_")[0];
			HoldGrvID = Strings.Mid(HoldGrvID, 2);

			//Set rs = getRS("SELECT GRV_InvoiceNumber FROM GRV WHERE GRVID=" & HoldGrvID)
			//HoldGrvNo = rs("GRV_InvoiceNumber")

			//HoldName = lvImport.SelectedItem
		}

		private void lvImport_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdEdit_Click(cmdEdit, new System.EventArgs());
		}

		private void lvImport_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13)
				cmdEdit_Click(cmdEdit, new System.EventArgs());
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}


		private void loadBT()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem listItem = null;
			lvImport.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID;");
			while (!(rs.EOF)) {
				listItem = this.lvImport.Items.Add("k" + rs.Fields("stockitemID").Value, rs.Fields("GRVimport_Barcode").Value, "");
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = rs.Fields("StockItem_Name").Value;
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_Name").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = rs.Fields("Catalogue_Quantity").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("Catalogue_Quantity").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 3) {
					listItem.SubItems[3].Text = rs.Fields("GRVimport_Quantity").Value;
				} else {
					listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Quantity").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 4) {
					listItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2);
				} else {
					listItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 5) {
					listItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2);
				} else {
					listItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2)));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 6) {
					listItem.SubItems[6].Text = rs.Fields("GRVimport_Key").Value;
				} else {
					listItem.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Key").Value));
				}
				rs.moveNext();
			}
		}
	}
}
