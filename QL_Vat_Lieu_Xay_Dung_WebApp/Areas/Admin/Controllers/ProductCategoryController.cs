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
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        private readonly IAuthorizationService _authorizationService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public ProductCategoryController(IProductCategoryService productCategoryService, IAuthorizationService authorizationService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _productCategoryService = productCategoryService;
            _authorizationService = authorizationService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "PRODUCT_CATEGORY", Operation.Read);
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
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productCategoryService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(ProductCategoryViewModel productViewModel)
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
                        Content = $"Product Category {productViewModel.Name} has been created",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _productCategoryService.Add(announcement, announcementUsers, productViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Product Category {productViewModel.Name} has been updated",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _productCategoryService.Update(announcement, announcementUsers, productViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                _productCategoryService.Save();
                return new OkObjectResult(productViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                var notificationId = Guid.NewGuid().ToString();
                var announcement = new AnnouncementViewModel
                {
                    Title = User.GetSpecificClaim("FullName"),
                    DateCreated = DateTime.Now,
                    Content = $"Product Category {_productCategoryService.GetById(id).Name} has been deleted",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                _productCategoryService.Delete(announcement, announcementUsers, id);
                _productCategoryService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                if (sourceId == targetId)
                {
                    return new BadRequestResult();
                }
                else
                {
                    _productCategoryService.UpdateParentId(sourceId, targetId, items);
                    _productCategoryService.Save();
                    return new OkResult();
                }
            }
        }

        [HttpPost]
        public IActionResult ReOrder(int sourceId, int targetId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                if (sourceId == targetId)
                {
                    return new BadRequestResult();
                }
                else
                {
                    _productCategoryService.ReOrder(sourceId, targetId);
                    _productCategoryService.Save();
                    return new OkResult();
                }
            }
        }

        #endregion Get Data API
    }
}