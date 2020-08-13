using Microsoft.AspNetCore.Http;
using QL_Vat_Lieu_Xay_Dung_WebApp.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels
{
    public class AccountDetailViewModel
    {
        public AccountDetailViewModel()
        {
        }

        [Required(ErrorMessage = "Yêu Cầu Nhập Tên Đăng Nhập", AllowEmptyStrings = false)]
        [Display(Name = "Tên Đăng Nhập")]
        public string UserName { set; get; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yêu Cầu Nhập Họ Và Tên", AllowEmptyStrings = false)]
        [Display(Name = "Họ Và Tên")]
        public string FullName { set; get; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { set; get; }

        [Display(Name = "Ảnh")]
        public IFormFile Avatar { get; set; }

        [Required]
        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { set; get; }

        [StringLength(100, ErrorMessage = "Mật Khẩu Phải Có Độ Dài Từ {2} Đến {1}", MinimumLength = 6)]
        [Display(Name = "Mật Khẩu Cũ")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [StringLength(100, ErrorMessage = "Mật Khẩu Phải Có Độ Dài Từ {2} Đến {1}", MinimumLength = 6)]
        [Display(Name = "Mật Khẩu Mới")]
        [DataType(DataType.Password)]
        [NotEqual("OldPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khẩu Mới")]
        [Compare("NewPassword", ErrorMessage = "Mật Khẩu Và Xác Nhận Mật Khẩu Không Trùng Khớp")]
        public string ConfirmPassword { get; set; }
    }
}