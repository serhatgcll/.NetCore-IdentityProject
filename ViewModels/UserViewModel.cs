using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityProject.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName  { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber  { get; set; }
        [Required(ErrorMessage = "Email Adresi Gereklidir")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email adresi doğru formatta girilmelidir.")]
        public string Email  { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }



    }
}
