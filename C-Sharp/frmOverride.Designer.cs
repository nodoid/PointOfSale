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
	partial class frmOverride
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOverride() : base()
		{
			Load += frmOverride_Load;
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
					withEventsField_txtPassword.KeyPress -= txtPassword_KeyPress;
				}
				withEventsField_txtPassword = value;
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.KeyPress += txtPassword_KeyPress;
				}
			}
		}
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
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblError;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverride));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblError = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.Picture1).BeginInit();
			this.SuspendLayout();
			//
			//txtPassword
			//
			this.txtPassword.AcceptsReturn = true;
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(9, 75);
			this.txtPassword.MaxLength = 0;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = Strings.ChrW(35);
			this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPassword.Size = new System.Drawing.Size(187, 19);
			this.txtPassword.TabIndex = 2;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(114, 120);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(82, 49);
			this.cmdExit.TabIndex = 1;
			this.cmdExit.TabStop = false;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//Picture1
			//
			this.Picture1.BackColor = System.Drawing.Color.Blue;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Picture1.Image = (System.Drawing.Image)resources.GetObject("Picture1.Image");
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.Name = "Picture1";
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Size = new System.Drawing.Size(206, 41);
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Picture1.TabIndex = 0;
			this.Picture1.TabStop = false;
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(12, 60);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(76, 13);
			this._lbl_0.TabIndex = 4;
			this._lbl_0.Text = "Access Code :";
			//
			//lblError
			//
			this.lblError.BackColor = System.Drawing.Color.Transparent;
			this.lblError.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(12, 99);
			this.lblError.Name = "lblError";
			this.lblError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblError.Size = new System.Drawing.Size(185, 16);
			this.lblError.TabIndex = 3;
			this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			//
			//frmOverride
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(206, 178);
			this.ControlBox = false;
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.Picture1);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this.lblError);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOverride";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)this.Picture1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
