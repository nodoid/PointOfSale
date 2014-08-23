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
	partial class frmFilterOrderList
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmFilterOrderList() : base()
		{
			Load += frmFilterOrderList_Load;
			FormClosed += frmFilterOrderList_FormClosed;
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
		private System.Windows.Forms.CheckedListBox withEventsField_lstFilter;
		public System.Windows.Forms.CheckedListBox lstFilter {
			get { return withEventsField_lstFilter; }
			set {
				if (withEventsField_lstFilter != null) {
					withEventsField_lstFilter.ItemCheck -= lstFilter_ItemCheck;
					withEventsField_lstFilter.KeyDown -= lstFilter_KeyDown;
					withEventsField_lstFilter.KeyPress -= lstFilter_KeyPress;
				}
				withEventsField_lstFilter = value;
				if (withEventsField_lstFilter != null) {
					withEventsField_lstFilter.ItemCheck += lstFilter_ItemCheck;
					withEventsField_lstFilter.KeyDown += lstFilter_KeyDown;
					withEventsField_lstFilter.KeyPress += lstFilter_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Button _cmdClick_4;
		public System.Windows.Forms.Button _cmdClick_1;
		public System.Windows.Forms.Button _cmdClick_2;
		public System.Windows.Forms.Button _cmdClick_3;
		private System.Windows.Forms.TextBox withEventsField_txtSearch;
		public System.Windows.Forms.TextBox txtSearch {
			get { return withEventsField_txtSearch; }
			set {
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter -= txtSearch_Enter;
					withEventsField_txtSearch.KeyDown -= txtSearch_KeyDown;
					withEventsField_txtSearch.KeyPress -= txtSearch_KeyPress;
				}
				withEventsField_txtSearch = value;
				if (withEventsField_txtSearch != null) {
					withEventsField_txtSearch.Enter += txtSearch_Enter;
					withEventsField_txtSearch.KeyDown += txtSearch_KeyDown;
					withEventsField_txtSearch.KeyPress += txtSearch_KeyPress;
				}
			}
		}
		private System.Windows.Forms.ToolStripButton withEventsField__tbStockItem_Button1;
		public System.Windows.Forms.ToolStripButton _tbStockItem_Button1 {
			get { return withEventsField__tbStockItem_Button1; }
			set {
				if (withEventsField__tbStockItem_Button1 != null) {
					withEventsField__tbStockItem_Button1.Click -= tbStockItem_ButtonClick;
				}
				withEventsField__tbStockItem_Button1 = value;
				if (withEventsField__tbStockItem_Button1 != null) {
					withEventsField__tbStockItem_Button1.Click += tbStockItem_ButtonClick;
				}
			}
		}
		private System.Windows.Forms.ToolStripButton withEventsField__tbStockItem_Button2;
		public System.Windows.Forms.ToolStripButton _tbStockItem_Button2 {
			get { return withEventsField__tbStockItem_Button2; }
			set {
				if (withEventsField__tbStockItem_Button2 != null) {
					withEventsField__tbStockItem_Button2.Click -= tbStockItem_ButtonClick;
				}
				withEventsField__tbStockItem_Button2 = value;
				if (withEventsField__tbStockItem_Button2 != null) {
					withEventsField__tbStockItem_Button2.Click += tbStockItem_ButtonClick;
				}
			}
		}
		private System.Windows.Forms.ToolStripButton withEventsField__tbStockItem_Button3;
		public System.Windows.Forms.ToolStripButton _tbStockItem_Button3 {
			get { return withEventsField__tbStockItem_Button3; }
			set {
				if (withEventsField__tbStockItem_Button3 != null) {
					withEventsField__tbStockItem_Button3.Click -= tbStockItem_ButtonClick;
				}
				withEventsField__tbStockItem_Button3 = value;
				if (withEventsField__tbStockItem_Button3 != null) {
					withEventsField__tbStockItem_Button3.Click += tbStockItem_ButtonClick;
				}
			}
		}
		private System.Windows.Forms.ToolStripButton withEventsField__tbStockItem_Button4;
		public System.Windows.Forms.ToolStripButton _tbStockItem_Button4 {
			get { return withEventsField__tbStockItem_Button4; }
			set {
				if (withEventsField__tbStockItem_Button4 != null) {
					withEventsField__tbStockItem_Button4.Click -= tbStockItem_ButtonClick;
				}
				withEventsField__tbStockItem_Button4 = value;
				if (withEventsField__tbStockItem_Button4 != null) {
					withEventsField__tbStockItem_Button4.Click += tbStockItem_ButtonClick;
				}
			}
		}
		public System.Windows.Forms.ToolStrip tbStockItem;
		public System.Windows.Forms.ImageList ilSelect;
		public System.Windows.Forms.Label _lbl_2;
		//Public WithEvents cmdClick As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFilterOrderList));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstFilter = new System.Windows.Forms.CheckedListBox();
			this._cmdClick_4 = new System.Windows.Forms.Button();
			this._cmdClick_1 = new System.Windows.Forms.Button();
			this._cmdClick_2 = new System.Windows.Forms.Button();
			this._cmdClick_3 = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.tbStockItem = new System.Windows.Forms.ToolStrip();
			this._tbStockItem_Button1 = new System.Windows.Forms.ToolStripButton();
			this._tbStockItem_Button2 = new System.Windows.Forms.ToolStripButton();
			this._tbStockItem_Button3 = new System.Windows.Forms.ToolStripButton();
			this._tbStockItem_Button4 = new System.Windows.Forms.ToolStripButton();
			this.ilSelect = new System.Windows.Forms.ImageList();
			this._lbl_2 = new System.Windows.Forms.Label();
			//Me.cmdClick = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.tbStockItem.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmdClick).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ClientSize = new System.Drawing.Size(293, 452);
			this.Location = new System.Drawing.Point(3, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmFilterOrderList";
			this.lstFilter.Size = new System.Drawing.Size(271, 379);
			this.lstFilter.Location = new System.Drawing.Point(9, 63);
			this.lstFilter.TabIndex = 7;
			this.lstFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFilter.BackColor = System.Drawing.SystemColors.Window;
			this.lstFilter.CausesValidation = true;
			this.lstFilter.Enabled = true;
			this.lstFilter.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFilter.IntegralHeight = true;
			this.lstFilter.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFilter.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFilter.Sorted = false;
			this.lstFilter.TabStop = true;
			this.lstFilter.Visible = true;
			this.lstFilter.MultiColumn = false;
			this.lstFilter.Name = "lstFilter";
			this._cmdClick_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClick_4.Text = "&C";
			this._cmdClick_4.Size = new System.Drawing.Size(103, 34);
			this._cmdClick_4.Location = new System.Drawing.Point(360, 138);
			this._cmdClick_4.TabIndex = 6;
			this._cmdClick_4.TabStop = false;
			this._cmdClick_4.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClick_4.CausesValidation = true;
			this._cmdClick_4.Enabled = true;
			this._cmdClick_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClick_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClick_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClick_4.Name = "_cmdClick_4";
			this._cmdClick_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClick_1.Text = "&A";
			this._cmdClick_1.Size = new System.Drawing.Size(103, 34);
			this._cmdClick_1.Location = new System.Drawing.Point(357, 204);
			this._cmdClick_1.TabIndex = 5;
			this._cmdClick_1.TabStop = false;
			this._cmdClick_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClick_1.CausesValidation = true;
			this._cmdClick_1.Enabled = true;
			this._cmdClick_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClick_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClick_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClick_1.Name = "_cmdClick_1";
			this._cmdClick_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClick_2.Text = "&S";
			this._cmdClick_2.Size = new System.Drawing.Size(103, 34);
			this._cmdClick_2.Location = new System.Drawing.Point(360, 252);
			this._cmdClick_2.TabIndex = 4;
			this._cmdClick_2.TabStop = false;
			this._cmdClick_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClick_2.CausesValidation = true;
			this._cmdClick_2.Enabled = true;
			this._cmdClick_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClick_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClick_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClick_2.Name = "_cmdClick_2";
			this._cmdClick_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClick_3.Text = "&U";
			this._cmdClick_3.Size = new System.Drawing.Size(103, 34);
			this._cmdClick_3.Location = new System.Drawing.Point(351, 303);
			this._cmdClick_3.TabIndex = 3;
			this._cmdClick_3.TabStop = false;
			this._cmdClick_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClick_3.CausesValidation = true;
			this._cmdClick_3.Enabled = true;
			this._cmdClick_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClick_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClick_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClick_3.Name = "_cmdClick_3";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(223, 19);
			this.txtSearch.Location = new System.Drawing.Point(57, 42);
			this.txtSearch.TabIndex = 1;
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
			this.tbStockItem.ShowItemToolTips = true;
			this.tbStockItem.Size = new System.Drawing.Size(272, 40);
			this.tbStockItem.Location = new System.Drawing.Point(9, 0);
			this.tbStockItem.TabIndex = 0;
			this.tbStockItem.ImageList = ilSelect;
			this.tbStockItem.Name = "tbStockItem";
			this._tbStockItem_Button1.Size = new System.Drawing.Size(68, 41);
			this._tbStockItem_Button1.AutoSize = false;
			this._tbStockItem_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this._tbStockItem_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tbStockItem_Button1.Text = "&All";
			this._tbStockItem_Button1.Name = "All";
			this._tbStockItem_Button1.ImageIndex = 0;
			this._tbStockItem_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._tbStockItem_Button2.Size = new System.Drawing.Size(68, 41);
			this._tbStockItem_Button2.AutoSize = false;
			this._tbStockItem_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this._tbStockItem_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tbStockItem_Button2.Text = "&Selected";
			this._tbStockItem_Button2.Name = "Selected";
			this._tbStockItem_Button2.ImageIndex = 1;
			this._tbStockItem_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._tbStockItem_Button3.Size = new System.Drawing.Size(68, 41);
			this._tbStockItem_Button3.AutoSize = false;
			this._tbStockItem_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this._tbStockItem_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tbStockItem_Button3.Text = "&Unselected";
			this._tbStockItem_Button3.Name = "Unselected";
			this._tbStockItem_Button3.ImageIndex = 2;
			this._tbStockItem_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._tbStockItem_Button4.Size = new System.Drawing.Size(68, 41);
			this._tbStockItem_Button4.AutoSize = false;
			this._tbStockItem_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this._tbStockItem_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tbStockItem_Button4.Text = "&Clear All";
			this._tbStockItem_Button4.Name = "clear";
			this._tbStockItem_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.ilSelect.ImageSize = new System.Drawing.Size(20, 20);
			this.ilSelect.TransparentColor = System.Drawing.Color.FromArgb(255, 0, 255);
			this.ilSelect.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilSelect.ImageStream");
			this.ilSelect.Images.SetKeyName(0, "");
			this.ilSelect.Images.SetKeyName(1, "");
			this.ilSelect.Images.SetKeyName(2, "");
			this._lbl_2.Text = "Search:";
			this._lbl_2.Size = new System.Drawing.Size(40, 13);
			this._lbl_2.Location = new System.Drawing.Point(9, 48);
			this._lbl_2.TabIndex = 2;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = false;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this.Controls.Add(lstFilter);
			this.Controls.Add(_cmdClick_4);
			this.Controls.Add(_cmdClick_1);
			this.Controls.Add(_cmdClick_2);
			this.Controls.Add(_cmdClick_3);
			this.Controls.Add(txtSearch);
			this.Controls.Add(tbStockItem);
			this.Controls.Add(_lbl_2);
			this.tbStockItem.Items.Add(_tbStockItem_Button1);
			this.tbStockItem.Items.Add(_tbStockItem_Button2);
			this.tbStockItem.Items.Add(_tbStockItem_Button3);
			this.tbStockItem.Items.Add(_tbStockItem_Button4);
			//Me.cmdClick.SetIndex(_cmdClick_4, CType(4, Short))
			//Me.cmdClick.SetIndex(_cmdClick_1, CType(1, Short))
			//Me.cmdClick.SetIndex(_cmdClick_2, CType(2, Short))
			//Me.cmdClick.SetIndex(_cmdClick_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdClick, System.ComponentModel.ISupportInitialize).EndInit()
			this.tbStockItem.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
