Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmLangImport
	Inherits System.Windows.Forms.Form
	Dim st_Name As String
	Dim dReceipt As Boolean
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2421 'Import|Checked
		If rsLang.RecordCount Then frmExport.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmExport.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2427 'HandHeld Stock Take: (Item Barcode, Item Quantity)]
		If rsLang.RecordCount Then lblHeading.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblHeading.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2428 'File Path|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmLangImport.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	Private Sub ExRecipe()
		Dim sql As String
		Dim sqlInsert As String
		Dim sqlUp As String
		Dim K_Value As Short
		Dim rs As ADODB.Recordset 'Catalogue baracorde
		Dim rj As ADODB.Recordset
		Dim rt As ADODB.Recordset
		Dim rd As ADODB.Recordset
		
		On Error GoTo updateError
		rs = getRS("SELECT * FROM RecieptEx Order By StockCode Asc")
		Do While rs.EOF = False
			
			On Error Resume Next
			rj = getRS("SELECT * FROM RecieptEx WHERE StockCode = '" & rs.Fields("StockCode").Value & "'")
			
			rt = getRS("SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" & rs.Fields("StockCode").Value & "'")
			
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rt.Fields("Catalogue_StockItemID").Value) Or rt.RecordCount = 0 Then
			Else
				cnnDB.Execute("UPDATE StockItem SET StockItem_RecipeType = 2 WHERE StockItemID = " & rt.Fields("Catalogue_StockItemID").Value)
				If rj.RecordCount > 0 Then
					On Error Resume Next
					Do While rj.EOF = False
						If prgUpdate.Value = 300 Then
							prgUpdate.Value = 0
						Else
							prgUpdate.Value = prgUpdate.Value + 0.5
						End If
						rd = getRS("SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" & rj.Fields("combStockCode").Value & "'")
						If rd.RecordCount Then
							sqlInsert = "INSERT INTO RecipeStockitemLnk (RecipeStockitemLnk_RecipeID,RecipeStockitemLnk_StockitemID,RecipeStockitemLnk_Quantity)" & " Values ( " & rt.Fields("Catalogue_StockItemID").Value & "," & rd.Fields("Catalogue_StockItemID").Value & "," & rj.Fields("Quantity").Value & ")"
						End If
						
						cnnDB.Execute(sqlInsert)
						rj.moveNext()
						If rj.EOF = False Then rs.moveNext()
					Loop 
				End If
			End If
			
			If rs.EOF = True Then Exit Do
			rs.moveNext()
		Loop 
		prgUpdate.Value = 300
		MsgBox("Import Bill Of Material was completed succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "4POS Bill of Material Import")
		dooCleanUp()
		Exit Sub
updateError: 
		MsgBox(Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "4POS Bill of Material Import")
		dooCleanUp()
	End Sub
	Sub dooCleanUp()
		cnnDB.Execute("DROP TABLE RecieptEx")
	End Sub
	
	Private Sub Command2_Click()
        Dim ShowOpen As Boolean
        Dim strPath_DB As String
		
		If ShowOpen = True Then
			Text1.Text = strPath_DB
			Command1.Enabled = True
		Else
			Exit Sub
		End If
		
	End Sub
	Function ShowOpen1() As Boolean
        Dim strPath_DB1 As String
		Dim Extention As String
        Dim cmdDlg As New OpenFileDialog
		On Error GoTo Extracter
		
		With cmdDlg
			'.CancelError = True
			.Title = "Upload Customer File"
			.FileName = ""
			.FilterIndex = 0
			.ShowDialog()
			strPath_DB1 = .FileName
		End With
		
        If strPath_DB1 <> "" Then
            If Command1.Tag = "1" Then
                Text1.Text = strPath_DB1
            Else
                txtFile.Text = strPath_DB1
            End If
            ShowOpen1 = True
        Else
            ShowOpen1 = False
        End If

        Exit Function

Extracter:
        If MsgBoxResult.Cancel Then
            Exit Function
        End If
        MsgBox(Err.Description)
	End Function
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'Dim langID As Integer
		Command1.Tag = 1
		If ShowOpen1 = True Then
			Command1.Tag = 0
			System.Windows.Forms.Application.DoEvents()
			prgUpdate.Maximum = ReadLine(Trim(Text1.Text))
			System.Windows.Forms.Application.DoEvents()
			
			If ImportCSVHandMenu(Trim(Text1.Text)) = True Then
				Me.Close()
				frmLangMenu.loadItem(0)
			End If
		Else
			Exit Sub
		End If
		Command1.Tag = 0
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Dim langID As Integer
		
		Command3.Tag = 0
		
		If ShowOpen1 = True Then
			System.Windows.Forms.Application.DoEvents()
			prgUpdate.Maximum = ReadLine(Trim(txtFile.Text))
			System.Windows.Forms.Application.DoEvents()
			If ImportCSVHand(Trim(txtFile.Text)) = True Then
				If Command3.Tag <> "0" Then
					langID = CInt(Command3.Tag)
					Me.Close()
					frmLang.loadItem(langID)
				End If
			End If
		Else
			Exit Sub
		End If
		
		
		Exit Sub
		If exUt_variable = 1 Then
			If ShowOpen1 = True Then
				System.Windows.Forms.Application.DoEvents()
				prgUpdate.Maximum = ReadLine(Trim(txtFile.Text))
				System.Windows.Forms.Application.DoEvents()
				If ImportCSVHand(Trim(txtFile.Text)) = True Then
					Me.lblHeading.Text = "HandHeld StockTake: (Item Barcode, Item Quantity)"
					UpdateCatalogID()
				End If
			Else
				Exit Sub
			End If
		ElseIf exUt_variable = 2 Then 
			If ShowOpen1 = True Then
				If ImportCSVtoAccess(Trim(txtFile.Text)) = True Then
					ExRecipe()
				End If
			Else
				Exit Sub
			End If
		End If
		
	End Sub
	Private Sub Command4_Click()
		Me.Close()
	End Sub
	Private Function ImportCSVHand(ByRef strFilePath As String) As Boolean
        Dim sql As String
		Dim oFileSys As New Scripting.FileSystemObject
		Dim oFile As Scripting.TextStream
		Dim strCSV As String
		Dim strIn As String
		Dim blEmpty As Boolean
		Dim sSplit() As String
		
		On Error GoTo ImportError
		
		blEmpty = True
		prgUpdate.Value = 1
		
		Dim rsLang As ADODB.Recordset
		If oFileSys.FileExists(strFilePath) Then
			
			cnnDB.Execute("INSERT INTO LanguageLayout ( LanguageLayout_Name ) SELECT 'New Language';")
			rsLang = getRS("SELECT Max(LanguageLayout.LanguageLayoutID) AS MaxOfLanguageLayoutID FROM LanguageLayout;")
			
			cnnDB.Execute("INSERT INTO LanguageLayoutLnk ( LanguageLayoutLnk_LanguageID, LanguageLayoutLnk_LanguageLayoutID, LanguageLayoutLnk_Description, LanguageLayoutLnk_RightTL, LanguageLayoutLnk_Screen ) SELECT theJoin.LanguageID, theJoin.LanguageLayoutID, 'None' AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT Language.LanguageID, LanguageLayout.LanguageLayoutID From Language, LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" & rsLang.Fields("MaxOfLanguageLayoutID").Value & "))) AS theJoin LEFT JOIN LanguageLayoutLnk ON (theJoin.LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) AND (theJoin.LanguageLayoutID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) Is Null));")
			sql = "UPDATE LanguageLayoutLnk AS LanguageLayoutLnk_1 INNER JOIN LanguageLayoutLnk ON LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID SET LanguageLayoutLnk.LanguageLayoutLnk_Description = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Description], LanguageLayoutLnk.LanguageLayoutLnk_RightTL = [LanguageLayoutLnk_1]![LanguageLayoutLnk_RightTL], LanguageLayoutLnk.LanguageLayoutLnk_Section = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Section], LanguageLayoutLnk.LanguageLayoutLnk_Screen = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Screen] "
			sql = sql & "WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_Description)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_Screen)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & rsLang.Fields("MaxOfLanguageLayoutID").Value & ") AND ((LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageLayoutID)=1));"
			cnnDB.Execute(sql)
			Command3.Tag = rsLang.Fields("MaxOfLanguageLayoutID").Value
			
			oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)
			System.Windows.Forms.Application.DoEvents()
			While Not oFile.AtEndOfLine
				System.Windows.Forms.Application.DoEvents()
				
				If prgUpdate.Value = prgUpdate.Maximum Then
					System.Windows.Forms.Application.DoEvents()
					prgUpdate.Value = 0
				Else
					prgUpdate.Value = prgUpdate.Value + 1
					System.Windows.Forms.Application.DoEvents()
				End If
				
				blEmpty = False
				strCSV = oFile.ReadLine
				sSplit = Split(strCSV, "|")
				System.Windows.Forms.Application.DoEvents()
				
				If strCSV <> vbNullString Then
					System.Windows.Forms.Application.DoEvents()
					
					sSplit(1) = Replace(sSplit(1), ",", "-")
					sSplit(1) = Replace(sSplit(1), "'", "''")
					
					strIn = "UPDATE LanguageLayoutLnk SET LanguageLayoutLnk_Description = '" & sSplit(1) & "' WHERE LanguageLayoutLnk_LanguageID = " & sSplit(0) & " AND LanguageLayoutLnk_LanguageLayoutID = " & rsLang.Fields("MaxOfLanguageLayoutID").Value & ";"
					cnnDB.Execute(strIn)
					System.Windows.Forms.Application.DoEvents()
				End If
			End While
			If blEmpty = True Then
				MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Handheld StockTake")
				ImportCSVHand = False
				Exit Function
				
			End If
			
			ImportCSVHand = True
			
			Exit Function
		ElseIf Not oFileSys.FileExists(strFilePath) Then 
			
			MsgBox("CSV File does not exist", MsgBoxStyle.Information, My.Application.Info.Title)
			ImportCSVHand = False
			Exit Function
		End If
		
