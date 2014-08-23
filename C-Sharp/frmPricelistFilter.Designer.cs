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
	partial class frmPricelistFilter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPricelistFilter() : base()
		{
			FormClosed += frmPricelistFilter_FormClosed;
			KeyPress += frmPricelistFilter_KeyPress;
			Resize += frmPricelistFilter_Resize;
			Load += frmPricelistFilter_Load;
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
		private System.Windows.Forms.CheckBox withEventsField_chkChannel;
		public System.Windows.Forms.CheckBox chkChannel {
			get { return withEventsField_chkChannel; }
			set {
				if (withEventsField_chkChannel != null) {
					withEventsField_chkChannel.CheckStateChanged -= chkChannel_CheckStateChanged;
				}
				withEventsField_chkChannel = value;
				if (withEventsField_chkChannel != null) {
					withEventsField_chkChannel.CheckStateChanged += chkChannel_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbDelivery;
		public System.Windows.Forms.ComboBox cmbCOD;
		public System.Windows.Forms.CheckBox _chkFields_12;
		private System.Windows.Forms.TextBox withEventsField__txtFields_0;
		public System.Windows.Forms.TextBox _txtFields_0 {
			get { return withEventsField__txtFields_0; }
			set {
				if (withEventsField__txtFields_0 != null) {
					withEventsField__txtFields_0.Enter -= txtFields_Enter;
				}
				withEventsField__txtFields_0 = value;
				if (withEventsField__txtFields_0 != null) {
					withEventsField__txtFields_0.Enter += txtFields_Enter;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAllocate;
		public System.Windows.Forms.Button cmdAllocate {
			get { return withEventsField_cmdAllocate; }
			set {
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click -= cmdAllocate_Click;
				}
				withEventsField_cmdAllocate = value;
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click += cmdAllocate_Click;
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
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_38;
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
			this.cmdPrint = new System.Windows.Forms.Button();
			this.chkChannel = new System.Windows.Forms.CheckBox();
			this.cmbDelivery = new System.Windows.Forms.ComboBox();
			this.cmbCOD = new System.Windows.Forms.ComboBox();
			this._chkFields_12 = new System.Windows.Forms.CheckBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
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
			this.ShapeContainer1.Size = new System.Drawing.Size(406, 131);
			this.ShapeContainer1.TabIndex = 13;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_2
			//
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.Location = new System.Drawing.Point(15, 60);
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_2.Size = new System.Drawing.Size(379, 64);
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(320, 240);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(76, 28);
			this.cmdPrint.TabIndex = 12;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//chkChannel
			//
			this.chkChannel.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.chkChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkChannel.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkChannel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkChannel.Location = new System.Drawing.Point(218, 199);
			this.chkChannel.Name = "chkChannel";
			this.chkChannel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkChannel.Size = new System.Drawing.Size(136, 13);
			this.chkChannel.TabIndex = 5;
			this.chkChannel.Text = "Delivery Channel Name:";
			this.chkChannel.UseVisualStyleBackColor = false;
			//
			//cmbDelivery
			//
			this.cmbDelivery.BackColor = System.Drawing.SystemColors.Window;
			this.cmbDelivery.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDelivery.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbDelivery.Location = new System.Drawing.Point(218, 214);
			this.cmbDelivery.Name = "cmbDelivery";
			this.cmbDelivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbDelivery.Size = new System.Drawing.Size(178, 21);
			this.cmbDelivery.TabIndex = 6;
			//
			//cmbCOD
			//
			this.cmbCOD.BackColor = System.Drawing.SystemColors.Window;
			this.cmbCOD.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbCOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCOD.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbCOD.Location = new System.Drawing.Point(29, 214);
			this.cmbCOD.Name = "cmbCOD";
			this.cmbCOD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbCOD.Size = new System.Drawing.Size(178, 21);
			this.cmbCOD.TabIndex = 4;
			//
			//_chkFields_12
			//
			this._chkFields_12.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_12.Location = new System.Drawing.Point(320, 96);
			this._chkFields_12.Name = "_chkFields_12";
			this._chkFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_12.Size = new System.Drawing.Size(64, 19);
			this._chkFields_12.TabIndex = 7;
			this._chkFields_12.Text = "Disabled:";
			this._chkFields_12.UseVisualStyleBackColor = false;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(140, 66);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(247, 19);
			this._txtFields_0.TabIndex = 2;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdAllocate);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(406, 39);
			this.picButtons.TabIndex = 10;
			//
			//cmdAllocate
			//
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Location = new System.Drawing.Point(192, 3);
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Size = new System.Drawing.Size(119, 28);
			this.cmdAllocate.TabIndex = 11;
			this.cmdAllocate.Text = "&Allocate Stock Items";
			this.cmdAllocate.UseVisualStyleBackColor = false;
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
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(324, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 8;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//_lblLabels_0
			//
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Location = new System.Drawing.Point(28, 199);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(106, 13);
			this._lblLabels_0.TabIndex = 3;
			this._lblLabels_0.Text = "COD Channel Name:";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_38
			//
			this._lblLabels_38.AutoSize = true;
			this._lblLabels_38.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_38.Location = new System.Drawing.Point(24, 69);
			this._lblLabels_38.Name = "_lblLabels_38";
			this._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_38.Size = new System.Drawing.Size(116, 13);
			this._lblLabels_38.TabIndex = 1;
			this._lblLabels_38.Text = "Price List Group Name:";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(15, 45);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(56, 13);
			this._lbl_5.TabIndex = 0;
			this._lbl_5.Text = "&1. General";
			//
			//frmPricelistFilter
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(406, 131);
			this.ControlBox = false;
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.chkChannel);
			this.Controls.Add(this.cmbDelivery);
			this.Controls.Add(this.cmbCOD);
			this.Controls.Add(this._chkFields_12);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lblLabels_38);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPricelistFilter";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Price List Group";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
