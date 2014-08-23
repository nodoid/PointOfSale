Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmGRVblind
	Inherits System.Windows.Forms.Form
	
	Dim gMode As Short
	Const mdProcess As Short = 1
	Const mdSupplier As Short = 0
	Const mdInstruction As Short = 2
	Dim loading As Boolean
	
    Public gSupplierID As Integer
	Public gPurchaseOrderID As Integer
	Public gSupplierSystem As Boolean
	Public gTransactionType As Short
    Dim frmMode As New List(Of GroupBox)
	Private Sub loadLanguage()

		'frmGRVblind = NO CAPTION!
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1636 'This utility will create a blank.......|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1432 'Supplier Details|Checked
		If rsLang.RecordCount Then frmMode(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmMode(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1442 'Supplier Name|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1573 'Representative Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1641 'Create New Purchase Order|Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblData = No Code      [By Clicking the "Create Purchase Order" button.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblData.Caption = rsLang("LanguageLayoutLnk_Description"): lblData.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdProceed = No Code   [Create Purchase Order]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdProceed.Caption = rsLang("LanguageLayoutLnk_Description"): cmdProceed.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2459 'New Supplier|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Note: DB Entry 1005 does not contain ">>" chars
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVblind.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub doMode(ByRef mode As Short)
        gMode = mode
        Dim x As Short
        For x = 0 To frmMode.Count - 1
            frmMode(x).Visible = False
        Next
        frmMode(gMode).Left = frmMode(0).Left
        frmMode(gMode).Top = frmMode(0).Top
        frmMode(gMode).Visible = True
        System.Windows.Forms.Application.DoEvents()

        Select Case gMode
            Case mdProcess
                Me.cmdProceed.Focus()
                cmdBack.Text = "&Back"
                cmdNext.Text = "E&xit"
            Case mdSupplier
                If Me.Visible Then lstSupplier.Focus()
                cmdBack.Text = "E&xit"
                cmdNext.Text = "&Next"
            Case mdInstruction
                MsgBox("")

        End Select
    End Sub
	
	Public Sub exitOrder()
		On Error Resume Next
		bolFNVegGRV = False
		Me.Close()
	End Sub
	
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Select Case gMode
			Case mdSupplier
				exitOrder()
			Case mdProcess
				doMode(mdSupplier)
			Case mdInstruction
				doMode(mdProcess)
		End Select
		
	End Sub
	
	
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		'    On Local Error Resume Next
		Dim sql As String
		Dim rs As ADODB.Recordset
		Select Case gMode
			Case mdSupplier
                rs = getRS("SELECT * FROM Supplier WHERE SupplierID = " & GetItemData(lstSupplier, lstSupplier.SelectedIndex))
				lblName.Text = ""
				lblRepName.Text = ""
				lblRepNumber.Text = ""
				
				gSupplierID = rs.Fields("SupplierID").Value
				lblName.Text = rs.Fields("Supplier_Name").Value
				lblRepName.Text = rs.Fields("Supplier_RepresentativeName").Value & ""
				lblRepNumber.Text = rs.Fields("Supplier_RepresentativeNumber").Value & ""
				
				doMode(mdProcess)
			Case mdProcess
				
				exitOrder()
				
		End Select
	End Sub
	
	Private Sub cmdProceed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProceed.Click
		Dim sql As String
		Dim rs As ADODB.Recordset
		If lstSupplier.SelectedIndex <> -1 Then
			sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
            sql = sql & "SELECT " & GetItemData(Me.lstSupplier, lstSupplier.SelectedIndex) & ", Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Blind)', '' FROM Company;"
			cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
			rs = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
			Me.Close()
			frmGRV.Create(rs.Fields("id").Value)
		End If
	End Sub
	
	Private Sub frmGRVblind_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmGRVblind_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loading = True
        frmMode.AddRange(New GroupBox() {_frmMode_0, _frmMode_1})

        Dim rs As ADODB.Recordset
        Dim x, lQuantity As Short
		Dim lDepositQuantity As Short
        Dim lCost As Decimal
		Dim lActualCost As Decimal
        Dim lDepositUnit As Decimal
		Dim lDepositPack As Decimal
		rs = getRS("SELECT * FROM Supplier WHERE Supplier_Disabled = 0 ORDER BY Supplier.Supplier_Name")
		Me.lstSupplier.Items.Clear()
		Do Until rs.EOF
            lstSupplier.Items.Add(New LBI(rs.Fields("Supplier_Name").Value & "", rs.Fields("SupplierID").Value))
            rs.MoveNext()
		Loop 
		lstSupplier.SelectedIndex = 0
		
		loadLanguage()
		loading = False
		
		doMode(mdSupplier)
	End Sub
	
	
	Private Sub lstSupplier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSupplier.SelectedIndexChanged
		If lstSupplier.SelectedIndex <> -1 Then cmdNext.Enabled = True
	End Sub
	
	Private Sub lstSupplier_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSupplier.DoubleClick
		cmdNext_Click(cmdNext, New System.EventArgs())
		
	End Sub
	
	Private Sub lstSupplier_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstSupplier.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdNext_Click(cmdNext, New System.EventArgs())
		End If
		If KeyAscii = 27 Then
			cmdBack_Click(cmdBack, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class