Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmMenu
	Inherits System.Windows.Forms.Form
	Dim gIndex As Short
	Dim gIndexMenu As Short
	Dim gSection As String
	Public gBit As Integer
	Public gSuper As Boolean
	
	Dim gDayEndStart As Integer
	Dim gDayEndEnd As Integer
    Dim lblMenu As New List(Of Label)
    Public DTPicker1 As New List(Of DateTimePicker)
	Private Sub loadLanguage()
		
		'NOTE: TEXT EMBEDDED IN BACKGROUND IMAGE- MUST CHANGE TO LABELS!
		
		'NOTE: MENU TEXT NOT DONE!!!
		'               ==========
		
		'frmMenu = No Code      [4POS Back Office]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMenu.Caption = rsLang("LanguageLayoutLnk_Description"): frmMenu.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code       [Before viewing reports, the date range needs.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code       [From Date]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code       [To Date]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblColor(0) = No Code/Dynamic/NA?
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblColor(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblColor(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblColor(1) = No Code/Dynamic/NA?
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblColor(1).Caption = rsLang("LanguageLayoutLnk_Description"): lblColor(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NO CODES/DYNAMIC FIELDS
		'=======================
		'lblCompany
		'lblDayEnd
		'lblDayEndCurrent
		'lblMenu(0)
		'lblMenuMain(0)
		'lblPath
		'lblUser
		'lblVersion
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMenu.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub

    Public Sub upgradeWarning()
        Dim fso As New Scripting.FileSystemObject
        MsgBox("You are running an older version of 4POSBackOffice on this machine. System will now copy latest 4POSBackoffice application from main machine.")
        'Run the batch here
        If fso.FileExists("C:\4POS\4POSUpdate.bat") Then
            Shell("C:\4POS\4POSUpdate.bat", AppWinStyle.NormalFocus)
        Else
            FileOpen(7, "C:\4POS\4POSUpdate.bat", OpenMode.Output)
            PrintLine(7, "ECHO OFF")
            PrintLine(7, "cls")
            PrintLine(7, "ECHO ------------------------------------------------------------------")
            PrintLine(7, "ECHO This will copy latest 4POSBackoffice application from main machine.")
            PrintLine(7, "pause")
            PrintLine(7, "copy " & Replace(serverPath, "4posserver\", "") & "4pos\4POSOffice.exe" & " /B C:\4POS /V /Y")
            'Print #7, "C:\4POS\4POSOffice.exe"
            PrintLine(7, "ECHO -")
            PrintLine(7, "ECHO -")
            PrintLine(7, "ECHO Please Run/Open 4POSBackoffice application now.")
            'Print #7, "ECHO ON"
            PrintLine(7, "pause")
            PrintLine(7, "exit")
            FileClose(7)
            Shell("C:\4POS\4POSUpdate.bat", AppWinStyle.NormalFocus)
        End If
    End Sub

	Public Sub loadMenu(ByVal lMenu As String)
        Dim y As Short
        Dim parentID As Integer
		Dim rs As ADODB.Recordset
		Dim rsMain As ADODB.Recordset
		Dim rsVer As ADODB.Recordset
		'On Local Error Resume Next
		Dim x As Decimal
		Dim revName As String
		Dim fso As New Scripting.FileSystemObject
        Dim r As Integer
		frmLoading.Show()
		System.Windows.Forms.Application.DoEvents()
		'MsgBox "loadMenu 1"
		Dim rsCNameBug As ADODB.Recordset
		Dim cVerOrig As Decimal
		Dim cVerNew As Decimal
		Dim tempVerBug As String
		Dim arrVerBug() As String
		If LCase(VB.Left(serverPath, 3)) <> "c:\" Then
			rsCNameBug = getRS("SELECT Company_Version FROM Company;")
			If rsCNameBug.RecordCount Then
				If IsDbNull(rsCNameBug.Fields("Company_Version").Value) Then
				Else
					tempVerBug = LTrim(rsCNameBug.Fields("Company_Version").Value)
					tempVerBug = RTrim(Replace(tempVerBug, " ", ""))
					tempVerBug = Trim(Replace(tempVerBug, "/", ""))
					arrVerBug = Split(tempVerBug, ".")
					If UBound(arrVerBug) = 2 Then
						If Len(arrVerBug(0)) < 2 Then arrVerBug(0) = "00" & arrVerBug(0)
						If Len(arrVerBug(1)) < 2 Then arrVerBug(1) = "00" & arrVerBug(1)
						If Len(arrVerBug(2)) < 4 Then arrVerBug(2) = "0000" & arrVerBug(2)
						
						arrVerBug(0) = VB.Right(arrVerBug(0), 2)
						arrVerBug(1) = VB.Right(arrVerBug(1), 2)
						arrVerBug(2) = VB.Right(arrVerBug(2), 4)
						
						tempVerBug = arrVerBug(0) & arrVerBug(1) & arrVerBug(2)
						cVerOrig = CDec(tempVerBug)
					End If
					
					lblVersion.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
					tempVerBug = LTrim(lblVersion.Text)
					tempVerBug = RTrim(Replace(tempVerBug, " ", ""))
					tempVerBug = Trim(Replace(tempVerBug, "/", ""))
					arrVerBug = Split(tempVerBug, ".")
					If UBound(arrVerBug) = 2 Then
						If Len(arrVerBug(0)) < 2 Then arrVerBug(0) = "00" & arrVerBug(0)
						If Len(arrVerBug(1)) < 2 Then arrVerBug(1) = "00" & arrVerBug(1)
						If Len(arrVerBug(2)) < 4 Then arrVerBug(2) = "0000" & arrVerBug(2)
						
						arrVerBug(0) = VB.Right(arrVerBug(0), 2)
						arrVerBug(1) = VB.Right(arrVerBug(1), 2)
						arrVerBug(2) = VB.Right(arrVerBug(2), 4)
						
						tempVerBug = arrVerBug(0) & arrVerBug(1) & arrVerBug(2)
						cVerNew = CDec(tempVerBug)
					End If
					
                    If cVerNew < cVerOrig Then
                        upgradeWarning()
                        End
                    End If
				End If
			End If
		Else
			cnnDB.Execute("UPDATE Company SET Company_Version = '" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & "'")
		End If
		lblVersion.Text = "Version: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		
		'New encryption for version/company
		rsVer = getRS("SELECT * FROM Company")
		Dim tempVer As String
		Dim arrVer() As String
		Dim arrName() As String
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		If rsVer.BOF Or rsVer.EOF Then
			End
		Else
			'MsgBox "loadMenu 2"
			If rsVer.Fields.Count >= 59 Then
				'MsgBox "loadMenu 2 1"
				ReDim arrVer(3)
				If Len(CStr(My.Application.Info.Version.Major)) < 2 Then arrVer(0) = "00" & My.Application.Info.Version.Major
				If Len(CStr(My.Application.Info.Version.Minor)) < 2 Then arrVer(1) = "00" & My.Application.Info.Version.Minor
				arrVer(2) = "0000" & My.Application.Info.Version.Revision
				arrVer(0) = VB.Right(arrVer(0), 2)
				arrVer(1) = VB.Right(arrVer(1), 2)
				arrVer(2) = VB.Right(arrVer(2), 4)
				tempVer = arrVer(0) & arrVer(1) & arrVer(2)
				tempVer = Hex(CInt(tempVer))
				'lCode = CLng(("&H" & tempVer))
				'MsgBox "loadMenu 2 2"
				lPassword = rsVer.Fields("Company_Name").Value
				lCode = ""
				leCode = ""
				For x = 1 To Len(lPassword)
					lCode = Mid(lPassword, x, 1)
					leCode = leCode & Asc(lCode) & Chr(255)
					'leCode = leCode & Asc(lCode) & "|"
				Next 
				leCode = VB.Left(leCode, Len(leCode) - 1)
				'MsgBox leCode
				'a = Len(leCode)
				'Debug.Print leCode
				'arrName = Split(leCode, Chr(255))
				'leCode = ""
				'For x = 0 To UBound(arrName)
				'    leCode = leCode & Chr(arrName(x))
				'Next
				'MsgBox "loadMenu 2 3"
				'check the company name
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rsVer.Fields("Company_RePrintVN").Value) Then
					'MsgBox "loadMenu 2 41"
					lCode = tempVer & Chr(254) & leCode
					'lCode = tempVer & "_" & leCode
					'MsgBox lCode
					cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" & lCode & "'")
					'MsgBox "loadMenu 2 41 finish"
				Else
					'MsgBox "loadMenu 2 411"
					'If InStr(1, rsVer("Company_RePrintVN"), "_") Then
					If InStr(1, rsVer.Fields("Company_RePrintVN").Value, Chr(254)) Then
						'MsgBox "loadMenu 2 42"
						'leCode = Split(rsVer("Company_RePrintVN"), "_")(1)
						leCode = Split(rsVer.Fields("Company_RePrintVN").Value, Chr(254))(1)
						'lCode = tempVer & "_" & leCode
						lCode = tempVer & Chr(254) & leCode
						'MsgBox lCode
						cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" & lCode & "'")
						'MsgBox "loadMenu 2 42 1"
					Else
						'MsgBox "loadMenu 2 422"
						'lCode = tempVer & "_" & leCode
						lCode = tempVer & Chr(254) & leCode
						cnnDB.Execute("UPDATE Company SET Company_RePrintVN = '" & lCode & "'")
					End If
				End If
			End If
		End If
		'New encryption for version/company
		'MsgBox "loadMenu 3"
		
		gSection = lMenu
		rs = getRS("SELECT Company_Name FROM Company")
		If rs.BOF Or rs.EOF Then
			End
		End If
		lblCompany.Text = rs.Fields("Company_Name").Value
		rs.Close()
        'rsMain = getRS("SELECT Menu.MenuID, Menu.Menu_ParentID, Menu.Menu_Name, Menu.Menu_Type, Menu.Menu_Action, Menu.Menu_Window, Menu.Menu_Bit, Menu.Menu_Help From Menu Where (((Menu.Menu_Section) = '" & gSection & "') AND ((Menu.Menu_Hide)=False)) ORDER BY Menu.Menu_ParentID, Menu.Menu_Order;")
        'MsgBox "loadMenu 4"
         rsMain = getRS("SELECT Menu_ParentID, Menu_Name, Menu_Action FROM Menu WHERE Menu_ParentID > 0;")
        For Each Name As String In rsMain.Fields("Menu_Name").Value
            MainMenu1.Items.Add(Name)
        Next

        'For r = 2 To cols
        ' rsMain = getRS("SELECT * FROM Menu WHERE (Menu_ParentID = " & r.ToString & ") ORDERBY MenuOrder;")
        ' For Each Name As String In rsMain.Fields("Menu_Name").Value

        'Next
        'Next

        If rsMain.BOF Or rsMain.EOF Then
            End
        End If
        If VB.Command() = "" Then
            'MsgBox "loadMenu 4   - 4"
            If lblUser.Tag = "" Then
                MsgBox("No Security information found.", MsgBoxStyle.Critical, My.Application.Info.Title)
                End
            End If
        Else
            rs = getRS("SELECT * FROM Person where PersonID = " & VB.Command())
            If rs.BOF Or rs.EOF Then
                MsgBox("Unable to retreive security information.", MsgBoxStyle.Critical, "4POS")
                End
            Else
                'MsgBox "loadMenu 5"
                If rs.RecordCount = 1 Then
                    Me.lblUser.Tag = rs.Fields("PersonID").Value
                    Me.lblUser.Text = rs.Fields("Person_FirstName").Value & " " & rs.Fields("Person_LastName").Value

                    If Len(rs.Fields("Person_QuickAccess").Value) > 0 Then
                        For x = Len(rs.Fields("Person_QuickAccess").Value) To 1 Step -1
                            revName = revName & Mid(rs.Fields("Person_QuickAccess").Value, x, 1)
                        Next
                        If LCase(VB.Left(rs.Fields("Person_Position").Value, 8)) = "4posboss" And LCase(VB.Right(rs.Fields("Person_Position").Value, Len(rs.Fields("Person_QuickAccess").Value))) = revName Then
                            Me.lblUser.ForeColor = System.Drawing.Color.Yellow
                            Me.gSuper = True
                        End If
                    End If

                    gBit = rs.Fields("Person_SecurityBit").Value
                Else
                    MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login")
                    End
                End If
                'MsgBox "loadMenu 6"
            End If
        End If
        '    buildMenus 1, picMenuList(0), rsMain
        rs = rsMain.Clone
        rs.Filter = "Menu_ParentID=1" & parentID
        'MsgBox "loadMenu 7"
        Do Until rs.EOF
            x = 0
            'lblMenuMain.Load(x)
            '_lblMenuMain_0.Visible = True

            '_lblMenuMain_0.Text = rs.Fields("Menu_Name").Value
            '_lblMenuMain_0.BringToFront()
            '_lblMenuMain_0.Top = twipsToPixels(pixelToTwips(_lblMenuMain_0.Top, False) + (pixelToTwips(_lblMenuMain_0.Height, False) + 120) * (x - 1), False)
            If rs.Fields("Menu_Type").Value = "menu" Then
                'picMenuList.Load(picMenuList.UBound + 1)
                '    _lblMenuMain_0.Tag = 0
                '    _picMenuList_0.Tag = rs.Fields("MenuID").Value
                '    buildMenus(rs.Fields("MenuID").Value, _picMenuList_0, rs, CStr(0))
            End If

            rs.MoveNext()
        Loop
        'MsgBox "loadMenu 8"
        For y = 0 To Me.Controls.Count() - 1
            If CType(Controls(y), Object).Name = "lblMenu" Then
                'CType(Controls(y), Object).Width = twipsToPixels(pixelToTwips(CType(Controls(y), Object).Parent.Width, True) - pixelToTwips(_imgArrow_0.Width, True) - 100 - pixelToTwips(_imgMenu_1.Width, True), True)
                If VB.Left(CType(Controls(y), Object).Tag, 1) = "m" Then
                    'Controls(y).Container.PaintPicture Me._imgArrow_0.Picture, Controls(y).Container.Width - (Me._imgArrow_0.Width + 50), Controls(y).Top
                    'CType(Controls(y), Object).Parent.PaintPicture(Me._imgArrow_0.Image, pixelToTwips(CType(Controls(y), Object).Parent.Width, True) - (pixelToTwips(Me._imgArrow_0.Width, True) + pixelToTwips(Me._imgMenu_1.Width, True)), pixelToTwips(CType(Controls(y), Object).Top, True) + 45, False)
                End If
            End If
        Next y
        'MsgBox "loadMenu 9"
        If gBit And 4096 Then chkDash.Visible = True : Label2.Visible = True Else chkDash.Visible = False : Label2.Visible = False

        Me.Show()
        'MsgBox "loadMenu 10"
        mnWelcome_Click()
        'MsgBox "loadMenu 11"
        System.Windows.Forms.Application.DoEvents()
        Text1.Focus()
        tmrMenuShow_Tick(tmrMenuShow, New System.EventArgs())
        'MsgBox "loadMenu 12"
        'For x = 0 To Me.picMenuList.UBound
        '_picMenuList_0.Visible = False
        'Next x
        'MsgBox "loadMenu 13"
        System.Windows.Forms.Application.DoEvents()

        frmLoading.Close()
        'MsgBox "loadMenu 14"
    End Sub

    'Private Sub buildMenus(ByVal parentID As Integer, ByRef picMenu As System.Windows.Forms.PictureBox, ByRef rsMain As ADODB.Recordset, ByRef thePath As String)
    'Dim rs As ADODB.Recordset

    'Dim x As Short
    'Dim y As Short
    '    rs = New ADODB.Recordset
    '    rs = rsMain.Clone
    'Dim lPath As String
    '    Debug.Print(thePath)
    '    On Error Resume Next
    'lPath = thePath & "," & picMenu.Index
    'picMenu.Tag = lPath
    'rs.Filter = "Menu_ParentID=" & parentID
    'picMenu.Height = twipsToPixels(rs.RecordCount * (pixelToTwips(_lblMenu_0.Height, False) + 90) + 120 + 300, False)
    'picMenu.PaintPicture(Me._imgMenu_0, 0, 0)
    '   y = 0

    'Do Until rs.EOF
    '   y = y + 1
    'x = lblMenu.UBound + 1
    'lblMenu.Load(x)
    '_lblMenu_0.Parent = picMenu
    '_lblMenu_0.Text = rs("Menu_Name")
    '_lblMenu_0.Visible = True
    'If rs("Menu_Bit").Value And gBit Then
    ' _lblMenu_0.Enabled = True
    ' Else
    ' _lblMenu_0.Enabled = False
    ' End If
    ' _lblMenu_0.Top = twipsToPixels(120 + (pixelToTwips(_lblMenu_0.Height + 90, False) * (y - 1)), False)
    ' System.Windows.Forms.Application.DoEvents()
    ' If twipsToPixels(picMenu.Width, True) - 400 < pixelToTwips(_lblMenu_0.Width, True) Then
    ' picMenu.Width = twipsToPixels(400 + pixelToTwips(_lblMenu_0.Width, True), True)
    ' End If
    ' _lblMenu_0.Tag = VB.Left(rs("Menu_Type").Value, 1) & rs("Menu_Action").Value
    ' If rs("Menu_Type") = "menu" Then
    ' 'picMenuList.Load(picMenuList.UBound + 1)
    '_picMenuList_0.Tag = 0
    '_lblMenu_0.Tag = "m" & _picMenuList_0.Tag
    'buildMenus(rs("MenuID").Value, _picMenuList_0, rsMain, lPath)
    'End If
    'rs.MoveNext()
    'Loop
    'picMenu.PaintPicture(Me._imgMenu_1, pixelToTwips(picMenu.Width, True) - _
    '                     pixelToTwips(imgMenu(1).Width, True), 0)
    'picMenu.PaintPicture(Me.imgMenu(0), 0, 0)
    'picMenu.PaintPicture(Me.imgMenu(2), 0, 0)
    'picMenu.PaintPicture(Me.imgMenu(3), 0, _
    '                     pixelToTwips(picMenu.Height, False) - _
    '                     pixelToTwips(imgMenu(3).Height, False), , , _
    '                     pixelToTwips(imgMenu(3).Width, True) - _
    '                     pixelToTwips(picMenu.Width, True))
    'End Sub



    Private Sub chkDash_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDash.Click
        If chkDash.CheckState = 1 Then
            mnuDashboard_Click(mnuDashboard, New System.EventArgs())
        Else
            mnWelcome_Click()
        End If
    End Sub

    Public Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Dim rs As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject
        On Error GoTo errLoad
        If cnnDBreport.State Then cnnDBreport.Close()

        modUpdate = 0
        updateStockMovement() 'Defining the period from report are being loaded from

        'I need code
        If fso.FileExists(serverPath & "report" & Me.lblUser.Tag & ".mdb") Then fso.DeleteFile(serverPath & "report" & Me.lblUser.Tag & ".mdb")
        fso.CopyFile(serverPath & "templateReport.mdb", serverPath & "report" & Me.lblUser.Tag & ".mdb", True)
        openConnectionReport()

        rs = getRSreport("SELECT * FROM Report")
        If rs.RecordCount Then
            cnnDBreport.Execute("UPDATE Report SET Report.Report_DayEndStartID = " & gDayEndStart & ", Report.Report_DayEndEndID = " & gDayEndEnd & ", Report.Report_Heading = '" & Me.lblDayEnd.Text & "';")
        Else
            cnnDBreport.Execute("INSERT INTO Report ( Report_DayEndStartID, Report_DayEndEndID, Report_Heading, ReportID ) SELECT " & gDayEndStart & ", " & gDayEndEnd & ", '" & Me.lblDayEnd.Text & "', 1;")

        End If
        'Dim form As frmUpdateDayEnd
        frmUpdateDayEnd.Show()
        lblDayEndCurrent.Text = lblDayEnd.Text

        Exit Sub
errLoad:
        If Err.Number = 70 Then
            'MsgBox Err.Number & " " & Err.Description & " " & Err.source & vbCrLf & vbCrLf & " Cannot perform this action, report database is being used by another person or program. Please close any program that might be using the report database and try again."
            MsgBox("You are logged into the 4POSBackOffice on another computer with the same Username & Password. You can not load reports if logged onto more than 1 PC. Please close the other 4POSOffice program first before attempting to 'Load Reports' on this PC")
            'You have logged on to the 4POS Back Office program on another PC. You can not load reports if logged onto more than 1 PC. Please log out on the other PC/s.
        Else
            MsgBox(Err.Number & Err.Description)
        End If
    End Sub
    Sub Automaticload()
        Dim rs As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject
        cnnDBreport.Close()

        'modUpdate = 2
        'updateStockMovement          'Defining the period from report are being loaded from

        'I need code
        If fso.FileExists(serverPath & "report" & Me.lblUser.Tag & ".mdb") Then fso.DeleteFile(serverPath & "report" & Me.lblUser.Tag & ".mdb")
        fso.CopyFile(serverPath & "templateReport.mdb", serverPath & "report" & Me.lblUser.Tag & ".mdb", True)
        openConnectionReport()

        rs = getRSreport("SELECT * FROM Report")
        If rs.RecordCount Then
            cnnDBreport.Execute("UPDATE Report SET Report.Report_DayEndStartID = " & gDayEndStart & ", Report.Report_DayEndEndID = " & gDayEndEnd & ", Report.Report_Heading = '" & Me.lblDayEnd.Text & "';")
        Else
            cnnDBreport.Execute("INSERT INTO Report ( Report_DayEndStartID, Report_DayEndEndID, Report_Heading, ReportID ) SELECT " & gDayEndStart & ", " & gDayEndEnd & ", '" & Me.lblDayEnd.Text & "', 1;")

        End If
        Dim form As frmUpdateDayEnd
        form.Show()
        lblDayEndCurrent.Text = lblDayEnd.Text

    End Sub

    Public Sub cmdToday_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdToday.Click
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]));")
        If rs.RecordCount Then

            _DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value
            _DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value
            setDayEndRange()
        End If
        _DTPicker1_0.Focus()
    End Sub


    Private Sub cmdYesterday_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdYesterday.Click
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]-1));")
        If rs.RecordCount Then
            _DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value
            _DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value
            setDayEndRange()
        Else
            cmdToday_Click(cmdToday, New System.EventArgs())
        End If
        _DTPicker1_0.Focus()

    End Sub

    Public Sub setDayEndRange()
        Dim lDate As Date
        Dim lDateString As String
        Dim lDateArray() As String
        Dim lDateStart As Date
        Dim lDateEnd As Date
        Dim rs As ADODB.Recordset
        On Error Resume Next
        lDateStart = _DTPicker1_0.Value
        lDateEnd = _DTPicker1_1.Value
        lDateStart = CDate(VB.Left(CStr(lDateStart), 10))
        lDateEnd = CDate(VB.Left(CStr(lDateEnd), 10))

        If lDateStart >= lDateEnd Then
            lDateStart = _DTPicker1_1.Value
            lDateEnd = _DTPicker1_0.Value
        End If
        lDateStart = CDate(VB.Left(CStr(lDateStart), 10))
        lDateEnd = CDate(VB.Left(CStr(lDateEnd), 10))

        rs = getRS("SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) >= #" & lDateStart & " 00:00:00#)) ORDER BY DayEnd.DayEnd_Date;")
        If rs.BOF Or rs.EOF Then
            rs.Close()
            rs = getRS("SELECT Max(DayEnd.DayEndID) AS DayEndID FROM DayEnd;")

        End If
        gDayEndStart = rs.Fields("DayEndID").Value
        rs.Close()

        rs = getRS("SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) <= #" & lDateEnd & " 23:59:59#)) ORDER BY DayEnd.DayEnd_Date DESC;")
        If rs.BOF Or rs.EOF Then
            rs.Close()
            rs = getRS("SELECT Min(DayEnd.DayEndID) AS DayEndID FROM DayEnd;")

        End If
        gDayEndEnd = rs.Fields("DayEndID").Value
        rs.Close()

        rs = getRS("SELECT Count(DayEnd.DayEndID) AS [count], Min(DayEnd.DayEnd_Date) AS fromDate, Max(DayEnd.DayEnd_Date) AS toDate From DayEnd WHERE (((DayEnd.DayEndID)>= " & gDayEndStart & ") AND ((DayEnd.DayEndID) <= " & gDayEndEnd & "));")

        lblDayEnd.Text = "From " & Format(rs.Fields("fromDate").Value, "ddd dd mmm yyyy")
        lblDayEnd.Text = lblDayEnd.Text & " to "
        lblDayEnd.Text = lblDayEnd.Text & Format(rs.Fields("toDate").Value, "ddd dd mmm yyyy")
        lblDayEnd.Text = lblDayEnd.Text & " covering " & rs.Fields("count").Value & " day-end/s."
        _DTPicker1_0.Format = DateTimePickerFormat.Custom
        _DTPicker1_0.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("fromDate").Value, "yyyy"), _
        Format(rs.Fields("fromDate").Value, "m"), _
        Format(rs.Fields("fromDate").Value, "d"))
        _DTPicker1_1.Format = DateTimePickerFormat.Custom
        _DTPicker1_1.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("toDate").Value, "yyyy"), _
        Format(rs.Fields("toDate").Value, "m"), _
        Format(rs.Fields("toDate").Value, "d"))
    End Sub

    Private Sub DTPicker1_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles DTPicker1
        Dim dtp As New DateTimePicker
        dtp = DirectCast(eventSender, DateTimePicker)
        Dim Index As Integer = GetIndexer(dtp, DTPicker1)
        setDayEndRange()
    End Sub
    Private Sub frmMenu_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If Shift = 4 And KeyCode = 82 Then
            If gBit And 4096 Then
                Text1.Focus()

                tmrReports.Enabled = True
                KeyCode = 0
            End If
        End If
        If KeyCode = 40 Then
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyCode = 0
        End If
        If KeyCode = 38 Then
            System.Windows.Forms.SendKeys.Send("+{tab}")
            KeyCode = 0
        End If

    End Sub
    Private Sub frmMenu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        DTPicker1.AddRange(New DateTimePicker() {_DTPicker1_0, _DTPicker1_1})

        Dim rst As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject

        bUploadReport = False

        blResolution = False
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)
        If blResolution = True Then
            'Manually align controlls
            If fso.FileExists(serverPath & "4POSBack800.jpg") Then
                Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
                Me.BackgroundImage = System.Drawing.Image.FromFile(serverPath & "4POSBack800.jpg")
            End If
            Image1.Top = 0
            Image1.Left = 0
            Image1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width : Image1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            'Image1.Visible = False
            'nWRatio = nW / 15360: nHRatio = nH / 11520
            Image2.Top = 0
            Image2.Left = 0
            Image2.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
            Image2.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height

            'Realign Server path
            lblPath.Top = twipsToPixels((pixelToTwips(lblCompany.Top, False) + _
                                        pixelToTwips(lblCompany.Height, False)), False)
            lblUser.Top = twipsToPixels(pixelToTwips(lblUser.Top, False) + 90, False)
            lblVersion.Top = twipsToPixels(pixelToTwips(lblVersion.Top, False) + 120, False)
            lblDayEndCurrent.Top = twipsToPixels(pixelToTwips(lblVersion.Top, False) - 50, False)
            Label2.Top = twipsToPixels(pixelToTwips(lblVersion.Top, False) - 50, False)
            chkDash.Top = twipsToPixels(pixelToTwips(lblVersion.Top, False) - 50, False)
            'Label1.Top = Label1.Top + 90
            'lblUser.Top = lblUser.Top + 90
            'lblMenuMain(0).Top = lblMenuMain(0).Top + 90
            'CRViewer1.Left = -200
            'CRViewer1.Width = CRViewer1.Width + 100

        Else
            lblPath.Top = twipsToPixels(1000, False)

            Image1.Top = 0
            Image1.Left = 0
            'Image1.Width = Screen.Width: Image1.Height = Screen.Height
            'Image1.Visible = False
            'nWRatio = nW / 15360: nHRatio = nH / 11520
            Image2.Top = 0
            Image2.Left = 0
            Image2.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width : Image2.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        End If

        gIndex = -1
        lblPath.Text = serverPath

    End Sub
    Private Sub frmMenu_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = pixelToTwips(eventArgs.X, True)
        Dim y As Single = pixelToTwips(eventArgs.Y, False)
        gIndex = -1
        Text1.Focus()
        tmrMenuShow_Tick(tmrMenuShow, New System.EventArgs())
    End Sub

    Private Sub frmMenu_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)
        'Dim lRetVal As Long
        'Dim vValue As String
        'Dim rsBack As Recordset
        On Error GoTo unloadErr
        Dim rs As ADODB.Recordset
        Dim textstream As Scripting.TextStream
        Dim fso As New Scripting.FileSystemObject

        If MsgBox("Do you wish to perform Backup?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            rs = getRS("select Company_BackupPath from Company")
            If rs.RecordCount Then
                If rs.Fields("Company_BackupPath").Value <> "" Then
                    If fso.FileExists("C:\4POSBackup.txt") Then fso.DeleteFile("C:\4POSBackup.txt", True)

                    textstream = fso.OpenTextFile("C:\4POSBackup.txt", Scripting.IOMode.ForWriting, True)
                    textstream.Write(rs.Fields("Company_BackupPath").Value)
                    textstream.Close()
                End If
            End If

            Shell("c:\4pos\4posbackup.exe", AppWinStyle.NormalFocus)
            System.Windows.Forms.Application.DoEvents()
        End If

        End
        'ExitProcess 0

        'Set rsBack = getRS("SELECT Company_DayEndBit FROM Company")

        'If Abs(CBool(rsBack("Company_DayEndBit") And gCopySalesToHQ)) Then
        '   closeConnection       'Close pricing DB connectons
        '   closeConnectionReport 'Close report connection

        '   lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hKey)
        '   lRetVal = QueryValueEx(hKey, "compress", vValue)
        '   If vValue = "" Then vValue = 0
        '   If CBool(vValue) Then
        '      frmBackupDatabase.show 1
        '   End If
        '
        'End If
        'DeleteTempFiles

        Exit Sub
unloadErr:
        MsgBox(Err.Description)
        End
    End Sub

    Private Sub Label1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim givPass As String
        'givPass = InputBox("Please Enter Password!", "Please Enter Password!")
        'If givPass = "786" Then
        '    For x = dayStart To dayEnd
        '        'Multi Warehouse change     cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
        '        'Tranfer change             cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
        '        cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV]+[dayEndToday]![DayEndStockItemLnk_QuantityTransafer] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
        '    Next x
        '    MsgBox "Done"
        'Else
        '    MsgBox "invalid pass"
        'End If
    End Sub

    Private Sub lblCompany_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Dim intDate As Short
        Dim dtDate As String
        Dim dtMonth As String
        Dim stPass As String
        Dim givPass As String

        On Error GoTo Hell_Error

        givPass = InputBox("Please Enter Password!", "Please Enter Password!")
        'Construct password...........
        'If KeyAscii = 13 Then
        intDate = VB.Day(Today) * 2
        If Len(CStr(intDate)) = 1 Then dtDate = "0" & CStr(intDate) Else dtDate = Trim(CStr(intDate))

        intDate = Month(Today) * 2
        If Len(CStr(intDate)) = 1 Then dtMonth = "0" & CStr(intDate) Else dtMonth = Trim(CStr(intDate))

        'Create password
        stPass = dtDate & "##" & dtMonth
        stPass = Replace(stPass, " ", "")

        If Trim(givPass) = stPass Then

            givPass = InputBox("Please Enter Security Code!", "Please Enter Security Code!")
            If IsNumeric(givPass) Then 'And Len(givPass) = 13

                cnnDB.Execute("UPDATE Company SET Company_PosString = '" & Trim(givPass) & "'")
                MsgBox("Security Code saved!!!", MsgBoxStyle.Exclamation, "Security Code")
            Else

                MsgBox("Invalid Security Code!!!", MsgBoxStyle.Exclamation, "Security Code")
            End If

        Else
            MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords")
        End If

        'End If
        Exit Sub
Hell_Error:
        MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Exclamation, "Incorrect Passwords")
        Exit Sub
    End Sub

    Private Sub lblMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Dim Index As Short = 0
        'Select Case VB.Left(_lblMenu_0.Tag, 1)
        '    Case "m"
        '    Case "f"
        'tmrForm.Tag = Mid(_lblMenu_0.Tag, 2)
        'tmrForm.Enabled = True
        '    Case "a"
        'End Select
    End Sub

    Private Sub lblMenu_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = pixelToTwips(eventArgs.X, True)
        Dim y As Single = pixelToTwips(eventArgs.Y, False)
        Dim Index As Short = 0
        Dim lIndex As Short
        Dim lArray() As String
        Dim lRemoveMenu As Boolean
        lRemoveMenu = False
        If gIndexMenu = Index Then Exit Sub
        If gIndexMenu <> -1 Then
            If VB.Left(lblMenu(gIndexMenu).Tag, 1) = "m" Then

                lIndex = CShort(Split(Mid(lblMenu(gIndexMenu).Tag, 2), "_")(0))
                'If lblMenu(gIndexMenu).Parent = _lblMenu_0.Parent Then
                '_picMenuList_0.Visible = False
                'End If
            Else

            End If
            'lblMenu(gIndexMenu).BackStyle = 0
            'lblMenu(gIndexMenu).BackColor = _lblColor_0.BackColor
            'lblMenu(gIndexMenu).ForeColor = _lblColor_0.ForeColor
            'If lblMenu(gIndexMenu).Parent.Index <> _lblMenu_0.Parent.Index Then
            'or y = 0 To 1
            'blMenu(y).BackStyle = 0
            '_lblMenu_0.BackColor = _lblColor_0.BackColor
            '_lblMenu_0.ForeColor = _lblColor_0.ForeColor
            'Next
            'For x = 0 To Me.picMenuList.UBound
            '_picMenuList_0.Visible = False
            'Next x

            'lArray = Split(_lblMenu_0.Parent.Tag, ",")
            'For x = 1 To UBound(lArray)
            '_picMenuList_0.Visible = True
            'For y = lblMenu.LBound To lblMenu.UBound
            'If _lblMenu_0.Tag = "m" & lArray(x) Then
            'lblMenu(y).BackStyle = 1
            '_lblMenu_0.BackColor = _lblColor_1.BackColor
            '_lblMenu_0.ForeColor = _lblColor_1.ForeColor
            End 'If
            'Next

        End If
        '_lblMenu_0.BackStyle = 1
        '_lblMenu_0.BackColor = _lblColor_1.BackColor
        '_lblMenu_0.ForeColor = _lblColor_1.ForeColor
        'If VB.Left(_lblMenu_0.Tag, 1) = "m" Then
        ' lIndex = CShort(Split(Mid(_lblMenu_0.Tag, 2), "_")(0))
        ' _picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Left, True) + pixelToTwips(_lblMenu_0.Left, True) + pixelToTwips(_lblMenu_0.Parent.Width, True) - 250, True)
        ' If pixelToTwips(_picMenuList_0.Left, True) + pixelToTwips(_picMenuList_0.Width, True) > pixelToTwips(Me.Width, True) - 100 Then
        ' _picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Left, True) - pixelToTwips(_picMenuList_0.Width, True) + 110, True)

        'End If
        '_picMenuList_0.BringToFront()
        '_picMenuList_0.Top = twipsToPixels(pixelToTwips(_lblMenu_0.Parent.Top, False) + pixelToTwips(_lblMenu_0.Top, False) - 120, False)
        'If pixelToTwips(_picMenuList_0.Top, False) + pixelToTwips(_picMenuList_0.Height, False) > pixelToTwips(Me.Height, False) - 100 Then
        ' _picMenuList_0.Top = twipsToPixels(pixelToTwips(Me.Height, False) - pixelToTwips(_picMenuList_0.Height, False) - 800, False)

        ' End If
        'Me._picMenuList_0.Visible = True
        'End If
        gIndexMenu = Index
    End Sub
    Private Sub lblMenuMain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = 0
        If gIndex <> Index Then
            gIndex = Index
            tmrMenuShow.Enabled = True
        End If

    End Sub
    Private Sub lblMenuMain_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = pixelToTwips(eventArgs.X, True)
        Dim y As Single = pixelToTwips(eventArgs.Y, False)
        Dim Index As Short = 0
        'lblMenuMain_Click(_lblMenuMain_0, New System.EventArgs())
    End Sub

    Private Sub tmrForm_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrForm.Tick
        tmrForm.Enabled = False
        doMenuForms(tmrForm.Tag)
    End Sub
    Private Sub tmrMenuShow_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMenuShow.Tick
        tmrMenuShow.Enabled = False
        Dim x As Short
        'For x = 0 To lblMenuMain.UBound
        '_lblMenuMain_0.BackColor = _lblColor_0.BackColor
        '_lblMenuMain_0.ForeColor = _lblColor_0.ForeColor
        '_lblMenuMain_0.BackStyle = 0
        'Next x
        'For x = 0 To Me.lblMenu.UBound
        '_lblMenu_0.BackColor = _lblColor_0.BackColor
        '_lblMenu_0.ForeColor = _lblColor_0.ForeColor
        '_lblMenu_0.BackStyle = 0
        'Next
        gIndexMenu = -1
        'For x = 0 To picMenuList.UBound
        '_picMenuList_0.Visible = False
        'Next
        If gIndex = -1 Then
        Else
            'If _lblMenuMain_0.Tag = "" Then
            'Else
            '_picMenuList_0.Left = twipsToPixels(pixelToTwips(_lblMenuMain_0.Left, True) + pixelToTwips(_lblMenuMain_0.Width, True) + 120, True)
            '_picMenuList_0.Top = _lblMenuMain_0.Top
            '_picMenuList_0.BringToFront()

            'Me._picMenuList_0.Visible = True
            '_lblMenuMain_0.BackStyle = 1
            '_lblMenuMain_0.BackColor = _lblColor_1.BackColor
            '_lblMenuMain_0.ForeColor = _lblColor_1.ForeColor
        End If
        'End If
    End Sub

    Private Sub tmrReportCancel_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrReportCancel.Tick
        mnWelcome_Click()

    End Sub

    Private Sub tmrReports_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrReports.Tick
        tmrReports.Enabled = False
        System.Windows.Forms.Application.DoEvents()
        'UPGRADE_ISSUE: Form method frmMenu.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'PopupMenu(Me.mnuReports, , pixelToTwips(Me.picReport.Left, True) + 30, pixelToTwips(picReport.Top, False) + 30)
        Me.Activate()
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub mnuDashboard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDashboard.Click
        'Dim Report As New cryMenuSalesCube
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("c:\4posserver\Reports\cryMenuSalesCube.rpt")
        Dim rs As ADODB.Recordset
        Dim lTotal As Decimal

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'money
        rs = getRS("SELECT Sum(Sale.Sale_Total) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((Sale.Sale_PaymentType)<>5) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtCubeMoney.", "0.00")
        Else
            Report.SetParameterValue("txtCubeMoney", FormatNumber(rs.Fields("amount").Value, 2))
        End If
        rs.Close()

        'Stock
        rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtCubeStock", "0.00")
        Else
            Report.SetParameterValue("txtCubeStock", FormatNumber(rs.Fields("amount").Value, 2))
        End If
        rs.Close()

        'Account sales
        rs = getRS("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType HAVING (((Sale.Sale_PaymentType)=5));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtCubeAccountSales", "0.00")
        Else
            If rs.RecordCount Then
                Report.SetParameterValue("txtCubeAccountSales", FormatNumber(rs.Fields("amount").Value, 2))
            Else
                Report.SetParameterValue("txtCubeAccountSales", "0.00")
            End If
        End If
        rs.Close()

        'Account payments
        rs = getRS("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType HAVING (((Sale.Sale_PaymentType)<>5));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtCubeAccountPayment", "0.00")
        Else
            If rs.RecordCount Then
                Report.SetParameterValue("txtCubeAccountPayment", FormatNumber(rs.Fields("amount").Value, 2))
            Else
                Report.SetParameterValue("txtCubeAccountPayment", "0.00")
            End If
        End If
        rs.Close()

        'Direct Sales
        rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtCubeDirect", "0.00")
        Else
            Report.SetParameterValue("txtCubeDirect", FormatNumber(rs.Fields("amount").Value, 2))
        End If
        rs.Close()

        'Open Tables
        Dim cn As New ADODB.Connection
        cn = openConnectionInstance("waitron.mdb")
        If cn Is Nothing Then
            Report.SetParameterValue("txtCubeOpenTbl", "Not Found!")
        Else
            rs = getRSwaitron("SELECT Sum([TableTranactionItem_price]*[TableTranactionItem_quantity]) AS Amount FROM OpenTable INNER JOIN TableTranactionItem ON (OpenTable.OpenTable_TableID = TableTranactionItem.TableTranactionItem_TableID) AND (OpenTable.OpenTable_WaitronID = TableTranactionItem.TableTranactionItem_WaitronID);", cn)
            If IsDBNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtCubeOpenTbl", "0.00")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtCubeOpenTbl", FormatNumber(rs.Fields("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtCubeOpenTbl", "0.00")
                End If
            End If
            rs.Close()
        End If

        Report.SetParameterValue("txtCubeAccount", FormatNumber(Report.ParameterFields("txtCubeAccountSales").ToString - Report.ParameterFields("txtCubeAccountPayment").ToString, 2))
        '    Report.txtCubeDirect.SetText FormatNumber(Report.txtCubeMoney.Text - Report.txtCubeAccountPayment.Text, 2)


        'Profit Summary

        rs = getRS("SELECT Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS actualIncl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS listIncl, Sum([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100)) AS priceExcl, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS priceIncl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS depositIncl FROM (Sale INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) INNER JOIN (SaleItem LEFT JOIN Consignment ON SaleItem.SaleItem_SaleID = Consignment.Consignment_SaleID) ON Sale.SaleID = SaleItem.SaleItem_SaleID WHERE (((SaleItem.SaleItem_Reversal)=False) AND ((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((Consignment.ConsignmentID) Is Null));")
        Report.SetParameterValue("txtLEcost", FormatNumber(rs.Fields("listExcl").Value, 0))
        Report.SetParameterValue("txtAEcost", FormatNumber(rs.Fields("actualExcl").Value, 0))
        Report.SetParameterValue("txtLIcost", FormatNumber(rs.Fields("listIncl").Value, 0))
        Report.SetParameterValue("txtAIcost", FormatNumber(rs.Fields("actualIncl").Value, 0))
        If Report.ParameterFields("txtLEcost").ToString = "" Then Report.SetParameterValue("txtLEcost", "0")
        If Report.ParameterFields("txtLIcost").ToString = "" Then Report.SetParameterValue("txtLIcost", "0")
        If Report.ParameterFields("txtAEcost").ToString = "" Then Report.SetParameterValue("txtAEcost", "0")
        If Report.ParameterFields("txtAIcost").ToString = "" Then Report.SetParameterValue("txtAIcost", "0")

        Report.SetParameterValue("txtLEdeposit", FormatNumber(rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtLIdeposit", FormatNumber(rs.Fields("depositIncl").Value, 0))
        Report.SetParameterValue("txtAEdeposit", FormatNumber(rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtAIdeposit", FormatNumber(rs.Fields("depositIncl").Value, 0))
        If Report.ParameterFields("txtLEdeposit").ToString = "" Then Report.SetParameterValue("txtLEdeposit", "0")
        If Report.ParameterFields("txtLIdeposit").ToString = "" Then Report.SetParameterValue("txtLIdeposit", "0")
        If Report.ParameterFields("txtAEdeposit").ToString = "" Then Report.SetParameterValue("txtAEdeposit", "0")
        If Report.ParameterFields("txtAIdeposit").ToString = "" Then Report.SetParameterValue("txtAIdeposit", "0")

        Report.SetParameterValue("txtLEcontent", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtLIcontent", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value, 0))
        Report.SetParameterValue("txtAEcontent", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtAIcontent", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value, 0))
        If Report.ParameterFields("txtLEcontent").ToString = "" Then Report.SetParameterValue("txtLEcontent", "0")
        If Report.ParameterFields("txtLIcontent").ToString = "" Then Report.SetParameterValue("txtLIcontent", "0")
        If Report.ParameterFields("txtAEcontent").ToString = "" Then Report.SetParameterValue("txtAEcontent", "0")
        If Report.ParameterFields("txtAIcontent").ToString = "" Then Report.SetParameterValue("txtAIcontent", "0")

        Report.SetParameterValue("txtLEProfit", FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("listExcl")).Value, 0))
        Report.SetParameterValue("txtLIProfit", FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("listIncl")).Value, 0))
        Report.SetParameterValue("txtAEProfit", FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("actualExcl")).Value, 0))
        Report.SetParameterValue("txtAIProfit", FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("actualIncl")).Value, 0))
        If CDec(Report.ParameterFields("txtLEcost").ToString) = 0 Then
            If Report.ParameterFields("txtLEProfit").ToString = "" Then Report.SetParameterValue("txtLEProfit", "0")
            If Report.ParameterFields("txtLIProfit").ToString = "" Then Report.SetParameterValue("txtLIProfit", "0")
            If Report.ParameterFields("txtAEProfit").ToString = "" Then Report.SetParameterValue("txtAEProfit", "0")
            If Report.ParameterFields("txtAIProfit").ToString = "" Then Report.SetParameterValue("txtAIProfit", "0")
        Else
            Report.SetParameterValue("txtLEPerc", FormatNumber(CDec(Report.ParameterFields("txtLEProfit").ToString) / CDec(Report.ParameterFields("txtLEcost").ToString) * 100, 2) & "%")
            Report.SetParameterValue("txtLIPerc", FormatNumber(CDec(Report.ParameterFields("txtLIProfit").ToString) / CDec(Report.ParameterFields("txtLIcost").ToString) * 100, 2) & "%")
            Report.SetParameterValue("txtAEPerc", FormatNumber(CDec(Report.ParameterFields("txtAEProfit").ToString) / CDec(Report.ParameterFields("txtAEcost").ToString) * 100, 2) & "%")
            Report.SetParameterValue("txtAIPerc", FormatNumber(CDec(Report.ParameterFields("txtAIProfit").ToString) / CDec(Report.ParameterFields("txtAIcost").ToString) * 100, 2) & "%")
        End If
        Report.SetParameterValue("txtLEtotalProfit", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("listExcl").Value - rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtLItotalProfit", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("listIncl").Value - rs.Fields("depositIncl").Value, 0))
        Report.SetParameterValue("txtAEtotalProfit", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("actualExcl").Value - rs.Fields("depositExcl").Value, 0))
        Report.SetParameterValue("txtAItotalProfit", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("actualIncl").Value - rs.Fields("depositIncl").Value, 0))
        If Report.ParameterFields("txtLEtotalProfit").ToString = "" Then Report.SetParameterValue("txtLEtotalProfit", "0")
        If Report.ParameterFields("txtLItotalProfit").ToString = "" Then Report.SetParameterValue("txtLItotalProfit", "0")
        If Report.ParameterFields("txtAEtotalProfit").ToString = "" Then Report.SetParameterValue("txtAEtotalProfit", "0")
        If Report.ParameterFields("txtAItotalProfit").ToString = "" Then Report.SetParameterValue("txtAItotalProfit", "0")

        Report.SetParameterValue("txtLEtotal", FormatNumber(rs.Fields("priceExcl").Value, 0))
        Report.SetParameterValue("txtLItotal", FormatNumber(rs.Fields("priceIncl").Value, 0))
        Report.SetParameterValue("txtAEtotal", FormatNumber(rs.Fields("priceExcl").Value, 0))
        Report.SetParameterValue("txtAItotal", FormatNumber(rs.Fields("priceIncl").Value, 0))
        If Report.ParameterFields("txtLEtotal").ToString = "" Then Report.SetParameterValue("txtLEtotal", "0")
        If Report.ParameterFields("txtLItotal").ToString = "" Then Report.SetParameterValue("txtLItotal", "0")
        If Report.ParameterFields("txtAEtotal").ToString = "" Then Report.SetParameterValue("txtAEtotal", "0")
        If Report.ParameterFields("txtAItotal").ToString = "" Then Report.SetParameterValue("txtAItotal", "0")

        If CDec(Report.ParameterFields("txtLEcost").ToString) = 0 Then
        Else
            Report.SetParameterValue("txtLEtotalPerc", FormatNumber((1 - (rs.Fields("listExcl").Value + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) & "%")
            Report.SetParameterValue("txtLItotalPerc", FormatNumber((1 - (rs.Fields("listIncl").Value + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) & "%")
            Report.SetParameterValue("txtAEtotalPerc", FormatNumber((1 - (rs.Fields("actualExcl").Value + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) & "%")
            Report.SetParameterValue("txtAItotalPerc", FormatNumber((1 - (rs.Fields("actualIncl").Value + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) & "%")
        End If

        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Show()
        CrystalReportViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        tmrReportCancel.Enabled = True

        System.Windows.Forms.Application.DoEvents()
        gIndex = -1
        Text1.Focus()
        tmrMenuShow_Tick(tmrMenuShow, New System.EventArgs())
    End Sub

    Private Sub mnWelcome_Click()
        tmrReportCancel.Enabled = False
        'Dim Report As New menuDefault
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("menuDefault.rpt")
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub mnuStock_Click()
        tmrReportCancel.Enabled = False
        'Dim Report As New cryMenuStock
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryMenuStock.rpt")
        Dim rs As ADODB.Recordset
        Dim lTotal As Decimal

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'do invoice discount
        rs = getRS("SELECT Sum(Sale.Sale_Discount) AS amount FROM (Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtStockDiscount", "0.00")
        Else
            If rs.RecordCount Then
                Report.SetParameterValue("txtStockDiscount", FormatNumber(rs.Fields("amount").Value, 2))
            Else
                Report.SetParameterValue("txtStockDiscount", "0.00")
            End If
        End If
        rs.Close()

        rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
        Do Until rs.EOF
            If rs.Fields("depositType").Value Then
                If rs.Fields("SaleItem_Reversal").Value Then
                    Report.SetParameterValue("txtStockDepositSold", FormatNumber(rs.Fields("content").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDepositReturn", FormatNumber(rs.Fields("content").Value, 2))
                End If
            Else
                If rs.Fields("SaleItem_Reversal").Value Then
                    Report.SetParameterValue("txtStockCreditContent", FormatNumber(rs.Fields("content").Value, 2))
                    Report.SetParameterValue("txtStockCreditDeposit", FormatNumber(0 - rs.Fields("deposit").Value, 2))
                Else
                    Report.SetParameterValue("txtStockSoldContent", FormatNumber(rs.Fields("content").Value, 2))
                    Report.SetParameterValue("txtStockSoldDeposit", FormatNumber(rs.Fields("deposit").Value, 2))
                End If
            End If
            rs.MoveNext()
        Loop
        rs.Close()
        Report.SetParameterValue("txtStockSoldContent", FormatNumber(CDec(Report.ParameterFields("txtStockSoldContent").ToString) - CDec(Report.ParameterFields("txtStockSoldDeposit").ToString), 2))
        Report.SetParameterValue("txtStockCreditContent", FormatNumber(CDec(Report.ParameterFields("txtStockCreditContent").ToString) - CDec(Report.ParameterFields("txtStockCreditDeposit").ToString), 2))
        Report.SetParameterValue("txtStockSold", FormatNumber(CDec(Report.ParameterFields("txtStockSoldContent").ToString) + CDec(Report.ParameterFields("txtStockSoldDeposit").ToString), 2))
        Report.SetParameterValue("txtStockCreditTotal", FormatNumber(CDec(Report.ParameterFields("txtStockCreditContent").ToString) + CDec(Report.ParameterFields("txtStockCreditDeposit").ToString), 2))
        Report.SetParameterValue("txtStockTotal", FormatNumber(CDec(Report.ParameterFields("txtStockSold").ToString) + CDec(Report.ParameterFields("txtStockCreditTotal").ToString) + CDec(Report.ParameterFields("txtStockDepositSold").ToString) + CDec(Report.ParameterFields("txtStockDepositReturn").ToString), 2)) ' + CCur(Report.txtStockDiscount.Text),2)
        '    Report.txtStockTotal.SetText Report.txtStockDepositReturn.Text
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        tmrReportCancel.Enabled = True
    End Sub


    Private Sub mnuDeposits_Click()
        tmrReportCancel.Enabled = False
        'Dim Report As New cryMenuDeposit
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryMenuDeposit.rpt")
        Dim rs As ADODB.Recordset
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, Sum((IIf([SaleItem_DepositType]=3,[Deposit_Quantity],0)+IIf([SaleItem_DepositType]=1,1,0))*[SaleItem_Quantity]) AS bottle, Sum((IIf([SaleItem_DepositType]=3,1,0)+IIf([SaleItem_DepositType]=2,1,0))*[SaleItem_Quantity]) AS crate, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (Sale INNER JOIN (SaleItem INNER JOIN Deposit ON SaleItem.SaleItem_StockItemID = Deposit.DepositID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID Where (((SaleItem.SaleItem_DepositType) <> 0) And ((SaleItem.SaleItem_Reversal) = False) And ((SaleItem.SaleItem_Revoke) = False)) GROUP BY Deposit.Deposit_Name, Deposit.Deposit_Quantity, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost;")
        If rs.RecordCount Then
            Report.Database.Tables(1).SetDataSource(rs)
            'Report.VerifyOnEveryPrint = True
            CrystalReportViewer1.ReportSource = Report
            CrystalReportViewer1.Refresh()
            tmrReportCancel.Enabled = True
        End If
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub mnuAccount_Click()
        tmrReportCancel.Enabled = False
        'Dim Report As New cryMenuAccount
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryMenuAccount.rpt")
        Dim rs As ADODB.Recordset
        Dim lTotal As Decimal

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        lTotal = 0
        rs = getRS("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
        Do Until rs.EOF
            Select Case rs.Fields("Sale_PaymentType").Value
                Case 5
                    Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("amount").Value, 2))
                Case 1
                    Report.SetParameterValue("txtAccountCash", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    lTotal = lTotal - rs.Fields("amount").Value
                Case 2
                    Report.SetParameterValue("txtAccountCRcard", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    lTotal = lTotal - rs.Fields("amount").Value
                Case 3
                    Report.SetParameterValue("txtAccountDRcard", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    lTotal = lTotal - rs.Fields("amount").Value
                Case 4
                    Report.SetParameterValue("txtAccountCheque", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    lTotal = lTotal - rs.Fields("amount").Value
            End Select
            rs.MoveNext()
        Loop
        Report.SetParameterValue("txtAccountPayment", FormatNumber(lTotal, 2))
        lTotal = lTotal + CDec(Report.ParameterFields("txtAccountSales").ToString)
        Report.SetParameterValue("txtAccountTotal", FormatNumber(lTotal, 2))

        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        tmrReportCancel.Enabled = True
    End Sub
    Private Sub mnuMoney_Click()
        tmrReportCancel.Enabled = False
        'Dim Report As New cryMenuMoney
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryMenuMoney.rpt")
        Dim rs As ADODB.Recordset
        Dim lTotal As Decimal

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'get payoutTotal
        rs = getRS("SELECT Sum(Payout.Payout_Amount) AS amount FROM Company INNER JOIN Payout ON Company.Company_DayEndID = Payout.Payout_DayEndID;")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtPayout", "0.00")
        Else
            Report.SetParameterValue("txtPayout", FormatNumber(rs.Fields("amount").Value, 2))
        End If
        rs.Close()

        'get outages
        rs = getRS("SELECT Sum((([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer]))) AS amount FROM Company INNER JOIN Declaration ON Company.Company_DayEndID = Declaration.Declaration_DayEndID;")
        If IsDBNull(rs.Fields("amount").Value) Then
            Report.SetParameterValue("txtOutage", "0.00")
        Else
            Report.SetParameterValue("txtOutage", FormatNumber(rs.Fields("amount").Value, 2))
        End If
        rs.Close()

        'do money movement
        lTotal = 0
        rs = getRS("SELECT Sale.Sale_PaymentType, Sum(Sale.Sale_Total) AS amount FROM Company INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID  Where (((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
        Do Until rs.EOF
            Select Case rs.Fields("Sale_PaymentType").Value
                Case 1
                    Report.SetParameterValue("txtMoneyCash", FormatNumber(rs.Fields("amount").Value, 2))
                    lTotal = lTotal + rs.Fields("amount").Value
                Case 2
                    Report.SetParameterValue("txtMoneyCRcard", FormatNumber(rs.Fields("amount").Value, 2))
                    lTotal = lTotal + rs.Fields("amount").Value
                Case 3
                    Report.SetParameterValue("txtMoneyDRcard", FormatNumber(rs.Fields("amount").Value, 2))
                    lTotal = lTotal + rs.Fields("amount").Value
                Case 4
                    Report.SetParameterValue("txtMoneyCheque", FormatNumber(rs.Fields("amount").Value, 2))
                    lTotal = lTotal + rs.Fields("amount").Value
            End Select
            rs.MoveNext()
        Loop
        rs.Close()
        Report.SetParameterValue("txtMoneyTotal", FormatNumber(lTotal, 2))
        Report.SetParameterValue("txtMoneyTill", FormatNumber(CDec(Report.ParameterFields("txtMoneyTotal").ToString) + CDec(Report.ParameterFields("txtOutage").ToString) - CDec(Report.ParameterFields("txtPayout").ToString)), 2)

        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        tmrReportCancel.Enabled = True
    End Sub

    Private Sub frmMenu_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        'lblMenu.AddRange(New Label() {_lblMenu_0})
        DTPicker1.AddRange(New DateTimePicker() {_DTPicker1_0, _DTPicker1_1})
        Dim dt As New DateTimePicker
        For Each dt In DTPicker1
            AddHandler dt.ValueChanged, AddressOf DTPicker1_Change
        Next

    End Sub
End Class