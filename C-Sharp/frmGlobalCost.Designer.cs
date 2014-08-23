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
	partial class frmGlobalCost
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGlobalCost() : base()
		{
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
		private System.Windows.Forms.TextBox withEventsField_txtPassword;
		public System.Windows.Forms.TextBox txtPassword {
			get { return withEventsField_txtPassword; }
			set {
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.KeyDown -= txtPassword_KeyDown;
					withEventsField_txtPassword.KeyPress -= txtPassword_KeyPress;
				}
				withEventsField_txtPassword = value;
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.KeyDown += txtPassword_KeyDown;
					withEventsField_txtPassword.KeyPress += txtPassword_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Button withEventsField_Command3;
		public System.Windows.Forms.Button Command3 {
			get { return withEventsField_Command3; }
			set {
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click -= Command3_Click;
				}
				withEventsField_Command3 = value;
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click += Command3_Click;
				}
			}
		}
		public System.Windows.Forms.ProgressBar prgUpload;
		public System.Windows.Forms.Button Command2;
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
		public System.Windows.Forms.TextBox txtFileName;
		public System.Windows.Forms.OpenFileDialog cmdDlgOpen;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGlobalCost));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Command3 = new System.Windows.Forms.Button();
			this.prgUpload = new System.Windows.Forms.ProgressBar();
			this.Command2 = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.cmdDlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.Label1 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "[Update Cost]";
			this.ClientSize = new System.Drawing.Size(498, 141);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmGlobalCost";
			this.Frame1.Text = "Passwords";
			this.Frame1.Size = new System.Drawing.Size(493, 131);
			this.Frame1.Location = new System.Drawing.Point(2, 4);
			this.Frame1.TabIndex = 7;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtPassword.AutoSize = false;
			this.txtPassword.Size = new System.Drawing.Size(195, 23);
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(186, 54);
			this.txtPassword.PasswordChar = Strings.ChrW(42);
			this.txtPassword.TabIndex = 0;
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
			this.Label2.Text = "Passwords :";
			this.Label2.Size = new System.Drawing.Size(73, 19);
			this.Label2.Location = new System.Drawing.Point(98, 56);
			this.Label2.TabIndex = 8;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command3.Text = "Exit";
			this.Command3.Size = new System.Drawing.Size(105, 29);
			this.Command3.Location = new System.Drawing.Point(6, 104);
			this.Command3.TabIndex = 6;
			this.Command3.BackColor = System.Drawing.SystemColors.Control;
			this.Command3.CausesValidation = true;
			this.Command3.Enabled = true;
			this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command3.TabStop = true;
			this.Command3.Name = "Command3";
			this.prgUpload.Size = new System.Drawing.Size(493, 23);
			this.prgUpload.Location = new System.Drawing.Point(2, 48);
			this.prgUpload.TabIndex = 5;
			this.prgUpload.Maximum = 300;
			this.prgUpload.Name = "prgUpload";
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "Do Update";
			this.Command2.Size = new System.Drawing.Size(107, 29);
			this.Command2.Location = new System.Drawing.Point(386, 104);
			this.Command2.TabIndex = 4;
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "...";
			this.Command1.Size = new System.Drawing.Size(47, 19);
			this.Command1.Location = new System.Drawing.Point(444, 18);
			this.Command1.TabIndex = 3;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.txtFileName.AutoSize = false;
			this.txtFileName.Enabled = false;
			this.txtFileName.Size = new System.Drawing.Size(359, 19);
			this.txtFileName.Location = new System.Drawing.Point(78, 18);
			this.txtFileName.TabIndex = 2;
			this.txtFileName.AcceptsReturn = true;
			this.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFileName.BackColor = System.Drawing.SystemColors.Window;
			this.txtFileName.CausesValidation = true;
			this.txtFileName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFileName.HideSelection = true;
			this.txtFileName.ReadOnly = false;
			this.txtFileName.MaxLength = 0;
			this.txtFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFileName.Multiline = false;
			this.txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFileName.TabStop = true;
			this.txtFileName.Visible = true;
			this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFileName.Name = "txtFileName";
			this.Label1.Text = "File Name :";
			this.Label1.Size = new System.Drawing.Size(71, 15);
			this.Label1.Location = new System.Drawing.Point(2, 20);
			this.Label1.TabIndex = 1;
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
			this.Controls.Add(Frame1);
			this.Controls.Add(Command3);
			this.Controls.Add(prgUpload);
			this.Controls.Add(Command2);
			this.Controls.Add(Command1);
			this.Controls.Add(txtFileName);
			this.Controls.Add(Label1);
			this.Frame1.Controls.Add(txtPassword);
			this.Frame1.Controls.Add(Label2);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
