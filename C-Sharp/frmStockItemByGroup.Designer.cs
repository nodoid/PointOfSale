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
	partial class frmStockItemByGroup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockItemByGroup() : base()
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
		private System.Windows.Forms.ListBox withEventsField_lstStockItem;
		public System.Windows.Forms.ListBox lstStockItem {
			get { return withEventsField_lstStockItem; }
			set {
				if (withEventsField_lstStockItem != null) {
					withEventsField_lstStockItem.Enter -= lstStockItem_Enter;
					withEventsField_lstStockItem.KeyPress -= lstStockItem_KeyPress;
				}
				withEventsField_lstStockItem = value;
				if (withEventsField_lstStockItem != null) {
					withEventsField_lstStockItem.Enter += lstStockItem_Enter;
					withEventsField_lstStockItem.KeyPress += lstStockItem_KeyPress;
				}
			}
		}
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockItemByGroup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstStockItem = new System.Windows.Forms.ListBox();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.ControlBox = false;
			this.ClientSize = new System.Drawing.Size(473, 498);
			this.Location = new System.Drawing.Point(4, 4);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmStockItemByGroup";
			this.lstStockItem.Size = new System.Drawing.Size(461, 407);
			this.lstStockItem.Location = new System.Drawing.Point(6, 50);
			this.lstStockItem.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstStockItem.TabIndex = 0;
			this.lstStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstStockItem.BackColor = System.Drawing.SystemColors.Window;
			this.lstStockItem.CausesValidation = true;
			this.lstStockItem.Enabled = true;
			this.lstStockItem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstStockItem.IntegralHeight = true;
			this.lstStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstStockItem.Sorted = false;
			this.lstStockItem.TabStop = true;
			this.lstStockItem.Visible = true;
			this.lstStockItem.MultiColumn = false;
			this.lstStockItem.Name = "lstStockItem";
			this.Picture1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture1.BackColor = System.Drawing.Color.Blue;
			this.Picture1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Picture1.Size = new System.Drawing.Size(473, 41);
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.Image = (System.Drawing.Image)resources.GetObject("Picture1.Image");
			this.Picture1.TabIndex = 1;
			this.Picture1.TabStop = false;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.Visible = true;
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Picture1.Name = "Picture1";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.Label1.Text = "Press (A) To Select All Products";
			this.Label1.Size = new System.Drawing.Size(461, 33);
			this.Label1.Location = new System.Drawing.Point(6, 462);
			this.Label1.TabIndex = 2;
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
			this.Controls.Add(lstStockItem);
			this.Controls.Add(Picture1);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
