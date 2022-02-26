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

namespace DXApplication1
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private async void Parameters_Click(object sender, EventArgs e)
        {
            await Task.Run((() =>
            {
                if (!mainFormContainer.Controls.Contains(ParametersUC.Instance))
                {
                    mainFormContainer.BeginInvoke(new Action(delegate ()
                    {
                        mainFormContainer.Controls.Add(ParametersUC.Instance);

                        ParametersUC.Instance.Dock = DockStyle.Fill;
                        ParametersUC.Instance.BringToFront();
                    }));
                }

                ParametersUC.Instance.BringToFront();
            }));
        }
    }
}
