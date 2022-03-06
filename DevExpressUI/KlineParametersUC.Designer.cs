
namespace DevExpressUI
{
    partial class KlineParametersUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KlineParametersUc));
            this.tabNavDayParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitKlineParameters = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDayParameterList = new DevExpress.XtraEditors.GroupControl();
            this.gridDayParameters = new DevExpress.XtraGrid.GridControl();
            this.gvDayParameters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblKlineCount = new DevExpress.XtraEditors.LabelControl();
            this.tbxDayCount = new DevExpress.XtraEditors.TextEdit();
            this.cbxInterval = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxMarket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIdNo = new DevExpress.XtraEditors.LabelControl();
            this.lblKlineCountLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblDayCountLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblMarket = new DevExpress.XtraEditors.LabelControl();
            this.lblIntervalLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIdLabel = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tabPaneParameters = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavDayParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKlineParameters)).BeginInit();
            this.splitKlineParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).BeginInit();
            this.gcDayParameterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDayParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDayParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDayCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMarket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).BeginInit();
            this.tabPaneParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNavDayParameters
            // 
            this.tabNavDayParameters.Caption = "Day Parameters";
            this.tabNavDayParameters.Controls.Add(this.splitKlineParameters);
            this.tabNavDayParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavDayParameters.ImageOptions.Image")));
            this.tabNavDayParameters.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavDayParameters.Name = "tabNavDayParameters";
            this.tabNavDayParameters.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavDayParameters.Size = new System.Drawing.Size(1011, 735);
            // 
            // splitKlineParameters
            // 
            this.splitKlineParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitKlineParameters.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitKlineParameters.Location = new System.Drawing.Point(0, 0);
            this.splitKlineParameters.Name = "splitKlineParameters";
            this.splitKlineParameters.Panel1.Controls.Add(this.gcDayParameterList);
            this.splitKlineParameters.Panel1.Text = "Panel1";
            this.splitKlineParameters.Panel2.Controls.Add(this.tablePanel1);
            this.splitKlineParameters.Panel2.Controls.Add(this.groupControl1);
            this.splitKlineParameters.Panel2.MinSize = 350;
            this.splitKlineParameters.Panel2.Text = "Panel2";
            this.splitKlineParameters.Size = new System.Drawing.Size(1011, 735);
            this.splitKlineParameters.SplitterPosition = 300;
            this.splitKlineParameters.TabIndex = 0;
            // 
            // gcDayParameterList
            // 
            this.gcDayParameterList.Appearance.Options.UseTextOptions = true;
            this.gcDayParameterList.AppearanceCaption.Options.UseTextOptions = true;
            this.gcDayParameterList.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDayParameterList.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gcDayParameterList.CaptionImageOptions.Image")));
            this.gcDayParameterList.Controls.Add(this.gridDayParameters);
            this.gcDayParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDayParameterList.Location = new System.Drawing.Point(0, 0);
            this.gcDayParameterList.Name = "gcDayParameterList";
            this.gcDayParameterList.Size = new System.Drawing.Size(651, 735);
            this.gcDayParameterList.TabIndex = 0;
            this.gcDayParameterList.Text = "Day Parameter List";
            // 
            // gridDayParameters
            // 
            this.gridDayParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDayParameters.Location = new System.Drawing.Point(2, 21);
            this.gridDayParameters.MainView = this.gvDayParameters;
            this.gridDayParameters.Name = "gridDayParameters";
            this.gridDayParameters.Size = new System.Drawing.Size(647, 712);
            this.gridDayParameters.TabIndex = 0;
            this.gridDayParameters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDayParameters,
            this.gridView1});
            // 
            // gvDayParameters
            // 
            this.gvDayParameters.GridControl = this.gridDayParameters;
            this.gvDayParameters.Name = "gvDayParameters";
            this.gvDayParameters.OptionsView.ShowGroupPanel = false;
            this.gvDayParameters.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDayParameters_FocusedRowChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridDayParameters;
            this.gridView1.Name = "gridView1";
            // 
            // tablePanel1
            // 
            this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 8.86F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 53.85F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 88.26F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 9.03F)});
            this.tablePanel1.Controls.Add(this.lblKlineCount);
            this.tablePanel1.Controls.Add(this.tbxDayCount);
            this.tablePanel1.Controls.Add(this.cbxInterval);
            this.tablePanel1.Controls.Add(this.cbxMarket);
            this.tablePanel1.Controls.Add(this.lblIdNo);
            this.tablePanel1.Controls.Add(this.lblKlineCountLabel);
            this.tablePanel1.Controls.Add(this.lblDayCountLabel);
            this.tablePanel1.Controls.Add(this.lblMarket);
            this.tablePanel1.Controls.Add(this.lblIntervalLabel);
            this.tablePanel1.Controls.Add(this.lblIdLabel);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 44F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(350, 624);
            this.tablePanel1.TabIndex = 2;
            // 
            // lblKlineCount
            // 
            this.tablePanel1.SetColumn(this.lblKlineCount, 2);
            this.lblKlineCount.Location = new System.Drawing.Point(140, 177);
            this.lblKlineCount.Name = "lblKlineCount";
            this.tablePanel1.SetRow(this.lblKlineCount, 5);
            this.lblKlineCount.Size = new System.Drawing.Size(10, 18);
            this.lblKlineCount.TabIndex = 9;
            this.lblKlineCount.Text = "..";
            this.lblKlineCount.UseMnemonic = false;
            // 
            // tbxDayCount
            // 
            this.tablePanel1.SetColumn(this.tbxDayCount, 2);
            this.tbxDayCount.Location = new System.Drawing.Point(140, 141);
            this.tbxDayCount.Name = "tbxDayCount";
            this.tablePanel1.SetRow(this.tbxDayCount, 4);
            this.tbxDayCount.Size = new System.Drawing.Size(187, 24);
            this.tbxDayCount.TabIndex = 8;
            // 
            // cbxInterval
            // 
            this.tablePanel1.SetColumn(this.cbxInterval, 2);
            this.cbxInterval.EditValue = "";
            this.cbxInterval.Location = new System.Drawing.Point(140, 80);
            this.cbxInterval.Name = "cbxInterval";
            this.cbxInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInterval.Properties.Items.AddRange(new object[] {
            "OneMonth",
            "OneWeek",
            "ThreeDay",
            "OneDay",
            "TwelveHour",
            "EightHour",
            "SixHour",
            "FourHour",
            "TwoHour",
            "OneHour",
            "ThirtyMinutes",
            "FifteenMinutes",
            "FiveMinutes",
            "ThreeMinutes",
            "OneMinute"});
            this.tablePanel1.SetRow(this.cbxInterval, 2);
            this.cbxInterval.Size = new System.Drawing.Size(187, 24);
            this.cbxInterval.TabIndex = 7;
            // 
            // cbxMarket
            // 
            this.tablePanel1.SetColumn(this.cbxMarket, 2);
            this.cbxMarket.EditValue = "";
            this.cbxMarket.Location = new System.Drawing.Point(140, 110);
            this.cbxMarket.Name = "cbxMarket";
            this.cbxMarket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxMarket.Properties.Items.AddRange(new object[] {
            "FuturesUsdt",
            "Spot"});
            this.tablePanel1.SetRow(this.cbxMarket, 3);
            this.cbxMarket.Size = new System.Drawing.Size(187, 24);
            this.cbxMarket.TabIndex = 6;
            // 
            // lblIdNo
            // 
            this.tablePanel1.SetColumn(this.lblIdNo, 2);
            this.lblIdNo.Location = new System.Drawing.Point(140, 51);
            this.lblIdNo.Name = "lblIdNo";
            this.tablePanel1.SetRow(this.lblIdNo, 1);
            this.lblIdNo.Size = new System.Drawing.Size(0, 18);
            this.lblIdNo.TabIndex = 5;
            this.lblIdNo.UseMnemonic = false;
            // 
            // lblKlineCountLabel
            // 
            this.tablePanel1.SetColumn(this.lblKlineCountLabel, 1);
            this.lblKlineCountLabel.Location = new System.Drawing.Point(22, 177);
            this.lblKlineCountLabel.Name = "lblKlineCountLabel";
            this.tablePanel1.SetRow(this.lblKlineCountLabel, 5);
            this.lblKlineCountLabel.Size = new System.Drawing.Size(77, 18);
            this.lblKlineCountLabel.TabIndex = 4;
            this.lblKlineCountLabel.Text = "Kline Count:";
            // 
            // lblDayCountLabel
            // 
            this.tablePanel1.SetColumn(this.lblDayCountLabel, 1);
            this.lblDayCountLabel.Location = new System.Drawing.Point(22, 144);
            this.lblDayCountLabel.Name = "lblDayCountLabel";
            this.tablePanel1.SetRow(this.lblDayCountLabel, 4);
            this.lblDayCountLabel.Size = new System.Drawing.Size(74, 18);
            this.lblDayCountLabel.TabIndex = 3;
            this.lblDayCountLabel.Text = "Day Count:";
            // 
            // lblMarket
            // 
            this.tablePanel1.SetColumn(this.lblMarket, 1);
            this.lblMarket.Location = new System.Drawing.Point(22, 113);
            this.lblMarket.Name = "lblMarket";
            this.tablePanel1.SetRow(this.lblMarket, 3);
            this.lblMarket.Size = new System.Drawing.Size(50, 18);
            this.lblMarket.TabIndex = 2;
            this.lblMarket.Text = "Market:";
            // 
            // lblIntervalLabel
            // 
            this.tablePanel1.SetColumn(this.lblIntervalLabel, 1);
            this.lblIntervalLabel.Location = new System.Drawing.Point(22, 83);
            this.lblIntervalLabel.Name = "lblIntervalLabel";
            this.tablePanel1.SetRow(this.lblIntervalLabel, 2);
            this.lblIntervalLabel.Size = new System.Drawing.Size(55, 18);
            this.lblIntervalLabel.TabIndex = 1;
            this.lblIntervalLabel.Text = "Interval:";
            // 
            // lblIdLabel
            // 
            this.tablePanel1.SetColumn(this.lblIdLabel, 1);
            this.lblIdLabel.Location = new System.Drawing.Point(22, 51);
            this.lblIdLabel.Name = "lblIdLabel";
            this.tablePanel1.SetRow(this.lblIdLabel, 1);
            this.lblIdLabel.Size = new System.Drawing.Size(19, 18);
            this.lblIdLabel.TabIndex = 0;
            this.lblIdLabel.Text = "Id:";
            this.lblIdLabel.UseMnemonic = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblResult);
            this.groupControl1.Controls.Add(this.btnNew);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 624);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(350, 111);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(38, 72);
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
            this.btnNew.Location = new System.Drawing.Point(43, 20);
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
            this.btnDelete.Location = new System.Drawing.Point(133, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(223, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Save";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabPaneParameters
            // 
            this.tabPaneParameters.Controls.Add(this.tabNavDayParameters);
            this.tabPaneParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneParameters.Location = new System.Drawing.Point(0, 0);
            this.tabPaneParameters.Name = "tabPaneParameters";
            this.tabPaneParameters.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneParameters.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavDayParameters});
            this.tabPaneParameters.RegularSize = new System.Drawing.Size(1011, 761);
            this.tabPaneParameters.SelectedPage = this.tabNavDayParameters;
            this.tabPaneParameters.Size = new System.Drawing.Size(1011, 761);
            this.tabPaneParameters.TabIndex = 0;
            this.tabPaneParameters.Text = "tabPane1";
            // 
            // KlineParametersUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPaneParameters);
            this.Name = "KlineParametersUc";
            this.Size = new System.Drawing.Size(1011, 761);
            this.Load += new System.EventHandler(this.ParametersUC_Load);
            this.tabNavDayParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKlineParameters)).EndInit();
            this.splitKlineParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).EndInit();
            this.gcDayParameterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDayParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDayParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDayCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMarket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).EndInit();
            this.tabPaneParameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavDayParameters;
        private DevExpress.XtraEditors.SplitContainerControl splitKlineParameters;
        private DevExpress.XtraEditors.GroupControl gcDayParameterList;
        private DevExpress.XtraGrid.GridControl gridDayParameters;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDayParameters;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblKlineCount;
        private DevExpress.XtraEditors.TextEdit tbxDayCount;
        private DevExpress.XtraEditors.ComboBoxEdit cbxInterval;
        private DevExpress.XtraEditors.ComboBoxEdit cbxMarket;
        private DevExpress.XtraEditors.LabelControl lblIdNo;
        private DevExpress.XtraEditors.LabelControl lblKlineCountLabel;
        private DevExpress.XtraEditors.LabelControl lblDayCountLabel;
        private DevExpress.XtraEditors.LabelControl lblMarket;
        private DevExpress.XtraEditors.LabelControl lblIntervalLabel;
        private DevExpress.XtraEditors.LabelControl lblIdLabel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneParameters;
    }
}
