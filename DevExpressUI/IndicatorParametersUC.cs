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
using Castle.Core.Internal;
using Core.Costants.Messages;
using CryptoExchange.Net;
using DevExpress.Utils.Extensions;
using Entity.Concrete.Entities;

namespace DevExpressUI
{
    public partial class IndicatorParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public IndicatorParametersUC()
        {
            InitializeComponent();
            _indicatorParameterService = AutofacInstanceFactory.GetInstance<IIndicatorParameterService>();
            _indicatorService = AutofacInstanceFactory.GetInstance<IIndicatorService>();
        }

        private readonly IIndicatorParameterService _indicatorParameterService;
        private readonly IIndicatorService _indicatorService;

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
            LoadIndicators();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }

        private void LoadIndicatorParameterList()
        {
            var result = _indicatorParameterService.GetIndicatorParameterDetails();
            gridIndicatorParameters.DataSource = result.Data;
        }

        private async void LoadIndicators()
        {
            var result = await _indicatorService.GetAllIndicators();
            cbxIndicatorName.DataSource = result.Data;
            cbxIndicatorName.ValueMember = "Id";
            cbxIndicatorName.DisplayMember = "IndicatorName";

        }
        private void ClearAll()
        {
            lblIdNo.Text = "";
            cbxIndicatorName.Text = "";
            tbxParameterTitle.Text = "";
            cbxInterval.Text = "";
            tbxPeriod.Text = "";
            tbxMultiplier.Text = "";
            cbxKlineEndType.Text = "";
            tbxParameter1.Text = "";
            tbxParameter2.Text = "";
            tbxParameter3.Text = "";
            tbxParameter4.Text = "";
            tbxParameter5.Text = "";
            lblInUse.Text = "..";
            lblCreationDate.Text = "..";
            lblModifiedDate.Text = "..";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void gvIndicatorParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvIndicatorParameters.RowCount > 0)
            {
                lblIdNo.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Id"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Id"]).ToString();
                cbxIndicatorName.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["IndicatorName"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["IndicatorName"]).ToString();
                tbxParameterTitle.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["ParameterTitle"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["ParameterTitle"]).ToString();
                cbxInterval.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Interval"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Interval"]).ToString();
                tbxPeriod.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Period"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Period"]).ToString();
                tbxMultiplier.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Multiplier"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Multiplier"]).ToString();
                cbxKlineEndType.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["KlineEndType"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["KlineEndType"]).ToString();
                tbxParameter1.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter1"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter1"]).ToString();
                tbxParameter2.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter2"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter2"]).ToString();
                tbxParameter3.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter3"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter3"]).ToString();
                tbxParameter4.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter4"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter4"]).ToString();
                tbxParameter5.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter5"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["Parameter5"]).ToString();
                lblCreationDate.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["CreationDate"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["CreationDate"]).ToString();
                lblInUse.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["InUse"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["InUse"]).ToString();
                lblModifiedDate.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["ModifiedDate"]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns["ModifiedDate"]).ToString();

            }
            else
            {
                ClearAll();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(lblIdNo.Text);
                var result = await _indicatorParameterService.DeleteIndicatorParameterById(id);

                ClearAll();
                LoadIndicatorParameterList();
                lblResult.Text = "Id:" + id + " " + result.Message;

            }
            catch (Exception exception)
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }


        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (cbxIndicatorName.Text == "" || cbxInterval.Text == "" || tbxParameterTitle.Text == "")
            {
                lblResult.Text = CommonMessages.EnterAllRequiredParameters;
            }
            else
            {
                try
                {
                    if (lblIdNo.Text == "")
                    {

                        IndicatorParameterEntity indicatorParameterEntity = new IndicatorParameterEntity();

                        indicatorParameterEntity.IndicatorId = Convert.ToInt32(cbxIndicatorName.SelectedValue);
                        indicatorParameterEntity.ParameterTitle = tbxParameterTitle.Text;
                        indicatorParameterEntity.Interval = cbxInterval.Text;
                        indicatorParameterEntity.Period = tbxPeriod.Text == "" ? 0 : Convert.ToInt32(tbxPeriod.Text);
                        indicatorParameterEntity.Multiplier = tbxMultiplier.Text == "" ? 0 : Convert.ToDecimal(tbxMultiplier.Text);
                        indicatorParameterEntity.KlineEndType = cbxKlineEndType.Text;
                        indicatorParameterEntity.Parameter1 = tbxParameter1.Text == "" ? 0 : Convert.ToDecimal(tbxParameter1.Text);
                        indicatorParameterEntity.Parameter2 = tbxParameter2.Text == "" ? 0 : Convert.ToDecimal(tbxParameter2.Text);
                        indicatorParameterEntity.Parameter3 = tbxParameter3.Text == "" ? 0 : Convert.ToDecimal(tbxParameter3.Text);
                        indicatorParameterEntity.Parameter4 = tbxParameter4.Text == "" ? 0 : Convert.ToDecimal(tbxParameter4.Text);
                        indicatorParameterEntity.Parameter5 = tbxParameter5.Text == "" ? 0 : Convert.ToDecimal(tbxParameter5.Text);

                        var result = await _indicatorParameterService.AddIndicatorParameter(indicatorParameterEntity);

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

                        var indicatorParameterEntity = (await _indicatorParameterService.GetIndicatorParameterEntityByIdAsync(Convert.ToInt32(lblIdNo.Text))).Data;
                        indicatorParameterEntity.IndicatorId = Convert.ToInt32(cbxIndicatorName.SelectedValue);
                        indicatorParameterEntity.ParameterTitle = tbxParameterTitle.Text;
                        indicatorParameterEntity.Interval = cbxInterval.Text;
                        indicatorParameterEntity.Period = tbxPeriod.Text == "" ? 0 : Convert.ToInt32(tbxPeriod.Text);
                        indicatorParameterEntity.Multiplier = tbxMultiplier.Text == "" ? 0 : Convert.ToDecimal(tbxMultiplier.Text);
                        indicatorParameterEntity.KlineEndType = cbxKlineEndType.Text;
                        indicatorParameterEntity.Parameter1 = tbxParameter1.Text == "" ? 0 : Convert.ToDecimal(tbxParameter1.Text);
                        indicatorParameterEntity.Parameter2 = tbxParameter2.Text == "" ? 0 : Convert.ToDecimal(tbxParameter2.Text);
                        indicatorParameterEntity.Parameter3 = tbxParameter3.Text == "" ? 0 : Convert.ToDecimal(tbxParameter3.Text);
                        indicatorParameterEntity.Parameter4 = tbxParameter4.Text == "" ? 0 : Convert.ToDecimal(tbxParameter4.Text);
                        indicatorParameterEntity.Parameter5 = tbxParameter5.Text == "" ? 0 : Convert.ToDecimal(tbxParameter5.Text);

                        var result = await _indicatorParameterService.UpdateIndicatorParameter(indicatorParameterEntity);

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
                LoadIndicatorParameterList();
            }
        }

        private void gvIndicatorParameters_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool inUse = Convert.ToBoolean(gvIndicatorParameters.GetRowCellValue(e.RowHandle, "InUse"));

            if (inUse == true)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }
    }
}
