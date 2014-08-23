Option Strict Off
Option Explicit On
Friend Class lineItems
	Implements System.Collections.IEnumerable
	'local variable to hold collection
	Private mCol As Collection
	Private mvarlineItem As lineItem
	
	
	
	
	Public Property lineitem() As lineItem
		Get
			lineitem = mvarlineItem
		End Get
		Set(ByVal Value As lineItem)
			mvarlineItem = Value
		End Set
	End Property
	Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As lineItem
		Get
			On Error GoTo erItem
			'used when referencing an element in the collection
			'vntIndexKey contains either the Index or Key to the collection,
			'this is why it is declared as a Variant
			'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
			Item = mCol.Item(vntIndexKey)
			
			Exit Property
erItem: 
			Resume Next
		End Get
	End Property
	Public ReadOnly Property Count() As Integer
		Get
			'used when retrieving the number of elements in the
			'collection. Syntax: Debug.Print x.Count
			Count = mCol.Count()
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
	Public Sub reorder()
		Dim x As Object
		Dim lCol As New Collection
		For x = 1 To mCol.Count()
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mCol.Item(x).lineNo = x
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCol.Add(mCol.Item(x), "k" & mCol.Item(x).lineNo)
		Next x
		
		mCol = lCol
	End Sub
	
	Public Sub Add(ByRef lineitem As lineItem)
		Dim intLineNo As Object
		Dim lCol As New Collection
		Dim lLineitem As lineItem
		Dim x As Short
		If mCol.Count() Then
			lLineitem = mCol.Item(mCol.Count())
			If lLineitem.quantity = 0 Then mCol.Remove(lLineitem.lineNo)
		End If
		If mCol.Count() Then
			lLineitem = mCol.Item(mCol.Count())
			'If lLineitem.sPin <> "" Then
			If lLineitem.atitem = True Then
			Else
				If lLineitem.id = lineitem.id Then
					If lLineitem.transactionType = lineitem.transactionType Then
						If System.Math.Abs(lLineitem.price) = System.Math.Abs(lineitem.price) Then
							If lLineitem.reversal = lineitem.reversal Then
								If lLineitem.revoke = lineitem.revoke Then
									If lLineitem.shrink = lineitem.shrink Then
										If InStr(CStr(lLineitem.quantity), ".") Then
										Else
											lLineitem.quantity = lLineitem.quantity + lineitem.quantity
											Exit Sub
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End If
		
		For x = 1 To mCol.Count()
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mCol.Item(x).lineNo = x
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCol.Add(mCol.Item(x), "k" & mCol.Item(x).lineNo)
		Next x
		
		lineitem.lineNo = lCol.Count() + 1
		'UPGRADE_WARNING: Couldn't resolve default property of object intLineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		intLineNo = lineitem.lineNo
		
		
		lCol.Add(lineitem, "k" & lineitem.lineNo)
		mCol = lCol
		
	End Sub
	Public Sub Remove(ByRef vntIndexKey As Object)
		Dim x As Object
		'used when removing an element from the collection
		'vntIndexKey contains either the Index or Key, which is why
		'it is declared as a Variant
		'Syntax: x.Remove(xyz)
		Dim lCol As New Collection
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vntIndexKey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mCol.Remove("k" & vntIndexKey)
		For x = 1 To mCol.Count()
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol().lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mCol.Item(x).lineNo = x
			'UPGRADE_WARNING: Couldn't resolve default property of object mCol(x).lineNo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCol.Add(mCol.Item(x), "k" & mCol.Item(x).lineNo)
		Next x
		mCol = lCol
		
	End Sub
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'creates the collection when this class is created
		mCol = New Collection
		'create the mlineItem object when the items class is created
		mvarlineItem = New lineItem
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		'UPGRADE_NOTE: Object mvarlineItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mvarlineItem = Nothing
		'destroys collection when this class is terminated
		'UPGRADE_NOTE: Object mCol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mCol = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class