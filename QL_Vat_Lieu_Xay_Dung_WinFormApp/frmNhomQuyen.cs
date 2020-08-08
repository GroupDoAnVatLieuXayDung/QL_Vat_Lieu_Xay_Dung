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

        private void gv_NhomQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gv_NhomQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
    }
}
