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
            _indicatorParameterService = AutofacInstanceFactory.GetInstance<IIndicatorParameterService>();
            _apiInformationService = AutofacInstanceFactory.GetInstance<IApiInformationService>();

        }

        private readonly ITradeParameterService _tradeParameterService;
        private readonly IIndicatorParameterService _indicatorParameterService;
        private readonly IApiInformationService _apiInformationService;

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
            LoadIndicatorParameter();
            LoadApiToUse();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
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

        private void LoadIndicatorParameter()
        {
            var result = _indicatorParameterService.GetAllIndicatorParameters();
            cbxIndicatorParameter.DataSource = result.Data;
            cbxIndicatorParameter.ValueMember = "Id";
            cbxIndicatorParameter.DisplayMember = "ParameterTitle";
        }

        private async void LoadApiToUse()
        {
            var result =(await _apiInformationService.GetAllNotRemovedApiInformationAsync()).Data;
            cbxApiToUse.DataSource = result;
            cbxApiToUse.ValueMember = "Id";
            cbxApiToUse.DisplayMember = "ApiTitle";
        }

        private void ClearAll()
        {
            lblIdNo.Text = "";
            cbxIndicatorParameter.Text = "";
            cbxApiToUse.Text = "";
            cbxSymbolPair.Text = "";
            cbxInterval.Text = "";
            cbxMarginType.Text = "";
            cbxLeverage.Text = "";
            tbxMaxAmountLimit.Text = "";
            tbxMaxAmountPercentage.Text = "";
            chckAddPnlToMaxAmountLimit.CheckState = CheckState.Unchecked;
            tbxPercentageOfPnlToBeAdded.Text = "";
            lblInUse.Text = "";
            lblCreationDate.Text = "";
            lblModifiedDate.Text = "";
        }

        private void gvTradeParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTradeParameters.RowCount > 0)
            {
                lblIdNo.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Id"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Id"]).ToString();

                cbxIndicatorParameter.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["IndicatorParameterTitle"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["IndicatorParameterTitle"]).ToString();

                cbxApiToUse.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ApiTitle"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ApiTitle"]).ToString();

                cbxSymbolPair.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["SymbolPair"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["SymbolPair"]).ToString();

                cbxInterval.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Interval"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Interval"]).ToString();

                cbxMarginType.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MarginType"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MarginType"]).ToString();

                cbxLeverage.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Leverage"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Leverage"]).ToString();

                tbxMaxAmountLimit.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountLimit"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountLimit"]).ToString();

                tbxMaxAmountPercentage.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountPercentage"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountPercentage"]).ToString();

                chckAddPnlToMaxAmountLimit.CheckState = Convert.ToBoolean(gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["AddPnlToMaxAmountLimit"])) == false ? CheckState.Unchecked : CheckState.Checked;

                tbxPercentageOfPnlToBeAdded.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PercentageOfPnlToBeAdded"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PercentageOfPnlToBeAdded"]).ToString();

                lblInUse.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["InUse"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["InUse"]).ToString();

                lblCreationDate.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CreationDate"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CreationDate"]).ToString();

                lblModifiedDate.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ModifiedDate"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ModifiedDate"]).ToString();

            }
            else
            {
                ClearAll();
            }
        }
    }
}
