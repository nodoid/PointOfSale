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
	internal partial class frmOrderWizardFilter : System.Windows.Forms.Form
	{
		public int gDayEndStart;
		public string gDayEndEnd;
		public string gFilter;
//Dim gNodeFilter As IXMLDOMNode
		public string gFilterSQL;
		List<MonthCalendar> MonthView = new List<MonthCalendar>();


		private void loadLanguage()
		{
			//Label2 = No Code       [When Calculating your ordering levels.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code    [Day End Criteria]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_5 = No Code       [From Date]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_3 = No Code       [To Date]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code       [Calculated Day End Criteria]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code    [Wizard Rules]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code       [Forecast my stock holding for]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code       ["Day Ends" and then guarantee no re-order]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_4 = No Code       [level will be below]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDynamic = No Code   [Automatically re-calculate start and end dates based on current "Day End" date]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkDynamic.Caption = rsLang("LanguageLayoutLnk_Description"): chkDynamic.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){_Label1_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label1_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdFilter.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdFilter.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrderWizardFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void save()
		{
			short lStart = 0;
			short lEnd = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (this.chkDynamic.CheckState) {
				rs = modRecordSet.getRS(ref "SELECT " + gDayEndEnd + " - MAX(DayEndID) AS id From DayEnd");

				lStart = rs.Fields("id").Value;
			} else {
				lStart = Convert.ToInt16(gDayEndEnd);
			}

			lEnd = Convert.ToDouble(gDayEndEnd) - gDayEndStart + 1;


			modRecordSet.cnnDB.Execute("UPDATE MinMax SET MinMax_DayEndIDStart = " + lStart + ", MinMax_DayEndIDBack = " + lEnd + ", MinMax_DaysForward = " + this.txtDays.Text + ", MinMax_Minimum = " + this.txtMinimum.Text + " Where (MinMaxID = 1)");

			this.Close();
		}

		public void setDayEndRange()
		{
			System.DateTime lDate = default(System.DateTime);
			string lDateString = null;
			string[] lDateArray = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.DateTime lDateStart = default(System.DateTime);
			System.DateTime lDateEnd = default(System.DateTime);
			 // ERROR: Not supported in C#: OnErrorStatement

			lDateStart = _MonthView1_0.SelectionStart;
			lDateEnd = _MonthView1_1.SelectionEnd;

			if (_MonthView1_0.SelectionStart > _MonthView1_1.SelectionEnd) {
				lDateStart = _MonthView1_1.SelectionStart;
				lDateEnd = _MonthView1_0.SelectionEnd;
			}
			rs = modRecordSet.getRS(ref "SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd WHERE (DayEnd_Date >= #" + lDateStart + "#) ORDER BY DayEnd_Date");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd ORDER BY DayEndID DESC");
				gDayEndStart = rs.Fields("DayEndID").Value;
			} else {
				gDayEndStart = rs.Fields("DayEndID").Value;
			}
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd WHERE (DayEnd_Date <= #" + lDateEnd + "#) ORDER BY DayEnd_Date DESC");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd ORDER BY DayEndID DESC");
				gDayEndEnd = rs.Fields("DayEndID").Value;
			} else {
				gDayEndEnd = rs.Fields("DayEndID").Value;
			}
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT COUNT(*) AS [count], MIN(DayEnd_Date) AS fromDate, MAX(DayEnd_Date) AS toDate From DayEnd WHERE (DayEndID >= " + gDayEndStart + " AND DayEndID <= " + gDayEndEnd + ")");
			if (rs.BOF | rs.EOF) {
			} else {
				lDateString = Strings.Format(rs.Fields("fromDate").Value, "dddd dd,mmm yyyy");
				lblDayEnd.Text = "Day End date Range From ";
				lblDayEnd.Text = lblDayEnd.Text + lDateString;
				lDateString = Strings.Format(rs.Fields("toDate").Value, "dddd dd,mmm yyyy");
				lblDayEnd.Text = lblDayEnd.Text + " to ";
				lblDayEnd.Text = lblDayEnd.Text + lDateString;
				lblDayEnd.Text = lblDayEnd.Text + " covering a dayend range of ";
				lblDayEnd.Text = lblDayEnd.Text + rs.Fields("count").Value + " days.";
			}
		}


		private void cmdFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
			lblFilter.Text = My.MyProject.Forms.frmFilter.gHeading;
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
		}

		private void setup()
		{
			System.DateTime lDate = default(System.DateTime);
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lStart = 0;
			int lEnd = 0;
			rs = modRecordSet.getRS(ref "SELECT * FROM MinMax WHERE (MinMaxID = 1)");
			if (rs.BOF | rs.EOF) {
			} else {
				lStart = rs.Fields("MinMax_DayEndIDStart").Value;
				lEnd = rs.Fields("MinMax_DayEndIDBack").Value;
				this.txtMinimum.Text = rs.Fields("MinMax_Minimum").Value;
				this.txtDays.Text = rs.Fields("MinMax_DaysForward").Value;
				rs.Close();
				if (lStart < 1) {
					this.chkDynamic.CheckState = System.Windows.Forms.CheckState.Checked;
					rs = modRecordSet.getRS(ref "SELECT [Company].[Company_DayEndID]-(-1*[MinMax].[MinMax_DayEndIDStart]) AS id FROM Company, MinMax Where (MinMax.MinMaxID = 1)");
					lStart = rs.Fields("id").Value - 1;
				} else {
					this.chkDynamic.CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
				rs = modRecordSet.getRS(ref "SELECT DayEnd_Date FROM DayEnd Where (DayEndID = " + lStart + ")");
				if (rs.RecordCount)
					_MonthView1_1 = rs.Fields("DayEnd_Date").Value;

				rs = modRecordSet.getRS(ref "SELECT DayEnd_Date FROM DayEnd Where (DayEndID = " + lStart - lEnd + 1 + ")");
				if (rs.RecordCount) {
					lDate = rs.Fields("DayEnd_Date").Value;
					_MonthView1_0 = rs.Fields("DayEnd_Date").Value;
				}
			}

			setDayEndRange();
		}


		private void frmOrderWizardFilter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				save();
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmOrderWizardFilter_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    Dim gDOMFilter As New DOMDocument
			MonthView.AddRange(new MonthCalendar[] {
				_MonthView1_0,
				_MonthView1_1
			});
			MonthCalendar mc = new MonthCalendar();
			foreach (MonthCalendar mc_loopVariable in MonthView) {
				mc = mc_loopVariable;
				mc.Enter += MonthView1_Enter;
				mc.Leave += MonthView1_Leave;
				mc.DateChanged += MonthView1_SelChange;
			}
			gFilter = "stockitem";
			getNamespace();

			loadLanguage();
			setup();

		}

		private void MonthView1_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			MonthCalendar mv = new MonthCalendar();
			mv = (MonthCalendar)eventSender;
			int Index = GetIndex.GetIndexer(ref mv, ref MonthView);
			if (Index) {
				//        MonthView1(1).MonthBackColor = RGB(255, 255, 255)
				_MonthView1_1.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624);
			} else {
				//        MonthView1(0).MonthBackColor = RGB(255, 255, 255)
				_MonthView1_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624);
			}
		}

		private void MonthView1_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			MonthCalendar mv = new MonthCalendar();
			mv = (MonthCalendar)eventSender;
			int Index = GetIndex.GetIndexer(ref mv, ref MonthView);
			//    If Index Then
			_MonthView1_1.BackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 255, 255));
			//        MonthView1(0).MonthBackColor = -2147483624
			//    Else
			_MonthView1_0.BackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 255, 255));
			//        MonthView1(1).MonthBackColor = -2147483624
			//    End If
		}

		private void MonthView1_SelChange(System.Object eventSender, DateRangeEventArgs eventArgs)
		{
			//Dim Index As Short = MonthView1.GetIndex(eventSender)
			setDayEndRange();
		}

		private void txtDays_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtDays);
		}

		private void txtDays_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtDays_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtDays, ref 0);
		}

		private void txtMinimum_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtMinimum);
		}

		private void txtMinimum_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtMinimum_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtMinimum, ref 0);
		}

		private void getNamespace()
		{
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblFilter.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblFilter.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
			//    doSearch
		}
	}
}
