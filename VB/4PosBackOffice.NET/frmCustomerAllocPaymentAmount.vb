Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCustomerAllocPaymentAmount
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Dim WHFromA As Integer
	Dim WHToB As Integer
	Dim lAmount As Decimal
	
	Private Sub loadLanguage()
		
		'frmCustomerAllocPaymentAmount = No Code    [Allocate Partial Amount]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCustomerAllocPaymentAmount.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerAllocPaymentAmount.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1188 'Allocate|Checked
		If rsLang.RecordCount Then lblPComp.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblPComp.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_1 = No Code                           [Available]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1188 'Allocate|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCustomerAllocPaymentAmount.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Public Function getAmount(ByRef iAmount As Decimal) As Decimal
        lblStockItem.Text = FormatNumber(iAmount, 2)
        txtPrice.Text = FormatNumber(0 - iAmount, 2) '"0.00"

        loadLanguage()
        ShowDialog()
        'If txtPrice.Text = "" Then txtPrice.Text = 0
        getAmount = lAmount 'CCur(txtPrice.Text)
    End Function
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		rs = getRS("SELECT StockItem.StockItem_Name FROM StockItem WHERE ((StockItem.StockItemID)=" & gStockItemID & ");")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
            Me.Height = twipsToPixels(2520, False)
			
			loadLanguage()
			ShowDialog()
		End If

	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0, Optional ByRef WHFrom As Integer = 0, Optional ByRef WHTo As Integer = 0)
		gStockItemID = stockitemID
		'gPromotionID = promotionID
		gQuantity = quantity
		WHFromA = WHFrom
		WHToB = WHTo
		lblPComp.Text = frmStockTransferWH.lblWHA.Text
		loadData()
		
		'show 1
		
	End Sub
    Private Sub frmCustomerAllocPaymentAmount_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim mbAddNewFlag As Object
        Dim mbEditFlag As Object
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
        lAmount = 0
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
        rs = getRS("SELECT * FROM HandheldWHTransfer;")
        If rs.RecordCount Then
        End If

        Exit Sub
Err_ChkTransTable:
        If Err.Number = -2147217865 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldWHTransfer'.  Make sure it exists and that its name is spelled correctly." Then
            strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency, WHouseID Number"
            cnnDB.Execute("CREATE TABLE HandheldWHTransfer (" & strFldName & ")")
            System.Windows.Forms.Application.DoEvents()
            rs = getRS("SELECT * FROM HandheldWHTransfer;")
            If rs.RecordCount Then
            End If

            GoTo ChkTransTable
        End If

    End Sub

    'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Function update_Renamed() As Boolean
        Dim sql As String
        Dim txtQty As New TextBox
        On Error GoTo UpdateErr

        ChkHandheldWHTransfer()

        sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" & gStockItemID & ", 0, " & (0 - CDec(txtQty.Text)) & "," & WHFromA & ")"
        cnnDB.Execute(sql)
        System.Windows.Forms.Application.DoEvents()

        sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" & gStockItemID & ", 0, " & CDec(txtQty.Text) & "," & WHToB & ")"
        cnnDB.Execute(sql)
        System.Windows.Forms.Application.DoEvents()

        update_Renamed = True
        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        update_Renamed = True

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        If txtPrice.Text = "" Then txtPrice.Text = CStr(0)
        If CDec(txtPrice.Text) > (0 - CDec(lblStockItem.Text)) Then
            MsgBox("Insufficient funds.")
            Exit Sub
        End If
        lAmount = CDec(txtPrice.Text)
        'If CCur(txtQty.Text) > 0 Then
        'Else
        '    txtQty.SetFocus
        '    Exit Sub
        'End If

        'If update() Then
        Me.Close()
        'End If
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

    Private Sub txtQty_KeyPress(ByRef KeyAscii As Short)
        Select Case KeyAscii
            Case Asc(vbCr)
                KeyAscii = 0
            Case 8
            Case 48 To 57

        End Select
    End Sub

    Private Sub txtQty_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'txtQty.SelStart = 0
        'txtQty.SelLength = Len(txtQty.Text)
    End Sub

    Private Sub txtQty_MyLostFocus()
        ' LostFocus txtQty, 2
    End Sub
End Class