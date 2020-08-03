using System.Collections.Generic;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userViewModel);
        Task<bool> DeleteAsync(string id);
        Task<List<AppUserViewModel>> GetAllAsync();
        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
        Task<AppUserViewModel> GetById(string id);
        Task<bool> UpdateAsync(AppUserViewModel userViewModel);
    }
}