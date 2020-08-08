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

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmPhanQuyen : XtraForm
    {

        private static frmPhanQuyen _instance;
        public static frmPhanQuyen Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmPhanQuyen();
                return _instance;
            }
        }
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {

        }

        private void frmPhanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
