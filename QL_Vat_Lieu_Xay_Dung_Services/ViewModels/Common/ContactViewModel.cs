using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common
{
    public class ContactViewModel
    {
        public string Id { set; get; }

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(250)]
        public string Website { set; get; }

        [StringLength(250)]
        public string Address { set; get; }

        public string Other { set; get; }

        //Vĩ Độ
        public double? Latitude { set; get; }

        //Kinh Độ
        public double? Longitude { set; get; }

        public Status Status { set; get; }
    }
}