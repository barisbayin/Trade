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
    public partial class TradeParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        private TradeParametersUC()
        {
            InitializeComponent();
            _tradeParameterService = AutofacInstanceFactory.GetInstance<ITradeParameterService>();
        }

        private readonly ITradeParameterService _tradeParameterService;
        private static TradeParametersUC _tradeParametersUc;
        public static TradeParametersUC Instance
        {

            get
            {
                if (_tradeParametersUc == null)
                    _tradeParametersUc = new TradeParametersUC();
                return _tradeParametersUc;
            }
        }

        private void TradeParametersUC_Load(object sender, EventArgs e)
        {
            LoadTradeParameterList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }



        private void LoadTradeParameterList()
        {
            var result = _tradeParameterService.GetTradeParameterDetails();
            gridTradeParameters.DataSource = result.Data;
        }
    }
}
