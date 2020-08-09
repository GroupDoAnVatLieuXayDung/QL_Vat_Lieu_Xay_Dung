using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;
using System.ComponentModel;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }

        [DefaultValue(0)]
        public decimal Price { get; set; }

        // Giá Khuyến Mãi
        public decimal? PromotionPrice { get; set; }

        // Giá gốc khi nhập hàng vào
        public string Description { get; set; }

        public int BrandId { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        // Unit cho nguoi dung tu go
        public string Unit { get; set; }

        public BrandViewModel Brand { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}