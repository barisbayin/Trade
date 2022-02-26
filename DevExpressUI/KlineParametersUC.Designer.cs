
namespace DevExpressUI
{
    partial class KlineParametersUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KlineParametersUC));
            this.tabPaneParameters = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavDayParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDayParameterList = new DevExpress.XtraEditors.GroupControl();
            this.gridDayParameters = new DevExpress.XtraGrid.GridControl();
            this.gvDayParameters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabNavSymbolParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).BeginInit();
            this.tabPaneParameters.SuspendLayout();
            this.tabNavDayParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).BeginInit();
            this.gcDayParameterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDayParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDayParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneParameters
            // 
            this.tabPaneParameters.Controls.Add(this.tabNavDayParameters);
            this.tabPaneParameters.Controls.Add(this.tabNavSymbolParameters);
            this.tabPaneParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneParameters.Location = new System.Drawing.Point(0, 0);
            this.tabPaneParameters.Name = "tabPaneParameters";
            this.tabPaneParameters.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneParameters.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavDayParameters,
            this.tabNavSymbolParameters});
            this.tabPaneParameters.RegularSize = new System.Drawing.Size(797, 665);
            this.tabPaneParameters.SelectedPage = this.tabNavDayParameters;
            this.tabPaneParameters.Size = new System.Drawing.Size(797, 665);
            this.tabPaneParameters.TabIndex = 0;
            this.tabPaneParameters.Text = "tabPane1";
            // 
            // tabNavDayParameters
            // 
            this.tabNavDayParameters.Caption = "Day Parameters";
            this.tabNavDayParameters.Controls.Add(this.splitContainerControl1);
            this.tabNavDayParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavDayParameters.ImageOptions.Image")));
            this.tabNavDayParameters.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavDayParameters.Name = "tabNavDayParameters";
            this.tabNavDayParameters.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavDayParameters.Size = new System.Drawing.Size(797, 639);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcDayParameterList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(797, 639);
            this.splitContainerControl1.SplitterPosition = 400;
            this.splitContainerControl1.TabIndex = 0;
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
            this.gcDayParameterList.Size = new System.Drawing.Size(400, 639);
            this.gcDayParameterList.TabIndex = 0;
            this.gcDayParameterList.Text = "Day Parameter List";
            // 
            // gridDayParameters
            // 
            this.gridDayParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDayParameters.Location = new System.Drawing.Point(2, 21);
            this.gridDayParameters.MainView = this.gvDayParameters;
            this.gridDayParameters.Name = "gridDayParameters";
            this.gridDayParameters.Size = new System.Drawing.Size(396, 616);
            this.gridDayParameters.TabIndex = 0;
            this.gridDayParameters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDayParameters});
            // 
            // gvDayParameters
            // 
            this.gvDayParameters.GridControl = this.gridDayParameters;
            this.gvDayParameters.Name = "gvDayParameters";
            this.gvDayParameters.OptionsView.ShowGroupPanel = false;
            // 
            // tabNavSymbolParameters
            // 
            this.tabNavSymbolParameters.Caption = "Symbol Parameters";
            this.tabNavSymbolParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavSymbolParameters.ImageOptions.Image")));
            this.tabNavSymbolParameters.Name = "tabNavSymbolParameters";
            this.tabNavSymbolParameters.Size = new System.Drawing.Size(797, 546);
            // 
            // ParametersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPaneParameters);
            this.Name = "ParametersUC";
            this.Size = new System.Drawing.Size(797, 665);
            this.Load += new System.EventHandler(this.ParametersUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).EndInit();
            this.tabPaneParameters.ResumeLayout(false);
            this.tabNavDayParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).EndInit();
            this.gcDayParameterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDayParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDayParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneParameters;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavDayParameters;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavSymbolParameters;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcDayParameterList;
        private DevExpress.XtraGrid.GridControl gridDayParameters;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDayParameters;
    }
}
