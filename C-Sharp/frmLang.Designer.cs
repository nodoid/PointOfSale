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
	partial class frmLang
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmLang() : base()
		{
			Load += frmLang_Load;
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
		public System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.RadioButton withEventsField_Option3;
		public System.Windows.Forms.RadioButton Option3 {
			get { return withEventsField_Option3; }
			set {
				if (withEventsField_Option3 != null) {
					withEventsField_Option3.CheckedChanged -= Option3_CheckedChanged;
				}
				withEventsField_Option3 = value;
				if (withEventsField_Option3 != null) {
					withEventsField_Option3.CheckedChanged += Option3_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Option2;
		public System.Windows.Forms.RadioButton Option2 {
			get { return withEventsField_Option2; }
			set {
				if (withEventsField_Option2 != null) {
					withEventsField_Option2.CheckedChanged -= Option2_CheckedChanged;
				}
				withEventsField_Option2 = value;
				if (withEventsField_Option2 != null) {
					withEventsField_Option2.CheckedChanged += Option2_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Option1;
		public System.Windows.Forms.RadioButton Option1 {
			get { return withEventsField_Option1; }
			set {
				if (withEventsField_Option1 != null) {
					withEventsField_Option1.CheckedChanged -= Option1_CheckedChanged;
				}
				withEventsField_Option1 = value;
				if (withEventsField_Option1 != null) {
					withEventsField_Option1.CheckedChanged += Option1_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		public System.Windows.Forms.Button cmdPrint;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel picButtons;
		public myDataGridView gridEdit;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLang));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtName = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Option3 = new System.Windows.Forms.RadioButton();
			this.Option2 = new System.Windows.Forms.RadioButton();
			this.Option1 = new System.Windows.Forms.RadioButton();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.gridEdit = new myDataGridView();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridEdit).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Language Translation Editor";
			this.ClientSize = new System.Drawing.Size(963, 663);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
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
			this.Name = "frmLang";
			this.txtName.AutoSize = false;
			this.txtName.Size = new System.Drawing.Size(301, 24);
			this.txtName.Location = new System.Drawing.Point(125, 48);
			this.txtName.TabIndex = 4;
			this.txtName.Text = "Text1";
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
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtName.Name = "txtName";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picButtons.Size = new System.Drawing.Size(963, 44);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 1;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picButtons.Name = "picButtons";
			this.Option3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Option3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Option3.Text = "Touch Screen";
			this.Option3.Size = new System.Drawing.Size(129, 29);
			this.Option3.Location = new System.Drawing.Point(448, 6);
			this.Option3.Appearance = System.Windows.Forms.Appearance.Button;
			this.Option3.TabIndex = 9;
			this.Option3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Option3.CausesValidation = true;
			this.Option3.Enabled = true;
			this.Option3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Option3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Option3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Option3.TabStop = true;
			this.Option3.Checked = false;
			this.Option3.Visible = true;
			this.Option3.Name = "Option3";
			this.Option2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Option2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Option2.Text = "Point of Sale";
			this.Option2.Size = new System.Drawing.Size(129, 29);
			this.Option2.Location = new System.Drawing.Point(312, 6);
			this.Option2.Appearance = System.Windows.Forms.Appearance.Button;
			this.Option2.TabIndex = 8;
			this.Option2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Option2.CausesValidation = true;
			this.Option2.Enabled = true;
			this.Option2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Option2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Option2.TabStop = true;
			this.Option2.Checked = false;
			this.Option2.Visible = true;
			this.Option2.Name = "Option2";
			this.Option1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Option1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Option1.Text = "Back Office";
			this.Option1.Size = new System.Drawing.Size(129, 29);
			this.Option1.Location = new System.Drawing.Point(176, 6);
			this.Option1.Appearance = System.Windows.Forms.Appearance.Button;
			this.Option1.TabIndex = 7;
			this.Option1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Option1.CausesValidation = true;
			this.Option1.Enabled = true;
			this.Option1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Option1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Option1.TabStop = true;
			this.Option1.Checked = false;
			this.Option1.Visible = true;
			this.Option1.Name = "Option1";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(880, 6);
			this.cmdClose.TabIndex = 3;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(798, 6);
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Visible = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.Label2.Text = "Show Translations for :";
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Size = new System.Drawing.Size(158, 21);
			this.Label2.Location = new System.Drawing.Point(16, 14);
			this.Label2.TabIndex = 6;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = true;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			//gridEdit.OcxState = CType(resources.GetObject("gridEdit.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridEdit.Size = new System.Drawing.Size(947, 582);
			this.gridEdit.Location = new System.Drawing.Point(9, 75);
			this.gridEdit.TabIndex = 0;
			this.gridEdit.Name = "gridEdit";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Lanuage Name:";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Size = new System.Drawing.Size(110, 16);
			this.Label1.Location = new System.Drawing.Point(13, 51);
			this.Label1.TabIndex = 5;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(txtName);
			this.Controls.Add(picButtons);
			this.Controls.Add(gridEdit);
			this.Controls.Add(Label1);
			this.picButtons.Controls.Add(Option3);
			this.picButtons.Controls.Add(Option2);
			this.picButtons.Controls.Add(Option1);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(Label2);
			((System.ComponentModel.ISupportInitialize)this.gridEdit).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
