using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_WebApp.Controllers;
using System;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, Guid userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, Guid userId, string token, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, token },
                protocol: scheme);
        }
    }
}