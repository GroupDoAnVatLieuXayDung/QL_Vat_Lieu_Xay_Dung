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
    public partial class frmBillBillDetail : DevExpress.XtraEditors.XtraForm
    {
        #region Declare

        private readonly IBillService _billService;
        private readonly IProductService _productService;
        //private BillViewModel _bill;
        //private ProductViewModel _product;
        //private BillDetailViewModel _billDetail;
        private string _pCustomerName, _pCustomerMobile, _pBillStatus, _pPaymentMethod;
        private string _pCustomerAddress, _pCustomerMessage;
        private string _pBillId, _pProductId, _pPrice, _pQuantity;
        #endregion Declare
        public frmBillBillDetail(IBillService billService, IProductService productService)
        {
            InitializeComponent();
            _billService = billService;
            _productService = productService;
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
            List<BillViewModel> bills = _billService.GetAllBill();
            cbMaHD.DataSource = bills;
            cbMaHD.DisplayMember = "Id";
            cbMaHD.ValueMember = "Id";
        }
        private void LoadCbMaSp()
        {
            List<ProductViewModel> products = _productService.GetAll();
            cbMaSP.DataSource = products;
            cbMaSP.DisplayMember = "Name";
            cbMaSP.ValueMember = "Id";
        }

        private void LoadGvBill()
        {
            datagv_HoaDon.DataSource = _billService.GetAllBill();
        }
        private void LoadGvBillDetail(int id)
        {
            datagv_CTHoaDon.DataSource = _billService.GetBillDetails(id);
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
                    ct.GetType() == typeof(ComboBoxEdit)  || ct.GetType() == typeof(TextEdit))
                      ct.Text = String.Empty;
            }
            btnThemHD.Enabled = true;
            btnSuaHD.Enabled = btnXoaHD.Enabled = btnInHD.Enabled = false;
        }
        private void update_BillEdit()
        {
            //txtTenKH.Text = _bill.CustomerName;
            //txtPhone.Text = _bill.CustomerMobile;
            //cbTrangThai.Text =  _bill.BillStatus.GetDisplayName();
            //cbPhuongThucThanhToan.Text = _bill.PaymentMethod.GetDisplayName();
            //txtDiaChi.Text = _bill.CustomerAddress;
            //txtGhiChu.Text = _bill.CustomerMessage;
            txtTenKH.Text = _pCustomerName;
            txtPhone.Text = _pCustomerMobile;
            cbTrangThai.Text = _pBillStatus;
            cbPhuongThucThanhToan.Text = _pPaymentMethod;
            txtDiaChi.Text = _pCustomerAddress;
            txtGhiChu.Text = _pCustomerMessage;
            cbMaHD.Text = _pBillId;
        }
        private void setBtnBackHD_True()
        {
            btnBackHD.Text = "Huỷ";
            btnBackHD.Visible = true;
        }
        private void setBtnBackHD_False()
        {
            btnBackHD.Visible = false;
            btnBackHD.Text = "";
        }
        private void saveStament_Bill()
        {
            _pCustomerName = txtTenKH.Text.Trim();
            _pCustomerMobile = txtPhone.Text.Trim();
            _pBillStatus = cbTrangThai.Text.Trim();
            _pPaymentMethod = cbPhuongThucThanhToan.Text.Trim();
            _pCustomerAddress = txtDiaChi.Text.Trim();
            _pCustomerMessage = txtGhiChu.Text.Trim();
            _pBillId = cbMaHD.Text.Trim();
            //_bill.CustomerName = String.IsNullOrEmpty(txtTenKH.Text) ? "" : txtTenKH.Text;
            //_bill.CustomerMobile = txtPhone.Text;
            //_bill.BillStatus = cbTrangThai.EditValue.ToString().ParseEnum<BillStatus>(BillStatus.New);
            //_bill.PaymentMethod = cbPhuongThucThanhToan.EditValue.ToString().ParseEnum<PaymentMethod>(PaymentMethod.CashOnDelivery);
            //_bill.CustomerAddress = txtDiaChi.Text;
            //_bill.CustomerMessage = txtGhiChu.Text;
        }

        #endregion Bill method

        #region BillDetail method

        private bool isValid_BillDetail(string billId)
        {
            if (String.IsNullOrEmpty(billId) || String.IsNullOrEmpty(cbMaSP.Text.Trim()) ||
                String.IsNullOrEmpty(txtDonGia.Text) || String.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                return false;
            return true;
        }
        private void reStart_BillDetail()
        {
            foreach (Control ct in panel2.Controls)
            {
                if (typeof(TextBox) == ct.GetType() || ct.GetType() == typeof(System.Windows.Forms.ComboBox) ||
                     ct.GetType() == typeof(ComboBoxEdit) || ct.GetType() == typeof(TextEdit))
                    ct.Text = String.Empty;
            }
            btnThemCTHD.Enabled = true;
            btnSuaCTHD.Enabled = btnXoaCTHD.Enabled = false;
        }

        private void update_BillDetail_Edit()
        {
            cbMaHD.Text = _pBillId;
            cbMaSP.Text = _pProductId;
            txtDonGia.Text = _pPrice;
            txtSoLuong.Text = _pQuantity;
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
            _pBillId = cbMaHD.Text.Trim();
            _pProductId = cbMaSP.Text.Trim();
            _pQuantity = txtSoLuong.Text.Trim();
            _pPrice = txtDonGia.Text.Trim();
        }

        #endregion BillDetail method
        private void frmBill_BillDetailt_Load(object sender, EventArgs e)
        {
            LoadCbPhuongThucThanhToan();
            LoadCbMaHd();
            LoadCbTrangThai();
            LoadCbMaHd();
            LoadCbMaSp();
            LoadGvBill();
            gv_HoaDon.SelectRow(0);
            reStart_Bill();
            reStart_BillDetail();
            setBtnBackCTHD_False();
            setBtnBackHD_False();
            btnInHD.Enabled = true;
        }

        private void frmBill_BillDetailt_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Text = btnThemHD.Text.Equals("Tạo mới hoá đơn") ? "Lưu" : "Tạo mới hoá đơn";
            if (btnThemHD.Text.Equals("Tạo mới hoá đơn")) // An nut them lan 2
            {
                if (!isValid_Bill())
                {
                    MessageBox.Show("Ban phai nhap day du thông tin !");
                    btnThemHD.Text = "Lưu";
                    return;
                }
                GenericResult rs = _billService.Create(new BillViewModel()
                {
                    CustomerName = txtTenKH.Text,
                    CustomerMobile = txtPhone.Text,
                    BillStatus = cbTrangThai.EditValue.ToString().GetValueFromDescription<BillStatus>(BillStatus.New),

                    PaymentMethod = cbPhuongThucThanhToan.EditValue.ToString().GetValueFromDescription<PaymentMethod>(PaymentMethod.CashOnDelivery),
                    CustomerAddress = txtDiaChi.Text,
                    CustomerMessage = txtGhiChu.Text
                });
                // Save mới lưu được dữ liệu dưới database      _billService.Save();
                //_billService.Save();
                if (rs.Success)
                    FormHelper.showSuccessDialog(rs.Message, rs.Caption);
                else
                    FormHelper.showErrorDialog(rs.Message,rs.Error, rs.Caption);
                LoadGvBill();
                update_BillEdit();
                datagv_HoaDon.Enabled = btnInHD.Enabled = true;
                setBtnBackHD_False();
            }
            else //Vua nhan nut them
            {
                saveStament_Bill();
                setBtnBackHD_True();
                reStart_Bill();
                datagv_HoaDon.Enabled = false;

            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            btnSuaHD.Text = btnSuaHD.Text.Equals("Sửa hoá đơn") ? "Cập nhật" : "Sửa hoá đơn";
            if (btnSuaHD.Text.Equals("Sửa hoá đơn")) // An nut sửa lan 2
            {
                GenericResult rs = _billService.Update(new BillViewModel()
                {
                    Id = int.Parse(cbMaHD.SelectedValue.ToString()),
                    CustomerName = txtTenKH.Text,
                    CustomerMobile = txtPhone.Text,
                    BillStatus = cbTrangThai.EditValue.ToString().ParseEnum<BillStatus>(BillStatus.New),
                    PaymentMethod = cbPhuongThucThanhToan.EditValue.ToString().ParseEnum<PaymentMethod>(PaymentMethod.CashOnDelivery),
                    CustomerAddress = txtDiaChi.Text,
                    CustomerMessage = txtGhiChu.Text
                }); 
                cbMaHD.Enabled = true;
                LoadGvBill();
                reStart_Bill();
                update_BillEdit();
                datagv_HoaDon.Enabled = true;
                setBtnBackHD_False();
            }
            else //Vua nhan nut sửa
            {
                cbMaHD.Enabled = false;
                saveStament_Bill();
                setBtnBackHD_True();
                update_BillEdit();
                btnSuaHD.Enabled = true;
                btnXoaHD.Enabled = btnThemHD.Enabled = false;
                datagv_HoaDon.Enabled = false;

            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (FormHelper.showRemoveDialog(gv_HoaDon.GetRowCellValue(gv_HoaDon.GetSelectedRows()[0],"Id").ToString()) == DialogResult.No)
                return;
            GenericResult rs = _billService.UpdateStatus(int.Parse(cbMaHD.SelectedValue.ToString()), BillStatus.Cancelled);
            LoadGvBill();
            reStart_Bill();
        }

        private void btnBackHD_Click(object sender, EventArgs e)
        {
            btnBackHD.Text = btnBackHD.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBackHD.Text.Equals(""))
            {
                btnBackHD.Enabled = false;
                btnSuaHD.Text = "Sửa hoá đơn";
                btnThemHD.Text = "Tạo mới hoá đơn";
                update_BillEdit();
                btnSuaHD.Enabled = btnXoaHD.Enabled = false;
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

        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {

        }

        private void btnBackCTHD_Click(object sender, EventArgs e)
        {

        }
        private void gv_HoaDon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            GenericResult result = _billService.Update(new BillViewModel()
            {
                Id = int.Parse(gv_HoaDon.GetRowCellValue(rowIndex, "Id").ToString()),
                CustomerName = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerName").ToString(),
                CustomerMobile = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMobile").ToString(),
                BillStatus = gv_HoaDon.GetRowCellValue(rowIndex, "BillStatus").ToString().ParseEnum<BillStatus>(BillStatus.New),
                PaymentMethod = gv_HoaDon.GetRowCellValue(rowIndex, "PaymentMethod").ToString().ParseEnum<PaymentMethod>(PaymentMethod.CashOnDelivery),
                CustomerAddress = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerAddress").ToString(),
                CustomerMessage = gv_HoaDon.GetRowCellValue(rowIndex, "CustomerMessage").ToString()
            });
            gv_HoaDon.SelectRow(rowIndex);
        }

        private void gv_HoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //maNCC = gridNhaCC.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            //tenNCC = gridNhaCC.GetRowCellValue(e.RowHandle, "TenNCC").ToString();
            //diaChi = gridNhaCC.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
            //cbNhaCC.Text = maNCC;
            //txtTenNCC.Text = tenNCC;
            //txtDiaChi.Text = diaChi;
            //btnSua.Enabled = btnXoa.Enabled = true;


            int row = e.RowHandle;
            string billId = gv_CTHoaDon.GetRowCellValue(row, "BillId").ToString();
            LoadGvBillDetail(int.Parse(billId));
        }

        private void gv_CTHoaDon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gv_CTHoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
    }
}
