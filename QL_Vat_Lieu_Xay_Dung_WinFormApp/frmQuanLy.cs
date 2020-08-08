using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Vat_Lieu_Xay_Dung_WinFormApp
{
    public partial class frmQuanLy : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void aceNhomQuyen_Click(object sender, EventArgs e)
        {
            if(!Container.Controls.Contains(frmNhomQuyen.Instance))
            {
                Container.Controls.Add(frmNhomQuyen.Instance);
                frmNhomQuyen.Instance.Dock = DockStyle.Fill;
            }
            frmNhomQuyen.Instance.BringToFront();
        }

        private void aceManHinh_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(frmManHinh.Instance))
            {
                Container.Controls.Add(frmManHinh.Instance);
                frmManHinh.Instance.Dock = DockStyle.Fill;
            }
            frmManHinh.Instance.BringToFront();
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
