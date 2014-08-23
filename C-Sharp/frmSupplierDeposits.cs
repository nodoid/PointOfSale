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
	internal partial class frmSupplierDeposits : System.Windows.Forms.Form
	{
		bool loading;
		int gID;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1469;
			//Supplier Deposits|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblSupplier = No Code/Dynamic!

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSupplierDeposits.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click()
		{
			this.Close();
		}

		public void loadItem(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvList = null;
			int x = 0;
			int lQuantity = 0;
			short lDepositQuantity = 0;
			decimal lCost = default(decimal);
			decimal lActualCost = default(decimal);
			decimal lDepositUnit = default(decimal);
			decimal lDepositPack = default(decimal);
			System.Windows.Forms.ListViewItem lvItem = null;
			loading = true;
			gID = id;
			rs = modRecordSet.getRS(ref "SELECT * FROM Supplier WHERE SupplierID = " + gID);
			lblSupplier.Text = "Deposits for '" + rs.Fields("Supplier_Name").Value + "'";
			rs.Close();
			lvDeposit.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT * FROM Deposit WHERE (Deposit_Quantity <> 0) and Deposit_Disabled = 0 ORDER BY Deposit_Name");
			while (!(rs.EOF)) {
				if (rs.Fields("Deposit_Quantity").Value == "1") {
					lvList = lvDeposit.Items.Add("k1" + rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "");
					//UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					if (lvList.SubItems.Count > 1) {
						lvList.SubItems[1].Text = "Unit";
					} else {
						lvList.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Unit"));
					}
				} else {
					lvList = lvDeposit.Items.Add("k2" + rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "");
					//UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					if (lvList.SubItems.Count > 1) {
						lvList.SubItems[1].Text = "Crate";
					} else {
						lvList.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Crate"));
					}
					lvList = lvDeposit.Items.Add("k3" + rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "");
					//UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					if (lvList.SubItems.Count > 1) {
						lvList.SubItems[1].Text = "Case";
					} else {
						lvList.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Case"));
					}
				}
				rs.moveNext();
			}
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT SupplierDepositLnk_Type, SupplierDepositLnk_Name, SupplierDepositLnk_DepositID FROM SupplierDepositLnk WHERE (SupplierDepositLnk_SupplierID = " + gID + ")");
			 // ERROR: Not supported in C#: OnErrorStatement


			while (!(rs.EOF)) {
				lvItem = lvDeposit.Items["k" + rs.Fields("SupplierDepositLnk_Type").Value + rs.Fields("SupplierDepositLnk_DepositID").Value];
				if (lvItem == null) {
				} else {
					lvItem.Checked = true;
					//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					if (lvItem.SubItems.Count > 2) {
						lvItem.SubItems[2].Text = rs.Fields("SupplierDepositLnk_Name").Value;
					} else {
						lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("SupplierDepositLnk_Name").Value));
					}
				}

				rs.moveNext();
			}
			rs.Close();

			loading = false;

			loadLanguage();
			this.ShowDialog();

		}


		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmSupplierDeposits_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case System.Windows.Forms.Keys.Escape:
					KeyCode = 0;
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
		}

		private void lvDeposit_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			System.Windows.Forms.ListViewItem Item = lvDeposit.Items[eventArgs.Index];
			string lString = null;
			if (Item.Checked) {
				//UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (Item.SubItems.Count > 2) {
					Item.SubItems[2].Text = Item.Text;
				} else {
					Item.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Item.Text));
				}
				modRecordSet.cnnDB.Execute("INSERT INTO SupplierDepositLnk (SupplierDepositLnk_SupplierID, SupplierDepositLnk_DepositID, SupplierDepositLnk_Type, SupplierDepositLnk_Name) VALUES (" + gID + ", " + Strings.Mid(Item.Name, 3) + ", " + Strings.Mid(Item.Name, 2, 1) + ", '" + Strings.Replace(Item.Text, "'", "''") + "')");
			} else {
				modRecordSet.cnnDB.Execute("DELETE FROM SupplierDepositLnk WHERE SupplierDepositLnk_SupplierID = " + gID + " AND SupplierDepositLnk_DepositID = " + Strings.Mid(lvDeposit.FocusedItem.Name, 3) + " AND SupplierDepositLnk_Type = " + Strings.Mid(lvDeposit.FocusedItem.Name, 2, 1));
				//UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (Item.SubItems.Count > 2) {
					Item.SubItems[2].Text = "";
				} else {
					Item.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, ""));
				}
			}
		}

		private void lvDeposit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);

			string lString = null;
			System.Windows.Forms.ListViewItem lvItem = null;
			if (lvDeposit.FocusedItem == null) {
			} else {
				if (KeyAscii == 13) {
					//UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lString = Interaction.InputBox("Enter The Suppliers Name!", "DEPOSIT", lvDeposit.FocusedItem.SubItems[2].Text);
					if (!string.IsNullOrEmpty(lString)) {
						//UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						if (lString != lvDeposit.FocusedItem.SubItems[2].Text) {
							modRecordSet.cnnDB.Execute("UPDATE SupplierDepositLnk SET SupplierDepositLnk_Name = '" + Strings.Replace(lString, "'", "''") + "' WHERE SupplierDepositLnk_SupplierID = " + gID + " AND SupplierDepositLnk_DepositID = " + Strings.Mid(lvDeposit.FocusedItem.Name, 3) + " AND SupplierDepositLnk_Type = " + Strings.Mid(lvDeposit.FocusedItem.Name, 2, 1));
							//UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							if (lvDeposit.FocusedItem.SubItems.Count > 2) {
								lvDeposit.FocusedItem.SubItems[2].Text = lString;
							} else {
								lvDeposit.FocusedItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, lString));
							}
						}
					}
				}

			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
