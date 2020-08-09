using QL_Vat_Lieu_Xay_Dung_Dapper.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}