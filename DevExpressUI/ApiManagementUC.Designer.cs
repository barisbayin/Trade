
namespace DevExpressUI
{
    partial class ApiManagementUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApiManagementUC));
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gvApiList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridApiList = new DevExpress.XtraGrid.GridControl();
            this.gcApiManagment = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tpEntries = new DevExpress.Utils.Layout.TablePanel();
            this.chckShowDeleted = new DevExpress.XtraEditors.CheckEdit();
            this.lblCreationDate = new DevExpress.XtraEditors.LabelControl();
            this.tbxSecretKey = new DevExpress.XtraEditors.TextEdit();
            this.lblSecretKey = new DevExpress.XtraEditors.LabelControl();
            this.lblCreationDateLabel = new DevExpress.XtraEditors.LabelControl();
            this.tbxApiTitle = new DevExpress.XtraEditors.TextEdit();
            this.tbxApiKey = new DevExpress.XtraEditors.TextEdit();
            this.cbxExchange = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblIdNo = new DevExpress.XtraEditors.LabelControl();
            this.lblApiKeyLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblApiTitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblExchangeLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblIdLabel = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tabNavApiManagement = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabPaneParameters = new DevExpress.XtraBars.Navigation.TabPane();
            ((System.ComponentModel.ISupportInitialize)(this.gvApiList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridApiList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcApiManagment)).BeginInit();
            this.gcApiManagment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpEntries)).BeginInit();
            this.tpEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chckShowDeleted.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSecretKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxExchange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tabNavApiManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).BeginInit();
            this.tabPaneParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(18, 72);
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
            this.btnNew.Location = new System.Drawing.Point(18, 20);
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
            this.btnDelete.Location = new System.Drawing.Point(108, 20);
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
            this.btnAdd.Location = new System.Drawing.Point(198, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Save";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvApiList
            // 
            this.gvApiList.GridControl = this.gridApiList;
            this.gvApiList.Name = "gvApiList";
            this.gvApiList.OptionsView.ShowGroupPanel = false;
            this.gvApiList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvApiList_RowStyle);
            this.gvApiList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvApiList_FocusedRowChanged);
            // 
            // gridApiList
            // 
            this.gridApiList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridApiList.Location = new System.Drawing.Point(2, 21);
            this.gridApiList.MainView = this.gvApiList;
            this.gridApiList.Name = "gridApiList";
            this.gridApiList.Size = new System.Drawing.Size(513, 695);
            this.gridApiList.TabIndex = 0;
            this.gridApiList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvApiList});
            // 
            // gcApiManagment
            // 
            this.gcApiManagment.Appearance.Options.UseTextOptions = true;
            this.gcApiManagment.AppearanceCaption.Options.UseTextOptions = true;
            this.gcApiManagment.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcApiManagment.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gcApiManagment.CaptionImageOptions.Image")));
            this.gcApiManagment.Controls.Add(this.gridApiList);
            this.gcApiManagment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcApiManagment.Location = new System.Drawing.Point(0, 0);
            this.gcApiManagment.Name = "gcApiManagment";
            this.gcApiManagment.Size = new System.Drawing.Size(517, 718);
            this.gcApiManagment.TabIndex = 0;
            this.gcApiManagment.Text = "Api List";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcApiManagment);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tpEntries);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.MinSize = 300;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(827, 718);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // tpEntries
            // 
            this.tpEntries.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tpEntries.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 9.39F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 53.32F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 87.34F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 9.95F)});
            this.tpEntries.Controls.Add(this.chckShowDeleted);
            this.tpEntries.Controls.Add(this.lblCreationDate);
            this.tpEntries.Controls.Add(this.tbxSecretKey);
            this.tpEntries.Controls.Add(this.lblSecretKey);
            this.tpEntries.Controls.Add(this.lblCreationDateLabel);
            this.tpEntries.Controls.Add(this.tbxApiTitle);
            this.tpEntries.Controls.Add(this.tbxApiKey);
            this.tpEntries.Controls.Add(this.cbxExchange);
            this.tpEntries.Controls.Add(this.lblIdNo);
            this.tpEntries.Controls.Add(this.lblApiKeyLabel);
            this.tpEntries.Controls.Add(this.lblApiTitleLabel);
            this.tpEntries.Controls.Add(this.lblExchangeLabel);
            this.tpEntries.Controls.Add(this.lblIdLabel);
            this.tpEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpEntries.Location = new System.Drawing.Point(0, 0);
            this.tpEntries.Name = "tpEntries";
            this.tpEntries.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 44F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tpEntries.Size = new System.Drawing.Size(300, 607);
            this.tpEntries.TabIndex = 2;
            // 
            // chckShowDeleted
            // 
            this.tpEntries.SetColumn(this.chckShowDeleted, 1);
            this.tpEntries.SetColumnSpan(this.chckShowDeleted, 2);
            this.chckShowDeleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckShowDeleted.Location = new System.Drawing.Point(21, 233);
            this.chckShowDeleted.Name = "chckShowDeleted";
            this.chckShowDeleted.Properties.Caption = "Show Deleted Api\'s";
            this.chckShowDeleted.Properties.CheckStateChanged += new System.EventHandler(this.chckShowDeleted_Properties_CheckStateChanged);
            this.tpEntries.SetRow(this.chckShowDeleted, 7);
            this.chckShowDeleted.Size = new System.Drawing.Size(206, 16);
            this.chckShowDeleted.TabIndex = 17;
            // 
            // lblCreationDate
            // 
            this.tpEntries.SetColumn(this.lblCreationDate, 2);
            this.lblCreationDate.Location = new System.Drawing.Point(121, 206);
            this.lblCreationDate.Name = "lblCreationDate";
            this.tpEntries.SetRow(this.lblCreationDate, 6);
            this.lblCreationDate.Size = new System.Drawing.Size(0, 18);
            this.lblCreationDate.TabIndex = 16;
            // 
            // tbxSecretKey
            // 
            this.tpEntries.SetColumn(this.tbxSecretKey, 2);
            this.tbxSecretKey.Location = new System.Drawing.Point(121, 173);
            this.tbxSecretKey.Name = "tbxSecretKey";
            this.tpEntries.SetRow(this.tbxSecretKey, 5);
            this.tbxSecretKey.Size = new System.Drawing.Size(158, 24);
            this.tbxSecretKey.TabIndex = 15;
            // 
            // lblSecretKey
            // 
            this.tpEntries.SetColumn(this.lblSecretKey, 1);
            this.lblSecretKey.Location = new System.Drawing.Point(21, 176);
            this.lblSecretKey.Name = "lblSecretKey";
            this.tpEntries.SetRow(this.lblSecretKey, 5);
            this.lblSecretKey.Size = new System.Drawing.Size(76, 18);
            this.lblSecretKey.TabIndex = 14;
            this.lblSecretKey.Text = "Secret Key:";
            // 
            // lblCreationDateLabel
            // 
            this.tpEntries.SetColumn(this.lblCreationDateLabel, 1);
            this.lblCreationDateLabel.Location = new System.Drawing.Point(21, 206);
            this.lblCreationDateLabel.Name = "lblCreationDateLabel";
            this.tpEntries.SetRow(this.lblCreationDateLabel, 6);
            this.lblCreationDateLabel.Size = new System.Drawing.Size(94, 18);
            this.lblCreationDateLabel.TabIndex = 12;
            this.lblCreationDateLabel.Text = "Creation Date:";
            // 
            // tbxApiTitle
            // 
            this.tpEntries.SetColumn(this.tbxApiTitle, 2);
            this.tbxApiTitle.Location = new System.Drawing.Point(121, 110);
            this.tbxApiTitle.Name = "tbxApiTitle";
            this.tpEntries.SetRow(this.tbxApiTitle, 3);
            this.tbxApiTitle.Size = new System.Drawing.Size(158, 24);
            this.tbxApiTitle.TabIndex = 10;
            // 
            // tbxApiKey
            // 
            this.tpEntries.SetColumn(this.tbxApiKey, 2);
            this.tbxApiKey.Location = new System.Drawing.Point(121, 141);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tpEntries.SetRow(this.tbxApiKey, 4);
            this.tbxApiKey.Size = new System.Drawing.Size(158, 24);
            this.tbxApiKey.TabIndex = 8;
            // 
            // cbxExchange
            // 
            this.tpEntries.SetColumn(this.cbxExchange, 2);
            this.cbxExchange.EditValue = "";
            this.cbxExchange.Location = new System.Drawing.Point(121, 80);
            this.cbxExchange.Name = "cbxExchange";
            this.cbxExchange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxExchange.Properties.Items.AddRange(new object[] {
            "Binance",
            "FTX",
            "Okex",
            "Bittrex"});
            this.tpEntries.SetRow(this.cbxExchange, 2);
            this.cbxExchange.Size = new System.Drawing.Size(158, 24);
            this.cbxExchange.TabIndex = 7;
            // 
            // lblIdNo
            // 
            this.tpEntries.SetColumn(this.lblIdNo, 2);
            this.lblIdNo.Location = new System.Drawing.Point(121, 51);
            this.lblIdNo.Name = "lblIdNo";
            this.tpEntries.SetRow(this.lblIdNo, 1);
            this.lblIdNo.Size = new System.Drawing.Size(0, 18);
            this.lblIdNo.TabIndex = 5;
            this.lblIdNo.UseMnemonic = false;
            // 
            // lblApiKeyLabel
            // 
            this.tpEntries.SetColumn(this.lblApiKeyLabel, 1);
            this.lblApiKeyLabel.Location = new System.Drawing.Point(21, 144);
            this.lblApiKeyLabel.Name = "lblApiKeyLabel";
            this.tpEntries.SetRow(this.lblApiKeyLabel, 4);
            this.lblApiKeyLabel.Size = new System.Drawing.Size(54, 18);
            this.lblApiKeyLabel.TabIndex = 3;
            this.lblApiKeyLabel.Text = "Api Key:";
            // 
            // lblApiTitleLabel
            // 
            this.tpEntries.SetColumn(this.lblApiTitleLabel, 1);
            this.lblApiTitleLabel.Location = new System.Drawing.Point(21, 113);
            this.lblApiTitleLabel.Name = "lblApiTitleLabel";
            this.tpEntries.SetRow(this.lblApiTitleLabel, 3);
            this.lblApiTitleLabel.Size = new System.Drawing.Size(56, 18);
            this.lblApiTitleLabel.TabIndex = 2;
            this.lblApiTitleLabel.Text = "Api Title:";
            // 
            // lblExchangeLabel
            // 
            this.tpEntries.SetColumn(this.lblExchangeLabel, 1);
            this.lblExchangeLabel.Location = new System.Drawing.Point(21, 83);
            this.lblExchangeLabel.Name = "lblExchangeLabel";
            this.tpEntries.SetRow(this.lblExchangeLabel, 2);
            this.lblExchangeLabel.Size = new System.Drawing.Size(68, 18);
            this.lblExchangeLabel.TabIndex = 1;
            this.lblExchangeLabel.Text = "Exchange:";
            // 
            // lblIdLabel
            // 
            this.tpEntries.SetColumn(this.lblIdLabel, 1);
            this.lblIdLabel.Location = new System.Drawing.Point(21, 51);
            this.lblIdLabel.Name = "lblIdLabel";
            this.tpEntries.SetRow(this.lblIdLabel, 1);
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
            this.groupControl1.Location = new System.Drawing.Point(0, 607);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(300, 111);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // tabNavApiManagement
            // 
            this.tabNavApiManagement.Caption = "Api Management";
            this.tabNavApiManagement.Controls.Add(this.splitContainerControl1);
            this.tabNavApiManagement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavApiManagement.ImageOptions.Image")));
            this.tabNavApiManagement.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavApiManagement.Name = "tabNavApiManagement";
            this.tabNavApiManagement.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavApiManagement.Size = new System.Drawing.Size(827, 718);
            // 
            // tabPaneParameters
            // 
            this.tabPaneParameters.Controls.Add(this.tabNavApiManagement);
            this.tabPaneParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneParameters.Location = new System.Drawing.Point(0, 0);
            this.tabPaneParameters.Name = "tabPaneParameters";
            this.tabPaneParameters.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneParameters.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavApiManagement});
            this.tabPaneParameters.RegularSize = new System.Drawing.Size(827, 744);
            this.tabPaneParameters.SelectedPage = this.tabNavApiManagement;
            this.tabPaneParameters.Size = new System.Drawing.Size(827, 744);
            this.tabPaneParameters.TabIndex = 1;
            this.tabPaneParameters.Text = "tpaneApiManagement";
            // 
            // ApiManagementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPaneParameters);
            this.Name = "ApiManagementUC";
            this.Size = new System.Drawing.Size(827, 744);
            this.Load += new System.EventHandler(this.ApiManagementUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvApiList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridApiList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcApiManagment)).EndInit();
            this.gcApiManagment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tpEntries)).EndInit();
            this.tpEntries.ResumeLayout(false);
            this.tpEntries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chckShowDeleted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSecretKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxExchange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.tabNavApiManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneParameters)).EndInit();
            this.tabPaneParameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gvApiList;
        private DevExpress.XtraGrid.GridControl gridApiList;
        private DevExpress.XtraEditors.GroupControl gcApiManagment;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavApiManagement;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneParameters;
        private DevExpress.Utils.Layout.TablePanel tpEntries;
        private DevExpress.XtraEditors.CheckEdit chckShowDeleted;
        private DevExpress.XtraEditors.LabelControl lblCreationDate;
        private DevExpress.XtraEditors.TextEdit tbxSecretKey;
        private DevExpress.XtraEditors.LabelControl lblSecretKey;
        private DevExpress.XtraEditors.LabelControl lblCreationDateLabel;
        private DevExpress.XtraEditors.TextEdit tbxApiTitle;
        private DevExpress.XtraEditors.TextEdit tbxApiKey;
        private DevExpress.XtraEditors.ComboBoxEdit cbxExchange;
        private DevExpress.XtraEditors.LabelControl lblIdNo;
        private DevExpress.XtraEditors.LabelControl lblApiKeyLabel;
        private DevExpress.XtraEditors.LabelControl lblApiTitleLabel;
        private DevExpress.XtraEditors.LabelControl lblExchangeLabel;
        private DevExpress.XtraEditors.LabelControl lblIdLabel;
    }
}
