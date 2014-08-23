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
	partial class frmBOSecurity
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBOSecurity() : base()
		{
			FormClosed += frmBOSecurity_FormClosed;
			KeyPress += frmBOSecurity_KeyPress;
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
		private System.Windows.Forms.CheckBox withEventsField_chkSelectAll;
		public System.Windows.Forms.CheckBox chkSelectAll {
			get { return withEventsField_chkSelectAll; }
			set {
				if (withEventsField_chkSelectAll != null) {
					withEventsField_chkSelectAll.CheckStateChanged -= chkSelectAll_CheckStateChanged;
				}
				withEventsField_chkSelectAll = value;
				if (withEventsField_chkSelectAll != null) {
					withEventsField_chkSelectAll.CheckStateChanged += chkSelectAll_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.CheckedListBox lstSecurity;
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
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label lbl;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
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
			this.chkSelectAll = new System.Windows.Forms.CheckBox();
			this.lstSecurity = new System.Windows.Forms.CheckedListBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
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
			this.ShapeContainer1.Size = new System.Drawing.Size(359, 415);
			this.ShapeContainer1.TabIndex = 6;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape1
			//
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.Location = new System.Drawing.Point(4, 62);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(340, 328);
			//
			//chkSelectAll
			//
			this.chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
			this.chkSelectAll.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSelectAll.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.chkSelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkSelectAll.Location = new System.Drawing.Point(8, 396);
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSelectAll.Size = new System.Drawing.Size(211, 17);
			this.chkSelectAll.TabIndex = 5;
			this.chkSelectAll.Text = "Select All";
			this.chkSelectAll.UseVisualStyleBackColor = false;
			//
			//lstSecurity
			//
			this.lstSecurity.BackColor = System.Drawing.SystemColors.Window;
			this.lstSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSecurity.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSecurity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSecurity.Location = new System.Drawing.Point(16, 72);
			this.lstSecurity.Name = "lstSecurity";
			this.lstSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSecurity.Size = new System.Drawing.Size(316, 302);
			this.lstSecurity.TabIndex = 3;
			this.lstSecurity.Tag = "0";
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdExit);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(359, 39);
			this.picButtons.TabIndex = 0;
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
			//lbl
			//
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Location = new System.Drawing.Point(12, 48);
			this.lbl.Name = "lbl";
			this.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl.Size = new System.Drawing.Size(62, 14);
			this.lbl.TabIndex = 4;
			this.lbl.Text = "&1. General";
			//
			//frmBOSecurity
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(359, 415);
			this.ControlBox = false;
			this.Controls.Add(this.chkSelectAll);
			this.Controls.Add(this.lstSecurity);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.lbl);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBOSecurity";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Employee Back Office Permissions";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
