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
	partial class frmBlockTestSelect
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmBlockTestSelect() : base()
		{
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
		private System.Windows.Forms.Button withEventsField_cmdNewExist;
		public System.Windows.Forms.Button cmdNewExist {
			get { return withEventsField_cmdNewExist; }
			set {
				if (withEventsField_cmdNewExist != null) {
					withEventsField_cmdNewExist.Click -= cmdNewExist_Click;
				}
				withEventsField_cmdNewExist = value;
				if (withEventsField_cmdNewExist != null) {
					withEventsField_cmdNewExist.Click += cmdNewExist_Click;
				}
			}
		}
		public System.Windows.Forms.Button cmddelete;
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
					withEventsField_lvImport.DoubleClick -= lvImport_DoubleClick;
					withEventsField_lvImport.KeyPress -= lvImport_KeyPress;
				}
				withEventsField_lvImport = value;
				if (withEventsField_lvImport != null) {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBlockTestSelect));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdNewExist = new System.Windows.Forms.Button();
			this.cmddelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
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
			this.Text = "Block Test";
			this.ClientSize = new System.Drawing.Size(574, 448);
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
			this.Name = "frmBlockTestSelect";
			this.cmdNewExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewExist.Text = "Create a N&ew Test  based on existing";
			this.cmdNewExist.Size = new System.Drawing.Size(130, 49);
			this.cmdNewExist.Location = new System.Drawing.Point(296, 390);
			this.cmdNewExist.TabIndex = 8;
			this.cmdNewExist.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewExist.CausesValidation = true;
			this.cmdNewExist.Enabled = true;
			this.cmdNewExist.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewExist.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewExist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewExist.TabStop = true;
			this.cmdNewExist.Name = "cmdNewExist";
			this.cmddelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmddelete.Text = "&Delete G.R.V";
			this.cmddelete.Size = new System.Drawing.Size(111, 27);
			this.cmddelete.Location = new System.Drawing.Point(488, 456);
			this.cmddelete.TabIndex = 7;
			this.cmddelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmddelete.CausesValidation = true;
			this.cmddelete.Enabled = true;
			this.cmddelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmddelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmddelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmddelete.TabStop = true;
			this.cmddelete.Name = "cmddelete";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Load Selected Test";
			this.cmdEdit.Size = new System.Drawing.Size(130, 49);
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
			this.cmdExit.Size = new System.Drawing.Size(121, 49);
			this.cmdExit.Location = new System.Drawing.Point(448, 390);
			this.cmdExit.TabIndex = 0;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
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
			this._lvImport_ColumnHeader_1.Text = "Block Test Name";
			this._lvImport_ColumnHeader_1.Width = 200;
			this._lvImport_ColumnHeader_2.Text = "Test Date";
			this._lvImport_ColumnHeader_2.Width = 142;
			this._lvImport_ColumnHeader_3.Text = "Person Cutting";
			this._lvImport_ColumnHeader_3.Width = 212;
			this._lvImport_ColumnHeader_4.Text = "Main Stock Item";
			this._lvImport_ColumnHeader_4.Width = 358;
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
			this.cmdNew.Text = "Create a N&ew Test";
			this.cmdNew.Size = new System.Drawing.Size(130, 49);
			this.cmdNew.Location = new System.Drawing.Point(152, 390);
			this.cmdNew.TabIndex = 5;
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.Controls.Add(cmdNewExist);
			this.Controls.Add(cmddelete);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdExit);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(cmdNew);
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
