Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class DatabaseExport
	Public Event ExportStarted(ByVal ExportingFormat As DatabaseExportEnum)
    Public Event ExportError(ByRef myError As ErrObject, ByVal ExportingFormat As DatabaseExportEnum)
	Public Event ExportComplete(ByVal Success As Boolean, ByVal ExportingFormat As DatabaseExportEnum)
	
	Private ExportFilePath As String
	Private ADODBRecordset As ADODB.Recordset
	
	Public Enum DatabaseExportEnum
		CSV = 0
		HTML = 1
		Excel = 2
	End Enum
	
	Private Declare Function GetQueueStatus Lib "user32" (ByVal qsFlags As Integer) As Integer
	
	
	Public Property FilePath() As String
		Get
			FilePath = ExportFilePath
		End Get
		Set(ByVal Value As String)
			ExportFilePath = Value
		End Set
	End Property
	
	Private Function DoEventsEx() As Integer
		On Error Resume Next
		DoEventsEx = GetQueueStatus(&H80 Or &H1 Or &H4 Or &H20 Or &H10)
		If DoEventsEx <> 0 Then
			System.Windows.Forms.Application.DoEvents()
		End If
		
	End Function
	Public Sub ExportToCSV(Optional ByVal PrintHeader As Boolean = True)
		Dim rs As ADODB.Recordset
		Dim i As Integer
		Dim TotalRecords As Integer
		Dim ErrorOccured As Boolean
		Dim NumberOfFields As Short
		Const Quote As String = """" 'Faster then Chr$(34)
		Dim sql As String
		Dim FSO As New Scripting.FileSystemObject
		
		
		On Error GoTo ExportTracker
		
		RaiseEvent ExportStarted(DatabaseExportEnum.CSV)
		
		rs = getRSreport("SELECT * FROM aPastelDescription1")
		
		If rs.RecordCount > 0 Then
			
			FileOpen(1, ExportFilePath, OpenMode.Output, OpenAccess.Write)
			
			With getRSreport("SELECT * FROM aPastelDescription1")
				.MoveFirst()
				NumberOfFields = .Fields.Count - 1
				
				If PrintHeader Then
					For i = 0 To NumberOfFields - 1 'Now add the field names
						Print(1, .Fields(i).Name & ",") 'similar to the ones below
					Next i
					PrintLine(1, .Fields(NumberOfFields).Name)
				End If
				
				Do While Not .EOF
					TotalRecords = TotalRecords + 1
					For i = 0 To NumberOfFields 'If there is an emty field,
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If (IsDbNull(.Fields(i).Value)) Then 'add a , to indicate it is
							Print(1, ",") 'empty
						Else
							If i = NumberOfFields Then
								Print(1, Quote & Trim(CStr(.Fields(i).Value)) & Quote)
							Else
								Print(1, Quote & Trim(CStr(.Fields(i).Value)) & Quote & ",")
							End If
						End If 'Putting data under "" will not
					Next i 'confuse the reader of the file
					DoEventsEx() 'between Dhaka, Bangladesh as two
					PrintLine(1) 'fields or as one field.
					.moveNext()
					
				Loop 
			End With
			FileClose(1)
			RaiseEvent ExportComplete(Not ErrorOccured, DatabaseExportEnum.CSV)
			
			
		Else
			MsgBox("There are no database record to export to file", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			
			
		End If
		
		
		Exit Sub
		
ExportTracker: 
		RaiseEvent ExportError(Err, DatabaseExportEnum.CSV)
		If Err.Number = 0 Then
			Resume Next
			ErrorOccured = True
		End If
		
	End Sub
	'UPGRADE_NOTE: Argument type has been changed to Object. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="D0BD8832-D1AC-487C-8AA5-B36F9284E51E"'
	Public Function ShowSave(ByVal cmdlg As Object, ByVal ExportMode As DatabaseExportEnum, Optional ByRef DialogTitle As String = "Export Recordset to...") As Boolean
		Dim t_Day As String
		Dim t_Month As String
		Dim st_Name As String
		Dim Extention As String
		
		t_Day = Trim(CStr(VB.Day(Today)))
		t_Month = Trim(CStr(Month(Today)))
		
		If Len(t_Day) = 1 Then t_Day = "0" & Trim(CStr(VB.Day(Today)))
		If Len(t_Month) = 1 Then t_Month = "0" & Trim(CStr(Month(Today)))
		
		st_Name = "PasteExport" & Trim(CStr(Year(Today))) & Trim(t_Month) & Trim(t_Day)
		
		If ExportMode = DatabaseExportEnum.CSV Then
			Extention = "Comma Separated Values (*.csv)|*.csv|Text Files (*.txt)|*.txt|"
		End If
		
		On Error GoTo Extracter
		
		With cmdlg
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.CancelError. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CancelError = True
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.DialogTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.DialogTitle = DialogTitle
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FileName = st_Name
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.filter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.filter = Extention
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FilterIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FilterIndex = 0
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.ShowSave. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ShowSave()
			'UPGRADE_WARNING: Couldn't resolve default property of object cmdlg.FileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ExportFilePath = .FileName
		End With
		
		If ExportFilePath <> "" Then
			ShowSave = True
		End If
		
Extracter: 
		
	End Function
End Class