Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmVegTestStockBack
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Decimal
	Dim WHFromA As Integer
	Dim WHToB As Integer
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		
		rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" & gStockItemID & "));")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
			txtQty.Text = FormatNumber(gQuantity, 4)
			txtPrice.Text = FormatNumber(gQuantity * IIf(rs.Fields("PackSize_Volume").Value = 0, 1, rs.Fields("PackSize_Volume").Value), 2)
            Me.Height = twipsToPixels(4785, False)
			ShowDialog()
		End If

	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Decimal = 0, Optional ByRef WHFrom As Integer = 0, Optional ByRef WHTo As Integer = 0)
		gStockItemID = stockitemID
		'gPromotionID = promotionID
		gQuantity = quantity
		'WHFromA = WHFrom
		'WHToB = WHTo
		'lblPComp.Caption = frmStockTransferWH.lblWHA.Caption
		loadData()
		
		'show 1
		
	End Sub
	
	
	
	Private Sub cmdSelectChild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectChild.Click
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = 0
		lID = frmStockList.getItem
		If lID <> 0 Then
			rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" & lID & "));")
			If rs.RecordCount Then
				lblStockItemB.Text = rs.Fields("StockItem_Name").Value
				lblStockItemB.Tag = rs.Fields("StockItemID").Value
				txtQtyB.Text = FormatNumber(CDec(txtPrice.Text) / IIf(rs.Fields("PackSize_Volume").Value = 0, 1, rs.Fields("PackSize_Volume").Value), 2)
				txtPriceB.Text = FormatNumber(txtPrice.Text, 4)
			Else
				'    MsgBox "Insufficient Qty!"
				'    Exit Sub
			End If
			'
		End If
	End Sub
	
	Private Sub frmVegTestStockBack_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		'If mbAddNewFlag Then
		Me.Close()
		'Else
		'mbEditFlag = False
		'mbAddNewFlag = False
		'adoPrimaryRS.CancelUpdate
		'If mvBookMark > 0 Then
		'    adoPrimaryRS.Bookmark = mvBookMark
		'Else
		'    adoPrimaryRS.MoveFirst
		'End If
		'mbDataChanged = False
		'End If
	End Sub
	
	Private Sub ChkHandheldWHTransfer()
		Dim rs As ADODB.Recordset
		Dim strFldName As String
		
ChkTransTable: 
		
		On Error GoTo Err_ChkTransTable
		rs = getRS("SELECT * FROM HandheldVegReceive;")
		If rs.RecordCount Then
		End If
		
		Exit Sub
Err_ChkTransTable: 
		If Err.Number = -2147217865 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldVegReceive'.  Make sure it exists and that its name is spelled correctly." Then
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
			cnnDB.Execute("CREATE TABLE HandheldVegReceive (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			rs = getRS("SELECT * FROM HandheldVegReceive;")
			If rs.RecordCount Then
			End If
			
			GoTo ChkTransTable
		End If
		
	End Sub
	
	Private Function update_Renamed() As Boolean
        Dim gID As Integer
        Dim rj As ADODB.Recordset
        Dim RSadoPrimary As ADODB.Recordset
        Dim sql As String
        Dim lQuantity As Decimal

        On Error GoTo UpdateErr

        ChkHandheldWHTransfer()
        cnnDB.Execute("DELETE * FROM HandheldVegReceive;")

        sql = "INSERT INTO HandheldVegReceive (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - CDec(txtQty.Text)) & ")"
        cnnDB.Execute(sql)
        System.Windows.Forms.Application.DoEvents()

        sql = "INSERT INTO HandheldVegReceive (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & CInt(lblStockItemB.Tag) & ", 0, " & CDec(txtQtyB.Text) & ")"
        cnnDB.Execute(sql)
        System.Windows.Forms.Application.DoEvents()

        '---------------------------------------------
        cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegReceive')")
        stTableName = "HandheldVegReceive"
        rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegReceive';")
        gID = rj.Fields("StockGroupID").Value

        'snap shot
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        'Multi Warehouse change
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
        'Multi Warehouse change
        ' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        'snap shot

        RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
        If RSadoPrimary.RecordCount > 0 Then
            Do While RSadoPrimary.EOF = False
                lQuantity = RSadoPrimary.Fields("Quantity").Value
                cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & "));")
                RSadoPrimary.MoveNext()
            Loop
        End If

        cnnDB.Execute("DROP TABLE HandheldVegReceive;")
        cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegReceive';")

        MsgBox("Receiving Stock for Veg Production has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)

        update_Renamed = True
        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        update_Renamed = True

    End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If CDec(txtQty.Text) > 0 Then
		Else
			MsgBox("Insufficient Qty!")
			Exit Sub
		End If
		
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
	
	Private Sub txtPriceS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPriceS.Enter
        MyGotFocusNumeric(txtPriceS)
	End Sub
	
	Private Sub txtPriceS_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPriceS.Leave
        MyLostFocus(txtPriceS, 2)
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case Asc(vbCr)
				KeyAscii = 0
			Case 8
			Case 48 To 57
				
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQty_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Enter
		'MyGotFocusNumeric txtQty
		txtQty.SelectionStart = 0
		txtQty.SelectionLength = Len(txtQty.Text)
	End Sub
	
	Private Sub txtQty_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Leave
		' LostFocus txtQty, 2
	End Sub
End Class