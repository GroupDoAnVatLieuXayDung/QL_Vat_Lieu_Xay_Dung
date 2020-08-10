using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using System;

namespace QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }
    }
}