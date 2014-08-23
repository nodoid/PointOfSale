Option Strict Off
Option Explicit On
Friend Class frmGRVTemplate
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmGRVTemplate = No Code   [GRV Template Editor]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmGRVTemplate.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVTemplate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1459 'GRV Template|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_1 = No Code           [Available Columns]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code           [GRV Columns]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdUp = No Code            [Up]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdUp.Caption = rsLang("LanguageLayoutLnk_Description"): cmdUp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdDown = No Code          [Down]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdDown.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDown.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVTemplate.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub reorder()
        Dim x As Short
		For x = 0 To lstItem.Items.Count - 1
            cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & x + 1 & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & GetItemData(lstItem, x) & "));")
			
		Next 
		
	End Sub
	
	Private Sub cmbTemplate_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTemplate.SelectedIndexChanged
		Dim rs As ADODB.Recordset
        rs = getRS("SELECT GRVTemplateList.GRVTemplateListID, GRVTemplateList.GRVTemplateList_Name FROM GRVTemplateItem INNER JOIN GRVTemplateList ON GRVTemplateItem.GRVTemplateItem_GRVTemplateListID = GRVTemplateList.GRVTemplateListID Where (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID) = " & CInt(cmbTemplate.SelectedIndex) & ")) ORDER BY GRVTemplateItem.GRVTemplateItem_Order;")
		lstItem.Items.Clear()
		Do Until rs.EOF
            lstItem.Items.Add(New LBI(rs.Fields("GRVTemplateList_Name").Value, rs.Fields("GRVTemplateListID").Value))
			rs.moveNext()
		Loop 
	End Sub
	
	
	Private Sub doAction(ByRef ltype As Boolean)
		Dim x As Short
		If ltype Then
            cnnDB.Execute("DELETE GRVTemplateItem.GRVTemplateItem_GRVTemplateID, GRVTemplateItem.GRVTemplateItem_GRVTemplateListID From GRVTemplateItem WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & GetItemData(cmbTemplate, cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & CInt(lstItem.SelectedIndex) & "));")
		Else
			For x = 0 To lstItem.Items.Count - 1
                If GetItemData(lstItem, x) = CInt(lstTemplate.SelectedIndex) Then
                    lstItem.SelectedIndex = x
                    Exit Sub
                End If
			Next x
            cnnDB.Execute("INSERT INTO GRVTemplateItem ( GRVTemplateItem_GRVTemplateID, GRVTemplateItem_GRVTemplateListID, GRVTemplateItem_Order ) VALUES (" & CInt(cmbTemplate.SelectedIndex) & ", " & GetItemData(lstTemplate, lstTemplate.SelectedIndex) & ", " & lstItem.Items.Count + 1 & ");")
		End If
		reorder()
		cmbTemplate_SelectedIndexChanged(cmbTemplate, New System.EventArgs())
	End Sub
	
	Private Sub cmdDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDown.Click
		Dim x As Short
		Dim id As Integer
		If lstItem.SelectedIndex <> -1 Then
			If lstItem.SelectedIndex <> lstItem.Items.Count - 1 Then
                id = CInt(lstItem.SelectedIndex)
                cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & lstItem.SelectedIndex + 2 & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & CInt(lstItem.SelectedIndex) & "));")
                cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & lstItem.SelectedIndex + 1 & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & CInt(lstItem.SelectedIndex + 1) & "));")
				cmbTemplate_SelectedIndexChanged(cmbTemplate, New System.EventArgs())
				For x = 0 To lstItem.Items.Count - 1
                    If GetItemData(lstItem, x) = id Then
                        lstItem.SelectedIndex = x
                        lstItem.Focus()
                        Exit For
                    End If
				Next 
			End If
		End If
		
	End Sub
	
	Private Sub cmdUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUp.Click
		Dim x As Short
		Dim id As Integer
		If lstItem.SelectedIndex > 0 Then
            id = CInt(lstItem.SelectedIndex)
            cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & lstItem.SelectedIndex + 1 & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & CInt(lstItem.SelectedIndex - 1) & "));")
            cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & lstItem.SelectedIndex & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & CInt(lstItem.SelectedIndex) & "));")
			For x = lstItem.SelectedIndex + 1 To lstItem.Items.Count - 1
                cnnDB.Execute("UPDATE GRVTemplateItem SET GRVTemplateItem.GRVTemplateItem_Order = " & x + 1 & " WHERE (((GRVTemplateItem.GRVTemplateItem_GRVTemplateID)=" & CInt(cmbTemplate.SelectedIndex) & ") AND ((GRVTemplateItem.GRVTemplateItem_GRVTemplateListID)=" & GetItemData(lstItem, x) & "));")
			Next x
			cmbTemplate_SelectedIndexChanged(cmbTemplate, New System.EventArgs())
			For x = 0 To lstItem.Items.Count - 1
                If GetItemData(lstItem, x) = id Then
                    lstItem.SelectedIndex = x
                    lstItem.Focus()
                    Exit For
                End If
			Next 
		End If
	End Sub
	
	
	Private Sub frmGRVTemplate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmGRVTemplate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT GRVTemplate.* From GRVTemplate ORDER BY GRVTemplate.GRVTemplate_Name;")
		Do Until rs.EOF
            cmbTemplate.Items.Add(New LBI(rs.Fields("GRVTemplate_Name").Value, rs.Fields("GRVTemplateID").Value))
			rs.moveNext()
		Loop 
		cmbTemplate.SelectedIndex = 0
		
		loadLanguage()
		
		rs = getRS("SELECT GRVTemplateList.* From GRVTemplateList ORDER BY GRVTemplateList.GRVTemplateListID;")
		Do Until rs.EOF
            lstTemplate.Items.Add(New LBI(rs.Fields("GRVTemplateList_Name").Value, rs.Fields("GRVTemplateListID").Value))
			rs.moveNext()
		Loop 
	End Sub
	
	Private Sub lstItem_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstItem.DoubleClick
		doAction(1)
	End Sub
	
	
	
	Private Sub lstTemplate_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstTemplate.DoubleClick
		doAction(0)
	End Sub
End Class