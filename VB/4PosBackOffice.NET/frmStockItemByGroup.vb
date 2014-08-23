Option Strict Off
Option Explicit On
Friend Class frmStockItemByGroup
	Inherits System.Windows.Forms.Form
	Dim p_irc As Integer
	Dim p_MenuID As Integer
	Dim parentMID As Integer
	Dim p_OrderM As Integer
	Dim tprod_M As Boolean
	Dim bt_Vertical As Boolean
	
	Private Sub loadLanguage()
		
		'Picture1 CONTAINS IMAGE WITH TEXT - CONVERT TO LABEL!
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code   [Press (A) To Select All Products]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockItemByGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub lstStockItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStockItem.Enter
		'If lstStockItem.ListCount Then Else txtSearchIt.SetFocus
	End Sub
	Private Sub lstStockItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstStockItem.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub doKeyPress(ByRef KeyAscii As Short)
        Dim lc As Integer
        Dim x As Short
        Select Case KeyAscii
            Case 27
                KeyAscii = 0
                Me.Close()
            Case 13
                KeyAscii = 0

                If lstStockItem.SelectedIndex <> -1 Then
                    lc = CountSelected(lstStockItem.Items.Count)
                    If lc > 0 Then
                        If MsgBox("Changes you are about to make will affect : " & lc & " record(s), Do you want to continue?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.YesNo, "4POS Global Update") = MsgBoxResult.Yes Then
                            cnnDB.Execute("DELETE * FROM gGlobalUpdate;")
                            For x = 0 To lstStockItem.Items.Count - 1
                                If lstStockItem.GetSelected(x) = True Then
                                    cnnDB.Execute("INSERT INTO gGlobalUpdate(gStockItemID) VALUES (" & GetItemData(lstStockItem, x) & ")")
                                End If
                            Next
                        Else
                            cnnDB.Execute("DELETE * FROM gGlobalUpdate;")
                            Me.Close()
                        End If
                    Else
                        cnnDB.Execute("DELETE * FROM gGlobalUpdate;")
                    End If
                End If
                Me.Close()

            Case 65, 97
                For x = 0 To lstStockItem.Items.Count - 1
                    lstStockItem.SetSelected(x, True)
                Next
        End Select

    End Sub
	Private Function CountSelected(ByRef lstCount As Short) As Short
		Dim x As Short
		Dim y As Short
		
		For y = 0 To lstCount - 1
			If lstStockItem.GetSelected(y) Then x = x + 1
		Next 
		CountSelected = x
	End Function
	Private Sub doSearch(ByRef sq1 As String)
        Dim rs As ADODB.Recordset

        rs = getRS(sq1)
        Do While rs.EOF = False
            lstStockItem.Items.Add(New LBI(rs.Fields("StockItem_Name").Value, rs.Fields("StockItemID").Value))
            rs.MoveNext()
        Loop

    End Sub
	Public Sub loadItem(ByRef sql As String)
		doSearch(sql)
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
End Class