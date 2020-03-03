using DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataBase
{
   public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions options)
           : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AdvertisementPlan> AdvertisementPlans { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ClientRequest> ClientRequests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FileTbl> FileTbls { get; set; }
        public DbSet<GraphicDesigningPlan> GraphicDesigningPlans { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RefereeRequest> RefereeRequests { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<OrderOption> OrderOptions { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
