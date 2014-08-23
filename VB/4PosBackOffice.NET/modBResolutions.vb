Option Strict Off
Option Explicit On
Module modBResolutions
	Public TaxNarr_ve As String
	Public blpastel As Boolean
	Public blResolution As Boolean
	Public g_Updatep As Boolean
	
	Public Function ResizeForm(ByRef frmNAME As Object, ByRef fWidth As Double, ByRef fHeight As Double, ByRef WState As Short) As Object
		On Error Resume Next ' Error Handler
		Dim nI As Short
		Dim ctl, frm As Object
		Dim nW, nH As Integer
		Dim nHRatio, nWRatio As Single
		' which form is Active now. Try active f
		'     orm first
		
		'If frm.Enabled Then Set frm = frm.Name
		'       Exit For
		'  End If
		'Next
		
		' assumption ratio that forms are being
		'     developed at 800 X 600 Resolution
		
		frm = frmNAME
		
        nW = pixelToTwips(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, True)
        nH = pixelToTwips(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, False)
		nWRatio = nW / 15360 : nHRatio = nH / 11520
		
		
		If nWRatio = 1 Then
			' ------ No need to resize form if Ratio n is Unity.
			'frm.Left = 0: frm.Top = 0
			'frm.WindowState = 2       ' Max. Size.
			GoTo EndResize
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object frm.WindowState. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frm.WindowState = WState
			
		End If
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object frm.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frm.Width = fWidth * nWRatio
		'UPGRADE_WARNING: Couldn't resolve default property of object frm.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frm.Height = fHeight * nWRatio
		
		'UPGRADE_WARNING: Couldn't resolve default property of object frm.Controls. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For nI = 0 To frm.Controls.Count - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object frm.Controls. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ctl = frm.Controls(nI)
			' ------ Now Depending on control type,
			'set its Top, left, Height and Width properties.
			
			'UPGRADE_WARNING: Couldn't resolve default property of object frmNAME.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If CStr(frmNAME.name) = "frmMenu" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ctl.name = "lblCompany" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblPath" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "Label1" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.07)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lbl" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.027)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "DTPicker1" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.027)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "cmdToday" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.027)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "cmdYesterday" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.027)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "cmdLoad" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.03)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblDayEnd" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.022)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblUser" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.07)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblMenuMain" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.02)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblVersion" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.015)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "lblMenuMain" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio + 0.1)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "CRViewer1" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * (nWRatio + 6)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf ctl.name = "picReport" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * (nWRatio)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio)
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * (nHRatio)
				End If
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Left = ctl.Left * nWRatio
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Top = ctl.Top * nHRatio
			End If
			
			'ctl.Left = ctl.Left * nWRatio: ctl.Top = ctl.Top * nHRatio
			'UPGRADE_WARNING: Couldn't resolve default property of object frmNAME.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If CStr(frmNAME.name) = "frmMenu" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ctl.name = "CRViewer1" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Width = ctl.Width * (nWRatio)
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Height = ctl.Height * nHRatio
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Width = ctl.Width * nWRatio
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Height = ctl.Height * nHRatio
				End If
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Width = ctl.Width * nWRatio
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Height = ctl.Height * nHRatio
			End If
			
			
			If TypeOf ctl Is System.Windows.Forms.TextBox Or TypeOf ctl Is System.Windows.Forms.ComboBox Or TypeOf ctl Is System.Windows.Forms.Label Or TypeOf ctl Is System.Windows.Forms.GroupBox Then
				'     ctl.FontSize = ctl.FontSize * nWRatio
			End If
			
			If TypeOf ctl Is System.Windows.Forms.PictureBox Then
				'     ctl.FontSize = ctl.FontSize * nWRatio
			End If
			
			If TypeOf ctl Is System.Windows.Forms.PictureBox Then
				'     ctl.FontSize = ctl.FontSize * nWRatio
			End If
			
			If TypeOf ctl Is System.Windows.Forms.Button Then
				'     ctl.FontSize = ctl.FontSize * nWRatio
			End If
			
			blResolution = True
			
			If TypeOf ctl Is Microsoft.VisualBasic.PowerPacks.LineShape Then ' Graphic Controls..
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.X1 = ctl.X1 * nWRatio
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Y1 = ctl.Y1 * nHRatio
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.X2 = ctl.X2 * nWRatio
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl.Y2 = ctl.Y2 * nHRatio
			End If
			
			If TypeOf ctl Is System.Windows.Forms.Label Then
				'     ctl.FontSize = ctl.FontSize * nWRatio
			End If
			
			'Do date pickers
            If TypeOf ctl Is DateTimePicker Then
                'ctl.FontSize = ctl.FontSize * nWRatio
            End If
			
		Next 
		
		'UPGRADE_WARNING: Couldn't resolve default property of object frm.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frm.Refresh()
EndResize: 
	End Function
End Module