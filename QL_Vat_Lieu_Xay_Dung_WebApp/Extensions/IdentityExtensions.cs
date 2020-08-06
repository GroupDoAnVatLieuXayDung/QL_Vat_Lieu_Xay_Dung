using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity).Claims.Single(x => x.Type == "Id");
            return Guid.Parse(claim.Value);
        }
        public static string GetSpecificClaim(this ClaimsPrincipal claimsIdentity, string keyClaimsIdentity)
        {
            var claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == keyClaimsIdentity);
            return claim != null ? claim.Value : string.Empty;
        }
    }
}
