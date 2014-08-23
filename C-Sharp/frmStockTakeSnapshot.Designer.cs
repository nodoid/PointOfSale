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
	partial class frmStockTakeSnapshot
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTakeSnapshot() : base()
		{
			Load += frmStockTakeSnapshot_Load;
			KeyPress += frmStockTakeSnapshot_KeyPress;
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
		private System.Windows.Forms.Timer withEventsField_Timer1;
		public System.Windows.Forms.Timer Timer1 {
			get { return withEventsField_Timer1; }
			set {
				if (withEventsField_Timer1 != null) {
					withEventsField_Timer1.Tick -= Timer1_Tick;
				}
				withEventsField_Timer1 = value;
				if (withEventsField_Timer1 != null) {
					withEventsField_Timer1.Tick += Timer1_Tick;
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
		private System.Windows.Forms.Button withEventsField_cmdProceed;
		public System.Windows.Forms.Button cmdProceed {
			get { return withEventsField_cmdProceed; }
			set {
				if (withEventsField_cmdProceed != null) {
					withEventsField_cmdProceed.Click -= cmdProceed_Click;
				}
				withEventsField_cmdProceed = value;
				if (withEventsField_cmdProceed != null) {
					withEventsField_cmdProceed.Click += cmdProceed_Click;
				}
			}
		}
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.Label lbl;
		public System.Windows.Forms.Label lblInstruction;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTakeSnapshot));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Timer1 = new System.Windows.Forms.Timer(components);
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdProceed = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.lbl = new System.Windows.Forms.Label();
			this.lblInstruction = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Stock Take Snapshot";
			this.ClientSize = new System.Drawing.Size(391, 215);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockTakeSnapshot";
			this.Timer1.Enabled = false;
			this.Timer1.Interval = 10;
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 25);
			this.cmdExit.Location = new System.Drawing.Point(6, 180);
			this.cmdExit.TabIndex = 0;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProceed.Text = "&Proceed";
			this.cmdProceed.Size = new System.Drawing.Size(97, 25);
			this.cmdProceed.Location = new System.Drawing.Point(288, 180);
			this.cmdProceed.TabIndex = 1;
			this.cmdProceed.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProceed.CausesValidation = true;
			this.cmdProceed.Enabled = true;
			this.cmdProceed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProceed.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProceed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProceed.TabStop = true;
			this.cmdProceed.Name = "cmdProceed";
			this.Picture1.Size = new System.Drawing.Size(111, 108);
			this.Picture1.Location = new System.Drawing.Point(6, 6);
			this.Picture1.Image = (System.Drawing.Image)resources.GetObject("Picture1.Image");
			this.Picture1.TabIndex = 2;
			this.Picture1.TabStop = false;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.lbl.Text = "Please note that should you run the 'Create Theoretical Stock Snapshot' process you will over write the previously created snapshot.";
			this.lbl.Size = new System.Drawing.Size(256, 52);
			this.lbl.Location = new System.Drawing.Point(126, 120);
			this.lbl.TabIndex = 4;
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl.BackColor = System.Drawing.SystemColors.Control;
			this.lbl.Enabled = true;
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl.UseMnemonic = true;
			this.lbl.Visible = true;
			this.lbl.AutoSize = false;
			this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbl.Name = "lbl";
			this.lblInstruction.Text = "The 'Create Theoretical Stock Snapshot' process will create a snapshot of your stock holding as it stands currently for the purpose of facilitating your stock taking process. The theoretical snapshot that you create will remain constant until the next time that this process is run. This will allow you to continue your day-to-day activities without affecting your stock take count.";
			this.lblInstruction.Size = new System.Drawing.Size(256, 109);
			this.lblInstruction.Location = new System.Drawing.Point(126, 6);
			this.lblInstruction.TabIndex = 3;
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
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdProceed);
			this.Controls.Add(Picture1);
			this.Controls.Add(lbl);
			this.Controls.Add(lblInstruction);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
