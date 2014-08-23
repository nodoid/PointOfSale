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
    internal partial class frmPersonFPVerifyOT : System.Windows.Forms.Form
    {
        private DPFPDevXLib.DPFPCapture withEventsField_Capture_Renamed;

        public DPFPDevXLib.DPFPCapture Capture_Renamed
        {
            get { return withEventsField_Capture_Renamed; }
            set
            {
                if (withEventsField_Capture_Renamed != null)
                {
                    withEventsField_Capture_Renamed.OnReaderConnect -= Capture_Renamed_OnReaderConnect;
                    withEventsField_Capture_Renamed.OnReaderDisconnect -= Capture_Renamed_OnReaderDisconnect;
                    withEventsField_Capture_Renamed.OnFingerTouch -= Capture_Renamed_OnFingerTouch;
                    withEventsField_Capture_Renamed.OnFingerGone -= Capture_Renamed_OnFingerGone;
                    withEventsField_Capture_Renamed.OnSampleQuality -= Capture_Renamed_OnSampleQuality;
                    withEventsField_Capture_Renamed.OnComplete -= Capture_Renamed_OnComplete;
                }
                withEventsField_Capture_Renamed = value;
                if (withEventsField_Capture_Renamed != null)
                {
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
        DPFPEngXLib.DPFPVerification Verify;
        DPFPDevXLib.DPFPSampleConversion ConvertSample;
        bool loading;
        short gID;
        short gLastIndex;

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

            //loadLanguage
            this.ShowDialog();

            //Command1_Click

            return;
            FPA_Error:
            if (Err().Number == 429)
            {
                Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
            }
            else
            {
                Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
                // ERROR: Not supported in C#: ResumeStatement

            }
        }
        //UPGRADE_NOTE: Str was upgraded to Str_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        private void ReportStatus(string Str_Renamed)
        {
            // Add string to list box.
            int m = 0;
            m = Status.Items.Add((Str_Renamed));
            // Move list box selection down.
            Status.SelectedIndex = m;
        }

        private void DrawPicture(System.Drawing.Image Pict)
        {
            // Must use hidden PictureBox to easily resize picture.
            HiddenPict.Image = Pict;
            //UPGRADE_ISSUE: Constant vbSrcCopy was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            //UPGRADE_ISSUE: PictureBox method Picture1.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            //Picture1.PaintPicture(HiddenPict.Image, 0, 0, pixelToTwips(Picture1.ClientRectangle.Width, True), pixelToTwips(Picture1.ClientRectangle.Height, False), 0, 0, pixelToTwips(HiddenPict.ClientRectangle.Width, True), pixelToTwips(HiddenPict.ClientRectangle.Height, False), vbSrcCopy)
            //UPGRADE_ISSUE: PictureBox property Picture1.Image was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            Picture1.Image = Picture1.Image;
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

        private void frmPersonFPVerifyOT_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            // Create capture operation.
            Capture_Renamed = new DPFPDevXLib.DPFPCapture();
            // Start capture operation.
            Capture_Renamed.StartCapture();
            // Create DPFPFeatureExtraction object.
            CreateFtrs = new DPFPEngXLib.DPFPFeatureExtraction();
            // Create DPFPVerification object.
            Verify = new DPFPEngXLib.DPFPVerification();
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
            if (Feedback == DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood)
            {
                ReportStatus(("The quality of fingerprint sample is good."));
            }
            else
            {
                ReportStatus(("The quality of fingerprint sample is poor."));
            }
        }

        private void Capture_Renamed_OnComplete(string ReaderSerNum, object Sample)
        {
            ADODB.Recordset rs = default(ADODB.Recordset);
            DPFPDevXLib.DPFPCaptureFeedbackEnum Feedback = default(DPFPDevXLib.DPFPCaptureFeedbackEnum);
            DPFPEngXLib.DPFPVerificationResult Res = default(DPFPEngXLib.DPFPVerificationResult);
            object Templ = null;
            DPFPShrXLib.DPFPTemplate Templs = new DPFPShrXLib.DPFPTemplate();
            byte[] blob = null;
            //UPGRADE_ISSUE: clsRC4 object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            clsRC4 cBFCryp = new clsRC4();

            ReportStatus(("The fingerprint was captured."));
            // Draw fingerprint image.
            //UPGRADE_WARNING: Couldn't resolve default property of object ConvertSample.ConvertToPicture(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DrawPicture(ConvertSample.ConvertToPicture(Sample));
            // Process sample and create feature set for purpose of verification.
            Feedback = CreateFtrs.CreateFeatureSet(Sample, DPFPEngXLib.DPFPDataPurposeEnum.DataPurposeVerification);
            // Quality of sample is not good enough to produce feature set.
            if (Feedback == DPFPDevXLib.DPFPCaptureFeedbackEnum.CaptureFeedbackGood)
            {
                Prompt.Text = "Touch the fingerprint reader with a different finger.";

                rs = modRecordSet.getRS(ref "SELECT * FROM PersonFPLnk WHERE PersonID = " + gID);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (rs.RecordCount > 0)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object cBFCryp.DecodeArray64. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    blob = cBFCryp.DecodeArray64(Convert.ToString(rs("Person_FPs")));

                    if (Templs == null)
                        Templs = new DPFPShrXLib.DPFPTemplate();

                    // Import binary data to template.
                    Templs.Deserialize(blob);
                    Templ = Templs;
                    if (Templ == null)
                    {
                        Interaction.MsgBox("You must create a fingerprint template before you can perform verification.");
                    }
                    else
                    {
                        // Compare feature set with template.
                        Res = Verify.Verify(CreateFtrs.FeatureSet, Templ);
                        // Show results of comparison.
                        FAR.Text = Convert.ToString(Res.FARAchieved);
                        if (Res.Verified == true)
                        {
                            ReportStatus(("The fingerprint was verified."));
                            Interaction.MsgBox("Finger print matched.");
                        }
                        else
                        {
                            ReportStatus(("The fingerprint was not verified."));
                            Interaction.MsgBox("No finger print match found !");
                        }
                    }

                }
                else
                {

                }

            }
            else
            {
                ReportStatus(("The quality of feature set is poor."));
            }
        }
    }
}
