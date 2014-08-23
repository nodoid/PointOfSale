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
	partial class frmOrder
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrder() : base()
		{
			FormClosed += frmOrder_FormClosed;
			Load += frmOrder_Load;
			KeyPress += frmOrder_KeyPress;
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
		public System.Windows.Forms.Button _cmdInformation_1;
		public System.Windows.Forms.Button _cmdInformation_0;
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
		private System.Windows.Forms.Button withEventsField_cmdBack;
		public System.Windows.Forms.Button cmdBack {
			get { return withEventsField_cmdBack; }
			set {
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click -= cmdBack_Click;
				}
				withEventsField_cmdBack = value;
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click += cmdBack_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdBlank;
		public System.Windows.Forms.Button cmdBlank {
			get { return withEventsField_cmdBlank; }
			set {
				if (withEventsField_cmdBlank != null) {
					withEventsField_cmdBlank.Click -= cmdBlank_Click;
				}
				withEventsField_cmdBlank = value;
				if (withEventsField_cmdBlank != null) {
					withEventsField_cmdBlank.Click += cmdBlank_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAuto;
		public System.Windows.Forms.Button cmdAuto {
			get { return withEventsField_cmdAuto; }
			set {
				if (withEventsField_cmdAuto != null) {
					withEventsField_cmdAuto.Click -= cmdAuto_Click;
				}
				withEventsField_cmdAuto = value;
				if (withEventsField_cmdAuto != null) {
					withEventsField_cmdAuto.Click += cmdAuto_Click;
				}
			}
		}
		public System.Windows.Forms.Label _lblData_7;
		public System.Windows.Forms.Label _lblData_6;
		public System.Windows.Forms.Label _lblData_5;
		public System.Windows.Forms.Label _lblLabels_36;
		public System.Windows.Forms.Label _lblLabels_37;
		public System.Windows.Forms.Label _lblLabels_38;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblData_0;
		public System.Windows.Forms.Label _lblData_1;
		public System.Windows.Forms.Label _lblData_2;
		public System.Windows.Forms.Label _lblData_3;
		public System.Windows.Forms.Label _lblData_4;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.GroupBox _frmMode_1;
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
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.GroupBox _frmMode_0;
		//Public WithEvents cmdInformation As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblData As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public OvalShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrder));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._cmdInformation_1 = new System.Windows.Forms.Button();
			this._cmdInformation_0 = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdBlank = new System.Windows.Forms.Button();
			this.cmdAuto = new System.Windows.Forms.Button();
			this._lblData_7 = new System.Windows.Forms.Label();
			this._lblData_6 = new System.Windows.Forms.Label();
			this._lblData_5 = new System.Windows.Forms.Label();
			this._lblLabels_36 = new System.Windows.Forms.Label();
			this._lblLabels_37 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblData_0 = new System.Windows.Forms.Label();
			this._lblData_1 = new System.Windows.Forms.Label();
			this._lblData_2 = new System.Windows.Forms.Label();
			this._lblData_3 = new System.Windows.Forms.Label();
			this._lblData_4 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._frmMode_0 = new System.Windows.Forms.GroupBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.DataList1 = new myDataGridView();
			this._lbl_0 = new System.Windows.Forms.Label();
			//Me.cmdInformation = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblData = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new OvalShapeArray(components);
			this._frmMode_1.SuspendLayout();
			this._frmMode_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.DataList1).BeginInit();
			//CType(Me.cmdInformation, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Create / Amend an Order";
			this.ClientSize = new System.Drawing.Size(362, 472);
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
			this.Name = "frmOrder";
			this._cmdInformation_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdInformation_1.Text = "Order Information Report(*)";
			this._cmdInformation_1.Size = new System.Drawing.Size(166, 31);
			this._cmdInformation_1.Location = new System.Drawing.Point(186, 6);
			this._cmdInformation_1.TabIndex = 28;
			this._cmdInformation_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdInformation_1.CausesValidation = true;
			this._cmdInformation_1.Enabled = true;
			this._cmdInformation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdInformation_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdInformation_1.TabStop = true;
			this._cmdInformation_1.Name = "_cmdInformation_1";
			this._cmdInformation_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdInformation_0.Text = "Order Information Report";
			this._cmdInformation_0.Size = new System.Drawing.Size(166, 31);
			this._cmdInformation_0.Location = new System.Drawing.Point(6, 6);
			this._cmdInformation_0.TabIndex = 27;
			this._cmdInformation_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdInformation_0.CausesValidation = true;
			this._cmdInformation_0.Enabled = true;
			this._cmdInformation_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdInformation_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdInformation_0.TabStop = true;
			this._cmdInformation_0.Name = "_cmdInformation_0";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Size = new System.Drawing.Size(97, 34);
			this.cmdNext.Location = new System.Drawing.Point(246, 435);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Size = new System.Drawing.Size(97, 34);
			this.cmdBack.Location = new System.Drawing.Point(15, 435);
			this.cmdBack.TabIndex = 0;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this._frmMode_1.Text = "Select a supplier to transact with.";
			this._frmMode_1.Size = new System.Drawing.Size(346, 379);
			this._frmMode_1.Location = new System.Drawing.Point(6, 45);
			this._frmMode_1.TabIndex = 6;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Enabled = true;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Visible = true;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "&Edit Current Order";
			this.cmdEdit.Size = new System.Drawing.Size(97, 52);
			this.cmdEdit.Location = new System.Drawing.Point(9, 318);
			this.cmdEdit.TabIndex = 29;
			this.cmdEdit.TabStop = false;
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdBlank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBlank.Text = "&Create a Blank Order";
			this.cmdBlank.Size = new System.Drawing.Size(97, 52);
			this.cmdBlank.Location = new System.Drawing.Point(126, 318);
			this.cmdBlank.TabIndex = 26;
			this.cmdBlank.TabStop = false;
			this.cmdBlank.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBlank.CausesValidation = true;
			this.cmdBlank.Enabled = true;
			this.cmdBlank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBlank.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBlank.Name = "cmdBlank";
			this.cmdAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAuto.Text = "Create &Recommended Order";
			this.cmdAuto.Size = new System.Drawing.Size(97, 52);
			this.cmdAuto.Location = new System.Drawing.Point(240, 318);
			this.cmdAuto.TabIndex = 25;
			this.cmdAuto.TabStop = false;
			this.cmdAuto.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAuto.CausesValidation = true;
			this.cmdAuto.Enabled = true;
			this.cmdAuto.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAuto.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAuto.Name = "cmdAuto";
			this._lblData_7.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_7.Text = "Supplier_ShippingCode";
			this._lblData_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_7.Size = new System.Drawing.Size(190, 16);
			this._lblData_7.Location = new System.Drawing.Point(141, 267);
			this._lblData_7.TabIndex = 24;
			this._lblData_7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_7.Enabled = true;
			this._lblData_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_7.UseMnemonic = true;
			this._lblData_7.Visible = true;
			this._lblData_7.AutoSize = false;
			this._lblData_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_7.Name = "_lblData_7";
			this._lblData_6.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_6.Text = "Supplier_RepresentativeNumber";
			this._lblData_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_6.Size = new System.Drawing.Size(190, 16);
			this._lblData_6.Location = new System.Drawing.Point(141, 249);
			this._lblData_6.TabIndex = 23;
			this._lblData_6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_6.Enabled = true;
			this._lblData_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_6.UseMnemonic = true;
			this._lblData_6.Visible = true;
			this._lblData_6.AutoSize = false;
			this._lblData_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_6.Name = "_lblData_6";
			this._lblData_5.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_5.Text = "Supplier_RepresentativeName";
			this._lblData_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_5.Size = new System.Drawing.Size(190, 16);
			this._lblData_5.Location = new System.Drawing.Point(141, 231);
			this._lblData_5.TabIndex = 22;
			this._lblData_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_5.Enabled = true;
			this._lblData_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_5.UseMnemonic = true;
			this._lblData_5.Visible = true;
			this._lblData_5.AutoSize = false;
			this._lblData_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_5.Name = "_lblData_5";
			this._lblLabels_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_36.Text = "Account Number:";
			this._lblLabels_36.Size = new System.Drawing.Size(83, 13);
			this._lblLabels_36.Location = new System.Drawing.Point(50, 267);
			this._lblLabels_36.TabIndex = 21;
			this._lblLabels_36.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_36.Enabled = true;
			this._lblLabels_36.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_36.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_36.UseMnemonic = true;
			this._lblLabels_36.Visible = true;
			this._lblLabels_36.AutoSize = true;
			this._lblLabels_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_36.Name = "_lblLabels_36";
			this._lblLabels_37.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_37.Text = "Representative Number:";
			this._lblLabels_37.Size = new System.Drawing.Size(115, 13);
			this._lblLabels_37.Location = new System.Drawing.Point(18, 248);
			this._lblLabels_37.TabIndex = 20;
			this._lblLabels_37.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_37.Enabled = true;
			this._lblLabels_37.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_37.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_37.UseMnemonic = true;
			this._lblLabels_37.Visible = true;
			this._lblLabels_37.AutoSize = true;
			this._lblLabels_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_37.Name = "_lblLabels_37";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_38.Text = "Representative Name:";
			this._lblLabels_38.Size = new System.Drawing.Size(106, 13);
			this._lblLabels_38.Location = new System.Drawing.Point(27, 230);
			this._lblLabels_38.TabIndex = 19;
			this._lblLabels_38.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_38.Enabled = true;
			this._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_38.UseMnemonic = true;
			this._lblLabels_38.Visible = true;
			this._lblLabels_38.AutoSize = true;
			this._lblLabels_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_38.Name = "_lblLabels_38";
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "&2. Ordering Details";
			this._lbl_2.Size = new System.Drawing.Size(107, 13);
			this._lbl_2.Location = new System.Drawing.Point(9, 207);
			this._lbl_2.TabIndex = 18;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&1. General";
			this._lbl_1.Size = new System.Drawing.Size(61, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 18);
			this._lbl_1.TabIndex = 17;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "Supplier Name:";
			this._lblLabels_2.Size = new System.Drawing.Size(87, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(13, 39);
			this._lblLabels_2.TabIndex = 16;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_6.Text = "Physical Address:";
			this._lblLabels_6.Size = new System.Drawing.Size(94, 13);
			this._lblLabels_6.Location = new System.Drawing.Point(6, 78);
			this._lblLabels_6.TabIndex = 15;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Enabled = true;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.UseMnemonic = true;
			this._lblLabels_6.Visible = true;
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.Text = "Postal Address:";
			this._lblLabels_7.Size = new System.Drawing.Size(76, 13);
			this._lblLabels_7.Location = new System.Drawing.Point(24, 138);
			this._lblLabels_7.TabIndex = 14;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Enabled = true;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.UseMnemonic = true;
			this._lblLabels_7.Visible = true;
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(42, 57);
			this._lblLabels_8.TabIndex = 13;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Enabled = true;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.UseMnemonic = true;
			this._lblLabels_8.Visible = true;
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_9.Text = "Fax:";
			this._lblLabels_9.Size = new System.Drawing.Size(22, 13);
			this._lblLabels_9.Location = new System.Drawing.Point(210, 57);
			this._lblLabels_9.TabIndex = 12;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Enabled = true;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.UseMnemonic = true;
			this._lblLabels_9.Visible = true;
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblData_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_0.Text = "Supplier_Name";
			this._lblData_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_0.Size = new System.Drawing.Size(226, 16);
			this._lblData_0.Location = new System.Drawing.Point(105, 39);
			this._lblData_0.TabIndex = 11;
			this._lblData_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_0.Enabled = true;
			this._lblData_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_0.UseMnemonic = true;
			this._lblData_0.Visible = true;
			this._lblData_0.AutoSize = false;
			this._lblData_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_0.Name = "_lblData_0";
			this._lblData_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_1.Text = "Supplier_Telephone";
			this._lblData_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_1.Size = new System.Drawing.Size(94, 16);
			this._lblData_1.Location = new System.Drawing.Point(105, 57);
			this._lblData_1.TabIndex = 10;
			this._lblData_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_1.Enabled = true;
			this._lblData_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_1.UseMnemonic = true;
			this._lblData_1.Visible = true;
			this._lblData_1.AutoSize = false;
			this._lblData_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_1.Name = "_lblData_1";
			this._lblData_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_2.Text = "Supplier_Facimile";
			this._lblData_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_2.Size = new System.Drawing.Size(94, 16);
			this._lblData_2.Location = new System.Drawing.Point(237, 57);
			this._lblData_2.TabIndex = 9;
			this._lblData_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_2.Enabled = true;
			this._lblData_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_2.UseMnemonic = true;
			this._lblData_2.Visible = true;
			this._lblData_2.AutoSize = false;
			this._lblData_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_2.Name = "_lblData_2";
			this._lblData_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_3.Text = "Supplier_PhysicalAddress";
			this._lblData_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_3.Size = new System.Drawing.Size(226, 58);
			this._lblData_3.Location = new System.Drawing.Point(105, 78);
			this._lblData_3.TabIndex = 8;
			this._lblData_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_3.Enabled = true;
			this._lblData_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_3.UseMnemonic = true;
			this._lblData_3.Visible = true;
			this._lblData_3.AutoSize = false;
			this._lblData_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_3.Name = "_lblData_3";
			this._lblData_4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_4.Text = "Supplier_PostalAddress";
			this._lblData_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_4.Size = new System.Drawing.Size(226, 58);
			this._lblData_4.Location = new System.Drawing.Point(105, 141);
			this._lblData_4.TabIndex = 7;
			this._lblData_4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_4.Enabled = true;
			this._lblData_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_4.UseMnemonic = true;
			this._lblData_4.Visible = true;
			this._lblData_4.AutoSize = false;
			this._lblData_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_4.Name = "_lblData_4";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(328, 172);
			this._Shape1_1.Location = new System.Drawing.Point(9, 20);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(328, 70);
			this._Shape1_2.Location = new System.Drawing.Point(9, 209);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._frmMode_0.Text = "Select a supplier to transact with.";
			this._frmMode_0.Size = new System.Drawing.Size(346, 379);
			this._frmMode_0.Location = new System.Drawing.Point(6, 48);
			this._frmMode_0.TabIndex = 2;
			this._frmMode_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_0.Enabled = true;
			this._frmMode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_0.Visible = true;
			this._frmMode_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_0.Name = "_frmMode_0";
			this.txtSearch.AutoSize = false;
			this.txtSearch.Size = new System.Drawing.Size(283, 19);
			this.txtSearch.Location = new System.Drawing.Point(54, 18);
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
			//'DataList1.OcxState = CType(resources.GetObject("'DataList1.OcxState"), System.Windows.Forms.AxHost.State)
			this.DataList1.Size = new System.Drawing.Size(328, 329);
			this.DataList1.Location = new System.Drawing.Point(9, 42);
			this.DataList1.TabIndex = 4;
			this.DataList1.Name = "DataList1";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "&Search :";
			this._lbl_0.Size = new System.Drawing.Size(40, 13);
			this._lbl_0.Location = new System.Drawing.Point(11, 21);
			this._lbl_0.TabIndex = 5;
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
			this.Controls.Add(_cmdInformation_1);
			this.Controls.Add(_cmdInformation_0);
			this.Controls.Add(cmdNext);
			this.Controls.Add(cmdBack);
			this.Controls.Add(_frmMode_1);
			this.Controls.Add(_frmMode_0);
			this._frmMode_1.Controls.Add(cmdEdit);
			this._frmMode_1.Controls.Add(cmdBlank);
			this._frmMode_1.Controls.Add(cmdAuto);
			this._frmMode_1.Controls.Add(_lblData_7);
			this._frmMode_1.Controls.Add(_lblData_6);
			this._frmMode_1.Controls.Add(_lblData_5);
			this._frmMode_1.Controls.Add(_lblLabels_36);
			this._frmMode_1.Controls.Add(_lblLabels_37);
			this._frmMode_1.Controls.Add(_lblLabels_38);
			this._frmMode_1.Controls.Add(_lbl_2);
			this._frmMode_1.Controls.Add(_lbl_1);
			this._frmMode_1.Controls.Add(_lblLabels_2);
			this._frmMode_1.Controls.Add(_lblLabels_6);
			this._frmMode_1.Controls.Add(_lblLabels_7);
			this._frmMode_1.Controls.Add(_lblLabels_8);
			this._frmMode_1.Controls.Add(_lblLabels_9);
			this._frmMode_1.Controls.Add(_lblData_0);
			this._frmMode_1.Controls.Add(_lblData_1);
			this._frmMode_1.Controls.Add(_lblData_2);
			this._frmMode_1.Controls.Add(_lblData_3);
			this._frmMode_1.Controls.Add(_lblData_4);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this._frmMode_1.Controls.Add(ShapeContainer1);
			this._frmMode_0.Controls.Add(txtSearch);
			this._frmMode_0.Controls.Add(DataList1);
			this._frmMode_0.Controls.Add(_lbl_0);
			//Me.cmdInformation.SetIndex(_cmdInformation_1, CType(1, Short))
			//Me.cmdInformation.SetIndex(_cmdInformation_0, CType(0, Short))
			//Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
			//Me.frmMode.SetIndex(_frmMode_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lblData.SetIndex(_lblData_7, CType(7, Short))
			//Me.lblData.SetIndex(_lblData_6, CType(6, Short))
			//Me.lblData.SetIndex(_lblData_5, CType(5, Short))
			//Me.lblData.SetIndex(_lblData_0, CType(0, Short))
			//Me.lblData.SetIndex(_lblData_1, CType(1, Short))
			//M() ''e.lblData.SetIndex(_lblData_2, CType(2, Short))
			//M() 'e.lblData.SetIndex(_lblData_3, CType(3, Short))
			//Me.lblData.SetIndex(_lblData_4, CType(4, Short))
			//Me.lblLabels.SetIndex(_lblLabels_36, CType(36, Short))
			//Me.lblLabels.SetIndex(_lblLabels_37, CType(37, Short))
			//Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
			//Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdInformation, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.DataList1).EndInit();
			this._frmMode_1.ResumeLayout(false);
			this._frmMode_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
