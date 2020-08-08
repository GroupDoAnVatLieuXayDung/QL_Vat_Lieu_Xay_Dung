using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class SlideService : ISlideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Slide, int> _slideRepository;
        private readonly IMapper _mapper;

        public SlideService(IRepository<Slide, int> slideRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _slideRepository = slideRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _mapper.ProjectTo<SlideViewModel>(
                    _slideRepository.FindAll(x => x.Status == Status.Active && x.GroupAlias == groupAlias))
                .ToList();
        }

        public GenericResult Add(SlideViewModel slideViewModel)
        {
            try
            {
                _slideRepository.Add(_mapper.Map<SlideViewModel, Slide>(slideViewModel));
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(SlideViewModel slideViewModel)
        {

            try
            {
                _slideRepository.Update(_mapper.Map<SlideViewModel, Slide>(slideViewModel));
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
                _slideRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public SlideViewModel GetById(int id)
        {
            return _mapper.Map<Slide, SlideViewModel>(_slideRepository.FindById(id));
        }

        public PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _slideRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            var totalRow = query.Count();
            query = query.OrderBy(x => x.GroupAlias).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<SlideViewModel>(query).ToList();
            var paginationSet = new PagedResult<SlideViewModel>()
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
