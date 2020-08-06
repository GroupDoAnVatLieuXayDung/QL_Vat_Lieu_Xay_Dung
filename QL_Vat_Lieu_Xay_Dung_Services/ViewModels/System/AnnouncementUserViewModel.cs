using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System
{
    public class AnnouncementUserViewModel
    {
        public int Id { set; get; }

        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

    }
}
