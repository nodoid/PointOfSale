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
	partial class frmGRVselect
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVselect() : base()
		{
			FormClosed += frmGRVselect_FormClosed;
			Load += frmGRVselect_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdVoucher;
		public System.Windows.Forms.Button cmdVoucher {
			get { return withEventsField_cmdVoucher; }
			set {
				if (withEventsField_cmdVoucher != null) {
					withEventsField_cmdVoucher.Click -= cmdVoucher_Click;
				}
				withEventsField_cmdVoucher = value;
				if (withEventsField_cmdVoucher != null) {
					withEventsField_cmdVoucher.Click += cmdVoucher_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdNewFnV;
		public System.Windows.Forms.Button cmdNewFnV {
			get { return withEventsField_cmdNewFnV; }
			set {
				if (withEventsField_cmdNewFnV != null) {
					withEventsField_cmdNewFnV.Click -= cmdNewFnV_Click;
				}
				withEventsField_cmdNewFnV = value;
				if (withEventsField_cmdNewFnV != null) {
					withEventsField_cmdNewFnV.Click += cmdNewFnV_Click;
				}
			}
		}
		public System.Windows.Forms.ProgressBar prgBar;
		public System.Windows.Forms.Label lblNum;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.Button withEventsField_cmdAirTime;
		public System.Windows.Forms.Button cmdAirTime {
			get { return withEventsField_cmdAirTime; }
			set {
				if (withEventsField_cmdAirTime != null) {
					withEventsField_cmdAirTime.Click -= cmdAirTime_Click;
				}
				withEventsField_cmdAirTime = value;
				if (withEventsField_cmdAirTime != null) {
					withEventsField_cmdAirTime.Click += cmdAirTime_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdImport;
		public System.Windows.Forms.Button cmdImport {
			get { return withEventsField_cmdImport; }
			set {
				if (withEventsField_cmdImport != null) {
					withEventsField_cmdImport.Click -= cmdImport_Click;
				}
				withEventsField_cmdImport = value;
				if (withEventsField_cmdImport != null) {
					withEventsField_cmdImport.Click += cmdImport_Click;
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
		private System.Windows.Forms.Button withEventsField_cmddelete;
		public System.Windows.Forms.Button cmddelete {
			get { return withEventsField_cmddelete; }
			set {
				if (withEventsField_cmddelete != null) {
					withEventsField_cmddelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmddelete = value;
				if (withEventsField_cmddelete != null) {
					withEventsField_cmddelete.Click += cmdDelete_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtSearch;
		public System.Windows.Forms.TextBox txtSearch {
			get { return withEventsField_txtSearch; }
			set {
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter -= txtSearch_Enter;
					withEventsField_txtSearch.KeyPress -= txtSearch_KeyPress;
				}
				withEventsField_txtSearch = value;
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter += txtSearch_Enter;
					withEventsField_txtSearch.KeyPress += txtSearch_KeyPress;
				}
			}
		}
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lvImport_ColumnHeader_5;
		private System.Windows.Forms.ListView withEventsField_lvImport;
		public System.Windows.Forms.ListView lvImport {
			get { return withEventsField_lvImport; }
			set {
				if (withEventsField_lvImport != null) {
					withEventsField_lvImport.Click -= lvImport_Click;
					withEventsField_lvImport.DoubleClick -= lvImport_DoubleClick;
					withEventsField_lvImport.KeyDown -= lvImport_KeyDown;
					withEventsField_lvImport.KeyPress -= lvImport_KeyPress;
				}
				withEventsField_lvImport = value;
				if (withEventsField_lvImport != null) {
					withEventsField_lvImport.Click += lvImport_Click;
					withEventsField_lvImport.DoubleClick += lvImport_DoubleClick;
					withEventsField_lvImport.KeyDown += lvImport_KeyDown;
					withEventsField_lvImport.KeyPress += lvImport_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.GroupBox _Frame1_0;
		private System.Windows.Forms.Button withEventsField_cmdNew;
		public System.Windows.Forms.Button cmdNew {
			get { return withEventsField_cmdNew; }
			set {
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click -= cmdNew_Click;
				}
				withEventsField_cmdNew = value;
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click += cmdNew_Click;
				}
			}
		}
		public System.Windows.Forms.OpenFileDialog CDOpen;
		public System.Windows.Forms.Label Label1;
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVselect));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdVoucher = new System.Windows.Forms.Button();
			this.cmdNewFnV = new System.Windows.Forms.Button();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.prgBar = new System.Windows.Forms.ProgressBar();
			this.lblNum = new System.Windows.Forms.Label();
			this.cmdAirTime = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdImport = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.cmddelete = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lvImport = new System.Windows.Forms.ListView();
			this._lvImport_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_4 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_5 = new System.Windows.Forms.ColumnHeader();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.cmdNew = new System.Windows.Forms.Button();
			this.CDOpen = new System.Windows.Forms.OpenFileDialog();
			this.Label1 = new System.Windows.Forms.Label();
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Frame2.SuspendLayout();
			this._Frame1_0.SuspendLayout();
			this.lvImport.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select GRV Type ...";
			this.ClientSize = new System.Drawing.Size(590, 465);
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
			this.Name = "frmGRVselect";
			this.cmdVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdVoucher.Text = "&4POS Voucher G.R.V";
			this.cmdVoucher.Size = new System.Drawing.Size(73, 49);
			this.cmdVoucher.Location = new System.Drawing.Point(496, 336);
			this.cmdVoucher.TabIndex = 15;
			this.cmdVoucher.Visible = false;
			this.cmdVoucher.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVoucher.CausesValidation = true;
			this.cmdVoucher.Enabled = true;
			this.cmdVoucher.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVoucher.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVoucher.TabStop = true;
			this.cmdVoucher.Name = "cmdVoucher";
			this.cmdNewFnV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewFnV.Text = "&Fruit n Veg G.R.V";
			this.cmdNewFnV.Size = new System.Drawing.Size(73, 49);
			this.cmdNewFnV.Location = new System.Drawing.Point(416, 390);
			this.cmdNewFnV.TabIndex = 14;
			this.cmdNewFnV.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewFnV.CausesValidation = true;
			this.cmdNewFnV.Enabled = true;
			this.cmdNewFnV.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewFnV.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewFnV.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewFnV.TabStop = true;
			this.cmdNewFnV.Name = "cmdNewFnV";
			this.Frame2.Text = "Importing Airtime file ";
			this.Frame2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame2.Size = new System.Drawing.Size(557, 65);
			this.Frame2.Location = new System.Drawing.Point(16, 280);
			this.Frame2.TabIndex = 11;
			this.Frame2.Visible = false;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.prgBar.Size = new System.Drawing.Size(549, 31);
			this.prgBar.Location = new System.Drawing.Point(8, 24);
			this.prgBar.TabIndex = 12;
			this.prgBar.Name = "prgBar";
			this.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblNum.BackColor = System.Drawing.Color.Transparent;
			this.lblNum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblNum.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNum.Size = new System.Drawing.Size(283, 17);
			this.lblNum.Location = new System.Drawing.Point(120, 40);
			this.lblNum.TabIndex = 13;
			this.lblNum.Enabled = true;
			this.lblNum.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNum.UseMnemonic = true;
			this.lblNum.Visible = true;
			this.lblNum.AutoSize = false;
			this.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblNum.Name = "lblNum";
			this.cmdAirTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAirTime.Text = "&Air Time G.R.V";
			this.cmdAirTime.Size = new System.Drawing.Size(73, 49);
			this.cmdAirTime.Location = new System.Drawing.Point(336, 390);
			this.cmdAirTime.TabIndex = 10;
			this.cmdAirTime.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAirTime.CausesValidation = true;
			this.cmdAirTime.Enabled = true;
			this.cmdAirTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAirTime.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAirTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAirTime.TabStop = true;
			this.cmdAirTime.Name = "cmdAirTime";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Load Selected G.R.V.";
			this.cmdEdit.Size = new System.Drawing.Size(113, 49);
			this.cmdEdit.Location = new System.Drawing.Point(15, 390);
			this.cmdEdit.TabIndex = 7;
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdImport.Text = "&Import a G.R.V.";
			this.cmdImport.Size = new System.Drawing.Size(73, 49);
			this.cmdImport.Location = new System.Drawing.Point(256, 390);
			this.cmdImport.TabIndex = 5;
			this.cmdImport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdImport.CausesValidation = true;
			this.cmdImport.Enabled = true;
			this.cmdImport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdImport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdImport.TabStop = true;
			this.cmdImport.Name = "cmdImport";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 49);
			this.cmdExit.Location = new System.Drawing.Point(496, 390);
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
			this._Frame1_0.Location = new System.Drawing.Point(15, 12);
			this._Frame1_0.TabIndex = 1;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.cmddelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmddelete.Text = "&Delete G.R.V";
			this.cmddelete.Size = new System.Drawing.Size(111, 27);
			this.cmddelete.Location = new System.Drawing.Point(440, 8);
			this.cmddelete.TabIndex = 9;
			this.cmddelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmddelete.CausesValidation = true;
			this.cmddelete.Enabled = true;
			this.cmddelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmddelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmddelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmddelete.TabStop = true;
			this.cmddelete.Name = "cmddelete";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(283, 19);
			this.txtSearch.Location = new System.Drawing.Point(52, 18);
			this.txtSearch.TabIndex = 3;
			this.txtSearch.AcceptsReturn = true;
			this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
			this.txtSearch.CausesValidation = true;
			this.txtSearch.Enabled = true;
			this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSearch.HideSelection = true;
			this.txtSearch.ReadOnly = false;
			this.txtSearch.MaxLength = 0;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.Multiline = false;
			this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSearch.TabStop = true;
			this.txtSearch.Visible = true;
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSearch.Name = "txtSearch";
			this.lvImport.Size = new System.Drawing.Size(541, 316);
			this.lvImport.Location = new System.Drawing.Point(9, 40);
			this.lvImport.TabIndex = 2;
			this.lvImport.View = System.Windows.Forms.View.Details;
			this.lvImport.LabelEdit = false;
			this.lvImport.LabelWrap = true;
			this.lvImport.HideSelection = false;
			this.lvImport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvImport.BackColor = System.Drawing.SystemColors.Window;
			this.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvImport.Name = "lvImport";
			this._lvImport_ColumnHeader_1.Text = "Supplier";
			this._lvImport_ColumnHeader_1.Width = 177;
			this._lvImport_ColumnHeader_2.Text = "Order Date";
			this._lvImport_ColumnHeader_2.Width = 142;
			this._lvImport_ColumnHeader_3.Text = "Reference";
			this._lvImport_ColumnHeader_3.Width = 165;
			this._lvImport_ColumnHeader_4.Text = "Invoice #";
			this._lvImport_ColumnHeader_4.Width = 170;
			this._lvImport_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvImport_ColumnHeader_5.Text = "Amount";
			this._lvImport_ColumnHeader_5.Width = 95;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "&Search :";
			this._lbl_0.Size = new System.Drawing.Size(40, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 21);
			this._lbl_0.TabIndex = 4;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "Create a N&ew G.R.V.";
			this.cmdNew.Size = new System.Drawing.Size(113, 49);
			this.cmdNew.Location = new System.Drawing.Point(136, 390);
			this.cmdNew.TabIndex = 6;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.CDOpen.Title = "Select GRV import file ...";
			this.Label1.Text = "Import GRV field sequence: Barcode, Quantity, Description, Cost, Selling";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Label1.Size = new System.Drawing.Size(426, 16);
			this.Label1.Location = new System.Drawing.Point(105, 444);
			this.Label1.TabIndex = 8;
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
			this.Controls.Add(cmdVoucher);
			this.Controls.Add(cmdNewFnV);
			this.Controls.Add(Frame2);
			this.Controls.Add(cmdAirTime);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdImport);
			this.Controls.Add(cmdExit);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(cmdNew);
			this.Controls.Add(Label1);
			this.Frame2.Controls.Add(prgBar);
			this.Frame2.Controls.Add(lblNum);
			this._Frame1_0.Controls.Add(cmddelete);
			this._Frame1_0.Controls.Add(txtSearch);
			this._Frame1_0.Controls.Add(lvImport);
			this._Frame1_0.Controls.Add(_lbl_0);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_1);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_2);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_3);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_4);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_5);
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			this.Frame2.ResumeLayout(false);
			this._Frame1_0.ResumeLayout(false);
			this.lvImport.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
