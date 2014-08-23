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
	partial class frmMTWebReg
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMTWebReg() : base()
		{
			Load += frmMTWebReg_Load;
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
		public System.Windows.Forms.Label lblVerification;
		public System.Windows.Forms.Label lblOperation;
		public System.Windows.Forms.Label lblAccumulator;
		public System.Windows.Forms.Label lblGlobalCounter;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label label4;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMTWebReg));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command1 = new System.Windows.Forms.Button();
			this.Timer1 = new System.Windows.Forms.Timer(components);
			this.lblVerification = new System.Windows.Forms.Label();
			this.lblOperation = new System.Windows.Forms.Label();
			this.lblAccumulator = new System.Windows.Forms.Label();
			this.lblGlobalCounter = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Form1";
			this.ClientSize = new System.Drawing.Size(186, 209);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmMTWebReg";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Launch New Form";
			this.Command1.Size = new System.Drawing.Size(133, 25);
			this.Command1.Location = new System.Drawing.Point(24, 180);
			this.Command1.TabIndex = 8;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.Timer1.Enabled = false;
			this.Timer1.Interval = 1;
			this.lblVerification.Size = new System.Drawing.Size(109, 13);
			this.lblVerification.Location = new System.Drawing.Point(36, 156);
			this.lblVerification.TabIndex = 7;
			this.lblVerification.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblVerification.BackColor = System.Drawing.SystemColors.Control;
			this.lblVerification.Enabled = true;
			this.lblVerification.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVerification.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVerification.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVerification.UseMnemonic = true;
			this.lblVerification.Visible = true;
			this.lblVerification.AutoSize = false;
			this.lblVerification.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblVerification.Name = "lblVerification";
			this.lblOperation.Size = new System.Drawing.Size(145, 13);
			this.lblOperation.Location = new System.Drawing.Point(36, 114);
			this.lblOperation.TabIndex = 6;
			this.lblOperation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblOperation.BackColor = System.Drawing.SystemColors.Control;
			this.lblOperation.Enabled = true;
			this.lblOperation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOperation.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblOperation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblOperation.UseMnemonic = true;
			this.lblOperation.Visible = true;
			this.lblOperation.AutoSize = false;
			this.lblOperation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblOperation.Name = "lblOperation";
			this.lblAccumulator.Size = new System.Drawing.Size(97, 13);
			this.lblAccumulator.Location = new System.Drawing.Point(36, 72);
			this.lblAccumulator.TabIndex = 5;
			this.lblAccumulator.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblAccumulator.BackColor = System.Drawing.SystemColors.Control;
			this.lblAccumulator.Enabled = true;
			this.lblAccumulator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblAccumulator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblAccumulator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblAccumulator.UseMnemonic = true;
			this.lblAccumulator.Visible = true;
			this.lblAccumulator.AutoSize = false;
			this.lblAccumulator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblAccumulator.Name = "lblAccumulator";
			this.lblGlobalCounter.Size = new System.Drawing.Size(79, 13);
			this.lblGlobalCounter.Location = new System.Drawing.Point(36, 30);
			this.lblGlobalCounter.TabIndex = 4;
			this.lblGlobalCounter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblGlobalCounter.BackColor = System.Drawing.SystemColors.Control;
			this.lblGlobalCounter.Enabled = true;
			this.lblGlobalCounter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGlobalCounter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGlobalCounter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGlobalCounter.UseMnemonic = true;
			this.lblGlobalCounter.Visible = true;
			this.lblGlobalCounter.AutoSize = false;
			this.lblGlobalCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblGlobalCounter.Name = "lblGlobalCounter";
			this.Label3.Text = "TotalIncrements:";
			this.Label3.Size = new System.Drawing.Size(115, 13);
			this.Label3.Location = new System.Drawing.Point(12, 132);
			this.Label3.TabIndex = 3;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.Text = "Operation:";
			this.Label2.Size = new System.Drawing.Size(127, 13);
			this.Label2.Location = new System.Drawing.Point(12, 96);
			this.Label2.TabIndex = 2;
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
			this.Label1.Text = "Accumulator:";
			this.Label1.Size = new System.Drawing.Size(121, 13);
			this.Label1.Location = new System.Drawing.Point(12, 54);
			this.Label1.TabIndex = 1;
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
			this.label4.Text = "GenericGlobalCounter:";
			this.label4.Size = new System.Drawing.Size(133, 13);
			this.label4.Location = new System.Drawing.Point(12, 12);
			this.label4.TabIndex = 0;
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.Enabled = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label4.UseMnemonic = true;
			this.label4.Visible = true;
			this.label4.AutoSize = false;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.label4.Name = "label4";
			this.Controls.Add(Command1);
			this.Controls.Add(lblVerification);
			this.Controls.Add(lblOperation);
			this.Controls.Add(lblAccumulator);
			this.Controls.Add(lblGlobalCounter);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.Controls.Add(label4);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
