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
	internal class customers : System.Collections.IEnumerable
	{
//local variable to hold collection
		private Collection mCol = new Collection();
		ADODB.Recordset gRS = new ADODB.Recordset();
		public customer getCustomer(ref int id)
		{
			string sql = null;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = default(ADODB.Recordset);
			customer customer_Renamed = null;
			if (id) {

				cn = modRecordSet.openConnectionInstance();
				if (cn == null) {
					Interaction.MsgBox("You are not connected to the 4POS BackOffice server! This task can only be performed if you are connected to the server. Please contact your System Administrator.", MsgBoxStyle.Exclamation, "BackOffice Connection Error");
				} else {
					rs = new ADODB.Recordset();
					sql = "SELECT Customer.*, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS balance From Customer WHERE CustomerID=" + id;
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					if (rs.RecordCount) {
						customer_Renamed = new customer();
						customer_Renamed.Key = rs.Fields("CustomerID").Value;
						customer_Renamed.channelID = rs.Fields("Customer_ChannelID").Value;
						customer_Renamed.creditLimit = rs.Fields("Customer_CreditLimit").Value;
						customer_Renamed.department = rs.Fields("Customer_DepartmentName").Value + "";
						customer_Renamed.fax = rs.Fields("Customer_Fax").Value + "";
						customer_Renamed.name = rs.Fields("Customer_InvoiceName").Value + "";
						customer_Renamed.outstanding = rs.Fields("balance").Value;
						customer_Renamed.person = rs.Fields("Customer_FirstName").Value + " " + rs.Fields("Customer_Surname").Value;
						customer_Renamed.physical = rs.Fields("Customer_PhysicalAddress").Value + "";
						customer_Renamed.postal = rs.Fields("Customer_PostalAddress").Value + "";
						customer_Renamed.signed_Renamed = customer_Renamed.person;
						customer_Renamed.telephone = rs.Fields("Customer_Telephone").Value + "";
						customer_Renamed.terms = rs.Fields("Customer_Terms").Value;
						customer_Renamed.tax = rs.Fields("Customer_VATNumber").Value + "";
					}
				}
			}
			return customer_Renamed;
		}
		public Collection search(ref string searchString)
		{
			string lString = null;
			customer customer_Renamed = null;
			short lExit = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			mCol = new Collection();
			lString = Strings.Trim(searchString);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			if (!string.IsNullOrEmpty(lString)) {
				lString = Strings.Replace(lString, "'", "''");
				lString = "(Customer_InvoiceName LIKE '%" + Strings.Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") + "%')";
			} else {
				lString = "";
			}
			gRS.filter = lString;

			if (gRS.RecordCount <= 0) {
				lString = Strings.Trim(searchString);
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				if (!string.IsNullOrEmpty(lString)) {
					lString = Strings.Replace(lString, "'", "''");
					lString = "(Customer_Surname LIKE '%" + Strings.Replace(lString, " ", "%' AND Customer_Surname LIKE '%") + "%')";
				} else {
					lString = "";
				}
				gRS.filter = lString;
			}

			while (!(gRS.EOF)) {
				customer_Renamed = new customer();
				customer_Renamed.Key = gRS.Fields("CustomerID").Value;
				customer_Renamed.channelID = gRS.Fields("Customer_ChannelID").Value;
				customer_Renamed.creditLimit = gRS.Fields("Customer_CreditLimit").Value;
				customer_Renamed.department = gRS.Fields("Customer_DepartmentName").Value + "";
				customer_Renamed.fax = gRS.Fields("Customer_Fax").Value + "";
				customer_Renamed.name = gRS.Fields("Customer_InvoiceName").Value;
				customer_Renamed.outstanding = gRS.Fields("balance").Value;
				customer_Renamed.person = gRS.Fields("Customer_FirstName").Value + " " + gRS.Fields("Customer_Surname").Value;
				customer_Renamed.physical = gRS.Fields("Customer_PhysicalAddress").Value + "";
				customer_Renamed.postal = gRS.Fields("Customer_PostalAddress").Value + "";
				customer_Renamed.signed_Renamed = customer_Renamed.person;
				customer_Renamed.telephone = gRS.Fields("Customer_Telephone").Value + "";
				customer_Renamed.terms = gRS.Fields("Customer_Terms").Value;
				customer_Renamed.tax = gRS.Fields("Customer_VATNumber").Value + "";
				mCol.Add(customer_Renamed, "k" + customer_Renamed.Key);
				lExit = lExit + 1;
				if (lExit == 50)
					break; // TODO: might not be correct. Was : Exit Do
				gRS.moveNext();

			}
			return mCol;
		}

		public customer this[int vntIndexKey] {
			get {
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				 // ERROR: Not supported in C#: OnErrorStatement

				//UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				return mCol["k" + vntIndexKey];
			}
		}



		public int Count {
			get {
				 // ERROR: Not supported in C#: OnErrorStatement

				//used when retrieving the number of elements in the
				//collection. Syntax: Debug.Print x.Count
				return gRS.RecordCount;
			}
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


		public void Remove(ref int vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)


			mCol.Remove(vntIndexKey);
		}

		public void load()
		{
			string sql = null;
			ADODB.Connection cn = default(ADODB.Connection);
			if (gRS.State)
				gRS.Close();
			gRS.filter = "";
			cn = modRecordSet.openConnectionInstance();
			if (cn == null) {
				Interaction.MsgBox("You are not connected to the 4POS BackOffice server! This task can only be performed if you are connected to the server. Please contact your System Administrator.", MsgBoxStyle.Exclamation, "BackOffice Connection Error");
			} else {
				sql = "SELECT Customer.*, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS balance From Customer WHERE Customer_Disabled <> True ORDER BY Customer.Customer_InvoiceName;";

				gRS.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			}
		}



//UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Terminate_Renamed()
		{
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
