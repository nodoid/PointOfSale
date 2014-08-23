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
	internal partial class frmBlockTestFilterSelect : System.Windows.Forms.Form
	{
		int gID;
		int[,] dataArray;
		List<Button> cmdClick = new List<Button>();

		private void loadLanguage()
		{
			//frmPricelistFilterItem = No Code [Allocate Stock Items to Pricelist]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPricelistFilterItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricelistFilterItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code/Dynamic!

			//TOOLBAR CODE NOT DONE!!!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBlockTestFilterSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClick_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			Button btn = new Button();
			btn = (Button)eventSender;
			Index = GetIndex.GetIndexer(ref btn, ref cmdClick);
			tbStockItem_ButtonClick(this.tbStockItem.Items[Index], new System.EventArgs());
			lstStockItem.Focus();

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem(ref int id, ref int selectTestLoad, ref int tempTestID)
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			gID = id;
			//Set rs = getRS("SELECT StockItem.StockItem_Name, * FROM BlockTest INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID WHERE (((BlockTest.BlockTest_MainItemID)=" & gID & "));")
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, * FROM BlockTest INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID WHERE (((BlockTest.BlockTest_MainItemID)=" + gID + ") AND ((BlockTest.BlockTestID)<>" + tempTestID + "));");
			if (rs.BOF | rs.EOF) {
			} else {
				lblHeading.Text = rs.Fields("StockItem_Name").Value;
				//Set rs = getRS("SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name FROM StockItem ORDER BY StockItem_Name;")
				dataArray = new int[rs.RecordCount + 1, 4];
				x = -1;
				while (!(rs.EOF)) {
					x = x + 1;
					dataArray[x, 0] = rs.Fields("BlockTestID").Value;
					dataArray[x, 1] = rs.Fields("BlockTest_Desc").Value;
					dataArray[x, 2] = false;
					dataArray[x, 3] = rs.Fields("BlockTest_WeightCarcass").Value;
					rs.MoveNext();
				}

				//Set rs = getRS("SELECT PricelistFilterStockItemLnk.PricelistStockItemLnk_StockItemID From PricelistFilterStockItemLnk WHERE (((PricelistFilterStockItemLnk.PricelistStockItemLnk_PricelistID)=" & gID & "));")
				//Do Until rs.EOF
				//    For x = LBound(dataArray) To UBound(dataArray)
				//        If dataArray(x, 0) = rs("PricelistStockItemLnk_StockItemID") Then
				//            dataArray(x, 2) = True
				//        End If
				//    Next x
				//    rs.moveNext
				//Loop

				doLoad();

				loadLanguage();
				ShowDialog();
				selectTestLoad = dataArray.Clone();
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
								tmp = dataArray[x, 1] + ", " + x.ToString();
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
								tmp = dataArray[x, 1] + ", " + x.ToString();
								m = lstStockItem.Items.Add(tmp);
								lstStockItem.SetItemChecked(m, dataArray[x, 2]);
							}
						}
					}

					break;
				default:
					for (x = 0; x <= Information.UBound(dataArray) - 1; x++) {
						if (Strings.InStr(Strings.UCase(dataArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
							tmp = dataArray[x, 1] + ", " + x.ToString();
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

		private void frmBlockTestFilterSelect_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
				//sql = "DELETE PricelistFilterStockItemLnk.* From PricelistFilterStockItemLnk WHERE (((PricelistFilterStockItemLnk.PricelistStockitemLnk_PricelistID)=" & gID & ") AND ((PricelistFilterStockItemLnk.PricelistStockitemLnk_StockitemID)=" & dataArray(x, 0) & "));"
				//cnnDB.Execute sql

				//If dataArray(x, 2) Then
				//    sql = "INSERT INTO PricelistFilterStockItemLnk ( PricelistStockitemLnk_PricelistID, PricelistStockitemLnk_StockitemID ) SELECT " & gID & " AS pricelist, " & dataArray(x, 0) & " AS stock;"
				//    cnnDB.Execute sql
				//End If
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

		private void frmBlockTestFilterSelect_Load(object sender, System.EventArgs e)
		{
			cmdClick.AddRange(new Button[] {
				_cmdClick_1,
				_cmdClick_2,
				_cmdClick_3
			});
			Button btn = new Button();
			foreach (Button btn_loopVariable in cmdClick) {
				btn = btn_loopVariable;
				btn.Click += cmdClick_Click;
			}
		}
	}
}
