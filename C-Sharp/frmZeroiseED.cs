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
	internal partial class frmZeroiseED : System.Windows.Forms.Form
	{
		public event ExportStartedEventHandler ExportStarted;
		public delegate void ExportStartedEventHandler(DatabaseExport.DatabaseExportEnum ExportingFormat);
		public event ExportErrorEventHandler ExportError;
		public delegate void ExportErrorEventHandler(ref ErrObject myError, DatabaseExport.DatabaseExportEnum ExportingFormat);
		public event ExportCompleteEventHandler ExportComplete;
		public delegate void ExportCompleteEventHandler(bool Success, DatabaseExport.DatabaseExportEnum ExportingFormat);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetQueueStatus(int qsFlags);
			// As ADODB.Recordset
		ADODB.Recordset rs;
		string sql;

		short gSection;

		const short sec_Payment = 0;
		const short sec_Debit = 1;
		const short sec_Credit = 2;

//Public Enum DatabaseExportEnum
//    [CSV] = 0
//    [HTML] = 1
//    [Excel] = 2
//End Enum

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2499;
			//Export Customer Details|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2501;
			//Please click start to export customer details|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2490;
			//Password|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2496;
			//Start|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStart.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStart.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmZeroiseED.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void frmZeroiseED_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
			//If App.PrevInstance = True Then End
			//If openConnection() = True Then
			//ExportToCSV
			//Else: MsgBox "Connection to database was not successful"
			//End If
		}
		private void cmdStart_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//If mdbFile.Text <> "" Then
			string dtDate = null;
			string dtMonth = null;
			string stPass = null;

			//Construct password...........
			if (Strings.Len(DateAndTime.Day(DateAndTime.Today)) == 1)
				dtDate = "0" + Conversion.Str(DateAndTime.Day(DateAndTime.Today));
			else
				dtDate = Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)));
			if (Strings.Len(DateAndTime.Month(DateAndTime.Today)) == 1)
				dtMonth = "0" + Conversion.Str(DateAndTime.Month(DateAndTime.Today));
			else
				dtMonth = Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)));

			//Create password
			stPass = dtDate + "##" + dtMonth;
			stPass = Strings.Replace(stPass, " ", "");

			if (Strings.Trim(txtPassword.Text) == stPass) {
				//       ZeroiseStock


				//Trim(mdbFile.Text)
				if (modRecordSet.openConnection() == true) {
					ExportToCSV();
				} else {
					Interaction.MsgBox("Connection to database was not successful");
				}

			} else {
				Interaction.MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords");
			}
			//Else
			//MsgBox "Upload your database before you continue", vbOKOnly, "Customers"
			//End If
		}

		public bool ShowOpen1()
		{
			bool functionReturnValue = false;
			string strPath_DB1 = null;
			string Extention = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			var _with1 = cmdDlgOpen;
			//.CancelError = True
			_with1.Title = "Upload Database";
			_with1.FileName = "";
			_with1.Filter = "Access File (*.mdb)|*.mdb|Access (*.mdb)|*.mdb|";
			_with1.FilterIndex = 0;
			_with1.ShowDialog();
			strPath_DB1 = _with1.FileName;
			if (!string.IsNullOrEmpty(strPath_DB1)) {
				mdbFile.Text = strPath_DB1;
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;
			Extracter:
			if (MsgBoxResult.Cancel) {
				return functionReturnValue;
			}
			Interaction.MsgBox(Err().Description);
			return functionReturnValue;
		}
		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			if (ShowOpen1() == true) {
			} else {
				return;
			}
		}
		public string FilePath {
			get {
				string functionReturnValue = null;
				short x = 0;
				string temp = null;
				string strPath_DB1 = null;
				strPath_DB1 = (Strings.Trim(mdbFile.Text));
				functionReturnValue = mdbFile.Text;
				temp = functionReturnValue;
				x = Strings.InStrRev(temp, "\\");
				functionReturnValue = Strings.Mid(temp, 1, x - 1);
				functionReturnValue = functionReturnValue + "\\";
				return functionReturnValue;
			}
			set {
				short x = 0;
				string temp = null;
				FilePath = mdbFile.Text;
				temp = FilePath;
				x = Strings.InStrRev(temp, "\\");
				FilePath = Strings.Mid(temp, 1, x - 1);
				FilePath = FilePath + "\\";
			}
		}
		private int DoEventsEx()
		{
			int functionReturnValue = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = GetQueueStatus(0x80 | 0x1 | 0x4 | 0x20 | 0x10);
			if (functionReturnValue != 0) {
				System.Windows.Forms.Application.DoEvents();
			}
			return functionReturnValue;
		}
		public void ExportToCSV(bool PrintHeader = true)
		{
			string ExportFilePath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int i = 0;
			int TotalRecords = 0;
			bool ErrorOccured = false;
			short NumberOfFields = 0;
			const string quote = "\"";
			//Faster then Chr$(34)
			string sql = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			cmdStart.Enabled = false;
			cmdExit.Enabled = false;
			txtPassword.Enabled = false;

			string ptbl = null;
			string t_day = null;
			string t_Mon = null;

			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)))) == 1)
				t_day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			else
				t_day = Convert.ToString(DateAndTime.Day(DateAndTime.Today));
			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)))) == 1)
				t_Mon = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));
			else
				t_Mon = Conversion.Str(DateAndTime.Month(DateAndTime.Today));


			ExportFilePath = modRecordSet.serverPath + "4POSDebtor" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Mon) + Strings.Trim(t_day);

			if (fso.FileExists(ExportFilePath + ".csv"))
				fso.DeleteFile((ExportFilePath + ".csv"));

			rs = modRecordSet.getRS(ref "SELECT CustomerID, Customer_InvoiceName, Customer_DepartmentName, Customer_FirstName, Customer_Surname, Customer_PhysicalAddress, Customer_PostalAddress, Customer_Telephone, Customer_Current as CurrentBalance,Customer_30Days as 30Days, Customer_60Days as 60days, Customer_90Days as 90Days, Customer_120Days as 120Days,Customer_150Days as 150Days  FROM Customer");

			prgBar.Maximum = rs.RecordCount;
			if (rs.RecordCount > 0) {

				FileSystem.FileOpen(1, ExportFilePath + ".csv", OpenMode.Output);
				var _with2 = modRecordSet.getRS(ref ref "SELECT CustomerID, Customer_InvoiceName, Customer_DepartmentName, Customer_FirstName, Customer_Surname, Customer_PhysicalAddress, Customer_PostalAddress, Customer_Telephone, Customer_Current as CurrentBalance,Customer_30Days as 30Days, Customer_60Days as 60days, Customer_90Days as 90Days, Customer_120Days as 120Days,Customer_150Days as 150Days  FROM Customer");
				rs.MoveFirst();
				NumberOfFields = rs.Fields.Count - 1;
				if (PrintHeader) {
					//Now add the field names
					for (i = 0; i <= NumberOfFields - 1; i++) {
						FileSystem.Print(1, rs.Fields(i).name + ",");
						//similar to the ones below
					}
					FileSystem.PrintLine(1, rs.Fields(NumberOfFields).name);
				}

				while (!rs.EOF) {
					prgBar.Value = prgBar.Value + 1;
					 // ERROR: Not supported in C#: OnErrorStatement

					TotalRecords = TotalRecords + 1;

					//If there is an emty field,
					for (i = 0; i <= NumberOfFields; i++) {
						//add a , to indicate it is
						if ((Information.IsDBNull(rs.Fields(i).Value))) {
							FileSystem.Print(1, ",");
							//empty
						} else {
							if (i == NumberOfFields) {
								FileSystem.Print(1, quote + Strings.Trim(Convert.ToString(rs.Fields(i).Value)) + quote);
							} else {
								FileSystem.Print(1, quote + Strings.Trim(Convert.ToString(rs.Fields(i).Value)) + quote + ",");
							}
						}
						//Putting data under "" will not
					}
					//confuse the reader of the file
					DoEventsEx();
					//between Dhaka, Bangladesh as two
					FileSystem.PrintLine(1);
					//fields or as one field.
					rs.moveNext();

				}
				FileSystem.FileClose(1);

				Interaction.MsgBox("Customer details were successfully exported to : " + FilePath + "" + "4POSProd" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Mon) + Strings.Trim(t_day) + ".csv", MsgBoxStyle.OkOnly, "Customers");
				//   DoEvents
				//   DoEvents
				// MsgBox "Now Zeroising...", vbOKOnly, "Customers"

				//  cmdStart.Enabled = False
				//  cmdExit.Enabled = False

				//  Set rsZ = getRS("SELECT CustomerID FROM Customer")
				//  Do While Not rsZ.EOF
				//          DoEvents
				//          cmdProcess_Click (rsZ("CustomerID"))
				//          DoEvents
				//  rsZ.moveNext
				//  Loop

				//MsgBox "Completed", vbOKOnly, "Customers"

				//cmdStart.Enabled = True
				//cmdExit.Enabled = True
				this.Close();
			}
			System.Windows.Forms.Cursor.Current = Cursors.Default;

			rs.Close();
			//cnnDB.Close
			//Set cnnDB = Nothing
			//closeConnection
		}
		private void frmZeroiseED_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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




		private void cmdProcess_Click(ref int cID)
		{
			decimal amount = default(decimal);
			string txtAmountText = null;
			string txtNarrativeText = null;
			string txtNotesText = null;
			ADODB.Recordset rsCus = default(ADODB.Recordset);
			string cSQL = null;
			string sql = null;
			string sql1 = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string id = null;
			decimal days120 = default(decimal);
			decimal days60 = default(decimal);
			decimal current = default(decimal);
			decimal lAmount = default(decimal);
			decimal days30 = default(decimal);
			decimal days90 = default(decimal);
			decimal days150 = default(decimal);
			System.Windows.Forms.Application.DoEvents();
			//If txtNarrative.Text = "" Then
			//    MsgBox "Narrative is a mandarory field", vbExclamation, Me.Caption
			//    txtNarrative.SetFocus
			//    Exit Sub
			//End If
			//If CCur(txtAmount.Text) = 0 Then
			//   MsgBox "Amount is a mandarory field", vbExclamation, Me.Caption
			//   txtAmount.SetFocus
			//   Exit Sub
			//End If


			cSQL = "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit";
			cSQL = cSQL + " FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID";
			cSQL = cSQL + " WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + cID + "))";
			cSQL = cSQL + " ORDER BY CustomerTransaction.CustomerTransaction_Date DESC;";
			rsCus = modRecordSet.getRS(ref cSQL);
			//rsCus("credit") <> ""
			if (Convert.ToDecimal(rsCus("CustomerTransaction_Amount").Value) < 0) {
				gSection = 1;
				txtNotesText = "Zeroise Creditors Accounts";
				txtNarrativeText = "Zeroise Creditors Accounts";
				txtAmountText = (rsCus("CustomerTransaction_Amount").Value / -1);
			}

			//rsCus("debit") <> ""
			if (Convert.ToDecimal(rsCus("CustomerTransaction_Amount").Value) > 0) {
				gSection = 2;
				txtNotesText = "Zeroise Debitors Accounts";
				txtNarrativeText = "Zeroise Debitors Accounts";
				txtAmountText = (rsCus("CustomerTransaction_Amount"));
			}


			sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )";
			switch (gSection) {
				case sec_Payment:
					sql = sql + "SELECT " + cID + " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(txtNotesText, "'", "''") + "' AS description, " + Convert.ToDecimal(0 - Convert.ToDecimal(txtAmountText)) + " AS amount, '" + Strings.Replace(txtNarrativeText, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
				case sec_Debit:
					sql = sql + "SELECT " + cID + " AS Customer, 4 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(txtNotesText, "'", "''") + "' AS description, " + Convert.ToDecimal(txtAmountText) + " AS amount, '" + Strings.Replace(txtNarrativeText, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
				case sec_Credit:
					sql = sql + "SELECT " + cID + " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(txtNotesText, "'", "''") + "' AS description, " + Convert.ToDecimal(0 - Convert.ToDecimal(txtAmountText)) + " AS amount, '" + Strings.Replace(txtNarrativeText, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
			}

			modRecordSet.cnnDB.Execute(sql);

			rs = modRecordSet.getRS(ref "SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction");
			if (rs.BOF | rs.EOF) {
			} else {
				id = rs.Fields("id").Value;
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_Current) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_30Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_60Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_90Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_120Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_150Days) Is Null));");

				rs = modRecordSet.getRS(ref "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " + id + "));");

				amount = rs.Fields("CustomerTransaction_Amount").Value;
				current = rs.Fields("Customer_Current").Value;
				days30 = rs.Fields("Customer_30Days").Value;
				days60 = rs.Fields("Customer_60Days").Value;
				days90 = rs.Fields("Customer_90Days").Value;
				days120 = rs.Fields("Customer_120Days").Value;
				days150 = rs.Fields("Customer_150Days").Value;
				if (amount < 0) {
					days150 = days150 + amount;
					if ((days150 < 0)) {
						amount = days150;
						days150 = 0;
					} else {
						amount = 0;
					}
					days120 = days120 + amount;
					if ((days120 < 0)) {
						amount = days120;
						days120 = 0;
					} else {
						amount = 0;
					}
					days90 = days90 + amount;
					if ((days90 < 0)) {
						amount = days90;
						days90 = 0;
					} else {
						amount = 0;
					}
					days60 = days60 + amount;
					if ((days60 < 0)) {
						amount = days60;
						days60 = 0;
					} else {
						amount = 0;
					}
					days30 = days30 + amount;
					if ((days30 < 0)) {
						amount = days30;
						days30 = 0;
					} else {
						amount = 0;
					}
				}
				current = current + amount;
				//cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
				modRecordSet.cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " + 0 + ", Customer.Customer_30Days = " + 0 + ", Customer.Customer_60Days = " + 0 + ", Customer.Customer_90Days = " + 0 + ", Customer.Customer_120Days = " + 0 + ", Customer.Customer_150Days = " + 0 + " WHERE (((Customer.CustomerID)=" + rs.Fields("CustomerTransaction_CustomerID").Value + "));");
			}
		}
	}
}
