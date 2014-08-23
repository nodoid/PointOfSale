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
	partial class frmLogin
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmLogin() : base()
		{
			Load += frmLogin_Load;
			KeyPress += frmLogin_KeyPress;
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
		private System.Windows.Forms.TextBox withEventsField_txtUserName;
		public System.Windows.Forms.TextBox txtUserName {
			get { return withEventsField_txtUserName; }
			set {
				if (withEventsField_txtUserName != null) {
					withEventsField_txtUserName.Enter -= txtUserName_Enter;
				}
				withEventsField_txtUserName = value;
				if (withEventsField_txtUserName != null) {
					withEventsField_txtUserName.Enter += txtUserName_Enter;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdOK;
		public System.Windows.Forms.Button cmdOK {
			get { return withEventsField_cmdOK; }
			set {
				if (withEventsField_cmdOK != null) {
					withEventsField_cmdOK.Click -= cmdOK_Click;
				}
				withEventsField_cmdOK = value;
				if (withEventsField_cmdOK != null) {
					withEventsField_cmdOK.Click += cmdOK_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtPassword;
		public System.Windows.Forms.TextBox txtPassword {
			get { return withEventsField_txtPassword; }
			set {
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.Enter -= txtPassword_Enter;
				}
				withEventsField_txtPassword = value;
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.Enter += txtPassword_Enter;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "4 POS Application Suite";
			this.ClientSize = new System.Drawing.Size(348, 234);
			this.Location = new System.Drawing.Point(189, 232);
			this.ControlBox = false;
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmLogin.Icon");
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.BackgroundImage = (System.Drawing.Image)resources.GetObject("frmLogin.BackgroundImage");
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmLogin";
			this.txtUserName.AutoSize = false;
			this.txtUserName.Size = new System.Drawing.Size(187, 16);
			this.txtUserName.Location = new System.Drawing.Point(108, 100);
			this.txtUserName.TabIndex = 0;
			this.txtUserName.Text = "default";
			this.txtUserName.AcceptsReturn = true;
			this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
			this.txtUserName.CausesValidation = true;
			this.txtUserName.Enabled = true;
			this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUserName.HideSelection = true;
			this.txtUserName.ReadOnly = false;
			this.txtUserName.MaxLength = 0;
			this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUserName.Multiline = false;
			this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUserName.TabStop = true;
			this.txtUserName.Visible = true;
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUserName.Name = "txtUserName";
			this.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Size = new System.Drawing.Size(76, 26);
			this.cmdOK.Location = new System.Drawing.Point(34, 150);
			this.cmdOK.TabIndex = 2;
			this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOK.CausesValidation = true;
			this.cmdOK.Enabled = true;
			this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOK.TabStop = true;
			this.cmdOK.Name = "cmdOK";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton = this.cmdCancel;
			this.cmdCancel.Text = "E&xit";
			this.cmdCancel.Size = new System.Drawing.Size(76, 26);
			this.cmdCancel.Location = new System.Drawing.Point(222, 148);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.txtPassword.AutoSize = false;
			this.txtPassword.Size = new System.Drawing.Size(187, 16);
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(108, 122);
			this.txtPassword.PasswordChar = Strings.ChrW(42);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "password";
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
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPassword.Name = "txtPassword";
			this.Label2.Text = "If this is a New Installation please click OK to continue. Passwords may be maintained under Store Setup && Security once you have logged in.";
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Size = new System.Drawing.Size(273, 41);
			this.Label2.Location = new System.Drawing.Point(56, 190);
			this.Label2.TabIndex = 5;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "NOTE : ";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Size = new System.Drawing.Size(49, 17);
			this.Label1.Location = new System.Drawing.Point(8, 190);
			this.Label1.TabIndex = 4;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(txtUserName);
			this.Controls.Add(cmdOK);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(txtPassword);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
