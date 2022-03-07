using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Abstract;
using Business.DependencyResolvers;

namespace DevExpressUI
{
    public partial class TradeMonitorUC : DevExpress.XtraEditors.XtraUserControl
    {
        public TradeMonitorUC()
        {
            InitializeComponent();
            _tradeParameterService = AutofacInstanceFactory.GetInstance<ITradeParameterService>();
        }

        private readonly ITradeParameterService _tradeParameterService;
        private static TradeMonitorUC _tradeMonitorUc;

        public static TradeMonitorUC Instance
        {

            get
            {
                if (_tradeMonitorUc == null)
                    _tradeMonitorUc = new TradeMonitorUC();
                return _tradeMonitorUc;
            }
        }

        private void TradeMonitorUC_Load(object sender, EventArgs e)
        {
            LoadTradeParameters();
        }

        private async void LoadTradeParameters()
        {
            var result = await _tradeParameterService.GetAllTradeParametersAsync();
            cbxTradeParameterTitle.DataSource = result.Data;
            cbxTradeParameterTitle.ValueMember = "Id";
            cbxTradeParameterTitle.DisplayMember = "TradeParameterTitle";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"cmd.exe", @"/k c:\Users\Barış\source\repos\Trade\KlineUpdater\bin\Debug\netcoreapp3.1\KlineUpdater.exe");
        }
    }
}
