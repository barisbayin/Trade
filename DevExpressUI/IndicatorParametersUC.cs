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
    public partial class IndicatorParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public IndicatorParametersUC()
        {
            InitializeComponent();
            _indicatorParameterService = AutofacInstanceFactory.GetInstance<IIndicatorParameterService>();
        }

        private readonly IIndicatorParameterService _indicatorParameterService;

        private static IndicatorParametersUC _indicatorParametersUC;
        public static IndicatorParametersUC Instance
        {

            get
            {
                if (_indicatorParametersUC == null)
                    _indicatorParametersUC = new IndicatorParametersUC();
                return _indicatorParametersUC;
            }
        }

        private void IndicatorParametersUC_Load(object sender, EventArgs e)
        {
            LoadIndicatorParameterList();
        }

        private void LoadIndicatorParameterList()
        {
            var result = _indicatorParameterService.GetIndicatorParameterDetails();
            gridIndicatorParameters.DataSource = result.Data;
        }


    }
}
