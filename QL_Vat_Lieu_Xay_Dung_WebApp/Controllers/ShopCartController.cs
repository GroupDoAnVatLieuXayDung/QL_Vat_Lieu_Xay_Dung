using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Utilities.Constants;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        public ShopCartController(IProductService productService, IBillService billService)
        {
            _productService = productService;
            _billService = billService;
        }
        [Route("shop-cart.html", Name = "ShopCart")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        #region API AJAX
        /// <summary>
        /// Lấy Danh Sách Sản Phẩm Trong Giỏ Hàng
        /// </summary>
        /// <returns>Status 200 - List Product</returns>
        public IActionResult GetCart()
        {
            // Nếu session sẽ lấy dữ liệu ra trước nếu dữ liệu ko lấy ra dc (session == null) thì sẽ tạo mới
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession) ?? new List<ShopCartViewModel>();

            return new OkObjectResult(session);
        }

        /// <summary>
        /// Xóa Sản Phẩm Trong Giỏ Hảng
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IActionResult RemoveFromCart(int productId)
        {
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession);
            if (session == null) return new EmptyResult();
            var hasChanged = false;
            foreach (var item in session.Where(item => item.Product.Id == productId))
            {
                session.Remove(item);
                hasChanged = true;
                break;
            }
            if (hasChanged)
            {
                HttpContext.Session.Set(CommonConstants.CartSession, session);
            }
            return new OkObjectResult(productId);
        }

        /// <summary>
        /// Cập Nhật Số Lượng Sản Phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public IActionResult UpdateCart(int productId, int quantity)
        {
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession);
            if (session == null) return new EmptyResult();
            var hasChanged = false;
            foreach (var item in session.Where(x => x.Product.Id == productId))
            {
                var product = _productService.GetById(productId);
                    item.Product = product;
                    item.Quantity = quantity;
                    item.Price = product.PromotionPrice ?? product.Price;
                    hasChanged = true;
            }
            if (hasChanged)
            {
                HttpContext.Session.Set(CommonConstants.CartSession, session);
            }
            return new OkObjectResult(productId);
        }

        /// <summary>
        /// Thêm Sản Phẩm Vào Giỏ Hàng
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity, int size)
        {
            var product = _productService.GetById(productId);
            var getSize = _billService.GetSize(size);
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            {
                if (session.Any(x => x.Product.Id == productId && x.Size.Id == size))
                {
                    foreach (var shopCartViewModel in session.Where(shopCartViewModel =>
                        shopCartViewModel.Product.Id == productId && shopCartViewModel.Size.Id == size))
                    {
                        shopCartViewModel.Quantity += quantity;
                        shopCartViewModel.Price = product.PromotionPrice ?? product.Price;
                    }
                    //Update back to cart
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
                else
                {
                    session.Add(new ShopCartViewModel()
                    {
                        Product = product,
                        Quantity = quantity,
                        Size = getSize,
                        Price = product.PromotionPrice ?? product.Price
                    });
                    //Update back to cart
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
            }
            else
            {
                // Thêm Mới Sản Phẩm Vào Giỏ Hàng
                var cart = new List<ShopCartViewModel>();
                cart.Add(new ShopCartViewModel()
                {
                    Product = product,
                    Quantity = quantity,
                    Size = getSize,
                    Price = product.PromotionPrice ?? product.Price
                });
                HttpContext.Session.Set(CommonConstants.CartSession, cart);
            }
            return new OkObjectResult(productId);
        }

        /// <summary>
        /// Xoa Danh Sach San Pham Trong Gio Hang
        /// </summary>
        /// <returns></returns>
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CommonConstants.CartSession);
            return new OkResult();
        }
        #endregion
    }
}
