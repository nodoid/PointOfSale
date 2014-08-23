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
	internal partial class frmQuoteDelete : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmQuoteDelete = No Code   [Delete Unwanted Quotes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmQuoteDelete.Caption = rsLang("LanguageLayoutLnk_Description"): frmQuoteDelete.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code           [Affected Stock Items]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmQuoteDelete.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lPath = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			System.Windows.Forms.ListViewItem lvItem = null;
			lPath = modRecordSet.serverPath + "quote/";
			foreach (ListViewItem lvItem_loopVariable in this.lvData.Items) {
				lvItem = lvItem_loopVariable;
				if (lvItem.Checked) {
					if (fso.FileExists(lPath + Strings.Mid(lvItem.Name, 2))) {
						fso.DeleteFile(lPath + Strings.Mid(lvItem.Name, 2));
					}
					modRecordSet.cnnDB.Execute("DELETE Quote.* From Quote WHERE (((Quote.Quote_Document)='" + Strings.Mid(lvItem.Name, 2) + "'));");
				}

			}
			getData();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}


		private void getData()
		{
			string sql = null;
			string lFilter = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			sql = "SELECT Quote.Quote_Document, Quote.Quote_Name, Quote.Quote_Total, Quote.Quote_Reference, Format([Quote_Date],'ddd dd mmm yyyy') AS theDate From Quote ORDER BY Quote.Quote_Date;";
			rs = modRecordSet.getRS(ref sql);
			lvData.Items.Clear();
			while (!(rs.EOF)) {
				lvItem = lvData.Items.Add("K" + rs.Fields("Quote_Document").Value, rs.Fields("Quote_Document").Value, "");
				lvItem.Checked = false;
				//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lvItem.SubItems.Count > 0) {
					lvItem.SubItems[0].Text = rs.Fields("Quote_Name").Value;
				} else {
					lvItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("Quote_Name").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lvItem.SubItems.Count > 1) {
					lvItem.SubItems[1].Text = Strings.FormatNumber(rs.Fields("Quote_Total").Value, 1);
				} else {
					lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("Quote_Total").Value, 2)));
				}
				//UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lvItem.SubItems.Count > 2) {
					lvItem.SubItems[2].Text = rs.Fields("theDate").Value;
				} else {
					lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("theDate").Value));
				}
				rs.moveNext();
			}
		}


		private void frmQuoteDelete_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmQuoteDelete_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.ColumnHeader lvHeader = null;
			//UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
			//Load(frmOrderWizardFilter)
			lvData.Columns.Add("Document", Convert.ToInt32(sizeConvertors.twipsToPixels(700, true)), System.Windows.Forms.HorizontalAlignment.Left);
			lvData.Columns.Add("Name", Convert.ToInt32(sizeConvertors.twipsToPixels(2500, true)), System.Windows.Forms.HorizontalAlignment.Left);
			lvData.Columns.Add("Total", Convert.ToInt32(sizeConvertors.twipsToPixels(1200, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("Date", Convert.ToInt32(sizeConvertors.twipsToPixels(1600, true)), System.Windows.Forms.HorizontalAlignment.Right);

			loadLanguage();

			getData();
		}

		private void frmQuoteDelete_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			int lWidth = 0;
			for (x = 2; x <= lvData.Columns.Count; x++) {
				lWidth = lWidth + sizeConvertors.pixelToTwips(lvData.Columns[x].Width, true);
			}
			lvData.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lvData.Width, true) - lWidth - 320, true);
		}
	}
}
