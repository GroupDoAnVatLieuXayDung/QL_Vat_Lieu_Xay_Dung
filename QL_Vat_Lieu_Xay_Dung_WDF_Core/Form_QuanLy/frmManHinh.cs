using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet.Functions;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using DevExpress.XtraGrid.Columns;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using DevExpress.XtraSpreadsheet.Model;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmManHinh : DevExpress.XtraEditors.XtraForm
    {

        #region Declare Variable
        private readonly IFunctionService _functionService;
        
        private string pId,pName, pURL, pParentId;
        private string pIconCSS, pStatus,pSortOder;
        #endregion Declare Variable

        public frmManHinh(IFunctionService functionService)
        {
            InitializeComponent();
            _functionService = functionService;
        }
        #region Load Data

        private void loadCbParentId()
        {
            //  List<FunctionViewModel> funs = _functionService.GetAll_List();
            List<FunctionViewModel> funs = _functionService.GetAll_List();
            cbManHinhCha.DataSource = funs;
            cbManHinhCha.DisplayMember = "Name";
            cbManHinhCha.ValueMember = "Id";
        }

        private void loadGvFunction()
        {
            datagv_ManHinh.DataSource = _functionService.GetAll_List();
            gv_ManHinh.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_ManHinh.Columns["Id"].OptionsColumn.ReadOnly = true;
            //foreach(GridColumn gc in gv_ManHinh.Columns)
            //{
            //    gc.OptionsColumn.AllowEdit = true;
            //    if(gc.FieldName.Equals("Id"))
            //    {
            //        gc.OptionsColumn.AllowEdit = false;
            //        gc.OptionsColumn.ReadOnly = true;
            //    }
            //}
        }

        #endregion Load Data
        #region Method
        private bool isValid()
        {
            if (String.IsNullOrEmpty(txtTenManHinh.Text.Trim()) || String.IsNullOrEmpty(txtURL_.Text.Trim()))
                return false;
            return true;
        }
        private void reStart()
        {
            foreach (Control ct in panel2.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                  ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit))
                    ct.Text = String.Empty;
            }
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
        private void update_Edit()
        {
            txtMaManHinh.Text = pId;
            txtTenManHinh.Text = pName;
            txtURL_.Text = pURL;
            txtIconCSS.Text = pIconCSS;
            txtSortOrder.Text = pSortOder;
            cbManHinhCha.SelectedValue = pParentId;
            toggleSwitchHoatDong.IsOn =  pStatus.Equals("on") ?  true : false ;

        }
        private void setBtnBack_True()
        {
            btnBack.Text = "Huỷ";
            btnBack.Visible = true;
        }
        private void setBtnBack_False()
        {
            btnBack.Visible = false;
            btnBack.Text = "";
        }
        private void saveStament()
        {
            pId = txtMaManHinh.Text.Trim();
            pName = txtTenManHinh.Text.Trim();
            pURL = txtURL_.Text.Trim();
            pIconCSS = txtIconCSS.Text.Trim();
            pSortOder = txtSortOrder.Text.Trim();
            pParentId = cbManHinhCha.SelectedValue.ToString();
            pStatus = toggleSwitchHoatDong.IsOn ? "on" : "off";
        }


        #endregion Method

        private void frmManHinh_Load(object sender, EventArgs e)
        {
            loadCbParentId();
            loadGvFunction();
            gv_ManHinh.SelectRow(0);
            reStart();
            setBtnBack_False();
            txtMaManHinh.Enabled = false;
            txtMaManHinh.ReadOnly = true;
        }

        private void frmManHinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBack.Text.Equals(""))
            {
                btnBack.Enabled = false;
                btnSua.Text = "Chỉnh sửa màn hình";
                btnThem.Text = "Tạo mới màn hình";
                update_Edit();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                datagv_ManHinh.Enabled = true;
                txtMaManHinh.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Text = btnThem.Text.Equals("Tạo mới màn hình") ? "Lưu" : "Tạo mới màn hình";
            if (btnThem.Text.Equals("Tạo mới màn hình")) // An nut them lan 2
            {
                if (!isValid())
                {
                    MessageBox.Show("Ban phai nhap day du thông tin !");
                    btnThem.Text = "Lưu";
                    return;
                }
                //Code
                GenericResult rs = _functionService.Add(new FunctionViewModel()
                {
                    Name = pName,
                    URL = pURL,
                    ParentId = pParentId,
                    IconCss = pIconCSS,
                    SortOrder = int.Parse(pSortOder),
                    Status = pStatus.Equals("on") ? Status.Active : Status.InActive
                });
                FormHelper.showDialog(rs);
                //End Code
                loadGvFunction();
                update_Edit();
                datagv_ManHinh.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut them
            {
                saveStament();
                setBtnBack_True();
                reStart();
                datagv_ManHinh.Enabled = false;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Text = btnSua.Text.Equals("Chỉnh sửa màn hình") ? "Cập nhật" : "Chỉnh sửa màn hình";
            if (btnSua.Text.Equals("Chỉnh sửa màn hình")) // An nut sửa lan 2
            {
                //Code
                GenericResult rs = _functionService.Update(new FunctionViewModel()
                {
                    Id = pId,
                    Name = pName,
                    URL = pURL,
                    ParentId = pParentId,
                    IconCss = pIconCSS,
                    SortOrder = int.Parse(pSortOder),
                    Status = pStatus.Equals("on") ? Status.Active : Status.InActive
                });
                FormHelper.showDialog(rs);
                //End Code 
                loadGvFunction();
                reStart();
                datagv_ManHinh.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut sửa
            {
                saveStament();
                setBtnBack_True();
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                datagv_ManHinh.Enabled = false;

            }
            update_Edit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gv_ManHinh.GetRowCellValue(gv_ManHinh.GetSelectedRows()[0], "Id").ToString();
            if (FormHelper.showRemoveDialog(id) == DialogResult.No)
                return;
            GenericResult rs = _functionService.Delete(id);
            FormHelper.showDialog(rs);
            loadGvFunction();
            reStart();
        }
        private void gv_ManHinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult rs = _functionService.Update(new FunctionViewModel()
            {
                Id = pId,
                Name = pName,
                URL = pURL,
                ParentId = pParentId,
                IconCss = pIconCSS,
                SortOrder = int.Parse(pSortOder),
                Status = pStatus.Equals("on") ? Status.Active : Status.InActive
            });
            FormHelper.showDialog(rs);
            gv_ManHinh.SelectRow(rowIndex);
        }

        private void gv_ManHinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            pId = gv_ManHinh.GetRowCellValue(e.RowHandle, "Id").ToString();
            pName = gv_ManHinh.GetRowCellValue(e.RowHandle, "Name").ToString();
            pURL = gv_ManHinh.GetRowCellValue(e.RowHandle, "URL").ToString();
            pIconCSS = gv_ManHinh.GetRowCellValue(e.RowHandle, "IconCss").ToString();
            pSortOder = gv_ManHinh.GetRowCellValue(e.RowHandle, "SortOrder").ToString();
            pParentId = gv_ManHinh.GetRowCellValue(e.RowHandle, "ParentId") != null ? gv_ManHinh.GetRowCellValue(e.RowHandle, "ParentId").ToString() : "";

            cbManHinhCha.SelectedValue = pParentId;
            txtMaManHinh.Text = pId;
            txtTenManHinh.Text = pName;
            txtURL_.Text = pURL;
            txtIconCSS.Text = pIconCSS;
            txtSortOrder.Text = pSortOder;

            btnSua.Enabled = btnXoa.Enabled = true;
        }
    }
}