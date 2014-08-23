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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockItem : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
				}
			}
		}
		ADODB.Recordset gRSpriceSet;
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;

		int gID;
		bool gUpdate;

		bool ChkC;
		List<TextBox> txtInteger = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtFields = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		List<GroupBox> Frame1 = new List<GroupBox>();
		List<RadioButton> optRecipeType = new List<RadioButton>();
		List<Button> cmdNew = new List<Button>();

		List<Button> cmdMove = new List<Button>();
		private void buildDataControls()
		{
			doDataControl(ref (this.cmbShrink), ref "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", ref "StockItem_ShrinkID", ref "ShrinkID", ref "Shrink_Name");
			doDataControl(ref (this.cmbPricingGroup), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
			doDataControl(ref (this.cmbSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
			doDataControl(ref (this.cmbVat), ref "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", ref "StockItem_VatID", ref "VatID", ref "Vat_Name");
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", ref "StockItem_DepositID", ref "DepositID", ref "Deposit_Name");
			doDataControl(ref (this.cmbStockGroup), ref "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", ref "StockItem_StockGroupID", ref "StockGroupID", ref "StockGroup_Name");
			doDataControl(ref (this.cmbPriceSet), ref "SELECT PriceSet.PriceSetID, [PriceSet_Name] & '(' & [StockItem_Name] & ')' AS priceSet_FullName FROM PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID Where (((PriceSet.PriceSet_Disabled) = 0)) ORDER BY PriceSet.PriceSet_Name;", ref "StockItem_PriceSetID", ref "PriceSetID", ref "priceSet_FullName");
			doDataControl(ref (this.cmbPrintLocation), ref "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", ref "StockItem_PrintLocationID", ref "PrintLocationID", ref "PrintLocation_Name");
			doDataControl(ref (this.cmbPrintGroup), ref "SELECT PrintGroupID, PrintGroup_Name FROM PrintGroup ORDER BY PrintGroup_Name", ref "StockItem_PrintGroupID", ref "PrintGroupID", ref "PrintGroup_Name");
			//for report group
			doDataControl(ref (this.cmbReportGroup), ref "SELECT ReportID,ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disabled = False ORDER BY ReportGroup_Name", ref "StockItem_ReportID", ref "ReportID", ref "ReportGroup_Name");
			//for pack size
			doDataControl(ref (this.cmbPackSize), ref "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", ref "StockItem_PackSizeID", ref "PackSizeID", ref "PackSize_Name");

			//doDataControl Me.cmbReportGroup, "SELECT ReportID,ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disable = False ORDER BY ReportGroup_Name", "StockItem_ReportID", "ReportID", "ReportGroup_Name"
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.DataSource = adoPrimaryRS;
			dataControl.DataField = DataField;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}
		public void loadItem(ref int id)
		{
			string sql = null;
			string InSt = null;
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.ListViewItem lItem = null;
			System.Windows.Forms.CheckBox oCheck = null;
			ADODB.Recordset rsj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string InStc = null;
			string d_Sold = null;
			short j = 0;
			string sql1 = null;
			ADODB.Recordset rsN = default(ADODB.Recordset);
			string Insk = null;
			ADODB.Recordset Rsp1 = default(ADODB.Recordset);
			ADODB.Recordset rsSerial = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT StockitemOverwrite.StockitemOverwriteID From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" + id + "));");
			if (rs.RecordCount)
				this.chkSQ.CheckState = System.Windows.Forms.CheckState.Checked;
			else
				chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked;
			rs.Close();
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID = " + id);

			if (adoPrimaryRS.BOF | adoPrimaryRS.EOF) {
			} else {
				gID = id;
				if (adoPrimaryRS.Fields("StockItem_OrderQuantity").Value == adoPrimaryRS.Fields("StockItem_Quantity").Value) {
					this.cmbReorder.SelectedIndex = 1;
				} else {
					this.cmbReorder.SelectedIndex = 0;
				}
				if (adoPrimaryRS.Fields("StockItemOrderType").Value == 1)
					this.cmbReorder.SelectedIndex = 1;
				else
					this.cmbReorder.SelectedIndex = 0;

				foreach (TextBox oText_loopVariable in this.txtFields) {
					oText = oText_loopVariable;
					oText.DataBindings.Add(adoPrimaryRS);
					oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
				}
				foreach (TextBox oText_loopVariable in this.txtInteger) {
					oText = oText_loopVariable;
					oText.DataBindings.Add(adoPrimaryRS);
					oText.Leave += txtInteger_Leave;
				}
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					oText.DataBindings.Add(adoPrimaryRS);
					oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
					oText.Leave += txtFloat_Leave;
				}
				//Bind the check boxes to the data provider
				foreach (CheckBox oCheck_loopVariable in this.chkFields) {
					oCheck = oCheck_loopVariable;
					oCheck.DataBindings.Add(adoPrimaryRS);
					oCheck.Tag = oCheck.CheckState;
				}
				buildDataControls();

				if (string.IsNullOrEmpty(cmbPriceSet.BoundText)) {
					chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else {
					chkPriceSet.CheckState = System.Windows.Forms.CheckState.Checked;
				}

				//New Serial Tracker Code.....
				if (adoPrimaryRS.Fields("StockItem_SerialTracker").Value)
					_chkFields_1.Tag = 1;
				else
					_chkFields_1.Tag = 0;
				if (adoPrimaryRS.Fields("StockItem_ATItem").Value)
					_chkFields_6.Tag = 1;
				else
					_chkFields_6.Tag = 0;

				//Shelf & Barcode printing
				//  If IsNull(adoPrimaryRS("StockItem_SBarcode")) Then
				//   OptPrint(2).value = True
				//If LCase(adoPrimaryRS("StockItem_SBarcode")) = "shelf" Then
				//   optPrint(0).value = True
				//ElseIf LCase(adoPrimaryRS("StockItem_SBarcode")) = "barcode" Then
				//   optPrint(1).value = True
				//End If

				//* Shelf and barcode printing
				if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == true) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Checked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Checked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false) {
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked;
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
				//*

				mbDataChanged = false;
				var _with1 = FGRecipe;
				_with1.Visible = false;
				_with1.RowCount = 1;
				_with1.Col = 4;
				_with1.Col = 0;
				_with1.row = 0;
				_with1.Text = "Product";
				_with1.set_ColAlignment(0, 1);
				_with1.set_ColWidth(0, 2000);
				_with1.CellFontBold = true;
				_with1.Col = 1;
				_with1.Text = "Total Cost";
				_with1.set_ColAlignment(1, 7);
				_with1.set_ColWidth(1, 1000);
				_with1.CellFontBold = true;
				_with1.Col = 2;
				_with1.Text = "Quantity";
				_with1.set_ColAlignment(2, 7);
				_with1.set_ColWidth(2, 750);
				_with1.CellFontBold = true;
				_with1.Col = 3;
				_with1.Text = "Line Cost";
				_with1.set_ColAlignment(3, 7);
				_with1.set_ColWidth(3, 1000);
				_with1.CellFontBold = true;
				_with1.Visible = !this._optRecipeType_0.Checked;

				if (string.IsNullOrEmpty(_txtFields_1.Text))
					_txtFields_1.Text = Convert.ToString(0);

				optRecipeType[Convert.ToInt16(_txtFields_1.Text)].Checked = true;
				loadRecipe();

				loadMessage();
				loadTree();

				//Assing serial number
				sql = "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " + id;

				if (adoPrimaryRS.Fields("StockItem_SerialTracker").Value) {
					rsSerial = modRecordSet.getRS(ref "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " + id);

					//Get serial Details...
					if (rsSerial.RecordCount > 0) {
						while (rsSerial.EOF == false) {
							lItem = lstvSerial.Items.Add(rsSerial.Fields("Serial_SerialNumber").Value);
							if (Rsp1.RecordCount > 0) {
								lItem.SubItems.Add(rsSerial.Fields("Serial_SupplierName").Value);
							} else {
								lItem.SubItems.Add("Default Suppier");
							}
							lItem.SubItems.Add(rsSerial.Fields("Serial_DatePurchases").Value);
							//If rsSerial("Serial_Instock") = True Then
							if (rsSerial.Fields("Serial_Instock").Value == true | rsSerial.Fields("Serial_Status").Value == "Returned") {
								InStc = "No";
								d_Sold = Conversion.Str(rsSerial.Fields("Serial_DateSold").Value);
								Insk = rsSerial.Fields("Serial_InvoiceNumber").Value;
							} else {
								InStc = "Yes";
							}
							lItem.SubItems.Add(InStc);
							lItem.SubItems.Add(d_Sold);
							lItem.SubItems.Add(Insk);
							d_Sold = "";
							Insk = "";

							rsSerial.MoveNext();
						}
						cmbShrink.Enabled = false;
					}
				}

				//Stock item found
			}
		}

		private void cmdUpdate_Click()
		{
			update_Renamed();
		}

		//UPGRADE_WARNING: Event chkFields.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		//Handles chkFields.CheckStateChanged
		private void chkFields_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			CheckBox chk = new CheckBox();
			chk = (CheckBox)eventSender;
			int Index = GetIndex.GetIndexer(ref chk, ref chkFields);
			if (Index == 13) {
				if (_chkFields_12.CheckState == 1 & _chkFields_13.CheckState == 1) {
					modApplication.blNextItem = true;
					//ElseIf _chkFields_12.value = 1 And _chkFields_12.value = 1 Then
					//ElseIf _chkFields_12.value = 1 And _chkFields_12.value = 1 Then
				} else {
					modApplication.blNextItem = false;
				}

			}
		}

		//UPGRADE_WARNING: Event chkPriceSet.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkPriceSet_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkPriceSet.CheckState == 1) {
				if (gRSpriceSet == null) {
				} else {
					if (gRSpriceSet.Fields("StockItemID").Value == adoPrimaryRS.Fields("StockItemID").Value) {
						_txtInteger_0.Enabled = true;
						_txtFloat_0.Enabled = true;
						_txtFloat_1.Enabled = true;
						_txtInteger_0.Enabled = true;
						cmbDeposit.Enabled = true;
						cmbPricingGroup.Enabled = true;
						cmbShrink.Enabled = true;
						cmbVat.Enabled = true;
						cmbPriceSet.Enabled = false;
						chkPriceSet.Enabled = false;
						lblPriceSet.Text = "Primary Pricing Set Item";
						lblPriceSet.Visible = true;
						lblPriceSet.BackColor = System.Drawing.Color.Red;
						lblPriceSet.ForeColor = System.Drawing.Color.White;
						return;
					}
				}
				_txtInteger_0.Enabled = false;
				_txtFloat_0.Enabled = false;
				_txtFloat_1.Enabled = false;
				_txtInteger_0.Enabled = false;

				cmbDeposit.Enabled = false;
				cmbPricingGroup.Enabled = false;
				cmbShrink.Enabled = false;
				cmbVat.Enabled = false;

				cmbPriceSet.Enabled = true;
				lblPriceSet.Text = "Child Pricing Set Item";
				lblPriceSet.Visible = true;
				lblPriceSet.BackColor = System.Drawing.Color.Yellow;
				lblPriceSet.ForeColor = System.Drawing.Color.Black;
			} else {
				_txtInteger_0.Enabled = true;
				_txtFloat_0.Enabled = true;
				_txtFloat_1.Enabled = true;

				cmbDeposit.Enabled = true;
				cmbPricingGroup.Enabled = true;
				cmbShrink.Enabled = true;
				cmbVat.Enabled = true;
				cmbPriceSet.Enabled = false;
				adoPrimaryRS.Fields("StockItem_PriceSetID").Value = 0;
				lblPriceSet.Visible = false;
			}
			return;
			System.Windows.Forms.Application.DoEvents();
			if (gRSpriceSet == null) {
			} else {
				if (gRSpriceSet.Fields("StockItemID").Value == adoPrimaryRS.Fields("StockItemID").Value) {
					Interaction.MsgBox("Primary");
					return;
				}
			}
			if (!string.IsNullOrEmpty(cmbPricingGroup.BoundText)) {
				this.cmbPriceSet.Enabled = true;
				_txtInteger_0.Enabled = false;
				_txtFloat_0.Enabled = false;
				cmbDeposit.Enabled = false;
				cmbPricingGroup.Enabled = false;
				cmbShrink.Enabled = false;
				_chkFields_1.Enabled = false;
				//        If gRSpriceSet Is Nothing Then
				//        Else
				//            cmbPricingGroup.BoundText = gRSpriceSet("StockItem_PricingGroupID")
				//        End If
			} else {
				this.cmbPriceSet.Enabled = false;
				cmbPriceSet.BoundText = "";
				_txtInteger_0.Enabled = true;
				_txtFloat_0.Enabled = true;
				cmbDeposit.Enabled = true;
				cmbPricingGroup.Enabled = true;
				cmbShrink.Enabled = true;
				_chkFields_1.Enabled = true;
			}
		}

		private void cmbDeposit_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}


		private void cmbPackSize_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmbPriceSet_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gUpdate)
				return;
			if (!string.IsNullOrEmpty(cmbPriceSet.BoundText)) {
				gRSpriceSet = modRecordSet.getRS(ref "SELECT StockItem.* FROM PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID WHERE (((PriceSet.PriceSetID)=" + cmbPriceSet.BoundText + "));");
				//        chkPriceSet_Click
			}
		}

		private void cmbPriceSet_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmbPricingGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}



		private void cmbReportGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.keyCode = 0
				update_Renamed();
				//        adoPrimaryRS.Move 0
				cmdClose_Click(cmdClose, new System.EventArgs());
			}

		}

		private void cmbShrink_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.keyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmbStockGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.keyCode = 0
				update_Renamed();
				//        adoPrimaryRS.Move 0
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmbSupplier_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.keyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmbVat_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.keyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmdbarcodeItem_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//* Check if Display name is empty and refuses to exit
			if (string.IsNullOrEmpty(Strings.Trim(this._txtFields_7.Text))) {
				Interaction.MsgBox("The Display Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
				this._txtFields_7.Focus();
				return;
			} else if (Information.IsNumeric(this._txtFields_7.Text) == true) {
				Interaction.MsgBox("The Display Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
				this._txtFields_7.Focus();
				return;
			} else if (string.IsNullOrEmpty(Strings.Trim(this._txtFields_8.Text))) {
				Interaction.MsgBox("The Receipt Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				// frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
				this._txtFields_8.Focus();
				return;
			} else if (Information.IsNumeric(this._txtFields_8.Text) == true) {
				Interaction.MsgBox("The Receipt Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
				this._txtFields_8.Focus();
				return;
			}
			update_Renamed();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			//*
			//Here a public function barcode is called.
			barcodeItem();
			//*
		}

		private void cmdDeposit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmDepositList.loadItem(ref 0);
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", ref "StockItem_DepositID", ref "DepositID", ref "Deposit_Name");
		}


		private void cmdDuplicate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Here a public function Duplicate_codes_report is called.
			Duplicate_codes_report();

		}

		private void cmdHistory_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmStockItemHistory.loadItem(ref adoPrimaryRS.Fields("StockItemID").Value);
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (My.MyProject.Forms.frmStockList.Visible == true) {
				if (modApplication.blNextItem == true) {
					cmdClose_Click(cmdClose, new System.EventArgs());
				} else if (modApplication.blNextItem == false) {
					cmdClose_Click(cmdClose, new System.EventArgs());
					My.MyProject.Forms.frmStockList.DataList1_DblClickS();
				}
			}
		}

		private void cmdPackSize_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPackSizeList.loadItem();
			doDataControl(ref (this.cmbPackSize), ref "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", ref "StockItem_PackSizeID", ref "PackSizeID", ref "PackSize_Name");
		}

		private void cmdpriceselist_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//* Display frmpricesetlist
			short asID = 0;
			asID = adoPrimaryRS.Fields("StockItemID").Value;

			this.Hide();
			My.MyProject.Forms.frmPriceSetList.ShowDialog();

			//*
		}

		private void cmdPricingGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPricingGroupList.getItem();
			doDataControl(ref (this.cmbPricingGroup), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_BOM(ref " WHERE receipeID=" + adoPrimaryRS.Fields("StockItemID").Value);
		}

		private void cmdPrintGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPrintGroupList.getItem();
			doDataControl(ref (this.cmbPrintGroup), ref "SELECT PrintGroupID, PrintGroup_Name FROM PrintGroup ORDER BY PrintGroup_Name", ref "StockItem_PrintGroupID", ref "PrintGroupID", ref "PrintGroup_Name");
		}

		private void cmdPrintLocation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPrintLocationList.getItem();
			doDataControl(ref (this.cmbPrintLocation), ref "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", ref "StockItem_PrintLocationID", ref "PrintLocationID", ref "PrintLocation_Name");
		}

		private void cmdRecipeAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			int lKey = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			lKey = My.MyProject.Forms.frmStockList2.getItem();
			FGRecipe.Visible = false;
			System.Windows.Forms.Application.DoEvents();
			FGRecipe.Visible = true;

			if (lKey != 0) {

				if (lKey != adoPrimaryRS.Fields("StockItemID").Value) {
					rs = modRecordSet.getRS(ref "SELECT * From RecipeStockitemLnk WHERE (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" + adoPrimaryRS.Fields("StockItemID").Value + ") AND ((RecipeStockitemLnk.RecipeStockitemLnk_StockitemID)=" + lKey + "));");


					if (rs.RecordCount) {
					} else {
						rs.AddNew();
						rs.Fields("RecipeStockitemLnk_RecipeID").Value = adoPrimaryRS.Fields("StockItemID").Value;
						rs.Fields("RecipeStockitemLnk_StockitemID").Value = lKey;
						rs.Fields("RecipeStockitemLnk_Quantity").Value = 1;
						rs.Update();
					}

					FGRecipe_LeaveCell(FGRecipe, new System.EventArgs());
					loadRecipe();
					var _with2 = FGRecipe;
					for (x = 1; x <= _with2.RowCount - 1; x++) {
						if (FGRecipe.get_RowData(ref ref x) == lKey) {
							_with2.row = x;
							_with2.Col = 2;
							FGRecipe_EnterCell(FGRecipe, new System.EventArgs());
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
			}

		}

		private void cmdReportGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmReportGroupList.loadItem(ref 0);
			doDataControl(ref (this.cmbReportGroup), ref "SELECT ReportID, ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disabled=False ORDER BY ReportGroup_Name", ref "StockItem_ReportID", ref "ReportID", ref "ReportGroup_Name");
			//doDataControl Me.cmbStockGroup, "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name"

		}

		private void cmdShrink_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmShrink.ShowDialog();
			doDataControl(ref (this.cmbShrink), ref "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", ref "StockItem_ShrinkID", ref "ShrinkID", ref "Shrink_Name");
		}

		private void cmdStockGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmStockGroupList.loadItem(ref 0);
			doDataControl(ref (this.cmbStockGroup), ref "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", ref "StockItem_StockGroupID", ref "StockGroupID", ref "StockGroup_Name");
		}

		private void cmdSupplier_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmSupplierList.loadItem(ref 0);
			doDataControl(ref (this.cmbSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
		}

		private void cmdVAT_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmVATList.loadItem();
			doDataControl(ref (this.cmbVat), ref "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", ref "StockItem_VatID", ref "VatID", ref "Vat_Name");
		}
		public object Command1_Click()
		{
			//    Command1.SetFocus
			// DoEvents
			My.MyProject.Forms.frmStockBarcode.loadItem(ref adoPrimaryRS.Fields("StockItemID").Value);
			frmStockBarcode form = new frmStockBarcode();
			form.Show();
		}


		private void Command2_Click()
		{
		}

		private void FGRecipe_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lString = null;
			var _with3 = FGRecipe;
			if (_with3.Visible & _with3.Col == 2) {
				txtQuantity.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with3.Left, true) + _with3.CellLeft, true);
				txtQuantity.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with3.Top, false) + _with3.CellTop, false);
				txtQuantity.Width = sizeConvertors.twipsToPixels(_with3.CellWidth, true);
				txtQuantity.Height = sizeConvertors.twipsToPixels(_with3.CellHeight, false);
				txtQuantity.Text = _with3.Text;
				if (string.IsNullOrEmpty(txtQuantity.Text))
					txtQuantity.Text = "0";
				txtQuantity.Tag = Convert.ToDecimal(txtQuantity.Text);
				txtQuantity.SelectionStart = 0;
				txtQuantity.SelectionLength = 999;
				txtQuantity.Visible = true;
				txtQuantity.Focus();
			} else {
				txtQuantity.Visible = false;
			}


		}

		//Handles FGRecipe.LeaveCell
		private void FGRecipe_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			double lAmount = 0;
			//    On Local Error Resume Next
			if (txtQuantity.Visible) {
				if (string.IsNullOrEmpty(txtQuantity.Text))
					txtQuantity.Text = "0";
				FGRecipe.Text = Strings.FormatNumber(txtQuantity.Text, 4);

				if (Convert.ToDecimal(txtQuantity.Text) != Convert.ToDecimal(txtQuantity.Tag)) {
					if (Convert.ToDecimal(txtQuantity.Text) == 0) {
						txtQuantity.Visible = false;
						modRecordSet.cnnDB.Execute("DELETE RecipeStockitemLnk.* From RecipeStockitemLnk WHERE RecipeStockitemLnk_RecipeID=" + adoPrimaryRS.Fields("StockItemID").Value + " AND RecipeStockitemLnk_StockitemID=" + FGRecipe.get_RowData(ref FGRecipe.row) + ";");
						loadRecipe();
					} else {
						modRecordSet.cnnDB.Execute("UPDATE RecipeStockitemLnk SET RecipeStockitemLnk_Quantity = " + Convert.ToDecimal(txtQuantity.Text) + " WHERE RecipeStockitemLnk_RecipeID=" + adoPrimaryRS.Fields("StockItemID").Value + " AND RecipeStockitemLnk_StockitemID=" + FGRecipe.get_RowData(ref FGRecipe.row) + ";");
						FGRecipe.set_TextMatrix(ref FGRecipe.row, ref 3, ref Strings.FormatNumber(Convert.ToDecimal(FGRecipe.get_TextMatrix(ref FGRecipe.row, ref 1)) * Convert.ToDecimal(FGRecipe.get_TextMatrix(ref FGRecipe.row, ref 2)), 2));
						lAmount = 0;
						for (x = 1; x <= FGRecipe.RowCount - 1; x++) {
							lAmount = lAmount + Convert.ToDouble(FGRecipe.get_TextMatrix(ref x, ref 3));
						}
						this.lblRecipeCost.Text = Strings.FormatNumber(lAmount, 2);
					}
				}
			}

		}
		private void loadRecipe()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			double lAmount = 0;
			//    Set rs = getRS("SELECT ProductReceipt.ProductReceipt_ProductChildID, ProductReceipt.ProductReceipt_Quantity, Product.Product_Name, [Product_CostLast]/[Product_SupplierQuantity] AS cost FROM ProductReceipt INNER JOIN Product ON ProductReceipt.ProductReceipt_ProductChildID = Product.ProductID WHERE (((ProductReceipt.ProductReceipt_ProductID)=" & gID & ") AND ((Product.Product_Discontinued)=False)) ORDER BY Product.Product_Name;")
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost FROM RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " + adoPrimaryRS.Fields("StockItemID").Value + ") And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name;");
			var _with4 = FGRecipe;
			_with4.RowCount = rs.RecordCount + 1;
			x = 1;
			while (!(rs.EOF)) {
				_with4.set_TextMatrix(x, 0, rs.Fields("StockItem_Name").Value);
				_with4.set_TextMatrix(x, 2, Strings.FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4));
				_with4.set_TextMatrix(x, 1, Strings.FormatNumber(rs.Fields("Cost").Value, 2));
				_with4.set_TextMatrix(x, 3, Strings.FormatNumber(Convert.ToDecimal(_with4.get_TextMatrix(x, 1)) * Convert.ToDecimal(_with4.get_TextMatrix(x, 2)), 2));
				_with4.set_RowData(x, rs.Fields("StockItemID").Value);
				//lAmount = lAmount + CDbl(FGRecipe.TextMatrix(x, 1))
				lAmount = lAmount + Convert.ToDouble(FGRecipe.get_TextMatrix(ref ref x, ref ref 3));

				x = x + 1;
				rs.MoveNext();
			}
			lblRecipeCost.Text = Strings.FormatNumber(lAmount, 2);

		}


		//UPGRADE_ISSUE: Label event lblRecipeCost.Change was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
		private void lblRecipeCost_Change()
		{
			if (Convert.ToInt16(_txtFields_1.Text)) {
				_txtFloat_0.Text = lblRecipeCost.Text;
				_txtFloat_1.Text = lblRecipeCost.Text;
				_txtInteger_0.Text = Convert.ToString(1);
			}
		}

		//UPGRADE_WARNING: Event optRecipeType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		//Handles optRecipeType.CheckedChanged
		private void optRecipeType_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				RadioButton txt = new RadioButton();
				txt = (RadioButton)eventSender;
				int Index = GetIndex.GetIndexer(ref txt, ref optRecipeType);
				_txtFields_1.Text = Convert.ToString(Index);
				FGRecipe.Visible = Index;
				cmdRecipeAdd.Visible = Index;
				lblRecipeCost.Visible = Index;
				cmdPrint.Visible = Index;
				if (Index) {
					_txtFloat_0.Enabled = false;
					_txtFloat_1.Enabled = false;
					_txtInteger_0.Enabled = false;
					_txtFloat_0.Text = lblRecipeCost.Text;
					_txtFloat_1.Text = lblRecipeCost.Text;
					_txtInteger_0.Text = Convert.ToString(1);
				} else {
					_txtFloat_0.Enabled = true;
					_txtFloat_1.Enabled = true;
					_txtInteger_0.Enabled = true;
					FGRecipe.Col = 0;
					FGRecipe.row = 0;
					txtQuantity.Visible = false;
				}
			}
		}
		//Handles TabStrip1.ClickEvent
		private void TabStrip1_ClickEvent(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			_Frame1_0.Visible = _Frame1_1.Visible == _Frame1_2.Visible == _Frame1_3.Visible == false;

			var _with5 = lstvSerial;
			_with5.Columns.Item(0).Width = sizeConvertors.twipsToPixels(1500, true);
			_with5.Columns.Item(1).Width = sizeConvertors.twipsToPixels(1500, true);
			_with5.Columns.Item(2).Width = sizeConvertors.twipsToPixels(1500, true);
			_with5.Columns.Item(3).Width = sizeConvertors.twipsToPixels(1500, true);
			//.ColumnHeaders(3).Width = (lstvSerial.Width / 4) - 30
		}
		private void txtQuantity_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumericNew(ref txtQuantity);
		}
		private void txtQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtQuantity_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocusNew(ref txtQuantity, ref 4);
			FGRecipe_LeaveCell(FGRecipe, new System.EventArgs());
		}

		private void txtQuantity_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					KeyCode = 0;
					FGRecipe_LeaveCell(FGRecipe, new System.EventArgs());
					if (FGRecipe.row + 1 == FGRecipe.RowCount) {
					} else {
						FGRecipe.row = FGRecipe.row + 1;
					}
					break;
				case 38:
					KeyCode = 0;
					if (FGRecipe.row - 1 == 0) {
					} else {
						FGRecipe.row = FGRecipe.row - 1;
					}
					break;
			}
		}

		private void frmStockItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void frmStockItem_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			Frame1.AddRange(new GroupBox[] {
				_Frame1_0,
				_Frame1_1,
				_Frame1_2,
				_Frame1_3
			});
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1,
				_txtFields_7,
				_txtFields_8,
				_txtFields_14
			});
			txtInteger.AddRange(new TextBox[] {
				_txtInteger_0,
				_txtInteger_1,
				_txtInteger_2,
				_txtInteger_3,
				_txtInteger_4
			});
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_0,
				_txtFloat_1
			});
			chkFields.AddRange(new CheckBox[] {
				_chkFields_0,
				_chkFields_1,
				_chkFields_2,
				_chkFields_3,
				_chkFields_4,
				_chkFields_5,
				_chkFields_6,
				_chkFields_12,
				_chkFields_13
			});
			optRecipeType.AddRange(new RadioButton[] {
				_optRecipeType_0,
				_optRecipeType_1,
				_optRecipeType_2,
				_optRecipeType_3
			});
			cmdNew.AddRange(new Button[] {
				_cmdNew_0,
				_cmdNew_1,
				_cmdNew_2
			});
			cmdMove.AddRange(new Button[] {
				_cmdMove_0,
				_cmdMove_1
			});
			TextBox tb = new TextBox();
			CheckBox cb = new CheckBox();
			RadioButton rb = new RadioButton();
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdNew) {
				bt = bt_loopVariable;
				bt.Click += cmdNew_Click;
			}
			foreach (Button bt_loopVariable in cmdMove) {
				bt = bt_loopVariable;
				bt.Click += cmdMove_Click;
			}
			foreach (RadioButton rb_loopVariable in optRecipeType) {
				rb = rb_loopVariable;
				rb.CheckedChanged += optRecipeType_CheckedChanged;
			}
			foreach (CheckBox cb_loopVariable in chkFields) {
				cb = cb_loopVariable;
				cb.CheckedChanged += chkFields_CheckStateChanged;
			}
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			foreach (TextBox tb_loopVariable in txtFloat) {
				tb = tb_loopVariable;
				tb.Enter += txtFloat_Enter;
				tb.KeyPress += txtFloat_KeyPress;
				tb.Leave += txtFloat_Leave;
			}
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.KeyPress += txtInteger_KeyPress;
				tb.Leave += txtInteger_Leave;
			}
			ChkC = true;
			//Serial Fla
			//For x = 1 To Frame1.UBound
			_Frame1_1.Left = _Frame1_2.Left == _Frame1_3.Left == _Frame1_0.Left;
			_Frame1_1.Top = _Frame1_2.Top == _Frame1_3.Top == _Frame1_0.Top;
			_Frame1_1.Height = _Frame1_2.Height == _Frame1_3.Height == _Frame1_0.Height;
			_Frame1_1.Width = _Frame1_2.Width == _Frame1_3.Width == _Frame1_0.Width;
			Frame1[x].Visible = false;
			Frame1[x].BringToFront();
			//Next
			TVMessage.ImageList = ILtree;
			TreeView1.ImageList = ILtree;

			//*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
			if (!string.IsNullOrEmpty(My.MyProject.Forms.frmStockList.DataList1.BoundText)) {
				modApplication.Holdquantity = -1;
			}

			loadLanguage();
		}

		private void loadLanguage()
		{
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1586
			//If rsLang.RecordCount Then frmStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
			//
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1009;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			//
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			if (modRecordSet.rsLang.RecordCount){_Frame2_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1011;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1012;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1013;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1014;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1015;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1016;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			if (modRecordSet.rsLang.RecordCount){_chkFields_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2465;
			if (modRecordSet.rsLang.RecordCount){_chkFields_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1017;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1018;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1019;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}


			//============================= New SourceCode ============================

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1020;
			//Groupings|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame2_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1021;
			//Pricing Grou|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1022;
			//Stock Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1023;
			//Report Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1024;
			//Pricing and Shrinks|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame2_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1025;
			//Sale Shrinks|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1026;
			//Suppliers Quantity|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1027;
			//List Cost|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_10.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_10.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1028;
			//Actual Cost|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1029;
			//Ordering Rules|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame2_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_chkFields_0 = NO CODE     [Check this box to exclude this Stock Item when using the Ordering Wizard]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_4 = NO CODE           [When the Stock goes below]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_5 = NO CODE           [units,]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = NO CODE           [Re-order a]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_7 = 1008 match with wrong case!
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1008;
			//Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1030;
			//Pricing Set|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame2_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//chkPriceSet = NO CODE      [This Item is parto f a Pricing Set]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): chkPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblPriceSet = NO CODE      [No Action]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): lblPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1031;
			//Parameters|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame2_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1032;
			//This is a scale Product|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1033;
			//This is a scale item Non Weight|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1034;
			//Allow Fractions|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1035;
			//Do not allow negative stock|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2453;
			//POS Price Override (SQ)|Checked
			if (modRecordSet.rsLang.RecordCount){chkSQ.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkSQ.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1037;
			//Serial Tracking|Checked
			if (modRecordSet.rsLang.RecordCount){Frame3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2362;
			//Yes|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Frame6 = NO CODE           []

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2362;
			//Yes|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 2455 needs a "&&" to display correctly!
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2455;
			//Shelf & Barcode Printing|Checked
			if (modRecordSet.rsLang.RecordCount){Frame5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2456;
			//Shelf|Checked
			if (modRecordSet.rsLang.RecordCount){chkshelf.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkshelf.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){chkbarcode.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkbarcode.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//============================= End Frame(1) ==============================

			//_optRecipeType_0 = NO CODE [Not a Bill Of Material]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _optRecipeType_0.Caption = rsLang("LanguageLayoutLnk_Description"): _optRecipeType_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_optRecipeType_1 = NO CODE [Production]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1043;
			//At time of Sale|Checked
			if (modRecordSet.rsLang.RecordCount){_optRecipeType_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optRecipeType_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_optRecipeType_3 = NO CODE [This product makes other products]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _optRecipeType_3.Caption = rsLang("LanguageLayoutLnk_Description"): _optRecipeType_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdPrint = NO CODE         [Print Bill of Material]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdPrint.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrint.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdRecipeAdd = NO CODE     [Add Stock Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdRecipeAdd.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRecipeAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//txtQuantity = NO CODE      []
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//============================= END Frame(2) ==============================

			//NOTE: DB Entry 1188 missing "<<" chars
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1188;
			//Checked
			if (modRecordSet.rsLang.RecordCount){cmdAllocate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAllocate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1047 = missing ">>" chars
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1047;
			//Checked
			if (modRecordSet.rsLang.RecordCount){cmdDeallocate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDeallocate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1048;
			//New Message|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdNew_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdNew_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1049;
			//New Child|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdNew_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdNew_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1050 Differs from current caption, but DB Grammar better!
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1050;
			//New Child from existing stock|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdNew_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdNew_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1051;
			//Move Up|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdMove_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdMove_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1052;
			//Move Down|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdMove_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdMove_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1053;
			//Delete Item|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//============================= End Frame(3) ==============================

			modRecordSet.rsHelp.Filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadLanguage_OLD()
		{
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1586
			//If rsLang.RecordCount Then frmStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
			//
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1009;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			//
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			if (modRecordSet.rsLang.RecordCount){_Frame2_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame2_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1011;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1012;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1013;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1014;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1015;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1016;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			if (modRecordSet.rsLang.RecordCount){_chkFields_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 2465;
			if (modRecordSet.rsLang.RecordCount){_chkFields_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1017;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1018;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1019;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}
			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1019;
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

		}

		//UPGRADE_WARNING: Event frmStockItem.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockItem_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			//UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			//UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmdNext.Left = sizeConvertors.twipsToPixels(lblStatus.Width + 700, true);
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdLast.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmdLast.Left = sizeConvertors.pixelToTwips(cmdNext.Left, true) + 340;
			//*
			//here a public function loaditems is called to loaditems in frmstockItem When frmpricesetlist unloads

			//frmStockItem.txtholdname.Text = frmStockItem._txtFields_7.Text

			if (!string.IsNullOrEmpty(modApplication.Holdvalue)) {
				loadItems();
				modApplication.Holdvalue = "";
			}
			//*
		}

		private void cmdDetails_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			cmdDetails.Focus();
			System.Windows.Forms.Application.DoEvents();

			lID = adoPrimaryRS.Fields("StockItemID").Value;
			this.Close();
			My.MyProject.Forms.frmStockPricing.loadItem(ref lID);
			My.MyProject.Forms.frmStockPricing.ShowDialog();
		}

		private void frmStockItem_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			update_Renamed();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			//*
			txttemphold.Text = this._txtFields_8.Text;
			modApplication.HoldP = txttemphold.Text;
			this.txttemphold.Text = "";

			//*
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void cmdRefresh_Click()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			adoPrimaryRS.Requery();
			return;
			RefreshErr:
			Interaction.MsgBox(Err().Description);
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox oText = new TextBox();
			 // ERROR: Not supported in C#: OnErrorStatement


			mbEditFlag = false;
			mbAddNewFlag = false;
			adoPrimaryRS.CancelUpdate();
			//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (mvBookMark > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				adoPrimaryRS.Bookmark = mvBookMark;
			} else {
				adoPrimaryRS.MoveFirst();
			}
			mbDataChanged = false;
			foreach (TextBox oText_loopVariable in this.txtInteger) {
				oText = oText_loopVariable;
				//txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
			}
			foreach (TextBox oText_loopVariable in this.txtFloat) {
				oText = oText_loopVariable;
				//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oText.Text = oText.Text * 100;
				//txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
			}
		}

		//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void update_Renamed()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			gUpdate = true;
			this.cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			ADODB.Recordset rs = default(ADODB.Recordset);


			if (_txtInteger_0.Text == "0")
				_txtInteger_0.Text = "1";
			if (cmbReorder.SelectedIndex) {
				_txtInteger_2.Text = _txtInteger_0.Text;
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItemOrderType = 1 WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");

			} else {
				_txtInteger_2.Text = Convert.ToString(1);
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItemOrderType = 0 WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
			}

			if (adoPrimaryRS.Fields("StockItem_ListCost").OriginalValue != adoPrimaryRS.Fields("StockItem_ListCost").Value) {
				rs = modRecordSet.getRS(ref "SELECT Company.Company_DayEndID FROM Company;");
				adoPrimaryRS.Fields("StockItem_LastCost").Value = rs.Fields(0).Value;
			}

			if (_chkFields_2.CheckState != Convert.ToDouble(_chkFields_2.Tag)) {
				modRecordSet.cnnDB.Execute("UPDATE Scale SET Scale.Scale_Update = True;");
			}
			//* Update Barcode and Shelf

			if (chkshelf.CheckState == 1 & chkbarcode.CheckState == 1) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = true WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = true WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");

			}


			if (chkshelf.CheckState == 0 & chkbarcode.CheckState == 0) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = false WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = false WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");

			}

			if (chkshelf.CheckState == 0)
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = false WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
			if (chkbarcode.CheckState == 0)
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = false WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");

			if (chkshelf.CheckState == 1)
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = true WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
			if (chkbarcode.CheckState == 1)
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = true WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
			//If OptPrint(0).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = 'shelf' WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
			//If OptPrint(1).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = 'barcode' WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
			//If OptPrint(2).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = NULL WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
			//*

			//New code to update serial tracker...
			//Code for...
			if (_chkFields_1.CheckState != Convert.ToDouble(_chkFields_1.Tag)) {
				if (adoPrimaryRS.Fields("StockItem_ShrinkID").Value == 1)
					modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_SerialTracker = " + _chkFields_1.CheckState + " WHERE StockItemID = " + adoPrimaryRS.Fields("StockItemID").Value + ";");
			}

			if (string.IsNullOrEmpty(cmbPriceSet.BoundText)) {
				//UPGRADE_ISSUE: VBControlExtender property cmbPriceSet.DataField is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
				cmbPriceSet.DataField = "";
			}

			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			adoPrimaryRS.Move(0);
			//move to the new record

			//UPGRADE_ISSUE: VBControlExtender property cmbPriceSet.DataField is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			cmbPriceSet.DataField = "StockItem_PriceSetID";

			modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" + adoPrimaryRS.Fields("StockItemID").Value + "));");

			if (gRSpriceSet == null) {
			} else {
				if (gRSpriceSet.Fields("StockItemID").Value == adoPrimaryRS.Fields("StockItemID").Value) {
					modRecordSet.cnnDB.Execute("UPDATE (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN StockItem AS StockItem_1 ON PriceSet.PriceSet_StockItemID = StockItem_1.StockItemID SET StockItem.StockItem_ShrinkID = [StockItem_1]![StockItem_ShrinkID], StockItem.StockItem_PricingGroupID = [StockItem_1]![StockItem_PricingGroupID], StockItem.StockItem_VatID = [StockItem_1]![StockItem_VatID], StockItem.StockItem_DepositID = [StockItem_1]![StockItem_DepositID], StockItem.StockItem_Quantity = [StockItem_1]![StockItem_Quantity], StockItem.StockItem_ListCost = [StockItem_1]![StockItem_ListCost] WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[StockItem_1]![StockItemID]) AND (StockItem_1.StockItemID)=" + adoPrimaryRS.Fields("StockitemID").Value + ");");
					modRecordSet.cnnDB.Execute("DELETE PropChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" + adoPrimaryRS.Fields("Stockitem_PriceSetID").Value + "));");
					modRecordSet.cnnDB.Execute("DELETE PriceChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" + adoPrimaryRS.Fields("Stockitem_PriceSetID").Value + "));");
					modRecordSet.cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT StockItem.StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON PriceSet.PriceSet_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" + adoPrimaryRS.Fields("Stockitem_PriceSetID").Value + "));");
					modRecordSet.cnnDB.Execute("INSERT INTO PropChannelLnk ( PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup ) SELECT StockItem.StockItemID, PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON PriceSet.PriceSet_StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" + adoPrimaryRS.Fields("Stockitem_PriceSetID").Value + "));");
					modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PriceSetID)=" + adoPrimaryRS.Fields("Stockitem_PriceSetID").Value + "));");

				}
			}

			modRecordSet.cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" + adoPrimaryRS.Fields("StockitemID").Value + "));");
			if (chkSQ.CheckState)
				modRecordSet.cnnDB.Execute("INSERT INTO StockitemOverwrite ( StockitemOverwriteID ) SELECT " + adoPrimaryRS.Fields("StockitemID").Value + ";");

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			gUpdate = false;
			modApplication.RecipeCost();

			return;
			UpdateErr:
			gUpdate = false;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			//* Check if Display name is empty and refuses to exit
			if (string.IsNullOrEmpty(Strings.Trim(this._txtFields_7.Text))) {
				Interaction.MsgBox("The Display Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
				this._txtFields_7.Focus();
				return;
			} else if (Information.IsNumeric(this._txtFields_7.Text) == true) {
				Interaction.MsgBox("The Display Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
				this._txtFields_7.Focus();
				return;
			} else if (string.IsNullOrEmpty(Strings.Trim(this._txtFields_8.Text))) {
				Interaction.MsgBox("The Receipt Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				// frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
				this._txtFields_8.Focus();
				return;
			} else if (Information.IsNumeric(this._txtFields_8.Text) == true) {
				Interaction.MsgBox("The Receipt Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details");
				//frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
				this._txtFields_8.Focus();
				return;
			}

			//*
			System.Windows.Forms.Application.DoEvents();
			this.Close();

			//*Display frmStockList
			//*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does

			//    If Holdquantity = 0 Or frmPriceSet.lblStockItem.Tag <> "" Then
			//    ElseIf Holdquantity = -1 Or frmPriceSet.lblStockItem.Tag <> "" Then
			//    frmStockList.editItem 0
			//    HoldP = frmStockItem.txttemphold.Text
			//    frmStockList.show 1
			//    End If

			//*

		}
		//Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFields);

			//If Index = 14 Then Index = 0
			//If Index = 0 Then Index = 14

			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		//Handles txtInteger.Enter
		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
			modUtilities.MyGotFocusNumeric(ref txtInteger[Index]);
		}

		//Handles txtInteger.KeyPress
		private void txtInteger_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtInteger.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtInteger.Leave
		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}

		//Handles txtFloat.Enter
		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFloat);
			modUtilities.MyGotFocusNumeric(ref txtFloat[Index]);
		}

		//Handles txtFloat.KeyPress
		private void txtFloat_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtFloat.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtFloat.Leave
		private void txtFloat_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}

		private void loadMessage()
		{
			System.Windows.Forms.TreeNode lNode = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT Message.* From Message ORDER BY Message.Message_Name;");
			RSitem = modRecordSet.getRS(ref "SELECT MessageItem.* From MessageItem ORDER BY MessageItem_Order;");
			//    On Local Error Resume Next
			TVMessage.Nodes.Clear();
			if (rs.RecordCount) {
				rs.MoveFirst();
				while (!(rs.EOF)) {
					lNode = TVMessage.Nodes.Add("m" + rs.Fields("MessageID").Value, rs.Fields("Message_Name").Value, 1);
					RSitem.Filter = "MessageItem_MessageID=" + rs.Fields("MessageID").Value;
					if (RSitem.RecordCount) {
						RSitem.MoveFirst();
						while (!(RSitem.EOF)) {
							//UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
							lNode = TVMessage.Nodes.Find("m" + rs.Fields("MessageID").Value, true)[0].Nodes.Add("i" + RSitem.Fields("MessageItemID").Value, RSitem.Fields("MessageItem_Name").Value, 2);
							RSitem.MoveNext();
						}
					}
					rs.MoveNext();
				}
			}
		}

		private void loadTree()
		{
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.TreeNode lNode = null;
			TreeView1.Nodes.Clear();
			TreeView1.Nodes.Add("m0", "Product", 3);
			deleteUnallocated();
			RSitem = modRecordSet.getRS(ref "SELECT MessageItem.* From MessageItem ORDER BY MessageItem_Order;");
			rs = modRecordSet.getRS(ref "SELECT Message.MessageID, Message.Message_Name, StockItemMessageLnk.* FROM Message INNER JOIN StockItemMessageLnk ON Message.MessageID = StockItemMessageLnk.StockItemMessageLnk_MessageID Where (((StockItemMessageLnk.StockItemMessageLnk_StockItemID) = " + gID + ")) ORDER BY StockItemMessageLnk.StockItemMessageLnk_ParentID, StockItemMessageLnk.StockItemMessageLnk_Level, StockItemMessageLnk.StockItemMessageLnk_Order;");
			while (!(rs.EOF)) {
				//UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
				lNode = TreeView1.Nodes.Find("m" + rs.Fields("StockItemMessageLnk_ParentID").Value, true)[0].Nodes.Add("m" + rs.Fields("StockItemMessageLnkID").Value, rs.Fields("Message_Name").Value, 1);
				//UPGRADE_WARNING: Couldn't resolve default property of object RSitem.filter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RSitem.filter = "MessageItem_MessageID=" + rs.Fields("MessageID").Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object RSitem.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (RSitem.RecordCount) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RSitem.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RSitem.MoveFirst();
					//UPGRADE_WARNING: Couldn't resolve default property of object RSitem.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					while (!(RSitem.EOF)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object RSitem(MessageItem_Name). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object RSitem(MessageItemID). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
						lNode = TreeView1.Nodes.Find("m" + rs.Fields("StockItemMessageLnkID").Value, true)[0].Nodes.Add("i" + RSitem("MessageItemID").Value + "_" + rs.Fields("StockItemMessageLnkID").Value, RSitem("MessageItem_Name").Value, 2);
						//UPGRADE_WARNING: Couldn't resolve default property of object RSitem.moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						RSitem.moveNext();
					}
				}
				rs.MoveNext();
			}
			TreeView1.Nodes["m0"].Expand();
			//UPGRADE_ISSUE: MSComctlLib.Node property TreeView1.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			TreeView1.Nodes["m0"].Checked = true;
		}
		private void deleteUnallocated()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT StockItemMessageLnk.StockItemMessageLnkID FROM StockItemMessageLnk AS StockItemMessageLnk_1 RIGHT JOIN StockItemMessageLnk ON (StockItemMessageLnk_1.StockItemMessageLnkID = StockItemMessageLnk.StockItemMessageLnk_ParentID) AND (StockItemMessageLnk_1.StockItemMessageLnk_StockItemID = StockItemMessageLnk.StockItemMessageLnk_StockItemID) WHERE (((StockItemMessageLnk_1.StockItemMessageLnkID) Is Null) AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)<>0));");
			while (rs.RecordCount) {
				modRecordSet.cnnDB.Execute("DELETE * FROM StockItemMessageLnk WHERE StockItemMessageLnkID=" + rs.Fields("StockItemMessageLnkID").Value);
				rs = modRecordSet.getRS(ref "SELECT StockItemMessageLnk.StockItemMessageLnkID FROM StockItemMessageLnk AS StockItemMessageLnk_1 RIGHT JOIN StockItemMessageLnk ON (StockItemMessageLnk_1.StockItemMessageLnkID = StockItemMessageLnk.StockItemMessageLnk_ParentID) AND (StockItemMessageLnk_1.StockItemMessageLnk_StockItemID = StockItemMessageLnk.StockItemMessageLnk_StockItemID) WHERE (((StockItemMessageLnk_1.StockItemMessageLnkID) Is Null) AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)<>0));");
			}

		}

		private void cmdDeallocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.TreeNode lNode = null;
			string lKey = null;
			if (TreeView1.SelectedNode == null) {
			} else {
				if (TreeView1.SelectedNode.Name != "m0") {
					lNode = TreeView1.SelectedNode;
					modRecordSet.cnnDB.Execute("DELETE StockItemMessageLnk.* From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnkID)=" + Strings.Mid(lNode.Name, 2) + "));");
					//UPGRADE_ISSUE: MSComctlLib.Node property Parent.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					//lNode.Parent.Selected = True
					lNode.Parent.Checked = true;
					TreeView1.Nodes.RemoveAt(lNode.Name);
				}
			}


		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (TVMessage.SelectedNode == null) {
			} else {
				if (Strings.Left(TVMessage.SelectedNode.Name, 1) == "i") {
					rs = modRecordSet.getRS(ref "SELECT MessageItem.MessageItemID FROM MessageItem AS MessageItem_1, MessageItem WHERE (((MessageItem_1.MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + ") AND ((MessageItem.MessageItem_Order)>[MessageItem_1]![MessageItem_Order]));");
					while (!(rs.EOF)) {
						modRecordSet.cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" + rs.Fields("MessageItemID").Value + "));");
						rs.MoveNext();
					}
					modRecordSet.cnnDB.Execute("DELETE MessageItem.* From MessageItem WHERE (((MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");
				} else {
					modRecordSet.cnnDB.Execute("DELETE MessageItem.* From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");
					modRecordSet.cnnDB.Execute("DELETE Message.* From Message WHERE (((Message.MessageID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");
					modRecordSet.cnnDB.Execute("DELETE StockItemMessageLnk.* From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnk_MessageID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");
					loadTree();
				}
				//UPGRADE_WARNING: MSComctlLib.Nodes method TVMessage.Nodes.Remove has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				TVMessage.Nodes.RemoveAt((TVMessage.SelectedNode.Name));

			}
		}

		//Handles cmdMove.Click
		private void cmdMove_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdMove);
			 // ERROR: Not supported in C#: OnErrorStatement

			string lKey = null;
			lKey = TVMessage.SelectedNode.Name;
			if (Strings.Left(lKey, 1) == "i") {
				if (Index) {
					if (TVMessage.SelectedNode.LastNode.Name == TVMessage.SelectedNode.Name) {
						return;
					} else {
						modRecordSet.cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.NextNode.Name, 2) + "));");
						modRecordSet.cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]+1 WHERE (((MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");

					}
				} else {
					if (TVMessage.SelectedNode.FirstNode.Name == TVMessage.SelectedNode.Name) {
						return;
					} else {
						modRecordSet.cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]+1 WHERE (((MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.PrevNode.Name, 2) + "));");
						modRecordSet.cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" + Strings.Mid(TVMessage.SelectedNode.Name, 2) + "));");
					}
				}
				TVMessage.Visible = false;
				loadMessage();
				//UPGRADE_ISSUE: MSComctlLib.Node property TVMessage.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TVMessage.Nodes[lKey].Checked = true;
				TVMessage.Visible = true;
			}
		}

		//Handles cmdNew.Click
		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button txt = new Button();
			txt = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref cmdNew);
			int lIndex = 0;
			string lString = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.TreeNode lNode = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object lIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lIndex = 0;
			if (Index == 1) {
				if (TVMessage.SelectedNode == null) {
				} else {
					if (Strings.Left(TVMessage.SelectedNode.Name, 1) == "m")
						lNode = TVMessage.SelectedNode;
					else
						lNode = TVMessage.SelectedNode.Parent;

					lString = Interaction.InputBox("Enter Child Message Description for '" + lNode.Text + "'.", "NEW CHILD MESSAGE");
					if (!string.IsNullOrEmpty(lString)) {
						rs = modRecordSet.getRS(ref "SELECT MessageItem.MessageItem_MessageID From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" + Strings.Mid(lNode.Name, 2) + "));");
						modRecordSet.cnnDB.Execute("INSERT INTO MessageItem ( MessageItem_MessageID, MessageItem_Name, MessageItem_Order ) SELECT " + Strings.Mid(lNode.Name, 2) + ", '" + Strings.Replace(lString, "'", "''") + "', " + rs.RecordCount + 1 + ";");
						rs = modRecordSet.getRS(ref "SELECT Max(MessageItemID) AS MaxOfMessageID FROM MessageItem;");
						lNode = TVMessage.Nodes.Find(lNode.Name, true)[0].Nodes.Add("i" + rs.Fields(0).Value, lString, 2);
						lNode.Expand();
						TVMessage.SelectedNode = lNode;
					}
				}

			} else if (Index == 2) {
				if (TVMessage.SelectedNode == null) {
				} else {
					if (Strings.Left(TVMessage.SelectedNode.Name, 1) == "m")
						lNode = TVMessage.SelectedNode;
					else
						lNode = TVMessage.SelectedNode.Parent;

					if (My.MyProject.Forms.frmStockChildMessage.makeItem(ref Convert.ToInt32(Strings.Mid(lNode.Name, 2))) == false) {
					} else {
						//lString = InputBox("Enter Child Message Description for '" & lNode.Text & "'.", "NEW CHILD MESSAGE")
						//If lString <> "" Then
						//Set rs = getRS("SELECT MessageItem.MessageItem_MessageID From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" & Mid(lNode.Key, 2) & "));")
						//cnnDB.Execute "INSERT INTO MessageItem ( MessageItem_MessageID, MessageItem_Name, MessageItem_Order ) SELECT " & Mid(lNode.Key, 2) & ", '" & Replace(lString, "'", "''") & "', " & rs.RecordCount + 1 & ";"
						rs = modRecordSet.getRS(ref "SELECT Max(MessageItemID) AS MaxOfMessageID FROM MessageItem;");
						rs = modRecordSet.getRS(ref "SELECT * FROM MessageItem WHERE MessageItemID = " + rs.Fields(0).Value + ";");
						lNode = TVMessage.Nodes.Find(lNode.Name, true)[0].Nodes.Add("i" + rs.Fields(0).Value, rs.Fields(2).Value, 2);
						lNode.Expand();
						TVMessage.SelectedNode = lNode;
						//End If
					}
				}

			} else if (Index == 0) {
				lString = Interaction.InputBox("Enter Message Description", "NEW MESSAGE");
				if (!string.IsNullOrEmpty(lString)) {
					modRecordSet.cnnDB.Execute("INSERT INTO Message ( Message_Name, Message_Type ) SELECT '" + Strings.Replace(lString, "'", "''") + "', 0");
					rs = modRecordSet.getRS(ref "SELECT Max(Message.MessageID) AS MaxOfMessageID FROM Message;");
					TVMessage.Nodes.Add("m" + rs.Fields(0).Value, lString, 1);
					TVMessage.SelectedNode = TVMessage.Nodes["m" + rs.Fields(0).Value];
				}
			}
		}

		private void cmdAllocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short lOrder = 0;
			short lLevel = 0;
			System.Windows.Forms.TreeNode lNode = null;
			string lKey = null;
			lNode = TreeView1.SelectedNode;
			 // ERROR: Not supported in C#: OnErrorStatement

			lKey = lNode.Name;

			if (Interaction.MsgBox("Are you sure you wish to make '" + this.TVMessage.SelectedNode.Text + "' a child of '" + TreeView1.SelectedNode.Text + "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "CREATE ALLOCATION") == MsgBoxResult.Yes) {
				while (!(lNode.Name == "m0")) {
					lLevel = lLevel + 1;
					lNode = lNode.Parent;
				}
				rs = modRecordSet.getRS(ref "SELECT StockItemMessageLnk.StockItemMessageLnk_StockItemID From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnk_StockItemID)=" + gID + ") AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)=0));");
				lOrder = rs.RecordCount + 1;
				lNode = TreeView1.SelectedNode;
				modRecordSet.cnnDB.Execute("INSERT INTO StockItemMessageLnk ( StockItemMessageLnk_StockItemID, StockItemMessageLnk_MessageID, StockItemMessageLnk_ParentID, StockItemMessageLnk_Order, StockItemMessageLnk_Level ) SELECT " + gID + " AS lID, " + Strings.Mid(this.TVMessage.SelectedNode.Name, 2) + " AS mess, " + Strings.Mid(TreeView1.SelectedNode.Name, 2) + " AS parent, " + lOrder + " AS ord, " + lLevel + ";");
				if (Err().Number) {
				} else {
					loadTree();
					//UPGRADE_ISSUE: MSComctlLib.Node property TreeView1.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					TreeView1.Nodes[lKey].Checked = true;
					TreeView1.Nodes[lKey].Expand();
				}
			}
		}
		public object barcodeItem()
		{
			//*
			//DoEvents
			My.MyProject.Forms.frmStockBarcode.loadItem(ref adoPrimaryRS.Fields("StockItemID").Value);
			frmStockBarcode frm = new frmStockBarcode();
			frm.Show();

		}
		public object Duplicate_codes_report()
		{
			// cmdDuplicate.SetFocus
			System.Windows.Forms.Application.DoEvents();
			adoPrimaryRS.Move(0);
			update_Renamed();
			modApplication.report_StockItemDuplicateCodes();
		}
		public object loadItems()
		{
			int id = 0;

			//* Loads information on frmstockitem when frmpricesetlist unloads

			string sql = null;
			string InSt = null;
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.ListViewItem lItem = null;
			System.Windows.Forms.CheckBox oCheck = null;
			ADODB.Recordset rsj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string InStc = null;
			string d_Sold = null;
			short j = 0;
			string sql1 = null;
			ADODB.Recordset rsN = default(ADODB.Recordset);
			string Insk = null;
			ADODB.Recordset Rsp1 = default(ADODB.Recordset);
			ADODB.Recordset rsSerial = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			id = adoPrimaryRS.Fields("StockItemID").Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs = modRecordSet.getRS(ref "SELECT StockitemOverwrite.StockitemOverwriteID From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" + id + "));");
			//If Not rs Is Nothing Then Me.chkSQ.value = 1 Else chkSQ.value = 0
			if (rs.RecordCount)
				this.chkSQ.CheckState = System.Windows.Forms.CheckState.Checked;
			else
				chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked;
			rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID = " + id);

			if (adoPrimaryRS.BOF | adoPrimaryRS.EOF) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gID = id;
				if (adoPrimaryRS.Fields("StockItem_OrderQuantity").Value == adoPrimaryRS.Fields("StockItem_Quantity").Value) {
					this.cmbReorder.SelectedIndex = 1;
				} else {
					this.cmbReorder.SelectedIndex = 0;
				}
				if (adoPrimaryRS.Fields("StockItemOrderType").Value == 1)
					this.cmbReorder.SelectedIndex = 1;
				else
					this.cmbReorder.SelectedIndex = 0;

				foreach (TextBox oText_loopVariable in this.txtFields) {
					oText = oText_loopVariable;
					//UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					oText.DataBindings.Add(adoPrimaryRS);
					//UPGRADE_ISSUE: TextBox property oText.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					//UPGRADE_WARNING: TextBox property oText.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
				}
				foreach (TextBox oText_loopVariable in this.txtInteger) {
					oText = oText_loopVariable;
					//UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					oText.DataBindings.Add(adoPrimaryRS);
					//txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
				}
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					//UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					oText.DataBindings.Add(adoPrimaryRS);
					oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
					//txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
				}
				//Bind the check boxes to the data provider
				foreach (CheckBox oCheck_loopVariable in this.chkFields) {
					oCheck = oCheck_loopVariable;
					//UPGRADE_ISSUE: CheckBox property oCheck.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					oCheck.DataBindings.Add(adoPrimaryRS);
					oCheck.Tag = oCheck.CheckState;
				}
				buildDataControls();

				if (string.IsNullOrEmpty(cmbPriceSet.BoundText)) {
					chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else {
					chkPriceSet.CheckState = System.Windows.Forms.CheckState.Checked;
				}

				//New Serial Tracker Code.....
				if (adoPrimaryRS.Fields("StockItem_SerialTracker").Value)
					_chkFields_1.Tag = 1;
				else
					_chkFields_1.Tag = 0;

				//Shelf & Barcode printing
				//If IsNull(adoPrimaryRS("StockItem_SBarcode")) Then
				//    OptPrint(2).value = True
				if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == true) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Checked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Checked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == true & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false) {
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked;
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false & Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) == false) {
					chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;

				} else if (Convert.ToBoolean(Strings.LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) == false) {
					chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
				}


				mbDataChanged = false;
				var _with6 = FGRecipe;
				_with6.Visible = false;
				_with6.RowCount = 1;
				_with6.ColumnCount = 4;
				_with6.Col = 0;
				_with6.row = 0;
				_with6.Text = "Product";
				_with6.set_ColAlignment(0, 1);
				_with6.set_ColWidth(0, 2000);
				_with6.CellFontBold = true;
				_with6.Col = 1;
				_with6.Text = "Total Cost";
				_with6.set_ColAlignment(1, 7);
				_with6.set_ColWidth(1, 1000);
				_with6.CellFontBold = true;
				_with6.Col = 2;
				_with6.Text = "Quantity";
				_with6.set_ColAlignment(2, 7);
				_with6.set_ColWidth(2, 750);
				_with6.CellFontBold = true;
				_with6.Col = 3;
				_with6.Text = "Line Cost";
				_with6.set_ColAlignment(3, 7);
				_with6.set_ColWidth(3, 1000);
				_with6.CellFontBold = true;
				_with6.Visible = !this._optRecipeType_0.Checked;

				if (string.IsNullOrEmpty(_txtFields_1.Text))
					_txtFields_1.Text = Convert.ToString(0);

				optRecipeType[Convert.ToInt16(_txtFields_1.Text)].Checked = true;
				loadRecipe();

				loadMessage();
				loadTree();

				//Assing serial number
				//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sql = "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " + id;

				if (adoPrimaryRS.Fields("StockItem_SerialTracker").Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rsSerial = modRecordSet.getRS(ref "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " + id);

					//Get serial Details...
					if (rsSerial.RecordCount > 0) {
						while (rsSerial.EOF == false) {
							lItem = lstvSerial.Items.Add(rsSerial.Fields("Serial_SerialNumber").Value);
							if (Rsp1.RecordCount > 0) {
								lItem.SubItems.Add(rsSerial.Fields("Serial_SupplierName").Value);
							} else {
								lItem.SubItems.Add("Default Suppier");
							}
							lItem.SubItems.Add(rsSerial.Fields("Serial_DatePurchases").Value);
							//If rsSerial("Serial_Instock") = True Then
							if (rsSerial.Fields("Serial_Instock").Value == true | rsSerial.Fields("Serial_Status").Value == "Returned") {
								InStc = "No";
								d_Sold = Conversion.Str(rsSerial.Fields("Serial_DateSold").Value);
								Insk = rsSerial.Fields("Serial_InvoiceNumber").Value;
							} else {
								InStc = "Yes";
							}
							lItem.SubItems.Add(InStc);
							lItem.SubItems.Add(d_Sold);
							lItem.SubItems.Add(Insk);
							d_Sold = "";
							Insk = "";

							rsSerial.MoveNext();
						}
						cmbShrink.Enabled = false;
					}
				}

				//Stock item found
			}


			//*
		}
	}
}
