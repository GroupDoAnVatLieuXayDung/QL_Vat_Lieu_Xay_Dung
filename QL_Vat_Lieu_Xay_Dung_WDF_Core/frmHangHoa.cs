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
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmHangHoa : DevExpress.XtraEditors.XtraForm
    {
        #region Declare Variable
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private ProductViewModel product;

        #endregion Declare Variable
        public frmHangHoa(IProductService productService,IProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productService = productService;
            _productCategoryService = productCategoryService;
        }
        #region Load Data

        private void loadCbDanhMuc()
        {
            cbMaDanhMuc.DataSource = _productCategoryService.GetAll();
            cbMaDanhMuc.DisplayMember = "Name";
            cbMaDanhMuc.ValueMember = "Id";
        }
        private void loadGvHangHoa()
        {
            datagv_HangHoa.DataSource = _productService.GetAll();
            gv_HangHoa.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_HangHoa.Columns["Id"].OptionsColumn.ReadOnly = true;

        }

        #endregion Load Data
        #region Method
        private bool isValid()
        {
            if (String.IsNullOrEmpty(txtTenHangHoa.Text.Trim()) || String.IsNullOrEmpty(cbMaDanhMuc.Text.Trim()) 
                || String.IsNullOrEmpty(txtDonGia.Text.Trim()) || String.IsNullOrEmpty(txtDonViTinh.Text.Trim()) )
                return false;
            return true;
        }
        private void reStart()
        {
            foreach (Control ct in panel1.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                  ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox) )
                    ct.Text = String.Empty;
            }
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
        private void update_Edit()
        {
            txtTenHangHoa.Text = product.Name;
            cbMaDanhMuc.SelectedValue = product.CategoryId;
            chkTrangThai.Checked = product.Status == Status.Active ? true : false ;
            //Load hinh anh o day
            txtDonGia.Text = product.Price.ToString();
            txtDonViTinh.Text = product.Unit;
            txtGiaKhuyenMai.Text = product.PromotionPrice.ToString();
            txtMoTa.Text = product.Description;
            txtNoiDung.Text = product.Content;
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
            product.Name = txtTenHangHoa.Text.Trim();
            product.CategoryId = int.Parse(cbMaDanhMuc.SelectedValue.ToString());
            product.Status = chkTrangThai.Checked ? Status.Active : Status.InActive ;

            product.Image = "";   // Load anh

            product.Price = int.Parse(txtDonGia.Text.Trim());
            product.Unit = txtDonViTinh.Text.Trim();
            product.PromotionPrice = int.Parse(txtGiaKhuyenMai.Text.Trim());
            product.Description = txtMoTa.Text.Trim();
            product.Content = txtNoiDung.Text.Trim();
            
        }


        #endregion Method

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            loadCbDanhMuc();
            loadGvHangHoa();
            gv_HangHoa.SelectRow(0);
            reStart();
            setBtnBack_False();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Text = btnThem.Text.Equals("Tạo mới hàng hoá") ? "Lưu" : "Tạo mới hàng hoá";
            if (btnThem.Text.Equals("Tạo mới hàng hoá")) // An nut them lan 2
            {
                if (!isValid())
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin !!!");
                    btnThem.Text = "Lưu";
                    return;
                }
                //Code
                GenericResult rs = _productService.Add(new ProductViewModel()
                {
                    Name = txtTenHangHoa.Text.Trim(),
                    CategoryId = int.Parse(cbMaDanhMuc.SelectedValue.ToString()),
                    Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                    Image = "", /// Load Image
                    Price = int.Parse(txtDonGia.Text.Trim()),
                    Unit = txtDonViTinh.Text.Trim(),
                    PromotionPrice = int.Parse(txtGiaKhuyenMai.Text.Trim()),
                    Description = txtMoTa.Text.Trim(),
                    Content = txtNoiDung.Text.Trim()
                }); 
                FormHelper.showDialog(rs);
                //End Code
                loadGvHangHoa();
                update_Edit();
                datagv_HangHoa.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut them
            {
                saveStament();
                setBtnBack_True();
                reStart();
                datagv_HangHoa.Enabled = false;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Text = btnSua.Text.Equals("Chỉnh sửa hàng hoá") ? "Cập nhật" : "Chỉnh sửa hàng hoá" ;
            if (btnSua.Text.Equals("Chỉnh sửa hàng hoá")) // An nut sửa lan 2
            {
                //Code
                GenericResult rs = _productService.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = txtTenHangHoa.Text.Trim(),
                    CategoryId = int.Parse(cbMaDanhMuc.SelectedValue.ToString()),
                    Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                    Image = "", /// Load Image
                    Price = int.Parse(txtDonGia.Text.Trim()),
                    Unit = txtDonViTinh.Text.Trim(),
                    PromotionPrice = int.Parse(txtGiaKhuyenMai.Text.Trim()),
                    Description = txtMoTa.Text.Trim(),
                    Content = txtNoiDung.Text.Trim()
                });
                FormHelper.showDialog(rs);
                //End Code 
                loadGvHangHoa();
                reStart();
                datagv_HangHoa.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut sửa
            {
                saveStament();
                setBtnBack_True();
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                datagv_HangHoa.Enabled = false;

            }
            update_Edit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gv_HangHoa.GetRowCellValue(gv_HangHoa.GetSelectedRows()[0], "Id").ToString();
            if (FormHelper.showRemoveDialog(id) == DialogResult.No)
                return;
            GenericResult rs = _productService.Delete(int.Parse(id));
            FormHelper.showDialog(rs);
            loadGvHangHoa();
            reStart();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)  //Su kien click button Back
        {
            btnBack.Text = btnBack.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBack.Text.Equals(""))
            {
                btnBack.Enabled = false;
                btnSua.Text = "Chỉnh sửa hàng hoá";
                btnThem.Text = "Tạo mới hàng hoá" ;
                update_Edit();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                datagv_HangHoa.Enabled = true;
                txtTenHangHoa.Focus();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //gv_HangHoa.EditingValue = repositoryItemTextEdit1;
        }

        private void datagv_HangHoa_Click(object sender, EventArgs e)
        {

        }

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ptrImage_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void gv_HangHoa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult rs = _productService.Add(new ProductViewModel()
            {
                Id = product.Id,
                Name = txtTenHangHoa.Text.Trim(),
                CategoryId = int.Parse(cbMaDanhMuc.SelectedValue.ToString()),
                Status = chkTrangThai.Checked ? Status.Active : Status.InActive,
                Image = "", /// Load Image
                Price = int.Parse(txtDonGia.Text.Trim()),
                Unit = txtDonViTinh.Text.Trim(),
                PromotionPrice = int.Parse(txtGiaKhuyenMai.Text.Trim()),
                Description = txtMoTa.Text.Trim(),
                Content = txtNoiDung.Text.Trim()
            });
            FormHelper.showDialog(rs);
            gv_HangHoa.SelectRow(rowIndex);
        }

        private void gv_HangHoa_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            product.Id = int.Parse(gv_HangHoa.GetRowCellValue(e.RowHandle, "Id").ToString());
            product.Name = gv_HangHoa.GetRowCellValue(e.RowHandle, "FullName").ToString();
            product.CategoryId = int.Parse(gv_HangHoa.GetRowCellValue(e.RowHandle, "Address").ToString());
            product.Status = gv_HangHoa.GetRowCellValue(e.RowHandle, "Status").ToString() == "Active" ? Status.Active : Status.InActive;
            product.Image = gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString(); // Load image
            product.Price = int.Parse(gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString());
            product.Unit = gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString(); ;
            product.PromotionPrice = int.Parse(gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString());
            product.Description = gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString();
            product.Content = gv_HangHoa.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString(); 

            update_Edit();

            btnSua.Enabled = btnXoa.Enabled = true;
        }
    }
}