using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Helpers
{
    public class CustomClaim : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        private readonly UserManager<AppUser> _userManager;

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
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("Id", user.Id.ToString()),
                new Claim("Roles",string.Join(";",roles)),
                new Claim("FullName",user.FullName ?? string.Empty),
                new Claim("Phone",user.PhoneNumber ?? string.Empty),
                new Claim("Avatar",user.Avatar?? "/img_ds/img.jpg"),
                new Claim("Email",user.Email ?? string.Empty)
            });
            return principal;
        }
    }
}