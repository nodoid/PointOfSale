Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSupplierStatement
	Inherits System.Windows.Forms.Form
	Dim gMonth As Short
	Dim cnnDBStatement As New ADODB.Connection
	
	Dim gRS As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmSupplierStatement = No Code [Supplier Previous Statements]
		'Closest match DB entry 1553, but word order differs
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSupplierStatement.Caption = rsLang("LanguageLayoutLnk_Description"): frmSupplierStatement.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSupplierStatement.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNew_Click()
		frmSupplier.loadItem(0)
		doSearch()
	End Sub
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim x As Short
		Dim strDBPath As String
		Dim fso As New Scripting.FileSystemObject
		
		If DataList1.BoundText <> "" Then
			strDBPath = serverPath & "month" & gMonth - Me.cmbMonth.SelectedIndex & ".mdb"
			If fso.FileExists(strDBPath) Then
				With cnnDBStatement
					.Provider = "MSDataShape"
					cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw")
					
				End With
				SupplierStatement(CInt(DataList1.BoundText))
				
				cnnDBStatement.Close()
			Else
				MsgBox("There is no previous month statement for this Supplier", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, My.Application.Info.Title)
				Me.Close()
			End If
			
		End If
	End Sub
	Private Sub SupplierStatement(ByRef id As Integer)
		Dim lConn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim rsCompany As ADODB.Recordset
		Dim rsTransaction As ADODB.Recordset
		Dim lAddress As String
        Dim lNumber As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySupplierStatement.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
		lAddress = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
		If VB.Right(lAddress, 2) = ", " Then
			lAddress = VB.Left(lAddress, Len(lAddress) - 2)
		End If
		Report.Database.Tables(1).SetDataSource(rs)
        Report.SetParameterValue("txtAddress", lAddress)
		lNumber = ""
		If rs.Fields("Company_Telephone").Value <> "" Then lNumber = lNumber & "Tel: " & rs.Fields("Company_Telephone").Value
		If rs.Fields("Company_Fax").Value <> "" Then
			If lNumber <> "" Then lNumber = lNumber & " / "
			lNumber = lNumber & "Fax: " & rs.Fields("Company_Fax").Value
		End If
		If rs.Fields("Company_Email").Value <> "" Then
			If lNumber <> "" Then lNumber = lNumber & " / "
			lNumber = lNumber & "Email: " & rs.Fields("Company_Email").Value
		End If
        Report.SetParameterValue("txtNumbers", lNumber)
		lConn = openConnectionInstance("month" & gMonth - Me.cmbMonth.SelectedIndex & ".mdb")
		If lConn Is Nothing Then Exit Sub
		rsCompany = New ADODB.Recordset
		rsCompany.Open("SELECT * FROM Supplier Where SupplierID = " & id, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Report.Database.Tables(1).SetDataSource(rsCompany)
		
		
		rsTransaction = New ADODB.Recordset
		rsTransaction.Open("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Date, SupplierTransaction.SupplierTransaction_Reference, TransactionType.TransactionType_Name, IIf([SupplierTransaction_Amount]<0,[SupplierTransaction_Amount],0) AS credit, IIf([SupplierTransaction_Amount]>=0,[SupplierTransaction_Amount],0) AS debit, SupplierTransaction.SupplierTransaction_Amount FROM SupplierTransaction INNER JOIN TransactionType ON SupplierTransaction.SupplierTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" & id & "));", lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Report.Database.Tables(2).SetDataSource(rsTransaction)
		
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		If rsTransaction.BOF Or rsTransaction.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            ReportNone.SetParameterValue("txtTitle", "Statement")
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		
		frmReportShow.Text = "Supplier Statement"
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		frmReportShow.ShowDialog()
		
		
	End Sub
	
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		cmdPrint_Click(cmdPrint, New System.EventArgs())
	End Sub
	
	Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select
		
	End Sub
	
	
	Private Sub frmSupplierStatement_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim loading As Boolean
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
		loading = True
		rs = getRS("SELECT Company_MonthendID FROM Company;")
		gMonth = rs.Fields("Company_MonthendID").Value - 1
		cmbMonth.SelectedIndex = 0
		
		loadLanguage()
		
		doSearch()
	End Sub
	
	Private Sub frmSupplierStatement_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	Private Sub frmSupplierStatement_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				Me.DataList1.Focus()
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = "WHERE (Supplier_Name LIKE '%" & Replace(lString, " ", "%' AND Supplier_Name LIKE '%") & "%')"
		End If
		gRS = getRS("SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier " & lString & " ORDER BY Supplier_Name")
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "Supplier_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "SupplierID"
		
	End Sub
End Class