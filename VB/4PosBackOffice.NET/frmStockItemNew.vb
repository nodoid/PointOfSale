Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStockItemNew
	Inherits System.Windows.Forms.Form
	Dim gBrandItem As Integer
	Dim gStockItem As Integer
	Const mdProducts As Short = 0
	Const mdDetails As Short = 1
	Const mdBarcodes As Short = 3
	Const mdCustomDetails As Short = 2
	Const mdFinish As Short = 4
	Dim gSystem As Short
	Dim gMode As Short
    Dim frmMode As New List(Of GroupBox)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1668 'New Stock Item|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 1001 needs Double Quotations
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1001 'Select the product for the new stock item|Checked
        If rsLang.RecordCount Then _frmMode_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _frmMode_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
        If rsLang.RecordCount Then _lbl_35.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_35.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: Full label not matching DB entry 1002 as it requires a count(er) attached to it!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1002
		If rsLang.RecordCount Then lblRecords.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblRecords.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1003 'The product I want is not in the list.|Checked
		If rsLang.RecordCount Then cmdCustom.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCustom.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'missing ">>" and "&" characters
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmMode(1) = No Code
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1009 'Display Name|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'txtName = No Code/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1011 'Receipt Name|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'txtReceipt = No Code/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1776 'Supplier|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1013 'Deposit|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1021 'Pricing Group|Checked
		If rsLang.RecordCount Then _lblLabels_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1022 'Stock Group|Checked
		If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1019 'Pack Size|Checked
		If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_2 = No code     [There Are]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_10 = No Code    [Units in a Case/Carton, which costs]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_1 = No Code     [And you sell in shrinks of]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockItemNew.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadProducts()
		Dim lString As String
		Dim x As Short
		Dim rs As ADODB.Recordset
		gMode = 0
		
		
		
		For x = 0 To frmMode.Count - 1
			frmMode(x).Visible = False
		Next 
		
		frmMode(0).Left = frmMode(0).Left
		frmMode(0).Top = frmMode(0).Top
		frmMode(0).Visible = True
		frmMode(0).Refresh()
		
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		If Trim(txtSearch.Text) = "" Then
			lString = "Where (StockItem.StockItemID Is Null)"
		Else
			lString = "(BrandItem_Name LIKE '%" & Replace(lString, " ", "%' AND BrandItem_Name LIKE '%") & "%')"
			lString = "Where (StockItem.StockItemID Is Null) AND " & lString
		End If
		
		rs = getRS("SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItem LEFT OUTER JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID " & lString & " ORDER BY BrandItem.BrandItem_Name")
		If rs.RecordCount Then
			lblRecords.Text = "Displayed Records : " & rs.RecordCount
		Else
			If Trim(txtSearch.Text) <> "" Then rs = getRS("SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItemQuantity INNER JOIN (BrandItem LEFT JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID) ON BrandItemQuantity.BrandItemQuantity_BrandItemID = BrandItem.BrandItemID WHERE (((BrandItemQuantity.BrandItemQuantity_Barcode)='" & Trim(txtSearch.Text) & "') AND ((StockItem.StockItemID) Is Null)) ORDER BY BrandItem.BrandItem_Name;")
        End If

        Dim bind As BindingSource = New BindingSource
        bind.DataSource = rs
		DataList1.DataSource = rs
		DataList1.listField = "BrandItem_Name"
		DataList1.DataBindings.Add(bind.DataSource)
		DataList1.boundColumn = "BrandItemID"
		Me.cmdBack.Text = "E&xit"
		Me.cmdNext.Text = "&Next"
		Me.cmdNext.Enabled = True
		If txtSearch.Visible Then Me.txtSearch.Focus()
		
	End Sub
    Private Sub doMode(ByRef mode As Short)
        Dim mdSystemDetails As Short
        gMode = mode
        Dim x As Short
        For x = 0 To frmMode.Count - 1
            frmMode(x).Visible = False
        Next
        frmMode(gMode).Left = frmMode(0).Left
        frmMode(gMode).Top = frmMode(0).Top
        frmMode(gMode).Visible = True
        frmMode(gMode).Refresh()
        Select Case gMode
            Case mdProducts
                loadProducts()
            Case mdSystemDetails
            Case mdCustomDetails
                loadCustom()

        End Select
    End Sub
	
    Private Sub cmbDeposit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbDeposit.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbPackSize_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbPackSize.KeyDown
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
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbStockGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbStockGroup.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If
    End Sub
	
    Private Sub cmbSupplier_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbSupplier.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
        End If

    End Sub
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Dim x As Short
		Select Case gMode
			Case 0
				Me.Close()
			Case 1
				gMode = 0
				For x = 0 To frmMode.Count - 1
					frmMode(x).Visible = False
				Next 
				frmMode(0).Left = frmMode(0).Left
				frmMode(0).Top = frmMode(0).Top
				frmMode(0).Visible = True
				frmMode(0).Refresh()
				txtSearch.Focus()
				cmdBack.Text = "E&xit"
		End Select
	End Sub
	
	
	
	
	Private Sub cmdCustom_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCustom.Click
        Dim rs As ADODB.Recordset
		Dim vValue As String
        Dim hkey As String
		Dim lRetVal As Integer
		If checkSecurity = True Then
			
			'for Security Code
			If bolSecurityCode = True Then
				loadCustom()
			Else
				MsgBox("New Stock Items cannot be added due to Security Restrictions." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired")
				Exit Sub
			End If
			'for Security Code
		Else
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
                'check advance date expiry system
                On Error Resume Next
                vValue = ""
                lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_QUERY_VALUE, hkey)
                lRetVal = QueryValueEx(hkey, "ShellClass", vValue)
                RegCloseKey(hkey)
                If vValue = "" Then
                    vValue = "0"
                Else
                    If vValue <> "0" Then vValue = CStr(CDate("&H" & vValue))
                End If

                If IsDBNull(rs("Company_TerminateDate")) And vValue = "0" Then
                    cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                    lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                    lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                    SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                    RegCloseKey(hkey)
                Else
                    If IsDBNull(rs("Company_TerminateDate")) And vValue <> "0" Then
                        'db date tempered
                        If posDemo() = True Then
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                            lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                            lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                            SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                            RegCloseKey(hkey)
                        Else
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    If IsDBNull(rs("Company_TerminateDate")) Then
                    Else
                        'UPGRADE_WARNING: Couldn't resolve default property of object rs(Company_TerminateDate). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If rs("Company_TerminateDate").Value > Today Then
                            'db date tempered
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    If Today >= CDate(rs("Company_TerminateDate").Value + 30) Then
                        '    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                        '    checkSecurity = False
                        MsgBox("New Stock Items may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired")
                        Exit Sub
                    Else
                        loadCustom()
                    End If
                End If
            End If
		End If
	End Sub
	
	Private Sub cmdDeposit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeposit.Click
		frmDepositList.loadItem(0)
		doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", "StockItem_DepositID", "DepositID", "Deposit_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbDeposit.BoundText = rs.Fields("Default_DepositID").Value
		Else
			cmbDeposit.BoundText = CStr(0)
		End If
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		cmdNext.Focus()
		System.Windows.Forms.Application.DoEvents()
		Select Case gMode
			Case 0
				DataList1_DblClick(DataList1, New System.EventArgs())
			Case 1
				createProduct()
		End Select
	End Sub
	Private Sub createProduct()
		Dim rs As ADODB.Recordset
		Dim sql As String
		
		If txtName.Text = "" Then
			MsgBox("Product Name is a required field!", MsgBoxStyle.Exclamation, Me.Text)
			txtName.Focus()
			Exit Sub
		End If
		If txtReceipt.Text = "" Then
			MsgBox("Receipt Name is a required field!", MsgBoxStyle.Exclamation, Me.Text)
			txtReceipt.Focus()
			Exit Sub
		End If
		If cmbSupplier.CtlText = "" Then
            MsgBox("The Supplier field Must Not be empty!", MsgBoxStyle.Exclamation, Me.Text)
            cmbSupplier.Focus()
            Exit Sub
        End If
		If cmbDeposit.CtlText = "" Then
            MsgBox("The Deposit field Must Not be empty!", MsgBoxStyle.Exclamation, Me.Text)
            cmbDeposit.Focus()
            Exit Sub
        End If
		If cmbPricingGroup.CtlText = "" Then
            MsgBox("The Pricing Group field Must Not be empty!", MsgBoxStyle.Exclamation, Me.Text)
            cmbPricingGroup.Focus()
            Exit Sub
        End If
		If cmbStockGroup.CtlText = "" Then
            MsgBox("The Stock Group field Must Not be empty!", MsgBoxStyle.Exclamation, Me.Text)
            cmbStockGroup.Focus()
            Exit Sub
        End If
		If cmbPackSize.CtlText = "" Then
            MsgBox("The Pack Size field Must Not be empty!", MsgBoxStyle.Exclamation, Me.Text)
            cmbPackSize.Focus()
            Exit Sub
        End If
		If CInt(txtQuantity.Text) = CDbl("0") Then
			txtQuantity.Text = "1"
		End If
		If CInt(txtCost.Text) = CDbl("0") Then
			txtCost.Text = "1"
		End If
		
		sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey) VALUES ("
		sql = sql & gBrandItem & ", " & cmbSupplier.BoundText & ", " & cmbShrink.BoundText & ", " & cmbPackSize.BoundText & ", " & cmbPricingGroup.BoundText & ", " & cmbStockGroup.BoundText & ", 2, " & cmbDeposit.BoundText & ", '" & Replace(txtName.Text, "'", "''") & "', '" & Replace(txtReceipt.Text, "'", "''") & "', " & Replace(CStr(CDec(txtQuantity.Text)), ",", "") & ", " & Replace(txtCost.Text, ",", "") & ", " & Replace(txtCost.Text, ",", "") & ", 0, 0, " & CDec(txtQuantity.Text) & ", 1, 0, 0, 0, '')"
		cnnDB.Execute(sql)
		
		sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;"
		rs = getRS(sql)
		gStockItem = rs.Fields("id").Value
		cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		
		'Multi Warehouse change     cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & ", " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & " FROM Company;"
		cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CDec(txtCost.Text) / CDec(txtQuantity.Text) & ", " & CDec(txtCost.Text) / CDec(txtQuantity.Text) & ", Warehouse.WarehouseID FROM Company, Warehouse;")
		cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " & gStockItem & ", 0 FROM Warehouse;")
		
		cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & gStockItem & "));")
		
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" & gStockItem & ")")
        Dim formUpdate As frmUpdateCatalogue
        formUpdate.Show()
		
		buildBarcodes(gStockItem)
		If gBrandItem Then
			cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		End If
        frmStockBarcode.loadItem(gStockItem)
        Dim formBar As frmStockBarcode
        formBar.Show()
        frmStockPricing.loadItem(gStockItem)
        Dim formPrice As frmStockPricing
        formPrice.Show()
		gStockItem = 0
		gBrandItem = 0
		loadProducts()
		
		
	End Sub
	
	Private Sub cmdPackSize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPackSize.Click
		frmPackSizeList.loadItem()
		doDataControl((Me.cmbPackSize), "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", "StockItem_PackSizeID", "PackSizeID", "PackSize_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbPackSize.BoundText = rs.Fields("Default_PricingGroupID").Value
		Else
			cmbPackSize.BoundText = CStr(1)
		End If
	End Sub
	
	Private Sub cmdPricingGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPricingGroup.Click
		frmPricingGroupList.getItem()
		doDataControl((Me.cmbPricingGroup), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbPricingGroup.BoundText = rs.Fields("Default_PricingGroupID").Value
		Else
			cmbPricingGroup.BoundText = CStr(1)
		End If
	End Sub
	
	Private Sub cmdShrink_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShrink.Click
		frmShrink.ShowDialog()
		doDataControl((Me.cmbShrink), "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", "StockItem_ShrinkID", "ShrinkID", "Shrink_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbShrink.BoundText = rs.Fields("Default_ShrinkID").Value
		Else
			cmbShrink.BoundText = CStr(12)
		End If
	End Sub
	Private Sub cmdStockGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStockGroup.Click
		frmStockGroupList.loadItem(0)
		doDataControl((Me.cmbStockGroup), "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbStockGroup.BoundText = rs.Fields("Default_StockGroupID").Value
		Else
			cmbStockGroup.BoundText = CStr(1)
		End If
	End Sub
	Private Sub cmdSupplier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupplier.Click
		frmSupplierList.loadItem(0)
		doDataControl((Me.cmbSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM [Default]")
		If rs.RecordCount Then
			cmbSupplier.BoundText = rs.Fields("Default_SupplierID").Value
		Else
			cmbSupplier.BoundText = CStr(4)
		End If
	End Sub
	Private Function getSerialNumber() As String
		Dim FSO As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		getSerialNumber = ""
		If FSO.FolderExists(serverPath) Then
			fsoFolder = FSO.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(password)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	
	Private Function bolSecurityCode() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		
		Dim stPass As String
		Dim givPass As String
		
		On Error GoTo Hell_Error
		
		bolSecurityCode = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					gSecKey = rs.Fields("Company_PosString").Value
					If Len(rs.Fields("Company_PosString").Value) = 13 Then
						bolSecurityCode = True
						Exit Function
					End If
				End If
				
				If IsDbNull(rs.Fields("Company_PosString").Value) Or rs.Fields("Company_PosString").Value = "0" Then
                    bolSecurityCode = True
                    Exit Function
                End If
				
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					intYear = CShort(VB.Left(rs.Fields("Company_PosString").Value, 2))
					intMonth = CShort(Mid(rs.Fields("Company_PosString").Value, 3, 2))
					intDate = CShort(Mid(rs.Fields("Company_PosString").Value, 5, 2))
					
					If (intDate / 2) = System.Math.Round(intDate / 2) Then
						intDate = intDate / 2
					Else
						Exit Function
					End If
					
					
					If (intMonth / 2) = System.Math.Round(intMonth / 2) Then
						intMonth = intMonth / 2
					Else
						Exit Function
					End If
					
					
					If (intYear / 2) = System.Math.Round(intYear / 2) Then
						intYear = intYear / 2
					Else
						Exit Function
					End If
					
					stPass = "20"
					If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
					If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
					If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
					
					If IsDate(stPass) Then
						If CDate(stPass) >= Today Then
							bolSecurityCode = True
							Exit Function
						End If
					End If
					
					'If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
					'    bolSecurityCode = True
					'    Exit Function
					'Else
					'    Exit Function
					'End If
					
				Else
					Exit Function
				End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
		
		Exit Function
Hell_Error: 
		MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Exclamation)
		Exit Function
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_Code").Value) Then
					gSecKey = rs.Fields("Company_Code").Value
					If Len(rs.Fields("Company_Code").Value) = 13 Then
						
						checkSecurity = True
						Exit Function
					End If
				End If
				lPassword = "pospospospos"
				lCode = getSerialNumber
				If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
					checkSecurity = True
				Else
					leCode = Encrypt(lCode, lPassword)
					For x = 1 To Len(leCode)
						If Asc(Mid(leCode, x, 1)) < 33 Then
							leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
						End If
					Next x
					
					If rs.Fields("Company_Code").Value = leCode Then
						'If IsNull(rs("Company_TerminateDate")) Then
						checkSecurity = True
						'Else
						'    If Date > rs("Company_TerminateDate") Then
						'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						'        checkSecurity = False
						Exit Function
						'   End If
						'End If
					Else
						'txtCompany.Text = rs("Company_Name")
						'txtCompany.SelStart = 0
						'txtCompany.SelLength = 999
						'show 1
					End If
					
				End If
			Else
				MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
				End
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
        Dim gStockItemID As Integer
        Dim gBrandItemID As Integer
		Dim rs As ADODB.Recordset
		Dim x As Short
		
		Dim vValue As String
        Dim hkey As String = ""
		Dim lRetVal As Integer
		If checkSecurity = True Then
			
		Else
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				'check advance date expiry system
				On Error Resume Next
				vValue = ""
				lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_QUERY_VALUE, hkey)
				lRetVal = QueryValueEx(hkey, "ShellClass", vValue)
				RegCloseKey(hkey)
				If vValue = "" Then
					vValue = "0"
				Else
					If vValue <> "0" Then vValue = CStr(CDate("&H" & vValue))
				End If
				
				If IsDbNull(rs.Fields("Company_TerminateDate").Value) And vValue = "0" Then
                    cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                    lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                    lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                    SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                    RegCloseKey(hkey)
                Else
                    If IsDBNull(rs.Fields("Company_TerminateDate").Value) And vValue <> "0" Then
                        'db date tempered
                        If posDemo() = True Then
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & Today & "#;")
                            lRetVal = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls\MSOCache", 0, "soap", 0, KEY_ALL_ACCESS, 0, hkey, 0)
                            lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\CurrentVersion\ShellDls", 0, KEY_ALL_ACCESS, hkey)
                            SetValueEx(hkey, "ShellClass", REG_SZ, Hex(Today.ToOADate))
                            RegCloseKey(hkey)
                        Else
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    If IsDBNull(rs.Fields("Company_TerminateDate").Value) Then
                    Else
                        If rs.Fields("Company_TerminateDate").Value > Today Then
                            'db date tempered
                            cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" & (System.DateTime.FromOADate(Today.ToOADate - 20)) & "#;")
                            MsgBox("Invalid License found." & vbCrLf & "application will now exit", MsgBoxStyle.Critical, "Run Time Error")
                            End
                        End If
                    End If

                    If Today >= CDate(rs.Fields("Company_TerminateDate").Value + 30) Then
                        '    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                        '   checkSecurity = False
                        MsgBox("New Stock Items may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired")
                        Exit Sub
                    Else

                    End If
                End If
			End If
		End If
		
		If DataList1.BoundText <> "" Then
			gMode = 1
			gBrandItemID = 0
			gStockItemID = 0
			txtName.Enabled = False
			txtReceipt.Enabled = False
			cmbStockGroup.BoundText = CStr(35)
			
			rs = getRS("SELECT * FROM BrandItem WHERE BrandItemID = " & DataList1.BoundText)
			
			gBrandItem = rs.Fields("BrandItemID").Value
			txtName.Text = rs.Fields("BrandItem_Name").Value
			txtReceipt.Text = rs.Fields("BrandItem_ReceiptName").Value
			cmbShrink.BoundText = rs.Fields("BrandItem_ShrinkID").Value
			cmbDeposit.BoundText = rs.Fields("BrandItem_DepositID").Value
			
			cmbPricingGroup.BoundText = IIf(IsDbNull(rs.Fields("BrandItem_PricingGroupID").Value), 1, rs.Fields("BrandItem_PricingGroupID").Value) 'rs("BrandItem_PricingGroupID")
			cmbStockGroup.BoundText = IIf(IsDbNull(rs.Fields("BrandItem_StockGroupID").Value), 1, rs.Fields("BrandItem_StockGroupID").Value) 'rs("BrandItem_StockGroupID")
			cmbPackSize.BoundText = IIf(IsDbNull(rs.Fields("BrandItem_PackSizeID").Value), 1, rs.Fields("BrandItem_PackSizeID").Value) 'rs("BrandItem_PackSizeID")
			
			rs = getRS("SELECT TOP 1 BrandItemSupplier.BrandItemSupplier_SupplierID, BrandItemSupplier.BrandItemSupplier_Quantity, BrandItemSupplier.BrandItemSupplier_PackCost From BrandItemSupplier Where (((BrandItemSupplier.BrandItemSupplier_BrandItemID) = " & gBrandItem & ")) ORDER BY BrandItemSupplier.BrandItemSupplier_SupplierID;")
			If rs.BOF Or rs.EOF Then
			Else
				cmbSupplier.BoundText = rs.Fields("BrandItemSupplier_SupplierID").Value
				txtQuantity.Text = FormatNumber(rs.Fields("BrandItemSupplier_Quantity").Value, 0)
				txtCost.Text = FormatNumber(rs.Fields("BrandItemSupplier_PackCost").Value, 2)
			End If
			
			For x = 0 To frmMode.Count - 1
				frmMode(x).Visible = False
			Next 
			
			frmMode(1).Left = frmMode(0).Left
			frmMode(1).Top = frmMode(0).Top
			frmMode(1).Visible = True
			frmMode(1).Refresh()
			cmbSupplier.Focus()
			cmdBack.Text = "&Back"
			
		End If
	End Sub
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        If eventArgs.KeyChar = ChrW(13) Then
            eventArgs.KeyChar = ChrW(0)
            DataList1_DblClick(DataList1, New System.EventArgs())
        End If
    End Sub
	Private Sub frmStockItemNew_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Private Sub frmStockItemNew_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        frmMode.AddRange(New GroupBox() {_frmMode_0, _frmMode_1})
        Dim gStockItemID As Integer
        Dim gBrandItemID As Integer
		gBrandItemID = 0
		gStockItemID = 0
		buildDataControls()
		doMode(mdProducts)
		
		loadLanguage()
	End Sub
	
	Private Sub loadCustom()
        Dim gStockItemID As Integer
        Dim gBrandItemID As Integer
		Dim x As Short
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
			cmbPricingGroup.BoundText = rs.Fields("Default_PricingGroupID").Value
			cmbPackSize.BoundText = rs.Fields("Default_PricingGroupID").Value
		Else
			cmbShrink.BoundText = CStr(12)
			cmbSupplier.BoundText = CStr(4)
			cmbDeposit.BoundText = CStr(0)
			cmbStockGroup.BoundText = CStr(1)
			cmbPricingGroup.BoundText = CStr(1)
			cmbPackSize.BoundText = CStr(1)
		End If
		For x = 0 To frmMode.Count - 1
			frmMode(x).Visible = False
		Next 
		frmMode(1).Left = frmMode(0).Left
		frmMode(1).Top = frmMode(0).Top
		frmMode(1).Visible = True
		frmMode(1).Refresh()
		cmdBack.Text = "&Back"
		txtName.Focus()
	End Sub
	Private Sub buildDataControls()
		doDataControl((Me.cmbShrink), "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", "StockItem_ShrinkID", "ShrinkID", "Shrink_Name")
		doDataControl((Me.cmbPricingGroup), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
		doDataControl((Me.cmbSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
		doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", "StockItem_DepositID", "DepositID", "Deposit_Name")
		doDataControl((Me.cmbStockGroup), "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name")
		doDataControl((Me.cmbPackSize), "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", "StockItem_PackSizeID", "PackSizeID", "PackSize_Name")
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        dataControl.DataSource = rs
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	Private Sub txtName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Enter
        MyGotFocus(txtName)
	End Sub
	
	Private Sub txtName_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Leave
		If txtReceipt.Text = "" Or txtReceipt.Text = "[New Product]" Then
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
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 40 Then
			Me.DataList1.Focus()
		End If
	End Sub
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			loadProducts()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class