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
	internal partial class frmFilterOrderList : System.Windows.Forms.Form
	{
		string gField;
		string[,] gArray;
		bool loading;
		string gFieldID;
		string gFieldName;
		string gHeading;
		List<Button> cmdClick = new List<Button>();

		private void loadLanguage()
		{
			//frmFilterOrderList = No caption / No Code / NA?

			//TOOLBAR CODE NOT DONE!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmFilterOrderList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void setup()
		{
			short x = 0;
			loading = true;
			lstFilter.Visible = false;
			this.lstFilter.Items.Clear();
			int m = 0;
			switch (this.tbStockItem.Tag) {
				case Convert.ToString(1):
					for (x = 0; x <= Information.UBound(gArray); x++) {
						if (Convert.ToBoolean(gArray[x, 2])) {
							if (Strings.InStr(Strings.UCase(gArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
								m = lstFilter.Items.Add(new LBI(gArray[x, 1], x));
								lstFilter.SetItemChecked(m, gArray[x, 2]);
							}
						}
					}

					break;

				case Convert.ToString(2):
					for (x = 0; x <= Information.UBound(gArray); x++) {
						if (Convert.ToBoolean(gArray[x, 2])) {
						} else {
							if (Strings.InStr(Strings.UCase(gArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
								m = lstFilter.Items.Add(new LBI(gArray[x, 1], x));
								lstFilter.SetItemChecked(m, gArray[x, 2]);
							}
						}
					}

					break;

				default:
					for (x = 0; x <= Information.UBound(gArray); x++) {
						if (Strings.InStr(Strings.UCase(gArray[x, 1]), Strings.UCase(this.txtSearch.Text))) {
							m = lstFilter.Items.Add(new LBI(gArray[x, 1], x));
							lstFilter.SetItemChecked(m, gArray[x, 2]);
						}
					}

					break;
			}
			if (lstFilter.SelectedIndex)
				lstFilter.SelectedIndex = 0;
			lstFilter.Visible = true;
			loading = false;

		}

		public bool loadData(ref string lName)
		{
			bool functionReturnValue = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lSQL = null;
			int x = 0;
			string lID = null;
			gField = lName;
			rs = modRecordSet.getRS(ref "SELECT * From ftConstruct WHERE (ftConstruct_Name = '" + Strings.Replace(lName, "'", "''") + "')");
			gFieldID = rs.Fields("ftConstruct_FieldID").Value;
			gFieldName = rs.Fields("ftConstruct_FieldName").Value;
			gHeading = rs.Fields("ftConstruct_DisplayName").Value;
			lSQL = rs.Fields("ftConstruct_SQL").Value;
			rs.Close();
			rs = modRecordSet.getRS(ref lSQL);
			//Display the list of Titles in the DataCombo


			loading = true;
			functionReturnValue = false;
			x = -1;
			gArray = new string[rs.RecordCount, 3];
			while (!(rs.EOF)) {
				x = x + 1;
				gArray[x, 0] = rs.Fields(gFieldID).Value;
				gArray[x, 1] = rs.Fields(gFieldName).Value + "";
				gArray[x, 2] = Convert.ToString(0);
				rs.MoveNext();
			}
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT ftDataItem_ID From ftOrderItem WHERE (ftDataItem_PersonID = " + modRecordSet.gPersonID + ") AND (ftDataItem_FieldName = '" + Strings.Replace(gField, "'", "''") + "')");

			while (!(rs.EOF)) {
				lID = rs.Fields("ftDataItem_ID").Value;
				for (x = 0; x <= Information.UBound(gArray); x++) {
					if (lID == gArray[x, 0]) {
						gArray[x, 2] = Convert.ToString(1);
					}
				}
				rs.MoveNext();
			}
			rs.Close();
			setup();
			functionReturnValue = true;

			loadLanguage();
			ShowDialog();
			loading = false;
			return functionReturnValue;

		}

		private void save()
		{
			short x = 0;
			string lSQL = null;
			string lHeading = null;
			ADODB.Recordset rs = new ADODB.Recordset();
			rs = modRecordSet.cnnDB.Execute("DELETE FROM ftOrderItem WHERE (ftDataItem_PersonID = " + modRecordSet.gPersonID + ") AND (ftDataItem_FieldName = '" + Strings.Replace(gField, "'", "''") + "')");
			modRecordSet.cnnDB.Execute("DELETE FROM ftOrder WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(gField, "'", "''") + "')");
			for (x = 0; x <= lstFilter.Items.Count - 1; x++) {
				if (lstFilter.GetItemChecked(x)) {
					lHeading = lHeading + " OR ''" + gArray[GID.GetItemData(ref lstFilter, ref x), 1] + "''";
					lSQL = lSQL + " OR [field] = " + gArray[GID.GetItemData(ref lstFilter, ref x), 0];
					modRecordSet.cnnDB.Execute("INSERT INTO ftOrderItem (ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID) VALUES (" + modRecordSet.gPersonID + ", '" + Strings.Replace(gField, "'", "''") + "', " + gArray[GID.GetItemData(ref lstFilter, ref x), 0] + ")");
				}

			}
			if (!string.IsNullOrEmpty(lSQL)) {
				lSQL = "(" + Strings.Mid(lSQL, 4) + ")";
				lHeading = "(" + gHeading + " = " + Strings.Mid(lHeading, 4) + ")";
				modRecordSet.cnnDB.Execute("INSERT INTO ftOrder (ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading) VALUES (" + modRecordSet.gPersonID + ", '" + Strings.Replace(gField, "'", "''") + "', '" + Strings.Replace(lSQL, "'", "''") + "', '" + Strings.Replace(lHeading, "'", "''") + "')");
			}
		}




		//Handles cmdClick.Click
		private void cmdClick_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdClick);
			tbStockItem_ButtonClick(this.tbStockItem.Items[Index], new System.EventArgs());
			lstFilter.Focus();

		}

		private void frmFilterOrderList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			save();
		}

		private void lstFilter_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			if (loading)
				return;
			short x = 0;
			x = GID.GetItemData(ref lstFilter, ref lstFilter.SelectedIndex);
			if (Convert.ToBoolean(gArray[x, 2]) != lstFilter.GetItemChecked(eventArgs.Index)) {
				gArray[x, 2] = Convert.ToString(lstFilter.GetItemChecked(lstFilter.SelectedIndex));
			}
		}

		private void lstFilter_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (Shift == 4 & KeyCode == 88) {
				this.Close();
				KeyCode = 0;
			}

		}

		private void lstFilter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
				KeyAscii = 0;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void tbStockItem_ButtonClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.ToolStripItem Button = (System.Windows.Forms.ToolStripItem)eventSender;
			short x = 0;
			if (Button.Name == "clear") {
				for (x = 0; x <= lstFilter.Items.Count - 1; x++) {
					gArray[x, 2] = Convert.ToString(0);
					lstFilter.SetItemChecked(x, gArray[x, 2]);
				}

				setup();

			} else {
				for (x = 1; x <= tbStockItem.Items.Count; x++) {
					((ToolStripButton)tbStockItem.Items[x]).Checked = false;
				}
				tbStockItem.Tag = Button.Owner.Items.IndexOf(Button) - 1;
				//Button.Checked = True
				setup();
			}
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 9999;
		}


		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 40) {
				if (lstFilter.Items.Count) {
					lstFilter.Focus();
					if (lstFilter.SelectedIndex == -1) {
						lstFilter.SelectedIndex = 0;
					}
				}
				KeyCode = 0;
			}
			if (Shift == 4 & KeyCode == 88) {
				this.Close();
				KeyCode = 0;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				setup();
				KeyAscii = 0;
			}
			if (KeyAscii == 27) {
				this.Close();
				KeyAscii = 0;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmFilterOrderList_Load(object sender, System.EventArgs e)
		{
			cmdClick.AddRange(new Button[] {
				_cmdClick_1,
				_cmdClick_2,
				_cmdClick_3,
				_cmdClick_4
			});
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdClick) {
				bt = bt_loopVariable;
				bt.Click += cmdClick_Click;
			}
		}
	}
}
