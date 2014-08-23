Option Strict Off
Option Explicit On
Friend Class frmPOSreport
	Inherits System.Windows.Forms.Form
	
	Private Sub loadLanguage()
		
		'Note: Form Caption has a spelling mistake!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2347 'Sale Transaction List|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2348 'Persons|Checked
        If rsLang.RecordCount Then _Label1_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label1_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1(1) = No Code    [Sale Channels]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(2) = No Code    [POS Devices]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2351 'Transaction Reference|Checked
        If rsLang.RecordCount Then _Label1_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label1_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2352 'Only Show Transaction with revoked Lines|Checked
		If rsLang.RecordCount Then chkRevoke.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkRevoke.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2353 'Only show transaction with one or more Reversals
		If rsLang.RecordCount Then chkReversal.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkReversal.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2354 'Do not show Consignments|Checked
		If rsLang.RecordCount Then chkNoCon.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkNoCon.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2355 'Only show transaction with foreign Currencies|Checked
		If rsLang.RecordCount Then chkFC.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkFC.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2356 'Only show Summary|Checked
		If rsLang.RecordCount Then chkSum.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkSum.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2357 'Only Show Outstanding Consignments|Checked
		If rsLang.RecordCount Then chkOutCon.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkOutCon.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1181 'Show/Print Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPOSreport.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Function getSQL() As String
        Dim sql As String
		Dim gl As Boolean
		Dim lWhere As String
		Dim x As Short
		Dim lString As String
		
		'If 1 = 1 Then lWhere = lWhere & " AND (Sale.Sale_SaleChk=False)"
		If chkOutCon.CheckState Then lWhere = lWhere & " AND (Consignment_CompleteSaleID Is Null)"
		If chkNoCon.CheckState Then lWhere = lWhere & " AND (ConsignmentID Is Null)"
		
		If chkRevoke.CheckState Then lWhere = lWhere & " AND (SaleItem_Revoke=True)"
		If chkReversal.CheckState Then lWhere = lWhere & " AND (SaleItem_Reversal=True)"
		If chkFC.CheckState Then lWhere = lWhere & " AND (Sale_PaymentType=8)"
		
		lString = ""
		For x = 0 To Me.lstChannel.Items.Count - 1
			If Me.lstChannel.GetItemChecked(x) Then
                lString = lString & " OR Sale_ChannelID=" & GetItemData(lstChannel, x)
			End If
		Next x
		If lString <> "" Then
			lString = " AND (" & Mid(lString, 4) & ")"
			lWhere = lWhere & lString
		End If
		
		lString = ""
		For x = 0 To Me.lstPerson.Items.Count - 1
			If Me.lstPerson.GetItemChecked(x) Then
                lString = lString & " OR Sale_PersonID=" & GetItemData(lstPerson, x)
			End If
		Next x
		If lString <> "" Then
			lString = " AND (" & Mid(lString, 4) & ")"
			lWhere = lWhere & lString
		End If
		
		lString = ""
		For x = 0 To Me.lstPOS.Items.Count - 1
			If Me.lstPOS.GetItemChecked(x) Then
                lString = lString & " OR Sale_POSID=" & GetItemData(lstPOS, x)
			End If
		Next x
		If lString <> "" Then
			lString = " AND (" & Mid(lString, 4) & ")"
			lWhere = lWhere & lString
		End If
		
		lString = ""
		gl = False
		For x = 0 To Me.lstSaleref.Items.Count - 1
			If Me.lstSaleref.GetItemChecked(x) Then
				If x = 0 Then
					lString = lString & " Sale_CardRef <>''"
					gl = True
				ElseIf x = 1 Then 
					If gl = True Then
						lString = lString & " OR Sale_OrderRef <>''"
					Else
						lString = lString & " Sale_OrderRef <>''"
						gl = True
					End If
				ElseIf x = 2 Then 
					If gl = True Then
						lString = lString & " OR Sale_SerialRef <>''"
					Else
						lString = lString & " Sale_SerialRef <>''"
					End If
				End If
			End If
		Next x
		
		If lString <> "" Then
			lString = " AND (" & Mid(lString, 2) & ")"
			lWhere = lWhere & lString
		End If
		
		If lWhere <> "" Then lWhere = " WHERE " & Mid(lWhere, 6)
		
		'FROM OLD BO code               sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName,aPerson1.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson1 ON Sale.Sale_PersonID = aPerson1.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID "
		'added new Mgr field below      sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName,aPerson.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID "
		'query copy of report SELECT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName, aPerson.Person_Comm FROM SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID WHERE (((Sale.Sale_PosID)=12) AND ((SaleItem.SaleItem_Reversal)=True));
		
		If chkOutCon.CheckState Then
			'sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID "
			sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName, aPOS1.POS_Name FROM ((SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID) INNER JOIN aPOS1 ON Sale.Sale_PosID = aPOS1.POSID "
		Else
			'sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem RIGHT JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID "
			sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName, aPOS1.POS_Name FROM ((SaleItem RIGHT JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID) INNER JOIN aPOS1 ON Sale.Sale_PosID = aPOS1.POSID "
		End If
		
		sql = sql & lWhere
		Debug.Print(sql)
		getSQL = sql
		
	End Function
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim sql As String
		Dim SumSales As Decimal
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument 'As New cryPOSreport
        ReportNone.Load("cryNoRecords.rpt")
        Report.Load("cryPOSreport.rpt")
		On Error Resume Next
		
		If chkSum.CheckState Then
            Report.Load("cryPOSreportSum.rpt")
		Else
            Report.Load("cryPOSreport.rpt")
			'Set Report = New cryPOSreportRevoke
		End If
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name From aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
		rs.Close()
		
		rs = getRSreport(getSQL)
		
		If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName.", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union "
		sql = sql & "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
		sql = sql & "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));"
		
		'sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) AND ((SaleItem.SaleItem_Revoke) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) AND ((SaleItem.SaleItem_Revoke) <> 0))"
		sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0))"
		rsData = getRSreport(sql)
		
		If rsData.BOF Or rsData.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		If emp_Clicked = True Then
			SumSales = 0
			Do While rs.EOF = False
				SumSales = SumSales + rs.Fields("Sale_Total").Value
				rs.moveNext()
			Loop 
			'Resise to excluding vat
			SumSales = SumSales - (SumSales * 0.14)
			rs.MoveFirst()
            Report.SetParameterValue("txtComm", IIf(IsDBNull(rs.Fields("Person_Comm").Value), 0, rs.Fields("Person_Comm").Value))
            Report.SetParameterValue("txtTotalCommision", FormatNumber((SumSales * rs.Fields("Person_Comm").Value) / 100, 2))
		End If
		
        If chkOutCon.CheckState Then Report.SetParameterValue("txtTitle", "Point Of Sale Outstanding Consignments for Device")
		
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsData)
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtComm").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	Private Function emp_Clicked() As Boolean
		Dim intj As Short
		Dim j As Short
		Dim inClick As Short
		
		inClick = lstPerson.Items.Count - 1
		
		intj = 0
		
		For j = 0 To inClick
			If lstPerson.GetItemChecked(j) = True Then
				intj = intj + 1
				emp_Clicked = True
				Exit Function
			End If
		Next 
		
		emp_Clicked = False
		
	End Function
	Private Function emp_Clicked1() As Short
		Dim intj As Short
		Dim j As Short
		Dim inClick As Short
		
		inClick = lstPerson.Items.Count - 1
		
		intj = 0
		
		For j = 0 To inClick
			If lstPerson.GetItemChecked(j) = True Then
				intj = intj + 1
			End If
		Next 
		
	End Function
	
	Private Sub frmPOSreport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim rs As ADODB.Recordset
		lstPerson.Items.Clear()
		rs = getRSreport("SELECT aPerson.PersonID, [Person_FirstName] & ' ' & [Person_Position] AS personName From aPerson Where (((aPerson.PersonID) <> 1) And ((aPerson.Person_Disabled) = False)) ORDER BY [Person_FirstName] & ' ' & [Person_Position];")
        Dim m As Integer
        Do Until rs.EOF
            m = Me.lstPerson.Items.Add(rs.Fields("PersonName").Value)
            'lstPerson = New SetItemData(m, rs.Fields("PersonID").Value)
            rs.MoveNext()
        Loop
		lstChannel.Items.Clear()
		rs = getRSreport("SELECT aChannel.ChannelID, aChannel.Channel_Name From aChannel Where (((aChannel.Channel_Disabled) = False)) ORDER BY aChannel.ChannelID;")
        'Dim m As Integer
		Do Until rs.EOF
            m = Me.lstChannel.Items.Add(rs.Fields("Channel_Name").Value)
            'lstChannel = New SetItemData(m, rs.Fields("ChannelID").Value)
			rs.moveNext()
		Loop 
		
		lstPOS.Items.Clear()
		rs = getRSreport("SELECT aPOS.POSID, aPOS.POS_Name From aPOS ORDER BY aPOS.POSID;")
		Do Until rs.EOF
            m = Me.lstPOS.Items.Add(rs.Fields("POS_Name").Value)
            'lstPOS = New SetItemData(m, rs.Fields("POSID").Value)
			rs.moveNext()
		Loop 
		
		loadLanguage()

	End Sub
End Class