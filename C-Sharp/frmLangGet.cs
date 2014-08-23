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
	internal partial class frmLangGet : System.Windows.Forms.Form
	{
		string gName;
		string gScreen;
		bool gRTL;

		public void getLanguageValue(ref string lName, ref bool bRTL, ref string sScreen)
		{
			//lblName.Caption = lName
			//lblKey.Caption = frmKeyboard.getKeyDescription(KeyCode, Shift)
			txtTrans.Text = lName;
			if (bRTL == true)
				chkRTL.CheckState = System.Windows.Forms.CheckState.Checked;
			else
				chkRTL.CheckState = System.Windows.Forms.CheckState.Unchecked;
			txtTrans.SelectionStart = 0;
			txtTrans.SelectionLength = 9999;
			//txtTrans.SetFocus
			ShowDialog();
			lName = gName;
			bRTL = gRTL;
			sScreen = sScreen;
		}

		private void cmdAccept_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			gName = txtTrans.Text;
			gRTL = chkRTL.CheckState;
			//gScreen = sScreen
			this.Close();
		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			gName = "";
			gRTL = chkRTL.CheckState;
		}

		private void Text1_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//    Select Case KeyCode
			//        Case 16, 17, 18
			//        Case Else
			//            lblKey.Caption = frmKeyboard.getKeyDescription(KeyCode, Shift)
			//            gKeyCode = KeyCode
			//            gShift = Shift
			//    End Select
			//    KeyCode = 0
		}

		private void Text1_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//    KeyAscii = 0
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