ImportError: 
		MsgBox("Import aborted because " & Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Import Language")
		Exit Function
		Resume Next
	End Function
	
	Private Function ImportCSVHandMenu(ByRef strFilePath As String) As Boolean
		Dim oFileSys As New Scripting.FileSystemObject
		Dim oFile As Scripting.TextStream
		Dim strCSV As String
		Dim strIn As String
		Dim blEmpty As Boolean
		Dim sSplit() As String
		
		On Error GoTo ImportError
		
		blEmpty = True
		prgUpdate.Value = 1
		
		If oFileSys.FileExists(strFilePath) Then
			oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)
			System.Windows.Forms.Application.DoEvents()
			While Not oFile.AtEndOfLine
				System.Windows.Forms.Application.DoEvents()
				
				If prgUpdate.Value = prgUpdate.Maximum Then
					System.Windows.Forms.Application.DoEvents()
					prgUpdate.Value = 0
				Else
					prgUpdate.Value = prgUpdate.Value + 1
					System.Windows.Forms.Application.DoEvents()
				End If
				
				blEmpty = False
				strCSV = oFile.ReadLine
				sSplit = Split(strCSV, "|")
				System.Windows.Forms.Application.DoEvents()
				
				If strCSV <> vbNullString Then
					System.Windows.Forms.Application.DoEvents()
					
					sSplit(1) = Replace(sSplit(1), ",", "-")
					sSplit(1) = Replace(sSplit(1), "'", "''")
					
					cnnDB.Execute("UPDATE Menu SET Menu_Update=True, Menu_Name = '" & sSplit(1) & "' WHERE ((MenuID)=" & sSplit(0) & ");")
					System.Windows.Forms.Application.DoEvents()
				End If
			End While
			
			If blEmpty = True Then
				MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Handheld StockTake")
				ImportCSVHandMenu = False
				Exit Function
				
			End If
			
			ImportCSVHandMenu = True
			
			Exit Function
		ElseIf Not oFileSys.FileExists(strFilePath) Then 
			
			MsgBox("CSV File does not exist", MsgBoxStyle.Information, My.Application.Info.Title)
			ImportCSVHandMenu = False
			Exit Function
		End If
		
