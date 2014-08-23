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
	partial class frmCompanyEmails
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCompanyEmails() : base()
		{
			Load += frmCompanyEmails_Load;
			FormClosed += frmCompanyEmails_FormClosed;
			KeyPress += frmCompanyEmails_KeyPress;
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
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_6;
		public System.Windows.Forms.TextBox _txtFields_5;
		public System.Windows.Forms.TextBox _txtFields_4;
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
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape2;
		public System.Windows.Forms.Label Label6;
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
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
			this.Shape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_6 = new System.Windows.Forms.TextBox();
			this._txtFields_5 = new System.Windows.Forms.TextBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Shape1,
				this.Shape2
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(298, 282);
			this.ShapeContainer1.TabIndex = 21;
			this.ShapeContainer1.TabStop = false;
			//
			//Shape1
			//
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.Location = new System.Drawing.Point(6, 236);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(287, 31);
			//
			//Shape2
			//
			this.Shape2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Shape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this.Shape2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.Location = new System.Drawing.Point(6, 52);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(287, 165);
			//
			//_txtFields_7
			//
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.Location = new System.Drawing.Point(228, 240);
			this._txtFields_7.MaxLength = 0;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.Size = new System.Drawing.Size(59, 20);
			this._txtFields_7.TabIndex = 19;
			this._txtFields_7.Text = "0";
			this._txtFields_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFields_6
			//
			this._txtFields_6.AcceptsReturn = true;
			this._txtFields_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_6.Location = new System.Drawing.Point(76, 192);
			this._txtFields_6.MaxLength = 0;
			this._txtFields_6.Name = "_txtFields_6";
			this._txtFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_6.Size = new System.Drawing.Size(214, 20);
			this._txtFields_6.TabIndex = 16;
			//
			//_txtFields_5
			//
			this._txtFields_5.AcceptsReturn = true;
			this._txtFields_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_5.Location = new System.Drawing.Point(76, 170);
			this._txtFields_5.MaxLength = 0;
			this._txtFields_5.Name = "_txtFields_5";
			this._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_5.Size = new System.Drawing.Size(214, 20);
			this._txtFields_5.TabIndex = 14;
			//
			//_txtFields_4
			//
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.Location = new System.Drawing.Point(76, 148);
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.Size = new System.Drawing.Size(214, 20);
			this._txtFields_4.TabIndex = 12;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(298, 33);
			this.picButtons.TabIndex = 9;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(216, 2);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 23);
			this.cmdClose.TabIndex = 11;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(4, 2);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 23);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(76, 126);
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(214, 20);
			this._txtFields_3.TabIndex = 4;
			//
			//_txtFields_2
			//
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.Location = new System.Drawing.Point(76, 104);
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.Size = new System.Drawing.Size(214, 20);
			this._txtFields_2.TabIndex = 3;
			//
			//_txtFields_1
			//
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.Location = new System.Drawing.Point(76, 82);
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.Size = new System.Drawing.Size(214, 20);
			this._txtFields_1.TabIndex = 2;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(76, 60);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(214, 20);
			this._txtFields_0.TabIndex = 1;
			//
			//Label10
			//
			this.Label10.AutoSize = true;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label10.Location = new System.Drawing.Point(138, 242);
			this.Label10.Name = "Label10";
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.Size = new System.Drawing.Size(94, 13);
			this.Label10.TabIndex = 20;
			this.Label10.Text = "Company Number:";
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label9
			//
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Location = new System.Drawing.Point(10, 220);
			this.Label9.Name = "Label9";
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.Size = new System.Drawing.Size(121, 15);
			this.Label9.TabIndex = 18;
			this.Label9.Text = "2. Company Number";
			//
			//Label8
			//
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Location = new System.Drawing.Point(10, 194);
			this.Label8.Name = "Label8";
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.Size = new System.Drawing.Size(63, 17);
			this.Label8.TabIndex = 17;
			this.Label8.Text = "Email No 7:";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label7
			//
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Location = new System.Drawing.Point(10, 172);
			this.Label7.Name = "Label7";
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.Size = new System.Drawing.Size(63, 17);
			this.Label7.TabIndex = 15;
			this.Label7.Text = "Email No 6:";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label5
			//
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Location = new System.Drawing.Point(10, 150);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(63, 17);
			this.Label5.TabIndex = 13;
			this.Label5.Text = "Email No 5:";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label4
			//
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(10, 130);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(63, 17);
			this.Label4.TabIndex = 8;
			this.Label4.Text = "Email No 4:";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(10, 108);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(63, 17);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "Email No 3:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(19, 84);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(61, 13);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "Email No 2:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(19, 64);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(61, 13);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "Email No 1:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label6
			//
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Location = new System.Drawing.Point(8, 36);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(161, 15);
			this.Label6.TabIndex = 0;
			this.Label6.Text = "1. Email For Remote Office";
			//
			//frmCompanyEmails
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(298, 282);
			this.ControlBox = false;
			this.Controls.Add(this._txtFields_7);
			this.Controls.Add(this._txtFields_6);
			this.Controls.Add(this._txtFields_5);
			this.Controls.Add(this._txtFields_4);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._txtFields_2);
			this.Controls.Add(this._txtFields_1);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmCompanyEmails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Store Emails";
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
