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
	internal partial class frmGlobalCost : System.Windows.Forms.Form
	{
		string strPath_DB1;

		private void loadLanguage()
		{

			//frmGlobalCost = No Code    [Update Cost]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmGlobalCost.Caption = rsLang("LanguageLayoutLnk_Description"): frmGlobalCost.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Closest Match DB entry 2490 = Password
			//Frame1 = No Code           [Passwords]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame11.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Closest Match DB entry 2490 = Password
			//Label2 = No Code           [Passwords]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Labels2.Caption = rsLang("LanguageLayoutLnk_Description"): Labels2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGlobalCost.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public bool ShowOpen()
		{
			bool functionReturnValue = false;
			string Extention = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			var _with1 = cmdDlgOpen;
			//.CancelError = True
			_with1.Title = "Upload Cost File";
			_with1.FileName = "";
			_with1.Filter = "CSV File (*.csv)|*.csv|CSV (*.csv)|*.csv|";
			_with1.FilterIndex = 0;
			_with1.ShowDialog();
			strPath_DB1 = _with1.FileName;


			if (!string.IsNullOrEmpty(strPath_DB1)) {
				this.txtFileName.Text = strPath_DB1;
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
		public bool ImportCSVtoAccess(ref string strFilePath)
		{
			bool functionReturnValue = false;
			bool dReceipt = false;
			Scripting.FileSystemObject oFileSys = new Scripting.FileSystemObject();
			Scripting.TextStream oFile = default(Scripting.TextStream);
			string strCSV = null;
			string strFldName = null;
			//String of fields' name
			string strFV = null;
			//String of fields' values
			short iCount = 0;

			short x = 0;
			string strStr_1 = null;
			string strStr_2 = null;
			string temp = null;
			string strIn = null;
			bool blEmpty = false;
			bool blTrue = false;

			 // ERROR: Not supported in C#: OnErrorStatement


			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();

			blTrue = false;
			blEmpty = true;

			dReceipt = false;

			if (oFileSys.FileExists(strFilePath)) {

				oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, false, Scripting.Tristate.TristateUseDefault);

				while (!oFile.AtEndOfLine) {

					if (prgUpload.Value == 300) {
						prgUpload.Value = 0;
					} else {
						prgUpload.Value = prgUpload.Value + 1;
					}

					blEmpty = false;
					strCSV = oFile.ReadLine;
					strFV = strCSV;

					strFldName = "Barcode Text,CostPrice Currency";

					if (blTrue == false) {
						strFldName = "Barcode Text,CostPrice Currency";
						modRecordSet.cnnDB.Execute("CREATE TABLE FRIENDYFOODHALL (" + strFldName + ")");
						blTrue = true;
						dReceipt = true;
						//2 Read header
						strCSV = oFile.ReadLine;
					}



					if (strCSV != Constants.vbNullString) {

						//Repeat 4 Times
						//
						strStr_1 = strCSV;
						x = Strings.Len(strCSV) - Strings.Len(Strings.Right(strCSV, Strings.Len(strCSV) - Strings.InStr(strCSV, ",")));
						strStr_1 = Strings.Mid(strStr_1, 1, x - 1);


						strStr_2 = Strings.Right(strCSV, Strings.Len(strCSV) - Strings.InStr(strCSV, ","));
						temp = strStr_2;

						strIn = "INSERT INTO FRIENDYFOODHALL (Barcode,CostPrice) VALUES ('" + Strings.Trim(strStr_1) + "'," + Convert.ToDecimal(Strings.Trim(strStr_2)) + ")";
						modRecordSet.cnnDB.Execute(strIn);


					}

				}

				if (blEmpty == true) {
					Interaction.MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					functionReturnValue = false;
					return functionReturnValue;
				}
				prgUpload.Value = 300;
				functionReturnValue = true;
				return functionReturnValue;
			} else if (!oFileSys.FileExists(strFilePath)) {
				Interaction.MsgBox("CSV File does not exist", MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				functionReturnValue = false;
				return functionReturnValue;
			}
			ImportError:



			Interaction.MsgBox("Export Aborted Because " + Err().Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			modRecordSet.cnnDB.Execute("DROP TABLE FRIENDYFOODHALL");
			return functionReturnValue;

		}
		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (ShowOpen() == true) {
				if (ImportCSVtoAccess(ref Strings.Trim(txtFileName.Text)) == true) {
					DoCostingUpdate();
					this.Close();
				}
			} else {
				return;
			}

		}
		private void Command3_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		public void DoCostingUpdate()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);

			rj = modRecordSet.getRS(ref "SELECT StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN FRIENDYFOODHALL ON Catalogue.Catalogue_Barcode = FRIENDYFOODHALL.BARCODE WHERE FRIENDYFOODHALL.BARCODE IS NOT NULL;");

			if (rj.RecordCount) {
				if (Interaction.MsgBox("Your about to update [ " + rj.RecordCount + " ] Records do you want to continue?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
					modRecordSet.cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON [StockItem].[StockItemID]=[Catalogue].[Catalogue_StockItemID]) INNER JOIN FRIENDYFOODHALL ON [Catalogue].[Catalogue_Barcode]=[FRIENDYFOODHALL].[BARCODE] SET StockItem.StockItem_ListCost = [FRIENDYFOODHALL]![CostPrice], StockItem.StockItem_ActualCost = [FRIENDYFOODHALL]![CostPrice] WHERE [FRIENDYFOODHALL].[BARCODE] IS NOT NULL;");
					modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_ActualCost = 1,StockItem_ListCost= 1 WHERE StockItem.StockItem_ListCost = 0 OR  StockItem.StockItem_ListCost = 0;");
					Interaction.MsgBox("Update Completed successfully");
					modRecordSet.cnnDB.Execute("DROP TABLE FRIENDYFOODHALL");

				}
			}

		}
		private void txtPassword_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 27)
				this.Close();
		}
		private void txtPassword_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			string dtDate = null;
			string dtMonth = null;
			string stPass = null;

			//Construct password...........
			if (KeyAscii == 13) {
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

				if (Strings.Trim(this.txtPassword.Text) == stPass) {
					//Call intialize process...
					Frame1.Visible = false;
				} else {
					Interaction.MsgBox("Incorrect password was entered!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "4POS Stock Fix");
				}

			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
