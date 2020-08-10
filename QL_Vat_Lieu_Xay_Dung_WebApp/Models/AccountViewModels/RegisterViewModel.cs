using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Yêu Cầu Nhập Họ Và Tên", AllowEmptyStrings = false)]
        [Display(Name = "Họ Và Tên")]
        public string FullName { set; get; }

        [Display(Name = "Ngày Sinh")]
        public DateTime? BirthDay { set; get; }

        [Required(ErrorMessage = "Yêu Cầu Nhập Tên Đăng Nhập", AllowEmptyStrings = false)]
        [Display(Name = "Tên Đăng Nhập")]
        public string UserName { set; get; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật Khẩu Phải Có Độ Dài Từ {1} Đến {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khẩu")]
        [Compare("Password", ErrorMessage = "Mật Khẩu Và Xác Nhận Mật Khẩu Không Trùng Khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { set; get; }

        [Display(Name = "Ảnh")]
        public IFormFile Avatar { get; set; }
    }
}