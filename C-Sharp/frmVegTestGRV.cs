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
	internal partial class frmVegTestGRV : System.Windows.Forms.Form
	{
		int localGRVID;

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

		private void frmVegTestGRV_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		public int getGRVID()
		{
			localGRVID = 0;
			ShowDialog();
			return localGRVID;
		}

		private void frmVegTestGRV_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			//loading = True
			ADODB.Recordset rs = default(ADODB.Recordset);
			short X = 0;
			short lQuantity = 0;
			short lDepositQuantity = 0;
			decimal lCost = default(decimal);
			decimal lActualCost = default(decimal);
			decimal lDepositUnit = default(decimal);
			decimal lDepositPack = default(decimal);
			string ltype = null;
			string tmp = null;
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
				tmp = rs.Fields("Supplier_Name").Value + "" + rs.Fields("SupplierID").Value;
				lstSupplier.Items.Add(tmp);
				rs.moveNext();
			}
			lstSupplier.SelectedIndex = 0;
			loading = false;
		}

//UPGRADE_WARNING: Event lstSupplier.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstSupplier_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ltype = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			if (lstSupplier.SelectedIndex == -1)
				return;
			rs = modRecordSet.getRS(ref "SELECT TOP 100 GRV.GRVID, Supplier.SupplierID, Supplier.Supplier_Name, GRV.GRV_GRVStatusID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, Supplier.Supplier_GRVtype FROM (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((GRV.GRV_GRVStatusID)=3) AND ((Supplier.SupplierID) = " + Convert.ToInt32(lstSupplier.SelectedIndex) + ")) ORDER BY GRV.GRV_InvoiceDate DESC;");

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

				if (rs.Fields("GRV_GRVStatusID").Value != 1) {
					lvItem.Font = new Font(lvItem.Font, FontStyle.Bold);
				}

				if (lvItem.SubItems.Count > 0) {
					lvItem.SubItems[0].Text = rs.Fields("GRV_InvoiceNumber").Value;
				} else {
					lvItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRV_InvoiceNumber").Value));
				}
				if (lvItem.SubItems.Count > 1) {
					lvItem.SubItems[1].Text = Strings.Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy");
				} else {
					lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")));
				}
				if (lvItem.SubItems.Count > 2) {
					lvItem.SubItems[2].Text = Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2);
				} else {
					lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)));
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
				//report_GRV  Mid(lvItems.SelectedItem.Key, 2)
				localGRVID = Convert.ToInt32(Strings.Mid(lvItems.FocusedItem.Name, 2));
				this.Close();
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
