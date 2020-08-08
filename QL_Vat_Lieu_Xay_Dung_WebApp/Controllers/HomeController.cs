using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ISlideService _slideService;
        public HomeController(IProductService productService, IProductCategoryService productCategoryService, ISlideService slideService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _slideService = slideService;
        }

        public IActionResult Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            var homeViewModel = new HomeViewModel
            {

                HotProducts = _productService.GetHotProducts(5),
                TopSellProducts = _productService.GetNewProducts(5),
                HomeSlides = _slideService.GetSlides("top"),
                HomeCategories = _productCategoryService.GetHomeCategories(5),
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
