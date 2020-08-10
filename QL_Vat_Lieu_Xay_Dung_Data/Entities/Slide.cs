using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Data.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Vat_Lieu_Xay_Dung_Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>, ISwitchable
    {
        public Slide()
        {
        }

        public Slide(int id, string name, string image, string url, int? displayOrder, Status status, string groupAlias)
        {
            Id = id;
            Name = name;
            Image = image;
            Url = url;
            DisplayOrder = displayOrder;
            Status = status;
            GroupAlias = groupAlias;
        }

        public Slide(string name, string image, string url, int? displayOrder, Status status, string groupAlias)
        {
            Name = name;
            Image = image;
            Url = url;
            DisplayOrder = displayOrder;
            Status = status;
            GroupAlias = groupAlias;
        }

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(250)]
        [Required]
        public string Image { set; get; }

        [StringLength(250)]
        public string Url { set; get; }

        public int? DisplayOrder { set; get; }

        public Status Status { get; set; }

        // cái này dùng để group nhiều slide lại để select
        [StringLength(25)]
        [Required]
        public string GroupAlias { get; set; }
    }
}