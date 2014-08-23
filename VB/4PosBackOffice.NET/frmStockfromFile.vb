Option Strict Off
Option Explicit On
Friend Class frmStockfromFile
	Inherits System.Windows.Forms.Form
	Dim stBarcode As String
	Dim slProd As Short
	Dim gBrandItem As Integer
	Dim gStockItem As Integer
	Const mdProducts As Short = 0
	Const mdDetails As Short = 1
	Const mdBarcodes As Short = 3
	Const mdCustomDetails As Short = 2
	Const mdFinish As Short = 4
	Dim gSystem As Short
    Dim gMode As Short
	
	Private Sub loadLanguage()
		
		'frmStockfromFile = No Code     [Adding Stock Items]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockfromFile.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockfromFile.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdNext = No Code              [Do Update]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code               [File Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockfromFile.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub doMode(ByRef mode As Short)
        Dim rs As ADODB.Recordset
        Dim rsC As ADODB.Recordset
        gMode = mode
        Dim fso As New Scripting.FileSystemObject
        Dim lStringRecord As String
        Dim x As Integer

        'stBarcode = ""
        'If txtFile.Text = "" Then
        '    MsgBox "Please Upload the file to load data from", vbApplicationModal + vbInformation + vbOKOnly, App.title
        '   Exit Sub
        'Else
        System.Windows.Forms.Application.DoEvents()

        '    Set TS = FSO.OpenTextFile(CommonDialog1.FileName)
        '    If TS Is Nothing Then
        '       Else
        '           If TS.AtEndOfStream Then
        '                MsgBox CommonDialog1.FileName & " is an Empty file!", vbExclamation, "FILE ERROR"
        '                Exit Sub
        '           Else
        '             X = 0
        '               Do Until TS.AtEndOfStream
        '
        '
        '
        '                  lStringRecord = TS.ReadLine
        '
        '                  k = Len(lStringRecord) - Len(Right(lStringRecord, Len(lStringRecord) - InStr(lStringRecord, ",")))


        '                  lStringRecord = Mid$(lStringRecord, 1, k - 1)

        rs = getRS("SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItem LEFT OUTER JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID WHERE (StockItem.StockItemID IS NULL) ORDER BY BrandItem.BrandItem_Name")



        'Set rsC = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode ='" & lStringRecord & "'")

        Do While rs.EOF = False

            'If rs.RecordCount > 0 Then

            'Else
            'Set rs = getRS("SELECT * FROM BrandItem,BrandItemQuantity WHERE BrandItem.BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID AND BrandItemQuantity_Barcode = '" & lStringRecord & "'")
            rsC = getRS("SELECT * FROM BrandItem,BrandItemQuantity WHERE BrandItem.BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID AND BrandItemQuantity_BrandItemID = " & rs.Fields("BrandItemID").Value & "")

            If rsC.RecordCount Then
                x = x + 1
                gBrandItem = rsC.Fields("BrandItemID").Value
                txtName.Text = rsC.Fields("BrandItem_Name").Value
                txtReceipt.Text = rsC.Fields("BrandItem_ReceiptName").Value
                createProduct()
            Else
                x = x + 1
                stBarcode = lStringRecord
                txtName.Text = "[New Product]"
                txtReceipt.Text = "[New Product]"
                createProduct()

            End If

            'End If

            rs.MoveNext()
        Loop

        '      End If
        '    End If
        '   Label2.Caption = "Number Of Record Added :" & Str(X)
        'End If

    End Sub
	Private Sub cboBarcode_Click()
        _frmMode_1.Enabled = True
		
	End Sub
	
    Private Sub cmbDeposit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbDeposit.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
	
    Private Sub cmbPricingGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbPricingGroup.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbShrink_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbShrink.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyChar = ChrW(0)
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbStockGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbStockGroup.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyChar = ChrW(0)
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbSupplier_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbSupplier.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyChar = ChrW(0)
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If

    End Sub
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Me.Close()
	End Sub
	
	Private Sub cmdCustom_Click()
		loadCustom()
	End Sub
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		doMode(mdProducts)
		System.Windows.Forms.Application.DoEvents()
		cmdnext.Focus()
		System.Windows.Forms.Application.DoEvents()
		
	End Sub
	Private Sub createProduct()
		Dim rs As ADODB.Recordset
		Dim sql As String
		If txtName.Text = "" Then
			MsgBox("Product Name is a required field", MsgBoxStyle.Exclamation, Me.Text)
			txtName.Focus()
			Exit Sub
		End If
		If txtReceipt.Text = "" Then
			MsgBox("Receipt Name is a required field", MsgBoxStyle.Exclamation, Me.Text)
			txtReceipt.Focus()
			Exit Sub
		End If
		
		txtQuantity.Text = "1"
		
		txtCost.Text = "1"
		
		If cmbSupplier.BoundText = "" Or cmbShrink.BoundText = "" Or cmbPricingGroup.BoundText = "" Or cmbStockGroup.BoundText = "" Or cmbDeposit.BoundText = "" Then
			MsgBox("Please enter all the required information", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		
		sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey) VALUES ("
		sql = sql & gBrandItem & ", " & cmbSupplier.BoundText & ", " & cmbShrink.BoundText & ", " & cmbPricingGroup.BoundText & ", " & cmbStockGroup.BoundText & ", 2, " & cmbDeposit.BoundText & ", '" & Replace(txtName.Text, "'", "''") & "', '" & Replace(txtReceipt.Text, "'", "''") & "', " & Replace(txtQuantity.Text, ",", "") & ", " & Replace(txtCost.Text, ",", "") & ", " & Replace(txtCost.Text, ",", "") & ", 0, 0, " & txtQuantity.Text & ", 1, 0, 0, 0, '')"
		
		cnnDB.Execute(sql)
		
		sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;"
		rs = getRS(sql)
		gStockItem = rs.Fields("id").Value
		cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CDec(txtCost.Text) / CDec(txtQuantity.Text) & ", " & CDec(txtCost.Text) / CDec(txtQuantity.Text) & " FROM Company;")
		cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " & gStockItem & ", 0 FROM Warehouse;")
		
		cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" & gStockItem & ")")
        Dim update As New frmUpdateCatalogue
        update.Show()

		buildBarcodes(gStockItem)
		
		If gBrandItem Then
			cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		Else
			cnnDB.Execute("UPDATE StockItem INNER JOIN Catalogue ON StockItem.StockItemID=Catalogue.Catalogue_StockItemID SET Catalogue.Catalogue_Barcode = '" & stBarcode & "' WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
			
		End If
		
		gStockItem = 0
		gBrandItem = 0
		
	End Sub
	Private Sub frmStockfromFile_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdBack_Click(cmdBack, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmStockfromFile_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim gStockItemID As Object
		Dim gBrandItemID As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object gBrandItemID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gBrandItemID = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object gStockItemID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gStockItemID = 0
		
		loadLanguage()
		buildDataControls()
		loadCustom()
		System.Windows.Forms.Application.DoEvents()
		'Me.CommonDialog1.FileName = ""
		'Me.CommonDialog1.ShowOpen
		
		'txtFile.Text = CommonDialog1.FileName
		
		
	End Sub
	
	Private Sub loadCustom()
		Dim gStockItemID As Object
		Dim gBrandItemID As Object
		gMode = 1
		gBrandItemID = 0
		gStockItemID = 0
		txtName.Enabled = True
		txtReceipt.Enabled = True
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbShrink.BoundText = rs.Fields("Default_ShrinkID").Value
			cmbSupplier.BoundText = rs.Fields("Default_SupplierID").Value
			cmbDeposit.BoundText = rs.Fields("Default_DepositID").Value
			cmbStockGroup.BoundText = rs.Fields("Default_StockGroupID").Value
			cmbPricingGroup.BoundText = CStr(163)
			
		Else
			cmbShrink.BoundText = CStr(12)
			cmbSupplier.BoundText = CStr(4)
			cmbDeposit.BoundText = CStr(0)
			cmbStockGroup.BoundText = CStr(1)
			cmbPricingGroup.BoundText = CStr(1)
		End If
		
		
	End Sub
	Private Sub buildDataControls()
		doDataControl((Me.cmbShrink), "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", "StockItem_ShrinkID", "ShrinkID", "Shrink_Name")
		doDataControl((Me.cmbPricingGroup), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
		doDataControl((Me.cmbSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
		doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", "StockItem_DepositID", "DepositID", "Deposit_Name")
		doDataControl((Me.cmbStockGroup), "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name")
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.DataSource = rs
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.listField = listField
    End Sub
	
	Private Sub txtName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Enter
        MyGotFocus(txtName)
    End Sub

    Private Sub txtName_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Leave
        If txtReceipt.Text = "" Then
            txtReceipt.Text = txtName.Text
        End If
    End Sub

    Private Sub txtReceipt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtReceipt.Enter
        MyGotFocus(txtReceipt)
    End Sub
	
	Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumeric(txtQuantity)
	End Sub
	
    Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocus(txtQuantity, 0)
    End Sub

    Private Sub txtCost_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCost.Enter
        MyGotFocusNumeric(txtCost)
    End Sub

    Private Sub txtCost_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCost.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
	Private Sub txtCost_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCost.Leave
        MyLostFocus(txtCost, 2)
	End Sub
End Class