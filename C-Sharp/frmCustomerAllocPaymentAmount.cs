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
	internal partial class frmCustomerAllocPaymentAmount : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;
		int WHFromA;
		int WHToB;
		decimal lAmount;

		private void loadLanguage()
		{

			//frmCustomerAllocPaymentAmount = No Code    [Allocate Partial Amount]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCustomerAllocPaymentAmount.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerAllocPaymentAmount.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1188;
			//Allocate|Checked
			if (modRecordSet.rsLang.RecordCount){lblPComp.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblPComp.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code                           [Available]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1188;
			//Allocate|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCustomerAllocPaymentAmount.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public decimal getAmount(ref decimal iAmount)
		{
			lblStockItem.Text = Strings.FormatNumber(iAmount, 2);
			txtPrice.Text = Strings.FormatNumber(0 - iAmount, 2);
			//"0.00"

			loadLanguage();
			ShowDialog();
			//If txtPrice.Text = "" Then txtPrice.Text = 0
			return lAmount;
			//CCur(txtPrice.Text)
		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name FROM StockItem WHERE ((StockItem.StockItemID)=" + gStockItemID + ");");
			if (rs.RecordCount) {
				lblStockItem.Text = rs.Fields("StockItem_Name").Value;
				this.Height = sizeConvertors.twipsToPixels(2520, false);

				loadLanguage();
				ShowDialog();
			}

		}

//Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
		public void loadItem(ref int stockitemID, ref int quantity = 0, ref int WHFrom = 0, ref int WHTo = 0)
		{
			gStockItemID = stockitemID;
			//gPromotionID = promotionID
			gQuantity = quantity;
			WHFromA = WHFrom;
			WHToB = WHTo;
			lblPComp.Text = My.MyProject.Forms.frmStockTransferWH.lblWHA.Text;
			loadData();

			//show 1

		}
		private void frmCustomerAllocPaymentAmount_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			object mbAddNewFlag = null;
			object mbEditFlag = null;
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//If mbAddNewFlag Then
			lAmount = 0;
			this.Close();
			//Else
			//mbEditFlag = False
			//mbAddNewFlag = False
			//adoPrimaryRS.CancelUpdate
			//If mvBookMark > 0 Then
			//    adoPrimaryRS.Bookmark = mvBookMark
			//Else
			//    adoPrimaryRS.MoveFirst
			//End If
			//mbDataChanged = False
			//End If
		}

		private void ChkHandheldWHTransfer()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string strFldName = null;
			ChkTransTable:


			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM HandheldWHTransfer;");
			if (rs.RecordCount) {
			}

			return;
			Err_ChkTransTable:
			if (Err().Number == -2147217865 & Err().Description == "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldWHTransfer'.  Make sure it exists and that its name is spelled correctly.") {
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency, WHouseID Number";
				modRecordSet.cnnDB.Execute("CREATE TABLE HandheldWHTransfer (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				rs = modRecordSet.getRS(ref "SELECT * FROM HandheldWHTransfer;");
				if (rs.RecordCount) {
				}

				goto ChkTransTable;
			}

		}

		//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			string sql = null;
			TextBox txtQty = new TextBox();
			 // ERROR: Not supported in C#: OnErrorStatement


			ChkHandheldWHTransfer();

			sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" + gStockItemID + ", 0, " + (0 - Convert.ToDecimal(txtQty.Text)) + "," + WHFromA + ")";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" + gStockItemID + ", 0, " + Convert.ToDecimal(txtQty.Text) + "," + WHToB + ")";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (string.IsNullOrEmpty(txtPrice.Text))
				txtPrice.Text = Convert.ToString(0);
			if (Convert.ToDecimal(txtPrice.Text) > (0 - Convert.ToDecimal(lblStockItem.Text))) {
				Interaction.MsgBox("Insufficient funds.");
				return;
			}
			lAmount = Convert.ToDecimal(txtPrice.Text);
			//If CCur(txtQty.Text) > 0 Then
			//Else
			//    txtQty.SetFocus
			//    Exit Sub
			//End If

			//If update() Then
			this.Close();
			//End If
		}

		private void txtPrice_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPrice);
		}

		private void txtPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPressNegative(ref txtPrice, ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtPrice_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPrice, ref 2);
		}

		private void txtPriceS_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPriceS);
		}

		private void txtPriceS_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPriceS, ref 2);
		}

		private void txtQty_KeyPress(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:

					break;
			}
		}

		private void txtQty_MyGotFocus(System.Object eventSender, System.EventArgs eventArgs)
		{
			//txtQty.SelStart = 0
			//txtQty.SelLength = Len(txtQty.Text)
		}

		private void txtQty_MyLostFocus()
		{
			// LostFocus txtQty, 2
		}
	}
}
