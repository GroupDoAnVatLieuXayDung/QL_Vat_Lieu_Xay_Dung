using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IProductService : IDisposable
    {
        //void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        //List<ProductQuantityViewModel> GetQuantities(int productId);
        List<ProductViewModel> GetAll();

        GenericResult Add(ProductViewModel productViewModel);

        GenericResult Update(ProductViewModel productViewModel);

        GenericResult Delete(int id);

        GenericResult AddImages(int productId, string[] images);

        #region Realtime

        GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductViewModel productViewModel);

        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductViewModel productViewModel);

        GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int id);

        GenericResult AddImages(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int productId, string[] images);

        #endregion Realtime

        int UpdateViewCount(int id);

        ProductViewModel GetById(int id);

        void Save();

        TagViewModel GetTagById(string id);

        List<ProductImageViewModel> GetImages(int productId);

        List<ProductViewModel> GetAllSearch(int? categoryId, string keyword);

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, int? brandId, string keyword, int page, int pageSize, string sort = null, string tag = null);

        List<ProductViewModel> GetHotProducts(int top);

        List<ProductViewModel> GetNewProducts(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<ProductViewModel> GetUpsellProducts(int top);

        List<TagViewModel> GetProductTags(int productId);

        bool CheckAvailability(int productId, int size);
    }
}