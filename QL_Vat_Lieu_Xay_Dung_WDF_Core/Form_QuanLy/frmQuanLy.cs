using System;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WDF_Core.FunctionStatic;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core.Form_QuanLy
{
    public partial class frmQuanLy : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        private readonly ISupplierService _supplierService;
        private readonly IFunctionService _functionService;
        private readonly IServiceProvider _serviceProvider;

        public frmQuanLy(IServiceProvider serviceProvider,IProductService productService,IBillService billService,ISupplierService supplierService,IFunctionService functionService)
        {
            InitializeComponent();
            _productService = productService;
            _billService = billService;
            _supplierService = supplierService;
            _functionService = functionService;
            _serviceProvider = serviceProvider;
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            
        }

        private void frmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.closeForm(this, e);
        }

        private void btnManHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            var form = _serviceProvider.GetRequiredService<frmManHinh>();
            form.MdiParent = this;
            form.Show();
        

            //frmManHinh mh = new frmManHinh(functionService);
            //mh.MdiParent = this;
            //mh.Show();
            //ribbonControl1.AddControl(mh);
        }

        private void btnNhomQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnHangHoa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
