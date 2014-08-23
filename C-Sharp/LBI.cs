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
	public class LBI
	{
		private string mString;

		private object mT;
		public LBI(string inString, object inT)
		{
			mString = inString;
			mT = inT;
		}

		public override string ToString()
		{
			return mString + ", " + mT;
		}

	}
}
