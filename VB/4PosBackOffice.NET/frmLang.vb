Option Strict Off
Option Explicit On
Friend Class frmLang
	Inherits System.Windows.Forms.Form
	Dim gParentID As Integer
	Dim grClick As Boolean
	Private Sub loadKeys(ByRef secID As Short)
        Dim sql As String
		Dim rs As ADODB.Recordset
		Dim x As Integer
		Dim kS As String
		
		gridEdit.RowCount = 1
		rs = getRS("SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name From LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" & gParentID & "));")
		If rs.RecordCount Then
			cnnDB.Execute("INSERT INTO LanguageLayoutLnk ( LanguageLayoutLnk_LanguageID, LanguageLayoutLnk_LanguageLayoutID, LanguageLayoutLnk_Description, LanguageLayoutLnk_RightTL, LanguageLayoutLnk_Screen ) SELECT theJoin.LanguageID, theJoin.LanguageLayoutID, 'None' AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT Language.LanguageID, LanguageLayout.LanguageLayoutID From Language, LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" & gParentID & "))) AS theJoin LEFT JOIN LanguageLayoutLnk ON (theJoin.LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) AND (theJoin.LanguageLayoutID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) Is Null));")
			sql = "UPDATE LanguageLayoutLnk AS LanguageLayoutLnk_1 INNER JOIN LanguageLayoutLnk ON LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID SET LanguageLayoutLnk.LanguageLayoutLnk_Description = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Description], LanguageLayoutLnk.LanguageLayoutLnk_RightTL = [LanguageLayoutLnk_1]![LanguageLayoutLnk_RightTL], LanguageLayoutLnk.LanguageLayoutLnk_Section = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Section], LanguageLayoutLnk.LanguageLayoutLnk_Screen = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Screen] "
			sql = sql & "WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_Description)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_Screen)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageLayoutID)=1));"
			
			If gParentID <> 1 Then cnnDB.Execute(sql)
			
			Me.txtName.Text = rs.Fields("LanguageLayout_Name").Value
			rs = getRS("SELECT Language.*, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Section) = " & secID & ")) ORDER BY LanguageLayoutLnk_LanguageID;")
			gridEdit.RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
				gridEdit.row = x
				gridEdit.Col = 0
				gridEdit.Text = rs.Fields("LanguageLayoutLnk_Description").Value
				gridEdit.CellAlignment = 1
				
				gridEdit.Col = 1
				If rs.Fields("LanguageLayoutLnk_RightTL").Value = True Then
					kS = "Yes"
				Else
					kS = "No"
				End If
				gridEdit.Text = UCase(kS)
				'gridEdit.Text = getKeyDescription(rs("LanguageLayoutLnk_Key"), rs("LanguageLayoutLnk_Shift"))
				gridEdit.Col = 2
				gridEdit.Text = IIf(IsDbNull(rs.Fields("LanguageLayoutLnk_Screen").Value), "NOT ASSIGNED", rs.Fields("LanguageLayoutLnk_Screen").Value) 'rs("LanguageLayoutLnk_Screen")
				'gridEdit.Col = 3
				'gridEdit.Text = rs("LanguageLayoutLnk_Key")
				gridEdit.set_RowData(gridEdit.row, rs.Fields("LanguageLayoutLnk_LanguageID").Value)
				'gridEdit.Col = 4
				'gridEdit.Text = rs("Language_Order")
				'gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
				'gridEdit.Col = 5
				'If rs("Language_Show") = True Then
				'   kS = "Yes"
				'Else
				'   kS = "No"
				'End If
				'gridEdit.Text = UCase(kS)
				'gridEdit.Col = 6
				'gridEdit.Text = rs("LanguageID")
				'gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
				rs.moveNext()
			Loop 
		End If
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cnnDB.Execute("UPDATE LanguageLayout SET LanguageLayout.LanguageLayout_Name = '" & Replace(txtName.Text, "'", "''") & "' WHERE (((LanguageLayout.LanguageLayoutID)=" & gParentID & "));")
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("UPDATE LanguageLayout SET LanguageLayout.LanguageLayout_Name = '" & Replace(txtName.Text, "'", "''") & "' WHERE (((LanguageLayout.LanguageLayoutID)=" & gParentID & "));")
		Me.Close()
	End Sub
	
    Public Sub loadItem(ByRef lParentID As Short)
        gParentID = lParentID
        'loadKeys
        Option1_CheckedChanged(Option1, New System.EventArgs())
        Option1.Checked = True
        ShowDialog()
    End Sub
	
	Private Sub frmLang_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		grClick = True
		With gridEdit
            .Col = 3
			.RowCount = 0
			System.Windows.Forms.Application.DoEvents()
			.RowCount = 2
			.FixedRows = 1
			.FixedCols = 0
			.row = 0
			.Col = 0
			.CellFontBold = True
			.Text = "Translation"
			.set_ColWidth(0, 11200)
			.CellAlignment = 3
			
			.Col = 1
			.CellFontBold = True
			.Text = "Right To Left"
			.set_ColWidth(1, 1200)
			.CellAlignment = 4
			
			.Col = 2
			.CellFontBold = True
			.Text = "Screen"
			.set_ColWidth(2, 1500)
			.CellAlignment = 1
			
			'.Col = 3
			'.CellFontBold = True
			'.Text = "Keycode"
			'.ColWidth(3) = 0
			'.CellAlignment = 1
			
			'.Col = 4
			'.CellFontBold = True
			'.Text = "Display"
			'.ColWidth(4) = 800
			'.CellAlignment = 1
			
			'.Col = 5
			'.CellFontBold = True
			'.Text = "Show"
			'.ColWidth(5) = 800
			'.CellAlignment = 1
			
			'.Col = 6
			'.CellFontBold = True
			'.Text = "KEY"
			'.ColWidth(6) = 0
			'.CellAlignment = 1
			
			
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
		'UPGRADE_WARNING: Couldn't resolve default property of object getKeyDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		getKeyDescription = lShift & lKey
	End Function
	
    Private Sub gridEdit_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles gridEdit.ClickEvent
        Dim frmLanguageGet As frmLangGet
        Dim InLanguage As Integer
        Dim inres As MsgBoxResult
        Dim k_ID As Integer
        Dim lName, sScreen As String
        Dim bRTL As Boolean
        Dim kView As String
        Dim inRe As Short
        Dim lKey As Short
        Dim lShift As Short
        Dim rs As ADODB.Recordset

        If grClick = True Then
            grClick = False
            Exit Sub
        End If

        lName = Trim(gridEdit.get_TextMatrix(gridEdit.row, 0))
        kView = UCase(Trim(gridEdit.get_TextMatrix(gridEdit.row, 1)))
        If kView = "YES" Then
            bRTL = True
        Else
            bRTL = False
        End If
        sScreen = Trim(gridEdit.get_TextMatrix(gridEdit.row, 2))
        frmLangGet.getLanguageValue(lName, bRTL, sScreen)

        If lName <> "" Then
            'Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
            rs = getRS("SELECT Language.LanguageID, Language.Language_Description, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.get_RowData(gridEdit.row) & "))")

            If rs.RecordCount Then
                '    If rs("LanguageID") = gridEdit.RowData(gridEdit.row) Then
                '    Else
                '        MsgBox "Cannot allocate this key as it is allocated to '" & rs("Language_Name") & "!", vbExclamation, "Language LAYOUT"
                '    End If
                'Else
                '    lName = getKeyDescription(lKey, lShift)
                lName = Replace(lName, ",", "-")
                lName = Replace(lName, "'", "''")
                cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_RightTL = " & bRTL & ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" & lName & "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.get_RowData(gridEdit.row) & "));")
                'cnnDB.Execute "UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " & lShift & ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " & lKey & ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" & lName & "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.RowData(gridEdit.row) & "));"
                '    gridEdit.TextMatrix(gridEdit.row, 3) = lKey
                If bRTL = True Then
                    gridEdit.set_TextMatrix(gridEdit.row, 1, "YES")
                Else
                    gridEdit.set_TextMatrix(gridEdit.row, 1, "NO")
                End If
                gridEdit.set_TextMatrix(gridEdit.row, 0, lName)
            End If

        End If

        Exit Sub
        kView = UCase(Trim(gridEdit.get_TextMatrix(gridEdit.row, gridEdit.Col)))

        If kView = "YES" Or kView = "NO" Then
            k_ID = Val(gridEdit.get_TextMatrix(gridEdit.row, gridEdit.Col + 1))
            If kView = "YES" Then
                inres = MsgBox("Do you want to hide Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Language SET Language_Show = 0 WHERE LanguageID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.row, gridEdit.Col, "NO")

                End If

            ElseIf kView = "NO" Then
                inres = MsgBox("Do you want to show Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Language SET Language_Show = 1 WHERE LanguageID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.row, gridEdit.Col, "YES")
                End If
            End If

            Exit Sub
        End If

        lName = gridEdit.get_TextMatrix(gridEdit.row, 0)
        'k_ID = Val(gridEdit.TextMatrix(gridEdit.row, 6))
        'Do Display Option.....

        If gridEdit.Col > 0 Then
            If Val(kView) > 0 Then
                If Val(kView) < 100 Then
                    frmChangeDisplay.lblName.Text = lName
                    frmChangeDisplay.txtNumber.Text = Trim(kView)
                    frmChangeDisplay.ShowDialog()

                    If InLanguage = 200 Then
                    Else
                        cnnDB.Execute("UPDATE Language SET Language_Order = " & InLanguage & " WHERE LanguageID = " & k_ID)
                        With gridEdit
                            .Text = Str(InLanguage)
                            If Option1.Checked Then loadKeys(0)
                            If Option2.Checked Then loadKeys(2)
                            If Option3.Checked Then loadKeys(1)
                        End With
                    End If
                End If
                Exit Sub
            End If
        End If

        lName = gridEdit.get_TextMatrix(gridEdit.row, 0)

        'lKey = gridEdit.TextMatrix(gridEdit.row, 3)
        'lShift = gridEdit.TextMatrix(gridEdit.row, 2)
        'UPGRADE_WARNING: Couldn't resolve default property of object frmLanguageGet.getLanguageValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmLanguageGet.getLanguageValue(lName, lKey, lShift)

        If lKey <> 0 Then
            'Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
            rs = getRS("SELECT Language.LanguageID, Language.Language_Name, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Shift)=" & lShift & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Key)=" & lKey & "))")

            If rs.RecordCount Then
                If rs.Fields("LanguageID").Value = gridEdit.get_RowData(gridEdit.row) Then
                Else
                    MsgBox("Cannot allocate this key as it is allocated to '" & rs.Fields("Language_Name").Value & "!", MsgBoxStyle.Exclamation, "Language LAYOUT")
                End If
            Else
                lName = getKeyDescription(lKey, lShift)
                cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " & lShift & ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " & lKey & ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" & lName & "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.get_RowData(gridEdit.row) & "));")
                gridEdit.set_TextMatrix(gridEdit.row, 3, lKey)
                gridEdit.set_TextMatrix(gridEdit.row, 2, lShift)
                gridEdit.set_TextMatrix(gridEdit.row, 1, lName)
            End If

        End If
    End Sub
	
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
		If eventSender.Checked Then
			loadKeys(0)
		End If
	End Sub
	
	Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2.CheckedChanged
		If eventSender.Checked Then
			loadKeys(2)
		End If
	End Sub
	
	Private Sub Option3_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option3.CheckedChanged
		If eventSender.Checked Then
			loadKeys(1)
		End If
	End Sub
	
	Private Sub Option4_Click()
        Dim secID As Integer
        Dim sql As String
		
		grClick = True
		With gridEdit
            .Col = 1
			.RowCount = 0
			System.Windows.Forms.Application.DoEvents()
			.RowCount = 2
			.FixedRows = 1
			.FixedCols = 0
			.row = 0
			.Col = 0
			.CellFontBold = True
			.Text = "Translation"
			.set_ColWidth(0, 11200)
			.CellAlignment = 3
		End With
		
		Dim rs As ADODB.Recordset
		Dim x As Integer
		Dim kS As String
		
		gridEdit.RowCount = 1
		rs = getRS("SELECT * FROM Menu;")
		If rs.RecordCount Then
			cnnDB.Execute("INSERT INTO LanguageLayoutLnk ( LanguageLayoutLnk_LanguageID, LanguageLayoutLnk_LanguageLayoutID, LanguageLayoutLnk_Description, LanguageLayoutLnk_RightTL, LanguageLayoutLnk_Screen ) SELECT theJoin.LanguageID, theJoin.LanguageLayoutID, 'None' AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT Language.LanguageID, LanguageLayout.LanguageLayoutID From Language, LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" & gParentID & "))) AS theJoin LEFT JOIN LanguageLayoutLnk ON (theJoin.LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) AND (theJoin.LanguageLayoutID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) Is Null));")
			sql = "UPDATE LanguageLayoutLnk AS LanguageLayoutLnk_1 INNER JOIN LanguageLayoutLnk ON LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID SET LanguageLayoutLnk.LanguageLayoutLnk_Description = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Description], LanguageLayoutLnk.LanguageLayoutLnk_RightTL = [LanguageLayoutLnk_1]![LanguageLayoutLnk_RightTL], LanguageLayoutLnk.LanguageLayoutLnk_Section = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Section], LanguageLayoutLnk.LanguageLayoutLnk_Screen = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Screen] "
			sql = sql & "WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_Description)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_Screen)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageLayoutID)=1));"
			
			If gParentID <> 1 Then cnnDB.Execute(sql)
			
			Me.txtName.Text = rs.Fields("LanguageLayout_Name").Value
			rs = getRS("SELECT Language.*, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Section) = " & secID & ")) ORDER BY LanguageLayoutLnk_LanguageID;")
			gridEdit.RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
				gridEdit.row = x
				gridEdit.Col = 0
				gridEdit.Text = rs.Fields("LanguageLayoutLnk_Description").Value
				gridEdit.CellAlignment = 1
				
				gridEdit.Col = 1
				If rs.Fields("LanguageLayoutLnk_RightTL").Value = True Then
					kS = "Yes"
				Else
					kS = "No"
				End If
				gridEdit.Text = UCase(kS)
				'gridEdit.Text = getKeyDescription(rs("LanguageLayoutLnk_Key"), rs("LanguageLayoutLnk_Shift"))
				gridEdit.Col = 2
				gridEdit.Text = IIf(IsDbNull(rs.Fields("LanguageLayoutLnk_Screen").Value), "NOT ASSIGNED", rs.Fields("LanguageLayoutLnk_Screen").Value) 'rs("LanguageLayoutLnk_Screen")
				'gridEdit.Col = 3
				'gridEdit.Text = rs("LanguageLayoutLnk_Key")
				gridEdit.set_RowData(gridEdit.row, rs.Fields("LanguageLayoutLnk_LanguageID").Value)
				'gridEdit.Col = 4
				'gridEdit.Text = rs("Language_Order")
				'gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
				'gridEdit.Col = 5
				'If rs("Language_Show") = True Then
				'   kS = "Yes"
				'Else
				'   kS = "No"
				'End If
				'gridEdit.Text = UCase(kS)
				'gridEdit.Col = 6
				'gridEdit.Text = rs("LanguageID")
				'gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
				rs.moveNext()
			Loop 
		End If
		
	End Sub
End Class