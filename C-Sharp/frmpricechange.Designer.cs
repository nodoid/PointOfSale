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
	partial class frmpricechange
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmpricechange() : base()
		{
			Load += frmpricechange_Load;
			KeyPress += frmpricechange_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdcancel;
		public System.Windows.Forms.Button cmdcancel {
			get { return withEventsField_cmdcancel; }
			set {
				if (withEventsField_cmdcancel != null) {
					withEventsField_cmdcancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdcancel = value;
				if (withEventsField_cmdcancel != null) {
					withEventsField_cmdcancel.Click += cmdCancel_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdshow;
		public System.Windows.Forms.Button cmdshow {
			get { return withEventsField_cmdshow; }
			set {
				if (withEventsField_cmdshow != null) {
					withEventsField_cmdshow.Click -= cmdShow_Click;
				}
				withEventsField_cmdshow = value;
				if (withEventsField_cmdshow != null) {
					withEventsField_cmdshow.Click += cmdShow_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdenddate;
		public System.Windows.Forms.Button cmdenddate {
			get { return withEventsField_cmdenddate; }
			set {
				if (withEventsField_cmdenddate != null) {
					withEventsField_cmdenddate.Click -= cmdenddate_Click;
				}
				withEventsField_cmdenddate = value;
				if (withEventsField_cmdenddate != null) {
					withEventsField_cmdenddate.Click += cmdenddate_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtenddate;
		public System.Windows.Forms.TextBox txtstartdate;
		private System.Windows.Forms.Button withEventsField_cmdstart;
		public System.Windows.Forms.Button cmdstart {
			get { return withEventsField_cmdstart; }
			set {
				if (withEventsField_cmdstart != null) {
					withEventsField_cmdstart.Click -= cmdStart_Click;
				}
				withEventsField_cmdstart = value;
				if (withEventsField_cmdstart != null) {
					withEventsField_cmdstart.Click += cmdStart_Click;
				}
			}
		}
		public System.Windows.Forms.Label lblInstruction;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmpricechange));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdcancel = new System.Windows.Forms.Button();
			this.cmdshow = new System.Windows.Forms.Button();
			this.cmdenddate = new System.Windows.Forms.Button();
			this.txtenddate = new System.Windows.Forms.TextBox();
			this.txtstartdate = new System.Windows.Forms.TextBox();
			this.cmdstart = new System.Windows.Forms.Button();
			this.lblInstruction = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Price Changes";
			this.ClientSize = new System.Drawing.Size(442, 155);
			this.Location = new System.Drawing.Point(3, 29);
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmpricechange.Icon");
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmpricechange";
			this.cmdcancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdcancel.Text = "&Cancel";
			this.cmdcancel.Size = new System.Drawing.Size(81, 33);
			this.cmdcancel.Location = new System.Drawing.Point(352, 112);
			this.cmdcancel.TabIndex = 7;
			this.cmdcancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdcancel.CausesValidation = true;
			this.cmdcancel.Enabled = true;
			this.cmdcancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdcancel.TabStop = true;
			this.cmdcancel.Name = "cmdcancel";
			this.cmdshow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdshow.Text = "&Show";
			this.cmdshow.Size = new System.Drawing.Size(81, 33);
			this.cmdshow.Location = new System.Drawing.Point(248, 112);
			this.cmdshow.TabIndex = 6;
			this.cmdshow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdshow.CausesValidation = true;
			this.cmdshow.Enabled = true;
			this.cmdshow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdshow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdshow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdshow.TabStop = true;
			this.cmdshow.Name = "cmdshow";
			this.cmdenddate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdenddate.Text = "...";
			this.cmdenddate.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdenddate.Size = new System.Drawing.Size(33, 33);
			this.cmdenddate.Location = new System.Drawing.Point(400, 64);
			this.cmdenddate.TabIndex = 5;
			this.cmdenddate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdenddate.CausesValidation = true;
			this.cmdenddate.Enabled = true;
			this.cmdenddate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdenddate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdenddate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdenddate.TabStop = true;
			this.cmdenddate.Name = "cmdenddate";
			this.txtenddate.AutoSize = false;
			this.txtenddate.Size = new System.Drawing.Size(81, 33);
			this.txtenddate.Location = new System.Drawing.Point(320, 64);
			this.txtenddate.TabIndex = 4;
			this.txtenddate.AcceptsReturn = true;
			this.txtenddate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtenddate.BackColor = System.Drawing.SystemColors.Window;
			this.txtenddate.CausesValidation = true;
			this.txtenddate.Enabled = true;
			this.txtenddate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtenddate.HideSelection = true;
			this.txtenddate.ReadOnly = false;
			this.txtenddate.MaxLength = 0;
			this.txtenddate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtenddate.Multiline = false;
			this.txtenddate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtenddate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtenddate.TabStop = true;
			this.txtenddate.Visible = true;
			this.txtenddate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtenddate.Name = "txtenddate";
			this.txtstartdate.AutoSize = false;
			this.txtstartdate.Size = new System.Drawing.Size(81, 33);
			this.txtstartdate.Location = new System.Drawing.Point(112, 64);
			this.txtstartdate.TabIndex = 2;
			this.txtstartdate.AcceptsReturn = true;
			this.txtstartdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtstartdate.BackColor = System.Drawing.SystemColors.Window;
			this.txtstartdate.CausesValidation = true;
			this.txtstartdate.Enabled = true;
			this.txtstartdate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtstartdate.HideSelection = true;
			this.txtstartdate.ReadOnly = false;
			this.txtstartdate.MaxLength = 0;
			this.txtstartdate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtstartdate.Multiline = false;
			this.txtstartdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtstartdate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtstartdate.TabStop = true;
			this.txtstartdate.Visible = true;
			this.txtstartdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtstartdate.Name = "txtstartdate";
			this.cmdstart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdstart.Text = "...";
			this.cmdstart.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdstart.Size = new System.Drawing.Size(33, 33);
			this.cmdstart.Location = new System.Drawing.Point(192, 64);
			this.cmdstart.TabIndex = 1;
			this.cmdstart.BackColor = System.Drawing.SystemColors.Control;
			this.cmdstart.CausesValidation = true;
			this.cmdstart.Enabled = true;
			this.cmdstart.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdstart.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdstart.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdstart.TabStop = true;
			this.cmdstart.Name = "cmdstart";
			this.lblInstruction.Text = "This Process will print you the Price Changes of the Date range you selected.Please Select the 'Start Date' and the 'End Date'  and Click the Show button.Please Note the Start Date must be earlier than the 'End Date'";
			this.lblInstruction.Size = new System.Drawing.Size(424, 45);
			this.lblInstruction.Location = new System.Drawing.Point(8, 8);
			this.lblInstruction.TabIndex = 8;
			this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblInstruction.BackColor = System.Drawing.SystemColors.Control;
			this.lblInstruction.Enabled = true;
			this.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInstruction.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInstruction.UseMnemonic = true;
			this.lblInstruction.Visible = true;
			this.lblInstruction.AutoSize = false;
			this.lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInstruction.Name = "lblInstruction";
			this.Label2.Text = "End Date:";
			this.Label2.Size = new System.Drawing.Size(81, 33);
			this.Label2.Location = new System.Drawing.Point(232, 72);
			this.Label2.TabIndex = 3;
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
			this.Label1.Text = " Start Date:";
			this.Label1.Size = new System.Drawing.Size(97, 25);
			this.Label1.Location = new System.Drawing.Point(8, 72);
			this.Label1.TabIndex = 0;
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
			this.Controls.Add(cmdcancel);
			this.Controls.Add(cmdshow);
			this.Controls.Add(cmdenddate);
			this.Controls.Add(txtenddate);
			this.Controls.Add(txtstartdate);
			this.Controls.Add(cmdstart);
			this.Controls.Add(lblInstruction);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
