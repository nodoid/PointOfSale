Option Strict Off
Option Explicit On
Friend Class frmMTWebReg
	Inherits System.Windows.Forms.Form
	' MTDemo - Multithreading Demo program
	' Copyright © 1997 by Desaware Inc. All Rights Reserved
	
	Dim State As Short
	' State = 0 - Idle
	' State = 1 - Loading existing value
	' State = 2 - Adding 1 to existing value
	' State = 3 - Storing existing value
	' State = 4 - Extra delay
	
	Dim Accumulator As Integer
	
	Const OtherCodeDelay As Short = 10
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		'Dim f As New frmMTDemo1
		'f.show
	End Sub
	
	Private Sub frmMTWebReg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_WARNING: Timer property Timer1.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
		Timer1.Interval = 750 + Rnd() * 500
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		Static otherdelay As Integer
		Select Case State
			Case 0
				lblOperation.Text = "Idle"
				State = 1
			Case 1
				lblOperation.Text = "Loading Acc"
				Accumulator = GenericGlobalCounter
				State = 2
			Case 2
				lblOperation.Text = "Incrementing"
				Accumulator = Accumulator + 1
				State = 3
			Case 3
				lblOperation.Text = "Storing"
				GenericGlobalCounter = Accumulator
				TotalIncrements = TotalIncrements + 1
				State = 4
			Case 4
				lblOperation.Text = "Generic Code"
				If otherdelay >= OtherCodeDelay Then
					State = 0
					otherdelay = 0
				Else
					otherdelay = otherdelay + 1
				End If
		End Select
		UpdateDisplay()
		
	End Sub
	
	Public Sub UpdateDisplay()
		lblGlobalCounter.Text = Str(GenericGlobalCounter)
		lblAccumulator.Text = Str(Accumulator)
		lblVerification.Text = Str(TotalIncrements)
	End Sub
End Class