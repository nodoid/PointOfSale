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
	internal partial class frmGRVTemplate : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmGRVTemplate = No Code   [GRV Template Editor]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmGRVTemplate.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVTemplate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1459;
			//GRV Template|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code           [Available Columns]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [GRV Columns]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdUp = No Code            [Up]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdUp.Caption = rsLang("LanguageLayoutLnk_Description"): cmdUp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdDown = No Code          [Down]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdDown.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDown.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVTemplate.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void reorder()
		{
			short x = 0;
			for (x = 0; x <= lstItem.Items.Count - 1; x++) {
				modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + x + 1 + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + GID.GetItemData(ref lstItem, ref x) + "));");

			}

		}

		private void cmbTemplate_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT GRVTemplateList.GRVTemplateListID, GRVTemplateList.GRVTemplateList_Name FROM GRVTemplateItem INNER JOIN GRVTemplateList ON GRVTemplateItem.GRVTemplateItem_GRVTemplateListID = GRVTemplateList.GRVTemplateListID Where (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID) = " + Convert.ToInt32(cmbTemplate.SelectedIndex) + ")) ORDER BY GRVTemplateItem.GRVTemplateItem_Order;");
			lstItem.Items.Clear();
			while (!(rs.EOF)) {
				lstItem.Items.Add(new LBI(rs.Fields("GRVTemplateList_Name").Value, rs.Fields("GRVTemplateListID").Value));
				rs.moveNext();
			}
		}


		private void doAction(ref bool ltype)
		{
			short x = 0;
			if (ltype) {
				modRecordSet.cnnDB.Execute("DELETE GRVTemplateItem.GRVTemplateItem_GRVTemplateID, GRVTemplateItem.GRVTemplateItem_GRVTemplateListID From GRVTemplateItem WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + GID.GetItemData(ref cmbTemplate, ref cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + Convert.ToInt32(lstItem.SelectedIndex) + "));");
			} else {
				for (x = 0; x <= lstItem.Items.Count - 1; x++) {
					if (GID.GetItemData(ref lstItem, ref x) == Convert.ToInt32(lstTemplate.SelectedIndex)) {
						lstItem.SelectedIndex = x;
						return;
					}
				}
				modRecordSet.cnnDB.Execute("INSERT INTO GRVTemplateItem ( GRVTemplateItem_GRVTemplateID, GRVTemplateItem_GRVTemplateListID, GRVTemplateItem_Order ) VALUES (" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ", " + GID.GetItemData(ref lstTemplate, ref lstTemplate.SelectedIndex) + ", " + lstItem.Items.Count + 1 + ");");
			}
			reorder();
			cmbTemplate_SelectedIndexChanged(cmbTemplate, new System.EventArgs());
		}

		private void cmdDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			int id = 0;
			if (lstItem.SelectedIndex != -1) {
				if (lstItem.SelectedIndex != lstItem.Items.Count - 1) {
					id = Convert.ToInt32(lstItem.SelectedIndex);
					modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + lstItem.SelectedIndex + 2 + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + Convert.ToInt32(lstItem.SelectedIndex) + "));");
					modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + lstItem.SelectedIndex + 1 + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + Convert.ToInt32(lstItem.SelectedIndex + 1) + "));");
					cmbTemplate_SelectedIndexChanged(cmbTemplate, new System.EventArgs());
					for (x = 0; x <= lstItem.Items.Count - 1; x++) {
						if (GID.GetItemData(ref lstItem, ref x) == id) {
							lstItem.SelectedIndex = x;
							lstItem.Focus();
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
			}

		}

		private void cmdUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			int id = 0;
			if (lstItem.SelectedIndex > 0) {
				id = Convert.ToInt32(lstItem.SelectedIndex);
				modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + lstItem.SelectedIndex + 1 + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + Convert.ToInt32(lstItem.SelectedIndex - 1) + "));");
				modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + lstItem.SelectedIndex + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + Convert.ToInt32(lstItem.SelectedIndex) + "));");
				for (x = lstItem.SelectedIndex + 1; x <= lstItem.Items.Count - 1; x++) {
					modRecordSet.cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " + x + 1 + " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" + Convert.ToInt32(cmbTemplate.SelectedIndex) + ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" + GID.GetItemData(ref lstItem, ref x) + "));");
				}
				cmbTemplate_SelectedIndexChanged(cmbTemplate, new System.EventArgs());
				for (x = 0; x <= lstItem.Items.Count - 1; x++) {
					if (GID.GetItemData(ref lstItem, ref x) == id) {
						lstItem.SelectedIndex = x;
						lstItem.Focus();
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
		}


		private void frmGRVTemplate_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmGRVTemplate_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT GRVTemplate.* From GRVTemplate ORDER BY GRVTemplate.GRVTemplate_Name;");
			while (!(rs.EOF)) {
				cmbTemplate.Items.Add(new LBI(rs.Fields("GRVTemplate_Name").Value, rs.Fields("GRVTemplateID").Value));
				rs.moveNext();
			}
			cmbTemplate.SelectedIndex = 0;

			loadLanguage();

			rs = modRecordSet.getRS(ref "SELECT GRVTemplateList.* From GRVTemplateList ORDER BY GRVTemplateList.GRVTemplateListID;");
			while (!(rs.EOF)) {
				lstTemplate.Items.Add(new LBI(rs.Fields("GRVTemplateList_Name").Value, rs.Fields("GRVTemplateListID").Value));
				rs.moveNext();
			}
		}

		private void lstItem_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			doAction(ref 1);
		}



		private void lstTemplate_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			doAction(ref 0);
		}
	}
}
