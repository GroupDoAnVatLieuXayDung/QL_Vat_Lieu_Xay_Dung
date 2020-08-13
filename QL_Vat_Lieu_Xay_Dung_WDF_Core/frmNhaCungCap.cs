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
using DevExpress.Mvvm.Native;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        #region Declare Variable
        private readonly ISupplierService _supplierService;

        private SupplierViewModel nhaCungCap;
        #endregion Declare Variable
        public frmNhaCungCap(ISupplierService supplierService)
        {
            InitializeComponent();
            _supplierService = supplierService;
            nhaCungCap = new SupplierViewModel();
        }
        #region Load Data

        private void loadGvNhaCungCap()
        {
            gv_NhaCC.DataSource = _supplierService.GetAll();
            grid_NhaCC.Columns["Id"].OptionsColumn.AllowEdit = false;
            grid_NhaCC.Columns["Id"].OptionsColumn.ReadOnly = true;

        }

        #endregion Load Data
        #region Method
        private bool isValid()
        {
            if (String.IsNullOrEmpty(txtTen.Text.Trim()) || String.IsNullOrEmpty(txtSoDT.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()))
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
            txtTen.Text = nhaCungCap.FullName;
            txtDiaChi.Text = nhaCungCap.Address;
            txtSoDT.Text = nhaCungCap.PhoneNumber;
            chkTrangThai.Checked = nhaCungCap.Status == Status.InActive ? false : true;
        }
        private void setBtnBack_True()
        {
            btnBack.Text = "Huỷ";
            btnBack.Visible = true;
            btnBack.Visible = true;
        }
        private void setBtnBack_False()
        {
            btnBack.Visible = false;
            btnBack.Text = "";
            btnBack.Visible = false;
        }
        private void saveStament()
        {
            nhaCungCap.FullName = txtTen.Text;
            nhaCungCap.Address = txtDiaChi.Text;
            nhaCungCap.PhoneNumber = txtSoDT.Text;
            nhaCungCap.Status = chkTrangThai.Checked ? Status.Active : Status.InActive;
        }
        private void setEdit_True()
        {
            foreach (Control ct in panel1.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                  ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = true;
            }
        }
        private void setEdit_False()
        {
            foreach (Control ct in panel1.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                  ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = false;
            }
        }

        #endregion Method
        private void frmKhachHang_NCC_Load(object sender, EventArgs e)
        {
            loadGvNhaCungCap();
            grid_NhaCC.SelectRow(0);
            reStart();
            setBtnBack_False();
            setEdit_False();
        }

        private void frmKhachHang_NCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Text = btnThem.Text.Equals("Thêm nhà cung cấp") ? "Lưu" : "Thêm nhà cung cấp";
            if (btnThem.Text.Equals("Thêm nhà cung cấp")) // An nut them lan 2
            {
                if (!isValid())
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin !!!");
                    btnThem.Text = "Lưu";
                    return;
                }
                //Code
                GenericResult rs = _supplierService.Add(new SupplierViewModel()
                {
                    FullName = txtTen.Text.Trim(),
                    Address = txtDiaChi.Text.Trim(),
                    DateCreated = DateTime.Now,
                    PhoneNumber = txtSoDT.Text.Trim(),
                    Status = chkTrangThai.Checked == true ? Status.Active : Status.InActive
                });
                _supplierService.Save();
                if (rs.Success)
                    FormHelper.showSuccessDialog(rs.Message, rs.Caption);
                else
                    FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
                //End Code
                loadGvNhaCungCap();
                update_Edit();
                gv_NhaCC.Enabled = true;
                setBtnBack_False();
                setEdit_False();
            }
            else //Vua nhan nut them
            {
                setEdit_True();
                saveStament();
                setBtnBack_True();
                reStart();
                gv_NhaCC.Enabled = false;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Text = btnSua.Text.Equals("Sửa thông tin nhà cung cấp") ? "Cập nhật" : "Sửa thông tin nhà cung cấp";
            if (btnSua.Text.Equals("Sửa thông tin nhà cung cấp")) // An nut sửa lan 2
            {
                //Code
                GenericResult rs = _supplierService.Update(new SupplierViewModel()
                {
                    Id = int.Parse(grid_NhaCC.GetRowCellValue(grid_NhaCC.GetSelectedRows()[0], "Id").ToString()),
                    FullName = txtTen.Text.Trim(),
                    Address = txtDiaChi.Text.Trim(),
                    PhoneNumber = txtSoDT.Text.Trim(),
                    Status = chkTrangThai.Checked == true ? Status.Active : Status.InActive
                });
                _supplierService.Save();
                if (rs.Success)
                    FormHelper.showSuccessDialog(rs.Message, rs.Caption);
                else
                    FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
                //End Code 
                loadGvNhaCungCap();
                reStart();
                gv_NhaCC.Enabled = true;
                setBtnBack_False();
                setEdit_False();
            }
            else //Vua nhan nut sửa
            {
                setEdit_True();
                saveStament();
                setBtnBack_True();
                btnSua.Enabled = true;
                btnXoa.Enabled = btnThem.Enabled = false;
                gv_NhaCC.Enabled = false;

            }
            update_Edit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = grid_NhaCC.GetRowCellValue(grid_NhaCC.GetSelectedRows()[0], "Id").ToString();
            if (FormHelper.showRemoveDialog("nhà cung cấo có mã là " + id) == DialogResult.No)
                return;
            GenericResult rs = _supplierService.Delete(int.Parse(id));
            _supplierService.Save();
            if (rs.Success)
                FormHelper.showSuccessDialog(rs.Message, rs.Caption);
            else
                FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
            loadGvNhaCungCap();
            reStart();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBack.Text.Equals(""))
            {
                btnBack.Enabled = false;
                btnBack.Visible = false;
                btnSua.Text = "Sửa thông tin nhà cung cấp";
                btnThem.Text = "Thêm nhà cung cấp";
                update_Edit();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                gv_NhaCC.Enabled = true;
                txtTen.Focus();
            }
        }

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrangThai.Checked)
                chkTrangThai.Text = "Ngưng hoạt động";
            else
                chkTrangThai.Text = "Hoạt động";
        }

        private void grid_Khach_NV_NhaCC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult rs = _supplierService.Update(new SupplierViewModel()
            {
                Id = int.Parse(grid_NhaCC.GetRowCellValue(grid_NhaCC.GetSelectedRows()[0], "Id").ToString()),
                FullName = txtTen.Text.Trim(),
                Address = txtDiaChi.Text.Trim(),
                PhoneNumber = txtSoDT.Text.Trim(),
                Status = chkTrangThai.Checked == true ? Status.Active : Status.InActive
            });
            _supplierService.Save();
            if (rs.Success)
                FormHelper.showSuccessDialog(rs.Message, rs.Caption);
            else
                FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
            grid_NhaCC.SelectRow(rowIndex);
        }

        private void grid_Khach_NV_NhaCC_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            nhaCungCap.FullName = grid_NhaCC.GetRowCellValue(e.RowHandle, "FullName").ToString();
            nhaCungCap.Address = grid_NhaCC.GetRowCellValue(e.RowHandle, "Address").ToString();
            nhaCungCap.PhoneNumber = grid_NhaCC.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString();
            nhaCungCap.Status = grid_NhaCC.GetRowCellValue(e.RowHandle, "Status").ToString() == "Active" ? Status.Active : Status.InActive;


            update_Edit();

            btnSua.Enabled = btnXoa.Enabled = true;
        }
    }
}