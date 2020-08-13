using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Model;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy
{
    public partial class frmNhomQuyen : XtraForm
    {
        #region Declare Variable
        private readonly IRoleService _roleService;
        private AppRoleViewModel _appRoleViewModel;
        private PermissionViewModel _permissionViewModel;
        private readonly IFunctionService _functionService;
        #endregion Declare Variable

        public frmNhomQuyen(IRoleService roleService, IFunctionService functionService)
        {
            InitializeComponent();
            _roleService = roleService;
            _functionService = functionService;
            _appRoleViewModel = new AppRoleViewModel();
            _permissionViewModel = new PermissionViewModel();
        }
        #region Load Data Roles

        private async Task LoadGvRoles()
        {
            gv_NhomQuyen.DataSource = await _roleService.GetAllAsync();
        }

        #endregion

        #region Method
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtNhomQuyen.Text.Trim()))
                return false;
            return true;
        }
        private void ResetControl()
        {
            txtNhomQuyen.ResetText();
            txtMoTa.ResetText();
            txtNhomQuyen.Focus();
        }

        private void ResetButtonRoles()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
        private void setBtnBack_True()
        {
            btnBack.Text = "Back";
            btnBack.Visible = true;
        }
        private void setBtnBack_False()
        {
            btnBack.Visible = false;
            btnBack.Text = "";
        }
        private void save_Roles()
        {
            _appRoleViewModel = new AppRoleViewModel
            {
                Name = txtNhomQuyen.Text.Trim(), Description = txtMoTa.Text.Trim()
            };
        }
        
        #endregion

        private async void frmNhomQuyen_Load(object sender, EventArgs e)
        {
            await LoadGvRoles();
            ResetButtonRoles();
            EnableFalseControl();
            btnBack.Visible = false;
            btnBackPermission.Visible = false;
        }

        private void EnableFalseControl()
        {
            txtMoTa.Enabled = false;
            txtNhomQuyen.Enabled = false;
        }

        private void EnableTrueControl()
        {
            txtNhomQuyen.Enabled = true;
            txtMoTa.Enabled = true;
        }
        private void frmNhomQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Back") ? "Back" : "";
            if (btnBack.Text.Equals("Back"))
            {
                btnBack.Visible = false;
                btnSua.Text = "Sửa nhóm quyền";
                btnThem.Text = "Thêm nhóm quyền";
                ResetButtonRoles();
                ResetControl();
                EnableFalseControl();
                gv_NhomQuyen.Enabled = true;
                txtNhomQuyen.Focus();

            }

        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Save"))
            {
                if (!IsValid())
                {
                    MessageBox.Show("Bạn phải nhập thông tin đầy đủ !");
                    btnThem.Text = "Save";
                    return;
                }
                save_Roles();
                var kq = await _roleService.AddAsync(_appRoleViewModel);
                if (kq)
                {
                    FormHelper.showSuccessDialog("Thêm Roles Thành Công", "Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm User Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnThem.Text = "Thêm nhóm quyền";
                EnableFalseControl();
                ResetControl();
                gv_NhomQuyen.Enabled = true;
                setBtnBack_False();
                await LoadGvRoles();
            }
            else // Add
            {
                setBtnBack_True();
                btnThem.Text = "Save";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                gv_NhomQuyen.Enabled = false;
                EnableTrueControl();
                ResetControl();
            }
        }
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Save"))
            {
                if (!IsValid())
                {
                    MessageBox.Show("Bạn phải nhập thông tin đầy đủ !");
                    btnThem.Text = "Save";
                    return;
                }
                save_Roles();
                _appRoleViewModel.Id = Guid.Parse(grid_NhomQuyen.GetRowCellValue(grid_NhomQuyen.GetSelectedRows()[0], "Id").ToString());
                var kq = await _roleService.UpdateAsync(_appRoleViewModel);
                if (kq)
                {
                    FormHelper.showSuccessDialog("Update Role Thành Công", "Thành Công");
                }
                else
                {
                    MessageBox.Show("Update Role Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSua.Text = "Sửa nhóm quyền";
                EnableFalseControl();
                ResetControl();
                gv_NhomQuyen.Enabled = true;
                setBtnBack_False();
                await LoadGvRoles();
            }
            else // Update
            {
                setBtnBack_True();
                btnSua.Text = "Save";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                EnableTrueControl();
                gv_NhomQuyen.Enabled = false;

            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (FormHelper.showRemoveDialog(grid_NhomQuyen.GetRowCellValue(grid_NhomQuyen.GetSelectedRows()[0], "Id")
                .ToString()) == DialogResult.No)
            {
                return;
            }
            var kq = await _roleService.DeleteAsync(Guid.Parse(grid_NhomQuyen.GetRowCellValue(grid_NhomQuyen.GetSelectedRows()[0], "Id").ToString()));
            if (kq)
            {
                FormHelper.showSuccessDialog("Delete Roles Thành Công", "Thành Công");
                ResetControl();
                await LoadGvRoles();
            }
            else
            {
                MessageBox.Show("Delete Roles Không Thành Công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void grid_NhomQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtNhomQuyen.Text = grid_NhomQuyen.GetRowCellValue(e.RowHandle, "Name").ToString();
            txtMoTa.Text = grid_NhomQuyen.GetRowCellValue(e.RowHandle, "Description") != null ? grid_NhomQuyen.GetRowCellValue(e.RowHandle, "Description").ToString() : "";
            btnSua.Enabled = btnXoa.Enabled = true;
            btnBack.Visible = false;
            save_Roles();
            await LoadGvPhanQuyen();
        }

        private async Task LoadGvPhanQuyen()
        {
            var getAllPermission = _roleService.GetListFunctionWithRole(
                Guid.Parse(grid_NhomQuyen.GetRowCellValue(grid_NhomQuyen.GetSelectedRows()[0], "Id").ToString()));
            var getAllFunction = await _functionService.GetAll();
            var kq = getAllPermission.Join(getAllFunction, p => p.FunctionId, f => f.Id, (p, f) => new
            {
                p.RoleId,
                p.FunctionId,
                f.Name,
                p.CanRead,
                p.CanCreate,
                p.CanUpdate,
                p.CanDelete

            }).ToList();
            gv_PhanQuyen.DataSource = kq;
        }

        #region Permission





        private async void btnBackPermission_Click(object sender, EventArgs e)
        {
            btnBackPermission.Visible = false;
            btnSavePermission.Visible = false;
            gv_NhomQuyen.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnBack.Visible = true;
            await LoadGvPhanQuyen();
        }
        private async void btnSavePermission_Click(object sender, EventArgs e)
        {
            try
            {
                List<PermissionViewModel> p = new List<PermissionViewModel>();
                btnBackPermission.Visible = false;
                for (int i = 0; i < grid_PhanQuyen.RowCount; i++)
                {
                    PermissionViewModel permission = new PermissionViewModel();
                    permission.RoleId = Guid.Parse(grid_PhanQuyen.GetRowCellValue(i, "RoleId").ToString());
                    permission.FunctionId = grid_PhanQuyen.GetRowCellValue(i, "FunctionId").ToString();
                    permission.CanRead = bool.Parse(grid_PhanQuyen.GetRowCellValue(i, "CanRead").ToString());
                    permission.CanCreate = bool.Parse(grid_PhanQuyen.GetRowCellValue(i, "CanCreate").ToString());
                    permission.CanUpdate = bool.Parse(grid_PhanQuyen.GetRowCellValue(i, "CanUpdate").ToString());
                    permission.CanDelete = bool.Parse(grid_PhanQuyen.GetRowCellValue(i, "CanDelete").ToString());
                    p.Add(permission);
                }
                _roleService.SavePermission(p, Guid.Parse(grid_NhomQuyen.GetRowCellValue(grid_NhomQuyen.GetSelectedRows()[0], "Id").ToString()));
                await LoadGvPhanQuyen();
                MessageBox.Show("Luu Thanh Cong", "Thanh Cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemCanCreate_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void repositoryItemCanRead_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void repositoryItemCanUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void repositoryItemCanDelete_MouseDown(object sender, MouseEventArgs e)
        {
           
        }



        private void grid_PhanQuyen_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "CanRead")
            //{
            //    if ((bool)e.Value)
            //    {
            //        repositoryItemCanRead.ValueChecked = false;
            //    }
            //    else
            //    {
            //        repositoryItemCanRead.ValueChecked = true;
            //    }
            //}

            //if (e.Column.FieldName == "CanCreate")
            //{
            //    if ((bool)e.Value)
            //    {
            //        repositoryItemCanCreate.ValueChecked = false;
            //    }
            //    else
            //    {
            //        repositoryItemCanCreate.ValueChecked = true;
            //    }
            //}
            //if (e.Column.FieldName == "CanUpdate")
            //{
            //    if ((bool)e.Value)
            //    {
            //        repositoryItemCanUpdate.ValueChecked = false;
            //    }
            //    else
            //    {
            //        repositoryItemCanUpdate.ValueChecked = true;
            //    }
            //}
            //if (e.Column.FieldName == "CanDelete")
            //{
            //    if ((bool)e.Value)
            //    {
            //        repositoryItemCanDelete.ValueChecked = false;
            //    }
            //    else
            //    {
            //        repositoryItemCanDelete.ValueChecked = true;
            //    }
            //}
        }
        private void repositoryItemCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            grid_PhanQuyen.PostEditor();
        }
        private void repositoryItemCanCreate_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void repositoryItemCanRead_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void grid_PhanQuyen_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            btnBackPermission.Visible = true;
            btnSavePermission.Visible = true;
            gv_NhomQuyen.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnBack.Visible = false;
        }

        #endregion

    }
}
