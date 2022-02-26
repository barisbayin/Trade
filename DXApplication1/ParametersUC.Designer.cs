
namespace DevExpressUI
{
    partial class ParametersUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersUC));
            this.tabPanelParameters = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavDayParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavSymbolParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDayParameterList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabPanelParameters)).BeginInit();
            this.tabPanelParameters.SuspendLayout();
            this.tabNavDayParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).BeginInit();
            this.gcDayParameterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPanelParameters
            // 
            this.tabPanelParameters.Controls.Add(this.tabNavDayParameters);
            this.tabPanelParameters.Controls.Add(this.tabNavSymbolParameters);
            this.tabPanelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanelParameters.Location = new System.Drawing.Point(0, 0);
            this.tabPanelParameters.Name = "tabPanelParameters";
            this.tabPanelParameters.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPanelParameters.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavDayParameters,
            this.tabNavSymbolParameters});
            this.tabPanelParameters.RegularSize = new System.Drawing.Size(839, 636);
            this.tabPanelParameters.SelectedPage = this.tabNavDayParameters;
            this.tabPanelParameters.Size = new System.Drawing.Size(839, 636);
            this.tabPanelParameters.TabIndex = 0;
            this.tabPanelParameters.Text = "Parameters";
            // 
            // tabNavDayParameters
            // 
            this.tabNavDayParameters.Caption = "Day Parameters";
            this.tabNavDayParameters.Controls.Add(this.splitContainerControl1);
            this.tabNavDayParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage1.ImageOptions.Image")));
            this.tabNavDayParameters.Name = "tabNavDayParameters";
            this.tabNavDayParameters.Size = new System.Drawing.Size(839, 610);
            // 
            // tabNavSymbolParameters
            // 
            this.tabNavSymbolParameters.Caption = "Symbol Parameters";
            this.tabNavSymbolParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavSymbolParameters.ImageOptions.Image")));
            this.tabNavSymbolParameters.Name = "tabNavSymbolParameters";
            this.tabNavSymbolParameters.Size = new System.Drawing.Size(839, 610);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcDayParameterList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(839, 610);
            this.splitContainerControl1.SplitterPosition = 405;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcDayParameterList
            // 
            this.gcDayParameterList.Appearance.Options.UseTextOptions = true;
            this.gcDayParameterList.AppearanceCaption.Options.UseTextOptions = true;
            this.gcDayParameterList.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDayParameterList.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.gcDayParameterList.Controls.Add(this.gridControl1);
            this.gcDayParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDayParameterList.Location = new System.Drawing.Point(0, 0);
            this.gcDayParameterList.Name = "gcDayParameterList";
            this.gcDayParameterList.Size = new System.Drawing.Size(405, 610);
            this.gcDayParameterList.TabIndex = 0;
            this.gcDayParameterList.Text = "Day Parameter List";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(401, 587);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ParametersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanelParameters);
            this.Name = "ParametersUC";
            this.Size = new System.Drawing.Size(839, 636);
            ((System.ComponentModel.ISupportInitialize)(this.tabPanelParameters)).EndInit();
            this.tabPanelParameters.ResumeLayout(false);
            this.tabNavDayParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDayParameterList)).EndInit();
            this.gcDayParameterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPanelParameters;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavDayParameters;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavSymbolParameters;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcDayParameterList;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
