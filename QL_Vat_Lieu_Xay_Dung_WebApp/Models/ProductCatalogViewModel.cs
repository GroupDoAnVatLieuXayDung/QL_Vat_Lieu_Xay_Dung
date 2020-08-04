using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models
{
    public class ProductCatalogViewModel
    {
        public PagedResult<ProductViewModel> Data { get; set; }

        public ProductCategoryViewModel ProductCategory { set; get; }

        public string SortType { set; get; }

        public int? PageSize { set; get; }
        public BrandViewModel Brand { set; get; }
        public List<SizeViewModel> Sizes { get; set; }

        public List<SelectListItem> SortTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "lastest",Text = "Mới về"},
            new SelectListItem(){Value = "price_low_to_high",Text = "Giá Tăng Dần"},
            new SelectListItem(){Value = "price_high_to_low",Text = "Giá Giảm Dần"},
            new SelectListItem(){Value = "price_sell",Text = "Giảm Giá"},
            new SelectListItem(){Value = "name",Text = "Name"},
        };

        public List<SelectListItem> PageSizes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "3",Text = "3"},
            new SelectListItem(){Value = "6",Text = "6"},
            new SelectListItem(){Value = "9",Text = "9"},
        };
    }
}
