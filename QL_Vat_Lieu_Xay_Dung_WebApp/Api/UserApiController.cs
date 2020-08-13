using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    [Authorize]
    public class UserApiController : ApiController
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserApiController(UserManager<AppUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var model = await _userManager.FindByIdAsync(id);

            return new OkObjectResult(model);
        }

        /// <summary>
        /// Puts the specified user view model.
        /// </summary>
        /// <param name="accountDetailViewModel">The user view model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("update-{accountDetailViewModel}")]
        public async Task<IActionResult> Put(AccountDetailViewModel accountDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(accountDetailViewModel.Email);
                user.FullName = accountDetailViewModel.FullName;
                user.PhoneNumber = accountDetailViewModel.PhoneNumber;
                user.BirthDay = accountDetailViewModel.BirthDay;
                if (accountDetailViewModel.Avatar != null)
                {
                    user.Avatar = UploadImage(accountDetailViewModel.Avatar);
                }
                if (accountDetailViewModel.NewPassword != null && accountDetailViewModel.OldPassword != null)
                {
                    var kq = await _userManager.ChangePasswordAsync(user, accountDetailViewModel.OldPassword,
                        accountDetailViewModel.NewPassword);
                    if (!kq.Succeeded)
                    {
                        return new OkObjectResult(new GenericResult(false, "Mật Khẩu Cũ Không Khớp Vs Mật Khẩu Trong Hệ Thống"));
                    }
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new OkObjectResult(new GenericResult(true, "Cập Nhật Thành Công"));
                }
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return new BadRequestObjectResult(allErrors);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public string UploadImage(IFormFile avatar)
        {
            if (avatar == null)
            {
                return null;
            }
            var now = DateTime.Now;
            var filename = avatar
                .FileName
                .Trim('"');

            var imageFolder = $@"\uploaded\images\{now: yyyyMMdd}";

            var folder = _hostingEnvironment.WebRootPath + imageFolder;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var filePath = Path.Combine(folder, filename);
            using (var fs = System.IO.File.Create(filePath))
            {
                avatar.CopyTo(fs);
                fs.Flush();
            }
            return Path.Combine(imageFolder, filename).Replace(@"\", @"/");
        }
    }
}