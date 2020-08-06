using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;

namespace QL_Vat_Lieu_Xay_Dung_Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        public AnnouncementUser() { }
        public AnnouncementUser(string announcementId, Guid userId, bool? hasRead)
        {
            AnnouncementId = announcementId;
            UserId = userId;
            HasRead = hasRead;
        }

        [Required]
        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }
        [Required]
        public string AnnouncementId { get; set; }


        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}