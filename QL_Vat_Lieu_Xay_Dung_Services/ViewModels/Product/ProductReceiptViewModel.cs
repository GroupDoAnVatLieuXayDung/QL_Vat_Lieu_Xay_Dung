using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductReceiptViewModel
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        [DefaultValue(0)]
        public decimal Total { get; set; }

        public DateTime DateCreated { get; set; }

        public ReceiptStatus ReceiptStatus { set; get; }

        public Guid? UserId { set; get; }

        public DateTime DateModified { get; set; }

        public SupplierViewModel Supplier { get; set; }

        //Đây là mối quan hệ 1 - nhiều (1 danh mục nhiều products)
        public List<ProductReceiptDetailViewModel> ProductReceiptDetails { get; set; }
    }
}