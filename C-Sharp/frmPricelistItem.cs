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
	internal partial class frmPricelistItem : System.Windows.Forms.Form
	{
		int gID;
		short[,] dataArray;
		List<Button> cmdClick = new List<Button>();
		private void loadLanguage()
		{

			//frmPricelistItem = No Code [Allocate Stock Items to Pricelist]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPricelistItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricelistItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code/Dynamic!

			//TOOLBAR CODE NOT DONE!!!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPricelistItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClick_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = cmdClick.GetIndex(eventSender)
			int Index = 0;
			Button m = new Button();
			Button n = new Button();
			n = (Button)eventSender;
			Index = 0;
			foreach (Button m_loopVariable in cmdClick) {
				m = m_loopVariable;
				if (m.Name != n.Name) {
					Index = Index + 1;
				}
			}
			//UPGRADE_WARNING: Lower bound of collection Me.tbStockItem.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			tbStockItem_ButtonClick(this.tbStockItem.Items[Index], new System.EventArgs());
			lstStockItem.Focus();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem(ref int id)
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			gID = id;
			rs = modRecordSet.getRS(ref "SELECT Pricelist_Name FROM Pricelist WHERE PricelistID = " + gID);
			if (rs.BOF | rs.EOF) {
			} else {
				lblHeading.Text = rs.Fields("Pricelist_Name").Value;
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name FROM StockItem ORDER BY StockItem_Name;");
				dataArray = new short[rs.RecordCount + 1, 3];
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				x = -1;
				while (!(rs.EOF)) {
					x = x + 1;
					dataArray[x, 0] = rs.Fields("StockItemID").Value;
					dataArray[x, 1] = rs.Fields("StockItem_Name").Value;
					dataArray[x, 2] = false;
					rs.moveNext();
				}


				rs = modRecordSet.getRS(ref "SELECT PricelistStockItemLnk.PricelistStockItemLnk_StockItemID From PricelistStockItemLnk WHERE (((PricelistStockItemLnk.PricelistStockItemLnk_PricelistID)=" + gID + "));");
				while (!(rs.EOF)) {
					for (x = Information.LBound(dataArray); x <= Information.UBound(dataArray); x++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (dataArray[x, 0] == rs.Fields("PricelistStockItemLnk_StockItemID").Value) {
							//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							dataArray[x, 2] = true;
						}
					}
					rs.moveNext();
				}

				doLoad();

				loadLanguage();
				ShowDialog();
			}
		}

		private void doLoad()
		{
			short x = 0;
			bool loading = false;
			string tmp = null;
			loading = true;
			lstStockItem.Visible = false;
			this.lstStockItem.Items.Clear();
			int m = 0;
			switch (this.tbStockItem.Tag) {
				case Convert.ToString(1):
					for (x = 0; x <= Information.UBound(dataArray) - 1; x++) {
						if (dataArray[x, 2]) {
							if (Strings.InStr(Strings.UCase(dataArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
								tmp = dataArray[x, 1].ToString() + x.ToString();
								m = lstStockItem.Items.Add(tmp);
								lstStockItem.SetItemChecked(m, dataArray[x, 2]);
							}
						}
					}

					break;

				case Convert.ToString(2):
					for (x = 0; x <= Information.UBound(dataArray) - 1; x++) {
						if (dataArray[x, 2]) {
						} else {
							if (Strings.InStr(Strings.UCase(dataArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
								tmp = dataArray[x, 1].ToString() + x.ToString();
								m = lstStockItem.Items.Add(tmp);
								lstStockItem.SetItemChecked(m, dataArray[x, 2]);
							}
						}
					}

					break;
				default:
					for (x = 0; x <= Information.UBound(dataArray) - 1; x++) {
						if (Strings.InStr(Strings.UCase(dataArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
							tmp = dataArray[x, 1].ToString() + x.ToString();
							m = lstStockItem.Items.Add(tmp);
							lstStockItem.SetItemChecked(m, dataArray[x, 2]);
						}
					}

					break;
			}
			if (lstStockItem.SelectedIndex)
				lstStockItem.SelectedIndex = 0;
			lstStockItem.Visible = true;
			loading = false;

		}

		private void frmPricelistItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

//UPGRADE_WARNING: Event lstStockItem.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstStockItem_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			string sql = null;
			if (loading)
				return;
			short x = 0;
			x = Convert.ToInt16(lstStockItem.SelectedIndex);
			if (lstStockItem.SelectedIndex != -1) {
				dataArray[x, 2] = Convert.ToInt16(lstStockItem.GetItemChecked(lstStockItem.SelectedIndex));
				sql = "DELETE PricelistStockItemLnk.* From PricelistStockItemLnk WHERE (((PricelistStockItemLnk.PricelistStockitemLnk_PricelistID)=" + gID + ") AND ((PricelistStockItemLnk.PricelistStockitemLnk_StockitemID)=" + dataArray[x, 0] + "));";

				modRecordSet.cnnDB.Execute(sql);

				if (dataArray[x, 2]) {
					sql = "INSERT INTO PricelistStockItemLnk ( PricelistStockitemLnk_PricelistID, PricelistStockitemLnk_StockitemID ) SELECT " + gID + " AS pricelist, " + dataArray[x, 0] + " AS stock;";

					modRecordSet.cnnDB.Execute(sql);
				}
			}
		}

		private void tbStockItem_ButtonClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.ToolStripItem Button = (System.Windows.Forms.ToolStripItem)eventSender;
			short x = 0;
			for (x = 0; x <= tbStockItem.Items.Count; x++) {
				((ToolStripButton)tbStockItem.Items[x]).Checked = false;
			}
			tbStockItem.Tag = Button.Owner.Items.IndexOf(Button) - 1;
			//    buildDepartment
			//Button.Checked = True
			doLoad();
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 40) {
				this.lstStockItem.Focus();
				KeyCode = 0;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doLoad();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmPricelistItem_Load(object sender, System.EventArgs e)
		{
			cmdClick.AddRange(new Button[] {
				_cmdClick_1,
				_cmdClick_2,
				_cmdClick_3
			});
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdClick) {
				bt = bt_loopVariable;
				bt.Click += cmdClick_Click;
			}
		}
	}
}
