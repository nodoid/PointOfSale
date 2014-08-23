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
	internal partial class frmStockBreakShrink : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;

		private void loadLanguage()
		{

			//frmStockBreakShrink = No Code  [Break a Stock Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockBreakShrink.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBreakShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code               [Quantity to move]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdMove = No Code              [Move]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdMove.Caption = rsLang("LanguageLayoutLnk_Description"): cmdMove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockBreakShrink.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{
			Button cmdNew = new Button();
			cmdNew.Visible = false;

			loadLanguage();
			this.ShowDialog();
			return gID;

		}

		private void getNamespace()
		{
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNamespace_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}


		private void DataList1_DblClick()
		{
			object cmdNew = null;
			object DataList1 = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object cmdNew.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (cmdNew.Visible) {
				//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					My.MyProject.Forms.frmStockGroup.loadItem(ref DataList1.BoundText);
				}
				doSearch();
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(DataList1.BoundText)) {
					gID = 0;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					gID = DataList1.BoundText;
				}
				switch (gSection) {
					case 0:
						this.Close();
						break;
					case 1:
						//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modApplication.report_StockTake(DataList1.BoundText);
						break;
					case 2:
						//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						My.MyProject.Forms.frmStockTake.loadItem(ref DataList1.BoundText);
						break;
					case 3:
						//UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modApplication.report_StockQuantityData(ref DataList1.BoundText);
						break;
				}
			}
		}

		private void DataList1_KeyPress(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case 13:
					DataList1_DblClick();
					KeyAscii = 0;
					break;
				case 27:
					this.Close();
					KeyAscii = 0;
					break;
			}

		}

		private void cmdMove_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lParent = 0;
			int lChild = 0;
			lParent = Convert.ToInt32(Strings.Split(lblData.Tag, "_")[0]);
			lChild = Convert.ToInt32(Strings.Split(lblData.Tag, "_")[1]);
			short lQty = 0;
			lQty = Convert.ToInt16(this.txtQuantity.Text);
			if (lQty) {
				if (Interaction.MsgBox("Are you sure to want to commit this conversion?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "COMMIT CONVERSION") == MsgBoxResult.Yes) {
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]-" + lQty + " WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + lParent + "));");
					modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-" + lQty + " WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lParent + "));");

					//UPGRADE_WARNING: Lower bound of collection Me.lvStock.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lQty = lQty * Convert.ToDouble(this.lvStock.FocusedItem.SubItems[4].Text);

					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+" + lQty + " WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + lChild + "));");
					modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]+" + lQty + " WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lChild + "));");

					modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN (StockBreak INNER JOIN StockItem AS StockItem_1 ON StockBreak.StockBreak_ChildID = StockItem_1.StockItemID) ON StockItem.StockItemID = StockBreak.StockBreak_ParentID SET StockItem_1.StockItem_ActualCost = [StockItem!StockItem_ActualCost]/CLng([StockItem!StockItem_Quantity])/CLng([StockBreak!StockBreak_Quantity]), StockItem_1.StockItem_ListCost = [StockItem!StockItem_ListCost]/CLng([StockItem!StockItem_Quantity])/CLng([StockBreak!StockBreak_Quantity]) WHERE (((StockItem.StockItemID)=" + lParent + ") AND ((StockItem_1.StockItemID)=" + lChild + "));");

					modRecordSet.cnnDB.Execute("INSERT INTO StockBreakTransaction ( StockBreakTransaction_ParentID, StockBreakTransaction_ChildID, StockBreakTransaction_DayEndID, StockBreakTransaction_Quantity, StockBreakTransaction_MoveQuantity ) SELECT StockBreak.StockBreak_ParentID, StockBreak.StockBreak_ChildID, Company.Company_DayEndID, StockBreak.StockBreak_Quantity, " + Convert.ToInt16(this.txtQuantity.Text) + " AS moveQty From Company, StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" + lParent + ") AND ((StockBreak.StockBreak_ChildID)=" + lChild + "));");


					doSearch();
				}
			} else {
				Interaction.MsgBox("Stock Item Move Quantity is ZERO!", MsgBoxStyle.Exclamation, "STOCK ITEM CONVERSION");
				this.txtQuantity.Focus();
			}

		}

		private void frmStockBreakShrink_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		public void loadItem(ref short section)
		{
			object cmdNew = null;
			gSection = section;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdNew.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (gSection)
				cmdNew.Visible = false;
			doSearch();

			loadLanguage();
			this.ShowDialog();
		}

		private void frmStockBreakShrink_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lvStock.Columns.Add("", "From Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(3800, true)));
			lvStock.Columns.Add("QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(800, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvStock.Columns.Add("", "To Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(3750, true)));
			lvStock.Columns.Add("QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(800, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvStock.Columns.Add("Move", Convert.ToInt32(sizeConvertors.twipsToPixels(600, true)), System.Windows.Forms.HorizontalAlignment.Right);
		}

		private void frmStockBreakShrink_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		private void lvStock_ItemClick(System.Windows.Forms.ListViewItem Item)
		{
			this.lblData.Text = "Remove one unit of '" + lvStock.FocusedItem.Text + "' and create " + lvStock.FocusedItem.SubItems[4].Text + " units of '" + lvStock.FocusedItem.SubItems[2].Text + "'.";
			this.lblData.Tag = lvStock.FocusedItem.Name;
		}

		private void lvStock_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				this.txtQuantity.Focus();
				KeyAscii = 0;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQuantity_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQuantity);
		}

		private void txtQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				this.cmdMove.Focus();
				KeyAscii = 0;
			} else {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQuantity_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtQuantity, ref 0);
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
					this.lvStock.Focus();
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
				lString = " AND (StockItem.StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem.StockItem_Name LIKE '%") + "%')";
			}
			lString = " WHERE StockBreak.StockBreak_Disabled=0 AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID=2 AND WarehouseStockItemLnk_1.WarehouseStockItemLnk_WarehouseID=2 " + lString;
			gRS = modRecordSet.getRS(ref "SELECT StockBreak.StockBreak_Quantity, StockBreak.StockBreak_ParentID, StockItem.StockItem_Name, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, StockBreak.StockBreak_ChildID, StockItemChild.StockItem_Name AS StockItemChild_Name, WarehouseStockItemLnk_1.WarehouseStockItemLnk_Quantity AS WarehouseStockItemLnkChild_Quantity FROM WarehouseStockItemLnk AS WarehouseStockItemLnk_1 INNER JOIN (WarehouseStockItemLnk INNER JOIN ((StockBreak INNER JOIN StockItem ON StockBreak.StockBreak_ParentID = StockItem.StockItemID) INNER JOIN StockItem AS StockItemChild ON StockBreak.StockBreak_ChildID = StockItemChild.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk_1.WarehouseStockItemLnk_StockItemID = StockItemChild.StockItemID " + lString + " ORDER BY StockItem.StockItem_Name");
			lvStock.Items.Clear();
			while (!(gRS.EOF)) {
				listItem = lvStock.Items.Add(gRS.Fields("StockBreak_ParentID").Value + "_" + gRS.Fields("StockBreak_ChildID").Value, gRS.Fields("StockItem_Name").Value, "");
				if (listItem.SubItems.Count > 0) {
					listItem.SubItems[0].Text = gRS.Fields("WarehouseStockItemLnk_Quantity").Value;
				} else {
					listItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, gRS.Fields("WarehouseStockItemLnk_Quantity").Value));
				}
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = gRS.Fields("StockItemChild_Name").Value;
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, gRS.Fields("StockItemChild_Name").Value));
				}
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = gRS.Fields("WarehouseStockItemLnkChild_Quantity").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, gRS.Fields("WarehouseStockItemLnkChild_Quantity").Value));
				}
				if (listItem.SubItems.Count > 3) {
					listItem.SubItems[3].Text = gRS.Fields("StockBreak_Quantity").Value;
				} else {
					listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, gRS.Fields("StockBreak_Quantity").Value));
				}

				gRS.moveNext();
			}
			if (lvStock.FocusedItem == null) {
				this.lblData.Text = "";
				picMove.Visible = false;
			} else {
				//UPGRADE_ISSUE: MSComctlLib.ListView event lvStock.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
				lvStock_ItemClick(lvStock.FocusedItem);
				picMove.Visible = true;
			}
		}
	}
}
