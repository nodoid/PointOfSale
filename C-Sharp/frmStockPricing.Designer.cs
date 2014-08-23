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
	partial class frmStockPricing
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockPricing() : base()
		{
			Load += frmStockPricing_Load;
			FormClosed += frmStockPricing_FormClosed;
			Resize += frmStockPricing_Resize;
			KeyDown += frmStockPricing_KeyDown;
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
		public System.Windows.Forms.TextBox txttemphold;
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
		private System.Windows.Forms.Button withEventsField_cmdbarcode;
		public System.Windows.Forms.Button cmdbarcode {
			get { return withEventsField_cmdbarcode; }
			set {
				if (withEventsField_cmdbarcode != null) {
					withEventsField_cmdbarcode.Click -= cmdbarcode_Click;
				}
				withEventsField_cmdbarcode = value;
				if (withEventsField_cmdbarcode != null) {
					withEventsField_cmdbarcode.Click += cmdbarcode_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdHistory;
		public System.Windows.Forms.Button cmdHistory {
			get { return withEventsField_cmdHistory; }
			set {
				if (withEventsField_cmdHistory != null) {
					withEventsField_cmdHistory.Click -= cmdHistory_Click;
				}
				withEventsField_cmdHistory = value;
				if (withEventsField_cmdHistory != null) {
					withEventsField_cmdHistory.Click += cmdHistory_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDetails;
		public System.Windows.Forms.Button cmdDetails {
			get { return withEventsField_cmdDetails; }
			set {
				if (withEventsField_cmdDetails != null) {
					withEventsField_cmdDetails.Click -= cmdDetails_Click;
				}
				withEventsField_cmdDetails = value;
				if (withEventsField_cmdDetails != null) {
					withEventsField_cmdDetails.Click += cmdDetails_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdUndo;
		public System.Windows.Forms.Button cmdUndo {
			get { return withEventsField_cmdUndo; }
			set {
				if (withEventsField_cmdUndo != null) {
					withEventsField_cmdUndo.Click -= cmdUndo_Click;
				}
				withEventsField_cmdUndo = value;
				if (withEventsField_cmdUndo != null) {
					withEventsField_cmdUndo.Click += cmdUndo_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		private System.Windows.Forms.ComboBox withEventsField_cmbChannel;
		public System.Windows.Forms.ComboBox cmbChannel {
			get { return withEventsField_cmbChannel; }
			set {
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.SelectedIndexChanged -= cmbChannel_SelectedIndexChanged;
				}
				withEventsField_cmbChannel = value;
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.SelectedIndexChanged += cmbChannel_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.PictureBox _picLine_0;
		private System.Windows.Forms.TextBox withEventsField__txtCost_0;
		public System.Windows.Forms.TextBox _txtCost_0 {
			get { return withEventsField__txtCost_0; }
			set {
				if (withEventsField__txtCost_0 != null) {
					withEventsField__txtCost_0.Enter -= txtCost_Enter;
					withEventsField__txtCost_0.KeyPress -= txtCost_KeyPress;
					withEventsField__txtCost_0.Leave -= txtCost_Leave;
				}
				withEventsField__txtCost_0 = value;
				if (withEventsField__txtCost_0 != null) {
					withEventsField__txtCost_0.Enter += txtCost_Enter;
					withEventsField__txtCost_0.KeyPress += txtCost_KeyPress;
					withEventsField__txtCost_0.Leave += txtCost_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField__txtProp_0;
		public System.Windows.Forms.TextBox _txtProp_0 {
			get { return withEventsField__txtProp_0; }
			set {
				if (withEventsField__txtProp_0 != null) {
					withEventsField__txtProp_0.Enter -= txtProp_Enter;
					withEventsField__txtProp_0.KeyPress -= txtProp_KeyPress;
					withEventsField__txtProp_0.Leave -= txtProp_Leave;
				}
				withEventsField__txtProp_0 = value;
				if (withEventsField__txtProp_0 != null) {
					withEventsField__txtProp_0.Enter += txtProp_Enter;
					withEventsField__txtProp_0.KeyPress += txtProp_KeyPress;
					withEventsField__txtProp_0.Leave += txtProp_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField__txtPrice_0;
		public System.Windows.Forms.TextBox _txtPrice_0 {
			get { return withEventsField__txtPrice_0; }
			set {
				if (withEventsField__txtPrice_0 != null) {
					withEventsField__txtPrice_0.Enter -= txtPrice_Enter;
					withEventsField__txtPrice_0.KeyPress -= txtPrice_KeyPress;
					withEventsField__txtPrice_0.Leave -= txtPrice_Leave;
				}
				withEventsField__txtPrice_0 = value;
				if (withEventsField__txtPrice_0 != null) {
					withEventsField__txtPrice_0.Enter += txtPrice_Enter;
					withEventsField__txtPrice_0.KeyPress += txtPrice_KeyPress;
					withEventsField__txtPrice_0.Leave += txtPrice_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField__txtVariableCost_0;
		public System.Windows.Forms.TextBox _txtVariableCost_0 {
			get { return withEventsField__txtVariableCost_0; }
			set {
				if (withEventsField__txtVariableCost_0 != null) {
					withEventsField__txtVariableCost_0.Enter -= txtVariableCost_Enter;
					withEventsField__txtVariableCost_0.KeyPress -= txtVariableCost_KeyPress;
					withEventsField__txtVariableCost_0.Leave -= txtVariableCost_Leave;
				}
				withEventsField__txtVariableCost_0 = value;
				if (withEventsField__txtVariableCost_0 != null) {
					withEventsField__txtVariableCost_0.Enter += txtVariableCost_Enter;
					withEventsField__txtVariableCost_0.KeyPress += txtVariableCost_KeyPress;
					withEventsField__txtVariableCost_0.Leave += txtVariableCost_Leave;
				}
			}
		}
		public System.Windows.Forms.Label _lblGPActual_0;
		public System.Windows.Forms.Label _lblGP_0;
		public System.Windows.Forms.Label _lblSection_0;
		public Microsoft.VisualBasic.PowerPacks.LineShape _lnProfit_0;
		public System.Windows.Forms.Label _lblProfitPrecent_0;
		public System.Windows.Forms.Label _lblProfitAmount_0;
		public System.Windows.Forms.Label _lblMatrix_0;
		public System.Windows.Forms.Label _lblDepositUnit_0;
		public System.Windows.Forms.Label _lblDepositPack_0;
		public System.Windows.Forms.Label _lblVat_0;
		public System.Windows.Forms.Label _lblMarkup_0;
		public System.Windows.Forms.Label _lblPrice_0;
		public System.Windows.Forms.Label _lblPercent_0;
		public System.Windows.Forms.GroupBox _frmItem_0;
		public System.Windows.Forms.ImageList ilGeneral;
		public System.Windows.Forms.Label _lbl_17;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblPriceSet;
		public System.Windows.Forms.Label _lbl_16;
		public System.Windows.Forms.Label _lbl_15;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label lblStockItemName;
		public System.Windows.Forms.Label lblPricingGroupRule;
		public System.Windows.Forms.Label lblPricingGroup;
		public System.Windows.Forms.Label _lbl_18;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label lblVatName;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label _lbl_10;
		public System.Windows.Forms.Label _lbl_11;
		public System.Windows.Forms.Label _lbl_12;
		public System.Windows.Forms.Label _lbl_13;
		public System.Windows.Forms.Label _lbl_14;
		public Microsoft.VisualBasic.PowerPacks.LineShape _Line1_3;
		public LineShapeArray Line1;
		//Public WithEvents frmItem As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblDepositPack As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblDepositUnit As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//P''ublic WithEvents lblGP As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//P'ublic WithEvents lblGPActual As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//P'ublic WithEvents lblMarkup As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//P'ublic WithEvents lblMatrix As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//P'''ublic WithEvents lblPercent As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblPrice As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblProfitAmount As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblProfitPrecent As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblSection As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblVat As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public LineShapeArray lnProfit;
		//Public WithEvents picLine As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
		//Public WithEvents txtCost As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtPrice As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//P''ublic WithEvents txtProp As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtVariableCost As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer2;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockPricing));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txttemphold = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdbarcode = new System.Windows.Forms.Button();
			this.cmdHistory = new System.Windows.Forms.Button();
			this.cmdDetails = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdUndo = new System.Windows.Forms.Button();
			this.cmbChannel = new System.Windows.Forms.ComboBox();
			this._frmItem_0 = new System.Windows.Forms.GroupBox();
			this._picLine_0 = new System.Windows.Forms.PictureBox();
			this._txtCost_0 = new System.Windows.Forms.TextBox();
			this._txtProp_0 = new System.Windows.Forms.TextBox();
			this._txtPrice_0 = new System.Windows.Forms.TextBox();
			this._txtVariableCost_0 = new System.Windows.Forms.TextBox();
			this._lblGPActual_0 = new System.Windows.Forms.Label();
			this._lblGP_0 = new System.Windows.Forms.Label();
			this._lblSection_0 = new System.Windows.Forms.Label();
			this._lnProfit_0 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._lblProfitPrecent_0 = new System.Windows.Forms.Label();
			this._lblProfitAmount_0 = new System.Windows.Forms.Label();
			this._lblMatrix_0 = new System.Windows.Forms.Label();
			this._lblDepositUnit_0 = new System.Windows.Forms.Label();
			this._lblDepositPack_0 = new System.Windows.Forms.Label();
			this._lblVat_0 = new System.Windows.Forms.Label();
			this._lblMarkup_0 = new System.Windows.Forms.Label();
			this._lblPrice_0 = new System.Windows.Forms.Label();
			this._lblPercent_0 = new System.Windows.Forms.Label();
			this.ilGeneral = new System.Windows.Forms.ImageList();
			this._lbl_17 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblPriceSet = new System.Windows.Forms.Label();
			this._lbl_16 = new System.Windows.Forms.Label();
			this._lbl_15 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this.lblStockItemName = new System.Windows.Forms.Label();
			this.lblPricingGroupRule = new System.Windows.Forms.Label();
			this.lblPricingGroup = new System.Windows.Forms.Label();
			this._lbl_18 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this.lblVatName = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this._lbl_9 = new System.Windows.Forms.Label();
			this._lbl_10 = new System.Windows.Forms.Label();
			this._lbl_11 = new System.Windows.Forms.Label();
			this._lbl_12 = new System.Windows.Forms.Label();
			this._lbl_13 = new System.Windows.Forms.Label();
			this._lbl_14 = new System.Windows.Forms.Label();
			this._Line1_3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Line1 = new LineShapeArray(components);
			//Me.frmItem = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblDepositPack = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblDepositUnit = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblGP = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblGPActual = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblMarkup = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblMatrix = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblPercent = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblPrice = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblProfitAmount = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblProfitPrecent = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblSection = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblVat = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.lnProfit = new LineShapeArray(components);
			//Me.picLine = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
			//Me.txtCost = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//'Me.txtPrice = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//M() 'e.txtProp = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//M() 'e.txtVariableCost = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.picButtons.SuspendLayout();
			this._frmItem_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmItem, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblDepositPack, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblDepositUnit, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblGP, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblGPActual, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblMarkup, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblPercent, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblPrice, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblProfitAmount, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblProfitPrecent, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblSection, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblVat, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.lnProfit).BeginInit();
			//CType(Me.picLine, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtCost, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtPrice, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtProp, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtVariableCost, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Stock Item Pricing";
			this.ClientSize = new System.Drawing.Size(711, 565);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmStockPricing.Icon");
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockPricing";
			this.txttemphold.AutoSize = false;
			this.txttemphold.Size = new System.Drawing.Size(73, 21);
			this.txttemphold.Location = new System.Drawing.Point(392, 574);
			this.txttemphold.TabIndex = 48;
			this.txttemphold.AcceptsReturn = true;
			this.txttemphold.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txttemphold.BackColor = System.Drawing.SystemColors.Window;
			this.txttemphold.CausesValidation = true;
			this.txttemphold.Enabled = true;
			this.txttemphold.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txttemphold.HideSelection = true;
			this.txttemphold.ReadOnly = false;
			this.txttemphold.MaxLength = 0;
			this.txttemphold.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txttemphold.Multiline = false;
			this.txttemphold.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txttemphold.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txttemphold.TabStop = true;
			this.txttemphold.Visible = true;
			this.txttemphold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txttemphold.Name = "txttemphold";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(711, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 38;
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
			this.cmdNext.Text = "&Next Item >";
			this.cmdNext.Size = new System.Drawing.Size(67, 29);
			this.cmdNext.Location = new System.Drawing.Point(320, 4);
			this.cmdNext.TabIndex = 50;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdbarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdbarcode.Text = "&Barcode";
			this.cmdbarcode.Size = new System.Drawing.Size(77, 31);
			this.cmdbarcode.Location = new System.Drawing.Point(86, 2);
			this.cmdbarcode.TabIndex = 47;
			this.cmdbarcode.TabStop = false;
			this.cmdbarcode.BackColor = System.Drawing.SystemColors.Control;
			this.cmdbarcode.CausesValidation = true;
			this.cmdbarcode.Enabled = true;
			this.cmdbarcode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdbarcode.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdbarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdbarcode.Name = "cmdbarcode";
			this.cmdHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdHistory.Text = "&History";
			this.cmdHistory.Size = new System.Drawing.Size(67, 29);
			this.cmdHistory.Location = new System.Drawing.Point(248, 4);
			this.cmdHistory.TabIndex = 45;
			this.cmdHistory.TabStop = false;
			this.cmdHistory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHistory.CausesValidation = true;
			this.cmdHistory.Enabled = true;
			this.cmdHistory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHistory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHistory.Name = "cmdHistory";
			this.cmdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDetails.Text = "&Details";
			this.cmdDetails.Size = new System.Drawing.Size(73, 29);
			this.cmdDetails.Location = new System.Drawing.Point(168, 4);
			this.cmdDetails.TabIndex = 41;
			this.cmdDetails.TabStop = false;
			this.cmdDetails.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDetails.CausesValidation = true;
			this.cmdDetails.Enabled = true;
			this.cmdDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDetails.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDetails.Name = "cmdDetails";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.Location = new System.Drawing.Point(512, 2);
			this.cmdExit.TabIndex = 40;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUndo.Text = "&Undo";
			this.cmdUndo.Size = new System.Drawing.Size(73, 29);
			this.cmdUndo.Location = new System.Drawing.Point(5, 3);
			this.cmdUndo.TabIndex = 39;
			this.cmdUndo.TabStop = false;
			this.cmdUndo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUndo.CausesValidation = true;
			this.cmdUndo.Enabled = true;
			this.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUndo.Name = "cmdUndo";
			this.cmbChannel.Size = new System.Drawing.Size(160, 21);
			this.cmbChannel.Location = new System.Drawing.Point(87, 66);
			this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChannel.TabIndex = 0;
			this.cmbChannel.BackColor = System.Drawing.SystemColors.Window;
			this.cmbChannel.CausesValidation = true;
			this.cmbChannel.Enabled = true;
			this.cmbChannel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbChannel.IntegralHeight = true;
			this.cmbChannel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbChannel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbChannel.Sorted = false;
			this.cmbChannel.TabStop = true;
			this.cmbChannel.Visible = true;
			this.cmbChannel.Name = "cmbChannel";
			this._frmItem_0.Text = "Frame1";
			this._frmItem_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmItem_0.Size = new System.Drawing.Size(100, 355);
			this._frmItem_0.Location = new System.Drawing.Point(87, 159);
			this._frmItem_0.TabIndex = 5;
			this._frmItem_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmItem_0.Enabled = true;
			this._frmItem_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmItem_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmItem_0.Visible = true;
			this._frmItem_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmItem_0.Name = "_frmItem_0";
			this._picLine_0.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this._picLine_0.Size = new System.Drawing.Size(94, 7);
			this._picLine_0.Location = new System.Drawing.Point(3, 189);
			this._picLine_0.TabIndex = 37;
			this._picLine_0.TabStop = false;
			this._picLine_0.Dock = System.Windows.Forms.DockStyle.None;
			this._picLine_0.CausesValidation = true;
			this._picLine_0.Enabled = true;
			this._picLine_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._picLine_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._picLine_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._picLine_0.Visible = true;
			this._picLine_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this._picLine_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._picLine_0.Name = "_picLine_0";
			this._txtCost_0.AutoSize = false;
			this._txtCost_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCost_0.Size = new System.Drawing.Size(88, 19);
			this._txtCost_0.Location = new System.Drawing.Point(6, 18);
			this._txtCost_0.TabIndex = 1;
			this._txtCost_0.Text = "9,999.99";
			this._txtCost_0.AcceptsReturn = true;
			this._txtCost_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtCost_0.CausesValidation = true;
			this._txtCost_0.Enabled = true;
			this._txtCost_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCost_0.HideSelection = true;
			this._txtCost_0.ReadOnly = false;
			this._txtCost_0.MaxLength = 0;
			this._txtCost_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCost_0.Multiline = false;
			this._txtCost_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCost_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCost_0.TabStop = true;
			this._txtCost_0.Visible = true;
			this._txtCost_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtCost_0.Name = "_txtCost_0";
			this._txtProp_0.AutoSize = false;
			this._txtProp_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtProp_0.Size = new System.Drawing.Size(88, 19);
			this._txtProp_0.Location = new System.Drawing.Point(6, 54);
			this._txtProp_0.TabIndex = 2;
			this._txtProp_0.AcceptsReturn = true;
			this._txtProp_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtProp_0.CausesValidation = true;
			this._txtProp_0.Enabled = true;
			this._txtProp_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtProp_0.HideSelection = true;
			this._txtProp_0.ReadOnly = false;
			this._txtProp_0.MaxLength = 0;
			this._txtProp_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtProp_0.Multiline = false;
			this._txtProp_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtProp_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtProp_0.TabStop = true;
			this._txtProp_0.Visible = true;
			this._txtProp_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtProp_0.Name = "_txtProp_0";
			this._txtPrice_0.AutoSize = false;
			this._txtPrice_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtPrice_0.Size = new System.Drawing.Size(88, 19);
			this._txtPrice_0.Location = new System.Drawing.Point(6, 150);
			this._txtPrice_0.TabIndex = 3;
			this._txtPrice_0.AcceptsReturn = true;
			this._txtPrice_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtPrice_0.CausesValidation = true;
			this._txtPrice_0.Enabled = true;
			this._txtPrice_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtPrice_0.HideSelection = true;
			this._txtPrice_0.ReadOnly = false;
			this._txtPrice_0.MaxLength = 0;
			this._txtPrice_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtPrice_0.Multiline = false;
			this._txtPrice_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtPrice_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtPrice_0.TabStop = true;
			this._txtPrice_0.Visible = true;
			this._txtPrice_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtPrice_0.Name = "_txtPrice_0";
			this._txtVariableCost_0.AutoSize = false;
			this._txtVariableCost_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtVariableCost_0.Enabled = false;
			this._txtVariableCost_0.Size = new System.Drawing.Size(88, 19);
			this._txtVariableCost_0.Location = new System.Drawing.Point(6, 243);
			this._txtVariableCost_0.TabIndex = 4;
			this._txtVariableCost_0.TabStop = false;
			this._txtVariableCost_0.Text = "42.00";
			this._txtVariableCost_0.AcceptsReturn = true;
			this._txtVariableCost_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtVariableCost_0.CausesValidation = true;
			this._txtVariableCost_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtVariableCost_0.HideSelection = true;
			this._txtVariableCost_0.ReadOnly = false;
			this._txtVariableCost_0.MaxLength = 0;
			this._txtVariableCost_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtVariableCost_0.Multiline = false;
			this._txtVariableCost_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtVariableCost_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtVariableCost_0.Visible = true;
			this._txtVariableCost_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtVariableCost_0.Name = "_txtVariableCost_0";
			this._lblGPActual_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblGPActual_0.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			this._lblGPActual_0.Text = "lblGPActual";
			this._lblGPActual_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblGPActual_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblGPActual_0.Size = new System.Drawing.Size(88, 16);
			this._lblGPActual_0.Location = new System.Drawing.Point(6, 300);
			this._lblGPActual_0.TabIndex = 46;
			this._lblGPActual_0.Enabled = true;
			this._lblGPActual_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblGPActual_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblGPActual_0.UseMnemonic = true;
			this._lblGPActual_0.Visible = true;
			this._lblGPActual_0.AutoSize = false;
			this._lblGPActual_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblGPActual_0.Name = "_lblGPActual_0";
			this._lblGP_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblGP_0.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			this._lblGP_0.Text = "lblGP";
			this._lblGP_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblGP_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblGP_0.Size = new System.Drawing.Size(88, 16);
			this._lblGP_0.Location = new System.Drawing.Point(6, 216);
			this._lblGP_0.TabIndex = 43;
			this._lblGP_0.Enabled = true;
			this._lblGP_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblGP_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblGP_0.UseMnemonic = true;
			this._lblGP_0.Visible = true;
			this._lblGP_0.AutoSize = false;
			this._lblGP_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblGP_0.Name = "_lblGP_0";
			this._lblSection_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblSection_0.BackColor = System.Drawing.Color.Red;
			this._lblSection_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblSection_0.Size = new System.Drawing.Size(88, 34);
			this._lblSection_0.Location = new System.Drawing.Point(6, 318);
			this._lblSection_0.TabIndex = 36;
			this._lblSection_0.Enabled = true;
			this._lblSection_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblSection_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblSection_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblSection_0.UseMnemonic = true;
			this._lblSection_0.Visible = true;
			this._lblSection_0.AutoSize = false;
			this._lblSection_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblSection_0.Name = "_lblSection_0";
			this._lnProfit_0.X1 = 93;
			this._lnProfit_0.X2 = 0;
			this._lnProfit_0.Y1 = 224;
			this._lnProfit_0.Y2 = 224;
			this._lnProfit_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._lnProfit_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._lnProfit_0.BorderWidth = 1;
			this._lnProfit_0.Visible = true;
			this._lnProfit_0.Name = "_lnProfit_0";
			this._lblProfitPrecent_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblProfitPrecent_0.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._lblProfitPrecent_0.Text = "lblProfitPrecent";
			this._lblProfitPrecent_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblProfitPrecent_0.ForeColor = System.Drawing.Color.Black;
			this._lblProfitPrecent_0.Size = new System.Drawing.Size(88, 16);
			this._lblProfitPrecent_0.Location = new System.Drawing.Point(6, 282);
			this._lblProfitPrecent_0.TabIndex = 28;
			this._lblProfitPrecent_0.Enabled = true;
			this._lblProfitPrecent_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblProfitPrecent_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblProfitPrecent_0.UseMnemonic = true;
			this._lblProfitPrecent_0.Visible = true;
			this._lblProfitPrecent_0.AutoSize = false;
			this._lblProfitPrecent_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblProfitPrecent_0.Name = "_lblProfitPrecent_0";
			this._lblProfitAmount_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblProfitAmount_0.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
			this._lblProfitAmount_0.Text = "lblProfitAmount";
			this._lblProfitAmount_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblProfitAmount_0.ForeColor = System.Drawing.Color.Black;
			this._lblProfitAmount_0.Size = new System.Drawing.Size(88, 16);
			this._lblProfitAmount_0.Location = new System.Drawing.Point(6, 264);
			this._lblProfitAmount_0.TabIndex = 27;
			this._lblProfitAmount_0.Enabled = true;
			this._lblProfitAmount_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblProfitAmount_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblProfitAmount_0.UseMnemonic = true;
			this._lblProfitAmount_0.Visible = true;
			this._lblProfitAmount_0.AutoSize = false;
			this._lblProfitAmount_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblProfitAmount_0.Name = "_lblProfitAmount_0";
			this._lblMatrix_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblMatrix_0.Text = "30.00";
			this._lblMatrix_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblMatrix_0.Size = new System.Drawing.Size(88, 13);
			this._lblMatrix_0.Location = new System.Drawing.Point(6, 39);
			this._lblMatrix_0.TabIndex = 26;
			this._lblMatrix_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblMatrix_0.Enabled = true;
			this._lblMatrix_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblMatrix_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblMatrix_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblMatrix_0.UseMnemonic = true;
			this._lblMatrix_0.Visible = true;
			this._lblMatrix_0.AutoSize = false;
			this._lblMatrix_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblMatrix_0.Name = "_lblMatrix_0";
			this._lblDepositUnit_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblDepositUnit_0.Text = "10.00";
			this._lblDepositUnit_0.Size = new System.Drawing.Size(88, 13);
			this._lblDepositUnit_0.Location = new System.Drawing.Point(6, 78);
			this._lblDepositUnit_0.TabIndex = 25;
			this._lblDepositUnit_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblDepositUnit_0.Enabled = true;
			this._lblDepositUnit_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDepositUnit_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblDepositUnit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDepositUnit_0.UseMnemonic = true;
			this._lblDepositUnit_0.Visible = true;
			this._lblDepositUnit_0.AutoSize = false;
			this._lblDepositUnit_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblDepositUnit_0.Name = "_lblDepositUnit_0";
			this._lblDepositPack_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblDepositPack_0.Text = "15.00";
			this._lblDepositPack_0.Size = new System.Drawing.Size(88, 13);
			this._lblDepositPack_0.Location = new System.Drawing.Point(6, 96);
			this._lblDepositPack_0.TabIndex = 24;
			this._lblDepositPack_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblDepositPack_0.Enabled = true;
			this._lblDepositPack_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDepositPack_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblDepositPack_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDepositPack_0.UseMnemonic = true;
			this._lblDepositPack_0.Visible = true;
			this._lblDepositPack_0.AutoSize = false;
			this._lblDepositPack_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblDepositPack_0.Name = "_lblDepositPack_0";
			this._lblVat_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblVat_0.Text = "lblVat";
			this._lblVat_0.Size = new System.Drawing.Size(88, 13);
			this._lblVat_0.Location = new System.Drawing.Point(6, 114);
			this._lblVat_0.TabIndex = 23;
			this._lblVat_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblVat_0.Enabled = true;
			this._lblVat_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblVat_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblVat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblVat_0.UseMnemonic = true;
			this._lblVat_0.Visible = true;
			this._lblVat_0.AutoSize = false;
			this._lblVat_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblVat_0.Name = "_lblVat_0";
			this._lblMarkup_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblMarkup_0.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			this._lblMarkup_0.Text = "lblMarkup";
			this._lblMarkup_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblMarkup_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblMarkup_0.Size = new System.Drawing.Size(88, 16);
			this._lblMarkup_0.Location = new System.Drawing.Point(6, 132);
			this._lblMarkup_0.TabIndex = 22;
			this._lblMarkup_0.Enabled = true;
			this._lblMarkup_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblMarkup_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblMarkup_0.UseMnemonic = true;
			this._lblMarkup_0.Visible = true;
			this._lblMarkup_0.AutoSize = false;
			this._lblMarkup_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblMarkup_0.Name = "_lblMarkup_0";
			this._lblPrice_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblPrice_0.BackColor = System.Drawing.Color.Red;
			this._lblPrice_0.Text = "lblPrice";
			this._lblPrice_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblPrice_0.ForeColor = System.Drawing.Color.White;
			this._lblPrice_0.Size = new System.Drawing.Size(88, 16);
			this._lblPrice_0.Location = new System.Drawing.Point(6, 171);
			this._lblPrice_0.TabIndex = 21;
			this._lblPrice_0.Enabled = true;
			this._lblPrice_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPrice_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPrice_0.UseMnemonic = true;
			this._lblPrice_0.Visible = true;
			this._lblPrice_0.AutoSize = false;
			this._lblPrice_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblPrice_0.Name = "_lblPrice_0";
			this._lblPercent_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblPercent_0.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._lblPercent_0.Text = "lblPercent";
			this._lblPercent_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblPercent_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblPercent_0.Size = new System.Drawing.Size(88, 16);
			this._lblPercent_0.Location = new System.Drawing.Point(6, 198);
			this._lblPercent_0.TabIndex = 20;
			this._lblPercent_0.Enabled = true;
			this._lblPercent_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPercent_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPercent_0.UseMnemonic = true;
			this._lblPercent_0.Visible = true;
			this._lblPercent_0.AutoSize = false;
			this._lblPercent_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblPercent_0.Name = "_lblPercent_0";
			this.ilGeneral.ImageSize = new System.Drawing.Size(20, 20);
			this.ilGeneral.TransparentColor = System.Drawing.Color.FromArgb(255, 0, 255);
			this.ilGeneral.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilGeneral.ImageStream");
			this.ilGeneral.Images.SetKeyName(0, "");
			this.ilGeneral.Images.SetKeyName(1, "");
			this.ilGeneral.Images.SetKeyName(2, "");
			this.ilGeneral.Images.SetKeyName(3, "");
			this.ilGeneral.Images.SetKeyName(4, "");
			this.ilGeneral.Images.SetKeyName(5, "");
			this.ilGeneral.Images.SetKeyName(6, "");
			this._lbl_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_17.Text = "Margin % ";
			this._lbl_17.Size = new System.Drawing.Size(88, 13);
			this._lbl_17.Location = new System.Drawing.Point(-3, 460);
			this._lbl_17.TabIndex = 49;
			this._lbl_17.BackColor = System.Drawing.Color.Transparent;
			this._lbl_17.Enabled = true;
			this._lbl_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_17.UseMnemonic = true;
			this._lbl_17.Visible = true;
			this._lbl_17.AutoSize = false;
			this._lbl_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_17.Name = "_lbl_17";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "GP %:";
			this._lbl_0.Size = new System.Drawing.Size(88, 13);
			this._lbl_0.Location = new System.Drawing.Point(-3, 378);
			this._lbl_0.TabIndex = 44;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblPriceSet.Text = "No Action";
			this.lblPriceSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPriceSet.Size = new System.Drawing.Size(421, 17);
			this.lblPriceSet.Location = new System.Drawing.Point(87, 525);
			this.lblPriceSet.TabIndex = 42;
			this.lblPriceSet.Visible = false;
			this.lblPriceSet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPriceSet.BackColor = System.Drawing.SystemColors.Control;
			this.lblPriceSet.Enabled = true;
			this.lblPriceSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPriceSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPriceSet.UseMnemonic = true;
			this.lblPriceSet.AutoSize = false;
			this.lblPriceSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPriceSet.Name = "lblPriceSet";
			this._lbl_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_16.Text = "Pricing Rule:";
			this._lbl_16.Size = new System.Drawing.Size(60, 13);
			this._lbl_16.Location = new System.Drawing.Point(22, 111);
			this._lbl_16.TabIndex = 35;
			this._lbl_16.BackColor = System.Drawing.Color.Transparent;
			this._lbl_16.Enabled = true;
			this._lbl_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_16.UseMnemonic = true;
			this._lbl_16.Visible = true;
			this._lbl_16.AutoSize = true;
			this._lbl_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_16.Name = "_lbl_16";
			this._lbl_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_15.Text = "Pricing Group:";
			this._lbl_15.Size = new System.Drawing.Size(67, 13);
			this._lbl_15.Location = new System.Drawing.Point(14, 90);
			this._lbl_15.TabIndex = 34;
			this._lbl_15.BackColor = System.Drawing.Color.Transparent;
			this._lbl_15.Enabled = true;
			this._lbl_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_15.UseMnemonic = true;
			this._lbl_15.Visible = true;
			this._lbl_15.AutoSize = true;
			this._lbl_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_15.Name = "_lbl_15";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "Sales Channel:";
			this._lbl_4.Size = new System.Drawing.Size(71, 13);
			this._lbl_4.Location = new System.Drawing.Point(12, 69);
			this._lbl_4.TabIndex = 33;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Enabled = true;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = true;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_4.Name = "_lbl_4";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "Stock Item:";
			this._lbl_7.Size = new System.Drawing.Size(54, 13);
			this._lbl_7.Location = new System.Drawing.Point(29, 51);
			this._lbl_7.TabIndex = 32;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = true;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this.lblStockItemName.Text = "Label1";
			this.lblStockItemName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblStockItemName.Size = new System.Drawing.Size(39, 13);
			this.lblStockItemName.Location = new System.Drawing.Point(87, 51);
			this.lblStockItemName.TabIndex = 31;
			this.lblStockItemName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStockItemName.BackColor = System.Drawing.Color.Transparent;
			this.lblStockItemName.Enabled = true;
			this.lblStockItemName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItemName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItemName.UseMnemonic = true;
			this.lblStockItemName.Visible = true;
			this.lblStockItemName.AutoSize = true;
			this.lblStockItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStockItemName.Name = "lblStockItemName";
			this.lblPricingGroupRule.Text = "Label1";
			this.lblPricingGroupRule.Size = new System.Drawing.Size(421, 43);
			this.lblPricingGroupRule.Location = new System.Drawing.Point(87, 108);
			this.lblPricingGroupRule.TabIndex = 30;
			this.lblPricingGroupRule.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPricingGroupRule.BackColor = System.Drawing.SystemColors.Control;
			this.lblPricingGroupRule.Enabled = true;
			this.lblPricingGroupRule.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPricingGroupRule.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPricingGroupRule.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPricingGroupRule.UseMnemonic = true;
			this.lblPricingGroupRule.Visible = true;
			this.lblPricingGroupRule.AutoSize = false;
			this.lblPricingGroupRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPricingGroupRule.Name = "lblPricingGroupRule";
			this.lblPricingGroup.Text = "Label1";
			this.lblPricingGroup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPricingGroup.Size = new System.Drawing.Size(39, 13);
			this.lblPricingGroup.Location = new System.Drawing.Point(87, 90);
			this.lblPricingGroup.TabIndex = 29;
			this.lblPricingGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPricingGroup.BackColor = System.Drawing.Color.Transparent;
			this.lblPricingGroup.Enabled = true;
			this.lblPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPricingGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPricingGroup.UseMnemonic = true;
			this.lblPricingGroup.Visible = true;
			this.lblPricingGroup.AutoSize = true;
			this.lblPricingGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPricingGroup.Name = "lblPricingGroup";
			this._lbl_18.Text = "Actual";
			this._lbl_18.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_18.Size = new System.Drawing.Size(37, 13);
			this._lbl_18.Location = new System.Drawing.Point(3, 390);
			this._lbl_18.TabIndex = 6;
			this._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_18.BackColor = System.Drawing.Color.Transparent;
			this._lbl_18.Enabled = true;
			this._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_18.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_18.UseMnemonic = true;
			this._lbl_18.Visible = true;
			this._lbl_18.AutoSize = true;
			this._lbl_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_18.Name = "_lbl_18";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_1.Text = "List Cost:";
			this._lbl_1.Size = new System.Drawing.Size(88, 13);
			this._lbl_1.Location = new System.Drawing.Point(-3, 180);
			this._lbl_1.TabIndex = 19;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = false;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "Unit Deposit:";
			this._lbl_2.Size = new System.Drawing.Size(88, 13);
			this._lbl_2.Location = new System.Drawing.Point(-3, 237);
			this._lbl_2.TabIndex = 18;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = false;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_3.Text = "Case Deposit:";
			this._lbl_3.Size = new System.Drawing.Size(88, 13);
			this._lbl_3.Location = new System.Drawing.Point(-3, 255);
			this._lbl_3.TabIndex = 17;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = false;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_5.Text = "Matrix %";
			this._lbl_5.Size = new System.Drawing.Size(88, 13);
			this._lbl_5.Location = new System.Drawing.Point(-3, 198);
			this._lbl_5.TabIndex = 16;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = false;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_6.Text = "Prop %";
			this._lbl_6.Size = new System.Drawing.Size(88, 13);
			this._lbl_6.Location = new System.Drawing.Point(-3, 219);
			this._lbl_6.TabIndex = 15;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Enabled = true;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.UseMnemonic = true;
			this._lbl_6.Visible = true;
			this._lbl_6.AutoSize = false;
			this._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_6.Name = "_lbl_6";
			this.lblVatName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblVatName.Text = "VAT at 14%";
			this.lblVatName.Size = new System.Drawing.Size(88, 13);
			this.lblVatName.Location = new System.Drawing.Point(-3, 273);
			this.lblVatName.TabIndex = 14;
			this.lblVatName.BackColor = System.Drawing.Color.Transparent;
			this.lblVatName.Enabled = true;
			this.lblVatName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVatName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVatName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVatName.UseMnemonic = true;
			this.lblVatName.Visible = true;
			this.lblVatName.AutoSize = false;
			this.lblVatName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblVatName.Name = "lblVatName";
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_8.Text = "Markup Price:";
			this._lbl_8.Size = new System.Drawing.Size(88, 13);
			this._lbl_8.Location = new System.Drawing.Point(-3, 294);
			this._lbl_8.TabIndex = 13;
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Enabled = true;
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.UseMnemonic = true;
			this._lbl_8.Visible = true;
			this._lbl_8.AutoSize = false;
			this._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_8.Name = "_lbl_8";
			this._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_9.Text = "Override Price:";
			this._lbl_9.Size = new System.Drawing.Size(88, 13);
			this._lbl_9.Location = new System.Drawing.Point(-3, 312);
			this._lbl_9.TabIndex = 12;
			this._lbl_9.BackColor = System.Drawing.Color.Transparent;
			this._lbl_9.Enabled = true;
			this._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_9.UseMnemonic = true;
			this._lbl_9.Visible = true;
			this._lbl_9.AutoSize = false;
			this._lbl_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_9.Name = "_lbl_9";
			this._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_10.Text = "Price:";
			this._lbl_10.Size = new System.Drawing.Size(88, 13);
			this._lbl_10.Location = new System.Drawing.Point(-3, 333);
			this._lbl_10.TabIndex = 11;
			this._lbl_10.BackColor = System.Drawing.Color.Transparent;
			this._lbl_10.Enabled = true;
			this._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_10.UseMnemonic = true;
			this._lbl_10.Visible = true;
			this._lbl_10.AutoSize = false;
			this._lbl_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_10.Name = "_lbl_10";
			this._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_11.Text = "Markup %:";
			this._lbl_11.Size = new System.Drawing.Size(88, 13);
			this._lbl_11.Location = new System.Drawing.Point(-3, 360);
			this._lbl_11.TabIndex = 10;
			this._lbl_11.BackColor = System.Drawing.Color.Transparent;
			this._lbl_11.Enabled = true;
			this._lbl_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_11.UseMnemonic = true;
			this._lbl_11.Visible = true;
			this._lbl_11.AutoSize = false;
			this._lbl_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_11.Name = "_lbl_11";
			this._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_12.Text = "Actual Cost:";
			this._lbl_12.Size = new System.Drawing.Size(88, 13);
			this._lbl_12.Location = new System.Drawing.Point(-3, 405);
			this._lbl_12.TabIndex = 9;
			this._lbl_12.BackColor = System.Drawing.Color.Transparent;
			this._lbl_12.Enabled = true;
			this._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_12.UseMnemonic = true;
			this._lbl_12.Visible = true;
			this._lbl_12.AutoSize = false;
			this._lbl_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_12.Name = "_lbl_12";
			this._lbl_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_13.Text = "Profit Amount:";
			this._lbl_13.Size = new System.Drawing.Size(88, 13);
			this._lbl_13.Location = new System.Drawing.Point(-3, 423);
			this._lbl_13.TabIndex = 8;
			this._lbl_13.BackColor = System.Drawing.Color.Transparent;
			this._lbl_13.Enabled = true;
			this._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_13.UseMnemonic = true;
			this._lbl_13.Visible = true;
			this._lbl_13.AutoSize = false;
			this._lbl_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_13.Name = "_lbl_13";
			this._lbl_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_14.Text = "Markup % ";
			this._lbl_14.Size = new System.Drawing.Size(88, 13);
			this._lbl_14.Location = new System.Drawing.Point(-3, 441);
			this._lbl_14.TabIndex = 7;
			this._lbl_14.BackColor = System.Drawing.Color.Transparent;
			this._lbl_14.Enabled = true;
			this._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_14.UseMnemonic = true;
			this._lbl_14.Visible = true;
			this._lbl_14.AutoSize = false;
			this._lbl_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_14.Name = "_lbl_14";
			this._Line1_3.X1 = 81;
			this._Line1_3.X2 = 45;
			this._Line1_3.Y1 = 396;
			this._Line1_3.Y2 = 396;
			this._Line1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Line1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Line1_3.BorderWidth = 1;
			this._Line1_3.Visible = true;
			this._Line1_3.Name = "_Line1_3";
			this.Controls.Add(txttemphold);
			this.Controls.Add(picButtons);
			this.Controls.Add(cmbChannel);
			this.Controls.Add(_frmItem_0);
			this.Controls.Add(_lbl_17);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblPriceSet);
			this.Controls.Add(_lbl_16);
			this.Controls.Add(_lbl_15);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lbl_7);
			this.Controls.Add(lblStockItemName);
			this.Controls.Add(lblPricingGroupRule);
			this.Controls.Add(lblPricingGroup);
			this.Controls.Add(_lbl_18);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(_lbl_6);
			this.Controls.Add(lblVatName);
			this.Controls.Add(_lbl_8);
			this.Controls.Add(_lbl_9);
			this.Controls.Add(_lbl_10);
			this.Controls.Add(_lbl_11);
			this.Controls.Add(_lbl_12);
			this.Controls.Add(_lbl_13);
			this.Controls.Add(_lbl_14);
			this.ShapeContainer1.Shapes.Add(_Line1_3);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdNext);
			this.picButtons.Controls.Add(cmdbarcode);
			this.picButtons.Controls.Add(cmdHistory);
			this.picButtons.Controls.Add(cmdDetails);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(cmdUndo);
			this._frmItem_0.Controls.Add(_picLine_0);
			this._frmItem_0.Controls.Add(_txtCost_0);
			this._frmItem_0.Controls.Add(_txtProp_0);
			this._frmItem_0.Controls.Add(_txtPrice_0);
			this._frmItem_0.Controls.Add(_txtVariableCost_0);
			this._frmItem_0.Controls.Add(_lblGPActual_0);
			this._frmItem_0.Controls.Add(_lblGP_0);
			this._frmItem_0.Controls.Add(_lblSection_0);
			this.ShapeContainer2.Shapes.Add(_lnProfit_0);
			this._frmItem_0.Controls.Add(_lblProfitPrecent_0);
			this._frmItem_0.Controls.Add(_lblProfitAmount_0);
			this._frmItem_0.Controls.Add(_lblMatrix_0);
			this._frmItem_0.Controls.Add(_lblDepositUnit_0);
			this._frmItem_0.Controls.Add(_lblDepositPack_0);
			this._frmItem_0.Controls.Add(_lblVat_0);
			this._frmItem_0.Controls.Add(_lblMarkup_0);
			this._frmItem_0.Controls.Add(_lblPrice_0);
			this._frmItem_0.Controls.Add(_lblPercent_0);
			this._frmItem_0.Controls.Add(ShapeContainer2);
			//Me.Line1.SetIndex(_Line1_3, CType(3, Short))
			//Me.frmItem.SetIndex(_frmItem_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_17, CType(17, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_16, CType(16, Short))
			//Me.lbl.SetIndex(_lbl_15, CType(15, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_18, CType(18, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_6, CType(6, Short))
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_9, CType(9, Short))
			//Me.lbl.SetIndex(_lbl_10, CType(10, Short))
			//Me.lbl.SetIndex(_lbl_11, CType(11, Short))
			//Me.lbl.SetIndex(_lbl_12, CType(12, Short))
			//Me.lbl.SetIndex(_lbl_13, CType(13, Short))
			//Me.lbl.SetIndex(_lbl_14, CType(14, Short))
			//Me.lblDepositPack.SetIndex(_lblDepositPack_0, CType(0, Short))
			//Me.lblDepositUnit.SetIndex(_lblDepositUnit_0, CType(0, Short))
			//Me.lblGP.SetIndex(_lblGP_0, CType(0, Short))
			//Me.lblGPActual.SetIndex(_lblGPActual_0, CType(0, Short))
			//Me.lblMarkup.SetIndex(_lblMarkup_0, CType(0, Short))
			//Me.lblMatrix.SetIndex(_lblMatrix_0, CType(0, Short))
			//Me.lblPercent.SetIndex(_lblPercent_0, CType(0, Short))
			//Me.lblPrice.SetIndex(_lblPrice_0, CType(0, Short))
			//Me.lblProfitAmount.SetIndex(_lblProfitAmount_0, CType(0, Short))
			//Me.lblProfitPrecent.SetIndex(_lblProfitPrecent_0, CType(0, Short))
			//Me.lblSection.SetIndex(_lblSection_0, CType(0, Short))
			//Me.lblVat.SetIndex(_lblVat_0, CType(0, Short))
			this.lnProfit.SetIndex(_lnProfit_0, Convert.ToInt16(0));
			//Me.picLine.SetIndex(_picLine_0, CType(0, Short))
			//Me.txtCost.SetIndex(_txtCost_0, CType(0, Short))
			//Me.txtPrice.SetIndex(_txtPrice_0, CType(0, Short))
			//Me.txtProp.SetIndex(_txtProp_0, CType(0, Short))
			//Me.txtVariableCost.SetIndex(_txtVariableCost_0, CType(0, Short))
			//CType(Me.txtVariableCost, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtProp, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtPrice, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtCost, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.picLine, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.lnProfit).EndInit();
			//CType(Me.lblVat, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblSection, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblProfitPrecent, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblProfitAmount, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblPrice, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblPercent, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblMatrix, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblMarkup, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblGPActual, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblGP, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblDepositUnit, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblDepositPack, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmItem, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.Line1).EndInit();
			this.picButtons.ResumeLayout(false);
			this._frmItem_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
