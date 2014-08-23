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
	partial class frmBarcodeLoad
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBarcodeLoad() : base()
		{
			FormClosed += frmBarcodeLoad_FormClosed;
			Load += frmBarcodeLoad_Load;
			KeyPress += frmBarcodeLoad_KeyPress;
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
		public System.Windows.Forms.RadioButton _Option1_11;
		public System.Windows.Forms.RadioButton _Option1_10;
		public System.Windows.Forms.RadioButton _Option1_9;
		public System.Windows.Forms.RadioButton _Option1_8;
		public System.Windows.Forms.RadioButton _Option1_7;
		public System.Windows.Forms.RadioButton _Option1_6;
		public System.Windows.Forms.RadioButton _Option1_5;
		public System.Windows.Forms.RadioButton _Option1_4;
		public System.Windows.Forms.RadioButton _Option1_3;
		public System.Windows.Forms.RadioButton _Option1_2;
		public System.Windows.Forms.RadioButton _Option1_1;
		public System.Windows.Forms.RadioButton _Option1_0;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.CheckBox _chkFields_0;
		public System.Windows.Forms.CheckBox _chkFields_1;
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.CheckBox _chkFields_3;
		public System.Windows.Forms.CheckBox _chkFields_4;
		public System.Windows.Forms.CheckBox _chkFields_5;
		private System.Windows.Forms.TextBox withEventsField_txtpos;
		public System.Windows.Forms.TextBox txtpos {
			get { return withEventsField_txtpos; }
			set {
				if (withEventsField_txtpos != null) {
					withEventsField_txtpos.Leave -= txtpos_Leave;
				}
				withEventsField_txtpos = value;
				if (withEventsField_txtpos != null) {
					withEventsField_txtpos.Leave += txtpos_Leave;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cmbfont;
		public System.Windows.Forms.ComboBox cmbfont {
			get { return withEventsField_cmbfont; }
			set {
				if (withEventsField_cmbfont != null) {
					withEventsField_cmbfont.Leave -= cmbfont_Leave;
				}
				withEventsField_cmbfont = value;
				if (withEventsField_cmbfont != null) {
					withEventsField_cmbfont.Leave += cmbfont_Leave;
				}
			}
		}
		public System.Windows.Forms.RadioButton _Option2_2;
		public System.Windows.Forms.RadioButton _Option2_1;
		public System.Windows.Forms.RadioButton _Option2_0;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.GroupBox frmDeposits;
		private System.Windows.Forms.HScrollBar withEventsField_HSLeft;
		public System.Windows.Forms.HScrollBar HSLeft {
			get { return withEventsField_HSLeft; }
			set {
				if (withEventsField_HSLeft != null) {
					withEventsField_HSLeft.Scroll -= HSLeft_Scroll;
				}
				withEventsField_HSLeft = value;
				if (withEventsField_HSLeft != null) {
					withEventsField_HSLeft.Scroll += HSLeft_Scroll;
				}
			}
		}
		private System.Windows.Forms.HScrollBar withEventsField_HSTop;
		public System.Windows.Forms.HScrollBar HSTop {
			get { return withEventsField_HSTop; }
			set {
				if (withEventsField_HSTop != null) {
					withEventsField_HSTop.Scroll -= HSTop_Scroll;
				}
				withEventsField_HSTop = value;
				if (withEventsField_HSTop != null) {
					withEventsField_HSTop.Scroll += HSTop_Scroll;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdundo;
		public System.Windows.Forms.Button cmdundo {
			get { return withEventsField_cmdundo; }
			set {
				if (withEventsField_cmdundo != null) {
					withEventsField_cmdundo.Click -= cmdUndo_Click;
				}
				withEventsField_cmdundo = value;
				if (withEventsField_cmdundo != null) {
					withEventsField_cmdundo.Click += cmdUndo_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdnormal;
		public System.Windows.Forms.Button cmdnormal {
			get { return withEventsField_cmdnormal; }
			set {
				if (withEventsField_cmdnormal != null) {
					withEventsField_cmdnormal.Click -= cmdnormal_Click;
				}
				withEventsField_cmdnormal = value;
				if (withEventsField_cmdnormal != null) {
					withEventsField_cmdnormal.Click += cmdnormal_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbpos;
		private System.Windows.Forms.Button withEventsField_cmdadd;
		public System.Windows.Forms.Button cmdadd {
			get { return withEventsField_cmdadd; }
			set {
				if (withEventsField_cmdadd != null) {
					withEventsField_cmdadd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdadd = value;
				if (withEventsField_cmdadd != null) {
					withEventsField_cmdadd.Click += cmdAdd_Click;
				}
			}
		}
		public System.Windows.Forms.OpenFileDialog cmdDlgOpen;
		public System.Windows.Forms.SaveFileDialog cmdDlgSave;
		public System.Windows.Forms.FontDialog cmdDlgFont;
		public System.Windows.Forms.ColorDialog cmdDlgColor;
		public System.Windows.Forms.PrintDialog cmdDlgPrint;
		private System.Windows.Forms.Button withEventsField_cmdSave;
		public System.Windows.Forms.Button cmdSave {
			get { return withEventsField_cmdSave; }
			set {
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click -= cmdSave_Click;
				}
				withEventsField_cmdSave = value;
				if (withEventsField_cmdSave != null) {
					withEventsField_cmdSave.Click += cmdSave_Click;
				}
			}
		}
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
		private System.Windows.Forms.HScrollBar withEventsField_HSHeight;
		public System.Windows.Forms.HScrollBar HSHeight {
			get { return withEventsField_HSHeight; }
			set {
				if (withEventsField_HSHeight != null) {
					withEventsField_HSHeight.Scroll -= HSHeight_Scroll;
				}
				withEventsField_HSHeight = value;
				if (withEventsField_HSHeight != null) {
					withEventsField_HSHeight.Scroll += HSHeight_Scroll;
				}
			}
		}
		private System.Windows.Forms.HScrollBar withEventsField_HSselect;
		public System.Windows.Forms.HScrollBar HSselect {
			get { return withEventsField_HSselect; }
			set {
				if (withEventsField_HSselect != null) {
					withEventsField_HSselect.Scroll -= HSselect_Scroll;
				}
				withEventsField_HSselect = value;
				if (withEventsField_HSselect != null) {
					withEventsField_HSselect.Scroll += HSselect_Scroll;
				}
			}
		}
		public System.Windows.Forms.PictureBox _picSelect_0;
		public System.Windows.Forms.Panel picInner;
		public System.Windows.Forms.Panel picOuter;
		private System.Windows.Forms.HScrollBar withEventsField_HSWidth;
		public System.Windows.Forms.HScrollBar HSWidth {
			get { return withEventsField_HSWidth; }
			set {
				if (withEventsField_HSWidth != null) {
					withEventsField_HSWidth.Scroll -= HSWidth_Scroll;
				}
				withEventsField_HSWidth = value;
				if (withEventsField_HSWidth != null) {
					withEventsField_HSWidth.Scroll += HSWidth_Scroll;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label lblLeft;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label lblTop;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label lblLineNo;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblWidth;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label lblHeight;
		public System.Windows.Forms.Label lbldesign;
		//Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents Option2 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents picSelect As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarcodeLoad));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._Option1_11 = new System.Windows.Forms.RadioButton();
			this._Option1_10 = new System.Windows.Forms.RadioButton();
			this._Option1_9 = new System.Windows.Forms.RadioButton();
			this._Option1_8 = new System.Windows.Forms.RadioButton();
			this._Option1_7 = new System.Windows.Forms.RadioButton();
			this._Option1_6 = new System.Windows.Forms.RadioButton();
			this._Option1_5 = new System.Windows.Forms.RadioButton();
			this._Option1_4 = new System.Windows.Forms.RadioButton();
			this._Option1_3 = new System.Windows.Forms.RadioButton();
			this._Option1_2 = new System.Windows.Forms.RadioButton();
			this._Option1_1 = new System.Windows.Forms.RadioButton();
			this._Option1_0 = new System.Windows.Forms.RadioButton();
			this.frmDeposits = new System.Windows.Forms.GroupBox();
			this._chkFields_4 = new System.Windows.Forms.CheckBox();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this.txtpos = new System.Windows.Forms.TextBox();
			this.cmbfont = new System.Windows.Forms.ComboBox();
			this._Option2_2 = new System.Windows.Forms.RadioButton();
			this._Option2_1 = new System.Windows.Forms.RadioButton();
			this._Option2_0 = new System.Windows.Forms.RadioButton();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._chkFields_3 = new System.Windows.Forms.CheckBox();
			this._chkFields_5 = new System.Windows.Forms.CheckBox();
			this.HSLeft = new System.Windows.Forms.HScrollBar();
			this.HSTop = new System.Windows.Forms.HScrollBar();
			this.cmdundo = new System.Windows.Forms.Button();
			this.cmdnormal = new System.Windows.Forms.Button();
			this.cmbpos = new System.Windows.Forms.ComboBox();
			this.cmdadd = new System.Windows.Forms.Button();
			this.cmdDlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.cmdDlgSave = new System.Windows.Forms.SaveFileDialog();
			this.cmdDlgFont = new System.Windows.Forms.FontDialog();
			this.cmdDlgColor = new System.Windows.Forms.ColorDialog();
			this.cmdDlgPrint = new System.Windows.Forms.PrintDialog();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.HSHeight = new System.Windows.Forms.HScrollBar();
			this.HSselect = new System.Windows.Forms.HScrollBar();
			this.picOuter = new System.Windows.Forms.Panel();
			this.picInner = new System.Windows.Forms.Panel();
			this._picSelect_0 = new System.Windows.Forms.PictureBox();
			this.HSWidth = new System.Windows.Forms.HScrollBar();
			this._lbl_7 = new System.Windows.Forms.Label();
			this.lblLeft = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.lblTop = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.lblLineNo = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.lbldesign = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.frmDeposits.SuspendLayout();
			this.picOuter.SuspendLayout();
			this.picInner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this._picSelect_0).BeginInit();
			this.SuspendLayout();
			//
			//Frame1
			//
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Frame1.Controls.Add(this._Option1_11);
			this.Frame1.Controls.Add(this._Option1_10);
			this.Frame1.Controls.Add(this._Option1_9);
			this.Frame1.Controls.Add(this._Option1_8);
			this.Frame1.Controls.Add(this._Option1_7);
			this.Frame1.Controls.Add(this._Option1_6);
			this.Frame1.Controls.Add(this._Option1_5);
			this.Frame1.Controls.Add(this._Option1_4);
			this.Frame1.Controls.Add(this._Option1_3);
			this.Frame1.Controls.Add(this._Option1_2);
			this.Frame1.Controls.Add(this._Option1_1);
			this.Frame1.Controls.Add(this._Option1_0);
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(568, 24);
			this.Frame1.Name = "Frame1";
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(142, 300);
			this.Frame1.TabIndex = 41;
			this.Frame1.TabStop = false;
			this.Frame1.Text = "Select Field to Format";
			//
			//_Option1_11
			//
			this._Option1_11.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_11.Location = new System.Drawing.Point(8, 280);
			this._Option1_11.Name = "_Option1_11";
			this._Option1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_11.Size = new System.Drawing.Size(129, 17);
			this._Option1_11.TabIndex = 53;
			this._Option1_11.TabStop = true;
			this._Option1_11.Text = "&Price for   24:";
			this._Option1_11.UseVisualStyleBackColor = false;
			//
			//_Option1_10
			//
			this._Option1_10.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_10.Location = new System.Drawing.Point(8, 256);
			this._Option1_10.Name = "_Option1_10";
			this._Option1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_10.Size = new System.Drawing.Size(129, 17);
			this._Option1_10.TabIndex = 52;
			this._Option1_10.TabStop = true;
			this._Option1_10.Text = "&Price for   12:";
			this._Option1_10.UseVisualStyleBackColor = false;
			//
			//_Option1_9
			//
			this._Option1_9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_9.Location = new System.Drawing.Point(8, 232);
			this._Option1_9.Name = "_Option1_9";
			this._Option1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_9.Size = new System.Drawing.Size(129, 17);
			this._Option1_9.TabIndex = 51;
			this._Option1_9.TabStop = true;
			this._Option1_9.Text = "&Price for    6:";
			this._Option1_9.UseVisualStyleBackColor = false;
			//
			//_Option1_8
			//
			this._Option1_8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_8.Location = new System.Drawing.Point(8, 184);
			this._Option1_8.Name = "_Option1_8";
			this._Option1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_8.Size = new System.Drawing.Size(129, 17);
			this._Option1_8.TabIndex = 50;
			this._Option1_8.TabStop = true;
			this._Option1_8.Text = "Blan&k";
			this._Option1_8.UseVisualStyleBackColor = false;
			//
			//_Option1_7
			//
			this._Option1_7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_7.Location = new System.Drawing.Point(8, 160);
			this._Option1_7.Name = "_Option1_7";
			this._Option1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_7.Size = new System.Drawing.Size(129, 17);
			this._Option1_7.TabIndex = 49;
			this._Option1_7.TabStop = true;
			this._Option1_7.Text = "Bar&code:";
			this._Option1_7.UseVisualStyleBackColor = false;
			//
			//_Option1_6
			//
			this._Option1_6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_6.Location = new System.Drawing.Point(8, 136);
			this._Option1_6.Name = "_Option1_6";
			this._Option1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_6.Size = new System.Drawing.Size(129, 17);
			this._Option1_6.TabIndex = 48;
			this._Option1_6.TabStop = true;
			this._Option1_6.Text = "&Line:";
			this._Option1_6.UseVisualStyleBackColor = false;
			//
			//_Option1_5
			//
			this._Option1_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_5.Location = new System.Drawing.Point(8, 112);
			this._Option1_5.Name = "_Option1_5";
			this._Option1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_5.Size = new System.Drawing.Size(129, 17);
			this._Option1_5.TabIndex = 47;
			this._Option1_5.TabStop = true;
			this._Option1_5.Text = "&Group:";
			this._Option1_5.UseVisualStyleBackColor = false;
			//
			//_Option1_4
			//
			this._Option1_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_4.Location = new System.Drawing.Point(8, 208);
			this._Option1_4.Name = "_Option1_4";
			this._Option1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_4.Size = new System.Drawing.Size(129, 17);
			this._Option1_4.TabIndex = 46;
			this._Option1_4.TabStop = true;
			this._Option1_4.Text = "&Price for   1:";
			this._Option1_4.UseVisualStyleBackColor = false;
			//
			//_Option1_3
			//
			this._Option1_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_3.Location = new System.Drawing.Point(8, 88);
			this._Option1_3.Name = "_Option1_3";
			this._Option1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_3.Size = new System.Drawing.Size(129, 17);
			this._Option1_3.TabIndex = 45;
			this._Option1_3.TabStop = true;
			this._Option1_3.Text = "&Telephone:";
			this._Option1_3.UseVisualStyleBackColor = false;
			//
			//_Option1_2
			//
			this._Option1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_2.Location = new System.Drawing.Point(8, 64);
			this._Option1_2.Name = "_Option1_2";
			this._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_2.Size = new System.Drawing.Size(129, 17);
			this._Option1_2.TabIndex = 44;
			this._Option1_2.TabStop = true;
			this._Option1_2.Text = "Barcode &No:";
			this._Option1_2.UseVisualStyleBackColor = false;
			//
			//_Option1_1
			//
			this._Option1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_1.Location = new System.Drawing.Point(8, 40);
			this._Option1_1.Name = "_Option1_1";
			this._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_1.Size = new System.Drawing.Size(129, 17);
			this._Option1_1.TabIndex = 43;
			this._Option1_1.TabStop = true;
			this._Option1_1.Text = "Stock &Item Name:";
			this._Option1_1.UseVisualStyleBackColor = false;
			//
			//_Option1_0
			//
			this._Option1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_0.Location = new System.Drawing.Point(8, 16);
			this._Option1_0.Name = "_Option1_0";
			this._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_0.Size = new System.Drawing.Size(129, 17);
			this._Option1_0.TabIndex = 42;
			this._Option1_0.TabStop = true;
			this._Option1_0.Text = "Company Na&me:";
			this._Option1_0.UseVisualStyleBackColor = false;
			//
			//frmDeposits
			//
			this.frmDeposits.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.frmDeposits.Controls.Add(this._chkFields_4);
			this.frmDeposits.Controls.Add(this._chkFields_0);
			this.frmDeposits.Controls.Add(this.txtpos);
			this.frmDeposits.Controls.Add(this.cmbfont);
			this.frmDeposits.Controls.Add(this._Option2_2);
			this.frmDeposits.Controls.Add(this._Option2_1);
			this.frmDeposits.Controls.Add(this._Option2_0);
			this.frmDeposits.Controls.Add(this.Label6);
			this.frmDeposits.Controls.Add(this.Label5);
			this.frmDeposits.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmDeposits.Location = new System.Drawing.Point(568, 328);
			this.frmDeposits.Name = "frmDeposits";
			this.frmDeposits.Padding = new System.Windows.Forms.Padding(0);
			this.frmDeposits.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmDeposits.Size = new System.Drawing.Size(142, 185);
			this.frmDeposits.TabIndex = 31;
			this.frmDeposits.TabStop = false;
			this.frmDeposits.Text = "Font";
			//
			//_chkFields_4
			//
			this._chkFields_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_4.Location = new System.Drawing.Point(8, 160);
			this._chkFields_4.Name = "_chkFields_4";
			this._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_4.Size = new System.Drawing.Size(129, 19);
			this._chkFields_4.TabIndex = 40;
			this._chkFields_4.Text = "Add/Remo&ve:";
			this._chkFields_4.UseVisualStyleBackColor = false;
			//
			//_chkFields_0
			//
			this._chkFields_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Location = new System.Drawing.Point(8, 64);
			this._chkFields_0.Name = "_chkFields_0";
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Size = new System.Drawing.Size(129, 19);
			this._chkFields_0.TabIndex = 39;
			this._chkFields_0.Tag = "Company_Name";
			this._chkFields_0.Text = "B&old:";
			this._chkFields_0.UseVisualStyleBackColor = false;
			//
			//txtpos
			//
			this.txtpos.AcceptsReturn = true;
			this.txtpos.BackColor = System.Drawing.SystemColors.Window;
			this.txtpos.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtpos.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtpos.Location = new System.Drawing.Point(72, 48);
			this.txtpos.MaxLength = 0;
			this.txtpos.Name = "txtpos";
			this.txtpos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtpos.Size = new System.Drawing.Size(65, 19);
			this.txtpos.TabIndex = 37;
			this.txtpos.Text = "1";
			//
			//cmbfont
			//
			this.cmbfont.BackColor = System.Drawing.SystemColors.Window;
			this.cmbfont.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbfont.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbfont.Items.AddRange(new object[] {
				"8",
				"10",
				"12"
			});
			this.cmbfont.Location = new System.Drawing.Point(72, 24);
			this.cmbfont.Name = "cmbfont";
			this.cmbfont.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbfont.Size = new System.Drawing.Size(65, 21);
			this.cmbfont.TabIndex = 35;
			this.cmbfont.Text = "8";
			//
			//_Option2_2
			//
			this._Option2_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option2_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option2_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option2_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._Option2_2.Location = new System.Drawing.Point(8, 136);
			this._Option2_2.Name = "_Option2_2";
			this._Option2_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option2_2.Size = new System.Drawing.Size(129, 17);
			this._Option2_2.TabIndex = 34;
			this._Option2_2.TabStop = true;
			this._Option2_2.Text = "Align &Right:";
			this._Option2_2.UseVisualStyleBackColor = false;
			//
			//_Option2_1
			//
			this._Option2_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option2_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option2_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option2_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._Option2_1.Location = new System.Drawing.Point(8, 112);
			this._Option2_1.Name = "_Option2_1";
			this._Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option2_1.Size = new System.Drawing.Size(129, 17);
			this._Option2_1.TabIndex = 33;
			this._Option2_1.TabStop = true;
			this._Option2_1.Text = "Align &Center:";
			this._Option2_1.UseVisualStyleBackColor = false;
			//
			//_Option2_0
			//
			this._Option2_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Option2_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._Option2_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option2_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._Option2_0.Location = new System.Drawing.Point(8, 88);
			this._Option2_0.Name = "_Option2_0";
			this._Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option2_0.Size = new System.Drawing.Size(129, 17);
			this._Option2_0.TabIndex = 32;
			this._Option2_0.TabStop = true;
			this._Option2_0.Text = "Align Le&ft:";
			this._Option2_0.UseVisualStyleBackColor = false;
			//
			//Label6
			//
			this.Label6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label6.Location = new System.Drawing.Point(8, 48);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(65, 17);
			this.Label6.TabIndex = 38;
			this.Label6.Text = "Ro&w Position:";
			//
			//Label5
			//
			this.Label5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label5.Location = new System.Drawing.Point(8, 24);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(65, 17);
			this.Label5.TabIndex = 36;
			this.Label5.Text = "Font Si&ze:";
			//
			//_chkFields_1
			//
			this._chkFields_1.Location = new System.Drawing.Point(0, 0);
			this._chkFields_1.Name = "_chkFields_1";
			this._chkFields_1.Size = new System.Drawing.Size(104, 24);
			this._chkFields_1.TabIndex = 0;
			//
			//_chkFields_2
			//
			this._chkFields_2.Location = new System.Drawing.Point(0, 0);
			this._chkFields_2.Name = "_chkFields_2";
			this._chkFields_2.Size = new System.Drawing.Size(104, 24);
			this._chkFields_2.TabIndex = 0;
			//
			//_chkFields_3
			//
			this._chkFields_3.Location = new System.Drawing.Point(0, 0);
			this._chkFields_3.Name = "_chkFields_3";
			this._chkFields_3.Size = new System.Drawing.Size(104, 24);
			this._chkFields_3.TabIndex = 0;
			//
			//_chkFields_5
			//
			this._chkFields_5.Location = new System.Drawing.Point(0, 0);
			this._chkFields_5.Name = "_chkFields_5";
			this._chkFields_5.Size = new System.Drawing.Size(104, 24);
			this._chkFields_5.TabIndex = 0;
			//
			//HSLeft
			//
			this.HSLeft.Cursor = System.Windows.Forms.Cursors.Default;
			this.HSLeft.LargeChange = 5;
			this.HSLeft.Location = new System.Drawing.Point(416, 48);
			this.HSLeft.Maximum = 104;
			this.HSLeft.Name = "HSLeft";
			this.HSLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HSLeft.Size = new System.Drawing.Size(112, 19);
			this.HSLeft.TabIndex = 27;
			this.HSLeft.TabStop = true;
			//
			//HSTop
			//
			this.HSTop.Cursor = System.Windows.Forms.Cursors.Default;
			this.HSTop.LargeChange = 5;
			this.HSTop.Location = new System.Drawing.Point(280, 48);
			this.HSTop.Maximum = 26;
			this.HSTop.Name = "HSTop";
			this.HSTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HSTop.Size = new System.Drawing.Size(112, 19);
			this.HSTop.TabIndex = 26;
			this.HSTop.TabStop = true;
			//
			//cmdundo
			//
			this.cmdundo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdundo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdundo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdundo.Location = new System.Drawing.Point(136, 464);
			this.cmdundo.Name = "cmdundo";
			this.cmdundo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdundo.Size = new System.Drawing.Size(88, 49);
			this.cmdundo.TabIndex = 5;
			this.cmdundo.Text = "&Undo";
			this.cmdundo.UseVisualStyleBackColor = false;
			//
			//cmdnormal
			//
			this.cmdnormal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdnormal.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdnormal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdnormal.Location = new System.Drawing.Point(384, 560);
			this.cmdnormal.Name = "cmdnormal";
			this.cmdnormal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdnormal.Size = new System.Drawing.Size(88, 41);
			this.cmdnormal.TabIndex = 20;
			this.cmdnormal.Text = "Back To &Default";
			this.cmdnormal.UseVisualStyleBackColor = false;
			//
			//cmbpos
			//
			this.cmbpos.BackColor = System.Drawing.SystemColors.Window;
			this.cmbpos.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbpos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			this.cmbpos.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbpos.Items.AddRange(new object[] {
				"Second Row",
				"Third Row",
				"Fourth Row",
				"Fifth Row",
				"Sixth Row",
				"Seventh Row",
				"Eight Row"
			});
			this.cmbpos.Location = new System.Drawing.Point(248, 560);
			this.cmbpos.Name = "cmbpos";
			this.cmbpos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbpos.Size = new System.Drawing.Size(65, 21);
			this.cmbpos.TabIndex = 18;
			this.cmbpos.Text = "First Row";
			//
			//cmdadd
			//
			this.cmdadd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdadd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdadd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdadd.Location = new System.Drawing.Point(368, 464);
			this.cmdadd.Name = "cmdadd";
			this.cmdadd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdadd.Size = new System.Drawing.Size(88, 49);
			this.cmdadd.TabIndex = 1;
			this.cmdadd.Text = "&Save Design";
			this.cmdadd.UseVisualStyleBackColor = false;
			//
			//cmdSave
			//
			this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSave.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSave.Location = new System.Drawing.Point(472, 464);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSave.Size = new System.Drawing.Size(88, 49);
			this.cmdSave.TabIndex = 0;
			this.cmdSave.Text = "&Apply Changes";
			this.cmdSave.UseVisualStyleBackColor = false;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(32, 464);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(88, 49);
			this.cmdExit.TabIndex = 2;
			this.cmdExit.Text = "&Back";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//HSHeight
			//
			this.HSHeight.Cursor = System.Windows.Forms.Cursors.Default;
			this.HSHeight.LargeChange = 5;
			this.HSHeight.Location = new System.Drawing.Point(144, 48);
			this.HSHeight.Maximum = 82;
			this.HSHeight.Minimum = 10;
			this.HSHeight.Name = "HSHeight";
			this.HSHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HSHeight.Size = new System.Drawing.Size(112, 19);
			this.HSHeight.TabIndex = 4;
			this.HSHeight.TabStop = true;
			this.HSHeight.Value = 30;
			//
			//HSselect
			//
			this.HSselect.Cursor = System.Windows.Forms.Cursors.Default;
			this.HSselect.LargeChange = 500;
			this.HSselect.Location = new System.Drawing.Point(32, 384);
			this.HSselect.Maximum = 33266;
			this.HSselect.Name = "HSselect";
			this.HSselect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HSselect.Size = new System.Drawing.Size(531, 22);
			this.HSselect.SmallChange = 100;
			this.HSselect.TabIndex = 16;
			this.HSselect.TabStop = true;
			//
			//picOuter
			//
			this.picOuter.BackColor = System.Drawing.SystemColors.Control;
			this.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picOuter.Controls.Add(this.picInner);
			this.picOuter.Cursor = System.Windows.Forms.Cursors.Default;
			this.picOuter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picOuter.Location = new System.Drawing.Point(32, 88);
			this.picOuter.Name = "picOuter";
			this.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picOuter.Size = new System.Drawing.Size(531, 297);
			this.picOuter.TabIndex = 14;
			this.picOuter.TabStop = true;
			//
			//picInner
			//
			this.picInner.BackColor = System.Drawing.SystemColors.Control;
			this.picInner.Controls.Add(this._picSelect_0);
			this.picInner.Cursor = System.Windows.Forms.Cursors.Default;
			this.picInner.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picInner.Location = new System.Drawing.Point(0, 0);
			this.picInner.Name = "picInner";
			this.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picInner.Size = new System.Drawing.Size(533, 204);
			this.picInner.TabIndex = 6;
			this.picInner.TabStop = true;
			//
			//_picSelect_0
			//
			this._picSelect_0.BackColor = System.Drawing.SystemColors.Window;
			this._picSelect_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._picSelect_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._picSelect_0.Location = new System.Drawing.Point(0, 0);
			this._picSelect_0.Name = "_picSelect_0";
			this._picSelect_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picSelect_0.Size = new System.Drawing.Size(118, 142);
			this._picSelect_0.TabIndex = 15;
			//
			//HSWidth
			//
			this.HSWidth.Cursor = System.Windows.Forms.Cursors.Default;
			this.HSWidth.LargeChange = 5;
			this.HSWidth.Location = new System.Drawing.Point(16, 48);
			this.HSWidth.Maximum = 204;
			this.HSWidth.Minimum = 10;
			this.HSWidth.Name = "HSWidth";
			this.HSWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HSWidth.Size = new System.Drawing.Size(104, 19);
			this.HSWidth.TabIndex = 3;
			this.HSWidth.TabStop = true;
			this.HSWidth.Value = 40;
			//
			//_lbl_7
			//
			this._lbl_7.AutoSize = true;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Location = new System.Drawing.Point(512, 32);
			this._lbl_7.Name = "_lbl_7";
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.Size = new System.Drawing.Size(23, 13);
			this._lbl_7.TabIndex = 30;
			this._lbl_7.Text = "mm";
			//
			//lblLeft
			//
			this.lblLeft.AutoSize = true;
			this.lblLeft.BackColor = System.Drawing.Color.Transparent;
			this.lblLeft.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblLeft.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLeft.Location = new System.Drawing.Point(480, 32);
			this.lblLeft.Name = "lblLeft";
			this.lblLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLeft.Size = new System.Drawing.Size(13, 13);
			this.lblLeft.TabIndex = 29;
			this.lblLeft.Text = "0";
			this.lblLeft.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_6
			//
			this._lbl_6.AutoSize = true;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Location = new System.Drawing.Point(416, 32);
			this._lbl_6.Name = "_lbl_6";
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.Size = new System.Drawing.Size(60, 13);
			this._lbl_6.TabIndex = 28;
			this._lbl_6.Text = "Left Margin";
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(376, 32);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(23, 13);
			this._lbl_5.TabIndex = 25;
			this._lbl_5.Text = "mm";
			//
			//lblTop
			//
			this.lblTop.AutoSize = true;
			this.lblTop.BackColor = System.Drawing.Color.Transparent;
			this.lblTop.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTop.Location = new System.Drawing.Point(344, 32);
			this.lblTop.Name = "lblTop";
			this.lblTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTop.Size = new System.Drawing.Size(13, 13);
			this.lblTop.TabIndex = 24;
			this.lblTop.Text = "0";
			this.lblTop.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_4
			//
			this._lbl_4.AutoSize = true;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Location = new System.Drawing.Point(280, 32);
			this._lbl_4.Name = "_lbl_4";
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.Size = new System.Drawing.Size(61, 13);
			this._lbl_4.TabIndex = 23;
			this._lbl_4.Text = "Top Margin";
			//
			//Label8
			//
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Location = new System.Drawing.Point(16, 72);
			this.Label8.Name = "Label8";
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.Size = new System.Drawing.Size(425, 17);
			this.Label8.TabIndex = 22;
			this.Label8.Text = "The Numbers from (1 to 23) on the left side is the row position where your field " + "will appear.";
			//
			//lblLineNo
			//
			this.lblLineNo.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.lblLineNo.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblLineNo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLineNo.Location = new System.Drawing.Point(16, 88);
			this.lblLineNo.Name = "lblLineNo";
			this.lblLineNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLineNo.Size = new System.Drawing.Size(17, 297);
			this.lblLineNo.TabIndex = 21;
			this.lblLineNo.Text = "1- 2- 3- 4-  5- 6- 7- 8- 9- 10- 11- 12- 13- 14- 15- 16- 17- 18- 19- 20- 21- 22- 2" + "3-";
			//
			//Label7
			//
			this.Label7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label7.Location = new System.Drawing.Point(544, 1);
			this.Label7.Name = "Label7";
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.Size = new System.Drawing.Size(169, 17);
			this.Label7.TabIndex = 19;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(32, 3);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(74, 13);
			this.Label1.TabIndex = 17;
			this.Label1.Text = "Design Name:";
			//
			//lblWidth
			//
			this.lblWidth.AutoSize = true;
			this.lblWidth.BackColor = System.Drawing.Color.Transparent;
			this.lblWidth.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblWidth.Location = new System.Drawing.Point(80, 32);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblWidth.Size = new System.Drawing.Size(19, 13);
			this.lblWidth.TabIndex = 13;
			this.lblWidth.Text = "50";
			this.lblWidth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(104, 32);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(23, 13);
			this._lbl_0.TabIndex = 12;
			this._lbl_0.Text = "mm";
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(16, 32);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(64, 13);
			this._lbl_1.TabIndex = 11;
			this._lbl_1.Text = "Label Width";
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(144, 32);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(67, 13);
			this._lbl_2.TabIndex = 10;
			this._lbl_2.Text = "Label Height";
			//
			//_lbl_3
			//
			this._lbl_3.AutoSize = true;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(240, 32);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(23, 13);
			this._lbl_3.TabIndex = 9;
			this._lbl_3.Text = "mm";
			//
			//lblHeight
			//
			this.lblHeight.AutoSize = true;
			this.lblHeight.BackColor = System.Drawing.Color.Transparent;
			this.lblHeight.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeight.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeight.Location = new System.Drawing.Point(216, 32);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeight.Size = new System.Drawing.Size(13, 13);
			this.lblHeight.TabIndex = 8;
			this.lblHeight.Text = "0";
			this.lblHeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lbldesign
			//
			this.lbldesign.AutoSize = true;
			this.lbldesign.BackColor = System.Drawing.Color.Transparent;
			this.lbldesign.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbldesign.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbldesign.Location = new System.Drawing.Point(144, 3);
			this.lbldesign.Name = "lbldesign";
			this.lbldesign.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbldesign.Size = new System.Drawing.Size(39, 13);
			this.lbldesign.TabIndex = 7;
			this.lbldesign.Text = "Label1";
			//
			//frmBarcodeLoad
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(726, 519);
			this.ControlBox = false;
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.frmDeposits);
			this.Controls.Add(this.HSLeft);
			this.Controls.Add(this.HSTop);
			this.Controls.Add(this.cmdundo);
			this.Controls.Add(this.cmdnormal);
			this.Controls.Add(this.cmbpos);
			this.Controls.Add(this.cmdadd);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.HSHeight);
			this.Controls.Add(this.HSselect);
			this.Controls.Add(this.picOuter);
			this.Controls.Add(this.HSWidth);
			this.Controls.Add(this._lbl_7);
			this.Controls.Add(this.lblLeft);
			this.Controls.Add(this._lbl_6);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.lblTop);
			this.Controls.Add(this._lbl_4);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.lblLineNo);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblWidth);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this._lbl_2);
			this.Controls.Add(this._lbl_3);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lbldesign);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 29);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBarcodeLoad";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Barcode Designing";
			this.Frame1.ResumeLayout(false);
			this.frmDeposits.ResumeLayout(false);
			this.picOuter.ResumeLayout(false);
			this.picInner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this._picSelect_0).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
