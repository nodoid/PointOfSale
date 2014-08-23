Option Strict Off
Option Explicit On
Friend Class customers
	Implements System.Collections.IEnumerable
	'local variable to hold collection
	Private mCol As New Collection
	Dim gRS As New ADODB.Recordset
	Public Function getCustomer(ByRef id As Integer) As customer
        Dim sql As String
		Dim cn As ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim customer_Renamed As customer
		If id Then
			
			cn = openConnectionInstance()
			If cn Is Nothing Then
				MsgBox("You are not connected to the 4POS BackOffice server! This task can only be performed if you are connected to the server. Please contact your System Administrator.", MsgBoxStyle.Exclamation, "BackOffice Connection Error")
			Else
				rs = New ADODB.Recordset
				sql = "SELECT Customer.*, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS balance From Customer WHERE CustomerID=" & id
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
				If rs.RecordCount Then
					customer_Renamed = New customer
					customer_Renamed.Key = rs.Fields("CustomerID").Value
					customer_Renamed.channelID = rs.Fields("Customer_ChannelID").Value
					customer_Renamed.creditLimit = rs.Fields("Customer_CreditLimit").Value
					customer_Renamed.department = rs.Fields("Customer_DepartmentName").Value & ""
					customer_Renamed.fax = rs.Fields("Customer_Fax").Value & ""
					customer_Renamed.name = rs.Fields("Customer_InvoiceName").Value & ""
					customer_Renamed.outstanding = rs.Fields("balance").Value
					customer_Renamed.person = rs.Fields("Customer_FirstName").Value & " " & rs.Fields("Customer_Surname").Value
					customer_Renamed.physical = rs.Fields("Customer_PhysicalAddress").Value & ""
					customer_Renamed.postal = rs.Fields("Customer_PostalAddress").Value & ""
					customer_Renamed.signed_Renamed = customer_Renamed.person
					customer_Renamed.telephone = rs.Fields("Customer_Telephone").Value & ""
					customer_Renamed.terms = rs.Fields("Customer_Terms").Value
					customer_Renamed.tax = rs.Fields("Customer_VATNumber").Value & ""
				End If
			End If
		End If
		getCustomer = customer_Renamed
	End Function
	Public Function search(ByRef searchString As String) As Collection
		Dim lString As String
		Dim customer_Renamed As customer
		Dim lExit As Short
		On Error Resume Next
		mCol = New Collection
		lString = Trim(searchString)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		If lString <> "" Then
			lString = Replace(lString, "'", "''")
			lString = "(Customer_InvoiceName LIKE '%" & Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") & "%')"
		Else
			lString = ""
		End If
		gRS.filter = lString
		
		If gRS.RecordCount <= 0 Then
			lString = Trim(searchString)
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			If lString <> "" Then
				lString = Replace(lString, "'", "''")
				lString = "(Customer_Surname LIKE '%" & Replace(lString, " ", "%' AND Customer_Surname LIKE '%") & "%')"
			Else
				lString = ""
			End If
			gRS.filter = lString
		End If
		
		Do Until gRS.EOF
			customer_Renamed = New customer
			customer_Renamed.Key = gRS.Fields("CustomerID").Value
			customer_Renamed.channelID = gRS.Fields("Customer_ChannelID").Value
			customer_Renamed.creditLimit = gRS.Fields("Customer_CreditLimit").Value
			customer_Renamed.department = gRS.Fields("Customer_DepartmentName").Value & ""
			customer_Renamed.fax = gRS.Fields("Customer_Fax").Value & ""
			customer_Renamed.name = gRS.Fields("Customer_InvoiceName").Value
			customer_Renamed.outstanding = gRS.Fields("balance").Value
			customer_Renamed.person = gRS.Fields("Customer_FirstName").Value & " " & gRS.Fields("Customer_Surname").Value
			customer_Renamed.physical = gRS.Fields("Customer_PhysicalAddress").Value & ""
			customer_Renamed.postal = gRS.Fields("Customer_PostalAddress").Value & ""
			customer_Renamed.signed_Renamed = customer_Renamed.person
			customer_Renamed.telephone = gRS.Fields("Customer_Telephone").Value & ""
			customer_Renamed.terms = gRS.Fields("Customer_Terms").Value
			customer_Renamed.tax = gRS.Fields("Customer_VATNumber").Value & ""
			mCol.Add(customer_Renamed, "k" & customer_Renamed.Key)
			lExit = lExit + 1
			If lExit = 50 Then Exit Do
			gRS.moveNext()
			
		Loop 
		search = mCol
	End Function
	
    Default Public ReadOnly Property Item(ByVal vntIndexKey As Integer) As customer
        Get
            'used when referencing an element in the collection
            'vntIndexKey contains either the Index or Key to the collection,
            'this is why it is declared as a Variant
            'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
            On Error Resume Next
            'UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Item = mCol.Item("k" & vntIndexKey)
        End Get
    End Property
	
	
	
	Public ReadOnly Property Count() As Integer
		Get
			On Error Resume Next
			'used when retrieving the number of elements in the
			'collection. Syntax: Debug.Print x.Count
			Count = gRS.RecordCount
		End Get
	End Property
	
	
	'UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3FC1610-34F3-43F5-86B7-16C984F0E88E"'
	'Public ReadOnly Property NewEnum() As stdole.IUnknown
		'Get
			'this property allows you to enumerate
			'this collection with the For...Each syntax
			'NewEnum = mCol._NewEnum
		'End Get
	'End Property
	
	Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		'UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="95F9AAD0-1319-4921-95F0-B9D3C4FF7F1C"'
		'GetEnumerator = mCol.GetEnumerator
	End Function
	
	
    Public Sub Remove(ByRef vntIndexKey As Integer)
        'used when removing an element from the collection
        'vntIndexKey contains either the Index or Key, which is why
        'it is declared as a Variant
        'Syntax: x.Remove(xyz)


        mCol.Remove(vntIndexKey)
    End Sub
	
	Public Sub load()
        Dim sql As String
		Dim cn As ADODB.Connection
		If gRS.State Then gRS.Close()
		gRS.filter = ""
		cn = openConnectionInstance()
		If cn Is Nothing Then
			MsgBox("You are not connected to the 4POS BackOffice server! This task can only be performed if you are connected to the server. Please contact your System Administrator.", MsgBoxStyle.Exclamation, "BackOffice Connection Error")
		Else
			sql = "SELECT Customer.*, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS balance From Customer WHERE Customer_Disabled <> True ORDER BY Customer.Customer_InvoiceName;"
			
			gRS.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		End If
	End Sub
	
	
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		'destroys collection when this class is terminated
		'UPGRADE_NOTE: Object mCol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mCol = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class