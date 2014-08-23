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
	partial class frmGRVSummary
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVSummary() : base()
		{
			Load += frmGRVSummary_Load;
			FormClosed += frmGRVSummary_FormClosed;
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
		private System.Windows.Forms.Timer withEventsField_tmrAutoGRV;
		public System.Windows.Forms.Timer tmrAutoGRV {
			get { return withEventsField_tmrAutoGRV; }
			set {
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick -= tmrAutoGRV_Tick;
				}
				withEventsField_tmrAutoGRV = value;
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick += tmrAutoGRV_Tick;
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
		private System.Windows.Forms.Panel withEventsField_Picture2;
		public System.Windows.Forms.Panel Picture2 {
			get { return withEventsField_Picture2; }
			set {
				if (withEventsField_Picture2 != null) {
					withEventsField_Picture2.Resize -= Picture2_Resize;
				}
				withEventsField_Picture2 = value;
				if (withEventsField_Picture2 != null) {
					withEventsField_Picture2.Resize += Picture2_Resize;
				}
			}
		}
		public System.Windows.Forms.TextBox txtNotes;
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
		public System.Windows.Forms.RadioButton _optClose_0;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.GroupBox frmProcess;
		public System.Windows.Forms.Label lblDepositReturnIn;
		public System.Windows.Forms.Label _lbl_35;
		public System.Windows.Forms.Label lblDepositReturnVatIn;
		public System.Windows.Forms.Label _lbl_34;
		public System.Windows.Forms.Label lblDepositReturnInclusiveIn;
		public System.Windows.Forms.Label _lbl_33;
		public System.Windows.Forms.Label lblDepositReturnVatRateIn;
		public System.Windows.Forms.GroupBox _Frame1_5;
		public System.Windows.Forms.Label lblContentOut;
		public System.Windows.Forms.Label lblDiscountLineOut;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label lblExclusiveOut;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label lblVATout;
		public System.Windows.Forms.Label _lbl_12;
		public System.Windows.Forms.Label lblInclusiveOut;
		public System.Windows.Forms.Label lblVatRateOut;
		public System.Windows.Forms.Label _lbl_37;
		public System.Windows.Forms.Label lblLinesOut;
		public System.Windows.Forms.GroupBox _Frame1_3;
		public System.Windows.Forms.Label lblDepositVatRateOut;
		public System.Windows.Forms.Label lblDepositOut;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label lblDepositVatOut;
		public System.Windows.Forms.Label _lbl_23;
		public System.Windows.Forms.Label lblDepositInclusiveOut;
		public System.Windows.Forms.Label _lbl_24;
		public System.Windows.Forms.GroupBox _Frame1_4;
		public System.Windows.Forms.Label lblDepositReturnVatRateOut;
		public System.Windows.Forms.Label _lbl_15;
		public System.Windows.Forms.Label lblDepositReturnInclusiveOut;
		public System.Windows.Forms.Label _lbl_16;
		public System.Windows.Forms.Label lblDepositReturnVatOut;
		public System.Windows.Forms.Label _lbl_17;
		public System.Windows.Forms.Label lblDepositReturnOut;
		public System.Windows.Forms.GroupBox _Frame1_2;
		private System.Windows.Forms.ComboBox withEventsField_cmbPayment;
		public System.Windows.Forms.ComboBox cmbPayment {
			get { return withEventsField_cmbPayment; }
			set {
				if (withEventsField_cmbPayment != null) {
					withEventsField_cmbPayment.SelectedIndexChanged -= cmbPayment_SelectedIndexChanged;
				}
				withEventsField_cmbPayment = value;
				if (withEventsField_cmbPayment != null) {
					withEventsField_cmbPayment.SelectedIndexChanged += cmbPayment_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtUllage;
		public System.Windows.Forms.TextBox txtUllage {
			get { return withEventsField_txtUllage; }
			set {
				if (withEventsField_txtUllage != null) {
					withEventsField_txtUllage.Enter -= txtUllage_Enter;
					withEventsField_txtUllage.KeyPress -= txtUllage_KeyPress;
					withEventsField_txtUllage.Leave -= txtUllage_Leave;
				}
				withEventsField_txtUllage = value;
				if (withEventsField_txtUllage != null) {
					withEventsField_txtUllage.Enter += txtUllage_Enter;
					withEventsField_txtUllage.KeyPress += txtUllage_KeyPress;
					withEventsField_txtUllage.Leave += txtUllage_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtDiscount;
		public System.Windows.Forms.TextBox txtDiscount {
			get { return withEventsField_txtDiscount; }
			set {
				if (withEventsField_txtDiscount != null) {
					withEventsField_txtDiscount.Enter -= txtDiscount_Enter;
					withEventsField_txtDiscount.KeyPress -= txtDiscount_KeyPress;
					withEventsField_txtDiscount.Leave -= txtDiscount_Leave;
				}
				withEventsField_txtDiscount = value;
				if (withEventsField_txtDiscount != null) {
					withEventsField_txtDiscount.Enter += txtDiscount_Enter;
					withEventsField_txtDiscount.KeyPress += txtDiscount_KeyPress;
					withEventsField_txtDiscount.Leave += txtDiscount_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtMinus;
		public System.Windows.Forms.TextBox txtMinus {
			get { return withEventsField_txtMinus; }
			set {
				if (withEventsField_txtMinus != null) {
					withEventsField_txtMinus.Enter -= txtMinus_Enter;
					withEventsField_txtMinus.KeyPress -= txtMinus_KeyPress;
					withEventsField_txtMinus.Leave -= txtMinus_Leave;
				}
				withEventsField_txtMinus = value;
				if (withEventsField_txtMinus != null) {
					withEventsField_txtMinus.Enter += txtMinus_Enter;
					withEventsField_txtMinus.KeyPress += txtMinus_KeyPress;
					withEventsField_txtMinus.Leave += txtMinus_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtPlus;
		public System.Windows.Forms.TextBox txtPlus {
			get { return withEventsField_txtPlus; }
			set {
				if (withEventsField_txtPlus != null) {
					withEventsField_txtPlus.Enter -= txtPlus_Enter;
					withEventsField_txtPlus.KeyPress -= txtPlus_KeyPress;
					withEventsField_txtPlus.Leave -= txtPlus_Leave;
				}
				withEventsField_txtPlus = value;
				if (withEventsField_txtPlus != null) {
					withEventsField_txtPlus.Enter += txtPlus_Enter;
					withEventsField_txtPlus.KeyPress += txtPlus_KeyPress;
					withEventsField_txtPlus.Leave += txtPlus_Leave;
				}
			}
		}
		public System.Windows.Forms.Label lblContentIn;
		public System.Windows.Forms.Label lblDiscountLineIn;
		public System.Windows.Forms.Label _lbl_20;
		public System.Windows.Forms.Label _lbl_21;
		public System.Windows.Forms.Label lblExclusiveIn;
		public System.Windows.Forms.Label _lbl_22;
		public System.Windows.Forms.Label _lbl_29;
		public System.Windows.Forms.Label lblVATin;
		public System.Windows.Forms.Label _lbl_30;
		public System.Windows.Forms.Label lblInclusiveIn;
		public System.Windows.Forms.Label lblVatRateIn;
		public System.Windows.Forms.Label _lbl_19;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label lblDiscount;
		public System.Windows.Forms.Label lblUllage;
		public System.Windows.Forms.Label lblDiscountName;
		public System.Windows.Forms.Label _lbl_31;
		public System.Windows.Forms.Label lblContentExclusiveIn;
		public System.Windows.Forms.Label _lbl_11;
		public System.Windows.Forms.Label _lbl_10;
		public System.Windows.Forms.Label _lbl_32;
		public System.Windows.Forms.Label lblLinesIn;
		public System.Windows.Forms.GroupBox _Frame1_0;
		public System.Windows.Forms.Label lblDepositVatRateIn;
		public System.Windows.Forms.Label lblDepositIn;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label lblDepositVatIn;
		public System.Windows.Forms.Label _lbl_13;
		public System.Windows.Forms.Label lblDepositInclusiveIn;
		public System.Windows.Forms.Label _lbl_14;
		public System.Windows.Forms.GroupBox _Frame1_1;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line2;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label _lbl_28;
		public System.Windows.Forms.Label lblInBoundVat;
		public System.Windows.Forms.Label _lbl_27;
		public System.Windows.Forms.Label lblInBound;
		public System.Windows.Forms.Label _lbl_26;
		public System.Windows.Forms.Label lblCreditVat;
		public System.Windows.Forms.Label _lbl_25;
		public System.Windows.Forms.Label lblCredit;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label lblOutBoundVat;
		public System.Windows.Forms.Label lblOutBound;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label lblTotal;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblTotalOriginal;
		public System.Windows.Forms.Label lblDifference;
		public System.Windows.Forms.Label _lbl_18;
		public System.Windows.Forms.GroupBox frmMain;
		public System.Windows.Forms.Label lblSupplier;
		public System.Windows.Forms.Panel Picture1;
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optClose As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.Line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.tmrAutoGRV = new System.Windows.Forms.Timer(this.components);
			this.Picture2 = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.frmProcess = new System.Windows.Forms.GroupBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.cmdNext = new System.Windows.Forms.Button();
			this._optClose_0 = new System.Windows.Forms.RadioButton();
			this.Label3 = new System.Windows.Forms.Label();
			this.frmMain = new System.Windows.Forms.GroupBox();
			this._Frame1_5 = new System.Windows.Forms.GroupBox();
			this.lblDepositReturnIn = new System.Windows.Forms.Label();
			this._lbl_35 = new System.Windows.Forms.Label();
			this.lblDepositReturnVatIn = new System.Windows.Forms.Label();
			this._lbl_34 = new System.Windows.Forms.Label();
			this.lblDepositReturnInclusiveIn = new System.Windows.Forms.Label();
			this._lbl_33 = new System.Windows.Forms.Label();
			this.lblDepositReturnVatRateIn = new System.Windows.Forms.Label();
			this._Frame1_3 = new System.Windows.Forms.GroupBox();
			this.lblContentOut = new System.Windows.Forms.Label();
			this.lblDiscountLineOut = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this.lblExclusiveOut = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.lblVATout = new System.Windows.Forms.Label();
			this._lbl_12 = new System.Windows.Forms.Label();
			this.lblInclusiveOut = new System.Windows.Forms.Label();
			this.lblVatRateOut = new System.Windows.Forms.Label();
			this._lbl_37 = new System.Windows.Forms.Label();
			this.lblLinesOut = new System.Windows.Forms.Label();
			this._Frame1_4 = new System.Windows.Forms.GroupBox();
			this.lblDepositVatRateOut = new System.Windows.Forms.Label();
			this.lblDepositOut = new System.Windows.Forms.Label();
			this._lbl_9 = new System.Windows.Forms.Label();
			this.lblDepositVatOut = new System.Windows.Forms.Label();
			this._lbl_23 = new System.Windows.Forms.Label();
			this.lblDepositInclusiveOut = new System.Windows.Forms.Label();
			this._lbl_24 = new System.Windows.Forms.Label();
			this._Frame1_2 = new System.Windows.Forms.GroupBox();
			this.lblDepositReturnVatRateOut = new System.Windows.Forms.Label();
			this._lbl_15 = new System.Windows.Forms.Label();
			this.lblDepositReturnInclusiveOut = new System.Windows.Forms.Label();
			this._lbl_16 = new System.Windows.Forms.Label();
			this.lblDepositReturnVatOut = new System.Windows.Forms.Label();
			this._lbl_17 = new System.Windows.Forms.Label();
			this.lblDepositReturnOut = new System.Windows.Forms.Label();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.cmbPayment = new System.Windows.Forms.ComboBox();
			this.txtUllage = new System.Windows.Forms.TextBox();
			this.txtDiscount = new System.Windows.Forms.TextBox();
			this.txtMinus = new System.Windows.Forms.TextBox();
			this.txtPlus = new System.Windows.Forms.TextBox();
			this.lblContentIn = new System.Windows.Forms.Label();
			this.lblDiscountLineIn = new System.Windows.Forms.Label();
			this._lbl_20 = new System.Windows.Forms.Label();
			this._lbl_21 = new System.Windows.Forms.Label();
			this.lblExclusiveIn = new System.Windows.Forms.Label();
			this._lbl_22 = new System.Windows.Forms.Label();
			this._lbl_29 = new System.Windows.Forms.Label();
			this.lblVATin = new System.Windows.Forms.Label();
			this._lbl_30 = new System.Windows.Forms.Label();
			this.lblInclusiveIn = new System.Windows.Forms.Label();
			this.lblVatRateIn = new System.Windows.Forms.Label();
			this._lbl_19 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.lblDiscount = new System.Windows.Forms.Label();
			this.lblUllage = new System.Windows.Forms.Label();
			this.lblDiscountName = new System.Windows.Forms.Label();
			this._lbl_31 = new System.Windows.Forms.Label();
			this.lblContentExclusiveIn = new System.Windows.Forms.Label();
			this._lbl_11 = new System.Windows.Forms.Label();
			this._lbl_10 = new System.Windows.Forms.Label();
			this._lbl_32 = new System.Windows.Forms.Label();
			this.lblLinesIn = new System.Windows.Forms.Label();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this.lblDepositVatRateIn = new System.Windows.Forms.Label();
			this.lblDepositIn = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.lblDepositVatIn = new System.Windows.Forms.Label();
			this._lbl_13 = new System.Windows.Forms.Label();
			this.lblDepositInclusiveIn = new System.Windows.Forms.Label();
			this._lbl_14 = new System.Windows.Forms.Label();
			this._lbl_28 = new System.Windows.Forms.Label();
			this.lblInBoundVat = new System.Windows.Forms.Label();
			this._lbl_27 = new System.Windows.Forms.Label();
			this.lblInBound = new System.Windows.Forms.Label();
			this._lbl_26 = new System.Windows.Forms.Label();
			this.lblCreditVat = new System.Windows.Forms.Label();
			this._lbl_25 = new System.Windows.Forms.Label();
			this.lblCredit = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this.lblOutBoundVat = new System.Windows.Forms.Label();
			this.lblOutBound = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblTotalOriginal = new System.Windows.Forms.Label();
			this.lblDifference = new System.Windows.Forms.Label();
			this._lbl_18 = new System.Windows.Forms.Label();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.lblSupplier = new System.Windows.Forms.Label();
			this.Picture2.SuspendLayout();
			this.frmProcess.SuspendLayout();
			this.frmMain.SuspendLayout();
			this._Frame1_5.SuspendLayout();
			this._Frame1_3.SuspendLayout();
			this._Frame1_4.SuspendLayout();
			this._Frame1_2.SuspendLayout();
			this._Frame1_0.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this.Picture1.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 13);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Line2,
				this.Line1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(631, 537);
			this.ShapeContainer1.TabIndex = 95;
			this.ShapeContainer1.TabStop = false;
			//
			//Line2
			//
			this.Line2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Name = "Line2";
			this.Line2.X1 = 620;
			this.Line2.X2 = 24;
			this.Line2.Y1 = 485;
			this.Line2.Y2 = 485;
			//
			//Line1
			//
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Name = "Line1";
			this.Line1.X1 = 620;
			this.Line1.X2 = 24;
			this.Line1.Y1 = 482;
			this.Line1.Y2 = 482;
			//
			//tmrAutoGRV
			//
			this.tmrAutoGRV.Interval = 10;
			//
			//Picture2
			//
			this.Picture2.BackColor = System.Drawing.Color.Blue;
			this.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture2.Controls.Add(this.cmdExit);
			this.Picture2.Controls.Add(this.cmdBack);
			this.Picture2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture2.Location = new System.Drawing.Point(0, 25);
			this.Picture2.Name = "Picture2";
			this.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture2.Size = new System.Drawing.Size(760, 49);
			this.Picture2.TabIndex = 102;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(627, 3);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(73, 40);
			this.cmdExit.TabIndex = 104;
			this.cmdExit.TabStop = false;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//cmdBack
			//
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Location = new System.Drawing.Point(426, 3);
			this.cmdBack.Name = "cmdBack";
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Size = new System.Drawing.Size(73, 40);
			this.cmdBack.TabIndex = 103;
			this.cmdBack.TabStop = false;
			this.cmdBack.Text = "<< &Back";
			this.cmdBack.UseVisualStyleBackColor = false;
			//
			//frmProcess
			//
			this.frmProcess.BackColor = System.Drawing.SystemColors.Control;
			this.frmProcess.Controls.Add(this.txtNotes);
			this.frmProcess.Controls.Add(this.cmdNext);
			this.frmProcess.Controls.Add(this._optClose_0);
			this.frmProcess.Controls.Add(this.Label3);
			this.frmProcess.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmProcess.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmProcess.Location = new System.Drawing.Point(657, 363);
			this.frmProcess.Name = "frmProcess";
			this.frmProcess.Padding = new System.Windows.Forms.Padding(0);
			this.frmProcess.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmProcess.Size = new System.Drawing.Size(343, 271);
			this.frmProcess.TabIndex = 3;
			this.frmProcess.TabStop = false;
			this.frmProcess.Text = "Process this 'Goods Receiving Voucher'";
			//
			//txtNotes
			//
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.BackColor = System.Drawing.SystemColors.Window;
			this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNotes.Location = new System.Drawing.Point(21, 102);
			this.txtNotes.MaxLength = 255;
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNotes.Size = new System.Drawing.Size(301, 85);
			this.txtNotes.TabIndex = 6;
			this.txtNotes.Text = "txtNotes";
			//
			//cmdNext
			//
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Location = new System.Drawing.Point(183, 198);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Size = new System.Drawing.Size(139, 55);
			this.cmdNext.TabIndex = 7;
			this.cmdNext.Text = "P&rocess";
			this.cmdNext.UseVisualStyleBackColor = false;
			//
			//_optClose_0
			//
			this._optClose_0.BackColor = System.Drawing.SystemColors.Control;
			this._optClose_0.Checked = true;
			this._optClose_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optClose_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optClose_0.Location = new System.Drawing.Point(18, 18);
			this._optClose_0.Name = "_optClose_0";
			this._optClose_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optClose_0.Size = new System.Drawing.Size(310, 19);
			this._optClose_0.TabIndex = 4;
			this._optClose_0.TabStop = true;
			this._optClose_0.Text = "This Purchase Order has been delivered in full.";
			this._optClose_0.UseVisualStyleBackColor = false;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(21, 84);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(42, 14);
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Notes:";
			//
			//frmMain
			//
			this.frmMain.BackColor = System.Drawing.SystemColors.Control;
			this.frmMain.Controls.Add(this._Frame1_5);
			this.frmMain.Controls.Add(this._Frame1_3);
			this.frmMain.Controls.Add(this._Frame1_4);
			this.frmMain.Controls.Add(this._Frame1_2);
			this.frmMain.Controls.Add(this._Frame1_0);
			this.frmMain.Controls.Add(this._Frame1_1);
			this.frmMain.Controls.Add(this._lbl_28);
			this.frmMain.Controls.Add(this.lblInBoundVat);
			this.frmMain.Controls.Add(this._lbl_27);
			this.frmMain.Controls.Add(this.lblInBound);
			this.frmMain.Controls.Add(this._lbl_26);
			this.frmMain.Controls.Add(this.lblCreditVat);
			this.frmMain.Controls.Add(this._lbl_25);
			this.frmMain.Controls.Add(this.lblCredit);
			this.frmMain.Controls.Add(this._lbl_8);
			this.frmMain.Controls.Add(this.lblOutBoundVat);
			this.frmMain.Controls.Add(this.lblOutBound);
			this.frmMain.Controls.Add(this._lbl_6);
			this.frmMain.Controls.Add(this.lblTotal);
			this.frmMain.Controls.Add(this._lbl_7);
			this.frmMain.Controls.Add(this._lbl_0);
			this.frmMain.Controls.Add(this.lblTotalOriginal);
			this.frmMain.Controls.Add(this.lblDifference);
			this.frmMain.Controls.Add(this._lbl_18);
			this.frmMain.Controls.Add(this.ShapeContainer1);
			this.frmMain.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmMain.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmMain.Location = new System.Drawing.Point(3, 84);
			this.frmMain.Name = "frmMain";
			this.frmMain.Padding = new System.Windows.Forms.Padding(0);
			this.frmMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmMain.Size = new System.Drawing.Size(631, 550);
			this.frmMain.TabIndex = 11;
			this.frmMain.TabStop = false;
			this.frmMain.Text = "fmHeading";
			//
			//_Frame1_5
			//
			this._Frame1_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Frame1_5.Controls.Add(this.lblDepositReturnIn);
			this._Frame1_5.Controls.Add(this._lbl_35);
			this._Frame1_5.Controls.Add(this.lblDepositReturnVatIn);
			this._Frame1_5.Controls.Add(this._lbl_34);
			this._Frame1_5.Controls.Add(this.lblDepositReturnInclusiveIn);
			this._Frame1_5.Controls.Add(this._lbl_33);
			this._Frame1_5.Controls.Add(this.lblDepositReturnVatRateIn);
			this._Frame1_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_5.Location = new System.Drawing.Point(9, 375);
			this._Frame1_5.Name = "_Frame1_5";
			this._Frame1_5.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_5.Size = new System.Drawing.Size(301, 79);
			this._Frame1_5.TabIndex = 94;
			this._Frame1_5.TabStop = false;
			this._Frame1_5.Text = "Purchased Deposits";
			//
			//lblDepositReturnIn
			//
			this.lblDepositReturnIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnIn.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnIn.Location = new System.Drawing.Point(150, 18);
			this.lblDepositReturnIn.Name = "lblDepositReturnIn";
			this.lblDepositReturnIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnIn.Size = new System.Drawing.Size(91, 17);
			this.lblDepositReturnIn.TabIndex = 101;
			this.lblDepositReturnIn.Text = "0.00";
			this.lblDepositReturnIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_35
			//
			this._lbl_35.BackColor = System.Drawing.Color.Transparent;
			this._lbl_35.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_35.ForeColor = System.Drawing.Color.Black;
			this._lbl_35.Location = new System.Drawing.Point(16, 21);
			this._lbl_35.Name = "_lbl_35";
			this._lbl_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_35.Size = new System.Drawing.Size(133, 13);
			this._lbl_35.TabIndex = 100;
			this._lbl_35.Text = "Deposit Value:";
			this._lbl_35.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnVatIn
			//
			this.lblDepositReturnVatIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnVatIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnVatIn.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnVatIn.Location = new System.Drawing.Point(150, 36);
			this.lblDepositReturnVatIn.Name = "lblDepositReturnVatIn";
			this.lblDepositReturnVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnVatIn.Size = new System.Drawing.Size(91, 17);
			this.lblDepositReturnVatIn.TabIndex = 99;
			this.lblDepositReturnVatIn.Text = "0.00";
			this.lblDepositReturnVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_34
			//
			this._lbl_34.BackColor = System.Drawing.Color.Transparent;
			this._lbl_34.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_34.ForeColor = System.Drawing.Color.Black;
			this._lbl_34.Location = new System.Drawing.Point(16, 39);
			this._lbl_34.Name = "_lbl_34";
			this._lbl_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_34.Size = new System.Drawing.Size(133, 13);
			this._lbl_34.TabIndex = 98;
			this._lbl_34.Text = "VAT:";
			this._lbl_34.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnInclusiveIn
			//
			this.lblDepositReturnInclusiveIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnInclusiveIn.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositReturnInclusiveIn.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnInclusiveIn.Location = new System.Drawing.Point(150, 54);
			this.lblDepositReturnInclusiveIn.Name = "lblDepositReturnInclusiveIn";
			this.lblDepositReturnInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnInclusiveIn.Size = new System.Drawing.Size(91, 19);
			this.lblDepositReturnInclusiveIn.TabIndex = 97;
			this.lblDepositReturnInclusiveIn.Text = "0.00";
			this.lblDepositReturnInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_33
			//
			this._lbl_33.BackColor = System.Drawing.Color.Transparent;
			this._lbl_33.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_33.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_33.ForeColor = System.Drawing.Color.Black;
			this._lbl_33.Location = new System.Drawing.Point(16, 57);
			this._lbl_33.Name = "_lbl_33";
			this._lbl_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_33.Size = new System.Drawing.Size(133, 13);
			this._lbl_33.TabIndex = 96;
			this._lbl_33.Text = "Inclusive:";
			this._lbl_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnVatRateIn
			//
			this.lblDepositReturnVatRateIn.BackColor = System.Drawing.Color.Transparent;
			this.lblDepositReturnVatRateIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositReturnVatRateIn.Location = new System.Drawing.Point(243, 39);
			this.lblDepositReturnVatRateIn.Name = "lblDepositReturnVatRateIn";
			this.lblDepositReturnVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnVatRateIn.Size = new System.Drawing.Size(55, 16);
			this.lblDepositReturnVatRateIn.TabIndex = 95;
			this.lblDepositReturnVatRateIn.Text = "0.00";
			//
			//_Frame1_3
			//
			this._Frame1_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this._Frame1_3.Controls.Add(this.lblContentOut);
			this._Frame1_3.Controls.Add(this.lblDiscountLineOut);
			this._Frame1_3.Controls.Add(this._lbl_1);
			this._Frame1_3.Controls.Add(this._lbl_3);
			this._Frame1_3.Controls.Add(this.lblExclusiveOut);
			this._Frame1_3.Controls.Add(this._lbl_4);
			this._Frame1_3.Controls.Add(this._lbl_5);
			this._Frame1_3.Controls.Add(this.lblVATout);
			this._Frame1_3.Controls.Add(this._lbl_12);
			this._Frame1_3.Controls.Add(this.lblInclusiveOut);
			this._Frame1_3.Controls.Add(this.lblVatRateOut);
			this._Frame1_3.Controls.Add(this._lbl_37);
			this._Frame1_3.Controls.Add(this.lblLinesOut);
			this._Frame1_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_3.Location = new System.Drawing.Point(318, 18);
			this._Frame1_3.Name = "_Frame1_3";
			this._Frame1_3.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_3.Size = new System.Drawing.Size(301, 145);
			this._Frame1_3.TabIndex = 69;
			this._Frame1_3.TabStop = false;
			this._Frame1_3.Text = "Credited Content / Liquid";
			//
			//lblContentOut
			//
			this.lblContentOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblContentOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentOut.Location = new System.Drawing.Point(153, 33);
			this.lblContentOut.Name = "lblContentOut";
			this.lblContentOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentOut.Size = new System.Drawing.Size(91, 19);
			this.lblContentOut.TabIndex = 82;
			this.lblContentOut.Text = "0.00";
			this.lblContentOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDiscountLineOut
			//
			this.lblDiscountLineOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDiscountLineOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDiscountLineOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDiscountLineOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDiscountLineOut.Location = new System.Drawing.Point(153, 54);
			this.lblDiscountLineOut.Name = "lblDiscountLineOut";
			this.lblDiscountLineOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDiscountLineOut.Size = new System.Drawing.Size(91, 19);
			this.lblDiscountLineOut.TabIndex = 81;
			this.lblDiscountLineOut.Text = "0.00";
			this.lblDiscountLineOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_1
			//
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(18, 36);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(133, 13);
			this._lbl_1.TabIndex = 80;
			this._lbl_1.Text = "Contents Value :";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_3
			//
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(18, 57);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(133, 13);
			this._lbl_3.TabIndex = 79;
			this._lbl_3.Text = "Line Item Discount :";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblExclusiveOut
			//
			this.lblExclusiveOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblExclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblExclusiveOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblExclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExclusiveOut.Location = new System.Drawing.Point(153, 75);
			this.lblExclusiveOut.Name = "lblExclusiveOut";
			this.lblExclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblExclusiveOut.Size = new System.Drawing.Size(91, 19);
			this.lblExclusiveOut.TabIndex = 78;
			this.lblExclusiveOut.Text = "0.00";
			this.lblExclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_4
			//
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Location = new System.Drawing.Point(18, 78);
			this._lbl_4.Name = "_lbl_4";
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.Size = new System.Drawing.Size(133, 13);
			this._lbl_4.TabIndex = 77;
			this._lbl_4.Text = "Exclusive:";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(18, 99);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(133, 13);
			this._lbl_5.TabIndex = 76;
			this._lbl_5.Text = "VAT :";
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblVATout
			//
			this.lblVATout.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblVATout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblVATout.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVATout.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVATout.Location = new System.Drawing.Point(153, 96);
			this.lblVATout.Name = "lblVATout";
			this.lblVATout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVATout.Size = new System.Drawing.Size(91, 19);
			this.lblVATout.TabIndex = 75;
			this.lblVATout.Text = "0.00";
			this.lblVATout.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_12
			//
			this._lbl_12.BackColor = System.Drawing.Color.Transparent;
			this._lbl_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_12.Location = new System.Drawing.Point(18, 120);
			this._lbl_12.Name = "_lbl_12";
			this._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_12.Size = new System.Drawing.Size(133, 13);
			this._lbl_12.TabIndex = 74;
			this._lbl_12.Text = "Inclusive:";
			this._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblInclusiveOut
			//
			this.lblInclusiveOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInclusiveOut.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInclusiveOut.Location = new System.Drawing.Point(153, 117);
			this.lblInclusiveOut.Name = "lblInclusiveOut";
			this.lblInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInclusiveOut.Size = new System.Drawing.Size(91, 19);
			this.lblInclusiveOut.TabIndex = 73;
			this.lblInclusiveOut.Text = "0.00";
			this.lblInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblVatRateOut
			//
			this.lblVatRateOut.BackColor = System.Drawing.Color.Transparent;
			this.lblVatRateOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVatRateOut.Location = new System.Drawing.Point(246, 99);
			this.lblVatRateOut.Name = "lblVatRateOut";
			this.lblVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVatRateOut.Size = new System.Drawing.Size(55, 16);
			this.lblVatRateOut.TabIndex = 72;
			this.lblVatRateOut.Text = "lblVatRateOut";
			//
			//_lbl_37
			//
			this._lbl_37.BackColor = System.Drawing.Color.Transparent;
			this._lbl_37.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_37.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_37.Location = new System.Drawing.Point(18, 15);
			this._lbl_37.Name = "_lbl_37";
			this._lbl_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_37.Size = new System.Drawing.Size(133, 13);
			this._lbl_37.TabIndex = 71;
			this._lbl_37.Text = "No Of Lines :";
			this._lbl_37.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblLinesOut
			//
			this.lblLinesOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblLinesOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblLinesOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblLinesOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLinesOut.Location = new System.Drawing.Point(153, 12);
			this.lblLinesOut.Name = "lblLinesOut";
			this.lblLinesOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLinesOut.Size = new System.Drawing.Size(91, 19);
			this.lblLinesOut.TabIndex = 70;
			this.lblLinesOut.Text = "0.00";
			this.lblLinesOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Frame1_4
			//
			this._Frame1_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this._Frame1_4.Controls.Add(this.lblDepositVatRateOut);
			this._Frame1_4.Controls.Add(this.lblDepositOut);
			this._Frame1_4.Controls.Add(this._lbl_9);
			this._Frame1_4.Controls.Add(this.lblDepositVatOut);
			this._Frame1_4.Controls.Add(this._lbl_23);
			this._Frame1_4.Controls.Add(this.lblDepositInclusiveOut);
			this._Frame1_4.Controls.Add(this._lbl_24);
			this._Frame1_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_4.Location = new System.Drawing.Point(318, 162);
			this._Frame1_4.Name = "_Frame1_4";
			this._Frame1_4.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_4.Size = new System.Drawing.Size(301, 82);
			this._Frame1_4.TabIndex = 61;
			this._Frame1_4.TabStop = false;
			this._Frame1_4.Text = "Deposits with Credits";
			//
			//lblDepositVatRateOut
			//
			this.lblDepositVatRateOut.BackColor = System.Drawing.Color.Transparent;
			this.lblDepositVatRateOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositVatRateOut.Location = new System.Drawing.Point(243, 39);
			this.lblDepositVatRateOut.Name = "lblDepositVatRateOut";
			this.lblDepositVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositVatRateOut.Size = new System.Drawing.Size(55, 16);
			this.lblDepositVatRateOut.TabIndex = 68;
			this.lblDepositVatRateOut.Text = "0.00";
			//
			//lblDepositOut
			//
			this.lblDepositOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositOut.Location = new System.Drawing.Point(150, 18);
			this.lblDepositOut.Name = "lblDepositOut";
			this.lblDepositOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositOut.Size = new System.Drawing.Size(91, 17);
			this.lblDepositOut.TabIndex = 67;
			this.lblDepositOut.Text = "0.00";
			this.lblDepositOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_9
			//
			this._lbl_9.BackColor = System.Drawing.Color.Transparent;
			this._lbl_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_9.Location = new System.Drawing.Point(16, 21);
			this._lbl_9.Name = "_lbl_9";
			this._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_9.Size = new System.Drawing.Size(133, 13);
			this._lbl_9.TabIndex = 66;
			this._lbl_9.Text = "Deposit Value:";
			this._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositVatOut
			//
			this.lblDepositVatOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositVatOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositVatOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositVatOut.Location = new System.Drawing.Point(150, 36);
			this.lblDepositVatOut.Name = "lblDepositVatOut";
			this.lblDepositVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositVatOut.Size = new System.Drawing.Size(91, 17);
			this.lblDepositVatOut.TabIndex = 65;
			this.lblDepositVatOut.Text = "0.00";
			this.lblDepositVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_23
			//
			this._lbl_23.BackColor = System.Drawing.Color.Transparent;
			this._lbl_23.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_23.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_23.Location = new System.Drawing.Point(16, 39);
			this._lbl_23.Name = "_lbl_23";
			this._lbl_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_23.Size = new System.Drawing.Size(133, 13);
			this._lbl_23.TabIndex = 64;
			this._lbl_23.Text = "VAT:";
			this._lbl_23.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositInclusiveOut
			//
			this.lblDepositInclusiveOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositInclusiveOut.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositInclusiveOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositInclusiveOut.Location = new System.Drawing.Point(150, 54);
			this.lblDepositInclusiveOut.Name = "lblDepositInclusiveOut";
			this.lblDepositInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositInclusiveOut.Size = new System.Drawing.Size(91, 19);
			this.lblDepositInclusiveOut.TabIndex = 63;
			this.lblDepositInclusiveOut.Text = "0.00";
			this.lblDepositInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_24
			//
			this._lbl_24.BackColor = System.Drawing.Color.Transparent;
			this._lbl_24.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_24.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_24.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_24.Location = new System.Drawing.Point(16, 57);
			this._lbl_24.Name = "_lbl_24";
			this._lbl_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_24.Size = new System.Drawing.Size(133, 13);
			this._lbl_24.TabIndex = 62;
			this._lbl_24.Text = "Inclusive:";
			this._lbl_24.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Frame1_2
			//
			this._Frame1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this._Frame1_2.Controls.Add(this.lblDepositReturnVatRateOut);
			this._Frame1_2.Controls.Add(this._lbl_15);
			this._Frame1_2.Controls.Add(this.lblDepositReturnInclusiveOut);
			this._Frame1_2.Controls.Add(this._lbl_16);
			this._Frame1_2.Controls.Add(this.lblDepositReturnVatOut);
			this._Frame1_2.Controls.Add(this._lbl_17);
			this._Frame1_2.Controls.Add(this.lblDepositReturnOut);
			this._Frame1_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_2.Location = new System.Drawing.Point(321, 375);
			this._Frame1_2.Name = "_Frame1_2";
			this._Frame1_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_2.Size = new System.Drawing.Size(301, 79);
			this._Frame1_2.TabIndex = 22;
			this._Frame1_2.TabStop = false;
			this._Frame1_2.Text = "Returned Deposits";
			//
			//lblDepositReturnVatRateOut
			//
			this.lblDepositReturnVatRateOut.BackColor = System.Drawing.Color.Transparent;
			this.lblDepositReturnVatRateOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnVatRateOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositReturnVatRateOut.Location = new System.Drawing.Point(243, 39);
			this.lblDepositReturnVatRateOut.Name = "lblDepositReturnVatRateOut";
			this.lblDepositReturnVatRateOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnVatRateOut.Size = new System.Drawing.Size(55, 16);
			this.lblDepositReturnVatRateOut.TabIndex = 83;
			this.lblDepositReturnVatRateOut.Text = "0.00";
			//
			//_lbl_15
			//
			this._lbl_15.BackColor = System.Drawing.Color.Transparent;
			this._lbl_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_15.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_15.ForeColor = System.Drawing.Color.Black;
			this._lbl_15.Location = new System.Drawing.Point(16, 57);
			this._lbl_15.Name = "_lbl_15";
			this._lbl_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_15.Size = new System.Drawing.Size(133, 13);
			this._lbl_15.TabIndex = 27;
			this._lbl_15.Text = "Inclusive:";
			this._lbl_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnInclusiveOut
			//
			this.lblDepositReturnInclusiveOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnInclusiveOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnInclusiveOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnInclusiveOut.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositReturnInclusiveOut.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnInclusiveOut.Location = new System.Drawing.Point(150, 54);
			this.lblDepositReturnInclusiveOut.Name = "lblDepositReturnInclusiveOut";
			this.lblDepositReturnInclusiveOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnInclusiveOut.Size = new System.Drawing.Size(91, 19);
			this.lblDepositReturnInclusiveOut.TabIndex = 28;
			this.lblDepositReturnInclusiveOut.Text = "0.00";
			this.lblDepositReturnInclusiveOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_16
			//
			this._lbl_16.BackColor = System.Drawing.Color.Transparent;
			this._lbl_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_16.ForeColor = System.Drawing.Color.Black;
			this._lbl_16.Location = new System.Drawing.Point(16, 39);
			this._lbl_16.Name = "_lbl_16";
			this._lbl_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_16.Size = new System.Drawing.Size(133, 13);
			this._lbl_16.TabIndex = 25;
			this._lbl_16.Text = "VAT:";
			this._lbl_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnVatOut
			//
			this.lblDepositReturnVatOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnVatOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnVatOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnVatOut.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnVatOut.Location = new System.Drawing.Point(150, 36);
			this.lblDepositReturnVatOut.Name = "lblDepositReturnVatOut";
			this.lblDepositReturnVatOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnVatOut.Size = new System.Drawing.Size(91, 17);
			this.lblDepositReturnVatOut.TabIndex = 26;
			this.lblDepositReturnVatOut.Text = "0.00";
			this.lblDepositReturnVatOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_17
			//
			this._lbl_17.BackColor = System.Drawing.Color.Transparent;
			this._lbl_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_17.ForeColor = System.Drawing.Color.Black;
			this._lbl_17.Location = new System.Drawing.Point(16, 21);
			this._lbl_17.Name = "_lbl_17";
			this._lbl_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_17.Size = new System.Drawing.Size(133, 13);
			this._lbl_17.TabIndex = 23;
			this._lbl_17.Text = "Deposit Value:";
			this._lbl_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositReturnOut
			//
			this.lblDepositReturnOut.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositReturnOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositReturnOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositReturnOut.ForeColor = System.Drawing.Color.Black;
			this.lblDepositReturnOut.Location = new System.Drawing.Point(150, 18);
			this.lblDepositReturnOut.Name = "lblDepositReturnOut";
			this.lblDepositReturnOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositReturnOut.Size = new System.Drawing.Size(91, 17);
			this.lblDepositReturnOut.TabIndex = 24;
			this.lblDepositReturnOut.Text = "0.00";
			this.lblDepositReturnOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Frame1_0
			//
			this._Frame1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Frame1_0.Controls.Add(this.cmbPayment);
			this._Frame1_0.Controls.Add(this.txtUllage);
			this._Frame1_0.Controls.Add(this.txtDiscount);
			this._Frame1_0.Controls.Add(this.txtMinus);
			this._Frame1_0.Controls.Add(this.txtPlus);
			this._Frame1_0.Controls.Add(this.lblContentIn);
			this._Frame1_0.Controls.Add(this.lblDiscountLineIn);
			this._Frame1_0.Controls.Add(this._lbl_20);
			this._Frame1_0.Controls.Add(this._lbl_21);
			this._Frame1_0.Controls.Add(this.lblExclusiveIn);
			this._Frame1_0.Controls.Add(this._lbl_22);
			this._Frame1_0.Controls.Add(this._lbl_29);
			this._Frame1_0.Controls.Add(this.lblVATin);
			this._Frame1_0.Controls.Add(this._lbl_30);
			this._Frame1_0.Controls.Add(this.lblInclusiveIn);
			this._Frame1_0.Controls.Add(this.lblVatRateIn);
			this._Frame1_0.Controls.Add(this._lbl_19);
			this._Frame1_0.Controls.Add(this._Label1_1);
			this._Frame1_0.Controls.Add(this.Label2);
			this._Frame1_0.Controls.Add(this._Label1_0);
			this._Frame1_0.Controls.Add(this.lblDiscount);
			this._Frame1_0.Controls.Add(this.lblUllage);
			this._Frame1_0.Controls.Add(this.lblDiscountName);
			this._Frame1_0.Controls.Add(this._lbl_31);
			this._Frame1_0.Controls.Add(this.lblContentExclusiveIn);
			this._Frame1_0.Controls.Add(this._lbl_11);
			this._Frame1_0.Controls.Add(this._lbl_10);
			this._Frame1_0.Controls.Add(this._lbl_32);
			this._Frame1_0.Controls.Add(this.lblLinesIn);
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.Location = new System.Drawing.Point(9, 18);
			this._Frame1_0.Name = "_Frame1_0";
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Size = new System.Drawing.Size(301, 268);
			this._Frame1_0.TabIndex = 12;
			this._Frame1_0.TabStop = false;
			this._Frame1_0.Text = "Purchased Content / Liquid";
			//
			//cmbPayment
			//
			this.cmbPayment.BackColor = System.Drawing.SystemColors.Window;
			this.cmbPayment.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPayment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbPayment.Items.AddRange(new object[] {
				"C.O.D.",
				"15 Days",
				"30 Days",
				"60 Days",
				"90 Days",
				"120 Days",
				"Smart Card"
			});
			this.cmbPayment.Location = new System.Drawing.Point(153, 96);
			this.cmbPayment.Name = "cmbPayment";
			this.cmbPayment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbPayment.Size = new System.Drawing.Size(91, 22);
			this.cmbPayment.TabIndex = 0;
			//
			//txtUllage
			//
			this.txtUllage.AcceptsReturn = true;
			this.txtUllage.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.txtUllage.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUllage.Enabled = false;
			this.txtUllage.ForeColor = System.Drawing.Color.Red;
			this.txtUllage.Location = new System.Drawing.Point(99, 135);
			this.txtUllage.MaxLength = 0;
			this.txtUllage.Name = "txtUllage";
			this.txtUllage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUllage.Size = new System.Drawing.Size(40, 19);
			this.txtUllage.TabIndex = 8;
			this.txtUllage.Text = "0.20";
			this.txtUllage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//txtDiscount
			//
			this.txtDiscount.AcceptsReturn = true;
			this.txtDiscount.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDiscount.Enabled = false;
			this.txtDiscount.ForeColor = System.Drawing.Color.Red;
			this.txtDiscount.Location = new System.Drawing.Point(99, 117);
			this.txtDiscount.MaxLength = 0;
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDiscount.Size = new System.Drawing.Size(40, 19);
			this.txtDiscount.TabIndex = 35;
			this.txtDiscount.TabStop = false;
			this.txtDiscount.Text = "2.00";
			this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//txtMinus
			//
			this.txtMinus.AcceptsReturn = true;
			this.txtMinus.BackColor = System.Drawing.SystemColors.Window;
			this.txtMinus.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMinus.ForeColor = System.Drawing.Color.Red;
			this.txtMinus.Location = new System.Drawing.Point(153, 180);
			this.txtMinus.MaxLength = 0;
			this.txtMinus.Name = "txtMinus";
			this.txtMinus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMinus.Size = new System.Drawing.Size(91, 19);
			this.txtMinus.TabIndex = 2;
			this.txtMinus.Text = "0.00";
			this.txtMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//txtPlus
			//
			this.txtPlus.AcceptsReturn = true;
			this.txtPlus.BackColor = System.Drawing.SystemColors.Window;
			this.txtPlus.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPlus.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPlus.Location = new System.Drawing.Point(153, 159);
			this.txtPlus.MaxLength = 0;
			this.txtPlus.Name = "txtPlus";
			this.txtPlus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPlus.Size = new System.Drawing.Size(91, 19);
			this.txtPlus.TabIndex = 1;
			this.txtPlus.Text = "0.00";
			this.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//lblContentIn
			//
			this.lblContentIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblContentIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentIn.Location = new System.Drawing.Point(153, 33);
			this.lblContentIn.Name = "lblContentIn";
			this.lblContentIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentIn.Size = new System.Drawing.Size(91, 19);
			this.lblContentIn.TabIndex = 59;
			this.lblContentIn.Text = "0.00";
			this.lblContentIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDiscountLineIn
			//
			this.lblDiscountLineIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDiscountLineIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDiscountLineIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDiscountLineIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDiscountLineIn.Location = new System.Drawing.Point(153, 54);
			this.lblDiscountLineIn.Name = "lblDiscountLineIn";
			this.lblDiscountLineIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDiscountLineIn.Size = new System.Drawing.Size(91, 19);
			this.lblDiscountLineIn.TabIndex = 58;
			this.lblDiscountLineIn.Text = "0.00";
			this.lblDiscountLineIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_20
			//
			this._lbl_20.BackColor = System.Drawing.Color.Transparent;
			this._lbl_20.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_20.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_20.Location = new System.Drawing.Point(18, 36);
			this._lbl_20.Name = "_lbl_20";
			this._lbl_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_20.Size = new System.Drawing.Size(133, 13);
			this._lbl_20.TabIndex = 57;
			this._lbl_20.Text = "Contents Value :";
			this._lbl_20.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_21
			//
			this._lbl_21.BackColor = System.Drawing.Color.Transparent;
			this._lbl_21.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_21.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_21.Location = new System.Drawing.Point(18, 57);
			this._lbl_21.Name = "_lbl_21";
			this._lbl_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_21.Size = new System.Drawing.Size(133, 13);
			this._lbl_21.TabIndex = 56;
			this._lbl_21.Text = "Line Item Discount :";
			this._lbl_21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblExclusiveIn
			//
			this.lblExclusiveIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExclusiveIn.Location = new System.Drawing.Point(153, 201);
			this.lblExclusiveIn.Name = "lblExclusiveIn";
			this.lblExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblExclusiveIn.Size = new System.Drawing.Size(91, 19);
			this.lblExclusiveIn.TabIndex = 55;
			this.lblExclusiveIn.Text = "0.00";
			this.lblExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_22
			//
			this._lbl_22.BackColor = System.Drawing.Color.Transparent;
			this._lbl_22.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_22.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_22.Location = new System.Drawing.Point(18, 204);
			this._lbl_22.Name = "_lbl_22";
			this._lbl_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_22.Size = new System.Drawing.Size(133, 13);
			this._lbl_22.TabIndex = 54;
			this._lbl_22.Text = "Exclusive:";
			this._lbl_22.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_29
			//
			this._lbl_29.BackColor = System.Drawing.Color.Transparent;
			this._lbl_29.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_29.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_29.Location = new System.Drawing.Point(18, 225);
			this._lbl_29.Name = "_lbl_29";
			this._lbl_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_29.Size = new System.Drawing.Size(133, 13);
			this._lbl_29.TabIndex = 53;
			this._lbl_29.Text = "VAT :";
			this._lbl_29.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblVATin
			//
			this.lblVATin.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblVATin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblVATin.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVATin.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVATin.Location = new System.Drawing.Point(153, 222);
			this.lblVATin.Name = "lblVATin";
			this.lblVATin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVATin.Size = new System.Drawing.Size(91, 19);
			this.lblVATin.TabIndex = 52;
			this.lblVATin.Text = "0.00";
			this.lblVATin.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_30
			//
			this._lbl_30.BackColor = System.Drawing.Color.Transparent;
			this._lbl_30.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_30.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_30.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_30.Location = new System.Drawing.Point(18, 246);
			this._lbl_30.Name = "_lbl_30";
			this._lbl_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_30.Size = new System.Drawing.Size(133, 13);
			this._lbl_30.TabIndex = 51;
			this._lbl_30.Text = "Inclusive:";
			this._lbl_30.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblInclusiveIn
			//
			this.lblInclusiveIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInclusiveIn.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInclusiveIn.Location = new System.Drawing.Point(153, 243);
			this.lblInclusiveIn.Name = "lblInclusiveIn";
			this.lblInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInclusiveIn.Size = new System.Drawing.Size(91, 19);
			this.lblInclusiveIn.TabIndex = 50;
			this.lblInclusiveIn.Text = "0.00";
			this.lblInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblVatRateIn
			//
			this.lblVatRateIn.BackColor = System.Drawing.Color.Transparent;
			this.lblVatRateIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblVatRateIn.Location = new System.Drawing.Point(246, 225);
			this.lblVatRateIn.Name = "lblVatRateIn";
			this.lblVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVatRateIn.Size = new System.Drawing.Size(55, 16);
			this.lblVatRateIn.TabIndex = 49;
			this.lblVatRateIn.Text = "0.00";
			//
			//_lbl_19
			//
			this._lbl_19.BackColor = System.Drawing.Color.Transparent;
			this._lbl_19.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_19.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_19.Location = new System.Drawing.Point(18, 99);
			this._lbl_19.Name = "_lbl_19";
			this._lbl_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_19.Size = new System.Drawing.Size(133, 13);
			this._lbl_19.TabIndex = 48;
			this._lbl_19.Text = "Payment Terms";
			this._lbl_19.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Label1_1
			//
			this._Label1_1.AutoSize = true;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.ForeColor = System.Drawing.Color.Red;
			this._Label1_1.Location = new System.Drawing.Point(138, 138);
			this._Label1_1.Name = "_Label1_1";
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.Size = new System.Drawing.Size(19, 14);
			this._Label1_1.TabIndex = 47;
			this._Label1_1.Text = "%:";
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Location = new System.Drawing.Point(-36, 138);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(133, 13);
			this.Label2.TabIndex = 46;
			this.Label2.Text = "Ullage @";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Label1_0
			//
			this._Label1_0.AutoSize = true;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.ForeColor = System.Drawing.Color.Red;
			this._Label1_0.Location = new System.Drawing.Point(138, 120);
			this._Label1_0.Name = "_Label1_0";
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.Size = new System.Drawing.Size(19, 14);
			this._Label1_0.TabIndex = 45;
			this._Label1_0.Text = "%:";
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDiscount
			//
			this.lblDiscount.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDiscount.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDiscount.ForeColor = System.Drawing.Color.Red;
			this.lblDiscount.Location = new System.Drawing.Point(153, 117);
			this.lblDiscount.Name = "lblDiscount";
			this.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDiscount.Size = new System.Drawing.Size(91, 19);
			this.lblDiscount.TabIndex = 44;
			this.lblDiscount.Text = "0.00";
			this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblUllage
			//
			this.lblUllage.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblUllage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblUllage.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblUllage.ForeColor = System.Drawing.Color.Red;
			this.lblUllage.Location = new System.Drawing.Point(153, 138);
			this.lblUllage.Name = "lblUllage";
			this.lblUllage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblUllage.Size = new System.Drawing.Size(91, 19);
			this.lblUllage.TabIndex = 43;
			this.lblUllage.Text = "0.00";
			this.lblUllage.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDiscountName
			//
			this.lblDiscountName.BackColor = System.Drawing.Color.Transparent;
			this.lblDiscountName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDiscountName.ForeColor = System.Drawing.Color.Red;
			this.lblDiscountName.Location = new System.Drawing.Point(-42, 120);
			this.lblDiscountName.Name = "lblDiscountName";
			this.lblDiscountName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDiscountName.Size = new System.Drawing.Size(133, 13);
			this.lblDiscountName.TabIndex = 42;
			this.lblDiscountName.Text = "Account Discount";
			this.lblDiscountName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_31
			//
			this._lbl_31.BackColor = System.Drawing.Color.Transparent;
			this._lbl_31.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_31.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_31.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_31.Location = new System.Drawing.Point(18, 78);
			this._lbl_31.Name = "_lbl_31";
			this._lbl_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_31.Size = new System.Drawing.Size(133, 13);
			this._lbl_31.TabIndex = 41;
			this._lbl_31.Text = "Content Sub Total :";
			this._lbl_31.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblContentExclusiveIn
			//
			this.lblContentExclusiveIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblContentExclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentExclusiveIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentExclusiveIn.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblContentExclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentExclusiveIn.Location = new System.Drawing.Point(153, 75);
			this.lblContentExclusiveIn.Name = "lblContentExclusiveIn";
			this.lblContentExclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentExclusiveIn.Size = new System.Drawing.Size(91, 19);
			this.lblContentExclusiveIn.TabIndex = 40;
			this.lblContentExclusiveIn.Text = "0.00";
			this.lblContentExclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_11
			//
			this._lbl_11.BackColor = System.Drawing.Color.Transparent;
			this._lbl_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_11.ForeColor = System.Drawing.Color.Red;
			this._lbl_11.Location = new System.Drawing.Point(18, 183);
			this._lbl_11.Name = "_lbl_11";
			this._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_11.Size = new System.Drawing.Size(133, 13);
			this._lbl_11.TabIndex = 39;
			this._lbl_11.Text = "Sundry Minuses:";
			this._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_10
			//
			this._lbl_10.BackColor = System.Drawing.Color.Transparent;
			this._lbl_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_10.Location = new System.Drawing.Point(18, 162);
			this._lbl_10.Name = "_lbl_10";
			this._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_10.Size = new System.Drawing.Size(133, 13);
			this._lbl_10.TabIndex = 38;
			this._lbl_10.Text = "Sundry Pluses:";
			this._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_32
			//
			this._lbl_32.BackColor = System.Drawing.Color.Transparent;
			this._lbl_32.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_32.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_32.Location = new System.Drawing.Point(18, 15);
			this._lbl_32.Name = "_lbl_32";
			this._lbl_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_32.Size = new System.Drawing.Size(133, 13);
			this._lbl_32.TabIndex = 37;
			this._lbl_32.Text = "No Of Lines :";
			this._lbl_32.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblLinesIn
			//
			this.lblLinesIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblLinesIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblLinesIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblLinesIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLinesIn.Location = new System.Drawing.Point(153, 12);
			this.lblLinesIn.Name = "lblLinesIn";
			this.lblLinesIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLinesIn.Size = new System.Drawing.Size(91, 19);
			this.lblLinesIn.TabIndex = 36;
			this.lblLinesIn.Text = "0";
			this.lblLinesIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_Frame1_1
			//
			this._Frame1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Frame1_1.Controls.Add(this.lblDepositVatRateIn);
			this._Frame1_1.Controls.Add(this.lblDepositIn);
			this._Frame1_1.Controls.Add(this._lbl_2);
			this._Frame1_1.Controls.Add(this.lblDepositVatIn);
			this._Frame1_1.Controls.Add(this._lbl_13);
			this._Frame1_1.Controls.Add(this.lblDepositInclusiveIn);
			this._Frame1_1.Controls.Add(this._lbl_14);
			this._Frame1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.Location = new System.Drawing.Point(9, 285);
			this._Frame1_1.Name = "_Frame1_1";
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Size = new System.Drawing.Size(301, 82);
			this._Frame1_1.TabIndex = 13;
			this._Frame1_1.TabStop = false;
			this._Frame1_1.Text = "Deposits with Purchases";
			//
			//lblDepositVatRateIn
			//
			this.lblDepositVatRateIn.BackColor = System.Drawing.Color.Transparent;
			this.lblDepositVatRateIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositVatRateIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositVatRateIn.Location = new System.Drawing.Point(243, 39);
			this.lblDepositVatRateIn.Name = "lblDepositVatRateIn";
			this.lblDepositVatRateIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositVatRateIn.Size = new System.Drawing.Size(55, 16);
			this.lblDepositVatRateIn.TabIndex = 60;
			this.lblDepositVatRateIn.Text = "0.00";
			//
			//lblDepositIn
			//
			this.lblDepositIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositIn.Location = new System.Drawing.Point(150, 18);
			this.lblDepositIn.Name = "lblDepositIn";
			this.lblDepositIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositIn.Size = new System.Drawing.Size(91, 17);
			this.lblDepositIn.TabIndex = 15;
			this.lblDepositIn.Text = "0.00";
			this.lblDepositIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_2
			//
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(16, 21);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(133, 13);
			this._lbl_2.TabIndex = 14;
			this._lbl_2.Text = "Deposit Value:";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositVatIn
			//
			this.lblDepositVatIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositVatIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositVatIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositVatIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositVatIn.Location = new System.Drawing.Point(150, 36);
			this.lblDepositVatIn.Name = "lblDepositVatIn";
			this.lblDepositVatIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositVatIn.Size = new System.Drawing.Size(91, 17);
			this.lblDepositVatIn.TabIndex = 17;
			this.lblDepositVatIn.Text = "0.00";
			this.lblDepositVatIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_13
			//
			this._lbl_13.BackColor = System.Drawing.Color.Transparent;
			this._lbl_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_13.Location = new System.Drawing.Point(16, 39);
			this._lbl_13.Name = "_lbl_13";
			this._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_13.Size = new System.Drawing.Size(133, 13);
			this._lbl_13.TabIndex = 16;
			this._lbl_13.Text = "VAT:";
			this._lbl_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDepositInclusiveIn
			//
			this.lblDepositInclusiveIn.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDepositInclusiveIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositInclusiveIn.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositInclusiveIn.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositInclusiveIn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositInclusiveIn.Location = new System.Drawing.Point(150, 54);
			this.lblDepositInclusiveIn.Name = "lblDepositInclusiveIn";
			this.lblDepositInclusiveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositInclusiveIn.Size = new System.Drawing.Size(91, 19);
			this.lblDepositInclusiveIn.TabIndex = 19;
			this.lblDepositInclusiveIn.Text = "0.00";
			this.lblDepositInclusiveIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_14
			//
			this._lbl_14.BackColor = System.Drawing.Color.Transparent;
			this._lbl_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_14.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_14.Location = new System.Drawing.Point(16, 57);
			this._lbl_14.Name = "_lbl_14";
			this._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_14.Size = new System.Drawing.Size(133, 13);
			this._lbl_14.TabIndex = 18;
			this._lbl_14.Text = "Inclusive:";
			this._lbl_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_28
			//
			this._lbl_28.BackColor = System.Drawing.Color.Transparent;
			this._lbl_28.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_28.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_28.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_28.Location = new System.Drawing.Point(336, 456);
			this._lbl_28.Name = "_lbl_28";
			this._lbl_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_28.Size = new System.Drawing.Size(133, 13);
			this._lbl_28.TabIndex = 93;
			this._lbl_28.Text = "In Bound VAT:";
			this._lbl_28.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblInBoundVat
			//
			this.lblInBoundVat.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this.lblInBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInBoundVat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInBoundVat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInBoundVat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInBoundVat.Location = new System.Drawing.Point(470, 453);
			this.lblInBoundVat.Name = "lblInBoundVat";
			this.lblInBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInBoundVat.Size = new System.Drawing.Size(91, 19);
			this.lblInBoundVat.TabIndex = 92;
			this.lblInBoundVat.Text = "0.00";
			this.lblInBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_27
			//
			this._lbl_27.BackColor = System.Drawing.Color.Transparent;
			this._lbl_27.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_27.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_27.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_27.Location = new System.Drawing.Point(337, 477);
			this._lbl_27.Name = "_lbl_27";
			this._lbl_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_27.Size = new System.Drawing.Size(133, 13);
			this._lbl_27.TabIndex = 91;
			this._lbl_27.Text = "Credit Inclusive:";
			this._lbl_27.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblInBound
			//
			this.lblInBound.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this.lblInBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInBound.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInBound.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInBound.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInBound.Location = new System.Drawing.Point(471, 474);
			this.lblInBound.Name = "lblInBound";
			this.lblInBound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInBound.Size = new System.Drawing.Size(91, 19);
			this.lblInBound.TabIndex = 90;
			this.lblInBound.Text = "0.00";
			this.lblInBound.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_26
			//
			this._lbl_26.BackColor = System.Drawing.Color.Transparent;
			this._lbl_26.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_26.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_26.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_26.Location = new System.Drawing.Point(336, 246);
			this._lbl_26.Name = "_lbl_26";
			this._lbl_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_26.Size = new System.Drawing.Size(133, 13);
			this._lbl_26.TabIndex = 89;
			this._lbl_26.Text = "Credits VAT:";
			this._lbl_26.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblCreditVat
			//
			this.lblCreditVat.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblCreditVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCreditVat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCreditVat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblCreditVat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCreditVat.Location = new System.Drawing.Point(470, 243);
			this.lblCreditVat.Name = "lblCreditVat";
			this.lblCreditVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCreditVat.Size = new System.Drawing.Size(91, 19);
			this.lblCreditVat.TabIndex = 88;
			this.lblCreditVat.Text = "0.00";
			this.lblCreditVat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_25
			//
			this._lbl_25.BackColor = System.Drawing.Color.Transparent;
			this._lbl_25.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_25.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_25.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_25.Location = new System.Drawing.Point(337, 267);
			this._lbl_25.Name = "_lbl_25";
			this._lbl_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_25.Size = new System.Drawing.Size(133, 13);
			this._lbl_25.TabIndex = 87;
			this._lbl_25.Text = "Credits Inclusive:";
			this._lbl_25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblCredit
			//
			this.lblCredit.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCredit.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCredit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblCredit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCredit.Location = new System.Drawing.Point(471, 264);
			this.lblCredit.Name = "lblCredit";
			this.lblCredit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCredit.Size = new System.Drawing.Size(91, 19);
			this.lblCredit.TabIndex = 86;
			this.lblCredit.Text = "0.00";
			this.lblCredit.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_8
			//
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Location = new System.Drawing.Point(24, 456);
			this._lbl_8.Name = "_lbl_8";
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.Size = new System.Drawing.Size(133, 13);
			this._lbl_8.TabIndex = 85;
			this._lbl_8.Text = "Out Bound VAT:";
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblOutBoundVat
			//
			this.lblOutBoundVat.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.lblOutBoundVat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblOutBoundVat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblOutBoundVat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblOutBoundVat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOutBoundVat.Location = new System.Drawing.Point(158, 453);
			this.lblOutBoundVat.Name = "lblOutBoundVat";
			this.lblOutBoundVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblOutBoundVat.Size = new System.Drawing.Size(91, 19);
			this.lblOutBoundVat.TabIndex = 84;
			this.lblOutBoundVat.Text = "0.00";
			this.lblOutBoundVat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblOutBound
			//
			this.lblOutBound.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.lblOutBound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblOutBound.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblOutBound.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblOutBound.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOutBound.Location = new System.Drawing.Point(159, 474);
			this.lblOutBound.Name = "lblOutBound";
			this.lblOutBound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblOutBound.Size = new System.Drawing.Size(91, 19);
			this.lblOutBound.TabIndex = 21;
			this.lblOutBound.Text = "0.00";
			this.lblOutBound.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_6
			//
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Location = new System.Drawing.Point(25, 477);
			this._lbl_6.Name = "_lbl_6";
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.Size = new System.Drawing.Size(133, 13);
			this._lbl_6.TabIndex = 20;
			this._lbl_6.Text = "Purchases Inclusive:";
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblTotal
			//
			this.lblTotal.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotal.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotal.Location = new System.Drawing.Point(531, 522);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotal.Size = new System.Drawing.Size(91, 19);
			this.lblTotal.TabIndex = 10;
			this.lblTotal.Text = "0.00";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_7
			//
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Location = new System.Drawing.Point(396, 525);
			this._lbl_7.Name = "_lbl_7";
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.Size = new System.Drawing.Size(133, 13);
			this._lbl_7.TabIndex = 9;
			this._lbl_7.Text = "Nett Invoice Value:";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_0
			//
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(24, 504);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(133, 13);
			this._lbl_0.TabIndex = 29;
			this._lbl_0.Text = "Desired Invoice Value:";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblTotalOriginal
			//
			this.lblTotalOriginal.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblTotalOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalOriginal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalOriginal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalOriginal.Location = new System.Drawing.Point(159, 501);
			this.lblTotalOriginal.Name = "lblTotalOriginal";
			this.lblTotalOriginal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalOriginal.Size = new System.Drawing.Size(91, 19);
			this.lblTotalOriginal.TabIndex = 30;
			this.lblTotalOriginal.Text = "0.00";
			this.lblTotalOriginal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblDifference
			//
			this.lblDifference.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.lblDifference.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDifference.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDifference.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDifference.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDifference.Location = new System.Drawing.Point(159, 522);
			this.lblDifference.Name = "lblDifference";
			this.lblDifference.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDifference.Size = new System.Drawing.Size(91, 19);
			this.lblDifference.TabIndex = 32;
			this.lblDifference.Text = "0.00";
			this.lblDifference.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_18
			//
			this._lbl_18.BackColor = System.Drawing.Color.Transparent;
			this._lbl_18.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_18.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_18.Location = new System.Drawing.Point(24, 525);
			this._lbl_18.Name = "_lbl_18";
			this._lbl_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_18.Size = new System.Drawing.Size(133, 13);
			this._lbl_18.TabIndex = 31;
			this._lbl_18.Text = "Difference:";
			this._lbl_18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Picture1
			//
			this.Picture1.BackColor = System.Drawing.Color.Red;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.Controls.Add(this.lblSupplier);
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.Name = "Picture1";
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Size = new System.Drawing.Size(760, 25);
			this.Picture1.TabIndex = 33;
			//
			//lblSupplier
			//
			this.lblSupplier.AutoSize = true;
			this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
			this.lblSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSupplier.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblSupplier.ForeColor = System.Drawing.Color.White;
			this.lblSupplier.Location = new System.Drawing.Point(0, 0);
			this.lblSupplier.Name = "lblSupplier";
			this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSupplier.Size = new System.Drawing.Size(91, 19);
			this.lblSupplier.TabIndex = 34;
			this.lblSupplier.Text = "lblSupplier";
			//
			//frmGRVSummary
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(760, 684);
			this.ControlBox = false;
			this.Controls.Add(this.Picture2);
			this.Controls.Add(this.frmProcess);
			this.Controls.Add(this.frmMain);
			this.Controls.Add(this.Picture1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmGRVSummary";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GRV Summary and Process";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Picture2.ResumeLayout(false);
			this.frmProcess.ResumeLayout(false);
			this.frmProcess.PerformLayout();
			this.frmMain.ResumeLayout(false);
			this._Frame1_5.ResumeLayout(false);
			this._Frame1_3.ResumeLayout(false);
			this._Frame1_4.ResumeLayout(false);
			this._Frame1_2.ResumeLayout(false);
			this._Frame1_0.ResumeLayout(false);
			this._Frame1_0.PerformLayout();
			this._Frame1_1.ResumeLayout(false);
			this.Picture1.ResumeLayout(false);
			this.Picture1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
