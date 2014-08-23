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
	partial class frmCashTransactionItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCashTransactionItem() : base()
		{
			Load += frmCashTransactionItem_Load;
			KeyPress += frmCashTransactionItem_KeyPress;
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
		public System.Windows.Forms.CheckBox _chkChannel_1;
		public System.Windows.Forms.CheckBox _chkChannel_2;
		public System.Windows.Forms.CheckBox _chkChannel_3;
		public System.Windows.Forms.CheckBox _chkChannel_4;
		public System.Windows.Forms.CheckBox _chkChannel_5;
		public System.Windows.Forms.CheckBox _chkChannel_6;
		public System.Windows.Forms.CheckBox _chkChannel_7;
		public System.Windows.Forms.CheckBox _chkChannel_8;
		public System.Windows.Forms.CheckBox _chkChannel_9;
		public System.Windows.Forms.CheckBox _chkType_2;
		public System.Windows.Forms.CheckBox _chkType_1;
		public System.Windows.Forms.CheckBox _chkType_0;
		private System.Windows.Forms.TextBox withEventsField_txtPrice;
		public System.Windows.Forms.TextBox txtPrice {
			get { return withEventsField_txtPrice; }
			set {
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter -= txtPrice_Enter;
					withEventsField_txtPrice.KeyPress -= txtPrice_KeyPress;
					withEventsField_txtPrice.Leave -= txtPrice_Leave;
				}
				withEventsField_txtPrice = value;
				if (withEventsField_txtPrice != null) {
					withEventsField_txtPrice.Enter += txtPrice_Enter;
					withEventsField_txtPrice.KeyPress += txtPrice_KeyPress;
					withEventsField_txtPrice.Leave += txtPrice_Leave;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbQuantity;
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
		public System.Windows.Forms.Label _lbl_4;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label lblStockItem;
		//Public WithEvents chkChannel As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents chkType As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
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
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._chkChannel_1 = new System.Windows.Forms.CheckBox();
			this._chkChannel_2 = new System.Windows.Forms.CheckBox();
			this._chkChannel_3 = new System.Windows.Forms.CheckBox();
			this._chkChannel_4 = new System.Windows.Forms.CheckBox();
			this._chkChannel_5 = new System.Windows.Forms.CheckBox();
			this._chkChannel_6 = new System.Windows.Forms.CheckBox();
			this._chkChannel_7 = new System.Windows.Forms.CheckBox();
			this._chkChannel_8 = new System.Windows.Forms.CheckBox();
			this._chkChannel_9 = new System.Windows.Forms.CheckBox();
			this._chkType_2 = new System.Windows.Forms.CheckBox();
			this._chkType_1 = new System.Windows.Forms.CheckBox();
			this._chkType_0 = new System.Windows.Forms.CheckBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.cmbQuantity = new System.Windows.Forms.ComboBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			this.Shape1 = new _4PosBackOffice.NET.RectangleShapeArray(this.components);
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_0,
				this._Shape1_1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(465, 311);
			this.ShapeContainer1.TabIndex = 21;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_0, Convert.ToInt16(0));
			this._Shape1_0.Location = new System.Drawing.Point(3, 190);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(196, 81);
			//
			//_Shape1_1
			//
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_1, Convert.ToInt16(1));
			this._Shape1_1.Location = new System.Drawing.Point(204, 111);
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_1.Size = new System.Drawing.Size(181, 186);
			//
			//_chkChannel_1
			//
			this._chkChannel_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_1.Location = new System.Drawing.Point(216, 115);
			this._chkChannel_1.Name = "_chkChannel_1";
			this._chkChannel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_1.Size = new System.Drawing.Size(166, 23);
			this._chkChannel_1.TabIndex = 11;
			this._chkChannel_1.Text = "1. POS";
			this._chkChannel_1.UseVisualStyleBackColor = false;
			//
			//_chkChannel_2
			//
			this._chkChannel_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_2.Location = new System.Drawing.Point(216, 135);
			this._chkChannel_2.Name = "_chkChannel_2";
			this._chkChannel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_2.Size = new System.Drawing.Size(166, 19);
			this._chkChannel_2.TabIndex = 12;
			this._chkChannel_2.Text = "1. POS";
			this._chkChannel_2.UseVisualStyleBackColor = false;
			//
			//_chkChannel_3
			//
			this._chkChannel_3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_3.Location = new System.Drawing.Point(216, 155);
			this._chkChannel_3.Name = "_chkChannel_3";
			this._chkChannel_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_3.Size = new System.Drawing.Size(166, 16);
			this._chkChannel_3.TabIndex = 13;
			this._chkChannel_3.Text = "1. POS";
			this._chkChannel_3.UseVisualStyleBackColor = false;
			//
			//_chkChannel_4
			//
			this._chkChannel_4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_4.Location = new System.Drawing.Point(216, 176);
			this._chkChannel_4.Name = "_chkChannel_4";
			this._chkChannel_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_4.Size = new System.Drawing.Size(166, 16);
			this._chkChannel_4.TabIndex = 14;
			this._chkChannel_4.Text = "1. POS";
			this._chkChannel_4.UseVisualStyleBackColor = false;
			//
			//_chkChannel_5
			//
			this._chkChannel_5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_5.Location = new System.Drawing.Point(216, 198);
			this._chkChannel_5.Name = "_chkChannel_5";
			this._chkChannel_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_5.Size = new System.Drawing.Size(166, 16);
			this._chkChannel_5.TabIndex = 15;
			this._chkChannel_5.Text = "1. POS";
			this._chkChannel_5.UseVisualStyleBackColor = false;
			//
			//_chkChannel_6
			//
			this._chkChannel_6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_6.Location = new System.Drawing.Point(216, 218);
			this._chkChannel_6.Name = "_chkChannel_6";
			this._chkChannel_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_6.Size = new System.Drawing.Size(166, 17);
			this._chkChannel_6.TabIndex = 16;
			this._chkChannel_6.Text = "1. POS";
			this._chkChannel_6.UseVisualStyleBackColor = false;
			//
			//_chkChannel_7
			//
			this._chkChannel_7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_7.Location = new System.Drawing.Point(216, 240);
			this._chkChannel_7.Name = "_chkChannel_7";
			this._chkChannel_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_7.Size = new System.Drawing.Size(166, 16);
			this._chkChannel_7.TabIndex = 17;
			this._chkChannel_7.Text = "1. POS";
			this._chkChannel_7.UseVisualStyleBackColor = false;
			//
			//_chkChannel_8
			//
			this._chkChannel_8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_8.Location = new System.Drawing.Point(216, 260);
			this._chkChannel_8.Name = "_chkChannel_8";
			this._chkChannel_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_8.Size = new System.Drawing.Size(166, 16);
			this._chkChannel_8.TabIndex = 18;
			this._chkChannel_8.Text = "1. POS";
			this._chkChannel_8.UseVisualStyleBackColor = false;
			//
			//_chkChannel_9
			//
			this._chkChannel_9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkChannel_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkChannel_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkChannel_9.Location = new System.Drawing.Point(216, 278);
			this._chkChannel_9.Name = "_chkChannel_9";
			this._chkChannel_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkChannel_9.Size = new System.Drawing.Size(166, 20);
			this._chkChannel_9.TabIndex = 19;
			this._chkChannel_9.Text = "1. POS";
			this._chkChannel_9.UseVisualStyleBackColor = false;
			//
			//_chkType_2
			//
			this._chkType_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkType_2.Checked = true;
			this._chkType_2.CheckState = System.Windows.Forms.CheckState.Checked;
			this._chkType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkType_2.Location = new System.Drawing.Point(6, 246);
			this._chkType_2.Name = "_chkType_2";
			this._chkType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkType_2.Size = new System.Drawing.Size(187, 19);
			this._chkType_2.TabIndex = 9;
			this._chkType_2.Text = "Not Valid for Cheque Payments";
			this._chkType_2.UseVisualStyleBackColor = false;
			//
			//_chkType_1
			//
			this._chkType_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkType_1.Checked = true;
			this._chkType_1.CheckState = System.Windows.Forms.CheckState.Checked;
			this._chkType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkType_1.Location = new System.Drawing.Point(6, 223);
			this._chkType_1.Name = "_chkType_1";
			this._chkType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkType_1.Size = new System.Drawing.Size(187, 17);
			this._chkType_1.TabIndex = 8;
			this._chkType_1.Text = "Not Valid for Debit Cards Payments";
			this._chkType_1.UseVisualStyleBackColor = false;
			//
			//_chkType_0
			//
			this._chkType_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkType_0.Checked = true;
			this._chkType_0.CheckState = System.Windows.Forms.CheckState.Checked;
			this._chkType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkType_0.Location = new System.Drawing.Point(6, 201);
			this._chkType_0.Name = "_chkType_0";
			this._chkType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkType_0.Size = new System.Drawing.Size(187, 21);
			this._chkType_0.TabIndex = 7;
			this._chkType_0.Text = "Not Valid for Credit Card Payments";
			this._chkType_0.UseVisualStyleBackColor = false;
			//
			//txtPrice
			//
			this.txtPrice.AcceptsReturn = true;
			this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrice.Location = new System.Drawing.Point(111, 87);
			this.txtPrice.MaxLength = 0;
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPrice.Size = new System.Drawing.Size(79, 19);
			this.txtPrice.TabIndex = 5;
			this.txtPrice.Text = "0.00";
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//cmbQuantity
			//
			this.cmbQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.cmbQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbQuantity.Location = new System.Drawing.Point(111, 63);
			this.cmbQuantity.Name = "cmbQuantity";
			this.cmbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbQuantity.Size = new System.Drawing.Size(79, 21);
			this.cmbQuantity.TabIndex = 3;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(465, 39);
			this.picButtons.TabIndex = 20;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(303, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 21;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_lbl_4
			//
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Location = new System.Drawing.Point(6, 155);
			this._lbl_4.Name = "_lbl_4";
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.Size = new System.Drawing.Size(189, 34);
			this._lbl_4.TabIndex = 6;
			this._lbl_4.Text = "This Cash Transaction does not apply to the following payment methods.";
			//
			//_lbl_0
			//
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(207, 63);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(177, 43);
			this._lbl_0.TabIndex = 10;
			this._lbl_0.Text = "Disabled this Cash Transaction for the following checked Sale Channels.";
			//
			//_lbl_3
			//
			this._lbl_3.AutoSize = true;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(73, 90);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(34, 13);
			this._lbl_3.TabIndex = 4;
			this._lbl_3.Text = "Price:";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(39, 66);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(63, 13);
			this._lbl_2.TabIndex = 2;
			this._lbl_2.Text = "Shrink Size:";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(6, 45);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(92, 13);
			this._lbl_1.TabIndex = 0;
			this._lbl_1.Text = "Stock Item Name:";
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblStockItem
			//
			this.lblStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItem.Location = new System.Drawing.Point(111, 45);
			this.lblStockItem.Name = "lblStockItem";
			this.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItem.Size = new System.Drawing.Size(274, 17);
			this.lblStockItem.TabIndex = 1;
			this.lblStockItem.Text = "Label1";
			//
			//frmCashTransactionItem
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(465, 311);
			this.ControlBox = false;
			this.Controls.Add(this._chkChannel_1);
			this.Controls.Add(this._chkChannel_2);
			this.Controls.Add(this._chkChannel_3);
			this.Controls.Add(this._chkChannel_4);
			this.Controls.Add(this._chkChannel_5);
			this.Controls.Add(this._chkChannel_6);
			this.Controls.Add(this._chkChannel_7);
			this.Controls.Add(this._chkChannel_8);
			this.Controls.Add(this._chkChannel_9);
			this.Controls.Add(this._chkType_2);
			this.Controls.Add(this._chkType_1);
			this.Controls.Add(this._chkType_0);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.cmbQuantity);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._lbl_4);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lbl_3);
			this.Controls.Add(this._lbl_2);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this.lblStockItem);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCashTransactionItem";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit a Cash Transaction Item";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
