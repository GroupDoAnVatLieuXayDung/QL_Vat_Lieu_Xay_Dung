using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmQuanLy : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void aceNhomQuyen_Click(object sender, EventArgs e)
        {
        }

        private void aceManHinh_Click(object sender, EventArgs e)
        {
          
        }

        private void acePhanQuyen_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(frmPhanQuyen.Instance))
            {
                Container.Controls.Add(frmPhanQuyen.Instance);
                frmPhanQuyen.Instance.Dock = DockStyle.Fill;
            }
            frmPhanQuyen.Instance.BringToFront();
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void frmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
