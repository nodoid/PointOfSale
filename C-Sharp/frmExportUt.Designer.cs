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
	partial class frmExportUt
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmExportUt() : base()
		{
			Load += frmExportUt_Load;
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
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.OpenFileDialog cmdlgOpen;
		public System.Windows.Forms.SaveFileDialog cmdlgSave;
		public System.Windows.Forms.FontDialog cmdlgFont;
		public System.Windows.Forms.ColorDialog cmdlgColor;
		public System.Windows.Forms.PrintDialog cmdlgPrint;
		public System.Windows.Forms.TextBox Text1;
		private System.Windows.Forms.Button withEventsField_cmdBrowse;
		public System.Windows.Forms.Button cmdBrowse {
			get { return withEventsField_cmdBrowse; }
			set {
				if (withEventsField_cmdBrowse != null) {
					withEventsField_cmdBrowse.Click -= cmdBrowse_Click;
				}
				withEventsField_cmdBrowse = value;
				if (withEventsField_cmdBrowse != null) {
					withEventsField_cmdBrowse.Click += cmdBrowse_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdExportNow;
		public System.Windows.Forms.Button cmdExportNow {
			get { return withEventsField_cmdExportNow; }
			set {
				if (withEventsField_cmdExportNow != null) {
					withEventsField_cmdExportNow.Click -= cmdExportNow_Click;
				}
				withEventsField_cmdExportNow = value;
				if (withEventsField_cmdExportNow != null) {
					withEventsField_cmdExportNow.Click += cmdExportNow_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmdBrowse = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.cmdlgSave = new System.Windows.Forms.SaveFileDialog();
			this.cmdlgFont = new System.Windows.Forms.FontDialog();
			this.cmdlgColor = new System.Windows.Forms.ColorDialog();
			this.cmdlgPrint = new System.Windows.Forms.PrintDialog();
			this.Text1 = new System.Windows.Forms.TextBox();
			this.cmdExportNow = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//cmdBrowse
			//
			this.cmdBrowse.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBrowse.Location = new System.Drawing.Point(390, 48);
			this.cmdBrowse.Name = "cmdBrowse";
			this.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBrowse.Size = new System.Drawing.Size(43, 17);
			this.cmdBrowse.TabIndex = 1;
			this.cmdBrowse.Text = "...";
			this.ToolTip1.SetToolTip(this.cmdBrowse, "Browse file ");
			this.cmdBrowse.UseVisualStyleBackColor = false;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.Font = new System.Drawing.Font("Times New Roman", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(360, 4);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(73, 27);
			this.cmdExit.TabIndex = 6;
			this.cmdExit.Text = "&Exit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(437, 38);
			this.picButtons.TabIndex = 4;
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
			this.cmdClose.TabIndex = 5;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//Text1
			//
			this.Text1.AcceptsReturn = true;
			this.Text1.BackColor = System.Drawing.SystemColors.Window;
			this.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text1.Enabled = false;
			this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Text1.Location = new System.Drawing.Point(66, 46);
			this.Text1.MaxLength = 0;
			this.Text1.Name = "Text1";
			this.Text1.ReadOnly = true;
			this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text1.Size = new System.Drawing.Size(317, 19);
			this.Text1.TabIndex = 2;
			//
			//cmdExportNow
			//
			this.cmdExportNow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExportNow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExportNow.Font = new System.Drawing.Font("Times New Roman", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdExportNow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExportNow.Location = new System.Drawing.Point(318, 72);
			this.cmdExportNow.Name = "cmdExportNow";
			this.cmdExportNow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExportNow.Size = new System.Drawing.Size(113, 27);
			this.cmdExportNow.TabIndex = 0;
			this.cmdExportNow.Text = "Export &Now!";
			this.cmdExportNow.UseVisualStyleBackColor = false;
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(4, 50);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(59, 15);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "File Path:";
			//
			//frmExportUt
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(437, 106);
			this.ControlBox = false;
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.Text1);
			this.Controls.Add(this.cmdBrowse);
			this.Controls.Add(this.cmdExportNow);
			this.Controls.Add(this.Label1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(3, 19);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmExportUt";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " Export Utilities";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
