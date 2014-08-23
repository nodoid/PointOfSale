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
	internal partial class frmPOSreport : System.Windows.Forms.Form
	{

		private void loadLanguage()
		{

			//Note: Form Caption has a spelling mistake!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2347;
			//Sale Transaction List|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2348;
			//Persons|Checked
			if (modRecordSet.rsLang.RecordCount){_Label1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1(1) = No Code    [Sale Channels]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code    [POS Devices]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2351;
			//Transaction Reference|Checked
			if (modRecordSet.rsLang.RecordCount){_Label1_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label1_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2352;
			//Only Show Transaction with revoked Lines|Checked
			if (modRecordSet.rsLang.RecordCount){chkRevoke.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkRevoke.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2353;
			//Only show transaction with one or more Reversals
			if (modRecordSet.rsLang.RecordCount){chkReversal.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkReversal.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2354;
			//Do not show Consignments|Checked
			if (modRecordSet.rsLang.RecordCount){chkNoCon.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkNoCon.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2355;
			//Only show transaction with foreign Currencies|Checked
			if (modRecordSet.rsLang.RecordCount){chkFC.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkFC.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2356;
			//Only show Summary|Checked
			if (modRecordSet.rsLang.RecordCount){chkSum.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkSum.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2357;
			//Only Show Outstanding Consignments|Checked
			if (modRecordSet.rsLang.RecordCount){chkOutCon.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkOutCon.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1181;
			//Show/Print Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPOSreport.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private string getSQL()
		{
			string sql = null;
			bool gl = false;
			string lWhere = null;
			short x = 0;
			string lString = null;

			//If 1 = 1 Then lWhere = lWhere & " AND (Sale.Sale_SaleChk=False)"
			if (chkOutCon.CheckState)
				lWhere = lWhere + " AND (Consignment_CompleteSaleID Is Null)";
			if (chkNoCon.CheckState)
				lWhere = lWhere + " AND (ConsignmentID Is Null)";

			if (chkRevoke.CheckState)
				lWhere = lWhere + " AND (SaleItem_Revoke=True)";
			if (chkReversal.CheckState)
				lWhere = lWhere + " AND (SaleItem_Reversal=True)";
			if (chkFC.CheckState)
				lWhere = lWhere + " AND (Sale_PaymentType=8)";

			lString = "";
			for (x = 0; x <= this.lstChannel.Items.Count - 1; x++) {
				if (this.lstChannel.GetItemChecked(x)) {
					lString = lString + " OR Sale_ChannelID=" + GID.GetItemData(ref lstChannel, ref x);
				}
			}
			if (!string.IsNullOrEmpty(lString)) {
				lString = " AND (" + Strings.Mid(lString, 4) + ")";
				lWhere = lWhere + lString;
			}

			lString = "";
			for (x = 0; x <= this.lstPerson.Items.Count - 1; x++) {
				if (this.lstPerson.GetItemChecked(x)) {
					lString = lString + " OR Sale_PersonID=" + GID.GetItemData(ref lstPerson, ref x);
				}
			}
			if (!string.IsNullOrEmpty(lString)) {
				lString = " AND (" + Strings.Mid(lString, 4) + ")";
				lWhere = lWhere + lString;
			}

			lString = "";
			for (x = 0; x <= this.lstPOS.Items.Count - 1; x++) {
				if (this.lstPOS.GetItemChecked(x)) {
					lString = lString + " OR Sale_POSID=" + GID.GetItemData(ref lstPOS, ref x);
				}
			}
			if (!string.IsNullOrEmpty(lString)) {
				lString = " AND (" + Strings.Mid(lString, 4) + ")";
				lWhere = lWhere + lString;
			}

			lString = "";
			gl = false;
			for (x = 0; x <= this.lstSaleref.Items.Count - 1; x++) {
				if (this.lstSaleref.GetItemChecked(x)) {
					if (x == 0) {
						lString = lString + " Sale_CardRef <>''";
						gl = true;
					} else if (x == 1) {
						if (gl == true) {
							lString = lString + " OR Sale_OrderRef <>''";
						} else {
							lString = lString + " Sale_OrderRef <>''";
							gl = true;
						}
					} else if (x == 2) {
						if (gl == true) {
							lString = lString + " OR Sale_SerialRef <>''";
						} else {
							lString = lString + " Sale_SerialRef <>''";
						}
					}
				}
			}

			if (!string.IsNullOrEmpty(lString)) {
				lString = " AND (" + Strings.Mid(lString, 2) + ")";
				lWhere = lWhere + lString;
			}

			if (!string.IsNullOrEmpty(lWhere))
				lWhere = " WHERE " + Strings.Mid(lWhere, 6);

			//FROM OLD BO code               sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName,aPerson1.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson1 ON Sale.Sale_PersonID = aPerson1.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID "
			//added new Mgr field below      sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName,aPerson.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID "
			//query copy of report SELECT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName, aPerson.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID WHERE (((Sale.Sale_PosID)=12) AND ((SaleItem.SaleItem_Reversal)=True));

			if (chkOutCon.CheckState) {
				//sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID "
				sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName, aPOS1.POS_Name FROM ((SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID) INNER JOIN aPOS1 ON Sale.Sale_PosID = aPOS1.POSID ";
			} else {
				//sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem RIGHT JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID "
				sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName, aPOS1.POS_Name FROM ((SaleItem RIGHT JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID) INNER JOIN aPOS1 ON Sale.Sale_PosID = aPOS1.POSID ";
			}

			sql = sql + lWhere;
			Debug.Print(sql);
			return sql;

		}
		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			decimal SumSales = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			//As New cryPOSreport
			ReportNone.Load("cryNoRecords.rpt");
			Report.Load("cryPOSreport.rpt");
			 // ERROR: Not supported in C#: OnErrorStatement


			if (chkSum.CheckState) {
				Report.Load("cryPOSreportSum.rpt");
			} else {
				Report.Load("cryPOSreport.rpt");
				//Set Report = New cryPOSreportRevoke
			}

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name From aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			rs = modReport.getRSreport(ref getSQL());

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName.", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));";

			//sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) AND ((SaleItem.SaleItem_Revoke) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) AND ((SaleItem.SaleItem_Revoke) <> 0))"
			sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0))";
			rsData = modReport.getRSreport(ref sql);

			if (rsData.BOF | rsData.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			if (emp_Clicked() == true) {
				SumSales = 0;
				while (rs.EOF == false) {
					SumSales = SumSales + rs.Fields("Sale_Total").Value;
					rs.moveNext();
				}
				//Resise to excluding vat
				SumSales = SumSales - (SumSales * 0.14);
				rs.MoveFirst();
				Report.SetParameterValue("txtComm", (Information.IsDBNull(rs.Fields("Person_Comm").Value) ? 0 : rs.Fields("Person_Comm").Value));
				Report.SetParameterValue("txtTotalCommision", Strings.FormatNumber((SumSales * rs.Fields("Person_Comm").Value) / 100, 2));
			}

			if (chkOutCon.CheckState)
				Report.SetParameterValue("txtTitle", "Point Of Sale Outstanding Consignments for Device");

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsData);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtComm").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		private bool emp_Clicked()
		{
			bool functionReturnValue = false;
			short intj = 0;
			short j = 0;
			short inClick = 0;

			inClick = lstPerson.Items.Count - 1;

			intj = 0;

			for (j = 0; j <= inClick; j++) {
				if (lstPerson.GetItemChecked(j) == true) {
					intj = intj + 1;
					functionReturnValue = true;
					return functionReturnValue;
				}
			}

			functionReturnValue = false;
			return functionReturnValue;

		}
		private short emp_Clicked1()
		{
			short intj = 0;
			short j = 0;
			short inClick = 0;

			inClick = lstPerson.Items.Count - 1;

			intj = 0;

			for (j = 0; j <= inClick; j++) {
				if (lstPerson.GetItemChecked(j) == true) {
					intj = intj + 1;
				}
			}

		}

		private void frmPOSreport_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			lstPerson.Items.Clear();
			rs = modReport.getRSreport(ref "SELECT aPerson.PersonID, [Person_FirstName] & ' ' & [Person_Position] AS personName From aPerson Where (((aPerson.PersonID) <> 1) And ((aPerson.Person_Disabled) = False)) ORDER BY [Person_FirstName] & ' ' & [Person_Position];");
			int m = 0;
			while (!(rs.EOF)) {
				m = this.lstPerson.Items.Add(rs.Fields("PersonName").Value);
				//lstPerson = New SetItemData(m, rs.Fields("PersonID").Value)
				rs.MoveNext();
			}
			lstChannel.Items.Clear();
			rs = modReport.getRSreport(ref "SELECT aChannel.ChannelID, aChannel.Channel_Name From aChannel Where (((aChannel.Channel_Disabled) = False)) ORDER BY aChannel.ChannelID;");
			//Dim m As Integer
			while (!(rs.EOF)) {
				m = this.lstChannel.Items.Add(rs.Fields("Channel_Name").Value);
				//lstChannel = New SetItemData(m, rs.Fields("ChannelID").Value)
				rs.moveNext();
			}

			lstPOS.Items.Clear();
			rs = modReport.getRSreport(ref "SELECT aPOS.POSID, aPOS.POS_Name From aPOS ORDER BY aPOS.POSID;");
			while (!(rs.EOF)) {
				m = this.lstPOS.Items.Add(rs.Fields("POS_Name").Value);
				//lstPOS = New SetItemData(m, rs.Fields("POSID").Value)
				rs.moveNext();
			}

			loadLanguage();

		}
	}
}
