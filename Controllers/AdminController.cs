using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentityProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentityProject.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser>_userManager { get; }

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public  IActionResult Index()
        {
            return  View(_userManager.Users.ToList());
        }
    }
}
