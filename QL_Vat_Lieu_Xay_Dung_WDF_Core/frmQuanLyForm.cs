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
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmQuanLyForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        private readonly ISupplierService _supplierService;
        private readonly IFunctionService _functionService;
        private readonly IServiceProvider _serviceProvider;
        public frmQuanLyForm(IServiceProvider serviceProvider, IProductService productService, IBillService billService, ISupplierService supplierService, IFunctionService functionService)
        {
            InitializeComponent();
            _productService = productService;
            _billService = billService;
            _supplierService = supplierService;
            _functionService = functionService;
            _serviceProvider = serviceProvider;
        }

        private void btnManHinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var form = _serviceProvider.GetRequiredService<frmManHinh>();
            //form.MdiParent = this;
            //form.Show();
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmManHinh>();
            form.ShowDialog(this);


            //frmManHinh mh = new frmManHinh(functionService);
            //mh.MdiParent = this;
            //mh.Show();
            //ribbonControl1.AddControl(mh);
        }

        private void btnNhomQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmNhomQuyen>();
            form.ShowDialog(this);
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmUser>();
            form.ShowDialog(this);
        }

        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmNhaCungCap>();
            form.ShowDialog(this);
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmHangHoa>();
            form.ShowDialog(this);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmDanhMucHangHoa>();
            form.ShowDialog(this);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.IsMdiContainer = false;
            var form = _serviceProvider.GetRequiredService<frmBill_BillDetailt>();
            form.ShowDialog(this);
        }
    }
}