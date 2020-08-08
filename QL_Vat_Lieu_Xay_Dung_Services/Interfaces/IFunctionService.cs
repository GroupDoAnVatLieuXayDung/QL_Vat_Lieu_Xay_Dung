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
        GenericResult Add(FunctionViewModel function);

        Task<List<FunctionViewModel>> GetAll();

        //Mới thêm hàm ở đây
        List<FunctionViewModel> GetAll_List();

        IQueryable<FunctionViewModel> GetAllWithParentId(string parentId);

        FunctionViewModel GetById(string id);

        GenericResult Update(FunctionViewModel function);

        GenericResult Delete(string id);

        void Save();

        bool CheckExistedId(string id);

        GenericResult UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        GenericResult ReOrder(string sourceId, string targetId);
    }
}