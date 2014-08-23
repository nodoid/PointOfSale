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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmMWSelect : System.Windows.Forms.Form
	{
		int lMWNo;
		ADODB.Recordset rsMWare;

		private void loadLanguage()
		{

			//frmMWSelect = No Code  [Warehouse Selection]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMWSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmMWSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMWSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getMWNo()
		{
			int functionReturnValue = 0;
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			rsMWare = modRecordSet.getRS(ref "SELECT WarehouseID, Warehouse_Name From Warehouse WHERE (WarehouseID > 1) ORDER BY WarehouseID");
			if (rsMWare.RecordCount == 1) {
				functionReturnValue = rsMWare.Fields("WarehouseID").Value;
				goto jumpOut;
			}

			cmbMWNo.Items.Clear();
			while (!(rsMWare.EOF)) {
				cmbMWNo.Items.Add(new LBI(rsMWare.Fields("Warehouse_Name").Value, rsMWare.Fields("WarehouseID").Value));
				rsMWare.moveNext();
			}
			cmbMWNo.SelectedIndex = 0;
			txtWNO.Text = Convert.ToString(cmbMWNo.SelectedIndex);

			loadLanguage();
			this.ShowDialog();
			functionReturnValue = lMWNo;
			jumpOut:
			return functionReturnValue;


		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			lMWNo = Convert.ToInt32(txtWNO.Text);
			lMWNo = Convert.ToInt32(cmbMWNo.SelectedIndex);
			this.Close();
		}
	}
}
