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
namespace _4PosBackOffice.NET
{

	static class VarPtr
	{

		public static int VarPtr(object e)
		{
			GCHandle GC = GCHandle.Alloc(e, GCHandleType.Pinned);
			int GC2 = GC.AddrOfPinnedObject().ToInt32();
			GC.Free();
			return GC2;
		}
	}
}
namespace _4PosBackOffice.NET
{

	static class ObjPtr
	{
		public static int ObjPtr(object e)
		{
			GCHandle GC = GCHandle.Alloc(e, GCHandleType.Normal);
			int GC2 = GC.AddrOfPinnedObject().ToInt32();
		}
	}
}
