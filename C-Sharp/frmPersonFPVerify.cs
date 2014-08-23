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
	internal partial class frmPersonFPVerify : System.Windows.Forms.Form
	{
		private DPSDKOPSLib.FPGetTemplate withEventsField_op;
		private DPSDKOPSLib.FPGetTemplate op {
			get { return withEventsField_op; }
			set {
				if (withEventsField_op != null) {
					withEventsField_op.Done -= op_Done;
					withEventsField_op.SampleReady -= op_SampleReady;
				}
				withEventsField_op = value;
				if (withEventsField_op != null) {
					withEventsField_op.Done += op_Done;
					withEventsField_op.SampleReady += op_SampleReady;
				}
			}
		}
		DpSdkEngLib.FPTemplate tp;
		ADODB.Connection cnx1 = new ADODB.Connection();
		ADODB.Recordset rs1 = new ADODB.Recordset();
		DpSdkEngLib.FPVerify vp;
		float nStartTimer;
		float nEndTimer;

		bool loading;
		short gID;
		short gLastIndex;

		private void loadLanguage()
		{

			//frmPersonFPVerify = No Code    [Verify Form]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPersonFPVerify.Caption = rsLang("LanguageLayoutLnk_Description"): frmPersonFPVerify.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//eName = No Code / Dynamic!

			//Label1 = No Code               [Please put your finger on the sensor...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code             [Verify Again?]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPersonFPVerify.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			this.Close();

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		public void loadItem(ref int id)
		{

			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;

			 // ERROR: Not supported in C#: OnErrorStatement

			loading = true;
			gID = id;
			//Set rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
			rs = modRecordSet.getRS(ref "SELECT * FROM Person WHERE PersonID = " + id);

			eName.Text = "Finger Print Verfication for -> " + Strings.UCase(rs.Fields("Person_LastName").value);
			//& ""
			eName.Refresh();

			//Set rs = getRS("SELECT * FROM PersonFPLnk WHERE PersonID = " & id)
			//If rs.RecordCount > 0 Then
			//Label3 = "You already have Finger Prints saved."
			//Else
			//
			//End If

			loading = false;

			loadLanguage();
			this.ShowDialog();

			Command1_Click(Command1, new System.EventArgs());

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}


		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//   If tName.Text = "" Then
			//     MsgBox "Enter user name "
			//     Exit Sub
			//   End If

			if (op == null) {
				op = new DPSDKOPSLib.FPGetTemplate();
			}
			op.Run();

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void frmPersonFPVerify_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//frmVerify.show 1

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void frmPersonFPVerify_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//rs.Close
			//cnx.Close
			//UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			op = null;
			//UPGRADE_NOTE: Object vp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			vp = null;

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void op_Done(object pTemplate)
		{
			object re = null;
			object thsh = null;
			object src = null;
			object er = null;
			object varnt = null;
			object blob_read = null;
			object rs = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			tp = pTemplate;
			DpSdkEngLib.FPTemplate rp = default(DpSdkEngLib.FPTemplate);

			op = new DPSDKOPSLib.FPGetTemplate();
			vp = new DpSdkEngLib.FPVerify();

			bool result = false;
			object strHex = null;
			string strTemp = null;
			short rno = 0;

			rno = 1;
			result = false;

			rs = modRecordSet.getRS(ref "SELECT * FROM PersonFPLnk WHERE PersonID = " + gID);
			//UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (rs.RecordCount > 0) {

				//Label3 = "You already have Finger Prints saved."
				//rs.Find "employee_name = '" + tName.Text + "'"
				//If rs.EOF = False Then
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object blob_read. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				blob_read = rs("Person_FP");
				//UPGRADE_WARNING: Couldn't resolve default property of object blob_read. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object varnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				varnt = blob_read;
				rp = new DpSdkEngLib.FPTemplate();
				//UPGRADE_WARNING: Couldn't resolve default property of object er. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				er = rp.import(varnt);
				//UPGRADE_WARNING: Couldn't resolve default property of object re. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				re = vp.Compare(rp, pTemplate, result, src, thsh, false, DpSdkEngLib.AISecureModeMask.Sm_None);
				//UPGRADE_NOTE: Object rp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rp = null;
				//End If

			} else {

			}


			if (result == true) {
				Label1.Text = "Passed !!! Finger prints matched ";
				Label1.Refresh();
				Interaction.MsgBox("Finger print matched.");
				//+ rs("employee_name")
			} else {
				Label1.Text = "Failed !!! Finger prints NOT matched";
				Label1.Refresh();
				Interaction.MsgBox("No finger print match found !");
			}

			//UPGRADE_NOTE: Object rp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rp = null;
			//UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			op = null;
			//UPGRADE_NOTE: Object vp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			vp = null;

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void op_SampleReady(object pSample)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			pSample.PictureOrientation = DpSdkEngLib.AIOrientation.Or_Portrait;
			pSample.PictureWidth = sizeConvertors.pixelToTwips(Picture1.Width, true) / sizeConvertors.twipsPerPixel(true);
			pSample.PictureHeight = sizeConvertors.pixelToTwips(Picture1.Height, false) / sizeConvertors.twipsPerPixel(false);
			Picture1.Image = pSample.Picture;

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}
	}
}
