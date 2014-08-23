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
	internal class customer
	{
		public string Key;

//local variable(s) to hold property value(s)
			//local copy
		private string mvarname;
			//local copy
		private string mvardepartment;
			//local copy
		private string mvarperson;
			//local copy
		private string mvarphysical;
			//local copy
		private string mvarpostal;
			//local copy
		private string mvartelephone;
			//local copy
		private string mvarfax;
			//local copy
		private string mvartax;
			//local copy
		private string mvarsigned;
			//local copy
		private decimal mvarcreditLimit;
			//local copy
		private decimal mvaroutstanding;
			//local copy
		private int mvarchannelID;
			//local copy
		private short mvarterms;


		public short terms {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.terms
			get { return mvarterms; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.terms = 5
			set { mvarterms = value; }
		}




		public int channelID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.channelID
			get { return mvarchannelID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.channelID = 5
			set { mvarchannelID = value; }
		}





		public decimal outstanding {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.outstanding
			get { return mvaroutstanding; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.outstanding = 5
			set { mvaroutstanding = value; }
		}





		public decimal creditLimit {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.creditLimit
			get { return mvarcreditLimit; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.creditLimit = 5
			set { mvarcreditLimit = value; }
		}





//UPGRADE_NOTE: signed was upgraded to signed_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		public string signed_Renamed {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.signed
			get { return mvarsigned; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.signed = 5
			set { mvarsigned = value; }
		}





		public string fax {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.fax
			get { return mvarfax; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.fax = 5
			set { mvarfax = value; }
		}



		public string tax {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.fax
			get { return mvartax; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.fax = 5
			set { mvartax = value; }
		}





		public string telephone {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.telephone
			get { return mvartelephone; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.telephone = 5
			set { mvartelephone = value; }
		}





		public string postal {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.postal
			get { return mvarpostal; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.postal = 5
			set { mvarpostal = value; }
		}





		public string physical {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.physical
			get { return mvarphysical; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.physical = 5
			set { mvarphysical = value; }
		}





		public string person {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.person
			get { return mvarperson; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.person = 5
			set { mvarperson = value; }
		}





		public string department {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.department
			get { return mvardepartment; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.department = 5
			set { mvardepartment = value; }
		}





		public string name {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.name
			get { return mvarname; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.name = 5
			set { mvarname = value; }
		}
	}
}
