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
	internal partial class frmPersonFPReg : System.Windows.Forms.Form
	{
		private DPSDKOPSLib.FPRegisterTemplate withEventsField_op;
		public DPSDKOPSLib.FPRegisterTemplate op {
			get { return withEventsField_op; }
			set {
				if (withEventsField_op != null) {
					withEventsField_op.Done -= op_Done;
					withEventsField_op.SampleQuality -= op_SampleQuality;
					withEventsField_op.SampleReady -= op_SampleReady;
				}
				withEventsField_op = value;
				if (withEventsField_op != null) {
					withEventsField_op.Done += op_Done;
					withEventsField_op.SampleQuality += op_SampleQuality;
					withEventsField_op.SampleReady += op_SampleReady;
				}
			}
		}
		short cursample;
		DpSdkEngLib.FPTemplate register;

		bool loading;
		short gID;
		short gLastIndex;
		List<Label> Label6 = new List<Label>();
		List<PictureBox> picSample = new List<PictureBox>();
		private void loadLanguage()
		{

			//frmPersonFPReg = No Code   [Registration Form]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPersonFPReg.Caption = rsLang("LanguageLayoutLnk_Description"): frmPersonFPReg.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [Press Start Button to Start]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//eName = No Code/Dynamic!

			//Label1 = No Code           [Quality]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2496;
			//Start|
			if (modRecordSet.rsLang.RecordCount){start_cmd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;start_cmd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Command1 = No Code         [Verify]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code           [Events]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPersonFPReg.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;

			loading = true;
			gID = id;
			//Set rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
			rs = modRecordSet.getRS(ref "SELECT * FROM Person WHERE PersonID = " + id);

			eName.Text = "Finger Print Registration for -> " + Strings.UCase(rs.Fields("Person_LastName").value);
			//& ""
			eName.Refresh();

			rs = modRecordSet.getRS(ref "SELECT * FROM PersonFPLnk WHERE PersonID = " + id);
			if (rs.RecordCount > 0) {
				Label3.Text = "You already have Finger Prints saved.";
			} else {

			}

			loading = false;

			loadLanguage();
			this.ShowDialog();

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void Save_and_Load_Verify_Form()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			object blob_write = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			object bvariant = null;
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			//UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			blob_write = System.DBNull.Value;
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			//UPGRADE_WARNING: Couldn't resolve default property of object bvariant. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			bvariant = System.DBNull.Value;

			if (register == null) {
				lblEvents.Text = "";
				Interaction.MsgBox("Nothing Registered !!");
				return;
			}

			register.Export(bvariant);
			//UPGRADE_WARNING: Couldn't resolve default property of object bvariant. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			blob_write = bvariant;

			rs = modRecordSet.getRS(ref "SELECT * FROM PersonFPLnk WHERE PersonID = " + gID);
			//UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (rs.RecordCount > 0) {
				//cnnDB.Execute "UPDATE PersonFPLnk SET PersonFPLnk.Person_FP = " & blob_write & " WHERE (((PersonFPLnk.PersonID)=" & gID & "));"
				//rs.AddNew
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs("PersonID").Value = gID;
				//UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs("Person_FP").Value = blob_write;
				//UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs.update();
			} else {
				//cnnDB.Execute "INSERT INTO PersonFPLnk (PersonID, Person_FP) VALUES (" & gID & ", " & blob_write & ")"
				//UPGRADE_WARNING: Couldn't resolve default property of object rs.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs.AddNew();
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs("PersonID").Value = gID;
				//UPGRADE_WARNING: Couldn't resolve default property of object blob_write. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs("Person_FP").Value = blob_write;
				//UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs.update();
			}

			//reslt = MsgBox("Wana do more registerations !! ? ", vbYesNo, "More Registrations ?")
			//If reslt = 6 Then
			// eName.Text = ""
			// eName.Refresh
			// Label3.Caption = "Before Putting finger on the senser - Enter New Name -> "
			// Label3.Refresh
			// Call start_cmd_Click
			//Else
			My.MyProject.Forms.frmPersonFPVerify.loadItem(ref (gID));
			//End If

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


			My.MyProject.Forms.frmPersonFPVerify.loadItem(ref (gID));

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void frmPersonFPReg_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			Label6.AddRange(new Label[] {
				_Label6_0,
				_Label6_1,
				_Label6_2,
				_Label6_3
			});
			picSample.AddRange(new PictureBox[] {
				_picSample_0,
				_picSample_1,
				_picSample_2,
				_picSample_3
			});

			int i = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			//If cnx Is Nothing And rs Is Nothing Then
			//Set cnx = New Connection
			//Set rs = New Recordset
			//End If
			//cnx.Open "sdb", "", ""
			//rs.Open "select * from empl", cnx, adOpenKeyset, adLockOptimistic

			cursample = 0;

			op = new DPSDKOPSLib.FPRegisterTemplate();
			for (i = 0; i <= 3; i++) {
				//UPGRADE_NOTE: Object picSample().Picture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				picSample[i].Image = null;
				Label6[i].Visible = false;
			}

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
			 // ERROR: Not supported in C#: OnErrorStatement


			lblEvents.Text = "";
			//UPGRADE_NOTE: Object register may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			register = null;
			register = pTemplate;
			Interaction.MsgBox("Registration Process is Done. Please wait while system verify and save information...");
			Save_and_Load_Verify_Form();

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void op_SampleQuality(DpSdkEngLib.AISampleQuality Quality)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			switch (Quality) {
				case DpSdkEngLib.AISampleQuality.Sq_Good:
					lblQuality.Text = "OK";
					cursample = cursample + 1;
					Label6[cursample - 1].Visible = false;
					if (cursample != 4) {
						Label6[cursample].Visible = true;
					}
					break;
				case DpSdkEngLib.AISampleQuality.Sq_LowContrast:
					lblQuality.Text = "Bad Quality";
					break;
				case DpSdkEngLib.AISampleQuality.Sq_NoCentralRegion:
					lblQuality.Text = "Bad Quality";
					break;
				case DpSdkEngLib.AISampleQuality.Sq_None:
					lblQuality.Text = "Bad Quality";
					break;
				case DpSdkEngLib.AISampleQuality.Sq_NotEnoughFtr:
					lblQuality.Text = "Bad Quality";
					//
					break;
				case DpSdkEngLib.AISampleQuality.Sq_TooDark:
					lblQuality.Text = "Too Dark";
					break;
				case DpSdkEngLib.AISampleQuality.Sq_TooLight:
					lblQuality.Text = "Too Light";
					break;
				case DpSdkEngLib.AISampleQuality.Sq_TooNoisy:
					lblQuality.Text = "Too Noisy";
					break;
			}
			lblEvents.Text = "";

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


			if (cursample < 3) {
				Label3.Text = "Yes, put your finger again on the sensor for sample #" + Conversion.Str(cursample + 1);
				Label3.Refresh();
			} else {
				Label3.Text = "Wait for the Verify form";
				Label3.Refresh();
				this.Cursor = System.Windows.Forms.Cursors.Cross;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureOrientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			pSample.PictureOrientation = DpSdkEngLib.AIOrientation.Or_Portrait;
			//UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			pSample.PictureWidth = sizeConvertors.pixelToTwips(picSample[cursample].Width, true) / sizeConvertors.twipsPerPixel(true);
			//UPGRADE_WARNING: Couldn't resolve default property of object pSample.PictureHeight. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			pSample.PictureHeight = sizeConvertors.pixelToTwips(picSample[cursample].Height, false) / sizeConvertors.twipsPerPixel(false);
			//UPGRADE_WARNING: Couldn't resolve default property of object pSample.Picture. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			picSample[cursample].Image = pSample.Picture;
			lblEvents.Text = "Sample ready";

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void picSample_Click(System.Object eventSender, KeyEventArgs eventArgs)
		{
			int Index = 0;
			PictureBox pbox = new PictureBox();
			pbox = (PictureBox)eventSender;
			Index = GetIndex.GetIndexer(ref pbox, ref picSample);
			 // ERROR: Not supported in C#: OnErrorStatement


			short i = 0;
			cursample = 0;
			for (i = 0; i <= 3; i++) {
				//UPGRADE_NOTE: Object picSample().Picture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				picSample[i].Image = null;
				Label6[i].Visible = false;
			}
			Label6[cursample].Visible = true;
			//UPGRADE_NOTE: Object op may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			op = null;
			op = new DPSDKOPSLib.FPRegisterTemplate();
			op.Run();
			lblQuality.Text = "";
			lblEvents.Text = "";

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void start_cmd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//eName.Text = ""
			//eName.Refresh
			Label3.Text = "Put your finger on the senser 4 times -> ";
			Label3.Refresh();
			picSample_Click(picSample[0], new System.EventArgs());

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
