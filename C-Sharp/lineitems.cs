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
namespace _4PosBackOffice.NET
{
	internal class lineItems : System.Collections.IEnumerable
	{
//local variable to hold collection
		private Collection mCol;
		private lineItem mvarlineItem;




		public lineItem lineitem {
			get { return mvarlineItem; }
			set { mvarlineItem = value; }
		}
		public lineItem this[object vntIndexKey] {
			get {
				lineItem functionReturnValue = null;
				 // ERROR: Not supported in C#: OnErrorStatement

				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				functionReturnValue = mCol[vntIndexKey];
				return functionReturnValue;
				erItem:

				 // ERROR: Not supported in C#: ResumeStatement

				return functionReturnValue;
			}
		}
		public int Count {
//used when retrieving the number of elements in the
//collection. Syntax: Debug.Print x.Count
			get { return mCol.Count(); }
		}
//UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3FC1610-34F3-43F5-86B7-16C984F0E88E"'
//Public ReadOnly Property NewEnum() As stdole.IUnknown
		//Get
		//this property allows you to enumerate
		//this collection with the For...Each syntax
		//NewEnum = mCol._NewEnum
		//End Get
//End Property

		public System.Collections.IEnumerator GetEnumerator()
		{
			//UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="95F9AAD0-1319-4921-95F0-B9D3C4FF7F1C"'
			//GetEnumerator = mCol.GetEnumerator
		}
		public void reorder()
		{
			object x = null;
			Collection lCol = new Collection();
			for (x = 1; x <= mCol.Count(); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mCol[x].lineNo = x;
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCol.Add(mCol[x], "k" + mCol[x].lineNo);
			}

			mCol = lCol;
		}

		public void Add(ref lineItem lineitem)
		{
			object intLineNo = null;
			Collection lCol = new Collection();
			lineItem lLineitem = null;
			short x = 0;
			if (mCol.Count()) {
				lLineitem = mCol[mCol.Count()];
				if (lLineitem.quantity == 0)
					mCol.Remove(lLineitem.lineNo);
			}
			if (mCol.Count()) {
				lLineitem = mCol[mCol.Count()];
				//If lLineitem.sPin <> "" Then
				if (lLineitem.atitem == true) {
				} else {
					if (lLineitem.id == lineitem.id) {
						if (lLineitem.transactionType == lineitem.transactionType) {
							if (System.Math.Abs(lLineitem.price) == System.Math.Abs(lineitem.price)) {
								if (lLineitem.reversal == lineitem.reversal) {
									if (lLineitem.revoke == lineitem.revoke) {
										if (lLineitem.shrink == lineitem.shrink) {
											if (Strings.InStr(Convert.ToString(lLineitem.quantity), ".")) {
											} else {
												lLineitem.quantity = lLineitem.quantity + lineitem.quantity;
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}

			for (x = 1; x <= mCol.Count(); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mCol[x].lineNo = x;
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCol.Add(mCol[x], "k" + mCol[x].lineNo);
			}

			lineitem.lineNo = lCol.Count() + 1;
			//UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			intLineNo = lineitem.lineNo;


			lCol.Add(lineitem, "k" + lineitem.lineNo);
			mCol = lCol;

		}
		public void Remove(ref object vntIndexKey)
		{
			object x = null;
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)
			Collection lCol = new Collection();

			//UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mCol.Remove("k" + vntIndexKey);
			for (x = 1; x <= mCol.Count(); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mCol[x].lineNo = x;
				//UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCol.Add(mCol[x], "k" + mCol[x].lineNo);
			}
			mCol = lCol;

		}
//UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Initialize_Renamed()
		{
			//creates the collection when this class is created
			mCol = new Collection();
			//create the mlineItem object when the items class is created
			mvarlineItem = new lineItem();
		}
		public lineItems() : base()
		{
			Class_Initialize_Renamed();
		}
//UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Terminate_Renamed()
		{
			//UPGRADE_NOTE: Object mvarlineItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvarlineItem = null;
			//destroys collection when this class is terminated
			//UPGRADE_NOTE: Object mCol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mCol = null;
		}
		protected override void Finalize()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}
	}
}
