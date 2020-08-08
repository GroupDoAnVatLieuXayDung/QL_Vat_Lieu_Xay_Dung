using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IFunctionService : IDisposable
    {
        Task<List<FunctionViewModel>> GetAll();

        IQueryable<FunctionViewModel> GetAllWithParentId(string parentId);

        FunctionViewModel GetById(string id);
        GenericResult Add(FunctionViewModel functionViewModel);
        GenericResult Update(FunctionViewModel functionViewModel);

        GenericResult Delete(string id);
        #region Realtime
        GenericResult Add(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, FunctionViewModel functionViewModel);
        GenericResult Update(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, FunctionViewModel functionViewModel);
        GenericResult Delete(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel> announcementUsers, string id);
        #endregion
        void Save();

        bool CheckExistedId(string id);

        GenericResult UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        GenericResult ReOrder(string sourceId, string targetId);
    }
}