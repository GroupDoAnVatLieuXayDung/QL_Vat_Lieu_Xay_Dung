using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> HomeSlides { get; set; }

        public List<ProductViewModel> HotProducts { get; set; }

        public List<ProductViewModel> NewProducts { get; set; }

        public List<ProductCategoryViewModel> HomeCategories { set; get; }

        public string Title { set; get; }

        public string MetaKeyWord { set; get; }

        public string MetaDescription { set; get; }
    }
}
