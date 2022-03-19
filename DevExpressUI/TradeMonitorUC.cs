﻿using DevExpress.XtraEditors;
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
using Entity.Concrete.Entities;

namespace DevExpressUI
{
    public partial class TradeMonitorUC : DevExpress.XtraEditors.XtraUserControl
    {
        public TradeMonitorUC()
        {
            InitializeComponent();
            _tradeParameterService = AutofacInstanceFactory.GetInstance<ITradeParameterService>();
            _tradeFlowService = AutofacInstanceFactory.GetInstance<ITradeFlowService>();
        }

        private readonly ITradeParameterService _tradeParameterService;
        private readonly ITradeFlowService _tradeFlowService;
        private static TradeMonitorUC _tradeMonitorUc;

        public static TradeMonitorUC Instance
        {

            get
            {
                if (_tradeMonitorUc == null)
                    _tradeMonitorUc = new TradeMonitorUC();
                return _tradeMonitorUc;
            }
        }

        private void TradeMonitorUC_Load(object sender, EventArgs e)
        {
            LoadTradeFlowDetails();
            LoadTradeParameters();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }

        private async void LoadTradeParameters()
        {
            var result = await _tradeParameterService.GetAllTradeParametersAsync();
            cbxTradeParameterTitle.DataSource = result.Data;
            cbxTradeParameterTitle.ValueMember = "Id";
            cbxTradeParameterTitle.DisplayMember = "TradeParameterTitle";
        }

        private void LoadTradeFlowDetails()
        {
            var result = _tradeFlowService.GetTradeFlowPartialDetails();
            gridTradeFlowPartial.DataSource = result.Data;
        }

        private void ClearAll()
        {
            lblIdNo.Text = "..";
            cbxTradeParameterTitle.Text = "";
            lblSymbolPair.Text = "..";
            lblInterval.Text = "..";
            lblIndicatorParameter.Text = "..";
            lblApiToUse.Text = "..";
            lblMarginType.Text = "..";
            lblLeverage.Text = "..";
            lblMaxAmountLimit.Text = "..";
            lblMaxAmountLimitPercentage.Text = "..";
            lblAddPnlToMAL.Text = "..";
            lblPercentageOfPnl.Text = "..";
            lblInUse.Text = "..";
            lblIsSelected.Text = "..";
            lblCreationDate.Text = "..";
            lblModifiedDate.Text = "..";
            lblResult.Text = "..";

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTradeParameters();
            LoadTradeFlowDetails();
            ClearAll();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxTradeParameterTitle.Text == "")
            {
                lblResult.Text = CommonMessages.EnterAllRequiredParameters;
            }
            else
            {

                try
                {
                    if (lblIdNo.Text == "..")
                    {

                        TradeFlowEntity tradeFlowEntity = new TradeFlowEntity();

                        tradeFlowEntity.TradeParameterId = Convert.ToInt32(cbxTradeParameterTitle.SelectedValue);

                        var result = await _tradeFlowService.AddTradeFlowAsync(tradeFlowEntity);

                        if (result.Success)
                        {
                            lblResult.Text = "New Parameter " + result.Message;
                        }
                        else
                        {
                            lblResult.Text = result.Message;
                        }

                    }

                    if (lblIdNo.Text != "..")
                    {

                        var tradeFlowEntity = (await _tradeFlowService.GetTradeFlowByIdAsync(Convert.ToInt32(lblIdNo.Text))).Data;

                        tradeFlowEntity.TradeParameterId = Convert.ToInt32(cbxTradeParameterTitle.SelectedValue);


                        var result = await _tradeFlowService.UpdateTradeFlowAsync(tradeFlowEntity);

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


                LoadTradeFlowDetails();
            }
        }

        private void gvTradeFlowPartial_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTradeFlowPartial.RowCount > 0)
            {
                lblIdNo.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Id"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Id"]).ToString();
                cbxTradeParameterTitle.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["TradeParameterTitle"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["TradeParameterTitle"]).ToString();
                lblSymbolPair.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["SymbolPair"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["SymbolPair"]).ToString();
                lblInterval.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Interval"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Interval"]).ToString();
                lblIndicatorParameter.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["IndicatorParameterTitle"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["IndicatorParameterTitle"]).ToString();
                lblApiToUse.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["ApiTitle"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["ApiTitle"]).ToString();
                lblMarginType.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MarginType"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MarginType"]).ToString();
                lblLeverage.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Leverage"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["Leverage"]).ToString();
                lblMaxAmountLimit.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MaxAmountLimit"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MaxAmountLimit"]).ToString();
                lblMaxAmountLimitPercentage.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MaxAmountPercentage"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["MaxAmountPercentage"]).ToString();
                lblAddPnlToMAL.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["AddPnlToMaxAmountLimit"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["AddPnlToMaxAmountLimit"]).ToString();
                lblPercentageOfPnl.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["PercentageOfPnlToBeAdded"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["PercentageOfPnlToBeAdded"]).ToString();
                lblInUse.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["InUse"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["InUse"]).ToString();
                lblIsSelected.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["IsSelected"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["IsSelected"]).ToString();
                lblCreationDate.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["CreationDate"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["CreationDate"]).ToString();
                lblModifiedDate.Text = gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["ModifiedDate"]) == null ? "" : gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["ModifiedDate"]).ToString();

                if (gvTradeFlowPartial.GetRowCellValue(gvTradeFlowPartial.FocusedRowHandle, gvTradeFlowPartial.Columns["IsSelected"]).ToString()=="True")
                {
                    btnSelect.Visible = false;
                    btnUnselect.Visible = true;
                }
                else
                {
                    btnSelect.Visible = true;
                    btnUnselect.Visible = false;
                }
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

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            if (lblIdNo.Text == "..")
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }
            else
            {
                var result = await _tradeFlowService.SelectTradeFlowAsync(Convert.ToInt32(lblIdNo.Text));

                lblResult.Text = "Id: " + lblIdNo.Text + " " + result.Message;

            }
            LoadTradeFlowDetails();

        }

        private async void btnUnselect_Click(object sender, EventArgs e)
        {
            if (lblIdNo.Text == "..")
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }
            else
            {
                var result = await _tradeFlowService.UnSelectTradeFlowAsync(Convert.ToInt32(lblIdNo.Text));

                lblResult.Text = "Id: " + lblIdNo.Text + " " + result.Message;

            }
            LoadTradeFlowDetails();
        }

        private void gvTradeFlowPartial_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isSelected = Convert.ToBoolean(gvTradeFlowPartial.GetRowCellValue(e.RowHandle, "IsSelected"));
            bool inUse = Convert.ToBoolean(gvTradeFlowPartial.GetRowCellValue(e.RowHandle, "InUse"));
            if (isSelected == true)
            {
                e.Appearance.BackColor = Color.Blue;
                e.Appearance.ForeColor = Color.White;
            }

            if (inUse == true)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"cmd.exe", @"/k c:\Users\Barış\source\repos\Trade\KlineUpdater\bin\Debug\netcoreapp3.1\KlineUpdater.exe");
        }
    }
}