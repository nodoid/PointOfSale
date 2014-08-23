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
	partial class frmKeyboard
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmKeyboard() : base()
		{
			Load += frmKeyboard_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		private myDataGridView withEventsField_gridEdit;
		public myDataGridView gridEdit {
			get { return withEventsField_gridEdit; }
			set {
				if (withEventsField_gridEdit != null) {
					withEventsField_gridEdit.Click -= gridEdit_ClickEvent;
				}
				withEventsField_gridEdit = value;
				if (withEventsField_gridEdit != null) {
					withEventsField_gridEdit.Click += gridEdit_ClickEvent;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmKeyboard));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtName = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.gridEdit = new myDataGridView();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridEdit).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Keyboard Layout Editor";
			this.ClientSize = new System.Drawing.Size(434, 611);
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
			this.Name = "frmKeyboard";
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
			this.picButtons.Size = new System.Drawing.Size(434, 44);
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
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(352, 6);
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
			this.cmdPrint.Location = new System.Drawing.Point(270, 6);
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			//gridEdit.OcxState = CType(resources.GetObject("gridEdit.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridEdit.Size = new System.Drawing.Size(419, 526);
			this.gridEdit.Location = new System.Drawing.Point(9, 75);
			this.gridEdit.TabIndex = 0;
			this.gridEdit.Name = "gridEdit";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Keyboard Name:";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Size = new System.Drawing.Size(117, 16);
			this.Label1.Location = new System.Drawing.Point(6, 51);
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
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdPrint);
			((System.ComponentModel.ISupportInitialize)this.gridEdit).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
