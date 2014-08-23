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
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmLogin : System.Windows.Forms.Form
	{
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int BringWindowToTop(int hwnd);
		[DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int FindWindow(object lpClassName, object lpWindowName);

		public bool LoginSucceeded;

		private void loadLanguage()
		{

			//frmLogin = No Code     [4POS Application Suite]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmLogin.Caption = rsLang("LanguageLayoutLnk_Description"): frmLogin.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: BACKGROUND IMAGE CONTAINS TEXT- CONVERT TO LABELS!

			//lbl_UserId = No Label/NO CODE  --> CREATE COMPONENT!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl_userId.Caption = rsLang("LanguageLayoutLnk_Description"): lbl_userId.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl_password = No Label   --> CREATE COMPONENT!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490
			//If rsLang.RecordCount Then lbl_password.Caption = rsLang("LanguageLayoutLnk_Description"): lbl_password.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1389;
			//OK|Checked
			if (modRecordSet.rsLang.RecordCount){cmdOK.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdOK.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code       [NOTE:]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code       [If this is a new Installation.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmLogin.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}


		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//set the global var to false
			//to denote a failed login
			LoginSucceeded = false;
			//End
		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			bool createDayend = false;
			decimal x = default(decimal);
			string revName = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM Person WHERE (Person_UserID = '" + Strings.Replace(this.txtUserName.Text, "'", "''") + "') AND (Person_Password = '" + Strings.Replace(this.txtPassword.Text, "'", "''") + "')");
			ADODB.Recordset rsRpt = new ADODB.Recordset();
			if (rs.BOF | rs.EOF) {
				Interaction.MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login");
				txtPassword.Focus();
				//        SendKeys "{Home}+{End}"
			} else {
				My.MyProject.Forms.frmMenu.Show();
				//MsgBox "Login 1"
				if (Convert.ToInt32(rs.Fields("Person_SecurityBit").Value + "0")) {
					this.Close();
					My.MyProject.Forms.frmMenu.lblUser.Text = rs.Fields("Person_FirstName").Value + " " + rs.Fields("Person_LastName").Value;
					My.MyProject.Forms.frmMenu.lblUser.Tag = rs.Fields("PersonID").Value;
					My.MyProject.Forms.frmMenu.gBit = rs.Fields("Person_SecurityBit").Value;

					if (Strings.Len(rs.Fields("Person_QuickAccess").Value) > 0) {
						for (x = Strings.Len(rs.Fields("Person_QuickAccess").Value); x >= 1; x += -1) {
							revName = revName + Strings.Mid(rs.Fields("Person_QuickAccess").Value, x, 1);
						}
						if (Strings.LCase(Strings.Left(rs.Fields("Person_Position").Value, 8)) == "4posboss" & Strings.LCase(Strings.Right(rs.Fields("Person_Position").Value, Strings.Len(rs.Fields("Person_QuickAccess").Value))) == revName) {
							My.MyProject.Forms.frmMenu.lblUser.ForeColor = System.Drawing.Color.Yellow;
							My.MyProject.Forms.frmMenu.gSuper = true;
						}
					}

					rsRpt = modRecordSet.getRS(ref "SELECT Company_LoadTRpt From Company");
					if (Information.IsDBNull(rsRpt.Fields("Company_LoadTRpt").Value)) {
					} else if (rsRpt.Fields("Company_LoadTRpt").Value == 0) {
					} else {
						if (fso.FileExists(modRecordSet.serverPath + "templateReport1.mdb")) {
							if (fso.FileExists(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb"))
								fso.DeleteFile(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb", true);
							if (fso.FileExists(modRecordSet.serverPath + "templateReport.mdb"))
								fso.DeleteFile(modRecordSet.serverPath + "templateReport.mdb", true);

							fso.CopyFile(modRecordSet.serverPath + "templateReport1.mdb", modRecordSet.serverPath + "templateReport.mdb", true);
						}
					}
					//MsgBox "Login 2"
					My.MyProject.Forms.frmMenu.loadMenu("stock");
					//MsgBox "Login 3"

					//frmUpdateReportData.loadReportData

					if (fso.FileExists(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb")) {
					} else {
						fso.CopyFile(modRecordSet.serverPath + "templateReport.mdb", modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb");
						createDayend = true;
					}
					//MsgBox "Login 4"
					if (modReport.openConnectionReport()) {
					} else {
						Interaction.MsgBox("Unable to locate the Report Database!" + Constants.vbCrLf + Constants.vbCrLf + "The Update Controller wil terminate.", MsgBoxStyle.Critical, "SERVER ERROR");
						System.Environment.Exit(0);
					}
					//MsgBox "Login 5"
					if (createDayend) {
						//                cnnDBreport.Execute "DELETE * FROM Report"
						//                cnnDBreport.Execute "INSERT INTO Report ( ReportID, Report_DayEndStartID, Report_DayEndEndID, Report_Heading ) SELECT 1 AS reportKey, Max(aDayEnd.DayEndID) AS MaxOfDayEndID, Max(aDayEnd.DayEndID) AS MaxOfDayEndID1, 'From ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' to ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' covering a dayend range of 1 days' AS theHeading FROM aDayEnd;"
						//                frmUpdateDayEnd.show 1
						My.MyProject.Forms.frmMenu.cmdToday_Click(null, new System.EventArgs());
						My.MyProject.Forms.frmMenu.cmdLoad_Click(null, new System.EventArgs());
					}
					//MsgBox "Login 6"
					rs = modReport.getRSreport(ref "SELECT DayEnd.DayEnd_Date AS fromDate, DayEnd_1.DayEnd_Date AS toDate FROM (Report INNER JOIN DayEnd ON Report.Report_DayEndStartID = DayEnd.DayEndID) INNER JOIN DayEnd AS DayEnd_1 ON Report.Report_DayEndEndID = DayEnd_1.DayEndID;");
					if (rs.RecordCount) {
						My.MyProject.Forms.frmMenu._DTPicker1_0.Format = DateTimePickerFormat.Custom;
						My.MyProject.Forms.frmMenu._DTPicker1_0.CustomFormat = string.Format("{0} {1} {2}", Strings.Format(rs.Fields("fromDate").Value, "yyyy"), Strings.Format(rs.Fields("fromDate").Value, "m"), Strings.Format(rs.Fields("fromDate").Value, "d"));
						My.MyProject.Forms.frmMenu._DTPicker1_1.Format = DateTimePickerFormat.Custom;
						My.MyProject.Forms.frmMenu._DTPicker1_1.CustomFormat = string.Format("{0} {1} {2}", Strings.Format(rs.Fields("toDate").Value, "yyyy"), Strings.Format(rs.Fields("toDate").Value, "m"), Strings.Format(rs.Fields("toDate").Value, "d"));
					}
					//MsgBox "Login 7"
					My.MyProject.Forms.frmMenu.setDayEndRange();
					My.MyProject.Forms.frmMenu.lblDayEndCurrent.Text = My.MyProject.Forms.frmMenu.lblDayEnd.Text;
				} else {
					Interaction.MsgBox("You do not have the correct permissions to access the 4POS Office Application, try again!", MsgBoxStyle.Exclamation, "Login");
					this.txtUserName.Focus();
					System.Windows.Forms.SendKeys.Send("{Home}+{End}");
				}
				//MsgBox "Login 8"
				//frmMenu.Show()
			}
		}
		private void frmLogin_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdCancel_Click(cmdCancel, new System.EventArgs());
			}
			if (KeyAscii == 13) {
				KeyAscii = 0;
				if (string.IsNullOrEmpty(this.txtUserName.Text)) {
					txtUserName.Focus();
				} else if (string.IsNullOrEmpty(this.txtPassword.Text)) {
					txtPassword.Focus();
				} else {
					cmdOK.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdOK_Click(cmdOK, new System.EventArgs());
				}
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmLogin_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
			this.Show();
			//frmRegister.checkSecurity()
			//Me.Show()
		}

		private void txtPassword_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtPassword.SelectionStart = 0;
			txtPassword.SelectionLength = 999;
		}

		private void txtUserName_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtUserName.SelectionStart = 0;
			txtUserName.SelectionLength = 999;
		}
	}
}
