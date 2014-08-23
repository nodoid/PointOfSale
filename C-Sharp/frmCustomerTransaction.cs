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
	internal partial class frmCustomerTransaction : System.Windows.Forms.Form
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
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();
		int gID;
		short gSection;

		const short sec_Payment = 0;
		const short sec_Debit = 1;

		const short sec_Credit = 2;
		private void loadLanguage()
		{

			//frmCustomerTransaction= No Code    [Customer Transaction]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCustomerTransaction.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerTransaction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1290;
			//Email|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_10.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_10.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1319;
			//Financials|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1293;
			//Credit Limit|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1295;
			//Current|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1297;
			//60 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1299;
			//120 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_17.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_17.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1296;
			//30 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1298;
			//90 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1300;
			//150 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_18.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_18.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code                   [Transaction]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1327;
			//Narrative|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1328;
			//Notes|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1329;
			//Amount|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1330;
			//Settlement|Checked
			if (modRecordSet.rsLang.RecordCount){lblSett.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblSett.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1331;
			//Settlement|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1332;
			//Process|Checked
			if (modRecordSet.rsLang.RecordCount){cmdProcess.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdProcess.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCustomerTransaction.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//doDataControl(Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name")
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//	rs = getRS(sql)
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//	dataControl.DataSource = rs
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//	dataControl.DataSource = adoPrimaryRS
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//	dataControl.DataField = DataField
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//	dataControl.boundColumn = boundColumn
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//	dataControl.listField = listField
		}

		public void loadItem(ref int id, ref short section)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			this.lblSett.Visible = true;
			this.txtSettlement.Visible = true;

			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Customer WHERE CustomerID = " + id);
			} else {
				this.Close();
				return;
			}
			gSection = section;
			switch (gSection) {
				case sec_Payment:
					this.Text = "Account Payment";
					break;
				case sec_Debit:
					this.lblSett.Visible = false;
					this.txtSettlement.Visible = false;
					this.Text = "Debit Journal-Increase amount owing";
					break;
				case sec_Credit:
					this.lblSett.Visible = false;
					this.txtSettlement.Visible = false;
					this.Text = "Credit Journal-Decrease amount owing";
					break;
				default:
					this.Close();
					return;

					break;
			}
			_lbl_2.Text = "&3. Transaction (" + this.Text + ")";
			//    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
			//    Else
			BindingSource bind = new BindingSource();
			bind.DataSource = adoPrimaryRS;

			foreach (TextBox oText_loopVariable in this.txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(bind.DataSource);
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
				//txtFloat_Leave(txtFloat.Item((oText.TabIndex)), New System.EventArgs())
			}
			//Bind the check boxes to the data provider
			//        For Each oCheck In Me.chkFields
			//            Set oCheck.DataBindings.Add(adoPrimaryRS)
			//        Next
			buildDataControls();
			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
			//    End If
		}

		private void cmdProcess_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			decimal amount = default(decimal);
			string sql = null;
			string sql1 = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string id = null;
			decimal days120 = default(decimal);
			decimal days60 = default(decimal);
			decimal current = default(decimal);
			decimal days30 = default(decimal);
			decimal days90 = default(decimal);
			decimal days150 = default(decimal);
			System.Windows.Forms.Application.DoEvents();
			if (string.IsNullOrEmpty(txtNarrative.Text)) {
				Interaction.MsgBox("Narrative is a mandarory field", MsgBoxStyle.Exclamation, this.Text);
				txtNarrative.Focus();
				return;
			}
			if (Convert.ToDecimal(txtAmount.Text) == 0) {
				Interaction.MsgBox("Amount is a mandarory field", MsgBoxStyle.Exclamation, this.Text);
				txtAmount.Focus();
				return;
			}

			sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )";
			switch (gSection) {
				case sec_Payment:
					sql = sql + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS description, " + Convert.ToDecimal(0 - Convert.ToDecimal(this.txtAmount.Text)) + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
				case sec_Debit:
					sql = sql + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, 4 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS description, " + Convert.ToDecimal(this.txtAmount.Text) + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
				case sec_Credit:
					sql = sql + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS description, " + Convert.ToDecimal(0 - Convert.ToDecimal(this.txtAmount.Text)) + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
					break;
			}

			modRecordSet.cnnDB.Execute(sql);

			rs = modRecordSet.getRS(ref "SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction");
			if (rs.BOF | rs.EOF) {
			} else {
				id = rs.Fields("id").Value;
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_Current) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_30Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_60Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_90Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_120Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_150Days) Is Null));");

				rs = modRecordSet.getRS(ref "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " + id + "));");

				amount = rs.Fields("CustomerTransaction_Amount").Value;
				current = rs.Fields("Customer_Current").Value;
				days30 = rs.Fields("Customer_30Days").Value;
				days60 = rs.Fields("Customer_60Days").Value;
				days90 = rs.Fields("Customer_90Days").Value;
				days120 = rs.Fields("Customer_120Days").Value;
				days150 = rs.Fields("Customer_150Days").Value;
				if (amount < 0) {
					days150 = days150 + amount;
					if ((days150 < 0)) {
						amount = days150;
						days150 = 0;
					} else {
						amount = 0;
					}
					days120 = days120 + amount;
					if ((days120 < 0)) {
						amount = days120;
						days120 = 0;
					} else {
						amount = 0;
					}
					days90 = days90 + amount;
					if ((days90 < 0)) {
						amount = days90;
						days90 = 0;
					} else {
						amount = 0;
					}
					days60 = days60 + amount;
					if ((days60 < 0)) {
						amount = days60;
						days60 = 0;
					} else {
						amount = 0;
					}
					days30 = days30 + amount;
					if ((days30 < 0)) {
						amount = days30;
						days30 = 0;
					} else {
						amount = 0;
					}
				}
				current = current + amount;
				modRecordSet.cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " + current + ", Customer.Customer_30Days = " + days30 + ", Customer.Customer_60Days = " + days60 + ", Customer.Customer_90Days = " + days90 + ", Customer.Customer_120Days = " + days120 + ", Customer.Customer_150Days = 0" + days150 + " WHERE (((Customer.CustomerID)=" + rs.Fields("CustomerTransaction_CustomerID").Value + "));");
			}


			if (Conversion.Val(txtSettlement.Text) > 0) {
				sql1 = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )";
				sql1 = sql1 + "SELECT " + adoPrimaryRS.Fields("CustomerID").Value + " AS Customer, 8 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS description, " + Convert.ToDecimal(0 - Convert.ToDecimal(this.txtSettlement.Text)) + " AS amount,'" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "', 'System' AS person FROM Company;";

				modRecordSet.cnnDB.Execute(sql1);

				rs = modRecordSet.getRS(ref "SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction");

				if (rs.BOF | rs.EOF) {
				} else {
					id = rs.Fields("id").Value;
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_Current) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_30Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_60Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_90Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_120Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_150Days) Is Null));");

					rs = modRecordSet.getRS(ref "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " + id + "));");
					amount = rs.Fields("CustomerTransaction_Amount").Value;
					current = rs.Fields("Customer_Current").Value;
					days30 = rs.Fields("Customer_30Days").Value;
					days60 = rs.Fields("Customer_60Days").Value;
					days90 = rs.Fields("Customer_90Days").Value;
					days120 = rs.Fields("Customer_120Days").Value;
					days150 = rs.Fields("Customer_150Days").Value;

					if (amount < 0) {
						days150 = days150 + amount;
						if ((days150 < 0)) {
							amount = days150;
							days150 = 0;
						} else {
							amount = 0;
						}

						days120 = days120 + amount;
						if ((days120 < 0)) {
							amount = days120;
							days120 = 0;
						} else {
							amount = 0;
						}

						days90 = days90 + amount;
						if ((days90 < 0)) {
							amount = days90;
							days90 = 0;
						} else {
							amount = 0;
						}

						days60 = days60 + amount;
						if ((days60 < 0)) {
							amount = days60;
							days60 = 0;
						} else {
							amount = 0;
						}

						days30 = days30 + amount;
						if ((days30 < 0)) {
							amount = days30;
							days30 = 0;
						} else {
							amount = 0;
						}
					}
					//current = amount
					current = current + amount;
					modRecordSet.cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " + current + ", Customer.Customer_30Days = " + days30 + ", Customer.Customer_60Days = " + days60 + ", Customer.Customer_90Days = " + days90 + ", Customer.Customer_120Days = " + days120 + ", Customer.Customer_150Days = 0" + days150 + " WHERE (((Customer.CustomerID)=" + rs.Fields("CustomerTransaction_CustomerID").Value + "));");
				}
			}

			cmdStatement_Click(cmdStatement, new System.EventArgs());
			this.Close();

		}
		private void cmdProcess_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtTotalAmount.Text = Strings.FormatNumber(Convert.ToDecimal(txtAmount.Text) + Convert.ToDecimal(txtSettlement.Text), 2);
		}

		private void cmdStatement_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_CustomerStatement(ref adoPrimaryRS.Fields("CustomerID").Value);
		}

		private void frmCustomerTransaction_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Button cmdLast = new System.Windows.Forms.Button();
			System.Windows.Forms.Button cmdNext = new System.Windows.Forms.Button();
			System.Windows.Forms.Label lblStatus = new System.Windows.Forms.Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.twipsToPixels(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmCustomerTransaction_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
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

		private void frmCustomerTransaction_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			System.Windows.Forms.TextBox oText = null;
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
					oText.Leave += txtFloat_Leave;
					//txtFloat_Leave(txtFloat.Item(oText.TabIndex), New System.EventArgs())
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			return functionReturnValue;
			//    If _txtFields_2.Text = "" Then
			//        _txtFields_2.Text = "[Customer]"
			//    End If

			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = false;
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

		private void txtAmount_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtAmount);
		}

		private void txtAmount_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtAmount_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtAmount, ref 2);
		}
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtFields.GetIndex(eventSender)
			int t = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			t = GetIndex.GetIndexer(ref n, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[t]);
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
			//Dim Index As Short = txtFloat.GetIndex(eventSender)
			int t = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			t = GetIndex.GetIndexer(ref n, ref txtFloat);
			modUtilities.MyGotFocusNumeric(ref txtFloat[t]);
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
			//Dim Index As Short = txtFloat.GetIndex(eventSender)
			int t = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			t = GetIndex.GetIndexer(ref n, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[t], ref 2);
		}

		private void txtNarrative_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtNarrative);
		}

		private void txtNotes_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtNotes);
		}
		private void txtSettlement_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtSettlement);
		}

		private void txtSettlement_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtSettlement_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtSettlement, ref 2);

		}
	}
}
