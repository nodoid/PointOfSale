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
	internal partial class frmUpdateReportData : System.Windows.Forms.Form
	{
		short gCNT;
		short gTotal;

		private void loadLanguage()
		{

			//Label1 = No Code   [Updating Report Data...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmUpdateReportData.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadReportData()
		{
			ShowDialog();
		}

		private void moveItem()
		{
			gCNT = gCNT + 1;
			picInner.Width = sizeConvertors.twipsToPixels(Convert.ToInt16(sizeConvertors.pixelToTwips(picOuter.Width, true) / gTotal * gCNT) + 100, true);
			System.Windows.Forms.Application.DoEvents();
		}

		private void beginUpdate()
		{
			picInner.Width = 0;
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();

			//fill the templateReport with data
			ADODB.Connection ccndbReport = default(ADODB.Connection);
			string[] lTable = null;
			short Y = 0;
			lTable = Strings.Split("aChannel,aCompany,aConsignment,aCustomer,aDayEnd,aDayEndDepositItemLnk,aDeposit,aftConstruct,aftData,aftDataItem,aftSet,aGRV,aGRVDeposit,aGRVitem,aPackSize,aPayout,aPerson,aPOS,aPricingGroup,aPurchaseOrder,aRecipe,aRecipeStockitemLnk,aSaleItemReciept,aShrink,aStockBreakTransaction,aStockGroup,aStockItem,aStockTakeDetail,Supplier,Vat", ",");
			System.Windows.Forms.Application.DoEvents();
			gTotal = 9 + 1 * 9;
			//ccndbReport.Close
			ccndbReport = modRecordSet.openConnectionInstance(ref "templatereport.mdb");
			for (Y = 0; Y <= Information.UBound(lTable); Y++) {
				moveItem();
				System.Windows.Forms.Application.DoEvents();
				ccndbReport.Execute("DELETE * FROM " + lTable[Y] + ";");
				ccndbReport.Execute("INSERT INTO " + lTable[Y] + " SELECT * FROM " + lTable[Y] + "1;");
			}
			//fill the templateReport with data

			System.Windows.Forms.Application.DoEvents();
			this.Close();

		}

		private void frmUpdateReportData_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			picInner.Width = 0;
		}

		private void tmrStart_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrStart.Enabled = false;
			beginUpdate();
		}
	}
}
