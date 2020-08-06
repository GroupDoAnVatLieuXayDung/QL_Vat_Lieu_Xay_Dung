using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_WebApp.Authorization;
using QL_Vat_Lieu_Xay_Dung_WebApp.Extensions;
using QL_Vat_Lieu_Xay_Dung_WebApp.SignalR;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHubContext<QLVLXD_Hub> _hubContext;
        public UserController(IUserService userService, IAuthorizationService authorizationService, IHubContext<QLVLXD_Hub> hubContext)
        {
            _userService = userService;
            _authorizationService = authorizationService;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "USER", Operation.Read);
            if (!result.Succeeded)
            {
                return new RedirectResult("/Admin/Login/Index");
            }
            return View();
        }
        #region Get Data API
        public IActionResult GetAll()
        {
            var model = _userService.GetAllAsync();

            return new OkObjectResult(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var model = await _userService.GetById(id);

            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _userService.GetAllPagingAsync(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(AppUserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (userViewModel.Id == null)
                {
                    var announcement = new AnnouncementViewModel()
                    {
                        Content = $"User {userViewModel.UserName} has been created",
                        DateCreated = DateTime.Now,
                        Status = Status.Active,
                        Title = "User created",
                        UserId = User.GetUserId(),
                        Id = Guid.NewGuid().ToString(),

                    };
                    await _userService.AddAsync(userViewModel);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", announcement);
                }
                else
                {
                    await _userService.UpdateAsync(userViewModel);
                }
                return new OkObjectResult(userViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                await _userService.DeleteAsync(id);

                return new OkObjectResult(id);
            }
        }
        #endregion
    }
}
