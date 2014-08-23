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
	internal partial class frmGRVprint : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1781;
			//Invoice Print|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1433;
			//Select a Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1783;
			//Select an Invoice|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVprint.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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

		private void frmGRVprint_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmGRVprint_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			loading = true;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string ltype = null;
			string tmpString = null;
			loadLanguage();
			setHeading();
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
				tmpString = rs.Fields("Supplier_Name").Value + " " + rs.Fields("SupplierID").Value;
				lstSupplier.Items.Add(tmpString);
				rs.moveNext();
			}
			lstSupplier.SelectedIndex = 0;
			loading = false;
		}

		private void lstSupplier_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ltype = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			if (lstSupplier.SelectedIndex == -1)
				return;
			rs = modRecordSet.getRS(ref "SELECT TOP 100 GRV.GRVID, Supplier.SupplierID, Supplier.Supplier_Name, GRV.GRV_GRVStatusID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, Supplier.Supplier_GRVtype FROM (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((Supplier.SupplierID) = " + Convert.ToInt64(lstSupplier.SelectedIndex) + ")) ORDER BY GRV.GRV_InvoiceDate DESC;");


			this.lvItems.Items.Clear();
			while (!(rs.EOF)) {
				if (Information.IsDBNull(rs.Fields("Supplier_GRVtype").Value)) {
					ltype = "normal";
				} else {
					ltype = rs.Fields("Supplier_GRVtype").Value;
					if (string.IsNullOrEmpty(ltype))
						ltype = "normal";
				}
				lvItem = lvItems.Items.Add("K" + rs.Fields("GRVID").Value, rs.Fields("Supplier_Name").Value, "");

				lvItem.Font = new Font(lvItem.Font, rs.Fields("GRV_GRVStatusID").Value != 1);

				if (lvItem.SubItems.Count > 0) {
					lvItem.SubItems[0].Text = rs.Fields("GRV_InvoiceNumber").Value;
				} else {
					lvItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRV_InvoiceNumber").Value));
				}
				if (lvItem.SubItems.Count > 0) {
					lvItem.SubItems[0].Text = Strings.Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy");
				} else {
					lvItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")));
				}
				if (lvItem.SubItems.Count > 1) {
					lvItem.SubItems[1].Text = Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 1);
				} else {
					lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)));
				}
				rs.moveNext();
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
				modApplication.report_GRV(ref Convert.ToInt32(Strings.Mid(lvItems.FocusedItem.Name, 2)));
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
