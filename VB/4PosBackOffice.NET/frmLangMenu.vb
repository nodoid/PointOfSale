Option Strict Off
Option Explicit On
Friend Class frmLangMenu
	Inherits System.Windows.Forms.Form
	Dim gParentID As Integer
	Dim grClick As Boolean
	Private Sub loadKeys(ByRef secID As Short)
		Dim rs As ADODB.Recordset
		Dim x As Integer
		Dim kS As String
		
        gridEdit.RowCount = 1
		rs = getRS("SELECT * FROM Menu WHERE (((Menu.Menu_ParentID)>0)) ORDER BY Menu.Menu_ParentID, Menu.Menu_Order;")
		If rs.RecordCount Then
            gridEdit.RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
                gridEdit.RowCount = x
                gridEdit.ColumnCount = 0
				gridEdit.Text = rs.Fields("Menu_Name").Value
                'gridEdit.CellAlignment = 1
				
                gridEdit.set_RowData(gridEdit.RowCount, rs.Fields("MenuID").Value)
				
				rs.moveNext()
			Loop 
		End If
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
    Public Sub loadItem(ByRef lParentID As Integer)
        gParentID = lParentID
        loadKeys(4)
        ShowDialog()
    End Sub
	
	Private Sub frmLangMenu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		grClick = True
		With gridEdit
            .ColumnCount = 1
            .RowCount = 0
			System.Windows.Forms.Application.DoEvents()
            .RowCount = 2
            '.FixedRows = 1
            '.FixedCols = 0
            .RowCount = 0
            .ColumnCount = 0
            '.CellFontBold = True
            .Text = "Translation"
            '.set_ColWidth(0, 6225)
            '.CellAlignment = 3
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
	
    Private Sub gridEdit_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim frmLanguageGet As frmLangGet
        Dim Option3 As New RadioButton
        Dim Option2 As New RadioButton
        Dim Option1 As New RadioButton
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

        lName = Trim(gridEdit.get_TextMatrix(gridEdit.RowCount, 0))
        'If kView = "YES" Then
        bRTL = True
        'Else
        '    bRTL = False
        'End If
        sScreen = "" 'Trim(gridEdit.TextMatrix(gridEdit.row, 2))
        frmLangGet.getLanguageValue(lName, bRTL, sScreen)

        If lName <> "" Then
            rs = getRS("SELECT * FROM Menu WHERE ((MenuID)=" & gridEdit.get_RowData(gridEdit.RowCount) & ");")
            If rs.RecordCount Then

                lName = Replace(lName, ",", "-")
                lName = Replace(lName, "'", "''")

                cnnDB.Execute("UPDATE Menu SET Menu_Update=True, Menu_Name = '" & lName & "' WHERE ((MenuID)=" & gridEdit.get_RowData(gridEdit.RowCount) & ");")
                gridEdit.set_TextMatrix(gridEdit.RowCount, 0, lName)
            End If

        End If

        Exit Sub
        kView = UCase(Trim(gridEdit.get_TextMatrix(gridEdit.RowCount, gridEdit.ColumnCount)))

        If kView = "YES" Or kView = "NO" Then
            k_ID = Val(gridEdit.get_TextMatrix(gridEdit.RowCount, gridEdit.ColumnCount + 1))
            If kView = "YES" Then
                inres = MsgBox("Do you want to hide Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Language SET Language_Show = 0 WHERE LanguageID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.RowCount, gridEdit.ColumnCount, "NO")

                End If

            ElseIf kView = "NO" Then
                inres = MsgBox("Do you want to show Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title)
                If inres = MsgBoxResult.Yes Then
                    cnnDB.Execute("UPDATE Language SET Language_Show = 1 WHERE LanguageID = " & k_ID)
                    gridEdit.set_TextMatrix(gridEdit.RowCount, gridEdit.ColumnCount, "YES")
                End If
            End If

            Exit Sub
        End If

        lName = gridEdit.get_TextMatrix(gridEdit.RowCount, 0)
        'k_ID = Val(gridEdit.TextMatrix(gridEdit.row, 6))
        'Do Display Option.....

        If gridEdit.ColumnCount > 0 Then
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

        lName = gridEdit.get_TextMatrix(gridEdit.RowCount, 0)

        'lKey = gridEdit.TextMatrix(gridEdit.row, 3)
        'lShift = gridEdit.TextMatrix(gridEdit.row, 2)
        frmLanguageGet.getLanguageValue(lName, lKey, lShift)

        If lKey <> 0 Then
            'Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
            rs = getRS("SELECT Language.LanguageID, Language.Language_Name, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Shift)=" & lShift & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Key)=" & lKey & "))")

            If rs.RecordCount Then
                If rs.Fields("LanguageID").Value = gridEdit.get_RowData(gridEdit.RowCount) Then
                Else
                    MsgBox("Cannot allocate this key as it is allocated to '" & rs.Fields("Language_Name").Value & "!", MsgBoxStyle.Exclamation, "Language LAYOUT")
                End If
            Else
                lName = getKeyDescription(lKey, lShift)
                cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " & lShift & ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " & lKey & ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" & lName & "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.get_RowData(gridEdit.RowCount) & "));")
                gridEdit.set_TextMatrix(gridEdit.RowCount, 3, lKey)
                gridEdit.set_TextMatrix(gridEdit.RowCount, 2, lShift)
                gridEdit.set_TextMatrix(gridEdit.RowCount, 1, lName)
            End If

        End If
    End Sub
End Class