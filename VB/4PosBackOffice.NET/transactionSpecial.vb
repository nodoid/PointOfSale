Option Strict Off
Option Explicit On
Friend Class transactionSpecial
	'local variable(s) to hold property value(s)
	Private mvarquote As Boolean 'local copy
	Private mvarname As String 'local copy
	Private mvartelephone As String 'local copy
	Private mvarmobile As String 'local copy
	Private mvaraddress As String 'local copy
	Private mvarsaleID As Integer 'local copy
	Private mvartransactionType As String 'local copy
	
	
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
	
	
	
	Public Property saleID() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.saleID
			saleID = mvarsaleID
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.saleID = 5
			mvarsaleID = Value
		End Set
	End Property
	
	
	
	
	
	Public Property address() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.address
			address = mvaraddress
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.address = 5
			mvaraddress = Value
		End Set
	End Property
	
	
	
	
	
	Public Property mobile() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.mobile
			mobile = mvarmobile
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.mobile = 5
			mvarmobile = Value
		End Set
	End Property
	
	
	
	
	
	Public Property telephone() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.telephone
			telephone = mvartelephone
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.telephone = 5
			mvartelephone = Value
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
	
	
	
	
	Public Property quote() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.quote
			quote = mvarquote
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.quote = 5
			mvarquote = Value
		End Set
	End Property
End Class