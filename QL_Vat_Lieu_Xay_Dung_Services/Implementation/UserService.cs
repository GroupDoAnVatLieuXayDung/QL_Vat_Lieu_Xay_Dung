using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AppUserViewModel userViewModel)
        {
            var user = new AppUser()
            {
                UserName = userViewModel.UserName,
                Avatar = userViewModel.Avatar,
                Email = userViewModel.Email,
                FullName = userViewModel.FullName,
                DateCreated = DateTime.Now,
                PhoneNumber = userViewModel.PhoneNumber,
                Status = userViewModel.Status,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, userViewModel.Password);
            if (result.Succeeded && userViewModel.Roles.Count > 0)
            {
                var appUser = await _userManager.FindByNameAsync(user.UserName);
                if (appUser != null)
                    await _userManager.AddToRolesAsync(appUser, userViewModel.Roles);
            }

            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }


        public async Task<List<AppUserViewModel>> GetAllAsync()
        {
            return await _mapper.ProjectTo<AppUserViewModel>(_userManager.Users).ToListAsync();
        }

        public PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.FullName.Contains(keyword)
                                         || x.UserName.Contains(keyword)
                                         || x.Email.Contains(keyword));

            var totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var data = query.Select(x => new AppUserViewModel()
            {
                UserName = x.UserName,
                Avatar = x.Avatar,
                BirthDay = x.BirthDay.ToString(),
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                DateCreated = x.DateCreated
            }).ToList();
            var paginationSet = new PagedResult<AppUserViewModel>()
            {
                ResultList = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public async Task<AppUserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = _mapper.Map<AppUser, AppUserViewModel>(user);
            userViewModel.Roles = roles.ToList();
            return userViewModel;
        }

        public async Task<bool> UpdateAsync(AppUserViewModel userViewModel)
        {
            var user = await _userManager.FindByIdAsync(userViewModel.Id.ToString());
            //Remove current roles in db
            var currentRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user,
                userViewModel.Roles.Except(currentRoles).ToArray());

            if (result.Succeeded)
            {
                var needRemoveRoles = currentRoles.Except(userViewModel.Roles).ToArray();
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);

                //Update user detail
                user.FullName = userViewModel.FullName;
                user.Status = userViewModel.Status;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                await _userManager.UpdateAsync(user);
            }

            return result.Succeeded;
        }
    }
}