ImportError: 
		MsgBox("Import aborted because " & Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Import Language")
		Exit Function
		Resume Next
	End Function
	
	Public Function ImportCSVtoAccess(ByRef strFilePath As String) As Boolean
		Dim oFileSys As New Scripting.FileSystemObject
		Dim oFile As Scripting.TextStream
		Dim strCSV As String
		Dim strFldName As String 'String of fields' name
		Dim strFV As String 'String of fields' values
		Dim iCount As Short
		
		Dim x As Short
		Dim strStr_1 As String
		Dim strStr_2 As String
		Dim strStr_3 As String
		Dim strStr_4 As String
		Dim temp As String
		Dim strIn As String
		Dim blEmpty As Boolean
		Dim blTrue As Boolean
		
		Dim cCounter As Short
		
		On Error GoTo ImportError
		
		System.Windows.Forms.Application.DoEvents()
		System.Windows.Forms.Application.DoEvents()
		cCounter = 0
		blTrue = False
		blEmpty = True
		
		prgUpdate.Value = 1
		
		dReceipt = False
		
		If oFileSys.FileExists(strFilePath) Then
			
			oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)
			
			While Not oFile.AtEndOfLine
				cCounter = cCounter + 1
				If prgUpdate.Value = 300 Then
					prgUpdate.Value = 0
				Else
					prgUpdate.Value = prgUpdate.Value + 0.1
				End If
				
				blEmpty = False
				strCSV = oFile.ReadLine
				strFV = strCSV
				
				'strFldName = "StockCode Text," & _
				''                  "combStockCode Text," & _
				''                  "comStockDescription TEXT(120)," & _
				''                  "Quantity Currency"
				strFldName = "StockCode Text," & "combStockCode Text," & "Quantity Currency"
				If blTrue = False Then
					'strFldName = "StockCode Text,combStockCode Text,comStockDescription TEXT(120),Quantity Currency"
					strFldName = "StockCode Text,combStockCode Text,Quantity Currency"
					cnnDB.Execute("CREATE TABLE RecieptEx (" & strFldName & ")")
					blTrue = True
					dReceipt = True
				End If
				
				If strCSV <> vbNullString Then
					'Repeat 3 Times
					'
					strStr_1 = strCSV
					x = Len(strCSV) - Len(VB.Right(strCSV, Len(strCSV) - InStr(strCSV, ",")))
					strStr_1 = Mid(strStr_1, 1, x - 1)
					
					
					strStr_2 = VB.Right(strCSV, Len(strCSV) - InStr(strCSV, ","))
					temp = strStr_2
					x = Len(strStr_2) - Len(VB.Right(strStr_2, Len(strStr_2) - InStr(strStr_2, ",")))
					strStr_2 = Mid(strStr_2, 1, x - 1)
					
					strStr_3 = VB.Right(temp, Len(temp) - InStr(temp, ","))
					
					'temp = strStr_3
					'x = Len(strStr_3) - Len(Right(strStr_3, Len(strStr_3) - InStr(strStr_3, ",")))
					'strStr_3 = Mid$(strStr_3, 1, x - 1)
					
					'strStr_4 = Right(temp, Len(temp) - InStr(temp, ","))
					'strIn = "INSERT INTO RecieptEx (StockCode,combStockCode,comStockDescription,Quantity) VALUES " & _
					''                  "(" & Val(strStr_1) & "," & Val(strStr_2) & ",'" & Replace(Trim(strStr_3), "'", "''") & "'," & CCur(strStr_4) & ")"
					
					strIn = "INSERT INTO RecieptEx (StockCode,combStockCode,Quantity) VALUES " & "(" & Val(strStr_1) & "," & Val(strStr_2) & "," & CDec(strStr_3) & ")"
					cnnDB.Execute(strIn)
				End If
			End While
			
			If blEmpty = True Then
				MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "4POS Bill of Material Import")
				ImportCSVtoAccess = False
				Exit Function
			End If
			prgUpdate.Value = 300
			ImportCSVtoAccess = True
			Exit Function
			
		ElseIf Not oFileSys.FileExists(strFilePath) Then 
			MsgBox("CSV File does not exist", MsgBoxStyle.Information, "4POS Bill of Material Import")
			ImportCSVtoAccess = False
			Exit Function
		End If
		
