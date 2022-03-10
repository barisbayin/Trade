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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"cmd.exe", @"/k c:\Users\Barış\source\repos\Trade\KlineUpdater\bin\Debug\netcoreapp3.1\KlineUpdater.exe");
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

                    if (lblIdNo.Text != "")
                    {

                        var tradeFlowEntity = (await _tradeFlowService.GetTradeFlowById(Convert.ToInt32(lblIdNo.Text))).Data;

                        tradeFlowEntity.TradeParameterId = Convert.ToInt32(cbxTradeParameterTitle.SelectedValue);


                        var result = await _tradeFlowService.UpdateTradeFlow(tradeFlowEntity);

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
    }
}
