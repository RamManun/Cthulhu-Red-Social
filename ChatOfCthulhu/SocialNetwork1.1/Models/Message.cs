using System;

namespace SocialNetwork1._1.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsReaded { get; set; }
        public DateTime SendingTime { get; set; }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}