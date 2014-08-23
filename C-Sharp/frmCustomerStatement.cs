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
	internal partial class frmCustomerStatement : System.Windows.Forms.Form
	{
		short gMonth;
		ADODB.Connection cnnDBStatement = new ADODB.Connection();

		ADODB.Recordset gRS;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1391;
			//Customer Statement Run|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//chkFields = No Code        [Do not print Payment Date on Statement]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkFields.Caption = rsLang("LanguageLayoutLnk_Description"): chkFields.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNew_Click()
		{
			My.MyProject.Forms.frmCustomer.loadItem(ref 0);
			doSearch();
		}
		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string strDBPath = null;
			if (!string.IsNullOrEmpty(DataList1.BoundText)) {

				if (this.cmbMonthEnd.SelectedIndex == 0){Interaction.MsgBox("Please select Month from List and then click PRINT.", MsgBoxStyle.Exclamation);return;
}
				strDBPath = modRecordSet.serverPath + "month" + gMonth - this.cmbMonthEnd.SelectedIndex + ".mdb";
				if (fso.FileExists(strDBPath)) {
					var _with1 = cnnDBStatement;
					_with1.Provider = "MSDataShape";
					cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strDBPath + ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw");

					CustomerStatement(ref Convert.ToInt32(DataList1.BoundText));
					cnnDBStatement.Close();
				} else {
					Interaction.MsgBox("There is no previous month statement for this Customer", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					this.Close();
				}

				//strDBPath = serverPath & "month" & gMonth - Me.cmbMonth.ListIndex & ".mdb"
				//If fso.FileExists(strDBPath) Then
				//   With cnnDBStatement
				//        .Provider = "MSDataShape"
				//        cnnDBStatement.Open "Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
				//
				//   End With
				//   CustomerStatement DataList1.BoundText
				//   cnnDBStatement.Close
				//Else
				//   MsgBox "There is no previous month statement for this Customer", vbApplicationModal + vbOKOnly + vbInformation, App.title
				//   Unload Me
				//End If
			}
		}

		private void CustomerStatement(ref int id)
		{
			ADODB.Recordset rsInterest = default(ADODB.Recordset);
			ADODB.Recordset rsCustTransCheck = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			string lNumber = null;
			string lAddress = null;
			ADODB.Recordset rs = new ADODB.Recordset();
			string sql = null;

			//Dim Report As New cryCustomerStatement_AGING 'cryCustomerStatement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerStatement_AGING.rpt");
			System.DateTime lDate = default(System.DateTime);
			rs = modRecordSet.getRS(ref "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" + gMonth - (this.cmbMonthEnd.SelectedIndex - 1) + "));");
			Report.SetParameterValue("txtStatementDate", Strings.Format(rs.Fields("MonthEnd_Date").Value, "dd mmm yyyy"));
			lDate = rs.Fields("MonthEnd_Date").Value;

			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			lDate = System.Date.FromOADate(lDate.ToOADate() + 10);
			lDate = System.Date.FromOADate(lDate.ToOADate() - DateAndTime.Day(lDate)) + rs.Fields("Company_PaymentDay").Value;
			if (chkFields.CheckState) {
				Report.SetParameterValue("txtPaymentDate", " ");
				Report.SetParameterValue("Text7", " ");
			} else {
				Report.SetParameterValue("txtPaymentDate", Strings.Format(lDate, "dd mmm yyyy"));
			}
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

			//New banking details
			if (Information.IsDBNull(rs.Fields("Company_BankName").Value)) {
			} else {
				Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchName").Value)) {
			} else {
				Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchCode").Value)) {
			} else {
				Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"));
			}

			if (Information.IsDBNull(rs.Fields("Company_AccountNumber").Value)) {
			} else {
				Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"));
			}
			//...................

			rsCompany = new ADODB.Recordset();
			rsCompany.Open("SELECT * FROM Customer Where CustomerID = " + id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			Report.SetParameterValue("txtDaysCurr", "R " + Strings.FormatNumber(rsCompany("Customer_Current"), 2));
			Report.SetParameterValue("txtDays30", "R " + Strings.FormatNumber(rsCompany("Customer_30Days"), 2));
			Report.SetParameterValue("txtDays60", "R " + Strings.FormatNumber(rsCompany("Customer_60Days"), 2));
			Report.SetParameterValue("txtDays90", "R " + Strings.FormatNumber(rsCompany("Customer_90Days"), 2));
			Report.SetParameterValue("txtDays120", "R " + Strings.FormatNumber(rsCompany("Customer_120Days"), 2));
			Report.SetParameterValue("txtDays150", "R " + Strings.FormatNumber(rsCompany("Customer_150Days"), 2));
			rsCompany.Close();

			rsCompany.Open("SELECT * FROM Customer Where CustomerID = " + id, modRecordSet.cnnDB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			Report.Database.Tables(2).SetDataSource(rsCompany);

			rsTransaction = new ADODB.Recordset();
			//rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
			//'" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			//changed for OPEN ITEM
			//rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
			//'" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			rsCustTransCheck = new ADODB.Recordset();
			rsCustTransCheck.Open("SELECT * FROM CustomerTransaction Where CustomerTransaction_CustomerID = " + id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			if (rsCustTransCheck.Fields.Count <= 12) {
				rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit, 0, 0, 0 FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + id + "));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			} else {
				rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]), CustomerTransaction.CustomerTransaction_Reference & IIf([CustomerTransaction.CustomerTransaction_Allocated]<>[CustomerTransaction_Amount] AND [CustomerTransaction.CustomerTransaction_Allocated]<>0,'   (P)',Null), CustomerTransaction.CustomerTransaction_PersonName, TransactionType.TransactionType_Name," + " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))>0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS debit," + " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS credit, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + id + ") AND ((CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<>0));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			}
			//Report.Database.Tables(3).SetDataSource rsTransaction, 3
			if (rsTransaction.BOF | rsTransaction.EOF) {
				rsTransaction = new ADODB.Recordset();
				rsTransaction.Open("SELECT 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0," + " 0, 0 AS debit, 0 AS credit;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				Report.Database.Tables(3).SetDataSource(rsTransaction);
				//Exit Sub
			} else {
				Report.Database.Tables(3).SetDataSource(rsTransaction);
			}

			if (rsTransaction.BOF | rsTransaction.EOF) {
				return;
			}


			//Set rsInterest = New Recordset
			//rsInterest.Open ("SELECT * FROM Interest WHERE (((CustomerID)=" & id & ")) and (Debit>0);"), cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			rsInterest = modRecordSet.getRS(ref "SELECT * FROM Interest WHERE (((CustomerID)=" + id + ")) and (Debit>0);");

			//If rsInterest.BOF Or rsInterest.EOF Then
			if (rsInterest.RecordCount > 0) {
				Report.ReportDefinition.ReportObjects("Field20").Top = 280;
				Report.ReportDefinition.ReportObjects("Field21").Top = 280;
				Report.ReportDefinition.ReportObjects("Field22").Top = 280;
				Report.ReportDefinition.ReportObjects("Field23").Top = 280;

				Report.Database.Tables(4).SetDataSource(rsInterest);

			} else {
				//Set rsInterest = New Recordset
				//rsInterest.Open "SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
				rsInterest = modRecordSet.getRS(ref "SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;");
				Report.ReportDefinition.Sections("Field20").SectionFormat.EnableSuppress = true;
				Report.ReportDefinition.Sections("Field21").SectionFormat.EnableSuppress = true;
				Report.ReportDefinition.Sections("Field22").SectionFormat.EnableSuppress = true;
				Report.ReportDefinition.Sections("Field23").SectionFormat.EnableSuppress = true;
				Report.Database.Tables(4).SetDataSource(rsInterest);

				//Exit Sub
				//Set rsInterest = New Recordset
				//rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			}

			if (rs.Fields("Company_DebtorPrintBal").Value == true) {
				CrystalDecisions.CrystalReports.Engine.TextObject tObj = Report.ReportDefinition.ReportObjects("Text5");
				tObj.Color = Color.White;
			}

			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			//    frmReportShow.CRViewer1.PrintReport
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//    Unload frmReportShow

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
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


		private void frmCustomerStatement_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool loading = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			loading = true;
			rs = modRecordSet.getRS(ref "SELECT Company_MonthendID FROM Company;");
			gMonth = rs.Fields("Company_MonthendID").Value - 1;
			cmbMonth.SelectedIndex = 0;
			doSearch();
			loadLanguage();
			//Dim rs As New Recordset
			cmbMonthEnd.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT Min(DayEnd.DayEnd_Date) AS MinOfDayEnd_Date, Max(DayEnd_1.DayEnd_Date) AS MaxOfDayEnd_Date, Company.Company_MonthEndID, MonthEnd.MonthEndID FROM Company, (DayEnd AS DayEnd_1 INNER JOIN MonthEnd ON DayEnd_1.DayEnd_MonthEndID = MonthEnd.MonthEndID) INNER JOIN DayEnd ON MonthEnd.MonthEndID = DayEnd.DayEnd_MonthEndID GROUP BY Company.Company_MonthEndID, MonthEnd.MonthEndID ORDER BY MonthEnd.MonthEndID DESC");
			gMonth = rs.Fields("Company_MonthEndID").Value;
			while (!(rs.EOF)) {
				if (rs.Fields("Company_MonthEndID").Value == rs.Fields("MonthEndID").Value) {
					cmbMonthEnd.Items.Add("Select Month");
				} else {
					cmbMonthEnd.Items.Add((rs.Fields("Company_MonthEndID").Value - rs.Fields("MonthEndID").Value) + " Month/s ago  ( " + Strings.Format(rs.Fields("MinOfDayEnd_Date").Value, "dd-MM-yyyy") + "   /   " + Strings.Format(rs.Fields("MaxOfDayEnd_Date").Value, "dd-MM-yyyy") + " )");
				}
				rs.moveNext();
			}
			cmbMonthEnd.SelectedIndex = 0;
		}

		private void frmCustomerStatement_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}
		private void frmCustomerStatement_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
			string lString = null;
			BindingSource bind = new BindingSource();
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "AND (Customer_InvoiceName LIKE '%" + Strings.Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") + "%')";
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT CustomerID, Customer_InvoiceName FROM Customer WHERE Customer_Disabled = 0 " + lString + " ORDER BY Customer_InvoiceName");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "Customer_InvoiceName";


			//Bind the DataCombo to the ADO Recordset
			//DataList1.DataSource = gRS
			bind.DataSource = gRS;
			DataList1.DataBindings.Add(bind.DataSource);
			DataList1.boundColumn = "CustomerID";

		}
	}
}
