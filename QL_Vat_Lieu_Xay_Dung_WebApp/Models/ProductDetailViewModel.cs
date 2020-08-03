using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public Status CheckAvailability { get; set; }
        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public List<ProductImageViewModel> ProductImages { set; get; }

        public List<ProductViewModel> UpsellProducts { get; set; }

        public List<ProductViewModel> LastestProducts { get; set; }
        public List<SelectListItem> Sizes { get; set; }
        public List<TagViewModel> Tags { set; get; }

    }
}
