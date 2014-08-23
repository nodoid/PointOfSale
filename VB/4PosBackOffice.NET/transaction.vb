Option Strict Off
Option Explicit On
Friend Class transaction
	'local variable(s) to hold property value(s)
	Private mvarcompanyName As String 'local copy
	Private mvarposID As Integer 'local copy
	Private mvarposName As String 'local copy
	Private mvartaxNumber As String 'local copy
	Private mvarheading1 As String 'local copy
	Private mvarheading2 As String 'local copy
	Private mvarheading3 As String 'local copy
	Private mvarfooter As String 'local copy
	Private mvartransactionID As String 'local copy
	Private mvartransactionType As String 'local copy
	Private mvartransactionDate As Date 'local copy
	Private mvarchannelID As Short 'local copy
	Private mvarcashierID As Integer 'local copy
	Private mvarcashierName As String 'local copy
	Private mvarmanagerID As Integer 'local copy
	Private mvarmanagerName As String 'local copy
	Private mvarpaymentType As String 'local copy
	Private mvarpaymentSubTotal As Decimal 'local copy
	Private mvarpaymentDiscount As Decimal 'local copy
	'For Gratuity
	Private mvarpaymentGratuity As Decimal 'local copy
	'For DisChk
	Private mvarDisChk As Boolean 'local copy
	Private mvarpaymentTotal As Decimal 'local copy
	Private mvarpaymentTender As Decimal 'local copy
	Private mvarpaymentSlip As Boolean 'local copy
	Private mvarlineitems As New lineItems 'local copy
	Private mvarcustomer As customer 'local copy
	
	Private mvardeleted As Boolean 'local copy
	Private mvardeposit() As Integer 'local copy
	
	'For Order Reference.....
	Private mvarCard As String 'local copy
	Private mvarSerial As String 'local copy
	Private mvarOrder As String 'local copy
	
	'To Handle Split Tender...
	Private mvarSplitCash As Decimal 'local copy
	Private mvarSplitDebit As Decimal 'local copy
	Private mvarSplitCredit As Decimal 'local copy
	Private mvarSplitCheque As Decimal 'local copy
	
	Private mvartransactionSpecial As transactionSpecial
	
	
	Public Function creditDeposit(ByVal vData As Integer) As Boolean
        Dim x As Integer
		creditDeposit = False
        For x = 0 To UBound(mvardeposit)
            'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If mvardeposit(x) = vData Then
                Exit Function
            End If
        Next x
		creditDeposit = True
		ReDim Preserve mvardeposit(UBound(mvardeposit) + 1)
		mvardeposit(UBound(mvardeposit)) = vData
	End Function
	Public Sub loadCurrent(Optional ByRef lPath As String = "")
        Dim intLineNo As Integer
        Dim prTender As Integer
        Dim y As Integer
        Dim gPath As String
		Dim fso As New Scripting.FileSystemObject
		Dim textstream As Scripting.TextStream
		'UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim lineitem_Renamed As lineItem
		'UPGRADE_NOTE: customer was upgraded to customer_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim customer_Renamed As customer
		'UPGRADE_NOTE: transactionSpecial was upgraded to transactionSpecial_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim transactionSpecial_Renamed As transactionSpecial
		Dim lString As String
        Dim dataArray As String()
        Dim lineArray As String()
		Dim x As Integer
		Dim bool1 As Boolean
		'UPGRADE_NOTE: Object mvarcustomer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarcustomer = Nothing
		'UPGRADE_NOTE: Object mvartransactionSpecial may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvartransactionSpecial = Nothing
		'UPGRADE_NOTE: Object mvarlineitems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarlineitems = Nothing
		
		'On Local Error Resume Next
		On Error GoTo Load_Err
		
		bool1 = False
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If lPath = "" Then lPath = gPath & "current.tra"
        Dim lArray As String()
		If fso.FileExists(lPath) Then
			textstream = fso.OpenTextFile(lPath, Scripting.IOMode.ForReading, True)
			lString = textstream.ReadAll
			'UPGRADE_WARNING: Couldn't resolve default property of object dataArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataArray = Split(lString, Chr(255))
			For x = LBound(dataArray) To UBound(dataArray)
				
				'UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If dataArray(x) <> "" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object dataArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lineArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lineArray = Split(dataArray(x), Chr(254))
					Select Case lineArray(0)
						Case "tran"
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarchannelID = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcashierID = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcashierName = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarchannelID = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcompanyName = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvardeleted = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarfooter = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading1 = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading2 = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading3 = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarmanagerID = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarmanagerName = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentDiscount = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentSlip = lineArray(13)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentSubTotal = lineArray(14)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentTender = lineArray(15)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentTotal = lineArray(16)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentType = lineArray(17)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarposID = lineArray(18)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarposName = lineArray(19)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartaxNumber = lineArray(20)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionDate = lineArray(21)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionID = lineArray(22)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionType = lineArray(23)
							
							'Additional Code
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarCard = lineArray(26)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSerial = lineArray(27)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarOrder = lineArray(28)
							
							'Additional Split
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCash = lineArray(29)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitDebit = lineArray(30)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCredit = lineArray(31)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCheque = lineArray(32)
							
							'For Gratuity
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentGratuity = lineArray(33)
							'For DisChk
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarDisChk = lineArray(34)
							
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(35). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If UBound(lineArray) > 34 And lineArray(35) <> "" Then
								'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								'UPGRADE_WARNING: Couldn't resolve default property of object lArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lArray = Split(lineArray(35), "/")
								ReDim mvardeposit(UBound(lArray))
								
								For y = 1 To UBound(lArray)
									'UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									'UPGRADE_WARNING: Couldn't resolve default property of object lArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									mvardeposit(y) = lArray(y)
								Next y
							End If
							
						Case "spec"
							transactionSpecial_Renamed = New transactionSpecial
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.address = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.mobile = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.name = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.quote = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.saleID = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.telephone = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.transactionType = lineArray(7)
							mvartransactionSpecial = transactionSpecial_Renamed
							
						Case "cust"
							customer_Renamed = New customer
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.channelID = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.creditLimit = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.department = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.fax = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.Key = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.name = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.outstanding = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.person = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.physical = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.postal = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.signed_Renamed = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.telephone = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.terms = lineArray(13)
							
							If UBound(lineArray) = 14 Then
								'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.tax = lineArray(14)
							Else
								customer_Renamed.tax = ""
							End If
							
							mvarcustomer = customer_Renamed
						Case "item"
							lineitem_Renamed = New lineItem
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.build = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.code = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.depositType = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.id = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.lineNo = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.name = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.originalPrice = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.price = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.quantity = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.receiptName = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.dataType = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.reversal = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.revoke = lineArray(13)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.setBuild = lineArray(14)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.shrink = lineArray(15)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.transactionType = lineArray(16)
							
							intCur = intCur + 1
							'UPGRADE_WARNING: Couldn't resolve default property of object prTender. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							prTender = True
							bool1 = True
							
							'On Local Error Resume Next
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.vat = lineArray(17)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.increment = lineArray(18)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.cashPrice = lineArray(19)
							'changed for airtime
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.sPin = lineArray(20)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.sSerial = lineArray(21)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.sExpiry = lineArray(22)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.atitem = lineArray(23)
							'changed for airtime
							mvarlineitems.Add(lineitem_Renamed)
							
					End Select
				End If
			Next 
		End If
		
		If bool1 = True Then
			
			'UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			intLineNo = lineitem_Renamed.lineNo
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			intLineNo = 0
		End If
		
		
		Exit Sub
