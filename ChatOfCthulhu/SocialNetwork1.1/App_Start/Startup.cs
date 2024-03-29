﻿using Microsoft.Owin;
using Owin;
using SocialNetwork1._1.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(SocialNetwork1._1.Startup))]

namespace SocialNetwork1._1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // регистрация менеджера ролей
            //
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Muestra/Index"),
            });
            app.MapSignalR();
        }
    }
}