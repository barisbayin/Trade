using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers;
using DataAccess.Abstract;
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

namespace DevExpressUI
{
    public partial class KlineParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public KlineParametersUC()
        {
            InitializeComponent();

            _binanceCommonDatabaseParameterService = AutofacInstanceFactory.GetInstance<IBinanceCommonDatabaseParameterService>();
            _binanceCommonDatabaseParameterDal = AutofacInstanceFactory.GetInstance<IBinanceCommonDatabaseParameterDal>();

        }



        private readonly IBinanceCommonDatabaseParameterService _binanceCommonDatabaseParameterService;
        private IBinanceCommonDatabaseParameterDal _binanceCommonDatabaseParameterDal;


        private static KlineParametersUC _parametersUc;
        public static KlineParametersUC Instance
        {

            get
            {
                if (_parametersUc == null)
                    _parametersUc = new KlineParametersUC();
                return _parametersUc;
            }
        }

        private void ParametersUC_Load(object sender, EventArgs e)
        {
            LoadDayParameters();
        }

        public  async void LoadDayParameters()
        {
            var dayParameterList = (await _binanceCommonDatabaseParameterService.GetAllBinanceIntervalParametersAsync()).Data;
            gridDayParameters.DataSource = dayParameterList;
        }


    }
}
