Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGlobalCost
	Inherits System.Windows.Forms.Form
	Dim strPath_DB1 As String
	
	Private Sub loadLanguage()
		
		'frmGlobalCost = No Code    [Update Cost]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmGlobalCost.Caption = rsLang("LanguageLayoutLnk_Description"): frmGlobalCost.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Closest Match DB entry 2490 = Password
		'Frame1 = No Code           [Passwords]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame11.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Closest Match DB entry 2490 = Password
		'Label2 = No Code           [Passwords]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Labels2.Caption = rsLang("LanguageLayoutLnk_Description"): Labels2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGlobalCost.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Function ShowOpen() As Boolean
		Dim Extention As String
		
		On Error GoTo Extracter
		
        With cmdDlgOpen
            '.CancelError = True
            .Title = "Upload Cost File"
            .FileName = ""
            .Filter = "CSV File (*.csv)|*.csv|CSV (*.csv)|*.csv|"
            .FilterIndex = 0
            .ShowDialog()
            strPath_DB1 = .FileName

        End With
		
		If strPath_DB1 <> "" Then
			Me.txtFileName.Text = strPath_DB1
			ShowOpen = True
		Else
			ShowOpen = False
		End If
		
		Exit Function
		
Extracter: 
		If MsgBoxResult.Cancel Then
			Exit Function
		End If
		MsgBox(Err.Description)
	End Function
	Public Function ImportCSVtoAccess(ByRef strFilePath As String) As Boolean
        Dim dReceipt As Boolean
		Dim oFileSys As New Scripting.FileSystemObject
		Dim oFile As Scripting.TextStream
		Dim strCSV As String
		Dim strFldName As String 'String of fields' name
		Dim strFV As String 'String of fields' values
		Dim iCount As Short
		
		Dim x As Short
		Dim strStr_1 As String
		Dim strStr_2 As String
		Dim temp As String
		Dim strIn As String
		Dim blEmpty As Boolean
		Dim blTrue As Boolean
		
		On Error GoTo ImportError
		
		System.Windows.Forms.Application.DoEvents()
		System.Windows.Forms.Application.DoEvents()
		
		blTrue = False
		blEmpty = True
		
		dReceipt = False
		
		If oFileSys.FileExists(strFilePath) Then
			
			oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)
			
			While Not oFile.AtEndOfLine
				
				If prgUpload.Value = 300 Then
					prgUpload.Value = 0
				Else
					prgUpload.Value = prgUpload.Value + 1
				End If
				
				blEmpty = False
				strCSV = oFile.ReadLine
				strFV = strCSV
				
				strFldName = "Barcode Text,CostPrice Currency"
				
				If blTrue = False Then
					strFldName = "Barcode Text,CostPrice Currency"
					cnnDB.Execute("CREATE TABLE FRIENDYFOODHALL (" & strFldName & ")")
					blTrue = True
					dReceipt = True
					'2 Read header
					strCSV = oFile.ReadLine
				End If
				
				
				
				If strCSV <> vbNullString Then
					
					'Repeat 4 Times
					'
					strStr_1 = strCSV
					x = Len(strCSV) - Len(VB.Right(strCSV, Len(strCSV) - InStr(strCSV, ",")))
					strStr_1 = Mid(strStr_1, 1, x - 1)
					
					
					strStr_2 = VB.Right(strCSV, Len(strCSV) - InStr(strCSV, ","))
					temp = strStr_2
					
					strIn = "INSERT INTO FRIENDYFOODHALL (Barcode,CostPrice) VALUES ('" & Trim(strStr_1) & "'," & CDec(Trim(strStr_2)) & ")"
					cnnDB.Execute(strIn)
					
					
				End If
				
			End While
			
			If blEmpty = True Then
				MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				ImportCSVtoAccess = False
				Exit Function
			End If
			prgUpload.Value = 300
			ImportCSVtoAccess = True
			Exit Function
		ElseIf Not oFileSys.FileExists(strFilePath) Then 
			MsgBox("CSV File does not exist", MsgBoxStyle.Information, My.Application.Info.Title)
			ImportCSVtoAccess = False
			Exit Function
		End If
		
		
ImportError: 
		
		MsgBox("Export Aborted Because " & Err.Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		cnnDB.Execute("DROP TABLE FRIENDYFOODHALL")
		
	End Function
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		If ShowOpen = True Then
			If ImportCSVtoAccess(Trim(txtFileName.Text)) = True Then
				DoCostingUpdate()
				Me.Close()
			End If
		Else
			Exit Sub
		End If
		
	End Sub
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Me.Close()
	End Sub
	Sub DoCostingUpdate()
		Dim rj As ADODB.Recordset
		
		rj = getRS("SELECT StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN FRIENDYFOODHALL ON Catalogue.Catalogue_Barcode = FRIENDYFOODHALL.BARCODE WHERE FRIENDYFOODHALL.BARCODE IS NOT NULL;")
		
		If rj.RecordCount Then
			If MsgBox("Your about to update [ " & rj.RecordCount & " ] Records do you want to continue?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title) = MsgBoxResult.Yes Then
				cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON [StockItem].[StockItemID]=[Catalogue].[Catalogue_StockItemID]) INNER JOIN FRIENDYFOODHALL ON [Catalogue].[Catalogue_Barcode]=[FRIENDYFOODHALL].[BARCODE] SET StockItem.StockItem_ListCost = [FRIENDYFOODHALL]![CostPrice], StockItem.StockItem_ActualCost = [FRIENDYFOODHALL]![CostPrice] WHERE [FRIENDYFOODHALL].[BARCODE] IS NOT NULL;")
				cnnDB.Execute("UPDATE StockItem SET StockItem_ActualCost = 1,StockItem_ListCost= 1 WHERE StockItem.StockItem_ListCost = 0 OR  StockItem.StockItem_ListCost = 0;")
				MsgBox("Update Completed successfully")
				cnnDB.Execute("DROP TABLE FRIENDYFOODHALL")
				
			End If
		End If
		
	End Sub
	Private Sub txtPassword_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 27 Then Me.Close()
	End Sub
	Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim dtDate As String
		Dim dtMonth As String
		Dim stPass As String
		
		'Construct password...........
		If KeyAscii = 13 Then
			If Len(VB.Day(Today)) = 1 Then dtDate = "0" & Str(VB.Day(Today)) Else dtDate = Trim(Str(VB.Day(Today)))
			If Len(Month(Today)) = 1 Then dtMonth = "0" & Str(Month(Today)) Else dtMonth = Trim(Str(Month(Today)))
			
			'Create password
			stPass = dtDate & "##" & dtMonth
			stPass = Replace(stPass, " ", "")
			
			If Trim(Me.txtPassword.Text) = stPass Then
				'Call intialize process...
				Frame1.Visible = False
			Else
				MsgBox("Incorrect password was entered!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "4POS Stock Fix")
			End If
			
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class