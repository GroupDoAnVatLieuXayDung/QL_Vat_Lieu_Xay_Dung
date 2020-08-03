using System;
using System.Collections.Generic;
using System.Text;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Interfaces
{
    public interface IProductCategoryService
    {
        GenericResult Add(ProductCategoryViewModel productCategoryViewModel);

        GenericResult Update(ProductCategoryViewModel productCategoryViewModel);

        GenericResult Delete(int id);

        List<ProductCategoryViewModel> GetByAlias(string alias);

        List<ProductCategoryViewModel> GetAll();

        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetAllByParentId(int parentId);

        ProductCategoryViewModel GetById(int id);

        GenericResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        GenericResult ReOrder(int sourceId, int targetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);

        void Save();
    }
}
