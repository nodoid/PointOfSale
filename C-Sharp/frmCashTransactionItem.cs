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
	internal partial class frmCashTransactionItem : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gQuantity;
		List<CheckBox> chkChannel = new List<CheckBox>();
		private void loadLanguage()
		{

			//frmCashTransactionItem = No Code   [Edit a Cash Transaction Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCashTransactionItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmCashTransactionItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2145;
			//Shrink Size|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_4 = No Code                   [This Cash Transaction does not apply to the following payment methods]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkType_0 = No Code               [Not Valid for Credit Card Payments]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkType_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkType_1 = No Code               [Not Valid for Debit Card Payments]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkType_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkType_2 = No Code               [Not Valid for Cheque Payments]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkType_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Note: _lbl_0 has a spelling mistake/grammar mistake in Caption!
			//_lbl_0 = No Code                   [Disable this Cash Transaction for the following checked Sale Channels]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkChannel(1) = No Code/Dynamic/NA?
			//chkChannel(2) = No Code/Dynamic/NA?
			//chkChannel(3) = No Code/Dynamic/NA?
			//chkChannel(4) = No Code/Dynamic/NA?
			//chkChannel(5) = No Code/Dynamic/NA?
			//chkChannel(6) = No Code/Dynamic/NA?
			//chkChannel(7) = No Code/Dynamic/NA?
			//chkChannel(8) = No Code/Dynamic/NA?
			//chkChannel(9) = No Code/Dynamic/NA?

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCashTransactionItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel");
			while (!(rs.EOF)) {
				chkChannel[rs.Fields("ChannelID").Value].Text = rs.Fields("ChannelID").Value + ". " + rs.Fields("Channel_Name").Value;
				rs.moveNext();
			}
			rs.Close();
			if (gQuantity) {

				rs = modRecordSet.getRS(ref "SELECT CashTransaction.*, StockItem.StockItem_Name FROM CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID WHERE (((CashTransaction.CashTransaction_StockItemID)=" + gStockItemID + ") AND ((CashTransaction.CashTransaction_Shrink)=" + gQuantity + "));");
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					txtPrice.Text = Convert.ToString(rs.Fields("CashTransaction_Amount").Value * 100);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					cmbQuantity.Tag = gQuantity;
					this._chkType_0.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rs.Fields("CashTransaction_type").Value & 1)));
					this._chkType_1.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rs.Fields("CashTransaction_type").Value & 2)));
					this._chkType_2.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rs.Fields("CashTransaction_type").Value & 4)));
					this._chkChannel_1.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel1").Value);
					this._chkChannel_2.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel2").Value);
					this._chkChannel_3.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel3").Value);
					this._chkChannel_4.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel4").Value);
					this._chkChannel_5.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel5").Value);
					this._chkChannel_6.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel6").Value);
					this._chkChannel_7.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel7").Value);
					this._chkChannel_8.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel8").Value);
					this._chkChannel_9.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel9").Value);

				} else {
					this.Close();
					return;
				}
			} else {
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					txtPrice.Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					cmbQuantity.Tag = rs.Fields("CatalogueChannelLnk_Quantity").Value;
					this._chkType_0.CheckState = System.Windows.Forms.CheckState.Checked;
					this._chkType_1.CheckState = System.Windows.Forms.CheckState.Checked;
					this._chkType_2.CheckState = System.Windows.Forms.CheckState.Checked;
				} else {
					this.Close();
					return;
				}

			}
			rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_Quantity From Catalogue Where (((Catalogue.Catalogue_StockItemID) = " + gStockItemID + ") And ((Catalogue.Catalogue_Disabled) = 0)) ORDER BY Catalogue.Catalogue_Quantity;");
			cmbQuantity.Items.Clear();
			int m = 0;
			while (!(rs.EOF)) {
				m = cmbQuantity.Items.Add(rs.Fields("Catalogue_Quantity").Value);
				if (cmbQuantity.Tag == rs.Fields("Catalogue_Quantity").Value) {
					cmbQuantity.SelectedIndex = m;
				}
				rs.moveNext();
			}
		}
		public void loadItem(ref int stockitemID, ref int quantity)
		{
			gStockItemID = stockitemID;
			gQuantity = quantity;
			loadData();

			loadLanguage();
			ShowDialog();
		}

		private void frmCashTransactionItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			bool mbAddNewFlag = false;
			bool mbEditFlag = false;
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

		private void cmdCancel_Click()
		{
			bool mbDataChanged = false;
			int mvBookMark = 0;
			ADODB.Recordset adoPrimaryRS = new ADODB.Recordset();
			bool mbAddNewFlag = false;
			bool mbEditFlag = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (mbAddNewFlag) {
				this.Close();
			} else {
				mbEditFlag = false;
				mbAddNewFlag = false;
				adoPrimaryRS.CancelUpdate();
				if (mvBookMark > 0) {
					adoPrimaryRS.Bookmark = mvBookMark;
				} else {
					adoPrimaryRS.MoveFirst();
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			string sql = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			short lBit = 0;
			functionReturnValue = true;
			modRecordSet.cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" + gStockItemID + ") AND ((CashTransaction.CashTransaction_Shrink)=" + gQuantity + "));");
			modRecordSet.cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" + gStockItemID + ") AND ((CashTransaction.CashTransaction_Shrink)=" + Convert.ToString(this.cmbQuantity.SelectedIndex) + "));");
			if (this._chkType_0.CheckState)
				lBit = lBit + 1;
			if (this._chkType_1.CheckState)
				lBit = lBit + 2;
			if (this._chkType_2.CheckState)
				lBit = lBit + 4;

			modRecordSet.cnnDB.Execute("INSERT INTO CashTransaction ( CashTransaction_StockItemID, CashTransaction_Shrink, CashTransaction_Amount, CashTransaction_Type, CashTransaction_Disabled, CashTransaction_Channel1, CashTransaction_Channel2, CashTransaction_Channel3, CashTransaction_Channel4, CashTransaction_Channel5, CashTransaction_Channel6, CashTransaction_Channel7, CashTransaction_Channel8, CashTransaction_Channel9 ) SELECT " + gStockItemID + ", " + Convert.ToString(this.cmbQuantity.SelectedIndex) + ", " + Convert.ToDecimal(this.txtPrice.Text) + ", " + lBit + ", 0," + chkChannel[1].CheckState + ", " + chkChannel[2].CheckState + ", " + chkChannel[3].CheckState + ", " + chkChannel[4].CheckState + ", " + chkChannel[5].CheckState + ", " + chkChannel[6].CheckState + ", " + chkChannel[7].CheckState + ", " + chkChannel[8].CheckState + ", " + chkChannel[9].CheckState + ";");
			sql = "UPDATE (StockItem AS StockItem_1 INNER JOIN (CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID) ON StockItem_1.StockItem_PriceSetID = StockItem.StockItem_PriceSetID) INNER JOIN CashTransaction AS CashTransaction_1 ON (CashTransaction_1.CashTransaction_Shrink = CashTransaction.CashTransaction_Shrink) AND (StockItem_1.StockItemID = CashTransaction_1.CashTransaction_StockItemID) SET CashTransaction_1.CashTransaction_Amount = [CashTransaction]![CashTransaction_Amount], CashTransaction_1.CashTransaction_Type = [CashTransaction]![CashTransaction_Type], CashTransaction_1.CashTransaction_Disabled = [CashTransaction]![CashTransaction_Disabled], CashTransaction_1.CashTransaction_Channel1 = [CashTransaction]![CashTransaction_Channel1], CashTransaction_1.CashTransaction_Channel2 = [CashTransaction]![CashTransaction_Channel2], CashTransaction_1.CashTransaction_Channel3 = [CashTransaction]![CashTransaction_Channel3], ";
			sql = sql + " CashTransaction_1.CashTransaction_Channel4 = [CashTransaction]![CashTransaction_Channel4], CashTransaction_1.CashTransaction_Channel5 = [CashTransaction]![CashTransaction_Channel5], CashTransaction_1.CashTransaction_Channel6 = [CashTransaction]![CashTransaction_Channel6], CashTransaction_1.CashTransaction_Channel7 = [CashTransaction]![CashTransaction_Channel7], CashTransaction_1.CashTransaction_Channel8 = [CashTransaction]![CashTransaction_Channel8], CashTransaction_1.CashTransaction_Channel9 = [CashTransaction]![CashTransaction_Channel9] ";
			sql = sql + " WHERE (((CashTransaction.CashTransaction_StockItemID)=" + gStockItemID + ") AND ((CashTransaction_1.CashTransaction_StockItemID)<>" + gStockItemID + ") AND ((StockItem_1.StockItem_PriceSetID)<>0));";
			modRecordSet.cnnDB.Execute(sql);
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
			if (update_Renamed()) {
				this.Close();
			}
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

		private void frmCashTransactionItem_Load(object sender, System.EventArgs e)
		{
			chkChannel.AddRange(new CheckBox[] {
				_chkChannel_1,
				_chkChannel_2,
				_chkChannel_3,
				_chkChannel_4,
				_chkChannel_5,
				_chkChannel_6,
				_chkChannel_7,
				_chkChannel_8,
				_chkChannel_9
			});
		}
	}
}
