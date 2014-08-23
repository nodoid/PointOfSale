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
	partial class frmGRVimport
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVimport() : base()
		{
			Load += frmGRVimport_Load;
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
		private System.Windows.Forms.Timer withEventsField_tmrAutoGRV;
		public System.Windows.Forms.Timer tmrAutoGRV {
			get { return withEventsField_tmrAutoGRV; }
			set {
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick -= tmrAutoGRV_Tick;
				}
				withEventsField_tmrAutoGRV = value;
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick += tmrAutoGRV_Tick;
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
		public System.Windows.Forms.OpenFileDialog CDOpen;
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
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_5;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_6;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_7;
		public System.Windows.Forms.ListView lvImport;
		public System.Windows.Forms.GroupBox _Frame1_0;
		private myDataGridView withEventsField_DataList1;
		public myDataGridView DataList1 {
			get { return withEventsField_DataList1; }
			set {
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick -= DataList1_DblClick;
					withEventsField_DataList1.KeyPress -= DataList1_KeyPress;
				}
				withEventsField_DataList1 = value;
				if (withEventsField_DataList1 != null) {
					withEventsField_DataList1.DoubleClick += DataList1_DblClick;
					withEventsField_DataList1.KeyPress += DataList1_KeyPress;
				}
			}
		}
		public System.Windows.Forms.GroupBox _Frame1_1;
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVimport));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.tmrAutoGRV = new System.Windows.Forms.Timer(components);
			this.cmdNext = new System.Windows.Forms.Button();
			this.CDOpen = new System.Windows.Forms.OpenFileDialog();
			this.cmdExit = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.lvImport = new System.Windows.Forms.ListView();
			this._lvImport_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_4 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_5 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_6 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_7 = new System.Windows.Forms.ColumnHeader();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this.DataList1 = new myDataGridView();
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			this._Frame1_0.SuspendLayout();
			this.lvImport.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Import a GRV ...";
			this.ClientSize = new System.Drawing.Size(590, 462);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
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
			this.Name = "frmGRVimport";
			this.tmrAutoGRV.Enabled = false;
			this.tmrAutoGRV.Interval = 10;
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Size = new System.Drawing.Size(88, 49);
			this.cmdNext.Location = new System.Drawing.Point(486, 402);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.TabStop = true;
			this.cmdNext.Name = "cmdNext";
			this.CDOpen.Title = "Select GRV import file ...";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(88, 49);
			this.cmdExit.Location = new System.Drawing.Point(15, 402);
			this.cmdExit.TabIndex = 0;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this._Frame1_0.Text = "Imported GRV Data";
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.Size = new System.Drawing.Size(559, 370);
			this._Frame1_0.Location = new System.Drawing.Point(15, 24);
			this._Frame1_0.TabIndex = 2;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.lvImport.Size = new System.Drawing.Size(541, 346);
			this.lvImport.Location = new System.Drawing.Point(9, 15);
			this.lvImport.TabIndex = 3;
			this.lvImport.View = System.Windows.Forms.View.Details;
			this.lvImport.LabelEdit = false;
			this.lvImport.LabelWrap = true;
			this.lvImport.HideSelection = false;
			this.lvImport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvImport.BackColor = System.Drawing.SystemColors.Window;
			this.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvImport.Name = "lvImport";
			this._lvImport_ColumnHeader_1.Text = "Barcode";
			this._lvImport_ColumnHeader_1.Width = 118;
			this._lvImport_ColumnHeader_2.Text = "Name";
			this._lvImport_ColumnHeader_2.Width = 236;
			this._lvImport_ColumnHeader_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_3.Text = "Pack Size";
			this._lvImport_ColumnHeader_3.Width = 106;
			this._lvImport_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_4.Text = "Quantity";
			this._lvImport_ColumnHeader_4.Width = 95;
			this._lvImport_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_5.Text = "Cost";
			this._lvImport_ColumnHeader_5.Width = 118;
			this._lvImport_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_6.Text = "Price";
			this._lvImport_ColumnHeader_6.Width = 118;
			this._lvImport_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_7.Text = "Order";
			this._lvImport_ColumnHeader_7.Width = 71;
			this._Frame1_1.Text = "Select a Supplier for this GRV ...";
			this._Frame1_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_1.Size = new System.Drawing.Size(559, 370);
			this._Frame1_1.Location = new System.Drawing.Point(15, 24);
			this._Frame1_1.TabIndex = 4;
			this._Frame1_1.Visible = false;
			this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_1.Enabled = true;
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.Name = "_Frame1_1";
			//'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(328, 342);
			this.DataList1.Location = new System.Drawing.Point(219, 15);
			this.DataList1.TabIndex = 5;
			this.DataList1.Name = "DataList1";
			this.Controls.Add(cmdNext);
			this.Controls.Add(cmdExit);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(_Frame1_1);
			this._Frame1_0.Controls.Add(lvImport);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_1);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_2);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_3);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_4);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_5);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_6);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_7);
			this._Frame1_1.Controls.Add(DataList1);
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this._Frame1_0.ResumeLayout(false);
			this.lvImport.ResumeLayout(false);
			this._Frame1_1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
