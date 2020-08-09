using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System.Collections.Generic;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IProductCategoryService
    {
        List<ProductCategoryViewModel> GetByAlias(string alias);

        List<ProductCategoryViewModel> GetAll();

        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetAllByParentId(int parentId);

        ProductCategoryViewModel GetById(int id);

        GenericResult Add(ProductCategoryViewModel productCategoryViewModel);

        GenericResult Update(ProductCategoryViewModel productCategoryViewModel);

        GenericResult Delete(int id);

        GenericResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        GenericResult ReOrder(int sourceId, int targetId);

        #region Realtime

        GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductCategoryViewModel productCategoryViewModel);

        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductCategoryViewModel productCategoryViewModel);

        GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int id);

        #endregion Realtime

        List<ProductCategoryViewModel> GetHomeCategories(int top);

        void Save();
    }
}