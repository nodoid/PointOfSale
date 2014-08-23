Option Strict Off
Option Explicit On
Friend Class frmDesign
	Inherits System.Windows.Forms.Form
    Dim WithEvents option1 As List(Of RadioButton)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1906 'Barcode Design|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1907 'Please Select the Stock Barcode to Modify|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1821 'Stock Barcode|Checked
		If rsLang.RecordCount Then Option1(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1830 'Shelf Taker|Checked
		If rsLang.RecordCount Then Option1(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdnext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdnext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmDesign.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Dim rs As ADODB.Recordset
		Dim rsBClabel As ADODB.Recordset
		Dim rst As ADODB.Recordset
		Dim TheLastIDIncr As Short
		Dim BCLabelIDIncr As Short
		Dim rsNewName As ADODB.Recordset
		Dim rsForName As ADODB.Recordset
		Dim InpType As String
		Dim x As Short
		rs = New ADODB.Recordset
		rsBClabel = New ADODB.Recordset
		rst = New ADODB.Recordset
		rsNewName = New ADODB.Recordset
		rsForName = New ADODB.Recordset
		
		'Set rs = getRS("SELECT Max(BClabel_LabelID) as TheMaxLabelID FROM BClabel")
		'***** If BClabel and BClabelItem tables are empty then insert all data from LabelItem
		'If IsNull(rs("TheMaxLabelID")) Then
		'   IntDesign1 = 2
		'   DataList1_DblClick
		'  Exit Sub
		'End If
		
		rs = getRS("SELECT Max(LabelID) as TheMaxLabelID FROM Label;")
		If IsDbNull(rs.Fields("TheMaxLabelID").Value) Then
			IntDesign1 = 2
			DataList1_DblClick(DataList1, New System.EventArgs())
			Exit Sub
		End If
		TheLastIDIncr = rs.Fields("TheMaxLabelID").Value + 1 'LabelID
		
		rst = getRS("SELECT Max(BClabelID) as TheMaxBClabelID FROM BClabel")
		If IsDbNull(rst.Fields("TheMaxBClabelID").Value) Then
			BCLabelIDIncr = 1
		Else
			BCLabelIDIncr = rst.Fields("TheMaxBClabelID").Value + 1 'BCLabelID
		End If
		
		If Option1(1).Checked = True Then
			InpType = CStr(1)
		ElseIf Option1(2).Checked = True Then 
			InpType = CStr(2)
		Else
			InpType = InputBox("Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.")
			If Not IsNumeric(InpType) Then
				'MsgBox "Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.", vbInformation, App.title
				Exit Sub
			ElseIf CDbl(InpType) = 1 Then 
				TheType = 1
			ElseIf CDbl(InpType) = 2 Then 
				TheType = 2
			Else
				MsgBox("Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.", MsgBoxStyle.Information, My.Application.Info.Title)
				Exit Sub
			End If
		End If
		
		'****
		'New Label Name
		'****
		x = x + 1
		NewLabelName = "New Label" & x
		
		rsNewName = getRS("SELECT * FROM Label WHERE Label_Name='" & NewLabelName & "'")
		rsForName = getRS("SELECT * FROM Label")
		
		If rsNewName.RecordCount > 0 Then
			'*******
			'Do until New Name not found
			'*******
			Do Until rsForName.EOF
				'****
				'If New Label Name not found then add 1 to last Label No
				'****
				If rsNewName.RecordCount > 0 Then
					x = x + 1
					NewLabelName = "New Label" & x
					rsNewName = getRS("SELECT * FROM Label WHERE Label_Name='" & NewLabelName & "'")
					
				ElseIf rsNewName.RecordCount < 1 Then 
					NewLabelName = NewLabelName
					Exit Do
				End If
				
				rsForName.moveNext()
			Loop 
			
		Else
			
		End If
		x = 0
		
		'*****
		'Inserting New Label
		'*****
		rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & BCLabelIDIncr & " ,'Stock','Stock','" & 0 & "',15," & TheLastIDIncr & ")")
		
		rsBClabel = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & BCLabelIDIncr & "," & 22 & ",'blank'," & 1 & "," & 0 & ",'" & 0 & "',' ','" & 0 & "'," & TheLastIDIncr & ")")
		
		rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" & TheLastIDIncr & "")
		
		rsBClabel = getRS("INSERT INTO Label(LabelID,Label_Type,Label_Name,Label_Height,Label_Width,Label_Top,Label_Rotate,Label_Disabled,Label_Left)VALUES(" & TheLastIDIncr & "," & TheType & ",'" & NewLabelName & "'," & 30 & "," & 40 & "," & 0 & ",'" & 0 & "','" & 0 & "'," & 0 & ")")
		
		rsBClabel = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & TheLastIDIncr & "," & 22 & ",'blank'," & 1 & "," & 0 & ",'" & 0 & "',' ')")
		
		RecSel = rs.Fields("BClabelID").Value
		'SelectLabelName = NewLabelName
		
		MyLIDWHole = TheLastIDIncr
		
		frmBarcodeLoad.ShowDialog()
		
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		DataList1_DblClick(DataList1, New System.EventArgs())
	End Sub
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.DoubleClick

        Dim rs As ADODB.Recordset
        Dim rst As ADODB.Recordset
        Dim rsInner As ADODB.Recordset
        Dim rsShelf As ADODB.Recordset
        Dim rsBClabel As ADODB.Recordset
        Dim HoldBClabelItem_BCLabelID As Short
        Dim TheSample As String
        Dim IntLabelID As Short
        Dim IncrBClabelID As Short

        rs = New ADODB.Recordset
        rst = New ADODB.Recordset
        rsInner = New ADODB.Recordset
        rsShelf = New ADODB.Recordset
        rsBClabel = New ADODB.Recordset
        Dim TheeMaxID As Short

        cnnDB.Execute("DELETE * FROM BClabel;")
        cnnDB.Execute("DELETE * FROM BClabelItem;")

        IntDesign = 1 'New code
        HoldBClabelItem_BCLabelID = 1
        rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID")

        If rs.RecordCount > 0 Then

            If Trim(DataList1.CurrentCell.Value.ToString) = "" Then
                If TheType = 2 Then
                    MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                    Exit Sub
                Else
                    MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                    Exit Sub
                End If
            Else
            End If

            MyLIDWHole = CShort(DataList1.CurrentCell.Value)

            rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" & MyLIDWHole & "")
            If rs.RecordCount = 0 Then

                IncrBClabelID = 1
                rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;")

                rsBClabel = getRS("INSERT INTO BClabel(BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES('Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")
                'Set rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(1,'Stock','Stock','" & 0 & "',15," & rsInner("LabelID") & ")")

                Do Until rsInner.EOF
                    '****
                    'Inserting information into BCLabel
                    '***

                    If Trim(rsInner.Fields("labelItem_Sample").Value) = "" Then
                        TheSample = " "
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    ElseIf IsDBNull(rsInner.Fields("labelItem_Sample").Value) Then
                        TheSample = " "
                    Else
                        TheSample = rsInner.Fields("labelItem_Sample").Value
                    End If

                    rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & HoldBClabelItem_BCLabelID & "," & rsInner.Fields("labelItem_Line").Value & ",'" & rsInner.Fields("labelItem_Field").Value & "'," & rsInner.Fields("labelItem_Align").Value & "," & rsInner.Fields("labelItem_Size").Value & "," & rsInner.Fields("labelItem_Bold").Value & ",'" & TheSample & "','" & 0 & "'," & rsInner.Fields("labelItem_LabelID").Value & ")")
                    IntLabelID = rsInner.Fields("labelItem_LabelID").Value
                    rsInner.MoveNext()
                    '****
                    'If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
                    '****
                    On Error Resume Next
                    If IntLabelID <> rsInner.Fields("labelItem_LabelID").Value Then
                        HoldBClabelItem_BCLabelID = HoldBClabelItem_BCLabelID + 1

                        IncrBClabelID = IncrBClabelID + 1

                        If rsInner.Fields("Label_Top").Value = 3 Then
                            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")
                        Else
                            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',30," & rsInner.Fields("LabelID").Value & ")")
                        End If

                    Else

                    End If
                Loop
                rst = getRS("SELECT Max(BClabelID) As MaxLaID FROM BClabel")
                'Dim TheeMaxID As Integer

                TheeMaxID = rst.Fields("MaxLaID").Value

                rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=1;")

                '****
                'Inserting For shelf talker
                '****
                TheeMaxID = TheeMaxID + 1
                rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")

                Do Until rsInner.EOF
                    '****
                    'Inserting information into BCLabel
                    '***

                    If Trim(rsInner.Fields("labelItem_Sample").Value) = "" Then
                        TheSample = " "
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    ElseIf IsDBNull(rsInner.Fields("labelItem_Sample").Value) Then
                        TheSample = " "
                    Else
                        TheSample = rsInner.Fields("labelItem_Sample").Value
                    End If

                    rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & TheeMaxID & "," & rsInner.Fields("labelItem_Line").Value & ",'" & rsInner.Fields("labelItem_Field").Value & "'," & rsInner.Fields("labelItem_Align").Value & "," & rsInner.Fields("labelItem_Size").Value & "," & rsInner.Fields("labelItem_Bold").Value & ",'" & TheSample & "','" & 0 & "'," & rsInner.Fields("labelItem_LabelID").Value & ")")
                    IntLabelID = rsInner.Fields("labelItem_LabelID").Value
                    rsInner.MoveNext()
                    '****
                    'If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
                    '****

                    If IntLabelID <> rsInner.Fields("labelItem_LabelID").Value Then
                        TheeMaxID = TheeMaxID + 1

                        'IncrBClabelID = IncrBClabelID + 1

                        If rsInner.Fields("Label_Top").Value = 3 Then
                            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & TheeMaxID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")
                        Else
                            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & TheeMaxID & ",'Stock','Stock','" & 0 & "',30," & rsInner.Fields("LabelID").Value & ")")
                        End If

                    Else

                    End If
                Loop

                '***
                'For new database
                '***
                If IntDesign1 <> 2 Then
                    If Trim(DataList1.CurrentCell.Value.ToString) = "" Then
                        If TheType = 2 Then
                            MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                            Exit Sub
                        Else
                            MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                            Exit Sub
                        End If
                    Else
                    End If
                Else
                    IntDesign = 0
                End If

                If IntDesign1 = 2 Then
                    IntDesign1 = 0
                    cmdNew_Click(cmdnew, New System.EventArgs())
                    Exit Sub

                End If

                MyLIDWHole = CShort(DataList1.CurrentCell.Value)

                rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" & MyLIDWHole & "")
                RecSel = rs.Fields("BClabelID").Value
                'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                SelectLabelName = DataList1.CurrentCell.Value.ToString
                frmBarcodeLoad.ShowDialog()

            Else
                RecSel = rs.Fields("BClabelID").Value
                'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                SelectLabelName = DataList1.CurrentCell.Value.ToString
                frmBarcodeLoad.ShowDialog()
            End If
        ElseIf rs.RecordCount < 1 Then
            'Set rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;")
            IncrBClabelID = 1
            rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;")

            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(1,'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")

            Do Until rsInner.EOF
                '****
                'Inserting information into BCLabel
                '***

                If Trim(rsInner.Fields("labelItem_Sample").Value) = "" Then
                    TheSample = " "
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                ElseIf IsDBNull(rsInner.Fields("labelItem_Sample").Value) Then
                    TheSample = " "
                Else
                    TheSample = rsInner.Fields("labelItem_Sample").Value
                End If

                rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & HoldBClabelItem_BCLabelID & "," & rsInner.Fields("labelItem_Line").Value & ",'" & rsInner.Fields("labelItem_Field").Value & "'," & rsInner.Fields("labelItem_Align").Value & "," & rsInner.Fields("labelItem_Size").Value & "," & rsInner.Fields("labelItem_Bold").Value & ",'" & TheSample & "','" & 0 & "'," & rsInner.Fields("labelItem_LabelID").Value & ")")
                IntLabelID = rsInner.Fields("labelItem_LabelID").Value
                rsInner.MoveNext()
                '****
                'If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
                '****
                On Error Resume Next
                If IntLabelID <> rsInner.Fields("labelItem_LabelID").Value Then
                    HoldBClabelItem_BCLabelID = HoldBClabelItem_BCLabelID + 1

                    IncrBClabelID = IncrBClabelID + 1

                    If rsInner.Fields("Label_Top").Value = 3 Then
                        rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")
                    Else
                        rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',30," & rsInner.Fields("LabelID").Value & ")")
                    End If

                Else

                End If
            Loop
            rst = getRS("SELECT Max(BClabelID) As MaxLaID FROM BClabel")
            'Dim TheeMaxID As Integer

            TheeMaxID = rst.Fields("MaxLaID").Value

            rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=1;")

            '****
            'Inserting For shelf talker
            '****
            TheeMaxID = TheeMaxID + 1
            rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & IncrBClabelID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")

            Do Until rsInner.EOF
                '****
                'Inserting information into BCLabel
                '***

                If Trim(rsInner.Fields("labelItem_Sample").Value) = "" Then
                    TheSample = " "
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                ElseIf IsDBNull(rsInner.Fields("labelItem_Sample").Value) Then
                    TheSample = " "
                Else
                    TheSample = rsInner.Fields("labelItem_Sample").Value
                End If

                rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & TheeMaxID & "," & rsInner.Fields("labelItem_Line").Value & ",'" & rsInner.Fields("labelItem_Field").Value & "'," & rsInner.Fields("labelItem_Align").Value & "," & rsInner.Fields("labelItem_Size").Value & "," & rsInner.Fields("labelItem_Bold").Value & ",'" & TheSample & "','" & 0 & "'," & rsInner.Fields("labelItem_LabelID").Value & ")")
                IntLabelID = rsInner.Fields("labelItem_LabelID").Value
                rsInner.MoveNext()
                '****
                'If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
                '****

                If IntLabelID <> rsInner.Fields("labelItem_LabelID").Value Then
                    TheeMaxID = TheeMaxID + 1

                    'IncrBClabelID = IncrBClabelID + 1

                    If rsInner.Fields("Label_Top").Value = 3 Then
                        rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & TheeMaxID & ",'Stock','Stock','" & 0 & "',15," & rsInner.Fields("LabelID").Value & ")")
                    Else
                        rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & TheeMaxID & ",'Stock','Stock','" & 0 & "',30," & rsInner.Fields("LabelID").Value & ")")
                    End If

                Else

                End If
            Loop

            '***
            'For new database
            '***
            If IntDesign1 <> 2 Then
                If Trim(DataList1.CurrentCell.Value.ToString) = "" Then
                    If TheType = 2 Then
                        MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                        Exit Sub
                    Else
                        MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office")
                        Exit Sub
                    End If
                Else
                End If
            Else
                IntDesign = 0
            End If

            If IntDesign1 = 2 Then
                IntDesign1 = 0
                cmdNew_Click(cmdnew, New System.EventArgs())
                Exit Sub

            End If

            MyLIDWHole = CShort(DataList1.CurrentCell.Value)

            rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" & MyLIDWHole & "")
            RecSel = rs.Fields("BClabelID").Value
            'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            SelectLabelName = DataList1.CurrentCell.Value.ToString
            frmBarcodeLoad.ShowDialog()



        End If '*** if statement for checking BClabel and BClabelItem =0 end here

    End Sub
	
	Private Sub frmDesign_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 27 Then
			cmdExit_Click(cmdExit, New System.EventArgs())
		ElseIf KeyAscii = 13 Then 
			cmdNext_Click(cmdNext, New System.EventArgs())
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmDesign_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        option1.AddRange(New RadioButton() {_Option1_1, _Option1_2})
		On Error Resume Next
		Dim rs As ADODB.Recordset
		Dim rst As ADODB.Recordset
		
		rs = New ADODB.Recordset
		
		rst = New ADODB.Recordset
		
		rs = getRS("SELECT * FROM Label WHERE Label.Label_Type=" & 2 & " ORDER BY LabelID")
        DataList1.DataBindings.Add(rs)
        DataList1.DataSource = rs
        DataList1.listField = "Label_Name"
		
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
        DataList1.DataSource = rs
        DataList1.boundColumn = "LabelID"
		TheType = 2
		
		loadLanguage()
		Me.ShowDialog()
		
	End Sub
	Public Function MyLoad() As Object
        Dim rs As ADODB.Recordset
		Dim rst As New ADODB.Recordset
		
		rs = getRS("SELECT * FROM Label WHERE Label.Label_Type=" & 2 & "")
		
        DataList1.DataSource = rs
        DataList1.listField = "Label_Name"
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = rs
        DataList1.boundColumn = "LabelID"
		
		loadLanguage()
		Me.ShowDialog()
	End Function
	Public Function TheSelect() As Object
		Dim rs As ADODB.Recordset
		Dim rst As ADODB.Recordset
		
		rs = New ADODB.Recordset
		rst = New ADODB.Recordset
		
        MyLIDWHole = CShort(DataList1.CurrentCell.Value)
		
		rs = getRS("SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" & MyLIDWHole & "")
		RecSel = rs.Fields("BClabelID").Value
		
		TheSelectedPrinterNew = 2
		frmBarcodeLoad.ShowDialog()
		
	End Function
	Public Function RefreshLoad(ByRef Index As Short) As Object
		
		On Error Resume Next
		Dim rs As ADODB.Recordset
		Dim rst As ADODB.Recordset
		
		rs = New ADODB.Recordset
		
		rst = New ADODB.Recordset
		'TheSelectedPrinterNew = 0
		rs = getRS("SELECT * FROM Label WHERE Label.Label_Type=" & Index & " ORDER BY LabelID")
		
        DataList1.DataSource = rs
        DataList1.listField = "Label_Name"
		
		'Bind the DataCombo to the ADO Recordset
		
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = rs
        DataList1.boundColumn = "LabelID"
		'if the Type was Shelf Talker set option button to true else set Barcode option button to true
		If TheType = 1 Then
			Me.Option1(1).Checked = True
		ElseIf TheType = 2 Then 
			Me.Option1(2).Checked = True
		End If
		
		loadLanguage()
		Me.ShowDialog()
		
	End Function
	
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Integer
            Dim rb As New RadioButton
            rb = DirectCast(eventSender, RadioButton)
            Index = GetIndexer(rb, option1)

            On Error Resume Next
            Dim rs As ADODB.Recordset
            Dim rst As ADODB.Recordset

            rs = New ADODB.Recordset

            rst = New ADODB.Recordset

            rs = getRS("SELECT * FROM Label WHERE Label.Label_Type=" & Index & " ORDER BY LabelID")

            DataList1.DataSource = rs
            DataList1.listField = "Label_Name"

            'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
            DataList1.DataSource = rs
            DataList1.boundColumn = "LabelID"
            TheType = Index

            If TheType = 1 Then
                Me.Label1.Text = "Please select the Shelf Talker you wish to modify"
                Me.Text = "Shelf Talker Design"
            Else
                Me.Label1.Text = "Please select the Stock Barcode you wish to modify"
                Me.Text = "Barcode Design"
            End If

        End If
    End Sub
End Class