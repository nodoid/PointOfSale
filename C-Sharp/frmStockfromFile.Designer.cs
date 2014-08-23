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
	partial class frmStockfromFile
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockfromFile() : base()
		{
			Load += frmStockfromFile_Load;
			KeyPress += frmStockfromFile_KeyPress;
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
		public System.Windows.Forms.TextBox txtFile;
		public System.Windows.Forms.ProgressBar prgStockItem;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.Button withEventsField_cmdNext;
		public System.Windows.Forms.Button cmdNext {
			get { return withEventsField_cmdNext; }
			set {
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click -= cmdNext_Click;
				}
				withEventsField_cmdNext = value;
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click += cmdNext_Click;
				}
			}
		}
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public System.Windows.Forms.SaveFileDialog CommonDialog1Save;
		public System.Windows.Forms.FontDialog CommonDialog1Font;
		public System.Windows.Forms.ColorDialog CommonDialog1Color;
		public System.Windows.Forms.PrintDialog CommonDialog1Print;
		public System.Windows.Forms.PictureBox Picture1;
		private System.Windows.Forms.TextBox withEventsField_txtName;
		public System.Windows.Forms.TextBox txtName {
			get { return withEventsField_txtName; }
			set {
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter -= txtName_Enter;
					withEventsField_txtName.Leave -= txtName_Leave;
				}
				withEventsField_txtName = value;
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter += txtName_Enter;
					withEventsField_txtName.Leave += txtName_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtReceipt;
		public System.Windows.Forms.TextBox txtReceipt {
			get { return withEventsField_txtReceipt; }
			set {
				if (withEventsField_txtReceipt != null) {
					withEventsField_txtReceipt.Enter -= txtReceipt_Enter;
				}
				withEventsField_txtReceipt = value;
				if (withEventsField_txtReceipt != null) {
					withEventsField_txtReceipt.Enter += txtReceipt_Enter;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtQuantity;
		public System.Windows.Forms.TextBox txtQuantity {
			get { return withEventsField_txtQuantity; }
			set {
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter -= txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress -= txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave -= txtQuantity_Leave;
				}
				withEventsField_txtQuantity = value;
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter += txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress += txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave += txtQuantity_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtCost;
		public System.Windows.Forms.TextBox txtCost {
			get { return withEventsField_txtCost; }
			set {
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter -= txtCost_Enter;
					withEventsField_txtCost.KeyPress -= txtCost_KeyPress;
					withEventsField_txtCost.Leave -= txtCost_Leave;
				}
				withEventsField_txtCost = value;
				if (withEventsField_txtCost != null) {
					withEventsField_txtCost.Enter += txtCost_Enter;
					withEventsField_txtCost.KeyPress += txtCost_KeyPress;
					withEventsField_txtCost.Leave += txtCost_Leave;
				}
			}
		}
		private myDataGridView withEventsField_cmbShrink;
		public myDataGridView cmbShrink {
			get { return withEventsField_cmbShrink; }
			set {
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown -= cmbShrink_KeyDown;
				}
				withEventsField_cmbShrink = value;
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown += cmbShrink_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.GroupBox Frame1;
		private myDataGridView withEventsField_cmbPricingGroup;
		public myDataGridView cmbPricingGroup {
			get { return withEventsField_cmbPricingGroup; }
			set {
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown -= cmbPricingGroup_KeyDown;
				}
				withEventsField_cmbPricingGroup = value;
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown += cmbPricingGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbStockGroup;
		public myDataGridView cmbStockGroup {
			get { return withEventsField_cmbStockGroup; }
			set {
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown -= cmbStockGroup_KeyDown;
				}
				withEventsField_cmbStockGroup = value;
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown += cmbStockGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbDeposit;
		public myDataGridView cmbDeposit {
			get { return withEventsField_cmbDeposit; }
			set {
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown -= cmbDeposit_KeyDown;
				}
				withEventsField_cmbDeposit = value;
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown += cmbDeposit_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbSupplier;
		public myDataGridView cmbSupplier {
			get { return withEventsField_cmbSupplier; }
			set {
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown -= cmbSupplier_KeyDown;
				}
				withEventsField_cmbSupplier = value;
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown += cmbSupplier_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.GroupBox _frmMode_1;
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockfromFile));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.prgStockItem = new System.Windows.Forms.ProgressBar();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1Save = new System.Windows.Forms.SaveFileDialog();
			this.CommonDialog1Font = new System.Windows.Forms.FontDialog();
			this.CommonDialog1Color = new System.Windows.Forms.ColorDialog();
			this.CommonDialog1Print = new System.Windows.Forms.PrintDialog();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtReceipt = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.cmbShrink = new myDataGridView();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this.cmbPricingGroup = new myDataGridView();
			this.cmbStockGroup = new myDataGridView();
			this.cmbDeposit = new myDataGridView();
			this.cmbSupplier = new myDataGridView();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Frame2.SuspendLayout();
			this.picButtons.SuspendLayout();
			this._frmMode_1.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).BeginInit();
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Adding Stock Items";
			this.ClientSize = new System.Drawing.Size(528, 170);
			this.Location = new System.Drawing.Point(3, 22);
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
			this.Name = "frmStockfromFile";
			this.Frame2.Size = new System.Drawing.Size(515, 99);
			this.Frame2.Location = new System.Drawing.Point(6, 62);
			this.Frame2.TabIndex = 24;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.txtFile.AutoSize = false;
			this.txtFile.Enabled = false;
			this.txtFile.Size = new System.Drawing.Size(403, 19);
			this.txtFile.Location = new System.Drawing.Point(104, 12);
			this.txtFile.TabIndex = 26;
			this.txtFile.AcceptsReturn = true;
			this.txtFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFile.BackColor = System.Drawing.SystemColors.Window;
			this.txtFile.CausesValidation = true;
			this.txtFile.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFile.HideSelection = true;
			this.txtFile.ReadOnly = false;
			this.txtFile.MaxLength = 0;
			this.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFile.Multiline = false;
			this.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFile.TabStop = true;
			this.txtFile.Visible = true;
			this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFile.Name = "txtFile";
			this.prgStockItem.Size = new System.Drawing.Size(495, 21);
			this.prgStockItem.Location = new System.Drawing.Point(14, 34);
			this.prgStockItem.TabIndex = 25;
			this.prgStockItem.Maximum = 10000;
			this.prgStockItem.Name = "prgStockItem";
			this.Label1.Text = "File Name: ";
			this.Label1.Size = new System.Drawing.Size(81, 17);
			this.Label1.Location = new System.Drawing.Point(20, 12);
			this.Label1.TabIndex = 28;
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
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = ":";
			this.Label2.Size = new System.Drawing.Size(295, 23);
			this.Label2.Location = new System.Drawing.Point(212, 60);
			this.Label2.TabIndex = 27;
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
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(528, 53);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 21;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Do Update>>";
			this.cmdNext.Size = new System.Drawing.Size(96, 33);
			this.cmdNext.Location = new System.Drawing.Point(420, 6);
			this.cmdNext.TabIndex = 23;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Size = new System.Drawing.Size(97, 33);
			this.cmdBack.Location = new System.Drawing.Point(8, 6);
			this.cmdBack.TabIndex = 22;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this._frmMode_1.Text = "New \"Stock Item\" Details.";
			this._frmMode_1.Enabled = false;
			this._frmMode_1.Size = new System.Drawing.Size(331, 263);
			this._frmMode_1.Location = new System.Drawing.Point(-2, 506);
			this._frmMode_1.TabIndex = 0;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Visible = true;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this.Picture1.Size = new System.Drawing.Size(295, 4);
			this.Picture1.Location = new System.Drawing.Point(28, 162);
			this.Picture1.TabIndex = 10;
			this.Picture1.TabStop = false;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Name = "Picture1";
			this.txtName.AutoSize = false;
			this.txtName.Size = new System.Drawing.Size(241, 19);
			this.txtName.Location = new System.Drawing.Point(82, 18);
			this.txtName.TabIndex = 9;
			this.txtName.Text = "[New Product]";
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
			this.txtReceipt.AutoSize = false;
			this.txtReceipt.Size = new System.Drawing.Size(241, 19);
			this.txtReceipt.Location = new System.Drawing.Point(82, 39);
			this.txtReceipt.MaxLength = 20;
			this.txtReceipt.TabIndex = 8;
			this.txtReceipt.AcceptsReturn = true;
			this.txtReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtReceipt.BackColor = System.Drawing.SystemColors.Window;
			this.txtReceipt.CausesValidation = true;
			this.txtReceipt.Enabled = true;
			this.txtReceipt.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtReceipt.HideSelection = true;
			this.txtReceipt.ReadOnly = false;
			this.txtReceipt.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtReceipt.Multiline = false;
			this.txtReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtReceipt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtReceipt.TabStop = true;
			this.txtReceipt.Visible = true;
			this.txtReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReceipt.Name = "txtReceipt";
			this.Frame1.Size = new System.Drawing.Size(317, 57);
			this.Frame1.Location = new System.Drawing.Point(8, 168);
			this.Frame1.TabIndex = 1;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.Size = new System.Drawing.Size(28, 19);
			this.txtQuantity.Location = new System.Drawing.Point(56, 12);
			this.txtQuantity.TabIndex = 3;
			this.txtQuantity.Text = "12";
			this.txtQuantity.AcceptsReturn = true;
			this.txtQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.txtQuantity.CausesValidation = true;
			this.txtQuantity.Enabled = true;
			this.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantity.HideSelection = true;
			this.txtQuantity.ReadOnly = false;
			this.txtQuantity.MaxLength = 0;
			this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQuantity.Multiline = false;
			this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQuantity.TabStop = true;
			this.txtQuantity.Visible = true;
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQuantity.Name = "txtQuantity";
			this.txtCost.AutoSize = false;
			this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCost.Size = new System.Drawing.Size(56, 19);
			this.txtCost.Location = new System.Drawing.Point(256, 14);
			this.txtCost.TabIndex = 2;
			this.txtCost.Text = "0.00";
			this.txtCost.AcceptsReturn = true;
			this.txtCost.BackColor = System.Drawing.SystemColors.Window;
			this.txtCost.CausesValidation = true;
			this.txtCost.Enabled = true;
			this.txtCost.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCost.HideSelection = true;
			this.txtCost.ReadOnly = false;
			this.txtCost.MaxLength = 0;
			this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCost.Multiline = false;
			this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCost.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCost.TabStop = true;
			this.txtCost.Visible = true;
			this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCost.Name = "txtCost";
			//cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbShrink.Size = new System.Drawing.Size(91, 21);
			this.cmbShrink.Location = new System.Drawing.Point(134, 30);
			this.cmbShrink.TabIndex = 4;
			this.cmbShrink.Name = "cmbShrink";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "There are ";
			this._lblLabels_2.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(6, 16);
			this._lblLabels_2.TabIndex = 7;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_10.Text = "Units in a case/carton, which costs";
			this._lblLabels_10.Size = new System.Drawing.Size(167, 13);
			this._lblLabels_10.Location = new System.Drawing.Point(86, 16);
			this._lblLabels_10.TabIndex = 6;
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Enabled = true;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.UseMnemonic = true;
			this._lblLabels_10.Visible = true;
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "and you sell in shrinks of";
			this._lblLabels_1.Size = new System.Drawing.Size(115, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(8, 38);
			this._lblLabels_1.TabIndex = 5;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			//cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPricingGroup.Size = new System.Drawing.Size(241, 21);
			this.cmbPricingGroup.Location = new System.Drawing.Point(82, 108);
			this.cmbPricingGroup.TabIndex = 11;
			this.cmbPricingGroup.Name = "cmbPricingGroup";
			//cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbStockGroup.Size = new System.Drawing.Size(241, 21);
			this.cmbStockGroup.Location = new System.Drawing.Point(82, 132);
			this.cmbStockGroup.TabIndex = 12;
			this.cmbStockGroup.Name = "cmbStockGroup";
			//cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbDeposit.Size = new System.Drawing.Size(241, 21);
			this.cmbDeposit.Location = new System.Drawing.Point(82, 84);
			this.cmbDeposit.TabIndex = 13;
			this.cmbDeposit.Name = "cmbDeposit";
			//cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbSupplier.Size = new System.Drawing.Size(241, 21);
			this.cmbSupplier.Location = new System.Drawing.Point(82, 60);
			this.cmbSupplier.TabIndex = 14;
			this.cmbSupplier.Name = "cmbSupplier";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_6.Text = "Deposit:";
			this._lblLabels_6.Size = new System.Drawing.Size(39, 13);
			this._lblLabels_6.Location = new System.Drawing.Point(38, 90);
			this._lblLabels_6.TabIndex = 20;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Enabled = true;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.UseMnemonic = true;
			this._lblLabels_6.Visible = true;
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Supplier:";
			this._lblLabels_0.Size = new System.Drawing.Size(41, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(36, 66);
			this._lblLabels_0.TabIndex = 19;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_3.Text = "Pricing Group:";
			this._lblLabels_3.Size = new System.Drawing.Size(67, 13);
			this._lblLabels_3.Location = new System.Drawing.Point(10, 114);
			this._lblLabels_3.TabIndex = 18;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Enabled = true;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.UseMnemonic = true;
			this._lblLabels_3.Visible = true;
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_4.Text = "Stock Group:";
			this._lblLabels_4.Size = new System.Drawing.Size(63, 13);
			this._lblLabels_4.Location = new System.Drawing.Point(14, 138);
			this._lblLabels_4.TabIndex = 17;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Enabled = true;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.UseMnemonic = true;
			this._lblLabels_4.Visible = true;
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.Text = "Display Name:";
			this._lblLabels_7.Size = new System.Drawing.Size(68, 13);
			this._lblLabels_7.Location = new System.Drawing.Point(10, 20);
			this._lblLabels_7.TabIndex = 16;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Enabled = true;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.UseMnemonic = true;
			this._lblLabels_7.Visible = true;
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Receipt Name:";
			this._lblLabels_8.Size = new System.Drawing.Size(71, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(6, 45);
			this._lblLabels_8.TabIndex = 15;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Enabled = true;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.UseMnemonic = true;
			this._lblLabels_8.Visible = true;
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_8.Name = "_lblLabels_8";
			this.Controls.Add(Frame2);
			this.Controls.Add(picButtons);
			this.Controls.Add(_frmMode_1);
			this.Frame2.Controls.Add(txtFile);
			this.Frame2.Controls.Add(prgStockItem);
			this.Frame2.Controls.Add(Label1);
			this.Frame2.Controls.Add(Label2);
			this.picButtons.Controls.Add(cmdNext);
			this.picButtons.Controls.Add(cmdBack);
			this._frmMode_1.Controls.Add(Picture1);
			this._frmMode_1.Controls.Add(txtName);
			this._frmMode_1.Controls.Add(txtReceipt);
			this._frmMode_1.Controls.Add(Frame1);
			this._frmMode_1.Controls.Add(cmbPricingGroup);
			this._frmMode_1.Controls.Add(cmbStockGroup);
			this._frmMode_1.Controls.Add(cmbDeposit);
			this._frmMode_1.Controls.Add(cmbSupplier);
			this._frmMode_1.Controls.Add(_lblLabels_6);
			this._frmMode_1.Controls.Add(_lblLabels_0);
			this._frmMode_1.Controls.Add(_lblLabels_3);
			this._frmMode_1.Controls.Add(_lblLabels_4);
			this._frmMode_1.Controls.Add(_lblLabels_7);
			this._frmMode_1.Controls.Add(_lblLabels_8);
			this.Frame1.Controls.Add(txtQuantity);
			this.Frame1.Controls.Add(txtCost);
			this.Frame1.Controls.Add(cmbShrink);
			this.Frame1.Controls.Add(_lblLabels_2);
			this.Frame1.Controls.Add(_lblLabels_10);
			this.Frame1.Controls.Add(_lblLabels_1);
			//Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
			//Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).EndInit();
			this.Frame2.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this._frmMode_1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
