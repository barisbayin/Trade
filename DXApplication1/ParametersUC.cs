
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
    public partial class ParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public ParametersUC()
        {
            InitializeComponent();

        }


        private static ParametersUC _parametersUC;
        public static ParametersUC Instance
        {

            get
            {
                if (_parametersUC == null)
                    _parametersUC = new ParametersUC();
                return _parametersUC;
            }
        }
    }
}
