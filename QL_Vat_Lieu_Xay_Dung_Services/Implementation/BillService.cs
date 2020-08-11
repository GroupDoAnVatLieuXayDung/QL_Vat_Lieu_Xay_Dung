using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Size = QL_Vat_Lieu_Xay_Dung_Data.Entities.Size;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill, int> _orderRepository;

        private readonly IRepository<BillDetail, int> _orderDetailRepository;

        private readonly IRepository<Size, int> _sizeRepository;

        private readonly IRepository<Product, int> _productRepository;

        private readonly IRepository<Announcement, string> _announceRepository;

        private readonly IRepository<AnnouncementUser, int> _announceUserRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IRepository<ProductReceiptDetail, int> _productQuantityRepository;

        public BillService(IRepository<Bill, int> orderRepository,
            IRepository<BillDetail, int> orderDetailRepository,
            IRepository<Product, int> productRepository,
            IRepository<Size, int> sizeRepository,
            IUnitOfWork unitOfWork, IMapper mapper, IRepository<ProductReceiptDetail, int> productQuantityRepository, IRepository<Announcement, string> announceRepository, IRepository<AnnouncementUser, int> announceUserRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _sizeRepository = sizeRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productQuantityRepository = productQuantityRepository;
            _announceRepository = announceRepository;
            _announceUserRepository = announceUserRepository;
        }

        public PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            var query = _orderRepository.FindAll();
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
                query = query.Where(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            }

            var totalRow = query.Count();
            var data = _mapper.ProjectTo<BillViewModel>(query.OrderByDescending(x => x.DateCreated)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize))
                .ToList();
            return new PagedResult<BillViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                ResultList = data,
                RowCount = totalRow
            };
        }

        public List<BillViewModel> GetAllBill()
        {
            return _mapper.ProjectTo<BillViewModel>(_orderRepository.FindAll()).ToList();
        }

        public BillViewModel GetDetail(int billId)
        {
            var billViewModel = _mapper.Map<Bill, BillViewModel>(_orderRepository.FindSingle(x => x.Id == billId));
            var billDetailViewModel = _mapper.ProjectTo<BillDetailViewModel>(_orderDetailRepository.FindAll(x => x.BillId == billId)).ToList();
            billViewModel.BillDetails = billDetailViewModel;
            return billViewModel;
        }

        public GenericResult CreateDetail(BillDetailViewModel billDetailViewModel)
        {
            try
            {
                var billDetail = _mapper.Map<BillDetailViewModel, BillDetail>(billDetailViewModel);
                _orderDetailRepository.Add(billDetail);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult DeleteDetail(int productId, int billId, int sizeId)
        {
            try
            {
                var detail = _orderDetailRepository.FindSingle(x =>
                    x.ProductId == productId && x.BillId == billId && x.SizeId == sizeId);
                _orderDetailRepository.Remove(detail);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public GenericResult UpdateStatus(int orderId, BillStatus status)
        {
            try
            {
                var order = _orderRepository.FindById(orderId);
                order.BillStatus = status;
                _orderRepository.Update(order);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public GenericResult Create(BillViewModel billViewModel)
        {
            try
            {
                var order = _mapper.Map<BillViewModel, Bill>(billViewModel);

                var orderDetails = _mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billViewModel.BillDetails).AsReadOnly();

                foreach (var productDetail in orderDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                    if (productDetail.Product != null && productDetail.Size != null)
                    {
                        productDetail.Size = null;
                        productDetail.Product = null;
                    }
                }

                order.BillDetails = orderDetails;
                order.Total = orderDetails.Sum(x => x.Price * x.Quantity);
                _orderRepository.Add(order);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception ex)
            {
                var tmp = ex.Message;
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(BillViewModel billViewModel)
        {
            try
            {
                // Mapping to order domain
                var order = _mapper.Map<BillViewModel, Bill>(billViewModel);
                // Lấy Toàn Bộ Chi Tiết Hóa Đơn Ra Sau Khi Mapping Vào
                var orderDetails = order.BillDetails;
                // Them 1 chi tiet hoa don
                var addDetails = orderDetails.Where(x => x.Id == 0).ToList();
                // Update Chi Tiet hoa don
                var updateDetails = orderDetails.Where(x => x.Id != 0).ToList();
                // Existed Details
                var existedDetails = _orderDetailRepository.FindAll(x => x.BillId == billViewModel.Id).ToList();
                //Clear db
                order.BillDetails.Clear();
                _orderDetailRepository.RemoveMultiple(existedDetails.Except(updateDetails).ToList());
                foreach (var productDetail in updateDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                    _orderDetailRepository.Update(productDetail);
                }

                foreach (var productDetail in addDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                    _orderDetailRepository.Add(productDetail);
                }

                order.Total = updateDetails.Sum(x => x.Quantity * x.Price) + addDetails.Sum(x => x.Quantity * x.Price);
                _orderRepository.Update(order);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        #region RealTime SingalR

        public GenericResult Create(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, BillViewModel billViewModel)
        {
            try
            {
                var order = _mapper.Map<BillViewModel, Bill>(billViewModel);
                var orderDetails = _mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billViewModel.BillDetails);
                foreach (var productDetail in orderDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                }

                order.Total = orderDetails.Sum(x => x.Price * x.Quantity);
                order.BillDetails = orderDetails;
                _orderRepository.Add(order);
                // Real Time
                var announcement = _mapper.Map<AnnouncementViewModel, Announcement>(announcementViewModel);
                _announceRepository.Add(announcement);
                foreach (var announcementUserViewModel in announcementUsers)
                {
                    _announceUserRepository.Add(_mapper.Map<AnnouncementUserViewModel, AnnouncementUser>(announcementUserViewModel));
                }
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, BillViewModel billViewModel)
        {
            try
            {
                // Mapping to order domain
                var order = _mapper.Map<BillViewModel, Bill>(billViewModel);
                // Lấy Toàn Bộ Chi Tiết Hóa Đơn Ra Sau Khi Mapping Vào
                var orderDetails = order.BillDetails;
                // Them 1 chi tiet hoa don
                var addDetails = orderDetails.Where(x => x.Id == 0).ToList();
                // Update Chi Tiet hoa don
                var updateDetails = orderDetails.Where(x => x.Id != 0).ToList();
                // Existed Details
                var existedDetails = _orderDetailRepository.FindAll(x => x.BillId == billViewModel.Id).ToList();
                //Clear db
                order.BillDetails.Clear();
                _orderDetailRepository.RemoveMultiple(existedDetails.Except(updateDetails).ToList());
                foreach (var productDetail in updateDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                    _orderDetailRepository.Update(productDetail);
                }

                foreach (var productDetail in addDetails)
                {
                    var product = _productRepository.FindById(productDetail.ProductId);
                    productDetail.Price = product.Price;
                    _orderDetailRepository.Add(productDetail);
                }

                order.Total = updateDetails.Sum(x => x.Quantity * x.Price) + addDetails.Sum(x => x.Quantity * x.Price);
                _orderRepository.Update(order);
                // Real Time
                var announcement = _mapper.Map<AnnouncementViewModel, Announcement>(announcementViewModel);
                _announceRepository.Add(announcement);
                foreach (var announcementUserViewModel in announcementUsers)
                {
                    _announceUserRepository.Add(_mapper.Map<AnnouncementUserViewModel, AnnouncementUser>(announcementUserViewModel));
                }
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        #endregion RealTime SingalR

        public List<BillDetailViewModel> GetBillDetails(int billId)
        {
            var model = _mapper
                .ProjectTo<BillDetailViewModel>(_orderDetailRepository.FindAll(x => x.BillId == billId)).ToList();
            return model;
        }

        public List<SizeViewModel> GetSizes()
        {
            return _mapper.ProjectTo<SizeViewModel>(_sizeRepository.FindAll()).ToList();
        }

        public SizeViewModel GetSize(int id)
        {
            return _mapper.Map<Size, SizeViewModel>(_sizeRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}