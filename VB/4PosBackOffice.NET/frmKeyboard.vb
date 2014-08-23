Option Strict Off
Option Explicit On
Friend Class frmKeyboard
	Inherits System.Windows.Forms.Form
	Dim gParentID As Integer
	Dim grClick As Boolean
	
	Private Sub loadLanguage()
		
		'frmKeyboard = No Code  [Keyboard Layout Editor]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmKeyboard(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmKeyboard.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code       [Keyboard Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmKeyboard.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadKeys()
        Dim sql As String
		Dim rs As ADODB.Recordset
		Dim x As Integer
		Dim kS As String
		
        gridEdit.RowCount = 1
		rs = getRS("SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name From KeyboardLayout WHERE (((KeyboardLayout.KeyboardLayoutID)=" & gParentID & "));")
		If rs.RecordCount Then
			cnnDB.Execute("INSERT INTO KeyboardKeyboardLayoutLnk ( KeyboardKeyboardLayoutLnk_KeyboardID, KeyboardKeyboardLayoutLnk_KeyboardLayoutID, KeyboardKeyboardLayoutLnk_Shift, KeyboardKeyboardLayoutLnk_Key, KeyboardKeyboardLayoutLnk_Description ) SELECT theJoin.KeyboardID, theJoin.KeyboardLayoutID, 0 AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT keyboard.KeyboardID, KeyboardLayout.KeyboardLayoutID From keyboard, KeyboardLayout WHERE (((KeyboardLayout.KeyboardLayoutID)=" & gParentID & "))) AS theJoin LEFT JOIN KeyboardKeyboardLayoutLnk ON (theJoin.KeyboardID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID) AND (theJoin.KeyboardLayoutID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID) Is Null));")
			sql = "UPDATE KeyboardKeyboardLayoutLnk AS KeyboardKeyboardLayoutLnk_1 INNER JOIN KeyboardKeyboardLayoutLnk ON KeyboardKeyboardLayoutLnk_1.KeyboardKeyboardLayoutLnk_KeyboardID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID SET KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Shift], KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Key], KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Description] "
			sql = sql & "WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift)=0) AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key)=0) AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=" & gParentID & ") AND ((KeyboardKeyboardLayoutLnk_1.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=1));"
			
			If gParentID <> 1 Then cnnDB.Execute(sql)
			
			Me.txtName.Text = rs.Fields("KeyboardLayout_Name").Value
			rs = getRS("SELECT keyboard.*, KeyboardKeyboardLayoutLnk.* FROM KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID Where (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) = " & gParentID & ")) ORDER BY keyboard.keyboard_Order, keyboard.keyboard_Name;")
            gridEdit.RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
				gridEdit.row = x
				gridEdit.Col = 0
				gridEdit.Text = rs.Fields("keyboard_Name").Value
                gridEdit.CellAlignment = 1
				
				gridEdit.Col = 1
				gridEdit.Text = getKeyDescription(rs.Fields("KeyboardKeyboardLayoutLnk_Key").Value, rs.Fields("KeyboardKeyboardLayoutLnk_Shift").Value)
				gridEdit.Col = 2
				gridEdit.Text = rs.Fields("KeyboardKeyboardLayoutLnk_Shift").Value
				gridEdit.Col = 3
				gridEdit.Text = rs.Fields("KeyboardKeyboardLayoutLnk_Key").Value
				gridEdit.set_RowData(gridEdit.row, rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value)
				gridEdit.Col = 4
				gridEdit.Text = rs.Fields("Keyboard_Order").Value
				gridEdit.set_RowData(gridEdit.row, rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value)
				gridEdit.Col = 5
				If rs.Fields("keyboard_Show").Value = True Then
					kS = "Yes"
				Else
					kS = "No"
				End If
				gridEdit.Text = UCase(kS)
				gridEdit.Col = 6
				gridEdit.Text = rs.Fields("KeyboardID").Value
				gridEdit.set_RowData(gridEdit.row, rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value)
				rs.moveNext()
			Loop 
		End If
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cnnDB.Execute("UPDATE KeyboardLayout SET KeyboardLayout.KeyboardLayout_Name = '" & Replace(txtName.Text, "'", "''") & "' WHERE (((KeyboardLayout.KeyboardLayoutID)=" & gParentID & "));")
		Me.Close()
	End Sub
	
    Public Sub loadItem(ByRef lParentID As Integer)
        gParentID = lParentID
        loadKeys()

        loadLanguage()
        ShowDialog()
    End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim rs As ADODB.Recordset
		Dim sql As String
        'Dim Report As New cryKeyboardName
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryKeyboardName.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
		rs = getRS("SELECT KeyboardLayout.KeyboardLayout_Name, keyboard.keyboard_Name, KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description, keyboard.keyboard_Order, keyboard.keyboard_Show FROM (KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID) INNER JOIN KeyboardLayout ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID = KeyboardLayout.KeyboardLayoutID Where (((KeyboardLayout.KeyboardLayoutID) = " & gParentID & ")) ORDER BY keyboard.keyboard_Order, keyboard.keyboard_Name;")
		
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
		If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
        Report.Database.Tables(0).SetDataSource(rs)
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub frmKeyboard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		grClick = True
		With gridEdit
            .Col = 7
            .RowCount = 0
			System.Windows.Forms.Application.DoEvents()
            .RowCount = 2
			.FixedRows = 1
			.FixedCols = 0
			.row = 0
			.Col = 0
			.CellFontBold = True
			.Text = "Action"
			.set_ColWidth(0, 3000)
			.CellAlignment = 3
			
			.Col = 1
			.CellFontBold = True
			.Text = "Key"
			.set_ColWidth(1, 800)
			.CellAlignment = 4
			
			.Col = 2
			.CellFontBold = True
			.Text = "Special"
			.set_ColWidth(2, 0)
			.CellAlignment = 1
			
			.Col = 3
			.CellFontBold = True
			.Text = "Keycode"
			.set_ColWidth(3, 0)
			.CellAlignment = 1
			
			.Col = 4
			.CellFontBold = True
			.Text = "Display"
			.set_ColWidth(4, 800)
			.CellAlignment = 1
			
			.Col = 5
			.CellFontBold = True
			.Text = "Show"
			.set_ColWidth(5, 800)
			.CellAlignment = 1
			
			.Col = 6
			.CellFontBold = True
			.Text = "KEY"
			.set_ColWidth(6, 0)
			.CellAlignment = 1
			
			
		End With
	End Sub
	
	Public Function getKeyDescription(ByRef KeyCode As Short, ByRef Shift As Short) As Object
		Dim lShift As String
		Dim lKey As String
		Select Case KeyCode
			Case 16, 17, 18
			Case 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123
				lKey = "F" & KeyCode - 111
			Case 37
				lKey = "Left"
			Case 38
				lKey = "Up"
			Case 39
				lKey = "Right"
			Case 40
				lKey = "Down"
			Case 27
				lKey = "Esc"
			Case 13
				lKey = "Enter"
			Case 35
				lKey = "End"
			Case 34
				lKey = "PgDn"
			Case 33
				lKey = "PgUp"
			Case 36
				lKey = "Home"
			Case 46
				lKey = "Del"
			Case 45
				lKey = "Ins"
			Case 19
				lKey = "Pause"
			Case 9
				lKey = "Tab"
			Case 8
				lKey = "Back Space"
			Case Else
				lKey = Chr(KeyCode)
		End Select
		Select Case Shift
			Case 1
				lShift = "Shift+"
			Case 2
				lShift = "Ctrl+"
			Case 4
				lShift = "Alt+"
			Case Else
				lShift = ""
		End Select
		getKeyDescription = lShift & lKey
	End Function
	
    Private Sub gridEdit_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles gridEdit.Click
        Dim inres As MsgBoxResult
        Dim k_ID As Integer
        Dim lName As String
        Dim kView As String
        Dim inRe As Short
        Dim lKey As Short
        Dim lShift As Short
        Dim rs As ADODB.Recordset

        If grClick = True Then
            grClick = False
            Exit Sub
        End If

        kView = UCase(Trim(gridEdit.get_TextMatrix(gridEdit.row, gridEdit.Col)))

        If kView = "YES" Or kView = "NO" Then
            k_ID = Val(gridEdit.get_TextMatrix(gridEdit.row, gridEdit.Col + 1))
            If kView = "YES" Then
                inres = MsgBox("Do you want to hide Key on Keyboard", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Keyboard SET Keyboard_Show = 0 WHERE KeyboardID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.row, gridEdit.Col, "NO")

                End If

            ElseIf kView = "NO" Then
                inres = MsgBox("Do you want to show Key on Keyboard", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Keyboard SET Keyboard_Show = 1 WHERE KeyboardID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.row, gridEdit.Col, "YES")
                End If
            End If

            Exit Sub
        End If

        lName = gridEdit.get_TextMatrix(gridEdit.row, 0)
        k_ID = Val(gridEdit.get_TextMatrix(gridEdit.row, 6))
        'Do Display Option.....

        If gridEdit.Col > 0 Then
            If Val(kView) > 0 Then
                If Val(kView) < 100 Then
                    frmChangeDisplay.lblName.Text = lName
                    frmChangeDisplay.txtNumber.Text = Trim(kView)
                    frmChangeDisplay.ShowDialog()

                    If InKeyboard = 200 Then
                    Else
                        cnnDB.Execute("UPDATE Keyboard SET keyboard_Order = " & InKeyboard & " WHERE KeyboardID = " & k_ID)
                        With gridEdit
                            .Text = Str(InKeyboard)
                            loadKeys()
                        End With
                    End If
                End If
                Exit Sub
            End If
        End If

        lName = gridEdit.get_TextMatrix(gridEdit.row, 0)

        lKey = CShort(gridEdit.get_TextMatrix(gridEdit.row, 3))
        lShift = CShort(gridEdit.get_TextMatrix(gridEdit.row, 2))
        frmKeyboardGet.getKeyboardValue(lName, lKey, lShift)

        If lKey <> 0 Then
            'Set rs = getRS("SELECT keyboard.* From keyboard WHERE (((keyboard.keyboard_Shift)=" & lShift & ") AND ((keyboard.keyboard_Key)=" & lKey & "));")
            rs = getRS("SELECT keyboard.keyboardID, keyboard.keyboard_Name, KeyboardKeyboardLayoutLnk.* FROM KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID Where (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) = " & gParentID & ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift)=" & lShift & ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key)=" & lKey & "))")

            If rs.RecordCount Then
                If rs.Fields("KeyboardID").Value = gridEdit.get_RowData(gridEdit.row) Then
                Else
                    MsgBox("Cannot allocate this key as it is allocated to '" & rs.Fields("keyboard_Name").Value & "!", MsgBoxStyle.Exclamation, "KEYBOARD LAYOUT")
                End If
            Else
                lName = getKeyDescription(lKey, lShift)
                cnnDB.Execute("UPDATE KeyboardKeyboardLayoutLnk SET KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift = " & lShift & ", KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key = " & lKey & ", KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description = '" & lName & "' WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=" & gParentID & ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID)=" & gridEdit.get_RowData(gridEdit.row) & "));")
                gridEdit.set_TextMatrix(gridEdit.row, 3, lKey)
                gridEdit.set_TextMatrix(gridEdit.row, 2, lShift)
                gridEdit.set_TextMatrix(gridEdit.row, 1, lName)
            End If

        End If
    End Sub
End Class