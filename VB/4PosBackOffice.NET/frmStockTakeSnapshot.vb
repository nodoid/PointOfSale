Option Strict Off
Option Explicit On
Friend Class frmStockTakeSnapshot
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1215 'Stock Take Snapshot|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblInstruction = No Code   [The "Create Theoretical Stock Take Snapshot" process.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblInstruction.Caption = rsLang("LanguageLayoutLnk_Description"): lblInstruction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl = No Code              [Please note that.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl.Caption = rsLang("LanguageLayoutLnk_Description"): lbl.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1217 'Proceed|Checked
		If rsLang.RecordCount Then cmdProceed.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdProceed.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTakeSnapshot.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub remoteSnapShot()
		Timer1.Enabled = True
		ShowDialog()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdProceed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProceed.Click
		Me.cmdExit.Enabled = False
		Me.cmdProceed.Visible = False
		lblInstruction.Text = "Busy updating ..." & vbCrLf & vbCrLf & "Please be patient."
		lbl.Visible = False
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
		'Multi Warehouse change
		'cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
		'cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
		'cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
		cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
		'changed below 2 lines for StockTake Print Difference
		cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_QuantityOrig ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment, 0 AS quantityOrig FROM WarehouseStockItemLnk;")
		cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity], StockTake.StockTake_QuantityOrig = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
		'Multi Warehouse change
		' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
		cnnDB.Execute("DELETE FROM StockTakeDeposit")
		cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
		lblInstruction.Text = "Your 'Theoretical Stock Snapshot' has been created."
		Me.cmdExit.Enabled = True
		cmdExit.Focus()
	End Sub
	Private Sub frmStockTakeSnapshot_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockTakeSnapshot_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		Timer1.Enabled = False
		System.Windows.Forms.Application.DoEvents()
		
		Me.cmdExit.Enabled = False
		Me.cmdProceed.Visible = False
		lblInstruction.Text = "Busy updating ..." & vbCrLf & vbCrLf & "Please be patient."
		lbl.Visible = False
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
		'Multi Warehouse change
		'cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
		'cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
		'cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
		cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
		'changed below 2 lines for StockTake Print Difference
		cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_QuantityOrig ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment, 0 AS quantityOrig FROM WarehouseStockItemLnk;")
		cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity], StockTake.StockTake_QuantityOrig = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
		'Multi Warehouse change
		' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
		cnnDB.Execute("DELETE FROM StockTakeDeposit")
		cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
		lblInstruction.Text = "Your 'Theoretical Stock Snapshot' has been created."
		Me.cmdExit.Enabled = True
		cmdExit.Focus()
		
		Me.Close()
	End Sub
End Class