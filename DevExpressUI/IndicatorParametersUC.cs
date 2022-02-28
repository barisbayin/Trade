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
    public partial class IndicatorParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public IndicatorParametersUC()
        {
            InitializeComponent();
        }
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
        private void chckShowDeleted_Properties_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
