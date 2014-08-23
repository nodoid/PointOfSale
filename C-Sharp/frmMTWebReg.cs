using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
 // ERROR: Not supported in C#: OptionDeclaration
namespace _4PosBackOffice.NET
{
	internal partial class frmMTWebReg : System.Windows.Forms.Form
	{
// MTDemo - Multithreading Demo program
// Copyright © 1997 by Desaware Inc. All Rights Reserved

		short State;
// State = 0 - Idle
// State = 1 - Loading existing value
// State = 2 - Adding 1 to existing value
// State = 3 - Storing existing value
// State = 4 - Extra delay

		int Accumulator;

		const short OtherCodeDelay = 10;

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim f As New frmMTDemo1
			//f.show
		}

		private void frmMTWebReg_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Timer property Timer1.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
			Timer1.Interval = 750 + VBMath.Rnd() * 500;
		}

		int static_Timer1_Tick_otherdelay;
		private void Timer1_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (State) {
				case 0:
					lblOperation.Text = "Idle";
					State = 1;
					break;
				case 1:
					lblOperation.Text = "Loading Acc";
					Accumulator = modMTDemo.GenericGlobalCounter;
					State = 2;
					break;
				case 2:
					lblOperation.Text = "Incrementing";
					Accumulator = Accumulator + 1;
					State = 3;
					break;
				case 3:
					lblOperation.Text = "Storing";
					modMTDemo.GenericGlobalCounter = Accumulator;
					modMTDemo.TotalIncrements = modMTDemo.TotalIncrements + 1;
					State = 4;
					break;
				case 4:
					lblOperation.Text = "Generic Code";
					if (static_Timer1_Tick_otherdelay >= OtherCodeDelay) {
						State = 0;
						static_Timer1_Tick_otherdelay = 0;
					} else {
						static_Timer1_Tick_otherdelay = static_Timer1_Tick_otherdelay + 1;
					}
					break;
			}
			UpdateDisplay();

		}

		public void UpdateDisplay()
		{
			lblGlobalCounter.Text = Conversion.Str(modMTDemo.GenericGlobalCounter);
			lblAccumulator.Text = Conversion.Str(Accumulator);
			lblVerification.Text = Conversion.Str(modMTDemo.TotalIncrements);
		}
	}
}
