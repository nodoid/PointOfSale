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
	internal partial class frmPersonFPRegOT : System.Windows.Forms.Form
	{
//UPGRADE_NOTE: Capture was upgraded to Capture_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private DPFPDevXLib.DPFPCapture withEventsField_Capture_Renamed;
		public DPFPDevXLib.DPFPCapture Capture_Renamed {
			get { return withEventsField_Capture_Renamed; }
			set {
				if (withEventsField_Capture_Renamed != null) {
					withEventsField_Capture_Renamed.OnReaderConnect -= Capture_Renamed_OnReaderConnect;
					withEventsField_Capture_Renamed.OnReaderDisconnect -= Capture_Renamed_OnReaderDisconnect;
					withEventsField_Capture_Renamed.OnFingerTouch -= Capture_Renamed_OnFingerTouch;
					withEventsField_Capture_Renamed.OnFingerGone -= Capture_Renamed_OnFingerGone;
					withEventsField_Capture_Renamed.OnSampleQuality -= Capture_Renamed_OnSampleQuality;
					withEventsField_Capture_Renamed.OnComplete -= Capture_Renamed_OnComplete;
				}
				withEventsField_Capture_Renamed = value;
				if (withEventsField_Capture_Renamed != null) {
					withEventsField_Capture_Renamed.OnReaderConnect += Capture_Renamed_OnReaderConnect;
					withEventsField_Capture_Renamed.OnReaderDisconnect += Capture_Renamed_OnReaderDisconnect;
					withEventsField_Capture_Renamed.OnFingerTouch += Capture_Renamed_OnFingerTouch;
					withEventsField_Capture_Renamed.OnFingerGone += Capture_Renamed_OnFingerGone;
					withEventsField_Capture_Renamed.OnSampleQuality += Capture_Renamed_OnSampleQuality;
					withEventsField_Capture_Renamed.OnComplete += Capture_Renamed_OnComplete;
				}
			}
		}
		DPFPEngXLib.DPFPFeatureExtraction CreateFtrs;
		DPFPEngXLib.DPFPEnrollment CreateTempl;
		DPFPDevXLib.DPFPSampleConversion ConvertSample;

		bool loading;
		short gID;
		short gLastIndex;

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
				Label4.Text = "You already have Finger Prints saved.";
			} else {

			}

			loading = false;

			//loadLanguage
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

		private void DrawPicture(System.Drawing.Image Pict)
		{
			// Must use hidden PictureBox to easily resize picture.
			HiddenPict.Image = Pict;
			//UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			//Picture1.PaintPicture(HiddenPict.Image, 0, 0, pixelToTwips(Picture1.ClientRectangle.Width, True), pixelToTwips(Picture1.ClientRectangle.Height, False), 0, 0, pixelToTwips(HiddenPict.ClientRectangle.Width, True), pixelToTwips(HiddenPict.ClientRectangle.Height, False), vbSrcCopy)
			Picture1.Image = Picture1.Image;
		}
