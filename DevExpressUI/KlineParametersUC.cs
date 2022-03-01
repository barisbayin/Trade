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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Costants.Messages;
using Entity.Concrete.Entities;

namespace DevExpressUI
{
    public partial class KlineParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public KlineParametersUC()
        {
            InitializeComponent();

            _binanceCommonDatabaseParameterService = AutofacInstanceFactory.GetInstance<IBinanceCommonDatabaseParameterService>();

        }



        private readonly IBinanceCommonDatabaseParameterService _binanceCommonDatabaseParameterService;


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
            ClearAll();
        }

        private async void LoadDayParameters()
        {
            var dayParameterList = (await _binanceCommonDatabaseParameterService.GetAllBinanceIntervalParametersAsync()).Data;
            gridDayParameters.DataSource = dayParameterList;
        }



        private void gvDayParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDayParameters.RowCount > 0)
            {
                lblIdNo.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[0]).ToString();
                cbxInterval.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[1]).ToString();
                cbxMarket.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[2]).ToString();
                tbxDayCount.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[3]).ToString();
                lblKlineCount.Text = gvDayParameters.GetRowCellValue(gvDayParameters.FocusedRowHandle, gvDayParameters.Columns[4]).ToString();
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
                var result = await _binanceCommonDatabaseParameterService.DeleteDayParameterById(id);

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
    }
}
