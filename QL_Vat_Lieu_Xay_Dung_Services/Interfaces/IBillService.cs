using System;
using System.Collections.Generic;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IBillService
    {
        GenericResult Create(BillViewModel billViewModel);
        GenericResult Update(BillViewModel billViewModel);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);
        List<BillViewModel> GetAllBill();
        BillViewModel GetDetail(int billId);

        GenericResult CreateDetail(BillDetailViewModel billDetailViewModel);

        GenericResult DeleteDetail(int productId, int billId, int sizeId);

        GenericResult UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<SizeViewModel> GetSizes();

        SizeViewModel GetSize(int id);

        void Save();
    }
}
