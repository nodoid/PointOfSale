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
	partial class frmKeyboardGet
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmKeyboardGet() : base()
		{
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
		private System.Windows.Forms.Button withEventsField_cmdAccept;
		public System.Windows.Forms.Button cmdAccept {
			get { return withEventsField_cmdAccept; }
			set {
				if (withEventsField_cmdAccept != null) {
					withEventsField_cmdAccept.Click -= cmdAccept_Click;
				}
				withEventsField_cmdAccept = value;
				if (withEventsField_cmdAccept != null) {
					withEventsField_cmdAccept.Click += cmdAccept_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_Text1;
		public System.Windows.Forms.TextBox Text1 {
			get { return withEventsField_Text1; }
			set {
				if (withEventsField_Text1 != null) {
					withEventsField_Text1.KeyDown -= Text1_KeyDown;
					withEventsField_Text1.KeyPress -= Text1_KeyPress;
				}
				withEventsField_Text1 = value;
				if (withEventsField_Text1 != null) {
					withEventsField_Text1.KeyDown += Text1_KeyDown;
					withEventsField_Text1.KeyPress += Text1_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label lblName;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblKey;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmKeyboardGet));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.Text1 = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblKey = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(250, 76);
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmKeyboardGet";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Decline";
			this.Command1.Size = new System.Drawing.Size(73, 22);
			this.Command1.Location = new System.Drawing.Point(174, 42);
			this.Command1.TabIndex = 3;
			this.Command1.TabStop = false;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Name = "Command1";
			this.cmdAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAccept.Text = "Accept";
			this.cmdAccept.Size = new System.Drawing.Size(73, 22);
			this.cmdAccept.Location = new System.Drawing.Point(99, 42);
			this.cmdAccept.TabIndex = 2;
			this.cmdAccept.TabStop = false;
			this.cmdAccept.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAccept.CausesValidation = true;
			this.cmdAccept.Enabled = true;
			this.cmdAccept.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAccept.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAccept.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAccept.Name = "cmdAccept";
			this.Text1.AutoSize = false;
			this.Text1.Size = new System.Drawing.Size(149, 25);
			this.Text1.Location = new System.Drawing.Point(0, 108);
			this.Text1.TabIndex = 0;
			this.Text1.Text = "Text1";
			this.Text1.AcceptsReturn = true;
			this.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Text1.BackColor = System.Drawing.SystemColors.Window;
			this.Text1.CausesValidation = true;
			this.Text1.Enabled = true;
			this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Text1.HideSelection = true;
			this.Text1.ReadOnly = false;
			this.Text1.MaxLength = 0;
			this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text1.Multiline = false;
			this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Text1.TabStop = true;
			this.Text1.Visible = true;
			this.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Text1.Name = "Text1";
			this.lblName.Text = "...";
			this.lblName.Size = new System.Drawing.Size(241, 16);
			this.lblName.Location = new System.Drawing.Point(3, 21);
			this.lblName.TabIndex = 5;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Enabled = true;
			this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblName.UseMnemonic = true;
			this.lblName.Visible = true;
			this.lblName.AutoSize = false;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblName.Name = "lblName";
			this.Label1.Text = "Press the desired Key combination";
			this.Label1.Size = new System.Drawing.Size(241, 16);
			this.Label1.Location = new System.Drawing.Point(3, 0);
			this.Label1.TabIndex = 4;
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
			this.lblKey.Text = "Label1";
			this.lblKey.Size = new System.Drawing.Size(86, 20);
			this.lblKey.Location = new System.Drawing.Point(6, 42);
			this.lblKey.TabIndex = 1;
			this.lblKey.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblKey.BackColor = System.Drawing.SystemColors.Control;
			this.lblKey.Enabled = true;
			this.lblKey.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblKey.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblKey.UseMnemonic = true;
			this.lblKey.Visible = true;
			this.lblKey.AutoSize = false;
			this.lblKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblKey.Name = "lblKey";
			this.Controls.Add(Command1);
			this.Controls.Add(cmdAccept);
			this.Controls.Add(Text1);
			this.Controls.Add(lblName);
			this.Controls.Add(Label1);
			this.Controls.Add(lblKey);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
