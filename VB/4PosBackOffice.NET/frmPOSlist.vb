Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPOSlist
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	
	Private Sub loaLanguage()
		
		'frmPOSlist = No Code   [Select a Point Of Sale]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPOSlist.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSlist.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
	End Sub
	
	Public Function getItem() As Integer
		cmdNew.Visible = False
		
		loaLanguage()
		Me.ShowDialog()
		getItem = gID
		
	End Function
	Public Function doAction(ByRef lSection As Short) As Integer
		gSection = lSection
		Me.ShowDialog()
	End Function
	
	Private Sub getNamespace()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Function getSerialNumber() As String
		Dim fso As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		Dim fsoDrive As Scripting.Drive
		getSerialNumber = ""
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal PassWord As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(PassWord)
        For x = 0 To Len(secret)
            Char_Renamed = CStr(Asc(Mid(PassWord, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
            Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
        Next
		Encrypt = secret
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_Code").Value) Then
					gSecKey = rs.Fields("Company_Code").Value
					If Len(rs.Fields("Company_Code").Value) = 13 Then
						
						checkSecurity = True
						Exit Function
					End If
				End If
				lPassword = "pospospospos"
				lCode = getSerialNumber
				If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
					checkSecurity = True
				Else
					leCode = Encrypt(lCode, lPassword)
					For x = 1 To Len(leCode)
						If Asc(Mid(leCode, x, 1)) < 33 Then
							leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
						End If
					Next x
					
					If rs.Fields("Company_Code").Value = leCode Then
						'If IsNull(rs("Company_TerminateDate")) Then
						checkSecurity = True
						'Else
						'    If Date > rs("Company_TerminateDate") Then
						'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						'        checkSecurity = False
						Exit Function
						'   End If
						'End If
					Else
						'txtCompany.Text = rs("Company_Name")
						'txtCompany.SelStart = 0
						'txtCompany.SelLength = 999
						'show 1
					End If
					
				End If
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		If checkSecurity = True Then
			If frmPOSCode.setupCode = True Then
				nwPOS = True
				frmPOS.loadItem(0)
				doSearch()
			End If
		Else
			MsgBox("New POS units may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "Software is not Registered")
		End If
	End Sub
	
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles DataList1.DoubleClick
        If DataList1.BoundText <> "" Then
            If gSection Then
                Select Case gSection
                    Case 1
                        report_POS(CInt(DataList1.BoundText))
                End Select
                Exit Sub
            Else
                frmPOS.loadItem(CInt(DataList1.BoundText))
            End If
        End If
        doSearch()
    End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub
	Private Sub frmPOSlist_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmPOSlist_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		nwPOS = False
		
		loaLanguage()
		doSearch()
		
		
	End Sub
	
	Private Sub frmPOSlist_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				Me.DataList1.Focus()
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = "WHERE (Pos_Name LIKE '%" & Replace(lString, " ", "%' AND Pos_Name LIKE '%") & "%')"
		End If
		gRS = getRS("SELECT DISTINCT PosID, Pos_Name FROM Pos " & lString & " ORDER BY PosID")
		'Display the list of Titles in the DataCombo
        DataList1.DataSource = gRS
  DataList1.listField = "Pos_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "PosID"
		
	End Sub
End Class