using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Dapper.ViewModels;

namespace QL_Vat_Lieu_Xay_Dung_Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}
