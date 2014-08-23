Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmSerialNumber
	Inherits System.Windows.Forms.Form
	Dim intComp As Short
	Dim inIndex As Short
	
	Private Sub loadLanguage()
		
		'frmSerialNumber = No Code  [Serial Number Entry]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSerialNumber.Caption = rsLang("LanguageLayoutLnk_Description"): frmSerialNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2431 'Import|Checked
		If rsLang.RecordCount Then Command1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label5 = No Code           [Item Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label4 = No Code           [Item Code]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label3 = No Code           [Quantity]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Note: Label6.caption has a spelling mistake!
		'Label6 = no Code           [Received]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2026 'Returned|Checked
		If rsLang.RecordCount Then Label7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1055 'Serial Number|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAdd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAdd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label2 = No Code           [List Of Serial Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label8 = No Code           [All Items that are being returned should be checked]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdRemove = No Code        [Remove]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdRemove.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRemove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2464 'Update|Checked
		If rsLang.RecordCount Then cmdUpdate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdUpdate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSerialNumber.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		Dim sql As String
		Dim rs As ADODB.Recordset
		
		If Val(txtQty.Text) = lstSerial.Items.Count Then
			MsgBox("Enough Item Serial number(s) have been entered", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		
		If txtSerialNbr.Text = "" Then
			MsgBox("Please enter the serial number before you continue", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		Else
			'Check duplicate serials in database
			sql = "SELECT tblSerialNumber FROM tblSerialTracking WHERE tblStockItemID = " & Val(Trim(txtcode.Text))
			
			rs = getRS(sql)
			
			If rs.RecordCount >= 1 Then
				Do While rs.EOF = False
					If UCase(rs.Fields("tblSerialNumber").Value) = UCase(txtSerialNbr.Text) Then
						MsgBox("Item with this " & UCase(txtSerialNbr.Text) & " Serial number already exists", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
						txtSerialNbr.Text = ""
						txtSerialNbr.Focus()
						
						Exit Sub
					End If
					rs.moveNext()
				Loop 
			End If
			
			If ChkDuplicates(Trim(txtSerialNbr.Text)) = False Then
				lstSerial.Items.Add(Trim(txtSerialNbr.Text))
				txtSerialNbr.Text = ""
			Else
				MsgBox("This serial number exist already in the list", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			End If
		End If
		
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Grv_Unload = True
		Me.Close()
		
		
	End Sub
	
	Private Sub cmdRemove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRemove.Click
		Dim inrsp As Short
		
		inrsp = MsgBox("Do you want to remove this serial number", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
		
		If inrsp = MsgBoxResult.Yes Then
			If lstSerial.SelectedIndex >= 0 Then lstSerial.Items.RemoveAt(lstSerial.SelectedIndex)
		End If
		
	End Sub
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        Dim rs As ADODB.Recordset
		Dim sql As String
		Dim sql1 As String
		Dim sql2 As String
		Dim srItem As String
        Dim intr As Short
		Dim rj As ADODB.Recordset
		Dim rt As ADODB.Recordset
		Dim jStatus As Short
		
		If Val(txtQty.Text) <> lstSerial.Items.Count Then
			MsgBox("Item serial number(s) should be " & Val(txtQty.Text) & " in number", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		Else
			jStatus = ChkReturned
			If jStatus = 1 Then
				For intr = 0 To lstSerial.Items.Count - 1
					If lstSerial.GetItemChecked(intr) = True Then
                        srItem = "RT" & lstSerial.Text.Trim(ChrW(intr))
					Else
                        srItem = "RC" & lstSerial.Text.Trim(ChrW(intr))
					End If
					tempStockItem(intComp) = Trim(srItem)
					intComp = intComp + 1
					
				Next 
				
			ElseIf jStatus = 2 Then 
				MsgBox("Only " & Trim(txtRtd.Text) & " should be returned on this Item", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			ElseIf jStatus = 3 Then 
				MsgBox("You've selected few Items for return than specified", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			ElseIf jStatus = 4 Then 
				MsgBox("There are no returns for this Item!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
		End If
		
		lstSerial.Items.Clear()
		inIndex = inIndex + 1
		
		If inIndex < intCurr Then
			txtItem.Text = intArrayName(inIndex)
			txtcode.Text = CStr(intArraySCode(inIndex))
			sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & Val(Trim(txtcode.Text)) & " AND GRVItem_Return = 0 AND GRVItem_GRVID = " & Gr_ID
			
			sql2 = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & Val(Trim(txtcode.Text)) & " AND GRVItem_Return = 1 AND GRVItem_GRVID = " & Gr_ID
			
			rs = getRS(sql)
			
			rt = getRS(sql2)
			If rs.RecordCount = 1 Then
                txtQty.Text = CStr(CShort(rs("GRVItem_Quantity").Value))
				If rt.RecordCount > 0 Then
					txtRtd.Text = CStr(CShort(rt.Fields("GRVItem_Quantity").Value))
				Else
					txtRtd.Text = CStr(0)
				End If
			End If
		Else
			Me.Close()
		End If
		
	End Sub
	
	Private Sub frmSerialNumber_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		lstSerial.Items.Clear()
		'Loop thru items
		LoadGRVItemValues()
		
		loadLanguage()
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If IsNumeric(Chr(KeyAscii)) = False Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Function ChkReturned() As Short
		Dim j As Short
		Dim i As Short
		'Count Checked
		i = 0
		j = lstSerial.Items.Count
		
		For j = 0 To lstSerial.Items.Count - 1
			If lstSerial.GetItemChecked(j) = True Then
				i = i + 1
			End If
		Next 
		
		If Val(txtRtd.Text) > 0 Then
			If i = Val(txtRtd.Text) Then
				ChkReturned = 1 'Commit the transaction
			ElseIf i > Val(txtRtd.Text) Then 
				ChkReturned = 2 'more serials have been specified as returned that required
			ElseIf i < Val(txtRtd.Text) Then 
				ChkReturned = 3 'Less serial have been specified for than required
			End If
		ElseIf Val(txtRtd.Text) = 0 Then 
			If i = 0 Then
				ChkReturned = 1 'Commit transaction
			Else
				ChkReturned = 4 'No returned but some item have been clicked for return
			End If
		End If
		
	End Function
	Function ChkDuplicates(ByRef SN As String) As Boolean
		Dim inC As Short
		
		If lstSerial.Items.Count = 0 Then
			ChkDuplicates = False
		Else
			For inC = 0 To lstSerial.Items.Count - 1
                If Trim(SN) = lstSerial.Text.Trim(ChrW(inC)) Then
                    ChkDuplicates = True
                    Exit Function
                End If
			Next 
			ChkDuplicates = False
		End If
		
	End Function
	Sub LoadGRVItemValues()
		Dim sql2 As String
		Dim sql As String
		Dim inAr As Boolean
		Dim rs As ADODB.Recordset
		Dim rs1 As ADODB.Recordset
		Dim rt As ADODB.Recordset
		
		
		intComp = 0
		
		inAr = False
		inIndex = 0
		
		rs_St.MoveFirst()
		
		Do While rs_St.EOF = False
			'sql = "SELECT * FROM tblSerialFlag WHERE tblStockItemID = " & rs_St("GRVItem_StockItemID")
			sql = "SELECT * FROM StockItem WHERE StockItemID = " & rs_St.Fields("GRVItem_StockItemID").Value
			rs = getRS(sql) 'Check serial flag
			
			If rs.RecordCount = 1 Then
				'If rs("tblSerialTrack") = True Then
				If rs.Fields("StockItem_SerialTracker").Value = True Then
					'sql = "SELECT StockItemID,StockItem_Name FROM StockItem WHERE StockItemID = " & rs_St("GRVItem_StockItemID")
					rs1 = getRS(sql)
					intArrayName(intCurr) = Trim(rs1.Fields("StockItem_Name").Value)
					intArraySCode(intCurr) = rs1.Fields("StockItemID").Value
					intCurr = intCurr + 1
					inAr = True
				End If
			End If
			rs_St.moveNext()
		Loop 
		
		
		If inAr = True Then
			txtItem.Text = intArrayName(0)
			txtcode.Text = CStr(intArraySCode(0))
		End If
		
		lstSerial.Items.Clear()
		
		sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & Val(Trim(txtcode.Text)) & " AND GRVItem_Return = 0 AND GRVItem_GRVID = " & Gr_ID
		
		sql2 = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & Val(Trim(txtcode.Text)) & " AND GRVItem_Return = 1 AND GRVItem_GRVID = " & Gr_ID
		
		rs = getRS(sql)
		rt = getRS(sql2)
		If rs.RecordCount = 1 Then
			txtQty.Text = CStr(CShort(rs.Fields("GRVItem_Quantity").Value))
			If rt.RecordCount > 0 Then
				txtRtd.Text = CStr(CShort(rt.Fields("GRVItem_Quantity").Value))
			Else
				txtRtd.Text = CStr(0)
			End If
		End If
		
	End Sub
	Sub SaveIntoTable()
        Dim sql As String
		'Save all details into serial tables
		Dim rs As ADODB.Recordset
		Dim intK As Short
		Dim intP As Short
		Dim Grv_qty As Short
		Dim Grv_Track As Short
		Dim UpLoop As Short
		
		Grv_qty = 0
		Grv_Track = 0
		
		For intK = 0 To intCurr - 1
			sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & intArraySCode(intK) & " AND GRVItem_Return = 0 AND GRVItem_GRVID = " & Gr_ID
			rs = getRS(sql)
			
			Grv_qty = (rs.Fields("GRVItem_Quantity").Value - 1)
			
			UpLoop = Grv_Track + Grv_qty
			
			If rs.RecordCount = 1 Then
				For intP = Grv_Track To UpLoop
					sql = "INSERT INTO tblSerialTracking (tblStockItemID,tblSerialNumber,tblDatePurchases) " & "VALUES (" & Val(CStr(intArraySCode(intK))) & ",'" & Trim(tempStockItem(intP)) & "',#" & CDate(Today) & "#)"
					cnnDB.Execute(sql)
					
				Next 
				
				Grv_Track = Grv_qty + 1
			End If
		Next 
		
	End Sub
	Private Sub txtSerialNbr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNbr.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			If txtSerialNbr.Text <> "" Then
				cmdAdd_Click(cmdAdd, New System.EventArgs())
			Else
				MsgBox("Please enter the serial number before you continue", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				GoTo EventExitSub
			End If
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class