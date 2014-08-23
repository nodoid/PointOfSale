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
using Microsoft.Win32;
namespace _4PosBackOffice.NET
{
	static class modUtilities
	{
		public const int REG_SZ = 1;
		public const int REG_DWORD = 4;

		public const int HKEY_CLASSES_ROOT = 0x80000000;
		public const int HKEY_CURRENT_USER = 0x80000001;
		public const int HKEY_LOCAL_MACHINE = 0x80000002;
		public const int HKEY_USERS = 0x80000003;

		public const short ERROR_NONE = 0;
		public const short ERROR_BADDB = 1;
		public const short ERROR_BADKEY = 2;
		public const short ERROR_CANTOPEN = 3;
		public const short ERROR_CANTREAD = 4;
		public const short ERROR_CANTWRITE = 5;
		public const short ERROR_OUTOFMEMORY = 6;
		public const short ERROR_ARENA_TRASHED = 7;
		public const short ERROR_ACCESS_DENIED = 8;
		public const short ERROR_INVALID_PARAMETERS = 87;
		public const short ERROR_NO_MORE_ITEMS = 259;

		public const int KEY_QUERY_VALUE = 0x1;
		public const int KEY_SET_VALUE = 0x2;
		public const int KEY_ALL_ACCESS = 0x3f;

