using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace SocialNetwork1._1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String SurName { get; set; }
        public DateTime BirthDay { get; set; }
        public String Photo { get; set; }
        public String Gender { get; set; }

        public virtual ICollection<Message> SendedMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<ApplicationUser> FirstFriends { get; set; }
        public virtual ICollection<ApplicationUser> SecondFriends { get; set; }

        public ApplicationUser()
        {
            SendedMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            FirstFriends = new List<ApplicationUser>();
            SecondFriends = new List<ApplicationUser>();
        }

        /*public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("BirthDay", this.BirthDay.Year.ToString()));
            return userIdentity;
        }*/
    }
}