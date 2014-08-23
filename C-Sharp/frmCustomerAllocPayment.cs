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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmCustomerAllocPayment : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord -= adoPrimaryRS_WillChangeRecord;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord += adoPrimaryRS_WillChangeRecord;
				}
			}
		}
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;

		short gMonthEnd;
		bool gLoading;

		bool bSelectPayment;
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();

		List<CheckBox> chkFields = new List<CheckBox>();
		private void loadLanguage()
		{

			//frmCustomerAllocPayment = No Code  [Payment Allocation]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCustomerAllocPayment.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerAllocPayment.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1188;
			//Allocate|Checked
			if (modRecordSet.rsLang.RecordCount){cmdShowHistory.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdShowHistory.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdInv.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdInv.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1282;
			//Statement|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStatement.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStatement.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1284;
			//Invoice Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1285;
			//Department|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1286;
			//Responsible Person Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1287;
			//Surname|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1319;
			//Financials|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1293;
			//Credit Limit|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1295;
			//Current|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1297;
			//60 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1299;
			//120 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_17.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_17.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1294;
			//Terms|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1296;
			//30 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1298;
			//90 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1300;
			//150 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_18.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_18.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_7 = No Code                   [Payments]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(17).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(8) = No Code                   [Invoices - Unallocated]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(9) = No Code                   [Invoices - Allocated]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdAllocateFull = No Code          [Allocate Full Payment]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdAllocateFull.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAllocateFull.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdAllocate = No Code              [Allocate Partial]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdAllocate.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAllocate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCustomerAllocPayment.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			string sql = null;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();
			short x = 0;
			string tmp = null;
			//If openConnection() Then
			//    frmMain.lblPath.Caption = serverPath
			//    closeConnection
			//End If

			cn = modRecordSet.openConnectionInstance();
			if (cn == null) {
				this.Close();
				return;
			} else {

				sql = "SELECT Company.Company_MonthEndID FROM Company;";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				gMonthEnd = rs.Fields("Company_MonthEndID").Value;
				cmbMonth.Items.Add(new LBI("This Month", gMonthEnd));

				for (x = 2; x <= gMonthEnd; x++) {
					tmp = (x - 1).ToString() + " Months Ago";
					cmbMonth.Items.Add(new LBI(tmp, gMonthEnd - x + 1));
				}
				cmbMonth.SelectedIndex = 0;

				cmbPOS.Items.Add(new LBI("[All Point Of Sale]", 0));
				for (x = 1; x <= 12; x++) {
					tmp = "Point of Sale " + x.ToString();
					cmbPOS.Items.Add(new LBI(tmp, x));
				}
				cmbPOS.SelectedIndex = 0;
			}

			cmdsearch_Click_Payment();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			cmdsearch_Click_Alloc();
			cmdAllocate.Focus();
		}

		private void cmdAllocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			decimal tempAmount = default(decimal);
			//On Error Resume Next
			ADODB.Connection cn = default(ADODB.Connection);
			short x = 0;
			string databaseName = null;
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			decimal cAlloc = default(decimal);
			//Screen.MousePointer = vbHourglass

			if (lvPayment.FocusedItem == null) {
				Interaction.MsgBox("Select Payment to Allocate!");
				return;
			}

			if (lvTransaction.FocusedItem == null) {
				Interaction.MsgBox("Select Invoice to be Allocate!");
				return;
			}


			if ((0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text)) > 0) {

				if (Interaction.MsgBox("Are you sure you wish to Allocate " + Constants.vbCrLf + Constants.vbCrLf + lvPayment.FocusedItem.SubItems[2].Text + " | " + lvPayment.FocusedItem.Text + " | " + lvPayment.FocusedItem.SubItems[1].Text + " | R " + lvPayment.FocusedItem.SubItems[6].Text + Constants.vbCrLf + Constants.vbCrLf + " TO " + Constants.vbCrLf + Constants.vbCrLf + lvTransaction.FocusedItem.SubItems[2].Text + " | " + lvTransaction.FocusedItem.Text + " | " + lvTransaction.FocusedItem.SubItems[1].Text + " | R " + lvTransaction.FocusedItem.SubItems[6].Text, MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					tempAmount = 0;
					tempAmount = My.MyProject.Forms.frmCustomerAllocPaymentAmount.getAmount(ref Convert.ToDecimal(lvPayment.FocusedItem.SubItems[6].Text));

					if (Convert.ToDecimal(tempAmount) == Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
						tempAmount = Convert.ToDecimal(tempAmount);
					} else if (Convert.ToDecimal(tempAmount) > Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
						tempAmount = Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text);
					} else if (Convert.ToDecimal(tempAmount) < Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
						tempAmount = Convert.ToDecimal(tempAmount);
					}

					sql = "INSERT INTO CustomerTransactionAlloc ( CustomerTransactionAlloc_CustomerID, CustomerTransactionAlloc_MainID, CustomerTransactionAlloc_ChildID, CustomerTransactionAlloc_Date, CustomerTransactionAlloc_Description, CustomerTransactionAlloc_Amount, CustomerTransactionAlloc_Reference, CustomerTransactionAlloc_PersonName )";
					//sql = sql & "SELECT " & adoPrimaryRS("CustomerID") & " AS Customer, " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & " AS cID, #" & Now() & "# AS [Datea], 'Allocations' AS Descs, " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
					sql = sql + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, " + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + " AS mID, " + Strings.Replace(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[0], "K", "") + " AS cID, #" + DateAndTime.Now + "# AS [Datea], 'Allocations' AS Descs, " + Convert.ToDecimal(tempAmount) + " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" + Convert.ToDecimal(0 - tempAmount) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + "));");
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = " + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" + Convert.ToDecimal(tempAmount) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + Strings.Replace(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[0], "K", "") + "));");
				}
			} else {
				Interaction.MsgBox("Insufficient funds.");
				return;
			}

			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();

			//If MsgBox("Are you sure you wish to Allocate " & vbCrLf & vbCrLf & lvPayment.SelectedItem.SubItems(2) & " | " & lvPayment.SelectedItem & " | " & lvPayment.SelectedItem.SubItems(1) & " | R " & lvPayment.SelectedItem.SubItems(4) & vbCrLf & vbCrLf & " TO " & vbCrLf & vbCrLf & lvTransaction.SelectedItem.SubItems(2) & " | " & lvTransaction.SelectedItem & " | " & lvTransaction.SelectedItem.SubItems(1) & " | R " & lvTransaction.SelectedItem.SubItems(3), vbYesNo) = vbYes Then
			//    'aC = InputBox("Please enter the amount you with to Allocate.", "Please enter the amount you with to Allocate.", FormatNumber((0 - lvPayment.SelectedItem.SubItems(4)), 2))
			//
			//
			//    If IsNumeric(aC) Then
			//        cAlloc = aC
			//    Else
			//        MsgBox "Enter the correct amount."
			//    End If
			//    If cAlloc > 0 Then
			//
			//    Else
			//        MsgBox "Enter the correct amount."
			//    End If
			//End If
			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();
		}

		private void cmdAllocateFull_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object tempAmount = null;
			//On Error Resume Next
			ADODB.Connection cn = default(ADODB.Connection);
			short x = 0;
			string databaseName = null;
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			decimal cAlloc = default(decimal);
			//Screen.MousePointer = vbHourglass

			if (lvPayment.FocusedItem == null) {
				Interaction.MsgBox("Select Payment to Allocate!");
				return;
			}

			if (lvTransaction.FocusedItem == null) {
				Interaction.MsgBox("Select Invoice to be Allocated!");
				return;
			}

			//If Split(Me.lvTransaction.SelectedItem.Key, "_")(2) = 0 Then MsgBox "There is no Sale document attached!", vbInformation: Screen.MousePointer = vbNormal: Exit Sub
			//lID = Split(Me.lvTransaction.SelectedItem.Key, "_")(2)
			tempAmount = 0;
			if (Convert.ToDecimal(0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text)) == Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
				tempAmount = Convert.ToDecimal(0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text));
			} else if (Convert.ToDecimal(0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text)) > Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
				tempAmount = Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text);
			} else if (Convert.ToDecimal(0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text)) < Convert.ToDecimal(lvTransaction.FocusedItem.SubItems[6].Text)) {
				tempAmount = Convert.ToDecimal(0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text));
			}

			if ((0 - Convert.ToDouble(lvPayment.FocusedItem.SubItems[6].Text)) > 0) {
				//If (0 - lvPayment.SelectedItem.SubItems(6)) >= lvTransaction.SelectedItem.SubItems(6) Then
				if (Interaction.MsgBox("Are you sure you wish to Allocate " + Constants.vbCrLf + Constants.vbCrLf + lvPayment.FocusedItem.SubItems[2].Text + " | " + lvPayment.FocusedItem.Text + " | " + lvPayment.FocusedItem.SubItems[1].Text + " | R " + lvPayment.FocusedItem.SubItems[6].Text + Constants.vbCrLf + Constants.vbCrLf + " TO " + Constants.vbCrLf + Constants.vbCrLf + lvTransaction.FocusedItem.SubItems[2].Text + " | " + lvTransaction.FocusedItem.Text + " | " + lvTransaction.FocusedItem.SubItems[1].Text + " | R " + lvTransaction.FocusedItem.SubItems[6].Text, MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					sql = "INSERT INTO CustomerTransactionAlloc ( CustomerTransactionAlloc_CustomerID, CustomerTransactionAlloc_MainID, CustomerTransactionAlloc_ChildID, CustomerTransactionAlloc_Date, CustomerTransactionAlloc_Description, CustomerTransactionAlloc_Amount, CustomerTransactionAlloc_Reference, CustomerTransactionAlloc_PersonName )";
					//sql = sql & "SELECT " & adoPrimaryRS("CustomerID") & " AS Customer, " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & " AS cID, #" & Now() & "# AS [Datea], 'Allocations' AS Descs, " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
					sql = sql + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, " + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + " AS mID, " + Strings.Replace(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[0], "K", "") + " AS cID, #" + DateAndTime.Now + "# AS [Datea], 'Allocations' AS Descs, " + Convert.ToDecimal(tempAmount) + " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" + Convert.ToDecimal(0 - tempAmount) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + "));");
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = " + Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "") + ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" + Convert.ToDecimal(tempAmount) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + Strings.Replace(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[0], "K", "") + "));");
				}
			} else {
				Interaction.MsgBox("Insufficient funds.");
				return;
			}

			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();

			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();
		}

		private void cmdInv_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			int personID = 0;
			int posID = 0;
			string[] lArray = null;
			string lAddress = null;

			//On Error Resume Next
			ADODB.Connection cn = default(ADODB.Connection);
			short x = 0;
			string databaseName = null;
			int lID = 0;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			if (lvTransaction.FocusedItem == null)
				return;
			//lID = Mid(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), 2)
			if (Convert.ToDouble(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[2]) == 0) {
				Interaction.MsgBox("There is no Sale document attached!", MsgBoxStyle.Information);
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				return;
			}
			lID = Convert.ToInt32(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[2]);
			//If openConnection() Then
			//    frmMain.lblPath.Caption = serverPath
			//    closeConnection
			//End If
			//Set cn = openConnectionInstance()
			//lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
			//Dim lLineitem As lineitem
			//If lMonth = gMonthEnd Then
			//    databaseName = ""
			//Else
			//    databaseName = "Month" & lMonth & ".mdb"
			//End If
			databaseName = Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[1];

			cn = modRecordSet.openConnectionInstance(ref databaseName);
			if (cn == null) {
				return;
			}

			transaction lTransaction = new transaction();
			lineItem lLineitem = null;
			customer lCustomer = new customer();
			transactionSpecial lSpecial = new transactionSpecial();
			if (Convert.ToDouble(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[3]) == 2) {
				//sale
				//Dim Report As New cryReceipt
				//Set Report = New cryReceipt

				rs = new ADODB.Recordset();
				sql = "SELECT Sale.* From Sale WHERE (((SaleID)=" + lID + "));";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

				if (rs.RecordCount) {
					lTransaction.cashierID = rs.Fields("Sale_PersonID").Value;
					lTransaction.channelID = rs.Fields("Sale_ChannelID").Value;
					lTransaction.managerID = rs.Fields("Sale_ManagerID").Value;
					lTransaction.paymentDiscount = rs.Fields("Sale_Discount").Value;
					lTransaction.paymentSlip = rs.Fields("Sale_Slip").Value;
					lTransaction.paymentSubTotal = rs.Fields("Sale_SubTotal").Value;
					lTransaction.paymentTender = rs.Fields("Sale_Tender").Value;
					lTransaction.paymentTotal = rs.Fields("Sale_Total").Value;
					lTransaction.paymentType = rs.Fields("Sale_PaymentType").Value;
					lTransaction.posID = rs.Fields("Sale_POSID").Value;
					lTransaction.transactionDate = rs.Fields("Sale_DatePOS").Value;
					lTransaction.transactionID = rs.Fields("Sale_Reference").Value + "";
					lTransaction.transactionType = "Sale";
					//If prPrevSerial_p = True Then strSerial = rs("Sale_Serialref")
					rs.Close();

					rs = modRecordSet.getRS(ref "SELECT * FROM Company");
					lTransaction.companyName = rs.Fields("Company_Name").Value;
					//gParameters.companyName
					lTransaction.footer = " ";
					//gParameters.footer & ""
					lTransaction.heading1 = rs.Fields("Company_PhysicalAddress").Value;
					//gParameters.heading1 & ""
					lTransaction.heading2 = " ";
					//gParameters.heading2 & ""
					lTransaction.heading3 = " ";
					//gParameters.heading3 & ""
					lTransaction.taxNumber = rs.Fields("Company_TaxNumber").Value;
					//gParameters.taxNumber & ""
					rs.Close();


					sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" + lTransaction.cashierID + "));";
					rs = modRecordSet.getRS(ref sql);
					//rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
					if (rs.RecordCount) {
						lTransaction.cashierName = rs.Fields("personName").Value + "";
					}
					rs.Close();

					sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" + lTransaction.managerID + "));";
					rs = modRecordSet.getRS(ref sql);
					//rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
					if (rs.RecordCount) {
						lTransaction.managerName = rs.Fields("personName").Value + "";
					}
					rs.Close();

					sql = "SELECT POS_Name From POS WHERE (((POS.POSID)=" + lTransaction.posID + "));";
					rs = modRecordSet.getRS(ref sql);
					//rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
					if (rs.RecordCount) {
						lTransaction.posName = rs.Fields("POS_Name").Value + "";
					}
					rs.Close();

					//sql = "SELECT SaleItem.*, StockItem.StockItem_Name AS longName, StockItem.StockItem_ReceiptName AS receiptName, Catalogue.Catalogue_Barcode AS code,'Sale' as saleType FROM (StockItem INNER JOIN SaleItem ON StockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN Catalogue ON (Catalogue.Catalogue_Quantity = SaleItem.SaleItem_ShrinkQuantity) AND (SaleItem.SaleItem_StockItemID = Catalogue.Catalogue_StockItemID) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_SaleID)=" & lID & "))"
					//sql = sql & " UNION "
					//sql = sql & "SELECT SaleItem.*, Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code,'Deposit' as saleType FROM Deposit INNER JOIN SaleItem ON Deposit.DepositID = SaleItem.SaleItem_StockItemID WHERE (((SaleItem.SaleItem_DepositType)<>0) AND ((SaleItem.SaleItem_SaleID)=" & lID & "));"
					sql = "SELECT SaleItem.*, 'Sale' AS saleType From SaleItem Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_SaleID) = " + lID + "))";
					sql = sql + " UNION ";
					sql = sql + "SELECT SaleItem.*, 'Deposit' AS saleType From SaleItem WHERE (((SaleItem.SaleItem_DepositType)<>0) AND ((SaleItem.SaleItem_SaleID)=" + lID + "));";
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					while (!(rs.EOF)) {
						lLineitem = new lineItem();
						lLineitem.build = 0;
						lLineitem.depositType = rs.Fields("SaleItem_DepositType").Value;
						lLineitem.id = rs.Fields("SaleItem_StockItemID").Value;
						lLineitem.lineNo = rs.Fields("SaleItem_LineNo").Value;
						lLineitem.originalPrice = rs.Fields("SaleItem_PriceOriginal").Value;
						lLineitem.price = rs.Fields("SaleItem_Price").Value;
						lLineitem.quantity = rs.Fields("SaleItem_Quantity").Value;
						lLineitem.reversal = rs.Fields("SaleItem_Reversal").Value;
						lLineitem.revoke = rs.Fields("SaleItem_Revoke").Value;
						lLineitem.setBuild = rs.Fields("SaleItem_SetID").Value;
						lLineitem.shrink = rs.Fields("SaleItem_ShrinkQuantity").Value;
						lLineitem.vat = rs.Fields("SaleItem_Vat").Value;
						lLineitem.transactionType = rs.Fields("SaleType").Value + "";
						//lLineitem.code = rs("Code") & ""
						switch (lLineitem.depositType) {
							case 0:
								sql = "SELECT StockItem.StockItem_Name AS longName, StockItem.StockItem_ReceiptName AS receiptName From StockItem WHERE (((StockItemID)=" + rs.Fields("SaleItem_StockItemID").Value + "));";
								rsItems = modRecordSet.getRS(ref sql);
								if (rsItems.RecordCount) {
									lLineitem.name = rs.Fields("SaleItem_ShrinkQuantity").Value + " x " + rsItems.Fields("longName").Value;
									lLineitem.receiptName = rs.Fields("SaleItem_ShrinkQuantity").Value + "x" + rsItems.Fields("receiptName").Value;
								}
								rsItems.Close();
								sql = "SELECT Catalogue.Catalogue_Barcode AS code FROM Catalogue WHERE (Catalogue.Catalogue_Quantity = " + rs.Fields("SaleItem_ShrinkQuantity").Value + ") AND (Catalogue.Catalogue_StockItemID = " + rs.Fields("SaleItem_StockItemID").Value + ");";
								rsItems = modRecordSet.getRS(ref sql);
								if (rsItems.RecordCount) {
									lLineitem.code = rsItems.Fields("Code").Value + "";
								}
								rsItems.Close();
								break;
							case 1:
								sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" + rs.Fields("SaleItem_StockItemID").Value + "));";
								rsItems = modRecordSet.getRS(ref sql);
								if (rsItems.RecordCount) {
									lLineitem.name = rs.Fields("longName").Value + "-Unit";
									lLineitem.receiptName = rs.Fields("receiptName").Value + "(U)";
									lLineitem.code = rsItems.Fields("Code").Value + "";
								}
								rsItems.Close();
								break;
							case 2:
								sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" + rs.Fields("SaleItem_StockItemID").Value + "));";
								rsItems = modRecordSet.getRS(ref sql);
								if (rsItems.RecordCount) {
									lLineitem.name = rs.Fields("longName").Value + "-Empty Crate";
									lLineitem.receiptName = rs.Fields("receiptName").Value + "(E)";
									lLineitem.code = rsItems.Fields("Code").Value + "";
								}
								rsItems.Close();
								break;
							case 3:
								sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" + rs.Fields("SaleItem_StockItemID").Value + "));";
								rsItems = modRecordSet.getRS(ref sql);
								if (rsItems.RecordCount) {
									lLineitem.name = rs.Fields("longName").Value + "-Full Case";
									lLineitem.receiptName = rs.Fields("receiptName").Value + "(F)";
									lLineitem.code = rsItems.Fields("Code").Value + "";
								}
								rsItems.Close();
								break;
						}
						lTransaction.lineItems.Add(ref lLineitem);
						rs.MoveNext();
					}
					rs.Close();

					sql = "SELECT Customer.*, CustomerTransaction.* FROM (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID WHERE (((Sale.SaleID)=" + lID + "));";
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					if (rs.RecordCount) {
						lCustomer.channelID = lTransaction.channelID;
						lCustomer.creditLimit = rs.Fields("Customer_ChannelID").Value;
						lCustomer.department = rs.Fields("Customer_DepartmentName").Value + "";
						lCustomer.fax = rs.Fields("Customer_Fax").Value + "";
						lCustomer.Key = rs.Fields("CustomerID").Value;
						lCustomer.name = rs.Fields("Customer_InvoiceName").Value + "";
						lCustomer.outstanding = 0;
						lCustomer.person = rs.Fields("Customer_FirstName").Value + " " + rs.Fields("Customer_Surname").Value;
						lCustomer.physical = rs.Fields("Customer_PhysicalAddress").Value + "";
						lCustomer.postal = rs.Fields("Customer_PostalAddress").Value + "";
						lCustomer.signed_Renamed = rs.Fields("CustomerTransaction_PersonName").Value;
						lCustomer.telephone = rs.Fields("Customer_Telephone").Value + "";
						lCustomer.terms = Convert.ToInt16(rs.Fields("Customer_Terms").Value + "");
						lCustomer.tax = rs.Fields("Customer_VatNumber").Value + "";
						if (rs.Fields("CustomerTransaction_TransactionTypeID").Value == 3) {
							lTransaction.transactionType = "Payment";
							lTransaction.paymentDiscount = 0;
						}
						lTransaction.customer_Renamed = lCustomer;
					}
					rs.Close();
					sql = "SELECT Consignment.* FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID WHERE (((Sale.SaleID)=" + lID + "));";
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					if (rs.BOF & rs.EOF) {
					} else {
						lSpecial.address = rs.Fields("Consignment_Address").Value;
						lSpecial.mobile = rs.Fields("Consignment_Mobile").Value;
						lSpecial.name = rs.Fields("Consignment_Name").Value;
						lSpecial.quote = 0;
						lSpecial.saleID = lID;
						lSpecial.telephone = rs.Fields("Consignment_Number").Value;
						lSpecial.transactionType = "Consignment";
						lTransaction.transactionSpecial_Renamed = lSpecial;
					}
					rs.Close();

					sql = "SELECT Consignment.* FROM Consignment INNER JOIN Sale ON Consignment.Consignment_CompleteSaleID = Sale.SaleID WHERE (((Sale.SaleID)=" + lID + "));";
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					if (rs.BOF & rs.EOF) {
					} else {
						lSpecial.address = rs.Fields("Consignment_Address").Value;
						lSpecial.mobile = rs.Fields("Consignment_Mobile").Value;
						lSpecial.name = rs.Fields("Consignment_Name").Value;
						lSpecial.quote = 0;
						lSpecial.saleID = lID;
						lSpecial.telephone = rs.Fields("Consignment_Number").Value;
						lSpecial.transactionType = "Consignment Complete";
						lTransaction.transactionSpecial_Renamed = lSpecial;
					}

					printTransactionA4(ref lTransaction);
				}

			} else if (Convert.ToDouble(Strings.Split(this.lvTransaction.FocusedItem.Name, "_")[3]) == 3) {
				//payment
				//Dim Report As New cryPayment
				Report.Load("cryPayment.rpt");
				rs = modRecordSet.getRS(ref "SELECT * FROM Company");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				if (Information.IsDBNull(rs.Fields("Company_PhysicalAddress").Value)) {
				} else {
					lAddress = Strings.Replace(rs.Fields("Company_PhysicalAddress").Value, Constants.vbCrLf, ", ");
					if (Strings.Right(lAddress, 2) == ", ") {
						lAddress = Strings.Left(lAddress, Strings.Len(lAddress) - 2);
					}
				}
				Report.SetParameterValue("txtCompanyDetails1", lAddress);
				if (Information.IsDBNull(rs.Fields("Company_Telephone").Value)) {
				} else {
					Report.SetParameterValue("txtCompanyDetails2", rs.Fields("Company_Telephone"));
				}
				if (Information.IsDBNull(rs.Fields("Company_TaxNumber").Value)) {
				} else {
					Report.SetParameterValue("txtCompanyDetails4", "TAX NO :" + rs.Fields("Company_TaxNumber").Value);
				}
				//If lTransaction.heading2 <> "" Then
				//    Report.txtCompanyDetails2.SetText lTransaction.heading2
				//    If lTransaction.heading3 <> "" Then
				//        Report.txtCompanyDetails3.SetText lTransaction.heading3
				//
				//    Else
				//        If lTransaction.taxNumber <> "" Then
				//            Report.txtCompanyDetails4.SetText "TAX NO :" & lTransaction.taxNumber
				//        End If
				//    End If
				//Else
				//    If lTransaction.heading3 <> "" Then
				//        Report.txtCompanyDetails2.SetText lTransaction.heading3
				//    Else
				//        If lTransaction.taxNumber <> "" Then
				//            Report.txtCompanyDetails2.SetText "TAX NO :" & lTransaction.taxNumber
				//        End If
				//    End If
				//End If
				rs.Close();
				Report.SetParameterValue("txtCustomer", _txtFields_2.Text);
				if (!string.IsNullOrEmpty(_txtFields_6.Text)) {
					lArray = Strings.Split(_txtFields_6.Text, Constants.vbCrLf);
					Report.SetParameterValue("txtCustAddress1", lArray[0]);
					if (Information.UBound(lArray) >= 1)
						Report.SetParameterValue("txtCustAddress2", lArray[1]);
					if (Information.UBound(lArray) >= 2)
						Report.SetParameterValue("txtCustAddress3", lArray[2]);
					if (Information.UBound(lArray) >= 3)
						Report.SetParameterValue("txtCustAddress4", lArray[3]);

				}
				if (!string.IsNullOrEmpty(_txtFields_0.Text))
					Report.SetParameterValue("txtCustAddress5", "TAX NO: " + _txtFields_0.Text);

				//If LCase(databaseName) = "pricing.mdb" Then
				//    sql = "SELECT Sale.SaleID, POS.POS_Name, Person.Person_FirstName, Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN Person ON Sale.Sale_PersonID = Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
				//Else
				//    sql = "SELECT Sale.SaleID, POS.POS_Name, M_Person.Person_FirstName, M_Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN M_Person ON Sale.Sale_PersonID = M_Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
				//End If
				//sql = "SELECT Sale.SaleID, POS.POS_Name, Person.Person_FirstName, Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN Person ON Sale.Sale_PersonID = Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
				sql = "SELECT Sale.* From Sale WHERE (((SaleID)=" + lID + "));";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

				if (rs.RecordCount) {
					posID = rs.Fields("Sale_PosID").Value;
					personID = rs.Fields("Sale_PersonID").Value;
					Report.SetParameterValue("txtInvoiceNumber", rs.Fields("Sale_Reference"));
					Report.SetParameterValue("txtInvoiceDate", Strings.Format(rs.Fields("Sale_DatePOS").Value, "dd mmm yyyy hh:mm"));
					//Report.txtPOS.SetText rs("POS_Name")
					//Report.txtCashier.SetText rs("Person_FirstName") & rs("Person_LastName")
					Report.SetParameterValue("txtAmount", Strings.FormatNumber(rs.Fields("Sale_Total").Value, 2));
					Report.SetParameterValue("txtChange", Strings.FormatNumber(rs.Fields("Sale_Tender").Value - rs.Fields("Sale_Total").Value, 2));
					// lTransaction.paymentTotal - lTransaction.paymentTender, 2)
					Report.SetParameterValue("txtTender", Strings.FormatNumber(rs.Fields("Sale_Tender").Value, 2));
					//  lTransaction.paymentTender, 2)
					//Report.txtPaidBy.SetText lTransaction.customer.signed
					Report.ReportDefinition.Sections("txtPaidBy").SectionFormat.EnableSuppress = true;
					rs.Close();

					sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" + personID + "));";
					rs = modRecordSet.getRS(ref sql);
					if (rs.RecordCount) {
						Report.SetParameterValue("txtCashier", rs.Fields("personName").Value + "");
					}
					rs.Close();

					sql = "SELECT POS_Name From POS WHERE (((POS.POSID)=" + posID + "));";
					rs = modRecordSet.getRS(ref sql);
					if (rs.RecordCount) {
						Report.SetParameterValue("txtPOS", rs.Fields("POS_Name").Value + "");
					}
					rs.Close();


					sql = "SELECT CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_ReferenceID From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=8) AND ((CustomerTransaction.CustomerTransaction_ReferenceID)=" + lID + "));";
					Debug.Print(sql);
					rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
					if (rs.RecordCount) {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(rs.Fields("CustomerTransaction_Amount").Value, 2));
					} else {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber("0.00", 2));
					}

					My.MyProject.Forms.frmReportShow.Text = "Customer Statement";
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
					My.MyProject.Forms.frmReportShow.mReport = Report;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
				} else {
					ReportNone.Load("cryNoRecords.rpt");
					ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
					ReportNone.SetParameterValue("txtTitle", "Customer Statement");
					//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
					return;
				}

			}
		}

		private void cmdsearch_Click_AllocByID(ref int PId)
		{
			bool prPrevSerial_p = false;
			int x = 0;
			string sql = null;
			string databaseName = null;
			short y = 0;
			short lMonth = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();

			bSelectPayment = true;
			if (gLoading)
				return;
			gLoading = true;
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			lMonth = Convert.ToInt16(cmbMonth.SelectedIndex);
			if (lMonth == gMonthEnd) {
				databaseName = "pricing.mdb";
			} else {
				databaseName = "Month" + lMonth + ".mdb";
			}
			//If openConnection() Then
			//    frmMain.lblPath.Caption = serverPath
			//    closeConnection
			//End If

			cn = modRecordSet.openConnectionInstance(ref databaseName);
			if (cn == null) {
				return;
			}
			string lString = null;
			string lCustomerString = null;
			string lStockString = null;
			string lPosString = null;
			if (this.cmbPOS.SelectedIndex)
				lPosString = " AND (Sale_PosID=" + cmbPOS.SelectedIndex + ")";
			lString = Strings.Trim(txtCustomer.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			//If lString <> "" Then
			//lString = "(Customer_InvoiceName LIKE '%" & Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") & "%')"
			lString = "(CustomerID = " + adoPrimaryRS.Fields("CustomerID").Value + ")";
			//Else
			//    lString = ""
			//End If
			lCustomerString = lString;
			if (!string.IsNullOrEmpty(lCustomerString))
				lCustomerString = " AND (" + lCustomerString + ") ";


			//Cater for one at a time
			if (!string.IsNullOrEmpty(Strings.Trim(this.txtStock.Text))) {
				y = 1;
				lString = Strings.Trim(this.txtStock.Text);
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
			}
			if (!string.IsNullOrEmpty(Strings.Trim(this.txtSerial.Text))) {
				prPrevSerial_p = true;
				y = 2;
				lString = Strings.Trim(this.txtSerial.Text);
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
				lString = Strings.Replace(lString, "  ", " ");
			}


			if (!string.IsNullOrEmpty(lString)) {
				//By StockItem........
				if (y == 1)
					lString = "(StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";

				//By Serial Number......
				if (y == 2)
					lString = "(Sale.Sale_Serialref LIKE '" + Strings.Replace(lString, " ", "%' AND Sale.Sale_Serialref LIKE '%") + "%')";
			} else {
				lString = "";
			}

			lStockString = lString;
			if (!string.IsNullOrEmpty(lStockString))
				lStockString = " AND (" + lStockString + ") AND (SaleItem.SaleItem_DepositType=0)";

			if (string.IsNullOrEmpty(lCustomerString)) {
				if (string.IsNullOrEmpty(lStockString)) {
					sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType From Sale Where ((Sale.Sale_PaymentType > 0) " + lPosString + " )ORDER BY Sale.SaleID DESC;";
				} else {
					//By StockItem........
					if (y == 1)
						sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN StockItem ON SaleItem.SaleItem_StockItemID = StockItem.StockItemID WHERE (((Sale.Sale_PaymentType) > 0) " + lStockString + lPosString + " ) ORDER BY Sale.SaleID DESC;";

					//By Serial Number......
					if (y == 2)
						sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) WHERE (((Sale.Sale_PaymentType) > 0) " + lStockString + lPosString + " ) ORDER BY Sale.SaleID DESC;";

				}
			} else {
				if (string.IsNullOrEmpty(lStockString)) {
					sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) " + lCustomerString + lPosString + " ) ORDER BY Sale.SaleID DESC;";
				} else {
					sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN (Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN StockItem ON SaleItem.SaleItem_StockItemID = StockItem.StockItemID Where (((Sale.Sale_PaymentType) > 0) " + lCustomerString + lStockString + lPosString + " )  ORDER BY Sale.SaleID DESC;";
					sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM StockItem, Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) And ((Customer.CustomerID) = " + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY Sale.SaleID DESC;";
				}
			}
			sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM StockItem, Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) And ((Customer.CustomerID) = " + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY Sale.SaleID DESC;";

			sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;";

			sql = "SELECT CustomerTransactionAlloc.CustomerTransactionAllocID, CustomerTransactionAlloc.CustomerTransactionAlloc_MainID, CustomerTransactionAlloc.CustomerTransactionAlloc_Amount, CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, " + "CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransactionAlloc INNER JOIN (CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID) ON CustomerTransactionAlloc.CustomerTransactionAlloc_ChildID = CustomerTransaction.CustomerTransactionID WHERE (((CustomerTransactionAlloc.CustomerTransactionAlloc_MainID)=" + PId + "));";
			Debug.Print(sql);
			rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			lvTransAlloc.Items.Clear();
			lblcount.Text = "0 of 0";

			System.Windows.Forms.ListViewItem lvItem = null;
			x = 0;
			lvTransAlloc.Visible = false;
			while (!(rs.EOF)) {
				x = x + 1;
				if (gLoading) {
				} else {
					break; // TODO: might not be correct. Was : Exit Do
				}
				lblcount.Text = x + " of " + rs.RecordCount;
				System.Windows.Forms.Application.DoEvents();
				//If rs("CustomerTransaction_Reference") = "Month End" Then
				if (rs.Fields("TransactionType_Name").Value == "B/Forward") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value & (Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
						//Else
						lvItem = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionAllocID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItem.SubItems.Count > 1) {
							lvItem.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItem.SubItems.Count > 2) {
							lvItem.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						//Select Case rs("Sale_PaymentType")
						//   Case 1
						//        lvItem.SubItems(2) = "Cash"
						//    Case 2
						//        lvItem.SubItems(2) = "CR Card"
						//    Case 3
						//        lvItem.SubItems(2) = "DR Card"
						//    Case 4
						//        lvItem.SubItems(2) = "Cheque"
						//    Case 5
						//        lvItem.SubItems(2) = "Account"
						//    Case 7
						//        lvItem.SubItems(2) = "Split Tender"
						//    Case Else
						//        lvItem.SubItems(2) = "Cash"
						//End Select
						if (lvItem.SubItems.Count > 3) {
							lvItem.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItem.SubItems.Count > 4) {
							lvItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItem.SubItems.Count > 5) {
							lvItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4);
						} else {
							lvItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Invoice") {
					//If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
					//Else
					lvItem = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionAllocID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
					if (lvItem.SubItems.Count > 1) {
						lvItem.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
					} else {
						lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
					}
					if (lvItem.SubItems.Count > 2) {
						lvItem.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
					} else {
						lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
					}
					if (lvItem.SubItems.Count > 3) {
						lvItem.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
					} else {
						lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 4) {
						lvItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
					} else {
						lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 5) {
						lvItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4);
					} else {
						lvItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)));
					}
					//End If
				} else if (rs.Fields("TransactionType_Name").Value == "Interest") {
					//If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
					//Else
					lvItem = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionAllocID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
					if (lvItem.SubItems.Count > 1) {
						lvItem.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
					} else {
						lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
					}
					if (lvItem.SubItems.Count > 2) {
						lvItem.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
					} else {
						lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
					}
					if (lvItem.SubItems.Count > 3) {
						lvItem.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
					} else {
						lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 4) {
						lvItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
					} else {
						lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 5) {
						lvItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4);
					} else {
						lvItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)));
					}
					//End If
				} else if (rs.Fields("TransactionType_Name").Value == "Debit Journal") {
					//If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
					//Else
					lvItem = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionAllocID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
					if (lvItem.SubItems.Count > 1) {
						lvItem.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
					} else {
						lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
					}
					if (lvItem.SubItems.Count > 2) {
						lvItem.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
					} else {
						lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
					}
					if (lvItem.SubItems.Count > 3) {
						lvItem.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
					} else {
						lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 4) {
						lvItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
					} else {
						lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
					}
					if (lvItem.SubItems.Count > 5) {
						lvItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4);
					} else {
						lvItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)));
					}
					//End If
				}
				rs.moveNext();
			}
			lvTransAlloc.Visible = true;
			lvTransAlloc.Refresh();
			Cursor = System.Windows.Forms.Cursors.Default;
			gLoading = false;
		}

		private void cmdsearch_Click_Alloc()
		{
			int x = 0;
			string sql = null;
			string databaseName = null;
			short y = 0;
			short lMonth = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();

			bSelectPayment = false;
			if (gLoading)
				return;
			gLoading = true;
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			//lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
			//If lMonth = gMonthEnd Then
			databaseName = "pricing.mdb";
			//Else
			//    databaseName = "Month" & lMonth & ".mdb"
			//End If

			//Set cn = openConnectionInstance(databaseName)
			//If cn Is Nothing Then
			//    Exit Sub
			//End If
			string lString = null;

			sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;";
			Debug.Print(sql);
			//rs.Open sql, cnnDB, adOpenStatic, adLockReadOnly, adCmdText
			rs = modRecordSet.getRS(ref sql);

			lvTransAlloc.Items.Clear();
			lblcount.Text = "0 of 0";

			System.Windows.Forms.ListViewItem lvItemAlloc = null;
			x = 0;
			lvTransAlloc.Visible = false;
			while (!(rs.EOF)) {
				x = x + 1;
				if (gLoading) {
				} else {
					break; // TODO: might not be correct. Was : Exit Do
				}
				lblcount.Text = x + " of " + rs.RecordCount;
				System.Windows.Forms.Application.DoEvents();
				//If rs("CustomerTransaction_Reference") = "Month End" Then
				if (rs.Fields("TransactionType_Name").Value == "B/Forward") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value & (Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
						//Else
						lvItemAlloc = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemAlloc.SubItems.Count > 1) {
							lvItemAlloc.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemAlloc.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemAlloc.SubItems.Count > 2) {
							lvItemAlloc.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemAlloc.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						//Select Case rs("Sale_PaymentType")
						//   Case 1
						//        lvItemAlloc.SubItems(2) = "Cash"
						//    Case 2
						//        lvItemAlloc.SubItems(2) = "CR Card"
						//    Case 3
						//        lvItemAlloc.SubItems(2) = "DR Card"
						//    Case 4
						//        lvItemAlloc.SubItems(2) = "Cheque"
						//    Case 5
						//        lvItemAlloc.SubItems(2) = "Account"
						//    Case 7
						//        lvItemAlloc.SubItems(2) = "Split Tender"
						//    Case Else
						//        lvItemAlloc.SubItems(2) = "Cash"
						//End Select
						if (lvItemAlloc.SubItems.Count > 3) {
							lvItemAlloc.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 4) {
							lvItemAlloc.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 5) {
							lvItemAlloc.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Invoice") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value & (Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
						//Else
						lvItemAlloc = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemAlloc.SubItems.Count > 1) {
							lvItemAlloc.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemAlloc.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemAlloc.SubItems.Count > 2) {
							lvItemAlloc.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemAlloc.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemAlloc.SubItems.Count > 3) {
							lvItemAlloc.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 4) {
							lvItemAlloc.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 5) {
							lvItemAlloc.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Interest") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value & (Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
						//Else
						lvItemAlloc = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemAlloc.SubItems.Count > 1) {
							lvItemAlloc.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemAlloc.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemAlloc.SubItems.Count > 2) {
							lvItemAlloc.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemAlloc.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemAlloc.SubItems.Count > 3) {
							lvItemAlloc.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 4) {
							lvItemAlloc.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 5) {
							lvItemAlloc.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Debit Journal") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value) {
						//Else
						lvItemAlloc = lvTransAlloc.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemAlloc.SubItems.Count > 1) {
							lvItemAlloc.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemAlloc.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemAlloc.SubItems.Count > 2) {
							lvItemAlloc.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemAlloc.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemAlloc.SubItems.Count > 3) {
							lvItemAlloc.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 4) {
							lvItemAlloc.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemAlloc.SubItems.Count > 5) {
							lvItemAlloc.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemAlloc.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
					}
				}
				rs.moveNext();
			}
			lvTransAlloc.Visible = true;
			//lvTransAlloc.Refresh
			Cursor = System.Windows.Forms.Cursors.Default;
			gLoading = false;
		}

		private void cmdsearch_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			string sql = null;
			string databaseName = null;
			short y = 0;
			short lMonth = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();


			if (gLoading)
				return;
			gLoading = true;
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			//lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
			//If lMonth = gMonthEnd Then
			databaseName = "pricing.mdb";
			//Else
			//    databaseName = "Month" & lMonth & ".mdb"
			//End If
			//If openConnection() Then
			//    frmMain.lblPath.Caption = serverPath
			//    closeConnection
			//End If

			//Set cn = openConnectionInstance(databaseName)
			//If cn Is Nothing Then
			//    Exit Sub
			//End If
			//Dim lString As String

			System.Windows.Forms.Application.DoEvents();
			if (rs.State)
				rs.Close();
			sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;";
			Debug.Print(sql);
			//rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
			rs = modRecordSet.getRS(ref sql);

			lvTransaction.Items.Clear();
			lblcount.Text = "0 of 0";

			System.Windows.Forms.ListViewItem lvItemTran = null;
			x = 0;
			lvTransaction.Visible = false;
			while (!(rs.EOF)) {
				x = x + 1;
				if (gLoading) {
				} else {
					break; // TODO: might not be correct. Was : Exit Do
				}
				lblcount.Text = x + " of " + rs.RecordCount;
				System.Windows.Forms.Application.DoEvents();
				//If rs("CustomerTransaction_Reference") = "Month End" Then
				if (rs.Fields("TransactionType_Name").Value == "B/Forward") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value) {
					} else if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == rs.Fields("CustomerTransaction_Allocated").Value & (Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) < 0) {
					} else {
						lvItemTran = lvTransaction.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemTran.SubItems.Count > 1) {
							lvItemTran.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemTran.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemTran.SubItems.Count > 2) {
							lvItemTran.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemTran.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						//Select Case rs("Sale_PaymentType")
						//   Case 1
						//        lvItemTran.SubItems(2) = "Cash"
						//    Case 2
						//        lvItemTran.SubItems(2) = "CR Card"
						//    Case 3
						//        lvItemTran.SubItems(2) = "DR Card"
						//    Case 4
						//        lvItemTran.SubItems(2) = "Cheque"
						//    Case 5
						//        lvItemTran.SubItems(2) = "Account"
						//    Case 7
						//        lvItemTran.SubItems(2) = "Split Tender"
						//    Case Else
						//        lvItemTran.SubItems(2) = "Cash"
						//End Select
						if (lvItemTran.SubItems.Count > 3) {
							lvItemTran.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 4) {
							lvItemTran.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 5) {
							lvItemTran.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 6) {
							lvItemTran.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemTran.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Invoice") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value) {
					} else if (rs.Fields("CustomerTransaction_Allocated").Value < 0) {
					} else {
						lvItemTran = lvTransaction.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemTran.SubItems.Count > 1) {
							lvItemTran.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemTran.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemTran.SubItems.Count > 2) {
							lvItemTran.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemTran.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemTran.SubItems.Count > 3) {
							lvItemTran.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 4) {
							lvItemTran.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 5) {
							lvItemTran.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 6) {
							lvItemTran.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemTran.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Interest") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value) {
					} else if (rs.Fields("CustomerTransaction_Allocated").Value < 0) {
					} else {
						lvItemTran = lvTransaction.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemTran.SubItems.Count > 1) {
							lvItemTran.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemTran.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemTran.SubItems.Count > 2) {
							lvItemTran.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemTran.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemTran.SubItems.Count > 3) {
							lvItemTran.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 4) {
							lvItemTran.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 5) {
							lvItemTran.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 6) {
							lvItemTran.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemTran.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Debit Journal") {
					if ((Information.IsDBNull(rs.Fields("debit").Value) ? 0 : rs.Fields("debit").Value) == rs.Fields("CustomerTransaction_Allocated").Value) {
					} else {
						lvItemTran = lvTransaction.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemTran.SubItems.Count > 1) {
							lvItemTran.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemTran.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemTran.SubItems.Count > 2) {
							lvItemTran.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemTran.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemTran.SubItems.Count > 3) {
							lvItemTran.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 4) {
							lvItemTran.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 5) {
							lvItemTran.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemTran.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemTran.SubItems.Count > 6) {
							lvItemTran.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemTran.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}
				}
				rs.moveNext();
			}
			lvTransaction.Visible = true;
			//lvTransaction.Refresh
			Cursor = System.Windows.Forms.Cursors.Default;
			gLoading = false;
		}

		private void cmdsearch_Click_Payment()
		{
			int x = 0;
			string sql = null;
			string databaseName = null;
			short y = 0;
			short lMonth = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();


			if (gLoading)
				return;
			gLoading = true;
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			//lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
			//If lMonth = gMonthEnd Then
			databaseName = "pricing.mdb";
			//Else
			//    databaseName = "Month" & lMonth & ".mdb"
			//End If
			//If openConnection() Then
			//    frmMain.lblPath.Caption = serverPath
			//    closeConnection
			//End If

			//Set cn = openConnectionInstance(databaseName)
			//If cn Is Nothing Then
			//    Exit Sub
			//End If
			//Dim lString As String

			sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;";
			Debug.Print(sql);
			//rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
			rs = modRecordSet.getRS(ref sql);

			lvPayment.Items.Clear();
			//Exit Sub
			lblcount.Text = "0 of 0";

			System.Windows.Forms.ListViewItem lvItemPay = null;
			x = 0;
			lvPayment.Visible = false;
			while (!(rs.EOF)) {
				x = x + 1;
				if (gLoading) {
				} else {
					break; // TODO: might not be correct. Was : Exit Do
				}
				lblcount.Text = x + " of " + rs.RecordCount;
				System.Windows.Forms.Application.DoEvents();
				//If rs("CustomerTransaction_Reference") = "Month End" Then
				if (rs.Fields("TransactionType_Name").Value == "B/Forward") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= IIf(IsNull(rs("CustomerTransaction_Allocated")), 0, rs("CustomerTransaction_Allocated")) Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}
				} else if (rs.Fields("TransactionType_Name").Value == "Payment") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= IIf(IsNull(rs("CustomerTransaction_Allocated")), 0, rs("CustomerTransaction_Allocated")) Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						//Select Case rs("Sale_PaymentType")
						//   Case 1
						//        lvItemPay.SubItems(2) = "Cash"
						//    Case 2
						//        lvItemPay.SubItems(2) = "CR Card"
						//    Case 3
						//        lvItemPay.SubItems(2) = "DR Card"
						//    Case 4
						//        lvItemPay.SubItems(2) = "Cheque"
						//    Case 5
						//        lvItemPay.SubItems(2) = "Account"
						//    Case 7
						//        lvItemPay.SubItems(2) = "Split Tender"
						//    Case Else
						//        lvItemPay.SubItems(2) = "Cash"
						//End Select
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}

				} else if (rs.Fields("TransactionType_Name").Value == "Credit Journal") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}

				} else if (rs.Fields("TransactionType_Name").Value == "Invoice") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}

				} else if (rs.Fields("TransactionType_Name").Value == "Interest") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}

				} else if (rs.Fields("TransactionType_Name").Value == "Settlement") {
					//If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
					if ((Information.IsDBNull(rs.Fields("credit").Value) ? 0 : rs.Fields("credit").Value) == 0) {
					} else {
						lvItemPay = lvPayment.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItemPay.SubItems.Count > 1) {
							lvItemPay.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItemPay.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItemPay.SubItems.Count > 2) {
							lvItemPay.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItemPay.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItemPay.SubItems.Count > 3) {
							lvItemPay.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 4) {
							lvItemPay.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 5) {
							lvItemPay.SubItems[5].Text = Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4);
						} else {
							lvItemPay.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)));
						}
						if (lvItemPay.SubItems.Count > 6) {
							lvItemPay.SubItems[6].Text = Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4);
						} else {
							lvItemPay.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0 ? ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)) : 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)));
						}
					}

				}
				rs.moveNext();
			}
			lvPayment.Visible = true;
			//lvPayment.Refresh
			Cursor = System.Windows.Forms.Cursors.Default;
			gLoading = false;
		}


		private void buildDataControls()
		{
			doDataControl(ref (this.cmbChannel), ref "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", ref "Customer_ChannelID", ref "ChannelID", ref "Channel_Name");
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataSource = rs
			dataControl.DataBindings.Add(adoPrimaryRS);
			dataControl.DataField = DataField;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}
		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			gLoading = false;

			if (id) {
				//checkcustid = id
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Customer WHERE CustomerID = " + id);
				cmbTerms.SelectedIndex = adoPrimaryRS.Fields("Customer_Terms").Value;
				mbAddNewFlag = false;
			} else {
				//Set adoPrimaryRS = getRS("select * from Customer")
				//adoPrimaryRS.AddNew
				//Me.Caption = Me.Caption & " [New record]"
				//mbAddNewFlag = True
				//cmbTerms.ListIndex = 0
				//Me.cmbChannel.BoundText = 0
			}
			//    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
			//    Else
			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			//        For Each oText In Me.txtInteger
			//            Set oText.DataBindings.Add(adoPrimaryRS)
			//            txtInteger_LostFocus oText.Index
			//        Next
			foreach (TextBox oText_loopVariable in this.txtFloat) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloat_Leave;
				//txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
			}
			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in this.chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			cmbTerms.DataSource = adoPrimaryRS;
			buildDataControls();
			mbDataChanged = false;
			if (mbAddNewFlag == true) {
				foreach (CheckBox oCheck_loopVariable in this.chkFields) {
					oCheck = oCheck_loopVariable;
					oCheck.CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
				cmbChannel.BoundText = "1";
			}

			loadData();

			loadLanguage();
			ShowDialog();
			//    End If
		}

		private void cmbChannel_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (mbEditFlag | mbAddNewFlag)
				return;
			if (eventArgs.KeyCode == 27) {
				//eventArgs = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmdShowHistory_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int i = 0;
			int x = 0;
			string sql = null;
			string databaseName = null;
			short y = 0;
			short lMonth = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = new ADODB.Recordset();

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cmdShowHistory.Text == "&Show Full History") {
				cmdShowHistory.Text = "&Show Current Month";
			} else {
				cmdShowHistory.Text = "&Show Full History";
				cmdsearch_Click(cmdSearch, new System.EventArgs());
				return;
			}

			if (gLoading)
				return;
			gLoading = true;
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();

			y = cmbMonth.Items.Count - 1;
			lvTransaction.Items.Clear();
			lblcount.Text = "0 of 0";
			lvTransaction.Visible = false;

			string lPosString = null;
			System.Windows.Forms.ListViewItem lvItem = null;
			//(cmbMonth.ListCount - 1)
			for (i = 0; i <= y; i++) {

				lMonth = Convert.ToInt32(cmbMonth.Items[i]);
				if (lMonth == gMonthEnd) {
					databaseName = "pricing.mdb";
				} else {
					databaseName = "Month" + lMonth + ".mdb";
				}

				cn = modRecordSet.openConnectionInstance(ref databaseName);
				if (cn == null) {
					goto nextMonth;
					//Exit Sub
				}
				//Dim lString As String
				//Dim lCustomerString As String
				//Dim lStockString As String
				if (this.cmbPOS.SelectedIndex)
					lPosString = " AND (Sale_PosID=" + cmbPOS.SelectedIndex + ")";

				sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," + " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + adoPrimaryRS.Fields("CustomerID").Value + ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;";
				Debug.Print(sql);
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

				x = 0;
				//lvTransaction.Visible = False
				while (!(rs.EOF)) {
					x = x + 1;
					if (gLoading) {
					} else {
						break; // TODO: might not be correct. Was : Exit Do
					}
					lblcount.Text = x + " of " + rs.RecordCount;
					System.Windows.Forms.Application.DoEvents();
					if (rs.Fields("CustomerTransaction_Reference").Value != "Month End") {
						lvItem = lvTransaction.Items.Add("K" + rs.Fields("CustomerTransactionID").Value + "_" + databaseName + "_" + rs.Fields("CustomerTransaction_ReferenceID").Value + "_" + rs.Fields("CustomerTransaction_TransactionTypeID").Value, Strings.Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "");
						if (lvItem.SubItems.Count > 1) {
							lvItem.SubItems[1].Text = rs.Fields("CustomerTransaction_Reference").Value;
						} else {
							lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("CustomerTransaction_Reference").Value));
						}
						if (lvItem.SubItems.Count > 2) {
							lvItem.SubItems[2].Text = rs.Fields("TransactionType_Name").Value;
						} else {
							lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("TransactionType_Name").Value));
						}
						if (lvItem.SubItems.Count > 3) {
							lvItem.SubItems[3].Text = Strings.FormatNumber(rs.Fields("debit").Value, 4);
						} else {
							lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("debit").Value, 4)));
						}
						if (lvItem.SubItems.Count > 4) {
							lvItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("credit").Value, 4);
						} else {
							lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("credit").Value, 4)));
						}
					}
					rs.moveNext();
				}
				//lvTransaction.Visible = True
				rs.Close();
				nextMonth:
			}

			lvTransaction.Visible = true;
			Cursor = System.Windows.Forms.Cursors.Default;
			gLoading = false;


			return;
			ErrShowHistory:
			if (Strings.InStr(Strings.LCase(Err().Description), "not a valid path")) {
				Interaction.MsgBox(Err().Number + " - " + Err().Description);
				return;
			} else {
				Interaction.MsgBox(Err().Number + " - " + Err().Description);
				return;
			}
		}

		private void cmdStatement_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//On Error Resume Next
			if (mbAddNewFlag) {
				Interaction.MsgBox("There is no statement for a new customer.", MsgBoxStyle.Exclamation, "New Customer");
			} else {
				modApplication.report_CustomerStatement(ref adoPrimaryRS.Fields("CustomerID").Value);
			}
		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//On Error Resume Next
			ADODB.Connection cn = default(ADODB.Connection);
			short x = 0;
			string databaseName = null;
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			decimal cAlloc = default(decimal);
			//Screen.MousePointer = vbHourglass

			if (bSelectPayment == true) {
			} else {
				Interaction.MsgBox("Select Payment first to continue!");
				return;
			}

			if (lvTransAlloc.FocusedItem == null) {
				Interaction.MsgBox("Select Invoice to Un-Allocated!");
				return;
			}

			//If Split(Me.lvTransaction.SelectedItem.Key, "_")(2) = 0 Then MsgBox "There is no Sale document attached!", vbInformation: Screen.MousePointer = vbNormal: Exit Sub
			lID = Convert.ToInt32(Strings.Replace(Strings.Split(this.lvTransAlloc.FocusedItem.Name, "_")[0], "K", ""));
			//tempAmount = 0
			//If CCur((0 - lvPayment.SelectedItem.SubItems(6))) = CCur((lvTransaction.SelectedItem.SubItems(6))) Then
			//    tempAmount = CCur((0 - lvPayment.SelectedItem.SubItems(6)))
			//ElseIf CCur((0 - lvPayment.SelectedItem.SubItems(6))) > CCur((lvTransaction.SelectedItem.SubItems(6))) Then
			//    tempAmount = CCur((lvTransaction.SelectedItem.SubItems(6)))
			//ElseIf CCur((0 - lvPayment.SelectedItem.SubItems(6))) < CCur((lvTransaction.SelectedItem.SubItems(6))) Then
			//    tempAmount = CCur((0 - lvPayment.SelectedItem.SubItems(6)))
			//End If

			//If (0 - lvPayment.SelectedItem.SubItems(6)) > 0 Then
			//If (0 - lvPayment.SelectedItem.SubItems(6)) >= lvTransaction.SelectedItem.SubItems(6) Then
			sql = "Select * From CustomerTransactionAlloc Where CustomerTransactionAllocID = " + lID + ";";
			Debug.Print(sql);
			rs = modRecordSet.getRS(ref sql);
			if (rs.RecordCount) {
				if (Interaction.MsgBox("Are you sure you wish to Un-Allocate " + Constants.vbCrLf + Constants.vbCrLf + lvTransAlloc.FocusedItem.SubItems[2].Text + " | " + lvTransAlloc.FocusedItem.Text + " | " + lvTransAlloc.FocusedItem.SubItems[1].Text + " | R " + lvTransAlloc.FocusedItem.SubItems[3].Text, MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" + Convert.ToDecimal(rs.Fields("CustomerTransactionAlloc_Amount").Value) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + rs.Fields("CustomerTransactionAlloc_MainID").Value + "));");
					//cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
					modRecordSet.cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated-" + Convert.ToDecimal(rs.Fields("CustomerTransactionAlloc_Amount").Value) + " WHERE (((CustomerTransaction.CustomerTransactionID)=" + rs.Fields("CustomerTransactionAlloc_ChildID").Value + "));");

					sql = "DELETE FROM CustomerTransactionAlloc Where CustomerTransactionAllocID = " + lID + ";";
					modRecordSet.cnnDB.Execute(sql);
				}
			}
			//Else
			//    MsgBox "Insufficient funds."
			//    Exit Sub
			//End If

			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();

			cmdsearch_Click_Payment();
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click(cmdSearch, new System.EventArgs());
			System.Windows.Forms.Application.DoEvents();
			cmdsearch_Click_Alloc();
			System.Windows.Forms.Application.DoEvents();
			cmdAllocate.Focus();
		}

		private void frmCustomerAllocPayment_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_2,
				_txtFields_3,
				_txtFields_4,
				_txtFields_5,
				_txtFields_6,
				_txtFields_7,
				_txtFields_8,
				_txtFields_9,
				_txtFields_10
			});
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_12,
				_txtFloat_13,
				_txtFloat_15,
				_txtFloat_16,
				_txtFloat_17,
				_txtFloat_18
			});
			chkFields.AddRange(new CheckBox[] {
				_chkFields_11,
				_chkFields_19
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			foreach (TextBox tb_loopVariable in txtFloat) {
				tb = tb_loopVariable;
				tb.Enter += txtFloat_Enter;
				tb.KeyPress += txtFloat_KeyPress;
			}
		}

		private void frmCustomerAllocPayment_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmCustomerAllocPayment_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (mbEditFlag | mbAddNewFlag)
				return;

			switch (KeyCode) {
				case System.Windows.Forms.Keys.Escape:
					KeyCode = 0;
					System.Windows.Forms.Application.DoEvents();
					adoPrimaryRS.Move(0);
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
		}

		private void frmCustomerAllocPayment_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This is where you put validation code
			//This event gets called when the following actions occur
			bool bCancel = false;
			switch (adReason) {
				case ADODB.EventReasonEnum.adRsnAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnClose:
					break;
				case ADODB.EventReasonEnum.adRsnDelete:
					break;
				case ADODB.EventReasonEnum.adRsnFirstChange:
					break;
				case ADODB.EventReasonEnum.adRsnMove:
					break;
				case ADODB.EventReasonEnum.adRsnRequery:
					break;
				case ADODB.EventReasonEnum.adRsnResynch:
					break;
				case ADODB.EventReasonEnum.adRsnUndoAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnUndoDelete:
					break;
				case ADODB.EventReasonEnum.adRsnUndoUpdate:
					break;
				case ADODB.EventReasonEnum.adRsnUpdate:
					break;
			}

			if (bCancel)
				adStatus = ADODB.EventStatusEnum.adStatusCancel;
		}


		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox oText = new TextBox();
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
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					//txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			if (string.IsNullOrEmpty(_txtFields_4.Text)) {
				Interaction.MsgBox("A Customer First Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS");
				_txtFields_4.Focus();
				functionReturnValue = false;
				return functionReturnValue;
			}
			if (string.IsNullOrEmpty(_txtFields_5.Text)) {
				Interaction.MsgBox("A Customer surname Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS");
				_txtFields_5.Focus();
				functionReturnValue = false;
				return functionReturnValue;
			}
			if (string.IsNullOrEmpty(_txtFields_2.Text)) {
				_txtFields_2.Text = _txtFields_4.Text + " " + _txtFields_5.Text;
			}
			adoPrimaryRS.Fields("Customer_Terms").Value = Convert.ToInt32(cmbTerms.Items[cmbTerms.SelectedIndex]);
			if (mbAddNewFlag) {
				//        adoPrimaryRS.UpdateBatch adAffectAll
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.Move(0);
			}
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			return functionReturnValue;
			//    update = False
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			//    update
			if (update_Renamed()) {
				this.Close();
			}
		}

		private void lvPayment_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lvPayment.FocusedItem == null) {
				//MsgBox "Select Invoice to be Allocated!"
				return;
			}
			cmdsearch_Click_AllocByID(ref Convert.ToInt32(Strings.Replace(Strings.Split(this.lvPayment.FocusedItem.Name, "_")[0], "K", "")));
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtInteger_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtInteger(Index)
		}

		private void txtInteger_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtInteger_MyLostFocus(ref short Index)
		{
			//    LostFocus txtInteger(Index), 0
		}

		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloat);
			modUtilities.MyGotFocusNumeric(ref txtFloat[Index]);
		}

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
		private void txtFloat_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}



		private void printTransactionA4(ref transaction lTransaction)
		{
			string typeQuote = null;
			string typeAccountPayment = null;
			string typeConsignment = null;
			string typeConsignmentReturn = null;
			string typeAccountSaleCOD = null;
			string typeAccountSale = null;
			int lRetVal = 0;
			int hkey = 0;
			string vValue = null;
			decimal lnVat = default(decimal);
			string gPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			customer customer_Renamed = null;
			string sql = null;
			ADODB.Recordset rsNew = new ADODB.Recordset();
			//Dim rsNew2                  As New Recordset

			lineItem lineitem_Renamed = null;
			string lString = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			short lPaymentType = 0;
			string[] lArray = null;
			decimal TCurrency = default(decimal);

			decimal QuoteTotal = default(decimal);

			 // ERROR: Not supported in C#: OnErrorStatement

			//Set which invoice is required
			string sPrintGST = null;
			sPrintGST = "";
			QuoteTotal = 0;
			//lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
			//lRetVal = QueryValueEx(hkey, "printGST", sPrintGST)
			//RegCloseKey (hkey)
			//If sPrintGST = "" Then sPrintGST = "0"

			// If gParameters.A4Exclusive = True Then
			//     Set Report = New cryReceipt1
			// ElseIf sPrintGST = "1" Then
			//     Set Report = New cryReceipt1
			// Else
			Report.Load("cryReceipt.rpt");
			// End If

			//lPaymentType = getPaymentType(lTransaction)

			//If lPaymentType And typeAccountPayment Then
			//    printTransactionPaymentA4 lTransaction
			//    Exit Sub
			//End If
			//Dim lnVat               As Currency
			gPath = "C:\\4POS\\pos\\";
			int lVatAmount = 0;
			int lAmount = 0;

			rsNew.Open(gPath + "data\\item.rs", , ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
			//, adOpenStatic, adLockOptimistic
			lnVat = 0;
			//a = rsNew.RecordCount
			//rsNew.Close

			//rsNew2.source = rsNew.source

			//rsNew("transactionItem_quantity").Type = rsNew("transactionItem_price").Type
			//rsNew("transactionItem_quantity").DefinedSize = rsNew("transactionItem_price").DefinedSize
			//rsNew2("transactionItem_quantity").Attributes = rsNew("transactionItem_price").Attributes
			//rsNew2("transactionItem_quantity").NumericScale = rsNew("transactionItem_price").NumericScale
			//rsNew2("transactionItem_quantity").Precision = rsNew("transactionItem_price").Precision


			foreach (lineItem lineitem_Renamed_loopVariable in lTransaction.lineItems) {
				lineitem_Renamed = lineitem_Renamed_loopVariable;
				rsNew.AddNew();
				if (lineitem_Renamed.revoke) {
				} else {
					rsNew.Fields("transactionItem_build").Value = lineitem_Renamed.build;
					rsNew.Fields("transactionItem_code").Value = lineitem_Renamed.code;
					rsNew.Fields("transactionItem_depositType").Value = lineitem_Renamed.depositType;
					rsNew.Fields("transactionItem_id").Value = lineitem_Renamed.id;
					rsNew.Fields("transactionItem_lineNo").Value = lineitem_Renamed.lineNo;
					rsNew.Fields("transactionItem_name").Value = lineitem_Renamed.name;
					rsNew.Fields("transactionItem_originalPrice").Value = lineitem_Renamed.originalPrice;
					rsNew.Fields("transactionItem_price").Value = lineitem_Renamed.price;
					rsNew.Fields("transactionItem_quantity").Value = lineitem_Renamed.quantity;
					rsNew.Fields("transactionItem_receiptName").Value = Strings.LTrim(Strings.Mid(lineitem_Renamed.receiptName, Strings.InStr(1, lineitem_Renamed.receiptName, "x") + 1, Strings.Len(lineitem_Renamed.receiptName)));
					//lineitem.receiptName
					rsNew.Fields("transactionItem_reversal").Value = lineitem_Renamed.reversal;
					rsNew.Fields("transactionItem_revoke").Value = lineitem_Renamed.revoke;
					rsNew.Fields("transactionItem_set").Value = lineitem_Renamed.setBuild;
					rsNew.Fields("transactionItem_shrink").Value = lineitem_Renamed.shrink;
					rsNew.Fields("transactionItem_type").Value = lineitem_Renamed.transactionType;
					rsNew.Fields("transactionItem_vat").Value = lineitem_Renamed.vat;

					if (lineitem_Renamed.vat > 0)
						lnVat = lnVat + ((lineitem_Renamed.quantity * lineitem_Renamed.price) - ((lineitem_Renamed.quantity * lineitem_Renamed.price) / (1 + (lineitem_Renamed.vat / 100))));
					QuoteTotal = QuoteTotal + (lineitem_Renamed.quantity * lineitem_Renamed.price);
					//If gParameters.A4Exclusive = True Then TCurrency = TCurrency + ((lineitem.quantity * lineitem.price) / (1 + (lineitem.vat) / 100))
					//TCurrency = 0 'TCurrency + ((lineitem.quantity * lineitem.price) / (1 + (lineitem.vat) / 100))
					rsNew.update();
				}
			}

			//rsNew.MoveFirst
			//vValue = rsNew("transactionItem_quantity")
			vValue = "";
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS\\pos", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "A4Items", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue))
				vValue = "0";
			if (vValue == "1") {
				rsNew.Sort = "transactionItem_receiptName";
			} else if (vValue == "0") {
			}

			Report.Database.Tables(1).SetDataSource(rsNew);
			//Report.Database.Tables(2).SetDataSource rsNew, 3
			Report.SetParameterValue("txtCompanyName", lTransaction.companyName);
			Report.SetParameterValue("txtCompanyDetails1", lTransaction.heading1);

			if (!string.IsNullOrEmpty(lTransaction.heading2)) {
				Report.SetParameterValue("txtCompanyDetails2", lTransaction.heading2);
				if (!string.IsNullOrEmpty(lTransaction.heading3)) {
					Report.SetParameterValue("txtCompanyDetails3", lTransaction.heading3);

					//If gParameters.tr_PrintInvoice = False Then
					if (!string.IsNullOrEmpty(lTransaction.taxNumber)) {
						Report.SetParameterValue("txtCompanyDetails4", "TAX NO :" + lTransaction.taxNumber);
					}
					//End If
				} else {
					//If gParameters.tr_PrintInvoice = False Then
					if (!string.IsNullOrEmpty(lTransaction.taxNumber)) {
						Report.SetParameterValue("txtCompanyDetails3", "TAX NO :" + lTransaction.taxNumber);
					}
					//End If
				}
			} else {
				if (!string.IsNullOrEmpty(lTransaction.heading3)) {
					Report.SetParameterValue("txtCompanyDetails2", lTransaction.heading3);
					//If gParameters.tr_PrintInvoice = False Then
					if (!string.IsNullOrEmpty(lTransaction.taxNumber)) {
						Report.SetParameterValue("txtCompanyDetails3", "TAX NO :" + lTransaction.taxNumber);
					}
					//End If

				} else {
					//If gParameters.tr_PrintInvoice = False Then
					if (!string.IsNullOrEmpty(lTransaction.taxNumber)) {
						Report.SetParameterValue("txtCompanyDetails2", "TAX NO :" + lTransaction.taxNumber);
					}
					//End If
				}
			}

			lString = lString + lTransaction.heading1 + Strings.Chr(13);
			lString = lString + lTransaction.heading2 + Strings.Chr(13);
			lString = lString + lTransaction.heading3 + Strings.Chr(13);
			if (!string.IsNullOrEmpty(lTransaction.taxNumber))
				lString = lString + "TAX NO :" + lTransaction.taxNumber;
			lString = Strings.Replace(lString, Strings.Chr(13) + Strings.Chr(13), Strings.Chr(13));
			lString = Strings.Replace(lString, Strings.Chr(13) + Strings.Chr(13), Strings.Chr(13));

			Report.SetParameterValue("txtInvoiceNumber", lTransaction.transactionID);
			Report.SetParameterValue("txtInvoiceDate", Strings.Format(lTransaction.transactionDate, "dd mmm yyyy hh:mm"));
			Report.SetParameterValue("txtPOS", lTransaction.posName);
			Report.SetParameterValue("txtCashier", lTransaction.cashierName);
			if (Strings.LCase(lTransaction.transactionType) == "deposit credit") {
				Report.SetParameterValue("txtType", "DEPOSIT CREDIT");
				Report.SetParameterValue("txtTypeSpecial", "");
				Report.SetParameterValue("txtInvoiceNumber", "[" + lTransaction.transactionID + "]");
			} else {
				if (lTransaction.transactionSpecial_Renamed == null) {
					if (lTransaction.customer_Renamed == null) {
						Report.SetParameterValue("txtCustomer", "Cash Sale");
						switch (lTransaction.paymentType) {
							case Convert.ToString(1):
								Report.SetParameterValue("txtCustomer", "Cash Sale");
								break;
							case Convert.ToString(2):
								Report.SetParameterValue("txtCustomer", "Credit Card Sale");
								break;
							case Convert.ToString(3):
								Report.SetParameterValue("txtCustomer", "Debit Card Sale");
								break;
							case Convert.ToString(4):
								Report.SetParameterValue("txtCustomer", "Cheque Sale");
								break;
							case Convert.ToString(7):
								Report.SetParameterValue("txtCustomer", "Split Tender");
								break;
							default:
								Report.SetParameterValue("txtCustomer", "Cash Sale");
								break;
						}
						Report.SetParameterValue("txtType", "TAX INVOICE");
						Report.SetParameterValue("txtTypeSpecial", "");
					} else {
						Report.SetParameterValue("txtSigned", lTransaction.customer_Renamed.signed_Renamed);
						Report.SetParameterValue("txtCustomer", lTransaction.customer_Renamed.name);
						if (!string.IsNullOrEmpty(lTransaction.customer_Renamed.physical)) {
							lArray = Strings.Split(lTransaction.customer_Renamed.physical, Constants.vbCrLf);
							Report.SetParameterValue("txtCustAddress1", lArray[0]);
							if (Information.UBound(lArray) >= 1)
								Report.SetParameterValue("txtCustAddress2", lArray[1]);
							if (Information.UBound(lArray) >= 2)
								Report.SetParameterValue("txtCustAddress3", lArray[2]);
							if (Information.UBound(lArray) >= 3)
								Report.SetParameterValue("txtCustAddress4", lArray[3]);

						}
						if (!string.IsNullOrEmpty(lTransaction.customer_Renamed.tax))
							Report.SetParameterValue("txtCustAddress5", "TAX NO: " + lTransaction.customer_Renamed.tax);
						//Report.txtCustomerAddress.SetText lTransaction.customer.name & Chr(13) & Chr(13) & Replace(lTransaction.customer.physical, Chr(10), "") & Chr(13) & Chr(13) & "TAX NO: " & lTransaction.customer.tax
						Report.SetParameterValue("txtType", "TAX INVOICE");
						if (lTransaction.customer_Renamed.terms) {
							Report.SetParameterValue("txtTypeSpecial", "Account Sale");
						} else {
							Report.SetParameterValue("txtTypeSpecial", "Cash Sale");
						}
					}
				} else {
					Report.SetParameterValue("txtType", "");
					Report.SetParameterValue("txtTypeSpecial", "");
					if (lPaymentType & typeQuote) {
						Report.SetParameterValue("txtType", "QUOTE");
						if (lPaymentType & typeConsignment) {
							if (lPaymentType & typeAccountSale | lPaymentType & typeAccountSaleCOD) {
								Report.SetParameterValue("txtTypeSpecial", "Account Consignment");
							} else {
								Report.SetParameterValue("txtTypeSpecial", "Consignment");
							}
						} else if (lPaymentType & typeConsignmentReturn) {
							if (lPaymentType & typeAccountSale | lPaymentType & typeAccountSaleCOD) {
								Report.SetParameterValue("txtTypeSpecial", "Account Consignment Return Quote");
							} else {
								Report.SetParameterValue("txtTypeSpecial", "Consignment Return");
							}
						} else {
							if (lPaymentType & typeAccountSale | lPaymentType & typeAccountSaleCOD) {
								Report.SetParameterValue("txtTypeSpecial", "Account");
							} else {
								Report.SetParameterValue("txtTypeSpecial", "");
							}
						}
					} else if (lPaymentType & typeConsignment) {
						if (lPaymentType & typeAccountSale | lPaymentType & typeAccountSaleCOD) {
							Report.SetParameterValue("txtType", "Account Consignment Sale");
						} else {
							Report.SetParameterValue("txtType", "Consignment Sale");
						}
					} else if (lPaymentType & typeConsignmentReturn) {
						if (lPaymentType & typeAccountSale | lPaymentType & typeAccountSaleCOD) {
							Report.SetParameterValue("txtType", "Account Consignment Return");
						} else {
							Report.SetParameterValue("txtType", "Consignment Return");
						}
					} else if (lPaymentType & typeAccountSale) {
						Report.SetParameterValue("txtType", "Account Sale");
					} else if (lPaymentType & typeAccountPayment) {
						Report.SetParameterValue("txtType", "Account Payment");
					}

					if (lTransaction.customer_Renamed == null) {
						if (!string.IsNullOrEmpty(lTransaction.transactionSpecial_Renamed.address)) {
							lArray = Strings.Split(lTransaction.transactionSpecial_Renamed.address, Constants.vbCrLf);
							Report.SetParameterValue("txtCustAddress1", lArray[0]);
							if (Information.UBound(lArray) >= 1)
								Report.SetParameterValue("txtCustAddress2", lArray[1]);
							if (Information.UBound(lArray) >= 2)
								Report.SetParameterValue("txtCustAddress3", lArray[2]);
							if (Information.UBound(lArray) >= 3)
								Report.SetParameterValue("txtCustAddress4", lArray[3]);

						}
						Report.SetParameterValue("txtSigned", lTransaction.transactionSpecial_Renamed.name);
						Report.SetParameterValue("txtCustomer", lTransaction.transactionSpecial_Renamed.name);
					} else {
						if (!string.IsNullOrEmpty(lTransaction.customer_Renamed.tax))
							lTransaction.customer_Renamed.physical = lTransaction.customer_Renamed.physical;
						if (!string.IsNullOrEmpty(lTransaction.customer_Renamed.physical)) {
							lArray = Strings.Split(lTransaction.customer_Renamed.physical, Constants.vbCrLf);
							Report.SetParameterValue("txtCustAddress1", lArray[0]);
							if (Information.UBound(lArray) >= 1)
								Report.SetParameterValue("txtCustAddress2", lArray[1]);
							if (Information.UBound(lArray) >= 2)
								Report.SetParameterValue("txtCustAddress3", lArray[2]);
							if (Information.UBound(lArray) >= 3)
								Report.SetParameterValue("txtCustAddress4", lArray[3]);
						}
						Report.SetParameterValue("txtSigned.", lTransaction.customer_Renamed.signed_Renamed);
						Report.SetParameterValue("txtCustomer", lTransaction.customer_Renamed.name);
					}
				}
			}
			//do report reference.....
			if (!string.IsNullOrEmpty(lTransaction.CardRefer)) {
				Report.SetParameterValue("txtCard", "Card Reference : " + lTransaction.CardRefer);
				//ElseIf gParameters.CardRefer = True Then
				//    Report.txtCard.SetText "Card Reference : " & stCard
			}

			if (!string.IsNullOrEmpty(lTransaction.OrderRefer)) {
				Report.SetParameterValue("txtOrder", "Order Reference : " + lTransaction.OrderRefer);
				//ElseIf gParameters.OrderRefer = True Then
				//    Report.txtOrder.SetText "Order Reference : " & stOrder
			}

			if (!string.IsNullOrEmpty(lTransaction.SerialRefer)) {
				Report.SetParameterValue("txtSerial", "Serial Reference : " + lTransaction.SerialRefer);
				//ElseIf gParameters.SerialRefer = True Then
				//    Report.txtSerial.SetText "Serial Reference : " & stSerial
			}

			Report.SetParameterValue("txtDiscount", Strings.FormatNumber(lTransaction.paymentDiscount, 2));
			//If gParameters.A4Exclusive = True Then
			//   Report.txtAText.SetText FormatNumber(TCurrency - lTransaction.paymentDiscount, 2)
			//End If

			//If frmMain.lblChange.Caption = "" Then frmMain.lblChange.Caption = "0.00"

			if (lPaymentType & typeQuote) {
				Report.SetParameterValue("txtTender", Strings.FormatNumber("0.00", 2));
			} else {
				Report.SetParameterValue("txtTender", Strings.FormatNumber(lTransaction.paymentTender, 2));
				//  lTransaction.paymentTender, 2)
			}
			Report.SetParameterValue("txtVAT", Strings.FormatNumber(lnVat, 2));
			Report.SetParameterValue("txtChange", Strings.FormatNumber("0.00", 2));

			//Report.txtTotal.SetText FormatNumber(lTransaction.paymentTotal, 2)
			if (lPaymentType & typeQuote) {
				//FIXED: it was calculating twice    Report.txtTotal.SetText FormatNumber((QuoteTotal - lTransaction.paymentDiscount), 2)
				Report.SetParameterValue("txtTotal", Strings.FormatNumber(QuoteTotal, 2));
				//a = QuoteTotal
			} else {
				Report.SetParameterValue("txtTotal", Strings.FormatNumber(lTransaction.paymentTotal, 2));
			}

			if (lPaymentType & typeQuote | lPaymentType & typeConsignment | lPaymentType & typeConsignmentReturn | lPaymentType & typeAccountSale) {
				Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = true;
			}

			//New banking details
			ADODB.Recordset rsCompBank = default(ADODB.Recordset);
			rsCompBank = modRecordSet.getRS(ref "select * from Company;");
			if (rsCompBank.RecordCount) {
				if (Information.IsDBNull(rsCompBank.Fields("Company_BankName").Value)) {
				} else {
					Report.SetParameterValue("txtBankName", rsCompBank.Fields("Company_BankName"));
				}
				if (Information.IsDBNull(rsCompBank.Fields("Company_BranchName").Value)) {
				} else {
					Report.SetParameterValue("txtBranchName", rsCompBank.Fields("Company_BranchName"));
				}
				if (Information.IsDBNull(rsCompBank.Fields("Company_BranchCode").Value)) {
				} else {
					Report.SetParameterValue("txtBranchCode", rsCompBank.Fields("Company_BranchCode"));
				}
				if (Information.IsDBNull(rsCompBank.Fields("Company_AccountNumber").Value)) {
				} else {
					Report.SetParameterValue("txtAccountNumber", rsCompBank.Fields("Company_AccountNumber"));
				}
			}
			//...................

			//Report.selectPrinter "", Printer.DeviceName, ""
			//'Report.VerifyOnEveryPrint = True
			//Report.PrintOut False
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			My.MyProject.Forms.frmReportShow.ShowDialog();

			return;
			ptA4:
			Interaction.MsgBox(Err().Number + Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

		}
	}
}
