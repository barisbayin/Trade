
namespace DevExpressUI
{
    partial class TradeMonitorUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeMonitorUC));
            this.gridTradeFlowPartial = new DevExpress.XtraGrid.GridControl();
            this.gvTradeFlowPartial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselect = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tabPaneTradeMonitor = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavTradeMonitor = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcTradeMonitorList = new DevExpress.XtraEditors.GroupControl();
            this.tpEntries = new DevExpress.Utils.Layout.TablePanel();
            this.lblIsSelectedLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIsSelected = new DevExpress.XtraEditors.LabelControl();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.lblIdNo = new DevExpress.XtraEditors.LabelControl();
            this.lblSymbolPair = new DevExpress.XtraEditors.LabelControl();
            this.lblIndicatorParameter = new DevExpress.XtraEditors.LabelControl();
            this.lblApiToUse = new DevExpress.XtraEditors.LabelControl();
            this.lblAddPnlToMAL = new DevExpress.XtraEditors.LabelControl();
            this.lblMaxAmountLimitPercentage = new DevExpress.XtraEditors.LabelControl();
            this.lblMaxAmountLimit = new DevExpress.XtraEditors.LabelControl();
            this.lblLeverage = new DevExpress.XtraEditors.LabelControl();
            this.lblMarginType = new DevExpress.XtraEditors.LabelControl();
            this.lblPercentageOfPnl = new DevExpress.XtraEditors.LabelControl();
            this.cbxTradeParameterTitle = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblTradeParameterTitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblModifiedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblModifiedDateLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblInUse = new DevExpress.XtraEditors.LabelControl();
            this.lblCreationDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCreationDateLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblInUseLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblPercentageOfPnlToBeAddedLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblAddPnlToMaxAmountLimitLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblMaxAmountPercentageLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblLeverageLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblMarginTypeLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblSymbolPairLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumAmountLimitLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIntervalLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblApiToUseLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIndicatorParameterLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIdLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridTradeFlowPartial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeFlowPartial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneTradeMonitor)).BeginInit();
            this.tabPaneTradeMonitor.SuspendLayout();
            this.tabNavTradeMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTradeMonitorList)).BeginInit();
            this.gcTradeMonitorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpEntries)).BeginInit();
            this.tpEntries.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTradeFlowPartial
            // 
            this.gridTradeFlowPartial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTradeFlowPartial.Location = new System.Drawing.Point(2, 21);
            this.gridTradeFlowPartial.MainView = this.gvTradeFlowPartial;
            this.gridTradeFlowPartial.Name = "gridTradeFlowPartial";
            this.gridTradeFlowPartial.Size = new System.Drawing.Size(697, 813);
            this.gridTradeFlowPartial.TabIndex = 0;
            this.gridTradeFlowPartial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTradeFlowPartial});
            // 
            // gvTradeFlowPartial
            // 
            this.gvTradeFlowPartial.GridControl = this.gridTradeFlowPartial;
            this.gvTradeFlowPartial.Name = "gvTradeFlowPartial";
            this.gvTradeFlowPartial.OptionsView.ShowGroupPanel = false;
            this.gvTradeFlowPartial.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvTradeFlowPartial_RowStyle);
            this.gvTradeFlowPartial.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTradeFlowPartial_FocusedRowChanged);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(51, 153);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 18);
            this.lblResult.TabIndex = 3;
            this.lblResult.UseMnemonic = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNew.Location = new System.Drawing.Point(70, 106);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 34);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelete.Location = new System.Drawing.Point(160, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnSelect);
            this.groupControl1.Controls.Add(this.btnUnselect);
            this.groupControl1.Controls.Add(this.btnStart);
            this.groupControl1.Controls.Add(this.lblResult);
            this.groupControl1.Controls.Add(this.btnNew);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 650);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(400, 186);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.ImageOptions.Image")));
            this.btnSelect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSelect.Location = new System.Drawing.Point(57, 30);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(140, 43);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnUnselect
            // 
            this.btnUnselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnselect.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnUnselect.Appearance.Options.UseFont = true;
            this.btnUnselect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselect.ImageOptions.Image")));
            this.btnUnselect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUnselect.Location = new System.Drawing.Point(57, 30);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(140, 43);
            this.btnUnselect.TabIndex = 6;
            this.btnUnselect.Text = "Unselect";
            this.btnUnselect.Visible = false;
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.ImageOptions.Image")));
            this.btnStart.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnStart.Location = new System.Drawing.Point(203, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 43);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Trade!";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(250, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Save";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabPaneTradeMonitor
            // 
            this.tabPaneTradeMonitor.Controls.Add(this.tabNavTradeMonitor);
            this.tabPaneTradeMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneTradeMonitor.Location = new System.Drawing.Point(0, 0);
            this.tabPaneTradeMonitor.Name = "tabPaneTradeMonitor";
            this.tabPaneTradeMonitor.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneTradeMonitor.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavTradeMonitor});
            this.tabPaneTradeMonitor.RegularSize = new System.Drawing.Size(1111, 862);
            this.tabPaneTradeMonitor.SelectedPage = this.tabNavTradeMonitor;
            this.tabPaneTradeMonitor.Size = new System.Drawing.Size(1111, 862);
            this.tabPaneTradeMonitor.TabIndex = 4;
            this.tabPaneTradeMonitor.Text = "tpaneTradeMonitor";
            // 
            // tabNavTradeMonitor
            // 
            this.tabNavTradeMonitor.Caption = "Trade Flows";
            this.tabNavTradeMonitor.Controls.Add(this.splitContainerControl1);
            this.tabNavTradeMonitor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavTradeMonitor.ImageOptions.Image")));
            this.tabNavTradeMonitor.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavTradeMonitor.Name = "tabNavTradeMonitor";
            this.tabNavTradeMonitor.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavTradeMonitor.Size = new System.Drawing.Size(1111, 836);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcTradeMonitorList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tpEntries);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.MinSize = 400;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1111, 836);
            this.splitContainerControl1.SplitterPosition = 400;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcTradeMonitorList
            // 
            this.gcTradeMonitorList.Appearance.Options.UseTextOptions = true;
            this.gcTradeMonitorList.AppearanceCaption.Options.UseTextOptions = true;
            this.gcTradeMonitorList.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcTradeMonitorList.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gcTradeMonitorList.CaptionImageOptions.Image")));
            this.gcTradeMonitorList.Controls.Add(this.gridTradeFlowPartial);
            this.gcTradeMonitorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTradeMonitorList.Location = new System.Drawing.Point(0, 0);
            this.gcTradeMonitorList.Name = "gcTradeMonitorList";
            this.gcTradeMonitorList.Size = new System.Drawing.Size(701, 836);
            this.gcTradeMonitorList.TabIndex = 0;
            this.gcTradeMonitorList.Text = "Trade Flow List";
            // 
            // tpEntries
            // 
            this.tpEntries.AutoScroll = true;
            this.tpEntries.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tpEntries.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 63.74F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 85.92F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 3.89F)});
            this.tpEntries.Controls.Add(this.lblIsSelectedLabel);
            this.tpEntries.Controls.Add(this.lblIsSelected);
            this.tpEntries.Controls.Add(this.lblInterval);
            this.tpEntries.Controls.Add(this.lblIdNo);
            this.tpEntries.Controls.Add(this.lblSymbolPair);
            this.tpEntries.Controls.Add(this.lblIndicatorParameter);
            this.tpEntries.Controls.Add(this.lblApiToUse);
            this.tpEntries.Controls.Add(this.lblAddPnlToMAL);
            this.tpEntries.Controls.Add(this.lblMaxAmountLimitPercentage);
            this.tpEntries.Controls.Add(this.lblMaxAmountLimit);
            this.tpEntries.Controls.Add(this.lblLeverage);
            this.tpEntries.Controls.Add(this.lblMarginType);
            this.tpEntries.Controls.Add(this.lblPercentageOfPnl);
            this.tpEntries.Controls.Add(this.cbxTradeParameterTitle);
            this.tpEntries.Controls.Add(this.btnRefresh);
            this.tpEntries.Controls.Add(this.lblTradeParameterTitleLabel);
            this.tpEntries.Controls.Add(this.lblModifiedDate);
            this.tpEntries.Controls.Add(this.lblModifiedDateLabel);
            this.tpEntries.Controls.Add(this.lblInUse);
            this.tpEntries.Controls.Add(this.lblCreationDate);
            this.tpEntries.Controls.Add(this.lblCreationDateLabel);
            this.tpEntries.Controls.Add(this.lblInUseLabel);
            this.tpEntries.Controls.Add(this.lblPercentageOfPnlToBeAddedLabel);
            this.tpEntries.Controls.Add(this.lblAddPnlToMaxAmountLimitLabel);
            this.tpEntries.Controls.Add(this.lblMaxAmountPercentageLabel);
            this.tpEntries.Controls.Add(this.lblLeverageLabel);
            this.tpEntries.Controls.Add(this.lblMarginTypeLabel);
            this.tpEntries.Controls.Add(this.lblSymbolPairLabel);
            this.tpEntries.Controls.Add(this.lblMaximumAmountLimitLabel);
            this.tpEntries.Controls.Add(this.lblIntervalLabel);
            this.tpEntries.Controls.Add(this.lblApiToUseLabel);
            this.tpEntries.Controls.Add(this.lblIndicatorParameterLabel);
            this.tpEntries.Controls.Add(this.lblIdLabel);
            this.tpEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpEntries.Location = new System.Drawing.Point(0, 0);
            this.tpEntries.Name = "tpEntries";
            this.tpEntries.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 44F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tpEntries.Size = new System.Drawing.Size(400, 650);
            this.tpEntries.TabIndex = 2;
            // 
            // lblIsSelectedLabel
            // 
            this.tpEntries.SetColumn(this.lblIsSelectedLabel, 1);
            this.lblIsSelectedLabel.Location = new System.Drawing.Point(19, 440);
            this.lblIsSelectedLabel.Name = "lblIsSelectedLabel";
            this.tpEntries.SetRow(this.lblIsSelectedLabel, 14);
            this.lblIsSelectedLabel.Size = new System.Drawing.Size(77, 18);
            this.lblIsSelectedLabel.TabIndex = 58;
            this.lblIsSelectedLabel.Text = "Is Selected:";
            // 
            // lblIsSelected
            // 
            this.tpEntries.SetColumn(this.lblIsSelected, 2);
            this.lblIsSelected.Location = new System.Drawing.Point(178, 440);
            this.lblIsSelected.Name = "lblIsSelected";
            this.tpEntries.SetRow(this.lblIsSelected, 14);
            this.lblIsSelected.Size = new System.Drawing.Size(10, 18);
            this.lblIsSelected.TabIndex = 57;
            this.lblIsSelected.Text = "..";
            // 
            // lblInterval
            // 
            this.tpEntries.SetColumn(this.lblInterval, 2);
            this.lblInterval.Location = new System.Drawing.Point(178, 140);
            this.lblInterval.Name = "lblInterval";
            this.tpEntries.SetRow(this.lblInterval, 4);
            this.lblInterval.Size = new System.Drawing.Size(10, 18);
            this.lblInterval.TabIndex = 56;
            this.lblInterval.Text = "..";
            // 
            // lblIdNo
            // 
            this.tpEntries.SetColumn(this.lblIdNo, 2);
            this.lblIdNo.Location = new System.Drawing.Point(178, 50);
            this.lblIdNo.Name = "lblIdNo";
            this.tpEntries.SetRow(this.lblIdNo, 1);
            this.lblIdNo.Size = new System.Drawing.Size(10, 18);
            this.lblIdNo.TabIndex = 55;
            this.lblIdNo.Text = "..";
            // 
            // lblSymbolPair
            // 
            this.tpEntries.SetColumn(this.lblSymbolPair, 2);
            this.lblSymbolPair.Location = new System.Drawing.Point(178, 110);
            this.lblSymbolPair.Name = "lblSymbolPair";
            this.tpEntries.SetRow(this.lblSymbolPair, 3);
            this.lblSymbolPair.Size = new System.Drawing.Size(10, 18);
            this.lblSymbolPair.TabIndex = 54;
            this.lblSymbolPair.Text = "..";
            // 
            // lblIndicatorParameter
            // 
            this.tpEntries.SetColumn(this.lblIndicatorParameter, 2);
            this.lblIndicatorParameter.Location = new System.Drawing.Point(178, 170);
            this.lblIndicatorParameter.Name = "lblIndicatorParameter";
            this.tpEntries.SetRow(this.lblIndicatorParameter, 5);
            this.lblIndicatorParameter.Size = new System.Drawing.Size(10, 18);
            this.lblIndicatorParameter.TabIndex = 53;
            this.lblIndicatorParameter.Text = "..";
            // 
            // lblApiToUse
            // 
            this.tpEntries.SetColumn(this.lblApiToUse, 2);
            this.lblApiToUse.Location = new System.Drawing.Point(178, 200);
            this.lblApiToUse.Name = "lblApiToUse";
            this.tpEntries.SetRow(this.lblApiToUse, 6);
            this.lblApiToUse.Size = new System.Drawing.Size(10, 18);
            this.lblApiToUse.TabIndex = 52;
            this.lblApiToUse.Text = "..";
            // 
            // lblAddPnlToMAL
            // 
            this.tpEntries.SetColumn(this.lblAddPnlToMAL, 2);
            this.lblAddPnlToMAL.Location = new System.Drawing.Point(178, 350);
            this.lblAddPnlToMAL.Name = "lblAddPnlToMAL";
            this.tpEntries.SetRow(this.lblAddPnlToMAL, 11);
            this.lblAddPnlToMAL.Size = new System.Drawing.Size(10, 18);
            this.lblAddPnlToMAL.TabIndex = 51;
            this.lblAddPnlToMAL.Text = "..";
            // 
            // lblMaxAmountLimitPercentage
            // 
            this.tpEntries.SetColumn(this.lblMaxAmountLimitPercentage, 2);
            this.lblMaxAmountLimitPercentage.Location = new System.Drawing.Point(178, 320);
            this.lblMaxAmountLimitPercentage.Name = "lblMaxAmountLimitPercentage";
            this.tpEntries.SetRow(this.lblMaxAmountLimitPercentage, 10);
            this.lblMaxAmountLimitPercentage.Size = new System.Drawing.Size(10, 18);
            this.lblMaxAmountLimitPercentage.TabIndex = 50;
            this.lblMaxAmountLimitPercentage.Text = "..";
            // 
            // lblMaxAmountLimit
            // 
            this.tpEntries.SetColumn(this.lblMaxAmountLimit, 2);
            this.lblMaxAmountLimit.Location = new System.Drawing.Point(178, 290);
            this.lblMaxAmountLimit.Name = "lblMaxAmountLimit";
            this.tpEntries.SetRow(this.lblMaxAmountLimit, 9);
            this.lblMaxAmountLimit.Size = new System.Drawing.Size(10, 18);
            this.lblMaxAmountLimit.TabIndex = 49;
            this.lblMaxAmountLimit.Text = "..";
            // 
            // lblLeverage
            // 
            this.tpEntries.SetColumn(this.lblLeverage, 2);
            this.lblLeverage.Location = new System.Drawing.Point(178, 260);
            this.lblLeverage.Name = "lblLeverage";
            this.tpEntries.SetRow(this.lblLeverage, 8);
            this.lblLeverage.Size = new System.Drawing.Size(10, 18);
            this.lblLeverage.TabIndex = 48;
            this.lblLeverage.Text = "..";
            // 
            // lblMarginType
            // 
            this.tpEntries.SetColumn(this.lblMarginType, 2);
            this.lblMarginType.Location = new System.Drawing.Point(178, 230);
            this.lblMarginType.Name = "lblMarginType";
            this.tpEntries.SetRow(this.lblMarginType, 7);
            this.lblMarginType.Size = new System.Drawing.Size(10, 18);
            this.lblMarginType.TabIndex = 47;
            this.lblMarginType.Text = "..";
            // 
            // lblPercentageOfPnl
            // 
            this.tpEntries.SetColumn(this.lblPercentageOfPnl, 2);
            this.lblPercentageOfPnl.Location = new System.Drawing.Point(178, 380);
            this.lblPercentageOfPnl.Name = "lblPercentageOfPnl";
            this.tpEntries.SetRow(this.lblPercentageOfPnl, 12);
            this.lblPercentageOfPnl.Size = new System.Drawing.Size(10, 18);
            this.lblPercentageOfPnl.TabIndex = 46;
            this.lblPercentageOfPnl.Text = "..";
            // 
            // cbxTradeParameterTitle
            // 
            this.tpEntries.SetColumn(this.cbxTradeParameterTitle, 2);
            this.cbxTradeParameterTitle.FormattingEnabled = true;
            this.cbxTradeParameterTitle.Location = new System.Drawing.Point(178, 78);
            this.cbxTradeParameterTitle.Name = "cbxTradeParameterTitle";
            this.tpEntries.SetRow(this.cbxTradeParameterTitle, 2);
            this.cbxTradeParameterTitle.Size = new System.Drawing.Size(209, 26);
            this.cbxTradeParameterTitle.TabIndex = 45;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.tpEntries.SetColumn(this.btnRefresh, 2);
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefresh.Location = new System.Drawing.Point(178, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.tpEntries.SetRow(this.btnRefresh, 0);
            this.btnRefresh.Size = new System.Drawing.Size(209, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTradeParameterTitleLabel
            // 
            this.tpEntries.SetColumn(this.lblTradeParameterTitleLabel, 1);
            this.lblTradeParameterTitleLabel.Location = new System.Drawing.Point(19, 80);
            this.lblTradeParameterTitleLabel.Name = "lblTradeParameterTitleLabel";
            this.tpEntries.SetRow(this.lblTradeParameterTitleLabel, 2);
            this.lblTradeParameterTitleLabel.Size = new System.Drawing.Size(149, 18);
            this.lblTradeParameterTitleLabel.TabIndex = 44;
            this.lblTradeParameterTitleLabel.Text = "Trade Parameter Title:";
            // 
            // lblModifiedDate
            // 
            this.tpEntries.SetColumn(this.lblModifiedDate, 2);
            this.lblModifiedDate.Location = new System.Drawing.Point(178, 500);
            this.lblModifiedDate.Name = "lblModifiedDate";
            this.tpEntries.SetRow(this.lblModifiedDate, 16);
            this.lblModifiedDate.Size = new System.Drawing.Size(10, 18);
            this.lblModifiedDate.TabIndex = 37;
            this.lblModifiedDate.Text = "..";
            // 
            // lblModifiedDateLabel
            // 
            this.tpEntries.SetColumn(this.lblModifiedDateLabel, 1);
            this.lblModifiedDateLabel.Location = new System.Drawing.Point(19, 500);
            this.lblModifiedDateLabel.Name = "lblModifiedDateLabel";
            this.tpEntries.SetRow(this.lblModifiedDateLabel, 16);
            this.lblModifiedDateLabel.Size = new System.Drawing.Size(94, 18);
            this.lblModifiedDateLabel.TabIndex = 36;
            this.lblModifiedDateLabel.Text = "Modified Date:";
            // 
            // lblInUse
            // 
            this.tpEntries.SetColumn(this.lblInUse, 2);
            this.lblInUse.Location = new System.Drawing.Point(178, 410);
            this.lblInUse.Name = "lblInUse";
            this.tpEntries.SetRow(this.lblInUse, 13);
            this.lblInUse.Size = new System.Drawing.Size(10, 18);
            this.lblInUse.TabIndex = 26;
            this.lblInUse.Text = "..";
            // 
            // lblCreationDate
            // 
            this.tpEntries.SetColumn(this.lblCreationDate, 2);
            this.lblCreationDate.Location = new System.Drawing.Point(178, 470);
            this.lblCreationDate.Name = "lblCreationDate";
            this.tpEntries.SetRow(this.lblCreationDate, 15);
            this.lblCreationDate.Size = new System.Drawing.Size(10, 18);
            this.lblCreationDate.TabIndex = 25;
            this.lblCreationDate.Text = "..";
            // 
            // lblCreationDateLabel
            // 
            this.tpEntries.SetColumn(this.lblCreationDateLabel, 1);
            this.lblCreationDateLabel.Location = new System.Drawing.Point(19, 470);
            this.lblCreationDateLabel.Name = "lblCreationDateLabel";
            this.tpEntries.SetRow(this.lblCreationDateLabel, 15);
            this.lblCreationDateLabel.Size = new System.Drawing.Size(94, 18);
            this.lblCreationDateLabel.TabIndex = 24;
            this.lblCreationDateLabel.Text = "Creation Date:";
            // 
            // lblInUseLabel
            // 
            this.tpEntries.SetColumn(this.lblInUseLabel, 1);
            this.lblInUseLabel.Location = new System.Drawing.Point(19, 410);
            this.lblInUseLabel.Name = "lblInUseLabel";
            this.tpEntries.SetRow(this.lblInUseLabel, 13);
            this.lblInUseLabel.Size = new System.Drawing.Size(49, 18);
            this.lblInUseLabel.TabIndex = 23;
            this.lblInUseLabel.Text = "In Use:";
            // 
            // lblPercentageOfPnlToBeAddedLabel
            // 
            this.tpEntries.SetColumn(this.lblPercentageOfPnlToBeAddedLabel, 1);
            this.lblPercentageOfPnlToBeAddedLabel.Location = new System.Drawing.Point(19, 380);
            this.lblPercentageOfPnlToBeAddedLabel.Name = "lblPercentageOfPnlToBeAddedLabel";
            this.tpEntries.SetRow(this.lblPercentageOfPnlToBeAddedLabel, 12);
            this.lblPercentageOfPnlToBeAddedLabel.Size = new System.Drawing.Size(150, 18);
            this.lblPercentageOfPnlToBeAddedLabel.TabIndex = 21;
            this.lblPercentageOfPnlToBeAddedLabel.Text = "% Of Pnl ToBe Added:";
            // 
            // lblAddPnlToMaxAmountLimitLabel
            // 
            this.tpEntries.SetColumn(this.lblAddPnlToMaxAmountLimitLabel, 1);
            this.lblAddPnlToMaxAmountLimitLabel.Location = new System.Drawing.Point(19, 350);
            this.lblAddPnlToMaxAmountLimitLabel.Name = "lblAddPnlToMaxAmountLimitLabel";
            this.tpEntries.SetRow(this.lblAddPnlToMaxAmountLimitLabel, 11);
            this.lblAddPnlToMaxAmountLimitLabel.Size = new System.Drawing.Size(109, 18);
            this.lblAddPnlToMaxAmountLimitLabel.TabIndex = 20;
            this.lblAddPnlToMaxAmountLimitLabel.Text = "Add Pnl To MAL:";
            // 
            // lblMaxAmountPercentageLabel
            // 
            this.tpEntries.SetColumn(this.lblMaxAmountPercentageLabel, 1);
            this.lblMaxAmountPercentageLabel.Location = new System.Drawing.Point(19, 320);
            this.lblMaxAmountPercentageLabel.Name = "lblMaxAmountPercentageLabel";
            this.tpEntries.SetRow(this.lblMaxAmountPercentageLabel, 10);
            this.lblMaxAmountPercentageLabel.Size = new System.Drawing.Size(109, 18);
            this.lblMaxAmountPercentageLabel.TabIndex = 19;
            this.lblMaxAmountPercentageLabel.Text = "Max Amount %:";
            // 
            // lblLeverageLabel
            // 
            this.tpEntries.SetColumn(this.lblLeverageLabel, 1);
            this.lblLeverageLabel.Location = new System.Drawing.Point(19, 260);
            this.lblLeverageLabel.Name = "lblLeverageLabel";
            this.tpEntries.SetRow(this.lblLeverageLabel, 8);
            this.lblLeverageLabel.Size = new System.Drawing.Size(65, 18);
            this.lblLeverageLabel.TabIndex = 18;
            this.lblLeverageLabel.Text = "Leverage:";
            // 
            // lblMarginTypeLabel
            // 
            this.tpEntries.SetColumn(this.lblMarginTypeLabel, 1);
            this.lblMarginTypeLabel.Location = new System.Drawing.Point(19, 230);
            this.lblMarginTypeLabel.Name = "lblMarginTypeLabel";
            this.tpEntries.SetRow(this.lblMarginTypeLabel, 7);
            this.lblMarginTypeLabel.Size = new System.Drawing.Size(87, 18);
            this.lblMarginTypeLabel.TabIndex = 17;
            this.lblMarginTypeLabel.Text = "Margin Type:";
            // 
            // lblSymbolPairLabel
            // 
            this.tpEntries.SetColumn(this.lblSymbolPairLabel, 1);
            this.lblSymbolPairLabel.Location = new System.Drawing.Point(19, 110);
            this.lblSymbolPairLabel.Name = "lblSymbolPairLabel";
            this.tpEntries.SetRow(this.lblSymbolPairLabel, 3);
            this.lblSymbolPairLabel.Size = new System.Drawing.Size(80, 18);
            this.lblSymbolPairLabel.TabIndex = 14;
            this.lblSymbolPairLabel.Text = "Symbol Pair:";
            // 
            // lblMaximumAmountLimitLabel
            // 
            this.tpEntries.SetColumn(this.lblMaximumAmountLimitLabel, 1);
            this.lblMaximumAmountLimitLabel.Location = new System.Drawing.Point(19, 290);
            this.lblMaximumAmountLimitLabel.Name = "lblMaximumAmountLimitLabel";
            this.tpEntries.SetRow(this.lblMaximumAmountLimitLabel, 9);
            this.lblMaximumAmountLimitLabel.Size = new System.Drawing.Size(123, 18);
            this.lblMaximumAmountLimitLabel.TabIndex = 12;
            this.lblMaximumAmountLimitLabel.Text = "Max Amount Limit:";
            // 
            // lblIntervalLabel
            // 
            this.tpEntries.SetColumn(this.lblIntervalLabel, 1);
            this.lblIntervalLabel.Location = new System.Drawing.Point(19, 140);
            this.lblIntervalLabel.Name = "lblIntervalLabel";
            this.tpEntries.SetRow(this.lblIntervalLabel, 4);
            this.lblIntervalLabel.Size = new System.Drawing.Size(55, 18);
            this.lblIntervalLabel.TabIndex = 3;
            this.lblIntervalLabel.Text = "Interval:";
            // 
            // lblApiToUseLabel
            // 
            this.tpEntries.SetColumn(this.lblApiToUseLabel, 1);
            this.lblApiToUseLabel.Location = new System.Drawing.Point(19, 200);
            this.lblApiToUseLabel.Name = "lblApiToUseLabel";
            this.tpEntries.SetRow(this.lblApiToUseLabel, 6);
            this.lblApiToUseLabel.Size = new System.Drawing.Size(77, 18);
            this.lblApiToUseLabel.TabIndex = 2;
            this.lblApiToUseLabel.Text = "Api To Use:";
            // 
            // lblIndicatorParameterLabel
            // 
            this.tpEntries.SetColumn(this.lblIndicatorParameterLabel, 1);
            this.lblIndicatorParameterLabel.Location = new System.Drawing.Point(19, 170);
            this.lblIndicatorParameterLabel.Name = "lblIndicatorParameterLabel";
            this.tpEntries.SetRow(this.lblIndicatorParameterLabel, 5);
            this.lblIndicatorParameterLabel.Size = new System.Drawing.Size(135, 18);
            this.lblIndicatorParameterLabel.TabIndex = 1;
            this.lblIndicatorParameterLabel.Text = "Indicator Parameter:";
            // 
            // lblIdLabel
            // 
            this.tpEntries.SetColumn(this.lblIdLabel, 1);
            this.lblIdLabel.Location = new System.Drawing.Point(19, 50);
            this.lblIdLabel.Name = "lblIdLabel";
            this.tpEntries.SetRow(this.lblIdLabel, 1);
            this.lblIdLabel.Size = new System.Drawing.Size(19, 18);
            this.lblIdLabel.TabIndex = 0;
            this.lblIdLabel.Text = "Id:";
            this.lblIdLabel.UseMnemonic = false;
            // 
            // TradeMonitorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPaneTradeMonitor);
            this.Name = "TradeMonitorUC";
            this.Size = new System.Drawing.Size(1111, 862);
            this.Load += new System.EventHandler(this.TradeMonitorUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTradeFlowPartial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeFlowPartial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneTradeMonitor)).EndInit();
            this.tabPaneTradeMonitor.ResumeLayout(false);
            this.tabNavTradeMonitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTradeMonitorList)).EndInit();
            this.gcTradeMonitorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tpEntries)).EndInit();
            this.tpEntries.ResumeLayout(false);
            this.tpEntries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridTradeFlowPartial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTradeFlowPartial;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneTradeMonitor;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavTradeMonitor;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcTradeMonitorList;
        private DevExpress.Utils.Layout.TablePanel tpEntries;
        private DevExpress.XtraEditors.LabelControl lblIdNo;
        private DevExpress.XtraEditors.LabelControl lblSymbolPair;
        private DevExpress.XtraEditors.LabelControl lblIndicatorParameter;
        private DevExpress.XtraEditors.LabelControl lblApiToUse;
        private DevExpress.XtraEditors.LabelControl lblAddPnlToMAL;
        private DevExpress.XtraEditors.LabelControl lblMaxAmountLimitPercentage;
        private DevExpress.XtraEditors.LabelControl lblMaxAmountLimit;
        private DevExpress.XtraEditors.LabelControl lblLeverage;
        private DevExpress.XtraEditors.LabelControl lblMarginType;
        private DevExpress.XtraEditors.LabelControl lblPercentageOfPnl;
        private System.Windows.Forms.ComboBox cbxTradeParameterTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblTradeParameterTitleLabel;
        private DevExpress.XtraEditors.LabelControl lblModifiedDate;
        private DevExpress.XtraEditors.LabelControl lblModifiedDateLabel;
        private DevExpress.XtraEditors.LabelControl lblInUse;
        private DevExpress.XtraEditors.LabelControl lblCreationDate;
        private DevExpress.XtraEditors.LabelControl lblCreationDateLabel;
        private DevExpress.XtraEditors.LabelControl lblInUseLabel;
        private DevExpress.XtraEditors.LabelControl lblPercentageOfPnlToBeAddedLabel;
        private DevExpress.XtraEditors.LabelControl lblAddPnlToMaxAmountLimitLabel;
        private DevExpress.XtraEditors.LabelControl lblMaxAmountPercentageLabel;
        private DevExpress.XtraEditors.LabelControl lblLeverageLabel;
        private DevExpress.XtraEditors.LabelControl lblMarginTypeLabel;
        private DevExpress.XtraEditors.LabelControl lblSymbolPairLabel;
        private DevExpress.XtraEditors.LabelControl lblMaximumAmountLimitLabel;
        private DevExpress.XtraEditors.LabelControl lblIntervalLabel;
        private DevExpress.XtraEditors.LabelControl lblApiToUseLabel;
        private DevExpress.XtraEditors.LabelControl lblIndicatorParameterLabel;
        private DevExpress.XtraEditors.LabelControl lblIdLabel;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.LabelControl lblIsSelectedLabel;
        private DevExpress.XtraEditors.LabelControl lblIsSelected;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnUnselect;
    }
}
