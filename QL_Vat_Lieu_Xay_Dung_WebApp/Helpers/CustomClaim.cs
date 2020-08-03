using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Helpers
{
    public class CustomClaim : UserClaimsPrincipalFactory<AppUser,AppRole>
    {
        readonly UserManager<AppUser> _userManager;
        public CustomClaim(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManager = userManager;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Id",value:user.Id.ToString()), 
                new Claim("Roles",string.Join(";",roles)),
                new Claim("FullName",user.FullName),
                new Claim("Avatar",user.Avatar??string.Empty),
                new Claim("Email",user.Email)
            });
            return principal;
        }
    }
}
