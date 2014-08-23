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
	partial class frmStockTakeCSV
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockTakeCSV() : base()
		{
			Load += frmStockTakeCSV_Load;
			KeyPress += frmStockTakeCSV_KeyPress;
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
		public System.Windows.Forms.PictureBox picBC;
		private System.Windows.Forms.CheckBox withEventsField_chkPic;
		public System.Windows.Forms.CheckBox chkPic {
			get { return withEventsField_chkPic; }
			set {
				if (withEventsField_chkPic != null) {
					withEventsField_chkPic.CheckStateChanged -= chkPic_CheckStateChanged;
				}
				withEventsField_chkPic = value;
				if (withEventsField_chkPic != null) {
					withEventsField_chkPic.CheckStateChanged += chkPic_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDiff;
		public System.Windows.Forms.Button cmdDiff {
			get { return withEventsField_cmdDiff; }
			set {
				if (withEventsField_cmdDiff != null) {
					withEventsField_cmdDiff.Click -= cmdDiff_Click;
				}
				withEventsField_cmdDiff = value;
				if (withEventsField_cmdDiff != null) {
					withEventsField_cmdDiff.Click += cmdDiff_Click;
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
		public System.Windows.Forms.Panel picButtons;
		private System.Windows.Forms.Button withEventsField_cmdsearch;
		public System.Windows.Forms.Button cmdsearch {
			get { return withEventsField_cmdsearch; }
			set {
				if (withEventsField_cmdsearch != null) {
					withEventsField_cmdsearch.Click -= cmdsearch_Click;
				}
				withEventsField_cmdsearch = value;
				if (withEventsField_cmdsearch != null) {
					withEventsField_cmdsearch.Click += cmdsearch_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtqty;
		public System.Windows.Forms.TextBox txtdesc;
		public System.Windows.Forms.TextBox txtcode;
		public System.Windows.Forms.DataGrid DataGrid1;
		public System.Windows.Forms.PictureBox imgBC;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockTakeCSV));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picBC = new System.Windows.Forms.PictureBox();
			this.chkPic = new System.Windows.Forms.CheckBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdDiff = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdsearch = new System.Windows.Forms.Button();
			this.txtqty = new System.Windows.Forms.TextBox();
			this.txtdesc = new System.Windows.Forms.TextBox();
			this.txtcode = new System.Windows.Forms.TextBox();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.imgBC = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataGrid1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "StockTake";
			this.ClientSize = new System.Drawing.Size(570, 390);
			this.Location = new System.Drawing.Point(3, 29);
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmStockTakeCSV.Icon");
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockTakeCSV";
			this.picBC.Size = new System.Drawing.Size(265, 300);
			this.picBC.Location = new System.Drawing.Point(576, 472);
			this.picBC.TabIndex = 11;
			this.picBC.Visible = false;
			this.picBC.Dock = System.Windows.Forms.DockStyle.None;
			this.picBC.BackColor = System.Drawing.SystemColors.Control;
			this.picBC.CausesValidation = true;
			this.picBC.Enabled = true;
			this.picBC.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picBC.Cursor = System.Windows.Forms.Cursors.Default;
			this.picBC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picBC.TabStop = true;
			this.picBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picBC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBC.Name = "picBC";
			this.chkPic.Text = "Show Pictures";
			this.chkPic.Size = new System.Drawing.Size(89, 17);
			this.chkPic.Location = new System.Drawing.Point(472, 360);
			this.chkPic.TabIndex = 10;
			this.chkPic.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPic.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkPic.BackColor = System.Drawing.SystemColors.Control;
			this.chkPic.CausesValidation = true;
			this.chkPic.Enabled = true;
			this.chkPic.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPic.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPic.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPic.TabStop = true;
			this.chkPic.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPic.Visible = true;
			this.chkPic.Name = "chkPic";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(570, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 7;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDiff.Text = "Show Difference";
			this.cmdDiff.Size = new System.Drawing.Size(97, 29);
			this.cmdDiff.Location = new System.Drawing.Point(360, 2);
			this.cmdDiff.TabIndex = 12;
			this.cmdDiff.TabStop = false;
			this.cmdDiff.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDiff.CausesValidation = true;
			this.cmdDiff.Enabled = true;
			this.cmdDiff.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDiff.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDiff.Name = "cmdDiff";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Save and E&xit";
			this.cmdClose.Size = new System.Drawing.Size(89, 29);
			this.cmdClose.Location = new System.Drawing.Point(472, 2);
			this.cmdClose.TabIndex = 8;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.cmdsearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdsearch.Text = "&Search";
			this.AcceptButton = this.cmdsearch;
			this.cmdsearch.Size = new System.Drawing.Size(89, 33);
			this.cmdsearch.Location = new System.Drawing.Point(8, 352);
			this.cmdsearch.TabIndex = 3;
			this.cmdsearch.BackColor = System.Drawing.SystemColors.Control;
			this.cmdsearch.CausesValidation = true;
			this.cmdsearch.Enabled = true;
			this.cmdsearch.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdsearch.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdsearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdsearch.TabStop = true;
			this.cmdsearch.Name = "cmdsearch";
			this.txtqty.AutoSize = false;
			this.txtqty.Size = new System.Drawing.Size(89, 25);
			this.txtqty.Location = new System.Drawing.Point(472, 48);
			this.txtqty.TabIndex = 2;
			this.txtqty.AcceptsReturn = true;
			this.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtqty.BackColor = System.Drawing.SystemColors.Window;
			this.txtqty.CausesValidation = true;
			this.txtqty.Enabled = true;
			this.txtqty.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtqty.HideSelection = true;
			this.txtqty.ReadOnly = false;
			this.txtqty.MaxLength = 0;
			this.txtqty.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtqty.Multiline = false;
			this.txtqty.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtqty.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtqty.TabStop = true;
			this.txtqty.Visible = true;
			this.txtqty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtqty.Name = "txtqty";
			this.txtdesc.AutoSize = false;
			this.txtdesc.Enabled = false;
			this.txtdesc.Size = new System.Drawing.Size(153, 25);
			this.txtdesc.Location = new System.Drawing.Point(272, 48);
			this.txtdesc.TabIndex = 1;
			this.txtdesc.AcceptsReturn = true;
			this.txtdesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtdesc.BackColor = System.Drawing.SystemColors.Window;
			this.txtdesc.CausesValidation = true;
			this.txtdesc.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtdesc.HideSelection = true;
			this.txtdesc.ReadOnly = false;
			this.txtdesc.MaxLength = 0;
			this.txtdesc.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtdesc.Multiline = false;
			this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtdesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtdesc.TabStop = true;
			this.txtdesc.Visible = true;
			this.txtdesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtdesc.Name = "txtdesc";
			this.txtcode.AutoSize = false;
			this.txtcode.Size = new System.Drawing.Size(89, 25);
			this.txtcode.Location = new System.Drawing.Point(88, 48);
			this.txtcode.TabIndex = 0;
			this.txtcode.AcceptsReturn = true;
			this.txtcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtcode.BackColor = System.Drawing.SystemColors.Window;
			this.txtcode.CausesValidation = true;
			this.txtcode.Enabled = true;
			this.txtcode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtcode.HideSelection = true;
			this.txtcode.ReadOnly = false;
			this.txtcode.MaxLength = 0;
			this.txtcode.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtcode.Multiline = false;
			this.txtcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtcode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtcode.TabStop = true;
			this.txtcode.Visible = true;
			this.txtcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtcode.Name = "txtcode";
			//DataGrid1.OcxState = CType(resources.GetObject("DataGrid1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataGrid1.Size = new System.Drawing.Size(553, 257);
			this.DataGrid1.Location = new System.Drawing.Point(8, 88);
			this.DataGrid1.TabIndex = 9;
			this.DataGrid1.Name = "DataGrid1";
			this.imgBC.Size = new System.Drawing.Size(265, 300);
			this.imgBC.Location = new System.Drawing.Point(568, 48);
			this.imgBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBC.Visible = false;
			this.imgBC.Enabled = true;
			this.imgBC.Cursor = System.Windows.Forms.Cursors.Default;
			this.imgBC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.imgBC.Name = "imgBC";
			this.Label3.Text = "Qty";
			this.Label3.Size = new System.Drawing.Size(33, 17);
			this.Label3.Location = new System.Drawing.Point(432, 56);
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
			this.Label2.Text = "Description";
			this.Label2.Size = new System.Drawing.Size(81, 25);
			this.Label2.Location = new System.Drawing.Point(184, 56);
			this.Label2.TabIndex = 5;
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
			this.Label1.Text = "Barcode";
			this.Label1.Size = new System.Drawing.Size(81, 25);
			this.Label1.Location = new System.Drawing.Point(8, 56);
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
			this.Controls.Add(picBC);
			this.Controls.Add(chkPic);
			this.Controls.Add(picButtons);
			this.Controls.Add(cmdsearch);
			this.Controls.Add(txtqty);
			this.Controls.Add(txtdesc);
			this.Controls.Add(txtcode);
			this.Controls.Add(DataGrid1);
			this.Controls.Add(imgBC);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.picButtons.Controls.Add(cmdDiff);
			this.picButtons.Controls.Add(cmdClose);
			((System.ComponentModel.ISupportInitialize)this.DataGrid1).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
