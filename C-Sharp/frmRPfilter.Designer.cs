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
	partial class frmRPfilter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmRPfilter() : base()
		{
			KeyPress += frmRPfilter_KeyPress;
			Load += frmRPfilter_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdNamespace;
		public System.Windows.Forms.Button cmdNamespace {
			get { return withEventsField_cmdNamespace; }
			set {
				if (withEventsField_cmdNamespace != null) {
					withEventsField_cmdNamespace.Click -= cmdNamespace_Click;
				}
				withEventsField_cmdNamespace = value;
				if (withEventsField_cmdNamespace != null) {
					withEventsField_cmdNamespace.Click += cmdNamespace_Click;
				}
			}
		}
		public System.Windows.Forms.Label lblHeading;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRPfilter));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdNamespace = new System.Windows.Forms.Button();
			this.lblHeading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "Select the filter for your Report";
			this.ClientSize = new System.Drawing.Size(462, 123);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmRPfilter";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(363, 66);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPrint.Size = new System.Drawing.Size(97, 52);
			this.cmdPrint.Location = new System.Drawing.Point(159, 66);
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNamespace.Text = "&Filter";
			this.cmdNamespace.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNamespace.Size = new System.Drawing.Size(97, 52);
			this.cmdNamespace.Location = new System.Drawing.Point(363, 3);
			this.cmdNamespace.TabIndex = 1;
			this.cmdNamespace.TabStop = false;
			this.cmdNamespace.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNamespace.CausesValidation = true;
			this.cmdNamespace.Enabled = true;
			this.cmdNamespace.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNamespace.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNamespace.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNamespace.Name = "cmdNamespace";
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			this.lblHeading.Size = new System.Drawing.Size(349, 52);
			this.lblHeading.Location = new System.Drawing.Point(3, 3);
			this.lblHeading.TabIndex = 0;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.BackColor = System.Drawing.SystemColors.Control;
			this.lblHeading.Enabled = true;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Name = "lblHeading";
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdPrint);
			this.Controls.Add(cmdNamespace);
			this.Controls.Add(lblHeading);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
