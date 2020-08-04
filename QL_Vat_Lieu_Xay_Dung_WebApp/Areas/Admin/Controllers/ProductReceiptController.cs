using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Enum;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.Authorization;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductReceiptController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IProductReceiptService _productReceiptService;

        public ProductReceiptController(IProductReceiptService productReceiptService, IAuthorizationService authorizationService)
        {
            _productReceiptService = productReceiptService;
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "PRODUCT_RECEIPT", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Login/Index");
            }
            return View();
        }

        #region Get Data API
        [HttpGet]
        public IActionResult GetReceiptDetailsByProductId(int id)
        {
            var model = _productReceiptService.GetReceiptDetailsByProductId(id);
            return new OkObjectResult(model);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {

            var model = _productReceiptService.GetProductReceiptDetail(id);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult UpdateStatus(int receiptId, ReceiptStatus status)
        {
            _productReceiptService.UpdateStatus(receiptId, status);
            return new OkResult();
        }

        [HttpGet]
        public IActionResult GetAllPaging(string startDate, string endDate, string keyword, int page, int pageSize)
        {
            var model = _productReceiptService.GetAllPaging(startDate, endDate, keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(ProductReceiptViewModel productReceiptViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            if (productReceiptViewModel.Id == 0)
            {
                _productReceiptService.Create(productReceiptViewModel);
            }
            else
            {
                _productReceiptService.Update(productReceiptViewModel);
            }
            _productReceiptService.Save();
            return new OkObjectResult(productReceiptViewModel);
        }

        [HttpGet]
        public IActionResult GetReceiptStatus()
        {
            var enums = ((ReceiptStatus[])Enum.GetValues(typeof(ReceiptStatus)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }


        [HttpGet]
        public IActionResult GetSizes()
        {
            var sizes = _productReceiptService.GetSizes();
            return new OkObjectResult(sizes);
        }

        #endregion
    }
}
