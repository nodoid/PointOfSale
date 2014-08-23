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
	partial class frmDeposit
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmDeposit() : base()
		{
			FormClosed += frmDeposit_FormClosed;
			KeyPress += frmDeposit_KeyPress;
			Resize += frmDeposit_Resize;
			Load += frmDeposit_Load;
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
		public System.Windows.Forms.CheckBox _chkFields_1;
		public System.Windows.Forms.TextBox _txtFloat_3;
		public System.Windows.Forms.TextBox _txtFloat_2;
		public System.Windows.Forms.TextBox _txtFloat_1;
		public System.Windows.Forms.TextBox _txtFloat_0;
		public System.Windows.Forms.TextBox _txtHide_1;
		public System.Windows.Forms.TextBox _txtHide_0;
		public System.Windows.Forms.TextBox _txtInteger_5;
		public System.Windows.Forms.TextBox _txtFields_4;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_28;
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
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
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
		private myDataGridView withEventsField_cmbVat;
		public myDataGridView cmbVat {
			get { return withEventsField_cmbVat; }
			set {
				if (withEventsField_cmbVat != null) {
					withEventsField_cmbVat.KeyDown -= cmbVat_KeyDown;
				}
				withEventsField_cmbVat = value;
				if (withEventsField_cmbVat != null) {
					withEventsField_cmbVat.KeyDown += cmbVat_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_38;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtHide As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this._txtFloat_3 = new System.Windows.Forms.TextBox();
			this._txtFloat_2 = new System.Windows.Forms.TextBox();
			this._txtFloat_1 = new System.Windows.Forms.TextBox();
			this._txtFloat_0 = new System.Windows.Forms.TextBox();
			this._txtHide_1 = new System.Windows.Forms.TextBox();
			this._txtHide_0 = new System.Windows.Forms.TextBox();
			this._txtInteger_5 = new System.Windows.Forms.TextBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_28 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmbVat = new _4PosBackOffice.NET.myDataGridView();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.Shape1 = new _4PosBackOffice.NET.RectangleShapeArray(this.components);
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.cmbVat).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_2,
				this._Shape1_0
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(549, 205);
			this.ShapeContainer1.TabIndex = 26;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_2, Convert.ToInt16(2));
			this._Shape1_2.Location = new System.Drawing.Point(15, 60);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(286, 136);
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_0, Convert.ToInt16(0));
			this._Shape1_0.Location = new System.Drawing.Point(309, 60);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(229, 76);
			//
			//_chkFields_1
			//
			this._chkFields_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_1.Location = new System.Drawing.Point(171, 174);
			this._chkFields_1.Name = "_chkFields_1";
			this._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_1.Size = new System.Drawing.Size(118, 19);
			this._chkFields_1.TabIndex = 11;
			this._chkFields_1.Text = "Disable this Deposit";
			this._chkFields_1.UseVisualStyleBackColor = false;
			//
			//_txtFloat_3
			//
			this._txtFloat_3.AcceptsReturn = true;
			this._txtFloat_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_3.Location = new System.Drawing.Point(465, 99);
			this._txtFloat_3.MaxLength = 0;
			this._txtFloat_3.Name = "_txtFloat_3";
			this._txtFloat_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_3.Size = new System.Drawing.Size(61, 19);
			this._txtFloat_3.TabIndex = 20;
			this._txtFloat_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_2
			//
			this._txtFloat_2.AcceptsReturn = true;
			this._txtFloat_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_2.Location = new System.Drawing.Point(402, 99);
			this._txtFloat_2.MaxLength = 0;
			this._txtFloat_2.Name = "_txtFloat_2";
			this._txtFloat_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_2.Size = new System.Drawing.Size(61, 19);
			this._txtFloat_2.TabIndex = 17;
			this._txtFloat_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_1
			//
			this._txtFloat_1.AcceptsReturn = true;
			this._txtFloat_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_1.Location = new System.Drawing.Point(465, 78);
			this._txtFloat_1.MaxLength = 0;
			this._txtFloat_1.Name = "_txtFloat_1";
			this._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_1.Size = new System.Drawing.Size(61, 19);
			this._txtFloat_1.TabIndex = 19;
			this._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_0
			//
			this._txtFloat_0.AcceptsReturn = true;
			this._txtFloat_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_0.Location = new System.Drawing.Point(402, 78);
			this._txtFloat_0.MaxLength = 0;
			this._txtFloat_0.Name = "_txtFloat_0";
			this._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_0.Size = new System.Drawing.Size(61, 19);
			this._txtFloat_0.TabIndex = 16;
			this._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtHide_1
			//
			this._txtHide_1.AcceptsReturn = true;
			this._txtHide_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtHide_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtHide_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtHide_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtHide_1.Location = new System.Drawing.Point(329, 167);
			this._txtHide_1.MaxLength = 0;
			this._txtHide_1.Name = "_txtHide_1";
			this._txtHide_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtHide_1.Size = new System.Drawing.Size(99, 19);
			this._txtHide_1.TabIndex = 25;
			this._txtHide_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtHide_1.Visible = false;
			//
			//_txtHide_0
			//
			this._txtHide_0.AcceptsReturn = true;
			this._txtHide_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtHide_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtHide_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtHide_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtHide_0.Location = new System.Drawing.Point(329, 142);
			this._txtHide_0.MaxLength = 0;
			this._txtHide_0.Name = "_txtHide_0";
			this._txtHide_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtHide_0.Size = new System.Drawing.Size(99, 19);
			this._txtHide_0.TabIndex = 24;
			this._txtHide_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtHide_0.Visible = false;
			//
			//_txtInteger_5
			//
			this._txtInteger_5.AcceptsReturn = true;
			this._txtInteger_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_5.Location = new System.Drawing.Point(239, 152);
			this._txtInteger_5.MaxLength = 0;
			this._txtInteger_5.Name = "_txtInteger_5";
			this._txtInteger_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_5.Size = new System.Drawing.Size(51, 19);
			this._txtInteger_5.TabIndex = 10;
			this._txtInteger_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFields_4
			//
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.Location = new System.Drawing.Point(104, 108);
			this._txtFields_4.MaxLength = 15;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.Size = new System.Drawing.Size(184, 19);
			this._txtFields_4.TabIndex = 6;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(105, 87);
			this._txtFields_3.MaxLength = 20;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(184, 19);
			this._txtFields_3.TabIndex = 4;
			//
			//_txtFields_28
			//
			this._txtFields_28.AcceptsReturn = true;
			this._txtFields_28.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_28.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_28.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_28.Location = new System.Drawing.Point(104, 64);
			this._txtFields_28.MaxLength = 128;
			this._txtFields_28.Name = "_txtFields_28";
			this._txtFields_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_28.Size = new System.Drawing.Size(184, 19);
			this._txtFields_28.TabIndex = 2;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdPrint);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(549, 39);
			this.picButtons.TabIndex = 23;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(375, 3);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.TabIndex = 26;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 22;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(460, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 21;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//cmbVat
			//
			this.cmbVat.AllowAddNew = true;
			this.cmbVat.BoundText = "";
			this.cmbVat.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbVat.Col = 0;
			this.cmbVat.CtlText = "";
			this.cmbVat.DataField = null;
			this.cmbVat.Location = new System.Drawing.Point(105, 129);
			this.cmbVat.Name = "cmbVat";
			this.cmbVat.row = 0;
			this.cmbVat.Size = new System.Drawing.Size(184, 21);
			this.cmbVat.TabIndex = 8;
			this.cmbVat.TopRow = 0;
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(309, 45);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(57, 14);
			this._lbl_0.TabIndex = 12;
			this._lbl_0.Text = "&2. Pricing";
			//
			//_lblLabels_2
			//
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Location = new System.Drawing.Point(72, 132);
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.Size = new System.Drawing.Size(31, 13);
			this._lblLabels_2.TabIndex = 7;
			this._lblLabels_2.Text = "VAT:";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_9
			//
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Location = new System.Drawing.Point(498, 66);
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.Size = new System.Drawing.Size(31, 13);
			this._lblLabels_9.TabIndex = 18;
			this._lblLabels_9.Text = "Case";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_8
			//
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Location = new System.Drawing.Point(432, 66);
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.Size = new System.Drawing.Size(34, 13);
			this._lblLabels_8.TabIndex = 15;
			this._lblLabels_8.Text = "Bottle";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_7
			//
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Location = new System.Drawing.Point(318, 99);
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.Size = new System.Drawing.Size(84, 13);
			this._lblLabels_7.TabIndex = 14;
			this._lblLabels_7.Text = "2. Special Price:";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_6
			//
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Location = new System.Drawing.Point(312, 81);
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.Size = new System.Drawing.Size(91, 13);
			this._lblLabels_6.TabIndex = 13;
			this._lblLabels_6.Text = "1. Inclusive Price:";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_5
			//
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Location = new System.Drawing.Point(104, 155);
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.Size = new System.Drawing.Size(138, 13);
			this._lblLabels_5.TabIndex = 9;
			this._lblLabels_5.Text = "Number of Bottles In a case";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_4
			//
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Location = new System.Drawing.Point(21, 108);
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.Size = new System.Drawing.Size(84, 13);
			this._lblLabels_4.TabIndex = 5;
			this._lblLabels_4.Text = "POS Quick Key:";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_3
			//
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Location = new System.Drawing.Point(27, 87);
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.Size = new System.Drawing.Size(78, 13);
			this._lblLabels_3.TabIndex = 3;
			this._lblLabels_3.Text = "Receipt Name:";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_38
			//
			this._lblLabels_38.AutoSize = true;
			this._lblLabels_38.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_38.Location = new System.Drawing.Point(30, 69);
			this._lblLabels_38.Name = "_lblLabels_38";
			this._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_38.Size = new System.Drawing.Size(75, 13);
			this._lblLabels_38.TabIndex = 1;
			this._lblLabels_38.Text = "Display Name:";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(15, 45);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(62, 14);
			this._lbl_5.TabIndex = 0;
			this._lbl_5.Text = "&1. General";
			//
			//frmDeposit
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(549, 205);
			this.ControlBox = false;
			this.Controls.Add(this._chkFields_1);
			this.Controls.Add(this._txtFloat_3);
			this.Controls.Add(this._txtFloat_2);
			this.Controls.Add(this._txtFloat_1);
			this.Controls.Add(this._txtFloat_0);
			this.Controls.Add(this._txtHide_1);
			this.Controls.Add(this._txtHide_0);
			this.Controls.Add(this._txtInteger_5);
			this.Controls.Add(this._txtFields_4);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._txtFields_28);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.cmbVat);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lblLabels_2);
			this.Controls.Add(this._lblLabels_9);
			this.Controls.Add(this._lblLabels_8);
			this.Controls.Add(this._lblLabels_7);
			this.Controls.Add(this._lblLabels_6);
			this.Controls.Add(this._lblLabels_5);
			this.Controls.Add(this._lblLabels_4);
			this.Controls.Add(this._lblLabels_3);
			this.Controls.Add(this._lblLabels_38);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeposit";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Deposit Details";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.cmbVat).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
