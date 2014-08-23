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
	partial class frmPersonFPVerify
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPersonFPVerify() : base()
		{
			FormClosed += frmPersonFPVerify_FormClosed;
			Load += frmPersonFPVerify_Load;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.TextBox eName;
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
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPersonFPVerify));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.eName = new System.Windows.Forms.TextBox();
			this.Command1 = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Verify Form";
			this.ClientSize = new System.Drawing.Size(271, 251);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmPersonFPVerify";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(271, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 5;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.Location = new System.Drawing.Point(184, 3);
			this.cmdExit.TabIndex = 6;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.eName.AutoSize = false;
			this.eName.BackColor = System.Drawing.Color.Blue;
			this.eName.ForeColor = System.Drawing.Color.White;
			this.eName.Size = new System.Drawing.Size(257, 17);
			this.eName.Location = new System.Drawing.Point(8, 48);
			this.eName.ReadOnly = true;
			this.eName.TabIndex = 4;
			this.eName.Text = "name";
			this.eName.AcceptsReturn = true;
			this.eName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.eName.CausesValidation = true;
			this.eName.Enabled = true;
			this.eName.HideSelection = true;
			this.eName.MaxLength = 0;
			this.eName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.eName.Multiline = false;
			this.eName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.eName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.eName.TabStop = true;
			this.eName.Visible = true;
			this.eName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.eName.Name = "eName";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Verify Again ?";
			this.Command1.Size = new System.Drawing.Size(113, 41);
			this.Command1.Location = new System.Drawing.Point(152, 200);
			this.Command1.TabIndex = 1;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.Picture1.Size = new System.Drawing.Size(129, 161);
			this.Picture1.Location = new System.Drawing.Point(8, 80);
			this.Picture1.TabIndex = 0;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.TabStop = true;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.label2.Text = "Name";
			this.label2.Size = new System.Drawing.Size(41, 17);
			this.label2.Location = new System.Drawing.Point(80, 160);
			this.label2.TabIndex = 3;
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Enabled = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.UseMnemonic = true;
			this.label2.Visible = true;
			this.label2.AutoSize = false;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.label2.Name = "label2";
			this.Label1.Text = "Please put your finger on the sensor ...";
			this.Label1.ForeColor = System.Drawing.Color.Red;
			this.Label1.Size = new System.Drawing.Size(105, 105);
			this.Label1.Location = new System.Drawing.Point(152, 80);
			this.Label1.TabIndex = 2;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(picButtons);
			this.Controls.Add(eName);
			this.Controls.Add(Command1);
			this.Controls.Add(Picture1);
			this.Controls.Add(label2);
			this.Controls.Add(Label1);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
