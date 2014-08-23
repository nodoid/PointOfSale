Option Strict Off
Option Explicit On
Friend Class frmStockItemHistory
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gID As Integer
    Dim lblField As New List(Of Label)
	Private Sub loadLanguage()
		
		'frmStockItemHistory = No Code  [Stock Item Sales History]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockItemHistory.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItemHistory.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblField_0 = No Code/Dynamic!
		
		'Label1(15) = No Code           [Current Units in Stock]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(15).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(15).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(16) = No Code           [Cases in Stock]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(16).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(17) = No Code           [Units per Case]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(17).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code            [Daily]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code            [Weekly]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(2) = No Code            [Monthly]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockItemHistory.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oLabel As System.Windows.Forms.Label
		Dim sql As String
		Dim rs As ADODB.Recordset
		Dim lQty As Integer
		rs = getRS("SELECT StockitemHistory.StockitemHistory_StockItemID From StockitemHistory WHERE (((StockitemHistory.StockitemHistory_StockItemID)=" & id & "));")
		If rs.RecordCount = 0 Then
			sql = "INSERT INTO StockitemHistory (StockitemHistory_StockItemID,  StockitemHistory_Value, StockitemHistory_Day1, StockitemHistory_Day2, StockitemHistory_Day3, StockitemHistory_Day4, StockitemHistory_Day5, StockitemHistory_Day6, StockitemHistory_Day7, StockitemHistory_Day8, StockitemHistory_Day9, StockitemHistory_Day10, StockitemHistory_Day11, StockitemHistory_Day12, StockitemHistory_Week1, StockitemHistory_Week2, StockitemHistory_Week3, StockitemHistory_Week4, StockitemHistory_Week5, StockitemHistory_Week6, StockitemHistory_Week7, StockitemHistory_Week8, StockitemHistory_Week9, StockitemHistory_Week10, StockitemHistory_Week11, StockitemHistory_Week12, StockitemHistory_Month1, StockitemHistory_Month2, StockitemHistory_Month3, StockitemHistory_Month4, StockitemHistory_Month5, StockitemHistory_Month6, StockitemHistory_Month7, StockitemHistory_Month8, StockitemHistory_Month9, StockitemHistory_Month10, StockitemHistory_Month11, StockitemHistory_Month12 )"
			sql = sql & " SELECT " & id & ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0;"
			cnnDB.Execute(sql)
		End If
		'    Set rs = getRS("SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) GROUP BY SaleItem.SaleItem_StockItemID HAVING (((SaleItem.SaleItem_StockItemID)=" & id & "));")
		sql = "SELECT Sum(sales.qty) AS SumOfqty FROM (SELECT SaleItem.SaleItem_StockItemID, (IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_StockItemID) = " & id & ") And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) Union SELECT SaleItemReciept.SaleItemReciept_StockitemID AS SaleItem_StockItemID, IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity]) AS qty "
		sql = sql & "FROM (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN SaleItemReciept ON SaleItem.SaleItemID = SaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItemReciept.SaleItemReciept_StockitemID)=" & id & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((SaleItem.SaleItem_Recipe)<>0))) AS sales;"
		'wrong calculation cuz DayEndID = MonthEndID
		'sql = "SELECT Sum(sales.qty) AS SumOfqty FROM (SELECT SaleItem.SaleItem_StockItemID, (IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS qty FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_StockItemID) = " & id & ") And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null)) Union SELECT SaleItemReciept.SaleItemReciept_StockitemID AS SaleItem_StockItemID, IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity]) AS qty "
		'sql = sql & "FROM (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_MonthEndID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) INNER JOIN SaleItemReciept ON SaleItem.SaleItemID = SaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItemReciept.SaleItemReciept_StockitemID)=" & id & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((SaleItem.SaleItem_Recipe)<>0))) AS sales;"
		
		rs = getRS(sql)
		If rs.RecordCount Then
			lQty = CInt(0 & rs.Fields("SumOfqty").Value)
		Else
			lQty = 0
		End If
		
		
		
		sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, CCur([WarehouseStockItemLnk_Quantity]/[StockItem_Quantity]) AS cases, StockitemHistory.*, [StockitemHistory_Week1]+" & lQty & " AS thisWeek, [StockitemHistory_Month1]+" & lQty & " AS thisMonth, " & lQty & " AS thisDay FROM (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID=2 AND StockItem.StockItemID=" & id & ";"
		'sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, CCur([WarehouseStockItemLnk_Quantity]/[StockItem_Quantity]) AS cases, StockitemHistory.*, [StockitemHistory_Week1]+" & lQty & " AS thisWeek, [StockitemHistory_Month1]+" & lQty & " AS thisMonth, " & lQty & " AS thisDay FROM (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE StockItem.StockItemID=" & id & ";"
		
		
		adoPrimaryRS = getRS(sql)
		If adoPrimaryRS.RecordCount = 0 Then
			Exit Sub
		End If
		For	Each oLabel In Me.lblField
            oLabel.DataBindings.Add(adoPrimaryRS)
        Next oLabel

        Me._lblFieldCurr_0.Text = FormatNumber(adoPrimaryRS.Fields("cases").Value, 2)
		
		loadLanguage()
		ShowDialog()
    End Sub

    Private Sub frmStockItemHistory_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblField.AddRange(New Label() {_lblField_0, _lblField_1, _lblField_2, _lblField_3, _lblField_4, _lblField_5, _
        _lblField_6, _lblField_7, _lblField_8, _lblField_9, _lblField_10, _
                                      _lblField_11, _lblField_12, _lblField_13, _lblField_14, _lblField_15, _
                                      _lblField_16, _lblField_16, _lblField_17, _lblField_18, _lblField_19, _
                                      _lblField_20, _lblField_21, _lblField_22, _lblField_23, _lblField_24, _
                                      _lblField_25, _lblField_26, _lblField_27, _lblField_28, _lblField_29, _
                                      _lblField_30, _lblField_31, _lblField_32, _lblField_33, _lblField_34, _
                                      _lblField_35, _lblField_36, _lblField_37, _lblField_38})
    End Sub
	
	
	'UPGRADE_WARNING: Event frmStockItemHistory.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmStockItemHistory_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdnext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdnext.Left + 340
	End Sub
	Private Sub frmStockItemHistory_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				adoPrimaryRS.Move(0)
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmStockItemHistory_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
End Class