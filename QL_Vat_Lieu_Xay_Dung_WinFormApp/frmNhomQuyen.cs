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

namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    public partial class frmNhomQuyen : XtraForm
    {

        private static frmNhomQuyen _instance;
        public static frmNhomQuyen Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmNhomQuyen();
                return _instance;
            }
        }
        public frmNhomQuyen()
        {
            InitializeComponent();
        }

        private void frmNhomQuyen_Load(object sender, EventArgs e)
        {

        }

        private void frmNhomQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePermission_Click(object sender, EventArgs e)
        {

        }

        private void grid_NhomQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void grid_PhanQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void btnBackPermission_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemCanCreate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grid_PhanQuyen_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

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

        private void repositoryItemCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            grid_PhanQuyen.PostEditor();
        }
    }
}
