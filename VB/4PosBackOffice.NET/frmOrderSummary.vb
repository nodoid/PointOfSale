Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmOrderSummary
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
    Dim lblLabels As New List(Of Label)
    Dim lbl As New List(Of Label)
    Dim txtFields As New List(Of TextBox)
    Dim lblData As New List(Of Label)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1594 'Complete Order|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1458 'Ordering Details|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1455 'Representative Name|Checked
		If rsLang.RecordCount Then lblLabels(38).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(38).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1456 'Representative Number|Checked
		If rsLang.RecordCount Then lblLabels(37).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(37).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1457 'Account Number|Checked
		If rsLang.RecordCount Then lblLabels(36).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(36).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmOrder = No Code     [Order Totals]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1605 'Content Total|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1606 'Deposit Total|Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1607 'Order Exclusive Total|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1608 'Process this Order|Checked
		If rsLang.RecordCount Then lbl(8).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(8).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1609 'Order Reference|Checked
		If rsLang.RecordCount Then _lbl_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1610 'Order Attention Line|Checked
		If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1332 'Process|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmOrderSummary.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub doTotals()
        Dim lContent, lQuantity As Decimal
		Dim lDeposit As Decimal
		lContent = CDec(frmOrderItem.lblContent.Text)
		lDeposit = CDec(frmOrderItem.lblDeposit.Text)
		Me.lblContentTotal.Text = FormatNumber(lContent, 2)
		lblDepositTotal.Text = FormatNumber(lDeposit, 2)
		lblTotal.Text = FormatNumber(lContent + lDeposit, 2)
	End Sub
	
	
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		System.Windows.Forms.Application.DoEvents()
		frmOrderItem.Close()
		System.Windows.Forms.Application.DoEvents()
		frmOrder.Close()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim gID As Integer
		Dim rs As ADODB.Recordset
		Dim rsComp As ADODB.Recordset
		
		Dim sql As String
		If MsgBox("You are about to commit this order." & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Commit Order") = MsgBoxResult.Yes Then
			update_Renamed()
			cnnDB.Execute("INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_DateCreated, PurchaseOrder_DatePosted, PurchaseOrder_Reference, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_AttentionLine ) SELECT TempOrder.TempOrder_SupplierID, Company.Company_DayEndID, TempOrder.TempOrder_DateCreated, Now() AS [date], TempOrder.TempOrder_Reference, 1 AS Status, TempOrder.TempOrder_AttentionLine From TempOrder, Company WHERE (((TempOrder.TempOrder_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
			rs = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
			
			gID = rs.Fields("id").Value
			
			'sql = "INSERT INTO PurchaseOrderItem ( PurchaseOrderItem_PurchaseOrderID, PurchaseOrderItem_StockItemID, PurchaseOrderItem_PackSize, PurchaseOrderItem_QuantityRequired, PurchaseOrderItem_Quantity, PurchaseOrderItem_QuantityDelivered, PurchaseOrderItem_DepositUnitCost, PurchaseOrderItem_DepositPackCost, PurchaseOrderItem_DepositCost, PurchaseOrderItem_ContentCost ) SELECT " & gID & " AS purchaseOrder, TempOrderItem.TempOrderItem_StockItemID, TempOrderItem.TempOrderItem_PackSize, TempOrderItem.TempOrderItem_QuantityRequired, TempOrderItem.TempOrderItem_Quantity, 0 AS delivered, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, (Abs([TempOrderItem_PackSize]=[StockItem_Quantity])*[Deposit_CaseCost])+([TempOrderItem_PackSize]*[Deposit_UnitCost]) AS deposit, [StockItem_ListCost] AS content "
			sql = "INSERT INTO PurchaseOrderItem ( PurchaseOrderItem_PurchaseOrderID, PurchaseOrderItem_StockItemID, PurchaseOrderItem_PackSize, PurchaseOrderItem_QuantityRequired, PurchaseOrderItem_Quantity, PurchaseOrderItem_QuantityDelivered, PurchaseOrderItem_DepositUnitCost, PurchaseOrderItem_DepositPackCost, PurchaseOrderItem_DepositCost, PurchaseOrderItem_ContentCost ) SELECT " & gID & " AS purchaseOrder, TempOrderItem.TempOrderItem_StockItemID, TempOrderItem.TempOrderItem_PackSize, TempOrderItem.TempOrderItem_QuantityRequired, TempOrderItem.TempOrderItem_Quantity, 0 AS delivered, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, (Abs([TempOrderItem_PackSize]=[StockItem_Quantity])*[Deposit_CaseCost])+([TempOrderItem_PackSize]*[Deposit_UnitCost]) AS deposit, TempOrderItem.TempOrderItem_ContentCost AS content "
			sql = sql & "FROM (StockItem INNER JOIN TempOrderItem ON StockItem.StockItemID = TempOrderItem.TempOrderItem_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));"
			cnnDB.Execute(sql)
			
			rsComp = getRS("SELECT Company_POPrintBC FROM Company;")
			If rsComp.RecordCount Then
				If IIf(IsDbNull(rsComp.Fields("Company_POPrintBC").Value), False, rsComp.Fields("Company_POPrintBC").Value) Then
					'cnnDB.Execute "UPDATE PurchaseOrderItem INNER JOIN Catalogue ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = Catalogue.Catalogue_StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Code = [Catalogue]![Catalogue_Barcode] WHERE (((Catalogue.Catalogue_Quantity)=1) AND ((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & gID & "));"
					cnnDB.Execute("UPDATE (PurchaseOrderItem INNER JOIN Catalogue ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = [Catalogue]![Catalogue_Barcode] WHERE (((Catalogue.Catalogue_Quantity)=1) AND ((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & gID & "));")
				Else
					cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = '' WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & gID & "));")
					cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN BrandItemSupplier ON StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) INNER JOIN PurchaseOrder ON (PurchaseOrder.PurchaseOrderID = PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID) AND (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) SET PurchaseOrderItem.PurchaseOrderItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((PurchaseOrder.PurchaseOrderID)=" & gID & "));")
				End If
			Else
				cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID SET PurchaseOrderItem.PurchaseOrderItem_Name = [StockItem]![StockItem_Name], PurchaseOrderItem.PurchaseOrderItem_Code = '' WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & gID & "));")
				cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN BrandItemSupplier ON StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) INNER JOIN PurchaseOrder ON (PurchaseOrder.PurchaseOrderID = PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID) AND (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) SET PurchaseOrderItem.PurchaseOrderItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((PurchaseOrder.PurchaseOrderID)=" & gID & "));")
			End If
			
			cnnDB.Execute("DELETE FROM TempOrderItem WHERE (TempOrderItem_SupplierID = " & adoPrimaryRS.Fields("SupplierID").Value & ")")
			cnnDB.Execute("DELETE FROM TempOrder WHERE (TempOrder_SupplierID = " & adoPrimaryRS.Fields("SupplierID").Value & ")")
			
			report_PurchaseOrder(gID)
			cmdExit_Click(cmdExit, New System.EventArgs())
			
		End If
	End Sub
	
	Private Sub frmOrderSummary_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lblLabels.AddRange(New Label() {_lblLabels_36, _lblLabels_37, _lblLabels_38, _lblLabels_6, _
                                        _lblLabels_7, _lblLabels_8, _lblLabels_8, _lblLabels_9})
        lbl.AddRange(New Label() {_lbl_0, _lbl_1, _lbl_2, _lbl_3, _lbl_4, _lbl_5, _lbl_6, _
                                  _lbl_7, _lbl_8})
        lblData.AddRange(New Label() {_lblData_0, _lblData_1, _lblData_2, _lblData_3, _lblData_4, _
                                      _lblData_5, _lblData_6, _lblData_7})
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        Dim oLabel As System.Windows.Forms.Label
		Dim oText As System.Windows.Forms.TextBox
		adoPrimaryRS = getRS("SELECT Supplier.*, TempOrder.* FROM Supplier INNER JOIN TempOrder ON Supplier.SupplierID = TempOrder.TempOrder_SupplierID WHERE (((Supplier.SupplierID)=" & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & "));")
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		For	Each oLabel In Me.lblData
			oLabel.DataBindings.Add(adoPrimaryRS)
		Next oLabel
		
		loadLanguage()
		doTotals()
	End Sub
	
	Private Sub frmOrderSummary_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		update_Renamed()
	End Sub
	
	Private Sub update_Renamed()
		'  On Error GoTo UpdateErr
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		Exit Sub
UpdateErr: 
		MsgBox(Err.Description)
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub
End Class