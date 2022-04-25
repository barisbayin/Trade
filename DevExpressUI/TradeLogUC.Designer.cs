
namespace DevExpressUI
{
    partial class TradeLogUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeLogUC));
            this.grcTradeLogsFilter = new DevExpress.XtraEditors.GroupControl();
            this.cbxTradeFlows = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grcTradeLogs = new DevExpress.XtraEditors.GroupControl();
            this.tabPaneTradeLogs = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavTradeLogs = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridTradeLogs = new DevExpress.XtraGrid.GridControl();
            this.gvTradeLogs2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvTradeLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcTradeLogsFilter)).BeginInit();
            this.grcTradeLogsFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTradeLogs)).BeginInit();
            this.grcTradeLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneTradeLogs)).BeginInit();
            this.tabPaneTradeLogs.SuspendLayout();
            this.tabNavTradeLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTradeLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeLogs2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // grcTradeLogsFilter
            // 
            this.grcTradeLogsFilter.Controls.Add(this.cbxTradeFlows);
            this.grcTradeLogsFilter.Controls.Add(this.btnRefresh);
            this.grcTradeLogsFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcTradeLogsFilter.Location = new System.Drawing.Point(0, 0);
            this.grcTradeLogsFilter.Name = "grcTradeLogsFilter";
            this.grcTradeLogsFilter.ShowCaption = false;
            this.grcTradeLogsFilter.Size = new System.Drawing.Size(1179, 52);
            this.grcTradeLogsFilter.TabIndex = 12;
            this.grcTradeLogsFilter.Text = "groupControl2";
            // 
            // cbxTradeFlows
            // 
            this.cbxTradeFlows.FormattingEnabled = true;
            this.cbxTradeFlows.Location = new System.Drawing.Point(15, 13);
            this.cbxTradeFlows.Name = "cbxTradeFlows";
            this.cbxTradeFlows.Size = new System.Drawing.Size(231, 26);
            this.cbxTradeFlows.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefresh.Location = new System.Drawing.Point(1058, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grcTradeLogs
            // 
            this.grcTradeLogs.Controls.Add(this.tabPaneTradeLogs);
            this.grcTradeLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTradeLogs.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.grcTradeLogs.Location = new System.Drawing.Point(0, 52);
            this.grcTradeLogs.Name = "grcTradeLogs";
            this.grcTradeLogs.ShowCaption = false;
            this.grcTradeLogs.Size = new System.Drawing.Size(1179, 888);
            this.grcTradeLogs.TabIndex = 11;
            this.grcTradeLogs.Text = "groupControl1";
            // 
            // tabPaneTradeLogs
            // 
            this.tabPaneTradeLogs.Controls.Add(this.tabNavTradeLogs);
            this.tabPaneTradeLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneTradeLogs.Location = new System.Drawing.Point(2, 2);
            this.tabPaneTradeLogs.Name = "tabPaneTradeLogs";
            this.tabPaneTradeLogs.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneTradeLogs.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavTradeLogs});
            this.tabPaneTradeLogs.RegularSize = new System.Drawing.Size(1175, 884);
            this.tabPaneTradeLogs.SelectedPage = this.tabNavTradeLogs;
            this.tabPaneTradeLogs.Size = new System.Drawing.Size(1175, 884);
            this.tabPaneTradeLogs.TabIndex = 5;
            this.tabPaneTradeLogs.Text = "tpaneTradeMonitor";
            // 
            // tabNavTradeLogs
            // 
            this.tabNavTradeLogs.Caption = "TradeLogs";
            this.tabNavTradeLogs.Controls.Add(this.gridTradeLogs);
            this.tabNavTradeLogs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavTradeLogs.ImageOptions.Image")));
            this.tabNavTradeLogs.Name = "tabNavTradeLogs";
            this.tabNavTradeLogs.Size = new System.Drawing.Size(1175, 858);
            // 
            // gridTradeLogs
            // 
            this.gridTradeLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTradeLogs.Location = new System.Drawing.Point(0, 0);
            this.gridTradeLogs.MainView = this.gvTradeLogs2;
            this.gridTradeLogs.Name = "gridTradeLogs";
            this.gridTradeLogs.Size = new System.Drawing.Size(1175, 858);
            this.gridTradeLogs.TabIndex = 0;
            this.gridTradeLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTradeLogs2});
            // 
            // gvTradeLogs2
            // 
            this.gvTradeLogs2.GridControl = this.gridTradeLogs;
            this.gvTradeLogs2.Name = "gvTradeLogs2";
            this.gvTradeLogs2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvTradeLogs2_CustomColumnDisplayText);
            // 
            // gvTradeLogs
            // 
            this.gvTradeLogs.Name = "gvTradeLogs";
            // 
            // TradeLogUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcTradeLogs);
            this.Controls.Add(this.grcTradeLogsFilter);
            this.Name = "TradeLogUC";
            this.Size = new System.Drawing.Size(1179, 940);
            this.Load += new System.EventHandler(this.TradeLogUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcTradeLogsFilter)).EndInit();
            this.grcTradeLogsFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTradeLogs)).EndInit();
            this.grcTradeLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneTradeLogs)).EndInit();
            this.tabPaneTradeLogs.ResumeLayout(false);
            this.tabNavTradeLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTradeLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeLogs2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTradeLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl grcTradeLogs;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneTradeLogs;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavTradeLogs;
        private DevExpress.XtraEditors.GroupControl grcTradeLogsFilter;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTradeLogs;
        private DevExpress.XtraGrid.GridControl gridTradeLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTradeLogs2;
        private System.Windows.Forms.ComboBox cbxTradeFlows;
    }
}
