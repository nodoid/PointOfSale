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
	partial class frmDesign
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmDesign() : base()
		{
			Load += frmDesign_Load;
			KeyPress += frmDesign_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdnew;
		public System.Windows.Forms.Button cmdnew {
			get { return withEventsField_cmdnew; }
			set {
				if (withEventsField_cmdnew != null) {
					withEventsField_cmdnew.Click -= cmdNew_Click;
				}
				withEventsField_cmdnew = value;
				if (withEventsField_cmdnew != null) {
					withEventsField_cmdnew.Click += cmdNew_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton _Option1_1;
		public System.Windows.Forms.RadioButton _Option1_2;
		private System.Windows.Forms.Button withEventsField_cmdexit;
		public System.Windows.Forms.Button cmdexit {
			get { return withEventsField_cmdexit; }
			set {
				if (withEventsField_cmdexit != null) {
					withEventsField_cmdexit.Click -= cmdExit_Click;
				}
				withEventsField_cmdexit = value;
				if (withEventsField_cmdexit != null) {
					withEventsField_cmdexit.Click += cmdExit_Click;
				}
			}
		}
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
		private myDataGridView withEventsField_DataList1;
		public myDataGridView DataList1 {
			get { return withEventsField_DataList1; }
			set {
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick -= DataList1_DblClick;
				}
				withEventsField_DataList1 = value;
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick += DataList1_DblClick;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
		//Public WithEvents Option1 As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDesign));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdnew = new System.Windows.Forms.Button();
			this._Option1_1 = new System.Windows.Forms.RadioButton();
			this._Option1_2 = new System.Windows.Forms.RadioButton();
			this.cmdexit = new System.Windows.Forms.Button();
			this.cmdnext = new System.Windows.Forms.Button();
			this.DataList1 = new myDataGridView();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.Option1 = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			//CType(Me.Option1, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Barcode Design";
			this.ClientSize = new System.Drawing.Size(425, 383);
			this.Location = new System.Drawing.Point(3, 29);
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
			this.Name = "frmDesign";
			this.cmdnew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdnew.Text = "N&ew";
			this.cmdnew.Size = new System.Drawing.Size(81, 33);
			this.cmdnew.Location = new System.Drawing.Point(168, 344);
			this.cmdnew.TabIndex = 6;
			this.cmdnew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdnew.CausesValidation = true;
			this.cmdnew.Enabled = true;
			this.cmdnew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdnew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdnew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdnew.TabStop = true;
			this.cmdnew.Name = "cmdnew";
			this._Option1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._Option1_1.Text = "&Shelf Talker";
			this._Option1_1.Size = new System.Drawing.Size(113, 33);
			this._Option1_1.Location = new System.Drawing.Point(144, 32);
			this._Option1_1.Appearance = System.Windows.Forms.Appearance.Button;
			this._Option1_1.TabIndex = 5;
			this._Option1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._Option1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Option1_1.CausesValidation = true;
			this._Option1_1.Enabled = true;
			this._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_1.TabStop = true;
			this._Option1_1.Checked = false;
			this._Option1_1.Visible = true;
			this._Option1_1.Name = "_Option1_1";
			this._Option1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._Option1_2.Text = "Stock &Barcode";
			this._Option1_2.Size = new System.Drawing.Size(129, 33);
			this._Option1_2.Location = new System.Drawing.Point(8, 32);
			this._Option1_2.Appearance = System.Windows.Forms.Appearance.Button;
			this._Option1_2.TabIndex = 4;
			this._Option1_2.Checked = true;
			this._Option1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._Option1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Option1_2.CausesValidation = true;
			this._Option1_2.Enabled = true;
			this._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Option1_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Option1_2.TabStop = true;
			this._Option1_2.Visible = true;
			this._Option1_2.Name = "_Option1_2";
			this.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdexit.Text = "E&xit";
			this.cmdexit.Size = new System.Drawing.Size(81, 33);
			this.cmdexit.Location = new System.Drawing.Point(8, 344);
			this.cmdexit.TabIndex = 2;
			this.cmdexit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdexit.CausesValidation = true;
			this.cmdexit.Enabled = true;
			this.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdexit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdexit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdexit.TabStop = true;
			this.cmdexit.Name = "cmdexit";
			this.cmdnext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdnext.Text = "&Next";
			this.cmdnext.Size = new System.Drawing.Size(81, 33);
			this.cmdnext.Location = new System.Drawing.Point(336, 344);
			this.cmdnext.TabIndex = 1;
			this.cmdnext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdnext.CausesValidation = true;
			this.cmdnext.Enabled = true;
			this.cmdnext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdnext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdnext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdnext.TabStop = true;
			this.cmdnext.Name = "cmdnext";
			//'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(409, 264);
			this.DataList1.Location = new System.Drawing.Point(8, 72);
			this.DataList1.TabIndex = 0;
			this.DataList1.Name = "DataList1";
			this.Label1.Text = "Please select the Stock Barcode you wish to modify";
			this.Label1.Size = new System.Drawing.Size(353, 25);
			this.Label1.Location = new System.Drawing.Point(8, 8);
			this.Label1.TabIndex = 3;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(cmdnew);
			this.Controls.Add(_Option1_1);
			this.Controls.Add(_Option1_2);
			this.Controls.Add(cmdexit);
			this.Controls.Add(cmdnext);
			this.Controls.Add(DataList1);
			this.Controls.Add(Label1);
			//Me.Option1.SetIndex(_Option1_1, CType(1, Short))
			//Me.Option1.SetIndex(_Option1_2, CType(2, Short))
			//CType(Me.Option1, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
