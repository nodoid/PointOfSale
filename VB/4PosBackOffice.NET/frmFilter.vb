Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmFilter
	Inherits System.Windows.Forms.Form
	Dim objectArray() As Object
	Public gCriteria As String
    Public gHeading As String
    Dim cmdList As New List(Of Button)
    Dim frmList As New List(Of GroupBox)
    Dim frmString As New List(Of GroupBox)
    Dim lblList As New List(Of Label)
    Dim txtString As New List(Of TextBox)
	
	Private Sub loadLanguage()
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2133 'Edit Selection Criteria|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1393 'Clear All|Checked
		If rsLang.RecordCount Then cmdClear.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClear.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmList(0) = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2136 'Build|Checked
        If rsLang.RecordCount Then _cmdList_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdList_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmString(0) = No Code/Dynamic/NA?
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub buildCriteria(ByRef filter_Renamed As String)
		Dim rs As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		gHeading = ""
		gCriteria = ""
		On Error Resume Next
		rs = modRecordSet.getRS("SELECT ftSet.* From ftSet Where (((ftSet.ftSet_Group) = '" & Replace(filter_Renamed, "'", "''") & "')) ORDER BY ftSet.ftSet_Order;")
		If rs.BOF Or rs.EOF Then
		Else
			Do Until rs.EOF
				RSitem = getRS("SELECT * From ftData WHERE (((ftData.ftData_PersonID)=" & gPersonID & ") AND ((ftData.ftData_FieldName)='" & Replace(rs.Fields("ftSet_Name").Value, "'", "''") & "'));")
				
				If RSitem.BOF Or RSitem.EOF Then
				Else
					gHeading = gHeading & " AND " & RSitem.Fields("ftData_Heading").Value
					gCriteria = gCriteria & " AND " & Replace(RSitem.Fields("ftData_SQL").Value, "[field]", rs.Fields("ftSet_Field").Value)
				End If
				RSitem.Close()
				rs.moveNext()
			Loop 
		End If
		rs.Close()
				
		If VB.Left(gCriteria, 5) = " AND " Then gCriteria = Mid(gCriteria, 6)
		If gCriteria <> "" Then gCriteria = " WHERE " & gCriteria
		If gHeading <> "" Then gHeading = Mid(gHeading, 6)
		
		'New code
		
	End Sub
	
    Public Function loadFilter(ByRef filter_Renamed As String) As Boolean
        Dim modGeneral As Object
        Dim lDOM As Object
        Dim lNode As Object
        Dim rs As New ADODB.Recordset
        Dim RSitem As New ADODB.Recordset
        Dim lCNT As Short
        rs = modRecordSet.getRS("SELECT ftSet.* From ftSet Where (((ftSet.ftSet_Group) = '" & Replace(filter_Renamed, "'", "''") & "')) ORDER BY ftSet.ftSet_Order;")

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
                            Me.Controls.Add(_frmList_0)
                            '_frmList_0.Controls.Add(lCNT)
                            '_cmdList_0.Load(lCNT)
                            cmdList(lCNT).Parent = frmList(lCNT)
                            'lblList.Load(lCNT)
                            lblList(lCNT).Parent = frmList(lCNT)
                        End If
                        frmList(lCNT).Visible = True
                        cmdList(lCNT).Visible = True
                        lblList(lCNT).Visible = True
                        frmList(lCNT).Top = twipsToPixels(pixelToTwips(frmList(0).Top, False) + lCNT * _
                                                         pixelToTwips(frmList(0).Height, False), False)
                        frmList(lCNT).Text = rs.Fields("ftset_DisplayName").Value
                        frmList(lCNT).Tag = rs.Fields("ftset_Name").Value
                        lblList(lCNT).Text = ""
                        RSitem = getRS("SELECT ftData_Heading From ftData WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(frmList(lCNT).Tag, "'", "''") & "')")
                        If RSitem.BOF Or RSitem.EOF Then
                        Else
                            lblList(lCNT).Text = RSitem.Fields("ftData_Heading").Value
                        End If
                        objectArray(lCNT) = frmList(lCNT)
                    Case 1
                        If lCNT Then
                            'frmString.Load(lCNT)
                            'txtString.Load(lCNT)
                            _txtString_0.Parent = frmString(lCNT)
                        End If
                        _frmString_0.Visible = True
                        _txtString_0.Visible = True
                        _frmString_0.Top = twipsToPixels(pixelToTwips(frmList(0).Top, False) + lCNT * pixelToTwips(frmList(0).Height, False), False)
                        _frmString_0.Text = lNode.selectSingleNode("@name").Text
                        _frmString_0.Tag = lNode.selectSingleNode("@id").Text
                        _txtString_0.Text = ""
                        lDOM = modGeneral.lsData.sql("SELECT ftData_Data From ftData WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(frmString(lCNT).Tag, "'", "''") & "')")
                        If lDOM Is Nothing Then
                        Else
                            If lDOM.documentElement.selectSingleNode("/root/ftData/@ftData_Data") Is Nothing Then
                            Else
                                _txtString_0.Text = lDOM.documentElement.selectSingleNode("/root/ftData/@ftData_Data").Text
                            End If
                        End If
                        _txtString_0.Tag = _txtString_0.Text
                        objectArray(lCNT) = _frmString_0
                End Select
                rs.MoveNext()
            Loop
            Me.Height = twipsToPixels(objectArray(UBound(objectArray)).Top + _
                                              objectArray(UBound(objectArray)).Height + 1000, False)

            loadLanguage()
            ShowDialog()
            'UPGRADE_WARNING: Couldn't resolve default property of object loadFilter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            loadFilter = True
        End If

    End Function
	
	Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClear.Click
		cnnDB.Execute("DELETE ftData.* From ftData")
		cnnDB.Execute("DELETE ftDataItem.* From ftDataItem")
		Me.Close()
	End Sub
	
    Private Sub cmdList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _cmdList_0.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdList)
        Dim rs As ADODB.Recordset
        If frmFilterList.loadData(frmList(Index).Tag) Then
            lblList(Index).Text = ""
            rs = getRS("SELECT ftData_Heading From ftData WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(frmList(Index).Tag, "'", "''") & "')")
            If rs.BOF Or rs.EOF Then
            Else
                lblList(Index).Text = rs.Fields("ftData_Heading").Value
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
					If txtString(x).Tag <> txtString(x).Text Then
						cnnDB.Execute("DELETE FROM ftData WHERE (ftData_PersonID = " & gPersonID & ") AND (ftData_FieldName = '" & Replace(frmString(x).Tag, "'", "''") & "')")
						If Trim(txtString(x).Text) <> "" Then
							lText = "[field] LIKE ''%25" & Replace(txtString(x).Text, " ", "%25'' AND [field] LIKE ''%25") & "%25''"
							cnnDB.Execute("INSERT INTO ftData (ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading, ftData_Data) VALUES (" & gPersonID & ", '" & Replace(frmString(x).Tag, "'", "''") & "', '(" & lText & ")', '(" & frmString(x).Text & " = " & txtString(x).Text & ")', '" & Replace(txtString(x).Text, "'", "''") & "')")
						End If
					End If
			End Select
		Next 
	End Sub
	Private Sub frmFilter_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		save()
	End Sub
	
    Private Sub txtString_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtString_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtString.GetIndex(eventSender)
        If KeyAscii = 27 Then
            Me.Close()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmFilter_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cmdList.AddRange(New Button() {_cmdList_0})
        frmList.AddRange(New GroupBox() {_frmList_0})
        frmString.AddRange(New GroupBox() {_frmString_0})
        lblList.AddRange(New Label() {_lblList_0})
        txtString.AddRange(New TextBox() {_txtString_0})
    End Sub
End Class