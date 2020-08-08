using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Brand, int> _brandRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Announcement, string> _announceRepository;
        private readonly IRepository<AnnouncementUser, int> _announceUserRepository;

        public BrandService(IRepository<Brand, int> brandRepository, IUnitOfWork unitOfWork, IMapper mapper, IRepository<Announcement, string> announceRepository, IRepository<AnnouncementUser, int> announceUserRepository)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _announceRepository = announceRepository;
            _announceUserRepository = announceUserRepository;
        }

        public List<BrandViewModel> GetAll()
        {
            return _mapper.ProjectTo<BrandViewModel>(_brandRepository.FindAll()).ToList();
        }

        public GenericResult Add(BrandViewModel brandViewModel)
        {
            try
            {
                _brandRepository.Add(_mapper.Map<BrandViewModel, Brand>(brandViewModel));

                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(BrandViewModel brandViewModel)
        {
            try
            {
                _brandRepository.Update(_mapper.Map<BrandViewModel, Brand>(brandViewModel));
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
                _brandRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, BrandViewModel brandViewModel)
        {
            try
            {
                _brandRepository.Add(_mapper.Map<BrandViewModel, Brand>(brandViewModel));
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
            BrandViewModel brandViewModel)
        {

            try
            {
                _brandRepository.Update(_mapper.Map<BrandViewModel, Brand>(brandViewModel));
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
                _brandRepository.Remove(id);
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

        public BrandViewModel GetById(int id)
        {
            return _mapper.Map<Brand, BrandViewModel>(_brandRepository.FindById(id));
        }

        public PagedResult<BrandViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _brandRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            var totalRow = query.Count();
            query = query.OrderBy(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<BrandViewModel>(query).ToList();
            var paginationSet = new PagedResult<BrandViewModel>()
            {
                ResultList = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public void Save()
        {
           _unitOfWork.Commit();
        }
    }
}