Load_Err: 
		MsgBox(Err.Number & " : " & Err.Description)
		Resume Next
	End Sub
	Public Sub flush(Optional ByRef lName As String = "")
        Dim saveTraSvr As String
        Dim gPath As String
        Dim x As Integer
		Dim fso As New Scripting.FileSystemObject
		Dim textstream As Scripting.TextStream
		'UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim lineitem_Renamed As lineItem
		Dim lString As String
		rebuildData()
		
		Dim ts As transactionSpecial ' moved from TAG 1
		
		lString = lString & "tran" & Chr(254)
		lString = lString & mvarcashierID & Chr(254)
		lString = lString & mvarcashierName & Chr(254)
		lString = lString & mvarchannelID & Chr(254)
		lString = lString & mvarcompanyName & Chr(254)
		lString = lString & mvardeleted & Chr(254)
		lString = lString & mvarfooter & Chr(254)
		lString = lString & mvarheading1 & Chr(254)
		lString = lString & mvarheading2 & Chr(254)
		lString = lString & mvarheading3 & Chr(254)
		lString = lString & mvarmanagerID & Chr(254)
		lString = lString & mvarmanagerName & Chr(254)
		lString = lString & mvarpaymentDiscount & Chr(254)
		lString = lString & mvarpaymentSlip & Chr(254)
		
		If mvartransactionSpecial Is Nothing Then
			lString = lString & mvarpaymentSubTotal & Chr(254)
			lString = lString & mvarpaymentTender & Chr(254)
			lString = lString & mvarpaymentTotal & Chr(254)
		Else
			If mvartransactionSpecial.transactionType = "stocktransfer" Then 'made changes for XFer Price
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
			ElseIf mvartransactionSpecial.transactionType = "Quote" Or mvartransactionSpecial.transactionType = "Data" Then 
				lString = lString & mvarpaymentSubTotal & Chr(254)
				lString = lString & mvarpaymentTender & Chr(254)
				lString = lString & mvarpaymentTotal & Chr(254)
			ElseIf mvartransactionSpecial.transactionType = "Consignment Complete" Then 
				lString = lString & mvarpaymentSubTotal & Chr(254)
				lString = lString & mvarpaymentTender & Chr(254)
				lString = lString & mvarpaymentTotal & Chr(254)
			Else
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
			End If
		End If
		
		
		lString = lString & mvarpaymentType & Chr(254)
		lString = lString & mvarposID & Chr(254)
		lString = lString & mvarposName & Chr(254)
		lString = lString & mvartaxNumber & Chr(254)
		lString = lString & mvartransactionDate & Chr(254)
		
		'for voucher number id
		'If saveTraSvr = True And lName <> "" And lName <> "current.tra" Then
		If Right(lName, 4) = ".tmp" And lName <> "current.tra" Then
			If mvartransactionID = "" Then mvartransactionID = Mid(lName, 1, InStr(lName, ".") - 1)
		End If
		
		lString = lString & mvartransactionID & Chr(254)
		lString = lString & mvartransactionType & Chr(254)
		lString = lString & "0" & Chr(254)
		lString = lString & "0" & Chr(254)
		
		'Added Here
		lString = lString & mvarCard & Chr(254)
		lString = lString & mvarSerial & Chr(254)
		lString = lString & mvarOrder & Chr(254)
		
		'Split Tender
		lString = lString & mvarSplitCash & Chr(254)
		lString = lString & mvarSplitDebit & Chr(254)
		lString = lString & mvarSplitCredit & Chr(254)
		lString = lString & mvarSplitCheque & Chr(254)
		
		'For Gratuity
		lString = lString & mvarpaymentGratuity & Chr(254)
		'For DisChk
		lString = lString & mvarDisChk & Chr(254)
		
		For x = 1 To UBound(mvardeposit)
			'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lString & "/" & mvardeposit(x)
		Next x
		
		lString = lString & Chr(255)
		If mvarcustomer Is Nothing Then
		Else
			lString = lString & "cust" & Chr(254)
			lString = lString & mvarcustomer.channelID & Chr(254)
			lString = lString & mvarcustomer.creditLimit & Chr(254)
			lString = lString & mvarcustomer.department & Chr(254)
			lString = lString & mvarcustomer.fax & Chr(254)
			lString = lString & mvarcustomer.Key & Chr(254)
			lString = lString & mvarcustomer.name & Chr(254)
			lString = lString & mvarcustomer.outstanding & Chr(254)
			lString = lString & mvarcustomer.person & Chr(254)
			lString = lString & mvarcustomer.physical & Chr(254)
			lString = lString & mvarcustomer.postal & Chr(254)
			lString = lString & mvarcustomer.signed_Renamed & Chr(254)
			lString = lString & mvarcustomer.telephone & Chr(254)
			lString = lString & mvarcustomer.terms & Chr(254)
			lString = lString & mvarcustomer.tax & Chr(255)
		End If
		
		' TAG 1
		If mvartransactionSpecial Is Nothing Then
		Else
			lString = lString & "spec" & Chr(254)
			lString = lString & mvartransactionSpecial.address & Chr(254)
			lString = lString & mvartransactionSpecial.mobile & Chr(254)
			lString = lString & mvartransactionSpecial.name & Chr(254)
			lString = lString & mvartransactionSpecial.quote & Chr(254)
			lString = lString & mvartransactionSpecial.saleID & Chr(254)
			lString = lString & mvartransactionSpecial.telephone & Chr(254)
			lString = lString & mvartransactionSpecial.transactionType & Chr(255)
		End If
		For	Each lineitem_Renamed In mvarlineitems
			lString = lString & "item" & Chr(254) & lineitem_Renamed.build & Chr(254)
			lString = lString & lineitem_Renamed.code & Chr(254)
			lString = lString & lineitem_Renamed.depositType & Chr(254)
			lString = lString & lineitem_Renamed.id & Chr(254)
			lString = lString & lineitem_Renamed.lineNo & Chr(254)
			lString = lString & lineitem_Renamed.name & Chr(254)
			
			If mvartransactionSpecial Is Nothing Then
				lString = lString & lineitem_Renamed.originalPrice & Chr(254)
				lString = lString & lineitem_Renamed.price & Chr(254)
			Else
				If mvartransactionSpecial.transactionType = "stocktransfer" Then 'made changes for XFer Price
					lString = lString & 0 & Chr(254)
					lString = lString & 0 & Chr(254)
				Else
					lString = lString & lineitem_Renamed.originalPrice & Chr(254)
					lString = lString & lineitem_Renamed.price & Chr(254)
				End If
			End If
			
			
			lString = lString & lineitem_Renamed.quantity & Chr(254)
			lString = lString & lineitem_Renamed.receiptName & Chr(254)
			lString = lString & lineitem_Renamed.dataType & Chr(254)
			lString = lString & lineitem_Renamed.reversal & Chr(254)
			lString = lString & lineitem_Renamed.revoke & Chr(254)
			lString = lString & lineitem_Renamed.setBuild & Chr(254)
			lString = lString & lineitem_Renamed.shrink & Chr(254)
			lString = lString & lineitem_Renamed.transactionType & Chr(254)
			lString = lString & lineitem_Renamed.vat & Chr(254)
			lString = lString & lineitem_Renamed.increment & Chr(254)
			lString = lString & lineitem_Renamed.cashPrice & Chr(254)
			'changed for airtime
			'lString = lString & lineitem.cashPrice & Chr(255)
			lString = lString & lineitem_Renamed.sPin & Chr(254)
			lString = lString & lineitem_Renamed.sSerial & Chr(254)
			lString = lString & lineitem_Renamed.sExpiry & Chr(254)
			lString = lString & lineitem_Renamed.atitem & Chr(255)
			'changed for airtime
		Next lineitem_Renamed
		If lName = "" Then lName = "current.tra"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object saveTraSvr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If saveTraSvr = True And lName <> "current.tra" Then
			If Left(LCase(lName), 9) = "complete\" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If fso.FileExists(gPath & lName) Then fso.DeleteFile(gPath & lName, True)
				'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				textstream = fso.OpenTextFile(gPath & lName, Scripting.IOMode.ForWriting, True)
			Else
				If fso.FileExists(serverPath & "data\save\" & lName) Then fso.DeleteFile(serverPath & "data\save\" & lName, True)
				textstream = fso.OpenTextFile(serverPath & "data\save\" & lName, Scripting.IOMode.ForWriting, True)
			End If
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If fso.FileExists(gPath & lName) Then fso.DeleteFile(gPath & lName, True)
			'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			textstream = fso.OpenTextFile(gPath & lName, Scripting.IOMode.ForWriting, True)
		End If
		
		
		textstream.Write(lString)
		textstream.Close()
	End Sub
	
	
    Public Property transactionSpecial_Renamed() As transactionSpecial
        Get
            '    If mvartransactionSpecial Is Nothing Then
            '        Set mvartransactionSpecial = New transactionSpecial
            '    End If
            transactionSpecial_Renamed = mvartransactionSpecial
        End Get
        Set(ByVal Value As transactionSpecial)
            mvartransactionSpecial = Value
            'flush
        End Set
    End Property
	
	
    Public Property customer_Renamed() As customer
        Get
            '    If mvarcustomer Is Nothing Then
            '        Set mvarcustomer = New customer
            '    End If
            customer_Renamed = mvarcustomer
        End Get
        Set(ByVal Value As customer)
            mvarcustomer = Value
            'flush
        End Set
    End Property
	
	
	
	
	Public Property lineItems() As lineItems
		Get
			If mvarlineitems Is Nothing Then
				mvarlineitems = New lineItems
			End If
			lineItems = mvarlineitems
		End Get
		Set(ByVal Value As lineItems)
			mvarlineitems = Value
		End Set
	End Property
	
	
	
	Public Property paymentSlip() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentSlip
			paymentSlip = mvarpaymentSlip
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentSlip = 5
			mvarpaymentSlip = Value
		End Set
	End Property
	
	
	
	Public Property deleted() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.deleted
			deleted = mvardeleted
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.deleted = 5
			mvardeleted = Value
		End Set
	End Property
	
	
	
	
	Public Property paymentTender() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentTender
			paymentTender = mvarpaymentTender
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentTender = 5
			mvarpaymentTender = Value
		End Set
	End Property
	
	
	
	
	
	Public Property paymentTotal() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentTotal
			paymentTotal = mvarpaymentTotal
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentTotal = 5
			mvarpaymentTotal = Value
		End Set
	End Property
	
	
	
	
	Public Property DisChk() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentSlip
			DisChk = mvarDisChk
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentSlip = 5
			mvarDisChk = Value
		End Set
	End Property
	
	'For Gratuity
	
	
	Public Property paymentGratuity() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentDiscount
			paymentGratuity = mvarpaymentGratuity
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentDiscount = 5
			mvarpaymentGratuity = Value
		End Set
	End Property
	
	
	
	Public Property paymentDiscount() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentDiscount
			paymentDiscount = mvarpaymentDiscount
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentDiscount = 5
			mvarpaymentDiscount = Value
		End Set
	End Property
	
	
	
	
	
	Public Property paymentSubTotal() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentSubTotal
			paymentSubTotal = mvarpaymentSubTotal
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentSubTotal = 5
			mvarpaymentSubTotal = Value
		End Set
	End Property
	
	
	
	Public Property paymentType() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.paymentType
			paymentType = mvarpaymentType
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.paymentType = 5
			mvarpaymentType = Value
		End Set
	End Property
	
	
	
	
	
	Public Property managerName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.managerName
			managerName = mvarmanagerName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.managerName = 5
			mvarmanagerName = Value
		End Set
	End Property
	
	
	
	
	
	Public Property managerID() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.managerID
			managerID = mvarmanagerID
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.managerID = 5
			mvarmanagerID = Value
		End Set
	End Property
	
	
	Friend Property cashierName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.cashierName
			cashierName = mvarcashierName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.cashierName = 5
			mvarcashierName = Value
		End Set
	End Property
	
	
	
	
	
	Public Property cashierID() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.cashierID
			cashierID = mvarcashierID
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.cashierID = 5
			mvarcashierID = Value
		End Set
	End Property
	
	
	
	
	
	Friend Property channelID() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.channelID
			channelID = mvarchannelID
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.channelID = 5
			mvarchannelID = Value
		End Set
	End Property
	
	
	
	
	
	Public Property transactionDate() As Date
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.transactionDate
			transactionDate = mvartransactionDate
		End Get
		Set(ByVal Value As Date)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.transactionDate = 5
			mvartransactionDate = Value
		End Set
	End Property
	
	
	
	
	
	Friend Property transactionType() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.transactionType
			transactionType = mvartransactionType
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.transactionType = 5
			mvartransactionType = Value
		End Set
	End Property
	
	
	
	
	
	Friend Property transactionID() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.transactionID
			transactionID = mvartransactionID
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.transactionID = 5
			mvartransactionID = Value
		End Set
	End Property
	
	
	
	Public Property footer() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.footer
			footer = mvarfooter
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.footer = 5
			mvarfooter = Value
		End Set
	End Property
	
	
	
	
	
	Public Property heading3() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.heading3
			heading3 = mvarheading3
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.heading3 = 5
			mvarheading3 = Value
		End Set
	End Property
	
	
	
	
	Public Property heading2() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.heading2
			heading2 = mvarheading2
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.heading2 = 5
			mvarheading2 = Value
		End Set
	End Property
	
	
	Public Property heading1() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.heading1
			heading1 = mvarheading1
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.heading1 = 5
			mvarheading1 = Value
		End Set
	End Property
	
	
	Public Property taxNumber() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.taxNumber
			taxNumber = mvartaxNumber
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.taxNumber = 5
			mvartaxNumber = Value
		End Set
	End Property
	
	
	
	Public Property posName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.posName
			posName = mvarposName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.posName = 5
			mvarposName = Value
		End Set
	End Property
	
	
	
	
	
	Public Property posID() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.posID
			posID = mvarposID
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.posID = 5
			mvarposID = Value
		End Set
	End Property
	Public Property companyName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			companyName = mvarcompanyName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarcompanyName = Value
		End Set
	End Property
	
	
	'New Class addition....
	
	Public Property OrderRefer() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			OrderRefer = mvarOrder
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarOrder = Value
		End Set
	End Property
	
	Public Property CardRefer() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			CardRefer = mvarCard
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarCard = Value
		End Set
	End Property
	
	
	Public Property SerialRefer() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			SerialRefer = mvarSerial
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarSerial = Value
		End Set
	End Property
	Public Property TSplitCash() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			TSplitCash = mvarSplitCash
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarSplitCash = Value
		End Set
	End Property
	Public Property TSplitCheque() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			TSplitCheque = mvarSplitCheque
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarSplitCheque = Value
		End Set
	End Property
	Public Property TSplitDebit() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			TSplitDebit = mvarSplitDebit
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarSplitDebit = Value
		End Set
	End Property
	Public Property TSplitCredit() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.companyName
			TSplitCredit = mvarSplitCredit
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.companyName = 5
			mvarSplitCredit = Value
		End Set
	End Property
	Public Sub resyncTransaction()
		Dim gDeposits As Object
		Dim gStockItems As Object
		Dim stcBarcode As Object
		Dim lUnit, lPack As Object
		Dim lPrice As Decimal
		Dim lQuantity As Short
		'UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim lineitem_Renamed As lineItem
		
		For	Each lineitem_Renamed In mvarlineitems
			If lineitem_Renamed.depositType = 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object stcBarcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				stcBarcode = lineitem_Renamed.code
				'UPGRADE_WARNING: Couldn't resolve default property of object gStockItems.getPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lPrice = gStockItems.getPrice(lineitem_Renamed.id, lineitem_Renamed.shrink)
				
				If System.Math.Abs(lineitem_Renamed.price) = System.Math.Abs(lineitem_Renamed.originalPrice) Then
					If lineitem_Renamed.reversal Then
						lineitem_Renamed.price = 0 - lPrice
					Else
						lineitem_Renamed.price = lPrice
					End If
					lineitem_Renamed.originalPrice = lineitem_Renamed.price
				End If
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object gDeposits.getPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lPrice = gDeposits.getPrice(lineitem_Renamed.id, lineitem_Renamed.depositType)
				If System.Math.Abs(lineitem_Renamed.price) = System.Math.Abs(lineitem_Renamed.originalPrice) Then
					If lineitem_Renamed.reversal Then
						lineitem_Renamed.price = lPrice
					Else
						If lineitem_Renamed.setBuild Then
						Else
							lineitem_Renamed.price = 0 - lPrice
						End If
					End If
					lineitem_Renamed.originalPrice = lineitem_Renamed.price
				End If
			End If
		Next lineitem_Renamed
	End Sub
	
	Public Sub rebuildData()
		Dim gChannel As Object
		Dim gManager As Object
		Dim gCashier As Object
		If gCashier Is Nothing Then
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gCashier.id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarcashierID = gCashier.id
			'UPGRADE_WARNING: Couldn't resolve default property of object gCashier.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarcashierName = gCashier.name
		End If
		If gManager Is Nothing Then
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gManager.id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarmanagerID = gManager.id
			'UPGRADE_WARNING: Couldn't resolve default property of object gManager.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarmanagerName = gManager.name
		End If
		If gChannel Is Nothing Then
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gChannel.Key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarchannelID = gChannel.Key
		End If
	End Sub
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		Dim gParameters As Object
		On Error GoTo ErrHandle
		
		If gParameters Is Nothing Then
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.companyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarcompanyName = gParameters.companyName
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.footer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarfooter = gParameters.footer
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarheading1 = gParameters.heading1
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarheading2 = gParameters.heading2
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.heading3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarheading3 = gParameters.heading3
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.posID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarposID = gParameters.posID
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.posName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvarposName = gParameters.posName
			'UPGRADE_WARNING: Couldn't resolve default property of object gParameters.taxNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mvartaxNumber = gParameters.taxNumber
			mvartransactionDate = Now
		End If
		mvartransactionType = "Sale"
		mvarpaymentDiscount = 0
		mvarpaymentSlip = False
		mvardeleted = False
		mvarpaymentSubTotal = 0
		mvarpaymentTender = 0
		mvarpaymentTotal = 0
		mvarpaymentType = CStr(-1)
		ReDim mvardeposit(0)
		rebuildData()
		
		Exit Sub
ErrHandle: 
		Resume Next
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	
	
	Public Sub loadCurrentV(Optional ByRef lPath As String = "", Optional ByRef cTotal As Decimal = 0)
		Dim intLineNo As Object
		Dim prTender As Object
		Dim y As Object
		Dim gPath As Object
		Dim fso As New Scripting.FileSystemObject
		Dim textstream As Scripting.TextStream
		'UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim lineitem_Renamed As lineItem
		'UPGRADE_NOTE: customer was upgraded to customer_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim customer_Renamed As customer
		'UPGRADE_NOTE: transactionSpecial was upgraded to transactionSpecial_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim transactionSpecial_Renamed As transactionSpecial
		Dim lString As String
		Dim dataArray As Object
		Dim lineArray As Object
		Dim x As Integer
		Dim bool1 As Boolean
		'UPGRADE_NOTE: Object mvarcustomer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarcustomer = Nothing
		'UPGRADE_NOTE: Object mvartransactionSpecial may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvartransactionSpecial = Nothing
		'UPGRADE_NOTE: Object mvarlineitems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarlineitems = Nothing
		
		'On Local Error Resume Next
		On Error GoTo Load_Err
		
		bool1 = False
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If lPath = "" Then lPath = gPath & "current.tra"
		Dim lArray As Object
		If fso.FileExists(lPath) Then
			textstream = fso.OpenTextFile(lPath, Scripting.IOMode.ForReading, True)
			lString = textstream.ReadAll
			'UPGRADE_WARNING: Couldn't resolve default property of object dataArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataArray = Split(lString, Chr(255))
			For x = LBound(dataArray) To UBound(dataArray)
				
				'UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If dataArray(x) <> "" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object dataArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lineArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lineArray = Split(dataArray(x), Chr(254))
					Select Case lineArray(0)
						Case "tran"
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarchannelID = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcashierID = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcashierName = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarchannelID = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarcompanyName = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvardeleted = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarfooter = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading1 = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading2 = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarheading3 = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarmanagerID = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarmanagerName = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentDiscount = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentSlip = lineArray(13)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentSubTotal = lineArray(14)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentTender = lineArray(15)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentTotal = lineArray(16)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentType = lineArray(17)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarposID = lineArray(18)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarposName = lineArray(19)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartaxNumber = lineArray(20)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionDate = lineArray(21)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionID = lineArray(22)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvartransactionType = lineArray(23)
							
							'Additional Code
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarCard = lineArray(26)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSerial = lineArray(27)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarOrder = lineArray(28)
							
							'Additional Split
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCash = lineArray(29)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitDebit = lineArray(30)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCredit = lineArray(31)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarSplitCheque = lineArray(32)
							
							'For Gratuity
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarpaymentGratuity = lineArray(33)
							'For DisChk
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							mvarDisChk = lineArray(34)
							
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(35). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If UBound(lineArray) > 34 And lineArray(35) <> "" Then
								'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								'UPGRADE_WARNING: Couldn't resolve default property of object lArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								lArray = Split(lineArray(35), "/")
								ReDim mvardeposit(UBound(lArray))
								
								For y = 1 To UBound(lArray)
									'UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									'UPGRADE_WARNING: Couldn't resolve default property of object lArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									mvardeposit(y) = lArray(y)
								Next y
							End If
							
						Case "spec"
							transactionSpecial_Renamed = New transactionSpecial
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.address = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.mobile = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.name = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.quote = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.saleID = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.telephone = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							transactionSpecial_Renamed.transactionType = lineArray(7)
							mvartransactionSpecial = transactionSpecial_Renamed
							
						Case "cust"
							customer_Renamed = New customer
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.channelID = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.creditLimit = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.department = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.fax = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.Key = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.name = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.outstanding = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.person = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.physical = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.postal = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.signed_Renamed = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.telephone = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							customer_Renamed.terms = lineArray(13)
							
							If UBound(lineArray) = 14 Then
								'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								customer_Renamed.tax = lineArray(14)
							Else
								customer_Renamed.tax = ""
							End If
							
							mvarcustomer = customer_Renamed
						Case "item"
							lineitem_Renamed = New lineItem
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.build = lineArray(1)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.code = lineArray(2)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.depositType = lineArray(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.id = lineArray(4)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.lineNo = lineArray(5)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.name = lineArray(6)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.originalPrice = lineArray(7)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.price = lineArray(8)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.quantity = lineArray(9)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.receiptName = lineArray(10)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.dataType = lineArray(11)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.reversal = lineArray(12)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.revoke = lineArray(13)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.setBuild = lineArray(14)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.shrink = lineArray(15)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.transactionType = lineArray(16)
							
							intCur = intCur + 1
							'UPGRADE_WARNING: Couldn't resolve default property of object prTender. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							prTender = True
							bool1 = True
							
							'On Local Error Resume Next
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.vat = lineArray(17)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.increment = lineArray(18)
							'UPGRADE_WARNING: Couldn't resolve default property of object lineArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lineitem_Renamed.cashPrice = lineArray(19)
							mvarlineitems.Add(lineitem_Renamed)
							
					End Select
				End If
			Next 
		End If
		
		If bool1 = True Then
			
			'UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			intLineNo = lineitem_Renamed.lineNo
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			intLineNo = 0
		End If
		
		
		Exit Sub
Load_Err: 
		MsgBox(Err.Number & " : " & Err.Description)
		Resume Next
	End Sub
	
	Public Sub flushV(Optional ByRef lName As String = "", Optional ByRef cTotal As Decimal = 0)
		Dim saveTraSvr As Object
		Dim gPath As Object
		Dim x As Object
		Dim postTransactionV As Object
		Dim gTransaction As Object
		Dim fso As New Scripting.FileSystemObject
		Dim textstream As Scripting.TextStream
		'UPGRADE_NOTE: lineitem was upgraded to lineitem_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim lineitem_Renamed As lineItem
		Dim lString As String
		rebuildData()
		
		Dim ts As transactionSpecial ' moved from TAG 1
		
		lString = lString & "tran" & Chr(254)
		lString = lString & mvarcashierID & Chr(254)
		lString = lString & mvarcashierName & Chr(254)
		lString = lString & mvarchannelID & Chr(254)
		lString = lString & mvarcompanyName & Chr(254)
		lString = lString & mvardeleted & Chr(254)
		lString = lString & mvarfooter & Chr(254)
		lString = lString & mvarheading1 & Chr(254)
		lString = lString & mvarheading2 & Chr(254)
		lString = lString & mvarheading3 & Chr(254)
		lString = lString & mvarmanagerID & Chr(254)
		lString = lString & mvarmanagerName & Chr(254)
		lString = lString & mvarpaymentDiscount & Chr(254)
		lString = lString & mvarpaymentSlip & Chr(254)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gTransaction.paymentTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gTransaction.paymentTotal = cTotal
		
		If mvartransactionSpecial Is Nothing Then
			lString = lString & cTotal & Chr(254)
			lString = lString & mvarpaymentTender & Chr(254)
			lString = lString & cTotal & Chr(254)
		Else
			If mvartransactionSpecial.transactionType = "stocktransfer" Then 'made changes for XFer Price
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
			ElseIf mvartransactionSpecial.transactionType = "Quote" Or mvartransactionSpecial.transactionType = "Data" Then 
				lString = lString & mvarpaymentSubTotal & Chr(254)
				lString = lString & mvarpaymentTender & Chr(254)
				lString = lString & mvarpaymentTotal & Chr(254)
			Else
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
				lString = lString & 0 & Chr(254)
			End If
		End If
		
		
		lString = lString & 1 & Chr(254)
		lString = lString & mvarposID & Chr(254)
		lString = lString & mvarposName & Chr(254)
		lString = lString & mvartaxNumber & Chr(254)
		lString = lString & mvartransactionDate & Chr(254)
		
		'for voucher number id
		'If saveTraSvr = True And lName <> "" And lName <> "current.tra" Then
		'If Right(lName, 4) = ".tmp" And lName <> "current.tra" Then
		'    If mvartransactionID = "" Then mvartransactionID = Mid(lName, 1, InStr(lName, ".") - 1)
		'End If
		'UPGRADE_WARNING: Couldn't resolve default property of object postTransactionV. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mvartransactionID = postTransactionV
		'lID = mvartransactionID
		lString = lString & mvartransactionID & Chr(254)
		lString = lString & mvartransactionType & Chr(254)
		lString = lString & "0" & Chr(254)
		lString = lString & "0" & Chr(254)
		
		'Added Here
		lString = lString & mvarCard & Chr(254)
		lString = lString & mvarSerial & Chr(254)
		lString = lString & mvarOrder & Chr(254)
		'Split Tender
		lString = lString & mvarSplitCash & Chr(254)
		lString = lString & mvarSplitDebit & Chr(254)
		lString = lString & mvarSplitCredit & Chr(254)
		lString = lString & mvarSplitCheque & Chr(254)
		
		'For Gratuity
		lString = lString & mvarpaymentGratuity & Chr(254)
		'For DisChk
		lString = lString & mvarDisChk & Chr(254)
		
		For x = 1 To UBound(mvardeposit)
			'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lString & "/" & mvardeposit(x)
		Next x
		
		lString = lString & Chr(255)
		If mvarcustomer Is Nothing Then
		Else
			lString = lString & "cust" & Chr(254)
			lString = lString & mvarcustomer.channelID & Chr(254)
			lString = lString & mvarcustomer.creditLimit & Chr(254)
			lString = lString & mvarcustomer.department & Chr(254)
			lString = lString & mvarcustomer.fax & Chr(254)
			lString = lString & mvarcustomer.Key & Chr(254)
			lString = lString & mvarcustomer.name & Chr(254)
			lString = lString & mvarcustomer.outstanding & Chr(254)
			lString = lString & mvarcustomer.person & Chr(254)
			lString = lString & mvarcustomer.physical & Chr(254)
			lString = lString & mvarcustomer.postal & Chr(254)
			lString = lString & mvarcustomer.signed_Renamed & Chr(254)
			lString = lString & mvarcustomer.telephone & Chr(254)
			lString = lString & mvarcustomer.terms & Chr(254)
			lString = lString & mvarcustomer.tax & Chr(255)
		End If
		
		' TAG 1
		If mvartransactionSpecial Is Nothing Then
		Else
			lString = lString & "spec" & Chr(254)
			lString = lString & mvartransactionSpecial.address & Chr(254)
			lString = lString & mvartransactionSpecial.mobile & Chr(254)
			lString = lString & mvartransactionSpecial.name & Chr(254)
			lString = lString & mvartransactionSpecial.quote & Chr(254)
			lString = lString & mvartransactionSpecial.saleID & Chr(254)
			lString = lString & mvartransactionSpecial.telephone & Chr(254)
			lString = lString & mvartransactionSpecial.transactionType & Chr(255)
		End If
		For	Each lineitem_Renamed In mvarlineitems
			lString = lString & "item" & Chr(254) & lineitem_Renamed.build & Chr(254)
			lString = lString & lineitem_Renamed.code & Chr(254)
			lString = lString & lineitem_Renamed.depositType & Chr(254)
			lString = lString & lineitem_Renamed.id & Chr(254)
			lString = lString & lineitem_Renamed.lineNo & Chr(254)
			lString = lString & lineitem_Renamed.name & Chr(254)
			
			If mvartransactionSpecial Is Nothing Then
				lString = lString & lineitem_Renamed.originalPrice & Chr(254)
				lString = lString & lineitem_Renamed.price & Chr(254)
			Else
				If mvartransactionSpecial.transactionType = "stocktransfer" Then 'made changes for XFer Price
					lString = lString & 0 & Chr(254)
					lString = lString & 0 & Chr(254)
				Else
					lString = lString & lineitem_Renamed.originalPrice & Chr(254)
					lString = lString & lineitem_Renamed.price & Chr(254)
				End If
			End If
			
			
			lString = lString & lineitem_Renamed.quantity & Chr(254)
			lString = lString & lineitem_Renamed.receiptName & Chr(254)
			lString = lString & lineitem_Renamed.dataType & Chr(254)
			lString = lString & lineitem_Renamed.reversal & Chr(254)
			lString = lString & lineitem_Renamed.revoke & Chr(254)
			lString = lString & lineitem_Renamed.setBuild & Chr(254)
			lString = lString & lineitem_Renamed.shrink & Chr(254)
			lString = lString & lineitem_Renamed.transactionType & Chr(254)
			lString = lString & lineitem_Renamed.vat & Chr(254)
			lString = lString & lineitem_Renamed.increment & Chr(254)
			lString = lString & lineitem_Renamed.cashPrice & Chr(255)
		Next lineitem_Renamed
		If lName = "" Then lName = "current.tra"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object saveTraSvr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If saveTraSvr = True And lName <> "current.tra" Then
			If fso.FileExists(lName) Then fso.DeleteFile(lName, True)
			textstream = fso.OpenTextFile(lName, Scripting.IOMode.ForWriting, True)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object gPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If fso.FileExists(lName) Then fso.DeleteFile(gPath & lName, True)
			textstream = fso.OpenTextFile(lName, Scripting.IOMode.ForWriting, True)
		End If
		
		
		textstream.Write(lString)
		textstream.Close()
	End Sub
End Class