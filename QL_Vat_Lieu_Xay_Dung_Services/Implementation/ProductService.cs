using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_Utilities.Helpers;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product, int> productRepository, IMapper mapper, IRepository<Tag, string> tagRepository, IUnitOfWork unitOfWork, IRepository<ProductTag, int> productTagRepository, IRepository<ProductQuantity, int> productQuantityRepository, IRepository<ProductImage, int> productImageRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _productTagRepository = productTagRepository;
            _productQuantityRepository = productQuantityRepository;
            _productImageRepository = productImageRepository;
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

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize, string sort = null)
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
            var quantity = _productQuantityRepository.FindSingle(x => x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.Quantity > 0;
        }



        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productQuantityRepository.RemoveMultiple(_productQuantityRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            return _mapper.ProjectTo<ProductQuantityViewModel>(
                    _productQuantityRepository.FindAll(x => x.ProductId == productId))
                .ToList();
        }
    }
}
