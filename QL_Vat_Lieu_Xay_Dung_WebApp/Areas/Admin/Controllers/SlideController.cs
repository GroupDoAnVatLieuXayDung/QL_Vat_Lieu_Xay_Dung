using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
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
    public class SlideController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly ISlideService _slideService;

        private readonly IHubContext<QLVLXD_Hub> _hubContext;

        public SlideController(ISlideService slideService, IAuthorizationService authorizationService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _slideService = slideService;
            _authorizationService = authorizationService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "SLIDE", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Login/Index");
            }

            return View();
        }

        #region Get Data API

        [HttpPost]
        public async Task<IActionResult> SaveEntity(SlideViewModel slideViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (slideViewModel.Id == 0)
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Slide {slideViewModel.Name} has been created",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _slideService.Add(announcement, announcementUsers, slideViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    var notificationId = Guid.NewGuid().ToString();
                    var announcement = new AnnouncementViewModel
                    {
                        Title = User.GetSpecificClaim("FullName"),
                        DateCreated = DateTime.Now,
                        Content = $"Slide {slideViewModel.Name} has been updated",
                        Id = notificationId,
                        UserId = User.GetUserId(),
                        Image = User.GetSpecificClaim("Avatar"),
                        Status = Status.Active
                    };
                    var announcementUsers = new List<AnnouncementUserViewModel>()
                    {
                        new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                    };
                    _slideService.Update(announcement, announcementUsers, slideViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                _slideService.Save();
                return new OkObjectResult(slideViewModel);
            }
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _slideService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _slideService.GetById(id);
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
                    Content = $"Slide {_slideService.GetById(id).Name} has been deleted",
                    Id = notificationId,
                    UserId = User.GetUserId(),
                    Image = User.GetSpecificClaim("Avatar"),
                    Status = Status.Active
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                _slideService.Delete(announcement, announcementUsers, id);
                _slideService.Save();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                return new OkObjectResult(id);
            }
        }

        #endregion Get Data API
    }
}