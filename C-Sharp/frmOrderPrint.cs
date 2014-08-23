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
	internal partial class frmOrderPrint : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1613;
			//Purchase Order Print|Checked
			if (modRecordSet.rsLang.RecordCount){lblPath.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblPath.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1433;
			//Select a Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1615;
			//Select a Purchase Order|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrderPrint.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void setHeading()
		{
			System.Windows.Forms.ColumnHeader lvHeading = null;
			lvItems.Columns.Clear();
			lvHeading = lvItems.Columns.Add("Supplier");
			lvHeading.Width = sizeConvertors.twipsToPixels(2100, true);
			lvHeading = lvItems.Columns.Add("Invoice Number");
			lvHeading.Width = sizeConvertors.twipsToPixels(1500, true);
			lvHeading = lvItems.Columns.Add("Date");
			lvHeading.Width = sizeConvertors.twipsToPixels(1100, true);
			lvHeading = lvItems.Columns.Add("Amount");
			lvHeading.Width = sizeConvertors.twipsToPixels(1300, true);
			lvHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmOrderPrint_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmOrderPrint_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			loading = true;
			ADODB.Recordset rs = default(ADODB.Recordset);
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			int x = 0;
			int lQuantity = 0;
			short lDepositQuantity = 0;
			decimal lCost = default(decimal);
			decimal lActualCost = default(decimal);
			decimal lDepositUnit = default(decimal);
			decimal lDepositPack = default(decimal);
			string ltype = null;
			setHeading();

			loadLanguage();

			rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT Supplier.* FROM Supplier WHERE Supplier_Disabled = 0 ORDER BY Supplier.Supplier_Name");
			this.lstSupplier.Items.Clear();
			while (!(rs.EOF)) {
				if (Information.IsDBNull(rs.Fields("Supplier_GRVtype").Value)) {
					ltype = "normal";
				} else {
					ltype = rs.Fields("Supplier_GRVtype").Value;
					if (string.IsNullOrEmpty(ltype))
						ltype = "normal";
				}
				lstSupplier.Items.Add(new LBI(rs.Fields("Supplier_Name").Value + "", rs.Fields("SupplierID").Value));
				rs.MoveNext();
			}
			lstSupplier.SelectedIndex = 0;
			loading = false;
		}

		private void lstSupplier_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			if (lstSupplier.SelectedIndex == -1)
				return;
			rs = modRecordSet.getRS(ref "SELECT TOP 100 PurchaseOrder.PurchaseOrderID, PurchaseOrder.PurchaseOrder_Reference, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID, Supplier.Supplier_Name FROM PurchaseOrderItem INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID GROUP BY PurchaseOrder.PurchaseOrderID, PurchaseOrder.PurchaseOrder_Reference, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_SupplierID Having (((PurchaseOrder.PurchaseOrder_SupplierID) = " + Convert.ToInt32(lstSupplier.SelectedIndex) + ")) ORDER BY PurchaseOrder.PurchaseOrderID DESC;");

			this.lvItems.Items.Clear();
			while (!(rs.EOF)) {

				lvItem = lvItems.Items.Add("K" + rs.Fields("PurchaseOrderID").Value, rs.Fields("Supplier_Name").Value, "");

				if (rs.Fields("PurchaseOrder_PurchaseOrderStatusID").Value != 1) {
					//lvItem.Font = lvItem.Font.
				}

				//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lvItem.SubItems.Count > 0) {
					lvItem.SubItems[0].Text = rs.Fields("PurchaseOrder_Reference").Value;
				} else {
					lvItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("PurchaseOrder_Reference").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lvItem.SubItems.Count > 1) {
					lvItem.SubItems[1].Text = Strings.Format(rs.Fields("PurchaseOrder_DateCreated").Value, "dd,mmm yyyy");
				} else {
					lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs.Fields("PurchaseOrder_DateCreated").Value, "dd,mmm yyyy")));
				}
				rs.MoveNext();
			}

		}

		private void lstSupplier_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void lvItems_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lvItems.FocusedItem == null) {
			} else {
				modApplication.report_PurchaseOrder(ref Convert.ToInt32(Strings.Mid(lvItems.FocusedItem.Name, 2)));
			}
		}

		private void lvItems_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			} else if (KeyAscii == 13) {
				lvItems_DoubleClick(lvItems, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
