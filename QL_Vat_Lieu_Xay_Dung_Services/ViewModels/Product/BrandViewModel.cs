using System;
using System.Collections.Generic;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
    }
}
