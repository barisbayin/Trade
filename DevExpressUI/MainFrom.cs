using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressUI
{
    public partial class MainFrom : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainFrom()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private async void aceParameters_Click(object sender, EventArgs e)
        {
            
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(KlineParametersUc.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(KlineParametersUc.Instance);

                        KlineParametersUc.Instance.Dock = DockStyle.Fill;
                        KlineParametersUc.Instance.BringToFront();
                    }));
                }

                KlineParametersUc.Instance.BringToFront();
            }));
        }

        private async void aceApiManagement_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(ApiManagementUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(ApiManagementUC.Instance);

                        ApiManagementUC.Instance.Dock = DockStyle.Fill;
                        ApiManagementUC.Instance.BringToFront();
                    }));
                }

                ApiManagementUC.Instance.BringToFront();
            }));
        }

        private async void aceIndicatorParameters_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(IndicatorParametersUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(IndicatorParametersUC.Instance);

                        IndicatorParametersUC.Instance.Dock = DockStyle.Fill;
                        IndicatorParametersUC.Instance.BringToFront();
                    }));
                }

                IndicatorParametersUC.Instance.BringToFront();
            }));
        }

        private async void aceTradeParameters_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(TradeParametersUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(TradeParametersUC.Instance);

                        TradeParametersUC.Instance.Dock = DockStyle.Fill;
                        TradeParametersUC.Instance.BringToFront();
                    }));
                }

                TradeParametersUC.Instance.BringToFront();
            }));
        }

        private async void aceTradeMonitor_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(TradeMonitorUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(TradeMonitorUC.Instance);

                        TradeMonitorUC.Instance.Dock = DockStyle.Fill;
                        TradeMonitorUC.Instance.BringToFront();
                    }));
                }

                TradeMonitorUC.Instance.BringToFront();
            }));
        }

        private async void accLogs_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(TradeLogUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(TradeLogUC.Instance);

                        TradeLogUC.Instance.Dock = DockStyle.Fill;
                        TradeLogUC.Instance.BringToFront();
                    }));
                }

                TradeLogUC.Instance.BringToFront();
            }));
        }
    }
}