ImportError: 
		If cCounter = 0 Then
			MsgBox("Export Aborted Because " & Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "4POS Bill of Material Import")
		Else
			MsgBox("Export Aborted At Record Number " & cCounter & " [" & strStr_1 & "," & strStr_2 & "," & strStr_3 & "] " & Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "4POS Bill of Material Import")
		End If
		
		If dReceipt = True Then dooCleanUp()
		
	End Function
	Sub UpdateCatalogID()
		Dim a As Object
        Dim strFldName As String
        Dim strIn As String
		Dim rj As ADODB.Recordset
		Dim rs As ADODB.Recordset
        'Dim rID As ADODB.Recordset
		
		'Set rID = getRS("SELECT * FROM " & st_Name)
		'Do While rID.EOF = False
		'        If prgUpdate.value = prgUpdate.Max Then
		'           prgUpdate.value = 0
		'        Else
		'           prgUpdate.value = prgUpdate.value + 1
		'        End If
		'    'rID("Handheld_Barcode") = 0
		'        rID("HandHeldID") = 0
		'        rID.update '"HandHeldID", 0
		' rID.moveNext
		'Loop
		
		strIn = "UPDATE " & st_Name & " SET HandHeldID = 0;"
		'strIn = "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Quantity > 0;"
		cnnDB.Execute(strIn)
		
		rj = getRS("SELECT * FROM " & st_Name)
		Do While rj.EOF = False
			If prgUpdate.Value = prgUpdate.Maximum Then
				prgUpdate.Value = 0
			Else
				prgUpdate.Value = prgUpdate.Value + 1
			End If
			
			'Set rs = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
			rs = getRS("SELECT StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, * FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" & rj.Fields("Handheld_Barcode").Value & "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));")
			If rs.RecordCount > 0 Then
				cnnDB.Execute("UPDATE " & st_Name & " SET HandHeldID = " & rs.Fields("Catalogue_StockItemID").Value & ", Quantity = " & (rj.Fields("Quantity").Value * rs.Fields("Catalogue_Quantity").Value) & " WHERE Handheld_Barcode = '" & rj.Fields("Handheld_Barcode").Value & "'")
			Else
				rs = getRS("SELECT * FROM StockItem WHERE (((StockItem.StockItem_QuickKey)='" & rj.Fields("Handheld_Barcode").Value & "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));")
				If rs.RecordCount > 0 Then cnnDB.Execute("UPDATE " & st_Name & " SET HandHeldID = " & rs.Fields("StockItemID").Value & ", Quantity = " & (rj.Fields("Quantity").Value * 1) & " WHERE Handheld_Barcode = '" & rj.Fields("Handheld_Barcode").Value & "'")
			End If
			
			
			rj.moveNext()
		Loop 
		
		'chkDuplicate:
		strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
		cnnDB.Execute("CREATE TABLE " & "Handheld777" & " (" & strFldName & ")")
		System.Windows.Forms.Application.DoEvents()
		
		rj = getRS("SELECT * FROM " & st_Name)
		Do While rj.EOF = False
			
			If IsDbNull(rj.Fields("HandHeldID").Value) Then
				a = 1
			ElseIf rj.Fields("HandHeldID").Value = 0 Then 
				a = 1
			Else
				rs = getRS("SELECT * FROM Handheld777 WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";")
				If rs.RecordCount > 0 Then
					strIn = "UPDATE Handheld777 SET Quantity = " & (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) & " WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";"
				Else
					strIn = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rj.Fields("HandHeldID").Value & ", '" & rj.Fields("Handheld_Barcode").Value & "', " & rj.Fields("Quantity").Value & ")"
				End If
				cnnDB.Execute(strIn)
			End If
			
			rj.moveNext()
		Loop 
		
		DeleteBlankID()
		
		cnnDB.Execute("DELETE * FROM " & st_Name & ";")
		'strIn = "SELECT Handheld777.* INTO " & st_Name & " FROM Handheld777" '& ResolveTable(cmbTables.Text)
		cnnDB.Execute("INSERT INTO " & st_Name & " SELECT * FROM Handheld777;")
		cnnDB.Execute("DROP TABLE Handheld777;")
		'chkDuplicate:
		
		
		MsgBox("File was extracted and exported succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		'prgUpdate.value = 300
		
	End Sub
	Sub DeleteRecieptTable()
		cnnDB.Execute("DELETE * RecipeStockitemLnk")
	End Sub
	Sub loadItems(ByRef id As Integer)
		
		If id = 1 Then
			Me.lblHeading.Text = "HandHeld StockTake: (Item Barcode, Item Quantity)"
		Else
			Me.lblHeading.Text = "BOM Item Number,Ingredients Item Number, Quantity"
		End If
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	
	Public Function ReadLine(ByRef fName As String) As Short
		Dim oFSO As New Scripting.FileSystemObject
		Dim oFSTR As Scripting.TextStream
        'Dim ret As Integer
		Dim lCtr As Integer
		If oFSO.FileExists(fName) Then
			oFSTR = oFSO.OpenTextFile(fName)
			Do While Not oFSTR.AtEndOfStream
				lCtr = lCtr + 1
				oFSTR.SkipLine()
			Loop 
			ReadLine = lCtr
			oFSTR.Close()
			'UPGRADE_NOTE: Object oFSTR may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			oFSTR = Nothing
		End If
	End Function
	
	Sub DeleteBlankID()
		Dim rj As ADODB.Recordset
		Dim rs As ADODB.Recordset
		'UPGRADE_NOTE: Val was upgraded to Val_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        'Dim Val_Renamed As Object
		Dim oFSO As New Scripting.FileSystemObject
		
		'cnnDB.Execute "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Handheld_Barcode = " & vbNullString
		rj = getRS("SELECT * FROM " & st_Name & " WHERE HandHeldID = 0")
		
		Dim i As Short
		Dim j As Short
		If rj.RecordCount > 0 Then
			MsgBox("CSV file has missing Barcodes, please verify them.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			
			'fill test array
			ReDim dChrom(rj.RecordCount - 1, 1)
			
			For i = 0 To rj.RecordCount - 1
				For j = 0 To 1
					If j = 0 Then
						dChrom(i, j) = rj.Fields("Handheld_Barcode").Value
					Else
						dChrom(i, j) = rj.Fields("Quantity").Value
					End If
				Next j
				rj.moveNext()
			Next i
			
			If oFSO.FolderExists("C:\temp\") Then 
			Else 
				oFSO.CreateFolder("C:\temp\")
			End If
			SaveAsCSV(dChrom, "C:\temp\" & st_Name & "_Missing.csv") 'App.Path & "\temp\" & st_Name & "_Missing.csv"
			
			'Set rs = getRS("SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
			'If rs.RecordCount > 0 Then cnnDB.Execute "UPDATE " & st_Name & " SET HandHeldID= " & rs("Catalogue_StockItemID") & " WHERE Handheld_Barcode = '" & rj("Handheld_Barcode") & "'"
			cnnDB.Execute("DELETE from " & st_Name & " WHERE HandHeldID = 0")
			MsgBox("CSV file has been as C:\temp\" & st_Name & "_Missing.csv")
		End If
		'MsgBox "File was extracted and exported succesfully", vbApplicationModal + vbInformation + vbOKOnly, App.title
		
	End Sub
End Class