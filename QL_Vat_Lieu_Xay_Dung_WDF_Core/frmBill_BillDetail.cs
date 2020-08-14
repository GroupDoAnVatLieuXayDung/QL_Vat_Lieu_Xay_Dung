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
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Enum;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.Implementation;
using QL_Vat_Lieu_Xay_Dung_Utilities.Helpers;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmBill_BillDetailt : DevExpress.XtraEditors.XtraForm
    {
        #region Declare

        private readonly IBillService _billService;
        private readonly IProductService _productService;
        private BillViewModel _bill,_billTemp = null ;
        private ProductViewModel _product;
        private List<BillDetailViewModel> _billDetailList;
        private BillDetailViewModel _billDetail;


        #endregion Declare
        public frmBill_BillDetailt(IBillService billService, IProductService productService)
        {
            InitializeComponent();
            _billService = billService;
            _productService = productService;
            _bill = new BillViewModel();
            _product = new ProductViewModel();
            _billDetail = new BillDetailViewModel();
            _billDetailList = new List<BillDetailViewModel>();
        }
        #region Load Data

        private void LoadCbPhuongThucThanhToan()
        {
            var enums = ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                     .Select(c => new EnumModel()
                     {
                         Value = (int)c,
                         Name = c.GetDescription()
                     }).ToList();
            foreach (EnumModel em in enums)
            {
                cbPhuongThucThanhToan.Properties.Items.Add(em.Name);
            }
        }
        private void LoadCbTrangThai()
        {
            var enums = ((BillStatus[])Enum.GetValues(typeof(BillStatus)))
             .Select(c => new EnumModel()
             {
                 Value = (int)c,
                 Name = c.GetDescription()
             }).ToList();
            foreach (EnumModel em in enums)
            {
                cbTrangThai.Properties.Items.Add(em.Name);
            }
        }
        private void LoadCbMaHd()
        {
            cbMaHD.DataSource = _billService.GetAllBill();
            cbMaHD.DisplayMember = "Id";
            cbMaHD.ValueMember = "Id";
        }
        private void LoadCbMaSp()
        {
            cbMaSP.DataSource = _productService.GetAll();
            cbMaSP.DisplayMember = "Name";
            cbMaSP.ValueMember = "Id";
        }

        private void LoadGvBill()
        {
            datagv_HoaDon.DataSource = _billService.GetAllBill();
            gv_HoaDon.Columns["Id"].OptionsColumn.ReadOnly = true;
            gv_HoaDon.Columns["Id"].OptionsColumn.AllowEdit = false;
        }
        private void LoadGvBillDetail(int id)
        {
            datagv_CTHoaDon.DataSource = _billService.GetBillDetails(id);
            gv_CTHoaDon.Columns["Id"].OptionsColumn.ReadOnly = true;
            gv_CTHoaDon.Columns["Id"].OptionsColumn.AllowEdit = false;
        }
        private void loadCbSize()
        {
            cbSize.DataSource = _billService.GetSizes();
            cbSize.DisplayMember = "Name";
            cbSize.ValueMember = "Id";
        }
        private void loadGvFormBillDetailList()
        {
            datagv_CTHoaDon.DataSource = null;
            datagv_CTHoaDon.DataSource = _billDetailList;
            gv_CTHoaDon.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_CTHoaDon.Columns["Id"].OptionsColumn.ReadOnly = true;
            decimal sum = 0;
            foreach(BillDetailViewModel b in _billDetailList)
            {
                sum += b.Quantity * b.Price;
            }
            txtTongTien.Text = sum.ToString();
            txtSoSanPham.Text = _billDetailList.Sum(b => b.Quantity).ToString();
            dateEditNgayTao.DateTime = DateTime.Now;
        }

        #endregion Load Data
        #region Bill method
        private bool isValid_Bill()
        {
            if (String.IsNullOrEmpty(txtTenKH.Text.Trim()) || String.IsNullOrEmpty(txtPhone.Text.Trim()) ||
                String.IsNullOrEmpty(cbTrangThai.Text.Trim()) || String.IsNullOrEmpty(cbPhuongThucThanhToan.Text.Trim()))
                return false;
            return true;
        }
        private void reStart_Bill()
        {
            foreach (Control ct in pnlEditHoaDon.Controls)
            {
                if(typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) || 
                    ct.GetType() == typeof(ComboBoxEdit)  || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                      ct.Text = String.Empty;
            }
            btnThemHD.Enabled = true;
            btnInHD.Enabled = false;
        }
        private void update_BillEdit()
        {
            txtTenKH.Text = _bill.CustomerName;
            txtPhone.Text = _bill.CustomerMobile;
            cbTrangThai.Text = _bill.BillStatus.ToString();
            cbPhuongThucThanhToan.Text = _bill.PaymentMethod.ToString();
            txtDiaChi.Text = _bill.CustomerAddress;
            txtGhiChu.Text = _bill.CustomerMessage;
            cbMaHD.SelectedValue = _bill.Id;
        }
        private void setBtnBackHD_True()
        {
            btnBackHD.Text = "Huỷ";
            btnBackHD.Visible = true;
            btnBackHD.Enabled = true;
        }
        private void setBtnBackHD_False()
        {
            btnBackHD.Visible = false;
            btnBackHD.Enabled = false;
            btnBackHD.Text = "";
        }
        private void saveStament_Bill()
        {
            _bill.CustomerName = txtTenKH.Text.Trim();
            _bill.CustomerMobile = txtPhone.Text.Trim();
            _bill.BillStatus = cbTrangThai.EditValue.ToString().GetValueFromDescription<BillStatus>(BillStatus.New);
            _bill.PaymentMethod = cbPhuongThucThanhToan.EditValue.ToString().GetValueFromDescription<PaymentMethod>(PaymentMethod.CashOnDelivery);
            _bill.CustomerAddress = txtDiaChi.Text.Trim();
            _bill.CustomerMessage = txtGhiChu.Text.Trim();
        }

        #endregion Bill method

        #region BillDetail method

        private bool isValid_BillDetail()
        {
            if (  String.IsNullOrEmpty(cbMaSP.Text.Trim()) ||
                String.IsNullOrEmpty(txtDonGia.Text) || String.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                return false;
            return true;
        }
        private void reStart_BillDetail()
        {
            foreach (Control ct in panel2.Controls)
            {
                if (typeof(TextBox) == ct.GetType()  || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Text = String.Empty;
            }
            btnThemCTHD.Enabled = true;
            btnSuaCTHD.Enabled = btnXoaCTHD.Enabled = false;
        }

        private void update_BillDetail_Edit()
        {
            cbSize.SelectedValue = _billDetail.SizeId;
            cbMaHD.Text = _billDetail.BillId.ToString();
            cbMaSP.SelectedValue = _billDetail.ProductId;
            txtDonGia.Text = _billDetail.Price.ToString();
            txtSoLuong.Text = _billDetail.Quantity.ToString();
        }
        private void setBtnBackCTHD_True()
        {
            btnBackCTHD.Text = "Huỷ";
            btnBackCTHD.Visible = true;
        }
        private void setBtnBackCTHD_False()
        {
            btnBackCTHD.Visible = false;
            btnBackCTHD.Text = "";
        }
        private void saveStament_BillDetail()
        {
            _billDetail.BillId = cbMaHD.Text.Trim() == "" ? (_billService.GetAllBill().Max(b => b.Id) + 1) : int.Parse(cbMaHD.Text.Trim());
            _billDetail.ProductId = cbMaSP.Text.Trim() == "" ?  1 : int.Parse(cbMaSP.SelectedValue.ToString());
            _billDetail.SizeId = cbSize.Text.Trim() == "" ? 1 : int.Parse(cbSize.SelectedValue.ToString());
            _billDetail.Quantity = txtSoLuong.Text.Trim() == "" ? 1 : int.Parse(txtSoLuong.Text.Trim());
            _billDetail.Price = txtDonGia.Text.Trim()  == "" ? 5000 : decimal.Parse(txtDonGia.Text.Trim());
        }

        #endregion BillDetail method
        private void setEdit_True()
        {
            foreach (Control ct in pnlEditHoaDon.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                    ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = true;
            }
            foreach (Control ct in panel2.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                    ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = true;
                cbMaHD.Enabled = false;
            }
        }
        private void setEdit_False()
        {
            foreach (Control ct in pnlEditHoaDon.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                    ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = false;
            }
            foreach (Control ct in panel2.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                    ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit) || ct.GetType() == typeof(NumberTextBox.NumberTextBox))
                    ct.Enabled = false;
            }
        }
        private void frmBill_BillDetailt_Load(object sender, EventArgs e)
        {
            LoadCbPhuongThucThanhToan();
            LoadCbMaHd();
            LoadCbTrangThai();
            LoadCbMaHd();
            LoadCbMaSp();
            loadCbSize();
            LoadGvBill();
            gv_HoaDon.SelectRow(0);
            reStart_Bill();
            reStart_BillDetail();
            setBtnBackCTHD_False();
            setBtnBackHD_False();
            setEdit_False();
            btnInHD.Enabled = true;
            cbMaHD.Enabled = false;
            btnHuyHoaDonTam.Enabled = false;
            btnHuyHoaDonTam.Visible = false;
        }

        private void frmBill_BillDetailt_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if(_billTemp != null)
            {
                MessageBox.Show("Có một hoá đơn tạm đang chờ xử lý, không thể tạo mới hoá đơn khác !");
                return;
            }    
            btnThemHD.Text = btnThemHD.Text.Equals("Tạo mới hoá đơn") ? "Lưu" : "Tạo mới hoá đơn";
            if (btnThemHD.Text.Equals("Tạo mới hoá đơn")) // An nut them lan 2
            {
                if (!isValid_Bill())
                {
                    MessageBox.Show("Ban phai nhap day du thông tin !");
                    btnThemHD.Text = "Lưu";
                    return;
                }
                _billTemp = new BillViewModel()
                {
                    Id = (_billService.GetAllBill().Max(b => b.Id) + 1),
                    CustomerName = txtTenKH.Text,
                    CustomerMobile = txtPhone.Text,
                    BillStatus = cbTrangThai.EditValue.ToString().GetValueFromDescription<BillStatus>(BillStatus.New),

                    PaymentMethod = cbPhuongThucThanhToan.EditValue.ToString().GetValueFromDescription<PaymentMethod>(PaymentMethod.CashOnDelivery),
                    CustomerAddress = txtDiaChi.Text,
                    CustomerMessage = txtGhiChu.Text
                };
                MessageBox.Show("Đã tạo hoá đơn tạm !");
                cbMaHD.Text = _billService.GetAllBill().Max(t => t.Id).ToString();
                btnHuyHoaDonTam.Enabled = true;
                btnHuyHoaDonTam.Visible = true;
                update_BillEdit();
                datagv_HoaDon.Enabled = btnInHD.Enabled = true;
                setBtnBackHD_False();
                setEdit_False();
            }
            else //Vua nhan nut them
            {
                setEdit_True();
                saveStament_Bill();
                setBtnBackHD_True();
                reStart_Bill();
                datagv_HoaDon.Enabled = false;

            }
        }

        private void btnBackHD_Click(object sender, EventArgs e)
        {
            btnBackHD.Text = btnBackHD.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBackHD.Text.Equals(""))
            {
                btnBackHD.Enabled = false;
                btnBackHD.Visible = false;
                btnThemHD.Text = "Tạo mới hoá đơn";
                update_BillEdit();
                btnInHD.Enabled = btnThemHD.Enabled = true;

                datagv_HoaDon.Enabled = true;
                txtTenKH.Focus();
                cbMaHD.Enabled = true;
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {

        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            btnThemCTHD.Text = btnThemCTHD.Text.Equals("Them CTHD") ? "Lưu" : "Them CTHD";
            if (btnThemCTHD.Text.Equals("Them CTHD")) // An nut them lan 2
            {
                if (!isValid_BillDetail())
                {
                    MessageBox.Show("Ban phai nhap day du thông tin !");
                    btnThemCTHD.Text = "Lưu";
                    return;
                }
                BillDetailViewModel bdt = new BillDetailViewModel()
                {
                    Id = _billDetailList.Count,
                    BillId = (_billService.GetAllBill().Max(b => b.Id) + 1),
                    ProductId = int.Parse(cbMaSP.SelectedValue.ToString()),
                    SizeId = int.Parse(cbSize.SelectedValue.ToString()),
                    Price = decimal.Parse(txtDonGia.Text.Trim()),
                    Quantity = int.Parse(txtSoLuong.Text.Trim())
                };
                if(_billDetailList.Any(b => b.ProductId == bdt.ProductId && b.SizeId == bdt.SizeId))
                {
                    MessageBox.Show("Đã tồn tại Chi tiết háo đơn này trong bill !");
                    btnThemCTHD.Text = "Lưu";
                    return;
                }    
                _billDetailList.Add(bdt);
                loadGvFormBillDetailList();
                update_BillDetail_Edit();
                datagv_CTHoaDon.Enabled = btnInHD.Enabled = true;
                setBtnBackCTHD_False();
                setEdit_False();
            }
            else //Vua nhan nut them
            {
                setEdit_True();
                saveStament_BillDetail();
                setBtnBackCTHD_True();
                reStart_BillDetail();
                datagv_CTHoaDon.Enabled = false;

            }
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            btnSuaCTHD.Text = btnSuaCTHD.Text.Equals("Sửa CTHD") ? "Cập nhật" : "Sửa CTHD";
            if (btnSuaCTHD.Text.Equals("Sửa CTHD")) // An nut sửa lan 2
            {
                //Code
                int id = int.Parse(gv_CTHoaDon.GetRowCellValue(gv_CTHoaDon.GetSelectedRows()[0], "Id").ToString());
                BillDetailViewModel b  = _billDetailList.FirstOrDefault(bdt => bdt.Id == id) ; 
                b.ProductId = int.Parse(cbMaSP.SelectedValue.ToString());
                b.SizeId = int.Parse(cbSize.SelectedValue.ToString());
                b.Price = decimal.Parse(txtDonGia.Text.Trim());
                b.Quantity = int.Parse(txtSoLuong.Text.Trim());
                MessageBox.Show("Cập nhật thành công !");
                //End Code 
                loadGvFormBillDetailList();
                reStart_BillDetail();
                datagv_CTHoaDon.Enabled = true;
                setBtnBackCTHD_False();
                setEdit_False();
            }
            else //Vua nhan nut sửa
            {
                setEdit_True();
                saveStament_BillDetail();
                setBtnBackCTHD_True();
                btnSuaCTHD.Enabled = true;
                btnXoaCTHD.Enabled = btnThemCTHD.Enabled = false;
                datagv_CTHoaDon.Enabled = false;

            }
            update_BillDetail_Edit();
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            string id = gv_CTHoaDon.GetRowCellValue(gv_CTHoaDon.GetSelectedRows()[0], "Id").ToString();
            if (FormHelper.showRemoveDialog( "chi tiết hoá đơn có mã " + id) == DialogResult.No)
                return;
            BillDetailViewModel bd = _billDetailList.FirstOrDefault(b => b.Id == int.Parse(id));
            _billDetailList.Remove(bd);
            MessageBox.Show("Xoá thành công !");
            loadGvFormBillDetailList();
            reStart_BillDetail();
        }

        private void btnBackCTHD_Click(object sender, EventArgs e)
        {
            btnBackCTHD.Text = btnBackCTHD.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBackCTHD.Text.Equals(""))
            {
                btnBackCTHD.Enabled = false;
                btnSuaCTHD.Text = "Sửa CTHD";
                btnThemCTHD.Text = "Them CTHD";
                update_BillDetail_Edit();
                btnSuaCTHD.Enabled = btnXoaCTHD.Enabled = false;
                btnThemCTHD.Enabled = true;
                datagv_CTHoaDon.Enabled = true;
                txtDonGia.Focus();
            }
        }
        private void gv_HoaDon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult rs = _billService.Update(new BillViewModel()
            {
                Id = int.Parse(gv_HoaDon.GetRowCellValue(rowIndex, "Id").ToString()),
                CustomerName = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerName").ToString(),
                CustomerMobile = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMobile").ToString(),
                BillStatus = gv_HoaDon.GetRowCellValue(rowIndex, "BillStatus").ToString().ParseEnum<BillStatus>(BillStatus.New),
                PaymentMethod = gv_HoaDon.GetRowCellValue(rowIndex, "PaymentMethod").ToString().ParseEnum<PaymentMethod>(PaymentMethod.CashOnDelivery),
                CustomerAddress = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerAddress").ToString(),
                CustomerMessage = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMessage").ToString()
            });
            _billService.Save();
            if (rs.Success)
                FormHelper.showSuccessDialog(rs.Message, rs.Caption);
            else
                FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
            gv_HoaDon.SelectRow(rowIndex);
            LoadGvBill();
        }

        private void gv_HoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int rowIndex = e.RowHandle;
            _bill.Id = int.Parse(gv_HoaDon.GetRowCellValue(rowIndex, "Id").ToString());
            _bill.CustomerName = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerName").ToString();
            _bill.CustomerMobile = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMobile").ToString();
            _bill.BillStatus = gv_HoaDon.GetRowCellValue(rowIndex, "BillStatus").ToString().ParseEnum<BillStatus>(BillStatus.New);
            _bill.PaymentMethod = gv_HoaDon.GetRowCellValue(rowIndex, "PaymentMethod").ToString().ParseEnum<PaymentMethod>(PaymentMethod.CashOnDelivery);
            _bill.CustomerAddress = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerAddress").ToString();
            _bill.CustomerMessage = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMessage").ToString();

            LoadGvBillDetail(_bill.Id);
            update_BillEdit();
        }

        private void gv_CTHoaDon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            int id = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Id").ToString());
            BillDetailViewModel bd = _billDetailList.FirstOrDefault(b => b.Id == id);
            bd.ProductId = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "ProductId").ToString());
            bd.SizeId = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "SizeId").ToString());
            bd.Price = decimal.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Price").ToString());
            bd.Quantity = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Quantity").ToString());
            gv_HoaDon.SelectRow(rowIndex);
            loadGvFormBillDetailList();
        }

        private void gv_CTHoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int rowIndex = e.RowHandle;
            _billDetail.Id = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Id").ToString());
            _billDetail.BillId = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "BillId").ToString());
            _billDetail.ProductId = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "ProductId").ToString());
            _billDetail.SizeId = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "SizeId").ToString());
            _billDetail.Price = decimal.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Price").ToString());
            _billDetail.Quantity = int.Parse(gv_CTHoaDon.GetRowCellValue(rowIndex, "Quantity").ToString());

            update_BillDetail_Edit();

            btnSuaCTHD.Enabled = btnXoaCTHD.Enabled = true;
        }

        private void btnHuyHoaDonTam_Click(object sender, EventArgs e)
        {
            _billTemp = null;
            btnHuyHoaDonTam.Enabled = false;
            btnHuyHoaDonTam.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(BillDetailViewModel bd in _billDetailList)
                {
                    bd.Id = 0;
                }
                _billTemp.Id = 0;
                _billTemp.BillDetails = _billDetailList;
                GenericResult rs = _billService.Create(_billTemp);
                _billService.Save();
                if (rs.Success)
                    FormHelper.showSuccessDialog(rs.Message, rs.Caption);
                else
                    FormHelper.showErrorDialog(rs.Message, rs.Error, rs.Caption);
            }
            catch(Exception ex)
            {
                var tmp = ex.Message;
                MessageBox.Show("Lưu vào hệ thống thất bại !");
            }
        }
    }
}
