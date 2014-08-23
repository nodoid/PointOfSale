Option Strict Off
Option Explicit On
Friend Class frmpricechange
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmpricechange = No Code   [Price Changes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmpricechange.Caption = rsLang("LanguageLayoutLnk_Description"): frmpricechange.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblInstruction = No Code   [This process will print you the.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblInstruction.Caption = rsLang("LanguageLayoutLnk_Description"): lblInstruction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1140 'Start Date|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1141 'End Date|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdShow = No Code          [Show]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdShow.Caption = rsLang("LanguageLayoutLnk_Description"): cmdShow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdCancel = No Code        [Cancel]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdCancel.Caption = rsLang("LanguageLayoutLnk_Description"): cmdCancel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmpricechange.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub cmdenddate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdenddate.Click
		HForPriceC = 2
		frmcalendar.ShowDialog()
		
	End Sub
	
	Private Sub cmdShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShow.Click
        Dim x As Integer
		On Error Resume Next
		
		Dim rs As ADODB.Recordset
		Dim rs1 As ADODB.Recordset
		Dim rs2 As ADODB.Recordset
		Dim rsB As ADODB.Recordset
		Dim rsDcheck As ADODB.Recordset
		Dim HMyPrice As Decimal
		Dim MyMarkup As String
		Dim HMyPrice1 As Decimal
		Dim MyCounterF As Double
		Dim MyCounterL As Double
		Dim Delimiter As String
		Dim rsk As ADODB.Recordset
		rs = New ADODB.Recordset
		rs1 = New ADODB.Recordset
		rs2 = New ADODB.Recordset
		rsB = New ADODB.Recordset
		rsDcheck = New ADODB.Recordset
		rsk = New ADODB.Recordset
		Delimiter = " "
		
		
		'create table name
		Te_Names = "NewPricechanges"
		'In case the table was not dropped then drop it
		rs = getRS("DROP TABLE " & Te_Names & "")
		MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number"
		'create table NewPriceChanges
		cnnDB.Execute("CREATE TABLE " & Te_Names & " (" & MyFTypess & ")")
		
		rs1 = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndEndID = DayEnd.DayEndID ORDER BY aStockItem1.StockItemID;")
		If rs1.RecordCount Then
			Do Until rs1.EOF
				rs2 = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndStartID = DayEnd.DayEndID WHERE (((aStockItem1.StockItemID)=" & rs1.Fields("DayEndStockItemLnk_StockItemID").Value & "));")
				If rs2.RecordCount Then
					If rs1.Fields("DayEndStockItemLnk_ListCost").Value <> rs2.Fields("DayEndStockItemLnk_ListCost").Value Then
						MyMarkup = CStr(0)
						'MyMarkup = (rs2("DayEndStockItemLnk_ListCost") / rsB("CatalogueChannelLnk_Price") * 100)
						'MyMarkup = 100 - MyMarkup
						'insert into Newpricechanges
						cnnDB.Execute("INSERT INTO " & Te_Names & "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" & rs1.Fields("DayEndStockItemLnk_StockItemID").Value & ",'" & rs1.Fields("StockItem_Name").Value & "', " & rs1.Fields("DayEndStockItemLnk_ListCost").Value & ", " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & "," & rs1.Fields("DayEndStockItemLnk_ListCost").Value & "," & MyMarkup & ")")
						'delete duplicates
						'Set rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2("DayEndStockItemLnk_StockItemID") & " and NewPricechanges.OldPrice = " & rs2("DayEndStockItemLnk_ListCost") & " and NewPricechanges.NewPrice = " & rs2("DayEndStockItemLnk_ListCost") & ")")
					End If
				End If
				rs1.moveNext()
			Loop 
		Else
			MsgBox("There was No Price Changes of Items between " & Me.txtstartdate.Text & " And " & Me.txtenddate.Text, MsgBoxStyle.Information, "4POS")
		End If
		
		
		
		'validation for start date
		If Me.txtstartdate.Text = "" Then
			MsgBox("Please Select/enter the Start Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKCancel, "4POS")
			Me.txtstartdate.Focus()
			Exit Sub
			'validation for end date
		ElseIf Me.txtenddate.Text = "" Then 
			MsgBox("Please Select/enter the End Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKCancel, "4POS")
			Me.txtenddate.Focus()
			Exit Sub
		End If
		
		'create table name
		Te_Names = "NewPricechanges"
		'In case the table was not dropped then drop it
		rs = getRS("DROP TABLE " & Te_Names & "")
		MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number"
		'create table NewPriceChanges
		cnnDB.Execute("CREATE TABLE " & Te_Names & " (" & MyFTypess & ")")
		
		'selecting from the start date
		rs = getRS("SELECT * FROM DayEnd WHERE Datevalue(DayEnd_Date)=#" & Me.txtstartdate.Text & "#")
		'selecting from the end date
		rs1 = getRS("SELECT * FROM DayEnd WHERE Datevalue(DayEnd_Date) = #" & Me.txtenddate.Text & "#")
		
		Me.cmdshow.Enabled = False
		Me.cmdcancel.Enabled = False
		'assigning the start date and the end date to the below variables
		MyCounterF = rs.Fields("DayEndID").Value
		MyCounterL = rs1.Fields("DayEndID").Value
		
		For x = MyCounterF To MyCounterL 'loop/round from the first date until the last date selected
			rs2 = getRS("SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" & MyCounterF & "")
			rsB = getRS("SELECT * FROM CatalogueChannelLnk WHERE CatalogueChannelLnk_StockItemID=" & MyCounterF & "")
			rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & "")
			
			rs2.MoveFirst()
			'formating the price
			HMyPrice1 = rs2.Fields("DayEndStockItemLnk_ListCost").Value
			HMyPrice1 = CDec(Format(HMyPrice1, "R# ,###.##"))
			'formating the price
			HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value
			HMyPrice = CDec(Format(HMyPrice, "R# ,###.##"))
			rs2.Fields("DayEndStockItemLnk_ListCost").Value = Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##")
			
			'looping through the price for a specific date,if the price differs then insert into newly created table
			Do Until rs2.EOF
				If rs2.Fields("DayEndStockItemLnk_ListCost").Value <> HMyPrice Then
					HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value
					HMyPrice = CDec(Format(HMyPrice, "R# ,###.##"))
					MyMarkup = CStr(rs2.Fields("DayEndStockItemLnk_ListCost").Value / rsB.Fields("CatalogueChannelLnk_Price").Value * 100)
					MyMarkup = CStr(100 - CDbl(MyMarkup))
					'insert into Newpricechanges
					rsk = getRS("INSERT INTO " & Te_Names & "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & ",'" & rs.Fields("StockItem_Name").Value & "', " & HMyPrice1 & ", " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & "," & rsB.Fields("CatalogueChannelLnk_Price").Value & "," & MyMarkup & ")")
					'delete duplicates
					rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & " and NewPricechanges.OldPrice = " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & " and NewPricechanges.NewPrice = " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & ")")
				End If
				rs2.moveNext()
				rs2.Fields("DayEndStockItemLnk_ListCost").Value = Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##")
			Loop 
			MyCounterF = MyCounterF + 1
		Next x 'for ends here
		
		rs = getRS("SELECT * FROM NewPriceChanges")
		'if there was a price change then display the report
		If rs.RecordCount > 0 Then
			ForNewPChange = 2
			modApplication.report_NewPriceChange()
			'if there was no price change then don't display the report instead display the below message
		ElseIf rs.RecordCount < 1 Then 
			MsgBox("There was No Price Changes of Items between " & Me.txtstartdate.Text & " And " & Me.txtenddate.Text, MsgBoxStyle.Information, "4POS")
			'if there was no price change then enable the show and cancel button
			Me.cmdshow.Enabled = True
			Me.cmdcancel.Enabled = True
		End If
		
	End Sub
	
	
	Private Sub OLD_cmdShow_Click()
        Dim x As Integer
		On Error Resume Next
		
		Dim rs As ADODB.Recordset
		Dim rs1 As ADODB.Recordset
		Dim rs2 As ADODB.Recordset
		Dim rsB As ADODB.Recordset
		Dim rsDcheck As ADODB.Recordset
		Dim HMyPrice As Decimal
		Dim MyMarkup As String
		Dim HMyPrice1 As Decimal
		Dim MyCounterF As Double
		Dim MyCounterL As Double
		Dim Delimiter As String
		Dim rsk As ADODB.Recordset
		rs = New ADODB.Recordset
		rs1 = New ADODB.Recordset
		rs2 = New ADODB.Recordset
		rsB = New ADODB.Recordset
		rsDcheck = New ADODB.Recordset
		rsk = New ADODB.Recordset
		Delimiter = " "
		'Set rs = getRS("SELECT * FROM DayEnd WHERE DayEnd_Date = " & Me.txtstartdate.Text & "")
		'validation for start date
		If Me.txtstartdate.Text = "" Then
			MsgBox("Please Select/enter the Start Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKCancel, "4POS")
			Me.txtstartdate.Focus()
			Exit Sub
			'validation for end date
		ElseIf Me.txtenddate.Text = "" Then 
			MsgBox("Please Select/enter the End Date", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKCancel, "4POS")
			Me.txtenddate.Focus()
			Exit Sub
		End If
		
		'create table name
		Te_Names = "NewPricechanges"
		'In case the table was not dropped then drop it
		rs = getRS("DROP TABLE " & Te_Names & "")
		
		'selecting from dayend
		rsDcheck = getRS("SELECT * FROM DayEnd")
		
		rsDcheck.MoveFirst()
		'looping through all the selected records
		Do Until rsDcheck.EOF
			'rsDcheck("DayEnd_Date") = Trim(Mid(rsDcheck("DayEnd_Date"), Len(rsDcheck("DayEnd_Date")) - 2, InStr(1, rsDcheck("DayEnd_Date"), Delimiter, Len(rsDcheck("DayEnd_Date")) - 1)))
			'formarting the date and time to just date
			rsDcheck.Fields("DayEnd_Date").Value = Trim(Mid(rsDcheck.Fields("DayEnd_Date").Value, 1, InStr(1, rsDcheck.Fields("DayEnd_Date").Value, Delimiter, 1) - 1))
			
			'updating the date fields to only date not date and time
			rs = getRS("UPDATE DayEnd SET DayEnd_Date=#" & rsDcheck.Fields("DayEnd_Date").Value & "# WHERE DayEndID=" & rsDcheck.Fields("DayEndID").Value & "")
			rsDcheck.moveNext()
		Loop 
		
		MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number"
		
		'create table NewPriceChanges
		
		cnnDB.Execute("CREATE TABLE " & Te_Names & " (" & MyFTypess & ")")
		'selecting from the start date
		
		rs = getRS("SELECT * FROM DayEnd WHERE (DayEnd_Date=#" & Me.txtstartdate.Text & "#)")
		'selecting from the end date
		rs1 = getRS("SELECT * FROM DayEnd WHERE (DayEnd_Date = #" & Me.txtenddate.Text & "#)")
		
		'MyDayendIDs = rs("DayEndID")
		
		'MyDayendIDs1 = rs1("DayEndID")
		Me.cmdshow.Enabled = False
		Me.cmdcancel.Enabled = False
		'assigning the start date and the end date to the below variables
		MyCounterF = rs.Fields("DayEndID").Value
		MyCounterL = rs1.Fields("DayEndID").Value
		
		For x = MyCounterF To MyCounterL 'loop/round from the first date until the last date selected
			
			rs2 = getRS("SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" & MyCounterF & "")
			rsB = getRS("SELECT * FROM CatalogueChannelLnk WHERE CatalogueChannelLnk_StockItemID=" & MyCounterF & "")
			rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & "")
			
			rs2.MoveFirst()
			'formating the price
			HMyPrice1 = rs2.Fields("DayEndStockItemLnk_ListCost").Value
			HMyPrice1 = CDec(Format(HMyPrice1, "R# ,###.##"))
			'formating the price
			HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value
			HMyPrice = CDec(Format(HMyPrice, "R# ,###.##"))
			rs2.Fields("DayEndStockItemLnk_ListCost").Value = Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##")
			
			Do Until rs2.EOF
				'looping through the price for a specific date,if the price differs then insert into newly created table
				If rs2.Fields("DayEndStockItemLnk_ListCost").Value <> HMyPrice Then
					
					'rsB("CatalogueChannelLnk_Price") = rsB("CatalogueChannelLnk_Price")
					
					HMyPrice = rs2.Fields("DayEndStockItemLnk_ListCost").Value
					HMyPrice = CDec(Format(HMyPrice, "R# ,###.##"))
					
					MyMarkup = CStr(rs2.Fields("DayEndStockItemLnk_ListCost").Value / rsB.Fields("CatalogueChannelLnk_Price").Value * 100)
					MyMarkup = CStr(100 - CDbl(MyMarkup))
					
					'Set rs = getRS("SELECT DayEndStockItemLnk_ListCost,StockItem_Name,CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (StockItem INNER JOIN DayEndStockItemLnk ON StockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE DayEndStockItemLnk_StockItemID=" & rs2("DayEndStockItemLnk_StockItemID") & ";")
					'modApplication.Report_PriceChanges
					'If rs2("DayEndStockItemLnk_ListCost") <> HMyPrice Then
					'insert into Newpricechanges
					rsk = getRS("INSERT INTO " & Te_Names & "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & ",'" & rs.Fields("StockItem_Name").Value & "', " & HMyPrice1 & ", " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & "," & rsB.Fields("CatalogueChannelLnk_Price").Value & "," & MyMarkup & ")")
					
					'End If
					'delete if there is records with same old price and new price
					rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2.Fields("DayEndStockItemLnk_StockItemID").Value & " and NewPricechanges.OldPrice = " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & " and NewPricechanges.NewPrice = " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & ")")
					
				End If
				'rsB.moveNext
				
				rs2.moveNext()
				rs2.Fields("DayEndStockItemLnk_ListCost").Value = Format(rs2.Fields("DayEndStockItemLnk_ListCost").Value, "R # ,###.##")
			Loop 
			
			'Set rs1 = getRS("SELECT * FROM DayEndStockItemLnk WHERE DayEndStockItemLnk_StockItemID=" & MyDayendIDs1 & "")
			'Set rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & rs1("DayEndStockItemLnk_StockItemID") & "")
			'rs1.MoveFirst
			'Do Until rs1.EOF
			'If HMyPrice <> rs1("DayEndStockItemLnk_ListCost") Then
			'HMyPrice1 = rs1("DayEndStockItemLnk_ListCost")
			'Set rs = getRS("INSERT INTO NewPriceChanges(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice)VALUES(" & rs1("DayEndStockItemLnk_StockItemID") & ",'" & rs("StockItem_Name") & "', '" & HMyPrice1 & "', '" & rs1("DayEndStockItemLnk_ListCost") & "')")
			'End If
			'rs1.moveNext
			'Loop
			
			MyCounterF = MyCounterF + 1
		Next x
		
		rs = getRS("SELECT * FROM NewPriceChanges")
		'if there was a price change then display the report
		If rs.RecordCount > 0 Then
			ForNewPChange = 2
			modApplication.report_NewPriceChange()
			'if there was no price change then don't display the report instead display the below message
		ElseIf rs.RecordCount < 1 Then 
			MsgBox("There was No Price Changes of Items between " & Me.txtstartdate.Text & " And " & Me.txtenddate.Text, MsgBoxStyle.Information, "4POS")
			'if there was no price change then enable the show and cancel button
			Me.cmdshow.Enabled = True
			Me.cmdcancel.Enabled = True
			
		End If
		
	End Sub
	
	Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
		HForPriceC = 1
		frmcalendar.ShowDialog()
		
	End Sub
	
	Private Sub frmpricechange_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdShow_Click(cmdShow, New System.EventArgs())
		ElseIf KeyAscii = 27 Then 
			cmdCancel_Click(cmdCancel, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmpricechange_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
	End Sub
End Class