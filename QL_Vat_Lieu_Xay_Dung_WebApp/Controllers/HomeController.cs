using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;
using System.Diagnostics;

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
                HotProducts = _productService.GetHotProducts(7),
                NewProducts = _productService.GetNewProducts(7),
                HomeSlides = _slideService.GetSlides("top"),
                HomeCategories = _productCategoryService.GetHomeCategories(7),
                MetaKeyWord = "Quảng Lý Vật Liệu Xây Dựng",
                MetaDescription = "Quảng Lý Vật Liệu Xây Dựng",
                Title = "Trang Chủ"
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RefreshCart()
        {
            return ViewComponent("HeaderCart");
        }
    }
}