		public const short REG_OPTION_NON_VOLATILE = 0;
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern int RegCloseKey(int hkey);
		[DllImport("advapi32.dll", EntryPoint = "RegCreateKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegCreateKeyEx(int hkey, string lpSubKey, int Reserved, string lpClass, int dwOptions, int samDesired, int lpSecurityAttributes, ref int phkResult, ref int lpdwDisposition);
		[DllImport("advapi32.dll", EntryPoint = "RegOpenKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegOpenKeyEx(int hkey, string lpSubKey, int ulOptions, int samDesired, ref int phkResult);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegQueryValueExString(int hkey, string lpValueName, int lpReserved, ref int lpType, string lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegQueryValueExLong(int hkey, string lpValueName, int lpReserved, ref int lpType, ref int lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegQueryValueExNULL(int hkey, string lpValueName, int lpReserved, ref int lpType, int lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegSetValueExString(int hkey, string lpValueName, int Reserved, int dwType, string lpValue, int cbData);
		[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int RegSetValueExLong(int hkey, string lpValueName, int Reserved, int dwType, ref int lpValue, int cbData);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern int SetForegroundWindow(int hwnd);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]


		private static extern int BringWindowToTop(int hwnd);
		[DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int FindWindow(object lpClassName, object lpWindowName);

		private const int LOCALE_SSHORTDATE = 0x1f;
		private const int WM_SETTINGCHANGE = 0x1a;
		private const int HWND_BROADCAST = 0xffff;
		[DllImport("kernel32", EntryPoint = "SetLocaleInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern bool SetLocaleInfo(int Locale, int LCType, string lpLCData);
		[DllImport("user32", EntryPoint = "PostMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int PostMessage(int hwnd, int wMsg, int wParam, int lParam);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetSystemDefaultLCID();

		public static void setShortDateFormat()
		{
			int dwLCID = 0;
			dwLCID = GetSystemDefaultLCID();
			if (SetLocaleInfo(dwLCID, LOCALE_SSHORTDATE, "yyyy/MM/dd") == false) {
				Interaction.MsgBox("Failed");
				return;
			}
			PostMessage(HWND_BROADCAST, WM_SETTINGCHANGE, 0, 0);
		}

		public static void setApplicationFocus(ref string title)
		{
			int iret = 0;
			int lHandle = 0;

			lHandle = FindWindow(VariantType.Empty, title);
			if (lHandle == 0) {
			} else {
				iret = BringWindowToTop(lHandle);
			}

		}

		public static int SetValueEx(int hkey, ref string sValueName, ref int ltype, ref int vValue)
		{
			int functionReturnValue = 0;
			int lValue = 0;
			string sValue = null;
			switch (ltype) {
				case REG_SZ:
					sValue = vValue + Strings.Chr(0);
					functionReturnValue = RegSetValueExString(hkey, sValueName, 0, ltype, sValue, Strings.Len(sValue));
					break;
				case REG_DWORD:
					lValue = vValue;
					functionReturnValue = RegSetValueExLong(hkey, sValueName, 0, ltype, ref lValue, 4);
					break;
			}
			return functionReturnValue;
		}

		public static int QueryValueEx(int lhKey, string szValueName, ref object vValue)
		{
			int functionReturnValue = 0;
			int cch = 0;
			int lrc = 0;
			int ltype = 0;
			int lValue = 0;
			string sValue = null;
			RegistryKey rkey = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			// Determine the size and type of data to be read
			rkey = Registry.LocalMachine.OpenSubKey(szValueName, true);

			lrc = RegQueryValueExNULL(lhKey, szValueName, 0, ref ltype, 0, ref cch);
			if (lrc != ERROR_NONE)
				 // ERROR: Not supported in C#: ErrorStatement


			switch (ltype) {
				// For strings
				case REG_SZ:
					sValue = new string(Strings.Chr(0), cch);

					lrc = RegQueryValueExString(lhKey, szValueName, 0, ref ltype, sValue, ref cch);
					if (lrc == ERROR_NONE) {
						vValue = Strings.Left(sValue, cch - 1);
					} else {
						vValue = null;
					}
					break;
				// For DWORDS
				case REG_DWORD:
					lrc = RegQueryValueExLong(lhKey, szValueName, 0, ref ltype, ref lValue, ref cch);
					if (lrc == ERROR_NONE)
						vValue = lValue;
					break;
				default:
					//all other data types not supported
					lrc = -1;
					break;
			}
			QueryValueExExit:

			functionReturnValue = lrc;
			return functionReturnValue;
			QueryValueExError:

			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}
		public static void MyGotFocus(ref object lControl)
		{
			short x = 0;
			if (lControl.Alignment == 1) {
				for (x = 1; x <= 10; x++) {
					if (Strings.Left(lControl.Text, 1) == "0") {
						lControl.Text = Strings.Mid(lControl.Text, 2);
					}
					if (string.IsNullOrEmpty(lControl.Text))
						lControl.Text = "0";
				}
			}
			lControl.SelStart = 0;
			lControl.SelLength = Strings.Len(lControl.Text);

		}

		public static void MyGotFocusNumeric(ref object lControl)
		{
			short x = 0;
			lControl.Text = Strings.Replace(lControl.Text, ",", "");
			lControl.Text = Strings.Replace(lControl.Text, ".", "");
			if (lControl.Alignment == 1) {
				for (x = 1; x <= 10; x++) {
					if (Strings.Left(lControl.Text, 1) == "0") {
						lControl.Text = Strings.Mid(lControl.Text, 2);
					}
					if (string.IsNullOrEmpty(lControl.Text))
						lControl.Text = "0";
				}
			}
			lControl.SelStart = 0;
			lControl.SelLength = Strings.Len(lControl.Text);

		}

		public static void MyGotFocusNumericMEAT(ref object lControl)
		{
			short x = 0;
			lControl.Text = Strings.Replace(lControl.Text, ",", "");
			//lControl.Text = Replace(lControl.Text, ".", "")
			//If lControl.Alignment = 1 Then
			//    For x = 1 To 10
			//        If Left(lControl.Text, 1) = "0" Then
			//            lControl.Text = Mid(lControl.Text, 2)
			//        End If
			if (string.IsNullOrEmpty(lControl.Text))
				lControl.Text = "0";
			//    Next
			//End If
			lControl.SelStart = 0;
			lControl.SelLength = Strings.Len(lControl.Text);

		}

		public static void MyGotFocusNumericNew(ref object lControl)
		{
			short x = 0;
			lControl.Text = Strings.Replace(lControl.Text, ",", "");
			if (string.IsNullOrEmpty(lControl.Text))
				lControl.Text = "0";
			lControl.SelStart = 0;
			lControl.SelLength = Strings.Len(lControl.Text);

		}

		public static void MyKeyPress(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
				case 46:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					break;
				default:
					KeyAscii = 0;
					break;
			}
		}

		public static void MyKeyPressInt(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					break;
				default:
					KeyAscii = 0;
					break;
			}
		}

		public static void MyKeyPressNegative(ref object lControl, ref short KeyAscii)
		{
			object lCurrentX = null;
			switch (KeyAscii) {
				case 45:
					//-
					if (Strings.InStr(lControl.Text, "-")) {
					} else {
						lCurrentX = lControl.SelStart + 1;
						lControl.Text = "-" + lControl.Text;
						lControl.SelStart = lCurrentX;

					}
					KeyAscii = 0;
					break;
				case 43:
					//+
					if (Strings.InStr(lControl.Text, "-")) {
						lCurrentX = lControl.SelStart - 1;
						lControl.Text = Strings.Right(lControl.Text, Strings.Len(lControl.Text) - 1);
						if (lCurrentX < 0)
							lCurrentX = 0;
						lControl.SelStart = lCurrentX;

					}
					KeyAscii = 0;

					break;
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
				case 46:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					break;
				default:
					KeyAscii = 0;
					break;
			}
		}

		public static void MyLostFocus(ref TextBox lControl, ref decimal lDecimal)
		{
			if (string.IsNullOrEmpty(lControl.Text))
				lControl.Text = 0;

			if (lDecimal) {
				lControl.Text = lControl.Text / 100;
			}
			lControl.Text = Strings.FormatNumber(lControl.Text, lDecimal);
		}

		public static void MyLostFocusNew(ref TextBox lControl, ref decimal lDecimal)
		{
			if (string.IsNullOrEmpty(lControl.Text))
				lControl.Text = 0;
			lControl.Text = Strings.FormatNumber(lControl.Text, lDecimal);
		}

//Public Sub ageCustomer(id As Long)
//    Dim rs As Recordset
//    Dim lAmount As Currency, current As Currency, days30 As Currency, days60 As Currency, days90 As Currency, days120 As Currency, days150 As Currency
//
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));"
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));"
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));"
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));"
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));"
//    cnnDB.Execute "UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));"
//
//    Set rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransaction_ReferenceID) = " & id & "));")
//
//    Do While rs.EOF = False
//       amount = amount + rs("CustomerTransaction_Amount")
//       rs.MoveNext
//    Loop
//
//    If rs.RecordCount Then
//
//    'Do While rs.EOF = False
//
//        'amount = rs("CustomerTransaction_Amount")
//        rs.MoveFirst
//        current = rs("Customer_Current")
//        days30 = rs("Customer_30Days")
//        days60 = rs("Customer_60Days")
//        days90 = rs("Customer_90Days")
//        days120 = rs("Customer_120Days")
//        days150 = rs("Customer_150Days")
//        If amount < 0 Then
//            days150 = days150 + amount
//            If (days150 < 0) Then
//                amount = days150
//                days150 = 0
//            Else
//                amount = 0
//            End If
//            days120 = days120 + amount
//            If (days120 < 0) Then
//                amount = days120
//                days120 = 0
//            Else
//                amount = 0
//            End If
//            days90 = days90 + amount
//            If (days90 < 0) Then
//                amount = days90
//                days90 = 0
//            Else
//                amount = 0
//            End If
//            days60 = days60 + amount
//            If (days60 < 0) Then
//                amount = days60
//                days60 = 0
//            Else
//                amount = 0
//            End If
//            days30 = days30 + amount
//            If (days30 < 0) Then
//                amount = days30
//                days30 = 0
//            Else
//                amount = 0
//            End If
//        End If
//        current = current + amount
//        cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
//        'rs.MoveNext
//    'Loop
//    End If
//End Sub
	}
}
