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
	partial class frmUpdateReportData
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmUpdateReportData() : base()
		{
			Load += frmUpdateReportData_Load;
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
		private System.Windows.Forms.Timer withEventsField_tmrStart;
		public System.Windows.Forms.Timer tmrStart {
			get { return withEventsField_tmrStart; }
			set {
				if (withEventsField_tmrStart != null) {
					withEventsField_tmrStart.Tick -= tmrStart_Tick;
				}
				withEventsField_tmrStart = value;
				if (withEventsField_tmrStart != null) {
					withEventsField_tmrStart.Tick += tmrStart_Tick;
				}
			}
		}
		public System.Windows.Forms.PictureBox picInner;
		public System.Windows.Forms.Panel picOuter;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUpdateReportData));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.tmrStart = new System.Windows.Forms.Timer(components);
			this.picOuter = new System.Windows.Forms.Panel();
			this.picInner = new System.Windows.Forms.PictureBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.picOuter.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.ControlBox = false;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(312, 55);
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmUpdateReportData";
			this.tmrStart.Interval = 100;
			this.tmrStart.Enabled = true;
			this.picOuter.BackColor = System.Drawing.Color.White;
			this.picOuter.Size = new System.Drawing.Size(298, 25);
			this.picOuter.Location = new System.Drawing.Point(6, 21);
			this.picOuter.TabIndex = 0;
			this.picOuter.Dock = System.Windows.Forms.DockStyle.None;
			this.picOuter.CausesValidation = true;
			this.picOuter.Enabled = true;
			this.picOuter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picOuter.Cursor = System.Windows.Forms.Cursors.Default;
			this.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picOuter.TabStop = true;
			this.picOuter.Visible = true;
			this.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picOuter.Name = "picOuter";
			this.picInner.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.picInner.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picInner.Size = new System.Drawing.Size(58, 34);
			this.picInner.Location = new System.Drawing.Point(0, 0);
			this.picInner.TabIndex = 1;
			this.picInner.Dock = System.Windows.Forms.DockStyle.None;
			this.picInner.CausesValidation = true;
			this.picInner.Enabled = true;
			this.picInner.Cursor = System.Windows.Forms.Cursors.Default;
			this.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picInner.TabStop = true;
			this.picInner.Visible = true;
			this.picInner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.picInner.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picInner.Name = "picInner";
			this.Label1.Text = "Loading Report Data ...";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(147, 16);
			this.Label1.Location = new System.Drawing.Point(6, 3);
			this.Label1.TabIndex = 2;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(picOuter);
			this.Controls.Add(Label1);
			this.picOuter.Controls.Add(picInner);
			this.picOuter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
