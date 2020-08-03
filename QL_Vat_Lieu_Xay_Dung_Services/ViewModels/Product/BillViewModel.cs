using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class BillViewModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        [DefaultValue(0)]
        public decimal? Total { get; set; }
        public PaymentMethod PaymentMethod { set; get; }

        public BillStatus BillStatus { set; get; }
        public Guid? CustomerId { set; get; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        //public AppUserViewModel User { get; set; }
        public List<BillDetailViewModel> BillDetails { set; get; }
    }
}
