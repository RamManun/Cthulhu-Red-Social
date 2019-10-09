using System.Web.Http;
using SocialNetwork1._1.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetwork1._1.Controllers
{
    public class ValuesController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        public class UserViewModel
        {
            public string Id { get; set; }
            public string Photo { get; set; }
            public string UserName { get; set; }
            public string SurName { get; set; }
            public DateTime Age { get; set; }
            public string Gender { get; set; }
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            var users = db.Users.Select(u => new UserViewModel {
                Id = u.Id,
                Photo = u.Photo,
                UserName = u.UserName,
                SurName = u.SurName,
                Age = u.BirthDay,
                Gender = u.Gender,
            });
            return users;
        }

        public UserViewModel GetUser(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            return new UserViewModel
            {
                Id = user.Id,
                Photo = user.Photo,
                UserName = user.UserName,
                SurName = user.SurName,
                Age = user.BirthDay,
                Gender = user.Gender,
            };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}