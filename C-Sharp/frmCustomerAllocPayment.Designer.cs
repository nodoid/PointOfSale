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
	partial class frmCustomerAllocPayment
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmCustomerAllocPayment() : base()
		{
			FormClosed += frmCustomerAllocPayment_FormClosed;
			KeyDown += frmCustomerAllocPayment_KeyDown;
			Resize += frmCustomerAllocPayment_Resize;
			Load += frmCustomerAllocPayment_Load;
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
		public System.Windows.Forms.Button cmdAllocateFull;
		public System.Windows.Forms.Button cmdAllocate;
		public System.Windows.Forms.ComboBox cmbMonth;
		public System.Windows.Forms.TextBox txtCustomer;
		private System.Windows.Forms.Button withEventsField_cmdSearch;
		public System.Windows.Forms.Button cmdSearch {
			get { return withEventsField_cmdSearch; }
			set {
				if (withEventsField_cmdSearch != null) {
					withEventsField_cmdSearch.Click -= cmdsearch_Click;
				}
				withEventsField_cmdSearch = value;
				if (withEventsField_cmdSearch != null) {
					withEventsField_cmdSearch.Click += cmdsearch_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cmbPOS;
		public System.Windows.Forms.TextBox txtStock;
		public System.Windows.Forms.Button cmdPrint;
		public System.Windows.Forms.Button cmdProfit;
		public System.Windows.Forms.TextBox txtSerial;
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.ComboBox cmbTerms;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_3;
		public System.Windows.Forms.TextBox _txtFields_4;
		public System.Windows.Forms.TextBox _txtFields_5;
		public System.Windows.Forms.TextBox _txtFields_6;
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_8;
		public System.Windows.Forms.TextBox _txtFields_9;
		public System.Windows.Forms.TextBox _txtFields_10;
		public System.Windows.Forms.CheckBox _chkFields_11;
		public System.Windows.Forms.TextBox _txtFloat_12;
		public System.Windows.Forms.TextBox _txtFloat_13;
		public System.Windows.Forms.TextBox _txtFloat_14;
		public System.Windows.Forms.TextBox _txtFloat_15;
		public System.Windows.Forms.TextBox _txtFloat_16;
		public System.Windows.Forms.TextBox _txtFloat_17;
		public System.Windows.Forms.TextBox _txtFloat_18;
		public System.Windows.Forms.CheckBox _chkFields_19;
		public System.Windows.Forms.Button cmdInv;
		private System.Windows.Forms.Button withEventsField_cmdShowHistory;
		public System.Windows.Forms.Button cmdShowHistory {
			get { return withEventsField_cmdShowHistory; }
			set {
				if (withEventsField_cmdShowHistory != null) {
					withEventsField_cmdShowHistory.Click -= cmdShowHistory_Click;
				}
				withEventsField_cmdShowHistory = value;
				if (withEventsField_cmdShowHistory != null) {
					withEventsField_cmdShowHistory.Click += cmdShowHistory_Click;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
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
		private myDataGridView withEventsField_cmbChannel;
		public myDataGridView cmbChannel {
			get { return withEventsField_cmbChannel; }
			set {
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.KeyDown -= cmbChannel_KeyDown;
				}
				withEventsField_cmbChannel = value;
				if (withEventsField_cmbChannel != null) {
					withEventsField_cmbChannel.KeyDown += cmbChannel_KeyDown;
				}
			}
		}
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_5;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_6;
		public System.Windows.Forms.ColumnHeader _lvPayment_ColumnHeader_7;
		private System.Windows.Forms.ListView withEventsField_lvPayment;
		public System.Windows.Forms.ListView lvPayment {
			get { return withEventsField_lvPayment; }
			set {
				if (withEventsField_lvPayment != null) {
					withEventsField_lvPayment.Click -= lvPayment_Click;
				}
				withEventsField_lvPayment = value;
				if (withEventsField_lvPayment != null) {
					withEventsField_lvPayment.Click += lvPayment_Click;
				}
			}
		}
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_5;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_6;
		public System.Windows.Forms.ColumnHeader _lvTransaction_ColumnHeader_7;
		public System.Windows.Forms.ListView lvTransaction;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_5;
		public System.Windows.Forms.ColumnHeader _lvTransAlloc_ColumnHeader_6;
		public System.Windows.Forms.ListView lvTransAlloc;
		public System.Windows.Forms.Label _lbl_9;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label lblcount;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lblLabels_11;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblLabels_12;
		public System.Windows.Forms.Label _lblLabels_13;
		public System.Windows.Forms.Label _lblLabels_15;
		public System.Windows.Forms.Label _lblLabels_17;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_14;
		public System.Windows.Forms.Label _lblLabels_16;
		public System.Windows.Forms.Label _lblLabels_18;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
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
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdAllocateFull = new System.Windows.Forms.Button();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.txtCustomer = new System.Windows.Forms.TextBox();
			this.cmdSearch = new System.Windows.Forms.Button();
			this.cmbPOS = new System.Windows.Forms.ComboBox();
			this.txtStock = new System.Windows.Forms.TextBox();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdProfit = new System.Windows.Forms.Button();
			this.txtSerial = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.cmbTerms = new System.Windows.Forms.ComboBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_3 = new System.Windows.Forms.TextBox();
			this._txtFields_4 = new System.Windows.Forms.TextBox();
			this._txtFields_5 = new System.Windows.Forms.TextBox();
			this._txtFields_6 = new System.Windows.Forms.TextBox();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_8 = new System.Windows.Forms.TextBox();
			this._txtFields_9 = new System.Windows.Forms.TextBox();
			this._txtFields_10 = new System.Windows.Forms.TextBox();
			this._chkFields_11 = new System.Windows.Forms.CheckBox();
			this._txtFloat_12 = new System.Windows.Forms.TextBox();
			this._txtFloat_13 = new System.Windows.Forms.TextBox();
			this._txtFloat_14 = new System.Windows.Forms.TextBox();
			this._txtFloat_15 = new System.Windows.Forms.TextBox();
			this._txtFloat_16 = new System.Windows.Forms.TextBox();
			this._txtFloat_17 = new System.Windows.Forms.TextBox();
			this._txtFloat_18 = new System.Windows.Forms.TextBox();
			this._chkFields_19 = new System.Windows.Forms.CheckBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdInv = new System.Windows.Forms.Button();
			this.cmdShowHistory = new System.Windows.Forms.Button();
			this.cmdStatement = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmbChannel = new _4PosBackOffice.NET.myDataGridView();
			this.lvPayment = new System.Windows.Forms.ListView();
			this._lvPayment_ColumnHeader_1 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_2 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_3 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_4 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_5 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_6 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvPayment_ColumnHeader_7 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this.lvTransaction = new System.Windows.Forms.ListView();
			this._lvTransaction_ColumnHeader_1 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_2 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_3 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_4 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_5 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_6 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransaction_ColumnHeader_7 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this.lvTransAlloc = new System.Windows.Forms.ListView();
			this._lvTransAlloc_ColumnHeader_1 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransAlloc_ColumnHeader_2 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransAlloc_ColumnHeader_3 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransAlloc_ColumnHeader_4 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransAlloc_ColumnHeader_5 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lvTransAlloc_ColumnHeader_6 = (System.Windows.Forms.ColumnHeader)new System.Windows.Forms.ColumnHeader();
			this._lbl_9 = new System.Windows.Forms.Label();
			this._lbl_8 = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this.lblcount = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblLabels_11 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblLabels_12 = new System.Windows.Forms.Label();
			this._lblLabels_13 = new System.Windows.Forms.Label();
			this._lblLabels_15 = new System.Windows.Forms.Label();
			this._lblLabels_17 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_14 = new System.Windows.Forms.Label();
			this._lblLabels_16 = new System.Windows.Forms.Label();
			this._lblLabels_18 = new System.Windows.Forms.Label();
			this.Shape1 = new _4PosBackOffice.NET.RectangleShapeArray(this.components);
			this.picButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.cmbChannel).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.SuspendLayout();
			//
			//ShapeContainer1
			//
			this.ShapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.ShapeContainer1.Name = "ShapeContainer1";
			this.ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
				this._Shape1_0,
				this._Shape1_1
			});
			this.ShapeContainer1.Size = new System.Drawing.Size(659, 652);
			this.ShapeContainer1.TabIndex = 72;
			this.ShapeContainer1.TabStop = false;
			//
			//_Shape1_0
			//
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_0, Convert.ToInt16(0));
			this._Shape1_0.Location = new System.Drawing.Point(342, 57);
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_0.Size = new System.Drawing.Size(310, 111);
			//
			//_Shape1_1
			//
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this.Shape1.SetIndex(this._Shape1_1, Convert.ToInt16(1));
			this._Shape1_1.Location = new System.Drawing.Point(6, 57);
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_1.Size = new System.Drawing.Size(328, 112);
			//
			//Command1
			//
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(264, 480);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(129, 29);
			this.Command1.TabIndex = 71;
			this.Command1.TabStop = false;
			this.Command1.Text = "&Un-Allocate Payment";
			this.Command1.UseVisualStyleBackColor = false;
			//
			//cmdAllocateFull
			//
			this.cmdAllocateFull.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocateFull.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAllocateFull.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocateFull.Location = new System.Drawing.Point(400, 480);
			this.cmdAllocateFull.Name = "cmdAllocateFull";
			this.cmdAllocateFull.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocateFull.Size = new System.Drawing.Size(129, 29);
			this.cmdAllocateFull.TabIndex = 68;
			this.cmdAllocateFull.TabStop = false;
			this.cmdAllocateFull.Text = "&Allocate Full Payment";
			this.cmdAllocateFull.UseVisualStyleBackColor = false;
			//
			//cmdAllocate
			//
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Location = new System.Drawing.Point(536, 480);
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Size = new System.Drawing.Size(113, 29);
			this.cmdAllocate.TabIndex = 64;
			this.cmdAllocate.TabStop = false;
			this.cmdAllocate.Text = "&Allocate Partial";
			this.cmdAllocate.UseVisualStyleBackColor = false;
			//
			//cmbMonth
			//
			this.cmbMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbMonth.Location = new System.Drawing.Point(729, 188);
			this.cmbMonth.Name = "cmbMonth";
			this.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbMonth.Size = new System.Drawing.Size(112, 21);
			this.cmbMonth.TabIndex = 56;
			//
			//txtCustomer
			//
			this.txtCustomer.AcceptsReturn = true;
			this.txtCustomer.BackColor = System.Drawing.SystemColors.Window;
			this.txtCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCustomer.Location = new System.Drawing.Point(729, 266);
			this.txtCustomer.MaxLength = 0;
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCustomer.Size = new System.Drawing.Size(112, 19);
			this.txtCustomer.TabIndex = 55;
			//
			//cmdSearch
			//
			this.cmdSearch.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSearch.Location = new System.Drawing.Point(748, 372);
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSearch.Size = new System.Drawing.Size(94, 28);
			this.cmdSearch.TabIndex = 54;
			this.cmdSearch.Text = "&Search ...";
			this.cmdSearch.UseVisualStyleBackColor = false;
			//
			//cmbPOS
			//
			this.cmbPOS.BackColor = System.Drawing.SystemColors.Window;
			this.cmbPOS.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPOS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbPOS.Location = new System.Drawing.Point(729, 227);
			this.cmbPOS.Name = "cmbPOS";
			this.cmbPOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbPOS.Size = new System.Drawing.Size(112, 21);
			this.cmbPOS.TabIndex = 53;
			//
			//txtStock
			//
			this.txtStock.AcceptsReturn = true;
			this.txtStock.BackColor = System.Drawing.SystemColors.Window;
			this.txtStock.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtStock.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtStock.Location = new System.Drawing.Point(729, 302);
			this.txtStock.MaxLength = 0;
			this.txtStock.Name = "txtStock";
			this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtStock.Size = new System.Drawing.Size(112, 19);
			this.txtStock.TabIndex = 52;
			//
			//cmdPrint
			//
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Location = new System.Drawing.Point(750, 480);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Size = new System.Drawing.Size(94, 28);
			this.cmdPrint.TabIndex = 50;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.UseVisualStyleBackColor = false;
			//
			//cmdProfit
			//
			this.cmdProfit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdProfit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdProfit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdProfit.Location = new System.Drawing.Point(752, 526);
			this.cmdProfit.Name = "cmdProfit";
			this.cmdProfit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdProfit.Size = new System.Drawing.Size(94, 28);
			this.cmdProfit.TabIndex = 49;
			this.cmdProfit.TabStop = false;
			this.cmdProfit.Text = "&Detail Profit";
			this.cmdProfit.UseVisualStyleBackColor = false;
			//
			//txtSerial
			//
			this.txtSerial.AcceptsReturn = true;
			this.txtSerial.BackColor = System.Drawing.SystemColors.Window;
			this.txtSerial.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSerial.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSerial.Location = new System.Drawing.Point(730, 336);
			this.txtSerial.MaxLength = 0;
			this.txtSerial.Name = "txtSerial";
			this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSerial.Size = new System.Drawing.Size(112, 19);
			this.txtSerial.TabIndex = 48;
			//
			//_txtFields_0
			//
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.Enabled = false;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.Location = new System.Drawing.Point(924, 238);
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.Size = new System.Drawing.Size(226, 19);
			this._txtFields_0.TabIndex = 44;
			//
			//cmbTerms
			//
			this.cmbTerms.BackColor = System.Drawing.SystemColors.Window;
			this.cmbTerms.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTerms.Enabled = false;
			this.cmbTerms.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbTerms.Items.AddRange(new object[] {
				"C.O.D.",
				"Current",
				"30 Days",
				"60 Days",
				"90 Days"
			});
			this.cmbTerms.Location = new System.Drawing.Point(567, 63);
			this.cmbTerms.Name = "cmbTerms";
			this.cmbTerms.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbTerms.Size = new System.Drawing.Size(79, 21);
			this.cmbTerms.TabIndex = 23;
			//
			//_txtFields_2
			//
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.Enabled = false;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.Location = new System.Drawing.Point(102, 63);
			this._txtFields_2.MaxLength = 0;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.Size = new System.Drawing.Size(226, 19);
			this._txtFields_2.TabIndex = 2;
			//
			//_txtFields_3
			//
			this._txtFields_3.AcceptsReturn = true;
			this._txtFields_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_3.Enabled = false;
			this._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_3.Location = new System.Drawing.Point(102, 84);
			this._txtFields_3.MaxLength = 0;
			this._txtFields_3.Name = "_txtFields_3";
			this._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_3.Size = new System.Drawing.Size(226, 19);
			this._txtFields_3.TabIndex = 4;
			//
			//_txtFields_4
			//
			this._txtFields_4.AcceptsReturn = true;
			this._txtFields_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_4.Enabled = false;
			this._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_4.Location = new System.Drawing.Point(15, 120);
			this._txtFields_4.MaxLength = 0;
			this._txtFields_4.Name = "_txtFields_4";
			this._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_4.Size = new System.Drawing.Size(157, 19);
			this._txtFields_4.TabIndex = 6;
			//
			//_txtFields_5
			//
			this._txtFields_5.AcceptsReturn = true;
			this._txtFields_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_5.Enabled = false;
			this._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_5.Location = new System.Drawing.Point(174, 120);
			this._txtFields_5.MaxLength = 0;
			this._txtFields_5.Name = "_txtFields_5";
			this._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_5.Size = new System.Drawing.Size(154, 19);
			this._txtFields_5.TabIndex = 8;
			//
			//_txtFields_6
			//
			this._txtFields_6.AcceptsReturn = true;
			this._txtFields_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_6.Location = new System.Drawing.Point(918, 115);
			this._txtFields_6.MaxLength = 0;
			this._txtFields_6.Multiline = true;
			this._txtFields_6.Name = "_txtFields_6";
			this._txtFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_6.Size = new System.Drawing.Size(226, 58);
			this._txtFields_6.TabIndex = 16;
			//
			//_txtFields_7
			//
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.Location = new System.Drawing.Point(918, 175);
			this._txtFields_7.MaxLength = 0;
			this._txtFields_7.Multiline = true;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.Size = new System.Drawing.Size(226, 58);
			this._txtFields_7.TabIndex = 18;
			//
			//_txtFields_8
			//
			this._txtFields_8.AcceptsReturn = true;
			this._txtFields_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_8.Enabled = false;
			this._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_8.Location = new System.Drawing.Point(102, 144);
			this._txtFields_8.MaxLength = 0;
			this._txtFields_8.Name = "_txtFields_8";
			this._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_8.Size = new System.Drawing.Size(226, 19);
			this._txtFields_8.TabIndex = 10;
			//
			//_txtFields_9
			//
			this._txtFields_9.AcceptsReturn = true;
			this._txtFields_9.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_9.Enabled = false;
			this._txtFields_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_9.Location = new System.Drawing.Point(926, 261);
			this._txtFields_9.MaxLength = 0;
			this._txtFields_9.Name = "_txtFields_9";
			this._txtFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_9.Size = new System.Drawing.Size(226, 19);
			this._txtFields_9.TabIndex = 12;
			//
			//_txtFields_10
			//
			this._txtFields_10.AcceptsReturn = true;
			this._txtFields_10.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_10.Enabled = false;
			this._txtFields_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_10.Location = new System.Drawing.Point(926, 282);
			this._txtFields_10.MaxLength = 0;
			this._txtFields_10.Name = "_txtFields_10";
			this._txtFields_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_10.Size = new System.Drawing.Size(226, 19);
			this._txtFields_10.TabIndex = 14;
			//
			//_chkFields_11
			//
			this._chkFields_11.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_11.Location = new System.Drawing.Point(829, 83);
			this._chkFields_11.Name = "_chkFields_11";
			this._chkFields_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_11.Size = new System.Drawing.Size(214, 19);
			this._chkFields_11.TabIndex = 39;
			this._chkFields_11.Text = "Disable this customer from Point Of Sale:";
			this._chkFields_11.UseVisualStyleBackColor = false;
			//
			//_txtFloat_12
			//
			this._txtFloat_12.AcceptsReturn = true;
			this._txtFloat_12.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_12.Enabled = false;
			this._txtFloat_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_12.Location = new System.Drawing.Point(423, 63);
			this._txtFloat_12.MaxLength = 0;
			this._txtFloat_12.Name = "_txtFloat_12";
			this._txtFloat_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_12.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_12.TabIndex = 21;
			this._txtFloat_12.Text = "9,999,999.00";
			this._txtFloat_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_13
			//
			this._txtFloat_13.AcceptsReturn = true;
			this._txtFloat_13.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_13.Enabled = false;
			this._txtFloat_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_13.Location = new System.Drawing.Point(423, 87);
			this._txtFloat_13.MaxLength = 0;
			this._txtFloat_13.Name = "_txtFloat_13";
			this._txtFloat_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_13.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_13.TabIndex = 25;
			this._txtFloat_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_14
			//
			this._txtFloat_14.AcceptsReturn = true;
			this._txtFloat_14.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_14.Enabled = false;
			this._txtFloat_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_14.Location = new System.Drawing.Point(567, 87);
			this._txtFloat_14.MaxLength = 0;
			this._txtFloat_14.Name = "_txtFloat_14";
			this._txtFloat_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_14.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_14.TabIndex = 27;
			this._txtFloat_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_15
			//
			this._txtFloat_15.AcceptsReturn = true;
			this._txtFloat_15.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_15.Enabled = false;
			this._txtFloat_15.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_15.Location = new System.Drawing.Point(423, 108);
			this._txtFloat_15.MaxLength = 0;
			this._txtFloat_15.Name = "_txtFloat_15";
			this._txtFloat_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_15.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_15.TabIndex = 29;
			this._txtFloat_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_16
			//
			this._txtFloat_16.AcceptsReturn = true;
			this._txtFloat_16.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_16.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_16.Enabled = false;
			this._txtFloat_16.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_16.Location = new System.Drawing.Point(567, 108);
			this._txtFloat_16.MaxLength = 0;
			this._txtFloat_16.Name = "_txtFloat_16";
			this._txtFloat_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_16.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_16.TabIndex = 31;
			this._txtFloat_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_17
			//
			this._txtFloat_17.AcceptsReturn = true;
			this._txtFloat_17.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_17.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_17.Enabled = false;
			this._txtFloat_17.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_17.Location = new System.Drawing.Point(423, 129);
			this._txtFloat_17.MaxLength = 0;
			this._txtFloat_17.Name = "_txtFloat_17";
			this._txtFloat_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_17.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_17.TabIndex = 33;
			this._txtFloat_17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_txtFloat_18
			//
			this._txtFloat_18.AcceptsReturn = true;
			this._txtFloat_18.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_18.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_18.Enabled = false;
			this._txtFloat_18.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_18.Location = new System.Drawing.Point(567, 129);
			this._txtFloat_18.MaxLength = 0;
			this._txtFloat_18.Name = "_txtFloat_18";
			this._txtFloat_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_18.Size = new System.Drawing.Size(79, 19);
			this._txtFloat_18.TabIndex = 35;
			this._txtFloat_18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//_chkFields_19
			//
			this._chkFields_19.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this._chkFields_19.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_19.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_19.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_19.Location = new System.Drawing.Point(811, 65);
			this._chkFields_19.Name = "_chkFields_19";
			this._chkFields_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_19.Size = new System.Drawing.Size(232, 19);
			this._chkFields_19.TabIndex = 38;
			this._chkFields_19.Text = "Automatically print a statement at monthend:";
			this._chkFields_19.UseVisualStyleBackColor = false;
			//
			//picButtons
			//
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Controls.Add(this.cmdInv);
			this.picButtons.Controls.Add(this.cmdShowHistory);
			this.picButtons.Controls.Add(this.cmdStatement);
			this.picButtons.Controls.Add(this.cmdCancel);
			this.picButtons.Controls.Add(this.cmdClose);
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.Name = "picButtons";
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Size = new System.Drawing.Size(659, 38);
			this.picButtons.TabIndex = 42;
			//
			//cmdInv
			//
			this.cmdInv.BackColor = System.Drawing.SystemColors.Control;
			this.cmdInv.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdInv.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdInv.Location = new System.Drawing.Point(211, 3);
			this.cmdInv.Name = "cmdInv";
			this.cmdInv.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdInv.Size = new System.Drawing.Size(73, 29);
			this.cmdInv.TabIndex = 47;
			this.cmdInv.TabStop = false;
			this.cmdInv.Text = "&Print";
			this.cmdInv.UseVisualStyleBackColor = false;
			this.cmdInv.Visible = false;
			//
			//cmdShowHistory
			//
			this.cmdShowHistory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShowHistory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShowHistory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShowHistory.Location = new System.Drawing.Point(88, 3);
			this.cmdShowHistory.Name = "cmdShowHistory";
			this.cmdShowHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShowHistory.Size = new System.Drawing.Size(113, 29);
			this.cmdShowHistory.TabIndex = 46;
			this.cmdShowHistory.TabStop = false;
			this.cmdShowHistory.Text = "&allocate";
			this.cmdShowHistory.UseVisualStyleBackColor = false;
			this.cmdShowHistory.Visible = false;
			//
			//cmdStatement
			//
			this.cmdStatement.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStatement.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStatement.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStatement.Location = new System.Drawing.Point(344, 3);
			this.cmdStatement.Name = "cmdStatement";
			this.cmdStatement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStatement.Size = new System.Drawing.Size(73, 29);
			this.cmdStatement.TabIndex = 43;
			this.cmdStatement.TabStop = false;
			this.cmdStatement.Text = "&Statement";
			this.cmdStatement.UseVisualStyleBackColor = false;
			this.cmdStatement.Visible = false;
			//
			//cmdCancel
			//
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.TabIndex = 40;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.UseVisualStyleBackColor = false;
			//
			//cmdClose
			//
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(576, 3);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.TabIndex = 41;
			this.cmdClose.TabStop = false;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.UseVisualStyleBackColor = false;
			//
			//cmbChannel
			//
			this.cmbChannel.AllowAddNew = true;
			this.cmbChannel.BoundText = "";
			this.cmbChannel.CellBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cmbChannel.Col = 0;
			this.cmbChannel.CtlText = "";
			this.cmbChannel.DataField = null;
			this.cmbChannel.Location = new System.Drawing.Point(823, 38);
			this.cmbChannel.Name = "cmbChannel";
			this.cmbChannel.row = 0;
			this.cmbChannel.Size = new System.Drawing.Size(223, 21);
			this.cmbChannel.TabIndex = 37;
			this.cmbChannel.TopRow = 0;
			//
			//lvPayment
			//
			this.lvPayment.BackColor = System.Drawing.SystemColors.Window;
			this.lvPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this._lvPayment_ColumnHeader_1,
				this._lvPayment_ColumnHeader_2,
				this._lvPayment_ColumnHeader_3,
				this._lvPayment_ColumnHeader_4,
				this._lvPayment_ColumnHeader_5,
				this._lvPayment_ColumnHeader_6,
				this._lvPayment_ColumnHeader_7
			});
			this.lvPayment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvPayment.FullRowSelect = true;
			this.lvPayment.GridLines = true;
			this.lvPayment.HideSelection = false;
			this.lvPayment.LabelWrap = false;
			this.lvPayment.Location = new System.Drawing.Point(7, 192);
			this.lvPayment.Name = "lvPayment";
			this.lvPayment.Size = new System.Drawing.Size(646, 121);
			this.lvPayment.TabIndex = 51;
			this.lvPayment.UseCompatibleStateImageBehavior = false;
			this.lvPayment.View = System.Windows.Forms.View.Details;
			//
			//_lvPayment_ColumnHeader_1
			//
			this._lvPayment_ColumnHeader_1.Text = "Date";
			this._lvPayment_ColumnHeader_1.Width = 200;
			//
			//_lvPayment_ColumnHeader_2
			//
			this._lvPayment_ColumnHeader_2.Text = "Reference";
			this._lvPayment_ColumnHeader_2.Width = 294;
			//
			//_lvPayment_ColumnHeader_3
			//
			this._lvPayment_ColumnHeader_3.Text = "Type";
			this._lvPayment_ColumnHeader_3.Width = 177;
			//
			//_lvPayment_ColumnHeader_4
			//
			this._lvPayment_ColumnHeader_4.Text = "Debit";
			this._lvPayment_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvPayment_ColumnHeader_4.Width = 0;
			//
			//_lvPayment_ColumnHeader_5
			//
			this._lvPayment_ColumnHeader_5.Text = "Credit";
			this._lvPayment_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvPayment_ColumnHeader_5.Width = 142;
			//
			//_lvPayment_ColumnHeader_6
			//
			this._lvPayment_ColumnHeader_6.Text = "Allocated";
			this._lvPayment_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvPayment_ColumnHeader_6.Width = 170;
			//
			//_lvPayment_ColumnHeader_7
			//
			this._lvPayment_ColumnHeader_7.Text = "Available";
			this._lvPayment_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvPayment_ColumnHeader_7.Width = 142;
			//
			//lvTransaction
			//
			this.lvTransaction.BackColor = System.Drawing.SystemColors.Window;
			this.lvTransaction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this._lvTransaction_ColumnHeader_1,
				this._lvTransaction_ColumnHeader_2,
				this._lvTransaction_ColumnHeader_3,
				this._lvTransaction_ColumnHeader_4,
				this._lvTransaction_ColumnHeader_5,
				this._lvTransaction_ColumnHeader_6,
				this._lvTransaction_ColumnHeader_7
			});
			this.lvTransaction.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvTransaction.FullRowSelect = true;
			this.lvTransaction.GridLines = true;
			this.lvTransaction.HideSelection = false;
			this.lvTransaction.LabelWrap = false;
			this.lvTransaction.Location = new System.Drawing.Point(8, 336);
			this.lvTransaction.Name = "lvTransaction";
			this.lvTransaction.Size = new System.Drawing.Size(646, 137);
			this.lvTransaction.TabIndex = 65;
			this.lvTransaction.UseCompatibleStateImageBehavior = false;
			this.lvTransaction.View = System.Windows.Forms.View.Details;
			//
			//_lvTransaction_ColumnHeader_1
			//
			this._lvTransaction_ColumnHeader_1.Text = "Date";
			this._lvTransaction_ColumnHeader_1.Width = 200;
			//
			//_lvTransaction_ColumnHeader_2
			//
			this._lvTransaction_ColumnHeader_2.Text = "Reference";
			this._lvTransaction_ColumnHeader_2.Width = 294;
			//
			//_lvTransaction_ColumnHeader_3
			//
			this._lvTransaction_ColumnHeader_3.Text = "Type";
			this._lvTransaction_ColumnHeader_3.Width = 177;
			//
			//_lvTransaction_ColumnHeader_4
			//
			this._lvTransaction_ColumnHeader_4.Text = "Debit";
			this._lvTransaction_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransaction_ColumnHeader_4.Width = 142;
			//
			//_lvTransaction_ColumnHeader_5
			//
			this._lvTransaction_ColumnHeader_5.Text = "Credit";
			this._lvTransaction_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransaction_ColumnHeader_5.Width = 0;
			//
			//_lvTransaction_ColumnHeader_6
			//
			this._lvTransaction_ColumnHeader_6.Text = "Allocated";
			this._lvTransaction_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransaction_ColumnHeader_6.Width = 170;
			//
			//_lvTransaction_ColumnHeader_7
			//
			this._lvTransaction_ColumnHeader_7.Text = "Outstanding";
			this._lvTransaction_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransaction_ColumnHeader_7.Width = 142;
			//
			//lvTransAlloc
			//
			this.lvTransAlloc.BackColor = System.Drawing.SystemColors.Window;
			this.lvTransAlloc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this._lvTransAlloc_ColumnHeader_1,
				this._lvTransAlloc_ColumnHeader_2,
				this._lvTransAlloc_ColumnHeader_3,
				this._lvTransAlloc_ColumnHeader_4,
				this._lvTransAlloc_ColumnHeader_5,
				this._lvTransAlloc_ColumnHeader_6
			});
			this.lvTransAlloc.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvTransAlloc.FullRowSelect = true;
			this.lvTransAlloc.GridLines = true;
			this.lvTransAlloc.HideSelection = false;
			this.lvTransAlloc.LabelWrap = false;
			this.lvTransAlloc.Location = new System.Drawing.Point(8, 512);
			this.lvTransAlloc.Name = "lvTransAlloc";
			this.lvTransAlloc.Size = new System.Drawing.Size(646, 129);
			this.lvTransAlloc.TabIndex = 70;
			this.lvTransAlloc.UseCompatibleStateImageBehavior = false;
			this.lvTransAlloc.View = System.Windows.Forms.View.Details;
			//
			//_lvTransAlloc_ColumnHeader_1
			//
			this._lvTransAlloc_ColumnHeader_1.Text = "Date";
			this._lvTransAlloc_ColumnHeader_1.Width = 200;
			//
			//_lvTransAlloc_ColumnHeader_2
			//
			this._lvTransAlloc_ColumnHeader_2.Text = "Reference";
			this._lvTransAlloc_ColumnHeader_2.Width = 294;
			//
			//_lvTransAlloc_ColumnHeader_3
			//
			this._lvTransAlloc_ColumnHeader_3.Text = "Type";
			this._lvTransAlloc_ColumnHeader_3.Width = 177;
			//
			//_lvTransAlloc_ColumnHeader_4
			//
			this._lvTransAlloc_ColumnHeader_4.Text = "Debit";
			this._lvTransAlloc_ColumnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransAlloc_ColumnHeader_4.Width = 142;
			//
			//_lvTransAlloc_ColumnHeader_5
			//
			this._lvTransAlloc_ColumnHeader_5.Text = "Credit";
			this._lvTransAlloc_ColumnHeader_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransAlloc_ColumnHeader_5.Width = 0;
			//
			//_lvTransAlloc_ColumnHeader_6
			//
			this._lvTransAlloc_ColumnHeader_6.Text = "Allocated";
			this._lvTransAlloc_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._lvTransAlloc_ColumnHeader_6.Width = 170;
			//
			//_lbl_9
			//
			this._lbl_9.AutoSize = true;
			this._lbl_9.BackColor = System.Drawing.Color.Transparent;
			this._lbl_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_9.Location = new System.Drawing.Point(8, 496);
			this._lbl_9.Name = "_lbl_9";
			this._lbl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_9.Size = new System.Drawing.Size(126, 14);
			this._lbl_9.TabIndex = 69;
			this._lbl_9.Text = "&5. Invoices - Allocated";
			//
			//_lbl_8
			//
			this._lbl_8.AutoSize = true;
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Location = new System.Drawing.Point(8, 320);
			this._lbl_8.Name = "_lbl_8";
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.Size = new System.Drawing.Size(138, 14);
			this._lbl_8.TabIndex = 67;
			this._lbl_8.Text = "&4. Invoices - Unallocated";
			//
			//_lbl_7
			//
			this._lbl_7.AutoSize = true;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Location = new System.Drawing.Point(8, 176);
			this._lbl_7.Name = "_lbl_7";
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.Size = new System.Drawing.Size(74, 14);
			this._lbl_7.TabIndex = 66;
			this._lbl_7.Text = "&3. Payments";
			//
			//lblcount
			//
			this.lblcount.AutoSize = true;
			this.lblcount.BackColor = System.Drawing.SystemColors.Control;
			this.lblcount.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblcount.Font = new System.Drawing.Font("Arial", 13.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblcount.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblcount.Location = new System.Drawing.Point(791, 442);
			this.lblcount.Name = "lblcount";
			this.lblcount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblcount.Size = new System.Drawing.Size(57, 21);
			this.lblcount.TabIndex = 63;
			this.lblcount.Text = "0 of 0";
			this.lblcount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_6
			//
			this._lbl_6.AutoSize = true;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Location = new System.Drawing.Point(729, 173);
			this._lbl_6.Name = "_lbl_6";
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.Size = new System.Drawing.Size(49, 13);
			this._lbl_6.TabIndex = 62;
			this._lbl_6.Text = "&1. Month";
			//
			//_lbl_5
			//
			this._lbl_5.AutoSize = true;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Location = new System.Drawing.Point(729, 212);
			this._lbl_5.Name = "_lbl_5";
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.Size = new System.Drawing.Size(81, 13);
			this._lbl_5.TabIndex = 61;
			this._lbl_5.Text = "&2. Point Of Sale";
			//
			//_lbl_2
			//
			this._lbl_2.AutoSize = true;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Location = new System.Drawing.Point(729, 251);
			this._lbl_2.Name = "_lbl_2";
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.Size = new System.Drawing.Size(92, 13);
			this._lbl_2.TabIndex = 60;
			this._lbl_2.Text = "&3. Customer name";
			//
			//_lbl_3
			//
			this._lbl_3.AutoSize = true;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Location = new System.Drawing.Point(729, 287);
			this._lbl_3.Name = "_lbl_3";
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.Size = new System.Drawing.Size(101, 13);
			this._lbl_3.TabIndex = 59;
			this._lbl_3.Text = "&4. Stock Item Name";
			//
			//_lbl_4
			//
			this._lbl_4.AutoSize = true;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Location = new System.Drawing.Point(736, 416);
			this._lbl_4.Name = "_lbl_4";
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.Size = new System.Drawing.Size(101, 13);
			this._lbl_4.TabIndex = 58;
			this._lbl_4.Text = "&4. Stock Item Name";
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(729, 322);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(99, 15);
			this.Label1.TabIndex = 57;
			this.Label1.Text = "&5: Serial Number";
			//
			//_lblLabels_11
			//
			this._lblLabels_11.AutoSize = true;
			this._lblLabels_11.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_11.Location = new System.Drawing.Point(855, 241);
			this._lblLabels_11.Name = "_lblLabels_11";
			this._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_11.Size = new System.Drawing.Size(71, 13);
			this._lblLabels_11.TabIndex = 45;
			this._lblLabels_11.Text = "VAT Number:";
			this._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_0
			//
			this._lbl_0.AutoSize = true;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Location = new System.Drawing.Point(342, 42);
			this._lbl_0.Name = "_lbl_0";
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.Size = new System.Drawing.Size(73, 14);
			this._lbl_0.TabIndex = 19;
			this._lbl_0.Text = "&2. Financials";
			//
			//_lblLabels_12
			//
			this._lblLabels_12.AutoSize = true;
			this._lblLabels_12.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_12.Location = new System.Drawing.Point(363, 66);
			this._lblLabels_12.Name = "_lblLabels_12";
			this._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_12.Size = new System.Drawing.Size(61, 13);
			this._lblLabels_12.TabIndex = 20;
			this._lblLabels_12.Text = "Credit Limit:";
			this._lblLabels_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_13
			//
			this._lblLabels_13.AutoSize = true;
			this._lblLabels_13.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_13.Location = new System.Drawing.Point(381, 90);
			this._lblLabels_13.Name = "_lblLabels_13";
			this._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_13.Size = new System.Drawing.Size(44, 13);
			this._lblLabels_13.TabIndex = 24;
			this._lblLabels_13.Text = "Current:";
			this._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_15
			//
			this._lblLabels_15.AutoSize = true;
			this._lblLabels_15.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_15.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_15.Location = new System.Drawing.Point(375, 111);
			this._lblLabels_15.Name = "_lblLabels_15";
			this._lblLabels_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_15.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_15.TabIndex = 28;
			this._lblLabels_15.Text = "60 Days:";
			this._lblLabels_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_17
			//
			this._lblLabels_17.AutoSize = true;
			this._lblLabels_17.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_17.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_17.Location = new System.Drawing.Point(369, 132);
			this._lblLabels_17.Name = "_lblLabels_17";
			this._lblLabels_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_17.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_17.TabIndex = 32;
			this._lblLabels_17.Text = "120 Days:";
			this._lblLabels_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_0
			//
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Location = new System.Drawing.Point(530, 66);
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.Size = new System.Drawing.Size(39, 13);
			this._lblLabels_0.TabIndex = 22;
			this._lblLabels_0.Text = "Terms:";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lbl_1
			//
			this._lbl_1.AutoSize = true;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Location = new System.Drawing.Point(6, 42);
			this._lbl_1.Name = "_lbl_1";
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.Size = new System.Drawing.Size(62, 14);
			this._lbl_1.TabIndex = 0;
			this._lbl_1.Text = "&1. General";
			//
			//_lblLabels_1
			//
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Location = new System.Drawing.Point(755, 44);
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.Size = new System.Drawing.Size(73, 13);
			this._lblLabels_1.TabIndex = 36;
			this._lblLabels_1.Text = "Sale Channel:";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_2
			//
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Location = new System.Drawing.Point(12, 63);
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.Size = new System.Drawing.Size(83, 14);
			this._lblLabels_2.TabIndex = 1;
			this._lblLabels_2.Text = "Invoice Name:";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_3
			//
			this._lblLabels_3.AutoSize = true;
			this._lblLabels_3.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_3.Location = new System.Drawing.Point(36, 84);
			this._lblLabels_3.Name = "_lblLabels_3";
			this._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_3.Size = new System.Drawing.Size(65, 13);
			this._lblLabels_3.TabIndex = 3;
			this._lblLabels_3.Text = "Department:";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_4
			//
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Location = new System.Drawing.Point(9, 108);
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.Size = new System.Drawing.Size(156, 14);
			this._lblLabels_4.TabIndex = 5;
			this._lblLabels_4.Text = "Responsible Person Name:";
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_5
			//
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Location = new System.Drawing.Point(174, 108);
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.Size = new System.Drawing.Size(60, 14);
			this._lblLabels_5.TabIndex = 7;
			this._lblLabels_5.Text = "Surname:";
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_6
			//
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Location = new System.Drawing.Point(819, 112);
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.Size = new System.Drawing.Size(90, 13);
			this._lblLabels_6.TabIndex = 15;
			this._lblLabels_6.Text = "Physical Address:";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_7
			//
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Location = new System.Drawing.Point(837, 172);
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.Size = new System.Drawing.Size(80, 13);
			this._lblLabels_7.TabIndex = 17;
			this._lblLabels_7.Text = "Postal Address:";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_8
			//
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Location = new System.Drawing.Point(42, 144);
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.Size = new System.Drawing.Size(61, 13);
			this._lblLabels_8.TabIndex = 9;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_9
			//
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Location = new System.Drawing.Point(899, 261);
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.Size = new System.Drawing.Size(27, 13);
			this._lblLabels_9.TabIndex = 11;
			this._lblLabels_9.Text = "Fax:";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_10
			//
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Location = new System.Drawing.Point(893, 282);
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.Size = new System.Drawing.Size(35, 13);
			this._lblLabels_10.TabIndex = 13;
			this._lblLabels_10.Text = "Email:";
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_14
			//
			this._lblLabels_14.AutoSize = true;
			this._lblLabels_14.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_14.Location = new System.Drawing.Point(519, 87);
			this._lblLabels_14.Name = "_lblLabels_14";
			this._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_14.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_14.TabIndex = 26;
			this._lblLabels_14.Text = "30 Days:";
			this._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_16
			//
			this._lblLabels_16.AutoSize = true;
			this._lblLabels_16.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_16.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_16.Location = new System.Drawing.Point(519, 108);
			this._lblLabels_16.Name = "_lblLabels_16";
			this._lblLabels_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_16.Size = new System.Drawing.Size(49, 13);
			this._lblLabels_16.TabIndex = 30;
			this._lblLabels_16.Text = "90 Days:";
			this._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//_lblLabels_18
			//
			this._lblLabels_18.AutoSize = true;
			this._lblLabels_18.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_18.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_18.Location = new System.Drawing.Point(513, 129);
			this._lblLabels_18.Name = "_lblLabels_18";
			this._lblLabels_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_18.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_18.TabIndex = 34;
			this._lblLabels_18.Text = "150 Days:";
			this._lblLabels_18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			//frmCustomerAllocPayment
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(224)));
			this.ClientSize = new System.Drawing.Size(659, 652);
			this.ControlBox = false;
			this.Controls.Add(this.Command1);
			this.Controls.Add(this.cmdAllocateFull);
			this.Controls.Add(this.cmdAllocate);
			this.Controls.Add(this.cmbMonth);
			this.Controls.Add(this.txtCustomer);
			this.Controls.Add(this.cmdSearch);
			this.Controls.Add(this.cmbPOS);
			this.Controls.Add(this.txtStock);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.cmdProfit);
			this.Controls.Add(this.txtSerial);
			this.Controls.Add(this._txtFields_0);
			this.Controls.Add(this.cmbTerms);
			this.Controls.Add(this._txtFields_2);
			this.Controls.Add(this._txtFields_3);
			this.Controls.Add(this._txtFields_4);
			this.Controls.Add(this._txtFields_5);
			this.Controls.Add(this._txtFields_6);
			this.Controls.Add(this._txtFields_7);
			this.Controls.Add(this._txtFields_8);
			this.Controls.Add(this._txtFields_9);
			this.Controls.Add(this._txtFields_10);
			this.Controls.Add(this._chkFields_11);
			this.Controls.Add(this._txtFloat_12);
			this.Controls.Add(this._txtFloat_13);
			this.Controls.Add(this._txtFloat_14);
			this.Controls.Add(this._txtFloat_15);
			this.Controls.Add(this._txtFloat_16);
			this.Controls.Add(this._txtFloat_17);
			this.Controls.Add(this._txtFloat_18);
			this.Controls.Add(this._chkFields_19);
			this.Controls.Add(this.picButtons);
			this.Controls.Add(this.cmbChannel);
			this.Controls.Add(this.lvPayment);
			this.Controls.Add(this.lvTransaction);
			this.Controls.Add(this.lvTransAlloc);
			this.Controls.Add(this._lbl_9);
			this.Controls.Add(this._lbl_8);
			this.Controls.Add(this._lbl_7);
			this.Controls.Add(this.lblcount);
			this.Controls.Add(this._lbl_6);
			this.Controls.Add(this._lbl_5);
			this.Controls.Add(this._lbl_2);
			this.Controls.Add(this._lbl_3);
			this.Controls.Add(this._lbl_4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._lblLabels_11);
			this.Controls.Add(this._lbl_0);
			this.Controls.Add(this._lblLabels_12);
			this.Controls.Add(this._lblLabels_13);
			this.Controls.Add(this._lblLabels_15);
			this.Controls.Add(this._lblLabels_17);
			this.Controls.Add(this._lblLabels_0);
			this.Controls.Add(this._lbl_1);
			this.Controls.Add(this._lblLabels_1);
			this.Controls.Add(this._lblLabels_2);
			this.Controls.Add(this._lblLabels_3);
			this.Controls.Add(this._lblLabels_4);
			this.Controls.Add(this._lblLabels_5);
			this.Controls.Add(this._lblLabels_6);
			this.Controls.Add(this._lblLabels_7);
			this.Controls.Add(this._lblLabels_8);
			this.Controls.Add(this._lblLabels_9);
			this.Controls.Add(this._lblLabels_10);
			this.Controls.Add(this._lblLabels_14);
			this.Controls.Add(this._lblLabels_16);
			this.Controls.Add(this._lblLabels_18);
			this.Controls.Add(this.ShapeContainer1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(73, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCustomerAllocPayment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payment Allocation";
			this.picButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.cmbChannel).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
