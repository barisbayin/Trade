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
                if (!mainFormContainer.Controls.Contains(KlineParametersUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(KlineParametersUC.Instance);

                        KlineParametersUC.Instance.Dock = DockStyle.Fill;
                        KlineParametersUC.Instance.BringToFront();
                    }));
                }

                KlineParametersUC.Instance.BringToFront();
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
    }
}
