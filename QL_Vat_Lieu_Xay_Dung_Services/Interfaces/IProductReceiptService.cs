using System.Collections.Generic;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IProductReceiptService
    {
        GenericResult Create(ProductReceiptViewModel productReceiptViewModel);
        GenericResult Update(ProductReceiptViewModel productReceiptViewModel);

        PagedResult<ProductReceiptViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);
        List<ProductReceiptViewModel> GetAllProductReceipt();
        ProductReceiptViewModel GetProductReceiptDetail(int productReceiptId);
        List<ProductReceiptDetailViewModel> GetReceiptDetailsByProductId(int productId);

        GenericResult CreateProductReceiptDetail(ProductReceiptDetailViewModel productReceiptDetailViewModel);

        GenericResult DeleteDetail(int productId, int productReceiptId, int sizeId);

        List<ProductReceiptDetailViewModel> GetProductReceiptDetails(int productReceiptId);
        GenericResult UpdateStatus(int receiptId, ReceiptStatus status);
        List<SizeViewModel> GetSizes();

        SizeViewModel GetSize(int id);

        void Save();
    }
}