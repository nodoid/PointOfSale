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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmCustomerStatementRun : System.Windows.Forms.Form
	{
		bool loading;
		short gID;
		short gLastIndex;
		short gMonth;
		ADODB.Connection cnnDBStatement = new ADODB.Connection();

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1391;
			//Customer Statement Run|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1393;
			//Clear All|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClear.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClear.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1395;
			//Customers|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCustomerStatementRun.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClear_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			for (x = 0; x <= lstCustomer.Items.Count - 1; x++) {
				lstCustomer.SetItemChecked(x, false);
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;
			loading = true;
			rs = modRecordSet.getRS(ref "SELECT Company_MonthendID FROM Company;");
			gMonth = rs.Fields("Company_MonthendID").Value;
			//- 1
			if (gMonth < 1)
				gMonth = 1;
			rs = modRecordSet.getRS(ref "SELECT Customer.CustomerID, Customer.Customer_InvoiceName, Customer.Customer_PrintStatement From Customer WHERE Customer_Disabled = 0 ORDER BY Customer.Customer_InvoiceName;");
			int m = 0;
			while (!(rs.EOF)) {
				m = lstCustomer.Items.Add(new LBI(rs.Fields("Customer_InvoiceName").Value, rs.Fields("CustomerID").Value));
				lstCustomer.SetItemChecked(m, rs.Fields("Customer_PrintStatement").Value);
				rs.moveNext();
			}
			rs.MoveFirst();
			lstCustomer.SelectedIndex = 0;
			loading = false;

			loadLanguage();
			this.ShowDialog();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			short x = 0;
			string strDBPath = null;

			strDBPath = modRecordSet.serverPath + "month" + gMonth + ".mdb";
			//If FSO.FileExists(strDBPath) Then

			//   With cnnDBStatement
			//        .Provider = "MSDataShape"
			//        cnnDBStatement.Open "Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
			//   End With
			//
			//    For x = 0 To lstCustomer.ListCount - 1
			//         If lstCustomer.Selected(x) Then
			//            CustomerStatement lstCustomer.ItemData(x)
			//         End If
			//    Next x
			//    cnnDBStatement.Close
			//  Else

			var _with1 = cnnDBStatement;
			_with1.Provider = "MSDataShape";
			cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + modRecordSet.serverPath + "pricing.mdb" + ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw");

			for (x = 0; x <= lstCustomer.Items.Count - 1; x++) {
				if (lstCustomer.GetItemChecked(x)) {
					CustomerStatement(ref Convert.ToInt32(lstCustomer.SelectedIndex));
				}
			}
			cnnDBStatement.Close();
			//MsgBox "Database [month" & gMonth & ".mdb] could not be found", vbApplicationModal + vbInformation + vbOKOnly, App.title
			//Exit Sub
			// End If



		}
		private void CustomerStatement(ref int id)
		{
			ADODB.Recordset rsInterest = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			int lNumber = 0;
			string lAddress = null;
			ADODB.Recordset rs = new ADODB.Recordset();
			string sql = null;
			//Dim Report As New cryCustomerStatement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerStatement.rpt");
			System.DateTime lDate = default(System.DateTime);
			rs = modRecordSet.getRS(ref "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" + gMonth + "));");
			//rs.Open "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			//Report.txtStatementDate.SetText Format(rs("MonthEnd_Date"), "dd mmm yyyy")
			Report.SetParameterValue("txtStatementDate", Strings.Format(DateAndTime.Today, "dd mmm yyyy"));
			lDate = rs.Fields("MonthEnd_Date").Value;

			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			lDate = System.Date.FromOADate(lDate.ToOADate() + 10);
			lDate = DateAndTime.DateSerial(DateAndTime.Year(lDate), DateAndTime.Month(lDate), 1);
			lDate = System.Date.FromOADate(lDate + rs.Fields("Company_PaymentDay").Value - 1);
			//Report.txtPaymentDate.SetText Format(lDate, "dd mmm yyyy")

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
			Report.Database.Tables(2).SetDataSource(rsCompany);

			rsTransaction = new ADODB.Recordset();
			//rsTransaction.Open "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + id + "));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

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

			rsInterest = new ADODB.Recordset();
			rsInterest.Open("SELECT * FROM Interest WHERE (((CustomerID)=" + id + ")) and (Debit>0);", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			//If rsInterest.BOF Or rsInterest.EOF Then
			if (rsInterest.RecordCount > 0) {
				//Report.Field20.Top = 280
				//Report.Field21.Top = 280
				//Report.Field22.Top = 280
				//Report.Field23.Top = 280

				Report.Database.Tables(4).SetDataSource(rsInterest);
			} else {
				rsInterest = new ADODB.Recordset();
				rsInterest.Open("SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				//Report.Field20.Suppress = True
				//Report.Field21.Suppress = True
				//Report.Field22.Suppress = True
				//Report.Field23.Suppress = True
				Report.Database.Tables(4).SetDataSource(rsInterest);

				//Exit Sub
				//Set rsInterest = New Recordset
				//rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			}

			//Report.PrintOut(False, 1)
			Report.PrintToPrinter(1, false, 0, 0);

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void frmCustomerStatementRun_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void frmCustomerStatementRun_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//Dim x As Short
			//Dim bit As Integer
			//    For x = 0 To Me.lstCustomer.ListCount - 1
			//        If lstCustomer.Selected(x) Then
			//            bit = bit + lstCustomer.ItemData(x)
			//        End If
			//    Next x
			//    cnnDB.Execute "UPDATE Person SET Person.Person_SecurityBit = " & bit & " WHERE (((Person.PersonID)=" & gID & "));"
		}
	}
}
