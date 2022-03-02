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

namespace DevExpressUI
{
    public partial class IndicatorParametersUC : DevExpress.XtraEditors.XtraUserControl
    {
        public IndicatorParametersUC()
        {
            InitializeComponent();
            _indicatorParameterService = AutofacInstanceFactory.GetInstance<IIndicatorParameterService>();
        }

        private readonly IIndicatorParameterService _indicatorParameterService;

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
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }

        private void LoadIndicatorParameterList()
        {
            var result = _indicatorParameterService.GetIndicatorParameterDetails();
            gridIndicatorParameters.DataSource = result.Data;
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void gvIndicatorParameters_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvIndicatorParameters.RowCount > 0)
            {
                lblIdNo.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[0]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[0]).ToString();
                cbxIndicatorName.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[1]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[1]).ToString();
                tbxParameterTitle.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[2]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[2]).ToString();
                cbxInterval.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[3]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[3]).ToString();
                tbxPeriod.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[4]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[4]).ToString();
                tbxMultiplier.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[5]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[5]).ToString();
                cbxKlineEndType.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[6]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[6]).ToString();
                tbxParameter1.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[7]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[7]).ToString();
                tbxParameter2.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[8]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[8]).ToString();
                tbxParameter3.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[9]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[9]).ToString();
                tbxParameter4.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[10]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[10]).ToString();
                tbxParameter5.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[11]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[11]).ToString();
                lblInUse.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[12]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[12]).ToString();
                lblCreationDate.Text = gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[13]) == null ? "" : gvIndicatorParameters.GetRowCellValue(gvIndicatorParameters.FocusedRowHandle, gvIndicatorParameters.Columns[13]).ToString();

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

                if (result.Success)
                {
                    ClearAll();
                    LoadIndicatorParameterList();
                    lblResult.Text = "Id:" + id + " " + result.Message;
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
    }
}
