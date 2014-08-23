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

	[ProvideProperty("Index", typeof(RectangleShape))]
	internal class RectangleShapeArray : BaseControlArray, IExtenderProvider
	{

		public event System.EventHandler Click;

		public RectangleShapeArray() : base()
		{
		}

		public RectangleShapeArray(IContainer Container) : base(Container)
		{
		}

		public bool CanExtend(object Target)
		{
			if (Target is RectangleShape) {
				return BaseCanExtend(Target);
			}
		}

		public short GetIndex(RectangleShape o)
		{
			return BaseGetIndex(o);
		}

		public void SetIndex(RectangleShape o, short Index)
		{
			BaseSetIndex(o, Index);
		}

		public bool ShouldSerializeIndex(RectangleShape o)
		{
			return BaseShouldSerializeIndex(o);
		}

		public void ResetIndex(RectangleShape o)
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

		public RectangleShape this[short Index] {
			get { return (RectangleShape)BaseGetItem(Index); }
		}

		protected override void HookUpControlEvents(object o)
		{

			RectangleShape ctl = null;
			ctl = (RectangleShape)o;

			if ((ClickEvent != null)) {
				ctl.Click += ClickEvent;
			}

		}

		protected override System.Type GetControlInstanceType()
		{
			return typeof(RectangleShape);
		}

	}
}
