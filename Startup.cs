using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentityProject.CustomValidation;
using CoreIdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NToastNotify;

namespace CoreIdentityProject
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationIdentityDbContext>(options =>         
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionStrings"]);
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(opts =>
                {
                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters =
                        "abcçdefghýijklmnoöpqrsþtuüvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";



                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequiredLength = 4;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                }).AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
              ProgressBar = false,
              PositionClass =ToastPositions.TopRight ,
              PreventDuplicates = true,
              CloseButton = true
            });
                 
            services.AddMvc(options => options.EnableEndpointRouting = false);
             
        }

        

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseNToastNotify();
        }
    }
}
