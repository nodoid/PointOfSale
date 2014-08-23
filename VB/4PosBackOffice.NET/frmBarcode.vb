Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmBarcode
	Inherits System.Windows.Forms.Form
	Dim gType As Integer
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Dim optBarcode As New List(Of RadioButton)
	
	Private Sub loadLanguage()
        Dim cmdExit As Button

		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1817 'Barcode Printing|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1818 'Printer|Checked
        If rsLang.RecordCount Then _Label2_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label2_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

		'lblPrinter = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1819 'Printer Type|Checked
        If rsLang.RecordCount Then _Label2_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label2_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblPrinterType = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1820 'Select the barcode printing type you require|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1821 'Stock Barcode|Checked
        If rsLang.RecordCount Then _optBarcode_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optBarcode_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1830 'Shelf Taker|Checked
        If rsLang.RecordCount Then _optBarcode_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optBarcode_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
        If rsLang.RecordCount Then
            cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value
            cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        End If

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
        If rsLang.RecordCount Then cmdnext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdnext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsHelp.Filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
       If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value

    End Sub

    Private Sub showLabels()
        Dim rs As ADODB.Recordset
        Dim lvItem As System.Windows.Forms.ListViewItem
        rs = getRS("SELECT Label.* From Label WHERE (((Label.Label_Type)=" & gType & ")) ORDER BY LabelID;")
        Me.lstBarcode.Items.Clear()
        Dim m As Integer
        Do Until rs.EOF
            m = Me.lstBarcode.Items.Add(rs.Fields("Label_Name").Value & " (" & "W" & rs.Fields("Label_Width").Value & "mm X H" & rs.Fields("Label_Height").Value & "mm)")
            lstBarcode.Items.Add(New SetItemData(m, rs.Fields("labelID").Value))

            rs.MoveNext()
        Loop

        rs = getRS("SELECT * FROM PrinterOftenUsed")
        On Error Resume Next
        If TheErr <> -2147217865 Then
            If gType = 2 Then
                lstBarcode.SelectedIndex = rs.Fields("LabelIndex").Value
            ElseIf gType = 1 Then
                lstBarcode.SelectedIndex = rs.Fields("ShelfIndex").Value
            End If
        End If
    End Sub

    Private Sub printStock()
        Dim sql As String
        Dim rs As ADODB.Recordset
        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays "
        sql = sql & "FROM Company, Label, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) "
        sql = sql & "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Label.LabelID)=" & CInt(lstBarcode.SelectedIndex) & ")); "
        rs = getRS(sql)
        If rs.RecordCount Then

            'Checks if the barcode/Shelf Talker button is clicked and displays the correct button.
            If _optBarcode_2.Checked = True Then
                If MsgBox("You have selected " & rs.RecordCount & " products to print." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT BARCODES") = MsgBoxResult.Yes Then
                    If CDbl(lblPrinterType.Tag) = 1 Then
                        printStockBarcode(rs)

                    ElseIf CDbl(lblPrinterType.Tag) = 2 Then
                        printStockA4(rs)

                    ElseIf CDbl(lblPrinterType.Tag) = 3 Then
                        PrintBarcodeDatamax(rs)
                    End If
                End If
            ElseIf _optBarcode_1.Checked = True Then
                If MsgBox("You have selected " & rs.RecordCount & " products to print." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT SHELF TALKER") = MsgBoxResult.Yes Then
                    If CDbl(lblPrinterType.Tag) = 1 Then
                        printStockBarcode(rs)
                    ElseIf CDbl(lblPrinterType.Tag) = 2 Then
                        'If InStr(LCase(lblPrinter), "label") Then
                        printStockA4(rs)
                        'Else
                        '    printStockA4_OLD rs
                        'End If
                    ElseIf CDbl(lblPrinterType.Tag) = 3 Then
                        PrintBarcodeDatamax(rs)
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub printStockBarcode(ByRef rs As ADODB.Recordset)
        Dim fso As New Scripting.FileSystemObject
        Dim lStream As Scripting.TextStream
        Dim lString As String
        Dim lArray As String()
        Dim lText As String
        Dim x As Short
        Do Until rs.EOF
            lString = rs.Fields("label_textstream").Value
            lArray = Split(lString, vbCrLf)
            lString = ""

            For x = 0 To UBound(lArray)
                lText = lArray(x)
                lString = lString & vbCrLf & doString(lText, rs)
            Next x
            lStream = fso.OpenTextFile("c:\aa.txt", Scripting.IOMode.ForWriting, True)
            lStream.Write(lString)
            lStream.Close()
            lString = "C:\AA.TXT"
            Call SpoolFile(lString, (lblPrinter.Text))

            rs.MoveNext()
        Loop
    End Sub

    Private Function doString(ByRef lString As String, ByRef rs As ADODB.Recordset) As String
        Dim x As Short
        Dim lString1 As String
        Dim lString2 As String
        Dim lText As String
        Dim rsP As ADODB.Recordset
        Dim rsShrink As ADODB.Recordset

        If Len(lString) > 15 Then
            lText = Mid(lString, 16)
            If InStr(lText, "COMPANY NAME CENTER") Then
                doString = VB.Left(lString, 15) & doCenter(lText, rs.Fields("Company_Name").Value)
                Exit Function
            End If
            If InStr(lText, "COMPANY NAME LEFT") Then
                doString = VB.Left(lString, 15) & VB.Left(rs.Fields("Company_Name").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "COMPANY NAME RIGHT") Then
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rs.Fields("Company_Name").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "TELEPHONE CENTER") Then
                doString = VB.Left(lString, 15) & doCenter(lText, rs.Fields("Company_Telephone").Value)
                Exit Function
            End If
            If InStr(lText, "TELEPHONE LEFT") Then
                doString = VB.Left(lString, 15) & VB.Left(rs.Fields("Company_Telephone").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "TELEPHONE RIGHT") Then
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rs.Fields("Company_Telephone").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "PRICEXXXXX") Then
                doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & rs.Fields("Price").Value, Len(lText)))
                Exit Function
            End If
            If InStr(lText, "PRICEX") Then
                doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & Split(rs.Fields("Price").Value & ".00", ".")(0), Len(lText)))
                Exit Function
            End If


            If InStr(lText, "PRIC4XXXXX") Then
                doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & rs.Fields("Price").Value, Len(lText)))
                Exit Function
            End If
            If InStr(lText, "PRIC1XXXXX") Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                    Else
                                        'doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If

                Exit Function
            End If
            If InStr(lText, "PRIC2XXXXX") Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                    Else
                                        'doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If
            If InStr(lText, "PRIC3XXXXX") Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) & " FOR  ", Len(lText)))
                                    Else
                                        'doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
                                    End If
                                End If
                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If

            If lText = "S1" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("PriceChannelLnk_Quantity").Value, Len(lText))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("CatalogueChannelLnk_Quantity").Value, Len(lText))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If

                Exit Function
            End If
            If lText = "S2" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("PriceChannelLnk_Quantity").Value, Len(lText))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("CatalogueChannelLnk_Quantity").Value, Len(lText))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If
            If lText = "S3" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("PriceChannelLnk_Quantity").Value, Len(lText))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rsP.Fields("CatalogueChannelLnk_Quantity").Value, Len(lText))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If

            If lText = "(P1 ea)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If

                Exit Function
            End If
            If lText = "(P2 ea)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If
            If lText = "(P3 ea)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If


            If lText = "(P1 EA)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If

                Exit Function
            End If
            If lText = "(P2 EA)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            ElseIf x = 2 Then

                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If
            If lText = "(P3 EA)" Then
                rsShrink = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " & rs.Fields("StockItemID").Value & ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;")
                x = 0
                If rsShrink.RecordCount > 0 Then
                    Do Until rsShrink.EOF

                        If rsShrink.Fields("ShrinkItem_Quantity").Value > 1 Then
                            If x = 0 Then

                                x = x + 1
                            ElseIf x = 1 Then

                                x = x + 1
                            ElseIf x = 2 Then
                                rsP = getRS("SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;")
                                If rsP.RecordCount > 0 Then
                                    doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("PriceChannelLnk_Price").Value, rsP.Fields("PriceChannelLnk_Price").Value, 1) / IIf(rsP.Fields("PriceChannelLnk_Quantity").Value, rsP.Fields("PriceChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                Else
                                    rsP = getRS("SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " & rsShrink.Fields("StockItemID").Value & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " & rsShrink.Fields("ShrinkItem_Quantity").Value & ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;")
                                    If rsP.RecordCount > 0 Then
                                        doString = VB.Left(lString, 15) & VB.Left("(" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " ea)", Len(" (" & FormatNumber(IIf(rsP.Fields("CatalogueChannelLnk_Price").Value, rsP.Fields("CatalogueChannelLnk_Price").Value, 1) / IIf(rsP.Fields("CatalogueChannelLnk_Quantity").Value, rsP.Fields("CatalogueChannelLnk_Quantity").Value, 1), 2) & " EA)"))
                                    Else

                                    End If
                                End If
                                x = x + 1
                            End If

                        End If

                        rsShrink.MoveNext()
                    Loop
                End If
                Exit Function
            End If

            If lText = "CCCC MM" Then
                'doString = Left(lString, 15) & Replace(lText, lText, Left(String(Len(lText), " ") & Year(Now) & " " & Month(Now), Len(lText)))
                doString = VB.Left(lString, 15) & VB.Left(Year(Now) & " " & Month(Now), Len(lText))
                Exit Function
            End If

            If lText = "XX" Then 'If InStr(lText, "XX") Then
                doString = VB.Left(lString, 15) & Replace(lText, lText, VB.Right(New String(" ", Len(lText)) & Split(rs.Fields("Price").Value, ".")(1), Len(lText)))
                Exit Function
            End If
            If InStr(lText, "DEPARTMENT CENTER") Then
                doString = VB.Left(lString, 15) & doCenter(lText, rs.Fields("PricingGroup_Name").Value)
                Exit Function
            End If
            If InStr(lText, "DEPARTMENT LEFT") Then
                doString = VB.Left(lString, 15) & VB.Left(rs.Fields("PricingGroup_Name").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "DEPARTMENT RIGHT") Then
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rs.Fields("PricingGroup_Name").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "BARREAD CENTER") Then
                doString = VB.Left(lString, 15) & doCenter(lText, rs.Fields("Catalogue_Barcode").Value)
                Exit Function
            End If
            If InStr(lText, "BARREAD LEFT") Then
                doString = VB.Left(lString, 15) & VB.Left(rs.Fields("Catalogue_Barcode").Value, Len(lText))
                Exit Function
            End If
            If InStr(lText, "BARREAD RIGHT") Then
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rs.Fields("Catalogue_Barcode").Value, Len(lText))
                Exit Function
            End If

            If InStr(lText, "BARCODEXXXXXX") Then
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & rs.Fields("Catalogue_Barcode").Value, Len(lText))
                Exit Function
            End If

            If InStr(lText, "NAME 1 CENTER") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & doCenter(lText, lString1)
                Exit Function
            End If
            If InStr(lText, "NAME 1 LEFT") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & VB.Left(lString1, Len(lText))
                Exit Function
            End If
            If InStr(lText, "NAME 1 RIGHT") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & lString1, Len(lText))
                Exit Function
            End If

            If InStr(lText, "NAME 2 CENTER") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & doCenter(lText, lString2)
                Exit Function
            End If
            If InStr(lText, "NAME 2 LEFT") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & VB.Left(lString2, Len(lText))
                Exit Function
            End If
            If InStr(lText, "NAME 2 RIGHT") Then
                lString1 = rs.Fields("Stockitem_Name").Value
                If rs.Fields("Catalogue_Quantity").Value <> 1 Then lString1 = rs.Fields("Catalogue_Quantity").Value & "X" & lString1
                splitString(Len(lText), lString1, lString2)
                doString = VB.Left(lString, 15) & VB.Right(New String(" ", Len(lText)) & lString2, Len(lText))
                Exit Function
            End If
            If InStr(lText, "DATE") Then
                lString1 = Format(Now, "yymm")
                doString = VB.Left(lString, 15) & Format(Now, "yymm")
                Exit Function
            End If

            'Expiry Date
            If InStr(lText, "SELL BY") Then
                'lString1 = Format((Now() + rs("StockItem_ExpiryDays")), "dd/mm/yy")
                'doString = Left(lString, 15) & Format((Now() + rs("StockItem_ExpiryDays")), "dd/mm/yy")
                lString1 = rs.Fields("StockItem_ExpiryDays").Value
                doString = VB.Left(lString, 15) & rs.Fields("StockItem_ExpiryDays").Value
                Exit Function
            End If

            If lText = "BARCODE" Then
                'If InStr(lText, "BARCODE") Then
                If doCheckSum(rs.Fields("Catalogue_Barcode").Value) Then
                Else
                    doString = VB.Left(lString, 15) & rs.Fields("Catalogue_Barcode").Value
                End If
                Exit Function
            End If
            If InStr(lText, "600106007141") Then
                If doCheckSum(rs.Fields("Catalogue_Barcode").Value) Then
                    doString = VB.Left(lString, 15) & VB.Left(rs.Fields("Catalogue_Barcode").Value & "0000", 13)
                End If
                Exit Function
            End If
            doString = lString
        Else
            If lString = "Q0001" Then
                doString = Replace(lString, "Q0001", "Q" & VB.Right("0000" & rs.Fields("barcodePersonLnk_PrintQTY").Value, 4))
            Else
                doString = lString
            End If
        End If
    End Function

    Private Function doCheckSum(ByRef lString As String) As Boolean
        Dim lAmount As Short
        Dim code As String
        Dim i As Short
        Dim value As String
        value = lString
        doCheckSum = False
        If InStr(value, "0") Then
            Do Until CDbl(VB.Left(value, 1)) <> 0
                value = Mid(value, 2)
            Loop
        End If
        If Len(value) > 9 Then value = VB.Left(value & "00000", 13)
        If Len(value) <> 13 Then Exit Function
        If value = "" Then Exit Function
        If InStr(value, ".") Then
            doCheckSum = False
        Else
            If IsNumeric(value) Then
                lAmount = 0
                For i = 1 To Len(value) - 1
                    code = VB.Left(value, i)
                    code = VB.Right(code, 1)
                    If i Mod 2 Then
                        lAmount = lAmount + CShort(code)
                    Else
                        lAmount = lAmount + CShort(code) * 3
                    End If
                Next
                lAmount = 10 - (lAmount Mod 10)
                If lAmount = 10 Then lAmount = 0
                doCheckSum = lAmount = CShort(VB.Right(value, 1))
            Else
                doCheckSum = False
            End If
        End If
    End Function

    Public Function doCenter(ByRef origText As String, ByRef newText As String) As String
        Dim newstring As String
        If Len(origText) > Len(newstring) Then
            If CShort((Len(origText) - Len(newText)) / 2) >= 0 Then
                doCenter = New String(" ", CShort((Len(origText) - Len(newText)) / 2)) & newText
            Else
                doCenter = VB.Left(newText, Len(origText))
            End If
        Else
            doCenter = VB.Left(newText, Len(origText))
        End If

    End Function

    Private Sub splitStringA4(ByRef lObject As Label, ByRef lWidth As Integer, ByRef HeadingString1 As String, ByRef HeadingString2 As String)
        Dim Printer As New Printing.PrintDocument
        Dim y As Short
        Dim x As Short
        Dim lHeading As String
        lHeading = HeadingString1
        HeadingString1 = lHeading & " "
        HeadingString2 = ""
        If (lWidth - lObject.Width) < 0 Then
            For x = Len(lHeading) + 1 To 1 Step -1
                HeadingString1 = VB.Left(lHeading, x)
                If (lWidth - lObject.Width + 50) > 0 Then
                    For y = Len(HeadingString1) + 1 To 1 Step -1
                        If VB.Right(VB.Left(HeadingString1, y), 1) = " " Then

                            HeadingString1 = VB.Left(HeadingString1, y - 1)
                            If (lHeading <> HeadingString1) Then
                                HeadingString2 = VB.Right(lHeading, Len(lHeading) - Len(HeadingString1))
                            End If
                            Exit For
                        End If
                    Next y
                    Exit For
                End If
            Next
        End If
        If HeadingString2 = "" Then
            HeadingString2 = HeadingString1
            HeadingString1 = ""
        Else
            Do Until Printer.DefaultPageSettings.Bounds.Width <= lWidth
                'Do Until Printer.PrinterSettings.TextWidth(HeadingString2) <= lWidth
                HeadingString2 = Mid(HeadingString2, 1, Len(HeadingString2) - 1)
            Loop
        End If
        HeadingString1 = Trim(HeadingString1)
        HeadingString2 = Trim(HeadingString2)
    End Sub

    Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdnext.Click
        lstBarcode_DoubleClick(lstBarcode, New System.EventArgs())
    End Sub

    Private Sub cndExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cndExit.Click
        Me.Close()
    End Sub
    Private Sub frmBarcode_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        optBarcode.AddRange(New RadioButton() {_optBarcode_1, _optBarcode_2})
        Dim rb As New RadioButton
        For Each rb In optBarcode
            AddHandler rb.CheckedChanged, AddressOf optBarcode_CheckedChanged
        Next
        Dim Printer As New Printing.PrintDocument
        Dim rs As ADODB.Recordset
        On Error Resume Next

        Dim TheBarcodePrName As String
        Dim lPrinter As String

        lPrinter = frmPrinter.selectPrinter()

        loadLanguage()

        If lPrinter = "" Then
            Me.Close()
            Exit Sub
        Else

            rs = getRS("SELECT * FROM PrinterOftenUsed")
            If rs.RecordCount Then
                lblPrinter.Text = lPrinter
                If rs("PrinterType").Value = 2 Then
                    lblPrinterType.Tag = 1
                    lblPrinterType.Text = "Argox Barcode Printer"
                ElseIf rs("PrinterType").Value = 3 Then  ' Printer.Width <= 9000 Then  'TheBarcodePrName = "Datamax Allegro" Then 'if Printer.Width <= 9000 then or if Name= DatamaxNew code for Datamax Allegro still busy
                    lblPrinterType.Tag = 3
                    lblPrinterType.Text = "Other Printer"
                ElseIf rs("PrinterType").Value = 1 Then
                    lblPrinterType.Tag = 2
                    lblPrinterType.Text = "A4 Printer"
                End If
            Else
                lblPrinter.Text = lPrinter
                If InStr(LCase(Printer.PrinterSettings.PrinterName), "label") Then
                    lblPrinterType.Tag = 1
                    lblPrinterType.Text = "Argox Barcode Printer"
                ElseIf Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width <= 9000 Then  'TheBarcodePrName = "Datamax Allegro" Then 'if Printer.Width <= 9000 then or if Name= DatamaxNew code for Datamax Allegro still busy
                    'a = Printer.Height
                    lblPrinterType.Tag = 3
                    lblPrinterType.Text = "Other Barcode Printer"
                Else
                    lblPrinterType.Tag = 2
                    lblPrinterType.Text = "A4 Printer"
                End If
            End If
            gType = 2
            showLabels()
        End If

        'Set rs = getRS("SELECT * FROM PrinterOftenUsed")
        If TheErr <> -2147217865 Then
            If gType = 2 Then
                'stBarcode.SelectedIndex = rs("LabelIndex")
            ElseIf gType = 1 Then
                lstBarcode.SelectedIndex = rs("ShelfIndex").Value
            End If
        End If
    End Sub

    Private Sub lstBarcode_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBarcode.DoubleClick
        Dim rs As New ADODB.Recordset
        Dim lID As Integer
        Dim sBCode As String
        Dim cQTY As Decimal

        rs = getRS("SELECT * FROM PrinterOftenUsed")

        If rs.RecordCount > 0 Then
            If gType = 2 Then
                rs = getRS("UPDATE PrinterOftenUsed SET PrinterIndex=" & rs("PrinterIndex").Value.ToString & " ,LabelIndex = " & lstBarcode.SelectedIndex.ToString & " WHERE PrinterIndex=" & rs("PrinterIndex").Value.ToString & "")
            ElseIf gType = 1 Then
                rs = getRS("UPDATE PrinterOftenUsed SET PrinterIndex=" & rs("PrinterIndex").Value.ToString & " ,ShelfIndex=" & lstBarcode.SelectedIndex.ToString & " WHERE PrinterIndex=" & rs("PrinterIndex").Value.ToString & "")
            End If
        Else
        End If

        If lstBarcode.SelectedIndex <> -1 Then
            Select Case gType
                Case 1, 2
                    If scaleBCPrint = True Then

                        lID = frmStockList.getItem
                        If lID <> 0 Then
                            On Error Resume Next
                            If frmBarcodeScaleItem.loadItem(lID, cQTY, sBCode) Then
                                printStockScale(cQTY, sBCode)
                                'scaleBCPrint = False
                            End If
                        End If
                    Else
                        'old way
                        If frmBarcodeStockitem.loadStock Then
                            printStock()
                        End If
                    End If
                Case Else
            End Select
        End If
    End Sub

    Private Sub printStockScale(Optional ByRef cQuantity As Decimal = 0, Optional ByRef sBCode As String = "")
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim x As Short
        Dim C As Short
        Dim D As Short
        Dim CD As Short
        Dim strCD As String
        x = 0
        C = 0
        D = 0
        CD = 0
        strCD = ""

        Dim wCodemvarCodeID As String
        Dim wCodemvarLenPrice As String
        Dim code As String
        Dim chkInput As String

        chkInput = CStr(1)
        wCodemvarCodeID = VB.Right("0000" & sBCode, 4)
        wCodemvarLenPrice = FormatCurrency(cQuantity, 2)
        wCodemvarLenPrice = Replace(wCodemvarLenPrice, "R", "")
        wCodemvarLenPrice = Replace(wCodemvarLenPrice, ",", "")
        wCodemvarLenPrice = Replace(wCodemvarLenPrice, ".", "")
        wCodemvarLenPrice = Replace(wCodemvarLenPrice, " ", "")
        wCodemvarLenPrice = VB.Right("00000" & wCodemvarLenPrice, 5)
        chkInput = CStr(Rnd2(1, 9))
        chkInput = VB.Left(chkInput, 1)
        code = "20" & wCodemvarCodeID & chkInput & wCodemvarLenPrice & "0"
        'New CheckSum code
        ' & format = 4 + 5 (4 digit for item & 5 digit for price)
        'If Val(wCodemvarCodeID) = 4 And Val(wCodemvarLenPrice) = 5 Then
        For x = 1 To 6
            C = C + Val(Mid(code, x * 2, 1))
        Next x
        C = C * 3

        For x = 1 To 6
            D = D + Val(Mid(code, (x * 2) - 1, 1))
        Next x
        CD = C + D

        strCD = Str(CD)
        'CD = 10 - (Val(Right(CD, 1)))
        CD = 10 - (Val(VB.Right(CStr(CD), 1))) : If CD = 10 Then CD = 0

        code = VB.Left(code, 12) & CD
        'End If
        'New CheckSum code

        'sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays "
        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, " & code & " AS Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, '" & FormatCurrency(cQuantity, 2) & "' AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays "
        sql = sql & "FROM Company, Label, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) "
        sql = sql & "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Label.LabelID)=" & CInt(lstBarcode.SelectedIndex) & ")); "
        rs = getRS(sql)
        If rs.RecordCount Then

            'Checks if the barcode/Shelf Talker button is clicked and displays the correct button.
            If _optBarcode_2.Checked = True Then
                If MsgBox("You have selected " & rs.RecordCount & " products to print." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT BARCODES") = MsgBoxResult.Yes Then
                    If CDbl(lblPrinterType.Tag) = 1 Then
                        printStockBarcode(rs)

                    ElseIf CDbl(lblPrinterType.Tag) = 2 Then
                        printStockA4(rs)

                    ElseIf CDbl(lblPrinterType.Tag) = 3 Then
                        PrintBarcodeDatamax(rs)
                    End If
                End If
            ElseIf _optBarcode_1.Checked = True Then
                If MsgBox("You have selected " & rs.RecordCount & " products to print." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT SHELF TALKER") = MsgBoxResult.Yes Then
                    If CDbl(lblPrinterType.Tag) = 1 Then
                        printStockBarcode(rs)
                    ElseIf CDbl(lblPrinterType.Tag) = 2 Then
                        'If InStr(LCase(lblPrinter), "label") Then
                        printStockA4(rs)
                        'Else
                        '    printStockA4_OLD rs
                        'End If
                    ElseIf CDbl(lblPrinterType.Tag) = 3 Then
                        PrintBarcodeDatamax(rs)
                    End If
                End If

            End If
        End If
    End Sub
	
	Private Function Rnd2(ByRef sngLow As Single, ByRef sngHigh As Single) As Single
		Randomize((GetTickCount() + Now.ToOADate())) ' Reseed with system time (2 ways)
		Rnd2 = (Rnd() * (sngHigh - sngLow)) + sngLow
	End Function
	
    Private Sub optBarcode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Integer
            Dim radBtn As New RadioButton
            radBtn = DirectCast(eventSender, RadioButton)
            Index = GetIndexer(radBtn, optBarcode)
            Dim stSring As String
            Dim rsPrinter_B As New ADODB.Recordset
            Dim fso As New Scripting.FileSystemObject

            'Doing shelf from file
            If grvPrin Then
                If fso.FileExists(serverPath & "ShelfBarcode.dat") Then
                    rsPrinter_B.Open(serverPath & "ShelfBarcode.dat")
                    'If Index = 2 Then rsPrinter_B.filter = "StockItem_SBarcode ='barcode'"
                    'If Index = 1 Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"

                    If Index = 2 Then rsPrinter_B.Filter = "StockItem_SBarcode =true"
                    If Index = 1 Then rsPrinter_B.Filter = "StockItem_SShelf =true"
                    If rsPrinter_B.RecordCount > 0 Then
                        'grvPrinType = Index
                    Else
                        If Index = 2 Then stSring = "Barcode Labels"
                        If Index = 1 Then stSring = "Shelf Talkers"
                        MsgBox("There are no StockItem(s) to print " & stSring & " from!.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, My.Application.Info.Title)
                        Me.Close()
                    End If
                Else
                    MsgBox("File " & serverPath & "ShelfBarcode.dat not found.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                    Me.Close()
                End If
            End If
            gType = Index
            showLabels()
        End If
    End Sub
	Private Sub splitString(ByRef Max As Short, ByRef HeadingString1 As String, ByRef HeadingString2 As String)
        Dim lHeading As String
		lHeading = UCase(HeadingString1)
		lHeading = Replace(lHeading, "&", "AND")
		lHeading = Replace(lHeading, "'", "")
		HeadingString1 = lHeading & " "
		HeadingString2 = ""
		
		If Len(lHeading) > Max Then
            HeadingString1 = VB.Left(lHeading, Max + 1)
			Do Until VB.Right(HeadingString1, 1) = " " Or Len(HeadingString1) = 1
				HeadingString1 = VB.Left(HeadingString1, Len(HeadingString1) - 1)
				
			Loop 
			If Len(HeadingString1) = 1 Then
				HeadingString1 = VB.Left(lHeading, 25)
				HeadingString2 = Mid(lHeading, 25, 25)
				
			Else
				HeadingString2 = VB.Left(Trim(Mid(lHeading, Len(HeadingString1))), Max)
			End If
		End If
		
	End Sub
	Private Sub printStockA4(ByRef rs As ADODB.Recordset)
        Dim mm As Decimal
        Dim i As Integer
        Dim lline As Integer
        Dim bGroup As String
        Dim sGroup As String
        Dim lTop As Integer
        Dim lHeight As Integer
        Dim gOffsetLabel As Integer
        Dim dasd As Integer
        Dim Printer As New Printing.PrintDocument
        Dim lObject As New Printing.PrintDocument
		Dim y As Integer
		Dim x As Integer
		Dim rsData As ADODB.Recordset
		Dim currentPic As Integer
		Dim twipsToMM As Integer
		Dim lLeft As Integer
		Dim lWidth As Integer
		Dim lCol, lCols, lRows, lrow As Short
		On Error GoTo Err_printStockA4
        dasd = Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width
        'Printer.PrinterSettings.DefaultPageSettings.ScaleMode = ScaleModeConstants.vbTwips 'twips
        'twipsToMM = Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
        'twipsToMM = twipsToMM / Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
		lObject = Printer
		
		Dim lString1, lString2 As String
		
		rsData = getRS("SELECT * FROM labelItem INNER JOIN label ON labelItem.labelItem_LabelID = label.labelID Where (((label.labelID) = " & rs.Fields("LabelID").Value & ")) ORDER BY label.labelID, labelItem.labelItem_Line;")
		
        lLeft = (lObject.PrinterSettings.DefaultPageSettings.PaperSize.Width - (lWidth)) / 2 + (gOffsetLabel * twipsToMM)
		lLeft = 0
		If rsData.Fields("Label_Rotate").Value Then
			lWidth = rsData.Fields("label_Height").Value * twipsToMM
			lHeight = rsData.Fields("label_Width").Value * twipsToMM
		Else
			lWidth = rsData.Fields("label_width").Value * twipsToMM
			lHeight = rsData.Fields("label_Height").Value * twipsToMM
		End If
		lTop = rsData.Fields("label_Top").Value * twipsToMM
        lCols = CDec(Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width / (lWidth + 60)) - 0.49999
        lRows = CDec(Printer.PrinterSettings.DefaultPageSettings.PaperSize.Height / (lHeight + 60)) - 0.49999
		
		sGroup = "1"
		If InStr(LCase(rsData.Fields("Label_Name").Value), "nursery") Then
			bGroup = "Yes"
		Else
			bGroup = "No"
            printStockA4(rs)
			Exit Sub
		End If
		
		Do Until rs.EOF
			rsData.MoveFirst()
			y = 0
			
            If y < 0 Then y = 0
            'lObject.FontName = "Tahoma"
			rsData.MoveFirst()
			If rsData.RecordCount Then
				lline = rsData.Fields("labelItem_Line").Value
				For i = 1 To rs.Fields("barcodePersonLnk_PrintQTY").Value
					lLeft = IIf(IsDbNull(rsData.Fields("Label_Left").Value), 0, rsData.Fields("Label_Left").Value) * twipsToMM
					'lLeft = 1200 'lCol * (lWidth + 60)

                    'lObject.CurrentY = lrow * (lHeight + 60)
					rsData.MoveFirst()
                    'y = lObject.CurrentY
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
					On Error Resume Next
                    'lObject.Line((lLeft, y) - (lLeft, y + 100))
                    'lObject.Line((lLeft, y) - (lLeft + 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth - 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth, y + 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth, lHeight + y - 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth - 100, lHeight + y))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft, lHeight + y - 100))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft + 100, lHeight + y))
                    'lObject.CurrentY = lrow * (lHeight + 60) + lTop
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    'y = lObject.CurrentY + 10
					Do Until rsData.EOF
						If lline <> rsData.Fields("labelItem_Line").Value Then
                            'y = lObject.CurrentY + 10
							lline = rsData.Fields("labelItem_Line").Value
						End If
						
						Select Case LCase(Trim(rsData.Fields("labelItem_Field").Value))
							Case "blank"
                                'lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                'lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                'lObject.Print(" ")
							Case "line"
                                'lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
							Case "code"
								Select Case rsData.Fields("labelItem_Align").Value
									Case 1
										If bGroup = "Yes" Then
											'Barcode CodeType, txtData, Printer, 15, 700, 3000, 250
											'Barcode "128", rs("Catalogue_Barcode"), lObject, 15, 700, lLeft + 90, Y
											Barcode("128", rs.Fields("Catalogue_Barcode").Value, lObject, 24, 500, 2400, CSng(y))
										Else
                                            'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y)
										End If
									Case 2
										If bGroup = "Yes" Then
											Barcode("128", rs.Fields("Catalogue_Barcode").Value, lObject, 24, 500, 2400, CSng(y))
										Else
											'old line before jonas   printBarcode lObject, rs("Catalogue_Barcode"), lLeft + 90, y
                                            'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y, lWidth + lWidth - 1440)
										End If
									Case Else
										If bGroup = "Yes" Then
											'Barcode "128", rs("Catalogue_Barcode"), lObject, 15, 700, lLeft + 90, Y
											Barcode("128", rs.Fields("Catalogue_Barcode").Value, lObject, 24, 500, 2400, CSng(y)) '3600
											'Barcode "128", "tZst1234", lObject, 24, 700, 2500, 130
										Else
                                            'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft, y, lWidth)
										End If
								End Select
							Case Else
                                'lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                'lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								mm = rsData.Fields("labelItem_Field").Value
								'code for printing shrinks
								
								'code for printing shrinks
								lString1 = rs.Fields(mm).Value
								Select Case rsData.Fields("labelItem_Align").Value
									Case 1
                                        'lObject.PSet(New Point[](lLeft + 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
										
									Case 2
                                        'lObject.PSet(New Point[](lLeft + lWidth - lObject.TextWidth(lString1) - 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
										
									Case 3
                                        'splitStringA4(lObject, lWidth, lString1, lString2)
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        'y = lObject.CurrentY + 10
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										lString1 = lString2
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
									Case Else
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
								End Select
						End Select
						
						If bGroup = "Yes" Then
							'sGroup = "1"
							
							If sGroup <> rsData.Fields("labelItem_Sample").Value Then 'And rs("barcodePersonLnk_PrintQTY") = 1 Then
								If rs.Fields("barcodePersonLnk_PrintQTY").Value = 1 Then
									rs.moveNext()
								ElseIf rs.Fields("barcodePersonLnk_PrintQTY").Value >= 1 Then 
									If i = rs.Fields("barcodePersonLnk_PrintQTY").Value And sGroup = "4" Then
										sGroup = "1"
										Exit Do
									ElseIf i = rs.Fields("barcodePersonLnk_PrintQTY").Value Then 
										rs.moveNext()
										i = 0
									End If
									i = i + 1
								End If
								sGroup = rsData.Fields("labelItem_Sample").Value
							End If
							
							'i = i + 1
							'If i >= rs("barcodePersonLnk_PrintQTY") Then
							'    sGroup = rsData("labelItem_Sample")
							'    'rs.moveNext
							'   Exit Do
							'End If
							If rs.EOF Then Exit Do
						End If
						rsData.moveNext()
					Loop 
					lCol = lCol + 1
					If lCol >= lCols Then
						lCol = 0
						lrow = lrow + 1
                        'If (lrow + 1) * lHeight > lObject.Height Then
                        ' Printer.NewPage()
                        ' If bGroup = "Yes" Then
                        ' lrow = 0 '-1
                        'Else
                        '   lrow = -1
                        ' End If
                        'End If
                    End If
            If sGroup = "4" Then sGroup = "1"
				Next 
			End If
			If bGroup = "Yes" Then
				If rs.EOF Then Exit Do
				If sGroup = "4" Then sGroup = "1"
			End If
			rs.moveNext()
		Loop 
        'Printer.EndDoc()
		
		Exit Sub
Err_printStockA4: 
		'MsgBox Err.Description
		Resume Next
	End Sub
    Public Sub printBarcode(ByRef barcodePicture As PictureBox, ByRef lValue As String, ByRef lLeft As Integer, ByRef lTop As Integer, Optional ByRef lWidth As Integer = 0)
        Dim BF As Integer
        Dim x As Short
        Dim y As Short
        Dim lXML As String
        Dim lastArray, oddArray, evenArray, parityArray As String()
        Dim lString, codeType, code, lCode, HeadingString1 As String
        Dim HeadingString2 As String
        Dim i, j As Integer
        Dim cnt As Short
        Dim barArray As String()
        lXML = ""
        If doCheckSum(lValue) Then
            oddArray = New String() {"0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011"}
            evenArray = New String() {"0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
            lastArray = New String() {"1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"}
            parityArray = New String() {"111111", "110100", "110010", "110001", "101100", "100110", "100011", "101010", "101001", "100101"}
            code = VB.Left(lValue, 1)
            code = VB.Right(code, 1)
            codeType = parityArray(CShort(code))

            lXML = lXML & doImage("101", 1)
            For i = 2 To 7
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lCode = VB.Left(codeType, i - 1)
                lCode = VB.Right(lCode, 1)
                If lCode = "0" Then
                    lXML = lXML & doImage(evenArray(code), 0)
                Else
                    lXML = lXML & doImage(oddArray(code), 0)
                End If
            Next
            lXML = lXML & doImage("01010", 1)
            For i = 8 To 13
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lXML = lXML & doImage(lastArray(code), 0)
            Next
            lXML = lXML & doImage("101", 1)
        Else
            lString = lValue
            For i = 1 To Len(lString)
                If CDbl(VB.Left(lString, 1)) = 0 Then
                    lString = VB.Right(lString, Len(lString) - 1)
                Else
                    Exit For
                End If
            Next
            lValue = lString

            oddArray = New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "-", ".", " ", "$", "/", "+", "%", "~", ","}
            evenArray = New String() {"111331311", "311311113", "113311113", "313311111", "111331113", "311331111", "113331111", "111311313", "311311311", "113311311", "311113113", "113113113", "313113111", "111133113", "311133111", "113133111", "111113313", "311113311", "113113311", "111133311", "311111133", "113111133", "313111131", "111131133", "311131131", "113131131", "111111333", "311111331", "113111331", "111131331", "331111113", "133111113", "333111111", "131131113", "331131111", "133131111", "131111313", "331111311", "133111311", "131131311", "131313111", "131311131", "131113131", "111313131", "1311313111131131311"}

            lString = "131131311"
            lString = lString + "1"
            For i = 1 To Len(lValue)
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                code = UCase(code)
                For j = 0 To UBound(oddArray)
                     If code = oddArray(j) Then
                        lString = lString + evenArray(j)
                        lString = lString + "1"
                        j = 9999
                    End If
                Next
            Next
            lString = lString + "131131311"

            For i = 1 To Len(lString)
                code = VB.Left(lString, i)
                code = VB.Right(code, 1)
                For j = 1 To CShort(code)
                    lCode = VB.Left(code, i)
                    lCode = VB.Right(lCode, 1)
                    If i Mod 2 Then
                        lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
                    Else
                        lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
                    End If
                    lXML = lXML & "20|"
                Next
            Next
        End If

        barArray = Split(lXML, "|")
        y = lTop
        If lWidth = 0 Then
            x = lLeft
        Else
            x = CShort(lLeft + (lWidth - UBound(barArray) * twipsPerPixel(True) / 2))
        End If
        For cnt = LBound(barArray) To UBound(barArray)
            If barArray(cnt) <> "" Then
                If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then

                    'barcodePicture.Line((x + cnt * twipsPerPixel(true), y) - (_
                    '        x + (cnt + 1) * twipsPerPixel(true), _
                    '        y + CInt(Split(barArray(cnt), "~")(1)) _
                    '        * twipsPerPixel(True)), CInt(Split(barArray(cnt), "~")(0)), BF)
                End If
            End If

        Next
    End Sub

    Function doImage(ByRef code As String, ByRef size_Renamed As Integer) As String
        Dim lXML As String
        Dim lCode As String
        Dim i As Short
        For i = 1 To Len(code)
            lCode = VB.Left(code, i)
            lCode = VB.Right(lCode, 1)
            If lCode = "0" Then
                lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
            Else
                lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
            End If
            If (size_Renamed) Then
                lXML = lXML & 30 & "|"
            Else
                lXML = lXML & 25 & "|"
            End If
        Next
        doImage = lXML
    End Function

    Public Function PrintBarcodeDatamax(ByRef rs As ADODB.Recordset) As Boolean
        Dim sql As String
        Dim mm As String
        Dim i As Integer
        Dim lline As Integer
        Dim lTop As Integer
        Dim lHeight As Integer
        Dim Printer As New Printing.PrintDocument
        Dim lObject As New Printing.PrintDocument
        Dim y As Integer
        Dim x As Integer
        Dim rsData As ADODB.Recordset
        Dim currentPic As Integer
        Dim twipsToMM As Integer
        Dim lLeft As Integer
        Dim lWidth As Integer
        Dim lCol, lCols, lRows, lrow As Short

        Dim rsPrice As ADODB.Recordset

        'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
        'twipsToMM = Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
        'twipsToMM = twipsToMM / Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
        lObject = Printer

        Dim lString1, lString2 As String
        rsData = getRS("SELECT * FROM labelItem INNER JOIN label ON labelItem.labelItem_LabelID = label.labelID Where (((label.labelID) = " & rs.Fields("LabelID").Value & ")) ORDER BY label.labelID, labelItem.labelItem_Line;")
        'lLeft = (lObject.Width - (lWidth)) / 2 + (gOffsetLabel * twipsToMM)

        lLeft = 0
        If rsData.Fields("Label_Rotate").Value Then
            lWidth = rsData.Fields("label_Height").Value * twipsToMM
            lHeight = rsData.Fields("label_Width").Value * twipsToMM
        Else
            lWidth = rsData.Fields("label_width").Value * twipsToMM
            lHeight = rsData.Fields("label_Height").Value * twipsToMM
        End If
        lTop = rsData.Fields("label_Top").Value * twipsToMM
        'lCols = CDec(Printer.Width / (lWidth + 60)) - 0.49999
        'lRows = CDec(Printer.Height / (lHeight + 60)) - 0.49999

        Do Until rs.EOF
            rsData.MoveFirst()
            y = 0

            'If y < 0 Then y = 0
            'lObject.FontName = "Tahoma"
            rsData.MoveFirst()
            If rsData.RecordCount Then
                lline = rsData.Fields("labelItem_Line").Value

                For i = 1 To rs.Fields("barcodePersonLnk_PrintQTY").Value
                    lLeft = IIf(IsDBNull(rsData.Fields("Label_Left").Value), 0, rsData.Fields("Label_Left").Value) * twipsToMM
                    'lObject.CurrentY = lrow * (lHeight + 60)
                    rsData.MoveFirst()
                    'y = lObject.CurrentY
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
                    On Error Resume Next
                    'lObject.Line((lLeft, y) - (lLeft, y + 100))
                    'lObject.Line((lLeft, y) - (lLeft + 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth - 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth, y + 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth, lHeight + y - 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth - 100, lHeight + y))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft, lHeight + y - 100))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft + 100, lHeight + y))
                    'lObject.CurrentY = lrow * (lHeight + 60) + lTop
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    'y = lObject.CurrentY + 10

                    Do Until rsData.EOF
                        If lline <> rsData.Fields("labelItem_Line").Value Then
                            'y = lObject.CurrentY + 10

                            lline = rsData.Fields("labelItem_Line").Value
                        End If

                        Select Case LCase(Trim(rsData.Fields("labelItem_Field").Value))
                            Case "blank"
                                'lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                'lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                'lObject.Print(" ")
                            Case "line"
                                'lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))

                            Case "code"
                                Select Case rsData.Fields("labelItem_Align").Value
                                    Case 1
                                        'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y)
                                    Case 2
                                        'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y, lWidth + lWidth - 1440)
                                    Case Else
                                        'printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft, y, lWidth)
                                End Select

                            Case Else
                                'lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                'lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                mm = rsData.Fields("labelItem_Field").Value
                                'code for printing shrinks
                                If mm = "Price6" Then
                                    sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price "
                                    sql = sql & "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                                    sql = sql & "WHERE (((StockItem.StockItemID)=" & rs.Fields("StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=6) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=6) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
                                    rsPrice = getRS(sql)
                                    If rsPrice.RecordCount Then
                                        lString1 = rsPrice.Fields("Price").Value & " FOR   6"
                                    Else
                                        lString1 = " "
                                    End If

                                ElseIf mm = "Price12" Then
                                    sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price "
                                    sql = sql & "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                                    sql = sql & "WHERE (((StockItem.StockItemID)=" & rs.Fields("StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=12) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=12) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
                                    rsPrice = getRS(sql)
                                    If rsPrice.RecordCount Then
                                        lString1 = rsPrice.Fields("Price").Value & " FOR  12"
                                    Else
                                        lString1 = " "
                                    End If

                                ElseIf mm = "Price24" Then
                                    sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price "
                                    sql = sql & "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                                    sql = sql & "WHERE (((StockItem.StockItemID)=" & rs.Fields("StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=24) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=24) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
                                    rsPrice = getRS(sql)
                                    If rsPrice.RecordCount Then
                                        lString1 = rsPrice.Fields("Price").Value & " FOR  24"
                                    Else
                                        lString1 = " "
                                    End If
                                Else
                                    lString1 = rs.Fields(mm).Value
                                End If
                                'code for printing shrinks

                                'lString1 = rs(mm)
                                Select Case rsData.Fields("labelItem_Align").Value
                                    Case 1

                                        'lObject.PSet(New Point[](lLeft + 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)

                                    Case 2
                                        'lObject.PSet(New Point[](lLeft + lWidth - lObject.TextWidth(lString1) - 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                    Case 3
                                        'splitStringA4(lObject, lWidth, lString1, lString2)
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        'y = lObject.CurrentY + 10

                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        lString1 = lString2
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)

                                    Case Else
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))

                                        ' lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        ' lObject.Print(lString1)
                                End Select
                        End Select
                        rsData.MoveNext()
                    Loop

                    'New code for tesing barcode printing

                    'Printer.NewPage()

                Next
            End If
            rs.MoveNext()
        Loop
        'Printer.EndDoc()
    End Function
End Class