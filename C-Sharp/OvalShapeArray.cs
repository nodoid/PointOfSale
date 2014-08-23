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
using System.ComponentModel;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{

	[ProvideProperty("Index", typeof(OvalShape))]
	internal class OvalShapeArray : BaseControlArray, IExtenderProvider
	{

		public event System.EventHandler Click;

		public OvalShapeArray() : base()
		{
		}

		public OvalShapeArray(IContainer Container) : base(Container)
		{
		}

		public bool CanExtend(object Target)
		{
			if (Target is OvalShape) {
				return BaseCanExtend(Target);
			}
		}

		public short GetIndex(OvalShape o)
		{
			return BaseGetIndex(o);
		}

		public void SetIndex(OvalShape o, short Index)
		{
			BaseSetIndex(o, Index);
		}

		public bool ShouldSerializeIndex(OvalShape o)
		{
			return BaseShouldSerializeIndex(o);
		}

		public void ResetIndex(OvalShape o)
		{
			BaseResetIndex(o);
		}

		public new void Load(short Index)
		{
			base.Load(Index);
			((ShapeContainer)Item[0].Parent).Shapes.Add(Item[Index]);
		}

		public new void Unload(short Index)
		{
			((ShapeContainer)Item[0].Parent).Shapes.Remove(Item[Index]);
			base.Unload(Index);
		}

		public OvalShape this[short Index] {
			get { return (OvalShape)BaseGetItem(Index); }
		}

		protected override void HookUpControlEvents(object o)
		{

			OvalShape ctl = null;
			ctl = (OvalShape)o;

			if ((ClickEvent != null)) {
				ctl.Click += ClickEvent;
			}

		}

		protected override System.Type GetControlInstanceType()
		{
			return typeof(OvalShape);
		}

	}
}