//UPGRADE_NOTE: Str was upgraded to Str_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void ReportStatus(string Str_Renamed)
		{
			// Add string to list box.
			int i = 0;
			i = Status.Items.Add((Str_Renamed));
			// Move list box selection down.
			Status.SelectedIndex = i;
		}

		private void Close_Renamed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			// Stop capture operation. This code is optional.
			Capture_Renamed.StopCapture();
			// Unload form.
			this.Close();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			// Stop capture operation. This code is optional.
			Capture_Renamed.StopCapture();
			// Unload form.
			this.Close();
		}

		private void frmPersonFPRegOT_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			// Create capture operation.
			Capture_Renamed = new DPFPDevXLib.DPFPCapture();
			// Start capture operation.
			Capture_Renamed.StartCapture();
			// Create DPFPFeatureExtraction object.
			CreateFtrs = new DPFPEngXLib.DPFPFeatureExtraction();
			// Create DPFPEnrollment object.
			CreateTempl = new DPFPEngXLib.DPFPEnrollment();
			// Show number of samples needed.
			Samples.Text = Convert.ToString(CreateTempl.FeaturesNeeded);
			// Create DPFPSampleConversion object.
			ConvertSample = new DPFPDevXLib.DPFPSampleConversion();
		}

		private void Capture_Renamed_OnReaderConnect(string ReaderSerNum)
		{
			ReportStatus(("The fingerprint reader was connected."));
		}

		private void Capture_Renamed_OnReaderDisconnect(string ReaderSerNum)
		{
			ReportStatus(("The fingerprint reader was disconnected."));
		}

		private void Capture_Renamed_OnFingerTouch(string ReaderSerNum)
		{
			ReportStatus(("The fingerprint reader was touched."));
		}
		private void Capture_Renamed_OnFingerGone(string ReaderSerNum)
		{
			ReportStatus(("The finger was removed from the fingerprint reader."));
		}
		private void Capture_Renamed_OnSampleQuality(string ReaderSerNum, DPFPDevXLib.DPFPCaptureFeedbackEnum Feedback)
		{
			if (Feedback == DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood) {
				ReportStatus(("The quality of the fingerprint sample is good."));
			} else {
				ReportStatus(("The quality of the fingerprint sample is poor."));
			}
		}

		private void Capture_Renamed_OnComplete(string ReaderSerNum, object Sample)
		{
			object rs = null;
			DPFPDevXLib.DPFPCaptureFeedbackEnum Feedback = default(DPFPDevXLib.DPFPCaptureFeedbackEnum);

			ReportStatus(("The fingerprint sample was captured."));
			// Draw fingerprint image.
			//UPGRADE_WARNING: Couldn't resolve default property of object ConvertSample.ConvertToPicture(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DrawPicture(ConvertSample.ConvertToPicture(Sample));
			// Process sample and create feature set for purpose of enrollment.
			Feedback = CreateFtrs.CreateFeatureSet(Sample, DPFPEngXLib.DPFPDataPurposeEnum.DataPurposeEnrollment);
			// Quality of sample is not good enough to produce feature set.
			DPFPShrXLib.DPFPTemplate Templ = default(DPFPShrXLib.DPFPTemplate);
			byte[] blob = null;
			//UPGRADE_ISSUE: clsRC4 object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			clsRC4 cBFCryp = new clsRC4();
			if (Feedback == DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood) {
				ReportStatus(("The fingerprint feature set was created."));
				Prompt.Text = "Touch the fingerprint reader again with the same finger.";
				// Add feature set to template.
				CreateTempl.AddFeatures(CreateFtrs.FeatureSet);
				// Show number of samples needed to complete template.
				Samples.Text = Convert.ToString(CreateTempl.FeaturesNeeded);
				// Check if template has been created.
				if (CreateTempl.TemplateStatus == DPFPEngXLib.DPFPTemplateStatusEnum.TemplateStatusTemplateReady) {

					//MainFrame.SetTemplete CreateTempl.Template
					// Template has been created, so stop capturing samples.
					Templ = CreateTempl.Template;
					//UPGRADE_WARNING: Couldn't resolve default property of object Templ.Serialize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					blob = Templ.Serialize;
					rs = modRecordSet.getRS(ref "SELECT * FROM PersonFPLnk WHERE PersonID = " + gID);
					//UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (rs.RecordCount > 0) {
						//cnnDB.Execute "UPDATE PersonFPLnk SET PersonFPLnk.Person_FP = " & blob_write & " WHERE (((PersonFPLnk.PersonID)=" & gID & "));"
						//rs.AddNew
						//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs("PersonID") = gID;
						//UPGRADE_WARNING: Couldn't resolve default property of object cBFCryp.EncodeArray64. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs("Person_FPs") = cBFCryp.EncodeArray64(ref blob);
						//UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs.update();
					} else {
						//cnnDB.Execute "INSERT INTO PersonFPLnk (PersonID, Person_FP) VALUES (" & gID & ", " & blob_write & ")"
						//UPGRADE_WARNING: Couldn't resolve default property of object rs.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs.AddNew();
						//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs("PersonID") = gID;
						//UPGRADE_WARNING: Couldn't resolve default property of object cBFCryp.EncodeArray64. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs("Person_FPs") = cBFCryp.EncodeArray64(ref blob);
						//UPGRADE_WARNING: Couldn't resolve default property of object rs.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rs.update();
					}

					Capture_Renamed.StopCapture();
					Prompt.Text = "Click Exit, and then click Fingerprint Verification.";
					Interaction.MsgBox("The fingerprint template was created.");

					//frmPersonFPVerifyOT.loadItem (gID)
					//frmPersonFPVerify.loadItem (gID)
				}
			}
		}
	}
}
