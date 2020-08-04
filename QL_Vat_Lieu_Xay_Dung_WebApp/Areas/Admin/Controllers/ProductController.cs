using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Helpers;
using QL_Vat_Lieu_Xay_Dung_WebApp.Authorization;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthorizationService _authorizationService;
        public ProductController(IProductService productService, IAuthorizationService authorizationService)
        {
            _productService = productService;
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "PRODUCT_LIST", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Login/Index");
            }
            return View();
        }

        #region AJAX API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword,int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId, null, keyword, page , pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return  new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
               var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                productViewModel.SeoAlias = AliasHelper.ConvertToAlias(productViewModel.Name);
                if (productViewModel.Id == 0)
                {
                    _productService.Add(productViewModel);
                }
                else
                {
                    _productService.Update(productViewModel);
                }
                _productService.Save();
                return new OkObjectResult(productViewModel);
            }
        }

        //[HttpPost]
        //public IActionResult SaveQuantities(int productId, List<ProductQuantityViewModel> quantities)
        //{
        //    _productService.AddQuantity(productId, quantities);
        //    _productService.Save();
        //    return new OkObjectResult(quantities);
        //}

        //[HttpGet]
        //public IActionResult GetQuantities(int productId)
        //{
        //    var quantities = _productService.GetQuantities(productId);
        //    return new OkObjectResult(quantities);
        //}
        [HttpPost]
        public IActionResult SaveImages(int productId, string[] images)
        {
            _productService.AddImages(productId, images);
            _productService.Save();
            return new OkObjectResult(images);
        }

        [HttpGet]
        public IActionResult GetImages(int productId)
        {
            var images = _productService.GetImages(productId);
            return new OkObjectResult(images);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _productService.Delete(id);
                _productService.Save();

                return new OkObjectResult(id);
            }
        }
        #endregion
    }
}
