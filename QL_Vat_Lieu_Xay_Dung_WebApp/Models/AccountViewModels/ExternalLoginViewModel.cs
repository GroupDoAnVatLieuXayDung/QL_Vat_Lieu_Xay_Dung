using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        public ExternalLoginViewModel()
        {
        }

        public ExternalLoginViewModel(string email, string fullName, string phoneNumber)
        {
            Email = email;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật Khẩu Phải Có Độ Dài Từ {2} Đến {1}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật Khẩu Và Xác Nhận Mật Khẩu Không Trùng Khớp")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        public IFormFile Avatar { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}