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
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;

namespace QL_Vat_Lieu_Xay_Dung_WDF_Core
{
    public partial class frmDanhMucHangHoa : DevExpress.XtraEditors.XtraForm
    {
        #region Declare Variable
        private readonly IProductCategoryService _productCategoryService;

        private string pId, pName, pParentId, pImage, pStatus;
        #endregion Declare Variable

        public frmDanhMucHangHoa(IProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
        }
        #region Load Data

        private void loadCbParentId()
        {
            //  List<FunctionViewModel> funs = _functionService.GetAll_List();
            List<ProductCategoryViewModel> products = _productCategoryService.GetAll();
            foreach (ProductCategoryViewModel em in products)
            {
                cbDanhMucCha.Properties.Items.Add(em.Name);
            }
        }

        private void loadGvFunction()
        {
            datagv_ManHinh.DataSource = _functionService.GetAll_List();
            gv_ManHinh.Columns["Id"].OptionsColumn.AllowEdit = false;
            gv_ManHinh.Columns["Id"].OptionsColumn.ReadOnly = true;
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
        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
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

        private void frmDanhMucHangHoa_Load(object sender, EventArgs e)
        {

        }

        private void gv_DanhMuc_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void ptrHinhAnh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void gv_DanhMuc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
    }
}