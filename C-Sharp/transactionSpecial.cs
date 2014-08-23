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
	internal class transactionSpecial
	{
//local variable(s) to hold property value(s)
			//local copy
		private bool mvarquote;
			//local copy
		private string mvarname;
			//local copy
		private string mvartelephone;
			//local copy
		private string mvarmobile;
			//local copy
		private string mvaraddress;
			//local copy
		private int mvarsaleID;
			//local copy
		private string mvartransactionType;


		public string transactionType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.transactionType
			get { return mvartransactionType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.transactionType = 5
			set { mvartransactionType = value; }
		}



		public int saleID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.saleID
			get { return mvarsaleID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.saleID = 5
			set { mvarsaleID = value; }
		}





		public string address {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.address
			get { return mvaraddress; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.address = 5
			set { mvaraddress = value; }
		}





		public string mobile {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.mobile
			get { return mvarmobile; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.mobile = 5
			set { mvarmobile = value; }
		}





		public string telephone {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.telephone
			get { return mvartelephone; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.telephone = 5
			set { mvartelephone = value; }
		}





		public string name {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarname; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarname = value; }
		}




		public bool quote {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.quote
			get { return mvarquote; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.quote = 5
			set { mvarquote = value; }
		}
	}
}
