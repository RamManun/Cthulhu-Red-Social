using Microsoft.AspNet.SignalR;
using SocialNetwork1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork1._1.Hubs
{
    public class DialogHub: Hub
    {
        public void Send(dynamic message)
        {
            ApplicationContext db = new ApplicationContext();
            string SenderId = message.SenderId.ToString();
            var sender = db.Users.First(u => u.Id == SenderId);
            message.SenderPhoto = sender.Photo;
            message.SenderName = sender.UserName;
            Clients.Others.addMessage(message);
            db.Dispose();
        }
    }
}