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
	partial class frmSerialNumber
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSerialNumber() : base()
		{
			Load += frmSerialNumber_Load;
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
		public System.Windows.Forms.TextBox txtRtd;
		public System.Windows.Forms.TextBox txtItem;
		public System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.TextBox withEventsField_txtQty;
		public System.Windows.Forms.TextBox txtQty {
			get { return withEventsField_txtQty; }
			set {
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.KeyPress -= txtQty_KeyPress;
				}
				withEventsField_txtQty = value;
				if (withEventsField_txtQty != null) {
					withEventsField_txtQty.KeyPress += txtQty_KeyPress;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemove;
		public System.Windows.Forms.Button cmdRemove {
			get { return withEventsField_cmdRemove; }
			set {
				if (withEventsField_cmdRemove != null) {
					withEventsField_cmdRemove.Click -= cmdRemove_Click;
				}
				withEventsField_cmdRemove = value;
				if (withEventsField_cmdRemove != null) {
					withEventsField_cmdRemove.Click += cmdRemove_Click;
				}
			}
		}
		public System.Windows.Forms.CheckedListBox lstSerial;
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtSerialNbr;
		public System.Windows.Forms.TextBox txtSerialNbr {
			get { return withEventsField_txtSerialNbr; }
			set {
				if (withEventsField_txtSerialNbr != null) {
					withEventsField_txtSerialNbr.KeyPress -= txtSerialNbr_KeyPress;
				}
				withEventsField_txtSerialNbr = value;
				if (withEventsField_txtSerialNbr != null) {
					withEventsField_txtSerialNbr.KeyPress += txtSerialNbr_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Button Command1;
		private System.Windows.Forms.Button withEventsField_cmdBack;
		public System.Windows.Forms.Button cmdBack {
			get { return withEventsField_cmdBack; }
			set {
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click -= cmdBack_Click;
				}
				withEventsField_cmdBack = value;
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click += cmdBack_Click;
				}
			}
		}
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Panel picButtons;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSerialNumber));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtRtd = new System.Windows.Forms.TextBox();
			this.txtItem = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdRemove = new System.Windows.Forms.Button();
			this.lstSerial = new System.Windows.Forms.CheckedListBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.txtSerialNbr = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.Frame1.SuspendLayout();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Serial Number Entry";
			this.ClientSize = new System.Drawing.Size(322, 457);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSerialNumber";
			this.Frame1.Size = new System.Drawing.Size(313, 415);
			this.Frame1.Location = new System.Drawing.Point(4, 40);
			this.Frame1.TabIndex = 2;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtRtd.AutoSize = false;
			this.txtRtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtRtd.Enabled = false;
			this.txtRtd.Size = new System.Drawing.Size(39, 19);
			this.txtRtd.Location = new System.Drawing.Point(262, 76);
			this.txtRtd.TabIndex = 17;
			this.txtRtd.AcceptsReturn = true;
			this.txtRtd.BackColor = System.Drawing.SystemColors.Window;
			this.txtRtd.CausesValidation = true;
			this.txtRtd.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRtd.HideSelection = true;
			this.txtRtd.ReadOnly = false;
			this.txtRtd.MaxLength = 0;
			this.txtRtd.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRtd.Multiline = false;
			this.txtRtd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRtd.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRtd.TabStop = true;
			this.txtRtd.Visible = true;
			this.txtRtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRtd.Name = "txtRtd";
			this.txtItem.AutoSize = false;
			this.txtItem.Size = new System.Drawing.Size(195, 19);
			this.txtItem.Location = new System.Drawing.Point(106, 16);
			this.txtItem.TabIndex = 15;
			this.txtItem.AcceptsReturn = true;
			this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtItem.BackColor = System.Drawing.SystemColors.Window;
			this.txtItem.CausesValidation = true;
			this.txtItem.Enabled = true;
			this.txtItem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtItem.HideSelection = true;
			this.txtItem.ReadOnly = false;
			this.txtItem.MaxLength = 0;
			this.txtItem.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtItem.Multiline = false;
			this.txtItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtItem.TabStop = true;
			this.txtItem.Visible = true;
			this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtItem.Name = "txtItem";
			this.txtCode.AutoSize = false;
			this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCode.Enabled = false;
			this.txtCode.Size = new System.Drawing.Size(39, 19);
			this.txtCode.Location = new System.Drawing.Point(106, 36);
			this.txtCode.TabIndex = 13;
			this.txtCode.AcceptsReturn = true;
			this.txtCode.BackColor = System.Drawing.SystemColors.Window;
			this.txtCode.CausesValidation = true;
			this.txtCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCode.HideSelection = true;
			this.txtCode.ReadOnly = false;
			this.txtCode.MaxLength = 0;
			this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCode.Multiline = false;
			this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCode.TabStop = true;
			this.txtCode.Visible = true;
			this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCode.Name = "txtCode";
			this.txtQty.AutoSize = false;
			this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQty.Enabled = false;
			this.txtQty.Size = new System.Drawing.Size(39, 19);
			this.txtQty.Location = new System.Drawing.Point(106, 76);
			this.txtQty.TabIndex = 10;
			this.txtQty.AcceptsReturn = true;
			this.txtQty.BackColor = System.Drawing.SystemColors.Window;
			this.txtQty.CausesValidation = true;
			this.txtQty.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQty.HideSelection = true;
			this.txtQty.ReadOnly = false;
			this.txtQty.MaxLength = 0;
			this.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQty.Multiline = false;
			this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQty.TabStop = true;
			this.txtQty.Visible = true;
			this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQty.Name = "txtQty";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(83, 21);
			this.cmdUpdate.Location = new System.Drawing.Point(226, 388);
			this.cmdUpdate.TabIndex = 9;
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemove.Text = "Remove";
			this.cmdRemove.Size = new System.Drawing.Size(83, 25);
			this.cmdRemove.Location = new System.Drawing.Point(226, 360);
			this.cmdRemove.TabIndex = 8;
			this.cmdRemove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemove.CausesValidation = true;
			this.cmdRemove.Enabled = true;
			this.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemove.TabStop = true;
			this.cmdRemove.Name = "cmdRemove";
			this.lstSerial.Size = new System.Drawing.Size(159, 238);
			this.lstSerial.Location = new System.Drawing.Point(4, 170);
			this.lstSerial.TabIndex = 6;
			this.lstSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSerial.BackColor = System.Drawing.SystemColors.Window;
			this.lstSerial.CausesValidation = true;
			this.lstSerial.Enabled = true;
			this.lstSerial.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSerial.IntegralHeight = true;
			this.lstSerial.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSerial.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSerial.Sorted = false;
			this.lstSerial.TabStop = true;
			this.lstSerial.Visible = true;
			this.lstSerial.MultiColumn = false;
			this.lstSerial.Name = "lstSerial";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(83, 23);
			this.cmdAdd.Location = new System.Drawing.Point(220, 122);
			this.cmdAdd.TabIndex = 5;
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.txtSerialNbr.AutoSize = false;
			this.txtSerialNbr.Size = new System.Drawing.Size(195, 19);
			this.txtSerialNbr.Location = new System.Drawing.Point(106, 98);
			this.txtSerialNbr.TabIndex = 4;
			this.txtSerialNbr.AcceptsReturn = true;
			this.txtSerialNbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSerialNbr.BackColor = System.Drawing.SystemColors.Window;
			this.txtSerialNbr.CausesValidation = true;
			this.txtSerialNbr.Enabled = true;
			this.txtSerialNbr.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSerialNbr.HideSelection = true;
			this.txtSerialNbr.ReadOnly = false;
			this.txtSerialNbr.MaxLength = 0;
			this.txtSerialNbr.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSerialNbr.Multiline = false;
			this.txtSerialNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSerialNbr.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSerialNbr.TabStop = true;
			this.txtSerialNbr.Visible = true;
			this.txtSerialNbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSerialNbr.Name = "txtSerialNbr";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.Label8.Text = "All Items that are being returned should be checked";
			this.Label8.Size = new System.Drawing.Size(141, 31);
			this.Label8.Location = new System.Drawing.Point(168, 170);
			this.Label8.TabIndex = 20;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.Label7.Text = "Returned";
			this.Label7.Size = new System.Drawing.Size(59, 17);
			this.Label7.Location = new System.Drawing.Point(202, 78);
			this.Label7.TabIndex = 19;
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label7.BackColor = System.Drawing.SystemColors.Control;
			this.Label7.Enabled = true;
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.Label6.Text = "Recieved";
			this.Label6.Size = new System.Drawing.Size(59, 17);
			this.Label6.Location = new System.Drawing.Point(44, 78);
			this.Label6.TabIndex = 18;
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.Label5.Text = "Item Name";
			this.Label5.Size = new System.Drawing.Size(83, 17);
			this.Label5.Location = new System.Drawing.Point(4, 18);
			this.Label5.TabIndex = 14;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label4.Text = "Item Code";
			this.Label4.Size = new System.Drawing.Size(93, 17);
			this.Label4.Location = new System.Drawing.Point(4, 38);
			this.Label4.TabIndex = 12;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label3.Text = "Quantity";
			this.Label3.Size = new System.Drawing.Size(71, 17);
			this.Label3.Location = new System.Drawing.Point(4, 58);
			this.Label3.TabIndex = 11;
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
			this.Line1.BorderWidth = 2;
			this.Line1.X1 = 4;
			this.Line1.X2 = 306;
			this.Line1.Y1 = 137;
			this.Line1.Y2 = 137;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this.Label2.Text = "List Of Serial Number";
			this.Label2.Size = new System.Drawing.Size(159, 17);
			this.Label2.Location = new System.Drawing.Point(4, 154);
			this.Label2.TabIndex = 7;
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
			this.Label1.Text = "Serial Number";
			this.Label1.Size = new System.Drawing.Size(91, 17);
			this.Label1.Location = new System.Drawing.Point(4, 100);
			this.Label1.TabIndex = 3;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(322, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 0;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "IMPORT >> ";
			this.Command1.Size = new System.Drawing.Size(91, 27);
			this.Command1.Location = new System.Drawing.Point(8, 4);
			this.Command1.TabIndex = 21;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "<< BACK ";
			this.cmdBack.Size = new System.Drawing.Size(91, 27);
			this.cmdBack.Location = new System.Drawing.Point(222, 4);
			this.cmdBack.TabIndex = 16;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.TabStop = true;
			this.cmdBack.Name = "cmdBack";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(576, 3);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.Controls.Add(Frame1);
			this.Controls.Add(picButtons);
			this.Frame1.Controls.Add(txtRtd);
			this.Frame1.Controls.Add(txtItem);
			this.Frame1.Controls.Add(txtCode);
			this.Frame1.Controls.Add(txtQty);
			this.Frame1.Controls.Add(cmdUpdate);
			this.Frame1.Controls.Add(cmdRemove);
			this.Frame1.Controls.Add(lstSerial);
			this.Frame1.Controls.Add(cmdAdd);
			this.Frame1.Controls.Add(txtSerialNbr);
			this.Frame1.Controls.Add(Label8);
			this.Frame1.Controls.Add(Label7);
			this.Frame1.Controls.Add(Label6);
			this.Frame1.Controls.Add(Label5);
			this.Frame1.Controls.Add(Label4);
			this.Frame1.Controls.Add(Label3);
			this.ShapeContainer1.Shapes.Add(Line1);
			this.Frame1.Controls.Add(Label2);
			this.Frame1.Controls.Add(Label1);
			this.Frame1.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(Command1);
			this.picButtons.Controls.Add(cmdBack);
			this.picButtons.Controls.Add(cmdClose);
			this.Frame1.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
