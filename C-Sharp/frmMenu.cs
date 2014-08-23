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
namespace _4PosBackOffice.NET
{
	internal partial class frmMenu : System.Windows.Forms.Form
	{
		short gIndex;
		short gIndexMenu;
		string gSection;
		public int gBit;
		public bool gSuper;

		int gDayEndStart;
		int gDayEndEnd;
		List<Label> lblMenu = new List<Label>();
		public List<DateTimePicker> DTPicker1 = new List<DateTimePicker>();
		private void loadLanguage()
		{

			//NOTE: TEXT EMBEDDED IN BACKGROUND IMAGE- MUST CHANGE TO LABELS!

			//NOTE: MENU TEXT NOT DONE!!!
			//               ==========

			//frmMenu = No Code      [4POS Back Office]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMenu.Caption = rsLang("LanguageLayoutLnk_Description"): frmMenu.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code       [Before viewing reports, the date range needs.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code       [From Date]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code       [To Date]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblColor(0) = No Code/Dynamic/NA?
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblColor(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblColor(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblColor(1) = No Code/Dynamic/NA?
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblColor(1).Caption = rsLang("LanguageLayoutLnk_Description"): lblColor(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NO CODES/DYNAMIC FIELDS
			//=======================
			//lblCompany
			//lblDayEnd
			//lblDayEndCurrent
			//lblMenu(0)
			//lblMenuMain(0)
			//lblPath
			//lblUser
			//lblVersion

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMenu.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void upgradeWarning()
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Interaction.MsgBox("You are running an older version of 4POSBackOffice on this machine. System will now copy latest 4POSBackoffice application from main machine.");
			//Run the batch here
			if (fso.FileExists("C:\\4POS\\4POSUpdate.bat")) {
				Interaction.Shell("C:\\4POS\\4POSUpdate.bat", AppWinStyle.NormalFocus);
			} else {
				FileSystem.FileOpen(7, "C:\\4POS\\4POSUpdate.bat", OpenMode.Output);
				FileSystem.PrintLine(7, "ECHO OFF");
				FileSystem.PrintLine(7, "cls");
				FileSystem.PrintLine(7, "ECHO ------------------------------------------------------------------");
				FileSystem.PrintLine(7, "ECHO This will copy latest 4POSBackoffice application from main machine.");
				FileSystem.PrintLine(7, "pause");
				FileSystem.PrintLine(7, "copy " + Strings.Replace(modRecordSet.serverPath, "4posserver\\", "") + "4pos\\4POSOffice.exe" + " /B C:\\4POS /V /Y");
				//Print #7, "C:\4POS\4POSOffice.exe"
				FileSystem.PrintLine(7, "ECHO -");
				FileSystem.PrintLine(7, "ECHO -");
				FileSystem.PrintLine(7, "ECHO Please Run/Open 4POSBackoffice application now.");
				//Print #7, "ECHO ON"
				FileSystem.PrintLine(7, "pause");
				FileSystem.PrintLine(7, "exit");
				FileSystem.FileClose(7);
				Interaction.Shell("C:\\4POS\\4POSUpdate.bat", AppWinStyle.NormalFocus);
			}
		}

		public void loadMenu(string lMenu)
		{
			short y = 0;
			int parentID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsMain = default(ADODB.Recordset);
			ADODB.Recordset rsVer = default(ADODB.Recordset);
			//On Local Error Resume Next
			decimal x = default(decimal);
			string revName = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			int r = 0;
			My.MyProject.Forms.frmLoading.Show();
			System.Windows.Forms.Application.DoEvents();
			//MsgBox "loadMenu 1"
			ADODB.Recordset rsCNameBug = default(ADODB.Recordset);
			decimal cVerOrig = default(decimal);
			decimal cVerNew = default(decimal);
			string tempVerBug = null;
			string[] arrVerBug = null;
			if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\") {
				rsCNameBug = modRecordSet.getRS(ref "SELECT Company_Version FROM Company;");
				if (rsCNameBug.RecordCount) {
					if (Information.IsDBNull(rsCNameBug.Fields("Company_Version").Value)) {
					} else {
						tempVerBug = Strings.LTrim(rsCNameBug.Fields("Company_Version").Value);
						tempVerBug = Strings.RTrim(Strings.Replace(tempVerBug, " ", ""));
						tempVerBug = Strings.Trim(Strings.Replace(tempVerBug, "/", ""));
						arrVerBug = Strings.Split(tempVerBug, ".");
						if (Information.UBound(arrVerBug) == 2) {
							if (Strings.Len(arrVerBug[0]) < 2)
								arrVerBug[0] = "00" + arrVerBug[0];
							if (Strings.Len(arrVerBug[1]) < 2)
								arrVerBug[1] = "00" + arrVerBug[1];
							if (Strings.Len(arrVerBug[2]) < 4)
								arrVerBug[2] = "0000" + arrVerBug[2];

							arrVerBug[0] = Strings.Right(arrVerBug[0], 2);
							arrVerBug[1] = Strings.Right(arrVerBug[1], 2);
							arrVerBug[2] = Strings.Right(arrVerBug[2], 4);

							tempVerBug = arrVerBug[0] + arrVerBug[1] + arrVerBug[2];
							cVerOrig = Convert.ToDecimal(tempVerBug);
						}

						lblVersion.Text = _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Major + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Minor + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Revision;
						tempVerBug = Strings.LTrim(lblVersion.Text);
						tempVerBug = Strings.RTrim(Strings.Replace(tempVerBug, " ", ""));
						tempVerBug = Strings.Trim(Strings.Replace(tempVerBug, "/", ""));
						arrVerBug = Strings.Split(tempVerBug, ".");
						if (Information.UBound(arrVerBug) == 2) {
							if (Strings.Len(arrVerBug[0]) < 2)
								arrVerBug[0] = "00" + arrVerBug[0];
							if (Strings.Len(arrVerBug[1]) < 2)
								arrVerBug[1] = "00" + arrVerBug[1];
							if (Strings.Len(arrVerBug[2]) < 4)
								arrVerBug[2] = "0000" + arrVerBug[2];

							arrVerBug[0] = Strings.Right(arrVerBug[0], 2);
							arrVerBug[1] = Strings.Right(arrVerBug[1], 2);
							arrVerBug[2] = Strings.Right(arrVerBug[2], 4);

							tempVerBug = arrVerBug[0] + arrVerBug[1] + arrVerBug[2];
							cVerNew = Convert.ToDecimal(tempVerBug);
						}

						if (cVerNew < cVerOrig) {
							upgradeWarning();
							System.Environment.Exit(0);
						}
					}
				}
			} else {
				modRecordSet.cnnDB.Execute("UPDATE Company SET Company_Version = '" + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Major + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Minor + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Revision + "'");
			}
			lblVersion.Text = "Version: " + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Major + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Minor + "." + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Revision;

			//New encryption for version/company
			rsVer = modRecordSet.getRS(ref "SELECT * FROM Company");
			string tempVer = null;
			string[] arrVer = null;
			string[] arrName = null;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			if (rsVer.BOF | rsVer.EOF) {
				System.Environment.Exit(0);
			} else {
				//MsgBox "loadMenu 2"
				if (rsVer.Fields.Count >= 59) {
					//MsgBox "loadMenu 2 1"
					arrVer = new string[4];
					if (Strings.Len(Convert.ToString(_4PosBackOffice.NET.My.MyProject.Application.Info.Version.Major)) < 2)
						arrVer[0] = "00" + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Major;
					if (Strings.Len(Convert.ToString(_4PosBackOffice.NET.My.MyProject.Application.Info.Version.Minor)) < 2)
						arrVer[1] = "00" + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Minor;
					arrVer[2] = "0000" + _4PosBackOffice.NET.My.MyProject.Application.Info.Version.Revision;
					arrVer[0] = Strings.Right(arrVer[0], 2);
					arrVer[1] = Strings.Right(arrVer[1], 2);
					arrVer[2] = Strings.Right(arrVer[2], 4);
					tempVer = arrVer[0] + arrVer[1] + arrVer[2];
					tempVer = Conversion.Hex(Convert.ToInt32(tempVer));
					//lCode = CLng(("&H" & tempVer))
					//MsgBox "loadMenu 2 2"
					lPassword = rsVer.Fields("Company_Name").Value;
					lCode = "";
					leCode = "";
					for (x = 1; x <= Strings.Len(lPassword); x++) {
						lCode = Strings.Mid(lPassword, x, 1);
						leCode = leCode + Strings.Asc(lCode) + Strings.Chr(255);
						//leCode = leCode & Asc(lCode) & "|"
					}
					leCode = Strings.Left(leCode, Strings.Len(leCode) - 1);
					//MsgBox leCode
					//a = Len(leCode)
					//Debug.Print leCode
					//arrName = Split(leCode, Chr(255))
					//leCode = ""
					//For x = 0 To UBound(arrName)
					//    leCode = leCode & Chr(arrName(x))
					//Next
					//MsgBox "loadMenu 2 3"
					//check the company name
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(rsVer.Fields("Company_RePrintVN").Value)) {
						//MsgBox "loadMenu 2 41"
						lCode = tempVer + Strings.Chr(254) + leCode;
						//lCode = tempVer & "_" & leCode
						//MsgBox lCode
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" + lCode + "'");
						//MsgBox "loadMenu 2 41 finish"
					} else {
						//MsgBox "loadMenu 2 411"
						//If InStr(1, rsVer("Company_RePrintVN"), "_") Then
						if (Strings.InStr(1, rsVer.Fields("Company_RePrintVN").Value, Strings.Chr(254))) {
							//MsgBox "loadMenu 2 42"
							//leCode = Split(rsVer("Company_RePrintVN"), "_")(1)
							leCode = Strings.Split(rsVer.Fields("Company_RePrintVN").Value, Strings.Chr(254))[1];
							//lCode = tempVer & "_" & leCode
							lCode = tempVer + Strings.Chr(254) + leCode;
							//MsgBox lCode
							modRecordSet.cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" + lCode + "'");
							//MsgBox "loadMenu 2 42 1"
						} else {
							//MsgBox "loadMenu 2 422"
							//lCode = tempVer & "_" & leCode
							lCode = tempVer + Strings.Chr(254) + leCode;
							modRecordSet.cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" + lCode + "'");
						}
					}
				}
			}
			//New encryption for version/company
			//MsgBox "loadMenu 3"

			gSection = lMenu;
			rs = modRecordSet.getRS(ref "SELECT Company_Name FROM Company");
			if (rs.BOF | rs.EOF) {
				System.Environment.Exit(0);
			}
			lblCompany.Text = rs.Fields("Company_Name").Value;
			rs.Close();
			//rsMain = getRS("SELECT Menu.MenuID, Menu.Menu_ParentID, Menu.Menu_Name, Menu.Menu_Type, Menu.Menu_Action, Menu.Menu_Window, Menu.Menu_Bit, Menu.Menu_Help From Menu Where (((Menu.Menu_Section) = '" & gSection & "') AND ((Menu.Menu_Hide)=False)) ORDER BY Menu.Menu_ParentID, Menu.Menu_Order;")
			//MsgBox "loadMenu 4"
			rsMain = modRecordSet.getRS(ref "SELECT Menu_ParentID, Menu_Name, Menu_Action FROM Menu WHERE Menu_ParentID > 0;");
			foreach (string Name in rsMain.Fields("Menu_Name").Value) {
				MainMenu1.Items.Add(Name);
			}

			//For r = 2 To cols
			// rsMain = getRS("SELECT * FROM Menu WHERE (Menu_ParentID = " & r.ToString & ") ORDERBY MenuOrder;")
			// For Each Name As String In rsMain.Fields("Menu_Name").Value

			//Next
			//Next

			if (rsMain.BOF | rsMain.EOF) {
				System.Environment.Exit(0);
			}
			if (string.IsNullOrEmpty(Interaction.Command())) {
				//MsgBox "loadMenu 4   - 4"
				if (string.IsNullOrEmpty(lblUser.Tag)) {
					Interaction.MsgBox("No Security information found.", MsgBoxStyle.Critical, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					System.Environment.Exit(0);
				}
			} else {
				rs = modRecordSet.getRS(ref "SELECT * FROM Person where PersonID = " + Interaction.Command());
				if (rs.BOF | rs.EOF) {
					Interaction.MsgBox("Unable to retreive security information.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				} else {
					//MsgBox "loadMenu 5"
					if (rs.RecordCount == 1) {
						this.lblUser.Tag = rs.Fields("PersonID").Value;
						this.lblUser.Text = rs.Fields("Person_FirstName").Value + " " + rs.Fields("Person_LastName").Value;

						if (Strings.Len(rs.Fields("Person_QuickAccess").Value) > 0) {
							for (x = Strings.Len(rs.Fields("Person_QuickAccess").Value); x >= 1; x += -1) {
								revName = revName + Strings.Mid(rs.Fields("Person_QuickAccess").Value, x, 1);
							}
							if (Strings.LCase(Strings.Left(rs.Fields("Person_Position").Value, 8)) == "4posboss" & Strings.LCase(Strings.Right(rs.Fields("Person_Position").Value, Strings.Len(rs.Fields("Person_QuickAccess").Value))) == revName) {
								this.lblUser.ForeColor = System.Drawing.Color.Yellow;
								this.gSuper = true;
							}
						}

						gBit = rs.Fields("Person_SecurityBit").Value;
					} else {
						Interaction.MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login");
						System.Environment.Exit(0);
					}
					//MsgBox "loadMenu 6"
				}
			}
			//    buildMenus 1, picMenuList(0), rsMain
			rs = rsMain.Clone;
			rs.Filter = "Menu_ParentID=1" + parentID;
			//MsgBox "loadMenu 7"
			while (!(rs.EOF)) {
				x = 0;
				//lblMenuMain.Load(x)
				//_lblMenuMain_0.Visible = True

				//_lblMenuMain_0.Text = rs.Fields("Menu_Name").Value
				//_lblMenuMain_0.BringToFront()
				//_lblMenuMain_0.Top = twipsToPixels(pixelToTwips(_lblMenuMain_0.Top, False) + (pixelToTwips(_lblMenuMain_0.Height, False) + 120) * (x - 1), False)
				if (rs.Fields("Menu_Type").Value == "menu") {
					//picMenuList.Load(picMenuList.UBound + 1)
					//    _lblMenuMain_0.Tag = 0
					//    _picMenuList_0.Tag = rs.Fields("MenuID").Value
					//    buildMenus(rs.Fields("MenuID").Value, _picMenuList_0, rs, CStr(0))
				}

				rs.MoveNext();
			}
			//MsgBox "loadMenu 8"
			for (y = 0; y <= this.Controls.Count() - 1; y++) {
				if (((object)Controls[y]).Name == "lblMenu") {
					//CType(Controls(y), Object).Width = twipsToPixels(pixelToTwips(CType(Controls(y), Object).Parent.Width, True) - pixelToTwips(_imgArrow_0.Width, True) - 100 - pixelToTwips(_imgMenu_1.Width, True), True)
					if (Strings.Left(((object)Controls[y]).Tag, 1) == "m") {
						//Controls(y).Container.PaintPicture Me._imgArrow_0.Picture, Controls(y).Container.Width - (Me._imgArrow_0.Width + 50), Controls(y).Top
						//CType(Controls(y), Object).Parent.PaintPicture(Me._imgArrow_0.Image, pixelToTwips(CType(Controls(y), Object).Parent.Width, True) - (pixelToTwips(Me._imgArrow_0.Width, True) + pixelToTwips(Me._imgMenu_1.Width, True)), pixelToTwips(CType(Controls(y), Object).Top, True) + 45, False)
					}
				}
			}
			//MsgBox "loadMenu 9"
			if (gBit & 4096){chkDash.Visible = true;Label2.Visible = true;}
			else{chkDash.Visible = false;Label2.Visible = false;}

			this.Show();
			//MsgBox "loadMenu 10"
			mnWelcome_Click();
			//MsgBox "loadMenu 11"
			System.Windows.Forms.Application.DoEvents();
			Text1.Focus();
			tmrMenuShow_Tick(tmrMenuShow, new System.EventArgs());
			//MsgBox "loadMenu 12"
			//For x = 0 To Me.picMenuList.UBound
			//_picMenuList_0.Visible = False
			//Next x
			//MsgBox "loadMenu 13"
			System.Windows.Forms.Application.DoEvents();

			My.MyProject.Forms.frmLoading.Close();
			//MsgBox "loadMenu 14"
		}

		//Private Sub buildMenus(ByVal parentID As Integer, ByRef picMenu As System.Windows.Forms.PictureBox, ByRef rsMain As ADODB.Recordset, ByRef thePath As String)
		//Dim rs As ADODB.Recordset

		//Dim x As Short
		//Dim y As Short
		//    rs = New ADODB.Recordset
		//    rs = rsMain.Clone
		//Dim lPath As String
		//    Debug.Print(thePath)
		//    On Error Resume Next
		//lPath = thePath & "," & picMenu.Index
		//picMenu.Tag = lPath
		//rs.Filter = "Menu_ParentID=" & parentID
		//picMenu.Height = twipsToPixels(rs.RecordCount * (pixelToTwips(_lblMenu_0.Height, False) + 90) + 120 + 300, False)
		//picMenu.PaintPicture(Me._imgMenu_0, 0, 0)
		//   y = 0

		//Do Until rs.EOF
		//   y = y + 1
		//x = lblMenu.UBound + 1
		//lblMenu.Load(x)
		//_lblMenu_0.Parent = picMenu
		//_lblMenu_0.Text = rs("Menu_Name")
		//_lblMenu_0.Visible = True
		//If rs("Menu_Bit").Value And gBit Then
		// _lblMenu_0.Enabled = True
		// Else
		// _lblMenu_0.Enabled = False
		// End If
		// _lblMenu_0.Top = twipsToPixels(120 + (pixelToTwips(_lblMenu_0.Height + 90, False) * (y - 1)), False)
		// System.Windows.Forms.Application.DoEvents()
		// If twipsToPixels(picMenu.Width, True) - 400 < pixelToTwips(_lblMenu_0.Width, True) Then
		// picMenu.Width = twipsToPixels(400 + pixelToTwips(_lblMenu_0.Width, True), True)
		// End If
		// _lblMenu_0.Tag = VB.Left(rs("Menu_Type").Value, 1) & rs("Menu_Action").Value
		// If rs("Menu_Type") = "menu" Then
		// 'picMenuList.Load(picMenuList.UBound + 1)
		//_picMenuList_0.Tag = 0
		//_lblMenu_0.Tag = "m" & _picMenuList_0.Tag
		//buildMenus(rs("MenuID").Value, _picMenuList_0, rsMain, lPath)
		//End If
		//rs.MoveNext()
		//Loop
		//picMenu.PaintPicture(Me._imgMenu_1, pixelToTwips(picMenu.Width, True) - _
		//                     pixelToTwips(imgMenu(1).Width, True), 0)
		//picMenu.PaintPicture(Me.imgMenu(0), 0, 0)
		//picMenu.PaintPicture(Me.imgMenu(2), 0, 0)
		//picMenu.PaintPicture(Me.imgMenu(3), 0, _
		//                     pixelToTwips(picMenu.Height, False) - _
		//                     pixelToTwips(imgMenu(3).Height, False), , , _
		//                     pixelToTwips(imgMenu(3).Width, True) - _
		//                     pixelToTwips(picMenu.Width, True))
		//End Sub



		private void chkDash_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkDash.CheckState == 1) {
				mnuDashboard_Click(mnuDashboard, new System.EventArgs());
			} else {
				mnWelcome_Click();
			}
		}

		public void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			 // ERROR: Not supported in C#: OnErrorStatement

			if (modReport.cnnDBreport.State)
				modReport.cnnDBreport.Close();

			modApplication.modUpdate = 0;
			modApplication.updateStockMovement();
			//Defining the period from report are being loaded from

			//I need code
			if (fso.FileExists(modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb"))
				fso.DeleteFile(modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb");
			fso.CopyFile(modRecordSet.serverPath + "templateReport.mdb", modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb", true);
			modReport.openConnectionReport();

			rs = modReport.getRSreport(ref "SELECT * FROM Report");
			if (rs.RecordCount) {
				modReport.cnnDBreport.Execute("UPDATE Report SET Report.Report_DayEndStartID = " + gDayEndStart + ", Report.Report_DayEndEndID = " + gDayEndEnd + ", Report.Report_Heading = '" + this.lblDayEnd.Text + "';");
			} else {
				modReport.cnnDBreport.Execute("INSERT INTO Report ( Report_DayEndStartID, Report_DayEndEndID, Report_Heading, ReportID ) SELECT " + gDayEndStart + ", " + gDayEndEnd + ", '" + this.lblDayEnd.Text + "', 1;");

			}
			//Dim form As frmUpdateDayEnd
			My.MyProject.Forms.frmUpdateDayEnd.Show();
			lblDayEndCurrent.Text = lblDayEnd.Text;

			return;
			errLoad:
			if (Err().Number == 70) {
				//MsgBox Err.Number & " " & Err.Description & " " & Err.source & vbCrLf & vbCrLf & " Cannot perform this action, report database is being used by another person or program. Please close any program that might be using the report database and try again."
				Interaction.MsgBox("You are logged into the 4POSBackOffice on another computer with the same Username & Password. You can not load reports if logged onto more than 1 PC. Please close the other 4POSOffice program first before attempting to 'Load Reports' on this PC");
				//You have logged on to the 4POS Back Office program on another PC. You can not load reports if logged onto more than 1 PC. Please log out on the other PC/s.
			} else {
				Interaction.MsgBox(Err().Number + Err().Description);
			}
		}
		public void Automaticload()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			modReport.cnnDBreport.Close();

			//modUpdate = 2
			//updateStockMovement          'Defining the period from report are being loaded from

			//I need code
			if (fso.FileExists(modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb"))
				fso.DeleteFile(modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb");
			fso.CopyFile(modRecordSet.serverPath + "templateReport.mdb", modRecordSet.serverPath + "report" + this.lblUser.Tag + ".mdb", true);
			modReport.openConnectionReport();

			rs = modReport.getRSreport(ref "SELECT * FROM Report");
			if (rs.RecordCount) {
				modReport.cnnDBreport.Execute("UPDATE Report SET Report.Report_DayEndStartID = " + gDayEndStart + ", Report.Report_DayEndEndID = " + gDayEndEnd + ", Report.Report_Heading = '" + this.lblDayEnd.Text + "';");
			} else {
				modReport.cnnDBreport.Execute("INSERT INTO Report ( Report_DayEndStartID, Report_DayEndEndID, Report_Heading, ReportID ) SELECT " + gDayEndStart + ", " + gDayEndEnd + ", '" + this.lblDayEnd.Text + "', 1;");

			}
			frmUpdateDayEnd form = null;
			form.Show();
			lblDayEndCurrent.Text = lblDayEnd.Text;

		}

		public void cmdToday_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]));");

			if (rs.RecordCount) {
				_DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value;
				_DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value;
				setDayEndRange();
			}
			_DTPicker1_0.Focus();
		}


		private void cmdYesterday_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]-1));");
			if (rs.RecordCount) {
				_DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value;
				_DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value;
				setDayEndRange();
			} else {
				cmdToday_Click(cmdToday, new System.EventArgs());
			}
			_DTPicker1_0.Focus();

		}

		public void setDayEndRange()
		{
			System.DateTime lDate = default(System.DateTime);
			string lDateString = null;
			string[] lDateArray = null;
			System.DateTime lDateStart = default(System.DateTime);
			System.DateTime lDateEnd = default(System.DateTime);
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement

			lDateStart = _DTPicker1_0.Value;
			lDateEnd = _DTPicker1_1.Value;
			lDateStart = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateStart), 10));
			lDateEnd = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateEnd), 10));

			if (lDateStart >= lDateEnd) {
				lDateStart = _DTPicker1_1.Value;
				lDateEnd = _DTPicker1_0.Value;
			}
			lDateStart = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateStart), 10));
			lDateEnd = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateEnd), 10));

			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) >= #" + lDateStart + " 00:00:00#)) ORDER BY DayEnd.DayEnd_Date;");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT Max(DayEnd.DayEndID) AS DayEndID FROM DayEnd;");

			}
			gDayEndStart = rs.Fields("DayEndID").Value;
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) <= #" + lDateEnd + " 23:59:59#)) ORDER BY DayEnd.DayEnd_Date DESC;");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT Min(DayEnd.DayEndID) AS DayEndID FROM DayEnd;");

			}
			gDayEndEnd = rs.Fields("DayEndID").Value;
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT Count(DayEnd.DayEndID) AS [count], Min(DayEnd.DayEnd_Date) AS fromDate, Max(DayEnd.DayEnd_Date) AS toDate From DayEnd WHERE (((DayEnd.DayEndID)>= " + gDayEndStart + ") AND ((DayEnd.DayEndID) <= " + gDayEndEnd + "));");

			lblDayEnd.Text = "From " + Strings.Format(rs.Fields("fromDate").Value, "ddd dd mmm yyyy");
			lblDayEnd.Text = lblDayEnd.Text + " to ";
			lblDayEnd.Text = lblDayEnd.Text + Strings.Format(rs.Fields("toDate").Value, "ddd dd mmm yyyy");
			lblDayEnd.Text = lblDayEnd.Text + " covering " + rs.Fields("count").Value + " day-end/s.";
			_DTPicker1_0.Format = DateTimePickerFormat.Custom;
			_DTPicker1_0.CustomFormat = string.Format("{0} {1} {2}", Strings.Format(rs.Fields("fromDate").Value, "yyyy"), Strings.Format(rs.Fields("fromDate").Value, "m"), Strings.Format(rs.Fields("fromDate").Value, "d"));
			_DTPicker1_1.Format = DateTimePickerFormat.Custom;
			_DTPicker1_1.CustomFormat = string.Format("{0} {1} {2}", Strings.Format(rs.Fields("toDate").Value, "yyyy"), Strings.Format(rs.Fields("toDate").Value, "m"), Strings.Format(rs.Fields("toDate").Value, "d"));
		}

		//Handles DTPicker1
		private void DTPicker1_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			DateTimePicker dtp = new DateTimePicker();
			dtp = (DateTimePicker)eventSender;
			int Index = GetIndex.GetIndexer(ref dtp, ref DTPicker1);
			setDayEndRange();
		}
		private void frmMenu_KeyUp(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (Shift == 4 & KeyCode == 82) {
				if (gBit & 4096) {
					Text1.Focus();

					tmrReports.Enabled = true;
					KeyCode = 0;
				}
			}
			if (KeyCode == 40) {
				System.Windows.Forms.SendKeys.Send("{tab}");
				KeyCode = 0;
			}
			if (KeyCode == 38) {
				System.Windows.Forms.SendKeys.Send("+{tab}");
				KeyCode = 0;
			}

		}
		private void frmMenu_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			DTPicker1.AddRange(new DateTimePicker[] {
				_DTPicker1_0,
				_DTPicker1_1
			});

			ADODB.Recordset rst = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			Module1.bUploadReport = false;

			modBResolutions.blResolution = false;
			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);
			if (modBResolutions.blResolution == true) {
				//Manually align controlls
				if (fso.FileExists(modRecordSet.serverPath + "4POSBack800.jpg")) {
					this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
					this.BackgroundImage = System.Drawing.Image.FromFile(modRecordSet.serverPath + "4POSBack800.jpg");
				}
				Image1.Top = 0;
				Image1.Left = 0;
				Image1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
				Image1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
				//Image1.Visible = False
				//nWRatio = nW / 15360: nHRatio = nH / 11520
				Image2.Top = 0;
				Image2.Left = 0;
				Image2.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
				Image2.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

				//Realign Server path
				lblPath.Top = sizeConvertors.twipsToPixels((sizeConvertors.pixelToTwips(lblCompany.Top, false) + sizeConvertors.pixelToTwips(lblCompany.Height, false)), false);
				lblUser.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblUser.Top, false) + 90, false);
				lblVersion.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblVersion.Top, false) + 120, false);
				lblDayEndCurrent.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblVersion.Top, false) - 50, false);
				Label2.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblVersion.Top, false) - 50, false);
				chkDash.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblVersion.Top, false) - 50, false);
				//Label1.Top = Label1.Top + 90
				//lblUser.Top = lblUser.Top + 90
				//lblMenuMain(0).Top = lblMenuMain(0).Top + 90
				//CRViewer1.Left = -200
				//CRViewer1.Width = CRViewer1.Width + 100

			} else {
				lblPath.Top = sizeConvertors.twipsToPixels(1000, false);

				Image1.Top = 0;
				Image1.Left = 0;
				//Image1.Width = Screen.Width: Image1.Height = Screen.Height
				//Image1.Visible = False
				//nWRatio = nW / 15360: nHRatio = nH / 11520
				Image2.Top = 0;
				Image2.Left = 0;
				Image2.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
				Image2.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			}

			gIndex = -1;
			lblPath.Text = modRecordSet.serverPath;

		}
		private void frmMenu_MouseDown(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)
		{
			short Button = eventArgs.Button / 0x100000;
			short Shift = System.Windows.Forms.Control.ModifierKeys / 0x10000;
			float x = sizeConvertors.pixelToTwips(eventArgs.X, true);
			float y = sizeConvertors.pixelToTwips(eventArgs.Y, false);
			gIndex = -1;
			Text1.Focus();
			tmrMenuShow_Tick(tmrMenuShow, new System.EventArgs());
		}

		private void frmMenu_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//Dim lRetVal As Long
			//Dim vValue As String
			//Dim rsBack As Recordset
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.TextStream textstream = default(Scripting.TextStream);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			if (Interaction.MsgBox("Do you wish to perform Backup?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				rs = modRecordSet.getRS(ref "select Company_BackupPath from Company");
				if (rs.RecordCount) {
					if (!string.IsNullOrEmpty(rs.Fields("Company_BackupPath").Value)) {
						if (fso.FileExists("C:\\4POSBackup.txt"))
							fso.DeleteFile("C:\\4POSBackup.txt", true);

						textstream = fso.OpenTextFile("C:\\4POSBackup.txt", Scripting.IOMode.ForWriting, true);
						textstream.Write(rs.Fields("Company_BackupPath").Value);
						textstream.Close();
					}
				}

				Interaction.Shell("c:\\4pos\\4posbackup.exe", AppWinStyle.NormalFocus);
				System.Windows.Forms.Application.DoEvents();
			}

			System.Environment.Exit(0);
			//ExitProcess 0

			//Set rsBack = getRS("SELECT Company_DayEndBit FROM Company")

			//If Abs(CBool(rsBack("Company_DayEndBit") And gCopySalesToHQ)) Then
			//   closeConnection       'Close pricing DB connectons
			//   closeConnectionReport 'Close report connection

			//   lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hKey)
			//   lRetVal = QueryValueEx(hKey, "compress", vValue)
			//   If vValue = "" Then vValue = 0
			//   If CBool(vValue) Then
			//      frmBackupDatabase.show 1
			//   End If
			//
			//End If
			//DeleteTempFiles

			return;
			unloadErr:
			Interaction.MsgBox(Err().Description);
			System.Environment.Exit(0);
		}

		private void Label1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim givPass As String
			//givPass = InputBox("Please Enter Password!", "Please Enter Password!")
			//If givPass = "786" Then
			//    For x = dayStart To dayEnd
			//        'Multi Warehouse change     cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
			//        'Tranfer change             cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
			//        cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV]+[dayEndToday]![DayEndStockItemLnk_QuantityTransafer] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
			//    Next x
			//    MsgBox "Done"
			//Else
			//    MsgBox "invalid pass"
			//End If
		}


		private void lblCompany_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short intDate = 0;
			string dtDate = null;
			string dtMonth = null;
			string stPass = null;
			string givPass = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			givPass = Interaction.InputBox("Please Enter Password!", "Please Enter Password!");
			//Construct password...........
			//If KeyAscii = 13 Then
			intDate = DateAndTime.Day(DateAndTime.Today) * 2;
			if (Strings.Len(Convert.ToString(intDate)) == 1)
				dtDate = "0" + Convert.ToString(intDate);
			else
				dtDate = Strings.Trim(Convert.ToString(intDate));

			intDate = DateAndTime.Month(DateAndTime.Today) * 2;
			if (Strings.Len(Convert.ToString(intDate)) == 1)
				dtMonth = "0" + Convert.ToString(intDate);
			else
				dtMonth = Strings.Trim(Convert.ToString(intDate));

			//Create password
			stPass = dtDate + "##" + dtMonth;
			stPass = Strings.Replace(stPass, " ", "");


			if (Strings.Trim(givPass) == stPass) {
				givPass = Interaction.InputBox("Please Enter Security Code!", "Please Enter Security Code!");
				//And Len(givPass) = 13
				if (Information.IsNumeric(givPass)) {

					modRecordSet.cnnDB.Execute("UPDATE Company SET Company_PosString = '" + Strings.Trim(givPass) + "'");
					Interaction.MsgBox("Security Code saved!!!", MsgBoxStyle.Exclamation, "Security Code");

				} else {
					Interaction.MsgBox("Invalid Security Code!!!", MsgBoxStyle.Exclamation, "Security Code");
				}

			} else {
				Interaction.MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords");
			}

			//End If
			return;
			Hell_Error:
			Interaction.MsgBox(Err().Number + " - " + Err().Description, MsgBoxStyle.Exclamation, "Incorrect Passwords");
			return;
		}


		private void lblMenu_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			//Select Case VB.Left(_lblMenu_0.Tag, 1)
			//    Case "m"
			//    Case "f"
			//tmrForm.Tag = Mid(_lblMenu_0.Tag, 2)
			//tmrForm.Enabled = True
			//    Case "a"
			//End Select
		}

		private void lblMenu_MouseMove(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)
		{
			short Button = eventArgs.Button / 0x100000;
			short Shift = System.Windows.Forms.Control.ModifierKeys / 0x10000;
			float x = sizeConvertors.pixelToTwips(eventArgs.X, true);
			float y = sizeConvertors.pixelToTwips(eventArgs.Y, false);
			short Index = 0;
			short lIndex = 0;
			string[] lArray = null;
			bool lRemoveMenu = false;
			lRemoveMenu = false;
			if (gIndexMenu == Index)
				return;
			if (gIndexMenu != -1) {

				if (Strings.Left(lblMenu[gIndexMenu].Tag, 1) == "m") {
					lIndex = Convert.ToInt16(Strings.Split(Strings.Mid(lblMenu[gIndexMenu].Tag, 2), "_")[0]);
					//If lblMenu(gIndexMenu).Parent = _lblMenu_0.Parent Then
					//_picMenuList_0.Visible = False
					//End If

				} else {
				}
				//lblMenu(gIndexMenu).BackStyle = 0
				//lblMenu(gIndexMenu).BackColor = _lblColor_0.BackColor
				//lblMenu(gIndexMenu).ForeColor = _lblColor_0.ForeColor
				//If lblMenu(gIndexMenu).Parent.Index <> _lblMenu_0.Parent.Index Then
				//or y = 0 To 1
				//blMenu(y).BackStyle = 0
				//_lblMenu_0.BackColor = _lblColor_0.BackColor
				//_lblMenu_0.ForeColor = _lblColor_0.ForeColor
				//Next
				//For x = 0 To Me.picMenuList.UBound
				//_picMenuList_0.Visible = False
				//Next x

				//lArray = Split(_lblMenu_0.Parent.Tag, ",")
				//For x = 1 To UBound(lArray)
				//_picMenuList_0.Visible = True
				//For y = lblMenu.LBound To lblMenu.UBound
				//If _lblMenu_0.Tag = "m" & lArray(x) Then
				//lblMenu(y).BackStyle = 1
				//_lblMenu_0.BackColor = _lblColor_1.BackColor
				//_lblMenu_0.ForeColor = _lblColor_1.ForeColor
				System.Environment.Exit(0);
				//If
				//Next

			}
			//_lblMenu_0.BackStyle = 1
			//_lblMenu_0.BackColor = _lblColor_1.BackColor
			//_lblMenu_0.ForeColor = _lblColor_1.ForeColor
			//If VB.Left(_lblMenu_0.Tag, 1) = "m" Then
			// lIndex = CShort(Split(Mid(_lblMenu_0.Tag, 2), "_")(0))
			// _picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Left, True) + pixelToTwips(_lblMenu_0.Left, True) + pixelToTwips(_lblMenu_0.Parent.Width, True) - 250, True)
			// If pixelToTwips(_picMenuList_0.Left, True) + pixelToTwips(_picMenuList_0.Width, True) > pixelToTwips(Me.Width, True) - 100 Then
			// _picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Left, True) - pixelToTwips(_picMenuList_0.Width, True) + 110, True)

			//End If
			//_picMenuList_0.BringToFront()
			//_picMenuList_0.Top = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Top, False) + pixelToTwips(_lblMenu_0.Top, False) - 120, False)
			//If pixelToTwips(_picMenuList_0.Top, False) + pixelToTwips(_picMenuList_0.Height, False) > pixelToTwips(Me.Height, False) - 100 Then
			// _picMenuList_0.Top = twipsToPixels(pixelToTwips(Me.Height, False) - pixelToTwips(_picMenuList_0.Height, False) - 800, False)

			// End If
			//Me._picMenuList_0.Visible = True
			//End If
			gIndexMenu = Index;
		}
		private void lblMenuMain_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			if (gIndex != Index) {
				gIndex = Index;
				tmrMenuShow.Enabled = true;
			}

		}
		private void lblMenuMain_MouseMove(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)
		{
			short Button = eventArgs.Button / 0x100000;
			short Shift = System.Windows.Forms.Control.ModifierKeys / 0x10000;
			float x = sizeConvertors.pixelToTwips(eventArgs.X, true);
			float y = sizeConvertors.pixelToTwips(eventArgs.Y, false);
			short Index = 0;
			//lblMenuMain_Click(_lblMenuMain_0, New System.EventArgs())
		}

		private void tmrForm_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrForm.Enabled = false;
			modApplication.doMenuForms(ref tmrForm.Tag);
		}
		private void tmrMenuShow_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrMenuShow.Enabled = false;
			short x = 0;
			//For x = 0 To lblMenuMain.UBound
			//_lblMenuMain_0.BackColor = _lblColor_0.BackColor
			//_lblMenuMain_0.ForeColor = _lblColor_0.ForeColor
			//_lblMenuMain_0.BackStyle = 0
			//Next x
			//For x = 0 To Me.lblMenu.UBound
			//_lblMenu_0.BackColor = _lblColor_0.BackColor
			//_lblMenu_0.ForeColor = _lblColor_0.ForeColor
			//_lblMenu_0.BackStyle = 0
			//Next
			gIndexMenu = -1;
			//For x = 0 To picMenuList.UBound
			//_picMenuList_0.Visible = False
			//Next
			if (gIndex == -1) {
			} else {
				//If _lblMenuMain_0.Tag = "" Then
				//Else
				//_picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenuMain_0.Left, True) + pixelToTwips(_lblMenuMain_0.Width, True) + 120, True)
				//_picMenuList_0.Top = _lblMenuMain_0.Top
				//_picMenuList_0.BringToFront()

				//Me._picMenuList_0.Visible = True
				//_lblMenuMain_0.BackStyle = 1
				//_lblMenuMain_0.BackColor = _lblColor_1.BackColor
				//_lblMenuMain_0.ForeColor = _lblColor_1.ForeColor
			}
			//End If
		}

		private void tmrReportCancel_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			mnWelcome_Click();

		}

		private void tmrReports_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrReports.Enabled = false;
			System.Windows.Forms.Application.DoEvents();
			//UPGRADE_ISSUE: Form method frmMenu.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//PopupMenu(Me.mnuReports, , pixelToTwips(Me.picReport.Left, True) + 30, pixelToTwips(picReport.Top, False) + 30)
			this.Activate();
			System.Windows.Forms.Application.DoEvents();
		}

		public void mnuDashboard_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Report As New cryMenuSalesCube
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("c:\\4posserver\\Reports\\cryMenuSalesCube.rpt");
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lTotal = default(decimal);

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			//money
			rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Total) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((Sale.Sale_PaymentType)<>5) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtCubeMoney.", "0.00");
			} else {
				Report.SetParameterValue("txtCubeMoney", Strings.FormatNumber(rs.Fields("amount").Value, 2));
			}
			rs.Close();

			//Stock
			rs = modRecordSet.getRS(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtCubeStock", "0.00");
			} else {
				Report.SetParameterValue("txtCubeStock", Strings.FormatNumber(rs.Fields("amount").Value, 2));
			}
			rs.Close();

			//Account sales
			rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType HAVING (((Sale.Sale_PaymentType)=5));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtCubeAccountSales", "0.00");
			} else {
				if (rs.RecordCount) {
					Report.SetParameterValue("txtCubeAccountSales", Strings.FormatNumber(rs.Fields("amount").Value, 2));
				} else {
					Report.SetParameterValue("txtCubeAccountSales", "0.00");
				}
			}
			rs.Close();

			//Account payments
			rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType HAVING (((Sale.Sale_PaymentType)<>5));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtCubeAccountPayment", "0.00");
			} else {
				if (rs.RecordCount) {
					Report.SetParameterValue("txtCubeAccountPayment", Strings.FormatNumber(rs.Fields("amount").Value, 2));
				} else {
					Report.SetParameterValue("txtCubeAccountPayment", "0.00");
				}
			}
			rs.Close();

			//Direct Sales
			rs = modRecordSet.getRS(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtCubeDirect", "0.00");
			} else {
				Report.SetParameterValue("txtCubeDirect", Strings.FormatNumber(rs.Fields("amount").Value, 2));
			}
			rs.Close();

			//Open Tables
			ADODB.Connection cn = new ADODB.Connection();
			cn = modRecordSet.openConnectionInstance(ref "waitron.mdb");
			if (cn == null) {
				Report.SetParameterValue("txtCubeOpenTbl", "Not Found!");
			} else {
				rs = modRecordSet.getRSwaitron(ref "SELECT Sum([TableTranactionItem_price]*[TableTranactionItem_quantity]) AS Amount FROM OpenTable INNER JOIN TableTranactionItem ON (OpenTable.OpenTable_TableID = TableTranactionItem.TableTranactionItem_TableID) AND (OpenTable.OpenTable_WaitronID = TableTranactionItem.TableTranactionItem_WaitronID);", ref cn);
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtCubeOpenTbl", "0.00");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtCubeOpenTbl", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtCubeOpenTbl", "0.00");
					}
				}
				rs.Close();
			}

			Report.SetParameterValue("txtCubeAccount", Strings.FormatNumber(Report.ParameterFields("txtCubeAccountSales").ToString - Report.ParameterFields("txtCubeAccountPayment").ToString, 2));
			//    Report.txtCubeDirect.SetText FormatNumber(Report.txtCubeMoney.Text - Report.txtCubeAccountPayment.Text, 2)


			//Profit Summary

			rs = modRecordSet.getRS(ref "SELECT Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS actualIncl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS listIncl, Sum([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100)) AS priceExcl, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS priceIncl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS depositIncl FROM (Sale INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) INNER JOIN (SaleItem LEFT JOIN Consignment ON SaleItem.SaleItem_SaleID = Consignment.Consignment_SaleID) ON Sale.SaleID = SaleItem.SaleItem_SaleID WHERE (((SaleItem.SaleItem_Reversal)=False) AND ((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null));");
			Report.SetParameterValue("txtLEcost", Strings.FormatNumber(rs.Fields("listExcl").Value, 0));
			Report.SetParameterValue("txtAEcost", Strings.FormatNumber(rs.Fields("actualExcl").Value, 0));
			Report.SetParameterValue("txtLIcost", Strings.FormatNumber(rs.Fields("listIncl").Value, 0));
			Report.SetParameterValue("txtAIcost", Strings.FormatNumber(rs.Fields("actualIncl").Value, 0));
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLEcost").ToString))
				Report.SetParameterValue("txtLEcost", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLIcost").ToString))
				Report.SetParameterValue("txtLIcost", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAEcost").ToString))
				Report.SetParameterValue("txtAEcost", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAIcost").ToString))
				Report.SetParameterValue("txtAIcost", "0");

			Report.SetParameterValue("txtLEdeposit", Strings.FormatNumber(rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtLIdeposit", Strings.FormatNumber(rs.Fields("depositIncl").Value, 0));
			Report.SetParameterValue("txtAEdeposit", Strings.FormatNumber(rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtAIdeposit", Strings.FormatNumber(rs.Fields("depositIncl").Value, 0));
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLEdeposit").ToString))
				Report.SetParameterValue("txtLEdeposit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLIdeposit").ToString))
				Report.SetParameterValue("txtLIdeposit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAEdeposit").ToString))
				Report.SetParameterValue("txtAEdeposit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAIdeposit").ToString))
				Report.SetParameterValue("txtAIdeposit", "0");

			Report.SetParameterValue("txtLEcontent", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtLIcontent", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value, 0));
			Report.SetParameterValue("txtAEcontent", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtAIcontent", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value, 0));
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLEcontent").ToString))
				Report.SetParameterValue("txtLEcontent", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLIcontent").ToString))
				Report.SetParameterValue("txtLIcontent", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAEcontent").ToString))
				Report.SetParameterValue("txtAEcontent", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAIcontent").ToString))
				Report.SetParameterValue("txtAIcontent", "0");

			Report.SetParameterValue("txtLEProfit", Strings.FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("listExcl")).Value, 0));
			Report.SetParameterValue("txtLIProfit", Strings.FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("listIncl")).Value, 0));
			Report.SetParameterValue("txtAEProfit", Strings.FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("actualExcl")).Value, 0));
			Report.SetParameterValue("txtAIProfit", Strings.FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("actualIncl")).Value, 0));
			if (Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) == 0) {
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEProfit").ToString))
					Report.SetParameterValue("txtLEProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLIProfit").ToString))
					Report.SetParameterValue("txtLIProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEProfit").ToString))
					Report.SetParameterValue("txtAEProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAIProfit").ToString))
					Report.SetParameterValue("txtAIProfit", "0");
			} else {
				Report.SetParameterValue("txtLEPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtLEProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) * 100, 2) + "%");
				Report.SetParameterValue("txtLIPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtLIProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtLIcost").ToString) * 100, 2) + "%");
				Report.SetParameterValue("txtAEPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtAEProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtAEcost").ToString) * 100, 2) + "%");
				Report.SetParameterValue("txtAIPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtAIProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtAIcost").ToString) * 100, 2) + "%");
			}
			Report.SetParameterValue("txtLEtotalProfit", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("listExcl").Value - rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtLItotalProfit", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("listIncl").Value - rs.Fields("depositIncl").Value, 0));
			Report.SetParameterValue("txtAEtotalProfit", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("actualExcl").Value - rs.Fields("depositExcl").Value, 0));
			Report.SetParameterValue("txtAItotalProfit", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("actualIncl").Value - rs.Fields("depositIncl").Value, 0));
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLEtotalProfit").ToString))
				Report.SetParameterValue("txtLEtotalProfit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLItotalProfit").ToString))
				Report.SetParameterValue("txtLItotalProfit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAEtotalProfit").ToString))
				Report.SetParameterValue("txtAEtotalProfit", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAItotalProfit").ToString))
				Report.SetParameterValue("txtAItotalProfit", "0");

			Report.SetParameterValue("txtLEtotal", Strings.FormatNumber(rs.Fields("priceExcl").Value, 0));
			Report.SetParameterValue("txtLItotal", Strings.FormatNumber(rs.Fields("priceIncl").Value, 0));
			Report.SetParameterValue("txtAEtotal", Strings.FormatNumber(rs.Fields("priceExcl").Value, 0));
			Report.SetParameterValue("txtAItotal", Strings.FormatNumber(rs.Fields("priceIncl").Value, 0));
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLEtotal").ToString))
				Report.SetParameterValue("txtLEtotal", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtLItotal").ToString))
				Report.SetParameterValue("txtLItotal", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAEtotal").ToString))
				Report.SetParameterValue("txtAEtotal", "0");
			if (string.IsNullOrEmpty(Report.ParameterFields("txtAItotal").ToString))
				Report.SetParameterValue("txtAItotal", "0");

			if (Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) == 0) {
			} else {
				Report.SetParameterValue("txtLEtotalPerc", Strings.FormatNumber((1 - (rs.Fields("listExcl").Value + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) + "%");
				Report.SetParameterValue("txtLItotalPerc", Strings.FormatNumber((1 - (rs.Fields("listIncl").Value + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) + "%");
				Report.SetParameterValue("txtAEtotalPerc", Strings.FormatNumber((1 - (rs.Fields("actualExcl").Value + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) + "%");
				Report.SetParameterValue("txtAItotalPerc", Strings.FormatNumber((1 - (rs.Fields("actualIncl").Value + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) + "%");
			}

			CrystalReportViewer1.ReportSource = Report;
			CrystalReportViewer1.Show();
			CrystalReportViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			tmrReportCancel.Enabled = true;

			System.Windows.Forms.Application.DoEvents();
			gIndex = -1;
			Text1.Focus();
			tmrMenuShow_Tick(tmrMenuShow, new System.EventArgs());
		}

		private void mnWelcome_Click()
		{
			tmrReportCancel.Enabled = false;
			//Dim Report As New menuDefault
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("menuDefault.rpt");
			CrystalReportViewer1.ReportSource = Report;
			CrystalReportViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}


		private void mnuStock_Click()
		{
			tmrReportCancel.Enabled = false;
			//Dim Report As New cryMenuStock
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryMenuStock.rpt");
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lTotal = default(decimal);

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//do invoice discount
			rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM (Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtStockDiscount", "0.00");
			} else {
				if (rs.RecordCount) {
					Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(rs.Fields("amount").Value, 2));
				} else {
					Report.SetParameterValue("txtStockDiscount", "0.00");
				}
			}
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
			while (!(rs.EOF)) {
				if (rs.Fields("depositType").Value) {
					if (rs.Fields("SaleItem_Reversal").Value) {
						Report.SetParameterValue("txtStockDepositSold", Strings.FormatNumber(rs.Fields("content").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDepositReturn", Strings.FormatNumber(rs.Fields("content").Value, 2));
					}
				} else {
					if (rs.Fields("SaleItem_Reversal").Value) {
						Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(rs.Fields("content").Value, 2));
						Report.SetParameterValue("txtStockCreditDeposit", Strings.FormatNumber(0 - rs.Fields("deposit").Value, 2));
					} else {
						Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(rs.Fields("content").Value, 2));
						Report.SetParameterValue("txtStockSoldDeposit", Strings.FormatNumber(rs.Fields("deposit").Value, 2));
					}
				}
				rs.MoveNext();
			}
			rs.Close();
			Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSoldContent").ToString) - Convert.ToDecimal(Report.ParameterFields("txtStockSoldDeposit").ToString), 2));
			Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockCreditContent").ToString) - Convert.ToDecimal(Report.ParameterFields("txtStockCreditDeposit").ToString), 2));
			Report.SetParameterValue("txtStockSold", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSoldContent").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockSoldDeposit").ToString), 2));
			Report.SetParameterValue("txtStockCreditTotal", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockCreditContent").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockCreditDeposit").ToString), 2));
			Report.SetParameterValue("txtStockTotal", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSold").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockCreditTotal").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDepositSold").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDepositReturn").ToString), 2));
			// + CCur(Report.txtStockDiscount.Text),2)
			//    Report.txtStockTotal.SetText Report.txtStockDepositReturn.Text
			CrystalReportViewer1.ReportSource = Report;
			CrystalReportViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			tmrReportCancel.Enabled = true;
		}


		private void mnuDeposits_Click()
		{
			tmrReportCancel.Enabled = false;
			//Dim Report As New cryMenuDeposit
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryMenuDeposit.rpt");
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, Sum((IIf([SaleItem_DepositType]=3,[Deposit_Quantity],0)+IIf([SaleItem_DepositType]=1,1,0))*[SaleItem_Quantity]) AS bottle, Sum((IIf([SaleItem_DepositType]=3,1,0)+IIf([SaleItem_DepositType]=2,1,0))*[SaleItem_Quantity]) AS crate, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (Sale INNER JOIN (SaleItem INNER JOIN Deposit ON SaleItem.SaleItem_StockItemID = Deposit.DepositID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID Where (((SaleItem.SaleItem_DepositType) <> 0) And ((SaleItem.SaleItem_Reversal) = False) And ((SaleItem.SaleItem_Revoke) = False)) GROUP BY Deposit.Deposit_Name, Deposit.Deposit_Quantity, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost;");
			if (rs.RecordCount) {
				Report.Database.Tables(1).SetDataSource(rs);
				//Report.VerifyOnEveryPrint = True
				CrystalReportViewer1.ReportSource = Report;
				CrystalReportViewer1.Refresh();
				tmrReportCancel.Enabled = true;
			}
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void mnuAccount_Click()
		{
			tmrReportCancel.Enabled = false;
			//Dim Report As New cryMenuAccount
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryMenuAccount.rpt");
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lTotal = default(decimal);

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			lTotal = 0;
			rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");
			while (!(rs.EOF)) {
				switch (rs.Fields("Sale_PaymentType").Value) {
					case 5:
						Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						break;
					case 1:
						Report.SetParameterValue("txtAccountCash", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						lTotal = lTotal - rs.Fields("amount").Value;
						break;
					case 2:
						Report.SetParameterValue("txtAccountCRcard", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						lTotal = lTotal - rs.Fields("amount").Value;
						break;
					case 3:
						Report.SetParameterValue("txtAccountDRcard", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						lTotal = lTotal - rs.Fields("amount").Value;
						break;
					case 4:
						Report.SetParameterValue("txtAccountCheque", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						lTotal = lTotal - rs.Fields("amount").Value;
						break;
				}
				rs.MoveNext();
			}
			Report.SetParameterValue("txtAccountPayment", Strings.FormatNumber(lTotal, 2));
			lTotal = lTotal + Convert.ToDecimal(Report.ParameterFields("txtAccountSales").ToString);
			Report.SetParameterValue("txtAccountTotal", Strings.FormatNumber(lTotal, 2));

			CrystalReportViewer1.ReportSource = Report;
			CrystalReportViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			tmrReportCancel.Enabled = true;
		}
		private void mnuMoney_Click()
		{
			tmrReportCancel.Enabled = false;
			//Dim Report As New cryMenuMoney
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryMenuMoney.rpt");
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lTotal = default(decimal);

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//get payoutTotal
			rs = modRecordSet.getRS(ref "SELECT Sum(Payout.Payout_Amount) AS amount FROM Company INNER JOIN Payout ON Company.Company_DayEndID = Payout.Payout_DayEndID;");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtPayout", "0.00");
			} else {
				Report.SetParameterValue("txtPayout", Strings.FormatNumber(rs.Fields("amount").Value, 2));
			}
			rs.Close();

			//get outages
			rs = modRecordSet.getRS(ref "SELECT Sum((([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer]))) AS amount FROM Company INNER JOIN Declaration ON Company.Company_DayEndID = Declaration.Declaration_DayEndID;");
			if (Information.IsDBNull(rs.Fields("amount").Value)) {
				Report.SetParameterValue("txtOutage", "0.00");
			} else {
				Report.SetParameterValue("txtOutage", Strings.FormatNumber(rs.Fields("amount").Value, 2));
			}
			rs.Close();

			//do money movement
			lTotal = 0;
			rs = modRecordSet.getRS(ref "SELECT Sale.Sale_PaymentType, Sum(Sale.Sale_Total) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID  Where (((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");
			while (!(rs.EOF)) {
				switch (rs.Fields("Sale_PaymentType").Value) {
					case 1:
						Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						lTotal = lTotal + rs.Fields("amount").Value;
						break;
					case 2:
						Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						lTotal = lTotal + rs.Fields("amount").Value;
						break;
					case 3:
						Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						lTotal = lTotal + rs.Fields("amount").Value;
						break;
					case 4:
						Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						lTotal = lTotal + rs.Fields("amount").Value;
						break;
				}
				rs.MoveNext();
			}
			rs.Close();
			Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(lTotal, 2));
			Report.SetParameterValue("txtMoneyTill", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtMoneyTotal").ToString) + Convert.ToDecimal(Report.ParameterFields("txtOutage").ToString) - Convert.ToDecimal(Report.ParameterFields("txtPayout").ToString)), 2);

			CrystalReportViewer1.ReportSource = Report;
			CrystalReportViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			tmrReportCancel.Enabled = true;
		}

		private void frmMenu_Load1(object sender, System.EventArgs e)
		{
			//lblMenu.AddRange(New Label() {_lblMenu_0})
			DTPicker1.AddRange(new DateTimePicker[] {
				_DTPicker1_0,
				_DTPicker1_1
			});
			DateTimePicker dt = new DateTimePicker();
			foreach (DateTimePicker dt_loopVariable in DTPicker1) {
				dt = dt_loopVariable;
				dt.ValueChanged += DTPicker1_Change;
			}

		}
	}
}
