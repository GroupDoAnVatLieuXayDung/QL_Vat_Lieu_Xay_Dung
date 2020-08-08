using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Helpers;
using QL_Vat_Lieu_Xay_Dung_WebApp.Authorization;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly IAuthorizationService _authorizationService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public ProductController(IProductService productService, IAuthorizationService authorizationService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _productService = productService;
            _authorizationService = authorizationService;
            _hubContext = hubContext;
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
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId, null, keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(ProductViewModel productViewModel)
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
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Product {productViewModel.Name} has been created",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _productService.Add(announcement, announcementUsers, productViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Product {productViewModel.Name} has been updated",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _productService.Update(announcement, announcementUsers, productViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                _productService.Save();
                return new OkObjectResult(productViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveImages(int productId, string[] images)
        {
            var notificationId = Guid.NewGuid().ToString();
            var announcement = new AnnouncementViewModel
            {
                Title = User.GetSpecificClaim("FullName"),
                DateCreated = DateTime.Now,
                Content = $"Product Images of {_productService.GetById(productId).Name} has been updated",
                Id = notificationId,
                UserId = User.GetUserId(),
                Image = User.GetSpecificClaim("Avatar"),
                Status = Status.Active
            };
            var announcementUsers = new List<AnnouncementUserViewModel>()
            {
                new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
            };

            _productService.AddImages(productId, images);
            _productService.Save();
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
            return new OkObjectResult(images);
        }

        [HttpGet]
        public IActionResult GetImages(int productId)
        {
            var images = _productService.GetImages(productId);
            return new OkObjectResult(images);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                var notificationId = Guid.NewGuid().ToString();
                var announcement = new AnnouncementViewModel
                {
                    Title = User.GetSpecificClaim("FullName"),
                    DateCreated = DateTime.Now,
                    Content = $"Product {_productService.GetById(id).Name} has been deleted",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };

                _productService.Delete(announcement, announcementUsers, id);
                _productService.Save();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                return new OkObjectResult(id);
            }
        }

        #endregion AJAX API
    }
}