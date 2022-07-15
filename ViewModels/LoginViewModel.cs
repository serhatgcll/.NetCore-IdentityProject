using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityProject.ViewModels
{
    public class LoginViewModel
    {    
        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifre en az 4 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
