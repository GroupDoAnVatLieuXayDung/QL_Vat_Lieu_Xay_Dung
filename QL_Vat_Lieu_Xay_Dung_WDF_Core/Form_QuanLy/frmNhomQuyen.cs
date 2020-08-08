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
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmNhomQuyen : XtraForm
    {
        #region Declare Variable
        private readonly IRoleService _roleService;

        private string pId, pName, pDescription;

        #endregion Declare Variable

        public frmNhomQuyen(IRoleService roleService)
        {
            InitializeComponent();
            _roleService = roleService;
        }
        #region Load Data

        private void loadGvRoles()
        {
            datagv_NhomQuyen.DataSource = _roleService.GetAllAsync();
            gv_NhomQuyen.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_NhomQuyen.Columns["Id"].OptionsColumn.ReadOnly = true;
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
            if (String.IsNullOrEmpty(txtNhomQuyen.Text.Trim()))
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
            txtNhomQuyen.Text = pName;
            txtMoTa.Text = pDescription;
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
            pName = txtNhomQuyen.Text.Trim();
            pDescription = txtMoTa.Text.Trim();
            pId = gv_NhomQuyen.GetRowCellValue(gv_NhomQuyen.GetSelectedRows()[0], "Id").ToString();
        }
        
        #endregion Method
        private void frmNhomQuyen_Load(object sender, EventArgs e)
        {
            loadGvRoles();
            gv_NhomQuyen.SelectRow(0);
            reStart();
            setBtnBack_False();
            btnThem.Text = "Thêm nhóm quyền";
            btnSua.Text = "Sửa nhóm quyền";
        }

        private void frmNhomQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Text = btnBack.Text.Equals("Huỷ") ? "" : "Huỷ";
            if (btnBack.Text.Equals(""))
            {
                btnBack.Enabled = false;
                btnSua.Text = "Sửa nhóm quyền";
                btnThem.Text = "Thêm nhóm quyền";
                update_Edit();
                btnSua.Enabled = btnXoa.Enabled = false;
                btnThem.Enabled = true;
                datagv_NhomQuyen.Enabled = true;
                txtNhomQuyen.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Text = btnThem.Text.Equals("Thêm nhóm quyền") ? "Lưu" : "Thêm nhóm quyền";
            if (btnThem.Text.Equals("Thêm nhóm quyền")) // An nut them lan 2
            {
                if (!isValid())
                {
                    MessageBox.Show("Bạn phải nhập tên nhóm quyền !");
                    btnThem.Text = "Lưu";
                    return;
                }
                //Code
                Task<bool> rs = _roleService.AddAsync(new AppRoleViewModel()
                {
                    Name = pName,
                    Description = pDescription
                });
                //
                //Thông báo dialog
                //
                //End Code
                loadGvRoles();
                update_Edit();
                datagv_NhomQuyen.Enabled = true;
                setBtnBack_False();
            }
            else //Vua nhan nut them
            {
                saveStament();
                setBtnBack_True();
                reStart();
                datagv_NhomQuyen.Enabled = false;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //btnSua.Text = btnSua.Text.Equals("Sửa nhóm quyền") ? "Cập nhật" : "Sửa nhóm quyền";
            //if (btnSua.Text.Equals("Sửa nhóm quyền")) // An nut sửa lan 2
            //{
            //    //Code
            //    Task<bool> rs = _roleService.UpdateAsync(new AppRoleViewModel()
            //    {
            //        Id = gv_NhomQuyen.GetRowCellValue(gv_NhomQuyen.GetSelectedRows()[0], "Id").ToString(),
            //        Name = pName,
            //        Description = pDescription
            //    });
            //    //
            //    //Thông báo
            //    //
            //    //End Code 
            //    loadGvFunction();
            //    reStart();
            //    datagv_ManHinh.Enabled = true;
            //    setBtnBack_False();
            //}
            //else //Vua nhan nut sửa
            //{
            //    saveStament();
            //    setBtnBack_True();
            //    btnSua.Enabled = true;
            //    btnXoa.Enabled = btnThem.Enabled = false;
            //    datagv_ManHinh.Enabled = false;

            //}
            //update_Edit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //string id = gv_NhomQuyen.GetRowCellValue(gv_NhomQuyen.GetSelectedRows()[0], "Id").ToString();
            //if (FormHelper.showRemoveDialog(id) == DialogResult.No)
            //    return;
            //Task<bool> rs = _roleService.DeleteAsync(id);
            ////
            ////Thong bao
            ////
            //loadGvRoles();
            //reStart();
        }
        private void gv_NhomQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            Task<bool> rs = _roleService.UpdateAsync(new AppRoleViewModel()
            {
             
            });
            //
            //Thong bao
            //
            gv_NhomQuyen.SelectRow(rowIndex);
        }

        private void gv_NhomQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            pId = gv_NhomQuyen.GetRowCellValue(e.RowHandle, "Id").ToString();
            pName = gv_NhomQuyen.GetRowCellValue(e.RowHandle, "Name").ToString();
            pDescription = gv_NhomQuyen.GetRowCellValue(e.RowHandle, "Description").ToString();
            
           
            txtNhomQuyen.Text = pName;
            txtMoTa.Text = pDescription;

            btnSua.Enabled = btnXoa.Enabled = true;
        }
    }
}
