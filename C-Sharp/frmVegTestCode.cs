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
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmVegTestCode : System.Windows.Forms.Form
	{
		ADODB.Recordset adoPrimaryRS;
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;
		int k_posID;
		bool k_posNew;


		bool flag;
		float y;
		short c;
		short YY;
		short x;
		[DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int BitBlt(int hDestDC, int x, int y, int nWidth, int nHeight, int hSrcDC, int xSrc, int ySrc, int dwRop);

		System.Drawing.Image obj = new System.Drawing.Bitmap(1, 1);
		[DllImport("kernel32", EntryPoint = "GetDriveTypeA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetDriveType(string nDrive);

		object[] fox = new object[9];
		string usb_drv;
		string yourdrive;
		bool CDKey;

		private byte[] arData;
		private byte[] arPWord;
		private short m_intCipher;


		public void Reset_frmEncStrings()
		{

			string strMsg = null;
			arData = null;
			arPWord = null;

		}

//UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Form_Initialize_Renamed()
		{

			basCryptoProcs.Initial_settings();
			Reset_frmEncStrings();

		}


		public bool setupCode()
		{

			CDKey = false;
			System.Windows.Forms.Application.DoEvents();
			object c = null;
			byte i = 0;

			//For i = 68 To 75
			//    c = c + 1
			//    fox(c) = Chr(i) & ":"
			//Next

			this.ShowDialog();

			return CDKey;
			//Exit Function
		}

		private void frmVegTestCode_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					//            adoPrimaryRS.Move 0
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			this.Close();
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			CDKey = false;
			string strSerial = null;
			string strTmp = null;
			short intDate = 0;
			short intYear = 0;
			short intMonth = 0;
			string dtDate = null;
			string dtMonth = null;
			string dtYear = null;
			string stPass = null;
			// clsCryptoAPI
			clsCryptoAPI cCrypto = null;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {

					//if old database don't chk secuirty
					if (rs.Fields.Count <= 55) {
						CDKey = false;
						Interaction.MsgBox("You need to download latest 4POS upgrades in order to Register.", MsgBoxStyle.Critical, "4POS");
						return;
					}

					txtFields.Text = Strings.Trim(Strings.Replace(txtFields.Text, "-", ""));


					cCrypto = new clsCryptoAPI();
					//clsCryptoAPI
					System.Windows.Forms.Application.DoEvents();
					txtFields.Text = Strings.LTrim(txtFields.Text);
					txtFields.Text = Strings.RTrim(txtFields.Text);
					txtFields.Text = Strings.Trim(txtFields.Text);
					//strTmp = cCrypto.ConvertStringFromHex(Left(rs("Company_ResMS"), 6))
					strTmp = cCrypto.ConvertStringFromHex(Strings.Left(txtFields.Text, Strings.Len(txtFields.Text) - 5));
					System.Windows.Forms.Application.DoEvents();
					arData = cCrypto.StringToByteArray(strTmp);
					System.Windows.Forms.Application.DoEvents();
					arPWord = cCrypto.StringToByteArray(Conversion.Val(Strings.Right(txtFields.Text, 5)));
					System.Windows.Forms.Application.DoEvents();
					cCrypto.PassWord = arPWord;
					System.Windows.Forms.Application.DoEvents();
					cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData);
					System.Windows.Forms.Application.DoEvents();

					// Decrypt the data input from the encrypted text box
					//If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
					if (cCrypto.Decrypt(2, 1)) {
						System.Windows.Forms.Application.DoEvents();
						arData = cCrypto.OutputData.Clone();
						strSerial = cCrypto.ByteArrayToString(arData);
					}

					if (Strings.Left(strSerial, 3) == "veg") {

						//Create date password
						if (Information.IsNumeric(Strings.Mid(strSerial, 4, Strings.Len(strSerial)))) {
							strSerial = Strings.Mid(strSerial, 4, Strings.Len(strSerial));
							intYear = Convert.ToInt16(Strings.Mid(strSerial, 5, 2));
							intMonth = Convert.ToInt16(Strings.Mid(strSerial, 3, 2));
							intDate = Convert.ToInt16(Strings.Left(strSerial, 2));

							if ((intDate / 2) == System.Math.Round(intDate / 2)) {
								intDate = intDate / 2;
							} else {
								goto jumpOut;
							}

							if ((intMonth / 3) == System.Math.Round(intMonth / 3)) {
								intMonth = intMonth / 3;
							} else {
								goto jumpOut;
							}

							if ((intYear / 4) == System.Math.Round(intYear / 4)) {
								intYear = intYear / 4;
							} else {
								goto jumpOut;
							}

							stPass = "20";
							if (Strings.Len(Convert.ToString(intYear)) == 1)
								stPass = stPass + "0" + intYear + "/";
							else
								stPass = stPass + intYear + "/";
							if (Strings.Len(Convert.ToString(intMonth)) == 1)
								stPass = stPass + "0" + intMonth + "/";
							else
								stPass = stPass + intMonth + "/";
							if (Strings.Len(Convert.ToString(intDate)) == 1)
								stPass = stPass + "0" + intDate;
							else
								stPass = stPass + intDate;

							if (Information.IsDate(stPass)) {
								if (Convert.ToDateTime(stPass) >= (System.Date.FromOADate(DateAndTime.Today.ToOADate() - 31))) {
									modRecordSet.cnnDB.Execute("UPDATE Company SET Company_ResMS = '" + txtFields.Text + "';");
									CDKey = true;
								}
							}

						} else {
							Interaction.MsgBox("Not a Valid 4VEG Key!", MsgBoxStyle.Critical);
						}
					} else {
						Interaction.MsgBox("Not a Valid 4VEG Key!", MsgBoxStyle.Critical);
					}
					jumpOut:
					cCrypto = null;
					// Free the Crypto class from memory
					strTmp = new string(Strings.Chr(0), 250);
					// overwrite data in temp variable
					//Exit Sub

				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					//End
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				//End
			}

			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			this.Close();

		}
	}
}
