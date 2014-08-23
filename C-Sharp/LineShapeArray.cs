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

	[ProvideProperty("Index", typeof(LineShape))]
	internal class LineShapeArray : BaseControlArray, IExtenderProvider
	{

		public event System.EventHandler Click;

		public LineShapeArray() : base()
		{
		}

		public LineShapeArray(IContainer Container) : base(Container)
		{
		}

		public bool CanExtend(object Target)
		{
			if (Target is LineShape) {
				return BaseCanExtend(Target);
			}
		}

		public short GetIndex(LineShape o)
		{
			return BaseGetIndex(o);
		}

		public void SetIndex(LineShape o, short Index)
		{
			BaseSetIndex(o, Index);
		}

		public bool ShouldSerializeIndex(LineShape o)
		{
			return BaseShouldSerializeIndex(o);
		}

		public void ResetIndex(LineShape o)
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

		public LineShape this[short Index] {
			get { return (LineShape)BaseGetItem(Index); }
		}


		protected override void HookUpControlEvents(object o)
		{
			LineShape ctl = null;
			ctl = (LineShape)o;

			if ((ClickEvent != null)) {
				ctl.Click += ClickEvent;
			}

		}

		protected override System.Type GetControlInstanceType()
		{
			return typeof(LineShape);
		}

	}
}
