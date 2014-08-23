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
	partial class frmCustomerStatementRun
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCustomerStatementRun() : base()
		{
			FormClosed += frmCustomerStatementRun_FormClosed;
			KeyPress += frmCustomerStatementRun_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdClear;
		public System.Windows.Forms.Button cmdClear {
			get { return withEventsField_cmdClear; }
			set {
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click -= cmdClear_Click;
				}
				withEventsField_cmdClear = value;
				if (withEventsField_cmdClear != null) {
					withEventsField_cmdClear.Click += cmdClear_Click;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.CheckedListBox lstCustomer;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label lbl;
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
			this.cmdClear = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.lstCustomer = new System.Windows.Forms.CheckedListBox();
			this.lbl = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] { this.Shape1 });
			this.ShapeContainer1.Size = new System.Drawing.Size(358, 406);
			this.ShapeContainer1.TabIndex = 5;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape1
			//
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.Location = new System.Drawing.Point(9, 63);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(340, 328);
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdClear);
			this.picButtons.Controls.Add(this.cmdPrint);
			this.picButtons.Controls.Add(this.cmdExit);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(358, 39);
			this.picButtons.TabIndex = 1;
			//
			//cmdClear
			//
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Location = new System.Drawing.Point(183, 3);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.Size = new System.Drawing.Size(73, 29);
			this.cmdClear.TabIndex = 5;
			this.cmdClear.TabStop = false;
			this.cmdClear.Text = "&Clear All";
			this.cmdClear.UseVisualStyleBackColor = false;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(5, 3);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(276, 3);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.TabIndex = 2;
			this.cmdExit.TabStop = false;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = false;
			//
			//lstCustomer
			//
			this.lstCustomer.BackColor = System.Drawing.SystemColors.Window;
			this.lstCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstCustomer.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCustomer.Location = new System.Drawing.Point(21, 75);
			this.lstCustomer.Name = "lstCustomer";
			this.lstCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCustomer.Size = new System.Drawing.Size(316, 302);
			this.lstCustomer.TabIndex = 0;
			this.lstCustomer.Tag = "0";
			//
			//lbl
			//
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Location = new System.Drawing.Point(12, 48);
			this.lbl.Name = "lbl";
			this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl.Size = new System.Drawing.Size(68, 13);
			this.lbl.TabIndex = 4;
			this.lbl.Text = "&1. Customers";
			//
			//frmCustomerStatementRun
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(358, 406);
			this.ControlBox = false;
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.lstCustomer);
			this.Controls.Add(this.lbl);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCustomerStatementRun";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Customer Statement Run";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
