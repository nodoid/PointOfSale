Option Strict Off
Option Explicit On
Friend Class lineItem
	'local variable(s) to hold property value(s)
	
	Private mvarid As Integer 'local copy
	Private mvarIncrement As Integer 'local copy
	Private mvarname As String 'local copy
	Private mvarreceiptName As String 'local copy
	Private mvarcode As String 'local copy
	Private mvartransactionType As String 'local copy
	Private mvarrevoke As Boolean 'local copy
	Private mvarpriceChanged As Boolean 'local copy
	Private mvardataType As Boolean 'local copy
	Private mvarreversal As Boolean 'local copy
	Private mvarvariablePrice As Boolean 'local copy
	Private mvarFractions As Boolean 'local copy
	Private mvarsetBuild As Short 'local copy
	Private mvarbuild As Short 'local copy
	Private mvardepositType As Short 'local copy
	Private mvarshrink As Short 'local copy
	Private mvarlineNo As Short 'local copy
	Private mvaroriginalPrice As Decimal 'local copy
	Private mvarprice As Decimal 'local copy
	Private mvarvat As Decimal 'local copy
	Private mvarcashprice As Decimal 'local copy
	Private mvarquantity As Decimal 'local copy
	'changed for airtime
	Private mvarATitem As Boolean 'local copy
	Private mvarspin As String 'local copy
	Private mvarsexpiry As String 'local copy
	Private mvarsserial As String 'local copy
	
	Public Property fractions() As Boolean
		Get
			fractions = mvarFractions
		End Get
		Set(ByVal Value As Boolean)
			mvarFractions = Value
		End Set
	End Property
	
	
	Public Property variablePrice() As Boolean
		Get
			variablePrice = mvarvariablePrice
		End Get
		Set(ByVal Value As Boolean)
			mvarvariablePrice = Value
		End Set
	End Property
	
	
	Public Property build() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.build
			build = mvarbuild
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.build = 5
			mvarbuild = Value
		End Set
	End Property
	
	
	
	
	Public Property setBuild() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.set
			setBuild = mvarsetBuild
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.set = 5
			mvarsetBuild = Value
		End Set
	End Property
	
	
	
	
	
	Public Property reversal() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.reversal
			reversal = mvarreversal
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.reversal = 5
			mvarreversal = Value
		End Set
	End Property
	
	
	
	
	
	Public Property revoke() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.revoke
			revoke = mvarrevoke
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.revoke = 5
			mvarrevoke = Value
		End Set
	End Property
	
	
	
	
	
	Public Property priceChanged() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.revoke
			priceChanged = mvarpriceChanged
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.revoke = 5
			mvarpriceChanged = Value
		End Set
	End Property
	
	
	
	
	Public Property price() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.price
			price = mvarprice
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.price = 5
			mvarprice = Value
		End Set
	End Property
	
	
	Public Property cashPrice() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.cashPrice
			cashPrice = mvarcashprice
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.price = 5
			mvarcashprice = Value
		End Set
	End Property
	
	
	
	Public Property vat() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.vat
			vat = mvarvat
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.vat = 5
			mvarvat = Value
		End Set
	End Property
	
	
	
	
	
	Public Property originalPrice() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.originalPrice
			originalPrice = mvaroriginalPrice
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.originalPrice = 5
			mvaroriginalPrice = Value
		End Set
	End Property
	
	
	
	
	
	Public Property transactionType() As String
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
	
	
	
	
	
	Public Property depositType() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.depositType
			depositType = mvardepositType
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.depositType = 5
			mvardepositType = Value
		End Set
	End Property
	
	
	
	
	
	Public Property code() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.code
			code = mvarcode
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.code = 5
			mvarcode = Value
		End Set
	End Property
	
	
	
	
	
	Public Property quantity() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.quantity
			quantity = mvarquantity
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.quantity = 5
			mvarquantity = Value
		End Set
	End Property
	
	
	
	
	
	Public Property shrink() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.shrink
			shrink = mvarshrink
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.shrink = 5
			mvarshrink = Value
		End Set
	End Property
	
	
	
	
	
	Public Property id() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.id
			id = mvarid
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.id = 5
			mvarid = Value
		End Set
	End Property
	
	
	
	Public Property increment() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.id
			increment = mvarIncrement
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.id = 5
			mvarIncrement = Value
		End Set
	End Property
	
	
	
	
	
	Public Property receiptName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.receiptName
			receiptName = mvarreceiptName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.receiptName = 5
			mvarreceiptName = Value
		End Set
	End Property
	
	
	
	
	
	Public Property name() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.name
			name = mvarname
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.name = 5
			mvarname = Value
		End Set
	End Property
	
	
	Public Property lineNo() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.lineNo
			lineNo = mvarlineNo
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.lineNo = 5
			mvarlineNo = Value
		End Set
	End Property
	
	
	Public Property dataType() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.name
			dataType = mvardataType
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.name = 5
			mvardataType = Value
		End Set
	End Property
	
	'changed for airtime
	
	Public Property atitem() As Boolean
		Get
			atitem = mvarATitem
		End Get
		Set(ByVal Value As Boolean)
			mvarATitem = Value
		End Set
	End Property
	
	
	Public Property sPin() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.name
			sPin = mvarspin
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.name = 5
			mvarspin = Value
		End Set
	End Property
	
	
	Public Property sExpiry() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.name
			sExpiry = mvarsexpiry
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.name = 5
			mvarsexpiry = Value
		End Set
	End Property
	
	
	Public Property sSerial() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.name
			sSerial = mvarsserial
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.name = 5
			mvarsserial = Value
		End Set
	End Property
	
	Public Function clone() As lineitem
		Dim lLineitem As New lineitem
		lLineitem.build = mvarbuild
		lLineitem.code = mvarcode
		lLineitem.depositType = mvardepositType
		lLineitem.id = mvarid
		lLineitem.lineNo = mvarlineNo
		lLineitem.name = mvarname
		lLineitem.originalPrice = mvaroriginalPrice
		lLineitem.price = mvarprice
		lLineitem.quantity = mvarquantity
		lLineitem.receiptName = mvarreceiptName
		lLineitem.reversal = mvarreversal
		lLineitem.revoke = mvarrevoke
		lLineitem.setBuild = mvarsetBuild
		lLineitem.shrink = mvarshrink
		lLineitem.transactionType = mvartransactionType
		lLineitem.vat = mvarvat
		lLineitem.sPin = mvarspin
		clone = lLineitem
	End Function
End Class