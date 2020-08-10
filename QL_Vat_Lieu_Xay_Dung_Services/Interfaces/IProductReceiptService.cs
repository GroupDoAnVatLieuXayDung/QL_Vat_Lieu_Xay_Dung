using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System.Collections.Generic;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IProductReceiptService
    {
        PagedResult<ProductReceiptViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);

        List<ProductReceiptViewModel> GetAllProductReceipt();

        ProductReceiptViewModel GetProductReceiptDetail(int productReceiptId);

        List<ProductReceiptDetailViewModel> GetReceiptDetailsByProductId(int productId);

        List<ProductReceiptDetailViewModel> GetProductReceiptDetails(int productReceiptId);

        GenericResult Create(ProductReceiptViewModel productReceiptViewModel);

        GenericResult Update(ProductReceiptViewModel productReceiptViewModel);

        GenericResult UpdateStatus(int receiptId, ReceiptStatus status);

        GenericResult CreateProductReceiptDetail(ProductReceiptDetailViewModel productReceiptDetailViewModel);

        GenericResult DeleteDetail(int productId, int productReceiptId, int sizeId);

        #region Realtime

        GenericResult Create(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductReceiptViewModel productReceiptViewModel);

        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductReceiptViewModel productReceiptViewModel);

        #endregion Realtime

        //Size
        List<SizeViewModel> GetSizes();

        SizeViewModel GetSize(int id);

        void Save();
    }
}