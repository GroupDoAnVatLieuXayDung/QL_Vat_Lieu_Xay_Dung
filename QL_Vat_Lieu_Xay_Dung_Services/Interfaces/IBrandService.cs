using System.Collections.Generic;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IBrandService
    {
        List<BrandViewModel> GetAll();
        GenericResult Add(BrandViewModel brandViewModel);
        GenericResult Update(BrandViewModel brandViewModel);
        GenericResult Delete(int id);
        #region Realtime
        GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, BrandViewModel brandViewModel);
        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, BrandViewModel brandViewModel);
        GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int id);
        #endregion

        BrandViewModel GetById(int id);
        PagedResult<BrandViewModel> GetAllPaging(string keyword, int page, int pageSize);
        void Save();
    }
}