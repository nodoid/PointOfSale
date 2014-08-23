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
	static class modReport
	{
		public static ADODB.Connection cnnDBreport;
		public static ADODB.Connection cnnDBConsReport;
		public static ADODB.Recordset getRSreport(ref string sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			string Path = null;
			string strDBPath = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			Debug.Print(sql);
			functionReturnValue.Open(sql, cnnDBreport, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;
			getRSreport_Error:

			if (cnnDBreport == null) {
				Interaction.MsgBox(Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + " cnnDBreport object has not been made.");
			} else if (Err().Description == "Not a valid password.") {
				Interaction.MsgBox("Error while getRSreport and Error is :" + Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + cnnDBreport.ConnectionString + Constants.vbCrLf + Constants.vbCrLf + " --- " + cnnDBreport.State);

				modRecordSet.cnnDB.Close();
				//UPGRADE_NOTE: Object cnnDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				modRecordSet.cnnDB = null;
				modRecordSet.cnnDB = new ADODB.Connection();
				//UPGRADE_WARNING: Couldn't resolve default property of object strDBPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strDBPath = modRecordSet.serverPath + "pricing.mdb";
				//UPGRADE_WARNING: Couldn't resolve default property of object strDBPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
				//cnnDB.CursorLocation = adUseClient
				//UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modRecordSet.cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Mode=Share Deny Read|Share Deny Write;Persist Security Info=False;Data Source= " + Path);
				modRecordSet.cnnDB.Execute("ALTER DATABASE PASSWORD Null " + " " + "lqd");
				modRecordSet.cnnDB.Close();
				//UPGRADE_NOTE: Object cnnDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				modRecordSet.cnnDB = null;
				modRecordSet.openConnection();

			} else {
				Interaction.MsgBox("Error while getRSreport and Error is :" + Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + cnnDBreport.ConnectionString + Constants.vbCrLf + Constants.vbCrLf + " --- " + cnnDBreport.State);
			}
			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}
		public static ADODB.Recordset getRSreport1(ref object sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cnnDBConsReport, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;
			getRSreport1_Error:

			if (cnnDBConsReport == null) {
				Interaction.MsgBox(Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + " cnnDBConsReport object has not been made.");
			} else {
				Interaction.MsgBox("Error while getRSreport1 and Error is :" + Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + " --- " + cnnDBConsReport.ConnectionString + Constants.vbCrLf + Constants.vbCrLf + " --- " + cnnDBConsReport.State);
			}
			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}

		public static bool openConnectionReport()
		{
			bool functionReturnValue = false;
			string Path = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			bool createDayend = false;
			string strDBPath = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			createDayend = false;
			functionReturnValue = true;
			cnnDBreport = new ADODB.Connection();
			strDBPath = modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb";
			var _with1 = cnnDBreport;
			_with1.Provider = "Microsoft.ACE.OLEDB.12.0";
			_with1.Properties("Jet OLEDB:System Database").Value = modRecordSet.serverPath + "Secured.mdw";
			_with1.Open(strDBPath, "liquid", "lqd");
			return functionReturnValue;
			withPass:

			//If serverPath = "" Then setNewServerPath
			//If serverPath <> "" Then
			cnnDBreport = new ADODB.Connection();
			strDBPath = modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb";
			//UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
			cnnDBreport.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			//UPGRADE_WARNING: Couldn't resolve default property of object Path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cnnDBreport.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " + Path);
			functionReturnValue = true;
			return functionReturnValue;
			openConnection_Error:
			//End If

			if (Err().Description == "[Microsoft][ODBC Microsoft Access Driver] Not a valid password.") {
				goto withPass;
			} else if (Err().Description == "Not a valid password.") {
				goto withPass;
			}

			functionReturnValue = false;
			Interaction.MsgBox(Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + " openConnectionReport object has not been made.");
			return functionReturnValue;
		}
		public static bool openConsReport(ref string strL)
		{
			bool functionReturnValue = false;
			string strTable = null;
			bool createDayend = false;
			string strDBPath = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			createDayend = false;

			cnnDBConsReport = new ADODB.Connection();

			strDBPath = modRecordSet.StrLocRep + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb";

			cnnDBConsReport.Open("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source= " + strDBPath + ";");
			openConnection_Error:

			functionReturnValue = false;
			Interaction.MsgBox(Err().Number + " " + Err().Description + " " + Err().Source + Constants.vbCrLf + Constants.vbCrLf + " openConsReport object has not been made.");
			return functionReturnValue;
		}
		public static void closeConnectionReport()
		{
			cnnDBreport.Close();
			//UPGRADE_NOTE: Object cnnDBreport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cnnDBreport = null;
		}
	}
}
