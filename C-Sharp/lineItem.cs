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
	internal class lineItem
	{
//local variable(s) to hold property value(s)

			//local copy
		private int mvarid;
			//local copy
		private int mvarIncrement;
			//local copy
		private string mvarname;
			//local copy
		private string mvarreceiptName;
			//local copy
		private string mvarcode;
			//local copy
		private string mvartransactionType;
			//local copy
		private bool mvarrevoke;
			//local copy
		private bool mvarpriceChanged;
			//local copy
		private bool mvardataType;
			//local copy
		private bool mvarreversal;
			//local copy
		private bool mvarvariablePrice;
			//local copy
		private bool mvarFractions;
			//local copy
		private short mvarsetBuild;
			//local copy
		private short mvarbuild;
			//local copy
		private short mvardepositType;
			//local copy
		private short mvarshrink;
			//local copy
		private short mvarlineNo;
			//local copy
		private decimal mvaroriginalPrice;
			//local copy
		private decimal mvarprice;
			//local copy
		private decimal mvarvat;
			//local copy
		private decimal mvarcashprice;
			//local copy
		private decimal mvarquantity;
//changed for airtime
			//local copy
		private bool mvarATitem;
			//local copy
		private string mvarspin;
			//local copy
		private string mvarsexpiry;
			//local copy
		private string mvarsserial;

		public bool fractions {
			get { return mvarFractions; }
			set { mvarFractions = value; }
		}


		public bool variablePrice {
			get { return mvarvariablePrice; }
			set { mvarvariablePrice = value; }
		}


		public short build {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.build
			get { return mvarbuild; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.build = 5
			set { mvarbuild = value; }
		}




		public short setBuild {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.set
			get { return mvarsetBuild; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.set = 5
			set { mvarsetBuild = value; }
		}





		public bool reversal {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.reversal
			get { return mvarreversal; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.reversal = 5
			set { mvarreversal = value; }
		}





		public bool revoke {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.revoke
			get { return mvarrevoke; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.revoke = 5
			set { mvarrevoke = value; }
		}





		public bool priceChanged {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.revoke
			get { return mvarpriceChanged; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.revoke = 5
			set { mvarpriceChanged = value; }
		}




		public decimal price {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.price
			get { return mvarprice; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.price = 5
			set { mvarprice = value; }
		}


		public decimal cashPrice {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.cashPrice
			get { return mvarcashprice; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.price = 5
			set { mvarcashprice = value; }
		}



		public decimal vat {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.vat
			get { return mvarvat; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.vat = 5
			set { mvarvat = value; }
		}





		public decimal originalPrice {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.originalPrice
			get { return mvaroriginalPrice; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.originalPrice = 5
			set { mvaroriginalPrice = value; }
		}





		public string transactionType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.transactionType
			get { return mvartransactionType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.transactionType = 5
			set { mvartransactionType = value; }
		}





		public short depositType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.depositType
			get { return mvardepositType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.depositType = 5
			set { mvardepositType = value; }
		}





		public string code {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.code
			get { return mvarcode; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.code = 5
			set { mvarcode = value; }
		}





		public decimal quantity {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.quantity
			get { return mvarquantity; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.quantity = 5
			set { mvarquantity = value; }
		}





		public short shrink {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.shrink
			get { return mvarshrink; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.shrink = 5
			set { mvarshrink = value; }
		}





		public int id {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.id
			get { return mvarid; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.id = 5
			set { mvarid = value; }
		}



		public int increment {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.id
			get { return mvarIncrement; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.id = 5
			set { mvarIncrement = value; }
		}





		public string receiptName {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.receiptName
			get { return mvarreceiptName; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.receiptName = 5
			set { mvarreceiptName = value; }
		}





		public string name {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarname; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarname = value; }
		}


		public short lineNo {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.lineNo
			get { return mvarlineNo; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.lineNo = 5
			set { mvarlineNo = value; }
		}


		public bool dataType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvardataType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvardataType = value; }
		}

//changed for airtime

		public bool atitem {
			get { return mvarATitem; }
			set { mvarATitem = value; }
		}


		public string sPin {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarspin; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarspin = value; }
		}


		public string sExpiry {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarsexpiry; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarsexpiry = value; }
		}


		public string sSerial {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarsserial; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarsserial = value; }
		}

		public lineitem clone()
		{
			lineItem lLineitem = new lineItem();
			lLineitem.build = mvarbuild;
			lLineitem.code = mvarcode;
			lLineitem.depositType = mvardepositType;
			lLineitem.id = mvarid;
			lLineitem.lineNo = mvarlineNo;
			lLineitem.name = mvarname;
			lLineitem.originalPrice = mvaroriginalPrice;
			lLineitem.price = mvarprice;
			lLineitem.quantity = mvarquantity;
			lLineitem.receiptName = mvarreceiptName;
			lLineitem.reversal = mvarreversal;
			lLineitem.revoke = mvarrevoke;
			lLineitem.setBuild = mvarsetBuild;
			lLineitem.shrink = mvarshrink;
			lLineitem.transactionType = mvartransactionType;
			lLineitem.vat = mvarvat;
			lLineitem.sPin = mvarspin;
			return lLineitem;
		}
	}
}
