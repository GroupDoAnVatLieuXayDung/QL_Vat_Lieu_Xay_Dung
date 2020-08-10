using System.ComponentModel.DataAnnotations;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        public ExternalLoginViewModel()
        {
            
        }
        public ExternalLoginViewModel(string email, string fullName,string dateOfBirth,string phoneNumber)
        {
            Email = email;
            FullName = fullName;
            DOB = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}