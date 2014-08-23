Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmZeroise
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2487 'Zeroising Stock|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2488 'Please Enter the password to continue|checked
		If rsLang.RecordCount Then lblHeading.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblHeading.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490 'Password|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmZeroise.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	
	Private Sub frmZeroise_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
	End Sub
	
	Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim dtDate As String
		Dim dtMonth As String
		Dim stPass As String
		
		'Construct password...........
		If KeyAscii = 13 Then
			If Len(VB.Day(Today)) = 1 Then dtDate = "0" & Str(VB.Day(Today)) Else dtDate = Trim(Str(VB.Day(Today)))
			If Len(Month(Today)) = 1 Then dtMonth = "0" & Str(Month(Today)) Else dtMonth = Trim(Str(Month(Today)))
			
			'Create password
			stPass = dtDate & "##" & dtMonth
			stPass = Replace(stPass, " ", "")
			
			If Trim(txtPassword.Text) = stPass Then
				'ZeroiseStock
				Update_Handheld()
			Else
				MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords")
			End If
			
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Sub ZeroiseStock()
		Dim rj As ADODB.Recordset
		Dim rs As ADODB.Recordset
		
		rj = getRS("SELECT * FROM WarehouseStockItemLnk WHERE WarehouseStockItemLnk_WarehouseID > 0")
		
		If rj.RecordCount > 0 Then
			If MsgBox("You have " & rj.RecordCount & " entries in database. Do you want to make them Zero?", MsgBoxStyle.OKCancel) = MsgBoxResult.OK Then
				cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk_Quantity = 0 WHERE WarehouseStockItemLnk_WarehouseID > 0")
				MsgBox("Stock process has been completed.")
			End If
		Else
			MsgBox("You don't have any stock.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		End If
	End Sub
	
	
	Sub Update_Handheld()
        Dim gID As Integer
        Dim strFldName As String
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim adoPrimaryRS As ADODB.Recordset
		Dim sql As String
		Dim lQuantity As Decimal
		Dim rsWH As ADODB.Recordset
		On Error GoTo Err_Update_Handheld
		rs = getRS("SELECT * from StockItem;") 'Where (StockItem.StockItem_Disabled = False) And (StockItem.StockItem_Discontinued = False);")
		If rs.RecordCount > 0 Then
			If MsgBox("You have " & rs.RecordCount & " items in database. Do you want to make them Zero?", MsgBoxStyle.OKCancel) = MsgBoxResult.OK Then
errCreateAgain: 
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
				cnnDB.Execute("CREATE TABLE " & "Handheld777" & " (" & strFldName & ")")
				System.Windows.Forms.Application.DoEvents()
				Do While rs.EOF = False
					sql = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("StockItemID").Value & ", 0, 0)"
					'sql = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, 0 AS Barcode, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity AS quantity FROM WarehouseStockItemLnk WHERE ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2);"
					cnnDB.Execute(sql)
					rs.moveNext()
				Loop 
				
			Else
				Exit Sub
			End If
		Else
			MsgBox("You don't have any stock.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('Handheld777')")
		stTableName = "Handheld777"
		rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'Handheld777';")
		gID = rj.Fields("StockGroupID").Value
		
		'snap shot
		'cnnDB.Execute "UPDATE Company SET Company.Company_StockTakeDate = now();"
		'cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
		'cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
		'cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
		'cnnDB.Execute "DELETE FROM StockTakeDeposit"
		'cnnDB.Execute "INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);"
		'snap shot
		'NEW snap shot
		cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
		'Multi Warehouse change
		cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
		cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;")
		cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
		'Multi Warehouse change
		cnnDB.Execute("DELETE FROM StockTakeDeposit")
		cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
		'NEW snap shot
		
		rsWH = getRS("SELECT * from Warehouse;")
		If rsWH.RecordCount > 0 Then
			Do While rsWH.EOF = False
				adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & rsWH.Fields("WarehouseID").Value & ")) ORDER BY StockItem.StockItem_Name")
				If adoPrimaryRS.RecordCount > 0 Then
					Do While adoPrimaryRS.EOF = False
						lQuantity = adoPrimaryRS.Fields("Quantity").Value
                        lQuantity = adoPrimaryRS.Fields("Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue
						cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=" & rsWH.Fields("WarehouseID").Value & "));")
						'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
						cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=" & rsWH.Fields("WarehouseID").Value & "));")
						cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & rsWH.Fields("WarehouseID").Value & "));")
						adoPrimaryRS.moveNext()
					Loop 
				End If
				rsWH.moveNext()
			Loop 
		End If
		
		cnnDB.Execute("DROP TABLE Handheld777")
		cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='Handheld777'")
		
		MsgBox("Stock process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		
		Exit Sub
Err_Update_Handheld: 
		Debug.Print(Err.Description)
		If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Table 'Handheld777' already exists." Then
			cnnDB.Execute("DROP TABLE Handheld777")
			GoTo errCreateAgain
		ElseIf Err.Description = "Table 'Handheld777' already exists." Then 
			cnnDB.Execute("DROP TABLE Handheld777")
			GoTo errCreateAgain
		Else
			MsgBox(Err.Description)
		End If
	End Sub
End Class