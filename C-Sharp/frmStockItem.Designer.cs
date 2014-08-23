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
	partial class frmStockItem
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmStockItem() : base()
		{
			FormClosed += frmStockItem_FormClosed;
			Resize += frmStockItem_Resize;
			Load += frmStockItem_Load;
			KeyPress += frmStockItem_KeyPress;
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
		public System.Windows.Forms.CheckBox _chkSerialTracking_1;
		public System.Windows.Forms.CheckBox _chkFields_6;
		public System.Windows.Forms.GroupBox Frame6;
		public System.Windows.Forms.CheckBox chkbarcode;
		public System.Windows.Forms.CheckBox chkshelf;
		public System.Windows.Forms.GroupBox Frame5;
		public System.Windows.Forms.CheckBox _chkFields_1;
		public System.Windows.Forms.CheckBox _chkSerialTracking_0;
		public System.Windows.Forms.GroupBox Frame3;
		private System.Windows.Forms.Button withEventsField_cmdReportGroup;
		public System.Windows.Forms.Button cmdReportGroup {
			get { return withEventsField_cmdReportGroup; }
			set {
				if (withEventsField_cmdReportGroup != null) {
					withEventsField_cmdReportGroup.Click -= cmdReportGroup_Click;
				}
				withEventsField_cmdReportGroup = value;
				if (withEventsField_cmdReportGroup != null) {
					withEventsField_cmdReportGroup.Click += cmdReportGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdStockGroup;
		public System.Windows.Forms.Button cmdStockGroup {
			get { return withEventsField_cmdStockGroup; }
			set {
				if (withEventsField_cmdStockGroup != null) {
					withEventsField_cmdStockGroup.Click -= cmdStockGroup_Click;
				}
				withEventsField_cmdStockGroup = value;
				if (withEventsField_cmdStockGroup != null) {
					withEventsField_cmdStockGroup.Click += cmdStockGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPricingGroup;
		public System.Windows.Forms.Button cmdPricingGroup {
			get { return withEventsField_cmdPricingGroup; }
			set {
				if (withEventsField_cmdPricingGroup != null) {
					withEventsField_cmdPricingGroup.Click -= cmdPricingGroup_Click;
				}
				withEventsField_cmdPricingGroup = value;
				if (withEventsField_cmdPricingGroup != null) {
					withEventsField_cmdPricingGroup.Click += cmdPricingGroup_Click;
				}
			}
		}
		private myDataGridView withEventsField_cmbPricingGroup;
		public myDataGridView cmbPricingGroup {
			get { return withEventsField_cmbPricingGroup; }
			set {
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown -= cmbPricingGroup_KeyDown;
				}
				withEventsField_cmbPricingGroup = value;
				if (withEventsField_cmbPricingGroup != null) {
					withEventsField_cmbPricingGroup.KeyDown += cmbPricingGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbStockGroup;
		public myDataGridView cmbStockGroup {
			get { return withEventsField_cmbStockGroup; }
			set {
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown -= cmbStockGroup_KeyDown;
				}
				withEventsField_cmbStockGroup = value;
				if (withEventsField_cmbStockGroup != null) {
					withEventsField_cmbStockGroup.KeyDown += cmbStockGroup_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbReportGroup;
		public myDataGridView cmbReportGroup {
			get { return withEventsField_cmbReportGroup; }
			set {
				if (withEventsField_cmbReportGroup != null) {
					withEventsField_cmbReportGroup.KeyDown -= cmbReportGroup_KeyDown;
				}
				withEventsField_cmbReportGroup = value;
				if (withEventsField_cmbReportGroup != null) {
					withEventsField_cmbReportGroup.KeyDown += cmbReportGroup_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_15;
		public System.Windows.Forms.Label _lblLabels_4;
		public System.Windows.Forms.Label _lblLabels_3;
		public System.Windows.Forms.GroupBox _Frame2_1;
		private System.Windows.Forms.Button withEventsField_cmdShrink;
		public System.Windows.Forms.Button cmdShrink {
			get { return withEventsField_cmdShrink; }
			set {
				if (withEventsField_cmdShrink != null) {
					withEventsField_cmdShrink.Click -= cmdShrink_Click;
				}
				withEventsField_cmdShrink = value;
				if (withEventsField_cmdShrink != null) {
					withEventsField_cmdShrink.Click += cmdShrink_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFloat_1;
		public System.Windows.Forms.TextBox _txtFloat_0;
		public System.Windows.Forms.TextBox _txtInteger_0;
		private myDataGridView withEventsField_cmbShrink;
		public myDataGridView cmbShrink {
			get { return withEventsField_cmbShrink; }
			set {
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown -= cmbShrink_KeyDown;
				}
				withEventsField_cmbShrink = value;
				if (withEventsField_cmbShrink != null) {
					withEventsField_cmbShrink.KeyDown += cmbShrink_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_11;
		public System.Windows.Forms.Label _lblLabels_10;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.GroupBox _Frame2_2;
		public System.Windows.Forms.ComboBox cmbReorder;
		public System.Windows.Forms.TextBox _txtInteger_3;
		public System.Windows.Forms.TextBox _txtInteger_1;
		public System.Windows.Forms.CheckBox _chkFields_0;
		public System.Windows.Forms.TextBox _txtInteger_2;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.GroupBox _Frame2_3;
		private System.Windows.Forms.Button withEventsField_cmdpriceselist;
		public System.Windows.Forms.Button cmdpriceselist {
			get { return withEventsField_cmdpriceselist; }
			set {
				if (withEventsField_cmdpriceselist != null) {
					withEventsField_cmdpriceselist.Click -= cmdpriceselist_Click;
				}
				withEventsField_cmdpriceselist = value;
				if (withEventsField_cmdpriceselist != null) {
					withEventsField_cmdpriceselist.Click += cmdpriceselist_Click;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_chkPriceSet;
		public System.Windows.Forms.CheckBox chkPriceSet {
			get { return withEventsField_chkPriceSet; }
			set {
				if (withEventsField_chkPriceSet != null) {
					withEventsField_chkPriceSet.CheckStateChanged -= chkPriceSet_CheckStateChanged;
				}
				withEventsField_chkPriceSet = value;
				if (withEventsField_chkPriceSet != null) {
					withEventsField_chkPriceSet.CheckStateChanged += chkPriceSet_CheckStateChanged;
				}
			}
		}
		private myDataGridView withEventsField_cmbPriceSet;
		public myDataGridView cmbPriceSet {
			get { return withEventsField_cmbPriceSet; }
			set {
				if (withEventsField_cmbPriceSet != null) {
					withEventsField_cmbPriceSet.CellValueChanged -= cmbPriceSet_Change;
					withEventsField_cmbPriceSet.KeyDown -= cmbPriceSet_KeyDown;
				}
				withEventsField_cmbPriceSet = value;
				if (withEventsField_cmbPriceSet != null) {
					withEventsField_cmbPriceSet.CellValueChanged += cmbPriceSet_Change;
					withEventsField_cmbPriceSet.KeyDown += cmbPriceSet_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label lblPriceSet;
		public System.Windows.Forms.GroupBox _Frame2_4;
		public System.Windows.Forms.TextBox _txtInteger_4;
		public System.Windows.Forms.CheckBox _chkFields_5;
		public System.Windows.Forms.CheckBox chkSQ;
		public System.Windows.Forms.CheckBox _chkFields_3;
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.CheckBox _chkFields_4;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.GroupBox _Frame2_5;
		private System.Windows.Forms.Button withEventsField_cmdPackSize;
		public System.Windows.Forms.Button cmdPackSize {
			get { return withEventsField_cmdPackSize; }
			set {
				if (withEventsField_cmdPackSize != null) {
					withEventsField_cmdPackSize.Click -= cmdPackSize_Click;
				}
				withEventsField_cmdPackSize = value;
				if (withEventsField_cmdPackSize != null) {
					withEventsField_cmdPackSize.Click += cmdPackSize_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintGroup;
		public System.Windows.Forms.Button cmdPrintGroup {
			get { return withEventsField_cmdPrintGroup; }
			set {
				if (withEventsField_cmdPrintGroup != null) {
					withEventsField_cmdPrintGroup.Click -= cmdPrintGroup_Click;
				}
				withEventsField_cmdPrintGroup = value;
				if (withEventsField_cmdPrintGroup != null) {
					withEventsField_cmdPrintGroup.Click += cmdPrintGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdVAT;
		public System.Windows.Forms.Button cmdVAT {
			get { return withEventsField_cmdVAT; }
			set {
				if (withEventsField_cmdVAT != null) {
					withEventsField_cmdVAT.Click -= cmdVAT_Click;
				}
				withEventsField_cmdVAT = value;
				if (withEventsField_cmdVAT != null) {
					withEventsField_cmdVAT.Click += cmdVAT_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintLocation;
		public System.Windows.Forms.Button cmdPrintLocation {
			get { return withEventsField_cmdPrintLocation; }
			set {
				if (withEventsField_cmdPrintLocation != null) {
					withEventsField_cmdPrintLocation.Click -= cmdPrintLocation_Click;
				}
				withEventsField_cmdPrintLocation = value;
				if (withEventsField_cmdPrintLocation != null) {
					withEventsField_cmdPrintLocation.Click += cmdPrintLocation_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSupplier;
		public System.Windows.Forms.Button cmdSupplier {
			get { return withEventsField_cmdSupplier; }
			set {
				if (withEventsField_cmdSupplier != null) {
					withEventsField_cmdSupplier.Click -= cmdSupplier_Click;
				}
				withEventsField_cmdSupplier = value;
				if (withEventsField_cmdSupplier != null) {
					withEventsField_cmdSupplier.Click += cmdSupplier_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeposit;
		public System.Windows.Forms.Button cmdDeposit {
			get { return withEventsField_cmdDeposit; }
			set {
				if (withEventsField_cmdDeposit != null) {
					withEventsField_cmdDeposit.Click -= cmdDeposit_Click;
				}
				withEventsField_cmdDeposit = value;
				if (withEventsField_cmdDeposit != null) {
					withEventsField_cmdDeposit.Click += cmdDeposit_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.TextBox _txtFields_14;
		public System.Windows.Forms.CheckBox _chkFields_13;
		public System.Windows.Forms.CheckBox _chkFields_12;
		public System.Windows.Forms.TextBox _txtFields_8;
		private myDataGridView withEventsField_cmbVat;
		public myDataGridView cmbVat {
			get { return withEventsField_cmbVat; }
			set {
				if (withEventsField_cmbVat != null) {
					withEventsField_cmbVat.KeyDown -= cmbVat_KeyDown;
				}
				withEventsField_cmbVat = value;
				if (withEventsField_cmbVat != null) {
					withEventsField_cmbVat.KeyDown += cmbVat_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbDeposit;
		public myDataGridView cmbDeposit {
			get { return withEventsField_cmbDeposit; }
			set {
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown -= cmbDeposit_KeyDown;
				}
				withEventsField_cmbDeposit = value;
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown += cmbDeposit_KeyDown;
				}
			}
		}
		private myDataGridView withEventsField_cmbSupplier;
		public myDataGridView cmbSupplier {
			get { return withEventsField_cmbSupplier; }
			set {
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown -= cmbSupplier_KeyDown;
				}
				withEventsField_cmbSupplier = value;
				if (withEventsField_cmbSupplier != null) {
					withEventsField_cmbSupplier.KeyDown += cmbSupplier_KeyDown;
				}
			}
		}
		public myDataGridView cmbPrintLocation;
		public myDataGridView cmbPrintGroup;
		private myDataGridView withEventsField_cmbPackSize;
		public myDataGridView cmbPackSize {
			get { return withEventsField_cmbPackSize; }
			set {
				if (withEventsField_cmbPackSize != null) {
					withEventsField_cmbPackSize.KeyDown -= cmbPackSize_KeyDown;
				}
				withEventsField_cmbPackSize = value;
				if (withEventsField_cmbPackSize != null) {
					withEventsField_cmbPackSize.KeyDown += cmbPackSize_KeyDown;
				}
			}
		}
		public System.Windows.Forms.Label _lblLabels_16;
		public System.Windows.Forms.Label _lblLabels_13;
		public System.Windows.Forms.Label _lblLabels_12;
		public System.Windows.Forms.Label _lblLabels_14;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lblLabels_5;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.GroupBox _Frame2_0;
		public System.Windows.Forms.GroupBox _Frame1_0;
		public System.Windows.Forms.TextBox txtholdname;
		public System.Windows.Forms.TextBox txttemphold;
		public System.Windows.Forms.TextBox _txtFields_7;
		public System.Windows.Forms.TextBox _txtFields_1;
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
		private System.Windows.Forms.Button withEventsField_cmdHistory;
		public System.Windows.Forms.Button cmdHistory {
			get { return withEventsField_cmdHistory; }
			set {
				if (withEventsField_cmdHistory != null) {
					withEventsField_cmdHistory.Click -= cmdHistory_Click;
				}
				withEventsField_cmdHistory = value;
				if (withEventsField_cmdHistory != null) {
					withEventsField_cmdHistory.Click += cmdHistory_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDuplicate;
		public System.Windows.Forms.Button cmdDuplicate {
			get { return withEventsField_cmdDuplicate; }
			set {
				if (withEventsField_cmdDuplicate != null) {
					withEventsField_cmdDuplicate.Click -= cmdDuplicate_Click;
				}
				withEventsField_cmdDuplicate = value;
				if (withEventsField_cmdDuplicate != null) {
					withEventsField_cmdDuplicate.Click += cmdDuplicate_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDetails;
		public System.Windows.Forms.Button cmdDetails {
			get { return withEventsField_cmdDetails; }
			set {
				if (withEventsField_cmdDetails != null) {
					withEventsField_cmdDetails.Click -= cmdDetails_Click;
				}
				withEventsField_cmdDetails = value;
				if (withEventsField_cmdDetails != null) {
					withEventsField_cmdDetails.Click += cmdDetails_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdbarcodeItem;
		public System.Windows.Forms.Button cmdbarcodeItem {
			get { return withEventsField_cmdbarcodeItem; }
			set {
				if (withEventsField_cmdbarcodeItem != null) {
					withEventsField_cmdbarcodeItem.Click -= cmdbarcodeItem_Click;
				}
				withEventsField_cmdbarcodeItem = value;
				if (withEventsField_cmdbarcodeItem != null) {
					withEventsField_cmdbarcodeItem.Click += cmdbarcodeItem_Click;
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
		public System.Windows.Forms.ImageList ILtree;
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
		private System.Windows.Forms.Button withEventsField_cmdRecipeAdd;
		public System.Windows.Forms.Button cmdRecipeAdd {
			get { return withEventsField_cmdRecipeAdd; }
			set {
				if (withEventsField_cmdRecipeAdd != null) {
					withEventsField_cmdRecipeAdd.Click -= cmdRecipeAdd_Click;
				}
				withEventsField_cmdRecipeAdd = value;
				if (withEventsField_cmdRecipeAdd != null) {
					withEventsField_cmdRecipeAdd.Click += cmdRecipeAdd_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optRecipeType_0;
		public System.Windows.Forms.RadioButton _optRecipeType_1;
		public System.Windows.Forms.RadioButton _optRecipeType_2;
		private System.Windows.Forms.TextBox withEventsField_txtQuantity;
		public System.Windows.Forms.TextBox txtQuantity {
			get { return withEventsField_txtQuantity; }
			set {
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter -= txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress -= txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave -= txtQuantity_Leave;
					withEventsField_txtQuantity.KeyDown -= txtQuantity_KeyDown;
				}
				withEventsField_txtQuantity = value;
				if (withEventsField_txtQuantity != null) {
					withEventsField_txtQuantity.Enter += txtQuantity_Enter;
					withEventsField_txtQuantity.KeyPress += txtQuantity_KeyPress;
					withEventsField_txtQuantity.Leave += txtQuantity_Leave;
					withEventsField_txtQuantity.KeyDown += txtQuantity_KeyDown;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optRecipeType_3;
		private myDataGridView withEventsField_FGRecipe;
		public myDataGridView FGRecipe {
			get { return withEventsField_FGRecipe; }
			set {
				if (withEventsField_FGRecipe != null) {
					withEventsField_FGRecipe.CellEnter -= FGRecipe_EnterCell;
				}
				withEventsField_FGRecipe = value;
				if (withEventsField_FGRecipe != null) {
					withEventsField_FGRecipe.CellEnter += FGRecipe_EnterCell;
				}
			}
		}
		public System.Windows.Forms.Label lblRecipeCost;
		public System.Windows.Forms.GroupBox _Frame1_1;
		public System.Windows.Forms.Button _cmdNew_2;
		private System.Windows.Forms.Button withEventsField_cmdDeallocate;
		public System.Windows.Forms.Button cmdDeallocate {
			get { return withEventsField_cmdDeallocate; }
			set {
				if (withEventsField_cmdDeallocate != null) {
					withEventsField_cmdDeallocate.Click -= cmdDeallocate_Click;
				}
				withEventsField_cmdDeallocate = value;
				if (withEventsField_cmdDeallocate != null) {
					withEventsField_cmdDeallocate.Click += cmdDeallocate_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAllocate;
		public System.Windows.Forms.Button cmdAllocate {
			get { return withEventsField_cmdAllocate; }
			set {
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click -= cmdAllocate_Click;
				}
				withEventsField_cmdAllocate = value;
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click += cmdAllocate_Click;
				}
			}
		}
		public System.Windows.Forms.Button _cmdMove_1;
		public System.Windows.Forms.Button _cmdMove_0;
		public System.Windows.Forms.Button _cmdNew_1;
		public System.Windows.Forms.Button _cmdNew_0;
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
				}
			}
		}
		public System.Windows.Forms.TreeView TVMessage;
		public System.Windows.Forms.TreeView TreeView1;
		public System.Windows.Forms.GroupBox _Frame1_2;
		//Public WithEvents TabStrip1 As Axmscomctl.AxTabStrip
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_1;
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_2;
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_3;
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_4;
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_5;
		public System.Windows.Forms.ColumnHeader _lstvSerial_ColumnHeader_6;
		public System.Windows.Forms.ListView lstvSerial;
		public System.Windows.Forms.GroupBox Frame4;
		public System.Windows.Forms.GroupBox _Frame1_3;
		public System.Windows.Forms.Label _lblLabels_7;
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents Frame2 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents chkSerialTracking As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents cmdMove As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents cmdNew As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optRecipeType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStockItem));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.Frame6 = new System.Windows.Forms.GroupBox();
			this._chkSerialTracking_1 = new System.Windows.Forms.CheckBox();
			this._chkFields_6 = new System.Windows.Forms.CheckBox();
			this.Frame5 = new System.Windows.Forms.GroupBox();
			this.chkbarcode = new System.Windows.Forms.CheckBox();
			this.chkshelf = new System.Windows.Forms.CheckBox();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this._chkSerialTracking_0 = new System.Windows.Forms.CheckBox();
			this._Frame2_1 = new System.Windows.Forms.GroupBox();
			this.cmdReportGroup = new System.Windows.Forms.Button();
			this.cmdStockGroup = new System.Windows.Forms.Button();
			this.cmdPricingGroup = new System.Windows.Forms.Button();
			this.cmbPricingGroup = new myDataGridView();
			this.cmbStockGroup = new myDataGridView();
			this.cmbReportGroup = new myDataGridView();
			this._lblLabels_15 = new System.Windows.Forms.Label();
			this._lblLabels_4 = new System.Windows.Forms.Label();
			this._lblLabels_3 = new System.Windows.Forms.Label();
			this._Frame2_2 = new System.Windows.Forms.GroupBox();
			this.cmdShrink = new System.Windows.Forms.Button();
			this._txtFloat_1 = new System.Windows.Forms.TextBox();
			this._txtFloat_0 = new System.Windows.Forms.TextBox();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this.cmbShrink = new myDataGridView();
			this._lblLabels_11 = new System.Windows.Forms.Label();
			this._lblLabels_10 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._Frame2_3 = new System.Windows.Forms.GroupBox();
			this.cmbReorder = new System.Windows.Forms.ComboBox();
			this._txtInteger_3 = new System.Windows.Forms.TextBox();
			this._txtInteger_1 = new System.Windows.Forms.TextBox();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this._txtInteger_2 = new System.Windows.Forms.TextBox();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._Frame2_4 = new System.Windows.Forms.GroupBox();
			this.cmdpriceselist = new System.Windows.Forms.Button();
			this.chkPriceSet = new System.Windows.Forms.CheckBox();
			this.cmbPriceSet = new myDataGridView();
			this.lblPriceSet = new System.Windows.Forms.Label();
			this._Frame2_5 = new System.Windows.Forms.GroupBox();
			this._txtInteger_4 = new System.Windows.Forms.TextBox();
			this._chkFields_5 = new System.Windows.Forms.CheckBox();
			this.chkSQ = new System.Windows.Forms.CheckBox();
			this._chkFields_3 = new System.Windows.Forms.CheckBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._chkFields_4 = new System.Windows.Forms.CheckBox();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._Frame2_0 = new System.Windows.Forms.GroupBox();
			this.cmdPackSize = new System.Windows.Forms.Button();
			this.cmdPrintGroup = new System.Windows.Forms.Button();
			this.cmdVAT = new System.Windows.Forms.Button();
			this.cmdPrintLocation = new System.Windows.Forms.Button();
			this.cmdSupplier = new System.Windows.Forms.Button();
			this.cmdDeposit = new System.Windows.Forms.Button();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this._txtFields_14 = new System.Windows.Forms.TextBox();
			this._chkFields_13 = new System.Windows.Forms.CheckBox();
			this._chkFields_12 = new System.Windows.Forms.CheckBox();
			this._txtFields_8 = new System.Windows.Forms.TextBox();
			this.cmbVat = new myDataGridView();
			this.cmbDeposit = new myDataGridView();
			this.cmbSupplier = new myDataGridView();
			this.cmbPrintLocation = new myDataGridView();
			this.cmbPrintGroup = new myDataGridView();
			this.cmbPackSize = new myDataGridView();
			this._lblLabels_16 = new System.Windows.Forms.Label();
			this._lblLabels_13 = new System.Windows.Forms.Label();
			this._lblLabels_12 = new System.Windows.Forms.Label();
			this._lblLabels_14 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lblLabels_5 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this.txtholdname = new System.Windows.Forms.TextBox();
			this.txttemphold = new System.Windows.Forms.TextBox();
			this._txtFields_7 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdHistory = new System.Windows.Forms.Button();
			this.cmdDuplicate = new System.Windows.Forms.Button();
			this.cmdDetails = new System.Windows.Forms.Button();
			this.cmdbarcodeItem = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.ILtree = new System.Windows.Forms.ImageList();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdRecipeAdd = new System.Windows.Forms.Button();
			this._optRecipeType_0 = new System.Windows.Forms.RadioButton();
			this._optRecipeType_1 = new System.Windows.Forms.RadioButton();
			this._optRecipeType_2 = new System.Windows.Forms.RadioButton();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this._optRecipeType_3 = new System.Windows.Forms.RadioButton();
			this.FGRecipe = new myDataGridView();
			this.lblRecipeCost = new System.Windows.Forms.Label();
			this._Frame1_2 = new System.Windows.Forms.GroupBox();
			this._cmdNew_2 = new System.Windows.Forms.Button();
			this.cmdDeallocate = new System.Windows.Forms.Button();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this._cmdMove_1 = new System.Windows.Forms.Button();
			this._cmdMove_0 = new System.Windows.Forms.Button();
			this._cmdNew_1 = new System.Windows.Forms.Button();
			this._cmdNew_0 = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.TVMessage = new System.Windows.Forms.TreeView();
			this.TreeView1 = new System.Windows.Forms.TreeView();
			//Me.TabStrip1 = New Axmscomctl.AxTabStrip
			this._Frame1_3 = new System.Windows.Forms.GroupBox();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this.lstvSerial = new System.Windows.Forms.ListView();
			this._lstvSerial_ColumnHeader_1 = new System.Windows.Forms.ColumnHeader();
			this._lstvSerial_ColumnHeader_2 = new System.Windows.Forms.ColumnHeader();
			this._lstvSerial_ColumnHeader_3 = new System.Windows.Forms.ColumnHeader();
			this._lstvSerial_ColumnHeader_4 = new System.Windows.Forms.ColumnHeader();
			this._lstvSerial_ColumnHeader_5 = new System.Windows.Forms.ColumnHeader();
			this._lstvSerial_ColumnHeader_6 = new System.Windows.Forms.ColumnHeader();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.Frame2 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.chkSerialTracking = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.cmdMove = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.cmdNew = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optRecipeType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this._Frame1_0.SuspendLayout();
			this.Frame6.SuspendLayout();
			this.Frame5.SuspendLayout();
			this.Frame3.SuspendLayout();
			this._Frame2_1.SuspendLayout();
			this._Frame2_2.SuspendLayout();
			this._Frame2_3.SuspendLayout();
			this._Frame2_4.SuspendLayout();
			this._Frame2_5.SuspendLayout();
			this._Frame2_0.SuspendLayout();
			this.picButtons.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this._Frame1_2.SuspendLayout();
			this._Frame1_3.SuspendLayout();
			this.Frame4.SuspendLayout();
			this.lstvSerial.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbReportGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPriceSet).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbVat).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPrintLocation).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPrintGroup).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPackSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.FGRecipe).BeginInit();
			//CType(Me.TabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Frame2, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.chkSerialTracking, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.cmdNew, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optRecipeType, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Stock Item Details";
			this.ClientSize = new System.Drawing.Size(592, 541);
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
			this.Name = "frmStockItem";
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_0.Size = new System.Drawing.Size(556, 435);
			this._Frame1_0.Location = new System.Drawing.Point(14, 96);
			this._Frame1_0.TabIndex = 51;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.Frame6.Text = "&8. Air Time";
			this.Frame6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame6.Size = new System.Drawing.Size(115, 43);
			this.Frame6.Location = new System.Drawing.Point(432, 338);
			this.Frame6.TabIndex = 113;
			this.Frame6.BackColor = System.Drawing.SystemColors.Control;
			this.Frame6.Enabled = true;
			this.Frame6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame6.Visible = true;
			this.Frame6.Padding = new System.Windows.Forms.Padding(0);
			this.Frame6.Name = "Frame6";
			this._chkSerialTracking_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkSerialTracking_1.Text = "Yes";
			this._chkSerialTracking_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkSerialTracking_1.Size = new System.Drawing.Size(61, 17);
			this._chkSerialTracking_1.Location = new System.Drawing.Point(236, 10);
			this._chkSerialTracking_1.TabIndex = 115;
			this._chkSerialTracking_1.Visible = false;
			this._chkSerialTracking_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkSerialTracking_1.BackColor = System.Drawing.SystemColors.Control;
			this._chkSerialTracking_1.CausesValidation = true;
			this._chkSerialTracking_1.Enabled = true;
			this._chkSerialTracking_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkSerialTracking_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkSerialTracking_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkSerialTracking_1.TabStop = true;
			this._chkSerialTracking_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkSerialTracking_1.Name = "_chkSerialTracking_1";
			this._chkFields_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_6.Text = "Yes";
			this._chkFields_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_6.Size = new System.Drawing.Size(79, 21);
			this._chkFields_6.Location = new System.Drawing.Point(10, 16);
			this._chkFields_6.TabIndex = 114;
			this._chkFields_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_6.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_6.CausesValidation = true;
			this._chkFields_6.Enabled = true;
			this._chkFields_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_6.TabStop = true;
			this._chkFields_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_6.Visible = true;
			this._chkFields_6.Name = "_chkFields_6";
			this.Frame5.Text = "&9. Shelf && Barcode Printing";
			this.Frame5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame5.Size = new System.Drawing.Size(235, 43);
			this.Frame5.Location = new System.Drawing.Point(312, 384);
			this.Frame5.TabIndex = 98;
			this.Frame5.BackColor = System.Drawing.SystemColors.Control;
			this.Frame5.Enabled = true;
			this.Frame5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame5.Visible = true;
			this.Frame5.Padding = new System.Windows.Forms.Padding(0);
			this.Frame5.Name = "Frame5";
			this.chkbarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkbarcode.Text = "Barcode";
			this.chkbarcode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkbarcode.Size = new System.Drawing.Size(83, 21);
			this.chkbarcode.Location = new System.Drawing.Point(100, 16);
			this.chkbarcode.TabIndex = 104;
			this.chkbarcode.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkbarcode.BackColor = System.Drawing.SystemColors.Control;
			this.chkbarcode.CausesValidation = true;
			this.chkbarcode.Enabled = true;
			this.chkbarcode.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkbarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkbarcode.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkbarcode.TabStop = true;
			this.chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkbarcode.Visible = true;
			this.chkbarcode.Name = "chkbarcode";
			this.chkshelf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshelf.Text = "Shelf";
			this.chkshelf.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkshelf.Size = new System.Drawing.Size(61, 21);
			this.chkshelf.Location = new System.Drawing.Point(10, 16);
			this.chkshelf.TabIndex = 103;
			this.chkshelf.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkshelf.BackColor = System.Drawing.SystemColors.Control;
			this.chkshelf.CausesValidation = true;
			this.chkshelf.Enabled = true;
			this.chkshelf.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkshelf.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkshelf.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkshelf.TabStop = true;
			this.chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkshelf.Visible = true;
			this.chkshelf.Name = "chkshelf";
			this.Frame3.Text = "&7. Serial Tracking";
			this.Frame3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame3.Size = new System.Drawing.Size(115, 43);
			this.Frame3.Location = new System.Drawing.Point(312, 338);
			this.Frame3.TabIndex = 92;
			this.Frame3.BackColor = System.Drawing.SystemColors.Control;
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Visible = true;
			this.Frame3.Padding = new System.Windows.Forms.Padding(0);
			this.Frame3.Name = "Frame3";
			this._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_1.Text = "Yes";
			this._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_1.Size = new System.Drawing.Size(79, 21);
			this._chkFields_1.Location = new System.Drawing.Point(10, 16);
			this._chkFields_1.TabIndex = 97;
			this._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_1.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_1.CausesValidation = true;
			this._chkFields_1.Enabled = true;
			this._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_1.TabStop = true;
			this._chkFields_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_1.Visible = true;
			this._chkFields_1.Name = "_chkFields_1";
			this._chkSerialTracking_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkSerialTracking_0.Text = "Yes";
			this._chkSerialTracking_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkSerialTracking_0.Size = new System.Drawing.Size(61, 17);
			this._chkSerialTracking_0.Location = new System.Drawing.Point(236, 10);
			this._chkSerialTracking_0.TabIndex = 93;
			this._chkSerialTracking_0.Visible = false;
			this._chkSerialTracking_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkSerialTracking_0.BackColor = System.Drawing.SystemColors.Control;
			this._chkSerialTracking_0.CausesValidation = true;
			this._chkSerialTracking_0.Enabled = true;
			this._chkSerialTracking_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkSerialTracking_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkSerialTracking_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkSerialTracking_0.TabStop = true;
			this._chkSerialTracking_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkSerialTracking_0.Name = "_chkSerialTracking_0";
			this._Frame2_1.Text = "&2. Groupings";
			this._Frame2_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_1.Size = new System.Drawing.Size(298, 92);
			this._Frame2_1.Location = new System.Drawing.Point(8, 248);
			this._Frame2_1.TabIndex = 13;
			this._Frame2_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_1.Enabled = true;
			this._Frame2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_1.Visible = true;
			this._Frame2_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_1.Name = "_Frame2_1";
			this.cmdReportGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdReportGroup.Text = "...";
			this.cmdReportGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdReportGroup.Location = new System.Drawing.Point(266, 66);
			this.cmdReportGroup.TabIndex = 100;
			this.cmdReportGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdReportGroup.CausesValidation = true;
			this.cmdReportGroup.Enabled = true;
			this.cmdReportGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdReportGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdReportGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdReportGroup.TabStop = true;
			this.cmdReportGroup.Name = "cmdReportGroup";
			this.cmdStockGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdStockGroup.Text = "...";
			this.cmdStockGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdStockGroup.Location = new System.Drawing.Point(267, 40);
			this.cmdStockGroup.TabIndex = 75;
			this.cmdStockGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdStockGroup.CausesValidation = true;
			this.cmdStockGroup.Enabled = true;
			this.cmdStockGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdStockGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdStockGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdStockGroup.TabStop = true;
			this.cmdStockGroup.Name = "cmdStockGroup";
			this.cmdPricingGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPricingGroup.Text = "...";
			this.cmdPricingGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdPricingGroup.Location = new System.Drawing.Point(267, 16);
			this.cmdPricingGroup.TabIndex = 74;
			this.cmdPricingGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPricingGroup.CausesValidation = true;
			this.cmdPricingGroup.Enabled = true;
			this.cmdPricingGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPricingGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPricingGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPricingGroup.TabStop = true;
			this.cmdPricingGroup.Name = "cmdPricingGroup";
			//cmbPricingGroup.OcxState = CType(resources.GetObject("cmbPricingGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPricingGroup.Size = new System.Drawing.Size(184, 21);
			this.cmbPricingGroup.Location = new System.Drawing.Point(81, 15);
			this.cmbPricingGroup.TabIndex = 14;
			this.cmbPricingGroup.Name = "cmbPricingGroup";
			//cmbStockGroup.OcxState = CType(resources.GetObject("cmbStockGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbStockGroup.Size = new System.Drawing.Size(184, 21);
			this.cmbStockGroup.Location = new System.Drawing.Point(81, 40);
			this.cmbStockGroup.TabIndex = 15;
			this.cmbStockGroup.Name = "cmbStockGroup";
			//cmbReportGroup.OcxState = CType(resources.GetObject("cmbReportGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbReportGroup.Size = new System.Drawing.Size(184, 21);
			this.cmbReportGroup.Location = new System.Drawing.Point(80, 64);
			this.cmbReportGroup.TabIndex = 99;
			this.cmbReportGroup.Name = "cmbReportGroup";
			this._lblLabels_15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_15.Text = "Report Group:";
			this._lblLabels_15.Size = new System.Drawing.Size(67, 13);
			this._lblLabels_15.Location = new System.Drawing.Point(8, 70);
			this._lblLabels_15.TabIndex = 101;
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
			this._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_4.Text = "Stock Group:";
			this._lblLabels_4.Size = new System.Drawing.Size(63, 13);
			this._lblLabels_4.Location = new System.Drawing.Point(13, 45);
			this._lblLabels_4.TabIndex = 63;
			this._lblLabels_4.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_4.Enabled = true;
			this._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_4.UseMnemonic = true;
			this._lblLabels_4.Visible = true;
			this._lblLabels_4.AutoSize = true;
			this._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_4.Name = "_lblLabels_4";
			this._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_3.Text = "Pricing Group:";
			this._lblLabels_3.Size = new System.Drawing.Size(67, 13);
			this._lblLabels_3.Location = new System.Drawing.Point(9, 21);
			this._lblLabels_3.TabIndex = 62;
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
			this._Frame2_2.Text = "&3. Pricing and Shrinks";
			this._Frame2_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_2.Size = new System.Drawing.Size(298, 82);
			this._Frame2_2.Location = new System.Drawing.Point(8, 344);
			this._Frame2_2.TabIndex = 57;
			this._Frame2_2.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_2.Enabled = true;
			this._Frame2_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_2.Visible = true;
			this._Frame2_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_2.Name = "_Frame2_2";
			this.cmdShrink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdShrink.Text = "...";
			this.cmdShrink.Size = new System.Drawing.Size(25, 19);
			this.cmdShrink.Location = new System.Drawing.Point(267, 15);
			this.cmdShrink.TabIndex = 76;
			this.cmdShrink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdShrink.CausesValidation = true;
			this.cmdShrink.Enabled = true;
			this.cmdShrink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShrink.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdShrink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShrink.TabStop = true;
			this.cmdShrink.Name = "cmdShrink";
			this._txtFloat_1.AutoSize = false;
			this._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_1.Size = new System.Drawing.Size(64, 19);
			this._txtFloat_1.Location = new System.Drawing.Point(165, 51);
			this._txtFloat_1.TabIndex = 19;
			this._txtFloat_1.Text = "0";
			this._txtFloat_1.AcceptsReturn = true;
			this._txtFloat_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_1.CausesValidation = true;
			this._txtFloat_1.Enabled = true;
			this._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_1.HideSelection = true;
			this._txtFloat_1.ReadOnly = false;
			this._txtFloat_1.MaxLength = 0;
			this._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_1.Multiline = false;
			this._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_1.TabStop = true;
			this._txtFloat_1.Visible = true;
			this._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_1.Name = "_txtFloat_1";
			this._txtFloat_0.AutoSize = false;
			this._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_0.Size = new System.Drawing.Size(64, 19);
			this._txtFloat_0.Location = new System.Drawing.Point(99, 51);
			this._txtFloat_0.TabIndex = 18;
			this._txtFloat_0.Text = "9,999.99";
			this._txtFloat_0.AcceptsReturn = true;
			this._txtFloat_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_0.CausesValidation = true;
			this._txtFloat_0.Enabled = true;
			this._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_0.HideSelection = true;
			this._txtFloat_0.ReadOnly = false;
			this._txtFloat_0.MaxLength = 0;
			this._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_0.Multiline = false;
			this._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_0.TabStop = true;
			this._txtFloat_0.Visible = true;
			this._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_0.Name = "_txtFloat_0";
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(54, 51);
			this._txtInteger_0.TabIndex = 17;
			this._txtInteger_0.Text = "999";
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_0.CausesValidation = true;
			this._txtInteger_0.Enabled = true;
			this._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_0.HideSelection = true;
			this._txtInteger_0.ReadOnly = false;
			this._txtInteger_0.MaxLength = 0;
			this._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_0.Multiline = false;
			this._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_0.TabStop = true;
			this._txtInteger_0.Visible = true;
			this._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_0.Name = "_txtInteger_0";
			//cmbShrink.OcxState = CType(resources.GetObject("cmbShrink.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbShrink.Size = new System.Drawing.Size(181, 21);
			this.cmbShrink.Location = new System.Drawing.Point(84, 14);
			this.cmbShrink.TabIndex = 16;
			this.cmbShrink.Name = "cmbShrink";
			this._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_11.Text = "Actual Cost:";
			this._lblLabels_11.Size = new System.Drawing.Size(57, 13);
			this._lblLabels_11.Location = new System.Drawing.Point(169, 39);
			this._lblLabels_11.TabIndex = 61;
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
			this._lblLabels_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_10.Text = "List Cost:";
			this._lblLabels_10.Size = new System.Drawing.Size(40, 13);
			this._lblLabels_10.Location = new System.Drawing.Point(120, 39);
			this._lblLabels_10.TabIndex = 60;
			this._lblLabels_10.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_10.Enabled = true;
			this._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_10.UseMnemonic = true;
			this._lblLabels_10.Visible = true;
			this._lblLabels_10.AutoSize = true;
			this._lblLabels_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_10.Name = "_lblLabels_10";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_9.Text = "Suppliers Quantity:";
			this._lblLabels_9.Size = new System.Drawing.Size(88, 13);
			this._lblLabels_9.Location = new System.Drawing.Point(9, 39);
			this._lblLabels_9.TabIndex = 59;
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
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "Sale Shrinks:";
			this._lblLabels_1.Size = new System.Drawing.Size(62, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(17, 18);
			this._lblLabels_1.TabIndex = 58;
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
			this._Frame2_3.Text = "&4. Ordering Rules";
			this._Frame2_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_3.Size = new System.Drawing.Size(235, 91);
			this._Frame2_3.Location = new System.Drawing.Point(312, 12);
			this._Frame2_3.TabIndex = 20;
			this._Frame2_3.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_3.Enabled = true;
			this._Frame2_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_3.Visible = true;
			this._Frame2_3.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_3.Name = "_Frame2_3";
			this.cmbReorder.Size = new System.Drawing.Size(97, 21);
			this.cmbReorder.Location = new System.Drawing.Point(63, 66);
			this.cmbReorder.Items.AddRange(new object[] {
				"Single Unit",
				"Case/Carton"
			});
			this.cmbReorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbReorder.TabIndex = 23;
			this.cmbReorder.BackColor = System.Drawing.SystemColors.Window;
			this.cmbReorder.CausesValidation = true;
			this.cmbReorder.Enabled = true;
			this.cmbReorder.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbReorder.IntegralHeight = true;
			this.cmbReorder.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbReorder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbReorder.Sorted = false;
			this.cmbReorder.TabStop = true;
			this.cmbReorder.Visible = true;
			this.cmbReorder.Name = "cmbReorder";
			this._txtInteger_3.AutoSize = false;
			this._txtInteger_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_3.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_3.Location = new System.Drawing.Point(184, 66);
			this._txtInteger_3.TabIndex = 24;
			this._txtInteger_3.Text = "999";
			this._txtInteger_3.AcceptsReturn = true;
			this._txtInteger_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_3.CausesValidation = true;
			this._txtInteger_3.Enabled = true;
			this._txtInteger_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_3.HideSelection = true;
			this._txtInteger_3.ReadOnly = false;
			this._txtInteger_3.MaxLength = 0;
			this._txtInteger_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_3.Multiline = false;
			this._txtInteger_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_3.TabStop = true;
			this._txtInteger_3.Visible = true;
			this._txtInteger_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_3.Name = "_txtInteger_3";
			this._txtInteger_1.AutoSize = false;
			this._txtInteger_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_1.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_1.Location = new System.Drawing.Point(150, 45);
			this._txtInteger_1.TabIndex = 22;
			this._txtInteger_1.Text = "999";
			this._txtInteger_1.AcceptsReturn = true;
			this._txtInteger_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_1.CausesValidation = true;
			this._txtInteger_1.Enabled = true;
			this._txtInteger_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_1.HideSelection = true;
			this._txtInteger_1.ReadOnly = false;
			this._txtInteger_1.MaxLength = 0;
			this._txtInteger_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_1.Multiline = false;
			this._txtInteger_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_1.TabStop = true;
			this._txtInteger_1.Visible = true;
			this._txtInteger_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_1.Name = "_txtInteger_1";
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.Text = "Check this box to exclude this Stock Item when using the Ordering wizard";
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Size = new System.Drawing.Size(217, 25);
			this._chkFields_0.Location = new System.Drawing.Point(9, 15);
			this._chkFields_0.TabIndex = 21;
			this._chkFields_0.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_0.CausesValidation = true;
			this._chkFields_0.Enabled = true;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_0.TabStop = true;
			this._chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_0.Visible = true;
			this._chkFields_0.Name = "_chkFields_0";
			this._txtInteger_2.AutoSize = false;
			this._txtInteger_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_2.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_2.Location = new System.Drawing.Point(160, 0);
			this._txtInteger_2.TabIndex = 52;
			this._txtInteger_2.Text = "999";
			this._txtInteger_2.Visible = false;
			this._txtInteger_2.AcceptsReturn = true;
			this._txtInteger_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_2.CausesValidation = true;
			this._txtInteger_2.Enabled = true;
			this._txtInteger_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_2.HideSelection = true;
			this._txtInteger_2.ReadOnly = false;
			this._txtInteger_2.MaxLength = 0;
			this._txtInteger_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_2.Multiline = false;
			this._txtInteger_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_2.TabStop = true;
			this._txtInteger_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_2.Name = "_txtInteger_2";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "of";
			this._lbl_7.Size = new System.Drawing.Size(9, 13);
			this._lbl_7.Location = new System.Drawing.Point(164, 69);
			this._lbl_7.TabIndex = 56;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = true;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "Re-order a ";
			this._lbl_0.Size = new System.Drawing.Size(53, 13);
			this._lbl_0.Location = new System.Drawing.Point(11, 69);
			this._lbl_0.TabIndex = 55;
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
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_5.Text = "units,";
			this._lbl_5.Size = new System.Drawing.Size(25, 13);
			this._lbl_5.Location = new System.Drawing.Point(196, 48);
			this._lbl_5.TabIndex = 54;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = true;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "When the stock goes below ";
			this._lbl_4.Size = new System.Drawing.Size(136, 13);
			this._lbl_4.Location = new System.Drawing.Point(12, 48);
			this._lbl_4.TabIndex = 53;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Enabled = true;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = true;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_4.Name = "_lbl_4";
			this._Frame2_4.Text = "&5. Pricing Set";
			this._Frame2_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_4.Size = new System.Drawing.Size(235, 76);
			this._Frame2_4.Location = new System.Drawing.Point(312, 104);
			this._Frame2_4.TabIndex = 25;
			this._Frame2_4.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_4.Enabled = true;
			this._Frame2_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_4.Visible = true;
			this._Frame2_4.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_4.Name = "_Frame2_4";
			this.cmdpriceselist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdpriceselist.Text = "...";
			this.cmdpriceselist.Size = new System.Drawing.Size(29, 21);
			this.cmdpriceselist.Location = new System.Drawing.Point(200, 32);
			this.cmdpriceselist.TabIndex = 102;
			this.cmdpriceselist.BackColor = System.Drawing.SystemColors.Control;
			this.cmdpriceselist.CausesValidation = true;
			this.cmdpriceselist.Enabled = true;
			this.cmdpriceselist.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdpriceselist.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdpriceselist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdpriceselist.TabStop = true;
			this.cmdpriceselist.Name = "cmdpriceselist";
			this.chkPriceSet.Text = "&5. This item is part of a Pricing Set";
			this.chkPriceSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.chkPriceSet.Size = new System.Drawing.Size(220, 13);
			this.chkPriceSet.Location = new System.Drawing.Point(9, 15);
			this.chkPriceSet.TabIndex = 26;
			this.chkPriceSet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPriceSet.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkPriceSet.BackColor = System.Drawing.SystemColors.Control;
			this.chkPriceSet.CausesValidation = true;
			this.chkPriceSet.Enabled = true;
			this.chkPriceSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPriceSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPriceSet.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPriceSet.TabStop = true;
			this.chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPriceSet.Visible = true;
			this.chkPriceSet.Name = "chkPriceSet";
			//cmbPriceSet.OcxState = CType(resources.GetObject("cmbPriceSet.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPriceSet.Size = new System.Drawing.Size(179, 21);
			this.cmbPriceSet.Location = new System.Drawing.Point(18, 32);
			this.cmbPriceSet.TabIndex = 27;
			this.cmbPriceSet.Name = "cmbPriceSet";
			this.lblPriceSet.Text = "No Action";
			this.lblPriceSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblPriceSet.Size = new System.Drawing.Size(211, 17);
			this.lblPriceSet.Location = new System.Drawing.Point(18, 51);
			this.lblPriceSet.TabIndex = 28;
			this.lblPriceSet.Visible = false;
			this.lblPriceSet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblPriceSet.BackColor = System.Drawing.SystemColors.Control;
			this.lblPriceSet.Enabled = true;
			this.lblPriceSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPriceSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPriceSet.UseMnemonic = true;
			this.lblPriceSet.AutoSize = false;
			this.lblPriceSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPriceSet.Name = "lblPriceSet";
			this._Frame2_5.Text = "&6.Parameters";
			this._Frame2_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_5.Size = new System.Drawing.Size(235, 152);
			this._Frame2_5.Location = new System.Drawing.Point(312, 182);
			this._Frame2_5.TabIndex = 29;
			this._Frame2_5.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_5.Enabled = true;
			this._Frame2_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_5.Visible = true;
			this._Frame2_5.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_5.Name = "_Frame2_5";
			this._txtInteger_4.AutoSize = false;
			this._txtInteger_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_4.Size = new System.Drawing.Size(27, 19);
			this._txtInteger_4.Location = new System.Drawing.Point(10, 36);
			this._txtInteger_4.TabIndex = 116;
			this._txtInteger_4.Text = "0";
			this._txtInteger_4.AcceptsReturn = true;
			this._txtInteger_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_4.CausesValidation = true;
			this._txtInteger_4.Enabled = true;
			this._txtInteger_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_4.HideSelection = true;
			this._txtInteger_4.ReadOnly = false;
			this._txtInteger_4.MaxLength = 0;
			this._txtInteger_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_4.Multiline = false;
			this._txtInteger_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_4.TabStop = true;
			this._txtInteger_4.Visible = true;
			this._txtInteger_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_4.Name = "_txtInteger_4";
			this._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_5.Text = "Do not Allow Negative Stock";
			this._chkFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_5.Size = new System.Drawing.Size(177, 19);
			this._chkFields_5.Location = new System.Drawing.Point(10, 102);
			this._chkFields_5.TabIndex = 107;
			this._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_5.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_5.CausesValidation = true;
			this._chkFields_5.Enabled = true;
			this._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_5.TabStop = true;
			this._chkFields_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_5.Visible = true;
			this._chkFields_5.Name = "_chkFields_5";
			this.chkSQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSQ.Text = "POS Price Overide (SQ)";
			this.chkSQ.ForeColor = System.Drawing.SystemColors.WindowText;
			this.chkSQ.Size = new System.Drawing.Size(151, 13);
			this.chkSQ.Location = new System.Drawing.Point(10, 128);
			this.chkSQ.TabIndex = 33;
			this.chkSQ.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSQ.BackColor = System.Drawing.SystemColors.Control;
			this.chkSQ.CausesValidation = true;
			this.chkSQ.Enabled = true;
			this.chkSQ.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkSQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSQ.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkSQ.TabStop = true;
			this.chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkSQ.Visible = true;
			this.chkSQ.Name = "chkSQ";
			this._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_3.Text = "Allow Fractions";
			this._chkFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_3.Size = new System.Drawing.Size(95, 19);
			this._chkFields_3.Location = new System.Drawing.Point(10, 80);
			this._chkFields_3.TabIndex = 32;
			this._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_3.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_3.CausesValidation = true;
			this._chkFields_3.Enabled = true;
			this._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_3.TabStop = true;
			this._chkFields_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_3.Visible = true;
			this._chkFields_3.Name = "_chkFields_3";
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.Text = "This is a scale product";
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Size = new System.Drawing.Size(170, 19);
			this._chkFields_2.Location = new System.Drawing.Point(10, 15);
			this._chkFields_2.TabIndex = 30;
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_2.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_2.CausesValidation = true;
			this._chkFields_2.Enabled = true;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_2.TabStop = true;
			this._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_2.Visible = true;
			this._chkFields_2.Name = "_chkFields_2";
			this._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_4.Text = "This is a scale item Non Weighed";
			this._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_4.Size = new System.Drawing.Size(179, 19);
			this._chkFields_4.Location = new System.Drawing.Point(10, 59);
			this._chkFields_4.TabIndex = 31;
			this._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_4.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_4.CausesValidation = true;
			this._chkFields_4.Enabled = true;
			this._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_4.TabStop = true;
			this._chkFields_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_4.Visible = true;
			this._chkFields_4.Name = "_chkFields_4";
			this._lbl_1.Text = "Sell by days (for labelling only)";
			this._lbl_1.Size = new System.Drawing.Size(140, 13);
			this._lbl_1.Location = new System.Drawing.Point(42, 39);
			this._lbl_1.TabIndex = 117;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._Frame2_0.Text = "&1. General";
			this._Frame2_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame2_0.Size = new System.Drawing.Size(298, 232);
			this._Frame2_0.Location = new System.Drawing.Point(9, 12);
			this._Frame2_0.TabIndex = 3;
			this._Frame2_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame2_0.Enabled = true;
			this._Frame2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame2_0.Visible = true;
			this._Frame2_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame2_0.Name = "_Frame2_0";
			this.cmdPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPackSize.Text = "...";
			this.cmdPackSize.Size = new System.Drawing.Size(25, 19);
			this.cmdPackSize.Location = new System.Drawing.Point(266, 206);
			this.cmdPackSize.TabIndex = 109;
			this.cmdPackSize.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPackSize.CausesValidation = true;
			this.cmdPackSize.Enabled = true;
			this.cmdPackSize.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPackSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPackSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPackSize.TabStop = true;
			this.cmdPackSize.Name = "cmdPackSize";
			this.cmdPrintGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintGroup.Text = "...";
			this.cmdPrintGroup.Size = new System.Drawing.Size(25, 19);
			this.cmdPrintGroup.Location = new System.Drawing.Point(266, 180);
			this.cmdPrintGroup.TabIndex = 88;
			this.cmdPrintGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintGroup.CausesValidation = true;
			this.cmdPrintGroup.Enabled = true;
			this.cmdPrintGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintGroup.TabStop = true;
			this.cmdPrintGroup.Name = "cmdPrintGroup";
			this.cmdVAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdVAT.Text = "...";
			this.cmdVAT.Size = new System.Drawing.Size(25, 19);
			this.cmdVAT.Location = new System.Drawing.Point(267, 82);
			this.cmdVAT.TabIndex = 77;
			this.cmdVAT.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVAT.CausesValidation = true;
			this.cmdVAT.Enabled = true;
			this.cmdVAT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVAT.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdVAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVAT.TabStop = true;
			this.cmdVAT.Name = "cmdVAT";
			this.cmdPrintLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintLocation.Text = "...";
			this.cmdPrintLocation.Size = new System.Drawing.Size(25, 19);
			this.cmdPrintLocation.Location = new System.Drawing.Point(267, 156);
			this.cmdPrintLocation.TabIndex = 73;
			this.cmdPrintLocation.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintLocation.CausesValidation = true;
			this.cmdPrintLocation.Enabled = true;
			this.cmdPrintLocation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintLocation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintLocation.TabStop = true;
			this.cmdPrintLocation.Name = "cmdPrintLocation";
			this.cmdSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSupplier.Text = "...";
			this.cmdSupplier.Size = new System.Drawing.Size(25, 19);
			this.cmdSupplier.Location = new System.Drawing.Point(267, 105);
			this.cmdSupplier.TabIndex = 72;
			this.cmdSupplier.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSupplier.CausesValidation = true;
			this.cmdSupplier.Enabled = true;
			this.cmdSupplier.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSupplier.TabStop = true;
			this.cmdSupplier.Name = "cmdSupplier";
			this.cmdDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeposit.Text = "...";
			this.cmdDeposit.Size = new System.Drawing.Size(25, 19);
			this.cmdDeposit.Location = new System.Drawing.Point(267, 58);
			this.cmdDeposit.TabIndex = 71;
			this.cmdDeposit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeposit.CausesValidation = true;
			this.cmdDeposit.Enabled = true;
			this.cmdDeposit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeposit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeposit.TabStop = true;
			this.cmdDeposit.Name = "cmdDeposit";
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.Size = new System.Drawing.Size(48, 19);
			this._txtFields_0.Location = new System.Drawing.Point(89, 132);
			this._txtFields_0.TabIndex = 9;
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.CausesValidation = true;
			this._txtFields_0.Enabled = true;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.HideSelection = true;
			this._txtFields_0.ReadOnly = false;
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.Multiline = false;
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_0.TabStop = true;
			this._txtFields_0.Visible = true;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Name = "_txtFields_0";
			this._txtFields_14.AutoSize = false;
			this._txtFields_14.Size = new System.Drawing.Size(202, 19);
			this._txtFields_14.Location = new System.Drawing.Point(89, 36);
			this._txtFields_14.TabIndex = 5;
			this._txtFields_14.AcceptsReturn = true;
			this._txtFields_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_14.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_14.CausesValidation = true;
			this._txtFields_14.Enabled = true;
			this._txtFields_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_14.HideSelection = true;
			this._txtFields_14.ReadOnly = false;
			this._txtFields_14.MaxLength = 0;
			this._txtFields_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_14.Multiline = false;
			this._txtFields_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_14.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_14.TabStop = true;
			this._txtFields_14.Visible = true;
			this._txtFields_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_14.Name = "_txtFields_14";
			this._chkFields_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_13.Text = "Discontinued:";
			this._chkFields_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_13.Size = new System.Drawing.Size(86, 19);
			this._chkFields_13.Location = new System.Drawing.Point(206, 132);
			this._chkFields_13.TabIndex = 11;
			this._chkFields_13.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_13.CausesValidation = true;
			this._chkFields_13.Enabled = true;
			this._chkFields_13.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_13.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_13.TabStop = true;
			this._chkFields_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_13.Visible = true;
			this._chkFields_13.Name = "_chkFields_13";
			this._chkFields_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_12.Text = "Disabled:";
			this._chkFields_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_12.Size = new System.Drawing.Size(64, 19);
			this._chkFields_12.Location = new System.Drawing.Point(140, 132);
			this._chkFields_12.TabIndex = 10;
			this._chkFields_12.BackColor = System.Drawing.SystemColors.Control;
			this._chkFields_12.CausesValidation = true;
			this._chkFields_12.Enabled = true;
			this._chkFields_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_12.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_12.TabStop = true;
			this._chkFields_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_12.Visible = true;
			this._chkFields_12.Name = "_chkFields_12";
			this._txtFields_8.AutoSize = false;
			this._txtFields_8.Size = new System.Drawing.Size(202, 19);
			this._txtFields_8.Location = new System.Drawing.Point(89, 15);
			this._txtFields_8.MaxLength = 40;
			this._txtFields_8.TabIndex = 4;
			this._txtFields_8.AcceptsReturn = true;
			this._txtFields_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_8.CausesValidation = true;
			this._txtFields_8.Enabled = true;
			this._txtFields_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_8.HideSelection = true;
			this._txtFields_8.ReadOnly = false;
			this._txtFields_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_8.Multiline = false;
			this._txtFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_8.TabStop = true;
			this._txtFields_8.Visible = true;
			this._txtFields_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_8.Name = "_txtFields_8";
			//cmbVat.OcxState = CType(resources.GetObject("cmbVat.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbVat.Size = new System.Drawing.Size(178, 21);
			this.cmbVat.Location = new System.Drawing.Point(89, 81);
			this.cmbVat.TabIndex = 7;
			this.cmbVat.Name = "cmbVat";
			//cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbDeposit.Size = new System.Drawing.Size(178, 21);
			this.cmbDeposit.Location = new System.Drawing.Point(89, 57);
			this.cmbDeposit.TabIndex = 6;
			this.cmbDeposit.Name = "cmbDeposit";
			//cmbSupplier.OcxState = CType(resources.GetObject("cmbSupplier.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbSupplier.Size = new System.Drawing.Size(178, 21);
			this.cmbSupplier.Location = new System.Drawing.Point(89, 105);
			this.cmbSupplier.TabIndex = 8;
			this.cmbSupplier.Name = "cmbSupplier";
			//cmbPrintLocation.OcxState = CType(resources.GetObject("cmbPrintLocation.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPrintLocation.Size = new System.Drawing.Size(175, 21);
			this.cmbPrintLocation.Location = new System.Drawing.Point(89, 156);
			this.cmbPrintLocation.TabIndex = 12;
			this.cmbPrintLocation.Name = "cmbPrintLocation";
			//cmbPrintGroup.OcxState = CType(resources.GetObject("cmbPrintGroup.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPrintGroup.Size = new System.Drawing.Size(174, 21);
			this.cmbPrintGroup.Location = new System.Drawing.Point(89, 180);
			this.cmbPrintGroup.TabIndex = 89;
			this.cmbPrintGroup.Name = "cmbPrintGroup";
			//cmbPackSize.OcxState = CType(resources.GetObject("cmbPackSize.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbPackSize.Size = new System.Drawing.Size(174, 21);
			this.cmbPackSize.Location = new System.Drawing.Point(89, 206);
			this.cmbPackSize.TabIndex = 110;
			this.cmbPackSize.Name = "cmbPackSize";
			this._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_16.Text = "Pack Size:";
			this._lblLabels_16.Size = new System.Drawing.Size(51, 13);
			this._lblLabels_16.Location = new System.Drawing.Point(32, 208);
			this._lblLabels_16.TabIndex = 111;
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
			this._lblLabels_13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_13.Text = "Print Group:";
			this._lblLabels_13.Size = new System.Drawing.Size(56, 13);
			this._lblLabels_13.Location = new System.Drawing.Point(27, 186);
			this._lblLabels_13.TabIndex = 90;
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
			this._lblLabels_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_12.Text = "Supplier Code:";
			this._lblLabels_12.Size = new System.Drawing.Size(69, 13);
			this._lblLabels_12.Location = new System.Drawing.Point(16, 135);
			this._lblLabels_12.TabIndex = 70;
			this._lblLabels_12.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_12.Enabled = true;
			this._lblLabels_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_12.UseMnemonic = true;
			this._lblLabels_12.Visible = true;
			this._lblLabels_12.AutoSize = true;
			this._lblLabels_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_12.Name = "_lblLabels_12";
			this._lblLabels_14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_14.Text = "POS Quick Key:";
			this._lblLabels_14.Size = new System.Drawing.Size(77, 13);
			this._lblLabels_14.Location = new System.Drawing.Point(7, 42);
			this._lblLabels_14.TabIndex = 69;
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
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Receipt Name:";
			this._lblLabels_8.Size = new System.Drawing.Size(71, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(13, 21);
			this._lblLabels_8.TabIndex = 68;
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
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_6.Text = "Deposit:";
			this._lblLabels_6.Size = new System.Drawing.Size(39, 13);
			this._lblLabels_6.Location = new System.Drawing.Point(45, 63);
			this._lblLabels_6.TabIndex = 67;
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
			this._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_5.Text = "VAT:";
			this._lblLabels_5.Size = new System.Drawing.Size(24, 13);
			this._lblLabels_5.Location = new System.Drawing.Point(60, 87);
			this._lblLabels_5.TabIndex = 66;
			this._lblLabels_5.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_5.Enabled = true;
			this._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_5.UseMnemonic = true;
			this._lblLabels_5.Visible = true;
			this._lblLabels_5.AutoSize = true;
			this._lblLabels_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_5.Name = "_lblLabels_5";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Default Supplier:";
			this._lblLabels_0.Size = new System.Drawing.Size(78, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(6, 111);
			this._lblLabels_0.TabIndex = 65;
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
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "Print Location:";
			this._lblLabels_2.Size = new System.Drawing.Size(68, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(16, 162);
			this._lblLabels_2.TabIndex = 64;
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
			this.txtholdname.AutoSize = false;
			this.txtholdname.Size = new System.Drawing.Size(63, 19);
			this.txtholdname.Location = new System.Drawing.Point(220, 570);
			this.txtholdname.TabIndex = 106;
			this.txtholdname.AcceptsReturn = true;
			this.txtholdname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtholdname.BackColor = System.Drawing.SystemColors.Window;
			this.txtholdname.CausesValidation = true;
			this.txtholdname.Enabled = true;
			this.txtholdname.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtholdname.HideSelection = true;
			this.txtholdname.ReadOnly = false;
			this.txtholdname.MaxLength = 0;
			this.txtholdname.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtholdname.Multiline = false;
			this.txtholdname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtholdname.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtholdname.TabStop = true;
			this.txtholdname.Visible = true;
			this.txtholdname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtholdname.Name = "txtholdname";
			this.txttemphold.AutoSize = false;
			this.txttemphold.Size = new System.Drawing.Size(83, 19);
			this.txttemphold.Location = new System.Drawing.Point(42, 572);
			this.txttemphold.TabIndex = 105;
			this.txttemphold.AcceptsReturn = true;
			this.txttemphold.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txttemphold.BackColor = System.Drawing.SystemColors.Window;
			this.txttemphold.CausesValidation = true;
			this.txttemphold.Enabled = true;
			this.txttemphold.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txttemphold.HideSelection = true;
			this.txttemphold.ReadOnly = false;
			this.txttemphold.MaxLength = 0;
			this.txttemphold.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txttemphold.Multiline = false;
			this.txttemphold.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txttemphold.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txttemphold.TabStop = true;
			this.txttemphold.Visible = true;
			this.txttemphold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txttemphold.Name = "txttemphold";
			this._txtFields_7.AutoSize = false;
			this._txtFields_7.Size = new System.Drawing.Size(202, 19);
			this._txtFields_7.Location = new System.Drawing.Point(103, 45);
			this._txtFields_7.MaxLength = 128;
			this._txtFields_7.TabIndex = 1;
			this._txtFields_7.AcceptsReturn = true;
			this._txtFields_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_7.CausesValidation = true;
			this._txtFields_7.Enabled = true;
			this._txtFields_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_7.HideSelection = true;
			this._txtFields_7.ReadOnly = false;
			this._txtFields_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_7.Multiline = false;
			this._txtFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_7.TabStop = true;
			this._txtFields_7.Visible = true;
			this._txtFields_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_7.Name = "_txtFields_7";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.Size = new System.Drawing.Size(79, 19);
			this._txtFields_1.Location = new System.Drawing.Point(596, 382);
			this._txtFields_1.TabIndex = 50;
			this._txtFields_1.Visible = false;
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.CausesValidation = true;
			this._txtFields_1.Enabled = true;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.HideSelection = true;
			this._txtFields_1.ReadOnly = false;
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.Multiline = false;
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_1.TabStop = true;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Name = "_txtFields_1";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(592, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 41;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next Item >";
			this.cmdNext.Size = new System.Drawing.Size(67, 29);
			this.cmdNext.Location = new System.Drawing.Point(427, 3);
			this.cmdNext.TabIndex = 108;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdHistory.Text = "&History";
			this.cmdHistory.Size = new System.Drawing.Size(67, 29);
			this.cmdHistory.Location = new System.Drawing.Point(233, 3);
			this.cmdHistory.TabIndex = 47;
			this.cmdHistory.TabStop = false;
			this.cmdHistory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHistory.CausesValidation = true;
			this.cmdHistory.Enabled = true;
			this.cmdHistory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHistory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHistory.Name = "cmdHistory";
			this.cmdDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDuplicate.Text = "&Duplicate Codes Report";
			this.cmdDuplicate.Size = new System.Drawing.Size(121, 29);
			this.cmdDuplicate.Location = new System.Drawing.Point(303, 3);
			this.cmdDuplicate.TabIndex = 46;
			this.cmdDuplicate.TabStop = false;
			this.cmdDuplicate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDuplicate.CausesValidation = true;
			this.cmdDuplicate.Enabled = true;
			this.cmdDuplicate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDuplicate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDuplicate.Name = "cmdDuplicate";
			this.cmdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDetails.Text = "&Pricing";
			this.cmdDetails.Size = new System.Drawing.Size(73, 29);
			this.cmdDetails.Location = new System.Drawing.Point(157, 3);
			this.cmdDetails.TabIndex = 45;
			this.cmdDetails.TabStop = false;
			this.cmdDetails.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDetails.CausesValidation = true;
			this.cmdDetails.Enabled = true;
			this.cmdDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDetails.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDetails.Name = "cmdDetails";
			this.cmdbarcodeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdbarcodeItem.Text = "&Barcodes";
			this.cmdbarcodeItem.Size = new System.Drawing.Size(73, 29);
			this.cmdbarcodeItem.Location = new System.Drawing.Point(82, 3);
			this.cmdbarcodeItem.TabIndex = 44;
			this.cmdbarcodeItem.TabStop = false;
			this.cmdbarcodeItem.BackColor = System.Drawing.SystemColors.Control;
			this.cmdbarcodeItem.CausesValidation = true;
			this.cmdbarcodeItem.Enabled = true;
			this.cmdbarcodeItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdbarcodeItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdbarcodeItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdbarcodeItem.Name = "cmdbarcodeItem";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 43;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(510, 3);
			this.cmdClose.TabIndex = 42;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.ILtree.ImageSize = new System.Drawing.Size(16, 16);
			this.ILtree.TransparentColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.ILtree.Images.SetKeyName(0, "");
			this.ILtree.Images.SetKeyName(1, "");
			this.ILtree.Images.SetKeyName(2, "");
			this._Frame1_1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_1.Size = new System.Drawing.Size(556, 395);
			this._Frame1_1.Location = new System.Drawing.Point(12, 104);
			this._Frame1_1.TabIndex = 34;
			this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_1.Enabled = true;
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Visible = true;
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.Name = "_Frame1_1";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "Print Bill Of Material";
			this.cmdPrint.Size = new System.Drawing.Size(106, 34);
			this.cmdPrint.Location = new System.Drawing.Point(174, 15);
			this.cmdPrint.TabIndex = 91;
			this.cmdPrint.Visible = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdRecipeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRecipeAdd.Text = "Add StockItem";
			this.cmdRecipeAdd.Size = new System.Drawing.Size(100, 34);
			this.cmdRecipeAdd.Location = new System.Drawing.Point(390, 15);
			this.cmdRecipeAdd.TabIndex = 35;
			this.cmdRecipeAdd.TabStop = false;
			this.cmdRecipeAdd.Visible = false;
			this.cmdRecipeAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRecipeAdd.CausesValidation = true;
			this.cmdRecipeAdd.Enabled = true;
			this.cmdRecipeAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRecipeAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRecipeAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRecipeAdd.Name = "cmdRecipeAdd";
			this._optRecipeType_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optRecipeType_0.Text = "Not a Bill Of Material";
			this._optRecipeType_0.Size = new System.Drawing.Size(133, 58);
			this._optRecipeType_0.Location = new System.Drawing.Point(27, 57);
			this._optRecipeType_0.Appearance = System.Windows.Forms.Appearance.Button;
			this._optRecipeType_0.TabIndex = 36;
			this._optRecipeType_0.TabStop = false;
			this._optRecipeType_0.Checked = true;
			this._optRecipeType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optRecipeType_0.BackColor = System.Drawing.SystemColors.Control;
			this._optRecipeType_0.CausesValidation = true;
			this._optRecipeType_0.Enabled = true;
			this._optRecipeType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optRecipeType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optRecipeType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optRecipeType_0.Visible = true;
			this._optRecipeType_0.Name = "_optRecipeType_0";
			this._optRecipeType_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optRecipeType_1.Text = "Production";
			this._optRecipeType_1.Size = new System.Drawing.Size(133, 58);
			this._optRecipeType_1.Location = new System.Drawing.Point(27, 129);
			this._optRecipeType_1.Appearance = System.Windows.Forms.Appearance.Button;
			this._optRecipeType_1.TabIndex = 37;
			this._optRecipeType_1.TabStop = false;
			this._optRecipeType_1.Visible = false;
			this._optRecipeType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optRecipeType_1.BackColor = System.Drawing.SystemColors.Control;
			this._optRecipeType_1.CausesValidation = true;
			this._optRecipeType_1.Enabled = true;
			this._optRecipeType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optRecipeType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optRecipeType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optRecipeType_1.Checked = false;
			this._optRecipeType_1.Name = "_optRecipeType_1";
			this._optRecipeType_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optRecipeType_2.Text = "At time of Sale";
			this._optRecipeType_2.Size = new System.Drawing.Size(133, 58);
			this._optRecipeType_2.Location = new System.Drawing.Point(27, 201);
			this._optRecipeType_2.Appearance = System.Windows.Forms.Appearance.Button;
			this._optRecipeType_2.TabIndex = 38;
			this._optRecipeType_2.TabStop = false;
			this._optRecipeType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optRecipeType_2.BackColor = System.Drawing.SystemColors.Control;
			this._optRecipeType_2.CausesValidation = true;
			this._optRecipeType_2.Enabled = true;
			this._optRecipeType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optRecipeType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._optRecipeType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optRecipeType_2.Checked = false;
			this._optRecipeType_2.Visible = true;
			this._optRecipeType_2.Name = "_optRecipeType_2";
			this.txtQuantity.AutoSize = false;
			this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.txtQuantity.Size = new System.Drawing.Size(64, 19);
			this.txtQuantity.Location = new System.Drawing.Point(168, 336);
			this.txtQuantity.TabIndex = 48;
			this.txtQuantity.Text = "Text1";
			this.txtQuantity.Visible = false;
			this.txtQuantity.AcceptsReturn = true;
			this.txtQuantity.CausesValidation = true;
			this.txtQuantity.Enabled = true;
			this.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantity.HideSelection = true;
			this.txtQuantity.ReadOnly = false;
			this.txtQuantity.MaxLength = 0;
			this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtQuantity.Multiline = false;
			this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtQuantity.TabStop = true;
			this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtQuantity.Name = "txtQuantity";
			this._optRecipeType_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._optRecipeType_3.Text = "This Product makes other products";
			this._optRecipeType_3.Size = new System.Drawing.Size(133, 58);
			this._optRecipeType_3.Location = new System.Drawing.Point(27, 273);
			this._optRecipeType_3.Appearance = System.Windows.Forms.Appearance.Button;
			this._optRecipeType_3.TabIndex = 39;
			this._optRecipeType_3.TabStop = false;
			this._optRecipeType_3.Visible = false;
			this._optRecipeType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optRecipeType_3.BackColor = System.Drawing.SystemColors.Control;
			this._optRecipeType_3.CausesValidation = true;
			this._optRecipeType_3.Enabled = true;
			this._optRecipeType_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optRecipeType_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._optRecipeType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optRecipeType_3.Checked = false;
			this._optRecipeType_3.Name = "_optRecipeType_3";
			//FGRecipe.OcxState = CType(resources.GetObject("FGRecipe.OcxState"), System.Windows.Forms.AxHost.State)
			this.FGRecipe.Size = new System.Drawing.Size(366, 274);
			this.FGRecipe.Location = new System.Drawing.Point(174, 57);
			this.FGRecipe.TabIndex = 40;
			this.FGRecipe.Name = "FGRecipe";
			this.lblRecipeCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblRecipeCost.Text = "0.00";
			this.lblRecipeCost.Size = new System.Drawing.Size(88, 19);
			this.lblRecipeCost.Location = new System.Drawing.Point(396, 333);
			this.lblRecipeCost.TabIndex = 49;
			this.lblRecipeCost.BackColor = System.Drawing.SystemColors.Control;
			this.lblRecipeCost.Enabled = true;
			this.lblRecipeCost.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblRecipeCost.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblRecipeCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRecipeCost.UseMnemonic = true;
			this.lblRecipeCost.Visible = true;
			this.lblRecipeCost.AutoSize = false;
			this.lblRecipeCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblRecipeCost.Name = "lblRecipeCost";
			this._Frame1_2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._Frame1_2.Size = new System.Drawing.Size(556, 385);
			this._Frame1_2.Location = new System.Drawing.Point(12, 96);
			this._Frame1_2.TabIndex = 78;
			this._Frame1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_2.Enabled = true;
			this._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_2.Visible = true;
			this._Frame1_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_2.Name = "_Frame1_2";
			this._cmdNew_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdNew_2.Text = "New Child  from existed Stock";
			this._cmdNew_2.Size = new System.Drawing.Size(79, 52);
			this._cmdNew_2.Location = new System.Drawing.Point(468, 75);
			this._cmdNew_2.TabIndex = 112;
			this._cmdNew_2.TabStop = false;
			this._cmdNew_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNew_2.CausesValidation = true;
			this._cmdNew_2.Enabled = true;
			this._cmdNew_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNew_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdNew_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNew_2.Name = "_cmdNew_2";
			this.cmdDeallocate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeallocate.Text = "De-allocate >>";
			this.cmdDeallocate.Size = new System.Drawing.Size(82, 31);
			this.cmdDeallocate.Location = new System.Drawing.Point(210, 252);
			this.cmdDeallocate.TabIndex = 85;
			this.cmdDeallocate.TabStop = false;
			this.cmdDeallocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeallocate.CausesValidation = true;
			this.cmdDeallocate.Enabled = true;
			this.cmdDeallocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeallocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeallocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeallocate.Name = "cmdDeallocate";
			this.cmdAllocate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAllocate.Text = "<< Allocate";
			this.cmdAllocate.Size = new System.Drawing.Size(82, 31);
			this.cmdAllocate.Location = new System.Drawing.Point(210, 84);
			this.cmdAllocate.TabIndex = 84;
			this.cmdAllocate.TabStop = false;
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.CausesValidation = true;
			this.cmdAllocate.Enabled = true;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Name = "cmdAllocate";
			this._cmdMove_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdMove_1.Text = "Move Down";
			this._cmdMove_1.Size = new System.Drawing.Size(79, 28);
			this._cmdMove_1.Location = new System.Drawing.Point(468, 197);
			this._cmdMove_1.TabIndex = 83;
			this._cmdMove_1.TabStop = false;
			this._cmdMove_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdMove_1.CausesValidation = true;
			this._cmdMove_1.Enabled = true;
			this._cmdMove_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdMove_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdMove_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdMove_1.Name = "_cmdMove_1";
			this._cmdMove_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdMove_0.Text = "Move Up";
			this._cmdMove_0.Size = new System.Drawing.Size(79, 28);
			this._cmdMove_0.Location = new System.Drawing.Point(468, 167);
			this._cmdMove_0.TabIndex = 82;
			this._cmdMove_0.TabStop = false;
			this._cmdMove_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdMove_0.CausesValidation = true;
			this._cmdMove_0.Enabled = true;
			this._cmdMove_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdMove_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdMove_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdMove_0.Name = "_cmdMove_0";
			this._cmdNew_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdNew_1.Text = "New Child";
			this._cmdNew_1.Size = new System.Drawing.Size(79, 28);
			this._cmdNew_1.Location = new System.Drawing.Point(468, 45);
			this._cmdNew_1.TabIndex = 81;
			this._cmdNew_1.TabStop = false;
			this._cmdNew_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNew_1.CausesValidation = true;
			this._cmdNew_1.Enabled = true;
			this._cmdNew_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNew_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNew_1.Name = "_cmdNew_1";
			this._cmdNew_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdNew_0.Text = "New Message";
			this._cmdNew_0.Size = new System.Drawing.Size(79, 28);
			this._cmdNew_0.Location = new System.Drawing.Point(468, 15);
			this._cmdNew_0.TabIndex = 80;
			this._cmdNew_0.TabStop = false;
			this._cmdNew_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNew_0.CausesValidation = true;
			this._cmdNew_0.Enabled = true;
			this._cmdNew_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNew_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdNew_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNew_0.Name = "_cmdNew_0";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete Item";
			this.cmdDelete.Size = new System.Drawing.Size(79, 28);
			this.cmdDelete.Location = new System.Drawing.Point(468, 321);
			this.cmdDelete.TabIndex = 79;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.TVMessage.CausesValidation = true;
			this.TVMessage.Size = new System.Drawing.Size(157, 334);
			this.TVMessage.Location = new System.Drawing.Point(303, 15);
			this.TVMessage.TabIndex = 86;
			this.TVMessage.HideSelection = false;
			this.TVMessage.Indent = 36;
			this.TVMessage.LabelEdit = false;
			this.TVMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TVMessage.Name = "TVMessage";
			this.TreeView1.CausesValidation = true;
			this.TreeView1.Size = new System.Drawing.Size(193, 334);
			this.TreeView1.Location = new System.Drawing.Point(9, 15);
			this.TreeView1.TabIndex = 87;
			this.TreeView1.HideSelection = false;
			this.TreeView1.Indent = 36;
			this.TreeView1.LabelEdit = false;
			this.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TreeView1.Name = "TreeView1";
			//TabStrip1.OcxState = CType(resources.GetObject("TabStrip1.OcxState"), System.Windows.Forms.AxHost.State)
			//Me.TabStrip1.Size = New System.Drawing.Size(577, 469)
			//Me.TabStrip1.Location = New System.Drawing.Point(8, 68)
			//Me.TabStrip1.TabIndex = 2
			//Me.TabStrip1.Name = "TabStrip1"
			this._Frame1_3.Size = new System.Drawing.Size(560, 387);
			this._Frame1_3.Location = new System.Drawing.Point(10, 108);
			this._Frame1_3.TabIndex = 94;
			this._Frame1_3.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_3.Enabled = true;
			this._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_3.Visible = true;
			this._Frame1_3.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_3.Name = "_Frame1_3";
			this.Frame4.Text = "Details";
			this.Frame4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Frame4.Size = new System.Drawing.Size(531, 379);
			this.Frame4.Location = new System.Drawing.Point(6, 6);
			this.Frame4.TabIndex = 95;
			this.Frame4.BackColor = System.Drawing.SystemColors.Control;
			this.Frame4.Enabled = true;
			this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Visible = true;
			this.Frame4.Padding = new System.Windows.Forms.Padding(0);
			this.Frame4.Name = "Frame4";
			this.lstvSerial.Size = new System.Drawing.Size(519, 339);
			this.lstvSerial.Location = new System.Drawing.Point(10, 12);
			this.lstvSerial.TabIndex = 96;
			this.lstvSerial.View = System.Windows.Forms.View.Details;
			this.lstvSerial.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.lstvSerial.LabelWrap = true;
			this.lstvSerial.HideSelection = true;
			this.lstvSerial.FullRowSelect = true;
			this.lstvSerial.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstvSerial.BackColor = System.Drawing.SystemColors.Window;
			this.lstvSerial.LabelEdit = true;
			this.lstvSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstvSerial.Name = "lstvSerial";
			this._lstvSerial_ColumnHeader_1.Text = "Serial Number";
			this._lstvSerial_ColumnHeader_1.Width = 170;
			this._lstvSerial_ColumnHeader_2.Text = "Supplier's Name";
			this._lstvSerial_ColumnHeader_2.Width = 170;
			this._lstvSerial_ColumnHeader_3.Text = "Date Purchased";
			this._lstvSerial_ColumnHeader_3.Width = 170;
			this._lstvSerial_ColumnHeader_4.Text = "In Stock";
			this._lstvSerial_ColumnHeader_4.Width = 170;
			this._lstvSerial_ColumnHeader_5.Text = "Date Sold";
			this._lstvSerial_ColumnHeader_5.Width = 170;
			this._lstvSerial_ColumnHeader_6.Text = "Invoice Number";
			this._lstvSerial_ColumnHeader_6.Width = 170;
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.Text = "Display Name:";
			this._lblLabels_7.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_7.Size = new System.Drawing.Size(89, 16);
			this._lblLabels_7.Location = new System.Drawing.Point(10, 48);
			this._lblLabels_7.TabIndex = 0;
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
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(txtholdname);
			this.Controls.Add(txttemphold);
			this.Controls.Add(_txtFields_7);
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(picButtons);
			this.Controls.Add(_Frame1_1);
			this.Controls.Add(_Frame1_2);
			//Me.Controls.Add(TabStrip1)
			this.Controls.Add(_Frame1_3);
			this.Controls.Add(_lblLabels_7);
			this._Frame1_0.Controls.Add(Frame6);
			this._Frame1_0.Controls.Add(Frame5);
			this._Frame1_0.Controls.Add(Frame3);
			this._Frame1_0.Controls.Add(_Frame2_1);
			this._Frame1_0.Controls.Add(_Frame2_2);
			this._Frame1_0.Controls.Add(_Frame2_3);
			this._Frame1_0.Controls.Add(_Frame2_4);
			this._Frame1_0.Controls.Add(_Frame2_5);
			this._Frame1_0.Controls.Add(_Frame2_0);
			this.Frame6.Controls.Add(_chkSerialTracking_1);
			this.Frame6.Controls.Add(_chkFields_6);
			this.Frame5.Controls.Add(chkbarcode);
			this.Frame5.Controls.Add(chkshelf);
			this.Frame3.Controls.Add(_chkFields_1);
			this.Frame3.Controls.Add(_chkSerialTracking_0);
			this._Frame2_1.Controls.Add(cmdReportGroup);
			this._Frame2_1.Controls.Add(cmdStockGroup);
			this._Frame2_1.Controls.Add(cmdPricingGroup);
			this._Frame2_1.Controls.Add(cmbPricingGroup);
			this._Frame2_1.Controls.Add(cmbStockGroup);
			this._Frame2_1.Controls.Add(cmbReportGroup);
			this._Frame2_1.Controls.Add(_lblLabels_15);
			this._Frame2_1.Controls.Add(_lblLabels_4);
			this._Frame2_1.Controls.Add(_lblLabels_3);
			this._Frame2_2.Controls.Add(cmdShrink);
			this._Frame2_2.Controls.Add(_txtFloat_1);
			this._Frame2_2.Controls.Add(_txtFloat_0);
			this._Frame2_2.Controls.Add(_txtInteger_0);
			this._Frame2_2.Controls.Add(cmbShrink);
			this._Frame2_2.Controls.Add(_lblLabels_11);
			this._Frame2_2.Controls.Add(_lblLabels_10);
			this._Frame2_2.Controls.Add(_lblLabels_9);
			this._Frame2_2.Controls.Add(_lblLabels_1);
			this._Frame2_3.Controls.Add(cmbReorder);
			this._Frame2_3.Controls.Add(_txtInteger_3);
			this._Frame2_3.Controls.Add(_txtInteger_1);
			this._Frame2_3.Controls.Add(_chkFields_0);
			this._Frame2_3.Controls.Add(_txtInteger_2);
			this._Frame2_3.Controls.Add(_lbl_7);
			this._Frame2_3.Controls.Add(_lbl_0);
			this._Frame2_3.Controls.Add(_lbl_5);
			this._Frame2_3.Controls.Add(_lbl_4);
			this._Frame2_4.Controls.Add(cmdpriceselist);
			this._Frame2_4.Controls.Add(chkPriceSet);
			this._Frame2_4.Controls.Add(cmbPriceSet);
			this._Frame2_4.Controls.Add(lblPriceSet);
			this._Frame2_5.Controls.Add(_txtInteger_4);
			this._Frame2_5.Controls.Add(_chkFields_5);
			this._Frame2_5.Controls.Add(chkSQ);
			this._Frame2_5.Controls.Add(_chkFields_3);
			this._Frame2_5.Controls.Add(_chkFields_2);
			this._Frame2_5.Controls.Add(_chkFields_4);
			this._Frame2_5.Controls.Add(_lbl_1);
			this._Frame2_0.Controls.Add(cmdPackSize);
			this._Frame2_0.Controls.Add(cmdPrintGroup);
			this._Frame2_0.Controls.Add(cmdVAT);
			this._Frame2_0.Controls.Add(cmdPrintLocation);
			this._Frame2_0.Controls.Add(cmdSupplier);
			this._Frame2_0.Controls.Add(cmdDeposit);
			this._Frame2_0.Controls.Add(_txtFields_0);
			this._Frame2_0.Controls.Add(_txtFields_14);
			this._Frame2_0.Controls.Add(_chkFields_13);
			this._Frame2_0.Controls.Add(_chkFields_12);
			this._Frame2_0.Controls.Add(_txtFields_8);
			this._Frame2_0.Controls.Add(cmbVat);
			this._Frame2_0.Controls.Add(cmbDeposit);
			this._Frame2_0.Controls.Add(cmbSupplier);
			this._Frame2_0.Controls.Add(cmbPrintLocation);
			this._Frame2_0.Controls.Add(cmbPrintGroup);
			this._Frame2_0.Controls.Add(cmbPackSize);
			this._Frame2_0.Controls.Add(_lblLabels_16);
			this._Frame2_0.Controls.Add(_lblLabels_13);
			this._Frame2_0.Controls.Add(_lblLabels_12);
			this._Frame2_0.Controls.Add(_lblLabels_14);
			this._Frame2_0.Controls.Add(_lblLabels_8);
			this._Frame2_0.Controls.Add(_lblLabels_6);
			this._Frame2_0.Controls.Add(_lblLabels_5);
			this._Frame2_0.Controls.Add(_lblLabels_0);
			this._Frame2_0.Controls.Add(_lblLabels_2);
			this.picButtons.Controls.Add(cmdNext);
			this.picButtons.Controls.Add(cmdHistory);
			this.picButtons.Controls.Add(cmdDuplicate);
			this.picButtons.Controls.Add(cmdDetails);
			this.picButtons.Controls.Add(cmdbarcodeItem);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			this._Frame1_1.Controls.Add(cmdPrint);
			this._Frame1_1.Controls.Add(cmdRecipeAdd);
			this._Frame1_1.Controls.Add(_optRecipeType_0);
			this._Frame1_1.Controls.Add(_optRecipeType_1);
			this._Frame1_1.Controls.Add(_optRecipeType_2);
			this._Frame1_1.Controls.Add(txtQuantity);
			this._Frame1_1.Controls.Add(_optRecipeType_3);
			this._Frame1_1.Controls.Add(FGRecipe);
			this._Frame1_1.Controls.Add(lblRecipeCost);
			this._Frame1_2.Controls.Add(_cmdNew_2);
			this._Frame1_2.Controls.Add(cmdDeallocate);
			this._Frame1_2.Controls.Add(cmdAllocate);
			this._Frame1_2.Controls.Add(_cmdMove_1);
			this._Frame1_2.Controls.Add(_cmdMove_0);
			this._Frame1_2.Controls.Add(_cmdNew_1);
			this._Frame1_2.Controls.Add(_cmdNew_0);
			this._Frame1_2.Controls.Add(cmdDelete);
			this._Frame1_2.Controls.Add(TVMessage);
			this._Frame1_2.Controls.Add(TreeView1);
			this._Frame1_3.Controls.Add(Frame4);
			this.Frame4.Controls.Add(lstvSerial);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_1);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_2);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_3);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_4);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_5);
			this.lstvSerial.Columns.Add(_lstvSerial_ColumnHeader_6);
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
			//Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
			//Me.Frame1.SetIndex(_Frame1_3, CType(3, Short))
			//Me.Frame2.SetIndex(_Frame2_1, CType(1, Short))
			//Me.Frame2.SetIndex(_Frame2_2, CType(2, Short))
			//Me.Frame2.SetIndex(_Frame2_3, CType(3, Short))
			//Me.Frame2.SetIndex(_Frame2_4, CType(4, Short))
			//Me.Frame2.SetIndex(_Frame2_5, CType(5, Short))
			//Me.Frame2.SetIndex(_Frame2_0, CType(0, Short))
			//Me.chkFields.SetIndex(_chkFields_6, CType(6, Short))
			//Me.chkFields.SetIndex(_chkFields_1, CType(1, Short))
			//Me.chkFields.SetIndex(_chkFields_0, CType(0, Short))
			//Me.chkFields.SetIndex(_chkFields_5, CType(5, Short))
			//Me.chkFields.SetIndex(_chkFields_3, CType(3, Short))
			//Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
			//Me.chkFields.SetIndex(_chkFields_4, CType(4, Short))
			//Me.chkFields.SetIndex(_chkFields_13, CType(13, Short))
			//Me.chkFields.SetIndex(_chkFields_12, CType(12, Short))
			//Me.chkSerialTracking.SetIndex(_chkSerialTracking_1, CType(1, Short))
			//Me.chkSerialTracking.SetIndex(_chkSerialTracking_0, CType(0, Short))
			//Me.cmdMove.SetIndex(_cmdMove_1, CType(1, Short))
			//Me.cmdMove.SetIndex(_cmdMove_0, CType(0, Short))
			//Me.cmdNew.SetIndex(_cmdNew_2, CType(2, Short))
			//Me.cmdNew.SetIndex(_cmdNew_1, CType(1, Short))
			//Me.cmdNew.SetIndex(_cmdNew_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//M() ''e.lblLabels.SetIndex(_lblLabels_15, CType(15, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
			//Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
			//Me.lblLabels.SetIndex(_lblLabels_11, CType(11, Short))
			//Me.lblLabels.SetIndex(_lblLabels_10, CType(10, Short))
			//Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_16, CType(16, Short))
			//Me.lblLabels.SetIndex(_lblLabels_13, CType(13, Short))
			//Me.lblLabels.SetIndex(_lblLabels_12, CType(12, Short))
			//Me.lblLabels.SetIndex(_lblLabels_14, CType(14, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//M() ''e.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.optRecipeType.SetIndex(_optRecipeType_0, CType(0, Short))
			//Me.optRecipeType.SetIndex(_optRecipeType_1, CType(1, Short))
			//Me.optRecipeType.SetIndex(_optRecipeType_2, CType(2, Short))
			//Me.optRecipeType.SetIndex(_optRecipeType_3, CType(3, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			//Me.txtFields.SetIndex(_txtFields_14, CType(14, Short))
			//Me.txtFields.SetIndex(_txtFields_8, CType(8, Short))
			//Me.txtFields.SetIndex(_txtFields_7, CType(7, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.txtFloat.SetIndex(_txtFloat_1, CType(1, Short))
			//Me.txtFloat.SetIndex(_txtFloat_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_3, CType(3, Short))
			//Me.txtInteger.SetIndex(_txtInteger_1, CType(1, Short))
			//Me.txtInteger.SetIndex(_txtInteger_2, CType(2, Short))
			//Me.txtInteger.SetIndex(_txtInteger_4, CType(4, Short))
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.optRecipeType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdNew, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdMove, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkSerialTracking, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame2, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.TabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.FGRecipe).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPackSize).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPrintGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPrintLocation).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbSupplier).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbVat).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPriceSet).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbShrink).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbReportGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbStockGroup).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmbPricingGroup).EndInit();
			this._Frame1_0.ResumeLayout(false);
			this.Frame6.ResumeLayout(false);
			this.Frame5.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this._Frame2_1.ResumeLayout(false);
			this._Frame2_2.ResumeLayout(false);
			this._Frame2_3.ResumeLayout(false);
			this._Frame2_4.ResumeLayout(false);
			this._Frame2_5.ResumeLayout(false);
			this._Frame2_0.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this._Frame1_1.ResumeLayout(false);
			this._Frame1_2.ResumeLayout(false);
			this._Frame1_3.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this.lstvSerial.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
