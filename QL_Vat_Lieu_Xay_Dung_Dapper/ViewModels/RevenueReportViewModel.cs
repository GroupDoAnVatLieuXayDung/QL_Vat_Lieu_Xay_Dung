using System;

namespace QL_Vat_Lieu_Xay_Dung_Dapper.ViewModels
{
    public class RevenueReportViewModel
    {
        public DateTime Date { get; set; }

        public decimal Revenue { get; set; }

        public decimal Profit { get; set; }
    }
}