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
	partial class frmItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmItem() : base()
		{
			Load += frmItem_Load;
			KeyPress += frmItem_KeyPress;
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
		public System.Windows.Forms.Button _cmdClear_10;
		public System.Windows.Forms.Button _cmdStockItem_10;
		public System.Windows.Forms.Button _cmdClear_9;
		public System.Windows.Forms.Button _cmdStockItem_9;
		public System.Windows.Forms.Button _cmdClear_8;
		public System.Windows.Forms.Button _cmdStockItem_8;
		public System.Windows.Forms.Button _cmdClear_7;
		public System.Windows.Forms.Button _cmdStockItem_7;
		public System.Windows.Forms.Button _cmdClear_6;
		public System.Windows.Forms.Button _cmdStockItem_6;
		public System.Windows.Forms.Button _cmdClear_5;
		public System.Windows.Forms.Button _cmdStockItem_5;
		public System.Windows.Forms.Button _cmdClear_4;
		public System.Windows.Forms.Button _cmdStockItem_4;
		public System.Windows.Forms.Button _cmdClear_3;
		public System.Windows.Forms.Button _cmdStockItem_3;
		public System.Windows.Forms.Button _cmdClear_2;
		public System.Windows.Forms.Button _cmdStockItem_2;
		public System.Windows.Forms.Button _cmdClear_1;
		public System.Windows.Forms.Button _cmdStockItem_1;
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
		private System.Windows.Forms.Button withEventsField_cmdLoad;
		public System.Windows.Forms.Button cmdLoad {
			get { return withEventsField_cmdLoad; }
			set {
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click -= cmdLoad_Click;
				}
				withEventsField_cmdLoad = value;
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click += cmdLoad_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optDataType_1;
		public System.Windows.Forms.RadioButton _optDataType_0;
		public System.Windows.Forms.Label _lbl_11;
		public System.Windows.Forms.Label _lbl_10;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lblItem_10;
		public System.Windows.Forms.Label _lblItem_9;
		public System.Windows.Forms.Label _lblItem_8;
		public System.Windows.Forms.Label _lblItem_7;
		public System.Windows.Forms.Label _lblItem_6;
		public System.Windows.Forms.Label _lblItem_5;
		public System.Windows.Forms.Label _lblItem_4;
		public System.Windows.Forms.Label _lblItem_3;
		public System.Windows.Forms.Label _lblItem_2;
		public System.Windows.Forms.Label _lblItem_1;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents cmdClear As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents cmdStockItem As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblItem As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optDataType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._cmdClear_10 = new System.Windows.Forms.Button();
			this._cmdStockItem_10 = new System.Windows.Forms.Button();
			this._cmdClear_9 = new System.Windows.Forms.Button();
			this._cmdStockItem_9 = new System.Windows.Forms.Button();
			this._cmdClear_8 = new System.Windows.Forms.Button();
			this._cmdStockItem_8 = new System.Windows.Forms.Button();
			this._cmdClear_7 = new System.Windows.Forms.Button();
			this._cmdStockItem_7 = new System.Windows.Forms.Button();
			this._cmdClear_6 = new System.Windows.Forms.Button();
			this._cmdStockItem_6 = new System.Windows.Forms.Button();
			this._cmdClear_5 = new System.Windows.Forms.Button();
			this._cmdStockItem_5 = new System.Windows.Forms.Button();
			this._cmdClear_4 = new System.Windows.Forms.Button();
			this._cmdStockItem_4 = new System.Windows.Forms.Button();
			this._cmdClear_3 = new System.Windows.Forms.Button();
			this._cmdStockItem_3 = new System.Windows.Forms.Button();
			this._cmdClear_2 = new System.Windows.Forms.Button();
			this._cmdStockItem_2 = new System.Windows.Forms.Button();
			this._cmdClear_1 = new System.Windows.Forms.Button();
			this._cmdStockItem_1 = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdLoad = new System.Windows.Forms.Button();
			this._optDataType_1 = new System.Windows.Forms.RadioButton();
			this._optDataType_0 = new System.Windows.Forms.RadioButton();
			this._lbl_11 = new System.Windows.Forms.Label();
			this._lbl_10 = new System.Windows.Forms.Label();
			this._lbl_9 = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lblItem_10 = new System.Windows.Forms.Label();
			this._lblItem_9 = new System.Windows.Forms.Label();
			this._lblItem_8 = new System.Windows.Forms.Label();
			this._lblItem_7 = new System.Windows.Forms.Label();
			this._lblItem_6 = new System.Windows.Forms.Label();
			this._lblItem_5 = new System.Windows.Forms.Label();
			this._lblItem_4 = new System.Windows.Forms.Label();
			this._lblItem_3 = new System.Windows.Forms.Label();
			this._lblItem_2 = new System.Windows.Forms.Label();
			this._lblItem_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.cmdClear = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.cmdStockItem = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblItem = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optDataType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.cmdClear, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.cmdStockItem, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optDataType, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Compare Stock Item to Stock Item";
			this.ClientSize = new System.Drawing.Size(558, 485);
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
			this.Name = "frmItem";
			this._cmdClear_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_10.Text = "&Clear";
			this._cmdClear_10.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_10.Location = new System.Drawing.Point(453, 309);
			this._cmdClear_10.TabIndex = 34;
			this._cmdClear_10.TabStop = false;
			this._cmdClear_10.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_10.CausesValidation = true;
			this._cmdClear_10.Enabled = true;
			this._cmdClear_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_10.Name = "_cmdClear_10";
			this._cmdStockItem_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_10.Text = "...";
			this._cmdStockItem_10.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_10.Location = new System.Drawing.Point(414, 309);
			this._cmdStockItem_10.TabIndex = 32;
			this._cmdStockItem_10.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_10.CausesValidation = true;
			this._cmdStockItem_10.Enabled = true;
			this._cmdStockItem_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_10.TabStop = true;
			this._cmdStockItem_10.Name = "_cmdStockItem_10";
			this._cmdClear_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_9.Text = "&Clear";
			this._cmdClear_9.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_9.Location = new System.Drawing.Point(453, 282);
			this._cmdClear_9.TabIndex = 31;
			this._cmdClear_9.TabStop = false;
			this._cmdClear_9.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_9.CausesValidation = true;
			this._cmdClear_9.Enabled = true;
			this._cmdClear_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_9.Name = "_cmdClear_9";
			this._cmdStockItem_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_9.Text = "...";
			this._cmdStockItem_9.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_9.Location = new System.Drawing.Point(414, 282);
			this._cmdStockItem_9.TabIndex = 29;
			this._cmdStockItem_9.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_9.CausesValidation = true;
			this._cmdStockItem_9.Enabled = true;
			this._cmdStockItem_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_9.TabStop = true;
			this._cmdStockItem_9.Name = "_cmdStockItem_9";
			this._cmdClear_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_8.Text = "&Clear";
			this._cmdClear_8.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_8.Location = new System.Drawing.Point(453, 255);
			this._cmdClear_8.TabIndex = 28;
			this._cmdClear_8.TabStop = false;
			this._cmdClear_8.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_8.CausesValidation = true;
			this._cmdClear_8.Enabled = true;
			this._cmdClear_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_8.Name = "_cmdClear_8";
			this._cmdStockItem_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_8.Text = "...";
			this._cmdStockItem_8.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_8.Location = new System.Drawing.Point(414, 255);
			this._cmdStockItem_8.TabIndex = 26;
			this._cmdStockItem_8.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_8.CausesValidation = true;
			this._cmdStockItem_8.Enabled = true;
			this._cmdStockItem_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_8.TabStop = true;
			this._cmdStockItem_8.Name = "_cmdStockItem_8";
			this._cmdClear_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_7.Text = "&Clear";
			this._cmdClear_7.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_7.Location = new System.Drawing.Point(453, 228);
			this._cmdClear_7.TabIndex = 25;
			this._cmdClear_7.TabStop = false;
			this._cmdClear_7.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_7.CausesValidation = true;
			this._cmdClear_7.Enabled = true;
			this._cmdClear_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_7.Name = "_cmdClear_7";
			this._cmdStockItem_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_7.Text = "...";
			this._cmdStockItem_7.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_7.Location = new System.Drawing.Point(414, 228);
			this._cmdStockItem_7.TabIndex = 23;
			this._cmdStockItem_7.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_7.CausesValidation = true;
			this._cmdStockItem_7.Enabled = true;
			this._cmdStockItem_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_7.TabStop = true;
			this._cmdStockItem_7.Name = "_cmdStockItem_7";
			this._cmdClear_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_6.Text = "&Clear";
			this._cmdClear_6.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_6.Location = new System.Drawing.Point(453, 201);
			this._cmdClear_6.TabIndex = 22;
			this._cmdClear_6.TabStop = false;
			this._cmdClear_6.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_6.CausesValidation = true;
			this._cmdClear_6.Enabled = true;
			this._cmdClear_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_6.Name = "_cmdClear_6";
			this._cmdStockItem_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_6.Text = "...";
			this._cmdStockItem_6.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_6.Location = new System.Drawing.Point(414, 201);
			this._cmdStockItem_6.TabIndex = 20;
			this._cmdStockItem_6.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_6.CausesValidation = true;
			this._cmdStockItem_6.Enabled = true;
			this._cmdStockItem_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_6.TabStop = true;
			this._cmdStockItem_6.Name = "_cmdStockItem_6";
			this._cmdClear_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_5.Text = "&Clear";
			this._cmdClear_5.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_5.Location = new System.Drawing.Point(453, 174);
			this._cmdClear_5.TabIndex = 19;
			this._cmdClear_5.TabStop = false;
			this._cmdClear_5.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_5.CausesValidation = true;
			this._cmdClear_5.Enabled = true;
			this._cmdClear_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_5.Name = "_cmdClear_5";
			this._cmdStockItem_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_5.Text = "...";
			this._cmdStockItem_5.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_5.Location = new System.Drawing.Point(414, 174);
			this._cmdStockItem_5.TabIndex = 17;
			this._cmdStockItem_5.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_5.CausesValidation = true;
			this._cmdStockItem_5.Enabled = true;
			this._cmdStockItem_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_5.TabStop = true;
			this._cmdStockItem_5.Name = "_cmdStockItem_5";
			this._cmdClear_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_4.Text = "&Clear";
			this._cmdClear_4.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_4.Location = new System.Drawing.Point(453, 147);
			this._cmdClear_4.TabIndex = 16;
			this._cmdClear_4.TabStop = false;
			this._cmdClear_4.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_4.CausesValidation = true;
			this._cmdClear_4.Enabled = true;
			this._cmdClear_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_4.Name = "_cmdClear_4";
			this._cmdStockItem_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_4.Text = "...";
			this._cmdStockItem_4.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_4.Location = new System.Drawing.Point(414, 147);
			this._cmdStockItem_4.TabIndex = 14;
			this._cmdStockItem_4.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_4.CausesValidation = true;
			this._cmdStockItem_4.Enabled = true;
			this._cmdStockItem_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_4.TabStop = true;
			this._cmdStockItem_4.Name = "_cmdStockItem_4";
			this._cmdClear_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_3.Text = "&Clear";
			this._cmdClear_3.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_3.Location = new System.Drawing.Point(453, 120);
			this._cmdClear_3.TabIndex = 13;
			this._cmdClear_3.TabStop = false;
			this._cmdClear_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_3.CausesValidation = true;
			this._cmdClear_3.Enabled = true;
			this._cmdClear_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_3.Name = "_cmdClear_3";
			this._cmdStockItem_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_3.Text = "...";
			this._cmdStockItem_3.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_3.Location = new System.Drawing.Point(414, 120);
			this._cmdStockItem_3.TabIndex = 11;
			this._cmdStockItem_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_3.CausesValidation = true;
			this._cmdStockItem_3.Enabled = true;
			this._cmdStockItem_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_3.TabStop = true;
			this._cmdStockItem_3.Name = "_cmdStockItem_3";
			this._cmdClear_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_2.Text = "&Clear";
			this._cmdClear_2.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_2.Location = new System.Drawing.Point(453, 93);
			this._cmdClear_2.TabIndex = 10;
			this._cmdClear_2.TabStop = false;
			this._cmdClear_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_2.CausesValidation = true;
			this._cmdClear_2.Enabled = true;
			this._cmdClear_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_2.Name = "_cmdClear_2";
			this._cmdStockItem_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_2.Text = "...";
			this._cmdStockItem_2.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_2.Location = new System.Drawing.Point(414, 93);
			this._cmdStockItem_2.TabIndex = 8;
			this._cmdStockItem_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_2.CausesValidation = true;
			this._cmdStockItem_2.Enabled = true;
			this._cmdStockItem_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_2.TabStop = true;
			this._cmdStockItem_2.Name = "_cmdStockItem_2";
			this._cmdClear_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdClear_1.Text = "&Clear";
			this._cmdClear_1.Size = new System.Drawing.Size(34, 19);
			this._cmdClear_1.Location = new System.Drawing.Point(453, 66);
			this._cmdClear_1.TabIndex = 7;
			this._cmdClear_1.TabStop = false;
			this._cmdClear_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdClear_1.CausesValidation = true;
			this._cmdClear_1.Enabled = true;
			this._cmdClear_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdClear_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdClear_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdClear_1.Name = "_cmdClear_1";
			this._cmdStockItem_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdStockItem_1.Text = "...";
			this._cmdStockItem_1.Size = new System.Drawing.Size(34, 19);
			this._cmdStockItem_1.Location = new System.Drawing.Point(414, 66);
			this._cmdStockItem_1.TabIndex = 5;
			this._cmdStockItem_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdStockItem_1.CausesValidation = true;
			this._cmdStockItem_1.Enabled = true;
			this._cmdStockItem_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdStockItem_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdStockItem_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdStockItem_1.TabStop = true;
			this._cmdStockItem_1.Name = "_cmdStockItem_1";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(79, 31);
			this.cmdExit.Location = new System.Drawing.Point(12, 435);
			this.cmdExit.TabIndex = 4;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "&Load report >>";
			this.cmdLoad.Size = new System.Drawing.Size(79, 31);
			this.cmdLoad.Location = new System.Drawing.Point(468, 435);
			this.cmdLoad.TabIndex = 3;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this._optDataType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_1.Text = "Sales Value";
			this._optDataType_1.Size = new System.Drawing.Size(145, 13);
			this._optDataType_1.Location = new System.Drawing.Point(318, 453);
			this._optDataType_1.TabIndex = 2;
			this._optDataType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_1.BackColor = System.Drawing.SystemColors.Control;
			this._optDataType_1.CausesValidation = true;
			this._optDataType_1.Enabled = true;
			this._optDataType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDataType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDataType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDataType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDataType_1.TabStop = true;
			this._optDataType_1.Checked = false;
			this._optDataType_1.Visible = true;
			this._optDataType_1.Name = "_optDataType_1";
			this._optDataType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_0.Text = "Sales Quantity";
			this._optDataType_0.Size = new System.Drawing.Size(145, 13);
			this._optDataType_0.Location = new System.Drawing.Point(318, 435);
			this._optDataType_0.TabIndex = 1;
			this._optDataType_0.Checked = true;
			this._optDataType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDataType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optDataType_0.CausesValidation = true;
			this._optDataType_0.Enabled = true;
			this._optDataType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optDataType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optDataType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDataType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDataType_0.TabStop = true;
			this._optDataType_0.Visible = true;
			this._optDataType_0.Name = "_optDataType_0";
			this._lbl_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_11.Text = "1&0";
			this._lbl_11.Size = new System.Drawing.Size(17, 13);
			this._lbl_11.Location = new System.Drawing.Point(9, 312);
			this._lbl_11.TabIndex = 44;
			this._lbl_11.BackColor = System.Drawing.Color.Transparent;
			this._lbl_11.Enabled = true;
			this._lbl_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_11.UseMnemonic = true;
			this._lbl_11.Visible = true;
			this._lbl_11.AutoSize = false;
			this._lbl_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_11.Name = "_lbl_11";
			this._lbl_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_10.Text = "&9";
			this._lbl_10.Size = new System.Drawing.Size(17, 13);
			this._lbl_10.Location = new System.Drawing.Point(9, 285);
			this._lbl_10.TabIndex = 43;
			this._lbl_10.BackColor = System.Drawing.Color.Transparent;
			this._lbl_10.Enabled = true;
			this._lbl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_10.UseMnemonic = true;
			this._lbl_10.Visible = true;
			this._lbl_10.AutoSize = false;
			this._lbl_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_10.Name = "_lbl_10";
			this._lbl_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_9.Text = "&8";
			this._lbl_9.Size = new System.Drawing.Size(17, 13);
			this._lbl_9.Location = new System.Drawing.Point(9, 258);
			this._lbl_9.TabIndex = 42;
			this._lbl_9.BackColor = System.Drawing.Color.Transparent;
			this._lbl_9.Enabled = true;
			this._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_9.UseMnemonic = true;
			this._lbl_9.Visible = true;
			this._lbl_9.AutoSize = false;
			this._lbl_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_9.Name = "_lbl_9";
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_8.Text = "&7";
			this._lbl_8.Size = new System.Drawing.Size(17, 13);
			this._lbl_8.Location = new System.Drawing.Point(9, 231);
			this._lbl_8.TabIndex = 41;
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Enabled = true;
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.UseMnemonic = true;
			this._lbl_8.Visible = true;
			this._lbl_8.AutoSize = false;
			this._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_8.Name = "_lbl_8";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "&6";
			this._lbl_7.Size = new System.Drawing.Size(17, 13);
			this._lbl_7.Location = new System.Drawing.Point(9, 204);
			this._lbl_7.TabIndex = 40;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = false;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_6.Text = "&5";
			this._lbl_6.Size = new System.Drawing.Size(17, 13);
			this._lbl_6.Location = new System.Drawing.Point(9, 177);
			this._lbl_6.TabIndex = 39;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Enabled = true;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.UseMnemonic = true;
			this._lbl_6.Visible = true;
			this._lbl_6.AutoSize = false;
			this._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_6.Name = "_lbl_6";
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_5.Text = "&4";
			this._lbl_5.Size = new System.Drawing.Size(17, 13);
			this._lbl_5.Location = new System.Drawing.Point(9, 150);
			this._lbl_5.TabIndex = 38;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = false;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "&3";
			this._lbl_4.Size = new System.Drawing.Size(17, 13);
			this._lbl_4.Location = new System.Drawing.Point(9, 123);
			this._lbl_4.TabIndex = 37;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Enabled = true;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = false;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_4.Name = "_lbl_4";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_3.Text = "&2";
			this._lbl_3.Size = new System.Drawing.Size(17, 13);
			this._lbl_3.Location = new System.Drawing.Point(9, 96);
			this._lbl_3.TabIndex = 36;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = false;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "&1";
			this._lbl_2.Size = new System.Drawing.Size(17, 13);
			this._lbl_2.Location = new System.Drawing.Point(9, 69);
			this._lbl_2.TabIndex = 35;
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
			this._lblItem_10.Size = new System.Drawing.Size(382, 19);
			this._lblItem_10.Location = new System.Drawing.Point(30, 309);
			this._lblItem_10.TabIndex = 33;
			this._lblItem_10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_10.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_10.Enabled = true;
			this._lblItem_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_10.UseMnemonic = true;
			this._lblItem_10.Visible = true;
			this._lblItem_10.AutoSize = false;
			this._lblItem_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_10.Name = "_lblItem_10";
			this._lblItem_9.Size = new System.Drawing.Size(382, 19);
			this._lblItem_9.Location = new System.Drawing.Point(30, 282);
			this._lblItem_9.TabIndex = 30;
			this._lblItem_9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_9.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_9.Enabled = true;
			this._lblItem_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_9.UseMnemonic = true;
			this._lblItem_9.Visible = true;
			this._lblItem_9.AutoSize = false;
			this._lblItem_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_9.Name = "_lblItem_9";
			this._lblItem_8.Size = new System.Drawing.Size(382, 19);
			this._lblItem_8.Location = new System.Drawing.Point(30, 255);
			this._lblItem_8.TabIndex = 27;
			this._lblItem_8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_8.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_8.Enabled = true;
			this._lblItem_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_8.UseMnemonic = true;
			this._lblItem_8.Visible = true;
			this._lblItem_8.AutoSize = false;
			this._lblItem_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_8.Name = "_lblItem_8";
			this._lblItem_7.Size = new System.Drawing.Size(382, 19);
			this._lblItem_7.Location = new System.Drawing.Point(30, 228);
			this._lblItem_7.TabIndex = 24;
			this._lblItem_7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_7.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_7.Enabled = true;
			this._lblItem_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_7.UseMnemonic = true;
			this._lblItem_7.Visible = true;
			this._lblItem_7.AutoSize = false;
			this._lblItem_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_7.Name = "_lblItem_7";
			this._lblItem_6.Size = new System.Drawing.Size(382, 19);
			this._lblItem_6.Location = new System.Drawing.Point(30, 201);
			this._lblItem_6.TabIndex = 21;
			this._lblItem_6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_6.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_6.Enabled = true;
			this._lblItem_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_6.UseMnemonic = true;
			this._lblItem_6.Visible = true;
			this._lblItem_6.AutoSize = false;
			this._lblItem_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_6.Name = "_lblItem_6";
			this._lblItem_5.Size = new System.Drawing.Size(382, 19);
			this._lblItem_5.Location = new System.Drawing.Point(30, 174);
			this._lblItem_5.TabIndex = 18;
			this._lblItem_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_5.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_5.Enabled = true;
			this._lblItem_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_5.UseMnemonic = true;
			this._lblItem_5.Visible = true;
			this._lblItem_5.AutoSize = false;
			this._lblItem_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_5.Name = "_lblItem_5";
			this._lblItem_4.Size = new System.Drawing.Size(382, 19);
			this._lblItem_4.Location = new System.Drawing.Point(30, 147);
			this._lblItem_4.TabIndex = 15;
			this._lblItem_4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_4.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_4.Enabled = true;
			this._lblItem_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_4.UseMnemonic = true;
			this._lblItem_4.Visible = true;
			this._lblItem_4.AutoSize = false;
			this._lblItem_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_4.Name = "_lblItem_4";
			this._lblItem_3.Size = new System.Drawing.Size(382, 19);
			this._lblItem_3.Location = new System.Drawing.Point(30, 120);
			this._lblItem_3.TabIndex = 12;
			this._lblItem_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_3.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_3.Enabled = true;
			this._lblItem_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_3.UseMnemonic = true;
			this._lblItem_3.Visible = true;
			this._lblItem_3.AutoSize = false;
			this._lblItem_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_3.Name = "_lblItem_3";
			this._lblItem_2.Size = new System.Drawing.Size(382, 19);
			this._lblItem_2.Location = new System.Drawing.Point(30, 93);
			this._lblItem_2.TabIndex = 9;
			this._lblItem_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_2.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_2.Enabled = true;
			this._lblItem_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_2.UseMnemonic = true;
			this._lblItem_2.Visible = true;
			this._lblItem_2.AutoSize = false;
			this._lblItem_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_2.Name = "_lblItem_2";
			this._lblItem_1.Size = new System.Drawing.Size(382, 19);
			this._lblItem_1.Location = new System.Drawing.Point(30, 66);
			this._lblItem_1.TabIndex = 6;
			this._lblItem_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblItem_1.BackColor = System.Drawing.SystemColors.Control;
			this._lblItem_1.Enabled = true;
			this._lblItem_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblItem_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblItem_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblItem_1.UseMnemonic = true;
			this._lblItem_1.Visible = true;
			this._lblItem_1.AutoSize = false;
			this._lblItem_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblItem_1.Name = "_lblItem_1";
			this._lbl_0.Text = "&1. Select Stock Items";
			this._lbl_0.Size = new System.Drawing.Size(123, 13);
			this._lbl_0.Location = new System.Drawing.Point(9, 9);
			this._lbl_0.TabIndex = 0;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(487, 283);
			this._Shape1_1.Location = new System.Drawing.Point(9, 57);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this.Controls.Add(_cmdClear_10);
			this.Controls.Add(_cmdStockItem_10);
			this.Controls.Add(_cmdClear_9);
			this.Controls.Add(_cmdStockItem_9);
			this.Controls.Add(_cmdClear_8);
			this.Controls.Add(_cmdStockItem_8);
			this.Controls.Add(_cmdClear_7);
			this.Controls.Add(_cmdStockItem_7);
			this.Controls.Add(_cmdClear_6);
			this.Controls.Add(_cmdStockItem_6);
			this.Controls.Add(_cmdClear_5);
			this.Controls.Add(_cmdStockItem_5);
			this.Controls.Add(_cmdClear_4);
			this.Controls.Add(_cmdStockItem_4);
			this.Controls.Add(_cmdClear_3);
			this.Controls.Add(_cmdStockItem_3);
			this.Controls.Add(_cmdClear_2);
			this.Controls.Add(_cmdStockItem_2);
			this.Controls.Add(_cmdClear_1);
			this.Controls.Add(_cmdStockItem_1);
			this.Controls.Add(cmdExit);
			this.Controls.Add(cmdLoad);
			this.Controls.Add(_optDataType_1);
			this.Controls.Add(_optDataType_0);
			this.Controls.Add(_lbl_11);
			this.Controls.Add(_lbl_10);
			this.Controls.Add(_lbl_9);
			this.Controls.Add(_lbl_8);
			this.Controls.Add(_lbl_7);
			this.Controls.Add(_lbl_6);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lblItem_10);
			this.Controls.Add(_lblItem_9);
			this.Controls.Add(_lblItem_8);
			this.Controls.Add(_lblItem_7);
			this.Controls.Add(_lblItem_6);
			this.Controls.Add(_lblItem_5);
			this.Controls.Add(_lblItem_4);
			this.Controls.Add(_lblItem_3);
			this.Controls.Add(_lblItem_2);
			this.Controls.Add(_lblItem_1);
			this.Controls.Add(_lbl_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(ShapeContainer1);
			//Me.cmdClear.SetIndex(_cmdClear_10, CType(10, Short))
			//Me.cmdClear.SetIndex(_cmdClear_9, CType(9, Short))
			//Me.cmdClear.SetIndex(_cmdClear_8, CType(8, Short))
			//Me.cmdClear.SetIndex(_cmdClear_7, CType(7, Short))
			//Me.cmdClear.SetIndex(_cmdClear_6, CType(6, Short))
			//Me.cmdClear.SetIndex(_cmdClear_5, CType(5, Short))
			//Me.cmdClear.SetIndex(_cmdClear_4, CType(4, Short))
			//Me.cmdClear.SetIndex(_cmdClear_3, CType(3, Short))
			//Me.cmdClear.SetIndex(_cmdClear_2, CType(2, Short))
			//Me.cmdClear.SetIndex(_cmdClear_1, CType(1, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_10, CType(10, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_9, CType(9, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_8, CType(8, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_7, CType(7, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_6, CType(6, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_5, CType(5, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_4, CType(4, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_3, CType(3, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_2, CType(2, Short))
			//Me.cmdStockItem.SetIndex(_cmdStockItem_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_11, CType(11, Short))
			//Me.lbl.SetIndex(_lbl_10, CType(10, Short))
			//Me.lbl.SetIndex(_lbl_9, CType(9, Short))
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_6, CType(6, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lblItem.SetIndex(_lblItem_10, CType(10, Short))
			//Me.lblItem.SetIndex(_lblItem_9, CType(9, Short))
			//Me.lblItem.SetIndex(_lblItem_8, CType(8, Short))
			//Me.lblItem.SetIndex(_lblItem_7, CType(7, Short))
			//Me.lblItem.SetIndex(_lblItem_6, CType(6, Short))
			//Me.lblItem.SetIndex(_lblItem_5, CType(5, Short))
			//Me.lblItem.SetIndex(_lblItem_4, CType(4, Short))
			//Me.lblItem.SetIndex(_lblItem_3, CType(3, Short))
			//Me.lblItem.SetIndex(_lblItem_2, CType(2, Short))
			//Me.lblItem.SetIndex(_lblItem_1, CType(1, Short))
			//Me.optDataType.SetIndex(_optDataType_1, CType(1, Short))
			//Me.optDataType.SetIndex(_optDataType_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.optDataType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdStockItem, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdClear, System.ComponentModel.ISupportInitialize).EndInit()
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
