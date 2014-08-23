Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmZeroiseED
	Inherits System.Windows.Forms.Form
	Public Event ExportStarted(ByVal ExportingFormat As DatabaseExport.DatabaseExportEnum)
    Public Event ExportError(ByRef myError As ErrObject, ByVal ExportingFormat As DatabaseExport.DatabaseExportEnum)
	Public Event ExportComplete(ByVal Success As Boolean, ByVal ExportingFormat As DatabaseExport.DatabaseExportEnum)
	Private Declare Function GetQueueStatus Lib "user32" (ByVal qsFlags As Integer) As Integer
	Dim rs As ADODB.Recordset ' As ADODB.Recordset
	Dim sql As String
	
	Dim gSection As Short
	
	Const sec_Payment As Short = 0
	Const sec_Debit As Short = 1
	Const sec_Credit As Short = 2
	
	'Public Enum DatabaseExportEnum
	'    [CSV] = 0
	'    [HTML] = 1
	'    [Excel] = 2
	'End Enum
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2499 'Export Customer Details|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2501 'Please click start to export customer details|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490 'Password|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2496 'Start|Checked
		If rsLang.RecordCount Then cmdstart.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdstart.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmZeroiseED.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub frmZeroiseED_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
		'If App.PrevInstance = True Then End
		'If openConnection() = True Then
		'ExportToCSV
		'Else: MsgBox "Connection to database was not successful"
		'End If
	End Sub
	Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
		'If mdbFile.Text <> "" Then
		Dim dtDate As String
		Dim dtMonth As String
		Dim stPass As String
		
		'Construct password...........
		If Len(VB.Day(Today)) = 1 Then dtDate = "0" & Str(VB.Day(Today)) Else dtDate = Trim(Str(VB.Day(Today)))
		If Len(Month(Today)) = 1 Then dtMonth = "0" & Str(Month(Today)) Else dtMonth = Trim(Str(Month(Today)))
		
		'Create password
		stPass = dtDate & "##" & dtMonth
		stPass = Replace(stPass, " ", "")
		
		If Trim(txtPassword.Text) = stPass Then
			'       ZeroiseStock
			
			
			If openConnection() = True Then 'Trim(mdbFile.Text)
				ExportToCSV()
			Else : MsgBox("Connection to database was not successful")
			End If
			
		Else
			MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords")
		End If
		'Else
		'MsgBox "Upload your database before you continue", vbOKOnly, "Customers"
		'End If
	End Sub
	
	Function ShowOpen1() As Boolean
        Dim strPath_DB1 As String
		Dim Extention As String
		On Error GoTo Extracter
		With cmdDlgOpen
            '.CancelError = True
            .Title = "Upload Database"
            .FileName = ""
           .Filter = "Access File (*.mdb)|*.mdb|Access (*.mdb)|*.mdb|"
            .FilterIndex = 0
            .ShowDialog()
            strPath_DB1 = .FileName
        End With
		If strPath_DB1 <> "" Then
			mdbFile.Text = strPath_DB1
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
		Dim fso As New Scripting.FileSystemObject
		If ShowOpen1 = True Then
		Else
			Exit Sub
		End If
	End Sub
	Public Property FilePath() As String
		Get
            Dim x As Short
            Dim temp As String
            Dim strPath_DB1 As String
			strPath_DB1 = (Trim(mdbFile.Text))
			FilePath = mdbFile.Text
			temp = FilePath
			x = InStrRev(temp, "\")
			FilePath = Mid(temp, 1, x - 1)
			FilePath = FilePath & "\"
		End Get
		Set(ByVal Value As String)
            Dim x As Short
            Dim temp As String
			FilePath = mdbFile.Text
			temp = FilePath
			x = InStrRev(temp, "\")
			FilePath = Mid(temp, 1, x - 1)
			FilePath = FilePath & "\"
		End Set
	End Property
	Private Function DoEventsEx() As Integer
		On Error Resume Next
		DoEventsEx = GetQueueStatus(&H80 Or &H1 Or &H4 Or &H20 Or &H10)
		If DoEventsEx <> 0 Then
			System.Windows.Forms.Application.DoEvents()
		End If
	End Function
	Public Sub ExportToCSV(Optional ByVal PrintHeader As Boolean = True)
        Dim ExportFilePath As String
		Dim rs As ADODB.Recordset
		Dim i As Integer
		Dim TotalRecords As Integer
		Dim ErrorOccured As Boolean
		Dim NumberOfFields As Short
		Const quote As String = """" 'Faster then Chr$(34)
		Dim sql As String
		Dim fso As New Scripting.FileSystemObject
		
		cmdstart.Enabled = False
		cmdExit.Enabled = False
		txtPassword.Enabled = False
		
		Dim ptbl As String
		Dim t_day As String
		Dim t_Mon As String
		
		If Len(Trim(Str(VB.Day(Today)))) = 1 Then t_day = "0" & Trim(CStr(VB.Day(Today))) Else t_day = CStr(VB.Day(Today))
		If Len(Trim(Str(Month(Today)))) = 1 Then t_Mon = "0" & Trim(CStr(Month(Today))) Else t_Mon = Str(Month(Today))
		
		
		ExportFilePath = serverPath & "4POSDebtor" & Trim(CStr(Year(Today))) & Trim(t_Mon) & Trim(t_day)
		
		If fso.FileExists(ExportFilePath & ".csv") Then fso.DeleteFile((ExportFilePath & ".csv"))
		
		rs = getRS("SELECT CustomerID, Customer_InvoiceName, Customer_DepartmentName, Customer_FirstName, Customer_Surname, Customer_PhysicalAddress, Customer_PostalAddress, Customer_Telephone, Customer_Current as CurrentBalance,Customer_30Days as 30Days, Customer_60Days as 60days, Customer_90Days as 90Days, Customer_120Days as 120Days,Customer_150Days as 150Days  FROM Customer")
		
		prgBar.Maximum = rs.RecordCount
		If rs.RecordCount > 0 Then
			
			FileOpen(1, ExportFilePath & ".csv", OpenMode.Output)
			With getRS("SELECT CustomerID, Customer_InvoiceName, Customer_DepartmentName, Customer_FirstName, Customer_Surname, Customer_PhysicalAddress, Customer_PostalAddress, Customer_Telephone, Customer_Current as CurrentBalance,Customer_30Days as 30Days, Customer_60Days as 60days, Customer_90Days as 90Days, Customer_120Days as 120Days,Customer_150Days as 150Days  FROM Customer")
				rs.MoveFirst()
				NumberOfFields = rs.Fields.Count - 1
				If PrintHeader Then
					For i = 0 To NumberOfFields - 1 'Now add the field names
						Print(1, rs.Fields(i).name & ",") 'similar to the ones below
					Next i
					PrintLine(1, rs.Fields(NumberOfFields).name)
				End If
				
				Do While Not rs.EOF
					prgBar.Value = prgBar.Value + 1
					On Error Resume Next
					TotalRecords = TotalRecords + 1
					
					For i = 0 To NumberOfFields 'If there is an emty field,
						If (IsDbNull(rs.Fields(i).Value)) Then 'add a , to indicate it is
							Print(1, ",") 'empty
						Else
							If i = NumberOfFields Then
								Print(1, quote & Trim(CStr(rs.Fields(i).Value)) & quote)
							Else
								Print(1, quote & Trim(CStr(rs.Fields(i).Value)) & quote & ",")
							End If
						End If 'Putting data under "" will not
					Next i 'confuse the reader of the file
					DoEventsEx() 'between Dhaka, Bangladesh as two
					PrintLine(1) 'fields or as one field.
					rs.moveNext()
					
				Loop 
			End With
			FileClose(1)
			
			MsgBox("Customer details were successfully exported to : " & FilePath & "" & "4POSProd" & Trim(CStr(Year(Today))) & Trim(t_Mon) & Trim(t_day) & ".csv", MsgBoxStyle.OKOnly, "Customers")
			'   DoEvents
			'   DoEvents
			' MsgBox "Now Zeroising...", vbOKOnly, "Customers"
			
			'  cmdStart.Enabled = False
			'  cmdExit.Enabled = False
			
			'  Set rsZ = getRS("SELECT CustomerID FROM Customer")
			'  Do While Not rsZ.EOF
			'          DoEvents
			'          cmdProcess_Click (rsZ("CustomerID"))
			'          DoEvents
			'  rsZ.moveNext
			'  Loop
			
			'MsgBox "Completed", vbOKOnly, "Customers"
			
			'cmdStart.Enabled = True
			'cmdExit.Enabled = True
			Me.Close()
		End If
		System.Windows.Forms.Cursor.Current = Cursors.Default
		
		rs.Close()
		'cnnDB.Close
		'Set cnnDB = Nothing
		'closeConnection
	End Sub
	Private Sub frmZeroiseED_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	
    Private Sub cmdProcess_Click(ByRef cID As Integer)
        Dim amount As Decimal
        Dim txtAmountText As String
        Dim txtNarrativeText As String
        Dim txtNotesText As String
        Dim rsCus As ADODB.Recordset
        Dim cSQL As String
        Dim sql As String
        Dim sql1 As String
        Dim rs As ADODB.Recordset
        Dim id As String
        Dim days120, days60, current, lAmount, days30, days90, days150 As Decimal
        System.Windows.Forms.Application.DoEvents()
        'If txtNarrative.Text = "" Then
        '    MsgBox "Narrative is a mandarory field", vbExclamation, Me.Caption
        '    txtNarrative.SetFocus
        '    Exit Sub
        'End If
        'If CCur(txtAmount.Text) = 0 Then
        '   MsgBox "Amount is a mandarory field", vbExclamation, Me.Caption
        '   txtAmount.SetFocus
        '   Exit Sub
        'End If


        cSQL = "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit"
        cSQL = cSQL & " FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID"
        cSQL = cSQL & " WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & cID & "))"
        cSQL = cSQL & " ORDER BY CustomerTransaction.CustomerTransaction_Date DESC;"
        rsCus = getRS(cSQL)
        If CDec(rsCus("CustomerTransaction_Amount").Value) < 0 Then 'rsCus("credit") <> ""
            gSection = 1
            txtNotesText = "Zeroise Creditors Accounts"
            txtNarrativeText = "Zeroise Creditors Accounts"
            txtAmountText = (rsCus("CustomerTransaction_Amount").Value / -1)
        End If

       If CDec(rsCus("CustomerTransaction_Amount").Value) > 0 Then 'rsCus("debit") <> ""
            gSection = 2
            txtNotesText = "Zeroise Debitors Accounts"
            txtNarrativeText = "Zeroise Debitors Accounts"
            txtAmountText = (rsCus("CustomerTransaction_Amount"))
        End If


        sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )"
        Select Case gSection
            Case sec_Payment
                sql = sql & "SELECT " & cID & " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CDec(0 - CDec(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
            Case sec_Debit
                sql = sql & "SELECT " & cID & " AS Customer, 4 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CDec(txtAmountText) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
            Case sec_Credit
                sql = sql & "SELECT " & cID & " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CDec(0 - CDec(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
        End Select

        cnnDB.Execute(sql)

        rs = getRS("SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction")
        If rs.BOF Or rs.EOF Then
        Else
            id = rs.Fields("id").Value
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));")
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));")
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));")
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));")
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));")
            cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));")

            rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")

            amount = rs.Fields("CustomerTransaction_Amount").Value
            current = rs.Fields("Customer_Current").Value
            days30 = rs.Fields("Customer_30Days").Value
            days60 = rs.Fields("Customer_60Days").Value
            days90 = rs.Fields("Customer_90Days").Value
            days120 = rs.Fields("Customer_120Days").Value
            days150 = rs.Fields("Customer_150Days").Value
            If amount < 0 Then
                days150 = days150 + amount
                If (days150 < 0) Then
                    amount = days150
                    days150 = 0
                Else
                    amount = 0
                End If
                days120 = days120 + amount
                If (days120 < 0) Then
                    amount = days120
                    days120 = 0
                Else
                    amount = 0
                End If
                days90 = days90 + amount
                If (days90 < 0) Then
                    amount = days90
                    days90 = 0
                Else
                    amount = 0
                End If
                days60 = days60 + amount
                If (days60 < 0) Then
                    amount = days60
                    days60 = 0
                Else
                    amount = 0
                End If
                days30 = days30 + amount
                If (days30 < 0) Then
                    amount = days30
                    days30 = 0
                Else
                    amount = 0
                End If
            End If
             current = current + amount
            'cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
            cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " & 0 & ", Customer.Customer_30Days = " & 0 & ", Customer.Customer_60Days = " & 0 & ", Customer.Customer_90Days = " & 0 & ", Customer.Customer_120Days = " & 0 & ", Customer.Customer_150Days = " & 0 & " WHERE (((Customer.CustomerID)=" & rs.Fields("CustomerTransaction_CustomerID").Value & "));")
        End If
    End Sub
End Class