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
	static class GID
	{

		public static string GetItemDataString(ref object listObj, ref int posn)
		{
			return listObj(posn).ToString;
		}

		public static int GetItemData(ref object listObj, ref int posn)
		{
			return listObj(posn);
		}

		public static string GetItemString(ref object listObj, ref int posn)
		{
			return listObj(posn).ToString;
		}

	}
}
