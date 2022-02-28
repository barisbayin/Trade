
namespace DevExpressUI
{
    partial class IndicatorParametersUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicatorParametersUC));
            this.tabPaneIndicatorParameters = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavInicatorParameters = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcIndicatorParamaters = new DevExpress.XtraEditors.GroupControl();
            this.gridIndicatorParameters = new DevExpress.XtraGrid.GridControl();
            this.gvIndicatorParameters = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneIndicatorParameters)).BeginInit();
            this.tabPaneIndicatorParameters.SuspendLayout();
            this.tabNavInicatorParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIndicatorParamaters)).BeginInit();
            this.gcIndicatorParamaters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndicatorParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIndicatorParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpEntries)).BeginInit();
            this.tpEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chckShowDeleted.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSecretKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxApiKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxExchange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPaneIndicatorParameters
            // 
            this.tabPaneIndicatorParameters.Controls.Add(this.tabNavInicatorParameters);
            this.tabPaneIndicatorParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneIndicatorParameters.Location = new System.Drawing.Point(0, 0);
            this.tabPaneIndicatorParameters.Name = "tabPaneIndicatorParameters";
            this.tabPaneIndicatorParameters.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabPaneIndicatorParameters.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavInicatorParameters});
            this.tabPaneIndicatorParameters.RegularSize = new System.Drawing.Size(1011, 761);
            this.tabPaneIndicatorParameters.SelectedPage = this.tabNavInicatorParameters;
            this.tabPaneIndicatorParameters.Size = new System.Drawing.Size(1011, 761);
            this.tabPaneIndicatorParameters.TabIndex = 2;
            this.tabPaneIndicatorParameters.Text = "tpaneApiManagement";
            // 
            // tabNavInicatorParameters
            // 
            this.tabNavInicatorParameters.Caption = "Indicator Parameters";
            this.tabNavInicatorParameters.Controls.Add(this.splitContainerControl1);
            this.tabNavInicatorParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabNavInicatorParameters.ImageOptions.Image")));
            this.tabNavInicatorParameters.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavInicatorParameters.Name = "tabNavInicatorParameters";
            this.tabNavInicatorParameters.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavInicatorParameters.Size = new System.Drawing.Size(1011, 735);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcIndicatorParamaters);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tpEntries);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.MinSize = 300;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1011, 735);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcIndicatorParamaters
            // 
            this.gcIndicatorParamaters.Appearance.Options.UseTextOptions = true;
            this.gcIndicatorParamaters.AppearanceCaption.Options.UseTextOptions = true;
            this.gcIndicatorParamaters.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIndicatorParamaters.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gcIndicatorParamaters.CaptionImageOptions.Image")));
            this.gcIndicatorParamaters.Controls.Add(this.gridIndicatorParameters);
            this.gcIndicatorParamaters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIndicatorParamaters.Location = new System.Drawing.Point(0, 0);
            this.gcIndicatorParamaters.Name = "gcIndicatorParamaters";
            this.gcIndicatorParamaters.Size = new System.Drawing.Size(701, 735);
            this.gcIndicatorParamaters.TabIndex = 0;
            this.gcIndicatorParamaters.Text = "Indicator Parameter List";
            // 
            // gridIndicatorParameters
            // 
            this.gridIndicatorParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIndicatorParameters.Location = new System.Drawing.Point(2, 21);
            this.gridIndicatorParameters.MainView = this.gvIndicatorParameters;
            this.gridIndicatorParameters.Name = "gridIndicatorParameters";
            this.gridIndicatorParameters.Size = new System.Drawing.Size(697, 712);
            this.gridIndicatorParameters.TabIndex = 0;
            this.gridIndicatorParameters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIndicatorParameters});
            // 
            // gvIndicatorParameters
            // 
            this.gvIndicatorParameters.GridControl = this.gridIndicatorParameters;
            this.gvIndicatorParameters.Name = "gvIndicatorParameters";
            this.gvIndicatorParameters.OptionsView.ShowGroupPanel = false;
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
            this.tpEntries.Size = new System.Drawing.Size(300, 624);
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
            this.chckShowDeleted.Size = new System.Drawing.Size(258, 20);
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
            this.groupControl1.Location = new System.Drawing.Point(0, 624);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(300, 111);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
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
            // 
            // IndicatorParametersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPaneIndicatorParameters);
            this.Name = "IndicatorParametersUC";
            this.Size = new System.Drawing.Size(1011, 761);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneIndicatorParameters)).EndInit();
            this.tabPaneIndicatorParameters.ResumeLayout(false);
            this.tabNavInicatorParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIndicatorParamaters)).EndInit();
            this.gcIndicatorParamaters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIndicatorParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIndicatorParameters)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneIndicatorParameters;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavInicatorParameters;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcIndicatorParamaters;
        private DevExpress.XtraGrid.GridControl gridIndicatorParameters;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIndicatorParameters;
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}
