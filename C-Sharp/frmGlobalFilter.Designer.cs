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
	partial class frmGlobalFilter
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGlobalFilter() : base()
		{
			Load += frmGlobalFilter_Load;
			KeyPress += frmGlobalFilter_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_cmdUndo;
		public System.Windows.Forms.Button cmdUndo {
			get { return withEventsField_cmdUndo; }
			set {
				if (withEventsField_cmdUndo != null) {
					withEventsField_cmdUndo.Click -= cmdUndo_Click;
				}
				withEventsField_cmdUndo = value;
				if (withEventsField_cmdUndo != null) {
					withEventsField_cmdUndo.Click += cmdUndo_Click;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkUndoPosOveride;
		public System.Windows.Forms.CheckBox chkUndoPosOveride {
			get { return withEventsField_chkUndoPosOveride; }
			set {
				if (withEventsField_chkUndoPosOveride != null) {
					withEventsField_chkUndoPosOveride.CheckStateChanged -= chkUndoPosOveride_CheckStateChanged;
				}
				withEventsField_chkUndoPosOveride = value;
				if (withEventsField_chkUndoPosOveride != null) {
					withEventsField_chkUndoPosOveride.CheckStateChanged += chkUndoPosOveride_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame3;
		private System.Windows.Forms.Button withEventsField_Command2;
		public System.Windows.Forms.Button Command2 {
			get { return withEventsField_Command2; }
			set {
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click -= Command2_Click;
				}
				withEventsField_Command2 = value;
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click += Command2_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
				}
			}
		}
		public System.Windows.Forms.CheckBox chkDiscontinued;
		public System.Windows.Forms.CheckBox chkDisable;
		public System.Windows.Forms.RadioButton _OprBarcode_1;
		public System.Windows.Forms.RadioButton _OprBarcode_0;
		public System.Windows.Forms.RadioButton _OprBarcode_2;
		private System.Windows.Forms.CheckBox withEventsField_chkSerialTracking;
		public System.Windows.Forms.CheckBox chkSerialTracking {
			get { return withEventsField_chkSerialTracking; }
			set {
				if (withEventsField_chkSerialTracking != null) {
					withEventsField_chkSerialTracking.CheckStateChanged -= chkSerialTracking_CheckStateChanged;
				}
				withEventsField_chkSerialTracking = value;
				if (withEventsField_chkSerialTracking != null) {
					withEventsField_chkSerialTracking.CheckStateChanged += chkSerialTracking_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkPosOveride;
		public System.Windows.Forms.CheckBox chkPosOveride {
			get { return withEventsField_chkPosOveride; }
			set {
				if (withEventsField_chkPosOveride != null) {
					withEventsField_chkPosOveride.CheckStateChanged -= chkPosOveride_CheckStateChanged;
				}
				withEventsField_chkPosOveride = value;
				if (withEventsField_chkPosOveride != null) {
					withEventsField_chkPosOveride.CheckStateChanged += chkPosOveride_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkAllowFractions;
		public System.Windows.Forms.CheckBox chkAllowFractions {
			get { return withEventsField_chkAllowFractions; }
			set {
				if (withEventsField_chkAllowFractions != null) {
					withEventsField_chkAllowFractions.CheckStateChanged -= chkAllowFractions_CheckStateChanged;
				}
				withEventsField_chkAllowFractions = value;
				if (withEventsField_chkAllowFractions != null) {
					withEventsField_chkAllowFractions.CheckStateChanged += chkAllowFractions_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkNonWeigted;
		public System.Windows.Forms.CheckBox chkNonWeigted {
			get { return withEventsField_chkNonWeigted; }
			set {
				if (withEventsField_chkNonWeigted != null) {
					withEventsField_chkNonWeigted.CheckStateChanged -= chkNonWeigted_CheckStateChanged;
				}
				withEventsField_chkNonWeigted = value;
				if (withEventsField_chkNonWeigted != null) {
					withEventsField_chkNonWeigted.CheckStateChanged += chkNonWeigted_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkScale;
		public System.Windows.Forms.CheckBox chkScale {
			get { return withEventsField_chkScale; }
			set {
				if (withEventsField_chkScale != null) {
					withEventsField_chkScale.CheckStateChanged -= chkScale_CheckStateChanged;
				}
				withEventsField_chkScale = value;
				if (withEventsField_chkScale != null) {
					withEventsField_chkScale.CheckStateChanged += chkScale_CheckStateChanged;
				}
			}
		}
		private myDataGridView withEventsField_cmbUpPrinting;
		public myDataGridView cmbUpPrinting {
			get { return withEventsField_cmbUpPrinting; }
			set {
				if (withEventsField_cmbUpPrinting != null) {
					withEventsField_cmbUpPrinting.CellValueChanged -= cmbUpPrinting_Change;
				}
				withEventsField_cmbUpPrinting = value;
				if (withEventsField_cmbUpPrinting != null) {
					withEventsField_cmbUpPrinting.CellValueChanged += cmbUpPrinting_Change;
				}
			}
		}
		private myDataGridView withEventsField_cmpUpSupplier;
		public myDataGridView cmpUpSupplier {
			get { return withEventsField_cmpUpSupplier; }
			set {
				if (withEventsField_cmpUpSupplier != null) {
					withEventsField_cmpUpSupplier.CellValueChanged -= cmpUpSupplier_Change;
				}
				withEventsField_cmpUpSupplier = value;
				if (withEventsField_cmpUpSupplier != null) {
					withEventsField_cmpUpSupplier.CellValueChanged += cmpUpSupplier_Change;
				}
			}
		}
		private myDataGridView withEventsField_cmbUpPricing;
		public myDataGridView cmbUpPricing {
			get { return withEventsField_cmbUpPricing; }
			set {
				if (withEventsField_cmbUpPricing != null) {
					withEventsField_cmbUpPricing.CellValueChanged -= cmbUpPricing_Change;
				}
				withEventsField_cmbUpPricing = value;
				if (withEventsField_cmbUpPricing != null) {
					withEventsField_cmbUpPricing.CellValueChanged += cmbUpPricing_Change;
				}
			}
		}
		private myDataGridView withEventsField_cmbReportGroups;
		public myDataGridView cmbReportGroups {
			get { return withEventsField_cmbReportGroups; }
			set {
				if (withEventsField_cmbReportGroups != null) {
					withEventsField_cmbReportGroups.CellValueChanged -= cmbReportGroups_Change;
				}
				withEventsField_cmbReportGroups = value;
				if (withEventsField_cmbReportGroups != null) {
					withEventsField_cmbReportGroups.CellValueChanged += cmbReportGroups_Change;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line3;
		public System.Windows.Forms.Label Label4;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line2;
		public System.Windows.Forms.Label Label3;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.Button withEventsField_Command3;
		public System.Windows.Forms.Button Command3 {
			get { return withEventsField_Command3; }
			set {
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click -= Command3_Click;
				}
				withEventsField_Command3 = value;
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click += Command3_Click;
				}
			}
		}
		public System.Windows.Forms.Label lblChanges;
		public System.Windows.Forms.Label lblHeading;
		public System.Windows.Forms.GroupBox Frame1;
		//Public WithEvents OprBarcode As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.Line3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Line2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this.cmdUndo = new System.Windows.Forms.Button();
			this.chkUndoPosOveride = new System.Windows.Forms.CheckBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Command2 = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.chkDiscontinued = new System.Windows.Forms.CheckBox();
			this.chkDisable = new System.Windows.Forms.CheckBox();
			this._OprBarcode_1 = new System.Windows.Forms.RadioButton();
			this._OprBarcode_0 = new System.Windows.Forms.RadioButton();
			this._OprBarcode_2 = new System.Windows.Forms.RadioButton();
			this.chkSerialTracking = new System.Windows.Forms.CheckBox();
			this.chkPosOveride = new System.Windows.Forms.CheckBox();
			this.chkAllowFractions = new System.Windows.Forms.CheckBox();
			this.chkNonWeigted = new System.Windows.Forms.CheckBox();
			this.chkScale = new System.Windows.Forms.CheckBox();
			this.cmbUpPrinting = new _4PosBackOffice.NET.myDataGridView();
			this.cmpUpSupplier = new _4PosBackOffice.NET.myDataGridView();
			this.cmbUpPricing = new _4PosBackOffice.NET.myDataGridView();
			this.cmbReportGroups = new _4PosBackOffice.NET.myDataGridView();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.Command3 = new System.Windows.Forms.Button();
			this.lblChanges = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this.Frame3.SuspendLayout();
			this.picButtons.SuspendLayout();
			this.Frame2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.cmbUpPrinting).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmpUpSupplier).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbUpPricing).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbReportGroups).BeginInit();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 13);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this.Line3,
				this.Line2,
				this.Line1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(441, 312);
			this.ShapeContainer1.TabIndex = 28;
			this.ShapeContainer1.TabStop = false;
			//
			//Line3
			//
			this.Line3.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line3.BorderWidth = 2;
			this.Line3.Name = "Line3";
			this.Line3.X1 = 6;
			this.Line3.X2 = 432;
			this.Line3.Y1 = 251;
			this.Line3.Y2 = 251;
			//
			//Line2
			//
			this.Line2.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line2.BorderWidth = 2;
			this.Line2.Name = "Line2";
			this.Line2.X1 = 8;
			this.Line2.X2 = 434;
			this.Line2.Y1 = 96;
			this.Line2.Y2 = 96;
			//
			//Line1
			//
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderWidth = 2;
			this.Line1.Name = "Line1";
			this.Line1.X1 = 6;
			this.Line1.X2 = 434;
			this.Line1.Y1 = 139;
			this.Line1.Y2 = 139;
			//
			//Frame3
			//
			this.Frame3.BackColor = System.Drawing.SystemColors.Control;
			this.Frame3.Controls.Add(this.cmdUndo);
			this.Frame3.Controls.Add(this.chkUndoPosOveride);
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(6, 496);
			this.Frame3.Name = "Frame3";
			this.Frame3.Padding = new System.Windows.Forms.Padding(0);
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(441, 49);
			this.Frame3.TabIndex = 28;
			this.Frame3.TabStop = false;
			this.Frame3.Text = "Undo Changes";
			//
			//cmdUndo
			//
			this.cmdUndo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUndo.Location = new System.Drawing.Point(184, 16);
			this.cmdUndo.Name = "cmdUndo";
			this.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUndo.Size = new System.Drawing.Size(95, 27);
			this.cmdUndo.TabIndex = 30;
			this.cmdUndo.Text = "Undo Update";
			this.cmdUndo.UseVisualStyleBackColor = false;
			//
			//chkUndoPosOveride
			//
			this.chkUndoPosOveride.BackColor = System.Drawing.SystemColors.Control;
			this.chkUndoPosOveride.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkUndoPosOveride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkUndoPosOveride.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkUndoPosOveride.Location = new System.Drawing.Point(8, 21);
			this.chkUndoPosOveride.Name = "chkUndoPosOveride";
			this.chkUndoPosOveride.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkUndoPosOveride.Size = new System.Drawing.Size(171, 16);
			this.chkUndoPosOveride.TabIndex = 29;
			this.chkUndoPosOveride.Text = "Undo POS Price Overide (SQ)";
			this.chkUndoPosOveride.UseVisualStyleBackColor = false;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.Command2);
			this.picButtons.Controls.Add(this.Command1);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(452, 38);
			this.picButtons.TabIndex = 20;
			//
			//Command2
			//
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Location = new System.Drawing.Point(360, 4);
			this.Command2.Name = "Command2";
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.Size = new System.Drawing.Size(83, 27);
			this.Command2.TabIndex = 22;
			this.Command2.Text = "&Exit";
			this.Command2.UseVisualStyleBackColor = false;
			//
			//Command1
			//
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(4, 4);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(83, 27);
			this.Command1.TabIndex = 21;
			this.Command1.Text = "Global Cost";
			this.Command1.UseVisualStyleBackColor = false;
			//
			//Frame2
			//
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Controls.Add(this.cmdUpdate);
			this.Frame2.Controls.Add(this.chkDiscontinued);
			this.Frame2.Controls.Add(this.chkDisable);
			this.Frame2.Controls.Add(this._OprBarcode_1);
			this.Frame2.Controls.Add(this._OprBarcode_0);
			this.Frame2.Controls.Add(this._OprBarcode_2);
			this.Frame2.Controls.Add(this.chkSerialTracking);
			this.Frame2.Controls.Add(this.chkPosOveride);
			this.Frame2.Controls.Add(this.chkAllowFractions);
			this.Frame2.Controls.Add(this.chkNonWeigted);
			this.Frame2.Controls.Add(this.chkScale);
			this.Frame2.Controls.Add(this.cmbUpPrinting);
			this.Frame2.Controls.Add(this.cmpUpSupplier);
			this.Frame2.Controls.Add(this.cmbUpPricing);
			this.Frame2.Controls.Add(this.cmbReportGroups);
			this.Frame2.Controls.Add(this.Label1);
			this.Frame2.Controls.Add(this.Label6);
			this.Frame2.Controls.Add(this.Label5);
			this.Frame2.Controls.Add(this.Label4);
			this.Frame2.Controls.Add(this.Label3);
			this.Frame2.Controls.Add(this.ShapeContainer1);
			this.Frame2.Enabled = false;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(6, 166);
			this.Frame2.Name = "Frame2";
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(441, 325);
			this.Frame2.TabIndex = 12;
			this.Frame2.TabStop = false;
			this.Frame2.Text = "Field(s) To Update";
			//
			//cmdUpdate
			//
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Location = new System.Drawing.Point(184, 280);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.Size = new System.Drawing.Size(95, 27);
			this.cmdUpdate.TabIndex = 19;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.UseVisualStyleBackColor = false;
			//
			//chkDiscontinued
			//
			this.chkDiscontinued.BackColor = System.Drawing.SystemColors.Control;
			this.chkDiscontinued.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDiscontinued.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDiscontinued.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDiscontinued.Location = new System.Drawing.Point(348, 272);
			this.chkDiscontinued.Name = "chkDiscontinued";
			this.chkDiscontinued.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDiscontinued.Size = new System.Drawing.Size(83, 17);
			this.chkDiscontinued.TabIndex = 11;
			this.chkDiscontinued.Text = "Discontinued";
			this.chkDiscontinued.UseVisualStyleBackColor = false;
			//
			//chkDisable
			//
			this.chkDisable.BackColor = System.Drawing.SystemColors.Control;
			this.chkDisable.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkDisable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkDisable.Location = new System.Drawing.Point(6, 272);
			this.chkDisable.Name = "chkDisable";
			this.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisable.Size = new System.Drawing.Size(71, 17);
			this.chkDisable.TabIndex = 10;
			this.chkDisable.Text = "Disabled";
			this.chkDisable.UseVisualStyleBackColor = false;
			//
			//_OprBarcode_1
			//
			this._OprBarcode_1.BackColor = System.Drawing.SystemColors.Control;
			this._OprBarcode_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._OprBarcode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OprBarcode_1.Location = new System.Drawing.Point(128, 130);
			this._OprBarcode_1.Name = "_OprBarcode_1";
			this._OprBarcode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OprBarcode_1.Size = new System.Drawing.Size(71, 19);
			this._OprBarcode_1.TabIndex = 7;
			this._OprBarcode_1.TabStop = true;
			this._OprBarcode_1.Text = "Barcode";
			this._OprBarcode_1.UseVisualStyleBackColor = false;
			//
			//_OprBarcode_0
			//
			this._OprBarcode_0.BackColor = System.Drawing.SystemColors.Control;
			this._OprBarcode_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._OprBarcode_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OprBarcode_0.Location = new System.Drawing.Point(6, 130);
			this._OprBarcode_0.Name = "_OprBarcode_0";
			this._OprBarcode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OprBarcode_0.Size = new System.Drawing.Size(69, 19);
			this._OprBarcode_0.TabIndex = 6;
			this._OprBarcode_0.TabStop = true;
			this._OprBarcode_0.Text = "Shelf";
			this._OprBarcode_0.UseVisualStyleBackColor = false;
			//
			//_OprBarcode_2
			//
			this._OprBarcode_2.BackColor = System.Drawing.SystemColors.Control;
			this._OprBarcode_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._OprBarcode_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OprBarcode_2.Location = new System.Drawing.Point(252, 130);
			this._OprBarcode_2.Name = "_OprBarcode_2";
			this._OprBarcode_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OprBarcode_2.Size = new System.Drawing.Size(47, 19);
			this._OprBarcode_2.TabIndex = 5;
			this._OprBarcode_2.TabStop = true;
			this._OprBarcode_2.Text = "None";
			this._OprBarcode_2.UseVisualStyleBackColor = false;
			//
			//chkSerialTracking
			//
			this.chkSerialTracking.BackColor = System.Drawing.SystemColors.Control;
			this.chkSerialTracking.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSerialTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSerialTracking.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSerialTracking.Location = new System.Drawing.Point(8, 86);
			this.chkSerialTracking.Name = "chkSerialTracking";
			this.chkSerialTracking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSerialTracking.Size = new System.Drawing.Size(211, 21);
			this.chkSerialTracking.TabIndex = 4;
			this.chkSerialTracking.Text = "Serial Tracking ";
			this.chkSerialTracking.UseVisualStyleBackColor = false;
			//
			//chkPosOveride
			//
			this.chkPosOveride.BackColor = System.Drawing.SystemColors.Control;
			this.chkPosOveride.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPosOveride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkPosOveride.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkPosOveride.Location = new System.Drawing.Point(8, 68);
			this.chkPosOveride.Name = "chkPosOveride";
			this.chkPosOveride.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPosOveride.Size = new System.Drawing.Size(211, 21);
			this.chkPosOveride.TabIndex = 3;
			this.chkPosOveride.Text = "POS Price Overide (SQ)";
			this.chkPosOveride.UseVisualStyleBackColor = false;
			//
			//chkAllowFractions
			//
			this.chkAllowFractions.BackColor = System.Drawing.SystemColors.Control;
			this.chkAllowFractions.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkAllowFractions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkAllowFractions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkAllowFractions.Location = new System.Drawing.Point(8, 52);
			this.chkAllowFractions.Name = "chkAllowFractions";
			this.chkAllowFractions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowFractions.Size = new System.Drawing.Size(211, 20);
			this.chkAllowFractions.TabIndex = 2;
			this.chkAllowFractions.Text = "Allow Fractions";
			this.chkAllowFractions.UseVisualStyleBackColor = false;
			//
			//chkNonWeigted
			//
			this.chkNonWeigted.BackColor = System.Drawing.SystemColors.Control;
			this.chkNonWeigted.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkNonWeigted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkNonWeigted.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkNonWeigted.Location = new System.Drawing.Point(8, 34);
			this.chkNonWeigted.Name = "chkNonWeigted";
			this.chkNonWeigted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkNonWeigted.Size = new System.Drawing.Size(211, 17);
			this.chkNonWeigted.TabIndex = 1;
			this.chkNonWeigted.Text = "This is a scale item Non-Weigted";
			this.chkNonWeigted.UseVisualStyleBackColor = false;
			//
			//chkScale
			//
			this.chkScale.BackColor = System.Drawing.SystemColors.Control;
			this.chkScale.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkScale.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkScale.Location = new System.Drawing.Point(8, 16);
			this.chkScale.Name = "chkScale";
			this.chkScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkScale.Size = new System.Drawing.Size(211, 18);
			this.chkScale.TabIndex = 0;
			this.chkScale.Text = "This Is a Scale Product ";
			this.chkScale.UseVisualStyleBackColor = false;
			//
			//cmbUpPrinting
			//
			this.cmbUpPrinting.AllowAddNew = true;
			this.cmbUpPrinting.BoundText = "";
			this.cmbUpPrinting.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbUpPrinting.Col = 0;
			this.cmbUpPrinting.CtlText = "";
			this.cmbUpPrinting.DataField = null;
			this.cmbUpPrinting.Location = new System.Drawing.Point(156, 210);
			this.cmbUpPrinting.Name = "cmbUpPrinting";
			this.cmbUpPrinting.row = 0;
			this.cmbUpPrinting.Size = new System.Drawing.Size(275, 21);
			this.cmbUpPrinting.TabIndex = 8;
			this.cmbUpPrinting.TopRow = 0;
			//
			//cmpUpSupplier
			//
			this.cmpUpSupplier.AllowAddNew = true;
			this.cmpUpSupplier.BoundText = "";
			this.cmpUpSupplier.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmpUpSupplier.Col = 0;
			this.cmpUpSupplier.CtlText = "";
			this.cmpUpSupplier.DataField = null;
			this.cmpUpSupplier.Location = new System.Drawing.Point(156, 162);
			this.cmpUpSupplier.Name = "cmpUpSupplier";
			this.cmpUpSupplier.row = 0;
			this.cmpUpSupplier.Size = new System.Drawing.Size(275, 21);
			this.cmpUpSupplier.TabIndex = 15;
			this.cmpUpSupplier.TopRow = 0;
			//
			//cmbUpPricing
			//
			this.cmbUpPricing.AllowAddNew = true;
			this.cmbUpPricing.BoundText = "";
			this.cmbUpPricing.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbUpPricing.Col = 0;
			this.cmbUpPricing.CtlText = "";
			this.cmbUpPricing.DataField = null;
			this.cmbUpPricing.Location = new System.Drawing.Point(156, 186);
			this.cmbUpPricing.Name = "cmbUpPricing";
			this.cmbUpPricing.row = 0;
			this.cmbUpPricing.Size = new System.Drawing.Size(275, 21);
			this.cmbUpPricing.TabIndex = 17;
			this.cmbUpPricing.TopRow = 0;
			//
			//cmbReportGroups
			//
			this.cmbReportGroups.AllowAddNew = true;
			this.cmbReportGroups.BoundText = "";
			this.cmbReportGroups.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbReportGroups.Col = 0;
			this.cmbReportGroups.CtlText = "";
			this.cmbReportGroups.DataField = null;
			this.cmbReportGroups.Location = new System.Drawing.Point(156, 234);
			this.cmbReportGroups.Name = "cmbReportGroups";
			this.cmbReportGroups.row = 0;
			this.cmbReportGroups.Size = new System.Drawing.Size(275, 21);
			this.cmbReportGroups.TabIndex = 26;
			this.cmbReportGroups.TopRow = 0;
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(38, 238);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(113, 13);
			this.Label1.TabIndex = 27;
			this.Label1.Text = "Report Groups:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label6
			//
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Location = new System.Drawing.Point(38, 164);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(113, 17);
			this.Label6.TabIndex = 18;
			this.Label6.Text = "New Supplier :";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label5
			//
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Location = new System.Drawing.Point(38, 188);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(113, 17);
			this.Label5.TabIndex = 16;
			this.Label5.Text = "New Pricing Group :";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Label4
			//
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(8, 112);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(147, 13);
			this.Label4.TabIndex = 14;
			this.Label4.Text = "Shelf && Barcode Printing";
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(38, 214);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(113, 13);
			this.Label3.TabIndex = 13;
			this.Label3.Text = "New Printing Location :";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//Frame1
			//
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Controls.Add(this.Command3);
			this.Frame1.Controls.Add(this.lblChanges);
			this.Frame1.Controls.Add(this.lblHeading);
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(6, 44);
			this.Frame1.Name = "Frame1";
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(441, 119);
			this.Frame1.TabIndex = 9;
			this.Frame1.TabStop = false;
			this.Frame1.Text = "1. Filter";
			//
			//Command3
			//
			this.Command3.BackColor = System.Drawing.SystemColors.Control;
			this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command3.Location = new System.Drawing.Point(356, 16);
			this.Command3.Name = "Command3";
			this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command3.Size = new System.Drawing.Size(79, 37);
			this.Command3.TabIndex = 23;
			this.Command3.Text = "Filter";
			this.Command3.UseVisualStyleBackColor = false;
			//
			//lblChanges
			//
			this.lblChanges.BackColor = System.Drawing.SystemColors.Window;
			this.lblChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblChanges.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblChanges.ForeColor = System.Drawing.Color.Red;
			this.lblChanges.Location = new System.Drawing.Point(12, 94);
			this.lblChanges.Name = "lblChanges";
			this.lblChanges.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblChanges.Size = new System.Drawing.Size(339, 19);
			this.lblChanges.TabIndex = 25;
			this.lblChanges.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			//
			//lblHeading
			//
			this.lblHeading.BackColor = System.Drawing.SystemColors.Control;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblHeading.Location = new System.Drawing.Point(12, 16);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.Size = new System.Drawing.Size(339, 76);
			this.lblHeading.TabIndex = 24;
			this.lblHeading.Text = "Using the \"Stock Item Selector\" .....";
			//
			//frmGlobalFilter
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(452, 545);
			this.ControlBox = false;
			this.Controls.Add(this.Frame3);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.Frame2);
			this.Controls.Add(this.Frame1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(128)));
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "frmGlobalFilter";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Global Update";
			this.Frame3.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.cmbUpPrinting).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmpUpSupplier).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbUpPricing).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbReportGroups).EndInit();
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
