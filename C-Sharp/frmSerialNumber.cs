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
	internal partial class frmSerialNumber : System.Windows.Forms.Form
	{
		short intComp;
		short inIndex;

		private void loadLanguage()
		{

			//frmSerialNumber = No Code  [Serial Number Entry]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSerialNumber.Caption = rsLang("LanguageLayoutLnk_Description"): frmSerialNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2431;
			//Import|Checked
			if (modRecordSet.rsLang.RecordCount){Command1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label5 = No Code           [Item Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label4 = No Code           [Item Code]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Note: Label6.caption has a spelling mistake!
			//Label6 = no Code           [Received]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2026;
			//Returned|Checked
			if (modRecordSet.rsLang.RecordCount){Label7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1055;
			//Serial Number|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAdd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAdd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label2 = No Code           [List Of Serial Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label8 = No Code           [All Items that are being returned should be checked]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdRemove = No Code        [Remove]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdRemove.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRemove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2464;
			//Update|Checked
			if (modRecordSet.rsLang.RecordCount){cmdUpdate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdUpdate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSerialNumber.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (Conversion.Val(txtQty.Text) == lstSerial.Items.Count) {
				Interaction.MsgBox("Enough Item Serial number(s) have been entered", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

			if (string.IsNullOrEmpty(txtSerialNbr.Text)) {
				Interaction.MsgBox("Please enter the serial number before you continue", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			} else {
				//Check duplicate serials in database
				sql = "SELECT tblSerialNumber FROM tblSerialTracking WHERE tblStockItemID = " + Conversion.Val(Strings.Trim(txtCode.Text));

				rs = modRecordSet.getRS(ref sql);

				if (rs.RecordCount >= 1) {
					while (rs.EOF == false) {
						if (Strings.UCase(rs.Fields("tblSerialNumber").Value) == Strings.UCase(txtSerialNbr.Text)) {
							Interaction.MsgBox("Item with this " + Strings.UCase(txtSerialNbr.Text) + " Serial number already exists", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
							txtSerialNbr.Text = "";
							txtSerialNbr.Focus();

							return;
						}
						rs.moveNext();
					}
				}

				if (ChkDuplicates(ref Strings.Trim(txtSerialNbr.Text)) == false) {
					lstSerial.Items.Add(Strings.Trim(txtSerialNbr.Text));
					txtSerialNbr.Text = "";
				} else {
					Interaction.MsgBox("This serial number exist already in the list", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				}
			}

		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.Grv_Unload = true;
			this.Close();


		}

		private void cmdRemove_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short inrsp = 0;

			inrsp = Interaction.MsgBox("Do you want to remove this serial number", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

			if (inrsp == MsgBoxResult.Yes) {
				if (lstSerial.SelectedIndex >= 0)
					lstSerial.Items.RemoveAt(lstSerial.SelectedIndex);
			}

		}
		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			string sql1 = null;
			string sql2 = null;
			string srItem = null;
			short intr = 0;
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rt = default(ADODB.Recordset);
			short jStatus = 0;

			if (Conversion.Val(txtQty.Text) != lstSerial.Items.Count) {
				Interaction.MsgBox("Item serial number(s) should be " + Conversion.Val(txtQty.Text) + " in number", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			} else {
				jStatus = ChkReturned();
				if (jStatus == 1) {
					for (intr = 0; intr <= lstSerial.Items.Count - 1; intr++) {
						if (lstSerial.GetItemChecked(intr) == true) {
							srItem = "RT" + lstSerial.Text.Trim(Strings.ChrW(intr));
						} else {
							srItem = "RC" + lstSerial.Text.Trim(Strings.ChrW(intr));
						}
						modApplication.tempStockItem[intComp] = Strings.Trim(srItem);
						intComp = intComp + 1;

					}

				} else if (jStatus == 2) {
					Interaction.MsgBox("Only " + Strings.Trim(txtRtd.Text) + " should be returned on this Item", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				} else if (jStatus == 3) {
					Interaction.MsgBox("You've selected few Items for return than specified", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				} else if (jStatus == 4) {
					Interaction.MsgBox("There are no returns for this Item!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

			}

			lstSerial.Items.Clear();
			inIndex = inIndex + 1;

			if (inIndex < modApplication.intCurr) {
				txtItem.Text = modApplication.intArrayName[inIndex];
				txtCode.Text = Convert.ToString(modApplication.intArraySCode[inIndex]);
				sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + Conversion.Val(Strings.Trim(txtCode.Text)) + " AND GRVItem_Return = 0 AND GRVItem_GRVID = " + modApplication.Gr_ID;

				sql2 = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + Conversion.Val(Strings.Trim(txtCode.Text)) + " AND GRVItem_Return = 1 AND GRVItem_GRVID = " + modApplication.Gr_ID;

				rs = modRecordSet.getRS(ref sql);

				rt = modRecordSet.getRS(ref sql2);
				if (rs.RecordCount == 1) {
					txtQty.Text = Convert.ToString(Convert.ToInt16(rs("GRVItem_Quantity").Value));
					if (rt.RecordCount > 0) {
						txtRtd.Text = Convert.ToString(Convert.ToInt16(rt.Fields("GRVItem_Quantity").Value));
					} else {
						txtRtd.Text = Convert.ToString(0);
					}
				}
			} else {
				this.Close();
			}

		}

		private void frmSerialNumber_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lstSerial.Items.Clear();
			//Loop thru items
			LoadGRVItemValues();

			loadLanguage();
		}

		private void txtQty_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (Information.IsNumeric(Strings.Chr(KeyAscii)) == false) {
				KeyAscii = 0;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		public short ChkReturned()
		{
			short functionReturnValue = 0;
			short j = 0;
			short i = 0;
			//Count Checked
			i = 0;
			j = lstSerial.Items.Count;

			for (j = 0; j <= lstSerial.Items.Count - 1; j++) {
				if (lstSerial.GetItemChecked(j) == true) {
					i = i + 1;
				}
			}

			if (Conversion.Val(txtRtd.Text) > 0) {
				if (i == Conversion.Val(txtRtd.Text)) {
					functionReturnValue = 1;
					//Commit the transaction
				} else if (i > Conversion.Val(txtRtd.Text)) {
					functionReturnValue = 2;
					//more serials have been specified as returned that required
				} else if (i < Conversion.Val(txtRtd.Text)) {
					functionReturnValue = 3;
					//Less serial have been specified for than required
				}
			} else if (Conversion.Val(txtRtd.Text) == 0) {
				if (i == 0) {
					functionReturnValue = 1;
					//Commit transaction
				} else {
					functionReturnValue = 4;
					//No returned but some item have been clicked for return
				}
			}
			return functionReturnValue;

		}
		public bool ChkDuplicates(ref string SN)
		{
			bool functionReturnValue = false;
			short inC = 0;

			if (lstSerial.Items.Count == 0) {
				functionReturnValue = false;
			} else {
				for (inC = 0; inC <= lstSerial.Items.Count - 1; inC++) {
					if (Strings.Trim(SN) == lstSerial.Text.Trim(Strings.ChrW(inC))) {
						functionReturnValue = true;
						return functionReturnValue;
					}
				}
				functionReturnValue = false;
			}
			return functionReturnValue;

		}
		public void LoadGRVItemValues()
		{
			string sql2 = null;
			string sql = null;
			bool inAr = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			ADODB.Recordset rt = default(ADODB.Recordset);


			intComp = 0;

			inAr = false;
			inIndex = 0;

			modApplication.rs_St.MoveFirst();

			while (modApplication.rs_St.EOF == false) {
				//sql = "SELECT * FROM tblSerialFlag WHERE tblStockItemID = " & rs_St("GRVItem_StockItemID")
				sql = "SELECT * FROM StockItem WHERE StockItemID = " + modApplication.rs_St.Fields("GRVItem_StockItemID").Value;
				rs = modRecordSet.getRS(ref sql);
				//Check serial flag

				if (rs.RecordCount == 1) {
					//If rs("tblSerialTrack") = True Then
					if (rs.Fields("StockItem_SerialTracker").Value == true) {
						//sql = "SELECT StockItemID,StockItem_Name FROM StockItem WHERE StockItemID = " & rs_St("GRVItem_StockItemID")
						rs1 = modRecordSet.getRS(ref sql);
						modApplication.intArrayName[modApplication.intCurr] = Strings.Trim(rs1.Fields("StockItem_Name").Value);
						modApplication.intArraySCode[modApplication.intCurr] = rs1.Fields("StockItemID").Value;
						modApplication.intCurr = modApplication.intCurr + 1;
						inAr = true;
					}
				}
				modApplication.rs_St.moveNext();
			}


			if (inAr == true) {
				txtItem.Text = modApplication.intArrayName[0];
				txtCode.Text = Convert.ToString(modApplication.intArraySCode[0]);
			}

			lstSerial.Items.Clear();

			sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + Conversion.Val(Strings.Trim(txtCode.Text)) + " AND GRVItem_Return = 0 AND GRVItem_GRVID = " + modApplication.Gr_ID;

			sql2 = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + Conversion.Val(Strings.Trim(txtCode.Text)) + " AND GRVItem_Return = 1 AND GRVItem_GRVID = " + modApplication.Gr_ID;

			rs = modRecordSet.getRS(ref sql);
			rt = modRecordSet.getRS(ref sql2);
			if (rs.RecordCount == 1) {
				txtQty.Text = Convert.ToString(Convert.ToInt16(rs.Fields("GRVItem_Quantity").Value));
				if (rt.RecordCount > 0) {
					txtRtd.Text = Convert.ToString(Convert.ToInt16(rt.Fields("GRVItem_Quantity").Value));
				} else {
					txtRtd.Text = Convert.ToString(0);
				}
			}

		}
		public void SaveIntoTable()
		{
			string sql = null;
			//Save all details into serial tables
			ADODB.Recordset rs = default(ADODB.Recordset);
			short intK = 0;
			short intP = 0;
			short Grv_qty = 0;
			short Grv_Track = 0;
			short UpLoop = 0;

			Grv_qty = 0;
			Grv_Track = 0;

			for (intK = 0; intK <= modApplication.intCurr - 1; intK++) {
				sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + modApplication.intArraySCode[intK] + " AND GRVItem_Return = 0 AND GRVItem_GRVID = " + modApplication.Gr_ID;
				rs = modRecordSet.getRS(ref sql);

				Grv_qty = (rs.Fields("GRVItem_Quantity").Value - 1);

				UpLoop = Grv_Track + Grv_qty;

				if (rs.RecordCount == 1) {
					for (intP = Grv_Track; intP <= UpLoop; intP++) {
						sql = "INSERT INTO tblSerialTracking (tblStockItemID,tblSerialNumber,tblDatePurchases) " + "VALUES (" + Conversion.Val(Convert.ToString(modApplication.intArraySCode[intK])) + ",'" + Strings.Trim(modApplication.tempStockItem[intP]) + "',#" + Convert.ToDateTime(DateAndTime.Today) + "#)";
						modRecordSet.cnnDB.Execute(sql);

					}

					Grv_Track = Grv_qty + 1;
				}
			}

		}
		private void txtSerialNbr_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);

			if (KeyAscii == 13) {
				if (!string.IsNullOrEmpty(txtSerialNbr.Text)) {
					cmdAdd_Click(cmdAdd, new System.EventArgs());
				} else {
					Interaction.MsgBox("Please enter the serial number before you continue", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					goto EventExitSub;
				}
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
