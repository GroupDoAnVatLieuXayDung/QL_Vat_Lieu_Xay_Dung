using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(Guid id);

        Task<AppRoleViewModel> GetByName(string name);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        IQueryable<FunctionViewModel> GetListFunctionWithRole_Function(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);

        Task<bool> AddAsync(AppRoleViewModel userViewModel);

        Task<bool> UpdateAsync(AppRoleViewModel roleViewModel);

        Task<bool> DeleteAsync(Guid id);

        #region Realtime

        Task<bool> AddAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel roleViewModel);

        Task<bool> UpdateAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel roleViewModel);

        Task<bool> DeleteAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, Guid id);

        #endregion Realtime
    }
}