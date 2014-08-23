Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCashTransactionItem
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gQuantity As Integer
    Dim chkChannel As New List(Of CheckBox)
	Private Sub loadLanguage()
		
		'frmCashTransactionItem = No Code   [Edit a Cash Transaction Item]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCashTransactionItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmCashTransactionItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2145 'Shrink Size|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_4 = No Code                   [This Cash Transaction does not apply to the following payment methods]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkType_0 = No Code               [Not Valid for Credit Card Payments]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkType_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkType_1 = No Code               [Not Valid for Debit Card Payments]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkType_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkType_2 = No Code               [Not Valid for Cheque Payments]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkType_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkType_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Note: _lbl_0 has a spelling mistake/grammar mistake in Caption!
		'_lbl_0 = No Code                   [Disable this Cash Transaction for the following checked Sale Channels]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkChannel(1) = No Code/Dynamic/NA?
		'chkChannel(2) = No Code/Dynamic/NA?
		'chkChannel(3) = No Code/Dynamic/NA?
		'chkChannel(4) = No Code/Dynamic/NA?
		'chkChannel(5) = No Code/Dynamic/NA?
		'chkChannel(6) = No Code/Dynamic/NA?
		'chkChannel(7) = No Code/Dynamic/NA?
		'chkChannel(8) = No Code/Dynamic/NA?
		'chkChannel(9) = No Code/Dynamic/NA?
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCashTransactionItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM Channel")
		Do Until rs.EOF
            chkChannel(rs.Fields("ChannelID").Value).Text = rs.Fields("ChannelID").Value & ". " & rs.Fields("Channel_Name").Value
			rs.moveNext()
		Loop 
		rs.Close()
		If gQuantity Then
			
			rs = getRS("SELECT CashTransaction.*, StockItem.StockItem_Name FROM CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID WHERE (((CashTransaction.CashTransaction_StockItemID)=" & gStockItemID & ") AND ((CashTransaction.CashTransaction_Shrink)=" & gQuantity & "));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				txtPrice.Text = CStr(rs.Fields("CashTransaction_Amount").Value * 100)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				cmbQuantity.Tag = gQuantity
				Me._chkType_0.CheckState = System.Math.Abs(CInt(CBool(rs.Fields("CashTransaction_type").Value And 1)))
				Me._chkType_1.CheckState = System.Math.Abs(CInt(CBool(rs.Fields("CashTransaction_type").Value And 2)))
				Me._chkType_2.CheckState = System.Math.Abs(CInt(CBool(rs.Fields("CashTransaction_type").Value And 4)))
                Me._chkChannel_1.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel1").Value)
                Me._chkChannel_2.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel2").Value)
                Me._chkChannel_3.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel3").Value)
                Me._chkChannel_4.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel4").Value)
                Me._chkChannel_5.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel5").Value)
                Me._chkChannel_6.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel6").Value)
                Me._chkChannel_7.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel7").Value)
                Me._chkChannel_8.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel8").Value)
                Me._chkChannel_9.CheckState = System.Math.Abs(rs.Fields("CashTransaction_Channel9").Value)
				
			Else
				Me.Close()
				Exit Sub
			End If
		Else
			rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				txtPrice.Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				cmbQuantity.Tag = rs.Fields("CatalogueChannelLnk_Quantity").Value
				Me._chkType_0.CheckState = System.Windows.Forms.CheckState.Checked
				Me._chkType_1.CheckState = System.Windows.Forms.CheckState.Checked
				Me._chkType_2.CheckState = System.Windows.Forms.CheckState.Checked
			Else
				Me.Close()
				Exit Sub
			End If
			
		End If
		rs = getRS("SELECT Catalogue.Catalogue_Quantity From Catalogue Where (((Catalogue.Catalogue_StockItemID) = " & gStockItemID & ") And ((Catalogue.Catalogue_Disabled) = 0)) ORDER BY Catalogue.Catalogue_Quantity;")
        cmbQuantity.Items.Clear()
        Dim m As Integer
		Do Until rs.EOF
            m = cmbQuantity.Items.Add(rs.Fields("Catalogue_Quantity").Value)
			If cmbQuantity.Tag = rs.Fields("Catalogue_Quantity").Value Then
                cmbQuantity.SelectedIndex = m
			End If
			rs.moveNext()
		Loop 
	End Sub
	Public Sub loadItem(ByRef stockitemID As Integer, ByRef quantity As Integer)
		gStockItemID = stockitemID
		gQuantity = quantity
		loadData()
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub frmCashTransactionItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
		If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub
		
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdCancel_Click()
        Dim mbDataChanged As Boolean
        Dim mvBookMark As Integer
        Dim adoPrimaryRS As ADODB.Recordset = New ADODB.Recordset
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
		On Error Resume Next
		If mbAddNewFlag Then
            Me.Close()
        Else
            mbEditFlag = False
            mbAddNewFlag = False
            adoPrimaryRS.CancelUpdate()
            If mvBookMark > 0 Then
                adoPrimaryRS.Bookmark = mvBookMark
            Else
                adoPrimaryRS.MoveFirst()
            End If
            mbDataChanged = False
        End If
	End Sub
	
	Private Function update_Renamed() As Boolean
        Dim sql As String
        On Error GoTo UpdateErr
        Dim lBit As Short
        update_Renamed = True
        cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" & gStockItemID & ") AND ((CashTransaction.CashTransaction_Shrink)=" & gQuantity & "));")
        cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" & gStockItemID & ") AND ((CashTransaction.CashTransaction_Shrink)=" & CStr(Me.cmbQuantity.SelectedIndex) & "));")
        If Me._chkType_0.CheckState Then lBit = lBit + 1
        If Me._chkType_1.CheckState Then lBit = lBit + 2
        If Me._chkType_2.CheckState Then lBit = lBit + 4

        cnnDB.Execute("INSERT INTO CashTransaction ( CashTransaction_StockItemID, CashTransaction_Shrink, CashTransaction_Amount, CashTransaction_Type, CashTransaction_Disabled, CashTransaction_Channel1, CashTransaction_Channel2, CashTransaction_Channel3, CashTransaction_Channel4, CashTransaction_Channel5, CashTransaction_Channel6, CashTransaction_Channel7, CashTransaction_Channel8, CashTransaction_Channel9 ) SELECT " & gStockItemID & ", " & CStr(Me.cmbQuantity.SelectedIndex) & ", " & CDec(Me.txtPrice.Text) & ", " & lBit & ", 0," & chkChannel(1).CheckState & ", " & chkChannel(2).CheckState & ", " & chkChannel(3).CheckState & ", " & chkChannel(4).CheckState & ", " & chkChannel(5).CheckState & ", " & chkChannel(6).CheckState & ", " & chkChannel(7).CheckState & ", " & chkChannel(8).CheckState & ", " & chkChannel(9).CheckState & ";")
        sql = "UPDATE (StockItem AS StockItem_1 INNER JOIN (CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID) ON StockItem_1.StockItem_PriceSetID = StockItem.StockItem_PriceSetID) INNER JOIN CashTransaction AS CashTransaction_1 ON (CashTransaction_1.CashTransaction_Shrink = CashTransaction.CashTransaction_Shrink) AND (StockItem_1.StockItemID = CashTransaction_1.CashTransaction_StockItemID) SET CashTransaction_1.CashTransaction_Amount = [CashTransaction]![CashTransaction_Amount], CashTransaction_1.CashTransaction_Type = [CashTransaction]![CashTransaction_Type], CashTransaction_1.CashTransaction_Disabled = [CashTransaction]![CashTransaction_Disabled], CashTransaction_1.CashTransaction_Channel1 = [CashTransaction]![CashTransaction_Channel1], CashTransaction_1.CashTransaction_Channel2 = [CashTransaction]![CashTransaction_Channel2], CashTransaction_1.CashTransaction_Channel3 = [CashTransaction]![CashTransaction_Channel3], "
        sql = sql & " CashTransaction_1.CashTransaction_Channel4 = [CashTransaction]![CashTransaction_Channel4], CashTransaction_1.CashTransaction_Channel5 = [CashTransaction]![CashTransaction_Channel5], CashTransaction_1.CashTransaction_Channel6 = [CashTransaction]![CashTransaction_Channel6], CashTransaction_1.CashTransaction_Channel7 = [CashTransaction]![CashTransaction_Channel7], CashTransaction_1.CashTransaction_Channel8 = [CashTransaction]![CashTransaction_Channel8], CashTransaction_1.CashTransaction_Channel9 = [CashTransaction]![CashTransaction_Channel9] "
        sql = sql & " WHERE (((CashTransaction.CashTransaction_StockItemID)=" & gStockItemID & ") AND ((CashTransaction_1.CashTransaction_StockItemID)<>" & gStockItemID & ") AND ((StockItem_1.StockItem_PriceSetID)<>0));"
        cnnDB.Execute(sql)

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        update_Renamed = True
    End Function
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
	Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Enter
		MyGotFocusNumeric(txtPrice)
	End Sub
	
	Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		MyKeyPressNegative(txtPrice, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Leave
		MyLostFocus(txtPrice, 2)
	End Sub

    Private Sub frmCashTransactionItem_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        chkChannel.AddRange(New CheckBox() {_chkChannel_1, _chkChannel_2, _chkChannel_3, _
                                           _chkChannel_4, _chkChannel_5, _chkChannel_6, _
                                           _chkChannel_7, _chkChannel_8, _chkChannel_9})
    End Sub
End Class