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
	static class GetIndex
	{
		public static object GetIndexer(ref object text1, ref IEnumerable<Control> text2)
		{
			int index = 0;
			Control m = new Control();
			index = 0;
			foreach (Control m_loopVariable in text2) {
				m = m_loopVariable;
				if (m.Name != text1.Name) {
					index = index + 1;
				} else {
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			return index;
		}
	}
}
