using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Constants;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;
using QL_Vat_Lieu_Xay_Dung_WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductService _productService;

        private readonly IBillService _billService;

        private readonly IConfiguration _configuration;

        private readonly IEmailSender _emailSender;

        private readonly IViewRenderService _viewRenderService;

        public ShopCartController(IProductService productService, IBillService billService, IConfiguration configuration, IEmailSender emailSender, IViewRenderService viewRenderService)
        {
            _productService = productService;
            _billService = billService;
            _configuration = configuration;
            _emailSender = emailSender;
            _viewRenderService = viewRenderService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("shop-cart.html", Name = "ShopCart")]
        public IActionResult Index()
        {
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("checkout.html", Name = "Checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            var model = new CheckoutViewModel();
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession);
            model.Carts = session;
            return View(model);
        }

        #region API AJAX

        [ApiExplorerSettings(IgnoreApi = true)]
        /// <summary>
        /// Checkouts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [Route("checkout.html", Name = "Checkout")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var session = HttpContext.Session.Get<List<ShopCartViewModel>>(CommonConstants.CartSession);

            if (ModelState.IsValid)
            {
                if (session != null)
                {
                    var details = session.Select(item => new BillDetailViewModel()
                    {
                        Product = item.Product,
                        Price = item.Price,
                        Size = item.Size,
                        SizeId = item.Size.Id,
                        Quantity = item.Quantity,
                        ProductId = item.Product.Id
                    })
                        .ToList();
                    var billViewModel = new BillViewModel()
                    {
                        CustomerMobile = model.CustomerMobile,
                        BillStatus = BillStatus.New,
                        CustomerAddress = model.CustomerAddress,
                        CustomerName = model.CustomerName,
                        CustomerMessage = model.CustomerMessage,
                        DateCreated = DateTime.Now,
                        Status = Status.Active,
                        BillDetails = details
                    };
                    if (User.Identity.IsAuthenticated)
                    {
                        billViewModel.CustomerId = new Guid(User.GetSpecificClaim("Id"));
                    }
                    try
                    {
                        _billService.Create(billViewModel);
                        _billService.Save();
                        ViewData["Success"] = true;
                        var content = await _viewRenderService.RenderToStringAsync("ShopCart/BillMail", billViewModel);
                        //Send mail
                        await _emailSender.SendEmailAsync(_configuration["MailSettings:AdminMail"], "Đơn Hàng Mới Đến Từ Website Quản Lý Vật Liệu Xây Dựng", content);

                        HttpContext.Session.Remove(CommonConstants.CartSession);
                    }
                    catch (Exception ex)
                    {
                        ViewData["Success"] = false;
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            model.Carts = session;
            return View(model);
        }

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
        [ApiExplorerSettings(IgnoreApi = true)]
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
        [ApiExplorerSettings(IgnoreApi = true)]
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
        [ApiExplorerSettings(IgnoreApi = true)]
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
                var cart = new List<ShopCartViewModel>
                {
                    new ShopCartViewModel()
                    {
                        Product = product,
                        Quantity = quantity,
                        Size = getSize,
                        Price = product.PromotionPrice ?? product.Price
                    }
                };
                HttpContext.Session.Set(CommonConstants.CartSession, cart);
            }
            return new OkObjectResult(productId);
        }

        /// <summary>
        /// Xoa Danh Sach San Pham Trong Gio Hang
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CommonConstants.CartSession);
            return new OkResult();
        }

        #endregion API AJAX
    }
}