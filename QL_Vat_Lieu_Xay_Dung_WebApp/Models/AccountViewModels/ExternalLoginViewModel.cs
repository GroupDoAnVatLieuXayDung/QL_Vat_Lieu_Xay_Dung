﻿using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}