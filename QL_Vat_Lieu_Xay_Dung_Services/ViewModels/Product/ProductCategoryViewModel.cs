using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;
using System.Collections.Generic;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public int SortOrder { get; set; }

        //Đây là mối quan hệ 1 - nhiều (1 danh mục nhiều products)
        public ICollection<ProductViewModel> Products { get; set; }
    }
}