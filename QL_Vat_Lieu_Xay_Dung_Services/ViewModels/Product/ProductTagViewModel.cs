using System;
using System.Collections.Generic;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductTagViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string TagId { set; get; }

        public ProductViewModel Product { set; get; }

        public TagViewModel Tag { set; get; }
    }
}
