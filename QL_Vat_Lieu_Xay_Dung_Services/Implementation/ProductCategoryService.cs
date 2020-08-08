using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCategory, int> _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;

        }
        public GenericResult Add(ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryViewModel);
                _productCategoryRepository.Add(productCategory);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryViewModel);
                _productCategoryRepository.Update(productCategory);
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
                _productCategoryRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }
        public List<ProductCategoryViewModel> GetByAlias(string alias)
        {
            return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository.FindAll(x => x.SeoAlias == alias)).ToList();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository.FindAll().OrderBy(x => x.ParentId))
                .ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                    .FindAll(x => x.Name.Contains(keyword)).OrderBy(x => x.ParentId)).ToList();

            }
            else
                return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository.FindAll().OrderBy(x => x.ParentId)).ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository.FindAll(x => x.Status == Status.Active && x.ParentId == parentId)).ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
        }

        public GenericResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            try
            {
                var sourceCategory = _productCategoryRepository.FindById(sourceId);
                sourceCategory.ParentId = targetId;
                _productCategoryRepository.Update(sourceCategory);

                var sibling = _productCategoryRepository.FindAll(x => items.Keys.Contains(x.Id));
                foreach (var child in sibling)
                {
                    child.SortOrder = items[child.Id];
                    _productCategoryRepository.Update(child);
                }
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }

        }

        public GenericResult ReOrder(int sourceId, int targetId)
        {
            try
            {
                var source = _productCategoryRepository.FindById(sourceId);
                var target = _productCategoryRepository.FindById(targetId);
                var tmpOrder = source.SortOrder;
                source.SortOrder = target.SortOrder;
                target.SortOrder = tmpOrder;
                _productCategoryRepository.Update(source);
                _productCategoryRepository.Update(target);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }
        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            //var temp = _productCategoryRepository
            //    .FindAll(x => x.HomeFlag == true, c => c.Products).ToList();
            var model = _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                .FindAll(x => x.HomeFlag == true).OrderBy(x => x.HomeOrder)
                .Take(top)).ToList();
            return model;

        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
