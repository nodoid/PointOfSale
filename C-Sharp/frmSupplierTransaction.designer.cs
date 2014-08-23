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
	partial class frmSupplierTransaction
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSupplierTransaction() : base()
		{
			FormClosed += frmSupplierTransaction_FormClosed;
			KeyDown += frmSupplierTransaction_KeyDown;
			Resize += frmSupplierTransaction_Resize;
			Load += frmSupplierTransaction_Load;
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
		public System.Windows.Forms.TextBox txtTotalAmount;
		private System.Windows.Forms.TextBox withEventsField_txtSettlement;
		public System.Windows.Forms.TextBox txtSettlement {
			get { return withEventsField_txtSettlement; }
			set {
				if (withEventsField_txtSettlement != null) {
					withEventsField_txtSettlement.Enter -= txtSettlement_Enter;
					withEventsField_txtSettlement.KeyPress -= txtSettlement_KeyPress;
					withEventsField_txtSettlement.Leave -= txtSettlement_Leave;
				}
				withEventsField_txtSettlement = value;
				if (withEventsField_txtSettlement != null) {
					withEventsField_txtSettlement.Enter += txtSettlement_Enter;
					withEventsField_txtSettlement.KeyPress += txtSettlement_KeyPress;
					withEventsField_txtSettlement.Leave += txtSettlement_Leave;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbPeriod;
		private System.Windows.Forms.TextBox withEventsField_txtNarrative;
		public System.Windows.Forms.TextBox txtNarrative {
			get { return withEventsField_txtNarrative; }
			set {
				if (withEventsField_txtNarrative != null) {
					withEventsField_txtNarrative.Enter -= txtNarrative_Enter;
				}
				withEventsField_txtNarrative = value;
				if (withEventsField_txtNarrative != null) {
					withEventsField_txtNarrative.Enter += txtNarrative_Enter;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtNotes;
		public System.Windows.Forms.TextBox txtNotes {
			get { return withEventsField_txtNotes; }
			set {
				if (withEventsField_txtNotes != null) {
					withEventsField_txtNotes.Enter -= txtNotes_Enter;
				}
				withEventsField_txtNotes = value;
				if (withEventsField_txtNotes != null) {
					withEventsField_txtNotes.Enter += txtNotes_Enter;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtAmount;
		public System.Windows.Forms.TextBox txtAmount {
			get { return withEventsField_txtAmount; }
			set {
				if (withEventsField_txtAmount != null) {
					withEventsField_txtAmount.Enter -= txtAmount_Enter;
					withEventsField_txtAmount.KeyPress -= txtAmount_KeyPress;
					withEventsField_txtAmount.Leave -= txtAmount_Leave;
				}
				withEventsField_txtAmount = value;
				if (withEventsField_txtAmount != null) {
					withEventsField_txtAmount.Enter += txtAmount_Enter;
					withEventsField_txtAmount.KeyPress += txtAmount_KeyPress;
					withEventsField_txtAmount.Leave += txtAmount_Leave;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdProcess;
		public System.Windows.Forms.Button cmdProcess {
			get { return withEventsField_cmdProcess; }
			set {
				if (withEventsField_cmdProcess != null) {
					withEventsField_cmdProcess.Click -= cmdProcess_Click;
					withEventsField_cmdProcess.Enter -= cmdProcess_Enter;
				}
				withEventsField_cmdProcess = value;
				if (withEventsField_cmdProcess != null) {
					withEventsField_cmdProcess.Click += cmdProcess_Click;
					withEventsField_cmdProcess.Enter += cmdProcess_Enter;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_6;
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_8;
		public System.Windows.Forms.TextBox _txtFields_9;
		public System.Windows.Forms.TextBox _txtFloat_13;
		public System.Windows.Forms.TextBox _txtFloat_14;
		public System.Windows.Forms.TextBox _txtFloat_15;
		public System.Windows.Forms.TextBox _txtFloat_16;
		public System.Windows.Forms.TextBox _txtFloat_17;
		private System.Windows.Forms.Button withEventsField_cmdStatement;
		public System.Windows.Forms.Button cmdStatement {
			get { return withEventsField_cmdStatement; }
			set {
				if (withEventsField_cmdStatement != null) {
					withEventsField_cmdStatement.Click -= cmdStatement_Click;
				}
				withEventsField_cmdStatement = value;
				if (withEventsField_cmdStatement != null) {
					withEventsField_cmdStatement.Click += cmdStatement_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblSettl;
		public System.Windows.Forms.Label _lblLabels_3;
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_11;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_13;
		public System.Windows.Forms.Label _lblLabels_14;
		public System.Windows.Forms.Label _lblLabels_15;
		public System.Windows.Forms.Label _lblLabels_16;
		public System.Windows.Forms.Label _lblLabels_17;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSupplierTransaction));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.txtTotalAmount = new System.Windows.Forms.TextBox();
			this.txtSettlement = new System.Windows.Forms.TextBox();
			this.cmbPeriod = new System.Windows.Forms.ComboBox();
			this.txtNarrative = new System.Windows.Forms.TextBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.cmdProcess = new System.Windows.Forms.Button();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_6 = new System.Windows.Forms.TextBox();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_8 = new System.Windows.Forms.TextBox();
			this._txtFields_9 = new System.Windows.Forms.TextBox();
			this._txtFloat_13 = new System.Windows.Forms.TextBox();
			this._txtFloat_14 = new System.Windows.Forms.TextBox();
			this._txtFloat_15 = new System.Windows.Forms.TextBox();
			this._txtFloat_16 = new System.Windows.Forms.TextBox();
			this._txtFloat_17 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdStatement = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblSettl = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_11 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_13 = new System.Windows.Forms.Label();
			this._lblLabels_14 = new System.Windows.Forms.Label();
			this._lblLabels_15 = new System.Windows.Forms.Label();
			this._lblLabels_16 = new System.Windows.Forms.Label();
			this._lblLabels_17 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Supplier Transaction";
			this.ClientSize = new System.Drawing.Size(652, 359);
			this.Location = new System.Drawing.Point(73, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmSupplierTransaction";
			this.txtTotalAmount.AutoSize = false;
			this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotalAmount.Size = new System.Drawing.Size(112, 19);
			this.txtTotalAmount.Location = new System.Drawing.Point(448, 318);
			this.txtTotalAmount.TabIndex = 36;
			this.txtTotalAmount.Text = "0.00";
			this.txtTotalAmount.AcceptsReturn = true;
			this.txtTotalAmount.BackColor = System.Drawing.SystemColors.Window;
			this.txtTotalAmount.CausesValidation = true;
			this.txtTotalAmount.Enabled = true;
			this.txtTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTotalAmount.HideSelection = true;
			this.txtTotalAmount.ReadOnly = false;
			this.txtTotalAmount.MaxLength = 0;
			this.txtTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTotalAmount.Multiline = false;
			this.txtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTotalAmount.TabStop = true;
			this.txtTotalAmount.Visible = true;
			this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTotalAmount.Name = "txtTotalAmount";
			this.txtSettlement.AutoSize = false;
			this.txtSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtSettlement.Size = new System.Drawing.Size(112, 19);
			this.txtSettlement.Location = new System.Drawing.Point(448, 296);
			this.txtSettlement.TabIndex = 9;
			this.txtSettlement.Text = "0.00";
			this.txtSettlement.AcceptsReturn = true;
			this.txtSettlement.BackColor = System.Drawing.SystemColors.Window;
			this.txtSettlement.CausesValidation = true;
			this.txtSettlement.Enabled = true;
			this.txtSettlement.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSettlement.HideSelection = true;
			this.txtSettlement.ReadOnly = false;
			this.txtSettlement.MaxLength = 0;
			this.txtSettlement.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSettlement.Multiline = false;
			this.txtSettlement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSettlement.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSettlement.TabStop = true;
			this.txtSettlement.Visible = true;
			this.txtSettlement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSettlement.Name = "txtSettlement";
			this.cmbPeriod.Size = new System.Drawing.Size(232, 21);
			this.cmbPeriod.Location = new System.Drawing.Point(410, 154);
			this.cmbPeriod.Items.AddRange(new object[] {
				"Current",
				"30 Days",
				"60 Days",
				"90 Days",
				"120 Days"
			});
			this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPeriod.TabIndex = 2;
			this.cmbPeriod.BackColor = System.Drawing.SystemColors.Window;
			this.cmbPeriod.CausesValidation = true;
			this.cmbPeriod.Enabled = true;
			this.cmbPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbPeriod.IntegralHeight = true;
			this.cmbPeriod.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbPeriod.Sorted = false;
			this.cmbPeriod.TabStop = true;
			this.cmbPeriod.Visible = true;
			this.cmbPeriod.Name = "cmbPeriod";
			this.txtNarrative.AutoSize = false;
			this.txtNarrative.Size = new System.Drawing.Size(232, 19);
			this.txtNarrative.Location = new System.Drawing.Point(410, 202);
			this.txtNarrative.TabIndex = 4;
			this.txtNarrative.AcceptsReturn = true;
			this.txtNarrative.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNarrative.BackColor = System.Drawing.SystemColors.Window;
			this.txtNarrative.CausesValidation = true;
			this.txtNarrative.Enabled = true;
			this.txtNarrative.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNarrative.HideSelection = true;
			this.txtNarrative.ReadOnly = false;
			this.txtNarrative.MaxLength = 0;
			this.txtNarrative.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNarrative.Multiline = false;
			this.txtNarrative.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNarrative.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNarrative.TabStop = true;
			this.txtNarrative.Visible = true;
			this.txtNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNarrative.Name = "txtNarrative";
			this.txtNotes.AutoSize = false;
			this.txtNotes.Size = new System.Drawing.Size(232, 49);
			this.txtNotes.Location = new System.Drawing.Point(410, 224);
			this.txtNotes.Multiline = true;
			this.txtNotes.TabIndex = 6;
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNotes.BackColor = System.Drawing.SystemColors.Window;
			this.txtNotes.CausesValidation = true;
			this.txtNotes.Enabled = true;
			this.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNotes.HideSelection = true;
			this.txtNotes.ReadOnly = false;
			this.txtNotes.MaxLength = 0;
			this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNotes.TabStop = true;
			this.txtNotes.Visible = true;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNotes.Name = "txtNotes";
			this.txtAmount.AutoSize = false;
			this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAmount.Size = new System.Drawing.Size(112, 19);
			this.txtAmount.Location = new System.Drawing.Point(448, 274);
			this.txtAmount.TabIndex = 8;
			this.txtAmount.Text = "0.00";
			this.txtAmount.AcceptsReturn = true;
			this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
			this.txtAmount.CausesValidation = true;
			this.txtAmount.Enabled = true;
			this.txtAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAmount.HideSelection = true;
			this.txtAmount.ReadOnly = false;
			this.txtAmount.MaxLength = 0;
			this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAmount.Multiline = false;
			this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtAmount.TabStop = true;
			this.txtAmount.Visible = true;
			this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAmount.Name = "txtAmount";
			this.cmdProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProcess.Text = "&Process";
			this.cmdProcess.Size = new System.Drawing.Size(79, 25);
			this.cmdProcess.Location = new System.Drawing.Point(564, 312);
			this.cmdProcess.TabIndex = 10;
			this.cmdProcess.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProcess.CausesValidation = true;
			this.cmdProcess.Enabled = true;
			this.cmdProcess.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProcess.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProcess.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProcess.TabStop = true;
			this.cmdProcess.Name = "cmdProcess";
			this._txtFields_2.AutoSize = false;
			this._txtFields_2.Enabled = false;
			this._txtFields_2.Size = new System.Drawing.Size(226, 19);
			this._txtFields_2.Location = new System.Drawing.Point(102, 63);
			this._txtFields_2.TabIndex = 16;
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.CausesValidation = true;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.HideSelection = true;
			this._txtFields_2.ReadOnly = false;
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.Multiline = false;
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_2.TabStop = true;
			this._txtFields_2.Visible = true;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_6.AutoSize = false;
			this._txtFields_6.Enabled = false;
			this._txtFields_6.Size = new System.Drawing.Size(226, 68);
			this._txtFields_6.Location = new System.Drawing.Point(102, 108);
			this._txtFields_6.Multiline = true;
			this._txtFields_6.TabIndex = 22;
			this._txtFields_6.AcceptsReturn = true;
			this._txtFields_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_6.CausesValidation = true;
			this._txtFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_6.HideSelection = true;
			this._txtFields_6.ReadOnly = false;
			this._txtFields_6.MaxLength = 0;
			this._txtFields_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_6.TabStop = true;
			this._txtFields_6.Visible = true;
			this._txtFields_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_6.Name = "_txtFields_6";
			this._txtFields_7.AutoSize = false;
			this._txtFields_7.Enabled = false;
			this._txtFields_7.Size = new System.Drawing.Size(226, 72);
			this._txtFields_7.Location = new System.Drawing.Point(102, 182);
			this._txtFields_7.Multiline = true;
			this._txtFields_7.TabIndex = 24;
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.CausesValidation = true;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.HideSelection = true;
			this._txtFields_7.ReadOnly = false;
			this._txtFields_7.MaxLength = 0;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_7.TabStop = true;
			this._txtFields_7.Visible = true;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_8.AutoSize = false;
			this._txtFields_8.Enabled = false;
			this._txtFields_8.Size = new System.Drawing.Size(94, 19);
			this._txtFields_8.Location = new System.Drawing.Point(102, 84);
			this._txtFields_8.TabIndex = 18;
			this._txtFields_8.AcceptsReturn = true;
			this._txtFields_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_8.CausesValidation = true;
			this._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_8.HideSelection = true;
			this._txtFields_8.ReadOnly = false;
			this._txtFields_8.MaxLength = 0;
			this._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_8.Multiline = false;
			this._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_8.TabStop = true;
			this._txtFields_8.Visible = true;
			this._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_8.Name = "_txtFields_8";
			this._txtFields_9.AutoSize = false;
			this._txtFields_9.Enabled = false;
			this._txtFields_9.Size = new System.Drawing.Size(94, 19);
			this._txtFields_9.Location = new System.Drawing.Point(234, 84);
			this._txtFields_9.TabIndex = 20;
			this._txtFields_9.AcceptsReturn = true;
			this._txtFields_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_9.CausesValidation = true;
			this._txtFields_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_9.HideSelection = true;
			this._txtFields_9.ReadOnly = false;
			this._txtFields_9.MaxLength = 0;
			this._txtFields_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_9.Multiline = false;
			this._txtFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_9.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_9.TabStop = true;
			this._txtFields_9.Visible = true;
			this._txtFields_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_9.Name = "_txtFields_9";
			this._txtFloat_13.AutoSize = false;
			this._txtFloat_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_13.Enabled = false;
			this._txtFloat_13.Size = new System.Drawing.Size(91, 19);
			this._txtFloat_13.Location = new System.Drawing.Point(84, 281);
			this._txtFloat_13.TabIndex = 27;
			this._txtFloat_13.AcceptsReturn = true;
			this._txtFloat_13.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_13.CausesValidation = true;
			this._txtFloat_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_13.HideSelection = true;
			this._txtFloat_13.ReadOnly = false;
			this._txtFloat_13.MaxLength = 0;
			this._txtFloat_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_13.Multiline = false;
			this._txtFloat_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_13.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_13.TabStop = true;
			this._txtFloat_13.Visible = true;
			this._txtFloat_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_13.Name = "_txtFloat_13";
			this._txtFloat_14.AutoSize = false;
			this._txtFloat_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_14.Enabled = false;
			this._txtFloat_14.Size = new System.Drawing.Size(91, 19);
			this._txtFloat_14.Location = new System.Drawing.Point(237, 281);
			this._txtFloat_14.TabIndex = 29;
			this._txtFloat_14.AcceptsReturn = true;
			this._txtFloat_14.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_14.CausesValidation = true;
			this._txtFloat_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_14.HideSelection = true;
			this._txtFloat_14.ReadOnly = false;
			this._txtFloat_14.MaxLength = 0;
			this._txtFloat_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_14.Multiline = false;
			this._txtFloat_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_14.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_14.TabStop = true;
			this._txtFloat_14.Visible = true;
			this._txtFloat_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_14.Name = "_txtFloat_14";
			this._txtFloat_15.AutoSize = false;
			this._txtFloat_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_15.Enabled = false;
			this._txtFloat_15.Size = new System.Drawing.Size(91, 19);
			this._txtFloat_15.Location = new System.Drawing.Point(84, 302);
			this._txtFloat_15.TabIndex = 31;
			this._txtFloat_15.AcceptsReturn = true;
			this._txtFloat_15.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_15.CausesValidation = true;
			this._txtFloat_15.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_15.HideSelection = true;
			this._txtFloat_15.ReadOnly = false;
			this._txtFloat_15.MaxLength = 0;
			this._txtFloat_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_15.Multiline = false;
			this._txtFloat_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_15.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_15.TabStop = true;
			this._txtFloat_15.Visible = true;
			this._txtFloat_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_15.Name = "_txtFloat_15";
			this._txtFloat_16.AutoSize = false;
			this._txtFloat_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_16.Enabled = false;
			this._txtFloat_16.Size = new System.Drawing.Size(91, 19);
			this._txtFloat_16.Location = new System.Drawing.Point(237, 302);
			this._txtFloat_16.TabIndex = 33;
			this._txtFloat_16.AcceptsReturn = true;
			this._txtFloat_16.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_16.CausesValidation = true;
			this._txtFloat_16.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_16.HideSelection = true;
			this._txtFloat_16.ReadOnly = false;
			this._txtFloat_16.MaxLength = 0;
			this._txtFloat_16.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_16.Multiline = false;
			this._txtFloat_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_16.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_16.TabStop = true;
			this._txtFloat_16.Visible = true;
			this._txtFloat_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_16.Name = "_txtFloat_16";
			this._txtFloat_17.AutoSize = false;
			this._txtFloat_17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_17.Enabled = false;
			this._txtFloat_17.Size = new System.Drawing.Size(91, 19);
			this._txtFloat_17.Location = new System.Drawing.Point(84, 323);
			this._txtFloat_17.TabIndex = 35;
			this._txtFloat_17.AcceptsReturn = true;
			this._txtFloat_17.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_17.CausesValidation = true;
			this._txtFloat_17.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_17.HideSelection = true;
			this._txtFloat_17.ReadOnly = false;
			this._txtFloat_17.MaxLength = 0;
			this._txtFloat_17.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_17.Multiline = false;
			this._txtFloat_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_17.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_17.TabStop = true;
			this._txtFloat_17.Visible = true;
			this._txtFloat_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_17.Name = "_txtFloat_17";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(652, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 13;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdStatement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStatement.Text = "&Statement";
			this.cmdStatement.Size = new System.Drawing.Size(73, 29);
			this.cmdStatement.Location = new System.Drawing.Point(6, 2);
			this.cmdStatement.TabIndex = 12;
			this.cmdStatement.TabStop = false;
			this.cmdStatement.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStatement.CausesValidation = true;
			this.cmdStatement.Enabled = true;
			this.cmdStatement.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStatement.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStatement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStatement.Name = "cmdStatement";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(568, 2);
			this.cmdClose.TabIndex = 11;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.Label3.Text = "Total Amount:";
			this.Label3.Size = new System.Drawing.Size(83, 19);
			this.Label3.Location = new System.Drawing.Point(362, 322);
			this.Label3.TabIndex = 40;
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.Text = "Settlement:";
			this.Label2.Size = new System.Drawing.Size(63, 15);
			this.Label2.Location = new System.Drawing.Point(0, 0);
			this.Label2.TabIndex = 39;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.lblSettl.Text = "Settlement:";
			this.lblSettl.Size = new System.Drawing.Size(63, 15);
			this.lblSettl.Location = new System.Drawing.Point(374, 302);
			this.lblSettl.TabIndex = 38;
			this.lblSettl.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblSettl.BackColor = System.Drawing.Color.Transparent;
			this.lblSettl.Enabled = true;
			this.lblSettl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSettl.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblSettl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSettl.UseMnemonic = true;
			this.lblSettl.Visible = true;
			this.lblSettl.AutoSize = false;
			this.lblSettl.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSettl.Name = "lblSettl";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_3.Text = "Amount:";
			this._lblLabels_3.Size = new System.Drawing.Size(47, 13);
			this._lblLabels_3.Location = new System.Drawing.Point(0, 0);
			this._lblLabels_3.TabIndex = 37;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Enabled = true;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.UseMnemonic = true;
			this._lblLabels_3.Visible = true;
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_3.Name = "_lblLabels_3";
			this.Line1.X1 = 51;
			this.Line1.X2 = 324;
			this.Line1.Y1 = 266;
			this.Line1.Y2 = 266;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.BorderWidth = 1;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_3.Text = "Period:";
			this._lbl_3.Size = new System.Drawing.Size(41, 13);
			this._lbl_3.Location = new System.Drawing.Point(363, 156);
			this._lbl_3.TabIndex = 1;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = true;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "&3. Transaction";
			this._lbl_2.Size = new System.Drawing.Size(83, 13);
			this._lbl_2.Location = new System.Drawing.Point(338, 172);
			this._lbl_2.TabIndex = 0;
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
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Narrative:";
			this._lblLabels_0.Size = new System.Drawing.Size(57, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(349, 204);
			this._lblLabels_0.TabIndex = 3;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "Notes:";
			this._lblLabels_1.Size = new System.Drawing.Size(31, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(374, 224);
			this._lblLabels_1.TabIndex = 5;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_11.Text = "Amount Paid:";
			this._lblLabels_11.Size = new System.Drawing.Size(76, 13);
			this._lblLabels_11.Location = new System.Drawing.Point(366, 280);
			this._lblLabels_11.TabIndex = 7;
			this._lblLabels_11.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_11.Enabled = true;
			this._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_11.UseMnemonic = true;
			this._lblLabels_11.Visible = true;
			this._lblLabels_11.AutoSize = true;
			this._lblLabels_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_11.Name = "_lblLabels_11";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&1. General";
			this._lbl_1.Size = new System.Drawing.Size(61, 13);
			this._lbl_1.Location = new System.Drawing.Point(6, 42);
			this._lbl_1.TabIndex = 14;
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
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "Aging";
			this._lbl_0.Size = new System.Drawing.Size(33, 13);
			this._lbl_0.Location = new System.Drawing.Point(12, 260);
			this._lbl_0.TabIndex = 25;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "Supplier Name:";
			this._lblLabels_2.Size = new System.Drawing.Size(87, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(10, 63);
			this._lblLabels_2.TabIndex = 15;
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
			this._lblLabels_6.Location = new System.Drawing.Point(3, 108);
			this._lblLabels_6.TabIndex = 21;
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
			this._lblLabels_7.Location = new System.Drawing.Point(24, 182);
			this._lblLabels_7.TabIndex = 23;
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
			this._lblLabels_8.Location = new System.Drawing.Point(39, 84);
			this._lblLabels_8.TabIndex = 17;
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
			this._lblLabels_9.Location = new System.Drawing.Point(207, 84);
			this._lblLabels_9.TabIndex = 19;
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
			this._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_13.Text = "Current:";
			this._lblLabels_13.Size = new System.Drawing.Size(37, 13);
			this._lblLabels_13.Location = new System.Drawing.Point(36, 284);
			this._lblLabels_13.TabIndex = 26;
			this._lblLabels_13.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_13.Enabled = true;
			this._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_13.UseMnemonic = true;
			this._lblLabels_13.Visible = true;
			this._lblLabels_13.AutoSize = true;
			this._lblLabels_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_13.Name = "_lblLabels_13";
			this._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_14.Text = "30 Days:";
			this._lblLabels_14.Size = new System.Drawing.Size(43, 13);
			this._lblLabels_14.Location = new System.Drawing.Point(189, 281);
			this._lblLabels_14.TabIndex = 28;
			this._lblLabels_14.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_14.Enabled = true;
			this._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_14.UseMnemonic = true;
			this._lblLabels_14.Visible = true;
			this._lblLabels_14.AutoSize = true;
			this._lblLabels_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_14.Name = "_lblLabels_14";
			this._lblLabels_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_15.Text = "60 Days:";
			this._lblLabels_15.Size = new System.Drawing.Size(43, 13);
			this._lblLabels_15.Location = new System.Drawing.Point(30, 305);
			this._lblLabels_15.TabIndex = 30;
			this._lblLabels_15.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_15.Enabled = true;
			this._lblLabels_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_15.UseMnemonic = true;
			this._lblLabels_15.Visible = true;
			this._lblLabels_15.AutoSize = true;
			this._lblLabels_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_15.Name = "_lblLabels_15";
			this._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_16.Text = "90 Days:";
			this._lblLabels_16.Size = new System.Drawing.Size(43, 13);
			this._lblLabels_16.Location = new System.Drawing.Point(189, 302);
			this._lblLabels_16.TabIndex = 32;
			this._lblLabels_16.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_16.Enabled = true;
			this._lblLabels_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_16.UseMnemonic = true;
			this._lblLabels_16.Visible = true;
			this._lblLabels_16.AutoSize = true;
			this._lblLabels_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_16.Name = "_lblLabels_16";
			this._lblLabels_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_17.Text = "120 Days:";
			this._lblLabels_17.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_17.Location = new System.Drawing.Point(24, 326);
			this._lblLabels_17.TabIndex = 34;
			this._lblLabels_17.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_17.Enabled = true;
			this._lblLabels_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_17.UseMnemonic = true;
			this._lblLabels_17.Visible = true;
			this._lblLabels_17.AutoSize = true;
			this._lblLabels_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_17.Name = "_lblLabels_17";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(328, 296);
			this._Shape1_1.Location = new System.Drawing.Point(6, 57);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(310, 165);
			this._Shape1_2.Location = new System.Drawing.Point(338, 188);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(txtTotalAmount);
			this.Controls.Add(txtSettlement);
			this.Controls.Add(cmbPeriod);
			this.Controls.Add(txtNarrative);
			this.Controls.Add(txtNotes);
			this.Controls.Add(txtAmount);
			this.Controls.Add(cmdProcess);
			this.Controls.Add(_txtFields_2);
			this.Controls.Add(_txtFields_6);
			this.Controls.Add(_txtFields_7);
			this.Controls.Add(_txtFields_8);
			this.Controls.Add(_txtFields_9);
			this.Controls.Add(_txtFloat_13);
			this.Controls.Add(_txtFloat_14);
			this.Controls.Add(_txtFloat_15);
			this.Controls.Add(_txtFloat_16);
			this.Controls.Add(_txtFloat_17);
			this.Controls.Add(picButtons);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(lblSettl);
			this.Controls.Add(_lblLabels_3);
			this.ShapeContainer1.Shapes.Add(Line1);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lblLabels_0);
			this.Controls.Add(_lblLabels_1);
			this.Controls.Add(_lblLabels_11);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(_lblLabels_2);
			this.Controls.Add(_lblLabels_6);
			this.Controls.Add(_lblLabels_7);
			this.Controls.Add(_lblLabels_8);
			this.Controls.Add(_lblLabels_9);
			this.Controls.Add(_lblLabels_13);
			this.Controls.Add(_lblLabels_14);
			this.Controls.Add(_lblLabels_15);
			this.Controls.Add(_lblLabels_16);
			this.Controls.Add(_lblLabels_17);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdStatement);
			this.picButtons.Controls.Add(cmdClose);
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_11, CType(11, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.lblLabels.SetIndex(_lblLabels_13, CType(13, Short))
			//Me.lblLabels.SetIndex(_lblLabels_14, CType(14, Short))
			//Me.lblLabels.SetIndex(_lblLabels_15, CType(15, Short))
			//Me.lblLabels.SetIndex(_lblLabels_16, CType(16, Short))
			//Me.lblLabels.SetIndex(_lblLabels_17, CType(17, Short))
			//Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
			//Me.txtFields.SetIndex(_txtFields_6, CType(6, Short))
			//Me.txtFields.SetIndex(_txtFields_7, CType(7, Short))
			//Me.txtFields.SetIndex(_txtFields_8, CType(8, Short))
			//Me.txtFields.SetIndex(_txtFields_9, CType(9, Short))
			//Me.txtFloat.SetIndex(_txtFloat_13, CType(13, Short))
			//Me.txtFloat.SetIndex(_txtFloat_14, CType(14, Short))
			//Me.txtFloat.SetIndex(_txtFloat_15, CType(15, Short))
			//Me.txtFloat.SetIndex(_txtFloat_16, CType(16, Short))
			//Me.txtFloat.SetIndex(_txtFloat_17, CType(17, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
