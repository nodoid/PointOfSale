Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPricingMatrix
	Inherits System.Windows.Forms.Form
	Dim loading As Boolean
	Dim gID As Integer
    Dim gDataArray() As Object
    Dim lblColorFixed As New List(Of Label)
    Dim lblcolor As New List(Of Label)
    Dim txtUnit As New List(Of TextBox)
    Dim txtCase As New List(Of TextBox)
	
	Private Sub loadLanguage()
		
		'frmPricingMatrix = No Code [Detailed Pricing Matrices]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPricingMatrix.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricingMatrix.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Function Unknown!
		'Command1 = No Code     []
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Note: Field is Dynamic with Default as below!
		'lblHeading = No Code   [Default Pricing Matrix for each Channel]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code       [Unit Markup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_5 = No Code       [Case/Carton Markup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblPricingGroup(1) = No Code
		'lblPricingGroup(2) = No Code
		'lblPricingGroup(3) = No Code
		'lblPricingGroup(4) = No Code
		'lblPricingGroup(5) = No Code
		'lblPricingGroup(6) = No Code
		'lblPricingGroup(7) = No Code
		'lblPricingGroup(8) = No Code
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPricingMatrix.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		Dim x As Short
		rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		With gridItem
			.RowCount = 2
            .Col = 10
			' Set FixedRows to 0 so you can use AddItem. You can't
			' use AddItem with a FixedRow. You have to use the Text property
			.FixedRows = 0
            '.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeFree 'Set the MergeCells property.
			.row = 0
			.Col = 0
			.set_ColWidth(0, 1300)
			.set_ColWidth(1, 700)
			.set_ColWidth(2, 700)
			.set_ColWidth(3, 700)
			.set_ColWidth(4, 700)
			.set_ColWidth(5, 700)
			.set_ColWidth(6, 700)
			.set_ColWidth(7, 700)
			.set_ColWidth(8, 700)
			.set_ColWidth(9, 700)
			.set_TextMatrix(0, 0, "Pack")
			.set_TextMatrix(0, 0, "QTY")
			rs.MoveFirst()
			For x = 0 To 7
				.set_TextMatrix(0, x + 2, rs.Fields("Channel_Code").Value)
				rs.moveNext()
			Next 
			.FixedCols = 2
			.FixedRows = 1
			
		End With
	End Sub
	
	Private Sub setup_NEW()
		Dim rs As ADODB.Recordset
		Dim x As Short
		rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		With gridItem
			.RowCount = 2
            .Col = 10
			' Set FixedRows to 0 so you can use AddItem. You can't
			' use AddItem with a FixedRow. You have to use the Text property
			.FixedRows = 0
            '.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeFree 'Set the MergeCells property.
			.row = 0
			.Col = 0
			.set_ColWidth(0, 1300)
			.set_ColWidth(1, 700)
			.set_ColWidth(2, 700)
			.set_ColWidth(3, 700)
			.set_ColWidth(4, 700)
			.set_ColWidth(5, 700)
			.set_ColWidth(6, 700)
			.set_ColWidth(7, 700)
			.set_ColWidth(8, 700)
			.set_ColWidth(9, 700)
			.set_TextMatrix(0, 0, "Pack")
			'.TextMatrix(0, 0) = "SHRINKS"
			.set_TextMatrix(0, 0, " ")
			.set_TextMatrix(0, 1, "QTY")
			rs.MoveFirst()
			For x = 0 To 7
				.set_TextMatrix(0, x + 2, rs.Fields("Channel_Code").Value)
				rs.moveNext()
			Next 
			.FixedCols = 2
			.FixedRows = 1
			
		End With
	End Sub
	
	Public Sub loadMatrix(ByRef id As Integer)
		loading = True
        Dim x, lCNT As Integer
		Dim lDepositQuantity As Short
		Dim rsMaster As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim lPackSizeID As Integer
		Dim lColour As Boolean
		gID = id
		setup()
		rs = getRS("SELECT PricingGroup.* From PricingGroup WHERE (((PricingGroup.PricingGroupID)=" & gID & "));")
		If rs.BOF Or rs.EOF Then
			Me.Close()
			End
		Else
			lblHeading.Text = rs.Fields("PricingGroup_Name").Value
			For x = 1 To 8
				txtUnit(x).Text = FormatNumber(rs.Fields("PricingGroup_Unit" & x).Value, 2)
				txtCase(x).Text = FormatNumber(rs.Fields("PricingGroup_Case" & x).Value, 2)
			Next x
			
		End If
		rs.Close()
		rsMaster = getRS("SELECT shrink.PricingGroup, PackSize.PackSizeID, PackSize.PackSize_Name, shrink.Quantity FROM [SELECT StockItem.StockItem_PricingGroupID AS PricingGroup, ShrinkItem.ShrinkItem_Quantity AS Quantity, StockItem.StockItem_PackSizeID AS PackSizeID FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID GROUP BY StockItem.StockItem_PricingGroupID, ShrinkItem.ShrinkItem_Quantity, StockItem.StockItem_PackSizeID]. AS shrink LEFT JOIN PackSize ON shrink.PackSizeID = PackSize.PackSizeID Where (((shrink.PricingGroup) = " & gID & ")) ORDER BY PackSize.PackSize_Volume, PackSize.PackSizeID, shrink.Quantity;")
		txtEdit.Visible = False
		With gridItem
			.RowCount = 1
			.Visible = False
            lCNT = -1
			Do Until rsMaster.EOF
				If lPackSizeID <> rsMaster.Fields("PackSizeID").Value Then
                    lColour = Not lColour
                    .Rows.Add(rsMaster.Fields("PackSize_Name").Value)
					lPackSizeID = rsMaster.Fields("PackSizeID").Value
				Else
                    .Rows.Add("")
				End If
				.row = .RowCount - 1
				.Col = 0
                .CellBackColor = lblColorFixed(System.Math.Abs(CShort(lColour))).BackColor
				.Col = 1
				.CellBackColor = lblColorFixed(System.Math.Abs(CShort(lColour))).BackColor
				.Text = rsMaster.Fields("quantity").Value
				.set_RowData(.row, rsMaster.Fields("PackSizeID").Value)
				For x = 1 To 8
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Col = x + 1
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsMaster.Fields("PackSizeID").Value & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster.Fields("quantity").Value & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					If rs.BOF Or rs.EOF Then
						.CellBackColor = lblcolor(System.Math.Abs(CShort(lColour))).BackColor
						If rsMaster.Fields("quantity").Value = 1 Then
							.Text = txtUnit(x).Text
						Else
							.Text = txtCase(x).Text
						End If
					Else
						.CellBackColor = lblColorChanged.BackColor
						.Text = FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2)
					End If
					rs.Close()
				Next 
				rsMaster.moveNext()
			Loop 
			
			.Visible = True
			
		End With
		
		loading = False
		If gridItem.RowCount > 1 Then
			gridItem.row = 1
			gridItem.Col = 2
		Else
			txtEdit.Visible = False
		End If
		loading = False
	End Sub
	
	
	Public Sub loadMatrix_NEW(ByRef id As Integer)
		loading = True
        Dim x, lCNT As Integer
		Dim lDepositQuantity As Short
		Dim rsMaster As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim lPackSizeID As Integer
		Dim lColour As Boolean
		gID = id
		setup()
		rs = getRS("SELECT PricingGroup.* From PricingGroup WHERE (((PricingGroup.PricingGroupID)=" & gID & "));")
		If rs.BOF Or rs.EOF Then
			Me.Close()
			End
		Else
			lblHeading.Text = rs.Fields("PricingGroup_Name").Value
			For x = 1 To 8
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtUnit(x).Text = FormatNumber(rs.Fields("PricingGroup_Unit" & x).Value, 2)
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtCase(x).Text = FormatNumber(rs.Fields("PricingGroup_Case" & x).Value, 2)
			Next x
			
		End If
		rs.Close()
		'Old PM
		'Set rsMaster = getRS("SELECT shrink.PricingGroup, PackSize.PackSizeID, PackSize.PackSize_Name, shrink.Quantity FROM [SELECT StockItem.StockItem_PricingGroupID AS PricingGroup, ShrinkItem.ShrinkItem_Quantity AS Quantity, StockItem.StockItem_PackSizeID AS PackSizeID FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID GROUP BY StockItem.StockItem_PricingGroupID, ShrinkItem.ShrinkItem_Quantity, StockItem.StockItem_PackSizeID]. AS shrink LEFT JOIN PackSize ON shrink.PackSizeID = PackSize.PackSizeID Where (((shrink.PricingGroup) = " & gID & ")) ORDER BY PackSize.PackSize_Volume, PackSize.PackSizeID, shrink.Quantity;")
		
		'New PM
		rsMaster = getRS("SELECT PricingGroup.PricingGroupID AS PricingGroup, Shrink.ShrinkID AS ShrinkID, Shrink.Shrink_Name AS Shrink_Name, ShrinkItem.ShrinkItem_Quantity AS Quantity FROM ((Shrink INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID GROUP BY PricingGroup.PricingGroupID, Shrink.ShrinkID, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity HAVING (((PricingGroup.PricingGroupID)=" & gID & ")) ORDER BY ShrinkItem.ShrinkItem_Quantity;")
		
		txtEdit.Visible = False
		With gridItem
			.RowCount = 1
			.Visible = False
			'UPGRADE_WARNING: Couldn't resolve default property of object lCNT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCNT = -1
			Do Until rsMaster.EOF
				
				If .row > 0 Then
					For x = 0 To .row
						'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If gridItem.get_TextMatrix(x, 1) = rsMaster.Fields("quantity").Value Then GoTo skipRow
					Next x
				End If
				'If lPackSizeID <> rsMaster("PackSizeID") Then
				If lPackSizeID <> rsMaster.Fields("ShrinkID").Value Then
					lColour = Not lColour
					'.AddItem rsMaster("PackSize_Name")
					'.AddItem rsMaster("Shrink_Name")
                    .Rows.Add("")
					'lPackSizeID = rsMaster("PackSizeID")
					lPackSizeID = rsMaster.Fields("ShrinkID").Value
				Else
                    .Rows.Add("")
				End If
				.row = .RowCount - 1
				.Col = 0
				.CellBackColor = lblColorFixed(System.Math.Abs(CShort(lColour))).BackColor
				.Col = 1
				.CellBackColor = lblColorFixed(System.Math.Abs(CShort(lColour))).BackColor
				.Text = rsMaster.Fields("quantity").Value
				'.RowData(.row) = rsMaster("PackSizeID")
				.set_RowData(.row, rsMaster.Fields("ShrinkID").Value)
				For x = 1 To 8
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Col = x + 1
					'Set rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsMaster("PackSizeID") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster("quantity") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					'Set rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsMaster("ShrinkID") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster("quantity") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster.Fields("quantity").Value & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					If rs.BOF Or rs.EOF Then
						.CellBackColor = lblcolor(System.Math.Abs(CShort(lColour))).BackColor
						If rsMaster.Fields("quantity").Value = 1 Then
							.Text = txtUnit(x).Text
						Else
							.Text = txtCase(x).Text
						End If
					Else
						.CellBackColor = lblColorChanged.BackColor
						.Text = FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2)
					End If
					rs.Close()
				Next 
				
