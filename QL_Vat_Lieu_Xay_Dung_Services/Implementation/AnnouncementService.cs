using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System;
using System.Linq;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement, string> _announcementRepository;

        private readonly IRepository<AnnouncementUser, int> _announcementUserRepository;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IRepository<Announcement, string> announcementRepository,
            IRepository<AnnouncementUser, int> announcementUserRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _announcementUserRepository = announcementUserRepository;
            this._announcementRepository = announcementRepository;
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PagedResult<AnnouncementViewModel> GetAllUnReadPaging(Guid userId, int pageIndex, int pageSize)
        {
            var query = from x in _announcementRepository.FindAll()
                        join y in _announcementUserRepository.FindAll()
                            on x.Id equals y.AnnouncementId
                            into xy
                        from announceUser in xy.DefaultIfEmpty()
                        where announceUser.HasRead == false && (announceUser.UserId == null || announceUser.UserId == userId)
                        select x;
            var totalRow = query.Count();
            var model = _mapper.ProjectTo<AnnouncementViewModel>(
                query.OrderByDescending(x => x.DateCreated)
                .Skip(pageSize * (pageIndex - 1)).Take(pageSize))
                .ToList();
            var paginationSet = new PagedResult<AnnouncementViewModel>
            {
                ResultList = model,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public bool MarkAsRead(Guid userId, string id)
        {
            var result = false;
            var announce = _announcementUserRepository.FindSingle(x => x.AnnouncementId == id && x.UserId == userId);
            if (announce == null)
            {
                _announcementUserRepository.Add(new AnnouncementUser
                {
                    AnnouncementId = id,
                    UserId = userId,
                    HasRead = true
                });
                result = true;
            }
            else
            {
                if (announce.HasRead == false)
                {
                    announce.HasRead = true;
                    _announcementUserRepository.Update(announce);
                    result = true;
                }
            }
            return result;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}