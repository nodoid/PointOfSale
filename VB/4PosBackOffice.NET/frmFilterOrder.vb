Option Strict Off
Option Explicit On
Friend Class frmFilterOrder
	Inherits System.Windows.Forms.Form
	Dim objectArray() As Object
	Public gCriteria As String
	Public gHeading As String
    Dim cmdList As New List(Of Button)
	Private Sub loadLanguage()

		'frmFilterOrder = No Code   [Broken Pack Exclusion List Criteria]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmFilterOrder.Caption = rsLang("LanguageLayoutLnk_Description"): frmFilterOrder.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmList(0) = No Code/Dynamic/NA?
		'lblList(0) = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2136 'Build |Checked
		If rsLang.RecordCount Then cmdList(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdList(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmFilterOrder.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub buildCriteria(ByRef filter_Renamed As String)
		Dim rs As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		gHeading = ""
		gCriteria = ""
		rs = modRecordSet.getRS("SELECT * From ftOrderSet Where (((ftSet_Group) = 'order')) ORDER BY ftSet_Order;")
		If rs.BOF Or rs.EOF Then
		Else
			Do Until rs.EOF
				RSitem = getRS("SELECT * From ftOrder WHERE (((ftData_PersonID)=" & gPersonID & ") AND ((ftData_FieldName)='" & Replace(rs.Fields("ftSet_Name").Value, "'", "''") & "'));")
				If RSitem.BOF Or RSitem.EOF Then
				Else
					gHeading = gHeading & " AND " & RSitem.Fields("ftData_Heading").Value
					gCriteria = gCriteria & " AND " & Replace(RSitem.Fields("ftData_SQL").Value, "[field]", rs.Fields("ftSet_Field").Value)
				End If
				RSitem.Close()
				rs.moveNext()
			Loop 
			gCriteria = Replace(gCriteria, "=", "<>")
			gCriteria = Replace(gCriteria, " OR ", " AND ")
		End If
		rs.Close()
		If gHeading <> "" Then gHeading = Mid(gHeading, 6)
		
	End Sub
    Public Function loadFilter(ByRef filter_Renamed As String) As Boolean
        Dim rs As New ADODB.Recordset
        Dim RSitem As New ADODB.Recordset
        Dim lCNT As Short
        rs = modRecordSet.getRS("SELECT * From ftOrderSet Where (((ftSet_Group) = 'order')) ORDER BY ftSet_Order;")
        If rs.BOF Or rs.EOF Then
            loadFilter = False
        Else
            lCNT = -1
            ReDim objectArray(rs.RecordCount - 1)
            Do Until rs.EOF
                lCNT = lCNT + 1
                Select Case rs.Fields("ftset_type").Value
                    Case 2

                        If lCNT Then
                            '_frmList_0.
                            'frmList.Load(lCNT)
                            'cmdList.Load(lCNT)
                            cmdList(lCNT).Parent = _frmList_0
                            'lblList.Load(lCNT)
                            _lblList_0.Parent = _frmList_0
                        End If

                        _frmList_0.Visible = True
                        _cmdList_0.Visible = True
                        _lblList_0.Visible = True
                        If lCNT Then _frmList_0.Top = twipsToPixels(lCNT * pixelToTwips(_frmList_0.Height, False) + pixelToTwips(_frmList_0.Top, False), False)
                        _frmList_0.Text = rs.Fields("ftset_DisplayName").Value
                        _frmList_0.Tag = rs.Fields("ftset_Name").Value
                        _lblList_0.Text = ""
                        RSitem = getRS("SELECT ftData_Heading From ftOrder WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(_frmList_0.Tag, "'", "''") & "')")
                        If RSitem.BOF Or RSitem.EOF Then
                        Else
                            _lblList_0.Text = RSitem.Fields("ftData_Heading").Value
                        End If

                        objectArray(lCNT) = _frmList_0

                End Select
                rs.MoveNext()
            Loop
           Me.Height = twipsToPixels(objectArray(UBound(objectArray)).Top + objectArray(UBound(objectArray)).Height + 1000, False)

            loadLanguage()
            ShowDialog()
            loadFilter = True
        End If
    End Function
    Private Sub cmdList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _cmdList_0.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdList)
        Dim rs As ADODB.Recordset
        If frmFilterOrderList.loadData(_frmList_0.Tag) Then
            _lblList_0.Text = ""
            rs = getRS("SELECT ftData_Heading From ftOrder WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(_frmList_0.Tag, "'", "''") & "')")
            If rs.BOF Or rs.EOF Then
            Else
                _lblList_0.Text = rs.Fields("ftData_Heading").Value
            End If
        End If
    End Sub
    Private Sub cmdList_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles _cmdList_0.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Dim Index As Short = cmdList.GetIndex(eventSender)
        If Shift = 4 And KeyCode = 88 Then
            Me.Close()
            KeyCode = 0
        End If
    End Sub
    Private Sub cmdList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _cmdList_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = cmdList.GetIndex(eventSender)
        If KeyAscii = 27 Then
            Me.Close()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	Private Sub save()
		Dim x As Short
		Dim lText As String
		For x = LBound(objectArray) To UBound(objectArray)
			Select Case objectArray(x).name
				Case "frmString"
			End Select
		Next 
	End Sub
	Private Sub frmFilterOrder_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		save()
	End Sub
    Private Sub txtString_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        If KeyAscii = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmFilterOrder_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cmdList.AddRange(New Button() {_cmdList_0})
    End Sub
End Class