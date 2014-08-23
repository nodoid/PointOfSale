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
	partial class frmMonthEnd
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMonthEnd() : base()
		{
			Load += frmMonthEnd_Load;
			KeyPress += frmMonthEnd_KeyPress;
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
		public System.Windows.Forms.PictureBox Picture2;
		public System.Windows.Forms.GroupBox _frmMode_3;
		public System.Windows.Forms.Label _Label1_7;
		public System.Windows.Forms.Label _Label1_6;
		public System.Windows.Forms.GroupBox _frmMode_1;
		public System.Windows.Forms.Label _Label1_4;
		public System.Windows.Forms.Label _Label1_5;
		public System.Windows.Forms.GroupBox _frmMode_0;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label1_2;
		public System.Windows.Forms.GroupBox _frmMode_2;
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
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMonthEnd));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this._frmMode_3 = new System.Windows.Forms.GroupBox();
			this.Picture2 = new System.Windows.Forms.PictureBox();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this._Label1_7 = new System.Windows.Forms.Label();
			this._Label1_6 = new System.Windows.Forms.Label();
			this._frmMode_0 = new System.Windows.Forms.GroupBox();
			this._Label1_4 = new System.Windows.Forms.Label();
			this._Label1_5 = new System.Windows.Forms.Label();
			this._frmMode_2 = new System.Windows.Forms.GroupBox();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this.cmdBack = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			this._frmMode_3.SuspendLayout();
			this._frmMode_1.SuspendLayout();
			this._frmMode_0.SuspendLayout();
			this._frmMode_2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Month End Run";
			this.ClientSize = new System.Drawing.Size(654, 497);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmMonthEnd";
			this._frmMode_3.Text = "Month End Run Complete";
			this._frmMode_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_3.Size = new System.Drawing.Size(196, 256);
			this._frmMode_3.Location = new System.Drawing.Point(354, 147);
			this._frmMode_3.TabIndex = 3;
			this._frmMode_3.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_3.Enabled = true;
			this._frmMode_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_3.Visible = true;
			this._frmMode_3.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_3.Name = "_frmMode_3";
			this.Picture2.Size = new System.Drawing.Size(140, 205);
			this.Picture2.Location = new System.Drawing.Point(27, 24);
			this.Picture2.Image = (System.Drawing.Image)resources.GetObject("Picture2.Image");
			this.Picture2.TabIndex = 4;
			this.Picture2.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture2.BackColor = System.Drawing.SystemColors.Control;
			this.Picture2.CausesValidation = true;
			this.Picture2.Enabled = true;
			this.Picture2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture2.TabStop = true;
			this.Picture2.Visible = true;
			this.Picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture2.Name = "Picture2";
			this._frmMode_1.Text = "Outstanding Day End Run";
			this._frmMode_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_1.Size = new System.Drawing.Size(196, 256);
			this._frmMode_1.Location = new System.Drawing.Point(204, 120);
			this._frmMode_1.TabIndex = 9;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Enabled = true;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Visible = true;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this._Label1_7.Text = "There have been no Point Of Sale transactions since the last time this Month End Run procedure was run.";
			this._Label1_7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_7.ForeColor = System.Drawing.Color.Red;
			this._Label1_7.Size = new System.Drawing.Size(178, 70);
			this._Label1_7.Location = new System.Drawing.Point(12, 30);
			this._Label1_7.TabIndex = 11;
			this._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_7.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_7.Enabled = true;
			this._Label1_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_7.UseMnemonic = true;
			this._Label1_7.Visible = true;
			this._Label1_7.AutoSize = false;
			this._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_7.Name = "_Label1_7";
			this._Label1_6.Text = "There is no need to run your Month End Run.";
			this._Label1_6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_6.ForeColor = System.Drawing.Color.Red;
			this._Label1_6.Size = new System.Drawing.Size(178, 70);
			this._Label1_6.Location = new System.Drawing.Point(12, 102);
			this._Label1_6.TabIndex = 10;
			this._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_6.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_6.Enabled = true;
			this._Label1_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_6.UseMnemonic = true;
			this._Label1_6.Visible = true;
			this._Label1_6.AutoSize = false;
			this._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_6.Name = "_Label1_6";
			this._frmMode_0.Text = "Outstanding Day End Run";
			this._frmMode_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_0.Size = new System.Drawing.Size(196, 256);
			this._frmMode_0.Location = new System.Drawing.Point(9, 12);
			this._frmMode_0.TabIndex = 6;
			this._frmMode_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_0.Enabled = true;
			this._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_0.Visible = true;
			this._frmMode_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_0.Name = "_frmMode_0";
			this._Label1_4.Text = "Please complete the Day End Run before proceeding with your Month End.";
			this._Label1_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_4.ForeColor = System.Drawing.Color.Red;
			this._Label1_4.Size = new System.Drawing.Size(178, 70);
			this._Label1_4.Location = new System.Drawing.Point(12, 102);
			this._Label1_4.TabIndex = 8;
			this._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_4.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_4.Enabled = true;
			this._Label1_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_4.UseMnemonic = true;
			this._Label1_4.Visible = true;
			this._Label1_4.AutoSize = false;
			this._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_4.Name = "_Label1_4";
			this._Label1_5.Text = "There is an outstanding Day End Run.";
			this._Label1_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label1_5.ForeColor = System.Drawing.Color.Red;
			this._Label1_5.Size = new System.Drawing.Size(178, 70);
			this._Label1_5.Location = new System.Drawing.Point(12, 30);
			this._Label1_5.TabIndex = 7;
			this._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_5.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_5.Enabled = true;
			this._Label1_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_5.UseMnemonic = true;
			this._Label1_5.Visible = true;
			this._Label1_5.AutoSize = false;
			this._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_5.Name = "_Label1_5";
			this._frmMode_2.Text = "Confirm Month End Run";
			this._frmMode_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_2.Size = new System.Drawing.Size(196, 256);
			this._frmMode_2.Location = new System.Drawing.Point(228, 24);
			this._frmMode_2.TabIndex = 2;
			this._frmMode_2.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_2.Enabled = true;
			this._frmMode_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_2.Visible = true;
			this._frmMode_2.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_2.Name = "_frmMode_2";
			this._Label1_1.Text = "Are you sure you wish to run the Month End. This action will move your current month details into a last month position and update all your account appropriately.";
			this._Label1_1.Size = new System.Drawing.Size(178, 121);
			this._Label1_1.Location = new System.Drawing.Point(9, 27);
			this._Label1_1.TabIndex = 12;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label1_2.Text = "By pressing 'Next' you will commit the Month End Run.";
			this._Label1_2.Size = new System.Drawing.Size(178, 34);
			this._Label1_2.Location = new System.Drawing.Point(9, 198);
			this._Label1_2.TabIndex = 5;
			this._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_2.Enabled = true;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.UseMnemonic = true;
			this._Label1_2.Visible = true;
			this._Label1_2.AutoSize = false;
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.Name = "_Label1_2";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Size = new System.Drawing.Size(85, 25);
			this.cmdBack.Location = new System.Drawing.Point(6, 279);
			this.cmdBack.TabIndex = 1;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.TabStop = true;
			this.cmdBack.Name = "cmdBack";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next >>";
			this.cmdNext.Size = new System.Drawing.Size(84, 25);
			this.cmdNext.Location = new System.Drawing.Point(117, 279);
			this.cmdNext.TabIndex = 0;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.TabStop = true;
			this.cmdNext.Name = "cmdNext";
			this.Controls.Add(_frmMode_3);
			this.Controls.Add(_frmMode_1);
			this.Controls.Add(_frmMode_0);
			this.Controls.Add(_frmMode_2);
			this.Controls.Add(cmdBack);
			this.Controls.Add(cmdNext);
			this._frmMode_3.Controls.Add(Picture2);
			this._frmMode_1.Controls.Add(_Label1_7);
			this._frmMode_1.Controls.Add(_Label1_6);
			this._frmMode_0.Controls.Add(_Label1_4);
			this._frmMode_0.Controls.Add(_Label1_5);
			this._frmMode_2.Controls.Add(_Label1_1);
			this._frmMode_2.Controls.Add(_Label1_2);
			//Me.Label1.SetIndex(_Label1_7, CType(7, Short))
			//Me.Label1.SetIndex(_Label1_6, CType(6, Short))
			//Me.Label1.SetIndex(_Label1_4, CType(4, Short))
			//Me.Label1.SetIndex(_Label1_5, CType(5, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_2, CType(2, Short))
			//Me.frmMode.SetIndex(_frmMode_3, CType(3, Short))
			//Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
			//Me.frmMode.SetIndex(_frmMode_0, CType(0, Short))
			//Me.frmMode.SetIndex(_frmMode_2, CType(2, Short))
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this._frmMode_3.ResumeLayout(false);
			this._frmMode_1.ResumeLayout(false);
			this._frmMode_0.ResumeLayout(false);
			this._frmMode_2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
