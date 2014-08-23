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
namespace _4PosBackOffice.NET
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class frmZeroiseED
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmZeroiseED() : base()
		{
			KeyPress += frmZeroiseED_KeyPress;
			Load += frmZeroiseED_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox mdbFile;
		private System.Windows.Forms.Button withEventsField_cmdStart;
		public System.Windows.Forms.Button cmdStart {
			get { return withEventsField_cmdStart; }
			set {
				if (withEventsField_cmdStart != null) {
					withEventsField_cmdStart.Click -= cmdStart_Click;
				}
				withEventsField_cmdStart = value;
				if (withEventsField_cmdStart != null) {
					withEventsField_cmdStart.Click += cmdStart_Click;
				}
			}
		}
		public System.Windows.Forms.ProgressBar prgBar;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Button withEventsField_cmdExit;
		public System.Windows.Forms.Button cmdExit {
			get { return withEventsField_cmdExit; }
			set {
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click -= cmdExit_Click;
				}
				withEventsField_cmdExit = value;
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click += cmdExit_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.OpenFileDialog cmdDlgOpen;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public System.Windows.Forms.SaveFileDialog CommonDialog1Save;
		public System.Windows.Forms.FontDialog CommonDialog1Font;
		public System.Windows.Forms.ColorDialog CommonDialog1Color;
		public System.Windows.Forms.PrintDialog CommonDialog1Print;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmZeroiseED));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Command1 = new System.Windows.Forms.Button();
			this.mdbFile = new System.Windows.Forms.TextBox();
			this.cmdStart = new System.Windows.Forms.Button();
			this.prgBar = new System.Windows.Forms.ProgressBar();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdDlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1Save = new System.Windows.Forms.SaveFileDialog();
			this.CommonDialog1Font = new System.Windows.Forms.FontDialog();
			this.CommonDialog1Color = new System.Windows.Forms.ColorDialog();
			this.CommonDialog1Print = new System.Windows.Forms.PrintDialog();
			this.Frame1.SuspendLayout();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Text = "Export Customer Details";
			this.ClientSize = new System.Drawing.Size(539, 153);
			this.Location = new System.Drawing.Point(3, 14);
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmZeroiseED.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmZeroiseED";
			this.Frame1.Size = new System.Drawing.Size(531, 107);
			this.Frame1.Location = new System.Drawing.Point(4, 40);
			this.Frame1.TabIndex = 2;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtPassword.AutoSize = false;
			this.txtPassword.Size = new System.Drawing.Size(179, 20);
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(238, 48);
			this.txtPassword.PasswordChar = Strings.ChrW(42);
			this.txtPassword.TabIndex = 8;
			this.txtPassword.AcceptsReturn = true;
			this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.CausesValidation = true;
			this.txtPassword.Enabled = true;
			this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPassword.HideSelection = true;
			this.txtPassword.ReadOnly = false;
			this.txtPassword.MaxLength = 0;
			this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPassword.Multiline = false;
			this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPassword.TabStop = true;
			this.txtPassword.Visible = true;
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Name = "txtPassword";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "----";
			this.Command1.Size = new System.Drawing.Size(77, 21);
			this.Command1.Location = new System.Drawing.Point(424, 16);
			this.Command1.TabIndex = 5;
			this.Command1.Visible = false;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.mdbFile.AutoSize = false;
			this.mdbFile.Size = new System.Drawing.Size(285, 21);
			this.mdbFile.Location = new System.Drawing.Point(8, 72);
			this.mdbFile.TabIndex = 4;
			this.mdbFile.Visible = false;
			this.mdbFile.AcceptsReturn = true;
			this.mdbFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.mdbFile.BackColor = System.Drawing.SystemColors.Window;
			this.mdbFile.CausesValidation = true;
			this.mdbFile.Enabled = true;
			this.mdbFile.ForeColor = System.Drawing.SystemColors.WindowText;
			this.mdbFile.HideSelection = true;
			this.mdbFile.ReadOnly = false;
			this.mdbFile.MaxLength = 0;
			this.mdbFile.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.mdbFile.Multiline = false;
			this.mdbFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.mdbFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.mdbFile.TabStop = true;
			this.mdbFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mdbFile.Name = "mdbFile";
			this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStart.Text = "Start ...";
			this.cmdStart.Size = new System.Drawing.Size(77, 21);
			this.cmdStart.Location = new System.Drawing.Point(424, 48);
			this.cmdStart.TabIndex = 3;
			this.ToolTip1.SetToolTip(this.cmdStart, "export database to csv");
			this.cmdStart.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStart.CausesValidation = true;
			this.cmdStart.Enabled = true;
			this.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStart.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStart.TabStop = true;
			this.cmdStart.Name = "cmdStart";
			this.prgBar.Size = new System.Drawing.Size(481, 21);
			this.prgBar.Location = new System.Drawing.Point(18, 80);
			this.prgBar.TabIndex = 7;
			this.prgBar.Name = "prgBar";
			this.Label2.Text = "Password:";
			this.Label2.Size = new System.Drawing.Size(101, 21);
			this.Label2.Location = new System.Drawing.Point(136, 48);
			this.Label2.TabIndex = 9;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Please click Start to Export Customer details";
			this.Label1.Size = new System.Drawing.Size(499, 56);
			this.Label1.Location = new System.Drawing.Point(16, 16);
			this.Label1.TabIndex = 6;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(533, 37);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 0;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.None;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.TabStop = true;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "Exit";
			this.cmdExit.Size = new System.Drawing.Size(77, 21);
			this.cmdExit.Location = new System.Drawing.Point(424, 8);
			this.cmdExit.TabIndex = 1;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.Controls.Add(Frame1);
			this.Controls.Add(picButtons);
			this.Frame1.Controls.Add(txtPassword);
			this.Frame1.Controls.Add(Command1);
			this.Frame1.Controls.Add(mdbFile);
			this.Frame1.Controls.Add(cmdStart);
			this.Frame1.Controls.Add(prgBar);
			this.Frame1.Controls.Add(Label2);
			this.Frame1.Controls.Add(Label1);
			this.picButtons.Controls.Add(cmdExit);
			this.Frame1.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
