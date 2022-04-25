using Business.Abstract;
using Business.DependencyResolvers;
using Core.Costants.Messages;
using Entity.Concrete.Entities;
using System;
using System.Drawing;
using DevExpressUI.Helpers;

namespace DevExpressUI
{
    public partial class KlineParametersUc : DevExpress.XtraEditors.XtraUserControl
    {
        public KlineParametersUc()
        {
            InitializeComponent();

            _binanceCommonDatabaseParameterService = AutofacInstanceFactory.GetInstance<IBinanceCommonDatabaseParameterService>();

        }



        private readonly IBinanceCommonDatabaseParameterService _binanceCommonDatabaseParameterService;


        private static KlineParametersUc _parametersUc;
        public static KlineParametersUc Instance
        {

            get
            {
                if (_parametersUc == null)
                    _parametersUc = new KlineParametersUc();
                return _parametersUc;
            }
        }

        private void ParametersUC_Load(object sender, EventArgs e)
        {
            LoadDayParameters();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }

        private async void LoadDayParameters()
        {
            var dayParameterList = (await _binanceCommonDatabaseParameterService.GetAllBinanceIntervalParametersAsync()).Data;
            gridDayParameters.DataSource = dayParameterList;
            SetGridColumnWidth();
        }



        private void gvDayParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDayParameters.RowCount > 0)
            {
                lblIdNo.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[0]) == null ? "" : gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[0]).ToString();
                cbxInterval.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[1]) == null ? "" : gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[1]).ToString();
                cbxMarket.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[2]) == null ? "" : gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[2]).ToString();
                tbxDayCount.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[3]) == null ? "" : gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[3]).ToString();
                lblKlineCount.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[4]) == null ? "" : gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[4]).ToString();
            }
            else
            {
                ClearAll();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(lblIdNo.Text);
                var result = await _binanceCommonDatabaseParameterService.DeleteDayParameterByIdAsync(id);

                if (result.Success)
                {
                    ClearAll();
                    LoadDayParameters();
                    lblResult.Text = "Id:" + id.ToString() + " " + result.Message;
                }
                else
                {
                    lblResult.Text = CommonMessages.Error;
                }
            }
            catch (Exception exception)
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }
            

        }

        private void ClearAll()
        {
            lblIdNo.Text = "";
            cbxInterval.Text = "";
            cbxMarket.Text = "";
            tbxDayCount.Text = "";
            lblKlineCount.Text = "";
            lblResult.Text = "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            BinanceIntervalParameterEntity binanceIntervalParameterEntity = new BinanceIntervalParameterEntity();
            if (tbxDayCount.Text == "" || cbxInterval.Text == "" || cbxMarket.Text == "")
            {
                lblResult.Text = CommonMessages.EnterAllRequiredParameters;
            }
            else
            {
                if (lblIdNo.Text == "")
                {
                    binanceIntervalParameterEntity.Interval = cbxInterval.Text;
                    binanceIntervalParameterEntity.Market = cbxMarket.Text;
                    binanceIntervalParameterEntity.DayParameter = Convert.ToInt32(tbxDayCount.Text);
                    var result = await _binanceCommonDatabaseParameterService.AddDayParameterAsync(binanceIntervalParameterEntity);
                    if (result.Success)
                    {
                        lblResult.Text = "New Parameter " + result.Message;
                        LoadDayParameters();
                    }
                    else
                    {
                        lblResult.Text = result.Message;
                    }
                }

                if (lblIdNo.Text != "")
                {
                    binanceIntervalParameterEntity.Id = Convert.ToInt32(lblIdNo.Text);
                    binanceIntervalParameterEntity.Interval = cbxInterval.Text;
                    binanceIntervalParameterEntity.Market = cbxMarket.Text;
                    binanceIntervalParameterEntity.DayParameter = Convert.ToInt32(tbxDayCount.Text);
                    var result = await _binanceCommonDatabaseParameterService.UpdateDayParameterAsync(binanceIntervalParameterEntity);
                    if (result.Success)
                    {
                        lblResult.Text = "Id:" + lblIdNo.Text + " " + result.Message;
                        LoadDayParameters();
                    }
                    else
                    {
                        lblResult.Text = result.Message;
                    }
                }
            }


        }

        private void gvDayParameters_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnDateTimeFormatHelper.ColumnDateTimeFormatter(e);
        }
        private void SetGridColumnWidth()
        {
            this.gvDayParameters.OptionsView.ColumnAutoWidth = false;
            this.gvDayParameters.BestFitColumns();

        }
    }
}
