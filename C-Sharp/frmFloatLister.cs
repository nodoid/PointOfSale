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
	internal partial class frmFloatLister : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;

		private void loadLanguage()
		{

			//frmFloatLister = No Code       [Denomination]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmFloatLister.Caption = rsLang("LanguageLayoutLnk_Description"): frmFloatLister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){Command2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmFloatLister.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{
			//cmdNew.Visible = False

			loadLanguage();
			this.ShowDialog();
			return gID;
		}
		private void getNamespace()
		{
		}
		private void cmdExit_Click()
		{
			this.Close();
		}
		private void cmdNamespace_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}
		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmNewDenomination.loadItem();
			doSearch();
		}
		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.CurrentCell.ToString())) {
					My.MyProject.Forms.frmFloatRepre.loadItem(ref Convert.ToInt32(DataList1.CurrentCell.Value));
				}
				doSearch();
			} else {
				if (string.IsNullOrEmpty(DataList1.CurrentCell.ToString())) {
					gID = 0;
				} else {
					gID = Convert.ToInt32(DataList1.CurrentCell.Value);
				}
				this.Close();
			}
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.Chr(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.Chr(0);
					break;
				case Strings.Chr(27):
					this.Close();
					eventArgs.KeyChar = Strings.Chr(0);
					break;
			}

		}
		private void frmFloatLister_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			doSearch();
		}

		private void frmFloatLister_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}
		private void doSearch()
		{
			//Dim sql As String
			//Dim lString As String
			//Dim column As DataColumn
			gRS = modRecordSet.getRS(ref "SELECT Float.Float_Unit, Float.Float_Pack, Float.Float_Name, Float.Float_Type,Float.Float_Disabled From [float] ORDER BY Float.Float_Unit, Float.Float_Type;");
			//Display the list of Titles in the DataCombo
			//Dim bind As New BindingSource
			//bind.DataSource = gRS
			DataList1.DataSource = gRS;
			DataList1.Columns.Add("Float_Name", "");
			//DataList1.listField = "Float_Name"

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.Columns.Add("Float_Unit", "");

		}
	}
}
