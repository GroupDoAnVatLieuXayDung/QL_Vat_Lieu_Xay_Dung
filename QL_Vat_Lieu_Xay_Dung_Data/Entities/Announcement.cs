using QL_Vat_Lieu_Xay_Dung_Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Data.Interfaces;

namespace QL_Vat_Lieu_Xay_Dung_Data.Entities
{
    [Table("Announcements")]
    public class Announcement: DomainEntity<string>, ISwitchable,IDateTracking
    {
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        public Announcement(string title, string content,string image, Guid userId, Status status)
        {
            Title = title;
            Content = content;
            Image = image;
            UserId = userId;
            Status = status;
        }

        [Required]
        [StringLength(250)]
        public string Title { set; get; }

        [StringLength(250)]
        public string Content { set; get; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        public Guid UserId { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
    }
}
