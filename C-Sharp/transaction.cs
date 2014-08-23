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
	internal class transaction
	{
//local variable(s) to hold property value(s)
			//local copy
		private string mvarcompanyName;
			//local copy
		private int mvarposID;
			//local copy
		private string mvarposName;
			//local copy
		private string mvartaxNumber;
			//local copy
		private string mvarheading1;
			//local copy
		private string mvarheading2;
			//local copy
		private string mvarheading3;
			//local copy
		private string mvarfooter;
			//local copy
		private string mvartransactionID;
			//local copy
		private string mvartransactionType;
			//local copy
		private System.DateTime mvartransactionDate;
			//local copy
		private short mvarchannelID;
			//local copy
		private int mvarcashierID;
			//local copy
		private string mvarcashierName;
			//local copy
		private int mvarmanagerID;
			//local copy
		private string mvarmanagerName;
			//local copy
		private string mvarpaymentType;
			//local copy
		private decimal mvarpaymentSubTotal;
			//local copy
		private decimal mvarpaymentDiscount;
//For Gratuity
			//local copy
		private decimal mvarpaymentGratuity;
//For DisChk
			//local copy
		private bool mvarDisChk;
			//local copy
		private decimal mvarpaymentTotal;
			//local copy
		private decimal mvarpaymentTender;
			//local copy
		private bool mvarpaymentSlip;
			//local copy
		private lineItems mvarlineitems = new lineItems();
			//local copy
		private customer mvarcustomer;

			//local copy
		private bool mvardeleted;
			//local copy
		private int[] mvardeposit;

//For Order Reference.....
			//local copy
		private string mvarCard;
			//local copy
		private string mvarSerial;
			//local copy
		private string mvarOrder;

//To Handle Split Tender...
			//local copy
		private decimal mvarSplitCash;
			//local copy
		private decimal mvarSplitDebit;
			//local copy
		private decimal mvarSplitCredit;
			//local copy
		private decimal mvarSplitCheque;

		private transactionSpecial mvartransactionSpecial;


		public bool creditDeposit(int vData)
		{
			bool functionReturnValue = false;
			int x = 0;
			functionReturnValue = false;
			for (x = 0; x <= Information.UBound(mvardeposit); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (mvardeposit[x] == vData) {
					return functionReturnValue;
				}
			}
			functionReturnValue = true;
			Array.Resize(ref mvardeposit, Information.UBound(mvardeposit) + 2);
			mvardeposit[Information.UBound(mvardeposit)] = vData;
			return functionReturnValue;
		}
		public void loadCurrent(ref string lPath = "")
		{
			int intLineNo = 0;
			int prTender = 0;
			int y = 0;
			string gPath = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			//UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			lineItem lineitem_Renamed = null;
			//UPGRADE_NOTE: customer was upgraded to customer_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			customer customer_Renamed = null;
			//UPGRADE_NOTE: transactionSpecial was upgraded to transactionSpecial_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			transactionSpecial transactionSpecial_Renamed = null;
			string lString = null;
			string[] dataArray = null;
			string[] lineArray = null;
			int x = 0;
			bool bool1 = false;
			//UPGRADE_NOTE: Object mvarcustomer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvarcustomer = null;
			//UPGRADE_NOTE: Object mvartransactionSpecial may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvartransactionSpecial = null;
			//UPGRADE_NOTE: Object mvarlineitems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvarlineitems = null;

			//On Local Error Resume Next
			 // ERROR: Not supported in C#: OnErrorStatement


			bool1 = false;

			//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(lPath))
				lPath = gPath + "current.tra";
			string[] lArray = null;
			if (fso.FileExists(lPath)) {
				textstream = fso.OpenTextFile(lPath, Scripting.IOMode.ForReading, true);
				lString = textstream.ReadAll;
				//UPGRADE_WARNING: Couldn't resolve default property of object dataArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dataArray = Strings.Split(lString, Strings.Chr(255));
				for (x = Information.LBound(dataArray); x <= Information.UBound(dataArray); x++) {

					//UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (!string.IsNullOrEmpty(dataArray[x])) {
						//UPGRADE_WARNING: Couldn't resolve default property of object dataArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object lineArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lineArray = Strings.Split(dataArray[x], Strings.Chr(254));
						switch (lineArray[0]) {
							case "tran":
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarchannelID = lineArray[3];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcashierID = lineArray[1];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcashierName = lineArray[2];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarchannelID = lineArray[3];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcompanyName = lineArray[4];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvardeleted = lineArray[5];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarfooter = lineArray[6];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading1 = lineArray[7];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading2 = lineArray[8];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading3 = lineArray[9];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarmanagerID = lineArray[10];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarmanagerName = lineArray[11];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentDiscount = lineArray[12];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentSlip = lineArray[13];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentSubTotal = lineArray[14];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentTender = lineArray[15];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentTotal = lineArray[16];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentType = lineArray[17];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarposID = lineArray[18];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarposName = lineArray[19];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartaxNumber = lineArray[20];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionDate = lineArray[21];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionID = lineArray[22];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionType = lineArray[23];

								//Additional Code
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarCard = lineArray[26];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSerial = lineArray[27];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarOrder = lineArray[28];

								//Additional Split
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCash = lineArray[29];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitDebit = lineArray[30];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCredit = lineArray[31];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCheque = lineArray[32];

								//For Gratuity
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentGratuity = lineArray[33];
								//For DisChk
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarDisChk = lineArray[34];

								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(35). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								if (Information.UBound(lineArray) > 34 & !string.IsNullOrEmpty(lineArray[35])) {
									//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									//UPGRADE_WARNING: Couldn't resolve default property of object lArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									lArray = Strings.Split(lineArray[35], "/");
									mvardeposit = new int[Information.UBound(lArray) + 1];

									for (y = 1; y <= Information.UBound(lArray); y++) {
										//UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
										//UPGRADE_WARNING: Couldn't resolve default property of object lArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
										mvardeposit[y] = lArray[y];
									}
								}
								break;

							case "spec":
								transactionSpecial_Renamed = new transactionSpecial();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.address = lineArray[1];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.mobile = lineArray[2];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.name = lineArray[3];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.quote = lineArray[4];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.saleID = lineArray[5];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.telephone = lineArray[6];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.transactionType = lineArray[7];
								mvartransactionSpecial = transactionSpecial_Renamed;
								break;

							case "cust":
								customer_Renamed = new customer();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.channelID = lineArray[1];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.creditLimit = lineArray[2];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.department = lineArray[3];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.fax = lineArray[4];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.Key = lineArray[5];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.name = lineArray[6];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.outstanding = lineArray[7];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.person = lineArray[8];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.physical = lineArray[9];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.postal = lineArray[10];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.signed_Renamed = lineArray[11];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.telephone = lineArray[12];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.terms = lineArray[13];

								if (Information.UBound(lineArray) == 14) {
									//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									customer_Renamed.tax = lineArray[14];
								} else {
									customer_Renamed.tax = "";
								}

								mvarcustomer = customer_Renamed;
								break;
							case "item":
								lineitem_Renamed = new lineItem();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.build = lineArray[1];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.code = lineArray[2];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.depositType = lineArray[3];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.id = lineArray[4];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.lineNo = lineArray[5];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.name = lineArray[6];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.originalPrice = lineArray[7];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.price = lineArray[8];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.quantity = lineArray[9];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.receiptName = lineArray[10];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.dataType = lineArray[11];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.reversal = lineArray[12];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.revoke = lineArray[13];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.setBuild = lineArray[14];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.shrink = lineArray[15];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.transactionType = lineArray[16];

								modRecordSet.intCur = modRecordSet.intCur + 1;
								//UPGRADE_WARNING: Couldn't resolve default property of object prTender. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								prTender = true;
								bool1 = true;

								//On Local Error Resume Next
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.vat = lineArray[17];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.increment = lineArray[18];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.cashPrice = lineArray[19];
								//changed for airtime
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.sPin = lineArray[20];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.sSerial = lineArray[21];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.sExpiry = lineArray[22];
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.atitem = lineArray[23];
								//changed for airtime
								mvarlineitems.Add(ref lineitem_Renamed);
								break;

						}
					}
				}
			}

			if (bool1 == true) {

				//UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				intLineNo = lineitem_Renamed.lineNo;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				intLineNo = 0;
			}


			return;
			Load_Err:
			Interaction.MsgBox(Err().Number + " : " + Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

		}
		public void flush(ref string lName = "")
		{
			string saveTraSvr = null;
			string gPath = null;
			int x = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			//UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			lineItem lineitem_Renamed = null;
			string lString = null;
			rebuildData();

			transactionSpecial ts = null;
			// moved from TAG 1

			lString = lString + "tran" + Strings.Chr(254);
			lString = lString + mvarcashierID + Strings.Chr(254);
			lString = lString + mvarcashierName + Strings.Chr(254);
			lString = lString + mvarchannelID + Strings.Chr(254);
			lString = lString + mvarcompanyName + Strings.Chr(254);
			lString = lString + mvardeleted + Strings.Chr(254);
			lString = lString + mvarfooter + Strings.Chr(254);
			lString = lString + mvarheading1 + Strings.Chr(254);
			lString = lString + mvarheading2 + Strings.Chr(254);
			lString = lString + mvarheading3 + Strings.Chr(254);
			lString = lString + mvarmanagerID + Strings.Chr(254);
			lString = lString + mvarmanagerName + Strings.Chr(254);
			lString = lString + mvarpaymentDiscount + Strings.Chr(254);
			lString = lString + mvarpaymentSlip + Strings.Chr(254);

			if (mvartransactionSpecial == null) {
				lString = lString + mvarpaymentSubTotal + Strings.Chr(254);
				lString = lString + mvarpaymentTender + Strings.Chr(254);
				lString = lString + mvarpaymentTotal + Strings.Chr(254);
			} else {
				//made changes for XFer Price
				if (mvartransactionSpecial.transactionType == "stocktransfer") {
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
				} else if (mvartransactionSpecial.transactionType == "Quote" | mvartransactionSpecial.transactionType == "Data") {
					lString = lString + mvarpaymentSubTotal + Strings.Chr(254);
					lString = lString + mvarpaymentTender + Strings.Chr(254);
					lString = lString + mvarpaymentTotal + Strings.Chr(254);
				} else if (mvartransactionSpecial.transactionType == "Consignment Complete") {
					lString = lString + mvarpaymentSubTotal + Strings.Chr(254);
					lString = lString + mvarpaymentTender + Strings.Chr(254);
					lString = lString + mvarpaymentTotal + Strings.Chr(254);
				} else {
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
				}
			}


			lString = lString + mvarpaymentType + Strings.Chr(254);
			lString = lString + mvarposID + Strings.Chr(254);
			lString = lString + mvarposName + Strings.Chr(254);
			lString = lString + mvartaxNumber + Strings.Chr(254);
			lString = lString + mvartransactionDate + Strings.Chr(254);

			//for voucher number id
			//If saveTraSvr = True And lName <> "" And lName <> "current.tra" Then
			if (Strings.Right(lName, 4) == ".tmp" & lName != "current.tra") {
				if (string.IsNullOrEmpty(mvartransactionID))
					mvartransactionID = Strings.Mid(lName, 1, Strings.InStr(lName, ".") - 1);
			}

			lString = lString + mvartransactionID + Strings.Chr(254);
			lString = lString + mvartransactionType + Strings.Chr(254);
			lString = lString + "0" + Strings.Chr(254);
			lString = lString + "0" + Strings.Chr(254);

			//Added Here
			lString = lString + mvarCard + Strings.Chr(254);
			lString = lString + mvarSerial + Strings.Chr(254);
			lString = lString + mvarOrder + Strings.Chr(254);

			//Split Tender
			lString = lString + mvarSplitCash + Strings.Chr(254);
			lString = lString + mvarSplitDebit + Strings.Chr(254);
			lString = lString + mvarSplitCredit + Strings.Chr(254);
			lString = lString + mvarSplitCheque + Strings.Chr(254);

			//For Gratuity
			lString = lString + mvarpaymentGratuity + Strings.Chr(254);
			//For DisChk
			lString = lString + mvarDisChk + Strings.Chr(254);

			for (x = 1; x <= Information.UBound(mvardeposit); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lString + "/" + mvardeposit[x];
			}

			lString = lString + Strings.Chr(255);
			if (mvarcustomer == null) {
			} else {
				lString = lString + "cust" + Strings.Chr(254);
				lString = lString + mvarcustomer.channelID + Strings.Chr(254);
				lString = lString + mvarcustomer.creditLimit + Strings.Chr(254);
				lString = lString + mvarcustomer.department + Strings.Chr(254);
				lString = lString + mvarcustomer.fax + Strings.Chr(254);
				lString = lString + mvarcustomer.Key + Strings.Chr(254);
				lString = lString + mvarcustomer.name + Strings.Chr(254);
				lString = lString + mvarcustomer.outstanding + Strings.Chr(254);
				lString = lString + mvarcustomer.person + Strings.Chr(254);
				lString = lString + mvarcustomer.physical + Strings.Chr(254);
				lString = lString + mvarcustomer.postal + Strings.Chr(254);
				lString = lString + mvarcustomer.signed_Renamed + Strings.Chr(254);
				lString = lString + mvarcustomer.telephone + Strings.Chr(254);
				lString = lString + mvarcustomer.terms + Strings.Chr(254);
				lString = lString + mvarcustomer.tax + Strings.Chr(255);
			}

			// TAG 1
			if (mvartransactionSpecial == null) {
			} else {
				lString = lString + "spec" + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.address + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.mobile + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.name + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.quote + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.saleID + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.telephone + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.transactionType + Strings.Chr(255);
			}
			foreach (lineItem lineitem_Renamed_loopVariable in mvarlineitems) {
				lineitem_Renamed = lineitem_Renamed_loopVariable;
				lString = lString + "item" + Strings.Chr(254) + lineitem_Renamed.build + Strings.Chr(254);
				lString = lString + lineitem_Renamed.code + Strings.Chr(254);
				lString = lString + lineitem_Renamed.depositType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.id + Strings.Chr(254);
				lString = lString + lineitem_Renamed.lineNo + Strings.Chr(254);
				lString = lString + lineitem_Renamed.name + Strings.Chr(254);

				if (mvartransactionSpecial == null) {
					lString = lString + lineitem_Renamed.originalPrice + Strings.Chr(254);
					lString = lString + lineitem_Renamed.price + Strings.Chr(254);
				} else {
					//made changes for XFer Price
					if (mvartransactionSpecial.transactionType == "stocktransfer") {
						lString = lString + 0 + Strings.Chr(254);
						lString = lString + 0 + Strings.Chr(254);
					} else {
						lString = lString + lineitem_Renamed.originalPrice + Strings.Chr(254);
						lString = lString + lineitem_Renamed.price + Strings.Chr(254);
					}
				}


				lString = lString + lineitem_Renamed.quantity + Strings.Chr(254);
				lString = lString + lineitem_Renamed.receiptName + Strings.Chr(254);
				lString = lString + lineitem_Renamed.dataType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.reversal + Strings.Chr(254);
				lString = lString + lineitem_Renamed.revoke + Strings.Chr(254);
				lString = lString + lineitem_Renamed.setBuild + Strings.Chr(254);
				lString = lString + lineitem_Renamed.shrink + Strings.Chr(254);
				lString = lString + lineitem_Renamed.transactionType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.vat + Strings.Chr(254);
				lString = lString + lineitem_Renamed.increment + Strings.Chr(254);
				lString = lString + lineitem_Renamed.cashPrice + Strings.Chr(254);
				//changed for airtime
				//lString = lString & lineitem.cashPrice & Chr(255)
				lString = lString + lineitem_Renamed.sPin + Strings.Chr(254);
				lString = lString + lineitem_Renamed.sSerial + Strings.Chr(254);
				lString = lString + lineitem_Renamed.sExpiry + Strings.Chr(254);
				lString = lString + lineitem_Renamed.atitem + Strings.Chr(255);
				//changed for airtime
			}
			if (string.IsNullOrEmpty(lName))
				lName = "current.tra";

			//UPGRADE_WARNING: Couldn't resolve default property of object saveTraSvr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (saveTraSvr == true & lName != "current.tra") {
				if (Strings.Left(Strings.LCase(lName), 9) == "complete\\") {
					//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (fso.FileExists(gPath + lName))
						fso.DeleteFile(gPath + lName, true);
					//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					textstream = fso.OpenTextFile(gPath + lName, Scripting.IOMode.ForWriting, true);
				} else {
					if (fso.FileExists(modRecordSet.serverPath + "data\\save\\" + lName))
						fso.DeleteFile(modRecordSet.serverPath + "data\\save\\" + lName, true);
					textstream = fso.OpenTextFile(modRecordSet.serverPath + "data\\save\\" + lName, Scripting.IOMode.ForWriting, true);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (fso.FileExists(gPath + lName))
					fso.DeleteFile(gPath + lName, true);
				//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				textstream = fso.OpenTextFile(gPath + lName, Scripting.IOMode.ForWriting, true);
			}


			textstream.Write(lString);
			textstream.Close();
		}


		public transactionSpecial transactionSpecial_Renamed {
//    If mvartransactionSpecial Is Nothing Then
//        Set mvartransactionSpecial = New transactionSpecial
//    End If
			get { return mvartransactionSpecial; }
				//flush
			set { mvartransactionSpecial = value; }
		}


		public customer customer_Renamed {
//    If mvarcustomer Is Nothing Then
//        Set mvarcustomer = New customer
//    End If
			get { return mvarcustomer; }
				//flush
			set { mvarcustomer = value; }
		}




		public lineItems lineItems {
			get {
				if (mvarlineitems == null) {
					mvarlineitems = new lineItems();
				}
				return mvarlineitems;
			}
			set { mvarlineitems = value; }
		}



		public bool paymentSlip {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentSlip
			get { return mvarpaymentSlip; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentSlip = 5
			set { mvarpaymentSlip = value; }
		}



		public bool deleted {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.deleted
			get { return mvardeleted; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.deleted = 5
			set { mvardeleted = value; }
		}




		public decimal paymentTender {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentTender
			get { return mvarpaymentTender; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentTender = 5
			set { mvarpaymentTender = value; }
		}





		public decimal paymentTotal {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentTotal
			get { return mvarpaymentTotal; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentTotal = 5
			set { mvarpaymentTotal = value; }
		}




		public bool DisChk {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentSlip
			get { return mvarDisChk; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentSlip = 5
			set { mvarDisChk = value; }
		}

//For Gratuity


		public decimal paymentGratuity {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentDiscount
			get { return mvarpaymentGratuity; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentDiscount = 5
			set { mvarpaymentGratuity = value; }
		}



		public decimal paymentDiscount {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentDiscount
			get { return mvarpaymentDiscount; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentDiscount = 5
			set { mvarpaymentDiscount = value; }
		}





		public decimal paymentSubTotal {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentSubTotal
			get { return mvarpaymentSubTotal; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentSubTotal = 5
			set { mvarpaymentSubTotal = value; }
		}



		public string paymentType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.paymentType
			get { return mvarpaymentType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.paymentType = 5
			set { mvarpaymentType = value; }
		}





		public string managerName {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.managerName
			get { return mvarmanagerName; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.managerName = 5
			set { mvarmanagerName = value; }
		}





		public int managerID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.managerID
			get { return mvarmanagerID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.managerID = 5
			set { mvarmanagerID = value; }
		}


		internal string cashierName {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.cashierName
			get { return mvarcashierName; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.cashierName = 5
			set { mvarcashierName = value; }
		}





		public int cashierID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.cashierID
			get { return mvarcashierID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.cashierID = 5
			set { mvarcashierID = value; }
		}





		internal short channelID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.channelID
			get { return mvarchannelID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.channelID = 5
			set { mvarchannelID = value; }
		}





		public System.DateTime transactionDate {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.transactionDate
			get { return mvartransactionDate; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.transactionDate = 5
			set { mvartransactionDate = value; }
		}





		internal string transactionType {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.transactionType
			get { return mvartransactionType; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.transactionType = 5
			set { mvartransactionType = value; }
		}





		internal string transactionID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.transactionID
			get { return mvartransactionID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.transactionID = 5
			set { mvartransactionID = value; }
		}



		public string footer {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.footer
			get { return mvarfooter; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.footer = 5
			set { mvarfooter = value; }
		}





		public string heading3 {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.heading3
			get { return mvarheading3; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.heading3 = 5
			set { mvarheading3 = value; }
		}




		public string heading2 {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.heading2
			get { return mvarheading2; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.heading2 = 5
			set { mvarheading2 = value; }
		}


		public string heading1 {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.heading1
			get { return mvarheading1; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.heading1 = 5
			set { mvarheading1 = value; }
		}


		public string taxNumber {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.taxNumber
			get { return mvartaxNumber; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.taxNumber = 5
			set { mvartaxNumber = value; }
		}



		public string posName {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.posName
			get { return mvarposName; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.posName = 5
			set { mvarposName = value; }
		}





		public int posID {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.posID
			get { return mvarposID; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.posID = 5
			set { mvarposID = value; }
		}
		public string companyName {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarcompanyName; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarcompanyName = value; }
		}


//New Class addition....

		public string OrderRefer {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarOrder; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarOrder = value; }
		}

		public string CardRefer {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarCard; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarCard = value; }
		}


		public string SerialRefer {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarSerial; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarSerial = value; }
		}
		public decimal TSplitCash {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarSplitCash; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarSplitCash = value; }
		}
		public decimal TSplitCheque {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarSplitCheque; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarSplitCheque = value; }
		}
		public decimal TSplitDebit {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarSplitDebit; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarSplitDebit = value; }
		}
		public decimal TSplitCredit {
//used when retrieving value of a property, on the right side of an assignment.
//Syntax: Debug.Print X.companyName
			get { return mvarSplitCredit; }
//used when assigning a value to the property, on the left side of an assignment.
//Syntax: X.companyName = 5
			set { mvarSplitCredit = value; }
		}
		public void resyncTransaction()
		{
			object gDeposits = null;
			object gStockItems = null;
			object stcBarcode = null;
			object lUnit = null;
			object lPack = null;
			decimal lPrice = default(decimal);
			short lQuantity = 0;
			//UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			lineItem lineitem_Renamed = null;

			foreach (lineItem lineitem_Renamed_loopVariable in mvarlineitems) {
				lineitem_Renamed = lineitem_Renamed_loopVariable;
				if (lineitem_Renamed.depositType == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object stcBarcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					stcBarcode = lineitem_Renamed.code;
					//UPGRADE_WARNING: Couldn't resolve default property of object gStockItems.getPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lPrice = gStockItems.getPrice(lineitem_Renamed.id, lineitem_Renamed.shrink);

					if (System.Math.Abs(lineitem_Renamed.price) == System.Math.Abs(lineitem_Renamed.originalPrice)) {
						if (lineitem_Renamed.reversal) {
							lineitem_Renamed.price = 0 - lPrice;
						} else {
							lineitem_Renamed.price = lPrice;
						}
						lineitem_Renamed.originalPrice = lineitem_Renamed.price;
					}
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gDeposits.getPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lPrice = gDeposits.getPrice(lineitem_Renamed.id, lineitem_Renamed.depositType);
					if (System.Math.Abs(lineitem_Renamed.price) == System.Math.Abs(lineitem_Renamed.originalPrice)) {
						if (lineitem_Renamed.reversal) {
							lineitem_Renamed.price = lPrice;
						} else {
							if (lineitem_Renamed.setBuild) {
							} else {
								lineitem_Renamed.price = 0 - lPrice;
							}
						}
						lineitem_Renamed.originalPrice = lineitem_Renamed.price;
					}
				}
			}
		}

		public void rebuildData()
		{
			object gChannel = null;
			object gManager = null;
			object gCashier = null;
			if (gCashier == null) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gCashier.id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarcashierID = gCashier.id;
				//UPGRADE_WARNING: Couldn't resolve default property of object gCashier.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarcashierName = gCashier.name;
			}
			if (gManager == null) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gManager.id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarmanagerID = gManager.id;
				//UPGRADE_WARNING: Couldn't resolve default property of object gManager.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarmanagerName = gManager.name;
			}
			if (gChannel == null) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gChannel.Key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarchannelID = gChannel.Key;
			}
		}
//UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Initialize_Renamed()
		{
			object gParameters = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (gParameters == null) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.companyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarcompanyName = gParameters.companyName;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.footer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarfooter = gParameters.footer;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarheading1 = gParameters.heading1;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarheading2 = gParameters.heading2;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarheading3 = gParameters.heading3;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.posID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarposID = gParameters.posID;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.posName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvarposName = gParameters.posName;
				//UPGRADE_WARNING: Couldn't resolve default property of object gParameters.taxNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvartaxNumber = gParameters.taxNumber;
				mvartransactionDate = DateAndTime.Now;
			}
			mvartransactionType = "Sale";
			mvarpaymentDiscount = 0;
			mvarpaymentSlip = false;
			mvardeleted = false;
			mvarpaymentSubTotal = 0;
			mvarpaymentTender = 0;
			mvarpaymentTotal = 0;
			mvarpaymentType = Convert.ToString(-1);
			mvardeposit = new int[1];
			rebuildData();

			return;
			ErrHandle:
			 // ERROR: Not supported in C#: ResumeStatement

		}
		public transaction() : base()
		{
			Class_Initialize_Renamed();
		}



		public void loadCurrentV(ref string lPath = "", ref decimal cTotal = 0)
		{
			object intLineNo = null;
			object prTender = null;
			object y = null;
			object gPath = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			//UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			lineItem lineitem_Renamed = null;
			//UPGRADE_NOTE: customer was upgraded to customer_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			customer customer_Renamed = null;
			//UPGRADE_NOTE: transactionSpecial was upgraded to transactionSpecial_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			transactionSpecial transactionSpecial_Renamed = null;
			string lString = null;
			object dataArray = null;
			object lineArray = null;
			int x = 0;
			bool bool1 = false;
			//UPGRADE_NOTE: Object mvarcustomer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvarcustomer = null;
			//UPGRADE_NOTE: Object mvartransactionSpecial may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvartransactionSpecial = null;
			//UPGRADE_NOTE: Object mvarlineitems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mvarlineitems = null;

			//On Local Error Resume Next
			 // ERROR: Not supported in C#: OnErrorStatement


			bool1 = false;

			//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(lPath))
				lPath = gPath + "current.tra";
			object lArray = null;
			if (fso.FileExists(lPath)) {
				textstream = fso.OpenTextFile(lPath, Scripting.IOMode.ForReading, true);
				lString = textstream.ReadAll;
				//UPGRADE_WARNING: Couldn't resolve default property of object dataArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dataArray = Strings.Split(lString, Strings.Chr(255));
				for (x = Information.LBound(dataArray); x <= Information.UBound(dataArray); x++) {

					//UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (!string.IsNullOrEmpty(dataArray(x))) {
						//UPGRADE_WARNING: Couldn't resolve default property of object dataArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object lineArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lineArray = Strings.Split(dataArray(x), Strings.Chr(254));
						switch (lineArray(0)) {
							case "tran":
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarchannelID = lineArray(3);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcashierID = lineArray(1);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcashierName = lineArray(2);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarchannelID = lineArray(3);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarcompanyName = lineArray(4);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvardeleted = lineArray(5);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarfooter = lineArray(6);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading1 = lineArray(7);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading2 = lineArray(8);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarheading3 = lineArray(9);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarmanagerID = lineArray(10);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarmanagerName = lineArray(11);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentDiscount = lineArray(12);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentSlip = lineArray(13);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentSubTotal = lineArray(14);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentTender = lineArray(15);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentTotal = lineArray(16);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentType = lineArray(17);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarposID = lineArray(18);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarposName = lineArray(19);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartaxNumber = lineArray(20);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionDate = lineArray(21);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionID = lineArray(22);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvartransactionType = lineArray(23);

								//Additional Code
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarCard = lineArray(26);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSerial = lineArray(27);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarOrder = lineArray(28);

								//Additional Split
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCash = lineArray(29);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitDebit = lineArray(30);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCredit = lineArray(31);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarSplitCheque = lineArray(32);

								//For Gratuity
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarpaymentGratuity = lineArray(33);
								//For DisChk
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								mvarDisChk = lineArray(34);

								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(35). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								if (Information.UBound(lineArray) > 34 & !string.IsNullOrEmpty(lineArray(35))) {
									//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									//UPGRADE_WARNING: Couldn't resolve default property of object lArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									lArray = Strings.Split(lineArray(35), "/");
									mvardeposit = new int[Information.UBound(lArray) + 1];

									for (y = 1; y <= Information.UBound(lArray); y++) {
										//UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
										//UPGRADE_WARNING: Couldn't resolve default property of object lArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
										mvardeposit[y] = lArray(y);
									}
								}
								break;

							case "spec":
								transactionSpecial_Renamed = new transactionSpecial();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.address = lineArray(1);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.mobile = lineArray(2);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.name = lineArray(3);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.quote = lineArray(4);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.saleID = lineArray(5);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.telephone = lineArray(6);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								transactionSpecial_Renamed.transactionType = lineArray(7);
								mvartransactionSpecial = transactionSpecial_Renamed;
								break;

							case "cust":
								customer_Renamed = new customer();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.channelID = lineArray(1);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.creditLimit = lineArray(2);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.department = lineArray(3);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.fax = lineArray(4);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.Key = lineArray(5);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.name = lineArray(6);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.outstanding = lineArray(7);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.person = lineArray(8);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.physical = lineArray(9);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.postal = lineArray(10);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.signed_Renamed = lineArray(11);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.telephone = lineArray(12);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.terms = lineArray(13);

								if (Information.UBound(lineArray) == 14) {
									//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									customer_Renamed.tax = lineArray(14);
								} else {
									customer_Renamed.tax = "";
								}

								mvarcustomer = customer_Renamed;
								break;
							case "item":
								lineitem_Renamed = new lineItem();
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.build = lineArray(1);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.code = lineArray(2);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.depositType = lineArray(3);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.id = lineArray(4);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.lineNo = lineArray(5);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.name = lineArray(6);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.originalPrice = lineArray(7);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.price = lineArray(8);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.quantity = lineArray(9);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.receiptName = lineArray(10);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.dataType = lineArray(11);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.reversal = lineArray(12);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.revoke = lineArray(13);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.setBuild = lineArray(14);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.shrink = lineArray(15);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.transactionType = lineArray(16);

								modRecordSet.intCur = modRecordSet.intCur + 1;
								//UPGRADE_WARNING: Couldn't resolve default property of object prTender. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								prTender = true;
								bool1 = true;

								//On Local Error Resume Next
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.vat = lineArray(17);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.increment = lineArray(18);
								//UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lineitem_Renamed.cashPrice = lineArray(19);
								mvarlineitems.Add(ref lineitem_Renamed);
								break;

						}
					}
				}
			}

			if (bool1 == true) {

				//UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				intLineNo = lineitem_Renamed.lineNo;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				intLineNo = 0;
			}


			return;
			Load_Err:
			Interaction.MsgBox(Err().Number + " : " + Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

		}

		public void flushV(ref string lName = "", ref decimal cTotal = 0)
		{
			object saveTraSvr = null;
			object gPath = null;
			object x = null;
			object postTransactionV = null;
			object gTransaction = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			//UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			lineItem lineitem_Renamed = null;
			string lString = null;
			rebuildData();

			transactionSpecial ts = null;
			// moved from TAG 1

			lString = lString + "tran" + Strings.Chr(254);
			lString = lString + mvarcashierID + Strings.Chr(254);
			lString = lString + mvarcashierName + Strings.Chr(254);
			lString = lString + mvarchannelID + Strings.Chr(254);
			lString = lString + mvarcompanyName + Strings.Chr(254);
			lString = lString + mvardeleted + Strings.Chr(254);
			lString = lString + mvarfooter + Strings.Chr(254);
			lString = lString + mvarheading1 + Strings.Chr(254);
			lString = lString + mvarheading2 + Strings.Chr(254);
			lString = lString + mvarheading3 + Strings.Chr(254);
			lString = lString + mvarmanagerID + Strings.Chr(254);
			lString = lString + mvarmanagerName + Strings.Chr(254);
			lString = lString + mvarpaymentDiscount + Strings.Chr(254);
			lString = lString + mvarpaymentSlip + Strings.Chr(254);

			//UPGRADE_WARNING: Couldn't resolve default property of object gTransaction.paymentTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gTransaction.paymentTotal = cTotal;

			if (mvartransactionSpecial == null) {
				lString = lString + cTotal + Strings.Chr(254);
				lString = lString + mvarpaymentTender + Strings.Chr(254);
				lString = lString + cTotal + Strings.Chr(254);
			} else {
				//made changes for XFer Price
				if (mvartransactionSpecial.transactionType == "stocktransfer") {
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
				} else if (mvartransactionSpecial.transactionType == "Quote" | mvartransactionSpecial.transactionType == "Data") {
					lString = lString + mvarpaymentSubTotal + Strings.Chr(254);
					lString = lString + mvarpaymentTender + Strings.Chr(254);
					lString = lString + mvarpaymentTotal + Strings.Chr(254);
				} else {
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
					lString = lString + 0 + Strings.Chr(254);
				}
			}


			lString = lString + 1 + Strings.Chr(254);
			lString = lString + mvarposID + Strings.Chr(254);
			lString = lString + mvarposName + Strings.Chr(254);
			lString = lString + mvartaxNumber + Strings.Chr(254);
			lString = lString + mvartransactionDate + Strings.Chr(254);

			//for voucher number id
			//If saveTraSvr = True And lName <> "" And lName <> "current.tra" Then
			//If Right(lName, 4) = ".tmp" And lName <> "current.tra" Then
			//    If mvartransactionID = "" Then mvartransactionID = Mid(lName, 1, InStr(lName, ".") - 1)
			//End If
			//UPGRADE_WARNING: Couldn't resolve default property of object postTransactionV. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvartransactionID = postTransactionV;
			//lID = mvartransactionID
			lString = lString + mvartransactionID + Strings.Chr(254);
			lString = lString + mvartransactionType + Strings.Chr(254);
			lString = lString + "0" + Strings.Chr(254);
			lString = lString + "0" + Strings.Chr(254);

			//Added Here
			lString = lString + mvarCard + Strings.Chr(254);
			lString = lString + mvarSerial + Strings.Chr(254);
			lString = lString + mvarOrder + Strings.Chr(254);
			//Split Tender
			lString = lString + mvarSplitCash + Strings.Chr(254);
			lString = lString + mvarSplitDebit + Strings.Chr(254);
			lString = lString + mvarSplitCredit + Strings.Chr(254);
			lString = lString + mvarSplitCheque + Strings.Chr(254);

			//For Gratuity
			lString = lString + mvarpaymentGratuity + Strings.Chr(254);
			//For DisChk
			lString = lString + mvarDisChk + Strings.Chr(254);

			for (x = 1; x <= Information.UBound(mvardeposit); x++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lString + "/" + mvardeposit[x];
			}

			lString = lString + Strings.Chr(255);
			if (mvarcustomer == null) {
			} else {
				lString = lString + "cust" + Strings.Chr(254);
				lString = lString + mvarcustomer.channelID + Strings.Chr(254);
				lString = lString + mvarcustomer.creditLimit + Strings.Chr(254);
				lString = lString + mvarcustomer.department + Strings.Chr(254);
				lString = lString + mvarcustomer.fax + Strings.Chr(254);
				lString = lString + mvarcustomer.Key + Strings.Chr(254);
				lString = lString + mvarcustomer.name + Strings.Chr(254);
				lString = lString + mvarcustomer.outstanding + Strings.Chr(254);
				lString = lString + mvarcustomer.person + Strings.Chr(254);
				lString = lString + mvarcustomer.physical + Strings.Chr(254);
				lString = lString + mvarcustomer.postal + Strings.Chr(254);
				lString = lString + mvarcustomer.signed_Renamed + Strings.Chr(254);
				lString = lString + mvarcustomer.telephone + Strings.Chr(254);
				lString = lString + mvarcustomer.terms + Strings.Chr(254);
				lString = lString + mvarcustomer.tax + Strings.Chr(255);
			}

			// TAG 1
			if (mvartransactionSpecial == null) {
			} else {
				lString = lString + "spec" + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.address + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.mobile + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.name + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.quote + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.saleID + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.telephone + Strings.Chr(254);
				lString = lString + mvartransactionSpecial.transactionType + Strings.Chr(255);
			}
			foreach (lineItem lineitem_Renamed_loopVariable in mvarlineitems) {
				lineitem_Renamed = lineitem_Renamed_loopVariable;
				lString = lString + "item" + Strings.Chr(254) + lineitem_Renamed.build + Strings.Chr(254);
				lString = lString + lineitem_Renamed.code + Strings.Chr(254);
				lString = lString + lineitem_Renamed.depositType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.id + Strings.Chr(254);
				lString = lString + lineitem_Renamed.lineNo + Strings.Chr(254);
				lString = lString + lineitem_Renamed.name + Strings.Chr(254);

				if (mvartransactionSpecial == null) {
					lString = lString + lineitem_Renamed.originalPrice + Strings.Chr(254);
					lString = lString + lineitem_Renamed.price + Strings.Chr(254);
				} else {
					//made changes for XFer Price
					if (mvartransactionSpecial.transactionType == "stocktransfer") {
						lString = lString + 0 + Strings.Chr(254);
						lString = lString + 0 + Strings.Chr(254);
					} else {
						lString = lString + lineitem_Renamed.originalPrice + Strings.Chr(254);
						lString = lString + lineitem_Renamed.price + Strings.Chr(254);
					}
				}


				lString = lString + lineitem_Renamed.quantity + Strings.Chr(254);
				lString = lString + lineitem_Renamed.receiptName + Strings.Chr(254);
				lString = lString + lineitem_Renamed.dataType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.reversal + Strings.Chr(254);
				lString = lString + lineitem_Renamed.revoke + Strings.Chr(254);
				lString = lString + lineitem_Renamed.setBuild + Strings.Chr(254);
				lString = lString + lineitem_Renamed.shrink + Strings.Chr(254);
				lString = lString + lineitem_Renamed.transactionType + Strings.Chr(254);
				lString = lString + lineitem_Renamed.vat + Strings.Chr(254);
				lString = lString + lineitem_Renamed.increment + Strings.Chr(254);
				lString = lString + lineitem_Renamed.cashPrice + Strings.Chr(255);
			}
			if (string.IsNullOrEmpty(lName))
				lName = "current.tra";

			//UPGRADE_WARNING: Couldn't resolve default property of object saveTraSvr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (saveTraSvr == true & lName != "current.tra") {
				if (fso.FileExists(lName))
					fso.DeleteFile(lName, true);
				textstream = fso.OpenTextFile(lName, Scripting.IOMode.ForWriting, true);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (fso.FileExists(lName))
					fso.DeleteFile(gPath + lName, true);
				textstream = fso.OpenTextFile(lName, Scripting.IOMode.ForWriting, true);
			}


			textstream.Write(lString);
			textstream.Close();
		}
	}
}
