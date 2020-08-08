using System.Collections.Generic;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierViewModel> GetAll();
        GenericResult Add(SupplierViewModel supplierViewModel);
        GenericResult Update(SupplierViewModel supplierViewModel);
        GenericResult Delete(int id);
        SupplierViewModel GetById(int id);
        PagedResult<SupplierViewModel> GetAllPaging(string keyword, int page, int pageSize);
        #region Realtime
        GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, SupplierViewModel supplierViewModel);
        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, SupplierViewModel supplierViewModel);
        GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int id);
        #endregion

        void Save();
    }
}