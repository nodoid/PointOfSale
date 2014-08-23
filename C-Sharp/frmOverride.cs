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
	internal partial class frmOverride : System.Windows.Forms.Form
	{
		bool slocalOR;
		int slocalMgrID;

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmOverride_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtPassword.Text = "";
		}

		public bool sOverride(ref int sMgrID)
		{
			slocalMgrID = 0;
			slocalOR = false;
			ShowDialog();
			sMgrID = slocalMgrID;
			return slocalOR;
		}

		private void txtPassword_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			ADODB.Recordset rs = default(ADODB.Recordset);
			slocalOR = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			switch (KeyAscii) {
				case 13:
					//Dim user As user
					KeyAscii = 0;
					rs = modRecordSet.getRS(ref "SELECT * FROM Person WHERE (Person_QuickAccess = '" + Strings.Replace(this.txtPassword.Text, "'", "''") + "')");
					if (rs.BOF | rs.EOF) {
						lblError.Text = "Invalid Security Code!";
						txtPassword.SelectionStart = 0;
						txtPassword.SelectionLength = 999;
						goto EventExitSub;
					} else {
						//MsgBox "Login 1"
						if (Convert.ToInt32(rs.Fields("Person_SecurityBit").Value + "0")) {
							if (8192 & rs.Fields("Person_SecurityBit").Value) {
								slocalOR = true;
								slocalMgrID = rs.Fields("PersonID").Value;
								this.Close();
							} else {
								lblError.Text = "Call Your Supervisor!";
								txtPassword.SelectionStart = 0;
								txtPassword.SelectionLength = 999;
								goto EventExitSub;
							}
						}
					}
					break;
				case 27:
					KeyAscii = 0;
					this.Close();
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
