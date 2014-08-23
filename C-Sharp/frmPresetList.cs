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
	internal partial class frmPresetList : System.Windows.Forms.Form
	{
		int gID;
		string gFilter;
		string gFilterSQL;
		ADODB.Recordset gRS;

		private void loadLanguage()
		{

			//frmPresetList = No Code    [Denomination List]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPresetList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPresetList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [Available Presets]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{

			loadLanguage();
			this.ShowDialog();
			return gID;
		}

		private void getNamespace()
		{
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			subRearangePreset();

			this.Close();
		}
		public void subRearangePreset()
		{

		}

		private void cmdNamespace_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void cmdNew_Click()
		{
			My.MyProject.Forms.frmPrintGroup.loadItem(ref 0);
			doSearch();
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim frmPresetTender As Object
			//Dim frmPreset As frmPresetTender
			//If DataList1.BoundText <> "" Then
			// gRS.Filter = "Float_Unit = " & DataList1.BoundText
			// frmPreset.loadItem(CInt(DataList1.BoundText), gRS.Fields("Float_Name"))
			// doSearch()
			//	End If

		}
		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
				case Strings.ChrW(27):
					this.Close();
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
			}

		}

		private void frmPresetList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			doSearch();
		}
		private void frmPresetList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}
		private void txtSearch_MyGotFocus(System.Object eventSender, System.EventArgs eventArgs)
		{
			//txtSearch.SelectionStart = 0
			//txtSearch.SelectionLength = 999
		}
		private void txtSearch_KeyDown(ref short KeyCode, ref short Shift)
		{
			switch (KeyCode) {
				case 40:
					this.DataList1.Focus();
					break;
			}
		}
		private void txtSearch_KeyPress(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
		}

		private void doSearch()
		{
			ADODB.Recordset rk = default(ADODB.Recordset);
			BindingSource bind = new BindingSource();
			gRS = modRecordSet.getRS(ref "SELECT Float.Float_Unit, Float.Float_Pack, Float.Float_Name, Float.Float_Type,Float.Float_Disabled From [float] WHERE Float.Float_Type = True AND Float_Disabled = False ORDER BY Float.Float_Unit, Float.Float_Type;");

			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "Float_Name";

			//Bind the DataCombo to the ADO Recordset
			bind.DataSource = gRS;
			DataList1.DataBindings.Add(bind.DataSource);
			DataList1.boundColumn = "Float_Unit";

			Label2.Text = "";
			while (gRS.EOF == false) {
				rk = modRecordSet.getRS(ref "SELECT keyboard.keyboard_Name,keyboard.keyboard_Description, keyboard.keyboard_Show,keyboard.keyboardID FROM tblPresetTender INNER JOIN keyboard ON tblPresetTender.tblKey = keyboard.KeyboardID WHERE tblPresetTender.tblValue = " + gRS.Fields("Float_Unit").Value + ";");
				if (rk.RecordCount) {
					Label2.Text = Label2.Text + gRS.Fields("Float_Name").Value + " :";
				}
				gRS.moveNext();
			}

		}
	}
}
