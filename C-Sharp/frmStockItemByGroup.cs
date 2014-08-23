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
	internal partial class frmStockItemByGroup : System.Windows.Forms.Form
	{
		int p_irc;
		int p_MenuID;
		int parentMID;
		int p_OrderM;
		bool tprod_M;
		bool bt_Vertical;

		private void loadLanguage()
		{

			//Picture1 CONTAINS IMAGE WITH TEXT - CONVERT TO LABEL!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code   [Press (A) To Select All Products]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockItemByGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void lstStockItem_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//If lstStockItem.ListCount Then Else txtSearchIt.SetFocus
		}
		private void lstStockItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void doKeyPress(ref short KeyAscii)
		{
			int lc = 0;
			short x = 0;
			switch (KeyAscii) {
				case 27:
					KeyAscii = 0;
					this.Close();
					break;
				case 13:
					KeyAscii = 0;

					if (lstStockItem.SelectedIndex != -1) {
						lc = CountSelected(ref lstStockItem.Items.Count);
						if (lc > 0) {
							if (Interaction.MsgBox("Changes you are about to make will affect : " + lc + " record(s), Do you want to continue?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.YesNo, "4POS Global Update") == MsgBoxResult.Yes) {
								modRecordSet.cnnDB.Execute("DELETE * FROM gGlobalUpdate;");
								for (x = 0; x <= lstStockItem.Items.Count - 1; x++) {
									if (lstStockItem.GetSelected(x) == true) {
										modRecordSet.cnnDB.Execute("INSERT INTO gGlobalUpdate(gStockItemID) VALUES (" + GID.GetItemData(ref lstStockItem, ref x) + ")");
									}
								}
							} else {
								modRecordSet.cnnDB.Execute("DELETE * FROM gGlobalUpdate;");
								this.Close();
							}
						} else {
							modRecordSet.cnnDB.Execute("DELETE * FROM gGlobalUpdate;");
						}
					}
					this.Close();

					break;
				case 65:
				case 97:
					for (x = 0; x <= lstStockItem.Items.Count - 1; x++) {
						lstStockItem.SetSelected(x, true);
					}

					break;
			}

		}
		private short CountSelected(ref short lstCount)
		{
			short x = 0;
			short y = 0;

			for (y = 0; y <= lstCount - 1; y++) {
				if (lstStockItem.GetSelected(y))
					x = x + 1;
			}
			return x;
		}
		private void doSearch(ref string sq1)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref sq1);
			while (rs.EOF == false) {
				lstStockItem.Items.Add(new LBI(rs.Fields("StockItem_Name").Value, rs.Fields("StockItemID").Value));
				rs.MoveNext();
			}

		}
		public void loadItem(ref string sql)
		{
			doSearch(ref sql);

			loadLanguage();
			this.ShowDialog();
		}
	}
}
