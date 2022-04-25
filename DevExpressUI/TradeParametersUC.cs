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
using Core.Costants.Messages;
using DevExpressUI.Helpers;
using Entity.Concrete.Entities;

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
            _binanceExchangeInformationService = AutofacInstanceFactory.GetInstance<IBinanceExchangeInformationService>();


        }

        private readonly ITradeParameterService _tradeParameterService;
        private readonly IIndicatorParameterService _indicatorParameterService;
        private readonly IApiInformationService _apiInformationService;
        private readonly IBinanceExchangeInformationService _binanceExchangeInformationService;

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
            LoadSymbolPairs();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
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
                var result = await _tradeParameterService.DeleteTradeParameterByIdAsync(id);

                ClearAll();
                LoadTradeParameterList();
                lblResult.Text = "Id: " + id + " " + result.Message;

            }
            catch (Exception exception)
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTradeParameterList();
            LoadIndicatorParameter();
            LoadApiToUse();
            LoadSymbolPairs();
            ClearAll();
            lblResult.Text = "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxTradeParameterTitle.Text == "" || cbxApiToUse.Text == "" || cbxIndicatorParameter.Text == "" || cbxApiToUse.Text == "" || cbxSymbolPair.Text == "" || cbxInterval.Text == "" || cbxMarginType.Text == "" || cbxLeverage.Text == "" || tbxMaxBalanceLimit.Text == "" || tbxMaxABalancePercentage.Text == "")
            {
                lblResult.Text = CommonMessages.EnterAllRequiredParameters;
            }
            else
            {
                if (chckAddPnlToMaxAmountLimit.CheckState == CheckState.Checked && tbxPercentageOfPnlToBeAdded.Text == "")
                {
                    lblResult.Text = "Percentage of Pnl to be added is empty!";
                }
                else
                {
                    try
                    {
                        if (lblIdNo.Text == "")
                        {

                            TradeParameterEntity tradeParameterEntity = new TradeParameterEntity();

                            tradeParameterEntity.IndicatorParameterId = Convert.ToInt32(cbxIndicatorParameter.SelectedValue);
                            tradeParameterEntity.ApiInformationId = Convert.ToInt32(cbxApiToUse.SelectedValue);
                            tradeParameterEntity.TradeParameterTitle = tbxTradeParameterTitle.Text;
                            tradeParameterEntity.SymbolPair = cbxSymbolPair.Text;
                            tradeParameterEntity.Interval = cbxInterval.Text;
                            tradeParameterEntity.MarginType = cbxMarginType.Text;
                            tradeParameterEntity.Leverage = Convert.ToInt32(cbxLeverage.Text);
                            tradeParameterEntity.StopLossPercent = tbxStopLossPercent.Text == "" ? 0 : Convert.ToDecimal(tbxStopLossPercent.Text);
                            tradeParameterEntity.MaximumBalanceLimit = tbxMaxBalanceLimit.Text == "" ? 0 : Convert.ToDecimal(tbxMaxBalanceLimit.Text);
                            tradeParameterEntity.MaxBalancePercentage = tbxMaxABalancePercentage.Text == "" ? 0 : Convert.ToDecimal(tbxMaxABalancePercentage.Text);
                            tradeParameterEntity.AddPnlToMaximumBalanceLimit = Convert.ToBoolean(chckAddPnlToMaxAmountLimit.CheckState);
                            tradeParameterEntity.PercentageOfPnlToBeAdded = tbxPercentageOfPnlToBeAdded.Text == "" ? 0 : Convert.ToDecimal(tbxPercentageOfPnlToBeAdded.Text);
                            tradeParameterEntity.OrderRangeBrickQuantity = Convert.ToInt32(tbxOrderRangeBrickQuantity.Text);
                            tradeParameterEntity.OrderQuantity = Convert.ToInt32(cbxOrderQuantity.Text);
                            tradeParameterEntity.PriceCalculationMethod = cbxPriceCalculationMethod.Text;
                            tradeParameterEntity.CancelOrdersAfterBrick = Convert.ToInt32(tbxCancelOrdersAfterBrick.Text);
                            tradeParameterEntity.NumberOfBricksToBeTolerated= Convert.ToInt32(tbxPercentageOfPnlToBeAdded.Text);

                            var result = await _tradeParameterService.AddTradeParameterAsync(tradeParameterEntity);

                            if (result.Success)
                            {
                                lblResult.Text = "New Parameter " + result.Message;
                            }
                            else
                            {
                                lblResult.Text = result.Message;
                            }

                        }

                        if (lblIdNo.Text != "")
                        {

                            var tradeParameterEntity = (await _tradeParameterService.GetTradeParameterEntityByIdAsync(Convert.ToInt32(lblIdNo.Text))).Data;

                            tradeParameterEntity.IndicatorParameterId = Convert.ToInt32(cbxIndicatorParameter.SelectedValue);
                            tradeParameterEntity.ApiInformationId = Convert.ToInt32(cbxApiToUse.SelectedValue);
                            tradeParameterEntity.TradeParameterTitle = tbxTradeParameterTitle.Text;
                            tradeParameterEntity.SymbolPair = cbxSymbolPair.Text;
                            tradeParameterEntity.Interval = cbxInterval.Text;
                            tradeParameterEntity.MarginType = cbxMarginType.Text;
                            tradeParameterEntity.Leverage = Convert.ToInt32(cbxLeverage.Text);
                            tradeParameterEntity.StopLossPercent = tbxStopLossPercent.Text == "" ? 0 : Convert.ToDecimal(tbxStopLossPercent.Text);
                            tradeParameterEntity.MaximumBalanceLimit = tbxMaxBalanceLimit.Text == "" ? 0 : Convert.ToDecimal(tbxMaxBalanceLimit.Text);
                            tradeParameterEntity.MaxBalancePercentage = tbxMaxABalancePercentage.Text == "" ? 0 : Convert.ToDecimal(tbxMaxABalancePercentage.Text);
                            tradeParameterEntity.AddPnlToMaximumBalanceLimit = Convert.ToBoolean(chckAddPnlToMaxAmountLimit.CheckState);
                            tradeParameterEntity.PercentageOfPnlToBeAdded = tbxPercentageOfPnlToBeAdded.Text == "" ? 0 : Convert.ToDecimal(tbxPercentageOfPnlToBeAdded.Text);
                            tradeParameterEntity.OrderRangeBrickQuantity = Convert.ToInt32(tbxOrderRangeBrickQuantity.Text);
                            tradeParameterEntity.OrderQuantity = Convert.ToInt32(cbxOrderQuantity.Text);
                            tradeParameterEntity.PriceCalculationMethod = cbxPriceCalculationMethod.Text;
                            tradeParameterEntity.CancelOrdersAfterBrick = Convert.ToInt32(tbxCancelOrdersAfterBrick.Text);
                            tradeParameterEntity.NumberOfBricksToBeTolerated = Convert.ToInt32(tbxPercentageOfPnlToBeAdded.Text);

                            var result = await _tradeParameterService.UpdateTradeParameterAsync(tradeParameterEntity);

                            if (result.Success)
                            {
                                lblResult.Text = "Id:" + lblIdNo.Text + " " + result.Message;
                            }
                            else
                            {
                                lblResult.Text = result.Message;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        lblResult.Text = CommonMessages.Error;
                    }
                }

                LoadTradeParameterList();
            }
        }



        private void LoadTradeParameterList()
        {
            var result = _tradeParameterService.GetTradeParameterDetails();
            gridTradeParameters.DataSource = result.Data;
            SetGridColumnWidth();
        }

        private void LoadIndicatorParameter()
        {
            var result = _indicatorParameterService.GetAllIndicatorParameters();
            cbxIndicatorParameter.DataSource = result.Data;
            cbxIndicatorParameter.ValueMember = "Id";
            cbxIndicatorParameter.DisplayMember = "ParameterTitle";
        }

        private void LoadApiToUse()
        {
            var result = _apiInformationService.GetAllNotRemovedApiInformation();
            cbxApiToUse.DataSource = result.Data;
            cbxApiToUse.ValueMember = "Id";
            cbxApiToUse.DisplayMember = "ApiTitle";
        }

        private void LoadSymbolPairs()
        {
            var result = _binanceExchangeInformationService.GetAllFuturesUsdtSymbolInformation();
            cbxSymbolPair.DataSource = result.Data;
            cbxSymbolPair.ValueMember = "Id";
            cbxSymbolPair.DisplayMember = "Name";
        }

        private void ClearAll()
        {
            lblIdNo.Text = "";
            tbxTradeParameterTitle.Text = "";
            cbxIndicatorParameter.Text = "";
            cbxApiToUse.Text = "";
            cbxSymbolPair.Text = "";
            cbxInterval.Text = "";
            cbxMarginType.Text = "";
            cbxLeverage.Text = "";
            tbxStopLossPercent.Text = "";
            tbxMaxBalanceLimit.Text = "";
            tbxMaxABalancePercentage.Text = "";
            chckAddPnlToMaxAmountLimit.CheckState = CheckState.Unchecked;
            tbxPercentageOfPnlToBeAdded.Text = "";
            tbxOrderRangeBrickQuantity.Text = "";
            cbxOrderQuantity.Text = "";
            cbxPriceCalculationMethod.Text = "";
            tbxCancelOrdersAfterBrick.Text = "";
            tbxNumberOfBricksToBeTolerated.Text = "";
            lblInUse.Text = "";
            lblCreationDate.Text = "";
            lblModifiedDate.Text = "";
        }

        private void gvTradeParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTradeParameters.RowCount > 0)
            {
                lblIdNo.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Id"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Id"]).ToString();

                tbxTradeParameterTitle.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["TradeParameterTitle"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["TradeParameterTitle"]).ToString();

                cbxIndicatorParameter.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["IndicatorParameterTitle"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["IndicatorParameterTitle"]).ToString();

                cbxApiToUse.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ApiTitle"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ApiTitle"]).ToString();

                cbxSymbolPair.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["SymbolPair"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["SymbolPair"]).ToString();

                cbxInterval.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Interval"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Interval"]).ToString();

                cbxMarginType.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MarginType"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MarginType"]).ToString();

                cbxLeverage.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Leverage"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["Leverage"]).ToString();

                tbxStopLossPercent.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["StopLossPercent"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["StopLossPercent"]).ToString();

                tbxMaxBalanceLimit.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountLimit"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountLimit"]).ToString();

                tbxMaxABalancePercentage.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountPercentage"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["MaxAmountPercentage"]).ToString();

                chckAddPnlToMaxAmountLimit.CheckState = Convert.ToBoolean(gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["AddPnlToMaxAmountLimit"])) == false ? CheckState.Unchecked : CheckState.Checked;

                tbxPercentageOfPnlToBeAdded.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PercentageOfPnlToBeAdded"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PercentageOfPnlToBeAdded"]).ToString();

                tbxOrderRangeBrickQuantity.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["OrderRangeBrickQuantity"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["OrderRangeBrickQuantity"]).ToString();

                cbxOrderQuantity.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["OrderQuantity"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["OrderQuantity"]).ToString();

                cbxPriceCalculationMethod.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PriceCalculationMethod"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["PriceCalculationMethod"]).ToString();

                tbxCancelOrdersAfterBrick.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CancelOrdersAfterBrick"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CancelOrdersAfterBrick"]).ToString();

                tbxNumberOfBricksToBeTolerated.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["NumberOfBricksToBeTolerated"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["NumberOfBricksToBeTolerated"]).ToString();

                lblInUse.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["InUse"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["InUse"]).ToString();

                lblCreationDate.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CreationDate"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["CreationDate"]).ToString();

                lblModifiedDate.Text = gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ModifiedDate"]) == null ? "" : gvTradeParameters.GetRowCellValue(gvTradeParameters.FocusedRowHandle, gvTradeParameters.Columns["ModifiedDate"]).ToString();

            }
            else
            {
                ClearAll();
            }
        }

        private void gvTradeParameters_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool inUse = Convert.ToBoolean(gvTradeParameters.GetRowCellValue(e.RowHandle, "InUse"));

            if (inUse == true)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gvTradeParameters_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnDateTimeFormatHelper.ColumnDateTimeFormatter(e);
        }
        private void SetGridColumnWidth()
        {
            this.gvTradeParameters.OptionsView.ColumnAutoWidth = false;
            this.gvTradeParameters.BestFitColumns();

        }
    }
}
