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
	static class modBResolutions
	{
		public static string TaxNarr_ve;
		public static bool blpastel;
		public static bool blResolution;
		public static bool g_Updatep;

		public static object ResizeForm(ref object frmNAME, ref double fWidth, ref double fHeight, ref short WState)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			// Error Handler
			short nI = 0;
			object ctl = null;
			object frm = null;
			int nW = 0;
			int nH = 0;
			float nHRatio = 0;
			float nWRatio = 0;
			// which form is Active now. Try active f
			//     orm first

			//If frm.Enabled Then Set frm = frm.Name
			//       Exit For
			//  End If
			//Next

			// assumption ratio that forms are being
			//     developed at 800 X 600 Resolution

			frm = frmNAME;

			nW = sizeConvertors.pixelToTwips(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, true);
			nH = sizeConvertors.pixelToTwips(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, false);
			nWRatio = nW / 15360;
			nHRatio = nH / 11520;


			if (nWRatio == 1) {
				// ------ No need to resize form if Ratio n is Unity.
				//frm.Left = 0: frm.Top = 0
				//frm.WindowState = 2       ' Max. Size.
				goto EndResize;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object frm.WindowState. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frm.WindowState = WState;

			}


			//UPGRADE_WARNING: Couldn't resolve default property of object frm.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frm.Width = fWidth * nWRatio;
			//UPGRADE_WARNING: Couldn't resolve default property of object frm.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frm.Height = fHeight * nWRatio;

			//UPGRADE_WARNING: Couldn't resolve default property of object frm.Controls. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			for (nI = 0; nI <= frm.Controls.Count() - 1; nI++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object frm.Controls. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ctl = frm.Controls(nI);
				// ------ Now Depending on control type,
				//set its Top, left, Height and Width properties.

				//UPGRADE_WARNING: Couldn't resolve default property of object frmNAME.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Convert.ToString(frmNAME.name) == "frmMenu") {
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (ctl.name == "lblCompany") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblPath") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "Label1") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.07);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lbl") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.027);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "DTPicker1") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.027);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "cmdToday") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.027);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "cmdYesterday") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.027);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "cmdLoad") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.03);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblDayEnd") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.022);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblUser") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.07);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblMenuMain") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.02);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblVersion") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.015);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "lblMenuMain") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio + 0.1);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "CRViewer1") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * (nWRatio + 6);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					} else if (ctl.name == "picReport") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * (nWRatio);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Left = ctl.Left * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Top = ctl.Top * (nHRatio);
					}
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Left = ctl.Left * nWRatio;
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Top = ctl.Top * nHRatio;
				}

				//ctl.Left = ctl.Left * nWRatio: ctl.Top = ctl.Top * nHRatio
				//UPGRADE_WARNING: Couldn't resolve default property of object frmNAME.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Convert.ToString(frmNAME.name) == "frmMenu") {
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (ctl.name == "CRViewer1") {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Width = ctl.Width * (nWRatio);
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Height = ctl.Height * nHRatio;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Width = ctl.Width * nWRatio;
						//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Height = ctl.Height * nHRatio;
					}
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Width = ctl.Width * nWRatio;
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Height = ctl.Height * nHRatio;
				}


				if (ctl is System.Windows.Forms.TextBox | ctl is System.Windows.Forms.ComboBox | ctl is System.Windows.Forms.Label | ctl is System.Windows.Forms.GroupBox) {
					//     ctl.FontSize = ctl.FontSize * nWRatio
				}

				if (ctl is System.Windows.Forms.PictureBox) {
					//     ctl.FontSize = ctl.FontSize * nWRatio
				}

				if (ctl is System.Windows.Forms.PictureBox) {
					//     ctl.FontSize = ctl.FontSize * nWRatio
				}

				if (ctl is System.Windows.Forms.Button) {
					//     ctl.FontSize = ctl.FontSize * nWRatio
				}

				blResolution = true;

				// Graphic Controls..
				if (ctl is Microsoft.VisualBasic.PowerPacks.LineShape) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.X1 = ctl.X1 * nWRatio;
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Y1 = ctl.Y1 * nHRatio;
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.X2 = ctl.X2 * nWRatio;
					//UPGRADE_WARNING: Couldn't resolve default property of object ctl.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ctl.Y2 = ctl.Y2 * nHRatio;
				}

				if (ctl is System.Windows.Forms.Label) {
					//     ctl.FontSize = ctl.FontSize * nWRatio
				}

				//Do date pickers
				if (ctl is DateTimePicker) {
					//ctl.FontSize = ctl.FontSize * nWRatio
				}

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object frm.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frm.Refresh();
			EndResize:
		}
	}
}
