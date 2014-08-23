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
	partial class frmVegTestSelect
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmVegTestSelect() : base()
		{
			KeyDown += frmVegTestSelect_KeyDown;
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
		private System.Windows.Forms.Button withEventsField_cmdRepair;
		public System.Windows.Forms.Button cmdRepair {
			get { return withEventsField_cmdRepair; }
			set {
				if (withEventsField_cmdRepair != null) {
					withEventsField_cmdRepair.Click -= cmdRepair_Click;
				}
				withEventsField_cmdRepair = value;
				if (withEventsField_cmdRepair != null) {
					withEventsField_cmdRepair.Click += cmdRepair_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRevST;
		public System.Windows.Forms.Button cmdRevST {
			get { return withEventsField_cmdRevST; }
			set {
				if (withEventsField_cmdRevST != null) {
					withEventsField_cmdRevST.Click -= cmdRevST_Click;
				}
				withEventsField_cmdRevST = value;
				if (withEventsField_cmdRevST != null) {
					withEventsField_cmdRevST.Click += cmdRevST_Click;
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
		private System.Windows.Forms.ListView withEventsField_lvImport;
		public System.Windows.Forms.ListView lvImport {
			get { return withEventsField_lvImport; }
			set {
				if (withEventsField_lvImport != null) {
					withEventsField_lvImport.Click -= lvImport_Click;
					withEventsField_lvImport.DoubleClick -= lvImport_DoubleClick;
					withEventsField_lvImport.KeyPress -= lvImport_KeyPress;
				}
				withEventsField_lvImport = value;
				if (withEventsField_lvImport != null) {
					withEventsField_lvImport.Click += lvImport_Click;
					withEventsField_lvImport.DoubleClick += lvImport_DoubleClick;
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
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVegTestSelect));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdRepair = new System.Windows.Forms.Button();
			this.cmdRevST = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.cmddelete = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lvImport = new System.Windows.Forms.ListView();
			this._lvImport_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this._lvImport_ColumnHeader_4 = new System.Windows.Forms.ColumnHeader();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.cmdNew = new System.Windows.Forms.Button();
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this._Frame1_0.SuspendLayout();
			this.lvImport.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "4VEG Production List";
			this.ClientSize = new System.Drawing.Size(574, 449);
			this.Location = new System.Drawing.Point(3, 29);
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
			this.Name = "frmVegTestSelect";
			this.cmdRepair.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRepair.Text = "Repair Product";
			this.cmdRepair.Size = new System.Drawing.Size(73, 49);
			this.cmdRepair.Location = new System.Drawing.Point(424, 390);
			this.cmdRepair.TabIndex = 9;
			this.cmdRepair.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRepair.CausesValidation = true;
			this.cmdRepair.Enabled = true;
			this.cmdRepair.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRepair.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRepair.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRepair.TabStop = true;
			this.cmdRepair.Name = "cmdRepair";
			this.cmdRevST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRevST.Text = "Stock Receiving";
			this.cmdRevST.Size = new System.Drawing.Size(73, 49);
			this.cmdRevST.Location = new System.Drawing.Point(344, 390);
			this.cmdRevST.TabIndex = 7;
			this.cmdRevST.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRevST.CausesValidation = true;
			this.cmdRevST.Enabled = true;
			this.cmdRevST.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRevST.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRevST.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRevST.TabStop = true;
			this.cmdRevST.Name = "cmdRevST";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Load Selected Production Test";
			this.cmdEdit.Size = new System.Drawing.Size(161, 49);
			this.cmdEdit.Location = new System.Drawing.Point(8, 390);
			this.cmdEdit.TabIndex = 6;
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(65, 49);
			this.cmdExit.Location = new System.Drawing.Point(504, 390);
			this.cmdExit.TabIndex = 0;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.Size = new System.Drawing.Size(559, 370);
			this._Frame1_0.Location = new System.Drawing.Point(8, 8);
			this._Frame1_0.TabIndex = 1;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.cmddelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmddelete.Text = "&Delete Production Test";
			this.cmddelete.Size = new System.Drawing.Size(151, 27);
			this.cmddelete.Location = new System.Drawing.Point(400, 16);
			this.cmddelete.TabIndex = 8;
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
			this.lvImport.Size = new System.Drawing.Size(541, 308);
			this.lvImport.Location = new System.Drawing.Point(9, 48);
			this.lvImport.TabIndex = 2;
			this.lvImport.View = System.Windows.Forms.View.Details;
			this.lvImport.LabelEdit = false;
			this.lvImport.LabelWrap = true;
			this.lvImport.HideSelection = false;
			this.lvImport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvImport.BackColor = System.Drawing.SystemColors.Window;
			this.lvImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvImport.Name = "lvImport";
			this._lvImport_ColumnHeader_1.Text = "Production Test Name";
			this._lvImport_ColumnHeader_1.Width = 219;
			this._lvImport_ColumnHeader_2.Text = "Production Date";
			this._lvImport_ColumnHeader_2.Width = 171;
			this._lvImport_ColumnHeader_3.Text = "Person Cutting";
			this._lvImport_ColumnHeader_3.Width = 212;
			this._lvImport_ColumnHeader_4.Text = "Main Stock Item";
			this._lvImport_ColumnHeader_4.Width = 311;
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
			this.cmdNew.Text = "Create a N&ew Production Test";
			this.cmdNew.Size = new System.Drawing.Size(161, 49);
			this.cmdNew.Location = new System.Drawing.Point(176, 390);
			this.cmdNew.TabIndex = 5;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.Controls.Add(cmdRepair);
			this.Controls.Add(cmdRevST);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdExit);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(cmdNew);
			this._Frame1_0.Controls.Add(cmddelete);
			this._Frame1_0.Controls.Add(txtSearch);
			this._Frame1_0.Controls.Add(lvImport);
			this._Frame1_0.Controls.Add(_lbl_0);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_1);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_2);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_3);
			this.lvImport.Columns.Add(_lvImport_ColumnHeader_4);
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			this._Frame1_0.ResumeLayout(false);
			this.lvImport.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
