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
	internal partial class frmRegister : System.Windows.Forms.Form
	{
		short gMode;
		const short modeCompany = 0;
		const short modeCode = 1;
		string gSecurityCode;
			//new serialization check
		string[] preSerial;
		List<Panel> picMode = new List<Panel>();
		private void loadLanguage()
		{

			//frmRegister = No Code      [Registration Wizard]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmRegister.Caption = rsLang("LanguageLayoutLnk_Description"): frmRegister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code           [Welcome to the 4POS Application Suite of products designed for the retailer.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [In the text box below.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_3 = No Code           [To bypass this registration.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code           [Store Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmRegister.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void doMode(ref object lMode)
		{
			int x = 0;
			gMode = lMode;
			for (x = 0; x <= picMode.Count; x++) {
				picMode[x].Visible = false;
			}
			picMode[gMode].Left = picMode[0].Left;
			picMode[gMode].Top = picMode[0].Top;

			picMode[gMode].Visible = true;
		}

		private void cmdBegin_Click()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string vValue = null;
			long hkey = 0;
			long lRetVal = 0;
			if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
				modRecordSet.cnnDB.Execute("UPDATE Company SET Company_Name = '" + Strings.Replace(txtCompany.Text, "'", "''") + "'");
				rs = modRecordSet.getRS(ref "SELECT * From Company");

				if (rs.RecordCount) {
					//check advance date expiry system
					 // ERROR: Not supported in C#: OnErrorStatement

					vValue = "";
					lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
					lRetVal = modUtilities.QueryValueEx(hkey, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\ShellClass", ref vValue);

					modUtilities.RegCloseKey(hkey);
					if (string.IsNullOrEmpty(vValue)) {
						vValue = "0";
					} else {
						if (vValue != "0")
							vValue = Convert.ToString(Convert.ToDateTime("&H" + vValue));
					}

					if (Information.IsDBNull(rs("Company_TerminateDate").Value) & vValue == "0") {
						//If vValue = "0" Then
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
						lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
						modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
						modUtilities.RegCloseKey(hkey);
					} else {
						if (Information.IsDBNull(rs("Company_TerminateDate").Value) & vValue != "0") {
							//db date tempered
							if (modApplication.posDemo() == true) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
								lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
								modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
								modUtilities.RegCloseKey(hkey);
							} else {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (Information.IsDBNull(rs("Company_TerminateDate").Value)) {
						} else {
							if (rs("Company_TerminateDate").Value > DateAndTime.Today) {
								//db date tempered
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						//If (Date + 2) > rs("Company_TerminateDate") Then
						//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						//    checkSecurity = False
						//   Exit Function
						//End If
					}
				}
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case modeCompany:
					cmdBegin_Click();
					this.Hide();
					break;
				case modeCode:
					cmdBegin_Click();
					doMode(ref modeCompany);
					txtCompany.SelectionStart = 0;
					txtCompany.SelectionLength = 999;
					txtCompany.Focus();
					cmdExit.Text = "E&xit";
					break;
			}
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			switch (gMode) {
				case modeCompany:
					if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
						//new serialization check
						//If Len(gSecKey) = 12 Then
						//is he really using Original CD to register
						if (My.MyProject.Forms.frmPOSCode.setupCode() == true) {
							if (Interaction.MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") == MsgBoxResult.Yes) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								cmdBegin_Click();
								//new serialization check    cnnDB.Execute "UPDATE Company SET Company.Company_Code = [Company_Code] & '0';"
								//new serialization check    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & strCDKey & "';"
								lPassword = "pospospospos";
								lCode = getSerialNumber();
								lCode = Encrypt(lCode, lPassword);
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" + Strings.Replace(lCode, "'", "''") + "';");

								lPassword = Strings.LTrim(Strings.Replace(txtCompany.Text, "'", ""));
								lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
								lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
								lPassword = Strings.LCase(lPassword);
								leCode = "";
								lCode = "";
								for (x = 1; x <= Strings.Len(lPassword); x++) {
									lCode = Strings.Mid(lPassword, x, 1);
									lCode = Convert.ToString(Strings.Asc(lCode));
									if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
										leCode = leCode + Strings.Mid(lPassword, x, 1);
									}
								}
								lPassword = leCode;
								rs = modRecordSet.getRS(ref "SELECT * FROM POS;");
								//WHERE POS_IPAddress = 'localhost';")
								if (rs.RecordCount) {
									while (rs.EOF == false) {
										if (rs.Fields("POS_IPAddress").Value == "localhost" & rs.Fields("POS_Name").Value == "Server") {
											lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
											leCode = Encrypt(lCode, lPassword);
											leCode = leCode + Strings.Chr(255) + basCryptoProcs.strCDKey;
											modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
											modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" + rs.Fields("POS_CID").Value + ";");
											break; // TODO: might not be correct. Was : Exit Do
										} else if (rs.Fields("POS_IPAddress").Value == "localhost") {
											lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
											leCode = Encrypt(lCode, lPassword);
											leCode = leCode + Strings.Chr(255) + basCryptoProcs.strCDKey;
											modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
											modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" + rs.Fields("POS_CID").Value + ";");
											break; // TODO: might not be correct. Was : Exit Do
										} else {
											modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
										}
										rs.moveNext();
									}
								}
								//new serialization check
								this.Close();
							}
							//Else

						}

						//Else
						//    cmdBegin_Click
						//    lblCompany.Caption = txtCompany.Text
						//    gSecurityCode = UCase(txtCompany.Text) & "XDFHWPGMIJ"
						//    gSecurityCode = Replace(gSecurityCode, " ", "")
						//    gSecurityCode = Replace(gSecurityCode, "'", "")
						//    gSecurityCode = Replace(gSecurityCode, """", "")
						//    gSecurityCode = Replace(gSecurityCode, ",", "")
						//    For x = 1 To 10
						//        gSecurityCode = Left(gSecurityCode, x) & Replace(Mid(gSecurityCode, x + 1), Mid(gSecurityCode, x, 1), "")
						//    Next x
						//    gSecurityCode = Left(gSecurityCode, 10)
						//    lCode = getSerialNumber
						//    leCode = ""
						//    On Local Error Resume Next
						//    For x = 1 To Len(lCode)
						//        leCode = leCode & Mid(gSecurityCode, Mid(lCode, x, 1) + 1, 1)
						//    Next x
						//    On Local Error GoTo 0
						//    lblCode.Caption = leCode
						//    doMode modeCode
						//    txtKey.Text = ""
						//    txtKey.SetFocus
						//    cmdExit.Caption = "&Back"
						//End If
					} else {
						Interaction.MsgBox("A Company name is required." + Constants.vbCrLf + Constants.vbCrLf + "If you do not want to register now, Press then 'Exit Button'.", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
						txtCompany.Focus();
					}
					break;
				//Case modeCode
				//    register
			}
		}

		private void register()
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lNewString = null;
			const string securtyStringReply = "9487203516";
			string lCode = null;
			string leCode = null;
			string lPassword = null;

			lNewString = "";
			for (x = 1; x <= Strings.Len(txtKey.Text); x++) {
				if (Information.IsNumeric(Strings.Mid(txtKey.Text, x, 1))) {
					lNewString = lNewString + Strings.InStr(securtyStringReply, Strings.Mid(txtKey.Text, x, 1)) - 1;
				}
			}

			if (System.Math.Abs(Convert.ToDouble(lNewString)) == System.Math.Abs(Convert.ToDouble(getSerialNumber()))) {
				lPassword = "pospospospos";
				lCode = getSerialNumber();
				if (!string.IsNullOrEmpty(lCode)) {
					lCode = Encrypt(lCode, lPassword);
					modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" + Strings.Replace(lCode, "'", "''") + "';");
					//new serialization check    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & Replace(lCode, "'", "''") & "';"
					lPassword = Strings.LTrim(Strings.Replace(txtCompany.Text, "'", ""));
					lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
					lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
					lPassword = Strings.LCase(lPassword);
					leCode = "";
					lCode = "";
					for (x = 1; x <= Strings.Len(lPassword); x++) {
						lCode = Strings.Mid(lPassword, x, 1);
						lCode = Convert.ToString(Strings.Asc(lCode));
						if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
							leCode = leCode + Strings.Mid(lPassword, x, 1);
						}
					}
					lPassword = leCode;
					rs = modRecordSet.getRS(ref "SELECT * FROM POS WHERE POS_IPAddress = 'localhost';");
					if (rs.RecordCount) {
						lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
						leCode = Encrypt(lCode, lPassword);
						modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
					}
					//new serialization check
				}
				this.Close();
			} else {
				Interaction.MsgBox("The 'Activation key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
			}
		}

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			functionReturnValue = "";
			Label4.Text = modRecordSet.serverPath;
			if (FSO.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = FSO.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
				Label3.Text = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;

		}

		private string Encrypt(string secret, string password)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(password);
			for (x = 1; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(password, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}


		public bool checkSecurity()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			modApplication.getLoginDate();
			//Piracy check

			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					//check Ban list
					if (modApplication.getBanList(ref rs.Fields("Company_Name").Value)) {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_PosString = '121832753'");
						// date 2006-09-16 753
						//MsgBox "Illegal function call." & vbCrLf & "application will now exit", vbCritical, "Run Time Error"
						//End
					}

					//check ban cdkeys
					if (getBanCDKey()) {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_PosString = '121832753'");
						// date 2006-09-16 753
					}

					if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
						modApplication.gSecKey = rs.Fields("Company_Code").Value;
						if (Strings.Len(rs.Fields("Company_Code").Value) == 13) {
							//checkSecurity = True
							//Exit Function
						}
					}
					lPassword = "pospospospos";
					lCode = getSerialNumber();

					//to handle WIN 98 problem of not picking HD Serial of server
					if (lCode == "0" & Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\" & !string.IsNullOrEmpty(rs.Fields("Company_Code").Value.ToString)) {
						//If lCode = "0" And LCase(Left(serverPath, 3)) <> "c:\" Then
						functionReturnValue = true;
						return functionReturnValue;
						//Else
					}
					//to handle WIN 98 problem of not picking HD Serial of server

					leCode = Encrypt(lCode, lPassword);
					for (x = 1; x <= Strings.Len(leCode); x++) {
						if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
							leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
						}
					}

					if (rs.Fields("Company_Code").Value.ToString == leCode) {
						//If IsNull(rs("Company_TerminateDate")) Then
						functionReturnValue = true;
						return functionReturnValue;
						//Else
						//    If Date > rs("Company_TerminateDate") Then
						//        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						//        checkSecurity = False
						//    End If
						//End If
					} else {
						if (checkDayEnds() == true) {
							functionReturnValue = true;
							return functionReturnValue;
						} else {
							txtCompany.Text = rs.Fields("Company_Name").Value;
							txtCompany.SelectionStart = 0;
							txtCompany.SelectionLength = 999;

							loadLanguage();
							this.ShowDialog(frmLogin);
						}
					}

					//End If
				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}


		public bool checkDayEnds()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rsComp = default(ADODB.Recordset);
			ADODB.Recordset rsPOS = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rsComp = modRecordSet.getRS(ref "SELECT * From Company");
				if (rsComp.RecordCount) {
					//If rsComp("Company_Code") <> "" Then
					if (!string.IsNullOrEmpty(rsComp.Fields("Company_Code").Value.ToString) & Strings.Len(rsComp.Fields("Company_Code").Value.ToString) >= 6 & !Information.IsNumeric(rsComp.Fields("Company_Code").Value.ToString)) {
						//Set rs = getRS("SELECT Max(DayEnd.DayEndID) AS maxID FROM DayEnd;")
						//If rs.BOF Or rs.EOF Then
						//    checkDayEnds = False
						//    Exit Function
						//Else
						//    If rs("maxID") >= 15 Then
						modApplication.blChkSecu = false;
						My.MyProject.Forms.frmRegisterAgree.blChkSecure();
						if (modApplication.blChkSecu == true) {
							//new serialization check    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '" & Replace("3571592584560", "'", "''") & "';"

							loadPreSerials();

							lPassword = "pospospospos";
							lCode = getSerialNumber();
							//MsgBox "lCode  " & lCode
							lCode = Encrypt(lCode, lPassword);
							//MsgBox "lCode  " & lCode
							modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" + Strings.Replace(lCode, "'", "''") + "';");

							lPassword = Strings.LTrim(Strings.Replace(rsComp.Fields("Company_Name").Value, "'", ""));
							lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
							lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
							lPassword = Strings.LCase(lPassword);
							leCode = "";
							lCode = "";
							for (x = 1; x <= Strings.Len(lPassword); x++) {
								lCode = Strings.Mid(lPassword, x, 1);
								lCode = Convert.ToString(Strings.Asc(lCode));
								if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
									leCode = leCode + Strings.Mid(lPassword, x, 1);
								}
							}
							lPassword = leCode;
							rsPOS = modRecordSet.getRS(ref "SELECT * FROM POS;");
							//WHERE POS_IPAddress = 'localhost';")
							if (rsPOS.RecordCount) {
								while (rsPOS.EOF == false) {
									if (rsPOS.Fields("POS_IPAddress").Value == "localhost") {
										lCode = Convert.ToString(rsPOS.Fields("POS_CID").Value * 135792468);
										leCode = Encrypt(lCode, lPassword);
										//leCode = leCode & Chr(255) & strCDKey
										leCode = leCode + Strings.Chr(255) + preSerial[rsPOS.Fields("POSID").Value];
										modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rsPOS.Fields("POS_CID").Value + ";");
									}
									rsPOS.MoveNext();
								}
							}

							//new serialization check
							functionReturnValue = true;
							return functionReturnValue;
						} else {
							functionReturnValue = false;
							return functionReturnValue;
						}
						//    Else
						//        checkDayEnds = False
						//        Exit Function
						//    End If
						//End If

					} else {
						functionReturnValue = false;
						return functionReturnValue;
					}

				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}

		private void loadPreSerials()
		{
			preSerial = new string[21];
			preSerial[0] = "B0ECB9F444347C66BB00001";
			preSerial[1] = "FB1863769BB68424B300002";
			preSerial[2] = "F1208835E63FE05D1300003";
			preSerial[3] = "EE8F5582E537C66B7400004";
			preSerial[4] = "1C15A97DF770A6E63300005";
			preSerial[5] = "4CFC05D13B2D03E7DD00006";
			preSerial[6] = "C83A20C3DC939C68D000007";
			preSerial[7] = "6698D3D57C753FDAC700008";
			preSerial[8] = "5DFE7F99EB090ED61F00009";
			preSerial[9] = "4C731DBD61F37B251300010";
			preSerial[10] = "64A72A7C0FF747EB4B00011";
			preSerial[11] = "8DD534E4DD07EAFA4B00012";
			preSerial[12] = "D37B45C581B4B2FF8400013";
			preSerial[13] = "2770B6008FF9CCA4FE00014";
			preSerial[14] = "E9764E9AF15982683000015";
			preSerial[15] = "B0AA5F109111C3099A00016";
			preSerial[16] = "620F3A446C700D8DE300017";
			preSerial[17] = "256B1211EC123E651700018";
			preSerial[18] = "559250B55D876EC98100019";
			preSerial[19] = "3999B6F959488AC1FD00020";
		}

		private void frmRegister_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdExit_Click(cmdExit, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmRegister_Load(object sender, System.EventArgs e)
		{
			picMode.AddRange(new Panel[] {
				_picMode_0,
				_picMode_1
			});
		}
	}
}
