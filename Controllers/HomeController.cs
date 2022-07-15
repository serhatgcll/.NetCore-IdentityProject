using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreIdentityProject.Models;
using CoreIdentityProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using NToastNotify.Helpers;

namespace CoreIdentityProject.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; }
        private readonly IToastNotification _toastNotification;

        public HomeController(UserManager<ApplicationUser> userManager,IToastNotification toastNotification)
        {
            _userManager = userManager;                         
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        public IActionResult SignUp()
        {
            return View();
        }

        //todo: Login sayfasına yönlendirme işleminde ki bug çözülecek.
        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;                       
                user.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {   
                    _toastNotification.AddSuccessToastMessage("Kullanıcı kayıt işlemi başarılı");

                    
                    //return RedirectToAction("Login");

                }
                
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                       ModelState.AddModelError("",item.Description); 
                       _toastNotification.AddErrorToastMessage(item.Description);
                    }
                }


            }


            return View(userViewModel);
        }
    }
}
