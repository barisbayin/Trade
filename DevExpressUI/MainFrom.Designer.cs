
namespace DevExpressUI
{
    partial class MainFrom
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.mainFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceTradeMonitor = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTradeParameters = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceKlineParameters = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceApiManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceIndicatorParameters = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accLogs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFormContainer
            // 
            this.mainFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormContainer.Location = new System.Drawing.Point(231, 20);
            this.mainFormContainer.Name = "mainFormContainer";
            this.mainFormContainer.Size = new System.Drawing.Size(861, 748);
            this.mainFormContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceTradeMonitor,
            this.aceTradeParameters,
            this.aceKlineParameters,
            this.aceApiManagement,
            this.aceIndicatorParameters,
            this.accLogs});
            this.accordionControl1.Location = new System.Drawing.Point(0, 20);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(231, 748);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // aceTradeMonitor
            // 
            this.aceTradeMonitor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceTradeMonitor.ImageOptions.Image")));
            this.aceTradeMonitor.Name = "aceTradeMonitor";
            this.aceTradeMonitor.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTradeMonitor.Text = "Trade Monitor";
            this.aceTradeMonitor.Click += new System.EventHandler(this.aceTradeMonitor_Click);
            // 
            // aceTradeParameters
            // 
            this.aceTradeParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceTradeParameters.ImageOptions.Image")));
            this.aceTradeParameters.Name = "aceTradeParameters";
            this.aceTradeParameters.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTradeParameters.Text = "Trade Parameters";
            this.aceTradeParameters.Click += new System.EventHandler(this.aceTradeParameters_Click);
            // 
            // aceKlineParameters
            // 
            this.aceKlineParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceKlineParameters.ImageOptions.Image")));
            this.aceKlineParameters.Name = "aceKlineParameters";
            this.aceKlineParameters.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceKlineParameters.Text = "Kline Parameters";
            this.aceKlineParameters.Click += new System.EventHandler(this.aceParameters_Click);
            // 
            // aceApiManagement
            // 
            this.aceApiManagement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceApiManagement.ImageOptions.Image")));
            this.aceApiManagement.Name = "aceApiManagement";
            this.aceApiManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceApiManagement.Text = "Api Management";
            this.aceApiManagement.Click += new System.EventHandler(this.aceApiManagement_Click);
            // 
            // aceIndicatorParameters
            // 
            this.aceIndicatorParameters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceIndicatorParameters.ImageOptions.Image")));
            this.aceIndicatorParameters.Name = "aceIndicatorParameters";
            this.aceIndicatorParameters.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceIndicatorParameters.Text = "Indicator Parameters";
            this.aceIndicatorParameters.Click += new System.EventHandler(this.aceIndicatorParameters_Click);
            // 
            // accLogs
            // 
            this.accLogs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accLogs.ImageOptions.Image")));
            this.accLogs.Name = "accLogs";
            this.accLogs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accLogs.Text = "Logs";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1092, 20);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 768);
            this.ControlContainer = this.mainFormContainer;
            this.Controls.Add(this.mainFormContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainFrom.IconOptions.SvgImage")));
            this.Name = "MainFrom";
            this.NavigationControl = this.accordionControl1;
            this.Text = "Algo Trade Master";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainFormContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceKlineParameters;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTradeMonitor;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTradeParameters;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceApiManagement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceIndicatorParameters;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accLogs;
    }
}

