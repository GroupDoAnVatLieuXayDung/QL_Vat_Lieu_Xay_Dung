using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Constants;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Components
{
    public class SideBarViewComponents : ViewComponent
    {
        private readonly IFunctionService _functionService;

        private readonly IRoleService _roleService;

        public SideBarViewComponents(IFunctionService functionService, IRoleService roleService)
        {
            _functionService = functionService;
            _roleService = roleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> lstFunctionViewModels = null;
            var rolesSplit = roles.Split(";");
            if (rolesSplit.Contains(CommonConstants.AdminRole))
            {
                lstFunctionViewModels = await _functionService.GetAll();
            }
            else
            {
                foreach (var itemRole in rolesSplit)
                {
                    var roleModelView = await _roleService.GetByName(itemRole);
                    if (roleModelView.Id == null) continue;
                    var tmpQueryable = _roleService.GetListFunctionWithRole_Function(roleModelView.Id.Value).OrderBy(t => t.SortOrder).ToList();
                    if (lstFunctionViewModels == null)
                    {
                        lstFunctionViewModels = tmpQueryable;
                    }
                    else
                    {
                        lstFunctionViewModels.AddRange(tmpQueryable.Except(lstFunctionViewModels));
                    }
                }
            }
            return View(lstFunctionViewModels);
        }
    }
}