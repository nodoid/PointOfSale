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
namespace _4PosBackOffice.NET
{
	static class modLenB
	{
		public static int LenB(string ObjStr)
		{
			if (Strings.Len(ObjStr) == 0)
				return 0;
			return System.Text.Encoding.Unicode.GetByteCount(ObjStr);
		}

		public static int LenB(object Obj)
		{
			if (Obj == null)
				return 0;
			try {
				return Strings.Len(Obj);
			} catch {
				try {
					return System.Runtime.InteropServices.Marshal.SizeOf(Obj);
				} catch {
					return -1;
				}
			}
		}
	}
}
