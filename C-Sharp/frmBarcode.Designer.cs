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
	partial class frmBarcode
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBarcode() : base()
		{
			Load += frmBarcode_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdnext;
		public System.Windows.Forms.Button cmdnext {
			get { return withEventsField_cmdnext; }
			set {
				if (withEventsField_cmdnext != null) {
					withEventsField_cmdnext.Click -= cmdNext_Click;
				}
				withEventsField_cmdnext = value;
				if (withEventsField_cmdnext != null) {
					withEventsField_cmdnext.Click += cmdNext_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cndExit;
		public System.Windows.Forms.Button cndExit {
			get { return withEventsField_cndExit; }
			set {
				if (withEventsField_cndExit != null) {
					withEventsField_cndExit.Click -= cndExit_Click;
				}
				withEventsField_cndExit = value;
				if (withEventsField_cndExit != null) {
					withEventsField_cndExit.Click += cndExit_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optBarcode_2;
		public System.Windows.Forms.RadioButton _optBarcode_1;
		private System.Windows.Forms.ListBox withEventsField_lstBarcode;
		public System.Windows.Forms.ListBox lstBarcode {
			get { return withEventsField_lstBarcode; }
			set {
				if (withEventsField_lstBarcode != null) {
					withEventsField_lstBarcode.DoubleClick -= lstBarcode_DoubleClick;
				}
				withEventsField_lstBarcode = value;
				if (withEventsField_lstBarcode != null) {
					withEventsField_lstBarcode.DoubleClick += lstBarcode_DoubleClick;
				}
			}
		}
		public System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.Label lblPrinterType;
		public System.Windows.Forms.Label lblPrinter;
		public System.Windows.Forms.Label _Label2_0;
		public System.Windows.Forms.Label Label1;
		//Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optBarcode As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBarcode));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdnext = new System.Windows.Forms.Button();
			this.cndExit = new System.Windows.Forms.Button();
			this._optBarcode_2 = new System.Windows.Forms.RadioButton();
			this._optBarcode_1 = new System.Windows.Forms.RadioButton();
			this.lstBarcode = new System.Windows.Forms.ListBox();
			this._Label2_1 = new System.Windows.Forms.Label();
			this.lblPrinterType = new System.Windows.Forms.Label();
			this.lblPrinter = new System.Windows.Forms.Label();
			this._Label2_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optBarcode = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Barcode Printing";
			this.ClientSize = new System.Drawing.Size(391, 435);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmBarcode.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmBarcode";
			this.cmdnext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdnext.Text = "&Next";
			this.cmdnext.Size = new System.Drawing.Size(106, 49);
			this.cmdnext.Location = new System.Drawing.Point(272, 376);
			this.cmdnext.TabIndex = 9;
			this.cmdnext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdnext.CausesValidation = true;
			this.cmdnext.Enabled = true;
			this.cmdnext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdnext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdnext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdnext.TabStop = true;
			this.cmdnext.Name = "cmdnext";
			this.cndExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cndExit.Text = "E&xit";
			this.cndExit.Size = new System.Drawing.Size(106, 49);
			this.cndExit.Location = new System.Drawing.Point(8, 376);
			this.cndExit.TabIndex = 7;
			this.cndExit.BackColor = System.Drawing.SystemColors.Control;
			this.cndExit.CausesValidation = true;
			this.cndExit.Enabled = true;
			this.cndExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cndExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cndExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cndExit.TabStop = true;
			this.cndExit.Name = "cndExit";
			this._optBarcode_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optBarcode_2.Text = "Stock Barcode";
			this._optBarcode_2.Size = new System.Drawing.Size(133, 40);
			this._optBarcode_2.Location = new System.Drawing.Point(9, 69);
			this._optBarcode_2.Appearance = System.Windows.Forms.Appearance.Button;
			this._optBarcode_2.TabIndex = 2;
			this._optBarcode_2.Checked = true;
			this._optBarcode_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optBarcode_2.BackColor = System.Drawing.SystemColors.Control;
			this._optBarcode_2.CausesValidation = true;
			this._optBarcode_2.Enabled = true;
			this._optBarcode_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optBarcode_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optBarcode_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optBarcode_2.TabStop = true;
			this._optBarcode_2.Visible = true;
			this._optBarcode_2.Name = "_optBarcode_2";
			this._optBarcode_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optBarcode_1.Text = "Shelf Talker";
			this._optBarcode_1.Size = new System.Drawing.Size(133, 40);
			this._optBarcode_1.Location = new System.Drawing.Point(144, 69);
			this._optBarcode_1.Appearance = System.Windows.Forms.Appearance.Button;
			this._optBarcode_1.TabIndex = 1;
			this._optBarcode_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optBarcode_1.BackColor = System.Drawing.SystemColors.Control;
			this._optBarcode_1.CausesValidation = true;
			this._optBarcode_1.Enabled = true;
			this._optBarcode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optBarcode_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optBarcode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optBarcode_1.TabStop = true;
			this._optBarcode_1.Checked = false;
			this._optBarcode_1.Visible = true;
			this._optBarcode_1.Name = "_optBarcode_1";
			this.lstBarcode.Size = new System.Drawing.Size(367, 254);
			this.lstBarcode.Location = new System.Drawing.Point(9, 117);
			this.lstBarcode.TabIndex = 8;
			this.lstBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstBarcode.BackColor = System.Drawing.SystemColors.Window;
			this.lstBarcode.CausesValidation = true;
			this.lstBarcode.Enabled = true;
			this.lstBarcode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstBarcode.IntegralHeight = true;
			this.lstBarcode.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstBarcode.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstBarcode.Sorted = false;
			this.lstBarcode.TabStop = true;
			this.lstBarcode.Visible = true;
			this.lstBarcode.MultiColumn = true;
			this.lstBarcode.ColumnWidth = 367;
			this.lstBarcode.Name = "lstBarcode";
			this._Label2_1.Text = "Printer Type:";
			this._Label2_1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label2_1.Size = new System.Drawing.Size(90, 16);
			this._Label2_1.Location = new System.Drawing.Point(6, 24);
			this._Label2_1.TabIndex = 6;
			this._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_1.BackColor = System.Drawing.Color.Transparent;
			this._Label2_1.Enabled = true;
			this._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_1.UseMnemonic = true;
			this._Label2_1.Visible = true;
			this._Label2_1.AutoSize = true;
			this._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_1.Name = "_Label2_1";
			this.lblPrinterType.Text = "Label1";
			this.lblPrinterType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPrinterType.Size = new System.Drawing.Size(41, 16);
			this.lblPrinterType.Location = new System.Drawing.Point(102, 24);
			this.lblPrinterType.TabIndex = 5;
			this.lblPrinterType.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPrinterType.BackColor = System.Drawing.Color.Transparent;
			this.lblPrinterType.Enabled = true;
			this.lblPrinterType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPrinterType.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPrinterType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPrinterType.UseMnemonic = true;
			this.lblPrinterType.Visible = true;
			this.lblPrinterType.AutoSize = true;
			this.lblPrinterType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPrinterType.Name = "lblPrinterType";
			this.lblPrinter.Text = "Label1";
			this.lblPrinter.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPrinter.Size = new System.Drawing.Size(41, 16);
			this.lblPrinter.Location = new System.Drawing.Point(102, 6);
			this.lblPrinter.TabIndex = 4;
			this.lblPrinter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPrinter.BackColor = System.Drawing.Color.Transparent;
			this.lblPrinter.Enabled = true;
			this.lblPrinter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPrinter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPrinter.UseMnemonic = true;
			this.lblPrinter.Visible = true;
			this.lblPrinter.AutoSize = true;
			this.lblPrinter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPrinter.Name = "lblPrinter";
			this._Label2_0.Text = "Printer:";
			this._Label2_0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Label2_0.Size = new System.Drawing.Size(50, 16);
			this._Label2_0.Location = new System.Drawing.Point(45, 6);
			this._Label2_0.TabIndex = 3;
			this._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label2_0.BackColor = System.Drawing.Color.Transparent;
			this._Label2_0.Enabled = true;
			this._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label2_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label2_0.UseMnemonic = true;
			this._Label2_0.Visible = true;
			this._Label2_0.AutoSize = true;
			this._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label2_0.Name = "_Label2_0";
			this.Label1.Text = "Select the barcode printing type you require";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(258, 16);
			this.Label1.Location = new System.Drawing.Point(12, 45);
			this.Label1.TabIndex = 0;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = true;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(cmdnext);
			this.Controls.Add(cndExit);
			this.Controls.Add(_optBarcode_2);
			this.Controls.Add(_optBarcode_1);
			this.Controls.Add(lstBarcode);
			this.Controls.Add(_Label2_1);
			this.Controls.Add(lblPrinterType);
			this.Controls.Add(lblPrinter);
			this.Controls.Add(_Label2_0);
			this.Controls.Add(Label1);
			//Me.Label2.SetIndex(_Label2_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_0, CType(0, Short))
			//Me.optBarcode.SetIndex(_optBarcode_2, CType(2, Short))
			//Me.optBarcode.SetIndex(_optBarcode_1, CType(1, Short))
			//CType(Me.optBarcode, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
