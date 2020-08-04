using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models
{
    public class PageContactViewModel
    {
        public ContactViewModel Contact { set; get; }

        public FeedbackViewModel Feedback { set; get; }
    }
}
