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
	internal partial class frmSetItem : System.Windows.Forms.Form
	{
		int gID;
		short[,] dataArray;
		bool loading;
		List<Button> cmdClick = new List<Button>();
		private void loadLanguage()
		{

			//frmSetItem = No Code   [Allocate Stock Items to Set]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSetItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmSetItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code/Dynamic!

			//tbStockItem = No Code for any items in array!!!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSetItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClick_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = cmdClick.GetIndex(eventSender)
			int Index = 0;
			Button n = new Button();
			n = (Button)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref cmdClick);
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
			rs = modRecordSet.getRS(ref "SELECT Set_Name FROM [Set] WHERE SetID = " + gID);
			if (rs.BOF | rs.EOF) {
			} else {
				lblHeading.Text = rs.Fields("Set_Name").Value;
				//        Set rs = getRS("SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, IIf(IsNull(SetItem_StockItemID), 0, SetItem_StockItemID) AS SetItemID FROM [SELECT TOP 100 PERCENT " & gID & " AS SetID, StockItemID, StockItem_Name From StockItem ORDER BY StockItem_Name]. AS StockItem LEFT JOIN SetItem ON (StockItem.StockItemID = SetItem.SetItem_StockItemID) AND (StockItem.SetID = SetItem.SetItem_SetID);")
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name FROM StockItem ORDER BY StockItem_Name;");
				dataArray = new short[rs.RecordCount + 1, 3];
				x = -1;
				while (!(rs.EOF)) {
					x = x + 1;
					dataArray[x, 0] = rs.Fields("StockItemID").Value;
					dataArray[x, 1] = rs.Fields("StockItem_Name").Value;
					dataArray[x, 2] = false;
					rs.moveNext();
				}


				rs = modRecordSet.getRS(ref "SELECT SetItem.SetItem_StockItemID From SetItem WHERE (((SetItem.SetItem_SetID)=" + gID + "));");
				while (!(rs.EOF)) {
					for (x = Information.LBound(dataArray); x <= Information.UBound(dataArray); x++) {
						if (dataArray[x, 0] == rs.Fields("SetItem_StockItemID").Value) {
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

		private void frmSetItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (loading)
				return;
			short x = 0;
			x = Convert.ToInt16(lstStockItem.SelectedIndex);
			if (lstStockItem.SelectedIndex != -1) {
				dataArray[x, 2] = Convert.ToInt16(lstStockItem.GetItemChecked(lstStockItem.SelectedIndex));

				sql = "DELETE FROM SetItem WHERE (SetItem_SetID = " + gID + ") And (SetItem_StockItemID = " + dataArray[x, 0] + ")";
				modRecordSet.cnnDB.Execute(sql);

				if (dataArray[x, 2]) {

					rs = modRecordSet.getRS(ref "SELECT SetItem.SetItem_StockItemID From SetItem WHERE (((SetItem.SetItem_SetID)<>" + gID + ") AND ((SetItem_StockItemID)=" + dataArray[x, 0] + "));");
					if (rs.RecordCount) {
						Interaction.MsgBox("This Stock Item already being used in other Stock Sets. Remove selected item from other stock sets first.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						dataArray[x, 2] = 0;
						lstStockItem.SetItemChecked(lstStockItem.SelectedIndex, false);
						//doLoad
					} else {
						sql = "INSERT INTO SetItem (SetItem_SetID, SetItem_StockItemID) VALUES(" + gID + ", " + dataArray[x, 0] + ")";
						modRecordSet.cnnDB.Execute(sql);
					}
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

		private void frmSetItem_Load(object sender, System.EventArgs e)
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
