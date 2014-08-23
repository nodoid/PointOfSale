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
	internal partial class frmDayEndList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;
		int mID_Renamed;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1265;
			//Select a Day End|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmDayEndList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{
			Button cmdNew = new Button();
			cmdNew.Visible = false;

			loadLanguage();
			this.ShowDialog();
			return gID;

		}

		private void getNamespace()
		{
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNamespace_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void cmdPrev_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			string lString = null;

			mID_Renamed = 0;
			mID_Renamed = My.MyProject.Forms.frmMonthendList.getItem(ref 7);
			if (mID_Renamed) {
				gRS = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM DayEnd WHERE DayEnd.DayEnd_MonthEndID = " + mID_Renamed + " ORDER BY DayEnd.DayEndID DESC;");
				//Display the list of Titles in the DataCombo
				DataList1.DataSource = gRS;
				DataList1.listField = "theDay";

				//Bind the DataCombo to the ADO Recordset
				//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
				DataList1.DataSource = gRS;
				DataList1.boundColumn = "DayEndID";
			} else {
				gRS = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM Company AS Company_1 INNER JOIN (Company RIGHT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Company_1.Company_MonthEndID = DayEnd.DayEnd_MonthEndID Where (((Company.CompanyID) Is Null)) ORDER BY DayEnd.DayEndID DESC;");
				//Display the list of Titles in the DataCombo
				DataList1.DataSource = gRS;
				DataList1.listField = "theDay";

				//Bind the DataCombo to the ADO Recordset
				DataList1.DataSource = gRS;
				DataList1.boundColumn = "DayEndID";
			}
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				if (mID_Renamed != 0) {
					modApplication.loadDayEndReportPrev(ref Convert.ToInt32(DataList1.BoundText), ref mID_Renamed);
				} else {
					modApplication.loadDayEndReport(Convert.ToInt32(DataList1.BoundText));
				}
			}
		}



		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			string lDate = null;
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
				case Strings.ChrW(27):
					this.Close();
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
				case Strings.ChrW(100):
					if (!string.IsNullOrEmpty(DataList1.BoundText)) {
						lDate = Interaction.InputBox("Enter New Date", "NEW DATE", Convert.ToString(DateAndTime.Today));
						if (!string.IsNullOrEmpty(lDate)) {
							 // ERROR: Not supported in C#: OnErrorStatement

							modRecordSet.cnnDB.Execute("UPDATE DayEnd SET DayEnd.DayEnd_Date = #" + lDate + "# WHERE (((DayEnd.DayEndID)=" + DataList1.BoundText + "));");
							doSearch();
						}
					}

					break;
			}

		}
		private void frmDayEndList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		public void loadItem(ref short section)
		{
			Button cmdNew = new Button();
			gSection = section;
			if (gSection)
				cmdNew.Visible = false;

			doSearch();
			if (System.Drawing.ColorTranslator.ToOle(My.MyProject.Forms.frmMenu.lblUser.ForeColor) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow))
				cmdPrev.Visible = false;
			loadLanguage();
			this.ShowDialog();
		}

		private void frmDayEndList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			mID_Renamed = 0;
		}

		private void frmDayEndList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		//Private Sub txtSearch_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		// Dim txtSearch As New TextBox
		//     txtSearch.SelStart = 0
		//    txtSearch.SelLength = 999
		//End Sub

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
			string sql = null;
			string lString = null;

			gRS = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM Company AS Company_1 INNER JOIN (Company RIGHT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Company_1.Company_MonthEndID = DayEnd.DayEnd_MonthEndID Where (((Company.CompanyID) Is Null)) ORDER BY DayEnd.DayEndID DESC;");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "theDay";


			//Bind the DataCombo to the ADO Recordset
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "DayEndID";

		}
	}
}
