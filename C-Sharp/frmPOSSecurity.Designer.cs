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
	partial class frmPOSSecurity
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPOSSecurity() : base()
		{
			FormClosed += frmPOSSecurity_FormClosed;
			KeyPress += frmPOSSecurity_KeyPress;
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
		private System.Windows.Forms.CheckBox withEventsField_chkPosSecurity;
		public System.Windows.Forms.CheckBox chkPosSecurity {
			get { return withEventsField_chkPosSecurity; }
			set {
				if (withEventsField_chkPosSecurity != null) {
					withEventsField_chkPosSecurity.CheckStateChanged -= chkPosSecurity_CheckStateChanged;
				}
				withEventsField_chkPosSecurity = value;
				if (withEventsField_chkPosSecurity != null) {
					withEventsField_chkPosSecurity.CheckStateChanged += chkPosSecurity_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.CheckedListBox withEventsField_lstChannel;
		public System.Windows.Forms.CheckedListBox lstChannel {
			get { return withEventsField_lstChannel; }
			set {
				if (withEventsField_lstChannel != null) {
					withEventsField_lstChannel.ItemCheck -= lstChannel_ItemCheck;
				}
				withEventsField_lstChannel = value;
				if (withEventsField_lstChannel != null) {
					withEventsField_lstChannel.ItemCheck += lstChannel_ItemCheck;
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
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.Label _Label1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Label _Label1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
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
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.chkPosSecurity = new System.Windows.Forms.CheckBox();
			this.lstChannel = new System.Windows.Forms.CheckedListBox();
			this.lstSecurity = new System.Windows.Forms.CheckedListBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_1,
				this._Shape1_0
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(493, 486);
			this.ShapeContainer1.TabIndex = 9;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_1
			//
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.Location = new System.Drawing.Point(252, 78);
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_1.Size = new System.Drawing.Size(232, 373);
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.Location = new System.Drawing.Point(9, 78);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(232, 373);
			//
			//chkPosSecurity
			//
			this.chkPosSecurity.BackColor = System.Drawing.SystemColors.Control;
			this.chkPosSecurity.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPosSecurity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPosSecurity.Location = new System.Drawing.Point(10, 456);
			this.chkPosSecurity.Name = "chkPosSecurity";
			this.chkPosSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPosSecurity.Size = new System.Drawing.Size(233, 19);
			this.chkPosSecurity.TabIndex = 8;
			this.chkPosSecurity.Text = "Select All";
			this.chkPosSecurity.UseVisualStyleBackColor = false;
			//
			//lstChannel
			//
			this.lstChannel.BackColor = System.Drawing.SystemColors.Window;
			this.lstChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstChannel.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstChannel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstChannel.Location = new System.Drawing.Point(264, 90);
			this.lstChannel.Name = "lstChannel";
			this.lstChannel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstChannel.Size = new System.Drawing.Size(208, 347);
			this.lstChannel.TabIndex = 5;
			this.lstChannel.Tag = "0";
			//
			//lstSecurity
			//
			this.lstSecurity.BackColor = System.Drawing.SystemColors.Window;
			this.lstSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSecurity.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSecurity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSecurity.Location = new System.Drawing.Point(22, 90);
			this.lstSecurity.Name = "lstSecurity";
			this.lstSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSecurity.Size = new System.Drawing.Size(208, 347);
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
			this.picButtons.Size = new System.Drawing.Size(493, 39);
			this.picButtons.TabIndex = 2;
			//
			//cmdExit
			//
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(411, 3);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.TabIndex = 1;
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
			this.cmdCancel.TabIndex = 0;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//_Label1_2
			//
			this._Label1_2.AutoSize = true;
			this._Label1_2.BackColor = System.Drawing.Color.Transparent;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Location = new System.Drawing.Point(12, 42);
			this._Label1_2.Name = "_Label1_2";
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.Size = new System.Drawing.Size(35, 13);
			this._Label1_2.TabIndex = 7;
			this._Label1_2.Text = "Name";
			//
			//_Label1_1
			//
			this._Label1_1.AutoSize = true;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Location = new System.Drawing.Point(12, 63);
			this._Label1_1.Name = "_Label1_1";
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.Size = new System.Drawing.Size(74, 13);
			this._Label1_1.TabIndex = 6;
			this._Label1_1.Text = "&1. Permissions";
			//
			//_Label1_0
			//
			this._Label1_0.AutoSize = true;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Location = new System.Drawing.Point(255, 63);
			this._Label1_0.Name = "_Label1_0";
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.Size = new System.Drawing.Size(120, 13);
			this._Label1_0.TabIndex = 4;
			this._Label1_0.Text = "&2. Sale Channel Access";
			//
			//frmPOSSecurity
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(493, 486);
			this.ControlBox = false;
			this.Controls.Add(this.chkPosSecurity);
			this.Controls.Add(this.lstChannel);
			this.Controls.Add(this.lstSecurity);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._Label1_2);
			this.Controls.Add(this._Label1_1);
			this.Controls.Add(this._Label1_0);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPOSSecurity";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Employee Point Of Sale Permissions";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
