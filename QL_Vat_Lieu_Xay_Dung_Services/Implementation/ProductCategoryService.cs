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
using System.Linq;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<ProductCategory, int> _productCategoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Announcement, string> _announceRepository;

        private readonly IRepository<AnnouncementUser, int> _announceUserRepository;

        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IRepository<Announcement, string> announceRepository, IRepository<AnnouncementUser, int> announceUserRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _announceRepository = announceRepository;
            _announceUserRepository = announceUserRepository;
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

        #region RealTime

        public GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers,
            ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryViewModel);
                _productCategoryRepository.Add(productCategory);
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

        public GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers,
            ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryViewModel);
                _productCategoryRepository.Update(productCategory);
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
                _productCategoryRepository.Remove(id);
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

        #endregion RealTime

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