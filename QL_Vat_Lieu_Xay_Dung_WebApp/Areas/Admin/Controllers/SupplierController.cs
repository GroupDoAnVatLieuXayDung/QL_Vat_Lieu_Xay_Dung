using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IAuthorizationService _authorizationService;

        public SupplierController(IAuthorizationService authorizationService, ISupplierService supplierService)
        {
            _authorizationService = authorizationService;
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Get Data API


        [HttpPost]
        public IActionResult SaveEntity(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (supplierViewModel.Id == 0)
                {
                    _supplierService.Add(supplierViewModel);
                }
                else
                {
                    _supplierService.Update(supplierViewModel);
                }
                _supplierService.Save();
                return new OkObjectResult(supplierViewModel);

            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(_supplierService.GetAll());
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _supplierService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _supplierService.GetById(id);
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
                _supplierService.Delete(id);
                _supplierService.Save();
                return new OkObjectResult(id);
            }
        }


        #endregion
    }
}
