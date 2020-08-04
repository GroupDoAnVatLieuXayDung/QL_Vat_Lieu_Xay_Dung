using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
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
                var receiptDetails = _mapper.Map<List<ProductReceiptDetailViewModel>, List<ProductReceiptDetail>>(productReceiptViewModel.ProductReceiptDetails);
                foreach (var receiptDetail in receiptDetails)
                {
                    var product = _productRepository.FindById(receiptDetail.ProductId);
                    if (product.Price == 0 || product.Price < receiptDetail.OriginalPrice)
                    {
                        product.Price = receiptDetail.OriginalPrice + (receiptDetail.OriginalPrice * 10 / 100);
                        _productRepository.Update(product);
                    }
                }

                receipt.Total = receiptDetails.Sum(x => x.OriginalPrice * x.Quantity);
                _productReceiptRepository.Add(receipt);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(ProductReceiptViewModel productReceiptViewModel)
        {
            try
            {
                // Mapping to order domain
                var receipt = _mapper.Map<ProductReceiptViewModel, ProductReceipt>(productReceiptViewModel);
                // Lấy Toàn Bộ Chi Tiết Hóa Đơn Ra Sau Khi Mapping Vào
                var recriptDetails = receipt.ProductReceiptDetails;
                // Them 1 chi tiet hoa don
                var addDetails = recriptDetails.Where(x => x.Id == 0).ToList();
                // Update Chi Tiet hoa don
                var updateDetails = recriptDetails.Where(x => x.Id != 0).ToList();
                // Existed Details
                var existedDetails = _productReceiptDetailRepository.FindAll(x => x.ProductReceiptId == productReceiptViewModel.Id).ToList();
                //Clear db
                receipt.ProductReceiptDetails.Clear();
                _productReceiptDetailRepository.RemoveMultiple(existedDetails.Except(updateDetails).ToList());
                foreach (var receiptDetail in updateDetails)
                {
                    var product = _productRepository.FindById(receiptDetail.ProductId);
                    if (product.Price == 0 || product.Price < receiptDetail.OriginalPrice)
                    {
                        product.Price = receiptDetail.OriginalPrice + (receiptDetail.OriginalPrice * 10 / 100);
                        _productRepository.Update(product);
                    }
                    _productReceiptDetailRepository.Update(receiptDetail);
                }

                foreach (var receiptDetail in addDetails)
                {
                    var product = _productRepository.FindById(receiptDetail.ProductId);
                    if (product.Price == 0 || product.Price < receiptDetail.OriginalPrice)
                    {
                        product.Price = receiptDetail.OriginalPrice + (receiptDetail.OriginalPrice * 10 / 100);
                        _productRepository.Update(product);
                    }
                    _productReceiptDetailRepository.Add(receiptDetail);
                }

                receipt.Total = updateDetails.Sum(x => x.Quantity * x.OriginalPrice) + addDetails.Sum(x => x.Quantity * x.OriginalPrice);
                _productReceiptRepository.Update(receipt);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public PagedResult<ProductReceiptViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            var query = _productReceiptRepository.FindAll();
            if (!string.IsNullOrEmpty(startDate))
            {
                var start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated >= start);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                var end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Supplier.FullName.Contains(keyword) || x.Supplier.PhoneNumber.Contains(keyword));
            }

            var totalRow = query.Count();
            var data = _mapper.ProjectTo<ProductReceiptViewModel>(query.OrderByDescending(x => x.DateCreated)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize))
                .ToList();
            return new PagedResult<ProductReceiptViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                ResultList = data,
                RowCount = totalRow
            };
        }

        public List<ProductReceiptViewModel> GetAllProductReceipt()
        {
            return _mapper.ProjectTo<ProductReceiptViewModel>(_productReceiptRepository.FindAll()).ToList();

        }

        public ProductReceiptViewModel GetProductReceiptDetail(int productReceiptId)
        {
            var productReceiptViewModel = _mapper.Map<ProductReceipt, ProductReceiptViewModel>(_productReceiptRepository.FindSingle(x => x.Id == productReceiptId));
            var productReceiptDetailViewModel = _mapper.ProjectTo<ProductReceiptDetailViewModel>(_productReceiptDetailRepository.FindAll(x => x.ProductReceiptId == productReceiptId)).ToList();
            productReceiptViewModel.ProductReceiptDetails = productReceiptDetailViewModel;
            return productReceiptViewModel;
        }

        public GenericResult CreateProductReceiptDetail(ProductReceiptDetailViewModel productReceiptDetailViewModel)
        {
            try
            {
                var productReceiptDetail = _mapper.Map<ProductReceiptDetailViewModel, ProductReceiptDetail>(productReceiptDetailViewModel);
                _productReceiptDetailRepository.Add(productReceiptDetail);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult DeleteDetail(int productId, int productReceiptId, int sizeId)
        {
            try
            {
                var detail = _productReceiptDetailRepository.FindSingle(x =>
                    x.ProductId == productId && x.ProductReceiptId == productReceiptId && x.SizeId == sizeId);
                _productReceiptDetailRepository.Remove(detail);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public List<ProductReceiptDetailViewModel> GetProductReceiptDetails(int productReceiptId)
        {
            var model = _mapper
                .ProjectTo<ProductReceiptDetailViewModel>(_productReceiptDetailRepository.FindAll(x => x.ProductReceiptId == productReceiptId)).ToList();
            return model;
        }

        public List<SizeViewModel> GetSizes()
        {
            return _mapper.ProjectTo<SizeViewModel>(_sizeRepository.FindAll()).ToList();

        }
        public List<ProductReceiptDetailViewModel> GetReceiptDetailsByProductId(int productId)
        {
            var model = _mapper.ProjectTo<ProductReceiptDetailViewModel>(
                    _productReceiptDetailRepository.FindAll(x => x.ProductId == productId && x.Quantity > 0).Distinct())
                .ToList();
            return model;
        }
        public SizeViewModel GetSize(int id)
        {
            return _mapper.Map<Size, SizeViewModel>(_sizeRepository.FindById(id));

        }
        public GenericResult UpdateStatus(int receiptId, ReceiptStatus status)
        {
            try
            {
                var receipt = _productReceiptRepository.FindById(receiptId);
                receipt.ReceiptStatus = status;
                _productReceiptRepository.Update(receipt);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
