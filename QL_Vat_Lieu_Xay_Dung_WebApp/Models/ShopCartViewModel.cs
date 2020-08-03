using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models
{
    public class ShopCartViewModel
    {
        public ProductViewModel Product { set; get; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public SizeViewModel Size { get; set; }

    }
}
