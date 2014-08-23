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
	partial class frmUpdateWarning
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmUpdateWarning() : base()
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
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdContinue;
		public System.Windows.Forms.Button cmdContinue {
			get { return withEventsField_cmdContinue; }
			set {
				if (withEventsField_cmdContinue != null) {
					withEventsField_cmdContinue.Click -= cmdContinue_Click;
				}
				withEventsField_cmdContinue = value;
				if (withEventsField_cmdContinue != null) {
					withEventsField_cmdContinue.Click += cmdContinue_Click;
				}
			}
		}
		public System.Windows.Forms.Timer tmrStart;
		public System.Windows.Forms.Label lblDesc;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUpdateWarning));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdContinue = new System.Windows.Forms.Button();
			this.tmrStart = new System.Windows.Forms.Timer(components);
			this.lblDesc = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Update Warning ...";
			this.ClientSize = new System.Drawing.Size(468, 258);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmUpdateWarning";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Cancel the Update of Point Of Sale";
			this.cmdClose.Size = new System.Drawing.Size(130, 37);
			this.cmdClose.Location = new System.Drawing.Point(309, 204);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "Print List";
			this.cmdPrint.Size = new System.Drawing.Size(130, 37);
			this.cmdPrint.Location = new System.Drawing.Point(171, 204);
			this.cmdPrint.TabIndex = 0;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdContinue.Text = "Continue with the Update of Point Of Sale";
			this.cmdContinue.Size = new System.Drawing.Size(130, 37);
			this.cmdContinue.Location = new System.Drawing.Point(33, 204);
			this.cmdContinue.TabIndex = 2;
			this.cmdContinue.BackColor = System.Drawing.SystemColors.Control;
			this.cmdContinue.CausesValidation = true;
			this.cmdContinue.Enabled = true;
			this.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdContinue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdContinue.TabStop = true;
			this.cmdContinue.Name = "cmdContinue";
			this.tmrStart.Interval = 10;
			this.tmrStart.Enabled = true;
			this.lblDesc.BackColor = System.Drawing.Color.White;
			this.lblDesc.Text = "There are 47 catalogue prices where your price is equal or less that the products cost price.";
			this.lblDesc.ForeColor = System.Drawing.Color.Red;
			this.lblDesc.Size = new System.Drawing.Size(409, 172);
			this.lblDesc.Location = new System.Drawing.Point(30, 12);
			this.lblDesc.TabIndex = 3;
			this.lblDesc.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDesc.Enabled = true;
			this.lblDesc.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDesc.UseMnemonic = true;
			this.lblDesc.Visible = true;
			this.lblDesc.AutoSize = false;
			this.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDesc.Name = "lblDesc";
			this.Controls.Add(cmdClose);
			this.Controls.Add(cmdPrint);
			this.Controls.Add(cmdContinue);
			this.Controls.Add(lblDesc);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
