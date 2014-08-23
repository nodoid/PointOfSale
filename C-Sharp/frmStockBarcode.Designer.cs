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
	partial class frmStockBarcode
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockBarcode() : base()
		{
			FormClosed += frmStockBarcode_FormClosed;
			Load += frmStockBarcode_Load;
			KeyPress += frmStockBarcode_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdBuildSPLU;
		public System.Windows.Forms.Button cmdBuildSPLU {
			get { return withEventsField_cmdBuildSPLU; }
			set {
				if (withEventsField_cmdBuildSPLU != null) {
					withEventsField_cmdBuildSPLU.Click -= cmdBuildSPLU_Click;
				}
				withEventsField_cmdBuildSPLU = value;
				if (withEventsField_cmdBuildSPLU != null) {
					withEventsField_cmdBuildSPLU.Click += cmdBuildSPLU_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdBuildBarcodes;
		public System.Windows.Forms.Button cmdBuildBarcodes {
			get { return withEventsField_cmdBuildBarcodes; }
			set {
				if (withEventsField_cmdBuildBarcodes != null) {
					withEventsField_cmdBuildBarcodes.Click -= cmdBuildBarcodes_Click;
				}
				withEventsField_cmdBuildBarcodes = value;
				if (withEventsField_cmdBuildBarcodes != null) {
					withEventsField_cmdBuildBarcodes.Click += cmdBuildBarcodes_Click;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.CheckBox _chkBarcode_0;
		public System.Windows.Forms.TextBox _txtBarcode_0;
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lblBarcode_0;
		public System.Windows.Forms.Label _lbl_12;
		public System.Windows.Forms.Label _lbl_13;
		public System.Windows.Forms.Label _lbl_14;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		//Public WithEvents chkBarcode As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblBarcode As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtBarcode As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdBuildSPLU = new System.Windows.Forms.Button();
			this.cmdBuildBarcodes = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this._chkBarcode_0 = new System.Windows.Forms.CheckBox();
			this._txtBarcode_0 = new System.Windows.Forms.TextBox();
			this.lblHeading = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lblBarcode_0 = new System.Windows.Forms.Label();
			this._lbl_12 = new System.Windows.Forms.Label();
			this._lbl_13 = new System.Windows.Forms.Label();
			this._lbl_14 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] { this.Shape1 });
			this.ShapeContainer1.Size = new System.Drawing.Size(361, 184);
			this.ShapeContainer1.TabIndex = 11;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape1
			//
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.Location = new System.Drawing.Point(9, 75);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(349, 64);
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdBuildSPLU);
			this.picButtons.Controls.Add(this.cmdBuildBarcodes);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(361, 38);
			this.picButtons.TabIndex = 6;
			//
			//cmdBuildSPLU
			//
			this.cmdBuildSPLU.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildSPLU.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuildSPLU.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildSPLU.Location = new System.Drawing.Point(184, 3);
			this.cmdBuildSPLU.Name = "cmdBuildSPLU";
			this.cmdBuildSPLU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildSPLU.Size = new System.Drawing.Size(88, 29);
			this.cmdBuildSPLU.TabIndex = 12;
			this.cmdBuildSPLU.TabStop = false;
			this.cmdBuildSPLU.Text = "&Build Scale PLU";
			this.cmdBuildSPLU.UseVisualStyleBackColor = false;
			//
			//cmdBuildBarcodes
			//
			this.cmdBuildBarcodes.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildBarcodes.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBuildBarcodes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildBarcodes.Location = new System.Drawing.Point(87, 3);
			this.cmdBuildBarcodes.Name = "cmdBuildBarcodes";
			this.cmdBuildBarcodes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildBarcodes.Size = new System.Drawing.Size(88, 29);
			this.cmdBuildBarcodes.TabIndex = 11;
			this.cmdBuildBarcodes.TabStop = false;
			this.cmdBuildBarcodes.Text = "&Build Barcode";
			this.cmdBuildBarcodes.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(280, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 8;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
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
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//_chkBarcode_0
			//
			this._chkBarcode_0.BackColor = System.Drawing.SystemColors.Window;
			this._chkBarcode_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkBarcode_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkBarcode_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkBarcode_0.Location = new System.Drawing.Point(243, 102);
			this._chkBarcode_0.Name = "_chkBarcode_0";
			this._chkBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkBarcode_0.Size = new System.Drawing.Size(13, 13);
			this._chkBarcode_0.TabIndex = 1;
			this._chkBarcode_0.UseVisualStyleBackColor = false;
			//
			//_txtBarcode_0
			//
			this._txtBarcode_0.AcceptsReturn = true;
			this._txtBarcode_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtBarcode_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtBarcode_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtBarcode_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtBarcode_0.Location = new System.Drawing.Point(66, 99);
			this._txtBarcode_0.MaxLength = 0;
			this._txtBarcode_0.Name = "_txtBarcode_0";
			this._txtBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtBarcode_0.Size = new System.Drawing.Size(154, 19);
			this._txtBarcode_0.TabIndex = 0;
			this._txtBarcode_0.Text = "99999999999999";
			//
			//lblHeading
			//
			this.lblHeading.BackColor = System.Drawing.SystemColors.Control;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Location = new System.Drawing.Point(0, 39);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.Size = new System.Drawing.Size(359, 19);
			this.lblHeading.TabIndex = 10;
			this.lblHeading.Text = "Label1";
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(9, 60);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(64, 13);
			this._lbl_2.TabIndex = 9;
			this._lbl_2.Text = "&1. Barcodes";
			//
			//_lblBarcode_0
			//
			this._lblBarcode_0.BackColor = System.Drawing.Color.Transparent;
			this._lblBarcode_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblBarcode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblBarcode_0.Location = new System.Drawing.Point(21, 102);
			this._lblBarcode_0.Name = "_lblBarcode_0";
			this._lblBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblBarcode_0.Size = new System.Drawing.Size(40, 13);
			this._lblBarcode_0.TabIndex = 5;
			this._lblBarcode_0.Text = "Bonne";
			this._lblBarcode_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_12
			//
			this._lbl_12.AutoSize = true;
			this._lbl_12.BackColor = System.Drawing.Color.Transparent;
			this._lbl_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_12.Location = new System.Drawing.Point(102, 84);
			this._lbl_12.Name = "_lbl_12";
			this._lbl_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_12.Size = new System.Drawing.Size(51, 13);
			this._lbl_12.TabIndex = 4;
			this._lbl_12.Text = "Bar Code";
			this._lbl_12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			//
			//_lbl_13
			//
			this._lbl_13.AutoSize = true;
			this._lbl_13.BackColor = System.Drawing.Color.Transparent;
			this._lbl_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_13.Location = new System.Drawing.Point(21, 84);
			this._lbl_13.Name = "_lbl_13";
			this._lbl_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_13.Size = new System.Drawing.Size(37, 13);
			this._lbl_13.TabIndex = 3;
			this._lbl_13.Text = "Shrink";
			//
			//_lbl_14
			//
			this._lbl_14.AutoSize = true;
			this._lbl_14.BackColor = System.Drawing.Color.Transparent;
			this._lbl_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_14.Location = new System.Drawing.Point(228, 84);
			this._lbl_14.Name = "_lbl_14";
			this._lbl_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_14.Size = new System.Drawing.Size(42, 13);
			this._lbl_14.TabIndex = 2;
			this._lbl_14.Text = "Disable";
			//
			//frmStockBarcode
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(361, 184);
			this.ControlBox = false;
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._chkBarcode_0);
			this.Controls.Add(this._txtBarcode_0);
			this.Controls.Add(this.lblHeading);
			this.Controls.Add(this._lbl_2);
			this.Controls.Add(this._lblBarcode_0);
			this.Controls.Add(this._lbl_12);
			this.Controls.Add(this._lbl_13);
			this.Controls.Add(this._lbl_14);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmStockBarcode";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Maintain Stock Item Barcodes";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
