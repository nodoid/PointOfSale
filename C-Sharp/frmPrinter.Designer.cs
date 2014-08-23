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
	partial class frmPrinter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPrinter() : base()
		{
			Load += frmPrinter_Load;
			KeyPress += frmPrinter_KeyPress;
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
		public System.Windows.Forms.RadioButton _optType_0;
		public System.Windows.Forms.RadioButton _optType_3;
		public System.Windows.Forms.RadioButton _optType_2;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.GroupBox Frame1;
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
		private System.Windows.Forms.ListBox withEventsField_lstPrinter;
		public System.Windows.Forms.ListBox lstPrinter {
			get { return withEventsField_lstPrinter; }
			set {
				if (withEventsField_lstPrinter != null) {
					withEventsField_lstPrinter.DoubleClick -= lstPrinter_DoubleClick;
					withEventsField_lstPrinter.KeyPress -= lstPrinter_KeyPress;
				}
				withEventsField_lstPrinter = value;
				if (withEventsField_lstPrinter != null) {
					withEventsField_lstPrinter.DoubleClick += lstPrinter_DoubleClick;
					withEventsField_lstPrinter.KeyPress += lstPrinter_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label Label3;
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrinter));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this._optType_3 = new System.Windows.Forms.RadioButton();
			this._optType_2 = new System.Windows.Forms.RadioButton();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.lstPrinter = new System.Windows.Forms.ListBox();
			this.Label3 = new System.Windows.Forms.Label();
			//Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select a Printer";
			this.ClientSize = new System.Drawing.Size(316, 316);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmPrinter";
			this.Frame1.Text = "NOTE: Please select your printer type before clicking 'Next'";
			this.Frame1.ForeColor = System.Drawing.Color.Blue;
			this.Frame1.Size = new System.Drawing.Size(295, 49);
			this.Frame1.Location = new System.Drawing.Point(8, 192);
			this.Frame1.TabIndex = 4;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.Text = "no spec";
			this._optType_0.Size = new System.Drawing.Size(97, 17);
			this._optType_0.Location = new System.Drawing.Point(184, 48);
			this._optType_0.TabIndex = 8;
			this._optType_0.Visible = false;
			this._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optType_0.CausesValidation = true;
			this._optType_0.Enabled = true;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_0.TabStop = true;
			this._optType_0.Checked = false;
			this._optType_0.Name = "_optType_0";
			this._optType_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_3.Text = "Other barcode printer";
			this._optType_3.Size = new System.Drawing.Size(121, 17);
			this._optType_3.Location = new System.Drawing.Point(168, 24);
			this._optType_3.TabIndex = 7;
			this._optType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_3.BackColor = System.Drawing.SystemColors.Control;
			this._optType_3.CausesValidation = true;
			this._optType_3.Enabled = true;
			this._optType_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_3.TabStop = true;
			this._optType_3.Checked = false;
			this._optType_3.Visible = true;
			this._optType_3.Name = "_optType_3";
			this._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.Text = "Argox printer";
			this._optType_2.Size = new System.Drawing.Size(121, 17);
			this._optType_2.Location = new System.Drawing.Point(80, 24);
			this._optType_2.TabIndex = 6;
			this._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_2.BackColor = System.Drawing.SystemColors.Control;
			this._optType_2.CausesValidation = true;
			this._optType_2.Enabled = true;
			this._optType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_2.TabStop = true;
			this._optType_2.Checked = false;
			this._optType_2.Visible = true;
			this._optType_2.Name = "_optType_2";
			this._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.Text = "A4 printer";
			this._optType_1.Size = new System.Drawing.Size(97, 17);
			this._optType_1.Location = new System.Drawing.Point(8, 24);
			this._optType_1.TabIndex = 5;
			this._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.BackColor = System.Drawing.SystemColors.Control;
			this._optType_1.CausesValidation = true;
			this._optType_1.Enabled = true;
			this._optType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_1.TabStop = true;
			this._optType_1.Checked = false;
			this._optType_1.Visible = true;
			this._optType_1.Name = "_optType_1";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(9, 256);
			this.cmdExit.TabIndex = 2;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Size = new System.Drawing.Size(97, 52);
			this.cmdNext.Location = new System.Drawing.Point(207, 256);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.lstPrinter.Size = new System.Drawing.Size(295, 176);
			this.lstPrinter.Location = new System.Drawing.Point(9, 9);
			this.lstPrinter.TabIndex = 0;
			this.lstPrinter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPrinter.BackColor = System.Drawing.SystemColors.Window;
			this.lstPrinter.CausesValidation = true;
			this.lstPrinter.Enabled = true;
			this.lstPrinter.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPrinter.IntegralHeight = true;
			this.lstPrinter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPrinter.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPrinter.Sorted = false;
			this.lstPrinter.TabStop = true;
			this.lstPrinter.Visible = true;
			this.lstPrinter.MultiColumn = false;
			this.lstPrinter.Name = "lstPrinter";
			this.Label3.Text = "Only printers with the word \"Label\" in the name would be regarded as true Barcode printers. All other printers would be regarded as an \"A4\" printer. If you are not sure, please rename the printer accordingly.";
			this.Label3.Size = new System.Drawing.Size(369, 49);
			this.Label3.Location = new System.Drawing.Point(8, 328);
			this.Label3.TabIndex = 3;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Controls.Add(Frame1);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdNext);
			this.Controls.Add(lstPrinter);
			this.Controls.Add(Label3);
			this.Frame1.Controls.Add(_optType_0);
			this.Frame1.Controls.Add(_optType_3);
			this.Frame1.Controls.Add(_optType_2);
			this.Frame1.Controls.Add(_optType_1);
			//Me.optType.SetIndex(_optType_0, CType(0, Short))
			//Me.optType.SetIndex(_optType_3, CType(3, Short))
			//Me.optType.SetIndex(_optType_2, CType(2, Short))
			//Me.optType.SetIndex(_optType_1, CType(1, Short))
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
