using System;
using System.Collections.Generic;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductReceiptDetailViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ProductReceiptId { set; get; }
        public ProductReceiptViewModel ProductReceipt { get; set; }
        public ProductViewModel Product { get; set; }

        public SizeViewModel Size { get; set; }
    }
}
