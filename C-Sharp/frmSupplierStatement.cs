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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmSupplierStatement : System.Windows.Forms.Form
	{
		short gMonth;
		ADODB.Connection cnnDBStatement = new ADODB.Connection();

		ADODB.Recordset gRS;

		private void loadLanguage()
		{

			//frmSupplierStatement = No Code [Supplier Previous Statements]
			//Closest match DB entry 1553, but word order differs
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSupplierStatement.Caption = rsLang("LanguageLayoutLnk_Description"): frmSupplierStatement.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSupplierStatement.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNew_Click()
		{
			My.MyProject.Forms.frmSupplier.loadItem(ref 0);
			doSearch();
		}
		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			string strDBPath = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				strDBPath = modRecordSet.serverPath + "month" + gMonth - this.cmbMonth.SelectedIndex + ".mdb";
				if (fso.FileExists(strDBPath)) {
					var _with1 = cnnDBStatement;
					_with1.Provider = "MSDataShape";
					cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strDBPath + ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw");

					SupplierStatement(ref Convert.ToInt32(DataList1.BoundText));

					cnnDBStatement.Close();
				} else {
					Interaction.MsgBox("There is no previous month statement for this Supplier", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					this.Close();
				}

			}
		}
		private void SupplierStatement(ref int id)
		{
			ADODB.Connection lConn = new ADODB.Connection();
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			string lAddress = null;
			string lNumber = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("crySupplierStatement.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			lAddress = Strings.Replace(rs.Fields("Company_PhysicalAddress").Value, Constants.vbCrLf, ", ");
			if (Strings.Right(lAddress, 2) == ", ") {
				lAddress = Strings.Left(lAddress, Strings.Len(lAddress) - 2);
			}
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetParameterValue("txtAddress", lAddress);
			lNumber = "";
			if (!string.IsNullOrEmpty(rs.Fields("Company_Telephone").Value))
				lNumber = lNumber + "Tel: " + rs.Fields("Company_Telephone").Value;
			if (!string.IsNullOrEmpty(rs.Fields("Company_Fax").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Fax: " + rs.Fields("Company_Fax").Value;
			}
			if (!string.IsNullOrEmpty(rs.Fields("Company_Email").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Email: " + rs.Fields("Company_Email").Value;
			}
			Report.SetParameterValue("txtNumbers", lNumber);
			lConn = modRecordSet.openConnectionInstance(ref "month" + gMonth - this.cmbMonth.SelectedIndex + ".mdb");
			if (lConn == null)
				return;
			rsCompany = new ADODB.Recordset();
			rsCompany.Open("SELECT * FROM Supplier Where SupplierID = " + id, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			Report.Database.Tables(1).SetDataSource(rsCompany);


			rsTransaction = new ADODB.Recordset();
			rsTransaction.Open("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Date, SupplierTransaction.SupplierTransaction_Reference, TransactionType.TransactionType_Name, IIf([SupplierTransaction_Amount]<0,[SupplierTransaction_Amount],0) AS credit, IIf([SupplierTransaction_Amount]>=0,[SupplierTransaction_Amount],0) AS debit, SupplierTransaction.SupplierTransaction_Amount FROM SupplierTransaction INNER JOIN TransactionType ON SupplierTransaction.SupplierTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" + id + "));", lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			Report.Database.Tables(2).SetDataSource(rsTransaction);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			if (rsTransaction.BOF | rsTransaction.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				ReportNone.SetParameterValue("txtTitle", "Statement");
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}


			My.MyProject.Forms.frmReportShow.Text = "Supplier Statement";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			My.MyProject.Forms.frmReportShow.ShowDialog();


		}


		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdPrint_Click(cmdPrint, new System.EventArgs());
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


		private void frmSupplierStatement_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;
			loading = true;
			rs = modRecordSet.getRS(ref "SELECT Company_MonthendID FROM Company;");
			gMonth = rs.Fields("Company_MonthendID").Value - 1;
			cmbMonth.SelectedIndex = 0;

			loadLanguage();

			doSearch();
		}

		private void frmSupplierStatement_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}
		private void frmSupplierStatement_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdExit_Click(cmdExit, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					this.DataList1.Focus();
					break;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void doSearch()
		{
			string sql = null;
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (Supplier_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND Supplier_Name LIKE '%") + "%')";
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier " + lString + " ORDER BY Supplier_Name");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "Supplier_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "SupplierID";

		}
	}
}