skipRow: 
				rsMaster.moveNext()
			Loop 
			
			.Visible = True
			
		End With
		
		loading = False
		If gridItem.RowCount > 1 Then
			gridItem.row = 1
			gridItem.Col = 2
		Else
			txtEdit.Visible = False
		End If
		loading = False
	End Sub
	
	
	Private Sub save()
        Dim lCol As Integer
        Dim colorInActive As Integer
		Dim sql As String
		Dim lAmountDefault As Decimal
		Dim lQuantity As Short
		If loading Then Exit Sub
		If gridItem.row Then
			If gridItem.get_TextMatrix(gridItem.row, 1) = "" Then Exit Sub
			lQuantity = CShort(gridItem.get_TextMatrix(gridItem.row, 1))
			If lQuantity > 1 Then
				lAmountDefault = CDec(Me.txtCase(Me.gridItem.Col - 1).Text)
			Else
				lAmountDefault = CDec(Me.txtUnit(Me.gridItem.Col - 1).Text)
			End If
			If txtEdit.Text <> txtEdit.Tag Then
				txtEdit.Tag = txtEdit.Text
				
				If txtEdit.Text = "" Then
					txtEdit.Text = FormatNumber(lAmountDefault * 100, 0, TriState.False, TriState.False, TriState.False)
					If txtEdit.Text = "" Then
						txtEdit.Text = "0"
					End If
				End If
				cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PackSizeID)=" & gridItem.get_RowData(gridItem.row) & "));")
				gridItem.Text = FormatNumber(CDbl(txtEdit.Text) / 100, 2, TriState.False, TriState.False, TriState.False)
				sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " & gID & ") AND (PricingGroupChannelLnk_PackSizeID = " & gridItem.get_RowData(gridItem.row) & ") AND (PricingGroupChannelLnk_Quantity = " & lQuantity & ") AND (PricingGroupChannelLnk_ChannelID = " & gridItem.Col - 1 & ")"
				cnnDB.Execute(sql)
				If lAmountDefault = CDec(gridItem.Text) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object colorInActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(colorInActive)
					loading = True
					'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCol = gridItem.Col
					gridItem.Col = 0
					If System.Drawing.ColorTranslator.ToOle(gridItem.CellBackColor) = System.Drawing.ColorTranslator.ToOle(Me.lblColorFixed(0).BackColor) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.Col = lCol
						gridItem.CellBackColor = Me.lblcolor(0).BackColor
						
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.Col = lCol
						gridItem.CellBackColor = Me.lblcolor(1).BackColor
					End If
					
					loading = False
				Else
					sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" & gID & ", " & gridItem.get_RowData(gridItem.row) & ", " & lQuantity & ", " & gridItem.Col - 1 & ", " & gridItem.Text & ");"
					cnnDB.Execute(sql)
					gridItem.CellBackColor = Me.lblColorChanged.BackColor
				End If
				sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PackSizeID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null));"
				cnnDB.Execute(sql)
			End If
			
		End If
	End Sub
	
	
	Private Sub save_NEW()
        Dim lCol As Integer
        Dim colorInActive As Integer
		Dim sql As String
		Dim lAmountDefault As Decimal
		Dim lQuantity As Short
		If loading Then Exit Sub
		If gridItem.row Then
			If gridItem.get_TextMatrix(gridItem.row, 1) = "" Then Exit Sub
			lQuantity = CShort(gridItem.get_TextMatrix(gridItem.row, 1))
			If lQuantity > 1 Then
				lAmountDefault = CDec(Me.txtCase(Me.gridItem.Col - 1).Text)
			Else
				lAmountDefault = CDec(Me.txtUnit(Me.gridItem.Col - 1).Text)
			End If
			If txtEdit.Text <> txtEdit.Tag Then
				txtEdit.Tag = txtEdit.Text
				
				If txtEdit.Text = "" Then
					txtEdit.Text = FormatNumber(lAmountDefault * 100, 0, TriState.False, TriState.False, TriState.False)
					If txtEdit.Text = "" Then
						txtEdit.Text = "0"
					End If
				End If
				'cnnDB.Execute "INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PackSizeID)=" & gridItem.RowData(gridItem.row) & "));"
				cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null));")
				gridItem.Text = FormatNumber(CDbl(txtEdit.Text) / 100, 2, TriState.False, TriState.False, TriState.False)
				'sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " & gID & ") AND (PricingGroupChannelLnk_PackSizeID = " & gridItem.RowData(gridItem.row) & ") AND (PricingGroupChannelLnk_Quantity = " & lQuantity & ") AND (PricingGroupChannelLnk_ChannelID = " & gridItem.Col - 1 & ")"
				sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " & gID & ") AND (PricingGroupChannelLnk_Quantity = " & lQuantity & ") AND (PricingGroupChannelLnk_ChannelID = " & gridItem.Col - 1 & ")"
				cnnDB.Execute(sql)
				If lAmountDefault = CDec(gridItem.Text) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object colorInActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(colorInActive)
					loading = True
					'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCol = gridItem.Col
					gridItem.Col = 0
					If System.Drawing.ColorTranslator.ToOle(gridItem.CellBackColor) = System.Drawing.ColorTranslator.ToOle(Me.lblColorFixed(0).BackColor) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.Col = lCol
						gridItem.CellBackColor = Me.lblcolor(0).BackColor
						
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.Col = lCol
						gridItem.CellBackColor = Me.lblcolor(1).BackColor
					End If
					
					loading = False
				Else
					'sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" & gID & ", " & gridItem.RowData(gridItem.row) & ", " & lQuantity & ", " & gridItem.Col - 1 & ", " & gridItem.Text & ");"
					sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" & gID & ", " & 0 & ", " & lQuantity & ", " & gridItem.Col - 1 & ", " & gridItem.Text & ");"
					cnnDB.Execute(sql)
					gridItem.CellBackColor = Me.lblColorChanged.BackColor
				End If
				'sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PackSizeID)=" & gridItem.RowData(gridItem.row) & ") AND ((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null));"
				sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE ((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null);"
				cnnDB.Execute(sql)
			End If
			
		End If
	End Sub
	
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		save()
		Me.Close()
	End Sub
	
	Private Sub cmdPricingGroup_Click()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		'If frmPrint.loadHTM("PricingGroupMatrix", "id=" & lstPricingGroup.ItemData(lstPricingGroup.ListIndex), "PricingMatrix") Then
		'    frmPrint.show 1
		'Else
		'    MsgBox "Unable to display report!", vbExclamation, "Report Error"
		'End If
		
		report_PricingMatrixNew(gID)
	End Sub
	
	Private Sub cmdStockItem_Click()
		Dim lstPricingGroup As Object
		Dim frmPrint As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object lstPricingGroup.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lstPricingGroup.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object frmPrint.loadHTM. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If frmPrint.loadHTM("PricingGroupStockItem", "id=" & lstPricingGroup.ItemData(lstPricingGroup.ListIndex), "PricingGroupStockItem") Then
			'UPGRADE_WARNING: Couldn't resolve default property of object frmPrint.show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmPrint.show(1)
		Else
			MsgBox("Unable to display report!", MsgBoxStyle.Exclamation, "Report Error")
		End If
	End Sub
	
	
	
	
	Private Sub cmdClose_Click()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		report_PricingMatrix(gID)
	End Sub
	
    Private Sub frmPricingMatrix_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                cmdExit_Click(cmdExit, New System.EventArgs())
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmPricingMatrix_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lblcolor.AddRange(New Label() {_lblcolor_0, _lblcolor_1})
        lblColorFixed.AddRange(New Label() {_lblColorFixed_0, _lblColorFixed_1})
        txtCase.AddRange(New TextBox() {_txtCase_1, _txtCase_2, _txtCase_3, _txtCase_4, _txtCase_5, _
                                        _txtCase_6, _txtCase_7, _txtCase_8})
        txtUnit.AddRange(New TextBox() {_txtUnit_1, _txtUnit_2, _txtUnit_3, _txtUnit_4, _txtUnit_5, _
                                        _txtUnit_6, _txtUnit_7, _txtUnit_8})
        loadLanguage()
    End Sub

    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles gridItem.EnterCell
        If loading Then Exit Sub
        With gridItem
            If .row Then
            Else
                Exit Sub
            End If
            txtEdit.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                              twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                              twipsToPixels(.CellWidth, True), twipsToPixels(.CellHeight, False))
            txtEdit.Text = Replace(.Text, ".", "")
            If txtEdit.Text = "000" Then txtEdit.Text = "0"
            txtEdit.Tag = txtEdit.Text
            txtEdit.Visible = True
            If Me.Visible Then txtEdit.Focus()

        End With
    End Sub

    Private Sub gridItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        txtEdit_Enter(txtEdit, New System.EventArgs())
    End Sub

    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Dim direction As Integer
        direction = 0
        Select Case eventArgs.KeyChar
            Case ChrW(40)
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub

    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles gridItem.LeaveCell
        save()
    End Sub



    Private Sub lblHeading_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblHeading.Click
        report_PricingMatrix(gID)
    End Sub

    Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Enter
        txtEdit.SelectionStart = 0
        txtEdit.SelectionLength = 999
    End Sub

    Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim bDoNotEdit As Boolean
        With Me.gridItem
            Select Case KeyCode
                Case 27 'ESC
                    txtEdit.Visible = False
                    .Focus()
                Case 13 'ENTER
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    moveNext(1)
                Case 37 'Left arrow
                    If txtEdit.SelectionStart = 0 And txtEdit.SelectionLength = 0 Or txtEdit.SelectedText = txtEdit.Text Then
                        .Focus()
                        System.Windows.Forms.Application.DoEvents()
                        If .Col > .FixedCols Then
                            bDoNotEdit = True
                            .Col = .Col - 1
                            bDoNotEdit = False
                        End If
                    End If
                Case 39 'Right arrow
                    If txtEdit.SelectionStart = Len(txtEdit.Text) Or txtEdit.SelectedText = txtEdit.Text Then
                        .Focus()
                        System.Windows.Forms.Application.DoEvents()
                        If .Col < .ColumnCount - 1 Then
                            bDoNotEdit = True
                            .Col = .Col + 1
                            bDoNotEdit = False
                        End If
                    End If

                Case 38 'Up arrow
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    If .row > .FixedRows Then
                        bDoNotEdit = True
                        .row = .row - 1
                        bDoNotEdit = False

                    End If
                Case 40 'Down arrow
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    If .row < .RowCount - 1 Then
                        bDoNotEdit = True
                        .row = .row + 1
                        bDoNotEdit = False
                    End If
            End Select
        End With
    End Sub
    Private Function moveNext(ByRef direction As Integer) As Boolean
        Dim x As Short
        Dim y As Short
        x = gridItem.Col + direction
        If x >= gridItem.Col Then
            gridItem.Col = 1
            If gridItem.row < gridItem.RowCount - 1 Then
                y = gridItem.row + 1
                gridItem.TopRow = gridItem.TopRow + 1
                gridItem.row = y
            End If
            System.Windows.Forms.Application.DoEvents()
        Else
            gridItem.Col = gridItem.Col + 1
        End If
        moveNext = True
    End Function


    Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '
        ' Delete carriage returns to get rid of beep
        ' and only allow numbers.
        '
        Dim lCurrentX As Short
        Select Case KeyAscii

            Case Asc(vbCr)

                KeyAscii = 0
            Case 8, 46
            Case 48 To 57
            Case 45 '-
                If InStr(txtEdit.Text, "-") Then
                Else
                    lCurrentX = txtEdit.SelectionStart + 1
                    txtEdit.Text = "-" & txtEdit.Text
                    txtEdit.SelectionStart = lCurrentX

                End If
                KeyAscii = 0
            Case 43 '+
                If InStr(txtEdit.Text, "-") Then
                    lCurrentX = txtEdit.SelectionStart - 1
                    txtEdit.Text = VB.Right(txtEdit.Text, Len(txtEdit.Text) - 1)
                    If lCurrentX < 0 Then lCurrentX = 0
                    txtEdit.SelectionStart = lCurrentX

                End If
                KeyAscii = 0
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
End Class