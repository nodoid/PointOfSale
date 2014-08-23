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
	partial class frmNewDenomination
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmNewDenomination() : base()
		{
			Load += frmNewDenomination_Load;
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
		private System.Windows.Forms.TextBox withEventsField_txtUnit;
		public System.Windows.Forms.TextBox txtUnit {
			get { return withEventsField_txtUnit; }
			set {
				if (withEventsField_txtUnit != null) {
					withEventsField_txtUnit.Enter -= txtUnit_Enter;
					withEventsField_txtUnit.KeyPress -= txtUnit_KeyPress;
					withEventsField_txtUnit.Leave -= txtUnit_Leave;
				}
				withEventsField_txtUnit = value;
				if (withEventsField_txtUnit != null) {
					withEventsField_txtUnit.Enter += txtUnit_Enter;
					withEventsField_txtUnit.KeyPress += txtUnit_KeyPress;
					withEventsField_txtUnit.Leave += txtUnit_Leave;
				}
			}
		}
		public System.Windows.Forms.CheckBox Check1;
		public System.Windows.Forms.RadioButton _optCoin_1;
		public System.Windows.Forms.RadioButton _optCoin_0;
		private System.Windows.Forms.TextBox withEventsField_txtPack;
		public System.Windows.Forms.TextBox txtPack {
			get { return withEventsField_txtPack; }
			set {
				if (withEventsField_txtPack != null) {
					withEventsField_txtPack.Enter -= txtPack_Enter;
					withEventsField_txtPack.KeyPress -= txtPack_KeyPress;
					withEventsField_txtPack.Leave -= txtPack_Leave;
				}
				withEventsField_txtPack = value;
				if (withEventsField_txtPack != null) {
					withEventsField_txtPack.Enter += txtPack_Enter;
					withEventsField_txtPack.KeyPress += txtPack_KeyPress;
					withEventsField_txtPack.Leave += txtPack_Leave;
				}
			}
		}
		public System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button withEventsField_Command2;
		public System.Windows.Forms.Button Command2 {
			get { return withEventsField_Command2; }
			set {
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click -= Command2_Click;
				}
				withEventsField_Command2 = value;
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click += Command2_Click;
				}
			}
		}
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		//Public WithEvents optCoin As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNewDenomination));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.Check1 = new System.Windows.Forms.CheckBox();
			this._optCoin_1 = new System.Windows.Forms.RadioButton();
			this._optCoin_0 = new System.Windows.Forms.RadioButton();
			this.txtPack = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Command2 = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.optCoin = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.optCoin, System.ComponentModel.ISupportInitialize).BeginInit()
			this.Text = "New Denomination";
			this.ClientSize = new System.Drawing.Size(234, 157);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmNewDenomination";
			this.txtUnit.AutoSize = false;
			this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtUnit.Size = new System.Drawing.Size(81, 19);
			this.txtUnit.Location = new System.Drawing.Point(146, 66);
			this.txtUnit.TabIndex = 1;
			this.txtUnit.Text = "0";
			this.txtUnit.AcceptsReturn = true;
			this.txtUnit.BackColor = System.Drawing.SystemColors.Window;
			this.txtUnit.CausesValidation = true;
			this.txtUnit.Enabled = true;
			this.txtUnit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUnit.HideSelection = true;
			this.txtUnit.ReadOnly = false;
			this.txtUnit.MaxLength = 0;
			this.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUnit.Multiline = false;
			this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUnit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUnit.TabStop = true;
			this.txtUnit.Visible = true;
			this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUnit.Name = "txtUnit";
			this.Check1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Check1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Check1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.Check1.Text = "Disable Denominations";
			this.Check1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Check1.Size = new System.Drawing.Size(223, 17);
			this.Check1.Location = new System.Drawing.Point(2, 134);
			this.Check1.TabIndex = 10;
			this.Check1.CausesValidation = true;
			this.Check1.Enabled = true;
			this.Check1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check1.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check1.TabStop = true;
			this.Check1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check1.Visible = true;
			this.Check1.Name = "Check1";
			this._optCoin_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCoin_1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this._optCoin_1.Text = "Note";
			this._optCoin_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._optCoin_1.Size = new System.Drawing.Size(59, 15);
			this._optCoin_1.Location = new System.Drawing.Point(166, 114);
			this._optCoin_1.TabIndex = 9;
			this._optCoin_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCoin_1.CausesValidation = true;
			this._optCoin_1.Enabled = true;
			this._optCoin_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optCoin_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCoin_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCoin_1.TabStop = true;
			this._optCoin_1.Checked = false;
			this._optCoin_1.Visible = true;
			this._optCoin_1.Name = "_optCoin_1";
			this._optCoin_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCoin_0.BackColor = System.Drawing.SystemColors.ScrollBar;
			this._optCoin_0.Text = "Coin";
			this._optCoin_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._optCoin_0.Size = new System.Drawing.Size(51, 15);
			this._optCoin_0.Location = new System.Drawing.Point(94, 114);
			this._optCoin_0.TabIndex = 8;
			this._optCoin_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCoin_0.CausesValidation = true;
			this._optCoin_0.Enabled = true;
			this._optCoin_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optCoin_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCoin_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCoin_0.TabStop = true;
			this._optCoin_0.Checked = false;
			this._optCoin_0.Visible = true;
			this._optCoin_0.Name = "_optCoin_0";
			this.txtPack.AutoSize = false;
			this.txtPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPack.Size = new System.Drawing.Size(81, 17);
			this.txtPack.Location = new System.Drawing.Point(146, 92);
			this.txtPack.TabIndex = 2;
			this.txtPack.Text = "0";
			this.txtPack.AcceptsReturn = true;
			this.txtPack.BackColor = System.Drawing.SystemColors.Window;
			this.txtPack.CausesValidation = true;
			this.txtPack.Enabled = true;
			this.txtPack.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPack.HideSelection = true;
			this.txtPack.ReadOnly = false;
			this.txtPack.MaxLength = 0;
			this.txtPack.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPack.Multiline = false;
			this.txtPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPack.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPack.TabStop = true;
			this.txtPack.Visible = true;
			this.txtPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPack.Name = "txtPack";
			this.txtName.AutoSize = false;
			this.txtName.Size = new System.Drawing.Size(137, 17);
			this.txtName.Location = new System.Drawing.Point(92, 44);
			this.txtName.TabIndex = 0;
			this.txtName.AcceptsReturn = true;
			this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtName.BackColor = System.Drawing.SystemColors.Window;
			this.txtName.CausesValidation = true;
			this.txtName.Enabled = true;
			this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtName.HideSelection = true;
			this.txtName.ReadOnly = false;
			this.txtName.MaxLength = 0;
			this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtName.Multiline = false;
			this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtName.TabStop = true;
			this.txtName.Visible = true;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Name = "txtName";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(234, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 3;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "&Undo";
			this.Command2.Size = new System.Drawing.Size(85, 25);
			this.Command2.Location = new System.Drawing.Point(4, 4);
			this.Command2.TabIndex = 12;
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "E&xit";
			this.Command1.Size = new System.Drawing.Size(87, 25);
			this.Command1.Location = new System.Drawing.Point(140, 4);
			this.Command1.TabIndex = 4;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.Label4.Text = "Unit/Amount:";
			this.Label4.Size = new System.Drawing.Size(77, 15);
			this.Label4.Location = new System.Drawing.Point(4, 68);
			this.Label4.TabIndex = 11;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label3.Text = "Type :";
			this.Label3.Size = new System.Drawing.Size(83, 15);
			this.Label3.Location = new System.Drawing.Point(4, 114);
			this.Label3.TabIndex = 7;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.Text = "Pack :";
			this.Label2.Size = new System.Drawing.Size(83, 15);
			this.Label2.Location = new System.Drawing.Point(4, 94);
			this.Label2.TabIndex = 6;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Name :";
			this.Label1.Size = new System.Drawing.Size(83, 15);
			this.Label1.Location = new System.Drawing.Point(4, 46);
			this.Label1.TabIndex = 5;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(txtUnit);
			this.Controls.Add(Check1);
			this.Controls.Add(_optCoin_1);
			this.Controls.Add(_optCoin_0);
			this.Controls.Add(txtPack);
			this.Controls.Add(txtName);
			this.Controls.Add(picButtons);
			this.Controls.Add(Label4);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.picButtons.Controls.Add(Command2);
			this.picButtons.Controls.Add(Command1);
			//Me.optCoin.SetIndex(_optCoin_1, CType(1, Short))
			//Me.optCoin.SetIndex(_optCoin_0, CType(0, Short))
			//CType(Me.optCoin, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
