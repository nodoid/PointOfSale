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
	partial class frmcalendar
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmcalendar() : base()
		{
			Load += frmcalendar_Load;
			KeyPress += frmcalendar_KeyPress;
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
		public MonthCalendar Calendar1;
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
		private System.Windows.Forms.Button withEventsField_cmdok;
		public System.Windows.Forms.Button cmdok {
			get { return withEventsField_cmdok; }
			set {
				if (withEventsField_cmdok != null) {
					withEventsField_cmdok.Click -= cmdOK_Click;
				}
				withEventsField_cmdok = value;
				if (withEventsField_cmdok != null) {
					withEventsField_cmdok.Click += cmdOK_Click;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcalendar));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Calendar1 = new System.Windows.Forms.MonthCalendar();
			this.cmdcancel = new System.Windows.Forms.Button();
			this.cmdok = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			//Calendar1
			//
			this.Calendar1.Location = new System.Drawing.Point(0, 0);
			this.Calendar1.Name = "Calendar1";
			this.Calendar1.TabIndex = 2;
			//
			//cmdcancel
			//
			this.cmdcancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdcancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdcancel.Location = new System.Drawing.Point(154, 165);
			this.cmdcancel.Name = "cmdcancel";
			this.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdcancel.Size = new System.Drawing.Size(73, 33);
			this.cmdcancel.TabIndex = 1;
			this.cmdcancel.Text = "&Cancel";
			this.cmdcancel.UseVisualStyleBackColor = false;
			//
			//cmdok
			//
			this.cmdok.BackColor = System.Drawing.SystemColors.Control;
			this.cmdok.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdok.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdok.Location = new System.Drawing.Point(78, 165);
			this.cmdok.Name = "cmdok";
			this.cmdok.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdok.Size = new System.Drawing.Size(73, 33);
			this.cmdok.TabIndex = 0;
			this.cmdok.Text = "&OK";
			this.cmdok.UseVisualStyleBackColor = false;
			//
			//frmcalendar
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(230, 207);
			this.Controls.Add(this.Calendar1);
			this.Controls.Add(this.cmdcancel);
			this.Controls.Add(this.cmdok);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 29);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmcalendar";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calendar";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
