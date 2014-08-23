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
	internal partial class frmSupplierTransaction : System.Windows.Forms.Form
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
		short gSection;

		const short sec_Payment = 0;
		const short sec_Debit = 1;

		const short sec_Credit = 2;
		List<TextBox> txtFields = new List<TextBox>();

		List<TextBox> txtFloat = new List<TextBox>();
		private void loadLanguage()
		{

			//frmSupplierTransaction = No Code   [Supplier Transaction]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSupplierTransaction.Caption = rsLang("LanguageLayoutLnk_Description"): frmSupplierTransaction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1282;
			//Statement|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStatement.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStatement.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1442;
			//Supplier Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1448;
			//Aging|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1295;
			//Current|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1297;
			//60 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1299;
			//120 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_17.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_17.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1296;
			//30 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1298;
			//90 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1496;
			//Period|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code
			//DB Entry 2406 closest match, but grammar wrong for use!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1327;
			//Narrative|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1328;
			//Notes|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1499;
			//Amount Paid|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1330;
			//Settlement|Checked
			if (modRecordSet.rsLang.RecordCount){lblSettl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblSettl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1331;
			//Total Amount|Checked
			if (modRecordSet.rsLang.RecordCount){Label3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1332;
			//Process|Checked
			if (modRecordSet.rsLang.RecordCount){cmdProcess.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdProcess.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSupplierTransaction.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		}

		private void doDataControl(ref System.Windows.Forms.Control dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//rs = getRS(sql)
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataSource = rs
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataBindings.Add(adoPrimaryRS)
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataField = DataField
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.boundColumn = boundColumn
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.listField = listField
		}
		public void loadItem(ref int id, ref short section)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			this.lblSettl.Visible = true;
			this.txtSettlement.Visible = true;

			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select SupplierID,Supplier_Name,Supplier_PostalAddress,Supplier_PhysicalAddress,Supplier_Telephone,Supplier_Facimile,Supplier_RepresentativeName,Supplier_RepresentativeNumber,Supplier_ShippingCode,Supplier_OrderAttentionLine,Supplier_Ullage,Supplier_discountCOD,Supplier_discount15days,Supplier_discount30days,Supplier_discount60days,Supplier_discount90days,Supplier_discount120days,Supplier_discountSmartCard,Supplier_discountDefault,Supplier_Current,Supplier_30Days,Supplier_60Days,Supplier_90Days,Supplier_120Days from Supplier WHERE SupplierID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Supplier");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				mbAddNewFlag = true;
			}
			gSection = section;
			switch (gSection) {
				case sec_Payment:
					this.Text = "Account Payment";
					break;
				case sec_Debit:
					this.lblSettl.Visible = false;
					this.txtSettlement.Visible = false;
					this._lblLabels_11.Text = "Debit Journal";
					this.Text = "Debit Journal-Increase amount owing";
					break;
				case sec_Credit:
					this.lblSettl.Visible = false;
					this.txtSettlement.Visible = false;
					this._lblLabels_11.Text = "Credit Journal";
					this.Text = "Credit Journal-Decrease amount owing";
					break;
				default:
					this.Close();
					return;

					break;
			}
			_lbl_2.Text = "&2. Transaction (" + this.Text + ")";
			this.cmbPeriod.SelectedIndex = 0;
			//    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
			//    Else
			foreach (TextBox oText_loopVariable in this.txtFields) {
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
			}
			//        For Each oText In Me.txtFloatNegative
			//            Set oText.DataBindings.Add(adoPrimaryRS)
			//            If oText.Text = "" Then oText.Text = "0"
			//            oText.Text = oText.Text * 100
			//            txtFloatNegative_LostFocus oText.Index
			//        Next
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
			int days150 = 0;
			int days120 = 0;
			int days90 = 0;
			int days60 = 0;
			int days30 = 0;
			int current = 0;
			int amount = 0;
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string id = null;
			decimal lAmount = default(decimal);
			string lField = null;
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
			sql = "INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) ";
			switch (gSection) {
				case sec_Payment:
					lAmount = Convert.ToDecimal(0 - Convert.ToDecimal(this.txtAmount.Text));
					sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 3 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
					break;
				case sec_Debit:
					lAmount = Convert.ToDecimal(this.txtAmount.Text);
					sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 4 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
					break;
				case sec_Credit:
					lAmount = Convert.ToDecimal(0 - Convert.ToDecimal(this.txtAmount.Text));
					sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 5 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
					break;
			}
			modRecordSet.cnnDB.Execute(sql);

			rs = modRecordSet.getRS(ref "SELECT MAX(SupplierTransactionID) AS id From SupplierTransaction");
			if (rs.BOF | rs.EOF) {
			} else {
				id = rs.Fields("id").Value;
				modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_Current = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_Current) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_30Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_30Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_60Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_60Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_90Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_90Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_120Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_120Days) Is Null));");
				//cnnDB.Execute "UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Customer_150Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_150Days) Is Null));"

				//Set rs = getRS("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days, Supplier.Supplier_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")
				rs = modRecordSet.getRS(ref "SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days FROM Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID Where (((SupplierTransaction.SupplierTransactionID) = " + id + "));");
				amount = rs.Fields("SupplierTransaction_Amount").Value;
				current = rs.Fields("Supplier_Current").Value;
				days30 = rs.Fields("Supplier_30Days").Value;
				days60 = rs.Fields("Supplier_60Days").Value;
				days90 = rs.Fields("Supplier_90Days").Value;
				days120 = rs.Fields("Supplier_120Days").Value;
				//days150 = rs("Supplier_150Days")
				days150 = 0;
				//MsgBox amount & " - " & current & " - " & days30 & " - " & days60 & " - " & days90 & " - " & days120 & " - " & days150

				switch (Convert.ToInt32(cmbPeriod.SelectedIndex)) {
					case 0:
						lField = "Supplier_Current";
						current = current + amount;

						break;
					case 1:
						lField = "Supplier_30Days";
						if (amount < 0) {
							days30 = days30 + amount;
							if ((days30 < 0)) {
								amount = days30;
								days30 = 0;
							} else {
								amount = 0;
							}
						}
						current = current + amount;

						break;
					case 2:
						lField = "Supplier_60Days";
						if (amount < 0) {
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

						break;
					case 3:
						lField = "Supplier_90Days";
						if (amount < 0) {
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

						break;
					case 4:
						lField = "Supplier_120Days";
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

						break;
				}
				//cnnDB.Execute "UPDATE Supplier SET Supplier." & lField & " = [Supplier]![" & lField & "]+(" & lAmount & ") WHERE (((Supplier.SupplierID)=" & adoPrimaryRS("SupplierID") & "));"
				//MsgBox current & " - " & days30 & " - " & days60 & " - " & days90 & " - " & days120 & " - " & days150
				modRecordSet.cnnDB.Execute("UPDATE Supplier SET Supplier.Supplier_Current = " + current + ", Supplier.Supplier_30Days = " + days30 + ", Supplier.Supplier_60Days = " + days60 + ", Supplier.Supplier_90Days = " + days90 + ", Supplier.Supplier_120Days = " + days120 + " WHERE (((Supplier.SupplierID)=" + rs.Fields("SupplierTransaction_SupplierID").Value + "));");
			}

			if (Conversion.Val(txtSettlement.Text) != 0) {
				sql = "INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) ";
				switch (gSection) {
					case sec_Payment:
						lAmount = Convert.ToDecimal(0 - Convert.ToDecimal(this.txtSettlement.Text));
						sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 8 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
						break;
					case sec_Debit:
						lAmount = Convert.ToDecimal(this.txtSettlement.Text);
						sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 8 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
						break;
					case sec_Credit:
						lAmount = Convert.ToDecimal(0 - Convert.ToDecimal(this.txtSettlement.Text));
						sql = sql + "SELECT " + adoPrimaryRS.Fields("SupplierID").Value + " AS supplier, " + modRecordSet.gPersonID + " AS person, 8 AS transType, Company.Company_MonthEndID, " + this.cmbPeriod.SelectedIndex + " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" + Strings.Replace(this.txtNotes.Text, "'", "''") + "' AS notes, " + lAmount + " AS amount, '" + Strings.Replace(this.txtNarrative.Text, "'", "''") + "' AS reference FROM Company;";
						break;
				}
				modRecordSet.cnnDB.Execute(sql);

				rs = modRecordSet.getRS(ref "SELECT MAX(SupplierTransactionID) AS id From SupplierTransaction");
				if (rs.BOF | rs.EOF) {
				} else {
					id = rs.Fields("id").Value;
					modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_Current = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_Current) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_30Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_30Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_60Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_60Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_90Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_90Days) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_120Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" + id + ") AND ((Supplier.Supplier_120Days) Is Null));");

					rs = modRecordSet.getRS(ref "SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days FROM Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID Where (((SupplierTransaction.SupplierTransactionID) = " + id + "));");
					amount = rs.Fields("SupplierTransaction_Amount").Value;
					current = rs.Fields("Supplier_Current").Value;
					days30 = rs.Fields("Supplier_30Days").Value;
					days60 = rs.Fields("Supplier_60Days").Value;
					days90 = rs.Fields("Supplier_90Days").Value;
					days120 = rs.Fields("Supplier_120Days").Value;
					days150 = 0;

					switch (Convert.ToInt32(cmbPeriod.SelectedIndex)) {
						case 0:
							lField = "Supplier_Current";
							current = current + amount;

							break;
						case 1:
							lField = "Supplier_30Days";
							if (amount < 0) {
								days30 = days30 + amount;
								if ((days30 < 0)) {
									amount = days30;
									days30 = 0;
								} else {
									amount = 0;
								}
							}
							current = current + amount;

							break;
						case 2:
							lField = "Supplier_60Days";
							if (amount < 0) {
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

							break;
						case 3:
							lField = "Supplier_90Days";
							if (amount < 0) {
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

							break;
						case 4:
							lField = "Supplier_120Days";
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

							break;
					}
					modRecordSet.cnnDB.Execute("UPDATE Supplier SET Supplier.Supplier_Current = " + current + ", Supplier.Supplier_30Days = " + days30 + ", Supplier.Supplier_60Days = " + days60 + ", Supplier.Supplier_90Days = " + days90 + ", Supplier.Supplier_120Days = " + days120 + " WHERE (((Supplier.SupplierID)=" + rs.Fields("SupplierTransaction_SupplierID").Value + "));");
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
			modApplication.report_SupplierStatement(ref adoPrimaryRS.Fields("SupplierID").Value);
		}

		private void frmSupplierTransaction_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_2,
				_txtFields_6,
				_txtFields_7,
				_txtFields_8,
				_txtFields_9
			});
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_13,
				_txtFloat_14,
				_txtFloat_15,
				_txtFloat_16,
				_txtFloat_17
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

//UPGRADE_WARNING: Event frmSupplierTransaction.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmSupplierTransaction_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmSupplierTransaction_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
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

		private void frmSupplierTransaction_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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


		private void cmdCancel_Click()
		{
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

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtFields);
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
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtFloat);
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
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}

		private void txtFloatNegative_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloatNegative(Index)
		}

		private void txtFloatNegative_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPressNegative txtFloatNegative(Index), KeyAscii
		}

		private void txtFloatNegative_MyLostFocus(ref short Index)
		{
			//    LostFocus txtFloatNegative(Index), 2
		}

		private void txtNarrative_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtNarrative);
		}

		private void txtNotes_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtNotes);
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
