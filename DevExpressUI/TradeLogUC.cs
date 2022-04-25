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
using DevExpressUI.Helpers;

namespace DevExpressUI
{
    public partial class TradeLogUC : DevExpress.XtraEditors.XtraUserControl
    {
        private TradeLogUC()
        {
            InitializeComponent();
            _tradeFlowService = AutofacInstanceFactory.GetInstance<ITradeFlowService>();
            _tradeLogService = AutofacInstanceFactory.GetInstance<ITradeLogService>();
        }

        private readonly ITradeLogService _tradeLogService;
        private readonly ITradeFlowService _tradeFlowService;
        private static TradeLogUC _tradeLogsUc;
        public static TradeLogUC Instance
        {

            get
            {
                if (_tradeLogsUc == null)
                    _tradeLogsUc = new TradeLogUC();
                return _tradeLogsUc;
            }
        }

 
        private void TradeLogUC_Load(object sender, EventArgs e)
        {
            LoadTradeLogDetails();
            SetGridColumnWidth();
            LoadTradeFlows();
        }

        private  void LoadTradeFlows()
        {
            var result = _tradeFlowService.GetAllTradeFlowPartialDetails();
            cbxTradeFlows.DataSource = result.Data;
            cbxTradeFlows.ValueMember = "Id";
            cbxTradeFlows.DisplayMember = "TradeParameterTitle";
        }

        private void LoadTradeLogDetails()
        {

            var result = _tradeLogService.GetAllTradeLogDetails();
            gridTradeLogs.DataSource = result.Data;
        }

        private void SetGridColumnWidth()
        {
            this.gvTradeLogs2.OptionsView.ColumnAutoWidth = false;
            this.gvTradeLogs2.BestFitColumns();

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTradeLogDetails();
        }

        private void gvTradeLogs2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnDateTimeFormatHelper.ColumnDateTimeFormatter(e);
        }
    }
}
