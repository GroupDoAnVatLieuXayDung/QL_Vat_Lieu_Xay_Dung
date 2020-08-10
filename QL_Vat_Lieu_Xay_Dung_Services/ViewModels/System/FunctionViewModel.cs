using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(250)]
        public string URL { set; get; }

        [StringLength(128)]
        public string ParentId { set; get; }

        public string IconCss { get; set; }

        public Status Status { get; set; }

        public int SortOrder { get; set; }
    }
}