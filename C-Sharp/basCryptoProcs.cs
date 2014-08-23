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
	static class basCryptoProcs
	{

		public static bool g_blnCaseSensitiveUserID;
		public static bool g_blnCaseSensitivePWord;
		public static bool g_blnEnhancedProvider;
		public static short g_intHashType;

		public const string PGM_NAME = "4LIQ Serials";
		public const int MAX_PATH = 260;
		public const string APP_NAME = "PWDTest";
		public const string APP_SECTION = "Settings";
		public const string MYNAME = "4LIQ";

		public static string strCDKey;


		public static byte[] ConvertToArray(ref string strInput)
		{
			byte[] functionReturnValue = null;

			//UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			clsCryptoAPI cCrypto = null;
			cCrypto = new clsCryptoAPI();

			//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.StringToByteArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			functionReturnValue = cCrypto.StringToByteArray(strInput);
			//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = null;
			return functionReturnValue;

		}

		public static bool Correct_Password_Length(ref byte[] arPWord)
		{
			bool functionReturnValue = false;

			short intLength = 0;
			string strPWord = null;
			//UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			clsCryptoAPI cCrypto = null;

			cCrypto = new clsCryptoAPI();
			//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strPWord = cCrypto.ByteArrayToString(arPWord);
			intLength = Strings.Len(strPWord);
			//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = null;

			if (intLength == 0) {
				Interaction.MsgBox("A Password / Passphrase must be entered.", MsgBoxStyle.Information | MsgBoxStyle.OkOnly, "Password / Passphrase missing");
				functionReturnValue = false;
				//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				cCrypto = null;
				return functionReturnValue;
			}

			if (intLength < 8) {
				// If not a valid length
				Interaction.MsgBox("Password / Passphrase must be a minimum length of eight(8) characters.", MsgBoxStyle.Information | MsgBoxStyle.OkOnly, "Invalid Password / Passphrase length");
				functionReturnValue = false;
				//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				cCrypto = null;
				return functionReturnValue;
			}


			functionReturnValue = true;
			//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = null;
			return functionReturnValue;

		}

		public static object CurrentSettings_Get(ref string strKey)
		{


			return Interaction.GetSetting(APP_NAME, APP_SECTION, strKey);

		}

		public static string CurrentSettings_Save(ref string strKey, ref object varValue)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Interaction.SaveSetting(APP_NAME, APP_SECTION, strKey, varValue);

		}

		public static void Initial_settings()
		{

			object varValue = null;

			// ---------------------------------------------------------------------------
			// Case sensitive User ID setting (Default = True)
			// ---------------------------------------------------------------------------
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			varValue = CurrentSettings_Get(ref "UserID");

			// if nothing of file, write default to the registry
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Len(Strings.Trim(varValue)) == 0) {
				g_blnCaseSensitiveUserID = true;
				CurrentSettings_Save(ref "UserID", ref g_blnCaseSensitiveUserID);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				g_blnCaseSensitiveUserID = Convert.ToBoolean(varValue);
			}

			// ---------------------------------------------------------------------------
			// Case sensitive Password / Passphrase setting (Default = True)
			// ---------------------------------------------------------------------------
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			varValue = CurrentSettings_Get(ref "Password");

			// if nothing of file, write default to the registry
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Len(Strings.Trim(varValue)) == 0) {
				g_blnCaseSensitivePWord = true;
				CurrentSettings_Save(ref "Password", ref g_blnCaseSensitivePWord);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				g_blnCaseSensitivePWord = Convert.ToBoolean(varValue);
			}

			// ---------------------------------------------------------------------------
			// Whether or not to use the Enhanced Provider
			// ---------------------------------------------------------------------------
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			varValue = CurrentSettings_Get(ref "EnhancedProvider");

			// if nothing of file, write default to the registry
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Len(Strings.Trim(varValue)) == 0) {
				g_blnEnhancedProvider = false;
				CurrentSettings_Save(ref "EnhancedProvider", ref g_blnEnhancedProvider);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				g_blnEnhancedProvider = Convert.ToBoolean(varValue);
			}

			// ---------------------------------------------------------------------------
			// Hash method (Default = MD5)
			// ---------------------------------------------------------------------------
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSettings_Get(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			varValue = CurrentSettings_Get(ref "HashMethod");

			// if nothing of file, write default to the registry
			//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Len(Strings.Trim(varValue)) == 0) {
				g_intHashType = 2;
				CurrentSettings_Save(ref "HashMethod", ref g_intHashType);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object varValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				g_intHashType = Convert.ToInt16(varValue);
			}

		}

		public static bool Same_As_Previous(ref byte[] arByte1, ref byte[] arByte2)
		{
			bool functionReturnValue = false;

			string strTmp1 = null;
			string strTmp2 = null;
			//UPGRADE_ISSUE: clsCryptoAPI object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			clsCryptoAPI cCrypto = null;
			cCrypto = new clsCryptoAPI();

			// ---------------------------------------------------------------------------
			// Convert byte arrays to string data
			// ---------------------------------------------------------------------------
			//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strTmp1 = cCrypto.ByteArrayToString(arByte1);
			//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strTmp2 = cCrypto.ByteArrayToString(arByte2);

			// ---------------------------------------------------------------------------
			// Make the comparisons to see if these two arrays are the same
			// ---------------------------------------------------------------------------
			if (Strings.StrComp(strTmp1, strTmp2, CompareMethod.Binary) == 0) {
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}

			// ---------------------------------------------------------------------------
			// Empty data strings
			// ---------------------------------------------------------------------------
			strTmp1 = new string(Strings.Chr(0), 250);
			strTmp2 = new string(Strings.Chr(0), 250);
			//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cCrypto = null;
			return functionReturnValue;

		}
	}
}
