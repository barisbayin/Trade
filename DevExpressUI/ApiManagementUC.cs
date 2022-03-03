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
using Business.DependencyResolvers;
using Business.Abstract;
using Business.Concrete;
using Core.Costants.Messages;
using Entity.Concrete.Entities;

namespace DevExpressUI
{
    public partial class ApiManagementUC : DevExpress.XtraEditors.XtraUserControl
    {
        public ApiManagementUC()
        {
            InitializeComponent();
            _apiInformationService = AutofacInstanceFactory.GetInstance<IApiInformationService>();

        }

        private readonly IApiInformationService _apiInformationService;
        private static ApiManagementUC _apiManagementUc;
        public static ApiManagementUC Instance
        {

            get
            {
                if (_apiManagementUc == null)
                    _apiManagementUc = new ApiManagementUC();
                return _apiManagementUc;
            }
        }


        private void ApiManagementUC_Load(object sender, EventArgs e)
        {
            LoadApiList();
            ClearAll();
            lblResult.ForeColor = Color.DarkRed;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private async void LoadApiList()
        {
            if (chckShowDeleted.CheckState == CheckState.Unchecked)
            {
                var result = (await _apiInformationService.GetAllNotRemovedApiInformation()).Data;
                gridApiList.DataSource = result;

            }
            else
            {
                var result = (await _apiInformationService.GetAllApiInformation()).Data;
                gridApiList.DataSource = result;
            }
        }

        private void ClearAll()
        {
            lblIdNo.Text = "";
            cbxExchange.Text = "";
            tbxApiTitle.Text = "";
            tbxApiKey.Text = "";
            tbxSecretKey.Text = "";
            lblCreationDate.Text = "";

        }

        private void gvApiList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvApiList.RowCount > 0)
            {
                lblIdNo.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[0]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[0]).ToString();
                cbxExchange.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[1]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[1]).ToString();
                tbxApiTitle.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[2]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[2]).ToString();
                tbxApiKey.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[3]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[3]).ToString();
                tbxSecretKey.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[4]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[4]).ToString();
                lblCreationDate.Text = gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[5]) == null ? "" : gvApiList.GetRowCellValue(gvApiList.FocusedRowHandle, gvApiList.Columns[5]).ToString();
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
                var isAlreadyRemoved = (await _apiInformationService.GetApiInformationById(id)).Data.IsRemoved;

                if (isAlreadyRemoved)
                {
                    ClearAll();
                    LoadApiList();
                    lblResult.Text = "Id:" + id.ToString() + " " + CommonMessages.IsAlreadyRemoved;
                }
                else
                {
                    var result = await _apiInformationService.DeleteApiInformationById(id);

                    if (result.Success)
                    {
                        ClearAll();
                        LoadApiList();
                        lblResult.Text = "Id:" + id.ToString() + " " + result.Message;
                    }
                    else
                    {
                        lblResult.Text = CommonMessages.Error;
                    }
                }
            }
            catch (Exception exception)
            {
                lblResult.Text = CommonMessages.ChooseItem;
            }
            

        }

        private void chckShowDeleted_Properties_CheckStateChanged(object sender, EventArgs e)
        {
            LoadApiList();
        }

        private void gvApiList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isRemoved = Convert.ToBoolean(gvApiList.GetRowCellValue(e.RowHandle, "IsRemoved"));

            if (isRemoved == true)
            {
                e.Appearance.BackColor = Color.DarkRed;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ApiInformationEntity apiInformationEntity = new ApiInformationEntity();
            if (cbxExchange.Text == "" || tbxApiTitle.Text == "" || tbxApiKey.Text == "" || tbxSecretKey.Text == "")
            {
                lblResult.Text = CommonMessages.EnterAllRequiredParameters;
            }
            else
            {
                try
                {
                    if (lblIdNo.Text == "")
                    {
                        apiInformationEntity.Exchange = cbxExchange.Text;
                        apiInformationEntity.ApiTitle = tbxApiTitle.Text;
                        apiInformationEntity.ApiKey = tbxApiKey.Text;
                        apiInformationEntity.SecretKey = tbxSecretKey.Text;
                        var result = await _apiInformationService.AddApiInformation(apiInformationEntity);
                        if (result.Success)
                        {
                            lblResult.Text = "New Api " + result.Message;
                            
                        }
                        else
                        {
                            lblResult.Text = result.Message;
                        }
                    }

                    if (lblIdNo.Text != "")
                    {
                        apiInformationEntity.Id = Convert.ToInt32(lblIdNo.Text);
                        apiInformationEntity.Exchange = cbxExchange.Text;
                        apiInformationEntity.ApiTitle = tbxApiTitle.Text;
                        apiInformationEntity.ApiKey = tbxApiKey.Text;
                        apiInformationEntity.SecretKey = tbxSecretKey.Text;
                        var result = await _apiInformationService.UpdateApiInformationById(apiInformationEntity);

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
                LoadApiList();
            }
        }
    }
}
