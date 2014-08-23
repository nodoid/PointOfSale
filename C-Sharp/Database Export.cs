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
	internal class DatabaseExport
	{
		public event ExportStartedEventHandler ExportStarted;
		public delegate void ExportStartedEventHandler(DatabaseExportEnum ExportingFormat);
		public event ExportErrorEventHandler ExportError;
		public delegate void ExportErrorEventHandler(ref ErrObject myError, DatabaseExportEnum ExportingFormat);
		public event ExportCompleteEventHandler ExportComplete;
		public delegate void ExportCompleteEventHandler(bool Success, DatabaseExportEnum ExportingFormat);

		private string ExportFilePath;
		private ADODB.Recordset ADODBRecordset;

		public enum DatabaseExportEnum
		{
			CSV = 0,
			HTML = 1,
			Excel = 2
		}
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int GetQueueStatus(int qsFlags);


		public string FilePath {
			get { return ExportFilePath; }
			set { ExportFilePath = value; }
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
			ADODB.Recordset rs = default(ADODB.Recordset);
			int i = 0;
			int TotalRecords = 0;
			bool ErrorOccured = false;
			short NumberOfFields = 0;
			const string Quote = "\"";
			//Faster then Chr$(34)
			string sql = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();


			 // ERROR: Not supported in C#: OnErrorStatement


			if (ExportStarted != null) {
				ExportStarted(DatabaseExportEnum.CSV);
			}

			rs = modReport.getRSreport(ref "SELECT * FROM aPastelDescription1");

			if (rs.RecordCount > 0) {

				FileSystem.FileOpen(1, ExportFilePath, OpenMode.Output, OpenAccess.Write);

				var _with1 = modReport.getRSreport(ref ref "SELECT * FROM aPastelDescription1");
				_with1.MoveFirst();
				NumberOfFields = _with1.Fields.Count - 1;

				if (PrintHeader) {
					//Now add the field names
					for (i = 0; i <= NumberOfFields - 1; i++) {
						FileSystem.Print(1, _with1.Fields(i).Name + ",");
						//similar to the ones below
					}
					FileSystem.PrintLine(1, _with1.Fields(NumberOfFields).Name);
				}

				while (!_with1.EOF) {
					TotalRecords = TotalRecords + 1;
					//If there is an emty field,
					for (i = 0; i <= NumberOfFields; i++) {
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						//add a , to indicate it is
						if ((Information.IsDBNull(_with1.Fields(i).Value))) {
							FileSystem.Print(1, ",");
							//empty
						} else {
							if (i == NumberOfFields) {
								FileSystem.Print(1, Quote + Strings.Trim(Convert.ToString(_with1.Fields(i).Value)) + Quote);
							} else {
								FileSystem.Print(1, Quote + Strings.Trim(Convert.ToString(_with1.Fields(i).Value)) + Quote + ",");
							}
						}
						//Putting data under "" will not
					}
					//confuse the reader of the file
					DoEventsEx();
					//between Dhaka, Bangladesh as two
					FileSystem.PrintLine(1);
					//fields or as one field.
					_with1.moveNext();

				}
				FileSystem.FileClose(1);
				if (ExportComplete != null) {
					ExportComplete(!ErrorOccured, DatabaseExportEnum.CSV);
				}


			} else {
				Interaction.MsgBox("There are no database record to export to file", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);


			}


			return;
			ExportTracker:

			if (ExportError != null) {
				ExportError(Err(), DatabaseExportEnum.CSV);
			}
			if (Err().Number == 0) {
				 // ERROR: Not supported in C#: ResumeStatement

				ErrorOccured = true;
			}

		}
//UPGRADE_NOTE: Argument type has been changed to Object. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="D0BD8832-D1AC-487C-8AA5-B36F9284E51E"'
		public bool ShowSave(object cmdlg, DatabaseExportEnum ExportMode, ref string DialogTitle = "Export Recordset to...")
		{
			bool functionReturnValue = false;
			string t_Day = null;
			string t_Month = null;
			string st_Name = null;
			string Extention = null;

			t_Day = Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			t_Month = Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));

			if (Strings.Len(t_Day) == 1)
				t_Day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			if (Strings.Len(t_Month) == 1)
				t_Month = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));

			st_Name = "PasteExport" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Month) + Strings.Trim(t_Day);

			if (ExportMode == DatabaseExportEnum.CSV) {
				Extention = "Comma Separated Values (*.csv)|*.csv|Text Files (*.txt)|*.txt|";
			}

			 // ERROR: Not supported in C#: OnErrorStatement


			var _with2 = cmdlg;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.CancelError. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.CancelError = true;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.DialogTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.DialogTitle = DialogTitle;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.FileName = st_Name;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.filter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.filter = Extention;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FilterIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.FilterIndex = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.ShowSave. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with2.ShowSave();
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ExportFilePath = _with2.FileName;

			if (!string.IsNullOrEmpty(ExportFilePath)) {
				functionReturnValue = true;
			}
			Extracter:
			return functionReturnValue;


		}
	}
}
