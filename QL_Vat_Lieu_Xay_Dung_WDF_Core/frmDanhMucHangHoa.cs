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
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmDanhMucHangHoa : DevExpress.XtraEditors.XtraForm
    {
        #region Declare Variable
        private readonly IProductCategoryService _productCategoryService;
        private ProductCategoryViewModel productCategory;

        #endregion Declare Variable

        public frmDanhMucHangHoa(IProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
        }
        #region Load Data

        private void loadCbDanhMucCha()
        {
            cbDanhMucCha.DataSource = _productCategoryService.GetAll();
            cbDanhMucCha.DisplayMember = "Name";
            cbDanhMucCha.ValueMember = "Id";
        }
        private void loadGvDanhMucHangHoa()
        {

            datagv_DanhMuc.DataSource = _productCategoryService.GetAll(); 
            gv_DanhMuc.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_DanhMuc.Columns["Id"].OptionsColumn.ReadOnly = true;

        }

        #endregion Load Data
        #region Method
        private bool isValid()
        {
            if (String.IsNullOrEmpty(txtTenDanhMuc.Text.Trim()))
                return false;
            return true;
        }
        private void reStart()
        {
            foreach (Control ct in panel1.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                  ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Text = String.Empty;
            }
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
        private void update_Edit()
        {
            txtTenDanhMuc.Text = productCategory.Name;
            cbDanhMucCha.SelectedValue = productCategory.ParentId;
            chkTrangThai.Checked = productCategory.Status == Status.Active ? true : false;
            //Load hinh anh o day
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
            productCategory.Name = txtTenDanhMuc.Text.Trim();
            productCategory.ParentId = int.Parse(cbDanhMucCha.SelectedValue.ToString());
            productCategory.Status = chkTrangThai.Checked ? Status.Active : Status.InActive;
            productCategory.Image = "";   // Load anh
        }


        #endregion Method

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Text = btnThem.Text.Equals("Tạo mới danh mục") ? "Lưu" : "Tạo mới danh mục";
            if (btnThem.Text.Equals("Tạo mới danh mục")) // An nut them lan 2
            {
                if (!isValid())
                {
                    MessageBox.Show("Bạn phải nhập vào tên danh mục !!!");
                    btnThem.Text = "Lưu";
                    return;
                }
                //Code
                GenericResult rs = _productCategoryService.Add(new ProductCategoryViewModel()
                {
                    Name = txtTenDanhMuc.Text.Trim(),
                    ParentId = int.Parse(cbDanhMucCha.SelectedValue.ToString()),
                    Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                    Image = "" /// Load Image
                });
                FormHelper.showDialog(rs);
                //End Code
                loadGvDanhMucHangHoa();
                update_Edit();
                datagv_DanhMuc.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut them
            {
                saveStament();
                setBtnBack_True();
                reStart();
                datagv_DanhMuc.Enabled = false;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Text = btnSua.Text.Equals("Chỉnh sửa hàng hoá") ? "Cập nhật" : "Chỉnh sửa hàng hoá";
            if (btnSua.Text.Equals("Chỉnh sửa hàng hoá")) // An nut sửa lan 2
            {
                //Code
                GenericResult rs = _productCategoryService.Update(new ProductCategoryViewModel()
                {
                    Name = txtTenDanhMuc.Text.Trim(),
                    ParentId = int.Parse(cbDanhMucCha.SelectedValue.ToString()),
                    Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                    Image = "" /// Load Image
                });
                FormHelper.showDialog(rs);
                //End Code 
                loadGvDanhMucHangHoa();
                reStart();
                datagv_DanhMuc.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut sửa
            {
                saveStament();
                setBtnBack_True();
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                datagv_DanhMuc.Enabled = false;

            }
            update_Edit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gv_DanhMuc.GetRowCellValue(gv_DanhMuc.GetSelectedRows()[0], "Id").ToString();
            if (FormHelper.showRemoveDialog(id) == DialogResult.No)
                return;
            GenericResult rs = _productCategoryService.Delete(int.Parse(id));
            FormHelper.showDialog(rs);
            loadGvDanhMucHangHoa();
            reStart();
        }

        private void frmDanhMucHangHoa_Load(object sender, EventArgs e)
        {
            loadCbDanhMucCha();
            loadGvDanhMucHangHoa();
            gv_DanhMuc.SelectRow(0);
            reStart();
            setBtnBack_False();
        }

        private void gv_DanhMuc_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            productCategory.Id = int.Parse(gv_DanhMuc.GetRowCellValue(e.RowHandle, "Id").ToString());
            productCategory.Name = gv_DanhMuc.GetRowCellValue(e.RowHandle, "Name").ToString();
            productCategory.ParentId = int.Parse(gv_DanhMuc.GetRowCellValue(e.RowHandle, "ParentId").ToString());
            productCategory.Status = gv_DanhMuc.GetRowCellValue(e.RowHandle, "Status").ToString() == "Active" ? Status.Active : Status.InActive;
            productCategory.Image = gv_DanhMuc.GetRowCellValue(e.RowHandle, "Image").ToString(); // Load image

            update_Edit();

            btnSua.Enabled = btnXoa.Enabled = true;
        }

        private void ptrHinhAnh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBack.Text.Equals(""))
            {
                btnBack.Enabled = false;
                btnSua.Text = "Chỉnh sửa danh mục";
                btnThem.Text = "Tạo mới danh mục";
                update_Edit();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                datagv_DanhMuc.Enabled = true;
                txtTenDanhMuc.Focus();
            }
        }

        private void gv_DanhMuc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult rs = _productCategoryService.Update(new ProductCategoryViewModel()
            {
                Name = txtTenDanhMuc.Text.Trim(),
                ParentId = int.Parse(cbDanhMucCha.SelectedValue.ToString()),
                Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                Image = "" /// Load Image
            });
            FormHelper.showDialog(rs);
            gv_DanhMuc.SelectRow(rowIndex);
        }
    }
}