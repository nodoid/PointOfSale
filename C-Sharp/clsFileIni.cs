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
namespace _4PosBackOffice.NET
{
	internal class clsFileIni
	{
		[DllImport("KERNEL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		#if Win16
//UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Win16 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
		private static extern int WritePrivateProfileString(string AppName, string KeyName, string keydefault, string FileName);
		[DllImport("KERNEL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetPrivateProfileString(string AppName, string KeyName, string keydefault, string ReturnString, int NumBytes, string FileName);
		[DllImport("kernel32", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		#elif
		private static extern int WritePrivateProfileString(string AppName, string KeyName, string keydefault, string FileName);
		[DllImport("kernel32", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetPrivateProfileString(string AppName, string KeyName, string keydefault, string ReturnString, int NumBytes, string FileName);
		#endif

		private string m_strFileINI;
		private string m_strSection;
		private string m_strKey;
		private string m_strDescription;

//Costant
		private const short BufSize = 255;



		public string FileINI {


			get { return m_strFileINI; }


			set { m_strFileINI = value; }
		}

		public string section {


			get { return m_strSection; }


			set { m_strSection = value; }
		}


		public string Key {


			get { return m_strKey; }


			set { m_strKey = value; }
		}


		public string Description {


			get { return m_strDescription; }


			set { m_strDescription = value; }
		}


		public void AddToINI()
		{
			int rc = 0;

			rc = WritePrivateProfileString(m_strSection, m_strKey, m_strDescription, m_strFileINI);

		}

		public string ReadFromINI()
		{
			int rc = 0;
			string RetStr = null;

			RetStr = Strings.Space(BufSize);
			rc = GetPrivateProfileString(m_strSection, m_strKey, "Not Found", RetStr, BufSize, m_strFileINI);

			RetStr = Strings.Left(RetStr, rc);
			if (RetStr == "Not Found") {
				m_strDescription = "Not Found";
			} else {
				m_strDescription = RetStr;
			}

			return m_strDescription;
		}
	}
}
