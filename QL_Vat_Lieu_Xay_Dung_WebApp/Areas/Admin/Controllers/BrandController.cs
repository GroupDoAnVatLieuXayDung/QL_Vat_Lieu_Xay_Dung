using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_WebApp.Authorization;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBrandService _brandService;

        public BrandController(IAuthorizationService authorizationService, IBrandService brandService)
        {
            _authorizationService = authorizationService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "Brand", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Login/Index");
            }
            return View();
        }
        #region Get Data API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _brandService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(BrandViewModel brandViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (brandViewModel.Id == 0)
                {
                    _brandService.Add(brandViewModel);
                }
                else
                {
                    _brandService.Update(brandViewModel);
                }
                _brandService.Save();
                return new OkObjectResult(brandViewModel);

            }
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _brandService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _brandService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                _brandService.Delete(id);
                _brandService.Save();
                return new OkObjectResult(id);
            }
        }


        #endregion
    }
}
