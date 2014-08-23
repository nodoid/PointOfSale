Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockBarcode
	Inherits System.Windows.Forms.Form
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmStockBarcode = No Code  [Maintain Stock Item Barcodes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdBuildBarcodes = No Code [&Build Barcode]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuildBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdBuildSPLU = No Code     [Build Scale PLU]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuildSPLU.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildSPLU.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: DB entry 1004 requires "&" for accelerator key!!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblHeading = No Code/Dynamic/NA!
		
		'_lbl_2 = No Code           [Barcodes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: DB Entry 2192 wrong case: "shrink" instead of "shrink"!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2192 'shrink|Checked
        If rsLang.RecordCount Then _lbl_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(12) = No Code          [Bar Code]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(12).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(12).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1195 'Disable|Checked
        If rsLang.RecordCount Then _lbl_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblBarcode(0) = No Code    [Bonne]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblBarcode(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblBarcode(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockBarcode.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim x As Short
		gID = id
		rs = getRS("SELECT StockItem_Name FROM StockItem WHERE StockItemID = " & gID)
		If rs.EOF Or rs.EOF Then
		Else
			lblHeading.Text = rs.Fields("StockItem_Name").Value
		End If
		
		sql = "INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) "
		sql = sql & "SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN "
		sql = sql & "StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID) "
		sql = sql & "WHERE (((theJoin.StockItemID)=" & id & ") AND ((Catalogue.Catalogue_StockItemID) Is Null));"
		
		cnnDB.Execute(sql)
		
		rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content, Catalogue.Catalogue_Disabled, ShrinkItem.ShrinkItem_Code FROM Catalogue INNER JOIN (StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) ON (ShrinkItem.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) Where (((Catalogue.Catalogue_StockItemID) = " & gID & ")) ORDER BY Catalogue.Catalogue_Quantity;")
		'Set rs = getRS("SELECT Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Disabled From Catalogue Where (((Catalogue.Catalogue_StockItemID) = " & gID & ")) ORDER BY Catalogue.Catalogue_Quantity;")
        'For x = 1 To lblBarcode.Count - 1
        'lblBarcode.Unload(x)
        'txtBarcode.Unload(x)
        'chkBarcode.Unload(x)
        'Next 

        x = -1
        Do Until rs.EOF
            x = x + 1
            If x Then
                'txtBarcode.Load(x)
                _txtBarcode_0.Top = twipsToPixels(pixelToTwips(_txtBarcode_0.Top, False) + _
                                                 pixelToTwips(_txtBarcode_0.Height, False) _
                                                 + 30, False)
                _txtBarcode_0.Visible = True
                _txtBarcode_0.TabIndex = _txtBarcode_0.TabIndex + 1
                'lblBarcode.Load(x)
                _lblBarcode_0.Top = twipsToPixels(pixelToTwips(_txtBarcode_0.Top, False) + _
                                                 pixelToTwips(_txtBarcode_0.Height, False) _
                                                 + 60, False)
                _lblBarcode_0.Visible = True
                _lblBarcode_0.BringToFront()

                'chkBarcode.Load(x)
                _chkBarcode_0.Top = twipsToPixels(pixelToTwips(_txtBarcode_0.Top, False) + _
                                                 pixelToTwips(_txtBarcode_0.Height, False) _
                                                 + 90, False)
                _chkBarcode_0.Visible = True
            End If
            _lblBarcode_0.Text = rs.Fields("Catalogue_Quantity").Value
            _txtBarcode_0.Text = rs.Fields("Catalogue_Barcode").Value
            _txtBarcode_0.Tag = _txtBarcode_0.Text
            _chkBarcode_0.CheckState = System.Math.Abs(CShort(rs.Fields("Catalogue_Disabled").Value))
            _chkBarcode_0.Tag = _chkBarcode_0.CheckState
            rs.MoveNext()
        Loop
        Shape1.Height = twipsToPixels(pixelToTwips(_lblBarcode_0.Top, False) + _
                                     pixelToTwips(_lblBarcode_0.Height, False) + 240 - _
                                     pixelToTwips(Shape1.Top, False), False)
        Height = twipsToPixels(pixelToTwips(Shape1.Top, False) + _
                              pixelToTwips(Shape1.Height, False) + 560, False)


    End Sub

    Private Sub cmdBuildBarcodes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildBarcodes.Click
        buildBarcodes(gID)
        loadItem(gID)
    End Sub

    Private Sub cmdBuildSPLU_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildSPLU.Click
        Dim rsChk As ADODB.Recordset

        rsChk = getRS("SELECT TOP 1 Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue Where (((CDbl(IIf(IsNumeric([Catalogue].[Catalogue_Barcode]), [Catalogue].[Catalogue_Barcode], 0))) > 0 And (CDbl(IIf(IsNumeric([Catalogue].[Catalogue_Barcode]), [Catalogue].[Catalogue_Barcode], 0))) < 99999)) ORDER BY CLng(Catalogue.Catalogue_Barcode) DESC;")
        If rsChk.RecordCount Then
            _txtBarcode_0.Text = CStr(CDbl(rsChk.Fields("Catalogue_Barcode").Value) + 1)
        Else
            _txtBarcode_0.Text = CStr(1)
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        'Dim x As Short
        'For x = 0 To txtBarcode.UBound
        _txtBarcode_0.Text = _txtBarcode_0.Tag
        _chkBarcode_0.CheckState = CShort(_chkBarcode_0.Tag)
        'Next
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim x As Short
        Dim rsChk As ADODB.Recordset

        If bGRVNewItemBarcode = True Then

            'For x = 0 To txtBarcode.UBound
            'Set rsChk = getRS("SELECT Catalogue_Barcode FROM Catalogue WHERE Catalogue_Barcode = '" & Replace(_txtBarcode_0.Text, "'", "''") & "' AND Catalogue_StockItemID <> " & gID & " AND Catalogue_Disabled=False;")
            rsChk = getRS("SELECT Catalogue.Catalogue_Barcode, StockItem.StockItem_Name FROM StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" & Replace(_txtBarcode_0.Text, "'", "''") & "') AND ((Catalogue.Catalogue_StockItemID)<>" & gID & ") AND ((Catalogue.Catalogue_Disabled)=False) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));")
            If rsChk.RecordCount Then
                MsgBox("'" & rsChk.Fields("Catalogue_Barcode").Value & "'  Barcode has already been used by  '" & rsChk.Fields("StockItem_Name").Value & "' , Please type in different Barcode or use Build Barcode option.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Exit Sub
            End If
            'If _txtBarcode_0.Text <> _txtBarcode_0.Tag Then
            '    sql = "UPDATE Catalogue SET Catalogue_Barcode = '" & Replace(_txtBarcode_0.Text, "'", "''") & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Caption
            '    cnnDB.Execute sql
            'End If
            'If _chkBarcode_0.value <> _chkBarcode_0.Tag Then
            '    sql = "UPDATE Catalogue SET Catalogue_Disabled = '" & _chkBarcode_0.value & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Caption
            '    cnnDB.Execute sql
            'End If
            'Next

            Me.Close()
        Else
            Me.Close()
        End If

    End Sub
    Private Sub frmStockBarcode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                System.Windows.Forms.Application.DoEvents()
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmStockBarcode_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        loadLanguage()
    End Sub

    Private Sub frmStockBarcode_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim x As Short
        Dim sql As String
        'For x = 0 To txtBarcode.UBound
        If _txtBarcode_0.Text <> _txtBarcode_0.Tag Then
            sql = "UPDATE Catalogue SET Catalogue_Barcode = '" & Replace(_txtBarcode_0.Text, "'", "''") & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Text
            cnnDB.Execute(sql)
        End If
        If _chkBarcode_0.CheckState <> CDbl(_chkBarcode_0.Tag) Then
            sql = "UPDATE Catalogue SET Catalogue_Disabled = '" & _chkBarcode_0.CheckState & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Text
            cnnDB.Execute(sql)
        End If
        ' Next

    End Sub
	
    Private Sub txtBarcode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtBarcode.Enter
        'Dim Index As Short = txtBarcode.GetIndex(eventSender)
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        txtBox.SelectionStart = 0
        txtBox.SelectionLength = Len(txtBox.Text)

    End Sub
End Class