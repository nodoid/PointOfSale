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
	partial class frmPrintLocation
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPrintLocation() : base()
		{
			KeyPress += frmPrintLocation_KeyPress;
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
		private System.Windows.Forms.TextBox withEventsField_txtName;
		public System.Windows.Forms.TextBox txtName {
			get { return withEventsField_txtName; }
			set {
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter -= txtName_Enter;
				}
				withEventsField_txtName = value;
				if (withEventsField_txtName != null) {
					withEventsField_txtName.Enter += txtName_Enter;
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
		private System.Windows.Forms.CheckedListBox withEventsField_lstPrinter;
		public System.Windows.Forms.CheckedListBox lstPrinter {
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
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrintLocation));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtName = new System.Windows.Forms.TextBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.lstPrinter = new System.Windows.Forms.CheckedListBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select a Printers for the Print Location";
			this.ClientSize = new System.Drawing.Size(316, 376);
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
			this.Name = "frmPrintLocation";
			this.txtName.AutoSize = false;
			this.txtName.Size = new System.Drawing.Size(190, 19);
			this.txtName.Location = new System.Drawing.Point(114, 6);
			this.txtName.TabIndex = 3;
			this.txtName.Text = "[New Print Location]";
			this.txtName.AcceptsReturn = true;
			this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtName.BackColor = System.Drawing.SystemColors.Window;
			this.txtName.CausesValidation = true;
			this.txtName.Enabled = true;
			this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtName.HideSelection = true;
			this.txtName.ReadOnly = false;
			this.txtName.MaxLength = 0;
			this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtName.Multiline = false;
			this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtName.TabStop = true;
			this.txtName.Visible = true;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtName.Name = "txtName";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(97, 52);
			this.cmdExit.Location = new System.Drawing.Point(9, 204);
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
			this.cmdNext.Text = "&Save";
			this.cmdNext.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNext.Size = new System.Drawing.Size(97, 52);
			this.cmdNext.Location = new System.Drawing.Point(207, 204);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.lstPrinter.Size = new System.Drawing.Size(295, 154);
			this.lstPrinter.Location = new System.Drawing.Point(9, 33);
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
			this.Label3.Text = "For Example:";
			this.Label3.Size = new System.Drawing.Size(100, 13);
			this.Label3.Location = new System.Drawing.Point(8, 304);
			this.Label3.TabIndex = 10;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label7.Text = "Incorrect :";
			this.Label7.ForeColor = System.Drawing.Color.Red;
			this.Label7.Size = new System.Drawing.Size(60, 13);
			this.Label7.Location = new System.Drawing.Point(80, 352);
			this.Label7.TabIndex = 9;
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Enabled = true;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label6.Text = "Correct :";
			this.Label6.Size = new System.Drawing.Size(60, 13);
			this.Label6.Location = new System.Drawing.Point(80, 328);
			this.Label6.TabIndex = 8;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Enabled = true;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.Label5.Text = "My Favorite Printer";
			this.Label5.ForeColor = System.Drawing.Color.Black;
			this.Label5.Size = new System.Drawing.Size(233, 29);
			this.Label5.Location = new System.Drawing.Point(144, 352);
			this.Label5.TabIndex = 7;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Enabled = true;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label4.Text = "MyFavoritePrinter";
			this.Label4.Size = new System.Drawing.Size(233, 29);
			this.Label4.Location = new System.Drawing.Point(144, 328);
			this.Label4.TabIndex = 6;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label2.Text = "Please note : This list will not show a printer, if the name of that printer has SPACE in it.";
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Size = new System.Drawing.Size(296, 37);
			this.Label2.Location = new System.Drawing.Point(8, 272);
			this.Label2.TabIndex = 5;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Print Location Name:";
			this.Label1.Size = new System.Drawing.Size(99, 13);
			this.Label1.Location = new System.Drawing.Point(6, 9);
			this.Label1.TabIndex = 4;
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
			this.Controls.Add(txtName);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdNext);
			this.Controls.Add(lstPrinter);
			this.Controls.Add(Label3);
			this.Controls.Add(Label7);
			this.Controls.Add(Label6);
			this.Controls.Add(Label5);
			this.Controls.Add(Label4);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
