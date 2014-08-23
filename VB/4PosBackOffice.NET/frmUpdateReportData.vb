Option Strict Off
Option Explicit On
Friend Class frmUpdateReportData
	Inherits System.Windows.Forms.Form
	Dim gCNT As Short
	Dim gTotal As Short
	
	Private Sub loadLanguage()
		
		'Label1 = No Code   [Updating Report Data...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmUpdateReportData.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadReportData()
		ShowDialog()
	End Sub
	
	Private Sub moveItem()
		gCNT = gCNT + 1
        picInner.Width = twipsToPixels(CShort(pixelToTwips(picOuter.Width, True) / gTotal * gCNT) + 100, True)
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Private Sub beginUpdate()
		picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		
		'fill the templateReport with data
		Dim ccndbReport As ADODB.Connection
        Dim lTable As String()
		Dim Y As Short
		lTable = Split("aChannel,aCompany,aConsignment,aCustomer,aDayEnd,aDayEndDepositItemLnk,aDeposit,aftConstruct,aftData,aftDataItem,aftSet,aGRV,aGRVDeposit,aGRVitem,aPackSize,aPayout,aPerson,aPOS,aPricingGroup,aPurchaseOrder,aRecipe,aRecipeStockitemLnk,aSaleItemReciept,aShrink,aStockBreakTransaction,aStockGroup,aStockItem,aStockTakeDetail,Supplier,Vat", ",")
		System.Windows.Forms.Application.DoEvents()
		gTotal = 9 + 1 * 9
		'ccndbReport.Close
		ccndbReport = openConnectionInstance("templatereport.mdb")
		For Y = 0 To UBound(lTable)
			moveItem()
			System.Windows.Forms.Application.DoEvents()
			ccndbReport.Execute("DELETE * FROM " & lTable(Y) & ";")
			ccndbReport.Execute("INSERT INTO " & lTable(Y) & " SELECT * FROM " & lTable(Y) & "1;")
		Next Y
		'fill the templateReport with data
		
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		
	End Sub
	
	Private Sub frmUpdateReportData_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		picInner.Width = 0
	End Sub
	
	Private Sub tmrStart_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrStart.Tick
		tmrStart.Enabled = False
		beginUpdate()
	End Sub
End Class