using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductReceiptViewModel
    {
        public int SupplierId { get; set; }
        [DefaultValue(0)]
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public SupplierViewModel Supplier { get; set; }
        //Đây là mối quan hệ 1 - nhiều (1 danh mục nhiều products)
        public List<ProductReceiptDetailViewModel> ProductReceiptDetails { get; set; }
    }
}
