using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentityProject.CustomValidation
{
    public class CustomIdentityErrorDescriber :IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"Bu {userName} geçersizdir."
            };

        }

        public override IdentityError DuplicateEmail(string email)
        {

            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"Bu {email} adresi kullanılmaktadır."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz en az {length} karakterde  olmalıdır."
            };
        }
    }
}
