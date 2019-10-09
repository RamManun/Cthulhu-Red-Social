using System.Web.Mvc;
using SocialNetwork1._1.Models;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Threading;
using System.Security.Claims;
using System.Linq;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using SocialNetwork.BL;

namespace SocialNetwork1._1.Controllers
{
    public class HomeController : Controller
    {

        LibroBL _LibroBL;
        CategoriasBL _categoriasBL;

        public HomeController()
        {
            _LibroBL = new SocialNetwork.BL.LibroBL();
            _categoriasBL = new SocialNetwork.BL.CategoriasBL();
        }

        private ApplicationContext db = new ApplicationContext();

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        private class MessageEqualityComparer : IEqualityComparer<Message>
        {
            public bool Equals(Message m1, Message m2)
            {
                return (m1.Receiver.Id == m2.Receiver.Id && m1.Sender.Id == m2.Sender.Id) || 
                    (m1.Receiver.Id == m2.Sender.Id && m1.Sender.Id == m2.Receiver.Id);
            }

            public int GetHashCode(Message message)
            {
                if (message.Sender.Id.CompareTo(message.Receiver.Id) >= 0)
                    return message.Sender.Id.GetHashCode();
                else
                    return message.Receiver.Id.GetHashCode();
            }
        }

        [Authorize]
        public async Task<ActionResult> Index(string Id)
        {
            ApplicationUserManager userManager = UserManager;
            if (Id == null)
            {
                var authUser = await userManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
                return View(authUser);
            }
            else
            {
                ApplicationUser user = await userManager.FindByIdAsync(Id);
                return View(user);
            }
        }

        [Authorize]
        public async Task<ActionResult> AddFriend(string id)
        {
            ApplicationUser firstUser = await UserManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
            ApplicationUser secondUser = await UserManager.FindByIdAsync(id);
            firstUser.SecondFriends.Add(secondUser);
            await UserManager.UpdateAsync(firstUser);
            return RedirectToAction("Index", "Home", new { id = id });
        }

        [Authorize]
        public async Task<ActionResult> DeleteFriend(string id)
        {
            ApplicationUser firstUser = await UserManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
            ApplicationUser secondUser = await UserManager.FindByIdAsync(id);
            if (firstUser.SecondFriends.Contains(secondUser))
            {
                firstUser.SecondFriends.Remove(secondUser);
                await UserManager.UpdateAsync(firstUser);
            }
            else
            {
                secondUser.SecondFriends.Remove(firstUser);
                await UserManager.UpdateAsync(secondUser);
            }
            /*var dialog = firstUser.ReceivedMessages
                .Union(firstUser.SendedMessages)
                .Where(u => (u.SenderId == secondUser.Id) || (u.ReceiverId == secondUser.Id))
                .ToList();
            foreach (var m in dialog)
            {
                if (m.Sender.Id == firstUser.Id)
                {
                    firstUser.SendedMessages.Remove(m);
                    secondUser.ReceivedMessages.Remove(m);
                }
                else
                {
                    firstUser.ReceivedMessages.Remove(m);
                    secondUser.SendedMessages.Remove(m);
                }
            }
            await UserManager.UpdateAsync(firstUser);
            await UserManager.UpdateAsync(secondUser);*/
            return RedirectToAction("Index", "Home", new { id = id });
        }

        [Authorize]
        public async Task<ActionResult> Friends()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
            var friends = user.FirstFriends.Union(user.SecondFriends);
            return View(friends);
        }
        
        [Authorize]
        public async Task<ActionResult> Dialogs()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
            var messages = user.ReceivedMessages.Union(user.SendedMessages).ToList();
            messages.Sort((m1, m2) => m2.SendingTime.CompareTo(m1.SendingTime));
            IEnumerable<Message> dialogs = messages.Distinct(new MessageEqualityComparer());

            return View(dialogs);
        }

        [Authorize]
        public async Task<ActionResult> Dialog(string id_1, string id_2)
        {
            ApplicationUser firstUser = await UserManager.FindByIdAsync(AuthenticationManager.User.Identity.GetUserId());
            var secondUserId = firstUser.Id == id_1 ? id_2 : id_1;
            var dialog = firstUser.ReceivedMessages
                .Union(firstUser.SendedMessages)
                .Where(u => (u.SenderId == secondUserId) || (u.ReceiverId == secondUserId))
                .ToList();
            dialog.Sort((m1, m2) => m2.SendingTime.CompareTo(m1.SendingTime));
            ViewBag.NewMessageSenderId = firstUser.Id;
            //ViewBag.SenderPhoto = firstUser.Photo;
            //ViewBag.SenderName = firstUser.UserName;
            ViewBag.NewMessageReceiverId = secondUserId;
            return View(dialog);
        }

        [Authorize]
        public ActionResult UserSearch()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSearch(SearchModel searchModel)
        {
            IQueryable<ApplicationUser> users = UserManager.Users;
            if (!String.IsNullOrEmpty(searchModel.UserName))
                users = users.Where(u => u.UserName == searchModel.UserName);
            if (!String.IsNullOrEmpty(searchModel.SurName))
                users = users.Where(u => u.UserName == searchModel.SurName);
            if (searchModel.AgeMin != null)
                users = users.Where(u => DbFunctions.DiffYears(u.BirthDay, DateTime.Today) >= searchModel.AgeMin);
            if (searchModel.AgeMax != null)
                users = users.Where(u => DbFunctions.DiffYears(u.BirthDay, DateTime.Today) <= searchModel.AgeMax);
            if (!String.IsNullOrEmpty(searchModel.Gender))
                users = users.Where(u => u.Gender == searchModel.Gender);
            return View(users);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SendMessage(Message message)
        {
            message.SendingTime = DateTime.Now;
            message.IsReaded = false;
            
            db.Messages.Add(message);
            db.SaveChanges();
            var sender = await UserManager.FindByIdAsync(message.SenderId);
            var msg = sender.SendedMessages.First(m => m.Id == message.Id);
            return PartialView(msg);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllMessages()
        {
            var messages = db.Messages.ToList();
            return View(messages);
        }

        public ActionResult MobileView()
        {
            return View();
        }

        public ActionResult Libros()
        {
            var listadeLibros = _LibroBL.ObtenerLibros();

            return View(listadeLibros);
        }

        public ActionResult Detalle(int id)
        {
            var Libro = _LibroBL.ObtenerLibro(id);

            return View(Libro);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}   