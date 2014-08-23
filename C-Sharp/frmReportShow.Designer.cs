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
	partial class frmReportShow
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmReportShow() : base()
		{
			Resize += frmReportShow_Resize;
			KeyPress += frmReportShow_KeyPress;
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
		private System.Windows.Forms.Timer withEventsField_tmrZoom;
		public System.Windows.Forms.Timer tmrZoom {
			get { return withEventsField_tmrZoom; }
			set {
				if (withEventsField_tmrZoom != null) {
					withEventsField_tmrZoom.Tick -= tmrZoom_Tick;
				}
				withEventsField_tmrZoom = value;
				if (withEventsField_tmrZoom != null) {
					withEventsField_tmrZoom.Tick += tmrZoom_Tick;
				}
			}
		}
		public System.Windows.Forms.Button cmdPrint;
		public System.Windows.Forms.Button cmdClose;
		private System.Windows.Forms.Panel withEventsField_picButtons;
		public System.Windows.Forms.Panel picButtons {
			get { return withEventsField_picButtons; }
			set {
				if (withEventsField_picButtons != null) {
					withEventsField_picButtons.Resize -= picButtons_Resize;
				}
				withEventsField_picButtons = value;
				if (withEventsField_picButtons != null) {
					withEventsField_picButtons.Resize += picButtons_Resize;
				}
			}
		}
		public System.Windows.Forms.PrintDialog cdbPrinterPrint;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tmrZoom = new System.Windows.Forms.Timer(this.components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cdbPrinterPrint = new System.Windows.Forms.PrintDialog();
			this.CRViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdPrint);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(655, 38);
			this.picButtons.TabIndex = 1;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(291, 3);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(73, 28);
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(576, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 2;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//CRViewer1
			//
			this.CRViewer1.ActiveViewIndex = -1;
			this.CRViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CRViewer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.CRViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CRViewer1.Location = new System.Drawing.Point(0, 38);
			this.CRViewer1.Name = "CRViewer1";
			this.CRViewer1.Size = new System.Drawing.Size(655, 466);
			this.CRViewer1.TabIndex = 2;
			//
			//frmReportShow
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(655, 504);
			this.ControlBox = false;
			this.Controls.Add(this.CRViewer1);
			this.Controls.Add(this.picButtons);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmReportShow";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Customer Statement";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}
			#endregion
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewer1;
	}
}
