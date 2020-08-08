using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
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
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        private readonly IAuthorizationService _authorizationService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public SupplierController(IAuthorizationService authorizationService, ISupplierService supplierService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _authorizationService = authorizationService;
            _supplierService = supplierService;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Get Data API

        [HttpPost]
        public async Task<IActionResult> SaveEntity(SupplierViewModel supplierViewModel)
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
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Supplier {supplierViewModel.FullName} has been created",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _supplierService.Add(announcement, announcementUsers, supplierViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Supplier {supplierViewModel.FullName} has been updated",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _supplierService.Update(announcement, announcementUsers, supplierViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
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
                    Content = $"Supplier {_supplierService.GetById(id).FullName} has been deleted",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                _supplierService.Delete(announcement, announcementUsers, id);
                _supplierService.Save();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                return new OkObjectResult(id);
            }
        }

        #endregion Get Data API
    }
}