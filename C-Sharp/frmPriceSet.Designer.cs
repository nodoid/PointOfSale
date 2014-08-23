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
	partial class frmPriceSet
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPriceSet() : base()
		{
			Load += frmPriceSet_Load;
			FormClosed += frmPriceSet_FormClosed;
			KeyDown += frmPriceSet_KeyDown;
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
		public System.Windows.Forms.TextBox txtholdvalue;
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEmulate;
		public System.Windows.Forms.Button cmdEmulate {
			get { return withEventsField_cmdEmulate; }
			set {
				if (withEventsField_cmdEmulate != null) {
					withEventsField_cmdEmulate.Click -= cmdEmulate_Click;
				}
				withEventsField_cmdEmulate = value;
				if (withEventsField_cmdEmulate != null) {
					withEventsField_cmdEmulate.Click += cmdEmulate_Click;
				}
			}
		}
		public System.Windows.Forms.CheckBox _chkFields_0;
		private System.Windows.Forms.TextBox withEventsField__txtFields_0;
		public System.Windows.Forms.TextBox _txtFields_0 {
			get { return withEventsField__txtFields_0; }
			set {
				if (withEventsField__txtFields_0 != null) {
					withEventsField__txtFields_0.TextChanged -= txtFields_TextChanged;
					withEventsField__txtFields_0.Enter -= txtFields_Enter;
				}
				withEventsField__txtFields_0 = value;
				if (withEventsField__txtFields_0 != null) {
					withEventsField__txtFields_0.TextChanged += txtFields_TextChanged;
					withEventsField__txtFields_0.Enter += txtFields_Enter;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintAll;
		public System.Windows.Forms.Button cmdPrintAll {
			get { return withEventsField_cmdPrintAll; }
			set {
				if (withEventsField_cmdPrintAll != null) {
					withEventsField_cmdPrintAll.Click -= cmdPrintAll_Click;
				}
				withEventsField_cmdPrintAll = value;
				if (withEventsField_cmdPrintAll != null) {
					withEventsField_cmdPrintAll.Click += cmdPrintAll_Click;
				}
			}
		}
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
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label lblStockItem;
		public System.Windows.Forms.Label _lblLabels_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this.txtholdvalue = new System.Windows.Forms.TextBox();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdEmulate = new System.Windows.Forms.Button();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrintAll = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this.lblStockItem = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] { this._Shape1_2 });
			this.ShapeContainer1.Size = new System.Drawing.Size(408, 204);
			this.ShapeContainer1.TabIndex = 13;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.Location = new System.Drawing.Point(9, 60);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(322, 112);
			//
			//txtholdvalue
			//
			this.txtholdvalue.AcceptsReturn = true;
			this.txtholdvalue.BackColor = System.Drawing.SystemColors.Window;
			this.txtholdvalue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtholdvalue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtholdvalue.Location = new System.Drawing.Point(90, 236);
			this.txtholdvalue.MaxLength = 0;
			this.txtholdvalue.Name = "txtholdvalue";
			this.txtholdvalue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtholdvalue.Size = new System.Drawing.Size(71, 19);
			this.txtholdvalue.TabIndex = 12;
			//
			//cmdEdit
			//
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Location = new System.Drawing.Point(282, 147);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.Size = new System.Drawing.Size(37, 17);
			this.cmdEdit.TabIndex = 11;
			this.cmdEdit.Text = "&Edit";
			this.cmdEdit.UseVisualStyleBackColor = false;
			//
			//cmdEmulate
			//
			this.cmdEmulate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEmulate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEmulate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEmulate.Location = new System.Drawing.Point(282, 128);
			this.cmdEmulate.Name = "cmdEmulate";
			this.cmdEmulate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEmulate.Size = new System.Drawing.Size(37, 17);
			this.cmdEmulate.TabIndex = 10;
			this.cmdEmulate.Text = "...";
			this.cmdEmulate.UseVisualStyleBackColor = false;
			//
			//_chkFields_0
			//
			this._chkFields_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Location = new System.Drawing.Point(222, 90);
			this._chkFields_0.Name = "_chkFields_0";
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Size = new System.Drawing.Size(97, 19);
			this._chkFields_0.TabIndex = 6;
			this._chkFields_0.Text = "Disable this Set:";
			this._chkFields_0.UseVisualStyleBackColor = false;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(96, 66);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(226, 19);
			this._txtFields_0.TabIndex = 5;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdPrintAll);
			this.picButtons.Controls.Add(this.cmdPrint);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(408, 39);
			this.picButtons.TabIndex = 2;
			//
			//cmdPrintAll
			//
			this.cmdPrintAll.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintAll.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintAll.Location = new System.Drawing.Point(96, 3);
			this.cmdPrintAll.Name = "cmdPrintAll";
			this.cmdPrintAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintAll.Size = new System.Drawing.Size(73, 29);
			this.cmdPrintAll.TabIndex = 13;
			this.cmdPrintAll.Text = "&Print All";
			this.cmdPrintAll.UseVisualStyleBackColor = false;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(183, 3);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.TabIndex = 7;
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
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(261, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_lblLabels_1
			//
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Location = new System.Drawing.Point(16, 114);
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.Size = new System.Drawing.Size(98, 13);
			this._lblLabels_1.TabIndex = 9;
			this._lblLabels_1.Text = "Primary Stock Item:";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//lblStockItem
			//
			this.lblStockItem.BackColor = System.Drawing.SystemColors.Control;
			this.lblStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockItem.Location = new System.Drawing.Point(15, 129);
			this.lblStockItem.Name = "lblStockItem";
			this.lblStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockItem.Size = new System.Drawing.Size(262, 16);
			this.lblStockItem.TabIndex = 8;
			this.lblStockItem.Text = "No Stock Item Selected";
			//
			//_lblLabels_0
			//
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Location = new System.Drawing.Point(14, 69);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(84, 13);
			this._lblLabels_0.TabIndex = 4;
			this._lblLabels_0.Text = "Price Set Name:";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(9, 45);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(56, 13);
			this._lbl_5.TabIndex = 3;
			this._lbl_5.Text = "&1. General";
			//
			//frmPriceSet
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(408, 204);
			this.ControlBox = false;
			this.Controls.Add(this.txtholdvalue);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdEmulate);
			this.Controls.Add(this._chkFields_0);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._lblLabels_1);
			this.Controls.Add(this.lblStockItem);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPriceSet";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Pricing Set Details";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
