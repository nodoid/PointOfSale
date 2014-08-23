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
	partial class frmChangeDisplay
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmChangeDisplay() : base()
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
		private System.Windows.Forms.Button withEventsField_cmdSubmit;
		public System.Windows.Forms.Button cmdSubmit {
			get { return withEventsField_cmdSubmit; }
			set {
				if (withEventsField_cmdSubmit != null) {
					withEventsField_cmdSubmit.Click -= cmdSubmit_Click;
				}
				withEventsField_cmdSubmit = value;
				if (withEventsField_cmdSubmit != null) {
					withEventsField_cmdSubmit.Click += cmdSubmit_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtNumber;
		public System.Windows.Forms.TextBox txtNumber {
			get { return withEventsField_txtNumber; }
			set {
				if (withEventsField_txtNumber != null) {
					withEventsField_txtNumber.KeyPress -= txtNumber_KeyPress;
				}
				withEventsField_txtNumber = value;
				if (withEventsField_txtNumber != null) {
					withEventsField_txtNumber.KeyPress += txtNumber_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label lblName;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangeDisplay));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdSubmit = new System.Windows.Forms.Button();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Text = "Form1";
			this.ClientSize = new System.Drawing.Size(248, 82);
			this.Location = new System.Drawing.Point(0, 0);
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
			this.Name = "frmChangeDisplay";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Decline";
			this.Command1.Size = new System.Drawing.Size(73, 22);
			this.Command1.Location = new System.Drawing.Point(172, 52);
			this.Command1.TabIndex = 4;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.cmdSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSubmit.Text = "Accept";
			this.cmdSubmit.Size = new System.Drawing.Size(73, 22);
			this.cmdSubmit.Location = new System.Drawing.Point(92, 52);
			this.cmdSubmit.TabIndex = 1;
			this.cmdSubmit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmit.CausesValidation = true;
			this.cmdSubmit.Enabled = true;
			this.cmdSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSubmit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmit.TabStop = true;
			this.cmdSubmit.Name = "cmdSubmit";
			this.txtNumber.AutoSize = false;
			this.txtNumber.Size = new System.Drawing.Size(81, 23);
			this.txtNumber.Location = new System.Drawing.Point(2, 50);
			this.txtNumber.TabIndex = 0;
			this.txtNumber.AcceptsReturn = true;
			this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNumber.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumber.CausesValidation = true;
			this.txtNumber.Enabled = true;
			this.txtNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNumber.HideSelection = true;
			this.txtNumber.ReadOnly = false;
			this.txtNumber.MaxLength = 0;
			this.txtNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNumber.Multiline = false;
			this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNumber.TabStop = true;
			this.txtNumber.Visible = true;
			this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNumber.Name = "txtNumber";
			this.lblName.Text = "Enter the desired display number";
			this.lblName.Size = new System.Drawing.Size(119, 19);
			this.lblName.Location = new System.Drawing.Point(0, 26);
			this.lblName.TabIndex = 3;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblName.BackColor = System.Drawing.SystemColors.Control;
			this.lblName.Enabled = true;
			this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblName.UseMnemonic = true;
			this.lblName.Visible = true;
			this.lblName.AutoSize = false;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblName.Name = "lblName";
			this.Label1.Text = "Enter the desired display number";
			this.Label1.Size = new System.Drawing.Size(241, 19);
			this.Label1.Location = new System.Drawing.Point(2, 4);
			this.Label1.TabIndex = 2;
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
			this.Controls.Add(Command1);
			this.Controls.Add(cmdSubmit);
			this.Controls.Add(txtNumber);
			this.Controls.Add(lblName);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
