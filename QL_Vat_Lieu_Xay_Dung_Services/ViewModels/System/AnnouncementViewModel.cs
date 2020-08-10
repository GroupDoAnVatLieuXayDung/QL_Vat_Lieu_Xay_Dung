using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System
{
    public class AnnouncementViewModel
    {
        public string Id { get; set; }

        public string Title { set; get; }

        public string Content { set; get; }

        public string Image { get; set; }

        public Guid UserId { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
    }
}