using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
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
    public class BrandController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IBrandService _brandService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public BrandController(IAuthorizationService authorizationService, IBrandService brandService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _authorizationService = authorizationService;
            _brandService = brandService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "Brand", Operation.Read);
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
            var model = _brandService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(BrandViewModel brandViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (brandViewModel.Id == 0)
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Brand {brandViewModel.Name} has been created",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _brandService.Add(announcement, announcementUsers, brandViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Brand {brandViewModel.Name} has been updated",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _brandService.Update(announcement, announcementUsers, brandViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                _brandService.Save();
                return new OkObjectResult(brandViewModel);
            }
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _brandService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _brandService.GetById(id);
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
                    Content = $"Brand {_brandService.GetById(id).Name} has been deleted",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                _brandService.Delete(announcement, announcementUsers, id);
                _brandService.Save();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                return new OkObjectResult(id);
            }
        }

        #endregion Get Data API
    }
}