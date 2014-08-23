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
	partial class frmVegTest
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmVegTest() : base()
		{
			Resize += frmVegTest_Resize;
			Load += frmVegTest_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			Form_Initialize_Renamed();
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
		public Microsoft.VisualBasic.PowerPacks.Printing.PrintForm PrintForm1;
		public System.Windows.Forms.TextBox AvailGRV;
		public System.Windows.Forms.Label lblTotalOP;
		public System.Windows.Forms.Label lblTotalLP;
		public System.Windows.Forms.Label lblTotalO;
		public System.Windows.Forms.Label _lblTotal_17;
		public System.Windows.Forms.Label lblTotalL;
		public System.Windows.Forms.Label _lblTotal_16;
		public System.Windows.Forms.Label lblTotalH;
		public System.Windows.Forms.Label _lblTotal_15;
		public System.Windows.Forms.Label lblTotalG;
		public System.Windows.Forms.Label _lblTotal_14;
		public System.Windows.Forms.Label _lblTotal_13;
		public System.Windows.Forms.Label lblTotalQ;
		public System.Windows.Forms.Label _lblTotal_12;
		public System.Windows.Forms.Label lblTotalF;
		public System.Windows.Forms.Label lblP;
		public System.Windows.Forms.Label _lblTotal_11;
		public System.Windows.Forms.Panel picTotal;
		public System.Windows.Forms.TextBox _txtEdit_0;
		public System.Windows.Forms.TextBox TotalQTY;
		public System.Windows.Forms.TextBox TotalQTYd;
		private System.Windows.Forms.TextBox withEventsField_txtR;
		public System.Windows.Forms.TextBox txtR {
			get { return withEventsField_txtR; }
			set {
				if (withEventsField_txtR != null) {
					withEventsField_txtR.Enter -= txtR_Enter;
					withEventsField_txtR.KeyPress -= txtR_KeyPress;
					withEventsField_txtR.Leave -= txtR_Leave;
				}
				withEventsField_txtR = value;
				if (withEventsField_txtR != null) {
					withEventsField_txtR.Enter += txtR_Enter;
					withEventsField_txtR.KeyPress += txtR_KeyPress;
					withEventsField_txtR.Leave += txtR_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtZ;
		public System.Windows.Forms.TextBox txtZ {
			get { return withEventsField_txtZ; }
			set {
				if (withEventsField_txtZ != null) {
					withEventsField_txtZ.Enter -= txtZ_Enter;
					withEventsField_txtZ.KeyPress -= txtZ_KeyPress;
					withEventsField_txtZ.Leave -= txtZ_Leave;
				}
				withEventsField_txtZ = value;
				if (withEventsField_txtZ != null) {
					withEventsField_txtZ.Enter += txtZ_Enter;
					withEventsField_txtZ.KeyPress += txtZ_KeyPress;
					withEventsField_txtZ.Leave += txtZ_Leave;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdTotal;
		public System.Windows.Forms.Button cmdTotal {
			get { return withEventsField_cmdTotal; }
			set {
				if (withEventsField_cmdTotal != null) {
					withEventsField_cmdTotal.Click -= cmdTotal_Click;
				}
				withEventsField_cmdTotal = value;
				if (withEventsField_cmdTotal != null) {
					withEventsField_cmdTotal.Click += cmdTotal_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtReqGP;
		public System.Windows.Forms.TextBox txtReqGP {
			get { return withEventsField_txtReqGP; }
			set {
				if (withEventsField_txtReqGP != null) {
					withEventsField_txtReqGP.Enter -= txtReqGP_Enter;
				}
				withEventsField_txtReqGP = value;
				if (withEventsField_txtReqGP != null) {
					withEventsField_txtReqGP.Enter += txtReqGP_Enter;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtVAT;
		public System.Windows.Forms.TextBox txtVAT {
			get { return withEventsField_txtVAT; }
			set {
				if (withEventsField_txtVAT != null) {
					withEventsField_txtVAT.Enter -= txtVAT_Enter;
				}
				withEventsField_txtVAT = value;
				if (withEventsField_txtVAT != null) {
					withEventsField_txtVAT.Enter += txtVAT_Enter;
				}
			}
		}
		public System.Windows.Forms.Label lblQuantity;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label lblBrokenPack;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label lblContentExclusive;
		public System.Windows.Forms.Label lblContentInclusives;
		public System.Windows.Forms.Label lblDepositExclusives;
		public System.Windows.Forms.Label lblA;
		public System.Windows.Forms.Label lblB;
		public System.Windows.Forms.Label lblC;
		public System.Windows.Forms.Label _lblTotal_0;
		public System.Windows.Forms.Label _lblTotal_1;
		public System.Windows.Forms.Label _lblTotal_2;
		public System.Windows.Forms.Label _lblTotal_3;
		public System.Windows.Forms.Label _lblTotal_4;
		public System.Windows.Forms.Label _lblTotal_5;
		public System.Windows.Forms.Label lblX;
		public System.Windows.Forms.Label lblGP_Y;
		public System.Windows.Forms.Label lblB_Z;
		public System.Windows.Forms.Label _lblTotal_6;
		public System.Windows.Forms.Label _lblTotal_7;
		public System.Windows.Forms.Label _lblTotal_8;
		public System.Windows.Forms.Label _lblTotal_9;
		public System.Windows.Forms.Label _lblTotal_10;
		public System.Windows.Forms.GroupBox frmTotals;
		public System.Windows.Forms.TextBox _txtEdit_1;
		public System.Windows.Forms.TextBox _txtEdit_2;
		private System.Windows.Forms.Button withEventsField_cmdReg;
		public System.Windows.Forms.Button cmdReg {
			get { return withEventsField_cmdReg; }
			set {
				if (withEventsField_cmdReg != null) {
					withEventsField_cmdReg.Click -= cmdReg_Click;
				}
				withEventsField_cmdReg = value;
				if (withEventsField_cmdReg != null) {
					withEventsField_cmdReg.Click += cmdReg_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdProc;
		public System.Windows.Forms.Button cmdProc {
			get { return withEventsField_cmdProc; }
			set {
				if (withEventsField_cmdProc != null) {
					withEventsField_cmdProc.Click -= cmdProc_Click;
				}
				withEventsField_cmdProc = value;
				if (withEventsField_cmdProc != null) {
					withEventsField_cmdProc.Click += cmdProc_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
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
		public System.Windows.Forms.Panel Picture2;
		private myDataGridView withEventsField_gridItem;
		public myDataGridView gridItem {
			get { return withEventsField_gridItem; }
			set {
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.KeyPress -= gridItem_KeyPress;
					withEventsField_gridItem.Enter -= gridItem_EnterCell;
					withEventsField_gridItem.Leave -= gridItem_LeaveCell;
				}
				withEventsField_gridItem = value;
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.KeyPress += gridItem_KeyPress;
					withEventsField_gridItem.Enter += gridItem_EnterCell;
					withEventsField_gridItem.Leave += gridItem_LeaveCell;
				}
			}
		}
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblTotal As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtEdit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVegTest));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.PrintForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this);
			this.AvailGRV = new System.Windows.Forms.TextBox();
			this.picTotal = new System.Windows.Forms.Panel();
			this.lblTotalOP = new System.Windows.Forms.Label();
			this.lblTotalLP = new System.Windows.Forms.Label();
			this.lblTotalO = new System.Windows.Forms.Label();
			this._lblTotal_17 = new System.Windows.Forms.Label();
			this.lblTotalL = new System.Windows.Forms.Label();
			this._lblTotal_16 = new System.Windows.Forms.Label();
			this.lblTotalH = new System.Windows.Forms.Label();
			this._lblTotal_15 = new System.Windows.Forms.Label();
			this.lblTotalG = new System.Windows.Forms.Label();
			this._lblTotal_14 = new System.Windows.Forms.Label();
			this._lblTotal_13 = new System.Windows.Forms.Label();
			this.lblTotalQ = new System.Windows.Forms.Label();
			this._lblTotal_12 = new System.Windows.Forms.Label();
			this.lblTotalF = new System.Windows.Forms.Label();
			this.lblP = new System.Windows.Forms.Label();
			this._lblTotal_11 = new System.Windows.Forms.Label();
			this._txtEdit_0 = new System.Windows.Forms.TextBox();
			this.frmTotals = new System.Windows.Forms.GroupBox();
			this.TotalQTY = new System.Windows.Forms.TextBox();
			this.TotalQTYd = new System.Windows.Forms.TextBox();
			this.txtR = new System.Windows.Forms.TextBox();
			this.txtZ = new System.Windows.Forms.TextBox();
			this.cmdTotal = new System.Windows.Forms.Button();
			this.txtReqGP = new System.Windows.Forms.TextBox();
			this.txtVAT = new System.Windows.Forms.TextBox();
			this.lblQuantity = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this.lblBrokenPack = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.lblContentExclusive = new System.Windows.Forms.Label();
			this.lblContentInclusives = new System.Windows.Forms.Label();
			this.lblDepositExclusives = new System.Windows.Forms.Label();
			this.lblA = new System.Windows.Forms.Label();
			this.lblB = new System.Windows.Forms.Label();
			this.lblC = new System.Windows.Forms.Label();
			this._lblTotal_0 = new System.Windows.Forms.Label();
			this._lblTotal_1 = new System.Windows.Forms.Label();
			this._lblTotal_2 = new System.Windows.Forms.Label();
			this._lblTotal_3 = new System.Windows.Forms.Label();
			this._lblTotal_4 = new System.Windows.Forms.Label();
			this._lblTotal_5 = new System.Windows.Forms.Label();
			this.lblX = new System.Windows.Forms.Label();
			this.lblGP_Y = new System.Windows.Forms.Label();
			this.lblB_Z = new System.Windows.Forms.Label();
			this._lblTotal_6 = new System.Windows.Forms.Label();
			this._lblTotal_7 = new System.Windows.Forms.Label();
			this._lblTotal_8 = new System.Windows.Forms.Label();
			this._lblTotal_9 = new System.Windows.Forms.Label();
			this._lblTotal_10 = new System.Windows.Forms.Label();
			this._txtEdit_1 = new System.Windows.Forms.TextBox();
			this._txtEdit_2 = new System.Windows.Forms.TextBox();
			this.Picture2 = new System.Windows.Forms.Panel();
			this.cmdReg = new System.Windows.Forms.Button();
			this.cmdProc = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.gridItem = new myDataGridView();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblTotal = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtEdit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.picTotal.SuspendLayout();
			this.frmTotals.SuspendLayout();
			this.Picture2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridItem).BeginInit();
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.Text = "4VEG Production Tester";
			this.ClientSize = new System.Drawing.Size(1016, 707);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.Name = "frmVegTest";
			this.AvailGRV.AutoSize = false;
			this.AvailGRV.Size = new System.Drawing.Size(105, 19);
			this.AvailGRV.Location = new System.Drawing.Point(168, 664);
			this.AvailGRV.ReadOnly = true;
			this.AvailGRV.TabIndex = 56;
			this.AvailGRV.Text = "0";
			this.AvailGRV.Visible = false;
			this.AvailGRV.AcceptsReturn = true;
			this.AvailGRV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.AvailGRV.BackColor = System.Drawing.SystemColors.Window;
			this.AvailGRV.CausesValidation = true;
			this.AvailGRV.Enabled = true;
			this.AvailGRV.ForeColor = System.Drawing.SystemColors.WindowText;
			this.AvailGRV.HideSelection = true;
			this.AvailGRV.MaxLength = 0;
			this.AvailGRV.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.AvailGRV.Multiline = false;
			this.AvailGRV.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AvailGRV.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.AvailGRV.TabStop = true;
			this.AvailGRV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.AvailGRV.Name = "AvailGRV";
			this.picTotal.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.picTotal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picTotal.Size = new System.Drawing.Size(997, 73);
			this.picTotal.Location = new System.Drawing.Point(8, 576);
			this.picTotal.TabIndex = 37;
			this.picTotal.Visible = false;
			this.picTotal.Dock = System.Windows.Forms.DockStyle.None;
			this.picTotal.CausesValidation = true;
			this.picTotal.Enabled = true;
			this.picTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.picTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picTotal.TabStop = true;
			this.picTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picTotal.Name = "picTotal";
			this.lblTotalOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalOP.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalOP.Text = "0.00";
			this.lblTotalOP.Size = new System.Drawing.Size(65, 16);
			this.lblTotalOP.Location = new System.Drawing.Point(928, 16);
			this.lblTotalOP.TabIndex = 54;
			this.lblTotalOP.Visible = false;
			this.lblTotalOP.Enabled = true;
			this.lblTotalOP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalOP.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalOP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalOP.UseMnemonic = true;
			this.lblTotalOP.AutoSize = false;
			this.lblTotalOP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalOP.Name = "lblTotalOP";
			this.lblTotalLP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalLP.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalLP.Text = "0.00";
			this.lblTotalLP.Size = new System.Drawing.Size(65, 16);
			this.lblTotalLP.Location = new System.Drawing.Point(728, 16);
			this.lblTotalLP.TabIndex = 53;
			this.lblTotalLP.Visible = false;
			this.lblTotalLP.Enabled = true;
			this.lblTotalLP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalLP.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalLP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalLP.UseMnemonic = true;
			this.lblTotalLP.AutoSize = false;
			this.lblTotalLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalLP.Name = "lblTotalLP";
			this.lblTotalO.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalO.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalO.Text = "0.00";
			this.lblTotalO.Size = new System.Drawing.Size(65, 16);
			this.lblTotalO.Location = new System.Drawing.Point(928, 0);
			this.lblTotalO.TabIndex = 51;
			this.lblTotalO.Visible = false;
			this.lblTotalO.Enabled = true;
			this.lblTotalO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalO.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalO.UseMnemonic = true;
			this.lblTotalO.AutoSize = false;
			this.lblTotalO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalO.Name = "lblTotalO";
			this._lblTotal_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_17.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_17.Text = "O :";
			this._lblTotal_17.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_17.Size = new System.Drawing.Size(35, 16);
			this._lblTotal_17.Location = new System.Drawing.Point(944, 32);
			this._lblTotal_17.TabIndex = 50;
			this._lblTotal_17.Visible = false;
			this._lblTotal_17.Enabled = true;
			this._lblTotal_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_17.UseMnemonic = true;
			this._lblTotal_17.AutoSize = false;
			this._lblTotal_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_17.Name = "_lblTotal_17";
			this.lblTotalL.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalL.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalL.Text = "0.00";
			this.lblTotalL.Size = new System.Drawing.Size(65, 16);
			this.lblTotalL.Location = new System.Drawing.Point(728, 0);
			this.lblTotalL.TabIndex = 49;
			this.lblTotalL.Visible = false;
			this.lblTotalL.Enabled = true;
			this.lblTotalL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalL.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalL.UseMnemonic = true;
			this.lblTotalL.AutoSize = false;
			this.lblTotalL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalL.Name = "lblTotalL";
			this._lblTotal_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_16.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_16.Text = "L :";
			this._lblTotal_16.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_16.Size = new System.Drawing.Size(35, 16);
			this._lblTotal_16.Location = new System.Drawing.Point(736, 32);
			this._lblTotal_16.TabIndex = 48;
			this._lblTotal_16.Visible = false;
			this._lblTotal_16.Enabled = true;
			this._lblTotal_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_16.UseMnemonic = true;
			this._lblTotal_16.AutoSize = false;
			this._lblTotal_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_16.Name = "_lblTotal_16";
			this.lblTotalH.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalH.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalH.Text = "0.00";
			this.lblTotalH.Size = new System.Drawing.Size(65, 16);
			this.lblTotalH.Location = new System.Drawing.Point(462, 0);
			this.lblTotalH.TabIndex = 47;
			this.lblTotalH.Visible = false;
			this.lblTotalH.Enabled = true;
			this.lblTotalH.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalH.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalH.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalH.UseMnemonic = true;
			this.lblTotalH.AutoSize = false;
			this.lblTotalH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalH.Name = "lblTotalH";
			this._lblTotal_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_15.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_15.Text = "H :";
			this._lblTotal_15.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_15.Size = new System.Drawing.Size(27, 16);
			this._lblTotal_15.Location = new System.Drawing.Point(480, 16);
			this._lblTotal_15.TabIndex = 46;
			this._lblTotal_15.Visible = false;
			this._lblTotal_15.Enabled = true;
			this._lblTotal_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_15.UseMnemonic = true;
			this._lblTotal_15.AutoSize = false;
			this._lblTotal_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_15.Name = "_lblTotal_15";
			this.lblTotalG.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalG.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalG.Text = "0.00";
			this.lblTotalG.Size = new System.Drawing.Size(65, 16);
			this.lblTotalG.Location = new System.Drawing.Point(392, 0);
			this.lblTotalG.TabIndex = 45;
			this.lblTotalG.Visible = false;
			this.lblTotalG.Enabled = true;
			this.lblTotalG.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalG.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalG.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalG.UseMnemonic = true;
			this.lblTotalG.AutoSize = false;
			this.lblTotalG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalG.Name = "lblTotalG";
			this._lblTotal_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_14.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_14.Text = "G :";
			this._lblTotal_14.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_14.Size = new System.Drawing.Size(27, 16);
			this._lblTotal_14.Location = new System.Drawing.Point(408, 16);
			this._lblTotal_14.TabIndex = 44;
			this._lblTotal_14.Visible = false;
			this._lblTotal_14.Enabled = true;
			this._lblTotal_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_14.UseMnemonic = true;
			this._lblTotal_14.AutoSize = false;
			this._lblTotal_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_14.Name = "_lblTotal_14";
			this._lblTotal_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_13.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_13.Text = "Q :";
			this._lblTotal_13.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_13.Size = new System.Drawing.Size(35, 16);
			this._lblTotal_13.Location = new System.Drawing.Point(536, 16);
			this._lblTotal_13.TabIndex = 43;
			this._lblTotal_13.Visible = false;
			this._lblTotal_13.Enabled = true;
			this._lblTotal_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_13.UseMnemonic = true;
			this._lblTotal_13.AutoSize = false;
			this._lblTotal_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_13.Name = "_lblTotal_13";
			this.lblTotalQ.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalQ.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalQ.Text = "0.00";
			this.lblTotalQ.Size = new System.Drawing.Size(65, 16);
			this.lblTotalQ.Location = new System.Drawing.Point(528, 0);
			this.lblTotalQ.TabIndex = 42;
			this.lblTotalQ.Visible = false;
			this.lblTotalQ.Enabled = true;
			this.lblTotalQ.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalQ.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalQ.UseMnemonic = true;
			this.lblTotalQ.AutoSize = false;
			this.lblTotalQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalQ.Name = "lblTotalQ";
			this._lblTotal_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_12.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_12.Text = "F :";
			this._lblTotal_12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_12.Size = new System.Drawing.Size(27, 16);
			this._lblTotal_12.Location = new System.Drawing.Point(344, 16);
			this._lblTotal_12.TabIndex = 41;
			this._lblTotal_12.Visible = false;
			this._lblTotal_12.Enabled = true;
			this._lblTotal_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_12.UseMnemonic = true;
			this._lblTotal_12.AutoSize = false;
			this._lblTotal_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_12.Name = "_lblTotal_12";
			this.lblTotalF.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotalF.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblTotalF.Text = "0.00";
			this.lblTotalF.Size = new System.Drawing.Size(65, 16);
			this.lblTotalF.Location = new System.Drawing.Point(323, 0);
			this.lblTotalF.TabIndex = 40;
			this.lblTotalF.Visible = false;
			this.lblTotalF.Enabled = true;
			this.lblTotalF.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTotalF.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotalF.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotalF.UseMnemonic = true;
			this.lblTotalF.AutoSize = false;
			this.lblTotalF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalF.Name = "lblTotalF";
			this.lblP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblP.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblP.Text = "0.00";
			this.lblP.Size = new System.Drawing.Size(65, 16);
			this.lblP.Location = new System.Drawing.Point(192, 0);
			this.lblP.TabIndex = 39;
			this.lblP.Enabled = true;
			this.lblP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblP.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblP.UseMnemonic = true;
			this.lblP.Visible = true;
			this.lblP.AutoSize = false;
			this.lblP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblP.Name = "lblP";
			this._lblTotal_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_11.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_11.Text = "After Production Qty.Loss - P :";
			this._lblTotal_11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_11.Size = new System.Drawing.Size(187, 16);
			this._lblTotal_11.Location = new System.Drawing.Point(0, 0);
			this._lblTotal_11.TabIndex = 38;
			this._lblTotal_11.Enabled = true;
			this._lblTotal_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_11.UseMnemonic = true;
			this._lblTotal_11.Visible = true;
			this._lblTotal_11.AutoSize = false;
			this._lblTotal_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_11.Name = "_lblTotal_11";
			this._txtEdit_0.AutoSize = false;
			this._txtEdit_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_0.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_0.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_0.Location = new System.Drawing.Point(391, 546);
			this._txtEdit_0.MaxLength = 8;
			this._txtEdit_0.TabIndex = 36;
			this._txtEdit_0.Tag = "0";
			this._txtEdit_0.Text = "0";
			this._txtEdit_0.Visible = false;
			this._txtEdit_0.AcceptsReturn = true;
			this._txtEdit_0.CausesValidation = true;
			this._txtEdit_0.Enabled = true;
			this._txtEdit_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_0.HideSelection = true;
			this._txtEdit_0.ReadOnly = false;
			this._txtEdit_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_0.Multiline = false;
			this._txtEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_0.TabStop = true;
			this._txtEdit_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_0.Name = "_txtEdit_0";
			this.frmTotals.Text = " Genral Information ";
			this.frmTotals.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.frmTotals.Size = new System.Drawing.Size(889, 137);
			this.frmTotals.Location = new System.Drawing.Point(3, 56);
			this.frmTotals.TabIndex = 10;
			this.frmTotals.BackColor = System.Drawing.SystemColors.Control;
			this.frmTotals.Enabled = true;
			this.frmTotals.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTotals.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTotals.Visible = true;
			this.frmTotals.Padding = new System.Windows.Forms.Padding(0);
			this.frmTotals.Name = "frmTotals";
			this.TotalQTY.AutoSize = false;
			this.TotalQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TotalQTY.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.TotalQTY.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.TotalQTY.Size = new System.Drawing.Size(234, 21);
			this.TotalQTY.Location = new System.Drawing.Point(216, 66);
			this.TotalQTY.ReadOnly = true;
			this.TotalQTY.TabIndex = 58;
			this.TotalQTY.Text = "0.00";
			this.TotalQTY.AcceptsReturn = true;
			this.TotalQTY.CausesValidation = true;
			this.TotalQTY.Enabled = true;
			this.TotalQTY.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TotalQTY.HideSelection = true;
			this.TotalQTY.MaxLength = 0;
			this.TotalQTY.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.TotalQTY.Multiline = false;
			this.TotalQTY.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotalQTY.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TotalQTY.TabStop = true;
			this.TotalQTY.Visible = true;
			this.TotalQTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.TotalQTY.Name = "TotalQTY";
			this.TotalQTYd.AutoSize = false;
			this.TotalQTYd.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.TotalQTYd.Size = new System.Drawing.Size(89, 19);
			this.TotalQTYd.Location = new System.Drawing.Point(472, 112);
			this.TotalQTYd.ReadOnly = true;
			this.TotalQTYd.TabIndex = 57;
			this.TotalQTYd.Text = "0";
			this.TotalQTYd.Visible = false;
			this.TotalQTYd.AcceptsReturn = true;
			this.TotalQTYd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.TotalQTYd.CausesValidation = true;
			this.TotalQTYd.Enabled = true;
			this.TotalQTYd.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TotalQTYd.HideSelection = true;
			this.TotalQTYd.MaxLength = 0;
			this.TotalQTYd.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.TotalQTYd.Multiline = false;
			this.TotalQTYd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TotalQTYd.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TotalQTYd.TabStop = true;
			this.TotalQTYd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.TotalQTYd.Name = "TotalQTYd";
			this.txtR.AutoSize = false;
			this.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtR.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtR.Enabled = false;
			this.txtR.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtR.Size = new System.Drawing.Size(234, 19);
			this.txtR.Location = new System.Drawing.Point(216, 104);
			this.txtR.TabIndex = 0;
			this.txtR.Text = "0.00";
			this.txtR.Visible = false;
			this.txtR.AcceptsReturn = true;
			this.txtR.CausesValidation = true;
			this.txtR.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtR.HideSelection = true;
			this.txtR.ReadOnly = false;
			this.txtR.MaxLength = 0;
			this.txtR.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtR.Multiline = false;
			this.txtR.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtR.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtR.TabStop = true;
			this.txtR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtR.Name = "txtR";
			this.txtZ.AutoSize = false;
			this.txtZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtZ.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtZ.Enabled = false;
			this.txtZ.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtZ.Size = new System.Drawing.Size(234, 19);
			this.txtZ.Location = new System.Drawing.Point(208, 96);
			this.txtZ.TabIndex = 1;
			this.txtZ.Text = "0.00";
			this.txtZ.Visible = false;
			this.txtZ.AcceptsReturn = true;
			this.txtZ.CausesValidation = true;
			this.txtZ.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtZ.HideSelection = true;
			this.txtZ.ReadOnly = false;
			this.txtZ.MaxLength = 0;
			this.txtZ.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtZ.Multiline = false;
			this.txtZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtZ.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtZ.TabStop = true;
			this.txtZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtZ.Name = "txtZ";
			this.cmdTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdTotal.Text = "Calculate";
			this.cmdTotal.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdTotal.Size = new System.Drawing.Size(99, 40);
			this.cmdTotal.Location = new System.Drawing.Point(776, 32);
			this.cmdTotal.TabIndex = 11;
			this.cmdTotal.TabStop = false;
			this.cmdTotal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdTotal.CausesValidation = true;
			this.cmdTotal.Enabled = true;
			this.cmdTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdTotal.Name = "cmdTotal";
			this.txtReqGP.AutoSize = false;
			this.txtReqGP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtReqGP.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtReqGP.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtReqGP.Size = new System.Drawing.Size(120, 21);
			this.txtReqGP.Location = new System.Drawing.Point(616, 20);
			this.txtReqGP.ReadOnly = true;
			this.txtReqGP.TabIndex = 2;
			this.txtReqGP.Text = "0.00";
			this.txtReqGP.AcceptsReturn = true;
			this.txtReqGP.CausesValidation = true;
			this.txtReqGP.Enabled = true;
			this.txtReqGP.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtReqGP.HideSelection = true;
			this.txtReqGP.MaxLength = 0;
			this.txtReqGP.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtReqGP.Multiline = false;
			this.txtReqGP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtReqGP.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtReqGP.TabStop = true;
			this.txtReqGP.Visible = true;
			this.txtReqGP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtReqGP.Name = "txtReqGP";
			this.txtVAT.AutoSize = false;
			this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtVAT.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.txtVAT.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.txtVAT.Size = new System.Drawing.Size(120, 19);
			this.txtVAT.Location = new System.Drawing.Point(616, 92);
			this.txtVAT.TabIndex = 3;
			this.txtVAT.Text = "0.00";
			this.txtVAT.Visible = false;
			this.txtVAT.AcceptsReturn = true;
			this.txtVAT.CausesValidation = true;
			this.txtVAT.Enabled = true;
			this.txtVAT.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtVAT.HideSelection = true;
			this.txtVAT.ReadOnly = false;
			this.txtVAT.MaxLength = 0;
			this.txtVAT.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtVAT.Multiline = false;
			this.txtVAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtVAT.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtVAT.TabStop = true;
			this.txtVAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtVAT.Name = "txtVAT";
			this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblQuantity.Text = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(64, 17);
			this.lblQuantity.Location = new System.Drawing.Point(673, 195);
			this.lblQuantity.TabIndex = 35;
			this.lblQuantity.BackColor = System.Drawing.SystemColors.Control;
			this.lblQuantity.Enabled = true;
			this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblQuantity.UseMnemonic = true;
			this.lblQuantity.Visible = true;
			this.lblQuantity.AutoSize = false;
			this.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblQuantity.Name = "lblQuantity";
			this._lbl_8.Text = "No Of Cases";
			this._lbl_8.Size = new System.Drawing.Size(60, 13);
			this._lbl_8.Location = new System.Drawing.Point(673, 183);
			this._lbl_8.TabIndex = 34;
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Enabled = true;
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.UseMnemonic = true;
			this._lbl_8.Visible = true;
			this._lbl_8.AutoSize = true;
			this._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_8.Name = "_lbl_8";
			this.lblBrokenPack.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblBrokenPack.Text = "lblQuantity";
			this.lblBrokenPack.Size = new System.Drawing.Size(64, 17);
			this.lblBrokenPack.Location = new System.Drawing.Point(745, 195);
			this.lblBrokenPack.TabIndex = 33;
			this.lblBrokenPack.BackColor = System.Drawing.SystemColors.Control;
			this.lblBrokenPack.Enabled = true;
			this.lblBrokenPack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblBrokenPack.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblBrokenPack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblBrokenPack.UseMnemonic = true;
			this.lblBrokenPack.Visible = true;
			this.lblBrokenPack.AutoSize = false;
			this.lblBrokenPack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblBrokenPack.Name = "lblBrokenPack";
			this._lbl_2.Text = "Broken Packs";
			this._lbl_2.Size = new System.Drawing.Size(67, 13);
			this._lbl_2.Location = new System.Drawing.Point(742, 183);
			this._lbl_2.TabIndex = 32;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this.lblContentExclusive.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContentExclusive.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this.lblContentExclusive.Text = "person name";
			this.lblContentExclusive.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblContentExclusive.Size = new System.Drawing.Size(234, 21);
			this.lblContentExclusive.Location = new System.Drawing.Point(215, 20);
			this.lblContentExclusive.TabIndex = 31;
			this.lblContentExclusive.Enabled = true;
			this.lblContentExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentExclusive.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentExclusive.UseMnemonic = true;
			this.lblContentExclusive.Visible = true;
			this.lblContentExclusive.AutoSize = false;
			this.lblContentExclusive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentExclusive.Name = "lblContentExclusive";
			this.lblContentInclusives.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContentInclusives.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblContentInclusives.Text = "0.00";
			this.lblContentInclusives.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblContentInclusives.Size = new System.Drawing.Size(233, 16);
			this.lblContentInclusives.Location = new System.Drawing.Point(840, 32);
			this.lblContentInclusives.TabIndex = 30;
			this.lblContentInclusives.Visible = false;
			this.lblContentInclusives.Enabled = true;
			this.lblContentInclusives.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblContentInclusives.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentInclusives.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentInclusives.UseMnemonic = true;
			this.lblContentInclusives.AutoSize = false;
			this.lblContentInclusives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblContentInclusives.Name = "lblContentInclusives";
			this.lblDepositExclusives.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositExclusives.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblDepositExclusives.Text = "0.00";
			this.lblDepositExclusives.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblDepositExclusives.Size = new System.Drawing.Size(233, 16);
			this.lblDepositExclusives.Location = new System.Drawing.Point(840, 16);
			this.lblDepositExclusives.TabIndex = 29;
			this.lblDepositExclusives.Visible = false;
			this.lblDepositExclusives.Enabled = true;
			this.lblDepositExclusives.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDepositExclusives.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositExclusives.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositExclusives.UseMnemonic = true;
			this.lblDepositExclusives.AutoSize = false;
			this.lblDepositExclusives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDepositExclusives.Name = "lblDepositExclusives";
			this.lblA.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblA.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblA.Text = "0.00";
			this.lblA.Enabled = false;
			this.lblA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblA.Size = new System.Drawing.Size(234, 16);
			this.lblA.Location = new System.Drawing.Point(215, 74);
			this.lblA.TabIndex = 28;
			this.lblA.Visible = false;
			this.lblA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblA.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblA.UseMnemonic = true;
			this.lblA.AutoSize = false;
			this.lblA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblA.Name = "lblA";
			this.lblB.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblB.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblB.Text = "0.00";
			this.lblB.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblB.Size = new System.Drawing.Size(234, 21);
			this.lblB.Location = new System.Drawing.Point(215, 43);
			this.lblB.TabIndex = 27;
			this.lblB.Enabled = true;
			this.lblB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblB.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblB.UseMnemonic = true;
			this.lblB.Visible = true;
			this.lblB.AutoSize = false;
			this.lblB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblB.Name = "lblB";
			this.lblC.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblC.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblC.Text = "0.00";
			this.lblC.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblC.Size = new System.Drawing.Size(233, 16);
			this.lblC.Location = new System.Drawing.Point(215, 112);
			this.lblC.TabIndex = 26;
			this.lblC.Visible = false;
			this.lblC.Enabled = true;
			this.lblC.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblC.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblC.UseMnemonic = true;
			this.lblC.AutoSize = false;
			this.lblC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblC.Name = "lblC";
			this._lblTotal_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_0.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_0.Text = "Person Cutting :";
			this._lblTotal_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_0.Size = new System.Drawing.Size(203, 21);
			this._lblTotal_0.Location = new System.Drawing.Point(0, 20);
			this._lblTotal_0.TabIndex = 25;
			this._lblTotal_0.Enabled = true;
			this._lblTotal_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_0.UseMnemonic = true;
			this._lblTotal_0.Visible = true;
			this._lblTotal_0.AutoSize = false;
			this._lblTotal_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_0.Name = "_lblTotal_0";
			this._lblTotal_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_1.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_1.Text = "Price Per Kg :";
			this._lblTotal_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_1.Size = new System.Drawing.Size(203, 16);
			this._lblTotal_1.Location = new System.Drawing.Point(2, 38);
			this._lblTotal_1.TabIndex = 24;
			this._lblTotal_1.Visible = false;
			this._lblTotal_1.Enabled = true;
			this._lblTotal_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_1.UseMnemonic = true;
			this._lblTotal_1.AutoSize = false;
			this._lblTotal_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_1.Name = "_lblTotal_1";
			this._lblTotal_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_2.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_2.Text = "Total Weight Purchased :";
			this._lblTotal_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_2.Size = new System.Drawing.Size(203, 16);
			this._lblTotal_2.Location = new System.Drawing.Point(2, 56);
			this._lblTotal_2.TabIndex = 23;
			this._lblTotal_2.Visible = false;
			this._lblTotal_2.Enabled = true;
			this._lblTotal_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_2.UseMnemonic = true;
			this._lblTotal_2.AutoSize = false;
			this._lblTotal_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_2.Name = "_lblTotal_2";
			this._lblTotal_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_3.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_3.Text = "Total Weight Used :";
			this._lblTotal_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_3.Size = new System.Drawing.Size(203, 16);
			this._lblTotal_3.Location = new System.Drawing.Point(2, 74);
			this._lblTotal_3.TabIndex = 22;
			this._lblTotal_3.Visible = false;
			this._lblTotal_3.Enabled = true;
			this._lblTotal_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_3.UseMnemonic = true;
			this._lblTotal_3.AutoSize = false;
			this._lblTotal_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_3.Name = "_lblTotal_3";
			this._lblTotal_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_4.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_4.Text = "Total Bag Available :";
			this._lblTotal_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_4.Size = new System.Drawing.Size(203, 21);
			this._lblTotal_4.Location = new System.Drawing.Point(2, 43);
			this._lblTotal_4.TabIndex = 21;
			this._lblTotal_4.Enabled = true;
			this._lblTotal_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_4.UseMnemonic = true;
			this._lblTotal_4.Visible = true;
			this._lblTotal_4.AutoSize = false;
			this._lblTotal_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_4.Name = "_lblTotal_4";
			this._lblTotal_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_5.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_5.Text = "Total Used :";
			this._lblTotal_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_5.Size = new System.Drawing.Size(203, 21);
			this._lblTotal_5.Location = new System.Drawing.Point(2, 66);
			this._lblTotal_5.TabIndex = 20;
			this._lblTotal_5.Enabled = true;
			this._lblTotal_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_5.UseMnemonic = true;
			this._lblTotal_5.Visible = true;
			this._lblTotal_5.AutoSize = false;
			this._lblTotal_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_5.Name = "_lblTotal_5";
			this.lblX.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblX.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			this.lblX.Text = "0.00";
			this.lblX.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblX.Size = new System.Drawing.Size(120, 16);
			this.lblX.Location = new System.Drawing.Point(616, 110);
			this.lblX.TabIndex = 19;
			this.lblX.Visible = false;
			this.lblX.Enabled = true;
			this.lblX.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblX.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblX.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblX.UseMnemonic = true;
			this.lblX.AutoSize = false;
			this.lblX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblX.Name = "lblX";
			this.lblGP_Y.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblGP_Y.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblGP_Y.Text = "0.00";
			this.lblGP_Y.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblGP_Y.Size = new System.Drawing.Size(120, 21);
			this.lblGP_Y.Location = new System.Drawing.Point(616, 43);
			this.lblGP_Y.TabIndex = 18;
			this.lblGP_Y.Enabled = true;
			this.lblGP_Y.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGP_Y.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblGP_Y.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGP_Y.UseMnemonic = true;
			this.lblGP_Y.Visible = true;
			this.lblGP_Y.AutoSize = false;
			this.lblGP_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGP_Y.Name = "lblGP_Y";
			this.lblB_Z.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblB_Z.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblB_Z.Text = "0.00";
			this.lblB_Z.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblB_Z.Size = new System.Drawing.Size(120, 21);
			this.lblB_Z.Location = new System.Drawing.Point(616, 66);
			this.lblB_Z.TabIndex = 17;
			this.lblB_Z.Enabled = true;
			this.lblB_Z.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblB_Z.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblB_Z.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblB_Z.UseMnemonic = true;
			this.lblB_Z.Visible = true;
			this.lblB_Z.AutoSize = false;
			this.lblB_Z.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblB_Z.Name = "lblB_Z";
			this._lblTotal_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_6.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_6.Text = "X - VAT+1 :";
			this._lblTotal_6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_6.Size = new System.Drawing.Size(133, 16);
			this._lblTotal_6.Location = new System.Drawing.Point(472, 110);
			this._lblTotal_6.TabIndex = 16;
			this._lblTotal_6.Visible = false;
			this._lblTotal_6.Enabled = true;
			this._lblTotal_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_6.UseMnemonic = true;
			this._lblTotal_6.AutoSize = false;
			this._lblTotal_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_6.Name = "_lblTotal_6";
			this._lblTotal_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_7.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_7.Text = "VAT :";
			this._lblTotal_7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_7.Size = new System.Drawing.Size(133, 16);
			this._lblTotal_7.Location = new System.Drawing.Point(472, 92);
			this._lblTotal_7.TabIndex = 15;
			this._lblTotal_7.Visible = false;
			this._lblTotal_7.Enabled = true;
			this._lblTotal_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_7.UseMnemonic = true;
			this._lblTotal_7.AutoSize = false;
			this._lblTotal_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_7.Name = "_lblTotal_7";
			this._lblTotal_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_8.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_8.Text = "Total Selling Price :";
			this._lblTotal_8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_8.Size = new System.Drawing.Size(133, 21);
			this._lblTotal_8.Location = new System.Drawing.Point(472, 43);
			this._lblTotal_8.TabIndex = 14;
			this._lblTotal_8.Enabled = true;
			this._lblTotal_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_8.UseMnemonic = true;
			this._lblTotal_8.Visible = true;
			this._lblTotal_8.AutoSize = false;
			this._lblTotal_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_8.Name = "_lblTotal_8";
			this._lblTotal_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_9.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_9.Text = "Total Cost :";
			this._lblTotal_9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_9.Size = new System.Drawing.Size(133, 21);
			this._lblTotal_9.Location = new System.Drawing.Point(472, 20);
			this._lblTotal_9.TabIndex = 13;
			this._lblTotal_9.Enabled = true;
			this._lblTotal_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_9.UseMnemonic = true;
			this._lblTotal_9.Visible = true;
			this._lblTotal_9.AutoSize = false;
			this._lblTotal_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_9.Name = "_lblTotal_9";
			this._lblTotal_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblTotal_10.BackColor = System.Drawing.Color.Transparent;
			this._lblTotal_10.Text = "Total GP :";
			this._lblTotal_10.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblTotal_10.Size = new System.Drawing.Size(133, 21);
			this._lblTotal_10.Location = new System.Drawing.Point(472, 66);
			this._lblTotal_10.TabIndex = 12;
			this._lblTotal_10.Enabled = true;
			this._lblTotal_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblTotal_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblTotal_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblTotal_10.UseMnemonic = true;
			this._lblTotal_10.Visible = true;
			this._lblTotal_10.AutoSize = false;
			this._lblTotal_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblTotal_10.Name = "_lblTotal_10";
			this._txtEdit_1.AutoSize = false;
			this._txtEdit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_1.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_1.Location = new System.Drawing.Point(350, 583);
			this._txtEdit_1.MaxLength = 10;
			this._txtEdit_1.TabIndex = 9;
			this._txtEdit_1.Tag = "0";
			this._txtEdit_1.Text = "0";
			this._txtEdit_1.Visible = false;
			this._txtEdit_1.AcceptsReturn = true;
			this._txtEdit_1.CausesValidation = true;
			this._txtEdit_1.Enabled = true;
			this._txtEdit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_1.HideSelection = true;
			this._txtEdit_1.ReadOnly = false;
			this._txtEdit_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_1.Multiline = false;
			this._txtEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_1.TabStop = true;
			this._txtEdit_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_1.Name = "_txtEdit_1";
			this._txtEdit_2.AutoSize = false;
			this._txtEdit_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtEdit_2.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this._txtEdit_2.Size = new System.Drawing.Size(55, 16);
			this._txtEdit_2.Location = new System.Drawing.Point(422, 583);
			this._txtEdit_2.MaxLength = 10;
			this._txtEdit_2.TabIndex = 8;
			this._txtEdit_2.Tag = "0";
			this._txtEdit_2.Text = "0";
			this._txtEdit_2.Visible = false;
			this._txtEdit_2.AcceptsReturn = true;
			this._txtEdit_2.CausesValidation = true;
			this._txtEdit_2.Enabled = true;
			this._txtEdit_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtEdit_2.HideSelection = true;
			this._txtEdit_2.ReadOnly = false;
			this._txtEdit_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtEdit_2.Multiline = false;
			this._txtEdit_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtEdit_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtEdit_2.TabStop = true;
			this._txtEdit_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtEdit_2.Name = "_txtEdit_2";
			this.Picture2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Picture2.BackColor = System.Drawing.Color.Blue;
			this.Picture2.Size = new System.Drawing.Size(1016, 49);
			this.Picture2.Location = new System.Drawing.Point(0, 0);
			this.Picture2.TabIndex = 5;
			this.Picture2.TabStop = false;
			this.Picture2.CausesValidation = true;
			this.Picture2.Enabled = true;
			this.Picture2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture2.Visible = true;
			this.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture2.Name = "Picture2";
			this.cmdReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdReg.Text = "&Register 4VEG";
			this.cmdReg.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdReg.Size = new System.Drawing.Size(115, 40);
			this.cmdReg.Location = new System.Drawing.Point(448, 3);
			this.cmdReg.TabIndex = 55;
			this.cmdReg.TabStop = false;
			this.cmdReg.Visible = false;
			this.cmdReg.BackColor = System.Drawing.SystemColors.Control;
			this.cmdReg.CausesValidation = true;
			this.cmdReg.Enabled = true;
			this.cmdReg.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdReg.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdReg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdReg.Name = "cmdReg";
			this.cmdProc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdProc.Text = "&Process";
			this.cmdProc.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdProc.Size = new System.Drawing.Size(67, 40);
			this.cmdProc.Location = new System.Drawing.Point(168, 3);
			this.cmdProc.TabIndex = 52;
			this.cmdProc.TabStop = false;
			this.cmdProc.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProc.CausesValidation = true;
			this.cmdProc.Enabled = true;
			this.cmdProc.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProc.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProc.Name = "cmdProc";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "P&rint";
			this.cmdPrint.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdPrint.Size = new System.Drawing.Size(67, 40);
			this.cmdPrint.Location = new System.Drawing.Point(88, 3);
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(67, 40);
			this.cmdExit.Location = new System.Drawing.Point(7, 3);
			this.cmdExit.TabIndex = 6;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			//gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridItem.Size = new System.Drawing.Size(901, 359);
			this.gridItem.Location = new System.Drawing.Point(3, 200);
			this.gridItem.TabIndex = 4;
			this.gridItem.Name = "gridItem";
			this.Controls.Add(AvailGRV);
			this.Controls.Add(picTotal);
			this.Controls.Add(_txtEdit_0);
			this.Controls.Add(frmTotals);
			this.Controls.Add(_txtEdit_1);
			this.Controls.Add(_txtEdit_2);
			this.Controls.Add(Picture2);
			this.Controls.Add(gridItem);
			this.picTotal.Controls.Add(lblTotalOP);
			this.picTotal.Controls.Add(lblTotalLP);
			this.picTotal.Controls.Add(lblTotalO);
			this.picTotal.Controls.Add(_lblTotal_17);
			this.picTotal.Controls.Add(lblTotalL);
			this.picTotal.Controls.Add(_lblTotal_16);
			this.picTotal.Controls.Add(lblTotalH);
			this.picTotal.Controls.Add(_lblTotal_15);
			this.picTotal.Controls.Add(lblTotalG);
			this.picTotal.Controls.Add(_lblTotal_14);
			this.picTotal.Controls.Add(_lblTotal_13);
			this.picTotal.Controls.Add(lblTotalQ);
			this.picTotal.Controls.Add(_lblTotal_12);
			this.picTotal.Controls.Add(lblTotalF);
			this.picTotal.Controls.Add(lblP);
			this.picTotal.Controls.Add(_lblTotal_11);
			this.frmTotals.Controls.Add(TotalQTY);
			this.frmTotals.Controls.Add(TotalQTYd);
			this.frmTotals.Controls.Add(txtR);
			this.frmTotals.Controls.Add(txtZ);
			this.frmTotals.Controls.Add(cmdTotal);
			this.frmTotals.Controls.Add(txtReqGP);
			this.frmTotals.Controls.Add(txtVAT);
			this.frmTotals.Controls.Add(lblQuantity);
			this.frmTotals.Controls.Add(_lbl_8);
			this.frmTotals.Controls.Add(lblBrokenPack);
			this.frmTotals.Controls.Add(_lbl_2);
			this.frmTotals.Controls.Add(lblContentExclusive);
			this.frmTotals.Controls.Add(lblContentInclusives);
			this.frmTotals.Controls.Add(lblDepositExclusives);
			this.frmTotals.Controls.Add(lblA);
			this.frmTotals.Controls.Add(lblB);
			this.frmTotals.Controls.Add(lblC);
			this.frmTotals.Controls.Add(_lblTotal_0);
			this.frmTotals.Controls.Add(_lblTotal_1);
			this.frmTotals.Controls.Add(_lblTotal_2);
			this.frmTotals.Controls.Add(_lblTotal_3);
			this.frmTotals.Controls.Add(_lblTotal_4);
			this.frmTotals.Controls.Add(_lblTotal_5);
			this.frmTotals.Controls.Add(lblX);
			this.frmTotals.Controls.Add(lblGP_Y);
			this.frmTotals.Controls.Add(lblB_Z);
			this.frmTotals.Controls.Add(_lblTotal_6);
			this.frmTotals.Controls.Add(_lblTotal_7);
			this.frmTotals.Controls.Add(_lblTotal_8);
			this.frmTotals.Controls.Add(_lblTotal_9);
			this.frmTotals.Controls.Add(_lblTotal_10);
			this.Picture2.Controls.Add(cmdReg);
			this.Picture2.Controls.Add(cmdProc);
			this.Picture2.Controls.Add(cmdPrint);
			this.Picture2.Controls.Add(cmdExit);
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lblTotal.SetIndex(_lblTotal_17, CType(17, Short))
			//Me.lblTotal.SetIndex(_lblTotal_16, CType(16, Short))
			//Me.lblTotal.SetIndex(_lblTotal_15, CType(15, Short))
			//Me.lblTotal.SetIndex(_lblTotal_14, CType(14, Short))
			//Me.lblTotal.SetIndex(_lblTotal_13, CType(13, Short))
			//Me.lblTotal.SetIndex(_lblTotal_12, CType(12, Short))
			//Me.lblTotal.SetIndex(_lblTotal_11, CType(11, Short))
			//Me.lblTotal.SetIndex(_lblTotal_0, CType(0, Short))
			//Me.lblTotal.SetIndex(_lblTotal_1, CType(1, Short))
			//Me.lblTotal.SetIndex(_lblTotal_2, CType(2, Short))
			//Me.lblTotal.SetIndex(_lblTotal_3, CType(3, Short))
			//Me.lblTotal.SetIndex(_lblTotal_4, CType(4, Short))
			//Me.lblTotal.SetIndex(_lblTotal_5, CType(5, Short))
			//Me.lblTotal.SetIndex(_lblTotal_6, CType(6, Short))
			//Me.lblTotal.SetIndex(_lblTotal_7, CType(7, Short))
			//Me.lblTotal.SetIndex(_lblTotal_8, CType(8, Short))
			//Me.lblTotal.SetIndex(_lblTotal_9, CType(9, Short))
			//Me.lblTotal.SetIndex(_lblTotal_10, CType(10, Short))
			//Me.txtEdit.SetIndex(_txtEdit_0, CType(0, Short))
			//Me.txtEdit.SetIndex(_txtEdit_1, CType(1, Short))
			//Me.txtEdit.SetIndex(_txtEdit_2, CType(2, Short))
			//CType(Me.txtEdit, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.gridItem).EndInit();
			this.picTotal.ResumeLayout(false);
			this.frmTotals.ResumeLayout(false);
			this.Picture2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
