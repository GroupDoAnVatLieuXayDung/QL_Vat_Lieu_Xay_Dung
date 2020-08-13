using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Microsoft.AspNetCore.Identity;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Properties;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private AppUserViewModel _appUserViewModel;
        public frmUser(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
            _appUserViewModel = new AppUserViewModel();
            InitializeComponent();
        }
        private async void frmUser_Load(object sender, EventArgs e)
        {
            await LoadGridViewUser();
            await LoadListBoxRoles();
            txtTaiKhoan.Focus();
            EnableFalseControl();
            btnBack.Visible = false;
            ptrAvatar.Enabled = false;
            toggleSwitchSuDungAvatar.IsOn = false;
        }

        private bool isValid_User()
        {
            if (string.IsNullOrEmpty(txtHoten.Text.Trim()) || string.IsNullOrEmpty(txtPhone.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtMatKhau.Text.Trim())||
                string.IsNullOrEmpty(txtTaiKhoan.Text.Trim()))
                return false;
            return true;
        }

        private void RessetControl()
        {
            txtHoten.ResetText();
            txtEmail.ResetText();
            txtMatKhau.ResetText();
            txtTaiKhoan.ResetText();
            txtPhone.ResetText();
            toggleSwitchTrangThai.IsOn = false;
            toggleSwitchSuDungAvatar.IsOn = false;
            datepkNgaySinh.EditValue = DateTime.Now;
            lstRole.SelectedIndex = -1;
            ptrAvatar.Image = null;

        }
        private void ResetUser()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
        private async Task LoadGridViewUser()
        {
            var dataSource = await _userService.GetAllAsync();
            gv_User.DataSource = dataSource;
        }

        private async Task LoadListBoxRoles()
        {
            lstRole.DataSource = await _roleService.GetAllAsync();
            lstRole.DisplayMember = "Name";
            lstRole.ValueMember = "Name";
        }
        private void setBtnBack_True()
        {
            btnBack.Text = "Back";
            btnBack.Visible = true;
        }
        private void setBtnBack_False()
        {
            btnBack.Text = "";
            btnBack.Visible = false;
        }
        private void save_User()
        {
            _appUserViewModel = new AppUserViewModel
            {
                UserName = txtTaiKhoan.Text.Trim(),
                BirthDay = datepkNgaySinh.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Avatar = ptrAvatar.Tag != null
                    ? "/img_ds/" + ptrAvatar.Tag.ToString().Substring(ptrAvatar.Tag.ToString().LastIndexOf("\\") + 1) : "/img_ds/img.jpg",
                PhoneNumber = txtPhone.Text.Trim(),
                FullName = txtHoten.Text.Trim(),
                DateCreated = DateTime.Now,
                Status = toggleSwitchTrangThai.IsOn ? Status.Active : Status.InActive
            };
            if (lstRole.SelectedItems.Count > 0)
            {
                foreach (var lstRoleItem in lstRole.SelectedItems)
                {

                    var tmp = lstRoleItem as AppRoleViewModel;
                    _appUserViewModel.Roles.Add(tmp.Name);
                }
            }
        }

        private void EnableFalseControl()
        {
            txtHoten.Enabled = false;
            txtEmail.Enabled = false;
            txtMatKhau.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtPhone.Enabled = false;
            datepkNgaySinh.Enabled = false;
            lstRole.Enabled = false;
            toggleSwitchTrangThai.Enabled = false;
            toggleSwitchSuDungAvatar.Enabled = false;
            ptrAvatar.Enabled = false;
        }

        private void EnableTrueControl()
        {
            txtHoten.Enabled = true;
            txtEmail.Enabled = true;
            txtMatKhau.Enabled = true;
            txtTaiKhoan.Enabled = true;
            datepkNgaySinh.Enabled = true;
            txtPhone.Enabled = true;
            lstRole.Enabled = true;
            toggleSwitchTrangThai.Enabled = true;
            toggleSwitchSuDungAvatar.Enabled = true;
        }
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Save"))
            {
                if (!isValid_User())
                {
                    MessageBox.Show("Bạn phải nhập thông tin đầy đủ !");
                    btnThem.Text = "Save";
                    return;
                }
                save_User();
                _appUserViewModel.PasswordHash = txtMatKhau.Text;
               var kq = await _userService.AddAsync(_appUserViewModel);
               if (kq)
               {
                   FormHelper.showSuccessDialog("Thêm User Thành Công", "Thành Công");
               }
               else
               {
                   MessageBox.Show("Thêm User Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               btnThem.Text = "Thêm người dùng";
               EnableFalseControl();
               RessetControl();
               gv_User.Enabled = true;
               setBtnBack_False();
               await LoadGridViewUser();
            }
            else // Add
            {
                setBtnBack_True();
                btnThem.Text = "Save";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                gv_User.Enabled = false;
                EnableTrueControl();
                RessetControl();
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Save"))
            {
                if (!isValid_User())
                {
                    MessageBox.Show("Bạn phải nhập thông tin đầy đủ !");
                    btnThem.Text = "Save";
                    return;
                }
                save_User();
                var kq = await _userService.UpdateAsync(_appUserViewModel);
                if (kq)
                {
                    FormHelper.showSuccessDialog("Update User Thành Công", "Thành Công");
                }
                else
                {
                    MessageBox.Show("Update User Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSua.Text = "Sửa thông tin người dùng";
                EnableFalseControl();
                RessetControl();
                gv_User.Enabled = true;
                setBtnBack_False();
                await LoadGridViewUser();
            }
            else // Update
            {
                setBtnBack_True();
                btnSua.Text = "Save";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                EnableTrueControl();
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
                gv_User.Enabled = false;
                btnSua.Enabled = true;
                ptrAvatar.Enabled = true;

            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {

            if (FormHelper.showRemoveDialog(grid_User.GetRowCellValue(grid_User.GetSelectedRows()[0], "Id")
                .ToString()) == DialogResult.No)
            {
                return;
            }
            var kq = await _userService.DeleteAsync(grid_User.GetRowCellValue(grid_User.GetSelectedRows()[0], "Id").ToString());
            if (kq)
            {
                FormHelper.showSuccessDialog("Delete User Thành Công", "Thành Công");
                RessetControl();
                await LoadGridViewUser();
            }
            else
            {
                MessageBox.Show("Delete User Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Back") ? "Back" : "";
            if (btnBack.Text.Equals("Back"))
            {
                btnBack.Visible = false;
                btnSua.Text = "Sửa thông tin người dùng";
                btnThem.Text = "Thêm người dùng";
                ResetUser();
                RessetControl();
                gv_User.Enabled = true;
                txtTaiKhoan.Focus();
            }
        }
        private void ptrAvatar_Click(object sender, EventArgs e)
        {
            string fNguon = FormHelper.chonFileNameHinhAnh();
            if (fNguon == null)
                ptrAvatar.Tag = "img.jpg";
            else
                ptrAvatar.Tag = fNguon;

            loadHinh(fNguon);
        }
        private void loadHinh(string fName)
        {
            try
            {
                using (FileStream fs = new FileStream(fName, FileMode.Open, FileAccess.Read))
                {
                    ptrAvatar.Image = Image.FromStream(fs);
                    fs.Dispose();
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
        private void toggleSwitchSuDungAvatar_Toggled(object sender, EventArgs e)
        {
            ptrAvatar.Enabled = toggleSwitchSuDungAvatar.IsOn;
        }
        private void ptrAvatar_EditValueChanged(object sender, EventArgs e)
        {

        }

        private async void grid_Khach_NV_NhaCC_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtTaiKhoan.Text = grid_User.GetRowCellValue(e.RowHandle, "UserName").ToString().Trim();
            txtEmail.Text = grid_User.GetRowCellValue(e.RowHandle, "Email") != null ? grid_User.GetRowCellValue(e.RowHandle, "Email").ToString().Trim() : null;
            toggleSwitchTrangThai.IsOn = grid_User.GetRowCellValue(e.RowHandle, "Status").ToString().Trim().Equals(Status.Active.ToString());
            txtMatKhau.Text = grid_User.GetRowCellValue(e.RowHandle, "PasswordHash").ToString().Trim();
            txtHoten.Text = grid_User.GetRowCellValue(e.RowHandle, "FullName").ToString().Trim();
            txtPhone.Text = grid_User.GetRowCellValue(e.RowHandle, "PhoneNumber").ToString().Trim();
            datepkNgaySinh.EditValue = grid_User.GetRowCellValue(e.RowHandle, "BirthDay") != null ? DateTime.Parse(grid_User.GetRowCellValue(e.RowHandle, "BirthDay").ToString().Trim()) : DateTime.Now;
            if (grid_User.GetRowCellValue(e.RowHandle, "Avatar") != null)
            {
                var tmp = grid_User.GetRowCellValue(e.RowHandle, "Avatar").ToString().Substring(grid_User.GetRowCellValue(e.RowHandle, "Avatar").ToString().LastIndexOf("/")+1);
                var tmp2 = tmp.Substring(0, tmp.LastIndexOf("."));
                ResourceManager rm = Resources.ResourceManager;
                Bitmap myImage = (Bitmap)rm.GetObject(tmp2);
                ptrAvatar.Image = myImage;
                ptrAvatar.Tag = "/img_ds/" + tmp;
                toggleSwitchSuDungAvatar.IsOn = true;
            }
            else
            {
                ptrAvatar.Image = null;
                toggleSwitchSuDungAvatar.IsOn = false;
            }

            ptrAvatar.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            save_User();
            btnBack.Visible = false;
            lstRole.SelectedIndex = -1;
            var checkRoles = await _userService.GetRoleByUser(_appUserViewModel);
            if (checkRoles.Count > 0)
            {

                foreach (string item in checkRoles)
                {
                    var index = lstRole.FindString(item);
                    lstRole.SetSelected(index,true);
                }
            }

        }
        private void toggleSwitchSuDungAvatar_Properties_Click(object sender, EventArgs e)
        {
            ptrAvatar.Enabled = toggleSwitchSuDungAvatar.IsOn;
        }
    }
}