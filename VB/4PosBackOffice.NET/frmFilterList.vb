Option Strict Off
Option Explicit On
Friend Class frmFilterList
	Inherits System.Windows.Forms.Form
	Dim gField As String
    Dim gArray(,) As String
	Dim loading As Boolean
	Dim gFieldID As String
	Dim gFieldName As String
	Dim gHeading As String

    Dim cmdClick As New List(Of Button)

	Private Sub loadLanguage()
		
		'frmFilterList = No caption / No Code / NA?
		
		'TOOLBAR CODE NOT DONE!
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmFilterList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub setup()
        Dim x As Short
		
		loading = True
		lstFilter.Visible = False
        Me.lstFilter.Items.Clear()
        Dim m As Integer
		Select Case Me.tbStockItem.Tag
			Case CStr(1)
				For x = 0 To UBound(gArray)
					If CBool(gArray(x, 2)) Then
						If InStr(UCase(gArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                            m = lstFilter.Items.Add(New LBI(gArray(x, 1), x))
                            lstFilter.SetItemChecked(m, gArray(x, 2))
						End If
					End If
				Next 
				
			Case CStr(2)
				For x = 0 To UBound(gArray)
					If CBool(gArray(x, 2)) Then
					Else
						If InStr(UCase(gArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                            m = lstFilter.Items.Add(New LBI(gArray(x, 1), x))
                            lstFilter.SetItemChecked(m, gArray(x, 2))
						End If
					End If
				Next 
			Case Else
				For x = 0 To UBound(gArray)
					If InStr(UCase(gArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                        m = lstFilter.Items.Add(New LBI(gArray(x, 1), x))
                        lstFilter.SetItemChecked(m, gArray(x, 2))
					End If
				Next 
		End Select
		If lstFilter.SelectedIndex Then lstFilter.SelectedIndex = 0
		lstFilter.Visible = True
		loading = False
		
	End Sub
	
    Public Function loadData(ByRef lName As String) As Boolean
        Dim rs As ADODB.Recordset
        Dim lSQL As String
        Dim x As Integer
        Dim lID As String
        gField = lName

        rs = getRS("SELECT * From ftConstruct WHERE (ftConstruct_Name = '" & Replace(lName, "'", "''") & "')")
        gFieldID = rs.Fields("ftConstruct_FieldID").Value
        gFieldName = rs.Fields("ftConstruct_FieldName").Value
        gHeading = rs.Fields("ftConstruct_DisplayName").Value
        lSQL = rs.Fields("ftConstruct_SQL").Value
        rs.Close()
        rs = getRS(lSQL)
        'Display the list of Titles in the DataCombo

        loading = True
        loadData = False
        x = -1
        ReDim gArray(rs.RecordCount - 1, 2)
        Do Until rs.EOF
            x = x + 1
            gArray(x, 0) = rs.Fields(gFieldID).Value
            gArray(x, 1) = rs.Fields(gFieldName).Value & ""
            gArray(x, 2) = CStr(0)
            rs.MoveNext()
        Loop
        rs.Close()
        rs = getRS("SELECT ftDataItem_ID From ftDataItem WHERE (ftDataItem_PersonID = " & gPersonID & ") AND (ftDataItem_FieldName = '" & Replace(gField, "'", "''") & "')")
        Do Until rs.EOF

            lID = rs.Fields("ftDataItem_ID").Value
            For x = 0 To UBound(gArray)
                If lID = gArray(x, 0) Then
                    gArray(x, 2) = CStr(1)
                End If
            Next
            rs.MoveNext()
        Loop
        rs.Close()
        setup()
        loadData = True

        loadLanguage()
        ShowDialog()
        loading = False

    End Function
	
	Private Sub save()
		Dim x As Short
		Dim lSQL As String
		Dim lHeading As String
		Dim rs As New ADODB.Recordset
		rs = cnnDB.Execute("DELETE FROM ftDataItem WHERE (ftDataItem_PersonID = " & gPersonID & ") AND (ftDataItem_FieldName = '" & Replace(gField, "'", "''") & "')")
		cnnDB.Execute("DELETE FROM ftData WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(gField, "'", "''") & "')")
		For x = 0 To lstFilter.Items.Count - 1
			If lstFilter.GetItemChecked(x) Then
                lHeading = lHeading & " OR ''" & gArray(GetItemData(lstFilter, x), 1) & "''"
                lSQL = lSQL & " OR [field] = " & gArray(GetItemData(lstFilter, x), 0)
                cnnDB.Execute("INSERT INTO ftDataItem (ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID) VALUES (" & gPersonID & ", '" & Replace(gField, "'", "''") & "', " & gArray(GetItemData(lstFilter, x), 0) & ")")
			End If
			
		Next x
		If lSQL <> "" Then
			lSQL = "(" & Mid(lSQL, 4) & ")"
			lHeading = "(" & gHeading & " = " & Mid(lHeading, 4) & ")"
			cnnDB.Execute("INSERT INTO ftData (ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading) VALUES (" & gPersonID & ", '" & Replace(gField, "'", "''") & "', '" & Replace(lSQL, "'", "''") & "', '" & Replace(lHeading, "'", "''") & "')")
		End If
	End Sub
	
	
	
	
    Private Sub cmdClick_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmdClick.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdClick)
        tbStockItem_ButtonClick(Me.tbStockItem.Items.Item(Index), New System.EventArgs())
        lstFilter.Focus()
    End Sub
	
	Private Sub frmFilterList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		save()
	End Sub
	
	Private Sub lstFilter_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lstFilter.ItemCheck
		If loading Then Exit Sub
		Dim x As Short
        x = GetItemData(lstFilter, lstFilter.SelectedIndex)
		If CBool(gArray(x, 2)) <> lstFilter.GetItemChecked(eventArgs.Index) Then
			gArray(x, 2) = CStr(lstFilter.GetItemChecked(lstFilter.SelectedIndex))
		End If
	End Sub
	
	Private Sub lstFilter_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lstFilter.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If Shift = 4 And KeyCode = 88 Then
			Me.Close()
			KeyCode = 0
		End If
		
	End Sub
	
    Private Sub lstFilter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstFilter.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 27 Then
            Me.Close()
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub tbStockItem_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbStockItem_Button1.Click, _tbStockItem_Button2.Click, _tbStockItem_Button3.Click, _tbStockItem_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Dim x As Short
        If Button.Name = "clear" Then
            For x = 0 To lstFilter.Items.Count - 1
                gArray(x, 2) = CStr(0)
                lstFilter.SetItemChecked(x, gArray(x, 2))
            Next

            setup()

        Else
            For x = 0 To tbStockItem.Items.Count
                CType(tbStockItem.Items.Item(x), ToolStripButton).Checked = False
            Next
            tbStockItem.Tag = Button.Owner.Items.IndexOf(Button) - 1
            'Button.Checked = True
            setup()
        End If
    End Sub

    Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
        txtSearch.SelectionStart = 0
        txtSearch.SelectionLength = 9999
    End Sub


    Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 40 Then
            If lstFilter.Items.Count Then
                lstFilter.Focus()
                If lstFilter.SelectedIndex = -1 Then
                    lstFilter.SelectedIndex = 0
                End If
            End If
            KeyCode = 0
        End If
        If Shift = 4 And KeyCode = 88 Then
            Me.Close()
            KeyCode = 0
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then
            setup()
            KeyAscii = 0
        End If
        If KeyAscii = 27 Then
            Me.Close()
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmFilterList_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cmdClick.AddRange(New Button() {_cmdClick_1, _cmdClick_2, _cmdClick_3, _cmdClick_4})
        Dim bt As New Button
        For Each bt In cmdClick
            AddHandler bt.Click, AddressOf cmdClick_Click
        Next
    End Sub
End Class