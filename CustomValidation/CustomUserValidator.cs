using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using NToastNotify.Helpers;

namespace CoreIdentityProject.CustomValidation
{
    public class CustomUserValidator : IUserValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            string[] Digits = new[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            foreach (var digit in Digits)
            {
                if (user.UserName[0].ToString()==digit)
                {
                    errors.Add(new IdentityError()
                    {
                        Code = "UserNameStartWishFirstLetterDigit",
                        Description = "Kullanıcı adı sayısal karakter ile başlayamaz"
                    });
                }


               
            }
            if (errors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }





        }
    }
}

