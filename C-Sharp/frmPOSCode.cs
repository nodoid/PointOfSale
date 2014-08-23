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
	internal partial class frmPOSCode : System.Windows.Forms.Form
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

		char[] fox = new char[9];
		string usb_drv;
		string yourdrive;
		bool CDKey;

		private byte[] arData;
		private byte[] arPWord;
		private short m_intCipher;

		private void loadLanguage()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//frmPOSCode = No Code   [4POS Registration]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPOSCode.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSCode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_0 = No Code       [Please type in your 4POS CD Key (without dashes)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_1 = No Code [CD Key]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPOSCode.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void Reset_frmEncStrings()
		{
			string strMsg = null;

			arData = null;
			arPWord = null;
		}

//UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Form_Initialize_Renamed()
		{
			//ChDrive App.Path
			//ChDir App.Path
			basCryptoProcs.Initial_settings();
			Reset_frmEncStrings();
		}

		public bool setupCode()
		{

			CDKey = false;
			System.Windows.Forms.Application.DoEvents();
			//Dim c, i As Byte
			//For i = 68 To 75
			//    c = c + 1
			//    fox(c) = Chr(i) & ":"
			//Next

			loadLanguage();
			this.ShowDialog();

			return CDKey;
			//Exit Function
		}

		private void frmPOSCode_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private System.DateTime getCDKeyDate(ref string posCDKey)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			clsCryptoAPI cCrypto = null;
			// clsCryptoAPI

			string strSerial = null;
			string strTmp = null;

			cCrypto = new clsCryptoAPI();
			//clsCryptoAPI
			System.Windows.Forms.Application.DoEvents();
			//strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
			strTmp = cCrypto.ConvertStringFromHex(Strings.Left(posCDKey, Strings.Len(posCDKey) - 5));
			System.Windows.Forms.Application.DoEvents();
			arData = cCrypto.StringToByteArray(strTmp);
			System.Windows.Forms.Application.DoEvents();
			arPWord = cCrypto.StringToByteArray(Conversion.Val(Strings.Right(posCDKey, 5)));
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

			//If strSerial = "pos" Then
			short intDate = 0;
			short intYear = 0;
			short intMonth = 0;
			string dtDate = null;
			string dtMonth = null;
			string dtYear = null;
			string stPass = null;
			if (Strings.Left(strSerial, 3) == "pos" | Strings.Left(strSerial, 3) == "pre") {

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
						//    If CDate(stPass) >= (Date - 31) Then

					}
				}
			}
			jumpOut:

			cCrypto = null;
			// Free the Crypto class from memory
			strTmp = new string(Strings.Chr(0), 250);
			// overwrite data in temp variable

			return Convert.ToDateTime(stPass);

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			clsCryptoAPI cCrypto = null;
			// clsCryptoAPI

			string strSerial = null;
			string strTmp = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			//Piracy check
			System.DateTime lastCDKeyDate = default(System.DateTime);
			lastCDKeyDate = System.Date.FromOADate(DateAndTime.Today.ToOADate() - 356);
			//check if he is backdating while on the cd-key screen
			if (DateAndTime.Today != modApplication.loginDate) {
				if (DateAndTime.Today < (System.Date.FromOADate(modApplication.loginDate.ToOADate() - 30))) {
					Interaction.MsgBox("ErrorCode:31 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
					CDKey = false;
					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					this.Close();
					return;
				}
			}
			//
			//check if he is changing the date before the install date
			strSerial = Strings.FormatDateTime(modApplication.instalDate, DateFormat.ShortDate);
			modApplication.instalDate = Convert.ToDateTime(strSerial);
			strSerial = "";
			if (Convert.ToDateTime(modApplication.instalDate) > DateAndTime.Today) {
				Interaction.MsgBox("ErrorCode:64 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
				CDKey = false;
				cmdClose.Focus();
				System.Windows.Forms.Application.DoEvents();
				this.Close();
				return;
			}
			//
			//check if current key is not older then the last used key (if any)
			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT TOP 1 * FROM POS ORDER BY POS_CID DESC;");
			if (rs.RecordCount) {
				if (Strings.InStr(1, rs.Fields("POS_Code").Value, Strings.Chr(255))) {
					lastCDKeyDate = getCDKeyDate(ref Convert.ToString(Strings.Split(rs.Fields("POS_Code").Value, Strings.Chr(255))[1]));
				}
			}
			//Piracy check

			txtFields.Text = Strings.Trim(Strings.Replace(txtFields.Text, "-", ""));
			if (Strings.Len(txtFields.Text) < 23) {
				Interaction.MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
				CDKey = false;
				cmdClose.Focus();
				System.Windows.Forms.Application.DoEvents();
				this.Close();
				return;
			}

			cCrypto = new clsCryptoAPI();
			//clsCryptoAPI
			System.Windows.Forms.Application.DoEvents();
			txtFields.Text = Strings.LTrim(txtFields.Text);
			txtFields.Text = Strings.RTrim(txtFields.Text);
			txtFields.Text = Strings.Trim(txtFields.Text);
			txtFields.Text = Strings.Replace(txtFields.Text, " ", "");
			//strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
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

			//If strSerial = "pos" Then
			short intDate = 0;
			short intYear = 0;
			short intMonth = 0;
			string dtDate = null;
			string dtMonth = null;
			string dtYear = null;
			string stPass = null;
			if (Strings.Left(strSerial, 3) == "pos") {

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
						if (Convert.ToDateTime(stPass) < lastCDKeyDate) {
							Interaction.MsgBox("ErrorCode:97 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
							CDKey = false;
							cmdClose.Focus();
							System.Windows.Forms.Application.DoEvents();
							this.Close();
							return;
						}

						if (Convert.ToDateTime(stPass) < 01/01/2012 00:00:00) {
							Interaction.MsgBox("ErrorCode:82 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
							CDKey = false;
							cmdClose.Focus();
							System.Windows.Forms.Application.DoEvents();
							this.Close();
							return;
						}

						rs = modRecordSet.getRS(ref "Select TOP 1 * FROM Sale ORDER BY SaleID DESC;");
						if (rs.RecordCount) {
							if (Convert.ToDateTime(stPass) < System.Date.FromOADate(rs.Fields("Sale_Date").Value - 30)) {
								Interaction.MsgBox("ErrorCode:28 - The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
								CDKey = false;
								cmdClose.Focus();
								System.Windows.Forms.Application.DoEvents();
								this.Close();
								return;
							}
						}

						if (Convert.ToDateTime(stPass) >= (System.Date.FromOADate(DateAndTime.Today.ToOADate() - 31))) {
							//Dim rs As Recordset
							//Dim rj As Recordset
							//Set rs = getRS("Select * FROM POS WHERE POS_Code = '" & Trim(strCDKey) & "'")
							//    If rs.RecordCount > 0 Then
							//       MsgBox "This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", vbApplicationModal + vbInformation + vbOKOnly, App.title
							//       CDKey = False
							//    Else
							//        CDKey = True
							//    End If
							//
							//    cnnDB.Execute "UPDATE Company SET Company_ResMS = '" & txtFields.Text & "';"
							//    CDKey = True
							 // ERROR: Not supported in C#: OnErrorStatement

							rs = modRecordSet.getRS(ref "Select * FROM POS;");
							while (rs.EOF == false) {
								if (Strings.InStr(1, rs.Fields("POS_Code").Value, Strings.Chr(255))) {
									if (Strings.Split(rs.Fields("POS_Code").Value, Strings.Chr(255))[1] == txtFields.Text) {
										Interaction.MsgBox("This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
										CDKey = false;
										goto jumpOut;
									}
								}
								rs.moveNext();
							}
							//all validation OK
							CDKey = true;
							basCryptoProcs.strCDKey = txtFields.Text;
						} else {
							Interaction.MsgBox("This '4POS CD Key' is expired!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
							CDKey = false;
							goto jumpOut;
						}
					}

				} else {
					Interaction.MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
					CDKey = false;
					goto jumpOut;
				}

			} else {
				//MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
				Interaction.MsgBox("The '4POS CD Key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
				CDKey = false;
			}
			jumpOut:
			cCrypto = null;
			// Free the Crypto class from memory
			strTmp = new string(Strings.Chr(0), 250);
			// overwrite data in temp variable

			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			//CDKey = False
			this.Close();
			Err_Close:

			//If Err.Number = 0 Then
			//Else
			//End If
			 // ERROR: Not supported in C#: ResumeStatement

		}

//Private Sub OLD__Timer1_Timer()
//Dim i
//    For i = 1 To 8
//        'DoEvents
//        If GetDriveType(fox(i)) = 5 Then ' CD ROM DISK'
//
//            If setupCodeAuto(fox(i)) = True Then
//                Timer1.Enabled = False
//                Unload Me
//                Exit Sub
//            Else
//                'Me.show 1
//            End If''
//
//            If TEST_CDROM(fox(i)) = True Then'
//
//                '_lbl_5.Caption = "Please Insert next 4POS CD to Add New Terminal then click Close."
//                _lbl_5.Caption = "Your 4POS CD is not installed 4POS CD must be Inserted to Register."
//                'Timer2.Enabled = True
//                Timer1.Enabled = False
//                'Timer5.Enabled = 0
//                'X = 324
//                'Y = 95
//                'chkFields_Click
//                txtFields.Enabled = False
//                'txtFields.SetFocus
//                Exit Sub
//            End If
//
//        Else
//            'Timer1.Enabled = True
//            'Y = 95'
//
//            'If Not Timer5.Enabled Then
//            'label1.Cls
//            'label1.CurrentX = 0
//            'label1.CurrentY = 0
//            'label1.Print "---<cd rom is off---->"'
//
//            'Timer5.Enabled = True
//            'End If
//            _lbl_5.Caption = "It looks you don't have CD-ROM drive. Please Type the CD Key Manually and press Exit."'
//
//            chkFields_Click
//            txtFields.Enabled = True
//            txtFields.SetFocus
//        End If
//    Next
//    If i >= 8 Then Timer1.Enabled = False
//End Sub''

//
//Function OLD__TEST_CDROM(ByVal CDR_SYMBOL) As Boolean '
//'
//On Error GoTo ER
//File1.Path = CDR_SYMBOL & "\"''
//
//Dim retval
//yourdrive = CDR_SYMBOL
		///
//
//'this is the main call to open the CD tray using a drive list box
//retval = openCD(Mid(CDR_SYMBOL, 1, 1))
//If retval <> 0 Then
//    'MsgBox "Not a CD drive!"
//Else
//    TEST_CDROM = True
//    'Drive1.Drive = CDR_SYMBOL
//
//End If
//'label1.Cls
//'label1.CurrentX = 0
//'label1.CurrentY = 0
//'label1.Print "cd rom <" & CDR_SYMBOL & "> is inserted please wait ..."
//Exit Function
//ER:
//If Err.Number = 68 Then
//
//    Else
//        MsgBox Err.Number & Err.Description
//        TEST_CDROM = False
//End If'
//
//End Function'
//
//Public Function OLD__setupCodeAuto(ByVal CDR_SYMBOL) As Boolean
//
//    Dim fso As New FileSystemObject
//    Dim fsoFolder As Folder
//    Dim fsoDrive As Drive
//
//    On Error GoTo D_Err
//    DoEvents
//
//    Drive1.Drive = CDR_SYMBOL
//    Set fsoFolder = fso.GetFolder(Drive1.Drive & "\")
//    txtFields.Text = fsoFolder.Drive.VolumeName
//
//Dim cCrypto As clsCryptoAPI ' clsCryptoAPI''
//
//Dim strSerial As String
//Dim strTmp'
//
//        Set cCrypto = New clsCryptoAPI 'clsCryptoAPI
//        DoEvents
//        txtFields.Text = LTrim(txtFields.Text)
//        txtFields.Text = RTrim(txtFields.Text)
//        txtFields.Text = Trim(txtFields.Text)
//        'strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, 6))
//        strTmp = cCrypto.ConvertStringFromHex(Left(txtFields.Text, (Len(txtFields.Text) - 5)))
//        DoEvents
//        arData = cCrypto.StringToByteArray(strTmp)
//        DoEvents
//        arPWord = cCrypto.StringToByteArray(Val(Right(txtFields.Text, 5)))
//        DoEvents
//        cCrypto.PassWord = arPWord()
//        DoEvents
//        cCrypto.InputData = arData()
//        DoEvents
//
//        ' Decrypt the data input from the encrypted text box
//        'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
//        If cCrypto.Decrypt(2, 1) Then
//            DoEvents
//            arData = cCrypto.OutputData
//            strSerial = cCrypto.ByteArrayToString(arData)
//        End If
//
//        If strSerial = "pos" Then
//
//            'Create date password
//            Dim intDate   As Integer
//            Dim intYear   As Integer
//            Dim intMonth   As Integer
//            Dim dtDate   As String
//            Dim dtMonth  As String
//            Dim dtYear  As String
//            Dim stPass As String
//            If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then
//                strSerial = Mid(strSerial, 4, Len(strSerial))
//                intYear = Mid(strSerial, 5, 2)
//                intMonth = Mid(strSerial, 3, 2)
//                intDate = Left(strSerial, 2)
//
//                If (intDate / 2) = Round(intDate / 2) Then
//                    intDate = intDate / 2
//                Else
//                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                    setupCodeAuto = False
//                    GoTo jumpOut
//                End If
//
//                If (intMonth / 3) = Round(intMonth / 3) Then
//                    intMonth = intMonth / 3
//                Else
//                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                    setupCodeAuto = False
//                    GoTo jumpOut
//                End If
//
//                If (intYear / 4) = Round(intYear / 4) Then
//                    intYear = intYear / 4
//                Else
//                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                    setupCodeAuto = False
//                    GoTo jumpOut
//                End If
//
//                stPass = "20"
//                If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
//                If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
//                If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
//
//                If IsDate(stPass) Then
//                    If CDate(stPass) >= (Date - 31) Then
//                        CDKey = True
//                        setupCodeAuto = True
//                    Else
//                        MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                        setupCodeAuto = False
//                        GoTo jumpOut
//                    End If
//                Else
//                    MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                    setupCodeAuto = False
//                    GoTo jumpOut
//                End If
//
//            Else
//                MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//                setupCodeAuto = False
//            End If
//
//            strCDKey = txtFields.Text
//
//            Dim rs As Recordset
//            Dim rj As Recordset''''
//
//            Set rs = getRS("Select * FROM POS WHERE POS_Code = '" & Trim(strCDKey) & "'")
//            If rs.RecordCount > 0 Then
//
//               'MsgBox "This CD already used and registered, Chooose another 4POS CD.", vbApplicationModal + vbInformation + vbOKOnly, App.title
//               MsgBox "This CD has already been used for Installation. A 4POS CD is licensed for 1 Computer only, Please Insert next 4POS CD for the additional POS terminal you wish to Install.", vbApplicationModal + vbInformation + vbOKOnly, App.title
//              setupCodeAuto = False
//               CDKey = False
//            Else
//                CDKey = True
//                setupCodeAuto = True
//            End If
//
//        Else
//            MsgBox "Not a Valid 4POS CD or CD Key!", vbCritical
//            setupCodeAuto = False
//        End If
//
//jumpOut:
//        Set cCrypto = Nothing    ' Free the Crypto class from memory
//        strTmp = String$(250, 0)  ' overwrite data in temp variable
//
//
//Exit Function
//D_Err:
//'If Err.Number = 76 Then
//'    MsgBox "Drive is not ready, or still loading disc."
//'Else
//'    MsgBox Err.Number & " - " & Err.Description
//'End If
//setupCodeAuto = False
//    'Exit Function
//End Function''
//
//Private Sub OLD__chkFields_Click()
//txtFields.Enabled = chkFields
//End Sub''

//Private Sub OLD__Command1_Click()
//Dim retval
//Dim yourdrive As String
		///
//'this is the main call to open the CD tray using a drive list box
//retval = openCD(Mid(Drive1.Drive, 1, 1))
		///
//'Or you could do this, without a drive box:
		///
//'yourdrive = "D"
//'retval = openCD(YourDrive)
		///
//'we need to make sure retval is 0, else an error happend
//If retval <> 0 Then MsgBox "Not a CD drive!"
//End Sub''
//
//Private Sub OLD__Command2_Click()
//On Error GoTo D_Err
//    Dim retval
//    Dim fso As New FileSystemObject
//    Dim fsoFolder As Folder
//    Dim fsoDrive As Drive
//
//_lbl_5.Caption = "Loading Key Please wait..."''
//
//'this is the main call to close the CD tray using a drive list box
//retval = closeCD(Mid(yourdrive, 1, 1))
//'we need to make sure retval is 0, else an error happend
//If retval <> 0 Then
//    MsgBox "Not a CD drive OR No CD in Drive!"
//    _lbl_5.Caption = "Not a CD drive OR No CD in Drive! Please put the CD Key Manually."
//            chkFields_Click
//            txtFields.Enabled = True
//            txtFields.SetFocus
//
//Else
//    'getSerialNumber = ""
//    'If fso.FolderExists(serverPath) Then
//    '    Set fsoFolder = fso.GetFolder(serverPath)
//    '    getSerialNumber = fsoFolder.Drive.SerialNumber
//    'End If
//    Drive1.Drive = yourdrive
//    Set fsoFolder = fso.GetFolder(Drive1.Drive & "\")
//    'txtFields.Text = fsoFolder.Drive.SerialNumber
//    txtFields.Text = fsoFolder.Drive.VolumeName
//
//    '_lbl_5.Caption = "Click Save && Exit to verify and save CD Key."
//    cmdClose_Click
//End If'
//
//Exit Sub
//D_Err:
//If Err.Number = 76 Then
//    MsgBox "Drive is not ready, or still loading disc."
//Else
//    MsgBox Err.Number & " - " & Err.Description
//End If
//
//
//End Sub'
//
//Private Sub OLD__Form_Resize()
//  On Error Resume Next
//Unload Me
//End Sub'
//UPGRADE_WARNING: Event txtFields.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtFields_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

		}
	}
}
