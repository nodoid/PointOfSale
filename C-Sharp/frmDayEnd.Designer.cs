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
	partial class frmDayEnd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmDayEnd() : base()
		{
			FormClosed += frmDayEnd_FormClosed;
			KeyPress += frmDayEnd_KeyPress;
			Load += frmDayEnd_Load;
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
		public System.Windows.Forms.Label lblDemo;
		public System.Windows.Forms.Label lblText;
		public System.Windows.Forms.GroupBox _frmMode_4;
		private System.Windows.Forms.Button withEventsField_cmdBack;
		public System.Windows.Forms.Button cmdBack {
			get { return withEventsField_cmdBack; }
			set {
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click -= cmdBack_Click;
				}
				withEventsField_cmdBack = value;
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click += cmdBack_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNext;
		public System.Windows.Forms.Button cmdNext {
			get { return withEventsField_cmdNext; }
			set {
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click -= cmdNext_Click;
				}
				withEventsField_cmdNext = value;
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click += cmdNext_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstPOS;
		public System.Windows.Forms.Label _Label1_3;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.GroupBox _frmMode_0;
		public System.Windows.Forms.MonthCalendar calDayEnd;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.GroupBox _frmMode_2;
		public System.Windows.Forms.Label _Label1_4;
		public System.Windows.Forms.Label _Label1_5;
		public System.Windows.Forms.GroupBox _frmMode_1;
		public System.Windows.Forms.PictureBox Picture2;
		public System.Windows.Forms.GroupBox _frmMode_3;
		//Public WithEvents MAPISession1 As MSMAPI.MAPISession
		//Public WithEvents MAPIMessages1 As MSMAPI.MAPIMessages
		public System.Windows.Forms.Label Label3;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayEnd));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this._frmMode_4 = new System.Windows.Forms.GroupBox();
			this.lblDemo = new System.Windows.Forms.Label();
			this.lblText = new System.Windows.Forms.Label();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this._frmMode_0 = new System.Windows.Forms.GroupBox();
			this.lstPOS = new System.Windows.Forms.ListBox();
			this._Label1_3 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this._frmMode_2 = new System.Windows.Forms.GroupBox();
			this.calDayEnd = new System.Windows.Forms.MonthCalendar();
			this.Label2 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this._Label1_4 = new System.Windows.Forms.Label();
			this._Label1_5 = new System.Windows.Forms.Label();
			this._frmMode_3 = new System.Windows.Forms.GroupBox();
			this.Picture2 = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this._frmMode_4.SuspendLayout();
			this._frmMode_0.SuspendLayout();
			this._frmMode_2.SuspendLayout();
			this._frmMode_1.SuspendLayout();
			this._frmMode_3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.Picture2).BeginInit();
			this.SuspendLayout();
			//
			//_frmMode_4
			//
			this._frmMode_4.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_4.Controls.Add(this.lblDemo);
			this._frmMode_4.Controls.Add(this.lblText);
			this._frmMode_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_4.Location = new System.Drawing.Point(412, 319);
			this._frmMode_4.Name = "_frmMode_4";
			this._frmMode_4.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_4.Size = new System.Drawing.Size(196, 313);
			this._frmMode_4.TabIndex = 16;
			this._frmMode_4.TabStop = false;
			this._frmMode_4.Text = "Demo Version Notification";
			//
			//lblDemo
			//
			this.lblDemo.BackColor = System.Drawing.SystemColors.Control;
			this.lblDemo.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDemo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDemo.ForeColor = System.Drawing.Color.Black;
			this.lblDemo.Location = new System.Drawing.Point(12, 138);
			this.lblDemo.Name = "lblDemo";
			this.lblDemo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDemo.Size = new System.Drawing.Size(175, 124);
			this.lblDemo.TabIndex = 18;
			//
			//lblText
			//
			this.lblText.BackColor = System.Drawing.SystemColors.Control;
			this.lblText.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblText.ForeColor = System.Drawing.Color.Black;
			this.lblText.Location = new System.Drawing.Point(12, 33);
			this.lblText.Name = "lblText";
			this.lblText.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblText.Size = new System.Drawing.Size(175, 82);
			this.lblText.TabIndex = 17;
			this.lblText.Text = "The 4POS Application you are currently using is a Demo Version. The Demo version " + "is a fully functional version except that you may only run one ten Day End runs." + "";
			//
			//cmdBack
			//
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Location = new System.Drawing.Point(4, 350);
			this.cmdBack.Name = "cmdBack";
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Size = new System.Drawing.Size(85, 25);
			this.cmdBack.TabIndex = 4;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.UseVisualStyleBackColor = false;
			//
			//cmdNext
			//
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Location = new System.Drawing.Point(118, 350);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Size = new System.Drawing.Size(84, 25);
			this.cmdNext.TabIndex = 3;
			this.cmdNext.Text = "&Next >>";
			this.cmdNext.UseVisualStyleBackColor = false;
			//
			//_frmMode_0
			//
			this._frmMode_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_0.Controls.Add(this.lstPOS);
			this._frmMode_0.Controls.Add(this._Label1_3);
			this._frmMode_0.Controls.Add(this._Label1_0);
			this._frmMode_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_0.Location = new System.Drawing.Point(6, 12);
			this._frmMode_0.Name = "_frmMode_0";
			this._frmMode_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_0.Size = new System.Drawing.Size(196, 313);
			this._frmMode_0.TabIndex = 0;
			this._frmMode_0.TabStop = false;
			this._frmMode_0.Text = "No Cashup Declarations";
			//
			//lstPOS
			//
			this.lstPOS.BackColor = System.Drawing.SystemColors.Window;
			this.lstPOS.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPOS.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lstPOS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPOS.ItemHeight = 16;
			this.lstPOS.Location = new System.Drawing.Point(9, 18);
			this.lstPOS.Name = "lstPOS";
			this.lstPOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPOS.Size = new System.Drawing.Size(178, 164);
			this.lstPOS.TabIndex = 1;
			//
			//_Label1_3
			//
			this._Label1_3.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_3.ForeColor = System.Drawing.Color.Red;
			this._Label1_3.Location = new System.Drawing.Point(12, 246);
			this._Label1_3.Name = "_Label1_3";
			this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_3.Size = new System.Drawing.Size(178, 43);
			this._Label1_3.TabIndex = 10;
			this._Label1_3.Text = "All active Point Of Sales Devices have to be declared before your Day End Run.";
			//
			//_Label1_0
			//
			this._Label1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_0.ForeColor = System.Drawing.Color.Red;
			this._Label1_0.Location = new System.Drawing.Point(12, 201);
			this._Label1_0.Name = "_Label1_0";
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.Size = new System.Drawing.Size(178, 40);
			this._Label1_0.TabIndex = 2;
			this._Label1_0.Text = "The following Point Of Sales Devices have not been declared.";
			//
			//_frmMode_2
			//
			this._frmMode_2.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_2.Controls.Add(this.calDayEnd);
			this._frmMode_2.Controls.Add(this.Label2);
			this._frmMode_2.Controls.Add(this._Label1_2);
			this._frmMode_2.Controls.Add(this._Label1_1);
			this._frmMode_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_2.Location = new System.Drawing.Point(210, 0);
			this._frmMode_2.Name = "_frmMode_2";
			this._frmMode_2.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_2.Size = new System.Drawing.Size(196, 313);
			this._frmMode_2.TabIndex = 5;
			this._frmMode_2.TabStop = false;
			this._frmMode_2.Text = "Confirm Day End Run";
			//
			//calDayEnd
			//
			this.calDayEnd.Location = new System.Drawing.Point(9, 42);
			this.calDayEnd.Name = "calDayEnd";
			this.calDayEnd.TabIndex = 14;
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label2.ForeColor = System.Drawing.Color.Blue;
			this.Label2.Location = new System.Drawing.Point(6, 252);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(181, 52);
			this.Label2.TabIndex = 15;
			this.Label2.Text = "Please insure that there are no other users using the system before pressing the " + "\"Next\" button!";
			//
			//_Label1_2
			//
			this._Label1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Location = new System.Drawing.Point(9, 207);
			this._Label1_2.Name = "_Label1_2";
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.Size = new System.Drawing.Size(178, 43);
			this._Label1_2.TabIndex = 9;
			this._Label1_2.Text = "As part of the \"Day End\" run, the integrity of your database will be check and a " + "backup made.";
			//
			//_Label1_1
			//
			this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Location = new System.Drawing.Point(15, 13);
			this._Label1_1.Name = "_Label1_1";
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.Size = new System.Drawing.Size(178, 34);
			this._Label1_1.TabIndex = 6;
			this._Label1_1.Text = "Use the date selector to select the correct date for your day end.";
			//
			//_frmMode_1
			//
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Controls.Add(this._Label1_4);
			this._frmMode_1.Controls.Add(this._Label1_5);
			this._frmMode_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.Location = new System.Drawing.Point(210, 319);
			this._frmMode_1.Name = "_frmMode_1";
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Size = new System.Drawing.Size(196, 313);
			this._frmMode_1.TabIndex = 11;
			this._frmMode_1.TabStop = false;
			this._frmMode_1.Text = "No POS Trasactions";
			//
			//_Label1_4
			//
			this._Label1_4.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_4.ForeColor = System.Drawing.Color.Red;
			this._Label1_4.Location = new System.Drawing.Point(9, 129);
			this._Label1_4.Name = "_Label1_4";
			this._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_4.Size = new System.Drawing.Size(178, 70);
			this._Label1_4.TabIndex = 13;
			this._Label1_4.Text = "There is no need to run your Day End Run.";
			//
			//_Label1_5
			//
			this._Label1_5.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_5.ForeColor = System.Drawing.Color.Red;
			this._Label1_5.Location = new System.Drawing.Point(12, 57);
			this._Label1_5.Name = "_Label1_5";
			this._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_5.Size = new System.Drawing.Size(178, 70);
			this._Label1_5.TabIndex = 12;
			this._Label1_5.Text = "There have been no Point Of Sale transactions since the last time this Day End Ru" + "n procedure was run.";
			//
			//_frmMode_3
			//
			this._frmMode_3.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_3.Controls.Add(this.Picture2);
			this._frmMode_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_3.Location = new System.Drawing.Point(412, 0);
			this._frmMode_3.Name = "_frmMode_3";
			this._frmMode_3.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_3.Size = new System.Drawing.Size(196, 313);
			this._frmMode_3.TabIndex = 7;
			this._frmMode_3.TabStop = false;
			this._frmMode_3.Text = "Day End Run Complete";
			//
			//Picture2
			//
			this.Picture2.BackColor = System.Drawing.SystemColors.Control;
			this.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture2.Image = (System.Drawing.Image)resources.GetObject("Picture2.Image");
			this.Picture2.Location = new System.Drawing.Point(27, 54);
			this.Picture2.Name = "Picture2";
			this.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture2.Size = new System.Drawing.Size(140, 205);
			this.Picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Picture2.TabIndex = 8;
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(6, 330);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(195, 15);
			this.Label3.TabIndex = 19;
			this.Label3.Text = "Please Wait, Stock Update progress...";
			this.Label3.Visible = false;
			//
			//frmDayEnd
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(654, 483);
			this.ControlBox = false;
			this.Controls.Add(this._frmMode_4);
			this.Controls.Add(this.cmdBack);
			this.Controls.Add(this.cmdNext);
			this.Controls.Add(this._frmMode_0);
			this.Controls.Add(this._frmMode_2);
			this.Controls.Add(this._frmMode_1);
			this.Controls.Add(this._frmMode_3);
			this.Controls.Add(this.Label3);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDayEnd";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Day End Run";
			this._frmMode_4.ResumeLayout(false);
			this._frmMode_0.ResumeLayout(false);
			this._frmMode_2.ResumeLayout(false);
			this._frmMode_1.ResumeLayout(false);
			this._frmMode_3.ResumeLayout(false);
			this._frmMode_3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.Picture2).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
