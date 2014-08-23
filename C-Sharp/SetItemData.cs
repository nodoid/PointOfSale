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
	public class SetItemData
	{
		private int iPosition;

		private object oValue;
		public SetItemData(int position, object value)
		{
			iPosition = position;
			oValue = value;
		}

		public override string ToString()
		{
			return iPosition + ", " + oValue;
		}
	}
}
