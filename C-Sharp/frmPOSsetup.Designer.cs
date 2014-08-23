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
	partial class frmPOSsetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPOSsetup() : base()
		{
			Load += frmPOSsetup_Load1;
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
		public System.Windows.Forms.TextBox _txtInteger_0;
		public System.Windows.Forms.TextBox _txtInteger_9;
		public System.Windows.Forms.CheckBox chkCustBal;
		public System.Windows.Forms.CheckBox chkConCashup;
		public System.Windows.Forms.TextBox _txtPrice_0;
		public System.Windows.Forms.CheckBox chkCheckCash;
		public System.Windows.Forms.CheckBox chkPrintinvoice;
		public System.Windows.Forms.CheckBox chkFinalizeCash;
		public System.Windows.Forms.CheckBox chkDisplaySelling;
		public System.Windows.Forms.CheckBox chkLearningPOS;
		public System.Windows.Forms.CheckBox chkCurrency;
		public System.Windows.Forms.CheckBox chkSerialTracking;
		public System.Windows.Forms.CheckBox chkPrintA4;
		public System.Windows.Forms.CheckBox chkSerialNumber;
		public System.Windows.Forms.CheckBox chkOrderNumber;
		public System.Windows.Forms.CheckBox chkCardNumber;
		public System.Windows.Forms.CheckBox chkLogoffAuto;
		public System.Windows.Forms.CheckBox chkReceiptBarcode;
		public System.Windows.Forms.CheckBox chkBypassTender;
		public System.Windows.Forms.CheckBox chkSecurityPopup;
		public System.Windows.Forms.TextBox _txtFields_5;
		public System.Windows.Forms.RadioButton _optPrint_2;
		public System.Windows.Forms.RadioButton _optPrint_1;
		public System.Windows.Forms.RadioButton _optPrint_0;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.CheckBox chkSearchAuto;
		public System.Windows.Forms.TextBox _txtFields_9;
		public System.Windows.Forms.CheckBox chkDividingLine;
		public System.Windows.Forms.CheckBox chkOpenTill;
		public System.Windows.Forms.CheckBox chkQuickCashup;
		public System.Windows.Forms.CheckBox chkBlindCashup;
		public System.Windows.Forms.RadioButton _optDeposits_2;
		public System.Windows.Forms.RadioButton _optDeposits_1;
		public System.Windows.Forms.RadioButton _optDeposits_0;
		public System.Windows.Forms.GroupBox frmDeposits;
		public System.Windows.Forms.CheckBox chkSets;
		public System.Windows.Forms.CheckBox chkShrink;
		public System.Windows.Forms.CheckBox chkSuppress;
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_4;
		public System.Windows.Forms.TextBox _txtInteger_5;
		public System.Windows.Forms.TextBox _txtInteger_6;
		public System.Windows.Forms.TextBox _txtInteger_7;
		public System.Windows.Forms.TextBox _txtInteger_8;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_9;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Label _lbl_1;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optDeposits As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents optPrint As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtPrice As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
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
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this._txtInteger_9 = new System.Windows.Forms.TextBox();
			this.chkCustBal = new System.Windows.Forms.CheckBox();
			this.chkConCashup = new System.Windows.Forms.CheckBox();
			this._txtPrice_0 = new System.Windows.Forms.TextBox();
			this.chkCheckCash = new System.Windows.Forms.CheckBox();
			this.chkPrintinvoice = new System.Windows.Forms.CheckBox();
			this.chkFinalizeCash = new System.Windows.Forms.CheckBox();
			this.chkDisplaySelling = new System.Windows.Forms.CheckBox();
			this.chkLearningPOS = new System.Windows.Forms.CheckBox();
			this.chkCurrency = new System.Windows.Forms.CheckBox();
			this.chkSerialTracking = new System.Windows.Forms.CheckBox();
			this.chkPrintA4 = new System.Windows.Forms.CheckBox();
			this.chkSerialNumber = new System.Windows.Forms.CheckBox();
			this.chkOrderNumber = new System.Windows.Forms.CheckBox();
			this.chkCardNumber = new System.Windows.Forms.CheckBox();
			this.chkLogoffAuto = new System.Windows.Forms.CheckBox();
			this.chkReceiptBarcode = new System.Windows.Forms.CheckBox();
			this.chkBypassTender = new System.Windows.Forms.CheckBox();
			this.chkSecurityPopup = new System.Windows.Forms.CheckBox();
			this._txtFields_5 = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._optPrint_2 = new System.Windows.Forms.RadioButton();
			this._optPrint_1 = new System.Windows.Forms.RadioButton();
			this._optPrint_0 = new System.Windows.Forms.RadioButton();
			this.chkSearchAuto = new System.Windows.Forms.CheckBox();
			this._txtFields_9 = new System.Windows.Forms.TextBox();
			this.chkDividingLine = new System.Windows.Forms.CheckBox();
			this.chkOpenTill = new System.Windows.Forms.CheckBox();
			this.chkQuickCashup = new System.Windows.Forms.CheckBox();
			this.chkBlindCashup = new System.Windows.Forms.CheckBox();
			this.frmDeposits = new System.Windows.Forms.GroupBox();
			this._optDeposits_2 = new System.Windows.Forms.RadioButton();
			this._optDeposits_1 = new System.Windows.Forms.RadioButton();
			this._optDeposits_0 = new System.Windows.Forms.RadioButton();
			this.chkSets = new System.Windows.Forms.CheckBox();
			this.chkShrink = new System.Windows.Forms.CheckBox();
			this.chkSuppress = new System.Windows.Forms.CheckBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this._txtInteger_5 = new System.Windows.Forms.TextBox();
			this._txtInteger_6 = new System.Windows.Forms.TextBox();
			this._txtInteger_7 = new System.Windows.Forms.TextBox();
			this._txtInteger_8 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.frmDeposits.SuspendLayout();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Line1,
				this._Shape1_2,
				this._Shape1_0,
				this._Shape1_1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(483, 670);
			this.ShapeContainer1.TabIndex = 64;
			this.ShapeContainer1.TabStop = false;
			//
			//Line1
			//
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Name = "Line1";
			this.Line1.X1 = 200;
			this.Line1.X2 = 200;
			this.Line1.Y1 = 324;
			this.Line1.Y2 = 656;
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.Location = new System.Drawing.Point(12, 56);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(459, 113);
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.Location = new System.Drawing.Point(12, 184);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(459, 118);
			//
			//_Shape1_1
			//
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.Location = new System.Drawing.Point(12, 318);
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_1.Size = new System.Drawing.Size(461, 345);
			//
			//_txtInteger_0
			//
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_0.Location = new System.Drawing.Point(424, 631);
			this._txtInteger_0.MaxLength = 2;
			this._txtInteger_0.Name = "_txtInteger_0";
			this._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_0.Size = new System.Drawing.Size(41, 19);
			this._txtInteger_0.TabIndex = 63;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtInteger_9
			//
			this._txtInteger_9.AcceptsReturn = true;
			this._txtInteger_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_9.Location = new System.Drawing.Point(422, 277);
			this._txtInteger_9.MaxLength = 0;
			this._txtInteger_9.Name = "_txtInteger_9";
			this._txtInteger_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_9.Size = new System.Drawing.Size(42, 19);
			this._txtInteger_9.TabIndex = 61;
			this._txtInteger_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//chkCustBal
			//
			this.chkCustBal.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkCustBal.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkCustBal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkCustBal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkCustBal.Location = new System.Drawing.Point(22, 469);
			this.chkCustBal.Name = "chkCustBal";
			this.chkCustBal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCustBal.Size = new System.Drawing.Size(170, 19);
			this.chkCustBal.TabIndex = 59;
			this.chkCustBal.Text = "Print Customer Balances";
			this.chkCustBal.UseVisualStyleBackColor = false;
			//
			//chkConCashup
			//
			this.chkConCashup.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkConCashup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkConCashup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkConCashup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkConCashup.Location = new System.Drawing.Point(22, 449);
			this.chkConCashup.Name = "chkConCashup";
			this.chkConCashup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkConCashup.Size = new System.Drawing.Size(170, 19);
			this.chkConCashup.TabIndex = 58;
			this.chkConCashup.Text = "Activate Consolidate Cashup";
			this.chkConCashup.UseVisualStyleBackColor = false;
			//
			//_txtPrice_0
			//
			this._txtPrice_0.AcceptsReturn = true;
			this._txtPrice_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtPrice_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtPrice_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtPrice_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtPrice_0.Location = new System.Drawing.Point(376, 604);
			this._txtPrice_0.MaxLength = 0;
			this._txtPrice_0.Name = "_txtPrice_0";
			this._txtPrice_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtPrice_0.Size = new System.Drawing.Size(88, 19);
			this._txtPrice_0.TabIndex = 57;
			this._txtPrice_0.Text = "0.00";
			this._txtPrice_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//chkCheckCash
			//
			this.chkCheckCash.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkCheckCash.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkCheckCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkCheckCash.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkCheckCash.Location = new System.Drawing.Point(208, 606);
			this.chkCheckCash.Name = "chkCheckCash";
			this.chkCheckCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCheckCash.Size = new System.Drawing.Size(177, 25);
			this.chkCheckCash.TabIndex = 56;
			this.chkCheckCash.Text = "Remove Excess Cash from Till";
			this.chkCheckCash.UseVisualStyleBackColor = false;
			//
			//chkPrintinvoice
			//
			this.chkPrintinvoice.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkPrintinvoice.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPrintinvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkPrintinvoice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkPrintinvoice.Location = new System.Drawing.Point(22, 432);
			this.chkPrintinvoice.Name = "chkPrintinvoice";
			this.chkPrintinvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPrintinvoice.Size = new System.Drawing.Size(173, 15);
			this.chkPrintinvoice.TabIndex = 55;
			this.chkPrintinvoice.Text = "Do Not Print VAT On Invoice";
			this.chkPrintinvoice.UseVisualStyleBackColor = false;
			//
			//chkFinalizeCash
			//
			this.chkFinalizeCash.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkFinalizeCash.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkFinalizeCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkFinalizeCash.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkFinalizeCash.Location = new System.Drawing.Point(208, 590);
			this.chkFinalizeCash.Name = "chkFinalizeCash";
			this.chkFinalizeCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFinalizeCash.Size = new System.Drawing.Size(215, 17);
			this.chkFinalizeCash.TabIndex = 54;
			this.chkFinalizeCash.Text = "Cash Sales have to be finalized (Touch)";
			this.chkFinalizeCash.UseVisualStyleBackColor = false;
			//
			//chkDisplaySelling
			//
			this.chkDisplaySelling.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkDisplaySelling.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisplaySelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisplaySelling.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDisplaySelling.Location = new System.Drawing.Point(208, 570);
			this.chkDisplaySelling.Name = "chkDisplaySelling";
			this.chkDisplaySelling.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisplaySelling.Size = new System.Drawing.Size(179, 19);
			this.chkDisplaySelling.TabIndex = 53;
			this.chkDisplaySelling.Text = "Display Selling Price";
			this.chkDisplaySelling.UseVisualStyleBackColor = false;
			//
			//chkLearningPOS
			//
			this.chkLearningPOS.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkLearningPOS.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkLearningPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkLearningPOS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkLearningPOS.Location = new System.Drawing.Point(208, 551);
			this.chkLearningPOS.Name = "chkLearningPOS";
			this.chkLearningPOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkLearningPOS.Size = new System.Drawing.Size(179, 19);
			this.chkLearningPOS.TabIndex = 52;
			this.chkLearningPOS.Text = "POS Learning Mode";
			this.chkLearningPOS.UseVisualStyleBackColor = false;
			//
			//chkCurrency
			//
			this.chkCurrency.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkCurrency.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkCurrency.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkCurrency.Location = new System.Drawing.Point(-184, 578);
			this.chkCurrency.Name = "chkCurrency";
			this.chkCurrency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCurrency.Size = new System.Drawing.Size(187, 19);
			this.chkCurrency.TabIndex = 51;
			this.chkCurrency.Text = "Enable International Currency";
			this.chkCurrency.UseVisualStyleBackColor = false;
			this.chkCurrency.Visible = false;
			//
			//chkSerialTracking
			//
			this.chkSerialTracking.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSerialTracking.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSerialTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSerialTracking.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSerialTracking.Location = new System.Drawing.Point(-176, 464);
			this.chkSerialTracking.Name = "chkSerialTracking";
			this.chkSerialTracking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSerialTracking.Size = new System.Drawing.Size(186, 17);
			this.chkSerialTracking.TabIndex = 50;
			this.chkSerialTracking.Text = "Enable Serial Tracking in Sales";
			this.chkSerialTracking.UseVisualStyleBackColor = false;
			this.chkSerialTracking.Visible = false;
			//
			//chkPrintA4
			//
			this.chkPrintA4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkPrintA4.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPrintA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkPrintA4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkPrintA4.Location = new System.Drawing.Point(208, 534);
			this.chkPrintA4.Name = "chkPrintA4";
			this.chkPrintA4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPrintA4.Size = new System.Drawing.Size(258, 17);
			this.chkPrintA4.TabIndex = 49;
			this.chkPrintA4.Text = "Print A4 Invoice with Exclusive Total";
			this.chkPrintA4.UseVisualStyleBackColor = false;
			//
			//chkSerialNumber
			//
			this.chkSerialNumber.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSerialNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSerialNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSerialNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSerialNumber.Location = new System.Drawing.Point(22, 522);
			this.chkSerialNumber.Name = "chkSerialNumber";
			this.chkSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSerialNumber.Size = new System.Drawing.Size(161, 19);
			this.chkSerialNumber.TabIndex = 48;
			this.chkSerialNumber.Text = "Serial Reference Number";
			this.chkSerialNumber.UseVisualStyleBackColor = false;
			//
			//chkOrderNumber
			//
			this.chkOrderNumber.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkOrderNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkOrderNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkOrderNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkOrderNumber.Location = new System.Drawing.Point(22, 504);
			this.chkOrderNumber.Name = "chkOrderNumber";
			this.chkOrderNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkOrderNumber.Size = new System.Drawing.Size(161, 19);
			this.chkOrderNumber.TabIndex = 47;
			this.chkOrderNumber.Text = "Order Number Reference";
			this.chkOrderNumber.UseVisualStyleBackColor = false;
			//
			//chkCardNumber
			//
			this.chkCardNumber.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkCardNumber.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkCardNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkCardNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkCardNumber.Location = new System.Drawing.Point(22, 486);
			this.chkCardNumber.Name = "chkCardNumber";
			this.chkCardNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCardNumber.Size = new System.Drawing.Size(169, 19);
			this.chkCardNumber.TabIndex = 46;
			this.chkCardNumber.Text = "Card Number Reference";
			this.chkCardNumber.UseVisualStyleBackColor = false;
			//
			//chkLogoffAuto
			//
			this.chkLogoffAuto.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkLogoffAuto.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkLogoffAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkLogoffAuto.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkLogoffAuto.Location = new System.Drawing.Point(208, 520);
			this.chkLogoffAuto.Name = "chkLogoffAuto";
			this.chkLogoffAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkLogoffAuto.Size = new System.Drawing.Size(258, 13);
			this.chkLogoffAuto.TabIndex = 45;
			this.chkLogoffAuto.Text = "Automatically Logoff Cashier";
			this.chkLogoffAuto.UseVisualStyleBackColor = false;
			//
			//chkReceiptBarcode
			//
			this.chkReceiptBarcode.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkReceiptBarcode.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkReceiptBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkReceiptBarcode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkReceiptBarcode.Location = new System.Drawing.Point(208, 502);
			this.chkReceiptBarcode.Name = "chkReceiptBarcode";
			this.chkReceiptBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkReceiptBarcode.Size = new System.Drawing.Size(258, 13);
			this.chkReceiptBarcode.TabIndex = 44;
			this.chkReceiptBarcode.Text = "Print Barcodes on receipts";
			this.chkReceiptBarcode.UseVisualStyleBackColor = false;
			//
			//chkBypassTender
			//
			this.chkBypassTender.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkBypassTender.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBypassTender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkBypassTender.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkBypassTender.Location = new System.Drawing.Point(208, 484);
			this.chkBypassTender.Name = "chkBypassTender";
			this.chkBypassTender.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBypassTender.Size = new System.Drawing.Size(258, 13);
			this.chkBypassTender.TabIndex = 43;
			this.chkBypassTender.Text = "Bypass Cashout Tender";
			this.chkBypassTender.UseVisualStyleBackColor = false;
			//
			//chkSecurityPopup
			//
			this.chkSecurityPopup.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSecurityPopup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSecurityPopup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSecurityPopup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSecurityPopup.Location = new System.Drawing.Point(208, 466);
			this.chkSecurityPopup.Name = "chkSecurityPopup";
			this.chkSecurityPopup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSecurityPopup.Size = new System.Drawing.Size(258, 13);
			this.chkSecurityPopup.TabIndex = 42;
			this.chkSecurityPopup.Text = "Bypass Security Popup";
			this.chkSecurityPopup.UseVisualStyleBackColor = false;
			//
			//_txtFields_5
			//
			this._txtFields_5.AcceptsReturn = true;
			this._txtFields_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_5.Location = new System.Drawing.Point(160, 240);
			this._txtFields_5.MaxLength = 0;
			this._txtFields_5.Name = "_txtFields_5";
			this._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_5.Size = new System.Drawing.Size(39, 19);
			this._txtFields_5.TabIndex = 41;
			this._txtFields_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_5.Visible = false;
			//
			//Frame1
			//
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Frame1.Controls.Add(this._optPrint_2);
			this.Frame1.Controls.Add(this._optPrint_1);
			this.Frame1.Controls.Add(this._optPrint_0);
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(22, 188);
			this.Frame1.Name = "Frame1";
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(191, 79);
			this.Frame1.TabIndex = 7;
			this.Frame1.TabStop = false;
			this.Frame1.Text = "Print POS Transaction";
			//
			//_optPrint_2
			//
			this._optPrint_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optPrint_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optPrint_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrint_2.Location = new System.Drawing.Point(15, 36);
			this._optPrint_2.Name = "_optPrint_2";
			this._optPrint_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrint_2.Size = new System.Drawing.Size(112, 16);
			this._optPrint_2.TabIndex = 9;
			this._optPrint_2.TabStop = true;
			this._optPrint_2.Text = "No";
			this._optPrint_2.UseVisualStyleBackColor = false;
			//
			//_optPrint_1
			//
			this._optPrint_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optPrint_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optPrint_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrint_1.Location = new System.Drawing.Point(15, 18);
			this._optPrint_1.Name = "_optPrint_1";
			this._optPrint_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrint_1.Size = new System.Drawing.Size(112, 16);
			this._optPrint_1.TabIndex = 8;
			this._optPrint_1.TabStop = true;
			this._optPrint_1.Text = "Yes";
			this._optPrint_1.UseVisualStyleBackColor = false;
			//
			//_optPrint_0
			//
			this._optPrint_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optPrint_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optPrint_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrint_0.Location = new System.Drawing.Point(15, 54);
			this._optPrint_0.Name = "_optPrint_0";
			this._optPrint_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrint_0.Size = new System.Drawing.Size(112, 16);
			this._optPrint_0.TabIndex = 10;
			this._optPrint_0.TabStop = true;
			this._optPrint_0.Text = "Ask";
			this._optPrint_0.UseVisualStyleBackColor = false;
			//
			//chkSearchAuto
			//
			this.chkSearchAuto.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSearchAuto.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSearchAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSearchAuto.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSearchAuto.Location = new System.Drawing.Point(208, 448);
			this.chkSearchAuto.Name = "chkSearchAuto";
			this.chkSearchAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSearchAuto.Size = new System.Drawing.Size(256, 13);
			this.chkSearchAuto.TabIndex = 23;
			this.chkSearchAuto.Text = "Automatically search for stock items";
			this.chkSearchAuto.UseVisualStyleBackColor = false;
			//
			//_txtFields_9
			//
			this._txtFields_9.AcceptsReturn = true;
			this._txtFields_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_9.Location = new System.Drawing.Point(402, 426);
			this._txtFields_9.MaxLength = 0;
			this._txtFields_9.Name = "_txtFields_9";
			this._txtFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_9.Size = new System.Drawing.Size(43, 19);
			this._txtFields_9.TabIndex = 38;
			this._txtFields_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFields_9.Visible = false;
			//
			//chkDividingLine
			//
			this.chkDividingLine.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkDividingLine.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDividingLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDividingLine.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDividingLine.Location = new System.Drawing.Point(208, 432);
			this.chkDividingLine.Name = "chkDividingLine";
			this.chkDividingLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDividingLine.Size = new System.Drawing.Size(258, 13);
			this.chkDividingLine.TabIndex = 22;
			this.chkDividingLine.Text = "Print Dividing line on Receipt";
			this.chkDividingLine.UseVisualStyleBackColor = false;
			//
			//chkOpenTill
			//
			this.chkOpenTill.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkOpenTill.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkOpenTill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkOpenTill.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkOpenTill.Location = new System.Drawing.Point(208, 414);
			this.chkOpenTill.Name = "chkOpenTill";
			this.chkOpenTill.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkOpenTill.Size = new System.Drawing.Size(258, 13);
			this.chkOpenTill.TabIndex = 21;
			this.chkOpenTill.Text = "Only Open Till for Cash Transaction";
			this.chkOpenTill.UseVisualStyleBackColor = false;
			//
			//chkQuickCashup
			//
			this.chkQuickCashup.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkQuickCashup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkQuickCashup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkQuickCashup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkQuickCashup.Location = new System.Drawing.Point(208, 396);
			this.chkQuickCashup.Name = "chkQuickCashup";
			this.chkQuickCashup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkQuickCashup.Size = new System.Drawing.Size(258, 13);
			this.chkQuickCashup.TabIndex = 40;
			this.chkQuickCashup.Text = "Quick Cashup";
			this.chkQuickCashup.UseVisualStyleBackColor = false;
			//
			//chkBlindCashup
			//
			this.chkBlindCashup.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkBlindCashup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBlindCashup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkBlindCashup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkBlindCashup.Location = new System.Drawing.Point(208, 378);
			this.chkBlindCashup.Name = "chkBlindCashup";
			this.chkBlindCashup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBlindCashup.Size = new System.Drawing.Size(258, 13);
			this.chkBlindCashup.TabIndex = 39;
			this.chkBlindCashup.Text = "Blind Cashup";
			this.chkBlindCashup.UseVisualStyleBackColor = false;
			//
			//frmDeposits
			//
			this.frmDeposits.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.frmDeposits.Controls.Add(this._optDeposits_2);
			this.frmDeposits.Controls.Add(this._optDeposits_1);
			this.frmDeposits.Controls.Add(this._optDeposits_0);
			this.frmDeposits.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmDeposits.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmDeposits.Location = new System.Drawing.Point(22, 344);
			this.frmDeposits.Name = "frmDeposits";
			this.frmDeposits.Padding = new System.Windows.Forms.Padding(0);
			this.frmDeposits.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmDeposits.Size = new System.Drawing.Size(166, 82);
			this.frmDeposits.TabIndex = 16;
			this.frmDeposits.TabStop = false;
			this.frmDeposits.Text = "Deposits";
			//
			//_optDeposits_2
			//
			this._optDeposits_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optDeposits_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDeposits_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDeposits_2.Location = new System.Drawing.Point(8, 54);
			this._optDeposits_2.Name = "_optDeposits_2";
			this._optDeposits_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDeposits_2.Size = new System.Drawing.Size(145, 13);
			this._optDeposits_2.TabIndex = 19;
			this._optDeposits_2.TabStop = true;
			this._optDeposits_2.Text = "Automatically Determined";
			this._optDeposits_2.UseVisualStyleBackColor = false;
			//
			//_optDeposits_1
			//
			this._optDeposits_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optDeposits_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDeposits_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDeposits_1.Location = new System.Drawing.Point(8, 36);
			this._optDeposits_1.Name = "_optDeposits_1";
			this._optDeposits_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDeposits_1.Size = new System.Drawing.Size(145, 13);
			this._optDeposits_1.TabIndex = 18;
			this._optDeposits_1.TabStop = true;
			this._optDeposits_1.Text = "Pricing Group Two";
			this._optDeposits_1.UseVisualStyleBackColor = false;
			//
			//_optDeposits_0
			//
			this._optDeposits_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._optDeposits_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDeposits_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDeposits_0.Location = new System.Drawing.Point(8, 16);
			this._optDeposits_0.Name = "_optDeposits_0";
			this._optDeposits_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDeposits_0.Size = new System.Drawing.Size(145, 13);
			this._optDeposits_0.TabIndex = 17;
			this._optDeposits_0.TabStop = true;
			this._optDeposits_0.Text = "Pricing Group One";
			this._optDeposits_0.UseVisualStyleBackColor = false;
			//
			//chkSets
			//
			this.chkSets.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSets.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSets.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSets.Location = new System.Drawing.Point(208, 324);
			this.chkSets.Name = "chkSets";
			this.chkSets.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSets.Size = new System.Drawing.Size(250, 13);
			this.chkSets.TabIndex = 20;
			this.chkSets.Text = "Automatically Build Sets";
			this.chkSets.UseVisualStyleBackColor = false;
			//
			//chkShrink
			//
			this.chkShrink.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkShrink.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkShrink.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkShrink.Location = new System.Drawing.Point(208, 342);
			this.chkShrink.Name = "chkShrink";
			this.chkShrink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShrink.Size = new System.Drawing.Size(256, 13);
			this.chkShrink.TabIndex = 36;
			this.chkShrink.Text = "Automatically Build Shrinks";
			this.chkShrink.UseVisualStyleBackColor = false;
			//
			//chkSuppress
			//
			this.chkSuppress.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkSuppress.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSuppress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSuppress.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSuppress.Location = new System.Drawing.Point(208, 360);
			this.chkSuppress.Name = "chkSuppress";
			this.chkSuppress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSuppress.Size = new System.Drawing.Size(258, 13);
			this.chkSuppress.TabIndex = 37;
			this.chkSuppress.Text = "Switch on Suppress After Cashup";
			this.chkSuppress.UseVisualStyleBackColor = false;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(240, 60);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(225, 19);
			this._txtFields_0.TabIndex = 1;
			//
			//_txtFields_1
			//
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.Location = new System.Drawing.Point(240, 81);
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.Size = new System.Drawing.Size(225, 19);
			this._txtFields_1.TabIndex = 2;
			//
			//_txtFields_2
			//
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.Location = new System.Drawing.Point(240, 103);
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.Size = new System.Drawing.Size(225, 19);
			this._txtFields_2.TabIndex = 3;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(240, 124);
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(225, 19);
			this._txtFields_3.TabIndex = 4;
			//
			//_txtFields_4
			//
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.Location = new System.Drawing.Point(240, 145);
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.Size = new System.Drawing.Size(225, 19);
			this._txtFields_4.TabIndex = 5;
			//
			//_txtInteger_5
			//
			this._txtInteger_5.AcceptsReturn = true;
			this._txtInteger_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_5.Location = new System.Drawing.Point(422, 188);
			this._txtInteger_5.MaxLength = 0;
			this._txtInteger_5.Name = "_txtInteger_5";
			this._txtInteger_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_5.Size = new System.Drawing.Size(42, 19);
			this._txtInteger_5.TabIndex = 11;
			this._txtInteger_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtInteger_6
			//
			this._txtInteger_6.AcceptsReturn = true;
			this._txtInteger_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_6.Location = new System.Drawing.Point(422, 210);
			this._txtInteger_6.MaxLength = 0;
			this._txtInteger_6.Name = "_txtInteger_6";
			this._txtInteger_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_6.Size = new System.Drawing.Size(42, 19);
			this._txtInteger_6.TabIndex = 12;
			this._txtInteger_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtInteger_7
			//
			this._txtInteger_7.AcceptsReturn = true;
			this._txtInteger_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_7.Location = new System.Drawing.Point(422, 232);
			this._txtInteger_7.MaxLength = 0;
			this._txtInteger_7.Name = "_txtInteger_7";
			this._txtInteger_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_7.Size = new System.Drawing.Size(42, 19);
			this._txtInteger_7.TabIndex = 13;
			this._txtInteger_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtInteger_8
			//
			this._txtInteger_8.AcceptsReturn = true;
			this._txtInteger_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_8.Location = new System.Drawing.Point(422, 254);
			this._txtInteger_8.MaxLength = 0;
			this._txtInteger_8.Name = "_txtInteger_8";
			this._txtInteger_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_8.Size = new System.Drawing.Size(42, 19);
			this._txtInteger_8.TabIndex = 14;
			this._txtInteger_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(483, 39);
			this.picButtons.TabIndex = 26;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(12, 2);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 25;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(396, 2);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 24;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_lblLabels_10
			//
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Location = new System.Drawing.Point(208, 632);
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.Size = new System.Drawing.Size(221, 13);
			this._lblLabels_10.TabIndex = 62;
			this._lblLabels_10.Text = "Cent Rounding: default=5 Cent, max=50 Cent";
			//
			//_lblLabels_9
			//
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Location = new System.Drawing.Point(317, 277);
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.Size = new System.Drawing.Size(106, 13);
			this._lblLabels_9.TabIndex = 60;
			this._lblLabels_9.Text = "No of Payouts Prints:";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(12, 170);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(120, 14);
			this._lbl_0.TabIndex = 6;
			this._lbl_0.Text = "&2. Transaction Prints";
			//
			//_lblLabels_0
			//
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Location = new System.Drawing.Point(20, 64);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(135, 13);
			this._lblLabels_0.TabIndex = 27;
			this._lblLabels_0.Text = "First Receipt Heading Line:";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_1
			//
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Location = new System.Drawing.Point(28, 84);
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.Size = new System.Drawing.Size(153, 13);
			this._lblLabels_1.TabIndex = 28;
			this._lblLabels_1.Text = "Second Receipt Heading Line:";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_2
			//
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Location = new System.Drawing.Point(18, 106);
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.Size = new System.Drawing.Size(140, 13);
			this._lblLabels_2.TabIndex = 29;
			this._lblLabels_2.Text = "Third Receipt Heading Line:";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_3
			//
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Location = new System.Drawing.Point(20, 128);
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.Size = new System.Drawing.Size(80, 13);
			this._lblLabels_3.TabIndex = 30;
			this._lblLabels_3.Text = "Receipt Footer:";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_4
			//
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Location = new System.Drawing.Point(26, 148);
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.Size = new System.Drawing.Size(71, 13);
			this._lblLabels_4.TabIndex = 31;
			this._lblLabels_4.Text = "VAT Number:";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_5
			//
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Location = new System.Drawing.Point(217, 190);
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.Size = new System.Drawing.Size(152, 13);
			this._lblLabels_5.TabIndex = 32;
			this._lblLabels_5.Text = "No of Account Payment Prints:";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_6
			//
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Location = new System.Drawing.Point(223, 211);
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.Size = new System.Drawing.Size(132, 13);
			this._lblLabels_6.TabIndex = 33;
			this._lblLabels_6.Text = "No of Account Sale Prints:";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_7
			//
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Location = new System.Drawing.Point(219, 232);
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.Size = new System.Drawing.Size(138, 13);
			this._lblLabels_7.TabIndex = 34;
			this._lblLabels_7.Text = "Cash Before Delivery Prints:";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_8
			//
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Location = new System.Drawing.Point(222, 254);
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.Size = new System.Drawing.Size(129, 13);
			this._lblLabels_8.TabIndex = 35;
			this._lblLabels_8.Text = "No of Consignment Prints:";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(15, 42);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(100, 14);
			this._lbl_5.TabIndex = 0;
			this._lbl_5.Text = "&1. Receipt Details";
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(12, 304);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(118, 14);
			this._lbl_1.TabIndex = 15;
			this._lbl_1.Text = "&3. Other Parameters";
			//
			//frmPOSsetup
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(483, 670);
			this.ControlBox = false;
			this.Controls.Add(this._txtInteger_0);
			this.Controls.Add(this._txtInteger_9);
			this.Controls.Add(this.chkCustBal);
			this.Controls.Add(this.chkConCashup);
			this.Controls.Add(this._txtPrice_0);
			this.Controls.Add(this.chkCheckCash);
			this.Controls.Add(this.chkPrintinvoice);
			this.Controls.Add(this.chkFinalizeCash);
			this.Controls.Add(this.chkDisplaySelling);
			this.Controls.Add(this.chkLearningPOS);
			this.Controls.Add(this.chkCurrency);
			this.Controls.Add(this.chkSerialTracking);
			this.Controls.Add(this.chkPrintA4);
			this.Controls.Add(this.chkSerialNumber);
			this.Controls.Add(this.chkOrderNumber);
			this.Controls.Add(this.chkCardNumber);
			this.Controls.Add(this.chkLogoffAuto);
			this.Controls.Add(this.chkReceiptBarcode);
			this.Controls.Add(this.chkBypassTender);
			this.Controls.Add(this.chkSecurityPopup);
			this.Controls.Add(this._txtFields_5);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.chkSearchAuto);
			this.Controls.Add(this._txtFields_9);
			this.Controls.Add(this.chkDividingLine);
			this.Controls.Add(this.chkOpenTill);
			this.Controls.Add(this.chkQuickCashup);
			this.Controls.Add(this.chkBlindCashup);
			this.Controls.Add(this.frmDeposits);
			this.Controls.Add(this.chkSets);
			this.Controls.Add(this.chkShrink);
			this.Controls.Add(this.chkSuppress);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this._txtFields_1);
			this.Controls.Add(this._txtFields_2);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._txtFields_4);
			this.Controls.Add(this._txtInteger_5);
			this.Controls.Add(this._txtInteger_6);
			this.Controls.Add(this._txtInteger_7);
			this.Controls.Add(this._txtInteger_8);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._lblLabels_10);
			this.Controls.Add(this._lblLabels_9);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lblLabels_1);
			this.Controls.Add(this._lblLabels_2);
			this.Controls.Add(this._lblLabels_3);
			this.Controls.Add(this._lblLabels_4);
			this.Controls.Add(this._lblLabels_5);
			this.Controls.Add(this._lblLabels_6);
			this.Controls.Add(this._lblLabels_7);
			this.Controls.Add(this._lblLabels_8);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPOSsetup";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Point Of Sale Parameters";
			this.Frame1.ResumeLayout(false);
			this.frmDeposits.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
