using AutoMapper;
using AutoMapper.QueryableExtensions;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, int> _productRepository;

        private readonly IRepository<Tag, string> _tagRepository;

        private readonly IRepository<ProductTag, int> _productTagRepository;

        private readonly IRepository<ProductReceiptDetail, int> _productReceiptDetailRepository;

        private readonly IRepository<ProductImage, int> _productImageRepository;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Brand, int> _brandRepository;

        private readonly IRepository<Announcement, string> _announceRepository;

        private readonly IRepository<AnnouncementUser, int> _announceUserRepository;

        public ProductService(IRepository<Product, int> productRepository, IMapper mapper, IRepository<Tag, string> tagRepository, IUnitOfWork unitOfWork, IRepository<ProductTag, int> productTagRepository, IRepository<ProductReceiptDetail, int> productReceiptDetailRepository, IRepository<ProductImage, int> productImageRepository, IRepository<Brand, int> brandRepository, IRepository<Announcement, string> announceRepository, IRepository<AnnouncementUser, int> announceUserRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _productTagRepository = productTagRepository;
            _productReceiptDetailRepository = productReceiptDetailRepository;
            _productImageRepository = productImageRepository;
            _brandRepository = brandRepository;
            _announceRepository = announceRepository;
            _announceUserRepository = announceUserRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public GenericResult Add(ProductViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
                if (!string.IsNullOrEmpty(productViewModel.Tags))
                {
                    var productTags = new List<ProductTag>();
                    var tags = productViewModel.Tags.Split(',');
                    foreach (var t in tags)
                    {
                        var tagId = AliasHelper.ConvertToAlias(t.Trim());
                        if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                        {
                            _tagRepository.Add(new Tag { Id = tagId, Name = t });
                        }
                        productTags.Add(new ProductTag { TagId = tagId });
                    }

                    foreach (var productTag in productTags)
                    {
                        product.ProductTags.Add(productTag);
                    }
                }
                _productRepository.Add(product);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(ProductViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
                if (!string.IsNullOrEmpty(productViewModel.Tags))
                {
                    var productTags = new List<ProductTag>();
                    var tags = productViewModel.Tags.Split(',');
                    foreach (var t in tags)
                    {
                        var tagId = AliasHelper.ConvertToAlias(t.Trim());
                        if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                        {
                            _tagRepository.Add(new Tag { Id = tagId, Name = t });
                        }

                        _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productViewModel.Id)
                            .ToList());
                        productTags.Add(new ProductTag { TagId = tagId });
                    }

                    foreach (var productTag in productTags)
                    {
                        product.ProductTags.Add(productTag);
                    }
                }
                _productRepository.Update(product);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public GenericResult Delete(int id)
        {
            try
            {
                _productRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public int UpdateViewCount(int id)
        {
            var model = _productRepository.FindById(id);
            model.ViewCount += 1;
            _productRepository.Update(model);
            Save();
            return model.ViewCount.HasValue ? model.ViewCount.Value : 0;
        }

        public ProductViewModel GetById(int id)
        {
            var model = _mapper.Map<Product, ProductViewModel>(_productRepository.FindSingle(x => x.Id == id));
            model.Brand = _mapper.Map<Brand, BrandViewModel>(_brandRepository.FindById(model.BrandId));
            return model;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, int? brandId, string keyword, int page, int pageSize, string sort = null, string tag = null)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(tag))
            {
                var getTmpTag = _tagRepository.FindById(tag);
                query = query.Where(x => x.Tags.Contains(getTmpTag.Name));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            if (brandId.HasValue)
            {
                query = query.Where(x => x.BrandId == brandId.Value);
            }
            // switch expression của linq
            query = sort switch
            {
                "name" => query.OrderByDescending(x => x.Name),
                "price_low_to_high" => query.OrderBy(x => x.Price),
                "price_high_to_low" => query.OrderByDescending(x => x.Price),
                "price_sell" => query.OrderByDescending(x => x.PromotionPrice.Value),
                _ => query.OrderByDescending(x => x.DateCreated)
            };
            var totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                ResultList = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public List<ProductViewModel> GetAllSearch(int? categoryId, string keyword)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            query = query.OrderByDescending(x => x.DateCreated);
            var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();
            return data;
        }

        public GenericResult AddImages(int productId, string[] images)
        {
            try
            {
                _productImageRepository.RemoveMultiple(_productImageRepository.FindAll(x => x.ProductId == productId).ToList());
                foreach (var image in images)
                {
                    _productImageRepository.Add(new ProductImage()
                    {
                        Path = image,
                        ProductId = productId,
                        Caption = string.Empty
                    });
                }
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        #region MyRegion

        public GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
                if (!string.IsNullOrEmpty(productViewModel.Tags))
                {
                    var productTags = new List<ProductTag>();
                    var tags = productViewModel.Tags.Split(',');
                    foreach (var t in tags)
                    {
                        var tagId = AliasHelper.ConvertToAlias(t.Trim());
                        if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                        {
                            _tagRepository.Add(new Tag { Id = tagId, Name = t });
                        }
                        productTags.Add(new ProductTag { TagId = tagId });
                    }

                    foreach (var productTag in productTags)
                    {
                        product.ProductTags.Add(productTag);
                    }
                }
                _productRepository.Add(product);
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

        public GenericResult AddImages(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int productId,
            string[] images)
        {
            try
            {
                _productImageRepository.RemoveMultiple(_productImageRepository.FindAll(x => x.ProductId == productId).ToList());
                foreach (var image in images)
                {
                    _productImageRepository.Add(new ProductImage()
                    {
                        Path = image,
                        ProductId = productId,
                        Caption = string.Empty
                    });
                }
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

        public GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, ProductViewModel productViewModel)
        {
            try
            {
                var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
                if (!string.IsNullOrEmpty(productViewModel.Tags))
                {
                    var productTags = new List<ProductTag>();
                    var tags = productViewModel.Tags.Split(',');
                    foreach (var t in tags)
                    {
                        var tagId = AliasHelper.ConvertToAlias(t.Trim());
                        if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                        {
                            _tagRepository.Add(new Tag { Id = tagId, Name = t });
                        }

                        _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productViewModel.Id)
                            .ToList());
                        productTags.Add(new ProductTag { TagId = tagId });
                    }

                    foreach (var productTag in productTags)
                    {
                        product.ProductTags.Add(productTag);
                    }
                }
                _productRepository.Update(product);
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

        public GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, int id)
        {
            try
            {
                _productRepository.Remove(id);
                // Real Time
                var announcement = _mapper.Map<AnnouncementViewModel, Announcement>(announcementViewModel);
                _announceRepository.Add(announcement);
                foreach (var announcementUserViewModel in announcementUsers)
                {
                    _announceUserRepository.Add(_mapper.Map<AnnouncementUserViewModel, AnnouncementUser>(announcementUserViewModel));
                }
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        #endregion MyRegion

        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _mapper.ProjectTo<ProductImageViewModel>(
                _productImageRepository.FindAll(x => x.ProductId == productId)
            ).ToList();
        }

        public List<ProductViewModel> GetNewProducts(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.Status == Status.Active).OrderByDescending(x => x.DateCreated)
                .Take(top)).ToList();
        }

        public List<ProductViewModel> GetHotProducts(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)).ToList();
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.FindById(id);
            return _mapper.ProjectTo<ProductViewModel>(
                    _productRepository.FindAll(x => x.Status == Status.Active
                                                    && x.Id != id && x.CategoryId == product.CategoryId)
                        .OrderByDescending(x => x.DateCreated)
                        .Take(top))
                .ToList();
        }

        public TagViewModel GetTagById(string id)
        {
            return _mapper.Map<Tag, TagViewModel>(_tagRepository.FindById(id));
        }

        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(
                _productRepository.FindAll(x => x.PromotionPrice != null)
                    .OrderByDescending(x => x.DateModified)
                    .Take(top)).ToList();
        }

        public List<TagViewModel> GetProductTags(int productId)
        {
            return _tagRepository.FindAll().Join(_productTagRepository.FindAll(), t => t.Id, p => p.TagId, (x, y) =>
                new TagViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        public bool CheckAvailability(int productId, int size)
        {
            var quantity = _productReceiptDetailRepository.FindAll(x => x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.FirstOrDefault(x => x.Quantity > 0) != null ? true : false;
        }
    }
}