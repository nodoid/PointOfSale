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
	partial class frmPersonFPVerifyOT
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPersonFPVerifyOT() : base()
		{
			Load += frmPersonFPVerifyOT_Load;
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
		public System.Windows.Forms.TextBox eName;
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
		public System.Windows.Forms.PictureBox HiddenPict;
		public System.Windows.Forms.PictureBox Picture1;
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
		public System.Windows.Forms.ListBox Status;
		public System.Windows.Forms.Label FAR;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Prompt;
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPersonFPVerifyOT));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.eName = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.HiddenPict = new System.Windows.Forms.PictureBox();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.Close_Renamed = new System.Windows.Forms.Button();
			this.Status = new System.Windows.Forms.ListBox();
			this.FAR = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Prompt = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Verify Form";
			this.ClientSize = new System.Drawing.Size(522, 310);
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
			this.Name = "frmPersonFPVerifyOT";
			this.eName.AutoSize = false;
			this.eName.BackColor = System.Drawing.Color.Blue;
			this.eName.ForeColor = System.Drawing.Color.White;
			this.eName.Size = new System.Drawing.Size(505, 17);
			this.eName.Location = new System.Drawing.Point(8, 48);
			this.eName.ReadOnly = true;
			this.eName.TabIndex = 11;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(522, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 9;
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
			this.cmdExit.TabIndex = 10;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.HiddenPict.Size = new System.Drawing.Size(41, 33);
			this.HiddenPict.Location = new System.Drawing.Point(152, 344);
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
			this.Picture1.Size = new System.Drawing.Size(185, 185);
			this.Picture1.Location = new System.Drawing.Point(8, 72);
			this.Picture1.TabIndex = 2;
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
			this.Close_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Close_Renamed.Text = "Close";
			this.Close_Renamed.Size = new System.Drawing.Size(81, 25);
			this.Close_Renamed.Location = new System.Drawing.Point(424, 344);
			this.Close_Renamed.TabIndex = 1;
			this.Close_Renamed.Visible = false;
			this.Close_Renamed.BackColor = System.Drawing.SystemColors.Control;
			this.Close_Renamed.CausesValidation = true;
			this.Close_Renamed.Enabled = true;
			this.Close_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Close_Renamed.Cursor = System.Windows.Forms.Cursors.Default;
			this.Close_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Close_Renamed.TabStop = true;
			this.Close_Renamed.Name = "Close_Renamed";
			this.Status.Size = new System.Drawing.Size(305, 124);
			this.Status.Location = new System.Drawing.Point(208, 128);
			this.Status.TabIndex = 0;
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
			this.FAR.Size = new System.Drawing.Size(177, 25);
			this.FAR.Location = new System.Drawing.Point(336, 272);
			this.FAR.TabIndex = 7;
			this.FAR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.FAR.BackColor = System.Drawing.SystemColors.Control;
			this.FAR.Enabled = true;
			this.FAR.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FAR.Cursor = System.Windows.Forms.Cursors.Default;
			this.FAR.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.FAR.UseMnemonic = true;
			this.FAR.Visible = true;
			this.FAR.AutoSize = false;
			this.FAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.FAR.Name = "FAR";
			this.Label3.Text = "False Accept Rate:";
			this.Label3.Size = new System.Drawing.Size(121, 17);
			this.Label3.Location = new System.Drawing.Point(208, 272);
			this.Label3.TabIndex = 6;
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
			this.Label1.Text = "Prompt:";
			this.Label1.Size = new System.Drawing.Size(177, 17);
			this.Label1.Location = new System.Drawing.Point(208, 72);
			this.Label1.TabIndex = 5;
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
			this.Prompt.Text = "Touch the fingerprint reader.";
			this.Prompt.Size = new System.Drawing.Size(305, 25);
			this.Prompt.Location = new System.Drawing.Point(208, 88);
			this.Prompt.TabIndex = 4;
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
			this.Label2.Text = "Status:";
			this.Label2.Size = new System.Drawing.Size(177, 17);
			this.Label2.Location = new System.Drawing.Point(208, 112);
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
			this.Controls.Add(eName);
			this.Controls.Add(picButtons);
			this.Controls.Add(HiddenPict);
			this.Controls.Add(Picture1);
			this.Controls.Add(Close_Renamed);
			this.Controls.Add(Status);
			this.Controls.Add(FAR);
			this.Controls.Add(Label3);
			this.Controls.Add(Label1);
			this.Controls.Add(Prompt);
			this.Controls.Add(Label2);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
