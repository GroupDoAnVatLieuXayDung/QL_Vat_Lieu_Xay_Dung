using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class ProductReceiptService : IProductReceiptService
    {
        private readonly IRepository<ProductReceipt, int> _productReceiptRepository;
        private readonly IRepository<ProductReceiptDetail, int> _productReceiptDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Size, int> _sizeRepository;

        public ProductReceiptService(IRepository<ProductReceipt, int> productReceiptRepository, IRepository<ProductReceiptDetail, int> productReceiptDetailRepository, IMapper mapper, IUnitOfWork unitOfWork, IRepository<Product, int> productRepository, IRepository<Size, int> sizeRepository)
        {
            _productReceiptRepository = productReceiptRepository;
            _productReceiptDetailRepository = productReceiptDetailRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
        }

        public GenericResult Create(ProductReceiptViewModel productReceiptViewModel)
        {
            try
            {
                var receipt = _mapper.Map<ProductReceiptViewModel, ProductReceipt>(productReceiptViewModel);
                var receiptDetails = _mapper.Map<List<ProductReceiptDetailViewModel>,List<ProductReceiptDetail>>
                    (productReceiptViewModel.ProductReceiptDetails);
                foreach (var receiptDetail in receiptDetails)
                {
                    
                }
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(ProductReceiptViewModel productReceiptViewModel)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ProductReceiptViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<ProductReceiptViewModel> GetAllProductReceipt()
        {
            throw new NotImplementedException();
        }

        public ProductReceiptViewModel GetProductReceiptDetail(int productReceiptId)
        {
            throw new NotImplementedException();
        }

        public ProductReceiptDetailViewModel CreateProductReceiptDetail(ProductReceiptDetailViewModel productReceiptDetailViewModel)
        {
            throw new NotImplementedException();
        }

        public GenericResult DeleteDetail(int productId, int productReceiptId, int sizeId)
        {
            throw new NotImplementedException();
        }

        public List<ProductReceiptDetailViewModel> GetProductReceiptDetails(int productReceiptId)
        {
            throw new NotImplementedException();
        }

        public List<SizeViewModel> GetSizes()
        {
            throw new NotImplementedException();
        }

        public SizeViewModel GetSize(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
