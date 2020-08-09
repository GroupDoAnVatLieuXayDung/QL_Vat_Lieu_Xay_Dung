using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IUserService
    {
        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);

        Task<bool> AddAsync(AppUserViewModel userViewModel);

        Task<bool> UpdateAsync(AppUserViewModel userViewModel);

        Task<bool> DeleteAsync(string id);

        #region Realtime

        Task<bool> AddAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, AppUserViewModel userViewModel);

        Task<bool> UpdateAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, AppUserViewModel userViewModel);

        Task<bool> DeleteAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, string id);

        #endregion Realtime
    }
}