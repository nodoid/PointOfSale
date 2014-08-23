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
	partial class frmPersonFPReg
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPersonFPReg() : base()
		{
			Load += frmPersonFPReg_Load;
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
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Panel picButtons;
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
		public System.Windows.Forms.TextBox eName;
		private System.Windows.Forms.Button withEventsField_start_cmd;
		public System.Windows.Forms.Button start_cmd {
			get { return withEventsField_start_cmd; }
			set {
				if (withEventsField_start_cmd != null) {
					withEventsField_start_cmd.Click -= start_cmd_Click;
				}
				withEventsField_start_cmd = value;
				if (withEventsField_start_cmd != null) {
					withEventsField_start_cmd.Click += start_cmd_Click;
				}
			}
		}
		public System.Windows.Forms.PictureBox _picSample_3;
		public System.Windows.Forms.PictureBox _picSample_2;
		public System.Windows.Forms.PictureBox _picSample_1;
		public System.Windows.Forms.PictureBox _picSample_0;
		public System.Windows.Forms.Label _Label6_3;
		public System.Windows.Forms.Label _Label6_2;
		public System.Windows.Forms.Label _Label6_1;
		public System.Windows.Forms.Label _Label6_0;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblEvents;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblQuality;
		//Public WithEvents Label6 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents picSample As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPersonFPReg));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Command1 = new System.Windows.Forms.Button();
			this.eName = new System.Windows.Forms.TextBox();
			this.start_cmd = new System.Windows.Forms.Button();
			this._picSample_3 = new System.Windows.Forms.PictureBox();
			this._picSample_2 = new System.Windows.Forms.PictureBox();
			this._picSample_1 = new System.Windows.Forms.PictureBox();
			this._picSample_0 = new System.Windows.Forms.PictureBox();
			this._Label6_3 = new System.Windows.Forms.Label();
			this._Label6_2 = new System.Windows.Forms.Label();
			this._Label6_1 = new System.Windows.Forms.Label();
			this._Label6_0 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblEvents = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblQuality = new System.Windows.Forms.Label();
			//Me.Label6 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.picSample = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.picSample, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Registration Form";
			this.ClientSize = new System.Drawing.Size(409, 265);
			this.Location = new System.Drawing.Point(3, 19);
			this.ControlBox = false;
			this.ForeColor = System.Drawing.SystemColors.Desktop;
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
			this.Name = "frmPersonFPReg";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(409, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 15;
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
			this.cmdExit.Location = new System.Drawing.Point(328, 3);
			this.cmdExit.TabIndex = 16;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.Label3.Text = "Press Start Button to Start";
			this.Label3.ForeColor = System.Drawing.Color.White;
			this.Label3.Size = new System.Drawing.Size(313, 25);
			this.Label3.Location = new System.Drawing.Point(8, 8);
			this.Label3.TabIndex = 17;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Verify";
			this.Command1.Size = new System.Drawing.Size(65, 25);
			this.Command1.Location = new System.Drawing.Point(168, 232);
			this.Command1.TabIndex = 14;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.eName.AutoSize = false;
			this.eName.BackColor = System.Drawing.Color.Blue;
			this.eName.ForeColor = System.Drawing.Color.White;
			this.eName.Size = new System.Drawing.Size(377, 17);
			this.eName.Location = new System.Drawing.Point(16, 48);
			this.eName.ReadOnly = true;
			this.eName.TabIndex = 13;
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
			this.start_cmd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.start_cmd.Text = "Start";
			this.start_cmd.Size = new System.Drawing.Size(65, 25);
			this.start_cmd.Location = new System.Drawing.Point(168, 200);
			this.start_cmd.TabIndex = 12;
			this.start_cmd.BackColor = System.Drawing.SystemColors.Control;
			this.start_cmd.CausesValidation = true;
			this.start_cmd.Enabled = true;
			this.start_cmd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.start_cmd.Cursor = System.Windows.Forms.Cursors.Default;
			this.start_cmd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.start_cmd.TabStop = true;
			this.start_cmd.Name = "start_cmd";
			this._picSample_3.Size = new System.Drawing.Size(85, 109);
			this._picSample_3.Location = new System.Drawing.Point(304, 80);
			this._picSample_3.TabIndex = 7;
			this._picSample_3.Dock = System.Windows.Forms.DockStyle.None;
			this._picSample_3.BackColor = System.Drawing.SystemColors.Control;
			this._picSample_3.CausesValidation = true;
			this._picSample_3.Enabled = true;
			this._picSample_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._picSample_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._picSample_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picSample_3.TabStop = true;
			this._picSample_3.Visible = true;
			this._picSample_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this._picSample_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._picSample_3.Name = "_picSample_3";
			this._picSample_2.Size = new System.Drawing.Size(85, 109);
			this._picSample_2.Location = new System.Drawing.Point(208, 80);
			this._picSample_2.TabIndex = 6;
			this._picSample_2.Dock = System.Windows.Forms.DockStyle.None;
			this._picSample_2.BackColor = System.Drawing.SystemColors.Control;
			this._picSample_2.CausesValidation = true;
			this._picSample_2.Enabled = true;
			this._picSample_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._picSample_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._picSample_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picSample_2.TabStop = true;
			this._picSample_2.Visible = true;
			this._picSample_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this._picSample_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._picSample_2.Name = "_picSample_2";
			this._picSample_1.Size = new System.Drawing.Size(85, 109);
			this._picSample_1.Location = new System.Drawing.Point(112, 80);
			this._picSample_1.TabIndex = 5;
			this._picSample_1.Dock = System.Windows.Forms.DockStyle.None;
			this._picSample_1.BackColor = System.Drawing.SystemColors.Control;
			this._picSample_1.CausesValidation = true;
			this._picSample_1.Enabled = true;
			this._picSample_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._picSample_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._picSample_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picSample_1.TabStop = true;
			this._picSample_1.Visible = true;
			this._picSample_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this._picSample_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._picSample_1.Name = "_picSample_1";
			this._picSample_0.Size = new System.Drawing.Size(85, 109);
			this._picSample_0.Location = new System.Drawing.Point(16, 80);
			this._picSample_0.TabIndex = 0;
			this._picSample_0.Dock = System.Windows.Forms.DockStyle.None;
			this._picSample_0.BackColor = System.Drawing.SystemColors.Control;
			this._picSample_0.CausesValidation = true;
			this._picSample_0.Enabled = true;
			this._picSample_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._picSample_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._picSample_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picSample_0.TabStop = true;
			this._picSample_0.Visible = true;
			this._picSample_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this._picSample_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._picSample_0.Name = "_picSample_0";
			this._Label6_3.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._Label6_3.Size = new System.Drawing.Size(89, 113);
			this._Label6_3.Location = new System.Drawing.Point(304, 76);
			this._Label6_3.TabIndex = 11;
			this._Label6_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_3.Enabled = true;
			this._Label6_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label6_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_3.UseMnemonic = true;
			this._Label6_3.Visible = true;
			this._Label6_3.AutoSize = false;
			this._Label6_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_3.Name = "_Label6_3";
			this._Label6_2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._Label6_2.Size = new System.Drawing.Size(89, 113);
			this._Label6_2.Location = new System.Drawing.Point(208, 76);
			this._Label6_2.TabIndex = 10;
			this._Label6_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_2.Enabled = true;
			this._Label6_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label6_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_2.UseMnemonic = true;
			this._Label6_2.Visible = true;
			this._Label6_2.AutoSize = false;
			this._Label6_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_2.Name = "_Label6_2";
			this._Label6_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._Label6_1.Size = new System.Drawing.Size(89, 113);
			this._Label6_1.Location = new System.Drawing.Point(112, 76);
			this._Label6_1.TabIndex = 9;
			this._Label6_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_1.Enabled = true;
			this._Label6_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label6_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_1.UseMnemonic = true;
			this._Label6_1.Visible = true;
			this._Label6_1.AutoSize = false;
			this._Label6_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_1.Name = "_Label6_1";
			this._Label6_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._Label6_0.Size = new System.Drawing.Size(89, 113);
			this._Label6_0.Location = new System.Drawing.Point(16, 76);
			this._Label6_0.TabIndex = 8;
			this._Label6_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label6_0.Enabled = true;
			this._Label6_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label6_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label6_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label6_0.UseMnemonic = true;
			this._Label6_0.Visible = true;
			this._Label6_0.AutoSize = false;
			this._Label6_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label6_0.Name = "_Label6_0";
			this.Label2.Text = "Events";
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label2.Size = new System.Drawing.Size(41, 16);
			this.Label2.Location = new System.Drawing.Point(248, 200);
			this.Label2.TabIndex = 4;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = true;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.lblEvents.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblEvents.Size = new System.Drawing.Size(145, 25);
			this.lblEvents.Location = new System.Drawing.Point(248, 216);
			this.lblEvents.TabIndex = 3;
			this.lblEvents.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblEvents.BackColor = System.Drawing.SystemColors.Control;
			this.lblEvents.Enabled = true;
			this.lblEvents.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblEvents.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblEvents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblEvents.UseMnemonic = true;
			this.lblEvents.Visible = true;
			this.lblEvents.AutoSize = false;
			this.lblEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblEvents.Name = "lblEvents";
			this.Label1.Text = "Quality";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(42, 16);
			this.Label1.Location = new System.Drawing.Point(16, 200);
			this.Label1.TabIndex = 2;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.lblQuality.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblQuality.Size = new System.Drawing.Size(137, 25);
			this.lblQuality.Location = new System.Drawing.Point(16, 216);
			this.lblQuality.TabIndex = 1;
			this.lblQuality.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblQuality.BackColor = System.Drawing.SystemColors.Control;
			this.lblQuality.Enabled = true;
			this.lblQuality.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblQuality.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblQuality.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblQuality.UseMnemonic = true;
			this.lblQuality.Visible = true;
			this.lblQuality.AutoSize = false;
			this.lblQuality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblQuality.Name = "lblQuality";
			this.Controls.Add(picButtons);
			this.Controls.Add(Command1);
			this.Controls.Add(eName);
			this.Controls.Add(start_cmd);
			this.Controls.Add(_picSample_3);
			this.Controls.Add(_picSample_2);
			this.Controls.Add(_picSample_1);
			this.Controls.Add(_picSample_0);
			this.Controls.Add(_Label6_3);
			this.Controls.Add(_Label6_2);
			this.Controls.Add(_Label6_1);
			this.Controls.Add(_Label6_0);
			this.Controls.Add(Label2);
			this.Controls.Add(lblEvents);
			this.Controls.Add(Label1);
			this.Controls.Add(lblQuality);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(Label3);
			//Me.Label6.SetIndex(_Label6_3, CType(3, Short))
			//Me.Label6.SetIndex(_Label6_2, CType(2, Short))
			//Me.Label6.SetIndex(_Label6_1, CType(1, Short))
			//Me.Label6.SetIndex(_Label6_0, CType(0, Short))
			//Me.picSample.SetIndex(_picSample_3, CType(3, Short))
			//Me.picSample.SetIndex(_picSample_2, CType(2, Short))
			//Me.picSample.SetIndex(_picSample_1, CType(1, Short))
			//Me.picSample.SetIndex(_picSample_0, CType(0, Short))
			//CType(Me.picSample, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
