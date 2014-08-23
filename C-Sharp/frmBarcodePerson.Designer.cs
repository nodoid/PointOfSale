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
	partial class frmBarcodePerson
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBarcodePerson() : base()
		{
			Load += frmBarcodePerson_Load;
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
		public System.Windows.Forms.CheckedListBox lstPerson;
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
		public System.Windows.Forms.Label _Label2_1;
		public System.Windows.Forms.Label lblPrinterType;
		public System.Windows.Forms.Label lblPrinter;
		public System.Windows.Forms.Label _Label2_0;
		public System.Windows.Forms.Label Label1;
		//Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBarcodePerson));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdPrint = new System.Windows.Forms.Button();
			this.lstPerson = new System.Windows.Forms.CheckedListBox();
			this.cndExit = new System.Windows.Forms.Button();
			this._Label2_1 = new System.Windows.Forms.Label();
			this.lblPrinterType = new System.Windows.Forms.Label();
			this.lblPrinter = new System.Windows.Forms.Label();
			this._Label2_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Security Barcode Printing";
			this.ClientSize = new System.Drawing.Size(394, 449);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
			this.Icon = (System.Drawing.Icon)resources.GetObject("frmBarcodePerson.Icon");
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
			this.Name = "frmBarcodePerson";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(106, 49);
			this.cmdPrint.Location = new System.Drawing.Point(21, 381);
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.lstPerson.Size = new System.Drawing.Size(361, 244);
			this.lstPerson.Location = new System.Drawing.Point(15, 93);
			this.lstPerson.TabIndex = 6;
			this.lstPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPerson.BackColor = System.Drawing.SystemColors.Window;
			this.lstPerson.CausesValidation = true;
			this.lstPerson.Enabled = true;
			this.lstPerson.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPerson.IntegralHeight = true;
			this.lstPerson.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPerson.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstPerson.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPerson.Sorted = false;
			this.lstPerson.TabStop = true;
			this.lstPerson.Visible = true;
			this.lstPerson.MultiColumn = false;
			this.lstPerson.Name = "lstPerson";
			this.cndExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cndExit.Text = "E&xit";
			this.cndExit.Size = new System.Drawing.Size(106, 49);
			this.cndExit.Location = new System.Drawing.Point(267, 381);
			this.cndExit.TabIndex = 5;
			this.cndExit.BackColor = System.Drawing.SystemColors.Control;
			this.cndExit.CausesValidation = true;
			this.cndExit.Enabled = true;
			this.cndExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cndExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cndExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cndExit.TabStop = true;
			this.cndExit.Name = "cndExit";
			this._Label2_1.Text = "Printer Type:";
			this._Label2_1.Size = new System.Drawing.Size(90, 16);
			this._Label2_1.Location = new System.Drawing.Point(6, 24);
			this._Label2_1.TabIndex = 4;
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
			this.lblPrinterType.Size = new System.Drawing.Size(41, 16);
			this.lblPrinterType.Location = new System.Drawing.Point(102, 24);
			this.lblPrinterType.TabIndex = 3;
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
			this.lblPrinter.Size = new System.Drawing.Size(41, 16);
			this.lblPrinter.Location = new System.Drawing.Point(102, 6);
			this.lblPrinter.TabIndex = 2;
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
			this._Label2_0.Size = new System.Drawing.Size(50, 16);
			this._Label2_0.Location = new System.Drawing.Point(45, 6);
			this._Label2_0.TabIndex = 1;
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
			this.Label1.Text = "Tick the check boxes for the Persons you require access barcodes for from the list below.";
			this.Label1.Size = new System.Drawing.Size(357, 37);
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
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(cmdPrint);
			this.Controls.Add(lstPerson);
			this.Controls.Add(cndExit);
			this.Controls.Add(_Label2_1);
			this.Controls.Add(lblPrinterType);
			this.Controls.Add(lblPrinter);
			this.Controls.Add(_Label2_0);
			this.Controls.Add(Label1);
			//Me.Label2.SetIndex(_Label2_1, CType(1, Short))
			//Me.Label2.SetIndex(_Label2_0, CType(0, Short))
			//CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
