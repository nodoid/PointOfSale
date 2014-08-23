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
	partial class frmPersonFPRegOT
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPersonFPRegOT() : base()
		{
			Load += frmPersonFPRegOT_Load;
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
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.TextBox eName;
		public System.Windows.Forms.PictureBox HiddenPict;
		public System.Windows.Forms.ListBox Status;
		private System.Windows.Forms.Button withEventsField_Close_Renamed;
		public System.Windows.Forms.Button Close_Renamed {
			get { return withEventsField_Close_Renamed; }
			set {
				if (withEventsField_Close_Renamed != null) {
					withEventsField_Close_Renamed.Click -= Close_Renamed_Click;
				}
				withEventsField_Close_Renamed = value;
				if (withEventsField_Close_Renamed != null) {
					withEventsField_Close_Renamed.Click += Close_Renamed_Click;
				}
			}
		}
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.Label Samples;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Prompt;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPersonFPRegOT));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.eName = new System.Windows.Forms.TextBox();
			this.HiddenPict = new System.Windows.Forms.PictureBox();
			this.Status = new System.Windows.Forms.ListBox();
			this.Close_Renamed = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.Samples = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Prompt = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Registration Form";
			this.ClientSize = new System.Drawing.Size(521, 311);
			this.Location = new System.Drawing.Point(3, 29);
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
			this.Name = "frmPersonFPRegOT";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(521, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 10;
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
			this.cmdExit.Location = new System.Drawing.Point(432, 3);
			this.cmdExit.TabIndex = 11;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.Label4.Text = "Registration Form";
			this.Label4.ForeColor = System.Drawing.Color.White;
			this.Label4.Size = new System.Drawing.Size(313, 25);
			this.Label4.Location = new System.Drawing.Point(8, 8);
			this.Label4.TabIndex = 12;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Enabled = true;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.eName.AutoSize = false;
			this.eName.BackColor = System.Drawing.Color.Blue;
			this.eName.ForeColor = System.Drawing.Color.White;
			this.eName.Size = new System.Drawing.Size(489, 17);
			this.eName.Location = new System.Drawing.Point(16, 48);
			this.eName.ReadOnly = true;
			this.eName.TabIndex = 9;
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
			this.HiddenPict.Size = new System.Drawing.Size(41, 33);
			this.HiddenPict.Location = new System.Drawing.Point(224, 328);
			this.HiddenPict.TabIndex = 8;
			this.HiddenPict.Visible = false;
			this.HiddenPict.Dock = System.Windows.Forms.DockStyle.None;
			this.HiddenPict.BackColor = System.Drawing.SystemColors.Control;
			this.HiddenPict.CausesValidation = true;
			this.HiddenPict.Enabled = true;
			this.HiddenPict.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HiddenPict.Cursor = System.Windows.Forms.Cursors.Default;
			this.HiddenPict.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HiddenPict.TabStop = true;
			this.HiddenPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.HiddenPict.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.HiddenPict.Name = "HiddenPict";
			this.Status.Size = new System.Drawing.Size(289, 176);
			this.Status.Location = new System.Drawing.Point(216, 128);
			this.Status.TabIndex = 6;
			this.Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Status.BackColor = System.Drawing.SystemColors.Window;
			this.Status.CausesValidation = true;
			this.Status.Enabled = true;
			this.Status.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Status.IntegralHeight = true;
			this.Status.Cursor = System.Windows.Forms.Cursors.Default;
			this.Status.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Status.Sorted = false;
			this.Status.TabStop = true;
			this.Status.Visible = true;
			this.Status.MultiColumn = false;
			this.Status.Name = "Status";
			this.Close_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Close_Renamed.Text = "Close";
			this.Close_Renamed.Size = new System.Drawing.Size(81, 25);
			this.Close_Renamed.Location = new System.Drawing.Point(416, 320);
			this.Close_Renamed.TabIndex = 4;
			this.Close_Renamed.Visible = false;
			this.Close_Renamed.BackColor = System.Drawing.SystemColors.Control;
			this.Close_Renamed.CausesValidation = true;
			this.Close_Renamed.Enabled = true;
			this.Close_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Close_Renamed.Cursor = System.Windows.Forms.Cursors.Default;
			this.Close_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Close_Renamed.TabStop = true;
			this.Close_Renamed.Name = "Close_Renamed";
			this.Picture1.Size = new System.Drawing.Size(185, 185);
			this.Picture1.Location = new System.Drawing.Point(16, 72);
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
			this.Samples.Size = new System.Drawing.Size(41, 25);
			this.Samples.Location = new System.Drawing.Point(160, 272);
			this.Samples.TabIndex = 7;
			this.Samples.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Samples.BackColor = System.Drawing.SystemColors.Control;
			this.Samples.Enabled = true;
			this.Samples.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Samples.Cursor = System.Windows.Forms.Cursors.Default;
			this.Samples.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Samples.UseMnemonic = true;
			this.Samples.Visible = true;
			this.Samples.AutoSize = false;
			this.Samples.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Samples.Name = "Samples";
			this.Label3.Text = "Fingerprint samples needed:";
			this.Label3.Size = new System.Drawing.Size(145, 25);
			this.Label3.Location = new System.Drawing.Point(16, 272);
			this.Label3.TabIndex = 5;
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
			this.Label2.Text = "Status:";
			this.Label2.Size = new System.Drawing.Size(177, 17);
			this.Label2.Location = new System.Drawing.Point(216, 112);
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
			this.Prompt.Text = "Touch the fingerprint reader.";
			this.Prompt.Size = new System.Drawing.Size(289, 17);
			this.Prompt.Location = new System.Drawing.Point(216, 88);
			this.Prompt.TabIndex = 2;
			this.Prompt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Prompt.BackColor = System.Drawing.SystemColors.Control;
			this.Prompt.Enabled = true;
			this.Prompt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Prompt.Cursor = System.Windows.Forms.Cursors.Default;
			this.Prompt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Prompt.UseMnemonic = true;
			this.Prompt.Visible = true;
			this.Prompt.AutoSize = false;
			this.Prompt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Prompt.Name = "Prompt";
			this.Label1.Text = "Prompt:";
			this.Label1.Size = new System.Drawing.Size(177, 17);
			this.Label1.Location = new System.Drawing.Point(216, 72);
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
			this.Controls.Add(picButtons);
			this.Controls.Add(eName);
			this.Controls.Add(HiddenPict);
			this.Controls.Add(Status);
			this.Controls.Add(Close_Renamed);
			this.Controls.Add(Picture1);
			this.Controls.Add(Samples);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Prompt);
			this.Controls.Add(Label1);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(Label4);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
