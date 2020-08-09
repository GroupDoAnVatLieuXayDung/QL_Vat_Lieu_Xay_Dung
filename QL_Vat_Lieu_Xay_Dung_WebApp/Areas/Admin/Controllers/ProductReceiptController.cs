using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Enum;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
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
    public class ProductReceiptController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IProductReceiptService _productReceiptService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public ProductReceiptController(IProductReceiptService productReceiptService, IAuthorizationService authorizationService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _productReceiptService = productReceiptService;
            _authorizationService = authorizationService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "PRODUCT_RECEIPT", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Error");
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
        public async Task<IActionResult> SaveEntity(ProductReceiptViewModel productReceiptViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            if (productReceiptViewModel.Id == 0)
            {
                var notificationId = Guid.NewGuid().ToString();
                var announcement = new AnnouncementViewModel
                {
                    Title = User.GetSpecificClaim("FullName"),
                    DateCreated = DateTime.Now,
                    Content = $"The Product Receipt of {productReceiptViewModel.Supplier.FullName} has been created",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                _productReceiptService.Create(announcement, announcementUsers, productReceiptViewModel);
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
            }
            else
            {
                var notificationId = Guid.NewGuid().ToString();
                var announcement = new AnnouncementViewModel
                {
                    Title = User.GetSpecificClaim("FullName"),
                    DateCreated = DateTime.Now,
                    Content = $"The Product Receipt of {productReceiptViewModel.Supplier.FullName} has been updated",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                _productReceiptService.Update(announcement, announcementUsers, productReceiptViewModel);
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
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

        #endregion Get Data API
    }
}