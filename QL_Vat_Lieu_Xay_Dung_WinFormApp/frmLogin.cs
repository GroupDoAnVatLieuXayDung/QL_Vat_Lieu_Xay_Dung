using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Equals("Admin") && txtMatKhau.Text.Equals("123456789"))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ten Tai Khoan Hoac Mat Khau Khong Dung", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ptrThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
