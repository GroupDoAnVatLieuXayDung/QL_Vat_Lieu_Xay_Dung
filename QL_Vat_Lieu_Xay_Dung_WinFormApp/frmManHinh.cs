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

namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    public partial class frmManHinh : DevExpress.XtraEditors.XtraForm
    {
        private static frmManHinh _instance;
        public static frmManHinh Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmManHinh();
                return _instance;
            }
        }
        public frmManHinh()
        {
            InitializeComponent();
        }

        private void frmManHinh_Load(object sender, EventArgs e)
        {

        }

        private void frmManHinh_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gv_ManHinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gv_ManHinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
    }
}