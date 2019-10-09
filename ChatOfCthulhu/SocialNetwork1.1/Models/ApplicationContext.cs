using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SocialNetwork1._1.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        /*public DbSet<ApplicationUser> Friends { get; set; }*/
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.FirstFriends)
                .WithMany(u => u.SecondFriends)
                .Map(t => t.MapLeftKey("FirstFriendId")
                .MapRightKey("SecondFriendId")
                .ToTable("Friends"));

            modelBuilder.Entity<Message>()
                .HasRequired<ApplicationUser>(m => m.Sender)
                .WithMany(u => u.SendedMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired<ApplicationUser>(m => m.Receiver) 
                .WithMany(u => u.ReceivedMessages)
                .WillCascadeOnDelete(false);
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}