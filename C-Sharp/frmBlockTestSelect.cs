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
	internal partial class frmBlockTestSelect : System.Windows.Forms.Form
	{
		string testType;
		int testID;

		private void loadLanguage()
		{

			//frmBlockTestSelect = No code   [Block Test]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBlockTestSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmBlockTestSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdEdit = No Code              [Load Selected Test]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdEdit.Caption = rsLang("LanguageLayoutLnk_Description"): cmdEdit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdNew = No Code               [Create a N&ew Test]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBlockTestSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadTest(ref string tType, ref int tID)
		{
			doSearch();

			loadLanguage();
			ShowDialog();

			tType = testType;
			tID = testID;
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

		private void cmdNewExist_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			testType = "select";
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
				lString = " AND (BlockTest.BlockTest_Desc LIKE '%" + Strings.Replace(lString, " ", "%' AND BlockTest.BlockTest_Desc LIKE '%") + "%')";
			}

			rs = modRecordSet.getRS(ref "SELECT BlockTest.BlockTestID, BlockTest.BlockTest_Date, BlockTest.BlockTest_MainItemID, BlockTest.BlockTest_PersonID, BlockTest.BlockTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, BlockTest.BlockTest_BlockTestStatusID FROM (BlockTest INNER JOIN Person ON BlockTest.BlockTest_PersonID = Person.PersonID) INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID WHERE ((BlockTest.BlockTest_BlockTestStatusID)>0) " + lString + " ORDER BY BlockTest.BlockTest_Desc;");
			//Set rs = getRS("SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " & lString & " ORDER BY Supplier.Supplier_Name;")
			 // ERROR: Not supported in C#: OnErrorStatement

			lvImport.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object rs.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			while (!(rs.EOF)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(BlockTest_Desc). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				listItem = this.lvImport.Items.Add("k" + rs("BlockTestID").Value, rs("BlockTest_Desc").Value, "");
				cmddelete.Enabled = true;
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = Strings.Format(rs("BlockTest_Date"), "yyyy mmm dd");
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs("BlockTest_Date"), "yyyy mmm dd")));
				}
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(Person_LastName). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = rs("Person_FirstName").Value + " " + rs("Person_LastName").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs("Person_FirstName").Value + " " + rs("Person_LastName").Value));
				}
				//If IsNull(rs("GRV_InvoiceInclusive")) Then
				//Else
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (listItem.SubItems.Count > 3) {
					listItem.SubItems[3].Text = rs("StockItem_Name");
				} else {
					listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs("StockItem_Name")));
				}
				//    listItem.SubItems(4) = FormatNumber(rs("GRV_InvoiceInclusive"), 2)
				//End If
				//UPGRADE_WARNING: Couldn't resolve default property of object rs.moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs.moveNext();
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
