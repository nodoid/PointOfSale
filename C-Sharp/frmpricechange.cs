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
	internal partial class frmpricechange : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmpricechange = No Code   [Price Changes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmpricechange.Caption = rsLang("LanguageLayoutLnk_Description"): frmpricechange.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblInstruction = No Code   [This process will print you the.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblInstruction.Caption = rsLang("LanguageLayoutLnk_Description"): lblInstruction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1140;
			//Start Date|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1141;
			//End Date|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdShow = No Code          [Show]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdShow.Caption = rsLang("LanguageLayoutLnk_Description"): cmdShow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdCancel = No Code        [Cancel]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdCancel.Caption = rsLang("LanguageLayoutLnk_Description"): cmdCancel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmpricechange.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();

		}

		private void cmdenddate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.HForPriceC = 2;
			My.MyProject.Forms.frmcalendar.ShowDialog();

		}

		private void cmdShow_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			ADODB.Recordset rs2 = default(ADODB.Recordset);
			ADODB.Recordset rsB = default(ADODB.Recordset);
			ADODB.Recordset rsDcheck = default(ADODB.Recordset);
			decimal HMyPrice = default(decimal);
			string MyMarkup = null;
			decimal HMyPrice1 = default(decimal);
			double MyCounterF = 0;
			double MyCounterL = 0;
			string Delimiter = null;
			ADODB.Recordset rsk = default(ADODB.Recordset);
			rs = new ADODB.Recordset();
			rs1 = new ADODB.Recordset();
			rs2 = new ADODB.Recordset();
			rsB = new ADODB.Recordset();
			rsDcheck = new ADODB.Recordset();
			rsk = new ADODB.Recordset();
			Delimiter = " ";


			//create table name
			modApplication.Te_Names = "NewPricechanges";
			//In case the table was not dropped then drop it
			rs = modRecordSet.getRS(ref "DROP TABLE " + modApplication.Te_Names + "");
			modApplication.MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number";
			//create table NewPriceChanges
			modRecordSet.cnnDB.Execute("CREATE TABLE " + modApplication.Te_Names + " (" + modApplication.MyFTypess + ")");

			rs1 = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndEndID = DayEnd.DayEndID ORDER BY aStockItem1.StockItemID;");
			if (rs1.RecordCount) {
				while (!(rs1.EOF)) {
					rs2 = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndStartID = DayEnd.DayEndID WHERE (((aStockItem1.StockItemID)=" + rs1.Fields("DayEndStockItemLnk_StockItemID").Value + "));");
					if (rs2.RecordCount) {
						if (rs1.Fields("DayEndStockItemLnk_ListCost").Value != rs2.Fields("DayEndStockItemLnk_ListCost").Value) {
							MyMarkup = Convert.ToString(0);
							//MyMarkup = (rs2("DayEndStockItemLnk_ListCost") / rsB("CatalogueChannelLnk_Price") * 100)
							//MyMarkup = 100 - MyMarkup
							//insert into Newpricechanges
							modRecordSet.cnnDB.Execute("INSERT INTO " + modApplication.Te_Names + "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" + rs1.Fields("DayEndStockItemLnk_StockItemID").Value + ",'" + rs1.Fields("StockItem_Name").Value + "', " + rs1.Fields("DayEndStockItemLnk_ListCost").Value + ", " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + "," + rs1.Fields("DayEndStockItemLnk_ListCost").Value + "," + MyMarkup + ")");
							//delete duplicates
							//Set rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2("DayEndStockItemLnk_StockItemID") & " and NewPricechanges.OldPrice = " & rs2("DayEndStockItemLnk_ListCost") & " and NewPricechanges.NewPrice = " & rs2("DayEndStockItemLnk_ListCost") & ")")
						}
					}
					rs1.moveNext();
				}
			} else {
				Interaction.MsgBox("There was No Price Changes of Items between " + this.txtstartdate.Text + " And " + this.txtenddate.Text, MsgBoxStyle.Information, "4POS");
			}



			//validation for start date
			if (string.IsNullOrEmpty(this.txtstartdate.Text)) {
				Interaction.MsgBox("Please Select/enter the Start Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkCancel, "4POS");
				this.txtstartdate.Focus();
				return;
				//validation for end date
			} else if (string.IsNullOrEmpty(this.txtenddate.Text)) {
				Interaction.MsgBox("Please Select/enter the End Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkCancel, "4POS");
				this.txtenddate.Focus();
				return;
			}

			//create table name
			modApplication.Te_Names = "NewPricechanges";
			//In case the table was not dropped then drop it
			rs = modRecordSet.getRS(ref "DROP TABLE " + modApplication.Te_Names + "");
			modApplication.MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number";
			//create table NewPriceChanges
			modRecordSet.cnnDB.Execute("CREATE TABLE " + modApplication.Te_Names + " (" + modApplication.MyFTypess + ")");

			//selecting from the start date
			rs = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE Datevalue(DayEnd_Date)=#" + this.txtstartdate.Text + "#");
			//selecting from the end date
			rs1 = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE Datevalue(DayEnd_Date) = #" + this.txtenddate.Text + "#");

			this.cmdshow.Enabled = false;
			this.cmdcancel.Enabled = false;
			//assigning the start date and the end date to the below variables
			MyCounterF = rs.Fields("DayEndID").Value;
			MyCounterL = rs1.Fields("DayEndID").Value;

			//loop/round from the first date until the last date selected
			for (x = MyCounterF; x <= MyCounterL; x++) {
				rs2 = modRecordSet.getRS(ref "SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" + MyCounterF + "");
				rsB = modRecordSet.getRS(ref "SELECT * FROM CatalogueChannelLnk WHERE CatalogueChannelLnk_StockItemID=" + MyCounterF + "");
				rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID=" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + "");

				rs2.MoveFirst();
				//formating the price
				HMyPrice1 = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
				HMyPrice1 = Convert.ToDecimal(Strings.Format(HMyPrice1, "R# ,###.##"));
				//formating the price
				HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
				HMyPrice = Convert.ToDecimal(Strings.Format(HMyPrice, "R# ,###.##"));
				rs2.Fields("DayEndStockItemLnk_ListCost").Value = Strings.Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##");

				//looping through the price for a specific date,if the price differs then insert into newly created table
				while (!(rs2.EOF)) {
					if (rs2.Fields("DayEndStockItemLnk_ListCost").Value != HMyPrice) {
						HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
						HMyPrice = Convert.ToDecimal(Strings.Format(HMyPrice, "R# ,###.##"));
						MyMarkup = Convert.ToString(rs2.Fields("DayEndStockItemLnk_ListCost").Value / rsB.Fields("CatalogueChannelLnk_Price").Value * 100);
						MyMarkup = Convert.ToString(100 - Convert.ToDouble(MyMarkup));
						//insert into Newpricechanges
						rsk = modRecordSet.getRS(ref "INSERT INTO " + modApplication.Te_Names + "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + ",'" + rs.Fields("StockItem_Name").Value + "', " + HMyPrice1 + ", " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + "," + rsB.Fields("CatalogueChannelLnk_Price").Value + "," + MyMarkup + ")");
						//delete duplicates
						rsk = modRecordSet.getRS(ref "DELETE * FROM " + modApplication.Te_Names + " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + " and NewPricechanges.OldPrice = " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + " and NewPricechanges.NewPrice = " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + ")");
					}
					rs2.moveNext();
					rs2.Fields("DayEndStockItemLnk_ListCost").Value = Strings.Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##");
				}
				MyCounterF = MyCounterF + 1;
			}
			//for ends here

			rs = modRecordSet.getRS(ref "SELECT * FROM NewPriceChanges");
			//if there was a price change then display the report
			if (rs.RecordCount > 0) {
				modApplication.ForNewPChange = 2;
				modApplication.report_NewPriceChange();
				//if there was no price change then don't display the report instead display the below message
			} else if (rs.RecordCount < 1) {
				Interaction.MsgBox("There was No Price Changes of Items between " + this.txtstartdate.Text + " And " + this.txtenddate.Text, MsgBoxStyle.Information, "4POS");
				//if there was no price change then enable the show and cancel button
				this.cmdshow.Enabled = true;
				this.cmdcancel.Enabled = true;
			}

		}


		private void OLD_cmdShow_Click()
		{
			int x = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			ADODB.Recordset rs2 = default(ADODB.Recordset);
			ADODB.Recordset rsB = default(ADODB.Recordset);
			ADODB.Recordset rsDcheck = default(ADODB.Recordset);
			decimal HMyPrice = default(decimal);
			string MyMarkup = null;
			decimal HMyPrice1 = default(decimal);
			double MyCounterF = 0;
			double MyCounterL = 0;
			string Delimiter = null;
			ADODB.Recordset rsk = default(ADODB.Recordset);
			rs = new ADODB.Recordset();
			rs1 = new ADODB.Recordset();
			rs2 = new ADODB.Recordset();
			rsB = new ADODB.Recordset();
			rsDcheck = new ADODB.Recordset();
			rsk = new ADODB.Recordset();
			Delimiter = " ";
			//Set rs = getRS("SELECT * FROM DayEnd WHERE DayEnd_Date = " & Me.txtstartdate.Text & "")
			//validation for start date
			if (string.IsNullOrEmpty(this.txtstartdate.Text)) {
				Interaction.MsgBox("Please Select/enter the Start Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkCancel, "4POS");
				this.txtstartdate.Focus();
				return;
				//validation for end date
			} else if (string.IsNullOrEmpty(this.txtenddate.Text)) {
				Interaction.MsgBox("Please Select/enter the End Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkCancel, "4POS");
				this.txtenddate.Focus();
				return;
			}

			//create table name
			modApplication.Te_Names = "NewPricechanges";
			//In case the table was not dropped then drop it
			rs = modRecordSet.getRS(ref "DROP TABLE " + modApplication.Te_Names + "");

			//selecting from dayend
			rsDcheck = modRecordSet.getRS(ref "SELECT * FROM DayEnd");

			rsDcheck.MoveFirst();
			//looping through all the selected records
			while (!(rsDcheck.EOF)) {
				//rsDcheck("DayEnd_Date") = Trim(Mid(rsDcheck("DayEnd_Date"), Len(rsDcheck("DayEnd_Date")) - 2, InStr(1, rsDcheck("DayEnd_Date"), Delimiter, Len(rsDcheck("DayEnd_Date")) - 1)))
				//formarting the date and time to just date
				rsDcheck.Fields("DayEnd_Date").Value = Strings.Trim(Strings.Mid(rsDcheck.Fields("DayEnd_Date").Value, 1, Strings.InStr(1, rsDcheck.Fields("DayEnd_Date").Value, Delimiter, 1) - 1));

				//updating the date fields to only date not date and time
				rs = modRecordSet.getRS(ref "UPDATE DayEnd SET DayEnd_Date=#" + rsDcheck.Fields("DayEnd_Date").Value + "# WHERE DayEndID=" + rsDcheck.Fields("DayEndID").Value + "");
				rsDcheck.moveNext();
			}

			modApplication.MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number";

			//create table NewPriceChanges

			modRecordSet.cnnDB.Execute("CREATE TABLE " + modApplication.Te_Names + " (" + modApplication.MyFTypess + ")");
			//selecting from the start date

			rs = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE (DayEnd_Date=#" + this.txtstartdate.Text + "#)");
			//selecting from the end date
			rs1 = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE (DayEnd_Date = #" + this.txtenddate.Text + "#)");

			//MyDayendIDs = rs("DayEndID")

			//MyDayendIDs1 = rs1("DayEndID")
			this.cmdshow.Enabled = false;
			this.cmdcancel.Enabled = false;
			//assigning the start date and the end date to the below variables
			MyCounterF = rs.Fields("DayEndID").Value;
			MyCounterL = rs1.Fields("DayEndID").Value;

			//loop/round from the first date until the last date selected
			for (x = MyCounterF; x <= MyCounterL; x++) {

				rs2 = modRecordSet.getRS(ref "SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" + MyCounterF + "");
				rsB = modRecordSet.getRS(ref "SELECT * FROM CatalogueChannelLnk WHERE CatalogueChannelLnk_StockItemID=" + MyCounterF + "");
				rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID=" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + "");

				rs2.MoveFirst();
				//formating the price
				HMyPrice1 = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
				HMyPrice1 = Convert.ToDecimal(Strings.Format(HMyPrice1, "R# ,###.##"));
				//formating the price
				HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
				HMyPrice = Convert.ToDecimal(Strings.Format(HMyPrice, "R# ,###.##"));
				rs2.Fields("DayEndStockItemLnk_ListCost").Value = Strings.Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##");

				while (!(rs2.EOF)) {
					//looping through the price for a specific date,if the price differs then insert into newly created table
					if (rs2.Fields("DayEndStockItemLnk_ListCost").Value != HMyPrice) {

						//rsB("CatalogueChannelLnk_Price") = rsB("CatalogueChannelLnk_Price")

						HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value;
						HMyPrice = Convert.ToDecimal(Strings.Format(HMyPrice, "R# ,###.##"));

						MyMarkup = Convert.ToString(rs2.Fields("DayEndStockItemLnk_ListCost").Value / rsB.Fields("CatalogueChannelLnk_Price").Value * 100);
						MyMarkup = Convert.ToString(100 - Convert.ToDouble(MyMarkup));

						//Set rs = getRS("SELECT DayEndStockItemLnk_ListCost,StockItem_Name,CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (StockItem INNER JOIN DayEndStockItemLnk ON StockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE DayEndStockItemLnk_StockItemID=" & rs2("DayEndStockItemLnk_StockItemID") & ";")
						//modApplication.Report_PriceChanges
						//If rs2("DayEndStockItemLnk_ListCost") <> HMyPrice Then
						//insert into Newpricechanges
						rsk = modRecordSet.getRS(ref "INSERT INTO " + modApplication.Te_Names + "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + ",'" + rs.Fields("StockItem_Name").Value + "', " + HMyPrice1 + ", " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + "," + rsB.Fields("CatalogueChannelLnk_Price").Value + "," + MyMarkup + ")");

						//End If
						//delete if there is records with same old price and new price
						rsk = modRecordSet.getRS(ref "DELETE * FROM " + modApplication.Te_Names + " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" + rs2.Fields("DayEndStockItemLnk_StockItemID").Value + " and NewPricechanges.OldPrice = " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + " and NewPricechanges.NewPrice = " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + ")");

					}
					//rsB.moveNext

					rs2.moveNext();
					rs2.Fields("DayEndStockItemLnk_ListCost").Value = Strings.Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##");
				}

				//Set rs1 = getRS("SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" & MyDayendIDs1 & "")
				//Set rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & rs1("DayEndStockItemLnk_StockItemID") & "")
				//rs1.MoveFirst
				//Do Until rs1.EOF
				//If HMyPrice <> rs1("DayEndStockItemLnk_ListCost") Then
				//HMyPrice1 = rs1("DayEndStockItemLnk_ListCost")
				//Set rs = getRS("INSERT INTO NewPriceChanges(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice)VALUES(" & rs1("DayEndStockItemLnk_StockItemID") & ",'" & rs("StockItem_Name") & "', '" & HMyPrice1 & "', '" & rs1("DayEndStockItemLnk_ListCost") & "')")
				//End If
				//rs1.moveNext
				//Loop

				MyCounterF = MyCounterF + 1;
			}

			rs = modRecordSet.getRS(ref "SELECT * FROM NewPriceChanges");
			//if there was a price change then display the report
			if (rs.RecordCount > 0) {
				modApplication.ForNewPChange = 2;
				modApplication.report_NewPriceChange();
				//if there was no price change then don't display the report instead display the below message
			} else if (rs.RecordCount < 1) {
				Interaction.MsgBox("There was No Price Changes of Items between " + this.txtstartdate.Text + " And " + this.txtenddate.Text, MsgBoxStyle.Information, "4POS");
				//if there was no price change then enable the show and cancel button
				this.cmdshow.Enabled = true;
				this.cmdcancel.Enabled = true;

			}

		}

		private void cmdStart_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.HForPriceC = 1;
			My.MyProject.Forms.frmcalendar.ShowDialog();

		}

		private void frmpricechange_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				cmdShow_Click(cmdshow, new System.EventArgs());
			} else if (KeyAscii == 27) {
				cmdCancel_Click(cmdcancel, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmpricechange_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}
	}
}
