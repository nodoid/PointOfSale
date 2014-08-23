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
	partial class frmLabel
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmLabel() : base()
		{
			Load += frmLabel_Load;
			KeyPress += frmLabel_KeyPress;
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
		private System.Windows.Forms.ListBox withEventsField_lstLayout;
		public System.Windows.Forms.ListBox lstLayout {
			get { return withEventsField_lstLayout; }
			set {
				if (withEventsField_lstLayout != null) {
					withEventsField_lstLayout.DoubleClick -= lstLayout_DoubleClick;
					withEventsField_lstLayout.KeyPress -= lstLayout_KeyPress;
				}
				withEventsField_lstLayout = value;
				if (withEventsField_lstLayout != null) {
					withEventsField_lstLayout.DoubleClick += lstLayout_DoubleClick;
					withEventsField_lstLayout.KeyPress += lstLayout_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdNext;
		public System.Windows.Forms.Button cmdNext {
			get { return withEventsField_cmdNext; }
			set {
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click -= cmdNext_Click;
				}
				withEventsField_cmdNext = value;
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click += cmdNext_Click;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLabel));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstLayout = new System.Windows.Forms.ListBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select Label Format";
			this.ClientSize = new System.Drawing.Size(364, 263);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmLabel";
			this.lstLayout.Size = new System.Drawing.Size(349, 189);
			this.lstLayout.Location = new System.Drawing.Point(6, 6);
			this.lstLayout.TabIndex = 2;
			this.lstLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstLayout.BackColor = System.Drawing.SystemColors.Window;
			this.lstLayout.CausesValidation = true;
			this.lstLayout.Enabled = true;
			this.lstLayout.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstLayout.IntegralHeight = true;
			this.lstLayout.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstLayout.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstLayout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstLayout.Sorted = false;
			this.lstLayout.TabStop = true;
			this.lstLayout.Visible = true;
			this.lstLayout.MultiColumn = false;
			this.lstLayout.Name = "lstLayout";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(21, 201);
			this.cmdExit.TabIndex = 1;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Size = new System.Drawing.Size(97, 52);
			this.cmdNext.Location = new System.Drawing.Point(243, 201);
			this.cmdNext.TabIndex = 0;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.Controls.Add(lstLayout);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdNext);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
