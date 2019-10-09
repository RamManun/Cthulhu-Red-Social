using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialNetwork1._1.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
 
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
 
            var role1 = new ApplicationRole { Name = "Admin" };
            var role2 = new ApplicationRole { Name = "User" };
 
            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser {
                UserName = "admn",
                SurName = "admn",
                BirthDay = new DateTime(1997, 4, 23),
                Email = "admn@gmail.com",
                Photo = "Admin.jpg",
                Gender = "Man"
            };
            string password = "admn11";
            var result = userManager.Create(admin, password);

            if(result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
            }

            base.Seed(context);
        }
    }
}