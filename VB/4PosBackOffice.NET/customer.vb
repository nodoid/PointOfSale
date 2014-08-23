Option Strict Off
Option Explicit On
Friend Class customer
	Public Key As String
	
	'local variable(s) to hold property value(s)
	Private mvarname As String 'local copy
	Private mvardepartment As String 'local copy
	Private mvarperson As String 'local copy
	Private mvarphysical As String 'local copy
	Private mvarpostal As String 'local copy
	Private mvartelephone As String 'local copy
	Private mvarfax As String 'local copy
	Private mvartax As String 'local copy
	Private mvarsigned As String 'local copy
	Private mvarcreditLimit As Decimal 'local copy
	Private mvaroutstanding As Decimal 'local copy
	Private mvarchannelID As Integer 'local copy
	Private mvarterms As Short 'local copy
	
	
	Public Property terms() As Short
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.terms
			terms = mvarterms
		End Get
		Set(ByVal Value As Short)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.terms = 5
			mvarterms = Value
		End Set
	End Property
	
	
	
	
	Public Property channelID() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.channelID
			channelID = mvarchannelID
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.channelID = 5
			mvarchannelID = Value
		End Set
	End Property
	
	
	
	
	
	Public Property outstanding() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.outstanding
			outstanding = mvaroutstanding
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.outstanding = 5
			mvaroutstanding = Value
		End Set
	End Property
	
	
	
	
	
	Public Property creditLimit() As Decimal
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.creditLimit
			creditLimit = mvarcreditLimit
		End Get
		Set(ByVal Value As Decimal)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.creditLimit = 5
			mvarcreditLimit = Value
		End Set
	End Property
	
	
	
	
	
	'UPGRADE_NOTE: signed was upgraded to signed_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Property signed_Renamed() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.signed
			signed_Renamed = mvarsigned
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.signed = 5
			mvarsigned = Value
		End Set
	End Property
	
	
	
	
	
	Public Property fax() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.fax
			fax = mvarfax
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.fax = 5
			mvarfax = Value
		End Set
	End Property
	
	
	
	Public Property tax() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.fax
			tax = mvartax
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.fax = 5
			mvartax = Value
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
	
	
	
	
	
	Public Property postal() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.postal
			postal = mvarpostal
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.postal = 5
			mvarpostal = Value
		End Set
	End Property
	
	
	
	
	
	Public Property physical() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.physical
			physical = mvarphysical
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.physical = 5
			mvarphysical = Value
		End Set
	End Property
	
	
	
	
	
	Public Property person() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.person
			person = mvarperson
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.person = 5
			mvarperson = Value
		End Set
	End Property
	
	
	
	
	
	Public Property department() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.department
			department = mvardepartment
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.department = 5
			mvardepartment = Value
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
End Class